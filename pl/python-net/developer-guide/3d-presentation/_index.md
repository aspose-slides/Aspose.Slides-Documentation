---
title: Tworzenie efektów 3D w prezentacjach przy użyciu Pythona
linktitle: Prezentacja 3D
type: docs
weight: 232
url: /pl/python-net/3d-presentation/
keywords:
- PowerPoint 3D
- Prezentacja 3D
- Obrót 3D
- Głębokość 3D
- Wyciąganie 3D
- Gradient 3D
- Tekst 3D
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Zastosuj i renderuj efekty 3D dla kształtów i tekstu PowerPoint w Pythonie przy użyciu Aspose.Slides. Konfiguruj kamerę, oświetlenie, materiał, wyciąganie, wypełnienia i tekst 3D."
---
## **Przegląd**

Aspose.Slides for Python via .NET może tworzyć, edytować, zachowywać i renderować formatowanie 3D w stylu PowerPoint dla kształtów i tekstu. Ten artykuł opisuje efekty 3D, takie jak obrót, wyciąganie, fazety, oświetlenie, materiały, wypełnienia gradientowe lub obrazkowe oraz tekst 3D.

{{% alert color="info" title="Note" %}}
Ten artykuł dotyczy efektów formatowania 3D na kształtach i tekście w PowerPoint. Nie jest to temat wstawiania ani edytowania samodzielnych plików modeli 3D. Gdy eksportujesz slajd do obrazu, PDF lub HTML, Aspose.Slides renderuje te efekty 3D w wyjściowym 2D.
{{% /alert %}}

## **Koncepcje formatowania 3D**

Użyj właściwości [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) aby zastosować formatowanie 3D do kształtu. Właściwość udostępnia [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/), które kontroluje scenę 3D tego kształtu.

Dla tekstu użyj właściwości [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/). Stosuje to formatowanie 3D do ramki tekstowej zamiast do ciała kształtu.

Najważniejsze właściwości to:

| Property | Co kontroluje | Kiedy używać |
|---|---|---|
| [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/) | Punkt widzenia, presetowy typ kamery, obrót, powiększenie i perspektywa. | Obróć obiekt w przestrzeni 3D lub dopasuj preset obrotu 3D w PowerPoint. |
| [light_rig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/light_rig/) | Preset oświetlenia, kierunek i obrót światła. | Zmień sposób, w jaki podświetlenia i cienie pojawiają się na powierzchni 3D. |
| [material](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/material/) | Materiał powierzchni, np. płaski, matowy, plastikowy lub metalowy. | Spraw, by ta sama geometria wyglądała bardziej płasko, miękko, błyszcząco lub metalicznie. |
| [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) | Jak daleko kształt rozciąga się w tył od swojej przedniej powierzchni. | Przekształć płaski kształt w widocznie gruby obiekt 3D. |
| [extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) | Kolor wyciągniętych boków. | Uczyń głębokość widoczną lub skoordynuj kolor boków z wypełnieniem przedniej części. |
| [depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) | Dodatkowa głębokość 3D używana w formatowaniu 3D PowerPoint. | Dostrój głębokość kształtów lub tekstu, szczególnie w połączeniu z ustawieniami fazetu i materiału. |
| [bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/) i [bevel_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_bottom/) | Wypukłe lub zaokrąglone krawędzie na przedniej i tylnej powierzchni. | Dodaj zmiękczoną lub formowaną krawędź zamiast ostrej, płaskiej powierzchni. |
| [contour_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_color/) i [contour_width](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_width/) | Obrys wokół obiektu 3D. | Podkreśl granicę obiektu w renderowanym wyniku. |

## **Utwórz kształt 3D**

Kształt zazwyczaj wymaga czterech rodzajów ustawień, aby wyglądał przekonująco 3D:

- Ustawienia kamery, ponieważ domyślny widok z przodu może ukrywać wyciąganie.
- Ustawienia oświetlenia, ponieważ oświetlenie sprawia, że powierzchnie i boki są widoczne.
- Ustawienia materiału, ponieważ powierzchnia wpływa na sposób, w jaki światło jest renderowane.
- Ustawienia wyciągania lub głębokości, ponieważ płaski kształt potrzebuje grubości.

Poniższy przykład tworzy prostokąt, dodaje tekst do jego przedniej powierzchni i stosuje formatowanie 3D. Wartości obrotu kamery są podane w stopniach, a wysokość wyciągania wynosi 100 punktów. Przykład renderuje slajd do obrazu PNG w podwójnych wymiarach domyślnych i zapisuje prezentację jako PPTX.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.text_frame.text = "3D"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.blue

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("shape_3d.png")

    presentation.save("shape_3d.pptx", slides.export.SaveFormat.PPTX)
