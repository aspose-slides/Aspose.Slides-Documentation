---
title: Добавляйте водяные знаки в презентации на Python
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
- удаление водяного знака из PPT
- удаление водяного знака из PPTX
- удаление водяного знака из ODP
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как управлять текстовыми и графическими водяными знаками в презентациях PowerPoint и OpenDocument на Python, чтобы помечать черновики, конфиденциальную информацию, авторские права и многое другое."
---

## **О водяном знаке**
**Водяной знак** в презентации — это текстовая или изображенческая метка, используемая на слайде или на всех слайдах презентации. Обычно водяной знак используется, чтобы указать, что презентация является черновиком (например, водяной знак "Черновик"); что она содержит конфиденциальную информацию (например, водяной знак "Конфиденциально"); для указания, к какой компании она принадлежит (например, водяной знак "Название компании"); идентифицировать автора презентации и т. д. Водяной знак помогает предотвратить нарушение авторских прав на презентацию, указывая, что презентацию нельзя копировать. Водяные знаки используются как в формате PowerPoint, так и в формате OpenOffice. В Aspose.Slides вы можете добавить водяной знак в форматы файлов PowerPoint PPT, PPTX и OpenOffice ODP.

В [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) существует несколько способов создать водяной знак в PowerPoint или OpenOffice, обернуть его в различные формы, изменить дизайн и поведение и т. д. Общим является то, что для добавления текстовых водяных знаков вы должны использовать класс [**TextFrame**](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), а для добавления изображений водяного знака - [**PictureFrame**](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/). PictureFrame реализует интерфейс [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) и может использовать всю мощь гибких настроек объекта формы. TextFrame не является формой, и его настройки ограничены. Поэтому рекомендуется обернуть TextFrame в объект [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/).

Существует два способа применения водяного знака: к одному слайду и ко всем слайдам презентации. Главный слайд используется для применения водяного знака ко всем слайдам презентации - водяной знак добавляется в главный слайд, полностью оформляется там и применяется ко всем слайдам без изменения разрешения на модификацию водяного знака на слайдах.

Водяной знак обычно считается недоступным для редактирования другими пользователями. Чтобы предотвратить редактирование водяного знака (или, точнее, родительской формы водяного знака), Aspose.Slides предоставляет функциональность блокировки формы. Определенная форма может быть заблокирована на обычном слайде или на главном слайде. При блокировке формы водяного знака на главном слайде - она будет заблокирована на всех слайдах презентации.

Вы можете установить имя водяного знака, чтобы в будущем, если вы захотите удалить водяной знак, вы могли найти его на форме слайда по имени.

Вы можете оформить водяной знак любым образом, однако обычно существуют общие характеристики водяных знаков, такие как: центрирование, вращение, положение спереди и т. д. Мы рассмотрим, как использовать их в примерах ниже.
## **Текстовый водяной знак**
### **Добавить текстовый водяной знак на слайд**
Чтобы добавить текстовый водяной знак в PPT, PPTX или ODP, вы можете сначала добавить форму на слайд, затем добавить текстовую рамку в эту форму. Текстовая рамка представлена типом [**TextFrame**](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/). Этот тип не наследуется от [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/), который имеет широкий набор свойств для установки водяного знака гибким образом. Поэтому рекомендуется обернуть объект [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) в объект [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/). Чтобы добавить водяной знак в форму, используйте метод [**add_text_frame**](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) с переданным текстом водяного знака:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    watermarkShape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 0, 0, 0, 0)
    watermarkTextFrame = watermarkShape.add_text_frame("Водяной знак")
    presentation.save("watermark-1.pptx", slides.export.SaveFormat.PPTX)

