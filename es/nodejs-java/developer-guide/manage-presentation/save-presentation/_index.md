---
title: Guardar presentaciones en JavaScript
linktitle: Guardar presentación
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
- formato estricto Office Open XML
- modo Zip64
- actualizar miniatura
- guardar progreso
- Node.js
- JavaScript
- Aspose.Slides
description: "Descubra cómo guardar presentaciones utilizando Aspose.Slides para Node.js mediante Java — exporte a PowerPoint u OpenDocument manteniendo diseños, fuentes y efectos."
---
## **Visión general**

[Open Presentations in JavaScript](/slides/es/nodejs-java/open-presentation/) describió cómo usar la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) para abrir una presentación. Este artículo explica cómo crear y guardar presentaciones. La clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) contiene el contenido de una presentación. Tanto si está creando una presentación desde cero como si está modificando una existente, querrá guardarla cuando haya terminado. Con Aspose.Slides para Node.js, puede guardar en un **archivo** o **flujo**. Este artículo explica las diferentes formas de guardar una presentación.

## **Guardar presentaciones en archivos**

Guarde una presentación en un archivo llamando al método `save` de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/). Pase el nombre del archivo y el formato de guardado al método. El siguiente ejemplo muestra cómo guardar una presentación con Aspose.Slides.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Puede guardar una presentación en un flujo pasando un flujo de salida al método `save` de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/). Una presentación puede escribirse en muchos tipos de flujo. En el ejemplo siguiente, creamos una nueva presentación y la guardamos en un flujo de archivo.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

