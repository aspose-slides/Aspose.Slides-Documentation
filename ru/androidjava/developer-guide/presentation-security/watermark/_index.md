---
title: Добавление водяных знаков в презентации на Android
linktitle: Водяной знак
type: docs
weight: 40
url: /ru/androidjava/watermark/
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
- Android
- Java
- Aspose.Slides
description: "Управляйте текстовыми и графическими водяными знаками в презентациях PowerPoint и OpenDocument на Android с помощью Java, чтобы указывать черновик, конфиденциальную информацию и многое другое."
---

## **О водяных знаках**

**Водяной знак** в презентации — это текстовый или графический штамп, используемый на отдельном слайде или на всех слайдах презентации. Обычно водяной знак указывает, что презентация является черновиком (например, «Черновик»), содержит конфиденциальную информацию (например, «Конфиденциально»), принадлежит определённой компании (например, «Название компании»), идентифицирует автора презентации и т.д. Водяной знак помогает предотвратить нарушения авторских прав, указывая, что презентацию нельзя копировать. Водяные знаки поддерживаются в форматах PowerPoint и OpenOffice. В Aspose.Slides вы можете добавить водяной знак в файлы форматов PowerPoint PPT, PPTX и OpenOffice ODP.

В [**Aspose.Slides**](https://products.aspose.com/slides/android-java/) существует несколько способов создания водяных знаков в документах PowerPoint или OpenOffice и их настройки. Общий момент: для добавления текстовых водяных знаков следует использовать интерфейс [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/), а для графических — класс [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) либо заполнить форму водяного знака изображением. `PictureFrame` реализует интерфейс [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/), что позволяет использовать все гибкие настройки объекта формы. Поскольку `ITextFrame` не является формой и его параметры ограничены, он оборачивается в объект [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/).

Водяной знак может применяться двумя способами: к отдельному слайду или ко всем слайдам презентации. Для применения к каждому слайду используется Slide Master — водяной знак добавляется в Slide Master, полностью оформляется там и применяется ко всем слайдам без ограничения возможности изменения водяного знака на отдельных слайдах.

Обычно считается, что водяной знак недоступен для редактирования другими пользователями. Чтобы запретить редактирование водяного знака (точнее, его родительской формы), Aspose.Slides предоставляет функциональность блокировки форм. Конкретную форму можно заблокировать как на обычном слайде, так и на Slide Master. Когда форма водяного знака заблокирована на Slide Master, она будет заблокирована на всех слайдах презентации.

Можно задать имя водяного знака, чтобы в дальнейшем при необходимости удалить его, найти форму по имени в коллекции форм слайда.

Водяной знак может быть оформлен произвольно; однако обычно у него есть общие свойства: центрирование, вращение, расположение на переднем плане и т.д. Рассмотрим, как использовать эти свойства в примерах ниже.

## **Текстовый водяной знак**

### **Добавление текстового водяного знака на слайд**

Чтобы добавить текстовый водяной знак в PPT, PPTX или ODP, сначала добавьте форму на слайд, затем добавьте к этой форме текстовый фрейм. Текстовый фрейм представлен интерфейсом [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/). Этот тип не наследуется от [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/), который обладает широким набором свойств для гибкого позиционирования водяного знака. Поэтому объект [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) оборачивается в объект [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/). Чтобы добавить текст водяного знака в форму, используйте метод [addTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) как показано ниже.
```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="Смотрите также" %}} 
- [Как использовать класс TextFrame](/slides/ru/androidjava/text-formatting/)
{{% /alert %}}

### **Добавление текстового водяного знака в презентацию**

Если нужно добавить текстовый водяной знак ко всей презентации (то есть ко всем слайдам одновременно), добавьте его в [MasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterslide/). Остальная логика аналогична добавлению водяного знака на отдельный слайд — создайте объект [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) и затем добавьте к нему водяной знак с помощью метода [addTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).
```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="Смотрите также" %}} 
- [Как использовать Slide Master](/slides/ru/androidjava/slide-master/)
{{% /alert %}}

### **Установка прозрачности формы водяного знака**

По умолчанию прямоугольная форма имеет цвета заливки и контура. Следующие строки кода делают форму прозрачной.
```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```


### **Установка шрифта для текстового водяного знака**

Вы можете изменить шрифт текстового водяного знака, как показано ниже.
```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```


### **Установка цвета текста водяного знака**

Чтобы задать цвет текста водяного знака, используйте следующий код:
```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(Color.argb(alpha, red, green, blue));
```


### **Центрирование текстового водяного знака**

Водяной знак можно центрировать на слайде, для чего выполните следующее:
```java
SizeF slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```


Изображение ниже показывает окончательный результат.

![The text watermark](text_watermark.png)

## **Графический водяной знак**

### **Добавление графического водяного знака в презентацию**

Чтобы добавить графический водяной знак на слайд презентации, выполните следующее:
```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```


### **Блокировка водяного знака от редактирования**

Если необходимо запретить редактирование водяного знака, используйте метод [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) у формы. С помощью этого свойства можно защитить форму от выбора, изменения размеров, перемещения, группировки с другими элементами, блокировать её текст от редактирования и многое другое:
```java
// Заблокировать форму водяного знака от изменения
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```


### **Перемещение водяного знака на передний план**

В Aspose.Slides порядок наложения форм (Z‑order) можно задать через метод [IShapeCollection.reorder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). Для этого вызовите данный метод из списка слайдов презентации, передав ссылку на форму и её порядковый номер. Так можно вынести форму на передний план или отправить её назад. Эта возможность особенно полезна, когда нужно разместить водяной знак перед содержимым презентации:
```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```


### **Установка поворота водяного знака**

Ниже пример кода, показывающий, как задать угол поворота водяного знака, чтобы он располагался по диагонали слайда:
```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```


### **Задание имени водяного знака**

Aspose.Slides позволяет задать имя формы. Используя имя формы, вы сможете в дальнейшем получить к ней доступ для изменения или удаления. Чтобы задать имя формы водяного знака, присвойте его методу [IAutoShape.setName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-):
```java
watermarkShape.setName("watermark");
```


### **Удаление водяного знака**

Для удаления формы водяного знака используйте метод [IAutoShape.getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getName--) для поиска формы в коллекции слайда, затем передайте найденную форму в метод [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-):
```java
IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(watermarkShape);
    }
}
```


## **FAQ**

**Что такое водяной знак и зачем его использовать?**

Водяной знак — это текстовое или графическое наложение на слайды, которое помогает защищать интеллектуальную собственность, усиливать узнаваемость бренда или предотвращать несанкционированное использование презентаций.

**Можно ли добавить водяной знак ко всем слайдам презентации?**

Да, Aspose.Slides позволяет программно добавить водяной знак на каждый слайд презентации. Вы можете пройтись циклом по всем слайдам и применить настройки водяного знака по отдельности.

**Как настроить прозрачность водяного знака?**

Прозрачность водяного знака регулируется параметрами заливки формы ([getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getFillFormat--)). Это обеспечивает ненавязчивый вид знака, не отвлекая внимание от содержимого слайда.

**Какие форматы изображений поддерживаются для водяных знаков?**

Aspose.Slides поддерживает различные форматы изображений, такие как PNG, JPEG, GIF, BMP, SVG и другие.

**Можно ли настроить шрифт и стиль текстового водяного знака?**

Да, вы можете выбрать любой шрифт, размер и стиль, чтобы они соответствовали дизайну вашей презентации и поддерживали фирменный стиль.

**Как изменить позицию или ориентацию водяного знака?**

Позицию и ориентацию водяного знака можно программно изменить, изменив координаты, размеры и свойства вращения формы.