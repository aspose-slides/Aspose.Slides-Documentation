---
title: Personaliza formas de presentación en Android
linktitle: Forma personalizada
type: docs
weight: 20
url: /es/androidjava/custom-shape/
keywords:
- forma personalizada
- añadir forma
- crear forma
- cambiar forma
- geometría de forma
- ruta geométrica
- puntos de ruta
- puntos de edición
- añadir punto
- eliminar punto
- operación de edición
- esquina curva
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Crea y personaliza formas en presentaciones de PowerPoint con Aspose.Slides para Android mediante Java: rutas geométricas, esquinas curvas, formas compuestas."
---

## **Cambiar una forma usando puntos de edición**
Considere un cuadrado. En PowerPoint, usando **puntos de edición**, puede 

* mover la esquina del cuadrado hacia adentro o hacia afuera
* especificar la curvatura de una esquina o punto
* añadir nuevos puntos al cuadrado
* manipular los puntos del cuadrado, etc. 

En esencia, puede realizar las tareas descritas en cualquier forma. Con los puntos de edición, puede cambiar una forma o crear una nueva forma a partir de una forma existente. 

## **Consejos para editar formas**

![imagen_resumen](custom_shape_0.png)

Antes de comenzar a editar formas de PowerPoint mediante puntos de edición, es posible que desee considerar estos puntos sobre las formas:

* Una forma (o su trayectoria) puede ser cerrada o abierta.
* Cuando una forma es cerrada, carece de punto de inicio o final. Cuando una forma es abierta, tiene un comienzo y un final. 
* Todas las formas constan de al menos 2 puntos de anclaje vinculados entre sí por líneas
* Una línea es recta o curva. Los puntos de anclaje determinan la naturaleza de la línea. 
* Los puntos de anclaje existen como puntos de esquina, puntos rectos o puntos suaves:
  * Un punto de esquina es un punto donde se unen 2 líneas rectas en un ángulo. 
  * Un punto suave es un punto donde 2 manejadores existen en una línea recta y los segmentos de la línea se unen en una curva suave. En este caso, todos los manejadores están separados del punto de anclaje por una distancia igual. 
  * Un punto recto es un punto donde 2 manejadores existen en una línea recta y esos segmentos de línea se unen en una curva suave. En este caso, los manejadores no tienen que estar separados del punto de anclaje por una distancia igual. 
* Al mover o editar los puntos de anclaje (lo que cambia el ángulo de las líneas), puede cambiar la apariencia de una forma. 

Para editar formas de PowerPoint mediante puntos de edición, **Aspose.Slides** proporciona la clase [**GeometryPath**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) y la interfaz [**IGeometryPath**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath).

