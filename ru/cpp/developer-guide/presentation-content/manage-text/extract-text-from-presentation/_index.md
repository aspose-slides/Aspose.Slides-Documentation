---
title: Извлечение текста из презентации
type: docs
weight: 90
url: /ru/cpp/extract-text-from-presentation/
---

{{% alert color="primary" %}} 

Не редкость, когда разработчикам необходимо извлекать текст из презентации. Для этого необходимо извлечь текст из всех фигур на всех слайдах презентации. Эта статья объясняет, как извлекать текст из презентаций Microsoft PowerPoint PPTX с помощью Aspose.Slides. Текст можно извлекать следующими способами:

- [Извлечение текста одного слайда](/slides/ru/cpp/extracting-text-from-the-presentation/)
- [Извлечение текста с использованием метода GetAllTextBoxes](/slides/ru/cpp/extracting-text-from-the-presentation/)
- [Категоризированное и быстрое извлечение текста](/slides/ru/cpp/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **Извлечение текста из слайда**
Aspose.Slides для C++ предоставляет пространство имен Aspose.Slides.Util, которое включает класс SlideUtil. Этот класс предоставляет несколько перегруженных статических методов для извлечения всего текста из презентации или слайда. Чтобы извлечь текст из слайда в презентации PPTX, 
используйте перегруженный статический метод [GetAllTextBoxes](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a97da94e3fc5230cdfc0e30b444c127df), предоставленный классом SlideUtil. Этот метод принимает объект Slide в качестве параметра.
При выполнении метод Slide сканирует весь текст со слайда, переданного в качестве параметра, и возвращает массив объектов TextFrame. Это означает, что любая текстовая форматировка, связанная с текстом, доступна. Следующий фрагмент кода извлекает весь текст с первого слайда презентации:

``` cpp
// Путь к директории с документами.
System::String dataDir = GetDataPath();

// Создание экземпляра класса Presentation, который представляет файл PPTX
auto pptxPresentation = System::MakeObject<Presentation>(dataDir + u"demo.pptx");

// Получите массив объектов ITextFrame из всех слайдов в PPTX
auto textFramesPPTX = Util::SlideUtil::GetAllTextFrames(pptxPresentation, true);

// Перебор массива TextFrames
for (int32_t i = 0; i < textFramesPPTX->get_Length(); i++)
{
	// Перебор параграфов в текущем ITextFrame
	for (const auto& para : textFramesPPTX[i]->get_Paragraphs())
	{
		// Перебор частей в текущем IParagraph
		for (const auto& port : para->get_Portions())
		{
			// Отображение текста в текущей части
			Console::WriteLine(port->get_Text());

			// Отображение высоты шрифта текста
			Console::WriteLine(port->get_PortionFormat()->get_FontHeight());

			// Отображение названия шрифта текста
			if (port->get_PortionFormat()->get_LatinFont() != nullptr)
			{
				Console::WriteLine(port->get_PortionFormat()->get_LatinFont()->get_FontName());
			}
		}
	}
}
```

## **Извлечение текста из презентации**
Чтобы просканировать текст из всей презентации, используйте 
[GetAllTextFrames](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a5a0aebdc520e5258c8a1f665fdb8be12) статический метод, предоставленный классом SlideUtil. Он принимает два параметра:

1. Во-первых, объект Presentation, который представляет презентацию PPTX, из которой извлекается текст.
1. Во-вторых, логическое значение, определяющее, следует ли включать мастер-слайд при сканировании текста из презентации.
   Метод возвращает массив объектов TextFrame, полностью с информацией о форматировании текста. Приведенный ниже код сканирует текст и информацию о форматировании из презентации, включая мастер-слайды.

``` cpp
// Путь к директории с документами.
System::String dataDir = GetDataPath();

// Создание экземпляра класса Presentation, который представляет файл PPTX
auto pptxPresentation = System::MakeObject<Presentation>(dataDir + u"demo.pptx");

// Получите массив объектов ITextFrame из всех слайдов в PPTX
auto textFramesPPTX = Util::SlideUtil::GetAllTextFrames(pptxPresentation, true);

// Перебор массива TextFrames
for (int32_t i = 0; i < textFramesPPTX->get_Length(); i++)
{
	// Перебор параграфов в текущем ITextFrame
	for (const auto& para : textFramesPPTX[i]->get_Paragraphs())
	{
		// Перебор частей в текущем IParagraph
		for (const auto& port : para->get_Portions())
		{
			// Отображение текста в текущей части
			Console::WriteLine(port->get_Text());

			// Отображение высоты шрифта текста
			Console::WriteLine(port->get_PortionFormat()->get_FontHeight());

			// Отображение названия шрифта текста
			if (port->get_PortionFormat()->get_LatinFont() != nullptr)
			{
				Console::WriteLine(port->get_PortionFormat()->get_LatinFont()->get_FontName());
			}
		}
	}
}
```

## **Категоризированное и быстрое извлечение текста**
В класс Presentation был добавлен новый статический метод GetPresentationText. У этого метода есть две перегрузки:

``` cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode) override
 
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode) override
```

Аргумент enum TextExtractionArrangingMode указывает режим организации вывода результата текста и может быть установлен на следующие значения:  
Unarranged - Исходный текст без учета положения на слайде  
Arranged - Текст расположен в том же порядке, что и на слайде

Режим Unarranged может быть использован, когда скорость критична, он быстрее, чем режим Arranged.

PresentationText представляет собой исходный текст, извлеченный из презентации. Он содержит метод get_SlidesText() из пространства имен Aspose.Slides.Util, который возвращает массив объектов ISlideText. Каждый объект представляет текст на соответствующем слайде. Объект ISlideText имеет следующие методы:

get_Text() - Текст на фигурах слайда.  
get_MasterText() - Текст на фигурах главной страницы для этого слайда.  
get_LayoutText() - Текст на фигурах на странице макета для этого слайда.  
get_NotesText() - Текст на фигурах на странице заметок для этого слайда.

Существует также класс SlideText, который реализует интерфейс ISlideText.

Новый API может использоваться следующим образом:

``` cpp
auto text = System::MakeObject<PresentationFactory>()->GetPresentationText(u"presentation.ppt", TextExtractionArrangingMode::Unarranged);
Console::WriteLine(text->get_SlidesText()[0]->get_Text());
Console::WriteLine(text->get_SlidesText()[0]->get_LayoutText());
Console::WriteLine(text->get_SlidesText()[0]->get_MasterText());
Console::WriteLine(text->get_SlidesText()[0]->get_NotesText());
```