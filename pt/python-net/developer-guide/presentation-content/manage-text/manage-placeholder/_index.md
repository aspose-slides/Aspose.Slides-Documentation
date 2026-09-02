---
title: Gerenciar Espaços Reservados de Apresentação em Python
linktitle: Gerenciar Espaços Reservados
type: docs
weight: 10
url: /pt/python-net/manage-placeholder/
keywords:
- espaço reservado
- espaço reservado de texto
- espaço reservado de imagem
- espaço reservado de gráfico
- espaço reservado de conteúdo
- texto de prompt
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Aprenda a inspecionar e editar espaços reservados de texto, imagem, gráfico e conteúdo e a entender a herança de espaços reservados com Aspose.Slides para Python via .NET."
---
## **Visão geral**

Um espaço reservado é uma forma que reserva uma posição para um tipo específico de conteúdo em um modelo de apresentação. Exemplos comuns são título, corpo, imagem, gráfico e espaços reservados de conteúdo de uso geral. Ao contrário de uma forma comum, um espaço reservado pode herdar sua posição, tamanho, formatação e outras configurações de um slide de layout ou slide mestre.

Aspose.Slides expõe informações de espaço reservado através da propriedade [Shape.placeholder](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/placeholder/). A propriedade devolve um objeto [Placeholder](https://reference.aspose.com/slides/pt/python-net/aspose.slides/placeholder/) ou `None` para uma forma normal. Use [Placeholder.type](https://reference.aspose.com/slides/pt/python-net/aspose.slides/placeholder/type/) para determinar o que o espaço reservado deve conter.

A classe da forma ainda importa depois de conhecer o tipo de espaço reservado:

- Um espaço reservado vazio de texto, imagem, gráfico ou conteúdo costuma ser representado por um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/).
- Um espaço reservado de imagem preenchido pode ser representado por um [PictureFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pictureframe/).
- Um espaço reservado de gráfico preenchido pode ser representado por um [Chart](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chart/).
- Um espaço reservado de conteúdo pode conter vários tipos de conteúdo. Verifique tanto [Placeholder.type](https://reference.aspose.com/slides/pt/python-net/aspose.slides/placeholder/type/) quanto a classe da forma em tempo de execução, em vez de assumir que todo espaço reservado é um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.type](https://reference.aspose.com/slides/pt/python-net/aspose.slides/placeholder/type/) descreve o papel de um espaço reservado; ele não garante a classe da forma em tempo de execução. Sempre faça uma verificação de tipo antes de acessar membros específicos de texto, imagem, gráfico, tabela ou mídia.
{{% /alert %}}

## **Entender a Herança de Espaços Reservados**

Os espaços reservados formam uma hierarquia:

1. Um slide mestre define estilos reutilizáveis e, em alguns casos, espaços reservados de nível mestre.
2. Um slide de layout define o arranjo usado por um ou mais slides normais e pode herdar do mestre.
3. Um slide normal contém os espaços reservados desse slide e pode herdar do seu layout.

Chame [Shape.get_base_placeholder](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/get_base_placeholder/) para subir um nível nessa hierarquia. Um espaço reservado de slide normalmente devolve seu espaço reservado de layout; um espaço reservado de layout pode devolver seu espaço reservado mestre. O método devolve `None` quando a forma não tem espaço reservado base.

O exemplo a seguir lista os espaços reservados no primeiro slide e relata seus espaços reservados base:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        type_name = type(shape).__name__
        print(f"Slide placeholder: {placeholder_type}; shape class: {type_name}")

        layout_placeholder = shape.get_base_placeholder()
        if layout_placeholder is not None:
            layout_placeholder_type = layout_placeholder.placeholder.type if layout_placeholder.placeholder is not None else None
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.get_base_placeholder()
            if master_placeholder is not None:
                master_placeholder_type = master_placeholder.placeholder.type if master_placeholder.placeholder is not None else None
                print(f"  Master placeholder: {master_placeholder_type}")
```

Editar um espaço reservado em um slide normal cria ou altera uma sobrescrita local para esse slide. Editar o layout ou mestre relacionado pode afetar todos os slides que ainda herdarem essa configuração. Uma forma ordinária local não tem espaço reservado base e não começa a herdar apenas porque ocupa as mesmas coordenadas.

## **Alterar Texto em um Espaço Reservado**

Títulos, títulos centralizados, subtítulos, corpo e espaços reservados de texto normalmente suportam texto. Verifique se é um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) antes de usar sua propriedade [text_frame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/text_frame/).

Este exemplo atualiza o primeiro espaço reservado de título no primeiro slide e salva o resultado:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    title_shape = None

    for shape in slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            title_shape = shape
            break

    if title_shape is None:
        raise RuntimeError("The first slide does not contain a title placeholder.")

    title_shape.text_frame.text = "Quarterly Business Review"
    presentation.save("title-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Esse padrão evita tratar espaços reservados de imagem, gráfico, tabela ou mídia como objetos [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/). Ele também identifica o espaço reservado por finalidade em vez de depender de um índice de forma frágil.

## **Definir Texto de Prompt em um Layout**

Texto de prompt é a instrução exibida em tempo de design em um espaço reservado vazio, como *Clique para adicionar título*. Defina um texto de prompt personalizado no espaço reservado do layout em vez de tentar alcançá‑lo através da coleção de formas de um slide normal. Acesse o layout via [Slide.layout_slide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/layout_slide/) e itere sobre [LayoutSlide.shapes](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseslide/shapes/).

O exemplo a seguir altera os prompts de título e subtítulo no layout usado pelo primeiro slide:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    layout_slide = presentation.slides[0].layout_slide

    for shape in layout_slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            shape.text_frame.text = "Enter a concise slide title"
        elif placeholder_type == slides.PlaceholderType.SUBTITLE:
            shape.text_frame.text = "Enter a subtitle or reporting period"

    presentation.save("custom-placeholder-prompts.pptx", slides.export.SaveFormat.PPTX)
```

Texto de prompt não é conteúdo de slide normal. Ele destina‑se a espaços reservados vazios em aplicações de edição como o PowerPoint. Quando um usuário ou programa fornece conteúdo real, o prompt deixa de ser exibido. Alterar um prompt também não substitui o texto existente nos slides que utilizam o layout.

## **Atualizar um Espaço Reservado de Imagem**

Existem dois casos a tratar:

- Se o espaço reservado de imagem já estiver preenchido e representado por um [PictureFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pictureframe/), substitua a imagem através de [PictureFillFormat.picture](https://reference.aspose.com/slides/pt/python-net/aspose.slides/picturefillformat/picture/) e [Picture.image](https://reference.aspose.com/slides/pt/python-net/aspose.slides/picture/image/).
- Se ainda for um espaço reservado vazio, adicione um quadro de imagem nas coordenadas do espaço reservado com [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shapecollection/add_picture_frame/) e remova o espaço reservado vazio.

O próximo exemplo suporta ambos os casos e salva a apresentação:

```python
import aspose.slides as slides

with slides.Presentation("picture-template.pptx") as presentation:
    slide = presentation.slides[0]
    picture_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        raise RuntimeError("The first slide does not contain a picture placeholder.")

    with open("replacement.png", "rb") as image_stream:
        image_bytes = image_stream.read()

    image = presentation.images.add_image(image_bytes)

    if isinstance(picture_placeholder, slides.PictureFrame):
        picture_placeholder.picture_format.picture.image = image
    else:
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, picture_placeholder.x, picture_placeholder.y, picture_placeholder.width, picture_placeholder.height, image)
        slide.shapes.remove(picture_placeholder)

    presentation.save("picture-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

A substituição criada para um espaço reservado vazio é um quadro de imagem local, não um novo espaço reservado, porque [Shape.placeholder](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/placeholder/) é somente leitura. Ele mantém a posição reservada, mas não herda mais o comportamento específico de espaço reservado. Se manter a relação de espaço reservado for essencial, prepare e preencha o espaço reservado no PowerPoint primeiro, então atualize o [PictureFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pictureframe/) resultante com Aspose.Slides.

Para transparência de imagem, recorte e outros efeitos específicos de imagem, veja [Manage Picture Frames](/slides/pt/python-net/picture-frame/). Essas operações pertencem ao quadro de imagem ou ao preenchimento de imagem, não aos metadados do espaço reservado.

## **Trabalhar com Espaços Reservados de Gráfico e Conteúdo**

Um espaço reservado de gráfico preenchido pode ser representado por um [Chart](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chart/). Este exemplo encontra tal gráfico tanto pelo tipo de espaço reservado quanto pela classe em tempo de execução, altera seu título e salva o arquivo:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-template.pptx") as presentation:
    slide = presentation.slides[0]
    placeholder_chart = None

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.CHART:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        raise RuntimeError("The first slide does not contain a populated chart placeholder.")

    placeholder_chart.has_title = True
    placeholder_chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    presentation.save("chart-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Um espaço reservado de conteúdo geral costuma ter [PlaceholderType.OBJECT](https://reference.aspose.com/slides/pt/python-net/aspose.slides/placeholdertype/). No PowerPoint ele funciona como um lançador para vários tipos de conteúdo, incluindo gráficos, tabelas, diagramas, imagens e mídia. Depois de preenchido, inspecione a classe real da forma para saber o que contém. Layouts especializados também podem expor [PlaceholderType.CHART](https://reference.aspose.com/slides/pt/python-net/aspose.slides/placeholdertype/), [PlaceholderType.TABLE](https://reference.aspose.com/slides/pt/python-net/aspose.slides/placeholdertype/), [PlaceholderType.PICTURE](https://reference.aspose.com/slides/pt/python-net/aspose.slides/placeholdertype/), [PlaceholderType.MEDIA](https://reference.aspose.com/slides/pt/python-net/aspose.slides/placeholdertype/), ou [PlaceholderType.DIAGRAM](https://reference.aspose.com/slides/pt/python-net/aspose.slides/placeholdertype/).

Aspose.Slides não converte um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) vazio em um [Chart](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chart/) apenas alterando [Placeholder.type](https://reference.aspose.com/slides/pt/python-net/aspose.slides/placeholder/type/); o tipo é somente leitura. Para preencher programaticamente uma área vazia de gráfico ou conteúdo, adicione o objeto necessário nas coordenadas do espaço reservado e, em seguida, remova o espaço reservado vazio. O exemplo a seguir faz isso para um gráfico:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("content-template.pptx") as presentation:
    slide = presentation.slides[0]
    target_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type in (slides.PlaceholderType.CHART, slides.PlaceholderType.OBJECT):
            target_placeholder = shape
            break

    if target_placeholder is None:
        raise RuntimeError("The first slide does not contain a chart or content placeholder.")

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, target_placeholder.x, target_placeholder.y, target_placeholder.width, target_placeholder.height)
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    slide.shapes.remove(target_placeholder)
    presentation.save("content-placeholder-replaced-with-chart.pptx", slides.export.SaveFormat.PPTX)
```

O gráfico adicionado é um gráfico local ordinário. Ele ocupa a área do espaço reservado, mas não herda do espaço reservado de layout. Use os artigos dedicados de [chart management](/slides/pt/python-net/powerpoint-charts/) quando precisar substituir categorias, séries ou dados da planilha.

## **Exemplo Completo: Atualizar Texto ou Imagem**

O exemplo end‑to‑end a seguir abre um modelo, procura no primeiro slide por um espaço reservado de título ou imagem, verifica os tipos de espaço reservado e de forma, atualiza o conteúdo apropriado e salva a saída. O exemplo evita deliberadamente assumir um índice de forma ou tratar todo espaço reservado como a mesma classe de forma.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    updated = False

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE) and isinstance(shape, slides.AutoShape):
            shape.text_frame.text = "Quarterly Business Review"
            updated = True
            break

        if placeholder_type == slides.PlaceholderType.PICTURE:
            with open("replacement.png", "rb") as image_stream:
                image_bytes = image_stream.read()

            image = presentation.images.add_image(image_bytes)

            if isinstance(shape, slides.PictureFrame):
                shape.picture_format.picture.image = image
            else:
                slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, image)
                slide.shapes.remove(shape)

            updated = True
            break

    if not updated:
        raise RuntimeError("No supported title or picture placeholder was found on the first slide.")

    presentation.save("placeholder-content-updated.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**O que é um espaço reservado base?**

Um espaço reservado base é a forma correspondente no layout ou mestre da qual outro espaço reservado herda. Use [Shape.get_base_placeholder](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/get_base_placeholder/) para recuperá‑lo. Uma forma local ordinária devolve `None` porque não faz parte da hierarquia de espaços reservados.

**Posso mudar todos os títulos dos slides editando um espaço reservado de layout?**

Você pode mudar a formatação ou o texto de prompt herdados através de um layout, mas o conteúdo de título existente está armazenado nos slides normais. Para substituir o texto real do título em toda a apresentação, itere sobre os slides e atualize cada espaço reservado de título.

**Como gerencio espaços reservados de data, número do slide, cabeçalho e rodapé?**

Use os gerenciadores de cabeçalho e rodapé no escopo apropriado de slide, layout, mestre, notas ou folheto. Veja [Manage Presentation Header and Footer](/slides/pt/python-net/presentation-header-and-footer/) para exemplos completos.