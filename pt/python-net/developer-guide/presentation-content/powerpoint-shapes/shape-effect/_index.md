---
title: Aplicar efeitos de forma em apresentações com Python
linktitle: Efeito de Forma
type: docs
weight: 30
url: /pt/python-net/shape-effect
keywords:
- efeito de forma
- efeito de sombra
- efeito de reflexão
- efeito de brilho
- efeito de bordas suaves
- formato de efeito
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Transforme seus arquivos PPT, PPTX e ODP com efeitos avançados de forma usando Aspose.Slides para Python — crie slides impressionantes e profissionais em segundos."
---
## **Introdução**

Enquanto os efeitos no PowerPoint podem ser usados para fazer uma forma se destacar, eles diferem de [preenchimentos](/slides/pt/python-net/shape-formatting/#gradient-fill) ou contornos. Usando os efeitos do PowerPoint, você pode criar reflexos convincentes em uma forma, espalhar o brilho de uma forma, etc.

<img src="shape-effect.png" alt="efeito-de-forma" style="zoom:50%;" />

* O PowerPoint fornece seis efeitos que podem ser aplicados a formas. Você pode aplicar um ou mais efeitos a uma forma. 

* Algumas combinações de efeitos ficam melhores que outras. Por esse motivo, as opções do PowerPoint em **Preset**. As opções de Preset são essencialmente uma combinação já conhecida de dois ou mais efeitos que tem boa aparência. Dessa forma, ao selecionar um preset, você não precisará perder tempo testando ou combinando efeitos diferentes para encontrar uma boa combinação.

Aspose.Slides oferece propriedades e métodos na classe [EffectFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/effectformat/) que permitem aplicar os mesmos efeitos a formas em apresentações do PowerPoint.

## **Aplicar efeito de sombra**

Este código Python mostra como aplicar o efeito de sombra externa (`outer_shadow_effect`) a um retângulo:

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

## **Aplicar efeito de reflexão**

Este código Python mostra como aplicar o efeito de reflexão a uma forma:

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

## **Aplicar efeito de brilho**

Este código Python mostra como aplicar o efeito de brilho a uma forma:

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

## **Aplicar efeito de bordas suaves**

Este código Python mostra como aplicar bordas suaves a uma forma:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 15

    pres.save("softEdges.pptx", slides.export.SaveFormat.PPTX)
```

## **Perguntas frequentes**

**Posso aplicar múltiplos efeitos à mesma forma?**

Sim, você pode combinar diferentes efeitos, como sombra, reflexão e brilho, em uma única forma para criar uma aparência mais dinâmica.

**A quais formas posso aplicar efeitos?**

Você pode aplicar efeitos a várias formas, incluindo autoshapes, gráficos, tabelas, imagens, objetos SmartArt, objetos OLE e muito mais.

**Posso aplicar efeitos a formas agrupadas?**

Sim, você pode aplicar efeitos a formas agrupadas. O efeito será aplicado ao grupo inteiro.