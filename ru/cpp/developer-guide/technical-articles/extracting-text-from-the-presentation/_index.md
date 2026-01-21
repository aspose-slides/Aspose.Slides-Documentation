---
title: Извлечение текста из презентаций
type: docs
weight: 60
url: /ru/cpp/extracting-text-from-the-presentation/
keywords:
- извлечение текста
- получение текста
- слайд
- текстовое поле
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как извлекать текст со слайдов или из всей презентации в Aspose.Slides для C++ и программно обрабатывать содержимое файлов PPT, PPTX и ODP."
---

{{% alert color="primary" %}} 

Нередко разработчикам требуется извлечь текст из презентации. Для этого необходимо извлечь текст из всех фигур на всех слайдах презентации. Эта статья объясняет, как извлекать текст из презентаций Microsoft PowerPoint PPTX с использованием Aspose.Slides. Текст может быть извлечён следующими способами:

[Извлечение текста с одного слайда](/slides/ru/cpp/extracting-text-from-the-presentation/)
[Извлечение текста с помощью метода GetAllTextBoxes](/slides/ru/cpp/extracting-text-from-the-presentation/)
[Категоризированное и быстрое извлечение текста](/slides/ru/cpp/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **Извлечение текста со слайда**
Aspose.Slides for C++ предоставляет пространство имён Aspose.Slides.Util, которое включает класс PresentationScanner. Этот класс содержит несколько перегруженных статических методов для извлечения полного текста из презентации или слайда. Чтобы извлечь текст со слайда в презентации PPTX, используйте перегруженный статический метод [GetAllTextBoxes](https://reference.aspose.com/slides/cpp/aspose.slides.util/slideutil/getalltextboxes/), реализованный в классе PresentationScanner. Этот метод принимает объект Slide в качестве параметра.
При выполнении метод Slide сканирует весь текст со слайда, переданного в параметре, и возвращает массив объектов TextFrame. Это значит, что доступно любое форматирование текста. Следующий фрагмент кода извлекает весь текст с первого слайда презентации:

**C#**
``` cpp

 //Создать экземпляр класса PresentationEx, который представляет файл PPTX

Presentation pptxPresentation = new Presentation(path + "demo.pptx");



//Получить массив объектов TextFrameEx с первого слайда

ITextFrame[] textFramesSlideOne = SlideUtil.GetAllTextBoxes(pptxPresentation.Slides[0]);

//Пройтись по массиву TextFrame

for (int i = 0; i < textFramesSlideOne.Length; i++)

    //Пройтись по абзацам в текущем TextFrame

    foreach (Paragraph para in textFramesSlideOne[i].Paragraphs)

        //Пройтись по частям в текущем абзаце

        foreach (Portion port in para.Portions)

        {

            //Отобразить текст в текущей части

            Console.WriteLine(port.Text);

            //Отобразить высоту шрифта текста

            Console.WriteLine(port.PortionFormat.FontHeight);

            //Отобразить название шрифта текста

            Console.WriteLine(port.PortionFormat.LatinFont.FontName);

        }



```



## **Извлечение текста из всей презентации**
Чтобы просканировать текст всей презентации, используйте статический метод [GetAllTextFrames](https://reference.aspose.com/slides/cpp/aspose.slides.util/slideutil/getalltextframes/), реализованный в классе PresentationScanner. Он принимает два параметра:

1. Прежде всего, объект Presentation, представляющий PPTX‑презентацию, из которой извлекается текст.
2. Затем логическое значение, определяющее, включать ли мастер‑слайд при сканировании текста презентации.

Метод возвращает массив объектов TextFrame с полной информацией о форматировании текста. Приведённый ниже код сканирует текст и информацию о форматировании из презентации, включая мастер‑слайды.

**C#**
``` cpp

 //Создать экземпляр класса Presentation, представляющего файл PPTX
Presentation pptxPresentation = new Presentation(path + "demo.pptx");
 //Получить массив объектов ITextFrame со всех слайдов PPTX
ITextFrame[] textFramesPPTX = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(pptxPresentation, true);
 //Пройтись по массиву TextFrames
for (int i = 0; i < textFramesPPTX.Length; i++)
    //Пройтись по абзацам в текущем ITextFrame
    foreach (IParagraph para in textFramesPPTX[i].Paragraphs)
        //Пройтись по частям в текущем IParagraph
        foreach (IPortion port in para.Portions)
        {
            //Отобразить текст в текущей части
            Console.WriteLine(port.Text);
            //Отобразить высоту шрифта текста
            Console.WriteLine(port.PortionFormat.FontHeight);
            //Отобразить название шрифта текста
            if (port.PortionFormat.LatinFont != null)
                Console.WriteLine(port.PortionFormat.LatinFont.FontName);
        }
```



## **Категоризированное и быстрое извлечение текста**
В класс Presentation добавлен новый статический метод GetPresentationText. Для этого метода существует две перегрузки:
``` cpp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)


```


Аргумент перечисления ExtractionMode указывает режим организации вывода результата текста и может принимать следующие значения:
Unarranged – необработанный текст без учёта позиции на слайде
Arranged – текст располагается в том же порядке, что и на слайде

Режим Unarranged можно использовать, когда важна скорость; он быстрее режима Arranged.

PresentationText представляет собой необработанный текст, извлечённый из презентации. Он содержит свойство SlidesText из пространства имён Aspose.Slides.Util, которое возвращает массив объектов ISlideText. Каждый объект представляет текст на соответствующем слайде. Объект ISlideText имеет следующие свойства:

ISlideText.Text – текст фигур на слайде
ISlideText.MasterText – текст фигур на мастер‑странице для этого слайда
ISlideText.LayoutText – текст фигур на странице макета для этого слайда
ISlideText.NotesText – текст фигур на странице заметок для этого слайда

Также существует класс SlideText, реализующий интерфейс ISlideText.

Новый API можно использовать следующим образом:
``` cpp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged);


```
