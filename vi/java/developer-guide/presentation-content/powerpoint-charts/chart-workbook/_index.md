---
title: Quản lý Sổ làm việc Biểu đồ trong Bản trình chiếu bằng Java
linktitle: Sổ làm việc Biểu đồ
type: docs
weight: 70
url: /vi/java/chart-workbook/
keywords:
- sổ làm việc biểu đồ
- dữ liệu biểu đồ
- ô sổ làm việc
- nhãn dữ liệu
- bảng tính
- nguồn dữ liệu
- sổ làm việc bên ngoài
- dữ liệu bên ngoài
- bộ nhớ cache biểu đồ
- khôi phục sổ làm việc
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Khám phá Aspose.Slides cho Java: dễ dàng quản lý sổ làm việc biểu đồ trong các định dạng PowerPoint và OpenDocument để tinh giản dữ liệu bản trình chiếu của bạn."
---
## **Overview**

Bài viết này giải thích cách làm việc với sổ làm việc biểu đồ trong Aspose.Slides. Nó cho thấy cách đọc và ghi dữ liệu biểu đồ qua các luồng sổ làm việc, sử dụng các ô sổ làm việc làm nhãn dữ liệu biểu đồ, truy cập các bộ sưu tập worksheet, và chỉ định loại nguồn dữ liệu cho các giá trị biểu đồ.

Nó cũng đề cập đến việc làm việc với sổ làm việc bên ngoài như là nguồn dữ liệu cho biểu đồ. Các ví dụ minh họa cách tạo và gán một sổ làm việc bên ngoài, lấy đường dẫn của sổ làm việc bên ngoài được liên kết với biểu đồ, và chỉnh sửa dữ liệu biểu đồ khi sổ làm việc có sẵn.

