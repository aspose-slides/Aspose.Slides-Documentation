---
title: Gestire i connettori nelle presentazioni in Java
linktitle: Connettore
type: docs
weight: 10
url: /it/java/connector/
keywords:
- connettore
- tipo di connettore
- punto del connettore
- linea del connettore
- angolo del connettore
- punto di connessione
- punto di regolazione
- collegare forme
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Impara come aggiungere, collegare, ricalcolare, regolare e ispezionare connettori lineari, piegati e curvi di PowerPoint con Aspose.Slides per Java."
---
## **Panoramica**

Un connettore è una linea che può rimanere collegata a due forme quando una delle due forme si muove. Le sue estremità si collegano a punti di connessione, rappresentati da punti verdi in PowerPoint. Alcuni connettori piegati e curvi espongono anche punti di regolazione, rappresentati da punti arancioni, che controllano la posizione dei singoli segmenti del connettore.

Aspose.Slides rappresenta i connettori tramite l'interfaccia [IConnector](https://reference.aspose.com/slides/it/java/com.aspose.slides/iconnector/). È possibile crearli, collegare le loro estremità alle forme, scegliere i punti di connessione, ricalcolarli e modificare la geometria dei connettori che hanno punti di regolazione.

## **Tipi di connettore**

La classe [ShapeType](https://reference.aspose.com/slides/it/java/com.aspose.slides/shapetype/) include preset di connettori lineari, piegati e curvi. La tabella seguente mostra le geometrie di connettore disponibili e il numero di punti di regolazione definiti da ciascun preset.

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

Il numero e il significato dei punti di regolazione fanno parte del preset di connettore selezionato. Non presumere che due tipi di connettore diversi espongano la stessa disposizione della raccolta.

## **Collega due forme**

Usa [IShapeCollection.addConnector](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishapecollection/#addConnector-int-float-float-float-float-) per aggiungere un connettore, e usa [IConnector.setStartShapeConnectedTo](https://reference.aspose.com/slides/it/java/com.aspose.slides/iconnector/#setStartShapeConnectedTo-com.aspose.slides.IShape-) e [IConnector.setEndShapeConnectedTo](https://reference.aspose.com/slides/it/java/com.aspose.slides/iconnector/#setEndShapeConnectedTo-com.aspose.slides.IShape-) per collegare le sue estremità. Dopo che entrambe le estremità sono collegate, [IConnector.reroute](https://reference.aspose.com/slides/it/java/com.aspose.slides/iconnector/#reroute--) seleziona un percorso breve tra le forme.

Il seguente esempio collega un'ellisse e un rettangolo con un connettore piegato:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
    IAutoShape rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    connector.reroute();

    presentation.save("connected-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Invocare `reroute` può modificare i valori di [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/it/java/com.aspose.slides/iconnector/#setStartShapeConnectionSiteIndex-long-) e [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/it/java/com.aspose.slides/iconnector/#setEndShapeConnectionSiteIndex-long-). Assegna siti di connessione specifici dopo il ricalcolo se tali siti devono rimanere fissi.
{{% /alert %}}

## **Scegliere un punto di connessione**

Ogni forma collegabile restituisce il suo numero di siti tramite [IShape.getConnectionSiteCount](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#getConnectionSiteCount--). Convalida un indice di sito preferito basato su zero prima di assegnarlo a un'estremità del connettore; il conteggio dei siti varia in base alla geometria della forma.

Questo esempio collega il connettore a un sito particolare sull'ellisse quando quel sito esiste:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
    IAutoShape rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    long preferredSiteIndex = 2;
    if (preferredSiteIndex < ellipse.getConnectionSiteCount()) {
        connector.setStartShapeConnectionSiteIndex(preferredSiteIndex);
    } else {
        System.out.println("The ellipse has only " + ellipse.getConnectionSiteCount() + " connection sites.");
    }

    presentation.save("specific-connection-site.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Regolare un punto del connettore**

I connettori con punti di regolazione li espongono tramite [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/it/java/com.aspose.slides/igeometryshape/#getAdjustments--). Ispeziona ogni [IAdjustValue](https://reference.aspose.com/slides/it/java/com.aspose.slides/iadjustvalue/) e controlla il valore del suo [getType](https://reference.aspose.com/slides/it/java/com.aspose.slides/iadjustvalue/#getType--) prima di modificarlo con [setRawValue](https://reference.aspose.com/slides/it/java/com.aspose.slides/iadjustvalue/#setRawValue-long-). Le regole generali per identificare le regolazioni di forma preset sono descritte in [Shape Manipulation](/slides/it/java/shape-manipulations/).

Il numero, l'ordine, il significato e l'intervallo di valori validi delle regolazioni del connettore dipendono dal preset del connettore. Il tipo di regolazione è di sola lettura, mentre il valore è modificabile. Il metodo di sola lettura [getName](https://reference.aspose.com/slides/it/java/com.aspose.slides/iadjustvalue/#getName--) fornisce un'ulteriore identificazione quando un connettore contiene più di una regolazione dello stesso tipo semantico.

### **Percorso intorno a un ostacolo**

Nel layout seguente, un connettore `BentConnector5` tra due forme attraversa una terza forma:

![connector-obstruction](connector-obstruction.png)

Questo codice crea il connettore ostruito:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    presentation.save("connector-obstruction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Spostare la piega verticale cambia il percorso in modo che il connettore aggiri l'ostacolo:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Invece di presumere che l'indice della raccolta `1` rappresenti sempre la piega verticale, questo esempio ricerca `ConnectorBendPositionY` e la modifica solo quando il tipo semantico previsto è presente:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        System.out.println(adjustment.getName() + ": " + adjustment.getType() + ", raw value = " + adjustment.getRawValue());
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
            break;
        }
    }

    if (verticalBend == null) {
        System.out.println("The connector does not expose a vertical bend adjustment.");
    } else {
        verticalBend.setRawValue(60000);
        presentation.save("connector-obstruction-fixed.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Un `BentConnector5` ha due regolazioni `ConnectorBendPositionX` e una `ConnectorBendPositionY`. Se il tipo necessario compare più volte, ispeziona `getName` e la geometria nota di quel preset prima di selezionarne una. Se una regolazione restituisce `ShapeAdjustmentType.Custom`, considerala specifica del preset e non modificarla finché non ne conosci il contratto.

## **Relazionare i valori di regolazione alla geometria del connettore**

Per i connettori piegati, i valori di regolazione possono essere usati per stimare le posizioni dei singoli segmenti. Questi calcoli sono specifici per il preset del connettore:

- `BentConnector4` normalmente espone una regolazione `ConnectorBendPositionX` e una `ConnectorBendPositionY`.
- Per queste posizioni di piega, dividere il valore restituito da `getRawValue` per `100000f` produce la frazione della larghezza o altezza del frame del connettore usata negli esempi sotto.
- Un frame del connettore può essere ruotato o capovolto, quindi le coordinate del frame devono essere trasformate prima di confrontarle con le coordinate della diapositiva.

Gli esempi seguenti usano `getType` per identificare prima le regolazioni. Non trattano gli indici della raccolta come identificatori portabili.

### **Connettore non ruotato**

Il layout iniziale contiene due forme di testo collegate da un `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Questo esempio ispeziona il connettore e ottiene le regolazioni di piega orizzontale e verticale:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    targetShape.getTextFrame().setText("To");
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        System.out.println(adjustment.getName() + ": " + adjustment.getType() + ", raw value = " + adjustment.getRawValue());
    }
} finally {
    presentation.dispose();
}
```

Per modificare entrambe le pieghe, individua ogni tipo previsto e cambia i valori solo dopo aver trovato entrambi:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    IAdjustValue horizontalBend = null;
    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend == null || verticalBend == null) {
        System.out.println("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);
        presentation.save("connector-adjusted.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Il risultato è un connettore i cui segmenti orizzontali e verticali sono stati spostati:

![connector-adjusted-1](connector-adjusted-1.png)

Una volta noti i tipi semantici, i loro valori possono essere convertiti in coordinate del frame del connettore. Questo esempio disegna un rettangolo sottile sul segmento verticale controllato dalle due regolazioni di piega:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    IAdjustValue horizontalBend = null;
    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend == null || verticalBend == null) {
        System.out.println("The connector does not expose the expected bend adjustments.");
    } else {
        float x = connector.getX() + connector.getWidth() * horizontalBend.getRawValue() / 100000f;
        float y = connector.getY();
        float height = connector.getHeight() * verticalBend.getRawValue() / 100000f;
        slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 1, height);
        presentation.save("connector-segment-guide.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

La forma di guida segna il segmento calcolato:

![connector-adjusted-2](connector-adjusted-2.png)

### **Connettore ruotato o capovolto**

Quando la stessa geometria del connettore è orientata verticalmente, i valori di [IShape.getFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#getFrame--), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/it/java/com.aspose.slides/shapeframe/#getFlipH--), e [ShapeFrame.getFlipV](https://reference.aspose.com/slides/it/java/com.aspose.slides/shapeframe/#getFlipV--) influenzano la conversione dalle coordinate del frame del connettore a quelle della diapositiva.

Questo esempio crea e regola il connettore orientato verticalmente:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
    targetShape.getTextFrame().setText("To 1");
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(102, 205, 170));
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            adjustment.setRawValue(adjustment.getRawValue() + 20000);
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            adjustment.setRawValue(adjustment.getRawValue() + 200000);
        }
    }

    presentation.save("vertical-connector-adjusted.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il connettore regolato appare verticalmente tra le forme:

![connector-adjusted-3](connector-adjusted-3.png)

Per un angolo di rotazione arbitrario `alpha`, ruota un punto del frame del connettore `(x, y)` attorno al centro del frame `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Il codice seguente gestisce l'orientamento a 90 gradi usato in questo esempio e disegna una guida rossa sul segmento corrispondente del connettore:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    IAdjustValue horizontalBend = null;
    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend == null || verticalBend == null) {
        System.out.println("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);

        float x = connector.getX();
        float y = connector.getY();
        if (connector.getFrame().getFlipH() == NullableBool.True) {
            x += connector.getWidth();
        }
        if (connector.getFrame().getFlipV() == NullableBool.True) {
            y += connector.getHeight();
        }

        x += connector.getWidth() * horizontalBend.getRawValue() / 100000f;
        float rotatedX = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
        float rotatedY = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
        float segmentWidth = connector.getHeight() * verticalBend.getRawValue() / 100000f;
        IAutoShape guide = slide.getShapes().addAutoShape(ShapeType.Rectangle, rotatedX, rotatedY, segmentWidth, 1);
        guide.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

        presentation.save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

La guida rossa segna il segmento calcolato dopo la trasformazione delle coordinate:

![connector-adjusted-4](connector-adjusted-4.png)

Queste formule descrivono i preset usati negli esempi, non un modello universale di connettore. Convalida i tipi di regolazione, l'orientamento del frame e gli intervalli di valori prima di applicare lo stesso calcolo a un preset diverso.

## **Trovare l'angolo di direzione di un connettore**

La direzione di un connettore lineare può essere calcolata dalla sua larghezza e altezza, applicando eventuali ribaltamenti orizzontali e verticali. Il seguente esempio restituisce l'angolo in senso orario rispetto all'asse orizzontale positivo nelle coordinate della diapositiva:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IConnector connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 100, 100, 200, 100);

    boolean flipH = connector.getFrame().getFlipH() == NullableBool.True;
    boolean flipV = connector.getFrame().getFlipV() == NullableBool.True;
    float deltaX = connector.getWidth() * (flipH ? -1 : 1);
    float deltaY = connector.getHeight() * (flipV ? -1 : 1);
    double angle = Math.atan2(deltaY, deltaX) * 180.0 / Math.PI;

    if (angle < 0) {
        angle += 360;
    }

    System.out.printf("Connector direction: %.2f degrees%n", angle);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Come posso capire se un connettore può essere collegato a una forma?**  
Controlla il valore di [getConnectionSiteCount](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#getConnectionSiteCount--) della forma. Un conteggio positivo indica che la forma espone punti di connessione. Convalida l'indice del sito selezionato prima di assegnarlo a una delle estremità del connettore.

**Posso identificare una regolazione del connettore tramite il suo indice di raccolta?**  
Un indice è significativo solo per un preset di connettore noto e per la disposizione della raccolta. Controlla [IAdjustValue.getType](https://reference.aspose.com/slides/it/java/com.aspose.slides/iadjustvalue/#getType--) prima di modificare un valore, e usa [IAdjustValue.getName](https://reference.aspose.com/slides/it/java/com.aspose.slides/iadjustvalue/#getName--) come informazione aggiuntiva quando lo stesso tipo semantico compare più volte.

** Cosa succede quando una forma collegata viene eliminata?**  
L'estremità del connettore corrispondente si stacca. Il connettore rimane sulla diapositiva e può essere eliminato, posizionato come linea libera o collegato a un'altra forma.

**I collegamenti del connettore vengono preservati quando una diapositiva viene copiata?**  
I collegamenti vengono generalmente preservati quando le forme collegate vengono copiate insieme alla diapositiva. Se un connettore viene copiato senza una delle sue forme target, l'estremità interessata deve essere ricollegata.