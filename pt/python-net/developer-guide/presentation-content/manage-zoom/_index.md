---
title: Gerenciar Zooms em Apresentações com Python
linktitle: Zoom
type: docs
weight: 60
url: /pt/python-net/manage-zoom/
keywords:
- zoom
- quadro de zoom
- zoom de slide
- zoom de seção
- zoom de resumo
- adicionar zoom
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Crie e personalize Zoom com Aspose.Slides para Python via .NET — navegue entre seções, adicione miniaturas e transições em apresentações PPT, PPTX e ODP."
---
## **Introdução**

Os Zooms no PowerPoint permitem que você vá para e volte de slides, seções e partes específicas de uma apresentação. Ao apresentar, essa capacidade de navegar rapidamente pelo conteúdo pode ser muito útil. 

![visão geral](overview.png)

* Para resumir toda a apresentação em um único slide, use um [Zoom de Resumo](#Summary-Zoom).
* Para exibir apenas os slides selecionados, use um [Zoom de Slide](#Slide-Zoom).
* Para exibir apenas uma única seção, use um [Zoom de Seção](#Section-Zoom).

## **Zoom de Slide**

Um zoom de slide pode tornar sua apresentação mais dinâmica, permitindo que você navegue livremente entre os slides em qualquer ordem que escolher sem interromper o fluxo da apresentação. Os zooms de slide são ótimos para apresentações curtas sem muitas seções, mas ainda podem ser usados em diferentes cenários de apresentação.

Os zooms de slide ajudam você a aprofundar múltiplas informações enquanto parece estar em uma única tela. 

![seleção de zoom de slide](slidezoomsel.png)

Para objetos de zoom de slide, o Aspose.Slides fornece a enumeração [ZoomImageType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/zoomimagetype/) , a classe [ZoomFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/zoomframe/) e alguns métodos na classe [ShapeCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shapecollection/) .

### **Criando Quadros de Zoom**

Você pode adicionar um quadro de zoom em um slide desta forma:

1.	Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) .
2.	Crie novos slides aos quais você pretende vincular. 
3.	Adicione um texto de identificação e um plano de fundo aos slides criados.
4.	Adicione quadros de zoom (contendo as referências aos slides criados) no primeiro slide.
5.	Grave a apresentação modificada como um arquivo PPTX.

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Adicionar novos slides à apresentação
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Criar um fundo para o segundo slide
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Criar uma caixa de texto para o segundo slide
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Criar um fundo para o terceiro slide
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Criar uma caixa de texto para o terceiro slide
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #Adicionar objetos ZoomFrame
    pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Salvar a apresentação
    pres.save("presentation-zoom.pptx", slides.export.SaveFormat.PPTX)
```
### **Criando Quadros de Zoom com Imagens Personalizadas**

Com o Aspose.Slides for Python via .NET, você pode criar um quadro de zoom com uma imagem diferente da imagem de visualização do slide desta forma: 
1.	Crie uma instância da classe `Presentation` .
2.	Crie um novo slide ao qual você pretende vincular. 
3.	Adicione um texto de identificação e um plano de fundo ao slide criado.
4.	Crie um objeto [PPImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ppimage/) adicionando uma imagem à coleção Images associada ao objeto Presentation que será usado para preencher o quadro.
5.	Adicione quadros de zoom (contendo a referência ao slide criado) no primeiro slide.
6.	Grave a apresentação modificada como um arquivo PPTX.

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Adicionar um novo slide à apresentação
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Criar um fundo para o segundo slide
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Criar uma caixa de texto para o terceiro slide
    autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Criar uma nova imagem para o objeto de zoom
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    #Adicionar o objeto ZoomFrame
    pres.slides[0].shapes.add_zoom_frame(20, 20, 300, 200, slide, image)

    # Salvar a apresentação
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Formatando Quadros de Zoom**

Nas seções anteriores (acima), mostramos como criar quadros de zoom simples. Para criar quadros de zoom mais complicados, é necessário alterar a formatação dos quadros. Existem várias configurações de formatação que você pode aplicar a um quadro de zoom.

Você pode controlar a formatação de um quadro de zoom em um slide desta forma:

1.	Crie uma instância da classe `Presentation` .
2.	Crie novos slides para vincular.
3.	Adicione um texto de identificação e plano de fundo aos slides criados.
4.	Adicione quadros de zoom (contendo as referências aos slides criados) no primeiro slide.
5.	Crie um objeto [PPImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ppimage/) adicionando uma imagem à coleção Images associada ao objeto Presentation que será usado para preencher o quadro.
6.	Defina uma imagem personalizada para o primeiro objeto de quadro de zoom.
7.	Altere o formato da linha para o segundo objeto de quadro de zoom.
8.	Remova o plano de fundo de uma imagem do segundo objeto de quadro de zoom.
9.	Grave a apresentação modificada como um arquivo PPTX.

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Adicionar novos slides à apresentação
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Criar um fundo para o segundo slide
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Criar uma caixa de texto para o segundo slide
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Criar um fundo para o terceiro slide
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Criar uma caixa de texto para o terceiro slide
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #Adicionar objetos ZoomFrame
    zoomFrame1 = pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    zoomFrame2 = pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Criar uma nova imagem para o objeto de zoom
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    # Definir imagem personalizada para o objeto zoomFrame1
    zoomFrame1.image = image

    # Definir um formato de quadro de zoom para o objeto zoomFrame2
    zoomFrame2.line_format.width = 5
    zoomFrame2.line_format.fill_format.fill_type = slides.FillType.SOLID
    zoomFrame2.line_format.fill_format.solid_fill_color.color = draw.Color.hot_pink
    zoomFrame2.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    # Não mostrar fundo para o objeto zoomFrame2
    zoomFrame2.show_background = False

    # Salvar a apresentação
    pres.save("presentation-zoom2.pptx", slides.export.SaveFormat.PPTX)
```

## **Zoom de Seção**

Um zoom de seção é um link para uma seção da sua apresentação. Você pode usar zooms de seção para voltar a seções que deseja enfatizar realmente. Ou pode usá‑los para destacar como certas partes da sua apresentação se conectam. 

![seleção de zoom de seção](seczoomsel.png)

Para objetos de zoom de seção, o Aspose.Slides fornece a classe [SectionZoomFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sectionzoomframe/) e alguns métodos da classe [ShapeCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shapecollection/) .

### **Criando Quadros de Zoom de Seção**

Você pode adicionar um quadro de zoom de seção a um slide desta forma:

1.	Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) .
2.	Crie um novo slide. 
3.	Adicione um plano de fundo de identificação ao slide criado.
4.	Crie uma nova seção à qual você pretende vincular o quadro de zoom. 
5.	Adicione um quadro de zoom de seção (contendo referências à seção criada) ao primeiro slide.
6.	Grave a apresentação modificada como um arquivo PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Adiciona um novo slide à apresentação
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # Adiciona uma nova Seção à apresentação
    pres.sections.add_section("Section 1", slide)

    # Adiciona um objeto SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # Salva a apresentação
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Criando Quadros de Zoom de Seção com Imagens Personalizadas**

Usando o Aspose.Slides for Python, você pode criar um quadro de zoom de seção com uma imagem de visualização de slide diferente desta forma: 

1.	Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) .
2.	Crie um novo slide.
3.	Adicione um plano de fundo de identificação ao slide criado.
4.	Crie uma nova seção à qual você pretende vincular o quadro de zoom. 
5.	Crie um objeto [PPImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ppimage/) adicionando uma imagem à coleção Images associada ao objeto [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) que será usado para preencher o quadro.
6.	Adicione um quadro de zoom de seção (contendo uma referência à seção criada) ao primeiro slide.
7.	Grave a apresentação modificada como um arquivo PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Adiciona um novo slide à apresentação
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # Adiciona uma nova Seção à apresentação
    pres.sections.add_section("Section 1", slide)

    # Cria uma nova imagem para o objeto de zoom
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    # Adiciona um objeto SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1], image)

    # Salva a apresentação
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Formatando Quadros de Zoom de Seção**

