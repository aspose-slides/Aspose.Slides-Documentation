---
title: Administrar Zoom
type: docs
weight: 60
url: /net/manage-zoom/
keywords: 
- zoom
- marco de zoom
- agregar zoom
- formatear marco de zoom
- resumen de zoom
- presentación de PowerPoint
- C#
- Csharp
- Aspose.Slides para .NET
description: "Agregue zoom o marcos de zoom a presentaciones de PowerPoint en C# o .NET"
---

## **Descripción General**
Los zooms en PowerPoint te permiten saltar a y desde diapositivas específicas, secciones y porciones de una presentación. Cuando estás presentando, esta capacidad para navegar rápidamente a través del contenido puede resultar muy útil.

![overview_image](overview.png)

* Para resumir una presentación completa en una sola diapositiva, utiliza un [Resumen de Zoom](#Summary-Zoom).
* Para mostrar solo diapositivas seleccionadas, utiliza un [Zoom de Diapositiva](#Slide-Zoom).
* Para mostrar solo una sección, utiliza un [Zoom de Sección](#Section-Zoom).

## **Zoom de Diapositiva**
Un zoom de diapositiva puede hacer que tu presentación sea más dinámica, permitiéndote navegar libremente entre diapositivas en cualquier orden que elijas sin interrumpir el flujo de tu presentación. Los zooms de diapositiva son excelentes para presentaciones breves sin muchas secciones, pero aún puedes usarlos en diferentes escenarios de presentación.

Los zooms de diapositiva te ayudan a profundizar en múltiples piezas de información mientras sientes que estás en un solo lienzo.

![overview_image](slidezoomsel.png)

Para objetos de zoom de diapositiva, Aspose.Slides proporciona la enumeración [ZoomImageType](https://reference.aspose.com/slides/net/aspose.slides/zoomimagetype), la interfaz [IZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/izoomframe) y algunos métodos bajo la interfaz [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

### **Creación de Marcos de Zoom**

Puedes agregar un marco de zoom en una diapositiva de la siguiente manera:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Crear nuevas diapositivas a las que planeas vincular los marcos de zoom. 
3. Agregar un texto de identificación y un fondo a las diapositivas creadas.
4. Agregar marcos de zoom (que contienen las referencias a las diapositivas creadas) a la primera diapositiva.
5. Escribir la presentación modificada como un archivo PPTX.

Este código C# te muestra cómo crear un marco de zoom en una diapositiva:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Agrega nuevas diapositivas a la presentación
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Crea un fondo para la segunda diapositiva
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Crea un cuadro de texto para la segunda diapositiva
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Segunda Diapositiva";

    // Crea un fondo para la tercera diapositiva
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // Crea un cuadro de texto para la tercera diapositiva
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Tercera Diapositiva";

    //Agrega objetos ZoomFrame
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Guarda la presentación
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Creación de Marcos de Zoom con Imágenes Personalizadas**
Con Aspose.Slides para .NET, puedes crear un marco de zoom con una imagen de vista previa de diapositiva diferente de la siguiente manera: 
1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Crear una nueva diapositiva a la que planeas vincular el marco de zoom. 
3. Agregar un texto de identificación y un fondo a la diapositiva.
4. Crear un objeto [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) agregando una imagen a la colección de Imágenes asociada con el objeto [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) que se utilizará para llenar el marco.
5. Agregar marcos de zoom (que contienen la referencia a la diapositiva creada) a la primera diapositiva.
6. Escribir la presentación modificada como un archivo PPTX.

Este código C# te muestra cómo crear un marco de zoom con una imagen diferente:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Agrega una nueva diapositiva a la presentación
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Crea un fondo para la segunda diapositiva
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Crea un cuadro de texto para la tercera diapositiva
    IAutoShape autoshape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Segunda Diapositiva";

    // Crea una nueva imagen para el objeto de zoom
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Agrega el objeto ZoomFrame
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 300, 200, slide, ppImage);

    // Guarda la presentación
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Formateo de Marcos de Zoom**
En las secciones anteriores, te mostramos cómo crear marcos de zoom simples. Para crear marcos de zoom más complicados, debes alterar el formato de un marco simple. Hay varias opciones de formato que puedes aplicar a un marco de zoom. 

Puedes controlar el formato de un marco de zoom en una diapositiva de la siguiente manera:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Crear nuevas diapositivas a las que planeas vincular el marco de zoom. 
3. Agregar algún texto de identificación y un fondo a las diapositivas creadas.
4. Agregar marcos de zoom (que contienen las referencias a las diapositivas creadas) a la primera diapositiva.
5. Crear un objeto [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) agregando una imagen a la colección de Imágenes asociada con el objeto [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) que se utilizará para llenar el marco.
6. Establecer una imagen personalizada para el primer objeto de marco de zoom.
7. Cambiar el formato de línea para el segundo objeto de marco de zoom.
8. Eliminar el fondo de una imagen del segundo objeto de marco de zoom.
9. Escribir la presentación modificada como un archivo PPTX.

Este código C# te muestra cómo cambiar el formato de un marco de zoom en una diapositiva: 

``` csharp 
using (Presentation pres = new Presentation())
{
    //Agrega nuevas diapositivas a la presentación
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Crea un fondo para la segunda diapositiva
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Crea un cuadro de texto para la segunda diapositiva
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Segunda Diapositiva";

    // Crea un fondo para la tercera diapositiva
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // Crea un cuadro de texto para la tercera diapositiva
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Tercera Diapositiva";

    // Agrega objetos ZoomFrame
    IZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Crea una nueva imagen para el objeto de zoom
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Establece una imagen personalizada para el objeto zoomFrame1
    zoomFrame1.ZoomImage = ppImage;

    // Establece un formato de marco de zoom para el objeto zoomFrame2
    zoomFrame2.LineFormat.Width = 5;
    zoomFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
    zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
    zoomFrame2.LineFormat.DashStyle = LineDashStyle.DashDot;

    // Configuración para no mostrar el fondo para el objeto zoomFrame2
    zoomFrame2.ShowBackground = false;

    // Guarda la presentación
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **Zoom de Sección**

Un zoom de sección es un enlace a una sección en tu presentación. Puedes usar los zooms de sección para volver a secciones que realmente deseas enfatizar. O puedes usarlos para destacar cómo ciertas piezas de tu presentación se conectan. 

![overview_image](seczoomsel.png)

Para objetos de zoom de sección, Aspose.Slides proporciona la interfaz [ISectionZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isectionzoomframe) y algunos métodos bajo la interfaz [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

### **Creación de Marcos de Zoom de Sección**

Puedes agregar un marco de zoom de sección a una diapositiva de la siguiente manera:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Crear una nueva diapositiva. 
3. Agregar un fondo de identificación a la diapositiva creada.
4. Crear una nueva sección a la que planeas vincular el marco de zoom. 
5. Agregar un marco de zoom de sección (que contiene referencias a la sección creada) a la primera diapositiva.
6. Escribir la presentación modificada como un archivo PPTX.

Este código C# te muestra cómo crear un marco de zoom en una diapositiva:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Agrega una nueva diapositiva a la presentación
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Agrega una nueva sección a la presentación
    pres.Sections.AddSection("Sección 1", slide);

    // Agrega un objeto SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // Guarda la presentación
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Creación de Marcos de Zoom de Sección con Imágenes Personalizadas**

Usando Aspose.Slides para .NET, puedes crear un marco de zoom de sección con una imagen de vista previa de diapositiva diferente de la siguiente manera: 

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Crear una nueva diapositiva.
3. Agregar un fondo de identificación a la diapositiva creada.
4. Crear una nueva sección a la que planeas vincular el marco de zoom. 
5. Crear un objeto [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) agregando una imagen a la colección de Imágenes asociada con el objeto [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) que se utilizará para llenar el marco.
5. Agregar un marco de zoom de sección (containing una referencia a la sección creada) a la primera diapositiva.
6. Escribir la presentación modificada como un archivo PPTX.

Este código C# te muestra cómo crear un marco de zoom con una imagen diferente:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Agrega una nueva diapositiva a la presentación
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Agrega una nueva sección a la presentación
    pres.Sections.AddSection("Sección 1", slide);

    // Crea una nueva imagen para el objeto de zoom
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Agrega objeto SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1], ppImage);

    // Guarda la presentación
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Formateo de Marcos de Zoom de Sección**

Para crear marcos de zoom de sección más complicados, debes alterar el formato de un marco simple. Hay varias opciones de formato que puedes aplicar a un marco de zoom de sección. 

Puedes controlar el formato de un marco de zoom de sección en una diapositiva de la siguiente manera:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Crear una nueva diapositiva.
3. Agregar un fondo de identificación a la diapositiva creada.
4. Crear una nueva sección a la que planeas vincular el marco de zoom. 
5. Agregar un marco de zoom de sección (que contiene referencias a la sección creada) a la primera diapositiva.
6. Cambiar el tamaño y la posición del objeto de zoom de sección creado.
7. Crear un objeto [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) agregando una imagen a la colección de imágenes asociada con el objeto [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) que se utilizará para llenar el marco.
8. Establecer una imagen personalizada para el objeto de marco de zoom de sección creado.
9. Establecer la capacidad de *volver a la diapositiva original desde la sección vinculada*. 
10. Eliminar el fondo de una imagen del objeto de marco de zoom de sección.
11. Cambiar el formato de línea para el segundo objeto de marco de zoom.
12. Cambiar la duración de la transición.
13. Escribir la presentación modificada como un archivo PPTX.

Este código C# te muestra cómo cambiar el formato de un marco de zoom de sección:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Agrega una nueva diapositiva a la presentación
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Agrega una nueva sección a la presentación
    pres.Sections.AddSection("Sección 1", slide);

    // Agrega objeto SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // Formateo para SectionZoomFrame
    sectionZoomFrame.X = 100;
    sectionZoomFrame.Y = 300;
    sectionZoomFrame.Width = 100;
    sectionZoomFrame.Height = 75;

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    sectionZoomFrame.ZoomImage = ppImage;

    sectionZoomFrame.ReturnToParent = true;
    sectionZoomFrame.ShowBackground = false;

    sectionZoomFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    sectionZoomFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Brown;
    sectionZoomFrame.LineFormat.DashStyle = LineDashStyle.DashDot;
    sectionZoomFrame.LineFormat.Width = 2.5f;

    sectionZoomFrame.TransitionDuration = 1.5f;

    // Guarda la presentación
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **Resumen de Zoom**

Un resumen de zoom es como una página de destino donde se muestran todas las piezas de tu presentación a la vez. Cuando estás presentando, puedes usar el zoom para ir de un lugar en tu presentación a otro en cualquier orden que desees. Puedes ser creativo, avanzar, o volver a visitar partes de tu presentación sin interrumpir el flujo de tu presentación.

![overview_image](sumzoomsel.png)

Para objetos de resumen de zoom, Aspose.Slides proporciona las interfaces [ISummaryZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomframe), [ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection), y [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection) y algunos métodos bajo la interfaz [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

### **Creación de Resumen de Zoom**

Puedes agregar un marco de resumen de zoom a una diapositiva de la siguiente manera:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Crear nuevas diapositivas con un fondo de identificación y nuevas secciones para las diapositivas creadas.
3. Agregar el marco de resumen de zoom a la primera diapositiva.
4. Escribir la presentación modificada como un archivo PPTX.

Este código C# te muestra cómo crear un marco de resumen de zoom en una diapositiva:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Agrega una nueva diapositiva a la presentación
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Agrega una nueva sección a la presentación
    pres.Sections.AddSection("Sección 1", slide);

    // Agrega una nueva diapositiva a la presentación
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Agrega una nueva sección a la presentación
    pres.Sections.AddSection("Sección 2", slide);

    // Agrega una nueva diapositiva a la presentación
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Agrega una nueva sección a la presentación
    pres.Sections.AddSection("Sección 3", slide);

    // Agrega una nueva diapositiva a la presentación
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.DarkGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Agrega una nueva sección a la presentación
    pres.Sections.AddSection("Sección 4", slide);

    // Agrega un objeto SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // Guarda la presentación
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Agregar y Eliminar Secciones del Resumen de Zoom**

Todas las secciones en un marco de resumen de zoom están representadas por objetos [ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection), que se almacenan en el objeto [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection). Puedes agregar o eliminar un objeto de sección de resumen de zoom a través de la interfaz [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection) de la siguiente manera:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Crear nuevas diapositivas con un fondo de identificación y nuevas secciones para las diapositivas creadas.
3. Agregar un marco de resumen de zoom en la primera diapositiva.
4. Agregar una nueva diapositiva y sección a la presentación.
5. Agregar la sección creada al marco de resumen de zoom.
6. Eliminar la primera sección del marco de resumen de zoom.
7. Escribir la presentación modificada como un archivo PPTX.

Este código C# te muestra cómo agregar y eliminar secciones en un marco de resumen de zoom:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Agrega una nueva diapositiva a la presentación
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Agrega una nueva sección a la presentación
    pres.Sections.AddSection("Sección 1", slide);

    //Agrega una nueva diapositiva a la presentación
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Agrega una nueva sección a la presentación
    pres.Sections.AddSection("Sección 2", slide);

    // Agrega objeto SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    //Agrega una nueva diapositiva a la presentación
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Agrega una nueva sección a la presentación
    ISection section3 = pres.Sections.AddSection("Sección 3", slide);

    // Agrega una sección al Resumen Zoom
    summaryZoomFrame.SummaryZoomCollection.AddSummaryZoomSection(section3);

    // Elimina la sección del Resumen Zoom
    summaryZoomFrame.SummaryZoomCollection.RemoveSummaryZoomSection(pres.Sections[1]);

    // Guarda la presentación
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Formateo de Secciones del Resumen de Zoom**

Para crear objetos de sección de resumen de zoom más complicados, debes alterar el formato de un marco simple. Hay varias opciones de formato que puedes aplicar a un objeto de sección de resumen de zoom. 

Puedes controlar el formato de un objeto de sección de resumen de zoom en un marco de resumen de zoom de esta manera:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Crear nuevas diapositivas con un fondo de identificación y nuevas secciones para las diapositivas creadas.
3. Agregar un marco de resumen de zoom a la primera diapositiva.
4. Obtener un objeto de sección de resumen de zoom para el primer objeto de la `ISummaryZoomSectionCollection`.
5. Crear un objeto [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) agregando una imagen a la colección de imágenes asociada con el objeto [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) que se utilizará para llenar el marco.
6. Establecer una imagen personalizada para el objeto de marco de zoom de sección creado.
7. Establecer la capacidad de *volver a la diapositiva original desde la sección vinculada*. 
8. Cambiar el formato de línea para el segundo objeto de marco de zoom.
9. Cambiar la duración de la transición.
10. Escribir la presentación modificada como un archivo PPTX.

Este código C# te muestra cómo cambiar el formato para un objeto de sección de resumen de zoom:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Agrega una nueva diapositiva a la presentación
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Agrega una nueva sección a la presentación
    pres.Sections.AddSection("Sección 1", slide);

    //Agrega una nueva diapositiva a la presentación
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Agrega una nueva sección a la presentación
    pres.Sections.AddSection("Sección 2", slide);

    // Agrega un objeto SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // Obtiene el primer objeto SummaryZoomSection
    ISummaryZoomSection summarySection = summaryZoomFrame.SummaryZoomCollection[0];

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Formateo para el objeto SummaryZoomSection
    summarySection.ZoomImage = ppImage;
    summarySection.ReturnToParent = false;

    summarySection.LineFormat.FillFormat.FillType = FillType.Solid;
    summarySection.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    summarySection.LineFormat.DashStyle = LineDashStyle.DashDot;
    summarySection.LineFormat.Width = 1.5f;

    summarySection.TransitionDuration = 1.5f;

    // Guarda la presentación
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```