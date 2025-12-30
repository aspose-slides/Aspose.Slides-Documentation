---
title: Administrar gráficos SmartArt en presentaciones usando PHP
linktitle: Gráficos SmartArt
type: docs
weight: 20
url: /es/php-java/manage-smartart-shape/
keywords:
- Objeto SmartArt
- Gráfico SmartArt
- Estilo SmartArt
- Color SmartArt
- Crear SmartArt
- Añadir SmartArt
- Editar SmartArt
- Cambiar SmartArt
- Acceder a SmartArt
- Tipo de diseño SmartArt
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Automatiza la creación, edición y estilo de SmartArt en PowerPoint usando PHP con Aspose.Slides, con ejemplos de código concisos y guía centrada en el rendimiento."
---

## **Crear una forma SmartArt**
Aspose.Slides for PHP via Java ha proporcionado una API para crear formas SmartArt. Para crear una forma SmartArt en una diapositiva, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtener la referencia de una diapositiva mediante su índice.
1. [Agregar una forma SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) estableciendo su [LayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType).
1. Guardar la presentación modificada como un archivo PPTX.
```php
  # Instanciar la clase Presentation
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Añadir forma SmartArt
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::BasicBlockList);
    # Guardar la presentación
    $pres->save("SimpleSmartArt.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figura: Forma SmartArt añadida a la diapositiva**|

## **Acceder a una forma SmartArt en una diapositiva**
El siguiente código se utilizará para acceder a las formas SmartArt añadidas en la diapositiva de la presentación. En el código de ejemplo recorreremos cada forma dentro de la diapositiva y comprobaremos si es una forma [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt). Si la forma es de tipo SmartArt, la convertiremos a una instancia de **SmartArt**.
```php
  # Cargar la presentación deseada
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Recorrer cada forma dentro de la primera diapositiva
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Comprobar si la forma es de tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Convertir la forma a SmartArtEx
        $smart = $shape;
        echo("Shape Name:" . $smart->getName());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Acceder a una forma SmartArt con un tipo de diseño concreto**
El siguiente código de ejemplo ayudará a acceder a la forma [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) con un LayoutType concreto. Tenga en cuenta que no puede cambiar el LayoutType del SmartArt, ya que es de solo lectura y se establece únicamente cuando se añade la forma [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt).

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) y cargar la presentación con la forma SmartArt.
1. Obtener la referencia de la primera diapositiva mediante su índice.
1. Recorrer cada forma dentro de la primera diapositiva.
1. Comprobar si la forma es de tipo [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) y, si lo es, convertir la forma seleccionada a SmartArt.
1. Comprobar la forma SmartArt con el LayoutType concreto y realizar las operaciones necesarias a continuación.
```php
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Recorrer cada forma dentro de la primera diapositiva
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Comprobar si la forma es de tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Convertir la forma a SmartArtEx
        $smart = $shape;
        # Comprobando el diseño de SmartArt
        if ($smart->getLayout() == SmartArtLayoutType::BasicBlockList) {
          echo("Do some thing here....");
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Cambiar el estilo de una forma SmartArt**
En este ejemplo aprenderemos a cambiar el estilo rápido de cualquier forma SmartArt.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) y cargar la presentación con la forma SmartArt.
1. Obtener la referencia de la primera diapositiva mediante su índice.
1. Recorrer cada forma dentro de la primera diapositiva.
1. Comprobar si la forma es de tipo [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) y, si lo es, convertir la forma seleccionada a SmartArt.
1. Encontrar la forma SmartArt con el estilo concreto.
1. Establecer el nuevo estilo para la forma SmartArt.
1. Guardar la presentación.
```php
  # Instanciar la clase Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Obtener la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Recorrer cada forma dentro de la primera diapositiva
    foreach($slide->getShapes() as $shape) {
      # Comprobar si la forma es de tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Convertir la forma a SmartArtEx
        $smart = $shape;
        # Comprobando el estilo de SmartArt
        if ($smart->getQuickStyle() == SmartArtQuickStyleType::SimpleFill) {
          # Cambiando el estilo de SmartArt
          $smart->setQuickStyle(SmartArtQuickStyleType::Cartoon);
        }
      }
    }
    # Guardar la presentación
    $pres->save("ChangeSmartArtStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figura: Forma SmartArt con estilo cambiado**|

## **Cambiar el estilo de color de una forma SmartArt**
En este ejemplo aprenderemos a cambiar el estilo de color de cualquier forma SmartArt. En el código de ejemplo se accederá a la forma SmartArt con un estilo de color concreto y se modificará su estilo.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) y cargar la presentación con la forma SmartArt.
1. Obtener la referencia de la primera diapositiva mediante su índice.
1. Recorrer cada forma dentro de la primera diapositiva.
1. Comprobar si la forma es de tipo [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) y, si lo es, convertir la forma seleccionada a SmartArt.
1. Encontrar la forma SmartArt con el estilo de color concreto.
1. Establecer el nuevo estilo de color para la forma SmartArt.
1. Guardar la presentación.
```php
  # Instanciar la clase Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Obtener la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Recorrer cada forma dentro de la primera diapositiva
    foreach($slide->getShapes() as $shape) {
      # Comprobar si la forma es de tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Convertir la forma a SmartArtEx
        $smart = $shape;
        # Comprobando el tipo de color de SmartArt
        if ($smart->getColorStyle() == SmartArtColorType::ColoredFillAccent1) {
          # Cambiando el tipo de color de SmartArt
          $smart->setColorStyle(SmartArtColorType::ColorfulAccentColors);
        }
      }
    }
    # Guardar la presentación
    $pres->save("ChangeSmartArtColorStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figura: Forma SmartArt con estilo de color cambiado**|

## **Preguntas frecuentes**

**¿Puedo animar SmartArt como un único objeto?**

Sí. SmartArt es una forma, por lo que puede aplicar [animaciones estándar](/slides/es/php-java/powerpoint-animation/) mediante la API de animaciones (entrada, salida, énfasis, trayectorias de movimiento) igual que con otras formas.

**¿Cómo puedo encontrar un SmartArt específico en una diapositiva si no conozco su ID interno?**

Establezca y utilice el Texto alternativo (AltText) y busque la forma por ese valor; es una forma recomendada de localizar la forma objetivo.

**¿Puedo agrupar SmartArt con otras formas?**

Sí. Puede agrupar SmartArt con otras formas (imágenes, tablas, etc.) y luego [manipular el grupo](/slides/es/php-java/group/).

**¿Cómo obtengo una imagen de un SmartArt específico (por ejemplo, para una vista previa o informe)?**

Exporte una miniatura/imagen de la forma; la biblioteca puede [representar formas individuales](/slides/es/php-java/create-shape-thumbnails/) en archivos raster (PNG/JPG/TIFF).

**¿Se conservará la apariencia de SmartArt al convertir toda la presentación a PDF?**

Sí. El motor de renderizado apunta a alta fidelidad para la [exportación a PDF](/slides/es/php-java/convert-powerpoint-to-pdf/), con una variedad de opciones de calidad y compatibilidad.