---
title: Gestionar encabezados y pies de página de presentaciones en Java
linktitle: Encabezado y pie de página
type: docs
weight: 140
url: /es/java/presentation-header-and-footer/
keywords:
- encabezado
- texto de encabezado
- pie de página
- texto de pie de página
- establecer encabezado
- establecer pie de página
- hoja de distribución
- notas
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Aprenda a gestionar los marcadores de posición de pie de página, fecha y hora, número de diapositiva y encabezado en diapositivas, páginas de notas y hojas de distribución con Aspose.Slides para Java."
---
## **Visión general**

PowerPoint utiliza diferentes marcadores de posición de encabezado y pie de página según el tipo de página. Aspose.Slides for Java permite controlar el texto y la visibilidad de estos marcadores mediante las interfaces de gestión de encabezado/pie de página.

Los marcadores de posición disponibles dependen del ámbito:

| Ámbito | Encabezado | Pie de página | Fecha/hora | Número de diapositiva/página |
|---|---|---|---|---|
| Diapositiva normal | No | Sí | Sí | Sí |
| Patrón de notas | Sí | Sí | Sí | Sí |
| Diapositiva de notas | Sí | Sí | Sí | Sí |
| Patrón de hoja de distribución | Sí | Sí | Sí | Sí |

Una diapositiva normal de la presentación no tiene un marcador de posición de encabezado. Los encabezados están disponibles en páginas de notas y hojas de distribución. En diapositivas normales, utilice los marcadores de pie de página, fecha/hora y número de diapositiva.

El ámbito de un cambio depende del gestor que utilice. La interfaz [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/es/java/com.aspose.slides/islideheaderfootermanager/) controla una diapositiva normal. La interfaz [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/java/com.aspose.slides/inotesslideheaderfootermanager/) controla una diapositiva de notas. Los gestores de patrón y diseño también pueden propagar la configuración a las diapositivas dependientes, mientras que la interfaz [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/) controla el patrón de hoja de distribución.

## **Establecer pie de página, fecha/hora y número de diapositiva en diapositivas normales**

Para diapositivas normales, el flujo de trabajo básico consiste en acceder al gestor de encabezado/pie de página de cada diapositiva, establecer el texto del pie de página y de fecha/hora, activar los marcadores de posición requeridos y guardar la presentación. Los números de diapositiva los genera la presentación, por lo que sólo es necesario controlar su visibilidad.

Utilice [`setFooterText`](https://reference.aspose.com/slides/es/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-) y [`setDateTimeText`](https://reference.aspose.com/slides/es/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeText-java.lang.String-) para fijar el texto, y emplee [`setFooterVisibility`](https://reference.aspose.com/slides/es/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-), [`setDateTimeVisibility`](https://reference.aspose.com/slides/es/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility-boolean-), y [`setSlideNumberVisibility`](https://reference.aspose.com/slides/es/java/com.aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility-boolean-) para mostrar los marcadores de posición correspondientes.

El siguiente ejemplo completo aplica el mismo pie de página, texto de fecha/hora y visibilidad del número de diapositiva a todas las diapositivas normales:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideHeaderFooterManager headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Si necesita actualizar sólo una diapositiva, acceda a esa diapositiva directamente mediante el método [`getSlides`](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#getSlides--) en lugar de iterar sobre toda la colección.

## **Establecer encabezados y pies de página en el patrón de notas**

El patrón de notas define el formato común y el comportamiento de los marcadores de posición para las páginas de notas. Utilice la interfaz [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/java/com.aspose.slides/imasternotesslideheaderfootermanager/) cuando quiera modificar sólo el propio patrón de notas.

El siguiente ejemplo establece el encabezado, el pie de página y el texto de fecha/hora en el patrón de notas y hace visibles todos los marcadores de posición admitidos en ese patrón:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El método [`getMasterNotesSlide`](https://reference.aspose.com/slides/es/java/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--) devuelve `null` cuando la presentación no contiene un patrón de notas.

## **Aplicar la configuración del patrón de notas a las diapositivas de notas secundarias**

Un patrón de notas puede aplicar la configuración de encabezado y pie de página a sí mismo y a todas las diapositivas de notas dependientes. Utilice los métodos de propagación dedicados en [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/java/com.aspose.slides/imasternotesslideheaderfootermanager/) cuando los mismos ajustes deban aplicarse a lo largo de la jerarquía de notas.

Por ejemplo, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/es/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersText-java.lang.String-) y [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/es/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility-boolean-) actualizan el encabezado del patrón de notas y todos los encabezados secundarios. Existen métodos equivalentes para pies de página, fecha/hora y números de diapositiva.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Los métodos de propagación utilizados arriba son [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/es/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersText-java.lang.String-), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/es/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility-boolean-), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/es/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText-java.lang.String-), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/es/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility-boolean-), y [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/es/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-).

