---
title: Formatowanie kształtów PowerPoint w Javie
linktitle: Formatowanie kształtów
type: docs
weight: 20
url: /pl/java/shape-formatting/
keywords:
- formatowanie kształtu
- formatowanie linii
- formatowanie stylu połączenia
- wypełnienie gradientem
- wypełnienie wzorem
- wypełnienie obrazem
- wypełnienie teksturą
- wypełnienie kolorem stałym
- przezroczystość kształtu
- obrócenie kształtu
- efekt 3D bevel
- efekt 3D obrotu
- resetowanie formatowania
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak formatować kształty PowerPoint w Javie przy użyciu Aspose.Slides — ustawiaj style wypełnień, linii i efektów dla plików PPT, PPTX i ODP z precyzją i pełną kontrolą."
---
## **Wprowadzenie**

W programie PowerPoint możesz dodawać kształty do slajdów. Ponieważ kształty składają się z linii, możesz je formatować, modyfikując lub stosując efekty do ich konturów. Dodatkowo możesz formatować kształty, określając ustawienia kontrolujące sposób wypełniania ich wnętrz.

![formatowanie kształtu w PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Java udostępnia interfejsy i metody, które pozwalają formatować kształty przy użyciu tych samych opcji dostępnych w programie PowerPoint.

## **Formatowanie linii**

Za pomocą Aspose.Slides możesz określić własny styl linii dla kształtu. Poniższe kroki opisują procedurę:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
1. Uzyskaj odniesienie do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/) do slajdu.
1. Ustaw [line style](https://reference.aspose.com/slides/pl/java/com.aspose.slides/linestyle/) kształtu.
1. Ustaw szerokość linii.
1. Ustaw [dash style](https://reference.aspose.com/slides/pl/java/com.aspose.slides/linedashstyle/) linii.
1. Ustaw kolor linii dla kształtu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod demonstruje, jak sformatować prostokąt `AutoShape`:

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj kształt automatyczny typu Rectangle.
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

    // Zapisz plik PPTX na dysku.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Sformatowane linie w prezentacji](formatted-lines.png)

## **Formatowanie stylów połączeń**

Oto trzy dostępne opcje typu połączenia:

* Zaokrąglony
* Kątowy
* Ścięty

Domyślnie, gdy PowerPoint łączy dwie linie pod kątem (np. w rogu kształtu), używa ustawienia **Round**. Jednakże, jeśli rysujesz kształt o ostrych kątach, możesz woleć opcję **Miter**.

![Styl połączenia w prezentacji](join-style-powerpoint.png)

Poniższy kod w języku Java demonstruje, jak trzy prostokąty (jak na powyższym obrazku) zostały utworzone przy użyciu ustawień typu połączenia Miter, Bevel i Round:

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj trzy kształty automatyczne typu Rectangle.
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

W programie PowerPoint wypełnienie gradientem to opcja formatowania, która pozwala zastosować ciągłe przejście kolorów w kształcie. Na przykład możesz zastosować dwa lub więcej kolorów w taki sposób, że jeden stopniowo przechodzi w drugi.

Oto jak zastosować wypełnienie gradientem do kształtu przy użyciu Aspose.Slides:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
1. Uzyskaj odniesienie do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/filltype/) kształtu na `Gradient`.
1. Dodaj dwa wybrane kolory z określonymi pozycjami, używając metod `add` kolekcji gradient stop udostępnionej przez interfejs [IGradientFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/igradientformat/).
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod w języku Java demonstruje, jak zastosować efekt wypełnienia gradientem do elipsy:

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj kształt automatyczny typu Ellipse.
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

![Elipsa z wypełnieniem gradientem](gradient-fill.png)

## **Wypełnienie wzorem**

W programie PowerPoint wypełnienie wzorem to opcja formatowania, która pozwala zastosować dwukolorowy wzór — np. kropki, paski, krzyżowanie lub szachownicę — do kształtu. Możesz wybrać własne kolory pierwszego planu i tła wzoru.

Aspose.Slides udostępnia ponad 45 wstępnie zdefiniowanych stylów wzorów, które możesz zastosować do kształtów, aby zwiększyć atrakcyjność wizualną prezentacji. Nawet po wybraniu gotowego wzoru, możesz określić dokładne kolory, które mają być użyte.

Oto jak zastosować wypełnienie wzorem do kształtu przy użyciu Aspose.Slides:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
1. Uzyskaj odniesienie do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/filltype/) kształtu na `Pattern`.
1. Wybierz styl wzoru spośród wstępnie zdefiniowanych opcji.
1. Ustaw [Background Color](https://reference.aspose.com/slides/pl/java/com.aspose.slides/patternformat/#getBackColor--) wzoru.
1. Ustaw [Foreground Color](https://reference.aspose.com/slides/pl/java/com.aspose.slides/patternformat/#getForeColor--) wzoru.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj kształt automatyczny typu Rectangle.
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

![Prostokąt z wypełnieniem wzorem](pattern-fill.png)

## **Wypełnienie obrazem**

W programie PowerPoint wypełnienie obrazem to opcja formatowania, która pozwala wstawić obraz wewnątrz kształtu — efektywnie używając obrazu jako tło kształtu.

Oto jak użyć Aspose.Slides do zastosowania wypełnienia obrazem w kształcie:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
1. Uzyskaj odniesienie do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/filltype/) kształtu na `Picture`.
1. Ustaw tryb wypełnienia obrazem na `Tile` (lub inny preferowany tryb).
1. Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ippimage/) z obrazu, którego chcesz użyć.
1. Przekaż obraz do metody `ISlidesPicture.setImage`.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Załóżmy, że mamy plik "lotus.png" z następującym obrazem:

