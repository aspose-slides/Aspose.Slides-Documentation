---
title: Конвертация презентаций PowerPoint в Markdown на PHP
linktitle: PowerPoint в Markdown
type: docs
weight: 140
url: /ru/php-java/convert-powerpoint-to-markdown/
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
- exportPPTX в MD
- PowerPoint
- презентация
- Markdown
- PHP
- Aspose.Slides
description: "Конвертируйте слайды PowerPoint — PPT, PPTX — в чистый Markdown с помощью Aspose.Slides для PHP через Java, автоматизируйте документацию и сохраняйте форматирование."
---

## **Обзор**

Aspose.Slides for PHP via Java позволяет конвертировать содержимое презентаций в Markdown, позволяя повторно использовать файлы PowerPoint (PPT, PPTX) и OpenDocument (ODP) для вики, Git‑репозиториев и генераторов статических сайтов. API сохраняет иерархию слайдов, создавая лёгкий, удобочитаемый Markdown, что позволяет автоматизировать конвейеры документирования и держать исходные презентации и файлы Markdown в идеальном согласовании.

Поддержка конвертации PowerPoint‑to‑Markdown была реализована в [Aspose.Slides 23.7](https://releases.aspose.com/slides/php-java/release-notes/2023/aspose-slides-for-php-via-java-23-7-release-notes/).

## **Конвертировать презентацию в Markdown**

Этот раздел объясняет, как Aspose.Slides конвертирует презентации PowerPoint и OpenDocument (PPT, PPTX, ODP) в чистый Markdown, сохраняя оригинальную иерархию слайдов, текст и базовое форматирование, чтобы вы могли повторно использовать контент в документации или в рабочих процессах с контролем версий без дополнительных ручных усилий.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) для представления презентации.  
1. Используйте метод [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save), чтобы экспортировать его как файл Markdown.

Этот PHP‑код показывает, как конвертировать презентацию PowerPoint в Markdown:
```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.md", SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```


## **Конвертировать презентацию в вариант Markdown**

Aspose.Slides позволяет конвертировать презентации PowerPoint в Markdown с базовым синтаксисом, а также в CommonMark, GitHub‑flavored Markdown, Trello, XWiki, GitLab и семнадцать других вариантов Markdown.

Следующий PHP‑код демонстрирует, как конвертировать презентацию PowerPoint в CommonMark:
```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setFlavor(Flavor->CommonMark);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```


23 поддерживаемых варианта Markdown перечислены в [Flavor enumeration](https://reference.aspose.com/slides/php-java/aspose.slides/flavor/).

## **Конвертировать презентацию с изображениями в Markdown**

Класс [MarkdownSaveOptions](https://reference.aspose.com/slides/php-java/aspose.slides/markdownsaveoptions/) раскрывает свойства и перечисления, позволяющие настроить результирующий файл Markdown. Например, перечисление [MarkdownExportType](https://reference.aspose.com/slides/php-java/aspose.slides/markdownexporttype/) задаёт, как обрабатывать изображения: `Sequential`, `TextOnly` или `Visual`.

{{% alert color="warning" %}}
По умолчанию экспорт PowerPoint‑to‑Markdown **не включает изображения**. Чтобы внедрить изображения, вызовите `markdownSaveOptions.setExportType(MarkdownExportType::Visual)` и установите `BasePath`, указывающий, куда будут сохраняться изображения, на которые ссылается файл Markdown.
{{% /alert %}}

### **Конвертировать изображения последовательно**

Если вы хотите, чтобы изображения появлялись по отдельности, одно за другим, в результирующем Markdown, выберите опцию `Sequential`. Следующий PHP‑код показывает, как конвертировать презентацию с изображениями в Markdown:
```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setShowHiddenSlides(true);
    $saveOptions->setShowSlideNumber(true);
    $saveOptions->setFlavor(Flavor->Github);
    $saveOptions->setExportType(MarkdownExportType::Sequential);
    $saveOptions->setNewLineType(NewLineType::Windows);

    $slideIndices = array(1, 2, 3, 4);
    $presentation->save("presentation.md", $slideIndices, SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```


### **Конвертировать изображения визуально**

Если вы хотите, чтобы изображения появлялись вместе в результирующем Markdown, выберите опцию `Visual`. В этом случае изображения сохраняются в текущий каталог приложения (и для них генерируется относительный путь в документе Markdown), либо вы можете указать предпочтительный каталог и имя папки.

Следующий PHP‑код демонстрирует эту операцию:
```php
$presentation = new Presentation("presentation.pptx");
try {
    $outPath = "c:/documents";

    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setExportType(MarkdownExportType::Visual);
    $saveOptions->setImagesSaveFolderName("md-images");
    $saveOptions->setBasePath($outPath);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```


## **Часто задаваемые вопросы**

**Сохраняются ли гиперссылки при экспорте в Markdown?**

Да. Текстовые [гиперссылки](/slides/ru/php-java/manage-hyperlinks/) сохраняются как стандартные ссылки Markdown. [Переходы](/slides/ru/php-java/slide-transition/) и [анимации](/slides/ru/php-java/powerpoint-animation/) слайдов не конвертируются.

**Могу ли я ускорить конвертацию, запустив её в нескольких потоках?**

Можно выполнять параллельную обработку файлов, но [не делитесь](/slides/ru/php-java/multithreading/) одним и тем же экземпляром [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) между потоками. Используйте отдельные экземпляры/процессы для каждого файла, чтобы избежать конфликтов.

**Что происходит с изображениями — где они сохраняются и являются ли пути относительными?**

[Изображения](/slides/ru/php-java/image/) экспортируются в отдельную папку, а файл Markdown по умолчанию ссылается на них относительными путями. Вы можете настроить базовый путь вывода и имя папки ресурсов, чтобы поддерживать предсказуемую структуру репозитория.