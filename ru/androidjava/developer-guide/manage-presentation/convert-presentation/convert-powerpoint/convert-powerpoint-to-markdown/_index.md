---
title: Конвертировать презентации PowerPoint в Markdown на Android
linktitle: PowerPoint в Markdown
type: docs
weight: 140
url: /ru/androidjava/convert-powerpoint-to-markdown/
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
- Android
- Java
- Aspose.Slides
description: "Конвертировать слайды PowerPoint—PPT, PPTX—в чистый Markdown с помощью Aspose.Slides для Android на Java, автоматизировать документацию и сохранять форматирование."
---

{{% alert color="info" %}} 

Поддержка конвертации PowerPoint в markdown была реализована в [Aspose.Slides 23.7](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

Экспорт PowerPoint в markdown **по умолчанию без изображений**. Если вы хотите экспортировать документ PowerPoint, содержащий изображения, необходимо установить `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` и также задать `BasePath`, куда будут сохраняться изображения, упомянутые в markdown‑документе.

{{% /alert %}} 

## **Конвертировать PowerPoint в Markdown**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), представляющего объект презентации.  
2. Используйте метод [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) для сохранения объекта в markdown‑файл.

Этот Java‑код показывает, как конвертировать PowerPoint в markdown:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Конвертировать PowerPoint в варианты Markdown**

Aspose.Slides позволяет конвертировать PowerPoint в markdown (с базовым синтаксисом), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab и ещё 17 вариантов markdown.

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


23 поддерживаемых варианта markdown перечислены в [перечислении Flavor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/flavor/) класса [MarkdownSaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownsaveoptions/).

## **Конвертировать презентацию, содержащую изображения, в Markdown**

Класс [MarkdownSaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownsaveoptions/) предоставляет свойства и перечисления, позволяющие использовать определённые параметры или настройки для получаемого markdown‑файла. Перечисление [MarkdownExportType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownexporttype/) , например, может быть установлено в значения, определяющие, как изображения будут отображаться или обрабатываться: `Sequential`, `TextOnly`, `Visual`.

### **Конвертировать изображения последовательно**

Если вы хотите, чтобы изображения отображались по отдельности одно за другим в результирующем markdown, необходимо выбрать последовательный вариант. Этот Java‑код показывает, как конвертировать презентацию с изображениями в markdown:
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


### **Конвертировать изображения визуально**

Если вы хотите, чтобы изображения отображались совместно в результирующем markdown, необходимо выбрать визуальный вариант. В этом случае изображения будут сохранены в текущий каталог приложения (и в markdown‑документе будет построен относительный путь к ним), либо вы можете указать предпочтительный путь и имя папки.

Этот Java‑код демонстрирует операцию:
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


## **FAQ**

**Сохраняются ли гиперссылки при экспорте в Markdown?**

Да. Текстовые [гиперссылки](/slides/ru/androidjava/manage-hyperlinks/) сохраняются как обычные ссылки Markdown. [Переходы](/slides/ru/androidjava/slide-transition/) и [анимации](/slides/ru/androidjava/powerpoint-animation/) слайдов не конвертируются.

**Могу ли я ускорить конвертацию, запуская её в нескольких потоках?**

Вы можете выполнять параллельную обработку разных файлов, но [не делитесь](/slides/ru/androidjava/multithreading/) одним экземпляром [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) между потоками. Используйте отдельные экземпляры/процессы для каждого файла, чтобы избежать конфликтов.

**Что происходит с изображениями — где они сохраняются и являются ли пути относительными?**

[Изображения](/slides/ru/androidjava/image/) экспортируются в отдельную папку, а Markdown‑файл по умолчанию ссылается на них относительно. Вы можете настроить базовый путь вывода и имя папки ресурсов, чтобы обеспечить предсказуемую структуру репозитория.