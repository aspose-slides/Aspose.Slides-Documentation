---
title: Публичный API и несовместимые изменения в Aspose.Slides для Java 15.9.0
type: docs
weight: 170
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
---

{{% alert color="primary" %}} 

Эта страница содержит список всех [добавленных](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) или [удаленных](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) классов, методов, свойств и так далее, а также других изменений, введенных в API Aspose.Slides для Java 15.8.0.

{{% /alert %}} 
## **Изменения публичного API**
#### **Методы renderToGraphics были добавлены в com.aspose.slides.ISlide, Slide**
Были добавлены следующие методы:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
были добавлены в интерфейс com.aspose.slides.ISlide и класс com.aspose.slides.Slide. Эти методы позволяют рендерить слайд в указанный объект Graphics2D.

``` java

 BufferedImage bufferedImage = new BufferedImage(960, 720, BufferedImage.TYPE_INT_ARGB);

Graphics2D g2d = bufferedImage.createGraphics();

Presentation pres = new Presentation("SomePresentation.pptx");

pres.getSlides().get_Item(0).renderToGraphics(false, g2d, bufferedImage.getWidth(), bufferedImage.getHeight());

g2d.dispose();

ImageIO.write(bufferedImage, "png", fileName);

```