---
title: Recuperar e Atualizar Propriedades de Visualização da Apresentação em JavaScript
linktitle: Propriedades de Visualização
type: docs
weight: 80
url: /pt/nodejs-java/presentation-view-properties/
keywords:
- propriedades de visualização
- visualização normal
- conteúdo do contorno
- ícones do contorno
- ajuste do divisor vertical
- visualização única
- estado da barra
- tamanho da dimensão
- ajuste automático
- zoom padrão
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Use o Aspose.Slides para Node.js via Java para configurar o layout da visualização normal, o zoom de slides e notas, o espaçamento da grade e a visibilidade de comentários em apresentações do PowerPoint."
---
## **Introdução**

Na visualização normal do PowerPoint, o slide aparece entre um painel lateral para miniaturas ou um contorno e um painel de notas abaixo. Aspose.Slides for Node.js via Java expõe as preferências de edição salvas da apresentação através de [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties). Estas incluem o layout dos painéis, níveis de zoom, espaçamento da grade e visibilidade de comentários.

## **Sobre NormalViewProperties**

Use [getNormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNormalViewProperties) para acessar a classe [NormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) controla se ícones aparecem ao lado dos títulos dos slides no contorno. [setSnapVerticalSplitter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) permite que o painel lateral se ajuste ao estado minimizado quando o usuário o estreita. [setPreferSingleView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setPreferSingleView) indica uma preferência por exibir um único painel na janela inteira.

[setVerticalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setVerticalBarState) controla o divisor entre o painel lateral e o slide. [setHorizontalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setHorizontalBarState) controla o divisor acima do painel de notas. Ambos aceitam um valor [SplitterBarStateType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/splitterbarstatetype/) de `Minimized`, `Maximized` ou `Restored`.

## **Sobre a restauração de NormalViewProperties**

Quando um divisor é restaurado, [getRestoredLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredLeft) fornece o tamanho salvo do painel lateral e [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) fornece o tamanho salvo da área superior do slide. Ambos expõem [NormalViewRestoredProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/). Seu método [setDimensionSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) aceita uma porcentagem de 0 a 100, e [setAutoAdjust](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) controla se o editor ajusta o tamanho quando a janela é redimensionada.

Este exemplo atualiza uma apresentação existente. Ele restaura o divisor horizontal, define o tamanho retornado por [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) para 80% com ajuste automático habilitado, e maximiza o divisor vertical. Também chama [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) para exibir ícones na visualização de contorno.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(slides.SplitterBarStateType.Restored);
    normalView.setVerticalBarState(slides.SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir o valor padrão de zoom**

[getSlideViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getSlideViewProperties) e [getNotesViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNotesViewProperties) armazenam configurações de zoom independentes para o editor. Essas configurações não afetam as dimensões dos slides, a reprodução da apresentação ou a resolução da exportação de imagens.

Este exemplo abre uma apresentação existente e chama [setVariableScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setVariableScale) para ajustar o slide à janela de edição. Para a página de notas, ele desabilita o dimensionamento automático e chama [setScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setScale) para definir um zoom fixo de 80%.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir o espaçamento da grade**

[setGridSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setGridSpacing) define a distância entre as linhas da grade de edição em toda a apresentação. Recebe um valor positivo em pontos, com 72 pontos por polegada. Este exemplo exibe o espaçamento atual em uma apresentação existente e salva uma grade de um quarto de polegada definindo o intervalo para 18 pontos.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18);

    presentation.save("grid-spacing.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A grade se repete em intervalo fixo. [Drawing guides](/slides/pt/nodejs-java/drawing-guides/) marcam posições horizontais ou verticais individuais. Ambos são auxiliares de edição e aparecem apenas em editores que os exibem. Apresentações e exportações para PDF, imagens ou SVG os omitam.

## **Mostrar ou ocultar comentários ao abrir uma apresentação**

[setShowComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setShowComments) armazena uma preferência que editores compatíveis usam ao abrir a apresentação. Para uma apresentação existente com comentários, este exemplo exibe a configuração atual e salva uma cópia com os comentários ocultos. Também chama [setLastView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setLastView) com [ViewType.SlideView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewtype/#SlideView) para que a cópia abra na visualização de slide.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current comment visibility: " + viewProperties.getShowComments());

    const hideComments = java.newByte(slides.NullableBool.False);
    viewProperties.setShowComments(hideComments);
    viewProperties.setLastView(slides.ViewType.SlideView);

    presentation.save("comments-hidden.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ocultar comentários preserva seu texto, autores, posições, respostas e status. Para alterar os próprios comentários, veja [Presentation Comments](/slides/pt/nodejs-java/presentation-comments/). As configurações de exportação controlam se os comentários aparecem em PDF, HTML, imagens, notas ou folhetos.

## **FAQ**

**Por que a grade está oculta quando reabro a apresentação?**

A apresentação armazena o intervalo da grade. Para ver a grade, habilite a visibilidade da grade no editor.

**Limpar guias de desenho altera o espaçamento da grade?**

Não. Adicionar, mover ou limpar uma guia deixa o intervalo da grade inalterado.

**Seções diferentes de uma apresentação podem ter configurações de visualização diferentes?**

Não. [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties) aplica-se a toda a apresentação.

**Posso salvar configurações de visualização diferentes para usuários diferentes?**

O arquivo armazena um conjunto de propriedades de visualização para todos. Um editor também pode aplicar as preferências locais de um usuário.

**Posso salvar configurações de visualização em um modelo?**

Sim. Apresentações criadas a partir do modelo herdam suas configurações de visualização salvas.