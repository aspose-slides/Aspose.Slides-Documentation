---
title: Gerenciar Parágrafos de Texto do PowerPoint em Python
linktitle: Gerenciar Parágrafo
type: docs
weight: 40
url: /pt/python-net/manage-paragraph/
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
description: "Domine a formatação de parágrafos com Aspose.Slides para Python via .NET — otimize alinhamento, espaçamento e estilo em apresentações PowerPoint e OpenDocument em Python para envolver os espectadores."
---
## **Introdução**

Aspose.Slides fornece as classes necessárias para trabalhar com texto do PowerPoint em Python.

* Aspose.Slides fornece a classe [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/) para criar objetos de quadro de texto. Um objeto `TextFrame` pode conter um ou mais parágrafos (cada parágrafo é separado por uma quebra de linha).
* Aspose.Slides fornece a classe [Paragraph](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraph/) para criar objetos de parágrafo. Um objeto `Paragraph` pode conter uma ou mais partes de texto.
* Aspose.Slides fornece a classe [Portion](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portion/) para criar objetos de parte de texto e especificar suas propriedades de formatação.

Um objeto `Paragraph` pode manipular texto com diferentes propriedades de formatação por meio de seus objetos subjacentes `Portion`.

## **Adicionar Vários Parágrafos Contendo Várias Partes**

Estas etapas mostram como adicionar um quadro de texto que contém três parágrafos, cada um com três partes:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Obtenha uma referência ao slide de destino pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) retangular ao slide.
1. Recupere o [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/) associado ao [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/).
1. Crie dois objetos [Paragraph](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraph/) e adicione-os à coleção de parágrafos do [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/) (juntamente com o parágrafo padrão, isso resulta em três parágrafos).
1. Para cada parágrafo, crie três objetos [Portion](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portion/) e adicione-os à coleção de partes desse parágrafo.
1. Defina o texto para cada parte.
1. Aplique a formatação desejada a cada parte de texto usando as propriedades expostas por [Portion](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portion/).
1. Salve a apresentação modificada.

The following Python code implements these steps:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar a classe Presentation para criar um novo arquivo PPTX.
with slides.Presentation() as presentation:

    # Acessar o primeiro slide.
    slide = presentation.slides[0]

    # Adicionar um AutoShape retangular.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # Acessar o TextFrame do AutoShape.
    text_frame = shape.text_frame

    # Criar parágrafos e partes; a formatação é aplicada abaixo.
    paragraph0 = text_frame.paragraphs[0]
    portion01 = slides.Portion()
    portion02 = slides.Portion()
    paragraph0.portions.add(portion01)
    paragraph0.portions.add(portion02)

    paragraph1 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph1)
    portion10 = slides.Portion()
    portion11 = slides.Portion()
    portion12 = slides.Portion()
    paragraph1.portions.add(portion10)
    paragraph1.portions.add(portion11)
    paragraph1.portions.add(portion12)

    paragraph2 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph2)
    portion20 = slides.Portion()
    portion21 = slides.Portion()
    portion22 = slides.Portion()
    paragraph2.portions.add(portion20)
    paragraph2.portions.add(portion21)
    paragraph2.portions.add(portion22)

    for i in range(3):
        for j in range(3):
            text_frame.paragraphs[i].portions[j].text = "Portion0" + str(j)
            if j == 0:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.red
                text_frame.paragraphs[i].portions[j].portion_format.font_bold = 1
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 15
            elif j == 1:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                text_frame.paragraphs[i].portions[j].portion_format.font_italic = 1
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 18

    # Salvar o PPTX no disco.
    presentation.save("paragraphs_and_portions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Gerenciar Marcadores de Parágrafo**

Listas de marcadores ajudam a organizar e apresentar informações de forma rápida e eficiente. Parágrafos com marcadores são frequentemente mais fáceis de ler e entender.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Acesse o slide de destino pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) ao slide.
1. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/) da forma.
1. Remova o parágrafo padrão do [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/).
1. Crie o primeiro parágrafo usando a classe [Paragraph](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraph/).
1. Defina o tipo de marcador do parágrafo como `SYMBOL` e especifique o caractere do marcador.
1. Defina o texto do parágrafo.
1. Defina a indentação do marcador para o parágrafo.
1. Defina a cor do marcador.
1. Defina o tamanho (altura) do marcador.
1. Adicione o parágrafo à coleção de parágrafos do [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/)​.
1. Adicione um segundo parágrafo e repita as etapas 7–12.
1. Salve a apresentação.

