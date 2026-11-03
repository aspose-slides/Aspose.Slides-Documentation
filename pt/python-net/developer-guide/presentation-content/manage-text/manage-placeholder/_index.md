---
title: Gerenciar placeholders de apresentação no Python
linktitle: Gerenciar placeholders
type: docs
weight: 10
url: /pt/python-net/manage-placeholder/
keywords:
- marcador
- marcador de texto
- marcador de imagem
- marcador de gráfico
- marcador de conteúdo
- texto de sugestão
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Aprenda a inspecionar e editar placeholders de texto, imagem, gráfico e conteúdo e a entender a herança de placeholders com Aspose.Slides para Python via .NET."
---
## **Visão geral**

Um placeholder é uma forma que reserva uma posição para um tipo específico de conteúdo em um modelo de apresentação. Exemplos comuns são placeholder de título, corpo, imagem, gráfico e placeholders de conteúdo de uso geral. Ao contrário de uma forma comum, um placeholder pode herdar sua posição, tamanho, formatação e outras configurações de um slide de layout ou slide mestre.

Aspose.Slides expõe informações de placeholder através da propriedade [Shape.placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/). A propriedade retorna um objeto [Placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/) ou `None` para uma forma normal. Use [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) para determinar o que o placeholder deve conter.

A classe da forma ainda importa depois de conhecer o tipo de placeholder:

