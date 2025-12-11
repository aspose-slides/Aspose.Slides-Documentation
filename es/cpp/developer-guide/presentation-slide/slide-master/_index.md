---
title: Administrar maestros de diapositivas de presentación en C++
linktitle: Maestro de diapositiva
type: docs
weight: 80
url: /es/cpp/slide-master/
keywords:
- maestro de diapositiva
- diapositiva maestra
- diapositiva maestra PPT
- varias diapositivas maestras
- comparar diapositivas maestras
- fondo
- marcador de posición
- clonar diapositiva maestra
- copiar diapositiva maestra
- duplicar diapositiva maestra
- diapositiva maestra sin usar
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Administrar maestros de diapositivas en Aspose.Slides para C++: crear, editar y aplicar diseños, temas y marcadores de posición a PPT, PPTX y ODP con ejemplos concisos en C++."
---

## **Qué es un Slide Master en PowerPoint**

Un **Slide Master** es una plantilla de diapositiva que define el diseño, los estilos, el tema, las fuentes, el fondo y otras propiedades para las diapositivas en una presentación. Si desea crear una presentación (o una serie de presentaciones) con el mismo estilo y plantilla para su empresa, puede usar un Slide Master. 

Un Slide Master es útil porque le permite establecer y cambiar el aspecto de todas las diapositivas de la presentación de una sola vez. Aspose.Slides admite el mecanismo de Slide Master de PowerPoint. 

VBA también le permite manipular un Slide Master y ejecutar las mismas operaciones admitidas en PowerPoint: cambiar fondos, agregar formas, personalizar el diseño, etc. Aspose.Slides proporciona mecanismos flexibles para que pueda usar Slide Masters y realizar tareas básicas con ellos. 

Estas son operaciones básicas de Slide Master:

- Crear un Slide Master.
- Aplicar Slide Master a las diapositivas de la presentación.
- Cambiar el fondo del Slide Master. 
- Agregar una imagen, marcador de posición, Smart Art, etc. al Slide Master.

Estas son operaciones más avanzadas que involucran Slide Master: 

- Comparar Slide Masters.
- Fusionar Slide Masters.
- Aplicar varios Slide Masters.
- Copiar diapositiva con Slide Master a otra presentación.
- Encontrar Slide Masters duplicados en presentaciones.
- Establecer Slide Master como la vista predeterminada de la presentación.

{{% alert color="primary" %}} 

Es posible que desee consultar Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) porque es una implementación en vivo de algunos de los procesos centrales descritos aquí.

{{% /alert %}} 

## **Cómo se aplica un Slide Master**

Antes de trabajar con un Slide Master, es posible que desee comprender cómo se utilizan en las presentaciones y se aplican a las diapositivas. 

* Cada presentación tiene al menos un Slide Master de forma predeterminada. 
* Una presentación puede contener varios Slide Masters. Puede agregar varios Slide Masters y usarlos para dar estilo a diferentes partes de una presentación de distintas maneras. 

En **Aspose.Slides**, un Slide Master está representado por el tipo [**IMasterSlide**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide). 

El objeto [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) de Aspose.Slides contiene la lista [**get_Masters()** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a8fda502eacdf2fe4ccfc1ab0bf185d29) de tipo [**IMasterSlideCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection), que contiene una lista de todos los slides maestros definidos en una presentación. 

Además de las operaciones CRUD, la interfaz [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection) contiene estos métodos útiles: [**AddClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection#aaf86ba9a1c55969e7d5f4dbc8cb233a1) y [**InsertClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection#af297b1c8e31fbcef821f1554b1fbc311). Esos métodos se heredan de la función básica de clonación de diapositivas. Pero al trabajar con Slide Masters, esos métodos le permiten implementar configuraciones complicadas. 

Cuando se agrega una nueva diapositiva a una presentación, se le aplica automáticamente un Slide Master. El Slide Master de la diapositiva anterior se selecciona de forma predeterminada. 

**Nota**: Las diapositivas de la presentación se almacenan en la lista [get_Slides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c), y cada nueva diapositiva se agrega al final de la colección de forma predeterminada. Si una presentación contiene un solo Slide Master, ese Slide Master se selecciona para todas las diapositivas nuevas. Esta es la razón por la que no tiene que definir el Slide Master para cada diapositiva nueva que cree.

El principio es el mismo para PowerPoint y Aspose.Slides. Por ejemplo, en PowerPoint, cuando agrega una nueva presentación, puede simplemente presionar en la línea inferior bajo la última diapositiva y entonces se creará una nueva diapositiva (con el Slide Master de la última presentación):

![todo:image_alt_text](slide-master_1.jpg)

En Aspose.Slides, puede realizar la tarea equivalente con el método [AddClone()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48) bajo la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).

