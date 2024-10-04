---
title: Encabezado y pie de página de presentación
type: docs
weight: 140
url: /androidjava/presentation-header-and-footer/
keywords: "Encabezado y pie de página de PowerPoint en Java"
description: "Encabezado y pie de página de PowerPoint en Java"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/androidjava/) proporciona soporte para trabajar con el texto de los encabezados y pies de página de las diapositivas que en realidad se mantienen a nivel de maestro de diapositivas.

{{% /alert %}} 

[Aspose.Slides para Android a través de Java](/slides/androidjava/) proporciona la función para gestionar encabezados y pies de página dentro de las diapositivas de la presentación. De hecho, estos se gestionan a nivel de maestro de presentación.

## **Gestionar Encabezado y Pie de Página en Presentación**
Las notas de una diapositiva específica podrían eliminarse como se muestra en el ejemplo a continuación:

```java
// Cargar presentación
Presentation pres = new Presentation("headerTest.pptx");
try {
    // Configurar pie de página
    pres.getHeaderFooterManager().setAllFootersText("Mi texto de pie de página");
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

## **Gestionar Encabezado y Pie de Página en Diapositivas de Resumen y Notas**
Aspose.Slides para Android a través de Java admite encabezados y pies de página en diapositivas de resumen y notas. Siga los pasos a continuación:

- Cargue una [Presentación](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) que contenga un video.
- Cambie la configuración de encabezado y pie de página para el maestro de notas y todas las diapositivas de notas.
- Haga que el maestro de notas y todos los marcadores de pie de página secundarios sean visibles.
- Haga que el maestro de notas y todos los marcadores de fecha y hora secundarios sean visibles.
- Cambie la configuración de encabezado y pie de página solo para la primera diapositiva de notas.
- Haga visible el marcador de encabezado de la diapositiva de notas.
- Establezca el texto en el marcador de encabezado de la diapositiva de notas.
- Establezca el texto en el marcador de fecha y hora de la diapositiva de notas.
- Escriba el archivo de presentación modificado.

Fragmento de código proporcionado en el ejemplo a continuación.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // Cambie la configuración de encabezado y pie de página para el maestro de notas y todas las diapositivas de notas
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // haga visibles el maestro de notas y todos los marcadores de pie de página secundarios
        headerFooterManager.setFooterAndChildFootersVisibility(true); // haga visibles el maestro de notas y todos los marcadores de encabezado secundarios
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // haga visibles el maestro de notas y todos los marcadores de número de diapositiva secundarios
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // haga visibles el maestro de notas y todos los marcadores de fecha y hora secundarios

        headerFooterManager.setHeaderAndChildHeadersText("Texto del encabezado"); // establezca el texto en el maestro de notas y en todos los marcadores de encabezado secundarios
        headerFooterManager.setFooterAndChildFootersText("Texto del pie de página"); // establezca el texto en el maestro de notas y en todos los marcadores de pie de página secundarios
        headerFooterManager.setDateTimeAndChildDateTimesText("Texto de fecha y hora"); // establezca el texto en el maestro de notas y en todos los marcadores de fecha y hora secundarios
    }

    // Cambie la configuración de encabezado y pie de página solo para la primera diapositiva de notas
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // haga visible este marcador de encabezado de diapositiva de notas

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // haga visible este marcador de pie de página de diapositiva de notas

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // haga visible este marcador de número de diapositiva de notas

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // haga visible este marcador de fecha y hora de diapositiva de notas

        headerFooterManager.setHeaderText("Nuevo texto de encabezado"); // establezca el texto en el marcador de encabezado de la diapositiva de notas
        headerFooterManager.setFooterText("Nuevo texto de pie de página"); // establezca el texto en el marcador de pie de página de la diapositiva de notas
        headerFooterManager.setDateTimeText("Nuevo texto de fecha y hora"); // establezca el texto en el marcador de fecha y hora de la diapositiva de notas
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```