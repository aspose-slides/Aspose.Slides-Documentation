---
title: Forma personalizada
type: docs
weight: 20
url: /es/nodejs-java/custom-shape/
keywords:
- forma
- forma personalizada
- crear forma
- geometría
- geometría de forma
- ruta de geometría
- puntos de ruta
- puntos de edición
- PowerPoint
- presentación
- JavaScript
- Aspose.Slides para Node.js vía Java
description: "Agregar una forma personalizada a una presentación de PowerPoint en JavaScript"
---

## **Cambiar una forma usando puntos de edición**

Considere un cuadrado. En PowerPoint, usando **puntos de edición**, puede 

* mover la esquina del cuadrado hacia adentro o hacia afuera
* especificar la curvatura de una esquina o punto
* añadir nuevos puntos al cuadrado
* manipular puntos en el cuadrado, etc. 

Básicamente, puede realizar las tareas descritas en cualquier forma. Con los puntos de edición, puede cambiar una forma o crear una nueva forma a partir de una forma existente. 

## **Consejos para editar formas**

![overview_image](custom_shape_0.png)

Antes de comenzar a editar formas de PowerPoint mediante puntos de edición, puede que desee considerar estos aspectos sobre las formas:

* Una forma (o su ruta) puede ser cerrada o abierta.
* Cuando una forma está cerrada, no tiene punto de inicio ni de fin. Cuando una forma está abierta, tiene un comienzo y un final. 
* Todas las formas constan de al menos 2 puntos de anclaje vinculados entre sí por líneas.
* Una línea es recta o curva. Los puntos de anclaje determinan la naturaleza de la línea. 
* Los puntos de anclaje existen como puntos de esquina, puntos rectos o puntos suaves:
  * Un punto de esquina es un punto donde 2 líneas rectas se unen en un ángulo. 
  * Un punto suave es un punto donde 2 mangos existen en una línea recta y los segmentos de la línea se unen en una curva suave. En este caso, todos los mangos están separados del punto de anclaje por una distancia igual. 
  * Un punto recto es un punto donde 2 mangos existen en una línea recta y los segmentos de esa línea se unen en una curva suave. En este caso, los mangos no tienen que estar separados del punto de anclaje por una distancia igual. 
* Moviendo o editando los puntos de anclaje (lo que cambia el ángulo de las líneas), puede modificar la apariencia de una forma. 

Para editar formas de PowerPoint mediante puntos de edición, **Aspose.Slides** proporciona la clase [**GeometryPath**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) y la clase [**GeometryPath**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath).

* Una instancia de [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) representa la ruta geométrica del objeto [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape).
* Para obtener el `GeometryPath` de la instancia `GeometryShape`, puede usar el método [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape#getGeometryPaths--).
* Para establecer el `GeometryPath` de una forma, puede usar estos métodos: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape#setGeometryPath-aspose.slides.IGeometryPath-) para *formas solidas* y [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape#setGeometryPaths-aspose.slides.IGeometryPath:A-) para *formas compuestas*.
* Para añadir segmentos, puede usar los métodos bajo [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath).
* Usando los métodos [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath#setStroke-boolean-) y [GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath#setFillMode-byte-), puede establecer la apariencia de una ruta geométrica.
* Con el método [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath#getPathData--) puede obtener la ruta geométrica de un `GeometryShape` como una matriz de segmentos de ruta.
* Para acceder a opciones adicionales de personalización de la geometría de la forma, puede convertir [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) a [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)
* Use los métodos [geometryPathToGraphicsPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeUtil#geometryPathToGraphicsPath-aspose.slides.IGeometryPath-) y [graphicsPathToGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (de la clase [ShapeUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeUtil)) para convertir [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) a [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) y viceversa.

## **Operaciones de edición simples**

Este código JavaScript muestra cómo

**Agregar una línea** al final de una ruta
```javascript
lineTo(point);
lineTo(x, y);
```

**Agregar una línea** a una posición específica en una ruta:
```javascript
lineTo(point, index);
lineTo(x, y, index);
```

**Agregar una curva Bézier cúbica** al final de una ruta:
```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```

**Agregar una curva Bézier cúbica** a la posición especificada en una ruta:
```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```

**Agregar una curva Bézier cuadrática** al final de una ruta:
```javascript
quadraticBezierTo(point1, point2);
quadraticBezierTo(x1, y1, x2, y2);
```

**Agregar una curva Bézier cuadrática** a una posición específica en una ruta:
```javascript
quadraticBezierTo(point1, point2, index);
quadraticBezierTo(x1, y1, x2, y2, index);
```

**Anexar un arco dado** a una ruta:
```javascript
arcTo(width, heigth, startAngle, sweepAngle);
```

**Cerrar la figura actual** de una ruta:
```javascript
closeFigure();
```

**Establecer la posición para el siguiente punto**:
```javascript
moveTo(point);
moveTo(x, y);
```

**Eliminar el segmento de ruta** en un índice dado:
```javascript
removeAt(index);
```


## **Agregar puntos personalizados a la forma**
1. Cree una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape) y establezca el tipo [ShapeType.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType).
2. Obtenga una instancia de la clase [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) a partir de la forma.
3. Agregue un nuevo punto entre los dos puntos superiores de la ruta.
4. Agregue un nuevo punto entre los dos puntos inferiores de la ruta.
5. Aplique la ruta a la forma.

Este código JavaScript muestra cómo agregar puntos personalizados a una forma:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);
    shape.setGeometryPath(geometryPath);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![example1_image](custom_shape_1.png)

## **Eliminar puntos de la forma**

1. Cree una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape) y establezca el tipo [ShapeType.Heart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType).
2. Obtenga una instancia de la clase [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) a partir de la forma.
3. Elimine el segmento de la ruta.
4. Aplique la ruta a la forma.

Este código JavaScript muestra cómo eliminar puntos de una forma:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Heart, 100, 100, 300, 300);
    var path = shape.getGeometryPaths()[0];
    path.removeAt(2);
    shape.setGeometryPath(path);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![example2_image](custom_shape_2.png)

