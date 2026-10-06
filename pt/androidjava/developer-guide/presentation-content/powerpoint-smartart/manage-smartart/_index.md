---
title: Gerenciar SmartArt em Apresentações PowerPoint no Android
linktitle: Gerenciar SmartArt
type: docs
weight: 10
url: /pt/androidjava/manage-smartart/
keywords:
- SmartArt
- texto SmartArt
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

SmartArt é um diagrama do PowerPoint composto por nós, formas de nó e um layout. Com Aspose.Slides para Android via Java, você pode criar SmartArt, ler texto de seus nós, alterar seu layout, inspecionar nós ocultos, configurar layouts de organogramas e criar organogramas de imagem.

## **Obter texto de um objeto SmartArt**

Um nó SmartArt pode conter uma ou mais formas. Para ler o texto das formas do nó, itere através de [ISmartArt.getAllNodes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#getAllNodes--), então leia o [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) retornado por [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--).

O exemplo requer uma apresentação com ao menos um slide e um objeto SmartArt como a primeira forma nesse slide. Ele imprime cada quadro de texto disponível no console.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = (ISmartArt) slide.getShapes().get_Item(0);
    for (ISmartArtNode node : smartArt.getAllNodes()) {
        for (ISmartArtShape nodeShape : node.getShapes()) {
            if (nodeShape.getTextFrame() != null) {
                System.out.println(nodeShape.getTextFrame().getText());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Alterar o tipo de layout de um objeto SmartArt**

O layout do SmartArt controla como os nós são organizados e conectados. O exemplo a seguir cria um objeto SmartArt com o valor `BasicBlockList` de [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/), altera‑o para o valor `BasicProcess` e salva a apresentação. A posição e o tamanho passados para [IShapeCollection.addSmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addSmartArt-float-float-float-float-int-) são medidos em pontos. Use [ISmartArt.setLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#setLayout-int-) para alterar o layout.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Verificar se um nó SmartArt está oculto**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#isHidden--) indica se o nó está oculto no modelo de dados do SmartArt. Nós ocultos podem existir na estrutura mesmo quando o layout selecionado não os exibe como elementos visíveis do diagrama.

O exemplo a seguir adiciona um nó a um objeto SmartArt que usa o valor `RadialCycle` de [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) e verifica o estado oculto do nó adicionado. Ele imprime uma mensagem se o nó estiver oculto e salva o diagrama.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Obter ou definir o layout do organograma**

Para diagramas SmartArt que utilizam um layout de organograma, [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#getOrganizationChartLayout--) e [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#setOrganizationChartLayout-int-) definem como os nós filhos são organizados sob um nó pai. Por exemplo, você pode definir que os nós filhos pendam à esquerda, à direita ou em ambos os lados, dependendo do [OrganizationChartLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/organizationchartlayouttype/) selecionado.

O exemplo a seguir cria um organograma e define o layout do primeiro nó para o valor `LeftHanging` de [OrganizationChartLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/organizationchartlayouttype/). O índice baseado em zero `0` seleciona o primeiro nó de nível superior; seus nós filhos utilizam o arranjo selecionado. A apresentação modificada é então salva.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Criar um organograma de imagem**

Um organograma de imagem é um layout SmartArt projetado para diagramas hierárquicos que incluem marcadores de posição de imagem. Use o valor `PictureOrganizationChart` de [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) ao adicionar o objeto SmartArt a um slide. Este exemplo salva um diagrama com marcadores de posição de imagem; ele não preenche os marcadores com imagens.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Converter diagramas legados em grupos de formas**

Ao modernizar uma apresentação existente, pode ser necessário atualizar um organograma criado originalmente no PowerPoint 97–2003. Aspose.Slides representa esses diagramas legados como objetos [ILegacyDiagram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegacydiagram/). Use [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legacydiagram/#convertToGroupShape--) para converter um diagrama em um grupo de formas, permitindo que você edite elementos visuais individuais. Consulte a [LegacyDiagram API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legacydiagram/) para obter detalhes.

A conversão adiciona um novo grupo à coleção de formas sem remover o diagrama original. Após a conversão bem‑sucedida, remova o original com [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) para evitar conteúdo duplicado. Reúna os diagramas legados em uma lista antes de convertê‑los, de modo que a adição e remoção de formas não interrompa a iteração.

O exemplo a seguir abre uma apresentação, pesquisa cada slide, converte os diagramas em grupos de formas e salva a apresentação atualizada como PPTX.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("legacy-diagrams.ppt");
try {
    for (ISlide slide : presentation.getSlides()) {
        List<ILegacyDiagram> legacyDiagrams = new ArrayList<>();
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ILegacyDiagram) {
                legacyDiagrams.add((ILegacyDiagram) shape);
            }
        }

        for (ILegacyDiagram legacyDiagram : legacyDiagrams) {
            IGroupShape groupShape = legacyDiagram.convertToGroupShape();

            if (groupShape != null) {
                slide.getShapes().remove(legacyDiagram);
            }
        }
    }

    presentation.save("modernized.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A apresentação salva contém grupos de formas editáveis no lugar dos diagramas legados convertidos, sem diagramas originais restantes ao lado deles. Abra o PPTX no PowerPoint para editar elementos individuais dentro de cada grupo, como texto, preenchimento ou posição.

## **FAQ**

**O SmartArt oferece suporte a espelhamento ou reversão para idiomas RTL?**

Sim. O método [ISmartArt.setReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-) troca a direção do diagrama de esquerda‑para‑direita para direita‑para‑esquerda, ou vice‑versa, quando o layout SmartArt selecionado suporta reversão.

**Como posso copiar SmartArt para o mesmo slide ou para outra apresentação preservando a formatação?**

Você pode [clonar a forma SmartArt](/slides/pt/androidjava/shape-manipulations/) com [ShapeCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) ou [clonar o slide inteiro](/slides/pt/androidjava/clone-slides/) que contém o SmartArt. Ambas as abordagens preservam tamanho, posição e formatação.

**Como faço para renderizar SmartArt em uma imagem raster para visualização ou exportação web?**

[Renderize o slide](/slides/pt/androidjava/convert-powerpoint-to-png/) ou a apresentação inteira para PNG ou JPEG. O SmartArt é renderizado como parte do slide.

**Como posso encontrar um objeto SmartArt específico em um slide se houver vários?**

Use [Shape.setAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setAlternativeText-java.lang.String-) ou [Shape.setName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setName-java.lang.String-) para atribuir um texto alternativo ou nome distintivo à forma SmartArt, procure esse valor em [BaseSlide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--) e então verifique se a forma correspondente é um [ISmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/).