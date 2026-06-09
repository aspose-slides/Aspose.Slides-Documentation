---
title: API Pública e Alterações Incompatíveis Retroativas no Aspose.Slides para .NET 15.7.0
linktitle: Aspose.Slides para .NET 15.7.0
type: docs
weight: 180
url: /pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
keywords:
- migração
- código legado
- código moderno
- abordagem legada
- abordagem moderna
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Revise as atualizações da API pública e as mudanças incompatíveis no Aspose.Slides para .NET para migrar suavemente suas soluções de apresentação PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 

Esta página lista todas as classes, métodos, propriedades etc. [adicionados](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) ou [removidos](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/), e outras alterações introduzidas com a API do Aspose.Slides for .NET 15.7.0.

{{% /alert %}} 
## **Alterações da API Pública**
#### **Enum ImagePixelFormat foi adicionado**
Enum Aspose.Slides.Export.ImagePixelFormat foi adicionado para especificar o formato de pixel das imagens geradas.
#### **Método IChartDataPoint.GetAutomaticDataPointColor() foi adicionado**
Retorna uma cor automática do ponto de dados com base no índice da série, índice do ponto de dados, ParentSeriesGroup, propriedade IsColorVaried e estilo do gráfico. Esta cor é usada por padrão se FillType for igual a NotDefined.
#### **Método RenderToGraphics foi adicionado ao Slide**
O método RenderToGraphics (e suas sobrecargas) foi adicionado a Aspose.Slides.Slide para renderizar um slide em um objeto Graphics.
#### **Propriedade PixelFormat foi adicionada ao ITiffOptions e TiffOptions**
A propriedade PixelFormat foi adicionada a Aspose.Slides.Export.ITiffOptions e Aspose.Slides.Export.TiffOptions para especificar o formato de pixel das imagens TIFF geradas.