Para criar quadros de zoom de seção mais complicados, você deve alterar a formatação de um quadro simples. Existem várias opções de formatação que você pode aplicar a um quadro de zoom de seção. 

Você pode controlar a formatação de um quadro de zoom de seção em um slide desta forma:

1.	Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) .
2.	Crie um novo slide.
3.	Adicione um plano de fundo de identificação ao slide criado.
4.	Crie uma nova seção à qual você pretende vincular o quadro de zoom. 
5.	Adicione um quadro de zoom de seção (contendo referências à seção criada) ao primeiro slide.
6.	Altere o tamanho e a posição do objeto de zoom de seção criado.
7.	Crie um objeto [PPImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ppimage/) adicionando uma imagem à coleção Images associada ao objeto [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) que será usado para preencher o quadro.
8.	Defina uma imagem personalizada para o objeto de quadro de zoom de seção criado.
9.	Defina a capacidade de *retornar ao slide original a partir da seção vinculada*.
10.	Remova o plano de fundo de uma imagem do objeto de quadro de zoom de seção.
11.	Altere o formato da linha para o segundo objeto de quadro de zoom.
12.	Altere a duração da transição.
13.	Grave a apresentação modificada como um arquivo PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #Adiciona um novo slide à apresentação
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Adiciona uma nova Seção à apresentação
    pres.sections.add_section("Section 1", slide)

    # Adiciona objeto SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # Formatação para SectionZoomFrame
    sectionZoomFrame.x = 100
    sectionZoomFrame.y = 300
    sectionZoomFrame.width = 100
    sectionZoomFrame.height = 75

    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    sectionZoomFrame.image = image

    sectionZoomFrame.return_to_parent = True
    sectionZoomFrame.show_background = False

    sectionZoomFrame.line_format.fill_format.fill_type = slides.FillType.SOLID
    sectionZoomFrame.line_format.fill_format.solid_fill_color.color = draw.Color.brown
    sectionZoomFrame.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    sectionZoomFrame.line_format.width = 2.5

    sectionZoomFrame.transition_duration = 1.5

    # Salva a apresentação
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Zoom de Resumo**

