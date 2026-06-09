---
title: Gerenciar SmartArt em Apresentações PowerPoint Usando Java
linktitle: Gerenciar SmartArt
type: docs
weight: 10
url: /pt/java/manage-smartart/
keywords:
- SmartArt
- texto SmartArt
- tipo de layout
- propriedade oculta
- organograma
- organograma com imagem
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Aprenda a criar e editar SmartArt no PowerPoint com Aspose.Slides para Java usando exemplos de código claros que aceleram o design de slides e a automação."
---
## **Visão geral**

SmartArt é um diagrama do PowerPoint composto por nós, formas de nó e um layout. Com Aspose.Slides para Java, você pode criar SmartArt, ler texto de seus nós, alterar seu layout, inspecionar nós ocultos, configurar layouts de organogramas e criar organogramas com imagens.

## **Obter texto de um objeto SmartArt**

Um nó de SmartArt pode conter uma ou mais formas. Para ler o texto visível, itere através de [ISmartArt.getAllNodes](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ismartart/#getAllNodes--), e então leia o [ITextFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/) retornado por [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ismartartshape/#getTextFrame--).

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

O layout do SmartArt controla como os nós são organizados e conectados. O exemplo a seguir cria um objeto SmartArt com o valor `BasicBlockList` do [SmartArtLayoutType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/SmartArtLayoutType), altera para o valor `BasicProcess` e salva a apresentação.

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

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ismartartnode/#isHidden--) indica se o nó está oculto no modelo de dados do SmartArt. Nós ocultos podem existir na estrutura mesmo quando o layout selecionado não os exibe como elementos visíveis do diagrama.

O exemplo a seguir adiciona um nó a um objeto SmartArt que usa o valor `RadialCycle` do [SmartArtLayoutType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/SmartArtLayoutType) e verifica o estado oculto do nó.

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

Para diagramas SmartArt que utilizam um layout de organograma, [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) e [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) definem como os nós filhos são organizados sob um nó pai. Por exemplo, é possível definir que os nós filhos pendam à esquerda, à direita ou de ambos os lados, dependendo do [OrganizationChartLayoutType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/OrganizationChartLayoutType) selecionado.

O exemplo a seguir cria um organograma e define o layout do primeiro nó para o valor `LeftHanging` do [OrganizationChartLayoutType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/OrganizationChartLayoutType).

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

Um organograma de imagem é um layout SmartArt projetado para diagramas hierárquicos que incluem espaços reservados para imagens. Use o valor `PictureOrganizationChart` do [SmartArtLayoutType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/SmartArtLayoutType) ao adicionar o objeto SmartArt a um slide.

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

## **Perguntas frequentes**

**O SmartArt oferece suporte a espelhamento ou inversão para idiomas RTL?**

Sim. O método [ISmartArt.setReversed](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ismartart/#setReversed-boolean-) altera a direção do diagrama de esquerda‑para‑direita para direita‑para‑esquerda, ou vice‑versa, quando o layout SmartArt selecionado suporta inversão.

**Como posso copiar o SmartArt para o mesmo slide ou para outra apresentação preservando a formatação?**

Você pode clonar a forma SmartArt usando [ShapeCollection.addClone](https://reference.aspose.com/slides/pt/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) ou clonar todo o slide que contém o SmartArt ([/slides/pt/java/clone-slides/]( /slides/pt/java/clone-slides/)). Ambas as abordagens preservam tamanho, posição e formatação.

**Como renderizar o SmartArt para uma imagem raster para visualização ou exportação para web?**

Renderize o slide ([/slides/pt/java/convert-powerpoint-to-png/]( /slides/pt/java/convert-powerpoint-to-png/)) ou a apresentação completa para PNG ou JPEG. O SmartArt é renderizado como parte do slide.

**Como localizar um objeto SmartArt específico em um slide se houver vários?**

Defina um texto alternativo ou um nome distintivo usando [Shape.getAlternativeText](https://reference.aspose.com/slides/pt/java/com.aspose.slides/shape/#getAlternativeText--) ou [Shape.getName](https://reference.aspose.com/slides/pt/java/com.aspose.slides/shape/#getName--) na forma SmartArt, procure esse valor em [BaseSlide.getShapes](https://reference.aspose.com/slides/pt/java/com.aspose.slides/baseslide/#getShapes--), e então verifique se a forma correspondente é um [ISmartArt](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ismartart/).