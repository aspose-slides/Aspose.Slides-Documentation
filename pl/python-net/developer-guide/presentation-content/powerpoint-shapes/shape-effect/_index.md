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
description: "Przekształć swoje pliki PPT, PPTX i ODP za pomocą zaawansowanych efektów kształtów przy użyciu Aspose.Slides dla Pythona — twórz efektowne, profesjonalne slajdy w kilka sekund."
---
## **Wprowadzenie**

Chociaż efekty w PowerPoint mogą być używane do wyróżnienia kształtu, różnią się od [wypełnień](/slides/pl/python-net/shape-formatting/#gradient-fill) lub konturów. Używając efektów PowerPoint, możesz tworzyć przekonujące odbicia na kształcie, rozprzestrzeniać poświatę kształtu itp.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint oferuje sześć efektów, które można zastosować do kształtów. Możesz zastosować jeden lub więcej efektów do kształtu. 

* Niektóre kombinacje efektów wyglądają lepiej niż inne. Z tego powodu w PowerPoint dostępne są opcje pod **Preset**. Opcje Preset to w zasadzie znane, dobrze wyglądające kombinacje dwóch lub więcej efektów. Dzięki wyborowi ustawienia wstępnego nie będziesz musiał tracić czasu na testowanie lub łączenie różnych efektów, aby znaleźć dobrą kombinację.

Aspose.Slides udostępnia właściwości i metody w klasie [EffectFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/effectformat/) , które pozwalają zastosować te same efekty do kształtów w prezentacjach PowerPoint.

## **Zastosuj efekt cienia**

Ten kod w Pythonie pokazuje, jak zastosować efekt zewnętrznego cienia (`outer_shadow_effect`) do prostokąta:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Zastosuj efekt odbicia**

Ten kod w Pythonie pokazuje, jak zastosować efekt odbicia do kształtu:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_reflection_effect()
    shape.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM
    shape.effect_format.reflection_effect.direction = 90
    shape.effect_format.reflection_effect.distance = 55
    shape.effect_format.reflection_effect.blur_radius = 4

    pres.save("reflection.pptx", slides.export.SaveFormat.PPTX)
```

## **Zastosuj efekt poświaty**

Ten kod w Pythonie pokazuje, jak zastosować efekt poświaty do kształtu:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = draw.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    pres.save("glow.pptx", slides.export.SaveFormat.PPTX)
```

## **Zastosuj efekt miękkich krawędzi**

Ten kod w Pythonie pokazuje, jak zastosować miękkie krawędzie do kształtu:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 15

    pres.save("softEdges.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy mogę zastosować wiele efektów do tego samego kształtu?**

Tak, możesz łączyć różne efekty, takie jak cień, odbicie i poświata, na jednym kształcie, aby uzyskać bardziej dynamiczny wygląd.

**Do jakich kształtów mogę zastosować efekty?**

Efekty można stosować do różnych kształtów, w tym automatycznych kształtów, wykresów, tabel, obrazów, obiektów SmartArt, obiektów OLE i innych.

**Czy mogę zastosować efekty do grupowanych kształtów?**

Tak, możesz zastosować efekty do grupowanych kształtów. Efekt zostanie zastosowany do całej grupy.