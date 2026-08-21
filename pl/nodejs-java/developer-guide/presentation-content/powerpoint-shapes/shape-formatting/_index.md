---
title: Formatowanie kształtów PowerPoint w JavaScript
linktitle: Formatowanie kształtów
type: docs
weight: 20
url: /pl/nodejs-java/shape-formatting/
keywords:
- formatowanie kształtu
- formatowanie linii
- efekt szkicu
- linia szkicu kształtu
- formatowanie stylu połączenia
- wypełnienie gradientowe
- wypełnienie wzorem
- wypełnienie obrazem
- wypełnienie teksturą
- wypełnienie jednokolorowe
- przezroczystość kształtu
- renderowanie kształtu w czerni i bieli
- renderowanie kształtu w odcieniach szarości
- obrót kształtu
- efekt fazowania 3D
- efekt obrotu 3D
- resetowanie formatowania
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Formatuj kształty PowerPoint w JavaScript przy użyciu Aspose.Slides — ustaw style wypełnienia, linii i efektów dla plików PPT, PPTX i ODP z precyzją i pełną kontrolą."
---
## **Wprowadzenie**

W programie PowerPoint możesz dodawać kształty do slajdów. Ponieważ kształty składają się z linii, możesz formatować je, modyfikując lub stosując efekty do ich konturów. Dodatkowo możesz formatować kształty, określając ustawienia kontrolujące sposób wypełniania ich wnętrz.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java udostępnia klasy i metody, które umożliwiają formatowanie kształtów przy użyciu tych samych opcji dostępnych w programie PowerPoint.

## **Formatowanie linii**

Za pomocą Aspose.Slides możesz określić niestandardowy styl linii dla kształtu. Poniższe kroki przedstawiają procedurę:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu na podstawie jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) do slajdu.
1. Ustaw [styl linii](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/linestyle/) kształtu.
1. Ustaw szerokość linii.
1. Ustaw [styl kreski](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/linedashstyle/) linii.
1. Ustaw kolor linii dla kształtu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod demonstruje, jak sformatować prostokąt `AutoShape`:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
let presentation = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd.
    let slide = presentation.getSlides().get_Item(0);

    // Dodaj automatyczny kształt typu Prostokąt.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // Usuń wypełnienie z prostokątnego kształtu.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Zastosuj formatowanie do linii prostokąta.
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // Ustaw kolor linii prostokąta.
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Zapisz plik PPTX na dysku.
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Sformatowane linie w prezentacji](formatted-lines.png)

## **Zastosowanie efektów szkicu do linii kształtu**

Efekt szkicu sprawia, że linia kształtu wygląda jak narysowana ręcznie. Użyj [Shape.getLineFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/) aby uzyskać dostęp do ustawień linii, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/lineformat/) aby uzyskać dostęp do ustawień szkicu oraz [SketchFormat.setSketchType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sketchformat/) aby wybrać wartość z wyliczenia [LineSketchType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/linesketchtype/).

