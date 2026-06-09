---
title: Formatar Formas do PowerPoint em Python
linktitle: Formatação de Formas
type: docs
weight: 20
url: /pt/python-net/shape-formatting/
keywords:
- formatar forma
- formatar linha
- formatar estilo de junção
- preenchimento gradiente
- preenchimento de padrão
- preenchimento de imagem
- preenchimento de textura
- preenchimento de cor sólida
- transparência da forma
- rotacionar forma
- efeito de bisel 3D
- efeito de rotação 3D
- redefinir formatação
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Aprenda a formatar formas do PowerPoint em Python usando Aspose.Slides—defina estilos de preenchimento, linha e efeito para arquivos PPT, PPTX e ODP com precisão e controle total."
---
## **Introdução**

No PowerPoint, você pode adicionar formas aos slides. Como as formas são compostas por linhas, é possível formatá‑las modificando ou aplicando efeitos aos seus contornos. Além disso, você pode formatar formas especificando configurações que controlam como seus interiores são preenchidos.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python fornece classes e propriedades que permitem formatar formas usando as mesmas opções disponíveis no PowerPoint.

## **Formatar Linhas**

Usando Aspose.Slides, você pode especificar um estilo de linha personalizado para uma forma. Os passos a seguir descrevem o procedimento:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) .
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) ao slide.
1. Defina o [line style](https://reference.aspose.com/slides/pt/python-net/aspose.slides/linestyle/) da forma.
1. Defina a largura da linha.
1. Defina o [dash style](https://reference.aspose.com/slides/pt/python-net/aspose.slides/linedashstyle/) da forma.
1. Defina a cor da linha para a forma.
1. Salve a apresentação modificada como um arquivo PPTX.

O código Python a seguir demonstra como formatar um `AutoShape` de retângulo:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar a classe Presentation que representa um arquivo de apresentação.
with slides.Presentation() as presentation:

    # Obter o primeiro slide.
    slide = presentation.slides[0]

    # Adicionar uma forma automática do tipo Retângulo.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Definir a cor de preenchimento para a forma retângulo.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # Aplicar formatação às linhas do retângulo.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # Definir a cor para a linha do retângulo.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Salvar o arquivo PPTX no disco.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![As linhas formatadas na apresentação](formatted-lines.png)

## **Formatar Estilos de Junção**

Aqui estão as três opções de tipo de junção:

* Round
* Miter
* Bevel

Por padrão, quando o PowerPoint junta duas linhas em um ângulo (como no canto de uma forma), ele usa a configuração **Round**. Entretanto, se você estiver desenhando uma forma com ângulos agudos, pode preferir a opção **Miter**.

![O estilo de junção na apresentação](join-style-powerpoint.png)

O código Python a seguir demonstra como três retângulos (conforme a imagem acima) foram criados usando as configurações de junção Miter, Bevel e Round:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar a classe Presentation que representa um arquivo de apresentação.
with slides.Presentation() as presentation:

	# Obter o primeiro slide.
	slide = presentation.slides[0]

	# Adicionar três formas automáticas do tipo Retângulo.
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# Definir a cor de preenchimento para cada forma retângulo.
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# Definir a largura da linha.
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# Definir a cor para a linha de cada retângulo.
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# Definir o estilo de junção.
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# Adicionar texto a cada retângulo.
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# Salvar o arquivo PPTX no disco.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **Preenchimento Gradiente**

No PowerPoint, o Preenchimento Gradiente é uma opção de formatação que permite aplicar uma transição contínua de cores a uma forma. Por exemplo, você pode aplicar duas ou mais cores de modo que uma desapareça gradualmente na outra.

Veja como aplicar um preenchimento gradiente a uma forma usando Aspose.Slides:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) .
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/filltype/) da forma como `GRADIENT`.
1. Adicione suas duas cores preferidas com posições definidas usando os métodos `add` da coleção `gradient_stops` exposta pela classe [GradientFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/gradientformat/) .
1. Salve a apresentação modificada como um arquivo PPTX.

O código Python a seguir demonstra como aplicar um efeito de preenchimento gradiente a uma elipse:

