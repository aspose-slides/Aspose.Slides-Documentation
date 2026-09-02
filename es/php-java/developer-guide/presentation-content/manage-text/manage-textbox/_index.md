---
title: Gestionar cuadros de texto en presentaciones usando PHP
linktitle: Gestionar cuadro de texto
type: docs
weight: 20
url: /es/php-java/manage-textbox/
keywords:
- cuadro de texto
- marco de texto
- añadir texto
- actualizar texto
- crear cuadro de texto
- comprobar cuadro de texto
- añadir columna de texto
- añadir hipervínculo
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP facilita la creación, edición y clonación de cuadros de texto en archivos PowerPoint y OpenDocument, mejorando la automatización de sus presentaciones."
---
## **Introducción**

Los textos en las diapositivas normalmente aparecen en cuadros de texto o formas. Por lo tanto, para añadir texto a una diapositiva, tienes que añadir un cuadro de texto y luego colocar algo de texto dentro del cuadro de texto. Aspose.Slides para PHP mediante Java proporciona la clase [AutoShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/autoshape/) que permite añadir una forma que contiene texto.

{{% alert title="Información" color="info" %}}

Aspose.Slides también ofrece la clase [Shape](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/) que permite añadir formas a las diapositivas. Sin embargo, no todas las formas añadidas mediante la clase `Shape` pueden contener texto. Pero las formas añadidas mediante la clase [AutoShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/autoshape/) pueden contener texto.

{{% /alert %}}

{{% alert title="Nota" color="warning" %}} 

