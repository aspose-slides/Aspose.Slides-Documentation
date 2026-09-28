---
title: Gerenciar Slides Master de Apresentação em JavaScript
linktitle: Master de Slides
type: docs
weight: 70
url: /pt/nodejs-java/slide-master/
keywords:
- slide master
- slide mestre
- slide mestre PPT
- vários slides mestre
- comparar slides mestre
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
description: "Gerencie slides master no Aspose.Slides para Node.js via Java: acesse, edite, clone, compare e remova slides master em apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

Um **slide master** define configurações de design compartilhadas para um grupo de slides. Ele pode conter formas comuns, logotipos, planos de fundo, estilos de texto, configurações de tema e configurações de rodapé. No PowerPoint, editar um slide master é a forma usual de manter uma apresentação consistente sem repetir a mesma formatação em cada slide.

Aspose.Slides for Node.js via Java oferece o mesmo modelo. Uma apresentação pode conter um ou mais slides master, e cada slide master pode conter vários slides de layout. Slides normais normalmente não referenciam um slide master diretamente. Em vez disso, um slide normal usa um slide de layout, e esse slide de layout pertence a um slide master.

A hierarquia é:

1. **Slide master** – define o design e o tema compartilhados.  
1. **Slide de layout** – define um arranjo específico de marcadores de posição e formatação ao nível do layout.  
1. **Slide normal** – contém o conteúdo real da apresentação e usa um slide de layout.

![A hierarquia de slides master, slides de layout e slides normais](slide-master_2.jpg)

No Aspose.Slides, um slide master é representado pela classe [MasterSlide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masterslide/). Todos os slides master em uma apresentação estão disponíveis através da coleção `Presentation.getMasters()`.

{{% alert color="info" title="Herança" %}}

Quando a mesma propriedade é definida em mais de um nível, o nível mais específico prevalece. Por exemplo, se um slide master e um slide de layout definirem um plano de fundo, os slides baseados naquele layout usarão o plano de fundo do layout. Para mais informações sobre slides de layout, veja [Apply or Change Slide Layouts](/nodejs-java/slide-layout/).

{{% /alert %}}

## **Acessar Slides Master**

No PowerPoint, você pode abrir a visualização Slide Master em **Exibir** > **Slide Master**.

![O comando Slide Master na guia Exibir do PowerPoint](slide-master_3.jpg)

No Aspose.Slides, use a coleção `getMasters()` para acessar os slides master:

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

Você também pode obter o slide master usado por um slide normal por meio de seu layout:

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

## **O que um Slide Master Contém**

Um slide master é um objeto semelhante a um slide. Ele herda o comportamento comum de slide de [BaseSlide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseslide/), portanto expõe muitas das mesmas propriedades de slide usadas por slides normais e de layout. Membros específicos do master são listados na página da API [MasterSlide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masterslide/).

Membros de slide master usados com frequência incluem:

| Membro | Propósito |
| --- | --- |
| `getBackground()` | Define o plano de fundo do slide ao nível do master. |
| `getShapes()` | Armazena formas inseridas no master, como logotipos, molduras de imagem e texto compartilhado. |
| `getLayoutSlides()` | Armazena os slides de layout que pertencem ao master. |
| `getThemeManager()` | Fornece acesso às APIs de tema do master. |
| `getHeaderFooterManager()` | Controla cabeçalhos, rodapés, datas e números de slide para o master e seus layouts filhos. |
| `getDependingSlides()` | Retorna slides normais que dependem do master por meio de seus layouts. |

## **Adicionar uma Imagem a um Slide Master**

Quando você adiciona uma imagem a um slide master, ela aparece nos slides que usam layouts desse master. Isso é útil para logotipos, marcas d’água, faixas decorativas e outros elementos visuais repetidos.

O exemplo a seguir adiciona um logotipo ao primeiro slide master:

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

## **Controlar a Visibilidade de Gráficos do Master**

Use [BaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseslide/#setShowMasterShapes) para ocultar gráficos herdados do master, como logotipos ou formas decorativas, sem excluí‑los do master. Passe `false` para [Slide.setShowMasterShapes](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slide/#setShowMasterShapes) no slide que deve omitir esses gráficos e mantenha `true` nos slides que devem exibi‑los.

O exemplo a seguir cria uma faixa decorativa azul em um master e dois slides que utilizam o mesmo layout em branco. A faixa fica visível no primeiro slide e oculta no segundo. Nenhuma apresentação ou imagem de entrada é necessária.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);
    layoutSlide.setShowMasterShapes(true);

    let slideHeight = presentation.getSlideSize().getSize().getHeight();
    let band = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 60, slideHeight);
    let bandColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let noFillType = java.newByte(aspose.slides.FillType.NoFill);
    band.getFillFormat().setFillType(solidFillType);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(noFillType);

    let visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    let hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O exemplo usa o layout **Blank** fornecido com uma nova apresentação e remove os marcadores de posição originais do slide inicial.

### **Escolher o Escopo da Configuração**

