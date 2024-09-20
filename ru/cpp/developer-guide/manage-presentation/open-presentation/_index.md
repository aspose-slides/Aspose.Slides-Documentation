---
title: Открыть Презентацию - C++ PowerPoint API
linktitle: Открыть Презентацию
type: docs
weight: 20
url: /cpp/open-presentation/
keywords: "Открыть PowerPoint, PPTX, PPT, Открыть Презентацию, Загрузить Презентацию, C++, CPP"
description: "Открыть или загрузить Презентацию PPT, PPTX, ODP на C++"
---

Помимо создания презентаций PowerPoint с нуля, Aspose.Slides позволяет открывать существующие презентации. После загрузки презентации вы можете получить информацию о ней, редактировать содержание на слайдами, добавлять новые слайды или удалять существующие и т. д. 

## Открыть Презентацию

Чтобы открыть существующую презентацию, вам просто нужно создать экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) и передать путь к файлу (презентации, которую вы хотите открыть) в его конструктор.

Этот код на C++ показывает, как открыть презентацию и узнать, сколько слайдов она содержит: 

```c++
// Путь к каталогу документов.
String dataDir = u"";

// Создает экземпляр класса Presentation и передает путь к файлу в его конструктор
auto pres = System::MakeObject<Presentation>(dataDir + u"OpenPresentation.pptx");

// Выводит общее количество слайдов в презентации
Console::WriteLine(Convert::ToString(pres->get_Slides()->get_Count()));
```

## **Открыть Защищенную Паролем Презентацию**

Когда вам нужно открыть презентацию, защищенную паролем, вы можете передать пароль через свойство [get_Password()](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/get_password/) (из класса [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/)) для расшифровки и загрузки презентации. Этот код на C++ демонстрирует операцию:

```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"ВАШ_ПАРОЛЬ");
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);
// Выполните некоторые операции с расшифрованной презентацией
```

## Открыть Крупную Презентацию

Aspose.Slides предоставляет параметры (в частности, свойство [BlobManagementOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) в классе [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/)), которые позволяют загружать крупные презентации. 

Этот код на C++ демонстрирует операцию, в которой загружается большая презентация (например, размером 2 ГБ):

```c++
String pathToVeryLargePresentationFile = u"veryLargePresentation.pptx";

{
    SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
    // выбираем поведение KeepLocked - "veryLargePresentation.pptx" будет заблокирован на
    // время существования экземпляра Presentation, но мы не должны загружать его в память или копировать в
    // временный файл
    loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

    auto pres = System::MakeObject<Presentation>(pathToVeryLargePresentationFile, loadOptions);

    // Большая презентация была загружена и может быть использована, но потребление памяти при этом остается низким.

    // Вносит изменения в презентацию.
    pres->get_Slides()->idx_get(0)->set_Name(u"Очень большая презентация");

    // Презентация будет сохранена в другой файл. Потребление памяти остается низким во время операции
    pres->Save(u"veryLargePresentation-copy.pptx", SaveFormat::Pptx);

    // нельзя этого делать! Произойдет исключение I/O, потому что файл заблокирован, пока объекты pres не
    // будут уничтожены
    File::Delete(pathToVeryLargePresentationFile);
}

// Здесь можно это сделать. Исходный файл не заблокирован объектом pres
File::Delete(pathToVeryLargePresentationFile);
```

{{% alert color="info" title="Информация" %}}

Чтобы обойти определенные ограничения при взаимодействии с потоками, Aspose.Slides может копировать содержимое потока. Загрузка крупной презентации через ее поток приведет к копированию содержимого презентации и вызовет медленную загрузку. Поэтому, когда вы собираетесь загрузить крупную презентацию, мы настоятельно рекомендуем использовать путь к файлу презентации, а не его поток.

Когда вы хотите создать презентацию, содержащую большие объекты (видео, аудио, большие изображения и т. д.), вы можете использовать [функциональность Blob](https://docs.aspose.com/slides/cpp/manage-blob/) для снижения потребления памяти.

{{%/alert %}} 

## Загрузить Презентацию

Aspose.Slides предоставляет [IResourceLoadingCallback](https://reference.aspose.com/slides/cpp/aspose.slides/iresourceloadingcallback/) с одним методом, который позволяет управлять внешними ресурсами. Этот код на C++ показывает, как использовать интерфейс `IResourceLoadingCallback`:

```c++
// Путь к каталогу документов.
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
            // Устанавливает заменяющий URL
            args->set_Uri(u"http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }

        // Пропускает все остальные изображения
        return ResourceLoadingAction::Skip;
    }
    
private:
    String m_dataDir;
};
```

<h2>Открыть и Сохранить Презентацию</h2>

<a name="cplusplus-open-save-presentation"><strong>Шаги: Открыть и Сохранить Презентацию на C++</strong></a>

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) и передайте файл, который вы хотите открыть. 

2. Сохраните презентацию. 

   ```c++
   	const String outPath = u"../out/SaveToFile_out.ppt";
   	
   	SharedPtr<Presentation> pres = MakeObject<Presentation>();
   
   	// pres->get_ProtectionManager()->Encrypt(u"pass");
   	// ...выполните некоторые операции здесь..
   
   	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
   ```