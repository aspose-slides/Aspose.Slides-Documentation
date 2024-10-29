---
title: Forma Personalizada
type: docs
weight: 20
url: /es/androidjava/custom-shape/
keywords: "forma de PowerPoint, forma personalizada, presentación de PowerPoint, Java, Aspose.Slides para Android a través de Java"
description: "Agregar forma personalizada en la presentación de PowerPoint en Java"
---

# Cambiar una Forma Usando Puntos de Edición
Considera un cuadrado. En PowerPoint, usando **puntos de edición**, puedes 

* mover la esquina del cuadrado hacia adentro o hacia afuera
* especificar la curvatura para una esquina o punto
* agregar nuevos puntos al cuadrado
* manipular puntos en el cuadrado, etc.

Esencialmente, puedes realizar las tareas descritas en cualquier forma. Usando puntos de edición, puedes cambiar una forma o crear una nueva forma a partir de una forma existente.

## **Consejos para la Edición de Formas**

![overview_image](custom_shape_0.png)

Antes de comenzar a editar formas de PowerPoint a través de puntos de edición, es posible que desees considerar estos puntos sobre las formas:

* Una forma (o su trayectoria) puede ser cerrada o abierta.
* Cuando una forma está cerrada, carece de un punto de inicio o de fin. Cuando una forma está abierta, tiene un inicio y un final.
* Todas las formas consisten en al menos 2 puntos de anclaje vinculados entre sí por líneas.
* Una línea es recta o curva. Los puntos de anclaje determinan la naturaleza de la línea.
* Los puntos de anclaje existen como puntos de esquina, puntos rectos o puntos suaves:
  * Un punto de esquina es un punto donde 2 líneas rectas se unen en un ángulo.
  * Un punto suave es un punto donde 2 manijas existen en línea recta y los segmentos de línea se unen en una curva suave. En este caso, todas las manijas están separadas del punto de anclaje por una distancia igual.
  * Un punto recto es un punto donde 2 manijas existen en línea recta y los segmentos de línea de esa línea se unen en una curva suave. En este caso, las manijas no tienen que estar separadas del punto de anclaje por una distancia igual.
* Al mover o editar puntos de anclaje (lo que cambia el ángulo de las líneas), puedes cambiar la apariencia de una forma.

Para editar formas de PowerPoint a través de puntos de edición, **Aspose.Slides** proporciona la clase [**GeometryPath**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) y la interfaz [**IGeometryPath**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath).

* Una [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) instancia representa una trayectoria geométrica del objeto [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape).
* Para recuperar el `GeometryPath` de la instancia `IGeometryShape`, puedes usar el método [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#getGeometryPaths--).
* Para establecer el `GeometryPath` de una forma, puedes usar estos métodos: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) para *formas sólidas* y [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) para *formas compuestas*.
* Para agregar segmentos, puedes usar los métodos de [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath).
* Usando los métodos [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath#setStroke-boolean-) y [IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath#setFillMode-byte-), puedes establecer la apariencia de una trayectoria geométrica.
* Usando el método [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath#getPathData--), puedes recuperar la trayectoria geométrica de un `GeometryShape` como un array de segmentos de trayectoria.
* Para acceder a opciones adicionales de personalización de geometría de formas, puedes convertir [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) a [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)
* Usa [geometryPathToGraphicsPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) y [graphicsPathToGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) métodos (de la clase [ShapeUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil)) para convertir [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) a [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) y viceversa.

## **Operaciones de Edición Simples**

Este código Java te muestra cómo

**Agregar una línea** al final de una trayectoria

``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```
**Agregar una línea** a una posición específica en una trayectoria:

``` java    
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```
**Agregar una curva Bezier cúbica** al final de una trayectoria:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Agregar una curva Bezier cúbica** a la posición especificada en una trayectoria:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```
**Agregar una curva Bezier cuadrática** al final de una trayectoria:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Agregar una curva Bezier cuadrática** a una posición especificada en una trayectoria:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```
**Adjuntar un arco dado** a una trayectoria:

``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Cerrar la figura actual** de una trayectoria:

``` java
public void closeFigure();
```
**Establecer la posición para el siguiente punto**:

``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```
**Eliminar el segmento de trayectoria** en un índice dado:

``` java
public void removeAt(int index);
```

## **Agregar Puntos Personalizados a la Forma**
1. Crea una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape) y establece el tipo [ShapeType.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType).
2. Obtén una instancia de la clase [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) de la forma.
3. Agrega un nuevo punto entre los dos puntos superiores en la trayectoria.
4. Agrega un nuevo punto entre los dos puntos inferiores en la trayectoria.
5. Aplica la trayectoria a la forma.

Este código Java te muestra cómo agregar puntos personalizados a una forma:

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
![example1_image](custom_shape_1.png)

##  Eliminar Puntos de la Forma

1. Crea una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape) y establece el tipo [ShapeType.Heart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType).
2. Obtén una instancia de la clase [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) de la forma.
3. Elimina el segmento de la trayectoria.
4. Aplica la trayectoria a la forma.

Este código Java te muestra cómo eliminar puntos de una forma:

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
![example2_image](custom_shape_2.png)

##  **Crear Forma Personalizada**

1. Calcula los puntos para la forma.
2. Crea una instancia de la clase [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath).
3. Rellena la trayectoria con los puntos.
4. Crea una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape).
5. Aplica la trayectoria a la forma.

Este Java te muestra cómo crear una forma personalizada:

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
![example3_image](custom_shape_3.png)


## **Crear Forma Personalizada Compuesta**

1. Crea una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape).
2. Crea una primera instancia de la clase [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath).
3. Crea una segunda instancia de la clase [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath).
4. Aplica las trayectorias a la forma.

Este código Java te muestra cómo crear una forma personalizada compuesta:

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

    shape.setGeometryPaths(new GeometryPath[] { geometryPath0, geometryPath1 });
} finally {
    if (pres != null) pres.dispose();
}
```
![example4_image](custom_shape_4.png)

## **Crear Forma Personalizada con Esquinas Curvas**

Este código Java te muestra cómo crear una forma personalizada con esquinas curvas (hacia adentro);

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

## **Convertir GeometryPath a java.awt.Shape**

1. Crea una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape).
2. Crea una instancia de la clase [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).
3. Convierte la instancia [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) a la instancia [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) usando [ShapeUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil).
4. Aplica las trayectorias a la forma.

Este código Java—una implementación de los pasos anteriores—demuestra el proceso de conversión de **GeometryPath** a **GraphicsPath**:

``` java
Presentation pres = new Presentation();
try {
    // Crear nueva forma
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // Obtener la trayectoria geométrica de la forma
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // Crear nueva trayectoria gráfica con texto
    Shape graphicsPath;
    Font font = new java.awt.Font("Arial", Font.PLAIN, 40);
    String text = "Texto en forma";
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

    // Convertir trayectoria gráfica a trayectoria geométrica
    IGeometryPath textPath = ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(PathFillModeType.Normal);

    // Establecer combinación de nueva trayectoria geométrica y trayectoria geométrica original a la forma
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    if (pres != null) pres.dispose();
}
```
![example5_image](custom_shape_5.png)