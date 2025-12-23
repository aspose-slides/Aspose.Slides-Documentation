---
title: Administrar Zoom de Presentación en PHP
linktitle: Administrar Zoom
type: docs
weight: 60
url: /es/php-java/manage-zoom/
keywords:
- zoom
- marco de zoom
- zoom de diapositiva
- zoom de sección
- zoom de resumen
- agregar zoom
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Cree y personalice Zoom con Aspose.Slides para PHP vía Java - cambie entre secciones, agregue miniaturas y transiciones en presentaciones PPT, PPTX y ODP."
---

## **Visión general**
Los Zoom en PowerPoint le permiten saltar a y desde diapositivas, secciones y partes específicas de una presentación. Cuando está presentando, esta capacidad de navegar rápidamente por el contenido puede resultar muy útil. 

![overview_image](overview.png)

* Para resumir toda una presentación en una sola diapositiva, use un [Zoom de resumen](#Summary-Zoom).
* Para mostrar solo diapositivas seleccionadas, use un [Zoom de diapositiva](#Slide-Zoom).
* Para mostrar solo una sección, use un [Zoom de sección](#Section-Zoom).

## **Zoom de diapositiva**
Un zoom de diapositiva puede hacer su presentación más dinámica, permitiéndole navegar libremente entre diapositivas en cualquier orden que elija sin interrumpir el flujo de su presentación. Los zoom de diapositiva son excelentes para presentaciones cortas sin muchas secciones, pero aún puede utilizarlos en diferentes escenarios de presentación.

Los zoom de diapositiva le ayudan a profundizar en múltiples piezas de información mientras siente que está en un único lienzo. 

![overview_image](slidezoomsel.png)

Para los objetos de zoom de diapositiva, Aspose.Slides proporciona la enumeración [ZoomImageType](https://reference.aspose.com/slides/php-java/aspose.slides/ZoomImageType), la interfaz [IZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IZoomFrame) y algunos métodos bajo la interfaz [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).

### **Crear marcos de zoom**

Puede agregar un marco de zoom a una diapositiva de esta manera:

1.	Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2.	Crear nuevas diapositivas a las que pretende enlazar los marcos de zoom. 
3.	Agregar un texto de identificación y un fondo a las diapositivas creadas.
4.	Agregar marcos de zoom (que contienen referencias a las diapositivas creadas) a la primera diapositiva.
5.	Guardar la presentación modificada como un archivo PPTX.

Este código PHP le muestra cómo crear un marco de zoom en una diapositiva:
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
    $autoshape->getTextFrame()->setText("Second Slide");
    # Crea un fondo para la tercera diapositiva
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # Crea un cuadro de texto para la tercera diapositiva
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
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

### **Crear marcos de zoom con imágenes personalizadas**
Con Aspose.Slides for PHP via Java, puede crear un marco de zoom con una imagen de vista previa de diapositiva diferente de esta manera:
1.	Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2.	Crear una nueva diapositiva a la que pretenda enlazar el marco de zoom. 
3.	Agregar un texto de identificación y un fondo a la diapositiva.
4.	Crear un objeto [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) añadiendo una imagen a la colección Images asociada con el objeto [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) que se usará para rellenar el marco.
5.	Agregar marcos de zoom (que contienen la referencia a la diapositiva creada) a la primera diapositiva.
6.	Guardar la presentación modificada como un archivo PPTX.

Este código PHP le muestra cómo crear un marco de zoom con una imagen diferente:
```php
  $pres = new Presentation();
  try {
    # Agrega una nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # Crea un fondo para la segunda diapositiva
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Crea un cuadro de texto para la tercera diapositiva
    $autoshape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
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

### **Dar formato a los marcos de zoom**
En las secciones anteriores, le mostramos cómo crear marcos de zoom simples. Para crear marcos de zoom más complejos, debe modificar el formato de un marco simple. Existen varias opciones de formato que puede aplicar a un marco de zoom. 

Puede controlar el formato de un marco de zoom en una diapositiva de esta manera:

1.	Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2.	Crear nuevas diapositivas a enlazar a las que pretenda enlazar el marco de zoom. 
3.	Agregar algún texto de identificación y un fondo a las diapositivas creadas.
4.	Agregar marcos de zoom (que contienen referencias a las diapositivas creadas) a la primera diapositiva.
5.	Crear un objeto [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) añadiendo una imagen a la colección Images asociada con el objeto [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) que se usará para rellenar el marco.
6.	Establecer una imagen personalizada para el primer objeto de marco de zoom.
7.	Cambiar el formato de línea para el segundo objeto de marco de zoom.
8.	Eliminar el fondo de una imagen del segundo objeto de marco de zoom.
5.	Guardar la presentación modificada como un archivo PPTX.

Este código PHP le muestra cómo cambiar el formato de un marco de zoom en una diapositiva:
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
    $autoshape->getTextFrame()->setText("Second Slide");
    # Crea un fondo para la tercera diapositiva
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # Crea un cuadro de texto para la tercera diapositiva
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
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

Un zoom de sección es un enlace a una sección de su presentación. Puede usar los zoom de sección para volver a secciones que desea enfatizar realmente. O puede usarlos para resaltar cómo ciertas partes de su presentación se conectan. 

![overview_image](seczoomsel.png)

Para los objetos de zoom de sección, Aspose.Slides proporciona la interfaz [ISectionZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ISectionZoomFrame) y algunos métodos bajo la interfaz [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).

### **Crear marcos de zoom de sección**

Puede agregar un marco de zoom de sección a una diapositiva de esta manera:

1.	Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2.	Crear una nueva diapositiva. 
3.	Agregar un fondo de identificación a la diapositiva creada.
4.	Crear una nueva sección a la que pretenda enlazar el marco de zoom. 
5.	Agregar un marco de zoom de sección (que contiene referencias a la sección creada) a la primera diapositiva.
6.	Guardar la presentación modificada como un archivo PPTX.

Este código PHP le muestra cómo crear un marco de zoom en una diapositiva:
```php
  $pres = new Presentation();
  try {
    # Agrega una nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Agrega una nueva sección a la presentación
    $pres->getSections()->addSection("Section 1", $slide);
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

### **Crear marcos de zoom de sección con imágenes personalizadas**

Usando Aspose.Slides for PHP via Java, puede crear un marco de zoom de sección con una imagen de vista previa de diapositiva diferente de esta manera:

1.	Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2.	Crear una nueva diapositiva.
3.	Agregar un fondo de identificación a la diapositiva creada.
4.	Crear una nueva sección a la que pretenda enlazar el marco de zoom. 
5.	Crear un objeto [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) añadiendo una imagen a la colección Images asociada con el objeto [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) que se usará para rellenar el marco.
5.	Agregar un marco de zoom de sección (que contiene una referencia a la sección creada) a la primera diapositiva.
6.	Guardar la presentación modificada como un archivo PPTX.

Este código PHP le muestra cómo crear un marco de zoom con una imagen diferente:
```php
  $pres = new Presentation();
  try {
    # Agrega nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Agrega una nueva sección a la presentación
    $pres->getSections()->addSection("Section 1", $slide);
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

### **Dar formato a los marcos de zoom de sección**

Para crear marcos de zoom de sección más complejos, debe modificar el formato de un marco simple. Existen varias opciones de formato que puede aplicar a un marco de zoom de sección. 

Puede controlar el formato de un marco de zoom de sección en una diapositiva de esta manera:

1.	Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2.	Crear una nueva diapositiva.
3.	Agregar un fondo de identificación a la diapositiva creada.
4.	Crear una nueva sección a la que pretenda enlazar el marco de zoom. 
5.	Agregar un marco de zoom de sección (que contiene referencias a la sección creada) a la primera diapositiva.
6.	Cambiar el tamaño y la posición del objeto de zoom de sección creado.
7.	Crear un objeto [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) añadiendo una imagen a la colección Images asociada con el objeto [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) que se usará para rellenar el marco.
8.	Establecer una imagen personalizada para el objeto de marco de zoom de sección creado.
9.	Establecer la capacidad de *volver a la diapositiva original desde la sección enlazada*. 
10.	Eliminar el fondo de una imagen del objeto de zoom de sección.
11.	Cambiar el formato de línea para el segundo objeto de marco de zoom.
12.	Cambiar la duración de la transición.
13.	Guardar la presentación modificada como un archivo PPTX.

Este código PHP le muestra cómo cambiar el formato de un marco de zoom de sección:
```php
  $pres = new Presentation();
  try {
    # Agrega una nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Agrega una nueva sección a la presentación
    $pres->getSections()->addSection("Section 1", $slide);
    # Agrega un objeto SectionZoomFrame
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

Un zoom de resumen es como una página de inicio donde todas las piezas de su presentación se muestran a la vez. Cuando está presentando, puede usar el zoom para pasar de un lugar de su presentación a otro en cualquier orden que desee. Puede ser creativo, adelantar o volver a visitar partes de su presentación sin interrumpir el flujo de la misma.

![overview_image](sumzoomsel.png)

Para los objetos de zoom de resumen, Aspose.Slides proporciona las interfaces [ISummaryZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSection) y [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSectionCollection) y algunos métodos bajo la interfaz [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).

### **Crear un zoom de resumen**

Puede agregar un marco de zoom de resumen a una diapositiva de esta manera:

1.	Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2.	Crear nuevas diapositivas con fondo de identificación y nuevas secciones para las diapositivas creadas.
3.	Agregar el marco de zoom de resumen a la primera diapositiva.
4.	Guardar la presentación modificada como un archivo PPTX.

Este código PHP le muestra cómo crear un marco de zoom de resumen en una diapositiva:
```php
  $pres = new Presentation();
  try {
    # Agrega una nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Agrega una nueva sección a la presentación
    $pres->getSections()->addSection("Section 1", $slide);
    # Agrega una nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Agrega una nueva sección a la presentación
    $pres->getSections()->addSection("Section 2", $slide);
    # Agrega una nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Agrega una nueva sección a la presentación
    $pres->getSections()->addSection("Section 3", $slide);
    # Agrega una nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->green);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Agrega una nueva sección a la presentación
    $pres->getSections()->addSection("Section 4", $slide);
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


### **Agregar y eliminar una sección de zoom de resumen**

Todas las secciones en un marco de zoom de resumen están representadas por objetos [ISummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSection), que se almacenan en el objeto [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISummaryZoomSectionCollection). Puede agregar o eliminar un objeto de sección de zoom de resumen a través de la interfaz [ISummaryZoomSectionCollection] de esta manera:

1.	Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2.	Crear nuevas diapositivas con fondo de identificación y nuevas secciones para las diapositivas creadas.
3.	Agregar un marco de zoom de resumen a la primera diapositiva.
4.	Agregar una nueva diapositiva y sección a la presentación.
5.	Agregar la sección creada al marco de zoom de resumen.
6.	Eliminar la primera sección del marco de zoom de resumen.
7.	Guardar la presentación modificada como un archivo PPTX.

Este código PHP le muestra cómo agregar y eliminar secciones en un marco de zoom de resumen:
```php
  $pres = new Presentation();
  try {
    # Agrega una nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Agrega una nueva sección a la presentación
    $pres->getSections()->addSection("Section 1", $slide);
    # Agrega una nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Agrega una nueva sección a la presentación
    $pres->getSections()->addSection("Section 2", $slide);
    # Agrega un objeto SummaryZoomFrame
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Agrega una nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Agrega una nueva sección a la presentación
    $section3 = $pres->getSections()->addSection("Section 3", $slide);
    # Agrega una sección al Summary Zoom
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


### **Dar formato a las secciones de zoom de resumen**

Para crear objetos de sección de zoom de resumen más complejos, debe modificar el formato de un marco simple. Existen varias opciones de formato que puede aplicar a un objeto de sección de zoom de resumen. 

Puede controlar el formato de un objeto de sección de zoom de resumen en un marco de zoom de resumen de esta manera:

1.	Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2.	Crear nuevas diapositivas con fondo de identificación y nuevas secciones para las diapositivas creadas.
3.	Agregar un marco de zoom de resumen a la primera diapositiva.
4.	Obtener un objeto de sección de zoom de resumen para el primer objeto de la `ISummaryZoomSectionCollection`.
7.	Crear un objeto [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) añadiendo una imagen a la colección images asociada con el objeto [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) que se usará para rellenar el marco.
8.	Establecer una imagen personalizada para el objeto de marco de zoom de sección creado.
9.	Establecer la capacidad de *volver a la diapositiva original desde la sección enlazada*. 
11.	Cambiar el formato de línea para el segundo objeto de marco de zoom.
12.	Cambiar la duración de la transición.
13.	Guardar la presentación modificada como un archivo PPTX.

Este código PHP le muestra cómo cambiar el formato de un objeto de sección de zoom de resumen:
```php
  $pres = new Presentation();
  try {
    # Agrega una nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Agrega una nueva sección a la presentación
    $pres->getSections()->addSection("Section 1", $slide);
    # Agrega una nueva diapositiva a la presentación
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Agrega una nueva sección a la presentación
    $pres->getSections()->addSection("Section 2", $slide);
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


## **FAQ**

**¿Puedo controlar el regreso a la diapositiva “principal” después de mostrar el objetivo?**

Sí. El [Zoom frame](https://reference.aspose.com/slides/php-java/aspose.slides/zoomframe/) o la [sección](https://reference.aspose.com/slides/php-java/aspose.slides/sectionzoomframe/) tiene un comportamiento `ReturnToParent` que, cuando está habilitado, envía a los espectadores de regreso a la diapositiva de origen después de visitar el contenido objetivo.

**¿Puedo ajustar la “velocidad” o duración de la transición del Zoom?**

Sí. Zoom permite establecer un `TransitionDuration` para que pueda controlar cuánto tiempo tarda la animación de salto.

**¿Existen límites en la cantidad de objetos Zoom que una presentación puede contener?**

No hay un límite de API duro documentado. Los límites prácticos dependen de la complejidad total de la presentación y del rendimiento del visor. Puede agregar muchos marcos de Zoom, pero considere el tamaño del archivo y el tiempo de renderizado.