```



{{% alert color="primary" title="См. также" %}} 
- [Как использовать ](/slides/ru/python-net/slide-master/)[TextFrame](/slides/ru/python-net/adding-and-formatting-text/)
{{% /alert %}}

### **Добавить текстовый водяной знак в презентацию**
Если вы хотите добавить водяной знак в презентацию (то есть, все слайды сразу), добавьте его в [**MasterSlide**](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/). Вся другая логика такая же, как и при добавлении водяного знака на один слайд - создайте объект [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) и затем добавьте водяной знак в него с помощью метода [**add_text_frame**](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/):

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    master = pres.masters[0]
    watermarkShape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 0, 0, 0, 0)
    watermarkTextFrame = watermarkShape.add_text_frame("Водяной знак")
    presentation.save("watermark-2.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert color="primary" title="См. также" %}} 
- [Как использовать ](/slides/ru/python-net/slide-master/)[Главный слайд](/slides/ru/python-net/slide-master/)
{{% /alert %}}

### **Установить шрифт текстового водяного знака**
Вы можете изменить шрифт текстового водяного знака:

```py
watermarkPortion = watermarkTextFrame.paragraphs[0].portions[0]
watermarkPortion.portion_format.font_height = 52
```


### **Установить прозрачность текстового водяного знака**
Чтобы установить прозрачность текстового водяного знака, используйте этот код:

```py
watermarkPortion = watermarkTextFrame.paragraphs[0].portions[0]
watermarkPortion.portion_format.fill_format.fill_type = slides.FillType.SOLID
watermarkPortion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(150, 200, 200, 200)
```


### **Центрировать текстовый водяной знак**
Можно центрировать водяной знак на слайде, и для этого вы можете сделать следующее:



```py
center = draw.PointF(presentation.slide_size.size.width / 2, presentation.slide_size.size.height / 2)

width = 300
height = 300

x = center.x - width / 2
y = center.y - height / 2

# ... код ...
watermarkShape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, x, y, width, height)
```


## **Изображенческий водяной знак**
### **Добавить изображенческий водяной знак в презентацию**
Чтобы добавить изображенческий водяной знак во все слайды презентации, вы можете сделать следующее:

```py
with slides.Presentation() as presentation:
    with open("image.png", "rb") as fs:
        data = fs.read()
        image = presentation.images.add_image(data)

# ...

watermarkShape.fill_format.fill_type = slides.FillType.PICTURE
watermarkShape.fill_format.picture_fill_format.picture.image = image
watermarkShape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
```




## **Заблокировать водяной знак от редактирования**
Если необходимо предотвратить редактирование водяного знака, используйте свойство [**AutoShape.shape_lock**](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на форме, которая его оборачивает. С помощью этого свойства вы можете защитить форму от выбора, изменения размера, изменения положения, группировки с другими элементами, заблокировать его текст от редактирования и многое другое:

```py
# Заблокировать формы от изменения
watermarkShape.shape_lock.select_locked = True
watermarkShape.shape_lock.size_locked = True
watermarkShape.shape_lock.text_locked = True
watermarkShape.shape_lock.position_locked = True
watermarkShape.shape_lock.grouping_locked = True
```



{{% alert color="primary" title="См. также" %}} 
- [Как заблокировать формы от редактирования](/slides/ru/python-net/presentation-locking/)
{{% /alert %}}

## **Перенести водяной знак на передний план**
В Aspose.Slides порядок Z форм можно установить с помощью метода [**reorder**](https://reference.aspose.com/slides/python-net/aspose.slides.slidecollection/). Для этого вам нужно вызвать этот метод из списка слайдов презентации и передать ссылку на форму и ее номер порядка в метод. Таким образом, возможно разместить форму на переднем плане или на заднем плане слайда. Эта функция особенно полезна, если вам нужно поместить водяной знак на передний план презентации:

```py
slide.shapes.reorder(len(slide.shapes) - 1, watermarkShape)
```


## **Установить вращение водяного знака**
Вот пример того, как установить вращение водяного знака (и его родительской формы):

```py
def calculate_rotation(height, width):
	rotation = math.atan(height / width) * 180 / math.pi
	return rotation

h = presentation.slide_size.size.height
w = presentation.slide_size.size.width

watermarkShape.x = (w - watermarkShape.width) / 2
watermarkShape.y = (h - watermarkShape.height) / 2
watermarkShape.rotation = calculate_rotation(h, w)
```


## **Установить имя для водяного знака**
Aspose.Slides позволяет установить имя формы. По имени формы вы можете получить к ней доступ в будущем для модификации или удаления. Чтобы установить имя родительской формы водяного знака - установите его в свойство [**name**](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/):



```py
watermarkShape.name = "водяной знак"
```


## **Удалить водяной знак**
Чтобы удалить форму водяного знака и ее дочерние элементы с слайда, используйте свойство [name](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) для поиска его на формах слайда. Затем передайте форму водяного знака в метод [**remove**](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/):

```py
for i in range(len(slide.shapes)):
    shape = slide.shapes[i]

    if shape.name == "водяной знак":
        slide.shapes.remove(shape)
```


## **Пример в реальном времени**
Вы можете ознакомиться с **Aspose.Slides** **бесплатными** [**Добавить водяной знак**](https://products.aspose.app/slides/watermark) и [**Удалить водяной знак**](https://products.aspose.app/slides/watermark/remove-watermark) онлайн инструментами. 

![todo:image_alt_text](slides-watermark.png)