![Obraz lotosu](lotus.png)

Poniższy kod w języku Java demonstruje, jak wypełnić kształt obrazem:

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj kształt automatyczny typu Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Ustaw typ wypełnienia na Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Ustaw tryb wypełnienia obrazem.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Załaduj obraz i dodaj go do zasobów prezentacji.
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

![Kształt z wypełnieniem obrazem](picture-fill.png)

### **Kafelkowanie obrazu jako tekstura**

Jeśli chcesz ustawić kafelkowany obraz jako teksturę i dostosować zachowanie kafelkowania, możesz użyć następujących metod interfejsu [IPictureFillFormat] oraz klasy [PictureFillFormat]:

- [setPictureFillMode](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Ustawia tryb wypełnienia obrazem — `Tile` lub `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Określa wyrównanie kafelków w obrębie kształtu.
- [setTileFlip](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Kontroluje, czy kafelek jest odwrócony poziomo, pionowo lub w obu kierunkach.
- [setTileOffsetX](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Ustawia poziomy offset kafelka (w punktach) od początku kształtu.
- [setTileOffsetY](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Ustawia pionowy offset kafelka (w punktach) od początku kształtu.
- [setTileScaleX](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Definiuje poziomą skalę kafelka jako procent.
- [setTileScaleY](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Definiuje pionową skalę kafelka jako procent.

Poniższy przykład kodu pokazuje, jak dodać prostokąt z kafelkowanym wypełnieniem obrazem i skonfigurować opcje kafelkowania:

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Dodaj prostokątny kształt automatyczny.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Ustaw typ wypełnienia kształtu na Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Załaduj obraz i dodaj go do zasobów prezentacji.
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

    // Zapisz plik PPTX na dysku.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Opcje kafelkowania](tile-options.png)

## **Wypełnienie kolorem stałym**

W programie PowerPoint wypełnienie kolorem stałym to opcja formatowania, która wypełnia kształt jednym, jednolitym kolorem. Ten prosty kolor tła jest stosowany bez gradientów, tekstur ani wzorów.

Aby zastosować wypełnienie kolorem stałym do kształtu przy użyciu Aspose.Slides, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
1. Uzyskaj odniesienie do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/filltype/) kształtu na `Solid`.
1. Przypisz wybrany kolor wypełnienia do kształtu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod w języku Java demonstruje, jak zastosować wypełnienie kolorem stałym do prostokąta w slajdzie PowerPoint:

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj kształt automatyczny typu Rectangle.
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

![Kształt z wypełnieniem kolorem stałym](solid-color-fill.png)

## **Ustawienie przezroczystości**

W programie PowerPoint, gdy zastosujesz wypełnienie kolorem stałym, gradientem, obrazem lub teksturą do kształtów, możesz także ustawić poziom przezroczystości, aby kontrolować krycie wypełnienia. Wyższa wartość przezroczystości sprawia, że kształt staje się bardziej przejrzysty, umożliwiając częściowe widzenie tła lub leżących pod nim obiektów.

Aspose.Slides pozwala ustawić poziom przezroczystości, modyfikując wartość alfa w kolorze używanym do wypełnienia. Oto jak to zrobić:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
1. Uzyskaj odniesienie do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/filltype/) na `Solid`.
1. Użyj `Color` do zdefiniowania koloru z przezroczystością (składnik `alpha` kontroluje przezroczystość).
1. Zapisz prezentację.

Poniższy kod w języku Java demonstruje, jak zastosować przezroczysty kolor wypełnienia do prostokąta:

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj prostokątny kształt automatyczny z wypełnieniem stałym.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Dodaj przezroczysty prostokątny kształt automatyczny nad kształtem stałym.
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

![Przezroczysty kształt](shape-transparency.png)

## **Obracanie kształtów**

Aspose.Slides umożliwia obracanie kształtów w prezentacjach PowerPoint. Może to być przydatne przy pozycjonowaniu elementów wizualnych z określonymi potrzebami dotyczącymi wyrównania lub projektu.

Aby obrócić kształt na slajdzie, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
1. Uzyskaj odniesienie do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/) do slajdu.
1. Ustaw właściwość obrotu kształtu na żądany kąt.
1. Zapisz prezentację.

Poniższy kod w języku Java demonstruje, jak obrócić kształt o 5 stopni:

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj kształt automatyczny typu Rectangle.
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

![Obrót kształtu](shape-rotation.png)

## **Dodawanie efektów 3D Bevel**

Aspose.Slides pozwala zastosować efekty 3D Bevel do kształtów, konfigurując ich właściwości [ThreeDFormat].

Aby dodać efekty 3D Bevel do kształtu, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
1. Uzyskaj odniesienie do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/) do slajdu.
1. Skonfiguruj [ThreeDFormat] kształtu, aby określić ustawienia bevel.
1. Zapisz prezentację.

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

![Efekt 3D Bevel](3D-bevel-effect.png)

## **Dodawanie efektów 3D Rotation**

Aspose.Slides pozwala zastosować efekty 3D Rotation do kształtów, konfigurując ich właściwości [ThreeDFormat].

Aby zastosować obrót 3D do kształtu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
1. Uzyskaj odniesienie do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/) do slajdu.
1. Użyj [setCameraType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icamera/#setCameraType-int-) i [setLightType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilightrig/#setLightType-int-), aby określić obrót 3D.
1. Zapisz prezentację.

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

![Efekt 3D Rotation](3D-rotation-effect.png)

## **Resetowanie formatowania**

Poniższy kod w języku Java pokazuje, jak zresetować formatowanie slajdu i przywrócić pozycję, rozmiar oraz formatowanie wszystkich kształtów z symbolami zastępczymi na [LayoutSlide] do ich domyślnych ustawień:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Zresetuj każdy kształt na slajdzie, który ma symbol zastępczy w układzie.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Czy formatowanie kształtów wpływa na ostateczny rozmiar pliku prezentacji?**

Tylko w niewielkim stopniu. Osadzone obrazy i multimedia zajmują większość miejsca w pliku, podczas gdy parametry kształtów, takie jak kolory, efekty i gradienty, są przechowywane jako metadane i praktycznie nie zwiększają rozmiaru.

**Jak mogę wykryć kształty na slajdzie, które mają identyczne formatowanie, aby je pogrupować?**

Porównaj kluczowe właściwości formatowania każdego kształtu — ustawienia wypełnienia, linii i efektów. Jeśli wszystkie odpowiadające sobie wartości są zgodne, traktuj ich style jako identyczne i logicznie grupuj te kształty, co upraszcza późniejsze zarządzanie stylami.

**Czy mogę zapisać zestaw niestandardowych stylów kształtów w osobnym pliku, aby ponownie używać ich w innych prezentacjach?**

Tak. Przechowaj przykładowe kształty z pożądanymi stylami w szablonie zestawu slajdów lub w pliku szablonu .POTX. Tworząc nową prezentację, otwórz szablon, sklonuj potrzebne stylowane kształty i ponownie zastosuj ich formatowanie w wybranych miejscach.