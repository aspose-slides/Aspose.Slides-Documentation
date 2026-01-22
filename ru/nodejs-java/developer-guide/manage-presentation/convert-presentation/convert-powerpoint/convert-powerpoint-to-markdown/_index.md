---
title: Конвертировать презентации PowerPoint в Markdown на JavaScript
linktitle: PowerPoint в Markdown
type: docs
weight: 140
url: /ru/nodejs-java/convert-powerpoint-to-markdown/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Конвертировать слайды PowerPoint в JavaScript — PPT, PPTX — в чистый Markdown с помощью Aspose.Slides для Node.js через Java, автоматизировать документацию и сохранять форматирование."
---

{{% alert color="warning" %}}

Экспорт PowerPoint в markdown по умолчанию **без изображений**. Если вы хотите экспортировать документ PowerPoint, содержащий изображения, вам нужно вызвать `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` и также задать `BasePath`, куда будут сохраняться изображения, на которые ссылается markdown‑документ.

{{% /alert %}}

## **Преобразование PowerPoint в Markdown**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), представляющий объект презентации.
2. Используйте метод [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save-aspose.slides.IXamlOptions-) для сохранения объекта в файл markdown.

Этот код JavaScript показывает, как преобразовать PowerPoint в markdown:
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


## **Преобразование PowerPoint в варианты Markdown**

Aspose.Slides позволяет преобразовать PowerPoint в markdown (с базовым синтаксисом), CommonMark, markdown в стиле GitHub, Trello, XWiki, GitLab и ещё 17 вариантов markdown.

Этот код JavaScript показывает, как преобразовать PowerPoint в CommonMark:
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

## **Преобразование презентации с изображениями в Markdown**

Класс [MarkdownSaveOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markdownsaveoptions/) предоставляет свойства и перечисления, позволяющие задавать различные параметры для результирующего markdown‑файла. Перечисление [MarkdownExportType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markdownexporttype/) может быть установлено в значения, определяющие, как изображения отображаются или обрабатываются: `Sequential`, `TextOnly`, `Visual`.

### **Последовательное преобразование изображений**

Если вы хотите, чтобы изображения появлялись одно за другим в результирующем markdown, выберите последовательный вариант. Этот код JavaScript показывает, как преобразовать презентацию с изображениями в markdown:
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


### **Визуальное преобразование изображений**

Если вы хотите, чтобы изображения отображались вместе в результирующем markdown, выберите визуальный вариант. В этом случае изображения будут сохранены в текущий каталог приложения (и в markdown‑документе будет построен относительный путь к ним), либо вы можете указать предпочтительный путь и имя папки.

Этот код JavaScript демонстрирует операцию:
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

Да. Текстовые [гиперссылки](/slides/ru/nodejs-java/manage-hyperlinks/) сохраняются как стандартные ссылки Markdown. [Переходы](/slides/ru/nodejs-java/slide-transition/) и [анимации](/slides/ru/nodejs-java/powerpoint-animation/) слайдов не преобразуются.

**Могу ли я ускорить конвертацию, запустив её в нескольких потоках?**

Можно выполнять конвертацию параллельно для разных файлов, но [не делитесь](/slides/ru/nodejs-java/multithreading/) одним и тем же объектом [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) между потоками. Используйте отдельные экземпляры/процессы для каждого файла, чтобы избежать конфликтов.

**Что происходит с изображениями — где они сохраняются и являются ли пути относительными?**

[Изображения](/slides/ru/nodejs-java/image/) экспортируются в отдельную папку, а Markdown‑файл по умолчанию ссылается на них относительными путями. Вы можете настроить базовый путь вывода и имя папки ресурсов, чтобы поддерживать предсказуемую структуру репозитория.