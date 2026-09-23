---
title: Recuperar y actualizar las propiedades de vista de la presentación en C++
linktitle: Propiedades de vista
type: docs
weight: 80
url: /es/cpp/presentation-view-properties/
keywords:
- propiedades de vista
- vista normal
- contenido del esquema
- iconos del esquema
- ajuste del divisor vertical
- vista única
- estado de barra
- tamaño de dimensión
- ajuste automático
- zoom predeterminado
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Descubra las propiedades de vista de Aspose.Slides para C++ para personalizar diapositivas en formatos PPT, PPTX y ODP: ajuste diseños, niveles de zoom y configuraciones de visualización."
---
## **Introducción**

La vista normal consta de tres regiones de contenido: la diapositiva propiamente dicha, una región de contenido lateral y una región de contenido inferior. Propiedades relacionadas con la posición de las diferentes regiones de contenido. Esta información permite a la aplicación guardar su estado de vista en el archivo, de modo que al volver a abrirlo la vista esté en el mismo estado que cuando la presentación se guardó por última vez.

Se ha añadido el método [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/es/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) para proporcionar acceso a las propiedades de vista normal de la presentación.

Se han añadido las interfaces [INormalViewProperties](https://reference.aspose.com/slides/es/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/es/cpp/aspose.slides/inormalviewrestoredproperties/) y sus descendientes, así como el enum [SplitterBarStateType](https://reference.aspose.com/slides/es/cpp/aspose.slides/splitterbarstatetype/).

## **Acerca de INormalViewProperties**

Representa las propiedades de vista normal.

La propiedad **ShowOutlineIcons** especifica si la aplicación debe mostrar iconos al visualizar el contenido del esquema en cualquiera de las regiones de contenido del modo de vista normal.

La propiedad **SnapVerticalSplitter** especifica si el divisor vertical debe ajustarse a un estado minimizado cuando la región lateral es lo suficientemente pequeña.

La propiedad **PreferSingleView** especifica si el usuario prefiere ver una sola región de contenido a pantalla completa en lugar de la vista normal estándar con tres regiones de contenido. Si está habilitada, la aplicación puede optar por mostrar una de las regiones de contenido en toda la ventana.

Las propiedades **VerticalBarState** y **HorizontalBarState** especifican el estado en el que debe mostrarse la barra divisor horizontal o vertical. Una barra divisor horizontal separa la diapositiva de la región de contenido situada bajo la diapositiva, mientras que la barra divisor vertical separa la diapositiva de la región de contenido lateral. Los valores posibles son: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** y **SplitterBarStateType.Restored.**

Las propiedades **RestoredLeft** y **RestoredTop** especifican el tamaño de la región superior o lateral de la diapositiva en la vista normal, cuando se aplica el valor **SplitterBarStateType.Restored** a **VerticalBarState** y **HorizontalBarState**, respectivamente.

## **Acerca de la restauración de INormalViewProperties**

Especifica el dimensionado de la región de la diapositiva (anchura cuando es un hijo de RestoredTop, altura cuando es un hijo de RestoredLeft) de la vista normal, cuando la región tiene un tamaño restaurado variable (ni minimizado ni maximizado).

La propiedad **DimensionSize** especifica el tamaño de la región de la diapositiva (anchura cuando es un hijo de restoredTop, altura cuando es un hijo de restoredLeft).

La propiedad **AutoAdjust** especifica si el tamaño de la región de contenido lateral debe compensar el nuevo tamaño al redimensionar la ventana que contiene la vista dentro de la aplicación.

A continuación se muestra un ejemplo de cómo puede acceder a las propiedades **ViewProperties.NormalViewProperties** de una presentación.

``` cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// Restaurar las propiedades de vista de la presentación
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Establecer el valor de zoom predeterminado**

Aspose.Slides para C++ ahora admite la configuración del valor de zoom predeterminado para una presentación, de modo que cuando la presentación se abre, el zoom ya está establecido. Esto puede hacerse configurando los [ViewProperties](https://reference.aspose.com/slides/es/cpp/aspose.slides/viewproperties/) de una presentación. Las propiedades de vista de diapositiva así como [get_NotesViewProperties](https://reference.aspose.com/slides/es/cpp/aspose.slides/viewproperties/get_notesviewproperties/) pueden establecerse programáticamente. En este tema, veremos con un ejemplo cómo establecer las propiedades de vista de una presentación en Aspose.Slides.

Para establecer las propiedades de vista, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/)
1. Establecer las View [Properties](https://reference.aspose.com/slides/es/cpp/aspose.slides/viewproperties/) de la presentación
1. Guardar la presentación como un archivo PPTX

``` cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Establecer las propiedades de vista de la presentación
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Valor de zoom en porcentaje para la vista de diapositiva
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Valor de zoom en porcentaje para la vista de notas 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **Establecer el espaciado de la cuadrícula**

Utilice [Presentation::get_ViewProperties](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_viewproperties/) para acceder a la configuración de vista a nivel de presentación. Los métodos [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/es/cpp/aspose.slides/iviewproperties/get_gridspacing/) y [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/es/cpp/aspose.slides/iviewproperties/set_gridspacing/) leen o modifican el intervalo de la cuadrícula de edición subyacente. Esta configuración se aplica a toda la presentación, no a una diapositiva individual. El espaciado de la cuadrícula se especifica en puntos, donde 72 puntos equivalen a una pulgada. Utilice un valor positivo, según lo requiera la documentación de la API.

El siguiente ejemplo abre un archivo `demo.pptx` existente, muestra su espaciado de cuadrícula actual, establece un intervalo de un cuarto de pulgada y guarda el resultado.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto gridSpacing = presentation->get_ViewProperties()->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

presentation->get_ViewProperties()->set_GridSpacing(18.0f);
presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

La cuadrícula es diferente de las [drawing guides](/slides/es/cpp/drawing-guides/). El espaciado de la cuadrícula controla un intervalo regular, mientras que las guías de dibujo son líneas de alineación horizontales o verticales posicionadas individualmente. Añadir, mover o eliminar guías de dibujo no cambia el espaciado de la cuadrícula.

Tanto la cuadrícula como las guías de dibujo son ayudas de edición. No se renderizan como contenido de diapositiva en PDF, imágenes, SVG o una presentación. Almacenar el espaciado de la cuadrícula no garantiza que un editor muestre la cuadrícula: su visibilidad también depende de las preferencias del visor o del editor.

## **Mostrar u ocultar comentarios al abrir una presentación**

Utilice [Presentation::get_ViewProperties](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_viewproperties/) para acceder a la configuración de vista a nivel de presentación. Utilice [IViewProperties::get_ShowComments](https://reference.aspose.com/slides/es/cpp/aspose.slides/iviewproperties/get_showcomments/) y [IViewProperties::set_ShowComments](https://reference.aspose.com/slides/es/cpp/aspose.slides/iviewproperties/set_showcomments/) para almacenar una preferencia sobre si los comentarios deben mostrarse cuando la presentación se abre en PowerPoint u otro editor compatible.

Esta configuración solo controla la preferencia de vista almacenada. No añade, elimina, edita ni resuelve comentarios. Ocultar comentarios preserva su contenido, autores, posiciones, respuestas y estados. Consulte [Presentation Comments](/slides/es/cpp/presentation-comments/) para operaciones que modifican los propios comentarios.

El siguiente ejemplo requiere un archivo `comments.pptx` existente que contenga comentarios. Muestra la configuración de visibilidad actual, solicita que los comentarios se oculten y guarda un nuevo PPTX sin eliminar ningún comentario. También utiliza [IViewProperties::set_LastView](https://reference.aspose.com/slides/es/cpp/aspose.slides/iviewproperties/set_lastview/) con [ViewType::SlideView](https://reference.aspose.com/slides/es/cpp/aspose.slides/viewtype/) para configurar la vista de edición inicial junto con la visibilidad de los comentarios.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <ViewType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"comments.pptx");
auto showComments = presentation->get_ViewProperties()->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

presentation->get_ViewProperties()->set_ShowComments(NullableBool::False);
presentation->get_ViewProperties()->set_LastView(ViewType::SlideView);
presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

Esta configuración no determina si los comentarios se incluyen en las exportaciones a PDF, HTML, imagen, notas o folletos. Configure por separado las opciones específicas de exportación correspondientes.

## **Preguntas frecuentes**

**¿Por qué la cuadrícula no es visible después de volver a abrir la presentación?**

El archivo almacena el espaciado de la cuadrícula, pero el editor controla si la cuadrícula se muestra. Verifique la configuración de visibilidad de la cuadrícula del editor.

**¿Eliminar las guías de dibujo cambia el espaciado de la cuadrícula?**

No. Las guías de dibujo y el espaciado de la cuadrícula son configuraciones independientes. Eliminar las guías deja el intervalo de la cuadrícula almacenado sin cambios.

**¿Puedo establecer diferentes configuraciones de vista para distintas secciones de una presentación?**

Las [view settings](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_viewproperties/) se definen a nivel de presentación ([Normal View](https://reference.aspose.com/slides/es/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/es/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), no por sección, por lo que un único conjunto de parámetros se aplica a todo el documento cuando se abre.

**¿Puedo predefinir diferentes estados de vista para distintos usuarios?**

No. Los ajustes se almacenan en el archivo y se comparten. Las aplicaciones visor pueden respetar las preferencias del usuario, pero el archivo en sí contiene un único conjunto de propiedades de vista.

**¿Puedo preparar una plantilla con View Properties predefinidos para que las nuevas presentaciones se abran de la misma manera?**

Sí. Debido a que los [view properties](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_viewproperties/) se almacenan a nivel de presentación, puede incorporarlos en una plantilla y crear documentos nuevos a partir de ella con la misma configuración de vista inicial.