---
title: Guardar presentaciones en Android
linktitle: Guardar presentación
type: docs
weight: 80
url: /es/androidjava/save-presentation/
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
- actualizar miniatura
- progreso de guardado
- Android
- Java
- Aspose.Slides
description: "Guardar presentaciones PowerPoint y OpenDocument en archivos o flujos en Android con Aspose.Slides, y configurar la salida PPTX y el informe de progreso."
---
## **Visión general**

Después de crear una presentación o [abrir una existente](/slides/es/androidjava/open-presentation/), utilice el método [Presentation.save](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) para escribir el resultado. Aspose.Slides for Android mediante Java puede guardar una presentación en un archivo o flujo en formatos PowerPoint, OpenDocument, PDF y otros. Las siguientes secciones cubren las operaciones estándar de guardado y las opciones disponibles para la salida PPTX.

## **Guardar presentaciones en archivos**

Para guardar una presentación en un archivo, pase la ruta de salida y un valor de [SaveFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/saveformat/) al método [Presentation.save](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). El valor del formato determina el tipo de archivo que Aspose.Slides crea.

El siguiente ejemplo crea una presentación y la guarda como archivo PPTX:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    // Añadir o modificar el contenido de la presentación aquí.

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Guardar presentaciones en su formato original**

Para ejemplos de detección de archivos y flujos, el comportamiento de presentaciones recién creadas y la distinción entre formatos de origen y salida, consulte [Determine the Original Presentation Format](/slides/es/androidjava/detect-presentation-source-format/).

En una aplicación de procesamiento por lotes, el formato de entrada puede no conocerse de antemano. Después de cargar un archivo, lea su formato original mediante el método [IPresentation.getSourceFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--) . Pase el valor resultante de [SourceFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/sourceformat/) a [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-) para obtener el valor correspondiente de [SaveFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/saveformat/) y, a continuación, use [Presentation.save](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) para escribir la presentación modificada.

El siguiente ejemplo completo procesa cada archivo en un directorio de entrada, actualiza su título y lo guarda en un directorio de salida en el formato desde el que se cargó:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SlideUtil;
import java.io.File;

File inputDirectory = new File("Input");
File outputDirectory = new File("Output");

if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    System.err.println("Cannot create the output directory.");
}

