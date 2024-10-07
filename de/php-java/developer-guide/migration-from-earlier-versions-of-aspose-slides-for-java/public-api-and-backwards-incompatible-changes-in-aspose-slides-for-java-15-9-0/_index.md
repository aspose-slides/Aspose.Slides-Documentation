---
title: Öffentliche API und nicht abwärtskompatible Änderungen in Aspose.Slides für PHP über Java 15.9.0
type: docs
weight: 170
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) oder [entfernten](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) Klassen, Methoden, Eigenschaften usw. und andere Änderungen auf, die mit der Aspose.Slides für PHP über Java 15.8.0 API eingeführt wurden.

{{% /alert %}} 
## **Änderungen der öffentlichen API**
#### **renderToGraphics-Methoden wurden zu com.aspose.slides.ISlide, Slide hinzugefügt**
Die folgenden Methoden wurden hinzugefügt:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
wurden zum com.aspose.slides.ISlide-Interface und zur com.aspose.slides.Slide-Klasse hinzugefügt. Diese Methoden ermöglichen das Rendern einer Folie zu einem angegebenen Graphics2D-Objekt.

```php
  $bufferedImage = new BufferedImage(960, 720, BufferedImage->TYPE_INT_ARGB);
  $g2d = $bufferedImage->createGraphics();
  $pres = new Presentation("SomePresentation.pptx");
  $pres->getSlides()->get_Item(0)->renderToGraphics(false, $g2d, $bufferedImage->getWidth(), $bufferedImage->getHeight());
  $g2d->dispose();
  Java("javax.imageio.ImageIO")->write($bufferedImage, "png", $fileName);

```