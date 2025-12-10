---
title: Administrar BLOBs de Presentación en C++ para un Uso Eficiente de Memoria
linktitle: Administrar BLOB
type: docs
weight: 10
url: /es/cpp/manage-blob/
keywords:
- objeto grande
- elemento grande
- archivo grande
- agregar BLOB
- exportar BLOB
- agregar imagen como BLOB
- reducir memoria
- consumo de memoria
- presentación grande
- archivo temporal
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Administre los datos BLOB en Aspose.Slides para C++ para agilizar las operaciones de archivos PowerPoint y OpenDocument y manejar presentaciones de manera eficiente."
---

## **Acerca de BLOB**

**BLOB** (**Binary Large Object**) suele ser un elemento grande (foto, presentación, documento o medio) guardado en formatos binarios.

Aspose.Slides para C++ le permite usar BLOBs para objetos de una manera que reduce el consumo de memoria cuando se trata de archivos grandes.

## **Utilizar BLOB para reducir el consumo de memoria**

### **Agregar un archivo grande mediante BLOB a una presentación**

[Aspose.Slides](/slides/es/cpp/) para C++ permite agregar archivos grandes (en este caso, un archivo de video grande) mediante un proceso que involucra BLOBs para reducir el consumo de memoria.

Este código en C++ muestra cómo agregar un archivo de video grande mediante el proceso BLOB a una presentación:
```cpp
const String pathToVeryLargeVideo = u"veryLargeVideo.avi";

// Crea una nueva presentación a la que se agregará el video
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToVeryLargeVideo, FileMode::Open);
// Agreguemos el video a la presentación - elegimos el comportamiento KeepLocked porque
// no tenemos la intención de acceder al archivo "veryLargeVideo.avi" file.
auto video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddVideoFrame(0.0f, 0.0f, 480.0f, 270.0f, video);

// Guarda la presentación. Mientras se genera una presentación grande, el consumo de memoria
// permanece bajo durante el ciclo de vida del objeto pres
pres->Save(u"presentationWithLargeVideo.pptx", SaveFormat::Pptx);
```


### **Exportar un archivo grande mediante BLOB desde una presentación**

Aspose.Slides para C++ permite exportar archivos grandes (en este caso, un archivo de audio o video) mediante un proceso que involucra BLOBs desde presentaciones. Por ejemplo, puede necesitar extraer un archivo multimedia grande de una presentación pero no desea que el archivo se cargue en la memoria de su computadora. Al exportar el archivo mediante el proceso BLOB, mantiene bajo el consumo de memoria.

Este código en C++ demuestra la operación descrita:
```cpp
const String hugePresentationWithAudiosAndVideosFile = u"Large  Video File Test1.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

// Crea una instancia de Presentation y bloquea el archivo "hugePresentationWithAudiosAndVideos.pptx" file.

auto pres = System::MakeObject<Presentation>(hugePresentationWithAudiosAndVideosFile, loadOptions);
// Guardemos cada video en un archivo. Para evitar un alto consumo de memoria, necesitamos un búfer que se utilizará
// para transferir los datos del flujo de video de la presentación a un flujo para un nuevo archivo de video.
auto buffer = System::MakeArray<uint8_t>(8 * 1024, 0);

// Recorre los videos
for (int32_t index = 0; index < pres->get_Videos()->get_Count(); ++index)
{
    auto video = pres->get_Videos()->idx_get(index);

    // Abre el flujo de video de la presentación. Tenga en cuenta que evitamos intencionalmente acceder a los métodos
    // como video->get_BinaryData - porque este método devuelve un arreglo de bytes que contiene el video completo, lo que entonces
    // causa que los bytes se carguen en memoria. Usamos video->GetStream, que devolverá Stream - y NO
    // requiere que carguemos todo el video en la memoria.
    
    auto presVideoStream = video->GetStream();

    auto outputFileStream = File::OpenWrite(String::Format(u"video{0}.avi", index));
    int32_t bytesRead;
    while ((bytesRead = presVideoStream->Read(buffer, 0, buffer->get_Length())) > 0)
    {
        outputFileStream->Write(buffer, 0, bytesRead);
    }
        
    // El consumo de memoria permanecerá bajo sin importar el tamaño del video o de la presentación,
}

// Si es necesario, puede aplicar los mismos pasos para los archivos de audio.
```



### **Agregar una imagen como BLOB a una presentación**

