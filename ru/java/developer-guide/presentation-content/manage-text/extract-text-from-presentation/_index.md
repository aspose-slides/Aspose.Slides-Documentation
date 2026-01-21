---
title: Расширенное извлечение текста из презентаций на Java
linktitle: Извлечение текста
type: docs
weight: 90
url: /ru/java/extract-text-from-presentation/
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
- Java
- Aspose.Slides
description: "Быстро извлекать текст из презентаций PowerPoint и OpenDocument с помощью Aspose.Slides для Java. Следуйте нашему простому пошаговому руководству, чтобы сэкономить время."
---

{{% alert color="primary" %}} 

Не редко, что разработчикам необходимо извлечь текст из презентации. Для этого нужно извлечь текст из всех фигур на всех слайдах презентации. В этой статье объясняется, как извлечь текст из презентаций Microsoft PowerPoint PPTX с помощью Aspose.Slides. 

{{% /alert %}} 
## **Извлечение текста со слайдов**
Aspose.Slides для Java предоставляет класс [SlideUtil](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil). Этот класс предоставляет несколько перегруженных статических методов для извлечения всего текста из презентации или слайда. Чтобы извлечь текст со слайда в PPTX‑презентации, используйте перегруженный статический метод [getAllTextBoxes](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) класса [SlideUtil](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil). Этот метод принимает объект Slide в качестве параметра.  
При выполнении метод Slide сканирует весь текст со слайда, переданного в качестве параметра, и возвращает массив объектов [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame). Это означает, что доступно любое форматирование текста. Ниже приведён фрагмент кода, который извлекает весь текст с первого слайда презентации:
```java
//Создать экземпляр класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation("demo.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        //Получить массив объектов ITextFrame со всех слайдов PPTX
        ITextFrame[] textFramesPPTX = SlideUtil.getAllTextBoxes(slide);

        //Перебрать массив TextFrames
        for (int i = 0; i < textFramesPPTX.length; i++) {
            //Перебрать абзацы в текущем ITextFrame
            for (IParagraph para : textFramesPPTX[i].getParagraphs()) {
                //Перебрать части (portions) в текущем IParagraph
                for (IPortion port : para.getPortions()) {
                    //Отобразить текст текущей части
                    System.out.println(port.getText());

                    //Отобразить высоту шрифта текста
                    System.out.println(port.getPortionFormat().getFontHeight());

                    //Отобразить название шрифта текста
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


## **Извлечение текста из презентаций**
Чтобы просканировать текст всей презентации, используйте статический метод [getAllTextFrames](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) класса SlideUtil. Он принимает два параметра:

1. Во‑первых, объект [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode#Unarranged), представляющий презентацию, из которой извлекается текст.
1. Во‑вторых, логическое значение, определяющее, следует ли включать мастер‑слайд при сканировании текста презентации.  
Метод возвращает массив объектов [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) с полной информацией о форматировании текста. Ниже приведён код, который сканирует текст и информацию о форматировании из презентации, включая мастер‑слайды.
```java
//Создать экземпляр класса Presentation, который представляет файл PPTX
Presentation pres = new Presentation("demo.pptx");
try {
    //Получить массив объектов ITextFrame со всех слайдов PPTX
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
                //Отобразить текст текущей части
                System.out.println(port.getText());

                //Отобразить высоту шрифта текста
                System.out.println(port.getPortionFormat().getFontHeight());

                //Отобразить название шрифта текста
                if (port.getPortionFormat().getLatinFont() != null)
                    System.out.println(port.getPortionFormat().getLatinFont().getFontName());
            }
        }
    }
} finally {
    pres.dispose();
}
```


## **Категоризированное и быстрое извлечение текста**
В класс Presentation добавлен новый статический метод getPresentationText. У этого метода три перегрузки:
```java
public IPresentationText getPresentationText(String file, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```


## **FAQ**

**Насколько быстро Aspose.Slides обрабатывает большие презентации при извлечении текста?**

Aspose.Slides оптимизирован для высокой производительности и эффективно обрабатывает даже [large presentations](/slides/ru/java/open-presentation/), что делает его подходящим для сценариев обработки в реальном времени или пакетной обработки.

**Может ли Aspose.Slides извлекать текст из таблиц и диаграмм в презентациях?**

Да, Aspose.Slides полностью поддерживает извлечение текста из таблиц, диаграмм и других сложных элементов слайдов, позволяя легко получать и анализировать весь текстовый контент.

**Нужна ли мне специальная лицензия Aspose.Slides для извлечения текста из презентаций?**

Вы можете извлекать текст с помощью бесплатной пробной версии Aspose.Slides, хотя она имеет ограничения, например обработку только ограниченного количества слайдов. Для неограниченного использования и работы с более крупными презентациями рекомендуется приобрести полную лицензию.