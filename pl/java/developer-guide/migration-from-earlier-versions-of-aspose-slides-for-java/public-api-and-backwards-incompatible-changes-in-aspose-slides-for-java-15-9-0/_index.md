---
title: Publiczne API i zmiany niekompatybilne wstecz w Aspose.Slides for Java 15.9.0
linktitle: Aspose.Slides for Java 15.9.0
type: docs
weight: 170
url: /pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
keywords:
- migracja
- kod starszy
- nowoczesny kod
- podejście legacy
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Przejrzyj aktualizacje publicznego API oraz zmiany łamiące kompatybilność w Aspose.Slides for Java, aby płynnie migrować swoje rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="info" %}} 

Ta strona wymienia wszystkie [dodane](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) lub [usunięte](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) klasy, metody, właściwości i tak dalej, oraz inne zmiany wprowadzone w API Aspose.Slides for Java 15.8.0.

{{% /alert %}} 
## **Zmiany w publicznym API**
#### **renderToGraphics methods were added to com.aspose.slides.ISlide, Slide**
Dodano następujące metody:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
zostały dodane do interfejsu com.aspose.slides.ISlide oraz do klasy com.aspose.slides.Slide. Metody te umożliwiają renderowanie slajdu do określonego obiektu Graphics2D.

Metody `renderToGraphics` zostały od tego czasu usunięte z publicznego API. W aktualnych wersjach slajd renderuje się przy pomocy [ISlide.getImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-), tak jak pokazuje poniższy przykład:

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