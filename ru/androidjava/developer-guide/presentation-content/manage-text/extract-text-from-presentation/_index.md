---
title: Продвинутое извлечение текста из презентаций на Android
linktitle: Извлечь текст
type: docs
weight: 90
url: /ru/androidjava/extract-text-from-presentation/
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
- presentation
- Android
- Java
- Aspose.Slides
description: "Быстро извлеките текст из презентаций PowerPoint и OpenDocument с помощью Aspose.Slides для Android через Java. Следуйте нашему простому пошаговому руководству, чтобы сэкономить время."
---

{{% alert color="primary" %}} 

Не редкость, когда разработчикам необходимо извлечь текст из презентации. Для этого нужно извлечь текст из всех фигур на всех слайдах презентации. В этой статье объясняется, как извлекать текст из презентаций Microsoft PowerPoint PPTX с помощью Aspose.Slides. 

{{% /alert %}} 
## **Извлечение текста со слайда**
Aspose.Slides for Android via Java предоставляет класс [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil). Этот класс раскрывает ряд перегруженных статических методов для извлечения полного текста из презентации или слайда. Чтобы извлечь текст со слайда в PPTX‑презентации, используйте перегруженный статический метод [getAllTextBoxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) класса [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil). Этот метод принимает объект Slide в качестве параметра.  
При выполнении метод Slide сканирует весь текст со слайда, переданного в параметре, и возвращает массив объектов [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame). Это означает, что доступно любое наличие форматирования текста. Ниже приведён фрагмент кода, извлекающий весь текст с первого слайда презентации:
```java
//Создать объект класса Presentation, который представляет файл PPTX
Presentation pres = new Presentation("demo.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        //Получить массив объектов ITextFrame со всех слайдов в PPTX
        ITextFrame[] textFramesPPTX = SlideUtil.getAllTextBoxes(slide);

        //Пройтись по массиву TextFrames
        for (int i = 0; i < textFramesPPTX.length; i++) {
            //Пройтись по абзацам текущего ITextFrame
            for (IParagraph para : textFramesPPTX[i].getParagraphs()) {
                //Пройтись по частям текущего IParagraph
                for (IPortion port : para.getPortions()) {
                    //Отобразить текст текущей части
                    System.out.println(port.getText());

                    //Отобразить высоту шрифта текста
                    System.out.println(port.getPortionFormat().getFontHeight());

                    //Отобразить имя шрифта текста
                    if (port.getPortionFormat().getLatinFont() != null)
                        System.out.println(port.getPortionFormat().getLatinFont().getFontName());
                }
            }
        }
    }
} finally {
    pres.dispose();
}
```


## **Извлечение текста из презентации**
Чтобы просканировать текст во всей презентации, используйте статический метод [getAllTextFrames](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) класса SlideUtil. Он принимает два параметра:

1. Во‑первых, объект [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Unarranged), который представляет презентацию, из которой извлекается текст.  
2. Во‑вторых, булево значение, определяющее, включать ли мастер‑слайд при сканировании текста из презентации.  

Метод возвращает массив объектов [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) с полной информацией о форматировании текста. Ниже показан код, который сканирует текст и информацию о форматировании из презентации, включая мастер‑слайды.
```java
//Создать объект класса Presentation, представляющий файл PPTX
Presentation pres = new Presentation("demo.pptx");
try {
    //Получить массив объектов ITextFrame со всех слайдов в PPTX
    ITextFrame[] textFramesPPTX = SlideUtil.getAllTextFrames(pres, true);

    //Пройтись по массиву TextFrames
    for (int i = 0; i < textFramesPPTX.length; i++) 
    {
        //Пройтись по абзацам текущего ITextFrame
        for (IParagraph para : textFramesPPTX[i].getParagraphs())
        {
            //Пройтись по частям текущего IParagraph
            for (IPortion port : para.getPortions())
            {
                //Отобразить текст текущей части
                System.out.println(port.getText());

                //Отобразить высоту шрифта текста
                System.out.println(port.getPortionFormat().getFontHeight());

                //Отобразить имя шрифта текста
                if (port.getPortionFormat().getLatinFont() != null)
                    System.out.println(port.getPortionFormat().getLatinFont().getFontName());
            }
        }
    }
} finally {
    pres.dispose();
}
```


## **Классифицированное и быстрое извлечение текста**
В класс Presentation добавлен новый статический метод getPresentationText. Для этого метода существует три перегрузки:
```java
public IPresentationText getPresentationText(String file, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
``` 

The [TextExtractionArrangingMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode) enum argument indicates the mode to organize the output of text result and can be set to the following values:
- [Unarranged](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Unarranged) - The raw text with no respect to position on the slide
- [Arranged](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Arranged) - The text is positioned in the same order as on the slide

**Unarranged** mode can be used when speed is critical, it's faster than Arranged mode.

[IPresentationText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationText) represents the raw text extracted from the presentation. It contains a [getSlidesText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationText#getSlidesText--) method which returns an array of [ISlideText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText) objects. Every object represent the text on the corresponding slide. [ISlideText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText) object have the following methods:

- [ISlideText.getText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getText--) - The text on the slide's shapes
- [ISlideText.getMasterText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getMasterText--) - The text on the master page's shapes for this slide
- [ISlideText.getLayoutText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getLayoutText--) - The text on the layout page's shapes for this slide
- [ISlideText.getNotesText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getNotesText--) - The text on the notes page's shapes for this slide

The new API can be used like this:

```java
IPresentationText text1 = PresentationFactory.getInstance().getPresentationText("presentation.pptx", TextExtractionArrangingMode.Unarranged);
System.out.println(text1.getSlidesText()[0].getText());
System.out.println(text1.getSlidesText()[0].getLayoutText());
System.out.println(text1.getSlidesText()[0].getMasterText());
System.out.println(text1.getSlidesText()[0].getNotesText());
```


## **FAQ**

**Насколько быстро Aspose.Slides обрабатывает крупные презентации при извлечении текста?**

Aspose.Slides оптимизирован для высокой производительности и эффективно обрабатывает даже [крупные презентации](/slides/ru/androidjava/open-presentation/), что делает его подходящим для сценариев обработки в реальном времени или пакетной обработки.

**Может ли Aspose.Slides извлекать текст из таблиц и диаграмм внутри презентаций?**

Да, Aspose.Slides полностью поддерживает извлечение текста из таблиц, диаграмм и других сложных элементов слайда, позволяя легко получить доступ к всему текстовому содержимому и проанализировать его.

**Нужна ли специальная лицензия Aspose.Slides для извлечения текста из презентаций?**

Текст можно извлекать с помощью бесплатной trial‑версии Aspose.Slides, однако она имеет определённые ограничения, например, обработку только ограниченного количества слайдов. Для неограниченного использования и работы с более крупными презентациями рекомендуется приобрести полную лицензию.