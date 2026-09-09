---
title: Tworzenie efektów 3D w prezentacjach przy użyciu Pythona
linktitle: Prezentacja 3D
type: docs
weight: 232
url: /pl/python-java/3d-presentation/
keywords:
- 3D PowerPoint
- prezentacja 3D
- obrót 3D
- głębokość 3D
- wyciągnięcie 3D
- gradient 3D
- tekst 3D
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Zastosuj i renderuj efekty 3D dla kształtów i tekstu PowerPoint w Pythonie przez Java z Aspose.Slides. Konfiguruj kamerę, oświetlenie, materiał, wyciągnięcie, wypełnienia i tekst 3D."
---
## **Przegląd**

Aspose.Slides for Python via Java może tworzyć, edytować, zachowywać i renderować formatowanie 3D w stylu PowerPoint dla kształtów i tekstu. Ten artykuł opisuje efekty 3D, takie jak obrót, wyciągnięcie, fazowanie, oświetlenie, materiał, wypełnienia gradientowe lub obrazkowe oraz tekst 3D.

{{% alert color="info" title="Uwaga" %}}
Ten artykuł dotyczy efektów formatowania 3D na kształtach i tekście w programie PowerPoint. Nie dotyczy wstawiania ani edytowania samodzielnych plików modeli 3D. Gdy eksportujesz slajd do obrazu, PDF lub HTML, Aspose.Slides renderuje te efekty 3D w wyjściowy 2D.
{{% /alert %}}

Zainstaluj pakiet zgodnie z opisem w [Installation](/slides/pl/python-java/installation/). Każdy przykład importuje `asposeslides`, uruchamia JVM w razie potrzeby, a następnie importuje API. Przykład wypełnienia obrazem wymaga pliku `image.jpg` w katalogu roboczym.

## **Koncepcje formatowania 3D**

Użyj [Shape.getThreeDFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getThreeDFormat), aby zastosować formatowanie 3D do kształtu. Zwrócony obiekt formatu kontroluje scenę 3D dla tego kształtu.

