---
title: Конвертация презентаций PowerPoint в SWF Flash на PHP
linktitle: PowerPoint в SWF
type: docs
weight: 80
url: /ru/php-java/convert-powerpoint-to-swf-flash/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в SWF
- презентация в SWF
- слайд в SWF
- PPT в SWF
- PPTX в SWF
- PowerPoint в Flash
- презентация в Flash
- слайд в Flash
- PPT в Flash
- PPTX в Flash
- сохранить PPT как SWF
- сохранить PPTX как SWF
- экспортировать PPT в SWF
- экспортировать PPTX в SWF
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Конвертировать PowerPoint (PPT/PPTX) в SWF Flash на PHP с Aspose.Slides. Пошаговые примеры кода, быстрый качественный вывод, без автоматизации PowerPoint."
---

## **Конвертация презентаций в Flash**

Метод [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) может использоваться для преобразования всей презентации в документ **SWF**. В следующем примере показано, как конвертировать презентацию в документ **SWF**, используя параметры, предоставленные классом [SWFOptions](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/). Вы также можете включить комментарии в сгенерированный SWF, используя класс [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/).
```php
  $pres = new Presentation("Sample.pptx");
  try {
    $swfOptions = new SwfOptions();
    $swfOptions->setViewerIncluded(false);
    $swfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    # Сохранение презентации
    $pres->save("Sample.swf", SaveFormat::Swf, $swfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Могу ли я включить скрытые слайды в SWF?**

Да. Включите скрытые слайды, используя метод [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setshowhiddenslides/) в классе [SwfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/). По умолчанию скрытые слайды не экспортируются.

**Как можно контролировать сжатие и конечный размер SWF?**

Используйте метод [setCompressed](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setcompressed/) и [adjust JPEG quality](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setjpegquality/) для балансировки размера файла и качества изображения.

**Для чего предназначен 'setViewerIncluded' и когда его следует отключать?**

Метод [setViewerIncluded](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setviewerincluded/) добавляет встроенный пользовательский интерфейс проигрывателя (элементы навигации, панели, поиск). Отключите его, если планируете использовать собственный проигрыватель или требуется чистый кадр SWF без UI.

**Что происходит, если исходный шрифт отсутствует на машине экспорта?**

Aspose.Slides заменит шрифт, указанный через метод [setDefaultRegularFont](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) в [SwfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/), чтобы избежать нежелательного fallback.