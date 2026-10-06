---
title: Gerenciar SmartArt em Apresentações PowerPoint usando JavaScript
linktitle: Gerenciar SmartArt
type: docs
weight: 10
url: /pt/nodejs-java/manage-smartart/
keywords:
- SmartArt
- Texto SmartArt
- tipo de layout
- propriedade oculta
- organograma
- organograma com imagens
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a criar e editar SmartArt do PowerPoint com Aspose.Slides para Node.js usando exemplos claros de código JavaScript que aceleram o design e a automação de slides."
---
## **Visão geral**

SmartArt é um diagrama do PowerPoint composto por nós, formas de nó e um layout. Com Aspose.Slides for Node.js via Java, você pode criar SmartArt, ler texto de seus nós, alterar seu layout, inspecionar nós ocultos, configurar layouts de organogramas e criar organogramas com imagens.

## **Obter texto de um objeto SmartArt**

Um nó SmartArt pode conter uma ou mais formas. Para ler o texto das formas do nó, itere através de [SmartArt.getAllNodes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/getallnodes/), então leia o [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) retornado por [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartshape/gettextframe/).

O exemplo requer uma apresentação com pelo menos um slide e um objeto SmartArt como a primeira forma naquele slide. Ele imprime cada quadro de texto disponível no console.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
        let smartArt = shape;
        let nodes = smartArt.getAllNodes();

        for (let nodeIndex = 0; nodeIndex < nodes.size(); nodeIndex++) {
            let node = nodes.get_Item(nodeIndex);
            let nodeShapes = node.getShapes();

            for (let shapeIndex = 0; shapeIndex < nodeShapes.size(); shapeIndex++) {
                let nodeShape = nodeShapes.get_Item(shapeIndex);

                if (nodeShape.getTextFrame() != null) {
                    console.log(nodeShape.getTextFrame().getText());
                }
            }
        }
    } else {
        console.log("The first shape is not a SmartArt object.");
    }
} finally {
    presentation.dispose();
}
```

## **Alterar o tipo de layout de um objeto SmartArt**

O layout do SmartArt controla como os nós são organizados e conectados. O exemplo a seguir cria um objeto SmartArt com o valor `BasicBlockList` de [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/), altera para o valor `BasicProcess` e salva a apresentação. A posição e o tamanho passados para [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addsmartart/) são medidos em pontos. Use [SmartArt.setLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setlayout/) para mudar o layout.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);
    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Verificar se um nó SmartArt está oculto**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/ishidden/) indica se o nó está oculto no modelo de dados do SmartArt. Nós ocultos podem existir na estrutura mesmo quando o layout selecionado não os exibe como elementos de diagrama visíveis.

O exemplo a seguir adiciona um nó a um objeto SmartArt que usa o valor `RadialCycle` de [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) e verifica o estado oculto do nó adicionado. Ele imprime uma mensagem se o nó estiver oculto e salva o diagrama.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);
    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Obter ou definir o layout do organograma**

Para diagramas SmartArt que utilizam um layout de organograma, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/getorganizationchartlayout/) e [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/setorganizationchartlayout/) definem como os nós filhos são organizados sob um nó pai. Por exemplo, é possível definir que os nós filho pendam à esquerda, à direita ou a ambos os lados, dependendo do [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/) selecionado.

O exemplo a seguir cria um organograma e define o layout do primeiro nó para o valor `LeftHanging` de [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/). O índice baseado em zero `0` seleciona o primeiro nó de nível superior; seus nós filhos utilizam a disposição selecionada. A apresentação modificada é então salva.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);
    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Criar um organograma com imagens**

Um organograma com imagens é um layout SmartArt projetado para diagramas hierárquicos que incluem marcadores de posição de imagem. Use o valor `PictureOrganizationChart` de [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) ao adicionar o objeto SmartArt a um slide. Este exemplo salva um diagrama com marcadores de posição de imagem; ele não preenche os marcadores com imagens.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Converter diagramas legados em grupos de formas**

Ao modernizar uma apresentação existente, pode ser necessário atualizar um organograma criado originalmente no PowerPoint 97–2003. Aspose.Slides representa esses diagramas legados como objetos [LegacyDiagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/). Use [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/converttogroupshape/) para converter um diagrama em um grupo de formas, permitindo editar elementos visuais individuais. Consulte a [LegacyDiagram API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/) para detalhes.

A conversão adiciona um novo grupo à coleção de formas sem remover o diagrama original. Após a conversão bem‑sucedida, remova o original com [ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/remove/) para evitar conteúdo duplicado. Reúna os diagramas legados em uma lista antes de convertê‑los, de modo que a adição e remoção de formas não interrompa a iteração.

O exemplo a seguir abre uma apresentação, procura em cada slide, converte os diagramas em grupos de formas e salva a apresentação atualizada como PPTX.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("legacy-diagrams.ppt");
try {
    let slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        let slide = slides.get_Item(slideIndex);
        let shapes = slide.getShapes();
        let legacyDiagrams = [];
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            let shape = shapes.get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.ILegacyDiagram")) {
                legacyDiagrams.push(shape);
            }
        }

        for (let legacyDiagram of legacyDiagrams) {
            let groupShape = legacyDiagram.convertToGroupShape();

            if (groupShape != null) {
                shapes.remove(legacyDiagram);
            }
        }
    }

    presentation.save("modernized.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A apresentação salva contém grupos de formas editáveis no lugar dos diagramas legados convertidos, sem diagramas originais permanecendo ao lado deles. Abra o PPTX no PowerPoint para editar elementos individuais dentro de cada grupo, como texto, preenchimento ou posição.

## **FAQ**

**O SmartArt oferece suporte a espelhamento ou inversão para idiomas RTL?**

Sim. O método [SmartArt.setReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setreversed/) altera a direção do diagrama de esquerda‑para‑direita para direita‑para‑esquerda, ou vice‑versa, quando o layout SmartArt selecionado suporta inversão.

**Como posso copiar um SmartArt para o mesmo slide ou para outra apresentação preservando a formatação?**

Você pode [clonar a forma SmartArt](/slides/pt/nodejs-java/shape-manipulations/) com [ShapeCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addclone/) ou [clonar o slide inteiro](/slides/pt/nodejs-java/clone-slides/) que contém o SmartArt. Ambas as abordagens preservam tamanho, posição e formatação.

**Como renderizar um SmartArt como imagem raster para visualização ou exportação web?**

[Renderize o slide](/slides/pt/nodejs-java/convert-powerpoint-to-png/) ou a apresentação inteira para PNG ou JPEG. O SmartArt é renderizado como parte do slide.

**Como encontrar um objeto SmartArt específico em um slide se houver vários?**

Use [Shape.setAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setalternativetext/) ou [Shape.setName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setname/) para atribuir um texto alternativo ou nome distinto à forma SmartArt, procure esse valor em [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes) e, em seguida, verifique se a forma correspondente é um [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/).