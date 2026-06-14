---
title: Quản lý Workbook Biểu đồ trong Bản trình chiếu bằng JavaScript
linktitle: Workbook Biểu đồ
type: docs
weight: 70
url: /vi/nodejs-java/chart-workbook/
keywords:
- workbook biểu đồ
- dữ liệu biểu đồ
- ô workbook
- nhãn dữ liệu
- bảng tính
- nguồn dữ liệu
- workbook ngoại
- dữ liệu ngoại
- PowerPoint
- trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Khám phá Aspose.Slides cho Node.js thông qua Java: dễ dàng quản lý workbook biểu đồ trong các định dạng PowerPoint và OpenDocument để tối ưu hoá dữ liệu trình chiếu của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với workbook biểu đồ trong Aspose.Slides. Nó cho thấy cách đọc và ghi dữ liệu biểu đồ qua các stream workbook, sử dụng các ô workbook làm nhãn dữ liệu biểu đồ, truy cập các bộ sưu tập worksheet và chỉ định loại nguồn dữ liệu cho các giá trị biểu đồ.

Nó cũng đề cập đến việc làm việc với workbook bên ngoài như nguồn dữ liệu cho biểu đồ. Các ví dụ minh họa cách tạo và gán một workbook bên ngoài, lấy đường dẫn của workbook bên ngoài được liên kết với biểu đồ và chỉnh sửa dữ liệu biểu đồ khi workbook sẵn có.

## **Đọc và Ghi Dữ liệu Biểu đồ từ Workbook**

Aspose.Slides cung cấp các phương thức [readWorkbookStream](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) và [writeWorkbookStream](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) cho phép bạn đọc và ghi workbook dữ liệu biểu đồ (chứa dữ liệu biểu đồ đã được chỉnh sửa bằng Aspose.Cells). **Note** rằng dữ liệu biểu đồ phải được tổ chức theo cùng cách hoặc phải có cấu trúc tương tự nguồn.

