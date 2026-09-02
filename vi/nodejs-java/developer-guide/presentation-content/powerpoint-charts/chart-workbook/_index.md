---
title: Quản lý Sách Tính Biểu Đồ trong Bản Trình Chiếu bằng JavaScript
linktitle: Sách Tính Biểu Đồ
type: docs
weight: 70
url: /vi/nodejs-java/chart-workbook/
keywords:
- sách tính biểu đồ
- dữ liệu biểu đồ
- ô sách tính
- nhãn dữ liệu
- bảng tính
- nguồn dữ liệu
- sách tính bên ngoài
- dữ liệu bên ngoài
- bộ nhớ đệm biểu đồ
- khôi phục sách tính
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Khám phá Aspose.Slides cho Node.js thông qua Java: dễ dàng quản lý sách tính biểu đồ trong các định dạng PowerPoint và OpenDocument để tối ưu hóa dữ liệu bản trình chiếu của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với sách tính biểu đồ trong Aspose.Slides. Nó cho thấy cách đọc và ghi dữ liệu biểu đồ thông qua luồng sách tính, sử dụng các ô trong sách tính làm nhãn dữ liệu biểu đồ, truy cập bộ sưu tập bảng tính, và chỉ định loại nguồn dữ liệu cho các giá trị biểu đồ.

Nó cũng đề cập đến việc làm việc với sách tính bên ngoài làm nguồn dữ liệu biểu đồ. Các ví dụ minh họa cách tạo và gán một sách tính bên ngoài, lấy đường dẫn của sách tính bên ngoài được liên kết với biểu đồ, và chỉnh sửa dữ liệu biểu đồ khi sách tính khả dụng.

## **Đọc và Ghi Dữ Liệu Biểu Đồ Từ Sách Tính**

Aspose.Slides cung cấp các phương thức [readWorkbookStream](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) và [writeWorkbookStream](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) cho phép bạn đọc và ghi sách tính dữ liệu biểu đồ (chứa dữ liệu biểu đồ đã được chỉnh sửa bằng Aspose.Cells). **Lưu ý** rằng dữ liệu biểu đồ phải được tổ chức theo cùng cách hoặc có cấu trúc tương tự như nguồn.

Đoạn mã JavaScript sau minh họa một thao tác mẫu:

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

## **Đặt Ô Sách Tính Là Nhãn Dữ Liệu Biểu Đồ**

