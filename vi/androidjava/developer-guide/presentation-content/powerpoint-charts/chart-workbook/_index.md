---
title: Quản lý Sổ làm việc Biểu đồ trong Bản trình chiếu trên Android
linktitle: Sổ làm việc Biểu đồ
type: docs
weight: 70
url: /vi/androidjava/chart-workbook/
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
- Android
- Java
- Aspose.Slides
description: "Khám phá Aspose.Slides cho Android qua Java: dễ dàng quản lý sổ làm việc biểu đồ trong định dạng PowerPoint và OpenDocument để tối ưu hóa dữ liệu bản trình chiếu của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với sổ làm việc biểu đồ trong Aspose.Slides. Nó trình bày cách đọc và ghi dữ liệu biểu đồ thông qua luồng sổ làm việc, sử dụng các ô sổ làm việc làm nhãn dữ liệu biểu đồ, truy cập bộ sưu tập bảng tính, và chỉ định kiểu nguồn dữ liệu cho các giá trị biểu đồ.

Nó cũng đề cập đến việc làm việc với sổ làm việc bên ngoài làm nguồn dữ liệu cho biểu đồ. Các ví dụ minh họa cách tạo và gán một sổ làm việc bên ngoài, lấy đường dẫn của sổ làm việc bên ngoài được liên kết với biểu đồ, và chỉnh sửa dữ liệu biểu đồ khi sổ làm việc khả dụng.

Đối với các ô sổ làm việc đại diện cho dữ liệu bị thiếu, xem [Kiểm soát hiển thị các ô trống](/slides/vi/androidjava/chart-series/) để biết sự khác biệt giữa ô trống và số 0, và so sánh biểu đồ đường cho các chế độ hiển thị khả dụng.

## **Bao gồm dữ liệu từ các hàng và cột ẩn**

Sử dụng [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) để kiểm soát liệu biểu đồ có vẽ dữ liệu từ các hàng và cột ẩn của bảng tính hay không. Đặt nó thành `true` để chỉ vẽ các ô hiển thị, hoặc `false` để bao gồm cả các ô hiển thị và ẩn. Cài đặt này chỉ điều khiển việc vẽ biểu đồ; nó không ẩn hoặc hiện các hàng hoặc cột của bảng tính.

Bản trình chiếu mẫu ([bản trình chiếu mẫu](hidden-source-data.pptx)) chứa một biểu đồ cột làm hình dạng đầu tiên trên slide đầu tiên. Bảng tính nhúng, `Sheet1`, có phạm vi nguồn sau, `A1:C4`. Hàng 3 và cột C bị ẩn, nhưng các ô của chúng vẫn chứa giá trị.

| Hàng bảng tính | A: Tháng | B: Bán lẻ | C: Bán buôn (cột ẩn) |
| --- | --- | --- | --- |
| 2 | Tháng 1 | 10 | 30 |
| 3 (hàng ẩn) | Tháng 2 | 40 | 60 |
| 4 | Tháng 3 | 20 | 50 |

Truy cập các ô nguồn thông qua [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) và đọc [IChartDataCell.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) để kiểm tra trạng thái ẩn của chúng. Phương pháp này báo cáo trạng thái ẩn mà không thay đổi nó. Trong tệp này, B2 hiển thị, B3 thuộc hàng ẩn, và C2 thuộc cột ẩn; ví dụ in ra `false`, `true`, và `true` tương ứng.

Đối với ví dụ này, làm mới dữ liệu biểu đồ sau khi thay đổi cài đặt vẽ: giữ lại sổ làm việc nhúng bằng [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) và tải lại bằng [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---). Khi bao gồm tất cả các ô, cũng sử dụng [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) để khôi phục phạm vi đầy đủ, bao gồm danh mục tháng 2 ẩn. Chỉ thay đổi cờ không đủ để làm mới dữ liệu biểu đồ và nhãn danh mục đã được lưu trong bộ nhớ đệm của mẫu này.

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

            // Làm mới dữ liệu biểu đồ từ sổ làm việc nhúng.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Khôi phục toàn bộ phạm vi nguồn, bao gồm các danh mục ẩn.
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

Ví dụ lưu hai phiên bản của bản trình chiếu: một chỉ có các giá trị Bán lẻ hiển thị (10 và 20), và một khác có tất cả sáu giá trị. Các hình ảnh dưới đây minh họa hai chế độ vẽ. Hàng 3 và cột C vẫn ẩn trong cả hai sổ làm việc nhúng.

| Chỉ các ô hiển thị (`true`) | Tất cả các ô (`false`) |
| --- | --- |
| ![Chỉ các ô hiển thị: Giá trị Bán lẻ 10 và 20 cho Tháng 1 và Tháng 3.](hidden_cells_True.png) | ![Tất cả các ô: Giá trị Bán lẻ và Bán buôn cho Tháng 1, Tháng 2 và Tháng 3.](hidden_cells_False.png) |

