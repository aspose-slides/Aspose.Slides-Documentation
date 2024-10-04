---
title: API Pública y Cambios Incompatibles hacia Atrás en Aspose.Slides para Java 15.9.0
type: docs
weight: 170
url: /es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
---

{{% alert color="primary" %}} 

Esta página enumera todas las clases, métodos, propiedades, etc., [agregados](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) o [eliminados](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) y otros cambios introducidos con la API de Aspose.Slides para Java 15.8.0.

{{% /alert %}} 
## **Cambios en la API Pública**
#### **Se añadieron métodos renderToGraphics a com.aspose.slides.ISlide, Slide**
Se han añadido los siguientes métodos:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
fueron añadidos a la interfaz com.aspose.slides.ISlide y a la clase com.aspose.slides.Slide. Estos métodos permiten renderizar una diapositiva a un objeto Graphics2D especificado.

``` java

 BufferedImage bufferedImage = new BufferedImage(960, 720, BufferedImage.TYPE_INT_ARGB);

Graphics2D g2d = bufferedImage.createGraphics();

Presentation pres = new Presentation("SomePresentation.pptx");

pres.getSlides().get_Item(0).renderToGraphics(false, g2d, bufferedImage.getWidth(), bufferedImage.getHeight());

g2d.dispose();

ImageIO.write(bufferedImage, "png", fileName);

```