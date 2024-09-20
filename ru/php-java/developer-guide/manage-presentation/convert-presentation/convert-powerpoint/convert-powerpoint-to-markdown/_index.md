---
title: Конвертация PowerPoint в Markdown
type: docs
weight: 140
url: /php-java/convert-powerpoint-to-markdown/
keywords: "Конвертация PowerPoint в Markdown, Конвертация ppt в md, PowerPoint, PPT, PPTX, Презентация, Markdown, Java, Aspose.Slides для PHP через Java"
description: "Конвертация PowerPoint в Markdown"
---

{{% alert color="info" %}} 

Поддержка конвертации PowerPoint в Markdown была реализована в [Aspose.Slides 23.7](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

Экспорт PowerPoint в Markdown **без изображений** по умолчанию. Если вы хотите экспортировать документ PowerPoint, содержащий изображения, вам необходимо задать `markdownSaveOptions.setExportType(MarkdownExportType::Visual)` и также задать `BasePath`, где будут сохраняться изображения, на которые ссылается документ Markdown.

{{% /alert %}} 

## **Конвертация PowerPoint в Markdown**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), чтобы представить объект презентации.
2. Используйте метод [Save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-), чтобы сохранить объект как файл Markdown.

Этот PHP код показывает, как конвертировать PowerPoint в Markdown:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.md", SaveFormat::Md);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Конвертация PowerPoint в вкус Markdown

Aspose.Slides позволяет вам конвертировать PowerPoint в Markdown (содержит базовый синтаксис), CommonMark, GitHub-формат Markdown, Trello, XWiki, GitLab и 17 других вкусов Markdown.

Этот PHP код показывает, как конвертировать PowerPoint в CommonMark:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $markdownSaveOptions = new MarkdownSaveOptions();
    $markdownSaveOptions->setFlavor(Flavor->CommonMark);
    $pres->save("pres.md", SaveFormat::Md, $markdownSaveOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

23 поддерживаемых вкуса Markdown [перечислены в перечислении Flavor](https://reference.aspose.com/slides/php-java/aspose.slides/flavor/) из класса [MarkdownSaveOptions](https://reference.aspose.com/slides/php-java/aspose.slides/markdownsaveoptions/).

## **Конвертация презентации, содержащей изображения, в Markdown**

Класс [MarkdownSaveOptions](https://reference.aspose.com/slides/php-java/aspose.slides/markdownsaveoptions/) предоставляет свойства и перечисления, которые позволяют использовать определенные параметры или настройки для выходного файла Markdown. Перечисление [MarkdownExportType](https://reference.aspose.com/slides/php-java/aspose.slides/markdownexporttype/) может быть установлено на значения, которые определяют, как изображения отображаются или обрабатываются: `Sequential`, `TextOnly`, `Visual`.

### **Конвертация изображений последовательно**

Если вы хотите, чтобы изображения появлялись по одному в выходном Markdown, вам нужно выбрать последовательный вариант. Этот PHP код показывает, как конвертировать презентацию, содержащую изображения, в Markdown:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $markdownSaveOptions = new MarkdownSaveOptions();
    $markdownSaveOptions->setShowHiddenSlides(true);
    $markdownSaveOptions->setShowSlideNumber(true);
    $markdownSaveOptions->setFlavor(Flavor->Github);
    $markdownSaveOptions->setExportType(MarkdownExportType::Sequential);
    $markdownSaveOptions->setNewLineType(NewLineType::Windows);
    $pres->save("doc.md", array(1, 2, 3, 4, 5, 6, 7, 8, 9 ), SaveFormat::Md, $markdownSaveOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Конвертация изображений визуально**

Если вы хотите, чтобы изображения появлялись вместе в выходном Markdown, вам необходимо выбрать визуальный вариант. В этом случае изображения будут сохранены в текущей директории приложения (и для них будет построен относительный путь в документе Markdown), или вы можете указать свой предпочтительный путь и имя папки.

Этот PHP код демонстрирует операцию:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $outPath = "c:/documents";
    $markdownSaveOptions = new MarkdownSaveOptions();
    $markdownSaveOptions->setExportType(MarkdownExportType::Visual);
    $markdownSaveOptions->setImagesSaveFolderName("md-images");
    $markdownSaveOptions->setBasePath($outPath);
    $pres->save("pres.md", SaveFormat::Md, $markdownSaveOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```