---
title: "Recuperar e Atualizar Propriedades de Visualização da Apresentação em PHP"
linktitle: "Propriedades de Visualização"
type: docs
weight: 80
url: /pt/php-java/presentation-view-properties/
keywords:
- "propriedades de visualização"
- "visualização normal"
- "conteúdo de contorno"
- "ícones de contorno"
- "ajustar divisória vertical"
- "visualização única"
- "estado da barra"
- "tamanho da dimensão"
- "ajuste automático"
- "zoom padrão"
- "PowerPoint"
- "OpenDocument"
- "apresentação"
- "PHP"
- "Aspose.Slides"
description: "Descubra as propriedades de visualização do Aspose.Slides para PHP via Java para personalizar formatos de slides PPT, PPTX e ODP — ajuste layouts, níveis de zoom e configurações de exibição."
---
## **Introdução**

A visualização normal consiste em três regiões de conteúdo: o próprio slide, uma região de conteúdo lateral e uma região de conteúdo inferior. Propriedades referentes ao posicionamento das diferentes regiões de conteúdo. Essas informações permitem que o aplicativo salve seu estado de visualização no arquivo, de modo que, ao ser reaberto, a visualização esteja no mesmo estado em que a apresentação foi salva pela última vez.

O método [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) foi adicionado para fornecer acesso às propriedades de visualização normal da apresentação.  

As classes [NormalViewProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewRestoredProperties) e seus descendentes, bem como o enum [SplitterBarStateType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SplitterBarStateType) foram adicionados.

## **Sobre INormalViewProperties**

Representa propriedades da visualização normal.

Os métodos [getShowOutlineIcons](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) e [setShowOutlineIcons](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) especificam se o aplicativo deve mostrar ícones ao exibir conteúdo de contorno em qualquer das regiões de conteúdo do modo de visualização normal.

Os métodos [getSnapVerticalSplitter](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) e [setSnapVerticalSplitter](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) especificam se a divisória vertical deve reduzir a um estado minimizado quando a região lateral for suficientemente pequena.

A propriedade [getPreferSingleView](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) e [setPreferSingleView](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) especificam se o usuário prefere ver uma única região de conteúdo em janela inteira em vez da visualização normal padrão com três regiões de conteúdo. Se habilitado, o aplicativo pode escolher exibir uma das regiões de conteúdo em toda a janela.

Os métodos [getVerticalBarState](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) e [getHorizontalBarState](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) especificam o estado em que a barra divisória horizontal ou vertical deve ser mostrada. Uma barra divisória horizontal separa o slide da região de conteúdo abaixo do slide; a barra divisória vertical separa o slide da região de conteúdo lateral. Os valores possíveis são: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SplitterBarStateType/#Maximized) e [SplitterBarStateType::Restored](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SplitterBarStateType/#Restored).

