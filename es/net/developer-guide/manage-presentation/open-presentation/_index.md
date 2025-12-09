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
description: "Abra presentaciones de PowerPoint (.pptx, .ppt) y OpenDocument (.odp) sin esfuerzo con Aspose.Slides para .NET: rápidas, fiables y con todas las funciones."
---

## **Descripción general**

Además de crear presentaciones de PowerPoint desde cero, Aspose.Slides también le permite abrir presentaciones existentes. Después de cargar una presentación, puede obtener información sobre ella, editar el contenido de las diapositivas, añadir nuevas diapositivas, eliminar las existentes y mucho más.

## **Abrir presentaciones**

Para abrir una presentación existente, instancie la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) y pase la ruta del archivo a su constructor.

El siguiente ejemplo en C# muestra cómo abrir una presentación y obtener el número de diapositivas:
```cs
// Instanciar la clase Presentation y pasar una ruta de archivo a su constructor.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // Imprimir el número total de diapositivas en la presentación.
    System.Console.WriteLine(presentation.Slides.Count);
}
```


## **Abrir presentaciones protegidas con contraseña**

Cuando necesita abrir una presentación protegida con contraseña, pase la contraseña a través de la propiedad [Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) de la clase [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) para descifrarla y cargarla. El siguiente código en C# demuestra esta operación:
```cs
LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
using (Presentation presentation = new Presentation("Sample.pptx", loadOptions))
{
    // Realizar operaciones en la presentación descifrada.
}
```


## **Abrir presentaciones grandes**

Aspose.Slides ofrece opciones —en particular la propiedad [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/blobmanagementoptions/) en la clase [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/)—para ayudarle a cargar presentaciones grandes.

El siguiente código en C# demuestra cómo cargar una presentación grande (por ejemplo, 2 GB):
```cs
const string filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = 
    {
        // Elija el comportamiento KeepLocked: el archivo de la presentación permanecerá bloqueado durante la vida útil de 
        // la instancia Presentation, pero no es necesario cargarlo en memoria ni copiarlo a un archivo temporal.
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024 // 10 MB
    }
};

using (Presentation presentation = new Presentation(filePath, loadOptions))
{
    // La gran presentación se ha cargado y puede usarse, mientras el consumo de memoria se mantiene bajo.

    // Realice cambios en la presentación.
    presentation.Slides[0].Name = "Large presentation";

    // Guarde la presentación en otro archivo. El consumo de memoria se mantiene bajo durante esta operación.
    presentation.Save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // ¡No haga esto! Se lanzará una excepción de E/S porque el archivo está bloqueado hasta que se elimine el objeto Presentation.
    File.Delete(filePath);
}

// Está bien hacerlo aquí. El archivo fuente ya no está bloqueado por el objeto Presentation.
File.Delete(filePath);
```


{{% alert color="info" title="Info" %}}
Para sortear ciertas limitaciones al trabajar con flujos, Aspose.Slides puede copiar el contenido de un flujo. Cargar una presentación grande desde un flujo hace que la presentación se copie y puede ralentizar la carga. Por lo tanto, cuando necesite cargar una presentación grande, recomendamos encarecidamente usar la ruta del archivo de la presentación en lugar de un flujo.

Al crear una presentación que contiene objetos grandes (video, audio, imágenes de alta resolución, etc.), puede utilizar [BLOB management](/slides/es/net/manage-blob/) para reducir el consumo de memoria.
{{%/alert %}}

## **Controlar recursos externos**

Aspose.Slides proporciona la interfaz [IResourceLoadingCallback](https://reference.aspose.com/slides/net/aspose.slides/iresourceloadingcallback/) que le permite gestionar recursos externos. El siguiente código en C# muestra cómo usar la interfaz `IResourceLoadingCallback`:
```cs
LoadOptions loadOptions = new LoadOptions();
loadOptions.ResourceLoadingCallback = new ImageLoadingHandler();

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```cs
public class ImageLoadingHandler : IResourceLoadingCallback
{
    public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
    {
        if (args.OriginalUri.EndsWith(".jpg"))
        {
            try
            {
                // Cargar una imagen de sustitución.
                byte[] imageData = File.ReadAllBytes("aspose-logo.jpg");
                args.SetData(imageData);
                return ResourceLoadingAction.UserProvided;
            }
            catch (Exception)
            {
                return ResourceLoadingAction.Skip;
            }
        }
        else if (args.OriginalUri.EndsWith(".png"))
        {
            // Establecer una URL sustituta.
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // Omitir todas las demás imágenes.
        return ResourceLoadingAction.Skip;
    }
}
```


## **Cargar presentaciones sin objetos binarios incrustados**

Una presentación de PowerPoint puede contener los siguientes tipos de objetos binarios incrustados:

- proyecto VBA (accesible a través de [IPresentation.VbaProject](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/vbaproject/));
- datos incrustados de objetos OLE (accesible a través de [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/));
- datos binarios de controles ActiveX (accesible a través de [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/net/aspose.slides/icontrol/activexcontrolbinary/)).

Usando la propiedad [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/) puede cargar una presentación sin ningún objeto binario incrustado.

Esta propiedad es útil para eliminar contenido binario potencialmente malicioso. El siguiente código en C# demuestra cómo cargar una presentación sin contenido binario incrustado:
```cs
LoadOptions loadOptions = new LoadOptions()
{
	DeleteEmbeddedBinaryObjects = true
}

using (Presentation presentation = new Presentation("malware.ppt", loadOptions))
{
    // Realizar operaciones en la presentación.
}
```


## **Preguntas frecuentes**

**¿Cómo puedo saber que un archivo está corrupto y no se puede abrir?**

Recibirá una excepción de validación de análisis/formato durante la carga. Estos errores a menudo mencionan una estructura ZIP no válida o registros de PowerPoint dañados.

**¿Qué ocurre si faltan fuentes requeridas al abrir?**

El archivo se abrirá, pero luego la [renderización/exportación](/slides/es/net/convert-presentation/) puede sustituir fuentes. [Configure sustituciones de fuentes](/slides/es/net/font-substitution/) o [añada las fuentes requeridas](/slides/es/net/custom-font/) al entorno de ejecución.

**¿Qué pasa con los medios incrustados (video/audio) al abrir?**

Se vuelven disponibles como recursos de la presentación. Si los medios se referencian mediante rutas externas, asegúrese de que esas rutas sean accesibles en su entorno; de lo contrario la [renderización/exportación](/slides/es/net/convert-presentation/) puede omitir los medios.