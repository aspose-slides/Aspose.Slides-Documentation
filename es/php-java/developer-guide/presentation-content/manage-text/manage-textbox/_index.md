---
title: Gestionar TextBox
type: docs
weight: 20
url: /es/php-java/manage-textbox/
description: Crear un cuadro de texto en las diapositivas de PowerPoint usando PHP. Agregar columna en el cuadro de texto o marco de texto en las diapositivas de PowerPoint usando PHP. Agregar un cuadro de texto con hipervínculo en las diapositivas de PowerPoint usando PHP.
---

Los textos en las diapositivas generalmente existen en cuadros de texto o formas. Por lo tanto, para agregar un texto a una diapositiva, debe agregar un cuadro de texto y luego poner algún texto dentro del cuadro de texto. Aspose.Slides para PHP a través de Java proporciona la interfaz [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) que le permite agregar una forma que contenga algún texto.

{{% alert title="Información" color="info" %}}

Aspose.Slides también proporciona la interfaz [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) que le permite agregar formas a las diapositivas. Sin embargo, no todas las formas agregadas a través de la interfaz `IShape` pueden contener texto. Pero las formas agregadas a través de la interfaz [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) pueden contener texto.

{{% /alert %}}

{{% alert title="Nota" color="warning" %}} 

Por lo tanto, al tratar con una forma a la que desea agregar texto, puede que desee verificar y confirmar que fue convertida a través de la interfaz `IAutoShape`. Solo entonces podrá trabajar con [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame), que es una propiedad de `IAutoShape`. Consulte la sección [Actualizar Texto](https://docs.aspose.com/slides/php-java/manage-textbox/#update-text) en esta página.

{{% /alert %}}

## **Crear Cuadro de Texto en la Diapositiva**

Para crear un cuadro de texto en una diapositiva, siga estos pasos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenga una referencia para la primera diapositiva de la presentación recién creada. 
3. Agregue un objeto [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) con [ShapeType](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#setShapeType-int-) establecido como `Rectangle` en una posición especificada en la diapositiva y obtenga la referencia del objeto `IAutoShape` recién agregado.
4. Agregue una propiedad `TextFrame` al objeto `IAutoShape` que contendrá un texto. En el ejemplo a continuación, agregamos este texto: *Aspose TextBox*
5. Finalmente, escriba el archivo PPTX a través del objeto `Presentation`. 

Este código PHP, una implementación de los pasos anteriores, le muestra cómo agregar texto a una diapositiva:

```php
  # Instancia Presentation
  $pres = new Presentation();
  try {
    # Obtiene la primera diapositiva en la presentación
    $sld = $pres->getSlides()->get_Item(0);
    # Agrega un AutoShape con tipo establecido como Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Agrega TextFrame al Rectangle
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

## **Verificar si la Forma es un Cuadro de Texto**

Aspose.Slides proporciona la propiedad [isTextBox()](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#isTextBox--) (de la clase [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)) para permitirle examinar formas y encontrar cuadros de texto.

![Cuadro de texto y forma](istextbox.png)

Este código PHP le muestra cómo verificar si una forma fue creada como un cuadro de texto:

```php
class ShapeCallback {
    function invoke($shape, $slide, $index){
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape")))
        $autoShape = $shape;
        echo(java_is_true($autoShape->isTextBox()) ? "la forma es un cuadro de texto" : "la forma es texto no cuadro");
    }
}

  $pres = new Presentation("pres.pptx");
  try {
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachSlideCallback"));
    ForEach::shape($pres, $forEachShapeCallback);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Agregar Columna en el Cuadro de Texto**

Aspose.Slides proporciona las propiedades [ColumnCount](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setColumnCount-int-) y [ColumnSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (de la interfaz [ITextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat) y la clase [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) que le permiten agregar columnas a los cuadros de texto. Puede especificar el número de columnas en un cuadro de texto y establecer la cantidad de espaciado en puntos entre las columnas.

Este código demuestra la operación descrita:

```php
  $pres = new Presentation();
  try {
    # Obtiene la primera diapositiva en la presentación
    $slide = $pres->getSlides()->get_Item(0);
    # Agrega un AutoShape con tipo establecido como Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Agrega TextFrame al Rectangle
    $aShape->addTextFrame("Todas estas columnas están limitadas a estar dentro de un solo contenedor de texto -- " . "puede agregar o eliminar texto y el texto nuevo o restante se ajusta automáticamente " . "para fluir dentro del contenedor. No se puede tener texto fluyendo de un contenedor " . "a otro sin embargo -- ¡le dijimos que las opciones de columnas de PowerPoint para texto son limitadas!");
    # Obtiene el formato de texto del TextFrame
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # Especifica el número de columnas en TextFrame
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

## **Agregar Columna en el Marco de Texto**
Aspose.Slides para PHP a través de Java proporciona la propiedad [ColumnCount](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setColumnCount-int-) (de la interfaz [ITextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat)) que le permite agregar columnas en los marcos de texto. A través de esta propiedad, puede especificar su número preferido de columnas en un marco de texto.

Este código PHP le muestra cómo agregar una columna dentro de un marco de texto:

```php
  $outPptxFileName = "ColumnsTest.pptx";
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    $format = $shape1->getTextFrame()->getTextFrameFormat();
    $format->setColumnCount(2);
    $shape1->getTextFrame()->setText("Todas estas columnas están forzadas a permanecer dentro de un solo contenedor de texto -- " . "puede agregar o eliminar texto - y el texto nuevo o restante se ajusta automáticamente " . "para permanecer dentro del contenedor. No se puede tener texto desbordando de un contenedor " . "a otro, sin embargo -- porque las opciones de columnas de PowerPoint para texto son limitadas!");
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

## **Actualizar Texto**

Aspose.Slides le permite cambiar o actualizar el texto contenido en un cuadro de texto o todos los textos contenidos en una presentación. 

Este código PHP demuestra una operación donde se actualizan o cambian todos los textos en una presentación:

```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # Verifica si la forma soporta el marco de texto (IAutoShape).
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # Itera a través de los párrafos en el marco de texto
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # Itera a través de cada porción en el párrafo
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months")); // Cambia el texto

              $portion->getPortionFormat()->setFontBold(NullableBool::True); // Cambia el formato

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

## **Agregar Cuadro de Texto con Hipervínculo** 

Puede insertar un enlace dentro de un cuadro de texto. Cuando se hace clic en el cuadro de texto, los usuarios son dirigidos a abrir el enlace. 

 Para agregar un cuadro de texto que contenga un enlace, siga estos pasos:

1. Cree una instancia de la clase `Presentation`. 
2. Obtenga una referencia para la primera diapositiva de la presentación recién creada. 
3. Agregue un objeto `AutoShape` con `ShapeType` establecido como `Rectangle` en una posición especificada en la diapositiva y obtenga una referencia del objeto `AutoShape` recién agregado.
4. Agregue un `TextFrame` al objeto `AutoShape` que contenga *Aspose TextBox* como su texto predeterminado. 
5. Instancie la clase `IHyperlinkManager`. 
6. Asigne el objeto `IHyperlinkManager` a la propiedad [HyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/Shape#getHyperlinkClick--) asociada con su porción preferida del `TextFrame`.
7. Finalmente, escriba el archivo PPTX a través del objeto `Presentation`. 

Este código PHP, una implementación de los pasos anteriores, le muestra cómo agregar un cuadro de texto con un hipervínculo a una diapositiva:

```php
  # Instancia una clase Presentation que representa un PPTX
  $pres = new Presentation();
  try {
    # Obtiene la primera diapositiva en la presentación
    $slide = $pres->getSlides()->get_Item(0);
    # Agrega un objeto AutoShape con tipo establecido como Rectangle
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # Convierte la forma a AutoShape
    $pptxAutoShape = $shape;
    # Accede a la propiedad ITextFrame asociada con el AutoShape
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # Agrega algo de texto al marco
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