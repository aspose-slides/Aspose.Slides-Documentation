---
title: Personalizar formas de presentación en Java
linktitle: Forma personalizada
type: docs
weight: 20
url: /es/java/custom-shape/
keywords:
- forma personalizada
- añadir forma
- crear forma
- cambiar forma
- geometría de forma
- ruta de geometría
- puntos de ruta
- puntos de edición
- añadir punto
- eliminar punto
- operación de edición
- esquina curvada
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Crear y personalizar formas en presentaciones de PowerPoint con Aspose.Slides para Java: rutas de geometría, esquinas curvadas, formas compuestas."
---
## **Visión general**

Este artículo explica cómo personalizar formas de presentación en Aspose.Slides editando la geometría de la forma mediante puntos de edición y rutas de geometría. Muestra cómo trabajar con [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) y [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) para modificar formas existentes, realizar operaciones básicas de edición de rutas, añadir o eliminar puntos y aplicar la geometría actualizada a una forma.

También demuestra cómo crear formas personalizadas y compuestas, construir formas con esquinas curvadas, determinar si la geometría de una forma está cerrada, inspeccionar los elementos de la forma y convertir contornos de texto AWT de Java en rutas de geometría.

## **Cambiar una forma usando Puntos de edición**

En PowerPoint, puedes usar **Puntos de edición** para modificar un cuadrado:

* Mover una esquina hacia dentro o hacia fuera.
* Ajustar la curvatura en un punto.
* Añadir nuevos puntos.

Editar puntos te permite modificar el contorno de una forma o usar una forma existente como base para una nueva.

## **Consejos para editar formas**

![overview_image](custom_shape_0.png)

Al editar formas de PowerPoint, tenga en cuenta estos conceptos:

* Una forma (o su ruta) puede estar cerrada o abierta.
* La ruta de una forma está compuesta por puntos de anclaje conectados por segmentos.
* Un segmento puede ser recto o curvo. Los puntos de anclaje y los tiradores de control determinan su forma.
* Los puntos de anclaje pueden ser puntos de esquina, puntos rectos o puntos suaves:
  * En un punto de esquina, los segmentos adyacentes pueden encontrarse en un ángulo.
  * En un punto suave, los dos tiradores de control están alineados y a la misma distancia del punto de anclaje.
  * En un punto recto, los dos tiradores de control están alineados pero pueden estar a distintas distancias del punto de anclaje.
* Mover los puntos de anclaje o ajustar sus tiradores modifica el contorno de la forma.

Para editar formas de PowerPoint mediante puntos de edición, **Aspose.Slides** proporciona la clase [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) y la interfaz [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/).

* Una instancia de [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) representa la ruta de geometría del objeto [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/).
* Para obtener la [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) de una instancia de [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/), puedes usar el método [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--).
* Para establecer la [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) de una forma, puedes usar estos métodos: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) para formas con una sola ruta y [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) para formas con varias rutas.
* Para añadir segmentos, puedes usar los métodos de [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/).
* Con los métodos [IGeometryPath.setStroke](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setStroke-boolean-) y [IGeometryPath.setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-), puedes definir la apariencia de una ruta de geometría.
* Mediante el método [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) puedes obtener la ruta de geometría de un [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/geometryshape/) como una matriz de segmentos de ruta.
* Para acceder a opciones adicionales de personalización de la geometría de la forma, puedes leer un [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) a través de su [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) y reproducir los segmentos en una [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/).

## **Operaciones de edición simples**

Utiliza los siguientes métodos para editar una ruta de geometría. Las sobrecargas que aceptan un índice insertan un segmento en esa posición basada en cero dentro de la matriz de segmentos de la ruta.

