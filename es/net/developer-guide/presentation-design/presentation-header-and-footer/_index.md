---
title: Administrar encabezados y pies de página de presentaciones en .NET
linktitle: Encabezado y pie de página
type: docs
weight: 140
url: /es/net/presentation-header-and-footer/
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
- .NET
- C#
- Aspose.Slides
description: "Aprenda cómo gestionar los marcadores de posición de pie de página, fecha y hora, número de diapositiva y encabezado en diapositivas, páginas de notas y folletos con Aspose.Slides para .NET."
---
## **Visión general**

PowerPoint utiliza diferentes marcadores de posición de encabezado y pie de página según el tipo de página. Aspose.Slides for .NET le permite controlar el texto y la visibilidad de estos marcadores de posición mediante interfaces de administrador de encabezado/pie de página.

Los marcadores de posición disponibles dependen del ámbito:

| Ámbito | Encabezado | Pie de página | Fecha/hora | Número de diapositiva/página |
|---|---|---|---|---|
| Diapositiva regular | No | Sí | Sí | Sí |
| Patrón de notas | Sí | Sí | Sí | Sí |
| Diapositiva de notas | Sí | Sí | Sí | Sí |
| Patrón de folletos | Sí | Sí | Sí | Sí |

Una diapositiva de presentación regular no tiene un marcador de posición de encabezado. Los encabezados están disponibles en las páginas de notas y en los folletos. Para diapositivas regulares, utilice los marcadores de posición de pie de página, fecha/hora y número de diapositiva.

El ámbito de un cambio depende del administrador que utilice. La interfaz [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/es/net/aspose.slides/islideheaderfootermanager/) controla una única diapositiva regular. La interfaz [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/net/aspose.slides/inotesslideheaderfootermanager/) controla una única diapositiva de notas. Los administradores de patrón y de diseño también pueden propagar la configuración a diapositivas dependientes, mientras que la interfaz [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/net/aspose.slides/imasterhandoutslideheaderfootermanager/) controla el patrón de folletos.

## **Establecer pie de página, fecha/hora y números de diapositiva en diapositivas regulares**

Para diapositivas regulares, el flujo de trabajo básico consiste en acceder al administrador de encabezado/pie de página de cada diapositiva, establecer el texto del pie de página y de la fecha/hora, habilitar los marcadores de posición requeridos y guardar la presentación. Los números de diapositiva los genera la presentación, por lo que solo necesita controlar su visibilidad.

