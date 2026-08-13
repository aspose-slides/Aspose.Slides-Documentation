---
title: Public API i niekompatybilne zmiany wsteczne w Aspose.Slides dla .NET 15.7.0
linktitle: Aspose.Slides dla .NET 15.7.0
type: docs
weight: 180
url: /pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
keywords:
- migracja
- kod legacy
- nowoczesny kod
- podejście legacy
- podejście nowoczesne
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Przeglądnij aktualizacje publicznego API i zmiany łamiące w Aspose.Slides dla .NET, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="info" %}} 
Ta strona wymienia wszystkie [added](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) lub [removed](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) klasy, metody, właściwości i tak dalej, oraz inne zmiany wprowadzone w API Aspose.Slides for .NET 15.7.0.
{{% /alert %}} 
## **Zmiany w publicznym API**
#### **Dodano wyliczenie ImagePixelFormat**
Wyliczenie Aspose.Slides.Export.ImagePixelFormat zostało dodane w celu określenia formatu pikseli dla generowanych obrazów.
#### **Dodano metodę IChartDataPoint.GetAutomaticDataPointColor()**
Zwraca automatyczny kolor punktu danych w oparciu o indeks serii, indeks punktu danych, ParentSeriesGroup, właściwość IsColorVaried oraz styl wykresu.
Ten kolor jest używany domyślnie, jeśli FillType ma wartość NotDefined.
#### **Dodano metodę RenderToGraphics do klasy Slide**
Metoda RenderToGraphics (oraz jej przeciążenia) została dodana do Aspose.Slides.Slide w celu renderowania slajdu do obiektu Graphics.
#### **Dodano właściwość PixelFormat do ITiffOptions i TiffOptions**
Właściwość PixelFormat została dodana do Aspose.Slides.Export.ITiffOptions i Aspose.Slides.Export.TiffOptions w celu określenia formatu pikseli dla generowanych obrazów TIFF.