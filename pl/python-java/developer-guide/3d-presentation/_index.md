---
title: Tworzenie efektów 3D w prezentacjach za pomocą Pythona
linktitle: Prezentacja 3D
type: docs
weight: 232
url: /pl/python-java/3d-presentation/
keywords:
- PowerPoint 3D
- Prezentacja 3D
- Obrót 3D
- Głębokość 3D
- Wyciągnięcie 3D
- Gradient 3D
- Tekst 3D
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Zastosuj i renderuj efekty 3D dla kształtów i tekstu PowerPoint w Pythonie przez Java z Aspose.Slides. Skonfiguruj kamerę, oświetlenie, materiał, wyciągnięcie, wypełnienia i tekst 3D."
---
## **Przegląd**

Aspose.Slides for Python via Java może tworzyć, edytować, zachowywać i renderować formatowanie 3D w stylu PowerPoint dla kształtów i tekstu. Ten artykuł opisuje efekty 3D, takie jak obrót, wyciąganie, sfazowania, oświetlenie, materiał, gradientowe lub obrazkowe wypełnienia oraz tekst 3D.

{{% alert color="info" title="Uwaga" %}}
Ten artykuł dotyczy efektów formatowania 3D na kształtach i tekście w PowerPoint. Nie chodzi o wstawianie ani edytowanie osobnych plików modeli 3D. Gdy eksportujesz slajd do obrazu, PDF lub HTML, Aspose.Slides renderuje te efekty 3D do wyeksportowanego wyniku 2D.
{{% /alert %}}

## **Koncepcje formatowania 3D**

Użyj metody [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) aby zastosować formatowanie 3D do kształtu. Metoda zwraca [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/), które kontroluje scenę 3D dla tego kształtu.

Dla tekstu użyj metody [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat). To stosuje formatowanie 3D do ramki tekstowej zamiast ciała kształtu.

Najważniejsze elementy API to:

| Element API | Co kontroluje | Kiedy używać |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera) | Punkt widzenia, gotowy typ kamery, obrót, przybliżenie i perspektywa. | Obróć obiekt w przestrzeni 3D lub dopasuj do gotowego ustawienia obrotu 3D w PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getLightRig) | Gotowe oświetlenie, kierunek i obrót światła. | Zmień sposób wyświetlania podświetleń i cieni na powierzchni 3D. |
| [getMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getMaterial) i [setMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setMaterial) | Materiał powierzchni, np. płaski, matowy, plastikowy lub metalowy. | Spraw, aby ta sama geometria wyglądała bardziej płasko, miękko, błyszcząco lub metalicznie. |
| [getExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionHeight) i [setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Jak daleko kształt wyciąga się w tył od swojej przedniej powierzchni. | Przekształć płaski kształt w widocznie gruby obiekt 3D. |
| [getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor) | Kolor wyciągniętych boków. | Uczyń głębokość widoczną lub dopasuj kolor boków do wypełnienia przedniej powierzchni. |
| [getDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getDepth) i [setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) | Dodatkowa głębokość 3D używana w formatowaniu 3D PowerPoint. | Doprecyzuj głębokość kształtów lub tekstu, szczególnie razem z ustawieniami sfazowania i materiału. |
| [getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop) i [getBevelBottom](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelBottom) | Podwyższone lub zaokrąglone krawędzie na przedniej i tylnej powierzchni. | Dodaj miękką lub formowaną krawędź zamiast ostrej płaskiej powierzchni. |
| [getContourColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourColor) i [getContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourWidth) i [setContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setContourWidth) | Obrys wokół obiektu 3D. | Podkreśl granicę obiektu w renderowanym wyniku. |

## **Utwórz kształt 3D**

Kształt zazwyczaj potrzebuje czterech rodzajów ustawień, zanim będzie wyglądał przekonująco 3D:

- Ustawienia kamery, ponieważ domyślny widok z przodu może ukrywać wyciągnięcie.  
- Ustawienia oświetlenia, ponieważ oświetlenie sprawia, że powierzchnie i boki są widoczne.  
- Ustawienia materiału, ponieważ powierzchnia wpływa na sposób renderowania światła.  
- Ustawienia wyciągnięcia lub głębokości, ponieważ płaski kształt potrzebuje grubości.

Poniższy przykład tworzy prostokąt, dodaje tekst do jego przedniej powierzchni i stosuje formatowanie 3D. Wartości obrotu kamery podane są w stopniach, a wysokość wyciągnięcia wynosi 100 punktów. Przykład renderuje slajd do obrazu PNG w dwukrotnych domyślnych wymiarach i zapisuje prezentację jako PPTX.

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

Renderowany obraz slajdu pokazuje prostokąt jako gruby blok 3D:

![Renderowany niebieski prostokąt 3D z białym tekstem 3D na przedniej powierzchni](img_01_01.png)

## **Obróć kształt przy użyciu kamery**

W PowerPoint, obrót 3D konfiguruje się w panelu 3‑D Rotation. Wartości obrotu X, Y i Z odpowiadają obrotowi ustawionemu za pomocą API kamery.

![Panel 3‑D Rotation w PowerPoint z wyróżnionymi wartościami obrotu X, Y i Z](img_02_01.png)

W Aspose.Slides uzyskaj dostęp do kamery przez [ThreeDFormat.getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera). Ten przykład tworzy prostokąt, wybiera ortograficzny widok z przodu i ustawia obroty X, Y i Z na odpowiednio 20, 30 i 40 stopni. Konfiguruje kształt w pamięci bez zapisywania pliku:

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

Użyj kamery, gdy musisz zmienić sposób, w jaki widz widzi obiekt. Nie zmienia to geometrii kształtu 2D na slajdzie. Zmienia to punkt widzenia 3D używany przez PowerPoint i przez Aspose.Slides podczas renderowania.

### **Skopiuj orientację kamery z kształtu szablonu**

Aby dopasować orientację kształtu szablonu, odczytaj jego preset kamery za pomocą [Camera.getCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getCameraType) i kąty obrotu za pomocą [Camera.getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getRotation). Przykład otwiera `template.pptx` i kopiuję orientację kamery z pierwszego kształtu na pierwszym slajdzie do drugiego kształtu. Oba kształty mają już oświetlenie 3D, a drugi kształt nie ma wyraźnego obrotu kamery.

Kąty podane są w stopniach. Indeks `0` to szerokość, indeks `1` to długość, a indeks `2` to obrót. Przekaż je do [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation) w tej kolejności. Jeśli źródło zwróci `None`, nie ma wyraźnego obrotu, więc pozostaw kąty drugiego kształtu nieustawione. Wyraźny obrót `(0, 0, 0)` zwraca trzy zera i powinien zostać skopiowany.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("template.pptx")
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()
    
    source_camera = shapes.get_Item(0).getThreeDFormat().getCamera()
    destination_camera = shapes.get_Item(1).getThreeDFormat().getCamera()

    destination_camera.setCameraType(source_camera.getCameraType())
    angles = source_camera.getRotation()
    if angles is not None:
        destination_camera.setRotation(angles[0], angles[1], angles[2])

    presentation.save("camera-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Po ponownym otwarciu `camera-copy.pptx` w PowerPoint, strzałka po prawej ma ten sam preset kamery i obrót co prostokąt po lewej. Oba kształty używają tego samego oświetlenia i głębokości wyciągnięcia.

![Niebieski prostokąt 3D i prawostronna strzałka z dopasowaną orientacją kamery, widziane z góry i z prawej](camera-orientation.png)

## **Dodaj wyciągnięcie i głębokość**

Wyciągnięcie sprawia, że kształt wygląda na gruby, wydłużając go za przednią powierzchnię. W PowerPoint kontrolka głębokości ustawia tę widoczną grubość, a kontrolka koloru ustawia kolor bocznych powierzchni.

![Kontrolki głębokości w PowerPoint powiązane z właściwościami koloru wyciągnięcia i wysokości wyciągnięcia](img_02_02.png)

Użyj [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight), aby ustawić grubość oraz [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor), aby uzyskać dostęp do koloru boków. Ten przykład nadaje prostokątowi wyciągnięcie 100 punktów z fioletowymi bokami i obraca kamerę, aby pokazać jego grubość. Konfiguruje kształt w pamięci bez zapisywania pliku:

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

Metoda [ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) ustawia głębokość obiektu 3D. Metoda [setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) kontroluje wysokość efektu wyciągnięcia, jak pokazano w tym przykładzie.

## **Użyj wypełnień gradientowych lub obrazkowych z efektami 3D**

Formatowanie 3D jest niezależne od wypełnienia kształtu. Możesz zastosować jednolity kolor, gradient, wzór lub wypełnienie obrazem na przedniej powierzchni i nadal używać tych samych ustawień kamery, światła, materiału i wyciągnięcia.

Ten przykład stosuje gradient od niebieskiego do pomarańczowego na przedniej powierzchni oraz ciemny pomarańczowy kolor dla wyciągnięcia 150 punktów. Przerwy gradientu na 0 i 100 oznaczają początek i koniec gradientu. Wartości obrotu kamery podane są w stopniach. Slajd renderowany jest do obrazu PNG w dwukrotnych domyślnych wymiarach:

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

Renderowany wynik zachowuje gradient na przedniej powierzchni i renderuje wyciągnięcie osobno:

![Renderowany prostokąt 3D z gradientem od niebieskiego do pomarańczowego i pomarańczowym wyciągnięciem](img_02_03.png)

Aby zamiast tego użyć wypełnienia obrazem, dodaj obraz do prezentacji i przypisz go do wypełnienia kształtu. Ten przykład wymaga istniejącego pliku o nazwie "image.jpg" w katalogu roboczym. Rozciąga obraz, aby wypełnić prostokąt, stosuje wyciągnięcie 150 punktów i ustawia obrót kamery w stopniach. Konfiguruje kształt w pamięci bez zapisywania lub renderowania pliku:

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

Obraz renderowany jest na przedniej powierzchni, podczas gdy wyciągnięcie renderowane jest jako boczna powierzchnia 3D:

![Renderowany prostokąt 3D z wypełnieniem zdjęciem na przedniej powierzchni i pomarańczowym wyciągnięciem](img_02_04.png)

## **Zastosuj formatowanie 3D do tekstu**

Formatowanie 3D kształtu wpływa na ciało kształtu. Formatowanie 3D tekstu wpływa na ramkę tekstową. Jest to przydatne przy efektach podobnych do WordArt, gdzie same litery potrzebują wyciągnięcia, materiału, oświetlenia i ustawień kamery.

Następny przykład tworzy tekst z pomarańczowo-białym wzorem siatki, stosuje łuk skierowany w górę i konfiguruje ustawienia 3D poprzez [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat). Wysokość i głębokość wyciągnięcia podane są w punktach, a obrót światła w stopniach. Wypełnienie i kontur kształtu są ukryte, aby widoczny był tylko tekst. Przykład renderuje obraz PNG w dwukrotnych domyślnych wymiarach slajdu i zapisuje prezentację jako PPTX:

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

Tekst renderowany jest jako zakrzywione, wyciągnięte litery 3D:

![Renderowany tekst 3D z zakrzywioną transformacją WordArt, pomarańczowym wypełnieniem wzorem i ciemnym wyciągnięciem](img_02_05.png)

## **Utrzymaj tekst płaski na kształcie 3D**

Aby zachować czytelność tekstu przy zachowaniu wyglądu 3D kształtu, wywołaj [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setKeepTextFlat) przez [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getTextFrameFormat). Gdy wartość jest `True`, tekst pozostaje poza sceną 3D. Gdy jest `False`, tekst uczestniczy w scenie i podąża za jej orientacją 3D.

To ustawienie nie usuwa formatowania 3D kształtu: jego kamera, oświetlenie, materiał i wyciągnięcie pozostają skonfigurowane przez [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat). Jest to także inne niż zwykły obrót. [Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) obraca kształt w płaszczyźnie slajdu, podczas gdy [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) kontroluje własny obrót tekstu w jego obszarze ograniczającym. Utrzymanie tekstu poza sceną 3D nie resetuje żadnego z tych kątów.

Następny samodzielny przykład tworzy niebieski prostokąt z tekstem i klonuje go obok oryginału. Oba kształty mają to samo formatowanie 3D; jedynie ustawienie tekstu się różni: `False` po lewej i `True` po prawej. Kąty kamery podane są w stopniach, a wysokość wyciągnięcia wynosi 40 punktów. Przykład zapisuje prezentację jako PPTX i renderuje slajd porównawczy do PNG w dwukrotnych domyślnych wymiarach.

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

Po lewej tekst podąża za orientacją 3D. Po prawej pozostaje płaski i łatwiejszy do odczytania. Oba prostokąty zachowują tę samą widoczną głębokość wyciągnięcia i orientację 3D.

![Prostokąty 3D obok siebie: tekst podąża za orientacją 3D po lewej i pozostaje płaski po prawej](keep_text_flat.png)

## **Zachowanie przy eksporcie i renderowaniu**

Aspose.Slides zachowuje formatowanie 3D przy zapisywaniu do formatów PowerPoint, takich jak PPTX. Podczas renderowania lub eksportu do formatów o stałym układzie, scena 3D jest rastrowana lub rysowana do wyjścia jako wynik 2D. Dotyczy to renderowania slajdów do [PNG](/slides/pl/python-java/convert-powerpoint-to-png/), eksportu do [PDF](/slides/pl/python-java/convert-powerpoint-to-pdf/), eksportu do [HTML](/slides/pl/python-java/convert-powerpoint-to-html/), lub generowania klatek dla [video conversion](/slides/pl/python-java/convert-powerpoint-to-video/).

- Wyeksportowane obrazy i PDFy nie są interaktywne. Obiekt nie może być obracany przez widza po eksporcie.  
- Ostateczny wygląd zależy od kombinacji kamery, zestawu świateł, materiału, wyciągnięcia, wypełnienia i skalowania slajdu.  
- Jeśli potrzebujesz sprawdzić dziedziczone lub oparte na motywie wartości formatowania, odczytaj [efektywne właściwości kształtu](/slides/pl/python-java/shape-effective-properties/).  
- Niektóre formaty wyjściowe nie mogą przechowywać edytowalnego formatowania 3D PowerPoint. W tych formatach wynik wizualny jest renderowany, a nie zachowywany jako edytowalne ustawienia 3D.

## **FAQ**

**Czy Aspose.Slides może tworzyć interaktywne prezentacje 3D?**

Aspose.Slides tworzy i renderuje efekty 3D PowerPoint dla kształtów i tekstu. Nie zamienia eksportowanych obrazów, PDFów ani stron HTML w interaktywne sceny 3D, które widz może obracać. W formacie PPTX formatowanie 3D pozostaje edytowalne w PowerPoint, jeśli format to obsługuje.

**Jaka jest różnica między modelem 3D a efektem 3D?**

Model 3D to oddzielny obiekt 3D wstawiany do prezentacji. Efekt 3D to formatowanie zastosowane do zwykłego kształtu lub tekstu w PowerPoint, takie jak obrót, wyciągnięcie, sfazowanie, oświetlenie i materiał. Ten artykuł opisuje efekty 3D.

**Jakie ustawienia są wymagane dla widocznego kształtu 3D?**

Co najmniej, ustaw obrót kamery oraz wyciągnięcie lub głębokość. W praktyce, ustaw także zestaw świateł i materiał, aby renderowane powierzchnie miały wyraźne podświetlenia i cienie.

**Czy mogę zastosować efekty 3D zarówno do kształtów, jak i tekstu?**

Tak. Użyj [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) dla ciała kształtu i [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat) dla tekstu.

**Czy efekty 3D pojawią się przy eksporcie do obrazów, PDF, HTML lub klatek wideo?**

Tak. Aspose.Slides renderuje efekty 3D przy tworzeniu obrazów slajdów, wyjścia PDF, wyjścia HTML oraz klatek używanych do konwersji wideo. Wyeksportowany wynik zawiera renderowany wygląd, a nie edytowalny obiekt 3D.

**Czy mogę odczytać ostateczne wartości 3D po zastosowaniu dziedziczenia i ustawień motywu?**

Tak. Użyj API efektywnego formatowania opisanego w [efektywne właściwości kształtu](/slides/pl/python-java/shape-effective-properties/), aby odczytać ostateczne wartości kamery, zestawu świateł, sfazowania i powiązane wartości 3D.