## **Establecer encabezados y pies de página en una diapositiva de notas individual**

Una diapositiva de notas pertenece a una diapositiva normal concreta. Utilice su interfaz [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/java/com.aspose.slides/inotesslideheaderfootermanager/) cuando quiera personalizar sólo esa página de notas.

El método [`addNotesSlide`](https://reference.aspose.com/slides/es/java/com.aspose.slides/inotesslidemanager/#addNotesSlide--) devuelve la diapositiva de notas para la diapositiva actual y crea una si aún no existe. El siguiente ejemplo configura la página de notas asociada a la primera diapositiva de la presentación:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();
    INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Si primero propaga la configuración desde el patrón de notas y luego modifica una diapositiva de notas individual, los ajustes posteriores por diapositiva le permiten personalizar esa página de notas de forma independiente.

## **Establecer encabezados y pies de página en el patrón de hoja de distribución**

Las páginas de hoja de distribución usan el patrón de hoja de distribución para sus marcadores de encabezado, pie de página, fecha/hora y número de página. A diferencia de las páginas de notas, la configuración de las hojas de distribución se gestiona a través del patrón de hoja de distribución y no mediante diapositivas de hoja de distribución individuales.

Utilice el método [`getMasterHandoutSlide`](https://reference.aspose.com/slides/es/java/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--) para acceder al patrón de hoja de distribución. Si no está presente, llame a [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/es/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) para crear el patrón de hoja de distribución predeterminado.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterHandoutSlide masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide == null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide != null) {
        IMasterHandoutSlideHeaderFooterManager headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Entender el ámbito y la herencia**

Elija el gestor de encabezado/pie de página que coincida con el ámbito que desea modificar:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/es/java/com.aspose.slides/islideheaderfootermanager/) cambia la configuración de pie de página, fecha/hora y número de diapositiva para una diapositiva normal.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/java/com.aspose.slides/ilayoutslideheaderfootermanager/) controla una diapositiva de diseño y puede propagar los ajustes compatibles a las diapositivas dependientes.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/java/com.aspose.slides/imasterslideheaderfootermanager/) controla un patrón de diapositiva normal y puede propagar los ajustes compatibles a las diapositivas dependientes.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/java/com.aspose.slides/imasternotesslideheaderfootermanager/) controla el patrón de notas y puede propagar la configuración a todas las diapositivas de notas dependientes.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/java/com.aspose.slides/inotesslideheaderfootermanager/) cambia una diapositiva de notas y admite un marcador de encabezado además del pie de página, fecha/hora y número de diapositiva.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/) cambia el patrón de hoja de distribución y admite los cuatro tipos de marcadores.

Utilice la propagación desde un patrón o diseño cuando el mismo ajuste deba aplicarse en toda su jerarquía. Utilice un gestor de diapositiva individual o de diapositiva de notas cuando necesite un ajuste local para una sola página.

## **Preguntas frecuentes**

**¿Puedo añadir un encabezado a una diapositiva normal?**

No. PowerPoint no define un marcador de posición de encabezado para diapositivas normales. En diapositivas normales, use los marcadores de pie de página, fecha/hora y número de diapositiva. Los marcadores de encabezado están disponibles en páginas de notas y hojas de distribución.

**¿Qué ocurre si un marcador de pie de página, fecha/hora o número de diapositiva no es visible?**

Utilice el gestor de encabezado/pie de página correspondiente para comprobar su visibilidad y habilitarlo cuando sea necesario. Por ejemplo, [`isFooterVisible`](https://reference.aspose.com/slides/es/java/com.aspose.slides/baseslideheaderfootermanager/#isFooterVisible--) indica si existe un marcador de pie de página, y [`setFooterVisibility`](https://reference.aspose.com/slides/es/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-) cambia su visibilidad.

**¿Cómo puedo iniciar la numeración de diapositivas a partir de un valor distinto de 1?**

Llame al método [`setFirstSlideNumber`](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) de la presentación. Los marcadores de número de diapositiva usarán entonces la secuencia de numeración actualizada.

**¿Qué ocurre con los encabezados y pies de página al exportar a PDF, imágenes o HTML?**

Los elementos visibles de encabezado y pie de página se renderizan junto con el resto del contenido de la presentación en el formato de salida. Su apariencia depende del tipo de página que se exporta y de la configuración de visibilidad de los marcadores correspondientes.