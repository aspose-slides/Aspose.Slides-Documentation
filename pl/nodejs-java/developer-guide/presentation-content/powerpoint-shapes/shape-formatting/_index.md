---
title: Formatuj kształty PowerPoint w JavaScript
linktitle: Formatowanie kształtów
type: docs
weight: 20
url: /pl/nodejs-java/shape-formatting/
keywords:
- formatowanie kształtu
- formatowanie linii
- formatowanie stylu połączenia
- wypełnienie gradientem
- wypełnienie wzorem
- wypełnienie obrazem
- wypełnienie teksturą
- wypełnienie jednolitym kolorem
- przezroczystość kształtu
- obracanie kształtu
- efekt 3D z fazką
- efekt 3D rotacji
- resetowanie formatowania
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Formatuj kształty PowerPoint w JavaScript przy użyciu Aspose.Slides—ustaw style wypełnienia, linii i efektów dla plików PPT, PPTX i ODP z precyzją i pełną kontrolą."
---
## **Wprowadzenie**

W programie PowerPoint możesz dodawać kształty do slajdów. Ponieważ kształty składają się z linii, możesz formatować je, modyfikując lub stosując efekty do ich konturów. Dodatkowo możesz formatować kształty, określając ustawienia kontrolujące sposób wypełniania ich wnętrz.

![Formatowanie kształtu w PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java udostępnia klasy i metody, które pozwalają formatować kształty przy użyciu tych samych opcji dostępnych w programie PowerPoint.

## **Formatowanie linii**

Używając Aspose.Slides, możesz określić niestandardowy styl linii dla kształtu. Poniżej opisano kroki procedury:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) do slajdu.
1. Ustaw [styl linii](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/linestyle/) kształtu.
1. Ustaw szerokość linii.
1. Ustaw [styl kreskowania](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/linedashstyle/) linii.
1. Ustaw kolor linii dla kształtu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```js
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
let presentation = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd.
    let slide = presentation.getSlides().get_Item(0);

    // Dodaj auto kształt typu Prostokąt.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // Ustaw kolor wypełnienia dla prostokątnego kształtu.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Zastosuj formatowanie do linii prostokąta.
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // Ustaw kolor linii prostokąta.
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Zapisz plik PPTX na dysk.
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Rezultat:

![Sformatowane linie w prezentacji](formatted-lines.png)

## **Formatowanie stylów połączeń**

Oto trzy dostępne opcje typu połączenia:

* Zaokrąglony
* Stykowy
* Ścięty

Domyślnie, gdy PowerPoint łączy dwie linie pod kątem (np. w rogu kształtu), używa ustawienia **Zaokrąglony**. Jednak przy rysowaniu kształtu o ostrych kątach możesz preferować opcję **Stykowy**.

![Styl połączenia w prezentacji](join-style-powerpoint.png)

```js
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
let presentation = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd.
    let slide = presentation.getSlides().get_Item(0);

    // Dodaj trzy auto kształty typu Rectangle.
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

    // Ustaw kolor linii dla każdego prostokąta.
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

    // Zapisz plik PPTX na dysk.
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Wypełnienie gradientem**

W programie PowerPoint wypełnienie gradientem to opcja formatowania, która pozwala zastosować ciągłe przejście kolorów w kształcie. Na przykład możesz zastosować dwa lub więcej kolorów, tak aby jeden stopniowo przechodził w drugi.

Aby zastosować wypełnienie gradientem do kształtu przy użyciu Aspose.Slides:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/filltype/) kształtu na `Gradient`.
1. Dodaj dwa wybrane kolory wraz z określonymi pozycjami, używając metod `add` kolekcji przystanków gradientu udostępnianej przez klasę [GradientFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/gradientformat/).
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```js
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
let presentation = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd.
    let slide = presentation.getSlides().get_Item(0);

    // Dodaj auto kształt typu Ellipse.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // Zastosuj formatowanie gradientowe do elipsy.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // Ustaw kierunek gradientu.
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // Dodaj dwa przystanki gradientu.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // Zapisz plik PPTX na dysk.
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Rezultat:

![Elipsa z wypełnieniem gradientowym](gradient-fill.png)

## **Wypełnienie wzorem**

W programie PowerPoint wypełnienie wzorem to opcja formatowania, która pozwala zastosować dwukolorowy wzór — na przykład kropki, paski, krzyżykowanie lub szachownicę — do kształtu. Możesz wybrać własne kolory dla pierwszego planu i tła wzoru.

Aspose.Slides udostępnia ponad 45 wstępnie zdefiniowanych stylów wzorów, które możesz zastosować do kształtów, aby zwiększyć atrakcyjność wizualną prezentacji. Nawet po wybraniu gotowego wzoru możesz określić dokładne kolory, które ma on używać.

Aby zastosować wypełnienie wzorem do kształtu przy użyciu Aspose.Slides:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/filltype/) kształtu na `Pattern`.
1. Wybierz styl wzoru spośród predefiniowanych opcji.
1. Ustaw [Background Color](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/patternformat/#getBackColor--) wzoru.
1. Ustaw [Foreground Color](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/patternformat/#getForeColor--) wzoru.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```js
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
let presentation = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd.
    let slide = presentation.getSlides().get_Item(0);

    // Dodaj auto kształt typu Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Ustaw typ wypełnienia na Pattern.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // Ustaw styl wzoru.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // Ustaw kolory tła i pierwszego planu wzoru.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Zapisz plik PPTX na dysk.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Rezultat:

![Prostokąt z wypełnieniem wzorem](pattern-fill.png)

## **Wypełnienie obrazem**

W programie PowerPoint wypełnienie obrazem to opcja formatowania, która pozwala wstawić obraz wewnątrz kształtu — efektywnie używając obrazu jako tła kształtu.

Jak używać Aspose.Slides do zastosowania wypełnienia obrazem w kształcie:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/filltype/) kształtu na `Picture`.
1. Ustaw tryb wypełnienia obrazu na `Tile` (lub inny preferowany tryb).
1. Utwórz obiekt [PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ppimage/) z obrazu, którego chcesz użyć.
1. Przekaż obraz do metody `ISlidesPicture.setImage`.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

![Obraz lotosu](lotus.png)

```js
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
let presentation = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd.
    let slide = presentation.getSlides().get_Item(0);

    // Dodaj auto kształt typu Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Ustaw typ wypełnienia na Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Ustaw tryb wypełnienia obrazem.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // Załaduj obraz i dodaj go do zasobów prezentacji.
    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture = presentation.getImages().addImage(image);
    image.dispose();

    // Ustaw obraz.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Zapisz plik PPTX na dysk.
    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Rezultat:

![Kształt z wypełnieniem obrazem](picture-fill.png)

### **Użycie obrazu kafelkowego jako tekstury**

Jeśli chcesz ustawić obraz kafelkowy jako teksturę i dostosować zachowanie kafelkowania, możesz użyć następujących metod klasy [PictureFillFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): Ustawia tryb wypełnienia obrazu — `Tile` lub `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): Określa wyrównanie kafelków w kształcie.
- [setTileFlip](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): Kontroluje, czy kafelek jest odwrócony poziomo, pionowo czy obu sposobów.
- [setTileOffsetX](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): Ustawia poziome przesunięcie kafelka (w punktach) od początku kształtu.
- [setTileOffsetY](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): Ustawia pionowe przesunięcie kafelka (w punktach) od początku kształtu.
- [setTileScaleX](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): Definiuje poziomą skalę kafelka jako procent.
- [setTileScaleY](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): Definiuje pionową skalę kafelka jako procent.

```js
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
let presentation = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd.
    let firstSlide = presentation.getSlides().get_Item(0);

    // Dodaj auto kształt typu Rectangle.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // Ustaw typ wypełnienia kształtu na Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Załaduj obraz i dodaj go do zasobów prezentacji.
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

    // Zapisz plik PPTX na dysk.
    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Rezultat:

![Opcje kafelkowania](tile-options.png)

## **Wypełnienie jednolitym kolorem**

W programie PowerPoint wypełnienie jednolitym kolorem to opcja formatowania, która wypełnia kształt jednym, jednolitym kolorem. To proste tło jest stosowane bez gradientów, tekstur ani wzorów.

Aby zastosować wypełnienie jednolitym kolorem do kształtu przy użyciu Aspose.Slides, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/filltype/) kształtu na `Solid`.
1. Przypisz preferowany kolor wypełnienia kształtowi.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```js
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
let presentation = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd.
    let slide = presentation.getSlides().get_Item(0);

    // Dodaj auto kształt typu Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Ustaw typ wypełnienia na Solid.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // Ustaw kolor wypełnienia.
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Zapisz plik PPTX na dysk.
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Rezultat:

![Kształt z jednolitym wypełnieniem koloru](solid-color-fill.png)

## **Ustawienie przezroczystości**

W programie PowerPoint, gdy stosujesz wypełnienie jednolitym kolorem, gradientem, obrazem lub teksturą do kształtów, możesz także ustawić poziom przezroczystości, aby kontrolować krycie wypełnienia. Wyższa wartość przezroczystości sprawia, że kształt jest bardziej przezroczysty, co pozwala częściowo widzieć tło lub obiekty pod nim.

