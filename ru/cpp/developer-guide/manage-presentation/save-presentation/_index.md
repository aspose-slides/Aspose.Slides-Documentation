---
title: Сохранение презентаций на C++
linktitle: Сохранить презентацию
type: docs
weight: 80
url: /ru/cpp/save-presentation/
keywords:
- сохранять PowerPoint
- сохранять OpenDocument
- сохранять презентацию
- сохранять слайд
- сохранять PPT
- сохранять PPTX
- сохранять ODP
- презентация в файл
- презентация в поток
- предопределённый тип представления
- строгий формат Office Open XML
- режим Zip64
- обновление эскиза
- прогресс сохранения
- C++
- Aspose.Slides
description: "Узнайте, как сохранять презентации на C++ с помощью Aspose.Slides — экспортировать в PowerPoint или OpenDocument, сохраняя макеты, шрифты и эффекты."
---
## **Обзор**

[Open Presentations in C++](/slides/ru/cpp/open-presentation/) описывает, как использовать класс [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) для открытия презентации. Эта статья объясняет, как создавать и сохранять презентации. Класс [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) содержит содержимое презентации. Независимо от того, создаёте ли вы презентацию с нуля или изменяете существующую, её необходимо сохранить после завершения работы. С помощью Aspose.Slides for C++ вы можете сохранять в **файл** или **поток**. В этой статье рассматриваются различные способы сохранения презентации.

## **Сохранение презентаций в файлы**

Сохраните презентацию в файл, вызвав метод `Save` класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/). Передайте имени файла и формат сохранения в метод. Ниже показан пример того, как сохранить презентацию с помощью Aspose.Slides.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Создайте экземпляр класса Presentation, представляющего файл презентации.
auto presentation = MakeObject<Presentation>();

// Выполните здесь некоторую работу...

// Сохраните презентацию в файл.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Сохранение презентаций в потоки**

Вы можете сохранить презентацию в поток, передав выходной поток методу `Save` класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/). Презентацию можно записать в различные типы потоков. В примере ниже мы создаём новую презентацию и сохраняем её в файловый поток.

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

// Создайте экземпляр класса Presentation, представляющего файл презентации.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// Сохраните презентацию в поток.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **Сохранение презентаций с предопределённым типом отображения**

Aspose.Slides позволяет задать начальный вид, который PowerPoint использует при открытии сгенерированной презентации, через класс [ViewProperties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/viewproperties/). Используйте метод [set_LastView](https://reference.aspose.com/slides/ru/cpp/aspose.slides/viewproperties/set_lastview/) со значением из перечисления [ViewType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/viewtype/).

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

Aspose.Slides позволяет сохранять презентацию в строгом формате Office Open XML. Используйте класс [PptxOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/pptxoptions/) и установите его свойство соответствия при сохранении. Если установить `Conformance.Iso29500_2008_Strict`, выходной файл будет сохранён в строгом формате Office Open XML.

Ниже пример создания презентации и её сохранения в строгом формате Office Open XML.

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

// Создайте экземпляр класса Presentation, представляющего файл презентации.
auto presentation = MakeObject<Presentation>();

// Сохраните презентацию в строгом формате Office Open XML.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Сохранение презентаций в формате Office Open XML в режиме Zip64**

Файл Office Open XML представляет собой ZIP‑архив, который накладывает ограничения в 4 ГБ (2^32 байт) на несжатый размер любого файла, сжатый размер любого файла и общий размер архива, а также ограничивает количество файлов в архиве 65 535 (2^16‑1). Расширения формата ZIP64 снимают эти ограничения, увеличивая их до 2^64.

Метод [IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) позволяет выбрать, когда использовать расширения ZIP64 при сохранении файла Office Open XML.

Метод может использоваться с следующими режимами:

- `IfNecessary` использует расширения ZIP64 только если презентация превышает указанные выше ограничения. Это режим по умолчанию.
- `Never` никогда не использует расширения ZIP64.
- `Always` всегда использует расширения ZIP64.

Ниже показан код, демонстрирующий, как сохранить презентацию в файл PPTX с включёнными расширениями ZIP64:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}
При сохранении с `Zip64Mode.Never` будет сгенерировано исключение [PptxException](https://reference.aspose.com/slides/ru/cpp/aspose.slides/pptxexception/), если презентацию нельзя сохранить в формате ZIP32.
{{% /alert %}}

## **Сохранение презентаций в формате Office Open XML с уровнями сжатия**

При работе с крупными презентациями вы можете регулировать уровень сжатия, чтобы балансировать размер файла и время обработки. В зависимости от требований вы можете предпочесть более быструю обработку или более компактный результат.

Aspose.Slides предоставляет метод [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/), позволяющий указать уровень сжатия при сохранении презентации в формате Office Open XML.

Доступные уровни сжатия:

- **None**: Сжатие не применяется. Файлы сохраняются «как есть».
- **Level1**: Самое быстрое сжатие с самым низким коэффициентом сжатия.
- **Level2**: Быстрое сжатие с немного лучшим коэффициентом, чем **Level1**.
- **Level3**: Обеспечивает лучшее сжатие, чем **Level2**, с умеренным влиянием на время обработки.
- **Level4**: Лучше, чем **Level3**.
- **Level5**: Улучшенное сжатие по сравнению с **Level4** с дополнительным временем обработки.
- **Level6**: Стандартное сжатие, предлагающее хороший баланс между скоростью обработки и размером файла. Это *уровень сжатия по умолчанию*.
- **Level7**: Лучше, чем **Level6**, но с более медленной обработкой.
- **Level8**: Лучше, чем **Level7**.
- **Level9**: Максимальное сжатие. Даёт наименьший размер файла ценой самого длительного времени обработки.

Ниже пример, демонстрирующий, как сохранить презентацию в файл PPTX *без сжатия*:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::None);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-out.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

