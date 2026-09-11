---
title: Formatar Formas do PowerPoint em Python via Java
linktitle: Formatação de Forma
type: docs
weight: 20
url: /pt/python-java/shape-formatting/
keywords:
- formatar forma
- formatar linha
- efeito de esboço
- linha de forma esboçada
- formatar estilo de junção
- preenchimento em gradiente
- preenchimento de padrão
- preenchimento com imagem
- preenchimento de textura
- preenchimento de cor sólida
- transparência da forma
- renderização de forma em preto e branco
- renderização de forma em tons de cinza
- rotacionar forma
- efeito de bisel 3D
- efeito de rotação 3D
- redefinir formatação
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Aprenda a formatar formas do PowerPoint em Python via Java usando Aspose.Slides — defina estilos de preenchimento, linha e efeito para arquivos PPT, PPTX e ODP com precisão e controle total."
---
## **Introdução**

No PowerPoint, você pode adicionar formas aos slides. Como as formas são compostas por linhas, você pode formatá‑las modificando ou aplicando efeitos aos seus contornos. Além disso, você pode formatar as formas especificando configurações que controlam como seus interiores são preenchidos.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python via Java fornece classes e métodos que permitem formatar formas usando as mesmas opções disponíveis no PowerPoint.

## **Formatar Linhas**