Poniższy kod JavaScript pokazuje, jak zastosować efekt [LineSketchType.Curved](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/linesketchtype/) , odczytać wyraźnie przypisaną wartość oraz usunąć efekt przy użyciu [LineSketchType.None](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/linesketchtype/):

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // Uzyskaj dostęp do formatu linii kształtu i jego formatu szkicu.
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // Zastosuj efekt szkicu.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // Odczytaj efekt szkicu przypisany bezpośrednio do kształtu.
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // Usuń efekt szkicu.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Wartość zwrócona przez [SketchFormat.getSketchType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sketchformat/) reprezentuje ustawienie przypisane bezpośrednio do kształtu. Jeśli formatowanie linii może być dziedziczone z motywu, slajdu głównego lub slajdu układu, użyj [LineFormat.getEffective](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/lineformat/), wywołaj `getSketchFormat` na zwróconym obiekcie, a następnie metodę `getSketchType`. Wartość efektywna odzwierciedla formatowanie, które jest faktycznie zastosowane po rozwiązaniu dziedziczenia:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    let lineFormat = shape.getLineFormat();

    let explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    let effectiveLineFormat = lineFormat.getEffective();
    let effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    console.log("Explicit sketch type: " + explicitSketchType);
    console.log("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Formatowanie stylów połączeń**

Oto trzy dostępne opcje typu połączenia:

* Round
* Miter
* Bevel

Domyślnie, gdy PowerPoint łączy dwie linie pod kątem (na przykład w rogu kształtu), używa ustawienia **Round**. Jednak przy rysowaniu kształtu o ostrych kątach możesz woleć opcję **Miter**.

![Styl połączenia w prezentacji](join-style-powerpoint.png)

Poniższy kod JavaScript demonstruje, jak trzy prostokąty (jak na powyższym obrazie) zostały utworzone przy użyciu ustawień typu połączenia Miter, Bevel i Round:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
let presentation = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd.
    let slide = presentation.getSlides().get_Item(0);

    // Dodaj trzy automatyczne kształty typu Prostokąt.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // Ustaw kolor wypełnienia dla każdego prostokątnego kształtu.
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    // Ustaw szerokość linii.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Ustaw kolor linii każdego prostokąta.
    shape1.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape3.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Ustaw styl połączenia.
    shape1.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    shape2.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    shape3.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    // Dodaj tekst do każdego prostokąta.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Zapisz plik PPTX na dysku.
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Wypełnienie gradientowe**

W programie PowerPoint wypełnienie gradientowe jest opcją formatowania, która pozwala zastosować ciągłe przejście kolorów w kształcie. Na przykład możesz zastosować dwa lub więcej kolorów w sposób, w którym jeden stopniowo przechodzi w drugi.

Oto, jak zastosować wypełnienie gradientowe do kształtu przy użyciu Aspose.Slides:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu na podstawie jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/filltype/) kształtu na `Gradient`.
1. Dodaj dwa wybrane kolory z określonymi pozycjami, korzystając z metod `add` kolekcji przystanków gradientu udostępnianej przez klasę [GradientFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/gradientformat/).
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
let presentation = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd.
    let slide = presentation.getSlides().get_Item(0);

    // Dodaj automatyczny kształt typu Elipsa.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // Zastosuj formatowanie gradientowe do elipsy.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // Ustaw kierunek gradientu.
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // Dodaj dwa przystanki gradientu.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // Zapisz plik PPTX na dysku.
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Elipsa z wypełnieniem gradientowym:

![Elipsa z wypełnieniem gradientowym](gradient-fill.png)

## **Wypełnienie wzorem**

W programie PowerPoint wypełnienie wzorem jest opcją formatowania, która pozwala zastosować dwukolorowy wzór — np. kropki, paski, krzyżowe kreskowanie lub szachownicę — do kształtu. Możesz wybrać własne kolory dla pierwszego planu i tła wzoru.

Aspose.Slides udostępnia ponad 45 wstępnie zdefiniowanych stylów wzorów, które możesz zastosować do kształtów, aby zwiększyć atrakcyjność wizualną prezentacji. Nawet po wybraniu gotowego wzoru możesz określić dokładne kolory, które ma on używać.

