---
title: Encabezado y pie de página de presentación
type: docs
weight: 140
url: /es/java/presentation-header-and-footer/
keywords: "Encabezado y pie de página de PowerPoint en Java"
description: "Encabezado y pie de página de PowerPoint en Java"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/es/java/) proporciona soporte para trabajar con el texto de encabezados y pies de página de las diapositivas que se mantienen en el nivel de diseño de diapositivas.

{{% /alert %}} 

[Aspose.Slides para Java](/slides/es/java/) proporciona la función para gestionar encabezados y pies de página dentro de las diapositivas de presentación. Estos se gestionan en el nivel de diseño de presentación.

## **Gestionar encabezado y pie de página en la presentación**
Las notas de una diapositiva específica pueden ser eliminadas como se muestra en el ejemplo siguiente:

```java
// Cargar presentación
Presentation pres = new Presentation("headerTest.pptx");
try {
    // Configurando pie de página
    pres.getHeaderFooterManager().setAllFootersText("Texto de mi pie de página");
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
                ((IAutoShape)shape).getTextFrame().setText("Hola, nuevo encabezado");
            }
        }
    }
}
```

## **Gestionar encabezado y pie de página en diapositivas de entrega y notas**
Aspose.Slides para Java soporta encabezados y pies de página en las diapositivas de entrega y notas. Por favor, siga los siguientes pasos:

- Cargue una [Presentación](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) que contenga un video.
- Cambie la configuración de encabezado y pie de página para el diseño de notas y todas las diapositivas de notas.
- Haga visibles el diseño de notas y todos los marcadores de posición de pie de página hijos.
- Haga visibles el diseño de notas y todos los marcadores de posición de fecha y hora hijos.
- Cambie la configuración de encabezado y pie de página solo para la primera diapositiva de notas.
- Haga visible el marcador de posición de encabezado de la diapositiva de notas.
- Establezca texto en el marcador de posición de encabezado de la diapositiva de notas.
- Establezca texto en el marcador de posición de fecha y hora de la diapositiva de notas.
- Escriba el archivo de presentación modificado.

Fragmento de código proporcionado en el siguiente ejemplo.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // Cambiar la configuración de encabezado y pie de página para el diseño de notas y todas las diapositivas de notas
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // hacer visibles el diseño de notas y todos los marcadores de posición de pie de página hijos
        headerFooterManager.setFooterAndChildFootersVisibility(true); // hacer visibles el diseño de notas y todos los marcadores de posición de encabezado hijos
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // hacer visibles el diseño de notas y todos los marcadores de posición de número de diapositiva
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // hacer visibles el diseño de notas y todos los marcadores de posición de fecha y hora hijos

        headerFooterManager.setHeaderAndChildHeadersText("Texto de encabezado"); // establecer texto para el diseño de notas y todos los marcadores de posición de encabezado hijos
        headerFooterManager.setFooterAndChildFootersText("Texto de pie de página"); // establecer texto para el diseño de notas y todos los marcadores de posición de pie de página hijos
        headerFooterManager.setDateTimeAndChildDateTimesText("Texto de fecha y hora"); // establecer texto para el diseño de notas y todos los marcadores de posición de fecha y hora hijos
    }

    // Cambiar la configuración de encabezado y pie de página solo para la primera diapositiva de notas
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // hacer visible este marcador de posición de encabezado de la diapositiva de notas

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // hacer visible este marcador de posición de pie de página de la diapositiva de notas

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // hacer visible este marcador de posición de número de diapositiva de la diapositiva de notas

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // hacer visible este marcador de posición de fecha y hora de la diapositiva de notas

        headerFooterManager.setHeaderText("Nuevo texto de encabezado"); // establecer texto en el marcador de posición de encabezado de la diapositiva de notas
        headerFooterManager.setFooterText("Nuevo texto de pie de página"); // establecer texto en el marcador de posición de pie de página de la diapositiva de notas
        headerFooterManager.setDateTimeText("Nuevo texto de fecha y hora"); // establecer texto en el marcador de posición de fecha y hora de la diapositiva de notas
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```