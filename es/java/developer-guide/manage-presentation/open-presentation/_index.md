---
title: Abrir presentaciones en Java
linktitle: Abrir presentación
type: docs
weight: 20
url: /es/java/open-presentation/
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
- Java
- Aspose.Slides
description: "Aprenda cómo abrir presentaciones PowerPoint y OpenDocument en Java, proporcionar contraseñas de apertura, controlar la carga de recursos y reducir el uso de memoria con Aspose.Slides para Java."
---
## **Introducción**

[Aspose.Slides for Java](https://products.aspose.com/slides/es/java/) puede cargar presentaciones PowerPoint y OpenDocument desde archivos y flujos. Después de que una presentación se haya cargado, puede inspeccionar su estructura, editar diapositivas, gestionar recursos y guardarla en el formato original o en otro formato compatible.

El comportamiento de carga puede personalizarse mediante la clase [LoadOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/loadoptions/). Por ejemplo, puede proporcionar una contraseña de apertura, mantener los objetos binarios grandes fuera de la memoria heap de Java, controlar los recursos externos o omitir los datos binarios incrustados.

## **Abrir presentaciones**

Para abrir una presentación existente, pase su ruta de archivo al constructor [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/). Libere la presentación después de usarla para que los manejadores de archivo, los datos temporales y otros recursos se liberen rápidamente.

El siguiente ejemplo en Java muestra cómo abrir una presentación y obtener el número de diapositivas:

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Abrir presentaciones protegidas con contraseña**

Una contraseña de apertura cifra el contenido de la presentación. Para cargar la presentación completa, pase la contraseña correcta a [LoadOptions.setPassword](https://reference.aspose.com/slides/es/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) y proporcione las opciones al constructor [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/). La carga falla cuando la contraseña falta o es incorrecta.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-presentation.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Para flujos de trabajo de detección, validación y cifrado de contraseñas, consulte [Password-Protect Presentations](/slides/es/java/password-protected-presentation/). Si una presentación cifrada se guardó deliberadamente con propiedades de documento públicas, esas propiedades pueden leerse sin contraseña; consulte [Manage Presentation Properties](/slides/es/java/presentation-properties/).

## **Abrir presentaciones grandes**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) devuelve opciones que controlan cómo Aspose.Slides maneja los objetos binarios grandes (BLOB) como imágenes, audio y vídeo. Puede mantener el archivo fuente bloqueado, permitir archivos temporales y limitar la cantidad de datos BLOB retenidos en memoria.

El siguiente código Java muestra cómo cargar una presentación grande (por ejemplo, 2 GB):

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationLockingBehavior;
import com.aspose.slides.SaveFormat;

final String filePath = "large-presentation.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Nota" %}}
Con [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentationlockingbehavior/#KeepLocked), el archivo fuente permanece bloqueado hasta que se libere la instancia de presentación. No mueva, sobrescriba ni elimine el archivo fuente mientras esa instancia esté activa.

Aspose.Slides puede copiar el contenido de un flujo de entrada durante la carga. Para presentaciones grandes, una ruta de archivo suele ser más eficiente que un flujo. Consulte [Manage BLOBs](/slides/es/java/manage-blob/) para opciones adicionales de almacenamiento y gestión de memoria.
{{% /alert %}}

## **Controlar recursos externos**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/es/java/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) acepta una implementación de [IResourceLoadingCallback](https://reference.aspose.com/slides/es/java/com.aspose.slides/iresourceloadingcallback/). La devolución de llamada puede proporcionar datos de reemplazo, redirigir un recurso, usar el cargador predeterminado o omitir el recurso. Esto es útil cuando las presentaciones contienen imágenes externas que deben resolverse según reglas de seguridad o almacenamiento específicas de la aplicación.

```java
import com.aspose.slides.IResourceLoadingArgs;
import com.aspose.slides.IResourceLoadingCallback;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.ResourceLoadingAction;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        boolean isJpeg = args.getOriginalUri().toLowerCase(Locale.ROOT).endsWith(".jpg");
        Path approvedImagePath = Paths.get("approved-image.jpg");
        if (!isJpeg || !Files.exists(approvedImagePath)) {
            return ResourceLoadingAction.Skip;
        }

        try {
            byte[] imageData = Files.readAllBytes(approvedImagePath);
            args.setData(imageData);
            return ResourceLoadingAction.UserProvided;
        } catch (IOException exception) {
            System.err.println("The approved replacement image could not be read.");
            return ResourceLoadingAction.Skip;
        }
    }
}

LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Cargar presentaciones sin objetos binarios incrustados**

Una presentación puede contener datos binarios incrustados que una aplicación no necesita o no desea conservar. Ejemplos incluyen:

- Proyectos VBA, disponibles a través de [IPresentation.getVbaProject](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipresentation/#getVbaProject--);
- Datos OLE incrustados, disponibles a través de [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/es/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--);
- Datos de controles ActiveX, disponibles a través de [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/es/java/com.aspose.slides/icontrol/#getActiveXControlBinary--).

Establezca [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/es/java/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) en `true` para eliminar estos datos binarios durante la carga. Guarde la presentación cargada para conservar el resultado saneado.

Esta opción reduce la exposición a cargas útiles incrustadas no deseadas, pero no constituye un sistema completo de detección de malware o saneamiento de contenido.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿Cómo puedo saber que un archivo está corrupto y no se puede abrir?**

Aspose.Slides lanza una excepción de análisis o de formato durante la carga. Maneje ese fallo por separado de un error de contraseña incorrecta para que la aplicación pueda informar la causa con precisión.

**¿Qué ocurre si faltan fuentes requeridas?**

La presentación aún puede cargarse, pero la renderización y exportación pueden sustituir fuentes. Puede [configurar sustitución de fuentes](/slides/es/java/font-substitution/) o [proporcionar fuentes personalizadas](/slides/es/java/custom-font/) para que la salida sea más predecible.

**¿La carga de una presentación también carga sus medios incrustados?**

El audio y vídeo incrustados están disponibles a través del modelo de objetos de la presentación. Los recursos externos se resuelven según el comportamiento de carga de recursos configurado y pueden no estar disponibles si sus ubicaciones no pueden ser accedidas.