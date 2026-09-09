---
title: Управление надстрочным и подстрочным текстом в презентациях с помощью Python через Java
linktitle: Надстрочный и подстрочный
type: docs
weight: 80
url: /ru/python-java/superscript-and-subscript/
keywords:
- надстрочный
- подстрочный
- добавить надстрочный
- добавить подстрочный
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Освойте надстрочный и подстрочный текст в Aspose.Slides для Python через Java и улучшите свои презентации с помощью профессионального форматирования текста для максимального воздействия."
---
## **Обзор**

Aspose.Slides предоставляет функции для интеграции верхнего и нижнего индекса текста в презентации PowerPoint (PPT, PPTX) и OpenDocument (ODP). Независимо от того, нужно ли вам выделить химические формулы, математические уравнения или добавить сноски, эти специальные варианты форматирования помогают сохранить ясность и точность. В этой статье вы узнаете, как без проблем применять стили верхнего и нижнего индекса и добиваться профессионального результата на каждом слайде.

## **Управление верхним и нижним индексом текста**

Вы можете добавить текст в верхнем или нижнем индексе в любой части абзаца. Чтобы применить это форматирование в текстовом фрейме Aspose.Slides, используйте метод [setEscapement](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portionformat/#setEscapement) класса [PortionFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portionformat/).

Значение escapement варьируется от -100 % (нижний индекс) до 100 % (верхний индекс). Например:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
- Получите слайд по его индексу.
- Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/) типа [ShapeType.Rectangle](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapetype/#Rectangle) на слайд.
- Получите доступ к [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/) , связанному с [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/).
- Очистите существующие абзацы.
- Создайте абзац для текста в верхнем индексе и добавьте его в [коллекцию абзацев](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/#getParagraphs) текстового фрейма.
- Создайте часть текста.
- Используйте [setEscapement](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portionformat/#setEscapement) для указания значения от 0 до 100 для верхнего индекса (0 — нет верхнего индекса).
- Установите текст [Portion](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portion/) и добавьте его в коллекцию частей абзаца.
- Создайте абзац для текста в нижнем индексе и добавьте его в [коллекцию абзацев](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/#getParagraphs) текстового фрейма.
- Создайте часть текста.
- Используйте [setEscapement](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portionformat/#setEscapement) для указания значения от -100 до 0 для нижнего индекса (0 — нет нижнего индекса).
- Установите текст [Portion](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portion/) и добавьте его в коллекцию частей абзаца.
- Сохраните презентацию в файл PPTX.

Следующий пример реализует эти шаги:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Paragraph, Portion, Presentation, SaveFormat, ShapeType

# Создать презентацию.
presentation = Presentation()
try:
    # Получить слайд.
    slide = presentation.getSlides().get_Item(0)

    # Создать текстовое поле.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    # Создать абзац для надстрочного текста.
    superscript_paragraph = Paragraph()

    # Создать часть с обычным текстом.
    title_portion = Portion()
    title_portion.setText("SlideTitle")
    superscript_paragraph.getPortions().add(title_portion)

    # Создать часть с надстрочным текстом.
    superscript_portion = Portion()
    superscript_portion.getPortionFormat().setEscapement(30)
    superscript_portion.setText("TM")
    superscript_paragraph.getPortions().add(superscript_portion)

    # Создать абзац для нижстрочного текста.
    subscript_paragraph = Paragraph()

    # Создать часть с обычным текстом.
    base_portion = Portion()
    base_portion.setText("a")
    subscript_paragraph.getPortions().add(base_portion)

    # Создать часть с нижстрочным текстом.
    subscript_portion = Portion()
    subscript_portion.getPortionFormat().setEscapement(-25)
    subscript_portion.setText("i")
    subscript_paragraph.getPortions().add(subscript_portion)

    # Добавить абзацы в текстовое поле.
    text_frame.getParagraphs().add(superscript_paragraph)
    text_frame.getParagraphs().add(subscript_paragraph)

    presentation.save("formatText.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Будут ли сохранены верхний и нижний индексы при экспорте в PDF или другие форматы?**

Да, Aspose.Slides корректно сохраняет форматирование верхнего и нижнего индексов при экспорте презентаций в PDF, PPT/PPTX, изображения и другие поддерживаемые форматы. Специальное форматирование остаётся неизменным во всех выходных файлах.

**Можно ли комбинировать верхний и нижний индексы с другими стилями форматирования, например полужирным или курсивом?**

Да, Aspose.Slides позволяет смешивать различные стили текста в одной части. Вы можете включать полужирный, курсив, подчёркивание и одновременно применять верхний или нижний индекс, настроив соответствующие свойства в [PortionFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portionformat/).

**Работает ли форматирование верхнего и нижнего индекса для текста внутри таблиц, диаграмм или SmartArt?**

Да, Aspose.Slides поддерживает форматирование в большинстве объектов, включая таблицы и элементы диаграмм. При работе с SmartArt необходимо получить доступ к соответствующим элементам (например, к [SmartArtNode](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartartnode/)) и их текстовым контейнерам, а затем настроить свойства [PortionFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portionformat/) аналогичным образом.