---
title: Maestro de Diapositivas
type: docs
weight: 80
url: /cpp/slide-master/
keywords: "Agregar Maestro de Diapositivas, diapositiva maestra PPT, maestro de diapositivas PowerPoint, imagen al Maestro de Diapositivas, Marcador de posición, Múltiples Maestros de Diapositivas, Comparar Maestros de Diapositivas, C++, CPP, Aspose.Slides para C++"
description: "Agregar o editar maestro de diapositivas en la presentación de PowerPoint en C++"
---

## **¿Qué es un Maestro de Diapositivas en PowerPoint?**

Un **Maestro de Diapositivas** es una plantilla de diapositiva que define el diseño, estilos, tema, fuentes, fondo y otras propiedades para las diapositivas en una presentación. Si deseas crear una presentación (o serie de presentaciones) con el mismo estilo y plantilla para tu empresa, puedes usar un maestro de diapositivas. 

Un Maestro de Diapositivas es útil porque te permite establecer y cambiar el aspecto de todas las diapositivas de la presentación a la vez. Aspose.Slides admite el mecanismo de Maestro de Diapositivas de PowerPoint. 

VBA también te permite manipular un Maestro de Diapositivas y ejecutar las mismas operaciones admitidas en PowerPoint: cambiar fondos, agregar formas, personalizar el diseño, etc. Aspose.Slides proporciona mecanismos flexibles que te permiten usar Maestros de Diapositivas y realizar tareas básicas con ellos. 

Estas son las operaciones básicas de Maestro de Diapositivas:

- Crear o editar Maestro de Diapositivas.
- Aplicar Maestros de Diapositivas a las diapositivas de la presentación.
- Cambiar el fondo del Maestro de Diapositivas.
- Agregar una imagen, un marcador de posición, Smart Art, etc. al Maestro de Diapositivas.

Estas son operaciones más avanzadas que involucran el Maestro de Diapositivas: 

- Comparar Maestros de Diapositivas.
- Fusionar Maestros de Diapositivas.
- Aplicar varios Maestros de Diapositivas.
- Copiar una diapositiva con Maestro de Diapositivas a otra presentación.
- Encontrar Maestros de Diapositivas duplicados en presentaciones.
- Configurar el Maestro de Diapositivas como la vista predeterminada de la presentación.

{{% alert color="primary" %}} 

