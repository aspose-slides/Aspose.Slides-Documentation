---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro Java 15.9.0
linktitle: Aspose.Slides pro Java 15.9.0
type: docs
weight: 170
url: /cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
keywords:
- migrace
- legacy kód
- moderní kód
- zastaralý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Prozkoumejte aktualizace veřejného API a rušivé změny v Aspose.Slides pro Java, abyste hladce migrovali své řešení prezentací PowerPoint PPT, PPTX a ODP."
---
{{% alert color="info" %}} 

Tato stránka uvádí všechny [přidané](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) nebo [odstraněné](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) třídy, metody, vlastnosti a podobně a další změny zavedené v Aspose.Slides for Java 15.8.0 API.

{{% /alert %}} 
## **Změny veřejného API**
#### **Metody renderToGraphics byly přidány do com.aspose.slides.ISlide, Slide**
Byly přidány následující metody:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
byly přidány do rozhraní com.aspose.slides.ISlide a do třídy com.aspose.slides.Slide. Tyto metody umožňují vykreslit snímek do zadaného objektu Graphics2D.

Metody `renderToGraphics` byly od té doby ze veřejného API odstraněny. V aktuálních verzích se snímek vykresluje pomocí [ISlide.getImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-), jak ukazuje níže uvedený příklad:

``` java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("SomePresentation.pptx");

try {

	IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

	try {

		slideImage.save("slide.png", ImageFormat.Png);

	} finally {

		slideImage.dispose();

	}

} finally {

	if (pres != null) pres.dispose();

}

```