---
title: Public API i zmiany niezgodne wstecz w Aspose.Slides for .NET 15.11.0
linktitle: Aspose.Slides dla .NET 15.11.0
type: docs
weight: 210
url: /pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/
keywords:
- migracja
- przestarzały kod
- nowoczesny kod
- przestarzałe podejście
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Przeglądaj aktualizacje publicznego API oraz zmiany łamiące w Aspose.Slides for .NET, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="primary" %}}

Ta strona wymienia wszystkie [dodane](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) lub [usunięte](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) klasy, metody, właściwości i tak dalej, oraz inne zmiany wprowadzone w API Aspose.Slides for .NET 15.11.0.

{{% /alert %}} 
## **Zmiany w publicznym API**

#### **Przestarzałe właściwości w klasie DataLabelCollection zostały usunięte**
Przestarzałe właściwości w klasie DataLabelCollection zostały usunięte:
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

#### **Nowa właściwość FirstSlideNumber została dodana do klasy Presentation**
Nowa właściwość FirstSlideNumber dodana do klasy Presentation umożliwia odczyt i ustawienie numeru pierwszego slajdu w prezentacji.

Po określeniu nowej wartości FirstSlideNumber wszystkie numery slajdów są przeliczane.

``` csharp

 using(var pres = new Presenation(path))

{

  int firstSlideNumber = pres.FirstSlideNumber;

  pres.FirstSlideNumber = 10;

  pres.Save(newPath, SaveFormat.Pptx);

}

```