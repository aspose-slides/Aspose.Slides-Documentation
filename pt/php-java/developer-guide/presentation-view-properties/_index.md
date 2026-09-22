---
title: Recuperar e Atualizar Propriedades de Visualização da Apresentação em PHP
linktitle: Propriedades de Visualização
type: docs
weight: 80
url: /pt/php-java/presentation-view-properties/
keywords: 
- propriedades de visualização
- visualização normal
- conteúdo de estrutura
- ícones de estrutura
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
description: "Descubra as propriedades de visualização do Aspose.Slides para PHP via Java para personalizar formatos de slides PPT, PPTX e ODP — ajuste layouts, níveis de zoom e configurações de exibição."
---
## **Introdução**

A visualização normal consiste em três regiões de conteúdo: o próprio slide, uma região de conteúdo lateral e uma região de conteúdo inferior. Propriedades referentes ao posicionamento das diferentes regiões de conteúdo. Essas informações permitem que o aplicativo salve seu estado de visualização no arquivo, de modo que, ao ser reaberto, a visualização esteja no mesmo estado de quando a apresentação foi salva pela última vez.

O método [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) foi adicionado para fornecer acesso às propriedades da visualização normal de uma apresentação.  

As classes [NormalViewProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewRestoredProperties) e seus descendentes, bem como o enum [SplitterBarStateType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SplitterBarStateType) foram adicionados.

## **Sobre INormalViewProperties**

Representa as propriedades da visualização normal.

Os métodos [getShowOutlineIcons](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) e [setShowOutlineIcons](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) especificam se o aplicativo deve mostrar ícones ao exibir conteúdo de contorno em qualquer das regiões de conteúdo do modo de visualização normal.

Os métodos [getSnapVerticalSplitter](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) e [setSnapVerticalSplitter](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) especificam se o divisor vertical deve encaixar em um estado minimizado quando a região lateral está suficientemente pequena.

As propriedades [getPreferSingleView](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) e [setPreferSingleView](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) especificam se o usuário prefere ver uma única região de conteúdo em tela cheia em vez da visualização normal padrão com três regiões de conteúdo. Se ativado, o aplicativo pode optar por exibir uma das regiões de conteúdo em toda a janela.

Os métodos [getVerticalBarState](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) e [getHorizontalBarState](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) especificam o estado em que a barra divisória horizontal ou vertical deve ser exibida. Uma barra divisória horizontal separa o slide da região de conteúdo abaixo do slide; a barra divisória vertical separa o slide da região de conteúdo lateral. Os valores possíveis são: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SplitterBarStateType/#Maximized) e [SplitterBarStateType::Restored](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SplitterBarStateType/#Restored).

