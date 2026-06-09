---
title: API Pública e Alterações Incompatíveis Retroativas no Aspose.Slides para Java 15.7.0
linktitle: Aspose.Slides para Java 15.7.0
type: docs
weight: 150
url: /pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
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
description: "Revise as atualizações da API pública e as alterações críticas no Aspose.Slides para Java para migrar suavemente suas soluções de apresentação PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 
Esta página lista todos os [added](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) ou [removed](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) classes, métodos, propriedades e assim por diante, e outras alterações introduzidas na API do Aspose.Slides for Java 15.7.0.
{{% /alert %}} 
## **Alterações da API Pública**
#### **Enum com.aspose.slides.ImagePixelFormat foi adicionado**
Enum com.aspose.slides.ImagePixelFormat foi adicionado para especificar o formato de pixel das imagens geradas.
#### **Método com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() foi adicionado**
Este método retorna uma cor automática do ponto de dados com base no índice da série, índice do ponto de dados, parentSeriesGroup, valores de isColorVaried e no estilo do gráfico. Essa cor é usada por padrão se fillType for igual a NotDefined.
#### **Métodos getPixelFormat(), setPixelFormat(int) foram adicionados ao com.aspose.slides.ITiffOptions**
Métodos getPixelFormat(), setPixelFormat(/ImagePixelFormat/int) foram adicionados ao com.aspose.slides.ITiffOptions e ao com.aspose.slides.TiffOptions para especificar o formato de pixel das imagens TIFF geradas.
``` java

 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```