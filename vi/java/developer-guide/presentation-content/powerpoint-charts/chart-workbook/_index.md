---
title: Quản lý Sổ làm việc Biểu đồ trong Bản trình bày bằng Java
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
- bộ nhớ đệm biểu đồ
- phục hồi sổ làm việc
- PowerPoint
- bản trình bày
- Java
- Aspose.Slides
description: "Khám phá Aspose.Slides cho Java: dễ dàng quản lý sổ làm việc biểu đồ trong định dạng PowerPoint và OpenDocument để tối ưu hóa dữ liệu bản trình bày của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với sổ làm việc biểu đồ trong Aspose.Slides. Nó cho thấy cách đọc và ghi dữ liệu biểu đồ thông qua luồng sổ làm việc, sử dụng các ô sổ làm việc làm nhãn dữ liệu biểu đồ, truy cập các bộ sưu tập worksheet và chỉ định loại nguồn dữ liệu cho các giá trị biểu đồ.

Nó cũng đề cập đến việc làm việc với sổ làm việc bên ngoài làm nguồn dữ liệu cho biểu đồ. Các ví dụ minh họa cách tạo và gán một sổ làm việc bên ngoài, lấy đường dẫn của sổ làm việc bên ngoài được liên kết tới biểu đồ, và chỉnh sửa dữ liệu biểu đồ khi sổ làm việc khả dụng.

Đối với các ô sổ làm việc đại diện cho dữ liệu thiếu, hãy xem [Kiểm soát việc Hiển thị các Ô Trống](/slides/vi/java/chart-series/) để biết sự khác biệt giữa một ô trống và số zero, và so sánh biểu đồ đường của các chế độ hiển thị có sẵn.

## **Bao gồm Dữ liệu từ Các Hàng và Cột Ẩn**

Sử dụng[IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) để kiểm soát liệu biểu đồ có vẽ dữ liệu từ các hàng và cột worksheet ẩn hay không. Đặt `true` để vẽ chỉ các ô hiển thị, hoặc `false` để bao gồm cả các ô hiển thị và ẩn. Cài đặt này chỉ kiểm soát việc vẽ biểu đồ; nó không ẩn hoặc hiện các hàng hoặc cột worksheet.

[sample presentation](hidden-source-data.pptx) chứa một biểu đồ cột là hình dạng đầu tiên trên slide đầu tiên. Worksheet nhúng, `Sheet1`, chứa dải nguồn sau, `A1:C4`. Hàng 3 và cột C được ẩn, nhưng các ô của chúng vẫn chứa giá trị.

| Hàng worksheet | A: Tháng | B: Bán lẻ | C: Bán buôn (cột ẩn) |
| --- | --- | --- | --- |
| 2 | Tháng 1 | 10 | 30 |
| 3 (hàng ẩn) | Tháng 2 | 40 | 60 |
| 4 | Tháng 3 | 20 | 50 |

