---
title: Recuperar e Atualizar Propriedades de Exibição da Apresentação no Android
linktitle: Propriedades de Exibição
type: docs
weight: 80
url: /pt/androidjava/presentation-view-properties/
keywords:
- propriedades de exibição
- visualização normal
- conteúdo de contorno
- ícones de contorno
- divisor vertical ajustável
- visualização única
- estado da barra
- tamanho da dimensão
- ajuste automático
- zoom padrão
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Use Aspose.Slides para Android via Java para configurar o layout da visualização normal, o zoom de slides e anotações, o espaçamento da grade e a visibilidade de comentários em apresentações do PowerPoint."
---
## **Introdução**

Na visualização normal do PowerPoint, o slide aparece entre um painel lateral para miniaturas ou um contorno e um painel de anotações abaixo. Aspose.Slides for Android via Java expõe as preferências de edição salvas da apresentação através de [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--). Estas incluem o layout dos painéis, níveis de zoom, espaçamento da grade e visibilidade de comentários.

## **Sobre INormalViewProperties**

Use [getNormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNormalViewProperties--) para acessar a interface [INormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) controla se ícones aparecem ao lado dos títulos dos slides no contorno. [setSnapVerticalSplitter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setSnapVerticalSplitter-boolean-) permite que o painel lateral se ajuste ao seu estado minimizado quando o usuário o reduz. [setPreferSingleView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setPreferSingleView-boolean-) indica uma preferência por exibir um único painel na janela completa.

[setVerticalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setVerticalBarState-int-) controla o divisor entre o painel lateral e o slide. [setHorizontalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setHorizontalBarState-int-) controla o divisor acima do painel de anotações. Ambos aceitam um valor [SplitterBarStateType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/splitterbarstatetype/) de `Minimized`, `Maximized` ou `Restored`.

## **Sobre Restaurar INormalViewProperties**

Quando um divisor é restaurado, [getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredLeft--) fornece o tamanho salvo do painel lateral e [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) fornece o tamanho salvo da área superior do slide. Ambos expõem [INormalViewRestoredProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/). Seu método [setDimensionSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setDimensionSize-float-) aceita uma porcentagem de 0 a 100, e [setAutoAdjust](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setAutoAdjust-boolean-) controla se o editor ajusta o tamanho quando a janela é redimensionada.

Este exemplo atualiza uma apresentação existente. Ele restaura o divisor horizontal, define o tamanho retornado por [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) para 80 % com ajuste automático ativado, e maximiza o divisor vertical. Também chama [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) para exibir ícones na visualização de contorno.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    INormalViewProperties normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(SplitterBarStateType.Restored);
    normalView.setVerticalBarState(SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir o Valor de Zoom Padrão**

[getSlideViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getSlideViewProperties--) e [getNotesViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNotesViewProperties--) armazenam configurações de zoom independentes para o editor. Essas configurações não afetam as dimensões dos slides, a reprodução da apresentação ou a resolução de exportação de imagens.

Este exemplo abre uma apresentação existente e chama [setVariableScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setVariableScale-boolean-) para ajustar o slide à janela de edição. Para a página de notas, ele desativa a escalonamento automático e chama [setScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setScale-int-) para definir um zoom fixo de 80 %.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir o Espaçamento da Grade**

[setGridSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) define a distância entre as linhas da grade de edição em toda a apresentação. Aceita um valor positivo em pontos, com 72 pontos por polegada. Este exemplo imprime o espaçamento atual em uma apresentação existente e salva uma grade de um quarto de polegada definindo o intervalo para 18 pontos.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18f);

    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A grade se repete em intervalos fixos. [Guias de desenho](/slides/pt/androidjava/drawing-guides/) marcam posições individuais horizontais ou verticais. Ambas são auxiliares de edição e aparecem apenas em editores que as exibem. Apresentações e exportações para PDF, imagens ou SVG não as incluem.

## **Mostrar ou Ocultar Comentários ao Abrir uma Apresentação**

[setShowComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-) armazena uma preferência que editores compatíveis usam ao abrir a apresentação. Para uma apresentação existente com comentários, este exemplo imprime a configuração atual e salva uma cópia com os comentários ocultos. Também chama [setLastView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-) com [ViewType.SlideView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewtype/#SlideView) para que a cópia abra na visualização de slide.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("comments.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current comment visibility: " + viewProperties.getShowComments());

    viewProperties.setShowComments(NullableBool.False);
    viewProperties.setLastView(ViewType.SlideView);

    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ocultar comentários preserva seu texto, autores, posições, respostas e status. Para alterar os próprios comentários, veja [Comentários da Apresentação](/slides/pt/androidjava/presentation-comments/). As configurações de exportação controlam se os comentários aparecem em PDF, HTML, imagens, notas ou folhetos.

## **FAQ**

**Por que a grade está oculta quando reabro a apresentação?**

A apresentação armazena o intervalo da grade. Para ver a grade, habilite a visibilidade da grade no editor.

**Limpar as guias de desenho altera o espaçamento da grade?**

Não. Adicionar, mover ou limpar uma guia deixa o intervalo da grade inalterado.

**Diferentes seções de uma apresentação podem ter diferentes configurações de visualização?**

Não. [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--) aplica-se a toda a apresentação.

**Posso salvar diferentes configurações de visualização para diferentes usuários?**

O arquivo armazena um único conjunto de propriedades de visualização para todos. Um editor pode também aplicar preferências locais do usuário.

**Posso salvar configurações de visualização em um modelo?**

Sim. Apresentações criadas a partir do modelo herdam suas configurações de visualização salvas.