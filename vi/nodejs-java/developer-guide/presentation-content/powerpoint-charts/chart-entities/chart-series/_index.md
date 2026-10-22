---
title: Quản lý Dữ liệu Series trong Biểu đồ trong Bản trình chiếu bằng JavaScript
linktitle: Series Dữ liệu
type: docs
url: /vi/nodejs-java/chart-series/
keywords:
- series biểu đồ
- độ chồng series
- màu series
- tên series
- điểm dữ liệu
- ô workbook
- khoảng cách series
- giá trị âm
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách quản lý series biểu đồ, điểm dữ liệu, ô workbook, định dạng, độ chồng, chiều rộng khoảng cách và giá trị âm trong bản trình chiếu bằng JavaScript."
---
## **Overview**

Biểu đồ có thể lưu các giá trị đã vẽ trong các ô của workbook hoặc trực tiếp dưới dạng các literal số. Một [ChartSeries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/) đại diện cho một tập hợp các giá trị có liên quan, và mỗi [ChartDataPoint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/) đại diện cho một điểm trong tập hợp đó. Các đối tượng [ChartCategory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategory/) cung cấp các nhãn hoặc giá trị nhóm được các series chia sẻ. Trong các biểu đồ được tạo với dữ liệu mặc định, tên series, danh mục và giá trị điểm sử dụng các đối tượng [ChartDataCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/) từ workbook của biểu đồ.

Đối với một biểu đồ danh mục điển hình, workbook mặc định sử dụng hàng 0 cho tên series, cột 0 cho tên danh mục và các ô còn lại cho giá trị series. Các chỉ số worksheet, hàng và cột truyền cho [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcell/) là chỉ số bắt đầu từ 0. Bố cục này hữu ích khi bạn tạo biểu đồ với dữ liệu mặc định, nhưng không nên cho rằng mọi biểu đồ hiện có đều sử dụng nó. Đối với một bản trình chiếu đã tải, hãy kiểm tra các ô được series, danh mục và các điểm dữ liệu tham chiếu trước khi thay đổi giá trị workbook.

Cài đặt biểu đồ có ba phạm vi khác nhau:

- Cài đặt cấp Series, chẳng hạn [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/), cung cấp giao diện mặc định cho tất cả các điểm trong một series.
- Cài đặt cấp Data‑point, chẳng hạn [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/), ghi đè giao diện series cho một điểm.
- Cài đặt nhóm áp dụng cho các series tương thích thuộc cùng một [ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/). Truy cập nhóm qua [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/) khi bạn cần thiết lập các tùy chọn như overlap hoặc gap width.

Khi không có fill cho điểm hoặc series được đặt một cách rõ ràng, phong cách và chủ đề của biểu đồ sẽ quyết định giao diện tự động. Khi cả định dạng series và point đều tồn tại, định dạng point sẽ có ưu tiên đối với điểm đó.

![Biểu đồ series PowerPoint](chart-series-powerpoint.png)

## **Set Series Values Using Numeric Literals**

Sử dụng các literal số khi giá trị series đến từ dữ liệu hoặc tính toán của ứng dụng và không cần tham chiếu đến ô worksheet. Gọi [setDataSourceTypeForValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/) với [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) trước khi gán kết quả [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/) của mỗi điểm thông qua [setAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/setasliteraldouble/).

Cài đặt bộ sưu tập kiểm soát loại nguồn của tất cả các giá trị điểm trong series đó. Phương thức [getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/basechartvalue/) của mỗi giá trị điểm báo cáo loại đã chọn; thay đổi nó thông qua cài đặt bộ sưu tập. Với `Worksheet`, sử dụng [getAsCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getascell/) để truy cập ô được tham chiếu. Với `DoubleLiterals`, sử dụng [getAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getasliteraldouble/) hoặc `setAsLiteralDouble` để đọc hoặc ghi số trực tiếp.

