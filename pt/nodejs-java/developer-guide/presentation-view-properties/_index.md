---
title: Recuperar e Atualizar Propriedades de Visualização da Apresentação em JavaScript
linktitle: Propriedades de Visualização
type: docs
weight: 80
url: /pt/nodejs-java/presentation-view-properties/
keywords:
- propriedades de visualização
- visualização normal
- conteúdo de contorno
- ícones de contorno
- ajuste automático do divisor vertical
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
description: "Descubra as propriedades de visualização do Aspose.Slides for Node.js via Java para personalizar formatos PPT, PPTX e ODP — ajuste layouts, níveis de zoom e configurações de exibição."
---
## **Introdução**

A visualização normal consiste em três regiões de conteúdo: o próprio slide, uma região de conteúdo lateral e uma região de conteúdo inferior. Propriedades relativas ao posicionamento das diferentes regiões de conteúdo. Essas informações permitem que o aplicativo salve seu estado de visualização no arquivo, de modo que, ao ser reaberto, a visualização esteja no mesmo estado em que a apresentação foi salva pela última vez.

O método [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) foi adicionado para fornecer acesso às propriedades de visualização normal da apresentação.  

As classes [NormalViewProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/NormalViewRestoredProperties) e seus descendentes, bem como o enum [SplitterBarStateType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SplitterBarStateType) foram adicionados.

## **Sobre NormalViewProperties**

Representa as propriedades de visualização normal.

Os métodos [getShowOutlineIcons](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) e [setShowOutlineIcons](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) especificam se o aplicativo deve mostrar ícones ao exibir o conteúdo de contorno em qualquer uma das regiões de conteúdo do modo de visualização normal.

Os métodos [getSnapVerticalSplitter](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) e [setSnapVerticalSplitter](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) especificam se o divisor vertical deve se recolher para um estado minimizado quando a região lateral está suficientemente pequena.

A propriedade [getPreferSingleView](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) e [setPreferSingleView](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) especificam se o usuário prefere ver uma única região de conteúdo em tela cheia em vez da visualização normal padrão com três regiões de conteúdo. Se ativada, o aplicativo pode escolher exibir uma das regiões de conteúdo em toda a janela.

Os métodos [getVerticalBarState](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) e [getHorizontalBarState](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) especificam o estado em que a barra do divisor horizontal ou vertical deve ser exibida. Uma barra de divisão horizontal separa o slide da região de conteúdo abaixo do slide, enquanto a barra de divisão vertical separa o slide da região de conteúdo lateral. Os valores possíveis são: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) e [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

Os métodos [getRestoredLeft](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) e [getRestoredTop](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) especificam o dimensionamento da região superior ou lateral do slide na visualização normal, quando o valor [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SplitterBarStateType#Restored) é aplicado para [getVerticalBarState](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) e [getHorizontalBarState](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) de forma correspondente.

## **Sobre a Restauração de NormalViewProperties**

Especifica o dimensionamento da região do slide (largura quando é filho de [getRestoredTop](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--), altura quando é filho de [getRestoredLeft](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) da visualização normal, quando a região tem um tamanho restaurado variável (nem minimizado nem maximizado).  

O método [getDimensionSize](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) especifica o tamanho da região do slide (largura quando é filho de restoredTop, altura quando é filho de restoredLeft).  

O método [getAutoAdjust](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) especifica se o tamanho da região de conteúdo lateral deve compensar o novo tamanho ao redimensionar a janela que contém a visualização dentro do aplicativo.  

Um exemplo é apresentado abaixo que mostra como acessar as propriedades [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) de uma apresentação.

```javascript

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // Restaurar as propriedades de visualização da apresentação
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Definir Valor de Zoom Padrão**

{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java agora oferece suporte à definição do valor de zoom padrão para a apresentação, de modo que, ao abrir a apresentação, o zoom já esteja definido. Isso pode ser feito configurando o [ViewProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ViewProperties) de uma apresentação. Os métodos [getSlideViewProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) e [getNotesViewProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) podem ser definidos programaticamente. Neste tópico, veremos com um exemplo como definir as [View Properties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ViewProperties) de uma [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation) em [Aspose.Slides](/slides/pt/).

{{% /alert %}} 

Para definir as propriedades de visualização, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation).
1. Defina as [View Properties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ViewProperties) da [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation).
1. Salve a apresentação como um arquivo [PPTX](https://docs.fileformat.com/presentation/pptx/). No exemplo abaixo, definimos o valor de zoom para a visualização de slide e também para a visualização de notas.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Definindo as propriedades de visualização da apresentação
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Valor de zoom em porcentagem para visualização de slide
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Valor de zoom em porcentagem para visualização de notas
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Posso definir diferentes configurações de visualização para diferentes seções de uma apresentação?**

As [configurações de visualização](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/getviewproperties/) são definidas no nível da apresentação ([Normal View](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), não por seção, portanto um único conjunto de parâmetros se aplica a todo o documento ao ser aberto.

**Posso pré-definir diferentes estados de visualização para diferentes usuários?**

Não. As configurações são armazenadas no arquivo e são compartilhadas. Aplicativos de visualização podem respeitar as preferências do usuário, mas o próprio arquivo contém apenas um conjunto de propriedades de visualização.

**Posso preparar um modelo com View Properties pré-definidas para que novas apresentações abram da mesma forma?**

Sim. Como as [view properties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/getviewproperties/) são armazenadas no nível da apresentação, você pode incorporá‑las em um modelo e criar novos documentos a partir dele com a mesma configuração de visualização inicial.