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

## **Cambiar una forma usando puntos de edición**
Considera un cuadrado. En PowerPoint, usando **puntos de edición**, puedes 

* mover la esquina del cuadrado hacia dentro o fuera
* especificar la curvatura de una esquina o punto
* añadir nuevos puntos al cuadrado
* manipular los puntos del cuadrado, etc. 

Esencialmente, puedes realizar las tareas descritas en cualquier forma. Usando puntos de edición, puedes cambiar una forma o crear una nueva forma a partir de una forma existente. 

## **Consejos para editar formas**

![imagen_resumen](custom_shape_0.png)

Antes de comenzar a editar formas de PowerPoint mediante puntos de edición, puede que quieras considerar estos aspectos sobre las formas:

* Una forma (o su ruta) puede estar cerrada o abierta.
* Cuando una forma está cerrada, no tiene punto de inicio ni de fin. Cuando una forma está abierta, tiene un inicio y un final. 
* Todas las formas constan de al menos 2 puntos de anclaje vinculados entre sí por líneas
* Una línea es recta o curva. Los puntos de anclaje determinan la naturaleza de la línea. 
* Los puntos de anclaje pueden ser puntos de esquina, puntos rectos o puntos suaves:
  * Un punto de esquina es un punto donde se unen 2 líneas rectas formando un ángulo. 
  * Un punto suave es un punto donde existen 2 manejadores en una línea recta y los segmentos de la línea se unen en una curva suave. En este caso, todos los manejadores están separados del punto de anclaje a una distancia igual. 
  * Un punto recto es un punto donde existen 2 manejadores en una línea recta y los segmentos de esa línea se unen en una curva suave. En este caso, los manejadores no tienen que estar separados del punto de anclaje a una distancia igual. 
* Al mover o editar los puntos de anclaje (lo que cambia el ángulo de las líneas), puedes modificar la apariencia de una forma. 

Para editar formas de PowerPoint mediante puntos de edición, **Aspose.Slides** proporciona la clase [**GeometryPath**](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) y la interfaz [**IGeometryPath**](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath).

* Una instancia de [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) representa una ruta geométrica del objeto [IGeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape).
* Para recuperar el`GeometryPath` de la instancia `IGeometryShape`, puedes usar el método [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#getGeometryPaths--).
* Para establecer el `GeometryPath` de una forma, puedes usar estos métodos: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) para *formas sólidas* y [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) para *formas compuestas*.
* Para añadir segmentos, puedes usar los métodos de [IGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath).
* Usando los métodos [IGeometryPath.setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath#setStroke-boolean-) y [IGeometryPath.setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath#setFillMode-byte-), puedes establecer la apariencia de una ruta geométrica.
* Con el método [IGeometryPath.getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath#getPathData--) puedes obtener la ruta geométrica de un `GeometryShape` como una matriz de segmentos de ruta.
* Para acceder a opciones adicionales de personalización de la geometría de la forma, puedes convertir [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) a [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html)
* Utiliza los métodos [geometryPathToGraphicsPath](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) y [graphicsPathToGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (de la clase [ShapeUtil](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil)) para convertir [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) a [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) y viceversa.

## **Operaciones de edición simples**

Este código PHP muestra cómo

**Añadir una línea** al final de una ruta
```php

```

**Añadir una línea** a una posición especificada en una ruta:
```php

```

**Añadir una curva Bézier cúbica** al final de una ruta:
```php

```

**Añadir una curva Bézier cúbica** a la posición especificada en una ruta:
```php
```

**Añadir una curva Bézier cuadrática** al final de una ruta:
```php

```

**Añadir una curva Bézier cuadrática** a la posición especificada en una ruta:
```php

```

**Añadir un arco dado** a una ruta:
```php

```

**Cerrar la figura actual** de una ruta:
```php

```

**Establecer la posición del siguiente punto**:
```php

```

**Eliminar el segmento de ruta** en un índice dado:
```php

```


## **Añadir puntos personalizados a una forma**
1. Crea una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) y establece el tipo [ShapeType::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType).
2. Obtén una instancia de la clase [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) a partir de la forma.
3. Añade un nuevo punto entre los dos puntos superiores de la ruta.
4. Añade un nuevo punto entre los dos puntos inferiores de la ruta.
5. Aplica la ruta a la forma.

Este código PHP muestra cómo añadir puntos personalizados a una forma:
```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $geometryPath = $shape->getGeometryPaths()[0];
    $geometryPath->lineTo(100, 50, 1);
    $geometryPath->lineTo(100, 50, 4);
    $shape->setGeometryPath($geometryPath);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![ejemplo1_imagen](custom_shape_1.png)

## **Eliminar puntos de una forma**

1. Crea una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) y establece el tipo [ShapeType::Heart](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType).
2. Obtén una instancia de la clase [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) a partir de la forma.
3. Elimina el segmento de la ruta.
4. Aplica la ruta a la forma.

Este código PHP muestra cómo eliminar puntos de una forma:
```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Heart, 100, 100, 300, 300);
    $path = $shape->getGeometryPaths()[0];
    $path->removeAt(2);
    $shape->setGeometryPath($path);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![ejemplo2_imagen](custom_shape_2.png)

## **Crear una forma personalizada**

1. Calcula los puntos para la forma.
2. Crea una instancia de la clase [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath).
3. Rellena la ruta con los puntos.
4. Crea una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape).
5. Aplica la ruta a la forma.

