---
title: API Pública e Alterações Incompatíveis Retroativas no Aspose.Slides for .NET 15.5.0
linktitle: Aspose.Slides for .NET 15.5.0
type: docs
weight: 160
url: /pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/
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
description: "Revisar atualizações da API pública e mudanças incompatíveis no Aspose.Slides for .NET para migrar suavemente suas soluções de apresentação PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}} 
Esta página lista todas as classes, métodos, propriedades e demais itens [adicionado](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) ou [removido](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) introduzidos na API do Aspose.Slides for .NET 15.5.0. 
{{% /alert %}} 
## **Alterações da API Pública**
#### **Classe CommonSlideViewProperties e Interface ICommonSlideViewProperties foram adicionadas**
A classe Aspose.Slides.CommonSlideViewProperties e a interface Aspose.Slides.ICommonSlideViewProperties representam propriedades comuns de visualização de slides (atualmente opções de escala de visualização).
#### **Propriedade IAxis.LabelOffset foi adicionada**
A propriedade IAxis.LabelOffset especifica a distância dos rótulos em relação ao eixo. Aplicada ao eixo de categoria ou de data.
#### **Propriedade IChartTextBlockFormat.AutofitType foi adicionada**
Alterar esta propriedade pode produzir influência apenas nas seguintes partes do gráfico: DataLabel e DataLabelFormat (suporte total no PowerPoint 2013; no PowerPoint 2007 não há efeito na renderização).
#### **Propriedade IChartTextBlockFormat.WrapText foi adicionada**
Alterar esta propriedade pode produzir influência apenas nas seguintes partes do gráfico: DataLabel e DataLabelFormat (suporte total no PowerPoint 2007/2013).
#### **Propriedades de margem foram adicionadas a IChartTextBlockFormat**
Alterar estas propriedades pode produzir influência apenas nas seguintes partes do gráfico: DataLabel e DataLabelFormat (suporte total no PowerPoint 2013; no PowerPoint 2007 não há efeito na renderização).
#### **Propriedade ViewProperties.NotesViewProperties foi adicionada**
A propriedade Aspose.Slides.ViewProperties.NotesViewProperties foi adicionada. Ela especifica propriedades comuns de visualização associadas ao modo de visualização de notas.
#### **Propriedade ViewProperties.SlideViewProperties foi adicionada**
A propriedade Aspose.Slides.ViewProperties.SlideViewProperties foi adicionada. Ela especifica propriedades comuns de visualização associadas ao modo de visualização de slides.