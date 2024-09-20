---
title: Публичный API и изменения, несовместимые с обратной совместимостью, в Aspose.Slides для Java 15.9.0
type: docs
weight: 170
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [добавленные](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) или [удаленные](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) классы, методы, свойства и так далее, а также другие изменения, введенные в API Aspose.Slides для Java 15.8.0.

{{% /alert %}} 
## **Изменения в публичном API**
#### **Методы renderToGraphics были добавлены в com.aspose.slides.ISlide, Slide**
Были добавлены следующие методы:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
были добавлены в интерфейс com.aspose.slides.ISlide и в класс com.aspose.slides.Slide. Эти методы позволяют визуализировать слайд в указанный объект Graphics2D.

``` java

 BufferedImage bufferedImage = new BufferedImage(960, 720, BufferedImage.TYPE_INT_ARGB);

Graphics2D g2d = bufferedImage.createGraphics();

Presentation pres = new Presentation("SomePresentation.pptx");

pres.getSlides().get_Item(0).renderToGraphics(false, g2d, bufferedImage.getWidth(), bufferedImage.getHeight());

g2d.dispose();

ImageIO.write(bufferedImage, "png", fileName);

```