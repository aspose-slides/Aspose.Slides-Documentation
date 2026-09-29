---
title: Quản lý chuỗi dữ liệu biểu đồ trong bản trình bày bằng JavaScript
linktitle: Chuỗi dữ liệu
type: docs
url: /vi/nodejs-java/chart-series/
keywords:
- chuỗi biểu đồ
- độ chồng lấn của chuỗi
- màu chuỗi
- tên chuỗi
- điểm dữ liệu
- ô sổ làm việc
- khoảng cách chuỗi
- giá trị âm
- PowerPoint
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách quản lý chuỗi biểu đồ, điểm dữ liệu, ô sổ làm việc, định dạng, độ chồng lấn, độ rộng khe hở và giá trị âm trong bản trình bày bằng JavaScript."
---
## **Tổng quan**

Biểu đồ lưu trữ dữ liệu đã vẽ trong một sổ dữ liệu biểu đồ. Một [ChartSeries](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartseries/) đại diện cho một tập hợp các giá trị có liên quan, và mỗi [ChartDataPoint](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdatapoint/) trong series tham chiếu tới một hoặc nhiều ô trong sổ làm việc. Các đối tượng [ChartCategory](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartcategory/) cung cấp các nhãn hoặc giá trị nhóm được chia sẻ bởi các series. Vì vậy, tên series, các danh mục và giá trị điểm được kết nối với các đối tượng [ChartDataCell](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdatacell/) thay vì chỉ được lưu dưới dạng văn bản hiển thị.