File[] inputFiles = inputDirectory.listFiles(File::isFile);
if (inputFiles != null && outputDirectory.isDirectory()) {
    for (File inputFile : inputFiles) {
        try {
            Presentation presentation = new Presentation(inputFile.getPath());
            try {
                int saveFormat = SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                File outputFile = new File(outputDirectory, inputFile.getName());
                presentation.save(outputFile.getPath(), saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (IllegalArgumentException exception) {
            System.err.println("Cannot map the source format of '" + inputFile.getPath() + "': " + exception.getMessage());
        } catch (Exception exception) {
            System.err.println("Cannot process '" + inputFile.getPath() + "': " + exception.getMessage());
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-) asigna PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP y PowerPoint XML a sus formatos de guardado de presentación correspondientes. Sólo asigna formatos de origen de presentación; no está destinado a seleccionar formatos de exportación como PDF, HTML, TIFF o imágenes. Pasar un valor de [SourceFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/sourceformat/) no compatible o inválido genera una [IllegalArgumentException](https://developer.android.com/reference/java/lang/IllegalArgumentException).

Los archivos heredados PPT, PPS y POT utilizan el mismo contenedor binario. Cuando una presentación de este tipo se carga desde un flujo sin extensión de archivo, un archivo PPS o POT puede identificarse como PPT. Si es necesario conservar estos subtipos heredados, conserve el nombre de archivo original o los metadatos de formato por separado y utilícelos al escoger el nombre de archivo y formato de salida.

## **Guardar presentaciones en flujos**

Para escribir una presentación sin depender de una ruta de archivo final, pase un flujo de escritura y un valor de [SaveFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/saveformat/) al método [Presentation.save](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Este enfoque es útil cuando la salida debe devolverse desde un servicio web, almacenarse en una base de datos o procesarse en memoria.

El siguiente ejemplo guarda una nueva presentación en un flujo de archivo:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.FileOutputStream;
import java.io.OutputStream;

Presentation presentation = new Presentation();
try {
    OutputStream outputStream = new FileOutputStream("Output.pptx");
    try {
        presentation.save(outputStream, SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Guardar presentaciones con un tipo de vista predefinido**

Puede especificar la vista en la que PowerPoint abre inicialmente una presentación guardada. Utilice el método [ViewProperties.setLastView](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) con un valor de [ViewType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/viewtype/) antes de guardar.

El siguiente ejemplo configura la vista Maestro de diapositivas como vista inicial:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Guardar presentaciones en el formato estricto Office Open XML**

Para crear un archivo PPTX que cumpla el perfil Strict de Office Open XML, cree una instancia de [PptxOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/pptxoptions/) y utilice su método [setConformance](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/pptxoptions/#setConformance-int-) con [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict). Luego pase las opciones al método [Presentation.save](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) .

```java
import com.aspose.slides.Conformance;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

Presentation presentation = new Presentation();
try {
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Guardar presentaciones en Office Open XML en modo Zip64**

Un archivo ZIP estándar limita el tamaño comprimido y sin comprimir de cada entrada, el tamaño total del archivo y el número de entradas. Dado que un archivo PPTX es un archivo ZIP, una presentación muy grande puede superar esos límites. Las extensiones ZIP64 elevan los límites de tamaño y de número de entradas aplicables.

Utilice el método [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/pptxoptions/#setZip64Mode-int-) para controlar si Aspose.Slides escribe extensiones ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/zip64mode/#IfNecessary) usa ZIP64 sólo cuando la presentación supera los límites ZIP estándar. Este es el modo predeterminado.
- [Never](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/zip64mode/#Never) desactiva las extensiones ZIP64.
- [Always](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/zip64mode/#Always) siempre escribe extensiones ZIP64.

El siguiente ejemplo siempre habilita extensiones ZIP64 para la presentación de salida:

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.Zip64Mode;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setZip64Mode(Zip64Mode.Always);

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Si se usa [Zip64Mode.Never](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/zip64mode/#Never) y la presentación no cabe dentro de los límites ZIP estándar, la operación de guardado lanza una [PptxException](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/pptxexception/) .
{{% /alert %}}

## **Guardar presentaciones en Office Open XML con niveles de compresión**

Para la salida PPTX, puede equilibrar la velocidad de guardado contra el tamaño del archivo usando el método [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/pptxoptions/#setCompressionLevel-int-) . La clase [CompressionLevel](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/compressionlevel/) proporciona estos valores:

- [None](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/compressionlevel/#None) almacena los datos sin compresión.
- [Level1](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/compressionlevel/#Level1) ofrece la compresión más rápida y el archivo comprimido más grande.
- [Level2](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/compressionlevel/#Level2) hasta [Level5](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/compressionlevel/#Level5) favorecen progresivamente una salida más pequeña sobre la velocidad de guardado.
- [Level6](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/compressionlevel/#Level6) equilibra velocidad de guardado y tamaño de archivo. Este es el nivel predeterminado.
- [Level7](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/compressionlevel/#Level7) y [Level8](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/compressionlevel/#Level8) favorecen aún más una salida más pequeña sobre la velocidad de guardado.
- [Level9](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/compressionlevel/#Level9) proporciona la compresión más fuerte y requiere más tiempo de procesamiento.

El siguiente ejemplo guarda una presentación sin compresión:

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.None);

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

El siguiente ejemplo utiliza el nivel máximo de compresión:

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.Level9);

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Guardar presentaciones sin actualizar la miniatura**

Cuando una presentación se guarda como PPTX, el método [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) controla la miniatura del documento:

- `true` regenera la miniatura durante la operación de guardado. Este es el valor predeterminado.
- `false` conserva la miniatura existente. Si la presentación no tiene miniatura, Aspose.Slides no genera una.

El siguiente ejemplo guarda una presentación sin actualizar su miniatura:

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("Output.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Desactivar la actualización de la miniatura puede reducir el tiempo necesario para guardar un archivo PPTX.
{{% /alert %}}

## **Actualizaciones de progreso de guardado en porcentaje**

Para supervisar una operación de guardado, implemente la interfaz [IProgressCallback](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iprogresscallback/) y pase la implementación al método [ISaveOptions.setProgressCallback](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isaveoptions/#setProgressCallback-com.aspose.slides.IProgressCallback-) . Aspose.Slides entonces llama al método [IProgressCallback.reporting](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iprogresscallback/#reporting-double-) con valores de progreso durante la exportación.

El siguiente ejemplo informa del progreso de una exportación a PDF en la consola:

```java
import com.aspose.slides.IProgressCallback;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        int progress = (int) progressValue;
        System.out.println(progress + "% of the file has been converted.");
    }
}

PdfOptions options = new PdfOptions();
options.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose ofrece un [PowerPoint Splitter](https://products.aspose.app/slides/es/splitter) gratuito creado con la API Aspose.Slides. Guarda diapositivas seleccionadas de una presentación como archivos PPT o PPTX independientes.
{{% /alert %}}

## **FAQ**

**¿Aspose.Slides admite guardado incremental o “fast save”?**

No. Cada operación de guardado escribe un archivo de salida completo en lugar de actualizar sólo las partes modificadas.

**¿Pueden varios hilos guardar la misma instancia de Presentation?**

No. Una instancia de [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/) **no es segura para subprocesos** (/slides/es/androidjava/multithreading/). Acceda y guarde cada instancia desde un solo hilo a la vez.

**¿Qué ocurre con los hipervínculos y los archivos vinculados externamente cuando guardo una presentación?**

Los [hipervínculos](/slides/es/androidjava/manage-hyperlinks/) permanecen en la presentación. Aspose.Slides no copia los archivos vinculados externamente, por lo que la presentación guardada debe seguir pudiendo acceder a sus ubicaciones.

**¿Puedo guardar metadatos del documento como autor, título, empresa y fecha de creación?**

Sí. Defina las [propiedades del documento](/slides/es/androidjava/presentation-properties/) apropiadas antes de guardar, y Aspose.Slides las escribe en el archivo de salida.