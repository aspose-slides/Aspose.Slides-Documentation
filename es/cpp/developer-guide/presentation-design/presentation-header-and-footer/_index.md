---
title: Gestionar encabezados y pies de página de la presentación en C++
linktitle: Encabezado y pie de página
type: docs
weight: 140
url: /es/cpp/presentation-header-and-footer/
keywords:
- encabezado
- texto de encabezado
- pie de página
- texto de pie de página
- establecer encabezado
- establecer pie de página
- folleto
- notas
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Aprenda a gestionar los marcadores de posición de pie de página, fecha y hora, número de diapositiva y encabezado en diapositivas, páginas de notas y folletos con Aspose.Slides para C++."
---
## **Descripción general**

PowerPoint utiliza diferentes marcadores de posición de encabezado y pie de página según el tipo de página. Aspose.Slides para C++ le permite controlar el texto y la visibilidad de estos marcadores de posición mediante interfaces de gestión de encabezados/pies de página.

Los marcadores de posición disponibles dependen del ámbito:

| Alcance | Encabezado | Pie de página | Fecha/hora | Número de diapositiva/página |
|---|---|---|---|---|
| Diapositiva normal | No | Sí | Sí | Sí |
| Maestro de notas | Sí | Sí | Sí | Sí |
| Diapositiva de notas | Sí | Sí | Sí | Sí |
| Maestro de folletos | Sí | Sí | Sí | Sí |

Una diapositiva normal de una presentación no tiene un marcador de posición de encabezado. Los encabezados están disponibles en las páginas de notas y en los folletos. Para las diapositivas normales, use los marcadores de posición de pie de página, fecha/hora y número de diapositiva.

El alcance de un cambio depende del gestor que utilice. La interfaz [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/es/cpp/aspose.slides/islideheaderfootermanager/) controla una diapositiva normal. La interfaz [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/cpp/aspose.slides/inotesslideheaderfootermanager/) controla una diapositiva de notas. Los gestores de maestro y de diseño también pueden propagar la configuración a diapositivas dependientes, mientras que la interfaz [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) controla el maestro de folletos.

## **Establecer pie de página, fecha/hora y números de diapositiva en diapositivas normales**

Para diapositivas normales, el flujo de trabajo básico consiste en acceder al gestor de encabezado/pie de página de cada diapositiva, establecer el texto del pie de página y de fecha/hora, habilitar los marcadores de posición necesarios y guardar la presentación. Los números de diapositiva son generados por la presentación, por lo que solo necesita controlar su visibilidad.

Utilice [`SetFooterText`](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootertext/) y [`SetDateTimeText`](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimetext/) para establecer el texto, y utilice [`SetFooterVisibility`](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/), [`SetDateTimeVisibility`](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimevisibility/) y [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibaseslideheaderfootermanager/setslidenumbervisibility/) para mostrar los marcadores de posición correspondientes.

