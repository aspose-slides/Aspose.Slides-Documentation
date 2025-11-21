---
title: Abrir una presentación en JavaScript
linktitle: Abrir presentaciones
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
description: "Abra presentaciones PowerPoint (.pptx, .ppt) y OpenDocument (.odp) sin esfuerzo con Aspose.Slides para Node.js: rápido, fiable y con todas las funciones."
---

## **Descripción general**

Además de crear presentaciones de PowerPoint desde cero, Aspose.Slides también permite abrir presentaciones existentes. Después de cargar una presentación, puedes obtener información sobre ella, editar el contenido de las diapositivas, agregar nuevas diapositivas, eliminar las existentes y mucho más.

## **Abrir presentaciones**

Para abrir una presentación existente, instancia la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) y pasa la ruta del archivo a su constructor.

El siguiente ejemplo de JavaScript muestra cómo abrir una presentación y obtener el recuento de diapositivas:
```js
// Instancie la clase Presentation y pase una ruta de archivo a su constructor.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // Imprima el número total de diapositivas en la presentación.
    console.log(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```


## **Abrir presentaciones protegidas con contraseña**

Cuando necesites abrir una presentación protegida con contraseña, pasa la contraseña mediante el método [setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setPassword) de la clase [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/) para descifrarla y cargarla. El siguiente código JavaScript demuestra esta operación:
```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
try {
    // Realice operaciones en la presentación descifrada.
} finally {
    presentation.dispose();
}
```


## **Abrir presentaciones de gran tamaño**

Aspose.Slides proporciona opciones—en particular el método [getBlobManagementOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) en la clase [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/)—para ayudar a cargar presentaciones de gran tamaño.

El siguiente código JavaScript muestra cómo cargar una presentación grande (por ejemplo, 2 GB):
```js
const filePath = "LargePresentation.pptx";

let loadOptions = new aspose.slides.LoadOptions();
// Elija el comportamiento KeepLocked: el archivo de la presentación permanecerá bloqueado durante la vida de
// la instancia Presentation, pero no necesita cargarse en memoria ni copiarse a un archivo temporal.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

let presentation = new aspose.slides.Presentation(filePath, loadOptions);
try {
    // La presentación grande se ha cargado y puede usarse, mientras el consumo de memoria se mantiene bajo.
    
    // Realice cambios en la presentación.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Guarde la presentación en otro archivo. El consumo de memoria se mantiene bajo durante esta operación.
    presentation.save("LargePresentation-copy.pptx", aspose.slides.SaveFormat.Pptx);

    // ¡No haga esto! Se lanzará una excepción de E/S porque el archivo está bloqueado hasta que se deseche el objeto Presentation.
    //fs.unlinkSync(filePath);
} finally {
    presentation.dispose();
}

// Está bien hacerlo aquí. El archivo fuente ya no está bloqueado por el objeto Presentation.
fs.unlinkSync(filePath);
```


{{% alert color="info" title="Info" %}}
Para evitar ciertas limitaciones al trabajar con streams, Aspose.Slides puede copiar el contenido de un stream. Cargar una presentación grande desde un stream provoca que la presentación se copie y puede ralentizar la carga. Por lo tanto, cuando necesites cargar una presentación grande, recomendamos encarecidamente usar la ruta del archivo de la presentación en lugar de un stream.

Al crear una presentación que contenga objetos de gran tamaño (vídeo, audio, imágenes de alta resolución, etc.), puedes usar la [gestión de BLOB](/slides/es/nodejs-java/manage-blob/) para reducir el consumo de memoria.
{{%/alert %}}

## **Controlar recursos externos**

Aspose.Slides proporciona la interfaz [IResourceLoadingCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iresourceloadingcallback/) que permite gestionar recursos externos. El siguiente código JavaScript muestra cómo usar la interfaz `IResourceLoadingCallback`:
```js
const ImageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
  resourceLoading: function(args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // Cargar una imagen de sustitución.
                const imageData = fs.readFileSync("aspose-logo.jpg");
                args.setData(imageData);
                return aspose.slides.ResourceLoadingAction.UserProvided;
            } catch {
                return aspose.slides.ResourceLoadingAction.Skip;
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // Establecer una URL de sustitución.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return aspose.slides.ResourceLoadingAction.Default;
        }
        // Omitir todas las demás imágenes.
        return aspose.slides.ResourceLoadingAction.Skip;
      }
});
```

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setResourceLoadingCallback(ImageLoadingHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
```


## **Cargar presentaciones sin objetos binarios incrustados**

Una presentación de PowerPoint puede contener los siguientes tipos de objetos binarios incrustados:

- proyecto VBA (accesible mediante [Presentation.getVbaProject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getVbaProject));
- datos incrustados de objeto OLE (accesibles mediante [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData));
- datos binarios de control ActiveX (accesibles mediante [Control.getActiveXControlBinary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getActiveXControlBinary)).

Mediante el método [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects), puedes cargar una presentación sin objetos binarios incrustados.

Este método es útil para eliminar contenido binario potencialmente malicioso. El siguiente código JavaScript muestra cómo cargar una presentación sin contenido binario incrustado:
```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

let presentation = new aspose.slides.Presentation("malware.ppt", loadOptions);
try {
    // Realice operaciones en la presentación.
} finally {
    presentation.dispose();
}
```


## **Preguntas frecuentes**

**¿Cómo puedo saber si un archivo está dañado y no se puede abrir?**

Se producirá una excepción de validación de análisis/formato durante la carga. Estos errores a menudo mencionan una estructura ZIP no válida o registros de PowerPoint dañados.

**¿Qué ocurre si faltan fuentes requeridas al abrir?**

El archivo se abrirá, pero luego la [renderización/exportación](/slides/es/nodejs-java/convert-presentation/) puede sustituir fuentes. [Configura sustituciones de fuentes](/slides/es/nodejs-java/font-substitution/) o [agrega las fuentes requeridas](/slides/es/nodejs-java/custom-font/) al entorno de ejecución.

**¿Qué pasa con los medios incrustados (vídeo/audio) al abrir?**

Se convierten en recursos de la presentación. Si los medios se referencian mediante rutas externas, asegúrate de que esas rutas sean accesibles en tu entorno; de lo contrario, la [renderización/exportación](/slides/es/nodejs-java/convert-presentation/) puede omitir los medios.