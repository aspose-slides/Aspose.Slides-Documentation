---
title: Gestionar Blob
type: docs
weight: 10
url: /net/manage-blob/
keywords: "Agregar blob, Exportar blob, Agregar imagen como blob, Presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Agregar blob a la presentación de PowerPoint en C# o .NET. Exportar blob. Agregar imagen como blob"
---

## **Acerca de BLOB**

**BLOB** (**Objeto Binario Grande**) es generalmente un elemento grande (foto, presentación, documento o medio) guardado en formatos binarios.

Aspose.Slides para .NET te permite usar BLOBs para objetos de una manera que reduce el consumo de memoria cuando hay archivos grandes involucrados.

## **Usar BLOB para Reducir el Consumo de Memoria**

### **Agregar Archivo Grande a una Presentación a través de BLOB**

[Aspose.Slides](/slides/net/) para .NET te permite agregar archivos grandes (en este caso, un archivo de video grande) mediante un proceso que involucra BLOBs para reducir el consumo de memoria.

Este C# te muestra cómo agregar un archivo de video grande a través del proceso BLOB a una presentación:

```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// Crea una nueva presentación a la que se añadirá el video
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // Vamos a agregar el video a la presentación - elegimos el comportamiento KeepLocked porque no
        // tenemos intención de acceder al archivo "veryLargeVideo.avi".
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // Guarda la presentación. Mientras se genera una presentación grande, el consumo de memoria
        // se mantiene bajo a lo largo del ciclo de vida del objeto pres.
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```

### **Exportar Archivo Grande a través de BLOB desde la Presentación**
Aspose.Slides para .NET te permite exportar archivos grandes (en este caso, un archivo de audio o video) a través de un proceso que involucra BLOBs desde presentaciones. Por ejemplo, puede que necesites extraer un archivo multimedia grande de una presentación pero no quieras que el archivo se cargue en la memoria de tu computadora. Al exportar el archivo a través del proceso BLOB, mantienes el consumo de memoria bajo.

Este código en C# demuestra la operación descrita:

```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// Bloquea el archivo fuente y NO lo carga en memoria
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// Crea una instancia de Presentation, bloquea el archivo "hugePresentationWithAudiosAndVideos.pptx".
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// Vamos a guardar cada video en un archivo. Para prevenir un alto uso de memoria, necesitamos un búfer que será utilizado
	// para transferir los datos desde el flujo de video de la presentación a un flujo para un archivo de video recién creado.
	byte[] buffer = new byte[8 * 1024];

	// Itera a través de los videos
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// Abre el flujo de video de la presentación. Por favor, ten en cuenta que evitamos intencionalmente acceder a propiedades
		// como video.BinaryData - porque esta propiedad devuelve un arreglo de bytes que contiene un video completo, lo que luego
		// causa que los bytes se carguen en memoria. Usamos video.GetStream, que devolverá un Stream - y NO
		// requiere que carguemos todo el video en la memoria.
		using (Stream presVideoStream = video.GetStream())
		{
			using (FileStream outputFileStream = File.OpenWrite($"video{index}.avi"))
			{
				int bytesRead;
				while ((bytesRead = presVideoStream.Read(buffer, 0, buffer.Length)) > 0)
				{
					outputFileStream.Write(buffer, 0, bytesRead);
				}
			}
		}

		// El consumo de memoria se mantendrá bajo independientemente del tamaño del video o de la presentación,
	}

	// Si es necesario, puedes aplicar los mismos pasos para archivos de audio. 
}
```

### **Agregar Imagen como BLOB en la Presentación**
Con métodos de la interfaz [**IImageCollection**](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) y la clase [**ImageCollection**](https://reference.aspose.com/slides/net/aspose.slides/imagecollection), puedes agregar una imagen grande como un flujo para que sea tratada como un BLOB.

Este código en C# te muestra cómo agregar una imagen grande a través del proceso BLOB:

```c#
string pathToLargeImage = "large_image.jpg";

// crea una nueva presentación a la que se añadirá la imagen.
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// Vamos a agregar la imagen a la presentación - elegimos el comportamiento KeepLocked porque no
		// tenemos intención de acceder al archivo "largeImage.png".
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Guarda la presentación. Mientras se genera una presentación grande, el consumo de memoria 
		// se mantiene bajo a lo largo del ciclo de vida del objeto pres.
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```

## **Memoria y Presentaciones Grandes**

Típicamente, para cargar una presentación grande, las computadoras requieren una gran cantidad de memoria temporal. Todo el contenido de la presentación se carga en la memoria y el archivo (del cual se cargó la presentación) deja de ser utilizado.

Considera una gran presentación de PowerPoint (large.pptx) que contiene un archivo de video de 1.5 GB. El método estándar para cargar la presentación se describe en este código C#:

```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

Pero este método consume alrededor de 1.6 GB de memoria temporal.

### **Cargar una Presentación Grande como BLOB**

A través del proceso que involucra un BLOB, puedes cargar una presentación grande mientras usas poca memoria. Este código C# describe la implementación donde se utiliza el proceso BLOB para cargar un archivo de presentación grande (large.pptx):

```c#
LoadOptions loadOptions = new LoadOptions
{
   BlobManagementOptions = new BlobManagementOptions
   {
       PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
       IsTemporaryFilesAllowed = true
   }
};
 
using (Presentation pres = new Presentation("large.pptx", loadOptions))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

### **Cambiar la Carpeta para Archivos Temporales**

Cuando se utiliza el proceso BLOB, tu computadora crea archivos temporales en la carpeta predeterminada para archivos temporales. Si deseas que los archivos temporales se mantengan en una carpeta diferente, puedes cambiar la configuración de almacenamiento utilizando `TempFilesRootPath`:

```c#
LoadOptions loadOptions = new LoadOptions
{
   BlobManagementOptions = new BlobManagementOptions
   {
       PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
       IsTemporaryFilesAllowed = true,
       TempFilesRootPath = "temp"
   }
};
```

{{% alert title="Info" color="info" %}}

Cuando utilizas `TempFilesRootPath`, Aspose.Slides no crea automáticamente una carpeta para almacenar archivos temporales. Debes crear la carpeta manualmente.

{{% /alert %}}