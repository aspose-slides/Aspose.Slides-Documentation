---
title: Áp dụng hiệu ứng hình dạng trong bản thuyết trình bằng PHP
linktitle: Hiệu ứng hình dạng
type: docs
weight: 30
url: /vi/php-java/shape-effect/
keywords:
- hiệu ứng hình dạng
- hiệu ứng bóng đổ
- hiệu ứng phản chiếu
- hiệu ứng hào quang
- hiệu ứng cạnh mềm
- định dạng hiệu ứng
- PowerPoint
- bản thuyết trình
- PHP
- Aspose.Slides
description: "Biến đổi các tệp PPT và PPTX của bạn với các hiệu ứng hình dạng nâng cao bằng Aspose.Slides cho PHP qua Java — tạo các slide ấn tượng, chuyên nghiệp trong vài giây."
---
## **Giới thiệu**

Trong PowerPoint, các hiệu ứng có thể được sử dụng để làm nổi bật một hình dạng, chúng khác với [fills](/slides/vi/php-java/shape-formatting/#gradient-fill) hoặc đường viền. Bằng cách sử dụng các hiệu ứng PowerPoint, bạn có thể tạo ra các phản chiếu thuyết phục trên một hình dạng, lan truyền ánh hào quang của hình dạng, v.v.

<img src="shape-effect.png" alt="hiệu-ứng-hình-dạng" style="zoom:50%;" />

* PowerPoint cung cấp sáu hiệu ứng có thể áp dụng cho các hình dạng. Bạn có thể áp dụng một hoặc nhiều hiệu ứng cho một hình dạng. 

* Một số kết hợp hiệu ứng trông đẹp hơn các kết hợp khác. Vì lý do này, các tùy chọn PowerPoint nằm dưới **Preset**. Các tùy chọn Preset thực chất là một tổ hợp đã được kiểm chứng là đẹp mắt của hai hoặc nhiều hiệu ứng. Theo cách này, khi chọn một preset, bạn sẽ không phải lãng phí thời gian thử nghiệm hoặc kết hợp các hiệu ứng khác nhau để tìm ra một sự kết hợp phù hợp.

Aspose.Slides cung cấp các thuộc tính và phương thức trong lớp [EffectFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/EffectFormat) cho phép bạn áp dụng cùng các hiệu ứng cho các hình dạng trong bản thuyết trình PowerPoint.

## **Áp dụng hiệu ứng bóng đổ**

Đoạn mã PHP này cho bạn thấy cách áp dụng hiệu ứng bóng đổ ngoài ([OuterShadowEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/EffectFormat#setOuterShadowEffect--)) cho một hình chữ nhật:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableOuterShadowEffect();
    $shape->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->DARK_GRAY);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDistance(10);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDirection(45);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Áp dụng hiệu ứng phản chiếu**

Đoạn mã PHP này cho bạn thấy cách áp dụng hiệu ứng phản chiếu cho một hình dạng:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableReflectionEffect();
    $shape->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment->Bottom);
    $shape->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $shape->getEffectFormat()->getReflectionEffect()->setDistance(55);
    $shape->getEffectFormat()->getReflectionEffect()->setBlurRadius(4);
    $pres->save("reflection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Áp dụng hiệu ứng hào quang**

Đoạn mã PHP này cho bạn thấy cách áp dụng hiệu ứng hào quang cho một hình dạng:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableGlowEffect();
    $shape->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->MAGENTA);
    $shape->getEffectFormat()->getGlowEffect()->setRadius(15);
    $pres->save("glow.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Áp dụng hiệu ứng cạnh mềm**

Đoạn mã PHP này cho bạn thấy cách áp dụng cạnh mềm cho một hình dạng:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableSoftEdgeEffect();
    $shape->getEffectFormat()->getSoftEdgeEffect()->setRadius(15);
    $pres->save("softEdges.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Câu hỏi thường gặp**

**Bạn có thể áp dụng nhiều hiệu ứng cho cùng một hình dạng không?**

Có, bạn có thể kết hợp các hiệu ứng khác nhau, chẳng hạn như bóng đổ, phản chiếu và hào quang, trên cùng một hình dạng để tạo ra một diện mạo năng động hơn.

**Bạn có thể áp dụng hiệu ứng cho những hình dạng nào?**

Bạn có thể áp dụng hiệu ứng cho nhiều loại hình dạng, bao gồm các autoshape, biểu đồ, bảng, ảnh, đối tượng SmartArt, đối tượng OLE và hơn nữa.

**Bạn có thể áp dụng hiệu ứng cho các hình dạng đã nhóm không?**

Có, bạn có thể áp dụng hiệu ứng cho các nhóm hình dạng. Hiệu ứng sẽ được áp dụng cho toàn bộ nhóm.