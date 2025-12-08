---
title: Конвертировать PowerPoint в Markdown на C#
type: docs
weight: 140
url: /ru/net/convert-powerpoint-to-markdown/
keywords: "Конвертировать PowerPoint в Markdown, Конвертировать ppt в md, PowerPoint, PPT, PPTX, Презентация, Markdown, C#, Csharp, .NET, Aspose.Slides"
description: "Конвертировать PowerPoint в Markdown на C#"
---

{{% alert color="info" %}} 

Поддержка конвертации PowerPoint в markdown была реализована в [Aspose.Slides 23.7](https://docs.aspose.com/slides/net/aspose-slides-for-net-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

Экспорт PowerPoint в markdown по умолчанию **без изображений**. Если вы хотите экспортировать документ PowerPoint, содержащий изображения, вам нужно задать `ExportType = MarkdownExportType.Visual` и установить BasePath, куда будут сохраняться изображения, на которые ссылается markdown‑документ.

{{% /alert %}} 

## **Преобразование PowerPoint в Markdown**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), представляющего объект презентации.
2. Используйте метод [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save), чтобы сохранить объект в markdown‑файл.

Этот код C# показывает, как преобразовать PowerPoint в markdown:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```


## **Преобразование PowerPoint в варианты Markdown**

Aspose.Slides позволяет преобразовать PowerPoint в markdown (с базовым синтаксисом), CommonMark, GitHub‑flavored markdown, Trello, XWiki, GitLab и еще 17 вариантов markdown.

Этот код C# показывает, как преобразовать PowerPoint в CommonMark:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```


23 поддерживаемых варианта markdown перечислены в [Flavor enumeration](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/flavor/) из класса [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Преобразование презентации с изображениями в Markdown**

Класс [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) предоставляет свойства и перечисления, позволяющие использовать определённые параметры или настройки для получаемого markdown‑файла. Перечисление [MarkdownExportType](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/), например, может быть установлено в значения, определяющие, как изображения отображаются или обрабатываются: `Sequential`, `TextOnly`, `Visual`.

### **Последовательное преобразование изображений**

Если вы хотите, чтобы изображения появлялись по отдельности одно за другим в получаемом markdown, необходимо выбрать опцию sequential. Этот код C# показывает, как преобразовать презентацию с изображениями в markdown:
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


### **Визуальное преобразование изображений**

Если вы хотите, чтобы изображения отображались вместе в получаемом markdown, необходимо выбрать опцию visual. В этом случае изображения будут сохранены в текущий каталог приложения (и в markdown‑документе будет построен относительный путь к ним), либо вы можете указать свой предпочтительный путь и имя папки.

Этот код C# демонстрирует операцию:
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

Да. Текстовые [гиперссылки](/slides/ru/net/manage-hyperlinks/) сохраняются как стандартные ссылки Markdown. [Переходы](/slides/ru/net/slide-transition/) и [анимации](/slides/ru/net/powerpoint-animation/) слайдов не конвертируются.

**Можно ли ускорить конвертацию, запустив её в нескольких потоках?**

Можно распараллелить обработку файлов, но [не следует делить](/slides/ru/net/multithreading/) один и тот же объект [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) между потоками. Используйте отдельные экземпляры/процессы для каждого файла, чтобы избежать конфликтов.

**Что происходит с изображениями — где они сохраняются и являются ли пути относительными?**

[Изображения](/slides/ru/net/image/) экспортируются в отдельную папку, а файл Markdown по умолчанию ссылается на них относительными путями. Вы можете настроить базовый путь вывода и имя папки ресурсов, чтобы поддерживать предсказуемую структуру репозитория.