## **Crear forma personalizada**

1. Calcule los puntos para la forma.
2. Cree una instancia de la clase [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath).
3. Rellene la ruta con los puntos.
4. Cree una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape).
5. Aplique la ruta a la forma.

Este JavaScript muestra cómo crear una forma personalizada:
```javascript
var points = java.newInstanceSync("java.util.ArrayList");
var R = 100;
var r = 50;
var step = 72;
for (var angle = -90; angle < 270; angle += step) {
    var radians = angle * (java.getStaticFieldValue("java.lang.Math", "PI") / 180.0);
    var x = R * java.callStaticMethodSync("java.lang.Math", "cos", radians);
    var y = R * java.callStaticMethodSync("java.lang.Math", "sin", radians);
    points.add(java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(x + R), java.newFloat(y + R)));
    radians = (java.getStaticFieldValue("java.lang.Math", "PI") * (angle + (step / 2))) / 180.0;
    x = r * java.callStaticMethodSync("java.lang.Math", "cos", radians);
    y = r * java.callStaticMethodSync("java.lang.Math", "sin", radians);
    points.add(java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(x + R), java.newFloat(y + R)));
}
var starPath = new aspose.slides.GeometryPath();
starPath.moveTo(points.get(0));
for (var i = 1; i < points.size(); i++) {
    starPath.lineTo(points.get(i));
}
starPath.closeFigure();
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, R * 2, R * 2);
    shape.setGeometryPath(starPath);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![example3_image](custom_shape_3.png)


## **Crear forma compuesta personalizada**

  1. Cree una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape).
  2. Cree una primera instancia de la clase [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath).
  3. Cree una segunda instancia de la clase [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath).
  4. Aplique las rutas a la forma.

Este código JavaScript muestra cómo crear una forma compuesta personalizada:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var geometryPath0 = new aspose.slides.GeometryPath();
    geometryPath0.moveTo(0, 0);
    geometryPath0.lineTo(shape.getWidth(), 0);
    geometryPath0.lineTo(shape.getWidth(), shape.getHeight() / 3);
    geometryPath0.lineTo(0, shape.getHeight() / 3);
    geometryPath0.closeFigure();
    var geometryPath1 = new aspose.slides.GeometryPath();
    geometryPath1.moveTo(0, (shape.getHeight() / 3) * 2);
    geometryPath1.lineTo(shape.getWidth(), (shape.getHeight() / 3) * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight());
    geometryPath1.lineTo(0, shape.getHeight());
    geometryPath1.closeFigure();
    shape.setGeometryPaths(java.newArray("com.aspose.slides.GeometryPath",[geometryPath0, geometryPath1]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![example4_image](custom_shape_4.png)

## **Crear forma personalizada con esquinas curvas**

Este código JavaScript muestra cómo crear una forma personalizada con esquinas curvas (hacia adentro);
```javascript
var shapeX = 20.0;
var shapeY = 20.0;
var shapeWidth = 300.0;
var shapeHeight = 200.0;
var leftTopSize = 50.0;
var rightTopSize = 20.0;
var rightBottomSize = 40.0;
var leftBottomSize = 10.0;
var pres = new aspose.slides.Presentation();
try {
    var childShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);
    var geometryPath = new aspose.slides.GeometryPath();
    var point1 = java.newInstanceSync("com.aspose.slides.Point2DFloat", leftTopSize, 0);
    var point2 = java.newInstanceSync("com.aspose.slides.Point2DFloat", shapeWidth - rightTopSize, 0);
    var point3 = java.newInstanceSync("com.aspose.slides.Point2DFloat", shapeWidth, shapeHeight - rightBottomSize);
    var point4 = java.newInstanceSync("com.aspose.slides.Point2DFloat", leftBottomSize, shapeHeight);
    var point5 = java.newInstanceSync("com.aspose.slides.Point2DFloat", 0, leftTopSize);
    geometryPath.moveTo(point1);
    geometryPath.lineTo(point2);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(point3);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(point4);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(point5);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();
    childShape.setGeometryPath(geometryPath);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Determinar si la geometría de una forma está cerrada**

