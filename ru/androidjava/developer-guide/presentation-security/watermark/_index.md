---
title: Водяной знак
type: docs
weight: 40
url: /androidjava/watermark/
keywords: "водяной знак в презентации"
description: "Используйте водяной знак в PowerPoint с Aspose.Slides. Добавьте водяной знак в ppt-презентацию или удалите водяной знак. Вставьте изображение водяного знака или текстовый водяной знак."
---

## **О водяном знаке**
**Водяной знак** в презентации — это текстовая или изображенческая метка, используемая на слайде или всех слайдах презентации. Обычно водяной знак используется для обозначения того, что презентация является черновиком (например, водяной знак "Черновик"); что она содержит конфиденциальную информацию (например, водяной знак "Конфиденциально"); указывает, к какой компании она принадлежит (например, водяной знак с "Название компании"); идентифицирует автора презентации и т.д. Водяной знак помогает предотвратить нарушение авторских прав на презентацию, указывая, что презентацию нельзя копировать. Водяные знаки используются как с форматами презентаций PowerPoint, так и OpenOffice. В Aspose.Slides вы можете добавить водяной знак в форматы файлов PowerPoint PPT, PPTX и OpenOffice ODP.

В [**Aspose.Slides**](https://products.aspose.com/slides/androidjava/) есть различные способы создания водяного знака в PowerPoint или OpenOffice, оборачивания его в разные формы, изменения дизайна и поведения и т.д. Общее в том, что для добавления текстовых водяных знаков вам следует использовать класс [**TextFrame**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame), а для добавления графического водяного знака — [**PictureFrame**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PictureFrame/). [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PictureFrame/) реализует интерфейс [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) и может использовать все возможности гибкой настройки объекта формы. [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) не является формой, и его параметры ограничены. Поэтому рекомендуется обернуть объект [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) в объект [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape).

Существует два способа применения водяного знака: к одному слайду и ко всем слайдам презентации. Слайд Мастера используется для применения водяного знака ко всем слайдам презентации — водяной знак добавляется в Слайд Мастера, полностью оформляется там и применяется ко всем слайдам без изменения разрешения на изменение водяных знаков на слайдах.

Водяной знак обычно считается недоступным для редактирования другими пользователями. Для предотвращения редактирования водяного знака (или, скорее, родительской формы водяного знака) Aspose.Slides предоставляет функциональность блокировки формы. Определённая форма может быть заблокирована как на обычном слайде, так и на слайде Мастера. При блокировке формы водяного знака на Слайде Мастере она будет заблокирована на всех слайдах презентации.

Вы можете задать название водяного знака, так что в будущем, если вы захотите удалить водяной знак, вы сможете найти его в формах слайда по имени.

Вы можете оформить водяной знак любым способом, однако обычно у водяных знаков есть общие характеристики, такие как: центрирование, вращение, передний план и т.д. Мы рассмотрим, как использовать их в примерах ниже.
## **Текстовый водяной знак**
### **Добавить текстовый водяной знак на слайд**
Чтобы добавить текстовый водяной знак в PPT, PPTX или ODP, вы можете сначала добавить форму на слайд, а затем добавить текстовую рамку в эту форму. Текстовая рамка представлена типом [**TextFrame**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame). Этот тип не наследуется от [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape), который имеет широкий набор свойств для гибкой установки водяного знака. Поэтому рекомендуется обернуть объект [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) в объект [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape). Чтобы добавить водяной знак в форму, используйте метод [**addTextFrame**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-) с текстом водяного знака, переданным в него:

```java
// Открыть презентацию
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 0, 0, 0, 0);

    ITextFrame watermarkTextFrame = watermarkShape.addTextFrame("Водяной знак");
    
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert color="primary" title="Смотрите также" %}} 
- [Как использовать ](/slides/androidjava/slide-master/)[TextFrame](/slides/androidjava/adding-and-formatting-text/)
{{% /alert %}}

### **Добавить текстовый водяной знак в презентацию**
Если вы хотите добавить водяной знак в презентацию (то есть ко всем слайдам сразу), добавьте его в [**MasterSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MasterSlide). Вся другая логика такая же, как и при добавлении водяного знака на один слайд — создайте объект [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) и затем добавьте водяной знак в него с помощью метода [**addTextFrame**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-):

```java
// Открыть презентацию
Presentation pres = new Presentation();
try {
    IMasterSlide master = pres.getMasters().get_Item(0);

    IAutoShape watermarkShape = master.getShapes().addAutoShape(ShapeType.Triangle, 0, 0, 0, 0);

    ITextFrame watermarkTextFrame = watermarkShape.addTextFrame("Водяной знак");

} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" title="Смотрите также" %}} 
- [Как использовать ](/slides/androidjava/slide-master/)[Слайд Мастера](/slides/androidjava/slide-master/)
{{% /alert %}}

### **Установить шрифт текстового водяного знака**
Вы можете изменить шрифт текстового водяного знака:

```java
IPortion watermarkPortion = watermarkTextFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);

watermarkPortion.getPortionFormat().setFontBold(NullableBool.True);

watermarkPortion.getPortionFormat().setFontHeight(52);
```

### **Установить прозрачность текстового водяного знака**
Чтобы установить прозрачность текстового водяного знака, используйте этот код:

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IPortion watermarkPortion = watermarkTextFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);

