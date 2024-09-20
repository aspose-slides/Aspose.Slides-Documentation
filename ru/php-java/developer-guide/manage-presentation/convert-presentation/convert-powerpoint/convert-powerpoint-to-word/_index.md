---
title: Конвертация PowerPoint в Word
type: docs
weight: 110
url: /php-java/convert-powerpoint-to-word/
keywords: "Конвертировать PowerPoint, PPT, PPTX, Презентация, Word, DOCX, DOC, PPTX в DOCX, PPT в DOC, PPTX в DOC, PPT в DOCX, Java, java, Aspose.Slides"
description: "Конвертация Презентации PowerPoint в Word"
---

Если вы планируете использовать текстовый контент или информацию из презентации (PPT или PPTX) новыми способами, вам может быть полезно конвертировать презентацию в Word (DOC или DOCX).

* По сравнению с Microsoft PowerPoint, приложение Microsoft Word лучше оборудовано инструментами и функциями для работы с контентом.
* Кроме функций редактирования в Word, вы также можете получить выгоду от улучшенного совместного рабочего процесса, печати и функций обмена.

{{% alert color="primary" %}}

Вы можете попробовать наш [**Онлайн конвертер Презентации в Word**](https://products.aspose.app/slides/conversion/ppt-to-word), чтобы увидеть, что вы могли бы получить, работая с текстовым контентом слайдов.

{{% /alert %}}

## **Aspose.Slides и Aspose.Words**

Чтобы конвертировать файл PowerPoint (PPTX или PPT) в Word (DOCX или DOCX), вам нужны оба [Aspose.Slides для PHP через Java](https://products.aspose.com/slides/php-java/) и [Aspose.Words для Java](https://products.aspose.com/words/php-java/).

В качестве самостоятельного API, [Aspose.Slides](https://products.aspose.app/slides) для java предоставляет функции, которые позволяют извлекать тексты из презентаций.

[Aspose.Words](https://docs.aspose.com/words/php-java/) — это продвинутый API для обработки документов, который позволяет приложениям генерировать, изменять, конвертировать, рендерить, печатать файлы и выполнять другие задачи с документами без использования Microsoft Word.

## **Конвертация PowerPoint в Word**

1. Скачайте библиотеки [Aspose.Slides для PHP через Java](https://downloads.aspose.com/slides/java) и [Aspose.Words для Java](https://downloads.aspose.com/words/java).
2. Добавьте *aspose-slides-x.x-jdk16.jar* и *aspose-words-x.x-jdk16.jar* в ваш CLASSPATH.
3. Используйте этот код, чтобы конвертировать PowerPoint в Word:

```php
  $pres = new Presentation($inputPres);
  try {
    $doc = new Document();
    $builder = new DocumentBuilder($doc);
    foreach($pres->getSlides() as $slide) {
      # генерирует и вставляет изображение слайда
      $bitmap = $slide->getThumbnail(1, 1);
      $builder->insertImage($bitmap);
      # вставляет тексты слайда
      foreach($slide->getShapes() as $shape) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $builder->writeln($shape->getTextFrame()->getText());
        }
      }
      $builder->insertBreak(BreakType::PAGE_BREAK);
    }
    $doc->save($outputDoc);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```