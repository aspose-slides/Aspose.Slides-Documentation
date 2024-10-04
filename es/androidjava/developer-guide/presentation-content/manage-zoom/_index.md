---
title: Administrar Zoom
type: docs
weight: 60
url: /androidjava/manage-zoom/
keywords: "Zoom, marco de zoom, agregar zoom, formato de marco de zoom, resumen de zoom, presentación de PowerPoint, Java, Aspose.Slides para Android a través de Java"
description: "Agrega zoom o marcos de zoom a presentaciones de PowerPoint en Java"
---

## **Resumen**
Los zooms en PowerPoint te permiten saltar hacia y desde diapositivas, secciones y porciones específicas de una presentación. Cuando estás presentando, esta habilidad para navegar rápidamente a través del contenido puede ser muy útil.

![overview_image](overview.png)

* Para resumir toda una presentación en una sola diapositiva, usa un [Resumen de Zoom](#Resumen-de-Zoom).
* Para mostrar solo diapositivas seleccionadas, usa un [Zoom de Diapositiva](#Zoom-de-Diapositiva).
* Para mostrar solo una sección, usa un [Zoom de Sección](#Zoom-de-Sección).

## **Zoom de Diapositiva**
Un zoom de diapositiva puede hacer que tu presentación sea más dinámica, permitiéndote navegar libremente entre las diapositivas en cualquier orden que elijas sin interrumpir el flujo de tu presentación. Los zooms de diapositiva son excelentes para presentaciones breves sin muchas secciones, pero aún puedes usarlos en diferentes escenarios de presentación.

Los zooms de diapositiva te ayudan a profundizar en múltiples piezas de información mientras sientes que estás en un solo lienzo.

![overview_image](slidezoomsel.png)

Para objetos de zoom de diapositiva, Aspose.Slides proporciona la enumeración [ZoomImageType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ZoomImageType), la interfaz [IZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IZoomFrame) y algunos métodos en la interfaz [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).

### **Creando Marcos de Zoom**

Puedes agregar un marco de zoom en una diapositiva de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Crea nuevas diapositivas a las que planeas vincular los marcos de zoom.
3. Agrega un texto de identificación y fondo a las diapositivas creadas.
4. Agrega marcos de zoom (que contengan las referencias a las diapositivas creadas) a la primera diapositiva.
5. Escribe la presentación modificada como un archivo PPTX.

Este código Java te muestra cómo crear un marco de zoom en una diapositiva:

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
    autoshape.getTextFrame().setText("Segunda Diapositiva");

    // Crea un fondo para la tercera diapositiva
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Crea un cuadro de texto para la tercera diapositiva
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Tercera Diapositiva");

    //Agrega objetos ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Guarda la presentación
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Creando Marcos de Zoom con Imágenes Personalizadas**
Con Aspose.Slides para Android a través de Java, puedes crear un marco de zoom con una imagen de vista previa de diapositiva diferente de esta manera:
1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Crea una nueva diapositiva a la que planeas vincular el marco de zoom.
3. Agrega un texto de identificación y fondo a la diapositiva.
4. Crea un objeto [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) al agregar una imagen a la colección de Imágenes asociada con el objeto [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) que se utilizará para llenar el marco.
5. Agrega marcos de zoom (conteniendo la referencia a la diapositiva creada) a la primera diapositiva.
6. Escribe la presentación modificada como un archivo PPTX.

Este código Java te muestra cómo crear un marco de zoom con una imagen diferente:

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
    autoshape.getTextFrame().setText("Segunda Diapositiva");

    // Crea una nueva imagen para el objeto zoom
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
### **Formateando Marcos de Zoom**
En las secciones anteriores, te mostramos cómo crear marcos de zoom simples. Para crear marcos de zoom más complicados, debes alterar el formato de un marco simple. Hay varias opciones de formato que puedes aplicar a un marco de zoom.

Puedes controlar el formato de un marco de zoom en una diapositiva de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Crea nuevas diapositivas a las que planeas vincular el marco de zoom.
3. Agrega algo de texto de identificación y fondo a las diapositivas creadas.
4. Agrega marcos de zoom (conteniendo las referencias a las diapositivas creadas) a la primera diapositiva.
5. Crea un objeto [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) al agregar una imagen a la colección de Imágenes asociada con el objeto [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) que se utilizará para llenar el marco.
6. Establece una imagen personalizada para el primer objeto de marco de zoom.
7. Cambia el formato de línea para el segundo objeto de marco de zoom.
8. Elimina el fondo de una imagen del segundo objeto de marco de zoom.
5. Escribe la presentación modificada como un archivo PPTX.

Este código Java te muestra cómo cambiar el formato de un marco de zoom en una diapositiva: 

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
    autoshape.getTextFrame().setText("Segunda Diapositiva");

    // Crea un fondo para la tercera diapositiva
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Crea un cuadro de texto para la tercera diapositiva
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Tercera Diapositiva");

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

    // Configuración para no mostrar fondo para el objeto zoomFrame2
    zoomFrame2.setShowBackground(false);

    // Guarda la presentación
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zoom de Sección**

Un zoom de sección es un enlace a una sección en tu presentación. Puedes usar zooms de sección para volver a secciones que realmente deseas enfatizar. O puedes usarlos para resaltar cómo ciertas piezas de tu presentación se conectan.

![overview_image](seczoomsel.png)

Para objetos de zoom de sección, Aspose.Slides proporciona la interfaz [ISectionZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISectionZoomFrame) y algunos métodos en la interfaz [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).

### **Creando Marcos de Zoom de Sección**

Puedes agregar un marco de zoom de sección a una diapositiva de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Crea una nueva diapositiva.
3. Agrega un fondo de identificación a la diapositiva creada.
4. Crea una nueva sección a la que planeas vincular el marco de zoom.
5. Agrega un marco de zoom de sección (que contenga referencias a la sección creada) a la primera diapositiva.
6. Escribe la presentación modificada como un archivo PPTX.

Este código Java te muestra cómo crear un marco de zoom en una diapositiva:

``` java
Presentation pres = new Presentation();
try {
    //Agrega una nueva diapositiva a la presentación
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Agrega una nueva sección a la presentación
    pres.getSections().addSection("Sección 1", slide);

    // Agrega un objeto SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Guarda la presentación
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Creando Marcos de Zoom de Sección con Imágenes Personalizadas**

Usando Aspose.Slides para Android a través de Java, puedes crear un marco de zoom de sección con una imagen de vista previa de diapositiva diferente de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Crea una nueva diapositiva.
3. Agrega un fondo de identificación a la diapositiva creada.
4. Crea una nueva sección a la que planeas vincular el marco de zoom.
5. Crea un objeto [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) al agregar una imagen a la colección de Imágenes asociada con el objeto [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) que se utilizará para llenar el marco.
5. Agrega un marco de zoom de sección (que contenga una referencia a la sección creada) a la primera diapositiva.
6. Escribe la presentación modificada como un archivo PPTX.

Este código Java te muestra cómo crear un marco de zoom con una imagen diferente:

``` java 
Presentation pres = new Presentation();
try {
    //Agrega nueva diapositiva a la presentación
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Agrega una nueva sección a la presentación
    pres.getSections().addSection("Sección 1", slide);

    // Crea una nueva imagen para el objeto zoom
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Agrega un objeto SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);

    // Guarda la presentación
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **Formateando Marcos de Zoom de Sección**

Para crear marcos de zoom de sección más complicados, debes alterar el formato de un marco simple. Hay varias opciones de formato que puedes aplicar a un marco de zoom de sección.

Puedes controlar el formato de un marco de zoom de sección en una diapositiva de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Crea una nueva diapositiva.
3. Agrega fondo de identificación a la diapositiva creada.
4. Crea una nueva sección a la que planeas vincular el marco de zoom.
5. Agrega un marco de zoom de sección (contiene referencias a la sección creada) a la primera diapositiva.
6. Cambia el tamaño y la posición del objeto de zoom de sección creado.
7. Crea un objeto [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) al agregar una imagen a la colección de Imágenes asociada con el objeto [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) que se utilizará para llenar el marco.
8. Establece una imagen personalizada para el objeto de marco de zoom de sección creado.
9. Establece la capacidad de *volver a la diapositiva original desde la sección vinculada*.
10. Elimina el fondo de una imagen del objeto de marco de zoom de sección.
11. Cambia el formato de línea para el segundo objeto de marco de zoom.
12. Cambia la duración de la transición.
13. Escribe la presentación modificada como un archivo PPTX.

Este código Java te muestra cómo cambiar el formato de un marco de zoom de sección:

``` java
Presentation pres = new Presentation();
try {
    //Agrega una nueva diapositiva a la presentación
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Agrega una nueva sección a la presentación
    pres.getSections().addSection("Sección 1", slide);

    // Agrega un objeto SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Formato para el objeto SectionZoomFrame
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

## **Resumen de Zoom**

Un resumen de zoom es como una página de aterrizaje donde todas las partes de tu presentación se muestran de una vez. Cuando estás presentando, puedes usar el zoom para ir de un lugar en tu presentación a otro en cualquier orden que desees. Puedes ser creativo, adelantar o revisar partes de tu presentación sin interrumpir el flujo de tu presentación.

![overview_image](sumzoomsel.png)

Para objetos de resumen de zoom, Aspose.Slides proporciona las interfaces [ISummaryZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSection) y [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) y algunos métodos en la interfaz [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).

### **Creando Resumen de Zoom**

Puedes agregar un marco de resumen de zoom a una diapositiva de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Crea nuevas diapositivas con fondo de identificación y nuevas secciones para las diapositivas creadas.
3. Agrega el marco de resumen de zoom a la primera diapositiva.
4. Escribe la presentación modificada como un archivo PPTX.

Este código Java te muestra cómo crear un marco de resumen de zoom en una diapositiva:

``` java 
Presentation pres = new Presentation();
try {
    //Agrega una nueva diapositiva a la presentación
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Agrega una nueva sección a la presentación
    pres.getSections().addSection("Sección 1", slide);

    //Agrega una nueva diapositiva a la presentación
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Agrega una nueva sección a la presentación
    pres.getSections().addSection("Sección 2", slide);

    //Agrega una nueva diapositiva a la presentación
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Agrega una nueva sección a la presentación
    pres.getSections().addSection("Sección 3", slide);

    //Agrega una nueva diapositiva a la presentación
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Agrega una nueva sección a la presentación
    pres.getSections().addSection("Sección 4", slide);

    // Agrega un objeto SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Guarda la presentación
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Agregando y Eliminando Secciones de Resumen de Zoom**

Todas las secciones en un marco de resumen de zoom están representadas por objetos [ISummaryZoomSection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSection), que se almacenan en el objeto [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection). Puedes agregar o eliminar un objeto de sección de resumen de zoom a través de la interfaz [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Crea nuevas diapositivas con fondo de identificación y nuevas secciones para las diapositivas creadas.
3. Agrega un marco de resumen de zoom a la primera diapositiva.
4. Agrega una nueva diapositiva y sección a la presentación.
5. Agrega la sección creada al marco de resumen de zoom.
6. Elimina la primera sección del marco de resumen de zoom.
7. Escribe la presentación modificada como un archivo PPTX.

Este código Java te muestra cómo agregar y eliminar secciones en un marco de resumen de zoom:

``` java
Presentation pres = new Presentation();
try {
    //Agrega una nueva diapositiva a la presentación
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Agrega una nueva sección a la presentación
    pres.getSections().addSection("Sección 1", slide);

    //Agrega una nueva diapositiva a la presentación
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Agrega una nueva sección a la presentación
    pres.getSections().addSection("Sección 2", slide);

    // Agrega un objeto SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //Agrega una nueva diapositiva a la presentación
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Agrega una nueva sección a la presentación
    ISection section3 = pres.getSections().addSection("Sección 3", slide);

    // Agrega una sección al Resumen de Zoom
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    // Elimina una sección del Resumen de Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    // Guarda la presentación
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Formateando Secciones de Resumen de Zoom**

Para crear objetos de sección de resumen de zoom más complicados, debes alterar el formato de un marco simple. Hay varias opciones de formato que puedes aplicar a un objeto de sección de resumen de zoom.

Puedes controlar el formato para un objeto de sección de resumen de zoom en un marco de resumen de zoom de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Crea nuevas diapositivas con fondo de identificación y nuevas secciones para las diapositivas creadas.
3. Agrega un marco de resumen de zoom a la primera diapositiva.
4. Obtén un objeto de sección de resumen de zoom del primer objeto de la `ISummaryZoomSectionCollection`.
7. Crea un objeto [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) al agregar una imagen a la colección de imágenes asociada con el objeto [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) que se utilizará para llenar el marco.
8. Establece una imagen personalizada para el objeto de marco de sección de resumen creado.
9. Establece la capacidad de *volver a la diapositiva original desde la sección vinculada*.
11. Cambia el formato de línea para el segundo objeto de marco de zoom.
12. Cambia la duración de la transición.
13. Escribe la presentación modificada como un archivo PPTX.

Este código Java te muestra cómo cambiar el formato de un objeto de sección de resumen de zoom:

``` java
Presentation pres = new Presentation();
try {
    //Agrega una nueva diapositiva a la presentación
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Agrega una nueva sección a la presentación
    pres.getSections().addSection("Sección 1", slide);

    //Agrega una nueva diapositiva a la presentación
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Agrega una nueva sección a la presentación
    pres.getSections().addSection("Sección 2", slide);

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