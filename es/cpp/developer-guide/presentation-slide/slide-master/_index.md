---
title: Administrar maestros de diapositivas de presentaciones en C++
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
- diapositiva maestra no usada
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Administrar maestros de diapositivas en Aspose.Slides para C++: acceder, editar, clonar, comparar y eliminar diapositivas maestras en presentaciones PowerPoint y OpenDocument."
---
## **Descripción general**

Un **slide master** define los ajustes de diseño compartidos para un conjunto de diapositivas. Puede contener formas comunes, logotipos, fondos, estilos de texto, ajustes de tema y de pie de página. En PowerPoint, editar un slide master es la forma habitual de mantener una presentación coherente sin repetir el mismo formato en cada diapositiva.

Aspose.Slides para C++ admite el mismo modelo. Una presentación puede contener una o varias diapositivas master, y cada diapositiva master puede contener varias diapositivas de diseño. Normalmente, las diapositivas habituales no hacen referencia directa a una diapositiva master. En su lugar, una diapositiva habitual utiliza una diapositiva de diseño, y esa diapositiva de diseño pertenece a una diapositiva master.

La jerarquía es:

1. **Slide master** - define el diseño y tema compartidos.  
1. **Layout slide** - define una disposición específica de marcadores de posición y formato a nivel de diseño.  
1. **Normal slide** - contiene el contenido real de la presentación y utiliza una diapositiva de diseño.

![Jerarquía de diapositivas master, diapositivas de diseño y diapositivas habituales](slide-master_2.jpg)

En Aspose.Slides, un slide master está representado por la interfaz [IMasterSlide](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterslide/). Todas las diapositivas master de una presentación están disponibles mediante la colección [Presentation::get_Masters](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_masters/), que implementa [IMasterSlideCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Herencia" %}}
Cuando la misma propiedad se define en más de un nivel, gana el nivel más específico. Por ejemplo, si una diapositiva master y una diapositiva de diseño definen ambas un fondo, las diapositivas basadas en ese diseño utilizan el fondo del diseño. Para obtener más información sobre las diapositivas de diseño, consulte [Aplicar o cambiar diseños de diapositivas](/slides/es/cpp/slide-layout/).
{{% /alert %}}

## **Acceder a los slide masters**

En PowerPoint, puede abrir la vista Slide Master desde **View** > **Slide Master**.

![El comando Slide Master en la pestaña View de PowerPoint](slide-master_3.jpg)

En Aspose.Slides, use la colección `get_Masters()` para acceder a las diapositivas master:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstMasterSlide = presentation->get_Master(0);
auto masterSlideCount = presentation->get_Masters()->get_Count();
auto firstMasterLayoutSlideCount = firstMasterSlide->get_LayoutSlides()->get_Count();

System::Console::WriteLine(System::String(u"Master slides: ") + masterSlideCount);
System::Console::WriteLine(System::String(u"Layouts in the first master: ") + firstMasterLayoutSlideCount);

presentation->Dispose();
```

También puede obtener la diapositiva master utilizada por una diapositiva habitual a través de su diseño:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slide = presentation->get_Slide(0);
auto layoutSlide = slide->get_LayoutSlide();
auto masterSlide = layoutSlide->get_MasterSlide();
auto masterSlideName = masterSlide->get_Name();

System::Console::WriteLine(masterSlideName);

presentation->Dispose();
```

## **Qué contiene un slide master**

Una diapositiva master es un objeto similar a una diapositiva. Implementa [IBaseSlide](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibaseslide/), por lo que expone muchas de las mismas propiedades de diapositiva que usan las diapositivas habituales y de diseño. Los miembros específicos del master aparecen en la página de la API [IMasterSlide](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterslide/).

Los miembros de diapositiva master más usados incluyen:

| Miembro | Propósito |
| --- | --- |
| `get_Background()` | Establece el fondo de la diapositiva a nivel de master. |
| `get_Shapes()` | Almacena las formas colocadas en el master, como logotipos, marcos de imágenes y texto compartido. |
| `get_LayoutSlides()` | Almacena las diapositivas de diseño que pertenecen al master. |
| `get_ThemeManager()` | Proporciona acceso a las API del tema del master. |
| `get_HeaderFooterManager()` | Controla encabezados, pies de página, fechas y números de diapositiva para el master y sus diseños hijos. |
| `GetDependingSlides()` | Devuelve las diapositivas habituales que dependen del master a través de sus diseños. |

## **Añadir una imagen a un slide master**

Cuando añades una imagen a una diapositiva master, aparece en las diapositivas que utilizan diseños de ese master. Es útil para logotipos, marcas de agua, bandas decorativas y otros elementos visuales repetidos.

El siguiente ejemplo añade un logotipo a la primera diapositiva master:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto logoBytes = System::IO::File::ReadAllBytes(u"logo.png");
auto logoImage = presentation->get_Images()->AddImage(logoBytes);

masterSlide->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle,
    20.0f,
    20.0f,
    80.0f,
    80.0f,
    logoImage);

