---
title: Tworzenie i stosowanie efektów WordArt w Pythonie
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
- efekt wyświetlania
- efekt poświaty
- transformacja WordArt
- efekt 3D
- efekt zewnętrznego cienia
- efekt wewnętrznego cienia
- Python
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i dostosowywać efekty WordArt w Aspose.Slides dla Pythona przez .NET. Ten przewodnik krok po kroku pomaga programistom ulepszyć prezentacje stylowym, profesjonalnym tekstem w Pythonie."
---
## **Przegląd**

Efekty WordArt pozwalają dodać wizualnie atrakcyjny, stylizowany tekst do prezentacji PowerPoint. Dzięki Aspose.Slides programiści mogą programowo tworzyć, dostosowywać i zarządzać WordArt tak jak w Microsoft PowerPoint — bez konieczności instalacji Office. Ten artykuł zawiera przegląd pracy z WordArt, w tym jak stosować transformacje tekstu, style wypełnień, kontury, cienie i inne opcje formatowania, aby treść prezentacji była bardziej ekspresyjna i angażująca. WordArt umożliwia traktowanie tekstu jako obiektu graficznego. Składa się z efektów lub specjalnych modyfikacji stosowanych do tekstu, aby uczynić go bardziej atrakcyjnym lub zauważalnym.

**WordArt w Microsoft PowerPoint**

Aby używać WordArt w Microsoft PowerPoint, należy wybrać jeden z wstępnie zdefiniowanych szablonów WordArt. Szablon WordArt to zestaw efektów, które są stosowane do tekstu lub jego kształtu.

**WordArt w Aspose.Slides**

W Aspose.Slides dla Pythona przez .NET 20.10 wdrożyliśmy obsługę WordArt i w kolejnych wydaniach Aspose.Slides dla Pythona przez .NET wprowadziliśmy ulepszenia tej funkcji.

Dzięki Aspose.Slides dla Pythona przez .NET możesz łatwo utworzyć własny szablon WordArt (pojedynczy efekt lub kombinację efektów) w Pythonie i zastosować go do tekstów.

## Tworzenie prostego szablonu WordArt i zastosowanie go do tekstu

**Użycie Aspose.Slides** 

Najpierw tworzymy prosty tekst przy użyciu tego kodu Pythona:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    textFrame = autoShape.text_frame

    portion = textFrame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"

    pres.save("wordart-1.pptx", slides.export.SaveFormat.PPTX)
```
Teraz ustawiamy wysokość czcionki tekstu na większą wartość, aby efekt był bardziej widoczny, za pomocą tego kodu:

```py 
    fontData = slides.FontData("Arial Black")
    portion.portion_format.latin_font = fontData
    portion.portion_format.font_height = 36
