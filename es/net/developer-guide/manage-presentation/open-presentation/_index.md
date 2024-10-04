---
title: Abrir Presentación en C#
linktitle: Abrir Presentación
type: docs
weight: 20
url: /es/net/open-presentation/
keywords: "Abrir PowerPoint, PPTX, PPT, Abrir Presentación, Cargar Presentación, C#, Csharp, .NET"
description: "Abrir o cargar Presentación PPT, PPTX, ODP en C# o .NET"
---

Además de crear presentaciones de PowerPoint desde cero, Aspose.Slides te permite abrir presentaciones existentes. Después de cargar una presentación, puedes obtener información sobre la presentación, editar la presentación (el contenido en sus diapositivas), agregar nuevas diapositivas o eliminar las existentes, etc.

## Abrir Presentación

Para abrir una presentación existente, simplemente tienes que instanciar la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) y pasar la ruta del archivo (a la presentación que quieres abrir) a su constructor.

Este código C# te muestra cómo abrir una presentación y también averiguar cuántas diapositivas contiene:

```c#
// Instancia la clase Presentation y pasa la ruta del archivo a su constructor
Presentation pres = new Presentation("OpenPresentation.pptx");

// Imprime el número total de diapositivas presentes en la presentación
System.Console.WriteLine(pres.Slides.Count.ToString());
```

## **Abrir Presentación Protegida por Contraseña**

Cuando tengas que abrir una presentación protegida por contraseña, puedes pasar la contraseña a través de la propiedad [Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) (de la clase [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/)) para desencriptar la presentación y cargar la presentación. Este código C# demuestra la operación:

```c#
	LoadOptions loadOptions = new LoadOptions {Password = "TU_CONTRASEÑA"};
	using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
	{
	  // Haz algo con la presentación desencriptada
	}
```

## Abrir Presentación Grande

Aspose.Slides proporciona opciones (la propiedad [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/blobmanagementoptions/) en particular) bajo la clase [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) para permitirte cargar presentaciones grandes.

Este C# demuestra una operación en la que se carga una presentación grande (digamos 2GB de tamaño):

```c#
const string pathToVeryLargePresentationFile = "veryLargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = {
        // Elijamos el comportamiento KeepLocked - el "veryLargePresentation.pptx" estará bloqueado durante
        // la duración de la instancia de Presentation, pero no necesitamos cargarlo en memoria ni copiarlo en
        // el archivo temporal
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
    }
};

using (Presentation pres = new Presentation(pathToVeryLargePresentationFile, loadOptions))
{
    // La presentación grande ha sido cargada y puede ser utilizada, pero el consumo de memoria sigue siendo bajo.

    // Realiza cambios en la presentación.
    pres.Slides[0].Name = "Presentación muy grande";

    // La presentación se guardará en otro archivo. El consumo de memoria se mantiene bajo durante la operación
    pres.Save("veryLargePresentation-copy.pptx", SaveFormat.Pptx);

    // ¡No se puede hacer eso! Se arrojará una excepción de IO, porque el archivo está bloqueado mientras los objetos pres
    // no serán destruidos
    File.Delete(pathToVeryLargePresentationFile);
}

// Se puede hacer aquí, el archivo de origen no está bloqueado por el objeto pres
File.Delete(pathToVeryLargePresentationFile);
```

{{% alert color="info" title="Info" %}}

Para sortear ciertas limitaciones al interactuar con flujos, Aspose.Slides puede copiar el contenido del flujo. Cargar una presentación grande a través de su flujo resultará en la copia del contenido de la presentación y causará una carga lenta. Por lo tanto, cuando tengas la intención de cargar una presentación grande, te recomendamos encarecidamente que uses la ruta del archivo de presentación y no su flujo.

Cuando quieras crear una presentación que contenga objetos grandes (video, audio, imágenes grandes, etc.), puedes utilizar la [facilidad Blob](https://docs.aspose.com/slides/net/manage-blob/) para reducir el consumo de memoria.

{{%/alert %}} 


## Cargar Presentación
Aspose.Slides proporciona [IResourceLoadingCallback](https://reference.aspose.com/slides/net/aspose.slides/iresourceloadingcallback/) con un único método para permitirte gestionar recursos externos. Este código C# te muestra cómo utilizar la interfaz `IResourceLoadingCallback`:

```c#
LoadOptions opts = new LoadOptions();
opts.ResourceLoadingCallback = new ImageLoadingHandler();
Presentation presentation = new Presentation("presentation.pptx", opts);
```

```c#
public class ImageLoadingHandler : IResourceLoadingCallback
{
    public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
    {
        if (args.OriginalUri.EndsWith(".jpg"))
        {
            try // Carga la imagen de sustitución
            {
                byte[] imageBytes = File.ReadAllBytes("c:\\aspose-logo.jpg");
                args.SetData(imageBytes);
                return ResourceLoadingAction.UserProvided;
            }
            catch (Exception)
            {
                return ResourceLoadingAction.Skip;
            }
        }
        else if (args.OriginalUri.EndsWith(".png"))
        {
            // Establece la url de sustitución
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // Salta todas las demás imágenes
        return ResourceLoadingAction.Skip;
    }
}
```

## Cargar Presentación Sin Objetos Binarios Incrustados

La presentación de PowerPoint puede contener los siguientes tipos de objetos binarios incrustados:

- Proyecto VBA ([IPresentation.VbaProject](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/vbaproject/));
- Datos de objeto OLE incrustados ([IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/));
- Datos binarios de Control ActiveX ([IControl.ActiveXControlBinary](https://reference.aspose.com/slides/net/aspose.slides/icontrol/activexcontrolbinary/));

Utilizando la propiedad [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/) puedes cargar la presentación sin ningún objeto binario incrustado.

Esta propiedad puede ser útil para eliminar contenido binario potencialmente malicioso.

El código C# demuestra cómo cargar y guardar una presentación sin contenido de malware:

```c#
LoadOptions loadOptions = new LoadOptions()
{
	DeleteEmbeddedBinaryObjects = true
}

using (var pres = new Presentation("malware.ppt", loadOptions))
{
    pres.Save("clean.ppt", SaveFormat.Ppt);
}
```

<h2>Abrir y Guardar Presentación</h2>

<a name="csharp-open-save-presentation"><strong>Pasos: Abrir y Guardar Presentación en C#</strong></a>

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) y pasa el archivo que deseas abrir. 
2. Guarda la Presentación.

```c#
// Carga cualquier presentación soportada e.g ppt, pptx, odp
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```