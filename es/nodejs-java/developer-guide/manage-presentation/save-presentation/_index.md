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
- Formato Strict de Office Open XML
- modo Zip64
- actualizando miniatura
- progreso de guardado
- Node.js
- JavaScript
- Aspose.Slides
description: "Guardar presentaciones de PowerPoint y OpenDocument en archivos o flujos con JavaScript y Aspose.Slides, y configurar la salida PPTX y el informe de progreso."
---
## **Visión general**

Después de crear una presentación o [abrir una existente](/slides/es/nodejs-java/open-presentation/), use el método [Presentation.save](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#save) para escribir el resultado. Aspose.Slides para Node.js mediante Java puede guardar una presentación en un archivo o flujo en formatos PowerPoint, OpenDocument, PDF y otros. Las siguientes secciones describen las operaciones estándar de guardado y las opciones disponibles para la salida PPTX.

## **Guardar presentaciones en archivos**

Para guardar una presentación en un archivo, pase la ruta de salida y un valor de [SaveFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/saveformat/) al método [Presentation.save](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#save). El valor de formato determina el tipo de archivo que Aspose.Slides crea.

El siguiente ejemplo crea una presentación y la guarda como archivo PPTX:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    // Añade o modifica el contenido de la presentación aquí.

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Guardar presentaciones en su formato original**

Para ejemplos de detección de archivos y flujos, el comportamiento de presentaciones recién creadas y la distinción entre formatos de origen y de salida, consulte [Determine the Original Presentation Format](/slides/es/nodejs-java/detect-presentation-source-format/).

En una aplicación de procesamiento por lotes, el formato de entrada puede no conocerse de antemano. Después de cargar un archivo, lea su formato original mediante el método [Presentation.getSourceFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#getSourceFormat). Pase el valor resultante de [SourceFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sourceformat/) a [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slideutil/#toSaveFormat) para obtener el valor correspondiente de [SaveFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/saveformat/), y luego utilice [Presentation.save](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#save) para escribir la presentación modificada.

El siguiente ejemplo completo procesa cada archivo en un directorio de entrada, actualiza su título y lo guarda en un directorio de salida en el formato desde el que se cargó:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const fs = require("fs");
const path = require("path");

const inputDirectory = "Input";
const outputDirectory = "Output";

if (!fs.existsSync(inputDirectory)) {
    console.error("The input directory does not exist.");
} else {
    fs.mkdirSync(outputDirectory, { recursive: true });

    const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
        .filter((entry) => entry.isFile());

    for (const inputFile of inputFiles) {
        const inputPath = path.join(inputDirectory, inputFile.name);
        try {
            const presentation = new aspose.slides.Presentation(inputPath);
            try {
                const saveFormat = aspose.slides.SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                const outputPath = path.join(outputDirectory, inputFile.name);
                presentation.save(outputPath, saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (error) {
            console.error(`Cannot process '${inputPath}': ${error.message}`);
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slideutil/#toSaveFormat) asigna PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP y PowerPoint XML a sus correspondientes formatos de guardado de presentación. Solo asigna formatos de origen de presentación; no está destinado a seleccionar formatos de exportación como PDF, HTML, TIFF o imágenes. Pasar un valor de [SourceFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sourceformat/) no compatible o inválido genera un error.

Los archivos heredados PPT, PPS y POT utilizan el mismo contenedor binario. Cuando una presentación de este tipo se carga desde un flujo sin extensión de archivo, un archivo PPS o POT puede identificarse como PPT. Si es necesario conservar estos subtipos heredados, conserve el nombre de archivo original o los metadatos de formato por separado y utilícelos al elegir el nombre y formato del archivo de salida.

## **Guardar presentaciones en flujos**

Para escribir una presentación sin depender de una ruta de archivo definitiva, pase un flujo de escritura y un valor de [SaveFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/saveformat/) al método [Presentation.save](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#save). Este enfoque es útil cuando la salida debe devolverse desde un servicio web, almacenarse en una base de datos o procesarse en memoria.

El siguiente ejemplo guarda una nueva presentación en un flujo de archivo:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "output.pptx");
    try {
        presentation.save(outputStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Guardar presentaciones con un tipo de vista predefinido**

Puede especificar la vista en la que PowerPoint abre inicialmente una presentación guardada. Use el método [ViewProperties.setLastView](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/viewproperties/#setLastView) con un valor de [ViewType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/viewtype/) antes de guardar.

El siguiente ejemplo configura la vista Maestro de diapositivas como vista inicial:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("slide-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Guardar presentaciones en el formato Strict Office Open XML**

Para crear un archivo PPTX que cumpla con el perfil Strict de Office Open XML, cree una instancia de [PptxOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pptxoptions/) y utilice su método [setConformance](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pptxoptions/#setConformance) con [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict). Luego pase las opciones al método [Presentation.save](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#save).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

const presentation = new aspose.slides.Presentation();
try {
    presentation.save("strict-office-open-xml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Guardar presentaciones en Office Open XML en modo Zip64**

Un archivo ZIP estándar limita el tamaño comprimido y descomprimido de cada entrada, el tamaño total del archivo y el número de entradas. Como un archivo PPTX es un archivo ZIP, una presentación muy grande puede superar esos límites. Las extensiones ZIP64 elevan los límites de tamaño y de número de entradas aplicables.

Use el método [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pptxoptions/#setZip64Mode) para controlar si Aspose.Slides escribe extensiones ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/zip64mode/#IfNecessary) usa ZIP64 solo cuando la presentación supera los límites estándar de ZIP. Este es el modo predeterminado.
- [Never](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/zip64mode/#Never) desactiva las extensiones ZIP64.
- [Always](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/zip64mode/#Always) siempre escribe extensiones ZIP64.

El siguiente ejemplo siempre habilita las extensiones ZIP64 para la presentación de salida:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setZip64Mode(aspose.slides.Zip64Mode.Always);

    presentation.save("output-zip64.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Si se usa [Zip64Mode.Never](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/zip64mode/#Never) y la presentación no cabe dentro de los límites estándar de ZIP, la operación de guardado lanza una [PptxException](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Guardar presentaciones en Office Open XML con niveles de compresión**

Para la salida PPTX, puede equilibrar la velocidad de guardado frente al tamaño del archivo usando el método [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel). La clase [CompressionLevel](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/compressionlevel/) proporciona los siguientes valores:

- [None](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/compressionlevel/#None) almacena los datos sin compresión.
- [Level1](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/compressionlevel/#Level1) ofrece la compresión más rápida y la salida comprimida más grande.
- [Level2](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/compressionlevel/#Level2) a [Level5](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/compressionlevel/#Level5) favorecen progresivamente una salida más pequeña sobre la velocidad de guardado.
- [Level6](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/compressionlevel/#Level6) equilibra la velocidad de guardado y el tamaño del archivo. Este es el nivel predeterminado.
- [Level7](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/compressionlevel/#Level7) y [Level8](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/compressionlevel/#Level8) favorecen aún más una salida más pequeña sobre la velocidad de guardado.
- [Level9](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/compressionlevel/#Level9) proporciona la compresión más fuerte y requiere más tiempo de procesamiento.

El siguiente ejemplo guarda una presentación sin compresión:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.None);

    presentation.save("output-no-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

El siguiente ejemplo usa el nivel máximo de compresión:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

    presentation.save("output-maximum-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Guardar presentaciones sin actualizar la miniatura**

Cuando una presentación se guarda como PPTX, el método [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) controla su miniatura del documento:

- `true` regenera la miniatura durante la operación de guardado. Este es el valor predeterminado.
- `false` conserva la miniatura existente. Si la presentación no tiene miniatura, Aspose.Slides no genera una.

El siguiente ejemplo guarda una presentación sin actualizar su miniatura:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Desactivar la actualización de la miniatura puede reducir el tiempo necesario para guardar un archivo PPTX.
{{% /alert %}}

## **Actualizaciones de progreso de guardado en porcentaje**

Para supervisar una operación de guardado, implemente la interfaz [IProgressCallback](https://reference.aspose.com/slides/es/java/com.aspose.slides/iprogresscallback/) con un proxy Java y pase la implementación al método [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/saveoptions/#setProgressCallback). Aspose.Slides llamará entonces al método [IProgressCallback.reporting](https://reference.aspose.com/slides/es/java/com.aspose.slides/iprogresscallback/#reporting-double-) con valores de progreso durante la exportación.

El siguiente ejemplo informa del progreso de una exportación a PDF en la consola:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const exportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

const options = new aspose.slides.PdfOptions();
options.setProgressCallback(exportProgressHandler);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose ofrece un [PowerPoint Splitter](https://products.aspose.app/slides/es/splitter) gratuito construido con la API Aspose.Slides. Guarda diapositivas seleccionadas de una presentación como archivos PPT o PPTX independientes.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Aspose.Slides admite guardado incremental o “fast save”?**

No. Cada operación de guardado escribe un archivo de salida completo en lugar de actualizar solo las partes modificadas.

**¿Pueden varios hilos guardar la misma instancia de Presentation?**

No. Una instancia de [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) [no es thread‑safe](/slides/es/nodejs-java/multithreading/). Acceda y guarde cada instancia desde un solo hilo a la vez.

**¿Qué ocurre con los hipervínculos y los archivos vinculados externamente al guardar una presentación?**

Los [hipervínculos](/slides/es/nodejs-java/manage-hyperlinks/) permanecen en la presentación. Aspose.Slides no copia los archivos vinculados externamente, por lo que la presentación guardada debe seguir pudiendo acceder a sus ubicaciones.

**¿Puedo guardar metadatos del documento como autor, título, empresa y fecha de creación?**

Sí. Establezca las [propiedades del documento](/slides/es/nodejs-java/presentation-properties/) adecuadas antes de guardar, y Aspose.Slides las escribe en el archivo de salida.