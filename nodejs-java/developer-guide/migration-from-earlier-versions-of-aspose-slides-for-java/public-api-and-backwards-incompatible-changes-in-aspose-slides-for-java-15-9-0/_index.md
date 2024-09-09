---
title: Public API and Backwards Incompatible Changes in Aspose.Slides for Java 15.9.0
type: docs
weight: 170
url: /nodejs-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
---

{{% alert color="primary" %}} 

This page lists all [added](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) or [removed](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) classes, methods, properties and so on, and other changes introduced with the Aspose.Slides for Java 15.8.0 API.

{{% /alert %}} 
## **Public API Changes**
#### **renderToGraphics methods were added to aspose.slides.ISlide, Slide**
The following methods have been added:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
were added to aspose.slides.ISlide interface and to aspose.slides.Slide class. These methods allow render a slide to specified Graphics2D object.

```javascript
    var bufferedImage = java.newInstanceSync("BufferedImage", 960, 720, java.getStaticFieldValue("BufferedImage", "TYPE_INT_ARGB"));
    var g2d = bufferedImage.createGraphics();
    var pres = new  aspose.slides.Presentation("SomePresentation.pptx");
    pres.getSlides().get_Item(0).renderToGraphics(false, g2d, bufferedImage.getWidth(), bufferedImage.getHeight());
    g2d.dispose();
    java.callStaticMethodSync("javax.imageio.ImageIO", "write", bufferedImage, "png", fileName);
```
