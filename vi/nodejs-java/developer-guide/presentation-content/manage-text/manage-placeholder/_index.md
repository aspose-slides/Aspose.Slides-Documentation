---
title: Quản lý các trình giữ chỗ trong bản trình chiếu bằng JavaScript
linktitle: Quản lý Trình giữ chỗ
type: docs
weight: 10
url: /vi/nodejs-java/manage-placeholder/
keywords:
- trình giữ chỗ
- trình giữ chỗ văn bản
- trình giữ chỗ hình ảnh
- trình giữ chỗ biểu đồ
- văn bản gợi ý
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Quản lý trình giữ chỗ một cách dễ dàng trong Aspose.Slides cho Node.js qua Java: thay thế văn bản, tùy chỉnh gợi ý và đặt độ trong suốt hình ảnh trong PowerPoint và OpenDocument."
---
## **Tổng quan**

Aspose.Slides cho phép bạn quản lý các placeholder trong bản trình chiếu một cách lập trình. Bài viết này giải thích cách tìm placeholder trên các slide và thay đổi văn bản của chúng, đặt văn bản gợi ý tùy chỉnh cho các layout placeholder, và điều chỉnh độ trong suốt của hình ảnh được sử dụng làm nền cho placeholder. Nó cũng bao gồm một phần FAQ ngắn giải thích sự khác biệt giữa base placeholder và local shape, mô tả cách thay đổi placeholder có thể được áp dụng qua layout hoặc master, và chỉ dẫn quản lý placeholder tiêu đề và chân trang.

## **Thay đổi văn bản trong Placeholder**

Sử dụng [Aspose.Slides for Node.js via Java](/slides/vi/nodejs-java/), bạn có thể tìm và sửa đổi các placeholder trên các slide trong bản trình chiếu. Aspose.Slides cho phép bạn thay đổi văn bản trong một placeholder.

**Prerequisite**: Bạn cần một bản trình chiếu có chứa placeholder. Bạn có thể tạo bản trình chiếu như vậy bằng ứng dụng Microsoft PowerPoint tiêu chuẩn.

Đây là cách bạn sử dụng Aspose.Slides để thay thế văn bản trong placeholder của bản trình chiếu đó:

1. Khởi tạo lớp [`Presentation`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation). và truyền bản trình chiếu làm đối số.
2. Lấy tham chiếu slide thông qua chỉ mục của nó.
3. Duyệt qua các shape để tìm placeholder.
4. Ép kiểu shape placeholder thành một [`AutoShape`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/AutoShape) và thay đổi văn bản bằng cách sử dụng [`TextFrame`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/TextFrame) gắn với [`AutoShape`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/AutoShape).
5. Lưu bản trình chiếu đã sửa đổi.

```javascript
// Tạo một lớp Presentation
var pres = new aspose.slides.Presentation("ReplacingText.pptx");
try {
    // Truy cập slide đầu tiên
    var sld = pres.getSlides().get_Item(0);
    // Duyệt qua các shape để tìm placeholder
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (shp.getPlaceholder() != null) {
            // Thay đổi văn bản trong mỗi placeholder
            shp.getTextFrame().setText("This is Placeholder");
        }
    }
    // Lưu bản trình chiếu vào đĩa
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Đặt Văn bản Gợi ý trong Placeholder**

Các layout chuẩn và đã được xây dựng sẵn chứa văn bản gợi ý placeholder như ***Click to add a title*** hoặc ***Click to add a subtitle***. Sử dụng Aspose.Slides, bạn có thể chèn văn bản gợi ý mà bạn muốn vào các layout placeholder.

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // Duyệt qua slide
    for (let i = 0; i < slide.getSlide().getShapes().size(); i++) {
        let shape = slide.getSlide().getShapes().get_Item(i);
        if ((shape.getPlaceholder() != null) && (java.instanceOf(shape, "com.aspose.slides.AutoShape"))) {
            var text = "";
            // PowerPoint hiển thị "Click to add title"
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.CenteredTitle) {
                text = "Add Title";
            } else // Thêm phụ đề
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.Subtitle) {
                text = "Add Subtitle";
            }
            shape.getTextFrame().setText(text);
            console.log("Placeholder with text: " + text);
        }
    }
    pres.save("Placeholders_PromptText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Đặt Độ trong Suất Hình ảnh Placeholder**

Aspose.Slides cho phép bạn đặt độ trong suốt của hình ảnh nền trong một placeholder văn bản. Bằng cách điều chỉnh độ trong suốt của hình trong khung như vậy, bạn có thể làm nổi bật văn bản hoặc hình ảnh (tùy thuộc vào màu của văn bản và hình ảnh).

```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (var i = 0; i < operationCollection.size(); i++) {
    if (java.instanceOf(operationCollection.get_Item(i), "com.aspose.slides.AlphaModulateFixed")) {
        var alphaModulate = operationCollection.get_Item(i);
        var currentValue = 100 - alphaModulate.getAmount();
        console.log("Current transparency value: " + currentValue);
        var alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}
presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
```

## **FAQ**

**Base placeholder là gì, và nó khác gì so với local shape trên slide?**

Base placeholder là shape gốc trên layout hoặc master mà shape của slide kế thừa—kiểu, vị trí và một số định dạng được lấy từ nó. Local shape là độc lập; nếu không có base placeholder, việc kế thừa sẽ không áp dụng.

**Làm thế nào để cập nhật tất cả tiêu đề hoặc chú thích trong toàn bộ bản trình chiếu mà không phải duyệt qua từng slide?**

Chỉnh sửa placeholder tương ứng trên layout hoặc master. Các slide dựa trên các layout/master đó sẽ tự động kế thừa thay đổi.

**Làm sao để kiểm soát các placeholder tiêu đề/chân trang tiêu chuẩn—ngày & giờ, số slide, và văn bản chân trang?**

Sử dụng các trình quản lý HeaderFooter ở phạm vi thích hợp (slide thường, layout, master, ghi chú/handout) để bật hoặc tắt các placeholder đó và đặt nội dung của chúng.