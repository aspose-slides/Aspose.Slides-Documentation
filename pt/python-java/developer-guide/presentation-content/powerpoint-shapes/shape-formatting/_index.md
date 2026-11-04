---
title: Formatar formas do PowerPoint em Python via Java
linktitle: Formatação de Formas
type: docs
weight: 20
url: /pt/python-java/shape-formatting/
keywords:
- formatar forma
- formatar linha
- efeito de esboço
- linha de forma esboçada
- formatar estilo de junção
- preenchimento gradiente
- preenchimento de padrão
- preenchimento de imagem
- preenchimento de textura
- preenchimento de cor sólida
- transparência da forma
- renderização de forma em preto e branco
- renderização de forma em escala de cinza
- rotacionar forma
- efeito de chanfrado 3D
- efeito de rotação 3D
- redefinir formatação
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Aprenda a formatar formas do PowerPoint em Python via Java usando Aspose.Slides — defina estilos de preenchimento, linha e efeito para arquivos PPT e PPTX com precisão e total controle."
---
## **Introdução**

Formate formas no PowerPoint ajustando seus contornos, preenchimentos e efeitos. Aspose.Slides for Python via Java permite controlar essas configurações programaticamente, incluindo transparência, rotação e formatação 3D.

![Opções de formatação de forma no PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Python via Java fornece classes e métodos que permitem formatar formas usando as mesmas opções disponíveis no PowerPoint.

## **Formatar linhas**

Use [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) para controlar o contorno de uma forma. Este exemplo cria um retângulo sem preenchimento com um contorno azul pontilhado. [LineFormat.setStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setStyle) seleciona uma linha composta grossa‑fina, enquanto [LineFormat.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) define sua largura para 7 pontos e [LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) seleciona o padrão de tracejado.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado:

![As linhas formatadas na apresentação](formatted-lines.png)

### **Definir padrões de traço de linha personalizados**

Use [LineFormat.setCustomDashPattern](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCustomDashPattern) quando os estilos de linha predefinidos não fornecem os comprimentos de traço e lacunas que você precisa, por exemplo para contornos de marca ou diagramas técnicos. Atribuir um padrão altera automaticamente o estilo de traço da linha para [LineDashStyle.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/).

As entradas do array alternam entre comprimentos de traço e lacuna, começando com um traço. Cada valor é um múltiplo da largura da linha: `[4, 2]` com largura de 3 pontos produz um traço de 12 pontos seguido de uma lacuna de 6 pontos. Use pares de valores finitos e não negativos para definir segmentos completos de traço e lacuna. O exemplo usa valores positivos para manter cada traço e lacuna visíveis.

Este exemplo cria cinco linhas azuis com o mesmo comprimento e extremidades planas. As três primeiras comparam padrões com largura de 3 pontos. A quarta repete o primeiro padrão com o dobro da largura, dobrando os comprimentos do traço e da lacuna. A quinta troca de um padrão personalizado para uma linha sólida.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, LineCapStyle, LineDashStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(600, 300, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ]

    for i, pattern in enumerate(patterns):
        line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0)
        line.getLineFormat().setWidth(6 if i == 3 else 3)
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        line.getLineFormat().setCapStyle(LineCapStyle.Flat)
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setCustomDashPattern(jpype.JArray(jpype.JFloat)(pattern))

    # Retornar a última linha para um estilo sólido.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid)

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Para voltar a um estilo tracejado predefinido, passe [LineDashStyle.Dash](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) para [LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle). O estilo selecionado controla a aparência da linha.

O resultado no PowerPoint, de cima para baixo: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; e **Solid, 3 pt**.

![Três padrões de traço personalizados, uma linha mais larga usando o primeiro padrão, e uma linha sólida no PowerPoint](custom-dash-patterns.png)

### **Definir extremidades de linha**

Use [LineFormat.setCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCapStyle) para definir as extremidades de uma linha aberta. A classe [LineCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linecapstyle/) fornece três estilos de extremidade explícitos:

- `Flat`: O traço termina no ponto final.
- `Round`: Uma extremidade semicircular estende‑se além do ponto final em metade da largura da linha.
- `Square`: Uma extremidade quadrada estende‑se além do ponto final em metade da largura da linha.

A classe também inclui `NotDefined`, que significa que nenhum estilo de extremidade foi explicitamente atribuído.

Extremidades são diferentes de pontas de seta, que adicionam símbolos às extremidades da linha, e de junções, que controlam cantos entre segmentos de linha. Este exemplo desativa pontas de seta através de [LineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setBeginArrowheadStyle) e [LineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setEndArrowheadStyle) para que apenas as formas de extremidade sejam comparadas.

O exemplo a seguir cria três linhas horizontais, de outra forma idênticas, com 20 pontos de largura. De cima para baixo, elas usam extremidades flat, round e square. Seus pontos finais têm as mesmas coordenadas horizontais; as extremidades round e square estendem‑se 10 pontos além de cada ponto final.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, LineCapStyle, LineDashStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    cap_styles = [LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square]

    for i, cap_style in enumerate(cap_styles):
        line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0)
        line.getLineFormat().setWidth(20)
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        line.getLineFormat().setDashStyle(LineDashStyle.Solid)
        line.getLineFormat().setCapStyle(cap_style)
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None_)

    presentation.save("line_caps.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado no PowerPoint, de cima para baixo: **Flat**, **Round**, e **Square**.

![Extremidades flat, round e square em linhas espessas idênticas no PowerPoint](line-caps.png)

## **Aplicar efeitos de esboço às linhas de forma**

Um efeito de esboço faz a linha de uma forma parecer desenhada à mão. Use [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) para acessar as configurações da linha, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getSketchFormat) para acessar as configurações de esboço, e [SketchFormat.setSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#setSketchType) para selecionar um valor da classe [LineSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/).

O código Python a seguir mostra como aplicar um efeito [LineSketchType.Curved](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/) , ler o valor atribuído explicitamente e remover o efeito com [LineSketchType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LineSketchType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)

    sketch_format = shape.getLineFormat().getSketchFormat()
    sketch_format.setSketchType(LineSketchType.Curved)
    explicit_sketch_type = sketch_format.getSketchType()
    print("Explicit sketch type:", explicit_sketch_type)
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

O valor retornado por [SketchFormat.getSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#getSketchType) representa a configuração atribuída diretamente à forma. Se a formatação da linha puder ser herdada de um tema, slide mestre ou slide de layout, use [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective) e leia o tipo de esboço da formatação de linha efetiva retornada, como mostrado abaixo. O valor efetivo reflete a formatação que realmente é aplicada após a herança ser resolvida. Este exemplo requer uma apresentação existente com ao menos uma forma no primeiro slide e imprime ambos os valores:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    line_format = shape.getLineFormat()
    explicit_sketch_type = line_format.getSketchFormat().getSketchType()
    effective_line_format = line_format.getEffective()
    effective_sketch_type = effective_line_format.getSketchFormat().getSketchType()

    print("Explicit sketch type:", explicit_sketch_type)
    print("Effective sketch type:", effective_sketch_type)
finally:
    presentation.dispose()
```

## **Formatar estilos de junção**

Aqui estão as três opções de tipo de junção:

* Round
* Miter
* Bevel

O estilo de junção controla como dois segmentos de contorno se encontram em um canto. Use **Round** para cantos arredondados, **Miter** para cantos pontiagudos, ou **Bevel** para cantos achatados.

![O estilo de junção na apresentação](join-style-powerpoint.png)

Este exemplo cria três retângulos pretos com contornos azuis de 15 pontos de largura. Ele usa [LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle) para definir os valores miter, bevel e round de [LineJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/), respectivamente, para comparar como os cantos são desenhados.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
    bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
    round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

    miter_shape.getFillFormat().setFillType(FillType.Solid)
    miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    bevel_shape.getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    round_shape.getFillFormat().setFillType(FillType.Solid)
    round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    miter_shape.getLineFormat().setWidth(15)
    bevel_shape.getLineFormat().setWidth(15)
    round_shape.getLineFormat().setWidth(15)

    miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Limitar junções Miter em cantos agudos**

Use [LineFormat.setMiterLimit](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setMiterLimit) com [LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle) definido como [LineJoinStyle.Miter](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/) para limitar o quanto um canto agudo pode se estender.

O limite é uma proporção da distância entre os cantos interno e externo da junção em relação à largura da linha. Por exemplo, um valor `8` permite um comprimento de miter de até oito vezes a largura da linha; não é uma medida em pontos. Se o canto ultrapassar o limite, o PowerPoint usa uma junção chanfrada naquele canto. Um limite maior permite pontas mais agudas. A configuração afeta somente junções miter, e alterá‑la não tem efeito visível quando o canto permanece dentro dos limites.

Este exemplo cria duas triângulos idênticos, sem preenchimento, com contornos de 20 pontos de largura. O triângulo esquerdo usa um limite de `2`, e o direito usa `8`. Cada triângulo tem 80 pontos de largura e 160 pontos de altura, dando ao seu canto superior uma proporção de comprimento de miter para largura de linha de aproximadamente `4.12`. Consequentemente, o PowerPoint chanfrar o ápice esquerdo e preservar o ápice direito.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(500, 320, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    miter_limits = [2.0, 8.0]

    for i, miter_limit in enumerate(miter_limits):
        triangle = slide.getShapes().addAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160)
        triangle.getFillFormat().setFillType(FillType.NoFill)
        triangle.getLineFormat().setWidth(20)
        triangle.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
        triangle.getLineFormat().setMiterLimit(miter_limit)

    presentation.save("miter_limits.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado no PowerPoint: **Miter limit 2** à esquerda e **miter limit 8** à direita.

![Um ápice chanfrado com limite miter 2 e um ápice pontiagudo com limite miter 8 no PowerPoint](miter-limits.png)

## **Preenchimento gradiente**

Um preenchimento gradiente mistura cores ao longo de uma forma. Este exemplo preenche uma elipse com um gradiente linear em um ângulo de 45 graus de vermelho a roxo usando [FillFormat.getGradientFormat](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getGradientFormat). O método [GradientStopCollection.addPresetColor](https://reference.aspose.com/slides/python-java/aspose.slides/gradientstopcollection/#addPresetColor) posiciona as paradas de cor em 0 e 1, o início e o fim do gradiente. Limpar as paradas existentes garante que apenas essas duas cores sejam usadas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45)
    shape.getFillFormat().getGradientFormat().getGradientStops().clear()
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado:

![A elipse com preenchimento gradiente](gradient-fill.png)

Se um gradiente parecer diferente em uma imagem exportada do que no PowerPoint, veja [Escolher um estilo de renderização de gradiente](/slides/pt/python-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Você pode selecionar um estilo de renderização sem alterar o preenchimento gradiente armazenado na apresentação.

### **Definir o ângulo do gradiente linear**

Use [GradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle) para controlar a orientação de um preenchimento [GradientShape.Linear](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/). O ângulo é medido em graus e aumenta no sentido horário: `0` vai da esquerda para a direita, `90` de cima para baixo, `180` da direita para a esquerda, e `270` de baixo para cima. Ângulos fracionários são suportados. Ângulos finitos fora de `[0, 360)` são normalizados para uma revolução; por exemplo, `-45` torna‑se `315` e `360` torna‑se `0`.

Este exemplo cria seis retângulos com paradas de vermelho, verde e azul idênticas nas posições `0`, `0.5` e `1`. O dimensionamento está desativado para que o ângulo possa ser comparado independentemente das proporções dos retângulos. Os ângulos, da esquerda para a direita, são `0`, `45` e `90` na primeira linha, e `135`, `180` e `270` na segunda linha.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    angles = [0, 45, 90, 135, 180, 270]

    for i, angle in enumerate(angles):
        x = 30 + (i % 3) * 230
        y = 30 + (i // 3) * 190

        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 200, 150)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        shape.getFillFormat().setFillType(FillType.Gradient)

        gradient = shape.getFillFormat().getGradientFormat()
        gradient.setGradientShape(GradientShape.Linear)
        gradient.getGradientStops().clear()
        gradient.getGradientStops().add(0, Color.RED)
        gradient.getGradientStops().add(0.5, Color.GREEN)
        gradient.getGradientStops().add(1, Color.BLUE)
        gradient.setLinearGradientScaled(NullableBool.False_)
        gradient.setLinearGradientAngle(angle)

    presentation.save("linear_gradient_angles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado no PowerPoint:

![Gradientes lineares em 0, 45 e 90 graus na linha superior, e 135, 180 e 270 graus na linha inferior](linear-gradient-angles.png)

### **Dimensionar um gradiente linear com a forma**

[GradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientScaled) aceita um valor [NullableBool](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/). Defina‑o explicitamente como `False_` para manter o ângulo geométrico do gradiente enquanto as proporções da forma mudam, ou como `True_` para dimensionar o gradiente com a largura e altura da forma. Com o dimensionamento ativado, o ângulo visível pode diferir do ângulo atribuído em uma forma não quadrada.

O exemplo a seguir usa um ângulo de `45` graus e as mesmas paradas de cor da comparação de ângulos. A coluna esquerda usa `False_`; a coluna direita usa `True_`. Cada coluna contém um retângulo largo acima de um retângulo alto. Ambos começam com as mesmas dimensões largas; mudar a largura e altura do segundo retângulo demonstra como o preenchimento responde ao redimensionamento sem mudar suas configurações de gradiente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 460, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    scaling_options = [NullableBool.False_, NullableBool.True_]

    for column, scaled in enumerate(scaling_options):
        for row in range(2):
            x = 30 + column * 360
            y = 30 if row == 0 else 150

            shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 300, 90)
            shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
            shape.getFillFormat().setFillType(FillType.Gradient)

            gradient = shape.getFillFormat().getGradientFormat()
            gradient.setGradientShape(GradientShape.Linear)
            gradient.getGradientStops().clear()
            gradient.getGradientStops().add(0, Color.RED)
            gradient.getGradientStops().add(0.5, Color.GREEN)
            gradient.getGradientStops().add(1, Color.BLUE)
            gradient.setLinearGradientAngle(45)
            gradient.setLinearGradientScaled(scaled)

            if row == 1:
                shape.setWidth(90)
                shape.setHeight(280)

    presentation.save("linear_gradient_scaling.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado no PowerPoint, com dimensionamento desativado à esquerda e ativado à direita:

![Retângulos largos e altos com gradiente de 45 graus, comparando LinearGradientScaled False à esquerda com True à direita](linear-gradient-scaling.png)

Com o dimensionamento desativado, as faixas de cor diagonais mantêm a mesma orientação em ambos os retângulos. Com o dimensionamento ativado, as faixas se esticam com as proporções da forma. Isso ajuda a reproduzir o gradiente de um modelo ao adaptar uma forma a um tamanho diferente. Em um quadrado, habilitar o dimensionamento não altera a aparência deste gradiente de `45` graus.

Ambas as configurações de ângulo e dimensionamento se aplicam a gradientes lineares. Elas não controlam preenchimentos [GradientShape.Radial or GradientShape.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/).

### **Combinar o ângulo com a direção do gradiente**

[GradientFormat.setGradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setGradientDirection) seleciona um estilo de gradiente da classe [GradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientdirection/). Não substitui um ângulo numérico. Para um gradiente linear, os estilos de canto podem mudar a área onde as cores são distribuídas sem alterar o ângulo atribuído via [setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle). Mantenha a direção inalterada ao comparar ângulos ou dimensionamento.

O exemplo a seguir aplica as mesmas configurações em ordem inversa. Os dois retângulos têm a mesma aparência: atribuir a direção antes ou depois do ângulo não altera o resultado.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    for i in range(2):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        shape.getFillFormat().setFillType(FillType.Gradient)

        gradient = shape.getFillFormat().getGradientFormat()
        gradient.setGradientShape(GradientShape.Linear)
        gradient.getGradientStops().clear()
        gradient.getGradientStops().add(0, Color.RED)
        gradient.getGradientStops().add(0.5, Color.GREEN)
        gradient.getGradientStops().add(1, Color.BLUE)
        gradient.setLinearGradientScaled(NullableBool.True_)

        if i == 0:
            gradient.setGradientDirection(GradientDirection.FromCorner1)
            gradient.setLinearGradientAngle(30)
        else:
            gradient.setLinearGradientAngle(30)
            gradient.setGradientDirection(GradientDirection.FromCorner1)

    presentation.save("linear_gradient_direction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Preenchimento de padrão**

Um preenchimento de padrão aplica um design de duas cores, como pontos, listras ou quadriculados. Este exemplo usa [PatternFormat.setPatternStyle](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#setPatternStyle) para selecionar um padrão de treliça. [PatternFormat.getBackColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getBackColor) fornece o fundo cinza claro, e [PatternFormat.getForeColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getForeColor) fornece a cor amarela do padrão.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Pattern)
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado:

![O retângulo com preenchimento de padrão](pattern-fill.png)

## **Preenchimento de imagem**

Um preenchimento de imagem usa uma imagem dentro de uma forma. Este exemplo requer uma imagem local e usa [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) para carregá‑la na coleção de imagens da apresentação. Definir [PictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode) para o modo em ladrilhos repete a imagem dentro do retângulo. A imagem fonte usada aqui é mostrada abaixo:

![A imagem do lótus](lotus.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    image = Images.fromFile("lotus.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado:

![A forma com preenchimento de imagem](picture-fill.png)

### **Ladrilhar imagem como textura**

Se você quiser definir uma imagem em ladrilhos como textura e personalizar o comportamento de ladrilhamento, pode usar os seguintes métodos da classe [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode): Define o modo de preenchimento de imagem — `Tile` ou `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileAlignment): Especifica o alinhamento dos ladrilhos dentro da forma.
- [setTileFlip](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileFlip): Controla se o ladrilho é invertido horizontalmente, verticalmente ou ambos.
- [setTileOffsetX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetX): Define o deslocamento horizontal do ladrilho (em pontos) a partir da origem da forma.
- [setTileOffsetY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetY): Define o deslocamento vertical do ladrilho (em pontos) a partir da origem da forma.
- [setTileScaleX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleX): Define a escala horizontal do ladrilho como porcentagem.
- [setTileScaleY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleY): Define a escala vertical do ladrilho como porcentagem.

Este exemplo requer uma imagem local e configura [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) para repeti‑la a 50% do seu tamanho original. Deslocamentos de −32 pontos deslocam os ladrilhos horizontal e verticalmente; o alinhamento inferior‑direito e a inversão em ambas as direções determinam como a textura repetida é organizada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)
    shape.getFillFormat().setFillType(FillType.Picture)

    source_image = Images.fromFile("lotus.png")
    try:
        presentation_image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado:

