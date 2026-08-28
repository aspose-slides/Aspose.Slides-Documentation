---
title: Gerenciar Parágrafos de Texto do PowerPoint em Python
linktitle: Gerenciar Parágrafo
type: docs
weight: 40
url: /pt/python-net/manage-paragraph/
aliases:
  - /python-net/paragraph/
  - /python-net/portion/
keywords:
  - adicionar texto
  - adicionar parágrafo
  - gerenciar texto
  - gerenciar parágrafo
  - gerenciar marcador
  - recuo de parágrafo
  - recuo suspenso
  - marcador de parágrafo
  - lista numerada
  - lista com marcadores
  - propriedades do parágrafo
  - importar HTML
  - texto para HTML
  - parágrafo para HTML
  - parágrafo para imagem
  - texto para imagem
  - exportar parágrafo
  - PowerPoint
  - apresentação
  - Python
  - Aspose.Slides
description: "Aprenda como criar e formatar parágrafos, porções, marcadores, listas numeradas, recuos, conteúdo HTML e imagens de parágrafo com Aspose.Slides para Python via .NET."
---
## **Visão geral**

Aspose.Slides for Python via .NET representa o texto como uma hierarquia de quadros de texto, parágrafos e trechos:

* [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/) representa o contêiner de texto em uma forma e fornece acesso à sua coleção de parágrafos.
* [Paragraph](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraph/) representa um parágrafo em um quadro de texto e fornece acesso às suas porções e à formatação de nível de parágrafo.
* [Portion](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portion/) representa uma sequência de texto dentro de um parágrafo. Cada porção pode ter seu próprio texto e formatação de nível de caractere.

Um parágrafo pode, portanto, conter texto com diferentes fontes, cores, tamanhos e outras formatações usando várias porções.

## **Criar e formatar parágrafos**

### **Criar parágrafos com várias porções**

As etapas a seguir criam um quadro de texto com três parágrafos, cada um contendo três porções:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Acesse o slide relevante por seu índice.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) retangular ao slide.
4. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/) da forma.
5. Use o parágrafo padrão e adicione mais dois objetos [Paragraph](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraph/) ao quadro de texto.
6. Adicione objetos [Portion](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portion/) suficientes para que cada parágrafo contenha três porções. O parágrafo padrão já contém uma porção vazia.
7. Defina o texto de cada porção.
8. Aplique a formatação de nível de caractere através de [Portion.portion_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portion/portion_format/).
9. Salve a apresentação modificada.

Este exemplo Python implementa as etapas:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)
    text_frame = shape.text_frame

    first_paragraph = text_frame.paragraphs[0]
    first_paragraph.portions.add(slides.Portion())
    first_paragraph.portions.add(slides.Portion())

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(third_paragraph)

    for paragraph_index in range(text_frame.paragraphs.count):
        paragraph = text_frame.paragraphs[paragraph_index]
        for portion_index in range(paragraph.portions.count):
            portion = paragraph.portions[portion_index]
            portion.text = f"Portion {paragraph_index + 1}.{portion_index + 1}"

            if portion_index == 0:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.red
                portion.portion_format.font_bold = slides.NullableBool.TRUE
                portion.portion_format.font_height = 15
            elif portion_index == 1:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                portion.portion_format.font_italic = slides.NullableBool.TRUE
                portion.portion_format.font_height = 18

    presentation.save("paragraphs_with_portions.pptx", slides.export.SaveFormat.PPTX)
