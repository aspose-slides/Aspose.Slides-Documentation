---
title: Formatowanie kształtów PowerPoint w JavaScript
linktitle: Formatowanie kształtu
type: docs
weight: 20
url: /pl/nodejs-java/shape-formatting/
keywords:
- formatowanie kształtu
- formatowanie linii
- efekt szkicu
- linia szkicowa kształtu
- formatowanie stylu połączeń
- wypełnienie gradientem
- wypełnienie wzorem
- wypełnienie obrazem
- wypełnienie teksturą
- wypełnienie kolorem stałym
- przezroczystość kształtu
- renderowanie kształtu czarno-białe
- renderowanie kształtu w odcieniach szarości
- obracanie kształtu
- efekt 3D bevel
- efekt 3D rotacji
- resetowanie formatowania
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Formatowanie kształtów PowerPoint w JavaScript przy użyciu Aspose.Slides — ustawiaj style wypełnień, linii i efektów dla plików PPT, PPTX i ODP z precyzją i pełną kontrolą."
---
## **Wprowadzenie**

W programie PowerPoint możesz dodawać kształty do slajdów. Ponieważ kształty składają się z linii, możesz je formatować, modyfikując lub stosując efekty do ich konturów. Dodatkowo możesz formatować kształty, określając ustawienia kontrolujące sposób wypełniania ich wnętrz.

![formatowanie-kształtu-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java udostępnia klasy i metody, które umożliwiają formatowanie kształtów przy użyciu tych samych opcji dostępnych w programie PowerPoint.

## **Formatowanie linii**

Używając Aspose.Slides, możesz określić własny styl linii dla kształtu. Poniższe kroki opisują procedurę:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Uzyskaj odwołanie do slajdu według jego indeksu.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) do slajdu.
4. Ustaw [styl linii](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linestyle/) kształtu.
5. Ustaw szerokość linii.
6. Ustaw [styl kreski](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/) linii.
7. Ustaw kolor linii dla kształtu.
8. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod demonstruje, jak sformatować prostokąt `AutoShape`:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instantiate the Presentation class that represents a presentation file.
let presentation = new aspose.slides.Presentation();
try {
    // Get the first slide.
    let slide = presentation.getSlides().get_Item(0);

    // Add an auto shape of the Rectangle type.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // Remove the fill from the rectangle shape.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Apply formatting to the rectangle's lines.
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // Set the color for the rectangle's line.
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Save the PPTX file to disk.
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Sformatowane linie w prezentacji](formatted-lines.png)

## **Zastosuj efekty szkicowe do linii kształtu**

Efekt szkicowy sprawia, że linia kształtu wygląda jak odręczna. Użyj [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) aby uzyskać dostęp do ustawień linii, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/) aby uzyskać dostęp do ustawień szkicu oraz [SketchFormat.setSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/) aby wybrać wartość z wyliczenia [LineSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/).

Poniższy kod JavaScript pokazuje, jak zastosować efekt [LineSketchType.Curved](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/), odczytać wyraźnie przypisaną wartość oraz usunąć efekt przy użyciu [LineSketchType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/):

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

Wartość zwracana przez [SketchFormat.getSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/) reprezentuje ustawienie przypisane bezpośrednio do kształtu. Jeśli formatowanie linii może być dziedziczone z motywu, slajdu głównego lub slajdu układu, użyj [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/), wywołaj `getSketchFormat` na zwróconym obiekcie, a następnie wywołaj jego metodę `getSketchType`. Wartość efektywna odzwierciedla formatowanie faktycznie zastosowane po rozwiązaniu dziedziczenia:

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

* Zaokrąglony
* Kątowy
* Ukośny

Domyślnie, gdy PowerPoint łączy dwie linie pod kątem (np. w narożniku kształtu), używa ustawienia **Zaokrąglony**. Jednakże, jeśli rysujesz kształt o ostrych kątach, możesz preferować opcję **Kątowy**.

![Styl połączenia w prezentacji](join-style-powerpoint.png)

Poniższy kod JavaScript demonstruje, jak trzy prostokąty (jak na powyższym obrazie) zostały utworzone przy użyciu ustawień typu połączenia Kątowy, Ukośny i Zaokrąglony:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Utwórz instancję klasy Presentation reprezentującej plik prezentacji.
let presentation = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd.
    let slide = presentation.getSlides().get_Item(0);

    // Dodaj trzy kształty automatyczne typu Rectangle.
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

    // Zapisz plik PPTX na dysku.
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Wypełnienie gradientem**

