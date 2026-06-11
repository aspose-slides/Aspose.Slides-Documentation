---
title: Zarządzanie kształtami prezentacji w JavaScript
linktitle: Manipulacja kształtami
type: docs
weight: 40
url: /pl/nodejs-java/shape-manipulations/
keywords:
- Kształt PowerPoint
- Kształt prezentacji
- Kształt na slajdzie
- Znajdź kształt
- Klonuj kształt
- Usuń kształt
- Ukryj kształt
- Zmień kolejność kształtu
- Pobierz Interop Shape ID
- Alternatywny tekst kształtu
- Formaty układu kształtu
- Kształt jako SVG
- Kształt do SVG
- Wyrównaj kształt
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak tworzyć, edytować i optymalizować kształty przy użyciu JavaScript oraz Aspose.Slides dla Node.js via Java, aby tworzyć wysokowydajne prezentacje PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z kształtami w prezentacjach przy użyciu Aspose.Slides. Pokazuje, jak znaleźć kształt na slajdzie, sklonować go, usunąć, ukryć, zmienić kolejność, uzyskać Interop shape ID oraz ustawić tekst alternatywny w celu identyfikacji i dalszego przetwarzania.

Omówiono także dostęp do formatów układu dla kształtów, renderowanie kształtu jako SVG, wyrównywanie kształtów na slajdzie oraz użycie właściwości odbicia poziomego i pionowego. Ponadto artykuł zawiera krótkie FAQ dotyczące łączenia kształtów, kolejności warstw oraz blokowania kształtów.

## **Znajdowanie kształtu na slajdzie**
Ten temat opisuje prostą technikę ułatwiającą programistom znajdowanie konkretnego kształtu na slajdzie bez użycia jego wewnętrznego Id. Ważne jest, aby wiedzieć, że pliki PowerPoint nie posiadają żadnego sposobu identyfikacji kształtów na slajdzie oprócz wewnętrznego unikatowego Id. Dla programistów może być trudne odnalezienie kształtu po jego wewnętrznym Id. Wszystkie kształty dodane do slajdów mają jakiś Tekst alternatywny. Zalecamy używanie tekstu alternatywnego do znajdowania konkretnego kształtu. Możesz użyć MS PowerPoint, aby zdefiniować tekst alternatywny dla obiektów, które planujesz zmienić w przyszłości.