```

**Użycie Microsoft PowerPoint**

Przejdź do menu efektów WordArt w Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Z menu po prawej możesz wybrać wstępnie zdefiniowany efekt WordArt. Z menu po lewej możesz określić ustawienia nowego WordArt.

Oto niektóre dostępne parametry lub opcje:

![todo:image_alt_text](image-20200930114015-3.png)

**Użycie Aspose.Slides**

Tutaj stosujemy kolor wzoru SmallGrid do tekstu i dodajemy czarną obwódkę o szerokości 1, używając tego kodu:

```py 
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID
                
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```

Wynikowy tekst:

![todo:image_alt_text](image-20200930114108-4.png)

## Stosowanie innych efektów WordArt

**Użycie Microsoft PowerPoint**

Z interfejsu programu możesz zastosować te efekty do tekstu, bloku tekstowego, kształtu lub podobnego elementu:

![todo:image_alt_text](image-20200930114129-5.png)

Na przykład efekty Cień, Odbicie i Poświata można zastosować do tekstu; Format 3D i Obrót 3D można zastosować do bloku tekstowego; właściwość Miękkie Krawędzie może być zastosowana do obiektu Shape (działa ona również, gdy nie ustawiono właściwości Format 3D).

### Stosowanie efektów cienia

Tutaj zamierzamy ustawić właściwości dotyczące wyłącznie tekstu. Stosujemy efekt cienia do tekstu za pomocą tego kodu w Pythonie:

```py 
    portion.portion_format.effect_format.enable_outer_shadow_effect()
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.black
    portion.portion_format.effect_format.outer_shadow_effect.scale_horizontal = 100
    portion.portion_format.effect_format.outer_shadow_effect.scale_vertical = 65
    portion.portion_format.effect_format.outer_shadow_effect.blur_radius = 4.73
    portion.portion_format.effect_format.outer_shadow_effect.direction = 230
    portion.portion_format.effect_format.outer_shadow_effect.distance = 2
    portion.portion_format.effect_format.outer_shadow_effect.skew_horizontal = 30
    portion.portion_format.effect_format.outer_shadow_effect.skew_vertical = 0
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.32)
```

API Aspose.Slides obsługuje trzy rodzaje cieni: OuterShadow, InnerShadow i PresetShadow.

Za pomocą PresetShadow możesz zastosować cień do tekstu (używając wartości predefiniowanych).

**Użycie Microsoft PowerPoint**

W PowerPoint możesz używać jednego rodzaju cienia. Oto przykład:

![todo:image_alt_text](image-20200930114225-6.png)

**Użycie Aspose.Slides**

Aspose.Slides faktycznie pozwala na jednoczesne zastosowanie dwóch rodzajów cieni: InnerShadow i PresetShadow.

**Uwaga:**

- Gdy OuterShadow i PresetShadow są używane razem, zastosowany zostaje tylko efekt OuterShadow. 
- Jeśli OuterShadow i InnerShadow są używane jednocześnie, wynikowy lub zastosowany efekt zależy od wersji PowerPoint. Na przykład w PowerPoint 2013 efekt zostaje podwojony. Natomiast w PowerPoint 2007 zastosowany zostaje efekt OuterShadow. 

### Stosowanie wyświetlania do tekstów

Dodajemy wyświetlanie do tekstu za pomocą tego przykładu kodu w Pythonie:

```py 
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

### Stosowanie efektu poświaty do tekstów

Stosujemy efekt poświaty do tekstu, aby go rozświetlić lub wyróżnić, używając tego kodu:

```py 
    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.r = 255
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

Wynik operacji:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Możesz zmienić parametry cienia, wyświetlania i poświaty. Właściwości efektów są ustawiane osobno dla każdej części tekstu. 

{{% /alert %}} 

### Użycie transformacji w WordArt

Używamy właściwości Transform (obowiązującej dla całego bloku tekstu) za pomocą tego kodu:
```py 
textFrame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

Wynik:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Zarówno Microsoft PowerPoint, jak i Aspose.Slides dla Pythona przez .NET udostępniają określoną liczbę wstępnie zdefiniowanych typów transformacji. 

{{% /alert %}} 

**Użycie PowerPoint**

Aby uzyskać dostęp do wstępnie zdefiniowanych typów transformacji, przejdź do: **Format** -> **TextEffect** -> **Transform**

**Użycie Aspose.Slides**

Aby wybrać typ transformacji, użyj wyliczenia TextShapeType. 

### Stosowanie efektów 3D do tekstów i kształtów

Ustawiamy efekt 3D dla kształtu tekstowego przy użyciu tego przykładowego kodu:

```py 
    autoShape.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_bottom.height = 10.5
    autoShape.three_d_format.bevel_bottom.width = 10.5

    autoShape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_top.height = 12.5
    autoShape.three_d_format.bevel_top.width = 11

    autoShape.three_d_format.extrusion_color.color = draw.Color.orange
    autoShape.three_d_format.extrusion_height = 6

    autoShape.three_d_format.contour_color.color = draw.Color.dark_red
    autoShape.three_d_format.contour_width = 1.5

    autoShape.three_d_format.depth = 3

    autoShape.three_d_format.material = slides.MaterialPresetType.PLASTIC

    autoShape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    autoShape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    autoShape.three_d_format.light_rig.set_rotation(0, 0, 40)

    autoShape.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

Wynikowy tekst i jego kształt:

![todo:image_alt_text](image-20200930114816-9.png)

Stosujemy efekt 3D do tekstu za pomocą tego kodu w Pythonie:

```py 
    textFrame.text_frame_format.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_bottom.height = 3.5
    textFrame.text_frame_format.three_d_format.bevel_bottom.width = 3.5

    textFrame.text_frame_format.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_top.height = 4
    textFrame.text_frame_format.three_d_format.bevel_top.width = 4

    textFrame.text_frame_format.three_d_format.extrusion_color.color = draw.Color.orange
    textFrame.text_frame_format.three_d_format.extrusion_height= 6

    textFrame.text_frame_format.three_d_format.contour_color.color = draw.Color.dark_red
    textFrame.text_frame_format.three_d_format.contour_width = 1.5

    textFrame.text_frame_format.three_d_format.depth= 3

    textFrame.text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC

    textFrame.text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    textFrame.text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    textFrame.text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)

    textFrame.text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

Wynik operacji:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

Zastosowanie efektów 3D do tekstów lub ich kształtów oraz interakcje między efektami opierają się na określonych regułach. 

Rozważ scenę dla tekstu i kształtu zawierającego ten tekst. Efekt 3D zawiera reprezentację obiektu 3D oraz scenę, na której obiekt został umieszczony. 

- Gdy scena jest ustawiona zarówno dla figury, jak i tekstu, scena figury ma wyższy priorytet — scena tekstu jest ignorowana. 
- Gdy figura nie ma własnej sceny, ale ma reprezentację 3D, używana jest scena tekstu. 
- W przeciwnym razie — gdy kształt pierwotnie nie ma efektu 3D — kształt jest płaski i efekt 3D jest stosowany wyłącznie do tekstu. 

Opisy są powiązane z właściwościami [ThreeDFormat.LightRig](https://reference.aspose.com/slides/pl/python-net/aspose.slides/threedformat/) i [ThreeDFormat.Camera](https://reference.aspose.com/slides/pl/python-net/aspose.slides/threedformat/). 

{{% /alert %}} 

## **Zastosowanie efektów zewnętrznego cienia do tekstów**
Aspose.Slides dla Pythona przez .NET udostępnia klasy [**IOuterShadow**](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/ioutershadow/) i [**IInnerShadow**](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/iinnershadow/), które pozwalają zastosować efekty cienia do tekstu w TextFrame. Przejdź przez następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/). 
2. Uzyskaj odwołanie do slajdu, używając jego indeksu. 
3. Dodaj AutoShape typu Rectangle do slajdu. 
4. Uzyskaj dostęp do TextFrame powiązanego z AutoShape. 
5. Ustaw FillType AutoShape na NoFill. 
6. Zainstaluj klasę OuterShadow. 
7. Ustaw BlurRadius cienia. 
8. Ustaw Direction cienia. 
9. Ustaw Distance cienia. 
10. Ustaw RectanglelAlign na TopLeft. 
11. Ustaw PresetColor cienia na Black. 
12. Zapisz prezentację jako plik PPTX. 

