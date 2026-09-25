---
title: Criar e Aplicar Efeitos WordArt em Python via Java
linktitle: WordArt
type: docs
weight: 110
url: /pt/python-java/wordart/
keywords:
- WordArt
- criar WordArt
- modelo WordArt
- efeito WordArt
- efeito sombra
- efeito reflexão
- efeito brilho
- transformação WordArt
- efeito 3D
- efeito sombra externa
- efeito sombra interna
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Crie e personalize efeitos WordArt no Aspose.Slides para Python via Java. Este guia passo a passo ajuda desenvolvedores a aprimorar apresentações com texto profissional em Python via Java."
---
## **Visão geral**

Os efeitos WordArt permitem estilizar texto com preenchimentos, contornos, sombras, reflexos, brilho, transformações e formatação 3D. Este artigo explica como criar e personalizar esses efeitos em apresentações do PowerPoint usando Aspose.Slides for Python via Java, sem o Microsoft Office instalado.

## **Criar um modelo WordArt simples e aplicá‑lo ao texto**

Os exemplos a seguir criam um estilo WordArt simples definindo o texto, fonte, preenchimento de padrão e contorno.

Cada exemplo cria uma nova apresentação e adiciona um retângulo ao seu primeiro slide; nenhum arquivo de entrada é necessário. O primeiro exemplo define o texto como "Aspose.Slides". A posição e as dimensões da forma são medidas em pontos:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    text_frame = auto_shape.getTextFrame()

    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
finally:
    presentation.dispose()
```

Defina a fonte como Arial Black em 36 pontos para tornar a formatação mais perceptível:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)
finally:
    presentation.dispose()
```

Aplique um padrão [SmallGrid](https://reference.aspose.com/slides/pt/python-java/aspose.slides/patternstyle/#SmallGrid) com primeiro plano laranja escuro e fundo branco, depois adicione um contorno de texto preto com largura de 1 ponto:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, PatternStyle, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern)
    dark_orange = Color(255, 140, 0)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(dark_orange)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE)
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid)

    portion.getPortionFormat().getLineFormat().setWidth(1)
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
finally:
    presentation.dispose()
```

O texto resultante:

![O modelo WordArt simples](WordArt_template.png)

## **Aplicar outros efeitos WordArt**

Os exemplos a seguir demonstram como aplicar sombras, reflexos, brilho, transformações e efeitos 3D ao texto.

### **Aplicar efeitos de sombra externa**

Uma sombra externa adiciona profundidade ao colocar uma sombra atrás do texto. Você pode personalizar sua cor, direção, distância, raio de desfoque, escala e inclinação.

Este exemplo chama [enableOuterShadowEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/effectformat/#enableOuterShadowEffect) e define uma sombra preta com raio de desfoque de 4 pontos, direção de 230 graus e distância de 30 pontos. Valores de escala de 100 preservam o tamanho da sombra, enquanto a inclinação horizontal a inclina em 20 graus. A transformação alfa define sua opacidade para 32%:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FontData, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect()
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32)
finally:
    presentation.dispose()
```

O texto resultante:

