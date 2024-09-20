---
title: Извлечение текста из презентации
type: docs
weight: 90
url: /net/extract-text-from-presentation/
keywords: "Извлечение текста из слайда, Извлечение текста из PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Извлечение текста из слайда или презентации PowerPoint на C# или .NET"
---

{{% alert color="primary" %}} 

Не редкость, когда разработчикам необходимо извлекать текст из презентации. Для этого нужно извлечь текст из всех фигур на всех слайдах в презентации. Эта статья объясняет, как извлекать текст из презентаций Microsoft PowerPoint PPTX с использованием Aspose.Slides. Текст может быть извлечен следующими способами:

- [Извлечение текста из одного слайда](/slides/net/extracting-text-from-the-presentation/)
- [Извлечение текста с использованием метода GetAllTextBoxes](/slides/net/extracting-text-from-the-presentation/)
- [Классифицированное и быстрое извлечение текста](/slides/net/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **Извлечение текста из слайда**
Aspose.Slides для .NET предоставляет пространство имен Aspose.Slides.Util, которое включает класс SlideUtil. Этот класс содержит несколько перегруженных статических методов для извлечения всего текста из презентации или слайда. Чтобы извлечь текст из слайда в PPTX-презентации, используйте перегруженный статический метод [GetAllTextBoxes](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/methods/getalltextboxes), предоставленный классом SlideUtil. Этот метод принимает объект Slide в качестве параметра. 
При выполнении метод Slide сканирует весь текст со слайда, переданного в качестве параметра, и возвращает массив объектов TextFrame. Это означает, что любое форматирование текста, связанное с текстом, доступно. Следующий фрагмент кода извлекает весь текст с первого слайда презентации:

```c#
//Создаем экземпляр класса Presentation, который представляет файл PPTX
Presentation pptxPresentation = new Presentation("demo.pptx");

//Получаем массив объектов ITextFrame из всех слайдов в PPTX
ITextFrame[] textFramesPPTX = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(pptxPresentation, true);

//Проходимся по массиву TextFrames
for (int i = 0; i < textFramesPPTX.Length; i++)
{
	//Проходимся по параграфам в текущем ITextFrame
	foreach (IParagraph para in textFramesPPTX[i].Paragraphs)
	{
		//Проходимся по частям в текущем IParagraph
		foreach (IPortion port in para.Portions)
		{
			//Выводим текст в текущей части
			Console.WriteLine(port.Text);

			//Выводим высоту шрифта текста
			Console.WriteLine(port.PortionFormat.FontHeight);

			//Выводим название шрифта текста
			if (port.PortionFormat.LatinFont != null)
				Console.WriteLine(port.PortionFormat.LatinFont.FontName);
		}
	}
}
```




## **Извлечение текста из презентации**
Чтобы просканировать текст из всей презентации, используйте статический метод [GetAllTextFrames](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/methods/getalltextframes), предоставленный классом SlideUtil. Этот метод принимает два параметра:

1. Во-первых, объект Presentation, который представляет PPTX-презентацию, из которой извлекается текст.
1. Во-вторых, логическое значение, определяющее, должен ли основной слайд быть включен при сканировании текста из презентации. 
   Метод возвращает массив объектов TextFrame, полный информации о форматировании текста. Код ниже сканирует текст и информацию о форматировании из презентации, включая основные слайды.

```c#
//Создаем экземпляр класса Presentation, который представляет файл PPTX
Presentation pptxPresentation = new Presentation("demo.pptx");

//Получаем массив объектов ITextFrame из всех слайдов в PPTX
ITextFrame[] textFramesPPTX = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(pptxPresentation, true);

//Проходимся по массиву TextFrames
for (int i = 0; i < textFramesPPTX.Length; i++)

	//Проходимся по параграфам в текущем ITextFrame
	foreach (IParagraph para in textFramesPPTX[i].Paragraphs)

		//Проходимся по частям в текущем IParagraph
		foreach (IPortion port in para.Portions)
		{
			//Выводим текст в текущей части
			Console.WriteLine(port.Text);

			//Выводим высоту шрифта текста
			Console.WriteLine(port.PortionFormat.FontHeight);

			//Выводим название шрифта текста
			if (port.PortionFormat.LatinFont != null)
				Console.WriteLine(port.PortionFormat.LatinFont.FontName);
		}
```




## **Классифицированное и быстрое извлечение текста**
В класс Presentation добавлен новый статический метод GetPresentationText. У этого метода есть два перегруженных варианта:

``` csharp
PresentationText GetPresentationText(Stream stream)
PresentationText GetPresentationText(Stream stream, ExtractionMode mode)
```

Аргумент enum ExtractionMode указывает режим организации вывода текста и может быть установлен на следующие значения:
Неорганизованный - Сырой текст без учета позиционирования на слайде
Организованный - Текст располагается в том же порядке, что и на слайде

Неорганизованный режим можно использовать, когда скорость критична, он быстрее, чем организованный режим.

PresentationText представляет собой сырой текст, извлеченный из презентации. Он содержит свойство SlidesText из пространства имен Aspose.Slides.Util, которое возвращает массив объектов ISlideText. Каждый объект представляет текст на соответствующем слайде. У объекта ISlideText есть следующие свойства:

ISlideText.Text - Текст на фигурах слайда
ISlideText.MasterText - Текст на формах главной страницы для этого слайда
ISlideText.LayoutText - Текст на формах макета для этого слайда
ISlideText.NotesText - Текст на формах заметок для этого слайда

Также есть класс SlideText, который реализует интерфейс ISlideText.

Новый API может использоваться следующим образом:

```c#
IPresentationText text1 = new PresentationFactory().GetPresentationText("presentation.ppt", TextExtractionArrangingMode.Unarranged);
Console.WriteLine(text1.SlidesText[0].Text);
Console.WriteLine(text1.SlidesText[0].LayoutText);
Console.WriteLine(text1.SlidesText[0].MasterText);
Console.WriteLine(text1.SlidesText[0].NotesText);
```