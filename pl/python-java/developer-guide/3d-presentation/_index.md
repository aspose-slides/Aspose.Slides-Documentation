---
title: Tworzenie efektów 3D w prezentacjach przy użyciu Pythona
linktitle: Prezentacja 3D
type: docs
weight: 232
url: /pl/python-java/3d-presentation/
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
- Python
- Java
- Aspose.Slides
description: "Stosuj i renderuj efekty 3D dla kształtów i tekstu PowerPoint w Pythonie za pośrednictwem Javy z Aspose.Slides. Konfiguruj kamerę, oświetlenie, materiał, ekstruzję, wypełnienia oraz tekst 3D."
---
## **Przegląd**

Aspose.Slides for Python via Java może tworzyć, edytować, zachowywać i renderować formatowanie 3D w stylu PowerPoint dla kształtów i tekstu. Ten artykuł opisuje efekty 3D, takie jak obrót, ekstruzja, fazowania, oświetlenie, materiał, wypełnienia gradientowe lub obrazkowe oraz tekst 3D.

{{% alert color="info" title="Note" %}}
Ten artykuł dotyczy efektów formatowania 3D na kształtach i tekście w programie PowerPoint. Nie jest o wstawianiu lub edytowaniu oddzielnych plików modeli 3D. Gdy eksportujesz slajd do obrazu, PDF lub HTML, Aspose.Slides renderuje te efekty 3D w wyjściowym 2D.
{{% /alert %}}

## **Koncepcje formatowania 3D**

Użyj metody [Shape.getThreeDFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getThreeDFormat), aby zastosować formatowanie 3D do kształtu. Metoda zwraca [ThreeDFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/), który kontroluje scenę 3D dla tego kształtu.

