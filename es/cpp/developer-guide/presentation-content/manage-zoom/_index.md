---
title: Administrar Zoom
type: docs
weight: 60
url: /cpp/manage-zoom/
keywords: "Zoom, marco de zoom, Agregar zoom, Formato marco de zoom, Zoom resumen, presentación de PowerPoint, C++, Aspose.Slides para C++"
description: "Agregar zoom o marcos de zoom a presentaciones de PowerPoint en C++"
---

## **Descripción general**
Los zooms en PowerPoint te permiten saltar hacia y desde diapositivas específicas, secciones y partes de una presentación. Cuando estás presentando, esta capacidad de navegar rápidamente entre el contenido puede resultar muy útil. 

![overview_image](Overview.png)

* Para resumir toda una presentación en una única diapositiva, utiliza un [Zoom resumen](#Summary-Zoom).
* Para mostrar solo diapositivas seleccionadas, utiliza un [Zoom de diapositiva](#Slide-Zoom).
* Para mostrar solo una sección, utiliza un [Zoom de sección](#Section-Zoom).

## **Zoom de diapositiva**
Un zoom de diapositiva puede hacer que tu presentación sea más dinámica, permitiéndote navegar libremente entre diapositivas en cualquier orden que elijas sin interrumpir el flujo de tu presentación. Los zooms de diapositiva son excelentes para presentaciones cortas sin muchas secciones, pero aún puedes usarlos en diferentes escenarios de presentación.

Los zooms de diapositiva te ayudan a profundizar en múltiples piezas de información mientras sientes que estás en un solo lienzo. 

![overview_image](slidezoomsel.png)

Para objetos de zoom de diapositiva, Aspose.Slides proporciona la enumeración [ZoomImageType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#ac0802a52a7f14a457b62e9761a77e8e2), la interfaz [IZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_zoom_frame) y algunos métodos bajo la interfaz [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection).

### **Creando marcos de zoom**

Puedes agregar un marco de zoom a una diapositiva de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Crea nuevas diapositivas a las que pretendes vincular los marcos de zoom. 
3. Agrega un texto de identificación y un fondo a las diapositivas creadas.
4. Agrega marcos de zoom (contenido las referencias a las diapositivas creadas) a la primera diapositiva.
5. Escribe la presentación modificada como un archivo PPTX.

Este código C++ te muestra cómo crear un marco de zoom en una diapositiva:

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

//Agrega nuevas diapositivas a la presentación
auto slide2 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// Crea un fondo para la segunda diapositiva
SetSlideBackground(slide2, Color::get_Cyan());

// Crea un cuadro de texto para la segunda diapositiva
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Segunda Diapositiva");

// Crea un fondo para la tercera diapositiva
SetSlideBackground(slide3, Color::get_DarkKhaki());

// Crea un cuadro de texto para la tercera diapositiva
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Tercera Diapositiva");

//Agrega objetos ZoomFrame
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
slide0->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Guarda la presentación
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Creando marcos de zoom con imágenes personalizadas**
Con Aspose.Slides para C++, puedes crear un marco de zoom con una imagen de vista previa diferente de la diapositiva de esta manera: 
1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Crea una nueva diapositiva a la que pretendes vincular el marco de zoom. 
3. Agrega un texto de identificación y un fondo a la diapositiva.
4. Crea un objeto [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) al agregar una imagen a la colección de Imágenes asociada con el objeto [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) que se utilizará para llenar el marco.
5. Agrega marcos de zoom (conteniendo la referencia a la diapositiva creada) a la primera diapositiva.
6. Escribe la presentación modificada como un archivo PPTX.

Este código C++ te muestra cómo crear un marco de zoom con una imagen diferente:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Agrega una nueva diapositiva a la presentación
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// Crea un fondo para la segunda diapositiva
SetSlideBackground(slide, Color::get_Cyan());

// Crea un cuadro de texto para la tercera diapositiva
auto autoshape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Segunda Diapositiva");

// Crea una nueva imagen para el objeto de zoom
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

//Agrega el objeto ZoomFrame
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, slide, image);

// Guarda la presentación
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Formateo de marcos de zoom**
En las secciones anteriores, te mostramos cómo crear marcos de zoom simples. Para crear marcos de zoom más complicados, debes alterar el formato de un marco simple. Hay varias opciones de formato que puedes aplicar a un marco de zoom. 

Puedes controlar el formato de un marco de zoom en una diapositiva de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Crea nuevas diapositivas a las que pretendes vincular el marco de zoom. 
3. Agrega un texto e identificación en el fondo a las diapositivas creadas.
4. Agrega marcos de zoom (conteniendo las referencias a las diapositivas creadas) a la primera diapositiva.
5. Crea un objeto [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) al agregar una imagen a la colección de Imágenes asociada con el objeto [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) que se utilizará para llenar el marco.
6. Establece una imagen personalizada para el primer objeto de marco de zoom.
7. Cambia el formato de línea para el segundo objeto de marco de zoom.
8. Elimina el fondo de una imagen del segundo objeto de marco de zoom.
5. Escribe la presentación modificada como un archivo PPTX.

Este código C++ te muestra cómo cambiar el formato de un marco de zoom en una diapositiva: 

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide1 = pres->get_Slides()->idx_get(0);
//Agrega nuevas diapositivas a la presentación
auto slide2 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());

// Crea un fondo para la segunda diapositiva
SetSlideBackground(slide2, Color::get_Cyan());

// Crea un cuadro de texto para la segunda diapositiva
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Segunda Diapositiva");

// Crea un fondo para la tercera diapositiva
SetSlideBackground(slide3, Color::get_DarkKhaki());

// Crea un cuadro de texto para la tercera diapositiva
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Tercera Diapositiva");

//Agrega objetos ZoomFrame
auto zoomFrame1 = slide1->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
auto zoomFrame2 = slide1->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Crea una nueva imagen para el objeto de zoom
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
// Establece la imagen personalizada para el objeto zoomFrame1
zoomFrame1->set_Image(image);

// Establece un formato de marco de zoom para el objeto zoomFrame2
zoomFrame2->get_LineFormat()->set_Width(5);
zoomFrame2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
zoomFrame2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_HotPink());
zoomFrame2->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);

