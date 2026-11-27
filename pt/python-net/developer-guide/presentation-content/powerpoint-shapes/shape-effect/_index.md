---
title: Aplicar Efeitos de Forma em Apresentações com Python
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

Embora os efeitos no PowerPoint possam ser usados para fazer uma forma se destacar, eles diferem de [preenchimentos](/slides/pt/python-net/shape-formatting/#gradient-fill) ou contornos. Usando os efeitos do PowerPoint, você pode criar reflexos convincentes em uma forma, espalhar o brilho de uma forma, etc.

![Efeito de forma](shape-effect.png)

O PowerPoint oferece seis efeitos que podem ser aplicados a formas. Você pode aplicar um ou mais efeitos a uma forma.

Algumas combinações de efeitos ficam melhores que outras. Por esse motivo, o PowerPoint tem opções em **Preset**. As opções de Preset são essencialmente uma combinação conhecida de boa aparência de dois ou mais efeitos. Dessa forma, ao selecionar um preset, você não precisará perder tempo testando ou combinando efeitos diferentes para encontrar uma boa combinação.

Aspose.Slides fornece propriedades e métodos na classe [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) que permitem aplicar os mesmos efeitos a formas em apresentações do PowerPoint.

## **Aplicar um efeito de sombra**

Aspose.Slides for Python via .NET oferece suporte a sombras externas e internas para formas. Você pode personalizar sua cor, direção, distância e raio de desfoque para corresponder ao design da sua apresentação.

### **Aplicar uma sombra externa**

Use uma sombra externa para fazer um cartão ou painel se destacar contra o fundo do slide. A sombra se estende além das bordas da forma, criando a impressão de que a forma está elevada acima do slide. Ajuste sua cor, direção, distância e raio de desfoque para combinar com a iluminação e o estilo do seu modelo.

Este código Python mostra como aplicar o [efeito de sombra externa](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) a um retângulo:

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

![Efeito de sombra](shadow_effect.png)

#### **Controlar a direção da sombra quando uma forma gira**

Por padrão, [OuterShadow.rotate_shadow_with_shape](https://reference.aspose.com/slides/python-net/aspose.slides.effects/outershadow/rotate_shadow_with_shape/) é `True`, então a sombra gira com a forma. Para fazer formas com rotações diferentes parecerem iluminadas da mesma direção, defina esta propriedade como `False` e atribua às sombras a mesma [direção](https://reference.aspose.com/slides/python-net/aspose.slides.effects/outershadow/direction/).

O exemplo cria duas setas com sombras cinzas deslocadas 42 pontos para a direita (`direction = 0`). Em seguida, duplica o slide e gira ambas as setas 90° no sentido horário.

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

No segundo slide, a seta à esquerda projeta sua sombra para baixo, enquanto a seta à direita ainda projeta sua sombra para a direita. A direção configurada permanece 0° para ambas as sombras.

![Renderização do PowerPoint antes e depois de uma rotação de 90°. Ambas as sombras começam à direita. Após a rotação, a sombra move-se abaixo da seta esquerda e permanece à direita da seta direita.](arrow-shadow-rotation.png)

### **Aplicar uma sombra interna**

Ao reproduzir o estilo visual de um modelo, use uma sombra interna para dar a um cartão ou painel uma aparência rebaixada. Uma sombra externa se estende fora da forma e faz com que ela pareça elevada, enquanto uma sombra interna sombrea o interior de suas bordas.

Chame [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/), então configure [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/). Valores maiores de raio de desfoque produzem bordas mais suaves.

Este exemplo Python cria um cartão azul claro com uma sombra interna cinza escura e o salva como um arquivo PPTX:

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

![Retângulo azul claro com sombra interna](inner_shadow_effect.png)

Para remover a sombra interna, chame [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) no formato de efeito da forma.

### **Aplicar, alterar e remover uma sombra predefinida**

Chame [enable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_preset_shadow_effect/) e defina a propriedade [preset](https://reference.aspose.com/slides/python-net/aspose.slides.effects/presetshadow/preset/) da sombra para um valor [PresetShadowType](https://reference.aspose.com/slides/python-net/aspose.slides/presetshadowtype/). Para trocar estilos, altere o preset na mesma forma. Chame [disable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_preset_shadow_effect/) para remover a sombra mantendo o preenchimento e o contorno.

Este exemplo mostra quatro estágios lado a lado em um slide. Ele clona o retângulo antes de cada alteração para que você possa comparar os resultados. Ambas as sombras são deslocadas em 10 pontos. Uma direção de 225° coloca a primeira sombra acima e à esquerda do retângulo, e 45° coloca a segunda abaixo e à direita.

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

| Original | Primeiro preset | Segundo preset | Após remoção |
| :---: | :---: | :---: | :---: |
| ![Sem sombra](preset_shadow_original.png) | ![Sombra projetada superior esquerda](preset_shadow_top_left.png) | ![Sombra projetada inferior direita](preset_shadow_bottom_right.png) | ![Sem sombra após remoção](preset_shadow_removed.png) |

## **Aplicar um efeito de reflexão**

Para aplicar um efeito de reflexão no Aspose.Slides for Python via .NET, você pode adicionar uma reflexão semelhante a um espelho em formas, ajustando parâmetros como distância, transparência e tamanho. Esse efeito aprimora a estética de suas apresentações ao dar às formas uma aparência mais polida e sofisticada. É fácil de implementar com código simples, permitindo aplicação rápida em vários elementos para um design consistente.

Este código Python mostra como aplicar o [efeito de reflexão](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) em uma forma:

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

![Efeito de reflexão](reflection_effect.png)

## **Aplicar um efeito de brilho**

Para aplicar um efeito de brilho a uma forma no Aspose.Slides for Python via .NET, você pode adicionar uma aura suave e luminosa ao redor das formas, ajustando propriedades como cor e tamanho. Esse efeito ajuda a fazer as formas se destacarem e adiciona um elemento visual atraente e chamativo à sua apresentação. É fácil de implementar com código mínimo, aprimorando a aparência geral de seus slides.

Este código Python mostra como aplicar o [efeito de brilho](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) a uma forma:

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

![Efeito de brilho](glow_effect.png)

## **Aplicar um efeito de bordas suaves**

Para aplicar um efeito de bordas suaves no Aspose.Slides for Python via .NET, você pode criar uma transição suave e desfocada ao redor das bordas de uma forma. Esse efeito adiciona um visual mais sutil e refinado, perfeito para designs que necessitam de uma aparência suave e delicada. Você pode ajustar facilmente parâmetros como raio para alcançar o efeito desejado em várias formas na sua apresentação.

Este código Python mostra como aplicar [bordas suaves](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) a uma forma:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Efeito de bordas suaves](soft_edges_effect.png)

## **Aplicar um efeito de desfoque**

Use o desfoque de forma para suavizar o preenchimento e o contorno de uma forma mantendo-a editável. Chame [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) no formato de efeito da forma. O raio é medido em pontos (1/72 polegada): use um valor não negativo, sendo que valores maiores produzem desfoque mais forte. Um raio zero mantém a aparência inalterada.

A configuração [grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) controla os limites visíveis do efeito. Com `False`, o desfoque é recortado aos limites pintados originais, incluindo o contorno. Com `True`, o desfoque pode se estender além desses limites. Nenhuma das configurações altera a posição ou as dimensões da forma.

A comparação abaixo usa o mesmo preenchimento, contorno e dimensões da forma em todo o exemplo. A linha superior usa `grow = False`; a linha inferior usa `grow = True`.

![Retângulo original comparado com raios de desfoque de 5 e 15 pontos, com grow desativado e ativado](shape_blur_comparison.png)

Este exemplo Python cria um retângulo laranja com contorno azul escuro, aplica um desfoque de 5 pontos e então o atualiza para um desfoque de 15 pontos chamando [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) novamente. Ele salva ambos os estados desfocados, depois chama [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) e salva a forma sem desfoque.

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

O desfoque de forma afeta o preenchimento e o contorno juntos. Um efeito de bordas suaves desvanece as bordas da forma, enquanto o desfoque de sombra suaviza apenas a sombra. Os efeitos de transformação de imagem operam sobre o conteúdo da imagem; este exemplo aplica desfoque diretamente ao formato de efeito da forma sem converter a forma em imagem.

## **FAQ**

**Posso aplicar vários efeitos à mesma forma?**
Sim, você pode combinar diferentes efeitos, como sombra, reflexão e brilho, em uma única forma para criar uma aparência mais dinâmica.

**Quais formas posso aplicar efeitos?**
Você pode aplicar efeitos a várias formas, incluindo autoshapes, gráficos, tabelas, imagens, objetos SmartArt, objetos OLE e muito mais.

**Posso aplicar efeitos a formas agrupadas?**
Sim, você pode aplicar efeitos a formas agrupadas. O efeito será aplicado a todo o grupo.