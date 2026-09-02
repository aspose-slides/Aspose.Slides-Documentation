---
title: Gestionar encabezados y pies de página de la presentación en JavaScript
linktitle: Encabezado y pie de página
type: docs
weight: 140
url: /es/nodejs-java/presentation-header-and-footer/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a gestionar los marcadores de posición de pie de página, fecha y hora, número de diapositiva y encabezado en diapositivas, páginas de notas y folletos con Aspose.Slides para Node.js mediante Java."
---
## **Visión general**

PowerPoint utiliza diferentes marcadores de posición de encabezado y pie de página según el tipo de página. Aspose.Slides para Node.js mediante Java le permite controlar el texto y la visibilidad de estos marcadores de posición a través de clases de gestión de encabezados/pies de página.

Los marcadores de posición disponibles dependen del ámbito:

| Ámbito | Encabezado | Pie de página | Fecha/hora | Número de diapositiva/página |
|---|---|---|---|---|
| Diapositiva normal | No | Sí | Sí | Sí |
| Maestro de notas | Sí | Sí | Sí | Sí |
| Diapositiva de notas | Sí | Sí | Sí | Sí |
| Maestro de folleto | Sí | Sí | Sí | Sí |

Una diapositiva normal no tiene un marcador de posición de encabezado. Los encabezados están disponibles en páginas de notas y folletos. En diapositivas normales, utilice los marcadores de posición de pie de página, fecha/hora y número de diapositiva.

El ámbito de un cambio depende del gestor que utilice. La clase[`SlideHeaderFooterManager`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slideheaderfootermanager/) controla una diapositiva normal. La clase[`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/notesslideheaderfootermanager/) controla una diapositiva de notas. Los gestores de maestro y de disposición también pueden propagar la configuración a diapositivas dependientes, mientras que la clase[`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) controla el maestro de folleto.

## **Establecer pie de página, fecha/hora y números de diapositiva en diapositivas normales**

Para diapositivas normales, el flujo de trabajo básico consiste en acceder al gestor de encabezado/pie de página de cada diapositiva, establecer el texto del pie de página y de la fecha/hora, habilitar los marcadores de posición necesarios y guardar la presentación. Los números de diapositiva los genera la presentación, por lo que solo necesita controlar su visibilidad.

Utilice[`setFooterText`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) y[`setDateTimeText`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) para establecer el texto, y utilice[`setFooterVisibility`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility),[`setDateTimeVisibility`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility) y[`setSlideNumberVisibility`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) para mostrar los marcadores de posición correspondientes.

El siguiente ejemplo completo aplica el mismo pie de página, texto de fecha/hora y visibilidad del número de diapositiva a todas las diapositivas normales:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Si necesita actualizar solo una diapositiva, acceda a esa diapositiva directamente mediante el método[`getSlides`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/getslides/) en lugar de iterar toda la colección.

## **Establecer encabezados y pies de página en el maestro de notas**

El maestro de notas define el formato común y el comportamiento de los marcadores de posición para las páginas de notas. Utilice la clase[`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) cuando solo quiera cambiar el propio maestro de notas.

El siguiente ejemplo establece el encabezado, el pie de página y el texto de fecha/hora en el maestro de notas y hace visibles todos los marcadores de posición compatibles en ese maestro:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El método[`getMasterNotesSlide`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/masternotesslidemanager/#getMasterNotesSlide) devuelve `null` cuando la presentación no contiene un maestro de notas.

## **Aplicar configuraciones del maestro de notas a diapositivas de notas secundarias**

Un maestro de notas puede aplicar la configuración de encabezado y pie de página a sí mismo y a todas las diapositivas de notas dependientes. Utilice los métodos de propagación dedicados en[`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) cuando la misma configuración deba aplicarse en toda la jerarquía de notas.

Por ejemplo,[`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) y[`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) actualizan el encabezado del maestro de notas y todos los encabezados secundarios. Existen métodos equivalentes para pies de página, fecha/hora y números de diapositiva.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Los métodos de propagación usados arriba son[`setFooterAndChildFootersText`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText),[`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility),[`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText),[`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility) y[`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility).

