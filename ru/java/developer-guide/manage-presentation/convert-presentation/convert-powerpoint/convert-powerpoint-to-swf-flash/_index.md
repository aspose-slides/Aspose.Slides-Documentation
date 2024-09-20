---
title: Конвертация PowerPoint в SWF Flash
type: docs
weight: 80
url: /java/convert-powerpoint-to-swf-flash/
keywords: "PPT, PPTX в SWF"
description: "Конвертация PowerPoint PPT, PPTX в SWF на Java"
---

## **Конвертация PPT(X) в SWF**
Метод [Save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) может быть использован для конвертации всей презентации в документ **SWF**. Следующий пример демонстрирует, как конвертировать презентацию в документ **SWF** с использованием параметров, предоставленных классом [**SWFOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/SwfOptions). Вы также можете включать комментарии в генерируемый SWF, используя класс [**ISWFOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/ISwfOptions) и интерфейс [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/INotesCommentsLayoutingOptions).

```java
Presentation pres = new Presentation("Sample.pptx");
try {
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    // Сохранение презентации
    pres.save("Sample.swf", SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```