Ten przykładowy kod w Pythonie — implementacja powyższych kroków — pokazuje, jak zastosować efekt zewnętrznego cienia do tekstu:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    # Pobierz odwołanie do slajdu
    sld = pres.slides[0]

    # Dodaj AutoShape typu Prostokąt
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # Dodaj TextFrame do prostokąta
    ashp.add_text_frame("Aspose TextBox")

    # Wyłącz wypełnienie kształtu, jeśli chcemy uzyskać cień tekstu
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Dodaj zewnętrzny cień i ustaw wszystkie niezbędne parametry
    ashp.effect_format.enable_outer_shadow_effect()
    shadow = ashp.effect_format.outer_shadow_effect
    shadow.blur_radius = 4.0
    shadow.direction = 45
    shadow.distance = 3
    shadow.rectangle_align = slides.RectangleAlignmentTOP_LEFT
    shadow.shadow_color.preset_color = slides.PresetColor.BLACK

    #Zapisz prezentację na dysku
    pres.save("pres_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Zastosowanie efektu wewnętrznego cienia do kształtów**
Przejdź przez następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/). 
2. Uzyskaj odwołanie do slajdu. 
3. Dodaj AutoShape typu Rectangle. 
4. Włącz efekt InnerShadowEffect. 
5. Ustaw wszystkie niezbędne parametry. 
6. Ustaw ColorType na Scheme. 
7. Ustaw kolor schematu. 
8. Zapisz prezentację jako plik [PPTX](https://docs.fileformat.com/presentation/pptx/). 

Ten przykładowy kod (oparty na powyższych krokach) pokazuje, jak dodać łącznik między dwoma kształtami w Pythonie:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    # Pobierz odwołanie do slajdu
    slide = presentation.slides[0]

    # Dodaj AutoShape typu Prostokąt
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 400, 300)
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Dodaj TextFrame do prostokąta
    ashp.add_text_frame("Aspose TextBox")
    port = ashp.text_frame.paragraphs[0].portions[0]
    pf = port.portion_format
    pf.font_height = 50

    # Włącz efekt wewnętrznego cienia    
    ef = pf.effect_format
    ef.enable_inner_shadow_effect()

    # Ustaw wszystkie niezbędne parametry
    ef.inner_shadow_effect.blur_radius = 8.0
    ef.inner_shadow_effect.direction = 90.0
    ef.inner_shadow_effect.distance = 6.0
    ef.inner_shadow_effect.shadow_color.b = 189

    # Ustaw ColorType na Scheme
    ef.inner_shadow_effect.shadow_color.color_type = slides.ColorType.SCHEME

    # Ustaw kolor schematu
    ef.inner_shadow_effect.shadow_color.scheme_color = slides.SchemeColor.ACCENT1

    # Zapisz prezentację
    presentation.save("WordArt_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Najczęściej zadawane pytania**

**Czy mogę używać efektów WordArt z różnymi czcionkami lub skryptami (np. arabskim, chińskim)?**

Tak, Aspose.Slides obsługuje Unicode i współpracuje ze wszystkimi głównymi czcionkami i skryptami. Efekty WordArt, takie jak cień, wypełnienie i kontur, można stosować niezależnie od języka, choć dostępność czcionek i renderowanie mogą zależeć od czcionek systemowych.

**Czy mogę zastosować efekty WordArt do elementów mastera slajdów?**

Tak, możesz zastosować efekty WordArt do kształtów na slajdach master, w tym do pól zastępczych tytułu, stopki lub tekstu tła. Zmiany w układzie mastera będą odzwierciedlone we wszystkich powiązanych slajdach.

**Czy efekty WordArt wpływają na rozmiar pliku prezentacji?**

Nieznacznie. Efekty WordArt, takie jak cienie, poświaty i gradientowe wypełnienia, mogą nieco zwiększyć rozmiar pliku z powodu dodatkowych metadanych formatowania, ale różnica zazwyczaj jest pomijalna.

**Czy mogę podglądnąć wynik efektów WordArt bez zapisywania prezentacji?**

Tak, możesz renderować slajdy zawierające WordArt na obrazy (np. PNG, JPEG) przy użyciu metody `get_image` z klas [Shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/) lub [Slide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/). Umożliwia to podgląd wyniku w pamięci lub na ekranie przed zapisaniem lub wyeksportowaniem pełnej prezentacji.