Um zoom de resumo funciona como uma página inicial onde todas as partes da sua apresentação são exibidas de uma só vez. Ao apresentar, você pode usar o zoom para ir de um ponto da apresentação a outro em qualquer ordem que desejar. Você pode ser criativo, avançar ou revisitar partes da sua apresentação sem interromper o fluxo da apresentação.

![imagem geral](summaryzoom.png)

Para objetos de zoom de resumo, o Aspose.Slides fornece a classe [SummaryZoomFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/summaryzoomsection/) e [SummaryZoomSectionCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/summaryzoomsectioncollection/) e alguns métodos da classe [ShapeCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shapecollection/) .

### **Criando Zoom de Resumo**

Você pode adicionar um quadro de zoom de resumo a um slide desta forma:

1.	Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) .
2.	Crie novos slides com plano de fundo de identificação e novas seções para os slides criados.
3.	Adicione o quadro de zoom de resumo ao primeiro slide.
4.	Grave a apresentação modificada como um arquivo PPTX.

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # Criar array de slides
    for slideNumber in range(5):
        #Adicionar novos slides à apresentação
        slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

        # Criar um fundo para o slide
        slide.background.type = slides.BackgroundType.OWN_BACKGROUND
        slide.background.fill_format.fill_type = slides.FillType.SOLID
        slide.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

        # Criar uma caixa de texto para o slide
        autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
        autoshape.text_frame.text = "Slide - {num}".format(num = (slideNumber + 2))

    # Criar objetos de zoom para todos os slides no primeiro slide
    for slideNumber in range(1, len(pres.slides)):
        x = (slideNumber - 1) * 100
        y = (slideNumber - 1) * 100
        zoomFrame = pres.slides[0].shapes.add_zoom_frame(x, y, 150, 120, pres.slides[slideNumber])

        # Definir a propriedade ReturnToParent para retornar ao primeiro slide
        zoomFrame.return_to_parent = True

    # Salvar a apresentação
    pres.save("presentation-zoom3.pptx", slides.export.SaveFormat.PPTX)
