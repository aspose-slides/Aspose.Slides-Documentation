---
title: Public API i zmiany niekompatybilne wstecznie w Aspose.Slides dla Java 14.5.0
linktitle: Aspose.Slides dla Java 14.5.0
type: docs
weight: 40
url: /pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
keywords:
- migracja
- kod legacy
- kod nowoczesny
- podejście legacy
- podejście nowoczesne
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Przegląd aktualizacji publicznego API oraz zmian niekompatybilnych w Aspose.Slides dla Java, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="info" %}} 

Ta strona wymienia wszystkie [dodane](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) klasy, metody, właściwości itp., wszelkie nowe [ograniczenia](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) oraz inne [zmiany](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) wprowadzone w API Aspose.Slides for Java 14.5.0.

{{% /alert %}} 
## **Public API i zmiany niekompatybilne wstecznie**
### **Dodane klasy i metody**
#### **Dodano interfejs Aspose.Slides.IPresentationInfo oraz klasy PresentationInfo**
Reprezentuje informacje o prezentacji.

Metoda Boolean isEncrypted() zwraca True, jeśli prezentacja jest zaszyfrowana, w przeciwnym razie zwraca False.

Metoda LoadFormat getLoadFormat() zwraca typ prezentacji.
#### **Dodano metodę Aspose.Slides.IShape.isGrouped()**
Metoda Aspose.Slides.IShape.isGrouped() określa, czy kształt jest pogrupowany.
#### **Dodano metodę Aspose.Slides.IShape.getParentGroup()**
Metoda Aspose.Slides.IShape.getParentGroup() zwraca obiekt nadrzędny GroupShape, jeśli kształt jest pogrupowany. W przeciwnym razie zwraca null.
#### **Dodano metodę Aspose.Slides.IShapeCollection.addGroupShape()**
Metoda Aspose.Slides.IShapeCollection.addGroupShape() tworzy nowy GroupShape i dodaje go na koniec kolekcji.

Rozmiar i pozycja ramki GroupShape będą dopasowywane do zawartości po dodaniu nowego kształtu do GroupShape.
#### **Dodano metodę Aspose.Slides.IShapeCollection.clear()**
Metoda Aspose.Slides.IShapeCollection.clear() usuwa wszystkie kształty z kolekcji.
#### **Dodano metodę Aspose.Slides.IShapeCollection.insertGroupShape(int)**
Metoda Aspose.Slides.IShapeCollection.insertGroupShape(int) tworzy nowy GroupShape i wstawia go do kolekcji pod wskazanym indeksem.

Rozmiar i pozycja ramki GroupShape będą dopasowywane do zawartości po dodaniu nowego kształtu do GroupShape.
#### **Dodano metody IPresentationFactory.getPresentationInfo(string file), IPresentationFactory.getPresentationInfo(InputStream stream)**
Te metody umożliwiają programistom uzyskanie informacji o pliku/strumieniu prezentacji bez pełnego ładowania prezentacji.
#### **Dodano metodę IPresentationFactory PresentationFactory.getInstance()**
Umożliwia korzystanie z funkcjonalności fabryki bez jej tworzenia.
### **Ograniczenia**
#### **Dodano ograniczenia dotyczące używania niezdefiniowanych wartości w IShape.getFrame()**
Kod, który próbuje przypisać niezdefiniowaną ramkę do IShape.setFrame(IShapeFrame), nie ma sensu w ogólnych przypadkach (szczególnie gdy nadrzędny GroupShape jest wielokrotnie zagnieżdżony w innych {{GroupShape}}). Na przykład:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    // Rzuca ArgumentException: wartości ramki muszą być określone.
    shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));
} finally {
    if (pres != null) pres.dispose();
}
```

lub

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Rzuca ArgumentException: wartości x, y, szerokość i wysokość muszą być określone.
    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);
} finally {
    if (pres != null) pres.dispose();
}
```

Takie kodowanie może prowadzić do niejasnych sytuacji. Dlatego wprowadzono ograniczenia dotyczące używania niezdefiniowanych wartości w IShape.Frame. Wartości x, y, width, height, flipH, flipV oraz rotationAngle muszą być określone (nie Float.NaN ani NullableBool.NotDefined). Powyższy przykład kodu teraz rzuca wyjątek ArgumentException.

Obowiązuje to w następujących przypadkach użycia:

``` java
// Ramka przekazana do IShape.setFrame(IShapeFrame) nie może zawierać niezdefiniowanych wartości.

// Parametry x, y, szerokość i wysokość następujących metod IShapeCollection
// nie mogą być również Float.NaN:
//
//     addAudioFrameCD
//     addAudioFrameEmbedded
//     addAudioFrameLinked
//     addAutoShape
//     addChart
//     addConnector
//     addOleObjectFrame
//     addPictureFrame
//     addSmartArt
//     addTable
//     addVideoFrame
//     insertAudioFrameEmbedded
//     insertAudioFrameLinked
//     insertAutoShape
//     insertChart
//     insertConnector
//     insertOleObjectFrame
//     insertPictureFrame
//     insertTable
//     insertVideoFrame
```

Jednak ramka IShape.getRawFrame() może być niezdefiniowana. Ma to sens, gdy kształt jest powiązany z placeholderem. Wtedy niezdefiniowane wartości ramki kształtu są nadpisywane przez wartości z nadrzędnego placeholdera. Jeśli nie ma nadrzędnego placeholdera dla tego kształtu, używane są wartości domyślne przy obliczaniu efektywnej ramki na podstawie IShape.getRawFrame(). Domyślne wartości to 0 oraz NullableBool.False dla x, y, width, height, flipH, flipV i rotationAngle. Na przykład:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    // Kształt jest powiązany z placeholderem.
    IShape shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);

    shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

    // Teraz kształt dziedziczy wartości x, y, wysokość, flipH i flipV z placeholdera
    // oraz nadpisuje szerokość = 100 i rotationAngle = 0.
} finally {
    if (pres != null) pres.dispose();
}
```
### **Zmienione właściwości**
#### **Zmieniono typ i nazwę metody Aspose.Slides.IShapeCollection.getParent()**
Typ właściwości Aspose.Slides.IShapeCollection.Parent został zmieniony z ISlideComponent na nowy interfejs IGroupShape. Interfejs IGroupShape jest potomkiem ISlideComponent, więc istniejący kod nie wymaga dostosowań.

Nazwa metody Aspose.Slides.IShapeCollection.getParent() została zmieniona z getParent na getParentGroup().
#### **Zmieniono typ metod Aspose.Slides.IShapeFrame.getFlipH() i .getFlipV()**
Typ metody Aspose.Slides.IShapeFrame.getFlipH() został zmieniony z bool na NullableBool.

Metoda IShape.getFrame() zwraca efektywną instancję IShapeFrame (wszystkie jej właściwości mają określone wartości efektywne).

Metoda IShape.getRawFrame() zwraca instancję IShapeFrame, w której każda właściwość może mieć niezdefiniowaną wartość (szczególnie FlipH lub FlipV może mieć wartość NullableBool.NotDefined).