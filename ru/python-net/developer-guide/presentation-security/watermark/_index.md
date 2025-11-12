---
title: Добавление водяных знаков в презентации на Python
linktitle: Водяной знак
type: docs
weight: 40
url: /ru/python-net/watermark/
keywords:
- водяной знак
- текстовый водяной знак
- изображение водяного знака
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
description: "Узнайте, как управлять текстовыми и графическими водяными знаками в презентациях PowerPoint и OpenDocument с помощью Python, чтобы обозначить черновик, конфиденциальную информацию, авторские права и многое другое."
---

## **О водяных знаках**

**Водяной знак** в презентации — это текстовая или графическая метка, используемая на отдельном слайде или на всех слайдах презентации. Обычно водяной знак указывает, что презентация является черновиком (например, «Черновик»), содержит конфиденциальную информацию (например, «Конфиденциально»), принадлежит определённой компании (например, «Название компании»), идентифицирует автора презентации и т.д. Водяной знак помогает предотвратить нарушения авторских прав, указывая, что презентацию не следует копировать. Водяные знаки используются как в форматах PowerPoint, так и в форматах OpenOffice. В Aspose.Slides вы можете добавить водяной знак в файлы форматов PowerPoint PPT, PPTX и OpenOffice ODP.

В [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) существует несколько способов создания водяных знаков в документах PowerPoint или OpenOffice и изменения их дизайна и поведения. Общий момент: для добавления текстовых водяных знаков следует использовать класс [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), а для добавления графических водяных знаков — класс [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) или заполнить форму водяного знака изображением. `PictureFrame` реализует класс [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), что позволяет использовать все гибкие параметры объекта формы. Поскольку `TextFrame` не является формой и его настройки ограничены, он обернут в объект [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).

Водяной знак может применяться двумя способами: к отдельному слайду или ко всем слайдам презентации. Для применения водяного знака ко всем слайдам используется шаблон слайда (Slide Master) — водяной знак добавляется в шаблон слайда, полностью там оформляется и применяется ко всем слайдам без ограничения возможности редактировать его на отдельных слайдах.

Водяной знак обычно считается недоступным для редактирования другими пользователями. Чтобы предотвратить редактирование водяного знака (точнее, его родительской формы), Aspose.Slides предоставляет возможность блокировки формы. Конкретную форму можно заблокировать на обычном слайде или на шаблоне слайда. Когда форма водяного знака заблокирована на шаблоне слайда, она будет заблокирована на всех слайдах презентации.

Вы можете задать имя водяного знака, чтобы в дальнейшем, при необходимости удаления, находить его среди форм слайда по имени.

Водяной знак можно оформить любым способом; однако обычно водяные знаки имеют общие характеристики, такие как центрирование, вращение, расположение спереди и т.д. Ниже мы рассмотрим, как использовать эти возможности в примерах.

## **Текстовый водяной знак**

### **Добавление текстового водяного знака на слайд**

Чтобы добавить текстовый водяной знак в PPT, PPTX или ODP, сначала добавьте форму на слайд, а затем добавьте в эту форму текстовый фрейм. Текстовый фрейм представлен классом [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/). Этот тип не наследуется от [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), который имеет широкий набор свойств для гибкого позиционирования водяного знака. Поэтому объект [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) оборачивается в объект [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). Чтобы добавить текст водяного знака в форму, используйте метод [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str), как показано ниже.

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    slide = presentation.slides[0]

    watermark_shape = slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="Смотрите также" %}} 
- [Как использовать класс TextFrame](/slides/ru/python-net/text-formatting/)
{{% /alert %}}

### **Добавление текстового водяного знака в презентацию**

Если требуется добавить текстовый водяной знак во всю презентацию (т.е. на все слайды сразу), добавьте его в [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/). Остальная логика такая же, как при добавлении водяного знака на отдельный слайд — создайте объект [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) и затем добавьте в него водяной знак с помощью метода [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str).

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    master_slide = presentation.masters[0]

    watermark_shape = master_slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="Смотрите также" %}} 
- [Как использовать шаблон слайда](/slides/ru/python-net/slide-master/)
{{% /alert %}}

### **Установка прозрачности формы водяного знака**

По умолчанию прямоугольная форма имеет заливку и цвет контура. Следующие строки кода делают форму прозрачной.

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

Водяной знак можно центрировать на слайде, для этого выполните следующее:

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

Ниже показан окончательный результат.

![Текстовый водяной знак](text_watermark.png)

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

Если необходимо предотвратить редактирование водяного знака, используйте свойство [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/) формы. С его помощью можно защитить форму от выбора, изменения размера, перемещения, группировки с другими элементами, блокировать её текст от редактирования и многое другое:

```py
# Заблокировать форму водяного знака от изменения
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **Перемещение водяного знака на передний план**

В Aspose.Slides порядок Z-слоёв форм можно задать с помощью метода [ShapeCollection.reorder](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/reorder/#int-ishape). Для этого вызовите метод из списка слайдов презентации, передав в него ссылку на форму и её номер порядка. Так можно перенести форму на передний план или отправить её на задний план. Эта функция особенно полезна, если нужно разместить водяной знак спереди презентации:

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **Установка вращения водяного знака**

Ниже пример кода, показывающий, как скорректировать вращение водяного знака, чтобы он находился по диагонали слайда:

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **Задание имени водяного знака**

Aspose.Slides позволяет задать имя формы. По имени формы в дальнейшем её можно найти для изменения или удаления. Чтобы задать имя формы водяного знака, присвойте его свойству [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/):

```py
watermark_shape.name = "watermark"
```

## **Удаление водяного знака**

Чтобы удалить форму водяного знака, используйте метод [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) для поиска её среди форм слайда. Затем передайте найденную форму в метод [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/#ishape):

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **Рабочий пример**

Вы можете опробовать бесплатные онлайн‑инструменты Aspose.Slides **Add Watermark** и **Remove Watermark**:

![Онлайн‑инструменты для добавления и удаления водяных знаков](online_tools.png)

## **FAQ**

**Что такое водяной знак и зачем он нужен?**

Водяной знак — это текстовое или графическое наложение на слайды, которое помогает защищать интеллектуальную собственность, усиливать узнаваемость бренда или предотвращать несанкционированное использование презентаций.

**Можно ли добавить водяной знак ко всем слайдам презентации?**

Да, Aspose.Slides позволяет добавить водяной знак на каждый слайд презентации. Вы можете пройтись по всем слайдам и применить настройки водяного знака индивидуально.

**Как отрегулировать прозрачность водяного знака?**

Прозрачность водяного знака регулируется изменением параметров заливки ([FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/)) формы. Это обеспечивает лёгкое и ненавязчивое отображение водяного знака.

**Какие форматы изображений поддерживаются для водяных знаков?**

Aspose.Slides поддерживает различные форматы изображений, такие как PNG, JPEG, GIF, BMP, SVG и др.

**Можно ли настроить шрифт и стиль текстового водяного знака?**

Да, вы можете выбрать любой шрифт, размер и стиль, чтобы он соответствовал дизайну вашей презентации и сохранял фирменный стиль.

**Как изменить позицию или ориентацию водяного знака?**

Позицию и ориентацию водяного знака можно скорректировать, изменяя координаты, размер и свойства вращения [shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).