```

## **Criar listas com marcadores e numeradas**

### **Criar uma lista com marcadores ou numerada**

Marcadores e numeração facilitam a leitura de itens relacionados. No Aspose.Slides, as configurações de lista são definidas através de [BulletFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/bulletformat/).

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Acesse o slide relevante por seu índice.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) ao slide selecionado.
4. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/) da forma.
5. Remova o parágrafo padrão do quadro de texto.
6. Crie um [Paragraph](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraph/) para um marcador de símbolo.
7. Defina [BulletFormat.type](https://reference.aspose.com/slides/pt/python-net/aspose.slides/bulletformat/type/) como [BulletType.SYMBOL](https://reference.aspose.com/slides/pt/python-net/aspose.slides/bullettype/) e especifique o caractere do marcador.
8. Defina o texto do parágrafo, recuo, cor do marcador e altura do marcador.
9. Adicione o parágrafo ao quadro de texto.
10. Crie um segundo parágrafo e defina [BulletFormat.type](https://reference.aspose.com/slides/pt/python-net/aspose.slides/bulletformat/type/) como [BulletType.NUMBERED](https://reference.aspose.com/slides/pt/python-net/aspose.slides/bullettype/).
11. Configure o estilo de marcador numerado e adicione o parágrafo ao quadro de texto.
12. Salve a apresentação.

Este exemplo Python cria um marcador de símbolo e um marcador numerado:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    symbol_paragraph = slides.Paragraph()
    symbol_paragraph.text = "Welcome to Aspose.Slides"
    symbol_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    symbol_paragraph.paragraph_format.bullet.char = chr(0x2022)
    symbol_paragraph.paragraph_format.indent = 25
    symbol_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    symbol_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    symbol_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    symbol_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(symbol_paragraph)

    numbered_paragraph = slides.Paragraph()
    numbered_paragraph.text = "This is a numbered item"
    numbered_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    numbered_paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WD_BLACK_PLAIN
    numbered_paragraph.paragraph_format.indent = 25
    numbered_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    numbered_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    numbered_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    numbered_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(numbered_paragraph)

    presentation.save("bulleted_and_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

### **Usar marcadores de imagem**

Marcadores de imagem permitem usar uma imagem personalizada em vez de um símbolo ou número.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Acesse o slide relevante por seu índice.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) e acesse seu [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/).
4. Remova o parágrafo padrão do quadro de texto.
5. Carregue a imagem do marcador e adicione-a à coleção de imagens da apresentação como um [PPImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ppimage/).
6. Crie um [Paragraph](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraph/) e defina seu texto.
7. Defina [BulletFormat.type](https://reference.aspose.com/slides/pt/python-net/aspose.slides/bulletformat/type/) como [BulletType.PICTURE](https://reference.aspose.com/slides/pt/python-net/aspose.slides/bullettype/).
8. Atribua a imagem através de [BulletFormat.picture](https://reference.aspose.com/slides/pt/python-net/aspose.slides/bulletformat/picture/) e defina a altura do marcador.
9. Adicione o parágrafo ao quadro de texto.
10. Salve a apresentação modificada.

Este exemplo Python cria um marcador de imagem:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("bullets.png") as bullet_image:
        presentation_image = presentation.images.add_image(bullet_image)

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = presentation_image
    paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(paragraph)

    presentation.save("picture_bullet.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("picture_bullet.ppt", slides.export.SaveFormat.PPT)
```

### **Criar uma lista de vários níveis**

Defina [ParagraphFormat.depth](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/depth/) para posicionar os parágrafos em diferentes níveis de uma lista. O nível superior tem profundidade `0`.

1. Crie um [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) e acesse um slide.
2. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) e limpe o parágrafo padrão de seu quadro de texto.
3. Crie quatro parágrafos e configure seus símbolos de marcador.
4. Defina seus valores de [ParagraphFormat.depth](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/depth/) como `0`, `1`, `2` e `3`.
5. Adicione os parágrafos ao quadro de texto e salve a apresentação.

Este exemplo Python cria uma lista de marcadores de quatro níveis:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Content"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    first_paragraph.paragraph_format.bullet.char = chr(0x2022)
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.depth = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Second level"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    second_paragraph.paragraph_format.bullet.char = "-"
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.depth = 1

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Third level"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    third_paragraph.paragraph_format.bullet.char = chr(0x2022)
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.depth = 2

    fourth_paragraph = slides.Paragraph()
    fourth_paragraph.text = "Fourth level"
    fourth_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    fourth_paragraph.paragraph_format.bullet.char = "-"
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    fourth_paragraph.paragraph_format.depth = 3

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)
    text_frame.paragraphs.add(fourth_paragraph)

    presentation.save("multilevel_list.pptx", slides.export.SaveFormat.PPTX)
