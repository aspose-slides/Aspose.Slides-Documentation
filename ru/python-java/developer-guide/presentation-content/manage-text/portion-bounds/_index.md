---
title: Получить границы текстовой части из презентаций в Python через Java
linktitle: Границы части
type: docs
weight: 47
url: /ru/python-java/portion-bounds/
keywords:
- границы текстовой части
- текстовая часть
- текстовый фрагмент
- координаты текста
- позиция текста
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Узнайте, как получить границы текстовой части в презентациях PowerPoint с помощью Aspose.Slides для Python через Java."
---
## **Обзор**

Часть текста представляет собой конкретный фрагмент текста внутри абзаца и позволяет работать с этим фрагментом независимо от окружающего содержимого. В Aspose.Slides части можно использовать, когда необходимо получить границы текстового фрагмента, применить форматирование только к части абзаца или управлять поведением текста на более детальном уровне.

В этой статье показано, как получить ограничивающий прямоугольник части, используя [Portion.getRect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portion/#getRect). Также показано, как получить координаты начала части, используя [Portion.getCoordinates](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portion/#getCoordinates). Кроме того, рассматриваются типичные сценарии, связанные с частями, такие как применение гиперссылки к отдельному текстовому фрагменту, понимание того, как разрешается форматирование через часть, абзац, текстовый кадр и наследование темы, а также обработка случаев, когда указанный шрифт недоступен.

## **Получение границ текстовой части**

Используйте [Portion.getRect](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portion/#getRect) для получения ограничивающего прямоугольника текстовой части:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            rectangle = portion.getRect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
finally:
    presentation.dispose()
```

## **Получение координат текстовой части**

Используйте [Portion.getCoordinates](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portion/#getCoordinates) для получения координат начала текстовой части:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            point = portion.getCoordinates()
            print(f"X = {point.x}; Y = {point.y}")
finally:
    presentation.dispose()
```

## **FAQ**

**Можно ли применить гиперссылку только к части текста в одном абзаце?**

Да, вы можете [назначить гиперссылку](/slides/ru/python-java/manage-hyperlinks/) отдельной части; только этот фрагмент будет кликабельным, а не весь абзац.

**Как работает наследование стилей: что переопределяет часть, а что берётся из абзаца или текстового кадра?**

Свойства уровня части имеют наивысший приоритет. Если свойство не задано у [Portion](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portion/), Aspose.Slides берёт его из [Paragraph](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraph/). Если и там оно не задано, Aspose.Slides использует стиль из [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/) или [theme](https://reference.aspose.com/slides/ru/python-java/aspose.slides/theme/).

**Что происходит, если указанный для части шрифт отсутствует на целевой машине или сервере?**

Применяются [правила подстановки шрифтов](/slides/ru/python-java/font-selection-sequence/). Текст может перераспределиться: могут измениться метрики, переносы и ширина, что важно для точного позиционирования.

**Могу ли я задать прозрачность заливки текста или градиент для части независимо от остального абзаца?**

Да, цвет текста, заливка и прозрачность на уровне [Portion](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portion/) могут отличаться от соседних фрагментов.