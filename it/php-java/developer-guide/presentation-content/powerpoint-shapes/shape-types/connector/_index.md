---
title: Gestire i connettori nelle presentazioni usando PHP
linktitle: Connettore
type: docs
weight: 10
url: /it/php-java/connector/
keywords:
- connettore
- tipo di connettore
- punto di connettore
- linea di connettore
- angolo del connettore
- punto di connessione
- punto di regolazione
- collegare forme
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come aggiungere, collegare, ricalcolare, regolare e ispezionare connettori dritti, piegati e curvi di PowerPoint con Aspose.Slides per PHP tramite Java."
---
## **Panoramica**

Un connettore è una linea che può rimanere collegata a due forme quando una delle due forme si sposta. Le sue estremità si attaccano ai punti di connessione, rappresentati da punti verdi in PowerPoint. Alcuni connettori piegati e curvi espongono inoltre punti di regolazione, rappresentati da punti arancioni, che controllano la posizione dei singoli segmenti del connettore.

Aspose.Slides rappresenta i connettori tramite la classe [Connector](https://reference.aspose.com/slides/it/php-java/aspose.slides/connector/). È possibile crearli, collegare le loro estremità alle forme, scegliere i punti di connessione, ricalcolare il percorso e modificare la geometria dei connettori che hanno punti di regolazione.

## **Tipi di Connettore**

La classe [ShapeType](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapetype/) include preset di connettori diritti, piegati e curvi. La tabella seguente mostra le geometrie dei connettori disponibili e il numero di punti di regolazione definiti da ciascun preset.

| Connettore | Image | Numero di punti di regolazione |
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

Il numero e il significato dei punti di regolazione fanno parte del preset del connettore selezionato. Non presumere che due tipologie diverse di connettore espongano la stessa disposizione della collection.

## **Collega Due Forme**

Usa [ShapeCollection::addConnector](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/addconnector/) per aggiungere un connettore e usa [Connector::setStartShapeConnectedTo](https://reference.aspose.com/slides/it/php-java/aspose.slides/connector/setstartshapeconnectedto/) e [Connector::setEndShapeConnectedTo](https://reference.aspose.com/slides/it/php-java/aspose.slides/connector/setendshapeconnectedto/) per collegare le sue estremità. Dopo che entrambe le estremità sono collegate, [Connector::reroute](https://reference.aspose.com/slides/it/php-java/aspose.slides/connector/reroute/) sceglie un percorso breve tra le forme.

L'esempio seguente collega un'ellisse e un rettangolo con un connettore piegato:

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

{{% alert color="warning" title="Avviso" %}}
Invocare `reroute` può modificare i valori di [Connector::setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/it/php-java/aspose.slides/connector/setstartshapeconnectionsiteindex/) e [Connector::setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/it/php-java/aspose.slides/connector/setendshapeconnectionsiteindex/). Assegna punti di connessione specifici dopo il ricalcolo se tali punti devono rimanere fissi.
{{% /alert %}}

## **Scegli un Punto di Connessione**

Ogni forma collegabile riporta il proprio numero di punti tramite [Shape::getConnectionSiteCount](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/getconnectionsitecount/). Convalida un indice di punto basato su zero prima di assegnarlo a un'estremità del connettore; il conteggio dei punti varia a seconda della geometria della forma.

Questo esempio collega il connettore a un punto particolare sull'ellisse quando tale punto esiste:

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

## **Regola un Punto del Connettore**

I connettori con punti di regolazione li espongono tramite [GeometryShape::getAdjustments](https://reference.aspose.com/slides/it/php-java/aspose.slides/geometryshape/#getadjustments). Esamina ogni [AdjustValue](https://reference.aspose.com/slides/it/php-java/aspose.slides/adjustvalue/) e controlla il valore di [AdjustValue::getType](https://reference.aspose.com/slides/it/php-java/aspose.slides/adjustvalue/#gettype) prima di modificarlo con [AdjustValue::setRawValue](https://reference.aspose.com/slides/it/php-java/aspose.slides/adjustvalue/setrawvalue/). Le regole generali per identificare le regolazioni di forme preset sono descritte in [Manipolazione della Forma](/slides/it/php-java/shape-manipulations/).

Il numero, l'ordine, il significato e l'intervallo di valori validi delle regolazioni del connettore dipendono dal preset del connettore. Il tipo di regolazione è di sola lettura, mentre il valore è scrivibile. Il metodo di sola lettura [AdjustValue::getName](https://reference.aspose.com/slides/it/php-java/aspose.slides/adjustvalue/getname/) fornisce un'identificazione aggiuntiva quando un connettore contiene più di una regolazione dello stesso tipo semantico.

### **Percorri Intorno a un Ostacolo**

Nel layout seguente, un connettore `BentConnector5` tra due forme passa attraverso una terza forma:

![connector-obstruction](connector-obstruction.png)

Questo codice crea il connettore ostruito:

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

Spostare la piega verticale modifica il percorso in modo che il connettore aggiri l'ostacolo:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Invece di presumere che l'indice della collection `1` rappresenti sempre la piega verticale, questo esempio cerca `ConnectorBendPositionY` e la modifica solo quando è presente il tipo semantico previsto:

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

Un `BentConnector5` ha due regolazioni `ConnectorBendPositionX` e una regolazione `ConnectorBendPositionY`. Se il tipo di cui hai bisogno compare più di una volta, esamina `getName` e la geometria nota di quel preset prima di sceglierne una. Se una regolazione restituisce `ShapeAdjustmentType::Custom`, trattane il significato e l'intervallo come specifici del preset e non modificarla finché il contratto non è noto.

## **Collega i Valori di Regolazione alla Geometria del Connettore**

Per i connettori piegati, i valori di regolazione possono essere usati per stimare le posizioni dei singoli segmenti. Questi calcoli sono specifici del preset del connettore:

- `BentConnector4` normalmente espone una regolazione `ConnectorBendPositionX` e una `ConnectorBendPositionY`.
- Per queste posizioni di piega, dividere il valore restituito da `getRawValue` per `100000` produce la frazione della larghezza o altezza del frame del connettore usata negli esempi seguenti.
- Un frame del connettore può essere ruotato o capovolto, quindi le coordinate del frame devono essere trasformate prima di confrontarle con le coordinate della diapositiva.

Gli esempi seguenti usano `getType` per identificare prima le regolazioni. Non trattano gli indici della collection come identificatori portabili.

### **Connettore Non Ruotato**

Il layout iniziale contiene due forme di testo collegate da un `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Questo esempio esamina il connettore e ottiene le sue regolazioni di piega orizzontale e verticale:

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

Per cambiare entrambe le pieghe, individua ciascun tipo previsto e modifica i valori solo dopo aver trovato entrambi:

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

Il risultato è un connettore i cui segmenti orizzontali e verticali sono stati spostati:

![connector-adjusted-1](connector-adjusted-1.png)

Una volta conosciuti i tipi semantici, i loro valori possono essere convertiti in coordinate del frame del connettore. Questo esempio disegna un rettangolo sottile sopra il segmento verticale controllato dalle due regolazioni di piega:

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

La forma guida segna il segmento calcolato:

![connector-adjusted-2](connector-adjusted-2.png)

### **Connettore Ruotato o Capovolto**

Quando la stessa geometria del connettore è orientata verticalmente, i valori di [Shape::getFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/getframe/), [ShapeFrame::getFlipH](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapeframe/getfliph/) e [ShapeFrame::getFlipV](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapeframe/getflipv/) influiscono sulla conversione dalle coordinate del frame del connettore a quelle della diapositiva.

Questo esempio crea e regola il connettore orientato verticalmente:

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

Il connettore regolato appare verticalmente tra le forme:

![connector-adjusted-3](connector-adjusted-3.png)

Per un angolo di rotazione arbitrario `alpha`, ruota un punto del frame del connettore `(x, y)` attorno al centro del frame `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Il codice seguente gestisce l'orientamento a 90 gradi usato in questo esempio e disegna una guida rossa sul segmento corrispondente del connettore:

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

La guida rossa segna il segmento calcolato dopo la trasformazione delle coordinate:

![connector-adjusted-4](connector-adjusted-4.png)

Queste formule descrivono i preset usati negli esempi, non un modello di connettore universale. Convalida i tipi di regolazione, l'orientamento del frame e gli intervalli di valore prima di applicare lo stesso calcolo a un preset diverso.

## **Trova l'Angolo di Direzione di un Connettore**

La direzione di un connettore rettilineo può essere calcolata dalla sua larghezza e altezza, applicando le inversioni orizzontali e verticali. L'esempio seguente restituisce l'angolo in senso orario rispetto all'asse orizzontale positivo nelle coordinate della diapositiva:

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

**Come posso sapere se un connettore può essere collegato a una forma?**

Verifica il valore di [Shape::getConnectionSiteCount](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/getconnectionsitecount/). Un conteggio positivo indica che la forma espone punti di connessione. Convalida l'indice del punto selezionato prima di assegnarlo a una delle estremità del connettore.

**Posso identificare una regolazione del connettore tramite il suo indice nella collection?**

Un indice è significativo solo per un preset di connettore noto e una disposizione della collection conosciuta. Controlla [AdjustValue::getType](https://reference.aspose.com/slides/it/php-java/aspose.slides/adjustvalue/#gettype) prima di modificare un valore e usa [AdjustValue::getName](https://reference.aspose.com/slides/it/php-java/aspose.slides/adjustvalue/getname/) come informazione aggiuntiva quando lo stesso tipo semantico compare più volte.

** Cosa succede quando una forma collegata viene eliminata?**

L'estremità corrispondente del connettore si stacca. Il connettore rimane sulla diapositiva e può essere eliminato, posizionato come linea libera o collegato a un'altra forma.

**I collegamenti del connettore vengono mantenuti quando una diapositiva viene copiata?**

I collegamenti sono generalmente mantenuti quando le forme collegate sono copiate con la diapositiva. Se un connettore viene copiato senza una delle sue forme target, l'estremità interessata deve essere ricollegata.