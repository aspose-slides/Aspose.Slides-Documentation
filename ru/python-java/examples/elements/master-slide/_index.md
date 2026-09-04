---
title: Главный слайд
type: docs
weight: 30
url: /ru/python-java/examples/elements/master-slide/
keywords:
- пример кода
- главный слайд
- добавить главный слайд
- доступ к главному слайду
- удалить главный слайд
- неиспользуемый главный слайд
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Управляйте главными слайдами с помощью Aspose.Slides for Python via Java: создавайте, получайте доступ, удаляйте и очищайте мастеры в презентациях PowerPoint и OpenDocument."
---
Master slides form the top level of the slide inheritance hierarchy in PowerPoint. A **master slide** defines common design elements such as backgrounds, logos, and text formatting. **Layout slides** inherit from master slides, and **normal slides** inherit from layout slides.

This article demonstrates how to create, modify, and manage master slides using **Aspose.Slides for Python via Java**.

Install the package as described in [Установка](/slides/ru/python-java/installation/). Each example imports `asposeslides` before starting the JVM, then imports the API after the JVM is running.

## **Добавить master slide**

This example shows how to create a new master slide by cloning the default one. It then adds a company name banner to all slides through layout inheritance.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Клонировать исходный главный слайд.
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    # Добавить баннер с названием компании в верхнюю часть главного слайда.
    text_box = new_master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25)
    text_box.getTextFrame().setText("Company Name")
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    text_box.getFillFormat().setFillType(FillType.NoFill)

    # Привязать новый главный слайд к макетному слайду.
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)

    # Привязать макетный слайд к первому слайду в презентации.
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Master slides provide a way to apply consistent branding or shared design elements across all slides. Changes made to a master are automatically reflected on dependent layout and normal slides.
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Shapes and formatting added to a master slide are inherited by layout slides and, in turn, by all normal slides that use those layouts. The image below illustrates how a text box added to a master slide is automatically rendered on the final slide.
{{% /alert %}}

![Master Inheritance Example](master-slide-banner.png)

## **Доступ к master slide**

You can access master slides through the presentation's master collection. This example retrieves the first master slide and changes its background type.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation

presentation = Presentation()
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    first_master_slide.getBackground().setType(BackgroundType.OwnBackground)
finally:
    presentation.dispose()
```

## **Удалить master slide**

A master slide can be removed by index or by reference after it is no longer used. This example assigns a cloned master slide to the presentation and then removes the original master by index.

```python
import jpage
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)

    # Удалить неиспользуемый оригинальный главный слайд по индексу.
    presentation.getMasters().removeAt(0)

    # Альтернативно, удалить неиспользуемый главный слайд по ссылке:
    # presentation.getMasters().remove(unused_master_slide)
finally:
    presentation.dispose()
```

## **Удалить неиспользуемые master slides**

Some presentations contain master slides that are not in use. Removing these slides can help reduce the file size.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    presentation.getMasters().addClone(default_master_slide)

    # Удалить все неиспользуемые главные слайды, включая помеченные как Preserve.
    presentation.getMasters().removeUnused(True)
finally:
    presentation.dispose()
```