---
title: Gerenciar mestres de slides de apresentação em JavaScript
linktitle: Mestre de Slide
type: docs
weight: 70
url: /pt/nodejs-java/slide-master/
keywords:
- mestre de slide
- slide mestre
- slide mestre PPT
- vários slides mestres
- comparar slides mestres
- plano de fundo
- marcador de posição
- clonar slide mestre
- copiar slide mestre
- duplicar slide mestre
- slide mestre não usado
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Gerenciar mestres de slides no Aspose.Slides para Node.js via Java: acessar, editar, clonar, comparar e remover slides mestres em apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

Um **slide mestre** define configurações de design compartilhadas para um grupo de slides. Ele pode conter formas comuns, logotipos, planos de fundo, estilos de texto, configurações de tema e configurações de rodapé. No PowerPoint, editar um slide mestre é a maneira usual de manter uma apresentação consistente sem repetir a mesma formatação em cada slide.

Aspose.Slides para Node.js via Java suporta o mesmo modelo. Uma apresentação pode conter um ou mais slides mestres, e cada slide mestre pode conter vários slides de layout. Slides normais geralmente não referenciam um slide mestre diretamente. Em vez disso, um slide normal usa um slide de layout, e esse slide de layout pertence a um slide mestre.

A hierarquia é:

1. **Slide mestre** – define o design e o tema compartilhados.  
1. **Slide de layout** – define um arranjo específico de marcadores de posição e formatação ao nível do layout.  
1. **Slide normal** – contém o conteúdo real da apresentação e usa um slide de layout.

![A hierarquia de slides mestres, slides de layout e slides normais](slide-master_2.jpg)

No Aspose.Slides, um slide mestre é representado pela classe [MasterSlide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masterslide/). Todos os slides mestres em uma apresentação estão disponíveis através da coleção `Presentation.getMasters()`.

{{% alert color="info" title="Herança" %}}
Quando a mesma propriedade é definida em mais de um nível, o nível mais específico prevalece. Por exemplo, se um slide mestre e um slide de layout definirem um plano de fundo, os slides baseados naquele layout usarão o plano de fundo do layout. Para mais informações sobre slides de layout, veja [Apply or Change Slide Layouts](/nodejs-java/slide-layout/).
{{% /alert %}}

## **Acessar Slides Mestres**

No PowerPoint, você pode abrir a exibição **Slide Master** em **Exibir** > **Slide Master**.

![O comando Slide Master na guia Exibir do PowerPoint](slide-master_3.jpg)

