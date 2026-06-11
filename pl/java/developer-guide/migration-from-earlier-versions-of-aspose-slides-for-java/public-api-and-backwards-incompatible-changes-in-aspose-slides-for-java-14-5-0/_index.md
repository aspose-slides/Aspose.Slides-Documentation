---
title: Publiczne API i zmiany niekompatybilne wstecz w Aspose.Slides for Java 14.5.0
linktitle: Aspose.Slides dla Java 14.5.0
type: docs
weight: 40
url: /pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
keywords:
- migracja
- kod legacy
- nowoczesny kod
- podejście legacy
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Przegląd aktualizacji publicznego API i zmian łamiących w Aspose.Slides for Java, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX oraz ODP."
---
{{% alert color="primary" %}} 

Ta strona wymienia wszystkie [dodane](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) klasy, metody, właściwości i tak dalej, wszelkie nowe [ograniczenia](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) oraz inne [zmiany](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) wprowadzone w API Aspose.Slides for Java 14.5.0.

{{% /alert %}} 
## **Publiczne API i zmiany niekompatybilne wstecz**
### **Dodane klasy i metody**
#### **Dodano interfejs Aspose.Slides.IPresentationInfo oraz klasy PresentationInfo**
Reprezentuje informacje o prezentacji.

Metoda Boolean isEncrypted() zwraca True, jeśli prezentacja jest zaszyfrowana, w przeciwnym razie zwraca False.

Metoda LoadFormat getLoadFormat() zwraca typ prezentacji.
#### **Dodano metodę Aspose.Slides.IShape.isGrouped()**
Metoda Aspose.Slides.IShape.isGrouped() określa, czy kształt jest grupowany.
#### **Dodano metodę Aspose.Slides.IShape.getParentGroup()**
Metoda Aspose.Slides.IShape.getParentGroup() zwraca obiekt rodzica typu GroupShape, jeśli kształt jest grupowany. W przeciwnym razie zwraca null.
#### **Dodano metodę Aspose.Slides.IShapeCollection.addGroupShape()**
Metoda Aspose.Slides.IShapeCollection.addGroupShape() tworzy nowy GroupShape i dodaje go na koniec kolekcji.

Rozmiar i pozycja ramki GroupShape zostaną dopasowane do zawartości, gdy nowy kształt zostanie dodany do GroupShape.
#### **Dodano metodę Aspose.Slides.IShapeCollection.clear()**
Metoda Aspose.Slides.IShapeCollection.clear() usuwa wszystkie kształty z kolekcji.
#### **Dodano metodę Aspose.Slides.IShapeCollection.insertGroupShape(int)**
Metoda Aspose.Slides.IShapeCollection.insertGroupShape(int) tworzy nowy GroupShape i wstawia go do kolekcji pod wskazanym indeksem.
Rozmiar i pozycja ramki GroupShape zostaną dopasowane do zawartości, gdy nowy kształt zostanie dodany do GroupShape.
#### **Dodano metody IPresentationFactory.getPresentationInfo(string file), IPresentatoinFactory.getPresentationInfo(InputStream stream)**
Te metody umożliwiają programistom uzyskanie informacji o pliku/prądzie prezentacji bez pełnego ładowania prezentacji.
#### **Dodano metodę IPresentationFactory PresentationFactory.getInstance()**
Umożliwia korzystanie z funkcjonalności fabryki bez tworzenia jej instancji.
### **Ograniczenia**
#### **Dodano ograniczenia dotyczące używania niezdefiniowanych wartości dla IShape.getFrame()**
Kod, który próbuje przypisać niezdefiniowaną ramkę do IShape.setFrame(IShapeFrame), nie ma sensu w ogólnych przypadkach (szczególnie gdy rodzicowski GroupShape jest wielokrotnie zagnieżdżony w innych {{GroupShape}}ach). Na przykład:

``` java

 IShape shape = ...;

shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));

```

lub

``` java

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);

```

Taki kod może prowadzić do niejasnych sytuacji. Dlatego dodano ograniczenia dotyczące używania niezdefiniowanych wartości dla IShape.Frame. Wartości x, y, width, height, flipH, flipV oraz rotationAngle muszą być zdefiniowane (nie Float.NaN ani NullableBool.NotDefined). Powyższy przykładowy kod teraz zgłasza wyjątek ArgumentException.
Dotyczy to następujących przypadków użycia:

``` java

 IShape shape = ...;

shape.setFrame(...); // nie może być niezdefiniowane

IShapeCollection shapes = ...;

// parametry x, y, szerokość, wysokość nie mogą być Float.NaN:

{

    shapes.addAudioFrameCD(...);

    shapes.addAudioFrameEmbedded(...);

    shapes.addAudioFrameLinked(...);

    shapes.addAutoShape(...);

    shapes.addChart(...);

    shapes.addConnector(...);

    shapes.addOleObjectFrame(...);

    shapes.addPictureFrame(...);

    shapes.addSmartArt(...);

    shapes.addTable(...);

    shapes.addVideoFrame(...);

    shapes.insertAudioFrameEmbedded(...);

    shapes.insertAudioFrameLinked(...);

    shapes.insertAutoShape(...);

    shapes.insertChart(...);

    shapes.insertConnector(...);

    shapes.insertOleObjectFrame(...);

    shapes.insertPictureFrame(...);

    shapes.insertTable(...);

    shapes.insertVideoFrame(...);

}

```

Jednak ramka IShape.getRawFrame() może być niezdefiniowana. Ma to sens, gdy kształt jest powiązany z placeholderem. Wtedy niezdefiniowane wartości ramki kształtu są nadpisywane wartościami z rodzicielskiego placeholdera. Jeśli dla tego kształtu nie istnieje rodzicielski placeholder, używane są wartości domyślne przy wyliczaniu efektywnej ramki na podstawie IShape.getRawFrame(). Domyślne wartości to 0 oraz NullableBool.False dla x, y, width, height, flipH, flipV i rotationAngle. Na przykład:

``` java

 IShape shape = ...; // kształt jest powiązany z placeholderem

shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

// teraz kształt dziedziczy wartości x, y, height, flipH, flipV z placeholdera i nadpisuje width=100 oraz rotationAngle=0.

```
### **Zmienione właściwości**
#### **Zmieniono typ i nazwę metody Aspose.Slides.IShapeCollection.getParent()**
Typ właściwości Aspose.Slides.IShapeCollection.Parent został zmieniony z ISlideComponent na nowy interfejs IGroupShape. Interfejs IGroupShape jest pochodną ISlideComponent, więc istniejący kod nie wymaga dostosowania.

Nazwa metody Aspose.Slides.IShapeCollection.getParent() została zmieniona z getParent na getParentGroup().
#### **Zmieniono typ metod Aspose.Slides.IShapeFrame.getFlipH() i .getFlipV()**
Typ metody Aspose.Slides.IShapeFrame.getFlipH() został zmieniony z bool na NullableBool.

Metoda IShape.getFrame() zwraca efektywną instancję IShapeFrame (wszystkie jej właściwości mają zdefiniowane wartości efektywne).

Metoda IShape.getRawFrame() zwraca instancję IShapeFrame, której każda właściwość może mieć niezdefiniowaną wartość (szczególnie FlipH lub FlipV może mieć wartość NullableBool.NotDefined).