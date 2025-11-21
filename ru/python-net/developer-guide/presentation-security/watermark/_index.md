---
title: Добавить водяные знаки в презентации на Python
linktitle: Водяной знак
type: docs
weight: 40
url: /ru/python-net/watermark/
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
- удалить водяной знак из PPTX
- удалить водяной знак из ODP
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как управлять текстовыми и графическими водяными знаками в презентациях PowerPoint и OpenDocument на Python, чтобы указать черновик, конфиденциальную информацию, авторские права и многое другое."
---

## **О водяных знаках**

**Водяной знак** в презентации — это текстовая или графическая метка, используемая на отдельном слайде или на всех слайдах презентации. Обычно водяной знак применяется, чтобы указать, что презентация является черновиком (например, водяной знак «Черновик»), содержит конфиденциальную информацию (например, «Конфиденциально»), обозначить принадлежность к компании (например, «Название компании»), идентифицировать автора презентации и т.д. Водяной знак помогает предотвратить нарушения авторских прав, показывая, что презентацию нельзя копировать. Водяные знаки используются как в форматах PowerPoint, так и в OpenOffice. В Aspose.Slides вы можете добавить водяной знак в файлы форматов PowerPoint PPT, PPTX и OpenOffice ODP.

В [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) существует несколько способов создания водяных знаков в документах PowerPoint или OpenOffice и их последующего изменения. Общий момент — для добавления текстовых водяных знаков следует использовать класс [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), а для добавления графических водяных знаков — класс [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) или заполнить форму водяного знака изображением. `PictureFrame` реализует класс [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), что позволяет использовать все гибкие настройки объекта формы. Поскольку `TextFrame` не является формой и его настройки ограничены, он оборачивается в объект [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).

Водяной знак можно применить двумя способами: к отдельному слайду или ко всем слайдам презентации. Для применения водяного знака ко всем слайдам используется мастер слайдов — водяной знак добавляется в мастер слайдов, полностью оформляется там и применяется ко всем слайдам без ограничения возможности изменения водяного знака на отдельных слайдах.

Водяной знак обычно считается недоступным для редактирования другими пользователями. Чтобы предотвратить редактирование водяного знака (а точнее его родительской формы), Aspose.Slides предоставляет функциональность блокировки форм. Конкретную форму можно заблокировать как на обычном слайде, так и на мастере слайдов. Когда форма водяного знака заблокирована на мастере слайдов, она будет заблокирована на всех слайдах презентации.

Вы можете задать имя водяному знаку, чтобы в дальнейшем, при необходимости удалить его, найти форму по имени в коллекции форм слайда.

Водяной знак можно оформить любой способ, однако обычно у него есть общие черты, такие как центрирование, вращение, положение спереди и т.п. Ниже рассмотрим, как использовать эти свойства в примерах.

## **Текстовый водяной знак**

### **Добавление текстового водяного знака на слайд**

Чтобы добавить текстовый водяной знак в PPT, PPTX или ODP, сначала добавьте форму на слайд, затем добавьте к этой форме текстовый фрейм. Текстовый фрейм представляет класс [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/). Этот тип не наследуется от [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), который обладает широким набором свойств для гибкого позиционирования водяного знака. Поэтому объект [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) оборачивается в объект [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). Чтобы добавить текст водяного знака в форму, используйте метод [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str), как показано ниже.
```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    slide = presentation.slides[0]

    watermark_shape = slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```


{{% alert color="primary" title="See also" %}} 
- [How to Use the TextFrame Class](/slides/ru/python-net/text-formatting/)
{{% /alert %}}

### **Добавление текстового водяного знака в презентацию**

Если нужно добавить текстовый водяной знак ко всей презентации (то есть сразу на все слайды), добавьте его в [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/). Остальная логика аналогична добавлению водяного знака на отдельный слайд — создайте объект [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) и затем добавьте к нему водяной знак с помощью метода [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str).
```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    master_slide = presentation.masters[0]

    watermark_shape = master_slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```


{{% alert color="primary" title="See also" %}} 
- [How to Use the Slide Master](/slides/ru/python-net/slide-master/)
{{% /alert %}}

### **Установка прозрачности формы водяного знака**

По умолчанию прямоугольная форма имеет цвета заливки и линии. Следующий код делает форму прозрачной.
```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```


### **Установка шрифта для текстового водяного знака**

