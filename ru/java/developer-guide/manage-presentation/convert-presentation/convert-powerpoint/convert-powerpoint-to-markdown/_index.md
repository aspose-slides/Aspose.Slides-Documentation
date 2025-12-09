---
title: Конвертация презентаций PowerPoint в Markdown на Java
linktitle: PowerPoint в Markdown
type: docs
weight: 140
url: /ru/java/convert-powerpoint-to-markdown/
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
- Java
- Aspose.Slides
description: "Конвертируйте слайды PowerPoint — PPT, PPTX — в чистый Markdown с помощью Aspose.Slides для Java, автоматизируйте документирование и сохраняйте форматирование."
---

{{% alert color="info" %}} 

Поддержка конвертации PowerPoint в markdown была реализована в [Aspose.Slides 23.7](https://docs.aspose.com/slides/java/aspose-slides-for-java-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

Экспорт PowerPoint в markdown по умолчанию **без изображений**. Если нужно экспортировать документ PowerPoint, содержащий изображения, следует установить `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` и также задать `BasePath`, куда будут сохраняться изображения, упомянутые в markdown‑документе.

{{% /alert %}} 

## **Конвертация PowerPoint в Markdown**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), представляющего объект презентации.
2. Используйте метод [Save ](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-)для сохранения объекта в файл markdown.

Этот Java‑код показывает, как конвертировать PowerPoint в markdown:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```


## Конвертация PowerPoint в различные форматы Markdown

Aspose.Slides позволяет конвертировать PowerPoint в markdown (базовый синтаксис), CommonMark, markdown в стиле GitHub, Trello, XWiki, GitLab и ещё 17 вариантов markdown.

Этот Java‑код показывает, как конвертировать PowerPoint в CommonMark:
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


23 поддерживаемых варианта markdown перечислены в [перечислении Flavor](https://reference.aspose.com/slides/java/com.aspose.slides/flavor/) класса [MarkdownSaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/).

## **Конвертация презентации с изображениями в Markdown**

Класс [MarkdownSaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/) предоставляет свойства и перечисления, позволяющие задавать различные параметры для итогового markdown‑файла. Перечисление [MarkdownExportType](https://reference.aspose.com/slides/java/com.aspose.slides/markdownexporttype/) может принимать значения, определяющие способ обработки изображений: `Sequential`, `TextOnly`, `Visual`.

### **Последовательная конвертация изображений**

Если требуется, чтобы изображения отображались последовательно одно за другим в полученном markdown, выберите опцию sequential. Этот Java‑код демонстрирует, как конвертировать презентацию с изображениями в markdown:
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


### **Визуальная конвертация изображений**

Если нужно, чтобы изображения отображались вместе в полученном markdown, выберите опцию visual. В этом случае изображения будут сохранены в текущий каталог приложения (и в markdown‑документе будет построен относительный путь к ним), либо вы можете указать собственный путь и имя папки.

Этот Java‑код демонстрирует процесс:
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