Một ô ẩn chứa giá trị khác với một ô trống. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) kiểm soát cách hiển thị các giá trị thiếu; nó không bao gồm hoặc loại trừ dữ liệu nguồn ẩn. Xem [Kiểm soát hiển thị các ô trống](/slides/vi/androidjava/chart-series/#control-the-display-of-empty-cells) để biết ví dụ.

## **Lấy phạm vi dữ liệu của biểu đồ**

Trước khi cập nhật dữ liệu sổ làm việc trong một bản trình chiếu hiện có, kiểm tra các phạm vi nguồn để xác định các ô bảng tính mà mỗi biểu đồ sử dụng. Phương thức [IChartData.getRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getRange--) trả về phạm vi dữ liệu hiện tại dưới dạng công thức có định danh bảng tính, chẳng hạn `Sheet1!$A$1:$D$5`. Ở đây, `Sheet1` là tên bảng tính, `!` ngăn cách nó với phạm vi ô, và `$A$1:$D$5` xác định các ô từ A1 đến D5, bao gồm cả hai. Dấu `$` chỉ tham chiếu tuyệt đối cho hàng và cột.

Phương thức này đọc phạm vi hiện tại mà không thay đổi biểu đồ hoặc sổ làm việc của nó. Nếu biểu đồ không sử dụng sổ làm việc làm nguồn dữ liệu, nó sẽ ném ra `InvalidOperationException`. Để biết thêm thông tin, xem [Tham chiếu API ChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/).

Ví dụ này mở một bản trình chiếu và kiểm tra các hình dạng trực tiếp trên mỗi slide để tìm biểu đồ. Nó in ra tên và phạm vi nguồn của mỗi biểu đồ. Nếu một biểu đồ không sử dụng sổ làm việc, nó in thông báo và tiếp tục với biểu đồ tiếp theo.

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

## **Đọc và ghi dữ liệu biểu đồ từ sổ làm việc**

Aspose.Slides cho Android thông qua Java cung cấp các phương pháp [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) và [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) cho phép bạn đọc và ghi sổ làm việc dữ liệu biểu đồ (chứa dữ liệu biểu đồ đã được chỉnh sửa bằng Aspose.Cells). **Note** rằng dữ liệu biểu đồ phải được tổ chức theo cùng một cách hoặc phải có cấu trúc tương tự như nguồn.

Ví dụ này sử dụng một bản trình chiếu có biểu đồ làm hình dạng đầu tiên trên slide đầu tiên. Nó đọc sổ làm việc nhúng vào một mảng byte, xóa các series và categories hiện có, và ghi lại cùng sổ làm việc. Các thay đổi vẫn còn trong bộ nhớ; ví dụ không lưu bản trình chiếu.

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

### **Xác thực bố cục biểu đồ sau khi chỉnh sửa sổ làm việc**

Khi bạn thay thế sổ làm việc nhúng bằng một sổ làm việc đã chỉnh sửa, biểu đồ vẫn giữ các bộ sưu tập series và category ban đầu. Sự không khớp này có thể gây lỗi cho [IChart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#validateChartLayout--) với lỗi chỉ mục ngoài phạm vi. Xóa các series và categories hiện có trước khi ghi lại sổ làm việc đã cập nhật vào biểu đồ. Ví dụ này sử dụng một biểu đồ là hình dạng đầu tiên trên slide đầu tiên. Vòng chú thích đánh dấu nơi việc chỉnh sửa sổ làm việc sẽ diễn ra; ví dụ có thể chạy sẽ ghi lại sổ làm việc gốc và xác thực bố cục trong bộ nhớ.

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

        // Sửa đổi các byte của sổ làm việc ở đây, ví dụ, bằng cách sử dụng Aspose.Cells.

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

Xóa các bộ sưu tập loại bỏ các tham chiếu dữ liệu cũ trước khi sổ làm việc được ghi lại. Hãy xây dựng lại bất kỳ series và ánh xạ category nào cần thiết cho sổ làm việc đã cập nhật trước khi sử dụng biểu đồ.

## **Đặt ô sổ làm việc làm nhãn dữ liệu biểu đồ**

Bạn có thể sử dụng văn bản từ các ô sổ làm việc làm nhãn dữ liệu cho biểu đồ.

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

## **Quản lý các bảng tính**

Phương thức [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) cung cấp quyền truy cập vào các bảng tính trong một sổ làm việc biểu đồ. Ví dụ này tạo một biểu đồ tròn với dữ liệu mặc định và in tên mỗi bảng tính ra console.

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

## **Xác định kiểu nguồn dữ liệu**

Ví dụ này tạo một biểu đồ cột 3D với dữ liệu mặc định và đặt hai tên series bằng các nguồn dữ liệu khác nhau. Tên đầu tiên sử dụng một chuỗi literal; tên thứ hai sử dụng ô C1 trên bảng tính 0. Phân loại [DataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/) chọn nguồn cho mỗi tên. Ví dụ lưu bản trình chiếu với các tên series đã được cập nhật.

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

## **Phát hiện các định dạng sổ làm việc nhúng không hỗ trợ**

Aspose.Slides không hỗ trợ định dạng sổ làm việc nhị phân Excel (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể sử dụng phương thức [getEmbeddedWorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) trên [IChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/) kết hợp với phân loại [WorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/workbooktype/) để phát hiện các định dạng không hỗ trợ và bỏ qua các biểu đồ đó. Ví dụ này kiểm tra các hình dạng trên slide đầu tiên của một bản trình chiếu hiện có, bỏ qua các hình dạng không phải biểu đồ, và in thông báo chẩn đoán cho mỗi biểu đồ có sổ làm việc .xlsb nhúng.

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

        // Đọc hoặc sửa đổi dữ liệu sổ làm việc biểu đồ được hỗ trợ tại đây.
    }
} finally {
    presentation.dispose();
}
```

## **Sổ làm việc bên ngoài**

Aspose.Slides hỗ trợ sử dụng sổ làm việc bên ngoài làm nguồn dữ liệu cho biểu đồ.

### **Tạo sổ làm việc bên ngoài**

Sử dụng [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) và [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) để xuất sổ làm việc biểu đồ nhúng ra file và liên kết biểu đồ với sổ làm việc bên ngoài đó.

Ví dụ này tạo một biểu đồ tròn với dữ liệu mặc định và xuất sổ làm việc của nó. Nó hoàn thành việc ghi file trước khi gán sổ làm việc bên ngoài làm nguồn dữ liệu cho biểu đồ, sau đó lưu bản trình chiếu đã liên kết.

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

### **Đặt sổ làm việc bên ngoài**

Bằng cách sử dụng phương thức [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-), bạn có thể gán một sổ làm việc bên ngoài cho một biểu đồ làm nguồn dữ liệu. Phương thức này cũng có thể được dùng để cập nhật đường dẫn tới sổ làm việc bên ngoài (nếu sổ đó đã được di chuyển).

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các sổ làm việc được lưu trữ ở vị trí từ xa hoặc tài nguyên, bạn vẫn có thể sử dụng chúng làm nguồn dữ liệu bên ngoài. Nếu đường dẫn tương đối cho sổ làm việc bên ngoài được cung cấp, nó sẽ tự động được chuyển thành đường dẫn đầy đủ.

Ví dụ này sử dụng một sổ làm việc bên ngoài có bảng tính tên `Sheet1` chứa một tên series ở B1, tên danh mục trong A2:A4, và các giá trị số trong B2:B4. Ví dụ tạo một biểu đồ tròn, liên kết sổ làm việc, và sử dụng [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) để ánh xạ A1:B4 thành một series và ba danh mục. Nó lưu bản trình chiếu với biểu đồ đã liên kết.

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

Tham số `updateChartData` của [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) điều khiển việc tải sổ làm việc.

* Khi `updateChartData` là `false`, chỉ có đường dẫn sổ làm việc được cập nhật. Dữ liệu biểu đồ không được tải hoặc cập nhật từ sổ làm việc mục tiêu, do đó sổ làm việc có thể không khả dụng.
* Khi `updateChartData` là `true`, dữ liệu biểu đồ được cập nhật từ sổ làm việc mục tiêu.

Ví dụ sau gán một URL placeholder với `updateChartData` đặt thành `false`. Nó giữ dữ liệu mặc định của biểu đồ tròn và lưu bản trình chiếu mà không tải sổ làm việc không khả dụng.

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

### **Lấy đường dẫn sổ làm việc nguồn dữ liệu bên ngoài của biểu đồ**

Để xác định sổ làm việc được liên kết với một biểu đồ, kiểm tra xem biểu đồ có sử dụng nguồn dữ liệu bên ngoài hay không và lấy đường dẫn sổ làm việc của nó.

Ví dụ này kiểm tra hình dạng đầu tiên trên slide đầu tiên của một bản trình chiếu có sổ làm việc bên ngoài đã liên kết. Nếu đó là một biểu đồ được liên kết với sổ làm việc bên ngoài, ví dụ sẽ in [getExternalWorkbookPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) ra console. Sau đó nó lưu một bản sao của bản trình chiếu.

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

Bạn có thể chỉnh sửa dữ liệu trong các sổ làm việc bên ngoài tương tự như cách bạn thay đổi nội dung của các sổ làm việc nội bộ. Khi một sổ làm việc bên ngoài không thể tải, một ngoại lệ sẽ được ném ra.

Ví dụ này sử dụng một biểu đồ là hình dạng đầu tiên trên slide đầu tiên và được liên kết với một sổ làm việc bên ngoài có thể truy cập. Nó đặt giá trị dựa trên ô của điểm dữ liệu đầu tiên trong series đầu tiên thành 100 và lưu bản trình chiếu đã cập nhật. Việc chỉnh sửa giá trị ô có thể cập nhật tệp XLSX bên ngoài đã liên kết, vì vậy hãy sử dụng bản sao nếu bạn cần bảo tồn sổ làm việc gốc.

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

### **Khôi phục sổ làm việc từ bộ nhớ đệm biểu đồ**

Nếu một biểu đồ sử dụng sổ làm việc bên ngoài mà không có hoặc không khả dụng, Aspose.Slides có thể tái tạo sổ làm việc biểu đồ từ dữ liệu đã được lưu trong bộ nhớ đệm của bản trình chiếu. Tạo [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/), gọi [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), và đặt [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) thành `true` trước khi mở bản trình chiếu.

Ví dụ Java sau khôi phục dữ liệu sổ làm việc cho một biểu đồ là hình dạng đầu tiên trên slide đầu tiên và tham chiếu một sổ làm việc bên ngoài không khả dụng. Nó truy cập dữ liệu đã khôi phục qua [IChart.getChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getChartData--) và [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

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

        // Đọc hoặc sửa đổi dữ liệu sổ làm việc đã khôi phục ở đây.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Nếu sổ làm việc bên ngoài không khả dụng và chế độ khôi phục bị tắt, Aspose.Slides sẽ ném ra một ngoại lệ. Chỉ bật khôi phục khi việc sử dụng dữ liệu biểu đồ đã lưu trong bộ nhớ đệm là một phương án chấp nhận được, vì bộ nhớ đệm có thể không chứa các thay đổi đã được thực hiện trên sổ làm việc bên ngoài sau lần cập nhật cuối cùng của bản trình chiếu.

## **Câu hỏi thường gặp**

**Tôi có thể xác định liệu một biểu đồ cụ thể có được liên kết với sổ làm việc bên ngoài hay sổ làm việc nhúng không?**

Có. Một biểu đồ có [data source type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) và một [path to an external workbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); nếu nguồn là sổ làm việc bên ngoài, bạn có thể đọc đường dẫn đầy đủ để chắc chắn rằng một tệp bên ngoài đang được sử dụng.

**Các đường dẫn tương đối tới sổ làm việc bên ngoài có được hỗ trợ không, và chúng được lưu như thế nào?**

Có. Nếu bạn chỉ định một đường dẫn tương đối, nó sẽ tự động được chuyển thành đường dẫn tuyệt đối. Bản trình chiếu lưu đường dẫn tuyệt đối trong tệp PPTX, vì vậy việc di chuyển sổ làm việc có thể yêu cầu cập nhật liên kết.

**Tôi có thể sử dụng sổ làm việc nằm trên các tài nguyên/mạng chia sẻ không?**

Có, các sổ làm việc như vậy có thể được sử dụng làm nguồn dữ liệu bên ngoài. Tuy nhiên, việc chỉnh sửa trực tiếp các sổ làm việc từ xa bằng Aspose.Slides không được hỗ trợ — chúng chỉ có thể được dùng làm nguồn.

**Aspose.Slides có ghi đè lên tệp XLSX bên ngoài khi lưu bản trình chiếu không?**

Bản trình chiếu lưu một [link to the external file](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--). Việc chỉnh sửa dữ liệu biểu đồ dựa trên ô cũng có thể cập nhật tệp XLSX cục bộ đã liên kết. Hãy sử dụng bản sao của sổ làm việc nếu bản gốc phải được giữ nguyên.

**Nếu tệp bên ngoài được bảo mật bằng mật khẩu, tôi nên làm gì?**

Aspose.Slides không chấp nhận mật khẩu khi liên kết. Một cách thường dùng là gỡ bảo mật trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, bằng [Aspose.Cells](https://reference.aspose.com/cells/java/)) và liên kết tới bản sao đó.

**Nhiều biểu đồ có thể tham chiếu cùng một sổ làm việc bên ngoài không?**

Có. Mỗi biểu đồ lưu liên kết riêng của mình. Nếu tất cả đều trỏ tới cùng một tệp, việc cập nhật tệp đó sẽ được phản ánh trong mỗi biểu đồ lần tiếp theo khi dữ liệu được tải.