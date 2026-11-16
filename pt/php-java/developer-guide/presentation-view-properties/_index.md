---
title: Recuperar e Atualizar Propriedades de Visualização da Apresentação em PHP
linktitle: Propriedades de Visualização
type: docs
weight: 80
url: /pt/php-java/presentation-view-properties/
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
- PHP
- Aspose.Slides
description: "Use Aspose.Slides for PHP via Java para configurar o layout da visualização normal, o zoom de slides e notas, o espaçamento da grade e a visibilidade de comentários em apresentações do PowerPoint."
---
## **Introdução**

Na visualização normal do PowerPoint, o slide aparece entre um painel lateral para miniaturas ou um contorno e um painel de notas abaixo. Aspose.Slides for PHP via Java expõe as preferências de edição salvas da apresentação através de [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/). Esses incluem o layout dos painéis, níveis de zoom, espaçamento da grade e visibilidade de comentários.

## **Sobre NormalViewProperties**

Use [getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnormalviewproperties/) para acessar a classe [NormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) controla se ícones aparecem ao lado dos títulos dos slides no contorno. [setSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setsnapverticalsplitter/) permite que o painel lateral se ajuste ao seu estado minimizado quando o usuário o reduz. [setPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setprefersingleview/) indica preferência por exibir um único painel na janela inteira.

[setVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setverticalbarstate/) controla o divisor entre o painel lateral e o slide. [setHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/sethorizontalbarstate/) controla o divisor acima do painel de notas. Ambos aceitam um valor [SplitterBarStateType](https://reference.aspose.com/slides/php-java/aspose.slides/splitterbarstatetype/) de `Minimized`, `Maximized` ou `Restored`.

## **Sobre Restaurar NormalViewProperties**

Quando um divisor é restaurado, [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredleft/) fornece o tamanho salvo do painel lateral e [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) fornece o tamanho salvo da área superior do slide. Ambos expõem [NormalViewRestoredProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/). Seu método [setDimensionSize](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setdimensionsize/) aceita uma porcentagem de 0 a 100, e [setAutoAdjust](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setautoadjust/) controla se o editor ajusta o tamanho quando a janela é redimensionada.

Este exemplo atualiza uma apresentação existente. Ele restaura o divisor horizontal, define o tamanho retornado por [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) para 80% com ajuste automático habilitado, e maximiza o divisor vertical. Também chama [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) para exibir ícones na visualização de contorno.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SplitterBarStateType;

$presentation = new Presentation("demo.pptx");
try {
    $normalView = $presentation->getViewProperties()->getNormalViewProperties();
    $normalView->setHorizontalBarState(SplitterBarStateType::Restored);
    $normalView->setVerticalBarState(SplitterBarStateType::Maximized);
    $normalView->getRestoredTop()->setAutoAdjust(true);
    $normalView->getRestoredTop()->setDimensionSize(80);
    $normalView->setShowOutlineIcons(true);

    $presentation->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Definir o Valor de Zoom Padrão**

[getSlideViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getslideviewproperties/) e [getNotesViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnotesviewproperties/) armazenam configurações de zoom independentes para o editor. Essas configurações não afetam as dimensões dos slides, a reprodução da apresentação ou a resolução da exportação de imagens.

Este exemplo abre uma apresentação existente e chama [setVariableScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setvariablescale/) para ajustar o slide à janela de edição. Para a página de notas, ele desativa o dimensionamento automático e chama [setScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setscale/) para definir um zoom fixo de 80%.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    $viewProperties->getSlideViewProperties()->setVariableScale(true);
    $viewProperties->getNotesViewProperties()->setVariableScale(false);
    $viewProperties->getNotesViewProperties()->setScale(80);

    $presentation->save("zoom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Definir o Espaçamento da Grade**

O método `setGridSpacing` de [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/) define a distância entre as linhas de grade de edição em toda a apresentação. Ele aceita um valor positivo em pontos, com 72 pontos por polegada. Este exemplo imprime o espaçamento atual em uma apresentação existente e salva uma grade de um quarto de polegada definindo o intervalo para 18 pontos.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current grid spacing: " . java_values($viewProperties->getGridSpacing()) . " points" . PHP_EOL;

    $viewProperties->setGridSpacing(18.0);
    
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A grade se repete em um intervalo fixo. [Guias de desenho](/slides/pt/php-java/drawing-guides/) marcam posições horizontais ou verticais individuais. Ambos são auxiliares de edição e aparecem apenas em editores que os exibem. Apresentações e exportações para PDF, imagens ou SVG os omitem.

## **Mostrar ou Ocultar Comentários ao Abrir uma Apresentação**

[setShowComments](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setshowcomments/) armazena uma preferência que os editores compatíveis usam ao abrir a apresentação. Para uma apresentação existente com comentários, este exemplo imprime a configuração atual e salva uma cópia com os comentários ocultos. Também chama [setLastView](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setlastview/) com [ViewType::SlideView](https://reference.aspose.com/slides/php-java/aspose.slides/viewtype/#SlideView) para que a cópia abra na visualização de slide.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current comment visibility: " . java_values($viewProperties->getShowComments()) . PHP_EOL;

    $viewProperties->setShowComments(NullableBool::False);
    $viewProperties->setLastView(ViewType::SlideView);

    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ocultar comentários preserva seu texto, autores, posições, respostas e status. Para alterar os próprios comentários, veja [Comentários da Apresentação](/slides/pt/php-java/presentation-comments/). As configurações de exportação controlam se os comentários aparecem em PDF, HTML, imagens, notas ou folhetos.

## **FAQ**

**Por que a grade fica oculta quando reabro a apresentação?**  
A apresentação armazena o intervalo da grade. Para ver a grade, habilite a visibilidade da grade no editor.

**Limpar os guias de desenho altera o espaçamento da grade?**  
Não. Adicionar, mover ou limpar um guia deixa o intervalo da grade inalterado.

**Seções diferentes de uma apresentação podem ter configurações de visualização diferentes?**  
Não. [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) se aplica a toda a apresentação.

**Posso salvar configurações de visualização diferentes para usuários diferentes?**  
O arquivo armazena um único conjunto de propriedades de visualização para todos. Um editor também pode aplicar as preferências locais de um usuário.

**Posso salvar configurações de visualização em um modelo?**  
Sim. Apresentações criadas a partir do modelo herdam as configurações de visualização salvas.