```

### **Adicionando e Removendo Seções de Zoom de Resumo**

Todas as seções em um quadro de zoom de resumo são representadas por objetos [SummaryZoomSection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/summaryzoomsection/) , que são armazenados no objeto [SummaryZoomSectionCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/summaryzoomsectioncollection/) . Você pode adicionar ou remover um objeto de seção de zoom de resumo através da classe [SummaryZoomSectionCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/summaryzoomsectioncollection/) desta forma:

1.	Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) .
2.	Crie novos slides com plano de fundo de identificação e novas seções para os slides criados.
3.	Adicione um quadro de zoom de resumo ao primeiro slide.
4.	Adicione um novo slide e uma nova seção à apresentação.
5.	Adicione a seção criada ao quadro de zoom de resumo.
6.	Remova a primeira seção do quadro de zoom de resumo.
7.	Grave a apresentação modificada como um arquivo PPTX.

``` python
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #Adiciona um novo slide à apresentação
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Adiciona uma nova seção à apresentação
    pres.sections.add_section("Section 1", slide)

    #Adiciona um novo slide à apresentação
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Adiciona uma nova seção à apresentação
    pres.sections.add_section("Section 2", slide)

    # Adiciona objeto SummaryZoomFrame
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    #Adiciona um novo slide à apresentação
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.chartreuse
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Adiciona uma nova seção à apresentação
    section3 = pres.sections.add_section("Section 3", slide)

    # Adiciona uma seção ao Summary Zoom
    summaryZoomFrame.summary_zoom_collection.add_summary_zoom_section(section3)

    # Remove seção do Summary Zoom
    summaryZoomFrame.summary_zoom_collection.remove_summary_zoom_section(pres.sections[1])

    # Salva a apresentação
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Formatando Seções de Zoom de Resumo**

Para criar objetos de seção de zoom de resumo mais complicados, você deve alterar a formatação de um quadro simples. Existem várias opções de formatação que você pode aplicar a um objeto de seção de zoom de resumo. 

Você pode controlar a formatação de um objeto de seção de zoom de resumo em um quadro de zoom de resumo desta forma:

1.	Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) .
2.	Crie novos slides com plano de fundo de identificação e novas seções para os slides criados.
3.	Adicione um quadro de zoom de resumo ao primeiro slide.
4.	Obtenha um objeto de seção de zoom de resumo para o primeiro objeto da `SummaryZoomSectionCollection` .
5.	Crie um objeto `PPImage` adicionando uma imagem à coleção de imagens associada ao objeto [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) que será usado para preencher o quadro.
6.	Defina uma imagem personalizada para o objeto de quadro de zoom de seção criado.
7.	Defina a capacidade de *retornar ao slide original a partir da seção vinculada*.
8.	Altere o formato da linha para o segundo objeto de quadro de zoom.
9.	Altere a duração da transição.
10.	Grave a apresentação modificada como um arquivo PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Adiciona um novo slide à apresentação
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.brown
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Adiciona uma nova seção à apresentação
    pres.sections.add_section("Section 1", slide)

    #Adiciona um novo slide à apresentação
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Adiciona uma nova seção à apresentação
    pres.sections.add_section("Section 2", slide)

    # Adiciona um objeto SummaryZoomFrame
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    # Obtém o primeiro objeto SummaryZoomSection
    summarySection = summaryZoomFrame.summary_zoom_collection[0]

    # Formatação para o objeto SummaryZoomSection
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    summarySection.image = image

    summarySection.return_to_parent = False

    summarySection.line_format.fill_format.fill_type = slides.FillType.SOLID
    summarySection.line_format.fill_format.solid_fill_color.color = draw.Color.black
    summarySection.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    summarySection.line_format.width = 1.5

    summarySection.transition_duration = 1.5

    # Salva a apresentação
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Perguntas Frequentes**

**Posso controlar o retorno ao slide 'pai' após exibir o destino?**

Sim. O [Zoom frame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/zoomframe/) ou a [section](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sectionzoomframe/) possui um comportamento `return_to_parent` que, quando habilitado, devolve os espectadores ao slide de origem após visitarem o conteúdo de destino.

**Posso ajustar a 'velocidade' ou a duração da transição de Zoom?**

Sim. O Zoom permite definir um `transition_duration`, permitindo controlar a duração da animação de salto.

**Existem limites para a quantidade de objetos Zoom que uma apresentação pode conter?**

Não há um limite rígido de API documentado. Os limites práticos dependem da complexidade geral da apresentação e do desempenho do visualizador. Você pode adicionar muitos quadros de Zoom, mas deve considerar o tamanho do arquivo e o tempo de renderização.