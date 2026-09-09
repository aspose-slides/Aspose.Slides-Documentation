---
title: Gerenciar Zoom de Apresentação em Python via Java
linktitle: Gerenciar Zoom
type: docs
weight: 60
url: /pt/python-java/manage-zoom/
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
- Java
- Aspose.Slides
description: "Crie e personalize Zoom com Aspose.Slides para Python via Java — navegue entre seções, adicione miniaturas e transições em apresentações PPT, PPTX e ODP."
---
## **Introdução**

Os Zooms no PowerPoint permitem que você salte para e de slides, seções e partes específicas de uma apresentação. Ao apresentar, essa capacidade de navegar rapidamente pelo conteúdo pode ser muito útil.

![visão geral](overview.png)

* Para resumir toda a apresentação em um único slide, use um [Zoom de Resumo](#summary-zoom).
* Para mostrar apenas slides selecionados, use um [Zoom de Slide](#slide-zoom).
* Para mostrar apenas uma única seção, use um [Zoom de Seção](#section-zoom).

## **Zoom de Slide**

Um zoom de slide pode tornar sua apresentação mais dinâmica, permitindo que você navegue livremente entre slides em qualquer ordem que escolher sem interromper o fluxo da sua apresentação. Os zooms de slide são ótimos para apresentações curtas sem muitas seções, mas você ainda pode usá‑los em diferentes cenários de apresentação.

Os zooms de slide ajudam você a aprofundar várias informações enquanto parece que está em uma única tela.

![zoom de slide selecionado](slidezoomsel.png)

Para objetos de zoom de slide, Aspose.Slides fornece a enumeração [ZoomImageType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/zoomimagetype/), a classe [ZoomFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/zoomframe/) e alguns métodos na classe [ShapeCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/).

### **Criar Quadros de Zoom**

Você pode adicionar um quadro de zoom em um slide desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
2. Crie novos slides aos quais você pretende vincular os quadros de zoom.
3. Adicione texto identificador e plano de fundo aos slides criados.
4. Adicione quadros de zoom (contendo as referências aos slides criados) ao primeiro slide.
5. Grave a apresentação modificada como um arquivo PPTX.

Este código Python mostra como criar um quadro de zoom em um slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # adiciona novos slides à apresentação
    second_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  Cria um fundo para o segundo slide
    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  Cria uma caixa de texto para o segundo slide
    auto_shape = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Cria um fundo para o terceiro slide
    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray)

    #  Cria uma caixa de texto para o terceiro slide
    auto_shape = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Third Slide")

    # adiciona objetos ZoomFrame
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    #  Salva a apresentação
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Criar Quadros de Zoom com Imagens Personalizadas**
Com Aspose.Slides for Python via Java, você pode criar um quadro de zoom com uma imagem de pré‑visualização de slide diferente desta forma:
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
2. Crie um novo slide ao qual você pretende vincular o quadro de zoom.
3. Adicione texto identificador e plano de fundo ao slide.
4. Crie um objeto [PPImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/ppimage/) adicionando uma imagem à coleção de imagens associada ao objeto [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) que será usado para preencher o quadro.
5. Adicione quadros de zoom (contendo a referência ao slide criado) ao primeiro slide.
6. Grave a apresentação modificada como um arquivo PPTX.

Este código Python mostra como criar um quadro de zoom com uma imagem diferente:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Adiciona um novo slide à apresentação
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  Cria um fundo para o segundo slide
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  Cria uma caixa de texto para o segundo slide
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Cria uma nova imagem para o objeto de zoom
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Adiciona o objeto ZoomFrame
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture)

    #  Salva a apresentação
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Formatar Quadros de Zoom**
Nas seções anteriores, mostramos como criar quadros de zoom simples. Para criar quadros de zoom mais complicados, você precisa alterar a formatação de um quadro simples. Existem várias opções de formatação que você pode aplicar a um quadro de zoom.

Você pode controlar a formatação de um quadro de zoom em um slide desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
2. Crie novos slides aos quais você pretende vincular os quadros de zoom.
3. Adicione texto identificador e plano de fundo aos slides criados.
4. Adicione quadros de zoom (contendo as referências aos slides criados) ao primeiro slide.
5. Crie um objeto [PPImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/ppimage/) adicionando uma imagem à coleção de imagens associada ao objeto [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) que será usado para preencher o quadro.
6. Defina uma imagem personalizada para o primeiro objeto de quadro de zoom.
7. Altere o formato da linha para o segundo objeto de quadro de zoom.
8. Remova o plano de fundo de uma imagem do segundo objeto de quadro de zoom.
9. Grave a apresentação modificada como um arquivo PPTX.

Este código Python mostra como alterar a formatação de um quadro de zoom em um slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    #  Adiciona novos slides à apresentação
    second_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  Cria um fundo para o segundo slide
    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  Cria uma caixa de texto para o segundo slide
    auto_shape = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Cria um fundo para o terceiro slide
    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray)

    #  Cria uma caixa de texto para o terceiro slide
    auto_shape = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Third Slide")

    #  Adiciona objetos ZoomFrame
    first_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    second_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    #  Cria uma nova imagem para o objeto de zoom
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    #  Define imagem personalizada para o objeto first_zoom_frame
    first_zoom_frame.setZoomImage(picture)

    #  Define um formato de quadro de zoom para o objeto second_zoom_frame
    second_zoom_frame.getLineFormat().setWidth(5)
    second_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    second_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink)
    second_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)

    #  Configuração para não exibir fundo no objeto second_zoom_frame
    second_zoom_frame.setShowBackground(False)

    #  Salva a apresentação
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zoom de Seção**

