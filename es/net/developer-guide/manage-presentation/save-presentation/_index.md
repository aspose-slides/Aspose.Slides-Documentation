---
title: Guardar presentaciones en .NET
linktitle: Guardar presentación
type: docs
weight: 80
url: /es/net/save-presentation/
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
- Formato estricto Office Open XML
- modo Zip64
- refrescar miniatura
- progreso de guardado
- .NET
- C#
- Aspose.Slides
description: "Guardar presentaciones PowerPoint y OpenDocument en archivos o flujos en C# con Aspose.Slides para .NET, y configurar la salida PPTX y el informe de progreso."
---
## **Visión general**

Después de crear una presentación o [abrir una existente](/slides/es/net/open-presentation/), utilice el método [Presentation.Save](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/save/) para escribir el resultado. Aspose.Slides para .NET puede guardar una presentación en un archivo o flujo en formatos PowerPoint, OpenDocument, PDF y otros. Las siguientes secciones cubren las operaciones de guardado estándar y las opciones disponibles para la salida PPTX.

## **Guardar presentaciones en archivos**

Para guardar una presentación en un archivo, pase la ruta de salida y un valor de [SaveFormat](https://reference.aspose.com/slides/es/net/aspose.slides.export/saveformat/) al método [Presentation.Save](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/save/). El valor del formato determina el tipo de archivo que Aspose.Slides crea.

El siguiente ejemplo crea una presentación y la guarda como un archivo PPTX:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

// Add or modify presentation content here.

presentation.Save("Output.pptx", SaveFormat.Pptx);
```

## **Guardar presentaciones en su formato original**

Para ejemplos de detección de archivo y flujo, el comportamiento de presentaciones recién creadas y la distinción entre formatos de origen y salida, consulte [Determinar el formato original de la presentación](/slides/es/net/detect-presentation-source-format/).

En una aplicación de procesamiento por lotes, el formato de entrada puede no ser conocido de antemano. Después de cargar un archivo, lea su formato original desde la propiedad [IPresentation.SourceFormat](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentation/sourceformat/). Pase el valor resultante de [SourceFormat](https://reference.aspose.com/slides/es/net/aspose.slides/sourceformat/) a [SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/es/net/aspose.slides.util/slideutil/tosaveformat/) para obtener el valor correspondiente de [SaveFormat](https://reference.aspose.com/slides/es/net/aspose.slides.export/saveformat/), y luego use [Presentation.Save](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/save/) para escribir la presentación modificada.

El siguiente ejemplo completo procesa cada archivo en un directorio de entrada, actualiza su título y lo guarda en un directorio de salida en el formato desde el que se cargó:

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Util;

var inputDirectory = "Input";
var outputDirectory = "Output";

Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory))
{
    try
    {
        using var presentation = new Presentation(inputPath);

        var sourceFormat = presentation.SourceFormat;
        var saveFormat = SlideUtil.ToSaveFormat(sourceFormat);

        presentation.DocumentProperties.Title = "Processed by the batch application";

        var outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));
        presentation.Save(outputPath, saveFormat);
    }
    catch (ArgumentException exception)
    {
        Console.Error.WriteLine($"Cannot map the source format of '{inputPath}': {exception.Message}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Cannot process '{inputPath}': {exception.Message}");
    }
}
```

[SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/es/net/aspose.slides.util/slideutil/tosaveformat/) asigna PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP y PowerPoint XML a sus formatos de guardado de presentación correspondientes. Solo asigna formatos de origen de presentación; no está destinado a seleccionar formatos de exportación como PDF, HTML, TIFF o imágenes. Pasar un valor de [SourceFormat](https://reference.aspose.com/slides/es/net/aspose.slides/sourceformat/) no admitido o inválido produce una [ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception).

Los archivos heredados PPT, PPS y POT utilizan el mismo contenedor binario. Cuando una presentación de este tipo se carga desde un flujo sin extensión de archivo, un archivo PPS o POT puede identificarse como PPT. Si es necesario conservar estos subtipos heredados, retenga el nombre de archivo original o los metadatos de formato por separado y úselos al elegir el nombre y formato de salida.

## **Guardar presentaciones en flujos**

Para escribir una presentación sin depender de una ruta de archivo final, pase un [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream) writable y un valor de [SaveFormat](https://reference.aspose.com/slides/es/net/aspose.slides.export/saveformat/) al método [Presentation.Save](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/save/). Este enfoque es útil cuando la salida debe devolverse desde un servicio web, almacenarse en una base de datos o procesarse en memoria.

El siguiente ejemplo guarda una presentación nueva en un flujo de archivo:

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
using var outputStream = new FileStream("Output.pptx", FileMode.Create);

presentation.Save(outputStream, SaveFormat.Pptx);
```

## **Guardar presentaciones con un tipo de vista predefinido**

Puede especificar la vista en la que PowerPoint abre inicialmente una presentación guardada. Establezca la propiedad [ViewProperties.LastView](https://reference.aspose.com/slides/es/net/aspose.slides/viewproperties/lastview/) a un valor de [ViewType](https://reference.aspose.com/slides/es/net/aspose.slides/viewtype/) antes de guardar.

El siguiente ejemplo configura la vista Maestro de diapositivas como vista inicial:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
```

## **Guardar presentaciones en el formato estricto Office Open XML**

Para crear un archivo PPTX que cumpla con el perfil Strict de Office Open XML, cree una instancia de [PptxOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/pptxoptions/) y establezca su propiedad [Conformance](https://reference.aspose.com/slides/es/net/aspose.slides.export/pptxoptions/conformance/) en `Conformance.Iso29500_2008_Strict`. Luego pase las opciones al método [Presentation.Save](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/save/).

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PptxOptions
{
    Conformance = Conformance.Iso29500_2008_Strict
};

using var presentation = new Presentation();

presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
```

## **Guardar presentaciones en formato Office Open XML en modo Zip64**

Un archivo ZIP estándar limita el tamaño comprimido y descomprimido de cada entrada, el tamaño total del archivo y el número de entradas. Dado que un archivo PPTX es un archivo ZIP, una presentación muy grande puede superar esos límites. Las extensiones ZIP64 aumentan los límites de tamaño y de número de entradas aplicables.

Utilice la propiedad [PptxOptions.Zip64Mode](https://reference.aspose.com/slides/es/net/aspose.slides.export/pptxoptions/zip64mode/) para controlar si Aspose.Slides escribe extensiones ZIP64:

- `IfNecessary` utiliza ZIP64 solo cuando la presentación supera los límites ZIP estándar. Este es el modo predeterminado.
- `Never` desactiva las extensiones ZIP64.
- `Always` siempre escribe extensiones ZIP64.

El siguiente ejemplo siempre habilita las extensiones ZIP64 para la presentación de salida:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    Zip64Mode = Zip64Mode.Always
};

presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, options);
```

{{% alert color="warning" title="Warning" %}}

If `Zip64Mode` is set to `Never` and the presentation cannot fit within standard ZIP limits, the save operation throws a [PptxException](https://reference.aspose.com/slides/es/net/aspose.slides/pptxexception/).

{{% /alert %}}

## **Guardar presentaciones en formato Office Open XML con niveles de compresión**

Para la salida PPTX, puede equilibrar la velocidad de guardado con el tamaño del archivo estableciendo la propiedad [PptxOptions.CompressionLevel](https://reference.aspose.com/slides/es/net/aspose.slides.export/pptxoptions/compressionlevel/). La enumeración [CompressionLevel](https://reference.aspose.com/slides/es/net/aspose.slides.export/compressionlevel/) proporciona los siguientes valores:

- `None` almacena los datos sin compresión.
- `Level1` ofrece la compresión más rápida y el archivo comprimido más grande.
- `Level2` a `Level5` favorecen progresivamente un archivo más pequeño sobre la velocidad de guardado.
- `Level6` equilibra velocidad de guardado y tamaño del archivo. Este es el nivel predeterminado.
- `Level7` y `Level8` favorecen aún más un archivo más pequeño sobre la velocidad de guardado.
- `Level9` brinda la compresión más fuerte y requiere el mayor tiempo de procesamiento.

El siguiente ejemplo guarda una presentación sin compresión:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.None
};

presentation.Save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
```

El siguiente ejemplo utiliza el nivel máximo de compresión:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.Level9
};

presentation.Save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
```

## **Guardar presentaciones sin actualizar la miniatura**

Cuando una presentación se guarda como PPTX, la propiedad [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/es/net/aspose.slides.export/pptxoptions/refreshthumbnail/) controla su miniatura de documento:

- `true` regenera la miniatura durante la operación de guardado. Este es el valor predeterminado.
- `false` conserva la miniatura existente. Si la presentación no tiene miniatura, Aspose.Slides no genera una.

El siguiente ejemplo guarda una presentación sin actualizar su miniatura:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    RefreshThumbnail = false
};

presentation.Save("Output.pptx", SaveFormat.Pptx, options);
```

{{% alert color="info" title="Note" %}}

Desactivar la actualización de la miniatura puede reducir el tiempo necesario para guardar un archivo PPTX.

{{% /alert %}}

## **Guardar actualizaciones de progreso en porcentaje**

Para supervisar una operación de guardado, implemente la interfaz [IProgressCallback](https://reference.aspose.com/slides/es/net/aspose.slides/iprogresscallback/) y asigne la implementación a la propiedad [ISaveOptions.ProgressCallback](https://reference.aspose.com/slides/es/net/aspose.slides.export/isaveoptions/progresscallback/). Aspose.Slides entonces llama al método [IProgressCallback.Reporting](https://reference.aspose.com/slides/es/net/aspose.slides/iprogresscallback/reporting/) con valores de progreso durante la exportación.

El siguiente ejemplo informa del progreso de una exportación PDF en la consola:

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PdfOptions
{
    ProgressCallback = new ExportProgressHandler()
};

using var presentation = new Presentation("Sample.pptx");

presentation.Save("Output.pdf", SaveFormat.Pdf, options);

class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        var progress = Convert.ToInt32(progressValue);
        Console.WriteLine($"{progress}% of the file has been converted.");
    }
}
```

{{% alert color="info" title="Note" %}}

Aspose ofrece un [PowerPoint Splitter](https://products.aspose.app/slides/es/splitter) gratuito construido con la API Aspose.Slides. Guarda diapositivas seleccionadas de una presentación como archivos PPT o PPTX independientes.

{{% /alert %}}

## **Preguntas frecuentes**

**¿Aspose.Slides admite guardado incremental o “fast save”?**

No. Cada operación de guardado escribe un archivo de salida completo en lugar de actualizar solo las partes modificadas.

**¿Pueden varios hilos guardar la misma instancia de Presentation?**

No. Una instancia de [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) **no es thread-safe** (/slides/es/net/multithreading/). Acceda y guarde cada instancia desde un solo hilo a la vez.

**¿Qué ocurre con los hipervínculos y los archivos vinculados externamente cuando guardo una presentación?**

Los [hipervínculos](/slides/es/net/manage-hyperlinks/) permanecen en la presentación. Aspose.Slides no copia los archivos vinculados externamente, por lo que la presentación guardada debe seguir pudiendo acceder a sus ubicaciones.

**¿Puedo guardar metadatos del documento como autor, título, empresa y fecha de creación?**

Sí. Establezca las [propiedades del documento](/slides/es/net/presentation-properties/) apropiadas antes de guardar, y Aspose.Slides las escribe en el archivo de salida.