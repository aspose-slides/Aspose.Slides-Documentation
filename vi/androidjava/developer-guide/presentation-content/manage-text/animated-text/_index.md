---
title: Hoạt hình văn bản PowerPoint trên Android
linktitle: Văn bản hoạt hình
type: docs
weight: 60
url: /vi/androidjava/animated-text/
keywords:
- văn bản hoạt hình
- hoạt hình văn bản
- đoạn văn hoạt hình
- hoạt hình đoạn văn
- hiệu ứng hoạt hình
- PowerPoint
- OpenDocument
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Tạo văn bản hoạt hình động trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Android, với các ví dụ mã Java tối ưu, dễ hiểu."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với văn bản động trong Aspose.Slides bằng cách áp dụng hiệu ứng hoạt hình cho các đoạn văn riêng lẻ và lấy các hiệu ứng đã được gán cho các đoạn trong một khung văn bản. Nó tập trung vào các phương thức API được sử dụng để thêm hoạt hình ở mức đoạn và kiểm tra các hiệu ứng hoạt hình đoạn hiện có trong một bản trình chiếu.

## **Thêm hiệu ứng hoạt hình cho các đoạn văn**

Chúng tôi đã thêm phương thức [**addEffect()**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) vào các lớp [**Sequence**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Sequence) và [**ISequence**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISequence). Phương thức này cho phép bạn thêm hiệu ứng hoạt hình vào một đoạn văn duy nhất. Đoạn mã mẫu sau cho thấy cách thêm một hiệu ứng hoạt hình vào một đoạn văn:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // chọn đoạn để thêm hiệu ứng
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // thêm hiệu ứng hoạt hình Fly vào đoạn đã chọn
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Lấy hiệu ứng hoạt hình của các đoạn văn**

Bạn có thể muốn tìm hiểu các hiệu ứng hoạt hình đã được thêm vào một đoạn văn—ví dụ, trong một kịch bản, bạn muốn lấy các hiệu ứng hoạt hình trong một đoạn vì bạn dự định áp dụng các hiệu ứng đó cho một đoạn hoặc hình dạng khác.

Aspose.Slides for Android thông qua Java cho phép bạn lấy tất cả các hiệu ứng hoạt hình được áp dụng cho các đoạn văn nằm trong một khung văn bản (hình dạng). Đoạn mã mẫu sau cho thấy cách lấy các hiệu ứng hoạt hình trong một đoạn văn:

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

**Các hoạt hình văn bản khác với chuyển đổi slide như thế nào, và chúng có thể được kết hợp không?**

Các hoạt hình văn bản điều khiển hành vi của đối tượng theo thời gian trên một slide, trong khi [chuyển đổi](/slides/vi/androidjava/slide-transition/) điều khiển cách các slide thay đổi. Chúng độc lập và có thể được sử dụng cùng nhau; thứ tự phát lại được quyết định bởi dòng thời gian hoạt hình và cài đặt chuyển đổi.

**Các hoạt hình văn bản có được giữ lại khi xuất sang PDF hoặc hình ảnh không?**

Không. PDF và hình ảnh raster là tĩnh, vì vậy bạn sẽ chỉ thấy một trạng thái duy nhất của slide mà không có chuyển động. Để giữ lại chuyển động, hãy sử dụng xuất [video](/slides/vi/androidjava/convert-powerpoint-to-video/) hoặc [HTML](/slides/vi/androidjava/export-to-html5/).

**Các hoạt hình văn bản có hoạt động trong bố cục và slide master không?**

Các hiệu ứng được áp dụng cho các đối tượng bố cục/master sẽ được kế thừa bởi các slide, nhưng thời gian và tương tác của chúng với các hoạt hình ở mức slide phụ thuộc vào chuỗi cuối cùng trên slide.