Um zoom de seção é um link para uma seção da sua apresentação. Você pode usar zooms de seção para voltar a seções que deseja realmente enfatizar. Ou pode usá‑los para destacar como certas partes da sua apresentação se conectam.

![zoom de seção selecionado](seczoomsel.png)

Para objetos de zoom de seção, Aspose.Slides fornece a classe [SectionZoomFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sectionzoomframe/) e alguns métodos na classe [ShapeCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/).

### **Criar Quadros de Zoom de Seção**

Você pode adicionar um quadro de zoom de seção a um slide desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
2. Crie um novo slide.
3. Adicione um plano de fundo distinto ao slide criado.
4. Crie uma nova seção à qual você pretende vincular o quadro de zoom.
5. Adicione um quadro de zoom de seção (contendo referências à seção criada) ao primeiro slide.
6. Grave a apresentação modificada como um arquivo PPTX.

Este código Python mostra como criar um quadro de zoom em um slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Adiciona um novo slide à apresentação
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Adiciona uma nova Seção à apresentação
    presentation.getSections().addSection("Section 1", slide)

    #  Adiciona um objeto SectionZoomFrame
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1))

    #  Salva a apresentação
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Criar Quadros de Zoom de Seção com Imagens Personalizadas**

Usando Aspose.Slides for Python via Java, você pode criar um quadro de zoom de seção com uma imagem de pré‑visualização de slide diferente desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
2. Crie um novo slide.
3. Adicione um plano de fundo distinto ao slide criado.
4. Crie uma nova seção à qual você pretende vincular o quadro de zoom.
5. Crie um objeto [PPImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/ppimage/) adicionando uma imagem à coleção de imagens associada ao objeto [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) que será usado para preencher o quadro.
6. Adicione um quadro de zoom de seção (contendo uma referência à seção criada) ao primeiro slide.
7. Grave a apresentação modificada como um arquivo PPTX.

Este código Python mostra como criar um quadro de zoom com uma imagem diferente:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Adiciona novo slide à apresentação
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Adiciona uma nova Seção à apresentação
    presentation.getSections().addSection("Section 1", slide)

    #  Cria uma nova imagem para o objeto de zoom
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    #  Adiciona objeto SectionZoomFrame
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1), picture)

    #  Salva a apresentação
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Formatar Quadros de Zoom de Seção**

Para criar quadros de zoom de seção mais complicados, você precisa alterar a formatação de um quadro simples. Existem várias opções de formatação que você pode aplicar a um quadro de zoom de seção.