## **Slide Master en la jerarquía de diapositivas**

Usar Slide Layouts con Slide Master permite la máxima flexibilidad. Un Slide Layout le permite establecer los mismos estilos que el Slide Master (fondo, fuentes, formas, etc.). Sin embargo, cuando varios Slide Layouts se combinan en un Slide Master, se crea un nuevo estilo. Cuando aplica un Slide Layout a una sola diapositiva, puede cambiar su estilo del que aplicó el Slide Master.

Slide Master sobrescribe todos los elementos de configuración: Slide Master → Slide Layout → Slide:

![todo:image_alt_text](slide-master_2)

Cada objeto [IMasterSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide) tiene una propiedad [**get_LayoutSlides()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a200db12188121c969627e4c4c0253a37) con una lista de Slide Layouts. Un tipo [Slide](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide) tiene una propiedad [**get_LayoutSlide()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide#a56b36c32cb9e5db97cdbc7e8248f6fa8) con un enlace a un Slide Layout aplicado a la diapositiva. La interacción entre una diapositiva y el Slide Master ocurre a través de un Slide Layout.

{{% alert color="info" title="Nota" %}}

* En Aspose.Slides, todas las configuraciones de diapositiva (Slide Master, Slide Layout y la propia diapositiva) son en realidad objetos de diapositiva que implementan la interfaz [**IBaseSlide**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide).

* Por lo tanto, Slide Master y Slide Layout pueden implementar las mismas propiedades y debe saber cómo se aplicarán sus valores a un objeto [Slide](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide). El Slide Master se aplica primero a una diapositiva y luego se aplica el Slide Layout. Por ejemplo, si el Slide Master y el Slide Layout ambos tienen un valor de fondo, la diapositiva terminará con el fondo del Slide Layout.

{{% /alert %}}

## **Qué compone un Slide Master**

Para comprender cómo se puede cambiar un Slide Master, necesita conocer sus componentes. Estas son las propiedades principales de [MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/).

- [get(set)_Background()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#aeac7142751858f0a68de92f259eb8d35) - obtener/establecer el fondo de la diapositiva.
- [get(set)_BodyStyle](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a51b96aee050a04e6d36b9d08b85dcf55) - obtener/establecer los estilos de texto del cuerpo de la diapositiva.
- [get(set)_Shapes](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#aa6b93a3863b7516d4a1a751a0ca885c7) - obtener/establecer todas las formas del Slide Master (marcadores de posición, marcos de imagen, etc).
- [get(set)_Controls](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#ae05f1e1b686a52728ae94e47f308ff08) - obtener/establecer los controles ActiveX.
- [get_ThemeManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_master_themeable#a70c68d34412e96f3cc24273fde826ecf) - obtener el gestor de temas.
- [get_HeaderFooterManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a755d0d7cc3c677e746499f2a4e33a5cc) - obtener el gestor de encabezado y pie de página.

Métodos de Slide Master:

- [GetDependingSlides](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a9026e22b68087238cc73348e303c6d90) - obtener todas las diapositivas que dependen del Slide Master.
- [ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a8d519dd31014fcbb2be0ab72061f94dc) - le permite crear un nuevo Slide Master basado en el Slide Master actual y un nuevo tema. El nuevo Slide Master se aplicará a todas las diapositivas dependientes.

## **Obtener un Slide Master**

En PowerPoint, el Slide Master se puede acceder desde el menú Ver → Slide Master:

![todo:image_alt_text](slide-master_3.jpg)

Usando Aspose.Slides, puede acceder a un Slide Master de esta manera:
```c++
System::SharedPtr<IMasterSlide> master = pres->get_Masters()->idx_get(0);
```


La interfaz [IMasterSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide) representa un Slide Master. La propiedad [get_Masters()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a8fda502eacdf2fe4ccfc1ab0bf185d29) (relacionada con el tipo [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection)) contiene una lista de todos los Slide Masters que están definidos en la presentación.

## **Agregar una imagen a un Slide Master**

Cuando agrega una imagen a un Slide Master, esa imagen aparecerá en todas las diapositivas dependientes de ese slide master. 

Por ejemplo, puede colocar el logotipo de su empresa y algunas imágenes en el Slide Master y luego volver al modo de edición de diapositivas. Debería ver la imagen en cada diapositiva. 

![todo:image_alt_text](slide-master_4.png)

Puede agregar imágenes a un slide master con Aspose.Slides:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(System::IO::File::ReadAllBytes(u"image.png"));
pres->get_Master(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


{{% alert color="primary" title="Ver también" %}} 

Para obtener más información sobre cómo agregar imágenes a una diapositiva, consulte el artículo [Picture Frame](/slides/es/cpp/picture-frame/#create-picture-frame).

{{% /alert %}}

## **Agregar un marcador de posición a un Slide Master**

Estos campos de texto son marcadores de posición estándar en un Slide Master: 

* Haga clic para editar el estilo del título del Master
* Editar estilos de texto del Master
* Segundo nivel
* Tercer nivel 

También aparecen en las diapositivas basadas en el Slide Master. Puede editar esos marcadores de posición en un Slide Master y los cambios se aplicarán automáticamente a las diapositivas. 

En PowerPoint, puede agregar un marcador de posición a través de la ruta Slide Master → Insert Placeholder:

![todo:image_alt_text](slide-master_5.png)

Examinemos un ejemplo más complicado de marcadores de posición con Aspose.Slides. Considere una diapositiva con marcadores de posición basados en el Slide Master:

![todo:image_alt_text](slide-master_6.png)

Queremos cambiar el formato del Título y el Subtítulo en el Slide Master de esta manera:

![todo:image_alt_text](slide-master_7.png)

Primero, recuperamos el contenido del marcador de posición del título del objeto Slide Master y luego usamos el campo `PlaceHolder.FillFormat`:
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


El estilo y formato del título cambiarán para todas las diapositivas basadas en el slide master:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="Ver también" %}} 

* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/cpp/manage-placeholder/)
* [Text Formatting](https://docs.aspose.com/slides/cpp/text-formatting/)

{{% /alert %}}

## **Cambiar el fondo en un Slide Master**

Cuando cambia el color de fondo de una diapositiva maestra, todas las diapositivas normales de la presentación obtendrán el nuevo color. Este código C++ demuestra la operación:
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

- [Presentation Background](https://docs.aspose.com/slides/cpp/presentation-background/)

- [Presentation Theme](https://docs.aspose.com/slides/cpp/presentation-theme/)

{{% /alert %}}

## **Clonar un Slide Master a otra presentación**

Para clonar un Slide Master a otra presentación, llame al método [**AddClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48) de la presentación de destino junto con un Slide Master pasado a él. Este código C++ le muestra cómo clonar un Slide Master a otra presentación:
```c++
auto presSource = System::MakeObject<Presentation>();
auto presTarget = System::MakeObject<Presentation>();
    
auto master = presTarget->get_Masters()->AddClone(presSource->get_Masters()->idx_get(0));
```


## **Agregar varios Slide Masters a una presentación**

Aspose.Slides le permite agregar varios Slide Masters y Slide Layouts a cualquier presentación. Esto le permite configurar estilos, diseños y opciones de formato para las diapositivas de la presentación de varias maneras. 

En PowerPoint, puede agregar nuevos Slide Masters y Layouts (desde el menú "Slide Master") de esta manera:

![todo:image_alt_text](slide-master_9.jpg)

Usando Aspose.Slides, puede agregar un nuevo Slide Master llamando al método [AddClone()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48):
```c++
pres->get_Masters()->AddClone(pres->get_Masters()->idx_get(0));
```


## **Comparar Slide Masters**

Un Master Slide implementa la interfaz [IBaseSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide) que contiene el método [**Equals()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#afb1febe7cf3991c06f4d96e017c22b6f), que puede usarse para comparar diapositivas. Devuelve `true` para Master Slides idénticos en estructura y contenido estático. 

Dos Master Slides son iguales si sus formas, estilos, textos, animaciones y otras configuraciones, etc., son iguales. La comparación no tiene en cuenta los valores de identificadores únicos (p. ej., SlideId) ni el contenido dinámico (p. ej., el valor de fecha actual en el marcador de posición de fecha).

## **Establecer un Slide Master como la vista predeterminada de la presentación**

Aspose.Slides le permite establecer un Slide Master como la vista predeterminada de una presentación. La vista predeterminada es lo que ve primero al abrir una presentación. 

Este código le muestra cómo establecer un Slide Master como la vista predeterminada de una presentación en C++:
```c++
pres->get_ViewProperties()->set_LastView(Aspose::Slides::ViewType::SlideMasterView);
```


## **Eliminar Master Slides no utilizados**

Aspose.Slides proporciona el método [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) (de la clase [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)) para permitirle eliminar master slides no deseados y sin usar. Este código C++ le muestra cómo eliminar un master slide de una presentación PowerPoint:
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


## **Preguntas frecuentes**

**¿Qué es un Slide Master en PowerPoint?**

Un Slide Master es una plantilla de diapositiva que define el diseño, los estilos, los temas, las fuentes, el fondo y otras propiedades de las diapositivas en una presentación. Le permite establecer y cambiar el aspecto de todas las diapositivas de la presentación de una sola vez.  

**¿Cómo se aplica un Slide Master en una presentación?**

Cada presentación tiene al menos un Slide Master de forma predeterminada. Cuando se agrega una nueva diapositiva, se le aplica automáticamente un Slide Master, normalmente heredando el master de la diapositiva anterior. Una presentación puede contener varios Slide Masters para dar estilo a diferentes partes de forma única.  

**¿Qué elementos se pueden personalizar en un Slide Master?**

- **Background**: Establecer el fondo de la diapositiva.
- **BodyStyle**: Definir los estilos de texto del cuerpo de la diapositiva.
- **Shapes**: Administrar todas las formas en el Slide Master, incluidos los marcadores de posición y los marcos de imagen.
- **Controls**: Gestionar controles ActiveX.
- **ThemeManager**: Acceder al gestor de temas.
- **HeaderFooterManager**: Gestionar encabezados y pies de página.  

**¿Cómo puedo agregar una imagen a un Slide Master?**

Agregar una imagen a un Slide Master garantiza que aparezca en todas las diapositivas que dependen de ese master. Por ejemplo, colocar el logotipo de la empresa en el Slide Master lo mostrará en cada diapositiva de la presentación.  

**¿Cómo se relacionan los Slide Masters con los Slide Layouts?**

Los Slide Layouts funcionan en conjunto con los Slide Masters para brindar flexibilidad en el diseño de las diapositivas. Mientras que un Slide Master define estilos y temas generales, los Slide Layouts permiten variaciones en la organización del contenido. La jerarquía es la siguiente:

- **Slide Master** → Define estilos globales.
- **Slide Layout** → Proporciona diferentes disposiciones de contenido.
- **Slide** → Hereda el diseño de su Slide Layout.

**¿Puedo tener múltiples Slide Masters en una única presentación?**

Sí, una presentación puede contener varios Slide Masters. Esto permite dar estilo a diferentes secciones de una presentación de diversas maneras, proporcionando flexibilidad en el diseño.  

**¿Cómo accedo y modifico un Slide Master usando Aspose.Slides?**

En Aspose.Slides, un Slide Master está representado por la interfaz [IMasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/). Puede acceder a un Slide Master mediante el método [get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) del objeto [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).