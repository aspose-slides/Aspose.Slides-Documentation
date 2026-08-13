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
description: "Revise as atualizações da API pública e as alterações que quebram a compatibilidade no Aspose.Slides para .NET para migrar suavemente suas soluções de apresentação PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}} 

Esta página lista todas as classes, métodos, propriedades etc. [added](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) ou [removed](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) e outras alterações introduzidas com a API do Aspose.Slides para .NET 15.7.0.

{{% /alert %}} 
## **Alterações na API Pública**
#### **Enum ImagePixelFormat Foi Adicionado**
Enum Aspose.Slides.Export.ImagePixelFormat foi adicionado para especificar o formato de pixel das imagens geradas.
#### **Método IChartDataPoint.GetAutomaticDataPointColor() Foi Adicionado**
Retorna uma cor automática do ponto de dados com base no índice da série, índice do ponto de dados, ParentSeriesGroup, propriedade IsColorVaried e estilo do gráfico.
Essa cor é usada por padrão se FillType for igual a NotDefined.
#### **Método RenderToGraphics Foi Adicionado ao Slide**
Método RenderToGraphics (e suas sobrecargas) foi adicionado ao Aspose.Slides.Slide para renderizar um slide em um objeto Graphics.
#### **Propriedade PixelFormat Foi Adicionada ao ITiffOptions e TiffOptions**
Propriedade PixelFormat foi adicionada ao Aspose.Slides.Export.ITiffOptions e Aspose.Slides.Export.TiffOptions para especificar o formato de pixel das imagens TIFF geradas.