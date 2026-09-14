---
title: Добавление водяных знаков в презентации на Python
linktitle: Водяной знак
type: docs
weight: 40
url: /ru/python-java/watermark/
keywords:
- водяной знак
- текстовый водяной знак
- графический водяной знак
- добавить водяной знак
- изменить водяной знак
- удалить водяной знак
- удалить водяной знак
- добавить водяной знак в PPT
- добавить водяной знак в PPTX
- добавить водяной знак в ODP
- удалить водяной знак из PPT
- удалить водяной знак из PPTX
- удалить водяной знак из ODP
- удалить водяной знак из PPT
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Управляйте текстовыми и графическими водяными знаками в презентациях PowerPoint и OpenDocument с помощью Python, чтобы обозначить черновик, конфиденциальную информацию, авторские права и многое другое."
---
## **Введение**

**Водяной знак** в презентации — это текстовая или графическая отметка, используемая на отдельном слайде или на всех слайдах презентации. Обычно водяной знак применяется, чтобы указать, что презентация является черновиком (например, водяной знак «Черновик»), содержит конфиденциальную информацию (например, «Конфиденциально»), принадлежит определённой компании (например, «Название компании»), идентифицировать автора и т.д. Водяной знак помогает предотвратить нарушения авторских прав, указывая, что копирование презентации не допускается. Водяные знаки поддерживаются как в PowerPoint, так и в форматах OpenOffice. В Aspose.Slides вы можете добавить водяной знак в файлы PowerPoint PPT, PPTX и OpenOffice ODP.

