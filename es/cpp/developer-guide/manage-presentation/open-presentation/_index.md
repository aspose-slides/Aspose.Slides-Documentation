---
title: Abrir Presentación - API de PowerPoint C++
linktitle: Abrir Presentación
type: docs
weight: 20
url: /cpp/open-presentation/
keywords: "Abrir PowerPoint, PPTX, PPT, Abrir Presentación, Cargar Presentación, C++, CPP"
description: "Abrir o cargar Presentación PPT, PPTX, ODP en C++"
---

Además de crear presentaciones de PowerPoint desde cero, Aspose.Slides te permite abrir presentaciones existentes. Después de cargar una presentación, puedes obtener información sobre la presentación, editar la presentación (contenido en sus diapositivas), agregar nuevas diapositivas o eliminar las existentes, etc.

## Abrir Presentación

Para abrir una presentación existente, simplemente tienes que instanciar la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) y pasar la ruta del archivo (de la presentación que deseas abrir) a su constructor.

Este código C++ te muestra cómo abrir una presentación y también averiguar cuántas diapositivas contiene:

```c++
// La ruta al directorio de documentos.
String dataDir = u"";

// Instancia la clase Presentation y pasa la ruta del archivo a su constructor
auto pres = System::MakeObject<Presentation>(dataDir + u"OpenPresentation.pptx");

// Imprime el número total de diapositivas presentes en la presentación
Console::WriteLine(Convert::ToString(pres->get_Slides()->get_Count()));
```

## **Abrir Presentación Protegida por Contraseña**

Cuando tengas que abrir una presentación protegida por contraseña, puedes pasar la contraseña a través de la propiedad [get_Password()](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/get_password/) (de la clase [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/)) para descifrar la presentación y cargar la presentación. Este código C++ demuestra la operación:

```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);
// Haz algo con la presentación descifrada
```

## Abrir Presentación Grande

Aspose.Slides proporciona opciones (la propiedad [BlobManagementOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) en particular) bajo la clase [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) para permitirte cargar presentaciones grandes.

Este C++ demuestra una operación en la que se carga una presentación grande (digamos de 2GB de tamaño):

```c++
String pathToVeryLargePresentationFile = u"veryLargePresentation.pptx";

{
    SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
    // elijamos el comportamiento KeepLocked - la "veryLargePresentation.pptx" estará bloqueada durante
    // la vida útil de la instancia de Presentation, pero no necesitamos cargarla en memoria ni copiarla en
    // el archivo temporal
    loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

    auto pres = System::MakeObject<Presentation>(pathToVeryLargePresentationFile, loadOptions);

    // La presentación grande ha sido cargada y puede ser utilizada, pero el consumo de memoria sigue siendo bajo.

    // Realiza cambios en la presentación.
    pres->get_Slides()->idx_get(0)->set_Name(u"Presentación muy grande");

    // La presentación se guardará en el otro archivo. El consumo de memoria se mantiene bajo durante la operación
    pres->Save(u"veryLargePresentation-copy.pptx", SaveFormat::Pptx);

    // ¡No se puede hacer eso! Se lanzará una excepción de IO porque el archivo está bloqueado mientras los objetos pres no serán
    // eliminados
    File::Delete(pathToVeryLargePresentationFile);
}

// Está bien hacerlo aquí. El archivo fuente no está bloqueado por el objeto pres
File::Delete(pathToVeryLargePresentationFile);
```

{{% alert color="info" title="Información" %}}

Para sortear ciertas limitaciones al interactuar con flujos, Aspose.Slides puede copiar el contenido del flujo. Cargar una presentación grande a través de su flujo dará como resultado la copia del contenido de la presentación y causará una carga lenta. Por lo tanto, cuando pretendas cargar una presentación grande, te recomendamos encarecidamente que uses la ruta del archivo de la presentación y no su flujo.

Cuando quieras crear una presentación que contenga grandes objetos (video, audio, imágenes grandes, etc.), puedes utilizar la [facilidad de Blob](https://docs.aspose.com/slides/cpp/manage-blob/) para reducir el consumo de memoria.

{{%/alert %}} 

## Cargar Presentación

Aspose.Slides proporciona [IResourceLoadingCallback](https://reference.aspose.com/slides/cpp/aspose.slides/iresourceloadingcallback/) con un método único para permitirte gestionar recursos externos. Este código C++ te muestra cómo usar la interfaz `IResourceLoadingCallback`:

```c++
// La ruta al directorio de documentos.
System::String dataDir = GetDataPath();

auto opts = System::MakeObject<LoadOptions>();
opts->set_ResourceLoadingCallback(System::MakeObject<ImageLoadingHandler>(dataDir));
auto presentation = System::MakeObject<Presentation>(dataDir + u"presentation.pptx", opts);
```

```c++
class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ImageLoadingHandler(String dataDir)
        : m_dataDir(dataDir)
    {
    }

    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        if (args->get_OriginalUri().EndsWith(u".jpg"))
        {
            try
            {
                System::ArrayPtr<uint8_t> imageBytes = File::ReadAllBytes(Path::Combine(m_dataDir, u"aspose-logo.jpg"));
                args->SetData(imageBytes);
                return ResourceLoadingAction::UserProvided;
            }
            catch (System::Exception&)
            {
                return ResourceLoadingAction::Skip;
            }
        }

        if (args->get_OriginalUri().EndsWith(u".png"))
        {
            // Establece la url de sustitución
            args->set_Uri(u"http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }

        // Salta todas las demás imágenes
        return ResourceLoadingAction::Skip;
    }
    
private:
    String m_dataDir;
};
```

<h2>Abrir y Guardar Presentación</h2>

<a name="cplusplus-open-save-presentation"><strong>Pasos: Abrir y Guardar Presentación en C++</strong></a>

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) y pasa el archivo que deseas abrir.

2. Guarda la presentación.

   ```c++
   	const String outPath = u"../out/SaveToFile_out.ppt";
   	
   	SharedPtr<Presentation> pres = MakeObject<Presentation>();
   
   	// pres->get_ProtectionManager()->Encrypt(u"pass");
   	// ...haz algún trabajo aquí..
   
   	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
   ```