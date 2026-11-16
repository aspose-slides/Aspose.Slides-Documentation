---
title: Recuperar y actualizar propiedades de vista de la presentación en C++
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
description: "Utilice Aspose.Slides para C++ para configurar la disposición de la vista normal, el zoom de diapositivas y notas, el espaciado de la cuadrícula y la visibilidad de los comentarios en presentaciones de PowerPoint."
---
## **Introducción**

En la vista normal de PowerPoint, la diapositiva aparece entre un panel lateral para miniaturas o un esquema y un panel de notas debajo. Aspose.Slides para C++ expone las preferencias de edición guardadas de la presentación a través de [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/). Estas incluyen la disposición de los paneles, los niveles de zoom, el espaciado de la cuadrícula y la visibilidad de los comentarios.

## **Acerca de INormalViewProperties**

Utilice [get_NormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) para acceder a la interfaz [INormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/). [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) controla si aparecen iconos junto a los títulos de las diapositivas en el esquema. [set_SnapVerticalSplitter](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_snapverticalsplitter/) permite que el panel lateral se ajuste a su estado minimizado cuando el usuario lo reduce. [set_PreferSingleView](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_prefersingleview/) indica una preferencia por mostrar un solo panel en la ventana completa.

[set_VerticalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_verticalbarstate/) controla el divisor entre el panel lateral y la diapositiva. [set_HorizontalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_horizontalbarstate/) controla el divisor sobre el panel de notas. Ambos aceptan un valor [SplitterBarStateType](https://reference.aspose.com/slides/cpp/aspose.slides/splitterbarstatetype/) de `Minimized`, `Maximized` o `Restored`.

## **Acerca de restaurar INormalViewProperties**

Cuando se restaura un divisor, [get_RestoredLeft](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredleft/) proporciona el tamaño guardado del panel lateral y [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) proporciona el tamaño guardado del área superior de la diapositiva. Ambos exponen [INormalViewRestoredProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/). Su método [set_DimensionSize](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_dimensionsize/) acepta un porcentaje de 0 a 100, y [set_AutoAdjust](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_autoadjust/) controla si el editor ajusta el tamaño al redimensionar la ventana.

Este ejemplo actualiza una presentación existente. Restaura el divisor horizontal, establece el tamaño del área superior de la diapositiva expuesta por [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) al 80% con el ajuste automático habilitado, y maximiza el divisor vertical. También habilita los iconos del esquema con [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) para la vista de esquema.

```cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto normalView = presentation->get_ViewProperties()->get_NormalViewProperties();
normalView->set_HorizontalBarState(SplitterBarStateType::Restored);
normalView->set_VerticalBarState(SplitterBarStateType::Maximized);
auto restoredTop = normalView->get_RestoredTop();
restoredTop->set_AutoAdjust(true);
restoredTop->set_DimensionSize(80.0f);
normalView->set_ShowOutlineIcons(true);

presentation->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Establecer el valor de zoom predeterminado**

[get_SlideViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_slideviewproperties/) y [get_NotesViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_notesviewproperties/) almacenan configuraciones de zoom independientes para el editor. Estas configuraciones no afectan las dimensiones de la diapositiva, la reproducción de la presentación o la resolución de la exportación de imágenes.

Este ejemplo abre una presentación existente y habilita el escalado automático con [set_VariableScale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_variablescale/) para adaptar la diapositiva a la ventana de edición. Para la página de notas, deshabilita el escalado automático y utiliza [set_Scale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_scale/) para establecer un zoom fijo del 80%.

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
viewProperties->get_SlideViewProperties()->set_VariableScale(true);
auto notesView = viewProperties->get_NotesViewProperties();
notesView->set_VariableScale(false);
notesView->set_Scale(80);

presentation->Save(u"zoom.pptx", SaveFormat::Pptx);
```

## **Establecer el espaciado de la cuadrícula**

[set_GridSpacing](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_gridspacing/) establece la distancia entre las líneas de la cuadrícula de edición en toda la presentación. Recibe un valor positivo en puntos, con 72 puntos por pulgada. Este ejemplo muestra el espaciado actual en una presentación existente y guarda una cuadrícula de un cuarto de pulgada estableciendo el intervalo a 18 puntos.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
auto gridSpacing = viewProperties->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

viewProperties->set_GridSpacing(18.0f);

presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

La cuadrícula se repite a intervalos fijos. [Guías de dibujo](/slides/es/cpp/drawing-guides/) marcan posiciones horizontales o verticales individuales. Ambas son herramientas de edición y solo aparecen en editores que las muestran. Las presentaciones y las exportaciones a PDF, imágenes o SVG las omiten.

## **Mostrar u ocultar comentarios al abrir una presentación**

[set_ShowComments](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_showcomments/) almacena una preferencia que los editores compatibles usan al abrir la presentación. Para una presentación existente con comentarios, este ejemplo muestra la configuración actual y guarda una copia con los comentarios ocultos. También llama a [set_LastView](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_lastview/) con [ViewType::SlideView](https://reference.aspose.com/slides/cpp/aspose.slides/viewtype/) para que la copia se abra en vista de diapositiva.

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

auto viewProperties = presentation->get_ViewProperties();
auto showComments = viewProperties->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

viewProperties->set_ShowComments(NullableBool::False);
viewProperties->set_LastView(ViewType::SlideView);

presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

Ocultar los comentarios preserva su texto, autores, posiciones, respuestas y estados. Para modificar los propios comentarios, consulte [Comentarios de la presentación](/slides/es/cpp/presentation-comments/). La configuración de exportación controla si los comentarios aparecen en PDF, HTML, imágenes, notas o folletos.

## **Preguntas frecuentes**

**¿Por qué la cuadrícula está oculta cuando vuelvo a abrir la presentación?**

La presentación guarda el intervalo de la cuadrícula. Para ver la cuadrícula, habilite la visibilidad de la cuadrícula en el editor.

**¿Eliminar las guías de dibujo cambia el espaciado de la cuadrícula?**

No. Añadir, mover o eliminar una guía deja el intervalo de la cuadrícula sin cambios.

**¿Pueden diferentes secciones de una presentación tener configuraciones de vista diferentes?**

No. [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) se aplica a toda la presentación.

**¿Puedo guardar diferentes configuraciones de vista para distintos usuarios?**

El archivo almacena un único conjunto de propiedades de vista para todos. Un editor también puede aplicar las preferencias locales del usuario.

**¿Puedo guardar configuraciones de vista en una plantilla?**

Sí. Las presentaciones creadas a partir de la plantilla heredan sus configuraciones de vista guardadas.