---
title: API Pública e Alterações Incompatíveis Retroativas no Aspose.Slides para Java 15.9.0
linktitle: Aspose.Slides para Java 15.9.0
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
description: "Revise as atualizações da API pública e as alterações incompatíveis no Aspose.Slides para Java para migrar suavemente suas soluções de apresentação PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 

Esta página lista todos os [adicionados](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) ou [removidos](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) classes, métodos, propriedades etc., e outras alterações introduzidas na API do Aspose.Slides para Java 15.8.0.

{{% /alert %}} 
## **Alterações da API Pública**
#### **Métodos renderToGraphics foram adicionados ao com.aspose.slides.ISlide, Slide**
Os seguintes métodos foram adicionados:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
foram adicionados à interface com.aspose.slides.ISlide e à classe com.aspose.slides.Slide. Esses métodos permitem renderizar um slide em um objeto Graphics2D especificado.

``` java

 BufferedImage bufferedImage = new BufferedImage(960, 720, BufferedImage.TYPE_INT_ARGB);

Graphics2D g2d = bufferedImage.createGraphics();

Presentation pres = new Presentation("SomePresentation.pptx");

pres.getSlides().get_Item(0).renderToGraphics(false, g2d, bufferedImage.getWidth(), bufferedImage.getHeight());

g2d.dispose();

ImageIO.write(bufferedImage, "png", fileName);

```