---
title: Гиперссылка
type: docs
weight: 130
url: /ru/python-java/examples/elements/hyperlink/
keywords:
- пример кода
- гиперссылка
- добавить гиперссылку
- доступ к гиперссылке
- удалить гиперссылку
- обновить гиперссылку
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Добавляйте и управляйте гиперссылками в Aspose.Slides for Python via Java: создавайте, получайте доступ, удаляйте и обновляйте ссылки в презентациях PPT, PPTX и ODP."
---
В этой статье демонстрируется добавление, доступ, удаление и обновление гиперссылок на фигурах с использованием **Aspose.Slides for Python via Java**.

Установите пакет, как описано в [Installation](/slides/ru/python-java/installation/). Каждый пример импортирует `asposeslides` перед запуском JVM, затем импортирует API после запуска JVM.

## **Add a Hyperlink**
Создайте прямоугольную фигуру с гиперссылкой, указывающей на внешний веб‑сайт.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))
finally:
    presentation.dispose()
```

## **Access a Hyperlink**
Прочтите информацию о гиперссылке из текстовой части фигуры.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))

    hyperlink = text_portion.getPortionFormat().getHyperlinkClick()
finally:
    presentation.dispose()
```

## **Remove a Hyperlink**
Удалите гиперссылку из текста фигуры.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))

    text_portion.getPortionFormat().setHyperlinkClick(None)
finally:
    presentation.dispose()
```

## **Update a Hyperlink**
Измените цель существующей гиперссылки. Используйте [HyperlinkManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlinkmanager/) для изменения текста, уже содержащего гиперссылку, что имитирует безопасное обновление гиперссылок в PowerPoint.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://old.example.com"))

    # Изменение гиперссылки внутри существующего текста должно выполняться через
    # HyperlinkManager, а не прямой установки свойства.
    # Это имитирует то, как PowerPoint безопасно обновляет гиперссылки.
    text_portion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com")
finally:
    presentation.dispose()
```