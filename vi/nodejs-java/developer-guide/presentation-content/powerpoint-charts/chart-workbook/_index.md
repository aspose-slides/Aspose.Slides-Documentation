---
title: Quản lý Sổ làm việc Biểu đồ trong Bản trình chiếu bằng JavaScript
linktitle: Sổ làm việc Biểu đồ
type: docs
weight: 70
url: /vi/nodejs-java/chart-workbook/
keywords:
- sổ làm việc biểu đồ
- dữ liệu biểu đồ
- ô sổ làm việc
- nhãn dữ liệu
- bảng tính
- nguồn dữ liệu
- sổ làm việc bên ngoài
- dữ liệu bên ngoài
- bộ nhớ đệm biểu đồ
- khôi phục sổ làm việc
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Khám phá Aspose.Slides cho Node.js qua Java: dễ dàng quản lý sổ làm việc biểu đồ trong các định dạng PowerPoint và OpenDocument để đơn giản hoá dữ liệu bản trình chiếu của bạn."
---
## **Overview**

Bài viết này giải thích cách làm việc với sổ làm việc biểu đồ trong Aspose.Slides. Nó cho thấy cách đọc và ghi dữ liệu biểu đồ thông qua các luồng sổ làm việc, sử dụng các ô sổ làm việc làm nhãn dữ liệu biểu đồ, truy cập các bộ sưu tập worksheet và chỉ định loại nguồn dữ liệu cho các giá trị biểu đồ.

Nó cũng đề cập đến việc làm việc với sổ làm việc bên ngoài làm nguồn dữ liệu cho biểu đồ. Các ví dụ minh họa cách tạo và chỉ định một sổ làm việc bên ngoài, lấy đường dẫn của sổ làm việc bên ngoài được liên kết với biểu đồ, và chỉnh sửa dữ liệu biểu đồ khi sổ làm việc có sẵn.

Đối với các ô sổ làm việc đại diện cho dữ liệu thiếu, tham khảo [Control the Display of Empty Cells](/slides/vi/nodejs-java/chart-series/) để biết sự khác nhau giữa ô trống và số zero, và so sánh biểu đồ đường của các chế độ hiển thị có sẵn.

## **Read and Write Chart Data from a Workbook**

Aspose.Slides cung cấp các phương thức [readWorkbookStream](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) và [writeWorkbookStream](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) cho phép bạn đọc và ghi sổ làm việc dữ liệu biểu đồ (chứa dữ liệu biểu đồ đã được chỉnh sửa bằng Aspose.Cells). **Note** rằng dữ liệu biểu đồ phải được tổ chức theo cùng cách hoặc phải có cấu trúc tương tự nguồn.

This JavaScript code demonstrates a sample operation:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **Validate Chart Layout After Workbook Modification**

