---
title: Publiczne API i zmiany niezgodne wstecz w Aspose.Slides dla .NET 15.7.0
linktitle: Aspose.Slides dla .NET 15.7.0
type: docs
weight: 180
url: /pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
keywords:
- migracja
- kod legacy
- nowoczesny kod
- podejście legacy
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Przejrzyj aktualizacje publicznego API i zmiany łamiące w Aspose.Slides dla .NET, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="primary" %}} 

Ta strona wymienia wszystkie [dodane](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) lub [usunięte](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) klasy, metody, właściwości i tak dalej, oraz inne zmiany wprowadzone w API Aspose.Slides dla .NET 15.7.0.

{{% /alert %}} 
## **Zmiany w publicznym API**
#### **Enum ImagePixelFormat został dodany**
Enum Aspose.Slides.Export.ImagePixelFormat został dodany w celu określenia formatu pikseli dla generowanych obrazów.
#### **Metoda IChartDataPoint.GetAutomaticDataPointColor() została dodana**
Zwraca automatyczny kolor punktu danych na podstawie indeksu serii, indeksu punktu danych, ParentSeriesGroup, właściwości IsColorVaried oraz stylu wykresu.
Ten kolor jest używany domyślnie, jeśli FillType jest równy NotDefined.
#### **Metoda RenderToGraphics została dodana do Slide**
Metoda RenderToGraphics (i jej przeciążenia) została dodana do Aspose.Slides.Slide w celu renderowania slajdu do obiektu Graphics.
#### **Właściwość PixelFormat została dodana do ITiffOptions i TiffOptions**
Właściwość PixelFormat została dodona do Aspose.Slides.Export.ITiffOptions i Aspose.Slides.Export.TiffOptions w celu określenia formatu pikseli dla generowanych obrazów TIFF.