---
title: Конвертация PowerPoint в TIFF с заметками
type: docs
weight: 100
url: /ru/java/convert-powerpoint-to-tiff-with-notes/
keywords: "Конвертация PowerPoint в TIFF с заметками"
description: "Конвертируйте PowerPoint в TIFF с заметками в Aspose.Slides."
---

## **Конвертация PPT(X) в представлении заметок слайдов в TIFF**
Метод [Save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) можно использовать для конвертации всей презентации в представлении заметок слайдов в TIFF. Приведенные ниже фрагменты кода обновляют образец презентации до TIFF изображений в представлении заметок слайдов, как показано ниже:

```java
//Создание объекта Presentation, который представляет файл презентации
Presentation pres = new Presentation("demo.pptx");
try {
    TiffOptions opts = new TiffOptions();
    opts.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    //Сохранение презентации в TIFF с заметками
    pres.save("Tiff-Notes.tiff", SaveFormat.Tiff,opts);
} finally {
    если (pres != null) pres.dispose();
}
```

Приведенные выше фрагменты кода обновляют образец презентации до TIFF изображений в представлении заметок слайдов, как показано ниже:

|**Представление исходной презентации с заметками слайда**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/6HdY6IV.png)| |


|**Сгенерированное TIFF изображение в представлении заметок слайда**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/A3ttT2y.png)| |

{{% alert title="Совет" color="primary" %}}

Вам может быть интересно ознакомиться с [БЕСПЛАТНЫМ конвертером PowerPoint в плакат](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}