Dla tekstu użyj metody [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/#getThreeDFormat). To stosuje formatowanie 3D do ramki tekstowej, a nie do ciała kształtu.

Najważniejsze członki API:

| Członek API | Co kontroluje | Kiedy używać |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#getCamera) | Punkt widzenia, preset typu kamery, obrót, przybliżenie i perspektywa. | Obrócenie obiektu w przestrzeni 3D lub dopasowanie do predefiniowanego obrotu w PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#getLightRig) | Preset światła, kierunek i obrót światła. | Zmiana wyglądu podświetleń i cieni na powierzchni 3D. |
| [getMaterial](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#getMaterial) i [setMaterial](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#setMaterial) | Materiał powierzchni, taki jak płaski, matowy, plastikowy lub metalowy. | Spraw, by ta sama geometria wyglądała na płaską, miękką, błyszczącą lub metaliczną. |
| [getExtrusionHeight](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#getExtrusionHeight) i [setExtrusionHeight](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Jak daleko kształt wznosi się w tył od swojej przedniej powierzchni. | Przekształć płaski kształt w widocznie gruby obiekt 3D. |
| [getExtrusionColor](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#getExtrusionColor) | Kolor boków ekstruzowanych. | Uwzględnij głębię lub skoordynuj kolor boków z wypełnieniem przedniej powierzchni. |
| [getDepth](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#getDepth) i [setDepth](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#setDepth) | Dodatkowa głębokość 3D używana przez formatowanie PowerPoint. | Dostosuj głębokość kształtów lub tekstu, zwłaszcza w połączeniu z fazowaniem i ustawieniami materiału. |
| [getBevelTop](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#getBevelTop) i [getBevelBottom](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#getBevelBottom) | Podniesione lub zaokrąglone krawędzie na przedniej i tylnej powierzchni. | Dodaj miękką lub formowaną krawędź zamiast ostrej płaskiej powierzchni. |
| [getContourColor](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#getContourColor) i [getContourWidth](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#getContourWidth) i [setContourWidth](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#setContourWidth) | Kontur wokół obiektu 3D. | Podkreśl granicę obiektu w renderowanym wyniku. |

## **Utworzenie kształtu 3D**

Kształt zazwyczaj wymaga czterech rodzajów ustawień, aby wyglądał przekonująco 3D:

- Ustawienia kamery, ponieważ domyślny widok z przodu może ukrywać ekstruzję.
- Ustawienia światła, ponieważ oświetlenie sprawia, że powierzchnie i boki są czytelne.
- Ustawienia materiału, ponieważ powierzchnia wpływa na sposób renderowania światła.
- Ustawienia ekstruzji lub głębokości, ponieważ płaski kształt potrzebuje grubości.

Poniższy przykład tworzy prostokąt, dodaje tekst na jego przedniej powierzchni i stosuje formatowanie 3D. Wartości obrotu kamery podane są w stopniach, a wysokość ekstruzji wynosi 100 punktów. Przykład renderuje slajd do obrazu PNG w dwukrotnie większych wymiarach niż domyślne i zapisuje prezentację jako PPTX.

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
    shape.getFillFormat().getSolidFillColor().setColor(Color(100, 149, 237))

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

Renderowany obraz slajdu przedstawia prostokąt jako gruby blok 3D:

![Wyrenderowany niebieski prostokąt 3D z białym tekstem 3D na przedniej powierzchni](img_01_01.png)

## **Obrócenie kształtu przy użyciu kamery**

W programie PowerPoint obrót 3D konfiguruje się w panelu **3‑D Rotation**. Wartości obrotu X, Y i Z odpowiadają obrotowi ustawionemu przez API kamery.

![Panel 3‑D Rotation w PowerPoint z podświetlonymi wartościami obrotu X, Y i Z](img_02_01.png)

W Aspose.Slides dostęp do kamery uzyskuje się przez [ThreeDFormat.getCamera](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#getCamera). Ten przykład tworzy prostokąt, wybiera ortograficzny widok z przodu i ustawia obroty X, Y i Z na 20, 30 i 40 stopni. Konfiguruje kształt w pamięci bez zapisywania pliku:

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

Używaj kamery, gdy potrzebujesz zmienić sposób, w jaki obserwator widzi obiekt. Nie zmienia to geometrii 2D kształtu na slajdzie. Zmienia punkt widzenia 3D używany przez PowerPoint i Aspose.Slides podczas renderowania.

## **Dodaj ekstruzję i głębokość**

Ekstruzja sprawia, że kształt wygląda na gruby, wydłużając go za przednią powierzchnię. W PowerPoint sterowanie głębokością ustawia tę widoczną grubość, a sterowanie kolorem ustawia kolor boków.

![Sterowanie głębokością w PowerPoint mapowane na właściwości koloru ekstruzji i wysokości ekstruzji](img_02_02.png)

Użyj [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#setExtrusionHeight), aby ustawić grubość, oraz [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#getExtrusionColor), aby uzyskać dostęp do koloru boków. Ten przykład nadaje prostokątowi ekstruzję 100 punktów z fioletowymi bokami i obraca kamerę, aby uwidocznić grubość. Konfiguruje kształt w pamięci bez zapisywania pliku:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

Metoda [ThreeDFormat.setDepth](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#setDepth) ustawia głębokość kształtu 3D. Metoda [setExtrusionHeight](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#setExtrusionHeight) kontroluje wysokość efektu ekstruzji, co pokazano w tym przykładzie.

## **Użyj wypełnień gradientowych lub obrazkowych z efektami 3D**

Formatowanie 3D jest niezależne od wypełnienia kształtu. Możesz zastosować jednolity kolor, gradient, wzór lub wypełnienie obrazkiem na przedniej powierzchni i nadal używać tych samych ustawień kamery, światła, materiału i ekstruzji.

Ten przykład nakłada gradient od niebieskiego do pomarańczowego na przednią powierzchnię oraz ciemnopomarańczowy kolor na ekstruzję o wysokości 150 punktów. Stopnie gradientu 0 i 100 oznaczają początek i koniec gradientu. Wartości obrotu kamery podane są w stopniach. Slajd jest renderowany do obrazu PNG w dwukrotnie większych wymiarach niż domyślne:

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color(255, 165, 0))

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

Renderowany wynik zachowuje gradient na przedniej powierzchni i renderuje ekstruzję oddzielnie:

![Wyrenderowany prostokąt 3D z gradientem niebiesko‑pomarańczowym i pomarańczową ekstruzją](img_02_03.png)

Aby użyć wypełnienia obrazkiem, dodaj obraz do prezentacji i przypisz go jako wypełnienie kształtu. Ten przykład wymaga istniejącego pliku o nazwie "image.jpg" w katalogu roboczym. Rozciąga obraz, aby wypełnił prostokąt, stosuje ekstruzję 150 punktów i ustawia obrót kamery w stopniach. Konfiguruje kształt w pamięci bez zapisywania ani renderowania pliku:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, LightRigPresetType, LightingDirection, MaterialPresetType, PictureFillMode, Presentation, ShapeType
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
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

Obraz jest renderowany na przedniej powierzchni, podczas gdy ekstruzja jest renderowana jako trójwymiarowa powierzchnia boczna:

![Wyrenderowany prostokąt 3D z wypełnieniem zdjęciem na przedniej powierzchni i pomarańczową ekstruzją](img_02_04.png)

## **Zastosowanie formatowania 3D do tekstu**

Formatowanie 3D kształtu wpływa na ciało kształtu. Formatowanie 3D tekstu wpływa na ramkę tekstową. Jest to przydatne w efektach przypominających WordArt, gdzie same litery potrzebują ekstruzji, materiału, oświetlenia i ustawień kamery.

Poniższy przykład tworzy tekst z pomarańczowo‑białym wzorem siatki, stosuje łukowaty podniesiony kształt i konfiguruje ustawienia 3D przez [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/#getThreeDFormat). Wysokość ekstruzji i głębokość podane są w punktach, a obrót światła w stopniach. Wypełnienie i kontur kształtu są ukryte, aby widoczny był tylko tekst. Przykład renderuje obraz PNG w dwukrotnie większych wymiarach slajdu i zapisuje prezentację jako PPTX:

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

Tekst jest renderowany jako zakrzywione, ekstruzowane litery 3D:

![Wyrenderowany tekst 3D z łukowatą transformacją WordArt, pomarańczowym wypełnieniem wzorem i ciemną ekstruzją](img_02_05.png)

## **Utrzymaj tekst płasko na kształcie 3D**

Aby tekst pozostał czytelny przy zachowaniu wyglądu 3D kształtu, wywołaj [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/#setKeepTextFlat) przez [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/#getTextFrameFormat). Gdy wartość jest `True`, tekst pozostaje poza sceną 3D. Gdy jest `False`, tekst uczestniczy w scenie i podąża za jej orientacją 3D.

To ustawienie nie usuwa formatowania 3D kształtu: jego kamera, oświetlenie, materiał i ekstruzja pozostają skonfigurowane przez [Shape.getThreeDFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getThreeDFormat). Różni się to też od zwykłego obrotu. [Shape.setRotation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#setRotation) obraca kształt w płaszczyźnie slajdu, natomiast [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/#setRotationAngle) kontroluje niestandardowy obrót tekstu w jego ramce. Utrzymanie tekstu poza sceną 3D nie resetuje żadnego z tych kątów.

Poniższy samodzielny przykład tworzy niebieski prostokąt z tekstem i klonuje go obok oryginału. Oba kształty mają to samo formatowanie 3D; jedyne różnice to ustawienie tekstu: `False` po lewej i `True` po prawej. Kąty kamery podane są w stopniach, a wysokość ekstruzji to 40 punktów. Przykład zapisuje prezentację jako PPTX i renderuje porównawczy slajd do PNG w dwukrotnie większych wymiarach niż domyślne.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140)

    shape.getTextFrame().setText("Readable text")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center)
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(100, 149, 237))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(40)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color(65, 105, 225))
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(False)

    flat_text_shape = slide.getShapes().addClone(shape, 400, 160)
    flat_text_shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(True)

    presentation.save("keep_text_flat.pptx", SaveFormat.Pptx)
    image = slide.getImage(2, 2)
    try:
        image.save("keep_text_flat.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

Po lewej tekst podąża za orientacją 3D. Po prawej pozostaje płaski i łatwiej go czytać. Oba prostokąty zachowują widoczną ekstruzję i orientację 3D.

![Prostokąty 3D obok siebie: tekst podąża za orientacją 3D po lewej i pozostaje płaski po prawej](keep_text_flat.png)

## **Zachowanie eksportu i renderowania**

Aspose.Slides zachowuje formatowanie 3D przy zapisie do formatów PowerPoint, takich jak PPTX. Przy renderowaniu lub eksporcie do formatów o stałym układzie scena 3D jest rasteryzowana lub rysowana w wyjściu jako wynik 2D. Dotyczy to renderowania slajdów do [PNG](/slides/pl/python-java/convert-powerpoint-to-png/), eksportu do [PDF](/slides/pl/python-java/convert-powerpoint-to-pdf/), eksportu do [HTML](/slides/pl/python-java/convert-powerpoint-to-html/) oraz generowania klatek do [konwersji wideo](/slides/pl/python-java/convert-powerpoint-to-video/).

Pamiętaj o następujących kwestiach:

- Eksportowane obrazy i pliki PDF nie są interaktywne. Obiekt nie może być obracany przez oglądającego po eksporcie.
- Końcowy wygląd zależy od kombinacji kamery, zestawu świateł, materiału, ekstruzji, wypełnienia i skalowania slajdu.
- Jeśli potrzebujesz sprawdzić wartości formatowania dziedziczone lub oparte na temacie, odczytaj [efektywne właściwości kształtu](/slides/pl/python-java/shape-effective-properties/).
- Niektóre formaty wyjściowe nie mogą przechowywać edytowalnego formatowania 3D PowerPoint. W takich formatach wynik wizualny jest renderowany, a nie zachowywany jako edytowalne ustawienia 3D.

## **FAQ**

**Czy Aspose.Slides może tworzyć interaktywne prezentacje 3D?**

Aspose.Slides tworzy i renderuje efekty 3D PowerPoint dla kształtów i tekstu. Nie sprawia, że wyeksportowane obrazy, PDF‑y ani strony HTML stają się interaktywnymi scenami 3D, które użytkownik może obracać. W PPTX formatowanie 3D pozostaje edytowalne w PowerPoint, o ile format to umożliwia.

**Jaka jest różnica między modelem 3D a efektem 3D?**

Model 3D to oddzielny obiekt 3D wstawiany do prezentacji. Efekt 3D to formatowanie stosowane do zwykłego kształtu lub tekstu w PowerPoint, takie jak obrót, ekstruzja, fazowanie, oświetlenie i materiał. Ten artykuł opisuje efekty 3D.

**Jakie ustawienia są wymagane, aby kształt 3D był widoczny?**

Co najmniej ustaw obrót kamery oraz ekstruzję lub głębokość. W praktyce warto także ustawić zestaw świateł i materiał, aby wyrenderowane powierzchnie miały wyraźne podświetlenia i cienie.

**Czy mogę zastosować efekty 3D zarówno do kształtów, jak i do tekstu?**

Tak. Użyj [Shape.getThreeDFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getThreeDFormat) dla ciała kształtu oraz [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/#getThreeDFormat) dla tekstu.

**Czy efekty 3D pojawią się przy eksporcie do obrazów, PDF, HTML lub klatek wideo?**

Tak. Aspose.Slides renderuje efekty 3D przy tworzeniu obrazów slajdów, wyjścia PDF, HTML oraz klatek używanych do konwersji wideo. Eksportowany plik zawiera wyrenderowany wygląd, a nie edytowalny obiekt 3D.

**Czy mogę odczytać ostateczne wartości 3D po zastosowaniu dziedziczenia i ustawień tematu?**

Tak. Skorzystaj z API formatowania efektywnego opisanych w [Shape Effective Properties](/slides/pl/python-java/shape-effective-properties/), aby odczytać ostateczne wartości kamery, zestawu świateł, fazowania i powiązane wartości 3D.