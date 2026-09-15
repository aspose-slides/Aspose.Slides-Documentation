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
- travar divisor vertical
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

A visualização normal consiste em três regiões de conteúdo: o próprio slide, uma região de conteúdo lateral e uma região de conteúdo inferior. As propriedades da visualização normal descrevem o posicionamento dessas regiões de conteúdo. Essa informação permite que o aplicativo salve seu estado de visualização no arquivo, de modo que, ao reabrir, a visualização esteja no mesmo estado em que a apresentação foi salva pela última vez.

O método [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/viewproperties/#getNormalViewProperties) foi adicionado para fornecer acesso às propriedades da visualização normal de uma apresentação.

As classes [NormalViewProperties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/normalviewproperties/) e [NormalViewRestoredProperties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/normalviewrestoredproperties/) e a enumeração [SplitterBarStateType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/splitterbarstatetype/) foram adicionadas.

## **Sobre NormalViewProperties**

Representa as propriedades da visualização normal.

Os métodos [getShowOutlineIcons](https://reference.aspose.com/slides/pt/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) e [setShowOutlineIcons](https://reference.aspose.com/slides/pt/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) especificam se o aplicativo deve mostrar ícones ao exibir conteúdo de contorno em qualquer das regiões de conteúdo do modo de visualização normal.

Os métodos [getSnapVerticalSplitter](https://reference.aspose.com/slides/pt/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) e [setSnapVerticalSplitter](https://reference.aspose.com/slides/pt/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) especificam se o divisor vertical deve travar em estado minimizado quando a região lateral for suficientemente pequena.

Os métodos [getPreferSingleView](https://reference.aspose.com/slides/pt/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) e [setPreferSingleView](https://reference.aspose.com/slides/pt/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) especificam se o usuário prefere ver uma única região de conteúdo em tela cheia em vez da visualização normal padrão com três regiões de conteúdo. Se ativado, o aplicativo pode escolher exibir uma das regiões de conteúdo em toda a janela.

Os métodos [getVerticalBarState](https://reference.aspose.com/slides/pt/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) e [getHorizontalBarState](https://reference.aspose.com/slides/pt/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) especificam o estado em que a barra divisora horizontal ou vertical deve ser exibida. Uma barra divisora horizontal separa o slide da região de conteúdo abaixo do slide; uma barra divisora vertical separa o slide da região de conteúdo lateral. Os valores possíveis são: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/pt/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/pt/python-java/aspose.slides/splitterbarstatetype/#Maximized) e [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pt/python-java/aspose.slides/splitterbarstatetype/#Restored).

Os métodos [getRestoredLeft](https://reference.aspose.com/slides/pt/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) e [getRestoredTop](https://reference.aspose.com/slides/pt/python-java/aspose.slides/normalviewproperties/#getRestoredTop) especificam o dimensionamento da região superior ou lateral do slide na visualização normal, quando o valor [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pt/python-java/aspose.slides/splitterbarstatetype/#Restored) é aplicado a [getVerticalBarState](https://reference.aspose.com/slides/pt/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) e [getHorizontalBarState](https://reference.aspose.com/slides/pt/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState), respectivamente.

## **Sobre Restaurar NormalViewProperties**

Especifica o dimensionamento da região do slide (largura quando filho de [getRestoredTop](https://reference.aspose.com/slides/pt/python-java/aspose.slides/normalviewproperties/#getRestoredTop), altura quando filho de [getRestoredLeft](https://reference.aspose.com/slides/pt/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) da visualização normal, quando a região tem um tamanho restaurado variável (nem minimizado nem maximizado).

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

## **Definir o Valor Padrão de Zoom**

{{% alert color="info" title="Note" %}}
O Aspose.Slides for Python via Java oferece suporte à definição do valor de zoom padrão, de modo que ele já seja aplicado quando a apresentação for aberta. Isso pode ser feito configurando o [ViewProperties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/viewproperties/) de uma apresentação. Os métodos [getSlideViewProperties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/viewproperties/#getSlideViewProperties) e [getNotesViewProperties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/viewproperties/#getNotesViewProperties) podem ser configurados programaticamente. Neste tópico, veremos com um exemplo como definir as [Propriedades de Visualização](https://reference.aspose.com/slides/pt/python-java/aspose.slides/viewproperties/) da [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) no [Aspose.Slides](/slides/pt/).
{{% /alert %}}

Para definir as propriedades de visualização, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
1. Defina as [Propriedades de Visualização](https://reference.aspose.com/slides/pt/python-java/aspose.slides/viewproperties/) da [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
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

## **FAQ**

**Posso definir diferentes configurações de visualização para diferentes seções de uma apresentação?**

As [configurações de visualização](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getViewProperties) são definidas no nível da apresentação ([Visualização Normal](https://reference.aspose.com/slides/pt/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Visualização de Slide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), não por seção, portanto um único conjunto de parâmetros se aplica a todo o documento quando ele é aberto.

**Posso pré-definir diferentes estados de visualização para diferentes usuários?**

Não. As configurações são armazenadas no arquivo e são compartilhadas. Aplicativos de visualização podem respeitar preferências do usuário, mas o próprio arquivo contém um único conjunto de propriedades de visualização.

**Posso preparar um modelo com Propriedades de Visualização pré-definidas para que novas apresentações abram da mesma forma?**

Sim. Como as [propriedades de visualização](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getViewProperties) são armazenadas no nível da apresentação, você pode incorporá‑las em um modelo e criar novos documentos a partir dele com a mesma configuração de visualização inicial.