![As opções de ladrilhos](tile-options.png)

## **Preenchimento de cor sólida**

Um preenchimento sólido fornece a uma forma uma cor única e uniforme. Este exemplo usa [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) para definir o modo de preenchimento sólido e atribui amarelo através de [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor), então salva o retângulo em uma apresentação.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado:

![A forma com preenchimento de cor sólida](solid-color-fill.png)

## **Usar o fundo do slide como preenchimento da forma**

Use [AutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#setUseBackgroundFill) quando uma forma deve corresponder ao fundo do slide, por exemplo em um modelo de apresentação. Defina [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) para [FillType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) primeiro para remover qualquer preenchimento explícito. Com essa combinação, a forma usa o fundo do slide em vez do seu preenchimento de estilo. Habilitar a flag sozinha não remove um preenchimento explícito existente.

Isso difere de [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/): o preenchimento de fundo cobre objetos atrás da forma com a área correspondente do fundo do slide, enquanto nenhum preenchimento deixa esses objetos visíveis. Um gradiente permanece alinhado ao slide em vez de reiniciar dentro de cada forma.

O exemplo a seguir cria um fundo mestre herdado pelo slide e coloca uma faixa magenta atrás de três retângulos. O retângulo esquerdo usa o fundo, o retângulo do meio não tem preenchimento, e o retângulo direito troca o preenchimento de fundo por um preenchimento laranja explícito.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, GradientShape, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    # Herdar o gradiente do mestre.
    slide.getBackground().setType(BackgroundType.NotDefined)
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined)
    background = slide.getLayoutSlide().getMasterSlide().getBackground()
    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Gradient)
    gradient = background.getFillFormat().getGradientFormat()
    gradient.setGradientShape(GradientShape.Linear)
    gradient.setLinearGradientAngle(0)
    gradient.getGradientStops().clear()
    color = Color(0, 0, 139)
    gradient.getGradientStops().add(0, color)
    color = Color(135, 206, 250)
    gradient.getGradientStops().add(1, color)

    # Adicionar este objeto primeiro para que apareça atrás dos retângulos.
    band = slide.getShapes().addAutoShape(ShapeType.Rectangle, 25, 150, 670, 100)
    band.getFillFormat().setFillType(FillType.Solid)
    band.getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    background_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 160, 200)
    background_shape.getFillFormat().setFillType(FillType.NotDefined)
    background_shape.setUseBackgroundFill(True)

    no_fill_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 280, 100, 160, 200)
    no_fill_shape.getFillFormat().setFillType(FillType.NoFill)

    explicit_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 510, 100, 160, 200)
    explicit_shape.getFillFormat().setFillType(FillType.NotDefined)
    explicit_shape.setUseBackgroundFill(True)

    # Desativar o preenchimento de fundo antes de aplicar um preenchimento explícito.
    explicit_shape.setUseBackgroundFill(False)
    explicit_shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    explicit_shape.getFillFormat().getSolidFillColor().setColor(color)

    presentation.save("background_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado, da esquerda para a direita: **background fill**, **no fill**, e **explicit fill**. A faixa magenta é ocultada pelos retângulos esquerdo e direito, mas permanece visível através do retângulo do meio.

![Preenchimento de fundo, sem preenchimento e preenchimento laranja explícito sobre uma faixa magenta](background-fill.png)

O mesmo comportamento se aplica a um fundo definido diretamente no slide ou herdado de um layout. A forma usa o fundo resolvido do slide; o exemplo deixa ambos os fundos do slide e do layout indefinidos para que o mestre os forneça.

## **Definir transparência**

Para um preenchimento sólido, o componente alfa da cor controla a opacidade: 0 é totalmente transparente e 255 é totalmente opaco. Este exemplo usa um valor alfa de 128 para um retângulo amarelo, tornando‑o aproximadamente 50% transparente para que o retângulo abaixo permaneça visível. A cor é atribuída através de [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 255, 0, 128)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(color)

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado:

![A forma transparente](shape-transparency.png)

## **Rotacionar formas**

Use [Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) para rotacionar uma forma no plano do slide. O ângulo é medido em graus; este exemplo gira um retângulo 5 graus no sentido horário e salva a apresentação.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.setRotation(5)

    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado:

![A rotação da forma](shape-rotation.png)

## **Adicionar efeitos de chanfrado 3D**

Use [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) para dar a uma forma profundidade e bordas chanfradas. Este exemplo cria uma elipse verde com contorno laranja, usa [ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) para definir a profundidade em 4 pontos, e aplica um chanfrado superior circular com largura e altura de 6 pontos via [ThreeDFormat.getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop). Uma câmera ortográfica de frente e iluminação de três pontos tornam o chanfrado visível.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, FillType, LightRigPresetType, LightingDirection, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(0, 128, 0)
    shape.getFillFormat().getSolidFillColor().setColor(color)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
    shape.getLineFormat().setWidth(2.0)
    shape.getThreeDFormat().setDepth(4)
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    shape.getThreeDFormat().getBevelTop().setHeight(6)
    shape.getThreeDFormat().getBevelTop().setWidth(6)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)

    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado:

