---
title: Recuperar e Atualizar Propriedades de Visualização da Apresentação em .NET
linktitle: Propriedades de Visualização
type: docs
weight: 80
url: /pt/net/presentation-view-properties/
keywords:
- propriedades de visualização
- visualização normal
- conteúdo do contorno
- ícones de contorno
- ajuste do divisor vertical
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
description: "Use o Aspose.Slides para .NET para configurar o layout da visualização normal, o zoom de slides e notas, o espaçamento da grade e a visibilidade de comentários em apresentações do PowerPoint."
---
## **Introdução**

Na visualização normal do PowerPoint, o slide aparece entre um painel lateral para miniaturas ou um contorno e um painel de notas abaixo. Aspose.Slides para .NET expõe as preferências de edição salvas da apresentação através de [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/). Estas incluem o layout do painel, níveis de zoom, espaçamento da grade e visibilidade de comentários.

## **Sobre INormalViewProperties**

Use [NormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/normalviewproperties/) para acessar a interface [INormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/). [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) controla se ícones aparecem ao lado dos títulos dos slides no contorno. [SnapVerticalSplitter](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/snapverticalsplitter/) permite que o painel lateral trave em seu estado minimizado quando o usuário o reduz. [PreferSingleView](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/prefersingleview/) indica uma preferência por exibir um único painel na janela completa.

[VerticalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/verticalbarstate/) controla o divisor entre o painel lateral e o slide. [HorizontalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/horizontalbarstate/) controla o divisor acima do painel de notas. Ambos aceitam um valor [SplitterBarStateType](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype/) de `Minimized`, `Maximized` ou `Restored`.

## **Sobre Restaurar INormalViewProperties**

Quando um divisor é restaurado, [RestoredLeft](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredleft/) fornece o tamanho salvo do painel lateral e [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) fornece o tamanho salvo da área superior do slide. Ambos expõem [INormalViewRestoredProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/). Sua propriedade [DimensionSize](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/dimensionsize/) aceita uma porcentagem de 0 a 100, e [AutoAdjust](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/autoadjust/) controla se o editor ajusta o tamanho quando a janela é redimensionada.

Este exemplo atualiza uma apresentação existente. Ele restaura o divisor horizontal, define [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) para 80% com ajuste automático ativado e maximiza o divisor vertical. Também habilita [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) para a visualização de contorno.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var normalView = presentation.ViewProperties.NormalViewProperties;
normalView.HorizontalBarState = SplitterBarStateType.Restored;
normalView.VerticalBarState = SplitterBarStateType.Maximized;
normalView.RestoredTop.AutoAdjust = true;
normalView.RestoredTop.DimensionSize = 80;
normalView.ShowOutlineIcons = true;

presentation.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
```

## **Definir o Valor Padrão de Zoom**

[SlideViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/slideviewproperties/) e [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/notesviewproperties/) armazenam configurações de zoom independentes para o editor. Essas configurações não afetam as dimensões dos slides, a reprodução de apresentação ou a resolução de exportação de imagens.

Este exemplo abre uma apresentação existente e habilita [VariableScale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/variablescale/) para ajustar o slide à janela de edição. Para a página de notas, ele desabilita o dimensionamento automático e define [Scale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/scale/) para um zoom fixo de 80%.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
viewProperties.SlideViewProperties.VariableScale = true;
viewProperties.NotesViewProperties.VariableScale = false;
viewProperties.NotesViewProperties.Scale = 80;

presentation.Save("zoom.pptx", SaveFormat.Pptx);
```

## **Definir o Espaçamento da Grade**

[GridSpacing](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/gridspacing/) define a distância entre as linhas da grade de edição em toda a apresentação. Ela recebe um valor positivo em pontos, com 72 pontos por polegada. Este exemplo imprime o espaçamento atual em uma apresentação existente e salva uma grade de um quarto de polegada definindo o intervalo para 18 pontos.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current grid spacing: {viewProperties.GridSpacing} points");

viewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

A grade se repete em intervalos fixos. [Guias de desenho](/slides/pt/net/drawing-guides/) marcam posições horizontais ou verticais individuais. Ambos são auxílios de edição e aparecem apenas em editores que os exibem. Apresentações e exportações para PDF, imagens ou SVG os omitêm.

## **Mostrar ou Ocultar Comentários ao Abrir uma Apresentação**

[ShowComments](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/showcomments/) armazena uma preferência que editores compatíveis utilizam ao abrir a apresentação. Para uma apresentação existente com comentários, este exemplo imprime a configuração atual e salva uma cópia com comentários ocultos. Também define [LastView](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/lastview/) para [ViewType.SlideView](https://reference.aspose.com/slides/net/aspose.slides/viewtype/) para que a cópia seja aberta na visualização de slide.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current comment visibility: {viewProperties.ShowComments}");

viewProperties.ShowComments = NullableBool.False;
viewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

Ocultar comentários preserva seu texto, autores, posições, respostas e status. Para alterar os próprios comentários, veja [Comentários da Apresentação](/slides/pt/net/presentation-comments/). As configurações de exportação controlam se os comentários aparecem em PDF, HTML, imagens, notas ou folhetos.

## **FAQ**

**Por que a grade fica oculta ao reabrir a apresentação?**

A apresentação armazena o intervalo da grade. Para ver a grade, habilite a visibilidade da grade no editor.

**Limpar guias de desenho altera o espaçamento da grade?**

Não. Adicionar, mover ou limpar uma guia deixa o intervalo da grade inalterado.

**Seções diferentes de uma apresentação podem ter configurações de visualização diferentes?**

Não. [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) se aplica a toda a apresentação.

**Posso salvar configurações de visualização diferentes para usuários diferentes?**

O arquivo armazena um único conjunto de propriedades de visualização para todos. Um editor pode também aplicar as preferências locais de um usuário.

**Posso salvar configurações de visualização em um modelo?**

Sim. Apresentações criadas a partir do modelo herdam as configurações de visualização salvas.