Khi bạn thay thế sổ làm việc nhúng bằng một sổ làm việc đã được sửa đổi, biểu đồ vẫn giữ lại các bộ sưu tập series và category gốc. Sự không khớp này có thể khiến [Chart.validateChartLayout](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Chart#validateChartLayout--) thất bại với lỗi index-out-of-range. Hãy xóa các series và category hiện có trước khi ghi sổ làm việc đã cập nhật trở lại biểu đồ.

```javascript
// Sau khi chỉnh sửa luồng sổ làm việc (ví dụ, sử dụng Aspose.Cells)
var updatedWorkbook = chartData.readWorkbookStream();

// Xóa các tham chiếu dữ liệu hiện có.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

Việc xóa các bộ sưu tập đảm bảo cấu trúc dữ liệu biểu đồ nhất quán với sổ làm việc mới, cho phép `validateChartLayout` hoàn thành mà không có lỗi.

## **Set WorkBook Cell as Chart DataLabel**

1. Tạo một thể hiện của lớp [Presentation](https://apireference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation).
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó.
3. Thêm một biểu đồ Bubble với một số dữ liệu.
4. Truy cập series của biểu đồ.
5. Đặt ô sổ làm việc làm nhãn dữ liệu.
6. Lưu bản trình bày.

Đoạn mã JavaScript này cho bạn cách đặt ô sổ làm việc làm nhãn dữ liệu biểu đồ:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu
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

## **Manage Worksheets**

Đoạn mã JavaScript này minh họa một thao tác trong đó phương thức [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) được sử dụng để truy cập một bộ sưu tập worksheet:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **Specify Data Source Type**

Đoạn mã JavaScript này cho bạn cách chỉ định một kiểu cho nguồn dữ liệu:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **Detect Unsupported Embedded Workbook Formats**

Aspose.Slides không hỗ trợ định dạng sổ làm việc Excel nhị phân (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể sử dụng phương thức `getEmbeddedWorkbookType` trên [ChartData](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdata/) cùng với enumeration [WorkbookType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/workbooktype/) để phát hiện các định dạng không được hỗ trợ và bỏ qua những biểu đồ đó.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

        // Đọc hoặc chỉnh sửa dữ liệu sổ làm việc biểu đồ tại đây.
    }
} finally {
    presentation.dispose();
}
```

## **External Workbook**

Aspose.Slides hỗ trợ sổ làm việc bên ngoài làm nguồn dữ liệu cho biểu đồ.

### **Create External Workbook**

Bằng cách sử dụng các phương thức **`readWorkbookStream`** và **`setExternalWorkbook`**, bạn có thể tạo một sổ làm việc bên ngoài từ đầu hoặc chuyển một sổ làm việc nội bộ thành bên ngoài.

Đoạn mã JavaScript này minh họa quy trình tạo sổ làm việc bên ngoài:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fileSystem = require("fs");

var pres = new aspose.slides.Presentation();
try {
    var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    // readWorkbookStream trả về dữ liệu workbook dưới dạng Node Buffer.
    var workbookData = chart.getChartData().readWorkbookStream();
    fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
    chart.getChartData().setExternalWorkbook(workbookPath);
    pres.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Set External Workbook**

Bằng cách sử dụng phương thức **`setExternalWorkbook`**, bạn có thể chỉ định một sổ làm việc bên ngoài cho biểu đồ như là nguồn dữ liệu của nó. Phương thức này cũng có thể được dùng để cập nhật đường dẫn tới sổ làm việc bên ngoài (nếu sổ làm việc đó đã được di chuyển).

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các sổ làm việc được lưu trữ ở vị trí hoặc tài nguyên từ xa, bạn vẫn có thể sử dụng các sổ làm việc đó làm nguồn dữ liệu bên ngoài. Nếu cung cấp đường dẫn tương đối cho sổ làm việc bên ngoài, nó sẽ tự động được chuyển thành đường dẫn đầy đủ.

Đoạn mã JavaScript này cho bạn cách thiết lập một sổ làm việc bên ngoài:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Tham số thứ hai của phương thức `setExternalWorkbook`, `updateChartData`, chỉ định liệu sổ làm việc Excel có được tải hay không.

* Khi `updateChartData` được đặt thành `false`, chỉ đường dẫn sổ làm việc được cập nhật — dữ liệu biểu đồ sẽ không được tải hoặc cập nhật từ sổ làm việc mục tiêu. Bạn có thể muốn sử dụng thiết lập này khi sổ làm việc mục tiêu không tồn tại hoặc không khả dụng.
* Khi `updateChartData` được đặt thành `true`, dữ liệu biểu đồ sẽ được cập nhật từ sổ làm việc mục tiêu.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **Get Chart External Data Source Workbook Path**

1. Tạo một thể hiện của lớp [Presentation](https://apireference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation).
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó.
3. Tạo một đối tượng cho hình dạng biểu đồ.
4. Tạo một đối tượng cho kiểu nguồn (`ChartDataSourceType`) đại diện cho nguồn dữ liệu của biểu đồ.
5. Xác định điều kiện phù hợp dựa trên việc kiểu nguồn giống với kiểu nguồn dữ liệu sổ làm việc bên ngoài.

Đoạn mã JavaScript này minh họa thao tác:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **Edit Chart Data**

Bạn có thể chỉnh sửa dữ liệu trong sổ làm việc bên ngoài theo cách bạn thay đổi nội dung của sổ làm việc nội bộ. Khi sổ làm việc bên ngoài không thể tải, một ngoại lệ sẽ được ném.

Đoạn mã JavaScript này là một triển khai của quá trình đã mô tả:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **Recover a Workbook from the Chart Cache**

Nếu một biểu đồ sử dụng sổ làm việc bên ngoài bị thiếu hoặc không khả dụng, Aspose.Slides có thể tái tạo sổ làm việc biểu đồ từ dữ liệu đã được lưu trong bộ nhớ đệm của bản trình bày. Tạo [LoadOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/), cấu hình nó với [SpreadsheetOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/spreadsheetoptions/), và gọi [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) với `true` trước khi mở bản trình bày.

Ví dụ JavaScript sau mở một bản trình bày mà biểu đồ của nó tham chiếu tới một sổ làm việc bên ngoài không khả dụng và truy cập dữ liệu đã được khôi phục thông qua [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Đọc hoặc chỉnh sửa dữ liệu sổ làm việc đã khôi phục tại đây.
} finally {
    presentation.dispose();
}
```

Nếu sổ làm việc bên ngoài không khả dụng và chế độ khôi phục bị tắt, Aspose.Slides sẽ ném ngoại lệ. Chỉ bật khôi phục khi việc sử dụng dữ liệu biểu đồ đã lưu trong bộ nhớ đệm là một phương án dự phòng chấp nhận được, vì bộ nhớ đệm có thể không chứa các thay đổi đã được thực hiện trên sổ làm việc bên ngoài sau lần cuối cùng bản trình bày được cập nhật.

## **FAQ**

**Tôi có thể xác định liệu một biểu đồ cụ thể có liên kết tới sổ làm việc bên ngoài hay sổ làm việc nhúng không?**

Có. Một biểu đồ có một [loại nguồn dữ liệu](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) và một [đường dẫn tới sổ làm việc bên ngoài](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); nếu nguồn là sổ làm việc bên ngoài, bạn có thể đọc đường dẫn đầy đủ để chắc chắn rằng đang sử dụng một tệp bên ngoài.

**Có hỗ trợ các đường dẫn tương đối tới sổ làm việc bên ngoài không, và chúng được lưu như thế nào?**

Có. Nếu bạn chỉ định một đường dẫn tương đối, nó sẽ tự động được chuyển thành đường dẫn tuyệt đối. Điều này thuận tiện cho tính di động của dự án; tuy nhiên, hãy lưu ý rằng bản trình bày sẽ lưu đường dẫn tuyệt đối trong tệp PPTX.

**Tôi có thể sử dụng sổ làm việc nằm trên tài nguyên/mạng chia sẻ không?**

Có, các sổ làm việc như vậy có thể được dùng làm nguồn dữ liệu bên ngoài. Tuy nhiên, việc chỉnh sửa các sổ làm việc từ xa trực tiếp từ Aspose.Slides không được hỗ trợ — chúng chỉ có thể được sử dụng làm nguồn.

**Aspose.Slides có ghi đè lên tệp XLSX bên ngoài khi lưu bản trình bày không?**

Không. Bản trình bày lưu một [liên kết tới tệp bên ngoài](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) và sử dụng nó để đọc dữ liệu. Tệp bên ngoài không bị thay đổi khi bản trình bày được lưu.

**Tôi nên làm gì nếu tệp bên ngoài được bảo vệ bằng mật khẩu?**

Aspose.Slides không chấp nhận mật khẩu khi liên kết. Một cách thường gặp là gỡ bảo vệ trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, sử dụng [Aspose.Cells](/cells/nodejs-java/)) và liên kết tới bản sao đó.

**Nhiều biểu đồ có thể tham chiếu cùng một sổ làm việc bên ngoài không?**

Có. Mỗi biểu đồ lưu trữ liên kết riêng của mình. Nếu tất cả đều trỏ tới cùng một tệp, việc cập nhật tệp đó sẽ được phản ánh trong mỗi biểu đồ vào lần tiếp theo dữ liệu được tải.