![O efeito de chanfrado 3D](3D-bevel-effect.png)

## **Adicionar efeitos de rotação 3D**

A visualização 3D de uma forma é controlada pelas configurações de sua câmera. Este exemplo usa [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation) com ângulos de latitude, longitude e revolução de 40, 35 e 20 graus, respectivamente. Ele seleciona uma câmera isométrica através de [Camera.setCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setCameraType) e iluminação equilibrada através de [LightRig.setLightType](https://reference.aspose.com/slides/python-java/aspose.slides/lightrig/#setLightType), então salva o retângulo formatado.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    auto_shape.getTextFrame().setText("Hello, Aspose!")
    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp)
    auto_shape.getThreeDFormat().getCamera().setRotation(40, 35, 20)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)

    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado:

![O efeito de rotação 3D](3D-rotation-effect.png)

## **Controlar renderização em preto e branco para formas**

O método [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) especifica como uma forma individual é renderizada quando uma apresentação é visualizada ou processada em modo preto e branco. Ele não habilita a exibição em preto e branco por si só, e não altera o preenchimento, linha ou outra formatação da forma no modo de cor normal.

Use um valor da classe [BlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/blackwhitemode/) para selecionar o comportamento desejado. Por exemplo, `Automatic` permite que o aplicativo de renderização escolha a conversão, `Gray` e `LightGray` utilizam coloração cinza, `BlackWhite` usa apenas preto e branco, `Black` e `White` forçam uma única cor, `Color` preserva a coloração normal, e `Hidden` omite a forma no modo preto e branco. `NotDefined` significa que nenhum modo de forma foi atribuído.

