---
title: Administrar Blob
type: docs
weight: 10
url: /es/net/manage-blob/
keywords: "Agregar blob, Exportar blob, Agregar imagen como blob, Presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Agregar blob a una presentación de PowerPoint en C# o .NET. Exportar blob. Agregar imagen como blob"
---

## **Acerca de BLOB**

**BLOB** (**Binary Large Object**) suele ser un elemento grande (foto, presentación, documento o medio) guardado en formatos binarios. 

Aspose.Slides para .NET le permite usar BLOBs para objetos de manera que reduzca el consumo de memoria cuando se manejan archivos grandes. 

## **Usar BLOB para Reducir el Consumo de Memoria**

### **Agregar Archivo Grande mediante BLOB a una Presentación**

[Aspose.Slides](/slides/es/net/) para .NET le permite agregar archivos grandes (en este caso, un archivo de video grande) a través de un proceso que involucra BLOBs para reducir el consumo de memoria.

Este C# le muestra cómo agregar un archivo de video grande mediante el proceso BLOB a una presentación:
```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// Crea una nueva presentación a la que se agregará el video
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // Agreguemos el video a la presentación - elegimos el comportamiento KeepLocked porque
        //no pretendemos acceder al archivo "veryLargeVideo.avi" file.
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // Guarda la presentación. Mientras se genera una presentación grande, el consumo de memoria
        // permanece bajo durante el ciclo de vida del objeto pres 
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```


### **Exportar Archivo Grande mediante BLOB desde una Presentación**
Aspose.Slides para .NET le permite exportar archivos grandes (en este caso, un archivo de audio o video) a través de un proceso que involucra BLOBs desde presentaciones. Por ejemplo, puede necesitar extraer un archivo multimedia grande de una presentación pero no desea que el archivo se cargue en la memoria de su computadora. Al exportar el archivo mediante el proceso BLOB, mantiene bajo el consumo de memoria. 

Este código en C# demuestra la operación descrita:
```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// Bloquea el archivo origen y NO lo carga en memoria
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// Crea una instancia de Presentation, bloquea el archivo "hugePresentationWithAudiosAndVideos.pptx".
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// Guardemos cada video en un archivo. Para evitar un alto uso de memoria, necesitamos un buffer que se utilizará
	// para transferir los datos del stream de video de la presentación a un stream para un archivo de video recién creado.
	byte[] buffer = new byte[8 * 1024];

	// Recorre los videos
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// Abre el stream de video de la presentación. Por favor, note que intencionalmente evitamos acceder a propiedades
		// como video.BinaryData - porque esta propiedad devuelve un arreglo de bytes que contiene el video completo, lo que entonces
		// provoca que los bytes se carguen en memoria. Usamos video.GetStream, que devolverá un Stream - y NO
		//  requiere que carguemos el video completo en la memoria.
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

		// El consumo de memoria permanecerá bajo sin importar el tamaño del video o de la presentación,
	}

	// Si es necesario, puede aplicar los mismos pasos para archivos de audio. 
}
```


### **Agregar Imagen como BLOB en la Presentación**
Con los métodos de la interfaz [**IImageCollection**](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) y la clase [**ImageCollection** ](https://reference.aspose.com/slides/net/aspose.slides/imagecollection) puede agregar una imagen grande como flujo para que se trate como un BLOB. 

Este código C# le muestra cómo agregar una imagen grande mediante el proceso BLOB:
```c#
string pathToLargeImage = "large_image.jpg";

// crea una nueva presentación a la que se agregará la imagen.
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// Agreguemos la imagen a la presentación - elegimos el comportamiento KeepLocked porque
		// NO pretendemos acceder al archivo "largeImage.png" file.
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Guarda la presentación. Mientras se genera una presentación grande, el consumo de memoria 
		// se mantiene bajo durante el ciclo de vida del objeto pres
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```


## **Memoria y Presentaciones Grandes**

Normalmente, para cargar una presentación grande, los equipos requieren mucha memoria temporal. Todo el contenido de la presentación se carga en la memoria y el archivo (del cual se cargó la presentación) deja de usarse. 

Considere una presentación de PowerPoint grande (large.pptx) que contiene un archivo de video de 1,5 GB. El método estándar para cargar la presentación se describe en este código C#:
```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```


Pero este método consume alrededor de 1,6 GB de memoria temporal. 

### **Cargar una Presentación Grande como BLOB**

A través del proceso que involucra un BLOB, puede cargar una presentación grande usando poca memoria. Este código C# describe la implementación donde se usa el proceso BLOB para cargar un archivo de presentación grande (large.pptx):
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


### **Cambiar la Carpeta de Archivos Temporales**

Cuando se usa el proceso BLOB, su equipo crea archivos temporales en la carpeta predeterminada para archivos temporales. Si desea que los archivos temporales se guarden en una carpeta diferente, puede cambiar la configuración de almacenamiento usando `TempFilesRootPath`:
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

Al usar `TempFilesRootPath`, Aspose.Slides no crea automáticamente una carpeta para almacenar archivos temporales. Debe **crear** la carpeta manualmente. 

{{% /alert %}}

## **FAQ**

**¿Qué datos en una presentación de Aspose.Slides se tratan como BLOB y están controlados por las opciones de BLOB?**

Objetos binarios grandes como imágenes, audio y video se tratan como BLOB. El archivo completo de la presentación también implica la gestión de BLOB cuando se carga o se guarda. Estos objetos están regidos por políticas de BLOB que le permiten administrar el uso de memoria y volcar a archivos temporales cuando sea necesario.

**¿Dónde configuro las reglas de manejo de BLOB durante la carga de la presentación?**

Utilice [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) con [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/). Allí establece el límite en memoria para BLOB, permite o no archivos temporales, elige la ruta raíz para los archivos temporales y selecciona el comportamiento de bloqueo de la fuente.

**¿Los ajustes de BLOB afectan el rendimiento y cómo equilibrar velocidad vs memoria?**

Sí. Mantener BLOB en memoria maximiza la velocidad pero incrementa el consumo de RAM; reducir el límite de memoria desvía más trabajo a archivos temporales, reduciendo la RAM a costa de I/O adicional. Ajuste el umbral [MaxBlobsBytesInMemory](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/) para lograr el equilibrio adecuado para su carga de trabajo y entorno.

**¿Ayudan las opciones de BLOB al abrir presentaciones extremadamente grandes (por ejemplo, varios gigabytes)?**

Sí. [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/) están diseñadas para esos escenarios: habilitar archivos temporales y usar bloqueo de fuente puede reducir significativamente el uso máximo de RAM y estabilizar el procesamiento de decks muy grandes.

**¿Puedo usar políticas de BLOB al cargar desde streams en lugar de archivos en disco?**

Sí. Las mismas reglas se aplican a los streams: la instancia de la presentación puede poseer y bloquear el stream de entrada (según el modo de bloqueo elegido), y se usan archivos temporales cuando están permitidos, manteniendo predecible el uso de memoria durante el procesamiento.