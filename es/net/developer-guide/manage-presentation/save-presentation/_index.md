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
- actualización de miniatura
- progreso de guardado
- .NET
- C#
- Aspose.Slides
description: "Descubra cómo guardar presentaciones en .NET usando Aspose.Slides—exportar a PowerPoint u OpenDocument manteniendo diseños, fuentes y efectos."
---
## **Descripción general**

[Open Presentations in C#](/slides/es/net/open-presentation/) describe cómo usar la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) para abrir una presentación. Este artículo explica cómo crear y guardar presentaciones. La clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) contiene el contenido de una presentación. Ya sea que esté creando una presentación desde cero o modificando una existente, querrá guardarla cuando haya terminado. Con Aspose.Slides para .NET, puede guardar en un **archivo** o **flujo**. Este artículo explica las diferentes formas de guardar una presentación.

## **Guardar presentaciones en archivos**

Guarde una presentación en un archivo llamando al método `Save` de la clase Presentation. Pase el nombre del archivo y el formato de guardado al método. El siguiente ejemplo muestra cómo guardar una presentación con Aspose.Slides.

```cs
// Instanciar la clase Presentation que representa un archivo de presentación.
using (Presentation presentation = new Presentation())
{
    // Realizar algún trabajo aquí...

    // Guardar la presentación en un archivo.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Guardar presentaciones en flujos**

Puede guardar una presentación en un flujo pasando un flujo de salida al método `Save` de la clase Presentation. Una presentación puede escribirse en muchos tipos de flujos. En el ejemplo a continuación, creamos una nueva presentación y la guardamos en un flujo de archivo.

```cs
// Instanciar la clase Presentation que representa un archivo de presentación.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // Guardar la presentación en el flujo.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **Guardar presentaciones con un tipo de vista predefinido**

Aspose.Slides le permite establecer la vista inicial que PowerPoint usa cuando la presentación generada se abre mediante la clase [ViewProperties](https://reference.aspose.com/slides/es/net/aspose.slides/viewproperties/). Establezca la propiedad [LastView](https://reference.aspose.com/slides/es/net/aspose.slides/viewproperties/lastview/) a un valor de la enumeración [ViewType](https://reference.aspose.com/slides/es/net/aspose.slides/viewtype/).

```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Guardar presentaciones en el formato estricto Office Open XML**

Aspose.Slides le permite guardar una presentación en el formato estricto Office Open XML. Utilice la clase [PptxOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/pptxoptions/) y establezca su propiedad conformance al guardar. Si establece `Conformance.Iso29500_2008_Strict`, el archivo de salida se guarda en el formato estricto Office Open XML.

El ejemplo a continuación crea una presentación y la guarda en el formato estricto Office Open XML.

```cs
PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// Instanciar la clase Presentation que representa un archivo de presentación.
using (Presentation presentation = new Presentation())
{
    // Guardar la presentación en el formato estricto Office Open XML.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **Guardar presentaciones en formato Office Open XML en modo Zip64**

Un archivo Office Open XML es un archivo ZIP que impone límites de 4 GB (2^32 bytes) en el tamaño sin comprimir de cualquier archivo, el tamaño comprimido de cualquier archivo y el tamaño total del archivo, y también limita el archivo a 65 535 (2^16‑1) archivos. Las extensiones de formato ZIP64 elevan estos límites a 2^64.

La propiedad [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/es/net/aspose.slides.export/ipptxoptions/zip64mode/) le permite elegir cuándo usar las extensiones del formato ZIP64 al guardar un archivo Office Open XML.

Esta propiedad ofrece los siguientes modos:

- `IfNecessary` usa las extensiones del formato ZIP64 sólo si la presentación supera las limitaciones anteriores. Este es el modo predeterminado.
- `Never` nunca usa extensiones del formato ZIP64.
- `Always` siempre usa extensiones del formato ZIP64.

El siguiente código muestra cómo guardar una presentación como archivo PPTX con las extensiones del formato ZIP64 habilitadas:

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="NOTA" color="warning" %}}
Cuando guarda con `Zip64Mode.Never`, se lanza una PptxException si la presentación no puede guardarse en formato ZIP32.
{{% /alert %}}

## **Guardar presentaciones en formato Office Open XML con niveles de compresión**

Al trabajar con presentaciones grandes, puede ajustar el nivel de compresión para equilibrar el tamaño del archivo y el tiempo de procesamiento. Según sus requisitos, puede preferir un procesamiento más rápido o archivos de salida más pequeños.

Aspose.Slides ofrece la propiedad [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/es/net/aspose.slides.export/ipptxoptions/compressionlevel/), que le permite especificar el nivel de compresión utilizado al guardar una presentación en formato Office Open XML.

Los siguientes niveles de compresión están disponibles:

- **None**: No se aplica compresión. Los archivos se almacenan tal cual.
- **Level1**: La compresión más rápida con la menor proporción de compresión.
- **Level2**: Compresión más rápida con una proporción de compresión algo mejor que **Level1**.
- **Level3**: Proporciona mejor compresión que **Level2** con un impacto moderado en el tiempo de procesamiento.
- **Level4**: Proporciona mejor compresión que **Level3**.
- **Level5**: Proporciona una compresión mejorada respecto a **Level4** con tiempo de procesamiento adicional.
- **Level6**: Compresión estándar que ofrece un buen equilibrio entre velocidad de procesamiento y tamaño de archivo. Este es el *nivel de compresión predeterminado*.
- **Level7**: Proporciona mejor compresión que **Level6** con un procesamiento más lento.
- **Level8**: Proporciona mejor compresión que **Level7**.
- **Level9**: Compresión máxima. Produce el archivo de menor tamaño a costa del tiempo de procesamiento más largo.

El siguiente ejemplo muestra cómo guardar una presentación como archivo PPTX *sin compresión*:
```cs
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-out.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.None
    });
}
```

Este ejemplo muestra cómo guardar una presentación como archivo PPTX con *compresión máxima*:
```cs
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **Guardar presentaciones sin actualizar la miniatura**

La propiedad [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/es/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) controla la generación de miniaturas al guardar una presentación en PPTX:

- Si se establece en `true`, la miniatura se actualiza durante el guardado. Este es el valor predeterminado.
- Si se establece en `false`, la miniatura actual se conserva. Si la presentación no tiene miniatura, no se generará ninguna.

En el código a continuación, la presentación se guarda en PPTX sin actualizar su miniatura.

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```

{{% alert title="Información" color="info" %}}
Esta opción ayuda a reducir el tiempo necesario para guardar una presentación en formato PPTX.
{{% /alert %}}

## **Actualizar el progreso de guardado en porcentaje**

La interfaz [IProgressCallback](https://reference.aspose.com/slides/es/net/aspose.slides/iprogresscallback/) se utiliza a través de la propiedad `ProgressCallback` expuesta por la interfaz [ISaveOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/isaveoptions/) y la clase abstracta [SaveOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/saveoptions/). Asigne una implementación de [IProgressCallback](https://reference.aspose.com/slides/es/net/aspose.slides/iprogresscallback/) a `ProgressCallback` para recibir actualizaciones del progreso de guardado como porcentaje.

Los fragmentos de código siguientes muestran cómo usar `IProgressCallback`.

```cs
ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // Utilice aquí el valor del porcentaje de progreso.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Información" color="info" %}}
Aspose ha desarrollado una aplicación gratuita PowerPoint Splitter utilizando su propia API. La aplicación le permite dividir una presentación en varios archivos guardando diapositivas seleccionadas como nuevos archivos PPTX o PPT.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Se admite el "guardado rápido" (guardado incremental) para que sólo se escriban los cambios?**

No. Guardar crea el archivo completo de destino cada vez; el "guardado rápido" incremental no es compatible.

**¿Es seguro guardar la misma instancia de Presentation desde varios hilos?**

No. Una instancia de Presentation no es segura para subprocesos; guárdela desde un solo hilo.

**¿Qué ocurre con los hipervínculos y los archivos vinculados externamente al guardar?**

[Hyperlinks](/slides/es/net/manage-hyperlinks/) se conservan. Los archivos vinculados externamente (p. ej., videos mediante rutas relativas) no se copian automáticamente; asegúrese de que las rutas referenciadas sigan siendo accesibles.

**¿Puedo establecer/guardar metadatos del documento (Autor, Título, Empresa, Fecha)?**

Sí. Las propiedades de documento estándar son compatibles y se escribirán en el archivo al guardarlo.