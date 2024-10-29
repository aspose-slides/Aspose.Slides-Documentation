---
title: Gestionar SmartArt
type: docs
weight: 10
url: /es/php-java/manage-smartart/
---

## **Obtener texto de SmartArt**
Ahora el método TextFrame se ha agregado a la interfaz [ISmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtShape) y a la clase [SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape) respectivamente. Esta propiedad te permite obtener todo el texto de [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) si no solo tiene texto de nodos. El siguiente código de muestra te ayudará a obtener texto de un nodo de SmartArt.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $smartArt = $slide->getShapes()->get_Item(0);
    $smartArtNodes = $smartArt->getAllNodes();
    foreach($smartArtNodes as $smartArtNode) {
      foreach($smartArtNode->getShapes() as $nodeShape) {
        if (!java_is_null($nodeShape->getTextFrame())) {
          echo($nodeShape->getTextFrame()->getText());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Cambiar el tipo de diseño de SmartArt**
Para cambiar el tipo de diseño de [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt). Por favor, sigue los pasos a continuación:

- Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Obtén la referencia de una diapositiva usando su índice.
- Agrega [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList.
- Cambia el [LayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#setLayout-int-) a BasicProcess.
- Escribe la presentación como un archivo PPTX.
  En el ejemplo dado a continuación, hemos agregado un conector entre dos formas.

```php
  $pres = new Presentation();
  try {
    # Agregar SmartArt BasicProcess
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
    # Cambiar LayoutType a BasicProcess
    $smart->setLayout(SmartArtLayoutType::BasicProcess);
    # Guardar presentación
    $pres->save("ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Comprobar la propiedad oculta de SmartArt**
Por favor, ten en cuenta: el método [ISmartArtNode.isHidden()](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#isHidden--) devuelve verdadero si este nodo es un nodo oculto en el modelo de datos. Para comprobar la propiedad oculta de cualquier nodo de [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt). Por favor, sigue los pasos a continuación:

- Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Agrega [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle.
- Agrega un nodo en SmartArt.
- Comprueba la propiedad [isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#isHidden--).
- Escribe la presentación como un archivo PPTX.

En el ejemplo dado a continuación, hemos agregado un conector entre dos formas.

```php
  $pres = new Presentation();
  try {
    # Agregar SmartArt BasicProcess
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
    # Agregar nodo en SmartArt
    $node = $smart->getAllNodes()->addNode();
    # Comprobar propiedad isHidden
    $hidden = $node->isHidden();// Devuelve verdadero

    if ($hidden) {
      # Realizar algunas acciones o notificaciones
    }
    # Guardar presentación
    $pres->save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Obtener o establecer el tipo de organigrama**
Los métodos [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getOrganizationChartLayout--), [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) permiten obtener o establecer el tipo de organigrama asociado con el nodo actual. Para obtener o establecer el tipo de organigrama. Por favor, sigue los pasos a continuación:

- Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Agrega [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) en la diapositiva.
- Obtén o [establece el tipo de organigrama](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-).
- Escribe la presentación como un archivo PPTX.
  En el ejemplo dado a continuación, hemos agregado un conector entre dos formas.

```php
  $pres = new Presentation();
  try {
    # Agregar SmartArt BasicProcess
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
    # Obtener o Establecer el tipo de organigrama
    $smart->getNodes()->get_Item(0)->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);
    # Guardar presentación
    $pres->save("OrganizeChartLayoutType_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Crear un organigrama de imágenes**
Aspose.Slides para PHP vía Java proporciona una API simple para crear gráficos y organigramas de imágenes de manera sencilla. Para crear un gráfico en una diapositiva:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtén la referencia de una diapositiva por su índice.
1. Agrega un gráfico con datos predeterminados junto con el tipo deseado (ChartType::PictureOrganizationChart).
1. Escribe la presentación modificada en un archivo PPTX.

El siguiente código se utiliza para crear un gráfico.

```php
  $pres = new Presentation("test.pptx");
  try {
    $smartArt = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);
    $pres->save("OrganizationChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Obtener o establecer el estado de SmartArt**
Para cambiar el tipo de diseño de [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt). Por favor, sigue los pasos a continuación:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Agrega [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) en la diapositiva.
1. [Obtén](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#isReversed--) o [Establece](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#setReversed-boolean-) el estado del Diagrama SmartArt.
1. Escribe la presentación como un archivo PPTX.

El siguiente código se utiliza para crear un gráfico.

```php
  # Instanciar la clase Presentation que representa el archivo PPTX
  $pres = new Presentation();
  try {
    # Agregar SmartArt BasicProcess
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicProcess);
    # Obtener o Establecer el estado del Diagrama SmartArt
    $smart->setReversed(true);
    $flag = $smart->isReversed();
    # Guardar presentación
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```