---
title: Administrar encabezados y pies de página de la presentación en Android
linktitle: Encabezado y pie de página
type: docs
weight: 140
url: /es/androidjava/presentation-header-and-footer/
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
- Android
- Java
- Aspose.Slides
description: "Utilice Aspose.Slides for Android via Java para agregar y personalizar encabezados y pies de página en presentaciones de PowerPoint y OpenDocument, logrando un aspecto profesional."
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/es/androidjava/) ofrece soporte para trabajar con el texto de encabezados y pies de página de las diapositivas, que realmente se mantiene a nivel de maestro de diapositivas.

{{% /alert %}} 

[Aspose.Slides for Android via Java](/slides/es/androidjava/) proporciona la funcionalidad de gestionar encabezados y pies de página dentro de las diapositivas de la presentación. Estos se gestionan, de hecho, a nivel del maestro de presentación.

## **Administrar encabezados y pies de página en una presentación**
Las notas de alguna diapositiva específica pueden eliminarse como se muestra en el ejemplo a continuación:
```java
// Cargar presentación
Presentation pres = new Presentation("headerTest.pptx");
try {
    // Configurar pie de página
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);

    // Acceder y actualizar encabezado
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide)
    {
        updateHeaderFooterText(masterNotesSlide);
    }

    // Guardar presentación
    pres.save("HeaderFooterJava.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

```java
// Método para establecer el texto del encabezado/pie de página
public static void updateHeaderFooterText(IBaseSlide master)
{
    for (IShape shape : master.getShapes())
    {
        if (shape.getPlaceholder() != null)
        {
            if (shape.getPlaceholder().getType() == PlaceholderType.Header)
            {
                ((IAutoShape)shape).getTextFrame().setText("HI there new header");
            }
        }
    }
}
```


## **Administrar encabezados y pies de página en diapositivas de folletos y notas**
Aspose.Slides for Android via Java admite encabezado y pie de página en diapositivas de folletos y notas. Por favor, siga los pasos a continuación:

- Cargue una [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) que contenga un video.
- Cambie la configuración de Encabezado y Pie de página para el maestro de notas y todas las diapositivas de notas.
- Establezca visibles los marcadores de posición de Pie de página del maestro de notas y de todos los elementos secundarios.
- Establezca visibles los marcadores de posición de Fecha y hora del maestro de notas y de todos los elementos secundarios.
- Cambie la configuración de Encabezado y Pie de página solo para la primera diapositiva de notas.
- Establezca visible el marcador de posición de Encabezado de la diapositiva de notas.
- Asigne texto al marcador de posición de Encabezado de la diapositiva de notas.
- Asigne texto al marcador de posición de Fecha‑hora de la diapositiva de notas.
- Guarde el archivo de presentación modificado.

Fragmento de código proporcionado en el siguiente ejemplo.
```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // Cambiar la configuración de encabezado y pie de página para el maestro de notas y todas las diapositivas de notas
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // hacer visible la diapositiva maestra de notas y todos los marcadores de posición de pie de página secundarios
        headerFooterManager.setFooterAndChildFootersVisibility(true); // hacer visible la diapositiva maestra de notas y todos los marcadores de posición de encabezado secundarios
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // hacer visible la diapositiva maestra de notas y todos los marcadores de posición de número de diapositiva secundarios
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // hacer visible la diapositiva maestra de notas y todos los marcadores de posición de fecha y hora secundarios

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // establecer texto en la diapositiva maestra de notas y todos los marcadores de posición de encabezado secundarios
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // establecer texto en la diapositiva maestra de notas y todos los marcadores de posición de pie de página secundarios
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // establecer texto en la diapositiva maestra de notas y todos los marcadores de posición de fecha y hora secundarios
    }

    // Cambiar la configuración de encabezado y pie de página solo para la primera diapositiva de notas
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // hacer visible el marcador de posición de encabezado de esta diapositiva de notas

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // hacer visible el marcador de posición de pie de página de esta diapositiva de notas

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // hacer visible el marcador de posición de número de diapositiva de esta diapositiva de notas

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // hacer visible el marcador de posición de fecha y hora de esta diapositiva de notas

        headerFooterManager.setHeaderText("New header text"); // establecer texto en el marcador de posición de encabezado de la diapositiva de notas
        headerFooterManager.setFooterText("New footer text"); // establecer texto en el marcador de posición de pie de página de la diapositiva de notas
        headerFooterManager.setDateTimeText("New date and time text"); // establecer texto en el marcador de posición de fecha y hora de la diapositiva de notas
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Preguntas frecuentes**

**¿Puedo añadir un “encabezado” a diapositivas normales?**

En PowerPoint, el “Encabezado” solo existe para notas y folletos; en diapositivas normales, los elementos compatibles son el pie de página, la fecha/hora y el número de diapositiva. En Aspose.Slides esto coincide con las mismas limitaciones: encabezado solo para Notas/Folletos, y en diapositivas—Pie de página/FechaHora/NúmeroDeDiapositiva.

**¿Qué ocurre si el diseño no contiene un área de pie de página, puedo “activar” su visibilidad?**

Sí. Verifique la visibilidad mediante el administrador de encabezado/pie de página y habilítela si es necesario. Estos indicadores y métodos de la API están diseñados para casos en los que el marcador de posición falta o está oculto.

**¿Cómo hago que la numeración de diapositivas comience en un valor distinto de 1?**

Establezca el [número de primera diapositiva] (https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) de la presentación; a partir de ahí, toda la numeración se recalcula. Por ejemplo, puede comenzar en 0 o 10, y ocultar el número en la diapositiva de título.

**¿Qué sucede con los encabezados/pies de página al exportar a PDF/imagenes/HTML?**

Se renderizan como elementos de texto habituales de la presentación. Es decir, si los elementos son visibles en diapositivas/páginas de notas, también aparecerán en el formato de salida junto con el resto del contenido.