Você pode controlar a formatação de um quadro de zoom de seção em um slide desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
2. Crie um novo slide.
3. Adicione um plano de fundo distinto ao slide criado.
4. Crie uma nova seção à qual você pretende vincular o quadro de zoom.
5. Adicione um quadro de zoom de seção (contendo referências à seção criada) ao primeiro slide.
6. Altere o tamanho e a posição do objeto de zoom de seção criado.
7. Crie um objeto [PPImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/ppimage/) adicionando uma imagem à coleção de imagens associada ao objeto [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) que será usado para preencher o quadro.
8. Defina uma imagem personalizada para o objeto de zoom de seção criado.
9. Defina a capacidade de *retornar ao slide original da seção vinculada*.
10. Remova o plano de fundo de uma imagem do objeto de zoom de seção.
11. Altere o formato da linha do objeto de zoom de seção.
12. Altere a duração da transição.
13. Grave a apresentação modificada como um arquivo PPTX.

Este código Python mostra como alterar a formatação de um quadro de zoom de seção:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Adiciona um novo slide à apresentação
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Adiciona uma nova Seção à apresentação
    presentation.getSections().addSection("Section 1", slide)

    #  Adiciona o objeto SectionZoomFrame
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1))

    #  Formatação para SectionZoomFrame
    section_zoom_frame.setX(100)
    section_zoom_frame.setY(300)
    section_zoom_frame.setWidth(100)
    section_zoom_frame.setHeight(75)

    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    section_zoom_frame.setZoomImage(picture)

    section_zoom_frame.setReturnToParent(True)
    section_zoom_frame.setShowBackground(False)

    section_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    section_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.gray)
    section_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    section_zoom_frame.getLineFormat().setWidth(2.5)

    section_zoom_frame.setTransitionDuration(1.5)

    #  Salva a apresentação
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```


## **Zoom de Resumo**

Um zoom de resumo é como uma página inicial onde todas as partes da sua apresentação são exibidas ao mesmo tempo. Quando você está apresentando, pode usar o zoom para ir de um ponto da apresentação a outro em qualquer ordem que desejar. Você pode ser criativo, avançar rapidamente ou revisitar partes da sua apresentação sem interromper o fluxo.

![zoom de resumo selecionado](sumzoomsel.png)

Para objetos de zoom de resumo, Aspose.Slides fornece as classes [SummaryZoomFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/summaryzoomsection/) e [SummaryZoomSectionCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/summaryzoomsectioncollection/) e alguns métodos na classe [ShapeCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/).

### **Criar um Zoom de Resumo**

Você pode adicionar um quadro de zoom de resumo a um slide desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
2. Crie novos slides com um plano de fundo distinto e novas seções para os slides criados.
3. Adicione o quadro de zoom de resumo ao primeiro slide.
4. Grave a apresentação modificada como um arquivo PPTX.

Este código Python mostra como criar um quadro de zoom de resumo em um slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Adiciona um novo slide à apresentação
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Adiciona uma nova seção à apresentação
    presentation.getSections().addSection("Section 1", slide)

    # Adiciona um novo slide à apresentação
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Adiciona uma nova seção à apresentação
    presentation.getSections().addSection("Section 2", slide)

    # Adiciona um novo slide à apresentação
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Adiciona uma nova seção à apresentação
    presentation.getSections().addSection("Section 3", slide)

    # Adiciona um novo slide à apresentação
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Adiciona uma nova seção à apresentação
    presentation.getSections().addSection("Section 4", slide)

    #  Adiciona um objeto SummaryZoomFrame
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    #  Salva a apresentação
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Adicionar e Remover uma Seção de Zoom de Resumo**

Todas as seções em um quadro de zoom de resumo são representadas por objetos [SummaryZoomSection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/summaryzoomsection/), que são armazenados no objeto [SummaryZoomSectionCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/summaryzoomsectioncollection/). Você pode adicionar ou remover um objeto de seção de zoom de resumo através da classe [SummaryZoomSectionCollection] desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
2. Crie novos slides com um plano de fundo distinto e novas seções para os slides criados.
3. Adicione um quadro de zoom de resumo ao primeiro slide.
4. Adicione um novo slide e seção à apresentação.
5. Adicione a seção criada ao quadro de zoom de resumo.
6. Remova a primeira seção do quadro de zoom de resumo.
7. Grave a apresentação modificada como um arquivo PPTX.

Este código Python mostra como adicionar e remover seções em um quadro de zoom de resumo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Adiciona um novo slide à apresentação
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Adiciona uma nova seção à apresentação
    presentation.getSections().addSection("Section 1", slide)

    # Adiciona um novo slide à apresentação
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Adiciona uma nova seção à apresentação
    presentation.getSections().addSection("Section 2", slide)

    #  Adiciona objeto SummaryZoomFrame
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    # Adiciona um novo slide à apresentação
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Adiciona uma nova seção à apresentação
    third_section = presentation.getSections().addSection("Section 3", slide)

    #  Adiciona uma seção ao Summary Zoom
    summary_zoom_frame.getSummaryZoomCollection().addSummaryZoomSection(third_section)

    #  Remove seção do Summary Zoom
    summary_zoom_frame.getSummaryZoomCollection().removeSummaryZoomSection(presentation.getSections().get_Item(1))

    #  Salva a apresentação
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Formatar Seções de Zoom de Resumo**

Para criar objetos de seção de zoom de resumo mais complicados, você precisa alterar a formatação de um quadro simples. Existem várias opções de formatação que você pode aplicar a um objeto de seção de zoom de resumo.

Você pode controlar a formatação de um objeto de seção de zoom de resumo em um quadro de zoom de resumo desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
2. Crie novos slides com um plano de fundo distinto e novas seções para os slides criados.
3. Adicione um quadro de zoom de resumo ao primeiro slide.
4. Obtenha o primeiro objeto de seção de zoom de resumo da [SummaryZoomSectionCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/summaryzoomsectioncollection/).
5. Crie um objeto [PPImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/ppimage/) adicionando uma imagem à coleção de imagens associada ao objeto [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) que será usado para preencher o quadro.
6. Defina uma imagem personalizada para o objeto de seção de zoom de resumo.
7. Defina a capacidade de *retornar ao slide original da seção vinculada*.
8. Altere o formato da linha do objeto de seção de zoom de resumo.
9. Altere a duração da transição.
10. Grave a apresentação modificada como um arquivo PPTX.

Este código Python mostra como alterar a formatação de um objeto de seção de zoom de resumo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Adiciona um novo slide à apresentação
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Adiciona uma nova seção à apresentação
    presentation.getSections().addSection("Section 1", slide)

    # Adiciona um novo slide à apresentação
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Adiciona uma nova seção à apresentação
    presentation.getSections().addSection("Section 2", slide)

    #  Adiciona um objeto SummaryZoomFrame
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    #  Obtém o primeiro objeto SummaryZoomSection
    summary_section = summary_zoom_frame.getSummaryZoomCollection().get_Item(0)

    #  Formatação para o objeto SummaryZoomSection
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    summary_section.setZoomImage(picture)

    summary_section.setReturnToParent(False)

    summary_section.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    summary_section.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.black)
    summary_section.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    summary_section.getLineFormat().setWidth(1.5)

    summary_section.setTransitionDuration(1.5)

    #  Salva a apresentação
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Perguntas Frequentes**

**Posso controlar o retorno ao slide 'pai' após exibir o destino?**

Sim. O [ZoomFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/zoomframe/) ou [SectionZoomFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sectionzoomframe/) suportam o retorno ao slide de origem por meio do método [setReturnToParent](https://reference.aspose.com/slides/pt/python-java/aspose.slides/zoomobject/#setReturnToParent), que envia os visualizadores de volta após visitarem o conteúdo alvo quando ativado.

**Posso ajustar a 'velocidade' ou a duração da transição do Zoom?**

Sim. O Zoom suporta a definição de uma duração de transição com o método [setTransitionDuration](https://reference.aspose.com/slides/pt/python-java/aspose.slides/zoomobject/#setTransitionDuration), permitindo controlar quanto tempo a animação de salto leva.

**Existem limites para a quantidade de objetos Zoom que uma apresentação pode conter?**

Não há um limite rígido de API documentado. Os limites práticos dependem da complexidade geral da apresentação e do desempenho do visualizador. Você pode adicionar muitos quadros de Zoom, mas deve considerar o tamanho do arquivo e o tempo de renderização.