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

Aspose.Slides for .NET może tworzyć, edytować, zachowywać i renderować formatowanie 3D w stylu PowerPoint dla kształtów i tekstu. Ten artykuł opisuje efekty 3D, takie jak obrót, ekstruzja, fazowanie, oświetlenie, materiał, wypełnienie gradientem lub obrazem oraz tekst 3D.

{{% alert color="info" title="Uwaga" %}}
Ten artykuł dotyczy efektów formatowania 3D na kształtach i tekście w PowerPoint. Nie chodzi o wstawianie lub edytowanie samodzielnych plików modeli 3D. Gdy eksportujesz slajd do obrazu, PDF lub HTML, Aspose.Slides renderuje te efekty 3D do wyeksportowanego wyjścia 2D.
{{% /alert %}}

## **Koncepcje formatowania 3D**

Użyj właściwości [IShape.ThreeDFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/properties/threedformat), aby zastosować formatowanie 3D do kształtu. Właściwość udostępnia [IThreeDFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat), który kontroluje scenę 3D dla tego kształtu.

Dla tekstu użyj właściwości [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframeformat/properties/threedformat). To zastosuje formatowanie 3D do ramki tekstowej zamiast do korpusu kształtu.

Najważniejsze właściwości to:

| Właściwość | Co kontroluje | Kiedy używać |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/camera) | Punkt widzenia, wstępny typ kamery, obrót, zoom i perspektywa. | Obróć obiekt w przestrzeni 3D lub dopasuj do wstępnego obrotu 3D w PowerPoint. |
| [LightRig](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/lightrig) | Wstępne oświetlenie, kierunek i obrót światła. | Zmodyfikuj, jak podświetlenia i cienie pojawiają się na powierzchni 3D. |
| [Material](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/material) | Materiał powierzchni, np. płaski, matowy, plastikowy lub metaliczny. | Spraw, aby ta sama geometria wyglądała płasko, miękko, błyszcząco lub metalicznie. |
| [ExtrusionHeight](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/extrusionheight) | Jak daleko kształt wystaje w tył od swojej przedniej powierzchni. | Przekształć płaski kształt w widocznie gruby obiekt 3D. |
| [ExtrusionColor](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Kolor ekstruzowanych boków. | Uwidocznij głębokość lub dopasuj kolor boków do przedniego wypełnienia. |
| [Depth](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/depth) | Dodatkowa głębokość 3D używana przez formatowanie 3D w PowerPoint. | Dostosuj głębokość kształtów lub tekstu, szczególnie razem z ustawieniami fazowania i materiału. |
| [BevelTop](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/beveltop) i [BevelBottom](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/bevelbottom) | Podniesione lub zaokrąglone krawędzie na przedniej i tylnej powierzchni. | Dodaj miękką lub formowaną krawędź zamiast ostrej, płaskiej powierzchni. |
| [ContourColor](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/contourcolor) i [ContourWidth](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/contourwidth) | Kontur wokół obiektu 3D. | Podkreśl granicę obiektu w renderowanym wyjściu. |

## **Utworzenie kształtu 3D**

Kształt zazwyczaj wymaga czterech rodzajów ustawień, aby wyglądał wiarygodnie 3D:

- Ustawień kamery, ponieważ domyślny widok z przodu może ukrywać ekstruzję.
- Ustawień światła, ponieważ oświetlenie sprawia, że powierzchnie i boki są czytelne.
- Ustawień materiału, ponieważ powierzchnia wpływa na sposób renderowania światła.
- Ustawień ekstruzji lub głębokości, ponieważ płaski kształt potrzebuje grubości.

Poniższy przykład tworzy prostokąt, dodaje tekst do jego przedniej powierzchni i stosuje formatowanie 3D. Wartości obrotu kamery podane są w stopniach, a wysokość ekstruzji wynosi 100 punktów. Przykład renderuje slajd do obrazu PNG w podwójnych wymiarach domyślnych i zapisuje prezentację jako PPTX.

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

Wyrenderowany obraz slajdu pokazuje prostokąt jako gruby blok 3D:

![Wyrenderowany niebieski prostokąt 3D z białym tekstem 3D na przedniej powierzchni](img_01_01.png)

## **Obrócenie kształtu za pomocą kamery**

W PowerPoint obroty 3D konfiguruje się w panelu **3‑D Rotation**. Wartości obrotu X, Y i Z odpowiadają obrotom ustawionym przez API kamery.

![Panel 3‑D Rotation w PowerPoint z wyróżnionymi wartościami obrotu X, Y i Z](img_02_01.png)

W Aspose.Slides dostęp do kamery uzyskuje się przez [IThreeDFormat.Camera](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/camera). Ten przykład tworzy prostokąt, wybiera ortograficzny widok z przodu i ustawia obroty X, Y i Z na 20, 30 i 40 stopni. Konfiguruje kształt w pamięci, bez zapisywania pliku:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Używaj kamery, gdy musisz zmienić sposób, w jaki obserwator widzi obiekt. Nie zmienia to geometrii 2D kształtu na slajdzie. Modyfikuje ona punkt widzenia 3D używany przez PowerPoint i Aspose.Slides podczas renderowania.

## **Dodanie ekstruzji i głębokości**

Ekstruzja sprawia, że kształt wygląda na gruby, wydłużając go za przednią powierzchnią. W PowerPoint kontrolka głębokości ustawia tę widoczną grubość, a kontrolka koloru ustawia kolor boków.

![Kontrolki głębokości w PowerPoint powiązane z właściwościami ExtrusionColor i ExtrusionHeight](img_02_02.png)

Ustaw [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/extrusionheight) dla grubości oraz [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/extrusioncolor) dla koloru boków. Ten przykład nadaje prostokątowi ekstruzję 100 punktów z fioletowymi bokami i obraca kamerę, aby ukazać grubość. Konfiguruje kształt w pamięci, bez zapisywania pliku:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

Właściwość [IThreeDFormat.Depth](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/depth) ustawia głębokość kształtu 3D. Właściwość [ExtrusionHeight](https://reference.aspose.com/slides/pl/net/aspose.slides/ithreedformat/properties/extrusionheight) kontroluje wysokość efektu ekstruzji, co pokazano w tym przykładzie.

## **Użycie wypełnie gradientem lub obrazem z efektami 3D**

Formatowanie 3D jest niezależne od wypełnienia kształtu. Możesz zastosować jednolity kolor, gradient, wzór lub wypełnienie obrazem na przedniej powierzchni i nadal korzystać z tych samych ustawień kamery, światła, materiału i ekstruzji.

Ten przykład nakłada gradient niebiesko‑pomarańczowy na przednią powierzchnię oraz ciemnopomarańczowy kolor na ekstruzję o wysokości 150 punktów. Punkty gradientu 0 i 100 oznaczają początek i koniec gradientu. Wartości obrotu kamery podane są w stopniach. Slajd renderowany jest do obrazu PNG w podwójnych wymiarach domyślnych:

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

Wyrenderowany wynik zachowuje gradient na przedniej powierzchni i renderuje ekstruzję osobno:

![Wyrenderowany prostokąt 3D z gradientem niebiesko‑pomarańczowym i pomarańczową ekstruzją](img_02_03.png)

Aby użyć wypełnienia obrazem, dodaj obraz do prezentacji i przypisz go jako wypełnienie kształtu. Ten przykład wymaga istniejącego pliku o nazwie "image.jpg" w katalogu roboczym. Rozciąga obraz, aby wypełnić prostokąt, stosuje ekstruzję 150 punktów i ustawia obrót kamery w stopniach. Konfiguruje kształt w pamięci, bez zapisu ani renderowania pliku:

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

Obraz jest renderowany na przedniej powierzchni, podczas gdy ekstruzja renderowana jest jako 3D‑boczna powierzchnia:

![Wyrenderowany prostokąt 3D z wypełnieniem zdjęciem na przedniej powierzchni i pomarańczową ekstruzją](img_02_04.png)

## **Zastosowanie formatowania 3D do tekstu**

Formatowanie 3D kształtu wpływa na korpus kształtu. Formatowanie 3D tekstu wpływa na ramkę tekstową. Jest to przydatne przy efektach typu WordArt, gdzie same litery wymagają ekstruzji, materiału, oświetlenia i ustawień kamery.

Poniższy przykład tworzy tekst z pomarańczowo‑białym wzorem siatki, nakłada łukowaty przekształcenie i konfiguruje ustawienia 3D poprzez [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframeformat/properties/threedformat). Wysokość ekstruzji i głębokość podane są w punktach, a obrót światła w stopniach. Wypełnienie i kontur kształtu ukryte, aby widoczny był tylko tekst. Przykład renderuje obraz PNG w podwójnych wymiarach domyślnych i zapisuje prezentację jako PPTX:

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

Tekst renderowany jest jako zakrzywione, ekstruzowane litery 3D:

![Wyrenderowany tekst 3D z łukowatą transformacją WordArt, wypełnieniem wzorem pomarańczowym i ciemną ekstruzją](img_02_05.png)

## **Utrzymanie tekstu płaskiego na kształcie 3D**

Aby tekst pozostawał czytelny przy zachowaniu wyglądu 3D kształtu, ustaw [ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframeformat/keeptextflat/) przez [ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/textframeformat/). Gdy wartość wynosi `true`, tekst pozostaje poza sceną 3D. Gdy jest `false`, tekst uczestniczy w scenie i podąża za jej orientacją 3D.

To ustawienie nie usuwa formatowania 3D kształtu: jego kamera, oświetlenie, materiał i ekstruzja pozostają skonfigurowane przez [IShape.ThreeDFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/threedformat/). Różni się to również od zwykłego obrotu. [IShape.Rotation](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/rotation/) obraca kształt w płaszczyźnie slajdu, natomiast [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframeformat/rotationangle/) steruje własnym obrotem tekstu w jego prostokącie ograniczającym. Utrzymanie tekstu poza sceną 3D nie resetuje żadnego z tych kątów.

Poniższy samodzielny przykład tworzy niebieski prostokąt z tekstem i klonuje go obok oryginału. Oba kształty mają to samo formatowanie 3D; jedyne różnice to ustawienie tekstu: `false` po lewej i `true` po prawej. Kąty kamery podane są w stopniach, a wysokość ekstruzji wynosi 40 punktów. Przykład zapisuje prezentację jako PPTX i renderuje slajd porównawczy do PNG w podwójnych wymiarach domyślnych.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

shape.TextFrame.Text = "Readable text";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 28;
shape.TextFrame.Paragraphs[0].ParagraphFormat.Alignment = TextAlignment.Center;
shape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Center;
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(30, 30, 0);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 40;
shape.ThreeDFormat.ExtrusionColor.Color = Color.RoyalBlue;
shape.TextFrame.TextFrameFormat.KeepTextFlat = false;

var flatTextShape = (IAutoShape)slide.Shapes.AddClone(shape, 400, 160);
flatTextShape.TextFrame.TextFrameFormat.KeepTextFlat = true;

presentation.Save("keep_text_flat.pptx", SaveFormat.Pptx);
using var image = slide.GetImage(2, 2);
image.Save("keep_text_flat.png");
```

Po lewej tekst podąża za orientacją 3D. Po prawej pozostaje płaski i łatwiejszy do odczytania. Oba prostokąty zachowują tę samą widoczną ekstruzję i orientację 3D.

![Dwa prostokąty 3D obok siebie: KeepTextFlat jest false po lewej i true po prawej](keep_text_flat.png)

## **Zachowanie przy eksporcie i renderowaniu**

Aspose.Slides zachowuje formatowanie 3D przy zapisie do formatów PowerPoint, takich jak PPTX. Przy renderowaniu lub eksporcie do formatów o stałym układzie scena 3D jest rasteryzowana lub rysowana do wyniku jako 2D. Dotyczy to renderowania slajdów do [PNG](/slides/pl/net/convert-powerpoint-to-png/), eksportu do [PDF](/slides/pl/net/convert-powerpoint-to-pdf/), eksportu do [HTML](/slides/pl/net/convert-powerpoint-to-html/), czy generowania klatek do [konwersji wideo](/slides/pl/net/convert-powerpoint-to-video/).

Pamiętaj o następujących kwestiach:

- Wyeksportowane obrazy i PDFy nie są interaktywne. Obiekt nie może być obracany przez widza po eksporcie.
- Ostateczny wygląd zależy od kombinacji kamery, zestawu świateł, materiału, ekstruzji, wypełnienia i skalowania slajdu.
- Jeśli potrzebujesz przejrzeć wartości formatowania odziedziczone lub oparte na motywie, odczytaj [efektywne właściwości kształtu](/slides/pl/net/shape-effective-properties/).
- Niektóre formaty wyjściowe nie mogą przechowywać edytowalnego formatowania 3D PowerPoint. W takich formatach efekt wizualny jest renderowany, a nie zachowywany jako edytowalne ustawienia 3D.

## **FAQ**

**Czy Aspose.Slides może tworzyć interaktywne prezentacje 3D?**

Aspose.Slides tworzy i renderuje efekty 3D PowerPoint dla kształtów i tekstu. Nie sprawia, że wyeksportowane obrazy, PDFy ani strony HTML stają się interaktywnymi scenami 3D, które widz może obracać. W PPTX formatowanie 3D pozostaje edytowalne w PowerPoint, o ile format to obsługuje.

**Jaka jest różnica między modelem 3D a efektem 3D?**

Model 3D to oddzielny obiekt 3D wstawiany do prezentacji. Efekt 3D to formatowanie zastosowane do zwykłego kształtu lub tekstu w PowerPoint, takie jak obrót, ekstruzja, fazowanie, oświetlenie i materiał. Ten artykuł opisuje efekty 3D.

**Jakie ustawienia są wymagane, aby kształt 3D był widoczny?**

Co najmniej ustaw obrót kamery oraz ekstruzję lub głębokość. W praktyce warto także ustawić zestaw świateł i materiał, aby renderowane powierzchnie miały wyraźne podświetlenia i cienie.

**Czy mogę zastosować efekty 3D zarówno do kształtów, jak i do tekstu?**

Tak. Użyj [IShape.ThreeDFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/properties/threedformat) dla korpusu kształtu i [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframeformat/properties/threedformat) dla tekstu.

**Czy efekty 3D pojawią się przy eksporcie do obrazów, PDF, HTML lub klatek wideo?**

Tak. Aspose.Slides renderuje efekty 3D podczas tworzenia obrazów slajdów, wyjścia PDF, wyjścia HTML oraz klatek używanych do konwersji wideo. Wyeksportowane wyjście zawiera renderowany wygląd, a nie edytowalny obiekt 3D.

**Czy mogę odczytać ostateczne wartości 3D po zastosowaniu dziedziczenia i ustawień motywu?**

Tak. Skorzystaj z API efektywnego formatowania opisanych w [Shape Effective Properties](/slides/pl/net/shape-effective-properties/), aby odczytać ostateczne wartości kamery, zestawu świateł, fazowania i powiązane wartości 3D.