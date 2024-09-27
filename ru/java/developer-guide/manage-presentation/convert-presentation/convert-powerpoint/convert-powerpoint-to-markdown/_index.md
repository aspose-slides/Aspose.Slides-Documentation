---
title: Конвертация PowerPoint в Markdown на Java
type: docs
weight: 140
url: /ru/java/convert-powerpoint-to-markdown/
keywords: "Конвертация PowerPoint в Markdown, Конвертировать ppt в md, PowerPoint, PPT, PPTX, Презентация, Markdown, Java, Aspose.Slides для Java"
description: "Конвертация PowerPoint в Markdown на Java"
---

{{% alert color="info" %}} 

Поддержка конвертации PowerPoint в markdown была реализована в [Aspose.Slides 23.7](https://docs.aspose.com/slides/java/aspose-slides-for-java-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

Экспорт PowerPoint в markdown **без изображений** по умолчанию. Если вы хотите экспортировать документ PowerPoint, содержащий изображения, вам нужно установить `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` и также установить `BasePath`, куда будут сохранены изображения, упомянутые в документе markdown.

{{% /alert %}} 

## **Конвертация PowerPoint в Markdown**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), чтобы представить объект презентации.
2. Используйте метод [Save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-), чтобы сохранить объект в виде файла markdown.

Этот код на Java показывает, как конвертировать PowerPoint в markdown:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## Конвертация PowerPoint в Markdown Flavor

Aspose.Slides позволяет вам конвертировать PowerPoint в markdown (с основным синтаксисом), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab и 17 других вариантов markdown.

Этот код на Java показывает, как конвертировать PowerPoint в CommonMark:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(Flavor.CommonMark);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

23 поддерживаемых варианта markdown [перечислены в перечислении Flavor](https://reference.aspose.com/slides/java/com.aspose.slides/flavor/) из класса [MarkdownSaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/).

## **Конвертация Презентации, Содержащей Изображения, в Markdown**

Класс [MarkdownSaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/) предоставляет свойства и перечисления, которые позволяют использовать определенные параметры или настройки для результирующего файла markdown. Например, перечисление [MarkdownExportType](https://reference.aspose.com/slides/java/com.aspose.slides/markdownexporttype/) может быть установлено на значения, которые определяют, как обрабатываются или отображаются изображения: `Sequential`, `TextOnly`, `Visual`.

### **Конвертация Изображений Последовательно**

Если вы хотите, чтобы изображения отображались по одному в результирующем markdown, вам нужно выбрать последовательный вариант. Этот код на Java показывает, как конвертировать презентацию, содержащую изображения, в markdown:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(Flavor.Github);
    markdownSaveOptions.setExportType(MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(NewLineType.Windows);
    pres.save("doc.md", new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Конвертация Изображений Визуально**

Если вы хотите, чтобы изображения отображались вместе в результирующем markdown, вам нужно выбрать визуальный вариант. В этом случае изображения будут сохранены в текущем каталоге приложения (и будет построен относительный путь для них в документе markdown), или вы можете указать предпочитаемый путь и имя папки.

Этот код на Java демонстрирует операцию:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    final String outPath = "c:/documents";
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setExportType(MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```