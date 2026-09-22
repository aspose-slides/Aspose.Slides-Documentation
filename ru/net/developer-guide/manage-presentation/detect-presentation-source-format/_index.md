---
title: Определить оригинальный формат презентации в .NET
linktitle: Исходный формат
type: docs
weight: 35
url: /ru/net/detect-presentation-source-format/
keywords:
- исходный формат
- определить формат презентации
- PowerPoint
- OpenDocument
- презентация
- PPT
- PPTX
- C#
- .NET
- Aspose.Slides
description: "Прочитайте оригинальный формат загруженной презентации на C# с Aspose.Slides для .NET, сравните API обнаружения и работайте с файлами, потоками и устаревшими форматами."
---
## **Обзор**

После загрузки презентации прочитайте только для чтения свойство [Presentation.SourceFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/sourceformat/) для определения её исходного формата. Это свойство также доступно через [IPresentation.SourceFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentation/sourceformat/). Используйте его, когда последующая обработка зависит от формата, из которого был загружен текущий экземпляр.

Исходный формат отличается от [SaveFormat](https://reference.aspose.com/slides/ru/net/aspose.slides.export/saveformat/), выбранного для выходного файла. Сохранение в другой формат не изменяет исходный формат уже существующего экземпляра.

## **Чтение исходного формата файла**

Этот пример требует существующего файла `sample.pptx`. Он загружает файл и выбирает политику обработки приложения, используя [Presentation.SourceFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/sourceformat/), а не имя файла. Измените путь входного файла, чтобы попробовать другие форматы. Пример выводит выбранную политику; замените сообщения своей логикой приложения.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

switch (presentation.SourceFormat)
{
    case SourceFormat.Ppt:
    case SourceFormat.Pps:
    case SourceFormat.Pot:
        Console.WriteLine("Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat.Pptx:
        Console.WriteLine("Use the standard PPTX processing policy.");
        break;
    default:
        Console.WriteLine($"Use the general policy for {presentation.SourceFormat}.");
        break;
}
```

## **Определение поддерживаемых значений**

Перечисление [SourceFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/sourceformat/) различает следующие форматы презентаций. Нижеуказанные расширения являются общепринятыми, а не восстановлением оригинального имени файла.

| Значение SourceFormat | Расширение | Формат |
| --- | --- | --- |
| `Ppt` | `.ppt` | презентация PowerPoint 97–2003 |
| `Pptx` | `.pptx` | презентация Office Open XML |
| `Pptm` | `.pptm` | презентация Office Open XML с поддержкой макросов |
| `Pps` | `.pps` | слайд-шоу PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | слайд-шоу Office Open XML |
| `Ppsm` | `.ppsm` | слайд-шоу Office Open XML с поддержкой макросов |
| `Pot` | `.pot` | шаблон PowerPoint 97–2003 |
| `Potx` | `.potx` | шаблон Office Open XML |
| `Potm` | `.potm` | шаблон Office Open XML с поддержкой макросов |
| `Odp` | `.odp` | презентация OpenDocument |
| `Otp` | `.otp` | шаблон презентации OpenDocument |
| `Fodp` | `.fodp` | плоская XML‑ODF презентация |
| `Xml` | `.xml` | презентация PowerPoint XML |

## **Чтение исходного формата из потока**

Этот пример требует существующего файла `sample.pps`. Чтение его байтов в поток памяти моделирует ввод без имени файла, например значение из базы данных или загруженный массив байтов. Конструктор [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) принимает только поток.

```csharp
using System;
using System.IO;
using Aspose.Slides;

var bytes = File.ReadAllBytes("sample.pps");
using var stream = new MemoryStream(bytes);
using var presentation = new Presentation(stream);

Console.WriteLine($"Source format: {presentation.SourceFormat}");
```

PPT, PPS и POT используют один и тот же базовый бинарный формат. При загрузке по пути к файлу расширение может помочь отличить слайд-шоу от шаблона. Без имени файла устаревшее содержимое PPS и POT может быть определено как `SourceFormat.Ppt`; пример PPS выше выдаёт `Ppt`.

Если вашему приложению необходимо сохранять различие, храните оригинальное имя файла или метаданные подтипа отдельно. Расширение — полезный подсказка для этих устаревших подтипов, но не должно быть единственной основой для идентификации произвольного содержимого презентации.

## **Сравнение обнаружения до и после загрузки**

Используйте [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ru/net/aspose.slides/presentationfactory/getpresentationinfo/) и [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentationinfo/loadformat/), когда нужно проанализировать файл до загрузки полной модели объектной презентации. Используйте [Presentation.SourceFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/sourceformat/), когда экземпляр уже существует.

Этот пример требует `sample.pptx` и выводит `Pptx` для обеих проверок. В продакшене выбирайте API, соответствующее вашему этапу обработки; уже загруженная презентация не требует дополнительного осмотра лишь для получения её исходного формата.

```csharp
using System;
using Aspose.Slides;

var path = "sample.pptx";
var information = PresentationFactory.Instance.GetPresentationInfo(path);
Console.WriteLine($"Before loading: {information.LoadFormat}");

using var presentation = new Presentation(path);
Console.WriteLine($"After loading: {presentation.SourceFormat}");
```

Результаты имеют разные типы перечислений: [LoadFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/loadformat/) и [SourceFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/sourceformat/). Не сравнивайте их, приводя числовые значения, и не предполагайте, что каждый формат имеет одинаковые результаты обнаружения. В проверке «сохранить‑и‑открыть» ниже PowerPoint XML перед загрузкой определялся как `LoadFormat.Unknown`, а после загрузки — `SourceFormat.Xml`.

## **Разделение исходного и выходного форматов**

Этот пример требует `sample.pptx` и записывает `converted.odp`. Он выводит `Pptx` как до, так и после сохранения оригинального экземпляра. Только новый экземпляр, загруженный из ODP‑выхода, сообщает `Odp`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
Console.WriteLine($"Before saving: {presentation.SourceFormat}");

presentation.Save("converted.odp", SaveFormat.Odp);
Console.WriteLine($"After saving: {presentation.SourceFormat}");

using var reopened = new Presentation("converted.odp");
Console.WriteLine($"Reopened output: {reopened.SourceFormat}");
```

Презентация, созданная с нуля через `new Presentation()`, сообщает `SourceFormat.Pptx`. У неё нет входного файла: это значение по умолчанию для вновь созданного экземпляра, а не доказательство того, что был загружен файл PPTX. Отслеживайте, создало ли ваше приложение экземпляр или загрузило его, если это различие имеет значение.

## **Преобразование исходного формата в расширение**

Следующий пример требует `sample.pptx`. Он сопоставляет каждое в данный момент поддерживаемое значение [SourceFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/sourceformat/) с традиционным расширением без разбора имени входного файла. Запасной вариант предотвращает бесшумное присвоение расширения нераспознанному значению.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var extension = presentation.SourceFormat switch
{
    SourceFormat.Ppt => ".ppt",
    SourceFormat.Pptx => ".pptx",
    SourceFormat.Pptm => ".pptm",
    SourceFormat.Pps => ".pps",
    SourceFormat.Ppsx => ".ppsx",
    SourceFormat.Ppsm => ".ppsm",
    SourceFormat.Pot => ".pot",
    SourceFormat.Potx => ".potx",
    SourceFormat.Potm => ".potm",
    SourceFormat.Odp => ".odp",
    SourceFormat.Otp => ".otp",
    SourceFormat.Fodp => ".fodp",
    SourceFormat.Xml => ".xml",
    _ => null
};

Console.WriteLine(extension ?? "No extension mapping is available.");
```

Это сопоставление не конвертирует файл и не восстанавливает устаревший подтип PPS/POT, потерянный при загрузке из потока. Для реального сохранения явно выбирайте [SaveFormat](https://reference.aspose.com/slides/ru/net/aspose.slides.export/saveformat/) или используйте конверсию, показанную в [Save Presentations in Their Original Format](/slides/ru/net/save-presentation/#save-presentations-in-their-original-format).

## **Проверка форматов путем сохранения и повторного открытия**

Этот автономный пример создаёт презентацию и записывает три файла в рабочем каталоге, перезаписывая файлы с теми же именами. Затем каждый результат открывается как по пути, так и через поток памяти. Для PPTX и ODP оба пути сообщают сохранённый формат. Для PPS загрузка по пути сообщает `Pps`, а загрузка тех же байтов без имени файла — `Ppt`.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var formats = new[] { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };

foreach (var format in formats)
{
    var path = $"roundtrip.{format.ToString().ToLowerInvariant()}";
    presentation.Save(path, format);

    using var fromFile = new Presentation(path);
    var bytes = File.ReadAllBytes(path);
    using var stream = new MemoryStream(bytes);
    using var fromStream = new Presentation(stream);

    Console.WriteLine($"{format}: file={fromFile.SourceFormat}, stream={fromStream.SourceFormat}");
}
```

| Сохранённый формат | SourceFormat из пути к файлу | SourceFormat из безымянного потока |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` соответственно | То же, что путь к файлу |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` соответственно | То же, что путь к файлу |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` соответственно | То же, что путь к файлу |
| ODP, OTP | `Odp`, `Otp` соответственно | То же, что путь к файлу |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

В этих проверках единственной нормализацией исходного формата было преобразование PPS/POT в `Ppt` для безымянных потоков. Таблица описывает идентификацию форматов, а не сохранение всех особенностей презентации при конвертации.

## **Вопросы и ответы**

**Изменится ли исходный формат презентации, загруженной из PPTX, при сохранении в ODP?**

Нет. Существующий экземпляр всё равно сообщает `Pptx`. Экземпляр, загруженный из сохранённого ODP‑файла, сообщает `Odp`.

**Может ли поток всегда различать устаревшую презентацию, слайд‑шоу и шаблон?**

Нет. PPT, PPS и POT используют один бинарный формат. Храните имя файла или метаданные подтипа отдельно, если требуется различие.

**Какой API использовать, если презентация уже загружена?**

Читайте [Presentation.SourceFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/sourceformat/). Для предварительного осмотра используйте [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ru/net/aspose.slides/presentationfactory/getpresentationinfo/).