```python
import aspose.slides as slides

# Instanciar a classe Presentation que representa um arquivo de apresentação.
with slides.Presentation() as presentation:

    # Obter o primeiro slide.
    slide = presentation.slides[0]

    # Adicionar uma forma automática do tipo Elipse.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Aplicar formatação de gradiente à elipse.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Definir a direção do gradiente.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Adicionar duas paradas de gradiente.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Salvar o arquivo PPTX no disco.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![A elipse com preenchimento gradiente](gradient-fill.png)

## **Preenchimento de Padrão**

No PowerPoint, o Preenchimento de Padrão é uma opção de formatação que permite aplicar um design de duas cores — como pontos, listras, cruzes ou quadriculados — a uma forma. Você pode escolher cores personalizadas para o primeiro plano e o plano de fundo do padrão.

Aspose.Slides oferece mais de 45 estilos de padrão predefinidos que podem ser aplicados a formas para melhorar a aparência visual das suas apresentações. Mesmo após selecionar um padrão predefinido, ainda é possível especificar as cores exatas que ele deve usar.

Veja como aplicar um preenchimento de padrão a uma forma usando Aspose.Slides:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) .
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/filltype/) da forma como `PATTERN`.
1. Escolha um estilo de padrão dentre as opções predefinidas.
1. Defina a [back_color](https://reference.aspose.com/slides/pt/python-net/aspose.slides/patternformat/back_color/) do padrão.
1. Defina a [fore_color](https://reference.aspose.com/slides/pt/python-net/aspose.slides/patternformat/fore_color/) do padrão.
1. Salve a apresentação modificada como um arquivo PPTX.

O código Python a seguir demonstra como aplicar um preenchimento de padrão a um retângulo:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar a classe Presentation que representa um arquivo de apresentação.
with slides.Presentation() as presentation:

    # Obter o primeiro slide.
    slide = presentation.slides[0]

    # Adicionar uma forma automática do tipo Retângulo.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Definir o tipo de preenchimento como Pattern.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # Definir o estilo do padrão.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Definir as cores de fundo e de primeiro plano do padrão.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # Salvar o arquivo PPTX no disco.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![O retângulo com preenchimento de padrão](pattern-fill.png)

## **Preenchimento de Imagem**

No PowerPoint, o Preenchimento de Imagem é uma opção de formatação que permite inserir uma imagem dentro de uma forma — efetivamente usando a imagem como plano de fundo da forma.

Veja como usar Aspose.Slides para aplicar um preenchimento de imagem a uma forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) .
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/filltype/) da forma como `PICTURE`.
1. Defina o modo de preenchimento de imagem como `TILE` (ou outro modo preferido).
1. Crie um objeto [PPImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ppimage/) a partir da imagem que deseja usar.
1. Atribua essa imagem à propriedade `picture.image` do `picture_fill_format` da forma.
1. Salve a apresentação modificada como um arquivo PPTX.

Suponha que tenhamos um arquivo "lotus.png" com a seguinte imagem:

![A imagem do lótus](lotus.png)

O código Python a seguir demonstra como preencher uma forma com a imagem:

```python
import aspose.slides as slides

# Instanciar a classe Presentation que representa um arquivo de apresentação.
with slides.Presentation() as presentation:

    # Obter o primeiro slide.
    slide = presentation.slides[0]

    # Adicionar uma forma automática do tipo Retângulo.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # Definir o tipo de preenchimento como Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Definir o modo de preenchimento de imagem.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Carregar uma imagem e adicioná-la aos recursos da apresentação.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # Definir a imagem.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # Salvar o arquivo PPTX no disco.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![A forma com preenchimento de imagem](picture-fill.png)

### **Imagem em Tile Como Textura**

Se desejar definir uma imagem em mosaico como textura e personalizar o comportamento de ladrilhamento, você pode usar as seguintes propriedades da classe [PictureFillFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/picturefillformat/) :

