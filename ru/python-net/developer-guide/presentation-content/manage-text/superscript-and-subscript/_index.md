---
title: Надстрочные и подстрочные символы
type: docs
weight: 80
url: /python-net/superscript-and-subscript/
keywords: "Надстрочный текст, Подстрочный текст, Добавить надстрочный текст, Добавить подстрочный текст, Презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Добавление надстрочного и подстрочного текста в презентации PowerPoint на Python"
---

## **Управление надстрочным и подстрочным текстом**
Вы можете добавить надстрочный и подстрочный текст в любой параграф. Для добавления надстрочного или подстрочного текста в текстовый фрейм Aspose.Slides необходимо использовать свойства **Escapement** класса PortionFormat.

Это свойство возвращает или устанавливает надстрочный или подстрочный текст (значение от -100% (подстрочный) до 100% (надстрочный). Например:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Получите ссылку на слайд, используя его индекс.
- Добавьте автофигуру типа Прямоугольник на слайд.
- Получите доступ к ITextFrame, связанному с IAutoShape.
- Очистите существующие параграфы.
- Создайте новый объект параграфа для хранения надстрочного текста и добавьте его в коллекцию IParagraphs ITextFrame.
- Создайте новый объект порции.
- Установите свойство Escapement для порции от 0 до 100 для добавления надстрочного текста. (0 означает отсутствие надстрочного текста)
- Установите некоторый текст для порции и добавьте его в коллекцию порций параграфа.
- Создайте новый объект параграфа для хранения подстрочного текста и добавьте его в коллекцию IParagraphs ITextFrame.
- Создайте новый объект порции.
- Установите свойство Escapement для порции от 0 до -100 для добавления подстрочного текста. (0 означает отсутствие подстрочного текста)
- Установите некоторый текст для порции и добавьте его в коллекцию порций параграфа.
- Сохраните презентацию в виде файла PPTX.

Реализация вышеуказанных шагов приведена ниже.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    # Получить слайд
    slide = presentation.slides[0]

    # Создать текстовое поле
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    textFrame = shape.text_frame
    textFrame.paragraphs.clear()

    # Создать параграф для надстрочного текста
    superPar = slides.Paragraph()

    # Создать порцию с обычным текстом
    portion1 = slides.Portion()
    portion1.text = "SlideTitle"
    superPar.portions.add(portion1)

    # Создать порцию с надстрочным текстом
    superPortion = slides.Portion()
    superPortion.portion_format.escapement = 30
    superPortion.text = "TM"
    superPar.portions.add(superPortion)

    # Создать параграф для подстрочного текста
    paragraph2 = slides.Paragraph()

    # Создать порцию с обычным текстом
    portion2 = slides.Portion()
    portion2.text = "a"
    paragraph2.portions.add(portion2)

    # Создать порцию с подстрочным текстом
    subPortion = slides.Portion()
    subPortion.portion_format.escapement = -25
    subPortion.text = "i"
    paragraph2.portions.add(subPortion)

    # Добавить параграфы в текстовое поле
    textFrame.paragraphs.add(superPar)
    textFrame.paragraphs.add(paragraph2)

    presentation.save("TestOut.pptx", slides.export.SaveFormat.PPTX)
```