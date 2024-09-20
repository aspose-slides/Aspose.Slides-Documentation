---
title: Конвертация PowerPoint в TIFF с заметками
type: docs
weight: 100
url: /androidjava/convert-powerpoint-to-tiff-with-notes/
keywords: "Конвертация PowerPoint в TIFF с заметками"
description: "Конвертация PowerPoint в TIFF с заметками в Aspose.Slides."
---

## **Конвертация PPT(X) в режиме просмотра с заметками в TIFF**
Метод [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) можно использовать для конвертации всей презентации в режиме просмотра с заметками в TIFF. Приведенные ниже фрагменты кода обновляют образец презентации в TIFF изображения в режиме просмотра с заметками, как показано ниже:

```java
//Создаем объект Presentation, представляющий файл презентации
Presentation pres = new Presentation("demo.pptx");
try {
    TiffOptions opts = new TiffOptions();
    opts.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    //Сохранение презентации в TIFF с заметками
    pres.save("Tiff-Notes.tiff", SaveFormat.Tiff,opts);
} finally {
    if (pres != null) pres.dispose();
}
```

Приведенные выше фрагменты кода обновляют образец презентации в TIFF изображения в режиме просмотра с заметками, как показано ниже:

|**Представление исходной презентации с заметками слайдов**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/6HdY6IV.png)| |


|**Сгенерированное изображение TIFF в режиме просмотра с заметками**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/A3ttT2y.png)| |

{{% alert title="Совет" color="primary" %}}

Вам может быть интересно ознакомиться с [БЕСПЛАТНЫМ конвертером PowerPoint в постер](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) от Aspose.

{{% /alert %}}