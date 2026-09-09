---
title: Criar e aplicar efeitos WordArt em Python via Java
linktitle: WordArt
type: docs
weight: 110
url: /pt/python-java/wordart/
keywords:
- WordArt
- criar WordArt
- modelo WordArt
- efeito WordArt
- efeito de sombra
- efeito de reflexão
- efeito de brilho
- transformação WordArt
- efeito 3D
- efeito de sombra externa
- efeito de sombra interna
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Crie e personalize efeitos WordArt no Aspose.Slides para Python via Java. Este guia passo a passo ajuda os desenvolvedores a melhorar apresentações com texto profissional em Python via Java."
---
## **Visão geral**

Os efeitos WordArt permitem que você adicione texto visualmente atraente e estilizado às suas apresentações do PowerPoint. Com Aspose.Slides, os desenvolvedores podem criar, personalizar e gerenciar WordArt programaticamente, assim como no Microsoft PowerPoint — sem a necessidade de ter o Office instalado. Este artigo fornece uma visão geral de como trabalhar com WordArt, incluindo como aplicar transformações de texto, estilos de preenchimento, contornos, sombras e outras opções de formatação para tornar o conteúdo da sua apresentação mais expressivo e envolvente. WordArt permite tratar o texto como um objeto gráfico. Consiste em efeitos ou modificações especiais aplicadas ao texto para torná‑lo mais atraente ou notório.

## **Criar um modelo WordArt simples e aplicá‑lo ao texto**

**Usando Aspose.Slides**

Primeiro, criamos um texto simples usando este código Python:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()

    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
finally:
    presentation.dispose()
```
Em seguida, aumente o tamanho da fonte para tornar o efeito mais perceptível:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    font_data = FontData("Arial Black")
    portion_format = portion.getPortionFormat()
    portion_format.setLatinFont(font_data)
    portion_format.setFontHeight(36)
finally:
    presentation.dispose()
```

**Usando Microsoft PowerPoint**

Acesse o menu de efeitos WordArt no Microsoft PowerPoint:

![Menu de efeitos WordArt no PowerPoint](image-20200930113926-1.png)

Do menu à direita, você pode escolher um efeito WordArt predefinido. Do menu à esquerda, pode especificar as configurações para um novo WordArt.

Estes são alguns dos parâmetros ou opções disponíveis:

![Opções de formatação do WordArt](image-20200930114015-3.png)

**Usando Aspose.Slides**

