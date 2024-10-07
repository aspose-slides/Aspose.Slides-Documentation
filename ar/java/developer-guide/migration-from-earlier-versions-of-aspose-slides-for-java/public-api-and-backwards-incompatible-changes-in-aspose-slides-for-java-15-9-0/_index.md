---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لجافا 15.9.0
type: docs
weight: 170
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
---

{{% alert color="primary" %}} 

تقوم هذه الصفحة بإدراج جميع [الفئات المضافة](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) أو [المزالة](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) والطرق والخصائص وما إلى ذلك، والتغييرات الأخرى التي تم تقديمها مع واجهة برمجة التطبيقات Aspose.Slides لجافا 15.8.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
#### **تمت إضافة طرق renderToGraphics إلى com.aspose.slides.ISlide و Slide**
تمت إضافة الطرق التالية:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
تمت إضافتها إلى واجهة com.aspose.slides.ISlide وإلى فئة com.aspose.slides.Slide. تتيح هذه الطرق رسم الشريحة إلى كائن Graphics2D المحدد.

``` java

 BufferedImage bufferedImage = new BufferedImage(960, 720, BufferedImage.TYPE_INT_ARGB);

Graphics2D g2d = bufferedImage.createGraphics();

Presentation pres = new Presentation("SomePresentation.pptx");

pres.getSlides().get_Item(0).renderToGraphics(false, g2d, bufferedImage.getWidth(), bufferedImage.getHeight());

g2d.dispose();

ImageIO.write(bufferedImage, "png", fileName);

```