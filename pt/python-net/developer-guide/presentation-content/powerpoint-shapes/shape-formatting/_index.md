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
- linha de forma esboçada
- formatar estilo de junção
- preenchimento gradiente
- preenchimento de padrão
- preenchimento de imagem
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
- Aspose.Slides
description: "Aprenda a formatar formas do PowerPoint em Python usando Aspose.Slides — defina estilos de preenchimento, linha e efeito para arquivos PPT, PPTX e ODP com precisão e controle total."
---
## **Introdução**

No PowerPoint, você pode adicionar formas aos slides. Como as formas são compostas por linhas, você pode formatá‑las modificando ou aplicando efeitos aos seus contornos. Além disso, você pode formatar as formas especificando configurações que controlam como seus interiores são preenchidos.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python fornece classes e propriedades que permitem formatar formas usando as mesmas opções disponíveis no PowerPoint.

## **Formatar Linhas**

Usando Aspose.Slides, você pode especificar um estilo de linha personalizado para uma forma. As etapas a seguir descrevem o procedimento:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Obtenha uma referência a um slide pelo seu índice.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ao slide.
4. Defina o [line style](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/) da forma.
5. Defina a largura da linha.
6. Defina o [dash style](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) da forma.
7. Defina a cor da linha para a forma.
8. Salve a apresentação modificada como um arquivo PPTX.

O código Python a seguir demonstra como formatar um `AutoShape` retangular:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar a classe Presentation que representa um arquivo de apresentação.
with slides.Presentation() as presentation:

    # Obter o primeiro slide.
    slide = presentation.slides[0]

    # Adicionar uma forma automática do tipo Retângulo.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Remover o preenchimento da forma de retângulo para que apenas suas linhas estejam visíveis.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # Aplicar formatação às linhas do retângulo.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # Definir a cor da linha do retângulo.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Salvar o arquivo PPTX no disco.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![As linhas formatadas na apresentação](formatted-lines.png)

## **Aplicar Efeitos de Esboço às Linhas de Forma**

Um efeito de esboço faz uma linha de forma parecer desenhada à mão. Use [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) para acessar as configurações de linha, [LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/) para acessar as configurações de esboço e [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) para selecionar um valor da enumeração [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/).

