---
title: API Pública e Alterações Incompatíveis Retroativas no Aspose.Slides para .NET 15.11.0
linktitle: Aspose.Slides para .NET 15.11.0
type: docs
weight: 210
url: /pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/
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
description: "Revise as atualizações da API pública e as mudanças que quebram a compatibilidade no Aspose.Slides para .NET para migrar suavemente suas soluções de apresentação PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 

Esta página lista todas as [adicionados](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) ou [removidos](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) classes, métodos, propriedades e etc., e outras alterações introduzidas com a API Aspose.Slides for .NET 15.11.0.

{{% /alert %}} 
## **Alterações da API Pública**

#### **Propriedades Obsoletas na Classe DataLabelCollection foram Excluídas**
Propriedades obsoletas na classe DataLabelCollection foram excluídas:
Aspose.Slides.Charts.DataLabelCollection.Delete
Aspose.Slides.Charts.DataLabelCollection.Format
Aspose.Slides.Charts.DataLabelCollection.LinkedSource
Aspose.Slides.Charts.DataLabelCollection.NumberFormat
Aspose.Slides.Charts.DataLabelCollection.Position
Aspose.Slides.Charts.DataLabelCollection.Separator
Aspose.Slides.Charts.DataLabelCollection.ShowBubbleSize
Aspose.Slides.Charts.DataLabelCollection.ShowCategoryName
Aspose.Slides.Charts.DataLabelCollection.ShowLeaderLines
Aspose.Slides.Charts.DataLabelCollection.ShowLegendKey
Aspose.Slides.Charts.DataLabelCollection.ShowPercentage
Aspose.Slides.Charts.DataLabelCollection.ShowSeriesName
Aspose.Slides.Charts.DataLabelCollection.ShowValue

#### **A Nova Propriedade FirstSlideNumber Foi Adicionada à Classe Presentation**
A nova propriedade FirstSlideNumber adicionada ao Presentation permite obter ou definir o número do primeiro slide em uma apresentação.

Quando um novo valor de FirstSlideNumber é especificado, todos os números de slide são recalculados.

``` csharp

 using(var pres = new Presenation(path))

{

  int firstSlideNumber = pres.FirstSlideNumber;

  pres.FirstSlideNumber = 10;

  pres.Save(newPath, SaveFormat.Pptx);

}

```