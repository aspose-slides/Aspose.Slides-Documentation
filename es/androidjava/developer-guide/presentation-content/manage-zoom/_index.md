---
title: Gestionar Zoom de Presentación en Android
linktitle: Gestionar Zoom
type: docs
weight: 60
url: /es/androidjava/manage-zoom/
keywords:
- zoom
- marco de zoom
- zoom de diapositiva
- zoom de sección
- zoom de resumen
- agregar zoom
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Crear y personalizar Zoom con Aspose.Slides para Android mediante Java — saltar entre secciones, agregar miniaturas y transiciones en presentaciones PPT, PPTX y ODP."
---

## **Descripción general**
Los Zoom en PowerPoint le permiten saltar a y desde diapositivas, secciones y porciones específicas de una presentación. Cuando está presentando, esta capacidad de navegar rápidamente por el contenido puede resultar muy útil. 

![overview_image](overview.png)

* Para resumir una presentación completa en una sola diapositiva, use un [Zoom de Resumen](#Summary-Zoom).
* Para mostrar solo diapositivas seleccionadas, use un [Zoom de Diapositiva](#Slide-Zoom).
* Para mostrar solo una sección, use un [Zoom de Sección](#Section-Zoom).

## **Zoom de Diapositiva**
Un zoom de diapositiva puede hacer que su presentación sea más dinámica, permitiéndole navegar libremente entre diapositivas en cualquier orden que elija sin interrumpir el flujo de su presentación. Los zooms de diapositiva son ideales para presentaciones cortas sin muchas secciones, pero también puede utilizarlos en diferentes escenarios de presentación.

Los zooms de diapositiva le ayudan a profundizar en múltiples piezas de información mientras siente que está en un solo lienzo. 

![overview_image](slidezoomsel.png)

Para los objetos de zoom de diapositiva, Aspose.Slides proporciona la enumeración [ZoomImageType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ZoomImageType), la interfaz [IZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IZoomFrame) y algunos métodos bajo la interfaz [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).

### **Crear marcos de Zoom**

Puede añadir un marco de zoom en una diapositiva de esta manera:

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2.	Cree nuevas diapositivas a las que pretenda enlazar los marcos de zoom. 
3.	Agregue un texto de identificación y un fondo a las diapositivas creadas.
4.	Agregue marcos de zoom (conteniendo referencias a las diapositivas creadas) a la primera diapositiva.
5.	Escriba la presentación modificada como un archivo PPTX.

Este código Java le muestra cómo crear un marco de zoom en una diapositiva:
``` java
Presentation pres = new Presentation();
try {
    //Agrega nuevas diapositivas a la presentación
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Crea un fondo para la segunda diapositiva
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Crea un cuadro de texto para la segunda diapositiva
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Crea un fondo para la tercera diapositiva
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Crea un cuadro de texto para la tercera diapositiva
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //Agrega objetos ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Guarda la presentación
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Crear marcos de Zoom con imágenes personalizadas**
Con Aspose.Slides para Android vía Java, puede crear un marco de zoom con una imagen de vista previa diferente de la diapositiva de esta manera:
1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2.	Cree una nueva diapositiva a la que pretenda enlazar el marco de zoom. 
3.	Agregue un texto de identificación y un fondo a la diapositiva.
4.	Cree un objeto [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) añadiendo una imagen a la colección Images asociada al objeto [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) que se usará para rellenar el marco.
5.	Agregue marcos de zoom (conteniendo la referencia a la diapositiva creada) a la primera diapositiva.
6.	Escriba la presentación modificada como un archivo PPTX.

Este código Java le muestra cómo crear un marco de zoom con una imagen diferente:
``` java
Presentation pres = new Presentation();
try {
    //Agrega una nueva diapositiva a la presentación
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Crea un fondo para la segunda diapositiva
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Crea un cuadro de texto para la tercera diapositiva
    IAutoShape autoshape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Crea una nueva imagen para el objeto Zoom
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    //Agrega el objeto ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    // Guarda la presentación
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **Formato de los marcos de Zoom**
En las secciones anteriores, le mostramos cómo crear marcos de zoom simples. Para crear marcos de zoom más complejos, debe alterar el formato de un marco simple. Existen varias opciones de formato que puede aplicar a un marco de zoom. 

Puede controlar el formato de un marco de zoom en una diapositiva de esta manera:

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2.	Cree nuevas diapositivas a las que pretenda enlazar el marco de zoom. 
3.	Agregue algún texto de identificación y un fondo a las diapositivas creadas.
4.	Agregue marcos de zoom (conteniendo referencias a las diapositivas creadas) a la primera diapositiva.
5.	Cree un objeto [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) añadiendo una imagen a la colección Images asociada al objeto [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) que se usará para rellenar el marco.
6.	Establezca una imagen personalizada para el primer objeto de marco de zoom.
7.	Cambie el formato de línea para el segundo objeto de marco de zoom.
8.	Elimine el fondo de la imagen del segundo objeto de marco de zoom.
5.	Escriba la presentación modificada como un archivo PPTX.

Este código Java le muestra cómo cambiar el formato de un marco de zoom en una diapositiva: 
``` java 
Presentation pres = new Presentation();
try {
    //Agrega nuevas diapositivas a la presentación
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Crea un fondo para la segunda diapositiva
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Crea un cuadro de texto para la segunda diapositiva
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Crea un fondo para la tercera diapositiva
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Crea un cuadro de texto para la tercera diapositiva
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //Agrega objetos ZoomFrame
    IZoomFrame zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Crea una nueva imagen para el objeto zoom
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    // Establece una imagen personalizada para el objeto zoomFrame1
    zoomFrame1.setImage(picture);

    // Establece un formato de marco de zoom para el objeto zoomFrame2
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    // Configuración para no mostrar el fondo del objeto zoomFrame2
    zoomFrame2.setShowBackground(false);

    // Guarda la presentación
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Zoom de Sección**

Un zoom de sección es un enlace a una sección de su presentación. Puede usar los zooms de sección para volver a secciones que desea enfatizar. O bien puede usarlos para resaltar cómo ciertas partes de su presentación se conectan. 

![overview_image](seczoomsel.png)

Para los objetos de zoom de sección, Aspose.Slides proporciona la interfaz [ISectionZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISectionZoomFrame) y algunos métodos bajo la interfaz [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).

### **Crear marcos de Zoom de Sección**

Puede añadir un marco de zoom de sección a una diapositiva de esta manera:

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2.	Cree una nueva diapositiva. 
3.	Agregue un fondo de identificación a la diapositiva creada.
4.	Cree una nueva sección a la que pretenda enlazar el marco de zoom. 
5.	Agregue un marco de zoom de sección (conteniendo referencias a la sección creada) a la primera diapositiva.
6.	Escriba la presentación modificada como un archivo PPTX.

Este código Java le muestra cómo crear un marco de zoom en una diapositiva:
``` java
Presentation pres = new Presentation();
try {
    //Agrega una nueva diapositiva a la presentación
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Agrega una nueva sección a la presentación
    pres.getSections().addSection("Section 1", slide);

    // Agrega un objeto SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Guarda la presentación
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Crear marcos de Zoom de Sección con imágenes personalizadas**

Usando Aspose.Slides para Android vía Java, puede crear un marco de zoom de sección con una imagen de vista previa diferente de la diapositiva de esta manera:

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2.	Cree una nueva diapositiva.
3.	Agregue un fondo de identificación a la diapositiva creada.
4.	Cree una nueva sección a la que pretenda enlazar el marco de zoom. 
5.	Cree un objeto [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) añadiendo una imagen a la colección Images asociada al objeto [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) que se usará para rellenar el marco.
5.	Agregue un marco de zoom de sección (conteniendo una referencia a la sección creada) a la primera diapositiva.
6.	Escriba la presentación modificada como un archivo PPTX.

Este código Java le muestra cómo crear un marco de zoom con una imagen diferente:
``` java 
Presentation pres = new Presentation();
try {
    //Agrega una nueva diapositiva a la presentación
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //Agrega una nueva sección a la presentación
    pres.getSections().addSection("Section 1", slide);

    //Crea una nueva imagen para el objeto zoom
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    //Agrega un objeto SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);

    //Guarda la presentación
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **Formato de los marcos de Zoom de Sección**

Para crear marcos de zoom de sección más complejos, debe alterar el formato de un marco simple. Existen varias opciones de formato que puede aplicar a un marco de zoom de sección. 

Puede controlar el formato de un marco de zoom de sección en una diapositiva de esta manera:

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2.	Cree una nueva diapositiva.
3.	Agregue un fondo de identificación a la diapositiva creada.
4.	Cree una nueva sección a la que pretenda enlazar el marco de zoom. 
5.	Agregue un marco de zoom de sección (conteniendo referencias a la sección creada) a la primera diapositiva.
6.	Cambie el tamaño y la posición del objeto de zoom de sección creado.
7.	Cree un objeto [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) añadiendo una imagen a la colección Images asociada al objeto [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) que se usará para rellenar el marco.
8.	Establezca una imagen personalizada para el objeto de marco de zoom de sección creado.
9.	Establezca la capacidad de *volver a la diapositiva original desde la sección enlazada*. 
10.	Elimine el fondo de la imagen del objeto de marco de zoom de sección.
11.	Cambie el formato de línea para el segundo objeto de marco de zoom.
12.	Cambie la duración de la transición.
13.	Escriba la presentación modificada como un archivo PPTX.

Este código Java le muestra cómo cambiar el formato de un marco de zoom de sección:
``` java
Presentation pres = new Presentation();
try {
    //Agrega una nueva diapositiva a la presentación
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Agrega una nueva sección a la presentación
    pres.getSections().addSection("Section 1", slide);

    // Agrega objeto SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Formato para SectionZoomFrame
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
         picture = pres.getImages().addImage(image);
     } finally {
        if (image != null) image.dispose();
     }
    sectionZoomFrame.setImage(picture);

    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);

    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.gray);
    sectionZoomFrame.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5f);

    sectionZoomFrame.setTransitionDuration(1.5f);

    // Guarda la presentación
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```



## **Zoom de Resumen**

Un zoom de resumen es como una página de destino donde se muestran todas las piezas de su presentación a la vez. Cuando está presentando, puede usar el zoom para pasar de un lugar de su presentación a otro en cualquier orden que desee. Puede ser creativo, adelantarse o volver a visitar partes de su presentación sin interrumpir el flujo de la misma.

![overview_image](sumzoomsel.png)

Para los objetos de zoom de resumen, Aspose.Slides proporciona las interfaces [ISummaryZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSection) y [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) y algunos métodos bajo la interfaz [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).

### **Crear un Zoom de Resumen**

Puede añadir un marco de zoom de resumen a una diapositiva de esta manera:

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2.	Cree nuevas diapositivas con fondo de identificación y nuevas secciones para las diapositivas creadas.
3.	Agregue el marco de zoom de resumen a la primera diapositiva.
4.	Escriba la presentación modificada como un archivo PPTX.

Este código Java le muestra cómo crear un marco de zoom de resumen en una diapositiva:
``` java 
Presentation pres = new Presentation();
try {
    //Agrega una nueva diapositiva a la presentación
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Agrega una nueva sección a la presentación
    pres.getSections().addSection("Section 1", slide);

    //Agrega una nueva diapositiva a la presentación
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Agrega una nueva sección a la presentación
    pres.getSections().addSection("Section 2", slide);

    //Agrega una nueva diapositiva a la presentación
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Agrega una nueva sección a la presentación
    pres.getSections().addSection("Section 3", slide);

    //Agrega una nueva diapositiva a la presentación
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Agrega una nueva sección a la presentación
    pres.getSections().addSection("Section 4", slide);

    // Agrega un objeto SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Guarda la presentación
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Agregar y eliminar una sección de Zoom de Resumen**

Todas las secciones en un marco de zoom de resumen están representadas por objetos [ISummaryZoomSection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSection), que se almacenan en el objeto [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection). Puede agregar o eliminar un objeto de sección de zoom de resumen a través de la interfaz [ISummaryZoomSectionCollection]{{https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection}} de esta manera:

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2.	Cree nuevas diapositivas con fondo de identificación y nuevas secciones para las diapositivas creadas.
3.	Agregue un marco de zoom de resumen a la primera diapositiva.
4.	Agregue una nueva diapositiva y sección a la presentación.
5.	Agregue la sección creada al marco de zoom de resumen.
6.	Elimine la primera sección del marco de zoom de resumen.
7.	Escriba la presentación modificada como un archivo PPTX.

Este código Java le muestra cómo agregar y eliminar secciones en un marco de zoom de resumen:
``` java
Presentation pres = new Presentation();
try {
    //Agrega una nueva diapositiva a la presentación
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Agrega una nueva sección a la presentación
    pres.getSections().addSection("Section 1", slide);

    //Agrega una nueva diapositiva a la presentación
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Agrega una nueva sección a la presentación
    pres.getSections().addSection("Section 2", slide);

    // Agrega un objeto SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //Agrega una nueva diapositiva a la presentación
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Agrega una nueva sección a la presentación
    ISection section3 = pres.getSections().addSection("Section 3", slide);

    // Agrega una sección al Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    // Elimina la sección del Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    // Guarda la presentación
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Formato de las secciones de Zoom de Resumen**

Para crear objetos de sección de zoom de resumen más complejos, debe alterar el formato de un marco simple. Existen varias opciones de formato que puede aplicar a un objeto de sección de zoom de resumen. 

Puede controlar el formato de un objeto de sección de zoom de resumen en un marco de zoom de resumen de esta manera:

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2.	Cree nuevas diapositivas con fondo de identificación y nuevas secciones para las diapositivas creadas.
3.	Agregue un marco de zoom de resumen a la primera diapositiva.
4.	Obtenga un objeto de sección de zoom de resumen para el primer objeto de la `ISummaryZoomSectionCollection`.
7.	Cree un objeto [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) añadiendo una imagen a la colección images asociada al objeto [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) que se usará para rellenar el marco.
8.	Establezca una imagen personalizada para el objeto de marco de sección de zoom creado.
9.	Establezca la capacidad de *volver a la diapositiva original desde la sección enlazada*. 
11.	Cambie el formato de línea para el segundo objeto de marco de zoom.
12.	Cambie la duración de la transición.
13.	Escriba la presentación modificada como un archivo PPTX.

Este código Java le muestra cómo cambiar el formato de un objeto de sección de zoom de resumen:
``` java
Presentation pres = new Presentation();
try {
    //Agrega una nueva diapositiva a la presentación
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Agrega una nueva sección a la presentación
    pres.getSections().addSection("Section 1", slide);

    //Agrega una nueva diapositiva a la presentación
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Agrega una nueva sección a la presentación
    pres.getSections().addSection("Section 2", slide);

    // Agrega un objeto SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Obtiene el primer objeto SummaryZoomSection
    ISummaryZoomSection summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    // Formato para el objeto SummaryZoomSection
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) image.dispose();
    }
    summarySection.setImage(picture);

    summarySection.setReturnToParent(false);

    summarySection.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.black);
    summarySection.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5f);

    summarySection.setTransitionDuration(1.5f);

    // Guarda la presentación
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Preguntas frecuentes**

**¿Puedo controlar el regreso a la diapositiva “principal” después de mostrar el objetivo?**

Sí. El [Zoom frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zoomframe/) o la [section](https://reference.aspose.com/slides/androidjava/com.aspose.slides/sectionzoomframe/) tiene un comportamiento de retorno al padre que, cuando está habilitado, devuelve a los espectadores a la diapositiva de origen después de visitar el contenido objetivo.

**¿Puedo ajustar la “velocidad” o duración de la transición de Zoom?**

Sí. Zoom permite establecer una duración de transición para que pueda controlar cuánto tiempo tarda la animación de salto.

**¿Existen límites en la cantidad de objetos Zoom que una presentación puede contener?**

No hay un límite estricto de API documentado. Los límites prácticos dependen de la complejidad general de la presentación y del rendimiento del visor. Puede agregar muchos marcos de Zoom, pero considere el tamaño del archivo y el tiempo de renderizado.