- Um placeholder vazio de texto, imagem, gráfico ou conteúdo é comumente representado por um [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
- Um placeholder de imagem preenchido pode ser representado por um [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/).
- Um placeholder de gráfico preenchido pode ser representado por um [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/).
- Um placeholder de conteúdo pode conter vários tipos de conteúdo. Verifique tanto [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) quanto a classe da forma em tempo de execução em vez de assumir que todo placeholder é um [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
O [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) descreve o papel de um placeholder; ele não garante a classe em tempo de execução da forma. Sempre use uma verificação de tipo antes de acessar membros específicos de texto, imagem, gráfico, tabela ou mídia.
{{% /alert %}}

## **Compreender a herança de placeholders**

Os placeholders formam uma hierarquia:

1. Um slide mestre define estilos reutilizáveis e, em alguns casos, placeholders de nível mestre.
2. Um slide de layout define o arranjo usado por um ou mais slides normais e pode herdar do mestre.
3. Um slide normal contém os placeholders desse slide e pode herdar de seu layout.

Chame [Shape.get_base_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_base_placeholder/) para subir um nível nessa hierarquia. Um placeholder de slide normalmente retorna seu placeholder de layout; um placeholder de layout pode retornar seu placeholder mestre. O método retorna `None` quando a forma não tem placeholder base.

O exemplo a seguir lista os placeholders no primeiro slide e relata seus placeholders base:

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

Editar um placeholder em um slide normal cria ou altera uma sobrescrita local para esse slide. Editar o layout ou mestre relacionado pode afetar todos os slides que ainda herdarem essa configuração. Uma forma ordinária local não tem placeholder base e não começa a herdar apenas porque ocupa as mesmas coordenadas.

## **Remover o status de placeholder**

Ao adaptar um modelo, use [Shape.remove_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/remove_placeholder/) para manter um objeto existente como uma forma comum. Sua propriedade [placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) torna‑se `None`, mas a forma permanece na coleção do slide. Em contraste, [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/) exclui a forma dessa coleção.

O exemplo a seguir requer `template.pptx` com ao menos um slide e um placeholder de texto não vazio no primeiro slide. Use um placeholder com formatação herdada do layout ou mestre para ver o efeito de remover esse relacionamento. O exemplo verifica se a mesma forma permanece, chama o método novamente na forma agora comum e salva o resultado.

{{% alert color="warning" title="Warning" %}}
Remover o status de placeholder não preserva automaticamente as configurações de aparência herdadas. O exemplo abaixo deixa deliberadamente essas configurações inalteradas, portanto a saída pode parecer diferente. Uma forma cuja posição e tamanho são totalmente herdados pode ficar com coordenadas e dimensões zero após a chamada e tornar‑se invisível, embora permaneça na coleção.
{{% /alert %}}

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    found = False

    for index in range(len(slide.shapes)):
        shape = slide.shapes[index]
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue
        if shape.text_frame is None or not shape.text_frame.text:
            continue

        shape_count = len(slide.shapes)
        shape.remove_placeholder()

        print(f"Placeholder removed: {shape.placeholder is None}")
        print(f"Same shape retained: {slide.shapes[index] == shape}")
        print(f"Shape count unchanged: {len(slide.shapes) == shape_count}")

        # Chamar o método em uma forma comum não tem efeito.
        shape.remove_placeholder()
        found = True
        break

    if found:
        presentation.save("placeholder-status-removed.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("No nonempty text placeholder was found on the first slide.")
```

Para um placeholder correspondente, as três verificações imprimem `True`. O texto permanece, mas posição, tamanho, rotação, fonte, alinhamento de parágrafo, margens do quadro de texto, ancoragem vertical, preenchimento e configurações de linha herdadas podem mudar quando o relacionamento de placeholder é removido. Por exemplo, a formatação herdada de título pode voltar à formatação de texto comum. Veja [Layout de Slide](/slides/pt/python-net/slide-layout/) para mais informações sobre layouts.

Para preservar a aparência desejada, capture a posição, tamanho e rotação resolvidos antes da chamada e copie os valores de formatação efetiva necessários em variáveis separadas. Recupere esses valores através de [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/), [ParagraphFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/get_effective/), [TextFrameFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/get_effective/), [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/) e [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/). Não confie apenas nos objetos de formatação efetiva, pois seus valores de formatação de texto podem mudar após a remoção do relacionamento. Aplique explicitamente os valores capturados à forma comum depois, incluindo família, tamanho, estilo e cor da fonte, configurações de parágrafo, configurações do quadro de texto, preenchimento e linha usados pelo seu modelo.

A geometria da forma herdada pode precisar ser atribuída explicitamente através de [GeometryShape.shape_type](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/shape_type/). Para um placeholder de texto retangular, isso significa atribuir [ShapeType.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/); restaurar apenas o preenchimento e a linha pode não restaurar o retângulo visível. Modelos com efeitos adicionais ou formatação mais complexa exigem que essas configurações também sejam tratadas.

## **Alterar texto em um placeholder**

Placeholders de título, título centralizado, subtítulo, corpo e texto normalmente suportam texto. Verifique se é um [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) antes de usar sua propriedade [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/).

Este exemplo atualiza o primeiro placeholder de título no primeiro slide e salva o resultado:

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

Esse padrão evita tratar placeholders de imagem, gráfico, tabela ou mídia como objetos [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). Também identifica o placeholder por finalidade em vez de depender de um índice de forma frágil.

## **Definir texto de sugestão em um layout**

O texto de sugestão é a instrução exibida em tempo de design em um placeholder vazio, como *Clique para adicionar título*. Defina texto de sugestão personalizado no placeholder do layout em vez de tentar alcançá‑lo através da coleção de formas de um slide normal. Acesse o layout por meio de [Slide.layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) e itere sobre [LayoutSlide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/).

O exemplo a seguir altera as sugestões de título e subtítulo no layout usado pelo primeiro slide:

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

Texto de sugestão não é conteúdo de slide normal. Destina‑se a placeholders vazios em aplicativos de edição como o PowerPoint. Quando um usuário ou programa fornece conteúdo real, a sugestão deixa de ser exibida. Alterar a sugestão também não substitui texto existente em slides que utilizam o layout.

## **Atualizar um placeholder de imagem**

Existem dois casos a serem tratados:

- Se o placeholder de imagem já estiver preenchido e representado por um [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/), substitua a imagem através de [PictureFillFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture/) e [Picture.image](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image/).
- Se ainda for um placeholder vazio, adicione um quadro de imagem nas coordenadas do placeholder com [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) e remova o placeholder vazio.

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

A substituição criada para um placeholder vazio é um quadro de imagem local, não um novo placeholder, porque [Shape.placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) é somente leitura. Ele mantém a posição reservada, mas não herda mais o comportamento específico de placeholder. Se manter o relacionamento de placeholder for essencial, prepare e preencha o placeholder no PowerPoint primeiro, então atualize o [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) resultante com Aspose.Slides.

Para transparência de imagem, recorte e outros efeitos específicos de imagem, veja [Gerenciar quadros de imagem](/slides/pt/python-net/picture-frame/). Essas operações pertencem ao quadro de imagem ou ao preenchimento da imagem, não aos metadados do placeholder.

## **Trabalhar com placeholders de gráfico e de conteúdo**

Um placeholder de gráfico preenchido pode ser representado por um [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/). Este exemplo encontra tal gráfico tanto pelo tipo de placeholder quanto pela classe em tempo de execução, altera seu título e salva o arquivo:

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

Um placeholder de conteúdo geral costuma ter [PlaceholderType.OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/). No PowerPoint ele funciona como um lançador para vários tipos de conteúdo, incluindo gráficos, tabelas, diagramas, imagens e mídia. Após ser preenchido, inspecione a classe real da forma para descobrir o que contém. Layouts especializados também podem expor [PlaceholderType.CHART](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.TABLE](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.MEDIA](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), ou [PlaceholderType.DIAGRAM](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/).

Aspose.Slides não converte um placeholder vazio de [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) em um [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) apenas alterando [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/); o tipo é somente leitura. Para preencher programaticamente uma área de gráfico ou conteúdo vazia, adicione o objeto necessário nas coordenadas do placeholder e então remova o placeholder vazio. O exemplo a seguir faz isso para um gráfico:

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

O gráfico adicionado é um gráfico local comum. Ele ocupa a área do placeholder, mas não herda do placeholder do layout. Use os [artigos de gerenciamento de gráficos](/slides/pt/python-net/powerpoint-charts/) quando precisar substituir categorias, séries ou dados da pasta de trabalho.

## **Exemplo completo: atualizar conteúdo de texto ou imagem**

O exemplo completo a seguir abre um modelo, procura no primeiro slide por um placeholder de título ou de imagem, verifica os tipos de placeholder e de forma, atualiza o conteúdo apropriado e salva o resultado. O exemplo evita deliberadamente assumir um índice de forma ou tratar todo placeholder como a mesma classe de forma.

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

## **Perguntas frequentes**

**O que é um placeholder base?**

Um placeholder base é a forma correspondente no layout ou mestre da qual outro placeholder herda. Use [Shape.get_base_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_base_placeholder/) para recuperá‑lo. Uma forma local comum retorna `None` porque não faz parte da hierarquia de placeholders.

**Posso mudar todos os títulos dos slides editando um placeholder de layout?**

Você pode mudar a formatação ou o texto de sugestão herdados através de um layout, mas o conteúdo real do título já está armazenado nos slides normais. Para substituir o texto do título em toda a apresentação, itere sobre os slides e atualize cada placeholder de título.

**Como administro placeholders de data, número do slide, cabeçalho e rodapé?**

Use os gerenciadores de cabeçalho e rodapé no escopo adequado de slide, layout, mestre, notas ou folhetos. Veja [Gerenciar cabeçalho e rodapé da apresentação](/slides/pt/python-net/presentation-header-and-footer/) para exemplos completos.