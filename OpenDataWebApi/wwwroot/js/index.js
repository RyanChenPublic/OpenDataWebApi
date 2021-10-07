$(document).ready(() => {
    //綁定取得資料按鈕
    $("#getOpenData").on("click", () => {
         getOpenData();
    })
    $("#InsertDb").on("click", () => {
        InsertDb();
    })
})

//fetch 後台API取得資料
function getOpenData() {

    fetch("api/Population", { method: 'get', redirect: 'follow' }).then(response => {
        if (!response.ok) throw new Error(response.statusText)
        return response.json();
    }).then(result => 
        createTable(result.responseData)
    ).catch(function (err) {
    })
}

function InsertDb() {
    fetch("api/Population", { method: "post", redirect: 'follow' }).then(response => {
        return response;
    }).then(result =>
        console.log(result)
        )
        .catch(function (err) {
            console.log(err);
        })
};
//建立畫面表格
function createTable(lists){
    let root = $("#OpenDataTable");
    let frag = $(document.createDocumentFragment());
    let columns = root.find("thead").find("th");
    root.find("tbody").empty();
    lists.forEach(data => {
        let tr = $("<tr>");
        // 畫面上的表格欄位與資料欄位的對應
        columns.each((i, item) => {
            let field = $(item).data("field");
            let value = data[field] == null ? "" : data[field];
            let td = $("<td/>");
            switch (field) {
                default:
                    td.text(value);
                    break;
              
            }
            tr.append(td);
        });
        frag.append(tr);
    });
    root.find("tbody").append(frag);
}