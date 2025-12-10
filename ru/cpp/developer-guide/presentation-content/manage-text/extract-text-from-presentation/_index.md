---
title: "Продвинутое извлечение текста из презентаций на C++"
linktitle: "Извлечение текста"
type: docs
weight: 90
url: /ru/cpp/extract-text-from-presentation/
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
- C++
- Aspose.Slides
description: "Быстро извлеките текст из презентаций PowerPoint и OpenDocument с помощью Aspose.Slides для C++. Следуйте нашему простому пошаговому руководству, чтобы сэкономить время."
---

{{% alert color="primary" %}} 

Не редкость, когда разработчикам требуется извлечь текст из презентации. Для этого необходимо извлечь текст из всех фигур на всех слайдах презентации. В этой статье объясняется, как извлекать текст из презентаций Microsoft PowerPoint PPTX с помощью Aspose.Slides. Текст можно извлекать следующими способами:

- [Извлечение текста из одного слайда](/slides/ru/cpp/extracting-text-from-the-presentation/)
- [Извлечение текста с помощью метода GetAllTextBoxes](/slides/ru/cpp/extracting-text-from-the-presentation/)
- [Категоризированное и быстрое извлечение текста](/slides/ru/cpp/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **Извлечение текста со слайда**
Aspose.Slides for C++ предоставляет пространство имен Aspose.Slides.Util, которое включает класс SlideUtil. Этот класс предоставляет несколько перегруженных статических методов для извлечения полного текста из презентации или слайда. Чтобы извлечь текст со слайда в презентации PPTX, используйте перегруженный статический метод [GetAllTextBoxes](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a97da94e3fc5230cdfc0e30b444c127df), предоставляемый классом SlideUtil. Этот метод принимает объект Slide в качестве параметра.
При выполнении метод Slide сканирует весь текст со слайда, переданного в качестве параметра, и возвращает массив объектов TextFrame. Это означает, что доступно любое форматирование текста. Ниже приведён фрагмент кода, который извлекает весь текст с первого слайда презентации:
```cpp
// Путь к каталогу документов.
System::String dataDir = GetDataPath();

// Создать объект класса Presentation, представляющий файл PPTX
auto pptxPresentation = System::MakeObject<Presentation>(dataDir + u"demo.pptx");

// Получить массив объектов ITextFrame со всех слайдов PPTX
auto textFramesPPTX = Util::SlideUtil::GetAllTextFrames(pptxPresentation, true);

// Перебрать массив TextFrame
for (int32_t i = 0; i < textFramesPPTX->get_Length(); i++)
{
	// Перебрать абзацы в текущем ITextFrame
	for (const auto& para : textFramesPPTX[i]->get_Paragraphs())
	{
		// Перебрать части в текущем IParagraph
		for (const auto& port : para->get_Portions())
		{
			// Отобразить текст текущей части
			Console::WriteLine(port->get_Text());

			// Отобразить высоту шрифта текста
			Console::WriteLine(port->get_PortionFormat()->get_FontHeight());

			// Отобразить название шрифта текста
			if (port->get_PortionFormat()->get_LatinFont() != nullptr)
			{
				Console::WriteLine(port->get_PortionFormat()->get_LatinFont()->get_FontName());
			}
		}
	}
}
```


## **Извлечение текста из презентации**
Чтобы просканировать текст всей презентации, используйте статический метод [GetAllTextFrames](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a5a0aebdc520e5258c8a1f665fdb8be12), предоставляемый классом SlideUtil. Он принимает два параметра:

1. Во-первых, объект Presentation, который представляет PPTX‑презентацию, из которой извлекается текст.
1. Во-вторых, логическое значение, определяющее, следует ли включать мастер‑слайд при сканировании текста из презентации.
   Метод возвращает массив объектов TextFrame, полностью содержащих информацию о форматировании текста. Ниже приведён код, который сканирует текст и информацию о форматировании из презентации, включая мастер‑слайды.
``` cpp
// Путь к каталогу документов.
System::String dataDir = GetDataPath();

// Создать объект класса Presentation, представляющий файл PPTX
auto pptxPresentation = System::MakeObject<Presentation>(dataDir + u"demo.pptx");

// Get an Array of ITextFrame objects from all slides in the PPTX
auto textFramesPPTX = Util::SlideUtil::GetAllTextFrames(pptxPresentation, true);

// Перебрать массив TextFrames
for (int32_t i = 0; i < textFramesPPTX->get_Length(); i++)
{
	// Перебрать абзацы в текущем ITextFrame
	for (const auto& para : textFramesPPTX[i]->get_Paragraphs())
	{
		// Перебрать части в текущем IParagraph
		for (const auto& port : para->get_Portions())
		{
			// Отобразить текст текущей части
			Console::WriteLine(port->get_Text());

			// Отобразить высоту шрифта текста
			Console::WriteLine(port->get_PortionFormat()->get_FontHeight());

			// Отобразить название шрифта текста
			if (port->get_PortionFormat()->get_LatinFont() != nullptr)
			{
				Console::WriteLine(port->get_PortionFormat()->get_LatinFont()->get_FontName());
			}
		}
	}
}
```


## **Категоризированное и быстрое извлечение текста**
В класс Presentation был добавлен новый статический метод GetPresentationText. Для этого метода существует две перегрузки:
``` cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode) override
 
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode) override
```


Аргумент перечисления TextExtractionArrangingMode указывает режим организации результата текста и может принимать следующие значения:  
Unarranged - Неотформатированный текст без учёта положения на слайде  
Arranged - Текст располагается в том же порядке, что и на слайде

Режим Unarranged можно использовать, когда важна скорость; он быстрее, чем режим Arranged.

PresentationText представляет собой неотформатированный текст, извлечённый из презентации. Он содержит метод get_SlidesText() из пространства имен Aspose.Slides.Util, который возвращает массив объектов ISlideText. Каждый объект представляет текст на соответствующем слайде. Объекты ISlideText имеют следующие методы:

get_Text() - Текст в фигурах слайда.  
get_MasterText() - Текст в фигурах мастер‑страницы для этого слайда.  
get_LayoutText() - Текст в фигурах страницы макета для этого слайда.  
get_NotesText() - Текст в фигурах страницы примечаний для этого слайда.

Существует также класс SlideText, который реализует интерфейс ISlideText.

Новый API можно использовать следующим образом:
``` cpp
auto text = System::MakeObject<PresentationFactory>()->GetPresentationText(u"presentation.ppt", TextExtractionArrangingMode::Unarranged);
Console::WriteLine(text->get_SlidesText()[0]->get_Text());
Console::WriteLine(text->get_SlidesText()[0]->get_LayoutText());
Console::WriteLine(text->get_SlidesText()[0]->get_MasterText());
Console::WriteLine(text->get_SlidesText()[0]->get_NotesText());
```


## **Вопросы и ответы**

**Насколько быстро Aspose.Slides обрабатывает большие презентации при извлечении текста?**

Aspose.Slides оптимизирован для высокой производительности и эффективно обрабатывает даже большие презентации, что делает её подходящей для сценариев реального времени или массовой обработки.

**Может ли Aspose.Slides извлекать текст из таблиц и диаграмм в презентациях?**

Да, Aspose.Slides полностью поддерживает извлечение текста из таблиц, диаграмм и других сложных элементов слайдов, позволяя легко получать и анализировать весь текстовый контент.

**Нужна ли мне специальная лицензия Aspose.Slides для извлечения текста из презентаций?**

Вы можете извлекать текст с помощью бесплатной пробной версии Aspose.Slides, однако она имеет определённые ограничения, например, обработку только ограниченного числа слайдов. Для неограниченного использования и работы с более крупными презентациями рекомендуется приобрести полную лицензию.