---
title: Gestionar SmartArt en presentaciones de PowerPoint usando PHP
linktitle: Gestionar SmartArt
type: docs
weight: 10
url: /es/php-java/manage-smartart/
keywords:
- SmartArt
- texto de SmartArt
- tipo de diseño
- propiedad oculta
- diagrama organizativo
- diagrama organizativo de imagen
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Aprende a crear y editar SmartArt de PowerPoint con Aspose.Slides para PHP a través de Java usando ejemplos de código claros que aceleran el diseño de diapositivas y la automatización."
---

## **Obtener texto de un objeto SmartArt**
Ahora se ha añadido el método TextFrame a la interfaz [ISmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtShape) y a la clase [SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape) respectivamente. Esta propiedad le permite obtener todo el texto de [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) si no sólo contiene texto de nodos. El siguiente fragmento de código le ayudará a obtener texto de un nodo de SmartArt.
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


## **Cambiar el tipo de diseño de un objeto SmartArt**
Para cambiar el tipo de diseño de [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Obtenga la referencia de una diapositiva mediante su índice.
- Añada [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList.
- Cambie [LayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#setLayout-int-) a BasicProcess.
- Guarde la presentación como un archivo PPTX.

En el ejemplo que sigue, hemos añadido un conector entre dos formas.
```php
  $pres = new Presentation();
  try {
    # Añadir SmartArt BasicProcess
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


## **Comprobar la propiedad Oculto de un objeto SmartArt**
Tenga en cuenta: el método [ISmartArtNode.isHidden()]((https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#isHidden--)) devuelve true si este nodo es un nodo oculto en el modelo de datos. Para comprobar la propiedad oculta de cualquier nodo de [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Añada [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle.
- Añada un nodo en SmartArt.
- Compruebe la propiedad [isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#isHidden--) .
- Guarde la presentación como un archivo PPTX.

En el ejemplo que sigue, hemos añadido un conector entre dos formas.
```php
  $pres = new Presentation();
  try {
    # Añadir SmartArt BasicProcess
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
    # Añadir nodo en SmartArt
    $node = $smart->getAllNodes()->addNode();
    # Comprobar la propiedad isHidden
    $hidden = $node->isHidden();// Devuelve true

    if ($hidden) {
      # Realizar alguna acción o notificación
    }
    # Guardar presentación
    $pres->save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Obtener o establecer el tipo de diagrama organizacional**
Los métodos [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getOrganizationChartLayout--) y [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) permiten obtener o establecer el tipo de diagrama organizacional asociado al nodo actual. Para obtener o establecer el tipo de diagrama organizacional siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Añada [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) en la diapositiva.
- Obtenga o [set the organization chart type](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-).
- Guarde la presentación como un archivo PPTX.

En el ejemplo que sigue, hemos añadido un conector entre dos formas.
```php
  $pres = new Presentation();
  try {
    # Añadir SmartArt BasicProcess
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
    # Obtener o establecer el tipo de diagrama organizacional
    $smart->getNodes()->get_Item(0)->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);
    # Guardar presentación
    $pres->save("OrganizeChartLayoutType_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Crear un diagrama organizacional de imagen**
Aspose.Slides for PHP via Java ofrece una API sencilla para crear diagramas de PictureOrganization de forma fácil. Para crear un diagrama en una diapositiva:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva mediante su índice.
3. Añada un diagrama con datos predeterminados junto con el tipo deseado (ChartType::PictureOrganizationChart).
4. Guarde la presentación modificada en un archivo PPTX

El siguiente código se utiliza para crear un diagrama.
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
Para cambiar el tipo de diseño de [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Añada [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) en la diapositiva.
3. [Get](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#isReversed--) o [Set](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#setReversed-boolean-) el estado del diagrama SmartArt.
4. Guarde la presentación como un archivo PPTX.

El siguiente código se utiliza para crear un diagrama.
```php
  # Instanciar la clase Presentation que representa el archivo PPTX
  $pres = new Presentation();
  try {
    # Añadir SmartArt BasicProcess
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicProcess);
    # Obtener o establecer el estado del diagrama SmartArt
    $smart->setReversed(true);
    $flag = $smart->isReversed();
    # Guardar la presentación
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**¿SmartArt admite espejado/inversión para idiomas RTL?**

Sí. El método [setReversed](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/) cambia la dirección del diagrama (LTR/RTL) si el tipo de SmartArt seleccionado admite la inversión.

**¿Cómo puedo copiar SmartArt a la misma diapositiva o a otra presentación conservando el formato?**

Puede [clone the SmartArt shape](/slides/es/php-java/shape-manipulations/) a través de la colección de formas ([ShapeCollection.addClone](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addclone/)) o [clone the entire slide](/slides/es/php-java/clone-slides/) que contiene esta forma. Ambos enfoques conservan el tamaño, la posición y el estilo.

**¿Cómo renderizo SmartArt a una imagen raster para vista previa o exportación web?**

[Render the slide](/slides/es/php-java/convert-powerpoint-to-png/) (o la presentación completa) a PNG/JPEG mediante la API que convierte diapositivas/presentaciones en imágenes; SmartArt se dibujará como parte de la diapositiva.

**¿Cómo puedo seleccionar programáticamente un SmartArt específico en una diapositiva si hay varios?**

Una práctica habitual es usar [alternative text](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) (Alt Text) o un [name](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getname/) y buscar la forma por ese atributo dentro de [slide shapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes), luego comprobar el tipo para confirmar que es [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/). La documentación describe técnicas típicas para encontrar y trabajar con formas.