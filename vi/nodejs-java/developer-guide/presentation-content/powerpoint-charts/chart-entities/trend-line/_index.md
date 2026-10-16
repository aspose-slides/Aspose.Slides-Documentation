---
title: Thêm Đường Xu Hướng vào Biểu Đồ Trình Chiếu trong JavaScript
linktitle: Đường Xu Hướng
type: docs
url: /vi/nodejs-java/trend-line/
keywords:
- biểu đồ
- đường xu hướng
- đường xu hướng hàm mũ
- đường xu hướng tuyến tính
- đường xu hướng logarit
- đường xu hướng trung bình động
- đường xu hướng đa thức
- đường xu hướng lũy thừa
- đường xu hướng tùy chỉnh
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Nhanh chóng thêm và tùy chỉnh các đường xu hướng trong biểu đồ PowerPoint bằng JavaScript và Aspose.Slides cho Node.js qua Java — hướng dẫn thực tế để thu hút khán giả của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách thêm các đường xu hướng vào biểu đồ trong bài thuyết trình bằng cách sử dụng Aspose.Slides. Nó chỉ ra cách tạo một biểu đồ, thêm các đường xu hướng vào các series của biểu đồ, và làm việc với một số loại đường xu hướng, bao gồm hàm mũ, tuyến tính, logarit, trung bình động, đa thức và lũy thừa.

Nó cũng mô tả cách thêm một đường tùy chỉnh vào biểu đồ bằng cách chèn một hình dạng đường thẳng, và bao gồm một phần Hỏi đáp ngắn về các giá trị chiếu xu hướng phía trước và phía sau và việc các đường xu hướng có được bảo tồn khi xuất ra PDF hoặc SVG và khi render biểu đồ dưới dạng hình ảnh hay không.

## **Thêm Đường Xu Hướng**