W programie PowerPoint wypełnienie gradientem jest opcją formatowania, która pozwala zastosować ciągłe przejście kolorów w kształcie. Na przykład możesz zastosować dwa lub więcej kolorów w taki sposób, że jeden stopniowo przechodzi w drugi.

Kiedy zastosować wypełnienie gradientem do kształtu przy użyciu Aspose.Slides:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Uzyskaj odwołanie do slajdu według jego indeksu.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) do slajdu.
4. Ustaw [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) kształtu na `Gradient`.
5. Dodaj dwa wybrane kolory z określonymi pozycjami, korzystając z metod `add` kolekcji przystanków gradientu udostępnianej przez klasę [GradientFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/).
6. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Utwórz instancję klasy Presentation reprezentującej plik prezentacji.
let presentation = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd.
    let slide = presentation.getSlides().get_Item(0);

    // Dodaj automatyczny kształt typu Ellipse.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // Zastosuj formatowanie gradientu do elipsy.
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

![Elipsa z wypełnieniem gradientowym](gradient-fill.png)

Jeśli gradient wygląda inaczej na wyeksportowanym obrazie niż w programie PowerPoint, zobacz [Wybierz styl renderowania gradientu](/slides/pl/nodejs-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Możesz wybrać styl renderowania bez zmiany wypełnienia gradientem przechowywanego w prezentacji.

## **Wypełnienie wzorem**

W programie PowerPoint wypełnienie wzorem jest opcją formatowania, która pozwala zastosować dwukolorowy wzór — np. kropki, paski, krzyżykowanie lub kratkę — do kształtu. Możesz wybrać własne kolory tła i pierwszego planu wzoru.

Aspose.Slides oferuje ponad 45 wstępnie zdefiniowanych stylów wzorów, które możesz zastosować do kształtów, aby zwiększyć atrakcyjność wizualną prezentacji. Nawet po wybraniu wstępnego wzoru, nadal możesz określić dokładne kolory, które ma używać.

Kiedy zastosować wypełnienie wzorem do kształtu przy użyciu Aspose.Slides:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Uzyskaj odwołanie do slajdu według jego indeksu.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) do slajdu.
4. Ustaw [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) kształtu na `Pattern`.
5. Wybierz styl wzoru spośród dostępnych opcji.
6. Ustaw [Kolor tła](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getBackColor--) wzoru.
7. Ustaw [Kolor pierwszego planu](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getForeColor--) wzoru.
8. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Utwórz instancję klasy Presentation reprezentującej plik prezentacji.
let presentation = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd.
    let slide = presentation.getSlides().get_Item(0);

    // Dodaj automatyczny kształt typu Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Ustaw typ wypełnienia na Pattern.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // Ustaw styl wzoru.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // Ustaw tło i kolory pierwszego planu wzoru.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Zapisz plik PPTX na dysku.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Prostokąt z wypełnieniem wzorem](pattern-fill.png)

## **Wypełnienie obrazem**

W programie PowerPoint wypełnienie obrazem jest opcją formatowania, która pozwala wstawić obraz wewnątrz kształtu — efektywnie używając obrazu jako tła kształtu.

Kiedy zastosować wypełnienie obrazem do kształtu przy użyciu Aspose.Slides:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Uzyskaj odwołanie do slajdu według jego indeksu.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) do slajdu.
4. Ustaw [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) kształtu na `Picture`.
5. Ustaw tryb wypełnienia obrazem na `Tile` (lub inny preferowany tryb).
6. Utwórz obiekt [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) z obrazu, którego chcesz użyć.
7. Przekaż obraz do metody `ISlidesPicture.setImage`.
8. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Załóżmy, że mamy plik "lotus.png" z następującym obrazem:

![Obraz lotosu](lotus.png)

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Utwórz instancję klasy Presentation reprezentującej plik prezentacji.
let presentation = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd.
    let slide = presentation.getSlides().get_Item(0);

    // Dodaj automatyczny kształt typu Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Ustaw typ wypełnienia na Picture.
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

![Kształt z wypełnieniem obrazem](picture-fill.png)

### **Kafelkowanie obrazu jako tekstura**