Utilice [`SetFooterText`](https://reference.aspose.com/slides/es/net/aspose.slides/baseslideheaderfootermanager/setfootertext/) y [`SetDateTimeText`](https://reference.aspose.com/slides/es/net/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) para establecer el texto, y use [`SetFooterVisibility`](https://reference.aspose.com/slides/es/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/), [`SetDateTimeVisibility`](https://reference.aspose.com/slides/es/net/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/) y [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/es/net/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) para mostrar los marcadores de posición correspondientes.

El siguiente ejemplo completo aplica el mismo pie de página, texto de fecha/hora y visibilidad del número de diapositiva a todas las diapositivas regulares:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    var headerFooterManager = slide.HeaderFooterManager;

    headerFooterManager.SetFooterText("Company Confidential");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
```

Si necesita actualizar solo una diapositiva, acceda a esa diapositiva directamente a través de la colección [`Slides`](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/slides/es/) en lugar de iterar por toda la colección.

## **Establecer encabezados y pies de página en el patrón de notas**

El patrón de notas define el formato común y el comportamiento de los marcadores de posición para las páginas de notas. Utilice la interfaz [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/net/aspose.slides/imasternotesslideheaderfootermanager/) cuando desee modificar solo el propio patrón de notas.

El siguiente ejemplo establece el encabezado, pie de página y texto de fecha/hora en el patrón de notas y hace visibles todos los marcadores de posición admitidos en ese patrón:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Notes header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Notes footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
```

La propiedad [`MasterNotesSlide`](https://reference.aspose.com/slides/es/net/aspose.slides/imasternotesslidemanager/masternotesslide/) devuelve `null` cuando la presentación no contiene un patrón de notas.

## **Aplicar la configuración del patrón de notas a diapositivas de notas hijas**

Un patrón de notas puede aplicar la configuración de encabezado y pie de página a sí mismo y a todas las diapositivas de notas dependientes. Utilice los métodos de propagación dedicados en [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/net/aspose.slides/imasternotesslideheaderfootermanager/) cuando la misma configuración deba aplicarse a lo largo de la jerarquía de notas.

Por ejemplo, [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/es/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) y [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/es/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) actualizan el encabezado del patrón de notas y todos los encabezados hijos. Existen métodos equivalentes para pies de página, fecha/hora y números de diapositiva.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderAndChildHeadersText("Notes header");
    headerFooterManager.SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Notes footer");
    headerFooterManager.SetFooterAndChildFootersVisibility(true);

    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation.Save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
```

Los métodos de propagación utilizados arriba son [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/es/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/es/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/es/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/es/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/) y [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/es/net/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Establecer encabezados y pies de página en una diapositiva de notas individual**

Una diapositiva de notas pertenece a una diapositiva regular concreta. Utilice su interfaz [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/net/aspose.slides/inotesslideheaderfootermanager/) cuando desee personalizar solo esa página de notas.

El método [`AddNotesSlide`](https://reference.aspose.com/slides/es/net/aspose.slides/inotesslidemanager/addnotesslide/) devuelve la diapositiva de notas para la diapositiva actual y crea una si aún no existe. El siguiente ejemplo configura la página de notas asociada a la primera diapositiva de la presentación:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var notesSlide = presentation.Slides[0].NotesSlideManager.AddNotesSlide();
var headerFooterManager = notesSlide.HeaderFooterManager;

headerFooterManager.SetHeaderText("Header for the first notes page");
headerFooterManager.SetHeaderVisibility(true);

headerFooterManager.SetFooterText("Footer for the first notes page");
headerFooterManager.SetFooterVisibility(true);

headerFooterManager.SetDateTimeText("Date and time text");
headerFooterManager.SetDateTimeVisibility(true);

headerFooterManager.SetSlideNumberVisibility(true);

presentation.Save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
```

Si primero propaga la configuración desde el patrón de notas y luego modifica una diapositiva de notas individual, la configuración posterior por diapositiva le permite personalizar esa página de notas de forma independiente.

## **Establecer encabezados y pies de página en el patrón de folletos**

Las páginas de folletos utilizan el patrón de folletos para sus marcadores de posición de encabezado, pie de página, fecha/hora y número de página. A diferencia de las páginas de notas, la configuración de los folletos se gestiona a través del patrón de folletos y no mediante diapositivas de folleto individuales.

Utilice la propiedad [`MasterHandoutSlide`](https://reference.aspose.com/slides/es/net/aspose.slides/imasterhandoutslidemanager/masterhandoutslide/) para acceder al patrón de folletos. Si no está presente, llame a [`SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/es/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) para crear el patrón de folletos predeterminado.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;

if (masterHandoutSlide == null)
{
    presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();
    masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
}

if (masterHandoutSlide != null)
{
    var headerFooterManager = masterHandoutSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Handout header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Handout footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
```

## **Comprender el ámbito y la herencia**

Elija el administrador de encabezado/pie de página que coincida con el ámbito que desea modificar:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/es/net/aspose.slides/islideheaderfootermanager/) cambia la configuración de pie de página, fecha/hora y número de diapositiva para una sola diapositiva regular.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/net/aspose.slides/ilayoutslideheaderfootermanager/) controla una diapositiva de diseño y puede propagar la configuración admitida a las diapositivas dependientes.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/net/aspose.slides/imasterslideheaderfootermanager/) controla un patrón de diapositiva regular y puede propagar la configuración admitida a las diapositivas dependientes.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/net/aspose.slides/imasternotesslideheaderfootermanager/) controla el patrón de notas y puede propagar la configuración a todas las diapositivas de notas dependientes.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/net/aspose.slides/inotesslideheaderfootermanager/) cambia una diapositiva de notas y admite un marcador de posición de encabezado además de pie de página, fecha/hora y número de diapositiva.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/net/aspose.slides/imasterhandoutslideheaderfootermanager/) cambia el patrón de folletos y admite los cuatro tipos de marcadores de posición.

Utilice la propagación desde un patrón o un diseño cuando la misma configuración deba aplicarse a lo largo de su jerarquía. Utilice un administrador de diapositiva individual o de diapositiva de notas cuando necesite una configuración local para una sola página.

## **Preguntas frecuentes**

**¿Puedo añadir un encabezado a una diapositiva regular?**

No. PowerPoint no define un marcador de posición de encabezado para diapositivas regulares. En diapositivas regulares, utilice los marcadores de posición de pie de página, fecha/hora y número de diapositiva. Los marcadores de posición de encabezado están disponibles en las páginas de notas y en los folletos.

**¿Qué ocurre si un marcador de posición de pie de página, fecha/hora o número de diapositiva no es visible?**

Utilice el administrador de encabezado/pie de página correspondiente para comprobar su visibilidad y habilitarlo cuando sea necesario. Por ejemplo, [`IsFooterVisible`](https://reference.aspose.com/slides/es/net/aspose.slides/baseslideheaderfootermanager/isfootervisible/) indica si existe un marcador de posición de pie de página, y [`SetFooterVisibility`](https://reference.aspose.com/slides/es/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) modifica su visibilidad.

**¿Cómo comienzo la numeración de diapositivas a partir de un valor distinto de 1?**

Establezca la propiedad [`FirstSlideNumber`](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/firstslidenumber/) de la presentación. Los marcadores de posición de número de diapositiva usarán entonces la secuencia de numeración actualizada.

**¿Qué ocurre con los encabezados y pies de página al exportar a PDF, imágenes o HTML?**

Los elementos visibles de encabezado y pie de página se renderizan junto con el resto del contenido de la presentación en el formato de salida. Su apariencia depende del tipo de página que se exporta y de la configuración de visibilidad de los marcadores de posición correspondientes.