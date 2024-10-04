---
title: Forma Personalizada
type: docs
weight: 20
url: /php-java/custom-shape/
keywords: "forma de PowerPoint, forma personalizada, presentación de PowerPoint, Java, Aspose.Slides para PHP a través de Java"
description: "Agregar forma personalizada en la presentación de PowerPoint"
---

# Cambiar una Forma Usando Puntos de Edición
Considera un cuadrado. En PowerPoint, usando **puntos de edición**, puedes 

* mover la esquina del cuadrado hacia adentro o hacia afuera
* especificar la curvatura para una esquina o punto
* agregar nuevos puntos al cuadrado
* manipular puntos en el cuadrado, etc.

Esencialmente, puedes realizar las tareas descritas en cualquier forma. Usando puntos de edición, puedes cambiar una forma o crear una nueva forma a partir de una forma existente.

## **Consejos para Editar Formas**

![overview_image](custom_shape_0.png)

Antes de comenzar a editar formas de PowerPoint a través de puntos de edición, es posible que desees considerar estos puntos sobre las formas:

* Una forma (o su trayectoria) puede ser cerrada o abierta.
* Cuando una forma está cerrada, carece de un punto de inicio o fin. Cuando una forma está abierta, tiene un comienzo y un final.
* Todas las formas constan de al menos 2 puntos ancla vinculados entre sí por líneas.
* Una línea es recta o curva. Los puntos ancla determinan la naturaleza de la línea.
* Los puntos ancla existen como puntos de esquina, puntos rectos o puntos suaves:
  * Un punto de esquina es un punto donde 2 líneas rectas se unen en un ángulo.
  * Un punto suave es un punto donde 2 mangos existen en línea recta y los segmentos de la línea se unen en una curva suave. En este caso, todos los mangos están separados del punto ancla por una distancia igual.
  * Un punto recto es un punto donde 2 mangos existen en línea recta y los segmentos de línea de esa línea se unen en una curva suave. En este caso, los mangos no tienen que estar separados del punto ancla por una distancia igual.
* Al mover o editar puntos ancla (lo que cambia el ángulo de las líneas), puedes cambiar la apariencia de una forma.

Para editar formas de PowerPoint a través de puntos de edición, **Aspose.Slides** proporciona la clase [**GeometryPath**](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) y la interfaz [**IGeometryPath**](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath).

* Una instancia de [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) representa una trayectoria geométrica del objeto [IGeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape).
* Para recuperar el `GeometryPath` de la instancia `IGeometryShape`, puedes usar el método [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#getGeometryPaths--).
* Para establecer el `GeometryPath` para una forma, puedes utilizar estos métodos: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) para *formas sólidas* y [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) para *formas compuestas*.
* Para agregar segmentos, puedes usar los métodos bajo [IGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath).
* Utilizando los métodos [IGeometryPath.setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath#setStroke-boolean-) y [IGeometryPath.setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath#setFillMode-byte-), puedes establecer la apariencia de una trayectoria geométrica.
* Usando el método [IGeometryPath.getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath#getPathData--) puedes recuperar la trayectoria geométrica de una `GeometryShape` como un arreglo de segmentos de trayectoria.
* Para acceder a opciones adicionales de personalización de geometría de la forma, puedes convertir [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) a [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html).
* Usa [geometryPathToGraphicsPath](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) y [graphicsPathToGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (de la clase [ShapeUtil](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil)) para convertir [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) a [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) y viceversa.

## **Operaciones de Edición Simples**

Este código PHP te muestra cómo

**Agregar una línea** al final de una trayectoria

```php

```
**Agregar una línea** a una posición especificada en una trayectoria:

```php

```
**Agregar una curva Bezier cúbica** al final de una trayectoria:

```php

```
**Agregar una curva Bezier cúbica** a la posición especificada en una trayectoria:

```php

```
**Agregar una curva Bezier cuadrática** al final de una trayectoria:

```php

```
**Agregar curva Bezier cuadrática** a una posición especificada en una trayectoria:

```php

```
**Agregar un arco dado** a una trayectoria:

```php

```
**Cerrar la figura actual** de una trayectoria:

```php

```
**Establecer la posición para el siguiente punto**:

```php

```
**Eliminar el segmento de la trayectoria** en un índice dado:

```php

```

## **Agregar Puntos Personalizados a la Forma**
1. Crea una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) y establece el tipo [ShapeType::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType).
2. Obtén una instancia de la clase [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) de la forma.
3. Agrega un nuevo punto entre los dos puntos superiores en la trayectoria.
4. Agrega un nuevo punto entre los dos puntos inferiores en la trayectoria.
5. Aplica la trayectoria a la forma.

Este código PHP te muestra cómo agregar puntos personalizados a una forma:

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
![example1_image](custom_shape_1.png)

##  Eliminar Puntos de la Forma

1. Crea una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) y establece el tipo [ShapeType::Heart](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType).
2. Obtén una instancia de la clase [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) de la forma.
3. Elimina el segmento de la trayectoria.
4. Aplica la trayectoria a la forma.

Este código PHP te muestra cómo eliminar puntos de una forma:

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
![example2_image](custom_shape_2.png)

##  **Crear Forma Personalizada**

1. Calcula los puntos para la forma.
2. Crea una instancia de la clase [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath).
3. Llena la trayectoria con los puntos.
4. Crea una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape).
5. Aplica la trayectoria a la forma.

Este Java te muestra cómo crear una forma personalizada:

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
![example3_image](custom_shape_3.png)

## **Crear Forma Personalizada Compuesta**

1. Crea una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape).
2. Crea una primera instancia de la clase [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath).
3. Crea una segunda instancia de la clase [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath).
4. Aplica las trayectorias a la forma.

Este código PHP te muestra cómo crear una forma personalizada compuesta:

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
![example4_image](custom_shape_4.png)

## **Crear Forma Personalizada Con Esquinas Curvas**

Este código PHP te muestra cómo crear una forma personalizada con esquinas curvas (hacia adentro);

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

## **Convertir GeometryPath a java.awt.Shape**

1. Crea una instancia de la clase [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape).
2. Crea una instancia de la clase [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html).
3. Convierte la instancia de [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) a la instancia de [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) usando [ShapeUtil](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil).
4. Aplica las trayectorias a la forma.

Este código PHP—una implementación de los pasos anteriores—demuestra el proceso de conversión de **GeometryPath** a **GraphicsPath**:

```php
  $pres = new Presentation();
  try {
    # Crear nueva forma
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    # Obtener trayectoria geométrica de la forma
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);
    # Crear nueva trayectoria gráfica con texto
    $graphicsPath;
    $font = new Font("Arial", Font->PLAIN, 40);
    $text = "Texto en forma";
    $img = new BufferedImage(100, 100, BufferedImage->TYPE_INT_ARGB);
    $g2 = $img->createGraphics();
    try {
      $glyphVector = $font->createGlyphVector($g2->getFontRenderContext(), $text);
      $graphicsPath = $glyphVector->getOutline(20.0, -$glyphVector->getVisualBounds()->getY() + 10);
    } finally {
      $g2->dispose();
    }
    # Convertir trayectoria gráfica a trayectoria geométrica
    $textPath = ShapeUtil->graphicsPathToGeometryPath($graphicsPath);
    $textPath->setFillMode(PathFillModeType::Normal);
    # Establecer la combinación de la nueva trayectoria geométrica y la trayectoria geométrica original a la forma
    $shape->setGeometryPaths(array($originalPath, $textPath ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example5_image](custom_shape_5.png)