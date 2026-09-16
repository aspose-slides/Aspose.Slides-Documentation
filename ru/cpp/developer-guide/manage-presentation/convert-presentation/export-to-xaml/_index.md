---
title: "Экспорт презентаций в XAML на C++"
linktitle: "Презентация в XAML"
type: docs
weight: 30
url: /ru/cpp/export-to-xaml/
keywords:
- экспорт PowerPoint
- экспорт OpenDocument
- экспорт презентации
- конвертировать PowerPoint
- конвертировать OpenDocument
- конвертировать презентацию
- PowerPoint в XAML
- OpenDocument в XAML
- презентация в XAML
- PPT в XAML
- PPTX в XAML
- ODP в XAML
- сохранить PPT как XAML
- сохранить PPTX как XAML
- сохранить ODP как XAML
- экспортировать PPT в XAML
- экспортировать PPTX в XAML
- экспортировать ODP в XAML
- C++
- Aspose.Slides
description: "Конвертировать слайды PowerPoint и OpenDocument в XAML на C++ с помощью Aspose.Slides — быстрое решение без Office, сохраняющее макет неизменным."
---
## **Обзор**

Эта статья объясняет, как экспортировать презентации PowerPoint в XAML с помощью Aspose.Slides. Она включает краткое введение в XAML, показывает, как сохранить презентацию в XAML с настройками по умолчанию, и демонстрирует, как настроить экспорт через [XamlOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export.xaml/xamloptions/), включая экспорт скрытых слайдов. Статья также отвечает на несколько часто задаваемых вопросов, связанных с запасными шрифтами, совместимостью стеков XAML и поведением при экспорте скрытых слайдов.

## **О XAML**

XAML — это основанный на XML язык разметки, используемый для описания пользовательских интерфейсов в таких фреймворках, как WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) и Xamarin.Forms.

С XAML‑файлами можно работать в визуальном дизайнере или писать и редактировать разметку напрямую.

## **Экспорт презентаций в XAML с параметрами по умолчанию**

Следующий пример на C++ показывает, как экспортировать презентацию в XAML с настройками по умолчанию:

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
presentation->Save(xamlOptions);
```

По умолчанию экспортированные слайды сохраняются в подпапке `pres` текущего рабочего каталога процесса, как возвращает [Directory::GetCurrentDirectory](https://reference.aspose.com/slides/ru/cpp/system.io/directory/getcurrentdirectory/). Папка создаётся автоматически, и любые необходимые изображения также сохраняются там.

Имя выходной папки берётся из имени исходного файла без расширения. Для `pres.pptx` выходные файлы именуются `pres/Slide_1.xaml`, `pres/Slide_2.xaml` и т.д. Даже если указать абсолютный путь к входной презентации, выходная папка создаётся относительно текущего рабочего каталога, а не рядом с исходным файлом.

## **Экспорт презентаций в XAML с пользовательскими параметрами**

Используйте интерфейс [IXamlOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export.xaml/ixamloptions/) для управления тем, как Aspose.Slides экспортирует презентацию в XAML.

Чтобы сохранить результат в пользовательском месте, реализуйте [IXamlOutputSaver](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export.xaml/ixamloutputsaver/) и передайте экземпляр вашей реализации в метод [set_OutputSaver](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) класса [XamlOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export.xaml/xamloptions/).

Чтобы включить скрытые слайды в XAML‑вывод, передайте `true` в метод [set_ExportHiddenSlides](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/), как показано в следующем примере на C++:

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);
presentation->Save(xamlOptions);
```

## **Сбор всех сгенерированных артефактов XAML**

Экспорт XAML может создавать документ XAML для каждого экспортированного слайда, а также отдельные изображения и вспомогательные ресурсы. Передайте собственный [IXamlOutputSaver](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export.xaml/ixamloutputsaver/) в [XamlOptions::set_OutputSaver](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/), чтобы получать эти артефакты вместо использования сохранения в файловой системе по умолчанию. Запустите экспорт через XAML‑специфичный перегрузку [Presentation::Save](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/save/), принимающую параметры XAML.

