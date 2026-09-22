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

A visualização normal consiste em três regiões de conteúdo: o próprio slide, uma região de conteúdo lateral e uma região de conteúdo inferior. Propriedades referentes ao posicionamento das diferentes regiões de conteúdo. Essas informações permitem que o aplicativo salve seu estado de visualização no arquivo, de modo que, ao ser reaberto, a visualização esteja no mesmo estado em que a apresentação foi salva pela última vez.

A propriedade [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/viewproperties/normal_view_properties/) foi adicionada para fornecer acesso às propriedades de visualização normal da apresentação.  

[NormalViewProperties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/normalviewrestoredproperties/) classes e seus descendentes, [SplitterBarStateType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/splitterbarstatetype/) enum foram adicionados.

## **Sobre INormalViewProperties** 

Representa as propriedades de visualização normal.

A propriedade **ShowOutlineIcons** especifica se o aplicativo deve mostrar ícones ao exibir conteúdo de contorno em qualquer das regiões de conteúdo do modo de visualização normal.

A propriedade **SnapVerticalSplitter** especifica se o divisor vertical deve retornar a um estado minimizado quando a região lateral for suficientemente pequena.

A propriedade **PreferSingleView** especifica se o usuário prefere ver uma única região de conteúdo em tela cheia em vez da visualização normal padrão com três regiões de conteúdo. Quando habilitada, o aplicativo pode optar por exibir uma das regiões de conteúdo em toda a janela.

As propriedades **VerticalBarState** e **HorizontalBarState** especificam o estado em que a barra divisória vertical ou horizontal deve ser exibida. Uma barra divisória horizontal separa o slide da região de conteúdo abaixo do slide; a barra divisória vertical separa o slide da região de conteúdo lateral. Valores possíveis são: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** e **SplitterBarStateType.Restored**.

As propriedades **RestoredLeft** e **RestoredTop** especificam o dimensionamento da região superior ou lateral do slide na visualização normal, quando o valor **SplitterBarStateType.Restored** é aplicado para **VerticalBarState** e **HorizontalBarState**, respectivamente.

## **Sobre Restaurar INormalViewProperties**

Especifica o dimensionamento da região do slide (largura quando filho de RestoredTop, altura quando filho de RestoredLeft) da visualização normal, quando a região está em um tamanho restaurado variável (nem minimizado nem maximizado).  

A propriedade **DimensionSize** especifica o tamanho da região do slide (largura quando filho de RestoredTop, altura quando filho de RestoredLeft).  

A propriedade **AutoAdjust** especifica se o tamanho da região de conteúdo lateral deve compensar o novo tamanho ao redimensionar a janela que contém a visualização dentro do aplicativo.

Um exemplo abaixo mostra como acessar as propriedades **ViewProperties.NormalViewProperties** de uma apresentação.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # Restaurar as propriedades de visualização da apresentação
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir Valor de Zoom Padrão**

Aspose.Slides for Python via .NET agora suporta a definição do valor de zoom padrão para a apresentação, de modo que, ao abrir a apresentação, o zoom já esteja definido. Isso pode ser feito definindo as [view_properties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/view_properties/) de uma apresentação. As propriedades de visualização de slide, bem como [notes_view_properties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/viewproperties/notes_view_properties/) podem ser definidas programaticamente. Neste tópico, veremos com um exemplo como definir as Propriedades de Visualização de uma Apresentação no Aspose.Slides.

Para definir as propriedades de visualização, siga as etapas abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/)
1. Defina as [view properties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/viewproperties/) da apresentação
1. Grave a apresentação como um arquivo PPTX

No exemplo abaixo, definimos o valor de zoom para a visualização de slide e para a visualização de notas.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # Definindo as propriedades de visualização da apresentação
    presentation.view_properties.slide_view_properties.scale = 100 # Valor de zoom em porcentagem para a visualização de slide
    presentation.view_properties.notes_view_properties.scale = 100 # Valor de zoom em porcentagem para a visualização de notas 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir o Espaçamento da Grade**

Use [Presentation.view_properties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/view_properties/) para acessar as configurações de visualização em todo o documento. A propriedade [ViewProperties.grid_spacing](https://reference.aspose.com/slides/pt/python-net/aspose.slides/viewproperties/grid_spacing/) lê ou altera o intervalo da grade de edição subjacente. Essa configuração se aplica a toda a apresentação, não a um slide individual. O espaçamento da grade é especificado em pontos, onde 72 pontos equivalem a uma polegada. Use um valor positivo, conforme exigido pela documentação da API.

O exemplo a seguir abre um `demo.pptx` existente, exibe o espaçamento de grade atual, define um intervalo de um quarto de polegada e salva o resultado.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

A grade difere dos [drawing guides](/slides/pt/python-net/drawing-guides/). O espaçamento da grade controla um intervalo regular, enquanto os guias de desenho são linhas de alinhamento horizontais ou verticais posicionadas individualmente. Adicionar, mover ou limpar guias de desenho não altera o espaçamento da grade.

Tanto a grade quanto os guias de desenho são auxílios de edição. Eles não são renderizados como conteúdo de slide em PDF, imagens, SVG ou em uma apresentação de slides. Armazenar o espaçamento da grade não garante que um editor exibirá a grade: sua visibilidade também depende das preferências do visualizador ou do editor.

## **FAQ**

**Por que a grade não fica visível depois que reabro a apresentação?**

O arquivo armazena o espaçamento da grade, mas o editor controla se a grade é exibida. Verifique as configurações de visibilidade da grade no editor.

**Limpar guias de desenho altera o espaçamento da grade?**

Não. Guias de desenho e espaçamento da grade são configurações independentes. Limpar os guias deixa o intervalo da grade armazenado inalterado.

**Posso definir diferentes configurações de visualização para diferentes seções de uma apresentação?**

As [view settings](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/view_properties/) são definidas ao nível da apresentação ([Normal View](https://reference.aspose.com/slides/pt/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/pt/python-net/aspose.slides/viewproperties/slide_view_properties/)), não por seção, portanto um único conjunto de parâmetros se aplica a todo o documento quando ele é aberto.

**Posso pré‑definir diferentes estados de visualização para diferentes usuários?**

Não. As configurações são armazenadas no arquivo e são compartilhadas. Aplicativos de visualização podem respeitar as preferências do usuário, mas o próprio arquivo contém um único conjunto de propriedades de visualização.

**Posso preparar um modelo com Propriedades de Visualização pré‑definidas para que novas apresentações abram da mesma forma?**

Sim. Como as [view properties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/view_properties/) são armazenadas ao nível da apresentação, você pode incorporá‑las em um modelo e criar novos documentos a partir dele com a mesma configuração inicial de visualização.