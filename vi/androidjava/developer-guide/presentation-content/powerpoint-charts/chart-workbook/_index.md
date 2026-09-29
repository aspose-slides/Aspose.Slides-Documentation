---
title: Quản lý Workbook biểu đồ trong Bản trình bày trên Android
linktitle: Workbook biểu đồ
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
- workbook bên ngoài
- dữ liệu bên ngoài
- bộ nhớ đệm biểu đồ
- khôi phục workbook
- PowerPoint
- bản trình bày
- Android
- Java
- Aspose.Slides
description: "Khám phá Aspose.Slides cho Android qua Java: dễ dàng quản lý workbook biểu đồ trong định dạng PowerPoint và OpenDocument để tối ưu hoá dữ liệu bản trình bày của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với workbook biểu đồ trong Aspose.Slides. Nó cho thấy cách đọc và ghi dữ liệu biểu đồ thông qua luồng workbook, sử dụng các ô workbook làm nhãn dữ liệu biểu đồ, truy cập bộ sưu tập worksheet, và chỉ định kiểu nguồn dữ liệu cho các giá trị biểu đồ.

Nó cũng bao phủ việc làm việc với workbook bên ngoài như nguồn dữ liệu cho biểu đồ. Các ví dụ minh họa cách tạo và gán một workbook bên ngoài, lấy đường dẫn của workbook bên ngoài được liên kết với biểu đồ, và chỉnh sửa dữ liệu biểu đồ khi workbook có sẵn.

Đối với các ô workbook đại diện cho dữ liệu thiếu, xem [Kiểm soát hiển thị các ô trống](/slides/vi/androidjava/chart-series/) để biết sự khác biệt giữa ô trống và số 0, và so sánh biểu đồ đường của các chế độ hiển thị có sẵn.

## **Bao gồm dữ liệu từ các hàng và cột ẩn**

Sử dụng[IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-)để kiểm soát liệu một biểu đồ có vẽ dữ liệu từ các hàng và cột worksheet ẩn hay không. Đặt nó thành `true` để chỉ vẽ các ô hiển thị, hoặc `false` để bao gồm cả các ô hiển thị và ẩn. Cài đặt này chỉ kiểm soát việc vẽ biểu đồ; nó không ẩn hoặc hiện các hàng hoặc cột worksheet.

Tải xuống [hidden-source-data.pptx](hidden-source-data.pptx) và đặt nó trong thư mục làm việc. Slide đầu tiên của nó chứa một biểu đồ cột là hình dạng đầu tiên. Worksheet nhúng, `Sheet1`, chứa phạm vi nguồn sau, `A1:C4`. Hàng 3 và cột C bị ẩn, nhưng các ô của chúng vẫn chứa giá trị.

| Hàng worksheet | A: Tháng | B: Bán lẻ | C: Bán buôn (cột ẩn) |
| --- | --- | --- | --- |
| 2 | Tháng 1 | 10 | 30 |
| 3 (hàng ẩn) | Tháng 2 | 40 | 60 |
| 4 | Tháng 3 | 20 | 50 |