### **Понимание жизненного цикла обратного вызова**

Экспортер вызывает [IXamlOutputSaver::Save](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export.xaml/ixamloutputsaver/save/) отдельно для каждого сгенерированного артефакта:

- `path` идентифицирует артефакт и может включать относительные каталоги. Сохраните эту информацию, поскольку XAML может ссылаться на ресурсы с помощью относительных путей.
- `data` содержит байты артефакта. Изображения и другие бинарные ресурсы не должны декодироваться как текст.
- Сохранитель отвечает за сохранение или удержание данных до возвращения. Примеры копируют каждый массив байтов во владение приложением.
- Считайте экспорт успешным только после завершения операции сохранения презентации и успешного выполнения всех обратных вызовов. Не гасите ошибки хранилища и не инициируйте незаметные фоновые записи. Если постоянное хранение происходит позже, сообщайте об общем успехе только после успешного завершения этого шага.
- [XamlOptions::set_ExportHiddenSlides](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) также применяется к пользовательскому сохранителю. Значение по умолчанию, `false`, исключает XAML‑документы скрытых слайдов. Установка `true` включает их и любые ресурсы, необходимые для их экспорта. Количество ресурсов зависит от презентации; не предполагайте один обратный вызов на слайд или фиксированный порядок вызовов.

### **Экспорт в память и инспекция артефактов**

