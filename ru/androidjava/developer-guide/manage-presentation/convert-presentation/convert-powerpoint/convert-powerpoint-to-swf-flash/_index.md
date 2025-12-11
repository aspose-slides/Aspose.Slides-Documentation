---
title: Конвертировать презентации PowerPoint в SWF Flash на Android
linktitle: PowerPoint в SWF
type: docs
weight: 80
url: /ru/androidjava/convert-powerpoint-to-swf-flash/
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
- Android
- Java
- Aspose.Slides
description: "Конвертировать PowerPoint (PPT/PPTX) в SWF Flash в Java с Aspose.Slides для Android. Пошаговые примеры кода, быстрое качественное вывод, без автоматизации PowerPoint."
---

## **Конвертировать PPT(X) в SWF**
Метод [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) может быть использован для преобразования всей презентации в документ **SWF**. Ниже приведён пример, показывающий, как конвертировать презентацию в документ **SWF**, используя параметры, предоставленные классом [**SWFOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SwfOptions). Вы также можете включать комментарии в генерируемый SWF с помощью класса [**ISWFOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISwfOptions) и интерфейса [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions).
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


## **FAQ**

**Можно ли включить скрытые слайды в SWF?**

Да. Включите скрытые слайды, используя метод [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-) в классе [SwfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/). По умолчанию скрытые слайды не экспортируются.

**Как можно контролировать сжатие и конечный размер SWF?**

Используйте метод [setCompressed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setCompressed-boolean-) и настройку качества JPEG через [adjust JPEG quality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setJpegQuality-int-) для балансировки размера файла и качества изображений.

**Для чего предназначен 'setViewerIncluded' и когда его следует отключать?**

Метод [setViewerIncluded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) добавляет встроенный интерфейс плеера (элементы навигации, панели, поиск). Отключите его, если планируете использовать собственный плеер или нужен «чистый» SWF без пользовательского интерфейса.

**Что происходит, если исходный шрифт отсутствует на машине экспорта?**

Aspose.Slides заменит отсутствующий шрифт шрифтом, указанным через [setDefaultRegularFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) в [SwfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/), чтобы избежать непреднамеренного переключения.