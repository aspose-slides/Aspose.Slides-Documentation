---
title: Gestionar formas de presentación en PHP
linktitle: Manipulación de formas
type: docs
weight: 40
url: /es/php-java/shape-manipulations/
keywords:
- Forma de PowerPoint
- Forma de presentación
- Forma en diapositiva
- Encontrar forma
- Clonar forma
- Eliminar forma
- Ocultar forma
- Cambiar orden de forma
- Obtener ID de forma Interop
- Texto alternativo de forma
- Formatos de diseño de forma
- Forma como SVG
- Forma a SVG
- Alinear forma
- PowerPoint
- Presentación
- PHP
- Aspose.Slides
description: "Aprende a crear, editar y optimizar formas en Aspose.Slides for PHP via Java y ofrecer presentaciones de PowerPoint de alto rendimiento."
---

## **Buscar una forma en una diapositiva**
Este tema describirá una técnica sencilla para facilitar a los desarrolladores la búsqueda de una forma específica en una diapositiva sin usar su Id interno. Es importante saber que los archivos de presentación de PowerPoint no poseen ningún modo de identificar las formas en una diapositiva salvo mediante un Id interno único. Resulta complicado para los desarrolladores encontrar una forma usando su Id interno único. Todas las formas añadidas a las diapositivas disponen de texto alternativo. Sugerimos a los desarrolladores utilizar el texto alternativo para encontrar una forma específica. Puede usar MS PowerPoint para definir el texto alternativo de los objetos que planea cambiar en el futuro.

Después de establecer el texto alternativo de cualquier forma deseada, puede abrir esa presentación con Aspose.Slides for PHP via Java e iterar por todas las formas añadidas a una diapositiva. Durante cada iteración, puede comprobar el texto alternativo de la forma y la forma cuyo texto alternativo coincida será la forma que necesite. Para demostrar esta técnica de forma más clara, hemos creado un método, [findShape](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) que realiza la tarea de encontrar una forma específica en una diapositiva y simplemente devuelve esa forma.
```php
  # Instanciar una clase Presentation que representa el archivo de la presentación
  $pres = new Presentation("FindingShapeInSlide.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Texto alternativo de la forma a encontrar
    $shape = findShape($slide, "Shape1");
    if (!java_is_null($shape)) {
      echo("Shape Name: " . $shape->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

```php