Truy cập các ô nguồn thông qua[IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) và đọc[IChartDataCell.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#isHidden--) để kiểm tra trạng thái ẩn của chúng. Phương pháp này báo cáo trạng thái ẩn mà không thay đổi nó. Trong tệp này, B2 là hiển thị, B3 thuộc hàng ẩn, và C2 thuộc cột ẩn; ví dụ in ra `false`, `true`, và `true` tương ứng.

Đối với ví dụ này, làm mới dữ liệu biểu đồ sau khi thay đổi cài đặt vẽ: giữ lại workbook nhúng bằng[readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) và tải lại bằng[writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---). Khi bao gồm tất cả các ô, cũng sử dụng[setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) để khôi phục dải đầy đủ, bao gồm danh mục tháng 2 ẩn. Chỉ thay đổi cờ không đủ để làm mới dữ liệu biểu đồ đã được lưu trong bộ nhớ đệm và nhãn danh mục của mẫu này.

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
                // Khôi phục dải nguồn đầy đủ, bao gồm các danh mục ẩn.
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

Ví dụ lưu hai phiên bản của bản trình bày: một chỉ có các giá trị Bán lẻ hiển thị (10 và 20), và một khác với tất cả sáu giá trị. Các hình ảnh dưới đây minh họa hai chế độ vẽ. Hàng 3 và cột C vẫn ẩn trong cả hai workbook nhúng.

| Chỉ các ô hiển thị (`true`) | Tất cả các ô (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

Một ô ẩn chứa giá trị khác với một ô trống.[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) kiểm soát cách hiển thị các giá trị thiếu; nó không bao gồm hoặc loại trừ dữ liệu nguồn ẩn. Xem [Kiểm soát việc Hiển thị các Ô Trống](/slides/vi/java/chart-series/#control-the-display-of-empty-cells) để biết ví dụ.

## **Lấy Dải Dữ liệu của Biểu đồ**

Trước khi cập nhật dữ liệu workbook trong một bản trình bày hiện có, kiểm tra dải nguồn để xác định các ô worksheet mà mỗi biểu đồ sử dụng.[IChartData.getRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getRange--) trả về dải dữ liệu hiện tại dưới dạng công thức có định danh worksheet, chẳng hạn `Sheet1!$A$1:$D$5`. Ở đây, `Sheet1` là tên worksheet, `!` ngăn cách nó với dải ô, và `$A$1:$D$5` xác định các ô A1 đến D5, bao gồm. Dấu `$` chỉ ra tham chiếu hàng và cột tuyệt đối.

Phương pháp này đọc dải hiện tại mà không thay đổi biểu đồ hoặc workbook của nó. Nếu biểu đồ không sử dụng workbook làm nguồn dữ liệu, nó sẽ ném `InvalidOperationException`. Để biết thêm chi tiết, xem [ChartData API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/).

Ví dụ này mở một bản trình bày và kiểm tra các hình dạng trực tiếp trên mỗi slide để tìm biểu đồ. Nó in ra tên mỗi biểu đồ và dải nguồn. Nếu một biểu đồ không sử dụng workbook, nó in thông báo và tiếp tục với biểu đồ tiếp theo.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.InvalidOperationException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                try {
                    String range = chart.getChartData().getRange();
                    System.out.println(chart.getName() + ": " + range);
                } catch (InvalidOperationException exception) {
                    System.out.println(chart.getName() + ": The chart does not use a workbook as its data source.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Đọc và Ghi Dữ liệu Biểu đồ từ Sổ làm việc**

Aspose.Slides for Java cung cấp các phương pháp[readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) và[writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) cho phép bạn đọc và ghi workbook dữ liệu biểu đồ (chứa dữ liệu biểu đồ đã chỉnh sửa bằng Aspose.Cells). **Lưu ý** rằng dữ liệu biểu đồ phải được tổ chức theo cùng cách hoặc có cấu trúc tương tự như nguồn.

Ví dụ này sử dụng một bản trình bày có biểu đồ là hình dạng đầu tiên trên slide đầu tiên. Nó đọc workbook nhúng vào một mảng byte, xóa các series và danh mục hiện có, và ghi lại cùng một workbook. Các thay đổi vẫn còn trong bộ nhớ; ví dụ không lưu bản trình bày.

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

### **Xác thực Bố cục Biểu đồ Sau Khi Sửa đổi Sổ làm việc**

Khi bạn thay thế một workbook nhúng bằng một workbook đã sửa, biểu đồ vẫn giữ lại các bộ sưu tập series và danh mục gốc. Sự không khớp này có thể khiến[IChart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#validateChartLayout--) thất bại với lỗi chỉ mục ngoài phạm vi. Xóa các series và danh mục hiện có trước khi ghi workbook đã cập nhật trở lại biểu đồ. Ví dụ này sử dụng một biểu đồ là hình dạng đầu tiên trên slide đầu tiên. Các chú thích đánh dấu nơi sẽ thực hiện việc chỉnh sửa workbook; ví dụ chạy được sẽ ghi lại workbook gốc và xác thực bố cục trong bộ nhớ.

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

        // Sửa đổi các byte của workbook tại đây, ví dụ, bằng cách sử dụng Aspose.Cells.

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

Việc xóa các bộ sưu tập loại bỏ các tham chiếu dữ liệu cũ trước khi workbook được ghi lại. Hãy xây dựng lại bất kỳ series và ánh xạ danh mục nào cần thiết cho workbook đã cập nhật trước khi sử dụng biểu đồ.

## **Đặt Ô Sổ làm việc làm Nhãn Dữ liệu Biểu đồ**

Bạn có thể sử dụng văn bản từ các ô workbook làm nhãn dữ liệu biểu đồ.

Ví dụ này thêm một biểu đồ bong bóng với dữ liệu mặc định vào slide đầu tiên của một bản trình bày hiện có. Nó sử dụng các ô A10:A12 trên worksheet 0 cho ba nhãn đầu tiên trong series đầu tiên, bật nhãn từ các ô, và lưu bản trình bày đã cập nhật.

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

## **Quản lý Worksheets**

[IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) cung cấp quyền truy cập vào các worksheet trong một workbook biểu đồ. Ví dụ này tạo một biểu đồ tròn với dữ liệu mặc định và in tên mỗi worksheet ra console.

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

## **Chỉ định Loại Nguồn Dữ liệu**

Ví dụ này tạo một biểu đồ cột 3D với dữ liệu mặc định và đặt hai tên series bằng các nguồn dữ liệu khác nhau. Tên đầu tiên sử dụng một literal string; tên thứ hai sử dụng ô C1 trên worksheet 0.[Tên enum DataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/) chọn nguồn cho mỗi tên. Ví dụ lưu bản trình bày với các tên series đã cập nhật.

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

## **Phát hiện Định dạng Sổ làm việc Nhúng Không hỗ trợ**

Aspose.Slides không hỗ trợ định dạng workbook Excel nhị phân (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể sử dụng phương pháp[getEmbeddedWorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) trên[IChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/) kết hợp với enum[WorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/workbooktype/) để phát hiện các định dạng không hỗ trợ và bỏ qua các biểu đồ đó. Ví dụ này kiểm tra các hình dạng trên slide đầu tiên của một bản trình bày hiện có, bỏ qua các hình không phải biểu đồ, và in thông điệp chẩn đoán cho mỗi biểu đồ có workbook .xlsb nhúng.

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

## **Sổ làm việc Ngoài**

Aspose.Slides hỗ trợ sử dụng workbook bên ngoài làm nguồn dữ liệu cho biểu đồ.

### **Tạo Sổ làm việc Ngoài**

Sử dụng[readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) và[setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) để xuất workbook biểu đồ nhúng ra một tệp và liên kết biểu đồ tới workbook bên ngoài đó.

Ví dụ này tạo một biểu đồ tròn với dữ liệu mặc định và xuất workbook của nó. Nó hoàn thành việc ghi tệp trước khi gán workbook bên ngoài làm nguồn dữ liệu cho biểu đồ, sau đó lưu bản trình bày đã liên kết.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    Path workbookPath = Paths.get("externalWorkbook1.xlsx").toAbsolutePath();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        Files.write(workbookPath, workbookData);
        chart.getChartData().setExternalWorkbook(workbookPath.toString());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Đặt Sổ làm việc Ngoài**

Bằng cách sử dụng phương pháp[setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-), bạn có thể gán một workbook bên ngoài cho biểu đồ làm nguồn dữ liệu. Phương pháp này cũng có thể được dùng để cập nhật đường dẫn tới workbook bên ngoài (nếu workbook đó đã được di chuyển).

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các workbook được lưu ở vị trí từ xa hoặc tài nguyên, bạn vẫn có thể sử dụng các workbook đó như một nguồn dữ liệu bên ngoài. Nếu đường dẫn tương đối cho một workbook bên ngoài được cung cấp, nó sẽ tự động chuyển sang đường dẫn đầy đủ.

Ví dụ này sử dụng một workbook bên ngoài mà worksheet có tên `Sheet1` chứa một tên series trong B1, tên danh mục trong A2:A4, và các giá trị số trong B2:B4. Ví dụ tạo một biểu đồ tròn, liên kết workbook, và sử dụng[setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) để ánh xạ A1:B4 thành một series và ba danh mục. Nó lưu bản trình bày với biểu đồ đã liên kết.

```java
import com.aspose.slides.*;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    String workbookPath = Paths.get("externalWorkbook.xlsx").toAbsolutePath().toString();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Tham số `updateChartData` của[setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) kiểm soát việc có tải workbook hay không.

* Khi `updateChartData` là `false`, chỉ đường dẫn workbook được cập nhật. Dữ liệu biểu đồ không được tải hoặc cập nhật từ workbook mục tiêu, vì vậy workbook có thể không khả dụng.
* Khi `updateChartData` là `true`, dữ liệu biểu đồ được cập nhật từ workbook mục tiêu.

Ví dụ sau gán một URL placeholder với `updateChartData` được đặt là `false`. Nó giữ lại dữ liệu mặc định của biểu đồ tròn và lưu bản trình bày mà không tải workbook không khả dụng.

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

### **Lấy Đường dẫn Sổ làm việc Nguồn Dữ liệu Ngoài của Biểu đồ**

Để xác định workbook được liên kết với một biểu đồ, kiểm tra xem biểu đồ có sử dụng nguồn dữ liệu bên ngoài hay không và lấy đường dẫn workbook của nó.

Ví dụ này kiểm tra hình dạng đầu tiên trên slide đầu tiên của một bản trình bày có workbook bên ngoài được liên kết. Nếu đó là một biểu đồ được liên kết tới workbook bên ngoài, ví dụ in[getExternalWorkbookPath](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) ra console. Sau đó nó lưu một bản sao của bản trình bày.

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

### **Chỉnh sửa Dữ liệu Biểu đồ**

Bạn có thể chỉnh sửa dữ liệu trong các workbook bên ngoài theo cách tương tự như chỉnh sửa nội dung các workbook nội bộ. Khi một workbook bên ngoài không thể tải, một ngoại lệ sẽ được ném.

Ví dụ này sử dụng một biểu đồ là hình dạng đầu tiên trên slide đầu tiên và được liên kết tới một workbook bên ngoài có thể truy cập. Nó đặt giá trị dựa trên ô của điểm dữ liệu đầu tiên trong series đầu tiên thành 100 và lưu bản trình bày đã cập nhật. Việc chỉnh sửa giá trị ô có thể cập nhật tệp XLSX bên ngoài đã liên kết, vì vậy hãy sử dụng một bản sao nếu bạn cần giữ nguyên workbook gốc.

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

### **Phục hồi Sổ làm việc từ Bộ nhớ Đệm của Biểu đồ**

Nếu một biểu đồ sử dụng workbook bên ngoài bị thiếu hoặc không khả dụng, Aspose.Slides có thể tái tạo workbook biểu đồ từ dữ liệu được lưu trong bộ nhớ đệm của bản trình bày. Tạo[LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/), gọi[LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), và đặt[ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) thành `true` trước khi mở bản trình bày.

Ví dụ Java sau phục hồi dữ liệu workbook cho một biểu đồ là hình dạng đầu tiên trên slide đầu tiên và tham chiếu tới một workbook bên ngoài không khả dụng. Nó truy cập dữ liệu đã phục hồi qua[IChart.getChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getChartData--) và[IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

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

Nếu workbook bên ngoài không khả dụng và việc phục hồi bị tắt, Aspose.Slides sẽ ném một ngoại lệ. Chỉ bật phục hồi khi việc sử dụng dữ liệu biểu đồ đã được lưu trong bộ nhớ đệm là một giải pháp thay thế chấp nhận được, vì bộ nhớ đệm có thể không chứa các thay đổi đã thực hiện trên workbook bên ngoài sau lần cập nhật cuối cùng của bản trình bày.

## **Câu hỏi thường gặp**

**Tôi có thể xác định được liệu một biểu đồ cụ thể có liên kết tới workbook bên ngoài hay workbook nhúng không?**

Có. Một biểu đồ có một [data source type](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getDataSourceType--) và một [path to an external workbook](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); nếu nguồn là một workbook bên ngoài, bạn có thể đọc đường dẫn đầy đủ để chắc chắn một tệp bên ngoài đang được sử dụng.

**Các đường dẫn tương đối tới workbook bên ngoài có được hỗ trợ không, và chúng được lưu như thế nào?**

Có. Nếu bạn chỉ định một đường dẫn tương đối, nó sẽ tự động được chuyển thành một đường dẫn tuyệt đối. Bản trình bày lưu đường dẫn tuyệt đối trong tệp PPTX, vì vậy việc di chuyển workbook có thể yêu cầu cập nhật liên kết.

**Tôi có thể sử dụng các workbook nằm trên tài nguyên/mạng chia sẻ không?**

Có, các workbook như vậy có thể được sử dụng làm nguồn dữ liệu bên ngoài. Tuy nhiên, việc chỉnh sửa trực tiếp các workbook từ xa bằng Aspose.Slides không được hỗ trợ—chúng chỉ có thể được dùng làm nguồn.

**Aspose.Slides có ghi đè lên file XLSX bên ngoài khi lưu bản trình bày không?**

Bản trình bày lưu một [link to the external file](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--). Việc chỉnh sửa dữ liệu biểu đồ dựa trên ô cũng có thể cập nhật file XLSX local đã liên kết. Hãy sử dụng một bản sao của workbook nếu bản gốc phải được giữ nguyên.

**Nếu file bên ngoài được bảo vệ bằng mật khẩu, tôi nên làm gì?**

Aspose.Slides không chấp nhận mật khẩu khi tạo liên kết. Một cách thường dùng là bỏ bảo vệ trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, bằng [Aspose.Cells](https://reference.aspose.com/cells/java/)) và liên kết tới bản sao đó.

**Nhiều biểu đồ có thể tham chiếu cùng một workbook bên ngoài không?**

Có. Mỗi biểu đồ lưu liên kết riêng của nó. Nếu tất cả đều trỏ tới cùng một tệp, việc cập nhật tệp sẽ được phản ánh trong mỗi biểu đồ vào lần tiếp theo dữ liệu được tải.