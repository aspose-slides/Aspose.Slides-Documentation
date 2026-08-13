---
title: Добавить водяные знаки в презентации на Android
linktitle: Водяной знак
type: docs
weight: 40
url: /ru/androidjava/watermark/
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
- стереть водяной знак из PPT
- стереть водяной знак из PPTX
- стереть водяной знак из ODP
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Управляйте текстовыми и графическими водяными знаками в презентациях PowerPoint и OpenDocument на Android с помощью Java, чтобы обозначить черновик, конфиденциальную информацию и прочее."
---
## **Введение**

**Водяной знак** в презентации — это текстовая или графическая маркировка, используемая на отдельном слайде или на всех слайдах презентации. Обычно водяной знак указывает, что материал является черновиком (например, «Draft»), содержит конфиденциальную информацию (например, «Confidential»), принадлежит определённой компании (например, «Company Name»), идентифицирует автора презентации и т.п. Водяной знак помогает предотвратить нарушения авторских прав, указывая, что материал не должен копироваться. Водяные знаки применяются как в PowerPoint, так и в OpenOffice. В Aspose.Slides вы можете добавить водяной знак в файлы форматов PowerPoint PPT, PPTX и OpenOffice ODP.

В [**Aspose.Slides**](https://products.aspose.com/slides/ru/android-java/) существует несколько способов создания водяных знаков в документах PowerPoint или OpenOffice и изменения их дизайна и поведения. Общий принцип: для добавления текстовых водяных знаков следует использовать интерфейс [ITextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/), а для графических — класс [PictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pictureframe/) либо заполнить форму водяного знака изображением. `PictureFrame` реализует интерфейс [IShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/), что позволяет использовать все гибкие настройки объекта формы. Поскольку `ITextFrame` не является формой и имеет ограниченные параметры, он оборачивается в объект [IShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/).

Существует два способа применения водяного знака: к отдельному слайду или ко всей презентации. Для добавления водяного знака на все слайды используется Slide Master — водяной знак размещается в Slide Master, полностью оформляется там и применяется ко всем слайдам без ограничения возможности изменения его на отдельных слайдах.

Водяной знак обычно считается недоступным для редактирования другими пользователями. Чтобы предотвратить редактирование водяного знака (точнее, его родительской формы), Aspose.Slides предоставляет функциональность блокировки формы. Конкретную форму можно заблокировать как на обычном слайде, так и на Slide Master. При блокировке формы водяного знака на Slide Master блокировка распространяется на все слайды презентации.

Можно задать имя водяному знаку, чтобы в дальнейшем легко находить его среди форм слайда по имени и при необходимости удалять.

Водяной знак можно оформить произвольно, однако обычно в них присутствуют общие характеристики: центрирование, поворот, размещение на переднем плане и т.п. Ниже мы рассмотрим, как использовать эти возможности в примерах.

## **Текстовый водяной знак**

### **Добавить текстовый водяной знак на слайд**

Чтобы добавить текстовый водяной знак в PPT, PPTX или ODP, сначала добавьте форму на слайд, затем добавьте к ней текстовый кадр. Текстовый кадр представляет интерфейс [ITextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/). Этот тип не наследуется от [IShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/), который предоставляет широкий набор свойств для гибкого позиционирования водяного знака. Поэтому объект [ITextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/) оборачивается в объект [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/). Чтобы добавить текст водяного знака в форму, используйте метод [addTextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) как показано ниже.

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="См. также" %}} 
- [Как использовать класс TextFrame](/slides/ru/androidjava/text-formatting/)
{{% /alert %}}

### **Добавить текстовый водяной знак в презентацию**

Если необходимо добавить текстовый водяной знак ко всей презентации (т.е. ко всем слайдам сразу), разместите его в [MasterSlide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/masterslide/). Дальнейшая логика аналогична добавлению водяного знака на отдельный слайд — создайте объект [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) и затем добавьте к нему водяной знак с помощью метода [addTextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="См. также" %}} 
- [Как использовать мастер‑слайдов](/slides/ru/androidjava/slide-master/)
{{% /alert %}}

### **Установить прозрачность формы водяного знака**

По умолчанию прямоугольная форма имеет заливку и цвет контура. Следующий код делает форму прозрачной.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.getFillFormat().setFillType(FillType.NoFill);
    watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
} finally {
    presentation.dispose();
}
```

### **Установить шрифт для текстового водяного знака**

Шрифт текстового водяного знака можно изменить, как показано ниже.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    textFormat.setLatinFont(new FontData("Arial"));
    textFormat.setFontHeight(50);
} finally {
    presentation.dispose();
}
```

### **Установить цвет текста водяного знака**

