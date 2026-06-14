---
title: Thêm Đường Xu Hướng vào Biểu Đồ Bản Trình Chiếu trên Android
linktitle: Đường Xu Hướng
type: docs
url: /vi/androidjava/trend-line/
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
- Android
- Java
- Aspose.Slides
description: "Nhanh chóng thêm và tùy chỉnh các đường xu hướng trong biểu đồ PowerPoint với Aspose.Slides cho Android via Java — một hướng dẫn thực tế để thu hút khán giả của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách thêm các đường xu hướng vào biểu đồ trong bản trình chiếu bằng cách sử dụng Aspose.Slides. Nó hướng dẫn cách tạo biểu đồ, thêm đường xu hướng vào chuỗi dữ liệu của biểu đồ và làm việc với một số loại đường xu hướng, bao gồm hàm mũ, tuyến tính, logarit, trung bình động, đa thức và lũy thừa.

Ngoài ra, bài viết còn mô tả cách thêm một đường tùy chỉnh vào biểu đồ bằng cách chèn một hình dạng đường thẳng, và cung cấp một phần FAQ ngắn về các giá trị chiếu hướng tiến và lùi của đường xu hướng cũng như việc các đường xu hướng có được giữ lại khi xuất sang PDF hoặc SVG và khi render biểu đồ dưới dạng hình ảnh hay không.

## **Thêm Đường Xu Hướng**
Aspose.Slides for Android via Java cung cấp API đơn giản để quản lý các Đường Xu Hướng của biểu đồ:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
1. Lấy tham chiếu đến một slide bằng chỉ số của nó.
1. Thêm một biểu đồ với dữ liệu mặc định cùng với bất kỳ kiểu nào mong muốn (ví dụ này sử dụng ChartType.ClusteredColumn).
1. Thêm đường xu hướng hàm mũ cho chuỗi biểu đồ 1.
1. Thêm đường xu hướng tuyến tính cho chuỗi biểu đồ 1.
1. Thêm đường xu hướng logarit cho chuỗi biểu đồ 2.
1. Thêm đường xu hướng trung bình động cho chuỗi biểu đồ 2.
1. Thêm đường xu hướng đa thức cho chuỗi biểu đồ 3.
1. Thêm đường xu hướng lũy thừa cho chuỗi biểu đồ 3.
1. Ghi bản trình chiếu đã chỉnh sửa ra tệp PPTX.

Đoạn mã sau được sử dụng để tạo biểu đồ với các Đường Xu Hướng.

```java
// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation();
try {
    // Tạo một biểu đồ cột nhóm
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // Thêm đường xu hướng hàm mũ cho chuỗi biểu đồ 1
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // Thêm đường xu hướng tuyến tính cho chuỗi biểu đồ 1
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // Thêm đường xu hướng logarit cho chuỗi biểu đồ 2
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    
    // Thêm đường xu hướng trung bình động cho chuỗi biểu đồ 2
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    
    // Thêm đường xu hướng đa thức cho chuỗi biểu đồ 3
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // Thêm đường xu hướng lũy thừa cho chuỗi biểu đồ 3
    ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);
    tredLinePower.setTrendlineType(TrendlineType.Power);
    tredLinePower.setBackward(1);
    
    // Lưu bản trình chiếu
    pres.save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Thêm Đường Tùy Chỉnh**
Aspose.Slides for Android via Java cung cấp API đơn giản để thêm các đường tùy chỉnh vào biểu đồ. Để thêm một đường thẳng đơn giản vào slide đã chọn của bản trình chiếu, vui lòng thực hiện các bước sau:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
- Lấy tham chiếu đến một slide bằng cách sử dụng chỉ số của nó.
- Tạo một biểu đồ mới bằng phương thức AddChart được cung cấp bởi đối tượng Shapes.
- Thêm một AutoShape loại Line bằng phương thức AddAutoShape được cung cấp bởi đối tượng Shapes.
- Thiết lập màu sắc cho các đường của hình dạng.
- Ghi bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Đoạn mã sau được sử dụng để tạo biểu đồ với Đường Tùy Chỉnh.

```java
// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight()/2, chart.getWidth(), 0);
    
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.awt.Color.RED);
    
    pres.save("Presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**‘forward’ và ‘backward’ có nghĩa là gì đối với một đường xu hướng?**

Chúng là độ dài của đường xu hướng được chiếu tiến hoặc lùi: đối với biểu đồ scatter (XY) — tính bằng đơn vị trục; đối với các biểu đồ không phải scatter — tính bằng số danh mục. Chỉ cho phép các giá trị không âm.

**Đường xu hướng có được giữ lại khi xuất bản trình chiếu sang PDF hoặc SVG, hoặc khi render slide thành hình ảnh không?**

Có. Aspose.Slides chuyển đổi bản trình chiếu sang [PDF](/slides/vi/androidjava/convert-powerpoint-to-pdf/)/[SVG](/slides/vi/androidjava/render-a-slide-as-an-svg-image/) và render các biểu đồ thành hình ảnh; các đường xu hướng, như một phần của biểu đồ, được giữ lại trong các thao tác này. Một phương thức cũng có sẵn để [xuất ảnh của biểu đồ](/slides/vi/androidjava/create-shape-thumbnails/).