This Python code shows how to add bulleted paragraphs:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Create a presentation instance.
with slides.Presentation() as presentation:

    # Access the first slide.
    slide = presentation.slides[0]

    # Add and access an AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Access the text frame of the created AutoShape.
    text_frame = shape.text_frame

    # Remove the default paragraph.
    text_frame.paragraphs.remove_at(0)

    # Create a paragraph.
    paragraph = slides.Paragraph()

    # Set the paragraph's bullet style and symbol.
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = chr(8226)

    # Set the paragraph text.
    paragraph.text = "Welcome to Aspose.Slides"

    # Set the bullet indent.
    paragraph.paragraph_format.indent = 25

    # Set the bullet color.
    paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph.paragraph_format.bullet.color.color = draw.Color.black
    paragraph.paragraph_format.bullet.is_bullet_hard_color = 1 

    # Set the bullet height.
    paragraph.paragraph_format.bullet.height = 100

    # Add the paragraph to the text frame.
    text_frame.paragraphs.add(paragraph)

    # Create the second paragraph.
    paragraph2 = slides.Paragraph()

    # Set the paragraph's bullet type and style.
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WDBLACK_PLAIN

    # Set the paragraph text.
    paragraph2.text = "This is numbered bullet"

    # Set the bullet indent.
    paragraph2.paragraph_format.indent = 25

    # Set the bullet color.
    paragraph2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph2.paragraph_format.bullet.color.color = draw.Color.black
    paragraph2.paragraph_format.bullet.is_bullet_hard_color = 1

    # Set the bullet height.
    paragraph2.paragraph_format.bullet.height = 100

    # Add the paragraph to the text frame.
    text_frame.paragraphs.add(paragraph2)

    # Save the presentation as a PPTX file.
    presentation.save("bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Gerenciar Marcadores de Imagem**

Listas com marcadores ajudam a organizar e apresentar informações de forma rápida e eficiente. Marcadores de imagem são fáceis de ler e entender.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Acesse o slide de destino pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) ao slide.
1. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/) da forma.
1. Remova o parágrafo padrão do [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/).
1. Crie o primeiro parágrafo usando a classe [Paragraph](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraph/).
1. Carregue uma imagem em um [PPImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ppimage/).
1. Defina o tipo de marcador como [PPImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ppimage/) e atribua a imagem.
1. Defina o texto do parágrafo.
1. Defina a indentação do parágrafo para o marcador.
1. Defina a cor do marcador.
1. Defina a altura do marcador.
1. Adicione o novo parágrafo à coleção de parágrafos do [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/)​.
1. Adicione um segundo parágrafo e repita as etapas 8–12.
1. Salve a apresentação.

This Python code shows how to add and manage picture bullets:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # Acesse o primeiro slide.
    slide = presentation.slides[0]

    # Carregue a imagem do marcador.
    image = draw.Bitmap("bullets.png")
    pp_image = presentation.images.add_image(image)

    # Adicione e acesse um AutoShape.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Acesse o TextFrame do AutoShape criado.
    text_frame = auto_shape.text_frame

    # Remova o parágrafo padrão.
    text_frame.paragraphs.remove_at(0)

    # Crie um novo parágrafo.
    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"

    # Defina o tipo de marcador do parágrafo como Imagem e atribua a imagem.
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = pp_image

    # Defina a altura do marcador.
    paragraph.paragraph_format.bullet.height = 100

    # Adicione o parágrafo ao TextFrame.
    text_frame.paragraphs.add(paragraph)

    # Salve a apresentação como um arquivo PPTX.
    presentation.save("picture_bullets_out.pptx", slides.export.SaveFormat.PPTX)
    # Salve a apresentação como um arquivo PPT.
    presentation.save("picture_bullets_out.ppt", slides.export.SaveFormat.PPT)
