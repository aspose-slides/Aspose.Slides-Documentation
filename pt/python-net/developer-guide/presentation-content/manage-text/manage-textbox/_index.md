---
title: Gerenciar Caixas de Texto em Apresentações com Python
linktitle: Gerenciar Caixa de Texto
type: docs
weight: 20
url: /pt/python-net/manage-textbox/
keywords:
- caixa de texto
- quadro de texto
- adicionar texto
- atualizar texto
- criar caixa de texto
- verificar caixa de texto
- adicionar coluna de texto
- adicionar hiperlink
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Aspose.Slides para Python via .NET facilita a criação, edição e clonagem de caixas de texto em arquivos PowerPoint e OpenDocument, aprimorando a automação de suas apresentações."
---
## **Introdução**

Os textos nos slides tipicamente existem em caixas de texto ou formas. Portanto, para adicionar um texto a um slide, você deve adicionar uma caixa de texto e então colocar algum texto dentro da caixa de texto. Aspose.Slides for Python fornece a classe [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) que permite adicionar uma forma contendo algum texto.

{{% alert title="Informação" color="info" %}}
Aspose.Slides também fornece a classe [Shape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/). Entretanto, nem todas as formas podem conter texto.
{{% /alert %}}

{{% alert title="Observação" color="warning" %}}
Portanto, ao lidar com uma forma à qual você deseja adicionar texto, pode ser necessário verificar e confirmar que ela foi convertida pela classe [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/). Só então você poderá trabalhar com [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/), que é uma propriedade da classe [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/). Consulte a seção [Update Text](/slides/pt/python-net/manage-textbox/#update-text) nesta página.
{{% /alert %}}

## **Criar Caixas de Texto em Slides**

Para criar uma caixa de texto em um slide:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Obtenha uma referência ao primeiro slide.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) com `ShapeType.RECTANGLE` na posição desejada do slide.
4. Defina o texto no [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/) da forma.
5. Salve a apresentação como um arquivo PPTX.

O exemplo Python a seguir implementa estas etapas:

```py
import aspose.slides as slides

# Instanciar a classe Presentation.
with slides.Presentation() as presentation:

    # Obter o primeiro slide da apresentação.
    slide = presentation.slides[0]

    # Adicionar um AutoShape do tipo RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # Salvar a apresentação no disco.
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **Verificar se uma Forma é uma Caixa de Texto**

Aspose.Slides fornece a propriedade [is_text_box](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/is_text_box/) na classe [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/), que permite determinar se uma forma é uma caixa de texto.

![Caixa de texto e forma](istextbox.png)

Este exemplo Python mostra como verificar se uma forma foi criada como caixa de texto:

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```

Observe que, se você adicionar um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) usando a classe [ShapeCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shapecollection/), a propriedade `is_text_box` da forma devolve `False`. Contudo, depois de adicionar texto — seja com o método `add_text_frame` ou definindo a propriedade `text` — `is_text_box` devolve `True`.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    # shape1.is_text_box é falso
    shape1.add_text_frame("shape 1")
    # shape1.is_text_box é verdadeiro

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 110, 100, 40)
    # shape2.is_text_box é falso
    shape2.text_frame.text = "shape 2"
    # shape2.is_text_box é verdadeiro

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 210, 100, 40)
    # shape3.is_text_box é falso
    shape3.add_text_frame("")
    # shape3.is_text_box é falso

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 100, 40)
    # shape4.is_text_box é falso
    shape4.text_frame.text = ""
    # shape4.is_text_box é falso
```

## **Adicionar Colunas a Caixas de Texto**

Aspose.Slides fornece as propriedades [column_count](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframeformat/column_count/) e [column_spacing](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframeformat/column_spacing/) na classe [TextFrameFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframeformat/) para adicionar colunas a caixas de texto. Você pode especificar o número de colunas e definir o espaçamento (em pontos) entre elas.

O código Python a seguir demonstra esta operação:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# Obter o primeiro slide da apresentação.
	slide = presentation.slides[0]

	# Adicionar um AutoShape do tipo RECTANGLE.
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# Adicionar um TextFrame ao retângulo.
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# Obter o formato de texto do TextFrame.
	format = shape.text_frame.text_frame_format

	# Especificar o número de colunas no TextFrame.
	format.column_count = 3

	# Especificar o espaçamento entre colunas.
	format.column_spacing = 10

	# Salvar a apresentação.
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **Atualizar Texto**

Aspose.Slides permite atualizar o texto em uma única caixa de texto ou em toda a apresentação.

O exemplo Python a seguir demonstra como atualizar todo o texto em uma apresentação:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = 1
  
    # Salvar a apresentação modificada.
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **Adicionar Caixas de Texto com Hiperlinks**

Você pode inserir um link em uma caixa de texto. Quando a caixa de texto for clicada, o link será aberto.

Para adicionar uma caixa de texto que contenha um hiperlink, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Obtenha uma referência ao primeiro slide.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) com `ShapeType.RECTANGLE` na posição desejada do slide.
4. Defina o texto no [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/) da forma.
5. Obtenha uma referência ao [HyperlinkManager](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlinkmanager/).
6. Use a propriedade `hyperlink_manager` para definir um hiperlink de clique externo.
7. Salve a apresentação como um arquivo PPTX.

Este exemplo Python mostra como adicionar uma caixa de texto com hiperlink a um slide:

```py
import aspose.slides as slides

# Instanciar a classe Presentation.
with slides.Presentation() as presentation:

    # Obter o primeiro slide da apresentação.
    slide = presentation.slides[0]

    # Adicionar um AutoShape do tipo RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # Adicionar texto ao quadro.
    text_portion.text = "Aspose.Slides"

    # Definir um hyperlink para o texto da porção.
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # Salvar a apresentação como um arquivo PPTX.
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **Perguntas Frequentes**

**Qual é a diferença entre uma caixa de texto e um placeholder de texto ao trabalhar com slides mestres?**

Um [placeholder](/slides/pt/python-net/manage-placeholder/) herda estilo/posição do [master](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masterslide/) e pode ser sobrescrito em [layouts](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutslide/), enquanto uma caixa de texto regular é um objeto independente em um slide específico e não muda quando você troca de layout.

**Como posso realizar uma substituição em massa de texto em toda a apresentação sem alterar texto dentro de gráficos, tabelas e SmartArt?**

Limite sua iteração a auto‑shapes que possuam quadros de texto e exclua objetos incorporados ([charts](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/pt/python-net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/pt/python-net/aspose.slides.smartart/smartart/)) percorrendo suas coleções separadamente ou ignorando esses tipos de objeto.