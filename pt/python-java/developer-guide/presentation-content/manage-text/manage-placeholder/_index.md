---
title: Gerenciar Placeholders de Apresentação em Python
linktitle: Gerenciar Placeholders
type: docs
weight: 10
url: /pt/python-java/manage-placeholder/
keywords:
- placeholder
- placeholder de texto
- placeholder de imagem
- placeholder de gráfico
- placeholder de conteúdo
- texto de sugestão
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Aprenda a inspecionar e editar placeholders de texto, imagem, gráfico e conteúdo e a entender a herança de placeholders com Aspose.Slides para Python via Java."
---
## **Visão geral**

Um placeholder é uma forma que reserva uma posição para um determinado tipo de conteúdo em um modelo de apresentação. Exemplos comuns são título, corpo, imagem, gráfico e placeholders de conteúdo de uso geral. Ao contrário de uma forma comum, um placeholder pode herdar sua posição, tamanho, formatação e outras configurações de um slide de layout ou do slide mestre.

Aspose.Slides expõe as informações de placeholder por meio do método [Shape.getPlaceholder](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getPlaceholder). O método devolve um objeto [Placeholder](https://reference.aspose.com/slides/pt/python-java/aspose.slides/placeholder/) ou `None` para uma forma normal. Use [Placeholder.getType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/placeholder/#getType) para determinar o que o placeholder se destina a conter.

O tipo da forma ainda importa depois de conhecer o tipo do placeholder:

- Um placeholder vazio de texto, imagem, gráfico ou conteúdo costuma ser representado por um [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/).
- Um placeholder de imagem preenchido pode ser representado por um [PictureFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pictureframe/).
- Um placeholder de gráfico preenchido pode ser representado por um [Chart](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chart/).
- Um placeholder de conteúdo pode conter vários tipos de conteúdo. Verifique tanto [Placeholder.getType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/placeholder/#getType) quanto o tipo de forma em tempo de execução, em vez de assumir que todo placeholder é um [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Aviso" %}}
[Placeholder.getType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/placeholder/#getType) descreve o papel de um placeholder; ele não garante o tipo de forma em tempo de execução. Sempre verifique o tipo antes de acessar membros específicos de texto, imagem, gráfico, tabela ou mídia.
{{% /alert %}}

## **Entender a Herança de Placeholders**

Os placeholders formam uma hierarquia:

1. Um slide mestre define estilos reutilizáveis e, em alguns casos, placeholders de nível mestre.
2. Um slide de layout define o arranjo usado por um ou mais slides normais e pode herdar do mestre.
3. Um slide normal contém os placeholders desse slide e pode herdar do seu layout.

Chame [Shape.getBasePlaceholder](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getBasePlaceholder) para subir um nível nessa hierarquia. Um placeholder de slide normalmente devolve seu placeholder de layout; um placeholder de layout pode devolver seu placeholder mestre. O método devolve `None` quando a forma não possui placeholder base.

O exemplo a seguir lista os placeholders do primeiro slide e relata seus placeholders base:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        type_name = shape.getClass().getSimpleName()
        print(f"Slide placeholder: {placeholder_type}; shape type: {type_name}")

        layout_placeholder = shape.getBasePlaceholder()
        if layout_placeholder is not None:
            layout_placeholder_info = layout_placeholder.getPlaceholder()
            layout_placeholder_type = None if layout_placeholder_info is None else layout_placeholder_info.getType()
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.getBasePlaceholder()
            if master_placeholder is not None:
                master_placeholder_info = master_placeholder.getPlaceholder()
                master_placeholder_type = None if master_placeholder_info is None else master_placeholder_info.getType()
                print(f"  Master placeholder: {master_placeholder_type}")
finally:
    presentation.dispose()
```

Editar um placeholder em um slide normal cria ou altera uma sobrescrita local para esse slide. Editar o layout ou o mestre relacionado pode afetar todos os slides que ainda herdam essa configuração. Uma forma ordinária local não possui placeholder base e não começa a herdar apenas porque ocupa as mesmas coordenadas.

## **Alterar Texto em um Placeholder**

Placeholders de título, título centralizado, subtítulo, corpo e texto normalmente suportam texto. Verifique se é um [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/) antes de usar seu método [getTextFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/#getTextFrame).

Este exemplo atualiza o primeiro placeholder de título no primeiro slide e salva o resultado:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    title_shape = None

    for shape in slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            title_shape = shape
            break

    if title_shape is None:
        print("The first slide does not contain a title placeholder.")
    else:
        title_shape.getTextFrame().setText("Quarterly Business Review")
        presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Esse padrão evita tratar placeholders de imagem, gráfico, tabela ou mídia como [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/). Ele também identifica o placeholder por finalidade em vez de confiar em um índice de forma frágil.

## **Definir Texto de Prompt em um Layout**

O texto de prompt é a instrução exibida em tempo de design em um placeholder vazio, como *Clique para adicionar título*. Defina texto de prompt personalizado no placeholder de layout em vez de tentar acessá‑lo através da coleção de formas de um slide normal. Acesse o layout por meio de [Slide.getLayoutSlide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slide/#getLayoutSlide) e itere sobre a coleção retornada por [BaseSlide.getShapes](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseslide/#getShapes).

O exemplo a seguir altera os prompts de título e subtítulo no layout usado pelo primeiro slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    layout_slide = presentation.getSlides().get_Item(0).getLayoutSlide()

    for shape in layout_slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            shape.getTextFrame().setText("Enter a concise slide title")
        elif placeholder_type == PlaceholderType.Subtitle:
            shape.getTextFrame().setText("Enter a subtitle or reporting period")

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Texto de prompt não é conteúdo de slide normal. Ele destina‑se a placeholders vazios em aplicativos de edição como o PowerPoint. Uma vez que um usuário ou programa fornece conteúdo real, o prompt deixa de ser exibido. Alterar um prompt também não substitui o texto existente em slides que utilizam o layout.

## **Atualizar um Placeholder de Imagem**

Existem dois casos a serem tratados:

- Se o placeholder de imagem já estiver preenchido e representado por um [PictureFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pictureframe/), substitua a imagem por meio de [PictureFillFormat.getPicture](https://reference.aspose.com/slides/pt/python-java/aspose.slides/picturefillformat/#getPicture) e [Picture.setImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/picture/#setImage).
- Se ainda for um placeholder vazio, adicione um quadro de imagem nas coordenadas do placeholder com [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/#addPictureFrame) e remova o placeholder vazio.

O próximo exemplo suporta ambos os casos e salva a apresentação:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("picture-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Picture:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        print("The first slide does not contain a picture placeholder.")
    else:
        image_bytes = Path("replacement.png").read_bytes()
        java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
        image = presentation.getImages().addImage(java_image_bytes)

        if isinstance(picture_placeholder, PictureFrame):
            picture_placeholder.getPictureFormat().getPicture().setImage(image)
        else:
            slide.getShapes().addPictureFrame(ShapeType.Rectangle, picture_placeholder.getX(), picture_placeholder.getY(), picture_placeholder.getWidth(), picture_placeholder.getHeight(), image)
            slide.getShapes().remove(picture_placeholder)

        presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A substituição criada para um placeholder vazio é um quadro de imagem local, não um novo placeholder, porque [Shape.getPlaceholder](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getPlaceholder) não fornece um setter. Ele mantém a posição reservada, mas não herda mais o comportamento específico de placeholder. Se manter a relação de placeholder for essencial, prepare e preencha o placeholder no PowerPoint primeiro e, em seguida, atualize o [PictureFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pictureframe/) resultante com Aspose.Slides.

Para transparência de imagem, recorte e outros efeitos específicos de imagem, consulte [Gerenciar Quadros de Imagem](/slides/pt/python-java/picture-frame/). Essas operações pertencem ao quadro de imagem ou ao preenchimento da imagem, não aos metadados do placeholder.

## **Trabalhar com Placeholders de Gráfico e de Conteúdo**

Um placeholder de gráfico preenchido pode ser representado por um [Chart](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chart/). Este exemplo localiza tal gráfico tanto pelo tipo de placeholder quanto pelo tipo de execução, altera seu título e salva o arquivo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, PlaceholderType, SaveFormat

presentation = Presentation("chart-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    placeholder_chart = None

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Chart:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        print("The first slide does not contain a populated chart placeholder.")
    else:
        placeholder_chart.setTitle(True)
        placeholder_chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Um placeholder de conteúdo geral geralmente tem [PlaceholderType.Object](https://reference.aspose.com/slides/pt/python-java/aspose.slides/placeholdertype/#Object). No PowerPoint ele funciona como um lançador para vários tipos de conteúdo, incluindo gráficos, tabelas, diagramas, imagens e mídia. Após ser preenchido, inspecione o tipo real da forma para saber o que contém. Layouts especializados também podem expor [PlaceholderType.Chart](https://reference.aspose.com/slides/pt/python-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/pt/python-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/pt/python-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/pt/python-java/aspose.slides/placeholdertype/#Media) ou [PlaceholderType.Diagram](https://reference.aspose.com/slides/pt/python-java/aspose.slides/placeholdertype/#Diagram).

Aspose.Slides não converte um placeholder vazio de [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/) em um [Chart](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chart/) apenas alterando [Placeholder.getType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/placeholder/#getType); o tipo não pode ser alterado pela API. Para preencher programaticamente um gráfico ou área de conteúdo vazia, adicione o objeto necessário nas coordenadas do placeholder e então remova o placeholder vazio. O exemplo a seguir faz isso para um gráfico:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PlaceholderType, ChartType, SaveFormat

presentation = Presentation("content-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    target_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Chart, PlaceholderType.Object):
            target_placeholder = shape
            break

    if target_placeholder is None:
        print("The first slide does not contain a chart or content placeholder.")
    else:
        chart = slide.getShapes().addChart(ChartType.ClusteredColumn, target_placeholder.getX(), target_placeholder.getY(), target_placeholder.getWidth(), target_placeholder.getHeight())
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        slide.getShapes().remove(target_placeholder)
        presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O gráfico adicionado é um gráfico local ordinário. Ele ocupa a área do placeholder, mas não herda do placeholder de layout. Use os artigos dedicados à [gerência de gráficos](/slides/pt/python-java/powerpoint-charts/) quando precisar substituir categorias, séries ou dados da pasta de trabalho.

## **Exemplo Completo: Atualizar Texto ou Conteúdo de Imagem**

O exemplo completo a seguir abre um modelo, procura no primeiro slide por um placeholder de título ou de imagem, verifica os tipos de placeholder e de forma, atualiza o conteúdo apropriado e salva o resultado. O exemplo evita deliberadamente assumir um índice de forma ou tratar todos os placeholders como do mesmo tipo.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    updated = False

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle) and isinstance(shape, AutoShape):
            shape.getTextFrame().setText("Quarterly Business Review")
            updated = True
            break

        if placeholder_type == PlaceholderType.Picture:
            image_bytes = Path("replacement.png").read_bytes()
            java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
            image = presentation.getImages().addImage(java_image_bytes)

            if isinstance(shape, PictureFrame):
                shape.getPictureFormat().getPicture().setImage(image)
            else:
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image)
                slide.getShapes().remove(shape)

            updated = True
            break

    if updated:
        presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx)
    else:
        print("No supported title or picture placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

## **FAQ**

**O que é um placeholder base?**

Um placeholder base é a forma correspondente no layout ou no mestre da qual outro placeholder herda. Use [Shape.getBasePlaceholder](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getBasePlaceholder) para recuperá‑lo. Uma forma local ordinária devolve `None` porque não faz parte da hierarquia de placeholders.

**Posso alterar todos os títulos dos slides editando um placeholder de layout?**

É possível alterar a formatação herdada ou o texto de prompt por meio de um layout, mas o conteúdo de título existente está armazenado nos slides normais. Para substituir o texto real dos títulos em toda a apresentação, itere sobre os slides e atualize cada placeholder de título.

**Como gerencio placeholders de data, número do slide, cabeçalho e rodapé?**

Use os gerentes de cabeçalho e rodapé no escopo apropriado: slide, layout, mestre, notas ou folhetos. Consulte [Gerenciar Cabeçalho e Rodapé da Apresentação](/slides/pt/python-java/presentation-header-and-footer/) para exemplos completos.