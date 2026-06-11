---
title: Publiczne API i zmiany niekompatybilne wstecz w Aspose.Slides dla .NET 14.3.0
linktitle: Aspose.Slides dla .NET 14.3.0
type: docs
weight: 50
url: /pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
keywords:
- migracja
- kod dziedziczony
- nowoczesny kod
- starsze podejście
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Przejrzyj aktualizacje publicznego API i zmiany łamiące w Aspose.Slides dla .NET, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
## **Publiczne API i zmiany niekompatybilne wstecz**
### **Dodano wyliczenie Aspose.Slides.ShapeThumbnailBounds i metody Aspose.Slides.IShape.GetThumbnail()**
Metody GetThumbnail() i GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) służą do tworzenia osobnego miniatury kształtu. Wyliczenie ShapeThumbnailBounds definiuje możliwe typy ograniczeń miniatury kształtu.
### **Do Aspose.Slides.IShape dodano własność UniqueId**
Właściwość Aspose.Slides.IShape.UniqueId zwraca unikalny w ramach prezentacji identyfikator kształtu. Te unikalne identyfikatory są przechowywane w niestandardowych znacznikach kształtu.
### **Zmieniono sygnaturę metody SetGroupingItem w IChartCategoryLevelsManager**
Sygnatura metody IChartCategoryLevelsManager

``` csharp

 void SetGroupingItem(int level, IChartDataCell value);

```

jest teraz przestarzała i została zastąpiona sygnaturą

``` csharp

 void SetGroupingItem(int level, object value);

```

Obecne wywołania takie jak

``` csharp

 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));

```

muszą zostać zmienione na wywołania takie jak

``` csharp

 .SetGroupingItem(1, "Group 1");

```

Przekaż wartość taką jak "Group 1" do SetGroupingItem, a nie wartość typu IChartDataCell. Tworzenie IChartDataCell z określonym arkuszem, wierszem i kolumną dla poziomów kategorii musi spełniać pewne wymagania i zostało enkapsulowane w metodzie SetGroupingItem(int, object).
### **Do interfejsu Aspose.Slides.IBaseSlide dodano własność SlideId**
Właściwość SlideId zwraca unikalny identyfikator slajdu.
### **Do ISlideShowTransition dodano własność SoundName**
String odczytywalny i zapisywalny. Określa czytelną nazwę dźwięku przejścia. Właściwość Sound musi być przypisana, aby odczytać lub ustawić nazwę dźwięku. Nazwa ta pojawia się w interfejsie użytkownika PowerPoint przy ręcznej konfiguracji dźwięku przejścia. Może rzucić PptxException, gdy właściwość Sound nie jest przypisana.
### **Zmieniono typ własności ChartSeriesGroup.Type**
Właściwość ChartSeriesGroup.Type została zmieniona z wyliczenia ChartType na nowe wyliczenie CombinableSeriesTypesGroup. Enum CombinableSeriesTypesGroup reprezentuje grupy łączonych typów serii.
### **Dodano obsługę generowania indywidualnych miniatur kształtów**
Aspose.Slides.ShapeThumbnailBounds

Nowe członki w Aspose.Slides.IShape, Aspose.Slides.Shape:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)