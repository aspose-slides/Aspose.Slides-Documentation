---
title: Add Watermarks to Presentations in Python
linktitle: Watermark
type: docs
weight: 40
url: /ru/python-net/developer-guide/presentation-security/watermark/
keywords:
- watermark
- text watermark
- image watermark
- add watermark
- change watermark
- remove watermark
- delete watermark
- add watermark to PPT
- add watermark to PPTX
- add watermark to ODP
- remove watermark from PPT
- remove watermark from PPTX
- remove watermark from ODP
- delete watermark from PPT
- delete watermark from PPTX
- delete watermark from ODP
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Learn how to manage text and image watermarks in PowerPoint and OpenDocument presentations in Python to indicate a draft, confidential information, copyright, and more."
---

## **О водяных знаках**

**Водяной знак** в презентации — это текстовый или графический штамп, используемый на отдельном слайде или на всех слайдах презентации. Обычно водяной знак применяется, чтобы указать, что презентация является черновиком (например, водяной знак «Черновик»), содержит конфиденциальную информацию (например, «Конфиденциально»), принадлежит определённой компании (например, «Название компании»), идентифицировать автора презентации и т.д. Водяной знак помогает предотвратить нарушения авторских прав, указывая, что презентацию не следует копировать. Водяные знаки используются как в форматах PowerPoint, так и в OpenOffice. В Aspose.Slides вы можете добавить водяной знак в файлы PowerPoint PPT, PPTX и OpenOffice ODP.

В [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) существует несколько способов создания водяных знаков в документах PowerPoint или OpenOffice и изменения их дизайна и поведения. Общий момент — для добавления текстовых водяных знаков следует использовать класс [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), а для добавления графических — класс [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) или заполнить форму водяного знака изображением. `PictureFrame` реализует класс [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), что позволяет использовать все гибкие настройки объекта формы. Поскольку `TextFrame` не является формой и его параметры ограничены, он оборачивается в объект [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).

Существует два способа применения водяного знака: к отдельному слайду или ко всем слайдам презентации. Для применения водяного знака ко всем слайдам используется Slide Master — водяной знак добавляется в Slide Master, полностью настраивается там и применяется ко всем слайдам, не влияя на возможность изменения водяного знака на отдельных слайдах.

Обычно считается, что водяной знак недоступен для редактирования другими пользователями. Чтобы предотвратить редактирование водяного знака (точнее, его родительской формы), Aspose.Slides предоставляет возможность блокировки формы. Конкретную форму можно заблокировать как на обычном слайде, так и на Slide Master. Когда форма водяного знака заблокирована на Slide Master, она будет заблокирована на всех слайдах презентации.

Можно задать имя водяного знака, чтобы в дальнейшем, при необходимости удалить его, найти его среди форм слайда по имени.

Водяной знак можно оформить любым образом; однако обычно у водяных знаков есть общие черты: выравнивание по центру, поворот, положение спереди и т.д. Мы рассмотрим, как использовать эти возможности в примерах ниже.

## **Текстовый водяной знак**

### **Добавление текстового водяного знака на слайд**

Чтобы добавить текстовый водяной знак в PPT, PPTX или ODP, сначала можно добавить форму на слайд, а затем добавить в эту форму текстовый фрейм. Текстовый фрейм представлен классом [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/). Этот тип не наследуется от [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), который предоставляет широкий набор свойств для гибкого позиционирования водяного знака. Поэтому объект [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) оборачивается в объект [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). Чтобы добавить текст водяного знака в форму, используйте метод [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str), как показано ниже.

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    slide = presentation.slides[0]

    watermark_shape = slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="См. также" %}} 
- [Как использовать класс TextFrame](/slides/ru/python-net/text-formatting/)
{{% /alert %}}

### **Добавление текстового водяного знака в презентацию**

Если необходимо добавить текстовый водяной знак ко всей презентации (т.e. сразу на все слайды), добавьте его в [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/). Дальнейшая логика такая же, как при добавлении водяного знака на отдельный слайд — создайте объект [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) и затем добавьте в него водяной знак с помощью метода [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str).

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    master_slide = presentation.masters[0]

    watermark_shape = master_slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="См. также" %}} 
- [Как использовать Slide Master](/slides/ru/python-net/slide-master/)
{{% /alert %}}

### **Установка прозрачности формы водяного знака**

По умолчанию прямоугольная форма имеет цвет заливки и линий. Следующие строки кода делают форму прозрачной.

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

Если необходимо запретить редактирование водяного знака, используйте свойство [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/) формы. С помощью этого свойства можно защитить форму от выбора, изменения размера, перемещения, группировки с другими элементами, блокировать её текст от редактирования и многое другое:

```py
# Блокировать форму водяного знака от изменений
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **Перемещение водяного знака на передний план**

В Aspose.Slides порядок Z-слоёв форм можно задать методом [ShapeCollection.reorder](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/reorder/#int-ishape). Для этого вызовите метод из списка слайдов презентации, передав в него ссылку на форму и её порядковый номер. Таким образом можно переместить форму на передний план или отправить её на задний план слайда. Эта возможность особенно полезна, когда нужно разместить водяной знак спереди презентации:

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **Установка поворота водяного знака**

Ниже пример кода, показывающего, как задать поворот водяного знака, чтобы он располагался по диагонали слайда:

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **Задание имени водяному знаку**

Aspose.Slides позволяет задать имя формы. Используя имя формы, вы сможете в дальнейшем получить к ней доступ для изменения или удаления. Чтобы задать имя формы водяного знака, присвойте его свойству [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/):

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

Вы можете протестировать бесплатные онлайн‑инструменты Aspose.Slides : [Add Watermark](https://products.aspose.app/slides/watermark) и [Remove Watermark](https://products.aspose.app/slides/watermark/remove-watermark).

![Онлайн‑инструменты для добавления и удаления водяных знаков](online_tools.png)

## **FAQ**

**Что такое водяной знак и зачем его использовать?**

Водяной знак — текстовое или графическое наложение на слайды, которое помогает защитить интеллектуальную собственность, укрепить узнаваемость бренда или предотвратить несанкционированное использование презентаций.

**Можно ли добавить водяной знак на все слайды презентации?**

Да, Aspose.Slides позволяет добавить водяной знак ко всем слайдам презентации. Вы можете перебрать все слайды и применить настройки водяного знака к каждому из них.

**Как отрегулировать прозрачность водяного знака?**

Прозрачность водяного знака можно изменить, изменив настройки заливки ([FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/)) формы. Это делает водяной знак ненавязчивым и не отвлекает от основного содержания слайда.

**Какие форматы изображений поддерживаются для водяных знаков?**

Aspose.Slides поддерживает различные форматы изображений, такие как PNG, JPEG, GIF, BMP, SVG и другие.

**Можно ли настроить шрифт и стиль текстового водяного знака?**

Да, вы можете выбрать любой шрифт, размер и стиль, чтобы они соответствовали дизайну вашей презентации и поддерживали согласованность бренда.

**Как изменить позицию или ориентацию водяного знака?**

Вы можете скорректировать позицию и ориентацию водяного знака, изменив координаты, размеры и свойства поворота [shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).