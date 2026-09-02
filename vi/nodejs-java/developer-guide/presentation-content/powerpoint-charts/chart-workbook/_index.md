---
title: Quản lý Sách làm việc Biểu đồ trong Bản trình bày bằng JavaScript
linktitle: Sách làm việc Biểu đồ
type: docs
weight: 70
url: /vi/nodejs-java/chart-workbook/
keywords:
- sách làm việc biểu đồ
- dữ liệu biểu đồ
- ô workbook
- nhãn dữ liệu
- bảng tính
- nguồn dữ liệu
- sách làm việc bên ngoài
- dữ liệu bên ngoài
- bộ nhớ đệm biểu đồ
- khôi phục workbook
- PowerPoint
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Khám phá Aspose.Slides cho Node.js qua Java: dễ dàng quản lý sách làm việc biểu đồ trong các định dạng PowerPoint và OpenDocument để tối ưu hoá dữ liệu bản trình bày của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với sách làm việc biểu đồ trong Aspose.Slides. Nó cho thấy cách đọc và ghi dữ liệu biểu đồ thông qua các luồng sách làm việc, sử dụng ô workbook làm nhãn dữ liệu biểu đồ, truy cập bộ sưu tập worksheet, và chỉ định kiểu nguồn dữ liệu cho các giá trị biểu đồ.

Nó cũng đề cập đến việc làm việc với sách làm việc bên ngoài như nguồn dữ liệu cho biểu đồ. Các ví dụ trình bày cách tạo và gán một sách làm việc bên ngoài, lấy đường dẫn của sách làm việc bên ngoài được liên kết với biểu đồ, và chỉnh sửa dữ liệu biểu đồ khi sách làm việc có sẵn.

## **Đọc và ghi dữ liệu biểu đồ từ sách làm việc**

Aspose.Slides cung cấp các phương thức [readWorkbookStream](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) và [writeWorkbookStream](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) cho phép bạn đọc và ghi sách làm việc dữ liệu biểu đồ (chứa dữ liệu biểu đồ đã chỉnh sửa bằng Aspose.Cells). **Lưu ý** rằng dữ liệu biểu đồ phải được tổ chức theo cùng cách hoặc có cấu trúc tương tự nguồn.

Đoạn mã JavaScript này minh họa một thao tác mẫu:

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

### **Xác thực bố cục biểu đồ sau khi sửa đổi sách làm việc**

