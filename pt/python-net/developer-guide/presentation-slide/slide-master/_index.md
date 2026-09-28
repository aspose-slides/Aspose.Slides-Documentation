---
title: Gerenciar slides master de apresentação em Python
linktitle: Mestre de Slides
type: docs
weight: 80
url: /pt/python-net/slide-master/
keywords:
- master de slide
- slide mestre
- slide mestre PPT
- múltiplos masters de slide
- comparar masters de slide
- plano de fundo
- marcador de posição
- clonar slide master
- copiar slide master
- duplicar slide master
- slide master não usado
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Gerencie masters de slides no Aspose.Slides para Python via .NET: acesse, edite, clone, compare e remova slides master em apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

Um **slide master** define configurações de design compartilhadas para um grupo de slides. Ele pode conter formas comuns, logotipos, planos de fundo, estilos de texto, configurações de tema e configurações de rodapé. No PowerPoint, editar um slide master é a forma usual de manter uma apresentação consistente sem repetir a mesma formatação em cada slide.

Aspose.Slides for Python via .NET oferece o mesmo modelo. Uma apresentação pode conter um ou mais slide masters, e cada slide master pode conter vários layout slides. Slides normais normalmente não referenciam um slide master diretamente. Em vez disso, um slide normal usa um layout slide, e esse layout slide pertence a um slide master.

A hierarquia é:

1. **Slide master** – define o design e o tema compartilhados.  
1. **Layout slide** – define um arranjo específico de marcadores de posição e formatação ao nível do layout.  
1. **Slide normal** – contém o conteúdo real da apresentação e usa um layout slide.

![A hierarquia de slide masters, layout slides e slides normais](slide-master_2.jpg)

No Aspose.Slides, um slide master é representado pela classe [MasterSlide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masterslide/). Todos os slide masters em uma apresentação estão disponíveis através da coleção `Presentation.masters`.

{{% alert color="info" title="Inheritance" %}}
Quando a mesma propriedade é definida em mais de um nível, o nível mais específico prevalece. Por exemplo, se um slide master e um layout slide ambos definirem um plano de fundo, os slides baseados nesse layout usarão o plano de fundo do layout. Para mais informações sobre layout slides, veja [Aplicar ou Alterar Layout de Slides](/slides/pt/python-net/slide-layout/).
{{% /alert %}}

## **Acessar Slide Masters**

No PowerPoint, você pode abrir a visualização do Slide Master em **Exibir** > **Slide Master**.

![O comando Slide Master na guia Exibir do PowerPoint](slide-master_3.jpg)

No Aspose.Slides, use a coleção `masters` para acessar slide masters:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

Você também pode obter o slide master usado por um slide normal através de seu layout:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **O que um Slide Master contém**

Um slide master é um objeto semelhante a um slide. Ele herda o comportamento comum de slides da classe [BaseSlide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseslide/), portanto expõe muitas das mesmas propriedades de slide usadas por slides normais e de layout. Membros específicos do master estão listados na página da API [MasterSlide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masterslide/).

Membros de slide master frequentemente usados incluem:

| Membro | Finalidade |
| --- | --- |
| `background` | Define o plano de fundo ao nível do master. |
| `shapes` | Armazena formas colocadas no master, como logotipos, quadros de imagem e texto compartilhado. |
| `layout_slides` | Armazena os layout slides que pertencem ao master. |
| `theme_manager` | Fornece acesso às APIs de tema do master. |
| `header_footer_manager` | Controla cabeçalhos, rodapés, datas e numeração de slides para o master e seus layouts filhos. |
| `get_depending_slides` | Retorna slides normais que dependem do master por meio de seus layouts. |

## **Adicionar uma imagem a um Slide Master**

Ao adicionar uma imagem a um slide master, ela aparece nos slides que usam layouts desse master. Isso é útil para logotipos, marcas d’água, faixas decorativas e outros elementos visuais repetidos.

O exemplo a seguir adiciona um logotipo ao primeiro slide master:

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

Para mais informações sobre quadros de imagem, veja [Quadro de Imagem](/slides/pt/python-net/picture-frame/).

## **Controlar a visibilidade de gráficos do master**

Use [BaseSlide.show_master_shapes](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseslide/show_master_shapes/) para ocultar gráficos herdados do master, como logotipos ou formas decorativas, sem excluí‑los do master. Defina [Slide.show_master_shapes](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/show_master_shapes/) como `False` no slide que deve omitir esses gráficos e mantenha‑o `True` nos slides que devem exibi‑los.

O exemplo autônomo a seguir cria uma faixa decorativa azul em um master e dois slides que usam o mesmo layout em branco. A faixa fica visível no primeiro slide e oculta no segundo. Nenhuma apresentação ou imagem de entrada é necessária.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]
    layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    layout_slide.show_master_shapes = True

    slide_height = presentation.slide_size.size.height
    band = master_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 60, slide_height)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.steel_blue
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    visible_slide = presentation.slides[0]
    visible_slide.layout_slide = layout_slide
    visible_slide.shapes.clear()

    hidden_slide = presentation.slides.add_empty_slide(layout_slide)

    visible_slide.show_master_shapes = True
    hidden_slide.show_master_shapes = False

    presentation.save("master-graphics.pptx", slides.export.SaveFormat.PPTX)
