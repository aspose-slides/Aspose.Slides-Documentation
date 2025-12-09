---
title: Конвертировать PowerPoint в SWF Flash
type: docs
weight: 80
url: /ru/nodejs-java/convert-powerpoint-to-swf-flash/
keywords: "PPT, PPTX в SWF"
description: "Конвертировать PowerPoint PPT, PPTX в SWF в JavaScript"
---

## **Конвертировать PPT(X) в SWF**
Метод [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) может использоваться для преобразования всей презентации в документ **SWF**. В следующем примере показано, как конвертировать презентацию в документ **SWF**, используя параметры, предоставляемые классом [**SWFOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SwfOptions). Вы также можете включать комментарии в генерируемый SWF, используя класс [**SWFOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SwfOptions) и класс [**NotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NotesCommentsLayoutingOptions).
```javascript
var pres = new aspose.slides.Presentation("Sample.pptx");
try {
    var swfOptions = new aspose.slides.SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    // Сохранение презентации
    pres.save("Sample.swf", aspose.slides.SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Часто задаваемые вопросы**

**Можно ли включать скрытые слайды в SWF?**

Да. Используйте метод [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/setshowhiddenslides/) в классе [SwfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/). По умолчанию скрытые слайды не экспортируются.

**Как я могу контролировать сжатие и итоговый размер SWF?**

Используйте метод [setCompressed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/setcompressed/) и [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/setjpegquality/), чтобы сбалансировать размер файла и качество изображений.

**Для чего предназначен 'setViewerIncluded' и когда его следует использовать?**

[setViewerIncluded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/setviewerincluded/) добавляет встроенный пользовательский интерфейс плеера (элементы навигации, панели, поиск). Используйте его, если планируете использовать свой собственный плеер или вам нужен чистый кадр SWF без UI.

**Что происходит, если исходный шрифт отсутствует на машине экспорта?**

Aspose.Slides заменит шрифт, указанный через [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) в классе [SwfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/), чтобы избежать непреднамеренного отката.