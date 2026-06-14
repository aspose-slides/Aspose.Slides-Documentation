---
title: Hoạt ảnh Văn bản PowerPoint trong JavaScript
linktitle: Văn bản Động
type: docs
weight: 60
url: /vi/nodejs-java/animated-text/
keywords:
- văn bản động
- hoạt ảnh văn bản
- đoạn văn bản động
- hoạt ảnh đoạn văn
- hiệu ứng hoạt ảnh
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tạo văn bản hoạt ảnh động trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Node.js, với các ví dụ mã tối ưu, dễ hiểu."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với văn bản hoạt ảnh trong Aspose.Slides bằng cách áp dụng các hiệu ứng hoạt ảnh cho từng đoạn và truy xuất các hiệu ứng đã được gán cho các đoạn trong một khung văn bản. Nó tập trung vào các phương thức API được sử dụng để thêm hoạt ảnh cấp đoạn và kiểm tra các hiệu ứng hoạt ảnh đoạn hiện có trong một bản trình chiếu.

## **Thêm hiệu ứng hoạt ảnh vào các đoạn văn**

Chúng tôi đã thêm phương thức [**addEffect()**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Sequence#addEffect-aspose.slides.IParagraph-int-int-int-) vào các lớp [**Sequence**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Sequence) và [**Sequence**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Sequence). Phương thức này cho phép bạn thêm hiệu ứng hoạt ảnh vào một đoạn duy nhất. Đoạn mã mẫu này cho thấy cách thêm hiệu ứng hoạt ảnh vào một đoạn văn:

```javascript
var presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // chọn đoạn văn để thêm hiệu ứng
    var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    // thêm hiệu ứng hoạt ảnh Fly vào đoạn văn đã chọn
    var effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    presentation.save("AnimationEffectinParagraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Lấy các hiệu ứng hoạt ảnh trong các đoạn văn**

Bạn có thể muốn tìm hiểu các hiệu ứng hoạt ảnh đã được thêm vào một đoạn — ví dụ, trong một trường hợp, bạn muốn lấy các hiệu ứng hoạt ảnh trong một đoạn vì bạn dự định áp dụng các hiệu ứng đó vào một đoạn hoặc hình dạng khác.

Aspose.Slides cho Node.js thông qua Java cho phép bạn lấy tất cả các hiệu ứng hoạt ảnh được áp dụng cho các đoạn chứa trong một khung văn bản (hình). Đoạn mã mẫu này cho thấy cách lấy các hiệu ứng hoạt ảnh trong một đoạn:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    for (let i = 0; i < autoShape.getTextFrame().getParagraphs().getCount(); i++) {
        let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(i);
        var effects = sequence.getEffectsByParagraph(paragraph);
        if (effects.length > 0) {
            console.log("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
        }
    }
} finally {
    pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Hiệu ứng hoạt ảnh văn bản khác với chuyển tiếp slide như thế nào, và chúng có thể kết hợp được không?**

Hoạt ảnh văn bản kiểm soát hành vi của đối tượng theo thời gian trên một slide, trong khi [transitions](/slides/vi/nodejs-java/slide-transition/) kiểm soát cách các slide chuyển đổi. Chúng độc lập và có thể được sử dụng cùng nhau; thứ tự phát lại được điều khiển bởi thời gian biểu hoạt ảnh và cài đặt chuyển tiếp.

**Các hiệu ứng hoạt ảnh văn bản có được giữ lại khi xuất ra PDF hoặc hình ảnh không?**

Không. PDF và hình ảnh raster là tĩnh, vì vậy bạn sẽ chỉ thấy một trạng thái duy nhất của slide mà không có chuyển động. Để giữ lại chuyển động, hãy sử dụng xuất [video](/slides/vi/nodejs-java/convert-powerpoint-to-video/) hoặc [HTML](/slides/vi/nodejs-java/export-to-html5/).

**Hiệu ứng hoạt ảnh văn bản có hoạt động trong bố cục và master slide không?**

Các hiệu ứng được áp dụng cho các đối tượng bố cục/master được kế thừa bởi các slide, nhưng thời gian và sự tương tác của chúng với các hoạt ảnh cấp slide phụ thuộc vào chuỗi cuối cùng trên slide.