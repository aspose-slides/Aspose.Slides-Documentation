---
title: Utwórz efekty 3D w prezentacjach przy użyciu Pythona
linktitle: Prezentacja 3D
type: docs
weight: 232
url: /pl/python-net/3d-presentation/
keywords:
- 3D PowerPoint
- prezentacja 3D
- obrót 3D
- głębokość 3D
- ekstruzja 3D
- gradient 3D
- tekst 3D
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Zastosuj i renderuj efekty 3D dla kształtów i tekstu PowerPoint w Pythonie przy użyciu Aspose.Slides. Konfiguruj kamerę, oświetlenie, materiał, ekstruzję, wypełnienia i tekst 3D."
---
## **Przegląd**

Aspose.Slides for Python via .NET może tworzyć, edytować, zachowywać i renderować formatowanie 3D w stylu PowerPoint dla kształtów i tekstu. Ten artykuł opisuje efekty 3D, takie jak obrót, ekstruzja, fazowanie, oświetlenie, materiał, wypełnienia gradientowe lub obrazkowe oraz tekst 3D.

{{% alert color="primary" %}}
Ten artykuł dotyczy efektów formatowania 3D na kształtach i tekście w PowerPoint. Nie dotyczy wstawiania ani edytowania samodzielnych plików modeli 3D. Gdy eksportujesz slajd do obrazu, PDF lub HTML, Aspose.Slides renderuje te efekty 3D w wyjściowym 2D.
{{% /alert %}}

## **Koncepcje formatowania 3D**

Użyj właściwości [Shape.three_d_format](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/three_d_format/), aby zastosować formatowanie 3D do kształtu. Właściwość udostępnia [ThreeDFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/threedformat/), które kontroluje scenę 3D dla tego kształtu.

Dla tekstu użyj właściwości [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframeformat/three_d_format/). Stosuje ona formatowanie 3D do ramki tekstowej zamiast do treści kształtu.

Najważniejsze właściwości to:

