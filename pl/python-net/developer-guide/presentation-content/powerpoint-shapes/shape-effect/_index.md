---
title: Zastosuj efekty kształtów w prezentacjach przy użyciu Pythona
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

Podczas gdy efekty w programie PowerPoint można wykorzystać do wyróżnienia kształtu, różnią się one od [wypełnień](/slides/pl/python-net/shape-formatting/#gradient-fill) czy konturów. Korzystając z efektów PowerPoint, możesz tworzyć przekonujące odbicia kształtu, rozprzestrzeniać poświatę kształtu itp.

![Efekt kształtu](shape-effect.png)

PowerPoint udostępnia sześć efektów, które można zastosować do kształtów. Możesz zastosować jeden lub więcej efektów do jednego kształtu.

Niektóre kombinacje efektów wyglądają lepiej niż inne. Z tego powodu PowerPoint oferuje opcje w sekcji **Preset**. Opcje Preset to w zasadzie znana kombinacja dwóch lub więcej efektów, które dobrze ze sobą współgrają. W ten sposób, wybierając preset, nie będziesz musiał tracić czasu na testowanie lub łączenie różnych efektów w poszukiwaniu ładnej kombinacji.

Aspose.Slides udostępnia właściwości i metody w klasie [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/), które pozwalają na zastosowanie tych samych efektów do kształtów w prezentacjach PowerPoint.

## **Zastosowanie efektu cienia**

Aspose.Slides for Python via .NET obsługuje cienie zewnętrzne i wewnętrzne dla kształtów. Możesz dostosować ich kolor, kierunek, odległość i promień rozmycia, aby pasowały do projektu Twojej prezentacji.

### **Zastosowanie cienia zewnętrznego**

Użyj cienia zewnętrznego, aby karta lub panel wyróżniały się na tle slajdu. Cień wykracza poza krawędzie kształtu, tworząc wrażenie, że kształt jest uniesiony nad slajdem. Dostosuj jego kolor, kierunek, odległość i promień rozmycia, aby pasowały do oświetlenia i stylu szablonu.

Ten kod w Pythonie pokazuje, jak zastosować [efekt cienia zewnętrznego](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) do prostokąta:

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

### **Zastosowanie cienia wewnętrznego**

Podczas odtwarzania wizualnego stylu szablonu użyj cienia wewnętrznego, aby nadać karcie lub panelowi wcięty wygląd. Cień zewnętrzny rozciąga się poza kształt i sprawia, że wydaje się podniesiony, natomiast cień wewnętrzny przyciemnia wnętrze jego krawędzi.

Wywołaj [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/), a następnie skonfiguruj [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/). Większe wartości promienia rozmycia dają delikatniejsze krawędzie.

Ten przykład w Pythonie tworzy jasnoniebieską kartę z ciemnoszarym cieniem wewnętrznym i zapisuje ją jako plik PPTX:

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

![Niebieski prostokąt z wewnętrznym cieniem](inner_shadow_effect.png)

Aby usunąć cień wewnętrzny, wywołaj [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) na formacie efektu kształtu.

## **Zastosowanie efektu odbicia**

Aby zastosować efekt odbicia w Aspose.Slides for Python via .NET, możesz dodać lustrzane odbicie do kształtów, regulując parametry takie jak odległość, przejrzystość i rozmiar. Efekt ten zwiększa estetykę prezentacji, nadając kształtom bardziej wyrafinowany wygląd. Jest łatwy do wdrożenia przy użyciu prostego kodu, umożliwiając szybkie zastosowanie go w wielu elementach dla spójnego projektu.

Ten kod w Pythonie pokazuje, jak zastosować [efekt odbicia](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) do kształtu:

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

Aby zastosować efekt poświaty do kształtu w Aspose.Slides for Python via .NET, możesz dodać miękką, świetlistą aurę wokół kształtów, regulując właściwości takie jak kolor i rozmiar. Efekt ten pomaga wyróżnić kształty i dodaje atrakcyjny, przyciągający uwagę element wizualny do Twojej prezentacji. Jego implementacja wymaga minimalnego kodu, podnosząc ogólny wygląd slajdów.

Ten kod w Pythonie pokazuje, jak zastosować [efekt poświaty](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) do kształtu:

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

Aby zastosować efekt miękkich krawędzi w Aspose.Slides for Python via .NET, możesz stworzyć płynne, rozmyte przejście wokół krawędzi kształtu. Efekt ten nadaje subtelniejszy i bardziej wyrafinowany wygląd, idealny dla projektów wymagających delikatnego, łagodnego wyglądu. Łatwo możesz dostosować parametry, takie jak promień, aby uzyskać pożądany efekt w różnych kształtach w prezentacji.

Ten kod w Pythonie pokazuje, jak zastosować [miękkie krawędzie](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) do kształtu:

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

Użyj rozmycia kształtu, aby złagodzić wypełnienie i kontur kształtu, zachowując go edytowalnym. Wywołaj [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) na formacie efektu kształtu. Promień mierzony jest w punktach (1/72 cala): użyj nieujemnej wartości, przy czym większe wartości dają silniejsze rozmycie. Promień równy zero pozostawia wygląd niezmieniony.

Ustawienie [grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) kontroluje widoczne granice efektu. Przy `False` rozmycie jest przycięte do pierwotnych pomalowanych granic, w tym konturu. Przy `True` rozmycie może wykraczać poza te granice. Żadne z ustawień nie zmienia pozycji ani wymiarów kształtu.

Poniższe porównanie używa tego samego wypełnienia, konturu i wymiarów kształtu. Górny rząd używa `grow = False`; dolny rząd używa `grow = True`.

![Oryginalny prostokąt porównany z promieniami rozmycia 5 i 15 punktów, przy wyłączonym i włączonym grow](shape_blur_comparison.png)

Ten przykład w Pythonie tworzy pomarańczowy prostokąt z ciemnoniebieskim konturem, stosuje rozmycie o promieniu 5 punktów, a następnie aktualizuje je do 15‑punktowego rozmycia, wywołując ponownie [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/). Zapisuje oba rozmyte stany, po czym wywołuje [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) i zapisuje kształt bez rozmycia.

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

Rozmycie kształtu wpływa jednocześnie na wypełnienie i kontur. Efekt miękkich krawędzi wygasza krawędzie kształtu, podczas gdy rozmycie cienia łagodzi jedynie cień. Efekty transformacji obrazu działają na zawartość obrazu; ten przykład stosuje rozmycie bezpośrednio do formatu efektu kształtu, bez konwertowania go na obraz.

## **FAQ**

**Czy mogę zastosować wiele efektów do tego samego kształtu?**

Tak, możesz łączyć różne efekty, takie jak cień, odbicie i poświata, na jednym kształcie, aby uzyskać bardziej dynamiczny wygląd.

**Do jakich kształtów mogę zastosować efekty?**

Możesz stosować efekty do różnych kształtów, w tym do autokształtów, wykresów, tabel, obrazów, obiektów SmartArt, obiektów OLE i innych.

**Czy mogę zastosować efekty do grupowanych kształtów?**

Tak, możesz zastosować efekty do grupowanych kształtów. Efekt zostanie zastosowany do całej grupy.