---
title: Tạo hoạt ảnh văn bản PowerPoint trong Java
linktitle: Văn bản hoạt hình
type: docs
weight: 60
url: /vi/java/animated-text/
keywords:
- văn bản hoạt hình
- hoạt ảnh văn bản
- đoạn văn hoạt hình
- hoạt ảnh đoạn văn
- hiệu ứng hoạt ảnh
- PowerPoint
- OpenDocument
- bản trình bày
- Java
- Aspose.Slides
description: "Tạo văn bản hoạt hình động trong các bản trình bày PowerPoint và OpenDocument bằng Aspose.Slides cho Java, với các ví dụ mã Java dễ hiểu và được tối ưu."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với văn bản hoạt hình trong Aspose.Slides bằng cách áp dụng hiệu ứng hoạt hình cho các đoạn văn riêng lẻ và truy xuất các hiệu ứng đã được gán cho các đoạn trong một khung văn bản. Nó tập trung vào các phương thức API được dùng để thêm hoạt hình cấp đoạn và kiểm tra các hiệu ứng hoạt hình đoạn hiện có trong một bản trình bày.

## **Thêm hiệu ứng hoạt hình vào các đoạn**

Chúng tôi đã thêm phương thức [**addEffect()**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) vào các lớp [**Sequence**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Sequence) và [**ISequence**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISequence). Phương thức này cho phép bạn thêm hiệu ứng hoạt hình vào một đoạn văn duy nhất. Đoạn mã mẫu sau cho thấy cách thêm một hiệu ứng hoạt hình vào một đoạn văn:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // chọn đoạn văn để thêm hiệu ứng
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // thêm hiệu ứng hoạt ảnh Fly vào đoạn văn đã chọn
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Lấy hiệu ứng hoạt hình của các đoạn**

Bạn có thể muốn tìm hiểu các hiệu ứng hoạt hình đã được thêm vào một đoạn văn — ví dụ, trong một trường hợp, bạn muốn lấy các hiệu ứng hoạt hình trong một đoạn vì bạn dự định áp dụng các hiệu ứng đó cho một đoạn khác hoặc hình dạng khác.

Aspose.Slides for Java cho phép bạn lấy tất cả các hiệu ứng hoạt hình được áp dụng cho các đoạn văn chứa trong một khung văn bản (hình). Đoạn mã mẫu sau cho thấy cách lấy các hiệu ứng hoạt hình trong một đoạn:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    IAutoShape autoShape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
    {
        IEffect[] effects = sequence.getEffectsByParagraph(paragraph);

        if (effects.length > 0)
            System.out.println("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
    }
} finally {
    pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Hoạt hình văn bản khác với chuyển tiếp slide như thế nào, và chúng có thể được kết hợp không?**

Hoạt hình văn bản kiểm soát hành vi của đối tượng theo thời gian trên một slide, trong khi [transitions](/slides/vi/java/slide-transition/) kiểm soát cách các slide thay đổi. Chúng độc lập và có thể được sử dụng cùng nhau; thứ tự phát được điều khiển bởi dòng thời gian hoạt hình và cài đặt chuyển tiếp.

**Các hoạt hình văn bản có được bảo tồn khi xuất sang PDF hoặc hình ảnh không?**

Không. PDF và hình ảnh raster là tĩnh, vì vậy bạn sẽ chỉ thấy một trạng thái duy nhất của slide mà không có chuyển động. Để giữ chuyển động, hãy sử dụng xuất sang [video](/slides/vi/java/convert-powerpoint-to-video/) hoặc [HTML](/slides/vi/java/export-to-html5/).

**Các hoạt hình văn bản có hoạt động trong bố cục và master slide không?**

Các hiệu ứng được áp dụng cho các đối tượng bố cục/master sẽ được kế thừa bởi các slide, nhưng thời gian và cách chúng tương tác với các hoạt hình cấp slide phụ thuộc vào chuỗi cuối cùng trên slide.