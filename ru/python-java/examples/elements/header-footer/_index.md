---
title: Заголовок и нижний колонтитул
type: docs
weight: 220
url: /ru/python-java/examples/elements/header-footer/
keywords:
- пример кода
- заголовок
- нижний колонтитул
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Управляйте заголовками и нижними колонтитулами слайдов с помощью Aspose.Slides для Python через Java: добавляйте даты, номера слайдов и пользовательский текст в презентациях форматов PPT, PPTX и ODP."
---
В этой статье показано, как добавить нижние колонтитулы и обновить заполнители даты и времени, используя **Aspose.Slides for Python via Java**.

Установите пакет, как описано в разделе [Installation](/slides/ru/python-java/installation/). Каждый пример импортирует `asposeslides` перед запуском JVM, а затем импортирует API после запуска JVM.

## **Add a Footer**

Добавьте текст в область нижнего колонтитула слайда и сделайте его видимым.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setFooterText("My footer")
    slide.getHeaderFooterManager().setFooterVisibility(True)
finally:
    presentation.dispose()
```

## **Update Date and Time**

Измените заполнитель даты и времени на слайде.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setDateTimeText("01/01/2024")
    slide.getHeaderFooterManager().setDateTimeVisibility(True)
finally:
    presentation.dispose()
```