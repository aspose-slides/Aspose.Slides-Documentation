---
title: Personalizar formas de presentación en PHP
linktitle: Forma personalizada
type: docs
weight: 20
url: /es/php-java/custom-shape/
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
- esquina curva
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Crea y personaliza formas en presentaciones de PowerPoint con Aspose.Slides para PHP mediante Java: rutas de geometría, esquinas curvas, formas compuestas."
---
## **Resumen**

Este artículo explica cómo personalizar formas de presentación en Aspose.Slides editando la geometría de la forma mediante puntos de edición y rutas de geometría. Muestra cómo trabajar con [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) para modificar formas existentes, realizar operaciones básicas de edición de rutas, añadir o eliminar puntos y aplicar la geometría actualizada a una forma.

También demuestra cómo crear formas personalizadas y compuestas, construir formas con esquinas curvas, determinar si la geometría de una forma está cerrada, inspeccionar los elementos de la forma y convertir contornos de texto de Java AWT en rutas de geometría.

## **Cambiar una Forma mediante Puntos de Edición**

En PowerPoint, puedes usar **Puntos de edición** para modificar un cuadrado:

* Mover una esquina hacia adentro o hacia fuera.
* Ajustar la curvatura en un punto.
* Añadir nuevos puntos.

Editar puntos te permite modificar el contorno de una forma o usar una forma existente como base para una nueva.

## **Consejos para la Edición de Formas**

![overview_image](custom_shape_0.png)

Al editar formas en PowerPoint, ten en cuenta estos conceptos:

* Una forma (o su ruta) puede estar cerrada o abierta.
* La ruta de una forma consta de puntos de anclaje conectados por segmentos.
* Un segmento puede ser recto o curvo. Los puntos de anclaje y los manejadores de control determinan su forma.
* Los puntos de anclaje existen como puntos de esquina, puntos rectos o puntos suaves:
  * En un punto de esquina, los segmentos adyacentes pueden encontrarse en un ángulo.
  * En un punto suave, los dos manejadores de control están alineados y a la misma distancia del punto de anclaje.
  * En un punto recto, los dos manejadores de control están alineados pero pueden estar a diferentes distancias del punto de anclaje.
* Mover los puntos de anclaje o ajustar sus manejadores cambia el contorno de la forma.

