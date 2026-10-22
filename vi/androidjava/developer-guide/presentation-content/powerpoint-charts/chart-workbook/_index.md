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
description: "Khám phá Aspose.Slides cho Android qua Java: quản lý sổ làm việc biểu đồ trong các định dạng PowerPoint và OpenDocument một cách dễ dàng để tối ưu hoá dữ liệu bản trình chiếu của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với sổ làm việc biểu đồ trong Aspose.Slides. Nó cho thấy cách đọc và ghi dữ liệu biểu đồ thông qua các luồng sổ làm việc, sử dụng các ô sổ làm việc làm nhãn dữ liệu biểu đồ, truy cập các bộ sưu tập bảng tính, và chỉ định loại nguồn dữ liệu cho các giá trị biểu đồ.

Nó cũng đề cập đến việc làm việc với sổ làm việc bên ngoài làm nguồn dữ liệu cho biểu đồ. Các ví dụ minh họa cách tạo và gán một sổ làm việc bên ngoài, lấy đường dẫn của sổ làm việc bên ngoài được liên kết với biểu đồ, và chỉnh sửa dữ liệu biểu đồ khi sổ làm việc có sẵn.

Đối với các ô sổ làm việc đại diện cho dữ liệu thiếu, xem [Kiểm soát hiển thị các ô trống](/slides/vi/androidjava/chart-series/) để biết sự khác biệt giữa ô trống và số 0, và so sánh biểu đồ đường của các chế độ hiển thị có sẵn.

## **Bao gồm dữ liệu từ các hàng và cột ẩn**

Sử dụng [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) để kiểm soát việc biểu đồ chỉ vẽ dữ liệu từ các hàng và cột bảng tính hiển thị. Đặt thành `true` để chỉ vẽ các ô hiển thị, hoặc `false` để bao gồm cả các ô hiển thị và ẩn. Cài đặt này chỉ điều khiển việc vẽ biểu đồ; nó không ẩn hay hiện các hàng hoặc cột bảng tính.

[Ví dụ bản trình chiếu mẫu](hidden-source-data.pptx) chứa một biểu đồ cột là hình dạng đầu tiên trên slide đầu tiên. Bảng tính nhúng, `Sheet1`, chứa phạm vi nguồn sau, `A1:C4`. Hàng 3 và cột C bị ẩn, nhưng các ô của chúng vẫn chứa giá trị.

| Hàng bảng tính | A: Tháng | B: Bán lẻ | C: Bán buôn (cột ẩn) |
| --- | --- | --- | --- |
| 2 | Tháng 1 | 10 | 30 |
| 3 (hàng ẩn) | Tháng 2 | 40 | 60 |
| 4 | Tháng 3 | 20 | 50 |

Truy cập các ô nguồn thông qua [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) và đọc [IChartDataCell.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) để kiểm tra trạng thái ẩn của chúng. Phương pháp này chỉ báo cáo trạng thái ẩn mà không thay đổi nó. Trong tệp này, B2 hiển thị, B3 thuộc hàng ẩn, và C2 thuộc cột ẩn; ví dụ in ra `false`, `true`, và `true` tương ứng.

Đối với ví dụ này, làm mới dữ liệu biểu đồ sau khi thay đổi cài đặt vẽ: giữ lại sổ làm việc nhúng bằng [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) và tải lại bằng [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---). Khi bao gồm tất cả các ô, cũng sử dụng [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) để khôi phục lại phạm vi đầy đủ, bao gồm danh mục tháng 2 ẩn. Chỉ thay đổi cờ không đủ để làm mới dữ liệu biểu đồ và nhãn danh mục đã được lưu trong bộ nhớ đệm của mẫu này.

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

Ví dụ lưu hai phiên bản của bản trình chiếu: một chỉ bao gồm các giá trị Bán lẻ hiển thị (`10` và `20`), và một khác bao gồm tất cả sáu giá trị. Các hình ảnh dưới đây minh họa hai chế độ vẽ. Hàng 3 và cột C vẫn ẩn trong cả hai sổ làm việc nhúng.

