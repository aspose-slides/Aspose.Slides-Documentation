---
title: Aplicar ou Alterar Layouts de Slides em Python via Java
linktitle: Layout de Slide
type: docs
weight: 60
url: /pt/python-java/slide-layout/
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
- Java
- Aspose.Slides
description: "Aplicar, criar e modificar layouts de slides em Aspose.Slides para Python via Java, adicionar marcadores de posição, remover layouts não utilizados e controlar a visibilidade do rodapé."
---
## **Visão geral**

Um layout de slide define as posições e formatação de marcadores de posição como títulos, texto, imagens, gráficos e tabelas. Aplicar um layout dá aos slides uma estrutura consistente, permitindo que cada slide contenha seu próprio conteúdo.

Os layouts mais comuns incluem:

- **Slide de Título**: Contém marcadores de posição de título e subtítulo.
- **Título e Conteúdo**: Contém um marcador de posição de título e um marcador de posição de conteúdo de uso geral.
- **Em branco**: Não contém marcadores de posição de conteúdo e é útil quando cada forma será posicionada manualmente.

## **Entender a Herança de Layouts**

Uma apresentação tem três níveis relacionados:

1. A [slide mestre](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterslide/) define o tema, formatação compartilhada, planos de fundo e objetos comuns.
1. A [slide de layout](https://reference.aspose.com/slides/pt/python-java/aspose.slides/layoutslide/) pertence a um mestre e define um arranjo particular de marcadores de posição.
1. A [slide normal](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slide/) usa um layout e armazena o conteúdo inserido para esse slide.

Um slide normal herda o tema e a formatação do seu layout, e o layout herda do seu mestre. Um valor definido diretamente em um slide normal substitui o valor herdado naquele nível. Quando um slide normal é criado, suas formas de marcador de posição são geradas a partir do layout selecionado, enquanto o conteúdo inserido nesses marcadores pertence ao slide normal.

Adicione os marcadores de posição necessários a um layout antes de criar slides a partir dele. Adicionar outro marcador de posição a um layout posteriormente não adiciona automaticamente uma forma de marcador correspondente aos slides normais existentes.

Esse relacionamento tem duas consequências importantes:

- Alterar a formatação herdada ou a geometria de marcadores de posição existentes em um layout pode atualizar todos os slides que dependem dele. Antes de editar um layout já em uso, inspecione seus slides dependentes e revise a apresentação resultante.
- Um layout que ainda é usado por um slide não pode ser removido. Reatribua seus slides dependentes a outro layout primeiro, ou remova apenas layouts não utilizados.

Para mais informações sobre o nível superior desta hierarquia, veja [Mestre de Slide](/slides/pt/python-java/slide-master/).

## **Selecionar e Aplicar um Layout de Slide**

Use um tipo de layout quando a apresentação segue definições padrão de layout do PowerPoint. Os nomes dos layouts são editáveis pelo usuário e podem ser localizados, portanto a seleção baseada em nome é menos confiável a menos que você controle o modelo de origem.

O exemplo a seguir procura por **Título e Conteúdo** no primeiro mestre. Se esse layout não estiver disponível, ele recorre deliberadamente a **Em branco**. A segunda verificação por `None` é necessária porque uma apresentação pode conter apenas layouts personalizados. O layout selecionado é então aplicado ao primeiro slide normal através do método [Slide.setLayoutSlide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slide/#setLayoutSlide).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slides = presentation.getMasters().get_Item(0).getLayoutSlides()
    target_layout = layout_slides.getByType(SlideLayoutType.TitleAndObject)

    if target_layout is None:
        target_layout = layout_slides.getByType(SlideLayoutType.Blank)

    if target_layout is None:
        print("The first master does not contain a suitable layout slide.")
    else:
        presentation.getSlides().get_Item(0).setLayoutSlide(target_layout)
        presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Alterar o layout de um slide não remove formas comuns adicionadas diretamente ao slide. Entretanto, as posições dos marcadores de posição, a formatação herdada e a correspondência entre os marcadores existentes e o novo layout podem mudar, portanto inspeccione a saída ao alternar entre layouts substancialmente diferentes.

## **Adicionar um Slide de Layout**

Seleção e criação são operações separadas. O exemplo anterior seleciona um layout existente; não o cria. Para criar um layout, chame o método [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterlayoutslidecollection/#add) na coleção de layouts do mestre de destino.

O exemplo a seguir sempre adiciona um novo layout **Título e Conteúdo** chamado `Report Title and Content`, depois adiciona um slide normal baseado nele. Os nomes dos layouts devem ser exclusivos dentro da coleção.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    report_layout = master_slide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content")
    presentation.getSlides().addEmptySlide(report_layout)

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Adicione um layout somente quando o modelo realmente precisar de outra estrutura reutilizável. Se já existir um layout adequado, selecione‑o e reutilize‑o em vez de criar um duplicado.

## **Adicionar Marcadores de Posição a um Slide de Layout**

O método [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/layoutslide/#getPlaceholderManager) fornece um [LayoutPlaceholderManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/layoutplaceholdermanager/) para adicionar formas de marcador de posição a um layout.

| Marcador de Posição do PowerPoint | Método LayoutPlaceholderManager |
| --------------------------------- | -------------------------------- |
| ![Conteúdo](content.png)          | [addContentPlaceholder](https://reference.aspose.com/slides/pt/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Conteúdo (Vertical)](contentV.png) | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/pt/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Texto](text.png)                | [addTextPlaceholder](https://reference.aspose.com/slides/pt/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Texto (Vertical)](textV.png)    | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/pt/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Imagem](picture.png)            | [addPicturePlaceholder](https://reference.aspose.com/slides/pt/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Gráfico](chart.png)             | [addChartPlaceholder](https://reference.aspose.com/slides/pt/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Tabela](table.png)              | [addTablePlaceholder](https://reference.aspose.com/slides/pt/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)         | [addSmartArtPlaceholder](https://reference.aspose.com/slides/pt/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Mídia](media.png)               | [addMediaPlaceholder](https://reference.aspose.com/slides/pt/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Imagem Online](onlineImage.png) | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/pt/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

O exemplo a seguir verifica se o layout **Em branco** existe, adiciona quatro marcadores de posição a ele e, em seguida, cria um slide normal que usa o layout modificado. A ordem é intencional: os marcadores são adicionados antes da criação do slide normal, de modo que Aspose.Slides possa gerar as formas de marcador correspondentes naquele slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout is None:
        print("The presentation does not contain a Blank layout slide.")
    else:
        placeholder_manager = blank_layout.getPlaceholderManager()
        placeholder_manager.addContentPlaceholder(20, 20, 310, 270)
        placeholder_manager.addVerticalTextPlaceholder(350, 20, 350, 270)
        placeholder_manager.addChartPlaceholder(20, 310, 310, 180)
        placeholder_manager.addTablePlaceholder(350, 310, 350, 180)

        presentation.getSlides().addEmptySlide(blank_layout)
        presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O resultado:

![Os marcadores de posição no slide de layout](add_placeholders.png)

{{% alert color="warning" title="Aviso" %}}
Alterar a formatação herdada ou a geometria de marcadores de posição existentes no layout pode afetar slides dependentes. Um marcador de posição recém‑adicionado ao layout não é retroalimentado nos slides normais existentes. Teste alterações de layout em uma cópia da apresentação e inspecione cada slide dependente.
{{% /alert %}}

## **Remover Slides de Layout Não Utilizados**

Use o método [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) para remover layouts que nenhum slide normal referencia. O método deixa intactos os layouts que ainda estão em uso.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Para remover um layout específico, primeiro use seu método [hasDependingSlides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/layoutslide/#hasDependingSlides) ou [getDependingSlides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/layoutslide/#getDependingSlides). Reatribua quaisquer slides dependentes antes de chamar [LayoutSlide.remove](https://reference.aspose.com/slides/pt/python-java/aspose.slides/layoutslide/#remove). Tentar remover um layout em uso gera uma [PptxEditException](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pptxeditexception/).

## **Controlar a Visibilidade do Rodapé em um Slide de Layout**

Um layout tem seus próprios marcadores de rodapé, número de slide e data‑hora. Use o método [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/layoutslide/#getHeaderFooterManager) para controlar esses marcadores em um layout. Isso é útil quando, por exemplo, layouts de conteúdo devem mostrar rodapés, mas layouts de título não devem.

O exemplo a seguir seleciona um layout com segurança e torna seus elementos de rodapé visíveis:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)

    if layout_slide is None:
        layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if layout_slide is None:
        print("The presentation does not contain a suitable layout slide.")
    else:
        header_footer_manager = layout_slide.getHeaderFooterManager()
        header_footer_manager.setFooterVisibility(True)
        header_footer_manager.setSlideNumberVisibility(True)
        header_footer_manager.setDateTimeVisibility(True)
        header_footer_manager.setFooterText("Footer text")
        header_footer_manager.setDateTimeText("Date and time text")

        presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Controlar a Visibilidade do Rodapé em um Mestre e em seus Layouts Filhos**

Para aplicar configurações de rodapé consistentes em toda a hierarquia de mestres, use o método [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterslide/#getHeaderFooterManager). Os métodos de propagação de [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterslideheaderfootermanager/) operam no mestre e em seus slides de layout e slides normais dependentes; eles não visam apenas um slide normal.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    header_footer_manager = presentation.getMasters().get_Item(0).getHeaderFooterManager()
    header_footer_manager.setFooterAndChildFootersVisibility(True)
    header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)
    header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)
    header_footer_manager.setFooterAndChildFootersText("Footer text")
    header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Perguntas Frequentes**

**Qual é a diferença entre um slide mestre e um slide de layout?**

Um slide mestre define o tema da apresentação e a formatação compartilhada. Um slide de layout pertence a um mestre e define um arranjo reutilizável de marcadores de posição. Slides normais utilizam esses layouts e armazenam o conteúdo específico de cada slide.

**Posso copiar um slide de layout de uma apresentação para outra?**

Sim. Adicione uma cópia à coleção de destino com o método [addClone](https://reference.aspose.com/slides/pt/python-java/aspose.slides/globallayoutslidecollection/#addClone). Ao copiar entre apresentações, verifique também fontes, temas, imagens e outros recursos usados pelo layout de origem.

**O que acontece quando modifico um layout que já está em uso?**

Slides dependentes herdam as alterações do layout, a menos que substituam a formatação ou os objetos afetados localmente. A geometria dos marcadores de posição e o estilo herdado podem, portanto, mudar em muitos slides de uma só vez. Use [getDependingSlides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/layoutslide/#getDependingSlides) para identificar os slides afetados antes de editar o layout.

**O que acontece se eu remover um layout que ainda está em uso?**

Aspose.Slides lança uma [PptxEditException](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pptxeditexception/). Reatribua primeiro os slides dependentes ou use [removeUnusedLayoutSlides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) para remover apenas layouts não referenciados.