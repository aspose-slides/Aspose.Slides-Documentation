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
- divisor vertical de encaixe
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
description: "Descubra as propriedades de visualização do Aspose.Slides para PHP via Java para personalizar formatos de slides PPT, PPTX e ODP — ajuste layouts, níveis de zoom e configurações de exibição."
---
## **Introdução**

A visualização normal consiste em três regiões de conteúdo: o próprio slide, uma região de conteúdo lateral e uma região de conteúdo inferior. Propriedades referentes ao posicionamento das diferentes regiões de conteúdo. Essas informações permitem que a aplicação salve seu estado de visualização no arquivo, de modo que, ao ser reaberta, a visualização esteja no mesmo estado em que a apresentação foi salva pela última vez.

O método [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) foi adicionado para fornecer acesso às propriedades de visualização normal da apresentação.  

As classes [NormalViewProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewRestoredProperties) e seus descendentes, bem como o enum [SplitterBarStateType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SplitterBarStateType) foram adicionados.

## **Sobre INormalViewProperties**

Representa as propriedades de visualização normal.

Os métodos [getShowOutlineIcons](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) e [setShowOutlineIcons](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) especificam se a aplicação deve mostrar ícones ao exibir conteúdo de contorno em qualquer das regiões de conteúdo do modo de visualização normal.

Os métodos [getSnapVerticalSplitter](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) e [setSnapVerticalSplitter](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) especificam se a divisória vertical deve colapsar para um estado minimizado quando a região lateral for suficientemente pequena.

A propriedade [getPreferSingleView](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) e [setPreferSingleView](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) especificam se o usuário prefere ver uma única região de conteúdo em tela cheia em vez da visualização normal padrão com três regiões de conteúdo. Quando habilitado, a aplicação pode optar por exibir uma das regiões de conteúdo em toda a janela.

Os métodos [getVerticalBarState](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) e [getHorizontalBarState](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) especificam o estado em que a barra de divisão horizontal ou vertical deve ser exibida. Uma barra de divisão horizontal separa o slide da região de conteúdo abaixo do slide; a barra de divisão vertical separa o slide da região de conteúdo lateral. Valores possíveis são: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SplitterBarStateType/#Maximized) e [SplitterBarStateType::Restored](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SplitterBarStateType/#Restored).

Os métodos [getRestoredLeft](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) e [getRestoredTop](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties#getRestoredTop) especificam o dimensionamento da região superior ou lateral do slide na visualização normal, quando o valor [SplitterBarStateType::Restored](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SplitterBarStateType/#Restored) é aplicado para [getVerticalBarState](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) e [getHorizontalBarState](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) respectivamente.

## **Sobre Restoring INormalViewProperties**

Especifica o dimensionamento da região do slide (largura quando filho de [getRestoredTop](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#getRestoredTop), altura quando filho de [getRestoredLeft](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) da visualização normal, quando a região tem um tamanho restaurado variável (nem minimizado nem maximizado).  

O método [getDimensionSize](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) especifica o tamanho da região do slide (largura quando filho de restoredTop, altura quando filho de restoredLeft).  

O método [getAutoAdjust](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) especifica se o tamanho da região de conteúdo lateral deve compensar o novo tamanho ao redimensionar a janela que contém a visualização dentro da aplicação.  

Um exemplo abaixo mostra como acessar as propriedades [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) de uma apresentação.

```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # Restaurar as propriedades de visualização da apresentação
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Definir o Valor de Zoom Padrão**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java agora suporta a definição do valor de zoom padrão para a apresentação, de modo que, ao abrir a apresentação, o zoom já esteja configurado. Isso pode ser feito definindo o [ViewProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ViewProperties) de uma apresentação. [getSlideViewProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) assim como [getNotesViewProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) podem ser definidos programaticamente. Neste tópico, veremos com um exemplo como definir as [View Properties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ViewProperties) de [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation) em [Aspose.Slides](/slides/pt/).

{{% /alert %}} 

Para definir as propriedades de visualização, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation).
2. Defina as [View Properties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ViewProperties) da [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation).
3. Grave a apresentação como um arquivo [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   No exemplo abaixo, definimos o valor de zoom tanto para a visualização de slide quanto para a visualização de notas.

```php
  $presentation = new Presentation();
  try {
    # Definindo as propriedades de visualização da apresentação
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // Valor de zoom em porcentagem para visualização de slide
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // Valor de zoom em porcentagem para visualização de notas

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **FAQ**

**Posso definir configurações de visualização diferentes para seções distintas de uma apresentação?**

As [configurações de visualização](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/getviewproperties/) são definidas ao nível da apresentação ([Normal View](https://reference.aspose.com/slides/pt/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/pt/php-java/aspose.slides/viewproperties/getslideviewproperties/)), não por seção, portanto um único conjunto de parâmetros se aplica a todo o documento quando ele é aberto.

**Posso pré‑definir estados de visualização diferentes para usuários diferentes?**

Não. As configurações são armazenadas no arquivo e são compartilhadas. Aplicativos visualizadores podem respeitar preferências do usuário, mas o arquivo em si contém um único conjunto de propriedades de visualização.

**Posso preparar um modelo com View Properties pré‑definidos para que novas apresentações abram da mesma forma?**

Sim. Como as [view properties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/getviewproperties/) são armazenadas ao nível da apresentação, você pode incorporá‑las em um modelo e criar novos documentos a partir dele com a mesma configuração de visualização inicial.