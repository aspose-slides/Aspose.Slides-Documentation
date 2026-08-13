---
title: API publique et changements incompatibles rétroactifs dans Aspose.Slides for Java 15.9.0
linktitle: Aspose.Slides pour Java 15.9.0
type: docs
weight: 170
url: /fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
keywords:
- migration
- code hérité
- code moderne
- approche héritée
- approche moderne
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Passez en revue les mises à jour de l'API publique et les changements incompatibles dans Aspose.Slides for Java afin de migrer en douceur vos solutions de présentation PowerPoint PPT, PPTX et ODP."
---
{{% alert color="info" %}} 

Cette page répertorie toutes les classes, méthodes, propriétés, etc., [ajoutées](/slides/fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) ou [supprimées](/slides/fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) et les autres modifications introduites avec l'API Aspose.Slides for Java 15.8.0.

{{% /alert %}} 
## **Modifications de l'API publique**
#### **Les méthodes renderToGraphics ont été ajoutées à com.aspose.slides.ISlide, Slide**
Les méthodes suivantes ont été ajoutées :

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
ont été ajoutées à l'interface com.aspose.slides.ISlide et à la classe com.aspose.slides.Slide. Ces méthodes permettent de rendre une diapositive dans un objet Graphics2D spécifié.

Les méthodes `renderToGraphics` ont depuis été supprimées de l'API publique. Dans les versions actuelles, il faut rendre une diapositive avec [ISlide.getImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-), comme le montre l'exemple ci‑dessous :

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