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
- Formato Strict Office Open XML
- modo Zip64
- refrescar miniatura
- progreso de guardado
- Android
- Java
- Aspose.Slides
description: "Descubra cómo guardar presentaciones en Java usando Aspose.Slides para Android—exportar a PowerPoint u OpenDocument conservando diseños, fuentes y efectos."
---
## **Descripción general**

[Abrir presentaciones en Android](/slides/es/androidjava/open-presentation/) describe cómo usar la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/) para abrir una presentación. Este artículo explica cómo crear y guardar presentaciones. La clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/) contiene el contenido de una presentación. Tanto si crea una presentación desde cero como si modifica una existente, querrá guardarla cuando haya terminado. Con Aspose.Slides para Android, puede guardar en un **archivo** o **flujo**. Este artículo explica las diferentes formas de guardar una presentación.

## **Guardar presentaciones en archivos**

Guarde una presentación en un archivo llamando al método `save` de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/). Pase el nombre del archivo y el formato de guardado al método. El siguiente ejemplo muestra cómo guardar una presentación con Aspose.Slides.

```java
import com.aspose.slides.*;

// Instanciar la clase Presentation que representa un archivo de presentación.
Presentation presentation = new Presentation();
try {
    // Realizar alguna tarea aquí...

    // Guardar la presentación en un archivo.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Guardar presentaciones en flujos**

Puede guardar una presentación en un flujo pasando un flujo de salida al método `save` de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/). Una presentación puede escribirse en varios tipos de flujos. En el ejemplo siguiente, creamos una nueva presentación y la guardamos en un flujo de archivo.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.OutputStream;

// Instanciar la clase Presentation que representa un archivo de presentación.
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // Guardar la presentación en el flujo.
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Guardar presentaciones con un tipo de vista predefinido**

Aspose.Slides le permite establecer la vista inicial que PowerPoint usa cuando la presentación generada se abre mediante la clase [ViewProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/viewproperties/). Use el método [setLastView](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) con un valor de la enumeración [ViewType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/viewtype/).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Guardar presentaciones en el formato Strict Office Open XML**

Aspose.Slides le permite guardar una presentación en el formato Strict Office Open XML. Utilice la clase [PptxOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/pptxoptions/) y establezca su propiedad conformance al guardar. Si establece [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict), el archivo de salida se guarda en el formato Strict Office Open XML.

El ejemplo siguiente crea una presentación y la guarda en el formato Strict Office Open XML.

```java
import com.aspose.slides.*;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Instanciar la clase Presentation que representa un archivo de presentación.
Presentation presentation = new Presentation();
try {
    // Guardar la presentación en el formato Strict Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Guardar presentaciones en formato Office Open XML en modo Zip64**

Un archivo Office Open XML es un archivo ZIP que impone límites de 4 GB (2^32 bytes) en el tamaño sin comprimir de cualquier archivo, el tamaño comprimido de cualquier archivo y el tamaño total del archivo, y también limita el archivo a 65 535 (2^16‑1) archivos. Las extensiones de formato ZIP64 elevan estos límites a 2^64.

El método [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) le permite elegir cuándo usar extensiones de formato ZIP64 al guardar un archivo Office Open XML.

Este método puede usarse con los siguientes modos:

- [IfNecessary](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/zip64mode/#IfNecessary) usa extensiones de formato ZIP64 solo si la presentación supera las limitaciones anteriores. Este es el modo predeterminado.
- [Never](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/zip64mode/#Never) nunca usa extensiones de formato ZIP64.
- [Always](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/zip64mode/#Always) siempre usa extensiones de formato ZIP64.

El siguiente código demuestra cómo guardar una presentación como archivo PPTX con extensiones de formato ZIP64 habilitadas:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setZip64Mode(Zip64Mode.Always);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTA" color="warning" %}}
Al guardar con [Zip64Mode.Never](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/zip64mode/#Never), se lanza una [PptxException](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/pptxexception/) si la presentación no puede guardarse en formato ZIP32.
{{% /alert %}}

## **Guardar presentaciones en formato Office Open XML con niveles de compresión**

Al trabajar con presentaciones grandes, puede ajustar el nivel de compresión para equilibrar el tamaño del archivo y el tiempo de procesamiento. Según sus requisitos, puede preferir un procesamiento más rápido o archivos de salida más pequeños.

Aspose.Slides proporciona el método [IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-) que permite especificar el nivel de compresión utilizado al guardar una presentación en formato Office Open XML.

Los siguientes niveles de compresión están disponibles:

- **None**: No se aplica compresión. Los archivos se almacenan tal cual.
- **Level1**: La compresión más rápida con la relación de compresión más baja.
- **Level2**: Compresión más rápida con una relación de compresión ligeramente mejor que **Level1**.
- **Level3**: Ofrece mejor compresión que **Level2** con un impacto moderado en el tiempo de procesamiento.
- **Level4**: Ofrece mejor compresión que **Level3**.
- **Level5**: Ofrece una compresión mejorada respecto a **Level4** con tiempo de procesamiento adicional.
- **Level6**: Compresión estándar que ofrece un buen equilibrio entre velocidad de procesamiento y tamaño de archivo. Este es el *nivel de compresión predeterminado*.
- **Level7**: Ofrece mejor compresión que **Level6** con un procesamiento más lento.
- **Level8**: Ofrece mejor compresión que **Level7**.
- **Level9**: Compresión máxima. Produce el archivo de menor tamaño a costa del mayor tiempo de procesamiento.

El siguiente ejemplo demuestra cómo guardar una presentación como archivo PPTX *sin compresión*:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.None);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

Este ejemplo muestra cómo guardar una presentación como archivo PPTX con *compresión máxima*:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.Level9);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **Guardar presentaciones sin refrescar la miniatura**

El método [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) controla la generación de miniaturas al guardar una presentación en PPTX:

- Si se establece a `true`, la miniatura se refresca durante el guardado. Este es el valor predeterminado.
- Si se establece a `false`, se conserva la miniatura actual. Si la presentación no tiene miniatura, no se genera ninguna.

En el código siguiente, la presentación se guarda en PPTX sin refrescar su miniatura.

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setRefreshThumbnail(false);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Información" color="info" %}}
Esta opción ayuda a reducir el tiempo necesario para guardar una presentación en formato PPTX.
{{% /alert %}}

## **Guardar actualizaciones de progreso en porcentaje**

La interfaz [IProgressCallback](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iprogresscallback/) se utiliza mediante el método `setProgressCallback` expuesto por la interfaz [ISaveOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isaveoptions/) y la clase abstracta [SaveOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/saveoptions/). Asigne una implementación de [IProgressCallback] con `setProgressCallback` para recibir actualizaciones del progreso de guardado como porcentaje.

Los fragmentos de código siguientes muestran cómo usar `IProgressCallback`.

```java
import com.aspose.slides.*;

ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```
```java
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // Utilice el valor de porcentaje de progreso aquí.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Información" color="info" %}}
Aspose ha desarrollado una [aplicación gratuita PowerPoint Splitter](https://products.aspose.app/slides/es/splitter) usando su propia API. La aplicación le permite dividir una presentación en varios archivos guardando diapositivas seleccionadas como nuevos archivos PPTX o PPT.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Se admite el “guardado rápido” (guardado incremental) para que sólo se escriban los cambios?**

No. Cada vez que se guarda se crea el archivo completo; el guardado incremental “rápido” no está soportado.

**¿Es seguro guardar la misma instancia de Presentation desde varios hilos?**

No. Una instancia de [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/) [no es segura para subprocesos](/slides/es/androidjava/multithreading/); guárdela desde un solo hilo.

**¿Qué ocurre con los hipervínculos y los archivos enlazados externamente al guardar?**

[Hyperlinks](/slides/es/androidjava/manage-hyperlinks/) se conservan. Los archivos enlazados externamente (p. ej., vídeos mediante rutas relativas) no se copian automáticamente; asegúrese de que las rutas referenciadas sigan siendo accesibles.

**¿Puedo establecer/guardar metadatos del documento (Autor, Título, Empresa, Fecha)?**

Sí. Las [propiedades de documento](/slides/es/androidjava/presentation-properties/) estándar son compatibles y se escribirán en el archivo al guardarlo.