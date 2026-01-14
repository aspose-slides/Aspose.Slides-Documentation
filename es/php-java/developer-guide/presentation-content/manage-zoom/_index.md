---
title: Gestionar Zoom de presentación en PHP
linktitle: Gestionar Zoom
type: docs
weight: 60
url: /es/php-java/manage-zoom/
keywords:
- zoom
- marco de zoom
- zoom de diapositiva
- zoom de sección
- zoom de resumen
- añadir zoom
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Crear y personalizar Zoom con Aspose.Slides para PHP mediante Java — saltar entre secciones, añadir miniaturas y transiciones en presentaciones PPT, PPTX y ODP."
---

## **Visión general**
Los Zoom en PowerPoint le permiten saltar hacia y desde diapositivas, secciones y partes específicas de una presentación. Cuando está presentando, esta capacidad de navegar rápidamente por el contenido puede resultar muy útil. 

![overview_image](overview.png)

* Para resumir una presentación completa en una sola diapositiva, use un [Zoom de resumen](#Summary-Zoom).
* Para mostrar sólo diapositivas seleccionadas, use un [Zoom de diapositiva](#Slide-Zoom).
* Para mostrar sólo una sección, use un [Zoom de sección](#Section-Zoom).

## **Zoom de diapositiva**
Un zoom de diapositiva puede hacer que su presentación sea más dinámica, permitiéndole navegar libremente entre diapositivas en el orden que elija sin interrumpir el flujo de la presentación. Los zooms de diapositiva son ideales para presentaciones breves sin muchas secciones, pero también pueden usarse en diferentes escenarios de presentación.

Los zooms de diapositiva le ayudan a profundizar en varios fragmentos de información mientras siente que está en un único lienzo. 

![overview_image](slidezoomsel.png)

Para los objetos de zoom de diapositiva, Aspose.Slides proporciona la enumeración [ZoomImageType](https://reference.aspose.com/slides/php-java/aspose.slides/zoomimagetype/), la clase [ZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/zoomframe/) y algunos métodos bajo la clase [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).

### **Crear marcos de zoom**

Puede añadir un marco de zoom en una diapositiva de esta forma:

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2.	Cree nuevas diapositivas a las que pretenda enlazar los marcos de zoom. 
3.	Añada un texto de identificación y fondo a las diapositivas creadas.
4.	Añada marcos de zoom (que contengan referencias a las diapositivas creadas) a la primera diapositiva.
5.	Guarde la presentación modificada como un archivo PPTX.

Este código PHP le muestra cómo crear un marco de zoom en una diapositiva:
```php
  $pres = new Presentation();
  try {
    # Añade nuevas diapositivas a la presentación
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Crea un fondo para la segunda diapositiva
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Crea un cuadro de texto para la segunda diapositiva
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Crea un fondo para la tercera diapositiva
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # Crea un cuadro de texto para la tercera diapositiva
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # Añade objetos ZoomFrame
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

### **Crear marcos de zoom con imágenes personalizadas**
Con Aspose.Slides para PHP mediante Java, puede crear un marco de zoom con una imagen de vista previa de diapositiva diferente de esta forma:
1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2.	Cree una nueva diapositiva a la que pretenda enlazar el marco de zoom. 
3.	Añada un texto de identificación y fondo a la diapositiva.
4.	Cree un objeto [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) añadiendo una imagen a la colección Images asociada al objeto [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) que se usará para rellenar el marco.
5.	Añada marcos de zoom (que contengan la referencia a la diapositiva creada) a la primera diapositiva.
6.	Guarde la presentación modificada como un archivo PPTX.

Este código PHP le muestra cómo crear un marco de zoom con una imagen diferente:
```php
  $pres = new Presentation();
  try {
    # Añade una nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Crea un fondo para la segunda diapositiva
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Crea un cuadro de texto para la tercera diapositiva
    $autoshape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Crea una nueva imagen para el objeto Zoom
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Añade el objeto ZoomFrame
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

### **Formato de los marcos de zoom**
En las secciones anteriores le mostramos cómo crear marcos de zoom simples. Para crear marcos de zoom más complejos, debe alterar el formato de un marco sencillo. Existen varias opciones de formato que puede aplicar a un marco de zoom. 

Puede controlar el formato de un marco de zoom en una diapositiva de esta forma:

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2.	Cree nuevas diapositivas a enlazar a las que pretenda enlazar el marco de zoom. 
3.	Añada algún texto de identificación y fondo a las diapositivas creadas.
4.	Añada marcos de zoom (que contengan referencias a las diapositivas creadas) a la primera diapositiva.
5.	Cree un objeto [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) añadiendo una imagen a la colección Images asociada al objeto [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) que se usará para rellenar el marco.
6.	Establezca una imagen personalizada para el primer objeto de marco de zoom.
7.	Cambie el formato de línea del segundo objeto de marco de zoom.
8.	Elimine el fondo de la imagen del segundo objeto de marco de zoom.
5.	Guarde la presentación modificada como un archivo PPTX.

Este código PHP le muestra cómo cambiar el formato de un marco de zoom en una diapositiva:
```php
  $pres = new Presentation();
  try {
    # Añade nuevas diapositivas a la presentación
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Crea un fondo para la segunda diapositiva
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Crea un cuadro de texto para la segunda diapositiva
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Crea un fondo para la tercera diapositiva
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # Crea un cuadro de texto para la tercera diapositiva
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # Añade objetos ZoomFrame
    $zoomFrame1 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $zoomFrame2 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
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
    # Establece una imagen personalizada para el objeto zoomFrame1
    $zoomFrame1->setImage($picture);
    # Establece un formato de marco de zoom para el objeto zoomFrame2
    $zoomFrame2->getLineFormat()->setWidth(5);
    $zoomFrame2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $zoomFrame2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->pink);
    $zoomFrame2->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    # Configuración para no mostrar el fondo del objeto zoomFrame2
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


## **Zoom de sección**

Un zoom de sección es un enlace a una sección de su presentación. Puede usar los zooms de sección para volver a secciones que desea destacar realmente. O puede usarlos para resaltar cómo ciertas partes de su presentación se conectan. 

![overview_image](seczoomsel.png)

Para los objetos de zoom de sección, Aspose.Slides proporciona la clase [SectionZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/sectionzoomframe/) y algunos métodos bajo la clase [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).

### **Crear marcos de zoom de sección**

Puede añadir un marco de zoom de sección a una diapositiva de esta forma:

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2.	Cree una nueva diapositiva. 
3.	Añada un fondo de identificación a la diapositiva creada.
4.	Cree una nueva sección a la que pretenda enlazar el marco de zoom. 
5.	Añada un marco de zoom de sección (que contenga referencias a la sección creada) a la primera diapositiva.
6.	Guarde la presentación modificada como un archivo PPTX.

Este código PHP le muestra cómo crear un marco de zoom en una diapositiva:
```php
  $pres = new Presentation();
  try {
    # Añade una nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Añade una nueva sección a la presentación
    $pres->getSections()->addSection("Section 1", $slide);
    # Añade un objeto SectionZoomFrame
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # Guarda la presentación
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Crear marcos de zoom de sección con imágenes personalizadas**

Usando Aspose.Slides para PHP mediante Java, puede crear un marco de zoom de sección con una imagen de vista previa de diapositiva diferente de esta forma:

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2.	Cree una nueva diapositiva.
3.	Añada un fondo de identificación a la diapositiva creada.
4.	Cree una nueva sección a la que pretenda enlazar el marco de zoom. 
5.	Cree un objeto [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) añadiendo una imagen a la colección Images asociada al objeto [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) que se usará para rellenar el marco.
5.	Añada un marco de zoom de sección (que contenga una referencia a la sección creada) a la primera diapositiva.
6.	Guarde la presentación modificada como un archivo PPTX.

Este código PHP le muestra cómo crear un marco de zoom con una imagen diferente:
```php
  $pres = new Presentation();
  try {
    # Añade una nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Añade una nueva sección a la presentación
    $pres->getSections()->addSection("Section 1", $slide);
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
    # Añade un objeto SectionZoomFrame
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

### **Formato de los marcos de zoom de sección**

Para crear marcos de zoom de sección más complejos, debe alterar el formato de un marco sencillo. Existen varias opciones de formato que puede aplicar a un marco de zoom de sección. 

Puede controlar el formato de un marco de zoom de sección en una diapositiva de esta forma:

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2.	Cree una nueva diapositiva.
3.	Añada un fondo de identificación a la diapositiva creada.
4.	Cree una nueva sección a la que pretenda enlazar el marco de zoom. 
5.	Añada un marco de zoom de sección (que contenga referencias a la sección creada) a la primera diapositiva.
6.	Cambie el tamaño y la posición del objeto de zoom de sección creado.
7.	Cree un objeto [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) añadiendo una imagen a la colección Images asociada al objeto [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) que se usará para rellenar el marco.
8.	Establezca una imagen personalizada para el objeto de marco de zoom de sección creado.
9.	Active la capacidad de *volver a la diapositiva original desde la sección enlazada*. 
10.	Elimine el fondo de la imagen del objeto de zoom de sección.
11.	Cambie el formato de línea del segundo objeto de marco de zoom.
12.	Cambie la duración de la transición.
13.	Guarde la presentación modificada como un archivo PPTX.

Este código PHP le muestra cómo cambiar el formato de un marco de zoom de sección:
```php
  $pres = new Presentation();
  try {
    # Añade una nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Añade una nueva sección a la presentación
    $pres->getSections()->addSection("Section 1", $slide);
    # Añade un objeto SectionZoomFrame
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # Formato del SectionZoomFrame
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



## **Zoom de resumen**

Un zoom de resumen es como una página de destino donde se muestran todos los elementos de su presentación a la vez. Cuando está presentando, puede usar el zoom para pasar de un punto de la presentación a otro en cualquier orden que desee. Puede ser creativo, avanzar rápidamente o volver a revisar partes de su espectáculo de diapositivas sin interrumpir el flujo de la presentación.

![overview_image](sumzoomsel.png)

Para los objetos de zoom de resumen, Aspose.Slides proporciona las clases [SummaryZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsection/) y [SummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsectioncollection/), así como algunos métodos bajo la clase [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).

### **Crear un zoom de resumen**

Puede añadir un marco de zoom de resumen a una diapositiva de esta forma:

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2.	Cree nuevas diapositivas con fondo de identificación y nuevas secciones para las diapositivas creadas.
3.	Añada el marco de zoom de resumen a la primera diapositiva.
4.	Guarde la presentación modificada como un archivo PPTX.

Este código PHP le muestra cómo crear un marco de zoom de resumen en una diapositiva:
```php
  $pres = new Presentation();
  try {
    # Añade una nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Añade una nueva sección a la presentación
    $pres->getSections()->addSection("Section 1", $slide);
    # Añade una nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Añade una nueva sección a la presentación
    $pres->getSections()->addSection("Section 2", $slide);
    # Añade una nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Añade una nueva sección a la presentación
    $pres->getSections()->addSection("Section 3", $slide);
    # Añade una nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->green);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Añade una nueva sección a la presentación
    $pres->getSections()->addSection("Section 4", $slide);
    # Añade un objeto SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Guarda la presentación
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Añadir y eliminar una sección de zoom de resumen**

Todas las secciones en un marco de zoom de resumen están representadas por objetos [SummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsection/), que se almacenan en el objeto [SummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsectioncollection/). Puede añadir o eliminar un objeto de sección de zoom de resumen a través de la clase [SummaryZoomSectionCollection] de esta forma:

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2.	Cree nuevas diapositivas con fondo de identificación y nuevas secciones para las diapositivas creadas.
3.	Añada un marco de zoom de resumen en la primera diapositiva.
4.	Añada una nueva diapositiva y sección a la presentación.
5.	Añada la sección creada al marco de zoom de resumen.
6.	Elimine la primera sección del marco de zoom de resumen.
7.	Guarde la presentación modificada como un archivo PPTX.

Este código PHP le muestra cómo añadir y eliminar secciones en un marco de zoom de resumen:
```php
  $pres = new Presentation();
  try {
    # Añade una nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Añade una nueva sección a la presentación
    $pres->getSections()->addSection("Section 1", $slide);
    # Añade una nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Añade una nueva sección a la presentación
    $pres->getSections()->addSection("Section 2", $slide);
    # Añade un objeto SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Añade una nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Añade una nueva sección a la presentación
    $section3 = $pres->getSections()->addSection("Section 3", $slide);
    # Añade una sección al Summary Zoom
    $summaryZoomFrame->getSummaryZoomCollection()->addSummaryZoomSection($section3);
    # Elimina la sección del Summary Zoom
    $summaryZoomFrame->getSummaryZoomCollection()->removeSummaryZoomSection($pres->getSections()->get_Item(1));
    # Guarda la presentación
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Formato de las secciones de zoom de resumen**

Para crear objetos de sección de zoom de resumen más complejos, debe alterar el formato de un marco sencillo. Existen varias opciones de formato que puede aplicar a un objeto de sección de zoom de resumen. 

Puede controlar el formato de un objeto de sección de zoom de resumen en un marco de zoom de resumen de esta forma:

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2.	Cree nuevas diapositivas con fondo de identificación y nuevas secciones para las diapositivas creadas.
3.	Añada un marco de zoom de resumen a la primera diapositiva.
4.	Obtenga un objeto de sección de zoom de resumen para el primer objeto de la `SummaryZoomSectionCollection`.
7.	Cree un objeto [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) añadiendo una imagen a la colección images asociada al objeto [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) que se usará para rellenar el marco.
8.	Establezca una imagen personalizada para el objeto de marco de sección de zoom creado.
9.	Active la capacidad de *volver a la diapositiva original desde la sección enlazada*. 
11.	Cambie el formato de línea del segundo objeto de marco de zoom.
12.	Cambie la duración de la transición.
13.	Guarde la presentación modificada como un archivo PPTX.

Este código PHP le muestra cómo cambiar el formato de un objeto de sección de zoom de resumen:
```php
  $pres = new Presentation();
  try {
    # Añade una nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Añade una nueva sección a la presentación
    $pres->getSections()->addSection("Section 1", $slide);
    # Añade una nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Añade una nueva sección a la presentación
    $pres->getSections()->addSection("Section 2", $slide);
    # Añade un objeto SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Obtiene el primer objeto SummaryZoomSection
    $summarySection = $summaryZoomFrame->getSummaryZoomCollection()->get_Item(0);
    # Formato del objeto SummaryZoomSection
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


## **FAQ**

**¿Puedo controlar el regreso a la diapositiva “padre” después de mostrar el objetivo?**

Sí. El [Zoom frame](https://reference.aspose.com/slides/php-java/aspose.slides/zoomframe/) o la [section](https://reference.aspose.com/slides/php-java/aspose.slides/sectionzoomframe/) tiene un comportamiento `ReturnToParent` que, cuando está habilitado, devuelve al espectador a la diapositiva de origen tras visitar el contenido objetivo.

**¿Puedo ajustar la “velocidad” o duración de la transición de Zoom?**

Sí. Zoom permite establecer un `TransitionDuration` para que pueda controlar cuánto dura la animación del salto.

**¿Existen límites en la cantidad de objetos Zoom que una presentación puede contener?**

No hay un límite duro documentado en la API. Los límites prácticos dependen de la complejidad total de la presentación y del rendimiento del visor. Puede añadir muchos marcos de zoom, pero tenga en cuenta el tamaño del archivo y el tiempo de renderizado.