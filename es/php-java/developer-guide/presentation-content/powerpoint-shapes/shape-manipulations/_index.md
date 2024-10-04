---
title: Manipulaciones de Formas
type: docs
weight: 40
url: /php-java/shape-manipulations/
---

## **Encontrar Forma en Diapositiva**
Este tema describirá una técnica simple para facilitar a los desarrolladores encontrar una forma específica en una diapositiva sin usar su Id interno. Es importante saber que los archivos de presentación de PowerPoint no tienen ninguna forma de identificar las formas en una diapositiva, excepto un Id único interno. Parece ser difícil para los desarrolladores encontrar una forma usando su Id único interno. Todas las formas añadidas a las diapositivas tienen algún Texto Alternativo. Sugerimos a los desarrolladores utilizar texto alternativo para encontrar una forma específica. Puede usar MS PowerPoint para definir el texto alternativo para objetos que planea cambiar en el futuro.

Después de establecer el texto alternativo de cualquier forma deseada, puede abrir esa presentación usando Aspose.Slides para PHP a través de Java e iterar a través de todas las formas añadidas a una diapositiva. Durante cada iteración, puede verificar el texto alternativo de la forma y la forma con el texto alternativo coincidente sería la forma que necesita. Para demostrar mejor esta técnica, hemos creado un método, [findShape](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-), que hace el truco para encontrar una forma específica en una diapositiva y luego simplemente devuelve esa forma.

