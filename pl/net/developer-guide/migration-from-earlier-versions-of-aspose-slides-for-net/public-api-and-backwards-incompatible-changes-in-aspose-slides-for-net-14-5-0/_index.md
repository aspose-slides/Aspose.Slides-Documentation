---
title: Publiczne API i zmiany niekompatybilne wstecz w Aspose.Slides dla .NET 14.5.0
linktitle: Aspose.Slides dla .NET 14.5.0
type: docs
weight: 70
url: /pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
keywords:
- migracja
- kod dziedziczony
- kod nowoczesny
- podejście dziedziczone
- podejście nowoczesne
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Przeglądaj aktualizacje publicznego API oraz zmiany łamiące kompatybilność w Aspose.Slides dla .NET, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="info" %}} 

Ta strona wymienia wszystkie [dodane](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) klasy, metody, właściwości i tak dalej, wszystkie nowe [ograniczenia](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) oraz inne [zmiany](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) wprowadzone w API Aspose.Slides dla .NET 14.5.0.

{{% /alert %}} 
## **Publiczne API i zmiany niekompatybilne wstecz**
### **Dodane interfejsy, klasy, właściwości i metody**
#### **Dodano interfejs Aspose.Slides.IPresentationInfo i klasę PresentationInfo**
Reprezentuje informacje o prezentacji.

- Właściwość boolowska IsEncrypted zwraca True, jeśli prezentacja jest zaszyfrowana, w przeciwnym razie zwraca False.
- Właściwość LoadFormat zwiera typ prezentacji.
#### **Dodano właściwość Aspose.Slides.IShape.IsGrouped**
Właściwość Aspose.Slides.IShape.IsGrouped określa, czy kształt jest grupowany.
#### **Dodano właściwość Aspose.Slides.IShape.ParentGroup**
Właściwość Aspose.Slides.IShape.ParentGroup zwraca obiekt nadrzędny GroupShape, jeśli kształt jest grupowany. W przeciwnym razie zwraca null.
#### **Dodano metodę Aspose.Slides.IShapeCollection.AddGroupShape()**
Metoda Aspose.Slides.IShapeCollection.AddGroupShape() tworzy nowy obiekt GroupShape i dodaje go na koniec kolekcji.
Rozmiar ramki i pozycja GroupShape zostaną dopasowane do zawartości po dodaniu nowego kształtu.
#### **Dodano metodę Aspose.Slides.IShapeCollection.Clear()**
Metoda Aspose.Slides.IShapeCollection.Clear() usuwa wszystkie kształty z kolekcji.
#### **Dodano metodę Aspose.Slides.IShapeCollection.InsertGroupShape(int)**
Metoda Aspose.Slides.IShapeCollection.InsertGroupShape(int) tworzy nowy obiekt GroupShape i wstawia go do kolekcji na wskazanej pozycji indeksu.
Rozmiar ramki i pozycja GroupShape zostaną dopasowane do zawartości po dodaniu nowego kształtu.
#### **Dodano metody IPresentationFactory.GetPresentationInfo(string file), IPresentatoinFactory.GetPresentationInfo(Stream stream)**
Te metody umożliwiają uzyskanie informacji o pliku lub strumieniu prezentacji bez pełnego ładowania prezentacji.
#### **Dodano właściwość IPresentationFactory PresentationFactory.Instance**
Ta właściwość pozwala programistom korzystać z funkcjonalności fabryki bez tworzenia jej instancji.
### **Ograniczenia**
#### **Ograniczenia dla IShape.Frame**
Dodano ograniczenia dotyczące używania nieokreślonych wartości dla IShape.Frame. Kod, który próbuje przypisać nieokreśloną ramkę do IShape.Frame, nie ma sensu w większości przypadków (szczególnie gdy nadrzędny GroupShape jest wielokrotnie zagnieżdżony w innych {{GroupShape}}). Na przykład:

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShape shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

// Rzuca ArgumentException: wartości ramki muszą być określone.
shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);
``` 

lub

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Rzuca ArgumentException: x, y, szerokość i wysokość muszą być określone.
slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);
``` 

Taki kod może prowadzić do niejasnych sytuacji. Dlatego wprowadzono ograniczenia dotyczące używania nieokreślonych wartości dla IShape.Frame. Wartości x, y, width, height, flipH, flipV oraz rotationAngle muszą być określone (i nie mogą być ustawione na float.NaN lub NullableBool.NotDefined). Powyższy przykładowy kod teraz zgłasza wyjątek ArgumentException.
Dotyczy to następujących przypadków użycia:

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Parametry x, y, width i height nie mogą być float.NaN, a flipH, flipV
// nie mogą być NullableBool.NotDefined:
IShape shape = shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
shape.Frame = new ShapeFrame(100, 100, 200, 100, NullableBool.False, NullableBool.False, 0);

// To samo ograniczenie dotyczy każdej metody, która tworzy kształt:
// AddAudioFrameCD, AddAudioFrameEmbedded, AddAudioFrameLinked, AddAutoShape, AddChart,
// AddConnector, AddOleObjectFrame, AddPictureFrame, AddSmartArt, AddTable, AddVideoFrame,
// InsertAudioFrameEmbedded, InsertAudioFrameLinked, InsertAutoShape, InsertChart,
// InsertConnector, InsertOleObjectFrame, InsertPictureFrame, InsertTable, InsertVideoFrame.
``` 

Jednak właściwości ramki IShape.RawFrame mogą być nieokreślone. Ma to sens, gdy kształt jest połączony z placeholderem. Wtedy nieokreślone wartości ramki kształtu są nadpisywane wartościami z nadrzędnego placeholdera. Jeśli nie ma nadrzędnego placeholdera, kształt korzysta z wartości domyślnych przy obliczaniu efektywnej ramki na podstawie IShape.RawFrame. Wartości domyślne to 0 oraz NullableBool.False dla x, y, width, height, flipH, flipV i rotationAngle. Na przykład:

``` csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Kształt jest powiązany z placeholderem
    IShape shape = presentation.Slides[0].Shapes[0];

    shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

    // teraz kształt odziedzicza wartości x, y, wysokości, flipH, flipV z placeholdera i nadpisuje szerokość=100 oraz rotationAngle=0.
}
``` 
### **Zmienione właściwości**
#### **Zmieniono nazwę i typ właściwości Aspose.Slides.IShapeCollection.Parent**
- Typ właściwości Aspose.Slides.IShapeCollection.Parent został zmieniony z ISlideComponent na nowy interfejs IGroupShape. Interfejs IGroupShape jest potomkiem ISlideComponent, więc istniejący kod nie wymaga adaptacji.
- Nazwa właściwości Aspose.Slides.IShapeCollection.Parent została zmieniona z Parent na ParentGroup.
#### **Zmieniono typy właściwości Aspose.Slides.IShapeFrame.FlipH, .FlipV**
- Typ właściwości Aspose.Slides.IShapeFrame.FlipH został zmieniony z bool na NullableBool.
- Właściwość IShape.Frame zwraca efektywną instancję IShapeFrame (wszystkie jej właściwości mają określone wartości efektywne).
- Właściwość IShape.RawFrame zwraca instancję IShapeFrame, której każda właściwość może mieć nieokreśloną wartość (szczególnie FlipH lub FlipV mogą mieć wartość NullableBool.NotDefined).