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
description: "Aprenda a abrir presentaciones PowerPoint y OpenDocument en JavaScript, proporcionar contraseñas de apertura, controlar la carga de recursos y reducir el uso de memoria con Aspose.Slides para Node.js vía Java."
---
## **Introducción**

[Aspose.Slides para Node.js vía Java](https://products.aspose.com/slides/es/nodejs-java/) puede cargar presentaciones PowerPoint y OpenDocument desde archivos y flujos. Después de cargar una presentación, puede inspeccionar su estructura, editar diapositivas, gestionar recursos y guardarla en el formato original o en otro formato compatible.

El comportamiento de carga se puede personalizar mediante la clase [LoadOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/loadoptions/). Por ejemplo, puede proporcionar una contraseña de apertura, mantener objetos binarios grandes fuera de la memoria de Node.js, controlar recursos externos o omitir datos binarios incrustados.

## **Abrir presentaciones**

Después de cargar un archivo o flujo, puede [determinar su formato de presentación original](/slides/es/nodejs-java/detect-presentation-source-format/) para elegir cómo su aplicación lo procesa.

Para abrir una presentación existente, pase su ruta de archivo al constructor [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/). Deseche la presentación después de usarla para que los manejadores de archivo, datos temporales y otros recursos se liberen rápidamente.

El siguiente ejemplo de JavaScript muestra cómo abrir una presentación y obtener su recuento de diapositivas:

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

Una contraseña de apertura cifra el contenido de la presentación. Para cargar la presentación completa, pase la contraseña correcta a [LoadOptions.setPassword](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/loadoptions/#setPassword) y proporcione las opciones al constructor [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/). La carga falla cuando la contraseña falta o es incorrecta.

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

## **Abrir presentaciones de gran tamaño**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) devuelve opciones que controlan cómo Aspose.Slides maneja objetos binarios grandes como imágenes, audio y video. Puede mantener el archivo fuente bloqueado, permitir archivos temporales y limitar la cantidad de datos BLOB retenidos en memoria.

El siguiente código JavaScript demuestra la carga de una presentación grande (por ejemplo, 2 GB):

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

{{% alert color="info" title="Note" %}}

Con [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentationlockingbehavior/#KeepLocked), el archivo fuente permanece bloqueado hasta que se deseche la instancia de la presentación. No mueva, sobrescriba ni elimine el archivo fuente mientras esa instancia esté activa.

Aspose.Slides puede copiar el contenido de un flujo de entrada mientras lo carga. Para presentaciones de gran tamaño, una ruta de archivo suele ser más eficiente que un flujo. Consulte [Manage BLOBs](/slides/es/nodejs-java/manage-blob/) para opciones adicionales de almacenamiento y gestión de memoria.

{{% /alert %}}

## **Controlar recursos externos**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/loadoptions/#setResourceLoadingCallback) acepta una implementación de [IResourceLoadingCallback](https://reference.aspose.com/slides/es/java/com.aspose.slides/iresourceloadingcallback/). La devolución de llamada puede proporcionar datos de reemplazo, redirigir un recurso, usar el cargador predeterminado o omitir el recurso. Esto es útil cuando las presentaciones contienen imágenes externas que deben resolverse según reglas de seguridad o almacenamiento específicas de la aplicación.

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

Una presentación puede contener datos binarios incrustados que una aplicación no necesita o no desea conservar. Algunos ejemplos son:

- proyectos VBA, accesibles mediante [Presentation.getVbaProject](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#getVbaProject);
- datos OLE incrustados, accesibles mediante [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- datos de controles ActiveX, accesibles mediante [Control.getActiveXControlBinary](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/control/#getActiveXControlBinary).

Establezca [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) en `true` para eliminar esos datos binarios durante la carga. Guarde la presentación cargada para conservar el resultado sanitizado.

Esta opción reduce la exposición a cargas útiles incrustadas no deseadas, pero no constituye un sistema completo de detección de malware o de sanitización de contenido.

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

## **FAQ**

**¿Cómo puedo saber si un archivo está corrupto y no se puede abrir?**

Aspose.Slides lanza una excepción de análisis o de formato durante la carga. Gestione ese fallo por separado de un error de contraseña incorrecta para que la aplicación pueda informar la causa con precisión.

**¿Qué ocurre si faltan fuentes requeridas?**

La presentación aún puede cargarse, pero la representación y la exportación pueden sustituir fuentes. Puede [configurar la sustitución de fuentes](/slides/es/nodejs-java/font-substitution/) o [proporcionar fuentes personalizadas](/slides/es/nodejs-java/custom-font/) para que la salida sea más predecible.

**¿La carga de una presentación también carga sus medios incrustados?**

Los audio y video incrustados se ponen a disposición a través del modelo de objetos de la presentación. Los recursos externos se resuelven según el comportamiento de carga de recursos configurado y pueden no estar disponibles si sus ubicaciones no pueden accederse.