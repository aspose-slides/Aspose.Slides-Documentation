---
title: Gestionar BLOBs de presentaciones en .NET para un uso eficiente de la memoria
linktitle: Gestionar BLOB
type: docs
weight: 10
url: /es/net/manage-blob/
keywords:
- objeto grande
- elemento grande
- archivo grande
- añadir BLOB
- exportar BLOB
- añadir imagen como BLOB
- reducir memoria
- consumo de memoria
- presentación grande
- archivo temporal
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Gestionar datos BLOB en Aspose.Slides para .NET para optimizar las operaciones con archivos PowerPoint y OpenDocument y lograr un manejo eficaz de las presentaciones."
---
## **Visión general**

Aspose.Slides proporciona un manejo basado en BLOB para datos binarios grandes en presentaciones, lo que ayuda a reducir el consumo de memoria al trabajar con imágenes, audio, vídeo y archivos de presentación de gran tamaño.

Este artículo muestra cómo utilizar el procesamiento basado en BLOB para añadir medios de gran tamaño a una presentación, exportar medios de gran tamaño desde una presentación y cargar presentaciones voluminosas de manera más eficiente. También explica cómo se pueden usar archivos temporales durante el procesamiento y cómo cambiar la carpeta utilizada para almacenarlos.

## **Acerca de BLOB**

**BLOB** (**Binary Large Object**) suele ser un elemento grande (foto, presentación, documento o medio) guardado en formatos binarios. 

Aspose.Slides para .NET le permite usar BLOBs para objetos de forma que se reduzca el consumo de memoria cuando se manejan archivos de gran tamaño. 

## **Usar BLOB para reducir el consumo de memoria**

### **Agregar un archivo grande mediante BLOB a una presentación**

[Aspose.Slides](/slides/es/net/) para .NET permite añadir archivos grandes (en este caso, un archivo de vídeo grande) mediante un proceso que involucra BLOBs para reducir el consumo de memoria.

Este fragmento de C# muestra cómo añadir un archivo de vídeo grande mediante el proceso BLOB a una presentación:

```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// Crea una nueva presentación a la que se añadirá el vídeo
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // Vamos a añadir el vídeo a la presentación - elegimos el comportamiento KeepLocked porque
        // no tenemos la intención de acceder al archivo "veryLargeVideo.avi".
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // Guarda la presentación. Mientras se genera una presentación grande, el consumo de memoria
        // se mantiene bajo durante el ciclo de vida del objeto pres 
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```


### **Exportar un archivo grande mediante BLOB desde una presentación**
Aspose.Slides para .NET le permite exportar archivos grandes (en este caso, un archivo de audio o vídeo) mediante un proceso que involucra BLOBs desde presentaciones. Por ejemplo, puede necesitar extraer un archivo de medios grande de una presentación pero no quiere que el archivo se cargue en la memoria de su ordenador. Al exportar el archivo mediante el proceso BLOB, mantiene bajo el consumo de memoria. 

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

// Crea una instancia de Presentation y bloquea el archivo "hugePresentationWithAudiosAndVideos.pptx".
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// Guardemos cada vídeo en un archivo. Para evitar un alto consumo de memoria, necesitamos un búfer que se usará
	// para transferir los datos del flujo de vídeo de la presentación a un flujo para un archivo de vídeo recién creado.
	byte[] buffer = new byte[8 * 1024];

	// Recorre los vídeos
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// Abre el flujo de vídeo de la presentación. Tenga en cuenta que intencionalmente evitamos acceder a propiedades
		// como video.BinaryData - porque esta propiedad devuelve una matriz de bytes que contiene un vídeo completo, lo que entonces
		// hace que los bytes se carguen en memoria. Usamos video.GetStream, que devolverá Stream y NO
		//  requiere que carguemos todo el vídeo en memoria.
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

		// El consumo de memoria seguirá bajo sin importar el tamaño del vídeo o de la presentación,
	}

	// Si es necesario, puede aplicar los mismos pasos a los archivos de audio. 
}
```

### **Añadir una imagen como BLOB a una presentación**
Con los métodos de la interfaz [**IImageCollection**](https://reference.aspose.com/slides/es/net/aspose.slides/iimagecollection) y de la clase [**ImageCollection** ](https://reference.aspose.com/slides/es/net/aspose.slides/imagecollection), puede añadir una imagen grande como flujo para que se trate como un BLOB. 

Este código C# muestra cómo añadir una imagen grande mediante el proceso BLOB:

```c#
string pathToLargeImage = "large_image.jpg";