| Operación | Método |
| --- | --- |
| Añadir o insertar una línea recta. | [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| Añadir o insertar una curva Bézier cúbica con dos puntos de control y un punto final. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Añadir o insertar una curva Bézier cuadrática con un punto de control y un punto final. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Añadir un arco elíptico con las dimensiones y ángulos especificados en grados. | [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| Cerrar la figura actual conectando su punto final con su punto inicial. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) |
| Establecer el punto inicial de una figura. | [GeometryPath.moveTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Eliminar un segmento en un índice basado en cero. | [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Añadir puntos personalizados a una forma**

Este ejemplo inserta dos puntos en una forma rectangular mediante [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) y aplica la ruta editada con [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-). Las coordenadas son locales a la forma: ambos puntos nuevos están en su centro, a 100 puntos del borde izquierdo y 50 puntos del borde superior. Los índices de segmento 1 y 4 los sitúan en los bordes superior e inferior, tirando esos bordes hacia dentro.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    IGeometryPath geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```

![example1_image](custom_shape_1.png)

## **Eliminar puntos de una forma**

Este ejemplo modifica el contorno de una forma en forma de corazón eliminando el segmento en el índice basado en cero 2 con [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-). Aplicar la ruta modificada con [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) actualiza el contorno de la forma.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300);

    IGeometryPath path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```
![example2_image](custom_shape_2.png)

## **Crear una forma personalizada**

Este ejemplo construye una estrella de cinco puntas con [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/). Radios exteriores e interiores alternados de 100 y 50 puntos definen las puntas y las hendiduras; un paso de 72 grados distribuye uniformemente las cinco puntas. La ruta se cierra con [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) y se aplica a una forma rectangular mediante [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), sustituyendo su contorno.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;
import java.util.ArrayList;
import java.util.List;

List<Point2D.Float> points = new ArrayList<>();

float outerRadius = 100f;
float innerRadius = 50f;
int angleStep = 72;

for (int angle = -90; angle < 270; angle += angleStep)
{
    double radians = angle * (Math.PI / 180f);
    double x = outerRadius * Math.cos(radians);
    double y = outerRadius * Math.sin(radians);
    Point2D.Float point = new Point2D.Float((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.cos(radians);
    y = innerRadius * Math.sin(radians);
    point = new Point2D.Float((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);
}

GeometryPath starPath = new GeometryPath();
starPath.moveTo(points.get(0));

for (int i = 1; i < points.size(); i++)
{
    starPath.lineTo(points.get(i));
}

starPath.closeFigure();

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```
![example3_image](custom_shape_3.png)

## **Crear una forma compuesta personalizada**

Este ejemplo define dos [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) cerrados para el tercio superior y el tercio inferior de una forma. Aplicar ambas rutas con [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) crea una única forma compuesta con una abertura en el tercio medio.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryPath topPath = new GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), shape.getHeight() / 3);
    topPath.lineTo(0, shape.getHeight() / 3);
    topPath.closeFigure();

    GeometryPath bottomPath = new GeometryPath();
    bottomPath.moveTo(0, shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    shape.setGeometryPaths(new GeometryPath[] { topPath, bottomPath });
} finally {
    presentation.dispose();
}
```
![example4_image](custom_shape_4.png)

## **Crear una forma personalizada con esquinas curvadas**

Este ejemplo combina segmentos rectos con [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) para crear una forma con esquinas curvadas hacia dentro. Cada tamaño de esquina establece el ancho y alto del arco en puntos, y el barrido de -90 grados dibuja un cuarto de elipse en sentido antihorario. La ruta completa se aplica con [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), y la presentación se guarda en formato PPTX.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

float shapeX = 20f;
float shapeY = 20f;
float shapeWidth = 300f;
float shapeHeight = 200f;

float leftTopSize = 50f;
float rightTopSize = 20f;
float rightBottomSize = 40f;
float leftBottomSize = 10f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    Point2D.Float topLeft = new Point2D.Float(leftTopSize, 0);
    Point2D.Float topRight = new Point2D.Float(shapeWidth - rightTopSize, 0);
    Point2D.Float rightBottom = new Point2D.Float(shapeWidth, shapeHeight - rightBottomSize);
    Point2D.Float bottomLeft = new Point2D.Float(leftBottomSize, shapeHeight);
    Point2D.Float leftTop = new Point2D.Float(0, leftTopSize);

    GeometryPath geometryPath = new GeometryPath();
    geometryPath.moveTo(topLeft);
    geometryPath.lineTo(topRight);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(rightBottom);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(bottomLeft);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(leftTop);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Comprobar si la geometría de una forma está cerrada**

El siguiente ayudante verifica si cada ruta de geometría no vacía termina con un segmento de cierre. Lee [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) y compara el [IPathSegment.getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) del segmento final con [PathCommandType.Close](https://reference.aspose.com/slides/java/com.aspose.slides/pathcommandtype/). Devuelve false cuando no hay rutas no vacías. Este método comprueba el comando final de cada ruta; no inspecciona cada subfigura dentro de una ruta. El ejemplo muestra `true` para un rectángulo.

```java
import com.aspose.slides.*;

class GeometryInspector {
    boolean isGeometryClosed(IGeometryShape geometryShape) {
        boolean hasNonemptyPath = false;

        for (IGeometryPath geometryPath : geometryShape.getGeometryPaths()) {
            IPathSegment[] segments = geometryPath.getPathData();
            if (segments.length == 0) {
                continue;
            }

            hasNonemptyPath = true;
            IPathSegment lastSegment = segments[segments.length - 1];
            if (lastSegment.getPathCommand() != PathCommandType.Close) {
                return false;
            }
        }

        return hasNonemptyPath;
    }
}

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryInspector inspector = new GeometryInspector();
    boolean closed = inspector.isGeometryClosed(shape);
    System.out.println(closed);
} finally {
    presentation.dispose();
}
```

## **Inspeccionar los comandos de la ruta de geometría**

Descarga [contour.pptx](contour.pptx) y colócalo en el directorio de trabajo de la aplicación. La primera forma de la primera diapositiva tiene un borde superior recto, una curva Bézier cúbica y un borde de cierre recto. Usa [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) para leer las rutas de la forma y [getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) para leer los segmentos de cada ruta en orden de dibujo. Para cada segmento, [getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) identifica el comando y determina cómo interpretar los valores devueltos por [getSegmentData](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getSegmentData--).

```java
import com.aspose.slides.*;
import java.util.Arrays;

Presentation presentation = new Presentation("contour.pptx");
try {
    IGeometryShape shape = (IGeometryShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IGeometryPath[] paths = shape.getGeometryPaths();

    for (int i = 0; i < paths.length; i++) {
        IPathSegment[] segments = paths[i].getPathData();
        for (int j = 0; j < segments.length; j++) {
            byte command = segments[j].getPathCommand();
            float[] data = segments[j].getSegmentData();
            String detail;
            switch (command) {
                case PathCommandType.MoveTo:
                case PathCommandType.LineTo:
                    detail = String.format("destination=(%s, %s)", data[0], data[1]);
                    break;
                case PathCommandType.CubicBezierTo:
                    detail = String.format("control1=(%s, %s) control2=(%s, %s) end=(%s, %s)", data[0], data[1], data[2], data[3], data[4], data[5]);
                    break;
                case PathCommandType.Close:
                    detail = "no coordinates";
                    break;
                default:
                    detail = "raw=" + Arrays.toString(data);
            }
            String name = PathCommandType.getName(PathCommandType.class, command);
            System.out.printf("Path %d, segment %d: %s %s%n", i, j, name, detail);
        }
    }
} finally {
    presentation.dispose();
}
```

La forma está situada en (200, 100) puntos en la diapositiva. Las coordenadas informadas son locales a la forma, con (0, 0) en su esquina superior izquierda, x aumentando hacia la derecha y y aumentando hacia abajo. El segmento de cierre vuelve al punto inicial sin coordenadas adicionales.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **Extraer e inspeccionar los elementos de la forma**

Utiliza [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#createShapeElements--) para inspeccionar una forma existente como elementos que contienen puntos de ruta y tipos de punto. Convierte cada [IShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/ishapeelement/) devuelto a [ShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/) para obtener las matrices de puntos y tipos mediante los métodos [getPathPoints](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathPoints--) y [getPathTypes](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathTypes--). Esta representación es útil para análisis de contorno o para pasar la geometría a herramientas de dibujo personalizadas.

El ejemplo abre input.pptx, encuentra la primera forma de geometría directamente en la primera diapositiva e imprime sus segmentos de ruta. Usa una presentación que contenga una forma con segmentos rectos y curvos para ver ambos tipos de salida. No busca dentro de grupos.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IGeometryShape shape = null;
    for (IShape candidate : slide.getShapes()) {
        if (candidate instanceof IGeometryShape) {
            shape = (IGeometryShape) candidate;
            break;
        }
    }

    if (shape == null) {
        System.out.println("No geometry shape found on the first slide.");
    } else {
        for (IShapeElement element : shape.createShapeElements()) {
            ShapeElement shapeElement = (ShapeElement) element;
            Point2D.Float[] points = shapeElement.getPathPoints();
            byte[] types = shapeElement.getPathTypes();
            System.out.println("Shape element:");

            for (int i = 0; i < points.length; i++) {
                int pointType = types[i] & 0x07; // Mantener el tipo de segmento, excluyendo las banderas.
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Consume both control points and the endpoint.
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    System.out.println("Close subpath back to its starting point.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Las matrices corresponden por índice: `points[i]` es un punto y `types[i]` describe su función. El tipo `0` inicia una figura, y el tipo `1` dibuja una línea desde el punto anterior hasta el punto actual. Un segmento Bézier cúbico comienza en el punto final anterior y usa tres entradas consecutivas de tipo `3`: dos puntos de control y el nuevo punto final. El bucle consume esas tres entradas juntas y comprueba el punto final para detectar cierre.

Los tipos de punto también contienen banderas. Enmascara con `0x07` para identificar el tipo de segmento y prueba `0x80` por separado para detectar una subruta cerrada. Por ejemplo, `129` (`0x81`) significa un punto final de línea que cierra una subruta, y `131` (`0x83`) significa un punto final Bézier que la cierra. Java almacena estas banderas en bytes con signo; la máscara conserva los valores de bits previstos. Comparar el valor sin procesar solo con `1` o `3` omitirá estos casos. Otras banderas, como guion (`0x10`) y marcador (`0x20`), no alteran el tipo base del segmento.

**Coordenadas y transformaciones.** Los puntos se miden en puntos (1/72 de pulgada), con X aumentando a la derecha y Y aumentando hacia abajo. Para una forma sin agrupar, las coordenadas extraídas ya incluyen la posición devuelta por [getX](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getX--) y [getY](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getY--) y reflejan su anchura y altura actuales. Por ejemplo, un rectángulo sin rotar en `(100, 200)` con tamaño `120 × 80` tiene límites de contorno `(100, 200)`–`(220, 280)`. No añadas la posición de la forma de nuevo. Resta su X y Y para obtener coordenadas relativas a su marco sin rotar.

Los puntos extraídos no aplican la rotación de la forma, devuelta por [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getRotation--), ni los giros horizontales y verticales. Para reproducir el contorno mostrado, aplica esas transformaciones alrededor del centro de la forma. Para formas agrupadas, también ten en cuenta el mapeo de coordenadas del grupo y sus transformaciones; no asumas que los puntos extraídos son las coordenadas finales renderizadas en la diapositiva ni apliques una traslación o escala dos veces si ya están reflejadas en el marco del hijo.

**Inspección frente a edición.** Las matrices extraídas describen el contorno; modificarlas no actualiza la forma original. Elige este enfoque cuando tu análisis o código de dibujo necesite matrices de punto/tipo. Usa [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) cuando necesites comandos de geometría en el sistema de coordenadas local de la forma o quieras editar su geometría. Aplica rutas editadas mediante [setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) o [setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---).

## **Convertir un Shape AWT de Java a GeometryPath**

Este ejemplo combina un contorno rectangular con texto convertido a geometría. El método [setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) del contorno desactiva su relleno. Un [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) crea el contorno del texto en un [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Su [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) suministra segmentos de movimiento, línea, cuadrática, cúbica y cierre, que el ejemplo reproduce en una [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/).

El texto usa una fuente Arial de 40 puntos. El contorno se desplaza 20 puntos horizontalmente y se posiciona con su parte superior visual 10 puntos bajo el borde superior de la forma. La ruta del texto se rellena, mientras que el rectángulo original permanece como contorno. Aplicar ambas rutas con [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) produce una única forma que contiene el rectángulo y el texto.

```java
import com.aspose.slides.*;
import java.awt.Font;
import java.awt.Graphics2D;
import java.awt.Shape;
import java.awt.font.GlyphVector;
import java.awt.font.FontRenderContext;
import java.awt.geom.Rectangle2D;
import java.awt.geom.PathIterator;
import java.awt.image.BufferedImage;

Presentation presentation = new Presentation();
try {
    // Crear nueva forma
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // Obtener la ruta de geometría de la forma
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // Crear nueva ruta gráfica con texto
    Shape graphicsPath;
    Font font = new Font("Arial", Font.PLAIN, 40);
    String text = "Text in shape";
    BufferedImage image = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
    Graphics2D graphics = image.createGraphics();

    try
    {
        FontRenderContext fontContext = graphics.getFontRenderContext();
        GlyphVector glyphVector = font.createGlyphVector(fontContext, text);
        Rectangle2D textBounds = glyphVector.getVisualBounds();
        float baseline = (float) -textBounds.getY() + 10;
        graphicsPath = glyphVector.getOutline(20f, baseline);
    }
    finally {
        graphics.dispose();
    }

    // Convertir ruta gráfica a ruta de geometría
    IGeometryPath textPath = new GeometryPath();
    PathIterator pathIterator = graphicsPath.getPathIterator(null);
    float[] points = new float[6];

    while (!pathIterator.isDone())
    {
        int segmentType = pathIterator.currentSegment(points);
        switch (segmentType)
        {
            case PathIterator.SEG_MOVETO:
                textPath.moveTo(points[0], points[1]);
                break;
            case PathIterator.SEG_LINETO:
                textPath.lineTo(points[0], points[1]);
                break;
            case PathIterator.SEG_QUADTO:
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case PathIterator.SEG_CUBICTO:
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case PathIterator.SEG_CLOSE:
                textPath.closeFigure();
                break;
        }
        pathIterator.next();
    }

    textPath.setFillMode(PathFillModeType.Normal);

    // Establecer la combinación de la nueva ruta de geometría y la ruta de geometría original en la forma
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**¿Qué ocurrirá con el relleno y el contorno después de reemplazar la geometría?**

El estilo permanece con la forma; solo cambia el contorno. El relleno y el contorno se aplican automáticamente a la nueva geometría.

**¿Cómo rotar correctamente una forma personalizada junto con su geometría?**

Utiliza el método [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setRotation-float-) de la forma; la geometría gira con la forma porque está vinculada al propio sistema de coordenadas de la forma.

**¿Puedo convertir una forma personalizada a una imagen para “bloquear” el resultado”?**

Sí. Exporta la [slide](/slides/es/java/convert-powerpoint-to-png/) o la [shape](/slides/es/java/create-shape-thumbnails/) a un formato raster; esto simplifica el trabajo posterior con geometrías complejas.