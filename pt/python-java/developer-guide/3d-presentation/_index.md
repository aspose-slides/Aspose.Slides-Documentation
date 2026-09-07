---
title: Criar Efeitos 3D em Apresentações Usando Python
linktitle: Apresentação 3D
type: docs
weight: 232
url: /pt/python-java/3d-presentation/
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
- Java
- Aspose.Slides
description: "Aplicar e renderizar efeitos 3D para formas e texto do PowerPoint em Python via Java com Aspose.Slides. Configurar câmera, iluminação, material, extrusão, preenchimentos e texto 3D."
---
## **Visão geral**

Aspose.Slides for Python via Java pode criar, editar, preservar e renderizar formatação 3D no estilo PowerPoint para formas e texto. Este artigo aborda efeitos 3D como rotação, extrusão, biséis, iluminação, material, preenchimentos degradê ou imagem e texto 3D.

{{% alert color="info" title="Nota" %}}

Este artigo trata de efeitos de formatação 3D em formas e texto do PowerPoint. Não se trata de inserir ou editar arquivos de modelo 3D independentes. Quando você exporta um slide para imagem, PDF ou HTML, o Aspose.Slides renderiza esses efeitos 3D na saída 2D exportada.

{{% /alert %}}

Instale o pacote conforme descrito em [Instalação](/slides/pt/python-java/installation/). Cada exemplo importa `asposeslides`, inicia a JVM se necessário e, em seguida, importa a API. O exemplo de preenchimento por imagem requer um arquivo `image.jpg` no diretório de trabalho.

## **Conceitos de Formatação 3D**

Use [Shape.getThreeDFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getThreeDFormat) para aplicar formatação 3D a uma forma. O objeto de formato retornado controla a cena 3D para aquela forma.

