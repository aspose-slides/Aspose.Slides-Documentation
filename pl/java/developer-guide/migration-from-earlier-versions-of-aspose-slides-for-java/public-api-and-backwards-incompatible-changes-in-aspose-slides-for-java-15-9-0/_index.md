---
title: Public API i zmiany niekompatybilne wstecz w Aspose.Slides dla Java 15.9.0
linktitle: Aspose.Slides dla Java 15.9.0
type: docs
weight: 170
url: /pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
keywords:
- migracja
- kod starszy
- nowoczesny kod
- tradycyjne podejście
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Przejrzyj aktualizacje publicznego API oraz zmiany łamiące w Aspose.Slides dla Java, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="primary" %}} 

Ta strona wymienia wszystkie [dodane](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) lub [usunięte](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) klasy, metody, właściwości i tak dalej, oraz inne zmiany wprowadzone w API Aspose.Slides for Java 15.8.0.

{{% /alert %}} 
## **Zmiany publicznego API**
#### **Metody renderToGraphics zostały dodane do com.aspose.slides.ISlide, Slide**
Dodano następujące metody:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
zostały dodane do interfejsu com.aspose.slides.ISlide oraz do klasy com.aspose.slides.Slide. Te metody umożliwiają renderowanie slajdu do określonego obiektu Graphics2D.

``` java

 BufferedImage bufferedImage = new BufferedImage(960, 720, BufferedImage.TYPE_INT_ARGB);

Graphics2D g2d = bufferedImage.createGraphics();

Presentation pres = new Presentation("SomePresentation.pptx");

pres.getSlides().get_Item(0).renderToGraphics(false, g2d, bufferedImage.getWidth(), bufferedImage.getHeight());

g2d.dispose();

ImageIO.write(bufferedImage, "png", fileName);

```