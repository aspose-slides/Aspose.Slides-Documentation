---
title: Водяной знак
type: docs
weight: 40
url: /java/watermark/
keywords: "водяной знак в презентации"
description: "Используйте водяной знак в PowerPoint с Aspose.Slides. Добавьте водяной знак в ppt-презентацию или удалите водяной знак. Вставьте изображение водяного знака или текстовый водяной знак."
---

## **О водяном знаке**
**Водяной знак** в презентации - это текстовый или графический штамп, используемый на слайде или на всех слайдах презентации. Обычно водяной знак используется для обозначения того, что презентация является черновиком (например, водяной знак "Черновик"); что она содержит конфиденциальную информацию (например, водяной знак "Конфиденциально"); для указания, к какой компании она принадлежит (например, водяной знак с названием компании); для идентификации автора презентации и т. д. Водяной знак помогает предотвратить нарушение авторских прав на презентацию, указывая на то, что презентацию нельзя копировать. Водяные знаки используются как в форматах PowerPoint, так и OpenOffice. В Aspose.Slides вы можете добавить водяной знак в форматы файлов PowerPoint PPT, PPTX и OpenOffice ODP.

В [**Aspose.Slides**](https://products.aspose.com/slides/java/) есть различные способы создания водяного знака в PowerPoint или OpenOffice, обрамления его в различные формы, изменения дизайна и поведения и т. д. Общее в том, что для добавления текстовых водяных знаков вам следует использовать класс [**TextFrame**](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame), а для добавления графического водяного знака - [**PictureFrame**](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame/). [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame/) реализует интерфейс [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) и может использовать всю мощь гибких настроек объекта формы. [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) не является формой, а его настройки ограничены. Поэтому рекомендуется обрамить объект [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) в объект [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape).

Существует два способа применения водяного знака: к одному слайду и ко всем слайдам презентации. Мастер-слайд используется для применения водяного знака ко всем слайдам презентации - водяной знак добавляется в Мастер-слайд, полностью разрабатывается там и применяется ко всем слайдам, не изменяя разрешение на модификацию водяного знака на слайдах.

Обычно водяной знак считается недоступным для редактирования другими пользователями. Чтобы предотвратить редактирование водяного знака (или скорее родительской формы водяного знака), Aspose.Slides предоставляет функциональность блокировки формы. Определенная форма может быть заблокирована на обычном слайде или на Мастере-слайде. При блокировке формы водяного знака на Мастере-слайде она будет заблокирована на всех слайдах презентации.

Вы можете задать имя водяного знака, чтобы в будущем, если вы захотите удалить водяной знак, вы могли его найти в формах слайдов по имени.

Вы можете разработать водяной знак любым способом, однако часто наблюдаются общие характеристики в рамках водяных знаков, такие как: центрирование, вращение, передняя позиция и т. д. Мы рассмотрим, как использовать их в примерах ниже.
## **Текстовый водяной знак**
### **Добавить текстовый водяной знак на слайд**
Чтобы добавить текстовый водяной знак в PPT, PPTX или ODP, вы можете сначала добавить форму на слайд, а затем добавить текстовую рамку в эту форму. Текстовая рамка представлена типом [**TextFrame**](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame). Этот тип не наследуется от [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape), который имеет широкий набор свойств для гибкой настройки водяного знака. Поэтому рекомендуется обрамить объект [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) в объект [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape). Чтобы добавить водяной знак в форму, используйте метод [**addTextFrame**](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-) с текстом водяного знака:

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
- [Как использовать ](/slides/java/slide-master/)[TextFrame](/slides/java/adding-and-formatting-text/)
{{% /alert %}}

### **Добавить текстовый водяной знак в презентацию**
Если вы хотите добавить водяной знак в презентацию (то есть ко всем слайдам сразу), добавьте его в [**MasterSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/MasterSlide). Вся остальная логика такая же, как и при добавлении водяного знака на один слайд - создайте объект [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) и затем добавьте в него водяной знак с помощью метода [**addTextFrame**](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-):

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
- [Как использовать ](/slides/java/slide-master/)[Мастер-слайд](/slides/java/slide-master/)
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
Можно центрировать водяной знак на слайде, для этого вы можете сделать следующее:

```java
Point2D.Float center = new Point2D.Float((float)  pres.getSlideSize().getSize().getWidth() / 2, (float) pres.getSlideSize().getSize().getHeight() / 2);

float width = 300;

float height = 300;

float x = (float) center.getX() - width / 2;

float y = (float) center.getY() - height / 2;

//...


IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Triangle, x, y, width, height);
```

## **Графический водяной знак**
### **Добавить графический водяной знак в презентацию**
Чтобы добавить графический водяной знак на все слайды презентации, вы можете сделать следующее:

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
Если необходимо предотвратить редактирование водяного знака, используйте метод [**AutoShape.getShapeLock**](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape#getShapeLock--) на форме, которая его обрамляет. С помощью этого метода вы можете защитить форму от выбора, изменения размера, изменения положения, группирования с другими элементами, заблокировать текст от редактирования и многого другого:

```java
// Заблокировать формы от изменения

watermarkShape.getShapeLock().setSelectLocked(true);

watermarkShape.getShapeLock().setSizeLocked(true);

watermarkShape.getShapeLock().setTextLocked(true);

watermarkShape.getShapeLock().setPositionLocked(true);

watermarkShape.getShapeLock().setGroupingLocked(true);
```

{{% alert color="primary" title="Смотрите также" %}} 
- [Как заблокировать формы от редактирования](/slides/java/presentation-locking/)
{{% /alert %}}

## **Переместить водяной знак на передний план**
В Aspose.Slides порядок наложения форм можно установить с помощью метода [**SlideCollection.reorder**](https://reference.aspose.com/slides/java/com.aspose.slides/SlideCollection#reorder-int-com.aspose.slides.ISlide...-). Для этого вам нужно вызвать этот метод из списка слайдов презентации и передать ссылку на форму и номер ее порядка в метод. Таким образом, можно переместить форму на передний или задний план слайда. Эта функция особенно полезна, если вам нужно разместить водяной знак на переднем плане презентации:

```java
slide.getShapes().reorder(slide.getShapes().size() - 1, watermarkShape);
```

## **Установить вращение водяного знака**
Вот пример того, как установить вращение водяного знака (и его родительской формы):

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

## **Установить имя для водяного знака**
Aspose.Slides позволяет задавать имя формы. По имени формы вы можете получить к ней доступ в будущем для модификации или удаления. Чтобы установить имя родительской формы водяного знака - задайте его в методе [**AutoShape.getName**](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getName--) :

```java
watermarkShape.setName("водяной_знак");
```

## **Удалить водяной знак**
Чтобы удалить форму водяного знака и ее дочерние элементы со слайда, используйте метод [AutoShape.getName](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getName--) , чтобы найти его в формах слайда. Затем передайте форму водяного знака в метод [**ShapeCollection.remove**](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeCollection#remove-com.aspose.slides.IShape-) :

```java
for (int i = 0; i < slide.getShapes().size(); i++)
{
    AutoShape shape = (AutoShape)slide.getShapes().get_Item(i);

    if ("водяной_знак".equals(shape.getName()))
    {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **Живой пример**
Вы можете проверить бесплатные онлайн-инструменты **Aspose.Slides** [**Добавить водяной знак** ](https://products.aspose.app/slides/watermark) и [**Удалить водяной знак**](https://products.aspose.app/slides/watermark/remove-watermark). 

![todo:image_alt_text](slides-watermark.png)