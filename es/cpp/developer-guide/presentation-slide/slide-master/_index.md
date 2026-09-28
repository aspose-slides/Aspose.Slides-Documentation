---
title: Gestionar diapositivas maestras de presentación en C++
linktitle: Diapositiva maestra
type: docs
weight: 80
url: /es/cpp/slide-master/
keywords:
- diapositiva maestra
- diapositiva maestra
- diapositiva maestra PPT
- múltiples diapositivas maestras
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
description: "Gestiona diapositivas maestras en Aspose.Slides para C++: accede, edita, clona, compara y elimina diapositivas maestras en presentaciones PowerPoint y OpenDocument."
---
## **Descripción general**

Un **slide master** define configuraciones de diseño compartidas para un grupo de diapositivas. Puede contener formas comunes, logotipos, fondos, estilos de texto, configuraciones de tema y configuraciones de pie de página. En PowerPoint, editar un slide master es la forma habitual de mantener una presentación coherente sin repetir el mismo formato en cada diapositiva.

Aspose.Slides para C++ admite el mismo modelo. Una presentación puede contener una o más diapositivas maestras, y cada diapositiva maestra puede contener varias diapositivas de diseño. Las diapositivas normales normalmente no se refieren directamente a una diapositiva maestra. En su lugar, una diapositiva normal utiliza una diapositiva de diseño, y esa diapositiva de diseño pertenece a una diapositiva maestra.

La jerarquía es:

1. **Slide master** – define el diseño y el tema compartidos.  
2. **Layout slide** – define una disposición específica de marcadores de posición y formato a nivel de diseño.  
3. **Normal slide** – contiene el contenido real de la presentación y utiliza una diapositiva de diseño.  

![La jerarquía de diapositivas maestras, diapositivas de diseño y diapositivas normales](slide-master_2.jpg)

