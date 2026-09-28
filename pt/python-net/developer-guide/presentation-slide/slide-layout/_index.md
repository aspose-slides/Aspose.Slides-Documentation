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
- layout não usado
- visibilidade de rodapé
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
description: "Aplicar, criar e modificar layouts de slide no Aspose.Slides para Python via .NET, adicionar marcadores de posição, remover layouts não usados e controlar a visibilidade de rodapé."
---
## **Visão geral**

Um layout de slide define as posições e a formatação de marcadores de posição, como títulos, texto, imagens, gráficos e tabelas. Aplicar um layout fornece aos slides uma estrutura consistente, permitindo que cada slide contenha seu próprio conteúdo.

Os layouts mais comuns incluem:

- **Slide de Título**: Contém marcadores de posição para título e subtítulo.  
- **Título e Conteúdo**: Contém um marcador de posição para título e um marcador de posição de uso geral para conteúdo.  
- **Em branco**: Não contém marcadores de posição e é útil quando todas as formas serão posicionadas manualmente.

## **Entender a herança de layout**

Uma apresentação possui três níveis relacionados:

1. Um [slide mestre](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masterslide/) define o tema, a formatação compartilhada, os planos de fundo e os objetos comuns.  
1. Um [slide de layout](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutslide/) pertence a um mestre e define um arranjo específico de marcadores de posição.  
1. Um [slide normal](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/) usa um layout e armazena o conteúdo inserido nesse slide.

Um slide normal herda tema e formatação do seu layout, e o layout herda do seu mestre. Um valor definido diretamente em um slide normal substitui o valor herdado naquele nível. Quando um slide normal é criado, suas formas de marcador de posição são geradas a partir do layout selecionado, enquanto o conteúdo inserido nesses marcadores pertence ao slide normal.

Adicione os marcadores de posição necessários a um layout antes de criar slides a partir dele. Adicionar outro marcador de posição a um layout posteriormente não adiciona automaticamente uma forma de marcador correspondente aos slides normais existentes.

Esse relacionamento tem duas consequências importantes:

- Alterar a formatação herdada ou a geometria de marcadores de posição existentes em um layout pode atualizar todos os slides que dependem dele. Antes de editar um layout que já está em uso, inspecione seus slides dependentes e revise a apresentação resultante.  
- Um layout que ainda está sendo usado por um slide não pode ser removido. Reatribua seus slides dependentes a outro layout primeiro, ou remova apenas layouts não utilizados.

Para obter mais informações sobre o nível superior dessa hierarquia, veja [Slide Mestre](/slides/pt/python-net/slide-master/).

Para ocultar logotipos herdados ou formas decorativas do mestre em um slide ou por meio de um layout compartilhado, veja [Controlar a visibilidade de gráficos do mestre](/slides/pt/python-net/slide-master/). O exemplo compara dois slides que usam o mesmo mestre.

## **Selecionar e aplicar um layout de slide**

Use um tipo de layout quando a apresentação segue definições padrão de layout do PowerPoint. Os nomes dos layouts são editáveis pelo usuário e podem ser localizados, portanto a seleção baseada em nome é menos confiável, a menos que você controle o modelo de origem.

O exemplo a seguir procura por **Título e Conteúdo** no primeiro mestre. Se esse layout não estiver disponível, ele recorre deliberadamente a **Em branco**. A segunda verificação de nulo é necessária porque uma apresentação pode conter apenas layouts personalizados. O layout selecionado é então aplicado ao primeiro slide normal através da propriedade [Slide.layout_slide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/layout_slide/).

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

Alterar o layout de um slide não remove formas comuns adicionadas diretamente ao slide. No entanto, as posições dos marcadores de posição, a formatação herdada e a correspondência entre os marcadores existentes e o novo layout podem mudar, portanto inspeccione a saída ao trocar entre layouts substancialmente diferentes.

## **Adicionar um slide de layout**

Seleção e criação são operações distintas. O exemplo anterior seleciona um layout existente; ele não cria um novo. Para criar um layout, chame o método [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masterlayoutslidecollection/add/) na coleção de layouts do mestre de destino.

O exemplo a seguir sempre adiciona um novo layout **Título e Conteúdo** chamado `Report Title and Content`, e então adiciona um slide normal baseado nele. Os nomes dos layouts devem ser exclusivos dentro da coleção.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

Adicione um layout somente quando o modelo realmente precisar de outra estrutura reutilizável. Se já existir um layout adequado, selecione‑o e reutilize‑o em vez de criar um duplicado.

## **Adicionar marcadores de posição a um slide de layout**

A propriedade [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutslide/placeholder_manager/) fornece um [LayoutPlaceholderManager](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutplaceholdermanager/) para acrescentar formas de marcador de posição a um layout.