Usando Aspose.Slides, você pode especificar um estilo de linha personalizado para uma forma. Os passos a seguir descrevem o procedimento:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/) ao slide.
1. Defina o [line style](https://reference.aspose.com/slides/pt/python-java/aspose.slides/linestyle/) da forma.
1. Defina a espessura da linha.
1. Defina o [dash style](https://reference.aspose.com/slides/pt/python-java/aspose.slides/linedashstyle/) da linha.
1. Defina a cor da linha para a forma.
1. Salve a apresentação modificada como um arquivo PPTX.

O código a seguir demonstra como formatar um retângulo [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Instanciar a classe Presentation que representa um arquivo de apresentação.
presentation = Presentation()
try:
    # Obter o primeiro slide.
    slide = presentation.getSlides().get_Item(0)

    # Adicionar uma forma automática do tipo Retângulo.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75)

    # Definir a cor de preenchimento para a forma retângulo.
    shape.getFillFormat().setFillType(FillType.NoFill)

    # Aplicar formatação às linhas do retângulo.
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)

    # Definir a cor da linha do retângulo.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Salvar o arquivo PPTX no disco.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![As linhas formatadas na apresentação](formatted-lines.png)

## **Aplicar Efeitos de Esboço às Linhas da Forma**

Um efeito de esboço faz com que a linha de uma forma pareça desenhada à mão. Use [Shape.getLineFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getLineFormat) para acessar as configurações da linha, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/lineformat/#getSketchFormat) para acessar as configurações de esboço e [SketchFormat.setSketchType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sketchformat/#setSketchType) para selecionar um valor da enumeração [LineSketchType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/linesketchtype/).

O código Python a seguir mostra como aplicar um efeito [LineSketchType.Curved](https://reference.aspose.com/slides/pt/python-java/aspose.slides/linesketchtype/#Curved), ler o valor atribuído explicitamente e remover o efeito com [LineSketchType.None_](https://reference.aspose.com/slides/pt/python-java/aspose.slides/linesketchtype/#None):

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

    # Acessar o formato de linha da forma e seu formato de esboço.
    sketch_format = shape.getLineFormat().getSketchFormat()

    # Aplicar um efeito de esboço.
    sketch_format.setSketchType(LineSketchType.Curved)

    # Ler o efeito de esboço atribuído diretamente à forma.
    explicit_sketch_type = sketch_format.getSketchType()
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Remover o efeito de esboço.
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

O valor retornado por [SketchFormat.getSketchType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sketchformat/#getSketchType) representa a configuração atribuída diretamente à forma. Se a formatação da linha puder ser herdada de um tema, slide mestre ou slide de layout, use [LineFormat.getEffective](https://reference.aspose.com/slides/pt/python-java/aspose.slides/lineformat/#getEffective), acesse `LineFormatEffectiveData.getSketchFormat` e leia `SketchFormatEffectiveData.getSketchType`. O valor efetivo reflete a formatação que é realmente aplicada após a herança ser resolvida:

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

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
finally:
    presentation.dispose()
```

## **Formatar Estilos de Junção**

Aqui estão as três opções de tipo de junção:

* Arredondado
* Meia‑esquadria
* Bisel

Por padrão, quando o PowerPoint une duas linhas em um ângulo (como no canto de uma forma), ele usa a configuração **Arredondado**. No entanto, se você estiver desenhando uma forma com ângulos agudos, pode preferir a opção **Meia‑esquadria**.

![Estilo de junção na apresentação](join-style-powerpoint.png)

O código Python a seguir demonstra como três retângulos (conforme mostrados na imagem acima) foram criados usando as configurações de tipo de junção Meia‑esquadria, Bisel e Arredondado:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Instanciar a classe Presentation que representa um arquivo de apresentação.
presentation = Presentation()
try:
    # Obter o primeiro slide.
    slide = presentation.getSlides().get_Item(0)

    # Adicionar três formas automáticas do tipo Retângulo.
    miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
    bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
    round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

    # Definir a cor de preenchimento para cada forma retângulo.
    miter_shape.getFillFormat().setFillType(FillType.Solid)
    miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    bevel_shape.getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    round_shape.getFillFormat().setFillType(FillType.Solid)
    round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # Definir a espessura da linha.
    miter_shape.getLineFormat().setWidth(15)
    bevel_shape.getLineFormat().setWidth(15)
    round_shape.getLineFormat().setWidth(15)

    # Definir a cor da linha de cada retângulo.
    miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Definir o estilo de junção.
    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    # Adicionar texto a cada retângulo.
    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    # Salvar o arquivo PPTX no disco.
    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Preenchimento em Gradiente**

No PowerPoint, Preenchimento em Gradiente é uma opção de formatação que permite aplicar uma mescla contínua de cores a uma forma. Por exemplo, você pode aplicar duas ou mais cores de modo que uma gradualmente se desfaça na outra.

Veja como aplicar um preenchimento em gradiente a uma forma usando Aspose.Slides:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/filltype/) da forma como `Gradient`.
1. Adicione suas duas cores preferidas com posições definidas usando o método [addPresetColor](https://reference.aspose.com/slides/pt/python-java/aspose.slides/gradientstopcollection/#addPresetColor) da coleção de paradas de gradiente exposta pela classe [GradientFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/gradientformat/).
1. Salve a apresentação modificada como um arquivo PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# Instanciar a classe Presentation que representa um arquivo de apresentação.
presentation = Presentation()
try:
    # Obter o primeiro slide.
    slide = presentation.getSlides().get_Item(0)

    # Adicionar uma forma automática do tipo Elipse.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)

    # Aplicar formatação de gradiente à elipse.
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)

    # Definir a direção do gradiente.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2)

    # Adicionar duas paradas de gradiente.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    # Salvar o arquivo PPTX no disco.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![A elipse com preenchimento em gradiente](gradient-fill.png)

## **Preenchimento de Padrão**

No PowerPoint, Preenchimento de Padrão é uma opção de formatação que permite aplicar um design de duas cores — como pontos, listras, cruzamentos ou quadriculados — a uma forma. Você pode escolher cores personalizadas para o primeiro plano e o plano de fundo do padrão.

Aspose.Slides fornece mais de 45 estilos de padrão pré‑definidos que você pode aplicar a formas para melhorar o apelo visual de suas apresentações. Mesmo após selecionar um padrão pré‑definido, você ainda pode especificar as cores exatas que ele deve usar.

Veja como aplicar um preenchimento de padrão a uma forma usando Aspose.Slides:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
2. Obtenha uma referência a um slide pelo seu índice.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/) ao slide.
4. Defina o [FillType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/filltype/) da forma como `Pattern`.
5. Escolha um estilo de padrão entre as opções pré‑definidas.
6. Defina a [Background Color](https://reference.aspose.com/slides/pt/python-java/aspose.slides/patternformat/#getBackColor) do padrão.
7. Defina a [Foreground Color](https://reference.aspose.com/slides/pt/python-java/aspose.slides/patternformat/#getForeColor) do padrão.
8. Salve a apresentação modificada como um arquivo PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Instanciar a classe Presentation que representa um arquivo de apresentação.
presentation = Presentation()
try:
    # Obter o primeiro slide.
    slide = presentation.getSlides().get_Item(0)

    # Adicionar uma forma automática do tipo Retângulo.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Definir o tipo de preenchimento como Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern)

    # Definir o estilo de padrão.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)

    # Definir as cores de fundo e de primeiro plano do padrão.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    # Salvar o arquivo PPTX no disco.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![O retângulo com preenchimento de padrão](pattern-fill.png)

## **Preenchimento com Imagem**

No PowerPoint, Preenchimento com Imagem é uma opção de formatação que permite inserir uma imagem dentro de uma forma — efetivamente usando a imagem como plano de fundo da forma.

Veja como usar Aspose.Slides para aplicar um preenchimento com imagem a uma forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
2. Obtenha uma referência a um slide pelo seu índice.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/) ao slide.
4. Defina o [FillType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/filltype/) da forma como `Picture`.
5. Defina o modo de preenchimento da imagem como `Tile` (ou outro modo preferido).
6. Crie um objeto [PPImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/ppimage/) a partir da imagem que você deseja usar.
7. Passe a imagem para o método `SlidesPicture.setImage`.
8. Salve a apresentação modificada como um arquivo PPTX.

Suponha que tenhamos um arquivo "lotus.png" com a seguinte imagem:

![A imagem lotus](lotus.png)

```python
import jpype
import asposeslides

if not jpway.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

# Instanciar a classe Presentation que representa um arquivo de apresentação.
presentation = Presentation()
try:
    # Obter o primeiro slide.
    slide = presentation.getSlides().get_Item(0)

    # Adicionar uma forma automática do tipo Retângulo.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    
    # Definir o tipo de preenchimento como Picture.
    shape.getFillFormat().setFillType(FillType.Picture)

    # Definir o modo de preenchimento da imagem.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    # Carregar uma imagem e adicioná‑la aos recursos da apresentação.
    image = Images.fromFile("lotus.png")
    picture = presentation.getImages().addImage(image)
    image.dispose()

    # Definir a imagem.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # Salvar o arquivo PPTX no disco.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![A forma com preenchimento de imagem](picture-fill.png)

### **Imagem em Mosaico como Textura**

Se você quiser definir uma imagem em mosaico como textura e personalizar o comportamento do mosaico, pode usar os seguintes métodos da classe [PictureFillFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/pt/python-java/aspose.slides/picturefillformat/#setPictureFillMode): Define o modo de preenchimento da imagem — `Tile` ou `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/pt/python-java/aspose.slides/picturefillformat/#setTileAlignment): Especifica o alinhamento das telhas dentro da forma.
- [setTileFlip](https://reference.aspose.com/slides/pt/python-java/aspose.slides/picturefillformat/#setTileFlip): Controla se a telha é virada horizontalmente, verticalmente ou ambos.
- [setTileOffsetX](https://reference.aspose.com/slides/pt/python-java/aspose.slides/picturefillformat/#setTileOffsetX): Define o deslocamento horizontal da telha (em pontos) a partir da origem da forma.
- [setTileOffsetY](https://reference.aspose.com/slides/pt/python-java/aspose.slides/picturefillformat/#setTileOffsetY): Define o deslocamento vertical da telha (em pontos) a partir da origem da forma.
- [setTileScaleX](https://reference.aspose.com/slides/pt/python-java/aspose.slides/picturefillformat/#setTileScaleX): Define a escala horizontal da telha como porcentagem.
- [setTileScaleY](https://reference.aspose.com/slides/pt/python-java/aspose.slides/picturefillformat/#setTileScaleY): Define a escala vertical da telha como porcentagem.

O código a seguir mostra como adicionar uma forma retângulo com preenchimento de imagem em mosaico e configurar as opções de telha:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

# Instanciar a classe Presentation que representa um arquivo de apresentação.
presentation = Presentation()
try:
    # Obter o primeiro slide.
    first_slide = presentation.getSlides().get_Item(0)

    # Adicionar uma forma automática retangular.
    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)

    # Definir o tipo de preenchimento da forma como Picture.
    shape.getFillFormat().setFillType(FillType.Picture)

    # Carregar a imagem e adicioná-la aos recursos da apresentação.
    source_image = Images.fromFile("lotus.png")
    presentation_image = presentation.getImages().addImage(source_image)
    source_image.dispose()

    # Atribuir a imagem à forma.
    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)

    # Configurar o modo de preenchimento da imagem e as propriedades de mosaico.
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    # Salvar o arquivo PPTX no disco.
    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![As opções de telha](tile-options.png)

## **Preenchimento Sólido**

No PowerPoint, Preenchimento de Cor Sólida é uma opção de formatação que preenche uma forma com uma única cor uniforme. Essa cor de fundo simples é aplicada sem gradientes, texturas ou padrões.

Para aplicar um preenchimento de cor sólida a uma forma usando Aspose.Slides, siga estes passos:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
2. Obtenha uma referência a um slide pelo seu índice.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/) ao slide.
4. Defina o [FillType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/filltype/) da forma como `Solid`.
5. Atribua a cor de preenchimento desejada à forma.
6. Salve a apresentação modificada como um arquivo PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Instanciar a classe Presentation que representa um arquivo de apresentação.
presentation = Presentation()
try:
    # Obter o primeiro slide.
    slide = presentation.getSlides().get_Item(0)

    # Adicionar uma forma automática do tipo Retângulo.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Definir o tipo de preenchimento como Solid.
    shape.getFillFormat().setFillType(FillType.Solid)

    # Definir a cor de preenchimento.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    # Salvar o arquivo PPTX no disco.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![A forma com preenchimento de cor sólida](solid-color-fill.png)

## **Definir Transparência**

No PowerPoint, ao aplicar um preenchimento sólido, em gradiente, com imagem ou textura a formas, você também pode definir um nível de transparência para controlar a opacidade do preenchimento. Um valor de transparência mais alto deixa a forma mais translúcida, permitindo que o plano de fundo ou objetos subjacentes fiquem parcialmente visíveis.

Aspose.Slides permite definir o nível de transparência ajustando o valor alfa na cor usada para o preenchimento. Veja como fazer isso:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
2. Obtenha uma referência a um slide pelo seu índice.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/) ao slide.
4. Defina o [FillType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/filltype/) como `Solid`.
5. Use [Color](https://docs.oracle.com/en/java/javase/17/docs/api/java.desktop/java/awt/Color.html) para definir uma cor com transparência (o componente `alpha` controla a transparência).
6. Salve a apresentação.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Instanciar a classe Presentation que representa um arquivo de apresentação.
presentation = Presentation()
try:
    # Obter o primeiro slide.
    slide = presentation.getSlides().get_Item(0)

    # Adicionar uma forma automática retangular sólida.
    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Adicionar uma forma automática retangular transparente sobre a forma sólida.
    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    transparent_color = Color(255, 255, 0, 204)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(transparent_color)

    # Salvar o arquivo PPTX no disco.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![A forma transparente](shape-transparency.png)

## **Rotacionar Formas**

Aspose.Slides permite rotacionar formas em apresentações PowerPoint. Isso pode ser útil ao posicionar elementos visuais com necessidades específicas de alinhamento ou design.

Para rotacionar uma forma em um slide, siga estes passos:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
2. Obtenha uma referência a um slide pelo seu índice.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/) ao slide.
4. Defina a propriedade de rotação da forma para o ângulo desejado.
5. Salve a apresentação.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Instanciar a classe Presentation que representa um arquivo de apresentação.
presentation = Presentation()
try:
    # Obter o primeiro slide.
    slide = presentation.getSlides().get_Item(0)

    # Adicionar uma forma automática do tipo Retângulo.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Rotacionar a forma em 5 graus.
    shape.setRotation(5)

    # Salvar o arquivo PPTX no disco.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![A rotação da forma](shape-rotation.png)

## **Adicionar Efeitos de Bisel 3D**

Aspose.Slides permite aplicar efeitos de bisel 3D a formas configurando suas propriedades [ThreeDFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/threedformat/).

Para adicionar efeitos de bisel 3D a uma forma, siga estes passos:

1. Instancie a classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
2. Obtenha uma referência a um slide pelo seu índice.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/) ao slide.
4. Configure o [ThreeDFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/threedformat/) da forma para definir as configurações de bisel.
5. Salve a apresentação.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, FillType, LightRigPresetType, LightingDirection, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Criar uma instância da classe Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Adicionar uma forma ao slide.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE)
    shape.getLineFormat().setWidth(2.0)

    # Definir as propriedades ThreeDFormat da forma.
    shape.getThreeDFormat().setDepth(4)
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    shape.getThreeDFormat().getBevelTop().setHeight(6)
    shape.getThreeDFormat().getBevelTop().setWidth(6)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)

    # Salvar a apresentação como um arquivo PPTX.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![O efeito de bisel 3D](3D-bevel-effect.png)

## **Adicionar Efeitos de Rotação 3D**

Aspose.Slides permite aplicar efeitos de rotação 3D a formas configurando suas propriedades [ThreeDFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/threedformat/).

Para aplicar rotação 3D a uma forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
2. Obtenha uma referência a um slide pelo seu índice.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/) ao slide.
4. Use os métodos [setCameraType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/camera/#setCameraType) e [setLightType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/lightrig/#setLightType) para definir a rotação 3D.
5. Salve a apresentação.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, Presentation, SaveFormat, ShapeType

# Criar uma instância da classe Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    auto_shape.getThreeDFormat().setDepth(6)
    auto_shape.getThreeDFormat().getCamera().setRotation(40, 35, 20)
    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)

    # Salvar a apresentação como um arquivo PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![O efeito de rotação 3D](3D-rotation-effect.png)

## **Controlar Renderização em Preto‑e‑Branco para Formas**

O método [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#setBlackWhiteMode) especifica como uma forma individual é renderizada quando uma apresentação é visualizada ou processada em modo preto‑e‑branco. Ele não habilita a exibição em preto‑e‑branco por si só e não altera o preenchimento, linha ou outra formatação da forma no modo de cores normais.

Use um valor da classe [BlackWhiteMode](https://reference.aspose.com/slides/pt/python-java/aspose.slides/blackwhitemode/) para selecionar o comportamento desejado. Por exemplo, `Automatic` permite que o aplicativo de renderização escolha a conversão, `Gray` e `LightGray` utilizam coloração em tons de cinza, `BlackWhite` usa apenas preto e branco, `Black` e `White` forçam uma única cor, `Color` preserva a coloração normal e `Hidden` omite a forma no modo preto‑e‑branco. `NotDefined` indica que nenhum modo de nível de forma foi atribuído.

O código Python a seguir cria uma forma colorida e faz com que ela apareça cinza no modo de exibição preto‑e‑branco:

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
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    # Mantenha o preenchimento laranja no modo colorido, mas renderize a forma com coloração cinza no modo preto e branco.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

No modo de cor normal, o retângulo mantém seu preenchimento laranja. Em um fluxo de trabalho de exibição preto‑e‑branco, ele usa coloração cinza porque seu modo está definido como `Gray`. Isso permite preservar um slide em cores completas enquanto define uma aparência distinta para impressão, visualização ou outros processos que respeitam as configurações de exibição preto‑e‑branco da apresentação.

## **Redefinir Formatação**

O código Python a seguir mostra como redefinir a formatação de um slide e reverter a posição, tamanho e formatação de todas as formas com marcadores de posição no [LayoutSlide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/layoutslide/) para suas configurações padrão:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        # Redefinir cada forma no slide que tem um placeholder no layout.
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**A formatação de formas afeta o tamanho final do arquivo da apresentação?**

Apenas minimamente. Imagens e mídia incorporadas ocupam a maior parte do espaço do arquivo, enquanto parâmetros de forma como cores, efeitos e gradientes são armazenados como metadados e praticamente não adicionam tamanho extra.

**Como posso detectar formas em um slide que compartilham formatação idêntica para que eu possa agrupá‑las?**

Compare as principais propriedades de formatação de cada forma — preenchimento, linha e configurações de efeito. Se todos os valores correspondentes coincidirem, trate seus estilos como idênticos e agrupe logicamente essas formas, o que simplifica o gerenciamento de estilo posterior.

**Posso salvar um conjunto de estilos de forma personalizados em um arquivo separado para reutilizar em outras apresentações?**

Sim. Armazene formas de exemplo com os estilos desejados em um slide‑modelo ou em um arquivo de modelo .POTX. Ao criar uma nova apresentação, abra o modelo, clone as formas estilizadas que precisar e reaplique sua formatação onde for necessário.