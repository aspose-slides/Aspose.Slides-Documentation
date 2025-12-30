---
title: Gestionar nodos de formas SmartArt en presentaciones usando PHP
linktitle: Nodo de forma SmartArt
type: docs
weight: 30
url: /es/php-java/manage-smartart-shape-node/
keywords:
- nodo SmartArt
- nodo hijo
- añadir nodo
- posición del nodo
- acceder al nodo
- eliminar nodo
- posición personalizada
- nodo asistente
- formato de relleno
- renderizar nodo
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Gestiona los nodos de formas SmartArt en PPT y PPTX con Aspose.Slides para PHP vía Java. Obtén ejemplos de código claros y consejos para optimizar tus presentaciones."
---

## **Añadir un nodo SmartArt**
Aspose.Slides for PHP via Java ha proporcionado la API más sencilla para gestionar las formas SmartArt de la manera más fácil. El siguiente código de ejemplo ayudará a añadir un nodo y un nodo hijo dentro de la forma SmartArt.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) y cargar la presentación con la forma SmartArt.
1. Obtener la referencia de la primera diapositiva mediante su índice.
1. Recorrer cada forma dentro de la primera diapositiva.
1. Comprobar si la forma es de tipo [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) y convertir la forma seleccionada a [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) si es SmartArt.
1. [Añadir un nodo nuevo](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--) en la forma SmartArt [**NodeCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#getAllNodes--) y establecer el texto en TextFrame.
1. Ahora, [Añadir](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--) un [**Nodo hijo**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) en el nodo SmartArt recién añadido y establecer el texto en TextFrame.
1. Guardar la presentación.
```php
  # Cargar la presentación deseada
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Recorrer cada forma dentro de la primera diapositiva
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Comprobar si la forma es de tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Convertir la forma a SmartArt
        $smart = $shape;
        # Añadir un nuevo nodo SmartArt
        $TemNode = $smart->getAllNodes()->addNode();
        # Añadir texto
        $TemNode->getTextFrame()->setText("Test");
        # Añadir un nuevo nodo hijo en el nodo padre. Se añadirá al final de la colección
        $newNode = $TemNode->getChildNodes()->addNode();
        # Añadir texto
        $newNode->getTextFrame()->setText("New Node Added");
      }
    }
    # Guardar la presentación
    $pres->save("AddSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Añadir un nodo SmartArt en una posición específica**
En el siguiente código de ejemplo hemos explicado cómo añadir los nodos hijos pertenecientes a los nodos respectivos de la forma SmartArt en una posición concreta.

1. Crear una instancia de la clase Presentation.
1. Obtener la referencia de la primera diapositiva mediante su índice.
1. Añadir una forma [**StackedList**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#StackedList) de tipo [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) en la diapositiva accedida.
1. Acceder al primer nodo en la forma SmartArt añadida.
1. Ahora, añadir el [**Nodo hijo**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) para el [**Nodo**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode) seleccionado en la posición 2 y establecer su texto.
1. Guardar la presentación.
```php
  # Crear una instancia de presentación
  $pres = new Presentation();
  try {
    # Acceder a la diapositiva de la presentación
    $slide = $pres->getSlides()->get_Item(0);
    # Añadir Smart Art IShape
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # Acceder al nodo SmartArt en el índice 0
    $node = $smart->getAllNodes()->get_Item(0);
    # Añadir nuevo nodo hijo en la posición 2 del nodo padre
    $chNode = $node->getChildNodes()->addNodeByPosition(2);
    # Añadir texto
    $chNode->getTextFrame()->setText("Sample Text Added");
    # Guardar la presentación
    $pres->save("AddSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Acceder a un nodo SmartArt**
El siguiente código de ejemplo ayudará a acceder a los nodos dentro de la forma SmartArt. Tenga en cuenta que no puede cambiar el LayoutType del SmartArt ya que es de solo lectura y se establece únicamente cuando se añade la forma SmartArt.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) y cargar la presentación con la forma SmartArt.
1. Obtener la referencia de la primera diapositiva mediante su índice.
1. Recorrer cada forma dentro de la primera diapositiva.
1. Comprobar si la forma es de tipo [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) y convertir la forma seleccionada a [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) si es SmartArt.
1. Recorrer todos los [**Nodos**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt#getAllNodes--) dentro de la forma SmartArt.
1. Acceder y mostrar información como la posición del nodo SmartArt, nivel y texto.
```php
  # Instanciar la clase Presentation
  $pres = new Presentation("SmartArtShape.pptx");
  try {
    # Obtener la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Recorrer cada forma dentro de la primera diapositiva
    foreach($slide->getShapes() as $shape) {
      # Comprobar si la forma es de tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Convertir la forma a SmartArt
        $smart = $shape;
        # Recorrer todos los nodos dentro del SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # Acceder al nodo SmartArt en el índice i
          $node = $smart->getAllNodes()->get_Item($i);
          # Imprimir los parámetros del nodo SmartArt
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


## **Acceder a un nodo hijo SmartArt**
El siguiente código de ejemplo ayudará a acceder a los nodos hijos pertenecientes a los nodos respectivos de la forma SmartArt.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) y cargar la presentación con la forma SmartArt.
1. Obtener la referencia de la primera diapositiva mediante su índice.
1. Recorrer cada forma dentro de la primera diapositiva.
1. Comprobar si la forma es de tipo [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) y convertir la forma seleccionada a [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) si es SmartArt.
1. Recorrer todos los [**Nodos**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt#getAllNodes--) dentro de la forma SmartArt.
1. Para cada [**Nodo**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode) de la forma SmartArt seleccionado, recorra todos los [**Nodos hijo**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode#getChildNodes--) dentro del nodo concreto.
1. Acceder y mostrar información como la posición, nivel y texto del [**Nodo hijo**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--).
```php
  # Instanciar la clase Presentation
  $pres = new Presentation("AccessChildNodes.pptx");
  try {
    # Obtener la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Recorrer cada forma dentro de la primera diapositiva
    foreach($slide->getShapes() as $shape) {
      # Comprobar si la forma es de tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Convertir la forma a SmartArt
        $smart = $shape;
        # Recorrer todos los nodos dentro de SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # Acceder al nodo SmartArt en el índice i
          $node0 = $smart->getAllNodes()->get_Item($i);
          # Recorrer los nodos hijos del nodo SmartArt en el índice i
          for($j = 0; $j < java_values($node0->getChildNodes()->size()) ; $j++) {
            # Acceder al nodo hijo en el nodo SmartArt
            $node = $node0->getChildNodes()->get_Item($j);
            # Imprimir los parámetros del nodo hijo SmartArt
            System->out->print("j = " . $j . ", Text = " . $node->getTextFrame()->getText() . ",  Level = " . $node->getLevel() . ", Position = " . $node->getPosition());
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


## **Acceder a un nodo hijo SmartArt en una posición específica**
En este ejemplo aprenderemos a acceder a los nodos hijos en una posición concreta pertenecientes a los nodos respectivos de la forma SmartArt.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Obtener la referencia de la primera diapositiva mediante su índice.
1. Añadir una forma SmartArt de tipo [**StackedList**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#StackedList).
1. Acceder a la forma SmartArt añadida.
1. Acceder al nodo con índice 0 de la forma SmartArt accedida.
1. Ahora, acceder al [**Nodo hijo**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) en la posición 1 del nodo SmartArt accedido mediante el método **get_Item()**.
1. Acceder y mostrar información como la posición, nivel y texto del [**Nodo hijo**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--).
```php
  # Instanciar la presentación
  $pres = new Presentation();
  try {
    # Acceder a la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Añadir la forma SmartArt en la primera diapositiva
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # Acceder al nodo SmartArt en el índice 0
    $node = $smart->getAllNodes()->get_Item(0);
    # Acceder al nodo hijo en la posición 1 del nodo padre
    $position = 1;
    $chNode = $node->getChildNodes()->get_Item($position);
    # Imprimir los parámetros del nodo hijo SmartArt
    System->out->print("Text = " . $chNode->getTextFrame()->getText() . ",  Level = " . $chNode->getLevel() . ", Position = " . $chNode->getPosition());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Eliminar un nodo SmartArt**
En este ejemplo aprenderemos a eliminar los nodos dentro de la forma SmartArt.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) y cargar la presentación con la forma SmartArt.
1. Obtener la referencia de la primera diapositiva mediante su índice.
1. Recorrer cada forma dentro de la primera diapositiva.
1. Comprobar si la forma es de tipo [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) y convertir la forma seleccionada a [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) si es SmartArt.
1. Comprobar si el [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) tiene más de 0 nodos.
1. Seleccionar el nodo SmartArt que se eliminará.
1. Ahora, eliminar el nodo seleccionado mediante el método [**RemoveNode**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) .
1. Guardar la presentación.
```php
  # Cargar la presentación deseada
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Recorrer cada forma dentro de la primera diapositiva
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Comprobar si la forma es de tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Convertir la forma a SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # Acceder al nodo SmartArt en el índice 0
          $node = $smart->getAllNodes()->get_Item(0);
          # Eliminar el nodo seleccionado
          $smart->getAllNodes()->removeNode($node);
        }
      }
    }
    # Guardar la presentación
    $pres->save("RemoveSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Eliminar un nodo SmartArt en una posición específica**
En este ejemplo aprenderemos a eliminar los nodos dentro de la forma SmartArt en una posición concreta.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) y cargar la presentación con la forma SmartArt.
1. Obtener la referencia de la primera diapositiva mediante su índice.
1. Recorrer cada forma dentro de la primera diapositiva.
1. Comprobar si la forma es de tipo [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) y convertir la forma seleccionada a [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) si es SmartArt.
1. Seleccionar el nodo de la forma SmartArt en el índice 0.
1. Ahora, comprobar si el nodo SmartArt seleccionado tiene más de 2 nodos hijos.
1. Ahora, eliminar el nodo en la **Posición 1** mediante el método [**RemoveNode**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#removeNode-int-) .
1. Guardar la presentación.
```php
  # Cargar la presentación deseada
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # Recorrer cada forma dentro de la primera diapositiva
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Comprobar si la forma es de tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Convertir la forma a SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # Acceder al nodo SmartArt en el índice 0
          $node = $smart->getAllNodes()->get_Item(0);
          if (java_values($node->getChildNodes()->size()) >= 2) {
            # Eliminar el nodo hijo en la posición 1
            $node->getChildNodes()->removeNode(1);
          }
        }
      }
    }
    # Guardar la presentación
    $pres->save("RemoveSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Establecer una posición personalizada para un nodo hijo en un objeto SmartArt**
Ahora Aspose.Slides for PHP via Java admite la configuración de las propiedades [SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setX-float-) y [Y](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setY-float-). El fragmento de código a continuación muestra cómo establecer la posición, el tamaño y la rotación personalizados de SmartArtShape; también tenga en cuenta que añadir nuevos nodos provoca un recálculo de las posiciones y tamaños de todos los nodos. Con la configuración de posición personalizada, el usuario puede establecer los nodos según los requisitos.
```php
  # Instanciar la clase Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(20, 20, 600, 500, SmartArtLayoutType::OrganizationChart);
    # Mover la forma SmartArt a una nueva posición
    $node = $smart->getAllNodes()->get_Item(1);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setX($shape->getX() . $shape->getWidth() * 2);
    $shape->setY($shape->getY() - $shape->getHeight() * 2);
    # Cambiar los anchos de la forma SmartArt
    $node = $smart->getAllNodes()->get_Item(2);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setWidth($shape->getWidth() . $shape->getWidth() * 2);
    # Cambiar la altura de la forma SmartArt
    $node = $smart->getAllNodes()->get_Item(3);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setHeight($shape->getHeight() . $shape->getHeight() * 2);
    # Cambiar la rotación de la forma SmartArt
    $node = $smart->getAllNodes()->get_Item(4);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setRotation(90);
    $pres->save("SmartArt.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **Comprobar un nodo asistente**
{{% alert color="primary" %}}

En este artículo investigaremos más a fondo las características de las formas SmartArt añadidas en diapositivas de presentación de forma programática usando Aspose.Slides for PHP via Java.

{{% /alert %}}

Utilizaremos la siguiente forma SmartArt de origen para nuestra investigación en distintas secciones de este artículo.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figura: Forma SmartArt de origen en la diapositiva**|

En el siguiente código de ejemplo investigaremos cómo identificar **nodos asistente** en la colección de nodos SmartArt y cambiarlos.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) y cargar la presentación con la forma SmartArt.
1. Obtener la referencia de la segunda diapositiva mediante su índice.
1. Recorrer cada forma dentro de la primera diapositiva.
1. Comprobar si la forma es de tipo [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) y convertir la forma seleccionada a [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) si es SmartArt.
1. Recorrer todos los nodos dentro de la forma SmartArt y comprobar si son [**Nodos asistente**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode#isAssistant--).
1. Cambiar el estado del nodo asistente a nodo normal.
1. Guardar la presentación.
```php
  # Crear una instancia de presentación
  $pres = new Presentation("AddNodes.pptx");
  try {
    # Recorrer cada forma dentro de la primera diapositiva
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # Comprobar si la forma es de tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Convertir la forma a SmartArt
        $smart = $shape;
        # Recorrer todos los nodos de la forma SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          $node = $smart->getAllNodes()->get_Item($i);
          # Comprobar si el nodo es un nodo Asistente
          if ($node->isAssistant()) {
            # Establecer el nodo Asistente a falso y convertirlo en un nodo normal
            $node->isAssistant();
          }
        }
      }
    }
    # Guardar la presentación
    $pres->save("ChangeAssitantNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figura: Nodos asistente cambiados en la forma SmartArt dentro de la diapositiva**|

## **Establecer el formato de relleno de un nodo**
Aspose.Slides for PHP via Java hace posible añadir formas SmartArt personalizadas y establecer su formato de relleno. Este artículo explica cómo crear y acceder a formas SmartArt y establecer su formato de relleno usando Aspose.Slides for PHP via Java.

Siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Obtener la referencia de una diapositiva mediante su índice.
1. Añadir una forma [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) estableciendo su [**LayoutType**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess).
1. Establecer el [**FillFormat**](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getFillFormat--) para los nodos de la forma SmartArt.
1. Guardar la presentación modificada como archivo PPTX.
```php
  # Instanciar la presentación
  $pres = new Presentation();
  try {
    # Acceder a la diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Añadir forma SmartArt y nodos
    $chevron = $slide->getShapes()->addSmartArt(10, 10, 800, 60, SmartArtLayoutType::ClosedChevronProcess);
    $node = $chevron->getAllNodes()->addNode();
    $node->getTextFrame()->setText("Some text");
    # Establecer el color de relleno del nodo
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


## **Generar una miniatura de un nodo hijo SmartArt**
Los desarrolladores pueden generar una miniatura del nodo hijo de un SmartArt siguiendo los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. [Añadir SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--).
1. Obtener la referencia de un nodo mediante su índice.
1. Obtener la imagen en miniatura.
1. Guardar la imagen en miniatura en el formato de imagen deseado.
```php
  # Instanciar la clase Presentation que representa el archivo PPTX
  $pres = new Presentation();
  try {
    # Añadir SmartArt
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
    # Obtener la referencia de un nodo usando su índice
    $node = $smart->getNodes()->get_Item(1);
    # Obtener la miniatura
    $slideImage = $node->getShapes()->get_Item(0)->getImage();
    # Guardar la miniatura
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


## **FAQ**

**¿Se admite la animación de SmartArt?**

Sí. SmartArt se trata como una forma normal, por lo que puede [aplicar animaciones estándar](/slides/es/php-java/shape-animation/) (entrada, salida, énfasis, rutas de movimiento) y ajustar la sincronización. También puede animar formas dentro de los nodos SmartArt cuando sea necesario.

**¿Cómo puedo localizar de forma fiable un SmartArt específico en una diapositiva si su ID interno es desconocido?**

Asigne y busque mediante [texto alternativo](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/). Establecer un AltText distintivo en el SmartArt permite encontrarlo programáticamente sin depender de identificadores internos.

**¿Se preservará la apariencia del SmartArt al convertir la presentación a PDF?**

Sí. Aspose.Slides renderiza SmartArt con alta fidelidad visual durante la [exportación a PDF](/slides/es/php-java/convert-powerpoint-to-pdf/), preservando el diseño, colores y efectos.

**¿Puedo extraer una imagen de todo el SmartArt (para vistas previas o informes)?**

Sí. Puede renderizar una forma SmartArt a [formatos rasterizados](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) o a [SVG](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) para salida vectorial escalable, lo que la hace adecuada para miniaturas, informes o uso web.