```

## **Gerenciar Marcadores Multinível**

Listas de marcadores ajudam a organizar e apresentar informações de forma rápida e eficiente. Marcadores multinível são fáceis de ler e entender.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Acesse o slide de destino.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) ao slide.
1. Acesse o [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/)'s [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/).
1. Remova o parágrafo padrão do [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/).
1. Crie o primeiro parágrafo usando a classe [Paragraph](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraph/) e defina sua profundidade como 0.
1. Crie o segundo parágrafo usando a classe [Paragraph](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraph/) e defina sua profundidade como 1.
1. Crie o terceiro parágrafo usando a classe [Paragraph](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraph/) e defina sua profundidade como 2.
1. Crie o quarto parágrafo usando a classe [Paragraph](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraph/) e defina sua profundidade como 3.
1. Adicione os novos parágrafos à coleção de parágrafos do [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/)​.
1. Salve a apresentação.

The following Python code shows how to add and manage multilevel bullets:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Criar uma instância de apresentação.
with slides.Presentation() as presentation:

    # Acessar o primeiro slide.
    slide = presentation.slides[0]
    
    # Adicionar um AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Acessar o TextFrame do AutoShape criado.
    text_frame = auto_shape.text_frame
    
    # Limpar o parágrafo padrão.
    text_frame.paragraphs.clear()

    # Adicionar o primeiro parágrafo.
    paragraph1 = slides.Paragraph()
    paragraph1.text = "Content"
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Definir o nível do marcador.
    paragraph1.paragraph_format.depth = 0

    # Adicionar o segundo parágrafo.
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Second Level"
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = '-'
    paragraph2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Definir o nível do marcador.
    paragraph2.paragraph_format.depth = 1

    # Adicionar o terceiro parágrafo.
    paragraph3 = slides.Paragraph()
    paragraph3.text = "Third Level"
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Definir o nível do marcador.
    paragraph3.paragraph_format.depth = 2

    # Adicionar o quarto parágrafo.
    paragraph4 = slides.Paragraph()
    paragraph4.text = "Fourth Level"
    paragraph4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph4.paragraph_format.bullet.char = '-'
    paragraph4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Definir o nível do marcador.
    paragraph4.paragraph_format.depth = 3

    # Adicionar os parágrafos à coleção.
    text_frame.paragraphs.add(paragraph1)
    text_frame.paragraphs.add(paragraph2)
    text_frame.paragraphs.add(paragraph3)
    text_frame.paragraphs.add(paragraph4)

    # Salvar a apresentação como um arquivo PPTX.
    presentation.save("multilevel_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Gerenciar Parágrafos com Listas Numeradas Personalizadas**

A classe [BulletFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/bulletformat/) fornece a propriedade `numbered_bullet_start_with` (e outras) para controlar a numeração personalizada e a formatação de parágrafos.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Acesse o slide que conterá os parágrafos.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) ao slide.
1. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/) da forma.
1. Remova o parágrafo padrão do [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/).
1. Crie o primeiro [Paragraph](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraph/) e defina `numbered_bullet_start_with` como 2.
1. Crie o segundo [Paragraph](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraph/) e defina `numbered_bullet_start_with` como 3.
1. Crie o terceiro [Paragraph](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraph/) e defina `numbered_bullet_start_with` como 7.
1. Adicione os parágrafos à coleção do [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/)​.
1. Salve a apresentação.

The following Python code demonstrates how to add and manage paragraphs with custom numbering and formatting.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # Adicionar e acessar um AutoShape.
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Acessar o TextFrame do AutoShape criado.
    text_frame = shape.text_frame

    # Remover o parágrafo padrão existente.
    text_frame.paragraphs.remove_at(0)

    # Criar o primeiro item numerado (iniciar em 2, nível de profundidade 4).
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph1)

    # Criar o segundo item numerado (iniciar em 3, nível de profundidade 4).
    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    text_frame.paragraphs.add(paragraph2)

    # Criar o terceiro item numerado (iniciar em 7, nível de profundidade 4).
    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph5)

    presentation.save("custom_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir Recuo da Primeira Linha para um Parágrafo**

Use a propriedade [ParagraphFormat.indent](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/indent/) para controlar o recuo da primeira linha de um parágrafo. Essa propriedade move apenas a primeira linha em relação à margem esquerda do parágrafo. Um valor positivo desloca a primeira linha para a direita, enquanto as linhas restantes permanecem alinhadas ao corpo do parágrafo.

Use [ParagraphFormat.margin_left](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/margin_left/) quando precisar mover todo o parágrafo. Use [ParagraphFormat.indent](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/indent/) quando precisar mover apenas a primeira linha.

O exemplo abaixo cria vários parágrafos e aplica diferentes valores de `indent` para demonstrar como o recuo da primeira linha afeta o layout do parágrafo.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Acesse o slide de destino.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) retangular ao slide.
4. Adicione um [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/) vazio à forma e remova o parágrafo padrão.
5. Crie vários parágrafos e defina diferentes valores de [indent](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/indent/) para eles.
6. Adicione os parágrafos ao quadro de texto.
7. Salve a apresentação modificada.

This code shows you how to set a paragraph indent:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.margin_left = 20.0
    first_paragraph.paragraph_format.indent = 0.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.margin_left = 20.0
    second_paragraph.paragraph_format.indent = 20.0

    third_paragraph = slides.Paragraph()
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.margin_left = 20.0
    third_paragraph.paragraph_format.indent = 40.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

The result:

![O recuo da primeira linha dos parágrafos](first_line_indent.png)

## **Definir Recuo Suspenso para um Parágrafo**

Um recuo suspenso é um layout de parágrafo em que a primeira linha começa à esquerda das linhas restantes. No Aspose.Slides, você cria esse efeito com a propriedade [ParagraphFormat.indent](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/indent/). Defina `indent` como um valor negativo para mover a primeira linha para a esquerda em relação ao corpo do parágrafo.

Na prática, [ParagraphFormat.margin_left](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/margin_left/) define a posição esquerda do corpo do parágrafo, e [ParagraphFormat.indent](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/indent/) define a posição da primeira linha em relação a essa margem. Para criar um recuo suspenso, defina um valor positivo em `margin_left` e um valor negativo em `indent`.

Essa formatação é útil para bibliografias, referências, entradas de glossário e outros parágrafos onde linhas envolvidas devem alinhar-se sob o corpo do parágrafo em vez de sob o primeiro caractere da primeira linha.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Acesse o slide de destino.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) retangular ao slide.
4. Adicione um [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/) vazio à forma e remova o parágrafo padrão.
5. Crie parágrafos e defina um valor positivo de [margin_left](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/margin_left/) para cada parágrafo.
6. Defina um valor negativo de [indent](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/indent/) para criar o efeito de recuo suspenso.
7. Adicione os parágrafos ao quadro de texto.
8. Salve a apresentação modificada.

This code shows you how to set a hanging indent for a paragraph:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.margin_left = 40.0
    first_paragraph.paragraph_format.indent = -20.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.margin_left = 60.0
    second_paragraph.paragraph_format.indent = -30.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

The result:

![O recuo suspenso dos parágrafos](hanging_indent.png)

## **Gerenciar Formato da Parte de Fim de Parágrafo**

Quando precisar controlar o estilo do “fim” de um parágrafo (a formatação aplicada após a última parte de texto), use a propriedade `end_paragraph_portion_format`. O exemplo abaixo aplica uma fonte Times New Roman maior ao final do segundo parágrafo.

1. Crie ou abra um arquivo [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Obtenha o slide de destino pelo índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) retangular ao slide.
1. Use o [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/) da forma e crie dois parágrafos.
1. Crie um [PortionFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portionformat/) configurado para Times New Roman 48 pt e aplique-o como o formato de parte de fim de parágrafo do parágrafo.
1. Atribua‑o à `end_paragraph_portion_format` do parágrafo (aplica‑se ao final do segundo parágrafo).
1. Grave a apresentação modificada como um arquivo PPTX.

This Python code shows you how to set the end‑of‑paragraph formatting for the second paragraph:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
	shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

	paragraph1 = slides.Paragraph()
	paragraph1.portions.add(slides.Portion("Sample text"))

	end_paragraph_portion_format = slides.PortionFormat()
	end_paragraph_portion_format.font_height = 48
	end_paragraph_portion_format.latin_font = slides.FontData("Times New Roman")

	paragraph2 = slides.Paragraph()
	paragraph2.portions.add(slides.Portion("Sample text 2"))
	paragraph2.end_paragraph_portion_format = end_paragraph_portion_format

	shape.text_frame.paragraphs.add(paragraph1)
	shape.text_frame.paragraphs.add(paragraph2)

	presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Importar Texto HTML em Parágrafos**

Aspose.Slides oferece suporte aprimorado para importar texto HTML em parágrafos.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Acesse o slide de destino pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) ao slide.
1. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/) do [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/).
1. Remova o parágrafo padrão do [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/).
1. Leia o arquivo HTML de origem.
1. Crie o primeiro parágrafo usando a classe [Paragraph](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraph/).
1. Adicione o conteúdo HTML à coleção de parágrafos do [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/)​.
1. Salve a apresentação modificada.

The following Python code implements these steps for importing HTML text into paragraphs.

```python
import aspose.slides as slides