Um slide normal usa seu master por meio de [Slide.getLayoutSlide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slide/#getLayoutSlide) e [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/layoutslide/#getMasterSlide). Definir a propriedade em um slide individual afeta apenas esse slide. Passar `false` para [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/layoutslide/#setShowMasterShapes) oculta os gráficos do master para slides que usam aquele layout compartilhado, mesmo que a configuração própria seja `true`. Para ocultar gráficos em apenas um slide, altere a propriedade do slide e deixe o layout compartilhado inalterado.

A configuração não é suportada como controle de visibilidade no próprio slide master. Em um master, [getShowMasterShapes](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masterslide/#getShowMasterShapes) sempre retorna `false`, e passar `true` para [setShowMasterShapes](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masterslide/#setShowMasterShapes) gera uma exceção. Aplique-a a um slide normal ou a um layout.

### **Distinguir Gráficos do Plano de Fundo**

| Operação | Efeito |
| --- | --- |
| Ocultar gráficos do master | Controla a visibilidade de formas herdadas do master sem excluí‑las ou alterar as próprias formas do slide. |
| Alterar o preenchimento do plano de fundo do slide | Altera a cor, gradiente ou imagem de fundo. Os gráficos do master são formas separadas e podem permanecer visíveis sobre esse fundo. Veja [Presentation Background](/slides/pt/nodejs-java/presentation-background/). |
| Excluir uma forma do master | Remove a forma fonte compartilhada, de modo que não esteja mais disponível para nenhum slide que use aquele master. |

## **Trabalhar com Marcadores de Posição**

Marcadores de posição são normalmente definidos em slides de layout. O slide master fornece o estilo e o tema compartilhados que esses layouts herdam, enquanto cada layout decide quais marcadores de posição estão disponíveis e onde são posicionados.

No PowerPoint, os comandos de marcador de posição estão disponíveis na visualização Slide Master.

![O comando Inserir Marcador de Posição na visualização Slide Master do PowerPoint](slide-master_5.png)

Para adicionar novos marcadores de posição com Aspose.Slides, trabalhe com o slide de layout que pertence ao master:

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

Você também pode formatar formas de marcador de posição que já existam em um slide master. O exemplo a seguir encontra o marcador de posição de título e aplica um preenchimento de gradiente linear:

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

![Título formatado herdado por slides normais](slide-master_8.png)

Para mais opções de formatação de marcadores de posição e texto, veja [Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) e [Text Formatting](/nodejs-java/text-formatting/).

## **Alterar o Plano de Fundo de um Slide Master**

Um plano de fundo de master é herdado por layouts e slides que não o sobrescrevem. O exemplo a seguir define uma cor de fundo sólida para o primeiro slide master:

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

## **Clonar um Slide Master para Outra Apresentação**

Use `MasterSlideCollection.addClone` para copiar um slide master para outra apresentação. O master copiado pode então ser usado por layouts e slides na apresentação de destino.

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

Se precisar clonar slides normais junto com seu master, veja [Clone Slides](/nodejs-java/clone-slides/).

## **Adicionar Vários Slides Master**

Uma apresentação pode conter vários slides master. Isso é útil quando diferentes seções exigem diferentes marcas, estruturas de página ou configurações de tema.

![Comandos do PowerPoint para inserir e gerenciar slides master](slide-master_9.jpg)

O exemplo a seguir clona o master padrão, atribui ao clone um plano de fundo diferente, cria um layout sob esse master clonado e adiciona um novo slide baseado nesse layout:

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

## **Comparar Slides Master**

Slides master podem ser comparados com o método `equals` herdado de [BaseSlide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseslide/). A comparação verifica a estrutura e o conteúdo estático, como formas, texto, formatação, animações e outras configurações de slide. Não compara identificadores únicos, como IDs de slide, ou valores dinâmicos de marcadores de posição, como a data atual.

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

## **Definir a Visualização de Slide Master como Visualização Padrão**

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

## **Remover Slides Master Não Utilizados**

Apresentações às vezes contêm slides master que não são mais usados por nenhum slide normal. Remover masters não utilizados pode reduzir o tamanho do arquivo e simplificar a manutenção do modelo.

Use `removeUnused` para remover masters não usados da coleção `getMasters()`:

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

**Qual é a diferença entre um slide master e um slide de layout?**

Um slide master define configurações de design compartilhadas, como tema, plano de fundo, formas comuns e estilos de texto. Um slide de layout pertence a um slide master e define um arranjo específico de marcadores de posição. Um slide normal usa um slide de layout, portanto herda tanto do layout quanto do master.

**Uma apresentação pode conter vários slides master?**

Sim. Uma apresentação pode conter vários slides master. Use múltiplos masters quando diferentes seções precisarem de sistemas visuais ou marcas distintas.

**Devo adicionar marcadores de posição a um slide master ou a um slide de layout?**

Na maioria dos casos, adicione marcadores de posição a slides de layout. Coloque elementos visuais compartilhados e formatação comum no slide master e coloque os marcadores de posição de conteúdo nos layouts que os slides normais usarão.

**Posso excluir um slide master que ainda está em uso?**

Não. Um slide master que possui slides dependentes não pode ser removido com segurança. Primeiro mova esses slides para layouts sob outro master, ou use um método de limpeza de masters não utilizados que remove apenas masters que não estão em uso.