## **Read and Write Chart Data from a Workbook**
Aspose.Slides cung cấp các phương thức [ReadWorkbookStream](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IChartData#readWorkbookStream--) và [WriteWorkbookStream](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) cho phép bạn đọc và ghi sổ làm việc dữ liệu biểu đồ (chứa dữ liệu biểu đồ đã chỉnh sửa bằng Aspose.Cells). **Note** rằng dữ liệu biểu đồ phải được tổ chức theo cùng cách hoặc có cấu trúc tương tự nguồn.

Đoạn mã Java sau minh họa một thao tác mẫu:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("chart.pptx");
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartData data = chart.getChartData();

    byte[] stream = data.readWorkbookStream();

    data.getSeries().clear();
    data.getCategories().clear();

    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Validate Chart Layout After Workbook Modification**

Khi bạn thay thế sổ làm việc nhúng bằng một sổ đã chỉnh sửa, biểu đồ vẫn giữ lại các bộ sưu tập series và category ban đầu. Sự không nhất quán này có thể gây `chart.validateChartLayout()` ném ra một `ArgumentOutOfRangeException` (parameter: index). Để tránh ngoại lệ, hãy xóa các series và category hiện có **before** ghi sổ làm việc đã cập nhật trở lại biểu đồ.

```java
// Sau khi chỉnh sửa luồng sổ làm việc (ví dụ, sử dụng Aspose.Cells)
byte[] updatedWorkbook = baos.toByteArray();

// Xóa các tham chiếu dữ liệu hiện có.
chart.getChartData().getSeries().clear();
chart.getChartData().getCategories().clear();

// Ghi sổ làm việc đã cập nhật trở lại biểu đồ.
chart.getChartData().writeWorkbookStream(updatedWorkbook);

// Bây giờ việc xác thực thành công.
chart.validateChartLayout();
```

Xóa các bộ sưu tập đảm bảo cấu trúc dữ liệu biểu đồ khớp với sổ làm việc mới, cho phép `validateChartLayout()` hoàn thành mà không có lỗi.

## **Set a Workbook Cell as a Chart Data Label**

1. Tạo một thể hiện của lớp [Presentation](https://apireference.aspose.com/slides/vi/java/com.aspose.slides/presentation) .
1. Lấy tham chiếu đến slide thông qua chỉ mục của nó.
1. Thêm một biểu đồ Bubble với một số dữ liệu.
1. Truy cập series của biểu đồ.
1. Đặt ô sổ làm việc làm nhãn dữ liệu.
1. Lưu bản thuyết trình.

Đoạn mã Java sau cho bạn cách đặt ô sổ làm việc làm nhãn dữ liệu biểu đồ:

```java
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Tạo một đối tượng lớp Presentation đại diện cho tệp bản trình chiếu
Presentation pres = new Presentation("chart2.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    IDataLabelCollection dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));

    pres.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Manage Worksheets**

Đoạn mã Java này minh họa một thao tác trong đó phương thức [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) được sử dụng để truy cập bộ sưu tập worksheet:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook wb =  chart.getChartData().getChartDataWorkbook();
    for (int i = 0; i < wb.getWorksheets().size(); i++)
        System.out.println(wb.getWorksheets().get_Item(i).getName());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Specify the Data Source Type**

Đoạn mã Java này cho bạn thấy cách chỉ định một loại cho nguồn dữ liệu:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.getChartData().getSeries().get_Item(0).getName();

    val.setDataSourceType(DataSourceType.StringLiterals);
    val.setData("LiteralString");

    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Detect Unsupported Embedded Workbook Formats**

Aspose.Slides không hỗ trợ định dạng sổ làm việc Excel nhị phân (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể sử dụng phương thức `getEmbeddedWorkbookType` trên [IChartData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IChartData) kết hợp với enumeration [WorkbookType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/WorkbookType) để phát hiện các định dạng không được hỗ trợ và bỏ qua những biểu đồ đó.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) continue;

        IChart chart = (IChart)shape;
        IChartData chartData = chart.getChartData();

        if (chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro) {
            // Sổ làm việc nhúng ở định dạng .xlsb, không được hỗ trợ.
            continue;
        }

        // Đọc hoặc sửa dữ liệu sổ làm việc biểu đồ ở đây.
    }
} finally {
    presentation.dispose();
}
```

## **External Workbook**

{{% alert color="info" %}} 
Trong [Aspose.Slides 19.4](https://docs.aspose.com/slides/vi/java/aspose-slides-for-java-19-4-release-notes/), chúng tôi đã triển khai hỗ trợ sổ làm việc bên ngoài làm nguồn dữ liệu cho biểu đồ.
{{% /alert %}} 

### **Create an External Workbook**

Sử dụng các phương thức **`readWorkbookStream`** và **`setExternalWorkbook`**, bạn có thể tạo một sổ làm việc bên ngoài từ đầu hoặc biến một sổ làm việc nội bộ thành bên ngoài.

Đoạn mã Java sau minh họa quá trình tạo sổ làm việc bên ngoài:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation pres = new Presentation();
try {
    final String workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    FileOutputStream fileStream = new FileOutputStream(workbookPath);
    try {
        byte[] workbookData = chart.getChartData().readWorkbookStream();
        fileStream.write(workbookData, 0, workbookData.length);
    } finally {
        if (fileStream != null) fileStream.close();
    }

    chart.getChartData().setExternalWorkbook(workbookPath);

    pres.save("externalWorkbook.pptx", SaveFormat.Pptx);
} catch (IOException e) {    
} finally {
    if (pres != null) pres.dispose();
}
```

### **Set an External Workbook**

Sử dụng phương thức **`setExternalWorkbook`**, bạn có thể gán một sổ làm việc bên ngoài cho biểu đồ như nguồn dữ liệu của nó. Phương thức này cũng có thể được dùng để cập nhật đường dẫn tới sổ làm việc bên ngoài (nếu sổ đó đã được di chuyển).

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các sổ làm việc được lưu ở vị trí từ xa hoặc tài nguyên, bạn vẫn có thể sử dụng các sổ như một nguồn dữ liệu bên ngoài. Nếu đường dẫn tương đối cho sổ làm việc bên ngoài được cung cấp, nó sẽ tự động được chuyển thành đường dẫn đầy đủ.

Đoạn mã Java này cho bạn cách đặt một sổ làm việc bên ngoài:

```java
import com.aspose.slides.*;

// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.getChartData();

    chartData.setExternalWorkbook("externalWorkbook.xlsx");

    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));

    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    
    pres.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Tham số thứ hai (`boolean`) của phương thức `setExternalWorkbook` được dùng để chỉ định liệu một sổ Excel có được tải hay không.

* Khi giá trị được đặt là `false`, chỉ đường dẫn sổ làm việc được cập nhật — dữ liệu biểu đồ sẽ không được tải hoặc cập nhật từ sổ mục tiêu. Bạn có thể muốn dùng cài đặt này khi sổ mục tiêu không tồn tại hoặc không khả dụng. 
* Khi giá trị được đặt là `true`, dữ liệu biểu đồ sẽ được cập nhật từ sổ mục tiêu.

```java
import com.aspose.slides.*;

// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();

    ((ChartData)chartData).setExternalWorkbook("http://path/doesnt/exists", false);

    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Get the External Data Source Workbook Path of a Chart**

1. Tạo một thể hiện của lớp [Presentation](https://apireference.aspose.com/slides/vi/java/com.aspose.slides/presentation) .
1. Lấy tham chiếu đến slide thông qua chỉ mục của nó.
1. Tạo một đối tượng cho hình dạng biểu đồ.
1. Tạo một đối tượng cho loại nguồn (`ChartDataSourceType`) đại diện cho nguồn dữ liệu của biểu đồ.
1. Chỉ định điều kiện liên quan dựa trên loại nguồn giống với loại nguồn dữ liệu sổ làm việc bên ngoài.

Đoạn mã Java này minh họa thao tác:

```java
import com.aspose.slides.*;

// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(1);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    int sourceType = chart.getChartData().getDataSourceType();
    
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        String path = chart.getChartData().getExternalWorkbookPath();
    }
	
	// Lưu bản trình chiếu
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Edit Chart Data**