Sử dụng [TrendlineCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinecollection/#add) để thêm một đường xu hướng vào một series của biểu đồ, chọn loại bằng [TrendlineType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinetype/). Ví dụ tạo một biểu đồ cột nhóm với dữ liệu mặc định và thêm hai đường xu hướng cho mỗi ba series của nó.

Đường xu hướng hàm mũ ẩn phương trình và giá trị R‑squared thông qua [setDisplayEquation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayEquation) và [setDisplayRSquaredValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayRSquaredValue), trong khi đường xu hướng tuyến tính có màu đỏ. Đường xu hướng logarit sử dụng [addTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#addTextFrameForOverriding) cho một nhãn tùy chỉnh. Đường trung bình động sử dụng [setPeriod](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setPeriod) là ba điểm dữ liệu và một [setTrendlineName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setTrendlineName) tùy chỉnh.

Đường xu hướng đa thức có [setOrder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setOrder) là ba và mở rộng một danh mục phía trước bằng [setForward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setForward). Đường xu hướng lũy thừa mở rộng một danh mục phía sau bằng [setBackward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setBackward).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);

    const firstSeries = chart.getChartData().getSeries().get_Item(0);

    const exponentialTrendline = firstSeries.getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    exponentialTrendline.setDisplayEquation(false);
    exponentialTrendline.setDisplayRSquaredValue(false);

    const linearTrendline = firstSeries.getTrendLines().add(aspose.slides.TrendlineType.Linear);
    linearTrendline.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    linearTrendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(red);

    const secondSeries = chart.getChartData().getSeries().get_Item(1);

    const logarithmicTrendline = secondSeries.getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    logarithmicTrendline.addTextFrameForOverriding("New log trend line");

    const movingAverageTrendline = secondSeries.getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    movingAverageTrendline.setPeriod(java.newByte(3));
    movingAverageTrendline.setTrendlineName("New TrendLine Name");

    const thirdSeries = chart.getChartData().getSeries().get_Item(2);

    const polynomialTrendline = thirdSeries.getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    polynomialTrendline.setForward(1);
    polynomialTrendline.setOrder(java.newByte(3));

    const powerTrendline = thirdSeries.getTrendLines().add(aspose.slides.TrendlineType.Power);
    powerTrendline.setBackward(1);

    presentation.save("ChartTrendLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt Giao Điểm Đường Xu Hướng**

Sử dụng [setIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setIntercept) để cố định giá trị Y của đường xu hướng tại X = 0. Cài đặt này hỗ trợ cho các đường xu hướng tuyến tính, hàm mũ và đa thức.

Ví dụ, một mô hình chi phí sản xuất có thể cần bắt đầu từ chi phí cố định đã biết là 100, ngay cả khi các đo lường ở khối lượng sản xuất khác 0 cho thấy một nền tảng khác. Đối với một đường xu hướng tuyến tính, việc cố định giao điểm ràng buộc phương trình `y = ax + b` thành `b = 100`; độ dốc sẽ được điều chỉnh dựa trên dữ liệu dưới ràng buộc đó. Nó không chỉ di chuyển một đường đã được điều chỉnh. Cài đặt giao cắt trục kiểm soát nơi các trục biểu đồ gặp nhau, không phải các hệ số của đường xu hướng đã được điều chỉnh.

Ví dụ sau tạo một biểu đồ scatter (XY) với khối lượng sản xuất từ 1 đến 4 và chi phí 170, 200, 230 và 260. Nó lưu biểu đồ với giao điểm tự động mặc định, đặt giao điểm thành 100 và lưu một PPTX thứ hai. Hai tệp chỉ khác nhau ở cài đặt giao điểm. Đường xu hướng hiển thị phương trình và mở rộng lại tới X = 0.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithMarkers, 20, 20, 480, 210);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const nameCell = workbook.getCell(0, 0, 1, "Production cost");
    const series = chart.getChartData().getSeries().add(nameCell, aspose.slides.ChartType.ScatterWithMarkers);
    const costs = [170, 200, 230, 260];

    for (let i = 0; i < costs.length; i++) {
        const xCell = workbook.getCell(0, i + 1, 0, i + 1);
        const yCell = workbook.getCell(0, i + 1, 1, costs[i]);
        series.getDataPoints().addDataPointForScatterSeries(xCell, yCell);
    }

    const trendline = series.getTrendLines().add(aspose.slides.TrendlineType.Linear);
    trendline.setDisplayEquation(true);
    trendline.setBackward(1);

    presentation.save("AutomaticIntercept.pptx", aspose.slides.SaveFormat.Pptx);

    trendline.setIntercept(100);
    presentation.save("FixedIntercept.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Với phép tính tự động, các dữ liệu này cho ra `y = 30x + 140`. Đặt giao điểm thành 100 thay vào đó cho ra khoảng `y = 43.33x + 100`: giá trị điều chỉnh ở không khớp với nền tảng đã biết, trong khi đường không còn đi qua mọi điểm dữ liệu.

| Giao điểm tự động | Giao điểm cố định 100 |
| --- | --- |
| ![Đường xu hướng tuyến tính với giao điểm được tính tự động là 140](intercept-automatic.png) | ![Đường xu hướng tuyến tính với giao điểm cố định là 100](intercept-fixed.png) |

Cả hai hình đều sử dụng cùng một dữ liệu và tỉ lệ trục. Các đường xu hướng được mở rộng lại tới X = 0 để hiển thị giao điểm của chúng.

Mặc định, [getIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#getIntercept) trả về `NaN`, biểu thị một giao điểm chưa xác định thay vì bằng 0. Khi đó giao điểm được tính tự động từ dữ liệu.

## **Thêm Đường Tùy Chỉnh**

Một đường tùy chỉnh là một hình dạng vẽ lên trên biểu đồ thay vì một đường xu hướng được tính từ dữ liệu series. Ví dụ này sử dụng [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAutoShape) để thêm một đường ngang vào slide trên biểu đồ. Vị trí của đường được chỉ định bằng tọa độ slide, đo bằng điểm, vì vậy nó bắt đầu ở cạnh trái của biểu đồ và nằm ở giữa chiều cao của biểu đồ. Độ rộng của nó khớp với độ rộng của biểu đồ. [getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) cho đường một màu đỏ đặc.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);

    const line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0);
    line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);

    presentation.save("AddCustomLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**'Forward' và 'backward' có nghĩa là gì đối với một đường xu hướng?**

Chúng là độ dài của đường xu hướng được chiếu phía trước/phía sau: đối với biểu đồ scatter (XY) — tính bằng đơn vị trục; đối với các biểu đồ không phải scatter — tính bằng số danh mục. Chỉ cho phép các giá trị không âm.

**Đường xu hướng có được giữ lại khi xuất bản trình chiếu ra PDF hoặc SVG, hoặc khi render một slide thành hình ảnh không?**

Có. Aspose.Slides chuyển đổi các bản trình chiếu sang [PDF](/slides/vi/nodejs-java/convert-powerpoint-to-pdf/) hoặc [SVG](/slides/vi/nodejs-java/render-a-slide-as-an-svg-image/) và render các biểu đồ thành hình ảnh; các đường xu hướng, như một phần của biểu đồ, được giữ lại trong các thao tác này. Một phương thức cũng có sẵn để [export an image of the chart](/slides/vi/nodejs-java/create-shape-thumbnails/) chính nó.