---
title: Конвертировать презентации PowerPoint в SWF Flash в PHP
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
description: "Конвертировать PowerPoint (PPT/PPTX) в SWF Flash в PHP с помощью Aspose.Slides. Пошаговые примеры кода, быстрое качественное вывод, без автоматизации PowerPoint."
---

## **Конвертировать презентации в Flash**
Метод [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) можно использовать для преобразования всей презентации в документ **SWF**. Следующий пример показывает, как конвертировать презентацию в документ **SWF**, используя параметры, предоставляемые классом [**SWFOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/SwfOptions). Вы также можете включить комментарии в создаваемый SWF, используя класс [**ISWFOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/ISwfOptions) и интерфейс [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/INotesCommentsLayoutingOptions).
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


## **Вопросы и ответы**

**Могу ли я включить скрытые слайды в SWF?**

Да. Включите скрытые слайды, используя метод [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setshowhiddenslides/) в классе [SwfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/). По умолчанию скрытые слайды не экспортируются.

**Как я могу контролировать сжатие и конечный размер SWF?**

Используйте метод [setCompressed](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setcompressed/) и [регулировать качество JPEG](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setjpegquality/) для балансировки размера файла и качества изображений.

**Для чего нужен 'setViewerIncluded' и когда его следует отключить?**

[setViewerIncluded](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setviewerincluded/) добавляет встроенный пользовательский интерфейс плеера (элементы навигации, панели, поиск). Отключите его, если планируете использовать собственный плеер или нужен чистый кадр SWF без UI.

**Что происходит, если исходный шрифт отсутствует на машине экспорта?**

Aspose.Slides заменит шрифт, указанный через [setDefaultRegularFont](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) в [SwfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/), чтобы избежать непреднамеренного отката.