Truy cập các ô nguồn thông qua[IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--)và đọc[IChartDataCell.isHidden](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdatacell/#isHidden--)để kiểm tra trạng thái ẩn của chúng. Phương pháp này báo cáo trạng thái ẩn mà không thay đổi nó. Trong tệp này, B2 hiển thị, B3 thuộc hàng ẩn, và C2 thuộc cột ẩn; ví dụ in ra `false`, `true`, và `true` tương ứng.

Đối với ví dụ này, làm mới dữ liệu biểu đồ sau khi thay đổi cài đặt vẽ: giữ lại workbook nhúng bằng[readWorkbookStream](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--)và tải lại bằng[writeWorkbookStream](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-). Khi bao gồm tất cả các ô, cũng sử dụng[setRange](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-)để khôi phục phạm vi đầy đủ, bao gồm danh mục tháng Hai ẩn. Chỉ thay đổi cờ không đủ để làm mới dữ liệu biểu đồ và nhãn danh mục được lưu trong bộ nhớ đệm của mẫu này.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hidden-source-data.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
        System.out.println("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        System.out.println("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        System.out.println("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        byte[] workbookData = chart.getChartData().readWorkbookStream();
        for (boolean visibleOnly : new boolean[] { true, false }) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // Làm mới dữ liệu biểu đồ từ workbook nhúng.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Khôi phục phạm vi nguồn đầy đủ, bao gồm các danh mục ẩn.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", SaveFormat.Pptx);
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Ví dụ lưu `hidden_cells_true.pptx` chỉ với các giá trị Bán lẻ hiển thị (10 và 20), và `hidden_cells_false.pptx` với tất cả sáu giá trị. Các hình ảnh dưới đây minh họa hai chế độ vẽ. Hàng 3 và cột C vẫn ẩn trong cả hai workbook nhúng.

| Chỉ các ô hiển thị (`true`) | Tất cả các ô (`false`) |
| --- | --- |
| ![Chỉ các ô hiển thị: Giá trị Bán lẻ 10 và 20 cho Tháng 1 và Tháng 3.](hidden_cells_True.png) | ![Tất cả các ô: Giá trị Bán lẻ và Bán buôn cho Tháng 1, Tháng 2 và Tháng 3.](hidden_cells_False.png) |

Một ô ẩn chứa giá trị khác với một ô trống.[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-)kiểm soát cách hiển thị các giá trị thiếu; nó không bao gồm hoặc loại trừ dữ liệu nguồn ẩn. Xem [Kiểm soát hiển thị các ô trống](/slides/vi/androidjava/chart-series/#control-the-display-of-empty-cells) để biết ví dụ.

## **Đọc và ghi dữ liệu biểu đồ từ một workbook**

Aspose.Slides for Android via Java cung cấp các phương thức[readWorkbookStream](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--)và[writeWorkbookStream](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-)cho phép bạn đọc và ghi các workbook dữ liệu biểu đồ (chứa dữ liệu biểu đồ đã chỉnh sửa bằng Aspose.Cells). **Lưu ý** rằng dữ liệu biểu đồ phải được tổ chức theo cùng một cách hoặc phải có cấu trúc tương tự nguồn.

Ví dụ này mở `chart.pptx`, phải chứa một biểu đồ là hình dạng đầu tiên trên slide đầu tiên. Nó đọc workbook nhúng vào một mảng byte, xóa các series và category hiện có, và ghi lại cùng một workbook. Các thay đổi vẫn tồn tại trong bộ nhớ; ví dụ không lưu bản trình bày.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Xác thực bố cục biểu đồ sau khi sửa đổi workbook**

Khi bạn thay thế một workbook nhúng bằng một workbook đã sửa, biểu đồ vẫn giữ các collection series và category ban đầu. Sự không khớp này có thể gây[IChart.validateChartLayout](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichart/#validateChartLayout--)thất bại với lỗi chỉ mục ngoài phạm vi. Xóa các series và category hiện có trước khi ghi workbook đã cập nhật lại vào biểu đồ. Ví dụ này yêu cầu `chart.pptx` với một biểu đồ là hình dạng đầu tiên trên slide đầu tiên. Nhận xét đánh dấu nơi sẽ chỉnh sửa workbook; ví dụ chạy được ghi lại workbook gốc và xác thực bố cục trong bộ nhớ.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        // Sửa đổi các byte của workbook ở đây, ví dụ, sử dụng Aspose.Cells.

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Xóa các collection loại bỏ các tham chiếu dữ liệu lỗi thời trước khi workbook được ghi lại. Tái tạo bất kỳ mapping series và category nào cần thiết cho workbook đã cập nhật trước khi sử dụng biểu đồ.

## **Đặt một ô trong Workbook làm Nhãn dữ liệu biểu đồ**

Bạn có thể sử dụng văn bản từ các ô workbook làm nhãn dữ liệu biểu đồ. Các bước sau cho thấy cách liên kết các nhãn trong biểu đồ bong bóng tới các ô trong workbook dữ liệu của nó.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) .
2. Truy cập slide đầu tiên bằng chỉ mục bắt đầu từ 0.
3. Thêm một biểu đồ bong bóng với dữ liệu mặc định.
4. Truy cập series của biểu đồ.
5. Đặt ô trong workbook làm nhãn dữ liệu.
6. Lưu bản trình bày.

Ví dụ này mở `chart2.pptx`, phải chứa ít nhất một slide, và thêm một biểu đồ bong bóng với dữ liệu mặc định. Nó sử dụng các ô A10:A12 trên worksheet 0 cho ba nhãn đầu tiên trong series đầu tiên, bật nhãn từ ô, và lưu kết quả vào `resultchart.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Quản lý các Worksheet**

Phương thức[IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--)cung cấp quyền truy cập vào các worksheet trong một workbook biểu đồ. Ví dụ này tạo một biểu đồ tròn với dữ liệu mặc định và in tên mỗi worksheet ra console.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    for (int i = 0; i < workbook.getWorksheets().size(); i++) {
        System.out.println(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **Xác định loại nguồn dữ liệu**

Ví dụ này tạo một biểu đồ cột 3D với dữ liệu mặc định và đặt hai tên series bằng các nguồn dữ liệu khác nhau. Tên đầu tiên sử dụng một chuỗi literal; tên thứ hai sử dụng ô C1 trên worksheet 0. Phân loại[DataSourceType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/datasourcetype/)chọn nguồn cho mỗi tên. Kết quả được lưu vào `pres.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    IStringChartValue cellName = chart.getChartData().getSeries().get_Item(1).getName();
    IChartDataCell nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Phát hiện các định dạng Workbook nhúng không được hỗ trợ**

Aspose.Slides không hỗ trợ định dạng workbook Excel nhị phân (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể sử dụng phương thức[getEmbeddedWorkbookType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--)trên [IChartData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdata/) cùng với phân loại[WorkbookType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/workbooktype/)để phát hiện các định dạng không hỗ trợ và bỏ qua các biểu đồ đó. Ví dụ này kiểm tra các shape trên slide đầu tiên của `sample.pptx`, bỏ qua các shape không phải biểu đồ, và in thông báo chẩn đoán cho mỗi biểu đồ có workbook .xlsb nhúng.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IChartData chartData = chart.getChartData();
        boolean isInternalWorkbook = chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook;
        boolean isBinaryMacro = chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            System.out.println("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // Đọc hoặc sửa đổi dữ liệu workbook biểu đồ được hỗ trợ ở đây.
    }
} finally {
    presentation.dispose();
}
```

## **Workbook ngoài**

Aspose.Slides hỗ trợ sử dụng workbook bên ngoài làm nguồn dữ liệu cho biểu đồ.

### **Tạo một Workbook bên ngoài**

Sử dụng[readWorkbookStream](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--)và[setExternalWorkbook](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-)để xuất một workbook biểu đồ nhúng ra tệp và liên kết biểu đồ tới workbook bên ngoài đó.

Ví dụ này tạo một biểu đồ tròn với dữ liệu mặc định, ghi workbook của nó vào `externalWorkbook1.xlsx`, và hoàn thành ghi tệp trước khi gán tệp làm nguồn dữ liệu biểu đồ. Nó lưu bản trình bày đã liên kết vào `externalWorkbook.pptx`.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    File workbookFile = new File("externalWorkbook1.xlsx").getAbsoluteFile();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        try (FileOutputStream workbookStream = new FileOutputStream(workbookFile)) {
            workbookStream.write(workbookData);
        }
        chart.getChartData().setExternalWorkbook(workbookFile.getAbsolutePath());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Gán một Workbook bên ngoài**

Bằng cách sử dụng phương thức[setExternalWorkbook](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-), bạn có thể gán một workbook bên ngoài cho một biểu đồ làm nguồn dữ liệu. Phương thức này cũng có thể được dùng để cập nhật đường dẫn tới workbook bên ngoài (nếu workbook đó đã được di chuyển).

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các workbook được lưu ở vị trí từ xa hoặc tài nguyên, bạn vẫn có thể sử dụng các workbook như vậy làm nguồn dữ liệu bên ngoài. Nếu đường dẫn tương đối cho một workbook bên ngoài được cung cấp, nó sẽ tự động chuyển thành đường dẫn đầy đủ.

Ví dụ này yêu cầu `externalWorkbook.xlsx` trong thư mục làm việc. Worksheet có tên `Sheet1` phải chứa một tên series trong B1, các tên category trong A2:A4, và các giá trị số trong B2:B4. Ví dụ tạo một biểu đồ tròn, liên kết workbook, và sử dụng[setRange](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-)để ánh xạ A1:B4 thành một series và ba category. Nó lưu kết quả vào `Presentation_with_externalWorkbook.pptx`.

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    File workbookFile = new File("externalWorkbook.xlsx");
    String workbookPath = workbookFile.getAbsolutePath();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Tham số`updateChartData`của[setExternalWorkbook](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-)kiểm soát việc có tải workbook hay không.

* Khi `updateChartData` là `false`, chỉ có đường dẫn workbook được cập nhật. Dữ liệu biểu đồ không được tải hoặc cập nhật từ workbook mục tiêu, vì vậy workbook có thể không khả dụng.
* Khi `updateChartData` là `true`, dữ liệu biểu đồ được cập nhật từ workbook mục tiêu.

Ví dụ sau gán một URL placeholder với `updateChartData`đặt thành `false`. Nó giữ dữ liệu mặc định của biểu đồ tròn và lưu bản trình bày mà không tải workbook không khả dụng.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Lấy đường dẫn Workbook nguồn dữ liệu bên ngoài của một biểu đồ**

Để xác định workbook được liên kết với một biểu đồ, đầu tiên kiểm tra xem biểu đồ có sử dụng nguồn dữ liệu bên ngoài không. Nếu có, bạn có thể lấy đường dẫn workbook bằng các bước sau.

1. Tạo một thể hiện của lớp[Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/).
2. Truy cập slide đầu tiên bằng chỉ mục bắt đầu từ 0.
3. Kiểm tra xem hình dạng đầu tiên có phải là một biểu đồ không.
4. Đọc kiểu nguồn dữ liệu của biểu đồ.
5. Nếu nguồn là một workbook bên ngoài, đọc đường dẫn của nó.

Ví dụ này mở `externalWorkbook.pptx`, được tạo trong ví dụ trước, và kiểm tra hình dạng đầu tiên trên slide đầu tiên. Nếu đó là một biểu đồ được liên kết tới một workbook bên ngoài, ví dụ in [getExternalWorkbookPath](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--)ra console. Sau đó nó lưu một bản sao của bản trình bày vào `Result.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("externalWorkbook.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        if (chartData.getDataSourceType() == ChartDataSourceType.ExternalWorkbook) {
            System.out.println(chartData.getExternalWorkbookPath());
        } else {
            System.out.println("The chart does not use an external workbook.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Chỉnh sửa dữ liệu biểu đồ**

Bạn có thể chỉnh sửa dữ liệu trong các workbook bên ngoài theo cách bạn thay đổi nội dung của các workbook nội bộ. Khi một workbook bên ngoài không thể tải, một ngoại lệ sẽ được ném ra.

Ví dụ này yêu cầu `presentation.pptx` với một biểu đồ là hình dạng đầu tiên trên slide đầu tiên và một workbook bên ngoài có thể truy cập. Nó đặt giá trị dựa trên ô của điểm dữ liệu đầu tiên trong series đầu tiên thành 100 và lưu bản trình bày vào `presentation_out.pptx`. Chỉnh sửa giá trị ô có thể cập nhật tệp XLSX bên ngoài đã liên kết, vì vậy hãy sử dụng một bản sao nếu bạn cần giữ nguyên workbook gốc.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartSeriesCollection series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            IChartDataCell valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", SaveFormat.Pptx);
            } else {
                System.out.println("The first data point is not linked to a workbook cell.");
            }
        } else {
            System.out.println("The chart has no data points to edit.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Khôi phục Workbook từ bộ nhớ đệm biểu đồ**

Nếu một biểu đồ sử dụng một workbook bên ngoài bị thiếu hoặc không khả dụng, Aspose.Slides có thể tái tạo workbook biểu đồ từ dữ liệu được lưu trong bộ nhớ đệm của bản trình bày. Tạo[LoadOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/loadoptions/), gọi[LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), và đặt[ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-)thành `true` trước khi mở bản trình bày.

Ví dụ Java sau mở `presentation.pptx`, slide đầu tiên trên slide đầu tiên phải là một biểu đồ tham chiếu tới một workbook bên ngoài không khả dụng, và truy cập dữ liệu đã khôi phục thông qua[IChart.getChartData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichart/#getChartData--)và[IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
import com.aspose.slides.*;

SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // Đọc hoặc sửa đổi dữ liệu workbook đã khôi phục ở đây.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Nếu workbook bên ngoài không khả dụng và khôi phục bị tắt, Aspose.Slides sẽ ném một ngoại lệ. Chỉ bật khôi phục khi việc sử dụng dữ liệu biểu đồ đã lưu trong bộ nhớ đệm là một phương án chấp nhận được, vì bộ nhớ đệm có thể không chứa các thay đổi đã thực hiện trên workbook bên ngoài sau khi bản trình bày được cập nhật lần cuối.

## **Câu hỏi thường gặp**

**Tôi có thể xác định liệu một biểu đồ cụ thể có liên kết tới workbook bên ngoài hay nhúng không?**

Có. Một biểu đồ có [kiểu nguồn dữ liệu](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/chartdata/#getDataSourceType--)và một [đường dẫn tới workbook bên ngoài](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); nếu nguồn là một workbook bên ngoài, bạn có thể đọc đường dẫn đầy đủ để chắc chắn rằng một tệp bên ngoài đang được sử dụng.

**Các đường dẫn tương đối tới workbook bên ngoài có được hỗ trợ không, và chúng được lưu trữ như thế nào?**

Có. Nếu bạn chỉ định một đường dẫn tương đối, nó sẽ tự động được chuyển sang đường dẫn tuyệt đối. Bản trình bày lưu đường dẫn tuyệt đối trong tệp PPTX, vì vậy việc di chuyển workbook có thể yêu cầu cập nhật liên kết.

**Tôi có thể sử dụng workbook nằm trên tài nguyên/mạng chia sẻ không?**

Có, các workbook như vậy có thể được sử dụng làm nguồn dữ liệu bên ngoài. Tuy nhiên, việc chỉnh sửa trực tiếp các workbook từ xa bằng Aspose.Slides không được hỗ trợ — chúng chỉ có thể được sử dụng làm nguồn.

**Aspose.Slides có ghi đè lên tệp XLSX bên ngoài khi lưu bản trình bày không?**

Bản trình bày lưu một [liên kết đến tệp bên ngoài](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--). Việc chỉnh sửa dữ liệu biểu đồ dựa trên ô cũng có thể cập nhật tệp XLSX địa phương đã liên kết. Hãy sử dụng một bản sao của workbook nếu bản gốc phải được giữ nguyên.

**Nếu tệp bên ngoài được bảo mật bằng mật khẩu, tôi nên làm gì?**

Aspose.Slides không chấp nhận mật khẩu khi liên kết. Một cách thường dùng là loại bỏ bảo mật trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, bằng [Aspose.Cells](https://reference.aspose.com/cells/java/)) và liên kết tới bản sao đó.

**Nhiều biểu đồ có thể tham chiếu cùng một workbook bên ngoài không?**

Có. Mỗi biểu đồ lưu liên kết riêng của nó. Nếu chúng đều trỏ tới cùng một tệp, việc cập nhật tệp đó sẽ được phản ánh trong mỗi biểu đồ vào lần kế tiếp dữ liệu được tải.