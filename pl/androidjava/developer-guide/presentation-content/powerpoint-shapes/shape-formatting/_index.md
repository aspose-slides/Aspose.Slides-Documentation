---
title: Formatowanie kształtów PowerPoint na Androidzie
linktitle: Formatowanie kształtów
type: docs
weight: 20
url: /pl/androidjava/shape-formatting/
keywords:
- formatowanie kształtu
- formatowanie linii
- efekt szkicu
- linia szkicu kształtu
- formatowanie stylu łączenia
- wypełnienie gradientem
- wypełnienie wzorem
- wypełnienie obrazem
- wypełnienie teksturą
- wypełnienie kolorem stałym
- przezroczystość kształtu
- obracanie kształtu
- efekt 3D fazowania
- efekt obracania 3D
- resetowanie formatowania
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: Dowiedz się, jak formatować kształty PowerPoint na Androidzie przy użyciu Aspose.Slides — ustaw style wypełnienia, linii i efektów dla plików PPT, PPTX i ODP z precyzją i pełną kontrolą.
---
## **Wprowadzenie**

W programie PowerPoint można dodawać kształty do slajdów. Ponieważ kształty składają się z linii, można je formatować, modyfikując lub stosując efekty na ich konturach. Dodatkowo można formatować kształty, określając ustawienia kontrolujące, jak wypełniane są ich wnętrza.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Android via Java udostępnia interfejsy i metody umożliwiające formatowanie kształtów przy użyciu tych samych opcji dostępnych w programie PowerPoint.

## **Formatowanie linii**

Za pomocą Aspose.Slides można określić niestandardowy styl linii dla kształtu. Poniższe kroki opisują procedurę:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu za pomocą jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) do slajdu.
1. Ustaw [line style](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/linestyle/) kształtu.
1. Ustaw szerokość linii.
1. Ustaw [dash style](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/linedashstyle/) linii.
1. Ustaw kolor linii dla kształtu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod demonstruje, jak sformatować prostokąt `AutoShape`:

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj auto-kształt typu Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Ustaw kolor wypełnienia dla kształtu prostokątnego.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Zastosuj formatowanie linii prostokąta.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Ustaw kolor linii prostokąta.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Zapisz plik PPTX na dysku.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![The formatted lines in the presentation](formatted-lines.png)

## **Zastosuj efekty szkicu do linii kształtu**

Efekt szkicu sprawia, że linia kształtu wygląda na odręcznie narysowaną. Użyj [IShape.getLineFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/) aby uzyskać dostęp do ustawień linii, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilineformat/) aby uzyskać dostęp do ustawień szkicu oraz [ISketchFormat.setSketchType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isketchformat/) aby wybrać wartość z wyliczenia [LineSketchType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/linesketchtype/).