// Configuración para No mostrar fondo para el objeto zoomFrame2
zoomFrame2->set_ShowBackground(false);

// Guarda la presentación
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **Zoom de sección**

Un zoom de sección es un enlace a una sección en tu presentación. Puedes usar los zooms de sección para volver a las secciones que realmente deseas enfatizar. O puedes usarlos para resaltar cómo ciertas piezas de tu presentación se conectan. 

![overview_image](seczoomsel.png)

Para objetos de zoom de sección, Aspose.Slides proporciona la interfaz [ISectionZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_section_zoom_frame) y algunos métodos bajo la interfaz [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection).

### **Creando marcos de zoom de sección**

Puedes agregar un marco de zoom de sección a una diapositiva de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Crea una nueva diapositiva. 
3. Agrega un fondo de identificación a la diapositiva creada.
4. Crea una nueva sección a la que pretendes vincular el marco de zoom. 
5. Agrega un marco de zoom de sección (contenido las referencias a la sección creada) a la primera diapositiva.
6. Escribe la presentación modificada como un archivo PPTX.

Este código C++ te muestra cómo crear un marco de zoom en una diapositiva:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Agrega una nueva diapositiva a la presentación
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Agrega una nueva sección a la presentación
pres->get_Sections()->AddSection(u"Sección 1", slide);

