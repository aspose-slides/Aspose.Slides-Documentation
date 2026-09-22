---
title: Определение оригинального формата презентации в C++
linktitle: Исходный формат
type: docs
weight: 35
url: /ru/cpp/detect-presentation-source-format/
keywords:
- исходный формат
- определение формата презентации
- PowerPoint
- OpenDocument
- презентация
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Прочитайте оригинальный формат загруженной презентации в C++ с помощью Aspose.Slides for C++, сравните API обнаружения и работайте с файлами, потоками и устаревшими форматами."
---
## **Обзор**

После загрузки презентации вызовите [Presentation::get_SourceFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_sourceformat/) чтобы определить её исходный формат. Этот метод также доступен через [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/get_sourceformat/). Используйте его, когда последующая обработка зависит от формата, из которого был загружен текущий экземпляр.

Исходный формат отличается от выбранного для выходного файла [SaveFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/saveformat/). Сохранение в другой формат не меняет исходный формат существующего экземпляра.

## **Чтение исходного формата файла**

Этот пример требует существующего файла `sample.pptx`. Он загружает файл и выбирает политику обработки приложения с помощью [Presentation::get_SourceFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_sourceformat/), а не имени файла. Измените путь к входному файлу, чтобы проверить другие форматы. Пример выводит выбранную политику; замените сообщения своей логикой приложения.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
    case SourceFormat::Pps:
    case SourceFormat::Pot:
        Console::WriteLine(u"Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat::Pptx:
        Console::WriteLine(u"Use the standard PPTX processing policy.");
        break;
    default:
        Console::WriteLine(String::Format(u"Use the general policy for {0}.", ObjectExt::ToString(presentation->get_SourceFormat())));
        break;
}
```

## **Определение поддерживаемых значений**

Перечисление [SourceFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/sourceformat/) различает следующие форматы презентаций. Ниже указаны обычные расширения, а не восстановление оригинального имени файла.

| SourceFormat value | Extension | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | Презентация PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Презентация Office Open XML |
| `Pptm` | `.pptm` | Презентация Office Open XML с поддержкой макросов |
| `Pps` | `.pps` | Слайд-шоу PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | Слайд-шоу Office Open XML |
| `Ppsm` | `.ppsm` | Слайд-шоу Office Open XML с поддержкой макросов |
| `Pot` | `.pot` | Шаблон PowerPoint 97–2003 |
| `Potx` | `.potx` | Шаблон Office Open XML |
| `Potm` | `.potm` | Шаблон Office Open XML с поддержкой макросов |
| `Odp` | `.odp` | Презентация OpenDocument |
| `Otp` | `.otp` | Шаблон презентации OpenDocument |
| `Fodp` | `.fodp` | Презентация Flat XML ODF |
| `Xml` | `.xml` | Презентация PowerPoint XML |

## **Чтение исходного формата из потока**

Этот пример требует существующего файла `sample.pps`. Чтение его байтов в поток памяти моделирует ввод без имени файла, например значение из базы данных или загруженный массив байтов. Конструктор [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) принимает только поток.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto bytes = File::ReadAllBytes(u"sample.pps");
auto stream = MakeObject<MemoryStream>(bytes);
auto presentation = MakeObject<Presentation>(stream);

Console::WriteLine(String::Format(u"Source format: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

PPT, PPS и POT используют один и тот же базовый бинарный формат. При загрузке по пути к файлу расширение может помочь отличить слайд-шоу от шаблона. Без имени файла содержимое старых PPS и POT может быть определено как `SourceFormat::Ppt`; пример PPS выше сообщает `Ppt`.

Если вашему приложению необходимо сохранять различие, храните оригинальное имя файла или метаданные подтипа отдельно. Расширение является полезной подсказкой для этих устаревших подтипов, но не должно быть единственной основой для идентификации произвольного содержимого презентации.

## **Сравнение определения до и после загрузки**

Используйте [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentationfactory/getpresentationinfo/) и [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentationinfo/get_loadformat/) когда необходимо проанализировать файл до полной загрузки модели объектов презентации. Используйте [Presentation::get_SourceFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_sourceformat/) когда экземпляр уже существует.

Этот пример требует `sample.pptx` и выводит `Pptx` для обеих проверок. В production выбирайте API, соответствующее вашему этапу обработки; уже загруженная презентация не нуждается во второй проверке только для получения её исходного формата.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <DOM/PresentationFactory.h>
#include <DOM/IPresentationInfo.h>
#include <LoadFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto path = String(u"sample.pptx");
auto information = PresentationFactory::get_Instance()->GetPresentationInfo(path);
Console::WriteLine(String::Format(u"Before loading: {0}", ObjectExt::ToString(information->get_LoadFormat())));

auto presentation = MakeObject<Presentation>(path);
Console::WriteLine(String::Format(u"After loading: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

Результаты имеют разные типы перечислений: [LoadFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/loadformat/) и [SourceFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/sourceformat/). Не сравнивайте их, приводя их числовые значения, и не полагайтесь на то, что каждый формат имеет идентичные результаты определения. PowerPoint XML может быть определён как `LoadFormat::Unknown` до загрузки и как `SourceFormat::Xml` после загрузки.

## **Отделяйте исходный и целевой форматы**

Этот пример требует `sample.pptx` и записывает `converted.odp`. Он выводит `Pptx` как до, так и после сохранения оригинального экземпляра. Только новый экземпляр, загруженный из ODP‑вывода, сообщает `Odp`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
Console::WriteLine(String::Format(u"Before saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

presentation->Save(u"converted.odp", SaveFormat::Odp);
Console::WriteLine(String::Format(u"After saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

auto reopened = MakeObject<Presentation>(u"converted.odp");
Console::WriteLine(String::Format(u"Reopened output: {0}", ObjectExt::ToString(reopened->get_SourceFormat())));
```

