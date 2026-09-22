---
title: Сохранение презентаций в C++
linktitle: Сохранить презентацию
type: docs
weight: 80
url: /ru/cpp/save-presentation/
keywords:
- сохранить PowerPoint
- сохранить OpenDocument
- сохранить презентацию
- сохранить слайд
- сохранить PPT
- сохранить PPTX
- сохранить ODP
- презентация в файл
- презентация в поток
- предопределенный тип представления
- строгий формат Office Open XML
- режим Zip64
- обновление миниатюры
- прогресс сохранения
- C++
- Aspose.Slides
description: "Сохраните презентации PowerPoint и OpenDocument в файлы или потоки на C++ с помощью Aspose.Slides, а также настройте вывод PPTX и отчет о прогрессе."
---
## **Обзор**

После того как вы создаете презентацию или [откроете существующую](/slides/ru/cpp/open-presentation/), используйте метод [Presentation::Save](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/save/) для записи результата. Aspose.Slides for C++ может сохранять презентацию в файл или поток в форматах PowerPoint, OpenDocument, PDF и других. Ниже представлены разделы, описывающие стандартные операции сохранения и доступные параметры для вывода PPTX.

## **Сохранение презентаций в файлы**

Чтобы сохранить презентацию в файл, передайте путь вывода и значение [SaveFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/saveformat/) в метод [Presentation::Save](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/save/). Значение формата определяет тип файла, который создаёт Aspose.Slides.

Следующий пример создаёт презентацию и сохраняет её как файл PPTX:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

// Добавьте или измените содержимое презентации здесь.

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Сохранение презентаций в их исходном формате**

Для примеров обнаружения формата файлов и потоков, поведения вновь созданных презентаций и различия между исходным и конечным форматами см. [Determine the Original Presentation Format](/slides/ru/cpp/detect-presentation-source-format/).

В приложениях пакетной обработки формат входных данных может быть неизвестен заранее. После загрузки файла прочитайте его исходный формат с помощью [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/get_sourceformat/). Передайте полученное значение [SourceFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/sourceformat/) в [SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides.util/slideutil/tosaveformat/), чтобы получить соответствующее значение [SaveFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/saveformat/), а затем используйте [Presentation::Save](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/save/) для записи изменённой презентации.

Следующий полностью пример обрабатывает каждый файл во входном каталоге, обновляет его заголовок и сохраняет его в выходном каталоге в том же формате, из которого он был загружен:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;
using namespace System::IO;

String inputDirectory = u"Input";
String outputDirectory = u"Output";

Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory);
for (const auto& inputPath : inputPaths)
{
    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);

        auto sourceFormat = presentation->get_SourceFormat();
        auto saveFormat = SlideUtil::ToSaveFormat(sourceFormat);

        presentation->get_DocumentProperties()->set_Title(u"Processed by the batch application");

        auto outputPath = Path::Combine(outputDirectory, Path::GetFileName(inputPath));
        presentation->Save(outputPath, saveFormat);
        presentation->Dispose();
    }
    catch (ArgumentException& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot map the source format of '{0}': {1}", inputPath, exception->get_Message()));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot process '{0}': {1}", inputPath, exception->get_Message()));
    }
}
```

[SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides.util/slideutil/tosaveformat/) сопоставляет PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP и PowerPoint XML их соответствующим форматам сохранения презентаций. Он сопоставляет только форматы источника презентаций; он не предназначен для выбора форматов экспорта, таких как PDF, HTML, TIFF или изображения. Передача неподдерживаемого или недопустимого значения [SourceFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/sourceformat/) приводит к возникновению [ArgumentException](https://reference.aspose.com/slides/ru/cpp/system/argumentexception/).

Унаследованные файлы PPT, PPS и POT используют один и тот же бинарный контейнер. Когда такая презентация загружается из потока без расширения файла, файл PPS или POT может быть идентифицирован как PPT. Если требуется сохранять эти устаревшие подтипы, удерживайте исходное имя файла или метаданные формата отдельно и используйте их при выборе имени и формата выходного файла.

## **Сохранение презентаций в потоки**

Чтобы записать презентацию без привязки к окончательному пути файла, передайте записываемый [Stream](https://reference.aspose.com/slides/ru/cpp/system.io/stream/) и значение [SaveFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/saveformat/) в метод [Presentation::Save](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/save/). Такой подход полезен, когда вывод должен быть возвращён из веб‑сервиса, сохранён в базе данных или обработан в памяти.

Следующий пример сохраняет новую презентацию в файловый поток:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto outputStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

presentation->Save(outputStream, SaveFormat::Pptx);

outputStream->Close();
presentation->Dispose();
```

## **Сохранение презентаций с предопределенным типом представления**

