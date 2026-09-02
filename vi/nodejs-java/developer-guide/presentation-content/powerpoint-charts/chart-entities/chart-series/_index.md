---
title: Quản lý Dữ liệu Chuỗi Biểu Đồ trong Bản Trình Chiếu bằng JavaScript
linktitle: Chuỗi Dữ liệu
type: docs
url: /vi/nodejs-java/chart-series/
keywords:
- chuỗi biểu đồ
- chồng lấn chuỗi
- màu chuỗi
- tên chuỗi
- điểm dữ liệu
- ô sổ làm việc
- khoảng cách chuỗi
- giá trị âm
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách quản lý chuỗi biểu đồ, điểm dữ liệu, ô sổ làm việc, định dạng, chồng lấn, độ rộng khoảng cách và giá trị âm trong bản trình chiếu bằng JavaScript."
---
## **Tổng quan**

Biểu đồ lưu trữ dữ liệu đã vẽ trong một sổ làm việc dữ liệu biểu đồ. Một [ChartSeries](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartseries/) đại diện cho một tập hợp các giá trị liên quan, và mỗi [ChartDataPoint](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdatapoint/) trong chuỗi tham chiếu tới một hoặc nhiều ô trong sổ làm việc. Các đối tượng [ChartCategory](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartcategory/) cung cấp các nhãn hoặc giá trị nhóm được chia sẻ bởi các chuỗi. Vì vậy, tên chuỗi, các danh mục và giá trị điểm đều được liên kết với các đối tượng [ChartDataCell](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdatacell/) thay vì chỉ được lưu dưới dạng văn bản hiển thị.