```

### **Iniciar itens de lista numerada com valores personalizados**

Use [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/pt/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) para definir o número inicial exibido para um parágrafo numerado.

1. Crie um [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) e adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) a um slide.
2. Limpe o parágrafo padrão do quadro de texto da forma.
3. Crie três parágrafos numerados.
4. Defina [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/pt/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) como `2`, `3` e `7` para os respectivos parágrafos.
5. Adicione os parágrafos ao quadro de texto e salve a apresentação.

Este exemplo Python atribui um número inicial personalizado a cada parágrafo:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Start at 2"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    first_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 2
    text_frame.paragraphs.add(first_paragraph)

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Start at 3"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    second_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 3
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Start at 7"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    third_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 7
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("custom_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

## **Controlar layout e propriedades de término de parágrafos**

### **Definir recuo da primeira linha**

Use a propriedade [ParagraphFormat.indent](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/indent/) para controlar o recuo da primeira linha de um parágrafo. Essa propriedade move apenas a primeira linha em relação à margem esquerda do parágrafo. Um valor positivo desloca a primeira linha para a direita, enquanto as linhas restantes permanecem alinhadas ao corpo do parágrafo.

Use [ParagraphFormat.margin_left](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/margin_left/) quando precisar mover todo o parágrafo. Use [ParagraphFormat.indent](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/indent/) quando precisar mover apenas a primeira linha.

O exemplo abaixo cria vários parágrafos e aplica diferentes valores de [ParagraphFormat.indent](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/indent/) para demonstrar como o recuo da primeira linha afeta o layout do parágrafo.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Acesse o slide de destino.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) retangular ao slide.
4. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/) da forma e remova o parágrafo padrão.
5. Crie vários parágrafos e defina diferentes valores de [ParagraphFormat.indent](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/indent/) para eles.
6. Adicione os parágrafos ao quadro de texto.
7. Salve a apresentação modificada.

Este código mostra como definir o recuo de um parágrafo:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 20
    first_paragraph.paragraph_format.indent = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 20
    second_paragraph.paragraph_format.indent = 20

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.margin_left = 20
    third_paragraph.paragraph_format.indent = 40

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![O recuo da primeira linha dos parágrafos](first_line_indent.png)

### **Definir recuo suspenso**

Um recuo suspenso é um layout de parágrafo em que a primeira linha começa à esquerda das linhas restantes. No Aspose.Slides, você cria esse efeito com a propriedade [ParagraphFormat.indent](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/indent/). Defina `indent` como um valor negativo para mover a primeira linha para a esquerda em relação ao corpo do parágrafo.

Na prática, [ParagraphFormat.margin_left](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/margin_left/) define a posição esquerda do corpo do parágrafo, e [ParagraphFormat.indent](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/indent/) define a posição da primeira linha em relação a essa margem. Para criar um recuo suspenso, defina um valor positivo de `margin_left` e um valor negativo de `indent`.

Essa formatação é útil para bibliografias, referências, entradas de glossário e outros parágrafos onde linhas envolvidas devem alinhar-se sob o corpo do parágrafo e não sob o primeiro caractere da primeira linha.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Acesse o slide de destino.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) retangular ao slide.
4. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/) da forma e remova o parágrafo padrão.
5. Crie parágrafos e defina um valor positivo de [ParagraphFormat.margin_left](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/margin_left/) para cada parágrafo.
6. Defina um valor negativo de [ParagraphFormat.indent](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/indent/) para criar o efeito de recuo suspenso.
7. Adicione os parágrafos ao quadro de texto.
8. Salve a apresentação modificada.

Este código mostra como definir um recuo suspenso para um parágrafo:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 40
    first_paragraph.paragraph_format.indent = -20

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 60
    second_paragraph.paragraph_format.indent = -30

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![O recuo suspenso dos parágrafos](hanging_indent.png)

### **Definir propriedades da porção final do parágrafo**

A propriedade [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) controla a formatação da marca de fim do parágrafo. O exemplo a seguir atribui um tamanho de fonte e fonte latina à marca de fim do segundo parágrafo:

1. Carregue um [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) e acesse um slide.
2. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) e limpe seu parágrafo padrão.
3. Crie dois parágrafos e adicione porções de texto a eles.
4. Crie um [PortionFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portionformat/) para a marca de fim do segundo parágrafo.
5. Defina [PortionFormat.font_height](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portionformat/font_height/) e [PortionFormat.latin_font](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portionformat/latin_font/).
6. Atribua o formato a [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) e salve a apresentação.

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.portions.add(slides.Portion("Sample text"))

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion("Sample text 2"))

    end_paragraph_format = slides.PortionFormat()
    end_paragraph_format.font_height = 48
    end_paragraph_format.latin_font = slides.FontData("Times New Roman")
    second_paragraph.end_paragraph_portion_format = end_paragraph_format

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("end_paragraph_format.pptx", slides.export.SaveFormat.PPTX)
```

## **Importar e exportar conteúdo de parágrafos**

### **Importar texto HTML em parágrafos**

Use [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphcollection/add_from_html/) para converter marcação HTML em parágrafos e porções em um quadro de texto.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Acesse um slide e adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/).
3. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/) da forma e limpe seu parágrafo padrão.
4. Leia o arquivo HTML fonte.
5. Passe a string HTML para [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphcollection/add_from_html/).
6. Salve a apresentação modificada.

Este exemplo Python importa HTML para um quadro de texto:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape_width = presentation.slide_size.size.width - 20
    shape_height = presentation.slide_size.size.height - 20
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, shape_width, shape_height)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    with open("file.html", "r", encoding="utf-8") as html_stream:
        html = html_stream.read()

    shape.text_frame.paragraphs.add_from_html(html)
    presentation.save("html_text.pptx", slides.export.SaveFormat.PPTX)
```

### **Exportar texto de parágrafo para HTML**

Use [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphcollection/export_to_html/) para exportar um intervalo selecionado de parágrafos como HTML.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) e carregue a apresentação desejada.
2. Acesse o slide e localize o [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) que contém o texto.
3. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/) da forma.
4. Chame [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphcollection/export_to_html/) com o índice do parágrafo inicial e o número de parágrafos a exportar.
5. Grave a string HTML retornada em um arquivo.

Este exemplo Python exporta todos os parágrafos da primeira forma de texto:

```python
import aspose.slides as slides

