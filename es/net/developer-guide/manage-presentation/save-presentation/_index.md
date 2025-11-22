---
title: Guardar presentaciones en .NET
linktitle: Guardar presentaciones
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
- Formato Strict Office Open XML
- modo Zip64
- actualizar miniatura
- progreso de guardado
- .NET
- C#
- Aspose.Slides
description: "Descubra cómo guardar presentaciones en .NET usando Aspose.Slides—exportar a PowerPoint u OpenDocument manteniendo diseños, fuentes y efectos."
---

## **Descripción general**

[Presentaciones abiertas en C#](/slides/es/net/open-presentation/) describió cómo usar la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) para abrir una presentación. Este artículo explica cómo crear y guardar presentaciones. La clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) contiene el contenido de una presentación. Ya sea que esté creando una presentación desde cero o modificando una existente, querrá guardarla cuando haya terminado. Con Aspose.Slides para .NET, puede guardar en un **archivo** o **flujo**. Este artículo explica las diferentes formas de guardar una presentación.

## **Guardar presentaciones en archivos**

Guarde una presentación en un archivo llamando al método `Save` de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). Pase el nombre del archivo y el formato de guardado al método. El siguiente ejemplo muestra cómo guardar una presentación con Aspose.Slides.
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

Puede guardar una presentación en un flujo pasando un flujo de salida al método `Save` de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). Una presentación puede escribirse en muchos tipos de flujo. En el ejemplo a continuación, creamos una nueva presentación y la guardamos en un flujo de archivo.
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

Aspose.Slides le permite establecer la vista inicial que PowerPoint usa cuando la presentación generada se abre mediante la clase [ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/). Establezca la propiedad [LastView](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/lastview/) a un valor de la enumeración [ViewType](https://reference.aspose.com/slides/net/aspose.slides/viewtype/).
```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```


## **Guardar presentaciones en el formato Strict Office Open XML**

Aspose.Slides permite guardar una presentación en el formato Strict Office Open XML. Use la clase [PptxOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions/) y establezca su propiedad de conformidad al guardar. Si establece `Conformance.Iso29500_2008_Strict`, el archivo de salida se guarda en el formato Strict Office Open XML.

El ejemplo a continuación crea una presentación y la guarda en el formato Strict Office Open XML.
```cs
PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// Instanciar la clase Presentation que representa un archivo de presentación.
using (Presentation presentation = new Presentation())
{
    // Guardar la presentación en el formato Strict Office Open XML.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```


## **Guardar presentaciones en formato Office Open XML en modo Zip64**

Un archivo Office Open XML es un archivo ZIP que impone límites de 4 GB (2^32 bytes) al tamaño sin comprimir de cualquier archivo, al tamaño comprimido de cualquier archivo y al tamaño total del archivo, y también limita el archivo a 65 535 (2^16‑1) archivos. Las extensiones de formato ZIP64 elevan estos límites a 2^64.

La propiedad [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/zip64mode/) le permite elegir cuándo usar extensiones de formato ZIP64 al guardar un archivo Office Open XML.

Esta propiedad proporciona los siguientes modos:

- `IfNecessary` usa extensiones de formato ZIP64 solo si la presentación supera las limitaciones anteriores. Este es el modo predeterminado.
- `Never` nunca usa extensiones de formato ZIP64.
- `Always` siempre usa extensiones de formato ZIP64.

El siguiente código muestra cómo guardar una presentación como PPTX con extensiones de formato ZIP64 habilitadas:
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

Al guardar con `Zip64Mode.Never`, se lanza una [PptxException](https://reference.aspose.com/slides/net/aspose.slides/pptxexception/) si la presentación no puede guardarse en formato ZIP32.

{{% /alert %}}

## **Guardar presentaciones sin actualizar la miniatura**

La propiedad [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) controla la generación de miniaturas al guardar una presentación en PPTX:

- Si se establece en `true`, la miniatura se actualiza durante el guardado. Este es el valor predeterminado.
- Si se establece en `false`, se conserva la miniatura actual. Si la presentación no tiene miniatura, no se generará ninguna.

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

## **Actualizaciones del progreso de guardado en porcentaje**

La interfaz [IProgressCallback](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback/) se usa a través de la propiedad `ProgressCallback` expuesta por la interfaz [ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/isaveoptions/) y la clase abstracta [SaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/). Asigne una implementación de [IProgressCallback](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback/) a `ProgressCallback` para recibir actualizaciones del progreso de guardado como un porcentaje.

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
        // Use el valor del porcentaje de progreso aquí.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```


{{% alert title="Información" color="info" %}}

Aspose ha desarrollado una [aplicación gratuita PowerPoint Splitter](https://products.aspose.app/slides/splitter) usando su propia API. La aplicación le permite dividir una presentación en varios archivos guardando diapositivas seleccionadas como nuevos archivos PPTX o PPT.

{{% /alert %}}

## **Preguntas frecuentes**

**¿Se admite el “guardado rápido” (guardado incremental) para que solo se escriban los cambios?**

No. Cada guardado crea el archivo de destino completo; el “guardado rápido” incremental no está soportado.

**¿Es seguro guardar la misma instancia de Presentation desde varios hilos?**

No. Una instancia de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) **no es segura para subprocesos** (/slides/es/net/multithreading/); guárdela desde un solo hilo.

**¿Qué ocurre con los hipervínculos y los archivos vinculados externamente al guardar?**

Los [hipervínculos](/slides/es/net/manage-hyperlinks/) se preservan. Los archivos vinculados externamente (p. ej., videos mediante rutas relativas) no se copian automáticamente; asegúrese de que las rutas referenciadas sigan siendo accesibles.

**¿Puedo establecer/guardar metadatos del documento (Autor, Título, Empresa, Fecha)?**

Sí. Las [propiedades estándar del documento](/slides/es/net/presentation-properties/) son compatibles y se escribirán en el archivo al guardarlo.