watermarkPortion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);

watermarkPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(red, green, blue, alpha));
```

### **Центрировать текстовый водяной знак**
Можно центрировать водяной знак на слайде, и для этого вы можете сделать следующее:

```java
Point2D.Float center = new Point2D.Float((float)  pres.getSlideSize().getSize().getWidth() / 2, (float) pres.getSlideSize().getSize().getHeight() / 2);

float width = 300;

float height = 300;

float x = (float) center.getX() - width / 2;

float y = (float) center.getY() - height / 2;

//...


IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Triangle, x, y, width, height);
```

## **Изображение водяного знака**
### **Добавить изображение водяного знака в презентацию**
Чтобы добавить изображение водяного знака на все слайды презентации, вы можете сделать следующее:

```java
IPPImage picture;
IImage image = Images.fromFile("watermark.png");
try {
    picture = pres.getImages().addImage(image);
} finally {
    if (image != null) image.dispose();
}
// ...


watermarkShape.getFillFormat().setFillType(FillType.Picture);

watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

## **Заблокировать водяной знак от редактирования**
Если необходимо предотвратить редактирование водяного знака, используйте метод [**AutoShape.getShapeLock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape#getShapeLock--) на форме, которая его оборачивает. С помощью этого метода вы можете защитить форму от выбора, изменения размера, изменения позиции, группировки с другими элементами, заблокировать текст от редактирования и многое другое:

```java
// Заблокировать формы от изменения

watermarkShape.getShapeLock().setSelectLocked(true);

watermarkShape.getShapeLock().setSizeLocked(true);

watermarkShape.getShapeLock().setTextLocked(true);

watermarkShape.getShapeLock().setPositionLocked(true);

watermarkShape.getShapeLock().setGroupingLocked(true);
```

{{% alert color="primary" title="Смотрите также" %}} 
- [Как заблокировать формы от редактирования](/slides/androidjava/presentation-locking/)
{{% /alert %}}

## **Вывести водяной знак вперед**
В Aspose.Slides порядок Z-форм можно установить через метод [**SlideCollection.reorder**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideCollection#reorder-int-com.aspose.slides.ISlide...-). Для этого вам нужно вызвать этот метод из списка слайдов презентации и передать ссылку на форму и ее номер в порядке. Таким образом, можно поместить форму впереди или позади слайда. Эта функция особенно полезна, если вам нужно поставить водяной знак перед презентацией:

```java
slide.getShapes().reorder(slide.getShapes().size() - 1, watermarkShape);
```

## **Установить вращение водяного знака**
Вот пример, как установить вращение водяного знака (и его родительской формы):

```java
float h = (float) pres.getSlideSize().getSize().getHeight();

float w = (float) pres.getSlideSize().getSize().getWidth();

watermarkShape.setX((w - watermarkShape.getWidth()) / 2);

watermarkShape.setY((h - watermarkShape.getHeight()) / 2);

watermarkShape.setRotation(calculateRotation(h, w));
```

```java
private int calculateRotation(float height, float width)
{
    double pageHeight = height;
    
    double pageWidth = width;
    
    double rotation = Math.atan((pageHeight / pageWidth)) * 180 / Math.PI;
    
    return (int) rotation;
}
```

## **Задать имя водяного знака**
Aspose.Slides позволяет задать имя формы. По имени формы вы можете получить к ней доступ в будущем, чтобы изменить или удалить. Чтобы задать имя родительской формы водяного знака — установите его в метод [**AutoShape.getName**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getName--) :

```java
watermarkShape.setName("водяной знак");
```

## **Удалить водяной знак**
Для удаления формы водяного знака и ее дочерних элементов из слайда используйте метод [AutoShape.getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getName--) для поиска ее в формах слайда. Затем передайте форму водяного знака в метод [**ShapeCollection.remove**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeCollection#remove-com.aspose.slides.IShape-) :

```java
for (int i = 0; i < slide.getShapes().size(); i++)
{
    AutoShape shape = (AutoShape)slide.getShapes().get_Item(i);

    if ("водяной знак".equals(shape.getName()))
    {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **Пример в реальном времени**
Вы можете проверить **Aspose.Slides** **бесплатные** [**Добавить водяной знак** ](https://products.aspose.app/slides/watermark) и [**Удалить водяной знак**](https://products.aspose.app/slides/watermark/remove-watermark) онлайн инструменты. 

![todo:image_alt_text](slides-watermark.png)