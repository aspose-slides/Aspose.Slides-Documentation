---
title: Продвинутое извлечение текста из презентаций на Android
linktitle: Извлечение текста
type: docs
weight: 90
url: /ru/androidjava/extract-text-from-presentation/
keywords:
- извлечение текста
- извлечение текста со слайда
- извлечение текста из презентации
- извлечение текста из PowerPoint
- извлечение текста из OpenDocument
- извлечение текста из PPT
- извлечение текста из PPTX
- извлечение текста из ODP
- получение текста
- получение текста со слайда
- получение текста из презентации
- получение текста из PowerPoint
- получение текста из OpenDocument
- получение текста из PPT
- получение текста из PPTX
- получение текста из ODP
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
Aspose.Slides for Android via Java предоставляет класс [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil). Этот класс содержит ряд перегруженных статических методов для извлечения всего текста из презентации или слайда. Чтобы извлечь текст со слайда в PPTX‑презентации, используйте перегруженный статический метод [getAllTextBoxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) класса [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil). Этот метод принимает объект Slide в качестве параметра.  
При выполнении метод Slide сканирует весь текст со слайда, переданного параметром, и возвращает массив объектов [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame). Это означает, что доступно любое форматирование текста. Ниже представлена часть кода, извлекающая весь текст с первого слайда презентации:
```java
//Создать экземпляр класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation("demo.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        //Получить массив объектов ITextFrame со всех слайдов в PPTX
        ITextFrame[] textFramesPPTX = SlideUtil.getAllTextBoxes(slide);

        //Пройти по массиву TextFrames
        for (int i = 0; i < textFramesPPTX.length; i++) {
            //Пройти по параграфам в текущем ITextFrame
            for (IParagraph para : textFramesPPTX[i].getParagraphs()) {
                //Пройти по частям в текущем IParagraph
                for (IPortion port : para.getPortions()) {
                    //Вывести текст текущей части
                    System.out.println(port.getText());

                    //Вывести высоту шрифта текста
                    System.out.println(port.getPortionFormat().getFontHeight());

                    //Вывести название шрифта текста
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

1. Сначала объект [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Unarranged), представляющий презентацию, из которой извлекается текст.  
2. Затем логическое значение, определяющее, включать ли мастер‑слайд при сканировании текста презентации.  
Метод возвращает массив объектов [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) с полной информацией о форматировании текста. Ниже показан код, сканирующий текст и информацию о форматировании из презентации, включая мастер‑слайды.
```java
//Создать экземпляр класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation("demo.pptx");
try {
    //Получить массив объектов ITextFrame со всех слайдов в PPTX
    ITextFrame[] textFramesPPTX = SlideUtil.getAllTextFrames(pres, true);

    //Пройти по массиву TextFrames
    for (int i = 0; i < textFramesPPTX.length; i++) 
    {
        //Пройти по параграфам в текущем ITextFrame
        for (IParagraph para : textFramesPPTX[i].getParagraphs())
        {
            //Пройти по частям в текущем IParagraph
            for (IPortion port : para.getPortions())
            {
                //Вывести текст текущей части
                System.out.println(port.getText());

                //Вывести высоту шрифта текста
                System.out.println(port.getPortionFormat().getFontHeight());

                //Вывести название шрифта текста
                if (port.getPortionFormat().getLatinFont() != null)
                    System.out.println(port.getPortionFormat().getLatinFont().getFontName());
            }
        }
    }
} finally {
    pres.dispose();
}
```


## **Категоризованное и быстрое извлечение текста**
В класс Presentation добавлен новый статический метод getPresentationText. Для этого метода предусмотрено три перегрузки:
```java
public IPresentationText getPresentationText(String file, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```


## **FAQ**

**Насколько быстро Aspose.Slides обрабатывает большие презентации при извлечении текста?**

Aspose.Slides оптимизирован для высокой производительности и эффективно обрабатывает даже [large presentations](/slides/ru/androidjava/open-presentation/), что делает его подходящим для сценариев реального времени или массовой обработки.

**Может ли Aspose.Slides извлекать текст из таблиц и диаграмм внутри презентаций?**

Да, Aspose.Slides полностью поддерживает извлечение текста из таблиц, диаграмм и других сложных элементов слайдов, позволяя легко получать и анализировать весь текстовый контент.

**Нужна ли специальная лицензия Aspose.Slides для извлечения текста из презентаций?**

Вы можете извлекать текст, используя бесплатную trial‑версию Aspose.Slides, однако она имеет ограничения, например, обработку ограниченного количества слайдов. Для неограниченного использования и работы с более крупными презентациями рекомендуется приобрести полную лицензию.