with slides.Presentation("ExportingHTMLText.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
        paragraphs = shape.text_frame.paragraphs
        html = paragraphs.export_to_html(0, paragraphs.count, None)
        with open("paragraphs.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
    else:
        print("The first shape is not a text shape.")
```

### **Renderizar um parágrafo como imagem**

[Paragraph](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraph/) fornece o método `get_image` para renderizar diretamente um parágrafo individual. O método retorna um [IImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/iimage/) que você pode salvar em um arquivo ou fluxo com [IImage.save](https://reference.aspose.com/slides/pt/python-net/aspose.slides/iimage/save/). Não é necessário renderizar a forma que contém o parágrafo ou recortar um bitmap manualmente.

O método `get_image` pode retornar `None` se o parágrafo não for encontrado na coleção pai, não tiver limites de renderização válidos ou não puder ser renderizado. Verifique o resultado antes de salvá‑lo e use a imagem retornada como um gerenciador de contexto para liberar seus recursos.

#### **Renderizar um parágrafo na escala padrão**

Suponha que temos um arquivo de apresentação chamado sample.pptx com um slide, onde a primeira forma é uma caixa de texto contendo três parágrafos.

![A caixa de texto com três parágrafos](paragraph_to_image_input.png)

O exemplo a seguir renderiza o segundo parágrafo em uma forma de texto regular na escala padrão e salva a imagem retornada em formato PNG:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None and shape.text_frame.paragraphs.count > 1:
        paragraph = shape.text_frame.paragraphs[1]
        paragraph_image = paragraph.get_image()

        if paragraph_image is not None:
            with paragraph_image:
                paragraph_image.save("paragraph.png", slides.ImageFormat.PNG)
        else:
            print("The paragraph could not be rendered.")
    else:
        print("The expected text shape or paragraph was not found.")
```

O resultado:

![A imagem do parágrafo](paragraph_to_image_output.png)

#### **Renderizar um parágrafo em uma célula de tabela com escala**

Passe fatores de escala horizontal e vertical para `get_image` para controlar o tamanho do parágrafo renderizado. O exemplo a seguir cria uma tabela, renderiza o parágrafo em sua primeira célula com duas vezes sua largura e altura padrão e salva o resultado como imagem PNG:

```python
import aspose.slides as slides

scale_x = 2
scale_y = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(50, 50, [300], [80])
    paragraph = table.rows[0][0].text_frame.paragraphs[0]
    paragraph.text = "Text in a table cell"

    paragraph_image = paragraph.get_image(scale_x, scale_y)
    if paragraph_image is not None:
        with paragraph_image:
            paragraph_image.save("table_paragraph.png", slides.ImageFormat.PNG)
    else:
        print("The paragraph could not be rendered.")
```

Um fator de escala `1` mantém esse eixo em seu tamanho de pixel padrão. Por exemplo, `2` para ambos os fatores produz uma imagem cuja largura e altura são aproximadamente duas vezes as dimensões padrão, resultando em quatro vezes mais pixels. Fatores maiores geralmente produzem texto mais nítido para zoom ou saída de alta resolução, mas também aumentam o uso de memória e o tamanho do arquivo. Fatores abaixo de `1` produzem imagens menores com menos detalhes. Use fatores iguais para preservar a proporção do parágrafo; fatores horizontais e verticais diferentes esticam a saída independentemente.

Renderizar uma forma inteira com [Shape.get_image](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/get_image/) continua útil quando a saída deve incluir o preenchimento, borda ou outro contexto visual da forma. Para uma imagem apenas do parágrafo, use `Paragraph.get_image`.

## **FAQ**

**Posso desativar completamente a quebra de linha dentro de um quadro de texto?**

Sim. Defina [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframeformat/wrap_text/) para desativar a quebra, de modo que as linhas não se interrompam nas bordas do quadro de texto.

**Como posso obter os limites exatos no slide de um parágrafo específico?**

Use [Paragraph.get_rect](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraph/get_rect/) para recuperar o retângulo delimitador do parágrafo. [Portion.get_rect](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portion/get_rect/) fornece os limites de uma porção individual.

**Onde o alinhamento do parágrafo (esquerda, direita, centro ou justificado) é controlado?**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/alignment/) é uma configuração de nível de parágrafo e se aplica a todo o parágrafo independentemente da formatação de porções individuais.

**Posso definir o idioma de revisão para parte de um parágrafo?**

Sim. Defina [PortionFormat.language_id](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portionformat/language_id/) para porções individuais, de modo que um parágrafo possa conter texto em vários idiomas.