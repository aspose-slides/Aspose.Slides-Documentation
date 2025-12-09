---
title: Конвертировать презентации PowerPoint в Markdown в .NET
linktitle: PowerPoint в Markdown
type: docs
weight: 140
url: /ru/net/convert-powerpoint-to-markdown/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в MD
- презентация в MD
- слайд в MD
- PPT в MD
- PPTX в MD
- сохранить PowerPoint как Markdown
- сохранить презентацию как Markdown
- сохранить слайд как Markdown
- сохранить PPT как MD
- сохранить PPTX как MD
- экспортировать PPT в MD
- exportPPTX в MD
- PowerPoint
- презентация
- Markdown
- .NET
- C#
- Aspose.Slides
description: "Конвертировать слайды PowerPoint — PPT, PPTX — в чистый Markdown с помощью Aspose.Slides для .NET, автоматизировать документацию и сохранять форматирование."
---

{{% alert color="info" %}} 
Поддержка преобразования PowerPoint в markdown была реализована в [Aspose.Slides 23.7](https://docs.aspose.com/slides/net/aspose-slides-for-net-23-7-release-notes/).
{{% /alert %}} 

{{% alert color="warning" %}} 
Экспорт PowerPoint в markdown **без изображений** по умолчанию. Если вы хотите экспортировать документ PowerPoint, содержащий изображения, необходимо установить `ExportType = MarkdownExportType.Visual` и задать BasePath, где будут сохраняться изображения, на которые ссылается markdown‑документ.
{{% /alert %}} 

## **Преобразовать PowerPoint в Markdown**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), представляющего объект презентации.  
2. Используйте метод [Save ](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save)для сохранения объекта в файл markdown.

Этот C# код показывает, как преобразовать PowerPoint в markdown:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```


## **Преобразовать PowerPoint в Markdown‑вариант**

Aspose.Slides позволяет конвертировать PowerPoint в markdown (с базовым синтаксисом), CommonMark, GitHub‑flavored markdown, Trello, XWiki, GitLab и ещё 17 вариантов markdown.

Этот C# код показывает, как преобразовать PowerPoint в CommonMark:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```


23 поддерживаемых варианта markdown перечислены в [Flavor enumeration](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/flavor/) класса [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Преобразовать презентацию с изображениями в Markdown**

Класс [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) предоставляет свойства и перечисления, позволяющие задавать параметры создаваемого файла markdown. Перечисление [MarkdownExportType](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) может принимать значения, определяющие способ обработки изображений: `Sequential`, `TextOnly`, `Visual`.

### **Преобразовать изображения последовательно**

Если нужно, чтобы изображения выводились по отдельности друг за другом в итоговом markdown, выберите последовательный вариант. Этот C# код показывает, как преобразовать презентацию с изображениями в markdown:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions
    {
        ShowHiddenSlides = true,
        ShowSlideNumber = true,
        Flavor = Flavor.Github,
        ExportType = MarkdownExportType.Sequential,
        NewLineType = NewLineType.Windows
    };
    
    pres.Save("doc.md", new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
}
```


### **Преобразовать изображения визуально**

Если нужно, чтобы изображения выводились вместе в итоговом markdown, выберите визуальный вариант. В этом случае изображения будут сохранены в текущий каталог приложения (и для них будет построен относительный путь в markdown‑документе), либо можно указать предпочитаемый путь и имя папки.

Этот C# код демонстрирует операцию:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    const string outPath = "c:\\documents";
    pres.Save(Path.Combine(outPath, "pres.md"), SaveFormat.Md, new MarkdownSaveOptions
    { 
        ExportType = MarkdownExportType.Visual,
        ImagesSaveFolderName = "md-images",
        BasePath = outPath
    });
}
```


## **FAQ**

**Сохраняются ли гиперссылки при экспорте в Markdown?**  
Да. Текстовые [hyperlinks](/slides/ru/net/manage-hyperlinks/) сохраняются как стандартные ссылки Markdown. Слайды [transitions](/slides/ru/net/slide-transition/) и [animations](/slides/ru/net/powerpoint-animation/) не конвертируются.

**Могу ли я ускорить конвертацию, запустив её в нескольких потоках?**  
Можно выполнять параллельную обработку файлов, но [don’t share](/slides/ru/net/multithreading/) один и тот же объект [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) между потоками. Используйте отдельные экземпляры/процессы для каждого файла, чтобы избежать конфликтов.

**Что происходит с изображениями — где они сохраняются и являются ли пути относительными?**  
[Images](/slides/ru/net/image/) экспортируются в отдельную папку, а Markdown‑файл ссылается на них относительными путями по умолчанию. Можно настроить базовый путь вывода и имя папки ресурсов, чтобы поддерживать предсказуемую структуру репозитория.