Poniższy kod Java pokazuje, jak zastosować efekt [LineSketchType.Curved](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/linesketchtype/), odczytać jawnie przypisaną wartość oraz usunąć efekt przy użyciu [LineSketchType.None](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/linesketchtype/):

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Uzyskaj dostęp do formatu linii kształtu i jego formatu szkicu.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Zastosuj efekt szkicu.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Odczytaj efekt szkicu przypisany bezpośrednio do kształtu.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Usuń efekt szkicu.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Wartość zwracana przez [ISketchFormat.getSketchType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isketchformat/) reprezentuje ustawienie przypisane bezpośrednio do kształtu. Jeśli formatowanie linii może być dziedziczone z motywu, slajdu nadrzędnego lub slajdu układu, użyj [ILineFormat.getEffective](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilineformat/), uzyskaj dostęp do [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilineformateffectivedata/), i odczytaj [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isketchformateffectivedata/). Wartość efektywna odzwierciedla formatowanie faktycznie zastosowane po rozwiązaniu dziedziczenia:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    ILineFormat lineFormat = shape.getLineFormat();

    int explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    ILineFormatEffectiveData effectiveLineFormat = lineFormat.getEffective();
    int effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    System.out.println("Explicit sketch type: " + explicitSketchType);
    System.out.println("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Formatowanie stylów łączenia**

Oto trzy dostępne opcje typu łączenia:

* Round
* Miter
* Bevel

Domyślnie, gdy PowerPoint łączy dwie linie pod kątem (np. w narożniku kształtu), używa ustawienia **Round**. Jednak przy rysowaniu kształtu o ostrych kątach, można woleć opcję **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

Poniższy kod Java demonstruje, jak trzy prostokąty (jak na powyższym obrazku) zostały utworzone przy użyciu ustawień typu łączenia Miter, Bevel i Round:

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj trzy auto‑kształty typu Rectangle.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Ustaw kolor wypełnienia dla każdego prostokątnego kształtu.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Ustaw szerokość linii.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Ustaw kolor linii dla każdego prostokąta.
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Ustaw styl łączenia.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Dodaj tekst do każdego prostokąta.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Zapisz plik PPTX na dysku.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Wypełnienie gradientem**

W programie PowerPoint wypełnienie gradientem jest opcją formatowania, która umożliwia zastosowanie płynnego przejścia kolorów do kształtu. Na przykład można zastosować dwa lub więcej kolorów w taki sposób, że jeden stopniowo przechodzi w drugi.

Jak zastosować wypełnienie gradientem do kształtu przy użyciu Aspose.Slides:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu za pomocą jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) do slajdu.
1. Ustaw właściwość kształtu [FillType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/filltype/) na `Gradient`.
1. Dodaj dwa wybrane kolory z określonymi pozycjami, używając metod `add` kolekcji przystanków gradientu udostępnianej przez interfejs [IGradientFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/igradientformat/).
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod Java demonstruje, jak zastosować efekt wypełnienia gradientem do elipsy:

```java
    // Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
    Presentation presentation = new Presentation();
    try {
        // Pobierz pierwszy slajd.
        ISlide slide = presentation.getSlides().get_Item(0);

        // Dodaj auto‑kształt typu Ellipse.
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

        // Zastosuj formatowanie gradientowe do elipsy.
        shape.getFillFormat().setFillType(FillType.Gradient);
        shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

        // Ustaw kierunek gradientu.
        shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

        // Dodaj dwa przystanki gradientu.
        shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
        shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

        // Zapisz plik PPTX na dysku.
        presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
```

Wynik:

![The ellipse with gradient fill](gradient-fill.png)

## **Wypełnienie wzorem**

W programie PowerPoint wypełnienie wzorem jest opcją formatowania, która pozwala zastosować dwukolorowy wzór — np. kropki, paski, krzyżówki lub szachownicę — do kształtu. Można wybrać własne kolory dla pierwszego planu i tła wzoru.

Aspose.Slides udostępnia ponad 45 wstępnie zdefiniowanych stylów wzoru, które można zastosować do kształtów w celu zwiększenia atrakcyjności wizualnej prezentacji. Nawet po wybraniu wstępnego wzoru można określić dokładne kolory, które mają być użyte.

Jak zastosować wypełnienie wzorem do kształtu przy użyciu Aspose.Slides:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu za pomocą jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) do slajdu.
1. Ustaw właściwość kształtu [FillType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/filltype/) na `Pattern`.
1. Wybierz styl wzoru spośród dostępnych opcji.
1. Ustaw [Background Color](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/patternformat/#getBackColor--) wzoru.
1. Ustaw [Foreground Color](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/patternformat/#getForeColor--) wzoru.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod Java demonstruje, jak zastosować wypełnienie wzorem do prostokąta:

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj auto‑kształt typu Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ustaw typ wypełnienia na Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Ustaw styl wzoru.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Ustaw kolory tła i pierwszego planu wzoru.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Zapisz plik PPTX na dysku.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![The rectangle with pattern fill](pattern-fill.png)

## **Wypełnienie obrazem**

W programie PowerPoint wypełnienie obrazem jest opcją formatowania, która pozwala wstawić obraz wewnątrz kształtu — efektywnie używając obrazu jako tła kształtu.

Jak używać Aspose.Slides do zastosowania wypełnienia obrazem w kształcie:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu za pomocą jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) do slajdu.
1. Ustaw właściwość kształtu [FillType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/filltype/) na `Picture`.
1. Ustaw tryb wypełnienia obrazem na `Tile` (lub inny preferowany tryb).
1. Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ippimage/) z obrazu, którego chcesz użyć.
1. Przekaż obraz do metody `ISlidesPicture.setImage`.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

