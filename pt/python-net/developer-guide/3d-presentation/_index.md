---
title: Criar efeitos 3D em apresentações usando Python
linktitle: Apresentação 3D
type: docs
weight: 232
url: /pt/python-net/3d-presentation/
keywords:
- PowerPoint 3D
- apresentação 3D
- rotação 3D
- profundidade 3D
- extrusão 3D
- gradiente 3D
- texto 3D
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Aplicar e renderizar efeitos 3D para formas e texto do PowerPoint em Python com Aspose.Slides. Configurar câmera, iluminação, material, extrusão, preenchimentos e texto 3D."
---
## **Visão geral**

Aspose.Slides for Python via .NET pode criar, editar, preservar e renderizar formatação 3D no estilo PowerPoint para formas e texto. Este artigo aborda efeitos 3D como rotação, extrusão, chanfrados, iluminação, material, preenchimentos em gradiente ou imagem e texto 3D.

{{% alert color="info" title="Note" %}}
Este artigo trata de efeitos de formatação 3D em formas e texto do PowerPoint. Não trata da inserção ou edição de arquivos de modelo 3D independentes. Quando você exporta um slide para imagem, PDF ou HTML, o Aspose.Slides renderiza esses efeitos 3D na saída 2D exportada.
{{% /alert %}}

## **Conceitos de Formatação 3D**

Use a propriedade [Shape.three_d_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/three_d_format/) para aplicar formatação 3D a uma forma. A propriedade expõe [ThreeDFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/threedformat/), que controla a cena 3D para essa forma.

Para texto, use a propriedade [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframeformat/three_d_format/) . Isso aplica formatação 3D ao quadro de texto em vez do corpo da forma.

As propriedades mais importantes são:

| Propriedade | O que controla | Quando usar |
|---|---|---|
| [camera](https://reference.aspose.com/slides/pt/python-net/aspose.slides/threedformat/camera/) | Ponto de vista, tipo de câmera predefinido, rotação, zoom e perspectiva. | Rotacionar o objeto no espaço 3D ou corresponder a um preset de rotação 3D do PowerPoint. |
| [light_rig](https://reference.aspose.com/slides/pt/python-net/aspose.slides/threedformat/light_rig/) | Preset de luz, direção e rotação da luz. | Alterar como realces e sombras aparecem na superfície 3D. |
| [material](https://reference.aspose.com/slides/pt/python-net/aspose.slides/threedformat/material/) | Material da superfície, como plano, fosco, plástico ou metal. | Fazer a mesma geometria parecer mais plana, suave, brilhante ou metálica. |
| [extrusion_height](https://reference.aspose.com/slides/pt/python-net/aspose.slides/threedformat/extrusion_height/) | Quão longe a forma se estende para trás a partir de sua face frontal. | Transformar uma forma plana em um objeto 3D visivelmente espesso. |
| [extrusion_color](https://reference.aspose.com/slides/pt/python-net/aspose.slides/threedformat/extrusion_color/) | Cor dos lados extrudidos. | Tornar a profundidade visível ou coordenar a cor lateral com o preenchimento frontal. |
| [depth](https://reference.aspose.com/slides/pt/python-net/aspose.slides/threedformat/depth/) | Profundidade 3D adicional usada pela formatação 3D do PowerPoint. | Ajustar finamente a profundidade para formas ou texto, especialmente junto com configurações de chanfrado e material. |
| [bevel_top](https://reference.aspose.com/slides/pt/python-net/aspose.slides/threedformat/bevel_top/) e [bevel_bottom](https://reference.aspose.com/slides/pt/python-net/aspose.slides/threedformat/bevel_bottom/) | Bordas elevadas ou arredondadas nas faces frontal e traseira. | Adicionar uma borda suavizada ou moldada em vez de uma face plana e afiada. |
| [contour_color](https://reference.aspose.com/slides/pt/python-net/aspose.slides/threedformat/contour_color/) e [contour_width](https://reference.aspose.com/slides/pt/python-net/aspose.slides/threedformat/contour_width/) | Contorno ao redor do objeto 3D. | Realçar o limite do objeto na saída renderizada. |

## **Criar uma Forma 3D**

Uma forma geralmente precisa de quatro tipos de configurações antes de parecer convincentemente 3D:

- Configurações de câmera, porque a visualização frontal padrão pode ocultar a extrusão.
- Configurações de luz, porque a iluminação torna as faces e os lados legíveis.
- Configurações de material, porque a superfície afeta como a luz é renderizada.
- Configurações de extrusão ou profundidade, porque uma forma plana precisa de espessura.

O exemplo a seguir cria um retângulo, adiciona texto à sua face frontal e aplica formatação 3D. Os valores de rotação da câmera estão em graus, e a altura da extrusão é 100 pontos. O exemplo renderiza o slide para uma imagem PNG em duas vezes suas dimensões padrão e salva a apresentação como PPTX.

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

A imagem do slide renderizado mostra o retângulo como um bloco 3D espesso:

![Retângulo 3D azul renderizado com texto 3D branco na face frontal](img_01_01.png)

## **Rotacionar uma Forma com a Câmera**

No PowerPoint, a rotação 3D é configurada no painel 3‑D Rotation. Os valores de rotação X, Y e Z correspondem à rotação que você define através da API de câmera.

![Painel 3‑D Rotation do PowerPoint com valores de rotação X, Y e Z destacados](img_02_01.png)

No Aspose.Slides, acesse a câmera através de [ThreeDFormat.camera](https://reference.aspose.com/slides/pt/python-net/aspose.slides/threedformat/camera/). Este exemplo cria um retângulo, seleciona uma visualização ortográfica frontal e define suas rotações X, Y e Z para 20, 30 e 40 graus, respectivamente. Ele configura a forma na memória sem salvar um arquivo:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Use a câmera quando precisar alterar como o observador vê o objeto. Ela não altera a geometria 2D da forma no slide. Ela altera o ponto de vista 3D usado pelo PowerPoint e pelo Aspose.Slides ao renderizar.

## **Adicionar Extrusão e Profundidade**

A extrusão faz uma forma parecer espessa ao estendê‑la para trás da face frontal. No PowerPoint, o controle de profundidade define essa espessura visível, e o controle de cor define a cor das faces laterais.

![Controles de profundidade do PowerPoint mapeados para as propriedades extrusion_color e extrusion_height](img_02_02.png)

Defina [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/pt/python-net/aspose.slides/threedformat/extrusion_height/) para a espessura e [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/pt/python-net/aspose.slides/threedformat/extrusion_color/) para a cor lateral. Este exemplo dá ao retângulo uma extrusão de 100 pontos com lados roxos e rotaciona a câmera para revelar sua espessura. Ele configura a forma na memória sem salvar um arquivo:

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

A propriedade [ThreeDFormat.depth](https://reference.aspose.com/slides/pt/python-net/aspose.slides/threedformat/depth/) define a profundidade de uma forma 3D. A propriedade [extrusion_height](https://reference.aspose.com/slides/pt/python-net/aspose.slides/threedformat/extrusion_height/) controla a altura do efeito de extrusão, como mostrado neste exemplo.

## **Usar Preenchimentos em Gradiente ou Imagem com Efeitos 3D**

A formatação 3D é independente do preenchimento da forma. Você pode aplicar uma cor sólida, gradiente, padrão ou preenchimento de imagem à face frontal e ainda usar as mesmas configurações de câmera, luz, material e extrusão.

Este exemplo aplica um gradiente azul‑para‑laranja à face frontal e uma cor laranja escura à extrusão de 150 pontos. As paradas do gradiente em 0 e 100 marcam o início e o fim do gradiente. Os valores de rotação da câmera estão em graus. O slide é renderizado para uma imagem PNG em duas vezes suas dimensões padrão:

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

A saída renderizada mantém o gradiente na face frontal e renderiza a extrusão separadamente:

![Retângulo 3D renderizado com preenchimento em gradiente azul‑para‑laranja e extrusão laranja](img_02_03.png)

Para usar um preenchimento de imagem, adicione a imagem à apresentação e atribua‑a ao preenchimento da forma. Este exemplo requer um arquivo existente chamado "image.jpg" no diretório de trabalho. Ele estica a imagem para preencher o retângulo, aplica uma extrusão de 150 pontos e define a rotação da câmera em graus. Ele configura a forma na memória sem salvar ou renderizar um arquivo:

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

A imagem é renderizada na face frontal, enquanto a extrusão é renderizada como a superfície lateral 3D:

![Retângulo 3D renderizado com preenchimento de foto na face frontal e extrusão laranja](img_02_04.png)

## **Aplicar Formatação 3D ao Texto**

A formatação 3D de forma afeta o corpo da forma. A formatação 3D de texto afeta o quadro de texto. Isso é útil para efeitos tipo WordArt onde as próprias letras precisam de extrusão, material, iluminação e configurações de câmera.

O exemplo a seguir cria texto com um padrão de grade laranja‑e‑branco, aplica um arco ascendente e configura as definições 3D através de [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframeformat/three_d_format/). A altura da extrusão e a profundidade estão em pontos, e a rotação da luz está em graus. O preenchimento e o contorno da forma são ocultados para que somente o texto seja visível. O exemplo renderiza uma imagem PNG em duas vezes as dimensões padrão do slide e salva a apresentação como PPTX:

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

O texto é renderizado como letras 3D curvadas e extrudidas:

![Texto 3D renderizado com transformação de arco WordArt, preenchimento de padrão laranja e extrusão escura](img_02_05.png)

## **Manter o Texto Plano em uma Forma 3D**

Para manter o texto legível enquanto preserva a aparência 3D da forma, defina [TextFrameFormat.keep_text_flat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframeformat/keep_text_flat/) através de [TextFrame.text_frame_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/text_frame_format/). Quando o valor é `True`, o texto permanece fora da cena 3D. Quando é `False`, o texto participa da cena e segue sua orientação 3D.

Esta configuração não remove a formatação 3D da forma: sua câmera, iluminação, material e extrusão permanecem configurados através de [Shape.three_d_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/three_d_format/). Também difere da rotação comum. [Shape.rotation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/rotation/) rotaciona a forma no plano do slide, enquanto [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframeformat/rotation_angle/) controla a rotação personalizada do texto dentro de sua caixa delimitadora. Manter o texto fora da cena 3D não redefine nenhum desses ângulos.

O exemplo autônomo a seguir cria um retângulo azul com texto e o duplica ao lado do original. Ambas as formas têm a mesma formatação 3D; apenas a configuração de texto difere: `False` à esquerda e `True` à direita. Os ângulos da câmera estão em graus, e a altura da extrusão é 40 pontos. O exemplo salva a apresentação como PPTX e renderiza o slide de comparação para PNG em duas vezes suas dimensões padrão.

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

À esquerda, o texto segue a orientação 3D. À direita, ele permanece plano e mais fácil de ler. Ambos os retângulos mantêm a mesma extrusão visível e orientação 3D.

![Retângulos 3D lado a lado: keep_text_flat é False à esquerda e True à direita](keep_text_flat.png)

## **Comportamento de Exportação e Renderização**

Aspose.Slides preserva a formatação 3D ao salvar em formatos do PowerPoint como PPTX. Ao renderizar ou exportar para formatos de layout fixo, a cena 3D é rasterizada ou desenhada na saída como um resultado 2D. Isso se aplica quando você renderiza slides para [PNG](/slides/pt/python-net/convert-powerpoint-to-png/), exporta para [PDF](/slides/pt/python-net/convert-powerpoint-to-pdf/), exporta para [HTML](/slides/pt/python-net/convert-powerpoint-to-html/), ou gera quadros para [conversão de vídeo](/slides/pt/python-net/convert-powerpoint-to-video/).

Mantenha esses pontos em mente:

- Imagens e PDFs exportados não são interativos. O objeto não pode ser rotacionado pelo visualizador após a exportação.
- A aparência final depende da combinação de câmera, rig de luz, material, extrusão, preenchimento e escala do slide.
- Se precisar inspecionar valores de formatação herdados ou baseados em tema, leia as [propriedades de forma efetivas](/slides/pt/python-net/shape-effective-properties/).
- Alguns formatos de saída não podem armazenar formatação 3D editável do PowerPoint. Nesses formatos, o resultado visual é renderizado em vez de preservado como configurações 3D editáveis.

## **FAQ**

**O Aspose.Slides pode criar apresentações 3D interativas?**

Aspose.Slides cria e renderiza efeitos 3D do PowerPoint para formas e texto. Não torna imagens exportadas, PDFs ou páginas HTML interativas como cenas 3D que o visualizador possa rotacionar. No PPTX, a formatação 3D permanece editável no PowerPoint onde o formato a suporta.

**Qual é a diferença entre um modelo 3D e um efeito 3D?**

Um modelo 3D é um objeto 3D separado inserido na apresentação. Um efeito 3D é formatação aplicada a uma forma ou texto comum do PowerPoint, como rotação, extrusão, chanfrado, iluminação e material. Este artigo cobre efeitos 3D.

**Quais configurações são necessárias para uma forma 3D visível?**

No mínimo, defina uma rotação de câmera e extrusão ou profundidade. Na prática, também configure um rig de luz e material para que as faces renderizadas tenham realces e sombras claros.

**Posso aplicar efeitos 3D tanto a formas quanto a texto?**

Sim. Use [Shape.three_d_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/three_d_format/) para o corpo da forma e [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframeformat/three_d_format/) para o texto.

**Os efeitos 3D aparecerão ao exportar para imagens, PDF, HTML ou quadros de vídeo?**

Sim. Aspose.Slides renderiza os efeitos 3D ao produzir imagens de slide, saída PDF, saída HTML e quadros usados na conversão de vídeo. A saída exportada contém a aparência renderizada, não um objeto 3D editável.

**Posso ler os valores finais de 3D após a aplicação de herança e configurações de tema?**

Sim. Use as APIs de formatação efetiva descritas em [Shape Effective Properties](/slides/pt/python-net/shape-effective-properties/) para ler a câmera final, rig de luz, chanfrado e valores 3D relacionados.