# Criar uma instância vazia de Presentation.
with slides.Presentation() as presentation:

    # Acessar o primeiro slide da apresentação.
    slide = presentation.slides[0]

    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    # Adicionar um AutoShape para acomodar o conteúdo HTML.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, slide_width - 20, slide_height - 10)

    # Limpar todos os parágrafos no TextFrame adicionado.
    shape.text_frame.paragraphs.clear()

    # Carregar o arquivo HTML.
    with open("file.html", "rt") as html_stream:
        # Adicionar texto do arquivo HTML ao TextFrame.
        shape.text_frame.paragraphs.add_from_html(html_stream.read())

    # Salvar a apresentação.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Exportar Texto de Parágrafo para HTML**

Aspose.Slides fornece suporte aprimorado para exportar texto para HTML.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) e carregue a apresentação de destino.
1. Acesse o slide desejado pelo seu índice.
1. Selecione a forma que contém o texto a ser exportado.
1. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/) da forma.
1. Abra um fluxo de arquivo para gravar a saída HTML.
1. Especifique o índice inicial e exporte os parágrafos necessários.

This Python example shows how to export paragraph text to HTML.

```python
import aspose.slides as slides

# Carregar o arquivo de apresentação.
with slides.Presentation("exporting_HTML_text.pptx") as presentation:
    # Acessar o primeiro slide da apresentação.
    slide = presentation.slides[0]

    # Índice da forma alvo.
    index = 0

    # Acessar a forma pelo índice.
    shape = slide.shapes[index]

    with open("output.html", "w") as html_stream:
        # Escrever os dados dos parágrafos em HTML fornecendo o índice inicial do parágrafo e o número total de parágrafos a exportar.
        html_stream.write(shape.text_frame.paragraphs.export_to_html(0, shape.text_frame.paragraphs.count, None))
```

