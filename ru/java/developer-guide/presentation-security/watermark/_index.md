---
title: Добавление водяных знаков в презентации на Java
linktitle: Водяной знак
type: docs
weight: 40
url: /ru/java/watermark/
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
- Java
- Aspose.Slides
description: "Управляйте текстовыми и графическими водяными знаками в презентациях PowerPoint и OpenDocument на Java, чтобы обозначить черновик, конфиденциальную информацию, авторские права и многое другое."
---

## **О водяных знаках**

**Водяной знак** в презентации — текстовый или графический штамп, используемый на отдельном слайде или на всех слайдах презентации. Обычно водяной знак служит для указания, что презентация является черновиком (например, «Черновик»), содержит конфиденциальную информацию (например, «Конфиденциально»), принадлежит определённой компании (например, «Название компании»), идентифицирует автора презентации и т. д. Водяной знак помогает предотвратить нарушения авторских прав, показывая, что презентацию нельзя копировать. Водяные знаки поддерживаются в форматах PowerPoint и OpenOffice. В Aspose.Slides можно добавить водяной знак в файлы форматов PowerPoint PPT, PPTX и OpenOffice ODP.

В [**Aspose.Slides**](https://products.aspose.com/slides/java/) есть несколько способов создания водяных знаков в документах PowerPoint или OpenOffice и изменения их дизайна и поведения. Общий момент — для добавления текстовых водяных знаков следует использовать интерфейс [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/), а для графических — класс [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) или заполнить форму водяного знака изображением. `PictureFrame` реализует интерфейс [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/), позволяя использовать все гибкие настройки объекта формы. Поскольку `ITextFrame` не является формой и имеет ограниченные настройки, он оборачивается в объект [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/).

Водяной знак можно применить двумя способами: к отдельному слайду или ко всем слайдам презентации. Для применения к каждому слайду используется шаблон слайда (Slide Master) — водяной знак добавляется в шаблон, полностью оформляется там и применяется ко всем слайдам, не влияя на возможность изменения водяного знака на отдельных слайдах.

Обычно водяной знак считается недоступным для редактирования другими пользователями. Чтобы предотвратить редактирование водяного знака (точнее, его родительской формы), Aspose.Slides предоставляет возможность блокировки формы. Конкретную форму можно заблокировать на обычном слайде или на шаблоне слайда. Когда форма водяного знака заблокирована в шаблоне слайда, она будет заблокирована на всех слайдах презентации.

Можно задать имя водяного знака, чтобы в дальнейшем, при необходимости удаления, найти его среди форм слайда по имени.

Водяной знак можно оформить любым способом; однако обычно у водяных знаков есть общие черты: выравнивание по центру, поворот, положение спереди и т. д. Рассмотрим, как это делать, в примерах ниже.

## **Текстовый водяной знак**

### **Добавление текстового водяного знака на слайд**

Чтобы добавить текстовый водяной знак в PPT, PPTX или ODP, сначала можно добавить форму на слайд, а затем добавить текстовый кадр к этой форме. Текстовый кадр представлен интерфейсом [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/). Этот тип не наследуется от [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/), который предоставляет широкий набор свойств для гибкого позиционирования водяного знака. Поэтому объект [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) оборачивается в объект [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/). Чтобы добавить текст водяного знака в форму, используйте метод [addTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) как показано ниже.
```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="Смотрите также" %}} 
- [Как использовать класс TextFrame](/slides/ru/java/text-formatting/)
{{% /alert %}}

### **Добавление текстового водяного знака во всю презентацию**

Если нужно добавить текстовый водяной знак ко всей презентации (т. е. сразу на все слайды), добавьте его в [MasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/masterslide/). Остальная логика такая же, как при добавлении водяного знака на отдельный слайд — создайте объект [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) и затем добавьте к нему водяной знак с помощью метода [addTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).
```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="Смотрите также" %}} 
- [Как использовать шаблон слайда](/slides/ru/java/slide-master/)
{{% /alert %}}

### **Установка прозрачности формы водяного знака**

По умолчанию прямоугольная форма имеет цвета заливки и линии. Следующий код делает форму прозрачной.
```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```


### **Установка шрифта для текстового водяного знака**

Шрифт текстового водяного знака можно изменить, как показано ниже.
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
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
```


### **Центрирование текстового водяного знака**

Водяной знак можно разместить по центру слайда, для чего выполните следующее:
```java
Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```


Ниже показан окончательный результат.

![Текстовый водяной знак](text_watermark.png)

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

Если необходимо запретить редактирование водяного знака, используйте метод [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) у формы. С помощью этого свойства можно защитить форму от выбора, изменения размера, перемещения, группировки с другими элементами, блокировать её текст от редактирования и многое другое:
```java
// Заблокировать форму водяного знака от изменения
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```


### **Перемещение водяного знака на передний план**

В Aspose.Slides порядок Z‑уровня форм задаётся через метод [IShapeCollection.reorder](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). Для этого вызовите метод из списка слайдов презентации, передав ссылку на форму и её порядковый номер. Так можно переместить форму на передний план или отправить её назад. Эта возможность особенно полезна, если требуется разместить водяной знак перед содержимым презентации:
```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```


### **Установка поворота водяного знака**

Ниже пример кода, показывающего, как изменить угол поворота водяного знака, чтобы он располагался по диагонали слайда:
```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```


### **Задание имени водяному знаку**

Aspose.Slides позволяет задать имя форме. Используя имя формы, её можно будет в дальнейшем найти для изменения или удаления. Чтобы задать имя форме водяного знака, передайте его методу [IAutoShape.setName](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setName-java.lang.String-):
```java
watermarkShape.setName("watermark");
```


### **Удаление водяного знака**

Чтобы удалить форму водяного знака, используйте метод [IAutoShape.getName](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getName--) для поиска её среди форм слайда. Затем передайте найденную форму методу [IShapeCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-):
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

**Что такое водяной знак и зачем он нужен?**

Водяной знак — это наложение текста или изображения на слайды, которое помогает защищать интеллектуальную собственность, усиливать узнаваемость бренда и препятствовать несанкционированному использованию презентаций.

**Можно ли добавить водяной знак на все слайды презентации?**

Да, Aspose.Slides позволяет программно добавить водяной знак ко всем слайдам презентации. Можно пройтись по каждому слайду и применить настройки водяного знака отдельно.

**Как отрегулировать прозрачность водяного знака?**

Прозрачность водяного знака регулируется изменением параметров заливки ([getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getFillFormat--)) формы. Это делает водяной знак ненавязчивым и не отвлекает внимание от содержимого слайда.

**Какие форматы изображений поддерживаются для водяных знаков?**

Aspose.Slides поддерживает различные форматы изображений, такие как PNG, JPEG, GIF, BMP, SVG и другие.

**Можно ли настроить шрифт и стиль текстового водяного знака?**

Да, можно выбрать любой шрифт, размер и стиль, чтобы они соответствовали дизайну вашей презентации и поддерживали фирменный стиль.

**Как изменить положение или ориентацию водяного знака?**

Позицию и ориентацию водяного знака можно программно изменить, задав координаты, размер и свойства вращения формы.