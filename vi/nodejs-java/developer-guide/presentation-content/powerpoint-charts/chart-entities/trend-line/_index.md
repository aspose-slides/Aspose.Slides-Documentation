---
title: Thêm Đường Xu Hướng vào Biểu Đồ Bản Trình Chiếu trong JavaScript
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
description: "Nhanh chóng thêm và tùy chỉnh đường xu hướng trong biểu đồ PowerPoint bằng JavaScript và Aspose.Slides cho Node.js thông qua Java — hướng dẫn thực tiễn để thu hút khán giả của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách thêm đường xu hướng vào biểu đồ trong bản trình chiếu bằng cách sử dụng Aspose.Slides. Nó cho thấy cách tạo biểu đồ, thêm đường xu hướng vào các chuỗi biểu đồ, và làm việc với một số loại đường xu hướng, bao gồm hàm mũ, tuyến tính, logarit, trung bình động, đa thức và lũy thừa.

Nó cũng mô tả cách thêm một đường tùy chỉnh vào biểu đồ bằng cách chèn một hình dạng đường thẳng, và bao gồm một phần Hỏi Đáp ngắn về các giá trị chiếu hướng tiến và lùi của đường xu hướng và việc các đường xu hướng có được giữ lại khi xuất sang PDF hoặc SVG và khi render biểu đồ dưới dạng hình ảnh hay không.

## **Thêm Đường Xu Hướng**

Aspose.Slides for Node.js via Java provides a simple API for managing different chart Trend Lines:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
1. Lấy tham chiếu của một slide bằng chỉ mục của nó.
1. Thêm một biểu đồ với dữ liệu mặc định cùng với bất kỳ loại nào mong muốn (ví dụ này sử dụng ChartType.ClusteredColumn).
1. Thêm đường xu hướng hàm mũ cho chuỗi biểu đồ 1.
1. Thêm đường xu hướng tuyến tính cho chuỗi biểu đồ 1.
1. Thêm đường xu hướng logarit cho chuỗi biểu đồ 2.
1. Thêm đường xu hướng trung bình động cho chuỗi biểu đồ 2.
1. Thêm đường xu hướng đa thức cho chuỗi biểu đồ 3.
1. Thêm đường xu hướng lũy thừa cho chuỗi biểu đồ 3.
1. Ghi bản trình chiếu đã sửa đổi thành tệp PPTX.

Mã sau được sử dụng để tạo biểu đồ với Đường Xu Hướng.

```javascript
// Tạo một thể hiện của lớp Presentation
var pres = new aspose.slides.Presentation();
try {
    // Tạo biểu đồ cột cụm
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);
    // Thêm đường xu hướng hàm mũ cho chuỗi biểu đồ 1
    var tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    // Thêm đường xu hướng tuyến tính cho chuỗi biểu đồ 1
    var tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Linear);
    tredLineLin.setTrendlineType(aspose.slides.TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Thêm đường xu hướng logarit cho chuỗi biểu đồ 2
    var tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    // Thêm đường xu hướng trung bình động cho chuỗi biểu đồ 2
    var tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod(3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    // Thêm đường xu hướng đa thức cho chuỗi biểu đồ 3
    var tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder(3);
    // Thêm đường xu hướng lũy thừa cho chuỗi biểu đồ 3
    var tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Power);
    tredLinePower.setTrendlineType(aspose.slides.TrendlineType.Power);
    tredLinePower.setBackward(1);
    // Lưu bản trình chiếu
    pres.save("ChartTrendLines_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Thêm Đường Tùy Chỉnh**

Aspose.Slides for Node.js via Java provides a simple API to add custom lines in a chart. To add a simple plain line to a selected slide of the presentation, please follow the steps below:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation)
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ số Index của nó
- Tạo một biểu đồ mới bằng phương thức AddChart được cung cấp bởi đối tượng Shapes
- Thêm một AutoShape loại Line bằng phương thức AddAutoShape được cung cấp bởi đối tượng Shapes
- Đặt màu sắc cho các đường của hình dạng.
- Ghi bản trình chiếu đã sửa đổi thành tệp PPTX

Mã sau được sử dụng để tạo biểu đồ với Đường Tùy Chỉnh.

```javascript
// Tạo một thể hiện của lớp Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    var shape = chart.getUserShapes().getShapes().addAutoShape(aspose.slides.ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("Presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Câu Hỏi Thường Gặp**

**'Forward' và 'backward' có nghĩa gì đối với một đường xu hướng?**

Chúng là độ dài của đường xu hướng được kéo dài về phía trước hoặc phía sau: đối với biểu đồ scatter (XY) — tính bằng đơn vị trục; đối với các biểu đồ không phải scatter — tính bằng số danh mục. Chỉ cho phép giá trị không âm.

**Đường xu hướng có được giữ lại khi xuất bản trình chiếu sang PDF hoặc SVG, hoặc khi render một slide thành hình ảnh không?**

Có. Aspose.Slides chuyển đổi bản trình chiếu sang [PDF](/slides/vi/nodejs-java/convert-powerpoint-to-pdf/)/[SVG](/slides/vi/nodejs-java/render-a-slide-as-an-svg-image/) và render các biểu đồ thành hình ảnh; các đường xu hướng, là một phần của biểu đồ, được giữ lại trong các thao tác này. Một phương pháp cũng có sẵn để [xuất hình ảnh của biểu đồ](/slides/vi/nodejs-java/create-shape-thumbnails/) riêng.