```php
  # Instanciar una clase de Presentación que representa el archivo de presentación
  $pres = new Presentation("FindingShapeInSlide.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Texto alternativo de la forma a encontrar
    $shape = findShape($slide, "Shape1");
    if (!java_is_null($shape)) {
      echo("Nombre de la Forma: " . $shape->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Clonar Forma**
Para clonar una forma en una diapositiva utilizando Aspose.Slides para PHP a través de Java:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtenga la referencia de una diapositiva utilizando su índice.
1. Acceda a la colección de formas de la diapositiva fuente.
1. Agregue una nueva diapositiva a la presentación.
1. Clone las formas de la colección de formas de la diapositiva fuente a la nueva diapositiva.
1. Guarde la presentación modificada como un archivo PPTX.

El ejemplo a continuación agrega una forma de grupo a una diapositiva.

```php
  # Instanciar clase de Presentación
  $pres = new Presentation("Source Frame.pptx");
  try {
    $sourceShapes = $pres->getSlides()->get_Item(0)->getShapes();
    $blankLayout = $pres->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destSlide = $pres->getSlides()->addEmptySlide($blankLayout);
    $destShapes = $destSlide->getShapes();
    $destShapes->addClone($sourceShapes->get_Item(1), 50, 150 + $sourceShapes->get_Item(0)->getHeight());
    $destShapes->addClone($sourceShapes->get_Item(2));
    $destShapes->insertClone(0, $sourceShapes->get_Item(0), 50, 150);
    # Escribir el archivo PPTX en el disco
    $pres->save("CloneShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Eliminar Forma**
Aspose.Slides para PHP a través de Java permite a los desarrolladores eliminar cualquier forma. Para eliminar la forma de cualquier diapositiva, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Acceda a la primera diapositiva.
1. Encuentre la forma con un AlternativeText específico.
1. Elimine la forma.
1. Guarde el archivo en el disco.

```php
  # Crear objeto Presentación
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Agregar autoshape de tipo rectángulo
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $altText = "Definido por el Usuario";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item(0);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $sld->getShapes()->remove($ashp);
      }
    }
    # Guardar presentación en el disco
    $pres->save("RemoveShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ocultar Forma**
Aspose.Slides para PHP a través de Java permite a los desarrolladores ocultar cualquier forma. Para ocultar la forma de cualquier diapositiva, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Acceda a la primera diapositiva.
1. Encuentre la forma con un AlternativeText específico.
1. Oculte la forma.
1. Guarde el archivo en el disco.

```php
  # Instanciar clase de Presentación que representa el PPTX
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Agregar autoshape de tipo rectángulo
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $alttext = "Definido por el Usuario";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item($i);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $ashp->setHidden(true);
      }
    }
    # Guardar presentación en el disco
    $pres->save("Hiding_Shapes_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Cambiar Orden de Formas**
Aspose.Slides para PHP a través de Java permite a los desarrolladores reordenar las formas. Reordenar la forma especifica qué forma está al frente o cuál está al fondo. Para reordenar la forma de cualquier diapositiva, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Acceda a la primera diapositiva.
1. Agregue una forma.
1. Agregue algo de texto en el marco de texto de la forma.
1. Agregue otra forma con las mismas coordenadas.
1. Reordene las formas.
1. Guarde el archivo en el disco.

```php
  $pres = new Presentation("ChangeShapeOrder.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 365, 400, 150);
    $shp3->getFillFormat()->setFillType(FillType::NoFill);
    $shp3->addTextFrame(" ");
    $para = $shp3->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Texto de Marca de Agua Texto de Marca de Agua Texto de Marca de Agua");
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 200, 365, 400, 150);
    $slide->getShapes()->reorder(2, $shp3);
    $pres->save("Reshape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Obtener ID de Forma Interoperable**
Aspose.Slides para PHP a través de Java permite a los desarrolladores obtener un identificador de forma único en el ámbito de la diapositiva en contraste con el método [getUniqueId](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getUniqueId--), que permite obtener un identificador único en el ámbito de la presentación. El método [getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getOfficeInteropShapeId--) fue agregado a las interfaces [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) y [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/Shape) respectivamente. El valor que devuelve el método [getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getOfficeInteropShapeId--) corresponde al valor del Id del objeto Microsoft.Office.Interop.PowerPoint.Shape. A continuación se proporciona un código de muestra.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Obtener identificador único de forma en el ámbito de la diapositiva
    $officeInteropShapeId = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getOfficeInteropShapeId();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Establecer Texto Alternativo para Forma**
Aspose.Slides para PHP a través de Java permite a los desarrolladores establecer el AlternateText de cualquier forma.
Las formas en una presentación se pueden distinguir mediante los métodos [AlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setAlternativeText-java.lang.String-) o [Nombre de Forma](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setName-java.lang.String-).
Los métodos [setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setAlternativeText-java.lang.String-) y [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getAlternativeText--) se pueden leer o establecer utilizando Aspose.Slides así como Microsoft PowerPoint.
Al usar este método, puede etiquetar una forma y realizar diferentes operaciones como eliminar una forma,
ocultar una forma o reordenar formas en una diapositiva.
Para establecer el AlternateText de una forma, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Acceda a la primera diapositiva.
1. Agregue cualquier forma a la diapositiva.
1. Realice algunos trabajos con la forma recién agregada.
1. Recorrido a través de las formas para encontrar una forma.
1. Establezca el AlternativeText.
1. Guarde el archivo en el disco.

```php
  # Instanciar clase de Presentación que representa el PPTX
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Agregar autoshape de tipo rectángulo
    $shp1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $shp2 = $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $shp2->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      $shape = $sld->getShapes()->get_Item($i);
      if (!java_is_null($shape)) {
        $shape->setAlternativeText("Definido por el Usuario");
      }
    }
    # Guardar presentación en el disco
    $pres->save("Set_AlternativeText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Acceder a Formatos de Diseño para Forma**
Aspose.Slides para PHP a través de Java proporciona una API simple para acceder a formatos de diseño para una forma. Este artículo demuestra cómo puede acceder a formatos de diseño.

A continuación se proporciona un código de muestra.

```php
  $pres = new Presentation("pres.pptx");
  try {
    foreach($pres->getLayoutSlides() as $layoutSlide) {
      foreach($layoutSlide->getShapes() as $shape) {
        $fillFormats = $shape->getFillFormat();
        $lineFormats = $shape->getLineFormat();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Renderizar Forma como SVG**
Ahora Aspose.Slides para PHP a través de Java admite la renderización de una forma como SVG. El método [writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (y su sobrecarga) ha sido agregado a la clase [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/Shape) y a la interfaz [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape). Este método permite guardar el contenido de la forma como un archivo SVG. El fragmento de código a continuación muestra cómo exportar la forma de la diapositiva a un archivo SVG.

```php
  $pres = new Presentation("TestExportShapeToSvg.pptx");
  try {
    $stream = new Java("java.io.FileOutputStream", "SingleShape.svg");
    try {
      $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->writeAsSvg($stream);
    } finally {
      if (!java_is_null($stream)) {
        $stream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Alineación de Formas**
Aspose.Slides permite alinear formas ya sea relativas a los márgenes de la diapositiva o relativas entre sí. Para este propósito, se ha agregado el método sobrecargado [SlidesUtil.alignShape()](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-). La enumeración [ShapesAlignmentType](https://reference.aspose.com/slides/php-java/aspose.slides/ShapesAlignmentType) define las opciones de alineación posibles.

**Ejemplo 1**

El código fuente a continuación alinea las formas con índices 1,2 y 4 a lo largo del borde superior de la diapositiva.

```php
  $pres = new Presentation("example.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape1 = $slide->getShapes()->get_Item(1);
    $shape2 = $slide->getShapes()->get_Item(2);
    $shape3 = $slide->getShapes()->get_Item(4);
    SlideUtil->alignShapes(ShapesAlignmentType::AlignTop, true, $pres->getSlides()->get_Item(0), array($slide->getShapes()->indexOf($shape1), $slide->getShapes()->indexOf($shape2), $slide->getShapes()->indexOf($shape3) ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**Ejemplo 2**

El ejemplo a continuación muestra cómo alinear toda la colección de formas en relación con la forma en la parte inferior de la colección.

```php
  $pres = new Presentation("example.pptx");
  try {
    SlideUtil->alignShapes(ShapesAlignmentType::AlignBottom, false, $pres->getSlides()->get_Item(0));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```