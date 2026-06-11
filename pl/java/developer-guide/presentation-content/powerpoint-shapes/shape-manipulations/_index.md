---
title: Zarządzanie kształtami prezentacji w Javie
linktitle: Manipulacja kształtami
type: docs
weight: 40
url: /pl/java/shape-manipulations/
keywords:
- Kształt PowerPoint
- Kształt prezentacji
- Kształt na slajdzie
- Znajdź kształt
- Klonuj kształt
- Usuń kształt
- Ukryj kształt
- Zmień kolejność kształtów
- Pobierz Interop Shape ID
- Tekst alternatywny kształtu
- Formaty układu kształtu
- Kształt jako SVG
- Kształt do SVG
- Wyrównaj kształt
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak tworzyć, edytować i optymalizować kształty w Aspose.Slides dla Javy oraz dostarczać wysokowydajne prezentacje PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z kształtami w prezentacjach przy użyciu Aspose.Slides. Pokazuje, jak znaleźć kształt na slajdzie, sklonować go, usunąć, ukryć, zmienić kolejność, uzyskać jego identyfikator Interop oraz ustawić tekst alternatywny w celu identyfikacji i dalszego przetwarzania.

Omówiono również, jak uzyskać dostęp do formatów układu dla kształtów, renderować kształt jako SVG, wyrównywać kształty na slajdzie oraz używać właściwości odbicia do poziomego i pionowego lustrzanego odbicia. Dodatkowo artykuł zawiera krótkie FAQ dotyczące łączenia kształtów, kolejności warstw oraz blokowania kształtów.

## **Znajdowanie kształtu na slajdzie**
Ten temat opisuje prostą technikę ułatwiającą programistom znajdowanie określonego kształtu na slajdzie bez użycia jego wewnętrznego Id. Ważne jest, aby wiedzieć, że pliki PowerPoint nie posiadają innego sposobu identyfikacji kształtów na slajdzie niż wewnętrzny unikalny Id. Dla programistów może być trudne znalezienie kształtu przy użyciu tego Id. Wszystkie kształty dodane do slajdów mają jakiś tekst alternatywny. Zalecamy używanie tekstu alternatywnego do wyszukiwania określonych kształtów. Możesz użyć programu MS PowerPoint, aby zdefiniować tekst alternatywny dla obiektów, które planujesz zmienić w przyszłości.

Po ustawieniu tekstu alternatywnego dowolnego pożądanego kształtu możesz otworzyć tę prezentację przy użyciu Aspose.Slides for Java i przeiterować wszystkie kształty dodane do slajdu. Podczas każdej iteracji możesz sprawdzić tekst alternatywny kształtu, a kształt z pasującym tekstem alternatywnym będzie tym, którego potrzebujesz. Aby lepiej zilustrować tę technikę, stworzyliśmy metodę [findShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) wykonującą to zadanie i zwracającą znaleziony kształt.

```java
// Utwórz klasę Presentation, która reprezentuje plik prezentacji
Presentation pres = new Presentation("FindingShapeInSlide.pptx");
try {

    ISlide slide = pres.getSlides().get_Item(0);
    // Alternatywny tekst kształtu do znalezienia
    IShape shape = findShape(slide, "Shape1");
    if (shape != null)
    {
        System.out.println("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// Implementacja metody służącej do znalezienia kształtu na slajdzie przy użyciu jego tekstu alternatywnego
public static IShape findShape(ISlide slide, String alttext)
{
    // Iterowanie po wszystkich kształtach na slajdzie
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // Jeśli tekst alternatywny kształtu pasuje do wymaganego, wtedy
        // Zwróć kształt
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```

## **Klony kształtu**
Aby sklonować kształt na slajdzie przy użyciu Aspose.Slides for Java:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
1. Uzyskaj referencję do slajdu, podając jego indeks.
1. Uzyskaj dostęp do kolekcji kształtów slajdu źródłowego.
1. Dodaj nowy slajd do prezentacji.
1. Sklonuj kształty z kolekcji kształtów slajdu źródłowego do nowego slajdu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy przykład dodaje grupowy kształt do slajdu.

