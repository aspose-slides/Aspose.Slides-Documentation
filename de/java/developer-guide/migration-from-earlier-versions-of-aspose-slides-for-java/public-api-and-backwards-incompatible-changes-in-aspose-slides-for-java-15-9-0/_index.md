---
title: Öffentliche API und abwärtsinkompatible Änderungen in Aspose.Slides für Java 15.9.0
linktitle: Aspose.Slides für Java 15.9.0
type: docs
weight: 170
url: /de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
keywords:
- Migration
- Legacy-Code
- Moderner Code
- Legacy-Ansatz
- Moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Überprüfen Sie die öffentlichen API‑Updates und Breaking‑Changes in Aspose.Slides für Java, um Ihre PowerPoint‑PPT-, PPTX‑ und ODP‑Präsentationslösungen reibungslos zu migrieren."
---
{{% alert color="info" %}} 

Diese Seite listet alle [hinzugefügt](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) oder [entfernt](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) Klassen, Methoden, Eigenschaften usw. sowie weitere Änderungen, die mit der Aspose.Slides für Java 15.8.0 API eingeführt wurden.

{{% /alert %}} 
## **Öffentliche API-Änderungen**
#### **renderToGraphics-Methoden wurden zu com.aspose.slides.ISlide, Slide hinzugefügt**
Die folgenden Methoden wurden hinzugefügt:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
wurden zum Interface com.aspose.slides.ISlide und zur Klasse com.aspose.slides.Slide hinzugefügt. Diese Methoden ermöglichen das Rendern einer Folie in ein angegebenes Graphics2D-Objekt.

Die `renderToGraphics`-Methoden wurden seitdem aus der öffentlichen API entfernt. In aktuellen Versionen wird eine Folie mit [ISlide.getImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) gerendert, wie das untenstehende Beispiel zeigt:

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