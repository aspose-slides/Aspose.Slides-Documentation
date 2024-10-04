---
title: Gestionar Blob
type: docs
weight: 10
url: /es/cpp/manage-blob/
keywords: "Agregar blob, Exportar blob, Agregar imagen como blob, Presentación de PowerPoint, C++, Aspose.Slides para C++"
description: "Agregar blob a la presentación de PowerPoint en C++. Exportar blob. Agregar imagen como blob"
---

## **Acerca de BLOB**

**BLOB** (**Objeto Binario Grande**) es generalmente un elemento grande (foto, presentación, documento o medio) guardado en formatos binarios. 

Aspose.Slides para C++ te permite utilizar BLOBs para objetos de una manera que reduce el consumo de memoria cuando se trabaja con archivos grandes. 

## **Usar BLOB para Reducir el Consumo de Memoria**

### **Agregar Archivo Grande a través de BLOB a una Presentación**

[Aspose.Slides](/slides/es/cpp/) para C++ te permite agregar archivos grandes (en este caso, un archivo de video grande) a través de un proceso que implica BLOBs para reducir el consumo de memoria.

Este código en C++ te muestra cómo agregar un archivo de video grande a través del proceso BLOB a una presentación:

```cpp
const String pathToVeryLargeVideo = u"veryLargeVideo.avi";

// Crea una nueva presentación a la que se añadirá el video
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToVeryLargeVideo, FileMode::Open);
// Vamos a agregar el video a la presentación - elegimos el comportamiento KeepLocked porque no
// tenemos intención de acceder al archivo "veryLargeVideo.avi".
auto video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddVideoFrame(0.0f, 0.0f, 480.0f, 270.0f, video);

// Guarda la presentación. Mientras se genera una presentación grande, el consumo de memoria
// se mantiene bajo durante todo el ciclo de vida del objeto pres 
pres->Save(u"presentationWithLargeVideo.pptx", SaveFormat::Pptx);
```


### **Exportar Archivo Grande a Través de BLOB desde la Presentación**
Aspose.Slides para C++ te permite exportar archivos grandes (en este caso, un archivo de audio o video) a través de un proceso que implica BLOB desde presentaciones. Por ejemplo, puede que necesites extraer un gran archivo multimedia de una presentación, pero no quieres que el archivo se cargue en la memoria de tu computadora. Al exportar el archivo a través del proceso BLOB, puedes mantener el consumo de memoria bajo. 

Este código en C++ demuestra la operación descrita:

```cpp
const String hugePresentationWithAudiosAndVideosFile = u"Large  Video File Test1.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

// Crea una instancia de Presentación, bloquea el archivo "hugePresentationWithAudiosAndVideos.pptx".

auto pres = System::MakeObject<Presentation>(hugePresentationWithAudiosAndVideosFile, loadOptions);
// Vamos a guardar cada video en un archivo. Para prevenir un alto consumo de memoria, necesitamos un buffer que se
// utilizará para transferir los datos del flujo de video de la presentación a un flujo para un nuevo archivo de video creado.
auto buffer = System::MakeArray<uint8_t>(8 * 1024, 0);

// Itera a través de los videos
for (int32_t index = 0; index < pres->get_Videos()->get_Count(); ++index)
{
	auto video = pres->get_Videos()->idx_get(index);

	// Abre el flujo de video de la presentación. Por favor, ten en cuenta que evitamos intencionalmente acceder a métodos
	// como video->get_BinaryData - porque este método devuelve un array de bytes que contiene un video completo, lo que luego
	// provoca que los bytes se carguen en memoria. Usamos video->GetStream, que devolverá Stream - y NO
	// requiere que carguemos todo el video en la memoria.
	
	auto presVideoStream = video->GetStream();

	auto outputFileStream = File::OpenWrite(String::Format(u"video{0}.avi", index));
	int32_t bytesRead;
	while ((bytesRead = presVideoStream->Read(buffer, 0, buffer->get_Length())) > 0)
	{
		outputFileStream->Write(buffer, 0, bytesRead);
	}
		
	// El consumo de memoria se mantendrá bajo independientemente del tamaño del video o la presentación.
}

// Si es necesario, puedes aplicar los mismos pasos para archivos de audio.
```

### **Agregar Imagen como BLOB en la Presentación**
Con los métodos de la interfaz [**IImageCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) y la clase [**ImageCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.image_collection), puedes agregar una imagen grande como un flujo para que sea tratada como un BLOB. 

Este código en C++ te muestra cómo agregar una imagen grande a través del proceso BLOB:

```cpp
const String pathToLargeImage = u"large_image.jpg";

// crea una nueva presentación a la que se añadirá la imagen.
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToLargeImage, FileMode::Open);
// Vamos a agregar la imagen a la presentación - elegimos el comportamiento KeepLocked porque no tenemos
// INTENCIÓN de acceder al archivo "largeImage.png".
auto img = pres->get_Images()->AddImage(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, 300.0f, 200.0f, img);

// Guarda la presentación. Mientras se genera una presentación grande, el consumo de memoria 
// se mantiene bajo durante todo el ciclo de vida del objeto pres
pres->Save(u"presentationWithLargeImage.pptx", SaveFormat::Pptx);
```

## **Memoria y Presentaciones Grandes**

Normalmente, para cargar una presentación grande, las computadoras requieren mucha memoria temporal. Todo el contenido de la presentación se carga en la memoria y el archivo (desde el cual se cargó la presentación) deja de ser utilizado. 

Considera una presentación de PowerPoint grande (large.pptx) que contiene un archivo de video de 1.5 GB. El método estándar para cargar la presentación se describe en este código en C++:

```cpp
auto pres = System::MakeObject<Presentation>(u"large.pptx");
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

Pero este método consume alrededor de 1.6 GB de memoria temporal. 

### **Cargar una Presentación Grande como BLOB**

A través del proceso que implica un BLOB, puedes cargar una presentación grande utilizando poca memoria. Este código en C++ describe la implementación donde se utiliza el proceso BLOB para cargar un archivo de presentación grande (large.pptx):

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);

auto pres = System::MakeObject<Presentation>(u"large.pptx", loadOptions);
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

#### **Cambiar la Carpeta para Archivos Temporales**

Cuando se utiliza el proceso BLOB, tu computadora crea archivos temporales en la carpeta predeterminada para archivos temporales. Si deseas que los archivos temporales se guarden en una carpeta diferente, puedes cambiar la configuración de almacenamiento utilizando `TempFilesRootPath`:

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);
blobManagementOptions->set_TempFilesRootPath(u"temp");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);
```

{{% alert title="Info" color="info" %}}

Cuando usas `TempFilesRootPath`, Aspose.Slides no crea automáticamente una carpeta para almacenar archivos temporales. Tienes que crear la carpeta manualmente. 

{{% /alert %}}