No Aspose.Slides, use a coleção `getMasters()` para acessar slides mestres:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let firstMasterSlide = presentation.getMasters().get_Item(0);
    let masterSlideCount = presentation.getMasters().size();
    let firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    console.log("Master slides: " + masterSlideCount);
    console.log("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

Você também pode obter o slide mestre usado por um slide normal através do seu layout:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let layoutSlide = slide.getLayoutSlide();
    let masterSlide = layoutSlide.getMasterSlide();
    let masterSlideName = masterSlide.getName();

    console.log(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **O que um Slide Mestre Contém**

Um slide mestre é um objeto semelhante a um slide. Ele herda comportamentos comuns de slide de [BaseSlide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseslide/), portanto expõe muitas das mesmas propriedades usadas por slides normais e de layout. Membros específicos do mestre estão listados na página da API [MasterSlide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masterslide/).

Membros de slide mestre frequentemente usados incluem:

| Membro | Propósito |
| --- | --- |
| `getBackground()` | Define o plano de fundo ao nível do mestre. |
| `getShapes()` | Armazena formas colocadas no mestre, como logotipos, molduras de imagem e texto compartilhado. |
| `getLayoutSlides()` | Armazena os slides de layout que pertencem ao mestre. |
| `getThemeManager()` | Fornece acesso às APIs de tema do mestre. |
| `getHeaderFooterManager()` | Controla cabeçalhos, rodapés, datas e números de slide para o mestre e seus layouts filhos. |
| `getDependingSlides()` | Retorna slides normais que dependem do mestre através de seus layouts. |

## **Adicionar uma Imagem a um Slide Mestre**

Quando você adiciona uma imagem a um slide mestre, ela aparece nos slides que usam layouts desse mestre. Isso é útil para logotipos, marcas d’água, faixas decorativas e outros elementos visuais repetidos.

O exemplo a seguir adiciona um logotipo ao primeiro slide mestre:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let logo = aspose.slides.Images.fromFile("logo.png");

    try {
        let logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            20,
            20,
            80,
            80,
            logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para mais informações sobre molduras de imagem, veja [Picture Frame](/nodejs-java/picture-frame/).

## **Trabalhar com Marcadores de Posição**

Marcadores de posição são normalmente definidos em slides de layout. O slide mestre fornece o estilo e o tema compartilhados que esses layouts herdam, enquanto cada layout decide quais marcadores de posição estão disponíveis e onde eles são colocados.

No PowerPoint, os comandos de marcador de posição estão disponíveis na visualização Slide Master.

![O comando Inserir Placeholder no PowerPoint Slide Master view](slide-master_5.png)

Para adicionar novos marcadores de posição com Aspose.Slides, trabalhe com o slide de layout que pertence ao mestre:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayoutSlide === null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(blankLayoutType, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Você também pode formatar formas de marcador de posição que já existem em um slide mestre. O exemplo a seguir localiza o marcador de posição de título e aplica um preenchimento de gradiente linear:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titlePlaceholder = null;
    let masterShapes = masterSlide.getShapes();
    let masterShapeCount = masterShapes.size();

    for (let masterShapeIndex = 0; masterShapeIndex < masterShapeCount; masterShapeIndex++) {
        let shape = masterShapes.get_Item(masterShapeIndex);

        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            let placeholder = shape.getPlaceholder();

            if (placeholder !== null && placeholder.getType() === aspose.slides.PlaceholderType.Title) {
                titlePlaceholder = shape;
                break;
            }
        }
    }

    if (titlePlaceholder !== null) {
        let gradientFillType = java.newByte(aspose.slides.FillType.Gradient);
        let linearGradientShape = java.newByte(aspose.slides.GradientShape.Linear);
        let redGradientColor = java.newInstanceSync("java.awt.Color", 255, 0, 0);
        let purpleGradientColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(gradientFillType);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(linearGradientShape);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Placeholder de título formatado herdado por slides normais](slide-master_8.png)

Para mais opções de formatação de marcadores de posição e texto, veja [Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) e [Text Formatting](/nodejs-java/text-formatting/).

## **Alterar o Plano de Fundo de um Slide Mestre**

Um plano de fundo mestre é herdado por layouts e slides que não o sobrescrevem. O exemplo a seguir define uma cor de fundo sólida para o primeiro slide mestre:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let masterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "GREEN");

    masterSlide.getBackground().setType(ownBackgroundType);
    masterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para tópicos relacionados, veja [Presentation Background](/nodejs-java/presentation-background/) e [Presentation Theme](/nodejs-java/presentation-theme/).

## **Clonar um Slide Mestre para Outra Apresentação**

Use `MasterSlideCollection.addClone` para copiar um slide mestre para outra apresentação. O mestre copiado pode então ser usado por layouts e slides na apresentação de destino.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let sourcePresentation = new aspose.slides.Presentation("source.pptx");
let destinationPresentation = new aspose.slides.Presentation("destination.pptx");
try {
    let sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    let clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

Se precisar clonar slides normais juntamente com seu mestre, veja [Clone Slides](/nodejs-java/clone-slides/).

## **Adicionar Vários Slides Mestres**

Uma apresentação pode conter múltiplos slides mestres. Isso é útil quando diferentes seções exigem diferentes marcas, estrutura de página ou configurações de tema.

![Comandos do PowerPoint para inserir e gerenciar slides mestres](slide-master_9.jpg)

O exemplo a seguir clona o mestre padrão, atribui ao clone um plano de fundo diferente, cria um layout sob esse mestre clonado e adiciona um novo slide baseado nesse layout:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let defaultMasterSlide = presentation.getMasters().get_Item(0);
    let sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let sectionMasterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    sectionMasterSlide.getBackground().setType(ownBackgroundType);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(blankLayoutType);
    if (sourceBlankLayout === null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    let sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Comparar Slides Mestres**

Slides mestres podem ser comparados com o método `equals` herdado de [BaseSlide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseslide/). A comparação verifica estrutura e conteúdo estático, como formas, texto, formatação, animações e outras configurações de slide. Não compara identificadores únicos, como IDs de slide, ou valores dinâmicos de marcadores de posição, como a data atual.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let firstPresentation = new aspose.slides.Presentation("first.pptx");
let secondPresentation = new aspose.slides.Presentation("second.pptx");
try {
    let firstPresentationMasterCount = firstPresentation.getMasters().size();
    let secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (let firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (let secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            let firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            let secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            let areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                console.log(
                    "first.pptx master #" + firstMasterIndex +
                    " equals second.pptx master #" + secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

Para mais informações, veja [Compare Presentation Slides](/slides/pt/nodejs-java/compare-slides/).

## **Definir a Visualização de Slide Mestre como Visualização Padrão**

Use o método `setLastView` em [ViewProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/viewproperties/) para controlar a visualização que o PowerPoint abre primeiro. O exemplo a seguir abre a apresentação na visualização Slide Master:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para mais configurações de visualização, veja [Save Presentation](/slides/pt/nodejs-java/save-presentation/).

## **Remover Slides Mestres Não Utilizados**

Apresentações às vezes contêm slides mestres que não são mais usados por nenhum slide normal. Remover mestres não utilizados pode reduzir o tamanho do arquivo e simplificar a manutenção de modelos.

Use `removeUnused` para remover mestres não utilizados da coleção `getMasters()`:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Você também pode usar o método de baixo código `Compress.removeUnusedMasterSlides`:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Qual a diferença entre um slide mestre e um slide de layout?

Um slide mestre define configurações de design compartilhadas, como tema, plano de fundo, formas comuns e estilos de texto. Um slide de layout pertence a um slide mestre e define um arranjo específico de marcadores de posição. Um slide normal usa um slide de layout, herdando tanto do layout quanto do mestre.

### Uma apresentação pode conter vários slides mestres?

Sim. Uma apresentação pode conter vários slides mestres. Use múltiplos mestres quando diferentes seções precisam de sistemas visuais ou marcas diferentes.

### Devo adicionar marcadores de posição a um slide mestre ou a um slide de layout?

Na maioria dos casos, adicione marcadores de posição a slides de layout. Coloque elementos visuais compartilhados e formatação comum no slide mestre e, em seguida, coloque os marcadores de posição de conteúdo nos layouts que os slides normais usarão.

### Posso excluir um slide mestre que ainda está em uso?

Não. Um slide mestre que possui slides dependentes não pode ser removido com segurança diretamente. Primeiro mova esses slides para layouts sob outro mestre, ou use um método de limpeza que remova apenas mestres que não estejam em uso.