| Właściwość | Co kontroluje | Kiedy używać |
|---|---|---|
| [camera](https://reference.aspose.com/slides/pl/python-net/aspose.slides/threedformat/camera/) | Punkt widzenia, predefiniowany typ kamery, obrót, zoom i perspektywa. | Obrócić obiekt w przestrzeni 3D lub dopasować do predefiniowanego obrotu 3D w PowerPoint. |
| [light_rig](https://reference.aspose.com/slides/pl/python-net/aspose.slides/threedformat/light_rig/) | Predefiniowane oświetlenie, kierunek i obrót światła. | Zmienić sposób, w jaki podświetlenia i cienie pojawiają się na powierzchni 3D. |
| [material](https://reference.aspose.com/slides/pl/python-net/aspose.slides/threedformat/material/) | Materiał powierzchni, np. płaski, matowy, plastikowy lub metalowy. | Sprawić, że ta sama geometria będzie wyglądać płasko, miękko, błyszcząco lub metalicznie. |
| [extrusion_height](https://reference.aspose.com/slides/pl/python-net/aspose.slides/threedformat/extrusion_height/) | Jak daleko kształt wystaje w tył od swojej przedniej powierzchni. | Przemienić płaski kształt w widocznie grubą bryłę 3D. |
| [extrusion_color](https://reference.aspose.com/slides/pl/python-net/aspose.slides/threedformat/extrusion_color/) | Kolor ekstruzowanych boków. | Uwidocznić głębokość lub dopasować kolor boków do wypełnienia przodu. |
| [depth](https://reference.aspose.com/slides/pl/python-net/aspose.slides/threedformat/depth/) | Dodatkowa głębokość 3D używana w formatowaniu 3D PowerPoint. | Dostrajać głębokość dla kształtów lub tekstu, szczególnie wraz z ustawieniami fazowania i materiału. |
| [bevel_top](https://reference.aspose.com/slides/pl/python-net/aspose.slides/threedformat/bevel_top/) and [bevel_bottom](https://reference.aspose.com/slides/pl/python-net/aspose.slides/threedformat/bevel_bottom/) | Podniesione lub zaokrąglone krawędzie na przedniej i tylnej powierzchni. | Dodać złagodzoną lub formowaną krawędź zamiast ostrej płaskiej powierzchni. |
| [contour_color](https://reference.aspose.com/slides/pl/python-net/aspose.slides/threedformat/contour_color/) and [contour_width](https://reference.aspose.com/slides/pl/python-net/aspose.slides/threedformat/contour_width/) | Kontur wokół obiektu 3D. | Podkreślić granicę obiektu w renderowanym obrazie. |

## **Utwórz kształt 3D**

Kształt zwykle wymaga czterech rodzajów ustawień, aby wyglądał przekonująco 3D:

- Ustawienia kamery, ponieważ domyślny widok przedni może ukrywać ekstruzję.
- Ustawienia oświetlenia, ponieważ oświetlenie sprawia, że powierzchnie i boki są widoczne.
- Ustawienia materiału, ponieważ powierzchnia wpływa na sposób renderowania światła.
- Ustawienia ekstruzji lub głębokości, ponieważ płaski kształt wymaga grubości.

Poniższy przykład tworzy prostokąt, dodaje tekst do jego przedniej powierzchni, stosuje formatowanie 3D, zapisuje prezentację jako PPTX i renderuje slajd do obrazu PNG.

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

Renderowany obraz slajdu przedstawia prostokąt jako grubą bryłę 3D:

![Renderowany niebieski prostokąt 3D z białym tekstem 3D na przedniej powierzchni](img_01_01.png)

## **Obróć kształt za pomocą kamery**

W PowerPoint rotacja 3D jest konfigurowana z panelu 3‑D Rotation. Wartości rotacji X, Y i Z odpowiadają obrotowi ustawionemu za pomocą interfejsu API kamery.

![Panel 3‑D Rotation w PowerPoint z wyróżnionymi wartościami rotacji X, Y i Z](img_02_01.png)

W Aspose.Slides ustaw typ kamery i obrót za pomocą [ThreeDFormat.camera](https://reference.aspose.com/slides/pl/python-net/aspose.slides/threedformat/camera/):

```py
shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Użyj kamery, gdy potrzebujesz zmienić sposób, w jaki widz widzi obiekt. Nie zmienia ona geometrii 2D kształtu na slajdzie. Zmienia punkt widzenia 3D używany przez PowerPoint i przez Aspose.Slides podczas renderowania.

## **Dodaj ekstruzję i głębokość**

Ekstruzja sprawia, że kształt wygląda na gruby, wydłużając go za przednią powierzchnią. W PowerPoint kontrolka głębokości ustawia tę widoczną grubość, a kontrolka koloru określa kolor bocznych powierzchni.

![Kontrolki głębokości w PowerPoint powiązane z właściwościami koloru ekstruzji i wysokości ekstruzji](img_02_02.png)

Ustaw [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/pl/python-net/aspose.slides/threedformat/extrusion_height/) dla grubości i [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/pl/python-net/aspose.slides/threedformat/extrusion_color/) dla koloru boków:

```py
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

Użyj [ThreeDFormat.depth](https://reference.aspose.com/slides/pl/python-net/aspose.slides/threedformat/depth/), gdy potrzebujesz bezpośrednio pracować z wartością głębokości w PowerPoint lub połączyć głębokość z fazowaniem, materiałem i efektami tekstu. W wielu scenariuszach kształtu, [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/pl/python-net/aspose.slides/threedformat/extrusion_height/) jest jaśniejszym ustawieniem, ponieważ bezpośrednio określa widoczną ekstruzję.

## **Użyj wypełnień gradientowych lub obrazkowych z efektami 3D**

Formatowanie 3D jest niezależne od wypełnienia kształtu. Możesz zastosować jednolity kolor, gradient, wzór lub wypełnienie obrazem na przedniej powierzchni i nadal używać tych samych ustawień kamery, oświetlenia, materiału i ekstruzji.

Ten przykład stosuje wypełnienie gradientowe do kształtu oraz ciemniejszy kolor ekstruzji na bokach:

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

Renderowany wynik zachowuje gradient na przedniej powierzchni i renderuje ekstruzję osobno:

![Renderowany prostokąt 3D z wypełnieniem gradientowym od niebieskiego do pomarańczowego oraz pomarańczową ekstruzją](img_02_03.png)

Aby zamiast tego użyć wypełnienia obrazem, dodaj obraz do prezentacji i przypisz go jako wypełnienie kształtu:

```py
with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

image = presentation.images.add_image(image_data)

shape.fill_format.fill_type = slides.FillType.PICTURE
shape.fill_format.picture_fill_format.picture.image = image
shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

shape.three_d_format.camera.set_rotation(10, 20, 30)
shape.three_d_format.extrusion_height = 150
shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

Obraz jest renderowany na przedniej powierzchni, podczas gdy ekstruzja jest renderowana jako 3D‑owa powierzchnia boczna:

![Renderowany prostokąt 3D z wypełnieniem zdjęciem na przedniej powierzchni i pomarańczową ekstruzją](img_02_04.png)

## **Zastosuj formatowanie 3D do tekstu**

Formatowanie 3D kształtu wpływa na treść kształtu. Formatowanie 3D tekstu wpływa na ramkę tekstową. Jest to przydatne w efektach podobnych do WordArt, gdzie same litery wymagają ekstruzji, materiału, oświetlenia i ustawień kamery.

Poniższy przykład tworzy tekst z wypełnieniem wzorem, stosuje transformację WordArt i konfiguruje ustawienia 3D w [TextFrameFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframeformat/):

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

Tekst jest renderowany jako zakrzywione, ekstruzowane litery 3D:

![Renderowany tekst 3D z wygiętą transformacją WordArt, pomarańczowym wypełnieniem wzorem i ciemną ekstruzją](img_02_05.png)

## **Zachowanie eksportu i renderowania**

Aspose.Slides zachowuje formatowanie 3D przy zapisywaniu do formatów PowerPoint, takich jak PPTX. Podczas renderowania lub eksportu do formatów o stałym układzie scena 3D jest rastrowana lub rysowana do wyjścia jako wynik 2D. Dotyczy to renderowania slajdów do [PNG](/slides/pl/python-net/convert-powerpoint-to-png/), eksportu do [PDF](/slides/pl/python-net/convert-powerpoint-to-pdf/), eksportu do [HTML](/slides/pl/python-net/convert-powerpoint-to-html/), lub generowania klatek dla [video conversion](/slides/pl/python-net/convert-powerpoint-to-video/).

Pamiętaj o następujących punktach:

- Eksportowane obrazy i pliki PDF nie są interaktywne. Obiekt nie może być obracany przez widza po eksporcie.
- Ostateczny wygląd zależy od kombinacji kamery, zestawu oświetlenia, materiału, ekstruzji, wypełnienia i skalowania slajdu.
- Jeśli musisz sprawdzić odziedziczone lub oparte na motywie wartości formatowania, przeczytaj [effective shape properties](/slides/pl/python-net/shape-effective-properties/).
- Niektóre formaty wyjściowe nie mogą przechowywać edytowalnego formatowania 3D PowerPoint. W tych formatach wynik wizualny jest renderowany, a nie zachowywany jako edytowalny obiekt 3D.

## **FAQ**

**Czy Aspose.Slides może tworzyć interaktywne prezentacje 3D?**

Aspose.Slides tworzy i renderuje efekty 3D PowerPoint dla kształtów i tekstu. Nie powoduje, że wyeksportowane obrazy, pliki PDF ani strony HTML są interaktywnymi scenami 3D, które widz może obracać. W PPTX formatowanie 3D pozostaje edytowalne w PowerPoint, o ile format to obsługuje.

**Jaka jest różnica między modelem 3D a efektem 3D?**

Model 3D to oddzielny obiekt 3D wstawiany do prezentacji. Efekt 3D to formatowanie zastosowane do zwykłego kształtu lub tekstu PowerPoint, takie jak obrót, ekstruzja, fazowanie, oświetlenie i materiał. Ten artykuł opisuje efekty 3D.

**Jakie ustawienia są wymagane, aby kształt 3D był widoczny?**

Co najmniej ustaw obrót kamery oraz ekstruzję lub głębokość. W praktyce warto także ustawić zestaw oświetlenia i materiał, aby renderowane powierzchnie miały wyraźne refleksy i cienie.

**Czy mogę zastosować efekty 3D zarówno do kształtów, jak i tekstu?**

Tak. Użyj [Shape.three_d_format](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/three_d_format/) dla treści kształtu oraz [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframeformat/three_d_format/) dla tekstu.

**Czy efekty 3D pojawią się przy eksporcie do obrazów, PDF, HTML lub klatek wideo?**

Tak. Aspose.Slides renderuje efekty 3D przy generowaniu obrazów slajdów, wyjścia PDF, wyjścia HTML oraz klatek używanych przy konwersji wideo. Wyeksportowany wynik zawiera wyrenderowany wygląd, a nie edytowalny obiekt 3D.

**Czy mogę odczytać ostateczne wartości 3D po zastosowaniu dziedziczenia i ustawień motywu?**

Tak. Użyj interfejsów API efektywnego formatowania opisanych w [Shape Effective Properties](/slides/pl/python-net/shape-effective-properties/), aby odczytać ostateczne wartości kamery, zestawu oświetlenia, fazowania i powiązane wartości 3D.