// Agrega un objeto SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// Guarda la presentación
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```
### **Creando marcos de zoom de sección con imágenes personalizadas**

Usando Aspose.Slides para C++, puedes crear un marco de zoom de sección con una imagen de vista previa diferente de la diapositiva de esta manera: 

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Crea una nueva diapositiva.
3. Agrega un fondo de identificación a la diapositiva creada.
4. Crea una nueva sección a la que pretendes vincular el marco de zoom. 
5. Crea un objeto [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) al agregar una imagen a la colección de Imágenes asociada con el objeto [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) que se utilizará para llenar el marco.
5. Agrega un marco de zoom de sección (conteniendo una referencia a la sección creada) a la primera diapositiva.
6. Escribe la presentación modificada como un archivo PPTX.

Este código C++ te muestra cómo crear un marco de zoom con una imagen diferente:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Agrega nueva diapositiva a la presentación
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Agrega una nueva sección a la presentación
pres->get_Sections()->AddSection(u"Sección 1", slide);

// Crea una nueva imagen para el objeto de zoom
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

// Agrega objeto SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1), image);

// Guarda la presentación
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Formateo de marcos de zoom de sección**

Para crear marcos de zoom de sección más complicados, debes alterar el formato de un marco simple. Hay varias opciones de formato que puedes aplicar a un marco de zoom de sección. 

Puedes controlar el formato de un marco de zoom de sección en una diapositiva de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Crea una nueva diapositiva.
3. Agrega un fondo de identificación a la diapositiva creada.
4. Crea una nueva sección a la que pretendes vincular el marco de zoom. 
5. Agrega un marco de zoom de sección (contenido las referencias a la sección creada) a la primera diapositiva.
6. Cambia el tamaño y la posición para el objeto de zoom de sección creado.
7. Crea un objeto [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) al agregar una imagen a la colección de Imágenes asociada con el objeto [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) que se utilizará para llenar el marco.
8. Establece una imagen personalizada para el objeto de marco de zoom de sección creado.
9. Establece la capacidad de *regresar a la diapositiva original desde la sección vinculada*. 
10. Elimina el fondo de una imagen del objeto de marco de zoom de sección.
11. Cambia el formato de línea para el segundo objeto de marco de zoom.
12. Cambia la duración de la transición.
13. Escribe la presentación modificada como un archivo PPTX.

Este código C++ te muestra cómo cambiar el formato de un marco de zoom de sección:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Agrega una nueva diapositiva a la presentación
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Agrega una nueva sección a la presentación
pres->get_Sections()->AddSection(u"Sección 1", slide);

// Agrega objeto SectionZoomFrame
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


## **Zoom resumen**

Un zoom resumen es como una página de destino donde se muestran todas las piezas de tu presentación a la vez. Cuando estás presentando, puedes usar el zoom para ir de un lugar a otro en tu presentación en cualquier orden que desees. Puedes ser creativo, saltar adelante o volver a las piezas de tu presentación sin interrumpir el flujo de tu presentación.

![overview_image](sumzoomsel.png)

Para objetos de zoom resumen, Aspose.Slides proporciona las interfaces [ISummaryZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_frame), [ISummaryZoomSection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section) y [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section_collection) y algunos métodos bajo la interfaz [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection).

### **Creando Zoom resumen**

Puedes agregar un marco de zoom resumen a una diapositiva de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Crea nuevas diapositivas con fondo de identificación y nuevas secciones para las diapositivas creadas.
3. Agrega el marco de zoom resumen a la primera diapositiva.
4. Escribe la presentación modificada como un archivo PPTX.

Este código C++ te muestra cómo crear un marco de zoom resumen en una diapositiva:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// Agrega una nueva diapositiva a la presentación
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Agrega una nueva sección a la presentación
pres->get_Sections()->AddSection(u"Sección 1", slide);

// Agrega una nueva diapositiva a la presentación
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Agrega una nueva sección a la presentación
pres->get_Sections()->AddSection(u"Sección 2", slide);

// Agrega una nueva diapositiva a la presentación
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Agrega una nueva sección a la presentación
pres->get_Sections()->AddSection(u"Sección 3", slide);

// Agrega una nueva diapositiva a la presentación
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_DarkGreen());

// Agrega una nueva sección a la presentación
pres->get_Sections()->AddSection(u"Sección 4", slide);

// Agrega un objeto SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// Guarda la presentación
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Agregando y removiendo secciones de Zoom resumen**

Todas las secciones en un marco de zoom resumen están representadas por objetos [ISummaryZoomSection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section), que se almacenan en el objeto [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section_collection). Puedes agregar o remover un objeto de sección de zoom resumen a través de la interfaz [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section_collection) de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Crea nuevas diapositivas con fondo de identificación y nuevas secciones para las diapositivas creadas.
3. Agrega un marco de zoom resumen a la primera diapositiva.
4. Agrega una nueva diapositiva y sección a la presentación.
5. Agrega la sección creada al marco de zoom resumen.
6. Remueve la primera sección del marco de zoom resumen.
7. Escribe la presentación modificada como un archivo PPTX.

Este código C++ te muestra cómo agregar y remover secciones en un marco de zoom resumen:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Agrega una nueva diapositiva a la presentación
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Agrega una nueva sección a la presentación
pres->get_Sections()->AddSection(u"Sección 1", slide);

//Agrega una nueva diapositiva a la presentación
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Agrega una nueva sección a la presentación
pres->get_Sections()->AddSection(u"Sección 2", slide);

// Agrega el objeto SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

//Agrega una nueva diapositiva a la presentación
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Agrega una nueva sección a la presentación
auto section3 = pres->get_Sections()->AddSection(u"Sección 3", slide);

// Agrega una sección al Zoom Resumen
summaryZoomFrame->get_SummaryZoomCollection()->AddSummaryZoomSection(section3);

// Remueve la sección del Zoom Resumen
summaryZoomFrame->get_SummaryZoomCollection()->RemoveSummaryZoomSection(pres->get_Sections()->idx_get(1));

// Guarda la presentación
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Formateo de secciones de Zoom resumen**

Para crear objetos de sección de zoom resumen más complicados, debes alterar el formato de un marco simple. Hay varias opciones de formato que puedes aplicar a un objeto de sección de zoom resumen. 

Puedes controlar el formato para un objeto de sección de zoom resumen en un marco de zoom resumen de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Crea nuevas diapositivas con fondo de identificación y nuevas secciones para las diapositivas creadas.
3. Agrega un marco de zoom resumen a la primera diapositiva.
4. Obtén un objeto de sección de zoom resumen para el primer objeto de la `ISummaryZoomSectionCollection`.
7. Crea un objeto [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) al agregar una imagen a la colección de imágenes asociada con el objeto [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) que se utilizará para llenar el marco.
8. Establece una imagen personalizada para el objeto de marco de zoom de sección creado.
9. Establece la capacidad de *regresar a la diapositiva original desde la sección vinculada*. 
11. Cambia el formato de línea para el segundo objeto de marco de zoom.
12. Cambia la duración de la transición.
13. Escribe la presentación modificada como un archivo PPTX.

Este código C++ te muestra cómo cambiar el formato para un objeto de sección de zoom resumen:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Agrega una nueva diapositiva a la presentación
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Agrega una nueva sección a la presentación
pres->get_Sections()->AddSection(u"Sección 1", slide);

//Agrega una nueva diapositiva a la presentación
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Agrega una nueva sección a la presentación
pres->get_Sections()->AddSection(u"Sección 2", slide);

// Agrega un objeto SummaryZoomFrame
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