Para texto, use [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframeformat/#getThreeDFormat). Isso aplica formatação 3D ao quadro de texto em vez do corpo da forma.

Os membros de API mais importantes são:

| Membro da API | O que controla | Quando usar |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/pt/python-java/aspose.slides/threedformat/#getCamera) | Ponto de vista, tipo de câmera predefinido, rotação, zoom e perspectiva. | Rotacionar o objeto no espaço 3D ou corresponder a um preset de rotação 3D do PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/pt/python-java/aspose.slides/threedformat/#getLightRig) | Preset de luz, direção e rotação da luz. | Alterar como realces e sombras aparecem na superfície 3D. |
| [getMaterial](https://reference.aspose.com/slides/pt/python-java/aspose.slides/threedformat/#getMaterial) e [setMaterial](https://reference.aspose.com/slides/pt/python-java/aspose.slides/threedformat/#setMaterial) | Material da superfície, como plano, fosco, plástico ou metal. | Fazer a mesma geometria parecer mais plana, suave, brilhante ou metálica. |
| [getExtrusionHeight](https://reference.aspose.com/slides/pt/python-java/aspose.slides/threedformat/#getExtrusionHeight) e [setExtrusionHeight](https://reference.aspose.com/slides/pt/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Distância que a forma se estende para trás a partir da face frontal. | Transformar uma forma plana em um objeto 3D visivelmente espesso. |
| [getExtrusionColor](https://reference.aspose.com/slides/pt/python-java/aspose.slides/threedformat/#getExtrusionColor) | Cor dos lados extrudados. | Tornar a profundidade visível ou coordenar a cor lateral com o preenchimento frontal. |
| [getDepth](https://reference.aspose.com/slides/pt/python-java/aspose.slides/threedformat/#getDepth) e [setDepth](https://reference.aspose.com/slides/pt/python-java/aspose.slides/threedformat/#setDepth) | Profundidade 3D adicional usada pela formatação 3D do PowerPoint. | Ajustar a profundidade para formas ou texto, especialmente junto com configurações de bisel e material. |
| [getBevelTop](https://reference.aspose.com/slides/pt/python-java/aspose.slides/threedformat/#getBevelTop) e [getBevelBottom](https://reference.aspose.com/slides/pt/python-java/aspose.slides/threedformat/#getBevelBottom) | Bisel elevado ou arredondado nas faces frontal e traseira. | Adicionar um contorno suavizado ou moldado em vez de uma face plana e afiada. |
| [getContourColor](https://reference.aspose.com/slides/pt/python-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/pt/python-java/aspose.slides/threedformat/#getContourWidth) e [setContourWidth](https://reference.aspose.com/slides/pt/python-java/aspose.slides/threedformat/#setContourWidth) | Contorno ao redor do objeto 3D. | Realçar o limite do objeto na saída renderizada. |

## **Criar uma Forma 3D**

Uma forma geralmente precisa de quatro tipos de configurações antes de parecer convincentemente 3D:

- Configurações de câmera, porque a visualização frontal padrão pode ocultar a extrusão.
- Configurações de luz, porque a iluminação torna as faces e lados legíveis.
- Configurações de material, porque a superfície afeta como a luz é renderizada.
- Configurações de extrusão ou profundidade, porque uma forma plana necessita de espessura.

O exemplo a seguir cria um retângulo, adiciona texto à sua face frontal, aplica formatação 3D, salva a apresentação como PPTX e renderiza o slide para uma imagem PNG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)
    shape.getTextFrame().setText("3D")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("shape_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("shape_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A imagem do slide renderizado mostra o retângulo como um bloco 3D espesso:

![Retângulo 3D azul renderizado com texto 3D branco na face frontal](img_01_01.png)

## **Rotacionar uma Forma com a Câmera**

No PowerPoint, a rotação 3D é configurada no painel 3‑D Rotation. Os valores de rotação X, Y e Z correspondem à rotação que você define através da API de câmera.

![Painel 3‑D Rotation do PowerPoint com valores de rotação X, Y e Z destacados](img_02_01.png)

No Aspose.Slides, defina o tipo de câmera e a rotação através do formato 3D retornado por [Shape.getThreeDFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getThreeDFormat):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
finally:
    presentation.dispose()
```

Use a câmera quando precisar mudar como o visualizador vê o objeto. Ela não altera a geometria da forma 2D no slide. Ela altera o ponto de vista 3D usado pelo PowerPoint e pelo Aspose.Slides ao renderizar.

## **Adicionar Extrusão e Profundidade**

A extrusão faz uma forma parecer espessa ao estendê‑la atrás da face frontal. No PowerPoint, o controle de profundidade define essa espessura visível, e o controle de cor define a cor das faces laterais.

![Controles de profundidade do PowerPoint mapeados para propriedades de cor de extrusão e altura de extrusão](img_02_02.png)

Defina a altura da extrusão para a espessura e a cor da extrusão para a cor lateral:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

Use a configuração de profundidade quando precisar trabalhar diretamente com o valor de profundidade do PowerPoint ou combinar profundidade com bisel, material e efeitos de texto. Em muitos cenários de forma, a altura da extrusão é a configuração mais clara porque expressa diretamente a extrusão visível.

## **Usar Preenchimentos Degradê ou Imagem com Efeitos 3D**

A formatação 3D é independente do preenchimento da forma. Você pode aplicar uma cor sólida, degradê, padrão ou preenchimento de imagem à face frontal e ainda usar as mesmas configurações de câmera, luz, material e extrusão.

Este exemplo aplica um preenchimento degradê à forma e uma cor de extrusão mais escura aos lados:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getTextFrame().setText("3D Gradient")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("gradient_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()
finally:
    presentation.dispose()
```

A saída renderizada mantém o degradê na face frontal e renderiza a extrusão separadamente:

![Retângulo 3D renderizado com preenchimento degradê azul‑para‑laranja e extrusão laranja](img_02_03.png)

Para usar um preenchimento de imagem, adicione a imagem à apresentação e atribua‑a ao preenchimento da forma:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PictureFillMode, Presentation, ShapeType
from java.awt import Color
from pathlib import Path
from java.nio.file import Files, Paths

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)

    file_path = str(Path("image.jpg").resolve())
    image_path = Paths.get(file_path)
    image_data = Files.readAllBytes(image_path)
    image = presentation.getImages().addImage(image_data)

    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

A imagem é renderizada na face frontal, enquanto a extrusão é renderizada como a superfície lateral 3D:

![Retângulo 3D renderizado com preenchimento de foto na face frontal e extrusão laranja](img_02_04.png)

## **Aplicar Formatação 3D ao Texto**

A formatação 3D da forma afeta o corpo da forma. A formatação 3D do texto afeta o quadro de texto. Isso é útil para efeitos tipo WordArt onde as próprias letras precisam de extrusão, material, iluminação e configurações de câmera.

O exemplo a seguir cria texto com preenchimento de padrão, aplica uma transformação WordArt e configura as definições 3D em [TextFrameFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframeformat/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, PatternStyle, Presentation, SaveFormat, ShapeType, TextShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().setText("3D Text")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern)
    pattern_color = Color(255, 140, 0)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(pattern_color)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE)
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid)

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128)

    text_frame_format = shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setTransform(TextShapeType.ArchUp)
    text_frame_format.getThreeDFormat().setExtrusionHeight(3.5)
    text_frame_format.getThreeDFormat().setDepth(3)
    text_frame_format.getThreeDFormat().setMaterial(MaterialPresetType.Plastic)
    text_frame_format.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    text_frame_format.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    text_frame_format.getThreeDFormat().getLightRig().setRotation(0, 0, 40)
    text_frame_format.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("text_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("text_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O texto é renderizado como letras curvadas, extrudadas em 3D:

![Texto 3D renderizado com transformação WordArt arqueada, preenchimento de padrão laranja e extrusão escura](img_02_05.png)

## **Comportamento de Exportação e Renderização**

O Aspose.Slides preserva a formatação 3D ao salvar em formatos do PowerPoint como PPTX. Ao renderizar ou exportar para formatos de layout fixo, a cena 3D é rasterizada ou desenhada na saída como um resultado 2D. Isso ocorre ao renderizar slides para PNG, exportar para PDF, exportar para HTML ou gerar quadros para conversão de vídeo.

Tenha em mente os seguintes pontos:

- Imagens e PDFs exportados não são interativos. O objeto não pode ser rotacionado pelo visualizador após a exportação.
- A aparência final depende da combinação de câmera, rig de luz, material, extrusão, preenchimento e dimensionamento do slide.
- Se precisar inspecionar valores de formatação herdados ou baseados em tema, use a API de formatação efetiva.
- Alguns formatos de saída não podem armazenar formatação 3D editável do PowerPoint. Nestes formatos, o resultado visual é renderizado em vez de preservado como configurações 3D editáveis.

## **Perguntas frequentes**

**O Aspose.Slides pode criar apresentações 3D interativas?**

O Aspose.Slides cria e renderiza efeitos 3D do PowerPoint para formas e texto. Ele não torna imagens exportadas, PDFs ou páginas HTML cenas 3D interativas que o visualizador possa rotacionar. No PPTX, a formatação 3D permanece editável no PowerPoint onde o formato a suporta.

**Qual a diferença entre um modelo 3D e um efeito 3D?**

Um modelo 3D é um objeto 3D separado inserido em uma apresentação. Um efeito 3D é formatação aplicada a uma forma ou texto do PowerPoint, como rotação, extrusão, bisel, iluminação e material. Este artigo trata de efeitos 3D.

**Quais configurações são necessárias para uma forma 3D visível?**

No mínimo, defina uma rotação de câmera e either extrusão ou profundidade. Na prática, também configure um rig de luz e material para que as faces renderizadas tenham realces e sombras claros.

**Posso aplicar efeitos 3D tanto a formas quanto a texto?**

Sim. Use [Shape.getThreeDFormat] para o corpo da forma e [TextFrameFormat.getThreeDFormat] para o texto.

**Os efeitos 3D aparecerão ao exportar para imagens, PDF, HTML ou quadros de vídeo?**

Sim. O Aspose.Slides renderiza os efeitos 3D ao gerar imagens de slides, saída PDF, saída HTML e quadros usados na conversão de vídeo. A saída exportada contém a aparência renderizada, não um objeto 3D editável.

**Posso ler os valores finais 3D após a aplicação de herança e configurações de tema?**

Sim. Use [ThreeDFormat.getEffective] para ler os valores finais de câmera, rig de luz, bisel e outros valores 3D.