## **Salvar um Parágrafo como Imagem**

Nesta seção, exploraremos dois exemplos que demonstram como salvar um parágrafo de texto, representado pela classe [Paragraph](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraph/), como uma imagem. Ambos os exemplos incluem obter a imagem de uma forma que contém o parágrafo usando os métodos `get_image` da classe [Shape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/), calcular os limites do parágrafo dentro da forma e exportá‑lo como uma imagem bitmap. Essas abordagens permitem extrair partes específicas do texto de apresentações PowerPoint e salvá‑las como imagens separadas, o que pode ser útil para uso posterior em vários cenários.

Vamos supor que temos um arquivo de apresentação chamado sample.pptx com um slide, onde a primeira forma é uma caixa de texto contendo três parágrafos.

![A caixa de texto com três parágrafos](paragraph_to_image_input.png)

**Exemplo 1**

Neste exemplo, obtém‑se o segundo parágrafo como uma imagem. Para isso, extraímos a imagem da forma do primeiro slide da apresentação e então calculamos os limites do segundo parágrafo no quadro de texto da forma. O parágrafo é então redesenhado em uma nova imagem bitmap, que é salva no formato PNG. Esse método é especialmente útil quando é necessário salvar um parágrafo específico como uma imagem separada preservando as dimensões e formatação exatas do texto.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Salvar a forma na memória como bitmap.
    with first_shape.get_image() as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Criar um bitmap da forma a partir da memória.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # Calcular os limites do segundo parágrafo.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()

    # Calcular as coordenadas e o tamanho da imagem de saída (tamanho mínimo - 1x1 pixel).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # Recortar o bitmap da forma para obter apenas o bitmap do parágrafo.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

