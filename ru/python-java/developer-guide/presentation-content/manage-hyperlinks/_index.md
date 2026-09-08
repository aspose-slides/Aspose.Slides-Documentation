---
title: Управление гиперссылками презентаций в Python через Java
linktitle: Управление гиперссылкой
type: docs
weight: 20
url: /ru/python-java/manage-hyperlinks/
keywords:
- добавить URL
- добавить гиперссылку
- создать гиперссылку
- форматировать гиперссылку
- удалить гиперссылку
- обновить гиперссылку
- гиперссылка в тексте
- гиперссылка на слайд
- гиперссылка на фигуру
- гиперссылка на изображение
- гиперссылка на видео
- изменяемая гиперссылка
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Легко управляйте гиперссылками в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Python через Java — улучшайте интерактивность и рабочий процесс за считанные минуты."
---
## **Введение**

Гиперссылка — это ссылка на объект, данные или место в документе. Ниже перечислены типичные гиперссылки в презентациях PowerPoint:

* Ссылки на веб‑сайты внутри текста, фигур или медиа
* Ссылки на слайды

Aspose.Slides for Python via Java позволяет выполнять множество задач, связанных с гиперссылками в презентациях. 

{{% alert color="info" title="Note" %}} 

Возможно, вам будет интересен простой, [бесплатный онлайн‑редактор PowerPoint.](https://products.aspose.app/slides/ru/editor)

{{% /alert %}} 

## **Добавить URL‑гиперссылки**

### **Добавить URL‑гиперссылки к тексту**

Этот код на Python показывает, как добавить гиперссылку на веб‑сайт к тексту:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")
    portion_format.setFontHeight(32)

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Добавить URL‑гиперссылки к фигурам или кадрам**

Этот пример кода на Python via Java демонстрирует, как добавить гиперссылку на веб‑сайт к фигуре:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50)

    shape.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Добавить URL‑гиперссылки к медиа**

Aspose.Slides позволяет добавлять гиперссылки к изображениям, аудио‑ и видеофайлам. 

Этот пример кода показывает, как добавить гиперссылку к **изображению**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    # Добавляет изображение в презентацию
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    # Создает рамку изображения на слайде 1 на основе ранее добавленного изображения
    picture_frame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    picture_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    picture_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Этот пример кода показывает, как добавить гиперссылку к **аудиофайлу**:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat

presentation = Presentation()
try:
    audio_data = Path("audio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = presentation.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio)

    audio_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    audio_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Этот пример кода показывает, как добавить гиперссылку к **видео**:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.avi").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video)

    video_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    video_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="success" title="Tip" %}} 

Возможно, вам будет полезно посмотреть *[Manage OLE](/slides/ru/python-java/manage-ole/)*.

{{% /alert %}}

## **Использовать гиперссылки для создания оглавления**

Поскольку гиперссылки позволяют добавлять ссылки на объекты или места, их можно использовать для создания оглавления. 

Этот пример кода показывает, как создать оглавление с гиперссылками:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())

    content_table = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100)
    content_table.getFillFormat().setFillType(FillType.NoFill)
    content_table.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    content_table.getTextFrame().getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText("Title of slide 2 .......... ")

    link_portion = Portion()
    link_portion.setText("Page 2")
    link_portion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(second_slide)

    paragraph.getPortions().add(link_portion)
    content_table.getTextFrame().getParagraphs().add(paragraph)

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Форматировать гиперссылки**

### **Цвет**

С помощью свойства [Hyperlink.setColorSource](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlink/#setColorSource) в классе [Hyperlink](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlink/) можно задать цвет гиперссылок и получить информацию о цвете из гиперссылок. Эта возможность впервые появилась в PowerPoint 2019, поэтому изменения, связанные со свойством, не применяются к более ранним версиям PowerPoint.

Этот пример кода демонстрирует операцию, в которой на один и тот же слайд были добавлены гиперссылки разных цветов:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Hyperlink, HyperlinkColorSource, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    colored_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, False)
    colored_link_shape.addTextFrame("This is a sample of colored hyperlink.")
    portion_format = colored_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.RED)

    default_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, False)
    default_link_shape.addTextFrame("This is a sample of usual hyperlink.")
    default_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com/"))

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Удалить гиперссылки из презентаций**

### **Удалить гиперссылки из текста**

Этот код на Python показывает, как удалить гиперссылку из текста на слайде презентации:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, AutoShape

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None:
                for paragraph in text_frame.getParagraphs():
                    for portion in paragraph.getPortions():
                        portion.getPortionFormat().getHyperlinkManager().removeHyperlinkClick()

    presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Удалить гиперссылки из фигур или кадров**

Этот код на Python показывает, как удалить гиперссылку из фигуры на слайде презентации: 

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        shape.getHyperlinkManager().removeHyperlinkClick()
    presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Изменяемая гиперссылка**

Класс [Hyperlink](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlink/) изменяемый. С его помощью можно менять значения следующих свойств:

- [setTargetFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlink/#setTargetFrame)
- [setTooltip](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlink/#setTooltip)
- [setHistory](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlink/#setHistory)
- [setHighlightClick](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlink/#setHighlightClick)
- [setStopSoundOnClick](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlink/#setStopSoundOnClick)

Этот фрагмент кода показывает, как добавить гиперссылку на слайд и позже изменить её всплывающую подсказку:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")
    portion_format.setFontHeight(32)

    # Изменяет всплывающую подсказку гиперссылки, которая уже была добавлена
    portion_format.getHyperlinkClick().setTooltip("Aspose: the File Format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Поддерживаемые свойства в HyperlinkQueries**

Вы можете получить доступ к [HyperlinkQueries](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlinkqueries/) из презентации, слайда или текста, для которого определена гиперссылка. 

- [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getHyperlinkQueries)
- [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/#getHyperlinkQueries)

Класс [HyperlinkQueries](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlinkqueries/) поддерживает следующие методы и свойства: 

- [getHyperlinkClicks](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks)
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers)
- [getAnyHyperlinks](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks)
- [removeAllHyperlinks](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks)

## **FAQ**

**Как создать внутренняя навигацию не только к слайду, но и к «разделу» или к первому слайду раздела?**

Разделы в PowerPoint — это группы слайдов; навигация технически указывает на конкретный слайд. Чтобы «перейти к разделу», обычно связываются с его первым слайдом.

**Можно ли привязать гиперссылку к элементам шаблона слайда, чтобы она работала на всех слайдах?**

Да. Элементы шаблона и макета поддерживают гиперссылки. Такие ссылки отображаются на дочерних слайдах и кликабельны во время показа.

**Сохраняются ли гиперссылки при экспорте в PDF, HTML, изображения или видео?**

В [PDF](/slides/ru/python-java/convert-powerpoint-to-pdf/) и [HTML](/slides/ru/python-java/convert-powerpoint-to-html/) да — ссылки, как правило, сохраняются. При экспорте в [изображения](/slides/ru/python-java/convert-powerpoint-to-png/) и [видео](/slides/ru/python-java/convert-powerpoint-to-video/) кликабельность не переносится из‑за характера этих форматов (растровые кадры/видео не поддерживают гиперссылки).