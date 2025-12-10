---
title: Конвертировать презентации PowerPoint в Markdown на Java
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
- презентацию в MD
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
description: "Конвертировать слайды PowerPoint — PPT, PPTX — в чистый Markdown с помощью Aspose.Slides для Java, автоматизировать документацию и сохранять форматирование."
---

{{% alert color="info" %}} 

Поддержка конверсии PowerPoint в markdown была реализована в [Aspose.Slides 23.7](https://docs.aspose.com/slides/java/aspose-slides-for-java-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

Экспорт PowerPoint в markdown **по умолчанию без изображений**. Если нужно экспортировать документ PowerPoint с изображениями, необходимо установить `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` и задать `BasePath`, куда будут сохраняться изображения, используемые в markdown‑документе.

{{% /alert %}} 

## **Преобразовать PowerPoint в Markdown**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) для представления объекта презентации.  
2. Используйте метод [Save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) для сохранения объекта в файл markdown.

Этот Java‑код демонстрирует, как преобразовать PowerPoint в markdown:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Преобразовать PowerPoint в вариант Markdown**

Aspose.Slides позволяет конвертировать PowerPoint в markdown (с базовым синтаксисом), CommonMark, GitHub‑flavored markdown, Trello, XWiki, GitLab и ещё 17 вариантов markdown.

Этот Java‑код демонстрирует, как преобразовать PowerPoint в CommonMark:
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


23 поддерживаемых варианта markdown перечислены в [Flavor enumeration](https://reference.aspose.com/slides/java/com.aspose.slides/flavor/) класса [MarkdownSaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/).

## **Преобразовать презентацию с изображениями в Markdown**

Класс [MarkdownSaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/) предоставляет свойства и перечисления, позволяющие задать различные параметры результирующего markdown‑файла. Перечисление [MarkdownExportType](https://reference.aspose.com/slides/java/com.aspose.slides/markdownexporttype/) может принимать значения, определяющие способ обработки изображений: `Sequential`, `TextOnly`, `Visual`.

### **Преобразовать изображения последовательно**

Если необходимо, чтобы изображения отображались по одному последовательно в результирующем markdown, выбирайте опцию последовательной обработки. Этот Java‑код показывает, как преобразовать презентацию с изображениями в markdown:
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


### **Преобразовать изображения визуально**

Если нужно, чтобы изображения отображались вместе в результирующем markdown, выбирайте визуальную опцию. В этом случае изображения сохраняются в текущий каталог приложения (для них формируется относительный путь в markdown‑документе) или вы можете указать собственный путь и имя папки.

Этот Java‑код демонстрирует данную операцию:
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


## **Часто задаваемые вопросы**

**Сохраняются ли гиперссылки при экспорте в Markdown?**

Да. Текстовые [hyperlinks](/slides/ru/java/manage-hyperlinks/) сохраняются как стандартные Markdown‑ссылки. [transitions](/slides/ru/java/slide-transition/) и [animations](/slides/ru/java/powerpoint-animation/) слайдов не конвертируются.

**Можно ли ускорить конвертацию, запустив её в нескольких потоках?**

Можно параллелить работу по файлам, но [don’t share](/slides/ru/java/multithreading/) один и тот же объект [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) между потоками. Используйте отдельные экземпляры/процессы для каждого файла, чтобы избежать конфликтов.

**Что происходит с изображениями — где они сохраняются и являются ли пути относительными?**

[Images](/slides/ru/java/image/) экспортируются в отдельную папку, а Markdown‑файл по умолчанию ссылается на них относительными путями. Вы можете настроить базовый путь вывода и имя папки ресурсов, чтобы поддерживать предсказуемую структуру репозитория.