![O efeito Sombra Externa](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Quando sombras externas e predefinidas são usadas juntas, apenas a sombra externa é aplicada.
- Se sombras externas e internas forem usadas simultaneamente, o efeito resultante depende da versão do PowerPoint. Por exemplo, no PowerPoint 2013, o efeito é duplicado, enquanto no PowerPoint 2007 apenas a sombra externa é aplicada.
{{% /alert %}}

### **Aplicar efeitos de reflexão**

Uma reflexão cria uma cópia espelhada do texto. Ajuste sua posição, escala, desfoque e opacidade para controlar sua aparência.

Este exemplo chama [enableReflectionEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/effectformat/#enableReflectionEffect) e inverte a reflexão verticalmente com escala de -100%. Usa um raio de desfoque de 0,5 ponto e distância de 4,72 pontos. A opacidade diminui de 60% para 0,9% entre as posições 0% e 60% ao longo da reflexão:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, RectangleAlignment, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect()
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft)
finally:
    presentation.dispose()
```

O texto resultante:

![O efeito Reflexão](reflection_effect.png)

### **Aplicar efeitos de brilho**

Um brilho adiciona um contorno colorido suave ao redor do texto. Ajuste sua cor, opacidade e raio para controlar o efeito.

Este exemplo chama [enableGlowEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/effectformat/#enableGlowEffect) e aplica um brilho vermelho com opacidade de 54% e raio de 7 pontos:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FontData, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableGlowEffect()
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(Color.RED)
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54)
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7)
finally:
    presentation.dispose()
```

O texto resultante:

![O efeito Brilho](glow_effect.png)

### **Aplicar transformações WordArt**

As transformações WordArt curvam, esticam ou distorcem um bloco de texto.

Defina [setTransform](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframeformat/#setTransform) para [ArchUpPour](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textshapetype/#ArchUpPour) para curvar todo o quadro de texto para cima:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, TextShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")
    text_frame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour)
finally:
    presentation.dispose()
```

O texto resultante:

![A transformação WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java fornece um conjunto de [tipos de transformação predefinidos](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textshapetype/).
{{% /alert %}}

### **Aplicar efeitos 3D a formas e texto**

Você pode aplicar efeitos 3D a uma forma ou ao seu texto. Chanfros, extrusão, iluminação e configurações de câmera controlam a aparência resultante.

O exemplo a seguir usa [ThreeDFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/threedformat/) para adicionar chanfros circulares, extrusão laranja e contorno vermelho escuro ao retângulo. Dimensões dos chanfros, altura da extrusão, largura do contorno e profundidade são medidos em pontos. Um material plástico, iluminação balanceada girada 40 graus ao redor do eixo Z, e uma câmera em perspectiva definem sua aparência:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    auto_shape.getTextFrame().setText("Aspose.Slides")

    auto_shape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle)
    auto_shape.getThreeDFormat().getBevelBottom().setHeight(10.5)
    auto_shape.getThreeDFormat().getBevelBottom().setWidth(10.5)

    auto_shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    auto_shape.getThreeDFormat().getBevelTop().setHeight(12.5)
    auto_shape.getThreeDFormat().getBevelTop().setWidth(11)

    orange = Color(255, 165, 0)
    auto_shape.getThreeDFormat().getExtrusionColor().setColor(orange)
    auto_shape.getThreeDFormat().setExtrusionHeight(6)

    dark_red = Color(139, 0, 0)
    auto_shape.getThreeDFormat().getContourColor().setColor(dark_red)
    auto_shape.getThreeDFormat().setContourWidth(1.5)

    auto_shape.getThreeDFormat().setDepth(3)

    auto_shape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic)

    auto_shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    auto_shape.getThreeDFormat().getLightRig().setRotation(0, 0, 40)

    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

A forma resultante:

![O efeito 3D da forma](shape_3D_effect.png)

Este exemplo aplica formatação 3D semelhante ao texto através de [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframeformat/#getThreeDFormat). Chanfros menores moldam as bordas das letras, enquanto a extrusão e a iluminação dão profundidade ao texto:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5)

    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4)

    orange = Color(255, 165, 0)
    text_frame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange)
    text_frame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6)

    dark_red = Color(139, 0, 0)
    text_frame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(dark_red)
    text_frame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5)

    text_frame.getTextFrameFormat().getThreeDFormat().setDepth(3)

    text_frame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic)

    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40)

    text_frame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

O texto resultante:

![O efeito 3D do texto](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
A aplicação de efeitos 3D ao texto ou às suas formas—e a interação entre esses efeitos—é regida por regras específicas. Considere uma cena envolvendo tanto o texto quanto a forma que o contém. Um efeito 3D inclui a representação 3D do objeto e a cena em que ele está inserido.

- Se uma cena for definida tanto para a forma quanto para o texto, a cena da forma tem prioridade e a cena do texto é ignorada.
- Se a forma não possuir sua própria cena, mas tiver uma representação 3D, a cena do texto será usada.
- Se a forma não tiver efeito 3D algum, ela será tratada como plana, e o efeito 3D será aplicado somente ao texto.

Esses comportamentos relacionam‑se aos métodos [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/pt/python-java/aspose.slides/threedformat/#getLightRig) e [ThreeDFormat.getCamera](https://reference.aspose.com/slides/pt/python-java/aspose.slides/threedformat/#getCamera).
{{% /alert %}}

Para manter o texto plano e legível enquanto preserva a formatação 3D da forma, consulte [Keep Text Flat on a 3D Shape](/slides/pt/python-java/3d-presentation/) para comparação de ambas as configurações e um exemplo completo em Python.

## **Perguntas frequentes**

**Posso usar efeitos WordArt com fontes ou scripts diferentes (por exemplo, árabe, chinês)?**

Sim, Aspose.Slides for Python via Java suporta Unicode e funciona com todas as principais fontes e scripts. Efeitos WordArt como sombra, preenchimento e contorno podem ser aplicados independentemente do idioma, embora a disponibilidade da fonte e a renderização possam depender das fontes do sistema.

**Posso aplicar efeitos WordArt a elementos do slide mestre?**

Sim, você pode aplicar efeitos WordArt a formas em slides mestres, incluindo marcadores de posição de título, rodapés ou texto de fundo. Alterações feitas no layout mestre serão refletidas em todos os slides associados.

**Os efeitos WordArt afetam o tamanho do arquivo da apresentação?**

Um pouco. Efeitos WordArt como sombras, brilhos e preenchimentos gradientes podem aumentar levemente o tamanho do arquivo devido a metadados de formatação adicionais, mas a diferença costuma ser insignificante.

**Posso visualizar o resultado dos efeitos WordArt sem salvar a apresentação?**

Sim, você pode renderizar slides que contêm WordArt em imagens (por exemplo, PNG, JPEG) usando [Slide.getImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slide/#getImage), ou renderizar formas individuais usando [Shape.getImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getImage). Isso permite visualizar o resultado na memória ou na tela antes de salvar ou exportar a apresentação completa.