Этот полный пример загружает `pres.pptx`, собирает каждый артефакт в [Dictionary<String, ArrayPtr<uint8_t>>](https://reference.aspose.com/slides/ru/cpp/system.collections.generic/dictionary/), и выводит его имя, тип и количество байтов. Имена сохраняются точно так, как переданы. Дублирующиеся имена приводят к ошибке сбора вместо тихой перезаписи артефакта.

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/IXamlOutputSaver.h>
#include <Export/Xaml/XamlOptions.h>
#include <system/array.h>
#include <system/collections/dictionary.h>
#include <system/console.h>
#include <system/string_comparer.h>
#include <system/io/path.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace System::Text;

class InMemoryXamlExample
{
    class MemoryXamlSaver : public IXamlOutputSaver
    {
    public:
        using ArtifactDictionary = Dictionary<String, ArrayPtr<uint8_t>>;
        SharedPtr<ArtifactDictionary> Artifacts = MakeObject<ArtifactDictionary>(StringComparer::get_Ordinal());

        void Save(String path, ArrayPtr<uint8_t> data) override
        {
            auto retainedData = data->Clone();
            Artifacts->Add(path, retainedData);
        }
    };

public:
    static void Run()
    {
        auto saver = MakeObject<MemoryXamlSaver>();
        auto presentation = MakeObject<Presentation>(u"pres.pptx");
        auto options = MakeObject<XamlOptions>();
        options->set_OutputSaver(saver);
        options->set_ExportHiddenSlides(true);
        presentation->Save(options);

        auto inspectXamlText = false;
        for (const auto& artifact : saver->Artifacts)
        {
            auto extension = Path::GetExtension(artifact.get_Key()).ToLowerInvariant();
            auto isXaml = extension == u".xaml";
            auto isImage = extension == u".png" || extension == u".jpg" || extension == u".jpeg" || extension == u".gif" || extension == u".bmp" || extension == u".tif" || extension == u".tiff" || extension == u".svg";
            String kind = isXaml ? u"slide XAML" : isImage ? u"image" : u"supporting resource";
            Console::WriteLine(u"{0}: {1} bytes ({2})", artifact.get_Key(), artifact.get_Value()->get_Length(), kind);

            // Декодировать только XAML, и только когда требуется текстовая проверка.
            if (isXaml && inspectXamlText)
            {
                auto markup = Encoding::get_UTF8()->GetString(artifact.get_Value());
                Console::WriteLine(markup);
            }
        }
    }
};
```

Вызовите `InMemoryXamlExample::Run` из вашего приложения. Проверки расширений полезны для инспекции; сохраняйте все артефакты, включая незнакомые типы ресурсов. Оставляйте байты неизменными при хранении или передаче. Используйте [Encoding::GetString](https://reference.aspose.com/slides/ru/cpp/system.text/encoding/getstring/) с кодировкой UTF-8 только для XAML, требующего текстовой обработки.

### **Упаковать собранные артефакты в ZIP‑архив**

Этот независимый пример собирает экспорт, проверяет имена и записывает оригинальные байты в ZIP‑архив. Уникальное имя архива разделяет параллельные задания экспорта. Записи ZIP используют прямые слеши и сохраняют относительные каталоги. Недопустимые имена или имена, конфликтующие после нормализации, отклоняют весь пакет до его записи.

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/IXamlOutputSaver.h>
#include <Export/Xaml/XamlOptions.h>
#include <system/array.h>
#include <system/collections/dictionary.h>
#include <system/console.h>
#include <system/string_comparer.h>
#include <system/guid.h>
#include <system/io/file_access.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/path.h>
#include <zip/zip_file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace Aspose::Zip;

class ZipXamlExample
{
    class CollectedXamlSaver : public IXamlOutputSaver
    {
    public:
        using ArtifactDictionary = Dictionary<String, ArrayPtr<uint8_t>>;
        SharedPtr<ArtifactDictionary> Artifacts = MakeObject<ArtifactDictionary>(StringComparer::get_Ordinal());

        void Save(String path, ArrayPtr<uint8_t> data) override
        {
            auto retainedData = data->Clone();
            Artifacts->Add(path, retainedData);
        }
    };

public:
    static void Run()
    {
        auto saver = MakeObject<CollectedXamlSaver>();
        auto presentation = MakeObject<Presentation>(u"pres.pptx");
        auto options = MakeObject<XamlOptions>();
        options->set_OutputSaver(saver);
        options->set_ExportHiddenSlides(false);
        presentation->Save(options);

        auto entries = MakeObject<Dictionary<String, ArrayPtr<uint8_t>>>(StringComparer::get_OrdinalIgnoreCase());
        for (const auto& artifact : saver->Artifacts)
        {
            auto entryName = artifact.get_Key().Replace(u'\\', u'/');
            auto segments = entryName.Split(u'/');
            auto unsafeName = entryName.StartsWith(u"/", StringComparison::Ordinal) || entryName.Contains(u":");
            for (const auto& segment : segments)
            {
                unsafeName |= String::IsNullOrWhiteSpace(segment) || segment == u"." || segment == u"..";
            }

            if (unsafeName || entries->ContainsKey(entryName))
            {
                Console::WriteLine(u"Export rejected: unsafe or duplicate artifact name: {0}", artifact.get_Key());
                return;
            }
            entries->Add(entryName, artifact.get_Value());
        }

        auto jobId = Guid::NewGuid();
        auto archivePath = u"xaml-" + jobId.ToString(u"N") + u".zip";
        auto archive = MakeObject<ZipFile>();
        for (const auto& artifact : entries)
        {
            auto fileName = Path::GetFileName(artifact.get_Key());
            auto directoryName = Path::GetDirectoryName(artifact.get_Key()).Replace(u'\\', u'/');
            archive->AddEntry(fileName, directoryName, artifact.get_Value());
        }

        auto output = MakeObject<FileStream>(archivePath, FileMode::CreateNew, FileAccess::Write);
        archive->Save(output);
        output->Close();
        archive->Dispose();

        // Save завершает каталог ZIP; закройте файл перед сообщением об успехе.
        Console::WriteLine(u"Saved {0} artifacts to {1}", entries->get_Count(), archivePath);
    }
};
```

Вызовите `ZipXamlExample::Run` из вашего приложения. Пример использует `Aspose::Zip::ZipFile` из C++‑рантайма для записи одного локального архива; сам экспортер не записывает отдельные XAML‑ или графические файлы. Для удалённого хранилища замените этап записи архива загрузкой собранных массивов байтов. Используйте идентификатор задания экспорта плюс полный относительный путь артефакта в качестве ключа блоба, либо сохраняйте идентификатор задания, относительное имя и бинарные данные в строке базы данных. Публикуйте задание только после завершения всех загрузок или фиксации транзакции БД. При неудаче очистите частичный вывод.

Для больших презентаций пользовательский сохранитель может сохранять каждый артефакт напрямую в хранилище приложения, чтобы избежать удержания полной копии экспорта в памяти. Экспортер всё равно собирает все сгенерированные артефакты в памяти перед вызовом сохранителя. Сохраняйте каждый обратный вызов синхронным с точки зрения экспортера: возвращайте управление только после того, как получатель принял байты, и позволяйте ошибкам достичь вызывающего кода.

### **Сохранить имена ресурсов и проверить ссылки**

- Нормализуйте разделители путей, если это требует назначение, но сохраняйте относительные каталоги. Не используйте только [Path::GetFileName](https://reference.aspose.com/slides/ru/cpp/system.io/path/getfilename/), если только не уверены, что каждое сгенерированное имя уникально и ссылки на ресурсы остаются валидными.
- Применяйте проверку имён, специфичную для назначения. При записи разрозненных файлов отклоняйте абсолютные пути и сегменты перехода, определяйте окончательный путь с помощью [Path::GetFullPath](https://reference.aspose.com/slides/ru/cpp/system.io/path/getfullpath/), и проверяйте, что он остаётся внутри целевого каталога экспорта, включая разделитель в проверке containment. Используйте контролируемый каталог без символических ссылок, которые могут перенаправлять записи.
- Используйте отдельный сохранитель и пространство имён хранилища для каждого задания экспорта. Обнаруживайте коллизии после нормализации разделителей и в соответствии с правилами чувствительности к регистру назначения.
- Перед публикацией разбирайте каждый XAML‑документ как XML и проверяйте его ссылки на файловые ресурсы, такие как атрибуты `Source` или `ImageSource` у изображений. Разрешайте каждый относительный URI относительно каталога содержащего артефакт XAML, нормализуйте полученное имя хранилища и подтверждайте, что соответствующий ключ словаря, запись ZIP или сохранённый объект существует. Обрабатывайте внешние URI и XAML‑выражения отдельно от относительных имён файлов.

Например, если `pres/Slide_1.xaml` ссылается на `images/image1.png`, сохранённый ресурс должен быть доступен как `pres/images/image1.png`. Сохранение только `image1.png` нарушит эту связь. Для объектного хранилища сохраняйте ту же структуру под префиксом задания и делайте эти URL‑ы ресурсов доступными потребителю XAML. Перезапустите завершённый ZIP для проверки имён записей и байтов ресурсов, а также загрузите представительные слайды в целевой XAML‑окружении, чтобы убедиться, что изображения корректно разрешаются.

## **Вопросы и ответы**

**Как обеспечить предсказуемый набор шрифтов, если исходный шрифт недоступен на машине?**

Используйте [set_DefaultRegularFont](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) в [XamlOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export.xaml/xamloptions/) — он применяется в качестве запасного шрифта во время экспорта, когда оригинал отсутствует. Это не гарантирует, что сгенерированный XAML будет ссылаться на запасной шрифт или что шрифт будет доступен на целевой машине. Убедитесь, что шрифты, указанные в XAML, доступны в окружении, где он отображается.

**Экспортированный XAML предназначен только для WPF или его можно использовать и в других XAML‑стэках?**

Aspose.Slides экспортирует WPF‑XAML через публичный API. Совместимость с другими стэками XAML, такими как UWP и Xamarin.Forms, не гарантируется. Протестируйте сгенерированную разметку в целевом окружении.

**Поддерживаются ли скрытые слайды и как предотвратить их экспорт по умолчанию?**

По умолчанию скрытые слайды не включаются. Вы можете управлять этим поведением через [set_ExportHiddenSlides](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) в [XamlOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export.xaml/xamloptions/) — оставьте его отключённым, если экспорт скрытых слайдов не нужен.