Aspose.Slides umożliwia ustawienie poziomu przezroczystości poprzez dostosowanie wartości alfa w kolorze używanym do wypełnienia. Oto jak to zrobić:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/filltype/) kształtu na `Solid`.
1. Użyj `Color`, aby określić kolor z przezroczystością (składnik `alpha` kontroluje przezroczystość).
1. Zapisz prezentację.

```js
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
let presentation = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd.
    let slide = presentation.getSlides().get_Item(0);

    // Dodaj prostokątny auto kształt wypełniony jednolitym kolorem.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Dodaj przezroczysty prostokątny auto kształt nad solidnym kształtem.
    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 204));

    // Zapisz plik PPTX na dysk.
    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Rezultat:

![Kształt z przezroczystością](shape-transparency.png)

## **Obracanie kształtów**

Aspose.Slides umożliwia obracanie kształtów w prezentacjach PowerPoint. Może to być przydatne podczas pozycjonowania elementów wizualnych o określonym wyrównaniu lub wymaganiach projektowych.

Aby obrócić kształt na slajdzie, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) do slajdu.
1. Ustaw właściwość rotacji kształtu na żądany kąt.
1. Zapisz prezentację.

```js
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
let presentation = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd.
    let slide = presentation.getSlides().get_Item(0);

    // Dodaj auto kształt typu Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Obróć kształt o 5 stopni.
    shape.setRotation(5);

    // Zapisz plik PPTX na dysk.
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Rezultat:

![Obrót kształtu](shape-rotation.png)

## **Dodawanie efektów 3D z fazką**

Aspose.Slides umożliwia zastosowanie efektów 3D z fazką do kształtów poprzez skonfigurowanie ich właściwości [ThreeDFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/threedformat/).

Aby dodać efekty 3D z fazką do kształtu, wykonaj następujące kroki:

1. Zainicjuj klasę [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) do slajdu.
1. Skonfiguruj [ThreeDFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/threedformat/) kształtu, aby określić ustawienia fazki.
1. Zapisz prezentację.

```js
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

    // Ustaw właściwości ThreeDFormat kształtu.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    // Zapisz prezentację jako plik PPTX.
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Rezultat:

![Efekt 3D z fazką](3D-bevel-effect.png)

## **Dodawanie efektów 3D rotacji**

Aspose.Slides umożliwia zastosowanie efektów 3D rotacji do kształtów poprzez skonfigurowanie ich właściwości [ThreeDFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/threedformat/).

Aby zastosować 3D rotację do kształtu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) do slajdu.
1. Użyj [setCameraType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/camera/#setCameraType) i [setLightType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/lightrig/#setLightType), aby określić rotację 3D.
1. Zapisz prezentację.

```js
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

Rezultat:

![Efekt 3D rotacji](3D-rotation-effect.png)

## **Resetowanie formatowania**

Poniższy kod Java pokazuje, jak zresetować formatowanie slajdu i przywrócić pozycję, rozmiar oraz formatowanie wszystkich kształtów z symbolami na [LayoutSlide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutslide/) do ich ustawień domyślnych:

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // Zresetuj każdy kształt na slajdzie, który ma symbol zastępczy w układzie.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Czy formatowanie kształtów wpływa na ostateczny rozmiar pliku prezentacji?**

Jedynie nieznacznie. Osadzone obrazy i multimedia zajmują większość miejsca w pliku, podczas gdy parametry kształtów, takie jak kolory, efekty i gradienty, są przechowywane jako metadane i praktycznie nie zwiększają rozmiaru.

**Jak mogę wykryć kształty na slajdzie, które mają identyczne formatowanie, aby je pogrupować?**

Porównaj kluczowe właściwości formatowania każdego kształtu — ustawienia wypełnienia, linii i efektów. Jeśli wszystkie odpowiadające sobie wartości są takie same, traktuj ich style jako identyczne i logicznie grupuj te kształty, co ułatwia późniejsze zarządzanie stylami.

**Czy mogę zapisać zestaw własnych stylów kształtów w osobnym pliku i ponownie wykorzystać go w innych prezentacjach?**

Tak. Przechowuj przykładowe kształty z pożądanymi stylami w szablonie slajdów lub pliku szablonu .POTX. Podczas tworzenia nowej prezentacji otwórz szablon, sklonuj potrzebne sformatowane kształty i ponownie zastosuj ich formatowanie w wybranych miejscach.