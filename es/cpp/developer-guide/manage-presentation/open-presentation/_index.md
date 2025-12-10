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
description: "Abra presentaciones de PowerPoint (.pptx, .ppt) y OpenDocument (.odp) sin esfuerzo con Aspose.Slides para C++ — rápido, confiable y con todas las funciones."
---

## **Descripción general**

Además de crear presentaciones de PowerPoint desde cero, Aspose.Slides también le permite abrir presentaciones existentes. Después de cargar una presentación, puede obtener información sobre ella, editar el contenido de las diapositivas, agregar nuevas diapositivas, eliminar las existentes y mucho más.

## **Abrir presentaciones**

Para abrir una presentación existente, instancie la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) y pase la ruta del archivo a su constructor.

El siguiente ejemplo en C++ muestra cómo abrir una presentación y obtener el número de diapositivas:
```cpp
// Instanciar la clase Presentation y pasar una ruta de archivo a su constructor.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Imprimir el número total de diapositivas en la presentación.
Console::WriteLine(presentation->get_Slides()->get_Count());

presentation->Dispose();
```


## **Abrir presentaciones protegidas con contraseña**

Cuando necesite abrir una presentación protegida con contraseña, pase la contraseña mediante el método [set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/) de la clase [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) para descifrarla y cargarla. El siguiente código C++ muestra esta operación:
```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
    
// Realizar operaciones en la presentación descifrada.

presentation->Dispose();
```


## **Abrir presentaciones grandes**

Aspose.Slides ofrece opciones, en particular el método [get_BlobManagementOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) de la clase [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/), para ayudarle a cargar presentaciones grandes.

El siguiente código C++ demuestra cómo cargar una presentación grande (por ejemplo, 2 GB):
```cpp
auto filePath = u"LargePresentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
// Elija el comportamiento KeepLocked: el archivo de presentación permanecerá bloqueado durante la vida útil de
// la instancia Presentation, pero no es necesario cargarlo en memoria ni copiarlo a un archivo temporal.
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
loadOptions->get_BlobManagementOptions()->set_IsTemporaryFilesAllowed(true);
loadOptions->get_BlobManagementOptions()->set_MaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

// La gran presentación se ha cargado y puede usarse, mientras el consumo de memoria permanece bajo.

// Realizar cambios en la presentación.
presentation->get_Slide(0)->set_Name(u"Large presentation");

// Guardar la presentación en otro archivo. El consumo de memoria permanece bajo durante esta operación.
presentation->Save(u"LargePresentation-copy.pptx", SaveFormat::Pptx);

// ¡No haga esto! Se lanzará una excepción de E/S porque el archivo está bloqueado hasta que se elimine el objeto Presentation.
File::Delete(filePath);

presentation->Dispose();

// Está bien hacerlo aquí. El archivo de origen ya no está bloqueado por el objeto Presentation.
File::Delete(filePath);
```


{{% alert color="info" title="Info" %}}
Para superar ciertas limitaciones al trabajar con flujos, Aspose.Slides puede copiar el contenido de un flujo. Cargar una presentación grande desde un flujo hace que la presentación se copie y puede ralentizar la carga. Por lo tanto, cuando necesite cargar una presentación grande, recomendamos encarecidamente usar la ruta del archivo de la presentación en lugar de un flujo.

Al crear una presentación que contiene objetos grandes (video, audio, imágenes de alta resolución, etc.), puede usar [BLOB management](/slides/es/cpp/manage-blob/) para reducir el consumo de memoria.
{{%/alert %}}

## **Controlar recursos externos**

Aspose.Slides proporciona la interfaz [IResourceLoadingCallback](https://reference.aspose.com/slides/cpp/aspose.slides/iresourceloadingcallback/) que le permite gestionar recursos externos. El siguiente código C++ muestra cómo utilizar la interfaz `IResourceLoadingCallback`:
```cpp
class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        if (args->get_OriginalUri().EndsWith(u".jpg"))
        {
            try
            {
                // Cargar una imagen de sustitución.
                auto imageData = File::ReadAllBytes(u"aspose-logo.jpg");
                args->SetData(imageData);
                return ResourceLoadingAction::UserProvided;
            }
            catch (Exception&)
            {
                return ResourceLoadingAction::Skip;
            }
        }
        else if (args->get_OriginalUri().EndsWith(u".png"))
        {
            // Establecer una URL de sustitución.
            args->set_Uri(u"http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }

        // Omitir todas las demás imágenes.
        return ResourceLoadingAction::Skip;
    }
};
```

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
```


## **Cargar presentaciones sin objetos binarios incrustados**

Una presentación de PowerPoint puede contener los siguientes tipos de objetos binarios incrustados:

- proyecto VBA (accesible mediante [IPresentation::get_VbaProject](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_vbaproject/));
- datos incrustados de objeto OLE (accesibles mediante [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/));
- datos binarios de control ActiveX (accesibles mediante [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_activexcontrolbinary/)).

Usando el método [ILoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/cpp/aspose.slides/iloadoptions/set_deleteembeddedbinaryobjects/), puede cargar una presentación sin ningún objeto binario incrustado.

Este método es útil para eliminar contenido binario potencialmente malicioso. El siguiente código C++ muestra cómo cargar una presentación sin contenido binario incrustado:
```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"malware.ppt", loadOptions);

// Perform operations on the presentation.

presentation->Dispose();
```


## **Preguntas frecuentes**

**¿Cómo puedo saber que un archivo está dañado y no se puede abrir?**

Recibirá una excepción de validación de análisis/formato durante la carga. Estos errores a menudo mencionan una estructura ZIP inválida o registros de PowerPoint dañados.

**¿Qué ocurre si faltan fuentes requeridas al abrir la presentación?**

El archivo se abrirá, pero posteriormente el [rendering/export](/slides/es/cpp/convert-presentation/) puede sustituir fuentes. [Configure font substitutions](/slides/es/cpp/font-substitution/) o [add the required fonts](/slides/es/cpp/custom-font/) al entorno de ejecución.

**¿Qué pasa con los medios incrustados (video/audio) al abrir la presentación?**

Se convierten en recursos de la presentación. Si los medios se referencian mediante rutas externas, asegúrese de que esas rutas sean accesibles en su entorno; de lo contrario, el [rendering/export](/slides/es/cpp/convert-presentation/) puede omitir los medios.