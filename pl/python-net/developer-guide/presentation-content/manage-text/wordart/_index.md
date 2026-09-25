---
title: Utwórz i zastosuj efekty WordArt w Pythonie
linktitle: WordArt
type: docs
weight: 110
url: /pl/python-net/wordart/
keywords:
- WordArt
- tworzenie WordArt
- szablon WordArt
- efekt WordArt
- efekt cienia
- efekt odbicia
- efekt poświaty
- przekształcenie WordArt
- efekt 3D
- efekt zewnętrznego cienia
- efekt wewnętrznego cienia
- Python
- Aspose.Slides
description: "Utwórz i dostosuj efekty WordArt w Aspose.Slides for Python via .NET. Ten przewodnik krok po kroku pomaga programistom ulepszyć prezentacje profesjonalnym tekstem w Pythonie."
---
## **Przegląd**

Efekty WordArt pozwalają stylizować tekst za pomocą wypełnień, konturów, cieni, odbić, poświaty, przekształceń i formatowania 3D. Ten artykuł wyjaśnia, jak tworzyć i dostosowywać te efekty w prezentacjach PowerPoint przy użyciu Aspose.Slides for Python via .NET, bez zainstalowanego Microsoft Office.

## **Utworzenie prostego szablonu WordArt i zastosowanie go do tekstu**

Poniższe przykłady tworzą prosty styl WordArt, ustawiając tekst, czcionkę, wypełnienie wzorem i obrys.  
Każdy przykład tworzy nową prezentację i dodaje prostokąt do pierwszego slajdu; nie jest wymagany żaden plik wejściowy. Pierwszy przykład ustawia tekst na "Aspose.Slides". Pozycja i wymiary kształtu są mierzone w punktach:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    text_frame = auto_shape.text_frame

    portion = text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
```

Ustaw czcionkę na Arial Black o rozmiarze 36 punktów, aby formatowanie było bardziej widoczne:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36
```

