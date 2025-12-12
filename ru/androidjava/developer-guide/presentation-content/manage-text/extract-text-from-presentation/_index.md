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
- презентация
- Android
- Java
- Aspose.Slides
description: "Быстро извлеките текст из презентаций PowerPoint и OpenDocument с помощью Aspose.Slides для Android на Java. Следуйте нашему простому пошаговому руководству, чтобы сэкономить время."
---

{{% alert color="primary" %}} 

Не редкость, когда разработчикам нужно извлечь текст из презентации. Для этого нужно извлечь текст из всех фигур на всех слайдах презентации. Эта статья объясняет, как извлекать текст из презентаций Microsoft PowerPoint PPTX с помощью Aspose.Slides. 

{{% /alert %}} 
## **Извлечение текста со слайда**
Aspose.Slides for Android via Java предоставляет класс [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil). Этот класс раскрывает ряд перегруженных статических методов для извлечения полного текста из презентации или слайда. Чтобы извлечь текст со слайда в презентации PPTX, используйте перегруженный статический метод [getAllTextBoxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) класса [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil). Этот метод принимает объект Slide в качестве параметра.
При выполнении метод Slide сканирует весь текст со слайда, переданного в качестве параметра, и возвращает массив объектов [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame). Это означает, что доступно любое форматирование текста. Следующий фрагмент кода извлекает весь текст с первого слайда презентации:
```java
//Создать экземпляр класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation("demo.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        //Получить массив объектов ITextFrame со всех слайдов в PPTX
        ITextFrame[] textFramesPPTX = SlideUtil.getAllTextBoxes(slide);

        //Перебрать массив TextFrames
        for (int i = 0; i < textFramesPPTX.length; i++) {
            //Перебрать абзацы в текущем ITextFrame
            for (IParagraph para : textFramesPPTX[i].getParagraphs()) {
                //Перебрать части (portions) в текущем IParagraph
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
Для сканирования текста во всей презентации используйте статический метод [getAllTextFrames](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) класса SlideUtil. Он принимает два параметра:

1. Во-первых, объект [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Unarranged), который представляет презентацию, из которой извлекается текст.
2. Во-вторых, логическое значение, определяющее, следует ли включать слайды‑шаблоны при сканировании текста из презентации.
   Метод возвращает массив объектов [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame), содержащих полную информацию о форматировании текста. Приведённый ниже код сканирует текст и информацию о форматировании из презентации, включая слайды‑шаблоны.
```java
//Создать экземпляр класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation("demo.pptx");
try {
    //Получить массив объектов ITextFrame со всех слайдов в PPTX
    ITextFrame[] textFramesPPTX = SlideUtil.getAllTextFrames(pres, true);

    //Перебрать массив TextFrames
    for (int i = 0; i < textFramesPPTX.length; i++) 
    {
        //Перебрать абзацы в текущем ITextFrame
        for (IParagraph para : textFramesPPTX[i].getParagraphs())
        {
            //Перебрать части (portions) в текущем IParagraph
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
Новый статический метод getPresentationText был добавлен в класс Presentation. Для этого метода доступны три перегрузки:
```java
public IPresentationText getPresentationText(String file, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```


## **Вопросы и ответы**

**Насколько быстро Aspose.Slides обрабатывает большие презентации при извлечении текста?**

Aspose.Slides оптимизирован для высокой производительности и эффективно обрабатывает даже [большие презентации](/slides/ru/androidjava/open-presentation/), что делает его подходящим для сценариев обработки в реальном времени или пакетной обработки.

**Может ли Aspose.Slides извлекать текст из таблиц и диаграмм в презентациях?**

Да, Aspose.Slides полностью поддерживает извлечение текста из таблиц, диаграмм и других сложных элементов слайдов, что позволяет легко получить доступ к всему текстовому содержимому и проанализировать его.

**Нужна ли специальная лицензия Aspose.Slides для извлечения текста из презентаций?**

Вы можете извлекать текст с помощью бесплатной пробной версии Aspose.Slides, однако она имеет определённые ограничения, например обработку только ограниченного количества слайдов. Для неограниченного использования и работы с более крупными презентациями рекомендуется приобрести полную лицензию.