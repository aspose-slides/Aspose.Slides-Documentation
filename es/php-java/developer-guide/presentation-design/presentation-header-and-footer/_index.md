---
title: Gestionar encabezados y pies de página de la presentación en PHP
linktitle: Encabezado y pie de página
type: docs
weight: 140
url: /es/php-java/presentation-header-and-footer/
keywords:
- encabezado
- texto del encabezado
- pie de página
- texto del pie de página
- establecer encabezado
- establecer pie de página
- folleto
- notas
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Aprenda cómo gestionar los marcadores de posición de pie de página, fecha y hora, número de diapositiva y encabezado en diapositivas, páginas de notas y folletos con Aspose.Slides para PHP a través de Java."
---
## **Visión general**

PowerPoint utiliza diferentes marcadores de posición de encabezado y pie de página según el tipo de página. Aspose.Slides para PHP a través de Java le permite controlar el texto y la visibilidad de estos marcadores mediante clases de gestión de encabezados/pies de página.

Los marcadores de posición disponibles dependen del ámbito:

| Ámbito | Encabezado | Pie de página | Fecha/hora | Número de diapositiva/página |
|---|---|---|---|---|
| Diapositiva normal | No | Sí | Sí | Sí |
| Máster de notas | Sí | Sí | Sí | Sí |
| Diapositiva de notas | Sí | Sí | Sí | Sí |
| Máster de folletos | Sí | Sí | Sí | Sí |

Una diapositiva normal de presentación no tiene un marcador de posición de encabezado. Los encabezados están disponibles en las páginas de notas y en los folletos. En diapositivas normales, utilice los marcadores de pie de página, fecha/hora y número de diapositiva.

El ámbito de un cambio depende del gestor que utilice. La clase [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/es/php-java/aspose.slides/slideheaderfootermanager/) controla una diapositiva normal. La clase [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/php-java/aspose.slides/notesslideheaderfootermanager/) controla una diapositiva de notas. Los gestores de máster y de diseño también pueden propagar la configuración a las diapositivas dependientes, mientras que la clase [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) controla el máster de folleto.

## **Establecer pie de página, fecha/hora y números de diapositiva en diapositivas normales**

Para diapositivas normales, el flujo de trabajo básico consiste en acceder al gestor de encabezado/pie de cada diapositiva, establecer el texto del pie de página y de la fecha/hora, habilitar los marcadores de posición requeridos y guardar la presentación. Los números de diapositiva los genera la presentación, por lo que solo necesita controlar su visibilidad.

Utilice [`setFooterText`](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseslideheaderfootermanager/setfootertext/) y [`setDateTimeText`](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) para establecer el texto, y use [`setFooterVisibility`](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/), [`setDateTimeVisibility`](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/) y [`setSlideNumberVisibility`](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) para mostrar los marcadores de posición correspondientes.