Con los métodos de la interfaz [**IImageCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) y la clase [**ImageCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.image_collection) puede agregar una imagen grande como flujo para que se trate como un BLOB.

Este código en C++ muestra cómo agregar una imagen grande mediante el proceso BLOB:
```cpp
const String pathToLargeImage = u"large_image.jpg";

// crea una nueva presentación a la que se agregará la imagen.
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToLargeImage, FileMode::Open);
// Agreguemos la imagen a la presentación - elegimos el comportamiento KeepLocked porque
// NO tenemos la intención de acceder al archivo "largeImage.png".
auto img = pres->get_Images()->AddImage(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, 300.0f, 200.0f, img);

// Guarda la presentación. Mientras se genera una presentación grande, el consumo de memoria 
// permanece bajo durante el ciclo de vida del objeto pres
pres->Save(u"presentationWithLargeImage.pptx", SaveFormat::Pptx);
```


## **Memoria y presentaciones grandes**

Normalmente, para cargar una presentación grande, las computadoras requieren mucha memoria temporal. Todo el contenido de la presentación se carga en la memoria y el archivo (del cual se cargó la presentación) deja de usarse.

Considere una presentación de PowerPoint grande (large.pptx) que contiene un archivo de video de 1,5 GB. El método estándar para cargar la presentación se describe en este código C++:
```cpp
auto pres = System::MakeObject<Presentation>(u"large.pptx");
pres->Save(u"large.pdf", SaveFormat::Pdf);
```


Sin embargo, este método consume alrededor de 1,6 GB de memoria temporal.

### **Cargar una presentación grande como BLOB**

Mediante el proceso que involucra un BLOB, puede cargar una presentación grande usando poca memoria. Este código C++ describe la implementación donde se utiliza el proceso BLOB para cargar un archivo de presentación grande (large.pptx):
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

Cuando se utiliza el proceso BLOB, su computadora crea archivos temporales en la carpeta predeterminada para archivos temporales. Si desea que los archivos temporales se guarden en una carpeta diferente, puede cambiar la configuración de almacenamiento usando `TempFilesRootPath`:
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

## **Preguntas frecuentes**

**¿Qué datos en una presentación de Aspose.Slides se tratan como BLOB y son controlados por las opciones de BLOB?**

Los objetos binarios grandes, como imágenes, audio y video, se tratan como BLOB. Todo el archivo de la presentación también implica manejo de BLOB cuando se carga o guarda. Estos objetos están regidos por políticas de BLOB que le permiten gestionar el uso de memoria y volcar a archivos temporales cuando sea necesario.

**¿Dónde configuro las reglas de manejo de BLOB durante la carga de la presentación?**

Utilice [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) con [BlobManagementOptions](https://reference.aspose.com/slides/cpp/aspose.slides/blobmanagementoptions/). Allí establece el límite en memoria para BLOB, permite o prohibe archivos temporales, elige la ruta raíz para los archivos temporales y selecciona el comportamiento de bloqueo de origen.

**¿Afectan las configuraciones de BLOB al rendimiento y cómo equilibrar velocidad vs memoria?**

Sí. Mantener BLOB en memoria maximiza la velocidad pero incrementa el consumo de RAM; reducir el límite de memoria desplaza más trabajo a archivos temporales, disminuyendo la RAM a costa de I/O adicional. Use el método [set_MaxBlobsBytesInMemory](https://reference.aspose.com/slides/cpp/aspose.slides/blobmanagementoptions/set_maxblobsbytesinmemory/) para alcanzar el equilibrio adecuado para su carga de trabajo y entorno.

**¿Ayudan las opciones de BLOB al abrir presentaciones extremadamente grandes (p. ej., varios gigabytes)?**

Sí. [BlobManagementOptions](https://reference.aspose.com/slides/cpp/aspose.slides/blobmanagementoptions/) están diseñadas para esos escenarios: habilitar archivos temporales y usar bloqueo de origen puede reducir significativamente el uso máximo de RAM y estabilizar el procesamiento de presentaciones muy grandes.

**¿Puedo usar políticas de BLOB al cargar desde flujos en lugar de archivos en disco?**

Sí. Las mismas reglas se aplican a los flujos: la instancia de la presentación puede poseer y bloquear el flujo de entrada (según el modo de bloqueo elegido), y se utilizan archivos temporales cuando están permitidos, manteniendo predecible el uso de memoria durante el procesamiento.