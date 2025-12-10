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
description: "Конвертировать слайды PowerPoint - PPT, PPTX - в чистый Markdown с помощью Aspose.Slides для .NET, автоматизировать документацию и сохранять форматирование."
---

{{% alert color="info" %}} 

Поддержка преобразования PowerPoint в markdown была реализована в [Aspose.Slides 23.7](https://docs.aspose.com/slides/net/aspose-slides-for-net-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

Экспорт PowerPoint в markdown **без изображений** по умолчанию. Если вам нужно экспортировать документ PowerPoint с изображениями, необходимо установить `ExportType = MarkdownExportType.Visual` и задать BasePath, куда будут сохраняться изображения, упомянутые в markdown‑документе.

{{% /alert %}} 

## **Преобразование PowerPoint в Markdown**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) для представления объекта презентации.  
2. Используйте метод [Save ]для сохранения объекта в файл markdown.

Этот C#‑код показывает, как преобразовать PowerPoint в markdown:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```


## **Преобразование PowerPoint в варианты Markdown**

Aspose.Slides позволяет преобразовать PowerPoint в markdown (с базовым синтаксисом), CommonMark, GitHub‑flavored markdown, Trello, XWiki, GitLab и еще 17 других вариантов markdown.

Этот C#‑код показывает, как преобразовать PowerPoint в CommonMark:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```


23 поддерживаемых варианта markdown перечислены в [списке Flavor enumeration](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/flavor/) класса [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Преобразование презентации с изображениями в Markdown**

Класс [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) предоставляет свойства и перечисления, позволяющие задавать различные параметры для получаемого markdown‑файла. Перечисление [MarkdownExportType](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) можно установить в значения, определяющие способ обработки изображений: `Sequential`, `TextOnly`, `Visual`.

### **Преобразование изображений последовательно**

Если вам нужно, чтобы изображения отображались одно за другим в полученном markdown, выберите последовательный вариант. Этот C#‑код показывает, как преобразовать презентацию с изображениями в markdown:
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


### **Преобразование изображений визуально**

Если вам нужно, чтобы изображения отображались вместе в полученном markdown, выберите визуальный вариант. В этом случае изображения будут сохранены в текущий каталог приложения (и в markdown‑документе будет сформирован относительный путь), либо вы можете указать свой путь и имя папки.

Этот C#‑код демонстрирует операцию:
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

Да. Текстовые [hyperlinks](/slides/ru/net/manage-hyperlinks/) сохраняются как стандартные ссылки Markdown. Слайды с [transitions](/slides/ru/net/slide-transition/) и [animations](/slides/ru/net/powerpoint-animation/) не конвертируются.

**Могу ли я ускорить конвертацию, запустив её в нескольких потоках?**

Можно распараллелить обработку по файлам, но [не делите](/slides/ru/net/multithreading/) один и тот же объект [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) между потоками. Используйте отдельные экземпляры или процессы для каждого файла, чтобы избежать конфликтов.

**Что происходит с изображениями — где они сохраняются и являются ли пути относительными?**

[Images](/slides/ru/net/image/) экспортируются в отдельную папку, а markdown‑файл ссылается на них относительными путями по умолчанию. Вы можете задать базовый путь вывода и имя папки ресурсов, чтобы поддерживать предсказуемую структуру репозитория.