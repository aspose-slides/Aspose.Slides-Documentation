---
title: Gerenciar Mestres de Slides de Apresentação em Python via Java
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
- plano de fundo
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

Um **slide master** define configurações de design compartilhadas para um grupo de slides. Ele pode conter formas comuns, logotipos, fundos, estilos de texto, configurações de tema e configurações de rodapé. No PowerPoint, editar um slide master é a maneira usual de manter uma apresentação consistente sem repetir a mesma formatação em cada slide.

Aspose.Slides for Python via Java oferece suporte ao mesmo modelo. Uma apresentação pode conter um ou mais master slides, e cada master slide pode conter vários layout slides. Slides normais geralmente não referenciam um master slide diretamente. Em vez disso, um slide normal usa um layout slide, e esse layout slide pertence a um master slide.

A hierarquia é:

1. **Slide master** - define o design e o tema compartilhados.  
1. **Layout slide** - define um arranjo específico de placeholders e formatação de nível de layout.  
1. **Normal slide** - contém o conteúdo real da apresentação e usa um layout slide.

![A hierarquia de master slides, layout slides e normal slides](slide-master_2.jpg)

No Aspose.Slides, um slide master é representado pela classe [MasterSlide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterslide/) . Todos os master slides em uma apresentação estão disponíveis através da coleção [Presentation.getMasters](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getMasters) , que é representada por [MasterSlideCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterslidecollection/) .

{{% alert color="info" title="Inheritance" %}}
Quando a mesma propriedade é definida em mais de um nível, o nível mais específico prevalece. Por exemplo, se um master slide e um layout slide definirem um fundo, os slides baseados nesse layout usarão o fundo do layout. Para mais informações sobre layout slides, veja [Aplicar ou Alterar Layouts de Slide](/slides/pt/python-java/slide-layout/) .
{{% /alert %}}

## **Acessar Slide Masters**

No PowerPoint, você pode abrir a visualização Slide Master em **View** > **Slide Master**.

![O comando Slide Master na guia View do PowerPoint](slide-master_3.jpg)

No Aspose.Slides, use a coleção [Presentation.getMasters](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getMasters) para acessar master slides:

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

Você também pode obter o master slide usado por um slide normal através de seu layout:

```python
import jpile
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

Um master slide é um objeto semelhante a um slide. Ele herda de [BaseSlide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseslide/) , portanto expõe muitas das mesmas propriedades de slide usadas por slides normais e de layout. Membros específicos de master são listados na página de API [MasterSlide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterslide/) .

Membros de master slide comumente usados incluem:

| Membro | Propósito |
| --- | --- |
| [getBackground](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseslide/#getBackground) | Define o fundo do slide em nível de master. |
| [getShapes](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseslide/#getShapes) | Armazena formas colocadas no master, como logotipos, molduras de imagem e texto compartilhado. |
| [getLayoutSlides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterslide/#getLayoutSlides) | Armazena os layout slides que pertencem ao master. |
| [getThemeManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterslide/#getThemeManager) | Fornece acesso às APIs de tema do master. |
| [getHeaderFooterManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterslide/#getHeaderFooterManager) | Controla cabeçalhos, rodapés, datas e números de slides para o master e seus layouts filhos. |
| [getDependingSlides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterslide/#getDependingSlides) | Retorna slides normais que dependem do master através de seus layouts. |

## **Adicionar uma Imagem a um Slide Master**

Quando você adiciona uma imagem a um master slide, ela aparece nos slides que usam layouts desse master. Isso é útil para logotipos, marcas d'água, faixas decorativas e outros elementos visuais repetidos.

O exemplo a seguir adiciona um logotipo ao primeiro master slide:

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

Para mais informações sobre molduras de imagem, veja [Moldura de Imagem](/slides/pt/python-java/picture-frame/) .

## **Controlar a Visibilidade de Gráficos do Master**

Use [BaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseslide/#setShowMasterShapes) para ocultar gráficos herdados do master, como logotipos ou formas decorativas, sem excluí-los do master. Passe `False` para [Slide.setShowMasterShapes](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slide/#setShowMasterShapes) no slide que deve omitir esses gráficos e mantenha `True` nos slides que devem exibi-los.

O exemplo a seguir cria uma faixa decorativa azul em um master e dois slides que usam o mesmo layout em branco. A faixa está visível no primeiro slide e oculta no segundo. Nenhuma apresentação ou imagem de entrada é necessária.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType, SlideLayoutType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    layout_slide = master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)
    layout_slide.setShowMasterShapes(True)

    slide_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    band = master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slide_height)
    band_color = Color(70, 130, 180)
    band.getFillFormat().setFillType(FillType.Solid)
    band.getFillFormat().getSolidFillColor().setColor(band_color)
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    visible_slide = presentation.getSlides().get_Item(0)
    visible_slide.setLayoutSlide(layout_slide)
    visible_slide.getShapes().clear()

    hidden_slide = presentation.getSlides().addEmptySlide(layout_slide)

    visible_slide.setShowMasterShapes(True)
    hidden_slide.setShowMasterShapes(False)

    presentation.save("master-graphics.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O exemplo usa o layout **Blank** fornecido com uma nova apresentação e remove os placeholders próprios do slide inicial.

### **Escolher o Escopo da Configuração**

Um slide normal usa seu master através de [Slide.getLayoutSlide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slide/#getLayoutSlide) e [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/layoutslide/#getMasterSlide) . Definir a propriedade em um slide individual afeta apenas esse slide. Passar `False` para [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/pt/python-java/aspose.slides/layoutslide/#setShowMasterShapes) oculta os gráficos do master para slides que usam esse layout compartilhado, mesmo que sua própria configuração seja `True`. Para ocultar gráficos em apenas um slide, altere a propriedade do slide e deixe o layout compartilhado inalterado.

A configuração não é suportada como controle de visibilidade no próprio master slide. Em um master, [getShowMasterShapes](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterslide/#getShowMasterShapes) sempre retorna `False`, e passar `True` para [setShowMasterShapes](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterslide/#setShowMasterShapes) gera uma exceção. Aplique-a a um slide normal ou a um layout.

### **Distinguir Gráficos do Fundo**

| Operação | Efeito |
| --- | --- |
| Ocultar gráficos do master | Controla a visibilidade de shapes herdados do master sem excluí-los ou alterar os shapes próprios do slide. |
| Alterar o preenchimento de fundo do slide | Altera a cor, gradiente ou imagem de fundo. Gráficos do master são shapes separados e podem permanecer visíveis sobre esse fundo. Veja [Fundo da Apresentação](/slides/pt/python-java/presentation-background/). |
| Excluir um shape do master | Remove o shape fonte compartilhado, de modo que não esteja mais disponível para nenhum slide que use esse master. |

## **Trabalhar com Placeholders**

Placeholders são normalmente definidos em layout slides. O master slide fornece o estilo e tema compartilhados que esses layouts herdam, enquanto cada layout decide quais placeholders estão disponíveis e onde são posicionados.

No PowerPoint, os comandos de placeholder estão disponíveis na visualização Slide Master.

![O comando Inserir Placeholder na visualização Slide Master do PowerPoint](slide-master_5.png)

Para adicionar novos placeholders com Aspose.Slides, trabalhe com o layout slide que pertence ao master:

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

Você também pode formatar shapes de placeholder que já existam em um master slide. O exemplo a seguir encontra o placeholder de título e aplica um preenchimento de gradiente linear:

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

![Placeholder de título formatado herdado por slides normais](slide-master_8.png)

Para mais opções de placeholder e formatação de texto, veja [Definir Texto de Prompt em Placeholder](/slides/pt/python-java/manage-placeholder/) e [Formatação de Texto](/slides/pt/python-java/text-formatting/) .

## **Alterar o Fundo de um Slide Master**

Um fundo de master é herdado por layouts e slides que não o substituem. O exemplo a seguir define uma cor de fundo sólida para o primeiro master slide:

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

Para tópicos relacionados, veja [Fundo da Apresentação](/slides/pt/python-java/presentation-background/) e [Tema da Apresentação](/slides/pt/python-java/presentation-theme/) .

## **Clonar um Slide Master para outra Apresentação**

Use [MasterSlideCollection.addClone](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterslidecollection/#addClone) para copiar um master slide para outra apresentação. O master copiado pode então ser usado por layouts e slides na apresentação de destino.

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

Se precisar clonar slides normais junto com seu master, veja [Clonar Slides](/slides/pt/python-java/clone-slides/) .

## **Adicionar Vários Slide Masters**

Uma apresentação pode conter múltiplos master slides. Isso é útil quando diferentes seções requerem diferentes marcas, estrutura de página ou configurações de tema.

![Comandos do PowerPoint para inserir e gerenciar master slides](slide-master_9.jpg)

O exemplo a seguir clona o master padrão, atribui ao clone um fundo diferente, cria um layout sob esse master clonado e adiciona um novo slide baseado nesse layout:

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

## **Comparar Slide Masters**

Master slides podem ser comparados com o método [equals](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseslide/#equals) herdado de [BaseSlide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseslide/) . A comparação verifica a estrutura e o conteúdo estático, como shapes, texto, formatação, animações e outras configurações de slide. Não compara identificadores únicos, como IDs de slide, ou valores dinâmicos de placeholder, como a data atual.

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

Para mais informações, veja [Comparar Slides da Apresentação](/slides/pt/python-java/compare-slides/) .

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

Para mais configurações de visualização, veja [Salvar Apresentação](/slides/pt/python-java/save-presentation/) .

## **Remover Slide Masters Não Utilizados**

As apresentações às vezes contêm master slides que não são mais usados por nenhum slide normal. Remover masters não utilizados pode reduzir o tamanho do arquivo e simplificar a manutenção do modelo.

Use [removeUnused](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterslidecollection/#removeUnused) para remover masters não utilizados da coleção [Presentation.getMasters](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getMasters) :

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

Você também pode usar o método low-code [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/compress/#removeUnusedMasterSlides) :

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

**Qual é a diferença entre um slide master e um layout slide?**

Um slide master define configurações de design compartilhadas, como tema, fundo, formas comuns e estilos de texto. Um layout slide pertence a um slide master e define um arranjo específico de placeholders. Um slide normal usa um layout slide, portanto herda tanto do layout quanto do master.

**Uma apresentação pode conter vários slide masters?**

Sim. Uma apresentação pode conter vários slide masters. Use múltiplos masters quando diferentes seções precisam de diferentes sistemas visuais ou branding.

**Devo adicionar placeholders a um master slide ou a um layout slide?**

Na maioria dos casos, adicione placeholders a layout slides. Coloque elementos visuais compartilhados e formatação compartilhada no master slide, e coloque os placeholders de conteúdo nos layouts que os slides normais usarão.

**Posso excluir um master slide que ainda está sendo usado?**

Não. Um master slide que tem slides dependentes não pode ser removido com segurança diretamente. Primeiro mova esses slides para layouts sob outro master, ou use um método de limpeza de masters não usados que remove apenas masters que não estão em uso.