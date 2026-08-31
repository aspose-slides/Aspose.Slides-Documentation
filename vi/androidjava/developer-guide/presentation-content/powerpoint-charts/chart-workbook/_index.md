---
title: Quản lý Workbook Biểu Đồ trong Bản Trình Chiếu trên Android
linktitle: Workbook Biểu Đồ
type: docs
weight: 70
url: /vi/androidjava/chart-workbook/
keywords:
- workbook biểu đồ
- dữ liệu biểu đồ
- ô workbook
- nhãn dữ liệu
- bảng tính
- nguồn dữ liệu
- workbook ngoại vi
- dữ liệu ngoại vi
- bộ nhớ cache biểu đồ
- khôi phục workbook
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Khám phá Aspose.Slides cho Android qua Java: quản lý workbook biểu đồ trong các định dạng PowerPoint và OpenDocument một cách dễ dàng để tối ưu hóa dữ liệu bản trình chiếu của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với sổ làm việc (workbook) cho biểu đồ trong Aspose.Slides. Nó cho thấy cách đọc và ghi dữ liệu biểu đồ thông qua luồng workbook, sử dụng các ô workbook làm nhãn dữ liệu biểu đồ, truy cập bộ sưu tập worksheet, và chỉ định loại nguồn dữ liệu cho các giá trị biểu đồ.

Nó cũng đề cập tới việc làm việc với các workbook ngoại vi làm nguồn dữ liệu cho biểu đồ. Các ví dụ minh họa cách tạo và gán một workbook ngoại vi, lấy đường dẫn của workbook ngoại vi được liên kết với biểu đồ, và chỉnh sửa dữ liệu biểu đồ khi workbook khả dụng.

## **Đọc và Ghi Dữ Liệu Biểu Đồ Từ Workbook**
Aspose.Slides cung cấp các phương thức [ReadWorkbookStream](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) và [WriteWorkbookStream](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) cho phép bạn đọc và ghi các workbook dữ liệu biểu đồ (chứa dữ liệu biểu đồ đã được chỉnh sửa bằng Aspose.Cells). **Lưu ý** rằng dữ liệu biểu đồ phải được sắp xếp theo cùng cách hoặc có cấu trúc tương tự như nguồn.

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

### **Xác Thực Bố Cục Biểu Đồ Sau Khi Sửa Đổi Workbook**

