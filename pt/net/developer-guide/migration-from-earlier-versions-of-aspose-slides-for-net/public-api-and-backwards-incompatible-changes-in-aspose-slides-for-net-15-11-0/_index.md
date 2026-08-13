---
title: API Pública e Alterações Incompatíveis Retroativas no Aspose.Slides for .NET 15.11.0
linktitle: Aspose.Slides for .NET 15.11.0
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
description: "Revise as atualizações da API pública e as mudanças incompatíveis no Aspose.Slides for .NET para migrar suavemente suas soluções de apresentação PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}} 
Esta página lista todas as classes, métodos, propriedades **adicionados** ou **removidos**, etc., e outras alterações introduzidas na API do Aspose.Slides for .NET 15.11.0.
{{% /alert %}} 
## **Alterações na API Pública**

#### **Propriedades Obsoletas na Classe DataLabelCollection Foram Excluídas**
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
A nova propriedade FirstSlideNumber adicionada à classe Presentation permite obter ou definir o número do primeiro slide em uma apresentação.

Quando um novo valor para FirstSlideNumber é especificado, todos os números dos slides são recalculados.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string path = "sample.pptx";
string newPath = "output.pptx";

using (var pres = new Presentation(path))
{
    int firstSlideNumber = pres.FirstSlideNumber;

    pres.FirstSlideNumber = 10;

    pres.Save(newPath, SaveFormat.Pptx);
}
```