Una forma cerrada se define como aquella en la que todos sus lados se conectan, formando un único contorno sin huecos. Esa forma puede ser una figura geométrica simple o un contorno personalizado complejo. El siguiente ejemplo de código muestra cómo comprobar si la geometría de una forma está cerrada:
```java
function isGeometryClosed(geometryShape) 
{
    let isClosed = null;

    geometryShape.getGeometryPaths().forEach(geometryPath => {
        const pathData = geometryPath.getPathData();
        const dataLength = pathData.length;

        if (dataLength === 0) return;

        const lastSegment = pathData[dataLength - 1];
        isClosed = lastSegment.getPathCommand() === aspose.slides.PathCommandType.Close;

        if (!isClosed) return false;
    });

    return isClosed === true;
}
```


## **Convertir GeometryPath a java.awt.Shape** 

1. Cree una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape).
2. Cree una instancia de la clase [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).
3. Convierta la instancia [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) a la instancia [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) usando [ShapeUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeUtil).
4. Aplique las rutas a la forma.

Este código JavaScript—una implementación de los pasos anteriores—demuestra el proceso de conversión de **GeometryPath** a **GraphicsPath**:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Crear nueva forma
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 100);
    // Obtener la ruta geométrica de la forma
    var originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(aspose.slides.PathFillModeType.None);
    // Crear nueva ruta gráfica con texto
    var graphicsPath;
    var font = java.newInstanceSync("java.awt.Font", "Arial", java.getStaticFieldValue("java.awt.Font", "PLAIN"), 40);
    var text = "Text in shape";
    var img = java.newInstanceSync("BufferedImage", 100, 100, java.getStaticFieldValue("BufferedImage", "TYPE_INT_ARGB"));
    var g2 = img.createGraphics();
    try {
        var glyphVector = font.createGlyphVector(g2.getFontRenderContext(), text);
        graphicsPath = glyphVector.getOutline(20.0, -glyphVector.getVisualBounds().getY() + 10);
    } finally {
        g2.dispose();
    }
    // Convertir ruta gráfica a ruta geométrica
    var textPath = aspose.slides.ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(aspose.slides.PathFillModeType.Normal);
    // Establecer combinación de la nueva ruta geométrica y la ruta geométrica original en la forma
    shape.setGeometryPaths(java.newArray("com.aspose.slides.IGeometryPath", [originalPath, textPath]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![example5_image](custom_shape_5.png)

## **Preguntas frecuentes**

**¿Qué sucede con el relleno y el contorno después de reemplazar la geometría?**

El estilo permanece con la forma; solo cambia el contorno. El relleno y el contorno se aplican automáticamente a la nueva geometría.

**¿Cómo rotar correctamente una forma personalizada junto con su geometría?**

Utilice el método [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setrotation/) de la forma; la geometría gira con la forma porque está vinculada al propio sistema de coordenadas de la forma.

**¿Puedo convertir una forma personalizada a una imagen para “bloquear” el resultado?**

Sí. Exporte el área de la [diapositiva](/slides/es/nodejs-java/convert-powerpoint-to-png/) requerida o la [forma](/slides/es/nodejs-java/create-shape-thumbnails/) misma a un formato raster; esto simplifica el trabajo posterior con geometrías complejas.