Đối với một biểu đồ danh mục thông thường, sổ làm việc mặc định sử dụng hàng 0 cho tên series, cột 0 cho tên danh mục và các ô còn lại cho giá trị series. Các chỉ mục worksheet, hàng và cột được truyền cho [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdataworkbook/#getCell) dựa trên chỉ mục 0. Bố cục này hữu ích khi bạn tạo biểu đồ với dữ liệu mặc định, nhưng đừng cho rằng mọi biểu đồ hiện có đều sử dụng nó. Đối với một bản trình bày đã tải, hãy kiểm tra các ô được tham chiếu bởi series, danh mục và các điểm dữ liệu trước khi thay đổi giá trị sổ làm việc.

Cài đặt biểu đồ có ba phạm vi khác nhau:

- Cài đặt ở mức series, chẳng hạn như [ChartSeries.getFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartseries/#getFormat), cung cấp ngoại hình mặc định cho tất cả các điểm trong một series.
- Cài đặt ở mức điểm dữ liệu, chẳng hạn như [ChartDataPoint.getFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdatapoint/#getFormat), ghi đè ngoại hình series cho một điểm.
- Cài đặt nhóm áp dụng cho các series tương thích thuộc cùng một [ChartSeriesGroup](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartseriesgroup/). Truy cập nhóm qua [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup) khi bạn cần đặt các tùy chọn như độ chồng lấn hoặc độ rộng khe hở.

Khi không có màu nền điểm hoặc series nào được đặt rõ ràng, kiểu biểu đồ và chủ đề sẽ quyết định ngoại hình tự động. Khi có cả định dạng series và điểm, định dạng điểm sẽ có ưu tiên đối với điểm đó.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Đặt Độ Chồng Lên Nhau của Series Biểu Đồ**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartseries/#getOverlap) báo cáo mức độ các thanh hoặc cột chồng lên nhau trong biểu đồ 2D, từ -100 đến 100 phần trăm. Đây là dự đoán chỉ đọc của cài đặt trên nhóm series cha. Sử dụng [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap) để cập nhật mọi series tương thích trong nhóm đó. Tùy chọn này áp dụng cho các loại biểu đồ hiển thị các thanh hoặc cột được nhóm; nó không ảnh hưởng đến các nhóm series không liên quan trong biểu đồ kết hợp.

Ví dụ sau đặt độ chồng cho nhóm chứa series đầu tiên:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const overlapPercent = java.newByte(30);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Biểu đồ mới chứa các chuỗi mẫu, danh mục và giá trị.
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![The series overlap](series_overlap.png)

## **Thay Đổi Màu Lấp Đầy của Series**

Sử dụng [ChartSeries.getFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartseries/#getFormat) để đặt màu lấp đầy mặc định cho toàn bộ series. Nếu một điểm đã có màu lấp đầy rõ ràng, cài đặt [ChartDataPoint.getFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdatapoint/#getFormat) của nó sẽ ghi đè màu lấp đầy series cho điểm đó.

Ví dụ sau áp dụng màu xanh đậm đặc cho series đầu tiên:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(blueColor);

    presentation.save("series_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![The color of the series](series_color.png)

## **Thay Đổi Tên Series**

Tên series được lưu trong sổ dữ liệu biểu đồ và thường được hiển thị trong chú giải. Trong sổ làm việc mặc định được tạo cho biểu đồ cột cụm, ô B1 nằm ở hàng 0, cột 1 và chứa tên của series đầu tiên. Các hằng số có tên trong ví dụ sau làm cho cấu trúc này trở nên rõ ràng:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const seriesNameRowIndex = 0;
const firstSeriesColumnIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const workbook = chart.getChartData().getChartDataWorkbook();
    const seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bạn cũng có thể cập nhật ô đã được [ChartSeries.getName](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartseries/#getName) tham chiếu. Cách này tránh việc giả định một hàng và cột cụ thể trong biểu đồ hiện có:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const firstNameCellIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![The series name](series_name.png)

## **Lấy Màu Lấp Đầy Tự Động của Series**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor) trả về màu được tính dựa trên chỉ mục series và kiểu biểu đồ. Đây là màu được sử dụng khi màu lấp đầy series chưa được định nghĩa rõ ràng. Gọi phương pháp này chỉ đọc màu đã tính; nó không gán màu mới.

Ví dụ sau in ra màu tự động của mỗi series mặc định:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const seriesCount = chart.getChartData().getSeries().size();
    for (let seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const automaticColor = series.getAutomaticSeriesColor();
        const automaticColorText = automaticColor.toString();
        console.log("Series " + seriesIndex + ": " + automaticColorText);
    }
} finally {
    presentation.dispose();
}
```

Đầu ra mẫu cho kiểu biểu đồ mặc định:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Màu chính xác phụ thuộc vào kiểu biểu đồ và chủ đề.

## **Đặt Màu Lấp Đầy Đảo Ngược cho Series Biểu Đồ**

Đối với series thanh, cột và bong bóng, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) có thể hiển thị các giá trị âm bằng một màu lấp đầy khác. Đặt màu lấp đầy series thường thành màu đặc, bật tính năng đảo ngược và gán màu giá trị âm qua [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Các số âm vẫn không thay đổi trong sổ làm việc; chỉ màu hiển thị thay đổi.

Ví dụ sau thay thế dữ liệu biểu đồ mặc định bằng một series. Hàng 0 của worksheet chứa tên series, cột 0 chứa tên danh mục, và cột 1 chứa các giá trị:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const headerRowIndex = 0;
const categoryColumnIndex = 0;
const firstSeriesColumnIndex = 1;
const firstDataRowIndex = 1;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const categoryNames = ["Category 1", "Category 2", "Category 3"];
const seriesValues = [-20, 50, -30];

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    const chartType = chart.getType();
    const series = chartData.getSeries().add(seriesNameCell, chartType);

    for (let categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        const dataRowIndex = firstDataRowIndex + categoryIndex;
        const categoryName = categoryNames[categoryIndex];
        const seriesValue = seriesValues[categoryIndex];

        const categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(redColor);

    presentation.save("inverted_solid_fill_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![The inverted solid fill color](inverted_solid_fill_color.png)

Bạn có thể bật đảo ngược cho một điểm thông qua [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Trong ví dụ sau, đảo ngược bị tắt cho series và chỉ bật cho điểm đã chọn. Điểm này cũng được gán một giá trị âm để hiệu ứng hiển thị:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 2;
const negativeValue = -30;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(redColor);
    series.setInvertIfNegative(false);

    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Xóa Giá Trị Điểm Dữ Liệu Cụ Thể**

Để làm cho một điểm trống mà không xóa các điểm còn lại, đặt ô sổ làm việc tương ứng của nó thành `null`. Đối với biểu đồ cột, giá trị được vẽ có thể lấy qua [ChartDataPoint.getValue](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdatapoint/#getValue). Điểm dữ liệu vẫn nằm ở cùng vị trí danh mục, nhưng biểu đồ sẽ coi giá trị của nó là trống theo cài đặt giá trị trống của biểu đồ.

Ví dụ sau chỉ xóa điểm thứ hai trong series đầu tiên:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Biểu đồ phân tán sử dụng các ô X và Y riêng biệt, và biểu đồ bong bóng còn sử dụng ô kích thước. Chỉ xóa ô đại diện cho giá trị bạn muốn loại bỏ. Đừng gọi [ChartDataPointCollection.clear](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdatapointcollection/#clear) khi muốn giữ lại các điểm khác, vì phương thức đó sẽ xóa mọi điểm dữ liệu trong collection.

## **Kiểm Soát Hiển Thị Các Ô Trống**

Các ô ẩn chứa giá trị là một trường hợp riêng biệt so với các ô trống. Để bao gồm hoặc loại bỏ dữ liệu từ các hàng và cột worksheet ẩn, xem [Include Data from Hidden Rows and Columns](/slides/vi/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Một ô workbook trống đại diện cho dữ liệu mất; một ô chứa `0` đại diện cho một giá trị số đã biết. Gọi [ChartDataCell.setValue](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdatacell/#setValue) với `null` để làm ô trống. Số không vẫn là không bất kể cài đặt ô trống.

Sử dụng [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) để chọn cách biểu đồ hiển thị các ô trống. Cài đặt này áp dụng cho toàn bộ biểu đồ. Nó thay đổi cách các khoảng trống được vẽ, mà không lấp đầy ô workbook trống bằng số 0 hoặc giá trị nội suy.

Ví dụ tự chứa sau tạo một biểu đồ đường với một series, xóa giá trị cho Ngày 3, và lưu cùng một biểu đồ với mỗi chế độ. Không cần file đầu vào. [ChartDataWorkbook](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdataworkbook/) sử dụng worksheet 0, cột 0 cho nhãn danh mục, và cột 1 cho giá trị; hàng 0 giữ tên series. Dữ liệu cuối cùng là `10, 20, empty, 30, 40`.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 40, 40, 640, 400);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    const series = chartData.getSeries().add(seriesNameCell, chart.getType());
    const values = [10, 20, 25, 30, 40];

    for (let i = 0; i < values.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Để Ngày 3 thực sự trống, trong khi vẫn giữ lại danh mục và điểm dữ liệu của nó.
    workbook.getCell(0, 3, 1).setValue(null);

    const modes = [aspose.slides.DisplayBlanksAsType.Gap, aspose.slides.DisplayBlanksAsType.Zero, aspose.slides.DisplayBlanksAsType.Span];
    const modeNames = ["Gap", "Zero", "Span"];
    for (let i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Mỗi file đầu ra lưu chế độ đã gán trước khi lưu: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, và `empty_cells_Span.pptx`. Để lưu chỉ một phiên bản, gán chế độ mong muốn và lưu bản trình bày một lần thay vì lặp qua các chế độ.

So sánh dưới đây cho thấy cùng một dữ liệu trong ba file. Ngày 3 là trống trong workbook trong mọi trường hợp:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Hiệu ứng hiển thị phụ thuộc vào loại biểu đồ. Biểu đồ đường cho phép so sánh ba chế độ dễ dàng. Biểu đồ thanh và cột không có đường nối qua danh mục thiếu, vì vậy `Span` không tạo được đoạn nối như trên; một cột thiếu và một cột có chiều cao 0 cũng có thể trông giống nhau. Tương tự, biểu đồ phân tán chỉ có các điểm đánh dấu cũng không có đường nối. Đừng mong đợi ba kết quả riêng biệt cho mọi loại biểu đồ; hãy kiểm tra đầu ra cho loại bạn sử dụng.

## **Đặt Độ Rộng Khe Hở của Series**

Độ rộng khe hở là khoảng cách giữa các cụm thanh hoặc cột liền kề, biểu diễn dưới dạng phần trăm của chiều rộng thanh hoặc cột. Giống như độ chồng, nó thuộc về nhóm series cha chứ không phải một series đơn lẻ. Gọi [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) một lần cho nhóm. Giá trị lớn hơn tạo nhiều không gian hơn giữa các cụm; giá trị nhỏ hơn làm chúng dày đặc hơn.

Ví dụ sau thay đổi độ rộng khe hở và chỉ lưu bản trình bày cuối cùng:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const gapWidthPercent = 30;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![The gap width](gap_width.png)

## **Câu hỏi thường gặp**

**Các loại biểu đồ nào hỗ trợ dữ liệu series?**

Tất cả các loại biểu đồ được biểu diễn bằng enumeration [ChartType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/charttype/) đều sử dụng dữ liệu biểu đồ, nhưng series của chúng không luôn có cùng cấu trúc giá trị hoặc cài đặt. Ví dụ, biểu đồ danh mục sử dụng danh mục và giá trị, biểu đồ phân tán sử dụng giá trị X và Y, và biểu đồ bong bóng còn thêm kích thước bong bóng. Hãy dùng phương pháp tạo điểm dữ liệu phù hợp với loại series. Các tùy chọn như độ chồng và độ rộng khe hở chỉ áp dụng cho các nhóm thanh hoặc cột tương thích.

**Series group là gì?**

Một [ChartSeriesGroup](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartseriesgroup/) chứa các series tương thích chia sẻ các cài đặt vẽ ở mức nhóm. Một biểu đồ kết hợp có thể chứa hơn một nhóm, vì vậy việc thay đổi nhóm được truy cập qua một series không nhất thiết làm thay đổi mọi series trong biểu đồ.

**Biểu đồ mới tạo có dữ liệu mặc định không?**

Có. Mặc định, [ShapeCollection.addChart](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapecollection/#addChart) tạo các series, danh mục và giá trị mẫu. Bạn có thể chỉnh sửa các ô này hoặc xóa cả hai collection series và category trước khi thêm một bộ dữ liệu tùy chỉnh hoàn toàn. Một overload cũng có thể tạo biểu đồ không có dữ liệu mặc định.

**Các đối tượng biểu đồ được kết nối với các ô workbook như thế nào?**

Tên series, nhãn danh mục và giá trị điểm dữ liệu tham chiếu đến các ô trong một [ChartDataWorkbook](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdataworkbook/). Thay đổi một ô được tham chiếu sẽ cập nhật phần tử biểu đồ tương ứng. Khi bạn xây dựng dữ liệu tùy chỉnh, hãy giữ các hàng danh mục và các hàng giá trị series đồng nhất để mỗi điểm được vẽ dưới đúng danh mục dự định.

**Làm sao để xóa một điểm mà không xóa toàn bộ series?**

Đặt ô giá trị liên quan thành `null` để giữ vị trí danh mục của điểm như một điểm trống. Chỉ dùng [ChartDataPointCollection.clear](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdatapointcollection/#clear) khi bạn muốn xóa hết tất cả các điểm trong series đó. Nếu bạn cũng xóa các danh mục, hãy cập nhật mọi series sao cho giá trị của chúng vẫn đồng bộ với collection danh mục.

**Các điểm trống được hiển thị như thế nào?**

Kết quả phụ thuộc vào loại biểu đồ và giá trị được cấu hình qua [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs). Các biểu đồ hỗ trợ có thể hiển thị khoảng trống dưới dạng khe hở, giá trị zero, hoặc bằng cách nối các điểm lân cận. Chọn cài đặt phù hợp với ý nghĩa của dữ liệu mất trong bài thuyết trình của bạn. Xem mục [Kiểm Soát Hiển Thị Các Ô Trống](#control-the-display-of-empty-cells) để biết ví dụ hoàn chỉnh và so sánh hình ảnh.

**Các giá trị âm được định dạng như thế nào?**

Đối với các series thanh, cột và bong bóng được hỗ trợ, gọi [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) và đặt màu trả về bởi [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Bạn có thể ghi đè hành vi cho một điểm riêng lẻ bằng [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Các phương pháp này ảnh hưởng đến định dạng, không phải giá trị số lưu trữ.

**Định dạng nào thắng khi cả series và điểm đều được định dạng?**

Định dạng điểm dữ liệu rõ ràng sẽ có ưu tiên đối với điểm đó. Các điểm khác tiếp tục sử dụng định dạng series rõ ràng hoặc, khi series không có định dạng, sẽ dùng kiểu biểu đồ và chủ đề tự động. Các cài đặt nhóm như độ chồng và độ rộng khe hở kiểm soát bố cục và không phải là các ghi đè định dạng ở mức điểm.

**Có giới hạn số series mà biểu đồ có thể chứa không?**

Aspose.Slides không áp đặt một giới hạn cố định cho số series. Trong thực tế, giới hạn hữu ích được quyết định bởi ràng buộc của file trình bày, bộ nhớ khả dụng, thời gian render và khả năng đọc hiểu của biểu đồ.

**Nên thay đổi gì khi các cột quá gần nhau hoặc quá xa?**

Gọi [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) trên nhóm series cha phù hợp. Tăng giá trị để mở rộng không gian giữa các cụm, hoặc giảm để đưa các cụm lại gần nhau hơn.