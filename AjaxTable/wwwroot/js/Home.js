$(() => {

    function onload() {
        console.log("works")
        $.get(`/home/getpeople`, ppl => {
            $("#my-table tbody td").remove()
            ppl.forEach(p => {
                $("#my-table tbody").append(
                    `<tr>
                        <td class="f">${p.firstname}</td>
                        <td class="l">${p.lastname}</td>
                        <td class="a">${p.age}</td>
                        <td class"e"><button class="btn btn-success edit" data-edit="${p.id}">Edit</button></td>
                         <td><button class="btn btn-danger delete" data-delete="${p.id}">Delete</button></td>
                    <tr>`
                )
            })
        
        })
    }
    onload();

    $("#add").on('click', function () {
        const firstname = $("#firstname").val();
        const lastname = $("#lastname").val();
        const age = parseInt($("#age").val());
        const person = {
            firstname,
            lastname,
            age
        };
        $.post('/home/add', person, function (p) {
            onload();
        })
    })
    $("#my-table").on('click', '.edit', function () {
        let Edit = parseInt($(this).data('edit'));
        let firstnamem = $(this).closest('tr').find("td:eq(0)").text();
        let lastnamem = $(this).closest('tr').find("td:eq(1)").text();
        let agem = $(this).closest('tr').find("td:eq(2)").text();
        $("#mfirstname").val(firstnamem);
        $("#mlastname").val(lastnamem);
        $("#mage").val(agem);
        $("#h").val(Edit);
        $("#my-modal").show(); 
        
    })
    $("#Save").on('click', function () {
        const firstname = $("#mfirstname").val();
        const lastname = $("#mlastname").val();
        const age = parseInt($("#mage").val());
        const Id = parseInt($("#h").val());
        const person = {
            Id,
            firstname,
            lastname,
            age
        };
        $.post('/home/edit', person, function (p) {
            onload();
        })
        $("#my-modal").hide();
    })
    $("#my-table").on('click', '.delete', function () {
        let Edit = parseInt($(this).data('delete'));
        const Id = {
            Id: Edit
        }
        $.post('/home/delete', Id, function (p) {
            onload();
        })
    })

})