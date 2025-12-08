---
title: Encabezado y pie de página de la presentación
type: docs
weight: 140
url: /es/nodejs-java/presentation-header-and-footer/
keywords: "Encabezado y pie de página de PowerPoint en JavaScript"
description: "Encabezado y pie de página de PowerPoint en JavaScript"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/es/nodejs-java/) ofrece soporte para trabajar con el texto de encabezados y pies de página de las diapositivas, que en realidad se mantiene a nivel de la diapositiva maestra.

{{% /alert %}} 

[Aspose.Slides for Node.js via Java](/slides/es/nodejs-java/) proporciona la función para gestionar encabezados y pies de página dentro de las diapositivas de una presentación. Estos se gestionan, de hecho, a nivel de la presentación maestra.

## **Administrar encabezado y pie de página en la presentación**
Las notas de una diapositiva específica pueden eliminarse como se muestra en el siguiente ejemplo:
```javascript
// Cargar presentación
var pres = new aspose.slides.Presentation("headerTest.pptx");
try {
    // Configurar pie de página
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);
    // Acceder y actualizar encabezado
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide) {
        updateHeaderFooterText(masterNotesSlide);
    }
    // Guardar presentación
    pres.save("HeaderFooterJava.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
function updateHeaderFooterText(master) {
    let shapes = master.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i); 
        if (shape.getPlaceholder() !== null) {
            if (shape.getPlaceholder().getType() === aspose.PlaceholderType.Header) {
                shape.getTextFrame().setText("HI there new header");
            }
        }
    }
}
```


## **Administrar encabezado y pie de página en diapositivas de folleto y notas**
Aspose.Slides para Node.js mediante Java admite encabezado y pie de página en diapositivas de folleto y notas. Siga los pasos a continuación:

- Cargue una [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) que contenga un video.
- Cambie la configuración de encabezado y pie de página para la maestro de notas y todas las diapositivas de notas.
- Establezca visibles los marcadores de posición de pie de página en la diapositiva maestra de notas y en todas las diapositivas secundarias.
- Establezca visibles los marcadores de posición de fecha y hora en la diapositiva maestra de notas y en todas las diapositivas secundarias.
- Cambie la configuración de encabezado y pie de página solo para la primera diapositiva de notas.
- Establezca visible el marcador de posición de encabezado en la diapositiva de notas.
- Establezca el texto en el marcador de posición de encabezado de la diapositiva de notas.
- Establezca el texto en el marcador de posición de fecha y hora de la diapositiva de notas.
- Guarde el archivo de presentación modificado.

Fragmento de código proporcionado en el ejemplo a continuación.
```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    // Cambiar la configuración de encabezado y pie de página para la diapositiva maestra de notas y todas las diapositivas de notas
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null) {
        var headerFooterManager = masterNotesSlide.getHeaderFooterManager();
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);// hacer visible la diapositiva maestra de notas y todos los marcadores de posición de pie de página secundarios
        headerFooterManager.setFooterAndChildFootersVisibility(true);// hacer visible la diapositiva maestra de notas y todos los marcadores de posición de encabezado secundarios
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);// hacer visible la diapositiva maestra de notas y todos los marcadores de posición de número de diapositiva secundarios
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);// hacer visible la diapositiva maestra de notas y todos los marcadores de posición de fecha y hora secundarios
        headerFooterManager.setHeaderAndChildHeadersText("Header text");// establecer texto en la diapositiva maestra de notas y todos los marcadores de posición de encabezado secundarios
        headerFooterManager.setFooterAndChildFootersText("Footer text");// establecer texto en la diapositiva maestra de notas y todos los marcadores de posición de pie de página secundarios
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");// establecer texto en la diapositiva maestra de notas y todos los marcadores de posición de fecha y hora secundarios
    }
    // Cambiar la configuración de encabezado y pie de página solo para la primera diapositiva de notas
    var notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null) {
        var headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible()) {
            headerFooterManager.setHeaderVisibility(true);
        }// hacer visible el marcador de posición de encabezado de esta diapositiva de notas
        if (!headerFooterManager.isFooterVisible()) {
            headerFooterManager.setFooterVisibility(true);
        }// hacer visible el marcador de posición de pie de página de esta diapositiva de notas
        if (!headerFooterManager.isSlideNumberVisible()) {
            headerFooterManager.setSlideNumberVisibility(true);
        }// hacer visible el marcador de posición de número de diapositiva de esta diapositiva de notas
        if (!headerFooterManager.isDateTimeVisible()) {
            headerFooterManager.setDateTimeVisibility(true);
        }// hacer visible el marcador de posición de fecha y hora de esta diapositiva de notas
        headerFooterManager.setHeaderText("New header text");// establecer texto en el marcador de posición de encabezado de la diapositiva de notas
        headerFooterManager.setFooterText("New footer text");// establecer texto en el marcador de posición de pie de página de la diapositiva de notas
        headerFooterManager.setDateTimeText("New date and time text");// establecer texto en el marcador de posición de fecha y hora de la diapositiva de notas
    }
    pres.save("testresult.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Preguntas frecuentes**

**¿Puedo agregar un "encabezado" a las diapositivas normales?**

En PowerPoint, el "encabezado" solo existe para notas y folletos; en las diapositivas normales, los elementos compatibles son el pie de página, la fecha/hora y el número de diapositiva. En Aspose.Slides esto coincide con las mismas limitaciones: encabezado solo para Notas/Folleto, y en las diapositivas—Pie de página/FechaHora/NúmeroDeDiapositiva.

**¿Qué pasa si el diseño no contiene un área de pie de página—puedo "activar" su visibilidad?**

Sí. Verifique la visibilidad mediante el gestor de encabezado/pie de página y habilítela si es necesario. Estos indicadores y métodos de la API están diseñados para casos en los que el marcador de posición falta o está oculto.

**¿Cómo hago que el número de diapositiva comience desde un valor distinto de 1?**

Establezca el [primer número de diapositiva](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) de la presentación; después de ello, toda la numeración se recalcula. Por ejemplo, puede comenzar en 0 o 10, y ocultar el número en la diapositiva de título.

**¿Qué ocurre con los encabezados/pies de página al exportar a PDF/imágenes/HTML?**

Se renderizan como elementos de texto normales de la presentación. Es decir, si los elementos son visibles en las diapositivas/páginas de notas, también aparecerán en el formato de salida junto con el resto del contenido.