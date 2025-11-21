---
title: Administrar Zoom
type: docs
weight: 60
url: /es/nodejs-java/manage-zoom/
keywords: "Zoom, marco de Zoom, Agregar zoom, Formatear marco de Zoom, Zoom de resumen, presentación PowerPoint, Java, Aspose.Slides para Node.js a través de Java"
description: "Agregar zoom o marcos de zoom a presentaciones PowerPoint en JavaScript"
---

## **Visión general**

Los Zoom en PowerPoint le permiten saltar hacia y desde diapositivas específicas, secciones y partes de una presentación. Al estar presentando, esta capacidad de navegar rápidamente por el contenido puede resultar muy útil. 

![overview_image](overview.png)

* Para resumir una presentación completa en una sola diapositiva, use un [Summary Zoom](#Summary-Zoom).
* Para mostrar solo diapositivas seleccionadas, use un [Slide Zoom](#Slide-Zoom).
* Para mostrar solo una sección, use un [Section Zoom](#Section-Zoom).

## **Zoom de diapositiva**

Un zoom de diapositiva puede hacer que su presentación sea más dinámica, permitiéndole navegar libremente entre diapositivas en cualquier orden que elija sin interrumpir el flujo de su presentación. Los zoom de diapositiva son ideales para presentaciones cortas sin muchas secciones, pero también puede usarlos en diferentes escenarios de presentación.

Los zoom de diapositiva le ayudan a profundizar en múltiples piezas de información mientras siente que está en un solo lienzo. 

![overview_image](slidezoomsel.png)

Para objetos de zoom de diapositiva, Aspose.Slides proporciona la enumeración [ZoomImageType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ZoomImageType), la clase [ZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ZoomFrame) y algunos métodos bajo la clase [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).

### **Creación de marcos de zoom**

Puede agregar un marco de zoom en una diapositiva de esta manera:

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2.	Cree nuevas diapositivas a las que tenga la intención de enlazar los marcos de zoom. 
3.	Agregue un texto de identificación y un fondo a las diapositivas creadas.
4.	Agregue marcos de zoom (que contienen las referencias a las diapositivas creadas) a la primera diapositiva.
5.	Escriba la presentación modificada como un archivo PPTX.

Este código JavaScript le muestra cómo crear un marco de zoom en una diapositiva:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Agrega nuevas diapositivas a la presentación
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Crea un fondo para la segunda diapositiva
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Crea un cuadro de texto para la segunda diapositiva
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Crea un fondo para la tercera diapositiva
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // Crea un cuadro de texto para la tercera diapositiva
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // Agrega objetos ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // Guarda la presentación
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Creación de marcos de zoom con imágenes personalizadas**

Con Aspose.Slides para Node.js a través de Java, puede crear un marco de zoom con una imagen de vista previa de diapositiva diferente de esta manera:
1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2.	Cree una nueva diapositiva a la que tenga la intención de enlazar el marco de zoom. 
3.	Agregue un texto de identificación y un fondo a la diapositiva.
4.	Cree un objeto [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage) añadiendo una imagen a la colección Images asociada con el objeto [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) que se utilizará para rellenar el marco.
5.	Agregue marcos de zoom (que contienen la referencia a la diapositiva creada) a la primera diapositiva.
6.	Escriba la presentación modificada como un archivo PPTX.

Este código JavaScript le muestra cómo crear un marco de zoom con una imagen diferente:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Agrega una nueva diapositiva a la presentación
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Crea un fondo para la segunda diapositiva
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Crea un cuadro de texto para la tercera diapositiva
    var autoshape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Crea una nueva imagen para el objeto Zoom
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Agrega el objeto ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);
    // Guarda la presentación
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Formato de los marcos de zoom**

En las secciones anteriores, le mostramos cómo crear marcos de zoom simples. Para crear marcos de zoom más complejos, debe alterar el formato de un marco sencillo. Existen varias opciones de formato que puede aplicar a un marco de zoom. 

Puede controlar el formato de un marco de zoom en una diapositiva de esta manera:

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2.	Cree nuevas diapositivas a enlazar a las que tenga la intención de enlazar el marco de zoom. 
3.	Agregue algún texto de identificación y un fondo a las diapositivas creadas.
4.	Agregue marcos de zoom (que contienen las referencias a las diapositivas creadas) a la primera diapositiva.
5.	Cree un objeto [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage) añadiendo una imagen a la colección Images asociada con el objeto [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) que se utilizará para rellenar el marco.
6.	Establezca una imagen personalizada para el primer objeto de marco de zoom.
7.	Cambie el formato de línea para el segundo objeto de marco de zoom.
8.	Elimine el fondo de una imagen del segundo objeto de marco de zoom.
5.	Escriba la presentación modificada como un archivo PPTX.

Este código JavaScript le muestra cómo cambiar el formato de un marco de zoom en una diapositiva:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Agrega nuevas diapositivas a la presentación
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Crea un fondo para la segunda diapositiva
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Crea un cuadro de texto para la segunda diapositiva
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Crea un fondo para la tercera diapositiva
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // Crea un cuadro de texto para la tercera diapositiva
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // Agrega objetos ZoomFrame
    var zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    var zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // Crea una nueva imagen para el objeto Zoom
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Establece una imagen personalizada para el objeto zoomFrame1
    zoomFrame1.setImage(picture);
    // Establece un formato de marco de zoom para el objeto zoomFrame2
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "pink"));
    zoomFrame2.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // Configuración para no mostrar el fondo del objeto zoomFrame2
    zoomFrame2.setShowBackground(false);
    // Guarda la presentación
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Zoom de sección**