```


## **Clonar una forma**
Para clonar una forma a una diapositiva usando Aspose.Slides for PHP via Java:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtenga la referencia de una diapositiva usando su índice.
1. Acceda a la colección de formas de la diapositiva origen.
1. Añada una nueva diapositiva a la presentación.
1. Clone las formas de la colección de formas de la diapositiva origen a la nueva diapositiva.
1. Guarde la presentación modificada como un archivo PPTX.

El ejemplo a continuación añade una forma de grupo a una diapositiva.
```php
  # Instanciar la clase Presentation
  $pres = new Presentation("Source Frame.pptx");
  try {
    $sourceShapes = $pres->getSlides()->get_Item(0)->getShapes();
    $blankLayout = $pres->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destSlide = $pres->getSlides()->addEmptySlide($blankLayout);
    $destShapes = $destSlide->getShapes();
    $destShapes->addClone($sourceShapes->get_Item(1), 50, 150 + $sourceShapes->get_Item(0)->getHeight());
    $destShapes->addClone($sourceShapes->get_Item(2));
    $destShapes->insertClone(0, $sourceShapes->get_Item(0), 50, 150);
    # Escribir el archivo PPTX en disco
    $pres->save("CloneShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Eliminar una forma**
Aspose.Slides for PHP via Java permite a los desarrolladores eliminar cualquier forma. Para eliminar la forma de cualquier diapositiva, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Acceda a la primera diapositiva.
1. Busque la forma con un AlternativeText específico.
1. Elimine la forma.
1. Guarde el archivo en disco.
```php
  # Crear objeto Presentation
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Agregar autoshape de tipo rectángulo
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $altText = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item(0);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $sld->getShapes()->remove($ashp);
      }
    }
    # Guardar la presentación en disco
    $pres->save("RemoveShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Ocultar una forma**
Aspose.Slides for PHP via Java permite a los desarrolladores ocultar cualquier forma. Para ocultar la forma de cualquier diapositiva, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Acceda a la primera diapositiva.
1. Busque la forma con un AlternativeText específico.
1. Oculte la forma.
1. Guarde el archivo en disco.
```php
  # Instanciar la clase Presentation que representa el PPTX
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Añadir autoshape de tipo rectángulo
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $alttext = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item($i);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $ashp->setHidden(true);
      }
    }
    # Guardar la presentación en disco
    $pres->save("Hiding_Shapes_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Cambiar el orden de las formas**
Aspose.Slides for PHP via Java permite a los desarrolladores reordenar las formas. Reordenar la forma especifica cuál está al frente y cuál está detrás. Para reordenar la forma de cualquier diapositiva, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Acceda a la primera diapositiva.
1. Añada una forma.
1. Añada algo de texto en el marco de texto de la forma.
1. Añada otra forma con las mismas coordenadas.
1. Reordene las formas.
1. Guarde el archivo en disco.
```php
  $pres = new Presentation("ChangeShapeOrder.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 365, 400, 150);
    $shp3->getFillFormat()->setFillType(FillType::NoFill);
    $shp3->addTextFrame(" ");
    $para = $shp3->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Watermark Text Watermark Text Watermark Text");
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 200, 365, 400, 150);
    $slide->getShapes()->reorder(2, $shp3);
    $pres->save("Reshape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Obtener el ID de forma Interop**
Aspose.Slides for PHP via Java permite a los desarrolladores obtener un identificador de forma único en el ámbito de la diapositiva, a diferencia del método [getUniqueId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getuniqueid/) que permite obtener un identificador único en el ámbito de la presentación. El método [getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getofficeinteropshapeid/) se añadió a la clase [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) respectivamente. El valor devuelto por el método [getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getofficeinteropshapeid/) corresponde al valor del Id del objeto Microsoft.Office.Interop.PowerPoint.Shape. A continuación se muestra un ejemplo de código.
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Obteniendo el identificador único de forma en el ámbito de la diapositiva
    $officeInteropShapeId = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getOfficeInteropShapeId();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Establecer texto alternativo para una forma**
Aspose.Slides for PHP via Java permite a los desarrolladores establecer el AlternateText de cualquier forma. Las formas en una presentación pueden distinguirse mediante el `Alternative Text` o el método [Shape Name](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setname/). Los métodos [setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setalternativetext/) y [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) pueden leerse o establecerse usando Aspose.Slides así como Microsoft PowerPoint. Usando este método, puede etiquetar una forma y realizar distintas operaciones como eliminar una forma, ocultar una forma o reordenar formas en una diapositiva. Para establecer el AlternateText de una forma, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Acceda a la primera diapositiva.
1. Añada cualquier forma a la diapositiva.
1. Realice alguna operación con la forma recién añadida.
1. Recorra las formas para encontrar una forma.
1. Establezca el AlternativeText.
1. Guarde el archivo en disco.
```php
  # Instanciar la clase Presentation que representa el PPTX
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Añadir autoshape de tipo rectángulo
    $shp1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $shp2 = $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $shp2->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      $shape = $sld->getShapes()->get_Item($i);
      if (!java_is_null($shape)) {
        $shape->setAlternativeText("User Defined");
      }
    }
    # Guardar la presentación en disco
    $pres->save("Set_AlternativeText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Acceder a formatos de diseño para una forma**
Aspose.Slides for PHP via Java proporciona una API sencilla para acceder a los formatos de diseño de una forma. Este artículo muestra cómo puede acceder a dichos formatos.

A continuación se muestra un ejemplo de código.
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


## **Renderizar una forma como SVG**
Ahora Aspose.Slides for PHP via Java soporta la renderización de una forma como SVG. El método [writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) (y sus sobrecargas) se añadió a la clase [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/). Este método permite guardar el contenido de la forma como un archivo SVG. El fragmento de código a continuación muestra cómo exportar la forma de la diapositiva a un archivo SVG.
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


## **Alinear una forma**
Aspose.Slides permite alinear formas ya sea respecto a los márgenes de la diapositiva o respecto a otras. Para ello, se añadió el método sobrecargado [SlidesUtil::alignShapes](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/alignshapes/). La enumeración [ShapesAlignmentType](https://reference.aspose.com/slides/php-java/aspose.slides/shapesalignmenttype/) define las posibles opciones de alineación.

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

El ejemplo a continuación muestra cómo alinear toda la colección de formas respecto a la forma más inferior de la colección.
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


## **Propiedades de volteo**

En Aspose.Slides, la clase [ShapeFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapeframe/) proporciona control sobre el espejo horizontal y vertical de las formas mediante sus propiedades `flipH` y `flipV`. Ambas propiedades son de tipo [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/), permitiendo valores `True` para indicar un volteo, `False` para no voltear, o `NotDefined` para usar el comportamiento predeterminado. Estos valores son accesibles desde el [Frame](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getFrame) de una forma.

Para modificar la configuración de volteo, se construye una nueva instancia de [ShapeFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapeframe/) con la posición y tamaño actuales de la forma, los valores deseados para `flipH` y `flipV`, y el ángulo de rotación. Asignar esta instancia al [Frame](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getFrame) de la forma y guardar la presentación aplica las transformaciones de espejo y las escribe en el archivo de salida.

Supongamos que disponemos de un archivo sample.pptx en el que la primera diapositiva contiene una única forma con la configuración de volteo predeterminada, como se muestra a continuación.

![La forma a voltear](shape_to_be_flipped.png)

El siguiente ejemplo de código recupera las propiedades de volteo actuales de la forma y la voltea tanto horizontal como verticalmente.
```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    // Obtener la propiedad de volteo horizontal de la forma.
    $horizontalFlip = $shape->getFrame()->getFlipH();
    echo "Horizontal flip: ", $horizontalFlip, "\n";

    // Obtener la propiedad de volteo vertical de la forma.
    $verticalFlip = $shape->getFrame()->getFlipV();
    echo "Vertical flip: ", $verticalFlip, "\n";

    $x = $shape->getFrame()->getX();
    $y = $shape->getFrame()->getY();
    $width = $shape->getFrame()->getWidth();
    $height = $shape->getFrame()->getHeight();
    $flipH = NullableBool::True; // Voltear horizontalmente.
    $flipV = NullableBool::True; // Voltear horizontalmente.
    $rotation = $shape->getFrame()->getRotation();

    $shape->setFrame(new ShapeFrame($x, $y, $width, $height, $flipH, $flipV, $rotation));

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


El resultado:

![La forma volteada](flipped_shape.png)

## **FAQ**

**¿Puedo combinar formas (unión/intersección/sustracción) en una diapositiva como en un editor de escritorio?**

No existe una API integrada para operaciones booleanas. Puede aproximarse construyendo el contorno deseado usted mismo—por ejemplo, calculando la geometría resultante (mediante [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/)) y creando una nueva forma con ese contorno, eliminando opcionalmente las originales.

**¿Cómo puedo controlar el orden de apilamiento (z-order) para que una forma siempre quede «encima»?**

Modifique el orden de inserción/movimiento dentro de la colección de [shapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) de la diapositiva. Para obtener resultados predecibles, finalice el z-order después de todas las demás modificaciones de la diapositiva.

**¿Puedo “bloquear” una forma para evitar que los usuarios la editen en PowerPoint?**

Sí. Establezca banderas de protección a nivel de forma (por ejemplo, bloquear la selección, movimiento, redimensionado, edición de texto). Si es necesario, aplique restricciones similares en la diapositiva maestra o de diseño. Tenga en cuenta que esta protección es a nivel de interfaz de usuario, no una característica de seguridad; para una protección más fuerte, combine con restricciones a nivel de archivo como [read-only recommendations or passwords](/slides/es/php-java/password-protected-presentation/).