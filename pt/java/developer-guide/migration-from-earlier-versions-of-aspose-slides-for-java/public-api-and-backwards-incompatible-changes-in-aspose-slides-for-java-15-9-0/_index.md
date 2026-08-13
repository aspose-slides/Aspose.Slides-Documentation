---
title: API Pública e Alterações Incompatíveis Retroativas no Aspose.Slides for Java 15.9.0
linktitle: Aspose.Slides for Java 15.9.0
type: docs
weight: 170
url: /pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
keywords:
- migração
- código legado
- código moderno
- abordagem legada
- abordagem moderna
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Revise as atualizações da API pública e as mudanças incompatíveis no Aspose.Slides for Java para migrar suavemente suas soluções de apresentações PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}} 
Esta página lista todas as [adicionados](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) ou [removidos](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) classes, métodos, propriedades e assim por diante, além de outras alterações introduzidas com a Aspose.Slides for Java 15.8.0 API.
{{% /alert %}} 
## **Alterações da API Pública**
#### **Métodos renderToGraphics foram adicionados a com.aspose.slides.ISlide, Slide**
Os seguintes métodos foram adicionados:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
foram adicionados à interface com.aspose.slides.ISlide e à classe com.aspose.slides.Slide. Esses métodos permitem renderizar um slide em um objeto Graphics2D especificado.

Os métodos `renderToGraphics` foram removidos da API pública. Nas versões atuais, renderize um slide com [ISlide.getImage](https://reference.aspose.com/slides/pt/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-), como faz o exemplo abaixo:

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