Khi bạn thay thế một workbook nhúng bằng một workbook đã được chỉnh sửa, biểu đồ vẫn giữ lại các bộ sưu tập series và category ban đầu. Sự không khớp này có thể khiến [IChart.validateChartLayout](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChart#validateChartLayout--) thất bại với lỗi chỉ mục ngoài phạm vi. Hãy xóa các series và category hiện có trước khi ghi workbook đã cập nhật trở lại biểu đồ.

```java
// Sau khi chỉnh sửa luồng workbook (ví dụ: sử dụng Aspose.Cells)
byte[] updatedWorkbook = chartData.readWorkbookStream();

// Xóa các tham chiếu dữ liệu hiện có.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

Việc xóa các bộ sưu tập đảm bảo cấu trúc dữ liệu biểu đồ đồng nhất với workbook mới, cho phép `validateChartLayout` hoàn thành mà không gặp lỗi.

## **Đặt Ô Workbook Là Nhãn Dữ Liệu Biểu Đồ**

1. Tạo một thể hiện của lớp [Presentation](https://apireference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation).
1. Lấy tham chiếu đến một slide thông qua chỉ mục của nó.
1. Thêm biểu đồ Bubble với một số dữ liệu.
1. Truy cập series của biểu đồ.
1. Đặt ô workbook làm nhãn dữ liệu.
1. Lưu bản trình chiếu.

Đoạn mã Java dưới đây cho thấy cách đặt ô workbook làm nhãn dữ liệu biểu đồ:

```java
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Khởi tạo một lớp Presentation đại diện cho một tệp bản trình chiếu
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

## **Quản Lý Worksheets**

Đoạn mã Java này minh họa một thao tác trong đó phương thức [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) được sử dụng để truy cập bộ sưu tập worksheet:

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

## **Chỉ Định Loại Nguồn Dữ Liệu**

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

## **Phát Hiện Định Dạng Workbook Nhúng Không Hỗ Trợ**

Aspose.Slides không hỗ trợ định dạng workbook Excel nhị phân (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể sử dụng phương thức `getEmbeddedWorkbookType` trên [IChartData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartData) kết hợp với enumeration [WorkbookType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/WorkbookType) để phát hiện các định dạng không được hỗ trợ và bỏ qua những biểu đồ đó.

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
            // Workbook nhúng ở định dạng .xlsb, không được hỗ trợ.
            continue;
        }

        // Đọc hoặc chỉnh sửa dữ liệu workbook của biểu đồ tại đây.
    }
} finally {
    presentation.dispose();
}
```

## **Workbook Ngoại Vi**

Aspose.Slides hỗ trợ workbook ngoại vi làm nguồn dữ liệu cho biểu đồ.

### **Tạo Workbook Ngoại Vi**

Sử dụng các phương thức **`readWorkbookStream`** và **`setExternalWorkbook`**, bạn có thể tạo một workbook ngoại vi từ đầu hoặc chuyển một workbook nội bộ thành ngoại vi.

Đoạn mã Java dưới đây minh họa quy trình tạo workbook ngoại vi:

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

### **Gán Workbook Ngoại Vi**

Sử dụng phương thức **`setExternalWorkbook`**, bạn có thể gán một workbook ngoại vi cho biểu đồ làm nguồn dữ liệu. Phương thức này cũng có thể được dùng để cập nhật đường dẫn tới workbook ngoại vi (nếu workbook đã được di chuyển).

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các workbook được lưu trữ tại các vị trí từ xa hoặc tài nguyên, bạn vẫn có thể dùng các workbook này làm nguồn dữ liệu ngoại vi. Nếu đường dẫn tương đối cho một workbook ngoại vi được cung cấp, nó sẽ tự động được chuyển thành đường dẫn đầy đủ.

Đoạn mã Java sau cho thấy cách đặt một workbook ngoại vi:

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

Tham số `updateChartData` (trong phương thức `setExternalWorkbook`) được dùng để chỉ định liệu workbook Excel có được tải hay không.

* Khi giá trị `updateChartData` được đặt thành `false`, chỉ đường dẫn workbook được cập nhật — dữ liệu biểu đồ sẽ không được tải hoặc cập nhật từ workbook mục tiêu. Bạn có thể muốn dùng thiết lập này khi workbook mục tiêu không tồn tại hoặc không khả dụng.
* Khi giá trị `updateChartData` được đặt thành `true`, dữ liệu biểu đồ sẽ được cập nhật từ workbook mục tiêu.

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

### **Lấy Đường Dẫn Workbook Nguồn Dữ Liệu Ngoại Vi Của Biểu Đồ**

1. Tạo một thể hiện của lớp [Presentation](https://apireference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation).
1. Lấy tham chiếu đến một slide thông qua chỉ mục của nó.
1. Tạo một đối tượng cho dạng shape của biểu đồ.
1. Tạo một đối tượng cho loại nguồn (`ChartDataSourceType`) đại diện cho nguồn dữ liệu của biểu đồ.
1. Xác định điều kiện liên quan dựa trên việc loại nguồn giống với loại nguồn dữ liệu workbook ngoại vi.

Đoạn mã Java dưới đây minh họa thao tác này:

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

### **Chỉnh Sửa Dữ Liệu Biểu Đồ**

Bạn có thể chỉnh sửa dữ liệu trong các workbook ngoại vi theo cách tương tự như khi thay đổi nội dung của các workbook nội bộ. Khi một workbook ngoại vi không thể được tải, một ngoại lệ sẽ được ném ra.

Đoạn mã Java này là một triển khai của quy trình đã mô tả:

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

### **Khôi Phục Workbook Từ Bộ Nhớ Cache Của Biểu Đồ**

Nếu một biểu đồ sử dụng một workbook ngoại vi bị thiếu hoặc không khả dụng, Aspose.Slides có thể tái tạo workbook của biểu đồ từ dữ liệu đã được lưu trong bộ nhớ cache của bản trình chiếu. Tạo [LoadOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/loadoptions/), cấu hình nó với [SpreadsheetOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/spreadsheetoptions/), và gọi [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) với `true` trước khi mở bản trình chiếu.

Ví dụ Java sau mở một bản trình chiếu mà biểu đồ tham chiếu tới một workbook ngoại vi không khả dụng và truy cập dữ liệu đã khôi phục thông qua [IChart.getChartData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichart/#getChartData--) và [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
import com.aspose.slides.*;

SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Đọc hoặc chỉnh sửa dữ liệu workbook đã khôi phục ở đây.
} finally {
    presentation.dispose();
}
```

