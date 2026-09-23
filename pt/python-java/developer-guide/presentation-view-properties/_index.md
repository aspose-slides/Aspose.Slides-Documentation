---
title: Recuperar e Atualizar Propriedades de Visualização da Apresentação em Python via Java
linktitle: Propriedades de Visualização
type: docs
weight: 80
url: /pt/python-java/presentation-view-properties/
keywords:
- propriedades de visualização
- visualização normal
- conteúdo de contorno
- ícones de contorno
- ajustar divisor vertical
- visualização única
- estado da barra
- tamanho da dimensão
- ajuste automático
- zoom padrão
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Descubra as propriedades de visualização do Aspose.Slides for Python via Java para personalizar slides PPT, PPTX e ODP — ajuste layouts, níveis de zoom e configurações de exibição."
---
## **Introdução**

A visualização normal consiste em três regiões de conteúdo: o próprio slide, uma região de conteúdo lateral e uma região de conteúdo inferior. As propriedades da visualização normal descrevem o posicionamento dessas regiões de conteúdo. Essas informações permitem que o aplicativo salve seu estado de visualização no arquivo, de modo que, ao reabri‑lo, a visualização esteja no mesmo estado em que a apresentação foi salva pela última vez.

O método [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/viewproperties/#getNormalViewProperties) foi adicionado para fornecer acesso às propriedades da visualização normal de uma apresentação.

As classes [NormalViewProperties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/normalviewrestoredproperties/) e a enumeração [SplitterBarStateType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/splitterbarstatetype/) foram adicionadas.

## **Sobre NormalViewProperties**

Representa as propriedades da visualização normal.

Os métodos [getShowOutlineIcons](https://reference.aspose.com/slides/pt/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) e [setShowOutlineIcons](https://reference.aspose.com/slides/pt/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) especificam se o aplicativo deve exibir ícones ao apresentar o conteúdo do contorno em qualquer das regiões de conteúdo do modo de visualização normal.

Os métodos [getSnapVerticalSplitter](https://reference.aspose.com/slides/pt/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) e [setSnapVerticalSplitter](https://reference.aspose.com/slides/pt/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) especificam se o divisor vertical deve ser reduzido a um estado minimizado quando a região lateral for suficientemente pequena.

Os métodos [getPreferSingleView](https://reference.aspose.com/slides/pt/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) e [setPreferSingleView](https://reference.aspose.com/slides/pt/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) especificam se o usuário prefere ver uma única região de conteúdo em janela inteira ao invés da visualização normal padrão com três regiões de conteúdo. Se habilitado, o aplicativo pode optar por exibir uma das regiões de conteúdo em toda a janela.

Os métodos [getVerticalBarState](https://reference.aspose.com/slides/pt/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) e [getHorizontalBarState](https://reference.aspose.com/slides/pt/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) especificam o estado em que a barra de divisor horizontal ou vertical deve ser exibida. Uma barra de divisor horizontal separa o slide da região de conteúdo abaixo do slide; uma barra de divisor vertical separa o slide da região de conteúdo lateral. Os valores possíveis são: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/pt/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/pt/python-java/aspose.slides/splitterbarstatetype/#Maximized) e [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pt/python-java/aspose.slides/splitterbarstatetype/#Restored).

Os métodos [getRestoredLeft](https://reference.aspose.com/slides/pt/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) e [getRestoredTop](https://reference.aspose.com/slides/pt/python-java/aspose.slides/normalviewproperties/#getRestoredTop) especificam o dimensionamento da região superior ou lateral do slide na visualização normal, quando o valor [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pt/python-java/aspose.slides/splitterbarstatetype/#Restored) é aplicado a [getVerticalBarState](https://reference.aspose.com/slides/pt/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) e [getHorizontalBarState](https://reference.aspose.com/slides/pt/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState), respectivamente.

## **Sobre Restaurar NormalViewProperties**

Especifica o dimensionamento da região do slide (largura quando filho de [getRestoredTop](https://reference.aspose.com/slides/pt/python-java/aspose.slides/normalviewproperties/#getRestoredTop), altura quando filho de [getRestoredLeft](https://reference.aspose.com/slides/pt/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) da visualização normal, quando a região possui um tamanho restaurado variável (nem minimizado nem maximizado).

O método [getDimensionSize](https://reference.aspose.com/slides/pt/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) especifica o tamanho da região do slide (largura quando filho de [getRestoredTop](https://reference.aspose.com/slides/pt/python-java/aspose.slides/normalviewproperties/#getRestoredTop), altura quando filho de [getRestoredLeft](https://reference.aspose.com/slides/pt/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

O método [getAutoAdjust](https://reference.aspose.com/slides/pt/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) especifica se o tamanho da região de conteúdo lateral deve compensar o novo tamanho ao redimensionar a janela que contém a visualização dentro do aplicativo.

O exemplo abaixo mostra como acessar [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/viewproperties/#getNormalViewProperties) para uma apresentação.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation()
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    # Restaurar as propriedades de visualização da apresentação.
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Definir o Valor de Zoom Padrão**

{{% alert color="info" title="Note" %}}
O Aspose.Slides for Python via Java suporta a definição do valor de zoom padrão para que ele já seja aplicado quando a apresentação for aberta. Isso pode ser feito definindo as [ViewProperties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/viewproperties/) de uma apresentação. [getSlideViewProperties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/viewproperties/#getSlideViewProperties) assim como [getNotesViewProperties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/viewproperties/#getNotesViewProperties) podem ser configurados programaticamente. Neste tópico, veremos com um exemplo como definir as [View Properties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/viewproperties/) de [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) no Aspose.Slides.
{{% /alert %}}

Para definir as propriedades de visualização, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
1. Defina as [View Properties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/viewproperties/) de [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
1. Grave a apresentação como um arquivo [PPTX](https://docs.fileformat.com/presentation/pptx/).

No exemplo abaixo, definimos o valor de zoom tanto para a visualização de slide quanto para a visualização de notas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Definir as propriedades de visualização da apresentação.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # Porcentagem de zoom para a visualização de slide.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # Porcentagem de zoom para a visualização de notas.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Definir o Espaçamento da Grade**

Use [Presentation.getViewProperties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getViewProperties) para acessar as configurações de visualização em todo o documento. Os métodos [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/pt/python-java/aspose.slides/viewproperties/#getGridSpacing) e [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/pt/python-java/aspose.slides/viewproperties/#setGridSpacing) leem ou alteram o intervalo da grade de edição subjacente. Essa configuração se aplica a toda a apresentação, não a um slide individual. O espaçamento da grade é especificado em pontos, onde 72 pontos equivalem a uma polegada. Use um valor positivo, conforme exigido pela documentação da API.

O exemplo a seguir abre um `demo.pptx` existente, imprime o espaçamento atual da grade, define um intervalo de um quarto de polegada e salva o resultado.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    grid_spacing = presentation.getViewProperties().getGridSpacing()
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.getViewProperties().setGridSpacing(18.0)
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A grade é diferente dos [drawing guides](/slides/pt/python-java/drawing-guides/). O espaçamento da grade controla um intervalo regular, enquanto os guias de desenho são linhas de alinhamento horizontais ou verticais posicionadas individualmente. Adicionar, mover ou limpar guias de desenho não altera o espaçamento da grade.

Tanto a grade quanto os guias de desenho são auxiliares de edição. Eles não são renderizados como conteúdo do slide em PDF, imagens, SVG ou apresentação de slides. Armazenar o espaçamento da grade não garante que um editor exibirá a grade: sua visibilidade também depende das preferências do visualizador ou editor.

## **Exibir ou Ocultar Comentários ao Abrir uma Apresentação**

Use [Presentation.getViewProperties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getViewProperties) para acessar as configurações de visualização em todo o documento. Use [ViewProperties.getShowComments](https://reference.aspose.com/slides/pt/python-java/aspose.slides/viewproperties/#getShowComments) e [ViewProperties.setShowComments](https://reference.aspose.com/slides/pt/python-java/aspose.slides/viewproperties/#setShowComments) para ler ou alterar a preferência armazenada sobre se os comentários devem ser exibidos quando a apresentação for aberta no PowerPoint ou em outro editor compatível.

Essa configuração controla apenas a preferência de visualização armazenada. Não adiciona, remove, edita ou resolve comentários. Ocultar comentários preserva seu conteúdo, autores, posições, respostas e status. Consulte [Presentation Comments](/slides/pt/python-java/presentation-comments/) para operações que alteram os próprios comentários.

O exemplo a seguir requer um `comments.pptx` existente que contenha comentários. Ele imprime a configuração de visibilidade atual, solicita que os comentários sejam ocultados e salva um novo PPTX sem remover nenhum comentário. Também usa [ViewProperties.setLastView](https://reference.aspose.com/slides/pt/python-java/aspose.slides/viewproperties/#setLastView) com [ViewType.SlideView](https://reference.aspose.com/slides/pt/python-java/aspose.slides/viewtype/#SlideView) para configurar a visualização de edição inicial juntamente com a visibilidade dos comentários.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ViewType

presentation = Presentation("comments.pptx")
try:
    show_comments = presentation.getViewProperties().getShowComments()
    print(f"Current comment visibility: {show_comments}")

    presentation.getViewProperties().setShowComments(NullableBool.False_)
    presentation.getViewProperties().setLastView(ViewType.SlideView)
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Essa configuração não determina se os comentários são incluídos nas exportações para PDF, HTML, imagem, notas ou folhetos. Configure as opções específicas de exportação relevantes separadamente.

## **FAQ**

**Por que a grade não está visível após reabrir a apresentação?**

O arquivo armazena o espaçamento da grade, mas o editor controla se a grade é exibida. Verifique as configurações de visibilidade da grade no editor.

**Limpar os guias de desenho altera o espaçamento da grade?**

Não. Os guias de desenho e o espaçamento da grade são configurações independentes. Limpar os guias deixa o intervalo da grade armazenado inalterado.

**Posso definir configurações de visualização diferentes para seções distintas de uma apresentação?**

As [view settings](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getViewProperties) são definidas ao nível da apresentação ([Normal View](https://reference.aspose.com/slides/pt/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/pt/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), não por seção, portanto um único conjunto de parâmetros se aplica a todo o documento ao ser aberto.

**Posso predefinir estados de visualização diferentes para usuários distintos?**

Não. As configurações são armazenadas no arquivo e são compartilhadas. Aplicativos de visualização podem honrar preferências de usuário, mas o arquivo em si contém um único conjunto de propriedades de visualização.

**Posso preparar um modelo com View Properties predefinidos para que novas apresentações sejam abertas da mesma forma?**

Sim. Como as [view properties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getViewProperties) são armazenadas ao nível da apresentação, você pode incorporá‑las em um modelo e criar novos documentos a partir dele com a mesma configuração de visualização inicial.