* Una instancia de [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) representa una trayectoria geométrica del objeto [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape).
* Para obtener el `GeometryPath` de la instancia `IGeometryShape`, puede usar el método [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#getGeometryPaths--) .
* Para establecer el `GeometryPath` de una forma, puede usar estos métodos: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) para *formas sólidas* y [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) para *formas compuestas*.
* Para añadir segmentos, puede usar los métodos bajo [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath) .
* Usando los métodos [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath#setStroke-boolean-) y [IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath#setFillMode-byte-) , puede establecer la apariencia de una trayectoria geométrica.
* Usando el método [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath#getPathData--) , puede obtener la trayectoria geométrica de un `GeometryShape` como una matriz de segmentos de trayectoria.
* Para acceder a opciones adicionales de personalización de la geometría de la forma, puede convertir [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) a [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) .
* Utilice los métodos [geometryPathToGraphicsPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) y [graphicsPathToGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (de la clase [ShapeUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil) ) para convertir [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) a [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) y viceversa.

## **Operaciones de edición simples**

Este código Java le muestra cómo

**Añadir una línea** al final de una trayectoria
``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```

**Añadir una línea** a una posición especificada en una trayectoria:
``` java    
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```

**Añadir una curva Bézier cúbica** al final de una trayectoria:
``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```

**Añadir una curva Bézier cúbica** a la posición especificada en una trayectoria:
``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```

**Añadir una curva Bézier cuadrática** al final de una trayectoria:
``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```

**Añadir una curva Bézier cuadrática** a una posición especificada en una trayectoria:
``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```

**Añadir un arco dado** a una trayectoria:
``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```

**Cerrar la figura actual** de una trayectoria:
``` java
public void closeFigure();
```

**Establecer la posición del siguiente punto**:
``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```

**Eliminar el segmento de trayectoria** en un índice dado:
``` java
public void removeAt(int index);
```


## **Agregar puntos personalizados a una forma**
1. Cree una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape) y establezca el tipo [ShapeType.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType) .
2. Obtenga una instancia de la clase [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) de la forma.
3. Añada un nuevo punto entre los dos puntos superiores de la trayectoria.
4. Añada un nuevo punto entre los dos puntos inferiores de la trayectoria.
5. Aplique la trayectoria a la forma.

Este código Java le muestra cómo añadir puntos personalizados a una forma:
``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    IGeometryPath geometryPath = shape.getGeometryPaths()[0];

    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);
    shape.setGeometryPath(geometryPath);
} finally {
    if (pres != null) pres.dispose();
}
```

![ejemplo1_imagen](custom_shape_1.png)

## **Eliminar puntos de una forma**

1. Cree una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape) y establezca el tipo [ShapeType.Heart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType) .
2. Obtenga una instancia de la clase [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) de la forma.
3. Elimine el segmento de la trayectoria.
4. Aplique la trayectoria a la forma.

Este código Java le muestra cómo eliminar puntos de una forma:
``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300);

    IGeometryPath path = shape.getGeometryPaths()[0];
    path.removeAt(2);
    shape.setGeometryPath(path);
} finally {
    if (pres != null) pres.dispose();
}
```

![ejemplo2_imagen](custom_shape_2.png)

## **Crear una forma personalizada**

1. Calcule los puntos para la forma.
2. Cree una instancia de la clase [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) .
3. Rellene la trayectoria con los puntos.
4. Cree una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape) .
5. Aplique la trayectoria a la forma.

Este Java le muestra cómo crear una forma personalizada:
``` java
List<Point2D.Float> points = new ArrayList<Point2D.Float>();

float R = 100, r = 50;
int step = 72;

for (int angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math.PI / 180f);
    double x = R * Math.cos(radians);
    double y = R * Math.sin(radians);
    points.add(new Point2D.Float((float)x + R, (float)y + R));

    radians = Math.PI * (angle + step / 2) / 180.0;
    x = r * Math.cos(radians);
    y = r * Math.sin(radians);
    points.add(new Point2D.Float((float)x + R, (float)y + R));
}

GeometryPath starPath = new GeometryPath();
starPath.moveTo(points.get(0));

for (int i = 1; i < points.size(); i++)
{
    starPath.lineTo(points.get(i));
}

starPath.closeFigure();

Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, R * 2, R * 2);

    shape.setGeometryPath(starPath);
} finally {
    if (pres != null) pres.dispose();
}
```

![ejemplo3_imagen](custom_shape_3.png)


## **Crear una forma personalizada compuesta**

  1. Cree una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape) .
  2. Cree una primera instancia de la clase [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) .
  3. Cree una segunda instancia de la clase [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) .
  4. Aplique las trayectorias a la forma.

Este código Java le muestra cómo crear una forma personalizada compuesta:
``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryPath geometryPath0 = new GeometryPath();
    geometryPath0.moveTo(0, 0);
    geometryPath0.lineTo(shape.getWidth(), 0);
    geometryPath0.lineTo(shape.getWidth(), shape.getHeight()/3);
    geometryPath0.lineTo(0, shape.getHeight() / 3);
    geometryPath0.closeFigure();

    GeometryPath geometryPath1 = new GeometryPath();
    geometryPath1.moveTo(0, shape.getHeight()/3 * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight());
    geometryPath1.lineTo(0, shape.getHeight());
    geometryPath1.closeFigure();

    shape.setGeometryPaths(new GeometryPath[] { geometryPath0, geometryPath1});
} finally {
    if (pres != null) pres.dispose();
}
```

![ejemplo4_imagen](custom_shape_4.png)

## **Crear una forma personalizada con esquinas curvas**

