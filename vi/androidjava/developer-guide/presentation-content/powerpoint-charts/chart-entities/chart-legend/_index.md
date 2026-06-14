---
title: Tùy chỉnh chú giải biểu đồ trong các bản trình bày trên Android
linktitle: Chú giải biểu đồ
type: docs
url: /vi/androidjava/chart-legend/
keywords:
- chú giải biểu đồ
- vị trí chú giải
- kích thước phông chữ
- PowerPoint
- bản trình bày
- Android
- Java
- Aspose.Slides
description: "Tùy chỉnh chú giải biểu đồ với Aspose.Slides cho Android qua Java để tối ưu hóa các bản trình bày PowerPoint với định dạng chú giải được điều chỉnh riêng."
---
## **Tổng quan**

Aspose.Slides cung cấp các tùy chọn để tùy chỉnh chú giải biểu đồ trong các bản trình bày PowerPoint. Bài viết này hướng dẫn cách đặt vị trí và kích thước cho chú giải, thiết lập kích thước phông chữ cho toàn bộ chú giải và áp dụng định dạng cho một mục chú giải riêng lẻ.

Nó cũng đề cập đến một số hành vi liên quan trong phần Câu hỏi thường gặp, bao gồm việc sử dụng chế độ không chồng lấp để vùng vẽ nhường chỗ cho chú giải, cho phép các nhãn chú giải dài tự động ngắt dòng hoặc sử dụng ngắt dòng thủ công, và cho phép định dạng chú giải kế thừa từ giao diện chủ đề của bản trình bày khi không đặt các thiết lập màu chữ và nền cụ thể.

## **Vị trí Chú giải**
Để thiết lập các thuộc tính của chú giải, vui lòng thực hiện theo các bước dưới đây:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
- Lấy tham chiếu của slide.
- Thêm biểu đồ vào slide.
- Thiết lập các thuộc tính của chú giải.
- Ghi bản trình bày dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã thiết lập vị trí và kích thước cho chú giải biểu đồ.

```java
// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation();
try {
    // Lấy tham chiếu của slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Thêm biểu đồ cột nhóm vào slide
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // Đặt thuộc tính cho Chú giải
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // Ghi bản trình bày ra đĩa
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Thiết lập Kích thước Phông chữ cho Chú giải**
Aspose.Slides cho Android qua Java cho phép các nhà phát triển thiết lập kích thước phông chữ của chú giải. Vui lòng thực hiện theo các bước dưới đây:

- Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
- Tạo biểu đồ mặc định.
- Thiết lập kích thước phông chữ.
- Thiết lập giá trị trục tối thiểu.
- Thiết lập giá trị trục tối đa.
- Ghi bản trình bày ra đĩa.

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

## **Thiết lập Kích thước Phông chữ cho Mục Chú giải Riêng lẻ**
Aspose.Slides cho Android qua Java cho phép các nhà phát triển thiết lập kích thước phông chữ của các mục chú giải riêng lẻ. Vui lòng thực hiện theo các bước dưới đây:

- Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
- Tạo biểu đồ mặc định.
- Truy cập mục chú giải.
- Thiết lập kích thước phông chữ.
- Thiết lập giá trị trục tối thiểu.
- Thiết lập giá trị trục tối đa.
- Ghi bản trình bày ra đĩa.

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

## **Câu hỏi thường gặp**

**Tôi có thể bật chú giải để biểu đồ tự động phân bổ không gian cho nó thay vì chồng lên không?**

Có. Sử dụng chế độ không chồng lấp ([setOverlay(false)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/legend/#setOverlay-boolean-)); trong trường hợp này, vùng vẽ sẽ thu nhỏ để nhường chỗ cho chú giải.

**Tôi có thể tạo nhãn chú giải đa dòng không?**

Có. Các nhãn dài sẽ tự động ngắt dòng khi không đủ không gian; việc chèn ngắt dòng bắt buộc được hỗ trợ bằng ký tự xuống dòng trong tên chuỗi.

**Làm thế nào để chú giải tuân theo bảng màu của giao diện chủ đề bản trình bày?**

Không đặt màu/vùng nền/phông chữ cụ thể cho chú giải hoặc văn bản của nó. Khi đó chúng sẽ kế thừa từ chủ đề và cập nhật đúng khi thiết kế thay đổi.