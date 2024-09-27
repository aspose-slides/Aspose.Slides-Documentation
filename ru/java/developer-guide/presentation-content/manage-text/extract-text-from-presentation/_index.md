---
title: Извлечение текста из презентации
type: docs
weight: 90
url: /ru/java/extract-text-from-presentation/
---

{{% alert color="primary" %}} 

Не редко разработчикам требуется извлечь текст из презентации. Для этого необходимо извлечь текст из всех фигур на всех слайдах презентации. В этой статье объясняется, как извлечь текст из презентаций Microsoft PowerPoint PPTX с использованием Aspose.Slides. 

{{% /alert %}} 
## **Извлечение текста из слайда**
Aspose.Slides для Java предоставляет класс [SlideUtil](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil). Этот класс предоставляет ряд перегруженных статических методов для извлечения всего текста из презентации или слайда. Чтобы извлечь текст из слайда в PPTX-презентации, 
используйте перегруженный статический метод [getAllTextBoxes](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) класса [SlideUtil](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil). Этот метод принимает объект Slide в качестве параметра.
При выполнении метод Slide сканирует весь текст со слайда, переданного в качестве параметра, и возвращает массив объектов [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame). Это означает, что любая текстовая форматировка, связанная с текстом, доступна. Следующий фрагмент кода извлекает весь текст с первого слайда презентации:

```java
//Создание экземпляра класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation("demo.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        //Получение массива объектов ITextFrame со всех слайдов в PPTX
        ITextFrame[] textFramesPPTX = SlideUtil.getAllTextBoxes(slide);

        //Цикл по массиву TextFrames
        for (int i = 0; i < textFramesPPTX.length; i++) {
            //Цикл по абзацам в текущем ITextFrame
            for (IParagraph para : textFramesPPTX[i].getParagraphs()) {
                //Цикл по частям в текущем IParagraph
                for (IPortion port : para.getPortions()) {
                    //Вывод текста в текущей части
                    System.out.println(port.getText());

                    //Вывод высоты шрифта текста
                    System.out.println(port.getPortionFormat().getFontHeight());

                    //Вывод названия шрифта текста
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
Чтобы просканировать текст из всей презентации, используйте
 [getAllTextFrames](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) статический метод, предоставленный классом SlideUtil. Он принимает два параметра:

1. Во-первых, объект [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode#Unarranged), представляющий презентацию, из которой извлекается текст.
1. Во-вторых, булевое значение, определяющее, следует ли включать мастер-слайд при сканировании текста из презентации.
   Метод возвращает массив объектов [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame), полностью с информацией о текстовой форматировке. Код ниже сканирует текст и информацию о форматировании из презентации, включая мастер-слайды.

```java
//Создание экземпляра класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation("demo.pptx");
try {
    //Получение массива объектов ITextFrame со всех слайдов в PPTX
    ITextFrame[] textFramesPPTX = SlideUtil.getAllTextFrames(pres, true);

    //Цикл по массиву TextFrames
    for (int i = 0; i < textFramesPPTX.length; i++) 
    {
        //Цикл по абзацам в текущем ITextFrame
        for (IParagraph para : textFramesPPTX[i].getParagraphs())
        {
            //Цикл по частям в текущем IParagraph
            for (IPortion port : para.getPortions())
            {
                //Вывод текста в текущей части
                System.out.println(port.getText());

                //Вывод высоты шрифта текста
                System.out.println(port.getPortionFormat().getFontHeight());

                //Вывод названия шрифта текста
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
В класс Presentation был добавлен новый статический метод getPresentationText. У этого метода три перегрузки:

```java
public IPresentationText getPresentationText(String file, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
``` 

Аргумент перечисления [TextExtractionArrangingMode](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode) указывает режим организации результата текстового вывода и может быть установлен в следующие значения:
- [Unarranged](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode#Unarranged) - Сырой текст без учета позиции на слайде
- [Arranged](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode#Arranged) - Текст располагается в том же порядке, что и на слайде

Режим **Unarranged** может быть использован, если скорость является критически важной, он быстрее, чем режим Arranged.

[IPresentationText](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationText) представляет собой сырой текст, извлеченный из презентации. Он содержит метод [getSlidesText](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationText#getSlidesText--) который возвращает массив объектов [ISlideText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText). Каждый объект представляет текст на соответствующем слайде. Объект [ISlideText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText) имеет следующие методы:

- [ISlideText.getText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText#getText--) - Текст на фигурах слайда
- [ISlideText.getMasterText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText#getMasterText--) - Текст на фигурах главной страницы для этого слайда
- [ISlideText.getLayoutText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText#getLayoutText--) - Текст на фигурах на странице макета для этого слайда
- [ISlideText.getNotesText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText#getNotesText--) - Текст на фигурах на странице заметок для этого слайда

Существует также класс [SlideText](https://reference.aspose.com/slides/java/com.aspose.slides/SlideText), который реализует интерфейс [ISlideText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText).

Новый API может быть использован следующим образом:

```java
IPresentationText text1 = PresentationFactory.getInstance().getPresentationText("presentation.pptx", TextExtractionArrangingMode.Unarranged);
System.out.println(text1.getSlidesText()[0].getText());
System.out.println(text1.getSlidesText()[0].getLayoutText());
System.out.println(text1.getSlidesText()[0].getMasterText());
System.out.println(text1.getSlidesText()[0].getNotesText());
```