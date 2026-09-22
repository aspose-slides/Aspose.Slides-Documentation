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
description: "Descubra as propriedades de visualização do Aspose.Slides for Node.js via Java para personalizar formatos PPT, PPTX e ODP—ajuste layouts, níveis de zoom e configurações de exibição."
---
## **Introdução**

A visualização normal consiste em três regiões de conteúdo: o slide propriamente dito, uma região de conteúdo lateral e uma região de conteúdo inferior. Propriedades referentes ao posicionamento das diferentes regiões de conteúdo. Essas informações permitem que o aplicativo salve o estado da visualização no arquivo, de modo que, ao reabrir, a visualização esteja no mesmo estado em que a apresentação foi salva pela última vez.

Foi adicionado o método [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) para fornecer acesso às propriedades da visualização normal de uma apresentação.  

Foram adicionadas as classes [NormalViewProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/NormalViewRestoredProperties), seus descendentes e o enum [SplitterBarStateType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SplitterBarStateType).

## **Sobre NormalViewProperties**

Representa as propriedades da visualização normal.

Os métodos [getShowOutlineIcons](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) e [setShowOutlineIcons](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) especificam se o aplicativo deve exibir ícones ao mostrar conteúdo de contorno em qualquer das regiões de conteúdo do modo de visualização normal.

Os métodos [getSnapVerticalSplitter](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) e [setSnapVerticalSplitter](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) especificam se o divisor vertical deve encaixar em um estado minimizado quando a região lateral está suficientemente pequena.

A propriedade [getPreferSingleView](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) e [setPreferSingleView](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) especificam se o usuário prefere ver uma única região de conteúdo em tela cheia em vez da visualização normal padrão com três regiões de conteúdo. Se habilitado, o aplicativo pode optar por exibir uma das regiões de conteúdo em toda a janela.

Os métodos [getVerticalBarState](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) e [getHorizontalBarState](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) especificam o estado em que a barra divisor horizontal ou vertical deve ser mostrada. Uma barra divisor horizontal separa o slide da região de conteúdo abaixo do slide, a barra divisor vertical separa o slide da região de conteúdo lateral. Os valores possíveis são: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) e [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

Os métodos [getRestoredLeft](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) e [getRestoredTop](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) especificam o dimensionamento da região superior ou lateral do slide da visualização normal, quando o valor [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SplitterBarStateType#Restored) for aplicado para [getVerticalBarState](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) e [getHorizontalBarState](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) de forma correspondente.

## **Sobre a Restauração de NormalViewProperties**

Especifica o dimensionamento da região do slide (largura quando filho de [getRestoredTop](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--), altura quando filho de [getRestoredLeft](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) da visualização normal, quando a região tem um tamanho restaurado variável (nem minimizada nem maximizada).  

O método [getDimensionSize](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) especifica o tamanho da região do slide (largura quando filho de restoredTop, altura quando filho de restoredLeft).  

O método [getAutoAdjust](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) especifica se o tamanho da região de conteúdo lateral deve compensar o novo tamanho ao redimensionar a janela que contém a visualização dentro do aplicativo.  

Um exemplo abaixo demonstra como acessar as propriedades [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) de uma apresentação.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

{{% alert color="info" %}} 

O Aspose.Slides for Node.js via Java agora suporta a definição do valor de zoom padrão para a apresentação, de modo que, ao abrir a apresentação, o zoom já esteja definido. Isso pode ser feito configurando o [ViewProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ViewProperties) de uma apresentação. Tanto [getSlideViewProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) quanto [getNotesViewProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) podem ser definidos programaticamente. Neste tópico, veremos com um exemplo como definir as [View Properties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ViewProperties) de uma [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation) no Aspose.Slides.

{{% /alert %}} 

Para definir as propriedades de visualização, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation).
2. Defina as [View Properties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ViewProperties) da [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation).
3. Grave a apresentação como um arquivo [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   No exemplo abaixo, definimos o valor de zoom para a visualização de slide e também para a visualização de notas.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    // Definindo as propriedades de visualização da apresentação
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Valor de zoom em porcentagem para a visualização de slide
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Valor de zoom em porcentagem para a visualização de notas
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir o Espaçamento da Grade**

Use [Presentation.getViewProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#getViewProperties--) para acessar as configurações de visualização em todo a apresentação. Os métodos [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) e [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) leem ou alteram o intervalo da grade de edição subjacente. Esta configuração se aplica a toda a apresentação, não a um slide individual. O espaçamento da grade é especificado em pontos, onde 72 pontos correspondem a uma polegada. Use um valor positivo, conforme exigido pela documentação da API.

O exemplo a seguir abre um `demo.pptx` existente, imprime o espaçamento atual da grade, define um intervalo de um quarto de polegada e salva o resultado.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("demo.pptx");
try {
    var gridSpacing = presentation.getViewProperties().getGridSpacing();
    console.log("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18);
    presentation.save("grid-spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A grade é diferente dos [guias de desenho](/slides/pt/nodejs-java/drawing-guides/). O espaçamento da grade controla um intervalo regular, enquanto os guias de desenho são linhas de alinhamento horizontais ou verticais posicionadas individualmente. Adicionar, mover ou limpar guias de desenho não altera o espaçamento da grade.

Tanto a grade quanto os guias de desenho são auxiliares de edição. Eles não são renderizados como conteúdo de slide em PDF, imagens, SVG ou apresentação de slides. Armazenar o espaçamento da grade não garante que um editor exibirá a grade: sua visibilidade também depende das preferências do visualizador ou editor.

## **FAQ**

**Por que a grade não está visível depois de reabrir a apresentação?**  
O arquivo armazena o espaçamento da grade, mas o editor controla se a grade é exibida. Verifique as configurações de visibilidade da grade no editor.

**Limpar os guias de desenho altera o espaçamento da grade?**  
Não. Os guias de desenho e o espaçamento da grade são configurações independentes. Limpar os guias deixa o intervalo da grade armazenado inalterado.

**Posso definir diferentes configurações de visualização para diferentes seções de uma apresentação?**  
As configurações de visualização são definidas ao nível da apresentação ([Normal View]/[Slide View]), não por seção, portanto um único conjunto de parâmetros se aplica a todo o documento ao ser aberto.

**Posso pré‑definir diferentes estados de visualização para diferentes usuários?**  
Não. As configurações são armazenadas no arquivo e são compartilhadas. Aplicativos de visualização podem obedecer às preferências do usuário, mas o arquivo em si contém um único conjunto de propriedades de visualização.

**Posso preparar um modelo com View Properties pré‑definidas para que novas apresentações abram da mesma forma?**  
Sim. Como as view properties são armazenadas ao nível da apresentação, você pode incorporá‑las em um modelo e criar novos documentos a partir dele com a mesma configuração inicial de visualização.