Un zoom de sección es un enlace a una sección de su presentación. Puede usar los zoom de sección para volver a secciones que desea enfatizar realmente. O puede utilizarlos para resaltar cómo ciertas partes de su presentación se conectan. 

![overview_image](seczoomsel.png)

Para objetos de zoom de sección, Aspose.Slides proporciona la clase [SectionZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SectionZoomFrame) y algunos métodos bajo la clase [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).

### **Creación de marcos de zoom de sección**

Puede agregar un marco de zoom de sección a una diapositiva de esta manera:

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2.	Cree una nueva diapositiva. 
3.	Agregue un fondo de identificación a la diapositiva creada.
4.	Cree una nueva sección a la que tenga la intención de enlazar el marco de zoom. 
5.	Agregue un marco de zoom de sección (que contiene referencias a la sección creada) a la primera diapositiva.
6.	Escriba la presentación modificada como un archivo PPTX.

Este código JavaScript le muestra cómo crear un marco de zoom en una diapositiva:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Agrega una nueva diapositiva a la presentación
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Agrega una nueva sección a la presentación
    pres.getSections().addSection("Section 1", slide);
    // Agrega un objeto SectionZoomFrame
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // Guarda la presentación
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Creación de marcos de zoom de sección con imágenes personalizadas**

Usando Aspose.Slides para Node.js a través de Java, puede crear un marco de zoom de sección con una imagen de vista previa de diapositiva diferente de esta manera:

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2.	Cree una nueva diapositiva.
3.	Agregue un fondo de identificación a la diapositiva creada.
4.	Cree una nueva sección a la que tenga la intención de enlazar el marco de zoom. 
5.	Cree un objeto [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage) añadiendo una imagen a la colección Images asociada con el objeto [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) que se utilizará para rellenar el marco.
5.	Agregue un marco de zoom de sección (que contiene una referencia a la sección creada) a la primera diapositiva.
6.	Escriba la presentación modificada como un archivo PPTX.

Este código JavaScript le muestra cómo crear un marco de zoom con una imagen diferente:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Agrega una nueva diapositiva a la presentación
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Agrega una nueva sección a la presentación
    pres.getSections().addSection("Section 1", slide);
    // Crea una nueva imagen para el objeto zoom
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Agrega un objeto SectionZoomFrame
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);
    // Guarda la presentación
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Formato de los marcos de zoom de sección**

