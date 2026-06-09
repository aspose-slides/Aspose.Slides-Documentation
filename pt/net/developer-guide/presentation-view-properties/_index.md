---
title: Recuperar e Atualizar Propriedades de Visualização de Apresentação no .NET
linktitle: Propriedades de Visualização
type: docs
weight: 80
url: /pt/net/presentation-view-properties/
keywords:
- propriedades de visualização
- visualização normal
- conteúdo de contorno
- ícones de contorno
- encaixar divisor vertical
- visualização única
- estado da barra
- tamanho da dimensão
- ajuste automático
- zoom padrão
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Descubra as propriedades de visualização do Aspose.Slides para .NET para personalizar formatos de slides PPT, PPTX e ODP—ajuste layouts, níveis de zoom e configurações de exibição."
---
## **Introdução**

A visualização normal consiste em três regiões de conteúdo: o próprio slide, uma região de conteúdo lateral e uma região de conteúdo inferior. Propriedades relacionadas ao posicionamento das diferentes regiões de conteúdo. Essa informação permite que a aplicação salve seu estado de visualização no arquivo, de modo que, ao reabri-lo, a visualização esteja no mesmo estado em que a apresentação foi salva pela última vez.

A propriedade [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/iviewproperties/properties/normalviewproperties) foi adicionada para fornecer acesso às propriedades de visualização normal da apresentação.

As interfaces [INormalViewProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/inormalviewrestoredproperties) e seus descendentes, bem como o enum [SplitterBarStateType](https://reference.aspose.com/slides/pt/net/aspose.slides/splitterbarstatetype) foram adicionados.

## **Sobre INormalViewProperties**

Representa propriedades de visualização normal.

A propriedade **ShowOutlineIcons** especifica se a aplicação deve mostrar ícones ao exibir conteúdo de contorno em qualquer das regiões de conteúdo do modo de visualização normal.

A propriedade **SnapVerticalSplitter** especifica se o divisor vertical deve encaixar em um estado minimizado quando a região lateral está suficientemente pequena.

A propriedade **PreferSingleView** especifica se o usuário prefere ver uma única região de conteúdo em tela cheia em vez da visualização normal padrão com três regiões de conteúdo. Se habilitada, a aplicação pode optar por exibir uma das regiões de conteúdo em toda a janela.

As propriedades **VerticalBarState** e **HorizontalBarState** especificam o estado em que a barra divisor horizontal ou vertical deve ser exibida. Uma barra divisor horizontal separa o slide da região de conteúdo abaixo do slide, e a barra divisor vertical separa o slide da região de conteúdo lateral. Os valores possíveis são: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** e **SplitterBarStateType.Restored**.

As propriedades **RestoredLeft** e **RestoredTop** especificam o dimensionamento da região superior ou lateral do slide na visualização normal, quando o valor **SplitterBarStateType.Restored** é aplicado a **VerticalBarState** e **HorizontalBarState**, respectivamente.

## **Sobre a Restauração de INormalViewProperties**

Especifica o dimensionamento da região do slide (largura quando filho de RestoredTop, altura quando filho de RestoredLeft) na visualização normal, quando a região tem um tamanho restaurado variável (nem minimizado nem maximizado).

A propriedade **DimensionSize** especifica o tamanho da região do slide (largura quando filho de restoredTop, altura quando filho de restoredLeft).

A propriedade **AutoAdjust** especifica se o tamanho da região de conteúdo lateral deve compensar o novo tamanho ao redimensionar a janela que contém a visualização dentro da aplicação.

Um exemplo é apresentado abaixo, mostrando como acessar as propriedades **ViewProperties.NormalViewProperties** de uma apresentação.

```c#
using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // Restaurar as propriedades de visualização da apresentação
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```

## **Definir o Valor de Zoom Padrão**

O Aspose.Slides para .NET agora suporta a definição do valor de zoom padrão para uma apresentação, de modo que, ao abrir a apresentação, o zoom já esteja definido. Isso pode ser feito configurando as [ViewProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/viewproperties) de uma apresentação. As propriedades de visualização de slide, bem como as [NotesViewProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/viewproperties/properties/notesviewproperties), podem ser definidas programaticamente. Neste tópico, veremos com um exemplo como definir as propriedades de visualização de uma apresentação no Aspose.Slides.

Para definir as propriedades de visualização, siga as etapas abaixo:
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation)
1. Defina as [Properties](https://reference.aspose.com/slides/pt/net/aspose.slides/viewproperties) de visualização da apresentação
1. Salve a apresentação como um arquivo PPTX

No exemplo abaixo, definimos o valor de zoom para a visualização de slide e também para a visualização de notas.

```c#
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Definir as propriedades de visualização da apresentação
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Valor de zoom em porcentagem para visualização de slide
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Valor de zoom em porcentagem para visualização de notas 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **Perguntas Frequentes**

**Posso definir diferentes configurações de visualização para diferentes seções de uma apresentação?**

[Configurações de visualização](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/viewproperties/) são definidas no nível da apresentação ([Normal View](https://reference.aspose.com/slides/pt/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/pt/net/aspose.slides/viewproperties/slideviewproperties/)), não por seção, portanto um único conjunto de parâmetros se aplica a todo o documento quando ele é aberto.

**Posso predefinir diferentes estados de visualização para diferentes usuários?**

Não. As configurações são armazenadas no arquivo e são compartilhadas. Aplicativos de visualização podem respeitar as preferências do usuário, mas o próprio arquivo contém um único conjunto de propriedades de visualização.

**Posso preparar um modelo com propriedades de visualização predefinidas para que novas apresentações abram da mesma forma?**

Sim. Como as [propriedades de visualização](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/viewproperties/) são armazenadas no nível da apresentação, você pode incorporá-las em um modelo e criar novos documentos a partir dele com a mesma configuração de visualização inicial.