presentation->Save(u"presentation-with-logo.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Para obtener más información sobre marcos de imágenes, consulte [Marco de imagen](/slides/es/cpp/picture-frame/).

## **Trabajar con marcadores de posición**

Los marcadores de posición se definen normalmente en las diapositivas de diseño. La diapositiva master proporciona el estilo y tema compartidos que esos diseños heredan, mientras que cada diseño decide qué marcadores de posición están disponibles y dónde se colocan.

En PowerPoint, los comandos de marcador de posición están disponibles en la vista Slide Master.

![El comando Insertar marcador de posición en la vista Slide Master de PowerPoint](slide-master_5.png)

Para añadir nuevos marcadores de posición con Aspose.Slides, trabaje con la diapositiva de diseño que pertenece al master:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto blankLayoutSlide = masterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayoutSlide == nullptr)
{
    blankLayoutSlide = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::Blank, u"Blank");
}

blankLayoutSlide->get_PlaceholderManager()->AddTextPlaceholder(
    60.0f,
    120.0f,
    600.0f,
    80.0f);

presentation->get_Slides()->AddEmptySlide(blankLayoutSlide);
presentation->Save(u"presentation-with-placeholder.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

También puede formatear las formas de marcador de posición que ya existen en una diapositiva master. El siguiente ejemplo localiza el marcador de posición de título y le aplica un relleno de degradado lineal:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
System::SharedPtr<IAutoShape> titlePlaceholder;

for (auto&& shape : masterSlide->get_Shapes())
{
    auto autoShape = System::AsCast<IAutoShape>(shape);

    if (autoShape != nullptr &&
        autoShape->get_Placeholder() != nullptr &&
        autoShape->get_Placeholder()->get_Type() == PlaceholderType::Title)
    {
        titlePlaceholder = autoShape;
        break;
    }
}

if (titlePlaceholder != nullptr)
{
    auto fillFormat = titlePlaceholder->get_FillFormat();
    fillFormat->set_FillType(FillType::Gradient);

    auto gradientFormat = fillFormat->get_GradientFormat();
    gradientFormat->set_GradientShape(GradientShape::Linear);

    auto gradientStops = gradientFormat->get_GradientStops();
    auto redGradientColor = System::Drawing::Color::FromArgb(255, 0, 0);
    auto purpleGradientColor = System::Drawing::Color::FromArgb(128, 0, 128);

    gradientStops->Add(0.0f, redGradientColor);
    gradientStops->Add(255.0f, purpleGradientColor);
}

presentation->Save(u"presentation-title-style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Marcador de posición de título formateado heredado por diapositivas habituales](slide-master_8.png)

Para más opciones de marcadores de posición y formato de texto, vea [Establecer texto de solicitud en marcador de posición](/slides/es/cpp/manage-placeholder/) y [Formato de texto](/slides/es/cpp/text-formatting/).

## **Cambiar el fondo de un slide master**

Un fondo de master se hereda por los diseños y las diapositivas que no lo sobrescriben. El siguiente ejemplo establece un color de fondo sólido para la primera diapositiva master:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto masterBackgroundColor = System::Drawing::Color::get_ForestGreen();

masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(masterBackgroundColor);

presentation->Save(u"presentation-master-background.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Para temas relacionados, vea [Fondo de presentación](/slides/es/cpp/presentation-background/) y [Tema de presentación](/slides/es/cpp/presentation-theme/).

## **Clonar un slide master a otra presentación**

Utilice [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterslidecollection/addclone/) para copiar una diapositiva master a otra presentación. El master copiado puede entonces ser usado por diseños y diapositivas en la presentación de destino.

```cpp
auto sourcePresentation = System::MakeObject<Presentation>(u"source.pptx");
auto destinationPresentation = System::MakeObject<Presentation>(u"destination.pptx");

auto sourceMasterSlide = sourcePresentation->get_Master(0);
auto clonedMasterSlide = destinationPresentation->get_Masters()->AddClone(sourceMasterSlide);

destinationPresentation->Save(u"destination-with-master.pptx", SaveFormat::Pptx);
destinationPresentation->Dispose();
sourcePresentation->Dispose();
```

Si necesita clonar diapositivas habituales junto con su master, consulte [Clonar diapositivas](/slides/es/cpp/clone-slides/).

## **Añadir varios slide masters**

Una presentación puede contener varias diapositivas master. Esto es útil cuando diferentes secciones requieren distintas marcas, estructuras de página o ajustes de tema.

![Comandos de PowerPoint para insertar y gestionar diapositivas master](slide-master_9.jpg)

El siguiente ejemplo clona el master predeterminado, le da al clon un fondo diferente, crea un diseño bajo ese master clonado y añade una nueva diapositiva basada en ese diseño:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto defaultMasterSlide = presentation->get_Master(0);
auto sectionMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);
auto sectionMasterBackgroundColor = System::Drawing::Color::get_LightSteelBlue();

sectionMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
sectionMasterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
sectionMasterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(sectionMasterBackgroundColor);

auto sourceBlankLayout = defaultMasterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (sourceBlankLayout == nullptr)
{
    sourceBlankLayout = defaultMasterSlide->get_LayoutSlide(0);
}

auto sectionBlankLayout = sectionMasterSlide->get_LayoutSlides()->AddClone(sourceBlankLayout);

presentation->get_Slides()->AddEmptySlide(sectionBlankLayout);
presentation->Save(u"presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Comparar slide masters**

Las diapositivas master pueden compararse con el método `Equals` heredado de [IBaseSlide](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibaseslide/). La comparación verifica la estructura y el contenido estático, como formas, texto, formato, animaciones y otros ajustes de diapositiva. No compara identificadores únicos, como IDs de diapositiva, ni valores dinámicos de marcadores de posición, como la fecha actual.

```cpp
auto firstPresentation = System::MakeObject<Presentation>(u"first.pptx");
auto secondPresentation = System::MakeObject<Presentation>(u"second.pptx");
auto firstPresentationMasterCount = firstPresentation->get_Masters()->get_Count();
auto secondPresentationMasterCount = secondPresentation->get_Masters()->get_Count();

for (int32_t firstMasterIndex = 0;
     firstMasterIndex < firstPresentationMasterCount;
     firstMasterIndex++)
{
    for (int32_t secondMasterIndex = 0;
         secondMasterIndex < secondPresentationMasterCount;
         secondMasterIndex++)
    {
        auto firstMasterSlide = firstPresentation->get_Master(firstMasterIndex);
        auto secondMasterSlide = secondPresentation->get_Master(secondMasterIndex);
        auto areMasterSlidesEqual = firstMasterSlide->Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            System::Console::WriteLine(
                System::String::Format(
                    u"first.pptx master #{0} equals second.pptx master #{1}",
                    firstMasterIndex,
                    secondMasterIndex));
        }
    }
}

secondPresentation->Dispose();
firstPresentation->Dispose();
```

Para más información, vea [Comparar diapositivas de presentación](/slides/es/cpp/compare-slides/).

## **Establecer la vista Slide Master como vista predeterminada**

Utilice el método `set_LastView` en [ViewProperties](https://reference.aspose.com/slides/es/cpp/aspose.slides/viewproperties/) para controlar la vista que PowerPoint abre primero. El siguiente ejemplo abre la presentación en la vista Slide Master:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"presentation-master-view.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Para más ajustes de vista, vea [Guardar presentación](/slides/es/cpp/save-presentation/).

## **Eliminar slide masters sin usar**

A veces las presentaciones contienen diapositivas master que ya no son usadas por ninguna diapositiva habitual. Eliminar masters sin usar puede reducir el tamaño del archivo y simplificar el mantenimiento de plantillas.

Utilice [MasterSlideCollection::RemoveUnused](https://reference.aspose.com/slides/es/cpp/aspose.slides/masterslidecollection/removeunused/) para eliminar los masters no usados de la colección `get_Masters()`:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_Masters()->RemoveUnused(true);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

También puede usar el método de bajo código [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/):

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(presentation);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre un slide master y una diapositiva de diseño?**

Un slide master define los ajustes de diseño compartidos como tema, fondo, formas comunes y estilos de texto. Una diapositiva de diseño pertenece a un slide master y define una disposición específica de marcadores de posición. Una diapositiva habitual usa una diapositiva de diseño, por lo que hereda tanto del diseño como del master.

**¿Puede una presentación contener varios slide masters?**

Sí. Una presentación puede contener varios slide masters. Use varios masters cuando diferentes secciones necesiten sistemas visuales o marcas distintas.

**¿Debo añadir marcadores de posición a una diapositiva master o a una diapositiva de diseño?**

En la mayoría de los casos, añada los marcadores de posición a las diapositivas de diseño. Coloque los elementos visuales y formatos compartidos en la diapositiva master y los marcadores de contenido en los diseños que usarán las diapositivas habituales.

**¿Puedo eliminar una diapositiva master que sigue en uso?**

No. Una diapositiva master que tiene diapositivas dependientes no puede eliminarse de forma segura directamente. Primero mueva esas diapositivas a diseños bajo otro master, o utilice un método de limpieza de masters no usados que elimine solo los masters que no están en uso.