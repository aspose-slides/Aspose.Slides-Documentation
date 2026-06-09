---
title: "Recuperar e Atualizar Propriedades de Visualização da Apresentação em C++"
linktitle: "Propriedades de Visualização"
type: docs
weight: 80
url: /pt/cpp/presentation-view-properties/
keywords:
- propriedades de visualização
- visualização normal
- conteúdo de contorno
- ícones de contorno
- encaixe do divisor vertical
- visualização única
- estado da barra
- tamanho da dimensão
- ajuste automático
- zoom padrão
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Descubra as propriedades de visualização do Aspose.Slides para C++ para personalizar os formatos PPT, PPTX e ODP, ajuste layouts, níveis de zoom e configurações de exibição."
---
## **Introdução**

A visualização normal consiste em três regiões de conteúdo: o próprio slide, uma região de conteúdo lateral e uma região de conteúdo inferior. Propriedades relacionadas ao posicionamento das diferentes regiões de conteúdo. Essas informações permitem que o aplicativo salve seu estado de visualização no arquivo, de modo que, ao reabri‑lo, a visualização esteja no mesmo estado em que a apresentação foi salva pela última vez.

O método [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) foi adicionado para fornecer acesso às propriedades de visualização normal da apresentação.  

As interfaces [INormalViewProperties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/inormalviewrestoredproperties/) e seus descendentes, bem como o enum [SplitterBarStateType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/splitterbarstatetype/), foram adicionados.

## **Sobre INormalViewProperties**

Representa as propriedades de visualização normal.

A propriedade **ShowOutlineIcons** especifica se o aplicativo deve exibir ícones ao apresentar o conteúdo de contorno em qualquer das regiões de conteúdo do modo de visualização normal.

A propriedade **SnapVerticalSplitter** especifica se o divisor vertical deve ser ajustado para um estado minimizado quando a região lateral for suficientemente pequena.

A propriedade **PreferSingleView** especifica se o usuário prefere ver uma única região de conteúdo em janela inteira em vez da visualização normal padrão com três regiões de conteúdo. Se habilitada, o aplicativo pode optar por exibir uma das regiões de conteúdo em toda a janela.

As propriedades **VerticalBarState** e **HorizontalBarState** especificam o estado em que a barra de divisor horizontal ou vertical deve ser exibida. Uma barra de divisor horizontal separa o slide da região de conteúdo abaixo do slide; a barra de divisor vertical separa o slide da região de conteúdo lateral. Os valores possíveis são: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** e **SplitterBarStateType.Restored**.

As propriedades **RestoredLeft** e **RestoredTop** especificam o dimensionamento da região superior ou lateral do slide na visualização normal, quando o valor **SplitterBarStateType.Restored** é aplicado para **VerticalBarState** e **HorizontalBarState**, respectivamente.

## **Sobre a Restauração de INormalViewProperties**

Especifica o dimensionamento da região do slide (largura quando filho de RestoredTop, altura quando filho de RestoredLeft) da visualização normal, quando a região tem um tamanho restaurado variável (nem minimizado nem maximizado).  

A propriedade **DimensionSize** especifica o tamanho da região do slide (largura quando filho de restoredTop, altura quando filho de restoredLeft).  

A propriedade **AutoAdjust** especifica se o tamanho da região de conteúdo lateral deve compensar o novo tamanho ao redimensionar a janela que contém a visualização dentro do aplicativo.  

Um exemplo abaixo mostra como você pode acessar as propriedades **ViewProperties.NormalViewProperties** de uma apresentação.

``` cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// Restaurar as propriedades de visualização da apresentação
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Definir o Valor de Zoom Padrão**

O Aspose.Slides para C++ agora oferece suporte à definição do valor de zoom padrão para a apresentação, de modo que, ao abrir a apresentação, o zoom já esteja definido. Isso pode ser feito configurando as [ViewProperties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/viewproperties/) de uma apresentação. As propriedades de visualização de slide, bem como [get_NotesViewProperties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/viewproperties/get_notesviewproperties/), podem ser definidas programaticamente. Neste tópico, veremos com um exemplo como definir as View Properties de uma apresentação no Aspose.Slides.

Para definir as propriedades de visualização, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Defina as [Properties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/viewproperties/) de visualização da apresentação.
3. Grave a apresentação como um arquivo PPTX.

No exemplo abaixo, definimos o valor de zoom para a visualização de slide e também para a visualização de notas.

``` cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Definindo as propriedades de visualização da apresentação
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Valor de zoom em porcentagem para visualização de slide
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Valor de zoom em porcentagem para visualização de notas 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Posso definir configurações de visualização diferentes para seções diferentes de uma apresentação?**

As [configurações de visualização](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_viewproperties/) são definidas no nível da apresentação ([Normal View](https://reference.aspose.com/slides/pt/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/pt/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), e não por seção, portanto um único conjunto de parâmetros se aplica a todo o documento quando ele é aberto.

**Posso definir previamente estados de visualização diferentes para usuários diferentes?**

Não. As configurações são armazenadas no arquivo e são compartilhadas. Aplicativos de visualização podem respeitar as preferências do usuário, mas o próprio arquivo contém um único conjunto de propriedades de visualização.

**Posso preparar um modelo com View Properties predefinidas para que novas apresentações abram da mesma forma?**

Sim. Como as [view properties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_viewproperties/) são armazenadas no nível da apresentação, você pode incorporá‑las em um modelo e criar novos documentos a partir dele com a mesma configuração de visualização inicial.