## **Establecer encabezados y pies de página en una diapositiva de notas individual**

Una diapositiva de notas pertenece a una diapositiva normal concreta. Utilice su clase[`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/notesslideheaderfootermanager/) cuando desee personalizar solo esa página de notas.

El método[`addNotesSlide`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/notesslidemanager/#addNotesSlide) devuelve la diapositiva de notas para la diapositiva actual y crea una si no existe. El siguiente ejemplo configura la página de notas asociada a la primera diapositiva de la presentación:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const headerFooterManager = slide.getNotesSlideManager().addNotesSlide().getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Si primero propaga la configuración desde el maestro de notas y luego cambia una diapositiva de notas individual, la configuración posterior por diapositiva le permite personalizar esa página de notas de forma independiente.

## **Establecer encabezados y pies de página en el maestro de folleto**

Las páginas de folleto utilizan el maestro de folleto para sus marcadores de posición de encabezado, pie de página, fecha/hora y número de página. A diferencia de las páginas de notas, la configuración de los folletos se gestiona a través del maestro de folleto y no mediante diapositivas de folleto individuales.

Utilice[`getMasterHandoutSlide`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/masterhandoutslidemanager/#getMasterHandoutSlide) para acceder al maestro de folleto. Si no está presente, llame a[`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/masterhandoutslidemanager/#setDefaultMasterHandoutSlide) para crear el maestro de folleto predeterminado.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    let masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide === null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide !== null) {
        const headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Entender el ámbito y la herencia**

Elija el gestor de encabezado/pie de página que coincida con el ámbito que desea modificar:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slideheaderfootermanager/) cambia la configuración de pie de página, fecha/hora y número de diapositiva para una diapositiva normal.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/layoutslideheaderfootermanager/) controla una diapositiva de disposición y puede propagar la configuración compatible a diapositivas dependientes.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/masterslideheaderfootermanager/) controla un maestro de diapositivas normal y puede propagar la configuración compatible a diapositivas dependientes.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) controla el maestro de notas y puede propagar la configuración a todas las diapositivas de notas dependientes.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/notesslideheaderfootermanager/) cambia una diapositiva de notas y admite un marcador de posición de encabezado además de pie de página, fecha/hora y número de diapositiva.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) cambia el maestro de folleto y admite los cuatro tipos de marcadores de posición.

Utilice la propagación desde un maestro o disposición cuando la misma configuración deba aplicarse a toda su jerarquía. Utilice un gestor de diapositiva individual o de diapositiva de notas cuando necesite una configuración local para una sola página.

## **Preguntas frecuentes**

**¿Puedo añadir un encabezado a una diapositiva normal?**

No. PowerPoint no define un marcador de posición de encabezado para diapositivas normales. En diapositivas normales, utilice los marcadores de posición de pie de página, fecha/hora y número de diapositiva. Los marcadores de posición de encabezado están disponibles en páginas de notas y folletos.

**¿Qué ocurre si un marcador de posición de pie de página, fecha/hora o número de diapositiva no es visible?**

Utilice el gestor de encabezado/pie de página correspondiente para comprobar su visibilidad y habilitarlo cuando sea necesario. Por ejemplo,[`isFooterVisible`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) indica si existe un marcador de posición de pie de página, y[`setFooterVisibility`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) cambia su visibilidad.

**¿Cómo comienzo la numeración de diapositivas a partir de un valor distinto de 1?**

Llame al método[`setFirstSlideNumber`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) de la presentación. Los marcadores de posición de número de diapositiva utilizarán entonces la secuencia de numeración actualizada.

**¿Qué sucede con los encabezados y pies de página al exportar a PDF, imágenes o HTML?**

Los elementos visibles de encabezado y pie de página se renderizan con el resto del contenido de la presentación en el formato de salida. Su apariencia depende del tipo de página que se exporta y de la configuración de visibilidad de los marcadores de posición correspondientes.