---
title: Aplicar ou Alterar Layouts de Slide em Python
linktitle: Layout de Slide
type: docs
weight: 60
url: /pt/python-net/slide-layout/
keywords:
- layout de slide
- layout de conteúdo
- marcador de posição
- design de apresentação
- design de slide
- layout não utilizado
- visibilidade do rodapé
- slide de título
- título e conteúdo
- cabeçalho de seção
- dois conteúdos
- comparação
- apenas título
- layout em branco
- conteúdo com legenda
- imagem com legenda
- título e texto vertical
- título vertical e texto
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Aplicar, criar e modificar layouts de slide no Aspose.Slides para Python via .NET, adicionar marcadores de posição, remover layouts não utilizados e controlar a visibilidade do rodapé."
---
## **Visão geral**

Um layout de slide define as posições e a formatação dos marcadores de posição, como títulos, texto, imagens, gráficos e tabelas. Aplicar um layout fornece aos slides uma estrutura consistente, permitindo que cada slide contenha seu próprio conteúdo.

Os layouts mais comuns incluem:

- **Title Slide**: Contém marcadores de título e subtítulo.
- **Title and Content**: Contém um marcador de título e um marcador de conteúdo de uso geral.
- **Blank**: Não contém marcadores de conteúdo e é útil quando cada forma será posicionada manualmente.

## **Entender a herança de layout**

Uma apresentação tem três níveis relacionados:

1. Um [master slide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masterslide/) define o tema, formatação compartilhada, fundos e objetos comuns.
2. Um [layout slide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutslide/) pertence a um master e define um arranjo específico de marcadores de posição.
3. Um [normal slide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/) usa um layout e armazena o conteúdo inserido para esse slide.

Um slide normal herda o tema e a formatação do seu layout, e o layout herda do seu master. Um valor definido diretamente em um slide normal substitui o valor herdado nesse nível. Quando um slide normal é criado, suas formas de marcador de posição são geradas a partir do layout selecionado, enquanto o conteúdo inserido nesses marcadores pertence ao slide normal.

Adicione os marcadores de posição necessários a um layout antes de criar slides a partir dele. Adicionar outro marcador de posição a um layout posteriormente não adiciona automaticamente a forma de marcador correspondente aos slides normais existentes.

E esse relacionamento tem duas consequências importantes:

- Mudar a formatação herdada ou a geometria dos marcadores existentes em um layout pode atualizar todos os slides que dependem dele. Antes de editar um layout que já está em uso, inspecione seus slides dependentes e revise a apresentação resultante.
- Um layout que ainda está sendo usado por um slide não pode ser removido. Reatribua seus slides dependentes a outro layout primeiro, ou remova apenas os layouts não utilizados.

Para mais informações sobre o nível superior desta hierarquia, veja [Slide Master](/slides/pt/python-net/slide-master/).

## **Selecionar e aplicar um layout de slide**

Use um tipo de layout quando a apresentação segue as definições padrão de layout do PowerPoint. Os nomes dos layouts são editáveis pelo usuário e podem ser localizados, então a seleção baseada em nome é menos confiável, a menos que você controle o modelo fonte.

O exemplo a seguir procura por **Title and Content** no primeiro master. Se esse layout não estiver disponível, ele recorre deliberadamente ao **Blank**. A segunda verificação nula é necessária porque uma apresentação pode conter apenas layouts personalizados. O layout selecionado é então aplicado ao primeiro slide normal através da propriedade [Slide.layout_slide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/layout_slide/).

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slides = presentation.masters[0].layout_slides
    target_layout = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if target_layout is None:
        target_layout = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if target_layout is None:
        raise RuntimeError("The first master does not contain a suitable layout slide.")

    presentation.slides[0].layout_slide = target_layout
    presentation.save("output-with-new-layout.pptx", slides.export.SaveFormat.PPTX)
