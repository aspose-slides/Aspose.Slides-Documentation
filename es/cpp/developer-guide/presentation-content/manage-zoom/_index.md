---
title: Administrar Zoom de presentación en C++
linktitle: Administrar Zoom
type: docs
weight: 60
url: /es/cpp/manage-zoom/
keywords:
- zoom
- marco de zoom
- zoom de diapositiva
- zoom de sección
- zoom de resumen
- agregar zoom
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Crear y personalizar Zoom con Aspose.Slides para C++ — saltar entre secciones, agregar miniaturas y transiciones en presentaciones PPT, PPTX y ODP."
---

## **Descripción general**
Los Zoom en PowerPoint le permiten saltar a y desde diapositivas, secciones y partes específicas de una presentación. Cuando está presentando, esta capacidad de navegar rápidamente a través del contenido puede resultar muy útil. 

![overview_image](Overview.png)

* Para resumir toda una presentación en una sola diapositiva, use un [Resumen Zoom](#Summary-Zoom).
* Para mostrar solo diapositivas seleccionadas, use un [Zoom de diapositiva](#Slide-Zoom).
* Para mostrar solo una sección, use un [Zoom de sección](#Section-Zoom).

## **Zoom de diapositiva**
Un zoom de diapositiva puede hacer su presentación más dinámica, permitiéndole navegar libremente entre diapositivas en cualquier orden que elija sin interrumpir el flujo de la presentación. Los zooms de diapositiva son ideales para presentaciones cortas sin muchas secciones, pero también pueden usarse en diferentes escenarios de presentación.

Los zooms de diapositiva le ayudan a profundizar en múltiples piezas de información mientras siente que está en un solo lienzo. 

![overview_image](slidezoomsel.png)

Para los objetos de zoom de diapositiva, Aspose.Slides proporciona la [ZoomImageType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#ac0802a52a7f14a457b62e9761a77e8e2) enumeración, la interfaz [IZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_zoom_frame) y algunos métodos bajo la interfaz [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection).

### **Crear marcos de zoom**

Puede agregar un marco de zoom en una diapositiva de esta manera:

1.	Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2.	Crear nuevas diapositivas a las que desea enlazar los marcos de zoom. 
3.	Agregar un texto de identificación y un fondo a las diapositivas creadas.
4.	Agregar marcos de zoom (conteniendo las referencias a las diapositivas creadas) a la primera diapositiva.
5.	Escribir la presentación modificada como un archivo PPTX.

Este código C++ le muestra cómo crear un marco de zoom en una diapositiva:
``` cpp 
void SetSlideBackground(SharedPtr<ISlide> slide, Color color)
{
    slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
    slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(color);
    slide->get_Background()->set_Type(BackgroundType::OwnBackground);
}
```

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Añade nuevas diapositivas a la presentación
auto slide2 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// Crea un fondo para la segunda diapositiva
SetSlideBackground(slide2, Color::get_Cyan());

// Crea un cuadro de texto para la segunda diapositiva
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Crea un fondo para la tercera diapositiva
SetSlideBackground(slide3, Color::get_DarkKhaki());

// Crea un cuadro de texto para la tercera diapositiva
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//Añade objetos ZoomFrame
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
slide0->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Guarda la presentación
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Crear marcos de zoom con imágenes personalizadas**
Con Aspose.Slides para C++, puede crear un marco de zoom con una imagen de vista previa diferente de la diapositiva de esta manera: 
1.	Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2.	Crear una nueva diapositiva a la que desea enlazar el marco de zoom. 
3.	Agregar un texto de identificación y un fondo a la diapositiva.
4.	Crear un objeto [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) agregando una imagen a la colección Images asociada con el objeto [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) que se utilizará para rellenar el marco.
5.	Agregar marcos de zoom (conteniendo la referencia a la diapositiva creada) a la primera diapositiva.
6.	Escribir la presentación modificada como un archivo PPTX.

Este código C++ le muestra cómo crear un marco de zoom con una imagen diferente:
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Añade una nueva diapositiva a la presentación
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// Crea un fondo para la segunda diapositiva
SetSlideBackground(slide, Color::get_Cyan());

// Crea un cuadro de texto para la tercera diapositiva
auto autoshape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Crea una nueva imagen para el objeto Zoom
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

//Añade el objeto ZoomFrame
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, slide, image);

// Guarda la presentación
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Formato de los marcos de zoom**
En las secciones anteriores, le mostramos cómo crear marcos de zoom simples. Para crear marcos de zoom más complejos, debe alterar el formato de un marco simple. Hay varias opciones de formato que puede aplicar a un marco de zoom. 

Puede controlar el formato de un marco de zoom en una diapositiva de esta manera:

1.	Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2.	Crear nuevas diapositivas a enlazar a las que desea enlazar el marco de zoom. 
3.	Agregar algún texto de identificación y un fondo a las diapositivas creadas.
4.	Agregar marcos de zoom (conteniendo las referencias a las diapositivas creadas) a la primera diapositiva.
5.	Crear un objeto [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) agregando una imagen a la colección Images asociada con el objeto [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) que se utilizará para rellenar el marco.
6.	Establecer una imagen personalizada para el primer objeto de marco de zoom.
7.	Cambiar el formato de línea para el segundo objeto de marco de zoom.
8.	Eliminar el fondo de la imagen del segundo objeto de marco de zoom.
5.	Escribir la presentación modificada como un archivo PPTX.

Este código C++ le muestra cómo cambiar el formato de un marco de zoom en una diapositiva: 
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide1 = pres->get_Slides()->idx_get(0);
//Añade nuevas diapositivas a la presentación
auto slide2 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());

// Crea un fondo para la segunda diapositiva
SetSlideBackground(slide2, Color::get_Cyan());

// Crea un cuadro de texto para la segunda diapositiva
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Crea un fondo para la tercera diapositiva
SetSlideBackground(slide3, Color::get_DarkKhaki());

// Crea un cuadro de texto para la tercera diapositiva
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//Añade objetos ZoomFrame
auto zoomFrame1 = slide1->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
auto zoomFrame2 = slide1->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Crea una nueva imagen para el objeto zoom
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
// Establece una imagen personalizada para el objeto zoomFrame1
zoomFrame1->set_Image(image);

// Establece un formato de marco de zoom para el objeto zoomFrame2
zoomFrame2->get_LineFormat()->set_Width(5);
zoomFrame2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
zoomFrame2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_HotPink());
zoomFrame2->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);