Para crear marcos de zoom de sección más complejos, debe alterar el formato de un marco sencillo. Existen varias opciones de formato que puede aplicar a un marco de zoom de sección. 

Puede controlar el formato de un marco de zoom de sección en una diapositiva de esta manera:

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2.	Cree una nueva diapositiva.
3.	Agregue un fondo de identificación a la diapositiva creada.
4.	Cree una nueva sección a la que tenga la intención de enlazar el marco de zoom. 
5.	Agregue un marco de zoom de sección (que contiene referencias a la sección creada) a la primera diapositiva.
6.	Cambie el tamaño y la posición del objeto de zoom de sección creado.
7.	Cree un objeto [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage) añadiendo una imagen a la colección Images asociada con el objeto [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) que se utilizará para rellenar el marco.
8.	Establezca una imagen personalizada para el objeto de marco de zoom de sección creado.
9.	Establezca la capacidad de *volver a la diapositiva original desde la sección enlazada*. 
10.	Elimine el fondo de una imagen del objeto de marco de zoom de sección.
11.	Cambie el formato de línea para el segundo objeto de marco de zoom.
12.	Cambie la duración de la transición.
13.	Escriba la presentación modificada como un archivo PPTX.

Este código JavaScript le muestra cómo cambiar el formato de un marco de zoom de sección:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Agrega una nueva diapositiva a la presentación
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Agrega una nueva sección a la presentación
    pres.getSections().addSection("Section 1", slide);
    // Agregar objeto SectionZoomFrame
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // Formato para SectionZoomFrame
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    sectionZoomFrame.setImage(picture);
    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);
    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    sectionZoomFrame.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5);
    sectionZoomFrame.setTransitionDuration(1.5);
    // Guarda la presentación
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Zoom de resumen**

Un zoom de resumen es como una página de inicio donde se muestran todas las partes de su presentación a la vez. Cuando está presentando, puede usar el zoom para pasar de un lugar de su presentación a otro en cualquier orden que desee. Puede ser creativo, adelantarse o volver a visitar partes de su presentación sin interrumpir el flujo de la misma.

![overview_image](sumzoomsel.png)

Para objetos de zoom de resumen, Aspose.Slides proporciona las clases [SummaryZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SummaryZoomFrame), [SummaryZoomSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SummaryZoomSection) y [SummaryZoomSectionCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SummaryZoomSectionCollection) y algunos métodos bajo la clase [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).

### **Creación de zoom de resumen**

Puede agregar un marco de zoom de resumen a una diapositiva de esta manera:

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2.	Cree nuevas diapositivas con fondo de identificación y nuevas secciones para las diapositivas creadas.
3.	Agregue el marco de zoom de resumen a la primera diapositiva.
4.	Escriba la presentación modificada como un archivo PPTX.

Este código JavaScript le muestra cómo crear un marco de zoom de resumen en una diapositiva:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Agrega una nueva diapositiva a la presentación
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Agrega una nueva sección a la presentación
    pres.getSections().addSection("Section 1", slide);
    // Agrega una nueva diapositiva a la presentación
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Agrega una nueva sección a la presentación
    pres.getSections().addSection("Section 2", slide);
    // Agrega una nueva diapositiva a la presentación
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Agrega una nueva sección a la presentación
    pres.getSections().addSection("Section 3", slide);
    // Agrega una nueva diapositiva a la presentación
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "green"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Agrega una nueva sección a la presentación
    pres.getSections().addSection("Section 4", slide);
    // Agrega un objeto SummaryZoomFrame
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Guarda la presentación
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Agregar y eliminar secciones de zoom de resumen**

