---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدار السابق في Aspose.Slides لـ Java 15.9.0
type: docs
weight: 170
url: /ar/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
---

{{% alert color="primary" %}} 

تستعرض هذه الصفحة جميع الفئات، والأساليب، والخصائص، وغيرها من التغييرات التي تم إضافتها أو إزالتها مع واجهة برمجة التطبيقات Aspose.Slides لـ Java 15.8.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
#### **تم إضافة أساليب renderToGraphics إلى com.aspose.slides.ISlide و Slide**
تمت إضافة الأساليب التالية:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
تمت إضافتها إلى واجهة com.aspose.slides.ISlide وإلى فئة com.aspose.slides.Slide. تسمح هذه الأساليب بعرض الشريحة على كائن Graphics2D المحدد.

``` java

 BufferedImage bufferedImage = new BufferedImage(960, 720, BufferedImage.TYPE_INT_ARGB);

Graphics2D g2d = bufferedImage.createGraphics();

Presentation pres = new Presentation("SomePresentation.pptx");

pres.getSlides().get_Item(0).renderToGraphics(false, g2d, bufferedImage.getWidth(), bufferedImage.getHeight());

g2d.dispose();

ImageIO.write(bufferedImage, "png", fileName);

```