El siguiente ejemplo completo aplica el mismo pie de página, texto de fecha/hora y visibilidad del número de diapositiva a todas las diapositivas normales:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getSlides() as $slide) {
        $headerFooterManager = $slide->getHeaderFooterManager();

        $headerFooterManager->setFooterText("Company Confidential");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_slide_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Si necesita actualizar solo una diapositiva, acceda a esa diapositiva directamente mediante el método [`getSlides`](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/getslides/) en lugar de iterar por toda la colección.

## **Establecer encabezados y pies de página en el máster de notas**

El máster de notas define el formato común y el comportamiento de los marcadores de posición para las páginas de notas. Utilice la clase [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/php-java/aspose.slides/masternotesslideheaderfootermanager/) cuando desee modificar solo el propio máster de notas.

El siguiente ejemplo establece el encabezado, el pie de página y el texto de fecha/hora en el máster de notas y hace visibles todos los marcadores compatibles en ese máster:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Notes header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Notes footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El método [`getMasterNotesSlide`](https://reference.aspose.com/slides/es/php-java/aspose.slides/masternotesslidemanager/getmasternotesslide/) devuelve `null` cuando la presentación no contiene un máster de notas.

## **Aplicar la configuración del máster de notas a diapositivas de notas subordinadas**

Un máster de notas puede aplicar la configuración de encabezado y pie de página a sí mismo y a todas las diapositivas de notas dependientes. Use los métodos de propagación dedicados en [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/php-java/aspose.slides/masternotesslideheaderfootermanager/) cuando los mismos ajustes deban aplicarse a lo largo de la jerarquía de notas.

Por ejemplo, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/es/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) y [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/es/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) actualizan el encabezado del máster de notas y todos los encabezados subordinados. Existen métodos equivalentes para pies de página, fecha/hora y números de diapositiva.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderAndChildHeadersText("Notes header");
        $headerFooterManager->setHeaderAndChildHeadersVisibility(true);

        $headerFooterManager->setFooterAndChildFootersText("Notes footer");
        $headerFooterManager->setFooterAndChildFootersVisibility(true);

        $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");
        $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

        $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    $presentation->save("presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Los métodos de propagación usados anteriormente son [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/es/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/es/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/es/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/es/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/) y [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/es/php-java/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Establecer encabezados y pies de página en una diapositiva de notas individual**

Una diapositiva de notas pertenece a una diapositiva normal concreta. Utilice su clase [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/php-java/aspose.slides/notesslideheaderfootermanager/) cuando desee personalizar solo esa página de notas.

El método [`addNotesSlide`](https://reference.aspose.com/slides/es/php-java/aspose.slides/notesslidemanager/addnotesslide/) devuelve la diapositiva de notas para la diapositiva actual y crea una si aún no existe. El siguiente ejemplo configura la página de notas asociada a la primera diapositiva de la presentación:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $notesSlide = $slide->getNotesSlideManager()->addNotesSlide();
    $headerFooterManager = $notesSlide->getHeaderFooterManager();

    $headerFooterManager->setHeaderText("Header for the first notes page");
    $headerFooterManager->setHeaderVisibility(true);

    $headerFooterManager->setFooterText("Footer for the first notes page");
    $headerFooterManager->setFooterVisibility(true);

    $headerFooterManager->setDateTimeText("Date and time text");
    $headerFooterManager->setDateTimeVisibility(true);

    $headerFooterManager->setSlideNumberVisibility(true);

    $presentation->save("presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Si primero propaga la configuración desde el máster de notas y luego cambia una diapositiva de notas individual, los ajustes posteriores por diapositiva le permiten personalizar esa página de notas de forma independiente.

## **Establecer encabezados y pies de página en el máster de folleto**

Las páginas de folleto utilizan el máster de folleto para sus marcadores de posición de encabezado, pie de página, fecha/hora y número de página. A diferencia de las páginas de notas, la configuración de los folletos se gestiona mediante el máster de folleto y no a través de diapositivas de folleto individuales.

Utilice el método [`getMasterHandoutSlide`](https://reference.aspose.com/slides/es/php-java/aspose.slides/masterhandoutslidemanager/getmasterhandoutslide/) para acceder al máster de folleto. Si no está presente, llame a [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/es/php-java/aspose.slides/masterhandoutslidemanager/setdefaultmasterhandoutslide/) para crear el máster de folleto predeterminado.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();

    if (java_is_null($masterHandoutSlide)) {
        $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();
    }

    if (!java_is_null($masterHandoutSlide)) {
        $headerFooterManager = $masterHandoutSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Handout header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Handout footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_handout_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Entender el ámbito y la herencia**

Elija el gestor de encabezado/pie de página que coincida con el ámbito que desea modificar:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/es/php-java/aspose.slides/slideheaderfootermanager/) cambia la configuración de pie de página, fecha/hora y número de diapositiva para una diapositiva normal.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutslideheaderfootermanager/) controla una diapositiva de diseño y puede propagar los ajustes compatibles a las diapositivas dependientes.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/php-java/aspose.slides/masterslideheaderfootermanager/) controla un máster de diapositivas normal y puede propagar los ajustes compatibles a las diapositivas dependientes.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/php-java/aspose.slides/masternotesslideheaderfootermanager/) controla el máster de notas y puede propagar la configuración a todas las diapositivas de notas dependientes.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/php-java/aspose.slides/notesslideheaderfootermanager/) cambia una diapositiva de notas y admite un marcador de posición de encabezado además del pie de página, fecha/hora y número de diapositiva.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) cambia el máster de folleto y admite los cuatro tipos de marcadores de posición.

Use la propagación desde un máster o diseño cuando el mismo ajuste deba aplicarse a lo largo de su jerarquía. Use un gestor de diapositiva individual o de diapositiva de notas cuando necesite un ajuste local para una sola página.

## **FAQ**

**¿Puedo añadir un encabezado a una diapositiva normal?**

No. PowerPoint no define un marcador de posición de encabezado para diapositivas normales. En diapositivas normales, utilice los marcadores de pie de página, fecha/hora y número de diapositiva. Los marcadores de encabezado están disponibles en las páginas de notas y en los folletos.

**¿Qué ocurre si un marcador de pie de página, fecha/hora o número de diapositiva no es visible?**

Utilice el gestor de encabezado/pie de página correspondiente para comprobar su visibilidad y habilitarlo cuando sea necesario. Por ejemplo, [`isFooterVisible`](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseslideheaderfootermanager/isfootervisible/) indica si hay un marcador de pie de página presente, y [`setFooterVisibility`](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) cambia su visibilidad.

**¿Cómo inicio la numeración de diapositivas a partir de un valor distinto de 1?**

Llame al método [`setFirstSlideNumber`](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/setfirstslidenumber/) de la presentación. Los marcadores de número de diapositiva utilizan entonces la secuencia de numeración actualizada.

**¿Qué ocurre con los encabezados y pies de página al exportar a PDF, imágenes o HTML?**

Los elementos visibles de encabezado y pie de página se renderizan junto con el resto del contenido de la presentación en el formato de salida. Su apariencia depende del tipo de página que se exporta y de la configuración de visibilidad de los marcadores de posición correspondientes.