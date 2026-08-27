---
title: Gestionar conectores en presentaciones usando JavaScript
linktitle: Conector
type: docs
weight: 10
url: /es/nodejs-java/connector/
keywords:
- conector
- tipo de conector
- punto de conector
- línea de conector
- ángulo del conector
- punto de conexión
- punto de ajuste
- conectar formas
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a añadir, unir, volver a enrutar, ajustar e inspeccionar conectores rectos, doblados y curvos de PowerPoint con Aspose.Slides para Node.js a través de Java."
---
## **Visión general**

Un conector es una línea que puede permanecer unida a dos formas cuando cualquiera de las formas se mueve. Sus extremos se conectan a puntos de conexión, representados por puntos verdes en PowerPoint. Algunos conectores doblados y curvos también exponen puntos de ajuste, representados por puntos naranjas, que controlan la posición de segmentos individuales del conector.

Aspose.Slides representa los conectores a través de la clase [Connector](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/connector/). Puede crearlos, unir sus extremos a formas, elegir puntos de conexión, volver a enrutar‑los y modificar la geometría de los conectores que tienen puntos de ajuste.

## **Tipos de conectores**

La clase [ShapeType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shapetype/) incluye preajustes de conectores rectos, doblados y curvos. La tabla siguiente muestra las geometrías de conectores disponibles y el número de puntos de ajuste definidos por cada preajuste.

| Conector | Imagen | Número de puntos de ajuste |
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

El número y el significado de los puntos de ajuste forman parte del preajuste de conector seleccionado. No asuma que dos tipos de conectores diferentes exponen la misma disposición de colección.

## **Conectar dos formas**

Utilice [ShapeCollection.addConnector](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shapecollection/addconnector/) para añadir un conector, y use [Connector.setStartShapeConnectedTo](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/connector/setstartshapeconnectedto/) y [Connector.setEndShapeConnectedTo](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/connector/setendshapeconnectedto/) para unir sus extremos. Después de que ambos extremos estén unidos, [Connector.reroute](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/connector/reroute/) selecciona una ruta corta entre las formas.

El siguiente ejemplo conecta una elipse y un rectángulo con un conector doblado:

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
Llamar a `reroute` puede cambiar los valores de [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/connector/setstartshapeconnectionsiteindex/) y [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/connector/setendshapeconnectionsiteindex/). Asigne puntos de conexión específicos después de volver a enrutar si esos puntos deben permanecer fijos.
{{% /alert %}}

## **Elegir un punto de conexión**

Cada forma conectable informa su número de puntos a través de [Shape.getConnectionSiteCount](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/getconnectionsitecount/). Valide un índice de punto basado en cero antes de asignarlo a un extremo del conector; el recuento de puntos varía según la geometría de la forma.

Este ejemplo une el conector a un punto concreto de la elipse cuando dicho punto existe:

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

## **Ajustar un punto del conector**

Los conectores con puntos de ajuste los exponen a través de [GeometryShape.getAdjustments](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/geometryshape/). Inspeccione cada [AdjustValue](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/adjustvalue/) y compruebe su valor de [getType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/adjustvalue/) antes de cambiarlo con [setRawValue](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/adjustvalue/setrawvalue/). Las reglas generales para identificar ajustes de forma predefinidos se describen en [Shape Manipulation](/slides/es/nodejs-java/shape-manipulations/).

El número, orden, significado y rango de valores válidos de los ajustes del conector dependen del preajuste del conector. El tipo de ajuste es de solo lectura, mientras que el valor del ajuste es modificable. El método de solo lectura [getName](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/adjustvalue/getname/) aporta información adicional cuando un conector contiene más de un ajuste del mismo tipo semántico.

### **Desviar alrededor de un obstáculo**

En el siguiente diseño, un conector `BentConnector5` entre dos formas pasa por una tercera forma:

![connector-obstruction](connector-obstruction.png)

Este código crea el conector obstruido:

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

Mover el doblez vertical cambia la ruta de modo que el conector evita el obstáculo:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

En lugar de asumir que el índice de colección `1` siempre representa el doblez vertical, este ejemplo busca `ConnectorBendPositionY` y lo modifica solo cuando el tipo semántico esperado está presente:

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

Un `BentConnector5` tiene dos ajustes `ConnectorBendPositionX` y un ajuste `ConnectorBendPositionY`. Si el tipo que necesita aparece más de una vez, inspeccione `getName` y la geometría conocida de ese preajuste antes de seleccionar uno. Si un ajuste devuelve `ShapeAdjustmentType.Custom`, trate su significado y rango como específicos del preajuste y no lo modifique hasta que se conozca ese contrato.