Чтобы задать цвет текста водяного знака, используйте следующий код:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 150, red = 200, green = 200, blue = 200;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
    fillFormat.setFillType(FillType.Solid);
    fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
} finally {
    presentation.dispose();
}
```

### **Центрировать текстовый водяной знак**

Водяной знак можно центрировать на слайде следующим образом:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    float watermarkWidth = 400;
    float watermarkHeight = 40;
    float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
    float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

    IAutoShape watermarkShape = slide.getShapes().addAutoShape(
            ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

    ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
} finally {
    presentation.dispose();
}
```

Изображение ниже показывает итоговый результат.

![Текстовый водяной знак](text_watermark.png)

## **Водяной знак‑изображение**

### **Добавить изображение водяного знака в презентацию**

Чтобы добавить изображение водяного знака на слайд презентации, выполните следующие действия:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    InputStream imageStream = new FileInputStream("watermark.png");
    IPPImage image = presentation.getImages().addImage(imageStream);

    watermarkShape.getFillFormat().setFillType(FillType.Picture);
    watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
} finally {
    presentation.dispose();
}
```

### **Заблокировать водяной знак от редактирования**

Если требуется запретить редактирование водяного знака, используйте метод [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) у формы. С помощью этого свойства можно защитить форму от выбора, изменения размеров, перемещения, группировки с другими элементами, блокировать её текст от редактирования и многое другое:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    // Заблокировать форму водяного знака от изменения
    watermarkShape.getAutoShapeLock().setSelectLocked(true);
    watermarkShape.getAutoShapeLock().setSizeLocked(true);
    watermarkShape.getAutoShapeLock().setTextLocked(true);
    watermarkShape.getAutoShapeLock().setPositionLocked(true);
    watermarkShape.getAutoShapeLock().setGroupingLocked(true);
} finally {
    presentation.dispose();
}
```

### **Переместить водяной знак на передний план**

В Aspose.Slides порядок наложения форм задаётся методом [IShapeCollection.reorder](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). Для этого необходимо вызвать метод из списка слайдов презентации, передав ссылку на форму и её порядковый номер. Так можно переместить форму на передний план либо отправить её назад. Эта возможность особенно полезна, когда нужно разместить водяной знак поверх содержимого презентации:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    int shapeCount = slide.getShapes().size();
    slide.getShapes().reorder(shapeCount - 1, watermarkShape);
} finally {
    presentation.dispose();
}
```

### **Установить вращение водяного знака**

Ниже пример кода, показывающего, как задать вращение водяного знака, чтобы он располагался по диагонали слайда:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

    watermarkShape.setRotation((float)diagonalAngle);
} finally {
    presentation.dispose();
}
```

### **Задать имя водяного знака**

Aspose.Slides позволяет задать имя форме. По имени формы её можно будет найти в будущем для изменения или удаления. Чтобы задать имя форме водяного знака, используйте метод [IAutoShape.setName](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.setName("watermark");
} finally {
    presentation.dispose();
}
```

### **Удалить водяной знак**

Чтобы удалить форму водяного знака, используйте метод [IAutoShape.getName](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getName--) для её поиска среди форм слайда. Затем передайте найденную форму в метод [IShapeCollection.remove](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("watermarked.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape[] slideShapes = slide.getShapes().toArray();
    for (IShape shape : slideShapes) {
        if ("watermark".equals(shape.getName()))
        {
            slide.getShapes().remove(shape);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Часто задаваемые вопросы**

### Что такое водяной знак и зачем его использовать?

Водяной знак — это наложенный на слайды текстовый или графический элемент, который помогает защищать интеллектуальную собственность, усиливать узнаваемость бренда или препятствовать неавторизованному использованию презентаций.

### Могу ли я добавить водяной знак ко всем слайдам презентации?

Да, Aspose.Slides позволяет программно добавить водяной знак на каждый слайд презентации. Вы можете пройтись по всем слайдам и применить настройки водяного знака индивидуально.

### Как можно отрегулировать прозрачность водяного знака?

Прозрачность водяного знака регулируется изменением параметров заливки формы ([getFillFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/shape/#getFillFormat--)). Это делает водяной знак едва заметным и не отвлекает внимание от содержания слайда.

### Какие форматы изображений поддерживаются для водяных знаков?

Aspose.Slides поддерживает различные форматы изображений, такие как PNG, JPEG, GIF, BMP, SVG и прочие.

### Могу ли я настроить шрифт и стиль текстового водяного знака?

Да, вы можете выбрать любой шрифт, размер и стиль, чтобы они соответствовали дизайну вашей презентации и поддерживали единообразие бренда.

### Как изменить позицию или ориентацию водяного знака?

Позицию и ориентацию водяного знака можно программно изменить, изменяя координаты, размеры и свойства вращения формы.