```java
// Utwórz klasę Presentation
Presentation pres = new Presentation("Source Frame.pptx");
try {
    IShapeCollection sourceShapes = pres.getSlides().get_Item(0).getShapes();
    ILayoutSlide blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destSlide = pres.getSlides().addEmptySlide(blankLayout);
    IShapeCollection destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);

    // Zapisz plik PPTX na dysku
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Usuwanie kształtu**
Aspose.Slides for Java umożliwia programistom usuwanie dowolnego kształtu. Aby usunąć kształt z dowolnego slajdu, postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
1. Uzyskaj dostęp do pierwszego slajdu.
1. Znajdź kształt o określonym AlternativeText.
1. Usuń kształt.
1. Zapisz plik na dysku.

```java
// Utwórz obiekt Presentation
Presentation pres = new Presentation();
try {
    // Pobierz pierwszy slajd
    ISlide sld = pres.getSlides().get_Item(0);

    // Dodaj autokształt typu prostokąt
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String altText = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(0);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            sld.getShapes().remove(ashp);
        }
    }

    // Zapisz prezentację na dysku
    pres.save("RemoveShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ukrywanie kształtu**
Aspose.Slides for Java umożliwia programistom ukrywanie dowolnego kształtu. Aby ukryć kształt na dowolnym slajdzie, postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
1. Uzyskaj dostęp do pierwszego slajdu.
1. Znajdź kształt o określonym AlternativeText.
1. Ukryj kształt.
1. Zapisz plik na dysku.

```java
// Utwórz klasę Presentation reprezentującą plik PPTX
Presentation pres = new Presentation();
try {
    // Pobierz pierwszy slajd
    ISlide sld = pres.getSlides().get_Item(0);

    // Dodaj autokształt typu prostokąt
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String alttext = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(i);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            ashp.setHidden(true);
        }
    }

    // Zapisz prezentację na dysku
    pres.save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zmiana kolejności kształtów**
Aspose.Slides for Java umożliwia programistom zmianę kolejności kształtów. Zmiana kolejności określa, który kształt jest na wierzchu, a który znajduje się z tyłu. Aby zmienić kolejność kształtów na dowolnym slajdzie, postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
1. Uzyskaj dostęp do pierwszego slajdu.
1. Dodaj kształt.
1. Dodaj tekst do ramki tekstowej kształtu.
1. Dodaj kolejny kształt o tych samych współrzędnych.
1. Zmień kolejność kształtów.
1. Zapisz plik na dysku.

```java
Presentation pres = new Presentation("ChangeShapeOrder.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shp3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(FillType.NoFill);
    shp3.addTextFrame(" ");

    IParagraph para = shp3.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");

    shp3 = slide.getShapes().addAutoShape(ShapeType.Triangle, 200, 365, 400, 150);

    slide.getShapes().reorder(2, shp3);

    pres.save("Reshape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Uzyskanie Interop Shape ID**
Aspose.Slides for Java umożliwia programistom uzyskanie unikalnego identyfikatora kształtu w zakresie slajdu, w przeciwieństwie do metody [getUniqueId](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShape#getUniqueId--) zwracającej unikalny identyfikator w zakresie prezentacji. Metoda [getOfficeInteropShapeId](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShape#getOfficeInteropShapeId--) została dodana do interfejsu [IShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShape) oraz klasy [Shape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Shape). Wartość zwracana przez metodę [getOfficeInteropShapeId](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShape#getOfficeInteropShapeId--) odpowiada wartości Id obiektu Microsoft.Office.Interop.PowerPoint.Shape. Poniżej znajduje się przykładowy kod.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Uzyskiwanie unikalnego identyfikatora kształtu w zakresie slajdu
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```

## **Ustawienie tekstu alternatywnego dla kształtu**
Aspose.Slides for Java umożliwia programistom ustawienie AlternateText dowolnego kształtu. Kształty w prezentacji mogą być rozróżniane przy użyciu metody [AlternativeText](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) lub [Shape Name](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShape#setName-java.lang.String-). Metody [setAlternativeText](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) i [getAlternativeText](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShape#getAlternativeText--) mogą być odczytywane i ustawiane zarówno w Aspose.Slides, jak i w Microsoft PowerPoint. Dzięki tej metodzie możesz oznaczyć kształt i wykonywać różne operacje, takie jak usuwanie, ukrywanie lub zmiana kolejności kształtów na slajdzie.

Aby ustawić AlternateText kształtu, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
1. Uzyskaj dostęp do pierwszego slajdu.
1. Dodaj dowolny kształt do slajdu.
1. Wykonaj operacje na nowo dodanym kształcie.
1. Przeglądaj kształty, aby znaleźć interesujący Cię kształt.
1. Ustaw AlternativeText.
1. Zapisz plik na dysku.

```java
// Utwórz klasę Presentation reprezentującą plik PPTX
Presentation pres = new Presentation();
try {
    // Pobierz pierwszy slajd
    ISlide sld = pres.getSlides().get_Item(0);

    // Dodaj autokształt typu prostokąt
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        AutoShape shape = (AutoShape) sld.getShapes().get_Item(i);
        if (shape != null)
        {
            shape.setAlternativeText("User Defined");
        }
    }

    // Zapisz prezentację na dysku
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Dostęp do formatów układu dla kształtu**
Aspose.Slides for Java zapewnia prosty interfejs API do uzyskiwania dostępu do formatów układu dla kształtu. Ten artykuł demonstruje, jak można uzyskać dostęp do formatów układu.

Poniżej znajduje się przykładowy kod.

```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (ILayoutSlide layoutSlide : pres.getLayoutSlides())
    {
        for (IShape shape : layoutSlide.getShapes())
        {
            IFillFormat fillFormats = shape.getFillFormat();
            ILineFormat lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Renderowanie kształtu jako SVG**
Teraz Aspose.Slides for Java wspiera renderowanie kształtu jako SVG. Do klasy [Shape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Shape) i interfejsu [IShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShape) została dodana metoda [writeAsSvg](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (oraz jej przeciążenie). Metoda ta umożliwia zapisanie zawartości kształtu jako pliku SVG. Poniższy fragment kodu pokazuje, jak wyeksportować kształt ze slajdu do pliku SVG.

```java
Presentation pres = new Presentation("TestExportShapeToSvg.pptx");
try {
    FileOutputStream stream = new FileOutputStream("SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) stream.close();
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Wyrównywanie kształtu**
Aspose.Slides umożliwia wyrównywanie kształtów względem marginesów slajdu lub względem siebie nawzajem. W tym celu dodano przeciążoną metodę [SlidesUtil.alignShape()](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-). Wyliczenie [ShapesAlignmentType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ShapesAlignmentType) definiuje dostępne opcje wyrównania.

**Przykład 1**

Poniższy kod źródłowy wyrównuje kształty o indeksach 1, 2 i 4 wzdłuż górnej krawędzi slajdu.

```java
Presentation pres = new Presentation("example.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShape shape1 = slide.getShapes().get_Item(1);
    IShape shape2 = slide.getShapes().get_Item(2);
    IShape shape3 = slide.getShapes().get_Item(4);
    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), new int[]
    {
        slide.getShapes().indexOf(shape1),
        slide.getShapes().indexOf(shape2),
        slide.getShapes().indexOf(shape3)
    });
} finally {
    if (pres != null) pres.dispose();
}
}
```

**Przykład 2**

Poniższy przykład pokazuje, jak wyrównać całą kolekcję kształtów względem najniższego kształtu w kolekcji.

```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```

## **Właściwości odbicia**

W Aspose.Slides klasa [ShapeFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shapeframe/) zapewnia kontrolę nad poziomym i pionowym lustrzanym odbiciem kształtów za pomocą właściwości `flipH` i `flipV`. Obie właściwości są typu `byte` i przyjmują wartości `1` (odbij), `0` (brak odbicia) lub `-1` (domyślne zachowanie). Wartości te są dostępne z [Frame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/#getFrame--) kształtu.

Aby zmodyfikować ustawienia odbicia, tworzona jest nowa instancja [ShapeFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shapeframe/) z aktualną pozycją i rozmiarem kształtu, żądanymi wartościami `flipH` i `flipV` oraz kątem obrotu. Przypisanie tej instancji do [Frame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/#getFrame--) kształtu i zapis prezentacji stosuje transformacje lustrzane i zapisuje je w pliku wyjściowym.

Załóżmy, że mamy plik sample.pptx, w którym pierwszy slajd zawiera pojedynczy kształt z domyślnymi ustawieniami odbicia, jak pokazano poniżej.

![Kształt do odbicia](shape_to_be_flipped.png)

Poniższy przykład kodu pobiera bieżące właściwości odbicia kształtu i odbija go zarówno poziomo, jak i pionowo.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    // Pobierz właściwość odbicia poziomego kształtu.
    byte horizontalFlip = shape.getFrame().getFlipH();
    System.out.println("Horizontal flip: " + horizontalFlip);

    // Pobierz właściwość odbicia pionowego kształtu.
    byte verticalFlip = shape.getFrame().getFlipV();
    System.out.println("Vertical flip: " + verticalFlip);

    float x = shape.getFrame().getX();
    float y = shape.getFrame().getY();
    float width = shape.getFrame().getWidth();
    float height = shape.getFrame().getHeight();
    byte flipH = NullableBool.True; // Odwróć poziomo.
    byte flipV = NullableBool.True; // Odwróć poziomo.
    float rotation = shape.getFrame().getRotation();

    shape.setFrame(new ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Odbity kształt](flipped_shape.png)

## **FAQ**

**Czy mogę łączyć kształty (union/intersect/subtract) na slajdzie tak jak w edytorze desktopowym?**

Nie istnieje wbudowane API operacji boolowskich. Można je przybliżyć, samodzielnie konstruując pożądany kontur – np. obliczając powstałą geometrię (przy użyciu [GeometryPath](https://reference.aspose.com/slides/pl/java/com.aspose.slides/geometrypath/)) i tworząc nowy kształt o tym obrysie, opcjonalnie usuwając oryginalne.

**Jak mogę kontrolować kolejność warstw (z‑order), aby kształt zawsze pozostawał „na wierzchu”?**

Zmieniaj kolejność wstawiania/przenoszenia w kolekcji [shapes](https://reference.aspose.com/slides/pl/java/com.aspose.slides/baseslide/#getShapes--) slajdu. Aby uzyskać przewidywalne wyniki, ustal kolejność warstw po zakończeniu wszystkich pozostałych modyfikacji slajdu.

**Czy mogę „zablokować” kształt, aby użytkownicy nie mogli go edytować w PowerPoint?**

Tak. Ustaw flagi ochrony poziomu kształtu (/slides/pl/java/applying-protection-to-presentation/) (np. blokada zaznaczania, przemieszczania, zmiany rozmiaru, edycji tekstu). W razie potrzeby można zastosować ograniczenia także na poziomie mastera lub układu. Należy pamiętać, że jest to ochrona na poziomie interfejsu, a nie funkcja bezpieczeństwa; dla silniejszej ochrony można połączyć ją z ograniczeniami na poziomie pliku, takimi jak rekomendacje trybu tylko do odczytu lub hasła (/slides/pl/java/password-protected-presentation/).