Es posible que desees consultar Aspose [**Visor de PowerPoint en línea**](https://products.aspose.app/slides/viewer) porque es una implementación en vivo de algunos de los procesos centrales descritos aquí.

{{% /alert %}} 

## **Cómo se aplica el Maestro de Diapositivas**

Antes de trabajar con un maestro de diapositivas, es posible que desees entender cómo se utilizan en las presentaciones y se aplican a las diapositivas. 

* Cada presentación tiene al menos un Maestro de Diapositivas por defecto. 
* Una presentación puede contener varios Maestros de Diapositivas. Puedes agregar varios Maestros de Diapositivas y usarlos para dar estilo a diferentes partes de una presentación de diferentes maneras. 

En **Aspose.Slides**, un Maestro de Diapositivas está representado por el tipo [**IMasterSlide**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide). 

El objeto [Presentación](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) de Aspose.Slides contiene la lista [**get_Masters()** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a8fda502eacdf2fe4ccfc1ab0bf185d29) del tipo [**IMasterSlideCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection), que contiene una lista de todas las diapositivas maestras que están definidas en una presentación. 

Además de las operaciones CRUD, la interfaz [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection) contiene estos métodos útiles: [**AddClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection#aaf86ba9a1c55969e7d5f4dbc8cb233a1) y [**InsertClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection#af297b1c8e31fbcef821f1554b1fbc311). Esos métodos son heredados de la función básica de clonación de diapositivas. Pero al tratar con Maestros de Diapositivas, esos métodos te permiten implementar configuraciones complicadas. 

Cuando se agrega una nueva diapositiva a una presentación, un Maestro de Diapositivas se aplica automáticamente a ella. El Maestro de Diapositivas de la diapositiva anterior se selecciona por defecto. 

**Nota**: Las diapositivas de la presentación se almacenan en la lista [get_Slides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) y cada nueva diapositiva se agrega al final de la colección por defecto. Si una presentación contiene un solo Maestro de Diapositivas, ese maestro se selecciona para todas las nuevas diapositivas. Esta es la razón por la que no tienes que definir el Maestro de Diapositivas para cada nueva diapositiva que creas.

El principio es el mismo para PowerPoint y Aspose.Slides. Por ejemplo, en PowerPoint, cuando agregas una nueva presentación, puedes simplemente presionar la línea inferior bajo la última diapositiva y luego se creará una nueva diapositiva (con el Maestro de Diapositivas de la última presentación):

![todo:image_alt_text](slide-master_1.jpg)

En Aspose.Slides, puedes realizar la tarea equivalente con el método [AddClone()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48) de la clase [Presentación](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).

## **Maestro de Diapositivas en la jerarquía de Diapositivas**

El uso de Diseños de Diapositivas con Maestro de Diapositivas permite una flexibilidad máxima. Un Diseño de Diapositiva te permite establecer todos los mismos estilos que el Maestro de Diapositivas (fondo, fuentes, formas, etc.). Sin embargo, cuando varios Diseños de Diapositivas se combinan en un Maestro de Diapositivas, se crea un nuevo estilo. Cuando aplicas un Diseño de Diapositiva a una sola diapositiva, puedes cambiar su estilo del que aplica el Maestro de Diapositivas.

El Maestro de Diapositivas prevalece sobre todos los elementos de configuración: Maestro de Diapositivas -> Diseño de Diapositiva -> Diapositiva:

![todo:image_alt_text](slide-master_2)

Cada objeto [IMasterSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide) tiene una propiedad [**get_LayoutSlides()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a200db12188121c969627e4c4c0253a37) con una lista de Diseños de Diapositivas. Un tipo [Diapositiva](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide) tiene una propiedad [**get_LayoutSlide()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide#a56b36c32cb9e5db97cdbc7e8248f6fa8) con un enlace a un Diseño de Diapositiva aplicado a la diapositiva. La interacción entre una diapositiva y el Maestro de Diapositivas ocurre a través de un Diseño de Diapositiva.

{{% alert color="info" title="Nota" %}}

* En Aspose.Slides, todas las configuraciones de las diapositivas (Maestro de Diapositivas, Diseño de Diapositiva y la diapositiva en sí) son en realidad objetos de diapositiva que implementan la interfaz [**IBaseSlide**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide).
* Por lo tanto, el Maestro de Diapositivas y el Diseño de Diapositiva pueden implementar las mismas propiedades y necesitas saber cómo se aplicarán sus valores a un objeto [Diapositiva](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide). El Maestro de Diapositivas se aplica primero a una diapositiva y luego se aplica el Diseño de Diapositiva. Por ejemplo, si el Maestro de Diapositivas y el Diseño de Diapositiva tienen ambos un valor de fondo, la diapositiva terminará con el fondo del Diseño de Diapositiva.

{{% /alert %}}

## **Qué comprende un Maestro de Diapositivas**

Para entender cómo se puede cambiar un Maestro de Diapositivas, necesitas conocer sus componentes. Estas son las propiedades centrales de [MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/).

- [get(set)_Background()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#aeac7142751858f0a68de92f259eb8d35) - obtener/establecer el fondo de la diapositiva.
- [get(set)_BodyStyle](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a51b96aee050a04e6d36b9d08b85dcf55) - obtener/establecer los estilos de texto del cuerpo de la diapositiva.
- [get(set)_Shapes](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#aa6b93a3863b7516d4a1a751a0ca885c7) - obtener/establecer todas las formas del Maestro de Diapositivas (marcadores de posición, marcos de imágenes, etc.).
- [get(set)_Controls](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#ae05f1e1b686a52728ae94e47f308ff08) - obtener/establecer controles ActiveX.
- [get_ThemeManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_master_themeable#a70c68d34412e96f3cc24273fde826ecf) - obtener el administrador de temas.
- [get_HeaderFooterManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a755d0d7cc3c677e746499f2a4e33a5cc) - obtener el administrador de encabezados y pies de página.

Métodos del Maestro de Diapositivas:

- [GetDependingSlides](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a9026e22b68087238cc73348e303c6d90) - obtener todas las diapositivas que dependen del Maestro de Diapositivas.
- [ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a8d519dd31014fcbb2be0ab72061f94dc) - te permite crear un nuevo Maestro de Diapositivas basado en el Maestro de Diapositivas actual y un nuevo tema. El nuevo Maestro de Diapositivas se aplicará a todas las diapositivas dependientes.

## **Obtener Maestro de Diapositivas**

En PowerPoint, el Maestro de Diapositivas se puede acceder desde el menú Ver -> Maestro de Diapositivas:

![todo:image_alt_text](slide-master_3.jpg)

Usando Aspose.Slides, puedes acceder a un Maestro de Diapositivas de esta manera:

```c++
System::SharedPtr<IMasterSlide> master = pres->get_Masters()->idx_get(0);
```

La interfaz [IMasterSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide) representa un Maestro de Diapositivas. La propiedad [get_Masters()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a8fda502eacdf2fe4ccfc1ab0bf185d29) (relacionada con el tipo [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection)) contiene una lista de todos los Maestros de Diapositivas que están definidos en la presentación.

## **Agregar Imagen al Maestro de Diapositivas**

Cuando agregas una imagen a un Maestro de Diapositivas, esa imagen aparecerá en todas las diapositivas que dependan de ese maestro de diapositivas. 

Por ejemplo, puedes colocar el logotipo de tu empresa y algunas imágenes en el Maestro de Diapositivas y luego volver al modo de edición de la diapositiva. Deberías ver la imagen en cada diapositiva. 

![todo:image_alt_text](slide-master_4.png)

Puedes agregar imágenes a un maestro de diapositivas con Aspose.Slides:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(System::IO::File::ReadAllBytes(u"image.png"));
pres->get_Master(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

{{% alert color="primary" title="Ver también" %}} 

Para obtener más información sobre cómo agregar imágenes a una diapositiva, consulta el artículo [Marco de Imagen](/slides/cpp/picture-frame/#create-picture-frame).
{{% /alert %}}

## **Agregar Marcador de Posición al Maestro de Diapositivas**

Estos campos de texto son marcadores de posición estándar en un Maestro de Diapositivas: 

* Haga clic para editar el estilo del título del Maestro

* Editar los estilos de texto del Maestro

* Segundo nivel

* Tercer nivel 

  También aparecen en las diapositivas basadas en el Maestro de Diapositivas. Puedes editar esos marcadores de posición en un Maestro de Diapositivas y los cambios se aplican automáticamente a las diapositivas. 

En PowerPoint, puedes agregar un marcador de posición a través de la ruta Maestro de Diapositivas -> Insertar Marcador de Posición:

![todo:image_alt_text](slide-master_5.png)

Examinemos un ejemplo más complicado de marcadores de posición con Aspose.Slides. Considera una diapositiva con marcadores de posición plantillados desde el Maestro de Diapositivas:

![todo:image_alt_text](slide-master_6.png)

Queremos cambiar el formato del Título y el Subtítulo en el Maestro de Diapositivas de esta manera:

![todo:image_alt_text](slide-master_7.png)

Primero, recuperamos el contenido del marcador de posición del título desde el objeto Maestro de Diapositivas y luego usamos el campo `PlaceHolder.FillFormat`:

```c++
System::SharedPtr<IAutoShape> FindPlaceholder(System::SharedPtr<IMasterSlide> master, PlaceholderType type)
{
    for (auto& shape : master->get_Shapes())
    {
        System::SharedPtr<IAutoShape> autoShape = System::AsCast<Aspose::Slides::IAutoShape>(shape);
        if (autoShape != nullptr)
        {
            if (autoShape->get_Placeholder()->get_Type() == type)
            {
                return autoShape;
            }
        }
    }
    return nullptr;
}

void Main()
{
    auto pres = System::MakeObject<Presentation>();
    System::SharedPtr<IMasterSlide> master = pres->get_Masters()->idx_get(0);
    System::SharedPtr<IAutoShape> placeHolder = FindPlaceholder(master, Aspose::Slides::PlaceholderType::Title);
    auto fillFormat = placeHolder->get_FillFormat();
    fillFormat->set_FillType(Aspose::Slides::FillType::Gradient);
    auto gradientFormat = fillFormat->get_GradientFormat();
    gradientFormat->set_GradientShape(Aspose::Slides::GradientShape::Linear);
    gradientFormat->get_GradientStops()->Add(0.0f, System::Drawing::Color::FromArgb(255, 0, 0));
    gradientFormat->get_GradientStops()->Add(255.0f, System::Drawing::Color::FromArgb(128, 0, 128));
    
    pres->Save(u"pres.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
}
```

El estilo y formato del título cambiarán para todas las diapositivas basadas en el maestro de diapositivas:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="Ver también" %}} 

* [Configurar Texto de Sugerencia en Marcador de Posición](https://docs.aspose.com/slides/cpp/manage-placeholder/)
* [Formato de Texto](https://docs.aspose.com/slides/cpp/text-formatting/)

{{% /alert %}}

## **Cambiar el Fondo en el Maestro de Diapositivas**

Cuando cambias el color de fondo de un maestro de diapositivas, todas las diapositivas normales en la presentación recibirán el nuevo color. Este código C++ demuestra la operación:

```c++
auto pres = System::MakeObject<Presentation>();

auto master = pres->get_Masters()->idx_get(0);
auto background = master->get_Background();
background->set_Type(Aspose::Slides::BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(Aspose::Slides::FillType::Solid);
background->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Green());
    
pres->Save(u"pres.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="primary" title="Ver también" %}} 

- [Fondo de Presentación](https://docs.aspose.com/slides/cpp/presentation-background/)

- [Tema de Presentación](https://docs.aspose.com/slides/cpp/presentation-theme/)

{{% /alert %}}

## **Clonar Maestro de Diapositivas a Otra Presentación**

Para clonar un Maestro de Diapositivas a otra presentación, llama al método [**AddClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48) de la presentación de destino junto con un Maestro de Diapositivas pasado a él. Este código C++ te muestra cómo clonar un Maestro de Diapositivas a otra presentación:

```c++
auto presSource = System::MakeObject<Presentation>();
auto presTarget = System::MakeObject<Presentation>();
    
auto master = presTarget->get_Masters()->AddClone(presSource->get_Masters()->idx_get(0));
```

## **Agregar Múltiples Maestros de Diapositivas a la Presentación**

Aspose.Slides te permite agregar varios Maestros de Diapositivas y Diseños de Diapositivas a cualquier presentación dada. Esto te permite configurar estilos, diseños y opciones de formato para las diapositivas de la presentación de muchas maneras. 

En PowerPoint, puedes agregar nuevos Maestros de Diapositivas y Diseños (desde el menú "Maestro de Diapositivas) de esta manera:

![todo:image_alt_text](slide-master_9.jpg)

Usando Aspose.Slides, puedes agregar un nuevo Maestro de Diapositivas llamando al método [AddClone()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48):

```c++
pres->get_Masters()->AddClone(pres->get_Masters()->idx_get(0));
```

## **Comparar Maestros de Diapositivas**

Un Maestro de Diapositivas implementa la interfaz [IBaseSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide) que contiene el método [**Equals()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#afb1febe7cf3991c06f4d96e017c22b6f), que se puede utilizar para comparar diapositivas. Devuelve `true` para los Maestros de Diapositivas idénticos en estructura y contenido estático. 

Dos Maestros de Diapositivas son iguales si sus formas, estilos, textos, animaciones y otras configuraciones son iguales. La comparación no tiene en cuenta los valores de identificador único (por ejemplo, SlideId) y contenido dinámico (por ejemplo, valor de fecha actual en Marcador de Posición de Fecha). 

## **Establecer Maestro de Diapositivas como Vista Predeterminada de la Presentación**

Aspose.Slides te permite establecer un Maestro de Diapositivas como la vista predeterminada para una presentación. La vista predeterminada es lo que ves primero cuando abres una presentación. 

Este código te muestra cómo establecer un Maestro de Diapositivas como la vista predeterminada de una presentación en C++:

```c++
pres->get_ViewProperties()->set_LastView(Aspose::Slides::ViewType::SlideMasterView);
```

## **Eliminar Maestro de Diapositivas No Utilizado**

Aspose.Slides proporciona el método [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) (de la clase [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)) para permitirte eliminar maestros de diapositivas no deseados y no utilizados. Este código C++ te muestra cómo eliminar un maestro de diapositivas de una presentación de PowerPoint:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```