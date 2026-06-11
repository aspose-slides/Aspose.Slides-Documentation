---
title: Formatowanie kształtów PowerPoint na Androidzie
linktitle: Formatowanie kształtów
type: docs
weight: 20
url: /pl/androidjava/shape-formatting/
keywords:
- formatowanie kształtu
- formatowanie linii
- formatowanie stylu połączenia
- wypełnienie gradientowe
- wypełnienie wzorem
- wypełnienie obrazem
- wypełnienie teksturą
- wypełnienie jednolitym kolorem
- przezroczystość kształtu
- obrót kształtu
- efekt 3D bevel
- efekt 3D rotacji
- resetowanie formatowania
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak formatować kształty PowerPoint na Androidzie przy użyciu Aspose.Slides — ustaw style wypełnienia, linii i efektów dla plików PPT, PPTX i ODP z precyzją i pełną kontrolą."
---
## **Wprowadzenie**

W programie PowerPoint możesz dodawać kształty do slajdów. Ponieważ kształty składają się z linii, możesz je formatować, modyfikując lub stosując efekty na ich konturach. Dodatkowo możesz formatować kształty, określając ustawienia kontrolujące wypełnienie ich wnętrza.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Android via Java udostępnia interfejsy i metody, które pozwalają formatować kształty przy użyciu tych samych opcji, które są dostępne w programie PowerPoint.

## **Formatowanie linii**

Korzystając z Aspose.Slides, możesz określić własny styl linii dla kształtu. Poniższe kroki opisują procedurę:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
1. Pobierz referencję do slajdu według jego indeksu.
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

    // Dodaj automatyczny kształt typu Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Ustaw kolor wypełnienia dla prostokątnego kształtu.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Zastosuj formatowanie do linii prostokąta.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Ustaw kolor linii prostokąta.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Zapisz plik PPTX na dysk.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Sformatowane linie w prezentacji](formatted-lines.png)

## **Formatowanie stylów połączeń**

Oto trzy dostępne opcje typu połączenia:

* Round
* Miter
* Bevel

Domyślnie, gdy PowerPoint łączy dwie linie pod kątem (np. w rogu kształtu), używa ustawienia **Round**. Jeśli jednak rysujesz kształt o ostrych kątach, możesz wolać opcję **Miter**.

![Styl połączenia w prezentacji](join-style-powerpoint.png)

Poniższy kod w języku Java demonstruje, jak trzy prostokąty (jak na powyższym obrazku) zostały utworzone przy użyciu ustawień Miter, Bevel i Round:

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj trzy automatyczne kształty typu Rectangle.
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

    // Ustaw kolor linii każdego prostokąta.
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Ustaw styl połączenia.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Dodaj tekst do każdego prostokąta.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Zapisz plik PPTX na dysk.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gradient Fill**

W programie PowerPoint wypełnienie gradientowe to opcja formatowania, która pozwala zastosować ciągłe przejście kolorów w kształcie. Na przykład możesz zastosować dwa lub więcej kolorów w taki sposób, że jeden stopniowo przechodzi w drugi.

Oto jak zastosować wypełnienie gradientowe do kształtu przy użyciu Aspose.Slides:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
1. Pobierz referencję do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/filltype/) kształtu na `Gradient`.
1. Dodaj dwa wybrane kolory wraz z określonymi pozycjami, używając metod `add` kolekcji punktów gradientu udostępnianej przez interfejs [IGradientFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/igradientformat/).
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod w języku Java demonstruje, jak zastosować efekt wypełnienia gradientowego do elipsy:

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj automatyczny kształt typu Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Zastosuj formatowanie gradientowe do elipsy.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Ustaw kierunek gradientu.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Dodaj dwa punkty gradientu.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Zapisz plik PPTX na dysk.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Elipsa z wypełnieniem gradientowym](gradient-fill.png)

## **Pattern Fill**

W programie PowerPoint wypełnienie wzorem to opcja formatowania, która pozwala zastosować dwukolorowy wzór — taki jak kropki, paski, krzyżykowanie lub kratkę — do kształtu. Możesz wybrać własne kolory pierwszego planu i tła wzoru.

Aspose.Slides udostępnia ponad 45 predefiniowanych stylów wzorów, które można zastosować do kształtów w celu zwiększenia atrakcyjności wizualnej prezentacji. Nawet po wybraniu gotowego wzoru możesz określić dokładne kolory, które mają być użyte.