// Configuración para no mostrar fondo del objeto zoomFrame2
zoomFrame2->set_ShowBackground(false);

// Guarda la presentación
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **Zoom de sección**

Un zoom de sección es un enlace a una sección de su presentación. Puede usar los zooms de sección para volver a secciones que desea enfatizar realmente. O puede usarlos para resaltar cómo ciertas partes de su presentación se conectan. 

![overview_image](seczoomsel.png)

Para los objetos de zoom de sección, Aspose.Slides proporciona la interfaz [ISectionZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_section_zoom_frame) y algunos métodos bajo la interfaz [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection).

### **Crear marcos de zoom de sección**

Puede agregar un marco de zoom de sección a una diapositiva de esta manera:

1.	Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2.	Crear una nueva diapositiva. 
3.	Agregar un fondo de identificación a la diapositiva creada.
4.	Crear una nueva sección a la que desea enlazar el marco de zoom. 
5.	Agregar un marco de zoom de sección (conteniendo referencias a la sección creada) a la primera diapositiva.
6.	Escribir la presentación modificada como un archivo PPTX.

Este código C++ le muestra cómo crear un marco de zoom en una diapositiva:
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Añade una nueva diapositiva a la presentación
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

//Añade una nueva sección a la presentación
pres->get_Sections()->AddSection(u"Section 1", slide);

//Añade un objeto SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

//Guarda la presentación
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Crear marcos de zoom de sección con imágenes personalizadas**

Usando Aspose.Slides para C++, puede crear un marco de zoom de sección con una imagen de vista previa diferente de la diapositiva de esta manera: 

1.	Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2.	Crear una nueva diapositiva.
3.	Agregar un fondo de identificación a la diapositiva creada.
4.	Crear una nueva sección a la que desea enlazar el marco de zoom. 
5.	Crear un objeto [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) agregando una imagen a la colección Images asociada con el objeto [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) que se utilizará para rellenar el marco.
5.	Agregar un marco de zoom de sección (conteniendo una referencia a la sección creada) a la primera diapositiva.
6.	Escribir la presentación modificada como un archivo PPTX.

Este código C++ le muestra cómo crear un marco de zoom con una imagen diferente:
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Añade una nueva diapositiva a la presentación
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Añade una nueva sección a la presentación
pres->get_Sections()->AddSection(u"Section 1", slide);

// Crea una nueva imagen para el objeto zoom
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

// Añade un objeto SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1), image);

