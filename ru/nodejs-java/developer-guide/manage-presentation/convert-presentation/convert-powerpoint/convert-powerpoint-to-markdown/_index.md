---
title: Конвертировать PowerPoint в Markdown на JavaScript
type: docs
weight: 140
url: /ru/nodejs-java/convert-powerpoint-to-markdown/
keywords: "Конвертировать PowerPoint в Markdown, Конвертировать ppt в md, PowerPoint, PPT, PPTX, Презентация, Markdown, Java, Aspose.Slides for Node.js via Java"
description: "Конвертировать PowerPoint в Markdown на JavaScript"
---

{{% alert color="info" %}} 

Поддержка конвертации PowerPoint в markdown реализована в [Aspose.Slides 23.7](https://docs.aspose.com/slides/nodejs-java/aspose-slides-for-java-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

Экспорт PowerPoint в markdown **по умолчанию без изображений**. Если нужно экспортировать документ PowerPoint с изображениями, вызовите `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` и также задайте `BasePath`, куда будут сохраняться изображения, используемые в markdown‑документе.

{{% /alert %}} 

## **Конвертация PowerPoint в Markdown**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) для представления объекта презентации.  
2. Используйте метод [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save-aspose.slides.IXamlOptions-) для сохранения объекта в файл markdown.

Этот JavaScript‑код демонстрирует, как конвертировать PowerPoint в markdown:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.md", aspose.slides.SaveFormat.Md);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Конвертация PowerPoint в различные варианты markdown**

Aspose.Slides позволяет конвертировать PowerPoint в markdown (с базовым синтаксисом), CommonMark, GitHub‑flavored markdown, Trello, XWiki, GitLab и ещё 17 вариантов markdown.

Этот JavaScript‑код показывает, как конвертировать PowerPoint в CommonMark:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.CommonMark);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


23 поддерживаемых варианта markdown перечислены в [перечислении Flavor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/flavor/) класса [MarkdownSaveOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markdownsaveoptions/).

## **Конвертация презентации с изображениями в Markdown**

Класс [MarkdownSaveOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markdownsaveoptions/) предоставляет свойства и перечисления, позволяющие задать параметры для результирующего markdown‑файла. Перечисление [MarkdownExportType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markdownexporttype/) может принимать значения, определяющие способ обработки изображений: `Sequential`, `TextOnly`, `Visual`.

### **Последовательная конвертация изображений**

Если требуется, чтобы изображения появлялись по одному в результирующем markdown, выберите вариант `Sequential`. Этот JavaScript‑код демонстрирует, как конвертировать презентацию с изображениями в markdown:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.Github);
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(aspose.slides.NewLineType.Windows);
    pres.save("doc.md", java.newArray("int", [1, 2, 3, 4, 5, 6, 7, 8, 9]), aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Визуальная конвертация изображений**

Если нужно, чтобы изображения отображались вместе в результирующем markdown, выберите вариант `Visual`. В этом случае изображения сохраняются в текущий каталог приложения (и в markdown‑документе будет построен относительный путь), либо можно указать свой путь и имя папки.

Этот JavaScript‑код демонстрирует процесс:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    final var outPath = "c:/documents";
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Сохраняются ли гиперссылки при экспорте в Markdown?**

Да. Текстовые [гиперссылки](/slides/ru/nodejs-java/manage-hyperlinks/) сохраняются как обычные ссылки Markdown. [Переходы](/slides/ru/nodejs-java/slide-transition/) и [анимации](/slides/ru/nodejs-java/powerpoint-animation/) слайдов не конвертируются.

**Можно ли ускорить конвертацию, запустив её в нескольких потоках?**

Можно выполнять параллельную обработку файлов, но [не следует делить](/slides/ru/nodejs-java/multithreading/) один и тот же объект [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) между потоками. Используйте отдельные экземпляры или процессы для каждого файла, чтобы избежать конфликтов.

**Что происходит с изображениями — где они сохраняются и являются ли пути относительными?**

[Изображения](/slides/ru/nodejs-java/image/) экспортируются в отдельную папку, а markdown‑файл по умолчанию ссылается на них относительными путями. Можно настроить базовый путь вывода и имя папки ресурсов, чтобы обеспечить предсказуемую структуру репозитория.