## **Relacionar valores de ajuste con la geometría del conector**

Para los conectores doblados, los valores de ajuste pueden usarse para estimar las posiciones de los segmentos individuales. Estos cálculos son específicos del preajuste del conector:

- `BentConnector4` normalmente expone un ajuste `ConnectorBendPositionX` y uno `ConnectorBendPositionY`.
- Para estas posiciones de doblez, dividir el valor devuelto por `getRawValue` entre `100000` produce la fracción del ancho o alto del marco del conector utilizada en los ejemplos siguientes.
- Un marco de conector puede rotarse o invertirse, por lo que las coordenadas del marco deben transformarse antes de compararse con las coordenadas de la diapositiva.

Los siguientes ejemplos usan `getType` para identificar primero los ajustes. No tratan los índices de colección como identificadores portátiles.

### **Conector sin rotar**

El diseño inicial contiene dos formas de texto conectadas por un `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Este ejemplo inspecciona el conector y obtiene sus ajustes de doblez horizontal y vertical:

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

Para cambiar ambos dobleces, localice cada tipo esperado y modifique los valores solo después de haber encontrado ambos:

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

El resultado es un conector cuyos segmentos horizontal y vertical se han desplazado:

![connector-adjusted-1](connector-adjusted-1.png)

Una vez conocidos los tipos semánticos, sus valores pueden convertirse en coordenadas del marco del conector. Este ejemplo dibuja un rectángulo delgado sobre el segmento vertical controlado por los dos ajustes de doblez:

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

La forma guía marca el segmento calculado:

![connector-adjusted-2](connector-adjusted-2.png)

### **Conector rotado o invertido**

Cuando la misma geometría de conector se orienta verticalmente, sus valores de [Shape.getFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/getframe/), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shapeframe/getfliph/) y [ShapeFrame.getFlipV](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shapeframe/getflipv/) afectan la conversión de coordenadas del marco del conector a coordenadas de la diapositiva.

Este ejemplo crea y ajusta el conector orientado verticalmente:

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

El conector ajustado aparece verticalmente entre las formas:

![connector-adjusted-3](connector-adjusted-3.png)

Para un ángulo de rotación arbitrario `alpha`, rote un punto del marco del conector `(x, y)` alrededor del centro del marco `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

El código siguiente maneja la orientación de 90 grados usada en este ejemplo y dibuja una guía roja sobre el segmento correspondiente del conector:

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

La guía roja marca el segmento calculado después de la transformación de coordenadas:

![connector-adjusted-4](connector-adjusted-4.png)

Estas fórmulas describen los preajustes usados en los ejemplos, no un modelo universal de conectores. Valide los tipos de ajuste, la orientación del marco y los rangos de valores antes de aplicar el mismo cálculo a un preajuste diferente.

## **Encontrar el ángulo de dirección de un conector**

La dirección de un conector recto puede calcularse a partir de su ancho y alto, aplicando los volteos horizontales y verticales. El siguiente ejemplo informa el ángulo en sentido horario respecto al eje horizontal positivo en coordenadas de diapositiva:

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

**¿Cómo puedo saber si un conector puede unirse a una forma?**

Compruebe el valor de [getConnectionSiteCount](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/getconnectionsitecount/) de la forma. Un recuento positivo indica que la forma expone puntos de conexión. Valide el índice del punto seleccionado antes de asignarlo a cualquiera de los extremos del conector.

**¿Puedo identificar un ajuste de conector por su índice de colección?**

Un índice solo tiene sentido para un preajuste de conector y una disposición de colección conocidos. Compruebe [AdjustValue.getType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/adjustvalue/) antes de modificar un valor, y use [AdjustValue.getName](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/adjustvalue/getname/) como información adicional cuando el mismo tipo semántico ocurre más de una vez.

**¿Qué ocurre cuando se elimina una forma conectada?**

El extremo del conector correspondiente queda desunido. El conector permanece en la diapositiva y puede eliminarse, posicionarse como una línea libre o unirse a otra forma.

**¿Se conservan los enlaces del conector al copiar una diapositiva?**

Los enlaces suelen conservarse cuando se copian las formas conectadas con la diapositiva. Si se copia un conector sin una de sus formas objetivo, el extremo afectado debe volver a unirse.