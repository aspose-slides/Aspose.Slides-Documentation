---
title: Formatar Formas do PowerPoint em Python
linktitle: Formatação de Formas
type: docs
weight: 20
url: /pt/python-net/shape-formatting/
keywords:
- formatar forma
- formatar linha
- efeito de esboço
- linha de forma de esboço
- formatar estilo de junção
- preenchimento gradiente
- preenchimento de padrão
- preenchimento de imagem
- preenchimento de textura
- preenchimento de cor sólida
- transparência da forma
- renderização preto e branco da forma
- renderização em tons de cinza da forma
- rotacionar forma
- efeito de bisel 3d
- efeito de rotação 3d
- redefinir formatação
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Aprenda a formatar formas do PowerPoint em Python usando Aspose.Slides — defina preenchimento, linha e estilos de efeito para arquivos PPT, PPTX e ODP com precisão e controle total."
---
## **Introdução**

No PowerPoint, você pode adicionar formas aos slides. Como as formas são compostas por linhas, você pode formatá‑las modificando ou aplicando efeitos em seus contornos. Além disso, é possível formatar as formas especificando configurações que controlam como seus interiores são preenchidos.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python fornece classes e propriedades que permitem formatar formas usando as mesmas opções disponíveis no PowerPoint.

## **Formatar Linhas**

