---
title: Экспорт презентаций в XAML в .NET
linktitle: Презентация в XAML
type: docs
weight: 30
url: /ru/net/export-to-xaml/
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
- экспорт PPT в XAML
- экспорт PPTX в XAML
- экспорт ODP в XAML
- .NET
- C#
- Aspose.Slides
description: "Конвертировать слайды PowerPoint и OpenDocument в XAML в .NET с помощью Aspose.Slides — быстрое решение без Office, сохраняющее макет."
---
## **Обзор**

Эта статья объясняет, как экспортировать презентации PowerPoint в XAML с помощью Aspose.Slides. Она включает краткое введение в XAML, показывает, как сохранить презентацию в XAML с настройками по умолчанию, и демонстрирует, как настроить экспорт через [XamlOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export.xaml/xamloptions/), включая экспорт скрытых слайдов. Статья также отвечает на несколько часто задаваемых вопросов, связанных с резервными шрифтами, совместимостью стека XAML и поведением экспорта скрытых слайдов.

## **О XAML**

XAML — это язык разметки на основе XML, используемый для описания пользовательских интерфейсов в таких фреймворках, как WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) и Xamarin.Forms.

Вы можете работать с файлами XAML в визуальном дизайнере или писать и редактировать разметку напрямую.

## **Экспорт презентаций в XAML с настройками по умолчанию**

Следующий пример на C# показывает, как экспортировать презентацию в XAML с настройками по умолчанию:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions();
presentation.Save(xamlOptions);
```

По умолчанию экспортированные слайды сохраняются в подпапку `pres` текущего рабочего каталога процесса, как возвращает [Directory.GetCurrentDirectory](https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.getcurrentdirectory). Папка создаётся автоматически, и любые требуемые изображения сохраняются там же.

Имя папки вывода берётся из имени исходного файла без расширения. Для `pres.pptx` файлы вывода называются `pres/Slide_1.xaml`, `pres/Slide_2.xaml` и так далее. Даже если вы передаёте абсолютный путь к входной презентации, папка вывода создаётся относительно текущего рабочего каталога, а не рядом с входным файлом.

## **Экспорт презентаций в XAML с пользовательскими настройками**

Используйте интерфейс [IXamlOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export.xaml/ixamloptions/) для управления тем, как Aspose.Slides экспортирует презентацию в XAML.

Чтобы сохранить результат в пользовательское место, реализуйте [IXamlOutputSaver](https://reference.aspose.com/slides/ru/net/aspose.slides.export.xaml/ixamloutputsaver/) и присвойте экземпляр вашей реализации свойству [OutputSaver](https://reference.aspose.com/slides/ru/net/aspose.slides.export.xaml/xamloptions/outputsaver/) объекта [XamlOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export.xaml/xamloptions/).

Чтобы включить скрытые слайды в вывод XAML, установите свойство [ExportHiddenSlides](https://reference.aspose.com/slides/ru/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) в `true`, как показано в следующем примере на C#:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions { ExportHiddenSlides = true };
presentation.Save(xamlOptions);
```

## **Сбор всех сгенерированных XAML‑артефактов**

