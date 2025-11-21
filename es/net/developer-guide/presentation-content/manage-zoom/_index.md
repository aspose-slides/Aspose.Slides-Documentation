---
title: Administrar Zoom de presentación en .NET
linktitle: Administrar Zoom
type: docs
weight: 60
url: /es/net/manage-zoom/
keywords:
- zoom
- marco de zoom
- zoom de diapositiva
- zoom de sección
- zoom de resumen
- agregar zoom
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Crear y personalizar Zoom con Aspose.Slides para .NET — saltar entre secciones, agregar miniaturas y transiciones en presentaciones PPT, PPTX y ODP."
---

## **Visión general**
Los Zoom en PowerPoint le permiten saltar hacia y desde diapositivas, secciones y partes específicas de una presentación. Cuando está presentando, esta capacidad de navegar rápidamente por el contenido puede resultar muy útil. 

![overview_image](overview.png)

* Para resumir una presentación completa en una sola diapositiva, use un [Resumen Zoom](#Summary-Zoom).
* Para mostrar solo diapositivas seleccionadas, use un [Zoom de diapositiva](#Slide-Zoom).
* Para mostrar solo una sección, use un [Zoom de sección](#Section-Zoom).

## **Zoom de diapositiva**
Un zoom de diapositiva puede hacer su presentación más dinámica, permitiéndole navegar libremente entre diapositivas en cualquier orden que elija sin interrumpir el flujo de su presentación. Los zoom de diapositiva son ideales para presentaciones cortas sin muchas secciones, pero aún puede utilizarlos en diferentes escenarios de presentación.

Los zoom de diapositiva le ayudan a profundizar en múltiples piezas de información mientras siente que está en un solo lienzo. 

![overview_image](slidezoomsel.png)

Para los objetos de zoom de diapositiva, Aspose.Slides proporciona la enumeración [ZoomImageType](https://reference.aspose.com/slides/net/aspose.slides/zoomimagetype), la interfaz [IZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/izoomframe) y algunos métodos bajo la interfaz [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

### **Creación de marcos de zoom**
Puede agregar un marco de zoom en una diapositiva de esta manera:

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2.	Cree nuevas diapositivas a las que pretende enlazar los marcos de zoom. 
3.	Agregue un texto de identificación y un fondo a las diapositivas creadas.
4.	Agregue marcos de zoom (que contienen referencias a las diapositivas creadas) a la primera diapositiva.
5.	Guarde la presentación modificada como un archivo PPTX.

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
    autoshape.TextFrame.Text = "Second Slide";

    // Crea un fondo para la tercera diapositiva
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // Crea un cuadro de texto para la tercera diapositiva
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //Agrega objetos ZoomFrame
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Guarda la presentación
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Creación de marcos de zoom con imágenes personalizadas**
Con Aspose.Slides para .NET, puede crear un marco de zoom con una imagen de vista previa de diapositiva diferente de esta manera: 
1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2.	Cree una nueva diapositiva a la que pretende enlazar el marco de zoom. 
3.	Agregue un texto de identificación y un fondo a la diapositiva.
4.	Cree un objeto [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) agregando una imagen a la colección Images asociada con el objeto [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) que se usará para rellenar el marco.
5.	Agregue marcos de zoom (que contienen la referencia a la diapositiva creada) a la primera diapositiva.
6.	Guarde la presentación modificada como un archivo PPTX.

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
    autoshape.TextFrame.Text = "Second Slide";

    // Crea una nueva imagen para el objeto Zoom
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    //Agrega el objeto ZoomFrame
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 300, 200, slide, ppImage);

    // Guarda la presentación
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Formato de marcos de zoom**
En las secciones anteriores, le mostramos cómo crear marcos de zoom simples. Para crear marcos de zoom más complejos, debe alterar el formato de un marco simple. Hay varias opciones de formato que puede aplicar a un marco de zoom. 

Puede controlar el formato de un marco de zoom en una diapositiva de esta manera:

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2.	Cree nuevas diapositivas a las que pretende enlazar el marco de zoom. 
3.	Agregue algún texto de identificación y un fondo a las diapositivas creadas.
4.	Agregue marcos de zoom (que contienen referencias a las diapositivas creadas) a la primera diapositiva.
5.	Cree un objeto [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) agregando una imagen a la colección Images asociada con el objeto [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) que se usará para rellenar el marco.
6.	Establezca una imagen personalizada para el primer objeto de marco de zoom.
7.	Cambie el formato de línea para el segundo objeto de marco de zoom.
8.	Elimine el fondo de una imagen del segundo objeto de marco de zoom.
9.	Guarde la presentación modificada como un archivo PPTX.

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
    autoshape.TextFrame.Text = "Second Slide";

    // Crea un fondo para la tercera diapositiva
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // Crea un cuadro de texto para la tercera diapositiva
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //Adds ZoomFrame objects
    IZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Crea una nueva imagen para el objeto zoom
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

    // Configuración para no mostrar el fondo del objeto zoomFrame2
    zoomFrame2.ShowBackground = false;

    // Guarda la presentación
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **Zoom de sección**

Un zoom de sección es un enlace a una sección de su presentación. Puede usar los zoom de sección para volver a secciones que desea enfatizar realmente. O puede usarlos para resaltar cómo ciertas partes de su presentación se conectan. 

![overview_image](seczoomsel.png)

Para los objetos de zoom de sección, Aspose.Slides proporciona la interfaz [ISectionZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isectionzoomframe) y algunos métodos bajo la interfaz [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

### **Creación de marcos de zoom de sección**

Puede agregar un marco de zoom de sección a una diapositiva de esta manera:

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2.	Cree una nueva diapositiva. 
3.	Agregue un fondo de identificación a la diapositiva creada.
4.	Cree una nueva sección a la que pretende enlazar el marco de zoom. 
5.	Agregue un marco de zoom de sección (que contiene referencias a la sección creada) a la primera diapositiva.
6.	Guarde la presentación modificada como un archivo PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Agrega una nueva diapositiva a la presentación
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Agrega una nueva sección a la presentación
    pres.Sections.AddSection("Section 1", slide);

    // Agrega un objeto SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // Guarda la presentación
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Creación de marcos de zoom de sección con imágenes personalizadas**

Usando Aspose.Slides para .NET, puede crear un marco de zoom de sección con una imagen de vista previa de diapositiva diferente de esta manera: 

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2.	Cree una nueva diapositiva.
3.	Agregue un fondo de identificación a la diapositiva creada.
4.	Cree una nueva sección a la que pretende enlazar el marco de zoom. 
5.	Cree un objeto [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) agregando una imagen a la colección Images asociada con el objeto [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) que se usará para rellenar el marco.
6.	Agregue un marco de zoom de sección (que contiene una referencia a la sección creada) a la primera diapositiva.
7.	Guarde la presentación modificada como un archivo PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Agrega una nueva diapositiva a la presentación
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Agrega una nueva sección a la presentación
    pres.Sections.AddSection("Section 1", slide);

    // Crea una nueva imagen para el objeto zoom
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Agrega un objeto SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1], ppImage);

    // Guarda la presentación
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Formato de marcos de zoom de sección**

Para crear marcos de zoom de sección más complicados, debe alterar el formato de un marco simple. Hay varias opciones de formato que puede aplicar a un marco de zoom de sección. 

Puede controlar el formato de un marco de zoom de sección en una diapositiva de esta manera:

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2.	Cree una nueva diapositiva.
3.	Agregue un fondo de identificación a la diapositiva creada.
4.	Cree una nueva sección a la que pretende enlazar el marco de zoom. 
5.	Agregue un marco de zoom de sección (que contiene referencias a la sección creada) a la primera diapositiva.
6.	Cambie el tamaño y la posición del objeto de zoom de sección creado.
7.	Cree un objeto [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) agregando una imagen a la colección Images asociada con el objeto [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) que se usará para rellenar el marco.
8.	Establezca una imagen personalizada para el objeto de marco de zoom de sección creado.
9.	Establezca la *capacidad de volver a la diapositiva original desde la sección vinculada*.
10.	Elimine el fondo de una imagen del objeto de marco de zoom de sección.
11.	Cambie el formato de línea para el segundo objeto de marco de zoom.
12.	Cambie la duración de la transición.
13.	Guarde la presentación modificada como un archivo PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Agrega una nueva diapositiva a la presentación
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Agrega una nueva sección a la presentación
    pres.Sections.AddSection("Section 1", slide);

    // Agrega un objeto SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // Formato para SectionZoomFrame
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



## **Zoom de resumen**

Un zoom de resumen es como una página de destino donde se muestran todas las piezas de su presentación a la vez. Cuando está presentando, puede usar el zoom para pasar de un lugar de su presentación a otro en cualquier orden que desee. Puede ser creativo, adelantarse o volver a visitar partes de su presentación sin interrumpir el flujo de la misma.

![overview_image](sumzoomsel.png)

Para los objetos de zoom de resumen, Aspose.Slides proporciona las interfaces [ISummaryZoomFrame](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomframe), [ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection) y [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection) y algunos métodos bajo la interfaz [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

### **Creación de zoom de resumen**

Puede agregar un marco de zoom de resumen a una diapositiva de esta manera:

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2.	Cree nuevas diapositivas con fondo de identificación y nuevas secciones para las diapositivas creadas.
3.	Agregue el marco de zoom de resumen a la primera diapositiva.
4.	Guarde la presentación modificada como un archivo PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Agrega una nueva diapositiva a la presentación
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Agrega una nueva sección a la presentación
    pres.Sections.AddSection("Section 1", slide);

    //Agrega una nueva diapositiva a la presentación
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Agrega una nueva sección a la presentación
    pres.Sections.AddSection("Section 2", slide);

    //Agrega una nueva diapositiva a la presentación
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Agrega una nueva sección a la presentación
    pres.Sections.AddSection("Section 3", slide);

    //Agrega una nueva diapositiva a la presentación
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.DarkGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Agrega una nueva sección a la presentación
    pres.Sections.AddSection("Section 4", slide);

    // Agrega un objeto SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // Guarda la presentación
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


### **Agregar y eliminar sección de zoom de resumen**

Todas las secciones en un marco de zoom de resumen están representadas por objetos [ISummaryZoomFrameSection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsection), que se almacenan en el objeto [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/net/aspose.slides/isummaryzoomsectioncollection). Puede agregar o eliminar un objeto de sección de zoom de resumen a través de la interfaz [ISummaryZoomSectionCollection] de esta manera:

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2.	Cree nuevas diapositivas con fondo de identificación y nuevas secciones para las diapositivas creadas.
3.	Agregue un marco de zoom de resumen a la primera diapositiva.
4.	Agregue una nueva diapositiva y sección a la presentación.
5.	Agregue la sección creada al marco de zoom de resumen.
6.	Elimine la primera sección del marco de zoom de resumen.
7.	Guarde la presentación modificada como un archivo PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Agrega una nueva diapositiva a la presentación
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Agrega una nueva sección a la presentación
    pres.Sections.AddSection("Section 1", slide);

    //Agrega una nueva diapositiva a la presentación
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Agrega una nueva sección a la presentación
    pres.Sections.AddSection("Section 2", slide);

    // Agrega un objeto SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    //Agrega una nueva diapositiva a la presentación
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Agrega una nueva sección a la presentación
    ISection section3 = pres.Sections.AddSection("Section 3", slide);

    // Agrega una sección al Summary Zoom
    summaryZoomFrame.SummaryZoomCollection.AddSummaryZoomSection(section3);

    // Elimina la sección del Summary Zoom
    summaryZoomFrame.SummaryZoomCollection.RemoveSummaryZoomSection(pres.Sections[1]);

    // Guarda la presentación
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


### **Formato de secciones de zoom de resumen**

Para crear objetos de sección de zoom de resumen más complicados, debe alterar el formato de un marco simple. Hay varias opciones de formato que puede aplicar a un objeto de sección de zoom de resumen. 

Puede controlar el formato de un objeto de sección de zoom de resumen en un marco de zoom de resumen de esta manera:

1.	Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2.	Cree nuevas diapositivas con fondo de identificación y nuevas secciones para las diapositivas creadas.
3.	Agregue un marco de zoom de resumen a la primera diapositiva.
4.	Obtenga un objeto de sección de zoom de resumen para el primer objeto de la `ISummaryZoomSectionCollection`.
7.	Cree un objeto [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) agregando una imagen a la colección images asociada con el objeto [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) que se usará para rellenar el marco.
8.	Establezca una imagen personalizada para el objeto de marco de zoom de sección creado.
9.	Establezca la *capacidad de volver a la diapositiva original desde la sección vinculada*.
11.	Cambie el formato de línea para el segundo objeto de marco de zoom.
12.	Cambie la duración de la transición.
13.	Guarde la presentación modificada como un archivo PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Agrega una nueva diapositiva a la presentación
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Agrega una nueva sección a la presentación
    pres.Sections.AddSection("Section 1", slide);

    //Agrega una nueva diapositiva a la presentación
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Agrega una nueva sección a la presentación
    pres.Sections.AddSection("Section 2", slide);

    // Agrega un objeto SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // Obtiene el primer objeto SummaryZoomSection
    ISummaryZoomSection summarySection = summaryZoomFrame.SummaryZoomCollection[0];

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Formato para el objeto SummaryZoomSection
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


## **Preguntas frecuentes**

**¿Puedo controlar el regreso a la diapositiva 'principal' después de mostrar el destino?**

Sí. El [Zoom frame](https://reference.aspose.com/slides/net/aspose.slides/zoomframe/) o la [section](https://reference.aspose.com/slides/net/aspose.slides/sectionzoomframe/) tiene un comportamiento `ReturnToParent` que, cuando está habilitado, devuelve al espectador a la diapositiva origen después de visitar el contenido objetivo.

**¿Puedo ajustar la 'velocidad' o duración de la transición de Zoom?**

Sí. Zoom admite la configuración de `TransitionDuration` para que pueda controlar cuánto tiempo dura la animación de salto.

**¿Existen límites en la cantidad de objetos Zoom que una presentación puede contener?**

No hay un límite estricto documentado en la API. Los límites prácticos dependen de la complejidad general de la presentación y del rendimiento del visor. Puede agregar muchos marcos de Zoom, pero considere el tamaño del archivo y el tiempo de renderizado.