Para editar formas de PowerPoint mediante puntos de edición, **Aspose.Slides** proporciona la clase [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

* Una instancia de [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) representa la ruta de geometría del objeto [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/).
* Para obtener el [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) del objeto [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/), puedes usar el método [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths).
* Para establecer el [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) de una forma, puedes usar estos métodos: [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) para formas con una única ruta y [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) para formas con múltiples rutas.
* Para añadir segmentos, puedes usar los métodos bajo [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).
* Mediante los métodos [GeometryPath::setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setStroke) y [GeometryPath::setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode), puedes establecer la apariencia de una ruta de geometría.
* Usando el método [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData), puedes obtener la ruta de geometría de un [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) como una matriz de segmentos de ruta.
* Para acceder a opciones adicionales de personalización de la geometría de la forma, puedes leer un [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) a través de su [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) y reproducir los segmentos en un [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

## **Operaciones de Edición Simples**

Utiliza los siguientes métodos para editar una ruta de geometría. Las sobrecargas que aceptan un índice insertan un segmento en esa posición basada en cero dentro de la matriz de segmentos de la ruta.

| Operación | Método |
| --- | --- |
| Añadir o insertar una línea recta. | [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) |
| Añadir o insertar una curva Bézier cúbica con dos puntos de control y un punto final. | [GeometryPath::cubicBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Añadir o insertar una curva Bézier cuadrática con un punto de control y un punto final. | [GeometryPath::quadraticBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Añadir un arco elíptico con las dimensiones y ángulos especificados en grados. | [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) |
| Cerrar la figura actual conectando su punto final con su punto de inicio. | [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) |
| Establecer el punto de inicio de una figura. | [GeometryPath::moveTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#moveTo) |
| Eliminar un segmento en un índice basado en cero. | [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) |

## **Añadir Puntos Personalizados a una Forma**

Este ejemplo inserta dos puntos en una forma rectangular usando [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) y aplica la ruta editada con [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath). Las coordenadas son locales a la forma: ambos puntos nuevos están en su centro, a 100 puntos del borde izquierdo y 50 puntos del borde superior. Los índices de segmento 1 y 4 los ubican en los bordes superior e inferior, tirando esos bordes hacia adentro.

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);

    $geometryPath = $shape->getGeometryPaths()[0];
    $geometryPath->lineTo(100, 50, 1);
    $geometryPath->lineTo(100, 50, 4);

    $shape->setGeometryPath($geometryPath);
} finally {
    $presentation->dispose();
}
```

![example1_image](custom_shape_1.png)

## **Eliminar Puntos de una Forma**

Este ejemplo modifica el contorno de una forma de corazón eliminando el segmento en el índice basado en cero 2 con [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt). Aplicar la ruta modificada con [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) actualiza el contorno de la forma.

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Heart, 100, 100, 300, 300);

    $path = $shape->getGeometryPaths()[0];
    $path->removeAt(2);

    $shape->setGeometryPath($path);
} finally {
    $presentation->dispose();
}
```
![example2_image](custom_shape_2.png)

## **Crear una Forma Personalizada**

Este ejemplo crea una estrella de cinco puntas con [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/). Los radios exteriores e interiores alternados de 100 y 50 puntos definen las puntas y las hendiduras; un paso de 72 grados separa uniformemente las cinco puntas. La ruta se cierra con [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) y se aplica a una forma rectangular mediante [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath), sustituyendo su contorno.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$points = [];
$outerRadius = 100;
$innerRadius = 50;
$angleStep = 72;
for ($angle = -90; $angle < 270; $angle += $angleStep) {
    $radians = deg2rad($angle);
    $points[] = [$outerRadius * cos($radians) + $outerRadius, $outerRadius * sin($radians) + $outerRadius];
    $radians = deg2rad($angle + $angleStep / 2);
    $points[] = [$innerRadius * cos($radians) + $outerRadius, $innerRadius * sin($radians) + $outerRadius];
}

$starPath = new GeometryPath();
$starPath->moveTo($points[0][0], $points[0][1]);
for ($i = 1; $i < count($points); $i++) {
    $starPath->lineTo($points[$i][0], $points[$i][1]);
}
$starPath->closeFigure();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, $outerRadius * 2, $outerRadius * 2);
    $shape->setGeometryPath($starPath);
} finally {
    $presentation->dispose();
}
```
![example3_image](custom_shape_3.png)

## **Crear una Forma Personalizada Compuesta**

Este ejemplo define dos objetos [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) cerrados para el tercio superior y el tercio inferior de una forma. Aplicar ambas rutas con [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) crea una única forma compuesta con una hueca en su tercio medio.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);

    $topPath = new GeometryPath();
    $topPath->moveTo(0, 0);
    $topPath->lineTo(java_values($shape->getWidth()), 0);
    $topPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()) / 3);
    $topPath->lineTo(0, java_values($shape->getHeight()) / 3);
    $topPath->closeFigure();

    $bottomPath = new GeometryPath();
    $bottomPath->moveTo(0, java_values($shape->getHeight()) / 3 * 2);
    $bottomPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()) / 3 * 2);
    $bottomPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()));
    $bottomPath->lineTo(0, java_values($shape->getHeight()));
    $bottomPath->closeFigure();

    $shape->setGeometryPaths([$topPath, $bottomPath]);
} finally {
    $presentation->dispose();
}
```
![example4_image](custom_shape_4.png)

## **Crear una Forma Personalizada con Esquinas Curvas**

Este ejemplo combina segmentos rectos con [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) para crear una forma con esquinas curvas hacia adentro. Cada tamaño de esquina define el ancho y la altura del arco en puntos, y el barrido de -90 grados dibuja un cuarto de elipse en sentido antihorario. La ruta completada se aplica con [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath), y la presentación se guarda en formato PPTX.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$shapeX = 20;
$shapeY = 20;
$shapeWidth = 300;
$shapeHeight = 200;

$leftTopSize = 50;
$rightTopSize = 20;
$rightBottomSize = 40;
$leftBottomSize = 10;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Custom, $shapeX, $shapeY, $shapeWidth, $shapeHeight);

    $topLeft = new Point2DFloat($leftTopSize, 0);
    $topRight = new Point2DFloat($shapeWidth - $rightTopSize, 0);
    $rightBottom = new Point2DFloat($shapeWidth, $shapeHeight - $rightBottomSize);
    $bottomLeft = new Point2DFloat($leftBottomSize, $shapeHeight);
    $leftTop = new Point2DFloat(0, $leftTopSize);

    $geometryPath = new GeometryPath();
    $geometryPath->moveTo($topLeft);
    $geometryPath->lineTo($topRight);
    $geometryPath->arcTo($rightTopSize, $rightTopSize, 180, -90);
    $geometryPath->lineTo($rightBottom);
    $geometryPath->arcTo($rightBottomSize, $rightBottomSize, -90, -90);
    $geometryPath->lineTo($bottomLeft);
    $geometryPath->arcTo($leftBottomSize, $leftBottomSize, 0, -90);
    $geometryPath->lineTo($leftTop);
    $geometryPath->arcTo($leftTopSize, $leftTopSize, 90, -90);
    $geometryPath->closeFigure();

    $shape->setGeometryPath($geometryPath);

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Descubrir si la Geometría de una Forma está Cerrada**