```

Mudar o layout de um slide não remove as formas normais adicionadas diretamente ao slide. No entanto, as posições dos marcadores de posição, a formatação herdada e a correspondência entre os marcadores existentes e o novo layout podem mudar, portanto inspecione o resultado ao alternar entre layouts substancialmente diferentes.

## **Adicionar um layout de slide**

A seleção e a criação são operações separadas. O exemplo anterior seleciona um layout existente; não o cria. Para criar um layout, chame o método [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masterlayoutslidecollection/add/) na coleção de layouts do master de destino.

O exemplo a seguir sempre adiciona um novo layout **Title and Content** chamado `Report Title and Content`, então adiciona um slide normal baseado nele. Os nomes dos layouts devem ser exclusivos dentro da coleção.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

Adicione um layout somente quando o modelo realmente precisar de outra estrutura reutilizável. Se já existir um layout adequado, selecione e reutilize‑o em vez de criar um duplicado.

## **Adicionar marcadores de posição a um layout de slide**

A propriedade [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutslide/placeholder_manager/) fornece um [LayoutPlaceholderManager](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutplaceholdermanager/) para adicionar formas de marcador de posição a um layout.

| Placeholder do PowerPoint          | `LayoutPlaceholderManager` Method |
| ----------------------------------- | --------------------------------- |
| Conteúdo                            | [`add_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutplaceholdermanager/add_content_placeholder/) |
| Conteúdo (Vertical)                 | [`add_vertical_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_content_placeholder/) |
| Texto                               | [`add_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutplaceholdermanager/add_text_placeholder/) |
| Texto (Vertical)                    | [`add_vertical_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_text_placeholder/) |
| Imagem                              | [`add_picture_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutplaceholdermanager/add_picture_placeholder/) |
| Gráfico                             | [`add_chart_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutplaceholdermanager/add_chart_placeholder/) |
| Tabela                              | [`add_table_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutplaceholdermanager/add_table_placeholder/) |
| SmartArt                            | [`add_smart_art_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutplaceholdermanager/add_smart_art_placeholder/) |
| Mídia                               | [`add_media_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutplaceholdermanager/add_media_placeholder/) |
| Imagem online                       | [`add_online_image_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutplaceholdermanager/add_online_image_placeholder/) |

O exemplo a seguir verifica se o layout **Blank** existe, adiciona quatro marcadores de posição a ele e, em seguida, cria um slide normal que usa o layout modificado. A ordem é intencional: os marcadores são adicionados antes de o slide normal ser criado, para que o Aspose.Slides possa gerar as formas de marcador correspondentes naquele slide.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout is None:
        raise RuntimeError("The presentation does not contain a Blank layout slide.")

    placeholder_manager = blank_layout.placeholder_manager
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    presentation.slides.add_empty_slide(blank_layout)
    presentation.save("output-with-placeholders.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![Os marcadores de posição no layout do slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Mudar a formatação herdada ou a geometria dos marcadores de posição existentes no layout pode afetar os slides dependentes. Um marcador de posição de layout recém‑adicionado não é preenchido retroativamente nos slides normais existentes. Teste as alterações de layout em uma cópia da apresentação e inspecione cada slide dependente.
{{% /alert %}}

## **Remover layouts de slide não utilizados**

Use o método [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/pt/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) para remover layouts que nenhum slide normal referencia. O método mantém intactos os layouts que ainda estão em uso.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

Para remover um layout específico, primeiro use a propriedade [has_depending_slides](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutslide/has_depending_slides/) ou o método [get_depending_slides](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutslide/get_depending_slides/). Reatribua quaisquer slides dependentes antes de chamar [LayoutSlide.remove](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutslide/remove/). Tentar remover um layout em uso gera uma [PptxEditException](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pptxeditexception/).

## **Controlar a visibilidade do rodapé em um layout de slide**

Um layout tem seus próprios marcadores de rodapé, número de slide e data/hora. Use a propriedade [LayoutSlide.header_footer_manager](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutslide/header_footer_manager/) para controlar esses marcadores em um layout. Isso é útil quando, por exemplo, layouts de conteúdo devem mostrar rodapés, mas layouts de título não.

O exemplo a seguir seleciona um layout com segurança e torna seus elementos de rodapé visíveis:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if layout_slide is None:
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if layout_slide is None:
        raise RuntimeError("The presentation does not contain a suitable layout slide.")

    header_footer_manager = layout_slide.header_footer_manager
    header_footer_manager.set_footer_visibility(True)
    header_footer_manager.set_slide_number_visibility(True)
    header_footer_manager.set_date_time_visibility(True)
    header_footer_manager.set_footer_text("Footer text")
    header_footer_manager.set_date_time_text("Date and time text")

    presentation.save("output-with-layout-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **Controlar a visibilidade do rodapé em um master e seus layouts filhos**

Para aplicar configurações de rodapé consistentes em toda a hierarquia de master, use a propriedade [MasterSlide.header_footer_manager](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masterslide/header_footer_manager/). Os métodos de propagação do [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masterslideheaderfootermanager/) operam no master e em seus slides de layout e slides normais dependentes; eles não visam apenas um slide normal.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager
    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)
    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output-with-master-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Qual é a diferença entre um Master Slide e um Layout Slide?**

Um master slide define o tema da apresentação e a formatação compartilhada. Um layout slide pertence a um master e define um arranjo reutilizável de marcadores de posição. Slides normais usam esses layouts e armazenam o conteúdo específico de cada slide.

**Posso copiar um Layout Slide de uma apresentação para outra?**

Sim. Adicione uma cópia à coleção de destino com o método [add_clone](https://reference.aspose.com/slides/pt/python-net/aspose.slides/globallayoutslidecollection/add_clone/). Ao copiar entre apresentações, também verifique fontes, temas, imagens e outros recursos usados pelo layout de origem.

**O que acontece quando modifico um layout que já está em uso?**

Slides dependentes herdam as alterações do layout, a menos que substituam a formatação ou objetos afetados localmente. A geometria dos marcadores e o estilo herdado podem, portanto, mudar em muitos slides ao mesmo tempo. Use [get_depending_slides](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutslide/get_depending_slides/) para identificar os slides afetados antes de editar o layout.

**O que acontece se eu remover um layout que ainda está em uso?**

O Aspose.Slides gera uma [PptxEditException](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pptxeditexception/). Reatribua primeiro os slides dependentes ou use [remove_unused_layout_slides](https://reference.aspose.com/slides/pt/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) para remover apenas os layouts não referenciados.