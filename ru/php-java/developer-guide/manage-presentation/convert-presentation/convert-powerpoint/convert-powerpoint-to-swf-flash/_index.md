---
title: Конвертация PowerPoint в SWF Flash
type: docs
weight: 80
url: /ru/php-java/convert-powerpoint-to-swf-flash/
keywords: "PPT, PPTX в SWF"
description: "Конвертация PowerPoint PPT, PPTX в SWF"
---

## **Конвертация PPT(X) в SWF**
Метод [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) может быть использован для конвертации всей презентации в документ **SWF**. Следующий пример демонстрирует, как конвертировать презентацию в документ **SWF** с использованием опций, предоставленных классом [**SWFOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/SwfOptions). Вы также можете включить комментарии в сгенерированный SWF, используя класс [**ISWFOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/ISwfOptions) и интерфейс [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/INotesCommentsLayoutingOptions).

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