Por lo tanto, cuando trabajas con una forma a la que deseas añadir texto, es posible que quieras comprobar y confirmar que se ha creado mediante la clase `AutoShape`. Solo entonces podrás trabajar con [TextFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/), que es una propiedad bajo `AutoShape`. Consulta la sección [Actualizar texto](/slides/es/php-java/manage-textbox/#update-text) en esta página.

{{% /alert %}}

## **Crear un cuadro de texto en una diapositiva**

Para crear un cuadro de texto en una diapositiva, sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/).
2. Obtén una referencia a la primera diapositiva de la presentación recién creada. 
3. Añade un objeto [AutoShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/autoshape/) con el tipo de forma establecido como [Rectangle](https://reference.aspose.com/slides/es/php-java/aspose.slides/shapetype/#Rectangle) en una posición especificada en la diapositiva y obtén la referencia del objeto `AutoShape` recién añadido.
4. Añade un `TextFrame` al objeto `AutoShape` que contendrá un texto. En el ejemplo siguiente, añadimos este texto: *Aspose TextBox*
5. Finalmente, escribe el archivo PPTX mediante el objeto `Presentation`. 

Este código PHP—una implementación de los pasos anteriores—te muestra cómo añadir texto a una diapositiva:

```php
  # Instancia Presentation
  $pres = new Presentation();
  try {
    # Obtiene la primera diapositiva de la presentación
    $sld = $pres->getSlides()->get_Item(0);
    # Añade un AutoShape con el tipo establecido como Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Añade TextFrame al rectángulo
    $ashp->addTextFrame(" ");
    # Accede al marco de texto
    $txtFrame = $ashp->getTextFrame();
    # Crea el objeto Paragraph para el marco de texto
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Crea un objeto Portion para el párrafo
    $portion = $para->getPortions()->get_Item(0);
    # Establece el texto
    $portion->setText("Aspose TextBox");
    # Guarda la presentación en disco
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Comprobar si una forma es un cuadro de texto**

Aspose.Slides proporciona el método [isTextBox](https://reference.aspose.com/slides/es/php-java/aspose.slides/autoshape/istextbox/) de la clase [AutoShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/autoshape/) , lo que permite examinar formas e identificar cuadros de texto.

![Cuadro de texto y forma](istextbox.png)

Este código PHP te muestra cómo comprobar si una forma se creó como cuadro de texto:

```php
class ShapeCallback {
    function invoke($shape, $slide, $index) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
            $autoShape = $shape;
            echo(java_is_true($autoShape->isTextBox()) ? "shape is a text box" : "shape is not a text box");
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachShapeCallback"));
    ForEach_::shape($presentation, $forEachShapeCallback);
} finally {
    $presentation->dispose();
}
```

Ten en cuenta que si simplemente añades una autoshape usando el método `addAutoShape` de la clase [ShapeCollection](https://reference.aspose.com/slides/es/php-java/aspose.slides/shapecollection/) , el método `isTextBox` de la autoshape devolverá `false`. Sin embargo, después de añadir texto a la autoshape mediante el método `addTextFrame` o el método `setText`, la propiedad `isTextBox` devolverá `true`.

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->isTextBox() devuelve false
$shape1->addTextFrame("shape 1");
// shape1->isTextBox() devuelve true

$shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->isTextBox() devuelve false
$shape2->getTextFrame()->setText("shape 2");
// shape2->isTextBox() devuelve true

$shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->isTextBox() devuelve false
$shape3->addTextFrame("");
// shape3->isTextBox() devuelve false

$shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->isTextBox() devuelve false
$shape4->getTextFrame()->setText("");
// shape4->isTextBox() devuelve false
```

## **Encontrar la forma que posee un cuadro de texto**

En código genérico de procesamiento de texto, puedes recibir un [TextFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/) sin saber ya qué objeto de presentación lo contiene. Usa el método [TextFrame::getParentShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/#getParentShape) para volver a la [Shape](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/) propietaria.

Para un cuadro de texto que pertenece a una [AutoShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/autoshape/) u otra forma que contiene texto, [TextFrame::getParentShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/#getParentShape) devuelve el propietario y [TextFrame::getParentCell](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/#getParentCell) devuelve `null`. Ambos métodos proporcionan una navegación solo de lectura, por lo que llamarlos no cambia la propiedad. Siempre verifica el valor devuelto con `java_is_null` antes de acceder a la forma.

Para un ejemplo completo que identifica propietarios de formas y celdas de tabla, incluidas las formas asociadas a nodos de SmartArt, consulta [Buscar y reemplazar texto](/slides/es/php-java/search-and-replace-text/).

## **Añadir columnas a un cuadro de texto**

Aspose.Slides ofrece los métodos [setColumnCount](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframeformat/setcolumncount/) y [setColumnSpacing](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframeformat/setcolumnspacing/) de la clase [TextFrameFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframeformat/) que permiten añadir columnas a los cuadros de texto. Puedes especificar el número de columnas en un cuadro de texto y establecer la distancia entre columnas en puntos.

Este código demuestra la operación descrita:

```php
  $pres = new Presentation();
  try {
    # Obtiene la primera diapositiva de la presentación
    $slide = $pres->getSlides()->get_Item(0);
    # Añade un AutoShape con el tipo establecido como Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Añade TextFrame al rectángulo
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # Obtiene el formato de texto del TextFrame
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # Especifica el número de columnas en el TextFrame
    $format->setColumnCount(3);
    # Especifica el espaciado entre columnas
    $format->setColumnSpacing(10);
    # Guarda la presentación
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Añadir columnas a un cuadro de texto**

Aspose.Slides para PHP mediante Java proporciona el método [setColumnCount](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframeformat/setcolumncount/) de la clase [TextFrameFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframeformat/) que permite añadir columnas en cuadros de texto. A través de esta propiedad, puedes especificar el número de columnas deseado en un cuadro de texto.

Este código PHP te muestra cómo añadir una columna dentro de un cuadro de texto:

```php
  $outPptxFileName = "ColumnsTest.pptx";
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    $format = $shape1->getTextFrame()->getTextFrameFormat();
    $format->setColumnCount(2);
    $shape1->getTextFrame()->setText("All these columns are forced to stay within a single text container -- " . "you can add or delete text - and the new or remaining text automatically adjusts " . "itself to stay within the container. You cannot have text spill over from one container " . "to other, though -- because PowerPoint's column options for text are limited!");
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test = new Presentation($outPptxFileName);
    try {
      $autoShape = $test->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(Double->NaN == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test)) {
        $test->dispose();
      }
    }
    $format->setColumnSpacing(20);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test1 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test1->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(20 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test1)) {
        $test1->dispose();
      }
    }
    $format->setColumnCount(3);
    $format->setColumnSpacing(15);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test2 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test2->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(3 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(15 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test2)) {
        $test2->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Actualizar texto**

Aspose.Slides permite cambiar o actualizar el texto contenido en un cuadro de texto o todos los textos contenidos en una presentación. 

Este código PHP demuestra una operación en la que todos los textos de una presentación se actualizan o cambian:

```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # Comprueba si la forma admite un marco de texto (IAutoShape).
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # Itera a través de los párrafos del marco de texto
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # Itera a través de cada porción en el párrafo
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// Cambia el texto

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// Cambia el formato

            }
          }
        }
      }
    }
    # Guarda la presentación modificada
    $pres->save("text-changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Añadir un cuadro de texto con hipervínculo** 

Puedes insertar un enlace dentro de un cuadro de texto. Cuando se hace clic en el cuadro de texto, los usuarios son dirigidos a abrir el enlace. 

Para añadir un cuadro de texto que contenga un enlace, sigue estos pasos:

1. Crea una instancia de la clase `Presentation`. 
2. Obtén una referencia a la primera diapositiva de la presentación recién creada. 
3. Añade un objeto `AutoShape` con `ShapeType` establecido como `Rectangle` en una posición especificada en la diapositiva y obtén una referencia del objeto AutoShape recién añadido.
4. Añade un `TextFrame` al objeto `AutoShape` que contenga *Aspose TextBox* como texto predeterminado. 
5. Instancia la clase `HyperlinkManager`. 
6. Asigna un hipervínculo usando el método [setExternalHyperlinkClick](https://reference.aspose.com/slides/es/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/) asociado a la parte que prefieras del `TextFrame`.
7. Finalmente, escribe el archivo PPTX mediante el objeto `Presentation`. 

Este código PHP—una implementación de los pasos anteriores—te muestra cómo añadir un cuadro de texto con un hipervínculo a una diapositiva:

```php
  # Instancia una clase Presentation que representa un PPTX
  $pres = new Presentation();
  try {
    # Obtiene la primera diapositiva de la presentación
    $slide = $pres->getSlides()->get_Item(0);
    # Añade un objeto AutoShape con el tipo establecido como Rectangle
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # Convierte la forma a AutoShape
    $pptxAutoShape = $shape;
    # Accede a la propiedad ITextFrame asociada al AutoShape
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # Añade texto al marco
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # Establece el hipervínculo para el texto de la porción
    $hyperlinkManager = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getHyperlinkManager();
    $hyperlinkManager->setExternalHyperlinkClick("http://www.aspose.com");
    # Guarda la presentación PPTX
    $pres->save("hLink_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre un cuadro de texto y un marcador de posición de texto al trabajar con diapositivas maestras?**

Un [marcador de posición](/slides/es/php-java/manage-placeholder/) hereda estilo/posición de la [maestra](https://reference.aspose.com/slides/es/php-java/aspose.slides/masterslide/) y puede ser sobrescrito en los [diseños](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutslide/), mientras que un cuadro de texto normal es un objeto independiente en una diapositiva específica y no cambia al cambiar de diseños.

**¿Cómo puedo realizar un reemplazo masivo de texto en toda la presentación sin afectar el texto dentro de gráficos, tablas y SmartArt?**

Limita tu iteración a las autoshapes que tengan cuadros de texto y excluye los objetos incrustados ([charts](https://reference.aspose.com/slides/es/php-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/es/php-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/es/php-java/aspose.slides/smartart/)) recorriendo sus colecciones por separado o omitiendo esos tipos de objetos.