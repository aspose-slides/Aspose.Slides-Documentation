---
title: ส่งออกชาร์ตการนำเสนอใน PHP
linktitle: ส่งออกชาร์ต
type: docs
weight: 90
url: /th/php-java/export-chart/
keywords:
- แผนภูมิ
- แผนภูมิเพื่อเป็นรูปภาพ
- แผนภูมิเป็นรูปภาพ
- สกัดรูปภาพแผนภูมิ
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีส่งออกแผนภูมิการนำเสนอด้วย Aspose.Slides สำหรับ PHP ผ่าน Java รองรับรูปแบบ PPT และ PPTX และทำให้กระบวนการรายงานเป็นอัตโนมัติในทุกเวิร์กโฟลว์"
---
## **Overview**

Aspose.Slides ให้คุณส่งออกแผนภูมิจากงานนำเสนอเป็นภาพ บทความนี้แสดงวิธีดึงภาพจากแผนภูมิและบันทึกไว้ ซึ่งเป็นประโยชน์เมื่อคุณต้องการใช้ภาพแผนภูมิภายนอกงานนำเสนอ PowerPoint

## **Get a Chart Image**
Aspose.Slides for PHP via Java รองรับการสกัดภาพของแผนภูมิเฉพาะ ตัวอย่างต่อไปนี้แสดงการใช้งาน

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $slideImage = $chart->getImage();
    try {
      $slideImage->save("image.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Can I export a chart as a vector (SVG) instead of a raster image?**

Yes. A chart is a shape, and its contents can be saved to SVG using the [shape-to-SVG saving method](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/writeassvg/).

**How can I set the exact size of the exported chart in pixels?**

Use the image-rendering overloads that let you specify size or scale—the library supports rendering objects with given dimensions/scale.

**What should I do if fonts in labels and the legend look wrong after export?**

[Load the required fonts](/slides/th/php-java/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsloader/) so the chart rendering preserves metrics and text appearance.

**Does export honor the PowerPoint theme, styles, and effects?**

Yes. Aspose.Slides’ renderer follows the presentation’s formatting (themes, styles, fills, effects), so the chart’s appearance is preserved.

**Where can I find available rendering/export capabilities beyond chart images?**

See the [API](https://reference.aspose.com/slides/th/php-java/aspose.slides/)/[documentation](/slides/th/php-java/convert-powerpoint/) for output targets ([PDF](/slides/th/php-java/convert-powerpoint-to-pdf/), [SVG](/slides/th/php-java/render-a-slide-as-an-svg-image/), [XPS](/slides/th/php-java/convert-powerpoint-to-xps/), [HTML](/slides/th/php-java/convert-powerpoint-to-html/), etc.) and related rendering options.