Aspose.Slides le permite establecer la vista inicial que PowerPoint usa cuando se abre la presentación generada mediante la clase [ViewProperties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/viewproperties/). Utilice el método [setLastView](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/viewproperties/#setLastView) con un valor de la enumeración [ViewType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/viewtype/).

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Guardar presentaciones en el formato estricto Office Open XML**

Aspose.Slides le permite guardar una presentación en el formato estricto Office Open XML. Utilice la clase [PptxOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pptxoptions/) y establezca su propiedad conformance al guardar. Si establece [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict), el archivo de salida se guarda en el formato estricto Office Open XML.

El ejemplo siguiente crea una presentación y la guarda en el formato estricto Office Open XML.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// Instanciar la clase Presentation que representa un archivo de presentación.
let presentation = new aspose.slides.Presentation();
try {
    // Guardar la presentación en el formato estricto Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Guardar presentaciones en formato Office Open XML en modo Zip64**

Un archivo Office Open XML es un archivo ZIP que impone límites de 4 GB (2^32 bytes) en el tamaño sin comprimir de cualquier archivo, el tamaño comprimido de cualquier archivo y el tamaño total del archivo, y también limita el archivo a 65 535 (2^16‑1) archivos. Las extensiones del formato ZIP64 elevan estos límites a 2^64.

El método [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) le permite elegir cuándo usar las extensiones del formato ZIP64 al guardar un archivo Office Open XML.

Este método puede usarse con los siguientes modos:

- [IfNecessary](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/zip64mode/#IfNecessary) usa las extensiones del formato ZIP64 solo si la presentación supera las limitaciones anteriores. Este es el modo predeterminado.
- [Never](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/zip64mode/#Never) nunca usa las extensiones del formato ZIP64.
- [Always](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/zip64mode/#Always) siempre usa las extensiones del formato ZIP64.

El siguiente código demuestra cómo guardar una presentación como archivo PPTX con las extensiones del formato ZIP64 habilitadas:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setZip64Mode(aspose.slides.Zip64Mode.Always);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
Cuando guarda con [Zip64Mode.Never](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/zip64mode/#Never), se lanza una [PptxException](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pptxexception/) si la presentación no puede guardarse en formato ZIP32.
{{% /alert %}}

## **Guardar presentaciones en formato Office Open XML con niveles de compresión**

Al trabajar con presentaciones grandes, puede ajustar el nivel de compresión para equilibrar el tamaño del archivo y el tiempo de procesamiento. Según sus requisitos, puede preferir un procesamiento más rápido o archivos de salida más pequeños.

Aspose.Slides proporciona el método [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel), que le permite especificar el nivel de compresión utilizado al guardar una presentación en formato Office Open XML.

Los siguientes niveles de compresión están disponibles:

- [**None**](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/compressionlevel/#None): No se aplica compresión. Los archivos se guardan tal cual.
- [**Level1**](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/compressionlevel/#Level1): La compresión más rápida con la menor relación de compresión.
- [**Level2**](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/compressionlevel/#Level2): Compresión más rápida con una relación de compresión ligeramente mejor que **Level1**.
- [**Level3**](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/compressionlevel/#Level3): Proporciona mejor compresión que **Level2** con un impacto moderado en el tiempo de procesamiento.
- [**Level4**](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/compressionlevel/#Level4): Proporciona mejor compresión que **Level3**.
- [**Level5**](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/compressionlevel/#Level5): Proporciona compresión mejorada respecto a **Level4** con tiempo de procesamiento adicional.
- [**Level6**](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/compressionlevel/#Level6): Compresión estándar que ofrece un buen equilibrio entre velocidad de procesamiento y tamaño del archivo. Este es el *nivel de compresión predeterminado*.
- [**Level7**](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/compressionlevel/#Level7): Proporciona mejor compresión que **Level6** con un procesamiento más lento.
- [**Level8**](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/compressionlevel/#Level8): Proporciona mejor compresión que **Level7**.
- [**Level9**](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/compressionlevel/#Level9): Compresión máxima. Produce el archivo de menor tamaño a costa del mayor tiempo de procesamiento.

El siguiente ejemplo demuestra cómo guardar una presentación como archivo PPTX *sin compresión*:

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.None);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

Este ejemplo muestra cómo guardar una presentación como archivo PPTX con *compresión máxima*:

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **Guardar presentaciones sin actualizar la miniatura**

El método [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) controla la generación de miniaturas al guardar una presentación en PPTX:

- Si se establece en `true`, la miniatura se actualiza durante el guardado. Este es el valor predeterminado.
- Si se establece en `false`, se conserva la miniatura actual. Si la presentación no tiene miniatura, no se genera ninguna.

En el código siguiente, la presentación se guarda en PPTX sin actualizar su miniatura.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

{{% alert title="Info" color="info" %}}
Esta opción ayuda a reducir el tiempo necesario para guardar una presentación en formato PPTX.
{{% /alert %}}

## **Guardar actualizaciones de progreso en porcentaje**

Los informes de progreso de guardado se configuran mediante el método [setProgressCallback](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) en [SaveOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/saveoptions/) y sus subclases. Proporcione un proxy Java que implemente la interfaz [IProgressCallback](https://reference.aspose.com/slides/es/java/com.aspose.slides/iprogresscallback/); durante la exportación, el callback recibe actualizaciones periódicas de porcentaje.

Los siguientes fragmentos de código muestran cómo usar `IProgressCallback`.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const ExportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        // Utilice aquí el valor del porcentaje de progreso.
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

{{% alert title="Info" color="info" %}}
Aspose ha desarrollado una [aplicación gratuita PowerPoint Splitter](https://products.aspose.app/slides/es/splitter) usando su propia API. La aplicación le permite dividir una presentación en varios archivos guardando las diapositivas seleccionadas como nuevos archivos PPTX o PPT.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Se soporta el “guardado rápido” (guardado incremental) para que sólo se escriban los cambios?**

No. Cada guardado crea el archivo completo de destino; el “guardado rápido” incremental no está soportado.

**¿Es seguro en cuanto a subprocesos guardar la misma instancia de Presentation desde varios hilos?**

No. Una instancia de [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) [no es segura para subprocesos](/slides/es/nodejs-java/multithreading/); guárdela desde un único hilo.

**¿Qué ocurre con los hipervínculos y los archivos vinculados externamente al guardar?**

[Los hipervínculos](/slides/es/nodejs-java/manage-hyperlinks/) se conservan. Los archivos vinculados externamente (p. ej., videos mediante rutas relativas) no se copian automáticamente; asegúrese de que las rutas referenciadas sigan siendo accesibles.

**¿Puedo establecer/guardar metadatos del documento (Autor, Título, Empresa, Fecha)?**

Sí. Las [propiedades estándar del documento](/slides/es/nodejs-java/presentation-properties/) son compatibles y se escribirán en el archivo al guardarlo.