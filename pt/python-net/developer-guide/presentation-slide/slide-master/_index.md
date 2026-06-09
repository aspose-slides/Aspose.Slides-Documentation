---
title: Gerenciar Mestres de Slides de Apresentação em Python
linktitle: Mestre de Slide
type: docs
weight: 80
url: /pt/python-net/slide-master/
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
- slide mestre não utilizado
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Gerenciar mestres de slides no Aspose.Slides para Python via .NET: acessar, editar, clonar, comparar e remover slides mestres em apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

Um **slide master** define configurações de design compartilhadas para um grupo de slides. Ele pode conter formas comuns, logotipos, planos de fundo, estilos de texto, configurações de tema e configurações de rodapé. No PowerPoint, editar um slide master é a forma usual de manter uma apresentação consistente sem repetir a mesma formatação em cada slide.

Aspose.Slides for Python via .NET suporta o mesmo modelo. Uma apresentação pode conter um ou mais master slides, e cada master slide pode conter vários layout slides. Slides normais normalmente não se referem diretamente a um master slide. Em vez disso, um slide normal usa um layout slide, e esse layout slide pertence a um master slide.

A hierarquia é:

1. **Slide master** – define o design e tema compartilhados.  
2. **Layout slide** – define um arranjo específico de marcadores de posição e formatação em nível de layout.  
3. **Normal slide** – contém o conteúdo real da apresentação e usa um layout slide.

![A hierarquia de master slides, layout slides e slides normais](slide-master_2.jpg)

Em Aspose.Slides, um slide master é representado pela classe [MasterSlide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masterslide/) . Todos os master slides em uma apresentação estão disponíveis através da coleção `Presentation.masters`.

{{% alert color="info" title="Inheritance" %}}
Quando a mesma propriedade é definida em mais de um nível, o nível mais específico prevalece. Por exemplo, se um master slide e um layout slide definirem um plano de fundo, os slides baseados naquele layout usarão o plano de fundo do layout. Para mais informações sobre layout slides, veja [Aplicar ou Alterar Layouts de Slides](/python-net/slide-layout/).
{{% /alert %}}

## **Acessar Slide Masters**

No PowerPoint, você pode abrir a visualização de Slide Master a partir de **Exibir** > **Slide Master**.

![O comando Slide Master na guia Exibir do PowerPoint](slide-master_3.jpg)

Em Aspose.Slides, use a coleção `masters` para acessar master slides:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

Você também pode obter o master slide usado por um slide normal através de seu layout:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **O que um Slide Master Contém**

Um master slide é um objeto semelhante a um slide. Ele herda o comportamento comum de slide da classe [BaseSlide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseslide/) , portanto expõe muitas das mesmas propriedades de slide usadas por slides normais e de layout. Os membros específicos de master estão listados na página da API [MasterSlide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masterslide/) .

Membros de master slide usados com frequência incluem:

| Membro | Finalidade |
| --- | --- |
| `background` | Define o plano de fundo do slide ao nível do master. |
| `shapes` | Armazena formas colocadas no master, como logotipos, quadros de imagem e texto compartilhado. |
| `layout_slides` | Armazena os layout slides que pertencem ao master. |
| `theme_manager` | Fornece acesso às APIs de tema do master. |
| `header_footer_manager` | Controla cabeçalhos, rodapés, datas e números de slide para o master e seus layouts filhos. |
| `get_depending_slides` | Retorna slides normais que dependem do master através de seus layouts. |

## **Adicionar uma Imagem a um Slide Master**

Quando você adiciona uma imagem a um master slide, ela aparece nos slides que usam layouts desse master. Isso é útil para logotipos, marcas d'água, faixas decorativas e outros elementos visuais repetidos.

O exemplo a seguir adiciona um logotipo ao primeiro master slide:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    with open("logo.png", "rb") as logo_stream:
        logo_bytes = logo_stream.read()

    logo_image = presentation.images.add_image(logo_bytes)

    master_slide.shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE,
        20,
        20,
        80,
        80,
        logo_image)

    presentation.save("presentation-with-logo.pptx", slides.export.SaveFormat.PPTX)
```

Para obter mais informações sobre quadros de imagem, veja [Quadro de Imagem](/python-net/picture-frame/).

## **Trabalhar com Marcadores de Posição**

Marcadores de posição são normalmente definidos em layout slides. O master slide fornece o estilo e tema compartilhados que esses layouts herdam, enquanto cada layout decide quais marcadores de posição estão disponíveis e onde eles são colocados.

No PowerPoint, os comandos de marcador de posição estão disponíveis na visualização de Slide Master.

![O comando Inserir Marcador de Posição na visualização de Slide Master do PowerPoint](slide-master_5.png)

Para adicionar novos marcadores de posição com Aspose.Slides, trabalhe com o layout slide que pertence ao master:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    blank_layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout_slide is None:
        blank_layout_slide = presentation.layout_slides.add(
            master_slide,
            slides.SlideLayoutType.BLANK,
            "Blank")

    blank_layout_slide.placeholder_manager.add_text_placeholder(60, 120, 600, 80)

    presentation.slides.add_empty_slide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", slides.export.SaveFormat.PPTX)
```

Você também pode formatar formas de marcador de posição que já existem em um master slide. O exemplo a seguir localiza o marcador de posição de título e aplica um preenchimento de gradiente linear:

```python
import aspose.pydrawing as draw
import aspose.slides as slides


def find_placeholder(master_slide, placeholder_type):
    for shape in master_slide.shapes:
        if isinstance(shape, slides.AutoShape) and shape.placeholder is not None:
            if shape.placeholder.type == placeholder_type:
                return shape

    return None


with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    title_placeholder = find_placeholder(master_slide, slides.PlaceholderType.TITLE)

    if title_placeholder is not None:
        red_gradient_color = draw.Color.from_argb(255, 0, 0)
        purple_gradient_color = draw.Color.from_argb(128, 0, 128)

        title_placeholder.fill_format.fill_type = slides.FillType.GRADIENT
        title_placeholder.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
        title_placeholder.fill_format.gradient_format.gradient_stops.add(0, red_gradient_color)
        title_placeholder.fill_format.gradient_format.gradient_stops.add(255, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![Marcador de posição de título formatado herdado por slides normais](slide-master_8.png)

Para mais opções de formatação de marcadores de posição e texto, veja [Definir Texto de Prompt em Marcador de Posição](/python-net/manage-placeholder/) e [Formatação de Texto](/python-net/text-formatting/).

## **Alterar o Plano de Fundo de um Slide Master**

Um plano de fundo de master é herdado por layouts e slides que não o sobrescrevem. O exemplo a seguir define uma cor de plano de fundo sólida para o primeiro master slide:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    presentation.save("presentation-master-background.pptx", slides.export.SaveFormat.PPTX)
```

Para tópicos relacionados, veja [Plano de Fundo da Apresentação](/python-net/presentation-background/) e [Tema da Apresentação](/python-net/presentation-theme/).

## **Clonar um Slide Master para Outra Apresentação**

Use o método `add_clone` na classe [MasterSlideCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masterslidecollection/) para copiar um master slide para outra apresentação. O master copiado pode então ser usado por layouts e slides na apresentação de destino.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Se precisar clonar slides normais juntamente com seu master, veja [Clonar Slides](/python-net/clone-slides/).

## **Adicionar Vários Slide Masters**

Uma apresentação pode conter múltiplos master slides. Isso é útil quando diferentes seções exigem marcas diferentes, estrutura de página ou configurações de tema distintas.

![Comandos do PowerPoint para inserir e gerenciar master slides](slide-master_9.jpg)

O exemplo a seguir clona o master padrão, dá ao clone um plano de fundo diferente, obtém um layout em branco sob esse master clonado e adiciona um novo slide baseado nesse layout:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    default_master_slide = presentation.masters[0]
    section_master_slide = presentation.masters.add_clone(default_master_slide)

    section_master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    section_master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    section_master_slide.background.fill_format.solid_fill_color.color = draw.Color.light_steel_blue

    section_blank_layout = section_master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if section_blank_layout is None:
        section_blank_layout = presentation.layout_slides.add(
            section_master_slide,
            slides.SlideLayoutType.BLANK,
            "Section Blank")

    presentation.slides.add_empty_slide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", slides.export.SaveFormat.PPTX)
```

## **Comparar Slide Masters**

Master slides podem ser comparados com o método `equals` herdado da classe [BaseSlide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseslide/) . A comparação verifica estrutura e conteúdo estático, como formas, texto, formatação, animações e outras configurações de slide. Não compara identificadores únicos, como IDs de slide, ou valores dinâmicos de marcadores de posição, como a data atual.

```python
import aspose.slides as slides

with slides.Presentation("first.pptx") as first_presentation:
    with slides.Presentation("second.pptx") as second_presentation:
        first_presentation_master_count = len(first_presentation.masters)
        second_presentation_master_count = len(second_presentation.masters)

        for first_master_index in range(first_presentation_master_count):
            for second_master_index in range(second_presentation_master_count):
                first_master_slide = first_presentation.masters[first_master_index]
                second_master_slide = second_presentation.masters[second_master_index]
                are_master_slides_equal = first_master_slide.equals(second_master_slide)

                if are_master_slides_equal:
                    print(
                        "first.pptx master #{} equals second.pptx master #{}".format(
                            first_master_index,
                            second_master_index))
```

Para mais informações, veja [Comparar Slides da Apresentação](/python-net/compare-slides/).

## **Definir a Visualização de Slide Master como Visualização Padrão**

Use a propriedade `last_view` em [ViewProperties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/viewproperties/) da apresentação para controlar a visualização que o PowerPoint abre primeiro. O exemplo a seguir abre a apresentação na visualização de Slide Master:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

Para mais configurações de visualização, veja [Salvar Apresentação](/python-net/save-presentation/).

## **Remover Master Slides Não Utilizados**

Apresentações às vezes contêm master slides que não são mais usados por nenhum slide normal. Remover masters não utilizados pode reduzir o tamanho do arquivo e simplificar a manutenção de modelos.

Use `remove_unused` para remover masters não utilizados da coleção `masters`:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

Você também pode usar o método low-code `remove_unused_master_slides` da classe [Compress](https://reference.aspose.com/slides/pt/python-net/aspose.slides.lowcode/compress/) :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Qual é a diferença entre um slide master e um layout slide?**

Um slide master define configurações de design compartilhadas, como tema, plano de fundo, formas comuns e estilos de texto. Um layout slide pertence a um master slide e define um arranjo específico de marcadores de posição. Um slide normal usa um layout slide, herdando assim tanto do layout quanto do master.

**Uma apresentação pode conter vários slide masters?**

Sim. Uma apresentação pode conter vários slide masters. Use múltiplos masters quando diferentes seções precisarem de sistemas visuais ou marcas distintas.

**Devo adicionar marcadores de posição a um master slide ou a um layout slide?**

Na maioria dos casos, adicione marcadores de posição a layout slides. Coloque elementos visuais compartilhados e formatação comum no master slide e coloque os marcadores de posição de conteúdo nos layouts que os slides normais usarão.

**Posso excluir um master slide que ainda está em uso?**

Não. Um master slide que possui slides dependentes não pode ser removido com segurança diretamente. Primeiro mova esses slides para layouts sob outro master, ou use um método de limpeza de masters não utilizados que remove apenas masters que não estão em uso.