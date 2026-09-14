---
title: Gerenciar mestres de slides de apresentação em Python via Java
linktitle: Mestre de Slide
type: docs
weight: 70
url: /pt/python-java/slide-master/
keywords:
- mestre de slide
- slide mestre
- slide mestre PPT
- vários slides mestres
- comparar slides mestres
- fundo
- marcador de posição
- clonar slide mestre
- copiar slide mestre
- duplicar slide mestre
- slide mestre não usado
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Gerencie mestres de slides no Aspose.Slides para Python via Java: acesse, edite, clone, compare e remova slides mestres em apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

Um **slide master** define configurações de design compartilhadas para um grupo de slides. Ele pode conter formas comuns, logotipos, fundos, estilos de texto, configurações de tema e configurações de rodapé. No PowerPoint, editar um slide master é a forma usual de manter uma apresentação consistente sem repetir a mesma formatação em cada slide.

Aspose.Slides for Python via Java suporta o mesmo modelo. Uma apresentação pode conter um ou mais slides mestres, e cada slide mestre pode conter vários slides de layout. Slides normais normalmente não referenciam um slide mestre diretamente. Em vez disso, um slide normal usa um slide de layout, e esse slide de layout pertence a um slide mestre.

A hierarquia é:

1. **Slide master** – define o design e o tema compartilhados.  
1. **Slide de layout** – define um arranjo específico de marcadores de posição e formatação de nível de layout.  
1. **Slide normal** – contém o conteúdo real da apresentação e usa um slide de layout.

![A hierarquia de slides mestres, slides de layout e slides normais](slide-master_2.jpg)

No Aspose.Slides, um slide master é representado pela classe [MasterSlide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterslide/). Todos os slides mestres em uma apresentação estão disponíveis por meio da coleção [Presentation.getMasters](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getMasters), que é representada por [MasterSlideCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterslidecollection/).

{{% alert color="info" title="Inheritance" %}}

Quando a mesma propriedade é definida em mais de um nível, o nível mais específico prevalece. Por exemplo, se um slide mestre e um slide de layout ambos definirem um fundo, os slides baseados naquele layout usarão o fundo do layout. Para mais informações sobre slides de layout, veja [Apply or Change Slide Layouts](/slides/pt/python-java/slide-layout/).

{{% /alert %}}

## **Acessar Slides Mestres**

No PowerPoint, você pode abrir a visualização Slide Master em **View** > **Slide Master**.

![O comando Slide Master na guia View do PowerPoint](slide-master_3.jpg)

No Aspose.Slides, use a coleção [Presentation.getMasters](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getMasters) para acessar slides mestres:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    master_slide_count = presentation.getMasters().size()
    first_master_layout_slide_count = first_master_slide.getLayoutSlides().size()

    print(f"Master slides: {master_slide_count}")
    print(f"Layouts in the first master: {first_master_layout_slide_count}")
finally:
    presentation.dispose()
```

Você também pode obter o slide mestre usado por um slide normal por meio de seu layout:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    layout_slide = slide.getLayoutSlide()
    master_slide = layout_slide.getMasterSlide()
    master_slide_name = master_slide.getName()

    print(master_slide_name)
finally:
    presentation.dispose()
```

## **O que um Slide Master contém**

Um slide mestre é um objeto semelhante a um slide. Ele herda de [BaseSlide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseslide/), portanto expõe muitas das mesmas propriedades de slide usadas por slides normais e de layout. Membros específicos do mestre estão listados na página da API [MasterSlide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterslide/).

Membros de slide mestre usados com frequência incluem:

| Membro | Finalidade |
| --- | --- |
| [getBackground](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseslide/#getBackground) | Define o plano de fundo do slide ao nível do mestre. |
| [getShapes](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseslide/#getShapes) | Armazena formas colocadas no mestre, como logotipos, quadros de imagem e texto compartilhado. |
| [getLayoutSlides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterslide/#getLayoutSlides) | Armazena os slides de layout que pertencem ao mestre. |
| [getThemeManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterslide/#getThemeManager) | Fornece acesso às APIs de tema do mestre. |
| [getHeaderFooterManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterslide/#getHeaderFooterManager) | Controla cabeçalhos, rodapés, datas e números de slide para o mestre e seus layouts filhos. |
| [getDependingSlides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterslide/#getDependingSlides) | Retorna slides normais que dependem do mestre por meio de seus layouts. |

## **Adicionar uma imagem a um Slide Master**

Ao adicionar uma imagem a um slide mestre, ela aparece nos slides que usam layouts daquele mestre. Isso é útil para logotipos, marcas d’água, faixas decorativas e outros elementos visuais repetidos.

O exemplo a seguir adiciona um logotipo ao primeiro slide mestre:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    logo = Images.fromFile("logo.png")
    try:
        logo_image = presentation.getImages().addImage(logo)
        master_slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 80, 80, logo_image)
    finally:
        logo.dispose()

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Para mais informações sobre quadros de imagem, veja [Picture Frame](/slides/pt/python-java/picture-frame/).

## **Trabalhar com marcadores de posição**

Marcadores de posição são normalmente definidos em slides de layout. O slide mestre fornece o estilo e o tema compartilhados que esses layouts herdam, enquanto cada layout decide quais marcadores de posição estão disponíveis e onde eles são colocados.

No PowerPoint, os comandos de marcador de posição estão disponíveis na visualização Slide Master.

![O comando Insert Placeholder na visualização Slide Master do PowerPoint](slide-master_5.png)

Para adicionar novos marcadores de posição com Aspose.Slides, trabalhe com o slide de layout que pertence ao mestre:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    blank_layout_slide = master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout_slide is None:
        blank_layout_slide = master_slide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank")

    blank_layout_slide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80)

    presentation.getSlides().addEmptySlide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Você também pode formatar formas de marcador de posição que já existem em um slide mestre. O exemplo a seguir encontra o marcador de posição de título e aplica um preenchimento de gradiente linear:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, GradientShape, PlaceholderType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    title_placeholder = None

    for shape in master_slide.getShapes():
        if isinstance(shape, AutoShape):
            if shape.getPlaceholder() is not None and shape.getPlaceholder().getType() == PlaceholderType.Title:
                title_placeholder = shape
                break

    if title_placeholder is not None:
        red_gradient_color = Color(255, 0, 0)
        purple_gradient_color = Color(128, 0, 128)

        title_placeholder.getFillFormat().setFillType(FillType.Gradient)
        title_placeholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(0.0), red_gradient_color)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(1.0), purple_gradient_color)

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Marcador de posição de título formatado herdado por slides normais](slide-master_8.png)

Para mais opções de marcador de posição e formatação de texto, veja [Set Prompt Text in Placeholder](/slides/pt/python-java/manage-placeholder/) e [Text Formatting](/slides/pt/python-java/text-formatting/).

## **Alterar o fundo de um Slide Master**

Um fundo de mestre é herdado por layouts e slides que não o substituem. O exemplo a seguir define uma cor de fundo sólida para o primeiro slide mestre:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    master_background_color = Color.GREEN

    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(master_background_color)

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Para tópicos relacionados, veja [Presentation Background](/slides/pt/python-java/presentation-background/) e [Presentation Theme](/slides/pt/python-java/presentation-theme/).

## **Clonar um Slide Master para outra apresentação**

Use [MasterSlideCollection.addClone](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterslidecollection/#addClone) para copiar um slide mestre para outra apresentação. O mestre copiado pode então ser usado por layouts e slides na apresentação de destino.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source_presentation = Presentation("source.pptx")
destination_presentation = Presentation("destination.pptx")
try:
    source_master_slide = source_presentation.getMasters().get_Item(0)
    cloned_master_slide = destination_presentation.getMasters().addClone(source_master_slide)

    destination_presentation.save("destination-with-master.pptx", SaveFormat.Pptx)
finally:
    source_presentation.dispose()
    destination_presentation.dispose()
```

Se precisar clonar slides normais junto com seu mestre, veja [Clone Slides](/slides/pt/python-java/clone-slides/).

## **Adicionar vários Slides Mestres**

Uma apresentação pode conter vários slides mestres. Isso é útil quando diferentes seções exigem diferentes identidades visuais, estrutura de página ou configurações de tema.

![Comandos do PowerPoint para inserir e gerenciar slides mestres](slide-master_9.jpg)

O exemplo a seguir clona o mestre padrão, atribui ao clone um fundo diferente, cria um layout sob esse mestre clonado e adiciona um novo slide baseado nesse layout:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, SlideLayoutType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    section_master_slide = presentation.getMasters().addClone(default_master_slide)
    section_master_background_color = Color.LIGHT_GRAY

    section_master_slide.getBackground().setType(BackgroundType.OwnBackground)
    section_master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    section_master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(section_master_background_color)

    source_blank_layout = default_master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)
    if source_blank_layout is None:
        source_blank_layout = default_master_slide.getLayoutSlides().get_Item(0)

    section_blank_layout = section_master_slide.getLayoutSlides().addClone(source_blank_layout)

    presentation.getSlides().addEmptySlide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Comparar Slides Mestres**

Slides mestres podem ser comparados com o método [equals](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseslide/#equals) herdado de [BaseSlide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseslide/). A comparação verifica estrutura e conteúdo estático, como formas, texto, formatação, animações e outras configurações de slide. Não compara identificadores únicos, como IDs de slide, ou valores dinâmicos de marcadores de posição, como a data atual.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

first_presentation = Presentation("first.pptx")
second_presentation = Presentation("second.pptx")
try:
    first_presentation_master_count = first_presentation.getMasters().size()
    second_presentation_master_count = second_presentation.getMasters().size()

    for first_master_index in range(first_presentation_master_count):
        for second_master_index in range(second_presentation_master_count):
            first_master_slide = first_presentation.getMasters().get_Item(first_master_index)
            second_master_slide = second_presentation.getMasters().get_Item(second_master_index)
            are_master_slides_equal = first_master_slide.equals(second_master_slide)

            if are_master_slides_equal:
                print(f"first.pptx master #{first_master_index} equals second.pptx master #{second_master_index}")
finally:
    first_presentation.dispose()
    second_presentation.dispose()
```

Para mais informações, veja [Compare Presentation Slides](/slides/pt/python-java/compare-slides/).

## **Definir a visualização Slide Master como visualização padrão**

Use o método [setLastView](https://reference.aspose.com/slides/pt/python-java/aspose.slides/viewproperties/#setLastView) em [ViewProperties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/viewproperties/) para controlar a visualização que o PowerPoint abre primeiro. O exemplo a seguir abre a apresentação na visualização Slide Master:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation("presentation.pptx")
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Para mais configurações de visualização, veja [Save Presentation](/slides/pt/python-java/save-presentation/).

## **Remover Slides Mestres não usados**

Apresentações às vezes contêm slides mestres que não são mais usados por nenhum slide normal. Remover mestres não utilizados pode reduzir o tamanho do arquivo e simplificar a manutenção de modelos.

Use [removeUnused](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterslidecollection/#removeUnused) para remover mestres não usados da coleção [Presentation.getMasters](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getMasters):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getMasters().removeUnused(True)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Você também pode usar o método de low-code [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/compress/#removeUnusedMasterSlides):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    Compress.removeUnusedMasterSlides(presentation)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Qual é a diferença entre um slide master e um slide de layout?**

Um slide master define configurações de design compartilhadas, como tema, fundo, formas comuns e estilos de texto. Um slide de layout pertence a um slide master e define um arranjo específico de marcadores de posição. Um slide normal usa um slide de layout, herdando tanto do layout quanto do master.

**Uma apresentação pode conter vários slides mestres?**

Sim. Uma apresentação pode conter vários slides mestres. Use múltiplos mestres quando diferentes seções precisarem de sistemas visuais ou identidades diferentes.

**Devo adicionar marcadores de posição a um slide master ou a um slide de layout?**

Na maioria dos casos, adicione marcadores de posição a slides de layout. Coloque elementos visuais compartilhados e formatação comum no slide master e coloque os marcadores de posição de conteúdo nos layouts que os slides normais usarão.

**Posso excluir um slide master que ainda está em uso?**

Não. Um slide master que tem slides dependentes não pode ser removido com segurança diretamente. Primeiro mova esses slides para layouts sob outro master, ou use um método de limpeza de mestres não usados que remova apenas mestres que não estejam em uso.