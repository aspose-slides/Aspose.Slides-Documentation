---
title: Конвертировать презентации PowerPoint в SWF Flash на Java
linktitle: PowerPoint в SWF
type: docs
weight: 80
url: /ru/java/convert-powerpoint-to-swf-flash/
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
- Java
- Aspose.Slides
description: "Конвертировать PowerPoint (PPT/PPTX) в SWF Flash на Java с Aspose.Slides. Пошаговые примеры кода, быстрое качественное вывод, без автоматизации PowerPoint."
---

## **Конвертировать PPT(X) в SWF**
Метод [Save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) , предоставляемый классом [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation), можно использовать для конвертации всей презентации в документ **SWF**. Следующий пример показывает, как конвертировать презентацию в документ **SWF**, используя параметры, предоставленные классом [**SWFOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/SwfOptions). Вы также можете включать комментарии в генерируемый SWF, используя класс [**ISWFOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/ISwfOptions) и интерфейс [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/INotesCommentsLayoutingOptions).
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