Вы можете изменить шрифт текстового водяного знака, как показано ниже.
```py
text_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format
text_format.latin_font = FontData("Arial")
text_format.font_height = 50
```


### **Установка цвета текста водяного знака**

Чтобы задать цвет текста водяного знака, используйте следующий код:
```py
alpha = 150
red = 200
green = 200
blue = 200

fill_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format.fill_format
fill_format.fill_type = FillType.SOLID
fill_format.solid_fill_color.color = drawing.Color.from_argb(alpha, red, green, blue)
```


### **Центрирование текстового водяного знака**

Можно центрировать водяной знак на слайде, для чего выполните следующее:
```py
slide_size = presentation.slide_size.size

watermark_width = 400
watermark_height = 40
watermark_x = (slide_size.width - watermark_width) / 2
watermark_y = (slide_size.height - watermark_height) / 2

watermark_shape = slide.shapes.add_auto_shape(
    ShapeType.RECTANGLE, watermark_x, watermark_y, watermark_width, watermark_height)

watermark_frame = watermark_shape.add_text_frame(watermark_text)
```


Ниже показан итоговый результат.

![The text watermark](text_watermark.png)

## **Графический водяной знак**

### **Добавление графического водяного знака в презентацию**

Чтобы добавить графический водяной знак на слайд презентации, выполните следующее:
```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```


## **Блокировка водяного знака от редактирования**

Если необходимо запретить редактирование водяного знака, используйте свойство [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/) формы. С помощью этого свойства можно защитить форму от выбора, изменения размеров, перемещения, группировки с другими элементами, блокировать её текст от редактирования и многое другое:
```py
# Заблокировать форму водяного знака от изменения
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```


## **Перемещение водяного знака на передний план**

В Aspose.Slides порядок Z-слоёв форм можно задать методом [ShapeCollection.reorder](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/reorder/#int-ishape). Для этого вызовите метод из списка слайдов презентации, передав в него ссылку на форму и её порядковый номер. Таким образом можно переместить форму на передний план или отправить её назад. Эта возможность особенно полезна, если нужно разместить водяной знак перед содержимым презентации:
```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```


## **Установка вращения водяного знака**

Ниже пример кода, показывающий, как скорректировать вращение водяного знака, чтобы он располагался по диагонали слайда:
```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```


## **Задание имени водяному знаку**

Aspose.Slides позволяет задать имя форме. Используя имя формы, вы сможете в дальнейшем получить к ней доступ для изменения или удаления. Чтобы задать имя форме водяного знака, присвойте его свойству [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/):
```py
watermark_shape.name = "watermark"
```


## **Удаление водяного знака**

Чтобы удалить форму водяного знака, используйте метод [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) для её поиска в коллекции форм слайда. Затем передайте найденную форму в метод [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/#ishape):
```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```


## **Онлайн‑пример**

Вы можете опробовать бесплатные онлайн‑инструменты Aspose.Slides **Add Watermark**[https://products.aspose.app/slides/watermark] и **Remove Watermark**[https://products.aspose.app/slides/watermark/remove-watermark].

![Online tools to add and remove watermarks](online_tools.png)

## **FAQ**

**Что такое водяной знак и зачем он нужен?**

Водяной знак — это наложение текста или изображения на слайды, которое помогает защищать интеллектуальную собственность, усиливать узнаваемость бренда или предотвращать несанкционированное использование презентаций.

**Можно ли добавить водяной знак ко всем слайдам презентации?**

Да, Aspose.Slides позволяет добавить водяной знак на каждый слайд презентации. Вы можете пройтись по всем слайдам и применить настройки водяного знака индивидуально.

**Как изменить прозрачность водяного знака?**

Прозрачность водяного знака регулируется изменением настроек заливки ([FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/)) формы. Это позволяет делать знак ненавязчивым и не отвлекать внимание от содержимого слайда.

**Какие форматы изображений поддерживаются для водяных знаков?**

Aspose.Slides поддерживает различные форматы изображений, такие как PNG, JPEG, GIF, BMP, SVG и другие.

**Можно ли настроить шрифт и стиль текстового водяного знака?**

Да, вы можете выбрать любой шрифт, размер и стиль, чтобы они соответствовали дизайну вашей презентации и поддерживали согласованность бренда.

**Как изменить позицию или ориентацию водяного знака?**

Позицию и ориентацию водяного знака можно скорректировать, изменяя координаты, размер и свойства вращения [shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).