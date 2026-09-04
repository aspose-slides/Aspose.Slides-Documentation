---
title: Abrir presentaciones en .NET
linktitle: Abrir presentación
type: docs
weight: 20
url: /es/net/open-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Aprende a abrir presentaciones de PowerPoint y OpenDocument en C#, proporcionar contraseñas de apertura, controlar la carga de recursos y reducir el uso de memoria con Aspose.Slides para .NET."
---
## **Introducción**

[Aspose.Slides for .NET](https://products.aspose.com/slides/es/net/) puede cargar presentaciones de PowerPoint y OpenDocument desde archivos y flujos. Después de cargar una presentación, puedes inspeccionar su estructura, editar diapositivas, gestionar recursos y guardarla en el formato original o en otro formato compatible.

El comportamiento de carga se puede personalizar mediante la clase [LoadOptions](https://reference.aspose.com/slides/es/net/aspose.slides/loadoptions/). Por ejemplo, puedes proporcionar una contraseña de apertura, mantener objetos binarios grandes fuera de la memoria gestionada, controlar recursos externos o omitir datos binarios incrustados.

## **Abrir presentaciones**

Para abrir una presentación existente, pasa su ruta de archivo al constructor [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/). Desecha la presentación después de usarla para que los manejadores de archivo, los datos temporales y otros recursos se liberen de forma rápida.

El siguiente ejemplo en C# muestra cómo abrir una presentación y obtener el número de diapositivas:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

## **Abrir presentaciones protegidas con contraseña**

Una contraseña de apertura cifra el contenido de la presentación. Para cargar la presentación completa, asigna la contraseña correcta a [LoadOptions.Password](https://reference.aspose.com/slides/es/net/aspose.slides/loadoptions/password/) y pasa las opciones al constructor [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/). La carga falla cuando la contraseña falta o es incorrecta.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-presentation.pptx", loadOptions);

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

Para la detección, validación y flujos de trabajo de cifrado de contraseñas, consulta [Password-Protect Presentations](/slides/es/net/password-protected-presentation/). Si una presentación cifrada se guardó deliberadamente con propiedades de documento públicas, esas propiedades pueden leerse sin contraseña; consulta [Manage Presentation Properties](/slides/es/net/presentation-properties/).

## **Abrir presentaciones grandes**

[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/es/net/aspose.slides/loadoptions/blobmanagementoptions/) controla cómo Aspose.Slides gestiona los objetos binarios grandes, como imágenes, audio y vídeo. Puedes mantener el archivo fuente bloqueado, permitir archivos temporales y limitar la cantidad de datos BLOB retenidos en memoria.

El siguiente código en C# demuestra cómo cargar una presentación grande (por ejemplo, 2 GB):

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

const string filePath = "large-presentation.pptx";

var loadOptions = new LoadOptions
{
    BlobManagementOptions =
    {
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024
    }
};

using var presentation = new Presentation(filePath, loadOptions);

presentation.Slides[0].Name = "Large presentation";
presentation.Save("large-presentation-copy.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}

Con `PresentationLockingBehavior.KeepLocked`, el archivo fuente permanece bloqueado hasta que se deseche el objeto `Presentation`. No muevas, sobrescribas ni elimines el archivo fuente mientras ese objeto esté activo.

Aspose.Slides puede copiar el contenido de un flujo de entrada durante la carga. Para presentaciones grandes, una ruta de archivo es, por tanto, generalmente más eficiente que un flujo. Consulta [Manage BLOBs](/slides/es/net/manage-blob/) para opciones adicionales de almacenamiento y gestión de memoria.

{{% /alert %}}

## **Controlar recursos externos**

[LoadOptions.ResourceLoadingCallback](https://reference.aspose.com/slides/es/net/aspose.slides/loadoptions/resourceloadingcallback/) acepta una implementación de [IResourceLoadingCallback](https://reference.aspose.com/slides/es/net/aspose.slides/iresourceloadingcallback/). La devolución de llamada puede proporcionar datos de reemplazo, redirigir un recurso, usar el cargador predeterminado o omitir el recurso. Esto es útil cuando las presentaciones contienen imágenes externas que deben resolverse de acuerdo con reglas de seguridad o almacenamiento específicas de la aplicación.

```csharp
using System;
using System.IO;
using Aspose.Slides;

internal static class OpenPresentationExample
{
    private static void Main()
    {
        var loadOptions = new LoadOptions
        {
            ResourceLoadingCallback = new ImageLoadingHandler()
        };

        using var presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
        Console.WriteLine("Slide count: " + presentation.Slides.Count);
    }

    private sealed class ImageLoadingHandler : IResourceLoadingCallback
    {
        public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
        {
            var isJpeg = args.OriginalUri.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase);
            if (!isJpeg || !File.Exists("approved-image.jpg"))
            {
                return ResourceLoadingAction.Skip;
            }

            var imageData = File.ReadAllBytes("approved-image.jpg");
            args.SetData(imageData);
            return ResourceLoadingAction.UserProvided;
        }
    }
}
```

## **Cargar presentaciones sin objetos binarios incrustados**

Una presentación puede contener datos binarios incrustados que una aplicación no necesita o no desea conservar. Ejemplos incluyen:

- Proyectos VBA, disponibles a través de [IPresentation.VbaProject](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentation/vbaproject/);
- Datos OLE incrustados, disponibles a través de [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/es/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/);
- Datos de controles ActiveX, disponibles a través de [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/es/net/aspose.slides/icontrol/activexcontrolbinary/).

Establece [LoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/es/net/aspose.slides/loadoptions/deleteembeddedbinaryobjects/) a `true` para eliminar estos datos binarios durante la carga. Guarda la presentación cargada para conservar el resultado saneado.

Esta opción reduce la exposición a cargas útiles incrustadas no deseadas, pero no constituye un sistema completo de detección de malware o de saneamiento de contenido.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DeleteEmbeddedBinaryObjects = true
};

using var presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);

presentation.Save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
```

## **Preguntas frecuentes**

**¿Cómo puedo saber si un archivo está corrupto y no se puede abrir?**

Aspose.Slides lanza una excepción de análisis o de formato durante la carga. Gestiona ese fallo por separado del error de contraseña incorrecta para que la aplicación pueda informar la causa con precisión.

**¿Qué ocurre si faltan fuentes requeridas?**

La presentación aún puede cargarse, pero la renderización y la exportación pueden sustituir fuentes. Puedes [configure font substitution](/slides/es/net/font-substitution/) o [provide custom fonts](/slides/es/net/custom-font/) para que el resultado sea más predecible.

**¿La carga de una presentación también carga sus medios incrustados?**

El audio y vídeo incrustados están disponibles a través del modelo de objetos de la presentación. Los recursos externos se resuelven según el comportamiento de carga de recursos configurado y pueden estar indisponibles si sus ubicaciones no pueden ser accedidas.