```javascript
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var data = chart.getChartData();
    var stream = data.readWorkbookStream();
    data.getSeries().clear();
    data.getCategories().clear();
    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Đặt Ô WorkBook làm Nhãn Dữ liệu Biểu đồ**

1. Tạo một thể hiện của lớp [Presentation](https://apireference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation) .
2. Lấy tham chiếu của slide thông qua chỉ mục của nó.
3. Thêm biểu đồ Bubble với một số dữ liệu.
4. Truy cập series của biểu đồ.
5. Đặt ô workbook làm nhãn dữ liệu.
6. Lưu bản trình chiếu.

```javascript
var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// Khởi tạo một lớp trình chiếu đại diện cho tệp trình chiếu
var pres = new aspose.slides.Presentation("chart2.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    var dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    var wb = chart.getChartData().getChartDataWorkbook();
    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));
    pres.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Quản lý Worksheets**

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    var wb = chart.getChartData().getChartDataWorkbook();
    for (var i = 0; i < wb.getWorksheets().size(); i++) {
        console.log(wb.getWorksheets().get_Item(i).getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Xác định Loại Nguồn Dữ liệu**

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var val = chart.getChartData().getSeries().get_Item(0).getName();
    val.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    val.setData("LiteralString");
    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Phát hiện Định dạng Workbook Nhúng không được Hỗ trợ**

Aspose.Slides không hỗ trợ định dạng workbook nhị phân Excel (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể sử dụng phương thức `getEmbeddedWorkbookType` trên [ChartData](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdata/) cùng với enumeration [WorkbookType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/workbooktype/) để phát hiện các định dạng không được hỗ trợ và bỏ qua các biểu đồ đó.

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapes = slide.getShapes();

    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        let shape = shapes.get_Item(shapeIndex);

        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) continue;

        let chart = shape;
        let chartData = chart.getChartData();

        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro) {
            // Workbook nhúng ở định dạng .xlsb, không được hỗ trợ.
            continue;
        }

        // Đọc hoặc sửa dữ liệu workbook biểu đồ tại đây.
    }
} finally {
    presentation.dispose();
}
```

## **Workbook Ngoại**

Aspose.Slides hỗ trợ workbook ngoại như nguồn dữ liệu cho biểu đồ.

### **Tạo Workbook Ngoại**

Sử dụng các phương thức **`readWorkbookStream`** và **`setExternalWorkbook`**, bạn có thể tạo một workbook ngoại từ đầu hoặc biến một workbook nội thành ngoại.

```javascript
var pres = new aspose.slides.Presentation();
try {
    final var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    var fileStream = java.newInstanceSync("java.io.FileOutputStream", workbookPath);
    try {
        var workbookData = chart.getChartData().readWorkbookStream();
        fileStream.write(workbookData, 0, workbookData.length);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
    chart.getChartData().setExternalWorkbook(workbookPath);
    pres.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Đặt Workbook Ngoại**

Sử dụng phương thức **`setExternalWorkbook`**, bạn có thể gán một workbook ngoại cho biểu đồ làm nguồn dữ liệu. Phương thức này cũng có thể được dùng để cập nhật đường dẫn tới workbook ngoại (nếu workbook đã được di chuyển).

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các workbook lưu ở vị trí từ xa hoặc tài nguyên, bạn vẫn có thể sử dụng các workbook đó làm nguồn dữ liệu ngoại. Nếu cung cấp đường dẫn tương đối cho workbook ngoại, nó sẽ tự động được chuyển sang đường dẫn đầy đủ.

```javascript
// Tạo một thể hiện của lớp Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, false);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("externalWorkbook.xlsx");
    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), aspose.slides.ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    pres.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Tham số `ChartData` (trong phương thức `setExternalWorkbook`) được dùng để chỉ định có tải workbook Excel hay không.

* Khi giá trị `ChartData` được đặt thành `false`, chỉ đường dẫn workbook được cập nhật — dữ liệu biểu đồ sẽ không được tải hoặc cập nhật từ workbook mục tiêu. Bạn có thể dùng thiết lập này khi workbook mục tiêu không tồn tại hoặc không khả dụng.  
* Khi giá trị `ChartData` được đặt thành `true`, dữ liệu biểu đồ sẽ được cập nhật từ workbook mục tiêu.

```javascript
// Tạo một thể hiện của lớp Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("http://path/doesnt/exists", false);
    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Lấy Đường Dẫn Workbook Nguồn Dữ liệu Ngoại của Biểu đồ**

1. Tạo một thể hiện của lớp [Presentation](https://apireference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation) .
2. Lấy tham chiếu của slide thông qua chỉ mục của nó.
3. Tạo một đối tượng cho shape biểu đồ.
4. Tạo một đối tượng cho loại nguồn (`ChartDataSourceType`) đại diện cho nguồn dữ liệu của biểu đồ.
5. Chỉ định điều kiện liên quan dựa trên việc loại nguồn bằng với loại nguồn dữ liệu workbook ngoại.

```javascript
// Tạo một thể hiện của lớp Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var slide = pres.getSlides().get_Item(1);
    var chart = slide.getShapes().get_Item(0);
    var sourceType = chart.getChartData().getDataSourceType();
    if (sourceType == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
        var path = chart.getChartData().getExternalWorkbookPath();
    }
    // Lưu bản trình chiếu
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Chỉnh sửa Dữ liệu Biểu đồ**

Bạn có thể chỉnh sửa dữ liệu trong workbook ngoại giống như khi thay đổi nội dung của workbook nội. Khi workbook ngoại không thể tải được, một ngoại lệ sẽ được ném.

```javascript
// Tạo một thể hiện của lớp Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var chartData = chart.getChartData();
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    pres.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Câu hỏi thường gặp**

**Tôi có thể xác định liệu một biểu đồ cụ thể có được liên kết với workbook ngoại hay nhúng không?**

Có. Một biểu đồ có [data source type](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) và một [path to an external workbook](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); nếu nguồn là workbook ngoại, bạn có thể đọc đường dẫn đầy đủ để chắc chắn rằng một tệp ngoại đang được sử dụng.

**Các đường dẫn tương đối tới workbook ngoại có được hỗ trợ và chúng được lưu như thế nào?**

Có. Nếu bạn chỉ định đường dẫn tương đối, nó sẽ tự động được chuyển sang đường dẫn tuyệt đối. Điều này thuận tiện cho việc di động dự án; tuy nhiên, hãy lưu ý rằng bản trình chiếu sẽ lưu đường dẫn tuyệt đối trong tệp PPTX.

**Tôi có thể sử dụng workbook nằm trên tài nguyên/mạng chia sẻ không?**

Có, các workbook như vậy có thể được sử dụng làm nguồn dữ liệu ngoại. Tuy nhiên, việc chỉnh sửa trực tiếp workbook từ xa bằng Aspose.Slides không được hỗ trợ — chúng chỉ có thể dùng làm nguồn.

**Aspose.Slides có ghi đè lên file XLSX ngoại khi lưu bản trình chiếu không?**

Không. Bản trình chiếu lưu một [link to the external file](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) và dùng nó để đọc dữ liệu. File ngoại không bị thay đổi khi bản trình chiếu được lưu.

**Nếu file ngoại được bảo vệ bằng mật khẩu, tôi phải làm gì?**

Aspose.Slides không chấp nhận mật khẩu khi liên kết. Cách phổ biến là loại bỏ bảo vệ trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, sử dụng [Aspose.Cells](/cells/nodejs-java/)) và liên kết tới bản sao đó.

**Nhiều biểu đồ có thể tham chiếu cùng một workbook ngoại không?**

Có. Mỗi biểu đồ lưu link riêng của mình. Nếu tất cả đều trỏ tới cùng một tệp, việc cập nhật tệp đó sẽ được phản ánh trong mỗi biểu đồ khi dữ liệu được tải lại.