---
title: Conector
type: docs
weight: 10
url: /es/nodejs-java/connector/
keywords: "Conectar formas, conectores, formas de PowerPoint, presentación de PowerPoint, Java, Aspose.Slides para Node.js mediante Java"
description: "Conectar formas de PowerPoint en JavaScript"
---

Un conector de PowerPoint es una línea especial que une o enlaza dos formas y permanece adherida a ellas incluso cuando se mueven o reposicionan en una diapositiva dada.  

Los conectores se suelen enlazar a *puntos de conexión* (puntos verdes), que existen en todas las formas de forma predeterminada. Los puntos de conexión aparecen cuando el cursor se acerca a ellos.  

Los *puntos de ajuste* (puntos naranjas), que existen solo en ciertos conectores, se utilizan para modificar la posición y forma de los conectores.  

## **Tipos de conectores**

En PowerPoint, puedes usar conectores rectos, en codo (angulados) y curvos.  

Aspose.Slides proporciona estos conectores:

| Conector                      | Imagen                                                        | Número de puntos de ajuste |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **Conectar formas usando conectores**

1. Crea una instancia de la clase [Presentation](https://apireference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).  
1. Obtén la referencia a una diapositiva mediante su índice.  
1. Añade dos [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) a la diapositiva usando el método `addAutoShape` expuesto por el objeto `Shapes`.  
1. Añade un conector mediante el método `addConnector` expuesto por el objeto `Shapes` definiendo el tipo de conector.  
1. Conecta las formas usando el conector.  
1. Llama al método `reroute` para aplicar la ruta de conexión más corta.  
1. Guarda la presentación.  

Este código JavaScript muestra cómo añadir un conector (un conector en codo) entre dos formas (una elipse y un rectángulo):
```javascript
// Instancia una clase de presentación que representa el archivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accede a la colección de formas para una diapositiva específica
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // Añade una forma automática Elipse
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // Añade una forma automática Rectángulo
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // Añade una forma conector a la colección de formas de la diapositiva
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // Conecta las formas usando el conector
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // Llama a reroute que establece la ruta automática más corta entre las formas
    connector.reroute();
    // Guarda la presentación
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{%  alert title="NOTE"  color="warning"   %}} 
El método `Connector.reroute` reruta un conector y obliga a que tome la trayectoria más corta posible entre las formas. Para lograr su objetivo, el método puede cambiar los puntos `setStartShapeConnectionSiteIndex` y `setEndShapeConnectionSiteIndex`.  
{{% /alert %}} 

## **Especificar punto de conexión**

Si deseas que un conector enlace dos formas usando puntos específicos en las formas, debes especificar tus puntos de conexión preferidos de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).  
1. Obtén la referencia a una diapositiva mediante su índice.  
1. Añade dos [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) a la diapositiva usando el método `addAutoShape` expuesto por el objeto `Shapes`.  
1. Añade un conector mediante el método `addConnector` expuesto por el objeto `Shapes` definiendo el tipo de conector.  
1. Conecta las formas usando el conector.  
1. Establece tus puntos de conexión preferidos en las formas.  
1. Guarda la presentación.  

Este código JavaScript demuestra una operación donde se especifica un punto de conexión preferido:
```javascript
// Instancia una clase de presentación que representa un archivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accede a la colección de formas para una diapositiva específica
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // Agrega una forma automática Elipse
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // Agrega una forma automática Rectángulo
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // Agrega una forma conector a la colección de formas de la diapositiva
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // Conecta las formas usando el conector
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // Establece el índice del punto de conexión preferido en la forma Elipse
    var wantedIndex = 6;
    // Comprueba si el índice preferido es menor que el número máximo de sitios de conexión
    if (ellipse.getConnectionSiteCount() > wantedIndex) {
        // Establece el punto de conexión preferido en la forma automática Elipse
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }
    // Guarda la presentación
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Ajustar punto de conector**

Puedes ajustar un conector existente mediante sus puntos de ajuste. Solo los conectores con puntos de ajuste pueden modificarse de esta manera. Consulta la tabla bajo **[Tipos de conectores.](/slides/es/nodejs-java/connector/#types-of-connectors)**  

### **Caso simple**

Considera un caso en que un conector entre dos formas (A y B) pasa a través de una tercera forma (C):

![connector-obstruction](connector-obstruction.png)
```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Para evitar o pasar por encima de la tercera forma, podemos ajustar el conector moviendo su línea vertical hacia la izquierda de esta forma:

![connector-obstruction-fixed](connector-obstruction-fixed.png)
```javascript
var adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```


### **Casos complejos** 

Para realizar ajustes más complicados, debes tener en cuenta lo siguiente:

* El punto ajustable de un conector está fuertemente ligado a una fórmula que calcula y determina su posición. Por lo tanto, los cambios en la ubicación del punto pueden alterar la forma del conector.  
* Los puntos de ajuste de un conector se definen en un orden estricto dentro de una matriz. Los puntos de ajuste se numeran desde el punto de inicio del conector hasta su fin.  
* Los valores de los puntos de ajuste reflejan el porcentaje del ancho/alto de la forma del conector.  
  * La forma está limitada por los puntos de inicio y fin del conector multiplicados por 1000.  
  * El primer punto, segundo punto y tercer punto definen respectivamente el porcentaje del ancho, el porcentaje del alto y nuevamente el porcentaje del ancho.  
* Para los cálculos que determinan las coordenadas de los puntos de ajuste de un conector, debes considerar la rotación del conector y su reflexión. **Nota** que el ángulo de rotación para todos los conectores mostrados bajo **[Tipos de conectores](/slides/es/nodejs-java/connector/#types-of-connectors)** es 0.  

#### **Caso 1**

Considera un caso en que dos objetos de marco de texto están vinculados entre sí mediante un conector:

![connector-shape-complex](connector-shape-complex.png)
```javascript
// Instancia una clase de presentación que representa un archivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtiene la primera diapositiva de la presentación
    var sld = pres.getSlides().get_Item(0);
    // Añade formas que se unirán mediante un conector
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // Añade un conector
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    // Especifica la dirección del conector
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    // Especifica el color del conector
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Especifica el grosor de la línea del conector
    connector.getLineFormat().setWidth(3);
    // Enlaza las formas con el conector
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    // Obtiene los puntos de ajuste del conector
    var adjValue_0 = connector.getAdjustments().get_Item(0);
    var adjValue_1 = connector.getAdjustments().get_Item(1);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


**Ajuste**

Podemos cambiar los valores de los puntos de ajuste del conector incrementando el porcentaje correspondiente de ancho y alto en un 20 % y 200 %, respectivamente:
```javascript
// Cambia los valores de los puntos de ajuste
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```


El resultado:

![connector-adjusted-1](connector-adjusted-1.png)

Para definir un modelo que nos permita determinar las coordenadas y la forma de las partes individuales del conector, creemos una forma que corresponda al componente horizontal del conector en el punto `connector.getAdjustments().get_Item(0)`:
```javascript
// Dibuja el componente vertical del conector
var x = connector.getX() + ((connector.getWidth() * adjValue_0.getRawValue()) / 100000);
var y = connector.getY();
var height = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 0, height);
```


El resultado:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Caso 2**

En el **Caso 1**, demostramos una operación simple de ajuste de conector usando principios básicos. En situaciones normales, debes tener en cuenta la rotación del conector y su visualización (que se establecen mediante `connector.getRotation()`, `connector.getFrame().getFlipH()` y `connector.getFrame().getFlipV()`). Ahora demostraremos el proceso.  

Primero, añadamos un nuevo objeto de marco de texto (**To 1**) a la diapositiva (para fines de conexión) y creemos un nuevo conector (verde) que lo una a los objetos que ya creamos.
```javascript
// Crea un nuevo objeto de enlace
var shapeTo_1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// Crea un nuevo conector
connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
connector.getLineFormat().setWidth(3);
// Conecta los objetos usando el conector recién creado
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// Obtiene los puntos de ajuste del conector
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// Cambia los valores de los puntos de ajuste
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```


El resultado:

![connector-adjusted-3](connector-adjusted-3.png)

Segundo, creemos una forma que corresponda al componente horizontal del conector que pasa por el nuevo punto de ajuste `connector.getAdjustments().get_Item(0)`. Utilizaremos los valores del conector para `connector.getRotation()`, `connector.getFrame().getFlipH()` y `connector.getFrame().getFlipV()` y aplicaremos la popular fórmula de conversión de coordenadas para rotación alrededor de un punto dado x₀:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

En nuestro caso, el ángulo de rotación del objeto es 90 grados y el conector se muestra verticalmente, por lo que el código correspondiente es:
```javascript
// Guarda las coordenadas del conector
x = connector.getX();
y = connector.getY();
// Corrige las coordenadas del conector en caso de que aparezca
if (connector.getFrame().getFlipH() == aspose.slides.NullableBool.True) {
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == aspose.slides.NullableBool.True) {
    y += connector.getHeight();
}
// Toma el valor del punto de ajuste como coordenada
x += (connector.getWidth() * adjValue_0.getRawValue()) / 100000;
// Convierte las coordenadas ya que Sin(90) = 1 y Cos(90) = 0
var xx = (connector.getFrame().getCenterX() - y) + connector.getFrame().getCenterY();
var yy = (x - connector.getFrame().getCenterX()) + connector.getFrame().getCenterY();
// Determina el ancho del componente horizontal usando el valor del segundo punto de ajuste
var width = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```


El resultado:

![connector-adjusted-4](connector-adjusted-4.png)

Demostramos cálculos que involucran ajustes simples y puntos de ajuste complicados (puntos de ajuste con ángulos de rotación). Con el conocimiento adquirido, puedes desarrollar tu propio modelo (o escribir código) para obtener un objeto `GraphicsPath` o incluso establecer los valores de los puntos de ajuste del conector en función de coordenadas específicas de la diapositiva.  

## **Encontrar ángulo de líneas de conector**

1. Crea una instancia de la clase.  
1. Obtén la referencia a una diapositiva mediante su índice.  
1. Accede a la forma de línea del conector.  
1. Usa el ancho, alto, altura del marco de la forma y ancho del marco de la forma para calcular el ángulo.  

Este código JavaScript demuestra una operación en la que calculamos el ángulo para una forma de línea de conector:
```javascript
var pres = new aspose.slides.Presentation("ConnectorLineAngle.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var dir = 0.0;
        var shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var ashp = shape;
            if (ashp.getShapeType() == aspose.slides.ShapeType.Line) {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        } else if (java.instanceOf(shape, "com.aspose.slides.Connector")) {
            var ashp = shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }
        console.log(dir);
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
function getDirection(w, h, flipH, flipV) {
    let endLineX = w * (flipH ? -1 : 1);
    let endLineY = h * (flipV ? -1 : 1);
    
    let endYAxisX = 0;
    let endYAxisY = h;

    let angle = Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX);

    if (angle < 0) {
        angle += 2 * Math.PI;
    }

    return angle * 180.0 / Math.PI;
}
```


## **FAQ**

**¿Cómo puedo saber si un conector puede "pegarse" a una forma específica?**  

Comprueba que la forma exponga [sitios de conexión](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getconnectionsitecount/). Si no hay ninguno o el recuento es cero, no es posible pegar; en ese caso, usa puntos finales libres y posiciónalos manualmente. Es aconsejable verificar el recuento de sitios antes de adjuntar.  

**¿Qué ocurre con un conector si elimino una de las formas conectadas?**  

Sus extremos se desacoplan; el conector permanece en la diapositiva como una línea ordinaria con inicio/final libres. Puedes eliminarlo o reasignar las conexiones y, si es necesario, [reroute](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connector/reroute/).  

**¿Se conservan los enlaces del conector al copiar una diapositiva a otra presentación?**  

Generalmente sí, siempre que las formas objetivo también se copien. Si la diapositiva se inserta en otro archivo sin las formas conectadas, los extremos se vuelven libres y tendrás que volver a adjuntarlos.