---
title: Конвертация PowerPoint в TIFF с заметками
type: docs
weight: 100
url: /ru/php-java/convert-powerpoint-to-tiff-with-notes/
keywords: "Конвертация PowerPoint в TIFF с заметками"
description: "Конвертация PowerPoint в TIFF с заметками в Aspose.Slides."
---

## **Конвертация PPT(X) в режим заметок слайдов в TIFF**
Метод [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) может быть использован для конвертации всей презентации в режиме заметок слайдов в TIFF. Приведенные ниже фрагменты кода обновляют образец презентации в TIFF-изображения в режиме заметок слайдов, как показано ниже:

```php
//Создать объект Presentation, представляющий файл презентации
  $pres = new Presentation("demo.pptx");
  try {
    $opts = new TiffOptions();
    $opts->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    # Сохранение презентации в TIFF с заметками
    $pres->save("Tiff-Notes.tiff", SaveFormat::Tiff, $opts);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Приведенные выше фрагменты кода обновляют образец презентации в TIFF-изображения в режиме заметок слайдов, как показано ниже:

|**Исходный вид презентации с заметками слайдов**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/6HdY6IV.png)| |


|**Сгенерированное TIFF-изображение в режиме заметок слайдов**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/A3ttT2y.png)| |

{{% alert title="Совет" color="primary" %}}

Вам может быть интересно ознакомиться с [БЕСПЛАТНЫМ конвертером PowerPoint в постер](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) от Aspose.

{{% /alert %}}