---
title: Tworzenie efektów 3D w prezentacjach przy użyciu .NET
linktitle: Prezentacja 3D
type: docs
weight: 232
url: /pl/net/3d-presentation/
keywords:
- PowerPoint 3D
- prezentacja 3D
- obrót 3D
- głębokość 3D
- ekstruzja 3D
- gradient 3D
- tekst 3D
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Zastosuj i renderuj efekty 3D dla kształtów i tekstu PowerPoint w .NET przy użyciu Aspose.Slides. Konfiguruj kamerę, oświetlenie, materiał, ekstruzję, wypełnienia i tekst 3D."
---
## **Przegląd**

Aspose.Slides for .NET może tworzyć, edytować, zachowywać i renderować formatowanie 3D w stylu PowerPoint dla kształtów i tekstu. Ten artykuł opisuje efekty 3D, takie jak obrót, ekstruzja, fazety, oświetlenie, materiał, wypełnienia gradientowe lub obrazu oraz tekst 3D.

{{% alert color="info" %}}
Ten artykuł dotyczy efektów formatowania 3D na kształtach i tekście w PowerPoint. Nie dotyczy wstawiania ani edycji samodzielnych plików modeli 3D. Kiedy eksportujesz slajd do obrazu, PDF lub HTML, Aspose.Slides renderuje te efekty 3D w wyjściowym 2D.
{{% /alert %}}

## **Koncepcje formatowania 3D**

Użyj właściwości [IShape.ThreeDFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/properties/threedformat) aby zastosować formatowanie 3D do kształtu. Właściwość udostępnia [IThreeDFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat), które steruje sceną 3D dla tego kształtu.

Dla tekstu użyj właściwości [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframeformat/properties/threedformat). Zastosuje to formatowanie 3D do ramki tekstowej, a nie do ciała kształtu.

Najważniejsze właściwości to:

| Właściwość | Co kontroluje | Kiedy używać |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/camera) | Punkt widzenia, typ kamery z ustawieniem wstępnym, obrót, przybliżenie i perspektywa. | Obróć obiekt w przestrzeni 3D lub dopasuj do wstępnego ustawienia obrotu 3D w PowerPoint. |
| [LightRig](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/lightrig) | Ustawienie światła, kierunek i obrót światła. | Zmienia sposób, w jaki podświetlenia i cienie pojawiają się na powierzchni 3D. |
| [Material](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/material) | Materiał powierzchni, np. płaski, matowy, plastikowy lub metalowy. | Spraw, aby ta sama geometria wyglądała bardziej płasko, miękko, błyszcząco lub metalicznie. |
| [ExtrusionHeight](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/extrusionheight) | Jak daleko kształt rozciąga się w tył od swojej przedniej ściany. | Zamień płaski kształt w widocznie gruby obiekt 3D. |
| [ExtrusionColor](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Kolor wyextrudowanych boków. | Uczyń głębokość widoczną lub skoordynuj kolor boków z wypełnieniem przodu. |
| [Depth](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/depth) | Dodatkowa głębokość 3D używana w formatowaniu 3D w PowerPoint. | Dostosuj precyzyjnie głębokość dla kształtów lub tekstu, szczególnie w połączeniu z ustawieniami fazetu i materiału. |
| [BevelTop](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/beveltop) i [BevelBottom](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/bevelbottom) | Podniesione lub zaokrąglone krawędzie na przedniej i tylnej powierzchni. | Dodaj zmiękczoną lub formowaną krawędź zamiast ostrej płaskiej powierzchni. |
| [ContourColor](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/contourcolor) i [ContourWidth](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/contourwidth) | Obrys wokół obiektu 3D. | Podkreśl granicę obiektu w renderowanym wyniku. |

## **Utwórz kształt 3D**

Kształt zazwyczaj potrzebuje czterech rodzajów ustawień, aby wyglądał wiarygodnie 3D:

- Ustawienia kamery, ponieważ domyślny widok z przodu może ukrywać ekstruzję.
- Ustawienia oświetlenia, ponieważ oświetlenie sprawia, że powierzchnie i boki są czytelne.
- Ustawienia materiału, ponieważ powierzchnia wpływa na sposób renderowania światła.
- Ustawienia ekstruzji lub głębokości, ponieważ płaski kształt potrzebuje grubości.

Poniższy przykład tworzy prostokąt, dodaje tekst do jego przedniej ściany, stosuje formatowanie 3D, zapisuje prezentację jako PPTX i renderuje slajd jako obraz PNG.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.TextFrame.Text = "3D";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("shape_3d.png");

presentation.Save("shape_3d.pptx", SaveFormat.Pptx);
```

Wyrenderowany slajd pokazuje prostokąt jako gruby blok 3D:

![Wyrenderowany niebieski prostokąt 3D z białym tekstem 3D na przedniej powierzchni](img_01_01.png)

## **Obróć kształt przy użyciu kamery**

W PowerPoint, obrót 3D jest konfigurowany w oknie 3‑D Rotation. Wartości obrotu X, Y i Z odpowiadają obrotowi ustawionemu przez API kamery.

![Okno PowerPoint 3‑D Rotation z zaznaczonymi wartościami obrotu X, Y i Z](img_02_01.png)

W Aspose.Slides ustaw typ kamery i obrót za pomocą [IThreeDFormat.Camera](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/camera):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Użyj kamery, gdy potrzebujesz zmienić sposób, w jaki odbiorca widzi obiekt. Nie zmienia to geometrii 2D kształtu na slajdzie. Zmienia to punkt widzenia 3D używany przez PowerPoint i Aspose.Slides podczas renderowania.

## **Dodaj ekstruzję i głębokość**

Ekstruzja sprawia, że kształt wygląda na gruby, rozciągając go za przednią powierzchnią. W PowerPoint kontrolka głębokości ustawia tę widoczną grubość, a kontrolka koloru określa kolor boków.

![Kontrolki głębokości PowerPoint powiązane z właściwościami koloru ekstruzji i wysokości ekstruzji](img_02_02.png)

Ustaw [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/extrusionheight) dla grubości i [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/extrusioncolor) dla koloru boków:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

Użyj [IThreeDFormat.Depth](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/depth), gdy potrzebujesz bezpośrednio pracować z wartością głębokości PowerPoint lub połączyć głębokość z fazetem, materiałem i efektami tekstu. W wielu scenariuszach kształtów `ExtrusionHeight` jest bardziej przejrzystym ustawieniem, ponieważ bezpośrednio określa widoczną ekstruzję.

## **Użyj wypełnień gradientowych lub obrazów z efektami 3D**

Formatowanie 3D jest niezależne od wypełnienia kształtu. Możesz zastosować jednolity kolor, gradient, wzór lub wypełnienie obrazem na przedniej powierzchni i nadal używać tych samych ustawień kamery, światła, materiału i ekstruzji.

Ten przykład stosuje wypełnienie gradientowe do kształtu i ciemniejszy kolor ekstruzji na bokach:

```csharp
using System.Drawing;
using Aspose.Slides;

const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.TextFrame.Text = "3D Gradient";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

shape.FillFormat.FillType = FillType.Gradient;
shape.FillFormat.GradientFormat.GradientStops.Add(0, Color.Blue);
shape.FillFormat.GradientFormat.GradientStops.Add(100, Color.Orange);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("gradient_3d.png");
```

Wyrenderowany wynik zachowuje gradient na przedniej powierzchni i renderuje ekstruzję oddzielnie:

![Wyrenderowany prostokąt 3D z wypełnieniem gradientowym od niebieskiego do pomarańczowego oraz pomarańczową ekstruzją](img_02_03.png)

Aby zamiast tego użyć wypełnienia obrazem, dodaj obraz do prezentacji i przypisz go jako wypełnienie kształtu:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

![Wyrenderowany prostokąt 3D z wypełnieniem zdjęciem na przedniej powierzchni i pomarańczową ekstruzją](img_02_04.png)

## **Zastosuj formatowanie 3D do tekstu**

Formatowanie 3D kształtu wpływa na ciało kształtu. Formatowanie 3D tekstu wpływa na ramkę tekstową. Jest to przydatne przy efektach podobnych do WordArt, gdzie same litery wymagają ekstruzji, materiału, oświetlenia i ustawień kamery.

Poniższy przykład tworzy tekst z wypełnieniem wzorem, stosuje przekształcenie WordArt i konfiguruje ustawienia 3D na [ITextFrameFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframeformat):

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Text = "3D Text";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.LargeGrid;

shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 128;

var textFrameFormat = shape.TextFrame.TextFrameFormat;
textFrameFormat.Transform = TextShapeType.ArchUp;
textFrameFormat.ThreeDFormat.ExtrusionHeight = 3.5f;
textFrameFormat.ThreeDFormat.Depth = 3;
textFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;
textFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
textFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
textFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);
textFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("text_3d.png");

presentation.Save("text_3d.pptx", SaveFormat.Pptx);
```

![Wyrenderowany tekst 3D z wygiętym przekształceniem WordArt, pomarańczowym wypełnieniem wzorem i ciemną ekstruzją](img_02_05.png)

## **Zachowanie eksportu i renderowania**

Aspose.Slides zachowuje formatowanie 3D przy zapisywaniu w formatach PowerPoint, takich jak PPTX. Podczas renderowania lub eksportu do formatów o stałym układzie, scena 3D jest rasteryzowana lub rysowana w wyjściu jako wynik 2D. Dotyczy to, gdy renderujesz slajdy do [PNG](/slides/pl/net/convert-powerpoint-to-png/), eksportujesz do [PDF](/slides/pl/net/convert-powerpoint-to-pdf/), eksportujesz do [HTML](/slides/pl/net/convert-powerpoint-to-html/), lub generujesz klatki dla [video conversion](/slides/pl/net/convert-powerpoint-to-video/).

- Wyeksportowane obrazy i PDFy nie są interaktywne. Obiekt nie może być obracany przez odbiorcę po eksporcie.
- Ostateczny wygląd zależy od kombinacji kamery, zestawu świateł, materiału, ekstruzji, wypełnienia i skalowania slajdu.
- Jeśli potrzebujesz sprawdzić odziedziczone lub oparte na temacie wartości formatowania, przeczytaj [efektywne właściwości kształtu](/slides/pl/net/shape-effective-properties/).
- Niektóre formaty wyjściowe nie mogą przechowywać edytowalnego formatowania 3D PowerPoint. W tych formatach wynik wizualny jest renderowany, a nie zachowywany jako edytowalne ustawienia 3D.

## **FAQ**

### Czy Aspose.Slides może tworzyć interaktywne prezentacje 3D?

Aspose.Slides tworzy i renderuje efekty 3D PowerPoint dla kształtów i tekstu. Nie tworzy interaktywnych scen 3D w wyeksportowanych obrazach, PDFach ani stronach HTML, które odbiorca mógłby obracać. W PPTX formatowanie 3D pozostaje edytowalne w PowerPoint, jeśli format je obsługuje.

### Jaka jest różnica między modelem 3D a efektem 3D?

Model 3D to oddzielny obiekt 3D wstawiany do prezentacji. Efekt 3D to formatowanie zastosowane do zwykłego kształtu lub tekstu w PowerPoint, takie jak obrót, ekstruzja, fazet, oświetlenie i materiał. Ten artykuł opisuje efekty 3D.

### Jakie ustawienia są wymagane dla widocznego kształtu 3D?

Minimalnie należy ustawić obrót kamery oraz ekstruzję lub głębokość. W praktyce warto także ustawić zestaw świateł i materiał, aby renderowane powierzchnie miały wyraźne podświetlenia i cienie.

### Czy mogę zastosować efekty 3D zarówno do kształtów, jak i tekstu?

Tak. Użyj [IShape.ThreeDFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/properties/threedformat) dla ciała kształtu oraz [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframeformat/properties/threedformat) dla tekstu.

### Czy efekty 3D pojawią się przy eksporterze do obrazów, PDF, HTML lub klatek wideo?

Tak. Aspose.Slides renderuje efekty 3D podczas tworzenia obrazów slajdów, wyjścia PDF, wyjścia HTML oraz klatek używanych przy konwersji wideo. Wyeksportowany wynik zawiera wyrenderowany wygląd, a nie edytowalny obiekt 3D.

### Czy mogę odczytać ostateczne wartości 3D po zastosowaniu dziedziczenia i ustawień motywu?

Tak. Użyj API formatowania efektywnego opisanego w [Efektywne właściwości kształtu](/slides/pl/net/shape-effective-properties/), aby odczytać ostateczne wartości kamery, zestawu świateł, fazetu i powiązane wartości 3D.