---
title: Offentlig API och bakåtinkompatibla ändringar i Aspose.Slides för Java 15.9.0
linktitle: Aspose.Slides för Java 15.9.0
type: docs
weight: 170
url: /sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
keywords:
- migrering
- gammal kod
- modern kod
- gammal metod
- modern metod
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Granska offentliga API-uppdateringar och brytande förändringar i Aspose.Slides för Java för att smidigt migrera dina PowerPoint PPT-, PPTX- och ODP-presentationslösningar."
---
{{% alert color="primary" %}}

Den här sidan listar alla [tillagda](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) eller [borttagna](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) klasser, metoder, egenskaper med mera, samt andra förändringar som införts med Aspose.Slides for Java 15.8.0 API.

{{% /alert %}} 
## **Offentliga API-ändringar**
#### **renderToGraphics-metoder lades till i com.aspose.slides.ISlide, Slide**
Följande metoder har lagts till:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
lades till i gränssnittet com.aspose.slides.ISlide och i klassen com.aspose.slides.Slide. Dessa metoder möjliggör rendering av en bild till ett specificerat Graphics2D-objekt.

``` java

 BufferedImage bufferedImage = new BufferedImage(960, 720, BufferedImage.TYPE_INT_ARGB);

Graphics2D g2d = bufferedImage.createGraphics();

Presentation pres = new Presentation("SomePresentation.pptx");

pres.getSlides().get_Item(0).renderToGraphics(false, g2d, bufferedImage.getWidth(), bufferedImage.getHeight());

g2d.dispose();

ImageIO.write(bufferedImage, "png", fileName);

```