Nếu workbook ngoại vi không khả dụng và tính năng khôi phục bị tắt, Aspose.Slides sẽ ném ra một ngoại lệ. Chỉ bật tính năng khôi phục khi việc sử dụng dữ liệu biểu đồ đã được cache là một phương án dự phòng chấp nhận được, vì cache có thể không chứa các thay đổi đã được thực hiện trên workbook ngoại vi sau lần cập nhật cuối cùng của bản trình chiếu.

## **FAQ**

**Tôi có thể xác định liệu một biểu đồ cụ thể có liên kết tới workbook ngoại vi hay workbook nhúng không?**

Có. Một biểu đồ có một [loại nguồn dữ liệu](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) và một [đường dẫn tới workbook ngoại vi](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); nếu nguồn là một workbook ngoại vi, bạn có thể đọc đường dẫn đầy đủ để chắc chắn rằng một tệp ngoại vi đang được sử dụng.

**Các đường dẫn tương đối tới workbook ngoại vi có được hỗ trợ không, và chúng được lưu như thế nào?**

Có. Nếu bạn chỉ định một đường dẫn tương đối, nó sẽ tự động được chuyển thành đường dẫn tuyệt đối. Điều này tiện lợi cho việc di động dự án; tuy nhiên, hãy lưu ý rằng bản trình chiếu sẽ lưu đường dẫn tuyệt đối trong tệp PPTX.

**Tôi có thể sử dụng workbook nằm trên các tài nguyên/mạng chia sẻ không?**

Có, các workbook như vậy có thể được dùng làm nguồn dữ liệu ngoại vi. Tuy nhiên, việc chỉnh sửa trực tiếp các workbook từ xa bằng Aspose.Slides không được hỗ trợ — chúng chỉ có thể được dùng làm nguồn.

**Aspose.Slides có ghi đè lên file XLSX ngoại vi khi lưu bản trình chiếu không?**

Không. Bản trình chiếu lưu một [liên kết tới tệp ngoại vi](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) và dùng liên kết này để đọc dữ liệu. Tệp ngoại vi tự nó không bị thay đổi khi bản trình chiếu được lưu.

**Nếu file ngoại vi được bảo vệ bằng mật khẩu, tôi nên làm gì?**

Aspose.Slides không chấp nhận mật khẩu khi tạo liên kết. Một cách phổ biến là loại bỏ bảo vệ trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, bằng cách sử dụng [Aspose.Cells](/cells/androidjava/)) và liên kết tới bản sao đó.

**Nhiều biểu đồ có thể tham chiếu cùng một workbook ngoại vi không?**

Có. Mỗi biểu đồ lưu liên kết riêng của nó. Nếu tất cả chúng trỏ tới cùng một tệp, việc cập nhật tệp sẽ được phản ánh trong mỗi biểu đồ khi dữ liệu được tải lại.