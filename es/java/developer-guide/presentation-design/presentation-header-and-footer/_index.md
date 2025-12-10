---
title: Administrar encabezados y pies de página de presentaciones en Java
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
- folleto
- notas
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Use Aspose.Slides for Java para agregar y personalizar encabezados y pies de página en presentaciones de PowerPoint y OpenDocument para un aspecto profesional."
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/es/java/) proporciona soporte para trabajar con los encabezados y pies de página de las diapositivas cuyo texto se mantiene en el nivel del maestro de diapositivas.

{{% /alert %}} 

[Aspose.Slides for Java](/slides/es/java/) proporciona la función para gestionar encabezados y pies de página dentro de las diapositivas de la presentación. Estos se gestionan de hecho a nivel del maestro de la presentación.

## **Administrar encabezados y pies de página en una presentación**
Las notas de una diapositiva específica pueden eliminarse como se muestra en el ejemplo a continuación:
```java
// Cargar presentación
Presentation pres = new Presentation("headerTest.pptx");
try {
    // Establecer pie de página
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
// Método para establecer texto de encabezado/pie de página
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


## **Administrar encabezados y pies de página en diapositivas de folleto y notas**
Aspose.Slides for Java admite encabezados y pies de página en diapositivas de folleto y notas. Siga los pasos a continuación:

- Cargue una [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) que contenga un video.
- Cambie la configuración de encabezado y pie de página para el maestro de notas y todas las diapositivas de notas.
- Establezca la diapositiva maestra de notas y todos los marcadores de posición de pie de página secundarios como visibles.
- Establezca la diapositiva maestra de notas y todos los marcadores de posición de fecha y hora secundarios como visibles.
- Cambie la configuración de encabezado y pie de página solo para la primera diapositiva de notas.
- Establezca el marcador de posición de encabezado de la diapositiva de notas como visible.
- Establezca el texto del marcador de posición de encabezado de la diapositiva de notas.
- Establezca el texto del marcador de posición de fecha y hora de la diapositiva de notas.
- Escriba el archivo de presentación modificado.

Fragmento de código proporcionado en el ejemplo a continuación.
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
            headerFooterManager.setHeaderVisibility(true); // hacer visible este marcador de posición de encabezado en la diapositiva de notas

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // hacer visible este marcador de posición de pie de página en la diapositiva de notas

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // hacer visible este marcador de posición de número de diapositiva en la diapositiva de notas

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // hacer visible este marcador de posición de fecha y hora en la diapositiva de notas

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

**¿Puedo agregar un "encabezado" a diapositivas normales?**

En PowerPoint, el "encabezado" solo existe para notas y folletos; en diapositivas normales, los elementos compatibles son el Footer, la DateTime y el SlideNumber. En Aspose.Slides esto coincide con las mismas limitaciones: encabezado solo para Notes/Handout, y en diapositivas—Footer/DateTime/SlideNumber.

**¿Qué pasa si el diseño no contiene un área de pie de página—puedo "activarla"?**

Sí. Verifique la visibilidad mediante el gestor de encabezado/footer y actívela si es necesario. Estos indicadores y métodos de la API están diseñados para casos en que el marcador de posición falta o está oculto.

**¿Cómo hago que el número de diapositiva comience en un valor distinto de 1?**

Establezca el [first slide number](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) de la presentación; después de eso, toda la numeración se recalcula. Por ejemplo, puede comenzar en 0 o 10, y ocultar el número en la diapositiva de título.

**¿Qué ocurre con los encabezados/pies de página al exportar a PDF/imagenes/HTML?**

Se renderizan como elementos de texto normales de la presentación. Es decir, si los elementos son visibles en las diapositivas/páginas de notas, también aparecerán en el formato de salida junto con el resto del contenido.