Oto jak zastosować wypełnienie wzorem do kształtu przy użyciu Aspose.Slides:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
1. Pobierz referencję do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/filltype/) kształtu na `Pattern`.
1. Wybierz styl wzoru spośród predefiniowanych opcji.
1. Ustaw [Background Color](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/patternformat/#getBackColor--) wzoru.
1. Ustaw [Foreground Color](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/patternformat/#getForeColor--) wzoru.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod w języku Java demonstruje, jak zastosować wypełnienie wzorem do prostokąta:

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj automatyczny kształt typu Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ustaw typ wypełnienia na Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Ustaw styl wzoru.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Ustaw tło i kolor pierwszego planu wzoru.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Zapisz plik PPTX na dysk.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Prostokąt z wypełnieniem wzorem](pattern-fill.png)

## **Picture Fill**

W programie PowerPoint wypełnienie obrazem to opcja formatowania, która pozwala wstawić obraz wewnątrz kształtu — skutecznie używając obrazu jako tła kształtu.

Oto jak używać Aspose.Slides, aby zastosować wypełnienie obrazem do kształtu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
1. Pobierz referencję do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/filltype/) kształtu na `Picture`.
1. Ustaw tryb wypełnienia obrazem na `Tile` (lub inny wybrany tryb).
1. Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ippimage/) z obrazu, którego chcesz użyć.
1. Przekaż obraz do metody `ISlidesPicture.setImage`.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Załóżmy, że mamy plik „lotus.png” z następującym obrazem:

![Obraz lotosu](lotus.png)

Poniższy kod w języku Java demonstruje, jak wypełnić kształt obrazem:

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj automatyczny kształt typu Rectangle.
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

    // Zapisz plik PPTX na dysk.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Kształt z wypełnieniem obrazem](picture-fill.png)

### **Tile Picture As Texture**

