---
title: Guardar presentaciones en JavaScript
linktitle: Guardar presentaciones
type: docs
weight: 80
url: /es/nodejs-java/save-presentation/
keywords:
- guardar PowerPoint
- guardar OpenDocument
- guardar presentación
- guardar diapositiva
- guardar PPT
- guardar PPTX
- guardar ODP
- presentación a archivo
- presentación a flujo
- tipo de vista predefinido
- Formato Strict Office Open XML
- modo Zip64
- refrescar miniatura
- progreso de guardado
- Node.js
- JavaScript
- Aspose.Slides
description: "Descubra cómo guardar presentaciones en JavaScript usando Aspose.Slides—exportar a PowerPoint o OpenDocument manteniendo diseños, fuentes y efectos."
---

## **Resumen**

[Open Presentations in JavaScript](/slides/es/nodejs-java/open-presentation/) describió cómo usar la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) para abrir una presentación. Este artículo explica cómo crear y guardar presentaciones. La clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) contiene el contenido de una presentación. Ya sea que esté creando una presentación desde cero o modificando una existente, querrá guardarla cuando haya terminado. Con Aspose.Slides para Node.js, puede guardar en un **archivo** o **flujo**. Este artículo explica las diferentes formas de guardar una presentación.

## **Guardar presentaciones en archivos**

Guarde una presentación en un archivo llamando al método `save` de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/). Pase el nombre del archivo y el formato de guardado al método. El siguiente ejemplo muestra cómo guardar una presentación con Aspose.Slides.
```js
// Instanciar la clase Presentation que representa un archivo de presentación.
let presentation = new aspose.slides.Presentation();
try {
    // Realizar algún trabajo aquí...

    // Guardar la presentación en un archivo.
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Guardar presentaciones en flujos**

Puede guardar una presentación en un flujo pasando un flujo de salida al método `save` de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/). Una presentación puede escribirse en muchos tipos de flujo. En el ejemplo a continuación, creamos una nueva presentación y la guardamos en un flujo de archivo.
```js
// Instanciar la clase Presentation que representa un archivo de presentación.
let presentation = new aspose.slides.Presentation();
try {
    let fileStream = java.newInstanceSync("java.io.FileOutputStream", "Output.pptx");
    try {
        // Guardar la presentación en el flujo.
        presentation.save(fileStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```


## **Guardar presentaciones con un tipo de vista predefinido**

Aspose.Slides le permite establecer la vista inicial que PowerPoint usa cuando la presentación generada se abre mediante la clase [ViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/). Use el método [setLastView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setLastView) con un valor de la enumeración [ViewType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewtype/).
```js
let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Guardar presentaciones en el formato Strict Office Open XML**

Aspose.Slides le permite guardar una presentación en el formato Strict Office Open XML. Use la clase [PptxOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxoptions/) y establezca su propiedad **conformance** al guardar. Si establece [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict), el archivo de salida se guarda en el formato Strict Office Open XML.

El ejemplo a continuación crea una presentación y la guarda en el formato Strict Office Open XML.
```js
let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// Instanciar la clase Presentation que representa un archivo de presentación.
let presentation = new aspose.slides.Presentation();
try {
    // Guardar la presentación en el formato Strict Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```


## **Guardar presentaciones en el formato Office Open XML en modo Zip64**

Un archivo Office Open XML es un archivo ZIP que impone límites de 4 GB (2^32 bytes) al tamaño sin comprimir de cualquier archivo, al tamaño comprimido de cualquier archivo y al tamaño total del archivo, y también limita el archivo a 65 535 (2^16‑1) archivos. Las extensiones de formato ZIP64 elevan estos límites a 2^64.

El método [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) le permite elegir cuándo usar extensiones de formato ZIP64 al guardar un archivo Office Open XML.

Este método puede usarse con los siguientes modos:

- [IfNecessary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zip64mode/#IfNecessary) usa extensiones ZIP64 solo si la presentación supera las limitaciones anteriores. Este es el modo predeterminado.
- [Never](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zip64mode/#Never) nunca usa extensiones ZIP64.
- [Always](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zip64mode/#Always) siempre usa extensiones ZIP64.

El siguiente código muestra cómo guardar una presentación como PPTX con extensiones de formato ZIP64 habilitadas:
```js
let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setZip64Mode(aspose.slides.Zip64Mode.Always);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```


{{% alert title="NOTA" color="warning" %}}

Cuando guarda con [Zip64Mode.Never](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zip64mode/#Never), se lanza una [PptxException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxexception/) si la presentación no puede guardarse en formato ZIP32.

{{% /alert %}}

## **Guardar presentaciones sin actualizar la miniatura**

El método [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) controla la generación de miniaturas al guardar una presentación en PPTX:

- Si se establece en `true`, la miniatura se actualiza durante el guardado. Este es el valor predeterminado.
- Si se establece en `false`, se conserva la miniatura actual. Si la presentación no tiene miniatura, no se genera ninguna.

En el código a continuación, la presentación se guarda en PPTX sin actualizar su miniatura.
```js
let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setRefreshThumbnail(false);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```


{{% alert title="Información" color="info" %}}

Esta opción ayuda a reducir el tiempo necesario para guardar una presentación en formato PPTX.

{{% /alert %}}

## **Actualizar el progreso de guardado en porcentaje**

Los informes de progreso de guardado se configuran mediante el método [setProgressCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) en [SaveOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) y sus subclases. Proporcione un proxy Java que implemente la interfaz [IProgressCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iprogresscallback/); durante la exportación, la devolución de llamada recibe actualizaciones periódicas de porcentaje.

Los siguientes fragmentos de código muestran cómo usar `IProgressCallback`.
```javascript
const ExportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        // Utilice el valor del porcentaje de progreso aquí.
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

let saveOptions = new aspose.slides.PdfOptions();
saveOptions.setProgressCallback(ExportProgressHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", aspose.slides.SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```


{{% alert title="Información" color="info" %}}

Aspose ha desarrollado una [aplicación gratuita PowerPoint Splitter](https://products.aspose.app/slides/splitter) usando su propia API. La aplicación le permite dividir una presentación en varios archivos guardando diapositivas seleccionadas como nuevos archivos PPTX o PPT.

{{% /alert %}}

## **Preguntas frecuentes**

**¿Se admite "guardado rápido" (guardado incremental) para que solo se escriban los cambios?**

No. Cada guardado crea el archivo de destino completo; el "guardado rápido" incremental no está soportado.

**¿Es seguro guardar la misma instancia de Presentation desde varios hilos?**

No. Una [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) [no es segura para subprocesos](/slides/es/nodejs-java/multithreading/); guárdela desde un solo hilo.

**¿Qué ocurre con los hipervínculos y los archivos enlazados externamente al guardar?**

Los [hipervínculos](/slides/es/nodejs-java/manage-hyperlinks/) se conservan. Los archivos enlazados externamente (por ejemplo, videos mediante rutas relativas) no se copian automáticamente; asegúrese de que las rutas referenciadas sigan siendo accesibles.

**¿Puedo establecer/guardar metadatos del documento (Autor, Título, Empresa, Fecha)?**

Sí. Las [propiedades estándar del documento](/slides/es/nodejs-java/presentation-properties/) son compatibles y se escribirán en el archivo al guardarlo.