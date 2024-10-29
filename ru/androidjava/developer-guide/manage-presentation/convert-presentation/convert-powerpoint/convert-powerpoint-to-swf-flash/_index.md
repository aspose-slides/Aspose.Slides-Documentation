---
title: Конвертация PowerPoint в SWF Flash
type: docs
weight: 80
url: /ru/androidjava/convert-powerpoint-to-swf-flash/
keywords: "PPT, PPTX в SWF"
description: "Конвертация PowerPoint PPT, PPTX в SWF на Java"
---

## **Конвертация PPT(X) в SWF**
Метод [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) может быть использован для конвертации всей презентации в документ **SWF**. В следующем примере показано, как конвертировать презентацию в документ **SWF** с использованием возможностей, предоставляемых классом [**SWFOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SwfOptions). Вы также можете включить комментарии в сгенерированном SWF, используя класс [**ISWFOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISwfOptions) и интерфейс [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions).

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