Đối với một biểu đồ danh mục điển hình, sổ làm việc mặc định sử dụng hàng 0 cho tên chuỗi, cột 0 cho tên danh mục và các ô còn lại cho giá trị chuỗi. Các chỉ mục worksheet, hàng và cột được truyền vào [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdataworkbook/#getCell) đều tính từ 0. Bố cục này hữu ích khi bạn tạo biểu đồ với dữ liệu mặc định, nhưng không nên cho rằng mọi biểu đồ hiện có đều sử dụng nó. Đối với một bản trình bày đã tải, hãy kiểm tra các ô được tham chiếu bởi các chuỗi, danh mục và điểm dữ liệu trước khi thay đổi giá trị trong sổ làm việc.

Cài đặt biểu đồ có ba phạm vi khác nhau:

- Cài đặt cấp chuỗi, chẳng hạn như [ChartSeries.getFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartseries/#getFormat), cung cấp giao diện mặc định cho tất cả các điểm trong một chuỗi.
- Cài đặt cấp điểm dữ liệu, chẳng hạn như [ChartDataPoint.getFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdatapoint/#getFormat), ghi đè giao diện chuỗi cho một điểm.
- Cài đặt nhóm áp dụng cho các chuỗi tương thích thuộc cùng một [ChartSeriesGroup](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartseriesgroup/). Truy cập nhóm qua [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup) khi bạn cần đặt các tùy chọn như độ chồng chéo hoặc độ rộng khoảng cách.

Khi không có màu nền điểm hoặc chuỗi nào được thiết lập rõ ràng, kiểu biểu đồ và chủ đề sẽ xác định giao diện tự động. Khi cả định dạng chuỗi và điểm đều tồn tại, định dạng điểm sẽ có ưu tiên đối với điểm đó.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Đặt Độ Chồng Lấn của Chuỗi Biểu Đồ**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartseries/#getOverlap) báo cáo mức độ các thanh hoặc cột chồng lên nhau trong biểu đồ 2D, từ -100 đến 100 phần trăm. Đây là một phép chiếu chỉ đọc của cài đặt trên nhóm chuỗi cha. Sử dụng [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap) để cập nhật mọi chuỗi tương thích trong nhóm đó. Tùy chọn này áp dụng cho các loại biểu đồ hiển thị các thanh hoặc cột được nhóm lại; nó không ảnh hưởng tới các nhóm chuỗi không liên quan trong biểu đồ kết hợp.

Ví dụ sau thiết lập độ chồng lấn cho nhóm chứa chuỗi đầu tiên:

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

## **Thay Đổi Màu Nền của Chuỗi**

Sử dụng [ChartSeries.getFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartseries/#getFormat) để đặt màu nền mặc định cho toàn bộ một chuỗi. Nếu một điểm đã có màu nền rõ ràng, cài đặt [ChartDataPoint.getFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdatapoint/#getFormat) của nó sẽ ghi đè màu nền chuỗi cho điểm đó.

Ví dụ sau áp dụng màu nền xanh đậm đặc cho chuỗi đầu tiên:

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

## **Thay Đổi Tên Chuỗi**

Tên chuỗi được lưu trong sổ làm việc dữ liệu biểu đồ và thường được hiển thị trong chú giải. Trong sổ làm việc mặc định được tạo cho biểu đồ cột cụm, ô B1 nằm ở hàng 0, cột 1 và chứa tên của chuỗi đầu tiên. Các hằng số được đặt tên trong ví dụ dưới đây làm rõ cấu trúc đó:

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

Bạn cũng có thể cập nhật ô đã được tham chiếu bởi [ChartSeries.getName](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartseries/#getName). Cách này tránh việc giả định một hàng và cột cụ thể trong một biểu đồ đã tồn tại:

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

## **Lấy Màu Nền Tự Động của Chuỗi**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor) trả về màu được tính dựa trên chỉ số chuỗi và kiểu biểu đồ. Đây là màu được sử dụng khi màu nền chuỗi không được xác định rõ ràng. Gọi phương thức này chỉ đọc màu đã tính; nó không gán màu nền mới.

Ví dụ sau in ra màu tự động của mỗi chuỗi mặc định:

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

Màu sắc chính xác phụ thuộc vào kiểu biểu đồ và chủ đề.

## **Đặt Màu Nền Đảo Ngược cho Chuỗi Biểu Đồ**

Đối với các chuỗi thanh, cột và bong bóng, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) có thể hiển thị các giá trị âm bằng một màu nền khác. Đặt màu nền chuỗi thường thành đặc, bật tính năng đảo ngược và chỉ định màu cho giá trị âm qua [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Các số âm vẫn không thay đổi trong sổ làm việc; chỉ màu hiển thị của chúng thay đổi.

Ví dụ sau thay thế dữ liệu biểu đồ mặc định bằng một chuỗi. Hàng 0 của worksheet chứa tên chuỗi, cột 0 chứa tên danh mục và cột 1 chứa các giá trị:

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

Bạn có thể bật đảo ngược cho một điểm thông qua [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Trong ví dụ dưới đây, đảo ngược bị tắt cho chuỗi và chỉ bật cho điểm đã chọn. Điểm này cũng được gán một giá trị âm để hiệu ứng hiển thị:

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

## **Xóa Giá Trị Của Một Điểm Dữ Liệu Cụ Thể**

Để làm cho một điểm trống mà không xóa các điểm khác, đặt ô sổ làm việc hỗ trợ của nó thành `null`. Đối với biểu đồ cột, giá trị đã vẽ có thể lấy qua [ChartDataPoint.getValue](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdatapoint/#getValue). Điểm dữ liệu vẫn giữ vị trí danh mục cũ, nhưng biểu đồ sẽ coi giá trị của nó là trống theo cài đặt giá trị trống của biểu đồ.

Ví dụ sau chỉ xóa điểm thứ hai trong chuỗi đầu tiên:

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

Biểu đồ phân tán sử dụng các ô X và Y riêng biệt, và biểu đồ bong bóng cũng sử dụng một ô kích thước. Chỉ xóa ô đại diện cho giá trị bạn muốn loại bỏ. Không gọi [ChartDataPointCollection.clear](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdatapointcollection/#clear) khi bạn muốn giữ các điểm còn lại, vì phương thức đó sẽ xóa mọi điểm dữ liệu khỏi bộ sưu tập.

## **Đặt Độ Rộng Khoảng Cách Giữa Các Chuỗi**

Độ rộng khoảng cách là khoảng cách giữa các cụm thanh hoặc cột liền kề, biểu thị dưới dạng phần trăm của độ rộng thanh hoặc cột. Giống như độ chồng lấn, nó thuộc về nhóm chuỗi cha chứ không phải một chuỗi cụ thể. Gọi [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) một lần cho nhóm. Giá trị lớn hơn tạo ra nhiều không gian hơn giữa các cụm; giá trị nhỏ hơn làm chúng dày đặc hơn.

Ví dụ sau thay đổi độ rộng khoảng cách và lưu chỉ bản trình bày cuối cùng:

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

## **Câu Hỏi Thường Gặp**

**Những loại biểu đồ nào hỗ trợ chuỗi dữ liệu?**

Tất cả các loại biểu đồ được biểu diễn bởi enumeration [ChartType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/charttype/) đều sử dụng dữ liệu biểu đồ, nhưng chuỗi của chúng không đồng nhất về cấu trúc giá trị hoặc cài đặt. Ví dụ, biểu đồ danh mục sử dụng danh mục và giá trị, biểu đồ phân tán sử dụng giá trị X và Y, và biểu đồ bong bóng thêm kích thước bong bóng. Hãy sử dụng phương pháp tạo điểm dữ liệu phù hợp với loại chuỗi. Các tùy chọn như độ chồng lấn và độ rộng khoảng cách chỉ áp dụng cho các nhóm thanh hoặc cột tương thích.

**Nhóm chuỗi biểu đồ là gì?**

Một [ChartSeriesGroup](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartseriesgroup/) chứa các chuỗi tương thích chia sẻ cài đặt vẽ cấp nhóm. Một biểu đồ kết hợp có thể chứa nhiều hơn một nhóm, vì vậy việc thay đổi nhóm thông qua một chuỗi không nhất thiết thay đổi mọi chuỗi trong biểu đồ.

**Biểu đồ mới tạo có chứa dữ liệu mặc định không?**

Có. Mặc định, [ShapeCollection.addChart](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapecollection/#addChart) tạo các chuỗi, danh mục và giá trị mẫu. Bạn có thể chỉnh sửa các ô này hoặc xóa cả bộ sưu tập chuỗi và danh mục trước khi thêm một bộ dữ liệu tùy chỉnh hoàn toàn. Một overload khác cũng có thể tạo biểu đồ không có dữ liệu mặc định.

**Các đối tượng biểu đồ được kết nối với các ô trong sổ làm việc như thế nào?**

Tên chuỗi, nhãn danh mục và giá trị điểm dữ liệu tham chiếu đến các ô trong một [ChartDataWorkbook](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdataworkbook/). Thay đổi một ô được tham chiếu sẽ cập nhật thành phần biểu đồ tương ứng. Khi xây dựng dữ liệu tùy chỉnh, hãy giữ cho các hàng danh mục và các hàng giá trị chuỗi thẳng hàng để mỗi điểm được vẽ dưới danh mục mong muốn.

**Làm sao để xóa một điểm mà không xóa toàn bộ chuỗi?**

Đặt ô giá trị tương ứng thành `null` để giữ vị trí danh mục của điểm như một điểm trống. Chỉ dùng [ChartDataPointCollection.clear](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdatapointcollection/#clear) khi bạn muốn xóa tất cả các điểm trong chuỗi đó. Nếu bạn cũng xóa các danh mục, hãy cập nhật mọi chuỗi sao cho giá trị của chúng vẫn đồng bộ với bộ sưu tập danh mục.

**Các điểm trống được hiển thị như thế nào?**

Kết quả phụ thuộc vào loại biểu đồ và giá trị được cấu hình qua [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs). Các biểu đồ được hỗ trợ có thể hiển thị các điểm trống dưới dạng khoảng trống, giá trị zero, hoặc bằng cách nối các điểm lân cận. Chọn cài đặt phù hợp với ý nghĩa của dữ liệu thiếu trong bản trình bày của bạn.

**Các giá trị âm được định dạng như thế nào?**

Đối với các chuỗi thanh, cột và bong bóng được hỗ trợ, gọi [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) và đặt màu trả về bởi [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Bạn có thể ghi đè hành vi cho một điểm riêng lẻ bằng [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Các phương pháp này ảnh hưởng đến định dạng, không phải các giá trị số lưu trữ.

**Định dạng nào thắng khi cả chuỗi và điểm đều được định dạng?**

Định dạng điểm dữ liệu rõ ràng sẽ có ưu tiên cho điểm đó. Các điểm khác vẫn sử dụng định dạng chuỗi rõ ràng hoặc, khi không có định dạng chuỗi, thì kiểu biểu đồ và chủ đề tự động. Các cài đặt nhóm như độ chồng lấn và độ rộng khoảng cách kiểm soát bố cục và không phải là các ghi đè định dạng cấp điểm.

**Có giới hạn số chuỗi mà một biểu đồ có thể chứa không?**

Aspose.Slides không áp đặt một giới hạn cố định riêng cho số chuỗi. Trong thực tế, các ràng buộc của tệp bản trình bày, bộ nhớ khả dụng, thời gian render và khả năng đọc của biểu đồ sẽ quyết định một giới hạn hữu ích.

**Nên thay đổi gì khi các cột quá gần nhau hoặc quá xa nhau?**

Gọi [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) trên nhóm chuỗi cha thích hợp. Tăng giá trị để mở rộng không gian giữa các cụm, hoặc giảm giá trị để đưa các cụm lại gần nhau hơn.