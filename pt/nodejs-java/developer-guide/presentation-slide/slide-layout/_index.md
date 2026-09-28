---
title: Aplicar ou Alterar Layouts de Slide em JavaScript
linktitle: Layout de Slide
type: docs
weight: 60
url: /pt/nodejs-java/slide-layout/
keywords:
- layout de slide
- layout de conteúdo
- marcador de posição
- design de apresentação
- design de slide
- layout não utilizado
- visibilidade do rodapé
- slide de título
- título e conteúdo
- cabeçalho de seção
- dois conteúdos
- comparação
- apenas título
- layout em branco
- conteúdo com legenda
- imagem com legenda
- título e texto vertical
- título vertical e texto
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Aplicar, criar e modificar layouts de slide no Aspose.Slides para Node.js via Java, adicionar marcadores de posição, remover layouts não utilizados e controlar a visibilidade do rodapé."
---
## **Visão geral**

Um layout de slide define as posições e a formatação de marcadores de posição, como títulos, texto, imagens, gráficos e tabelas. Aplicar um layout confere aos slides uma estrutura consistente, permitindo que cada slide contenha seu próprio conteúdo.

Os layouts mais comuns incluem:

- **Slide de Título**: Contém marcadores de título e subtítulo.
- **Título e Conteúdo**: Contém um marcador de título e um marcador de conteúdo de uso geral.
- **Em branco**: Não contém marcadores de conteúdo e é útil quando cada forma será posicionada manualmente.

## **Entender a Herança de Layout**

Uma apresentação tem três níveis relacionados:

1. Um [slide mestre](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masterslide/) define o tema, formatação compartilhada, fundos e objetos comuns.
1. Um [slide de layout](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/layoutslide/) pertence a um master e define um arranjo particular de marcadores.
1. Um [slide normal](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slide/) usa um layout e armazena o conteúdo inserido para esse slide.

Um slide normal herda o tema e a formatação do seu layout, e o layout herda do seu master. Um valor definido diretamente em um slide normal substitui o valor herdado naquele nível. Quando um slide normal é criado, suas formas de marcador são geradas a partir do layout selecionado, enquanto o conteúdo inserido nesses marcadores pertence ao slide normal.

Adicione os marcadores necessários a um layout antes de criar slides a partir dele. Adicionar outro marcador a um layout posteriormente não adiciona automaticamente uma forma de marcador correspondente aos slides normais existentes.

Esse relacionamento tem duas consequências importantes:

- Uma alteração na formatação herdada ou na geometria dos marcadores existentes em um layout pode atualizar todos os slides que dependem dele. Antes de editar um layout já em uso, verifique seus slides dependentes e revise a apresentação resultante.
- Um layout que ainda é usado por um slide não pode ser removido. Reatribua seus slides dependentes a outro layout primeiro, ou remova apenas layouts não utilizados.

Para mais informações sobre o nível superior desta hierarquia, veja [Mestre de Slide](/slides/pt/nodejs-java/slide-master/).

Para ocultar logos herdados ou formas decorativas do master em um slide ou por meio de um layout compartilhado, veja [Controlar a Visibilidade de Gráficos do Mestre](/slides/pt/nodejs-java/slide-master/). O exemplo compara dois slides usando o mesmo master.

## **Selecionar e Aplicar um Layout de Slide**

Use um valor [SlideLayoutType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slidelayouttype/) quando a apresentação segue definições padrão de layout do PowerPoint. Nomes de layout são editáveis pelo usuário e podem ser localizados, portanto a seleção baseada em nome é menos confiável a menos que você controle o modelo de origem.

