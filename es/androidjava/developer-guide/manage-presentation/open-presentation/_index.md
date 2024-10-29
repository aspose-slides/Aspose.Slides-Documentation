---
title: Abrir Presentación en Java
linktitle: Abrir Presentación
type: docs
weight: 20
url: /es/androidjava/open-presentation/
keywords: "Abrir PowerPoint, PPTX, PPT, Abrir Presentación, Cargar Presentación, Java"
description: "Abrir o cargar Presentación PPT, PPTX, ODP en Java"
---

Además de crear presentaciones de PowerPoint desde cero, Aspose.Slides te permite abrir presentaciones existentes. Después de cargar una presentación, puedes obtener información sobre la presentación, editar la presentación (el contenido en sus diapositivas), agregar nuevas diapositivas o eliminar las existentes, etc.

## Abrir Presentación

Para abrir una presentación existente, simplemente tienes que instanciar la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) y pasar la ruta del archivo (de la presentación que deseas abrir) a su constructor.

Este código Java te muestra cómo abrir una presentación y también averiguar cuántas diapositivas contiene:

```java
// Instancia la clase Presentation y pasa la ruta del archivo a su constructor
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Imprime el número total de diapositivas presentes en la presentación
    System.out.println(pres.getSlides().size());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Abrir Presentación Protegida por Contraseña**

Cuando tienes que abrir una presentación protegida por contraseña, puedes pasar la contraseña a través de la propiedad [Password](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#getPassword--) (de la clase [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/)) para desencriptar la presentación y cargar la presentación. Este código Java demuestra la operación:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("TU_CONTRASEÑA");
Presentation pres = new Presentation("pres.pptx", loadOptions);
try {
    // Haz algún trabajo con la presentación desencriptada
} finally {
    if (pres != null) pres.dispose();
}
```

## Abrir Presentación Grande

Aspose.Slides proporciona opciones (la propiedad [BlobManagementOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setBlobManagementOptions-com.aspose.slides.IBlobManagementOptions-) en particular) bajo la clase [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions) para permitirte cargar presentaciones grandes.

Este código Java demuestra una operación en la que se carga una presentación grande (digamos de 2GB de tamaño):

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(0L);

Presentation pres = new Presentation("veryLargePresentation.pptx", loadOptions);
try {
    // La presentación grande ha sido cargada y puede ser utilizada, pero el consumo de memoria sigue siendo bajo.
    // realiza cambios en la presentación.
    pres.getSlides().get_Item(0).setName("Presentación muy grande");

    // La presentación se guardará en el otro archivo. El consumo de memoria permanece bajo durante la operación
    pres.save("veryLargePresentation-copy.pptx", SaveFormat.Pptx);
} finally {
    if(pres != null) pres.dispose();
}
```

{{% alert color="info" title="Información" %}}

Para eludir ciertas limitaciones al interactuar con un flujo, Aspose.Slides puede copiar el contenido del flujo. Cargar una presentación grande a través de su flujo resultará en la copia de los contenidos de la presentación y causará una carga lenta. Por lo tanto, cuando tengas la intención de cargar una presentación grande, te recomendamos encarecidamente que utilices la ruta del archivo de la presentación y no su flujo.

Cuando deseas crear una presentación que contenga objetos grandes (video, audio, imágenes grandes, etc.), puedes usar la [facilidad de Blob](https://docs.aspose.com/slides/androidjava/manage-blob/) para reducir el consumo de memoria.

{{%/alert %}} 

## Cargar Presentación

Aspose.Slides proporciona [IResourceLoadingCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iresourceloadingcallback/) con un único método para permitirte gestionar recursos externos. Este código Java te muestra cómo utilizar la interfaz `IResourceLoadingCallback`:

```java
LoadOptions opts = new LoadOptions();
opts.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation pres = new Presentation("presentation.pptx", opts);
```

```java
class ImageLoadingHandler implements IResourceLoadingCallback 
{
    public int resourceLoading(IResourceLoadingArgs args) 
    {
        if (args.getOriginalUri().endsWith(".jpg")) 
        {
            try // carga una imagen de sustitución
            {
                byte[] imageBytes = Files.readAllBytes(new File("aspose-logo.jpg").toPath());
                args.setData(imageBytes);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // establece una url de sustitución
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // omite todas las demás imágenes
        return ResourceLoadingAction.Skip;
    }
}
```

## Cargar Presentación Sin Objetos Binarios Embebidos

La presentación de PowerPoint puede contener los siguientes tipos de objetos binarios embebidos:

- Proyecto VBA ([IPresentation.VbaProject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/vbaproject/));
- Datos embebidos de objeto OLE ([IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- Datos binarios de control ActiveX ([IControl.ActiveXControlBinary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--));

Usando la propiedad [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-), puedes cargar la presentación sin ningún objeto binario embebido.

Esta propiedad puede ser útil para eliminar contenido binario potencialmente malicioso.

El código demuestra cómo cargar y guardar una presentación sin contenido de malware:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation pres = new Presentation("malware.ppt", loadOptions);
try {
    pres.save("clean.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## Abrir y Guardar Presentación

Pasos para Abrir y Guardar Presentación:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) y pasa el archivo que deseas abrir.
2. Guarda la presentación.  

```java
// Instancia un objeto Presentation que representa un archivo PPT
Presentation pres = new Presentation();
try {
    // ...haz algún trabajo aquí...
    
    // Guarda tu presentación en un archivo
    pres.save("demoPass.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    if(pres != null) pres.dispose();
}
```