Aqui, aplicamos o preenchimento de padrão [PatternStyle.SmallGrid](https://reference.aspose.com/slides/pt/python-java/aspose.slides/patternstyle/#SmallGrid) ao texto e adicionamos uma borda preta ao texto usando este código:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getFillFormat().setFillType(FillType.Pattern)
    pattern_format = portion_format.getFillFormat().getPatternFormat()
    pattern_format.getForeColor().setColor(Color.ORANGE)
    pattern_format.getBackColor().setColor(Color.WHITE)
    pattern_format.setPatternStyle(PatternStyle.SmallGrid)

    line_format = portion_format.getLineFormat()
    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
finally:
    presentation.dispose()
```

O texto resultante:

![Texto com preenchimento de padrão e contorno preto](image-20200930114108-4.png)

## **Aplicando outros efeitos WordArt**

**Usando Microsoft PowerPoint**

A partir da interface do programa, você pode aplicar esses efeitos ao texto, a um bloco de texto, a uma forma ou a um elemento semelhante:

![Efeitos de texto e forma no PowerPoint](image-20200930114129-5.png)

Por exemplo, os efeitos Sombra, Reflexo e Brilho podem ser aplicados ao texto; os efeitos Formato 3D e Rotação 3D podem ser aplicados a um bloco de texto; o efeito Bordas Suaves pode ser aplicado a uma forma (ele ainda tem efeito quando nenhum efeito Formato 3D está definido).

### **Aplicando efeitos de sombra**

O código Python a seguir aplica um efeito de sombra apenas ao texto:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableOuterShadowEffect()
    outer_shadow = portion_format.getEffectFormat().getOuterShadowEffect()
    outer_shadow.getShadowColor().setColor(Color.BLACK)
    outer_shadow.setScaleHorizontal(100)
    outer_shadow.setScaleVertical(65)
    outer_shadow.setBlurRadius(4.73)
    outer_shadow.setDirection(230)
    outer_shadow.setDistance(2)
    outer_shadow.setSkewHorizontal(30)
    outer_shadow.setSkewVertical(0)
    outer_shadow.getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32)
finally:
    presentation.dispose()
```

A API Aspose.Slides oferece três tipos de sombras: [OuterShadow](https://reference.aspose.com/slides/pt/python-java/aspose.slides/outershadow/), [InnerShadow](https://reference.aspose.com/slides/pt/python-java/aspose.slides/innershadow/) e [PresetShadow](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presetshadow/).

Com [PresetShadow](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presetshadow/), você pode aplicar uma sombra ao texto usando valores predefinidos.

**Usando Microsoft PowerPoint**

No PowerPoint, você pode usar um tipo de sombra. Veja um exemplo:

![Configurações de sombra no PowerPoint](image-20200930114225-6.png)

**Usando Aspose.Slides**

Aspose.Slides realmente permite aplicar dois tipos de sombras ao mesmo tempo: [InnerShadow](https://reference.aspose.com/slides/pt/python-java/aspose.slides/innershadow/) e [PresetShadow](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presetshadow/).

**Observações:**

- Quando [OuterShadow](https://reference.aspose.com/slides/pt/python-java/aspose.slides/outershadow/) e [PresetShadow](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presetshadow/) são usados juntos, apenas o efeito [OuterShadow](https://reference.aspose.com/slides/pt/python-java/aspose.slides/outershadow/) é aplicado.
- Se [OuterShadow](https://reference.aspose.com/slides/pt/python-java/aspose.slides/outershadow/) e [InnerShadow](https://reference.aspose.com/slides/pt/python-java/aspose.slides/innershadow/) forem usados simultaneamente, o efeito resultante ou aplicado depende da versão do PowerPoint. Por exemplo, no PowerPoint 2013 o efeito é duplicado. Mas no PowerPoint 2007 o efeito [OuterShadow](https://reference.aspose.com/slides/pt/python-java/aspose.slides/outershadow/) é aplicado.

### **Aplicar reflexão ao texto**

Adicionamos uma reflexão ao texto por meio deste exemplo de código em Python via Java:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableReflectionEffect()
    reflection = portion_format.getEffectFormat().getReflectionEffect()
    reflection.setBlurRadius(0.5)
    reflection.setDistance(4.72)
    reflection.setStartPosAlpha(0)
    reflection.setEndPosAlpha(60)
    reflection.setDirection(90)
    reflection.setScaleHorizontal(100)
    reflection.setScaleVertical(-100)
    reflection.setStartReflectionOpacity(60)
    reflection.setEndReflectionOpacity(0.9)
    reflection.setRectangleAlign(RectangleAlignment.BottomLeft)
finally:
    presentation.dispose()
```

### **Aplicar efeito de brilho ao texto**

Aplicamos o efeito de brilho ao texto para que ele brilhe ou se destaque usando este código:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableGlowEffect()
    glow = portion_format.getEffectFormat().getGlowEffect()
    glow.getColor().setR(jpype.JByte(-1))
    glow.getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54)
    glow.setRadius(7)
finally:
    presentation.dispose()
```

O resultado da operação:

![Texto com efeito de brilho](image-20200930114621-7.png)

{{% alert color="info" title="Observação" %}}
Você pode mudar os parâmetros de sombra, reflexão e brilho. As propriedades dos efeitos são definidas separadamente para cada porção do texto.
{{% /alert %}}

### **Usando transformações no WordArt**

Use [TextFrameFormat.setTransform](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframeformat/#setTransform) para transformar todo o bloco de texto:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, TextShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    text_frame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour)
finally:
    presentation.dispose()
```

O resultado:

![Texto com transformação de arco](image-20200930114712-8.png)

{{% alert color="info" title="Observação" %}}
Tanto o Microsoft PowerPoint quanto o Aspose.Slides for Python via Java oferecem um número de tipos de transformação predefinidos.
{{% /alert %}}

**Usando PowerPoint**

Para acessar os tipos de transformação predefinidos, vá em: **Format** -> **TextEffect** -> **Transform**

**Usando Aspose.Slides**

Para selecionar um tipo de transformação, use a enumeração [TextShapeType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textshapetype/).

### **Aplicar efeitos 3D ao texto e formas**

Aplicamos um efeito 3D a uma forma de texto usando este código de exemplo:

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
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    auto_shape.getTextFrame().setText("Aspose.Slides")

    three_d_format = auto_shape.getThreeDFormat()
    three_d_format.getBevelBottom().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelBottom().setHeight(10.5)
    three_d_format.getBevelBottom().setWidth(10.5)

    three_d_format.getBevelTop().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelTop().setHeight(12.5)
    three_d_format.getBevelTop().setWidth(11)

    three_d_format.getExtrusionColor().setColor(Color.ORANGE)
    three_d_format.setExtrusionHeight(6)

    three_d_format.getContourColor().setColor(Color.RED)
    three_d_format.setContourWidth(1.5)

    three_d_format.setDepth(3)

    three_d_format.setMaterial(MaterialPresetType.Plastic)

    three_d_format.getLightRig().setDirection(LightingDirection.Top)
    three_d_format.getLightRig().setLightType(LightRigPresetType.Balanced)
    three_d_format.getLightRig().setRotation(0, 0, 40)

    three_d_format.getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

O texto resultante e sua forma:

![Forma de texto com efeitos 3D](image-20200930114816-9.png)

Aplicamos um efeito 3D ao texto com este código Python:

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
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    three_d_format = text_frame.getTextFrameFormat().getThreeDFormat()
    three_d_format.getBevelBottom().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelBottom().setHeight(3.5)
    three_d_format.getBevelBottom().setWidth(3.5)

    three_d_format.getBevelTop().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelTop().setHeight(4)
    three_d_format.getBevelTop().setWidth(4)

    three_d_format.getExtrusionColor().setColor(Color.ORANGE)
    three_d_format.setExtrusionHeight(6)

    three_d_format.getContourColor().setColor(Color.RED)
    three_d_format.setContourWidth(1.5)

    three_d_format.setDepth(3)

    three_d_format.setMaterial(MaterialPresetType.Plastic)

    three_d_format.getLightRig().setDirection(LightingDirection.Top)
    three_d_format.getLightRig().setLightType(LightRigPresetType.Balanced)
    three_d_format.getLightRig().setRotation(0, 0, 40)

    three_d_format.getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

O resultado da operação:

![Texto com efeitos 3D](image-20200930114905-10.png)

{{% alert color="info" title="Observação" %}}
A aplicação de efeitos 3D ao texto ou às suas formas e as interações entre os efeitos seguem determinadas regras.

Considere uma cena para o texto e a forma que contém esse texto. O efeito 3D contém uma representação de objeto 3D e a cena na qual o objeto está inserido.

- Quando a cena está definida tanto para a forma quanto para o texto, a cena da forma tem prioridade — a cena do texto é ignorada.
- Quando a forma não possui sua própria cena, mas tem uma representação 3D, a cena do texto é usada.
- Caso contrário — quando a forma originalmente não tem efeito 3D — a forma permanece plana e o efeito 3D é aplicado apenas ao texto.

Essas regras se referem aos métodos [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/pt/python-java/aspose.slides/threedformat/#getLightRig) e [ThreeDFormat.getCamera](https://reference.aspose.com/slides/pt/python-java/aspose.slides/threedformat/#getCamera).
{{% /alert %}}

## **Aplicar efeitos de sombra externa ao texto**

Aspose.Slides for Python via Java fornece as classes [OuterShadow](https://reference.aspose.com/slides/pt/python-java/aspose.slides/outershadow/) e [InnerShadow](https://reference.aspose.com/slides/pt/python-java/aspose.slides/innershadow/) que permitem aplicar efeitos de sombra ao texto em um [TextFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframe/). Siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
2. Obtenha a referência a um slide usando seu índice.
3. Adicione uma forma retangular ao slide.
4. Acesse o quadro de texto associado à forma.
5. Desative o preenchimento da forma.
6. Ative o efeito de sombra externa.
7. Defina o raio de desfoque da sombra.
8. Defina a direção da sombra.
9. Defina a distância da sombra.
10. Alinhe a sombra ao canto superior esquerdo.
11. Defina a cor da sombra como preto.
12. Grave a apresentação como um arquivo [PPTX](https://docs.fileformat.com/presentation/pptx/).

Este código de exemplo em Python via Java — uma implementação das etapas acima — mostra como aplicar o efeito de sombra externa ao texto:

```python
import jpage
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    # Obtenha a referência do slide
    slide = presentation.getSlides().get_Item(0)

    # Adicione um AutoShape do tipo Retângulo
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50)

    # Adicione TextFrame ao Retângulo
    auto_shape.addTextFrame("Aspose TextBox")

    # Desative o preenchimento da forma caso queiramos obter sombra do texto
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # Adicione sombra externa e defina todos os parâmetros necessários
    auto_shape.getEffectFormat().enableOuterShadowEffect()
    shadow = auto_shape.getEffectFormat().getOuterShadowEffect()
    shadow.setBlurRadius(4.0)
    shadow.setDirection(45)
    shadow.setDistance(3)
    shadow.setRectangleAlign(RectangleAlignment.TopLeft)
    shadow.getShadowColor().setPresetColor(PresetColor.Black)

    # Grave a apresentação no disco
    presentation.save("pres_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Aplicar efeito de sombra interna às formas**

Siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
2. Obtenha a referência do slide.
3. Adicione uma forma retangular.
4. Ative o efeito de sombra interna.
5. Defina todos os parâmetros necessários.
6. Defina o tipo de cor da sombra para usar uma cor de tema.
7. Defina a cor do tema.
8. Grave a apresentação como um [PPTX](https://docs.fileformat.com/presentation/pptx/) arquivo.

Este código de exemplo (baseado nas etapas acima) mostra como aplicar o efeito de sombra interna ao texto em uma forma em Python via Java:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorType, FillType, Presentation, SaveFormat, SchemeColor, ShapeType

presentation = Presentation()
try:
    # Obtenha a referência do slide
    slide = presentation.getSlides().get_Item(0)

    # Adicione um AutoShape do tipo Retângulo
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300)
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # Adicione TextFrame ao Retângulo
    auto_shape.addTextFrame("Aspose TextBox")
    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion_format = portion.getPortionFormat()
    portion_format.setFontHeight(50)

    # Habilite InnerShadowEffect
    effect_format = portion_format.getEffectFormat()
    effect_format.enableInnerShadowEffect()

    # Defina todos os parâmetros necessários
    inner_shadow = effect_format.getInnerShadowEffect()
    inner_shadow.setBlurRadius(8.0)
    inner_shadow.setDirection(90.0)
    inner_shadow.setDistance(6.0)
    inner_shadow.getShadowColor().setB(jpype.JByte(-67))

    # Defina ColorType como Scheme
    inner_shadow.getShadowColor().setColorType(ColorType.Scheme)

    # Defina a cor do esquema
    inner_shadow.getShadowColor().setSchemeColor(SchemeColor.Accent1)

    # Salve a apresentação
    presentation.save("WordArt_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Posso usar efeitos WordArt com fontes ou scripts diferentes (por exemplo, árabe, chinês)?**

Sim, Aspose.Slides oferece suporte a Unicode e funciona com todas as principais fontes e scripts. Os efeitos WordArt, como sombra, preenchimento e contorno, podem ser aplicados independentemente do idioma, embora a disponibilidade da fonte e a renderização possam depender das fontes instaladas no sistema.

**Posso aplicar efeitos WordArt a elementos do slide mestre?**

Sim, você pode aplicar efeitos WordArt a formas nos slides mestres, incluindo marcadores de título, rodapés ou texto de fundo. As alterações feitas no layout mestre serão refletidas em todos os slides associados.

**Os efeitos WordArt afetam o tamanho do arquivo da apresentação?**

Um pouco. Efeitos como sombras, brilhos e preenchimentos em degradê podem aumentar ligeiramente o tamanho do arquivo devido ao acréscimo de metadados de formatação, mas a diferença costuma ser insignificante.

**Posso pré‑visualizar o resultado dos efeitos WordArt sem salvar a apresentação?**

Sim, você pode renderizar os slides que contêm WordArt para imagens (por exemplo, PNG, JPEG) usando [Shape.getImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getImage) ou [Slide.getImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slide/#getImage). Isso permite visualizar o resultado na memória ou na tela antes de salvar ou exportar a apresentação completa.