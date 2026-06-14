---
title: Tạo hoạt ảnh văn bản PowerPoint trong PHP
linktitle: Văn bản hoạt ảnh
type: docs
weight: 60
url: /vi/php-java/animated-text/
keywords:
- văn bản hoạt ảnh
- hoạt ảnh văn bản
- đoạn văn hoạt ảnh
- hoạt ảnh đoạn văn
- hiệu ứng hoạt ảnh
- PowerPoint
- OpenDocument
- bản trình bày
- PHP
- Aspose.Slides
description: "Tạo văn bản hoạt ảnh động trong các bản trình bày PowerPoint và OpenDocument bằng cách sử dụng Aspose.Slides cho PHP thông qua Java, với các ví dụ mã dễ hiểu và được tối ưu."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với văn bản hoạt hình trong Aspose.Slides bằng cách áp dụng hiệu ứng hoạt hình cho từng đoạn văn và truy xuất các hiệu ứng đã được gán cho các đoạn trong một khung văn bản. Nó tập trung vào các phương thức API được dùng để thêm hoạt hình ở mức đoạn và kiểm tra các hiệu ứng hoạt hình đoạn hiện có trong một bản trình bày.

## **Thêm hiệu ứng hoạt hình cho đoạn văn**

Chúng tôi đã thêm phương thức [**addEffect()**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) vào lớp [**Sequence**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Sequence). Phương thức này cho phép bạn thêm hiệu ứng hoạt hình vào một đoạn văn duy nhất. Đoạn mã mẫu này cho thấy cách thêm một hiệu ứng hoạt hình vào một đoạn văn:

```php
  $presentation = new Presentation("Presentation.pptx");
  try {
    # chọn đoạn văn để thêm hiệu ứng
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    # thêm hiệu ứng hoạt ảnh Fly vào đoạn văn đã chọn
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($paragraph, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    $presentation->save("AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Lấy hiệu ứng hoạt hình của đoạn văn**

Bạn có thể muốn tìm hiểu các hiệu ứng hoạt hình đã được thêm vào một đoạn văn — ví dụ, trong một trường hợp, bạn muốn lấy các hiệu ứng hoạt hình trong một đoạn vì bạn dự định áp dụng các hiệu ứng đó cho một đoạn hoặc hình dạng khác.

Aspose.Slides for PHP thông qua Java cho phép bạn lấy tất cả các hiệu ứng hoạt hình được áp dụng cho các đoạn văn chứa trong một khung văn bản (hình dạng). Đoạn mã mẫu này cho thấy cách lấy các hiệu ứng hoạt hình trong một đoạn văn:

```php
  $pres = new Presentation("Presentation.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
      $effects = $sequence->getEffectsByParagraph($paragraph);
      if (java_values($Array->getLength($effects)) > 0) {
        echo("Paragraph \"" . $paragraph->getText() . "\" has " . $effects[0]->getType() . " effect.");
      }
    }
  } finally {
    $pres->dispose();
  }
```

## **Câu hỏi thường gặp**

**Các hoạt hình văn bản khác với chuyển tiếp slide như thế nào, và chúng có thể được kết hợp không?**

Hoạt hình văn bản kiểm soát hành vi của đối tượng theo thời gian trên một slide, trong khi [chuyển đổi](/slides/vi/php-java/slide-transition/) kiểm soát cách các slide thay đổi. Chúng độc lập và có thể được sử dụng cùng nhau; thứ tự phát lại được điều khiển bởi dòng thời gian hoạt hình và cài đặt chuyển đổi.

**Các hoạt hình văn bản có được giữ lại khi xuất ra PDF hoặc hình ảnh không?**

Không. PDF và hình ảnh raster là tĩnh, vì vậy bạn sẽ chỉ thấy một trạng thái duy nhất của slide mà không có chuyển động. Để giữ lại chuyển động, hãy sử dụng xuất ra [video](/slides/vi/php-java/convert-powerpoint-to-video/) hoặc [HTML](/slides/vi/php-java/export-to-html5/).

**Các hoạt hình văn bản có hoạt động trong bố cục và slide master không?**

Các hiệu ứng được áp dụng cho các đối tượng bố cục/master sẽ được kế thừa bởi các slide, nhưng thời gian và tương tác của chúng với các hoạt hình cấp slide phụ thuộc vào chuỗi cuối cùng trên slide.