Este exemplo cria um retângulo laranja e usa [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) para definir o modo como cinza. A forma salva mantém seu preenchimento laranja para exibição em cor normal e solicita coloração cinza de aplicativos que respeitam as configurações de exibição em preto e branco:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteMode, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    shape.getFillFormat().getSolidFillColor().setColor(color)
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Em modo de cor normal, o retângulo mantém seu preenchimento laranja. Em um fluxo de trabalho de exibição em preto e branco, ele usa coloração cinza porque seu modo está definido como `Gray`. Isso permite preservar um slide em cores completas enquanto define uma aparência distinta para impressão, visualização ou outros fluxos que respeitam as configurações de exibição em preto e branco da apresentação.

## **Redefinir formatação**

Use [Slide.reset](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#reset) para restaurar a posição, tamanho e formatação de marcadores de posição de slide a partir de seus marcadores de posição correspondentes no layout. Este exemplo requer uma apresentação existente com marcadores de posição vinculados ao layout e redefine cada slide antes de salvar. Formas sem marcadores de posição correspondentes no layout não são redefinidas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**A formatação de formas afeta o tamanho final do arquivo da apresentação?**

Cores, estilos de linha e configurações de efeitos geralmente adicionam poucos dados em comparação com imagens e mídia incorporadas. Preenchimentos de imagem podem aumentar o tamanho do arquivo porque suas imagens são armazenadas na apresentação.

**Como posso detectar formas em um slide que compartilham formatação idêntica para que eu possa agrupá‑las?**

Compare as principais propriedades de formatação de cada forma — preenchimento, linha e configurações de efeito. Se todos os valores correspondentes coincidirem, trate seus estilos como idênticos e agrupe logicamente essas formas, o que simplifica o gerenciamento de estilo posterior.

**Posso salvar um conjunto de estilos de forma personalizados em um arquivo separado para reutilizar em outras apresentações?**

Sim. Armazene formas de exemplo com os estilos desejados em um deck de slides modelo ou em um arquivo de modelo .POTX. Ao criar uma nova apresentação, abra o modelo, clone as formas estilizadas necessárias e reaplique sua formatação onde for preciso.