Este código Java muestra cómo crear una forma personalizada:
```php
  $points = new Java("java.util.ArrayList");
  $R = 100;
  $r = 50;
  $step = 72;
  for($angle = -90; $angle < 270; $angle += $step) {
    $radians = $angle * java("java.lang.Math")->PI / 180.0;
    $x = $R * java("java.lang.Math")->cos($radians);
    $y = $R * java("java.lang.Math")->sin($radians);
    $points->add(new Point2DFloat($x + $R, $y + $R));
    $radians = java("java.lang.Math")->PI * $angle . $step / 2 / 180.0;
    $x = $r * java("java.lang.Math")->cos($radians);
    $y = $r * java("java.lang.Math")->sin($radians);
    $points->add(new Point2DFloat($x + $R, $y + $R));
  }
  $starPath = new GeometryPath();
  $starPath->moveTo($points->get(0));
  for($i = 1; $i < java_values($points->size()) ; $i++) {
    $starPath->lineTo($points->get($i));
  }
  $starPath->closeFigure();
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, $R * 2, $R * 2);
    $shape->setGeometryPath($starPath);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![ejemplo3_imagen](custom_shape_3.png)


## **Crear una forma personalizada compuesta**

1. Crea una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape).
2. Crea una primera instancia de la clase [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath).
3. Crea una segunda instancia de la clase [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath).
4. Aplica las rutas a la forma.

Este código PHP muestra cómo crear una forma personalizada compuesta:
```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $geometryPath0 = new GeometryPath();
    $geometryPath0->moveTo(0, 0);
    $geometryPath0->lineTo($shape->getWidth(), 0);
    $geometryPath0->lineTo($shape->getWidth(), $shape->getHeight() / 3);
    $geometryPath0->lineTo(0, $shape->getHeight() / 3);
    $geometryPath0->closeFigure();
    $geometryPath1 = new GeometryPath();
    $geometryPath1->moveTo(0, $shape->getHeight() / 3 * 2);
    $geometryPath1->lineTo($shape->getWidth(), $shape->getHeight() / 3 * 2);
    $geometryPath1->lineTo($shape->getWidth(), $shape->getHeight());
    $geometryPath1->lineTo(0, $shape->getHeight());
    $geometryPath1->closeFigure();
    $shape->setGeometryPaths(array($geometryPath0, $geometryPath1 ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![ejemplo4_imagen](custom_shape_4.png)

## **Crear una forma personalizada con esquinas curvas**

Este código PHP muestra cómo crear una forma personalizada con esquinas curvas (hacia adentro);
```php
  $shapeX = 20.0;
  $shapeY = 20.0;
  $shapeWidth = 300.0;
  $shapeHeight = 200.0;
  $leftTopSize = 50.0;
  $rightTopSize = 20.0;
  $rightBottomSize = 40.0;
  $leftBottomSize = 10.0;
  $pres = new Presentation();
  try {
    $childShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Custom, $shapeX, $shapeY, $shapeWidth, $shapeHeight);
    $geometryPath = new GeometryPath();
    $point1 = new Point2DFloat($leftTopSize, 0);
    $point2 = new Point2DFloat($shapeWidth - $rightTopSize, 0);
    $point3 = new Point2DFloat($shapeWidth, $shapeHeight - $rightBottomSize);
    $point4 = new Point2DFloat($leftBottomSize, $shapeHeight);
    $point5 = new Point2DFloat(0, $leftTopSize);
    $geometryPath->moveTo($point1);
    $geometryPath->lineTo($point2);
    $geometryPath->arcTo($rightTopSize, $rightTopSize, 180, -90);
    $geometryPath->lineTo($point3);
    $geometryPath->arcTo($rightBottomSize, $rightBottomSize, -90, -90);
    $geometryPath->lineTo($point4);
    $geometryPath->arcTo($leftBottomSize, $leftBottomSize, 0, -90);
    $geometryPath->lineTo($point5);
    $geometryPath->arcTo($leftTopSize, $leftTopSize, 90, -90);
    $geometryPath->closeFigure();
    $childShape->setGeometryPath($geometryPath);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Descubrir si la geometría de una forma está cerrada**

Una forma cerrada se define como aquella en la que todos sus lados se conectan, formando un único contorno sin huecos. Esa forma puede ser una forma geométrica simple o un contorno personalizado complejo. El siguiente ejemplo de código muestra cómo comprobar si la geometría de una forma está cerrada:
```php
function isGeometryClosed($geometryShape)
{
    $isClosed = null;

    foreach ($geometryShape->getGeometryPaths() as $geometryPath) {
        $dataLength = count(java_values($geometryPath->getPathData()));
        if ($dataLength === 0) {
            continue;
        }

        $lastSegment = java_values($geometryPath->getPathData())[$dataLength - 1];
        $isClosed = $lastSegment->getPathCommand() === PathCommandType::Close;

        if ($isClosed === false) {
            return false;
        }
    }

    return $isClosed === true;
}
```


## **Convertir GeometryPath a java.awt.Shape** 

1. Crea una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape).
2. Crea una instancia de la clase [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html).
3. Convierte la instancia de [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) a la instancia de [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) utilizando [ShapeUtil](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil).
4. Aplica las rutas a la forma.

Este código PHP—una implementación de los pasos anteriores—demuestra el proceso de conversión de **GeometryPath** a **GraphicsPath**:
```php
  $pres = new Presentation();
  try {
    # Crear nueva forma
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    # Obtener la ruta de geometría de la forma
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);
    # Crear nueva ruta gráfica con texto
    $graphicsPath;
    $font = new Font("Arial", Font->PLAIN, 40);
    $text = "Text in shape";
    $img = new BufferedImage(100, 100, BufferedImage->TYPE_INT_ARGB);
    $g2 = $img->createGraphics();
    try {
      $glyphVector = $font->createGlyphVector($g2->getFontRenderContext(), $text);
      $graphicsPath = $glyphVector->getOutline(20.0, -$glyphVector->getVisualBounds()->getY() + 10);
    } finally {
      $g2->dispose();
    }
    # Convertir la ruta gráfica a ruta de geometría
    $textPath = ShapeUtil->graphicsPathToGeometryPath($graphicsPath);
    $textPath->setFillMode(PathFillModeType::Normal);
    # Establecer la combinación de la nueva ruta de geometría y la ruta de geometría original en la forma
    $shape->setGeometryPaths(array($originalPath, $textPath ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![ejemplo5_imagen](custom_shape_5.png)

## **Preguntas frecuentes**

**¿Qué ocurrirá con el relleno y el contorno después de reemplazar la geometría?**

El estilo permanece con la forma; solo cambia el contorno. El relleno y el contorno se aplican automáticamente a la nueva geometría.

**¿Cómo rotar correctamente una forma personalizada junto con su geometría?**

Utiliza el método [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setrotation/) de la forma; la geometría rota con la forma porque está vinculada al propio sistema de coordenadas de la forma.

**¿Puedo convertir una forma personalizada a una imagen para "bloquear" el resultado?**

Sí. Exporta el área de la [diapositiva](/slides/es/php-java/convert-powerpoint-to-png/) requerida o la propia [forma](/slides/es/php-java/create-shape-thumbnails/) a un formato raster; esto simplifica el trabajo posterior con geometrías complejas.