---
title: Tworzenie efektów 3D w prezentacjach przy użyciu .NET
linktitle: Prezentacja 3D
type: docs
weight: 232
url: /pl/net/3d-presentation/
keywords:
- PowerPoint 3D
- Prezentacja 3D
- Obrót 3D
- Głębokość 3D
- Ekstruzja 3D
- Gradient 3D
- Tekst 3D
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Zastosuj i renderuj efekty 3D dla kształtów i tekstu w PowerPoint w .NET przy użyciu Aspose.Slides. Skonfiguruj kamerę, oświetlenie, materiał, ekstruzję, wypełnienia oraz tekst 3D."
---
## **Przegląd**

Aspose.Slides for .NET może tworzyć, edytować, zachowywać i renderować formatowanie 3D w stylu PowerPoint dla kształtów i tekstu. Ten artykuł opisuje efekty 3D, takie jak obrót, ekstruzja, sfazowania, oświetlenie, materiał, wypełnienia gradientowe lub obrazowe oraz tekst 3D.

{{% alert color="primary" %}}
Ten artykuł dotyczy efektów formatowania 3D na kształtach i tekście w PowerPoint. Nie dotyczy wstawiania ani edytowania oddzielnych plików modeli 3D. Kiedy eksportujesz slajd do obrazu, PDF lub HTML, Aspose.Slides renderuje te efekty 3D w wyjściowym 2D.
{{% /alert %}}

## **Koncepcje formatowania 3D**

Użyj właściwości [IShape.ThreeDFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/properties/threedformat), aby zastosować formatowanie 3D do kształtu. Właściwość udostępnia [IThreeDFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat), które kontroluje scenę 3D dla tego kształtu.

Dla tekstu użyj właściwości [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframeformat/properties/threedformat). Stosuje ona formatowanie 3D do ramki tekstowej, a nie do ciała kształtu.

Najważniejsze właściwości to:

| Właściwość | Co kontroluje | Kiedy używać |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/camera) | Punkt widzenia, wstępnie ustawiony typ kamery, obrót, przybliżenie i perspektywa. | Obróć obiekt w przestrzeni 3D lub dopasuj do wstępnie ustawionego obrotu 3D w PowerPoint. |
| [LightRig](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/lightrig) | Ustawienia światła, kierunek i obrót światła. | Zmień wygląd podświetleń i cieni na powierzchni 3D. |
| [Material](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/material) | Materiał powierzchni, np. płaski, matowy, plastikowy lub metalowy. | Spraw, aby ta sama geometria wyglądała bardziej płasko, miękko, błyszcząco lub metalicznie. |
| [ExtrusionHeight](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/extrusionheight) | Jak daleko kształt wystaje w tył od swojej przedniej powierzchni. | Przekształć płaski kształt w widocznie gruby obiekt 3D. |
| [ExtrusionColor](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Kolor wyciągniętych boków. | Uwydatnij głębokość lub dopasuj kolor boków do wypełnienia przedniej części. |
| [Depth](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/depth) | Dodatkowa głębokość 3D używana przez formatowanie 3D w PowerPoint. | Dostosuj precyzyjnie głębokość kształtów lub tekstu, szczególnie wraz z ustawieniami sfazowania i materiału. |
| [BevelTop](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/beveltop) i [BevelBottom](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/bevelbottom) | Wzniesione lub zaokrąglone krawędzie na przedniej i tylnej powierzchni. | Dodaj zmiękczony lub formowany brzeg zamiast ostrym płaskim. |
| [ContourColor](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/contourcolor) i [ContourWidth](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/contourwidth) | Obrys wokół obiektu 3D. | Podkreśl granicę obiektu w renderowanym wyniku. |

## **Utwórz kształt 3D**

Zazwyczaj kształt wymaga czterech rodzajów ustawień, aby wyglądał wiarygodnie 3D:

- Ustawienia kamery, ponieważ domyślny widok z przodu może ukrywać ekstruzję.
- Ustawienia światła, ponieważ oświetlenie sprawia, że twarze i boki są czytelne.
- Ustawienia materiału, ponieważ powierzchnia wpływa na sposób renderowania światła.
- Ustawienia ekstruzji lub głębokości, ponieważ płaski kształt potrzebuje grubości.

Poniższy przykład tworzy prostokąt, dodaje tekst do jego przedniej powierzchni, stosuje formatowanie 3D, zapisuje prezentację jako PPTX i renderuje slajd do obrazu PNG.

```csharp
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

Renderowany obraz slajdu pokazuje prostokąt jako gruby blok 3D:

![Renderowany niebieski prostokąt 3D z białym tekstem 3D na przedniej powierzchni](img_01_01.png)

## **Obróć kształt za pomocą kamery**

W PowerPoint rotacja 3D jest konfigurowana w panelu Obrót 3D. Wartości rotacji X, Y i Z odpowiadają obrotowi ustawionemu za pomocą interfejsu API kamery.

![Panel Obrót 3D w PowerPoint z podświetlonymi wartościami rotacji X, Y i Z](img_02_01.png)

W Aspose.Slides ustaw typ kamery i obrót za pomocą [IThreeDFormat.Camera](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/camera):

```csharp
shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Użyj kamery, gdy musisz zmienić sposób, w jaki widz postrzega obiekt. Nie zmienia to geometrii kształtu 2D na slajdzie. Zmienia to punkt widzenia 3D używany przez PowerPoint i Aspose.Slides podczas renderowania.

## **Dodaj ekstruzję i głębokość**

Ekstruzja sprawia, że kształt wygląda na gruby, wydłużając go za przednią powierzchnią. W PowerPoint kontrolka głębokości określa tę widoczną grubość, a kontrolka koloru ustawia kolor boków.

![Kontrolki głębokości w PowerPoint powiązane z właściwościami koloru ekstruzji i wysokości ekstruzji](img_02_02.png)

Ustaw [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/extrusionheight) dla grubości i [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/extrusioncolor) dla koloru boków:

```csharp
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

Użyj [IThreeDFormat.Depth](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/depth), gdy musisz pracować bezpośrednio z wartością głębokości w PowerPoint lub łączyć głębokość z sfazowaniem, materiałem i efektami tekstu. W wielu scenariuszach kształtów `ExtrusionHeight` jest przejrzystszym ustawieniem, ponieważ bezpośrednio określa widoczną ekstruzję.

## **Użyj wypełnień gradientowych lub obrazowych z efektami 3D**

Formatowanie 3D jest niezależne od wypełnienia kształtu. Możesz zastosować jednolity kolor, gradient, wzór lub wypełnienie obrazem na przedniej powierzchni i nadal używać tych samych ustawień kamery, światła, materiału i ekstruzji.

Ten przykład stosuje wypełnienie gradientowe do kształtu i ciemniejszy kolor ekstruzji na bokach:

```csharp
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

Renderowany wynik zachowuje gradient na przedniej powierzchni i renderuje ekstruzję osobno:

![Renderowany prostokąt 3D z gradientem od niebieskiego do pomarańczowego i pomarańczową ekstruzją](img_02_03.png)

Aby użyć wypełnienia obrazem, dodaj obraz do prezentacji i przypisz go jako wypełnienie kształtu:

```csharp
var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

Obraz jest renderowany na przedniej powierzchni, podczas gdy ekstruzja jest renderowana jako 3D powierzchnia boczna:

![Renderowany prostokąt 3D z wypełnieniem zdjęciem na przedniej powierzchni i pomarańczową ekstruzją](img_02_04.png)

## **Zastosuj formatowanie 3D do tekstu**

Formatowanie 3D kształtu wpływa na ciało kształtu. Formatowanie 3D tekstu wpływa na ramkę tekstową. Jest to przydatne dla efektów podobnych do WordArt, gdzie same litery potrzebują ekstruzji, materiału, oświetlenia i ustawień kamery.

Poniższy przykład tworzy tekst z wypełnieniem wzorem, stosuje transformację WordArt i konfiguruje ustawienia 3D na [ITextFrameFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframeformat):

```csharp
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

Tekst jest renderowany jako zakrzywione, ekstruzowane litery 3D:

![Renderowany tekst 3D z zakrzywioną transformacją WordArt, pomarańczowym wypełnieniem wzorem i ciemną ekstruzją](img_02_05.png)

## **Zachowanie podczas eksportu i renderowania**

Aspose.Slides zachowuje formatowanie 3D przy zapisywaniu w formatach PowerPoint, takich jak PPTX. Podczas renderowania lub eksportu do formatów o stałym układzie, scena 3D jest rasteryzowana lub rysowana do wyniku jako 2D. Dotyczy to renderowania slajdów do [PNG](/slides/pl/net/convert-powerpoint-to-png/), eksportu do [PDF](/slides/pl/net/convert-powerpoint-to-pdf/), eksportu do [HTML](/slides/pl/net/convert-powerpoint-to-html/), lub generowania klatek do [konwersji wideo](/slides/pl/net/convert-powerpoint-to-video/).

Pamiętaj o następujących kwestiach:

- Eksportowane obrazy i pliki PDF nie są interaktywne. Obiekt nie może być obracany przez widza po eksporcie.
- Ostateczny wygląd zależy od kombinacji kamery, zestawu świateł, materiału, ekstruzji, wypełnienia i skalowania slajdu.
- Jeśli potrzebujesz sprawdzić dziedziczone lub oparte na motywie wartości formatowania, przeczytaj [efektywne właściwości kształtu](/slides/pl/net/shape-effective-properties/).
- Niektóre formaty wyjściowe nie mogą przechowywać edytowalnego formatowania 3D PowerPoint. W tych formatach wynik wizualny jest renderowany, a nie zachowywany jako edytowalne ustawienia 3D.

## **FAQ**

**Czy Aspose.Slides może tworzyć interaktywne prezentacje 3D?**

Aspose.Slides tworzy i renderuje efekty 3D PowerPoint dla kształtów i tekstu. Nie zamienia eksportowanych obrazów, plików PDF ani stron HTML w interaktywne sceny 3D, które widz mógłby obracać. W formacie PPTX formatowanie 3D pozostaje edytowalne w PowerPoint, jeśli format to obsługuje.

**Jaka jest różnica między modelem 3D a efektem 3D?**

Model 3D to oddzielny obiekt 3D wstawiany do prezentacji. Efekt 3D to formatowanie zastosowane do zwykłego kształtu lub tekstu PowerPoint, takie jak obrót, ekstruzja, sfazowanie, oświetlenie i materiał. Ten artykuł opisuje efekty 3D.

**Jakie ustawienia są wymagane, aby kształt 3D był widoczny?**

Co najmniej należy ustawić obrót kamery oraz ekstruzję lub głębokość. W praktyce warto także ustawić zestaw świateł i materiał, aby renderowane powierzchnie miały wyraźne podświetlenia i cienie.

**Czy mogę zastosować efekty 3D zarówno do kształtów, jak i do tekstu?**

Tak. Użyj [IShape.ThreeDFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/properties/threedformat) dla ciała kształtu oraz [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframeformat/properties/threedformat) dla tekstu.

**Czy efekty 3D pojawią się przy eksporcie do obrazów, PDF, HTML lub klatek wideo?**

Tak. Aspose.Slides renderuje efekty 3D przy tworzeniu obrazów slajdów, wyjścia PDF, wyjścia HTML i klatek używanych do konwersji wideo. Wyeksportowany wynik zawiera renderowany wygląd, a nie edytowalny obiekt 3D.

**Czy mogę odczytać ostateczne wartości 3D po zastosowaniu dziedziczenia i ustawień motywu?**

Tak. Skorzystaj z efektywnych interfejsów API formatowania opisanych w [Shape Effective Properties](/slides/pl/net/shape-effective-properties/), aby odczytać ostateczne wartości kamery, zestawu świateł, sfazowania i powiązane wartości 3D.