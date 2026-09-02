---
title: Конвертировать PPT в PPTX в .NET
linktitle: PPT в PPTX
type: docs
weight: 20
url: /ru/net/convert-ppt-to-pptx/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- PPT в PPTX
- сохранить PPT как PPTX
- экспортировать PPT в PPTX
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Конвертировать устаревшие файлы PPT в PPTX в .NET с помощью Aspose.Slides. Включает примеры на C# для конвертации отдельного файла и пакетной обработки, обработку ошибок и замечания о точности."
---
## **Обзор**

PPT — это устаревший двоичный формат PowerPoint, тогда как PPTX — более новый формат Open XML. Aspose.Slides for .NET может загрузить файл PPT и сохранить его как PPTX без Microsoft PowerPoint. Эта статья показывает, как конвертировать один файл или каталог файлов и объясняет, что проверять после конвертации.

## **Конвертировать файл PPT в PPTX**

Загрузите исходный файл с помощью класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/), затем вызовите [IPresentation.Save](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentation/save/) с [SaveFormat.Pptx](https://reference.aspose.com/slides/ru/net/aspose.slides.export/saveformat/). Объявление `using` освобождает презентацию и её ресурсы, когда область видимости заканчивается.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

// Load the legacy PPT presentation.
using var presentation = new Presentation("presentation.ppt");

// Save the presentation in PPTX format.
presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

Расширение файла само по себе не определяет формат вывода; аргумент [SaveFormat.Pptx](https://reference.aspose.com/slides/ru/net/aspose.slides.export/saveformat/) делает это. Держите пути ввода и вывода различными, если вам нужно сохранить оригинальный файл PPT.

## **Конвертировать несколько файлов PPT**

Следующий пример конвертирует каждый файл `.ppt` в одном каталоге. Каждый файл обрабатывается независимо, поэтому одна неудачная конверсия не останавливает остальную часть пакета.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var inputDirectory = "input";
var outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory, "*.ppt", SearchOption.TopDirectoryOnly))
{
    var outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pptx";
    var outputPath = Path.Combine(outputDirectory, outputFileName);

    try
    {
        using var presentation = new Presentation(inputPath);
        presentation.Save(outputPath, SaveFormat.Pptx);
        Console.WriteLine($"Converted: {inputPath}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Failed: {inputPath} ({exception.Message})");
    }
}
```

Для производственных нагрузок запишите полное исключение, решите, можно ли перезаписать существующий файл вывода, и запишите имена неконвертированных файлов в очередь повторных попыток или проверки. Повреждённые файлы, защищённые паролем файлы, открытые без требуемого пароля, недоступные пути и неподдерживаемый контент могут привести к сбою конвертации. См. [Презентации с паролем](/slides/ru/net/password-protected-presentation/) для загрузки зашифрованных файлов.

## **Точность и устаревшие функции**

Конверсия обычно сохраняет слайды, шаблоны, макеты, текст, фигуры, изображения, таблицы и диаграммы. Однако PPT и PPTX не представляют каждую функцию одинаково. Устаревшая функция, которой нет эквивалента в PPTX, или не поддерживаемая библиотекой, может быть нормализована, опущена или отображена иначе.

Проверьте конвертированный файл, если он содержит анимацию, переходы, встроенные или связанные OLE‑объекты, элементы управления ActiveX, встроенные медиа‑файлы, редкие шрифты или макросы VBA. Обычный файл PPTX не поддерживает макросы, поэтому используйте соответствующий рабочий процесс с поддержкой макросов, когда VBA необходимо оставить. Также убедитесь, что требуемые шрифты и внешние ресурсы присутствуют в среде, где будет открываться или рендериться конвертированная презентация.

Для важных документов откройте сгенерированный PPTX программно и проверьте количество ключевых слайдов и содержание, затем сравните его внешний вид и поведение показа слайдов в целевом просмотрщике. Не рассматривайте успешный вызов [IPresentation.Save](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentation/save/) как доказательство того, что каждая устаревшая функция имеет точный аналог в PPTX.

## **Когда использовать PPTX**

Используйте PPTX, когда презентация будет редактироваться в текущих версиях PowerPoint, обмениваться с системами, работающими с пакетами Open XML, или храниться в формате, который проще инспектировать и восстанавливать, чем устаревший бинарный PPT. Сохраняйте оригинальный PPT в качестве архивной или откатной копии, пока конвертированная презентация не пройдет проверку точности.

Если вместо этого вам нужен PDF, HTML, изображения, XPS или другой тип вывода, используйте рекомендации по конкретному формату в [Конвертировать презентации в несколько форматов](/slides/ru/net/convert-presentation/), а не предполагая, что все цели сохраняют редактируемые функции PowerPoint.

## **Онлайн‑конвертер**

Для редкого файла или быстрой сравнения вы можете использовать [онлайн конвертер PPT в PPTX](https://products.aspose.app/slides/ru/conversion/ppt-to-pptx). Для повторяемых конверсий, пакетной обработки или обработки ошибок на уровне приложения используйте .NET API.

## **Связанные статьи**

- [PPT vs PPTX](/slides/ru/net/ppt-vs-pptx/)
- [Сохранить презентации в .NET](/slides/ru/net/save-presentation/)
- [Поддерживаемые форматы файлов](/slides/ru/net/supported-file-formats/)
- [Открыть презентации в .NET](/slides/ru/net/open-presentation/)

## **Вопросы и ответы**

**Могу ли я конвертировать PPT в PPTX без установленного Microsoft PowerPoint?**  
Да. Aspose.Slides for .NET загружает и сохраняет файлы презентаций без необходимости в Microsoft PowerPoint.

**Сохранит ли конверсия PPT в PPTX весь контент точно?**  
Она сохраняет обычный контент презентации, но точная точность не гарантирована для каждой устаревшей или неподдерживаемой функции. Проверьте сгенерированный файл, если он содержит макросы, OLE‑ или ActiveX‑объекты, медиа‑файлы, специализированные анимации или редкие шрифты.

**Могу ли я конвертировать защищённый паролем файл PPT?**  
Да, если вы укажете правильный пароль при загрузке файла. Отсутствие пароля или неверный пароль приводит к ошибке загрузки.

**Стоит ли удалять файл PPT после конвертации?**  
Сохраняйте оригинал до тех пор, пока не проверите PPTX в нужных просмотрщиках и рабочих процессах. Это обеспечивает откатную копию, если устаревшая функция конвертируется иначе.