В [**Aspose.Slides**](https://products.aspose.com/slides/ru/python-java/) есть разные способы создания водяных знаков в документах PowerPoint или OpenOffice и изменения их дизайна и поведения. Общее требование — для добавления текстовых водяных знаков использовать класс [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/), а для графических — класс [PictureFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pictureframe/) или заполнить форму водяного знака изображением. [PictureFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pictureframe/) наследуется от класса [Shape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/), что позволяет применять все гибкие настройки объекта формы. Поскольку [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/) не является формой и имеет ограниченные настройки, его оборачивают в объект [Shape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/).

Есть два способа применения водяного знака: к отдельному слайду или ко всем слайдам презентации. Для добавления водяного знака ко всем слайдам используется мастер‑слайд — водяной знак добавляется в мастер‑слайд, полностью оформляется там и применяется ко всем слайдам, не влияя на возможность изменения водяного знака на отдельных слайдах.

Водяной знак обычно считается недоступным для редактирования другими пользователями. Чтобы предотвратить редактирование водяного знака (точнее, его родительской формы), Aspose.Slides предоставляет функциональность блокировки форм. Конкретную форму можно заблокировать на обычном слайде или на мастере‑слайде. Когда форма водяного знака заблокирована на мастере‑слайде, она будет заблокирована на всех слайдах презентации.

Можно задать имя водяного знака, чтобы в дальнейшем при необходимости удалить его, найти форму по имени в коллекции форм слайда.

Водяной знак можно оформить произвольно; однако обычно у него есть типичные характеристики: центрирование, вращение, расположение на переднем плане и т.п. Ниже показано, как использовать эти возможности в примерах.

## **Текстовый водяной знак**

### **Добавление текстового водяного знака на слайд**

Чтобы добавить текстовый водяной знак в PPT, PPTX или ODP, сначала добавьте форму на слайд, затем добавьте текстовый кадр в эту форму. Текстовый кадр представляется классом [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/). Этот тип не наследуется от [Shape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/), у которого широкий набор свойств для гибкого позиционирования водяного знака. Поэтому объект [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/) оборачивается в объект [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/). Чтобы добавить текст водяного знака в форму, используйте метод [addTextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/#addTextFrame), как показано ниже.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Примечание" %}} 
- [Как использовать класс TextFrame](/slides/ru/python-java/text-formatting/)
{{% /alert %}}

### **Добавление текстового водяного знака в презентацию**

Если необходимо добавить текстовый водяной знак сразу во всю презентацию (то есть на все слайды), добавьте его в [MasterSlide](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masterslide/). Дальше логика такая же, как при добавлении водяного знака на отдельный слайд — создайте объект [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/) и затем добавьте в него водяной знак с помощью метода [addTextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/#addTextFrame).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    watermark_shape = master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Примечание" %}} 
- [Как использовать мастер‑слайд](/slides/ru/python-java/slide-master/)
{{% /alert %}}

### **Установка прозрачности формы водяного знака**

По умолчанию прямоугольная форма имеет цвета заливки и контура. Следующие строки кода делают форму прозрачной.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.getFillFormat().setFillType(FillType.NoFill)
    watermark_shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
finally:
    presentation.dispose()
```

### **Установка шрифта для текстового водяного знака**

Можно изменить шрифт текстового водяного знака, как показано ниже.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FontData

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    text_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat()
    font = FontData("Arial")
    text_format.setLatinFont(font)
    text_format.setFontHeight(50)
finally:
    presentation.dispose()
```

### **Установка цвета текста водяного знака**

Чтобы задать цвет текста водяного знака, используйте следующий код:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    alpha, red, green, blue = 150, 200, 200, 200
    fill_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat()
    fill_format.setFillType(FillType.Solid)
    color = Color(red, green, blue, alpha)
    fill_format.getSolidFillColor().setColor(color)
finally:
    presentation.dispose()
```

### **Центрирование текстового водяного знака**

Водяной знак можно центрировать на слайде, выполнив следующее:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_size = presentation.getSlideSize().getSize()
    watermark_width = 400
    watermark_height = 40
    watermark_x = (slide_size.getWidth() - watermark_width) / 2
    watermark_y = (slide_size.getHeight() - watermark_height) / 2
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, watermark_x, watermark_y, watermark_width, watermark_height)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

Ниже показан окончательный результат.

![Текстовый водяной знак](text_watermark.png)

## **Графический водяной знак**

### **Добавление графического водяного знака в презентацию**

Чтобы добавить графический водяной знак на слайд презентации, выполните следующее:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, PictureFillMode

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    image_data = Path("watermark.png").read_bytes()
    image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(image_data))
    watermark_shape.getFillFormat().setFillType(FillType.Picture)
    watermark_shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    watermark_shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
finally:
    presentation.dispose()
```

### **Блокировка водяного знака от редактирования**

Если необходимо запретить редактирование водяного знака, используйте метод [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/#getAutoShapeLock) у формы. С помощью этого свойства можно защитить форму от выделения, изменения размера, перемещения, группировки с другими элементами, блокировать её текст от редактирования и многое другое:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    # Заблокировать форму водяного знака от изменения.
    watermark_shape.getAutoShapeLock().setSelectLocked(True)
    watermark_shape.getAutoShapeLock().setSizeLocked(True)
    watermark_shape.getAutoShapeLock().setTextLocked(True)
    watermark_shape.getAutoShapeLock().setPositionLocked(True)
    watermark_shape.getAutoShapeLock().setGroupingLocked(True)
finally:
    presentation.dispose()
```

### **Перемещение водяного знака на передний план**

В Aspose.Slides порядок наложения форм задаётся методом [ShapeCollection.reorder](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#reorder). Для этого вызовите метод у коллекции форм слайда, передав ссылку на форму и её порядковый номер. Таким способом можно переместить форму на передний план или отправить её на задний план. Эта возможность особенно полезна, когда нужно разместить водяной знак спереди презентации:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    shape_count = slide.getShapes().size()
    slide.getShapes().reorder(shape_count - 1, watermark_shape)
finally:
    presentation.dispose()
```

### **Установка вращения водяного знака**

Ниже пример кода, показывающего, как скорректировать угол вращения водяного знака, чтобы он был размещён диагонально через слайд:

```python
import jpype
import asposeslides
import math

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    slide_size = presentation.getSlideSize().getSize()
    diagonal_angle = math.atan((slide_size.getHeight() / slide_size.getWidth())) * 180 / math.pi
    watermark_shape.setRotation(diagonal_angle)
finally:
    presentation.dispose()
```

### **Задание имени для водяного знака**

Aspose.Slides позволяет задать имя форме. Используя имя формы, вы сможете позже обратиться к ней для изменения или удаления. Чтобы задать имя форме водяного знака, передайте его в метод [Shape.setName](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#setName):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.setName("watermark")
finally:
    presentation.dispose()
```

### **Удаление водяного знака**

Чтобы удалить форму водяного знака, используйте метод [Shape.getName](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getName) для её поиска в коллекции форм слайда. Затем передайте найденную форму в метод [ShapeCollection.remove](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#remove):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    slide_shapes = slide.getShapes().toArray()
    for shape in slide_shapes:
        if shape.getName() == "watermark":
            slide.getShapes().remove(shape)
finally:
    presentation.dispose()
```

## **FAQ**

**Что такое водяной знак и зачем его использовать?**

Водяной знак — это накладной текст или изображение, применяемый к слайдам, который помогает защищать интеллектуальную собственность, укреплять узнаваемость бренда и предотвращать несанкционированное использование презентаций.

**Можно ли добавить водяной знак на все слайды презентации?**

Да, Aspose.Slides позволяет программно добавить водяной знак на каждый слайд презентации. Вы можете пройтись по всем слайдам и применить настройки водяного знака по отдельности.

**Как отрегулировать прозрачность водяного знака?**

Прозрачность водяного знака регулируется изменением настроек заливки ([getFillFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getFillFormat)) формы. Это делает водяной знак ненавязчивым и не отвлекает внимание от содержимого слайда.

**Какие форматы изображений поддерживаются для водяных знаков?**

Aspose.Slides поддерживает различные форматы изображений, такие как PNG, JPEG, GIF, BMP, SVG и другие.

**Можно ли настроить шрифт и стиль текстового водяного знака?**

Да, вы можете выбрать любой шрифт, размер и стиль, соответствующие дизайну вашей презентации и поддерживающие единый стиль бренда.

**Как изменить позицию или ориентацию водяного знака?**

Позицию и ориентацию водяного знака можно изменить программно, изменив координаты, размер и свойства вращения формы.