```

Renderowany obraz slajdu pokazuje prostokąt jako gruby blok 3D:

![Renderowany niebieski prostokąt 3D z białym tekstem 3D na przedniej powierzchni](img_01_01.png)

## **Obróć kształt za pomocą kamery**

W PowerPoint obrót 3D konfiguruje się w panelu Obrót 3D. Wartości obrotu X, Y i Z odpowiadają obrotowi ustawionemu za pośrednictwem API kamery.

![Panel Obrót 3D w PowerPoint z podświetlonymi wartościami obrotu X, Y i Z](img_02_01.png)

W Aspose.Slides dostęp do kamery uzyskuje się przez [ThreeDFormat.camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/). Ten przykład tworzy prostokąt, wybiera ortograficzny widok z przodu i ustawia obroty X, Y i Z na kolejno 20, 30 i 40 stopni. Konfiguruje kształt w pamięci bez zapisywania pliku:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Używaj kamery, gdy potrzebujesz zmienić sposób, w jaki widz widzi obiekt. Nie zmienia to geometrycznej 2D kształtu na slajdzie. Zmienia to punkt widzenia 3D używany przez PowerPoint i przez Aspose.Slides podczas renderowania.

### **Skopiuj orientację kamery z kształtu szablonu**

Aby dopasować orientację kształtu szablonu, skopiuj jego preset [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) i odczytaj jego obrót za pomocą [get_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/get_rotation/). Przykład otwiera `template.pptx` i kopiuje orientację kamery z pierwszego kształtu na pierwszym slajdzie do drugiego kształtu. Oba kształty mają już oświetlenie 3D, a drugi kształt nie ma explicite ustawionego obrotu kamery.

Kąty podane są w stopniach. Indeksy `0`, `1` i `2` zawierają odpowiednio szerokość, długość i obrót. Przekaż je do [set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/) w tej kolejności. Jeśli źródło nie ma explicite obrotu, `get_rotation` zwraca `None`, więc pozostaw docelowe kąty nieustawione. Jeśli źródło explicite ustawi wszystkie trzy kąty na zero, skopiuj te zera.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    shapes = presentation.slides[0].shapes
    
    source_camera = shapes[0].three_d_format.camera
    destination_camera = shapes[1].three_d_format.camera

    destination_camera.camera_type = source_camera.camera_type
    angles = source_camera.get_rotation()
    if angles is not None:
        destination_camera.set_rotation(angles[0], angles[1], angles[2])

    presentation.save("camera-copy.pptx", slides.export.SaveFormat.PPTX)
```

Gdy ponownie otworzysz `camera-copy.pptx` w PowerPoint, oba kształty będą miały ten sam preset kamery i obrót. Strzałka po prawej używa orientacji skopiowanej z prostokąta po lewej. Oba kształty używają tego samego oświetlenia i głębokości wyciągania.

![Niebieski prostokąt 3D i strzałka w prawo z dopasowaną orientacją kamery, widziane z góry i z prawej strony](camera-orientation.png)

## **Dodaj wyciąganie i głębokość**

Wyciąganie sprawia, że kształt wygląda na gruby, wydłużając go za przednią powierzchnię. W PowerPoint kontrolka głębokości ustawia tę widoczną grubość, a kontrolka koloru ustawia kolor bocznych powierzchni.

![Kontrolki głębokości PowerPoint powiązane z właściwościami koloru wyciągania i wysokości wyciągania](img_02_02.png)

Ustaw [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) dla grubości i [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) dla koloru boków. Ten przykład nadaje prostokątowi wyciąganie 100 punktów z fioletowymi bokami i obraca kamerę, aby ukazać jego grubość. Konfiguruje kształt w pamięci bez zapisywania pliku:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

Właściwość [ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) ustawia głębokość obiektu 3D. Właściwość [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) kontroluje wysokość efektu wyciągania, jak pokazano w tym przykładzie.

## **Użyj wypełnień gradientowych lub obrazkowych z efektami 3D**

Formatowanie 3D jest niezależne od wypełnienia kształtu. Możesz zastosować jednolity kolor, gradient, wzór lub wypełnienie obrazkiem na przedniej powierzchni i nadal używać tych samych ustawień kamery, światła, materiału i wyciągania.

