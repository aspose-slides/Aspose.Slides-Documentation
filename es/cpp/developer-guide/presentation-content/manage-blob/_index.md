---
title: Administrar BLOBs de presentación en C++ para un uso eficiente de la memoria
linktitle: Administrar BLOB
type: docs
weight: 10
url: /es/cpp/manage-blob/
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
- C++
- Aspose.Slides
description: "Gestionar datos BLOB en Aspose.Slides para C++ para optimizar las operaciones de archivos PowerPoint y OpenDocument y lograr un manejo eficiente de presentaciones."
---
## **Visión general**

Aspose.Slides proporciona manejo basado en BLOB para datos binarios grandes en presentaciones, ayudando a reducir el consumo de memoria al trabajar con imágenes, audio, vídeo y archivos de presentación de gran tamaño.

Este artículo muestra cómo usar el procesamiento basado en BLOB para agregar medios grandes a una presentación, exportar medios grandes desde una presentación y cargar presentaciones grandes de manera más eficiente. También explica cómo se pueden usar archivos temporales durante el procesamiento y cómo cambiar la carpeta utilizada para almacenarlos.

## **Acerca de BLOB**

**BLOB** (**Binary Large Object**) suele ser un elemento grande (foto, presentación, documento o medio) guardado en formatos binarios. 

Aspose.Slides for C++ permite usar BLOBs para objetos de forma que se reduzca el consumo de memoria cuando se trata de archivos grandes. 

## **Utilizar BLOB para reducir el consumo de memoria**

### **Agregar un archivo grande mediante BLOB a una presentación**

[Aspose.Slides](/slides/es/cpp/) for C++ permite agregar archivos grandes (en este caso, un archivo de vídeo grande) mediante un proceso que implica BLOBs para reducir el consumo de memoria.

Este código C++ le muestra cómo agregar un archivo de vídeo grande mediante el proceso BLOB a una presentación:

```cpp
const String pathToVeryLargeVideo = u"veryLargeVideo.avi";

// Crea una nueva presentación a la que se añadirá el vídeo
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToVeryLargeVideo, FileMode::Open);
// Añadamos el vídeo a la presentación - elegimos el comportamiento KeepLocked porque
// no pretendemos acceder al archivo "veryLargeVideo.avi" file.
auto video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddVideoFrame(0.0f, 0.0f, 480.0f, 270.0f, video);

// Guarda la presentación. Mientras se genera una presentación grande, el consumo de memoria
// se mantiene bajo durante el ciclo de vida del objeto pres 
pres->Save(u"presentationWithLargeVideo.pptx", SaveFormat::Pptx);
```

### **Exportar un archivo grande mediante BLOB desde una presentación**

Aspose.Slides for C++ permite exportar archivos grandes (en este caso, un archivo de audio o vídeo) mediante un proceso que implica BLOBs desde presentaciones. Por ejemplo, puede necesitar extraer un archivo de medio grande de una presentación pero no desea que el archivo se cargue en la memoria de su computadora. Al exportar el archivo mediante el proceso BLOB, mantiene bajo el consumo de memoria. 

Este código en C++ demuestra la operación descrita:

```cpp
const String hugePresentationWithAudiosAndVideosFile = u"Large  Video File Test1.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

// Crea una instancia de Presentation y bloquea el archivo "hugePresentationWithAudiosAndVideos.pptx".

auto pres = System::MakeObject<Presentation>(hugePresentationWithAudiosAndVideosFile, loadOptions);
// Guardemos cada video en un archivo. Para evitar un alto uso de memoria, necesitamos un búfer que será usado
// para transferir los datos del flujo de video de la presentación a un flujo para un archivo de video recién creado.
auto buffer = System::MakeArray<uint8_t>(8 * 1024, 0);

// Recorre los videos
for (int32_t index = 0; index < pres->get_Videos()->get_Count(); ++index)
{
	auto video = pres->get_Videos()->idx_get(index);

	// Abre el flujo de video de la presentación. Tenga en cuenta que intencionalmente evitamos acceder a métodos
	// como video->get_BinaryData - porque este método devuelve una matriz de bytes que contiene el video completo, lo que
	// hace que los bytes se carguen en memoria. Usamos video->GetStream, que devolverá un Stream y NO
	// requiere que carguemos todo el video en la memoria.
	
	auto presVideoStream = video->GetStream();

	auto outputFileStream = File::OpenWrite(String::Format(u"video{0}.avi", index));
	int32_t bytesRead;
	while ((bytesRead = presVideoStream->Read(buffer, 0, buffer->get_Length())) > 0)
	{
		outputFileStream->Write(buffer, 0, bytesRead);
	}
		
	// El consumo de memoria se mantendrá bajo sin importar el tamaño del video o de la presentación,
}

// Si es necesario, puede aplicar los mismos pasos a los archivos de audio.
```

### **Agregar una imagen como BLOB a una presentación**

Con los métodos de la interfaz [**IImageCollection**](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.i_image_collection) y de la clase [**ImageCollection**](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.image_collection) puede agregar una imagen grande como flujo para que se trate como un BLOB. 