![Obraz lotosu](lotus.png)

Poniższy kod Java demonstruje, jak wypełnić kształt obrazem:

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj auto‑kształt typu Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Ustaw typ wypełnienia na Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Ustaw tryb wypełnienia obrazem.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Wczytaj obraz i dodaj go do zasobów prezentacji.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // Ustaw obraz.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Zapisz plik PPTX na dysku.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![The shape with picture fill](picture-fill.png)

### **Kafelkowanie obrazu jako tekstury**

Jeśli chcesz ustawić obraz w trybie kafelkowym jako teksturę i dostosować zachowanie kafelkowania, możesz użyć następujących metod interfejsu [IPictureFillFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/) oraz klasy [PictureFillFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Ustawia tryb wypełnienia obrazem — `Tile` lub `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Określa wyrównanie kafelków wewnątrz kształtu.
- [setTileFlip](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Kontroluje, czy kafelek jest odbity w poziomie, w pionie czy w obu kierunkach.
- [setTileOffsetX](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Ustawia poziomy offset kafelka (w punktach) względem początku kształtu.
- [setTileOffsetY](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Ustawia pionowy offset kafelka (w punktach) względem początku kształtu.
- [setTileScaleX](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Definiuje poziomą skalę kafelka jako procent.
- [setTileScaleY](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Definiuje pionową skalę kafelka jako procent.

Poniższy przykład kodu pokazuje, jak dodać prostokąt z kafelkowym wypełnieniem obrazem i skonfigurować opcje kafelkowania:

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Dodaj auto-kształt typu Rectangle.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Ustaw typ wypełnienia kształtu na Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Wczytaj obraz i dodaj go do zasobów prezentacji.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Przypisz obraz do kształtu.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Skonfiguruj tryb wypełnienia obrazem oraz właściwości kafelkowania.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // Zapisz plik PPTX na dysku.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![The tile options](tile-options.png)

## **Wypełnienie kolorem stałym**

W programie PowerPoint wypełnienie kolorem stałym jest opcją formatowania, która wypełnia kształt jednym jednolitym kolorem. Ten jednolity kolor tła jest stosowany bez gradientów, tekstur ani wzorów.

Aby zastosować wypełnienie kolorem stałym do kształtu przy użyciu Aspose.Slides, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu za pomocą jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) do slajdu.
1. Ustaw właściwość kształtu [FillType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/filltype/) na `Solid`.
1. Przypisz wybrany kolor wypełnienia do kształtu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod Java demonstruje, jak zastosować wypełnienie kolorem stałym do prostokąta w slajdzie PowerPoint:

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj auto‑kształt typu Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ustaw typ wypełnienia na Solid.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Ustaw kolor wypełnienia.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Zapisz plik PPTX na dysku.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![The shape with solid color fill](solid-color-fill.png)

## **Ustaw przezroczystość**

W programie PowerPoint, kiedy stosujesz wypełnienie kolorem stałym, gradientem, obrazem lub teksturą do kształtów, możesz także ustawić poziom przezroczystości, aby kontrolować nieprzezroczystość wypełnienia. Wyższa wartość przezroczystości sprawia, że kształt jest bardziej przejrzysty, umożliwiając częściowe widzenie tła lub obiektów pod spodem.

Aspose.Slides pozwala ustawić poziom przezroczystości, modyfikując wartość alfa w kolorze używanym do wypełnienia. Oto jak to zrobić:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu za pomocą jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/filltype/) na `Solid`.
1. Użyj klasy `Color`, aby określić kolor z przezroczystością (składnik `alpha` kontroluje przezroczystość).
1. Zapisz prezentację.

Poniższy kod Java demonstruje, jak zastosować przezroczysty kolor wypełnienia do prostokąta:

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj prostokątny auto‑kształt wypełniony kolorem stałym.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Dodaj przezroczysty prostokątny auto‑kształt nad solidnym kształtem.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // Zapisz plik PPTX na dysku.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![The transparent shape](shape-transparency.png)

## **Obracanie kształtów**

Aspose.Slides pozwala obracać kształty w prezentacjach PowerPoint. Może to być przydatne przy pozycjonowaniu elementów wizualnych z określonym wyrównaniem lub wymaganiami projektowymi.

Aby obrócić kształt na slajdzie, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu za pomocą jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) do slajdu.
1. Ustaw właściwość obrotu kształtu na żądany kąt.
1. Zapisz prezentację.

Poniższy kod Java demonstruje, jak obrócić kształt o 5 stopni:

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj auto‑kształt typu Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Obróć kształt o 5 stopni.
    shape.setRotation(5);

    // Zapisz plik PPTX na dysku.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![The shape rotation](shape-rotation.png)

## **Dodaj efekty 3D Bevel**

Aspose.Slides umożliwia zastosowanie efektów 3D Bevel do kształtów poprzez konfigurację ich właściwości [ThreeDFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/threedformat/).

Aby dodać efekty 3D Bevel do kształtu, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu za pomocą jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) do slajdu.
1. Skonfiguruj właściwość kształtu [ThreeDFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/threedformat/), aby określić ustawienia wycięcia.
1. Zapisz prezentację.

Poniższy kod Java pokazuje, jak zastosować efekty 3D Bevel do kształtu:

```java
// Utwórz instancję klasy Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj kształt do slajdu.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // Ustaw właściwości ThreeDFormat kształtu.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // Zapisz prezentację jako plik PPTX.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![The 3D bevel effect](3D-bevel-effect.png)

## **Dodaj efekty rotacji 3D**

Aspose.Slides pozwala zastosować efekty rotacji 3D do kształtów poprzez konfigurację ich właściwości [ThreeDFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/threedformat/).

Aby zastosować rotację 3D do kształtu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu za pomocą jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) do slajdu.
1. Użyj metod [setCameraType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icamera/#setCameraType-int-) i [setLightType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilightrig/#setLightType-int-), aby określić rotację 3D.
1. Zapisz prezentację.

Poniższy kod Java demonstruje, jak zastosować efekty rotacji 3D do kształtu:

```java
// Utwórz instancję klasy Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // Zapisz prezentację jako plik PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![The 3D rotation effect](3D-rotation-effect.png)

## **Resetowanie formatowania**

Poniższy kod Java pokazuje, jak zresetować formatowanie slajdu i przywrócić pozycję, rozmiar oraz formatowanie wszystkich kształtów z placeholderami na [LayoutSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/layoutslide/) do ich domyślnych ustawień:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Zresetuj każdy kształt na slajdzie, który ma placeholder w układzie.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Czy formatowanie kształtów wpływa na ostateczny rozmiar pliku prezentacji?**

Tylko minimalnie. Osadzone obrazy i multimedia zajmują większość miejsca w pliku, natomiast parametry kształtów, takie jak kolory, efekty i gradienty, są przechowywane jako metadane i praktycznie nie zwiększają rozmiaru.

**Jak mogę wykryć kształty na slajdzie, które mają identyczne formatowanie, aby je pogrupować?**

Porównaj kluczowe właściwości formatowania każdego kształtu — ustawienia wypełnienia, linii i efektów. Jeśli wszystkie odpowiadające sobie wartości są takie same, traktuj ich style jako identyczne i logicznie grupuj te kształty, co upraszcza późniejsze zarządzanie stylami.

**Czy mogę zapisać zestaw własnych stylów kształtów do osobnego pliku, aby ponownie używać ich w innych prezentacjach?**

Tak. Przechowuj przykładowe kształty z pożądanymi stylami w szablonie prezentacji lub w pliku szablonu .POTX. Tworząc nową prezentację, otwórz szablon, sklonuj potrzebne stylowe kształty i ponownie zastosuj ich formatowanie tam, gdzie jest to wymagane.