---
title: Продвинутое извлечение текста из презентаций на JavaScript
linktitle: Извлечение текста
type: docs
weight: 90
url: /ru/nodejs-java/extract-text-from-presentation/
keywords:
- извлечь текст
- извлечь текст со слайда
- извлечь текст из презентации
- извлечь текст из PowerPoint
- извлечь текст из OpenDocument
- извлечь текст из PPT
- извлечь текст из PPTX
- извлечь текст из ODP
- получить текст
- получить текст со слайда
- получить текст из презентации
- получить текст из PowerPoint
- получить текст из OpenDocument
- получить текст из PPT
- получить текст из PPTX
- получить текст из ODP
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Быстро извлекайте текст из презентаций PowerPoint и OpenDocument с помощью Aspose.Slides для Node.js. Следуйте нашему простому пошаговому руководству, чтобы сэкономить время."
---

{{% alert color="primary" %}} 

Не редкость, когда разработчикам требуется извлечь текст из презентации. Для этого нужно извлечь текст из всех фигур на всех слайдах презентации. В этой статье объясняется, как извлекать текст из презентаций Microsoft PowerPoint PPTX с помощью Aspose.Slides. 

{{% /alert %}} 

## **Извлечение текста со слайда**

Aspose.Slides for Node.js via Java предоставляет класс [SlideUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil). Этот класс раскрывает набор перегруженных статических методов для извлечения полного текста из презентации или слайда. Чтобы извлечь текст со слайда в PPTX‑презентации, используйте перегруженный статический метод [getAllTextBoxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#getAllTextBoxes-aspose.slides.IBaseSlide-) класса [SlideUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil). Этот метод принимает объект Slide в качестве параметра. При выполнении метод Slide сканирует весь текст переданного слайда и возвращает массив объектов [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame). Это означает, что доступно любое форматирование текста. Ниже приводится код, который извлекает весь текст с первого слайда презентации:
```javascript
// Создать экземпляр класса Presentation, представляющего файл PPTX
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    for (var s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        // Получить массив объектов ITextFrame со всех слайдов в PPTX
        var textFramesPPTX = aspose.slides.SlideUtil.getAllTextBoxes(slide);
        // Перебрать массив TextFrames
        for (var i = 0; i < textFramesPPTX.length; i++) {
            // Перебрать абзацы в текущем ITextFrame
            for (let j = 0; j < textFramesPPTX[i].getParagraphs().getCount(); j++) {
                let para = textFramesPPTX[i].getParagraphs().get_Item(j);
                // Перебрать части в текущем IParagraph
                for (let k = 0; k < para.getPortions().getCount(); k++) {
                    let port = para.getPortions().get_Item(k);
                    // Отобразить текст в текущей части
                    console.log(port.getText());
                    // Отобразить высоту шрифта текста
                    console.log(port.getPortionFormat().getFontHeight());
                    // Отобразить имя шрифта текста
                    if (port.getPortionFormat().getLatinFont() != null) {
                        console.log(port.getPortionFormat().getLatinFont().getFontName());
                    }
                });
            }
        }
    });
} finally {
    pres.dispose();
}
```


## **Извлечение текста из презентации**

Чтобы просканировать текст всей презентации, используйте статический метод [getAllTextFrames](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#getAllTextFrames-aspose.slides.IPresentation-boolean-) класса SlideUtil. Он принимает два параметра:

1. Во-первых, объект [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode#Unarranged), представляющий презентацию, из которой извлекается текст.
2. Во-вторых, булево значение, определяющее, следует ли включать мастер‑слайд при сканировании текста из презентации.

Метод возвращает массив объектов [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) с полной информацией о форматировании текста. Приведённый ниже код сканирует текст и сведения о форматировании из презентации, включая мастер‑слайды.
```javascript
// Создать экземпляр класса Presentation, представляющего файл PPTX
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Получить массив объектов ITextFrame со всех слайдов в PPTX
    var textFramesPPTX = aspose.slides.SlideUtil.getAllTextFrames(pres, true);
    // Перебрать массив TextFrames
    for (var i = 0; i < textFramesPPTX.length; i++) {
        // Перебрать абзацы в текущем ITextFrame
        for (let j = 0; j < textFramesPPTX[i].getParagraphs().getCount(); j++) {
            let para = textFramesPPTX[i].getParagraphs().get_Item(j);
            // Перебрать части в текущем IParagraph
            for (let k = 0; k < para.getPortions().getCount(); k++) {
                let port = para.getPortions().get_Item(k);
                // Отобразить текст в текущей части
                console.log(port.getText());
                // Отобразить высоту шрифта текста
                console.log(port.getPortionFormat().getFontHeight());
                // Отобразить имя шрифта текста
                if (port.getPortionFormat().getLatinFont() != null) {
                    console.log(port.getPortionFormat().getLatinFont().getFontName());
                }
            }
        }
    }
} finally {
    pres.dispose();
}
```


## **Категоризированное и быстрое извлечение текста**

В класс Presentation добавлен новый статический метод getPresentationText. Для этого метода существует три перегрузки:
```javascript
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```


## **FAQ**

**Насколько быстро Aspose.Slides обрабатывает большие презентации при извлечении текста?**

Aspose.Slides оптимизирован для высокой производительности и эффективно обрабатывает даже крупные презентации, что делает его подходящим для сценариев реального времени или массовой обработки.

**Может ли Aspose.Slides извлекать текст из таблиц и диаграмм в презентациях?**

Да, Aspose.Slides полностью поддерживает извлечение текста из таблиц, диаграмм и других сложных элементов слайда, позволяя легко получать и анализировать весь текстовый контент.

**Нужна ли специальная лицензия Aspose.Slides для извлечения текста из презентаций?**

Вы можете извлекать текст с помощью бесплатной пробной версии Aspose.Slides, однако у неё есть ограничения, например обработка ограниченного количества слайдов. Для неограниченного использования и работы с большими презентациями рекомендуется приобрести полную лицензию.