Jeśli chcesz ustawić obraz kaflowany jako teksturę i dostosować zachowanie kafelkowania, możesz użyć następujących metod klasy [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): Ustawia tryb wypełnienia obrazu — `Tile` lub `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): Określa wyrównanie kafelków w obrębie kształtu.
- [setTileFlip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): Kontroluje, czy kafelek jest odbity poziomo, pionowo, czy w obu kierunkach.
- [setTileOffsetX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): Ustawia poziomy offset kafelka (w punktach) względem położenia kształtu.
- [setTileOffsetY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): Ustawia pionowy offset kafelka (w punktach) względem położenia kształtu.
- [setTileScaleX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): Definiuje poziomą skalę kafelka jako procent.
- [setTileScaleY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): Definiuje pionową skalę kafelka jako procent.

Poniższy przykład kodu pokazuje, jak dodać prostokątny kształt z kafelkowanym wypełnieniem obrazem i skonfigurować opcje kafelkowania:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Utwórz instancję klasy Presentation reprezentującej plik prezentacji.
let presentation = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd.
    let firstSlide = presentation.getSlides().get_Item(0);

    // Dodaj automatyczny kształt prostokątny.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // Ustaw typ wypełnienia kształtu na Picture.
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

![Opcje kafelkowania](tile-options.png)

## **Wypełnienie kolorem stałym**

W programie PowerPoint wypełnienie kolorem stałym jest opcją formatowania, która wypełnia kształt jednorodnym kolorem. Ten jednolity kolor tła jest stosowany bez żadnych gradientów, tekstur ani wzorów.

Aby zastosować wypełnienie kolorem stałym do kształtu przy użyciu Aspose.Slides, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Uzyskaj odwołanie do slajdu według jego indeksu.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) do slajdu.
4. Ustaw [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) kształtu na `Solid`.
5. Przypisz wybrany kolor wypełnienia do kształtu.
6. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Utwórz instancję klasy Presentation reprezentującej plik prezentacji.
let presentation = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd.
    let slide = presentation.getSlides().get_Item(0);

    // Dodaj automatyczny kształt typu Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Ustaw typ wypełnienia na Solid.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // Ustaw kolor wypełnienia.
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Zapisz plik PPTX na dysku.
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Kształt z wypełnieniem kolorem stałym](solid-color-fill.png)

## **Ustaw przezroczystość**

W programie PowerPoint, gdy stosujesz wypełnienie kolorem stałym, gradientem, obrazem lub teksturą do kształtów, możesz również ustawić poziom przezroczystości, aby kontrolować krycie wypełnienia. Wyższa wartość przezroczystości sprawia, że kształt jest bardziej przejrzysty, pozwalając na częściowe zobaczenie tła lub obiektów znajdujących się pod nim.

Aspose.Slides umożliwia ustawienie poziomu przezroczystości poprzez dostosowanie wartości alfa w kolorze używanym do wypełnienia. Oto jak to zrobić:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Uzyskaj odwołanie do slajdu według jego indeksu.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) do slajdu.
4. Ustaw [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) kształtu na `Solid`.
5. Użyj `Color`, aby zdefiniować kolor z przezroczystością (składnik `alpha` kontroluje przezroczystość).
6. Zapisz prezentację.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Utwórz instancję klasy Presentation reprezentującej plik prezentacji.
let presentation = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd.
    let slide = presentation.getSlides().get_Item(0);

    // Dodaj automatyczny prostokąt o stałym wypełnieniu.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Dodaj przezroczysty prostokątny kształt automatyczny nad stałym kształtem.
    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 204));

    // Zapisz plik PPTX na dysku.
    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Przezroczysty kształt](shape-transparency.png)

## **Obracanie kształtów**

Aspose.Slides umożliwia obracanie kształtów w prezentacjach PowerPoint. Może to być przydatne przy pozycjonowaniu elementów wizualnych wymagających określonego wyrównania lub projektu.

Aby obrócić kształt na slajdzie, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Uzyskaj odwołanie do slajdu według jego indeksu.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) do slajdu.
4. Ustaw właściwość rotacji kształtu na żądany kąt.
5. Zapisz prezentację.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Utwórz instancję klasy Presentation reprezentującej plik prezentacji.
let presentation = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd.
    let slide = presentation.getSlides().get_Item(0);

    // Dodaj automatyczny kształt typu Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Obróć kształt o 5 stopni.
    shape.setRotation(5);

    // Zapisz plik PPTX na dysku.
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Obrót kształtu](shape-rotation.png)

## **Dodaj efekty 3D bevel**

Aspose.Slides pozwala zastosować efekty 3D bevel do kształtów, konfigurując ich właściwości [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/).

Aby dodać efekty 3D bevel do kształtu, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Uzyskaj odwołanie do slajdu według jego indeksu.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) do slajdu.
4. Skonfiguruj [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) kształtu, aby określić ustawienia bevel.
5. Zapisz prezentację.

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

![Efekt 3D bevel](3D-bevel-effect.png)

## **Dodaj efekty 3D rotacji**

Aspose.Slides umożliwia zastosowanie efektów 3D rotacji do kształtów, konfigurując ich właściwości [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/).

Aby zastosować 3D rotację do kształtu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Uzyskaj odwołanie do slajdu według jego indeksu.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) do slajdu.
4. Użyj [setCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setCameraType) i [setLightType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lightrig/#setLightType) aby określić rotację 3D.
5. Zapisz prezentację.

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

![Efekt 3D rotacji](3D-rotation-effect.png)

## **Kontrola renderowania czarno-białego dla kształtów**

Metoda [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) określa, jak pojedynczy kształt jest renderowany, gdy prezentacja jest wyświetlana lub przetwarzana w trybie czarno-białym. Nie włącza ona samego trybu czarno-białego i nie zmienia wypełnienia, linii ani innych formatowań kształtu w normalnym trybie kolorowym.

Użyj wartości z wyliczenia [BlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blackwhitemode/), aby wybrać pożądane zachowanie. Na przykład `Automatic` pozwala aplikacji renderującej wybrać konwersję, `Gray` i `LightGray` używają szarego zabarwienia, `BlackWhite` używa wyłącznie czerni i bieli, `Black` i `White` wymuszają jedyny kolor, `Color` zachowuje normalne kolory, a `Hidden` pomija kształt w trybie czarno-białym. `NotDefined` oznacza, że nie przypisano trybu na poziomie kształtu.

Poniższy kod JavaScript tworzy kolorowy kształt i sprawia, że w trybie wyświetlania czarno-białego pojawia się on jako szary:

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

    // Utrzymaj pomarańczowe wypełnienie w trybie kolorowym, ale renderuj kształt w odcieniach szarości w trybie czarno-białym.
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

W normalnym trybie kolorowym prostokąt zachowuje pomarańczowe wypełnienie. W przepływie pracy wyświetlania czarno-białego używa szarego zabarwienia, ponieważ jego tryb jest ustawiony na `Gray`. Dzięki temu możesz zachować slajd w pełnym kolorze, definiując jednocześnie odrębny wygląd dla druku, podglądu lub innych przepływów pracy respektujących ustawienia wyświetlania czarno-białego prezentacji.

## **Resetowanie formatowania**

Poniższy kod JavaScript pokazuje, jak zresetować formatowanie slajdu i przywrócić pozycję, rozmiar oraz formatowanie wszystkich kształtów z placeholderami na [LayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/) do ich domyślnych ustawień:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // Zresetuj każdy kształt na slajdzie, który ma element zastępczy w układzie.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Czy formatowanie kształtów wpływa na ostateczny rozmiar pliku prezentacji?**

Tylko minimalnie. Osadzone obrazy i multimedia zajmują większość miejsca w pliku, podczas gdy parametry kształtów, takie jak kolory, efekty i gradienty, są przechowywane jako metadane i nie dodają praktycznie żadnego dodatkowego rozmiaru.

**Jak mogę wykryć kształty na slajdzie, które mają identyczne formatowanie, aby je pogrupować?**

Porównaj kluczowe właściwości formatowania każdego kształtu — ustawienia wypełnienia, linii i efektów. Jeśli wszystkie odpowiadające sobie wartości są zgodne, traktuj ich style jako identyczne i logicznie grupuj te kształty, co upraszcza późniejsze zarządzanie stylami.

**Czy mogę zapisać zestaw niestandardowych stylów kształtów do osobnego pliku w celu ponownego użycia w innych prezentacjach?**

Tak. Przechowuj przykładowe kształty z pożądanymi stylami w zestawie slajdów szablonu lub w pliku szablonu .POTX. Tworząc nową prezentację, otwórz szablon, sklonuj potrzebne stylowe kształty i ponownie zastosuj ich formatowanie w wybranych miejscach.