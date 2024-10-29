---
title: Administrar Zoom
type: docs
weight: 60
url: /es/php-java/manage-zoom/
keywords: "Zoom, marco de zoom, agregar zoom, formato del marco de zoom, resumen de zoom, presentación de PowerPoint, Java, Aspose.Slides para PHP a través de Java"
description: "Agregar zoom o marcos de zoom a presentaciones de PowerPoint"
---

## **Descripción General**
Los zooms en PowerPoint te permiten saltar hacia y desde diapositivas, secciones y partes específicas de una presentación. Cuando estás presentando, esta capacidad de navegar rápidamente a través del contenido puede resultar muy útil.

![overview_image](overview.png)

* Para resumir toda una presentación en una sola diapositiva, utiliza un [Resumen de Zoom](#Resumen-de-Zoom).
* Para mostrar solo diapositivas seleccionadas, utiliza un [Zoom de Diapositiva](#Zoom-de-Diapositiva).
* Para mostrar solo una sección, utiliza un [Zoom de Sección](#Zoom-de-Sección).

## **Zoom de Diapositiva**
Un zoom de diapositiva puede hacer que tu presentación sea más dinámica, permitiéndote navegar libremente entre diapositivas en el orden que elijas sin interrumpir el flujo de tu presentación. Los zooms de diapositiva son excelentes para presentaciones cortas sin muchas secciones, pero aún puedes usarlos en diferentes escenarios de presentación.

Los zooms de diapositiva te ayudan a profundizar en múltiples piezas de información mientras sientes que estás en un solo lienzo.

![overview_image](slidezoomsel.png)

Para los objetos de zoom de diapositiva, Aspose.Slides proporciona la enumeración [ZoomImageType](https://reference.aspose.com/slides/php-java/aspose.slides/ZoomImageType), la interfaz [IZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IZoomFrame) y algunos métodos bajo la interfaz [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).

### **Creando Marcos de Zoom**

Puedes agregar un marco de zoom en una diapositiva de esta manera:

1.	Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2.	Crea nuevas diapositivas a las que pretendes vincular los marcos de zoom.
3.	Agrega un texto de identificación y un fondo a las diapositivas creadas.
4.  Agrega marcos de zoom (que contienen las referencias a las diapositivas creadas) a la primera diapositiva.
5.	Escribe la presentación modificada como un archivo PPTX.

Este código PHP te muestra cómo crear un marco de zoom en una diapositiva:

```php
  $pres = new Presentation();
  try {
    # Agrega nuevas diapositivas a la presentación
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Crea un fondo para la segunda diapositiva
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Crea un cuadro de texto para la segunda diapositiva
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Segunda Diapositiva");
    # Crea un fondo para la tercera diapositiva
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # Crea un cuadro de texto para la tercera diapositiva
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Tercer Diapositiva");
    # Agrega objetos ZoomFrame
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # Guarda la presentación
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Creando Marcos de Zoom con Imágenes Personalizadas**
Con Aspose.Slides para PHP a través de Java, puedes crear un marco de zoom con una imagen de vista previa de diapositiva diferente de esta manera:
1.	Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2.	Crea una nueva diapositiva a la que pretendes vincular el marco de zoom.
3.	Agrega un texto de identificación y un fondo a la diapositiva.
4.  Crea un objeto [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) agregando una imagen a la colección Images asociada con el objeto [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) que se usará para llenar el marco.
5.  Agrega marcos de zoom (que contienen la referencia a la diapositiva creada) a la primera diapositiva.
6.	Escribe la presentación modificada como un archivo PPTX.

Este código PHP te muestra cómo crear un marco de zoom con una imagen diferente:

```php
  $pres = new Presentation();
  try {
    # Agrega una nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Crea un fondo para la segunda diapositiva
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Crea un cuadro de texto para la segunda diapositiva
    $autoshape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Segunda Diapositiva");
    # Crea una nueva imagen para el objeto zoom
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Agrega el objeto ZoomFrame
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 300, 200, $slide, $picture);
    # Guarda la presentación
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Formateando Marcos de Zoom**
En las secciones anteriores, te mostramos cómo crear marcos de zoom simples. Para crear marcos de zoom más complejos, tienes que alterar el formato de un marco simple. Hay varias opciones de formato que puedes aplicar a un marco de zoom.

Puedes controlar el formato de un marco de zoom en una diapositiva de esta manera:

1.	Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2.	Crea nuevas diapositivas a las que pretendes vincular el marco de zoom.
3.	Agrega algo de texto de identificación y fondo a las diapositivas creadas.
4.  Agrega marcos de zoom (que contienen las referencias a las diapositivas creadas) a la primera diapositiva.
5.  Crea un objeto [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) agregando una imagen a la colección Images asociada con el objeto [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) que se usará para llenar el marco.
6.  Establece una imagen personalizada para el primer objeto de zoom frame.
7.  Cambia el formato de línea para el segundo objeto de zoom frame.
8.  Elimina el fondo de una imagen del segundo objeto de zoom frame.
5.	Escribe la presentación modificada como un archivo PPTX.

Este código PHP te muestra cómo cambiar el formato de un marco de zoom en una diapositiva:

```php
  $pres = new Presentation();
  try {
    # Agrega nuevas diapositivas a la presentación
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Crea un fondo para la segunda diapositiva
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Crea un cuadro de texto para la segunda diapositiva
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Segunda Diapositiva");
    # Crea un fondo para la tercera diapositiva
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # Crea un cuadro de texto para la tercera diapositiva
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Tercer Diapositiva");
    # Agrega objetos ZoomFrame
    $zoomFrame1 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $zoomFrame2 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # Crea una nueva imagen para el objeto de zoom
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Establece una imagen personalizada para el objeto zoomFrame1
    $zoomFrame1->setImage($picture);
    # Establece un formato de zoom frame para el objeto zoomFrame2
    $zoomFrame2->getLineFormat()->setWidth(5);
    $zoomFrame2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $zoomFrame2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->pink);
    $zoomFrame2->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    # Configuración para No mostrar fondo para el objeto zoomFrame2
    $zoomFrame2->setShowBackground(false);
    # Guarda la presentación
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Zoom de Sección**

Un zoom de sección es un enlace a una sección en tu presentación. Puedes usar zoom de sección para volver a secciones que realmente deseas enfatizar. O puedes usarlos para resaltar cómo ciertas partes de tu presentación se conectan.

![overview_image](seczoomsel.png)

Para los objetos de zoom de sección, Aspose.Slides proporciona la interfaz [ISectionZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ISectionZoomFrame) y algunos métodos bajo la interfaz [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).

### **Creando Marcos de Zoom de Sección**

Puedes agregar un marco de zoom de sección a una diapositiva de esta manera:

1.	Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2.	Crea una nueva diapositiva.
3.	Agrega un fondo de identificación a la diapositiva creada.
4.  Crea una nueva sección a la que pretendes vincular el marco de zoom.
5.  Agrega un marco de zoom de sección (que contenga referencias a la sección creada) a la primera diapositiva.
6.	Escribe la presentación modificada como un archivo PPTX.

Este código PHP te muestra cómo crear un marco de zoom en una diapositiva:

```php
  $pres = new Presentation();
  try {
    # Agrega una nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Agrega una nueva Sección a la presentación
    $pres->getSections()->addSection("Sección 1", $slide);
    # Agrega un objeto SectionZoomFrame
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # Guarda la presentación
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Creando Marcos de Zoom de Sección con Imágenes Personalizadas**

Utilizando Aspose.Slides para PHP a través de Java, puedes crear un marco de zoom de sección con una imagen de vista previa de diapositiva diferente de esta manera:

1.	Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2.	Crea una nueva diapositiva.
3.	Agrega un fondo de identificación a la diapositiva creada.
4.	Crea una nueva sección a la que pretendes vincular el marco de zoom.
5.  Crea un objeto [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) agregando una imagen a la colección Images asociada con el objeto [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) que se usará para llenar el marco.
5.  Agrega un marco de zoom de sección (que contenga una referencia a la sección creada) a la primera diapositiva.
6.	Escribe la presentación modificada como un archivo PPTX.

Este código PHP te muestra cómo crear un marco de zoom con una imagen diferente:

```php
  $pres = new Presentation();
  try {
    # Agrega nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Agrega una nueva Sección a la presentación
    $pres->getSections()->addSection("Sección 1", $slide);
    # Crea una nueva imagen para el objeto zoom
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Agrega objeto SectionZoomFrame
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1), $picture);
    # Guarda la presentación
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Formateando Marcos de Zoom de Sección**

Para crear marcos de zoom de sección más complicados, debes alterar el formato de un marco simple. Hay varias opciones de formato que puedes aplicar a un marco de zoom de sección.

Puedes controlar el formato de un marco de zoom de sección en una diapositiva de esta manera:

1.	Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2.	Crea una nueva diapositiva.
3.	Agrega un fondo de identificación a la diapositiva creada.
4.	Crea una nueva sección a la que pretendes vincular el marco de zoom.
5.	Agrega un marco de zoom de sección (que contenga referencias a la sección creada) a la primera diapositiva.
6.	Cambia el tamaño y la posición del objeto de zoom de sección creado.
7.	Crea un objeto [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) agregando una imagen a la colección Images asociada con el objeto [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) que se usará para llenar el marco.
8.	Establece una imagen personalizada para el objeto de marco de zoom de sección creado.
9.	Establece la capacidad de *volver a la diapositiva original desde la sección vinculada*.
10.	Elimina el fondo de una imagen del objeto de marco de zoom de sección.
11.	Cambia el formato de línea para el segundo objeto de zoom frame.
12.	Cambia la duración de la transición.
13.	Escribe la presentación modificada como un archivo PPTX.

Este código PHP te muestra cómo cambiar el formato de un marco de zoom de sección:

```php
  $pres = new Presentation();
  try {
    # Agrega una nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Agrega una nueva Sección a la presentación
    $pres->getSections()->addSection("Sección 1", $slide);
    # Agrega un objeto SectionZoomFrame
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # Formato para SectionZoomFrame
    $sectionZoomFrame->setX(100);
    $sectionZoomFrame->setY(300);
    $sectionZoomFrame->setWidth(100);
    $sectionZoomFrame->setHeight(75);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $sectionZoomFrame->setImage($picture);
    $sectionZoomFrame->setReturnToParent(true);
    $sectionZoomFrame->setShowBackground(false);
    $sectionZoomFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $sectionZoomFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $sectionZoomFrame->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $sectionZoomFrame->getLineFormat()->setWidth(2.5);
    $sectionZoomFrame->setTransitionDuration(1.5);
    # Guarda la presentación
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Resumen de Zoom**

Un resumen de zoom es como una página de aterrizaje donde se muestran todas las piezas de tu presentación a la vez. Cuando estás presentando, puedes usar el zoom para ir de un lugar en tu presentación a otro en cualquier orden que desees. Puedes ser creativo, saltar hacia adelante o volver a piezas de tu presentación sin interrumpir el flujo de tu presentación.

![overview_image](sumzoomsel.png)

Para los objetos de resumen de zoom, Aspose.Slides proporciona las interfaces [ISummaryZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSection) y [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSectionCollection) y algunos métodos bajo la interfaz [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).

### **Creando Resumen de Zoom**

Puedes agregar un marco de resumen de zoom a una diapositiva de esta manera:

1.	Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2.	Crea nuevas diapositivas con un fondo de identificación y nuevas secciones para las diapositivas creadas.
3.  Agrega el marco de resumen de zoom a la primera diapositiva.
4.	Escribe la presentación modificada como un archivo PPTX.

Este código PHP te muestra cómo crear un marco de resumen de zoom en una diapositiva:

```php
  $pres = new Presentation();
  try {
    # Agrega una nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Agrega una nueva sección a la presentación
    $pres->getSections()->addSection("Sección 1", $slide);
    # Agrega una nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Agrega una nueva sección a la presentación
    $pres->getSections()->addSection("Sección 2", $slide);
    # Agrega una nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Agrega una nueva sección a la presentación
    $pres->getSections()->addSection("Sección 3", $slide);
    # Agrega una nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->green);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Agrega una nueva sección a la presentación
    $pres->getSections()->addSection("Sección 4", $slide);
    # Agrega un objeto SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Guarda la presentación
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Agregando y Eliminando Sección de Resumen de Zoom**

Todas las secciones en un marco de resumen de zoom están representadas por objetos [ISummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSection), que se almacenan en el objeto [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSectionCollection). Puedes agregar o eliminar un objeto de sección de resumen de zoom a través de la interfaz [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSectionCollection) de esta manera:

1.	Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2.	Crea nuevas diapositivas con un fondo de identificación y nuevas secciones para las diapositivas creadas.
3.  Agrega un marco de resumen de zoom a la primera diapositiva.
4.  Agrega una nueva diapositiva y sección a la presentación.
5.  Agrega la sección creada al marco de resumen de zoom.
6.  Elimina la primera sección del marco de resumen de zoom.
7.	Escribe la presentación modificada como un archivo PPTX.

Este código PHP te muestra cómo agregar y eliminar secciones en un marco de resumen de zoom:

```php
  $pres = new Presentation();
  try {
    # Agrega una nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Agrega una nueva sección a la presentación
    $pres->getSections()->addSection("Sección 1", $slide);
    # Agrega una nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Agrega una nueva sección a la presentación
    $pres->getSections()->addSection("Sección 2", $slide);
    # Agrega objeto SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Agrega una nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Agrega una nueva sección a la presentación
    $section3 = $pres->getSections()->addSection("Sección 3", $slide);
    # Agrega una sección al Resumen de Zoom
    $summaryZoomFrame->getSummaryZoomCollection()->addSummaryZoomSection($section3);
    # Elimina sección del Resumen de Zoom
    $summaryZoomFrame->getSummaryZoomCollection()->removeSummaryZoomSection($pres->getSections()->get_Item(1));
    # Guarda la presentación
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Formateando Secciones de Resumen de Zoom**

Para crear objetos de sección de resumen de zoom más complicados, debes alterar el formato de un marco simple. Hay varias opciones de formato que puedes aplicar a un objeto de sección de resumen de zoom.

Puedes controlar el formato de un objeto de sección de resumen de zoom en un marco de resumen de zoom de esta manera:

1.	Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2.	Crea nuevas diapositivas con un fondo de identificación y nuevas secciones para las diapositivas creadas.
3.  Agrega un marco de resumen de zoom a la primera diapositiva.
4.  Obtén un objeto de sección de resumen de zoom para el primer objeto de la `ISummaryZoomSectionCollection`.
7.  Crea un objeto [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) agregando una imagen a la colección de imágenes asociada con el objeto [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) que se usará para llenar el marco.
8.  Establece una imagen personalizada para el objeto de marco de sección de resumen creado.
9.  Establece la capacidad de *volver a la diapositiva original desde la sección vinculada*.
11. Cambia el formato de línea para el segundo objeto de zoom frame.
12. Cambia la duración de la transición.
13.	Escribe la presentación modificada como un archivo PPTX.

Este código PHP te muestra cómo cambiar el formato para un objeto de sección de resumen de zoom:

```php
  $pres = new Presentation();
  try {
    # Agrega una nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Agrega una nueva sección a la presentación
    $pres->getSections()->addSection("Sección 1", $slide);
    # Agrega una nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Agrega una nueva sección a la presentación
    $pres->getSections()->addSection("Sección 2", $slide);
    # Agrega un objeto SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Obtiene el primer objeto SummaryZoomSection
    $summarySection = $summaryZoomFrame->getSummaryZoomCollection()->get_Item(0);
    # Formato para el objeto SummaryZoomSection
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($picture);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $summarySection->setImage($picture);
    $summarySection->setReturnToParent(false);
    $summarySection->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $summarySection->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->black);
    $summarySection->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $summarySection->getLineFormat()->setWidth(1.5);
    $summarySection->setTransitionDuration(1.5);
    # Guarda la presentación
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```