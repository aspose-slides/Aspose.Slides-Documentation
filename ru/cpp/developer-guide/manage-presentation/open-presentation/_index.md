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
- бинарный объект
- C++
- Aspose.Slides
description: "Узнайте, как открывать презентации PowerPoint и OpenDocument на C++, задавать пароли для открытия, управлять загрузкой ресурсов и снижать использование памяти с помощью Aspose.Slides для C++."
---
## **Введение**

[Aspose.Slides для C++](https://products.aspose.com/slides/ru/cpp/) может загружать презентации PowerPoint и OpenDocument из файлов и потоков. После загрузки презентации вы можете просматривать её структуру, редактировать слайды, управлять ресурсами и сохранять её в исходном или другом поддерживаемом формате.

Поведение загрузки можно настроить с помощью класса [LoadOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides/loadoptions/). Например, вы можете указать пароль для открытия, хранить большие бинарные объекты вне памяти, управлять внешними ресурсами или исключить встроенные бинарные данные.

## **Открытие презентаций**

После загрузки файла или потока вы можете [определить его оригинальный формат презентации](/slides/ru/cpp/detect-presentation-source-format/), чтобы выбрать способ обработки вашим приложением.

Чтобы открыть существующую презентацию, передайте путь к её файлу в конструктор [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/). Освобождайте объект презентации после использования, чтобы дескрипторы файлов, временные данные и другие ресурсы были быстро освобождены.

Следующий пример на C++ показывает, как открыть презентацию и получить количество её слайдов:

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

## **Открытие презентаций с паролем**

Пароль для открытия шифрует содержимое презентации. Чтобы загрузить полную презентацию, передайте правильный пароль в [LoadOptions::set_Password](https://reference.aspose.com/slides/ru/cpp/aspose.slides/loadoptions/set_password/) и передайте параметры в конструктор [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/). Загрузка завершится неудачей, если пароль отсутствует или неверен.

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

Для обнаружения пароля, проверки и рабочих процессов шифрования см. [Password-Protect Presentations](/slides/ru/cpp/password-protected-presentation/). Если зашифрованная презентация была намеренно сохранена с публичными свойствами документа, эти свойства можно прочитать без пароля; см. [Manage Presentation Properties](/slides/ru/cpp/presentation-properties/).

## **Открытие больших презентаций**

[LoadOptions::get_BlobManagementOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) управляет тем, как Aspose.Slides обрабатывает большие бинарные объекты, такие как изображения, аудио и видео. Вы можете оставить исходный файл заблокированным, разрешить создание временных файлов и ограничить объём BLOB‑данных, удерживаемых в памяти.

Следующий код на C++ демонстрирует загрузку большой презентации (например, 2 ГБ):

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

{{% alert color="info" title="Note" %}}
С помощью `PresentationLockingBehavior::KeepLocked` исходный файл остаётся заблокированным до тех пор, пока объект `Presentation` не будет освобождён. Не перемещайте, не перезаписывайте и не удаляйте исходный файл, пока объект жив.
Aspose.Slides может копировать содержимое входного потока во время загрузки. Для больших презентаций путь к файлу, как правило, эффективнее, чем поток. См. [Manage BLOBs](/slides/ru/cpp/manage-blob/) для дополнительных вариантов хранения и управления памятью.
{{% /alert %}}

## **Управление внешними ресурсами**

[LoadOptions::set_ResourceLoadingCallback](https://reference.aspose.com/slides/ru/cpp/aspose.slides/loadoptions/set_resourceloadingcallback/) принимает реализацию [IResourceLoadingCallback](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iresourceloadingcallback/). Обратный вызов может предоставить заменяющие данные, перенаправить ресурс, использовать загрузчик по умолчанию или пропустить ресурс. Это полезно, когда презентации содержат внешние изображения, которые необходимо разрешать в соответствии с правилами безопасности или хранения, специфичными для приложения.

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

## **Загрузка презентаций без встроенных бинарных объектов**

Презентация может содержать встроенные бинарные данные, которые приложению не нужны или которые не требуется сохранять. Примеры:

- проекты VBA, доступные через [IPresentation::get_VbaProject](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/get_vbaproject/);
- встроенные данные OLE, доступные через [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/);
- данные управления ActiveX, доступные через [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icontrol/get_activexcontrolbinary/).

Передайте `true` в [LoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ru/cpp/aspose.slides/loadoptions/set_deleteembeddedbinaryobjects/), чтобы удалить эти бинарные данные во время загрузки. Сохраните загруженную презентацию, чтобы зафиксировать очищенный результат.

Эта опция уменьшает риск появления нежелательных встроенных полезных нагрузок, но не является полноценной системой обнаружения вредоносного кода или санитаризации контента.

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

## **FAQ**

**Как определить, что файл повреждён и его нельзя открыть?**

Aspose.Slides бросает исключение парсинга или формата во время загрузки. Обрабатывайте эту ошибку отдельно от ошибки неверного пароля, чтобы приложение могло точно сообщить причину.

**Что происходит, если требуемые шрифты отсутствуют?**

Презентацию всё равно можно загрузить, но при рендеринге и экспорте шрифты могут быть заменены. Вы можете [настроить замену шрифтов](/slides/ru/cpp/font-substitution/) или [предоставить пользовательские шрифты](/slides/ru/cpp/custom-font/), чтобы сделать вывод более предсказуемым.

**Загружает ли презентация также её встроенные медиа‑файлы?**

Встроенные аудио и видео становятся доступными через объектную модель презентации. Внешние ресурсы разрешаются в соответствии с настроенным поведением загрузки ресурсов и могут быть недоступны, если их расположения недоступны.