// Guarda la presentación
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Formato de los marcos de zoom de sección**

Para crear marcos de zoom de sección más complejos, debe alterar el formato de un marco simple. Hay varias opciones de formato que puede aplicar a un marco de zoom de sección. 

Puede controlar el formato de un marco de zoom de sección en una diapositiva de esta manera:

1.	Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2.	Crear una nueva diapositiva.
3.	Agregar un fondo de identificación a la diapositiva creada.
4.	Crear una nueva sección a la que desea enlazar el marco de zoom. 
5.	Agregar un marco de zoom de sección (conteniendo referencias a la sección creada) a la primera diapositiva.
6.	Cambiar el tamaño y la posición del objeto de zoom de sección creado.
7.	Crear un objeto [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) agregando una imagen a la colección Images asociada con el objeto [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) que se utilizará para rellenar el marco.
8.	Establecer una imagen personalizada para el objeto de marco de zoom de sección creado.
9.	Establecer la capacidad de *volver a la diapositiva original desde la sección enlazada*. 
10.	Eliminar el fondo de la imagen del objeto de marco de zoom de sección.
11.	Cambiar el formato de línea para el segundo objeto de marco de zoom.
12.	Cambiar la duración de la transición.
13.	Escribir la presentación modificada como un archivo PPTX.

Este código C++ le muestra cómo cambiar el formato de un marco de zoom de sección:
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Añade una nueva diapositiva a la presentación
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Añade una nueva sección a la presentación
pres->get_Sections()->AddSection(u"Section 1", slide);

// Añade objeto SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// Formato para SectionZoomFrame
sectionZoomFrame->set_X(100.0f);
sectionZoomFrame->set_Y(300.0f);
sectionZoomFrame->set_Width(100.0f);
sectionZoomFrame->set_Height(75.0f);

auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
sectionZoomFrame->set_Image(image);

sectionZoomFrame->set_ReturnToParent(true);
sectionZoomFrame->set_ShowBackground(false);

auto sectionZoomLineFormat = sectionZoomFrame->get_LineFormat();
sectionZoomLineFormat->get_FillFormat()->set_FillType(FillType::Solid);
sectionZoomLineFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Brown());
sectionZoomLineFormat->set_DashStyle(LineDashStyle::DashDot);
sectionZoomLineFormat->set_Width(2.5f);

sectionZoomFrame->set_TransitionDuration(1.5f);

// Guarda la presentación
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **Zoom de resumen**

Un zoom de resumen es como una página de destino donde todas las piezas de su presentación se muestran a la vez. Cuando está presentando, puede usar el zoom para pasar de un lugar de su presentación a otro en cualquier orden que desee. Puede ser creativo, avanzar rápidamente o volver a visitar partes de su presentación sin interrumpir el flujo.

![overview_image](sumzoomsel.png)

Para los objetos de zoom de resumen, Aspose.Slides proporciona las interfaces [ISummaryZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_frame), [ISummaryZoomSection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section) y [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section_collection), y algunos métodos bajo la interfaz [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection).

### **Crear zoom de resumen**

Puede agregar un marco de zoom de resumen a una diapositiva de esta manera:

1.	Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2.	Crear nuevas diapositivas con fondo de identificación y nuevas secciones para las diapositivas creadas.
3.	Agregar el marco de zoom de resumen a la primera diapositiva.
4.	Escribir la presentación modificada como un archivo PPTX.

Este código C++ le muestra cómo crear un marco de zoom de resumen en una diapositiva:
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// Añade una nueva diapositiva a la presentación
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Añade una nueva sección a la presentación
pres->get_Sections()->AddSection(u"Section 1", slide);

// Añade una nueva diapositiva a la presentación
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Añade una nueva sección a la presentación
pres->get_Sections()->AddSection(u"Section 2", slide);

// Añade una nueva diapositiva a la presentación
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Añade una nueva sección a la presentación
pres->get_Sections()->AddSection(u"Section 3", slide);

// Añade una nueva diapositiva a la presentación
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_DarkGreen());

// Añade una nueva sección a la presentación
pres->get_Sections()->AddSection(u"Section 4", slide);

// Añade un objeto SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// Guarda la presentación
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Agregar y eliminar una sección de zoom de resumen**

Todas las secciones en un marco de zoom de resumen están representadas por objetos [ISummaryZoomSection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section), que se almacenan en el objeto [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section_collection). Puede agregar o eliminar un objeto de sección de zoom de resumen a través de la interfaz [ISummaryZoomSectionCollection] de esta manera:

1.	Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2.	Crear nuevas diapositivas con fondo de identificación y nuevas secciones para las diapositivas creadas.
3.	Agregar un marco de zoom de resumen a la primera diapositiva.
4.	Agregar una nueva diapositiva y sección a la presentación.
5.	Agregar la sección creada al marco de zoom de resumen.
6.	Eliminar la primera sección del marco de zoom de resumen.
7.	Escribir la presentación modificada como un archivo PPTX.

Este código C++ le muestra cómo agregar y eliminar secciones en un marco de zoom de resumen:
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Añade una nueva diapositiva a la presentación
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Añade una nueva sección a la presentación
pres->get_Sections()->AddSection(u"Section 1", slide);

//Añade una nueva diapositiva a la presentación
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Añade una nueva sección a la presentación
pres->get_Sections()->AddSection(u"Section 2", slide);

// Añade un objeto SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

//Añade una nueva diapositiva a la presentación
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Añade una nueva sección a la presentación
auto section3 = pres->get_Sections()->AddSection(u"Section 3", slide);

// Añade una sección al Summary Zoom
summaryZoomFrame->get_SummaryZoomCollection()->AddSummaryZoomSection(section3);

// Elimina la sección del Summary Zoom
summaryZoomFrame->get_SummaryZoomCollection()->RemoveSummaryZoomSection(pres->get_Sections()->idx_get(1));

// Guarda la presentación
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Formato de las secciones de zoom de resumen**

Para crear objetos de sección de zoom de resumen más complejos, debe alterar el formato de un marco simple. Hay varias opciones de formato que puede aplicar a un objeto de sección de zoom de resumen. 

Puede controlar el formato de un objeto de sección de zoom de resumen en un marco de zoom de resumen de esta manera:

1.	Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2.	Crear nuevas diapositivas con fondo de identificación y nuevas secciones para las diapositivas creadas.
3.	Agregar un marco de zoom de resumen a la primera diapositiva.
4.	Obtener un objeto de sección de zoom de resumen para el primer objeto de la `ISummaryZoomSectionCollection`.
7.	Crear un objeto [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) agregando una imagen a la colección images asociada con el objeto [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) que se utilizará para rellenar el marco.
8.	Establecer una imagen personalizada para el objeto de marco de zoom de sección creado.
9.	Establecer la capacidad de *volver a la diapositiva original desde la sección enlazada*. 
11.	Cambiar el formato de línea para el segundo objeto de marco de zoom.
12.	Cambiar la duración de la transición.
13.	Escribir la presentación modificada como un archivo PPTX.

Este código C++ le muestra cómo cambiar el formato de un objeto de sección de zoom de resumen:
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Añade una nueva diapositiva a la presentación
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Añade una nueva sección a la presentación
pres->get_Sections()->AddSection(u"Section 1", slide);

//Añade una nueva diapositiva a la presentación
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Añade una nueva sección a la presentación
pres->get_Sections()->AddSection(u"Section 2", slide);

// Añade un objeto SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// Obtiene el primer objeto SummaryZoomSection
auto summarySection = summaryZoomFrame->get_SummaryZoomCollection()->idx_get(0);

// Formato para el objeto SummaryZoomSection
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
summarySection->set_Image(image);

summarySection->set_ReturnToParent(false);

summarySection->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
summarySection->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
summarySection->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);
summarySection->get_LineFormat()->set_Width(1.5f);

summarySection->set_TransitionDuration(1.5f);

// Guarda la presentación
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **FAQ**

**¿Puedo controlar el regreso a la diapositiva “principal” después de mostrar el objetivo?**

Sí. El [Zoom frame](https://reference.aspose.com/slides/cpp/aspose.slides/zoomframe/) o [section](https://reference.aspose.com/slides/cpp/aspose.slides/sectionzoomframe/) tiene un método `set_ReturnToParent` que devuelve al espectador a la diapositiva de origen después de visitar el contenido objetivo.

**¿Puedo ajustar la “velocidad” o duración de la transición del Zoom?**

Sí. Zoom permite establecer una duración de transición para que pueda controlar cuánto tiempo tarda la animación de salto.

**¿Hay límites en la cantidad de objetos Zoom que una presentación puede contener?**

No hay un límite estricto documentado en la API. Los límites prácticos dependen de la complejidad general de la presentación y del rendimiento del visor. Puede agregar muchos marcos de Zoom, pero considere el tamaño del archivo y el tiempo de renderizado.