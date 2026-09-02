---
title: Gestionar conectores en presentaciones en Java
linktitle: Conector
type: docs
weight: 10
url: /es/java/connector/
keywords:
- conector
- tipo de conector
- punto de conector
- línea de conector
- ángulo del conector
- sitio de conexión
- punto de ajuste
- conectar formas
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Aprende cómo agregar, adjuntar, volver a enrutar, ajustar e inspeccionar conectores rectos, doblados y curvos de PowerPoint con Aspose.Slides para Java."
---
## **Descripción general**

Un conector es una línea que puede mantenerse unida a dos formas cuando cualquiera de ellas se mueve. Sus extremos se conectan a sitios de conexión, representados por puntos verdes en PowerPoint. Algunos conectores doblados y curvos también exponen puntos de ajuste, representados por puntos naranjas, que controlan la posición de los segmentos individuales del conector.

Aspose.Slides representa los conectores a través de la interfaz [IConnector](https://reference.aspose.com/slides/es/java/com.aspose.slides/iconnector/). Puedes crear conectores, unir sus extremos a formas, elegir sitios de conexión, volver a enrutar los conectores y modificar la geometría de los conectores que tienen puntos de ajuste.

## **Tipos de conector**

La clase [ShapeType](https://reference.aspose.com/slides/es/java/com.aspose.slides/shapetype/) incluye predefinidos de conectores rectos, doblados y curvos. La tabla siguiente muestra las geometrías de conector disponibles y el número de puntos de ajuste definidos por cada predefinido.

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

El número y el significado de los puntos de ajuste forman parte del predefinido de conector seleccionado. No asumas que dos tipos de conector diferentes exponen la misma disposición de colección.

## **Conectar dos formas**

Utiliza [IShapeCollection.addConnector](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishapecollection/#addConnector-int-float-float-float-float-) para agregar un conector, y usa [IConnector.setStartShapeConnectedTo](https://reference.aspose.com/slides/es/java/com.aspose.slides/iconnector/#setStartShapeConnectedTo-com.aspose.slides.IShape-) y [IConnector.setEndShapeConnectedTo](https://reference.aspose.com/slides/es/java/com.aspose.slides/iconnector/#setEndShapeConnectedTo-com.aspose.slides.IShape-) para unir sus extremos. Después de que ambos extremos estén unidos, [IConnector.reroute](https://reference.aspose.com/slides/es/java/com.aspose.slides/iconnector/#reroute--) selecciona una ruta corta entre las formas.

El siguiente ejemplo conecta una elipse y un rectángulo con un conector doblado:

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
Llamar a `reroute` puede cambiar los valores de [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/es/java/com.aspose.slides/iconnector/#setStartShapeConnectionSiteIndex-long-) y [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/es/java/com.aspose.slides/iconnector/#setEndShapeConnectionSiteIndex-long-). Asigna sitios de conexión específicos después de volver a enrutar si esos sitios deben permanecer fijos.
{{% /alert %}}

## **Elegir un sitio de conexión**

Cada forma conectable informa su número de sitios a través de [IShape.getConnectionSiteCount](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#getConnectionSiteCount--). Valida un índice de sitio base cero preferido antes de asignarlo a un extremo del conector; el recuento de sitios varía según la geometría de la forma.

Este ejemplo une el conector a un sitio concreto de la elipse cuando ese sitio existe:

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

## **Ajustar un punto del conector**

Los conectores con puntos de ajuste los exponen a través de [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/es/java/com.aspose.slides/igeometryshape/#getAdjustments--). Inspecciona cada [IAdjustValue](https://reference.aspose.com/slides/es/java/com.aspose.slides/iadjustvalue/) y comprueba su valor de [getType](https://reference.aspose.com/slides/es/java/com.aspose.slides/iadjustvalue/#getType--) antes de cambiarlo con [setRawValue](https://reference.aspose.com/slides/es/java/com.aspose.slides/iadjustvalue/#setRawValue-long-). Las reglas generales para identificar ajustes predefinidos de forma se describen en [Manipulación de formas](/slides/es/java/shape-manipulations/).

El número, orden, significado y rango de valores válidos de los ajustes del conector dependen del predefinido del conector. El tipo de ajuste es de solo lectura, mientras que el valor del ajuste es escribible. El método de solo lectura [getName](https://reference.aspose.com/slides/es/java/com.aspose.slides/iadjustvalue/#getName--) proporciona identificación adicional cuando un conector contiene más de un ajuste del mismo tipo semántico.

### **Ruta alrededor de un obstáculo**

En el siguiente diseño, un conector `BentConnector5` entre dos formas pasa a través de una tercera forma:

![connector-obstruction](connector-obstruction.png)

Este código crea el conector obstruido:

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

Mover el pliegue vertical cambia la ruta de modo que el conector evita el obstáculo:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

En lugar de asumir que el índice de colección `1` siempre representa el pliegue vertical, este ejemplo busca `ConnectorBendPositionY` y lo cambia solo cuando el tipo semántico esperado está presente:

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

Un `BentConnector5` tiene dos ajustes `ConnectorBendPositionX` y un ajuste `ConnectorBendPositionY`. Si el tipo que necesitas aparece más de una vez, inspecciona `getName` y la geometría conocida de ese predefinido antes de seleccionar uno. Si un ajuste reporta `ShapeAdjustmentType.Custom`, trata su significado y rango como específicos del predefinido y no lo modifiques hasta que ese contrato sea conocido.

## **Relacionar valores de ajuste con la geometría del conector**

Para los conectores doblados, los valores de ajuste pueden usarse para estimar las posiciones de los segmentos individuales. Estos cálculos son específicos del predefinido del conector:

- `BentConnector4` normalmente expone un ajuste `ConnectorBendPositionX` y uno `ConnectorBendPositionY`.
- Para esas posiciones de pliegue, dividir el valor devuelto por `getRawValue` entre `100000f` produce la fracción del ancho o alto del marco del conector usada en los ejemplos siguientes.
- Un marco de conector puede rotarse o voltearse, por lo que las coordenadas del marco deben transformarse antes de compararse con las coordenadas de la diapositiva.

Los siguientes ejemplos usan `getType` para identificar primero los ajustes. No tratan los índices de colección como identificadores portátiles.

### **Conector sin rotar**

El diseño inicial contiene dos formas de texto conectadas por un `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Este ejemplo inspecciona el conector y obtiene sus ajustes de pliegue horizontal y vertical:

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

Para cambiar ambos pliegues, localiza cada tipo esperado y modifica los valores solo después de haber encontrado ambos:

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

El resultado es un conector cuyos segmentos horizontal y vertical se han desplazado:

![connector-adjusted-1](connector-adjusted-1.png)

Una vez que se conocen los tipos semánticos, sus valores pueden convertirse en coordenadas del marco del conector. Este ejemplo dibuja un rectángulo fino sobre el segmento vertical controlado por los dos ajustes de pliegue:

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

La forma guía marca el segmento calculado:

![connector-adjusted-2](connector-adjusted-2.png)

### **Conector rotado o volteado**

Cuando la misma geometría de conector se orienta verticalmente, los valores de [IShape.getFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#getFrame--), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/es/java/com.aspose.slides/shapeframe/#getFlipH--) y [ShapeFrame.getFlipV](https://reference.aspose.com/slides/es/java/com.aspose.slides/shapeframe/#getFlipV--) afectan la conversión de coordenadas del marco del conector a coordenadas de la diapositiva.

Este ejemplo crea y ajusta el conector orientado verticalmente:

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

El conector ajustado aparece verticalmente entre las formas:

![connector-adjusted-3](connector-adjusted-3.png)

Para un ángulo de rotación arbitrario `alpha`, rota un punto del marco del conector `(x, y)` alrededor del centro del marco `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

El siguiente código gestiona la orientación de 90 grados usada en este ejemplo y dibuja una guía roja sobre el segmento correspondiente del conector:

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

La guía roja marca el segmento calculado después de la transformación de coordenadas:

![connector-adjusted-4](connector-adjusted-4.png)

Estas fórmulas describen los predefinidos usados en los ejemplos, no un modelo universal de conector. Valida los tipos de ajuste, la orientación del marco y los rangos de valores antes de aplicar el mismo cálculo a un predefinido diferente.

## **Encontrar el ángulo de dirección de un conector**

La dirección de un conector recto puede calcularse a partir de su ancho y alto, con giros horizontales y verticales aplicados. El siguiente ejemplo muestra el ángulo en sentido horario desde el eje horizontal positivo en coordenadas de diapositiva:

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

**¿Cómo puedo saber si un conector puede unirse a una forma?**

Comprueba el valor de [getConnectionSiteCount](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#getConnectionSiteCount--) de la forma. Un recuento positivo indica que la forma expone sitios de conexión. Valida el índice del sitio seleccionado antes de asignarlo a cualquiera de los extremos del conector.

**¿Puedo identificar un ajuste de conector por su índice de colección?**

Un índice tiene sentido solo para un predefinido de conector conocido y su disposición de colección. Comprueba [IAdjustValue.getType](https://reference.aspose.com/slides/es/java/com.aspose.slides/iadjustvalue/#getType--) antes de modificar un valor, y usa [IAdjustValue.getName](https://reference.aspose.com/slides/es/java/com.aspose.slides/iadjustvalue/#getName--) como información adicional cuando el mismo tipo semántico ocurre más de una vez.

**¿Qué ocurre cuando se elimina una forma conectada?**

El extremo del conector correspondiente queda desacoplado. El conector permanece en la diapositiva y puede eliminarse, posicionarse como una línea libre o unirse a otra forma.

**¿Se conservan los enlaces de los conectores al copiar una diapositiva?**

Los enlaces se conservan generalmente cuando las formas conectadas se copian junto con la diapositiva. Si se copia un conector sin una de sus formas objetivo, el extremo afectado debe volver a unirse.