Todas las secciones en un marco de zoom de resumen están representadas por objetos [SummaryZoomSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SummaryZoomSection), que se almacenan en el objeto [SummaryZoomSectionCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SummaryZoomSectionCollection). Puede agregar o eliminar un objeto de sección de zoom de resumen a través de la clase [SummaryZoomSectionCollection] de esta manera:

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2.	Cree nuevas diapositivas con fondo de identificación y nuevas secciones para las diapositivas creadas.
3.	Agregue un marco de zoom de resumen a la primera diapositiva.
4.	Agregue una nueva diapositiva y sección a la presentación.
5.	Agregue la sección creada al marco de zoom de resumen.
6.	Elimine la primera sección del marco de zoom de resumen.
7.	Escriba la presentación modificada como un archivo PPTX.

Este código JavaScript le muestra cómo agregar y eliminar secciones en un marco de zoom de resumen:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Agrega una nueva diapositiva a la presentación
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Agrega una nueva sección a la presentación
    pres.getSections().addSection("Section 1", slide);
    // Agrega una nueva diapositiva a la presentación
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Agrega una nueva sección a la presentación
    pres.getSections().addSection("Section 2", slide);
    // Agrega un objeto SummaryZoomFrame
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Agrega una nueva diapositiva a la presentación
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Agrega una nueva sección a la presentación
    var section3 = pres.getSections().addSection("Section 3", slide);
    // Agrega una sección al Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);
    // Elimina la sección del Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));
    // Guarda la presentación
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Formato de las secciones de zoom de resumen**

Para crear objetos de sección de zoom de resumen más complejos, debe alterar el formato de un marco sencillo. Existen varias opciones de formato que puede aplicar a un objeto de sección de zoom de resumen. 

Puede controlar el formato de un objeto de sección de zoom de resumen en un marco de zoom de resumen de esta manera:

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2.	Cree nuevas diapositivas con fondo de identificación y nuevas secciones para las diapositivas creadas.
3.	Agregue un marco de zoom de resumen a la primera diapositiva.
4.	Obtenga un objeto de sección de zoom de resumen para el primer objeto de la `ISummaryZoomSectionCollection`.
7.	Cree un objeto [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage) añadiendo una imagen a la colección images asociada con el objeto [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) que se utilizará para rellenar el marco.
8.	Establezca una imagen personalizada para el objeto de marco de zoom de sección creado.
9.	Establezca la capacidad de *volver a la diapositiva original desde la sección enlazada*. 
11.	Cambie el formato de línea para el segundo objeto de marco de zoom.
12.	Cambie la duración de la transición.
13.	Escriba la presentación modificada como un archivo PPTX.

Este código JavaScript le muestra cómo cambiar el formato de un objeto de sección de zoom de resumen:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Agrega una nueva diapositiva a la presentación
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Agrega una nueva sección a la presentación
    pres.getSections().addSection("Section 1", slide);
    // Agrega una nueva diapositiva a la presentación
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Agrega una nueva sección a la presentación
    pres.getSections().addSection("Section 2", slide);
    // Agrega un objeto SummaryZoomFrame
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Obtiene el primer objeto SummaryZoomSection
    var summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);
    // Formato para el objeto SummaryZoomSection
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    summarySection.setImage(picture);
    summarySection.setReturnToParent(false);
    summarySection.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "black"));
    summarySection.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5);
    summarySection.setTransitionDuration(1.5);
    // Guarda la presentación
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**¿Puedo controlar el regreso a la diapositiva “padre” después de mostrar el objetivo?**

Sí. El [Zoom frame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomframe/) o [section](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sectionzoomframe/) tiene un método `setReturnToParent` que, cuando está habilitado, devuelve al espectador a la diapositiva de origen después de que visite el contenido objetivo.

**¿Puedo ajustar la “velocidad” o duración de la transición del Zoom?**

Sí. Zoom expone un método `setTransitionDuration` para que pueda controlar cuánto tiempo lleva la animación de salto.

**¿Existen límites en la cantidad de objetos Zoom que una presentación puede contener?**

No hay un límite API estrictamente documentado. Los límites prácticos dependen de la complejidad general de la presentación y del rendimiento del visor. Puede agregar muchos marcos de Zoom, pero considere el tamaño del archivo y el tiempo de renderizado.