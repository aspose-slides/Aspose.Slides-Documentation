---
title: Конвертировать презентации PowerPoint в Markdown на .NET
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
- экспортировать PPTX в MD
- PowerPoint
- презентация
- Markdown
- .NET
- C#
- Aspose.Slides
description: "Конвертировать слайды PowerPoint—PPT, PPTX—в чистый Markdown с помощью Aspose.Slides для .NET, автоматизировать документацию и сохранять форматирование."
---

{{% alert color="info" %}} 

Поддержка преобразования PowerPoint в markdown была реализована в [Aspose.Slides 23.7](https://docs.aspose.com/slides/net/aspose-slides-for-net-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

Экспорт PowerPoint в markdown по умолчанию **без изображений**. Если вы хотите экспортировать документ PowerPoint, содержащий изображения, необходимо установить `ExportType = MarkdownExportType.Visual` и задать BasePath, куда будут сохраняться изображения, используемые в markdown‑документе.

{{% /alert %}} 

## **Преобразовать PowerPoint в Markdown**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), представляющего объект презентации.
2. Используйте метод [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save), чтобы сохранить объект в файл markdown.

Этот C#‑код показывает, как преобразовать PowerPoint в markdown:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```


## **Преобразовать PowerPoint в вариант Markdown**

Aspose.Slides позволяет преобразовать PowerPoint в markdown (с базовым синтаксисом), CommonMark, GitHub‑flavored markdown, Trello, XWiki, GitLab и ещё 17 вариантов markdown.

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


23 поддерживаемых варианта markdown перечислены в [Flavor enumeration](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/flavor/) класса [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Преобразовать презентацию с изображениями в Markdown**

Класс [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) предоставляет свойства и перечисления, позволяющие задавать параметры для получаемого markdown‑файла. Перечисление [MarkdownExportType](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) может принимать значения, определяющие, как будут обрабатываться изображения: `Sequential`, `TextOnly`, `Visual`.

### **Последовательное преобразование изображений**

Если вы хотите, чтобы изображения отображались последовательно одно за другим в полученном markdown, выберите параметр последовательного экспорта. Этот C#‑код показывает, как преобразовать презентацию с изображениями в markdown:
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

Если вы хотите, чтобы изображения отображались вместе в полученном markdown, выберите параметр визуального экспорта. В этом случае изображения сохраняются в текущий каталог приложения (и в markdown‑документе создаётся относительный путь к ним), либо вы можете указать собственный путь и имя папки.

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

Да. Текстовые [гиперссылки](/slides/ru/net/manage-hyperlinks/) сохраняются как стандартные ссылки Markdown. [Переходы](/slides/ru/net/slide-transition/) и [анимации](/slides/ru/net/powerpoint-animation/) слайдов не конвертируются.

**Могу ли я ускорить конвертацию, запустив её в нескольких потоках?**

Можно выполнять параллельную обработку файлов, но [не следует делить](/slides/ru/net/multithreading/) один и тот же объект [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) между потоками. Используйте отдельные экземпляры/процессы для каждого файла, чтобы избежать конфликтов.

**Что происходит с изображениями — где они сохраняются и являются ли пути относительными?**

[Изображения](/slides/ru/net/image/) экспортируются в отдельную папку, а файл Markdown по умолчанию ссылается на них относительными путями. Вы можете настроить базовый путь вывода и имя папки ассетов, чтобы поддерживать предсказуемую структуру репозитория.