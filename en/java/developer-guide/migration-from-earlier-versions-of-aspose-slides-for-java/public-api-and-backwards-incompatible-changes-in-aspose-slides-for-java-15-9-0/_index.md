---
title: Public API and Backwards Incompatible Changes in Aspose.Slides for Java 15.9.0
linktitle: Aspose.Slides for Java 15.9.0
type: docs
weight: 170
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
keywords:
- migration
- legacy code
- modern code
- legacy approach
- modern approach
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Review public API updates and breaking changes in Aspose.Slides for Java to smoothly migrate your PowerPoint PPT, PPTX and ODP presentation solutions."
---

{{% alert color="primary" %}} 

This page lists all [added](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) or [removed](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) classes, methods, properties and so on, and other changes introduced with the Aspose.Slides for Java 15.8.0 API.

{{% /alert %}} 
## **Public API Changes**
#### **renderToGraphics methods were added to com.aspose.slides.ISlide, Slide**
The following methods have been added:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
were added to com.aspose.slides.ISlide interface and to com.aspose.slides.Slide class. These methods allow render a slide to specified Graphics2D object.

The `renderToGraphics` methods have since been removed from the public API. In current versions, render a slide with [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-), as the example below does:

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