| Marcador de posição do PowerPoint | Método `LayoutPlaceholderManager` |
| --------------------------------- | --------------------------------- |
| ![Conteúdo](content.png) | [`add_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutplaceholdermanager/add_content_placeholder/) |
| ![Conteúdo (Vertical)](contentV.png) | [`add_vertical_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_content_placeholder/) |
| ![Texto](text.png) | [`add_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutplaceholdermanager/add_text_placeholder/) |
| ![Texto (Vertical)](textV.png) | [`add_vertical_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_text_placeholder/) |
| ![Imagem](picture.png) | [`add_picture_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutplaceholdermanager/add_picture_placeholder/) |
| ![Gráfico](chart.png) | [`add_chart_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutplaceholdermanager/add_chart_placeholder/) |
| ![Tabela](table.png) | [`add_table_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutplaceholdermanager/add_table_placeholder/) |
| ![SmartArt](smartart.png) | [`add_smart_art_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutplaceholdermanager/add_smart_art_placeholder/) |
| ![Mídia](media.png) | [`add_media_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutplaceholdermanager/add_media_placeholder/) |
| ![Imagem online](onlineImage.png) | [`add_online_image_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutplaceholdermanager/add_online_image_placeholder/) |

O exemplo a seguir verifica se o layout **Em branco** existe, acrescenta quatro marcadores de posição a ele e, em seguida, cria um slide normal que usa o layout modificado. A ordem é intencional: os marcadores são adicionados antes da criação do slide normal, permitindo que Aspose.Slides gere as formas de marcador correspondentes naquele slide.

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

![Os marcadores de posição no slide de layout](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Alterar a formatação herdada ou a geometria dos marcadores de posição de um layout pode afetar slides dependentes. Um marcador de posição recém‑adicionado não é retroativo em slides normais existentes. Teste alterações de layout em uma cópia da apresentação e inspecione cada slide dependente.
{{% /alert %}}

## **Remover slides de layout não utilizados**

Use o método [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/pt/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) para excluir layouts que nenhum slide normal referencia. O método deixa intactos os layouts que ainda estão em uso.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

Para remover um layout específico, primeiro verifique sua propriedade [has_depending_slides](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutslide/has_depending_slides/) ou o método [get_depending_slides](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutslide/get_depending_slides/). Reatribua quaisquer slides dependentes antes de chamar [LayoutSlide.remove](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutslide/remove/). Tentar remover um layout em uso gera uma [PptxEditException](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pptxeditexception/).

## **Controlar a visibilidade de rodapé em um slide de layout**

Um layout possui seus próprios marcadores de posição de rodapé, número de slide e data/hora. Use a propriedade [LayoutSlide.header_footer_manager](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutslide/header_footer_manager/) para controlar esses marcadores em um layout. Isso é útil quando, por exemplo, layouts de conteúdo devem exibir rodapés, mas layouts de título não.

O exemplo a seguir seleciona um layout de forma segura e torna seus elementos de rodapé visíveis:

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

## **Controlar a visibilidade de rodapé em um mestre e em seus layouts filhos**

Para aplicar configurações de rodapé consistentes em toda a hierarquia de mestres, use a propriedade [MasterSlide.header_footer_manager](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masterslide/header_footer_manager/). Os métodos de propagação de [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masterslideheaderfootermanager/) atuam no mestre e em seus slides de layout dependentes e slides normais; eles não visam apenas um slide normal.

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

**Qual a diferença entre um slide mestre e um slide de layout?**

Um slide mestre define o tema da apresentação e a formatação compartilhada. Um slide de layout pertence a um mestre e define um arranjo reutilizável de marcadores de posição. Slides normais utilizam esses layouts e armazenam o conteúdo específico de cada slide.

**Posso copiar um slide de layout de uma apresentação para outra?**

Sim. Adicione uma cópia à coleção de destino com o método [add_clone](https://reference.aspose.com/slides/pt/python-net/aspose.slides/globallayoutslidecollection/add_clone/). Ao copiar entre apresentações, verifique também fontes, temas, imagens e outros recursos usados pelo layout de origem.

**O que acontece se eu modificar um layout que já está em uso?**

Slides dependentes herdam as alterações do layout, salvo se substituírem a formatação ou os objetos afetados localmente. A geometria dos marcadores de posição e o estilo herdado podem, portanto, mudar em vários slides simultaneamente. Use [get_depending_slides](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutslide/get_depending_slides/) para identificar os slides afetados antes de editar o layout.

**O que acontece se eu remover um layout que ainda está em uso?**

Aspose.Slides lança uma [PptxEditException](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pptxeditexception/). Reatribua primeiro os slides dependentes ou use [remove_unused_layout_slides](https://reference.aspose.com/slides/pt/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) para remover apenas layouts não referenciados.