| Chỉ các ô hiển thị (`true`) | Tất cả các ô (`false`) |
| --- | --- |
| ![Chỉ các ô hiển thị: Giá trị Bán lẻ 10 và 20 cho Tháng 1 và Tháng 3.](hidden_cells_True.png) | ![Tất cả các ô: Giá trị Bán lẻ và Bán buôn cho Tháng 1, Tháng 2 và Tháng 3.](hidden_cells_False.png) |

Một ô ẩn chứa giá trị khác với một ô trống. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) kiểm soát cách hiển thị các giá trị thiếu; nó không bao gồm hay loại bỏ dữ liệu nguồn ẩn. Xem [Kiểm soát hiển thị các ô trống](/slides/vi/androidjava/chart-series/#control-the-display-of-empty-cells) để biết ví dụ.

## **Lấy phạm vi dữ liệu của biểu đồ**

Trước khi cập nhật dữ liệu sổ làm việc trong một bản trình chiếu hiện có, kiểm tra các phạm vi nguồn để xác định các ô bảng tính mà mỗi biểu đồ sử dụng. Phương pháp [IChartData.getRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getRange--) trả về phạm vi dữ liệu hiện tại dưới dạng công thức đủ điều kiện bảng tính, chẳng hạn `Sheet1!$A$1:$D$5`. Ở đây, `Sheet1` là tên bảng tính, `!` ngăn cách nó với phạm vi ô, và `$A$1:$D$5` xác định các ô từ A1 đến D5, bao gồm. Dấu `$` chỉ tham chiếu tuyệt đối cho hàng và cột.

Phương pháp này đọc phạm vi hiện tại mà không thay đổi biểu đồ hoặc sổ làm việc của nó. Nếu biểu đồ không sử dụng sổ làm việc làm nguồn dữ liệu, nó sẽ ném ra `InvalidOperationException`. Để biết thêm thông tin, xem [Tham chiếu API ChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/).

Ví dụ này mở một bản trình chiếu và kiểm tra các hình dạng trực tiếp trên mỗi slide để tìm biểu đồ. Nó in ra tên và phạm vi nguồn của từng biểu đồ. Nếu một biểu đồ không sử dụng sổ làm việc, nó in thông báo và tiếp tục với biểu đồ tiếp theo.

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

Aspose.Slides for Android via Java cung cấp các phương pháp [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) và [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) cho phép bạn đọc và ghi sổ làm việc dữ liệu biểu đồ (chứa dữ liệu biểu đồ đã được chỉnh sửa bằng Aspose.Cells). **Lưu ý** rằng dữ liệu biểu đồ phải được tổ chức theo cùng một cách hoặc phải có cấu trúc tương tự nguồn.

Ví dụ này sử dụng một bản trình chiếu có biểu đồ là hình dạng đầu tiên trên slide đầu tiên. Nó đọc sổ làm việc nhúng vào một mảng byte, xóa các chuỗi và danh mục hiện có, và ghi lại cùng một sổ làm việc. Các thay đổi vẫn tồn tại trong bộ nhớ; ví dụ không lưu bản trình chiếu.

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

Khi bạn thay thế một sổ làm việc nhúng bằng một sổ làm việc đã chỉnh sửa, biểu đồ vẫn giữ các bộ sưu tập chuỗi và danh mục gốc. Sự không khớp này có thể khiến [IChart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#validateChartLayout--) thất bại với lỗi chỉ mục ngoài phạm vi. Xóa các chuỗi và danh mục hiện có trước khi ghi sổ làm việc đã cập nhật lại vào biểu đồ. Ví dụ này sử dụng một biểu đồ là hình dạng đầu tiên trên slide đầu tiên. Đoạn chú thích đánh dấu nơi sẽ thực hiện việc chỉnh sửa sổ làm việc; ví dụ thực thi viết lại sổ làm việc gốc và xác thực bố cục trong bộ nhớ.

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

        // Sửa đổi các byte của sổ làm việc ở đây, ví dụ, sử dụng Aspose.Cells.

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

Xóa các bộ sưu tập loại bỏ các tham chiếu dữ liệu cũ trước khi sổ làm việc được ghi lại. Xây dựng lại bất kỳ chuỗi và ánh xạ danh mục nào cần thiết cho sổ làm việc đã cập nhật trước khi sử dụng biểu đồ.

## **Đặt định dạng số tùy chỉnh cho các ô sổ làm việc**

Sử dụng [IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) để kiểm soát cách các giá trị số xuất hiện trong sổ làm việc nhúng của biểu đồ. Ví dụ, một báo cáo có thể cần tỷ lệ chuyển đổi hiển thị dưới dạng phần trăm với bốn chữ số thập phân và một hệ số hiển thị với năm chữ số thập phân. Giữ cả hai giá trị ở dạng số để chúng vẫn có thể được sử dụng cho các phép tính và vẽ biểu đồ.

Định dạng số thay đổi cách hiển thị, không phải giá trị lưu trữ. Định dạng `0.0000%` hiển thị `0.125` thành `12.5000%`; nó không thay thế số lưu trữ bằng `12.5`. Tương tự, `0.00000` hiển thị `0.1234567` thành `0.12346` mà không làm tròn giá trị lưu trữ. Nếu định dạng tùy chỉnh là chuỗi rỗng (`""`), định dạng được trả về bởi [getPresetNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--) sẽ được sử dụng thay thế.

Ví dụ sau tạo một biểu đồ cột và truy cập các ô của nó qua [getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--). Trên bảng tính 0, B2 chứa tỷ lệ chuyển đổi và C2 chứa hệ số. Cả hai ô đều cung cấp giá trị cho biểu đồ. Ví dụ cũng bật nhãn giá trị được liên kết với định dạng nguồn.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 270, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 20, 620, 210);
    chart.setTitle(false);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00");
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(0);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell categoryCell = workbook.getCell(0, "A2", "Sample");
    chart.getChartData().getCategories().add(categoryCell);

    IChartDataCell percentageCell = workbook.getCell(0, "B2", 0.125);
    percentageCell.setCustomNumberFormat("0.0000%");
    IChartDataCell percentageName = workbook.getCell(0, "B1", "Conversion rate");
    IChartSeries percentageSeries = chart.getChartData().getSeries().add(percentageName, chart.getType());
    percentageSeries.getDataPoints().addDataPointForBarSeries(percentageCell);

    IChartDataCell precisionCell = workbook.getCell(0, "C2", 0.1234567);
    precisionCell.setCustomNumberFormat("0.00000");
    IChartDataCell precisionName = workbook.getCell(0, "C1", "Coefficient");
    IChartSeries precisionSeries = chart.getChartData().getSeries().add(precisionName, chart.getType());
    precisionSeries.getDataPoints().addDataPointForBarSeries(precisionCell);

    for (IChartSeries series : chart.getChartData().getSeries()) {
        IDataLabelFormat labelFormat = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(true);
    }

    presentation.save("CustomCellFormats.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Định dạng ô sổ làm việc tách biệt khỏi các định dạng được đặt trực tiếp trên trục biểu đồ hoặc nhãn dữ liệu. Trong ví dụ này, mỗi nhãn hiển thị giá trị ô nguồn vì [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) được đặt thành `true`, và tuân theo định dạng số nguồn vì [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) cũng được đặt thành `true`. Sau khi lưu và mở lại bản trình chiếu, các nhãn hiển thị `12.5000%` và `0.12346`, như hình dưới. Trục dọc sử dụng định dạng số riêng, được gán bằng [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) là `0.00`, với [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) đặt thành `false`.

Để định dạng một nhãn dữ liệu một cách độc lập, đặt cờ liên kết nguồn của nó thành `false` và gán định dạng bằng [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-). Điều này không thay đổi định dạng của ô sổ làm việc. Ví dụ, một định dạng nhãn độc lập `0.00` sẽ hiển thị giá trị đầu tiên thành `0.13`, trong khi B2 vẫn hiển thị `12.5000%`. Xem [Nhãn dữ liệu biểu đồ](/slides/vi/androidjava/chart-data-label/#set-the-percentage-sign-with-chart-data-labels) để định dạng nhãn trực tiếp.

Hình ảnh dưới đây được tạo từ bản trình chiếu đã lưu sau khi mở lại:

![Biểu đồ cột với nhãn liên kết nguồn hiển thị 12.5000% và 0.12346 và trục số được định dạng độc lập.](custom-cell-formats.png)

## **Đặt một ô sổ làm việc làm nhãn dữ liệu biểu đồ**

Bạn có thể sử dụng văn bản từ các ô sổ làm việc làm nhãn dữ liệu biểu đồ.

Ví dụ này thêm một biểu đồ bong bóng với dữ liệu mặc định vào slide đầu tiên của một bản trình chiếu hiện có. Nó sử dụng các ô A10:A12 trên bảng tính 0 cho ba nhãn đầu tiên của chuỗi đầu tiên, bật nhãn từ ô, và lưu bản trình chiếu đã cập nhật.

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

## **Quản lý bảng tính**

Phương pháp [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) cung cấp quyền truy cập vào các bảng tính trong một sổ làm việc biểu đồ. Ví dụ này tạo một biểu đồ tròn với dữ liệu mặc định và in tên mỗi bảng tính ra console.

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

## **Chỉ định loại nguồn dữ liệu**

Giá trị điểm chuỗi cũng có thể được lưu trữ trực tiếp dưới dạng số nguyên. Xem [Đặt giá trị chuỗi bằng số nguyên](/slides/vi/androidjava/chart-series/#set-series-values-using-numeric-literals) để biết ví dụ đầy đủ về việc lưu và đọc chúng. Loại nguồn của các giá trị điểm tách biệt khỏi cấu hình sổ làm việc nội bộ hoặc bên ngoài của biểu đồ; việc sử dụng số nguyên không tự động loại bỏ sổ làm việc nhúng.

Ví dụ này tạo một biểu đồ cột 3D với dữ liệu mặc định và đặt hai tên chuỗi bằng các nguồn dữ liệu khác nhau. Tên đầu tiên sử dụng chuỗi nguyên thuỷ; tên thứ hai sử dụng ô C1 trên bảng tính 0. Kiểu liệt kê [DataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/) chọn nguồn cho mỗi tên. Ví dụ lưu bản trình chiếu với các tên chuỗi đã cập nhật.

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

## **Phát hiện định dạng sổ làm việc nhúng không được hỗ trợ**

Aspose.Slides không hỗ trợ định dạng sổ làm việc nhị phân Excel (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể sử dụng phương pháp [getEmbeddedWorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) trên [IChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/) cùng với kiểu liệt kê [WorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/workbooktype/) để phát hiện các định dạng không được hỗ trợ và bỏ qua các biểu đồ đó. Ví dụ này kiểm tra các hình dạng trên slide đầu tiên của một bản trình chiếu hiện có, bỏ qua các hình dạng không phải biểu đồ, và in thông báo chẩn đoán cho mỗi biểu đồ có sổ làm việc .xlsb nhúng.

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

        // Đọc hoặc chỉnh sửa dữ liệu sổ làm việc biểu đồ được hỗ trợ ở đây.
    }
} finally {
    presentation.dispose();
}
```

## **Sổ làm việc bên ngoài**

Aspose.Slides hỗ trợ sử dụng sổ làm việc bên ngoài làm nguồn dữ liệu cho biểu đồ.

### **Tạo một sổ làm việc bên ngoài**

Sử dụng [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) và [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) để xuất sổ làm việc biểu đồ nhúng ra tệp và liên kết biểu đồ với sổ làm việc bên ngoài đó.

Ví dụ này tạo một biểu đồ tròn với dữ liệu mặc định và xuất sổ làm việc của nó. Nó hoàn thành việc ghi tệp trước khi gán sổ làm việc bên ngoài làm nguồn dữ liệu biểu đồ, sau đó lưu bản trình chiếu đã liên kết.

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

### **Đặt một sổ làm việc bên ngoài**

Bằng cách sử dụng phương pháp [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-), bạn có thể gán một sổ làm việc bên ngoài cho biểu đồ làm nguồn dữ liệu. Phương pháp này cũng có thể được dùng để cập nhật đường dẫn tới sổ làm việc bên ngoài (nếu nó đã được di chuyển).

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các sổ làm việc được lưu trữ ở vị trí từ xa hoặc tài nguyên, bạn vẫn có thể sử dụng các sổ làm việc đó làm nguồn dữ liệu bên ngoài. Nếu cung cấp đường dẫn tương đối cho một sổ làm việc bên ngoài, nó sẽ tự động được chuyển sang đường dẫn đầy đủ.

Ví dụ này sử dụng một sổ làm việc bên ngoài mà bảng tính có tên `Sheet1` chứa tên chuỗi ở B1, tên danh mục ở A2:A4, và các giá trị số ở B2:B4. Ví dụ tạo một biểu đồ tròn, liên kết sổ làm việc, và sử dụng [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) để ánh xạ A1:B4 thành một chuỗi và ba danh mục. Nó lưu bản trình chiếu với biểu đồ đã liên kết.

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

Tham số `updateChartData` của [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) kiểm soát việc tải sổ làm việc hay không.

* Khi `updateChartData` là `false`, chỉ có đường dẫn sổ làm việc được cập nhật. Dữ liệu biểu đồ không được tải hoặc cập nhật từ sổ làm việc mục tiêu, vì vậy sổ làm việc có thể không tồn tại.
* Khi `updateChartData` là `true`, dữ liệu biểu đồ được cập nhật từ sổ làm việc mục tiêu.

Ví dụ sau gán một URL giữ chỗ với `updateChartData` được đặt thành `false`. Nó giữ nguyên dữ liệu mặc định của biểu đồ tròn và lưu bản trình chiếu mà không tải sổ làm việc không khả dụng.

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

### **Lấy đường dẫn sổ làm việc nguồn dữ liệu bên ngoài của một biểu đồ**

Để xác định sổ làm việc được liên kết với một biểu đồ, kiểm tra xem biểu đồ có sử dụng nguồn dữ liệu bên ngoài hay không và lấy đường dẫn sổ làm việc của nó.

Ví dụ này kiểm tra hình dạng đầu tiên trên slide đầu tiên của một bản trình chiếu có sổ làm việc bên ngoài được liên kết. Nếu đó là một biểu đồ được liên kết với sổ làm việc bên ngoài, ví dụ sẽ in [getExternalWorkbookPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) ra console. Sau đó nó lưu một bản sao của bản trình chiếu.

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

Bạn có thể chỉnh sửa dữ liệu trong sổ làm việc bên ngoài giống như cách bạn thay đổi nội dung của sổ làm việc nội bộ. Khi một sổ làm việc bên ngoài không thể tải, một ngoại lệ sẽ được ném.

Ví dụ này sử dụng một biểu đồ là hình dạng đầu tiên trên slide đầu tiên và được liên kết với một sổ làm việc bên ngoài có thể truy cập. Nó đặt giá trị dựa trên ô của điểm dữ liệu đầu tiên trong chuỗi đầu tiên thành 100 và lưu bản trình chiếu đã cập nhật. Việc chỉnh sửa giá trị ô có thể cập nhật tệp XLSX bên ngoài đã liên kết, vì vậy hãy sao chép nếu bạn cần giữ nguyên sổ làm việc gốc.

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

### **Khôi phục sổ làm việc từ bộ nhớ đệm của biểu đồ**

Nếu một biểu đồ sử dụng sổ làm việc bên ngoài mà thiếu hoặc không khả dụng, Aspose.Slides có thể tái tạo sổ làm việc biểu đồ từ dữ liệu đã được lưu trong bộ nhớ đệm của bản trình chiếu. Tạo [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/), gọi [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), và đặt [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) thành `true` trước khi mở bản trình chiếu.

Ví dụ Java sau khôi phục dữ liệu sổ làm việc cho một biểu đồ là hình dạng đầu tiên trên slide đầu tiên và tham chiếu tới một sổ làm việc bên ngoài không khả dụng. Nó truy cập dữ liệu đã khôi phục qua [IChart.getChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getChartData--) và [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

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

        // Đọc hoặc chỉnh sửa dữ liệu sổ làm việc đã khôi phục ở đây.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Nếu sổ làm việc bên ngoài không khả dụng và việc khôi phục bị tắt, Aspose.Slides sẽ ném ra một ngoại lệ. Chỉ bật tính năng khôi phục khi việc sử dụng dữ liệu biểu đồ đã được lưu trong bộ nhớ đệm là một phương án chấp nhận được, vì bộ nhớ đệm có thể không chứa các thay đổi đã thực hiện trên sổ làm việc bên ngoài sau lần cập nhật cuối cùng của bản trình chiếu.

## **Câu hỏi thường gặp**

**Tôi có thể xác định liệu một biểu đồ cụ thể có liên kết tới sổ làm việc bên ngoài hay sổ làm việc nhúng không?**

Có. Một biểu đồ có [loại nguồn dữ liệu](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) và một [đường dẫn tới sổ làm việc bên ngoài](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); nếu nguồn là sổ làm việc bên ngoài, bạn có thể đọc đường dẫn đầy đủ để chắc chắn rằng một tệp bên ngoài đang được sử dụng.

**Các đường dẫn tương đối tới sổ làm việc bên ngoài có được hỗ trợ không, và chúng được lưu như thế nào?**

Có. Nếu bạn chỉ định một đường dẫn tương đối, nó sẽ tự động được chuyển sang đường dẫn tuyệt đối. Bản trình chiếu lưu đường dẫn tuyệt đối trong tệp PPTX, vì vậy việc di chuyển sổ làm việc có thể yêu cầu cập nhật liên kết.

**Tôi có thể sử dụng sổ làm việc nằm trên tài nguyên/mạng chia sẻ không?**

Có, những sổ làm việc như vậy có thể được sử dụng làm nguồn dữ liệu bên ngoài. Tuy nhiên, việc chỉnh sửa trực tiếp các sổ làm việc từ xa bằng Aspose.Slides không được hỗ trợ — chúng chỉ có thể được dùng làm nguồn.

**Aspose.Slides có ghi đè lên tệp XLSX bên ngoài khi lưu bản trình chiếu không?**

Bản trình chiếu lưu một [liên kết tới tệp bên ngoài](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--). Việc chỉnh sửa dữ liệu biểu đồ dựa trên ô cũng có thể cập nhật tệp XLSX cục bộ đã liên kết. Hãy sử dụng một bản sao của sổ làm việc nếu bản gốc phải được bảo toàn nguyên trạng.

**Nếu tệp bên ngoài được bảo vệ bằng mật khẩu thì tôi phải làm gì?**

Aspose.Slides không chấp nhận mật khẩu khi liên kết. Một cách tiếp cận phổ biến là bỏ bảo vệ trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, bằng [Aspose.Cells](https://reference.aspose.com/cells/java/)) và liên kết tới bản sao đó.

**Nhiều biểu đồ có thể tham chiếu cùng một sổ làm việc bên ngoài không?**

Có. Mỗi biểu đồ lưu liên kết riêng của mình. Nếu tất cả chúng trỏ tới cùng một tệp, việc cập nhật tệp sẽ được phản ánh trong mỗi biểu đồ vào lần tiếp theo dữ liệu được tải.