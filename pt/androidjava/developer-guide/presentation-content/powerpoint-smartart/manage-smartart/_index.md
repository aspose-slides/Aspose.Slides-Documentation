---
title: Gerenciar SmartArt em Apresentações PowerPoint no Android
linktitle: Gerenciar SmartArt
type: docs
weight: 10
url: /pt/androidjava/manage-smartart/
keywords:
- SmartArt
- Texto SmartArt
- tipo de layout
- propriedade oculta
- organograma
- organograma de imagem
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Aprenda a criar e editar SmartArt do PowerPoint com Aspose.Slides para Android usando exemplos de código Java claros que aceleram o design e a automação de slides."
---
## **Visão geral**

SmartArt é um diagrama do PowerPoint composto por nós, formas de nó e um layout. Com Aspose.Slides for Android via Java, você pode criar SmartArt, ler texto de seus nós, alterar seu layout, inspecionar nós ocultos, configurar layouts de organogramas e criar organogramas de imagem.

## **Obter texto de um objeto SmartArt**

Um nó SmartArt pode conter uma ou mais formas. Para ler o texto visível, itere através de [ISmartArt.getAllNodes](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ismartart/#getAllNodes--), então leia o [ITextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/) retornado por [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof ISmartArt) {
        ISmartArt smartArt = (ISmartArt) shape;

        for (ISmartArtNode node : smartArt.getAllNodes()) {
            for (ISmartArtShape nodeShape : node.getShapes()) {
                if (nodeShape.getTextFrame() != null) {
                    System.out.println(nodeShape.getTextFrame().getText());
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Alterar o tipo de layout de um objeto SmartArt**

O layout do SmartArt controla como os nós são dispostos e conectados. O exemplo a seguir cria um objeto SmartArt com o valor `BasicBlockList` de [SmartArtLayoutType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/SmartArtLayoutType), altera‑o para o valor `BasicProcess` e salva a apresentação.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Verificar se um nó SmartArt está oculto**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ismartartnode/#isHidden--) indica se o nó está oculto no modelo de dados do SmartArt. Nós ocultos podem existir na estrutura mesmo quando o layout selecionado não os exibe como elementos visíveis do diagrama.

O exemplo a seguir adiciona um nó a um objeto SmartArt que usa o valor `RadialCycle` de [SmartArtLayoutType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/SmartArtLayoutType) e verifica o estado oculto do nó.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Obter ou definir o layout do organograma**

Para diagramas SmartArt que utilizam um layout de organograma, [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) e [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) definem como os nós filhos são dispostos sob um nó pai. Por exemplo, você pode fazer os nós filhos pendurarem à esquerda, à direita ou a ambos os lados, dependendo do [OrganizationChartLayoutType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/OrganizationChartLayoutType) selecionado.

O exemplo a seguir cria um organograma e define o layout do primeiro nó para o valor `LeftHanging` de [OrganizationChartLayoutType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/OrganizationChartLayoutType).

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Criar um organograma de imagem**

Um organograma de imagem é um layout SmartArt projetado para diagramas hierárquicos que incluem marcadores de posição para imagens. Use o valor `PictureOrganizationChart` de [SmartArtLayoutType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/SmartArtLayoutType) ao adicionar o objeto SmartArt a um slide.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**O SmartArt oferece suporte a espelhamento ou inversão para idiomas RTL?**

Sim. O método [ISmartArt.setReversed](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-) altera a direção do diagrama de esquerda‑para‑direita para direita‑para‑esquerda, ou vice‑versa, quando o layout SmartArt selecionado suporta inversão.

**Como copiar SmartArt para o mesmo slide ou para outra apresentação preservando a formatação?**

Você pode [clonar a forma SmartArt](/slides/pt/androidjava/shape-manipulations/) com [ShapeCollection.addClone](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) ou [clonar todo o slide](/slides/pt/androidjava/clone-slides/) que contém o SmartArt. Ambas as abordagens preservam tamanho, posição e formatação.

**Como renderizar SmartArt para uma imagem raster para visualização ou exportação web?**

[Renderize o slide](/slides/pt/androidjava/convert-powerpoint-to-png/) ou a apresentação completa para PNG ou JPEG. O SmartArt é renderizado como parte do slide.

**Como encontrar um objeto SmartArt específico em um slide se houver vários?**

Defina um texto alternativo distinto em [Shape.getAlternativeText](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/shape/#getAlternativeText--) ou um nome em [Shape.getName](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/shape/#getName--) na forma SmartArt, pesquise esse valor em [BaseSlide.getShapes](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/baseslide/#getShapes--), e então verifique se a forma correspondente é um [ISmartArt](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ismartart/).