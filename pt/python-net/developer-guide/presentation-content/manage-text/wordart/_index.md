---
title: Criar e Aplicar Efeitos WordArt em Python
linktitle: WordArt
type: docs
weight: 110
url: /pt/python-net/wordart/
keywords:
- WordArt
- criar WordArt
- modelo WordArt
- efeito WordArt
- efeito de sombra
- efeito de reflexo
- efeito de brilho
- transformação WordArt
- efeito 3D
- efeito de sombra externa
- efeito de sombra interna
- Python
- Aspose.Slides
description: "Crie e personalize efeitos WordArt no Aspose.Slides para Python via .NET. Este guia passo a passo ajuda desenvolvedores a melhorar apresentações com texto profissional em Python."
---
## **Visão geral**

Os efeitos WordArt permitem estilizar texto com preenchimentos, contornos, sombras, reflexos, brilho, transformações e formatação 3D. Este artigo explica como criar e personalizar esses efeitos em apresentações do PowerPoint usando Aspose.Slides for Python via .NET, sem a necessidade de instalar o Microsoft Office.

## **Criar um Modelo WordArt Simples e Aplicá‑lo ao Texto**

Os exemplos a seguir criam um estilo WordArt simples definindo o texto, a fonte, o preenchimento de padrão e o contorno.

Cada exemplo cria uma nova apresentação e adiciona um retângulo ao seu primeiro slide; nenhum arquivo de entrada é necessário. O primeiro exemplo define o texto como "Aspose.Slides". A posição e as dimensões da forma são medidas em pontos:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    text_frame = auto_shape.text_frame

    portion = text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
