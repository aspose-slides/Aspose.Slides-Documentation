---
title: Добавить водяные знаки в презентации на Java
linktitle: Водяной знак
type: docs
weight: 40
url: /ru/java/watermark/
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
- Java
- Aspose.Slides
description: "Управляйте текстовыми и графическими водяными знаками в презентациях PowerPoint и OpenDocument на Java, чтобы обозначить черновик, конфиденциальную информацию, авторские права и многое другое."
---
## **Введение**

**Водяной знак** в презентации — это текстовая или графическая печать, используемая на слайде или на всех слайда�� презентации. Обычно водяной знак указывает, что презентация является черновиком (например, водяной знак «Draft»), содержит конфиденциальную информацию (например, «Confidential»), указывает, к какой компании относится (например, «Company Name»), идентифицирует автора презентации и т.д. Водяной знак помогает предотвратить нарушения авторских прав, указывая, что презентацию нельзя копировать. Водяные знаки используются как в форматах PowerPoint, так и в OpenOffice. В Aspose.Slides вы можете добавить водяной знак в файлы PowerPoint PPT, PPTX и OpenOffice ODP.

В [**Aspose.Slides**](https://products.aspose.com/slides/ru/java/) есть различные способы создания водяных знаков в документах PowerPoint или OpenOffice и изменения их дизайна и поведения. Общий момент заключается в том, что для добавления текстовых водяных знаков следует использовать интерфейс [ITextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/), а для добавления графических водяных знаков — класс [PictureFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pictureframe/) или заполнить форму водяного знака изображением. `PictureFrame` реализует интерфейс [IShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/), позволяя использовать все гибкие настройки объекта формы. Поскольку `ITextFrame` не является формой и его настройки ограничены, он оборачивается в объект [IShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/).

Существует два способа применения водяного знака: к отдельному слайду или ко всем слайдам презентации. Для применения водяного знака ко всем слайдам используется Slide Master — водяной знак добавляется в Slide Master, полностью оформляется там и применяется ко всем слайдам без ограничения возможности изменения водяного знака на отдельных слайдах.

Водяной знак обычно считается недоступным для редактирования другими пользователями. Чтобы предотвратить редактирование водяного знака (а точнее его родительской формы), Aspose.Slides предоставляет возможность блокировки формы. Конкретную форму можно заблокировать на обычном слайде или на Slide Master. Когда форма водяного знака заблокирована на Slide Master, она будет заблокирована на всех слайдах презентации.

Можно задать имя для водяного знака, чтобы в дальнейшем, при необходимости удалить его, найти его среди форм слайда по имени.

Водяной знак можно оформить любым способом; однако обычно у водяных знаков есть общие характеристики, такие как центрирование, вращение, расположение спереди и т.д. Ниже мы рассмотрим, как использовать их в примерах.

## **Текстовый водяной знак**

### **Добавление текстового водяного знака на слайд**

Чтобы добавить текстовый водяной знак в PPT, PPTX или ODP, сначала можно добавить форму на слайд, а затем добавить к этой форме текстовый фрейм. Текстовый фрейм представлен интерфейсом [ITextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/). Этот тип не наследуется от [IShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/), который имеет широкий набор свойств для гибкого позиционирования водяного знака. Поэтому объект [ITextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/) оборачивается в объект [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/). Чтобы добавить текст водяного знака в форму, используйте метод [addTextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) как показано ниже.

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="Смотрите также" %}} 
- [Как использовать класс TextFrame](/slides/ru/java/text-formatting/)
{{% /alert %}}

### **Добавление текстового водяного знака в презентацию**

Если необходимо добавить текстовый водяной знак ко всей презентации (т.е. ко всем слайдам сразу), добавьте его в [MasterSlide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/masterslide/). Остальная логика идентична добавлению водяного знака на отдельный слайд — создайте объект [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/) и затем добавьте в него водяной знак с помощью метода [addTextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="Смотрите также" %}} 
- [Как использовать Slide Master](/slides/ru/java/slide-master/)
{{% /alert %}}