Bạn có thể chỉnh sửa dữ liệu trong sổ làm việc bên ngoài giống như khi thay đổi nội dung của sổ làm việc nội bộ. Khi một sổ làm việc bên ngoài không thể tải, một ngoại lệ sẽ được ném ra.

Đoạn mã Java này là triển khai của quy trình đã mô tả:

```java
import com.aspose.slides.*;

// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = (IChart)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ChartData chartData = (ChartData)chart.getChartData();
    
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    
    pres.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Recover a Workbook from the Chart Cache**

Nếu một biểu đồ sử dụng sổ làm việc bên ngoài bị thiếu hoặc không khả dụng, Aspose.Slides có thể tái tạo sổ làm việc biểu đồ từ dữ liệu được lưu trong bộ nhớ cache của bản thuyết trình. Tạo [LoadOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadoptions/), cấu hình nó với [SpreadsheetOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/spreadsheetoptions/), và gọi [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) với `true` trước khi mở bản thuyết trình.

Ví dụ Java sau mở một bản thuyết trình mà biểu đồ tham chiếu tới một sổ làm việc bên ngoài không khả dụng và truy cập dữ liệu đã khôi phục qua [IChart.getChartData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichart/#getChartData--) và [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Đọc hoặc sửa dữ liệu sổ làm việc đã khôi phục ở đây.
} finally {
    presentation.dispose();
}
```

Nếu sổ làm việc bên ngoài không khả dụng và chức năng khôi phục bị tắt, Aspose.Slides sẽ ném ra một ngoại lệ. Chỉ bật khôi phục khi việc sử dụng dữ liệu biểu đồ đã cache là một cách dự phòng chấp nhận được, vì cache có thể không chứa các thay đổi được thực hiện trên sổ làm việc bên ngoài sau khi bản thuyết trình được cập nhật lần cuối.

## **FAQ**

**Tôi có thể xác định được một biểu đồ cụ thể có liên kết tới sổ làm việc bên ngoài hay nhúng không?**

Có. Một biểu đồ có [data source type](https://reference.aspose.com/slides/vi/java/com.aspose.slides/chartdata/#getDataSourceType--) và một [path to an external workbook](https://reference.aspose.com/slides/vi/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); nếu nguồn là sổ làm việc bên ngoài, bạn có thể đọc đường dẫn đầy đủ để chắc chắn rằng một tệp bên ngoài đang được sử dụng.

**Các đường dẫn tương đối tới sổ làm việc bên ngoài có được hỗ trợ không, và chúng được lưu như thế nào?**

Có. Nếu bạn chỉ định một đường dẫn tương đối, nó sẽ tự động được chuyển thành đường dẫn tuyệt đối. Điều này thuận tiện cho việc di chuyển dự án; tuy nhiên, hãy lưu ý rằng bản thuyết trình sẽ lưu đường dẫn tuyệt đối trong tệp PPTX.

**Tôi có thể sử dụng sổ làm việc nằm trên các tài nguyên/mạng chia sẻ không?**

Có, các sổ như vậy có thể được dùng làm nguồn dữ liệu bên ngoài. Tuy nhiên, việc chỉnh sửa trực tiếp các sổ làm việc từ xa bằng Aspose.Slides không được hỗ trợ — chúng chỉ có thể được dùng làm nguồn.

**Aspose.Slides có ghi đè lên tệp XLSX bên ngoài khi lưu bản thuyết trình không?**

Không. Bản thuyết trình lưu một [link to the external file](https://reference.aspose.com/slides/vi/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) và dùng nó để đọc dữ liệu. Tệp bên ngoài không bị thay đổi khi bản thuyết trình được lưu.

**Nếu tệp bên ngoài được bảo mật bằng mật khẩu, tôi nên làm gì?**

Aspose.Slides không chấp nhận mật khẩu khi liên kết. Một cách thường dùng là gỡ bảo mật trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, sử dụng [Aspose.Cells](/cells/java/)) và liên kết đến bản sao đó.

**Nhiều biểu đồ có thể tham chiếu cùng một sổ làm việc bên ngoài không?**

Có. Mỗi biểu đồ lưu liên kết riêng của mình. Nếu chúng đều trỏ tới cùng một tệp, việc cập nhật tệp sẽ được phản ánh trong mỗi biểu đồ lần tiếp theo khi dữ liệu được tải.