Usando Aspose.Slides, você pode especificar um estilo de linha personalizado para uma forma. As etapas a seguir descrevem o procedimento:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) ao slide.
1. Defina o [line style](https://reference.aspose.com/slides/pt/python-net/aspose.slides/linestyle/) da forma.
1. Defina a espessura da linha.
1. Defina o [dash style](https://reference.aspose.com/slides/pt/python-net/aspose.slides/linedashstyle/) da forma.
1. Defina a cor da linha da forma.
1. Salve a apresentação modificada como um arquivo PPTX.

O código Python a seguir demonstra como formatar um `AutoShape` retangular:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancie a classe Presentation que representa um arquivo de apresentação.
with slides.Presentation() as presentation:

    # Obtenha o primeiro slide.
    slide = presentation.slides[0]

    # Adicione uma forma automática do tipo Retângulo.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Remova o preenchimento da forma retangular para que apenas suas linhas fiquem visíveis.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # Aplique formatação às linhas do retângulo.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # Defina a cor da linha do retângulo.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Salve o arquivo PPTX no disco.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![As linhas formatadas na apresentação](formatted-lines.png)

## **Aplicar Efeitos de Esboço às Linhas da Forma**

Um efeito de esboço faz com que a linha de uma forma pareça desenhada à mão. Use [Shape.line_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/line_format/) para acessar as configurações de linha, [LineFormat.sketch_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides/lineformat/sketch_format/) para acessar as configurações de esboço e [SketchFormat.sketch_type](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sketchformat/sketch_type/) para selecionar um valor da enumeração [LineSketchType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/linesketchtype/).

O código Python a seguir mostra como aplicar um efeito [LineSketchType.CURVED](https://reference.aspose.com/slides/pt/python-net/aspose.slides/linesketchtype/) , ler o valor atribuído explicitamente e remover o efeito com [LineSketchType.NONE](https://reference.aspose.com/slides/pt/python-net/aspose.slides/linesketchtype/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # Acesse o formato de linha da forma e seu formato de esboço.
    sketch_format = shape.line_format.sketch_format

    # Aplique um efeito de esboço.
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # Leia o efeito de esboço atribuído diretamente à forma.
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Remova o efeito de esboço.
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

O valor retornado por `SketchFormat.sketch_type` representa a configuração atribuída diretamente à forma. Se a formatação da linha puder ser herdada de um tema, slide mestre ou slide de layout, use [LineFormat.get_effective](https://reference.aspose.com/slides/pt/python-net/aspose.slides/lineformat/get_effective/) , acesse a propriedade `sketch_format` do objeto retornado e leia sua propriedade `sketch_type`. O valor efetivo reflete a formatação realmente aplicada após a resolução da herança:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    line_format = shape.line_format

    explicit_sketch_type = line_format.sketch_format.sketch_type
    effective_line_format = line_format.get_effective()
    effective_sketch_type = effective_line_format.sketch_format.sketch_type

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
```

## **Formatar Estilos de Junção**

Aqui estão as três opções de tipo de junção:

* Arredondado
* Ângulo
* Chanfrado

Por padrão, quando o PowerPoint une duas linhas em um ângulo (como no canto de uma forma), ele usa a configuração **Arredondado**. No entanto, se você estiver desenhando uma forma com ângulos agudos, pode preferir a opção **Ângulo**.

![O estilo de junção na apresentação](join-style-powerpoint.png)

O código Python a seguir demonstra como três retângulos (conforme mostrado na imagem acima) foram criados usando as configurações de tipo de junção Miter, Bevel e Round:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancie a classe Presentation que representa um arquivo de apresentação.
with slides.Presentation() as presentation:

	# Obtenha o primeiro slide.
	slide = presentation.slides[0]

	# Adicione três formas automáticas do tipo Retângulo.
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# Defina a cor de preenchimento para cada forma de retângulo.
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# Defina a espessura da linha.
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# Defina a cor da linha de cada retângulo.
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# Defina o estilo de junção.
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# Adicione texto a cada retângulo.
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# Salve o arquivo PPTX no disco.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **Preenchimento Gradiente**

No PowerPoint, Preenchimento Gradiente é uma opção de formatação que permite aplicar uma mistura contínua de cores a uma forma. Por exemplo, você pode aplicar duas ou mais cores de forma que uma gradualmente se mescle à outra.

Veja como aplicar um preenchimento gradiente a uma forma usando Aspose.Slides:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/filltype/) da forma como `GRADIENT`.
1. Adicione suas duas cores preferidas com posições definidas usando os métodos `add` da coleção `gradient_stops` exposta pela classe [GradientFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/gradientformat/).
1. Salve a apresentação modificada como um arquivo PPTX.

```python
import aspose.slides as slides

# Instancie a classe Presentation que representa um arquivo de apresentação.
with slides.Presentation() as presentation:

    # Obtenha o primeiro slide.
    slide = presentation.slides[0]

    # Adicione uma forma automática do tipo Elipse.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Aplique formatação de gradiente à elipse.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Defina a direção do gradiente.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Adicione duas paradas de gradiente.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Salve o arquivo PPTX no disco.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

A elipse com preenchimento gradiente:

![A elipse com preenchimento gradiente](gradient-fill.png)

## **Preenchimento de Padrão**

No PowerPoint, Preenchimento de Padrão é uma opção de formatação que permite aplicar um design de duas cores — como pontos, listras, traços cruzados ou quadriculados — a uma forma. Você pode escolher cores personalizadas para o primeiro plano e o plano de fundo do padrão.

Aspose.Slides fornece mais de 45 estilos de padrão predefinidos que você pode aplicar a formas para melhorar o apelo visual de suas apresentações. Mesmo após selecionar um padrão predefinido, ainda é possível especificar as cores exatas que ele deve usar.

Veja como aplicar um preenchimento de padrão a uma forma usando Aspose.Slides:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/filltype/) da forma como `PATTERN`.
1. Escolha um estilo de padrão entre as opções predefinidas.
1. Defina o [back_color](https://reference.aspose.com/slides/pt/python-net/aspose.slides/patternformat/back_color/) do padrão.
1. Defina o [fore_color](https://reference.aspose.com/slides/pt/python-net/aspose.slides/patternformat/fore_color/) do padrão.
1. Salve a apresentação modificada como um arquivo PPTX.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancie a classe Presentation que representa um arquivo de apresentação.
with slides.Presentation() as presentation:

    # Obtenha o primeiro slide.
    slide = presentation.slides[0]

    # Adicione uma forma automática do tipo Retângulo.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Defina o tipo de preenchimento como Padrão.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # Defina o estilo do padrão.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Defina as cores de fundo e de primeiro plano do padrão.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # Salve o arquivo PPTX no disco.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

O retângulo com preenchimento de padrão:

![O retângulo com preenchimento de padrão](pattern-fill.png)

## **Preenchimento de Imagem**

No PowerPoint, Preenchimento de Imagem é uma opção de formatação que permite inserir uma imagem dentro de uma forma — usando efetivamente a imagem como plano de fundo da forma.

Veja como usar Aspose.Slides para aplicar um preenchimento de imagem a uma forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/filltype/) da forma como `PICTURE`.
1. Defina o modo de preenchimento da imagem como `TILE` (ou outro modo preferido).
1. Crie um objeto [PPImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ppimage/) a partir da imagem que deseja usar.
1. Atribua esta imagem à propriedade `picture.image` do `picture_fill_format` da forma.
1. Salve a apresentação modificada como um arquivo PPTX.

Suponha que temos um arquivo "lotus.png" com a seguinte imagem:

![A imagem lotus](lotus.png)

```python
import aspose.slides as slides

# Instancie a classe Presentation que representa um arquivo de apresentação.
with slides.Presentation() as presentation:

    # Obtenha o primeiro slide.
    slide = presentation.slides[0]

    # Adicione uma forma automática do tipo Retângulo.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # Defina o tipo de preenchimento como Imagem.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Defina o modo de preenchimento da imagem.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Carregue uma imagem e adicione-a aos recursos da apresentação.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # Defina a imagem.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # Salve o arquivo PPTX no disco.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

A forma com preenchimento de imagem:

![A forma com preenchimento de imagem](picture-fill.png)

### **Imagem em Mosaico como Textura**

Se você quiser definir uma imagem em mosaico como textura e personalizar o comportamento do mosaico, pode usar as seguintes propriedades da classe [PictureFillFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/picturefillformat/):

- [picture_fill_mode](https://reference.aspose.com/slides/pt/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Define o modo de preenchimento da imagem — `TILE` ou `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/pt/python-net/aspose.slides/picturefillformat/tile_alignment/): Especifica o alinhamento dos mosaicos dentro da forma.
- [tile_flip](https://reference.aspose.com/slides/pt/python-net/aspose.slides/picturefillformat/tile_flip/): Controla se o mosaico é invertido horizontalmente, verticalmente ou ambos.
- [tile_offset_x](https://reference.aspose.com/slides/pt/python-net/aspose.slides/picturefillformat/tile_offset_x/): Define o deslocamento horizontal do mosaico (em pontos) a partir da origem da forma.
- [tile_offset_y](https://reference.aspose.com/slides/pt/python-net/aspose.slides/picturefillformat/tile_offset_y/): Define o deslocamento vertical do mosaico (em pontos) a partir da origem da forma.
- [tile_scale_x](https://reference.aspose.com/slides/pt/python-net/aspose.slides/picturefillformat/tile_scale_x/): Define a escala horizontal do mosaico como porcentagem.
- [tile_scale_y](https://reference.aspose.com/slides/pt/python-net/aspose.slides/picturefillformat/tile_scale_y/): Define a escala vertical do mosaico como porcentagem.

```py
import aspose.slides as slides

# Instancie a classe Presentation que representa um arquivo de apresentação.
with slides.Presentation() as presentation:

    # Obtenha o primeiro slide.
    first_slide = presentation.slides[0]

    # Adicione uma forma automática retangular.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Defina o tipo de preenchimento da forma como Imagem.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Carregue a imagem e adicione-a aos recursos da apresentação.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # Atribua a imagem à forma.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # Configure o modo de preenchimento da imagem e as propriedades de mosaico.
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Salve o arquivo PPTX no disco.
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

As opções de mosaico:

![As opções de mosaico](tile-options.png)

## **Preenchimento Sólido de Cor**

No PowerPoint, Preenchimento Sólido de Cor é uma opção de formatação que preenche uma forma com uma única cor uniforme. Esta cor de fundo simples é aplicada sem gradientes, texturas ou padrões.

Para aplicar um preenchimento de cor sólida a uma forma usando Aspose.Slides, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/filltype/) da forma como `SOLID`.
1. Atribua a cor de preenchimento desejada à forma.
1. Salve a apresentação modificada como um arquivo PPTX.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancie a classe Presentation que representa um arquivo de apresentação.
with slides.Presentation() as presentation:

    # Obtenha o primeiro slide.
    slide = presentation.slides[0]

    # Adicione uma forma automática do tipo Retângulo.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Defina o tipo de preenchimento como Sólido.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Defina a cor de preenchimento.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Salve o arquivo PPTX no disco.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

A forma com preenchimento de cor sólida:

![A forma com preenchimento de cor sólida](solid-color-fill.png)

## **Definir Transparência**

No PowerPoint, ao aplicar um preenchimento sólido, gradiente, de imagem ou textura a formas, você também pode definir um nível de transparência para controlar a opacidade do preenchimento. Um valor de transparência mais alto torna a forma mais translúcida, permitindo que o fundo ou objetos subjacentes sejam parcialmente visíveis.

Aspose.Slides permite definir o nível de transparência ajustando o valor alfa na cor usada para o preenchimento. Veja como fazer isso:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) ao slide.
1. Defina o tipo de preenchimento como `SOLID`.
1. Use `Color.from_argb` para definir uma cor com transparência (o componente `alpha` controla a transparência).
1. Salve a apresentação.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instancie a classe Presentation que representa um arquivo de apresentação.
with slides.Presentation() as presentation:

    # Obtenha o primeiro slide.
    slide = presentation.slides[0]
    
    # Adicione uma forma automática retangular sólida.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Adicione uma forma automática retangular transparente sobre a forma sólida.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

A forma transparente:

![A forma transparente](shape-transparency.png)

## **Rotacionar Formas**

Aspose.Slides permite rotacionar formas em apresentações PowerPoint. Isso pode ser útil ao posicionar elementos visuais com necessidades específicas de alinhamento ou design.

Para rotacionar uma forma em um slide, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) ao slide.
1. Defina a propriedade `rotation` da forma com o ângulo desejado.
1. Salve a apresentação.

```python
import aspose.slides as slides

# Instancie a classe Presentation que representa um arquivo de apresentação.
with slides.Presentation() as presentation:

    # Obtenha o primeiro slide.
    slide = presentation.slides[0]

    # Adicione uma forma automática do tipo Retângulo.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Gire a forma em 5 graus.
    shape.rotation = 5

    # Salve o arquivo PPTX no disco.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

A rotação da forma:

![A rotação da forma](shape-rotation.png)

## **Adicionar Efeitos de Bisel 3D**

Aspose.Slides permite aplicar efeitos de bisel 3D a formas configurando as propriedades da [ThreeDFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/threedformat/).

Para adicionar efeitos de bisel 3D a uma forma, siga estas etapas:

1. Instancie a classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) ao slide.
1. Configure o [ThreeDFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/threedformat/) da forma para definir as configurações de bisel.
1. Salve a apresentação.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Crie uma instância da classe Presentation.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Adicione uma forma ao slide.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # Defina as propriedades ThreeDFormat da forma.
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # Salve a apresentação como um arquivo PPTX.
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

O efeito de bisel 3D:

![O efeito de bisel 3D](3D-bevel-effect.png)

## **Adicionar Efeitos de Rotação 3D**

Aspose.Slides permite aplicar efeitos de rotação 3D a formas configurando as propriedades da [ThreeDFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/threedformat/).

Para aplicar rotação 3D a uma forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) ao slide.
1. Defina o [camera_type](https://reference.aspose.com/slides/pt/python-net/aspose.slides/camera/camera_type/) e o [light_type](https://reference.aspose.com/slides/pt/python-net/aspose.slides/lightrig/light_type/) da forma para definir a rotação 3D.
1. Salve a apresentação.

```python
import aspose.slides as slides

# Crie uma instância da classe Presentation.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"

    auto_shape.three_d_format.depth = 6
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    # Salve a apresentação como um arquivo PPTX.
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

O efeito de rotação 3D:

![O efeito de rotação 3D](3D-rotation-effect.png)

## **Controlar a Renderização em Preto e Branco para Formas**

A propriedade [Shape.black_white_mode](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/black_white_mode/) especifica como uma forma individual é renderizada quando uma apresentação é visualizada ou processada em modo preto e branco. Ela não habilita a exibição em preto e branco por si só e não altera o preenchimento, a linha ou outra formatação da forma no modo de cores normal.

Use um valor da enumeração [BlackWhiteMode](https://reference.aspose.com/slides/pt/python-net/aspose.slides/blackwhitemode/) para selecionar o comportamento desejado. Por exemplo, `AUTOMATIC` permite que o aplicativo de renderização escolha a conversão, `GRAY` e `LIGHT_GRAY` usam coloração em tons de cinza, `BLACK_WHITE` usa apenas preto e branco, `BLACK` e `WHITE` forçam uma única cor, `COLOR` preserva a coloração normal e `HIDDEN` omite a forma no modo preto e branco. `NOT_DEFINED` indica que nenhum modo de forma foi atribuído.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange

    # Mantenha o preenchimento laranja em modo colorido, mas renderize a forma com coloração cinza no modo preto e branco.
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

## **Redefinir Formatação**

O código Python a seguir mostra como redefinir a formatação de um slide e restaurar a posição, tamanho e formatação de todas as formas com marcadores de posição no [LayoutSlide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutslide/) para suas configurações padrão:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Redefina cada forma no slide que tem um placeholder no layout.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**A formatação de formas afeta o tamanho final do arquivo da apresentação?**

Apenas de forma mínima. Imagens e mídias incorporadas ocupam a maior parte do espaço do arquivo, enquanto parâmetros de forma como cores, efeitos e gradientes são armazenados como metadados e quase não aumentam o tamanho.

**Como posso detectar formas em um slide que compartilham formatação idêntica para que eu possa agrupá‑las?**

Compare as principais propriedades de formatação de cada forma — preenchimento, linha e configurações de efeito. Se todos os valores correspondentes coincidirem, trate seus estilos como idênticos e agrupe logicamente essas formas, o que simplifica o gerenciamento de estilos posteriormente.

**Posso salvar um conjunto de estilos de forma personalizados em um arquivo separado para reutilizar em outras apresentações?**

Sim. Armazene formas de exemplo com os estilos desejados em um slide‑modelo ou em um arquivo de modelo .POTX. Ao criar uma nova apresentação, abra o modelo, clone as formas estilizadas de que precisar e reaplique sua formatação onde for necessário.