Вы можете задать представление, в котором PowerPoint будет первоначально открывать сохранённую презентацию. Вызовите [ViewProperties::set_LastView](https://reference.aspose.com/slides/ru/cpp/aspose.slides/viewproperties/set_lastview/) с значением [ViewType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/viewtype/) до сохранения.

Следующий пример устанавливает представление «Слайд‑объединитель» в качестве начального:

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Сохранение презентаций в строгом формате Office Open XML**

Чтобы создать файл PPTX, соответствующий строгому профилю Office Open XML, создайте экземпляр [PptxOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/pptxoptions/) и вызовите [PptxOptions::set_Conformance](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/pptxoptions/set_conformance/) с `Conformance::Iso29500_2008_Strict`. Затем передайте параметры в метод [Presentation::Save](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/save/).

```cpp
#include <DOM/Presentation.h>
#include <Export/Conformance.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

auto presentation = MakeObject<Presentation>();

presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Сохранение презентаций в формате Office Open XML в режиме Zip64**

Стандартный ZIP‑архив ограничивает сжатый и несжатый размер каждой записи, общий размер архива и количество записей. Поскольку файл PPTX является ZIP‑архивом, очень большая презентация может превысить эти ограничения. Расширения Zip64 повышают соответствующие лимиты размера и количества записей.

Используйте [PptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/pptxoptions/set_zip64mode/) для управления тем, будет ли Aspose.Slides записывать расширения Zip64:

- `IfNecessary` использует Zip64 только тогда, когда презентация превышает стандартные ограничения ZIP. Этот режим установлен по умолчанию.
- `Never` отключает расширения Zip64.
- `Always` всегда записывает расширения Zip64.

Следующий пример всегда включает расширения Zip64 для выходной презентации:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_Zip64Mode(Zip64Mode::Always);

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="warning" title="Warning" %}}
Если `Zip64Mode` установлен в `Never` и презентацию невозможно уместить в стандартные ограничения ZIP, операция сохранения бросает [PptxException](https://reference.aspose.com/slides/ru/cpp/aspose.slides/pptxexception/).
{{% /alert %}}

## **Сохранение презентаций в формате Office Open XML с уровнями сжатия**

Для вывода PPTX вы можете балансировать скорость сохранения и размер файла, вызывая [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/). Перечисление [CompressionLevel](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/compressionlevel/) предоставляет следующие значения:

- `None` сохраняет данные без сжатия.
- `Level1` обеспечивает самое быстрое сжатие и наибольший размер сжатого вывода.
- `Level2`–`Level5` постепенно отдают предпочтение более маленькому выводу в ущерб скорости сохранения.
- `Level6` балансирует скорость сохранения и размер файла. Это уровень по умолчанию.
- `Level7` и `Level8` ещё сильнее отдают предпочтение меньшему выводу в ущерб скорости сохранения.
- `Level9` обеспечивает максимальное сжатие и требует наибольшего времени обработки.

Следующий пример сохраняет презентацию без сжатия:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::None);

presentation->Save(u"OutputNoCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

Следующий пример использует максимальный уровень сжатия:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::Level9);

presentation->Save(u"OutputMaximumCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Сохранение презентаций без обновления миниатюры**

При сохранении презентации как PPTX параметр [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) управляет её миниатюрой документа:

- `true` генерирует миниатюру заново во время операции сохранения. Это значение по умолчанию.
- `false` сохраняет существующую миниатюру. Если у презентации нет миниатюры, Aspose.Slides её не создаёт.

Следующий пример сохраняет презентацию без обновления её миниатюры:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_RefreshThumbnail(false);

presentation->Save(u"Output.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Отключение обновления миниатюры может сократить время, необходимое для сохранения файла PPTX.
{{% /alert %}}

## **Отслеживание прогресса сохранения в процентах**

Чтобы мониторить процесс сохранения, реализуйте интерфейс [IProgressCallback](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iprogresscallback/) и передайте реализацию в [ISaveOptions::set_ProgressCallback](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/isaveoptions/set_progresscallback/). Aspose.Slides затем вызывает [IProgressCallback::Reporting](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iprogresscallback/reporting/) с значениями прогресса во время экспорта.

Следующий пример выводит прогресс экспорта PDF в консоль:

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <IProgressCallback.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);
        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto options = MakeObject<PdfOptions>();
options->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, options);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Aspose предоставляет бесплатный [PowerPoint Splitter](https://products.aspose.app/slides/ru/splitter), построенный на API Aspose.Slides. Он сохраняет выбранные слайды из презентации в отдельные файлы PPT или PPTX.
{{% /alert %}}

## **FAQ**

**Поддерживает ли Aspose.Slides инкрементное или «быстрое» сохранение?**

Нет. Каждая операция сохранения записывает полностью готовый файл вывода, а не только изменённые части.

**Могут ли несколько потоков сохранять один и тот же объект Presentation?**

Нет. Объект [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) [не является потокобезопасным](/slides/ru/cpp/multithreading/). Доступ к каждому экземпляру и его сохранение должны происходить только из одного потока одновременно.

**Что происходит с гиперссылками и внешними файлами при сохранении презентации?**

[Гиперссылки](/slides/ru/cpp/manage-hyperlinks/) остаются в презентации. Aspose.Slides не копирует внешние файлы, поэтому сохранённая презентация должна по‑прежнему иметь возможность обращаться к их расположениям.

**Можно ли сохранить метаданные документа, такие как автор, название, компания и дата создания?**

Да. Установите соответствующие [свойства документа](/slides/ru/cpp/presentation-properties/) перед сохранением, и Aspose.Slides запишет их в файл вывода.