Os métodos [getRestoredLeft](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) e [getRestoredTop](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties#getRestoredTop) especificam o dimensionamento da região superior ou lateral do slide na visualização normal, quando o valor [SplitterBarStateType::Restored](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SplitterBarStateType/#Restored) é aplicado para [getVerticalBarState](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) e [getHorizontalBarState](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) respectivamente.

## **Sobre Restaurar INormalViewProperties**

Especifica o dimensionamento da região do slide (largura quando filho de [getRestoredTop](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#getRestoredTop), altura quando filho de [getRestoredLeft](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) da visualização normal, quando a região tem um tamanho restaurado variável (nem minimizado nem maximizado).

O método [getDimensionSize](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) especifica o tamanho da região do slide (largura quando filho de restoredTop, altura quando filho de restoredLeft).

O método [getAutoAdjust](https://reference.aspose.com/slides/pt/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) especifica se o tamanho da região de conteúdo lateral deve compensar o novo tamanho ao redimensionar a janela que contém a visualização dentro do aplicativo.

Um exemplo apresentado abaixo mostra como acessar as propriedades [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) de uma apresentação.

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

Aspose.Slides for PHP via Java agora suporta a definição do valor de zoom padrão para apresentações, de modo que, ao abrir a apresentação, o zoom já esteja configurado. Isso pode ser feito definindo o [ViewProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ViewProperties) de uma apresentação. [getSlideViewProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) assim como [getNotesViewProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) podem ser definidos programaticamente. Neste tópico, veremos com um exemplo como definir as [View Properties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ViewProperties) de [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation) no Aspose.Slides.

{{% /alert %}} 

Para definir as propriedades de visualização, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation).
1. Defina as [View Properties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ViewProperties) da [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation).
1. Grave a apresentação como um arquivo [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   No exemplo apresentado abaixo, definimos o valor de zoom para a visualização de slide e também para a visualização de notas.

```php
  $presentation = new Presentation();
  try {
    # Definindo as propriedades de visualização da apresentação
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // Valor de zoom em porcentagem para a visualização de slide
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // Valor de zoom em porcentagem para a visualização de notas

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Definir o Espaçamento da Grade**

Use [Presentation::getViewProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#getViewProperties) para acessar as configurações de visualização de toda a apresentação. Os métodos [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/pt/php-java/aspose.slides/viewproperties/#getGridSpacing) e [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/pt/php-java/aspose.slides/viewproperties/#setGridSpacing) leem ou alteram o intervalo da grade de edição subjacente. Essa configuração se aplica a toda a apresentação, não a um slide individual. O espaçamento da grade é especificado em pontos, onde 72 pontos equivalem a uma polegada. Use um valor positivo, conforme exigido pela documentação da API.

O exemplo a seguir abre um `demo.pptx` existente, exibe o espaçamento atual da grade, define um intervalo de um quarto de polegada e salva o resultado.

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

A grade difere dos [drawing guides](/slides/pt/php-java/drawing-guides/). O espaçamento da grade controla um intervalo regular, enquanto os guias de desenho são linhas de alinhamento horizontais ou verticais posicionadas individualmente. Adicionar, mover ou limpar guias de desenho não altera o espaçamento da grade.

Tanto a grade quanto os guias de desenho são auxílios de edição. Eles não são renderizados como conteúdo de slide em PDF, imagens, SVG ou em uma apresentação de slides. Armazenar o espaçamento da grade não garante que um editor exibirá a grade: sua visibilidade também depende das preferências do visualizador ou do editor.

## **Mostrar ou Ocultar Comentários ao Abrir uma Apresentação**

Use [Presentation::getViewProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/getviewproperties/) para acessar as configurações de visualização de toda a apresentação. Use [ViewProperties::getShowComments](https://reference.aspose.com/slides/pt/php-java/aspose.slides/viewproperties/getshowcomments/) e [ViewProperties::setShowComments](https://reference.aspose.com/slides/pt/php-java/aspose.slides/viewproperties/setshowcomments/) para ler ou alterar a preferência armazenada sobre se os comentários devem ser mostrados quando a apresentação é aberta no PowerPoint ou em outro editor compatível.

Essa configuração controla apenas a preferência de visualização armazenada. Ela não adiciona, remove, edita ou resolve comentários. Ocultar comentários preserva seu conteúdo, autores, posições, respostas e status. Veja [Presentation Comments](/slides/pt/php-java/presentation-comments/) para operações que alteram os próprios comentários.

O exemplo a seguir requer um `comments.pptx` existente contendo comentários. Ele exibe a configuração de visibilidade atual, solicita que os comentários sejam ocultados e salva um novo PPTX sem remover nenhum comentário. Também usa [ViewProperties::setLastView](https://reference.aspose.com/slides/pt/php-java/aspose.slides/viewproperties/setlastview/) com [ViewType::SlideView](https://reference.aspose.com/slides/pt/php-java/aspose.slides/viewtype/#SlideView) para configurar a visualização de edição inicial juntamente com a visibilidade de comentários.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $showComments = $presentation->getViewProperties()->getShowComments();
    echo "Current comment visibility: " . java_values($showComments) . PHP_EOL;

    $presentation->getViewProperties()->setShowComments(NullableBool::False);
    $presentation->getViewProperties()->setLastView(ViewType::SlideView);
    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Essa configuração não determina se os comentários são incluídos nas exportações para PDF, HTML, imagem, notas ou folhetos. Configure as opções específicas de exportação separadamente.

## **FAQ**

**Por que a grade não está visível após eu reabrir a apresentação?**  

O arquivo armazena o espaçamento da grade, mas o editor controla se a grade é exibida. Verifique as configurações de visibilidade da grade no editor.

**Limpar guias de desenho altera o espaçamento da grade?**  

Não. Guias de desenho e espaçamento da grade são configurações independentes. Limpar guias deixa o intervalo da grade armazenado inalterado.

**Posso definir configurações de visualização diferentes para seções diferentes de uma apresentação?**  

As [configurações de visualização](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/getviewproperties/) são definidas ao nível da apresentação ([Normal View](https://reference.aspose.com/slides/pt/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/pt/php-java/aspose.slides/viewproperties/getslideviewproperties/)), não por seção, portanto um único conjunto de parâmetros se aplica a todo o documento quando ele é aberto.

**Posso pré-definir estados de visualização diferentes para usuários diferentes?**  

Não. As configurações são armazenadas no arquivo e são compartilhadas. Aplicativos de visualização podem respeitar preferências de usuário, mas o próprio arquivo contém um único conjunto de propriedades de visualização.

**Posso preparar um modelo com View Properties pré-definidos para que novas apresentações abram da mesma forma?**  

Sim. Como as [view properties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/getviewproperties/) são armazenadas ao nível da apresentação, você pode incorporá-las em um modelo e criar novos documentos a partir dele com a mesma configuração de visualização inicial.