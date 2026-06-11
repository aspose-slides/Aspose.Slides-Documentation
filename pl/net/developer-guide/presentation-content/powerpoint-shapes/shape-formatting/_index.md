---
title: Formatowanie kształtów PowerPoint w .NET
linktitle: Formatowanie kształtów
type: docs
weight: 20
url: /pl/net/shape-formatting/
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
- obracanie kształtu
- efekt fazowania 3D
- efekt obrotu 3D
- resetowanie formatowania
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak formatować kształty PowerPoint w C# przy użyciu Aspose.Slides — ustaw style wypełnienia, linii i efektów dla plików PPT i PPTX z precyzją i pełną kontrolą."
---
## **Wprowadzenie**

W programie PowerPoint możesz dodawać kształty do slajdów. Ponieważ kształty składają się z linii, możesz formatować je, modyfikując lub stosując efekty do ich konturów. Dodatkowo możesz formatować kształty, określając ustawienia kontrolujące sposób wypełnienia ich wnętrz.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for .NET zapewnia interfejsy i właściwości, które pozwalają formatować kształty przy użyciu tych samych opcji dostępnych w programie PowerPoint.

## **Formatowanie linii**

Korzystając z Aspose.Slides, możesz określić własny styl linii dla kształtu. Poniżej opisano kolejne kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/) do slajdu.
1. Ustaw [line style](https://reference.aspose.com/slides/pl/net/aspose.slides/linestyle/) kształtu.
1. Ustaw szerokość linii.
1. Ustaw [dash style](https://reference.aspose.com/slides/pl/net/aspose.slides/linedashstyle/) linii.
1. Ustaw kolor linii dla kształtu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```c#
    // Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
    using (Presentation presentation = new Presentation())
    {
        // Pobierz pierwszy slajd.
        ISlide slide = presentation.Slides[0];

        // Dodaj autokształt typu Rectangle.
        IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

        // Ustaw kolor wypełnienia dla prostokątnego kształtu.
        shape.FillFormat.FillType = FillType.NoFill;

        // Zastosuj formatowanie linii prostokąta.
        shape.LineFormat.Style = LineStyle.ThickThin;
        shape.LineFormat.Width = 7;
        shape.LineFormat.DashStyle = LineDashStyle.Dash;

        // Ustaw kolor linii prostokąta.
        shape.LineFormat.FillFormat.FillType = FillType.Solid;
        shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

        // Zapisz plik PPTX na dysku.
        presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
    }
```

Wynik:

![Sformatowane linie w prezentacji](formatted-lines.png)

## **Styl połączeń**

Oto trzy dostępne opcje typu połączenia:

* Zaokrąglony
* Kątowy
* Fazowany

Domyślnie, gdy PowerPoint łączy dwie linie pod kątem (np. w rogu kształtu), używa ustawienia **Round**. Jednak przy rysowaniu kształtu o ostrych kątach możesz woleć opcję **Miter**.

![Styl połączenia w prezentacji](join-style-powerpoint.png)

```c#
 // Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
 using (Presentation presentation = new Presentation())
 {
     // Pobierz pierwszy slajd.
     ISlide slide = presentation.Slides[0];

     // Dodaj trzy autokształty typu Rectangle.
     IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
     IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
     IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

     // Ustaw kolor wypełnienia dla każdego prostokątnego kształtu.
     shape1.FillFormat.FillType = FillType.Solid;
     shape1.FillFormat.SolidFillColor.Color = Color.Black;
     shape2.FillFormat.FillType = FillType.Solid;
     shape2.FillFormat.SolidFillColor.Color = Color.Black;
     shape3.FillFormat.FillType = FillType.Solid;
     shape3.FillFormat.SolidFillColor.Color = Color.Black;

     // Ustaw szerokość linii.
     shape1.LineFormat.Width = 15;
     shape2.LineFormat.Width = 15;
     shape3.LineFormat.Width = 15;

     // Ustaw kolor linii dla każdego prostokąta.
     shape1.LineFormat.FillFormat.FillType = FillType.Solid;
     shape1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
     shape2.LineFormat.FillFormat.FillType = FillType.Solid;
     shape2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
     shape3.LineFormat.FillFormat.FillType = FillType.Solid;
     shape3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

     // Ustaw styl połączenia.
     shape1.LineFormat.JoinStyle = LineJoinStyle.Miter;
     shape2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
     shape3.LineFormat.JoinStyle = LineJoinStyle.Round;

     // Dodaj tekst do każdego prostokąta.
     shape1.TextFrame.Text = "Miter Join Style";
     shape2.TextFrame.Text = "Bevel Join Style";
     shape3.TextFrame.Text = "Round Join Style";

     // Zapisz plik PPTX na dysku.
     presentation.Save("join_styles.pptx", SaveFormat.Pptx);
 }
```

## **Wypełnienie gradientem**

W programie PowerPoint wypełnienie gradientem to opcja formatowania, która pozwala zastosować ciągłe przejście kolorów na kształcie. Na przykład możesz zastosować dwa lub więcej kolorów w taki sposób, że jeden stopniowo przechodzi w drugi.

Oto jak zastosować wypełnienie gradientem do kształtu przy użyciu Aspose.Slides:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/net/aspose.slides/filltype/) kształtu na `Gradient`.
1. Dodaj dwa wybrane kolory z określonymi pozycjami, używając metod `Add` kolekcji przystanków gradientu udostępnianej przez interfejs [IGradientFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/igradientformat/).
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```c#
 // Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
 using (Presentation presentation = new Presentation())
 {
     // Pobierz pierwszy slajd.
     ISlide slide = presentation.Slides[0];

     // Dodaj autokształt typu Ellipse.
     IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

     // Zastosuj formatowanie gradientu do elipsy.
     shape.FillFormat.FillType = FillType.Gradient;
     shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

     // Ustaw kierunek gradientu.
     shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

     // Dodaj dwa przystanki gradientu.
     shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
     shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

     // Zapisz plik PPTX na dysku.
     presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
 }
```

Wynik:

![Elipsa z wypełnieniem gradientowym](gradient-fill.png)

## **Wypełnienie wzorem**

W programie PowerPoint wypełnienie wzorem to opcja formatowania, która pozwala zastosować dwukolorowy wzór — np. kropki, paski, krzyżowe kreski lub szachownicę — na kształcie. Możesz wybrać własne kolory dla pierwszego planu i tła wzoru.

Aspose.Slides udostępnia ponad 45 wbudowanych stylów wzorów, które możesz zastosować do kształtów, aby podnieść atrakcyjność wizualną prezentacji. Nawet po wybraniu gotowego wzoru możesz określić dokładne kolory, które zostaną użyte.

Oto jak zastosować wypełnienie wzorem do kształtu przy użyciu Aspose.Slides:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/net/aspose.slides/filltype/) kształtu na `Pattern`.
1. Wybierz styl wzoru spośród dostępnych opcji.
1. Ustaw [Background Color](https://reference.aspose.com/slides/pl/net/aspose.slides/ipatternformat/backcolor/) wzoru.
1. Ustaw [Foreground Color](https://reference.aspose.com/slides/pl/net/aspose.slides/ipatternformat/forecolor/) wzoru.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```c#
 // Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
 using (Presentation presentation = new Presentation())
 {
     // Pobierz pierwszy slajd.
     ISlide slide = presentation.Slides[0];

     // Dodaj autokształt typu Rectangle.
     IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

     // Ustaw typ wypełnienia na Pattern.
     shape.FillFormat.FillType = FillType.Pattern;

     // Ustaw styl wzoru.
     shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

     // Ustaw tło i kolor pierwszego planu wzoru.
     shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
     shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

     // Zapisz plik PPTX na dysku.
     presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
 }
```

Wynik:

![Prostokąt z wypełnieniem wzorem](pattern-fill.png)

## **Wypełnienie obrazem**

W programie PowerPoint wypełnienie obrazem to opcja formatowania, która pozwala wstawić obraz wewnątrz kształtu — efektywnie używając obrazu jako tła kształtu.

Oto jak używać Aspose.Slides do zastosowania wypełnienia obrazem w kształcie:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/net/aspose.slides/filltype/) kształtu na `Picture`.
1. Ustaw tryb wypełnienia obrazem na `Tile` (lub inny preferowany tryb).
1. Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage/) z obrazu, którego chcesz użyć.
1. Przypisz ten obraz do właściwości `Picture.Image` w `PictureFillFormat` kształtu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

![Obraz lotosu](lotus.png)

```c#
 // Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
 using (Presentation presentation = new Presentation())
 {
     // Pobierz pierwszy slajd.
     ISlide slide = presentation.Slides[0];

     // Dodaj autokształt typu Rectangle.
     IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

     // Ustaw typ wypełnienia na Picture.
     shape.FillFormat.FillType = FillType.Picture;

     // Ustaw tryb wypełnienia obrazem.
     shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

     // Załaduj obraz i dodaj go do zasobów prezentacji.
     IImage image = Images.FromFile("lotus.png");
     IPPImage presentationImage = presentation.Images.AddImage(image);
     image.Dispose();

     // Ustaw obraz.
     shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

     // Zapisz plik PPTX na dysku.
     presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
 }
```

Wynik:

![Kształt z wypełnieniem obrazem](picture-fill.png)

### **Obraz kafelkowy jako tekstura**

Jeśli chcesz ustawić obraz w trybie kafelkowym jako teksturę i dostosować zachowanie kafelkowania, możesz użyć następujących właściwości interfejsu [IPictureFillFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ipicturefillformat/) oraz klasy [PictureFillFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/pl/net/aspose.slides/ipicturefillformat/picturefillmode/): Ustawia tryb wypełnienia obrazem — `Tile` lub `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/pl/net/aspose.slides/ipicturefillformat/tilealignment/): Określa wyrównanie kafelków wewnątrz kształtu.
- [TileFlip](https://reference.aspose.com/slides/pl/net/aspose.slides/ipicturefillformat/tileflip/): Kontroluje, czy kafelek jest odbity w poziomie, w pionie lub w obu kierunkach.
- [TileOffsetX](https://reference.aspose.com/slides/pl/net/aspose.slides/ipicturefillformat/tileoffsetx/): Ustawia poziomy offset kafelka (w punktach) od początku kształtu.
- [TileOffsetY](https://reference.aspose.com/slides/pl/net/aspose.slides/ipicturefillformat/tileoffsety/): Ustawia pionowy offset kafelka (w punktach) od początku kształtu.
- [TileScaleX](https://reference.aspose.com/slides/pl/net/aspose.slides/ipicturefillformat/tilescalex/): Definiuje poziomą skalę kafelka jako procent.
- [TileScaleY](https://reference.aspose.com/slides/pl/net/aspose.slides/ipicturefillformat/tilescaley/): Definiuje pionową skalę kafelka jako procent.

```c#
 // Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
 using (Presentation presentation = new Presentation())
 {
     // Pobierz pierwszy slajd.
     ISlide firstSlide = presentation.Slides[0];

     // Dodaj autokształt typu Rectangle.
     IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

     // Ustaw typ wypełnienia kształtu na Picture.
     shape.FillFormat.FillType = FillType.Picture;

     // Załaduj obraz i dodaj go do zasobów prezentacji.
     IPPImage presentationImage;
     using (IImage sourceImage = Images.FromFile("lotus.png"))
         presentationImage = presentation.Images.AddImage(sourceImage);

     // Przypisz obraz do kształtu.
     IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
     pictureFillFormat.Picture.Image = presentationImage;

     // Skonfiguruj tryb wypełnienia obrazem oraz właściwości kafelkowania.
     pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
     pictureFillFormat.TileOffsetX = -32;
     pictureFillFormat.TileOffsetY = -32;
     pictureFillFormat.TileScaleX = 50;
     pictureFillFormat.TileScaleY = 50;
     pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
     pictureFillFormat.TileFlip = TileFlip.FlipBoth;

     // Zapisz plik PPTX na dysku.
     presentation.Save("tile.pptx", SaveFormat.Pptx);
 }
```

Wynik:

![Opcje kafelkowania](tile-options.png)

## **Wypełnienie kolorem stałym**

W programie PowerPoint wypełnienie kolorem stałym to opcja formatowania, która wypełnia kształt jednym jednolitym kolorem. Ten prosty kolor tła jest stosowany bez gradientów, tekstur ani wzorów.

Aby zastosować wypełnienie kolorem stałym do kształtu przy użyciu Aspose.Slides, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/net/aspose.slides/filltype/) kształtu na `Solid`.
1. Przypisz wybrany kolor wypełnienia do kształtu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```c#
 // Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
 using (Presentation presentation = new Presentation())
 {
     // Pobierz pierwszy slajd.
     ISlide slide = presentation.Slides[0];

     // Dodaj autokształt typu Rectangle.
     IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

     // Ustaw typ wypełnienia na Solid.
     shape.FillFormat.FillType = FillType.Solid;

     // Ustaw kolor wypełnienia.
     shape.FillFormat.SolidFillColor.Color = Color.Yellow;

     // Zapisz plik PPTX na dysku.
     presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
 }
```

Wynik:

![Kształt z wypełnieniem jednolitym kolorem](solid-color-fill.png)

## **Ustaw przezroczystość**

W programie PowerPoint, gdy stosujesz wypełnienie jednolitym kolorem, gradientem, obrazem lub teksturą, możesz także ustawić poziom przezroczystości, aby kontrolować krycie wypełnienia. Wyższa wartość przezroczystości sprawia, że kształt jest bardziej przejrzysty, co pozwala częściowo widzieć tło lub obiekty pod nim.

Aspose.Slides umożliwia ustawienie poziomu przezroczystości poprzez dostosowanie wartości alfa w kolorze używanym do wypełnienia. Oto jak to zrobić:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/net/aspose.slides/filltype/) na `Solid`.
1. Użyj `Color.FromArgb(alpha, baseColor)`, aby zdefiniować kolor z przezroczystością (składnik `alpha` kontroluje przezroczystość).
1. Zapisz prezentację.

```c#
const int alpha = 128;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
using (Presentation presentation = new Presentation())
{
    // Pobierz pierwszy slajd.
    ISlide slide = presentation.Slides[0];

    // Dodaj prostokątny autokształt wypełniony.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Dodaj przezroczysty prostokątny autokształt nad wypełnionym kształtem.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // Zapisz plik PPTX na dysku.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

Wynik:

![Przezroczysty kształt](shape-transparency.png)

## **Obracanie kształtów**

Aspose.Slides pozwala obracać kształty w prezentacjach PowerPoint. Może to być przydatne przy pozycjonowaniu elementów wizualnych z określonym wyrównaniem lub wymogami projektowymi.

Aby obrócić kształt na slajdzie, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/) do slajdu.
1. Ustaw właściwość `Rotation` kształtu na żądany kąt.
1. Zapisz prezentację.

```c#
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
using (Presentation presentation = new Presentation())
{
    // Pobierz pierwszy slajd.
    ISlide slide = presentation.Slides[0];

    // Dodaj autokształt typu Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Obróć kształt o 5 stopni.
    shape.Rotation = 5;

    // Zapisz plik PPTX na dysku.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

Wynik:

![Obrót kształtu](shape-rotation.png)

## **Dodaj efekty 3D fazowania**

Aspose.Slides umożliwia zastosowanie efektów 3D fazowania do kształtów poprzez konfigurację ich właściwości [ThreeDFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/threedformat/).

Aby dodać efekty 3D fazowania do kształtu, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/) do slajdu.
1. Skonfiguruj [ThreeDFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/threedformat/) kształtu, aby określić ustawienia fazowania.
1. Zapisz prezentację.

```c#
// Utwórz instancję klasy Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Dodaj kształt do slajdu.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;

    // Ustaw właściwości ThreeDFormat kształtu.
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

    // Zapisz prezentację jako plik PPTX.
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```

Wynik:

![Efekt 3D fazowania](3D-bevel-effect.png)

## **Dodaj efekty obrotu 3D**

Aspose.Slides umożliwia zastosowanie efektów obrotu 3D do kształtów poprzez konfigurację ich właściwości [ThreeDFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/threedformat/).

Aby zastosować obrót 3D do kształtu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu według jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/) do slajdu.
1. Ustaw [CameraType](https://reference.aspose.com/slides/pl/net/aspose.slides/icamera/cameratype/) i [LightType](https://reference.aspose.com/slides/pl/net/aspose.slides/ilightrig/lighttype/) kształtu, aby określić obrót 3D.
1. Zapisz prezentację.

```c#
// Utwórz instancję klasy Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // Zapisz prezentację jako plik PPTX.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

Wynik:

![Efekt obrotu 3D](3D-rotation-effect.png)

## **Resetowanie formatowania**

Poniższy kod C# pokazuje, jak zresetować formatowanie slajdu i przywrócić pozycję, rozmiar oraz formatowanie wszystkich kształtów z zastępcami na [LayoutSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/layoutslide/) do ustawień domyślnych:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Zresetuj każdy kształt na slajdzie, który ma placeholder w układzie.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Czy formatowanie kształtów wpływa na ostateczny rozmiar pliku prezentacji?**

Tylko w niewielkim stopniu. Osadzone obrazy i media zajmują większość miejsca, podczas gdy parametry kształtów, takie jak kolory, efekty i gradienty, są przechowywane jako metadane i praktycznie nie zwiększają rozmiaru pliku.

**Jak mogę wykryć kształty na slajdzie, które mają identyczne formatowanie, aby je pogrupować?**

Porównaj kluczowe właściwości formatowania każdego kształtu — ustawienia wypełnienia, linii i efektów. Jeśli wszystkie odpowiadające sobie wartości się zgadzają, traktuj ich style jako identyczne i logicznie grupuj te kształty, co upraszcza późniejsze zarządzanie stylami.

**Czy mogę zapisać zestaw własnych stylów kształtów w osobnym pliku, aby ponownie używać ich w innych prezentacjach?**

Tak. Przechowuj przykładowe kształty z pożądanymi stylami w szablonie prezentacji lub pliku szablonu .POTX. Tworząc nową prezentację, otwórz szablon, sklonuj potrzebne stylowe kształty i ponownie zastosuj ich formatowanie tam, gdzie jest wymagane.