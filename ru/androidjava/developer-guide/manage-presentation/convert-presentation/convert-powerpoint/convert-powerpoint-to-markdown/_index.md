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
- экспортировать PPTX в MD
- PowerPoint
- презентация
- Markdown
- Android
- Java
- Aspose.Slides
description: "Конвертируйте слайды PowerPoint — PPT, PPTX — в чистый Markdown с помощью Aspose.Slides для Android на Java, автоматизируйте документацию и сохраняйте форматирование."
---

Aspose.Slides поддерживает преобразование презентаций в markdown.

{{% alert color="warning" %}} 

Экспорт PowerPoint в markdown по умолчанию **без изображений**. Если вы хотите экспортировать документ PowerPoint, содержащий изображения, вам нужно установить `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` и также задать `BasePath`, куда будут сохраняться изображения, на которые ссылается markdown‑документ.

{{% /alert %}} 

## **Преобразовать PowerPoint в Markdown**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) для представления объекта презентации.  
2. Используйте метод [Save ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-)для сохранения объекта в markdown‑файл.

Этот Java‑код показывает, как преобразовать PowerPoint в markdown:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Преобразовать PowerPoint в Markdown‑формат**

Aspose.Slides позволяет преобразовать PowerPoint в markdown (с базовым синтаксисом), CommonMark, GitHub‑flavored markdown, Trello, XWiki, GitLab и ещё 17 вариантов markdown.

Этот Java‑код показывает, как преобразовать PowerPoint в CommonMark:
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


23 поддерживаемых варианта markdown перечислены в [Flavor enumeration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/flavor/) класса [MarkdownSaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownsaveoptions/).

## **Преобразовать презентацию с изображениями в Markdown**

Класс [MarkdownSaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownsaveoptions/) предоставляет свойства и перечисления, позволяющие задавать определённые параметры для результирующего markdown‑файла. Перечисление [MarkdownExportType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownexporttype/) может быть установлено в значения, определяющие способ обработки изображений: `Sequential`, `TextOnly`, `Visual`.

### **Последовательное преобразование изображений**

Если вы хотите, чтобы изображения появлялись по отдельности одно за другим в результирующем markdown, необходимо выбрать последовательный вариант. Этот Java‑код показывает, как преобразовать презентацию с изображениями в markdown:
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


### **Визуальное преобразование изображений**

Если вы хотите, чтобы изображения отображались вместе в результирующем markdown, необходимо выбрать визуальный вариант. В этом случае изображения будут сохраняться в текущий каталог приложения (и для них будет построен относительный путь в markdown‑документе), либо вы можете указать предпочитаемый путь и имя папки.

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


## **Вопросы и ответы**

**Сохраняются ли гиперссылки при экспорте в Markdown?**

Да. Текст [hyperlinks](/slides/ru/androidjava/manage-hyperlinks/) сохраняется как стандартные ссылки Markdown. Слайды [transitions](/slides/ru/androidjava/slide-transition/) и [animations](/slides/ru/androidjava/powerpoint-animation/) не конвертируются.

**Могу ли я ускорить конвертацию, запустив её в нескольких потоках?**

Можно выполнять параллельную обработку файлов, но [don’t share](/slides/ru/androidjava/multithreading/) один и тот же объект [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) между потоками. Используйте отдельные экземпляры/процессы для каждого файла, чтобы избежать конкуренции.

**Что происходит с изображениями — где они сохраняются и являются ли пути относительными?**

[Images](/slides/ru/androidjava/image/) экспортируются в отдельную папку, а Markdown‑файл по умолчанию ссылается на них относительными путями. Вы можете настроить базовый путь вывода и имя папки ресурсов, чтобы поддерживать предсказуемую структуру репозитория.