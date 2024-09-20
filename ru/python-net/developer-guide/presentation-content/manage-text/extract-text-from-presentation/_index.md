---
title: Извлечение текста из презентации
type: docs
weight: 90
url: /python-net/extract-text-from-presentation/
keywords: "Извлечение текста из слайда, Извлечение текста из PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Извлечение текста из слайда или презентации PowerPoint на Python"
---

{{% alert color="primary" %}} 

Не редкость, когда разработчикам нужно извлекать текст из презентации. Для этого необходимо извлечь текст из всех фигур на всех слайдах презентации. Эта статья объясняет, как извлекать текст из презентаций Microsoft PowerPoint PPTX с помощью Aspose.Slides. Текст можно извлекать следующими способами:

- [Извлечение текста из одного слайда](/slides/python-net/extracting-text-from-the-presentation/)
- [Извлечение текста с использованием метода GetAllTextBoxes](/slides/python-net/extracting-text-from-the-presentation/)
- [Категоризированное и быстрое извлечение текста](/slides/python-net/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **Извлечение текста из слайда**
Aspose.Slides для Python через .NET предоставляет пространство имен Aspose.Slides.Util, которое включает класс SlideUtil. Этот класс предоставляет ряд перегруженных статических методов для извлечения всего текста из презентации или слайда. Чтобы извлечь текст из слайда в PPTX-презентации, используйте перегруженный статический метод [GetAllTextBoxes](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/), предоставленный классом SlideUtil. Этот метод принимает объект Slide в качестве параметра.
При выполнении метод Slide сканирует весь текст с указанного слайда и возвращает массив объектов TextFrame. Это означает, что вся форматировка текста, связанная с текстом, доступна. Следующий фрагмент кода извлекает весь текст на первом слайде презентации:

```py
import aspose.slides as slides

#Создаем экземпляр класса Presentation, который представляет файл PPTX
with slides.Presentation("pres.pptx") as pptxPresentation:
    # Получаем массив объектов ITextFrame из всех слайдов в PPTX
    textFramesPPTX = slides.util.SlideUtil.get_all_text_boxes(pptxPresentation.slides[0])
    
    # Проходим по массиву TextFrames
    for i in range(len(textFramesPPTX)):
	    # Проходим по абзацам в текущем ITextFrame
        for para in textFramesPPTX[i].paragraphs:
            # Проходим по частям в текущем IParagraph
            for port in para.portions:
			    # Выводим текст в текущей части
                print(port.text)

    			# Выводим высоту шрифта текста
                print(port.portion_format.font_height)

			    # Выводим название шрифта текста
                if port.portion_format.latin_font != None:
                    print(port.portion_format.latin_font.font_name)
```




## **Извлечение текста из презентации**
Чтобы сканировать текст из всей презентации, используйте статический метод [GetAllTextFrames](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/), предоставленный классом SlideUtil. Он принимает два параметра:

1. Во-первых, объект Presentation, который представляет PPTX-презентацию, из которой извлекается текст.
1. Во-вторых, логическое значение, определяющее, следует ли включать мастер-слайд при сканировании текста из презентации.
   Метод возвращает массив объектов TextFrame, полный информации о форматировании текста. Код ниже сканирует текст и информацию о форматировании из презентации, включая мастер-слайды.

```py
import aspose.slides as slides

#Создаем экземпляр класса Presentation, который представляет файл PPTX
with slides.Presentation("pres.pptx") as pptxPresentation:
    # Получаем массив объектов ITextFrame из всех слайдов в PPTX
    textFramesPPTX = slides.util.SlideUtil.get_all_text_frames(pptxPresentation, True)
    
    # Проходим по массиву TextFrames
    for i in range(len(textFramesPPTX)):
	    # Проходим по абзацам в текущем ITextFrame
        for para in textFramesPPTX[i].paragraphs:
            # Проходим по частям в текущем IParagraph
            for port in para.portions:
			    # Выводим текст в текущей части
                print(port.text)

    			# Выводим высоту шрифта текста
                print(port.portion_format.font_height)

			    # Выводим название шрифта текста
                if port.portion_format.latin_font != None:
                    print(port.portion_format.latin_font.font_name)
```




## **Категоризированное и быстрое извлечение текста**
В класс Presentation был добавлен новый статический метод GetPresentationText. У этого метода есть две перегрузки:

```py
slides.Presentation.get_presentation_text(stream)
slides.Presentation.get_presentation_text(stream, mode)      
```

Аргумент enum ExtractionMode указывает режим организации вывода текста и может быть установлен на следующие значения:
Неорганизованный - «сырой» текст без учета позиции на слайде
Организованный - текст располагается в том же порядке, что и на слайде

Режим Неорганизованный может использоваться, когда скорость критична, он быстрее, чем организованный режим.

PresentationText представляет собой «сырой» текст, извлеченный из презентации. Он содержит свойство `slides_text` из пространства имен Aspose.Slides.Util, которое возвращает массив объектов SlideText. Каждый объект представляет текст на соответствующем слайде. Объект SlideText имеет следующие свойства:

SlideText.text - Текст на фигурах слайда
SlideText.master_text - Текст на фигурах основного слайда для этого слайда
SlideText.layout_text - Текст на фигурах макета для этого слайда
SlideText.notes_text - Текст на фигурах заметок для этого слайда


Новый API можно использовать так:

```py
import aspose.slides as slides

text1 = slides.PresentationFactory().get_presentation_text("pres.pptx", slides.TextExtractionArrangingMode.UNARRANGED)
print(text1.slides_text[0].text)
print(text1.slides_text[0].layout_text)
print(text1.slides_text[0].master_text)
print(text1.slides_text[0].notes_text)
```