Khi bạn thay thế một workbook nhúng bằng một workbook đã chỉnh sửa, biểu đồ vẫn giữ lại các bộ sưu tập series và category gốc. Sự không khớp này có thể gây lỗi cho [Chart.validateChartLayout](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Chart#validateChartLayout--) với lỗi index-out-of-range. Hãy xóa các series và category hiện có trước khi ghi lại workbook đã cập nhật vào biểu đồ.

```javascript
// Sau khi chỉnh sửa luồng workbook (ví dụ, sử dụng Aspose.Cells)
var updatedWorkbook = chartData.readWorkbookStream();

// Xóa các tham chiếu dữ liệu hiện có.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

Việc xóa các bộ sưu tập đảm bảo cấu trúc dữ liệu biểu đồ nhất quán với workbook mới, cho phép `validateChartLayout` hoàn thành mà không có lỗi.

## **Đặt ô WorkBook làm Chart DataLabel**

1. Tạo một thể hiện của lớp [Presentation](https://apireference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation).
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó.
3. Thêm biểu đồ Bubble với một số dữ liệu.
4. Truy cập series của biểu đồ.
5. Đặt ô workbook làm nhãn dữ liệu.
6. Lưu bản trình bày.

Đoạn mã JavaScript này cho bạn thấy cách đặt ô workbook làm nhãn dữ liệu biểu đồ:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// Tạo một lớp trình chiếu đại diện cho tệp trình chiếu
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

Đoạn mã JavaScript này minh họa một thao tác trong đó phương thức [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) được sử dụng để truy cập bộ sưu tập worksheet:

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

## **Chỉ định kiểu nguồn dữ liệu**

Đoạn mã JavaScript này cho bạn thấy cách chỉ định một kiểu cho nguồn dữ liệu:

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

## **Phát hiện định dạng sách làm việc nhúng không được hỗ trợ**

Aspose.Slides không hỗ trợ định dạng workbook nhị phân Excel (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể sử dụng phương thức `getEmbeddedWorkbookType` trên [ChartData](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdata/) cùng với enumeration [WorkbookType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/workbooktype/) để phát hiện các định dạng không được hỗ trợ và bỏ qua các biểu đồ đó.

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
            // Workbook nhúng ở định dạng .xlsb, không được hỗ trợ.
            continue;
        }

        // Đọc hoặc chỉnh sửa dữ liệu workbook của biểu đồ tại đây.
    }
} finally {
    presentation.dispose();
}
```

## **Sách làm việc bên ngoài**

Aspose.Slides hỗ trợ sách làm việc bên ngoài làm nguồn dữ liệu cho biểu đồ.

### **Tạo sách làm việc bên ngoài**

Sử dụng các phương thức **`readWorkbookStream`** và **`setExternalWorkbook`**, bạn có thể tạo một sách làm việc bên ngoài từ đầu hoặc làm cho một workbook nội bộ trở thành bên ngoài.

Đoạn mã JavaScript này minh họa quy trình tạo sách làm việc bên ngoài:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fileSystem = require("fs");

var pres = new aspose.slides.Presentation();
try {
    var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    // readWorkbookStream trả về các byte của workbook dưới dạng Node Buffer.
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

### **Đặt sách làm việc bên ngoài**

Sử dụng phương thức **`setExternalWorkbook`**, bạn có thể gán một sách làm việc bên ngoài cho biểu đồ như là nguồn dữ liệu của nó. Phương thức này cũng có thể được dùng để cập nhật đường dẫn tới sách làm việc bên ngoài (nếu sách đó đã được di chuyển).

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các workbook được lưu trữ ở vị trí từ xa hoặc tài nguyên, bạn vẫn có thể sử dụng các workbook này làm nguồn dữ liệu bên ngoài. Nếu cung cấp đường dẫn tương đối cho một sách làm việc bên ngoài, nó sẽ tự động được chuyển thành đường dẫn đầy đủ.

Đoạn mã JavaScript này cho bạn thấy cách đặt một sách làm việc bên ngoài:

```javascript
// Tạo một thể hiện của lớp Presentation
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Creates an instance of the Presentation class
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

Tham số thứ hai của phương thức `setExternalWorkbook`, `updateChartData`, chỉ định việc workbook Excel có được tải hay không.

* Khi `updateChartData` được đặt là `false`, chỉ đường dẫn sách làm việc được cập nhật — dữ liệu biểu đồ sẽ không được tải hoặc cập nhật từ sách làm việc đích. Bạn có thể muốn sử dụng cài đặt này khi sách làm việc đích không tồn tại hoặc không khả dụng.
* Khi `updateChartData` được đặt là `true`, dữ liệu biểu đồ sẽ được cập nhật từ sách làm việc đích.

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

### **Lấy đường dẫn sách làm việc nguồn dữ liệu bên ngoài của biểu đồ**

1. Tạo một thể hiện của lớp [Presentation](https://apireference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation).
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó.
3. Tạo một đối tượng cho hình dạng biểu đồ.
4. Tạo một đối tượng cho loại nguồn (`ChartDataSourceType`) đại diện cho nguồn dữ liệu của biểu đồ.
5. Chỉ định điều kiện liên quan dựa trên việc loại nguồn giống với loại nguồn dữ liệu sách làm việc bên ngoài.

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
    // Lưu bản trình bày
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Chỉnh sửa dữ liệu biểu đồ**

Bạn có thể chỉnh sửa dữ liệu trong các workbook bên ngoài tương tự như việc thay đổi nội dung của các workbook nội bộ. Khi một workbook bên ngoài không thể được tải, một ngoại lệ sẽ được ném ra.

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

### **Khôi phục sách làm việc từ bộ nhớ đệm biểu đồ**

Nếu một biểu đồ sử dụng một workbook bên ngoài bị thiếu hoặc không khả dụng, Aspose.Slides có thể tái tạo workbook của biểu đồ từ dữ liệu đã được lưu trong bộ nhớ đệm của bản trình bày. Tạo [LoadOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/), cấu hình nó với [SpreadsheetOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/spreadsheetoptions/), và gọi [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) với `true` trước khi mở bản trình bày.

Ví dụ JavaScript sau mở một bản trình bày mà biểu đồ của nó tham chiếu tới một workbook bên ngoài không khả dụng và truy cập dữ liệu đã khôi phục thông qua [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook):

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

    // Đọc hoặc chỉnh sửa dữ liệu workbook đã khôi phục tại đây.
} finally {
    presentation.dispose();
}
```

Nếu workbook bên ngoài không khả dụng và việc khôi phục bị tắt, Aspose.Slides sẽ ném ra một ngoại lệ. Hãy bật khôi phục chỉ khi việc sử dụng dữ liệu biểu đồ đã được lưu trong bộ nhớ đệm là một phương án dự phòng chấp nhận được, vì bộ nhớ đệm có thể không chứa các thay đổi được thực hiện trên workbook bên ngoài sau khi bản trình bày được cập nhật lần cuối.

## **Câu hỏi thường gặp**

**Tôi có thể xác định liệu một biểu đồ cụ thể có liên kết đến sách làm việc bên ngoài hay nhúng không?**

Có. Một biểu đồ có một [data source type](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) và một [path to an external workbook](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); nếu nguồn là một workbook bên ngoài, bạn có thể đọc đường dẫn đầy đủ để chắc chắn rằng một tệp bên ngoài đang được sử dụng.

**Các đường dẫn tương đối tới workbook bên ngoài có được hỗ trợ không, và chúng được lưu như thế nào?**

Có. Nếu bạn chỉ định một đường dẫn tương đối, nó sẽ tự động được chuyển thành đường dẫn tuyệt đối. Điều này thuận tiện cho việc di động dự án; tuy nhiên, hãy lưu ý rằng bản trình bày sẽ lưu đường dẫn tuyệt đối trong tệp PPTX.

**Tôi có thể sử dụng các workbook nằm trên tài nguyên/mạng chia sẻ không?**

Có, các workbook như vậy có thể được sử dụng làm nguồn dữ liệu bên ngoài. Tuy nhiên, việc chỉnh sửa trực tiếp các workbook từ xa bằng Aspose.Slides không được hỗ trợ — chúng chỉ có thể được dùng làm nguồn.

**Aspose.Slides có ghi đè lên file XLSX bên ngoài khi lưu bản trình bày không?**

Không. Bản trình bày lưu một [link to the external file](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) và dùng nó để đọc dữ liệu. File bên ngoài không bị thay đổi khi bản trình bày được lưu.

**Nếu tệp bên ngoài được bảo vệ bằng mật khẩu, tôi nên làm gì?**

Aspose.Slides không chấp nhận mật khẩu khi liên kết. Một cách thường dùng là gỡ bảo vệ trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, sử dụng [Aspose.Cells](/cells/nodejs-java/)) và liên kết tới bản sao đó.

**Nhiều biểu đồ có thể tham chiếu cùng một workbook bên ngoài không?**

Có. Mỗi biểu đồ lưu trữ liên kết riêng của mình. Nếu tất cả chúng đều trỏ tới cùng một tệp, việc cập nhật tệp đó sẽ được phản ánh trong mỗi biểu đồ lần tiếp theo dữ liệu được tải.