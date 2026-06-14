---
title: Thêm Đường Xu Hướng vào Biểu Đồ Trình Chiếu trong Java
linktitle: Đường Xu Hướng
type: docs
url: /vi/java/trend-line/
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
- Java
- Aspose.Slides
description: "Nhanh chóng thêm và tùy chỉnh các đường xu hướng trong biểu đồ PowerPoint bằng Aspose.Slides cho Java — một hướng dẫn thực tiễn để thu hút khán giả của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách thêm các đường xu hướng vào biểu đồ trong bản trình diễn bằng cách sử dụng Aspose.Slides. Nó cho thấy cách tạo biểu đồ, thêm đường xu hướng vào các chuỗi biểu đồ và làm việc với một số loại đường xu hướng, bao gồm hàm mũ, tuyến tính, logarit, trung bình động, đa thức và lũy thừa.

Nó cũng mô tả cách thêm một đường tùy chỉnh vào biểu đồ bằng cách chèn một hình dạng đường thẳng, và bao gồm một phần Câu hỏi thường gặp ngắn về giá trị chiếu tuyến xu hướng về phía trước và phía sau và việc các đường xu hướng có được giữ lại khi xuất ra PDF hoặc SVG và khi kết xuất biểu đồ thành hình ảnh hay không.

## **Thêm Đường Xu Hướng**
Aspose.Slides for Java cung cấp một API đơn giản để quản lý các Đường Xu Hướng biểu đồ khác nhau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
2. Lấy tham chiếu của một slide bằng chỉ mục của nó.
3. Thêm một biểu đồ với dữ liệu mặc định cùng với bất kỳ loại nào mong muốn (ví dụ này sử dụng ChartType.ClusteredColumn).
4. Thêm đường xu hướng hàm mũ cho chuỗi biểu đồ 1.
5. Thêm đường xu hướng tuyến tính cho chuỗi biểu đồ 1.
6. Thêm đường xu hướng logarit cho chuỗi biểu đồ 2.
7. Thêm đường xu hướng trung bình động cho chuỗi biểu đồ 2.
8. Thêm đường xu hướng đa thức cho chuỗi biểu đồ 3.
9. Thêm đường xu hướng lũy thừa cho chuỗi biểu đồ 3.
10. Ghi bản trình diễn đã sửa đổi vào tệp PPTX.

Mã sau được sử dụng để tạo một biểu đồ với các Đường Xu Hướng.

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
Aspose.Slides for Java cung cấp một API đơn giản để thêm các đường tùy chỉnh vào biểu đồ. Để thêm một đường thẳng đơn giản vào slide đã chọn của bản trình diễn, vui lòng thực hiện các bước sau:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation)
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó
- Tạo một biểu đồ mới bằng phương thức AddChart được cung cấp bởi đối tượng Shapes
- Thêm một AutoShape kiểu Đường bằng phương thức AddAutoShape được cung cấp bởi đối tượng Shapes
- Đặt màu cho các đường của hình dạng.
- Ghi bản trình diễn đã sửa đổi dưới dạng tệp PPTX

Mã sau được sử dụng để tạo một biểu đồ với các Đường Tùy Chỉnh.

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

## **Câu hỏi thường gặp**

**'Forward' và 'backward' có nghĩa là gì đối với một đường xu hướng?**

Chúng là độ dài của đường xu hướng được chiếu ra phía trước/phía sau: đối với biểu đồ phân tán (XY) — tính bằng đơn vị trục; đối với các biểu đồ không phải phân tán — tính bằng số lượng danh mục. Chỉ cho phép các giá trị không âm.

**Liệu đường xu hướng có được giữ lại khi xuất bản trình diễn sang PDF hoặc SVG, hoặc khi kết xuất một slide thành hình ảnh không?**

Có. Aspose.Slides chuyển đổi bản trình diễn sang [PDF](/slides/vi/java/convert-powerpoint-to-pdf/)/[SVG](/slides/vi/java/render-a-slide-as-an-svg-image/) và kết xuất các biểu đồ thành hình ảnh; các đường xu hướng, như một phần của biểu đồ, được giữ lại trong các thao tác này. Một phương thức cũng có sẵn để [xuất hình ảnh của biểu đồ](/slides/vi/java/create-shape-thumbnails/) riêng biệt.