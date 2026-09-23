---
title: Recuperar e Atualizar as Propriedades de Visualização da Apresentação no .NET
linktitle: Propriedades de Visualização
type: docs
weight: 80
url: /pt/net/presentation-view-properties/
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
- .NET
- C#
- Aspose.Slides
description: "Descubra as propriedades de visualização do Aspose.Slides para .NET para personalizar os formatos PPT, PPTX e ODP—ajuste layouts, níveis de zoom e configurações de exibição."
---
## **Introdução**

A visualização normal consiste em três regiões de conteúdo: o slide propriamente dito, uma região de conteúdo lateral e uma região de conteúdo inferior. Propriedades relacionadas ao posicionamento das diferentes regiões de conteúdo. Essas informações permitem que o aplicativo salve seu estado de visualização no arquivo, de modo que, ao ser reaberto, a visualização esteja no mesmo estado em que a apresentação foi salva pela última vez.

A propriedade [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/iviewproperties/properties/normalviewproperties) foi adicionada para fornecer acesso às propriedades de visualização normal da apresentação.

Os interfaces [INormalViewProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/inormalviewrestoredproperties) e seus descendentes, bem como o enum [SplitterBarStateType](https://reference.aspose.com/slides/pt/net/aspose.slides/splitterbarstatetype), foram adicionados.

## **Sobre INormalViewProperties**

Representa as propriedades de visualização normal.

A propriedade **ShowOutlineIcons** especifica se o aplicativo deve mostrar ícones ao exibir o conteúdo do contorno em qualquer das regiões de conteúdo do modo de visualização normal.

A propriedade **SnapVerticalSplitter** especifica se o divisor vertical deve encaixar em um estado minimizado quando a região lateral estiver suficientemente pequena.

A propriedade **PreferSingleView** especifica se o usuário prefere ver uma única região de conteúdo em tela cheia em vez da visualização normal padrão com três regiões de conteúdo. Se ativada, o aplicativo pode optar por exibir uma das regiões de conteúdo em toda a janela.

As propriedades **VerticalBarState** e **HorizontalBarState** especificam o estado em que a barra do divisor horizontal ou vertical deve ser mostrada. Um divisor horizontal separa o slide da região de conteúdo abaixo do slide; um divisor vertical separa o slide da região de conteúdo lateral. Os valores possíveis são: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** e **SplitterBarStateType.Restored**.

As propriedades **RestoredLeft** e **RestoredTop** especificam o dimensionamento da região superior ou lateral do slide na visualização normal, quando o valor **SplitterBarStateType.Restored** é aplicado para **VerticalBarState** e **HorizontalBarState**, respectivamente.

## **Sobre a Restauração de INormalViewProperties**

Especifica o dimensionamento da região do slide (largura quando filho de RestoredTop, altura quando filho de RestoredLeft) da visualização normal, quando a região está em um tamanho restaurado variável (nem minimizado nem maximizado).

A propriedade **DimensionSize** especifica o tamanho da região do slide (largura quando filho de RestoredTop, altura quando filho de RestoredLeft).

A propriedade **AutoAdjust** especifica se o tamanho da região de conteúdo lateral deve compensar o novo tamanho ao redimensionar a janela que contém a visualização dentro do aplicativo.

Um exemplo abaixo mostra como acessar as propriedades **ViewProperties.NormalViewProperties** de uma apresentação.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Aspose.Slides for .NET agora oferece suporte à definição do valor de zoom padrão para a apresentação, de modo que, ao abrir a apresentação, o zoom já esteja definido. Isso pode ser feito configurando o [ViewProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/viewproperties) de uma apresentação. As propriedades de visualização de slide, bem como [NotesViewProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/viewproperties/properties/notesviewproperties), podem ser definidas programaticamente. Neste tópico, veremos, com um exemplo, como definir as Propriedades de Visualização de uma apresentação no Aspose.Slides.

Para definir as propriedades de visualização, siga as etapas abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation)
2. Defina as [Properties](https://reference.aspose.com/slides/pt/net/aspose.slides/viewproperties) de visualização da apresentação
3. Grave a apresentação como um arquivo PPTX

No exemplo abaixo, definimos o valor de zoom para a visualização de slide e para a visualização de notas.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Definindo as propriedades de visualização da apresentação
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Valor de zoom em porcentagem para a visualização de slide
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Valor de zoom em porcentagem para a visualização de notas 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **Definir o Espaçamento da Grade**

Use [Presentation.ViewProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/viewproperties/) para acessar as configurações de visualização de toda a apresentação. A propriedade [IViewProperties.GridSpacing](https://reference.aspose.com/slides/pt/net/aspose.slides/iviewproperties/gridspacing/) lê ou altera o intervalo da grade de edição subjacente. Essa configuração se aplica a toda a apresentação, não a um slide individual. O espaçamento da grade é especificado em pontos, onde 72 pontos equivalem a uma polegada. Use um valor positivo, conforme requerido pela documentação da API.

O exemplo a seguir abre um `demo.pptx` existente, exibe seu espaçamento de grade atual, define um intervalo de um quarto de polegada e salva o resultado.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");
var gridSpacing = presentation.ViewProperties.GridSpacing;
Console.WriteLine($"Current grid spacing: {gridSpacing} points");

presentation.ViewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

A grade difere dos [drawing guides](/slides/pt/net/drawing-guides/). O espaçamento da grade controla um intervalo regular, enquanto os guias de desenho são linhas de alinhamento horizontais ou verticais posicionadas individualmente. Adicionar, mover ou limpar guias de desenho não altera o espaçamento da grade.

Tanto a grade quanto os guias de desenho são auxiliares de edição. Eles não são renderizados como conteúdo de slide em PDF, imagens, SVG ou apresentação de slides. Armazenar o espaçamento da grade não garante que um editor exibirá a grade: sua visibilidade também depende das preferências do visualizador ou editor.

## **Mostrar ou Ocultar Comentários ao Abrir uma Apresentação**

Use [Presentation.ViewProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/viewproperties/) para acessar as configurações de visualização de toda a apresentação. Leia ou altere [IViewProperties.ShowComments](https://reference.aspose.com/slides/pt/net/aspose.slides/iviewproperties/showcomments/) para armazenar uma preferência sobre se os comentários devem ser mostrados quando a apresentação for aberta no PowerPoint ou em outro editor compatível.

Essa configuração controla apenas a preferência de visualização armazenada. Ela não adiciona, remove, edita ou resolve comentários. Ocultar comentários preserva seu conteúdo, autores, posições, respostas e status. Consulte [Presentation Comments](/slides/pt/net/presentation-comments/) para operações que alteram os próprios comentários.

O exemplo a seguir requer um `comments.pptx` existente contendo comentários. Ele exibe a configuração de visibilidade atual, solicita que os comentários sejam ocultados e salva um novo PPTX sem remover nenhum comentário. Também define [IViewProperties.LastView](https://reference.aspose.com/slides/pt/net/aspose.slides/iviewproperties/lastview/) para [ViewType.SlideView](https://reference.aspose.com/slides/pt/net/aspose.slides/viewtype/) a fim de configurar a visualização de edição inicial juntamente com a visibilidade dos comentários.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");
var showComments = presentation.ViewProperties.ShowComments;
Console.WriteLine($"Current comment visibility: {showComments}");

presentation.ViewProperties.ShowComments = NullableBool.False;
presentation.ViewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

Essa configuração não determina se os comentários serão incluídos nas exportações em PDF, HTML, imagem, notas ou folhetos. Configure as opções específicas de exportação separadamente.

## **FAQ**

**Por que a grade não está visível depois de reabrir a apresentação?**

O arquivo armazena o espaçamento da grade, mas o editor controla se a grade é exibida. Verifique as configurações de visibilidade da grade no editor.

**Limpar os guias de desenho altera o espaçamento da grade?**

Não. Guias de desenho e espaçamento da grade são configurações independentes. Limpar os guias deixa o intervalo da grade armazenado inalterado.

**Posso definir diferentes configurações de visualização para diferentes seções de uma apresentação?**

As [view settings](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/viewproperties/) são definidas ao nível da apresentação ([Normal View](https://reference.aspose.com/slides/pt/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/pt/net/aspose.slides/viewproperties/slideviewproperties/)), não por seção, portanto um único conjunto de parâmetros se aplica a todo o documento quando ele é aberto.

**Posso pré‑definir diferentes estados de visualização para diferentes usuários?**

Não. As configurações são armazenadas no arquivo e são compartilhadas. Aplicativos visualizadores podem respeitar preferências do usuário, mas o próprio arquivo contém um único conjunto de propriedades de visualização.

**Posso preparar um modelo com Propriedades de Visualização predefinidas para que novas apresentações abram da mesma forma?**

Sim. Como as [view properties](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/viewproperties/) são armazenadas ao nível da apresentação, você pode incorporá‑las em um modelo e criar novos documentos a partir dele com a mesma configuração de visualização inicial.