En Aspose.Slides, una diapositiva maestra está representada por la interfaz [IMasterSlide](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterslide/). Todas las diapositivas maestras de una presentación están disponibles a través de la colección [Presentation::get_Masters](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_masters/), que implementa [IMasterSlideCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Cuando la misma propiedad está definida en más de un nivel, el nivel más específico gana. Por ejemplo, si una diapositiva maestra y una diapositiva de diseño definen ambas un fondo, las diapositivas basadas en ese diseño utilizan el fondo del diseño. Para obtener más información sobre las diapositivas de diseño, consulte [Apply or Change Slide Layouts](/slides/es/cpp/slide-layout/).
{{% /alert %}}

## **Acceder a diapositivas maestras**

En PowerPoint, puede abrir la vista de diapositiva maestra desde **Vista** > **Slide Master**.

![El comando Slide Master en la pestaña Vista de PowerPoint](slide-master_3.jpg)

En Aspose.Slides, use la colección `get_Masters()` para acceder a las diapositivas maestras:

```cpp
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstMasterSlide = presentation->get_Master(0);
auto masterSlideCount = presentation->get_Masters()->get_Count();
auto firstMasterLayoutSlideCount = firstMasterSlide->get_LayoutSlides()->get_Count();

System::Console::WriteLine(System::String(u"Master slides: ") + masterSlideCount);
System::Console::WriteLine(System::String(u"Layouts in the first master: ") + firstMasterLayoutSlideCount);

presentation->Dispose();
```

También puede obtener la diapositiva maestra utilizada por una diapositiva normal a través de su diseño:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slide = presentation->get_Slide(0);
auto layoutSlide = slide->get_LayoutSlide();
auto masterSlide = layoutSlide->get_MasterSlide();
auto masterSlideName = masterSlide->get_Name();

System::Console::WriteLine(masterSlideName);

presentation->Dispose();
```

## **Qué contiene una diapositiva maestra**

Una diapositiva maestra es un objeto similar a una diapositiva. Implementa [IBaseSlide](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibaseslide/), por lo que expone muchas de las mismas propiedades de diapositiva que se usan en diapositivas normales y de diseño. Los miembros específicos de la maestra se enumeran en la página de API [IMasterSlide](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterslide/).

Los miembros de diapositiva maestra más usados incluyen:

| Miembro | Propósito |
| --- | --- |
| `get_Background()` | Establece el fondo de la diapositiva a nivel de maestra. |
| `get_Shapes()` | Almacena las formas colocadas en la maestra, como logotipos, marcos de imágenes y texto compartido. |
| `get_LayoutSlides()` | Almacena las diapositivas de diseño que pertenecen a la maestra. |
| `get_ThemeManager()` | Proporciona acceso a las API del tema de la maestra. |
| `get_HeaderFooterManager()` | Controla encabezados, pies de página, fechas y números de diapositiva para la maestra y sus diseños secundarios. |
| `GetDependingSlides()` | Devuelve las diapositivas normales que dependen de la maestra a través de sus diseños. |

## **Agregar una imagen a una diapositiva maestra**

Cuando agrega una imagen a una diapositiva maestra, aparece en las diapositivas que usan diseños de esa maestra. Esto es útil para logotipos, marcas de agua, bandas decorativas y otros elementos visuales repetidos.

El siguiente ejemplo agrega un logotipo a la primera diapositiva maestra:

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

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

Para obtener más información sobre marcos de imagen, consulte [Picture Frame](/slides/es/cpp/picture-frame/).

## **Controlar la visibilidad de los gráficos de la maestra**

Utilice [IBaseSlide::set_ShowMasterShapes](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibaseslide/set_showmastershapes/) para ocultar los gráficos heredados de la maestra, como logotipos o formas decorativas, sin borrarlos de la maestra. Pase `false` a [Slide::set_ShowMasterShapes](https://reference.aspose.com/slides/es/cpp/aspose.slides/slide/set_showmastershapes/) en la diapositiva que debe omitir esos gráficos y `true` en las diapositivas que deben mostrarlos.

El siguiente ejemplo autocontenido crea una banda decorativa azul en una maestra y dos diapositivas que usan el mismo diseño en blanco. La banda es visible en la primera diapositiva y está oculta en la segunda. No se requiere una presentación o imagen de entrada.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFormat.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);
auto layoutSlide = masterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
layoutSlide->set_ShowMasterShapes(true);

auto slideHeight = presentation->get_SlideSize()->get_Size().get_Height();
auto band = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0.0f, 0.0f, 60.0f, slideHeight);
band->get_FillFormat()->set_FillType(FillType::Solid);
band->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());
band->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

auto visibleSlide = presentation->get_Slide(0);
visibleSlide->set_LayoutSlide(layoutSlide);
visibleSlide->get_Shapes()->Clear();

auto hiddenSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);

visibleSlide->set_ShowMasterShapes(true);
hiddenSlide->set_ShowMasterShapes(false);

presentation->Save(u"master-graphics.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

El ejemplo usa el diseño **Blank** suministrado con una nueva presentación y elimina los marcadores de posición propios de la diapositiva inicial.

### **Elegir el alcance de la configuración**

Una diapositiva normal utiliza su maestra a través de [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/es/cpp/aspose.slides/islide/get_layoutslide/) y [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutslide/get_masterslide/). Configurar la propiedad en una diapositiva individual afecta solo a esa diapositiva. Pasar `false` a [LayoutSlide::set_ShowMasterShapes](https://reference.aspose.com/slides/es/cpp/aspose.slides/layoutslide/set_showmastershapes/) oculta los gráficos de la maestra para las diapositivas que usan ese diseño compartido, aunque su propia configuración sea `true`. Para ocultar gráficos en una sola diapositiva, cambie la propiedad de la diapositiva y deje el diseño compartido sin cambios.

La configuración no se admite como control de visibilidad en la propia diapositiva maestra. En una maestra siempre devuelve `false`, y asignar `true` genera `System::NotSupportedException`. Aplíquela a una diapositiva normal o a un diseño en su lugar.

### **Distinguir los gráficos del fondo**

| Operación | Efecto |
| --- | --- |
| Ocultar los gráficos de la maestra | Controla la visibilidad de las formas heredadas de la maestra sin eliminarlas ni cambiar las propias formas de la diapositiva. |
| Cambiar el relleno del fondo de la diapositiva | Cambia el color, degradado o imagen del fondo. Los gráficos de la maestra son formas separadas y pueden seguir visibles sobre ese fondo. Consulte [Presentation Background](/slides/es/cpp/presentation-background/). |
| Eliminar una forma de la maestra | Elimina la forma fuente compartida, de modo que ya no esté disponible para ninguna diapositiva que use esa maestra. |

## **Trabajar con marcadores de posición**

Los marcadores de posición normalmente se definen en las diapositivas de diseño. La diapositiva maestra proporciona el estilo y tema compartidos que esas diapositivas heredan, mientras que cada diseño decide qué marcadores de posición están disponibles y dónde se colocan.

En PowerPoint, los comandos de marcador de posición están disponibles en la vista de Slide Master.

![El comando Insertar marcador de posición en la vista Slide Master de PowerPoint](slide-master_5.png)

Para agregar nuevos marcadores de posición con Aspose.Slides, trabaje con la diapositiva de diseño que pertenece a la maestra:

```cpp
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

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

También puede formatear las formas de marcador de posición que ya existen en una diapositiva maestra. El siguiente ejemplo encuentra el marcador de posición de título y aplica un relleno de degradado lineal:

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShapeCollection.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

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

![Marcador de posición de título formateado heredado por diapositivas normales](slide-master_8.png)

Para obtener más opciones de marcadores de posición y formato de texto, consulte [Set Prompt Text in Placeholder](/slides/es/cpp/manage-placeholder/) y [Text Formatting](/slides/es/cpp/text-formatting/).

## **Cambiar el fondo de una diapositiva maestra**

Un fondo de maestra se hereda en los diseños y diapositivas que no lo sobrescriben. El siguiente ejemplo establece un color de fondo sólido para la primera diapositiva maestra:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto masterBackgroundColor = System::Drawing::Color::get_ForestGreen();

masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(masterBackgroundColor);

presentation->Save(u"presentation-master-background.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Para temas relacionados, consulte [Presentation Background](/slides/es/cpp/presentation-background/) y [Presentation Theme](/slides/es/cpp/presentation-theme/).

## **Clonar una diapositiva maestra a otra presentación**

Utilice [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterslidecollection/addclone/) para copiar una diapositiva maestra a otra presentación. La maestra copiada puede entonces ser usada por diseños y diapositivas en la presentación de destino.

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto sourcePresentation = System::MakeObject<Presentation>(u"source.pptx");
auto destinationPresentation = System::MakeObject<Presentation>(u"destination.pptx");

auto sourceMasterSlide = sourcePresentation->get_Master(0);
auto clonedMasterSlide = destinationPresentation->get_Masters()->AddClone(sourceMasterSlide);

destinationPresentation->Save(u"destination-with-master.pptx", SaveFormat::Pptx);
destinationPresentation->Dispose();
sourcePresentation->Dispose();
```

Si necesita clonar diapositivas normales junto con su maestra, consulte [Clone Slides](/slides/es/cpp/clone-slides/).

## **Agregar varias diapositivas maestras**

Una presentación puede contener varias diapositivas maestras. Esto es útil cuando diferentes secciones requieren diferentes marcas, estructuras de página o configuraciones de tema.

![Comandos de PowerPoint para insertar y gestionar diapositivas maestras](slide-master_9.jpg)

El siguiente ejemplo clona la maestra predeterminada, le da al clon un fondo diferente, crea un diseño bajo esa maestra clonada y agrega una nueva diapositiva basada en ese diseño:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

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

## **Comparar diapositivas maestras**

Las diapositivas maestras pueden compararse con el método `Equals` heredado de [IBaseSlide](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibaseslide/). La comparación verifica la estructura y el contenido estático, como formas, texto, formato, animaciones y otras configuraciones de diapositiva. No compara identificadores únicos, como IDs de diapositiva, ni valores dinámicos de marcadores de posición, como la fecha actual.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

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

Para obtener más información, consulte [Compare Presentation Slides](/slides/es/cpp/compare-slides/).

## **Establecer la vista de diapositiva maestra como vista predeterminada**

Utilice el método `set_LastView` en [ViewProperties](https://reference.aspose.com/slides/es/cpp/aspose.slides/viewproperties/) para controlar la vista que PowerPoint abre primero. El siguiente ejemplo abre la presentación en la vista Slide Master:

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"presentation-master-view.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Para más configuraciones de vista, consulte [Save Presentation](/slides/es/cpp/save-presentation/).

## **Eliminar diapositivas maestras no usadas**

A veces las presentaciones contienen diapositivas maestras que ya no son usadas por ninguna diapositiva normal. Eliminar maestras no usadas puede reducir el tamaño del archivo y simplificar el mantenimiento de la plantilla.

Utilice [MasterSlideCollection::RemoveUnused](https://reference.aspose.com/slides/es/cpp/aspose.slides/masterslidecollection/removeunused/) para eliminar maestras no usadas de la colección `get_Masters()`:

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_Masters()->RemoveUnused(true);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

También puede usar el método de bajo código [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/):

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(presentation);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre una diapositiva maestra y una diapositiva de diseño?**

Una diapositiva maestra define configuraciones de diseño compartidas, como tema, fondo, formas comunes y estilos de texto. Una diapositiva de diseño pertenece a una diapositiva maestra y define una disposición específica de marcadores de posición. Una diapositiva normal utiliza una diapositiva de diseño, por lo que hereda tanto del diseño como de la maestra.

**¿Puede una presentación contener varias diapositivas maestras?**

Sí. Una presentación puede contener varias diapositivas maestras. Use varias maestras cuando distintas secciones necesiten diferentes sistemas visuales o marcas.

**¿Debería agregar marcadores de posición a una diapositiva maestra o a una diapositiva de diseño?**

En la mayoría de los casos, agregue los marcadores de posición a las diapositivas de diseño. Coloque los elementos visuales compartidos y el formato compartido en la diapositiva maestra, y luego coloque los marcadores de posición de contenido en los diseños que usarán las diapositivas normales.

**¿Puedo eliminar una diapositiva maestra que todavía se está usando?**

No. Una diapositiva maestra que tiene diapositivas dependientes no puede eliminarse de forma segura directamente. Primero mueva esas diapositivas a diseños bajo otra maestra, o utilice un método de limpieza de maestras no usadas que elimine solo las maestras que no están en uso.