Este código Java le muestra cómo crear una forma personalizada con esquinas curvas (hacia adentro);
```java
float shapeX = 20f;
float shapeY = 20f;
float shapeWidth = 300f;
float shapeHeight = 200f;

float leftTopSize = 50f;
float rightTopSize = 20f;
float rightBottomSize = 40f;
float leftBottomSize = 10f;

Presentation pres = new Presentation();
try {
    IAutoShape childShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(
            ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    GeometryPath geometryPath = new GeometryPath();

    Point2D.Float point1 = new Point2D.Float(leftTopSize, 0);
    Point2D.Float point2 = new Point2D.Float(shapeWidth - rightTopSize, 0);
    Point2D.Float point3 = new Point2D.Float(shapeWidth, shapeHeight - rightBottomSize);
    Point2D.Float point4 = new Point2D.Float(leftBottomSize, shapeHeight);
    Point2D.Float point5 = new Point2D.Float(0, leftTopSize);

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

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres!= null) pres.dispose();
}
```


## **Descubrir si la geometría de una forma está cerrada**

Una forma cerrada se define como aquella en la que todos sus lados se conectan, formando un solo contorno sin huecos. Dicha forma puede ser una figura geométrica simple o un contorno personalizado complejo. El siguiente ejemplo de código muestra cómo comprobar si la geometría de una forma está cerrada:
```java
boolean isGeometryClosed(IGeometryShape geometryShape)
{
    Boolean isClosed = null;

    for (IGeometryPath geometryPath : geometryShape.getGeometryPaths()) {
        int dataLength = geometryPath.getPathData().length;
        if (dataLength == 0)
            continue;

        IPathSegment lastSegment = geometryPath.getPathData()[dataLength - 1];
        isClosed = lastSegment.getPathCommand() == PathCommandType.Close;

        if (isClosed == false)
            return false;
    }

    return isClosed == true;
}
```


## **Convertir GeometryPath a java.awt.Shape** 

1. Cree una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape) .
2. Cree una instancia de la clase [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) .
3. Convierta la instancia de [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) a la instancia de [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) usando [ShapeUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil) .
4. Aplique las trayectorias a la forma.

Este código Java—una implementación de los pasos anteriores—demuestra el proceso de conversión de **GeometryPath** a **GraphicsPath**:
``` java
Presentation pres = new Presentation();
try {
    // Crear nueva forma
    GeometryShape shape = (GeometryShape)pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // Obtener la ruta de geometría de la forma
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // Crear nueva ruta gráfica con texto
    Shape graphicsPath;
    Font font = new java.awt.Font("Arial", Font.PLAIN, 40);
    String text = "Text in shape";
    BufferedImage img = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
    Graphics2D g2 = img.createGraphics();

    try
    {
        GlyphVector glyphVector = font.createGlyphVector(g2.getFontRenderContext(), text);
        graphicsPath = glyphVector.getOutline(20f, ((float) -glyphVector.getVisualBounds().getY()) + 10);
    }
    finally {
        g2.dispose();
    }

    // Convertir ruta gráfica a ruta de geometría
    IGeometryPath textPath = ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(PathFillModeType.Normal);

    // Establecer la combinación de la nueva ruta de geometría y la ruta de geometría original en la forma
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    if (pres != null) pres.dispose();
}
```

![ejemplo5_imagen](custom_shape_5.png)

## **Preguntas frecuentes**

**¿Qué ocurrirá con el relleno y el contorno después de reemplazar la geometría?**

El estilo permanece con la forma; solo cambia el contorno. El relleno y el contorno se aplican automáticamente a la nueva geometría.

**¿Cómo rotar correctamente una forma personalizada junto con su geometría?**

Utilice el método [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setRotation-float-) de la forma; la geometría rota con la forma porque está vinculada al propio sistema de coordenadas de la forma.

**¿Puedo convertir una forma personalizada en una imagen para “bloquear” el resultado?**

Sí. Exporte el área de la [diapositiva](/slides/es/androidjava/convert-powerpoint-to-png/) requerida o la propia [forma](/slides/es/androidjava/create-shape-thumbnails/) a un formato raster; esto simplifica el trabajo posterior con geometrías complejas.