Экспорт XAML может создавать документ XAML для каждого экспортированного слайда, а также отдельные изображения и вспомогательные ресурсы. Присвойте пользовательский [IXamlOutputSaver](https://reference.aspose.com/slides/ru/net/aspose.slides.export.xaml/ixamloutputsaver/) свойству [XamlOptions.OutputSaver](https://reference.aspose.com/slides/ru/net/aspose.slides.export.xaml/xamloptions/outputsaver/), чтобы получать эти артефакты вместо использования сохраняющего их по умолчанию в файловой системе. Запустите экспорт с помощью перегрузки [Presentation.Save](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/save/) для XAML, принимающей параметры XAML‑options.

### **Понимание жизненного цикла обратного вызова**

Экспортер вызывает [IXamlOutputSaver.Save](https://reference.aspose.com/slides/ru/net/aspose.slides.export.xaml/ixamloutputsaver/save/) отдельно для каждого сгенерированного артефакта:

- `path` идентифицирует артефакт и может включать относительные каталоги. Сохраните эту информацию, так как XAML может ссылаться на ресурсы с помощью относительных путей.
- `data` содержит байты артефакта. Изображения и другие бинарные ресурсы не должны декодироваться как текст.
- Сохранитель отвечает за хранение или постоянное сохранение данных перед возвратом. Примеры копируют каждый массив байтов в память, принадлежащую приложению.
- Считайте экспорт успешным только когда операция сохранения презентации завершилась и каждый обратный вызов завершился успешно. Не подавляйте ошибки хранения и не запускайте невидимые фоновые записи. Если сохранение происходит позже, сообщайте о полном успехе только после того, как и этот шаг также завершится успешно.

[XamlOptions.ExportHiddenSlides](https://reference.aspose.com/slides/ru/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) также применяется к пользовательскому сохранителю. Его значение по умолчанию, `false`, исключает XAML‑документы скрытых слайдов. Установка в `true` включает их и любые ресурсы, необходимые для их экспорта. Количество ресурсов зависит от презентации; не полагайтесь на один обратный вызов на слайд или фиксированный порядок вызовов.

### **Экспорт в память и проверка артефактов**

Этот полный пример загружает `pres.pptx`, собирает каждый артефакт в [Dictionary<string, byte[]>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2) и выводит его имя, тип и количество байтов. Имена сохраняются точно такими, какими они были переданы. Дублирующиеся имена приводят к сбою сбора вместо тихой перезаписи артефакта.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class InMemoryXamlExample
{
    public static void Run()
    {
        var saver = new MemoryXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = true };
        presentation.Save(options);

        bool inspectXamlText = false;
        foreach (var artifact in saver.Artifacts)
        {
            var extension = Path.GetExtension(artifact.Key).ToLowerInvariant();
            bool isXaml = extension == ".xaml";
            bool isImage = extension is ".png" or ".jpg" or ".jpeg" or ".gif" or ".bmp" or ".tif" or ".tiff" or ".svg";
            var kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
            Console.WriteLine($"{artifact.Key}: {artifact.Value.Length} bytes ({kind})");

            // Декодировать только XAML и только при необходимости текстовой инспекции.
            if (isXaml && inspectXamlText)
            {
                var markup = Encoding.UTF8.GetString(artifact.Value);
                Console.WriteLine(markup);
            }
        }
    }

    private sealed class MemoryXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

Вызовите `InMemoryXamlExample.Run` из вашего приложения. Проверки расширений полезны для осмотра; сохраняйте все артефакты, включая неизвестные типы ресурсов. Не изменяйте байты при хранении или передаче. Используйте [Encoding.UTF8.GetString](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding.getstring) только для XAML, который нуждается в текстовой обработке.

### **Упаковка собранных артефактов в ZIP‑архив**

Этот самостоятельный пример собирает экспорт, проверяет имена и записывает исходные байты в ZIP‑архив. Уникальное имя архива отделяет одновременно выполняемые задания экспорта. Записи ZIP используют прямые слеши и сохраняют относительные каталоги. Недопустимые имена или имена, сталкивающиеся после нормализации, отклоняют весь пакет до его записи.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class ZipXamlExample
{
    public static void Run()
    {
        var saver = new CollectedXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = false };
        presentation.Save(options);

        var entries = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase);
        foreach (var artifact in saver.Artifacts)
        {
            var entryName = artifact.Key.Replace('\\', '/');
            var segments = entryName.Split('/');
            bool unsafeName = entryName.StartsWith("/", StringComparison.Ordinal) || entryName.Contains(':');
            foreach (var segment in segments)
            {
                unsafeName |= string.IsNullOrWhiteSpace(segment) || segment == "." || segment == "..";
            }

            if (unsafeName || !entries.TryAdd(entryName, artifact.Value))
            {
                Console.WriteLine($"Export rejected: unsafe or duplicate artifact name: {artifact.Key}");
                return;
            }
        }

        var archivePath = $"xaml-{Guid.NewGuid():N}.zip";
        using (var output = new FileStream(archivePath, FileMode.CreateNew, FileAccess.Write))
        using (var archive = new ZipArchive(output, ZipArchiveMode.Create))
        {
            foreach (var artifact in entries)
            {
                var entry = archive.CreateEntry(artifact.Key, CompressionLevel.Optimal);
                using var entryStream = entry.Open();
                entryStream.Write(artifact.Value, 0, artifact.Value.Length);
            }
        }

        // Каталог ZIP был завершён освобождением перед сообщением об успехе.
        Console.WriteLine($"Saved {entries.Count} artifacts to {archivePath}");
    }

    private sealed class CollectedXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

Вызовите `ZipXamlExample.Run` из вашего приложения. Пример использует [ZipArchive](https://learn.microsoft.com/en-us/dotnet/api/system.io.compression.ziparchive) для записи одного локального архива; сам экспортер не записывает отдельные файлы XAML или изображения. Для удалённого хранилища замените этап записи архива загрузкой собранных массивов байтов. Используйте идентификатор задания экспорта плюс полный относительный путь артефакта в качестве ключа blob, либо храните идентификатор задания, относительное имя и бинарные данные в строке базы данных. Публикуйте задание только после завершения всех загрузок или фиксации транзакции базы данных. При неудаче очистите частичный вывод.

Для больших презентаций пользовательский сохранятель может напрямую сохранять каждый артефакт в хранилище приложения, чтобы избежать удержания полной копии экспорта в памяти приложения. Экспортер всё равно собирает все сгенерированные артефакты в памяти перед вызовом сохранятеля. Держите каждый обратный вызов синхронным с точки зрения экспортера: возвращайте управление только после того, как получатель принял байты, и позволяйте ошибкам достигать вызывающего кода.

### **Сохранение имён ресурсов и проверка ссылок**

- Нормализуйте разделители путей, если этого требует место назначения, но сохраняйте относительные каталоги. Не используйте только [Path.GetFileName](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfilename), если только каждый сгенерированный имя не гарантировано уникально и ссылки на ресурсы остаются корректными.
- Применяйте проверку имён, специфичную для места назначения. При записи отдельных файлов отклоняйте абсолютные пути и сегменты перехода, определяйте абсолютный путь с помощью [Path.GetFullPath](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfullpath) и проверяйте, что он остаётся внутри целевого каталога экспорта, включая разделитель в проверке содержания. Используйте контролируемый приложением каталог без символических ссылок, которые могут перенаправлять записи.
- Используйте отдельный сохранятель и пространство имён хранилища для каждого задания экспорта. Обнаруживайте конфликты после нормализации разделителей и в соответствии с правилами чувствительности к регистру места назначения.
- Перед публикацией разберите каждый XAML‑документ как XML и проверьте его ссылки на файловые ресурсы, такие как атрибуты `Source` или `ImageSource` изображений. Разрешите каждый относительный URI относительно каталога содержащего XAML‑артефакта, нормализуйте получившееся имя хранилища и подтвердите, что соответствующий ключ словаря, запись ZIP или сохранённый объект существует. Обрабатывайте внешние URI и выражения разметки XAML отдельно от относительных имён файлов.

Например, если `pres/Slide_1.xaml` ссылается на `images/image1.png`, сохранённый ресурс должен быть доступен как `pres/images/image1.png`. Хранение только `image1.png` нарушит эту связь. Для объектного хранилища сохраняйте ту же структуру под префиксом задания и делайте эти URL‑ы ресурсов доступными потребителю XAML. Откройте завершённый ZIP‑файл, чтобы проверить имена записей и байты ресурсов, и загрузите типичные слайды в целевую XAML‑среду, чтобы убедиться, что изображения корректно разрешаются.

## **FAQ**

**Как обеспечить предсказуемость шрифтов, если оригинальный шрифт недоступен на машине?**

Установите [DefaultRegularFont](https://reference.aspose.com/slides/ru/net/aspose.slides.export/saveoptions/defaultregularfont/) в [XamlOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export.xaml/xamloptions/) — он используется в качестве резервного шрифта при экспорте, когда оригинал отсутствует. Это не гарантирует, что сгенерированный XAML будет ссылаться на резервный шрифт или что шрифт будет доступен на целевой машине. Убедитесь, что шрифты, используемые в XAML, доступны в среде, где он отображается.

**Предназначен ли экспортированный XAML только для WPF, или его можно использовать и в других стеках XAML?**

Aspose.Slides экспортирует WPF‑XAML через публичный API. Совместимость с другими стеками XAML, такими как UWP и Xamarin.Forms, не гарантируется. Проверьте сгенерированную разметку в целевой среде.

**Поддерживаются ли скрытые слайды и как можно предотвратить их экспорт по умолчанию?**

По умолчанию скрытые слайды не включаются. Вы можете управлять этим поведением через [ExportHiddenSlides](https://reference.aspose.com/slides/ru/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) в [XamlOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export.xaml/xamloptions/) — оставьте его отключённым, если вам не требуется их экспорт.