// crea una nueva presentación a la que se añadirá la imagen.
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// Vamos a añadir la imagen a la presentación - elegimos el comportamiento KeepLocked porque
		// NO pretendemos acceder al archivo "largeImage.png" file.
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Guarda la presentación. Mientras se genera una presentación grande, el consumo de memoria 
		// se mantiene bajo durante el ciclo de vida del objeto pres
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```

## **Memoria y presentaciones grandes**

Normalmente, para cargar una presentación grande, los ordenadores necesitan mucha memoria temporal. Todo el contenido de la presentación se carga en la memoria y el archivo (del que se cargó la presentación) deja de utilizarse. 

Considere una presentación de PowerPoint grande (large.pptx) que contiene un archivo de vídeo de 1,5 GB. El método estándar para cargar la presentación se describe en este código C#:

```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

Pero este método consume alrededor de 1,6 GB de memoria temporal. 

### **Cargar una presentación grande como BLOB**

Mediante el proceso que involucra un BLOB, puede cargar una presentación grande utilizando poca memoria. Este código C# describe la implementación donde se usa el proceso BLOB para cargar un archivo de presentación grande (large.pptx):

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

### **Cambiar la carpeta para archivos temporales**

Cuando se usa el proceso BLOB, su ordenador crea archivos temporales en la carpeta predeterminada para archivos temporales. Si desea que los archivos temporales se guarden en una carpeta distinta, puede cambiar la configuración de almacenamiento usando `TempFilesRootPath`:

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
Al usar `TempFilesRootPath`, Aspose.Slides no crea automáticamente una carpeta para almacenar los archivos temporales. Debe crear la carpeta manualmente. 
{{% /alert %}}

### **Desechar los objetos de presentación para liberar memoria**

Al procesar presentaciones grandes, asegúrese de que la instancia de [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) se libere correctamente para que se libere la memoria que ocupaba. La forma recomendada es usar una instrucción o declaración `using` como se muestra en los ejemplos anteriores; elimina automáticamente la presentación y libera los recursos no administrados cuando se sale del bloque.

Si crea una presentación sin un bloque `using`, llame explícitamente a `Dispose()` después de haber terminado de usarla.

```cs
Presentation presentation = new Presentation("large.pptx");

// ...procesar la presentación...
presentation.Save("large.pdf", SaveFormat.Pdf);

// Liberar recursos explícitamente.
presentation.Dispose();
```

## **Preguntas frecuentes**

**¿Qué datos en una presentación de Aspose.Slides se tratan como BLOB y están controlados por las opciones BLOB?**

Los objetos binarios grandes, como imágenes, audio y vídeo, se tratan como BLOB. Todo el archivo de la presentación también implica la gestión de BLOB cuando se carga o guarda. Estos objetos están regidos por políticas BLOB que le permiten gestionar el uso de memoria y volcar a archivos temporales cuando sea necesario.

**¿Dónde configuro las reglas de gestión de BLOB durante la carga de una presentación?**

Utilice [LoadOptions](https://reference.aspose.com/slides/es/net/aspose.slides/loadoptions/) con [BlobManagementOptions](https://reference.aspose.com/slides/es/net/aspose.slides/blobmanagementoptions/). Allí establece el límite en memoria para BLOB, permite o impide los archivos temporales, elige la ruta raíz para los archivos temporales y selecciona el comportamiento de bloqueo de origen.

**¿Afectan los ajustes de BLOB al rendimiento y cómo equilibrar velocidad y memoria?**

Sí. Mantener BLOB en memoria maximiza la velocidad pero incrementa el consumo de RAM; reducir el límite de memoria transfiere más trabajo a archivos temporales, reduciendo la RAM a costa de I/O adicional. Ajuste el umbral [MaxBlobsBytesInMemory](https://reference.aspose.com/slides/es/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/) para conseguir el equilibrio adecuado para su carga de trabajo y entorno.

**¿Ayudan las opciones BLOB al abrir presentaciones extremadamente grandes (p. ej., gigabytes)?**

Sí. Las [BlobManagementOptions](https://reference.aspose.com/slides/es/net/aspose.slides/blobmanagementoptions/) están diseñadas para dichos escenarios: habilitar archivos temporales y usar bloqueo de origen puede reducir significativamente el uso máximo de RAM y estabilizar el procesamiento de presentaciones muy grandes.

**¿Puedo usar políticas BLOB al cargar desde flujos en lugar de archivos en disco?**

Sí. Las mismas reglas se aplican a los flujos: la instancia de presentación puede poseer y bloquear el flujo de entrada (según el modo de bloqueo seleccionado), y se usan archivos temporales cuando están permitidos, manteniendo predecible el uso de memoria durante el procesamiento.