O código Python a seguir mostra como aplicar um efeito [LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) , ler o valor atribuído explicitamente e remover o efeito com [LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # Acessar o formato de linha da forma e seu formato de esboço.
    sketch_format = shape.line_format.sketch_format

    # Aplicar um efeito de esboço.
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # Ler o efeito de esboço atribuído diretamente à forma.
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Remover o efeito de esboço.
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

O valor retornado por `SketchFormat.sketch_type` representa a configuração atribuída diretamente à forma. Se a formatação da linha puder ser herdada de um tema, slide mestre ou slide de layout, use [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/), acesse a propriedade `sketch_format` do objeto retornado e leia sua propriedade `sketch_type`. O valor efetivo reflete a formatação que realmente é aplicada após a resolução da herança:

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

* Round
* Miter
* Bevel

Por padrão, quando o PowerPoint une duas linhas em um ângulo (como no canto de uma forma), ele usa a configuração **Round**. No entanto, se você estiver desenhando uma forma com ângulos agudos, pode preferir a opção **Miter**.

![O estilo de junção na apresentação](join-style-powerpoint.png)

O código Python a seguir demonstra como três retângulos (conforme mostrados na imagem acima) foram criados usando as configurações de tipo de junção Miter, Bevel e Round:

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

	# Definir a cor da linha de cada retângulo.
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

No PowerPoint, Preenchimento Gradiente é uma opção de formatação que permite aplicar uma mescla contínua de cores a uma forma. Por exemplo, você pode aplicar duas ou mais cores de maneira que uma gradualmente se desvaneça na outra.

Eis como aplicar um preenchimento gradiente a uma forma usando Aspose.Slides:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Obtenha uma referência a um slide pelo seu índice.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ao slide.
4. Defina o [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) da forma como `GRADIENT`.
5. Adicione suas duas cores preferidas com posições definidas usando os métodos `add` da coleção `gradient_stops` exposta pela classe [GradientFormat](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/) .
6. Salve a apresentação modificada como um arquivo PPTX.

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

![A elipse com preenchimento gradiente](gradient-fill.png)

Se um gradiente parecer diferente em uma imagem exportada em comparação ao PowerPoint, consulte [Escolha um Estilo de Renderização de Gradiente](/slides/pt/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Você pode selecionar um estilo de renderização sem alterar o preenchimento gradiente armazenado na apresentação.

## **Preenchimento de Padrão**

No PowerPoint, Preenchimento de Padrão é uma opção de formatação que permite aplicar um design de duas cores — como pontos, listras, hachuras ou quadriculados — a uma forma. Você pode escolher cores personalizadas para o primeiro plano e plano de fundo do padrão.

Aspose.Slides fornece mais de 45 estilos de padrão predefinidos que você pode aplicar a formas para melhorar o apelo visual de suas apresentações. Mesmo depois de selecionar um padrão predefinido, ainda é possível especificar as cores exatas que ele deve usar.

Eis como aplicar um preenchimento de padrão a uma forma usando Aspose.Slides:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Obtenha uma referência a um slide pelo seu índice.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ao slide.
4. Defina o [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) da forma como `PATTERN`.
5. Escolha um estilo de padrão entre as opções predefinidas.
6. Defina o [back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) do padrão.
7. Defina o [fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) do padrão.
8. Salve a apresentação modificada como um arquivo PPTX.

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

![O retângulo com preenchimento de padrão](pattern-fill.png)

## **Preenchimento de Imagem**

No PowerPoint, Preenchimento de Imagem é uma opção de formatação que permite inserir uma imagem dentro de uma forma — efetivamente usando a imagem como plano de fundo da forma.

Eis como usar Aspose.Slides para aplicar um preenchimento de imagem a uma forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Obtenha uma referência a um slide pelo seu índice.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ao slide.
4. Defina o [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) da forma como `PICTURE`.
5. Defina o modo de preenchimento de imagem para `TILE` (ou outro modo preferido).
6. Crie um objeto [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) a partir da imagem que deseja usar.
7. Atribua esta imagem à propriedade `picture.image` do `picture_fill_format` da forma.
8. Salve a apresentação modificada como um arquivo PPTX.

Suponha que temos um arquivo "lotus.png" com a seguinte imagem:

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

    # Definir o modo de preenchimento da imagem.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Carregar uma imagem e adicioná-la aos recursos da apresentação.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # Definir a imagem.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # Salvar o arquivo PPTX no disco.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

![A forma com preenchimento de imagem](picture-fill.png)

### **Azulejar Imagem como Textura**

Se você quiser definir uma imagem em ladrilhos como textura e personalizar o comportamento de ladrilhos, pode usar as seguintes propriedades da classe [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) :

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Define o modo de preenchimento de imagem — `TILE` ou `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): Especifica o alinhamento dos ladrilhos dentro da forma.
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): Controla se o ladrilho é invertido horizontalmente, verticalmente ou ambos.
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): Define o deslocamento horizontal do ladrilho (em pontos) a partir da origem da forma.
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): Define o deslocamento vertical do ladrilho (em pontos) a partir da origem da forma.
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): Define a escala horizontal do ladrilho como porcentagem.
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): Define a escala vertical do ladrilho como porcentagem.

O exemplo de código a seguir mostra como adicionar uma forma retangular com preenchimento de imagem em ladrilhos e configurar as opções de ladrilhos:

```py
import aspose.slides as slides

# Instanciar a classe Presentation que representa um arquivo de apresentação.
with slides.Presentation() as presentation:

    # Obter o primeiro slide.
    first_slide = presentation.slides[0]

    # Adicionar uma forma automática de retângulo.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Definir o tipo de preenchimento da forma como Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Carregar a imagem e adicioná-la aos recursos da apresentação.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # Atribuir a imagem à forma.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # Configurar o modo de preenchimento da imagem e as propriedades de ladrilhamento.
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

![As opções de ladrilhos](tile-options.png)

## **Preenchimento de Cor Sólida**

No PowerPoint, Preenchimento de Cor Sólida é uma opção de formatação que preenche uma forma com uma única cor uniforme. Essa cor de fundo simples é aplicada sem gradientes, texturas ou padrões.

Para aplicar um preenchimento de cor sólida a uma forma usando Aspose.Slides, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Obtenha uma referência a um slide pelo seu índice.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ao slide.
4. Defina o [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) da forma como `SOLID`.
5. Atribua a cor de preenchimento preferida à forma.
6. Salve a apresentação modificada como um arquivo PPTX.

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

![A forma com preenchimento de cor sólida](solid-color-fill.png)

## **Definir Transparência**

No PowerPoint, ao aplicar um preenchimento sólido, gradiente, imagem ou textura a formas, você também pode definir um nível de transparência para controlar a opacidade do preenchimento. Um valor de transparência mais alto torna a forma mais translúcida, permitindo que o fundo ou objetos subjacentes sejam parcialmente visíveis.

Aspose.Slides permite definir o nível de transparência ajustando o valor alfa na cor usada para o preenchimento. Eis como fazer isso:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Obtenha uma referência a um slide pelo seu índice.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ao slide.
4. Defina o tipo de preenchimento como `SOLID`.
5. Use `Color.from_argb` para definir uma cor com transparência (o componente `alpha` controla a transparência).
6. Salve a apresentação.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instanciar a classe Presentation que representa um arquivo de apresentação.
with slides.Presentation() as presentation:

    # Obter o primeiro slide.
    slide = presentation.slides[0]
    
    # Adicionar uma forma automática de retângulo sólido.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Adicionar uma forma automática de retângulo transparente sobre a forma sólida.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

![A forma transparente](shape-transparency.png)

## **Rotacionar Formas**

Aspose.Slides permite rotacionar formas em apresentações do PowerPoint. Isso pode ser útil ao posicionar elementos visuais com alinhamento ou necessidades de design específicas.

Para rotacionar uma forma em um slide, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Obtenha uma referência a um slide pelo seu índice.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ao slide.
4. Defina a propriedade `rotation` da forma para o ângulo desejado.
5. Salve a apresentação.

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

![A rotação da forma](shape-rotation.png)

## **Adicionar Efeitos de Bisel 3D**

Aspose.Slides permite aplicar efeitos de bisel 3D a formas configurando suas propriedades [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) .

Para adicionar efeitos de bisel 3D a uma forma, siga estas etapas:

1. Instancie a classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Obtenha uma referência a um slide pelo seu índice.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ao slide.
4. Configure o [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) da forma para definir as configurações de bisel.
5. Salve a apresentação.

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

![O efeito de bisel 3D](3D-bevel-effect.png)

## **Adicionar Efeitos de Rotação 3D**

Aspose.Slides permite aplicar efeitos de rotação 3D a formas configurando suas propriedades [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) .

Para aplicar rotação 3D a uma forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Obtenha uma referência a um slide pelo seu índice.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ao slide.
4. Defina o [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) e o [light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/) da forma para definir a rotação 3D.
5. Salve a apresentação.

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

![O efeito de rotação 3D](3D-rotation-effect.png)

## **Controlar Renderização em Preto‑e‑Branco para Formas**

A propriedade [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) especifica como uma forma individual é renderizada quando uma apresentação é visualizada ou processada em modo preto‑e‑branco. Ela não habilita a exibição em preto‑e‑branco por si só, e não altera o preenchimento, a linha ou outras formatações da forma no modo de cor normal.

Use um valor da enumeração [BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/) para selecionar o comportamento desejado. Por exemplo, `AUTOMATIC` permite que o aplicativo de renderização escolha a conversão, `GRAY` e `LIGHT_GRAY` utilizam coloração cinza, `BLACK_WHITE` usa apenas preto e branco, `BLACK` e `WHITE` forçam uma única cor, `COLOR` preserva a coloração normal, e `HIDDEN` omite a forma no modo preto‑e‑branco. `NOT_DEFINED` significa que nenhum modo de nível de forma está atribuído.

O código Python a seguir cria uma forma colorida e faz com que ela apareça cinza no modo de exibição preto‑e‑branco:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange

    # Manter o preenchimento laranja no modo de cor, mas renderizar a forma com coloração cinza no modo preto e branco.
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

No modo de cor normal, o retângulo mantém seu preenchimento laranja. Em um fluxo de trabalho de exibição em preto‑e‑branco, ele usa coloração cinza porque seu modo está definido como `GRAY`. Isso permite que você preserve um slide em cores completas enquanto define uma aparência distinta para impressão, visualização ou outros fluxos de trabalho que respeitam as configurações de exibição em preto‑e‑branco da apresentação.

## **Redefinir Formatação**

O código Python a seguir mostra como redefinir a formatação de um slide e reverter a posição, tamanho e formatação de todas as formas com marcadores de posição no [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) para suas configurações padrão:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Redefinir cada forma no slide que possui um placeholder no layout.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**A formatação de forma afeta o tamanho final do arquivo de apresentação?**

Somente minimamente. Imagens e mídia incorporadas ocupam a maior parte do espaço do arquivo, enquanto parâmetros de forma como cores, efeitos e gradientes são armazenados como metadados e praticamente não adicionam tamanho extra.

**Como posso detectar formas em um slide que compartilham formatação idêntica para que eu possa agrupá‑las?**

Compare as propriedades de formatação principais de cada forma — preenchimento, linha e configurações de efeito. Se todos os valores correspondentes coincidirem, trate seus estilos como idênticos e agrupe logicamente essas formas, o que simplifica o gerenciamento de estilos posterior.

**Posso salvar um conjunto de estilos de forma personalizados em um arquivo separado para reutilização em outras apresentações?**

Sim. Armazene formas de amostra com os estilos desejados em um conjunto de slides modelo ou em um arquivo modelo .POTX. Ao criar uma nova apresentação, abra o modelo, clone as formas estilizadas que precisar e reaplique sua formatação onde for necessário.