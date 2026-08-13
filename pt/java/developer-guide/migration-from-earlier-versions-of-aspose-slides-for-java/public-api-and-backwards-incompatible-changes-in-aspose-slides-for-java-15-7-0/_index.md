---
title: API Pública e Alterações Incompatíveis Retroativas no Aspose.Slides for Java 15.7.0
linktitle: Aspose.Slides for Java 15.7.0
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
description: "Revise as atualizações da API pública e as mudanças incompatíveis no Aspose.Slides for Java para migrar suavemente suas soluções de apresentação PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}} 

Esta página lista todas as classes, métodos, propriedades e afins [added](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) ou [removed](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/), e outras alterações introduzidas com a API do Aspose.Slides for Java 15.7.0.

{{% /alert %}} 
## **Alterações da API Pública**
#### **Enum com.aspose.slides.ImagePixelFormat foi adicionado**
Enum com.aspose.slides.ImagePixelFormat foi adicionado para especificar o formato de pixel das imagens geradas.
#### **Método com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() foi adicionado**
Este método retorna uma cor automática do ponto de dados com base no índice da série, índice do ponto de dados, parentSeriesGroup, valores de isColorVaried e estilo do gráfico. Essa cor é usada por padrão se fillType for igual a NotDefined.
#### **Métodos getPixelFormat() e setPixelFormat(int) foram adicionados a com.aspose.slides.ITiffOptions**
Métodos getPixelFormat() e setPixelFormat(/ImagePixelFormat/int) foram adicionados a com.aspose.slides.ITiffOptions e com.aspose.slides.TiffOptions para especificar o formato de pixel das imagens TIFF geradas.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```