### **Установка прозрачности формы водяного знака**

По умолчанию прямоугольная форма имеет заливку и цвет контура. Следующие строки кода делают форму прозрачной.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

presentation.dispose();
```

### **Установка шрифта для текстового водяного знака**

Вы можете изменить шрифт текстового водяного знака, как показано ниже.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);

presentation.dispose();
```

### **Установка цвета текста водяного знака**

Чтобы задать цвет текста водяного знака, используйте следующий код:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));

presentation.dispose();
```

### **Центрирование текстового водяного знака**

Можно центрировать водяной знак на слайде, для чего выполните следующее:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

На изображении ниже показан итоговый результат.

![Текстовый водяной знак](text_watermark.png)

## **Графический водяной знак**

### **Добавление графического водяного знака в презентацию**

Чтобы добавить графический водяной знак на слайд презентации, выполните следующее:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

presentation.dispose();
```

### **Блокировка водяного знака от редактирования**

Если необходимо предотвратить редактирование водяного знака, используйте метод [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) у формы. С помощью этого свойства вы можете защитить форму от выбора, изменения размера, перемещения, группировки с другими элементами, заблокировать её текст от редактирования и многое другое:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// Заблокировать форму водяного знака от изменения
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);

presentation.dispose();
```

### **Переместить водяной знак на передний план**

В Aspose.Slides порядок Z‑слоёв форм можно задать методом [IShapeCollection.reorder](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). Для этого необходимо вызвать данный метод из списка слайдов презентации и передать в него ссылку на форму и её порядковый номер. Таким образом можно переместить форму на передний план или отправить её назад. Эта возможность особенно полезна, если нужно разместить водяной знак перед содержимым презентации:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);

presentation.dispose();
```

### **Установка вращения водяного знака**

Ниже приведён пример кода, показывающий, как настроить вращение водяного знака, чтобы он располагался по диагонали слайда:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

Dimension2D slideSize = presentation.getSlideSize().getSize();

double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);

presentation.dispose();
```

### **Задание имени для водяного знака**

Aspose.Slides позволяет задать имя форме. Используя имя формы, вы можете в дальнейшем получить к ней доступ для изменения или удаления. Чтобы задать имя форме водяного знака, передайте его методу [IAutoShape.setName](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/#setName-java.lang.String-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.setName("watermark");

presentation.dispose();
```

### **Удаление водяного знака**

Чтобы удалить форму водяного знака, используйте метод [IAutoShape.getName](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/#getName--) для её поиска среди форм слайда. Затем передайте форму водяного знака в метод [IShapeCollection.remove](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(shape);
    }
}

presentation.dispose();
```

## **Часто задаваемые вопросы**

### Что такое водяной знак и зачем его использовать?

Водяной знак — это наложенный на слайды текст или изображение, который помогает защищать интеллектуальную собственность, повышать узнаваемость бренда или предотвращать несанкционированное использование презентаций.

### Можно ли добавить водяной знак на все слайды презентации?

Да, Aspose.Slides позволяет программно добавить водяной знак на каждый слайд презентации. Вы можете перебрать все слайды и применить настройки водяного знака к каждому из них отдельно.

### Как отрегулировать прозрачность водяного знака?

Прозрачность водяного знака можно изменить, изменив настройки заливки ([getFillFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/shape/#getFillFormat--)) формы. Это делает водяной знак едва заметным и не отвлекает внимание от содержимого слайда.

### Какие форматы изображений поддерживаются для водяных знаков?

Aspose.Slides поддерживает различные форматы изображений, такие как PNG, JPEG, GIF, BMP, SVG и др.

### Можно ли настроить шрифт и стиль текстового водяного знака?

Да, вы можете выбрать любой шрифт, размер и стиль, чтобы они соответствовали дизайну вашей презентации и поддерживали согласованность бренда.

### Как изменить положение или ориентацию водяного знака?

Положением и ориентацией водяного знака можно управлять программно, изменяя координаты, размеры и свойства вращения формы.