Ví dụ sau tạo một biểu đồ cột với series và danh mục mặc định, sau đó gán các giá trị tính toán 10, 20, … cho các điểm hiện có của series đầu tiên. Nó lưu bản trình chiếu, mở lại và in các giá trị đã lưu.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    const series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().setDataSourceTypeForValues(aspose.slides.DataSourceType.DoubleLiterals);
    for (let i = 0; i < series.getDataPoints().size(); i++) {
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10);
    }

    presentation.save("numeric_literals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation("numeric_literals.pptx");
try {
    const reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    const reopenedChart = reopenedSlide.getShapes().get_Item(0);
    const reopenedSeries = reopenedChart.getChartData().getSeries().get_Item(0);
    for (let i = 0; i < reopenedSeries.getDataPoints().size(); i++) {
        const point = reopenedSeries.getDataPoints().get_Item(i);
        console.log(point.getValue().getAsLiteralDouble());
    }
} finally {
    reopenedPresentation.dispose();
}
```

Kiểu nguồn giá trị điểm tách riêng khỏi [ChartData.getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/), phương thức này xác định cấu hình workbook nội bộ hoặc ngoại vi của biểu đồ. Sử dụng các literal số không tự động loại bỏ workbook nhúng. Trong ví dụ này, workbook vẫn còn sẵn sàng cho nhãn danh mục, tên series và các series khác. Xem [Chart Workbook](/slides/vi/nodejs-java/chart-workbook/) để biết quản lý workbook.

Đối với biểu đồ scatter và bubble, sử dụng [setDataSourceTypeForXValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) và [setDataSourceTypeForYValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) để chọn nguồn cho [getXValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getxvalue/) và [getYValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getyvalue/). Biểu đồ bubble cũng sử dụng [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) cho [getBubbleSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getbubblesize/). Đặt mỗi nguồn áp dụng thành `DoubleLiterals` trước khi gán số qua phương thức `setAsLiteralDouble` của giá trị tương ứng.

## **Set the Chart Series Overlap**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getoverlap/) báo cáo mức độ chồng lấn của các thanh hoặc cột trong biểu đồ 2D, từ -100 đến 100 phần trăm. Đây là một phép chiếu chỉ đọc của cài đặt trên nhóm series cha. Sử dụng [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setoverlap/) để cập nhật mọi series tương thích trong nhóm đó. Tùy chọn này áp dụng cho các kiểu biểu đồ hiển thị các thanh hoặc cột được nhóm lại; nó không ảnh hưởng đến các nhóm series không liên quan trong biểu đồ kết hợp.

Ví dụ sau đặt overlap cho nhóm chứa series đầu tiên:

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

    // Biểu đồ mới chứa các series mẫu, danh mục và giá trị.
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Overlap của series](series_overlap.png)

## **Change the Series Fill Color**

Sử dụng [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/) để đặt fill mặc định cho toàn bộ một series. Nếu một điểm đã có fill được định nghĩa rõ ràng, cài đặt [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/) của nó sẽ ghi đè fill của series cho điểm đó.

Ví dụ sau áp dụng một fill xanh đậm cho series đầu tiên:

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

![Màu của series](series_color.png)

## **Change the Series Name**

Tên series được lưu trong workbook dữ liệu biểu đồ và thường hiển thị trong legend. Trong workbook mặc định được tạo cho biểu đồ cột nhóm, ô B1 nằm ở hàng 0, cột 1 và chứa tên của series đầu tiên. Các hằng số được đặt tên trong ví dụ sau làm cho cấu trúc này trở nên rõ ràng:

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

Bạn cũng có thể cập nhật ô mà [ChartSeries.getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getname/) đã tham chiếu. Cách này tránh việc giả định một hàng và cột cố định trong một biểu đồ đã tồn tại:

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

![Tên series](series_name.png)

### **Create a Series with a Name from Multiple Cells**

Một tên series tổng hợp hữu ích khi tên sản phẩm và kỳ báo cáo được lưu trong các ô workbook riêng biệt. Ví dụ, bạn có thể kết hợp `Product A` trong B1 và `2026` trong C1 thành một tên series duy nhất trong khi vẫn giữ cả hai phần liên kết tới ô nguồn.

Sử dụng [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcellcollection/) để lấy phạm vi tên, sau đó truyền bộ sưu tập đó cho [ChartSeriesCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriescollection/add/). Tham số `skipHiddenCells` điều khiển việc bao gồm các ô ẩn: `true` loại trừ chúng, `false` bao gồm chúng. Ví dụ này dùng `false` để bao gồm mọi ô trong phạm vi tên.

Ví dụ sau tạo một bản trình chiếu với một series và hai điểm dữ liệu. Các ô B1:C1 chỉ cung cấp tên series; A2:A3 cung cấp nhãn danh mục, và B2:B3 cung cấp các giá trị số.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 620, 180);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(true);

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // Hai ô này cung cấp tên series.
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    const nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    const series = chart.getChartData().getSeries().add(nameCells, aspose.slides.ChartType.ClusteredColumn);

    // Các ô riêng biệt cung cấp danh mục và các điểm dữ liệu số.
    const northCategory = workbook.getCell(0, 1, 0, "North");
    const southCategory = workbook.getCell(0, 2, 0, "South");
    chart.getChartData().getCategories().add(northCategory);
    chart.getChartData().getCategories().add(southCategory);
    const northValue = workbook.getCell(0, 1, 1, 120);
    const southValue = workbook.getCell(0, 2, 1, 150);
    series.getDataPoints().addDataPointForBarSeries(northValue);
    series.getDataPoints().addDataPointForBarSeries(southValue);

    presentation.save("composite_series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Tên series tạo ra là `Product A 2026`, với một dấu cách giữa hai giá trị ô. Legend hiển thị nó như một mục duy nhất cho cả hai cột. Hình dưới minh họa kết quả:

![Biểu đồ cột với giá trị Bắc và Nam và tên series tổng hợp Product A 2026 trong legend](composite_series_name.png)

## **Get the Automatic Series Fill Color**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getautomaticseriescolor/) trả về màu được tính dựa trên chỉ số series và phong cách biểu đồ. Đây là màu được sử dụng khi fill của series không được xác định rõ. Gọi phương thức này chỉ đọc màu đã tính; nó không gán một fill mới.

Ví dụ sau in màu tự động của mỗi series mặc định:

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

Đầu ra mẫu cho phong cách biểu đồ mặc định:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Màu chính xác phụ thuộc vào phong cách và chủ đề của biểu đồ.

## **Set Invert Fill Color for a Chart Series**

Đối với series thanh, cột và bubble, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/) có thể hiển thị các giá trị âm với một fill khác. Đặt fill series thông thường thành đặc, bật chế độ đảo ngược, và gán màu âm thông qua [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). Các số âm vẫn giữ nguyên trong workbook; chỉ màu hiển thị thay đổi.

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

![Màu fill đặc đảo ngược](inverted_solid_fill_color.png)

Bạn có thể bật đảo ngược cho một điểm thông qua [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/). Trong ví dụ sau, đảo ngược bị tắt cho series và chỉ bật cho điểm đã chọn. Điểm này cũng được gán giá trị âm để hiệu ứng hiển thị:

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

## **Clear a Specific Data Point Value**

Để làm cho một điểm trống mà không xóa các điểm khác, đặt ô workbook hỗ trợ nó thành `null`. Đối với biểu đồ cột, giá trị đã vẽ có thể truy cập qua [ChartDataPoint.getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/). Điểm dữ liệu vẫn ở vị trí danh mục cũ, nhưng biểu đồ sẽ xem giá trị của nó là trống theo cài đặt blank‑value của biểu đồ.

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

Biểu đồ scatter sử dụng các ô X và Y riêng biệt, và biểu đồ bubble cũng có ô kích thước. Chỉ xóa ô đại diện cho giá trị bạn muốn loại bỏ. Không gọi [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/) khi bạn muốn giữ lại các điểm khác, vì phương thức này sẽ xóa mọi điểm dữ liệu trong bộ sưu tập.

## **Control the Display of Empty Cells**

Các ô ẩn chứa giá trị là một trường hợp riêng so với các ô trống. Để bao gồm hoặc loại bỏ dữ liệu từ các hàng và cột worksheet ẩn, xem [Include Data from Hidden Rows and Columns](/slides/vi/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Một ô workbook trống đại diện cho dữ liệu thiếu; một ô chứa `0` đại diện cho một giá trị số đã biết. Gọi [ChartDataCell.setValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setvalue/) với `null` để làm ô trống. Số 0 vẫn là 0 bất kể cài đặt ô trống.

Sử dụng [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) để chọn cách biểu đồ hiển thị các ô trống. Cài đặt này áp dụng cho toàn bộ biểu đồ. Nó thay đổi cách vẽ các ô trống, mà không điền ô workbook trống bằng 0 hoặc giá trị nội suy.

Ví dụ tự chứa dưới đây tạo một biểu đồ đường với một series, xóa giá trị cho Ngày 3, và lưu cùng biểu đồ với mỗi chế độ. Không cần file đầu vào. [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) sử dụng worksheet 0, cột 0 cho nhãn danh mục và cột 1 cho các giá trị; hàng 0 chứa tên series. Dữ liệu cuối cùng là `10, 20, empty, 30, 40`.

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

    // Để Ngày 3 thực sự trống, đồng thời giữ lại danh mục và điểm dữ liệu của nó.
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

Mỗi file output lưu chế độ được chỉ định trước khi lưu: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` và `empty_cells_Span.pptx`. Để lưu chỉ một phiên bản, đặt chế độ mong muốn và lưu bản trình chiếu một lần thay vì lặp lại các chế độ.

Bảng so sánh dưới đây cho thấy cùng một dữ liệu trong cả ba file. Ngày 3 là trống trong workbook trong mọi trường hợp:

![Biểu đồ đường với dữ liệu giống nhau: Gap phá vỡ đường tại Ngày 3, Zero hạ đường xuống 0, và Span nối Ngày 2 tới Ngày 4.](display_blanks_as.png)

Hiệu ứng nhìn thấy phụ thuộc vào kiểu biểu đồ. Biểu đồ đường giúp so sánh ba chế độ dễ dàng. Biểu đồ thanh và cột không có đường nối qua danh mục thiếu, vì vậy `Span` không thể tạo đoạn nối như trên; một cột thiếu và một cột cao 0 cũng có thể trông giống nhau. Tương tự, biểu đồ scatter chỉ có marker cũng không có đường nối. Không mong đợi ba kết quả riêng biệt cho mọi kiểu biểu đồ; kiểm tra output cho kiểu bạn đang dùng.

## **Set the Series Gap Width**

Gap width là khoảng cách giữa các cụm thanh hoặc cột liền kề, tính bằng phần trăm của chiều rộng thanh hoặc cột. Giống như overlap, nó thuộc về nhóm series cha chứ không phải một series đơn lẻ. Gọi [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) một lần cho nhóm. Giá trị lớn tạo khoảng cách rộng hơn giữa các cụm; giá trị nhỏ làm chúng dày đặc hơn.

Ví dụ sau thay đổi gap width và chỉ lưu bản trình chiếu cuối cùng:

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

![Gap width](gap_width.png)

## **FAQ**

**Which chart types support data series?**

Tất cả các kiểu biểu đồ được biểu thị bởi enumeration [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) sử dụng dữ liệu biểu đồ, nhưng series của chúng không phải lúc nào cũng có cùng cấu trúc giá trị hoặc cài đặt. Ví dụ, biểu đồ danh mục dùng danh mục và giá trị, biểu đồ scatter dùng giá trị X và Y, và biểu đồ bubble thêm kích thước bubble. Sử dụng phương pháp tạo data‑point phù hợp với kiểu series. Các tùy chọn như overlap và gap width chỉ áp dụng cho các nhóm thanh hoặc cột tương thích.

**What is a chart series group?**

Một [ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/) chứa các series tương thích chia sẻ các cài đặt vẽ ở mức nhóm. Một biểu đồ kết hợp có thể chứa nhiều hơn một nhóm, vì vậy việc thay đổi nhóm thông qua một series không nhất thiết thay đổi mọi series trong biểu đồ.

**Does a newly created chart contain default data?**

Có. Mặc định, [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) tạo các series, danh mục và giá trị mẫu. Bạn có thể chỉnh sửa các ô này hoặc xóa cả hai bộ sưu tập series và danh mục trước khi thêm một bộ dữ liệu tùy chỉnh hoàn toàn. Một overload cũng có thể tạo biểu đồ không có dữ liệu mặc định.

**How are chart objects connected to workbook cells?**

Tên series, nhãn danh mục và giá trị data‑point tham chiếu đến các ô trong một [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/). Thay đổi một ô được tham chiếu sẽ cập nhật phần tử biểu đồ tương ứng. Khi bạn xây dựng dữ liệu tùy chỉnh, giữ các hàng danh mục và hàng giá trị series đồng bộ để mỗi điểm được vẽ dưới đúng danh mục.

**How do I clear one point instead of the whole series?**

Đặt ô giá trị tương ứng thành `null` để giữ vị trí danh mục của điểm như một điểm trống. Chỉ dùng [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/) khi bạn muốn xóa tất cả các điểm trong series đó. Nếu bạn cũng xóa các danh mục, hãy cập nhật mọi series để giá trị của chúng vẫn đồng bộ với bộ danh mục.

**How are empty points displayed?**

Kết quả phụ thuộc vào kiểu biểu đồ và giá trị được cấu hình qua [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/). Các biểu đồ được hỗ trợ có thể hiển thị blanks dưới dạng khoảng trống, giá trị zero, hoặc nối các điểm lân cận. Chọn cài đặt phù hợp với ý nghĩa của dữ liệu thiếu trong bản trình chiếu của bạn. Xem [Control the Display of Empty Cells](#control-the-display-of-empty-cells) để có ví dụ đầy đủ và so sánh trực quan.

**How are negative values formatted?**

Đối với các series thanh, cột và bubble được hỗ trợ, gọi [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/) và đặt màu trả về bởi [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). Bạn có thể ghi đè hành vi cho một điểm riêng lẻ bằng [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/). Các phương thức này ảnh hưởng đến định dạng, không phải giá trị số được lưu.

**Which formatting wins when both a series and a point are formatted?**

Định dạng data‑point rõ ràng có ưu tiên đối với điểm đó. Các điểm khác tiếp tục sử dụng định dạng series rõ ràng hoặc, khi series không được định dạng, phong cách và chủ đề biểu đồ tự động. Cài đặt nhóm như overlap và gap width kiểm soát bố cục và không phải là ghi đè định dạng cấp điểm.

**Is there a limit to how many series a chart can contain?**

Aspose.Slides không áp đặt một giới hạn cố định cho số series. Trong thực tế, các hạn chế của tệp trình chiếu, bộ nhớ khả dụng, thời gian render và khả năng đọc hiểu của biểu đồ sẽ quyết định giới hạn hữu dụng.

**What should I change when columns are too close together or too far apart?**

Gọi [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) trên nhóm series cha thích hợp. Tăng giá trị để làm rộng khoảng cách giữa các cụm, hoặc giảm để các cụm lại gần nhau hơn.