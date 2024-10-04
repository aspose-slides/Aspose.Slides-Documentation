---
title: Gestionar la forma SmartArt
type: docs
weight: 20
url: /es/php-java/manage-smartart-shape/
---


## **Crear forma SmartArt**
Aspose.Slides para PHP a través de Java ha proporcionado una API para crear formas SmartArt. Para crear una forma SmartArt en una diapositiva, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtenga la referencia de una diapositiva utilizando su índice.
1. [Agregue una forma SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) estableciendo su [LayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType).
1. Guarde la presentación modificada como un archivo PPTX.

```php
  # Instanciar clase Presentation
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Agregar forma Smart Art
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::BasicBlockList);
    # Guardando presentación
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

## **Acceder a la forma SmartArt en la diapositiva**
El siguiente código se utilizará para acceder a las formas SmartArt agregadas en la diapositiva de la presentación. En el código de ejemplo, recorreremos cada forma dentro de la diapositiva y verificaremos si es una forma de [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt). Si la forma es del tipo SmartArt, la convertiremos a una instancia de [**SmartArt**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt).

```php
  # Cargar la presentación deseada
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Recorrer cada forma dentro de la primera diapositiva
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Verificar si la forma es del tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Convertir la forma a SmartArtEx
        $smart = $shape;
        echo("Nombre de la forma:" . $smart->getName());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Acceder a la forma SmartArt con un tipo de diseño particular**
El siguiente código de ejemplo ayudará a acceder a la forma de [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) con un LayoutType particular: tenga en cuenta que no puede cambiar el LayoutType del SmartArt, ya que es de solo lectura y se establece solo cuando se agrega la forma de [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt).

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) y cargue la presentación con la forma SmartArt.
1. Obtenga la referencia de la primera diapositiva utilizando su índice.
1. Recorra cada forma dentro de la primera diapositiva.
1. Verifique si la forma es del tipo [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) y convierta la forma seleccionada a SmartArt si es SmartArt.
1. Verifique la forma SmartArt con un LayoutType particular y realice lo que sea necesario hacer a continuación.

```php
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Recorrer cada forma dentro de la primera diapositiva
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Verificar si la forma es del tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Convertir la forma a SmartArtEx
        $smart = $shape;
        # Verificando el diseño de SmartArt
        if ($smart->getLayout() == SmartArtLayoutType::BasicBlockList) {
          echo("Hacer algo aquí....");
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Cambiar el estilo de la forma SmartArt**
En este ejemplo, aprenderemos a cambiar el estilo rápido para cualquier forma SmartArt.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) y cargue la presentación con la forma SmartArt.
1. Obtenga la referencia de la primera diapositiva utilizando su índice.
1. Recorra cada forma dentro de la primera diapositiva.
1. Verifique si la forma es del tipo [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) y convierta la forma seleccionada a SmartArt si es SmartArt.
1. Encuentre la forma SmartArt con un estilo particular.
1. Establezca el nuevo estilo para la forma SmartArt.
1. Guarde la presentación.

```php
  # Instanciar clase Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Obtener la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Recorrer cada forma dentro de la primera diapositiva
    foreach($slide->getShapes() as $shape) {
      # Verificar si la forma es del tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Convertir la forma a SmartArtEx
        $smart = $shape;
        # Verificando el estilo de SmartArt
        if ($smart->getQuickStyle() == SmartArtQuickStyleType::SimpleFill) {
          # Cambiando el estilo de SmartArt
          $smart->setQuickStyle(SmartArtQuickStyleType::Cartoon);
        }
      }
    }
    # Guardando presentación
    $pres->save("ChangeSmartArtStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figura: Forma SmartArt con estilo cambiado**|

## **Cambiar el estilo de color de la forma SmartArt**
En este ejemplo, aprenderemos a cambiar el estilo de color para cualquier forma SmartArt. En el siguiente código de ejemplo se accederá a la forma SmartArt con un estilo de color particular y se cambiará su estilo.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) y cargue la presentación con la forma SmartArt.
1. Obtenga la referencia de la primera diapositiva utilizando su índice.
1. Recorra cada forma dentro de la primera diapositiva.
1. Verifique si la forma es del tipo [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) y convierta la forma seleccionada a SmartArt si es SmartArt.
1. Encuentre la forma SmartArt con un estilo de color particular.
1. Establezca el nuevo estilo de color para la forma SmartArt.
1. Guarde la presentación.

```php
  # Instanciar clase Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Obtener la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Recorrer cada forma dentro de la primera diapositiva
    foreach($slide->getShapes() as $shape) {
      # Verificar si la forma es del tipo SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Convertir la forma a SmartArtEx
        $smart = $shape;
        # Verificando el tipo de color de SmartArt
        if ($smart->getColorStyle() == SmartArtColorType::ColoredFillAccent1) {
          # Cambiando el tipo de color de SmartArt
          $smart->setColorStyle(SmartArtColorType::ColorfulAccentColors);
        }
      }
    }
    # Guardando presentación
    $pres->save("ChangeSmartArtColorStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figura: Forma SmartArt con estilo de color cambiado**|