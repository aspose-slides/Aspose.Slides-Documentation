---
title: "Tùy chỉnh chú giải biểu đồ trong bài thuyết trình bằng JavaScript"
linktitle: "Chú giải biểu đồ"
type: docs
url: /vi/nodejs-java/chart-legend/
keywords:
- "chú giải biểu đồ"
- "vị trí chú giải"
- "kích thước phông chữ"
- "PowerPoint"
- "bài thuyết trình"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Tùy chỉnh chú giải biểu đồ với JavaScript và Aspose.Slides cho Node.js để tối ưu hóa các bài thuyết trình PowerPoint với định dạng chú giải được cá nhân hoá."
---
## **Tổng quan**

Aspose.Slides cung cấp các tùy chọn để tùy chỉnh chú giải biểu đồ trong các bài thuyết trình PowerPoint. Bài viết này hướng dẫn cách đặt vị trí và kích thước của chú giải, đặt kích thước phông chữ cho toàn bộ chú giải và áp dụng định dạng cho một mục chú giải riêng lẻ.

Nó cũng đề cập đến một số hành vi liên quan trong phần Câu hỏi thường gặp, bao gồm việc sử dụng chế độ không chồng lên để khu vực vẽ dành chỗ cho chú giải, cho phép nhãn chú giải dài tự động ngắt dòng hoặc sử dụng ký tự ngắt dòng, và cho phép định dạng chú giải kế thừa từ giao diện chủ đề của bài thuyết trình khi không thiết lập màu chữ, màu nền hay phông chữ cụ thể.

## **Định vị Chú giải**

Để đặt các thuộc tính của chú giải, hãy thực hiện các bước sau:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
- Lấy tham chiếu tới slide.
- Thêm biểu đồ vào slide.
- Đặt các thuộc tính cho chú giải.
- Ghi bài thuyết trình dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã thiết lập vị trí và kích thước cho chú giải biểu đồ.

```javascript
// Tạo một thể hiện của lớp Presentation
var pres = new aspose.slides.Presentation();
try {
    // Lấy tham chiếu của slide
    var slide = pres.getSlides().get_Item(0);
    // Thêm biểu đồ cột cụm trên slide
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);
    // Đặt thuộc tính cho Legend
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    // Ghi bài thuyết trình ra đĩa
    pres.save("Legend_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Đặt Kích Thước Phông Chữ cho Chú Giải**

Aspose.Slides cho Node.js qua Java cho phép các nhà phát triển đặt kích thước phông chữ của chú giải. Vui lòng thực hiện các bước sau:

- Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
- Tạo biểu đồ mặc định.
- Đặt kích thước phông chữ.
- Đặt giá trị tối thiểu cho trục.
- Đặt giá trị tối đa cho trục.
- Ghi bài thuyết trình ra đĩa.

```javascript
// Tạo một thể hiện của lớp Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Đặt Kích Thước Phông Chữ cho Mục Chú Giải Riêng Lẻ**

Aspose.Slides cho Node.js qua Java cho phép các nhà phát triển đặt kích thước phông chữ cho từng mục chú giải riêng lẻ. Vui lòng thực hiện các bước sau:

- Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
- Tạo biểu đồ mặc định.
- Truy cập mục chú giải.
- Đặt kích thước phông chữ.
- Đặt giá trị tối thiểu cho trục.
- Đặt giá trị tối đa cho trục.
- Ghi bài thuyết trình ra đĩa.

```javascript
// Tạo một thể hiện của lớp Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();
    tf.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Can I enable the legend so that the chart automatically allocates space for it instead of overlaying it?**

Có. Sử dụng chế độ không chồng lên ([setOverlay(false)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/legend/setoverlay/)); trong trường hợp này, khu vực vẽ sẽ thu nhỏ để chứa chú giải.

**Can I make multi-line legend labels?**

Có. Nhãn dài sẽ tự động ngắt dòng khi không đủ không gian; các ngắt dòng buộc được hỗ trợ bằng ký tự xuống dòng trong tên chuỗi.

**How do I make the legend follow the presentation theme’s color scheme?**

Không đặt màu/ràu nền/phông chữ cụ thể cho chú giải hoặc văn bản của nó. Khi đó chúng sẽ kế thừa từ chủ đề và tự động cập nhật đúng khi thiết kế thay đổi.