Dla tekstu użyj [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/#getThreeDFormat). To stosuje formatowanie 3D do ramki tekstowej zamiast ciała kształtu.

Najważniejsze członki API:

| Członek API | Co kontroluje | Kiedy używać |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#getCamera) | Widok, typ kamery wstępnie ustawiony, rotacja, powiększenie i perspektywa. | Obróć obiekt w przestrzeni 3D lub dopasuj do wstępnie ustawionego obrotu 3D w programie PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#getLightRig) | Ustawienia światła, kierunek i rotacja światła. | Zmień sposób, w jaki podświetlenia i cienie pojawiają się na powierzchni 3D. |
| [getMaterial](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#getMaterial) i [setMaterial](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#setMaterial) | Materiał powierzchni, np. płaski, matowy, plastikowy lub metalowy. | Spraw, aby ta sama geometria wyglądała bardziej płasko, miękko, błyszcząco lub metalicznie. |
| [getExtrusionHeight](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#getExtrusionHeight) i [setExtrusionHeight](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Jak daleko kształt wystaje w tył od swojej przedniej powierzchni. | Przekształć płaski kształt w widocznie grubą bryłę 3D. |
| [getExtrusionColor](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#getExtrusionColor) | Kolor wyciągniętych boków. | Umożliw widoczność głębokości lub dopasuj kolor boków do wypełnienia przedniej powierzchni. |
| [getDepth](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#getDepth) i [setDepth](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#setDepth) | Dodatkowa głębokość 3D używana w formatowaniu 3D programu PowerPoint. | Dostosuj precyzyjnie głębokość dla kształtów lub tekstu, szczególnie w połączeniu z ustawieniami fazowania i materiału. |
| [getBevelTop](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#getBevelTop) i [getBevelBottom](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#getBevelBottom) | Podniesione lub zaokrąglone krawędzie na przedniej i tylnej powierzchni. | Dodaj zmiękczony lub formowany brzeg zamiast ostrej płaskiej powierzchni. |
| [getContourColor](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#getContourWidth) i [setContourWidth](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#setContourWidth) | Obrys wokół obiektu 3D. | Podkreśl granicę obiektu w renderowanym wyjściu. |

## **Utwórz kształt 3D**

Kształt zwykle wymaga czterech rodzajów ustawień, aby wyglądał przekonująco 3D:

- Ustawienia kamery, ponieważ domyślny widok z przodu może ukrywać wyciągnięcie.
- Ustawienia światła, ponieważ oświetlenie sprawia, że powierzchnie i boki są czytelne.
- Ustawienia materiału, ponieważ powierzchnia wpływa na renderowanie światła.
- Ustawienia wyciągnięcia lub głębokości, ponieważ płaski kształt potrzebuje grubości.

Poniższy przykład tworzy prostokąt, dodaje tekst do jego przedniej powierzchni, stosuje formatowanie 3D, zapisuje prezentację jako PPTX i renderuje slajd do obrazu PNG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)
    shape.getTextFrame().setText("3D")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("shape_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("shape_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Renderowany obraz slajdu pokazuje prostokąt jako grubą bryłę 3D:

![Renderowany niebieski prostokąt 3D z białym tekstem 3D na przedniej powierzchni](img_01_01.png)

## **Obróć kształt przy użyciu kamery**

W programie PowerPoint obrót 3D jest konfigurowany z panelu Obrót 3‑D. Wartości rotacji X, Y i Z odpowiadają obrotowi ustawianemu przez API kamery.

![Panel Obrót 3‑D programu PowerPoint z podświetlonymi wartościami rotacji X, Y i Z](img_02_01.png)

W Aspose.Slides ustaw typ kamery i rotację poprzez format 3D zwrócony przez [Shape.getThreeDFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getThreeDFormat):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
finally:
    presentation.dispose()
```

Użyj kamery, gdy potrzebujesz zmienić sposób, w jaki obserwator widzi obiekt. Nie zmienia ona geometryki 2D kształtu na slajdzie. Zmienia punkt widzenia 3D używany przez PowerPoint i przez Aspose.Slides przy renderowaniu.

## **Dodaj wyciągnięcie i głębokość**

Wyciągnięcie sprawia, że kształt wygląda na gruby, wydłużając go za przednią powierzchnią. W PowerPoint kontrola głębokości ustawia tę widoczną grubość, a kontrola koloru ustawia kolor boków.

![Kontrole głębokości w PowerPoint powiązane z właściwościami koloru wyciągnięcia i wysokości wyciągnięcia](img_02_02.png)

Ustaw wysokość wyciągnięcia dla grubości i kolor wyciągnięcia dla koloru boków:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

Użyj ustawienia głębokości, gdy potrzebujesz pracować bezpośrednio z wartością głębokości PowerPoint lub łączyć głębokość z fazowaniem, materiałem i efektami tekstu. W wielu scenariuszach kształtów wysokość wyciągnięcia jest jaśniejszym ustawieniem, ponieważ bezpośrednio wyraża widoczne wyciągnięcie.

## **Użyj gradientowych lub graficznych wypełnień z efektami 3D**

Formatowanie 3D jest niezależne od wypełnienia kształtu. Możesz zastosować jednolity kolor, gradient, wzór lub wypełnienie obrazem do przedniej powierzchni i nadal korzystać z tych samych ustawień kamery, światła, materiału i wyciągnięcia.

Ten przykład stosuje wypełnienie gradientowe do kształtu i ciemniejszy kolor wyciągnięcia po bokach:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getTextFrame().setText("3D Gradient")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("gradient_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()
finally:
    presentation.dispose()
```

Renderowany wynik zachowuje gradient na przedniej powierzchni i renderuje wyciągnięcie osobno:

![Renderowany prostokąt 3D z gradientowym wypełnieniem od niebieskiego do pomarańczowego i pomarańczowym wyciągnięciem](img_02_03.png)

Aby użyć wypełnienia obrazem, dodaj obraz do prezentacji i przypisz go jako wypełnienie kształtu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PictureFillMode, Presentation, ShapeType
from java.awt import Color
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)

    image_data = Path("image.jpg").read_bytes()
    java_image_data = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(java_image_data)

    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

Obraz jest renderowany na przedniej powierzchni, podczas gdy wyciągnięcie jest renderowane jako boczna powierzchnia 3D:

![Renderowany prostokąt 3D z wypełnieniem zdjęciem na przedniej powierzchni i pomarańczowym wyciągnięciem](img_02_04.png)

## **Zastosuj formatowanie 3D do tekstu**

Formatowanie 3D kształtu wpływa na ciało kształtu. Formatowanie 3D tekstu wpływa na ramkę tekstową. Jest to przydatne przy efektach podobnych do WordArt, gdzie same litery potrzebują wyciągnięcia, materiału, oświetlenia i ustawień kamery.

Poniższy przykład tworzy tekst z wypełnieniem wzorem, stosuje transformację WordArt i konfiguruje ustawienia 3D na [TextFrameFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, PatternStyle, Presentation, SaveFormat, ShapeType, TextShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().setText("3D Text")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern)
    pattern_color = Color(255, 140, 0)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(pattern_color)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE)
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid)

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128)

    text_frame_format = shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setTransform(TextShapeType.ArchUp)
    text_frame_format.getThreeDFormat().setExtrusionHeight(3.5)
    text_frame_format.getThreeDFormat().setDepth(3)
    text_frame_format.getThreeDFormat().setMaterial(MaterialPresetType.Plastic)
    text_frame_format.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    text_frame_format.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    text_frame_format.getThreeDFormat().getLightRig().setRotation(0, 0, 40)
    text_frame_format.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("text_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("text_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Tekst jest renderowany jako zakrzywione, wyciągnięte litery 3D:

![Renderowany tekst 3D z łukową transformacją WordArt, pomarańczowym wypełnieniem wzorem i ciemnym wyciągnięciem](img_02_05.png)

## **Zachowanie eksportu i renderowania**

Aspose.Slides zachowuje formatowanie 3D przy zapisie do formatów PowerPoint, takich jak PPTX. Przy renderowaniu lub eksporcie do formatów o stałym układzie scena 3D jest rasteryzowana lub rysowana w wyjściu jako rezultat 2D. Dotyczy to renderowania slajdów do PNG, eksportu do PDF, eksportu do HTML lub generowania klatek do konwersji wideo.

Pamiętaj o następujących kwestiach:

- Eksportowane obrazy i pliki PDF nie są interaktywne. Obiekt nie może być obracany przez widza po eksporcie.
- Ostateczny wygląd zależy od kombinacji kamery, oświetlenia, materiału, wyciągnięcia, wypełnienia i skalowania slajdu.
- Jeśli potrzebujesz sprawdzić dziedziczone lub oparte na motywie wartości formatowania, użyj API efektywnego formatowania.
- Niektóre formaty wyjściowe nie mogą przechowywać edytowalnego formatowania 3D PowerPoint. W tych formatach wynik wizualny jest renderowany, a nie zachowywany jako edytowalne ustawienia 3D.

## **FAQ**

**Czy Aspose.Slides może tworzyć interaktywne prezentacje 3D?**

Aspose.Slides tworzy i renderuje efekty 3D PowerPoint dla kształtów i tekstu. Nie sprawia, że wyeksportowane obrazy, PDF‑y ani strony HTML są interaktywnymi scenami 3D, które użytkownik może obracać. W PPTX formatowanie 3D pozostaje edytowalne w PowerPoint, o ile format to obsługuje.

**Jaka jest różnica między modelem 3D a efektem 3D?**

Model 3D to osobny obiekt 3D wstawiany do prezentacji. Efekt 3D to formatowanie zastosowane do zwykłego kształtu lub tekstu PowerPoint, takie jak obrót, wyciągnięcie, fazowanie, oświetlenie i materiał. Ten artykuł opisuje efekty 3D.

**Jakie ustawienia są wymagane dla widocznego kształtu 3D?**

Co najmniej ustaw rotację kamery oraz wyciągnięcie lub głębokość. W praktyce warto także ustawić oświetlenie i materiał, aby wyrenderowane powierzchnie miały wyraźne podświetlenia i cienie.

**Czy mogę zastosować efekty 3D zarówno do kształtów, jak i tekstu?**

Tak. Użyj [Shape.getThreeDFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getThreeDFormat) dla ciała kształtu oraz [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/#getThreeDFormat) dla tekstu.

**Czy efekty 3D pojawią się przy eksporcie do obrazów, PDF, HTML lub klatek wideo?**

Tak. Aspose.Slides renderuje efekty 3D przy generowaniu obrazów slajdów, wyjściu PDF, wyjściu HTML oraz klatkach używanych do konwersji wideo. Wyeksportowany wynik zawiera zrenderowany wygląd, a nie edytowalny obiekt 3D.

**Czy mogę odczytać ostateczne wartości 3D po zastosowaniu dziedziczenia i ustawień motywu?**

Tak. Użyj [ThreeDFormat.getEffective](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#getEffective), aby odczytać ostateczne wartości kamery, oświetlenia, fazowania i powiązane wartości 3D.