Этот пример показывает, как сохранить презентацию в файл PPTX с *максимальным сжатием*:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::Level9);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-level9.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

## **Сохранение презентаций без обновления эскиза**

Метод [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) управляет генерацией эскиза при сохранении презентации в PPTX:

- Если установлен `true`, эскиз обновляется во время сохранения. Это значение по умолчанию.
- Если установлен `false`, текущий эскиз сохраняется без изменений. Если у презентации нет эскиза, он не будет создаваться.

В коде ниже презентация сохраняется в PPTX без обновления её эскиза.

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Эта опция помогает сократить время, требуемое для сохранения презентации в формате PPTX.
{{% /alert %}}

## **Сохранение прогресса в процентах**

Интерфейс [IProgressCallback](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iprogresscallback/) используется через метод `set_ProgressCallback`, объявленный в интерфейсе [ISaveOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/isaveoptions/) и абстрактном классе [SaveOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/saveoptions/). Реализуйте [IProgressCallback](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iprogresscallback/) и передайте его в `set_ProgressCallback`, чтобы получать обновления о прогрессе сохранения в процентах.

Ниже приведены фрагменты кода, показывающие, как использовать `IProgressCallback`.

```cpp
#include <IProgressCallback.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        // Используйте здесь значение процента прогресса.
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```
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

// Класс обратного вызова прогресса, определённый выше.
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Aspose разработала [бесплатное приложение PowerPoint Splitter](https://products.aspose.app/slides/ru/splitter), использующее собственный API. Приложение позволяет разбивать презентацию на несколько файлов, сохраняя выбранные слайды как новые файлы PPTX или PPT.
{{% /alert %}}

## **Вопросы и ответы**

**Поддерживается ли «быстрое сохранение» (инкрементальное сохранение), при котором записываются только изменения?**

Нет. При каждом сохранении создаётся полностью новый целевой файл; инкрементальное «быстрое сохранение» не поддерживается.

**Можно ли безопасно сохранять один и тот же объект Presentation из нескольких потоков?**

Нет. Объект [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) **не является потокобезопасным**; сохраняйте его из одного потока.

**Что происходит с гиперссылками и внешними связанными файлами при сохранении?**

[Гиперссылки](/slides/ru/cpp/manage-hyperlinks/) сохраняются. Внешние связанные файлы (например, видео по относительным путям) не копируются автоматически — убедитесь, что указанные пути остаются доступными.

**Можно ли задавать/сохранять метаданные документа (Автор, Заголовок, Компания, Дата)?**

Да. Стандартные [свойства документа](/slides/ru/cpp/presentation-properties/) поддерживаются и будут записаны в файл при сохранении.