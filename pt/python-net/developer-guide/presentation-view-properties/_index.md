---
title: Recuperar e Atualizar Propriedades de Visualização da Apresentação em Python
linktitle: Propriedades de Visualização
type: docs
weight: 80
url: /pt/python-net/presentation-view-properties/
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
- apresentação
- Python
- Aspose.Slides
description: "Descubra as propriedades de visualização do Aspose.Slides para Python via .NET para personalizar formatos PPT, PPTX e ODP — ajuste layouts, níveis de zoom e configurações de exibição."
---
## **Introdução**

A visualização normal consiste em três regiões de conteúdo: o próprio slide, uma região de conteúdo lateral e uma região de conteúdo inferior. Propriedades relacionadas ao posicionamento das diferentes regiões de conteúdo. Essas informações permitem que o aplicativo salve seu estado de visualização no arquivo, de modo que ao reabrir o arquivo a visualização esteja no mesmo estado em que a apresentação foi salva pela última vez.

A propriedade [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/viewproperties/normal_view_properties/) foi adicionada para fornecer acesso às propriedades de visualização normal da apresentação.  

As classes [NormalViewProperties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/normalviewrestoredproperties/) e seus descendentes, bem como o enum [SplitterBarStateType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/splitterbarstatetype/) foram adicionados.

## **Sobre INormalViewProperties**

Representa as propriedades de visualização normal.

A propriedade **ShowOutlineIcons** especifica se o aplicativo deve exibir ícones ao mostrar o conteúdo do contorno em qualquer das regiões de conteúdo do modo de visualização normal.

A propriedade **SnapVerticalSplitter** especifica se o divisor vertical deve ser recolhido para um estado minimizado quando a região lateral for suficientemente pequena.

A propriedade **PreferSingleView** especifica se o usuário prefere ver uma única região de conteúdo em tela cheia em vez da visualização normal padrão com três regiões de conteúdo. Se habilitada, o aplicativo pode optar por exibir uma das regiões de conteúdo em toda a janela.

As propriedades **VerticalBarState** e **HorizontalBarState** especificam o estado em que a barra do divisor horizontal ou vertical deve ser exibida. Uma barra de divisor horizontal separa o slide da região de conteúdo abaixo do slide, a barra de divisor vertical separa o slide da região de conteúdo lateral. Os valores possíveis são: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** e **SplitterBarStateType.Restored**.

As propriedades **RestoredLeft** e **RestoredTop** especificam o dimensionamento da região superior ou lateral do slide na visualização normal, quando o valor **SplitterBarStateType.Restored** for aplicado a **VerticalBarState** e **HorizontalBarState**, respectivamente.

## **Sobre a restauração de INormalViewProperties**

Especifica o dimensionamento da região do slide (largura quando for filho de RestoredTop, altura quando for filho de RestoredLeft) na visualização normal, quando a região tem um tamanho restaurado variável (nem minimizado nem maximizado).

A propriedade **DimensionSize** especifica o tamanho da região do slide (largura quando for filho de RestoredTop, altura quando for filho de RestoredLeft).

A propriedade **AutoAdjust** especifica se o tamanho da região de conteúdo lateral deve compensar o novo tamanho ao redimensionar a janela que contém a visualização dentro do aplicativo.

Um exemplo abaixo mostra como acessar as propriedades **ViewProperties.NormalViewProperties** de uma apresentação.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # Restaurar as propriedades de visualização da apresentação
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir valor de zoom padrão**

O Aspose.Slides for Python via .NET agora suporta a definição do valor de zoom padrão para uma apresentação, de modo que, ao abrir a apresentação, o zoom já esteja definido. Isso pode ser feito definindo as [view_properties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/view_properties/) de uma apresentação. As propriedades de visualização de slide, bem como as [notes_view_properties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/viewproperties/notes_view_properties/) podem ser definidas programaticamente. Neste tópico, veremos com um exemplo como definir as Propriedades de Visualização de uma Apresentação no Aspose.Slides.

Para definir as propriedades de visualização, siga as etapas abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Defina as [view properties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/viewproperties/) da apresentação.
3. Grave a apresentação como um arquivo PPTX.

No exemplo abaixo, definimos o valor de zoom para a visualização de slide e também para a visualização de notas.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Definindo as propriedades de visualização da apresentação
    presentation.view_properties.slide_view_properties.scale = 100 # Valor de zoom em porcentagem para a visualização de slide
    presentation.view_properties.notes_view_properties.scale = 100 # Valor de zoom em porcentagem para a visualização de notas 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Posso definir configurações de visualização diferentes para seções diferentes de uma apresentação?**

As [configurações de visualização](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/view_properties/) são definidas no nível da apresentação ([Normal View](https://reference.aspose.com/slides/pt/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/pt/python-net/aspose.slides/viewproperties/slide_view_properties/)), não por seção, portanto um único conjunto de parâmetros se aplica a todo o documento quando ele é aberto.

**Posso pré‑definir diferentes estados de visualização para usuários diferentes?**

Não. As configurações são armazenadas no arquivo e são compartilhadas. Aplicativos visualizadores podem respeitar preferências do usuário, mas o arquivo em si contém um único conjunto de propriedades de visualização.

**Posso preparar um modelo com Propriedades de Visualização pré‑definidas para que novas apresentações abram da mesma forma?**

Sim. Como as [view properties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/view_properties/) são armazenadas no nível da apresentação, você pode incorporá‑las em um modelo e criar novos documentos a partir dele com a mesma configuração inicial de visualização.