Este código C++ le muestra cómo agregar una imagen grande mediante el proceso BLOB:

```cpp
const String pathToLargeImage = u"large_image.jpg";

// crea una nueva presentación a la que se añadirá la imagen.
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToLargeImage, FileMode::Open);
// Añadamos la imagen a la presentación - elegimos el comportamiento KeepLocked porque
// NO pretendemos acceder al archivo "largeImage.png" file.
auto img = pres->get_Images()->AddImage(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, 300.0f, 200.0f, img);

// Guarda la presentación. Mientras se genera una presentación grande,
// el consumo de memoria se mantiene bajo durante el ciclo de vida del objeto pres
pres->Save(u"presentationWithLargeImage.pptx", SaveFormat::Pptx);
```

## **Memoria y presentaciones grandes**

Normalmente, para cargar una presentación grande, los ordenadores requieren mucha memoria temporal. Todo el contenido de la presentación se carga en la memoria y el archivo (del que se cargó la presentación) deja de usarse. 

Considere una presentación de PowerPoint grande (large.pptx) que contiene un archivo de vídeo de 1,5 GB. El método estándar para cargar la presentación se describe en este código C++:

```cpp
auto pres = System::MakeObject<Presentation>(u"large.pptx");
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

Pero este método consume alrededor de 1,6 GB de memoria temporal. 

### **Cargar una presentación grande como BLOB**

A través del proceso que implica un BLOB, puede cargar una presentación grande usando poca memoria. Este código C++ describe la implementación donde se usa el proceso BLOB para cargar un archivo de presentación grande (large.pptx):

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);

auto pres = System::MakeObject<Presentation>(u"large.pptx", loadOptions);
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

#### **Cambiar la carpeta para archivos temporales**

Cuando se usa el proceso BLOB, su ordenador crea archivos temporales en la carpeta predeterminada para archivos temporales. Si desea que los archivos temporales se guarden en una carpeta distinta, puede cambiar la configuración de almacenamiento usando `TempFilesRootPath`:

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);
blobManagementOptions->set_TempFilesRootPath(u"temp");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);
```

{{% alert title="Info" color="info" %}}
Al usar `TempFilesRootPath`, Aspose.Slides no crea automáticamente una carpeta para almacenar archivos temporales. Debe crear la carpeta manualmente. 
{{% /alert %}}

### **Liberar objetos Presentation para liberar memoria**

Al procesar presentaciones grandes, asegúrese de que la instancia [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) se elimine correctamente para que se libere la memoria que ocupaba. Llame a `Dispose()` después de haber terminado de usar la presentación para liberar recursos no gestionados.

```cpp
auto presentation = System::MakeObject<Presentation>(u"large.pptx");

// ...procesar la presentación...
presentation->Save(u"large.pdf", SaveFormat::Pdf);

// Liberar recursos explícitamente.
presentation->Dispose();
```

## **Preguntas frecuentes**

**¿Qué datos en una presentación de Aspose.Slides se tratan como BLOB y se controlan mediante opciones BLOB?**

Objetos binarios grandes como imágenes, audio y vídeo se tratan como BLOB. El archivo completo de la presentación también implica manejo BLOB cuando se carga o guarda. Estos objetos están sujetos a políticas BLOB que le permiten gestionar el uso de memoria y volcar a archivos temporales cuando sea necesario.

**¿Dónde configuro las reglas de manejo BLOB durante la carga de una presentación?**

Utilice [LoadOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides/loadoptions/) con [BlobManagementOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides/blobmanagementoptions/). Allí establece el límite en memoria para BLOB, permite o prohibe archivos temporales, elige la ruta raíz para los archivos temporales y selecciona el comportamiento de bloqueo de la fuente.

**¿Los ajustes BLOB afectan al rendimiento y cómo equilibrar velocidad y memoria?**

Sí. Mantener BLOB en memoria maximiza la velocidad pero incrementa el consumo de RAM; reducir el límite de memoria desplaza más trabajo a archivos temporales, disminuyendo la RAM a costa de I/O adicional. Use el método [set_MaxBlobsBytesInMemory](https://reference.aspose.com/slides/es/cpp/aspose.slides/blobmanagementoptions/set_maxblobsbytesinmemory/) para encontrar el equilibrio adecuado para su carga de trabajo y entorno.

**¿Ayudan las opciones BLOB al abrir presentaciones extremadamente grandes (p. ej., gigabytes)?**

Sí. [BlobManagementOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides/blobmanagementoptions/) están diseñadas para esos escenarios: habilitar archivos temporales y usar bloqueo de fuente pueden reducir significativamente el pico de uso de RAM y estabilizar el procesamiento de presentaciones muy grandes.

**¿Puedo usar políticas BLOB al cargar desde streams en lugar de archivos en disco?**

Sí. Las mismas reglas se aplican a streams: la instancia de la presentación puede poseer y bloquear el stream de entrada (según el modo de bloqueo elegido), y los archivos temporales se usan cuando están permitidos, manteniendo predecible el uso de memoria durante el procesamiento.