1. Tạo một thể hiện của lớp [Presentation](https://apireference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation) .
1. Lấy tham chiếu của một slide thông qua chỉ mục của nó.
1. Thêm một biểu đồ Bubble với một số dữ liệu.
1. Truy cập series của biểu đồ.
1. Đặt ô sách tính làm nhãn dữ liệu.
1. Lưu bản trình diễn.

Đoạn mã JavaScript dưới đây cho thấy cách đặt một ô sách tính làm nhãn dữ liệu biểu đồ:

```javascript
var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// Khởi tạo lớp trình chiếu đại diện cho tệp trình chiếu
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

## **Quản Lý Bảng Tính**

Đoạn mã JavaScript này minh họa một thao tác trong đó phương thức [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) được sử dụng để truy cập bộ sưu tập bảng tính:

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

## **Chỉ Định Loại Nguồn Dữ Liệu**

Đoạn mã JavaScript này cho thấy cách chỉ định loại cho một nguồn dữ liệu:

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

## **Phát Hiện Định Dạng Sách Tính Nhúng Không Hỗ Trợ**

Aspose.Slides không hỗ trợ định dạng sách tính nhị phân Excel (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể sử dụng phương thức `getEmbeddedWorkbookType` trên [ChartData](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdata/) cùng với enumeration [WorkbookType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/workbooktype/) để phát hiện các định dạng không hỗ trợ và bỏ qua các biểu đồ đó.

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
            // Sổ làm việc nhúng ở định dạng .xlsb, không được hỗ trợ.
            continue;
        }

        // Đọc hoặc sửa đổi dữ liệu sổ làm việc biểu đồ ở đây.
    }
} finally {
    presentation.dispose();
}
```

## **Sách Tính Bên Ngoài**

Aspose.Slides hỗ trợ sách tính bên ngoài làm nguồn dữ liệu cho biểu đồ.

### **Tạo Sách Tính Bên Ngoài**

Sử dụng các phương thức **`readWorkbookStream`** và **`setExternalWorkbook`**, bạn có thể tạo một sách tính bên ngoài từ đầu hoặc chuyển một sách tính nội bộ thành sách tính bên ngoài.

Đoạn mã JavaScript này minh họa quá trình tạo sách tính bên ngoài:

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

### **Đặt Sách Tính Bên Ngoài**

Sử dụng phương thức **`setExternalWorkbook`**, bạn có thể gán một sách tính bên ngoài cho biểu đồ làm nguồn dữ liệu. Phương thức này cũng có thể được dùng để cập nhật đường dẫn tới sách tính bên ngoài (nếu sách đã được di chuyển).

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các sách tính được lưu trữ ở vị trí từ xa hoặc tài nguyên, bạn vẫn có thể sử dụng các sách tính đó làm nguồn dữ liệu bên ngoài. Nếu cung cấp đường dẫn tương đối cho một sách tính bên ngoài, nó sẽ tự động được chuyển sang đường dẫn tuyệt đối.

Đoạn mã JavaScript này cho thấy cách đặt một sách tính bên ngoài:

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

Tham số `ChartData` (được truyền vào phương thức `setExternalWorkbook`) được dùng để chỉ định liệu một sách tính Excel có được tải hay không.

* Khi giá trị `ChartData` được đặt là `false`, chỉ đường dẫn sách tính được cập nhật — dữ liệu biểu đồ sẽ không được tải hoặc cập nhật từ sách tính mục tiêu. Bạn có thể muốn sử dụng thiết lập này khi sách tính mục tiêu không tồn tại hoặc không khả dụng.
* Khi giá trị `ChartData` được đặt là `true`, dữ liệu biểu đồ sẽ được cập nhật từ sách tính mục tiêu.

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

### **Lấy Đường Dẫn Sách Tính Nguồn Dữ Liệu Bên Ngoài Của Biểu Đồ**

1. Tạo một thể hiện của lớp [Presentation](https://apireference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation) .
1. Lấy tham chiếu của một slide thông qua chỉ mục của nó.
1. Tạo một đối tượng cho hình dạng biểu đồ.
1. Tạo một đối tượng cho loại nguồn (`ChartDataSourceType`) đại diện cho nguồn dữ liệu của biểu đồ.
1. Chỉ định điều kiện liên quan dựa trên việc loại nguồn giống với loại nguồn dữ liệu sách tính bên ngoài.

Đoạn mã JavaScript này minh họa thao tác:

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

### **Chỉnh Sửa Dữ Liệu Biểu Đồ**

Bạn có thể chỉnh sửa dữ liệu trong sách tính bên ngoài tương tự như khi thay đổi nội dung của sách tính nội bộ. Khi không thể tải một sách tính bên ngoài, một ngoại lệ sẽ được ném ra.

Đoạn mã JavaScript này là triển khai của quá trình đã mô tả:

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

### **Khôi Phục Sách Tính Từ Bộ Nhớ Đệm Biểu Đồ**

Nếu một biểu đồ sử dụng sách tính bên ngoài mà bị thiếu hoặc không khả dụng, Aspose.Slides có thể tái tạo sách tính biểu đồ từ dữ liệu đã được lưu trong bộ nhớ đệm của bản trình diễn. Tạo [LoadOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/), cấu hình nó với [SpreadsheetOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/spreadsheetoptions/), và gọi [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) với giá trị `true` trước khi mở bản trình diễn.

Ví dụ JavaScript sau mở một bản trình diễn mà biểu đồ tham chiếu tới một sách tính bên ngoài không khả dụng và truy cập dữ liệu đã khôi phục thông qua [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook):

```javascript
const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Đọc hoặc sửa đổi dữ liệu sổ làm việc đã khôi phục ở đây.
} finally {
    presentation.dispose();
}
```

Nếu sách tính bên ngoài không khả dụng và tính năng khôi phục bị tắt, Aspose.Slides sẽ ném một ngoại lệ. Chỉ bật khôi phục khi việc sử dụng dữ liệu biểu đồ đã được lưu trong bộ nhớ đệm là một phương án dự phòng chấp nhận được, vì bộ nhớ đệm có thể không chứa các thay đổi đã được thực hiện trên sách tính bên ngoài sau lần cập nhật cuối cùng của bản trình diễn.

## **Câu Hỏi Thường Gặp**

**Tôi có thể xác định được một biểu đồ cụ thể có liên kết tới sách tính bên ngoài hay nhúng không?**

Có. Một biểu đồ có [loại nguồn dữ liệu](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) và một [đường dẫn tới sách tính bên ngoài](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); nếu nguồn là một sách tính bên ngoài, bạn có thể đọc đường dẫn đầy đủ để chắc chắn rằng một tệp bên ngoài đang được sử dụng.

**Các đường dẫn tương đối tới sách tính bên ngoài có được hỗ trợ không, và chúng được lưu như thế nào?**

Có. Nếu bạn chỉ định một đường dẫn tương đối, nó sẽ tự động được chuyển sang đường dẫn tuyệt đối. Điều này thuận tiện cho việc di chuyển dự án; tuy nhiên, hãy lưu ý rằng bản trình diễn sẽ lưu đường dẫn tuyệt đối trong tệp PPTX.

**Tôi có thể dùng sách tính nằm trên tài nguyên mạng/chia sẻ không?**

Có, các sách tính như vậy có thể được dùng làm nguồn dữ liệu bên ngoài. Tuy nhiên, việc chỉnh sửa trực tiếp các sách tính từ xa bằng Aspose.Slides không được hỗ trợ — chúng chỉ có thể được sử dụng làm nguồn.

**Aspose.Slides có ghi đè lên tệp XLSX bên ngoài khi lưu bản trình diễn không?**

Không. Bản trình diễn lưu một [liên kết tới tệp bên ngoài](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) và dùng liên kết này để đọc dữ liệu. Tệp bên ngoài sẽ không bị thay đổi khi bản trình diễn được lưu.

**Nếu tệp bên ngoài được bảo vệ bằng mật khẩu, tôi nên làm gì?**

Aspose.Slides không chấp nhận mật khẩu khi liên kết. Một cách thường dùng là tháo bảo vệ trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, sử dụng [Aspose.Cells](/cells/nodejs-java/)) và liên kết tới bản sao đó.

**Nhiều biểu đồ có thể tham chiếu tới cùng một sách tính bên ngoài không?**

Có. Mỗi biểu đồ lưu liên kết riêng của mình. Nếu chúng đều trỏ tới cùng một tệp, việc cập nhật tệp sẽ được phản ánh trong mỗi biểu đồ khi dữ liệu được tải lại.