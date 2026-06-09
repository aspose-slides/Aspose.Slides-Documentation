---
title: Gerenciar SmartArt em Apresentações PowerPoint usando PHP
linktitle: Gerenciar SmartArt
type: docs
weight: 10
url: /pt/php-java/manage-smartart/
keywords:
- SmartArt
- Texto SmartArt
- tipo de layout
- propriedade oculta
- organograma
- organograma com imagens
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Aprenda a criar e editar SmartArt no PowerPoint com Aspose.Slides para PHP via Java usando exemplos de código claros que aceleram o design de slides e a automação."
---
## **Visão geral**

SmartArt é um diagrama do PowerPoint composto por nós, formas de nó e um layout. Com Aspose.Slides for PHP via Java, você pode criar SmartArt, ler texto de seus nós, alterar seu layout, inspecionar nós ocultos, configurar layouts de organogramas e criar organogramas com imagens.

## **Obter texto de um objeto SmartArt**

Um nó de SmartArt pode conter uma ou mais formas. Para ler o texto visível, itere através de [SmartArt::getAllNodes](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartart/#getAllNodes) e, em seguida, leia o [TextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/) retornado por [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartartshape/#getTextFrame).

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.ISmartArt"))) {
        $smartArt = $shape;

        foreach ($smartArt->getAllNodes() as $smartArtNode) {
            foreach ($smartArtNode->getShapes() as $smartArtShape) {
                if (!java_is_null($smartArtShape->getTextFrame())) {
                    echo($smartArtShape->getTextFrame()->getText());
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Alterar o tipo de layout de um objeto SmartArt**

O layout do SmartArt controla como os nós são organizados e conectados. O exemplo a seguir cria um objeto SmartArt com o valor [SmartArtLayoutType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartartlayouttype/) `BasicBlockList`, altera‑o para o valor `BasicProcess` e salva a apresentação.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);

    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Verificar se um nó SmartArt está oculto**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartartnode/ishidden/) indica se o nó está oculto no modelo de dados do SmartArt. Nós ocultos podem existir na estrutura mesmo quando o layout selecionado não os exibe como elementos de diagrama visíveis.

O exemplo a seguir adiciona um nó a um objeto SmartArt que utiliza o valor [SmartArtLayoutType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartartlayouttype/) `RadialCycle` e verifica o estado oculto do nó.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::RadialCycle);

    $smartArtNode = $smartArt->getAllNodes()->addNode();
    $isHidden = $smartArtNode->isHidden();

    if ($isHidden) {
        echo("The node is hidden in the SmartArt data model.");
    }

    $presentation->save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Obter ou definir o layout do organograma**

Para diagramas SmartArt que utilizam um layout de organograma, [SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) e [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) definem como os nós filhos são dispostos sob um nó pai. Por exemplo, você pode definir os nós filhos para pendurar à esquerda, à direita ou em ambos os lados, dependendo do [OrganizationChartLayoutType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/organizationchartlayouttype/) selecionado.

O exemplo a seguir cria um organograma e define o layout do primeiro nó para o valor [OrganizationChartLayoutType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);

    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Criar um organograma com imagens**

Um organograma com imagens é um layout SmartArt projetado para diagramas hierárquicos que incluem marcadores de posição de imagens. Use o valor [SmartArtLayoutType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` ao adicionar o objeto SmartArt a um slide.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**O SmartArt suporta espelhamento ou reversão para idiomas RTL?**

Sim. O método [SmartArt::setReversed](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartart/setreversed/) troca a direção do diagrama de esquerda‑para‑direita para direita‑para‑esquerda, ou vice‑versa, quando o layout SmartArt selecionado oferece suporte à reversão.

**Como copiar um SmartArt para o mesmo slide ou para outra apresentação preservando a formatação?**

Você pode [clonar a forma SmartArt](/slides/pt/php-java/shape-manipulations/) com [ShapeCollection::addClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/addclone/) ou [clonar o slide inteiro](/slides/pt/php-java/clone-slides/) que contém o SmartArt. Ambas as abordagens preservam tamanho, posição e formatação.

**Como renderizar o SmartArt como imagem raster para visualização ou exportação web?**

[Renderize o slide](/slides/pt/php-java/convert-powerpoint-to-png/) ou a apresentação completa para PNG ou JPEG. O SmartArt é renderizado como parte do slide.

**Como encontrar um objeto SmartArt específico em um slide se houver vários?**

Defina um valor distintivo em [Shape::getAlternativeText](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/getalternativetext/) ou em [Shape::getName](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/getname/) na forma SmartArt, procure esse valor em [BaseSlide::getShapes](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseslide/#getShapes) e, então, verifique se a forma encontrada é um [SmartArt](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartart/).