Ten przykład stosuje gradient od niebieskiego do pomarańczowego na przedniej powierzchni oraz ciemnopomarańczowy kolor dla wyciągania 150 punktów. Punkty stopu gradientu 0 i 100 oznaczają początek i koniec gradientu. Wartości obrotu kamery podane są w stopniach. Slajd jest renderowany do obrazu PNG w podwójnych wymiarach domyślnych:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)

    shape.text_frame.text = "3D Gradient"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_stops.add(0, drawing.Color.blue)
    shape.fill_format.gradient_format.gradient_stops.add(100, drawing.Color.orange)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("gradient_3d.png")
```

![Renderowany prostokąt 3D z wypełnieniem gradientowym od niebieskiego do pomarańczowego oraz pomarańczowym wyciąganiem](img_02_03.png)

Aby zamiast tego użyć wypełnienia obrazkiem, dodaj obraz do prezentacji i przypisz go jako wypełnienie kształtu. Ten przykład wymaga istniejącego pliku o nazwie „image.jpg” w katalogu roboczym. Rozciąga obraz, aby wypełnić prostokąt, stosuje wyciąganie 150 punktów i ustawia obrót kamery w stopniach. Konfiguruje kształt w pamięci bez zapisywania ani renderowania pliku:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)

    image = presentation.images.add_image(image_data)

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = image
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

![Renderowany prostokąt 3D z wypełnieniem zdjęciem na przedniej powierzchni i pomarańczowym wyciąganiem](img_02_04.png)

## **Zastosuj formatowanie 3D do tekstu**

Formatowanie 3D kształtu wpływa na ciało kształtu. Formatowanie 3D tekstu wpływa na ramkę tekstową. Jest to przydatne przy efektach podobnych do WordArt, gdzie same litery potrzebują wyciągania, materiału, oświetlenia i ustawień kamery.

Poniższy przykład tworzy tekst z pomarańczowo-białym wzorem siatki, stosuje wstępny łuk i konfiguruje ustawienia 3D poprzez [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/). Wysokość wyciągania i głębokość podane są w punktach, a obrót światła w stopniach. Wypełnienie i kontur kształtu są ukryte, tak aby widoczny był tylko tekst. Przykład renderuje obraz PNG w podwójnych wymiarach domyślnego slajdu i zapisuje prezentację jako PPTX:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.text = "3D Text"

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = drawing.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = drawing.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.LARGE_GRID

    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 128

    text_frame_format = shape.text_frame.text_frame_format
    text_frame_format.transform = slides.TextShapeType.ARCH_UP
    text_frame_format.three_d_format.extrusion_height = 3.5
    text_frame_format.three_d_format.depth = 3
    text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC
    text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)
    text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("text_3d.png")

    presentation.save("text_3d.pptx", slides.export.SaveFormat.PPTX)
```

![Renderowany tekst 3D z łukowatą transformacją WordArt, pomarańczowym wypełnieniem wzorem i ciemnym wyciąganiem](img_02_05.png)

## **Utrzymaj tekst płaski na kształcie 3D**

Aby utrzymać czytelny tekst, zachowując jednocześnie wygląd 3D kształtu, ustaw [TextFrameFormat.keep_text_flat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/keep_text_flat/) poprzez [TextFrame.text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/text_frame_format/). Gdy wartość jest `True`, tekst pozostaje poza sceną 3D. Gdy jest `False`, tekst uczestniczy w scenie i podąża za jej orientacją 3D.

To ustawienie nie usuwa formatowania 3D kształtu: jego kamera, oświetlenie, materiał i wyciąganie pozostają skonfigurowane poprzez [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/). Jest to także inne niż zwykły obrót. [Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) obraca kształt w płaszczyźnie slajdu, podczas gdy [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) kontroluje niestandardowy obrót tekstu w jego ramce. Utrzymanie tekstu poza sceną 3D nie resetuje żadnego z tych kątów.

Poniższy samodzielny przykład tworzy niebieski prostokąt z tekstem i klonuje go obok oryginału. Oba kształty mają identyczne formatowanie 3D; różni się jedynie ustawienie tekstu: `False` po lewej i `True` po prawej. Kąty kamery podane są w stopniach, a wysokość wyciągania wynosi 40 punktów. Przykład zapisuje prezentację jako PPTX i renderuje slajd porównawczy do PNG w podwójnych wymiarach domyślnych.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 70, 160, 240, 140)

    shape.text_frame.text = "Readable text"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 28
    shape.text_frame.paragraphs[0].paragraph_format.alignment = slides.TextAlignment.CENTER
    shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.CENTER
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(30, 30, 0)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 40
    shape.three_d_format.extrusion_color.color = drawing.Color.royal_blue
    shape.text_frame.text_frame_format.keep_text_flat = False

    flat_text_shape = slide.shapes.add_clone(shape, 400, 160)
    flat_text_shape.text_frame.text_frame_format.keep_text_flat = True

    presentation.save("keep_text_flat.pptx", slides.export.SaveFormat.PPTX)
    with slide.get_image(2, 2) as image:
        image.save("keep_text_flat.png")
