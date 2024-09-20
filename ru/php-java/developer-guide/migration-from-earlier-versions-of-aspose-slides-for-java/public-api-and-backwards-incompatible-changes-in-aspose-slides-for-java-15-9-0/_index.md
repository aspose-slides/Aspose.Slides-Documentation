---
title: Публичный API и несовместимые изменения в Aspose.Slides для PHP через Java 15.9.0
type: docs
weight: 170
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [добавленные](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) или [удаленные](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) классы, методы, свойства и так далее, а также другие изменения, введенные с API Aspose.Slides для PHP через Java 15.8.0.

{{% /alert %}} 
## **Изменения в публичном API**
#### **Методы renderToGraphics были добавлены в com.aspose.slides.ISlide, Slide**
Были добавлены следующие методы:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
были добавлены в интерфейс com.aspose.slides.ISlide и класс com.aspose.slides.Slide. Эти методы позволяют рендерить слайд в заданный объект Graphics2D.

```php
  $bufferedImage = new BufferedImage(960, 720, BufferedImage->TYPE_INT_ARGB);
  $g2d = $bufferedImage->createGraphics();
  $pres = new Presentation("НекотораяПрезентация.pptx");
  $pres->getSlides()->get_Item(0)->renderToGraphics(false, $g2d, $bufferedImage->getWidth(), $bufferedImage->getHeight());
  $g2d->dispose();
  Java("javax.imageio.ImageIO")->write($bufferedImage, "png", $fileName);

```