Zastosuj wzór [SMALL_GRID](https://reference.aspose.com/slides/pl/python-net/aspose.slides/patternstyle/) z ciemnopomarańczowym pierwszym planem i białym tłem, a następnie dodaj czarny obrys tekstu o szerokości 1 punktu:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID

    portion.portion_format.line_format.width = 1
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```

Resultujący tekst:

![Prosty szablon WordArt](WordArt_template.png)

## **Zastosowanie innych efektów WordArt**

Poniższe przykłady pokazują, jak zastosować cienie, odbicia, poświatę, przekształcenia i efekty 3D do tekstu.

### **Zastosowanie efektu zewnętrznego cienia**

Zewnętrzny cień dodaje głębię, umieszczając cień za tekstem. Możesz dostosować jego kolor, kierunek, odległość, promień rozmycia, skalowanie i pochylenie.  
Ten przykład wywołuje [enable_outer_shadow_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides/effectformat/enable_outer_shadow_effect/) i ustawia czarny cień o promieniu rozmycia 4 punkty, kierunku 230 stopni i odległości 30 punktów. Wartości skali 100 zachowują rozmiar cienia, a pochylenie poziome przechyla go o 20 stopni. Transformacja alfa ustawia jego przezroczystość na 32%:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_outer_shadow_effect()
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.black
    portion.portion_format.effect_format.outer_shadow_effect.scale_horizontal = 100
    portion.portion_format.effect_format.outer_shadow_effect.scale_vertical = 100
    portion.portion_format.effect_format.outer_shadow_effect.blur_radius = 4
    portion.portion_format.effect_format.outer_shadow_effect.direction = 230
    portion.portion_format.effect_format.outer_shadow_effect.distance = 30
    portion.portion_format.effect_format.outer_shadow_effect.skew_horizontal = 20
    portion.portion_format.effect_format.outer_shadow_effect.skew_vertical = 0
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.32)
```

Resultujący tekst:

![Efekt zewnętrznego cienia](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Gdy zewnętrzne i wstępnie ustawione cienie są używane razem, stosowany jest tylko zewnętrzny cień.
- Jeśli jednocześnie używane są cienie zewnętrzne i wewnętrzne, wynikowy efekt zależy od wersji PowerPoint. Na przykład w PowerPoint 2013 efekt jest podwojony, podczas gdy w PowerPoint 2007 stosowany jest tylko zewnętrzny cień.
{{% /alert %}}

### **Zastosowanie efektu odbicia**

Odbicie tworzy lustrzaną kopię tekstu. Dostosuj jego pozycję, skalę, rozmycie i przezroczystość, aby kontrolować wygląd.  
Ten przykład wywołuje [enable_reflection_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides/effectformat/enable_reflection_effect/) i odwraca odbicie w pionie ze skalą -100%. Używa promienia rozmycia 0,5 punktu i odległości 4,72 punktu. Przezroczystość zmniejsza się z 60% do 0,9% między pozycjami 0% a 60% wzdłuż odbicia:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_reflection_effect()
    portion.portion_format.effect_format.reflection_effect.blur_radius = 0.5
    portion.portion_format.effect_format.reflection_effect.distance = 4.72
    portion.portion_format.effect_format.reflection_effect.start_pos_alpha = 0
    portion.portion_format.effect_format.reflection_effect.end_pos_alpha = 60
    portion.portion_format.effect_format.reflection_effect.direction = 90
    portion.portion_format.effect_format.reflection_effect.scale_horizontal = 100
    portion.portion_format.effect_format.reflection_effect.scale_vertical = -100
    portion.portion_format.effect_format.reflection_effect.start_reflection_opacity = 60
    portion.portion_format.effect_format.reflection_effect.end_reflection_opacity = 0.9
    portion.portion_format.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM_LEFT
```

Resultujący tekst:

![Efekt odbicia](reflection_effect.png)

### **Zastosowanie efektu poświaty**

Poświata dodaje miękki, kolorowy obrys wokół tekstu. Dostosuj jej kolor, przezroczystość i promień, aby kontrolować efekt.  
Ten przykład wywołuje [enable_glow_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides/effectformat/enable_glow_effect/) i stosuje czerwoną poświatę z 54% przezroczystością i promieniem 7 punktów:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.color = draw.Color.red
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

Resultujący tekst:

![Efekt poświaty](glow_effect.png)

### **Zastosowanie przekształceń WordArt**

Przekształcenia WordArt wyginają, rozciągają lub deformują blok tekstu.  
Ustaw [transform](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframeformat/transform/) na [ARCH_UP_POUR](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textshapetype/), aby zakrzywić cały ramkę tekstową w górę:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    text_frame = auto_shape.text_frame
    text_frame.text = "Aspose.Slides"
    text_frame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

Resultujący tekst:

![Przekształcenie WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via .NET udostępnia zestaw wstępnie zdefiniowanych [typów przekształceń](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textshapetype/).
{{% /alert %}}

### **Zastosowanie efektów 3D do kształtów i tekstu**

Możesz zastosować efekty 3D do kształtu lub jego tekstu. Krawędzie, ekstruzja, oświetlenie i ustawienia kamery kontrolują wynikowy wygląd.  
Poniższy przykład używa [ThreeDFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/threedformat/), aby dodać okrągłe krawędzie, pomarańczową ekstruzję i ciemnoczerwony kontur do prostokąta. Wymiary krawędzi, wysokość ekstruzji, szerokość konturu i głębokość są mierzone w punktach. Materiał plastikowy, zrównoważone oświetlenie obrócone o 40 stopni wokół osi Z oraz kamera perspektywiczna definiują jego wygląd:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    auto_shape.text_frame.text = "Aspose.Slides"

    auto_shape.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    auto_shape.three_d_format.bevel_bottom.height = 10.5
    auto_shape.three_d_format.bevel_bottom.width = 10.5

    auto_shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    auto_shape.three_d_format.bevel_top.height = 12.5
    auto_shape.three_d_format.bevel_top.width = 11

    auto_shape.three_d_format.extrusion_color.color = draw.Color.orange
    auto_shape.three_d_format.extrusion_height = 6

    auto_shape.three_d_format.contour_color.color = draw.Color.dark_red
    auto_shape.three_d_format.contour_width = 1.5

    auto_shape.three_d_format.depth = 3

    auto_shape.three_d_format.material = slides.MaterialPresetType.PLASTIC

    auto_shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    auto_shape.three_d_format.light_rig.set_rotation(0, 0, 40)

    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

Resultujący kształt:

![Efekt 3D kształtu](shape_3D_effect.png)

Ten przykład stosuje podobne formatowanie 3D do tekstu za pomocą [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframeformat/three_d_format/). Mniejsze krawędzie formują krawędzie liter, a ekstruzja i oświetlenie nadają tekstowi głębię:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    text_frame = auto_shape.text_frame
    text_frame.text = "Aspose.Slides"

    text_frame.text_frame_format.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    text_frame.text_frame_format.three_d_format.bevel_bottom.height = 3.5
    text_frame.text_frame_format.three_d_format.bevel_bottom.width = 3.5

    text_frame.text_frame_format.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    text_frame.text_frame_format.three_d_format.bevel_top.height = 4
    text_frame.text_frame_format.three_d_format.bevel_top.width = 4

    text_frame.text_frame_format.three_d_format.extrusion_color.color = draw.Color.orange
    text_frame.text_frame_format.three_d_format.extrusion_height = 6

    text_frame.text_frame_format.three_d_format.contour_color.color = draw.Color.dark_red
    text_frame.text_frame_format.three_d_format.contour_width = 1.5

    text_frame.text_frame_format.three_d_format.depth = 3

    text_frame.text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC

    text_frame.text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame.text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame.text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)

    text_frame.text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

Resultujący tekst:

![Efekt 3D tekstu](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Stosowanie efektów 3D do tekstu lub ich kształtów — oraz interakcja pomiędzy tymi efektami — podlega określonym regułom. Rozważ scenę obejmującą zarówno tekst, jak i kształt go zawierający. Efekt 3D obejmuje trójwymiarową reprezentację obiektu oraz scenę, w której jest umieszczony.

- Jeśli scena jest ustawiona zarówno dla kształtu, jak i dla tekstu, priorytet ma scena kształtu, a scena tekstu jest ignorowana.
- Jeśli kształt nie ma własnej sceny, ale posiada reprezentację 3D, używana jest scena tekstu.
- Jeśli kształt nie ma żadnego efektu 3D, traktowany jest jako płaski, a efekt 3D stosowany jest wyłącznie do tekstu.

Zachowania te odnoszą się do właściwości [ThreeDFormat.light_rig](https://reference.aspose.com/slides/pl/python-net/aspose.slides/threedformat/light_rig/) i [ThreeDFormat.camera](https://reference.aspose.com/slides/pl/python-net/aspose.slides/threedformat/camera/).
{{% /alert %}}

Aby utrzymać tekst płaski i czytelny, zachowując jednocześnie formatowanie 3D kształtu, zobacz [Keep Text Flat on a 3D Shape](/slides/pl/python-net/3d-presentation/) po porównaniu obu ustawień i pełnym przykładzie w Pythonie.

## **FAQ**

**Czy mogę używać efektów WordArt z różnymi czcionkami lub skryptami (np. arabski, chiński)?**  

Tak, Aspose.Slides for Python via .NET obsługuje Unicode i działa ze wszystkimi głównymi czcionkami i skryptami. Efekty WordArt, takie jak cień, wypełnienie i obrys, mogą być stosowane niezależnie od języka, choć dostępność czcionek i renderowanie mogą zależeć od czcionek systemowych.

**Czy mogę zastosować efekty WordArt do elementów mastera slajdu?**  

Tak, możesz stosować efekty WordArt do kształtów na slajdach master, w tym do pól tekstowych tytułu, stopek lub tekstu w tle. Zmiany w układzie master będą odzwierciedlone we wszystkich powiązanych slajdach.

**Czy efekty WordArt wpływają na rozmiar pliku prezentacji?**  

Nieznacznie. Efekty WordArt, takie jak cienie, poświaty i gradientowe wypełnienia, mogą nieco zwiększyć rozmiar pliku ze względu na dodatkowe metadane formatowania, ale różnica jest zazwyczaj pomijalna.

**Czy mogę podglądać rezultat efektów WordArt bez zapisywania prezentacji?**  

Tak, możesz renderować slajdy zawierające WordArt do obrazów (np. PNG, JPEG) za pomocą [Slide.get_image](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/get_image/), lub renderować pojedyncze kształty za pomocą [Shape.get_image](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/get_image/). Pozwala to podglądać rezultat w pamięci lub na ekranie przed zapisaniem lub wyeksportowaniem całej prezentacji.