```

Po lewej tekst podąża za orientacją 3D. Po prawej pozostaje płaski i łatwiejszy do odczytania. Oba prostokąty zachowują tę samą widoczną głębokość wyciągania i orientację 3D.

![Prostokąty 3D obok siebie: keep_text_flat jest False po lewej i True po prawej](keep_text_flat.png)

## **Zachowanie eksportu i renderowania**

Aspose.Slides zachowuje formatowanie 3D przy zapisywaniu do formatów PowerPoint, takich jak PPTX. Podczas renderowania lub eksportu do formatów o stałym układzie, scena 3D jest rasteryzowana lub rysowana w wyjściu jako rezultat 2D. Dotyczy to renderowania slajdów do [PNG](/slides/pl/python-net/convert-powerpoint-to-png/), eksportu do [PDF](/slides/pl/python-net/convert-powerpoint-to-pdf/), eksportu do [HTML](/slides/pl/python-net/convert-powerpoint-to-html/), lub generowania klatek do [video conversion](/slides/pl/python-net/convert-powerpoint-to-video/).

Pamiętaj o następujących kwestiach:

- Eksportowane obrazy i pliki PDF nie są interaktywne. Obiekt nie może być obracany przez użytkownika po eksporcie.
- Ostateczny wygląd zależy od kombinacji kamery, zestawu świateł, materiału, wyciągania, wypełnienia i skalowania slajdu.
- Jeśli potrzebujesz przejrzeć odziedziczone lub oparte na temacie wartości formatowania, odczytaj [efektywne właściwości kształtu](/slides/pl/python-net/shape-effective-properties/).
- Niektóre formaty wyjściowe nie mogą przechowywać edytowalnego formatowania 3D PowerPoint. W tych formatach wynik wizualny jest renderowany, a nie zachowywany jako edytowalne ustawienia 3D.

## **FAQ**

**Czy Aspose.Slides może tworzyć interaktywne prezentacje 3D?**

Aspose.Slides tworzy i renderuje efekty 3D PowerPoint dla kształtów i tekstu. Nie zamienia eksportowanych obrazów, plików PDF ani stron HTML w interaktywne sceny 3D, które użytkownik mógłby obracać. W PPTX formatowanie 3D pozostaje edytowalne w PowerPoint, o ile format to umożliwia.

**Jaka jest różnica między modelem 3D a efektem 3D?**

Model 3D to oddzielny obiekt 3D wstawiany do prezentacji. Efekt 3D to formatowanie zastosowane do zwykłego kształtu lub tekstu w PowerPoint, takie jak obrót, wyciąganie, fazet, oświetlenie i materiał. Ten artykuł opisuje efekty 3D.

**Jakie ustawienia są wymagane dla widocznego kształtu 3D?**

Co najmniej należy ustawić obrót kamery oraz wyciąganie lub głębokość. W praktyce warto także ustawić zestaw świateł i materiał, aby renderowane powierzchnie miały wyraźne podświetlenia i cienie.

**Czy mogę zastosować efekty 3D zarówno do kształtów, jak i tekstu?**

Tak. Use [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) for the shape body and [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/) for text.

**Czy efekty 3D będą widoczne przy eksporcie do obrazów, PDF, HTML lub klatek wideo?**

Tak. Aspose.Slides renderuje efekty 3D przy tworzeniu obrazów slajdów, wyjścia PDF, wyjścia HTML oraz klatek używanych przy konwersji wideo. Wyeksportowany plik zawiera wyrenderowany wygląd, a nie edytowalny obiekt 3D.

**Czy mogę odczytać końcowe wartości 3D po zastosowaniu dziedziczenia i ustawień motywu?**

Tak. Użyj API formatowania efektywnego opisanych w [efektywne właściwości kształtu](/slides/pl/python-net/shape-effective-properties/), aby odczytać ostateczne wartości kamery, zestawu świateł, fazetu i powiązane wartości 3D.