- [picture_fill_mode](https://reference.aspose.com/slides/pt/python-net/aspose.slides/picturefillformat/picture_fill_mode/) : Define o modo de preenchimento de imagem — `TILE` ou `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/pt/python-net/aspose.slides/picturefillformat/tile_alignment/) : Especifica o alinhamento dos tiles dentro da forma.
- [tile_flip](https://reference.aspose.com/slides/pt/python-net/aspose.slides/picturefillformat/tile_flip/) : Controla se o tile é invertido horizontalmente, verticalmente ou ambos.
- [tile_offset_x](https://reference.aspose.com/slides/pt/python-net/aspose.slides/picturefillformat/tile_offset_x/) : Define o deslocamento horizontal do tile (em pontos) a partir da origem da forma.
- [tile_offset_y](https://reference.aspose.com/slides/pt/python-net/aspose.slides/picturefillformat/tile_offset_y/) : Define o deslocamento vertical do tile (em pontos) a partir da origem da forma.
- [tile_scale_x](https://reference.aspose.com/slides/pt/python-net/aspose.slides/picturefillformat/tile_scale_x/) : Define a escala horizontal do tile como porcentagem.
- [tile_scale_y](https://reference.aspose.com/slides/pt/python-net/aspose.slides/picturefillformat/tile_scale_y/) : Define a escala vertical do tile como porcentagem.

O exemplo de código a seguir mostra como adicionar uma forma retangular com preenchimento de imagem em tile e configurar as opções de tile:

```py
import aspose.slides as slides

# Instanciar a classe Presentation que representa um arquivo de apresentação.
with slides.Presentation() as presentation:

    # Obter o primeiro slide.
    first_slide = presentation.slides[0]

    # Adicionar uma forma automática retangular.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Definir o tipo de preenchimento da forma como Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Carregar a imagem e adicioná-la aos recursos da apresentação.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # Atribuir a imagem à forma.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # Configurar o modo de preenchimento de imagem e as propriedades de ladrilhamento.
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Salvar o arquivo PPTX no disco.
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![As opções de tile](tile-options.png)

## **Preenchimento de Cor Sólida**

No PowerPoint, o Preenchimento de Cor Sólida é uma opção de formatação que preenche uma forma com uma única cor uniforme. Essa cor de fundo simples é aplicada sem gradientes, texturas ou padrões.

Para aplicar um preenchimento de cor sólida a uma forma usando Aspose.Slides, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) .
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/filltype/) da forma como `SOLID`.
1. Atribua a cor de preenchimento desejada à forma.
1. Salve a apresentação modificada como um arquivo PPTX.

O código Python a seguir demonstra como aplicar um preenchimento de cor sólida a um retângulo em um slide PowerPoint:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar a classe Presentation que representa um arquivo de apresentação.
with slides.Presentation() as presentation:

    # Obter o primeiro slide.
    slide = presentation.slides[0]

    # Adicionar uma forma automática do tipo Retângulo.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Definir o tipo de preenchimento como Solid.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Definir a cor de preenchimento.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Salvar o arquivo PPTX no disco.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![A forma com preenchimento de cor sólida](solid-color-fill.png)

## **Definir Transparência**

No PowerPoint, ao aplicar um preenchimento sólido, gradiente, de imagem ou textura a formas, você também pode definir um nível de transparência para controlar a opacidade do preenchimento. Um valor de transparência mais alto torna a forma mais translúcida, permitindo que o fundo ou objetos subjacentes sejam parcialmente visíveis.

Aspose.Slides permite definir o nível de transparência ajustando o valor alfa na cor usada para o preenchimento. Veja como fazer isso:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) .
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) ao slide.
1. Defina o tipo de preenchimento como `SOLID`.
1. Use `Color.from_argb` para definir uma cor com transparência (o componente `alpha` controla a transparência).
1. Salve a apresentação.

O código Python a seguir demonstra como aplicar uma cor de preenchimento transparente a um retângulo:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instanciar a classe Presentation que representa um arquivo de apresentação.
with slides.Presentation() as presentation:

    # Obter o primeiro slide.
    slide = presentation.slides[0]
    
    # Adicionar uma forma automática retangular sólida.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Adicionar uma forma automática retangular transparente sobre a forma sólida.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![A forma transparente](shape-transparency.png)

## **Rotacionar Formas**

Aspose.Slides permite rotacionar formas em apresentações PowerPoint. Isso pode ser útil ao posicionar elementos visuais com necessidades específicas de alinhamento ou design.

Para rotacionar uma forma em um slide, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) .
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) ao slide.
1. Defina a propriedade `rotation` da forma para o ângulo desejado.
1. Salve a apresentação.

O código Python a seguir demonstra como rotacionar uma forma em 5 graus:

```python
import aspose.slides as slides

# Instanciar a classe Presentation que representa um arquivo de apresentação.
with slides.Presentation() as presentation:

    # Obter o primeiro slide.
    slide = presentation.slides[0]

    # Adicionar uma forma automática do tipo Retângulo.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Rotacionar a forma em 5 graus.
    shape.rotation = 5

    # Salvar o arquivo PPTX no disco.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![A rotação da forma](shape-rotation.png)

## **Adicionar Efeitos de Bisel 3D**

Aspose.Slides permite aplicar efeitos de bisel 3D a formas configurando as propriedades do [ThreeDFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/threedformat/) .

Para adicionar efeitos de bisel 3D a uma forma, siga estas etapas:

1. Instancie a classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) .
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) ao slide.
1. Configure o [ThreeDFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/threedformat/) da forma para definir as configurações de bisel.
1. Salve a apresentação.

O código Python a seguir mostra como aplicar efeitos de bisel 3D a uma forma:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Criar uma instância da classe Presentation.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Adicionar uma forma ao slide.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # Definir as propriedades ThreeDFormat da forma.
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # Salvar a apresentação como um arquivo PPTX.
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![O efeito de bisel 3D](3D-bevel-effect.png)

## **Adicionar Efeitos de Rotação 3D**

Aspose.Slides permite aplicar efeitos de rotação 3D a formas configurando as propriedades do [ThreeDFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/threedformat/) .

Para aplicar rotação 3D a uma forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) .
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) ao slide.
1. Defina os valores de [camera_type](https://reference.aspose.com/slides/pt/python-net/aspose.slides/camera/camera_type/) e [light_type](https://reference.aspose.com/slides/pt/python-net/aspose.slides/lightrig/light_type/) da forma para especificar a rotação 3D.
1. Salve a apresentação.

O código Python a seguir demonstra como aplicar efeitos de rotação 3D a uma forma:

```python
import aspose.slides as slides

# Criar uma instância da classe Presentation.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"

    auto_shape.three_d_format.depth = 6
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    # Salvar a apresentação como um arquivo PPTX.      
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![O efeito de rotação 3D](3D-rotation-effect.png)

## **Redefinir Formatação**

O código Python a seguir mostra como redefinir a formatação de um slide e restaurar a posição, tamanho e formatação de todas as formas com marcadores no [LayoutSlide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutslide/) para as configurações padrão:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Redefinir cada forma no slide que tem um marcador no layout.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**A formatação de formas afeta o tamanho final do arquivo de apresentação?**

Apenas minimamente. Imagens e mídias incorporadas ocupam a maior parte do espaço do arquivo, enquanto parâmetros de forma como cores, efeitos e gradientes são armazenados como metadados e praticamente não acrescentam tamanho extra.

**Como posso detectar formas em um slide que compartilham formatação idêntica para agrupá‑las?**

Compare as principais propriedades de formatação de cada forma — preenchimento, linha e configurações de efeito. Se todos os valores correspondentes coincidirem, trate seus estilos como idênticos e agrupe logicamente essas formas, o que simplifica o gerenciamento posterior de estilos.

**Posso salvar um conjunto de estilos de forma personalizados em um arquivo separado para reutilização em outras apresentações?**

Sim. Armazene formas de exemplo com os estilos desejados em um slide‑modelo ou em um arquivo de modelo .POTX. Ao criar uma nova apresentação, abra o modelo, clone as formas estilizadas que precisar e reaplique sua formatação onde for necessário.