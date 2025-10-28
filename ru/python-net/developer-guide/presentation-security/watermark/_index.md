---
title: Добавить водяные знаки к презентациям на Python
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
description: "Узнайте, как управлять текстовыми и графическими водяными знаками в презентациях PowerPoint и OpenDocument на Python, чтобы обозначать черновик, конфиденциальную информацию, авторские права и многое другое."
---

## **О водяных знаках**

**Водяной знак** в презентации — это текстовая или графическая печать, использующаяся на слайде или во всех слайдах презентации. Обычно водяной знак применяют, чтобы указать, что презентация является черновиком (например, «Черновик»), содержит конфиденциальную информацию (например, «Конфиденциально»), принадлежит определённой компании (например, «Название компании»), идентифицировать автора презентации и т.д. Водяной знак помогает предотвратить нарушения авторских прав, указывая, что копировать презентацию нельзя. Водяные знаки поддерживаются в форматах PowerPoint и OpenOffice. В Aspose.Slides вы можете добавить водяной знак в файлы PPT, PPTX и ODP.

В [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) есть несколько способов создания водяных знаков в документах PowerPoint или OpenOffice и изменения их дизайна и поведения. Общий момент — для добавления текстовых водяных знаков следует использовать класс [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), а для графических — класс [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) или заполнить форму водяного знака изображением. `PictureFrame` реализует класс [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), позволяя использовать все гибкие параметры объекта формы. Поскольку `TextFrame` не является формой и имеет ограниченный набор настроек, его оборачивают в объект [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).

Водяной знак может быть применён двумя способами: к отдельному слайду или ко всем слайдам презентации. Для применения водяного знака ко всем слайдам используется мастер‑слайд — водяной знак добавляется в мастер‑слайд, полностью оформляется там и распространяется на все слайды, не ограничивая возможность изменения знака на отдельных слайдах.

Обычно считается, что водяной знак недоступен для редактирования другими пользователями. Чтобы запретить редактирование (а точнее — редактирование родительской формы водяного знака), Aspose.Slides предоставляет возможность блокировки формы. Конкретную форму можно заблокировать как на обычном слайде, так и на мастере‑слайде. Когда форма водяного знака заблокирована в мастере‑слайде, она будет заблокирована на всех слайдах презентации.

Вы можете задать имя для водяного знака, чтобы в дальнейшем, при желании удалить его, найти форму по имени в списке форм слайда.

Форма водяного знака может быть оформлена произвольно; однако обычно у водяных знаков есть общие черты — центрирование, поворот, размещение на переднем плане и т.п. Ниже показано, как использовать эти возможности в примерах.

## **Текстовый водяной знак**

### **Добавление текстового водяного знака на слайд**

Чтобы добавить текстовый водяной знак в PPT, PPTX или ODP, сначала добавьте форму на слайд, затем добавьте в эту форму текстовый фрейм. Текстовый фрейм представлен классом [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/). Этот тип не наследуется от [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), который предоставляет широкий набор свойств для гибкого позиционирования водяного знака. Поэтому объект [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) оборачивается в объект [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). Чтобы добавить текст водяного знака в форму, используйте метод [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str) как показано ниже.

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

Если нужно добавить текстовый водяной знак во всю презентацию (т.е. сразу на все слайды), добавьте его в [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/). Остальная логика совпадает с добавлением знака на отдельный слайд — создайте объект [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) и затем добавьте в него водяной знак с помощью метода [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str).

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    master_slide = presentation.masters[0]

    watermark_shape = master_slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="См. также" %}} 
- [Как использовать мастер‑слайд](/slides/ru/python-net/slide-master/)
{{% /alert %}}

### **Установка прозрачности формы водяного знака**

По умолчанию прямоугольная форма заполнена цветом и имеет цвет линии. Следующие строки кода делают форму прозрачной.

```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```

### **Установка шрифта для текстового водяного знака**

Шрифт текстового водяного знака можно изменить так:

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

Для центрирования водяного знака на слайде выполните следующее:

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

Если необходимо запретить редактирование водяного знака, используйте свойство [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/) формы. С его помощью можно запретить выделение, изменение размера, перемещение, группировку, редактирование текста и многое другое:

```py
# Блокировать форму водяного знака от изменения
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **Перемещение водяного знака на передний план**

В Aspose.Slides порядок наложения форм задаётся методом [ShapeCollection.reorder](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/reorder/#int-ishape). Для этого вызовите метод из списка слайдов презентации, передав ссылку на форму и её новый порядковый номер. Таким образом можно переместить форму на передний план либо отправить её назад. Эта возможность особенно полезна, когда нужно разместить водяной знак поверх остальных элементов презентации:

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **Установка поворота водяного знака**

Пример кода, показывающий, как настроить поворот водяного знака, чтобы он располагался по диагонали слайда:

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **Задание имени водяному знаку**

Aspose.Slides позволяет задать имя форме. По имени формы в дальнейшем её можно найти для изменения или удаления. Чтобы задать имя форме водяного знака, присвойте его свойству [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/):

```py
watermark_shape.name = "watermark"
```

## **Удаление водяного знака**

Для удаления формы водяного знака используйте метод [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) для поиска её среди форм слайда. Затем передайте найденную форму в метод [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/#ishape):

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **Онлайн‑пример**

Вы можете опробовать бесплатные онлайн‑инструменты Aspose.Slides **Add Watermark**[https://products.aspose.app/slides/watermark] и **Remove Watermark**[https://products.aspose.app/slides/watermark/remove-watermark].

![Онлайн‑инструменты для добавления и удаления водяных знаков](online_tools.png)

## **FAQ**

**Что такое водяной знак и зачем он нужен?**

Водяной знак — это наложенный на слайды текст или изображение, помогающие защитить интеллектуальную собственность, усилить узнаваемость бренда или предотвратить несанкционированное использование презентаций.

**Можно ли добавить водяной знак ко всем слайдам презентации?**

Да, Aspose.Slides позволяет добавить водяной знак ко всем слайдам презентации. Можно пройтись по каждому слайду и применить настройки знака индивидуально.

**Как изменить прозрачность водяного знака?**

Прозрачность регулируется настройками заливки ([FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/)) формы. Это делает знак едва заметным и не отвлекающим от содержимого слайда.

**Какие форматы изображений поддерживаются для водяных знаков?**

Aspose.Slides поддерживает PNG, JPEG, GIF, BMP, SVG и другие форматы.

**Можно ли настроить шрифт и стиль текстового водяного знака?**

Да, вы можете выбрать любой шрифт, размер и стиль, соответствующие дизайну вашей презентации и брендбуку.

**Как изменить позицию или ориентацию водяного знака?**

Позицию и ориентацию можно изменить, задав новые координаты, размер и угол поворота у формы ([shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)).