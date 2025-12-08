---
title: Извлечение текста из презентации
type: docs
weight: 90
url: /ru/nodejs-java/extract-text-from-presentation/
---

{{% alert color="primary" %}} 

Не редкость, когда разработчикам необходимо извлечь текст из презентации. Для этого нужно получить текст из всех фигур на всех слайдах презентации. В этой статье объясняется, как извлекать текст из презентаций Microsoft PowerPoint PPTX с помощью Aspose.Slides. 

{{% /alert %}} 

## **Извлечение текста со слайда**

Aspose.Slides for Node.js via Java предоставляет класс [SlideUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil). Этот класс раскрывает ряд перегруженных статических методов для извлечения всего текста из презентации или слайда. Чтобы извлечь текст со слайда в презентации PPTX,
используйте перегруженный статический метод [getAllTextBoxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#getAllTextBoxes-aspose.slides.IBaseSlide-) класса [SlideUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil). Этот метод принимает объект Slide в качестве параметра.
При выполнении метод Slide сканирует весь текст со слайда, переданного в качестве параметра, и возвращает массив объектов [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame). Это означает, что доступно любое форматирование текста. Следующий фрагмент кода извлекает весь текст первого слайда презентации:
```javascript
// Создать объект класса Presentation, представляющий файл PPTX
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
                    // Отобразить название шрифта текста
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

Чтобы просканировать текст всей презентации, используйте
статический метод [getAllTextFrames](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#getAllTextFrames-aspose.slides.IPresentation-boolean-) класса SlideUtil. Он принимает два параметра:

1. Во‑первых, объект [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode#Unarranged), представляющий презентацию, из которой извлекается текст.
2. Во‑вторых, логическое значение, определяющее, следует ли включать мастер‑слайд при сканировании текста презентации.
   Метод возвращает массив объектов [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) с полной информацией о форматировании текста. Ниже приведён код, который сканирует текст и сведения о форматировании из презентации, включая мастер‑слайды.
```javascript
// Создать объект класса Presentation, представляющий файл PPTX
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
                // Отобразить название шрифта текста
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

В класс Presentation добавлен новый статический метод getPresentationText. Для этого метода доступны три перегрузки:
```javascript
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
``` 

The [TextExtractionArrangingMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode) enum argument indicates the mode to organize the output of text result and can be set to the following values:
- [Unarranged](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode#Unarranged) - The raw text with no respect to position on the slide
- [Arranged](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode#Arranged) - The text is positioned in the same order as on the slide

**Unarranged** mode can be used when speed is critical, it's faster than Arranged mode.

[PresentationText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationText) represents the raw text extracted from the presentation. It contains a [getSlidesText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationText#getSlidesText--) method which returns an array of [SlideText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideText) objects. Every object represent the text on the corresponding slide. [SlideText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideText) object have the following methods:

- [SlideText.getText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideText#getText--) - The text on the slide's shapes
- [SlideText.getMasterText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideText#getMasterText--) - The text on the master page's shapes for this slide
- [SlideText.getLayoutText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideText#getLayoutText--) - The text on the layout page's shapes for this slide
- [SlideText.getNotesText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideText#getNotesText--) - The text on the notes page's shapes for this slide

There is also a [SlideText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideText) class which implements the [SlideText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideText) class.

The new API can be used like this:

```javascript
var text1 = aspose.slides.PresentationFactory.getInstance().getPresentationText("presentation.pptx", aspose.slides.TextExtractionArrangingMode.Unarranged);
console.log(text1.getSlidesText()[0].getText());
console.log(text1.getSlidesText()[0].getLayoutText());
console.log(text1.getSlidesText()[0].getMasterText());
console.log(text1.getSlidesText()[0].getNotesText());
```


## **FAQ**

**Насколько быстро Aspose.Slides обрабатывает большие презентации при извлечении текста?**

Aspose.Slides оптимизирован для высокой производительности и эффективно обрабатывает даже крупные презентации, что делает его пригодным для сценариев реального времени или массовой обработки.

**Может ли Aspose.Slides извлекать текст из таблиц и диаграмм в презентациях?**

Да, Aspose.Slides полностью поддерживает извлечение текста из таблиц, диаграмм и других сложных элементов слайдов, позволяя легко получать и анализировать весь текстовый контент.

**Нужна ли специальная лицензия Aspose.Slides для извлечения текста из презентаций?**

Вы можете извлекать текст с помощью бесплатной пробной версии Aspose.Slides, однако она имеет ограничения, например, обработку только ограниченного количества слайдов. Для неограниченного использования и работы с большими презентациями рекомендуется приобрести полную лицензию.