Os métodos [getRestoredLeft](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) e [getRestoredTop](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties#getRestoredTop) especificam o dimensionamento da região superior ou lateral do slide na visualização normal, quando o valor [SplitterBarStateType::Restored](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SplitterBarStateType/#Restored) é aplicado para [getVerticalBarState](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) e [getHorizontalBarState](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) respectivamente.

## **Sobre a Restauração INormalViewProperties**

Especifica o dimensionamento da região do slide (largura quando filho de [getRestoredTop](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#getRestoredTop), altura quando filho de [getRestoredLeft](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) da visualização normal, quando a região tem um tamanho restaurado variável (nem minimizado nem maximizado).  

O método [getDimensionSize](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) especifica o tamanho da região do slide (largura quando filho de restoredTop, altura quando filho de restoredLeft).  

O método [getAutoAdjust](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) especifica se o tamanho da região de conteúdo lateral deve compensar o novo tamanho ao redimensionar a janela que contém a visualização dentro do aplicativo.  

Um exemplo é apresentado abaixo mostrando como acessar as propriedades [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) de uma apresentação.

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
{{% alert color="info" %}} 

Aspose.Slides for PHP via Java agora oferece suporte à definição do valor de zoom padrão para a apresentação, de modo que, ao abrir a apresentação, o zoom já esteja ajustado. Isso pode ser feito configurando as [ViewProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ViewProperties) de uma apresentação. [getSlideViewProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) assim como [getNotesViewProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) podem ser definidos programaticamente. Neste tópico, veremos com um exemplo como definir as [View Properties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ViewProperties) de uma [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation) no Aspose.Slides.

{{% /alert %}} 

Para definir as propriedades de visualização, siga as etapas abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation).
1. Defina as [View Properties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ViewProperties) da [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation).
1. Grave a apresentação como um arquivo [PPTX](https://docs.fileformat.com/presentation/pptx/). No exemplo abaixo, definimos o valor de zoom para a visualização de slides e também para a visualização de anotações.

```php
  $presentation = new Presentation();
  try {
    # Definindo as propriedades de visualização da apresentação
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // Valor de zoom em porcentagem para a visualização de slide
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // Valor de zoom em porcentagem para a visualização de anotações

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Definir o Espaçamento da Grade**

Use [Presentation::getViewProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#getViewProperties) para acessar as configurações de visualização em todo o documento. Os métodos [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/pt/php-java/aspose.slides/viewproperties/#getGridSpacing) e [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/pt/php-java/aspose.slides/viewproperties/#setGridSpacing) leem ou alteram o intervalo da grade de edição subjacente. Essa configuração se aplica a toda a apresentação, não a um slide individual. O espaçamento da grade é especificado em pontos, onde 72 pontos correspondem a uma polegada. Use um valor positivo, conforme exigido pela documentação da API.

O exemplo a seguir abre um arquivo `demo.pptx` existente, exibe o espaçamento atual da grade, define um intervalo de um quarto de polegada e salva o resultado.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $gridSpacing = $presentation->getViewProperties()->getGridSpacing();
    echo "Current grid spacing: " . $gridSpacing . " points\n";

    $presentation->getViewProperties()->setGridSpacing(18.0);
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A grade difere dos [drawing guides](/slides/pt/php-java/drawing-guides/). O espaçamento da grade controla um intervalo regular, enquanto os guias de desenho são linhas de alinhamento horizontais ou verticais posicionadas individualmente. Adicionar, mover ou remover guias de desenho não altera o espaçamento da grade.

Tanto a grade quanto os guias de desenho são auxílios de edição. Eles não são renderizados como conteúdo de slide em PDF, imagens, SVG ou apresentação de slides. Armazenar o espaçamento da grade não garante que um editor exibirá a grade: sua visibilidade também depende das preferências do visualizador ou do editor.

## **FAQ**

**Por que a grade não fica visível depois que eu reabro a apresentação?**

O arquivo armazena o espaçamento da grade, mas o editor controla se a grade é exibida. Verifique as configurações de visibilidade da grade no editor.

**Limpar os guias de desenho altera o espaçamento da grade?**

Não. Guias de desenho e espaçamento da grade são configurações independentes. Limpar os guias deixa o intervalo da grade armazenado inalterado.

**Posso definir diferentes configurações de visualização para diferentes seções de uma apresentação?**

As [configurações de visualização](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/getviewproperties/) são definidas no nível da apresentação ([Normal View](https://reference.aspose.com/slides/pt/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/pt/php-java/aspose.slides/viewproperties/getslideviewproperties/)), não por seção, portanto um único conjunto de parâmetros se aplica a todo o documento ao ser aberto.

**Posso predefinir diferentes estados de visualização para diferentes usuários?**

Não. As configurações são armazenadas no arquivo e são compartilhadas. Aplicativos visualizadores podem respeitar preferências do usuário, mas o próprio arquivo contém um único conjunto de propriedades de visualização.

**Posso preparar um modelo com View Properties predefinidos para que novas apresentações abram da mesma forma?**

Sim. Como as [view properties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/getviewproperties/) são armazenadas no nível da apresentação, você pode incorporá‑las em um modelo e criar novos documentos a partir dele com a mesma configuração de visualização inicial.