---
title: Publiczny API i zmiany niekompatybilne wstecz w Aspose.Slides dla .NET 14.5.0
linktitle: Aspose.Slides dla .NET 14.5.0
type: docs
weight: 70
url: /pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
keywords:
- migracja
- kod starszy
- nowoczesny kod
- podejście tradycyjne
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Przegląd aktualizacji publicznego API oraz zmian łamiących kompatybilność w Aspose.Slides dla .NET, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="primary" %}} 

Ta strona zawiera wszystkie [dodane](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) klasy, metody, właściwości i tak dalej, wszelkie nowe [ograniczenia](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) oraz inne [zmiany](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) wprowadzone w API Aspose.Slides for .NET 14.5.0.

{{% /alert %}} 
## **Publiczny API i zmiany niekompatybilne wstecz**
### **Dodane interfejsy, klasy, właściwości i metody**
#### **Dodano interfejs Aspose.Slides.IPresentationInfo oraz klasę PresentationInfo**
Reprezentuje informacje o prezentacji.

- Właściwość Boolean IsEncrypted zwraca True, jeśli prezentacja jest zaszyfrowana, w przeciwnym razie zwraca False.
- Właściwość LoadFormat zwraca typ prezentacji.
#### **Dodano właściwość Aspose.Slides.IShape.IsGrouped**
Właściwość Aspose.Slides.IShape.IsGrouped określa, czy kształt jest zgrupowany.
#### **Dodano właściwość Aspose.Slides.IShape.ParentGroup**
Właściwość Aspose.Slides.IShape.ParentGroup zwraca obiekt GroupShape nadrzędny, jeśli kształt jest zgrupowany. W przeciwnym razie zwraca null.
#### **Dodano metodę Aspose.Slides.IShapeCollection.AddGroupShape()**
Metoda Aspose.Slides.IShapeCollection.AddGroupShape() tworzy nowy GroupShape i dodaje go na koniec kolekcji.
Rozmiar i pozycja ramki GroupShape zostaną dopasowane do zawartości, gdy zostanie dodany nowy kształt.
#### **Dodano metodę Aspose.Slides.IShapeCollection.Clear()**
Metoda Aspose.Slides.IShapeCollection.Clear() usuwa wszystkie kształty z kolekcji.
#### **Dodano metodę Aspose.Slides.IShapeCollection.InsertGroupShape(int)**
Metoda Aspose.Slides.IShapeCollection.InsertGroupShape(int) tworzy nowy GroupShape i wstawia go do kolekcji na określonej pozycji indeksu.
Rozmiar i pozycja ramki GroupShape zostaną dopasowane do zawartości, gdy zostanie dodany nowy kształt.
#### **Dodano metody IPresentationFactory.GetPresentationInfo(string file), IPresentatoinFactory.GetPresentationInfo(Stream stream)**
Metody te umożliwiają uzyskanie informacji o pliku prezentacji lub strumieniu bez pełnego ładowania prezentacji.
#### **Dodano właściwość IPresentationFactory PresentationFactory.Instance**
Właściwość ta pozwala programistom korzystać z funkcjonalności fabryki bez jej tworzenia.
### **Ograniczenia**
#### **Ograniczenia dotyczące IShape.Frame**
Wprowadzono ograniczenia dotyczące używania niezdefiniowanych wartości dla IShape.Frame. Kod, który próbuje przypisać niezdefiniowaną ramkę do IShape.Frame, nie ma sensu w większości przypadków (szczególnie gdy rodzic GroupShape jest wielokrotnie zagnieżdżony w innych {{GroupShape}}). Na przykład:

``` csharp

 IShape shape = ...;

shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);


``` 

lub

``` csharp

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);

``` 

Taki kod może prowadzić do niejasnych sytuacji. Dlatego wprowadzono ograniczenia dotyczące używania niezdefiniowanych wartości dla IShape.Frame. Wartości x, y, width, height, flipH, flipV oraz rotationAngle muszą być zdefiniowane (i nie mogą być ustawione na float.NaN lub NullableBool.NotDefined). Powyższy przykładowy kod teraz zgłasza wyjątek ArgumentException.
Dotyczy to następujących scenariuszy:

``` csharp

 IShape shape = ...;

shape.Frame = ...; // Nie może być niezdefiniowane

IShapeCollection shapes = ...;

// Parametry x, y, width, height nie mogą być float.NaN:

{
    shapes.AddAudioFrameCD(...);
    shapes.AddAudioFrameEmbedded(...);
    shapes.AddAudioFrameLinked(...);
    shapes.AddAutoShape(...);
    shapes.AddChart(...);
    shapes.AddConnector(...);
    shapes.AddOleObjectFrame(...);
    shapes.AddPictureFrame(...);
    shapes.AddSmartArt(...);
    shapes.AddTable(...);
    shapes.AddVideoFrame(...);
    shapes.InsertAudioFrameEmbedded(...);
    shapes.InsertAudioFrameLinked(...);
    shapes.InsertAutoShape(...);
    shapes.InsertChart(...);
    shapes.InsertConnector(...);
    shapes.InsertOleObjectFrame(...);
    shapes.InsertPictureFrame(...);
    shapes.InsertTable(...);
    shapes.InsertVideoFrame(...);
}
``` 

Jednak właściwości ramki IShape.RawFrame mogą być nieokreślone. Ma to sens, gdy kształt jest powiązany z placeholderem. Wtedy niezdefiniowane wartości ramki kształtu są nadpisywane z ramki placeholdera nadrzędnego. Jeśli nie ma placeholdera nadrzędnego, kształt używa wartości domyślnych przy wyliczaniu efektywnej ramki na podstawie IShape.RawFrame. Wartości domyślne to 0 oraz NullableBool.False dla x, y, width, height, flipH, flipV i rotationAngle. Na przykład:

``` csharp

 IShape shape = ...; // kształt jest powiązany z placeholderem

shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

// teraz kształt dziedziczy wartości x, y, height, flipH, flipV z placeholdera i nadpisuje width=100 oraz rotationAngle=0.

``` 
### **Zmienione właściwości**
#### **Zmieniono nazwę i typ właściwości Aspose.Slides.IShapeCollection.Parent**
- Typ właściwości Aspose.Slides.IShapeCollection.Parent został zmieniony z ISlideComponent na nowy interfejs IGroupShape. Interfejs IGroupShape jest potomkiem ISlideComponent, więc istniejący kod nie wymaga adaptacji.
- Nazwa właściwości Aspose.Slides.IShapeCollection.Parent została zmieniona z Parent na ParentGroup.
#### **Zmieniono typy właściwości Aspose.Slides.IShapeFrame.FlipH, .FlipV**
- Typ właściwości Aspose.Slides.IShapeFrame.FlipH został zmieniony z bool na NullableBool.
- Właściwość IShape.Frame zwraca efektywną instancję IShapeFrame (wszystkie jej właściwości mają zdefiniowane wartości skuteczne).
- Właściwość IShape.RawFrame zwraca instancję IShapeFrame, której każda właściwość może mieć nieokreśloną wartość (szczególnie FlipH lub FlipV może mieć wartość NullableBool.NotDefined).