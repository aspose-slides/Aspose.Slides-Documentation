---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides for Java 15.9.0
linktitle: Aspose.Slides pro Java 15.9.0
type: docs
weight: 170
url: /cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
keywords:
- migrace
- legacy kód
- moderní kód
- legacy přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Prohlédněte si aktualizace veřejného API a neslučitelné změny v Aspose.Slides for Java, abyste hladce migrovali svá řešení pro prezentace PowerPoint PPT, PPTX a ODP."
---
{{% alert color="primary" %}} 
Tato stránka uvádí všechny [přidané](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) nebo [odstraněné](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) třídy, metody, vlastnosti a podobně a další změny zavedené v API Aspose.Slides for Java 15.8.0.
{{% /alert %}} 
## **Změny veřejného API**
#### **Metody renderToGraphics byly přidány do com.aspose.slides.ISlide, Slide**
Byly přidány následující metody:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
byly přidány do rozhraní com.aspose.slides.ISlide a do třídy com.aspose.slides.Slide. Tyto metody umožňují vykreslit snímek do určeného objektu Graphics2D.
``` java

 BufferedImage bufferedImage = new BufferedImage(960, 720, BufferedImage.TYPE_INT_ARGB);

Graphics2D g2d = bufferedImage.createGraphics();

Presentation pres = new Presentation("SomePresentation.pptx");

pres.getSlides().get_Item(0).renderToGraphics(false, g2d, bufferedImage.getWidth(), bufferedImage.getHeight());

g2d.dispose();

ImageIO.write(bufferedImage, "png", fileName);

```