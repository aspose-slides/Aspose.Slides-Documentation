---
title: Открытие презентаций в C++
linktitle: Открыть презентацию
type: docs
weight: 20
url: /ru/cpp/open-presentation/
keywords:
- открыть PowerPoint
- открыть OpenDocument
- открыть презентацию
- открыть PPTX
- открыть PPT
- открыть ODP
- загрузить презентацию
- загрузить PPTX
- загрузить PPT
- загрузить ODP
- защищённая презентация
- большая презентация
- внешний ресурс
- двоичный объект
- C++
- Aspose.Slides
description: "Легко открывайте презентации PowerPoint (.pptx, .ppt) и OpenDocument (.odp) с помощью Aspose.Slides для C++ — быстро, надёжно, полностью функционально."
---

## **Обзор**

Помимо создания презентаций PowerPoint с нуля, Aspose.Slides также позволяет открывать существующие презентации. После загрузки презентации вы можете получать информацию о ней, редактировать содержимое слайдов, добавлять новые слайды, удалять существующие и многое другое.

## **Открытие презентаций**

Чтобы открыть существующую презентацию, создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) и передайте путь к файлу в его конструктор.

Следующий пример на C++ показывает, как открыть презентацию и получить количество слайдов:
```cpp
// Создайте объект класса Presentation и передайте путь к файлу в его конструктор.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Выведите общее количество слайдов в презентации.
Console::WriteLine(presentation->get_Slides()->get_Count());

presentation->Dispose();
```


## **Открытие защищённых паролем презентаций**

Когда необходимо открыть презентацию, защищённую паролем, передайте пароль через метод [set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/) класса [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) для расшифровки и загрузки. Ниже приведён код на C++, демонстрирующий эту операцию:
```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
    
// Выполните операции над расшифрованной презентацией.

presentation->Dispose();
```


## **Открытие больших презентаций**

Aspose.Slides предоставляет варианты — в частности метод [get_BlobManagementOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) класса [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) — для помощи при загрузке больших презентаций.

Следующий код на C++ демонстрирует загрузку большой презентации (например, 2 ГБ):
```cpp
auto filePath = u"LargePresentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
// Выберите поведение KeepLocked — файл презентации останется заблокированным в течение всего времени жизни
// экземпляра Presentation, но его не требуется загружать в память или копировать во временный файл.
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
loadOptions->get_BlobManagementOptions()->set_IsTemporaryFilesAllowed(true);
loadOptions->get_BlobManagementOptions()->set_MaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 МБ

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

// Большая презентация загружена и может использоваться, при этом потребление памяти остается низким.

// Внесите изменения в презентацию.
presentation->get_Slide(0)->set_Name(u"Large presentation");

// Сохраните презентацию в другой файл. Потребление памяти остаётся низким во время этой операции.
presentation->Save(u"LargePresentation-copy.pptx", SaveFormat::Pptx);

// Не делайте этого! Будет выброшено исключение ввода‑вывода, потому что файл заблокирован до тех пор, пока объект презентации не будет уничтожен.
File::Delete(filePath);

presentation->Dispose();

// Здесь это можно сделать. Исходный файл больше не заблокирован объектом презентации.
File::Delete(filePath);
```


{{% alert color="info" title="Info" %}}
Чтобы обойти некоторые ограничения при работе с потоками, Aspose.Slides может копировать содержимое потока. Загрузка большой презентации из потока приводит к копированию презентации и может замедлить процесс загрузки. Поэтому, когда необходимо загрузить большую презентацию, настоятельно рекомендуется использовать путь к файлу презентации, а не поток.

При создании презентации, содержащей большие объекты (видео, аудио, изображения высокого разрешения и т.п.), можно использовать [BLOB management](/slides/ru/cpp/manage-blob/) для снижения потребления памяти.
{{%/alert %}}

## **Управление внешними ресурсами**

Aspose.Slides предоставляет интерфейс [IResourceLoadingCallback](https://reference.aspose.com/slides/cpp/aspose.slides/iresourceloadingcallback/), позволяющий управлять внешними ресурсами. Ниже показан код на C++, демонстрирующий использование интерфейса `IResourceLoadingCallback`:
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
                // Загрузить заменяющее изображение.
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
            // Установить заменяющий URL.
            args->set_Uri(u"http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }

        // Пропустить все остальные изображения.
        return ResourceLoadingAction::Skip;
    }
};
```

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
```


## **Загрузка презентаций без встроенных двоичных объектов**

Презентация PowerPoint может содержать следующие типы встроенных двоичных объектов:

- VBA‑проект (доступно через [IPresentation::get_VbaProject](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_vbaproject/));
- Данные встроенного OLE‑объекта (доступно через [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/));
- Двоичные данные ActiveX‑контроля (доступно через [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_activexcontrolbinary/)).

С помощью метода [ILoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/cpp/aspose.slides/iloadoptions/set_deleteembeddedbinaryobjects/) можно загрузить презентацию без каких‑либо встроенных двоичных объектов.

Этот метод полезен для удаления потенциально вредоносного двоичного содержимого. Ниже показан код на C++, демонстрирующий загрузку презентации без встроенного двоичного контента:
```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"malware.ppt", loadOptions);

// Выполните операции над презентацией.

presentation->Dispose();
```


## **FAQ**

**Как определить, что файл повреждён и его нельзя открыть?**

При загрузке будет выброшено исключение, связанное с разбором или проверкой формата. Такие ошибки часто указывают на недопустимую структуру ZIP‑архива или повреждённые записи PowerPoint.

**Что происходит, если при открытии отсутствуют необходимые шрифты?**

Файл откроется, но дальнейшее [rendering/export](/slides/ru/cpp/convert-presentation/) может заменить шрифты. Настройте подстановку шрифтов с помощью [Configure font substitutions](/slides/ru/cpp/font-substitution/) или добавьте требуемые шрифты через [add the required fonts](/slides/ru/cpp/custom-font/) в среду выполнения.

**Что происходит с встроенными медиа (видео/аудио) при открытии?**

Они становятся доступными как ресурсы презентации. Если медиа ссылки указывают внешние пути, убедитесь, что эти пути доступны в вашей среде; иначе [rendering/export](/slides/ru/cpp/convert-presentation/) может опустить медиа.