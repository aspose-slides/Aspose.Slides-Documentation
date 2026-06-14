---
title: Tùy chỉnh chú giải biểu đồ trong bản trình bày bằng Java
linktitle: Chú giải biểu đồ
type: docs
url: /vi/java/chart-legend/
keywords:
- chú giải biểu đồ
- vị trí chú giải
- kích thước phông chữ
- PowerPoint
- bản trình bày
- Java
- Aspose.Slides
description: "Tùy chỉnh chú giải biểu đồ với Aspose.Slides cho Java để tối ưu hóa bản trình bày PowerPoint với định dạng chú giải được tùy chỉnh."
---
## **Overview**

Aspose.Slides cung cấp các tùy chọn để tùy chỉnh chú giải biểu đồ trong các bản trình bày PowerPoint. Bài viết này trình bày cách định vị và thay đổi kích thước của chú giải, đặt kích thước phông chữ cho toàn bộ chú giải, và áp dụng định dạng cho một mục chú giải riêng lẻ.

Nó cũng bao phủ một số hành vi liên quan trong mục FAQ, bao gồm việc sử dụng chế độ không chồng lên để khu vực vẽ (plot area) tạo chỗ cho chú giải, cho phép các nhãn chú giải dài tự động xuống dòng hoặc dùng ký tự ngắt dòng, và để định dạng chú giải kế thừa từ giao diện chủ đề của bản trình bày khi không thiết lập màu, độ đầy và phông chữ một cách rõ ràng.

## **Legend Positioning**
Để đặt các thuộc tính của chú giải. Vui lòng làm theo các bước dưới đây:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
- Lấy tham chiếu của slide.
- Thêm một biểu đồ vào slide.
- Đặt các thuộc tính của chú giải.
- Ghi bản trình bày dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã đặt vị trí và kích thước cho chú giải biểu đồ.

```java
// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation();
try {
    // Lấy tham chiếu của slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Thêm biểu đồ cột nhóm vào slide
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // Đặt thuộc tính của chú giải
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // Ghi bản trình bày vào đĩa
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set the Font Size of a Legend**
Aspose.Slides for Java cho phép các nhà phát triển thiết lập kích thước phông chữ của chú giải. Vui lòng làm theo các bước dưới đây:

- Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
- Tạo biểu đồ mặc định.
- Đặt kích thước phông chữ.
- Đặt giá trị trục tối thiểu.
- Đặt giá trị trục tối đa.
- Ghi bản trình bày vào đĩa.

```java
// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);

    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set the Font Size of an Individual Legend**
Aspose.Slides for Java cho phép các nhà phát triển thiết lập kích thước phông chữ cho các mục chú giải riêng lẻ. Vui lòng làm theo các bước dưới đây:

- Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
- Tạo biểu đồ mặc định.
- Truy cập mục chú giải.
- Đặt kích thước phông chữ.
- Đặt giá trị trục tối thiểu.
- Đặt giá trị trục tối đa.
- Ghi bản trình bày vào đĩa.

```java
// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IChartTextFormat tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    tf.getPortionFormat().setFontBold(NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Can I enable the legend so that the chart automatically allocates space for it instead of overlaying it?**

Có. Sử dụng chế độ không chồng lên ([setOverlay(false)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/legend/#setOverlay-boolean-)); trong trường hợp này, khu vực vẽ sẽ thu hẹp để chứa chú giải.

**Can I make multi-line legend labels?**

Có. Các nhãn dài sẽ tự động xuống dòng khi không đủ không gian; việc buộc ngắt dòng được hỗ trợ thông qua ký tự xuống dòng trong tên series.

**How do I make the legend follow the presentation theme’s color scheme?**

Không thiết lập màu sắc/độ đầy/phông chữ một cách rõ ràng cho chú giải hoặc văn bản của nó. Khi đó chúng sẽ kế thừa từ chủ đề và cập nhật đúng khi thiết kế thay đổi.