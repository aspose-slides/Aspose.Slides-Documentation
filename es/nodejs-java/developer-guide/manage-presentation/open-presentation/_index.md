---
title: Abrir presentaciones en JavaScript
linktitle: Abrir presentación
type: docs
weight: 20
url: /es/nodejs-java/open-presentation/
keywords:
- abrir PowerPoint
- abrir presentación
- abrir PPTX
- abrir PPT
- abrir ODP
- cargar presentación
- cargar PPTX
- cargar PPT
- cargar ODP
- presentación protegida
- presentación grande
- recurso externo
- objeto binario
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a abrir presentaciones PowerPoint y OpenDocument en JavaScript, proporcionar contraseñas de apertura, controlar la carga de recursos y reducir el uso de memoria con Aspose.Slides para Node.js mediante Java."
---
## **Introducción**

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/es/nodejs-java/) puede cargar presentaciones de PowerPoint y OpenDocument desde archivos y flujos. Después de cargar una presentación, puede inspeccionar su estructura, editar diapositivas, gestionar recursos y guardarla en el formato original u otro formato compatible.

El comportamiento de carga se puede personalizar mediante la clase [LoadOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/loadoptions/). Por ejemplo, puede proporcionar una contraseña de apertura, mantener los objetos binarios grandes fuera de la memoria de Node.js, controlar los recursos externos u omitir los datos binarios incrustados.

## **Abrir presentaciones**

Para abrir una presentación existente, pase su ruta de archivo al constructor de [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/). Libere la presentación después de su uso para que los manejadores de archivos, datos temporales y otros recursos se liberen rápidamente.

El siguiente ejemplo de JavaScript muestra cómo abrir una presentación y obtener el número de diapositivas:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Abrir presentaciones protegidas con contraseña**

Una contraseña de apertura cifra el contenido de la presentación. Para cargar la presentación completa, pase la contraseña correcta a [LoadOptions.setPassword](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/loadoptions/#setPassword) y proporcione las opciones al constructor de [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/). La carga falla cuando la contraseña falta o es incorrecta.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-presentation.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Para la detección, validación y flujos de trabajo de cifrado de contraseñas, consulte [Password-Protect Presentations](/slides/es/nodejs-java/password-protected-presentation/). Si una presentación cifrada se guardó deliberadamente con propiedades de documento públicas, esas propiedades pueden leerse sin contraseña; vea [Manage Presentation Properties](/slides/es/nodejs-java/presentation-properties/).

## **Abrir presentaciones grandes**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) devuelve opciones que controlan cómo Aspose.Slides maneja objetos binarios grandes como imágenes, audio y vídeo. Puede mantener el archivo fuente bloqueado, permitir archivos temporales y limitar la cantidad de datos BLOB conservados en memoria.

El siguiente código JavaScript muestra la carga de una presentación grande (por ejemplo, 2 GB):

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "large-presentation.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

const presentation = new slides.Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Nota" %}}
Con [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentationlockingbehavior/#KeepLocked), el archivo fuente permanece bloqueado hasta que la instancia de la presentación se libere. No mueva, sobrescriba ni elimine el archivo fuente mientras esa instancia esté viva.

Aspose.Slides puede copiar el contenido de un flujo de entrada durante la carga. Para presentaciones grandes, una ruta de archivo es, por lo tanto, generalmente más eficiente que un flujo. Consulte [Manage BLOBs](/slides/es/nodejs-java/manage-blob/) para opciones adicionales de almacenamiento y gestión de memoria.
{{% /alert %}}

## **Controlar recursos externos**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/loadoptions/#setResourceLoadingCallback) acepta una implementación de [IResourceLoadingCallback](https://reference.aspose.com/slides/es/java/com.aspose.slides/iresourceloadingcallback/). La devolución de llamada puede proporcionar datos de sustitución, redirigir un recurso, usar el cargador predeterminado o omitir el recurso. Esto es útil cuando las presentaciones contienen imágenes externas que deben resolverse de acuerdo con reglas de seguridad o almacenamiento específicas de la aplicación.

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const imageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
    resourceLoading: function(args) {
        const isJpeg = args.getOriginalUri().toLowerCase().endsWith(".jpg");
        const approvedImagePath = "approved-image.jpg";
        if (!isJpeg || !fs.existsSync(approvedImagePath)) {
            return slides.ResourceLoadingAction.Skip;
        }

        try {
            const imageData = fs.readFileSync(approvedImagePath);
            args.setData(imageData);
            return slides.ResourceLoadingAction.UserProvided;
        } catch (error) {
            console.error("The approved replacement image could not be read.");
            return slides.ResourceLoadingAction.Skip;
        }
    }
});

const loadOptions = new slides.LoadOptions();
loadOptions.setResourceLoadingCallback(imageLoadingHandler);

const presentation = new slides.Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Cargar presentaciones sin objetos binarios incrustados**

Una presentación puede contener datos binarios incrustados que una aplicación no necesita o no quiere conservar. Algunos ejemplos son:

- proyectos VBA, disponibles a través de [Presentation.getVbaProject](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#getVbaProject);
- datos OLE incrustados, disponibles a través de [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- datos de controles ActiveX, disponibles a través de [Control.getActiveXControlBinary](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/control/#getActiveXControlBinary).

Establezca [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) en `true` para eliminar estos datos binarios durante la carga. Guarde la presentación cargada para preservar el resultado sanitizado.

Esta opción reduce la exposición a cargas útiles incrustadas no deseadas, pero no constituye un sistema completo de detección de malware o sanitización de contenido.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

const presentation = new slides.Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿Cómo puedo saber que un archivo está corrupto y no se puede abrir?**

Aspose.Slides lanza una excepción de análisis o de formato durante la carga. Maneje ese error por separado del error de contraseña incorrecta para que la aplicación pueda informar la causa con precisión.

**¿Qué ocurre si faltan las fuentes necesarias?**

La presentación aún puede cargarse, pero la representación y la exportación pueden sustituir fuentes. Puede [configurar la sustitución de fuentes](/slides/es/nodejs-java/font-substitution/) o [proporcionar fuentes personalizadas](/slides/es/nodejs-java/custom-font/) para que la salida sea más predecible.

**¿La carga de una presentación también carga sus medios incrustados?**

Los audio y vídeo incrustados están disponibles a través del modelo de objetos de la presentación. Los recursos externos se resuelven según el comportamiento de carga configurado y pueden no estar disponibles si sus ubicaciones no pueden accederse.