Oto, jak zastosować wypełnienie wzorem do kształtu przy użyciu Aspose.Slides:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu na podstawie jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/filltype/) kształtu na `Pattern`.
1. Wybierz styl wzoru spośród dostępnych opcji.
1. Ustaw [Background Color](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/patternformat/#getBackColor--) wzoru.
1. Ustaw [Foreground Color](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/patternformat/#getForeColor--) wzoru.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
let presentation = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd.
    let slide = presentation.getSlides().get_Item(0);

    // Dodaj automatyczny kształt typu Prostokąt.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Ustaw typ wypełnienia na Wzór.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // Ustaw styl wzoru.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // Ustaw kolory tła i pierwszego planu wzoru.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Zapisz plik PPTX na dysku.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Prostokąt z wypełnieniem wzorem:

![Prostokąt z wypełnieniem wzorem](pattern-fill.png)

## **Wypełnienie obrazem**

W programie PowerPoint wypełnienie obrazem jest opcją formatowania, która umożliwia wstawienie obrazu wewnątrz kształtu — de facto używając obrazu jako tła kształtu.

Oto, jak używać Aspose.Slides do zastosowania wypełnienia obrazem w kształcie:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu na podstawie jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/filltype/) kształtu na `Picture`.
1. Ustaw tryb wypełnienia obrazem na `Tile` (lub inny preferowany tryb).
1. Utwórz obiekt [PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ppimage/) z obrazu, którego chcesz użyć.
1. Przekaż obraz do metody `ISlidesPicture.setImage`.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Załóżmy, że mamy plik "lotus.png" z następującym obrazem:

![Obraz lotosu](lotus.png)

Poniższy kod JavaScript pokazuje, jak dodać kształt wypełniony obrazem:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
let presentation = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd.
    let slide = presentation.getSlides().get_Item(0);

    // Dodaj automatyczny kształt typu Prostokąt.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Ustaw typ wypełnienia na Obraz.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Ustaw tryb wypełnienia obrazem.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // Wczytaj obraz i dodaj go do zasobów prezentacji.
    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture = presentation.getImages().addImage(image);
    image.dispose();

    // Ustaw obraz.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Zapisz plik PPTX na dysku.
    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kształt z wypełnieniem obrazem:

![Kształt z wypełnieniem obrazem](picture-fill.png)

### **Obraz w trybie Kafelkowanie jako tekstura**

Jeśli chcesz ustawić obraz w trybie kafelkowany jako teksturę i dostosować zachowanie kafelkowania, możesz użyć następujących metod klasy [PictureFillFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): Ustawia tryb wypełnienia obrazem — `Tile` lub `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): Określa wyrównanie kafelków wewnątrz kształtu.
- [setTileFlip](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): Kontroluje, czy kafelek jest odbijany w poziomie, w pionie lub w obu kierunkach.
- [setTileOffsetX](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): Ustawia poziomy offset kafelka (w punktach) względem początku kształtu.
- [setTileOffsetY](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): Ustawia pionowy offset kafelka (w punktach) względem początku kształtu.
- [setTileScaleX](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): Definiuje poziomą skalę kafelka jako procent.
- [setTileScaleY](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): Definiuje pionową skalę kafelka jako procent.

Poniższy przykład kodu pokazuje, jak dodać prostokąt z wypełnieniem obrazu w trybie kafelkowanie i skonfigurować opcje kafelkowania:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
let presentation = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd.
    let firstSlide = presentation.getSlides().get_Item(0);

    // Dodaj automatyczny kształt typu Prostokąt.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // Ustaw typ wypełnienia kształtu na Obraz.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Wczytaj obraz i dodaj go do zasobów prezentacji.
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Przypisz obraz do kształtu.
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Skonfiguruj tryb wypełnienia obrazem oraz właściwości kafelkowania.
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // Zapisz plik PPTX na dysku.
    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Opcje kafelkowania:

![Opcje kafelkowania](tile-options.png)

## **Jednokolorowe wypełnienie**

W programie PowerPoint jednokolorowe wypełnienie jest opcją formatowania, która wypełnia kształt jednym, jednolitym kolorem. Ten prosty kolor tła jest stosowany bez żadnych gradientów, tekstur ani wzorów.

Aby zastosować jednokolorowe wypełnienie do kształtu przy użyciu Aspose.Slides, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu na podstawie jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/filltype/) kształtu na `Solid`.
1. Przypisz wybrany kolor wypełnienia do kształtu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
let presentation = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd.
    let slide = presentation.getSlides().get_Item(0);

    // Dodaj automatyczny kształt typu Prostokąt.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Ustaw typ wypełnienia na Jednolity.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // Ustaw kolor wypełnienia.
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Zapisz plik PPTX na dysku.
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kształt z jednokolorowym wypełnieniem:

![Kształt z jednokolorowym wypełnieniem](solid-color-fill.png)

## **Ustawienie przezroczystości**

W programie PowerPoint, gdy stosujesz jednolity kolor, gradient, obraz lub wypełnienie teksturą na kształtach, możesz również ustawić poziom przezroczystości, aby kontrolować krycie wypełnienia. Wyższa wartość przezroczystości powoduje, że kształt jest bardziej przejrzysty, co pozwala częściowo widzieć tło lub znajdujące się pod nim obiekty.

Aspose.Slides umożliwia ustawienie poziomu przezroczystości poprzez dostosowanie wartości alfa w kolorze używanym do wypełnienia. Oto jak to zrobić:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu na podstawie jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/filltype/) na `Solid`.
1. Użyj `Color`, aby zdefiniować kolor z przezroczystością (składnik `alpha` steruje przezroczystością).
1. Zapisz prezentację.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
let presentation = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd.
    let slide = presentation.getSlides().get_Item(0);

    // Dodaj prostokątny automatyczny kształt z jednolitym wypełnieniem.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Dodaj przezroczysty prostokątny automatyczny kształt nad jednolitym kształtem.
    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 204));

    // Zapisz plik PPTX na dysku.
    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Przezroczysty kształt:

![Przezroczysty kształt](shape-transparency.png)

## **Obracanie kształtów**

Aspose.Slides pozwala obracać kształty w prezentacjach PowerPoint. Może to być przydatne przy pozycjonowaniu elementów wizualnych wymagających określonego wyrównania lub projektu.

Aby obrócić kształt na slajdzie, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu na podstawie jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) do slajdu.
1. Ustaw właściwość obrotu kształtu na żądany kąt.
1. Zapisz prezentację.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
let presentation = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd.
    let slide = presentation.getSlides().get_Item(0);

    // Dodaj automatyczny kształt typu Prostokąt.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Obróć kształt o 5 stopni.
    shape.setRotation(5);

    // Zapisz plik PPTX na dysku.
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Obrót kształtu:

![Obrót kształtu](shape-rotation.png)

## **Dodawanie efektów 3D Bevel**

Aspose.Slides pozwala zastosować efekty 3D Bevel do kształtów, konfigurując ich właściwości [ThreeDFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/threedformat/).

Aby dodać efekty 3D Bevel do kształtu, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu na podstawie jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) do slajdu.
1. Skonfiguruj [ThreeDFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/threedformat/) kształtu, aby określić ustawienia fazowania.
1. Zapisz prezentację.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Utwórz instancję klasy Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Dodaj kształt do slajdu.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getLineFormat().setWidth(2.0);

    // Set the shape's ThreeDFormat properties.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    // Save the presentation as a PPTX file.
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Efekt 3D Bevel:

![Efekt 3D Bevel](3D-bevel-effect.png)

## **Dodawanie efektów 3D obrotu**

Aspose.Slides pozwala zastosować efekty 3D obrotu do kształtów, konfigurując ich właściwości [ThreeDFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/threedformat/).

Aby zastosować obrót 3D do kształtu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu na podstawie jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) do slajdu.
1. Użyj [setCameraType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/camera/#setCameraType) oraz [setLightType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/lightrig/#setLightType), aby określić obrót 3D.
1. Zapisz prezentację.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Utwórz instancję klasy Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    // Zapisz prezentację jako plik PPTX.
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Efekt 3D obrotu:

![Efekt 3D obrotu](3D-rotation-effect.png)

## **Kontrola renderowania czarno-białego dla kształtów**

Metoda [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) określa, jak pojedynczy kształt jest renderowany, gdy prezentacja jest wyświetlana lub przetwarzana w trybie czarno-białym. Nie włącza ona samego trybu czarno-białego i nie zmienia wypełnienia, linii ani innych formatowań w normalnym trybie kolorów.

Użyj wartości z wyliczenia [BlackWhiteMode](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/blackwhitemode/), aby wybrać pożądane zachowanie. Na przykład `Automatic` pozwala aplikacji renderującej wybrać konwersję, `Gray` i `LightGray` używają odcieni szarości, `BlackWhite` używa wyłącznie czerni i bieli, `Black` i `White` wymuszają jednolity kolor, `Color` zachowuje normalne kolory, a `Hidden` pomija kształt w trybie czarno-białym. `NotDefined` oznacza, że nie przypisano trybu na poziomie kształtu.

Poniższy kod JavaScript tworzy kolorowy kształt i sprawia, że w trybie czarno-białym wyświetla się jako szary:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    // Zachowaj pomarańczowe wypełnienie w trybie kolorowym, ale renderuj kształt w odcieniach szarości w trybie czarno-białym.
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

W normalnym trybie kolorów prostokąt zachowuje pomarańczowe wypełnienie. W trybie wyświetlania czarno‑białego używa szarego koloru, ponieważ jego tryb jest ustawiony na `Gray`. Dzięki temu możesz zachować slajd w pełnym kolorze, jednocześnie definiując odrębny wygląd dla drukowania, podglądu lub innych procesów, które respektują ustawienia czarno‑białego wyświetlania prezentacji.

## **Resetowanie formatowania**

Poniższy kod JavaScript pokazuje, jak zresetować formatowanie slajdu i przywrócić pozycję, rozmiar oraz formatowanie wszystkich kształtów z symbolami zastępczymi na [LayoutSlide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutslide/) do ich domyślnych ustawień:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // Zresetuj każdy kształt na slajdzie, który ma placeholder w układzie.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Czy formatowanie kształtów wpływa na rozmiar ostatecznego pliku prezentacji?**

Tylko nieznacznie. Osadzone obrazy i multimedia zajmują większość przestrzeni pliku, podczas gdy parametry kształtów, takie jak kolory, efekty i gradienty, są przechowywane jako metadane i praktycznie nie zwiększają rozmiaru.

**Jak mogę wykryć kształty na slajdzie, które mają identyczne formatowanie, aby je pogrupować?**

Porównaj kluczowe właściwości formatowania każdego kształtu — ustawienia wypełnienia, linii i efektów. Jeśli wszystkie odpowiadające wartości są takie same, traktuj ich style jako identyczne i logicznie grupuj te kształty, co upraszcza późniejsze zarządzanie stylami.

**Czy mogę zapisać zestaw niestandardowych stylów kształtów w osobnym pliku, aby ponownie używać ich w innych prezentacjach?**

Tak. Przechowuj przykładowe kształty z pożądanymi stylami w szablonie slajdów lub pliku szablonu .POTX. Tworząc nową prezentację, otwórz szablon, sklonuj potrzebne stylizowane kształty i ponownie zastosuj ich formatowanie w odpowiednich miejscach.