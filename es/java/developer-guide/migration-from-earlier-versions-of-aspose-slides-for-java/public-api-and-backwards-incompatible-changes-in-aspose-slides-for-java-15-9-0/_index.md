---
title: API pública y cambios incompatibles hacia atrás en Aspose.Slides for Java 15.9.0
linktitle: Aspose.Slides para Java 15.9.0
type: docs
weight: 170
url: /es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
keywords:
- migración
- código heredado
- código moderno
- enfoque heredado
- enfoque moderno
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Revise las actualizaciones de la API pública y los cambios incompatibles en Aspose.Slides for Java para migrar sin problemas sus soluciones de presentaciones PowerPoint PPT, PPTX y ODP."
---
{{% alert color="info" %}} 

Esta página enumera todas las [añadidas](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) o [eliminadas](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) clases, métodos, propiedades, etc., y otros cambios introducidos con la API de Aspose.Slides for Java 15.8.0.

{{% /alert %}} 
## **Cambios de API pública**
#### **Se añadieron los métodos renderToGraphics a com.aspose.slides.ISlide, Slide**
Se han añadido los siguientes métodos:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
se añadieron a la interfaz com.aspose.slides.ISlide y a la clase com.aspose.slides.Slide. Estos métodos permiten renderizar una diapositiva en un objeto Graphics2D especificado.

Los métodos `renderToGraphics` se han eliminado de la API pública. En versiones actuales, renderiza una diapositiva con [ISlide.getImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-), como muestra el ejemplo siguiente:

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