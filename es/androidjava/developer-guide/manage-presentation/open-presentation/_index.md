---
title: Abrir presentaciones en Android
linktitle: Abrir presentación
type: docs
weight: 20
url: /es/androidjava/open-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Aprenda a abrir presentaciones PowerPoint y OpenDocument en Android, proporcionar contraseñas de apertura, controlar la carga de recursos y reducir el uso de memoria con Aspose.Slides para Android mediante Java."
---
## **Introducción**

[Aspose.Slides para Android vía Java](https://products.aspose.com/slides/es/androidjava/) puede cargar presentaciones PowerPoint y OpenDocument desde archivos y flujos. Después de cargar una presentación, puedes inspeccionar su estructura, editar diapositivas, gestionar recursos y guardarla en el formato original u otro formato compatible.

El comportamiento de carga se puede personalizar a través de la clase [LoadOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/loadoptions/). Por ejemplo, puedes proporcionar una contraseña de apertura, mantener objetos binarios grandes fuera de la memoria del heap de Java, controlar recursos externos u omitir datos binarios incrustados.

## **Abrir presentaciones**

Tras cargar un archivo o flujo, puedes [determinar su formato de presentación original](/slides/es/androidjava/detect-presentation-source-format/) para decidir cómo procesa tu aplicación.

Para abrir una presentación existente, pasa su ruta de archivo al constructor de [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/). Desecha la presentación después de usarla para que los manejadores de archivo, datos temporales y otros recursos se liberen rápidamente.

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

Una contraseña de apertura cifra el contenido de la presentación. Para cargar la presentación completa, pasa la contraseña correcta a [LoadOptions.setPassword](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) y proporciona las opciones al constructor de [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/). La carga falla cuando la contraseña falta o es incorrecta.

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

Para la detección de contraseñas, validación y flujos de trabajo de cifrado, consulta [Presentaciones protegidas con contraseña](/slides/es/androidjava/password-protected-presentation/). Si una presentación cifrada se guardó deliberadamente con propiedades de documento públicas, esas propiedades pueden leerse sin contraseña; ver [Gestionar propiedades de la presentación](/slides/es/androidjava/presentation-properties/).

## **Abrir presentaciones grandes**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) devuelve opciones que controlan cómo Aspose.Slides maneja objetos binarios grandes como imágenes, audio y vídeo. Puedes mantener el archivo fuente bloqueado, permitir archivos temporales y limitar la cantidad de datos BLOB retenidos en memoria.

El siguiente código Java demuestra cómo cargar una presentación grande (por ejemplo, 2 GB):

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
Con [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentationlockingbehavior/#KeepLocked), el archivo fuente permanece bloqueado hasta que la instancia de la presentación se deseche. No muevas, sobrescribas ni elimines el archivo fuente mientras esa instancia esté viva.

Aspose.Slides puede copiar el contenido de un flujo de entrada mientras lo carga. Para presentaciones grandes, una ruta de archivo suele ser más eficiente que un flujo. Consulta [Gestionar BLOBs](/slides/es/androidjava/manage-blob/) para opciones adicionales de almacenamiento y gestión de memoria.
{{% /alert %}}

## **Controlar recursos externos**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) acepta una implementación de [IResourceLoadingCallback](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iresourceloadingcallback/). La devolución de llamada puede proporcionar datos de reemplazo, redirigir un recurso, usar el cargador predeterminado o saltarse el recurso. Esto es útil cuando las presentaciones contienen imágenes externas que deben resolverse según reglas de seguridad o almacenamiento específicas de la aplicación.

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

Una presentación puede contener datos binarios incrustados que una aplicación no necesita o no quiere retener. Algunos ejemplos son:

- proyectos VBA, accesibles mediante [IPresentation.getVbaProject](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentation/#getVbaProject--);
- datos OLE incrustados, accesibles mediante [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--);
- datos de controles ActiveX, accesibles mediante [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--).

Configura [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) en `true` para eliminar estos datos binarios durante la carga. Guarda la presentación cargada para preservar el resultado sanitizado.

Esta opción reduce la exposición a cargas útiles incrustadas no deseadas, pero no constituye un sistema completo de detección de malware o sanitización de contenido.

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

**¿Cómo puedo saber si un archivo está corrupto y no se puede abrir?**

Aspose.Slides lanza una excepción de análisis o de formato durante la carga. Maneja ese error por separado del error de contraseña incorrecta para que la aplicación informe la causa con precisión.

**¿Qué ocurre si faltan fuentes requeridas?**

La presentación aún puede cargarse, pero la representación y la exportación pueden sustituir fuentes. Puedes [configurar la sustitución de fuentes](/slides/es/androidjava/font-substitution/) o [proporcionar fuentes personalizadas](/slides/es/androidjava/custom-font/) para que la salida sea más predecible.

**¿La carga de una presentación también carga sus medios incrustados?**

Los audio y vídeo incrustados quedan disponibles a través del modelo de objetos de la presentación. Los recursos externos se resuelven según el comportamiento de carga configurado y pueden no estar disponibles si sus ubicaciones no pueden ser accedidas.