---
title: Конвертация PowerPoint в Markdown на C#
type: docs
weight: 140
url: /net/convert-powerpoint-to-markdown/
keywords: "Конвертация PowerPoint в Markdown, Конвертация ppt в md, PowerPoint, PPT, PPTX, Презентация, Markdown, C#, Csharp, .NET, Aspose.Slides"
description: "Конвертация PowerPoint в Markdown на C#"
---

{{% alert color="info" %}} 

Поддержка конвертации PowerPoint в markdown была реализована в [Aspose.Slides 23.7](https://docs.aspose.com/slides/net/aspose-slides-for-net-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

Экспорт PowerPoint в markdown **без изображений** по умолчанию. Если вы хотите экспортировать документ PowerPoint, содержащий изображения, вам необходимо задать `ExportType = MarkdownExportType.Visual` и указать BasePath, где будут сохранены изображения, на которые ссылается markdown документ.

{{% /alert %}} 

## **Конвертация PowerPoint в Markdown**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), чтобы представить объект презентации.
2. Используйте метод [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save), чтобы сохранить объект в виде markdown файла.

Этот код на C# показывает, как конвертировать PowerPoint в markdown:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```

## Конвертация PowerPoint в различные форматы Markdown

Aspose.Slides позволяет конвертировать PowerPoint в markdown (с базовым синтаксисом), CommonMark, GitHub-совместимый markdown, Trello, XWiki, GitLab и 17 других форматов markdown.

Этот код на C# показывает, как конвертировать PowerPoint в CommonMark:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```

23 поддерживаемых формата markdown [перечислены в перечислении Flavor](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/flavor/) из класса [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Конвертация презентации, содержащей изображения, в Markdown**

Класс [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) предоставляет свойства и перечисления, которые позволяют использовать определенные параметры или настройки для результирующего markdown файла. Например, перечисление [MarkdownExportType](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) может быть установлено на значения, определяющие, как обрабатываются или отображаются изображения: `Sequential`, `TextOnly`, `Visual`.

### **Последовательная конвертация изображений**

Если вы хотите, чтобы изображения отображались по одному, одно за другим в результирующем markdown, вам нужно выбрать последовательный вариант. Этот код на C# показывает, как конвертировать презентацию, содержащую изображения, в markdown:

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

### **Визуальная конвертация изображений**

Если вы хотите, чтобы изображения отображались вместе в результирующем markdown, вам нужно выбрать визуальный вариант. В этом случае изображения будут сохранены в текущем каталоге приложения (и для них будет построен относительный путь в markdown документе), или вы можете указать свой предпочтительный путь и имя папки.

Этот код на C# демонстрирует операцию:

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