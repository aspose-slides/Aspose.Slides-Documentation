---
title: Recuperar e Atualizar Propriedades de Visualização da Apresentação em .NET
linktitle: Propriedades de Visualização
type: docs
weight: 80
url: /pt/net/presentation-view-properties/
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
- .NET
- C#
- Aspose.Slides
description: "Descubra as propriedades de visualização do Aspose.Slides para .NET para personalizar formatos PPT, PPTX e ODP—ajuste layouts, níveis de zoom e configurações de exibição."
---
## **Introdução**

A visualização normal consiste em três regiões de conteúdo: o próprio slide, uma região de conteúdo lateral e uma região de conteúdo inferior. Propriedades referentes ao posicionamento das diferentes regiões de conteúdo. Essas informações permitem que a aplicação salve seu estado de visualização no arquivo, de modo que, ao reabri‑lo, a visualização esteja no mesmo estado em que a apresentação foi salva pela última vez.

A propriedade [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/iviewproperties/properties/normalviewproperties) foi adicionada para fornecer acesso às propriedades de visualização normal da apresentação.  

As interfaces [INormalViewProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/inormalviewrestoredproperties) e seus descendentes, bem como o enum [SplitterBarStateType](https://reference.aspose.com/slides/pt/net/aspose.slides/splitterbarstatetype) foram adicionados.

## **Sobre INormalViewProperties**

Representa propriedades de visualização normal.

A propriedade **ShowOutlineIcons** especifica se a aplicação deve mostrar ícones ao exibir conteúdo de contorno em qualquer das regiões de conteúdo do modo de visualização normal.

A propriedade **SnapVerticalSplitter** especifica se o divisor vertical deve recolher para um estado minimizado quando a região lateral for suficientemente pequena.

A propriedade **PreferSingleView** especifica se o usuário prefere ver uma única região de conteúdo em janela inteira em vez da visualização normal padrão com três regiões de conteúdo. Quando habilitada, a aplicação pode optar por exibir uma das regiões de conteúdo na janela inteira.

As propriedades **VerticalBarState** e **HorizontalBarState** especificam o estado em que a barra do divisor horizontal ou vertical deve ser exibida. Uma barra de divisor horizontal separa o slide da região de conteúdo abaixo do slide; a barra de divisor vertical separa o slide da região de conteúdo lateral. Valores possíveis são: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** e **SplitterBarStateType.Restored**.

As propriedades **RestoredLeft** e **RestoredTop** especificam o dimensionamento da região superior ou lateral do slide na visualização normal, quando o valor **SplitterBarStateType.Restored** for aplicado a **VerticalBarState** e **HorizontalBarState**, respectivamente.

## **Sobre a Restauração de INormalViewProperties**

Especifica o dimensionamento da região do slide (largura quando filho de RestoredTop, altura quando filho de RestoredLeft) na visualização normal, quando a região tem um tamanho restaurado variável (nem minimizado nem maximizado).  

A propriedade **DimensionSize** especifica o tamanho da região do slide (largura quando filho de RestoredTop, altura quando filho de RestoredLeft).  

A propriedade **AutoAdjust** especifica se o tamanho da região de conteúdo lateral deve compensar o novo tamanho ao redimensionar a janela que contém a visualização dentro da aplicação.  

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

Aspose.Slides para .NET agora oferece suporte à definição do valor de zoom padrão para a apresentação, de modo que, ao abrir a apresentação, o zoom já esteja definido. Isso pode ser feito definindo as [ViewProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/viewproperties) de uma apresentação. As propriedades de visualização de slide, bem como as [NotesViewProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/viewproperties/properties/notesviewproperties), podem ser definidas programaticamente. Neste tópico, veremos com um exemplo como definir as propriedades de visualização de uma apresentação no Aspose.Slides.

Para definir as propriedades de visualização, siga as etapas abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation)
2. Defina as **ViewProperties** da apresentação
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

Use [Presentation.ViewProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/viewproperties/) para acessar as configurações de visualização de toda a apresentação. A propriedade [IViewProperties.GridSpacing](https://reference.aspose.com/slides/pt/net/aspose.slides/iviewproperties/gridspacing/) lê ou altera o intervalo da grade de edição subjacente. Essa configuração se aplica a toda a apresentação, não a um slide individual. O espaçamento da grade é especificado em pontos, onde 72 pontos correspondem a uma polegada. Use um valor positivo, conforme exigido pela documentação da API.

O exemplo a seguir abre um arquivo `demo.pptx` existente, exibe o espaçamento atual da grade, define um intervalo de um quarto de polegada e salva o resultado.

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

Tanto a grade quanto os guias de desenho são auxiliares de edição. Eles não são renderizados como conteúdo de slide em PDF, imagens, SVG ou em uma apresentação de slides. Armazenar o espaçamento da grade não garante que um editor exibirá a grade: sua visibilidade também depende das preferências do visualizador ou editor.

## **FAQ**

**Por que a grade não fica visível depois que reabro a apresentação?**  
O arquivo armazena o espaçamento da grade, mas o editor controla se a grade é exibida. Verifique as configurações de visibilidade da grade no editor.

**Limpar guias de desenho altera o espaçamento da grade?**  
Não. Guias de desenho e espaçamento da grade são configurações independentes. Limpar os guias deixa o intervalo da grade armazenado inalterado.

**Posso definir diferentes configurações de visualização para diferentes seções de uma apresentação?**  
As [configurações de visualização](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/viewproperties/) são definidas no nível da apresentação ([Normal View](https://reference.aspose.com/slides/pt/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/pt/net/aspose.slides/viewproperties/slideviewproperties/)), não por seção, de modo que um único conjunto de parâmetros se aplica ao documento inteiro ao ser aberto.

**Posso pré‑definir diferentes estados de visualização para diferentes usuários?**  
Não. As configurações são armazenadas no arquivo e são compartilhadas. Aplicativos de visualização podem respeitar preferências do usuário, mas o arquivo contém apenas um conjunto de propriedades de visualização.

**Posso preparar um modelo com propriedades de visualização predefinidas para que novas apresentações abram da mesma forma?**  
Sim. Como as [propriedades de visualização](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/viewproperties/) são armazenadas no nível da apresentação, você pode incorporá‑las em um modelo e criar novos documentos a partir dele com a mesma configuração inicial de visualização.