```

O exemplo usa o layout **Blank** fornecido com uma nova apresentação e remove os marcadores de posição próprios do slide inicial.

### **Escolher o escopo da configuração**

Um slide normal usa seu master por meio de [Slide.layout_slide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/layout_slide/) e [LayoutSlide.master_slide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutslide/master_slide/). Definir a propriedade em um slide individual afeta somente esse slide. Definir [LayoutSlide.show_master_shapes](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutslide/show_master_shapes/) como `False` oculta os gráficos do master para slides que usam esse layout compartilhado, mesmo que sua própria configuração seja `True`. Para ocultar gráficos em apenas um slide, altere a propriedade do slide e deixe o layout compartilhado inalterado.

A configuração não é suportada como controle de visibilidade no próprio slide master. Em um master ela sempre retorna `False`, e atribuir `True` gera uma exceção. Aplique‑a a um slide normal ou a um layout.

### **Diferenciar gráficos do plano de fundo**

| Operação | Efeito |
| --- | --- |
| Ocultar gráficos do master | Controla a visibilidade das formas herdadas do master sem excluí‑las ou alterar as próprias formas do slide. |
| Alterar o preenchimento de fundo do slide | Altera a cor, gradiente ou imagem de fundo. Gráficos do master são formas separadas e podem permanecer visíveis sobre esse fundo. Veja [Plano de Fundo da Apresentação](/slides/pt/python-net/presentation-background/). |
| Excluir uma forma do master | Remove a forma fonte compartilhada, de modo que não fique mais disponível para nenhum slide que use esse master. |

## **Trabalhar com marcadores de posição**

Marcadores de posição são normalmente definidos em layout slides. O slide master fornece o estilo e o tema compartilhados que esses layouts herdam, enquanto cada layout decide quais marcadores de posição estão disponíveis e onde são colocados.

No PowerPoint, os comandos de marcador de posição estão disponíveis na visualização do Slide Master.

![O comando Inserir Marcador de Posição na visualização do Slide Master do PowerPoint](slide-master_5.png)

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

Você também pode formatar formas de marcador de posição que já existam em um slide master. O exemplo a seguir encontra o marcador de posição de título e aplica um preenchimento de gradiente linear:

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
        title_placeholder.fill_format.gradient_format.gradient_stops.add(1, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![Título formatado herdado por slides normais](slide-master_8.png)

Para mais opções de formatação de marcadores e texto, veja [Definir texto de sugestão em marcador](/slides/pt/python-net/manage-placeholder/) e [Formatação de Texto](/slides/pt/python-net/text-formatting/).

## **Alterar o plano de fundo de um Slide Master**

Um plano de fundo de master é herdado por layouts e slides que não o substituem. O exemplo a seguir define uma cor de fundo sólida para o primeiro slide master:

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

Para tópicos relacionados, veja [Plano de Fundo da Apresentação](/slides/pt/python-net/presentation-background/) e [Tema da Apresentação](/slides/pt/python-net/presentation-theme/).

## **Clonar um Slide Master para outra apresentação**

Use o método `add_clone` na classe [MasterSlideCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masterslidecollection/) para copiar um slide master para outra apresentação. O master copiado pode então ser usado por layouts e slides na apresentação de destino.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Se precisar clonar slides normais juntamente com seu master, veja [Clonar Slides](/slides/pt/python-net/clone-slides/).

## **Adicionar vários Slide Masters**

Uma apresentação pode conter vários slide masters. Isso é útil quando diferentes seções exigem diferentes identidades visuais, estruturas de página ou configurações de tema.

![Comandos do PowerPoint para inserir e gerenciar slide masters](slide-master_9.jpg)

O exemplo a seguir clona o master padrão, atribui ao clone um plano de fundo diferente, obtém um layout em branco sob esse master clonado e adiciona um novo slide baseado nesse layout:

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

Slide masters podem ser comparados com o método `equals` herdado da classe [BaseSlide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseslide/). A comparação verifica estrutura e conteúdo estático, como formas, texto, formatação, animações e outras configurações de slide. Não compara identificadores únicos, como IDs de slide, ou valores dinâmicos de marcadores, como a data atual.

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

Para mais informações, veja [Comparar Slides da Apresentação](/slides/pt/python-net/compare-slides/).

## **Definir a visualização de Slide Master como a visualização padrão**

Use a propriedade `last_view` em [ViewProperties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/viewproperties/) da apresentação para controlar a visualização que o PowerPoint abre inicialmente. O exemplo a seguir abre a apresentação na visualização de Slide Master:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

Para mais configurações de visualização, veja [Salvar Apresentação](/slides/pt/python-net/save-presentation/).

## **Remover Slide Masters não utilizados**

Apresentações às vezes contêm slide masters que não são mais usados por nenhum slide normal. Remover masters não utilizados pode reduzir o tamanho do arquivo e simplificar a manutenção de modelos.

Use `remove_unused` para remover masters não utilizados da coleção `masters`:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

Você também pode usar o método de low‑code `remove_unused_master_slides` da classe [Compress](https://reference.aspose.com/slides/pt/python-net/aspose.slides.lowcode/compress/):

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **Perguntas frequentes**

**Qual a diferença entre um slide master e um layout slide?**  
Um slide master define configurações de design compartilhadas como tema, plano de fundo, formas comuns e estilos de texto. Um layout slide pertence a um slide master e define um arranjo específico de marcadores de posição. Um slide normal usa um layout slide, herdando tanto do layout quanto do master.

**Uma apresentação pode conter vários slide masters?**  
Sim. Uma apresentação pode conter vários slide masters. Use múltiplos masters quando diferentes seções necessitam de sistemas visuais ou identidades de marca distintas.

**Devo adicionar marcadores de posição a um slide master ou a um layout slide?**  
Na maioria dos casos, adicione marcadores de posição aos layout slides. Coloque elementos visuais compartilhados e formatação comum no slide master e coloque os marcadores de conteúdo nos layouts que os slides normais usarão.

**Posso excluir um slide master que ainda está em uso?**  
Não. Um slide master que possui slides dependentes não pode ser removido com segurança diretamente. Primeiro mova esses slides para layouts sob outro master, ou use um método de limpeza de masters não utilizados que remova apenas masters que não estejam em uso.