Презентация, созданная с нуля с помощью `MakeObject<Presentation>()`, сообщает `SourceFormat::Pptx`. У неё нет входного файла: это значение по умолчанию для новосозданного экземпляра, а не доказательство того, что был загружен файл PPTX. Отслеживайте, создал ли ваш код экземпляр или загрузил его, если это различие важно.

## **Отображение исходного формата в расширение**

Следующий пример требует `sample.pptx`. Он отображает каждое в настоящее время поддерживаемое значение [SourceFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/sourceformat/) в традиционное расширение, без разбора имени входного файла. Запасной вариант избегает безмолвного присвоения расширения нераспознанному значению.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto extension = String::Empty;
switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
        extension = u".ppt";
        break;
    case SourceFormat::Pptx:
        extension = u".pptx";
        break;
    case SourceFormat::Pptm:
        extension = u".pptm";
        break;
    case SourceFormat::Pps:
        extension = u".pps";
        break;
    case SourceFormat::Ppsx:
        extension = u".ppsx";
        break;
    case SourceFormat::Ppsm:
        extension = u".ppsm";
        break;
    case SourceFormat::Pot:
        extension = u".pot";
        break;
    case SourceFormat::Potx:
        extension = u".potx";
        break;
    case SourceFormat::Potm:
        extension = u".potm";
        break;
    case SourceFormat::Odp:
        extension = u".odp";
        break;
    case SourceFormat::Otp:
        extension = u".otp";
        break;
    case SourceFormat::Fodp:
        extension = u".fodp";
        break;
    case SourceFormat::Xml:
        extension = u".xml";
        break;
    default:
        break;
}

Console::WriteLine(extension.IsEmpty() ? u"No extension mapping is available." : extension);
```

Это отображение не преобразует файл и не восстанавливает устаревший подтип PPS/POT, потерянный при загрузке из потока. Для реального сохранения явно выбирайте [SaveFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/saveformat/) или используйте конвертацию, показанную в [Save Presentations in Their Original Format](/slides/ru/cpp/save-presentation/#save-presentations-in-their-original-format).

## **Проверка форматов путем сохранения и повторного открытия**

Этот автономный пример создаёт презентацию и записывает три файла в текущий каталог, перезаписывая файлы с теми же именами. Он открывает каждый результат как по пути, так и через поток памяти. Для PPTX и ODP оба пути сообщают сохранённый формат. Для PPS загрузка по пути сообщает `Pps`, а загрузка тех же байтов без имени файла — `Ppt`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto formats = MakeArray<SaveFormat>({SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps});

for (auto format : formats)
{
    auto formatName = ObjectExt::ToString(format);
    auto path = String::Format(u"roundtrip.{0}", formatName.ToLowerInvariant());
    presentation->Save(path, format);

    auto fromFile = MakeObject<Presentation>(path);
    auto bytes = File::ReadAllBytes(path);
    auto stream = MakeObject<MemoryStream>(bytes);
    auto fromStream = MakeObject<Presentation>(stream);

    Console::WriteLine(String::Format(u"{0}: file={1}, stream={2}", formatName, ObjectExt::ToString(fromFile->get_SourceFormat()), ObjectExt::ToString(fromStream->get_SourceFormat())));
}
```

Следующая таблица суммирует идентификацию исходного формата для презентаций с совпадающими расширениями:

| Сохранённый формат | SourceFormat из пути к файлу | SourceFormat из безименного потока |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` соответственно | `Pptx`, `Pptm` соответственно |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` соответственно | `Ppsx`, `Ppsm` соответственно |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` соответственно | `Potx`, `Potm` соответственно |
| ODP, OTP | `Odp`, `Otp` соответственно | `Odp`, `Otp` соответственно |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Устаревший контент PPS/POT нормализуется до `Ppt` для потоков без имени. Таблица описывает идентификацию форматов, а не сохранение всех особенностей презентации при конвертации.

## **FAQ**

**Сохраняет ли сохранение в ODP изменение исходного формата презентации, загруженной из PPTX?**

Нет. Существующий экземпляр по‑прежнему сообщает `Pptx`. Экземпляр, загруженный из сохранённого файла ODP, сообщает `Odp`.

**Может ли поток всегда различать устаревшую презентацию, слайд‑шоу и шаблон?**

Нет. PPT, PPS и POT используют общий бинарный формат. Сохраните имя файла или метаданные подтипа отдельно, если требуется различие.

**Какой API следует использовать, если презентация уже загружена?**

Читайте [Presentation::get_SourceFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_sourceformat/). Используйте [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentationfactory/getpresentationinfo/) для инспекции перед загрузкой.