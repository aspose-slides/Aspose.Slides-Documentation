---
title: Abrir presentaciones en C++
linktitle: Abrir presentación
type: docs
weight: 20
url: /es/cpp/open-presentation/
keywords:
- abrir PowerPoint
- abrir OpenDocument
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
- C++
- Aspose.Slides
description: "Aprende a abrir presentaciones de PowerPoint y OpenDocument en C++, proporcionar contraseñas de apertura, controlar la carga de recursos y reducir el uso de memoria con Aspose.Slides para C++."
---
## **Introducción**

[Aspose.Slides for C++](https://products.aspose.com/slides/es/cpp/) puede cargar presentaciones de PowerPoint y OpenDocument desde archivos y flujos. Después de cargar una presentación, puedes inspeccionar su estructura, editar diapositivas, gestionar recursos y guardarla en el formato original u otro formato compatible.

El comportamiento de carga puede personalizarse a través de la clase [LoadOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides/loadoptions/). Por ejemplo, puedes proporcionar una contraseña de apertura, mantener objetos binarios grandes fuera de la memoria, controlar recursos externos u omitir datos binarios incrustados.

## **Abrir presentaciones**

Para abrir una presentación existente, pasa su ruta de archivo al constructor de [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/). Libera la presentación después de usarla para que los manejadores de archivo, datos temporales y otros recursos se liberen rápidamente.

El siguiente ejemplo en C++ muestra cómo abrir una presentación y obtener el número de diapositivas:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **Abrir presentaciones protegidas con contraseña**

Una contraseña de apertura cifra el contenido de la presentación. Para cargar la presentación completa, pasa la contraseña correcta a [LoadOptions::set_Password](https://reference.aspose.com/slides/es/cpp/aspose.slides/loadoptions/set_password/) y pasa las opciones al constructor de [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/). La carga falla cuando la contraseña falta o es incorrecta.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = MakeObject<Presentation>(u"encrypted-presentation.pptx", loadOptions);

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

Para la detección, validación y flujos de trabajo de cifrado de contraseñas, consulta [Password-Protect Presentations](/slides/es/cpp/password-protected-presentation/). Si una presentación cifrada se guardó deliberadamente con propiedades de documento públicas, esas propiedades pueden leerse sin contraseña; véase [Manage Presentation Properties](/slides/es/cpp/presentation-properties/).

## **Abrir presentaciones grandes**

[LoadOptions::get_BlobManagementOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) controla cómo Aspose.Slides gestiona objetos binarios grandes como imágenes, audio y vídeo. Puedes mantener el archivo fuente bloqueado, permitir archivos temporales y limitar la cantidad de datos BLOB retenidos en memoria.

El siguiente código en C++ demuestra la carga de una presentación grande (por ejemplo, 2 GB):

```cpp
#include <DOM/ISlide.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IBlobManagementOptions.h>
#include <PresentationLockingBehavior.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String filePath = u"large-presentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
auto blobOptions = loadOptions->get_BlobManagementOptions();
blobOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobOptions->set_IsTemporaryFilesAllowed(true);
blobOptions->set_MaxBlobsBytesInMemory(10 * 1024 * 1024);

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

presentation->get_Slide(0)->set_Name(u"Large presentation");
presentation->Save(u"large-presentation-copy.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

{{% alert color="info" title="Nota" %}}

Con `PresentationLockingBehavior::KeepLocked`, el archivo de origen permanece bloqueado hasta que el objeto `Presentation` se libere. No mueva, sobrescriba ni elimine el archivo de origen mientras ese objeto esté activo.

Aspose.Slides puede copiar el contenido de un flujo de entrada mientras lo carga. Para presentaciones grandes, una ruta de archivo suele ser más eficiente que un flujo. Consulte [Manage BLOBs](/slides/es/cpp/manage-blob/) para opciones adicionales de almacenamiento y gestión de memoria.

{{% /alert %}}

## **Controlar recursos externos**

[LoadOptions::set_ResourceLoadingCallback](https://reference.aspose.com/slides/es/cpp/aspose.slides/loadoptions/set_resourceloadingcallback/) acepta una implementación de [IResourceLoadingCallback](https://reference.aspose.com/slides/es/cpp/aspose.slides/iresourceloadingcallback/). La devolución de llamada puede proporcionar datos de reemplazo, redirigir un recurso, usar el cargador predeterminado o omitir el recurso. Esto es útil cuando las presentaciones contienen imágenes externas que deben resolverse según reglas de seguridad o almacenamiento específicas de la aplicación.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IResourceLoadingArgs.h>
#include <IResourceLoadingCallback.h>
#include <ResourceLoadingAction.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        auto isJpeg = args->get_OriginalUri().EndsWith(u".jpg", StringComparison::OrdinalIgnoreCase);
        if (!isJpeg || !File::Exists(u"approved-image.jpg"))
        {
            return ResourceLoadingAction::Skip;
        }

        auto imageData = File::ReadAllBytes(u"approved-image.jpg");
        args->SetData(imageData);
        return ResourceLoadingAction::UserProvided;
    }
};

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"presentation-with-external-images.pptx", loadOptions);
Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **Cargar presentaciones sin objetos binarios incrustados**

Una presentación puede contener datos binarios incrustados que una aplicación no necesita o no desea conservar. Ejemplos incluyen:

- proyectos VBA, accesibles a través de [IPresentation::get_VbaProject](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentation/get_vbaproject/);
- datos OLE incrustados, accesibles a través de [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/es/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/);
- datos de controles ActiveX, accesibles a través de [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/es/cpp/aspose.slides/icontrol/get_activexcontrolbinary/).

Pasa `true` a [LoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/es/cpp/aspose.slides/loadoptions/set_deleteembeddedbinaryobjects/) para eliminar estos datos binarios durante la carga. Guarda la presentación cargada para conservar el resultado sanitizado.

Esta opción reduce la exposición a contenidos incrustados no deseados, pero no constituye un sistema completo de detección de malware o de sanitización de contenido.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"presentation-with-embedded-data.pptx", loadOptions);

presentation->Save(u"presentation-without-embedded-data.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Preguntas frecuentes**

**¿Cómo puedo saber si un archivo está corrupto y no se puede abrir?**

Aspose.Slides lanza una excepción de análisis o de formato durante la carga. Maneja esa falla por separado de un error de contraseña incorrecta para que la aplicación pueda informar la causa con precisión.

**¿Qué ocurre si faltan fuentes necesarias?**

La presentación aún puede cargarse, pero la renderización y exportación pueden sustituir fuentes. Puedes [configurar la sustitución de fuentes](/slides/es/cpp/font-substitution/) o [proveer fuentes personalizadas](/slides/es/cpp/custom-font/) para que la salida sea más predecible.

**¿La carga de una presentación también carga sus medios incrustados?**

El audio y vídeo incrustados quedan disponibles a través del modelo de objetos de la presentación. Los recursos externos se resuelven según el comportamiento de carga de recursos configurado y pueden no estar disponibles si sus ubicaciones no pueden accederse.