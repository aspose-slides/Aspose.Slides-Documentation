---
title: Извлечение текста из презентации
type: docs
weight: 60
url: /cpp/extracting-text-from-the-presentation/
---

{{% alert color="primary" %}} 

Необычно, что разработчикам необходимо извлекать текст из презентации. Для этого необходимо извлечь текст из всех фигур на всех слайдах в презентации. Эта статья объясняет, как извлечь текст из презентаций Microsoft PowerPoint PPTX с помощью Aspose.Slides. Текст можно извлекать следующими способами:

[Извлечение текста с одного слайда](/slides/cpp/extracting-text-from-the-presentation/)
[Извлечение текста с помощью метода GetAllTextBoxes](/slides/cpp/extracting-text-from-the-presentation/)
[Категоризированное и быстрое извлечение текста](/slides/cpp/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **Извлечение текста с слайда**
Aspose.Slides для C++ предоставляет пространство имен Aspose.Slides.Util, которое включает класс PresentationScanner. Этот класс предоставляет ряд перегруженных статических методов для извлечения всего текста из презентации или слайда. Чтобы извлечь текст с слайда в PPTX-презентации, используйте перегруженный статический метод [GetAllTextBoxes](http://docs.aspose.com/display/slidesnet/PresentationScanner+Members), предоставленный классом PresentationScanner. Этот метод принимает объект Slide в качестве параметра.
При выполнении метод Slide сканирует весь текст с переданного слайда и возвращает массив объектов TextFrame. Это означает, что любое форматирование текста, связанное с текстом, доступно. Следующий фрагмент кода извлекает весь текст с первого слайда презентации:

**C#**

``` cpp

 //Создание экземпляра класса PresentationEx, представляющего файл PPTX

Presentation pptxPresentation = new Presentation(path + "demo.pptx");


//Получение массива объектов TextFrameEx с первого слайда

ITextFrame[] textFramesSlideOne = SlideUtil.GetAllTextBoxes(pptxPresentation.Slides[0]);

//Цикл по массиву TextFrames

for (int i = 0; i < textFramesSlideOne.Length; i++)

    //Цикл по параграфам в текущем TextFrame

    foreach (Paragraph para in textFramesSlideOne[i].Paragraphs)

        //Цикл по частям в текущем параграфе

        foreach (Portion port in para.Portions)

        {

            //Вывести текст в текущей части

            Console.WriteLine(port.Text);

            //Вывести высоту шрифта текста

            Console.WriteLine(port.PortionFormat.FontHeight);

            //Вывести имя шрифта текста

            Console.WriteLine(port.PortionFormat.LatinFont.FontName);

        }



```


## **Извлечение текста из всей презентации**
Чтобы просканировать текст из всей презентации, используйте статический метод [GetAllTextFrames](http://docs.aspose.com/display/slidesnet/PresentationScanner+Members), предоставленный классом PresentationScanner. Он принимает два параметра:

1. Во-первых, объект Presentation, представляющий PPTX-презентацию, из которой извлекается текст.
2. Во-вторых, логическое значение, определяющее, следует ли включать мастер-слайд при сканировании текста из презентации.
   Метод возвращает массив объектов TextFrame, полный информации о форматировании текста. Приведенный ниже код сканирует текст и информацию о форматировании из презентации, включая мастер-слайды.

**C#**

``` cpp

 //Создание экземпляра класса Presentation, представляющего файл PPTX

Presentation pptxPresentation = new Presentation(path + "demo.pptx");

//Получение массива объектов ITextFrame со всех слайдов в PPTX

ITextFrame[] textFramesPPTX = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(pptxPresentation, true);

//Цикл по массиву TextFrames

for (int i = 0; i < textFramesPPTX.Length; i++)

    //Цикл по параграфам в текущем ITextFrame

    foreach (IParagraph para in textFramesPPTX[i].Paragraphs)

        //Цикл по частям в текущем IParagraph

        foreach (IPortion port in para.Portions)

        {

            //Вывести текст в текущей части

            Console.WriteLine(port.Text);

            //Вывести высоту шрифта текста

            Console.WriteLine(port.PortionFormat.FontHeight);

            //Вывести имя шрифта текста

            if (port.PortionFormat.LatinFont != null)

                Console.WriteLine(port.PortionFormat.LatinFont.FontName);

        }


```


## **Категоризированное и быстрое извлечение текста**
Новый статический метод GetPresentationText был добавлен в класс Presentation. У этого метода есть две перегрузки:

``` cpp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)


```

Аргумент enum ExtractionMode указывает режим организации вывода результата текста и может быть установлен на следующие значения:
Неупорядоченный - Сырой текст без учета положения на слайде
Упорядоченный - Текст расположен в том же порядке, что и на слайде

Неупорядоченный режим может быть использован, когда скорость критична, он быстрее, чем упорядоченный режим.

PresentationText представляет собой сырой текст, извлеченный из презентации. Он содержит свойство SlidesText из пространства имен Aspose.Slides.Util, которое возвращает массив объектов ISlideText. Каждый объект представляет текст на соответствующем слайде. Объект ISlideText имеет следующие свойства:

ISlideText.Text - текст на фигурах слайда
ISlideText.MasterText - текст на фигурах мастер-страницы для этого слайда
ISlideText.LayoutText - текст на фигурах страницы макета для этого слайда
ISlideText.NotesText - текст на фигурах страницы заметок для этого слайда

Также есть класс SlideText, который реализует интерфейс ISlideText.

Новый API можно использовать так:

``` cpp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged);


```