Po ustawieniu tekstu alternatywnego dowolnego pożądanego kształtu, możesz otworzyć tę prezentację przy użyciu Aspose.Slides for Node.js via Java i przeiterować wszystkie kształty dodane do slajdu. Podczas każdej iteracji możesz sprawdzić tekst alternatywny kształtu, a kształt z pasującym tekstem będzie tym, którego potrzebujesz. Aby lepiej zilustrować tę technikę, utworzyliśmy metodę [findShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideUtil#findShape-aspose.slides.IBaseSlide-java.lang.String-) wykonującą wyszukiwanie konkretnego kształtu na slajdzie i zwracającą ten kształt.

```javascript
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji
var pres = new aspose.slides.Presentation("FindingShapeInSlide.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // Alternatywny tekst kształtu do znalezienia
    var shape = findShape(slide, "Shape1");
    if (shape != null) {
        console.log("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
function findShape(slide, altText) {
    let shapes = slide.getShapes();
    
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i);
        
        if (shape.getAlternativeText() === altText) {
            return shape;
        }
    }

    return null;
}
```

## **Klonowanie kształtu**
Aby sklonować kształt na slajdzie przy użyciu Aspose.Slides for Node.js via Java:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
1. Pobierz referencję do slajdu, używając jego indeksu.
1. Uzyskaj dostęp do kolekcji kształtów slajdu źródłowego.
1. Dodaj nowy slajd do prezentacji.
1. Skopiuj kształty z kolekcji kształtów slajdu źródłowego do nowego slajdu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy przykład dodaje grupowy kształt do slajdu.

```javascript
// Utwórz instancję klasy Presentation
var pres = new aspose.slides.Presentation("Source Frame.pptx");
try {
    var sourceShapes = pres.getSlides().get_Item(0).getShapes();
    var blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    var destSlide = pres.getSlides().addEmptySlide(blankLayout);
    var destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);
    // Zapisz plik PPTX na dysku
    pres.save("CloneShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Usuwanie kształtu**
Aspose.Slides for Node.js via Java umożliwia programistom usunięcie dowolnego kształtu. Aby usunąć kształt z dowolnego slajdu, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
1. Uzyskaj dostęp do pierwszego slajdu.
1. Znajdź kształt o określonym AlternativeText.
1. Usuń kształt.
1. Zapisz plik na dysku.

```javascript
// Utwórz obiekt Presentation
var pres = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd
    var sld = pres.getSlides().get_Item(0);
    // Dodaj autokształt typu prostokąt
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var altText = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(0);
        if (alttext === ashp.getAlternativeText()) {
            sld.getShapes().remove(ashp);
        }
    }
    // Zapisz prezentację na dysku
    pres.save("RemoveShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ukrywanie kształtu**
Aspose.Slides for Node.js via Java umożliwia programistom ukrycie dowolnego kształtu. Aby ukryć kształt na dowolnym slajdzie, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
1. Uzyskaj dostęp do pierwszego slajdu.
1. Znajdź kształt o określonym AlternativeText.
1. Ukryj kształt.
1. Zapisz plik na dysku.

```javascript
// Utwórz instancję klasy Presentation, która reprezentuje plik PPTX
var pres = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd
    var sld = pres.getSlides().get_Item(0);
    // Dodaj autokształt typu prostokąt
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var alttext = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(i);
        if (alttext === ashp.getAlternativeText()) {
            ashp.setHidden(true);
        }
    }
    // Zapisz prezentację na dysku
    pres.save("Hiding_Shapes_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Zmiana kolejności kształtów**
Aspose.Slides for Node.js via Java umożliwia programistom zmianę kolejności kształtów. Zmiana kolejności określa, który kształt jest na wierzchu, a który z tyłu. Aby zmienić kolejność kształtów na dowolnym slajdzie, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
1. Uzyskaj dostęp do pierwszego slajdu.
1. Dodaj kształt.
1. Dodaj tekst do ramki tekstowej kształtu.
1. Dodaj kolejny kształt w tych samych współrzędnych.
1. Zmień kolejność kształtów.
1. Zapisz plik na dysku.

```javascript
var pres = new aspose.slides.Presentation("ChangeShapeOrder.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shp3.addTextFrame(" ");
    var para = shp3.getTextFrame().getParagraphs().get_Item(0);
    var portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");
    shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Triangle, 200, 365, 400, 150);
    slide.getShapes().reorder(2, shp3);
    pres.save("Reshape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Pobieranie Interop Shape ID**
Aspose.Slides for Node.js via Java umożliwia programistom uzyskanie unikalnego identyfikatora kształtu w zakresie slajdu, w przeciwieństwie do metody [getUniqueId](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Shape#getUniqueId--) zwracającej unikatowy identyfikator w zakresie prezentacji. Metoda [getOfficeInteropShapeId](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) została dodana do klasy [Shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Shape). Wartość zwracana przez [getOfficeInteropShapeId](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) odpowiada Id obiektu Microsoft.Office.Interop.PowerPoint.Shape. Poniżej znajduje się przykładowy kod.

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Uzyskiwanie unikalnego identyfikatora kształtu w zakresie slajdu
    var officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ustawianie tekstu alternatywnego dla kształtu**
Aspose.Slides for Node.js via Java umożliwia programistom ustawienie AlternateText dowolnego kształtu.
Kształty w prezentacji można odróżnić przy użyciu metody [AlternativeText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) lub [Shape Name](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Shape#setName-java.lang.String-).
Metody [setAlternativeText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) i [getAlternativeText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Shape#getAlternativeText--) mogą być odczytywane lub ustawiane zarówno w Aspose.Slides, jak i w Microsoft PowerPoint.
Korzystając z tej metody, możesz oznaczyć kształt i wykonywać różne operacje, takie jak usuwanie, ukrywanie lub zmiana kolejności kształtów na slajdzie.
Aby ustawić AlternateText kształtu, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
1. Uzyskaj dostęp do pierwszego slajdu.
1. Dodaj dowolny kształt do slajdu.
1. Wykonaj potrzebne operacje na nowo dodanym kształcie.
1. Przejdź przez kształty, aby znaleźć żądany kształt.
1. Ustaw AlternativeText.
1. Zapisz plik na dysku.

```javascript
// Utwórz instancję klasy Presentation, która reprezentuje plik PPTX
var pres = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd
    var sld = pres.getSlides().get_Item(0);
    // Dodaj autokształt typu prostokąt
    var shp1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    var shp2 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    for (var i = 0; i < sld.getShapes().size(); i++) {
        var shape = sld.getShapes().get_Item(i);
        if (shape != null) {
            shape.setAlternativeText("User Defined");
        }
    }
    // Zapisz prezentację na dysku
    pres.save("Set_AlternativeText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Dostęp do formatów układu dla kształtu**
Aspose.Slides for Node.js via Java zapewnia prosty interfejs API do uzyskiwania formatów układu dla kształtu. W tym artykule przedstawiono, jak uzyskać dostęp do formatów układu.

Poniżej znajduje się przykładowy kod.

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (let i = 0; i < pres.getLayoutSlides().size(); i++) {
        let layoutSlide = pres.getLayoutSlides().get_Item(i);
        for (let j = 0; j < layoutSlide.getShapes().size(); j++) {
            let shape = layoutSlide.getShapes().get_Item(j);
            var fillFormats = shape.getFillFormat();
            var lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Renderowanie kształtu jako SVG**
Teraz Aspose.Slides for Node.js via Java obsługuje renderowanie kształtu jako SVG. Metoda [writeAsSvg](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Shape#writeAsSvg-java.io.OutputStream-) (oraz jej przeciążenie) została dodana do klasy [Shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Shape). Metoda ta pozwala zapisać zawartość kształtu jako plik SVG. Poniższy fragment kodu pokazuje, jak wyeksportować kształt ze slajdu do pliku SVG.

```javascript
var pres = new aspose.slides.Presentation("TestExportShapeToSvg.pptx");
try {
    var stream = java.newInstanceSync("java.io.FileOutputStream", "SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) {
            stream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Wyrównywanie kształtów**
Aspose.Slides umożliwia wyrównywanie kształtów względem marginesów slajdu lub względem siebie nawzajem. W tym celu dodano przeciążoną metodę [SlidesUtil.alignShape()](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideUtil#alignShapes-int-boolean-aspose.slides.IBaseSlide-int:A-). Wyliczenie [ShapesAlignmentType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapesAlignmentType) definiuje dostępne opcje wyrównania.

**Przykład 1**

Poniższy kod wyrównuje kształty o indeksach 1, 2 i 4 wzdłuż górnej krawędzi slajdu.

```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shape1 = slide.getShapes().get_Item(1);
    var shape2 = slide.getShapes().get_Item(2);
    var shape3 = slide.getShapes().get_Item(4);
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), java.newArray("int", [slide.getShapes().indexOf(shape1), slide.getShapes().indexOf(shape2), slide.getShapes().indexOf(shape3)]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

**Przykład 2**

Poniższy przykład pokazuje, jak wyrównać całą kolekcję kształtów względem najniższego kształtu w kolekcji.

```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Właściwości odbicia**

W Aspose.Slides klasa [ShapeFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapeframe/) zapewnia kontrolę nad poziomym i pionowym odbiciem kształtów za pomocą właściwości `flipH` i `flipV`. Obie właściwości są typu `byte`, przyjmując wartość `1` jako odbicie, `0` jako brak odbicia lub `-1` jako zachowanie domyślne. Wartości te są dostępne z [Frame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/#getFrame) kształtu.

Aby zmodyfikować ustawienia odbicia, tworzy się nową instancję [ShapeFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapeframe/) z bieżącą pozycją i rozmiarem kształtu, pożądanymi wartościami `flipH` i `flipV` oraz kątem obrotu. Przypisanie tej instancji do [Frame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/#getFrame) kształtu i zapisanie prezentacji stosuje transformacje lustrzane i zapisuje je w pliku wyjściowym.

Załóżmy, że mamy plik sample.pptx, w którym pierwszy slajd zawiera pojedynczy kształt z domyślnymi ustawieniami odbicia, jak pokazano poniżej.

![The shape to be flipped](shape_to_be_flipped.png)

Poniższy przykład kodu pobiera bieżące właściwości odbicia kształtu i odbija go zarówno w poziomie, jak i w pionie.

```js
var presentation = new asposeSlides.Presentation("sample.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    // Pobierz właściwość odbicia poziomego kształtu.
    var horizontalFlip = shape.getFrame().getFlipH();
    console.log("Horizontal flip:", horizontalFlip);

    // Pobierz właściwość odbicia pionowego kształtu.
    var verticalFlip = shape.getFrame().getFlipV();
    console.log("Vertical flip:", verticalFlip);

    var x = java.newFloat(shape.getFrame().getX());
    var y = java.newFloat(shape.getFrame().getY());
    var width = java.newFloat(shape.getFrame().getWidth());
    var height = java.newFloat(shape.getFrame().getHeight());
    var flipH = java.newByte(asposeSlides.NullableBool.True); // Odbicie poziome.
    var flipV = java.newByte(asposeSlides.NullableBool.True); // Odbicie pionowe.
    var rotation = shape.getFrame().getRotation();

    shape.setFrame(new asposeSlides.ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![The flipped shape](flipped_shape.png)

## **FAQ**

**Czy mogę łączyć kształty (union/intersect/subtract) na slajdzie tak jak w edytorze desktopowym?**

Nie istnieje wbudowane API operacji boolowskich. Można je przybliżyć, tworząc własny kontur — np. obliczając powstałą geometrię (przy użyciu [GeometryPath](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/geometrypath/)) i tworząc nowy kształt z tym konturem, opcjonalnie usuwając oryginalne kształty.

**Jak kontrolować kolejność warstw (z‑order), aby kształt zawsze pozostawał „na wierzchu”?**

Zmieniaj kolejność wstawiania/przenoszenia w kolekcji [shapes](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseslide/#getShapes) slajdu. Dla przewidywalnych wyników ustal z‑order po zakończeniu wszystkich pozostałych modyfikacji slajdu.

**Czy mogę „zablokować” kształt, aby użytkownicy nie mogli go edytować w PowerPoint?**

Tak. Ustaw flagi ochrony na poziomie kształtu (np. blokada zaznaczania, przemieszczania, zmiany rozmiaru, edycji tekstu). W razie potrzeby zastosuj ograniczenia na poziomie mastera lub układu. Należy pamiętać, że jest to ochrona na poziomie interfejsu użytkownika, a nie mechanizm bezpieczeństwa; dla silniejszej ochrony można połączyć to z ograniczeniami na poziomie pliku, takimi jak zalecenia „tylko do odczytu” lub hasła [/slides/pl/nodejs-java/password-protected-presentation/](https://reference.aspose.com/slides/pl/nodejs-java/password-protected-presentation/).