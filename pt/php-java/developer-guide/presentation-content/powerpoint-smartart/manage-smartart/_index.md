---
title: Gerenciar SmartArt em Apresentações PowerPoint Usando PHP
linktitle: Gerenciar SmartArt
type: docs
weight: 10
url: /pt/php-java/manage-smartart/
keywords:
- SmartArt
- texto do SmartArt
- tipo de layout
- propriedade oculta
- organograma
- organograma de imagem
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Aprenda a criar e editar SmartArt no PowerPoint com Aspose.Slides para PHP via Java usando exemplos de código claros que aceleram o design de slides e a automação."
---
## **Visão geral**

SmartArt é um diagrama do PowerPoint composto por nós, formas de nó e um layout. Com Aspose.Slides para PHP via Java, você pode criar SmartArt, ler texto de seus nós, alterar seu layout, inspecionar nós ocultos, configurar layouts de organogramas e criar organogramas de imagens.

## **Obter texto de um objeto SmartArt**

Um nó SmartArt pode conter uma ou mais formas. Para ler o texto das formas do nó, itere através de [SmartArt::getAllNodes](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/getallnodes/), então leia o [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) retornado por [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/smartartshape/gettextframe/).

O exemplo requer uma apresentação com pelo menos um slide e um objeto SmartArt como a primeira forma nesse slide. Ele imprime cada quadro de texto disponível no console.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->get_Item(0);
    for ($i = 0; $i < java_values($smartArt->getAllNodes()->size()); $i++) {
        $node = $smartArt->getAllNodes()->get_Item($i);
        for ($j = 0; $j < java_values($node->getShapes()->size()); $j++) {
            $nodeShape = $node->getShapes()->get_Item($j);
            if (!java_is_null($nodeShape->getTextFrame())) {
                echo $nodeShape->getTextFrame()->getText() . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Alterar o tipo de layout de um objeto SmartArt**

O layout do SmartArt controla como os nós são organizados e conectados. O exemplo a seguir cria um objeto SmartArt com o valor `BasicBlockList` de [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) , altera para o valor `BasicProcess` e salva a apresentação. A posição e o tamanho passados para [ShapeCollection::addSmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) são medidos em pontos. Use [SmartArt::setLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setlayout/) para alterar o layout.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Verificar se um nó SmartArt está oculto**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/ishidden/) indica se o nó está oculto no modelo de dados do SmartArt. Nós ocultos podem existir na estrutura mesmo quando o layout selecionado não os exibe como elementos de diagrama visíveis.

O exemplo a seguir adiciona um nó a um objeto SmartArt que usa o valor `RadialCycle` de [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) , e verifica o estado oculto do nó adicionado. Ele imprime uma mensagem se o nó estiver oculto e salva o diagrama.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
    $node = $smartArt->getAllNodes()->addNode();
    $isHidden = java_values($node->isHidden());

    if ($isHidden) {
        echo "The node is hidden in the SmartArt data model." . PHP_EOL;
    }

    $presentation->save("CheckSmartArtHiddenProperty.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Obter ou definir o layout do organograma**

Para diagramas SmartArt que utilizam um layout de organograma, [SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) e [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) definem como os nós filhos são organizados sob um nó pai. Por exemplo, você pode definir os nós filhos para pendurar à esquerda, à direita ou em ambos os lados, dependendo do [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/) selecionado.

O exemplo a seguir cria um organograma e define o layout para o primeiro nó como o valor `LeftHanging` de [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/). O índice baseado em zero `0` seleciona o primeiro nó de nível superior; seus nós filhos usam o arranjo selecionado. A apresentação modificada é então salva.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;
use aspose\slides\OrganizationChartLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Criar um organograma de imagens**

Um organograma de imagens é um layout SmartArt projetado para diagramas hierárquicos que incluem marcadores de posição de imagens. Use o valor `PictureOrganizationChart` de [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) ao adicionar o objeto SmartArt a um slide. Este exemplo salva um diagrama com marcadores de posição de imagem; ele não preenche os marcadores com imagens.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Converter diagramas legados em grupos de formas**

Ao modernizar uma apresentação existente, pode ser necessário atualizar um organograma criado originalmente no PowerPoint 97–2003. Aspose.Slides representa esses diagramas legados como objetos [LegacyDiagram](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/). Use [LegacyDiagram::convertToGroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/converttogroupshape/) para converter um diagrama em um grupo de formas, permitindo editar elementos visuais individuais. Consulte a [LegacyDiagram API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/) para obter detalhes.

A conversão adiciona um novo grupo à coleção de formas sem remover o diagrama original. Após a conversão bem-sucedida, remova o original com [ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/) para evitar conteúdo duplicado. Reúna os diagramas legados em uma lista antes de convertê-los, de modo que a adição e remoção de formas não interrompa a iteração.

O exemplo a seguir abre uma apresentação, pesquisa cada slide, converte os diagramas em grupos de formas e salva a apresentação atualizada como PPTX.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("legacy-diagrams.ppt");
try {
    $legacyDiagramType = new JavaClass("com.aspose.slides.ILegacyDiagram");
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $legacyDiagrams = [];
        for ($j = 0; $j < java_values($slide->getShapes()->size()); $j++) {
            $shape = $slide->getShapes()->get_Item($j);
            if (java_instanceof($shape, $legacyDiagramType)) {
                $legacyDiagrams[] = $shape;
            }
        }

        foreach ($legacyDiagrams as $legacyDiagram) {
            $groupShape = $legacyDiagram->convertToGroupShape();

            if (!java_is_null($groupShape)) {
                $slide->getShapes()->remove($legacyDiagram);
            }
        }
    }

    $presentation->save("modernized.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A apresentação salva contém grupos de formas editáveis no lugar dos diagramas legados convertidos, sem diagramas originais permanecendo ao lado deles. Abra o PPTX no PowerPoint para editar elementos individuais dentro de cada grupo, como texto, preenchimento ou posição.

## **FAQ**

**SmartArt suporta espelhamento ou reversão para idiomas RTL?**

Sim. O método [SmartArt::setReversed](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/) altera a direção do diagrama de esquerda‑para‑direita para direita‑para‑esquerda, ou vice‑versa, quando o layout SmartArt selecionado suporta reversão.

**Como copiar SmartArt para o mesmo slide ou para outra apresentação preservando a formatação?**

Você pode [clonar a forma SmartArt](/slides/pt/php-java/shape-manipulations/) com [ShapeCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addclone/) ou [clonar o slide inteiro](/slides/pt/php-java/clone-slides/) que contém o SmartArt. Ambas as abordagens preservam tamanho, posição e formatação.

**Como renderizar SmartArt em uma imagem raster para visualização ou exportação web?**

[Renderizar o slide](/slides/pt/php-java/convert-powerpoint-to-png/) ou a apresentação inteira para PNG ou JPEG. O SmartArt é renderizado como parte do slide.

**Como encontrar um objeto SmartArt específico em um slide se houver vários?**

Use [Shape::setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setalternativetext/) ou [Shape::setName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setname/) para atribuir um texto alternativo ou nome distintivo à forma SmartArt, procure esse valor em [BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes), e então verifique se a forma correspondente é um [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/).