O exemplo a seguir procura por **Título e Conteúdo** no primeiro master. Se esse layout não estiver disponível, ele recua deliberadamente para **Em branco**. A segunda verificação de nulo é necessária porque uma apresentação pode conter apenas layouts personalizados. O layout selecionado é então aplicado ao primeiro slide normal através do método [Slide.setLayoutSlide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slide/#setLayoutSlide).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let targetLayout = layoutSlides.getByType(titleAndObjectLayoutType);

    if (targetLayout === null) {
        targetLayout = layoutSlides.getByType(blankLayoutType);
    }

    if (targetLayout === null) {
        throw new Error("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Mudar o layout de um slide não remove as formas normais adicionadas diretamente ao slide. Entretanto, as posições dos marcadores, a formatação herdada e a correspondência entre marcadores existentes e o novo layout podem mudar, portanto inspecione a saída ao alternar entre layouts substancialmente diferentes.

## **Adicionar um Slide de Layout**

A seleção e a criação são operações distintas. O exemplo anterior seleciona um layout existente; não o cria. Para criar um layout, chame o método [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masterlayoutslidecollection/#add) na coleção de layouts do master de destino.

O exemplo a seguir sempre adiciona um novo layout **Título e Conteúdo** denominado `Report Title and Content`, depois adiciona um slide normal baseado nele. Nomes de layout devem ser únicos dentro da coleção.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let reportLayout = masterSlide.getLayoutSlides().add(titleAndObjectLayoutType, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Adicione um layout somente quando o modelo realmente precisar de outra estrutura reutilizável. Se já existir um layout adequado, selecione e reutilize‑o em vez de criar um duplicado.

## **Adicionar Marcadores a um Slide de Layout**

O método [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) fornece um [LayoutPlaceholderManager](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/layoutplaceholdermanager/) para adicionar formas de marcador a um layout.

| Marcador PowerPoint               | Método `LayoutPlaceholderManager` |
| --------------------------------- | --------------------------------- |
| ![Conteúdo](content.png)          | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Conteúdo (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Texto](text.png)                | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Texto (Vertical)](textV.png)    | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Imagem](picture.png)            | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Gráfico](chart.png)             | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Tabela](table.png)              | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)         | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Mídia](media.png)               | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Imagem Online](onlineImage.png) | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

O exemplo a seguir verifica se o layout **Em branco** existe, adiciona quatro marcadores a ele e, em seguida, cria um slide normal que usa o layout modificado. A ordem é intencional: os marcadores são adicionados antes da criação do slide normal, para que Aspose.Slides possa gerar as formas de marcador correspondentes naquele slide.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayout = presentation.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayout === null) {
        throw new Error("The presentation does not contain a Blank layout slide.");
    }

    let placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![Os marcadores no slide de layout](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Mudar a formatação herdada ou a geometria dos marcadores de layout existentes pode afetar slides dependentes. Um marcador de layout recém‑adicionado não é retroalimentado nos slides normais existentes. Teste alterações de layout em uma cópia da apresentação e inspecione cada slide dependente.
{{% /alert %}}

## **Remover Slides de Layout Não Utilizados**

Use o método [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) para remover layouts que nenhum slide normal referencia. O método mantém intactos os layouts que ainda estão em uso.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para remover um layout específico, primeiro use seu método [hasDependingSlides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides) ou [getDependingSlides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/layoutslide/#getDependingSlides). Reatribua quaisquer slides dependentes antes de chamar [LayoutSlide.remove](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/layoutslide/#remove). Tentar remover um layout em uso gera uma [PptxEditException](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pptxeditexception/).

## **Controlar a Visibilidade do Rodapé em um Slide de Layout**

Um layout tem seus próprios marcadores de rodapé, número de slide e data/hora. Use o método [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager) para controlar esses marcadores em um layout. Isso é útil quando, por exemplo, layouts de conteúdo devem exibir rodapés, mas layouts de título não.

O exemplo a seguir seleciona um layout com segurança e torna seus elementos de rodapé visíveis:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = presentation.getLayoutSlides().getByType(titleAndObjectLayoutType);

    if (layoutSlide === null) {
        layoutSlide = presentation.getLayoutSlides().getByType(blankLayoutType);
    }

    if (layoutSlide === null) {
        throw new Error("The presentation does not contain a suitable layout slide.");
    }

    let headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Controlar a Visibilidade do Rodapé em um Master e Seus Layouts Filhos**

Para aplicar configurações de rodapé consistentes em toda a hierarquia de master, use o método [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager). Os métodos de propagação de [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masterslideheaderfootermanager/) operam sobre o master e seus slides de layout dependentes e slides normais; eles não visam apenas um slide normal.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Qual é a diferença entre um Master Slide e um Layout Slide?**

Um master slide define o tema da apresentação e a formatação compartilhada. Um layout slide pertence a um master e define um arranjo reutilizável de marcadores. Slides normais usam esses layouts e armazenam conteúdo específico de cada slide.

**Posso copiar um Layout Slide de uma apresentação para outra?**

Sim. Adicione uma cópia à coleção de destino usando o método [addClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone). Ao copiar entre apresentações, também verifique fontes, temas, imagens e outros recursos usados pelo layout de origem.

**O que acontece quando modifico um layout que já está em uso?**

Slides dependentes herdam as alterações do layout, a menos que substituam a formatação ou objetos afetados localmente. A geometria dos marcadores e o estilo herdado podem, portanto, mudar em vários slides de uma vez. Use [getDependingSlides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) para identificar os slides afetados antes de editar o layout.

**O que acontece se eu remover um layout que ainda está em uso?**

O Aspose.Slides lança uma [PptxEditException](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pptxeditexception/). Reatribua primeiro os slides dependentes ou use [removeUnusedLayoutSlides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) para remover apenas os layouts não referenciados.