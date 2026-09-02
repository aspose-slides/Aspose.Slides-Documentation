---
title: Gestire i connettori nelle presentazioni con JavaScript
linktitle: Connettore
type: docs
weight: 10
url: /it/nodejs-java/connector/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come aggiungere, collegare, ricalcolare, regolare e ispezionare i connettori PowerPoint lineari, piegati e curvi con Aspose.Slides per Node.js tramite Java."
---
## **Panoramica**

Un connettore è una linea che può rimanere collegata a due forme quando una delle due forme si sposta. Le sue estremità si collegano a punti di connessione, rappresentati da puntini verdi in PowerPoint. Alcuni connettori piegati e curvi espongono anche punti di regolazione, rappresentati da puntini arancioni, che controllano la posizione dei singoli segmenti del connettore.

Aspose.Slides rappresenta i connettori tramite la classe [Connector](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/connector/). Puoi crearli, collegare le loro estremità alle forme, scegliere i punti di connessione, ricalcolarli e modificare la geometria dei connettori che hanno punti di regolazione.

## **Tipi di connettore**

La classe [ShapeType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapetype/) include preset di connettori lineari, piegati e curvi. La tabella seguente mostra le geometrie di connettore disponibili e il numero di punti di regolazione definiti per ciascun preset.

| Connettore | Immagine | Numero di punti di regolazione |
|---|---|---|
| `ShapeType.Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

Il numero e il significato dei punti di regolazione fanno parte del preset di connettore selezionato. Non presumere che due diversi tipi di connettore espongano la stessa struttura della collezione.

## **Collega due forme**

Usa [ShapeCollection.addConnector](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapecollection/addconnector/) per aggiungere un connettore e utilizza [Connector.setStartShapeConnectedTo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/connector/setstartshapeconnectedto/) e [Connector.setEndShapeConnectedTo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/connector/setendshapeconnectedto/) per collegare le sue estremità. Dopo che entrambe le estremità sono collegate, [Connector.reroute](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/connector/reroute/) seleziona un percorso breve tra le forme.

Il seguente esempio collega un’ellisse e un rettangolo con un connettore piegato:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const ellipse = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 40, 80, 120, 80);
    const rectangle = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 320, 240, 140, 80);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    connector.reroute();

    presentation.save("connected-shapes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Chiamare `reroute` può modificare i valori di [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/connector/setstartshapeconnectionsiteindex/) e [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/connector/setendshapeconnectionsiteindex/). Assegna punti di connessione specifici dopo il ricalcolo se tali punti devono rimanere fissi.
{{% /alert %}}

## **Scegli un punto di connessione**

Ogni forma collegabile restituisce il numero dei suoi punti attraverso [Shape.getConnectionSiteCount](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/getconnectionsitecount/). Convalida un indice di punto (basato su zero) preferito prima di assegnarlo a un’estremità del connettore; il conteggio dei punti varia in base alla geometria della forma.

Questo esempio collega il connettore a un punto particolare dell’ellisse quando quel punto esiste:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const ellipse = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 40, 80, 120, 80);
    const rectangle = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 320, 240, 140, 80);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector3, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    const preferredSiteIndex = 2;
    if (preferredSiteIndex < ellipse.getConnectionSiteCount()) {
        connector.setStartShapeConnectionSiteIndex(preferredSiteIndex);
    } else {
        console.log(`The ellipse has only ${ellipse.getConnectionSiteCount()} connection sites.`);
    }

    presentation.save("specific-connection-site.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Regola un punto del connettore**

I connettori con punti di regolazione li espongono tramite [GeometryShape.getAdjustments](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/geometryshape/). Ispeziona ogni [AdjustValue](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/adjustvalue/) e controlla il suo valore [getType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/adjustvalue/) prima di cambiarlo con [setRawValue](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/adjustvalue/setrawvalue/). Le regole generali per identificare le regolazioni di una forma preset sono descritte in [Shape Manipulation](/slides/it/nodejs-java/shape-manipulations/).

Il numero, l’ordine, il significato e l’intervallo di valori valido delle regolazioni di un connettore dipendono dal preset del connettore. Il tipo di regolazione è di sola lettura, mentre il valore è scrivibile. Il metodo di sola lettura [getName](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/adjustvalue/getname/) fornisce un’identificazione aggiuntiva quando un connettore contiene più di una regolazione dello stesso tipo semantico.

### **Percorri intorno a un ostacolo**

Nel layout seguente, un connettore `BentConnector5` tra due forme passa attraverso una terza forma:

![connector-obstruction](connector-obstruction.png)

Questo codice crea il connettore ostacolato:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);

    const black = java.getStaticFieldValue("java.awt.Color", "BLACK");
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(black);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    presentation.save("connector-obstruction.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Spostare la piega verticale cambia il percorso in modo che il connettore aggiri l’ostacolo:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Invece di presumere che l’indice di collezione `1` rappresenti sempre la piega verticale, questo esempio cerca `ConnectorBendPositionY` e lo modifica solo quando è presente il tipo semantico atteso:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);

    const black = java.getStaticFieldValue("java.awt.Color", "BLACK");
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(black);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        console.log(`${adjustment.getName()}: ${adjustment.getType()}, raw value = ${adjustment.getRawValue()}`);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
            break;
        }
    }

    if (verticalBend === null) {
        console.log("The connector does not expose a vertical bend adjustment.");
    } else {
        verticalBend.setRawValue(60000);
        presentation.save("connector-obstruction-fixed.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Un `BentConnector5` ha due regolazioni `ConnectorBendPositionX` e una regolazione `ConnectorBendPositionY`. Se il tipo necessario compare più di una volta, ispeziona `getName` e la geometria nota di quel preset prima di sceglierne uno. Se una regolazione restituisce `ShapeAdjustmentType.Custom`, considerala specifica del preset e non modificarla finché il relativo contratto non è noto.

## **Relaziona i valori di regolazione alla geometria del connettore**

Per i connettori piegati, i valori di regolazione possono essere usati per stimare le posizioni dei singoli segmenti. questi calcoli sono specifici per il preset del connettore:

- `BentConnector4` normalmente espone un aggiustamento `ConnectorBendPositionX` e un aggiustamento `ConnectorBendPositionY`.
- Per queste posizioni di piega, dividere il valore restituito da `getRawValue` per `100000` produce la frazione della larghezza o altezza del frame del connettore usata negli esempi seguenti.
- Un frame del connettore può essere ruotato o capovolto, quindi le coordinate del frame devono essere trasformate prima di confrontarle con le coordinate della diapositiva.

Gli esempi seguenti usano `getType` per identificare prima le regolazioni. Non trattano gli indici di collezione come identificatori portabili.

### **Connettore non ruotato**

Il layout iniziale contiene due forme di testo collegate da un `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Questo esempio ispeziona il connettore e ottiene le sue regolazioni di piega orizzontale e verticale:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    targetShape.getTextFrame().setText("To");
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);

    const red = java.getStaticFieldValue("java.awt.Color", "RED");
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        console.log(`${adjustment.getName()}: ${adjustment.getType()}, raw value = ${adjustment.getRawValue()}`);
    }
} finally {
    presentation.dispose();
}
```

Per modificare entrambe le pieghe, individua ogni tipo previsto e modifica i valori solo dopo aver trovato entrambi:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    let horizontalBend = null;
    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend === null || verticalBend === null) {
        console.log("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);
        presentation.save("connector-adjusted.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Il risultato è un connettore i cui segmenti orizzontali e verticali si sono spostati:

![connector-adjusted-1](connector-adjusted-1.png)

Una volta noti i tipi semantici, i loro valori possono essere convertiti in coordinate del frame del connettore. Questo esempio disegna un rettangolo sottile sul segmento verticale controllato dalle due regolazioni di piega:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    let horizontalBend = null;
    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend === null || verticalBend === null) {
        console.log("The connector does not expose the expected bend adjustments.");
    } else {
        const x = connector.getX() + connector.getWidth() * horizontalBend.getRawValue() / 100000;
        const y = connector.getY();
        const height = connector.getHeight() * verticalBend.getRawValue() / 100000;
        const guideX = java.newFloat(x);
        const guideY = java.newFloat(y);
        const guideWidth = java.newFloat(1);
        const guideHeight = java.newFloat(height);
        slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, guideX, guideY, guideWidth, guideHeight);
        presentation.save("connector-segment-guide.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

![connector-adjusted-2](connector-adjusted-2.png)

### **Connettore ruotato o capovolto**

Quando la stessa geometria del connettore è orientata verticalmente, i valori di [Shape.getFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/getframe/), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapeframe/getfliph/) e [ShapeFrame.getFlipV](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapeframe/getflipv/) influenzano la conversione dalle coordinate del frame del connettore a quelle della diapositiva.

Questo esempio crea e regola il connettore orientato verticalmente:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
    targetShape.getTextFrame().setText("To 1");
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);

    const connectorColor = java.newInstanceSync("java.awt.Color", 102, 205, 170);
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(connectorColor);
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            adjustment.setRawValue(adjustment.getRawValue() + 20000);
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            adjustment.setRawValue(adjustment.getRawValue() + 200000);
        }
    }

    presentation.save("vertical-connector-adjusted.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il connettore regolato appare verticalmente tra le forme:

![connector-adjusted-3](connector-adjusted-3.png)

Per un angolo di rotazione arbitrario `alpha`, ruota un punto del frame del connettore `(x, y)` attorno al centro del frame `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Il codice seguente gestisce l’orientamento a 90 gradi usato in questo esempio e disegna una guida rossa sul segmento corrispondente del connettore:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    let horizontalBend = null;
    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend === null || verticalBend === null) {
        console.log("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);

        let x = connector.getX();
        let y = connector.getY();
        if (connector.getFrame().getFlipH() === aspose.slides.NullableBool.True) {
            x += connector.getWidth();
        }
        if (connector.getFrame().getFlipV() === aspose.slides.NullableBool.True) {
            y += connector.getHeight();
        }

        x += connector.getWidth() * horizontalBend.getRawValue() / 100000;
        const rotatedX = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
        const rotatedY = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
        const segmentWidth = connector.getHeight() * verticalBend.getRawValue() / 100000;
        const guideX = java.newFloat(rotatedX);
        const guideY = java.newFloat(rotatedY);
        const guideWidth = java.newFloat(segmentWidth);
        const guideHeight = java.newFloat(1);
        const guide = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, guideX, guideY, guideWidth, guideHeight);
        const red = java.getStaticFieldValue("java.awt.Color", "RED");
        const solidFillType = java.newByte(aspose.slides.FillType.Solid);
        guide.getLineFormat().getFillFormat().setFillType(solidFillType);
        guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);

        presentation.save("rotated-connector-segment-guide.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

La guida rossa segna il segmento calcolato dopo la trasformazione delle coordinate:

![connector-adjusted-4](connector-adjusted-4.png)

Queste formule descrivono i preset usati negli esempi, non un modello di connettore universale. Convalida i tipi di regolazione, l’orientamento del frame e gli intervalli di valori prima di applicare lo stesso calcolo a un preset diverso.

## **Trova l'angolo di direzione di un connettore**

La direzione di un connettore lineare può essere calcolata dalla sua larghezza e altezza, tenendo conto delle inversioni orizzontali e verticali. Il seguente esempio restituisce l’angolo in senso orario rispetto all’asse orizzontale positivo nelle coordinate della diapositiva:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.StraightConnector1, 100, 100, 200, 100);

    const flipH = connector.getFrame().getFlipH() === aspose.slides.NullableBool.True;
    const flipV = connector.getFrame().getFlipV() === aspose.slides.NullableBool.True;
    const deltaX = connector.getWidth() * (flipH ? -1 : 1);
    const deltaY = connector.getHeight() * (flipV ? -1 : 1);
    let angle = Math.atan2(deltaY, deltaX) * 180.0 / Math.PI;

    if (angle < 0) {
        angle += 360;
    }

    console.log(`Connector direction: ${angle.toFixed(2)} degrees`);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Come posso capire se un connettore può collegarsi a una forma?**

Verifica il valore di [getConnectionSiteCount](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/getconnectionsitecount/) della forma. Un conteggio positivo indica che la forma espone punti di connessione. Convalida l’indice del punto selezionato prima di assegnarlo a un’estremità del connettore.

**Posso identificare una regolazione del connettore tramite il suo indice di collezione?**

Un indice è significativo solo per un preset di connettore e una disposizione della collezione conosciuti. Controlla [AdjustValue.getType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/adjustvalue/) prima di modificare un valore e usa [AdjustValue.getName](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/adjustvalue/getname/) come informazione aggiuntiva quando lo stesso tipo semantico appare più volte.

**Cosa succede quando una forma collegata viene eliminata?**

L’estremità corrispondente del connettore diventa staccata. Il connettore rimane sulla diapositiva e può essere eliminato, posizionato come linea libera o collegato a un’altra forma.

**I collegamenti del connettore vengono mantenuti quando una diapositiva viene copiata?**

In genere i collegamenti sono conservati quando le forme collegate vengono copiate con la diapositiva. Se un connettore viene copiato senza una delle sue forme target, l’estremità interessata deve essere ricollegata.