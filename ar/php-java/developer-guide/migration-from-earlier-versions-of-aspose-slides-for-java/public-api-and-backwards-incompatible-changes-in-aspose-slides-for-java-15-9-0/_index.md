---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ PHP عبر Java 15.9.0
type: docs
weight: 170
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
---

{{% alert color="primary" %}} 

تدرج هذه الصفحة جميع [التم إضافة](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) أو [تم إزالة](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) الفئات، الطرق، الخصائص وما إلى ذلك، والتغييرات الأخرى التي تم تقديمها مع واجهة برمجة التطبيقات Aspose.Slides لـ PHP عبر Java 15.8.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
#### **تم إضافة طرق renderToGraphics إلى com.aspose.slides.ISlide، Slide**
تمت إضافة الطرق التالية:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
تمت إضافتها إلى واجهة com.aspose.slides.ISlide وإلى فئة com.aspose.slides.Slide. تسمح هذه الطرق بتقديم الشريحة إلى كائن Graphics2D المحدد.

```php
  $bufferedImage = new BufferedImage(960, 720, BufferedImage->TYPE_INT_ARGB);
  $g2d = $bufferedImage->createGraphics();
  $pres = new Presentation("SomePresentation.pptx");
  $pres->getSlides()->get_Item(0)->renderToGraphics(false, $g2d, $bufferedImage->getWidth(), $bufferedImage->getHeight());
  $g2d->dispose();
  Java("javax.imageio.ImageIO")->write($bufferedImage, "png", $fileName);

```