Jeśli chcesz ustawić obraz w trybie kafelkowania jako teksturę i dostosować zachowanie kafelkowania, możesz użyć następujących metod interfejsu [IPictureFillFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/) i klasy [PictureFillFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Ustawia tryb wypełnienia obrazem — `Tile` lub `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Określa wyrównanie kafelków w obrębie kształtu.
- [setTileFlip](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Kontroluje, czy kafelek jest odbity poziomo, pionowo czy w obu kierunkach.
- [setTileOffsetX](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Ustawia poziomy offset kafelka (w punktach) od początku kształtu.
- [setTileOffsetY](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Ustawia pionowy offset kafelka (w punktach) od początku kształtu.
- [setTileScaleX](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Definiuje poziomą skalę kafelka jako procent.
- [setTileScaleY](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Definiuje pionową skalę kafelka jako procent.

Poniższy przykład kodu pokazuje, jak dodać prostokątny kształt z wypełnieniem obrazem kafelkowanym i skonfigurować opcje kafelkowania:

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Dodaj automatyczny kształt prostokąta.
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

    // Skonfiguruj tryb wypełnienia obrazem i właściwości kafelkowania.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // Zapisz plik PPTX na dysk.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Opcje kafelkowania](tile-options.png)

## **Solid Color Fill**

W programie PowerPoint wypełnienie jednolitym kolorem to opcja formatowania, która wypełnia kształt jednym, jednolitym kolorem. Ten prosty kolor tła jest stosowany bez gradientów, tekstur ani wzorów.

Aby zastosować wypełnienie jednolitym kolorem do kształtu przy użyciu Aspose.Slides, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
1. Pobierz referencję do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/filltype/) kształtu na `Solid`.
1. Przypisz wybrany kolor wypełnienia do kształtu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod w języku Java demonstruje, jak zastosować wypełnienie jednolitym kolorem do prostokąta w slajdzie PowerPoint:

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj automatyczny kształt typu Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ustaw typ wypełnienia na Solid.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Ustaw kolor wypełnienia.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Zapisz plik PPTX na dysk.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Kształt z wypełnieniem jednolitym kolorem](solid-color-fill.png)

## **Set Transparency**

W programie PowerPoint, gdy stosujesz wypełnienie jednolitym kolorem, gradientem, obrazem lub teksturą do kształtów, możesz także ustawić poziom przejrzystości, aby kontrolować krycie wypełnienia. Wyższa wartość przejrzystości sprawia, że kształt jest bardziej przezroczysty, pozwalając częściowo widzieć tło lub obiekty znajdujące się pod nim.

Aspose.Slides umożliwia ustawienie poziomu przejrzystości poprzez dostosowanie wartości alfa koloru używanego do wypełnienia. Oto jak to zrobić:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
1. Pobierz referencję do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/filltype/) na `Solid`.
1. Użyj klasy `Color` do określenia koloru z przejrzystością (składnik `alpha` kontroluje przejrzystość).
1. Zapisz prezentację.

Poniższy kod w języku Java demonstruje, jak zastosować przezroczysty kolor wypełnienia do prostokąta:

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj automatyczny prostokąt wypełniony kolorem.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Dodaj przezroczysty prostokątny kształt automatyczny nad wypełnionym kształtem.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // Zapisz plik PPTX na dysk.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Przezroczysty kształt](shape-transparency.png)

## **Rotate Shapes**

Aspose.Slides umożliwia obracanie kształtów w prezentacjach PowerPoint. Może to być przydatne przy pozycjonowaniu elementów wizualnych wymagających określonego wyrównania lub projektu.

Aby obrócić kształt na slajdzie, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
1. Pobierz referencję do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) do slajdu.
1. Ustaw właściwość rotacji kształtu na żądany kąt.
1. Zapisz prezentację.

Poniższy kod w języku Java demonstruje, jak obrócić kształt o 5 stopni:

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj automatyczny kształt typu Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Obróć kształt o 5 stopni.
    shape.setRotation(5);

    // Zapisz plik PPTX na dysk.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Obrót kształtu](shape-rotation.png)

## **Add 3D Bevel Effects**

Aspose.Slides pozwala stosować efekty 3D bevel do kształtów poprzez konfigurowanie ich właściwości [ThreeDFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/threedformat/).

Aby dodać efekty 3D bevel do kształtu, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
1. Pobierz referencję do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) do slajdu.
1. Skonfiguruj [ThreeDFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/threedformat/) kształtu, aby określić ustawienia bevel.
1. Zapisz prezentację.

Poniższy kod w języku Java pokazuje, jak zastosować efekty 3D bevel do kształtu:

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

    // Ustaw własności ThreeDFormat kształtu.
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

![Efekt 3D bevel](3D-bevel-effect.png)

## **Add 3D Rotation Effects**

Aspose.Slides pozwala stosować efekty 3D rotacji do kształtów poprzez konfigurowanie ich właściwości [ThreeDFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/threedformat/).

Aby zastosować 3D rotację do kształtu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
1. Pobierz referencję do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) do slajdu.
1. Użyj metod [setCameraType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icamera/#setCameraType-int-) oraz [setLightType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilightrig/#setLightType-int-), aby zdefiniować rotację 3D.
1. Zapisz prezentację.

Poniższy kod w języku Java demonstruje, jak zastosować efekty 3D rotacji do kształtu:

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

![Efekt 3D rotacji](3D-rotation-effect.png)

## **Reset Formatting**

Poniższy kod w języku Java pokazuje, jak zresetować formatowanie slajdu i przywrócić pozycję, rozmiar oraz formatowanie wszystkich kształtów z placeholderami na [LayoutSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/layoutslide/) do ich domyślnych ustawień:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Zresetuj każdy kształt na slajdzie, który ma placeholder na układzie.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Czy formatowanie kształtów wpływa na ostateczny rozmiar pliku prezentacji?**

Jedynie minimalnie. Osadzone obrazy i multimedia zajmują większość miejsca w pliku, podczas gdy parametry kształtów, takie jak kolory, efekty i gradienty, są przechowywane jako metadane i praktycznie nie zwiększają rozmiaru.

**Jak mogę wykryć kształty na slajdzie, które mają identyczne formatowanie, aby je pogrupować?**

Porównaj kluczowe właściwości formatowania każdego kształtu — ustawienia wypełnienia, linii i efektów. Jeśli wszystkie odpowiadające sobie wartości są zgodne, traktuj ich style jako identyczne i logicznie grupuj te kształty, co ułatwia późniejsze zarządzanie stylami.

**Czy mogę zapisać zestaw niestandardowych stylów kształtów w oddzielnym pliku do ponownego użycia w innych prezentacjach?**

Tak. Przechowuj przykładowe kształty z pożądanymi stylami w szablonie prezentacji lub pliku szablonu .POTX. Przy tworzeniu nowej prezentacji otwórz szablon, sklonuj potrzebne stylowane kształty i ponownie zastosuj ich formatowanie tam, gdzie jest to wymagane.