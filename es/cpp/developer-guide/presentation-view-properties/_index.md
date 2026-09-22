---
title: Recuperar y actualizar las propiedades de vista de la presentación en C++
linktitle: Propiedades de vista
type: docs
weight: 80
url: /es/cpp/presentation-view-properties/
keywords:
- propiedades de vista
- vista normal
- contenido de esquema
- iconos de esquema
- ajustar divisor vertical
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
description: "Descubra las propiedades de vista de Aspose.Slides para C++ para personalizar formatos PPT, PPTX y ODP: ajuste diseños, niveles de zoom y configuraciones de visualización."
---
## **Introducción**

La vista normal consta de tres regiones de contenido: la diapositiva en sí, una región de contenido lateral y una región de contenido inferior. Las propiedades se refieren a la posición de las diferentes regiones de contenido. Esta información permite a la aplicación guardar su estado de vista en el archivo, de modo que al volver a abrirlo la vista esté en el mismo estado que cuando la presentación se guardó por última vez.

Se ha añadido el método [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/es/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) para proporcionar acceso a las propiedades de vista normal de la presentación.  

Se han añadido las interfaces [INormalViewProperties](https://reference.aspose.com/slides/es/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/es/cpp/aspose.slides/inormalviewrestoredproperties/) y sus descendientes, así como el enumerado [SplitterBarStateType](https://reference.aspose.com/slides/es/cpp/aspose.slides/splitterbarstatetype/).

## **Acerca de INormalViewProperties**

Representa las propiedades de vista normal.

La propiedad **ShowOutlineIcons** especifica si la aplicación debe mostrar íconos al visualizar contenido de esquema en cualquiera de las regiones de contenido del modo de vista normal.

La propiedad **SnapVerticalSplitter** especifica si el divisor vertical debe ajustarse a un estado minimizado cuando la región lateral es lo suficientemente pequeña.

La propiedad **PreferSingleView** especifica si el usuario prefiere ver una única región de contenido en pantalla completa en lugar de la vista normal estándar con tres regiones de contenido. Si está activada, la aplicación puede elegir mostrar una de las regiones de contenido en toda la ventana.

Las propiedades **VerticalBarState** y **HorizontalBarState** especifican el estado en que debe mostrarse la barra divisoria horizontal o vertical. Una barra divisoria horizontal separa la diapositiva de la región de contenido situada bajo la diapositiva, y una barra divisoria vertical separa la diapositiva de la región de contenido lateral. Los valores posibles son: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** y **SplitterBarStateType.Restored.**

Las propiedades **RestoredLeft** y **RestoredTop** especifican el tamaño de la región superior o lateral de la diapositiva en la vista normal, cuando se aplica el valor **SplitterBarStateType.Restored** a **VerticalBarState** y **HorizontalBarState**, respectivamente.

## **Acerca de restaurar INormalViewProperties**

Especifica el tamaño de la región de la diapositiva (ancho cuando es hijo de RestoredTop, alto cuando es hijo de RestoredLeft) en la vista normal, cuando la región tiene un tamaño restaurado variable (ni minimizado ni maximizado).

La propiedad **DimensionSize** especifica el tamaño de la región de la diapositiva (ancho cuando es hijo de RestoredTop, alto cuando es hijo de RestoredLeft).

La propiedad **AutoAdjust** especifica si el tamaño de la región de contenido lateral debe compensar el nuevo tamaño al redimensionar la ventana que contiene la vista dentro de la aplicación.

A continuación se muestra un ejemplo que explica cómo acceder a las propiedades **ViewProperties.NormalViewProperties** de una presentación.

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

Aspose.Slides para C++ ahora permite establecer el valor de zoom predeterminado para una presentación, de modo que cuando se abre la presentación, el zoom ya está configurado. Esto se puede lograr estableciendo las [ViewProperties](https://reference.aspose.com/slides/es/cpp/aspose.slides/viewproperties/) de una presentación. Las propiedades de vista de diapositiva, así como [get_NotesViewProperties](https://reference.aspose.com/slides/es/cpp/aspose.slides/viewproperties/get_notesviewproperties/) pueden configurarse programáticamente. En este tema, veremos con un ejemplo cómo establecer las Propiedades de Vista de una Presentación en Aspose.Slides.

Para establecer las propiedades de vista, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
2. Establezca la Vista [Properties](https://reference.aspose.com/slides/es/cpp/aspose.slides/viewproperties/) de la presentación.
3. Guarde la presentación como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos establecido el valor de zoom tanto para la vista de diapositiva como para la vista de notas.

``` cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Estableciendo las propiedades de vista de la presentación
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Valor de zoom en porcentaje para la vista de diapositiva
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Valor de zoom en porcentaje para la vista de notas 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **Establecer el espaciado de la cuadrícula**

Utilice [Presentation::get_ViewProperties](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_viewproperties/) para acceder a la configuración de vista a nivel de presentación. Los métodos [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/es/cpp/aspose.slides/iviewproperties/get_gridspacing/) y [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/es/cpp/aspose.slides/iviewproperties/set_gridspacing/) leen o modifican el intervalo de la cuadrícula de edición subyacente. Esta configuración se aplica a toda la presentación, no a una diapositiva individual. El espaciado de la cuadrícula se especifica en puntos, donde 72 puntos equivalen a una pulgada. Utilice un valor positivo, según lo requiera la documentación de la API.

El siguiente ejemplo abre un `demo.pptx` existente, muestra su espaciado de cuadrícula actual, establece un intervalo de un cuarto de pulgada y guarda el resultado.

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

Tanto la cuadrícula como las guías de dibujo son ayudas de edición. No se renderizan como contenido de diapositiva en PDF, imágenes, SVG o una presentación. Guardar el espaciado de la cuadrícula no garantiza que un editor lo muestre: su visibilidad también depende de las preferencias del visor o del editor.

## **FAQ**

**¿Por qué la cuadrícula no es visible después de volver a abrir la presentación?**

El archivo guarda el espaciado de la cuadrícula, pero el editor controla si la cuadrícula se muestra. Verifique la configuración de visibilidad de la cuadrícula del editor.

**¿Eliminar las guías de dibujo cambia el espaciado de la cuadrícula?**

No. Las guías de dibujo y el espaciado de la cuadrícula son configuraciones independientes. Eliminar las guías deja el intervalo de la cuadrícula almacenado sin cambios.

**¿Puedo establecer diferentes configuraciones de vista para distintas secciones de una presentación?**

Las [view settings](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_viewproperties/) se definen a nivel de presentación ([Normal View](https://reference.aspose.com/slides/es/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/es/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), no por sección, por lo que un único conjunto de parámetros se aplica a todo el documento cuando se abre.

**¿Puedo predefinir diferentes estados de vista para diferentes usuarios?**

No. Las configuraciones se almacenan en el archivo y se comparten. Las aplicaciones visor pueden respetar las preferencias del usuario, pero el propio archivo contiene un único conjunto de propiedades de vista.

**¿Puedo crear una plantilla con View Properties predefinidas para que las nuevas presentaciones se abran de la misma manera?**

Sí. Debido a que las [view properties](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_viewproperties/) se almacenan a nivel de presentación, puede incrustarlas en una plantilla y crear nuevos documentos a partir de ella con la misma configuración de vista inicial.