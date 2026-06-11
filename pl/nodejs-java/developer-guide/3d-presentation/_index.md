---
title: Tworzenie efektów 3D w prezentacjach przy użyciu Node.js
linktitle: Prezentacja 3D
type: docs
weight: 232
url: /pl/nodejs-java/3d-presentation/
keywords:
- PowerPoint 3D
- prezentacja 3D
- obrót 3D
- głębokość 3D
- wyciąganie 3D
- gradient 3D
- tekst 3D
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Zastosuj i renderuj efekty 3D dla kształtów i tekstu PowerPoint w Node.js przy użyciu Aspose.Slides. Skonfiguruj kamerę, oświetlenie, materiał, wyciąganie, wypełnienia oraz tekst 3D."
---
## **Przegląd**

Aspose.Slides for Node.js via Java może tworzyć, edytować, zachowywać i renderować formatowanie 3D w stylu PowerPoint dla kształtów i tekstu. Ten artykuł opisuje efekty 3D, takie jak obrót, wyciąganie, fazowanie, oświetlenie, materiały, wypełnienia gradientowe lub obrazkowe oraz tekst 3D.

{{% alert color="primary" %}}
Ten artykuł dotyczy efektów formatowania 3D na kształtach i tekście w PowerPoint. Nie dotyczy wstawiania ani edytowania samodzielnych plików modeli 3D. Kiedy eksportujesz slajd do obrazu, PDF lub HTML, Aspose.Slides renderuje te efekty 3D w wyjściowym 2D.
{{% /alert %}}

## **Koncepcje formatowania 3D**

Użyj [Shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/).`getThreeDFormat()`, aby zastosować formatowanie 3D do kształtu. Zwrócony obiekt [ThreeDFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/threedformat/) kontroluje scenę 3D dla tego kształtu.

Dla tekstu użyj [TextFrameFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframeformat/).`getThreeDFormat()`. To stosuje formatowanie 3D do ramki tekstowej, a nie do ciała kształtu.

Najważniejsze członki API:

| Członek API | Co kontroluje | Kiedy używać |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/threedformat/#getCamera) | Punkt widzenia, typ kamery wstępnie ustawiony, obrót, powiększenie i perspektywa. | Obróć obiekt w przestrzeni 3D lub dopasuj do wstępnie ustawionego obrotu 3D w PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/threedformat/#getLightRig) | Ustawienia światła, kierunek i obrót światła. | Zmień sposób wyświetlania podświetleń i cieni na powierzchni 3D. |
| [getMaterial](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/threedformat/#getMaterial) i [setMaterial](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/threedformat/#setMaterial) | Materiał powierzchni, np. płaski, matowy, plastikowy lub metalowy. | Spraw, by ta sama geometria wyglądała na bardziej płaską, miękką, błyszczącą lub metaliczną. |
| [getExtrusionHeight](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) i [setExtrusionHeight](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | Jak daleko kształt wystaje w tył od swojej przedniej powierzchni. | Przekształć płaski kształt w widocznie gruby obiekt 3D. |
| [getExtrusionColor](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | Kolor wyciągniętych boków. | Uczyń głębokość widoczną lub dopasuj kolor boków do wypełnienia przedniej części. |
| [getDepth](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/threedformat/#getDepth) i [setDepth](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/threedformat/#setDepth) | Dodatkowa głębokość 3D używana w formatowaniu 3D PowerPoint. | Dopracuj głębokość dla kształtów lub tekstu, szczególnie wraz z ustawieniami fazowania i materiału. |
| [getBevelTop](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/threedformat/#getBevelTop) i [getBevelBottom](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | Podniesione lub zaokrąglone krawędzie na przednich i tylnych powierzchniach. | Dodaj zmiękczony lub formowany brzeg zamiast ostrej, płaskiej powierzchni. |
| [getContourColor](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/threedformat/#getContourWidth) i [setContourWidth](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/threedformat/#setContourWidth) | Obrys wokół obiektu 3D. | Podkreśl granicę obiektu w renderowanym wyniku. |

## **Utwórz kształt 3D**

Kształt zazwyczaj wymaga czterech rodzajów ustawień, aby wyglądał przekonująco 3D:

- Ustawienia kamery, ponieważ domyślny widok z przodu może ukrywać wyciągnięcie.
- Ustawienia światła, ponieważ oświetlenie umożliwia odczytanie twarzy i boków.
- Ustawienia materiału, ponieważ powierzchnia wpływa na sposób renderowania światła.
- Ustawienia wyciągania lub głębokości, ponieważ płaski kształt potrzebuje grubości.

Poniższy przykład tworzy prostokąt, dodaje do jego przedniej powierzchni tekst, stosuje formatowanie 3D, zapisuje prezentację jako PPTX i renderuje slajd do obrazu PNG.

```javascript
const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(blueColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(blueColor);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Renderowany obraz slajdu pokazuje prostokąt jako gruby blok 3D:

![Renderowany niebieski prostokąt 3D z białym tekstem 3D na przedniej powierzchni](img_01_01.png)

## **Obróć kształt kamerą**

W PowerPoint obrót 3D konfiguruje się w panelu „3‑D Rotation”. Wartości obrotu X, Y i Z odpowiadają obrotowi ustawianemu przez API kamery.

![Panel PowerPoint 3‑D Rotation z podświetlonymi wartościami obrotu X, Y i Z](img_02_01.png)

W Aspose.Slides ustaw typ kamery i obrót poprzez format 3D zwrócony przez `shape.getThreeDFormat()`:

```javascript
shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

Użyj kamery, gdy musisz zmienić sposób, w jaki widz widzi obiekt. Nie zmienia to geometrii 2D kształtu na slajdzie. Zmienia punkt widzenia 3D używany przez PowerPoint i przez Aspose.Slides podczas renderowania.

## **Dodaj wyciąganie i głębokość**

Wyciąganie sprawia, że kształt wygląda na gruby, wydłużając go za przednią powierzchnią. W PowerPoint kontrolka głębokości ustawia tę widzialną grubość, a kontrolka koloru ustawia kolor bocznych powierzchni.

![Kontrolki głębokości w PowerPoint powiązane z właściwościami koloru wyciągania i wysokości wyciągania](img_02_02.png)

Ustaw wysokość wyciągania dla grubości i kolor wyciągania dla koloru boków:

```javascript
const extrusionColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

Użyj ustawienia głębokości, gdy musisz pracować bezpośrednio z wartością głębokości PowerPoint lub łączyć głębokość z fazowaniem, materiałem i efektami tekstu. W wielu scenariuszach kształtu wysokość wyciągania jest jaśniejszym ustawieniem, ponieważ bezpośrednio określa widzialne wyciągnięcie.

## **Użyj wypełnień gradientowych lub obrazkowych z efektami 3D**

Formatowanie 3D jest niezależne od wypełnienia kształtu. Możesz zastosować jednolity kolor, gradient, wzór lub wypełnienie obrazkiem do przedniej powierzchni i nadal używać tych samych ustawień kamery, światła, materiału i wyciągania.

Ten przykład stosuje wypełnienie gradientowe do kształtu i ciemniejszy kolor wyciągania po bokach:

```javascript
const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");
    const orangeColor = java.getStaticFieldValue("java.awt.Color", "ORANGE");
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, blueColor);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, orangeColor);

    const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(darkOrangeColor);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

Renderowany wynik zachowuje gradient na przedniej powierzchni i renderuje wyciąganie oddzielnie:

![Renderowany prostokąt 3D z gradientem niebiesko‑pomarańczowym i pomarańczowym wyciągnięciem](img_02_03.png)

Aby użyć wypełnienia obrazkiem, dodaj obraz do prezentacji i przypisz go jako wypełnienie kształtu:

```javascript
const sourceImage = aspose.slides.Images.fromFile("image.jpg");
let presentationImage;
try {
    presentationImage = presentation.getImages().addImage(sourceImage);
} finally {
    sourceImage.dispose();
}

shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(presentationImage);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(darkOrangeColor);
```

Obraz jest renderowany na przedniej powierzchni, a wyciąganie jest renderowane jako powierzchnia boczna 3D:

![Renderowany prostokąt 3D z wypełnieniem zdjęciem na przedniej powierzchni i pomarańczowym wyciągnięciem](img_02_04.png)

## **Zastosuj formatowanie 3D do tekstu**

Formatowanie 3D kształtu wpływa na ciało kształtu. Formatowanie 3D tekstu wpływa na ramkę tekstową. Jest to przydatne w efektach podobnych do WordArt, gdzie same litery potrzebują wyciągnięcia, materiału, oświetlenia i ustawień kamery.

Poniższy przykład tworzy tekst z wypełnieniem wzorem, stosuje transformację WordArt i konfiguruje ustawienia 3D na [TextFrameFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframeformat/):

```javascript
const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().setText("3D Text");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    const whiteColor = java.getStaticFieldValue("java.awt.Color", "WHITE");
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrangeColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(whiteColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.LargeGrid));

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    const textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(java.newByte(aspose.slides.TextShapeType.ArchUp));
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Tekst jest renderowany jako zakrzywione, wyciągnięte liternictwo 3D:

![Renderowany tekst 3D z łukowatą transformacją WordArt, pomarańczowym wypełnieniem wzorem i ciemnym wyciągnięciem](img_02_05.png)

## **Zachowanie przy eksporcie i renderowaniu**

Aspose.Slides zachowuje formatowanie 3D przy zapisie do formatów PowerPoint, takich jak PPTX. Przy renderowaniu lub eksporcie do formatów o stałym układzie scena 3D jest rasteryzowana lub rysowana w wyjściu jako wynik 2D. Dotyczy to renderowania slajdów do [PNG](/slides/pl/nodejs-java/convert-powerpoint-to-png/), eksportu do [PDF](/slides/pl/nodejs-java/convert-powerpoint-to-pdf/), eksportu do [HTML](/slides/pl/nodejs-java/convert-powerpoint-to-html/), lub generowania klatek do [konwersji wideo](/slides/pl/nodejs-java/convert-powerpoint-to-video/).

Pamiętaj o następujących punktach:

- Wyeksportowane obrazy i pliki PDF nie są interaktywne. Obiekt nie może być obracany przez widza po eksporcie.
- Ostateczny wygląd zależy od połączenia kamery, zestawu świateł, materiału, wyciągania, wypełnienia i skalowania slajdu.
- Jeśli potrzebujesz sprawdzić odziedziczone lub oparte na motywie wartości formatowania, odczytaj [efektywne właściwości kształtu](/slides/pl/nodejs-java/shape-effective-properties/).
- Niektóre formaty wyjściowe nie mogą przechowywać edytowalnego formatowania 3D PowerPoint. W takich formatach wynik wizualny jest renderowany, a nie zachowywany jako edytowalne ustawienia 3D.

## **FAQ**

**Czy Aspose.Slides może tworzyć interaktywne prezentacje 3D?**

Aspose.Slides tworzy i renderuje efekty 3D PowerPoint dla kształtów i tekstu. Nie sprawia, że wyeksportowane obrazy, PDF‑y ani strony HTML są interaktywnymi scenami 3D, które widz może obracać. W PPTX formatowanie 3D pozostaje edytowalne w PowerPoint, o ile format to umożliwia.

**Jaka jest różnica między modelem 3D a efektem 3D?**

Model 3D to oddzielny obiekt 3D wstawiany do prezentacji. Efekt 3D to formatowanie zastosowane do standardowego kształtu lub tekstu PowerPoint, takie jak obrót, wyciąganie, fazowanie, oświetlenie i materiał. Ten artykuł opisuje właśnie efekty 3D.

**Jakie ustawienia są wymagane, aby kształt był widocznie 3D?**

Co najmniej ustaw obrót kamery oraz wyciąganie lub głębokość. W praktyce warto także ustawić zestaw świateł i materiał, aby wyrenderowane powierzchnie miały wyraźne podświetlenia i cienie.

**Czy mogę zastosować efekty 3D zarówno do kształtów, jak i do tekstu?**

Tak. Użyj [Shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/).`getThreeDFormat()` dla ciała kształtu oraz [TextFrameFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframeformat/).`getThreeDFormat()` dla tekstu.

**Czy efekty 3D pojawią się przy eksporcie do obrazów, PDF, HTML lub klatek wideo?**

Tak. Aspose.Slides renderuje efekty 3D przy tworzeniu obrazów slajdów, wyjścia PDF, wyjścia HTML oraz klatek używanych przy konwersji wideo. Wyeksportowany wynik zawiera renderowany wygląd, a nie edytowalny obiekt 3D.

**Czy mogę odczytać ostateczne wartości 3D po zastosowaniu dziedziczenia i motywu?**

Tak. Użyj API efektywnego formatowania opisanego w [Shape Effective Properties](/slides/pl/nodejs-java/shape-effective-properties/), aby odczytać końcowe wartości kamery, zestawu świateł, fazowania i powiązane wartości 3D.