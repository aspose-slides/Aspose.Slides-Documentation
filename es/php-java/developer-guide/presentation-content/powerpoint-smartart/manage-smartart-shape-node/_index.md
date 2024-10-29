---
title: Crear o Administrar Nodo de Forma SmartArt en PowerPoint
linktitle: Administrar Nodo de Forma SmartArt
type: docs
weight: 30
url: /es/php-java/manage-smartart-shape-node/
keywords: smartart powerpoint, nodos smartart, posición smartart, eliminar smartart, añadir nodos smartart, presentación powerpoint, powerpoint java, api java de powerpoint
description: Administrar nodo smart art y nodo hijo en Presentaciones de PowerPoint
---

## **Agregar Nodo SmartArt en Presentación de PowerPoint usando PHP**
Aspose.Slides para PHP a través de Java ha proporcionado la API más sencilla para gestionar las formas SmartArt de la manera más fácil. El siguiente código de ejemplo ayudará a agregar un nodo y un nodo hijo dentro de la forma SmartArt.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) y cargar la presentación con la Forma SmartArt.
1. Obtener la referencia de la primera diapositiva utilizando su índice.
1. Recorrer cada forma dentro de la primera diapositiva.
1. Verificar si la forma es de tipo [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) y convertir el tipo de la forma seleccionada a [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) si es SmartArt.
1. [Agregar un nuevo Nodo](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--) en la forma SmartArt [**NodeCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#getAllNodes--) y establecer el texto en TextFrame.
1. Ahora, [Agregar](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--) un [**Nodo Hijo**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) en el nuevo [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) Nodo y establecer el texto en TextFrame.
1. Guardar la Presentación.

```php
  # Cargar la presentación deseada
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Recorrer cada forma dentro de la primera diapositiva
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Verificar si la forma es de tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Convertir la forma a SmartArt
        $smart = $shape;
        # Agregar un nuevo Nodo SmartArt
        $TemNode = $smart->getAllNodes()->addNode();
        # Agregar texto
        $TemNode->getTextFrame()->setText("Test");
        # Agregar un nuevo nodo hijo en el nodo padre. Se añadirá al final de la colección
        $newNode = $TemNode->getChildNodes()->addNode();
        # Agregar texto
        $newNode->getTextFrame()->setText("Nuevo Nodo Agregado");
      }
    }
    # Guardar presentación
    $pres->save("AddSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Agregar Nodo SmartArt en Posición Específica**
En el siguiente código de ejemplo explicamos cómo agregar los nodos hijos pertenecientes a los respectivos nodos de la forma SmartArt en una posición particular.

1. Crear una instancia de la clase Presentation.
1. Obtener la referencia de la primera diapositiva utilizando su índice.
1. Agregar una forma [**StackedList**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#StackedList) tipo [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) en la diapositiva accedida.
1. Acceder al primer nodo en la forma SmartArt agregada.
1. Ahora, agregar el [**Nodo Hijo**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) para el [**Nodo**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode) seleccionado en la posición 2 y establecer su texto.
1. Guardar la Presentación.

```php
  # Crear una instancia de presentación
  $pres = new Presentation();
  try {
    # Acceder a la diapositiva de presentación
    $slide = $pres->getSlides()->get_Item(0);
    # Agregar la forma Smart Art IShape
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # Accediendo al nodo SmartArt en el índice 0
    $node = $smart->getAllNodes()->get_Item(0);
    # Agregar un nuevo nodo hijo en la posición 2 en el nodo padre
    $chNode = $node->getChildNodes()->addNodeByPosition(2);
    # Agregar Texto
    $chNode->getTextFrame()->setText("Texto de Ejemplo Agregado");
    # Guardar Presentación
    $pres->save("AddSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Acceder a Nodo SmartArt en Presentación de PowerPoint usando PHP**
El siguiente código de ejemplo ayudará a acceder a los nodos dentro de la forma SmartArt. Tenga en cuenta que no puede cambiar el LayoutType del SmartArt, ya que es de solo lectura y se establece solo cuando se agrega la forma SmartArt.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) y cargar la presentación con la Forma SmartArt.
1. Obtener la referencia de la primera diapositiva utilizando su índice.
1. Recorrer cada forma dentro de la primera diapositiva.
1. Verificar si la forma es de tipo [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) y convertir el tipo de la forma seleccionada a [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) si es SmartArt.
1. Recorrer todos los [**Nodos**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt#getAllNodes--) dentro de la Forma SmartArt.
1. Acceder y mostrar información como la posición del Nodo SmartArt, nivel y texto.

```php
  # Instanciar la clase Presentation
  $pres = new Presentation("SmartArtShape.pptx");
  try {
    # Obtener la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Recorrer cada forma dentro de la primera diapositiva
    foreach($slide->getShapes() as $shape) {
      # Verificar si la forma es de tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Convertir forma a SmartArt
        $smart = $shape;
        # Recorrer todos los nodos dentro del SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # Accediendo al nodo SmartArt en el índice i
          $node = $smart->getAllNodes()->get_Item($i);
          # Imprimiendo los parámetros del nodo SmartArt
          System->out->print($node->getTextFrame()->getText() . " " . $node->getLevel() . " " . $node->getPosition());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Acceder a Nodo Hijo SmartArt**
El siguiente código de ejemplo ayudará a acceder a los nodos hijos pertenecientes a los respectivos nodos de la forma SmartArt.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) y cargar la presentación con la Forma SmartArt.
1. Obtener la referencia de la primera diapositiva utilizando su índice.
1. Recorrer cada forma dentro de la primera diapositiva.
1. Verificar si la forma es de tipo [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) y convertir el tipo de la forma seleccionada a [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) si es SmartArt.
1. Recorrer todos los [**Nodos**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt#getAllNodes--) dentro de la Forma SmartArt.
1. Para cada [**Nodo**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode), recorrer todos los [**Nodos Hijos**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode#getChildNodes--) dentro del nodo particular.
1. Acceder y mostrar información como la posición del [**Nodo Hijo**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--), nivel y texto.

```php
  # Instanciar la clase Presentation
  $pres = new Presentation("AccessChildNodes.pptx");
  try {
    # Obtener la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Recorrer cada forma dentro de la primera diapositiva
    foreach($slide->getShapes() as $shape) {
      # Verificar si la forma es de tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Convertir forma a SmartArt
        $smart = $shape;
        # Recorrer todos los nodos dentro del SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # Accediendo al nodo SmartArt en el índice i
          $node0 = $smart->getAllNodes()->get_Item($i);
          # Recorrer los nodos hijos en el nodo SmartArt en el índice i
          for($j = 0; $j < java_values($node0->getChildNodes()->size()) ; $j++) {
            # Accediendo al nodo hijo en el nodo SmartArt
            $node = $node0->getChildNodes()->get_Item($j);
            # Imprimiendo los parámetros del nodo hijo SmartArt
            System->out->print("j = " . $j . ", Texto = " . $node->getTextFrame()->getText() . ",  Nivel = " . $node->getLevel() . ", Posición = " . $node->getPosition());
          }
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Acceder a Nodo Hijo SmartArt en Posición Específica**
En este ejemplo, aprenderemos a acceder a los nodos hijos en una posición particular pertenecientes a los respectivos nodos de la forma SmartArt.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Obtener la referencia de la primera diapositiva utilizando su índice.
1. Agregar una forma [**StackedList**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#StackedList) tipo SmartArt.
1. Acceder a la forma SmartArt agregada.
1. Acceder al nodo en el índice 0 para la forma SmartArt accedida.
1. Ahora, acceder al [**Nodo Hijo**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) en la posición 1 para el nodo SmartArt accedido usando el método **get_Item()**.
1. Acceder y mostrar información como la posición del [**Nodo Hijo**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--), nivel y texto.

```php
  # Instanciar la presentación
  $pres = new Presentation();
  try {
    # Accediendo a la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Agregando la forma SmartArt en la primera diapositiva
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # Accediendo al nodo SmartArt en el índice 0
    $node = $smart->getAllNodes()->get_Item(0);
    # Accediendo al nodo hijo en la posición 1 en el nodo padre
    $position = 1;
    $chNode = $node->getChildNodes()->get_Item($position);
    # Imprimiendo los parámetros del nodo hijo SmartArt
    System->out->print("Texto = " . $chNode->getTextFrame()->getText() . ",  Nivel = " . $chNode->getLevel() . ", Posición = " . $chNode->getPosition());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Eliminar Nodo SmartArt en Presentación de PowerPoint usando PHP**
En este ejemplo, aprenderemos a eliminar los nodos dentro de la forma SmartArt.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) y cargar la presentación con la Forma SmartArt.
1. Obtener la referencia de la primera diapositiva utilizando su índice.
1. Recorrer cada forma dentro de la primera diapositiva.
1. Verificar si la forma es de tipo [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) y convertir la forma seleccionada a [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) si es SmartArt.
1. Verificar si el [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) tiene más de 0 nodos.
1. Seleccionar el nodo SmartArt a eliminar.
1. Ahora, eliminar el nodo seleccionado utilizando el método [**RemoveNode**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) .
1. Guardar la Presentación.

```php
  # Cargar la presentación deseada
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Recorrer cada forma dentro de la primera diapositiva
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Verificar si la forma es de tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Convertir la forma a SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # Accediendo al nodo SmartArt en el índice 0
          $node = $smart->getAllNodes()->get_Item(0);
          # Eliminando el nodo seleccionado
          $smart->getAllNodes()->removeNode($node);
        }
      }
    }
    # Guardar presentación
    $pres->save("RemoveSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Eliminar Nodo SmartArt en Posición Específica**
En este ejemplo, aprenderemos a eliminar los nodos dentro de la forma SmartArt en una posición particular.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) y cargar la presentación con la Forma SmartArt.
1. Obtener la referencia de la primera diapositiva utilizando su índice.
1. Recorrer cada forma dentro de la primera diapositiva.
1. Verificar si la forma es de tipo [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) y convertir la forma seleccionada a [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) si es SmartArt.
1. Seleccionar el nodo de forma SmartArt en el índice 0.
1. Ahora, verificar si el nodo SmartArt seleccionado tiene más de 2 nodos hijo.
1. Ahora, eliminar el nodo en **Posición 1** utilizando el método [**RemoveNode**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#removeNode-int-) .
1. Guardar la Presentación.

```php
  # Cargar la presentación deseada
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Recorrer cada forma dentro de la primera diapositiva
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Verificar si la forma es de tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Convertir la forma a SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # Accediendo al nodo SmartArt en el índice 0
          $node = $smart->getAllNodes()->get_Item(0);
          if (java_values($node->getChildNodes()->size()) >= 2) {
            # Eliminando el nodo hijo en la posición 1
            $node->getChildNodes()->removeNode(1);
          }
        }
      }
    }
    # Guardar presentación
    $pres->save("RemoveSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Establecer Posición Personalizada para Nodo Hijo en SmartArt**
Ahora Aspose.Slides para PHP a través de Java admite el establecimiento de las propiedades [SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setX-float-) y [Y](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setY-float-). El fragmento de código a continuación muestra cómo establecer una posición personalizada de SmartArtShape, tamaño y rotación. También tenga en cuenta que añadir nuevos nodos provoca un recalculo de las posiciones y tamaños de todos los nodos. Además, con la configuración de posición personalizada, el usuario puede establecer los nodos según los requisitos.

```php
  # Instanciar la clase Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(20, 20, 600, 500, SmartArtLayoutType::OrganizationChart);
    # Mover la forma SmartArt a una nueva posición
    $node = $smart->getAllNodes()->get_Item(1);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setX($shape->getX() + $shape->getWidth() * 2);
    $shape->setY($shape->getY() - $shape->getHeight() * 2);
    # Cambiar el ancho de la forma SmartArt
    $node = $smart->getAllNodes()->get_Item(2);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setWidth($shape->getWidth() + $shape->getWidth() * 2);
    # Cambiar la altura de la forma SmartArt
    $node = $smart->getAllNodes()->get_Item(3);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setHeight($shape->getHeight() + $shape->getHeight() * 2);
    # Cambiar la rotación de la forma SmartArt
    $node = $smart->getAllNodes()->get_Item(4);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setRotation(90);
    $pres->save("SmartArt.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Comprobar Nodo Asistente**
{{% alert color="primary" %}} 

En este artículo investigaremos más características de las formas SmartArt añadidas en las diapositivas de presentación programáticamente utilizando Aspose.Slides para PHP a través de Java.

{{% /alert %}} 

Usaremos la siguiente forma SmartArt fuente para nuestra investigación en diferentes secciones de este artículo.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figura: Forma SmartArt fuente en la diapositiva**|

En el siguiente código de ejemplo investigaremos cómo identificar **Nodos Asistentes** en la colección de nodos SmartArt y cambiarlos.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) y cargar la presentación con la Forma SmartArt.
1. Obtener la referencia de la segunda diapositiva utilizando su índice.
1. Recorrer cada forma dentro de la primera diapositiva.
1. Verificar si la forma es de tipo [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) y convertir la forma seleccionada a [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) si es SmartArt.
1. Recorrer todos los nodos dentro de la forma SmartArt y verificar si son [**Nodos Asistentes**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode#isAssistant--).
1. Cambiar el estado de Nodo Asistente a nodo normal.
1. Guardar la Presentación.

```php
  # Crear una instancia de presentación
  $pres = new Presentation("AddNodes.pptx");
  try {
    # Recorrer cada forma dentro de la primera diapositiva
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Verificar si la forma es de tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Convertir la forma a SmartArt
        $smart = $shape;
        # Recorrer todos los nodos de la forma SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          $node = $smart->getAllNodes()->get_Item($i);
          # Verificar si el nodo es un nodo asistente
          if ($node->isAssistant()) {
            # Establecer el nodo asistente a falso y convertirlo en un nodo normal
            $node->isAssistant(false);
          }
        }
      }
    }
    # Guardar presentación
    $pres->save("ChangeAssitantNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figura: Nodos Asistentes cambiados en la forma SmartArt dentro de la diapositiva**|

## **Establecer Formato de Relleno de Nodo**
Aspose.Slides para PHP a través de Java permite añadir formas SmartArt personalizadas y establecer su formato de relleno. Este artículo explica cómo crear y acceder a las formas SmartArt y establecer su formato de relleno utilizando Aspose.Slides para PHP a través de Java.

Siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Obtener la referencia de una diapositiva utilizando su índice.
1. Agregar una forma [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) estableciendo su [**LayoutType**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess).
1. Establecer el [**FillFormat**](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getFillFormat--) para los nodos de la forma SmartArt.
1. Escribir la presentación modificada como un archivo PPTX.

```php
  # Instanciar la presentación
  $pres = new Presentation();
  try {
    # Accediendo a la diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Agregando forma SmartArt y nodos
    $chevron = $slide->getShapes()->addSmartArt(10, 10, 800, 60, SmartArtLayoutType::ClosedChevronProcess);
    $node = $chevron->getAllNodes()->addNode();
    $node->getTextFrame()->setText("Algún texto");
    # Estableciendo el color de relleno del nodo
    foreach($node->getShapes() as $item) {
      $item->getFillFormat()->setFillType(FillType::Solid);
      $item->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    }
    # Guardar la presentación
    $pres->save("TestSmart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Generar Miniatura de Nodo Hijo SmartArt**
Los desarrolladores pueden generar una miniatura del nodo hijo de un SmartArt siguiendo los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. [Agregar SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--).
1. Obtener la referencia de un nodo utilizando su índice.
1. Obtener la imagen de miniatura.
1. Guardar la imagen de miniatura en cualquier formato de imagen deseado.

```php
  # Instanciar la clase Presentation que representa el archivo PPTX
  $pres = new Presentation();
  try {
    # Agregar SmartArt
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
    # Obtener la referencia de un nodo utilizando su índice
    $node = $smart->getNodes()->get_Item(1);
    # Obtener miniatura
    $slideImage = $node->getShapes()->get_Item(0)->getImage();
    # Guardar miniatura
    try {
      $slideImage->save("SmartArt_ChildNote_Thumbnail.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```