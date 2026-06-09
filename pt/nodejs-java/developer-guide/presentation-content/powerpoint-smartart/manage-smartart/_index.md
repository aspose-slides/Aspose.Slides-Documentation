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
- propriedade oculto
- organograma
- organograma com imagem
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a criar e editar SmartArt do PowerPoint com Aspose.Slides para Node.js usando exemplos claros de código JavaScript que aceleram o design de slides e a automação."
---
## **Visão geral**

SmartArt é um diagrama do PowerPoint composto por nós, formas de nó e um layout. Com Aspose.Slides para Node.js via Java, você pode criar SmartArt, ler texto de seus nós, alterar seu layout, inspecionar nós ocultos, configurar layouts de organograma e criar organogramas com imagens.

## **Obter texto de um objeto SmartArt**

Um nó SmartArt pode conter uma ou mais formas. Para ler o texto visível, itere através de [SmartArt.getAllNodes](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/smartart/#getAllNodes--), então leia o [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/) retornado por [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/smartartshape/#getTextFrame--).

```javascript
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
    }
} finally {
    presentation.dispose();
}
```

## **Alterar o tipo de layout de um objeto SmartArt**

O layout do SmartArt controla como os nós são organizados e conectados. O exemplo a seguir cria um objeto SmartArt com o valor [SmartArtLayoutType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/smartartlayouttype/) `BasicBlockList`, altera para o valor `BasicProcess` e salva a apresentação.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Verificar se um nó SmartArt está oculto**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/smartartnode/ishidden/) indica se o nó está oculto no modelo de dados do SmartArt. Nós ocultos podem existir na estrutura mesmo quando o layout selecionado não os exibe como elementos de diagrama visíveis.

O exemplo a seguir adiciona um nó a um objeto SmartArt que usa o valor [SmartArtLayoutType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/smartartlayouttype/) `RadialCycle` e verifica o estado oculto do nó.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);

    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Obter ou definir o layout do organograma**

Para diagramas SmartArt que utilizam um layout de organograma, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/smartartnode/#getOrganizationChartLayout--) e [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/smartartnode/#setOrganizationChartLayout-int-) definem como nós filhos são organizados sob um nó pai. Por exemplo, você pode definir nós filhos para pendurar à esquerda, à direita ou em ambos os lados, dependendo do [OrganizationChartLayoutType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/organizationchartlayouttype/) selecionado.

O exemplo a seguir cria um organograma e define o layout do primeiro nó para o valor [OrganizationChartLayoutType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);

    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Criar um organograma com imagens**

Um organograma com imagens é um layout SmartArt projetado para diagramas hierárquicos que incluem espaços reservados para imagens. Use o valor [SmartArtLayoutType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` ao adicionar o objeto SmartArt a um slide.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Perguntas frequentes**

**O SmartArt oferece suporte a espelhamento ou inversão para idiomas RTL?**

Sim. O método [SmartArt.setReversed](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/smartart/setreversed/) altera a direção do diagrama de esquerda para direita para direita para esquerda, ou vice‑versa, quando o layout SmartArt selecionado suporta a inversão.

**Como copiar um SmartArt para o mesmo slide ou para outra apresentação preservando a formatação?**

Você pode [clonar a forma SmartArt](/slides/pt/nodejs-java/shape-manipulations/) com [ShapeCollection.addClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shapecollection/addclone/) ou [clonar todo o slide](/slides/pt/nodejs-java/clone-slides/) que contém o SmartArt. Ambas as abordagens preservam tamanho, posição e formatação.

**Como renderizar o SmartArt para uma imagem raster para visualização ou exportação web?**

[Renderize o slide](/slides/pt/nodejs-java/convert-powerpoint-to-png/) ou a apresentação inteira para PNG ou JPEG. O SmartArt é renderizado como parte do slide.

**Como encontrar um objeto SmartArt específico em um slide se houver vários?**

Defina um texto alternativo distinto com [Shape.setAlternativeText](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/setalternativetext/) ou um nome com [Shape.setName](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/setname/) na forma SmartArt, procure esse valor em [BaseSlide.getShapes](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseslide/#getShapes) e, em seguida, verifique se a forma correspondente é um [SmartArt](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/smartart/).