El siguiente auxiliar verifica si cada ruta de geometría no vacía termina con un segmento de cierre. Lee [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) y compara el [PathSegment::getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) del segmento final con [PathCommandType::Close](https://reference.aspose.com/slides/php-java/aspose.slides/pathcommandtype/). Devuelve false cuando no hay rutas no vacías. Esta comprobación examina el comando final de cada ruta; no inspecciona cada subfigura dentro de una ruta. El ejemplo muestra `true` para un rectángulo.

```php
use aspose\slides\PathCommandType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

function isGeometryClosed($geometryShape)
{
    $hasNonemptyPath = false;
    foreach ($geometryShape->getGeometryPaths() as $geometryPath) {
        $segments = java_values($geometryPath->getPathData());
        if (count($segments) === 0) {
            continue;
        }
        $hasNonemptyPath = true;
        $lastSegment = $segments[count($segments) - 1];
        if (java_values($lastSegment->getPathCommand()) !== PathCommandType::Close) {
            return false;
        }
    }
    return $hasNonemptyPath;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $closed = isGeometryClosed($shape);
    echo ($closed ? "true" : "false") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Inspeccionar los Comandos de la Ruta de Geometría**

Descarga [contour.pptx](contour.pptx) y colócalo en el directorio de trabajo de la aplicación. La primera forma de la primera diapositiva tiene un borde superior recto, una curva Bézier cúbica y un borde de cierre recto. Usa [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) para leer las rutas de la forma y [getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) para leer los segmentos de cada ruta en orden de dibujo. Para cada segmento, [getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) identifica el comando y determina cómo interpretar los valores devueltos por [getSegmentData](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getSegmentData).

```php
use aspose\slides\PathCommandType;
use aspose\slides\Presentation;

$presentation = new Presentation("contour.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    foreach ($shape->getGeometryPaths() as $pathIndex => $path) {
        foreach ($path->getPathData() as $segmentIndex => $segment) {
            $command = java_values($segment->getPathCommand());
            $data = java_values($segment->getSegmentData());
            switch ($command) {
                case PathCommandType::MoveTo:
                case PathCommandType::LineTo:
                    $name = $command === PathCommandType::MoveTo ? "MoveTo" : "LineTo";
                    $detail = sprintf("destination=(%s, %s)", ...$data);
                    break;
                case PathCommandType::CubicBezierTo:
                    $name = "CubicBezierTo";
                    $detail = sprintf("control1=(%s, %s) control2=(%s, %s) end=(%s, %s)", ...$data);
                    break;
                case PathCommandType::Close:
                    $name = "Close";
                    $detail = "no coordinates";
                    break;
                default:
                    $name = "Command " . $command;
                    $detail = "raw=" . json_encode($data);
            }
            printf("Path %d, segment %d: %s %s\n", $pathIndex, $segmentIndex, $name, $detail);
        }
    }
} finally {
    $presentation->dispose();
}
```

La forma está situada en (200, 100) puntos sobre la diapositiva. Las coordenadas informadas son locales a la forma, con (0, 0) en su esquina superior izquierda, x aumentando hacia la derecha e y aumentando hacia abajo. El segmento de cierre vuelve al punto de inicio sin coordenadas adicionales.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **Extraer e Inspeccionar los Elementos de la Forma**

Utiliza [GeometryShape::createShapeElements](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#createShapeElements) para inspeccionar una forma existente como elementos que contienen puntos de ruta y tipos de punto. Usa cada [ShapeElement](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/) devuelto para obtener las matrices de puntos y tipos mediante los métodos [getPathPoints](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathPoints) y [getPathTypes](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathTypes). Esta representación es útil para análisis de contornos o para pasar la geometría a herramientas de dibujo personalizadas.

El ejemplo abre input.pptx, encuentra la primera forma de geometría directamente en la primera diapositiva y muestra sus segmentos de ruta. Usa una presentación que contenga una forma con segmentos rectos y curvos para ver ambos tipos de salida. No busca dentro de grupos.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = null;
    $shapes = $slide->getShapes();
    for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
        $candidate = $shapes->get_Item($shapeIndex);
        if (java_instanceof($candidate, java("com.aspose.slides.GeometryShape"))) {
            $shape = $candidate;
            break;
        }
    }

    if ($shape === null) {
        echo "No geometry shape found on the first slide." . PHP_EOL;
    } else {
        foreach ($shape->createShapeElements() as $element) {
            $points = java_values($element->getPathPoints());
            $types = array_values(unpack("C*", java_values($element->getPathTypes())));
            echo "Shape element:" . PHP_EOL;
            for ($i = 0; $i < count($points); $i++) {
                $pointType = $types[$i] & 0x07; // Mantener el tipo de segmento, excluyendo las banderas.
                switch ($pointType) {
                    case 0:
                        echo "Start figure at " . $points[$i] . PHP_EOL;
                        break;
                    case 1:
                        echo "Line to " . $points[$i] . PHP_EOL;
                        break;
                    case 3:
                        echo "Cubic Bezier: controls " . $points[$i] . ", " . $points[$i + 1] . "; end " . $points[$i + 2] . PHP_EOL;
                        $i += 2; // Consumir ambos puntos de control y el punto final.
                        break;
                }
                if (($types[$i] & 0x80) !== 0) {
                    echo "Close subpath back to its starting point." . PHP_EOL;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Las matrices corresponden por índice: `$points[$i]` es un punto y `$types[$i]` describe su papel. El tipo `0` inicia una figura, y el tipo `1` dibuja una línea desde el punto anterior al punto actual. Un segmento Bézier cúbico comienza en el punto final anterior y utiliza tres entradas consecutivas de tipo `3`: dos puntos de control seguidos del nuevo punto final. El bucle consume esas tres entradas juntas y verifica el punto final para saber si la subruta está cerrada.

Los tipos de punto también contienen banderas. Enmascara con `0x07` para identificar el tipo de segmento, y prueba `0x80` por separado para detectar una subruta cerrada. Por ejemplo, `129` (`0x81`) significa un punto final de línea que cierra una subruta, y `131` (`0x83`) significa un punto final Bézier que cierra una. El puente PHP/Java devuelve la matriz de bytes como una cadena binaria; desempaquetarla con `"C*"` produce valores de byte sin signo. Enmascarar preserva los valores de bits previstos. Comparar el valor bruto solo con `1` o `3` omitirá estos casos. Otras banderas, como la de guión (`0x10`) y marcador (`0x20`), no cambian el tipo base del segmento.

**Coordenadas y transformaciones.** Los puntos se miden en puntos (1/72 de pulgada), con X aumentando a la derecha e Y aumentando hacia abajo. Para una forma no agrupada, las coordenadas extraídas ya incluyen la posición devuelta por [getX](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getX) y [getY](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getY) y reflejan su ancho y alto actuales. Por ejemplo, un rectángulo sin rotación en `(100, 200)` con tamaño `120 × 80` tiene límites de contorno `(100, 200)`–`(220, 280)`. No añadas la posición de la forma de nuevo. Resta su X e Y para obtener coordenadas relativas a su marco sin rotar.

Los puntos extraídos no aplican la rotación de la forma, devuelta por [getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getRotation), ni los volteos horizontal y vertical. Para reproducir el contorno mostrado, aplica esas transformaciones alrededor del centro de la forma. Para formas agrupadas, también ten en cuenta el mapeo de coordenadas del grupo y sus transformaciones; no asumas que los puntos extraídos son las coordenadas finales rendereadas en la diapositiva ni apliques una traslación o escala dos veces si ya están reflejadas en el marco del hijo.

**Inspección versus edición.** Las matrices extraídas describen el contorno; modificarlas no actualiza la forma original. Elige este enfoque cuando tu código de análisis o dibujo necesite matrices de punto/tipo. Usa [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) cuando necesites comandos de geometría en el sistema de coordenadas local de la forma o quieras editar su geometría. Aplica rutas editadas a través de [setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) o [setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Convertir una Forma Java AWT a GeometryPath**

Este ejemplo combina un contorno rectangular con texto convertido a geometría. El método [setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) del contorno desactiva su relleno. Un [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) crea el contorno del texto en un [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Su [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) suministra segmentos de movimiento, línea, cuadrático, cúbico y cierre, que el ejemplo reproduce en un [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

El ejemplo usa una matriz de float de Java para que el puente PHP/Java conserve las coordenadas escritas por el iterador. El texto usa una fuente Arial de 40 puntos. El contorno se desplaza 20 puntos horizontalmente y se posiciona con su parte visual superior 10 puntos bajo el borde superior de la forma. La ruta del texto se rellena, mientras que el rectángulo original permanece como contorno. Aplicar ambas rutas con [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) produce una única forma que contiene el rectángulo y el texto.

```php
use aspose\slides\GeometryPath;
use aspose\slides\PathFillModeType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);

    $fontClass = java("java.awt.Font");
    $imageClass = java("java.awt.image.BufferedImage");
    $font = new Java("java.awt.Font", "Arial", $fontClass->PLAIN, 40);
    $image = new Java("java.awt.image.BufferedImage", 100, 100, $imageClass->TYPE_INT_ARGB);
    $graphics = $image->createGraphics();
    try {
        $fontContext = $graphics->getFontRenderContext();
        $glyphVector = $font->createGlyphVector($fontContext, "Text in shape");
        $textBounds = $glyphVector->getVisualBounds();
        $baseline = -java_values($textBounds->getY()) + 10;
        $graphicsPath = $glyphVector->getOutline(20.0, $baseline);
    } finally {
        $graphics->dispose();
    }

    $textPath = new GeometryPath();
    $pathIterator = $graphicsPath->getPathIterator(null);
    $iteratorClass = java("java.awt.geom.PathIterator");
    $arrayClass = java("java.lang.reflect.Array");
    $floatClass = java("java.lang.Float");
    $coordinates = $arrayClass->newInstance($floatClass->TYPE, 6);

    while (!java_values($pathIterator->isDone())) {
        $segmentType = java_values($pathIterator->currentSegment($coordinates));
        $points = java_values($coordinates);
        switch ($segmentType) {
            case java_values($iteratorClass->SEG_MOVETO):
                $textPath->moveTo($points[0], $points[1]);
                break;
            case java_values($iteratorClass->SEG_LINETO):
                $textPath->lineTo($points[0], $points[1]);
                break;
            case java_values($iteratorClass->SEG_QUADTO):
                $textPath->quadraticBezierTo($points[0], $points[1], $points[2], $points[3]);
                break;
            case java_values($iteratorClass->SEG_CUBICTO):
                $textPath->cubicBezierTo($points[0], $points[1], $points[2], $points[3], $points[4], $points[5]);
                break;
            case java_values($iteratorClass->SEG_CLOSE):
                $textPath->closeFigure();
                break;
        }
        $pathIterator->next();
    }
    $textPath->setFillMode(PathFillModeType::Normal);
    $shape->setGeometryPaths([$originalPath, $textPath]);
} finally {
    $presentation->dispose();
}
```
![example5_image](custom_shape_5.png)

## **Preguntas Frecuentes**

**¿Qué ocurrirá con el relleno y el contorno después de sustituir la geometría?**

El estilo permanece asociado a la forma; solo cambia el contorno. El relleno y el contorno se aplican automáticamente a la nueva geometría.

**¿Cómo roto correctamente una forma personalizada junto con su geometría?**

Usa el método [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) de la forma; la geometría gira con la forma porque está vinculada al propio sistema de coordenadas de la forma.

**¿Puedo convertir una forma personalizada en una imagen para “bloquear” el resultado”?**

Sí. Exporta la zona de la [diapositiva](/slides/es/php-java/convert-powerpoint-to-png/) requerida o la [forma](/slides/es/php-java/create-shape-thumbnails/) misma a un formato raster; esto simplifica el trabajo posterior con geometrías complejas.