```

Defina a fonte como Arial Black em 36 pontos para tornar a formatação mais perceptível:

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

Aplique um padrão [SMALL_GRID](https://reference.aspose.com/slides/pt/python-net/aspose.slides/patternstyle/) com primeiro plano laranja escuro e fundo branco, então adicione um contorno de texto preto com largura de 1 ponto:

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

O texto resultante:

![O modelo WordArt simples](WordArt_template.png)

## **Aplicar Outros Efeitos WordArt**

Os exemplos a seguir demonstram como aplicar sombras, reflexos, brilho, transformações e efeitos 3D ao texto.

### **Aplicar Efeitos de Sombra Externa**

Uma sombra externa adiciona profundidade colocando uma sombra atrás do texto. Você pode personalizar sua cor, direção, distância, raio de desfoque, escala e inclinação.

Este exemplo chama [enable_outer_shadow_effect](https://reference.aspose.com/slides/pt/python-net/aspose.slides/effectformat/enable_outer_shadow_effect/) e define uma sombra preta com raio de desfoque de 4 pontos, direção de 230 graus e distância de 30 pontos. Valores de escala de 100 preservam o tamanho da sombra, enquanto a inclinação horizontal a inclina em 20 graus. A transformação alfa define sua opacidade em 32%:

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

O texto resultante:

![O efeito de Sombra Externa](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Quando sombras externas e pré‑definidas são usadas juntas, somente a sombra externa é aplicada.
- Se sombras externas e internas forem usadas simultaneamente, o efeito resultante depende da versão do PowerPoint. Por exemplo, no PowerPoint 2013, o efeito é dobrado, enquanto no PowerPoint 2007, apenas a sombra externa é aplicada.
{{% /alert %}}

### **Aplicar Efeitos de Reflexão**

Uma reflexão cria uma cópia espelhada do texto. Ajuste sua posição, escala, desfoque e opacidade para controlar sua aparência.

Este exemplo chama [enable_reflection_effect](https://reference.aspose.com/slides/pt/python-net/aspose.slides/effectformat/enable_reflection_effect/) e inverte a reflexão verticalmente com escala de -100%. Usa um raio de desfoque de 0,5 ponto e uma distância de 4,72 pontos. A opacidade diminui de 60% para 0,9% entre as posições 0% e 60% ao longo da reflexão:

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

O texto resultante:

![O efeito de Reflexão](reflection_effect.png)

### **Aplicar Efeitos de Brilho**

Um brilho adiciona um contorno colorido suave ao redor do texto. Ajuste sua cor, opacidade e raio para controlar o efeito.

Este exemplo chama [enable_glow_effect](https://reference.aspose.com/slides/pt/python-net/aspose.slides/effectformat/enable_glow_effect/) e aplica um brilho vermelho com opacidade de 54% e raio de 7 pontos:

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

O texto resultante:

![O efeito de Brilho](glow_effect.png)

### **Aplicar Transformações WordArt**

As transformações WordArt curvam, esticam ou deformam um bloco de texto.

Defina [transform](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframeformat/transform/) como [ARCH_UP_POUR](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textshapetype/) para curvar todo o quadro de texto para cima:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    text_frame = auto_shape.text_frame
    text_frame.text = "Aspose.Slides"
    text_frame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

O texto resultante:

![A transformação WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via .NET fornece um conjunto de [tipos de transformação](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textshapetype/) predefinidos.
{{% /alert %}}

### **Aplicar Efeitos 3D a Formas e Texto**

Você pode aplicar efeitos 3D a uma forma ou ao seu texto. Chanfros, extrusão, iluminação e configurações de câmera controlam a aparência resultante.

O exemplo a seguir usa [ThreeDFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/threedformat/) para adicionar chanfros circulares, extrusão laranja e contorno vermelho escuro ao retângulo. As dimensões do chanfro, altura da extrusão, largura e profundidade do contorno são medidas em pontos. Um material plástico, iluminação equilibrada rotacionada em 40 graus ao redor do eixo Z, e uma câmera perspectiva definem sua aparência:

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

A forma resultante:

![O efeito 3D da forma](shape_3D_effect.png)

Este exemplo aplica formatação 3D semelhante ao texto via [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframeformat/three_d_format/). Chanfros menores moldam as bordas das letras, enquanto a extrusão e a iluminação dão profundidade ao texto:

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

O texto resultante:

![O efeito 3D do texto](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
A aplicação de efeitos 3D ao texto ou às suas formas — e a interação entre esses efeitos — é regida por regras específicas. Considere uma cena envolvendo tanto o texto quanto a forma que o contém. Um efeito 3D inclui a representação 3D do objeto e a cena na qual ele está inserido.

- Se uma cena for definida tanto para a forma quanto para o texto, a cena da forma tem prioridade e a cena do texto é ignorada.
- Se a forma não possuir sua própria cena, mas tiver uma representação 3D, a cena do texto será usada.
- Se a forma não tiver nenhum efeito 3D, será tratada como plana, e o efeito 3D será aplicado somente ao texto.

Esses comportamentos referem‑se às propriedades [ThreeDFormat.light_rig](https://reference.aspose.com/slides/pt/python-net/aspose.slides/threedformat/light_rig/) e [ThreeDFormat.camera](https://reference.aspose.com/slides/pt/python-net/aspose.slides/threedformat/camera/).
{{% /alert %}}

Para manter o texto plano e legível ao mesmo tempo que preserva a formatação 3D da forma, veja [Keep Text Flat on a 3D Shape](/slides/pt/python-net/3d-presentation/) para uma comparação de ambas as configurações e um exemplo Python completo.

## **Perguntas Frequentes**

**Posso usar efeitos WordArt com diferentes fontes ou scripts (por exemplo, Árabe, Chinês)?**

Sim, o Aspose.Slides for Python via .NET oferece suporte a Unicode e funciona com todas as principais fontes e scripts. Efeitos WordArt como sombra, preenchimento e contorno podem ser aplicados independentemente do idioma, embora a disponibilidade da fonte e a renderização possam depender das fontes do sistema.

**Posso aplicar efeitos WordArt a elementos do mestre de slides?**

Sim, você pode aplicar efeitos WordArt a formas nos slides mestres, incluindo marcadores de posição de título, rodapés ou texto de fundo. Alterações feitas ao layout mestre serão refletidas em todos os slides associados.

**Os efeitos WordArt afetam o tamanho do arquivo da apresentação?**

Um pouco. Efeitos WordArt como sombras, brilhos e preenchimentos gradientes podem aumentar ligeiramente o tamanho do arquivo devido a metadados de formatação adicionais, mas a diferença costuma ser insignificante.

**Posso visualizar o resultado dos efeitos WordArt sem salvar a apresentação?**

Sim, você pode renderizar slides que contêm WordArt em imagens (por exemplo, PNG, JPEG) usando [Slide.get_image](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/get_image/), ou renderizar formas individuais usando [Shape.get_image](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/get_image/). Isso permite pré‑visualizar o resultado na memória ou na tela antes de salvar ou exportar a apresentação completa.