The result:

![A imagem do parágrafo](paragraph_to_image_output.png)

**Exemplo 2**

Neste exemplo, ampliamos a abordagem anterior adicionando fatores de escala à imagem do parágrafo. A forma é extraída da apresentação e salva como imagem com um fator de escala de `2`. Isso permite uma saída de resolução mais alta ao exportar o parágrafo. Os limites do parágrafo são então calculados considerando a escala. A escala pode ser particularmente útil quando é necessária uma imagem mais detalhada, por exemplo, para uso em materiais impressos de alta qualidade.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

image_scale_x = 2
image_scale_y = image_scale_x

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Salvar a forma na memória como bitmap.
    with first_shape.get_image(slides.ShapeThumbnailBounds.SHAPE, image_scale_x, image_scale_y) as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Criar um bitmap da forma a partir da memória.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # Calcular os limites do segundo parágrafo.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()
    paragraph_rectangle.x *= image_scale_x
    paragraph_rectangle.y *= image_scale_y
    paragraph_rectangle.width *= image_scale_x
    paragraph_rectangle.height *= image_scale_y

    # Calcular as coordenadas e o tamanho da imagem de saída (tamanho mínimo - 1x1 pixel).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # Recortar o bitmap da forma para obter apenas o bitmap do parágrafo.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

## **Perguntas Frequentes**

**Posso desativar completamente a quebra automática de linhas dentro de um quadro de texto?**

Sim. Use a configuração de quebra de linha do quadro de texto ([wrap_text](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframeformat/wrap_text/)) para desativar a quebra, de modo que as linhas não se quebrem nas bordas do quadro.

**Como posso obter os limites exatos de um parágrafo específico no slide?**

Você pode recuperar o retângulo delimitador do parágrafo (e até de uma única parte) para conhecer sua posição e tamanho precisos no slide.

**Onde é controlado o alinhamento de parágrafo (esquerda/direita/centro/justificado)?**

[Alignment](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/alignment/) é uma configuração de nível de parágrafo em [ParagraphFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/paragraphformat/); ela se aplica a todo o parágrafo independentemente da formatação de partes individuais.

**Posso definir um idioma de verificação ortográfica para apenas parte de um parágrafo (por exemplo, uma palavra)?**

Sim. O idioma é definido ao nível da parte ([PortionFormat.language_id](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portionformat/language_id/)), permitindo que vários idiomas coexistam em um único parágrafo.