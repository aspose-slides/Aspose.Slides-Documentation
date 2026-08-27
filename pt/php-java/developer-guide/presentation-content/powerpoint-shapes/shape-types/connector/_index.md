---
title: Gerenciar Conectores em Apresentações Usando PHP
linktitle: Conector
type: docs
weight: 10
url: /pt/php-java/connector/
keywords:
- conector
- tipo de conector
- ponto de conector
- linha de conector
- ângulo do conector
- ponto de conexão
- ponto de ajuste
- conectar formas
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Aprenda a adicionar, anexar, redirecionar, ajustar e inspecionar conectores retos, dobrados e curvos do PowerPoint com Aspose.Slides para PHP via Java."
---
## **Visão geral**

Um conector é uma linha que pode permanecer conectada a duas formas quando qualquer uma delas se movimenta. Suas extremidades se ligam a pontos de conexão, representados por pontos verdes no PowerPoint. Alguns conectores dobrados e curvos também expõem pontos de ajuste, representados por pontos laranja, que controlam a posição de segmentos individuais do conector.

Aspose.Slides representa conectores através da classe [Connector](https://reference.aspose.com/slides/pt/php-java/aspose.slides/connector/). Você pode criá‑los, conectar suas extremidades a formas, escolher pontos de conexão, redirecioná‑los e modificar a geometria dos conectores que possuem pontos de ajuste.

## **Tipos de Conector**

A classe [ShapeType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapetype/) inclui predefinições de conectores retos, dobrados e curvos. A tabela a seguir mostra as geometrias de conector disponíveis e o número de pontos de ajuste definidos por cada predefinição.

| Conector | Imagem | Número de pontos de ajuste |
|---|---|---|
| `ShapeType::Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType::BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType::BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType::BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType::BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType::CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType::CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType::CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType::CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

O número e o significado dos pontos de ajuste fazem parte da predefinição de conector selecionada. Não presuma que dois tipos diferentes de conector exponham a mesma disposição de coleção.

## **Conectar duas formas**

Use [ShapeCollection::addConnector](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/addconnector/) para adicionar um conector e use [Connector::setStartShapeConnectedTo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/connector/setstartshapeconnectedto/) e [Connector::setEndShapeConnectedTo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/connector/setendshapeconnectedto/) para conectar suas extremidades. Após ambas as extremidades estarem conectadas, [Connector::reroute](https://reference.aspose.com/slides/pt/php-java/aspose.slides/connector/reroute/) seleciona a rota mais curta entre as formas.

O exemplo a seguir conecta uma elipse e um retângulo com um conector dobrado:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $ellipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 40, 80, 120, 80);
    $rectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 320, 240, 140, 80);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    $connector->reroute();

    $presentation->save("connected-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Chamar `reroute` pode alterar os valores de [Connector::setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/pt/php-java/aspose.slides/connector/setstartshapeconnectionsiteindex/) e [Connector::setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/pt/php-java/aspose.slides/connector/setendshapeconnectionsiteindex/). Atribua pontos de conexão específicos após o redirecionamento se esses pontos precisarem permanecer fixos.
{{% /alert %}}

## **Escolher um ponto de conexão**

Cada forma conectável informa seu número de pontos por meio de [Shape::getConnectionSiteCount](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/getconnectionsitecount/). Valide um índice de ponto (baseado em zero) antes de atribuí‑lo a uma extremidade do conector; a contagem de pontos varia conforme a geometria da forma.

Este exemplo conecta o conector a um ponto específico da elipse quando esse ponto existe:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $ellipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 40, 80, 120, 80);
    $rectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 320, 240, 140, 80);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);

    $preferredSiteIndex = 2;
    $connectionSiteCount = java_values($ellipse->getConnectionSiteCount());
    if ($preferredSiteIndex < $connectionSiteCount) {
        $connector->setStartShapeConnectionSiteIndex($preferredSiteIndex);
    } else {
        echo "The ellipse has only " . $connectionSiteCount . " connection sites." . PHP_EOL;
    }

    $presentation->save("specific-connection-site.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ajustar um ponto de conector**

Conectores com pontos de ajuste os expõem por meio de [GeometryShape::getAdjustments](https://reference.aspose.com/slides/pt/php-java/aspose.slides/geometryshape/#getadjustments). Inspecione cada [AdjustValue](https://reference.aspose.com/slides/pt/php-java/aspose.slides/adjustvalue/) e verifique seu valor de [AdjustValue::getType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/adjustvalue/#gettype) antes de alterá‑lo com [AdjustValue::setRawValue](https://reference.aspose.com/slides/pt/php-java/aspose.slides/adjustvalue/setrawvalue/). As regras gerais para identificar ajustes de forma predefinidos são descritas em [Manipulação de Forma](/slides/pt/php-java/shape-manipulations/).

O número, a ordem, o significado e a faixa de valores válidos dos ajustes de conector dependem da predefinição do conector. O tipo de ajuste é somente leitura, enquanto o valor do ajuste pode ser escrito. O método somente‑leitura [AdjustValue::getName](https://reference.aspose.com/slides/pt/php-java/aspose.slides/adjustvalue/getname/) fornece identificação adicional quando um conector contém mais de um ajuste do mesmo tipo semântico.

### **Desviar ao redor de um obstáculo**

No layout a seguir, um conector `BentConnector5` entre duas formas passa por uma terceira forma:

![connector-obstruction](connector-obstruction.png)

Este código cria o conector obstruído:

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector5, 20, 20, 400, 300);

    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(0, 0, 0));
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setStartShapeConnectionSiteIndex(2);

    $presentation->save("connector-obstruction.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Mover a dobradura vertical altera a rota para que o conector contorne o obstáculo:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Em vez de presumir que o índice da coleção `1` representa sempre a dobradura vertical, este exemplo procura por `ConnectorBendPositionY` e o altera somente quando o tipo semântico esperado está presente:

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector5, 20, 20, 400, 300);

    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(0, 0, 0));
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setStartShapeConnectionSiteIndex(2);

    $verticalBend = null;
    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentName = java_values($adjustment->getName());
        $adjustmentType = java_values($adjustment->getType());
        $rawValue = java_values($adjustment->getRawValue());
        echo $adjustmentName . ": " . $adjustmentType . ", raw value = " . $rawValue . PHP_EOL;
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $verticalBend = $adjustment;
            break;
        }
    }

    if ($verticalBend === null) {
        echo "The connector does not expose a vertical bend adjustment." . PHP_EOL;
    } else {
        $verticalBend->setRawValue(60000);
        $presentation->save("connector-obstruction-fixed.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Um `BentConnector5` possui dois ajustes `ConnectorBendPositionX` e um ajuste `ConnectorBendPositionY`. Se o tipo que você precisa ocorrer mais de uma vez, inspecione `getName` e a geometria conhecida daquela predefinição antes de selecionar um. Se um ajuste relatar `ShapeAdjustmentType::Custom`, trate seu significado e faixa como específicos da predefinição e não o altere até que esse contrato seja conhecido.

## **Relacionar valores de ajuste à geometria do conector**

Para conectores dobrados, os valores de ajuste podem ser usados para estimar as posições de segmentos individuais. Esses cálculos são específicos da predefinição do conector:

- `BentConnector4` normalmente expõe um ajuste `ConnectorBendPositionX` e um ajuste `ConnectorBendPositionY`.
- Para essas posições de dobradura, dividir o valor retornado por `getRawValue` por `100000` produz a fração da largura ou altura da moldura do conector usada nos exemplos abaixo.
- Uma moldura de conector pode ser rotacionada ou invertida, portanto as coordenadas da moldura devem ser transformadas antes de serem comparadas com as coordenadas do slide.

Os exemplos a seguir utilizam `getType` para identificar primeiro os ajustes. Eles não tratam índices de coleção como identificadores portáteis.

### **Conector não rotacionado**

O layout inicial contém duas formas de texto conectadas por um `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Este exemplo inspeciona o conector e obtém seus ajustes de dobradura horizontal e vertical:

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $sourceShape->getTextFrame()->setText("From");
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $targetShape->getTextFrame()->setText("To");
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);

    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(255, 0, 0));
    $connector->getLineFormat()->setWidth(3);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(2);

    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        echo $adjustment->getName() . ": " . $adjustment->getType() . ", raw value = " . $adjustment->getRawValue() . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Para alterar ambas as dobraduras, localize cada tipo esperado e modifique os valores somente depois que ambos forem encontrados:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(2);

    $horizontalBend = null;
    $verticalBend = null;
    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentType = java_values($adjustment->getType());
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionX) {
            $horizontalBend = $adjustment;
        } elseif ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $verticalBend = $adjustment;
        }
    }

    if ($horizontalBend === null || $verticalBend === null) {
        echo "The connector does not expose the expected bend adjustments." . PHP_EOL;
    } else {
        $horizontalBendValue = java_values($horizontalBend->getRawValue());
        $verticalBendValue = java_values($verticalBend->getRawValue());
        $horizontalBendValue += 20000;
        $verticalBendValue += 200000;
        $horizontalBend->setRawValue($horizontalBendValue);
        $verticalBend->setRawValue($verticalBendValue);
        $presentation->save("connector-adjusted.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

O resultado é um conector cujos segmentos horizontal e vertical foram movidos:

![connector-adjusted-1](connector-adjusted-1.png)

Uma vez que os tipos semânticos sejam conhecidos, seus valores podem ser convertidos em coordenadas da moldura do conector. Este exemplo desenha um retângulo fino sobre o segmento vertical controlado pelos dois ajustes de dobradura:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(2);

    $horizontalBend = null;
    $verticalBend = null;
    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentType = java_values($adjustment->getType());
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionX) {
            $horizontalBend = $adjustment;
        } elseif ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $verticalBend = $adjustment;
        }
    }

    if ($horizontalBend === null || $verticalBend === null) {
        echo "The connector does not expose the expected bend adjustments." . PHP_EOL;
    } else {
        $connectorX = java_values($connector->getX());
        $connectorY = java_values($connector->getY());
        $connectorWidth = java_values($connector->getWidth());
        $connectorHeight = java_values($connector->getHeight());
        $horizontalBendValue = java_values($horizontalBend->getRawValue());
        $verticalBendValue = java_values($verticalBend->getRawValue());
        $x = $connectorX + $connectorWidth * $horizontalBendValue / 100000;
        $y = $connectorY;
        $height = $connectorHeight * $verticalBendValue / 100000;
        $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 1, $height);
        $presentation->save("connector-segment-guide.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

A forma guia marca o segmento calculado:

![connector-adjusted-2](connector-adjusted-2.png)

### **Conector rotacionado ou invertido**

Quando a mesma geometria de conector está orientada verticalmente, seus valores de [Shape::getFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/getframe/), [ShapeFrame::getFlipH](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapeframe/getfliph/), e [ShapeFrame::getFlipV](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapeframe/getflipv/) afetam a conversão das coordenadas da moldura do conector para coordenadas do slide.

Este exemplo cria e ajusta o conector orientado verticalmente:

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $sourceShape->getTextFrame()->setText("From");
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
    $targetShape->getTextFrame()->setText("To 1");
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);

    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(102, 205, 170));
    $connector->getLineFormat()->setWidth(3);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(2);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(3);

    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentType = java_values($adjustment->getType());
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionX) {
            $rawValue = java_values($adjustment->getRawValue());
            $adjustment->setRawValue($rawValue + 20000);
        } elseif ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $rawValue = java_values($adjustment->getRawValue());
            $adjustment->setRawValue($rawValue + 200000);
        }
    }

    $presentation->save("vertical-connector-adjusted.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O conector ajustado aparece verticalmente entre as formas:

![connector-adjusted-3](connector-adjusted-3.png)

Para um ângulo de rotação arbitrário `alpha`, rotacione um ponto da moldura do conector `(x, y)` ao redor do centro da moldura `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

O código a seguir trata da orientação de 90 graus usada neste exemplo e desenha um guia vermelho sobre o segmento correspondente do conector:

```php
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(2);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(3);

    $horizontalBend = null;
    $verticalBend = null;
    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentType = java_values($adjustment->getType());
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionX) {
            $horizontalBend = $adjustment;
        } elseif ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $verticalBend = $adjustment;
        }
    }

    if ($horizontalBend === null || $verticalBend === null) {
        echo "The connector does not expose the expected bend adjustments." . PHP_EOL;
    } else {
        $horizontalBendValue = java_values($horizontalBend->getRawValue());
        $verticalBendValue = java_values($verticalBend->getRawValue());
        $horizontalBendValue += 20000;
        $verticalBendValue += 200000;
        $horizontalBend->setRawValue($horizontalBendValue);
        $verticalBend->setRawValue($verticalBendValue);

        $frame = $connector->getFrame();
        $connectorX = java_values($connector->getX());
        $connectorY = java_values($connector->getY());
        $connectorWidth = java_values($connector->getWidth());
        $connectorHeight = java_values($connector->getHeight());
        $flipH = java_values($frame->getFlipH()) == NullableBool::True;
        $flipV = java_values($frame->getFlipV()) == NullableBool::True;
        $centerX = java_values($frame->getCenterX());
        $centerY = java_values($frame->getCenterY());

        $x = $connectorX;
        $y = $connectorY;
        if ($flipH) {
            $x += $connectorWidth;
        }
        if ($flipV) {
            $y += $connectorHeight;
        }

        $x += $connectorWidth * $horizontalBendValue / 100000;
        $rotatedX = $centerX - $y + $centerY;
        $rotatedY = $x - $centerX + $centerY;
        $segmentWidth = $connectorHeight * $verticalBendValue / 100000;
        $guide = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $rotatedX, $rotatedY, $segmentWidth, 1);
        $guide->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $guide->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(255, 0, 0));

        $presentation->save("rotated-connector-segment-guide.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

O guia vermelho marca o segmento calculado após a transformação de coordenadas:

![connector-adjusted-4](connector-adjusted-4.png)

Essas fórmulas descrevem as predefinições usadas nos exemplos, não um modelo de conector universal. Valide os tipos de ajuste, a orientação da moldura e as faixas de valor antes de aplicar o mesmo cálculo a uma predefinição diferente.

## **Encontrar o ângulo de direção de um conector**

A direção de um conector reto pode ser calculada a partir de sua largura e altura, considerando as inversões horizontais e verticais. O exemplo a seguir relata o ângulo horário a partir do eixo horizontal positivo nas coordenadas do slide:

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $connector = $slide->getShapes()->addConnector(ShapeType::StraightConnector1, 100, 100, 200, 100);

    $frame = $connector->getFrame();
    $flipH = java_values($frame->getFlipH()) == NullableBool::True;
    $flipV = java_values($frame->getFlipV()) == NullableBool::True;
    $width = java_values($connector->getWidth());
    $height = java_values($connector->getHeight());
    $deltaX = $width * ($flipH ? -1 : 1);
    $deltaY = $height * ($flipV ? -1 : 1);
    $angle = atan2($deltaY, $deltaX) * 180.0 / pi();

    if ($angle < 0) {
        $angle += 360;
    }

    printf("Connector direction: %.2f degrees%s", $angle, PHP_EOL);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Como posso saber se um conector pode ser anexado a uma forma?**

Verifique o valor de [Shape::getConnectionSiteCount](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/getconnectionsitecount/). Uma contagem positiva indica que a forma expõe pontos de conexão. Valide o índice do ponto selecionado antes de atribuí‑lo a qualquer extremidade do conector.

**Posso identificar um ajuste de conector pelo seu índice na coleção?**

Um índice é significativo somente para uma predefinição de conector conhecida e sua disposição de coleção. Verifique [AdjustValue::getType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/adjustvalue/#gettype) antes de modificar um valor e use [AdjustValue::getName](https://reference.aspose.com/slides/pt/php-java/aspose.slides/adjustvalue/getname/) como informação adicional quando o mesmo tipo semântico ocorre mais de uma vez.

**O que acontece quando uma forma conectada é excluída?**

A extremidade correspondente do conector se desapega. O conector permanece no slide e pode ser excluído, posicionado como uma linha livre ou conectado a outra forma.

**As ligações de conectores são preservadas quando um slide é copiado?**

As ligações geralmente são preservadas quando as formas conectadas são copiadas juntamente com o slide. Se um conector for copiado sem uma de suas formas‑alvo, a extremidade afetada deverá ser conectada novamente.