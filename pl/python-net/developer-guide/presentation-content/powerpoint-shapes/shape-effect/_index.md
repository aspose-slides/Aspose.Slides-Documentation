---
title: Zastosowanie efektów kształtów w prezentacjach w Pythonie
linktitle: Efekt kształtu
type: docs
weight: 30
url: /pl/python-net/shape-effect
keywords:
- efekt kształtu
- efekt cienia
- efekt odbicia
- efekt poświaty
- efekt miękkich krawędzi
- format efektu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Przekształć swoje pliki PPT, PPTX i ODP przy użyciu zaawansowanych efektów kształtów w Aspose.Slides dla Pythona — twórz efektowne, profesjonalne slajdy w kilka sekund."
---
## **Wprowadzenie**

Podczas gdy efekty w PowerPoint mogą być użyte do wyróżnienia kształtu, różnią się od [wypełnień](/slides/pl/python-net/shape-formatting/#gradient-fill) lub konturów. Używając efektów PowerPoint, możesz tworzyć przekonujące odbicia na kształcie, rozprzestrzeniać poświatę kształtu itp.

![Efekt kształtu](shape-effect.png)

PowerPoint udostępnia sześć efektów, które można zastosować do kształtów. Możesz zastosować jeden lub więcej efektów do kształtu.

Niektóre kombinacje efektów wyglądają lepiej niż inne. Z tego powodu PowerPoint posiada opcje w sekcji **Preset**. Opcje Preset to w zasadzie znane, dobrze wyglądające kombinacje dwóch lub więcej efektów. Dzięki temu, wybierając preset, nie musisz tracić czasu na testowanie lub łączenie różnych efektów w celu znalezienia ładnej kombinacji.

Aspose.Slides udostępnia właściwości i metody w klasie [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/), które pozwalają zastosować te same efekty do kształtów w prezentacjach PowerPoint.

## **Zastosowanie efektu cienia**

Aspose.Slides for Python via .NET obsługuje zewnętrzne i wewnętrzne cienie dla kształtów. Możesz dostosować ich kolor, kierunek, odległość i promień rozmycia, aby pasowały do projektu Twojej prezentacji.

### **Zastosowanie zewnętrznego cienia**

Użyj zewnętrznego cienia, aby karta lub panel wyróżniały się na tle slajdu. Cień rozciąga się poza krawędzie kształtu, tworząc wrażenie, że kształt jest podniesiony ponad slajd. Dostosuj jego kolor, kierunek, odległość i promień rozmycia, aby pasowały do oświetlenia i stylu szablonu.

Ten kod Pythona pokazuje, jak zastosować [efekt zewnętrznego cienia](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) do prostokąta:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = slides.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    presentation.save("shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Efekt cienia](shadow_effect.png)

#### **Kontrola kierunku cienia przy obrocie kształtu**

Domyślnie, [OuterShadow.rotate_shadow_with_shape](https://reference.aspose.com/slides/python-net/aspose.slides.effects/outershadow/rotate_shadow_with_shape/) ma wartość `True`, więc cień obraca się razem z kształtem. Aby kształty o różnych obrotach były oświetlone z tego samego kierunku, ustaw tę właściwość na `False` i nadaj ich cieniom ten sam [kierunek](https://reference.aspose.com/slides/python-net/aspose.slides.effects/outershadow/direction/).

Przykład tworzy dwie strzałki z szarymi cieniami przesuniętymi o 42 punkty w prawo (`direction = 0`). Następnie duplikuje slajd i obraca obie strzałki o 90° zgodnie z ruchem wskazówek zegara.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    before = presentation.slides[0]

    left = before.shapes.add_auto_shape(slides.ShapeType.RIGHT_ARROW, 55, 130, 110, 60)
    left.fill_format.fill_type = slides.FillType.SOLID
    left.fill_format.solid_fill_color.color = slides.Color.steel_blue
    left.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    left.effect_format.enable_outer_shadow_effect()
    shadow = left.effect_format.outer_shadow_effect
    shadow.shadow_color.color = slides.Color.gray
    shadow.direction = 0
    shadow.distance = 42
    shadow.blur_radius = 0
    shadow.rotate_shadow_with_shape = True

    right = before.shapes.add_clone(left)
    right.x = 395
    right.effect_format.outer_shadow_effect.rotate_shadow_with_shape = False

    after = presentation.slides.add_clone(before)
    for arrow in after.shapes:
        arrow.rotation = 90

    presentation.save("arrow_shadows.pptx", slides.export.SaveFormat.PPTX)
```

Na drugim slajdzie lewa strzałka rzuca swój cień w dół, podczas gdy prawy cień nadal skierowany jest w prawo. Skonfigurowany kierunek pozostaje 0° dla obu cieni.

![Renderowanie PowerPoint przed i po obrocie o 90°. Oba cienie zaczynają po prawej stronie. Po obrocie cień przechodzi pod lewą strzałkę i pozostaje po prawej stronie prawej strzałki.](arrow-shadow-rotation.png)

### **Zastosowanie wewnętrznego cienia**

Podczas odtwarzania wizualnego stylu szablonu użyj wewnętrznego cienia, aby nadać karcie lub panelowi wklęsły wygląd. Zewnętrzny cień rozciąga się poza kształt i sprawia, że wygląda na podniesiony, natomiast wewnętrzny cień przyciemnia wnętrze jego krawędzi.

Wywołaj [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/), a następnie skonfiguruj [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/). Większe wartości promienia rozmycia dają miększe krawędzie.

Ten przykład w Pythonie tworzy jasnoniebieską kartę z ciemnoszarym wewnętrznym cieniem i zapisuje ją jako plik PPTX:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.light_blue
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    shape.effect_format.enable_inner_shadow_effect()
    shadow = shape.effect_format.inner_shadow_effect
    shadow.shadow_color.color = slides.Color.dim_gray
    shadow.direction = 225
    shadow.distance = 7
    shadow.blur_radius = 6

    presentation.save("inner_shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Jasnoniebieski prostokąt z wewnętrznym cieniem](inner_shadow_effect.png)

Aby usunąć wewnętrzny cień, wywołaj [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) na formacie efektu kształtu.

### **Zastosowanie, zmiana i usunięcie presetowego cienia**

Wywołaj [enable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_preset_shadow_effect/) i ustaw właściwość cienia [preset](https://reference.aspose.com/slides/python-net/aspose.slides.effects/presetshadow/preset/) na wartość [PresetShadowType](https://reference.aspose.com/slides/python-net/aspose.slides/presetshadowtype/). Aby zmienić styl, zmień preset na tym samym kształcie. Wywołaj [disable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_preset_shadow_effect/) aby usunąć cień, zachowując wypełnienie i kontur.

Ten przykład pokazuje cztery etapy obok siebie na jednym slajdzie. Przed każdą zmianą klonuje prostokąt, abyś mógł porównać wyniki. Oba cienie są odsunięte o 10 punktów. Kierunek 225° umieszcza pierwszy cień powyżej i po lewej stronie prostokąta, a 45° umieszcza drugi poniżej i po prawej.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(800, 120, slides.SlideSizeScaleType.DO_NOT_SCALE)
    shapes = presentation.slides[0].shapes

    shape = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 15, 30, 170, 60)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.steel_blue
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = slides.Color.dark_blue
    shape.text_frame.text = "No shadow"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 14
    shapes.add_clone(shape)

    shape.x += 200
    shape.effect_format.enable_preset_shadow_effect()
    shadow = shape.effect_format.preset_shadow_effect
    shadow.preset = slides.PresetShadowType.TOP_LEFT_DROP_SHADOW
    shadow.distance = 10
    shadow.direction = 225
    shape.text_frame.text = "TopLeftDropShadow"
    shapes.add_clone(shape)

    shape.x += 200
    shadow.preset = slides.PresetShadowType.BOTTOM_RIGHT_DROP_SHADOW
    shadow.direction = 45
    shape.text_frame.text = "BottomRightDropShadow"
    shapes.add_clone(shape)

    shape.x += 200
    shape.effect_format.disable_preset_shadow_effect()
    shape.text_frame.text = "No shadow"

    presentation.save("preset_shadows.pptx", slides.export.SaveFormat.PPTX)
```

| Oryginalny | Pierwszy preset | Drugi preset | Po usunięciu |
| :---: | :---: | :---: | :---: |
| ![Brak cienia](preset_shadow_original.png) | ![Cień w lewym górnym rogu](preset_shadow_top_left.png) | ![Cień w prawym dolnym rogu](preset_shadow_bottom_right.png) | ![Brak cienia po usunięciu](preset_shadow_removed.png) |

## **Zastosowanie efektu odbicia**

Aby zastosować efekt odbicia w Aspose.Slides for Python via .NET, możesz dodać lustrzane odbicie do kształtów, dostosowując parametry takie jak odległość, przezroczystość i rozmiar. Efekt ten podnosi estetykę Twoich prezentacji, nadając kształtom bardziej wykończony i elegancki wygląd. Jest łatwy do wdrożenia przy użyciu prostego kodu, umożliwiając szybką aplikację na wielu elementach dla spójnego projektu.

Ten kod Pythona pokazuje, jak zastosować [efekt odbicia](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) do kształtu:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_reflection_effect()
    shape.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM
    shape.effect_format.reflection_effect.direction = 90
    shape.effect_format.reflection_effect.distance = 40
    shape.effect_format.reflection_effect.blur_radius = 2

    presentation.save("reflection_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Efekt odbicia](reflection_effect.png)

## **Zastosowanie efektu poświaty**

Aby zastosować efekt poświaty do kształtu w Aspose.Slides for Python via .NET, możesz dodać miękką, świetlistą aurę wokół kształtów, regulując właściwości takie jak kolor i rozmiar. Efekt ten pomaga wyróżnić kształty i dodaje atrakcyjny, przyciągający wzrok element wizualny do Twojej prezentacji. Jest łatwy do wdrożenia przy minimalnym kodzie, podnosząc ogólny wygląd slajdów.

Ten kod Pythona pokazuje, jak zastosować [efekt poświaty](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) do kształtu:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = slides.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    presentation.save("glow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Efekt poświaty](glow_effect.png)

## **Zastosowanie efektu miękkich krawędzi**

Aby zastosować efekt miękkich krawędzi w Aspose.Slides for Python via .NET, możesz stworzyć płynne, rozmyte przejście wokół krawędzi kształtu. Efekt ten dodaje subtelny i wyrafinowany wygląd, idealny dla projektów wymagających łagodnego, delikatniejszego wyglądu. Łatwo możesz dostosować parametry, takie jak promień, aby uzyskać pożądany efekt na różnych kształtach w prezentacji.

Ten kod Pythona pokazuje, jak zastosować [miękkie krawędzie](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) do kształtu:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Efekt miękkich krawędzi](soft_edges_effect.png)

## **Zastosowanie efektu rozmycia**

Użyj rozmycia kształtu, aby zmiękczyć wypełnienie i kontur kształtu, pozostawiając go edytowalnym. Wywołaj [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) na formacie efektu kształtu. Promień jest mierzony w punktach (1/72 cala): użyj nieujemnej wartości, przy czym większe wartości dają silniejsze rozmycie. Promień równy zero pozostawia wygląd niezmieniony.

Ustawienie [grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) kontroluje widoczne granice efektu. Przy `False` rozmycie jest przycięte do pierwotnych pomalowanych granic, włącznie z konturem. Przy `True` rozmycie może wykraczać poza te granice. Żadne z ustawień nie zmienia położenia ani wymiarów kształtu.

Poniższe porównanie używa tego samego wypełnienia, konturu i wymiarów kształtu w całej serii. Górny wiersz używa `grow = False`; dolny wiersz używa `grow = True`.

![Oryginalny prostokąt porównany z promieniami rozmycia 5 i 15 punktów, z wyłączonym i włączonym grow](shape_blur_comparison.png)

Ten przykład w Pythonie tworzy pomarańczowy prostokąt z ciemnoniebieskim konturem, stosuje rozmycie o promieniu 5 punktów, a następnie aktualizuje je do 15 punktów, wywołując ponownie [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/). Zapisuje oba stany rozmycia, potem wywołuje [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) i zapisuje kształt bez rozmycia.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 80, 160, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.orange
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = slides.Color.dark_blue
    shape.line_format.width = 8

    shape.effect_format.set_blur_effect(5, False)
    presentation.save("shape_blur_5.pptx", slides.export.SaveFormat.PPTX)

    shape.effect_format.set_blur_effect(15, True)
    presentation.save("shape_blur_15.pptx", slides.export.SaveFormat.PPTX)

    shape.effect_format.disable_blur_effect()
    presentation.save("shape_blur_removed.pptx", slides.export.SaveFormat.PPTX)
```

Rozmycie kształtu wpływa jednocześnie na wypełnienie i kontur. Efekt miękkich krawędzi wyciera krawędzie kształtu, podczas gdy rozmycie cienia zmiękcza jedynie cień. Efekty transformacji obrazu działają na zawartość obrazu; ten przykład stosuje rozmycie bezpośrednio do formatu efektu kształtu, nie przekształcając go w obraz.

## **FAQ**

**Czy mogę zastosować wiele efektów do tego samego kształtu?**

Tak, możesz łączyć różne efekty, takie jak cień, odbicie i poświata, na jednym kształcie, aby uzyskać bardziej dynamiczny wygląd.

**Do jakich kształtów mogę stosować efekty?**

Efekty można stosować do różnych kształtów, w tym autokształtów, wykresów, tabel, obrazów, obiektów SmartArt, obiektów OLE i innych.

**Czy mogę stosować efekty do grupowanych kształtów?**

Tak, możesz stosować efekty do grupowanych kształtów. Efekt zostanie zastosowany do całej grupy.