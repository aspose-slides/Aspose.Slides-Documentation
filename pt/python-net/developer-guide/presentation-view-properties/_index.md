---
title: Recuperar e Atualizar Propriedades de Visualização da Apresentação em Python
linktitle: Propriedades de Visualização
type: docs
weight: 80
url: /pt/python-net/presentation-view-properties/
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
- Python
- Aspose.Slides
description: "Use Aspose.Slides for Python via .NET para configurar o layout da visualização normal, zoom de slides e notas, espaçamento da grade e visibilidade de comentários em apresentações do PowerPoint."
---
## **Introdução**

Na visualização normal do PowerPoint, o slide aparece entre um painel lateral para miniaturas ou um contorno e um painel de notas abaixo. Aspose.Slides for Python via .NET expõe as preferências de edição salvas da apresentação através de [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/). Estas incluem o layout do painel, níveis de zoom, espaçamento de grade e visibilidade de comentários.

## **Sobre NormalViewProperties**

Use [normal_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/) para acessar o objeto [NormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/). [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) controla se ícones aparecem ao lado dos títulos dos slides no contorno. [snap_vertical_splitter](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/snap_vertical_splitter/) permite que o painel lateral se ajuste ao seu estado minimizado quando o usuário o reduz. [prefer_single_view](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/prefer_single_view/) indica uma preferência por exibir um único painel na janela inteira.

[vertical_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/vertical_bar_state/) controla o divisor entre o painel lateral e o slide. [horizontal_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/horizontal_bar_state/) controla o divisor acima do painel de notas. Ambos aceitam um valor [SplitterBarStateType](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/) de `MINIMIZED`, `MAXIMIZED` ou `RESTORED`.

<!-- visual-explanation:presentation-view-properties:start -->
[![A conceptual editor separates a side panel, slide region and bottom region with labelled vertical and horizontal splitters.](visual-presentation-view-properties-40ae1765a743.svg)](visual-presentation-view-properties-40ae1765a743.svg)

*Na visualização normal, o divisor vertical controla a largura do painel lateral. O divisor horizontal controla o espaço acima do painel de notas.*
<!-- visual-explanation:presentation-view-properties:end -->

## **Sobre Restaurar NormalViewProperties**

Quando um divisor é restaurado, [restored_left](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_left/) fornece o tamanho salvo do painel lateral e [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) fornece o tamanho salvo da área superior do slide. Ambos expõem [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/). Sua propriedade [dimension_size](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/dimension_size/) aceita uma porcentagem de 0 a 100, e [auto_adjust](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/auto_adjust/) controla se o editor ajusta o tamanho quando a janela é redimensionada.

Este exemplo atualiza uma apresentação existente. Ele restaura o divisor horizontal, define [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) para 80% com ajuste automático habilitado e maximiza o divisor vertical. Também habilita [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) para a visualização de contorno.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    normal_view = presentation.view_properties.normal_view_properties
    normal_view.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    normal_view.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED
    normal_view.restored_top.auto_adjust = True
    normal_view.restored_top.dimension_size = 80
    normal_view.show_outline_icons = True

    presentation.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir o Valor Padrão de Zoom**

[slide_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/slide_view_properties/) e [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/notes_view_properties/) armazenam configurações de zoom independentes para o editor. Essas configurações não afetam as dimensões do slide, a reprodução da apresentação ou a resolução de exportação de imagens.

Este exemplo abre uma apresentação existente e habilita [variable_scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/variable_scale/) para ajustar o slide à janela de edição. Para a página de notas, ele desabilita o dimensionamento automático e define [scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/scale/) para um zoom fixo de 80%.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    view_properties.slide_view_properties.variable_scale = True
    view_properties.notes_view_properties.variable_scale = False
    view_properties.notes_view_properties.scale = 80

    presentation.save("zoom.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir o Espaçamento da Grade**

[grid_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/grid_spacing/) define a distância entre as linhas de grade de edição em toda a apresentação. Aceita um valor positivo em pontos, com 72 pontos por polegada. Este exemplo imprime o espaçamento atual em uma apresentação existente e salva uma grade de um quarto de polegada definindo o intervalo para 18 pontos.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current grid spacing: {view_properties.grid_spacing} points")

    view_properties.grid_spacing = 18.0

    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

A grade se repete em intervalos fixos. [Drawing guides](/slides/pt/python-net/drawing-guides/) marcam posições individuais horizontais ou verticais. Ambos são auxílios de edição e aparecem apenas em editores que os exibem. Apresentações de slides e exportações para PDF, imagens ou SVG os omitem.

## **Mostrar ou Ocultar Comentários ao Abrir uma Apresentação**

[show_comments](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/show_comments/) armazena uma preferência que editores compatíveis utilizam ao abrir a apresentação. Para uma apresentação existente com comentários, este exemplo imprime a configuração atual e salva uma cópia com os comentários ocultos. Também define [last_view](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/last_view/) para [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/python-net/aspose.slides/viewtype/) para que a cópia abra na visualização de slide.

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current comment visibility: {view_properties.show_comments}")

    view_properties.show_comments = slides.NullableBool.FALSE
    view_properties.last_view = slides.ViewType.SLIDE_VIEW
    
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

Ocultar comentários preserva seu texto, autores, posições, respostas e status. Para alterar os próprios comentários, veja [Presentation Comments](/slides/pt/python-net/presentation-comments/). As configurações de exportação controlam se os comentários aparecem em PDF, HTML, imagens, notas ou folhetos.

## **Perguntas Frequentes**

**Por que a grade fica oculta ao reabrir a apresentação?**

A apresentação armazena o intervalo da grade. Para ver a grade, habilite a visibilidade da grade no editor.

**Limpar guias de desenho altera o espaçamento da grade?**

Não. Adicionar, mover ou limpar uma guia não altera o intervalo da grade.

**Diferentes seções de uma apresentação podem ter configurações de visualização diferentes?**

Não. [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) se aplica a toda a apresentação.

**Posso salvar configurações de visualização diferentes para usuários diferentes?**

O arquivo armazena um conjunto de propriedades de visualização para todos. Um editor também pode aplicar preferências locais de um usuário.

**Posso salvar configurações de visualização em um modelo?**

Sim. Apresentações criadas a partir do modelo herdam suas configurações de visualização salvas.