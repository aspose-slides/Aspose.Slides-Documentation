---
title: Tworzenie efektów 3D w prezentacjach przy użyciu .NET
linktitle: Prezentacja 3D
type: docs
weight: 232
url: /pl/net/3d-presentation/
keywords:
- 3D PowerPoint
- prezentacja 3D
- obrót 3D
- głębia 3D
- wyextrudowanie 3D
- gradient 3D
- tekst 3D
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Zastosuj i renderuj efekty 3D dla kształtów i tekstu PowerPoint w .NET z Aspose.Slides. Skonfiguruj kamerę, oświetlenie, materiał, wyextrudowanie, wypełnienia i tekst 3D."
---
## **Przegląd**

Aspose.Slides for .NET może tworzyć, edytować, zachowywać i renderować formatowanie 3D w stylu PowerPoint dla kształtów i tekstu. Ten artykuł opisuje efekty 3D takie jak obrót, wyextrudowanie, fazowania, oświetlenie, materiał, wypełnienia gradientowe lub obrazkowe oraz tekst 3D.

{{% alert color="info" title="Note" %}}
Ten artykuł dotyczy efektów formatowania 3D na kształtach i tekście w PowerPoint. Nie dotyczy wstawiania ani edytowania samodzielnych plików modeli 3D. Gdy eksportujesz slajd do obrazu, PDF lub HTML, Aspose.Slides renderuje te efekty 3D w wyjściowym 2D.
{{% /alert %}}

## **Koncepcje formatowania 3D**

Użyj właściwości [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat), aby zastosować formatowanie 3D do kształtu. Właściwość udostępnia [IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat), który steruje sceną 3D dla tego kształtu.

Dla tekstu użyj właściwości [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat). To stosuje formatowanie 3D do ramki tekstowej zamiast do ciała kształtu.

Najważniejsze właściwości to:

| Właściwość | Co kontroluje | Kiedy używać |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) | Punkt widzenia, predefiniowany typ kamery, obrót, powiększenie i perspektywa. | Obróć obiekt w przestrzeni 3D lub dopasuj do presetowego obrotu 3D w PowerPoint. |
| [LightRig](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/lightrig) | Predefiniowane oświetlenie, kierunek i obrót światła. | Zmień wygląd podświetleń i cieni na powierzchni 3D. |
| [Material](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/material) | Materiał powierzchni, np. płaski, matowy, plastikowy lub metalowy. | Spraw, aby ta sama geometria wyglądała bardziej płasko, miękko, błyszcząco lub metalicznie. |
| [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) | Jak daleko kształt rozciąga się w tył od swojej przedniej powierzchni. | Przekształć płaski kształt w widocznie grubą bryłę 3D. |
| [ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Kolor wyextrudowanych boków. | Uwydatnij głębokość lub skoordynuj kolor boków z wypełnieniem przodu. |
| [Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth) | Dodatkowa głębia 3D używana w formatowaniu 3D PowerPoint. | Dostosuj precyzyjnie głębokość kształtów lub tekstu, szczególnie wraz z ustawieniami fazowania i materiału. |
| [BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/beveltop) i [BevelBottom](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/bevelbottom) | Podniesione lub zaokrąglone krawędzie na przedniej i tylnej powierzchni. | Dodaj zmiękczoną lub formowaną krawędź zamiast ostrej płaskiej powierzchni. |
| [ContourColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourcolor) i [ContourWidth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourwidth) | Obrzeże wokół obiektu 3D. | Podkreśl granicę obiektu w renderowanym wyniku. |

## **Utworzenie kształtu 3D**

Kształt zazwyczaj wymaga czterech rodzajów ustawień, aby wyglądał przekonująco 3D:

- Ustawienia kamery, ponieważ domyślny widok frontowy może ukrywać wyextrudowanie.
- Ustawienia światła, ponieważ oświetlenie sprawia, że powierzchnie i boki są czytelne.
- Ustawienia materiału, ponieważ powierzchnia wpływa na sposób renderowania światła.
- Ustawienia wyextrudowania lub głębokości, ponieważ płaski kształt potrzebuje grubości.

Poniższy przykład tworzy prostokąt, dodaje tekst do jego przedniej powierzchni i stosuje formatowanie 3D. Wartości obrotu kamery są podane w stopniach, a wysokość wyextrudowania wynosi 100 punktów. Przykład renderuje slajd do obrazu PNG w podwójnych domyślnych wymiarach i zapisuje prezentację jako PPTX.

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

Renderowany obraz slajdu pokazuje prostokąt jako grubą bryłę 3D:

![Renderowany niebieski prostokąt 3D z białym tekstem 3D na przedniej powierzchni](img_01_01.png)

## **Obrócenie kształtu za pomocą kamery**

W PowerPoint obrócenie 3D konfiguruje się w panelu 3-D Rotation. Wartości obrotu X, Y i Z odpowiadają obrotowi ustawionemu za pomocą API kamery.

![Panel PowerPoint 3‑D Rotation z wyróżnionymi wartościami obrotu X, Y i Z](img_02_01.png)

W Aspose.Slides dostęp do kamery uzyskuje się przez [IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera). Ten przykład tworzy prostokąt, wybiera ortograficzny widok frontowy i ustawia jego obroty X, Y i Z na 20, 30 i 40 stopni odpowiednio. Konfiguruje kształt w pamięci bez zapisywania pliku:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Użyj kamery, gdy potrzebujesz zmienić sposób, w jaki widz widzi obiekt. Nie zmienia to geometrii 2D kształtu na slajdzie. Zmienia to punkt widzenia 3D używany przez PowerPoint i przez Aspose.Slides podczas renderowania.

### **Skopiuj orientację kamery z kształtu szablonu**

Aby dopasować kształt w szablonie, skopiuj jego predefiniowany [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) i odczytaj jego kąty za pomocą [GetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/getrotation/). Przykład otwiera `template.pptx`, odczytuje kamerę z pierwszego kształtu na pierwszym slajdzie i stosuje jego orientację do drugiego kształtu. Oba kształty mają już oświetlenie 3D, a drugi kształt nie ma explicitnego obrotu kamery.

Kąty podane są w stopniach. Indeks `0` to szerokość, indeks `1` to długość, a indeks `2` to obrót. Przekaż je do [SetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/setrotation/) w tej kolejności. Jeśli źródło zwróci `null`, nie ma explicitnego obrotu, więc pozostaw kąty drugiego kształtu nieustawione. Explicitny obrót `(0, 0, 0)` zwraca trzy zera i powinien być skopiowany.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var shapes = presentation.Slides[0].Shapes;

var sourceCamera = shapes[0].ThreeDFormat.Camera;
var destinationCamera = shapes[1].ThreeDFormat.Camera;

destinationCamera.CameraType = sourceCamera.CameraType;
var angles = sourceCamera.GetRotation();
if (angles != null)
{
    destinationCamera.SetRotation(angles[0], angles[1], angles[2]);
}

presentation.Save("camera-copy.pptx", SaveFormat.Pptx);
```

Po ponownym otwarciu `camera-copy.pptx` oba kształty mają ten sam predefiniowany typ kamery i obrót. W PowerPoint strzałka po prawej używa orientacji kamery skopiowanej z prostokąta po lewej. Oba kształty używają tego samego oświetlenia i głębokości wyextrudowania.

![Niebieski prostokąt 3D i strzałka w prawo z dopasowaną orientacją kamery, widziane z góry i z prawej strony](camera-orientation.png)

## **Dodaj wyextrudowanie i głębokość**

Wyextrudowanie sprawia, że kształt wygląda na gruby, wydłużając go za przednią powierzchnię. W PowerPoint kontrola głębokości ustawia tę widoczną grubość, a kontrola koloru ustawia kolor boków.

![Kontrolki głębokości w PowerPoint powiązane z właściwościami koloru wyextrudowania i wysokości wyextrudowania](img_02_02.png)

Ustaw [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) dla grubości i [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) dla koloru boków. Ten przykład nadaje prostokątnemu kształtowi wyextrudowanie o 100 punktów z fioletowymi bokami i obraca kamerę, aby ujawnić jego grubość. Konfiguruje kształt w pamięci bez zapisywania pliku:

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

Właściwość [IThreeDFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth) ustawia głębokość obiektu 3D. Właściwość [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) kontroluje wysokość efektu wyextrudowania, jak pokazano w tym przykładzie.

## **Użycie wypełnień gradientowych lub obrazkowych z efektami 3D**

Formatowanie 3D jest niezależne od wypełnienia kształtu. Możesz zastosować jednolity kolor, gradient, wzór lub wypełnienie obrazkowe na przedniej powierzchni i nadal używać tych samych ustawień kamery, światła, materiału i wyextrudowania.

Ten przykład stosuje gradient od niebieskiego do pomarańczowego na przedniej powierzchni oraz ciemnopomarańczowy kolor dla wyextrudowania o wysokości 150 punktów. Punkty przystankowe gradientu przy 0 i 100 oznaczają początek i koniec gradientu. Wartości obrotu kamery podane są w stopniach. Slajd jest renderowany do obrazu PNG w podwójnych domyślnych wymiarach:

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

![Renderowany prostokąt 3D z wypełnieniem gradientowym od niebieskiego do pomarańczowego oraz pomarańczowym wyextrudowaniem](img_02_03.png)

Aby użyć wypełnienia obrazkowego, dodaj obraz do prezentacji i przypisz go jako wypełnienie kształtu. Ten przykład wymaga istniejącego pliku o nazwie "image.jpg" w katalogu roboczym. Rozciąga obraz, aby wypełnił prostokąt, stosuje wyextrudowanie o wysokości 150 punktów i ustawia obrót kamery w stopniach. Konfiguruje kształt w pamięci bez zapisywania lub renderowania pliku:

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

![Renderowany prostokąt 3D z wypełnieniem zdjęciem na przedniej powierzchni i pomarańczowym wyextrudowaniem](img_02_04.png)

## **Zastosowanie formatowania 3D do tekstu**

Formatowanie 3D kształtu wpływa na ciało kształtu. Formatowanie 3D tekstu wpływa na ramkę tekstową. Jest to przydatne przy efektach podobnych do WordArt, gdzie same litery potrzebują wyextrudowania, materiału, oświetlenia i ustawień kamery.

Poniższy przykład tworzy tekst z pomarańczowo-białym wzorem kratki, stosuje wygięcie w górę i konfiguruje ustawienia 3D poprzez [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat). Wysokość i głębokość wyextrudowania podane są w punktach, a obrót światła w stopniach. Wypełnienie i kontur kształtu są ukryte, aby widoczny był tylko tekst. Przykład renderuje obraz PNG w podwójnych wymiarach slajdu i zapisuje prezentację jako PPTX:

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

![Renderowany tekst 3D z wygięciem WordArt, pomarańczowym wypełnieniem wzorem i ciemnym wyextrudowaniem](img_02_05.png)

## **Utrzymanie tekstu płaskiego na kształcie 3D**

Aby tekst był czytelny przy zachowaniu wyglądu 3D kształtu, ustaw [ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/keeptextflat/) przez [ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframe/textframeformat/). Gdy wartość jest `true`, tekst pozostaje poza sceną 3D. Gdy jest `false`, tekst uczestniczy w scenie i podąża za jej orientacją 3D.

To ustawienie nie usuwa formatowania 3D kształtu: jego kamera, oświetlenie, materiał i wyextrudowanie pozostają skonfigurowane przez [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/threedformat/). Jest to również inne niż zwykły obrót. [IShape.Rotation](https://reference.aspose.com/slides/net/aspose.slides/ishape/rotation/) obraca kształt w płaszczyźnie slajdu, podczas gdy [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) kontroluje własny obrót tekstu w jego ramce. Utrzymanie tekstu poza sceną 3D nie resetuje żadnego z tych kątów.

Poniższy samodzielny przykład tworzy niebieski prostokąt z tekstem i klonuje go obok oryginału. Oba kształty mają takie samo formatowanie 3D; różni się tylko ustawienie tekstu: `false` po lewej i `true` po prawej. Kąty kamery podane są w stopniach, a wysokość wyextrudowania wynosi 40 punktów. Przykład zapisuje prezentację jako PPTX i renderuje slajd porównawczy do PNG w podwójnych domyślnych wymiarach.

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

Po lewej tekst podąża za orientacją 3D. Po prawej pozostaje płaski i łatwiejszy do odczytania. Oba prostokąty zachowują tę samą widoczną głębokość wyextrudowania i orientację 3D.

![Prostokąty 3D obok siebie: KeepTextFlat jest false po lewej i true po prawej](keep_text_flat.png)

## **Zachowanie eksportu i renderingu**

Aspose.Slides zachowuje formatowanie 3D podczas zapisywania w formatach PowerPoint, takich jak PPTX. Przy renderowaniu lub eksporcie do formatów o stałym układzie, scena 3D jest rastrowana lub rysowana w wyjściu jako wynik 2D. Dotyczy to renderowania slajdów do [PNG](/slides/pl/net/convert-powerpoint-to-png/), eksportu do [PDF](/slides/pl/net/convert-powerpoint-to-pdf/), eksportu do [HTML](/slides/pl/net/convert-powerpoint-to-html/), lub generowania klatek do [konwersji wideo](/slides/pl/net/convert-powerpoint-to-video/).

- Wyeksportowane obrazy i pliki PDF nie są interaktywne. Obiekt nie może być obracany przez odbiorcę po eksporcie.
- Ostateczny wygląd zależy od kombinacji kamery, zestawu świateł, materiału, wyextrudowania, wypełnienia i skalowania slajdu.
- Jeśli musisz sprawdzić dziedziczone lub oparte na motywie wartości formatowania, odczytaj [effective shape properties](/slides/pl/net/shape-effective-properties/).
- Niektóre formaty wyjściowe nie mogą przechowywać edytowalnego formatowania 3D PowerPoint. W tych formatach rezultat wizualny jest renderowany, a nie zachowywany jako edytowalne ustawienia 3D.

## **FAQ**

**Czy Aspose.Slides może tworzyć interaktywne prezentacje 3D?**

Aspose.Slides tworzy i renderuje efekty 3D PowerPoint dla kształtów i tekstu. Nie zamienia wyeksportowanych obrazów, plików PDF ani stron HTML w interaktywne sceny 3D, które użytkownik mógłby obracać. W formacie PPTX formatowanie 3D pozostaje edytowalne w PowerPoint, o ile format to umożliwia.

**Jaka jest różnica między modelem 3D a efektem 3D?**

Model 3D to oddzielny obiekt 3D wstawiany do prezentacji. Efekt 3D to formatowanie zastosowane do zwykłego kształtu lub tekstu PowerPoint, takie jak obrót, wyextrudowanie, fazowanie, oświetlenie i materiał. Ten artykuł opisuje efekty 3D.

**Jakie ustawienia są wymagane, aby uzyskać widoczny kształt 3D?**

Co najmniej ustaw obrót kamery oraz wyextrudowanie lub głębokość. W praktyce warto również ustawić zestaw świateł i materiał, aby renderowane powierzchnie miały wyraźne podświetlenia i cienie.

**Czy mogę zastosować efekty 3D zarówno do kształtów, jak i do tekstu?**

Tak. Użyj [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) dla ciała kształtu i [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat) dla tekstu.

**Czy efekty 3D pojawią się przy eksporcie do obrazów, PDF, HTML lub klatek wideo?**

Tak. Aspose.Slides renderuje efekty 3D przy tworzeniu obrazów slajdów, wyjścia PDF, HTML oraz klatek używanych do konwersji wideo. Wyeksportowany wynik zawiera renderowany wygląd, a nie edytowalny obiekt 3D.

**Czy mogę odczytać ostateczne wartości 3D po zastosowaniu dziedziczenia i ustawień motywu?**

Tak. Użyj API formatowania efektywnego opisanych w [Shape Effective Properties](/slides/pl/net/shape-effective-properties/), aby odczytać ostateczne wartości kamery, zestawu świateł, fazowania i powiązane wartości 3D.