El siguiente ejemplo completo aplica el mismo pie de página, texto de fecha/hora y visibilidad del número de diapositiva a todas las diapositivas normales:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (const auto& slide : System::IterateOver(presentation->get_Slides()))
{
    auto headerFooterManager = slide->get_HeaderFooterManager();

    headerFooterManager->SetFooterText(u"Company Confidential");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_slide_footers.pptx", SaveFormat::Pptx);
```

Si necesita actualizar solo una diapositiva, acceda a esa diapositiva directamente mediante [`Presentation::get_Slide`](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_slide/) en lugar de iterar por toda la colección de diapositivas.

## **Establecer encabezados y pies de página en el maestro de notas**

El maestro de notas define el formato común y el comportamiento de los marcadores de posición para las páginas de notas. Utilice la interfaz [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasternotesslideheaderfootermanager/) cuando desee cambiar solo el propio maestro de notas.

El siguiente ejemplo establece el encabezado, pie de página y texto de fecha/hora en el maestro de notas y hace visibles todos los marcadores de posición compatibles en ese maestro:

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Notes header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Notes footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
```

El método [`IMasterNotesSlideManager::get_MasterNotesSlide`](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasternotesslidemanager/get_masternotesslide/) devuelve `nullptr` cuando la presentación no contiene un maestro de notas.

## **Aplicar la configuración del maestro de notas a diapositivas de notas hijas**

Un maestro de notas puede aplicar la configuración de encabezado y pie de página a sí mismo y a todas las diapositivas de notas dependientes. Use los métodos de propagación dedicados en [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasternotesslideheaderfootermanager/) cuando la misma configuración deba aplicarse en toda la jerarquía de notas.

Por ejemplo, [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheaderstext/) y [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) actualizan el encabezado del maestro de notas y todos los encabezados hijos. Existen métodos equivalentes para pies de página, fecha/hora y números de diapositiva.

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderAndChildHeadersText(u"Notes header");
    headerFooterManager->SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager->SetFooterAndChildFootersText(u"Notes footer");
    headerFooterManager->SetFooterAndChildFootersVisibility(true);

    headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
    headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation->Save(u"presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
```

Los métodos de propagación utilizados arriba son [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/) y [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Establecer encabezados y pies de página en una diapositiva de notas individual**

Una diapositiva de notas pertenece a una diapositiva normal específica. Utilice su interfaz [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/cpp/aspose.slides/inotesslideheaderfootermanager/) cuando desee personalizar solo esa página de notas.

El método [`INotesSlideManager::AddNotesSlide`](https://reference.aspose.com/slides/es/cpp/aspose.slides/inotesslidemanager/addnotesslide/) devuelve la diapositiva de notas para la diapositiva actual y crea una si aún no existe. El siguiente ejemplo configura la página de notas asociada a la primera diapositiva de la presentación:

```cpp
#include <DOM/INotesSlide.h>
#include <DOM/INotesSlideHeaderFooterManager.h>
#include <DOM/INotesSlideManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);
auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();
auto headerFooterManager = notesSlide->get_HeaderFooterManager();

headerFooterManager->SetHeaderText(u"Header for the first notes page");
headerFooterManager->SetHeaderVisibility(true);

headerFooterManager->SetFooterText(u"Footer for the first notes page");
headerFooterManager->SetFooterVisibility(true);

headerFooterManager->SetDateTimeText(u"Date and time text");
headerFooterManager->SetDateTimeVisibility(true);

headerFooterManager->SetSlideNumberVisibility(true);

presentation->Save(u"presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
```

Si primero propaga la configuración desde el maestro de notas y luego modifica una diapositiva de notas individual, la configuración posterior por diapositiva le permite personalizar esa página de notas de forma independiente.

## **Establecer encabezados y pies de página en el maestro de folletos**

Las páginas de folletos utilizan el maestro de folletos para sus marcadores de posición de encabezado, pie de página, fecha/hora y número de página. A diferencia de las páginas de notas, la configuración de los folletos se gestiona a través del maestro de folletos y no mediante diapositivas de folletos individuales.

Utilice [`IMasterHandoutSlideManager::get_MasterHandoutSlide`](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterhandoutslidemanager/get_masterhandoutslide/) para acceder al maestro de folletos. Si no está presente, llame a [`IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) para crear el maestro de folletos predeterminado.

```cpp
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideHeaderFooterManager.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterHandoutSlideManager = presentation->get_MasterHandoutSlideManager();
auto masterHandoutSlide = masterHandoutSlideManager->get_MasterHandoutSlide();

if (masterHandoutSlide == nullptr)
{
    masterHandoutSlide = masterHandoutSlideManager->SetDefaultMasterHandoutSlide();
}

if (masterHandoutSlide != nullptr)
{
    auto headerFooterManager = masterHandoutSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Handout header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Handout footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_handout_footers.pptx", SaveFormat::Pptx);
```

## **Entender el alcance y la herencia**

Elija el gestor de encabezado/pie de página que coincida con el alcance que desea modificar:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/es/cpp/aspose.slides/islideheaderfootermanager/) cambia la configuración de pie de página, fecha/hora y número de diapositiva para una diapositiva normal.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutslideheaderfootermanager/) controla una diapositiva de diseño y puede propagar la configuración compatible a diapositivas dependientes.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterslideheaderfootermanager/) controla un maestro de diapositivas normal y puede propagar la configuración compatible a diapositivas dependientes.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasternotesslideheaderfootermanager/) controla el maestro de notas y puede propagar la configuración a todas las diapositivas de notas dependientes.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/cpp/aspose.slides/inotesslideheaderfootermanager/) cambia una diapositiva de notas y admite un marcador de posición de encabezado además del pie de página, fecha/hora y número de diapositiva.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) cambia el maestro de folletos y admite los cuatro tipos de marcadores de posición.

Utilice la propagación desde un maestro o diseño cuando la misma configuración deba aplicarse a toda su jerarquía. Utilice un gestor de diapositiva individual o de diapositiva de notas cuando necesite una configuración local para una sola página.

## **FAQ**

**¿Puedo añadir un encabezado a una diapositiva normal?**

No. PowerPoint no define un marcador de posición de encabezado para las diapositivas normales. En las diapositivas normales, use los marcadores de posición de pie de página, fecha/hora y número de diapositiva. Los marcadores de posición de encabezado están disponibles en las páginas de notas y en los folletos.

**¿Qué ocurre si un marcador de posición de pie de página, fecha/hora o número de diapositiva no es visible?**

Utilice el gestor de encabezado/pie de página correspondiente para comprobar su visibilidad y habilitarlo cuando sea necesario. Por ejemplo, [`get_IsFooterVisible`](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibaseslideheaderfootermanager/get_isfootervisible/) indica si hay un marcador de posición de pie de página, y [`SetFooterVisibility`](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/) modifica su visibilidad.

**¿Cómo comienzo la numeración de diapositivas a partir de un valor distinto de 1?**

Utilice [`Presentation::set_FirstSlideNumber`](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/set_firstslidenumber/) para establecer el número de la primera diapositiva. Los marcadores de posición de número de diapositiva usarán entonces la secuencia de numeración actualizada.

**¿Qué ocurre con los encabezados y pies de página al exportar a PDF, imágenes o HTML?**

Los elementos visibles de encabezado y pie de página se renderizan junto con el resto del contenido de la presentación en el formato de salida. Su apariencia depende del tipo de página que se exporta y de la configuración de visibilidad de los marcadores de posición correspondientes.