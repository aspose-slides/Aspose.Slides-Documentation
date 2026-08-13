---
title: Nyilvános API és visszafelé nem kompatibilis változások az Aspose.Slides for Java 15.9.0-ban
linktitle: Aspose.Slides for Java 15.9.0
type: docs
weight: 170
url: /hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
keywords:
- migráció
- régi kód
- modern kód
- régi megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Tekintsd át az Aspose.Slides for Java nyilvános API frissítéseit és töréspontjait, hogy zökkenőmentesen migráld PowerPoint PPT, PPTX és ODP prezentációs megoldásaidat."
---
{{% alert color="info" %}} 

Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) vagy [eltávolított](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) osztályt, metódust, tulajdonságot és egyebeket, valamint az Aspose.Slides for Java 15.8.0 API-val bevezetett egyéb változásokat.

{{% /alert %}} 
## **Nyilvános API-változások**
#### **renderToGraphics metódusok kerültek hozzáadásra a com.aspose.slides.ISlide, Slide osztályokhoz**
A következő metódusok lettek hozzáadva:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
a com.aspose.slides.ISlide interfészhez és a com.aspose.slides.Slide osztályhoz lettek hozzáadva. Ezek a metódusok lehetővé teszik egy dia renderelését a megadott Graphics2D objektumba.

A `renderToGraphics` metódusok azóta eltávolításra kerültek a nyilvános API-ból. A jelenlegi verziókban egy diát a [ISlide.getImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) metódussal renderelhetsz, ahogy az alábbi példa is mutatja:

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