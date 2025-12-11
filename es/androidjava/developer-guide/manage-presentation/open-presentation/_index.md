---
title: Abrir presentaciones en Android
linktitle: Abrir presentación
type: docs
weight: 20
url: /es/androidjava/open-presentation/
keywords:
- abrir PowerPoint
- abrir OpenDocument
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
- Android
- Java
- Aspose.Slides
description: "Abra presentaciones PowerPoint (.pptx, .ppt) y OpenDocument (.odp) sin esfuerzo con Aspose.Slides para Android mediante Java: rápido, fiable y con todas las funciones."
---

## **Descripción general**

Además de crear presentaciones de PowerPoint desde cero, Aspose.Slides también le permite abrir presentaciones existentes. Después de cargar una presentación, puede obtener información sobre ella, editar el contenido de las diapositivas, agregar nuevas diapositivas, eliminar las existentes y mucho más.

## **Abrir presentaciones**

Para abrir una presentación existente, instancie la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) y pase la ruta del archivo a su constructor.

El siguiente ejemplo en Java muestra cómo abrir una presentación y obtener el recuento de diapositivas:
```java
// Instanciar la clase Presentation y pasar una ruta de archivo a su constructor.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Imprimir el número total de diapositivas en la presentación.
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```


## **Abrir presentaciones protegidas con contraseña**

Cuando necesite abrir una presentación protegida con contraseña, pase la contraseña mediante el método [setPassword](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) de la clase [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) para descifrarla y cargarla. El siguiente código Java muestra esta operación:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
try {
    // Realizar operaciones en la presentación descifrada.
} finally {
    presentation.dispose();
}
```


## **Abrir presentaciones grandes**

Aspose.Slides ofrece opciones—en particular el método [getBlobManagementOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) en la clase [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/)—para ayudarle a cargar presentaciones grandes.

El siguiente código Java muestra cómo cargar una presentación grande (por ejemplo, 2 GB):
```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// Elija el comportamiento KeepLocked: el archivo de la presentación permanecerá bloqueado durante la vida útil de
// la instancia Presentation, pero no es necesario cargarla en memoria ni copiarla a un archivo temporal.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // La gran presentación se ha cargado y puede usarse, mientras el consumo de memoria se mantiene bajo.

    // Realice cambios en la presentación.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Guarde la presentación en otro archivo. El consumo de memoria se mantiene bajo durante esta operación.
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // ¡No haga esto! Se lanzará una excepción de E/S porque el archivo está bloqueado hasta que se libere el objeto Presentation.
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// Está bien hacerlo aquí. El archivo de origen ya no está bloqueado por el objeto Presentation.
Files.delete(Paths.get(filePath));
```


{{% alert color="info" title="Info" %}}
Para sortear ciertas limitaciones al trabajar con flujos, Aspose.Slides puede copiar el contenido de un flujo. Cargar una presentación grande desde un flujo hace que la presentación se copie y puede ralentizar la carga. Por lo tanto, cuando necesite cargar una presentación grande, recomendamos encarecidamente usar la ruta del archivo de la presentación en lugar de un flujo.

Al crear una presentación que contiene objetos grandes (vídeo, audio, imágenes de alta resolución, etc.), puede utilizar la [gestión de BLOB](/slides/es/androidjava/manage-blob/) para reducir el consumo de memoria.
{{%/alert %}}

## **Controlar recursos externos**

Aspose.Slides ofrece la interfaz [IResourceLoadingCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iresourceloadingcallback/) que le permite gestionar recursos externos. El siguiente código Java muestra cómo usar la interfaz `IResourceLoadingCallback`:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```java
class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // Cargar una imagen de sustitución.
                byte[] imageData = getImageBytes("aspose-logo.jpg"); // Utilice cualquier método para obtener los bytes
                args.setData(imageData);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // Establecer una URL de sustitución.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // Omitir todas las demás imágenes.
        return ResourceLoadingAction.Skip;
    }
}
```


## **Cargar presentaciones sin objetos binarios incrustados**

Una presentación de PowerPoint puede contener los siguientes tipos de objetos binarios incrustados:

- Proyecto VBA (accesible a través de [IPresentation.getVbaProject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getVbaProject--));
- Datos incrustados de objeto OLE (accesibles a través de [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- Datos binarios de control ActiveX (accesibles a través de [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--)).

Utilizando el método [ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) puede cargar una presentación sin objetos binarios incrustados.

Este método es útil para eliminar contenido binario potencialmente malicioso. El siguiente código Java muestra cómo cargar una presentación sin ningún contenido binario incrustado:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("malware.ppt", loadOptions);
try {
    // Realizar operaciones en la presentación.
} finally {
    presentation.dispose();
}
```


## **Preguntas frecuentes**

**¿Cómo puedo saber si un archivo está corrupto y no se puede abrir?**

Recibirá una excepción de validación de análisis/formato durante la carga. Estos errores a menudo mencionan una estructura ZIP no válida o registros de PowerPoint dañados.

**¿Qué ocurre si faltan fuentes requeridas al abrir?**

El archivo se abrirá, pero luego la [renderización/exportación](/slides/es/androidjava/convert-presentation/) puede sustituir fuentes. [Configure sustituciones de fuentes](/slides/es/androidjava/font-substitution/) o [agregue las fuentes requeridas](/slides/es/androidjava/custom-font/) al entorno de ejecución.

**¿Qué ocurre con los medios incrustados (vídeo/audio) al abrir?**

Se convierten en recursos de la presentación. Si los medios se referencian mediante rutas externas, asegúrese de que esas rutas sean accesibles en su entorno; de lo contrario, la [renderización/exportación](/slides/es/androidjava/convert-presentation/) puede omitir los medios.