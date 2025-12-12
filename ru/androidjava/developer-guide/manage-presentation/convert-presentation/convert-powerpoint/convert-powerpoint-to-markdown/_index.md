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
description: "Конвертировать слайды PowerPoint - PPT, PPTX - в чистый Markdown с помощью Aspose.Slides для Android на Java, автоматизировать документацию и сохранять форматирование."
---

{{% alert color="info" %}} 
Поддержка конвертации PowerPoint в markdown была реализована в [Aspose.Slides 23.7](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-23-7-release-notes/).
{{% /alert %}} 

{{% alert color="warning" %}} 
Экспорт PowerPoint в markdown по умолчанию **без изображений**. Если вы хотите экспортировать документ PowerPoint, содержащий изображения, необходимо установить `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` и также задать `BasePath`, куда будут сохраняться изображения, на которые ссылается markdown‑документ.
{{% /alert %}} 

## **Конвертировать PowerPoint в Markdown**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) для представления объекта презентации.  
2. Используйте метод [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) для сохранения объекта в файл markdown.  

Этот Java‑код показывает, как конвертировать PowerPoint в markdown:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Конвертировать PowerPoint в формат Markdown**

Aspose.Slides позволяет конвертировать PowerPoint в markdown (с базовым синтаксисом), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab и 17 других вариантов markdown.  

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


23 поддерживаемых формата markdown перечислены в [списке перечисления Flavor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/flavor/) класса [MarkdownSaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownsaveoptions/).  

## **Конвертировать презентацию с изображениями в Markdown**

Класс [MarkdownSaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownsaveoptions/) предоставляет свойства и перечисления, позволяющие использовать определённые параметры или настройки для получаемого markdown‑файла. Перечисление [MarkdownExportType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownexporttype/) может, например, принимать значения, определяющие, как изображения будут отображаться или обрабатываться: `Sequential`, `TextOnly`, `Visual`.  

### **Конвертировать изображения последовательно**

Если вы хотите, чтобы изображения отображались последовательно одно за другим в получаемом markdown, необходимо выбрать опцию sequential. Этот Java‑код показывает, как конвертировать презентацию с изображениями в markdown:
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

Если вы хотите, чтобы изображения отображались вместе в получаемом markdown, необходимо выбрать опцию visual. В этом случае изображения будут сохранены в текущий каталог приложения (и в markdown‑документе будет построен относительный путь к ним), либо вы можете указать предпочтительный путь и имя папки.  

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

Да. Текстовые [hyperlinks](/slides/ru/androidjava/manage-hyperlinks/) сохраняются как стандартные ссылки Markdown. Переходы слайдов [transitions](/slides/ru/androidjava/slide-transition/) и [animations](/slides/ru/androidjava/powerpoint-animation/) не конвертируются.  

**Могу ли я ускорить конвертацию, запустив её в нескольких потоках?**  

Вы можете параллелить обработку файлов, но [don’t share](/slides/ru/androidjava/multithreading/) один и тот же [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) экземпляр между потоками. Используйте отдельные экземпляры/процессы для каждого файла, чтобы избежать конфликтов.  

**Что происходит с изображениями — где они сохраняются и являются ли пути относительными?**  

[Images](/slides/ru/androidjava/image/) экспортируются в отдельную папку, а файл Markdown ссылается на них относительными путями по умолчанию. Вы можете настроить базовый путь вывода и имя папки ресурсов, чтобы поддерживать предсказуемую структуру репозитория.