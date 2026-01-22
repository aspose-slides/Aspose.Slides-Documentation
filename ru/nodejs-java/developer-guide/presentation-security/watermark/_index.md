---
title: Добавление водяных знаков в презентации на JavaScript
linktitle: Водяной знак
type: docs
weight: 40
url: /ru/nodejs-java/watermark/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Управляйте текстовыми и изображенными водяными знаками в презентациях PowerPoint и OpenDocument в Node.js, чтобы указывать черновик, конфиденциальную информацию, авторские права и многое другое."
---

## **О водяном знаке**

**Водяной знак** в презентации — это текстовая или графическая печать, используемая на отдельном слайде или на всех слайдах презентации. Обычно водяной знак применяется, чтобы указать, что презентация является черновиком (например, водяной знак «Черновик»), содержит конфиденциальную информацию (например, «Конфиденциально»), обозначить, к какой компании она относится (например, «Название компании»), идентифицировать автора презентации и т.д. Водяной знак помогает предотвратить нарушения авторских прав, указывая, что презентацию не следует копировать. Водяные знаки используются как в форматах PowerPoint, так и в OpenOffice. В Aspose.Slides вы можете добавить водяной знак в файлы PowerPoint PPT, PPTX и OpenOffice ODP.

В [**Aspose.Slides**](https://products.aspose.com/slides/nodejs-java/), существует несколько способов создания водяных знаков в документах PowerPoint или OpenOffice и изменения их дизайна и поведения. Общий момент состоит в том, что для добавления текстовых водяных знаков следует использовать тип [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/), а для добавления графических водяных знаков — класс [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) или заполнить форму водяного знака изображением. `PictureFrame` реализует тип [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/), позволяя использовать все гибкие настройки объекта формы. Поскольку `TextFrame` не является формой и его настройки ограничены, он оборачивается в объект [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/).

Существует два способа применения водяного знака: к отдельному слайду или ко всем слайдам презентации. Slide Master используется для применения водяного знака ко всем слайдам — водяной знак добавляется в Slide Master, полностью разрабатывается там и применяется ко всем слайдам без влияния на возможность изменения водяного знака на отдельных слайдах.

Водяной знак обычно считается недоступным для редактирования другими пользователями. Чтобы предотвратить редактирование водяного знака (а точнее его родительской формы), Aspose.Slides предоставляет возможность блокировки формы. Определённую форму можно заблокировать на обычном слайде или на Slide Master. Когда форма водяного знака заблокирована на Slide Master, она будет заблокирована на всех слайдах презентации.

Вы можете задать имя для водяного знака, чтобы в дальнейшем, при желании удалить его, найти его среди форм слайда по имени.

Водяной знак можно оформить любым способом; однако обычно у водяных знаков есть общие характеристики, такие как выравнивание по центру, вращение, положение спереди и т.д. Мы рассмотрим, как использовать их в примерах ниже.

## **Текстовый водяной знак**

### **Добавить текстовый водяной знак на слайд**

Чтобы добавить текстовый водяной знак в PPT, PPTX или ODP, сначала можно добавить форму на слайд, затем добавить к этой форме текстовый кадр. Текстовый кадр представлен типом [**TextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame). Этот тип не наследуется от [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape), который предоставляет широкий набор свойств для гибкого позиционирования водяного знака. Поэтому объект [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) оборачивается в объект [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape). Чтобы добавить текст водяного знака в форму, используйте метод [**addTextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) с переданным текстом водяного знака:
```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let slide = presentation.getSlides().get_Item(0);

let watermarkShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="См. также" %}} 
- Как использовать [TextFrame](/slides/ru/nodejs-java/text-formatting/).
{{% /alert %}}

### **Добавить текстовый водяной знак в презентацию**

Если вы хотите добавить текстовый водяной знак ко всей презентации (т.е. ко всем слайдам сразу), добавьте его в [**MasterSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide). Остальная логика аналогична добавлению водяного знака на отдельный слайд — создайте объект [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) и затем добавьте к нему водяной знак, используя метод [**addTextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-):
```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let masterSlide = presentation.getMasters().get_Item(0);

let watermarkShape = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="См. также" %}} 
- [Как использовать ](/slides/ru/nodejs-java/slide-master/)[Slide Master](/slides/ru/nodejs-java/slide-master/)
{{% /alert %}}

### **Установить прозрачность формы водяного знака**

По умолчанию прямоугольная форма имеет цвета заливки и контура. Следующий фрагмент кода делает форму прозрачной.
```javascript
watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
watermarkShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
```


### **Установить шрифт для текстового водяного знака**

Ниже показано, как изменить шрифт текстового водяного знака.
```javascript
let textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new aspose.slides.FontData("Arial"));
textFormat.setFontHeight(50);
```


### **Установить цвет текста водяного знака**

Чтобы задать цвет текста водяного знака, используйте следующий код:
```java
let alpha = 150;
let red = 200;
let green = 200;
let blue = 200;

let fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
fillFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", red, green, blue, alpha));
```


### **Центрировать текстовый водяной знак**

Можно центрировать водяной знак на слайде, для чего выполните следующее:
```javascript
const watermarkWidth = 400;
const watermarkHeight = 40;
const watermarkX = (slideSize.getWidth() - watermarkWidth) / 2;
const watermarkY = (slideSize.getHeight() - watermarkHeight) / 2;

let watermarkShape = masterSlide.getShapes().addAutoShape(
        aspose.slides.ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);
        
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```


На изображении ниже показан конечный результат.

![Текстовый водяной знак](text_watermark.png)

## **Графический водяной знак**

### **Добавить графический водяной знак в презентацию**

Чтобы добавить графический водяной знак во все слайды презентации, можно выполнить следующее:
```javascript
let watermarkImage = aspose.slides.Images.fromFile("watermark.png");
let image = presentation.getImages().addImage(watermarkImage);

// ...

watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
```


### **Заблокировать водяной знак от редактирования**

Если необходимо предотвратить редактирование водяного знака, используйте метод [**AutoShape.getShapeLock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#getShapeLock--) . С помощью этого свойства можно защитить форму от выбора, изменения размеров, перемещения, группировки с другими элементами, блокировать её текст от редактирования и многое другое:
```javascript
// Блокировать форму водяного знака от изменений
watermarkShape.getShapeLock().setSelectLocked(true);
watermarkShape.getShapeLock().setSizeLocked(true);
watermarkShape.getShapeLock().setTextLocked(true);
watermarkShape.getShapeLock().setPositionLocked(true);
watermarkShape.getShapeLock().setGroupingLocked(true);
```


### **Переместить водяной знак на передний план**

В Aspose.Slides порядок Z-слоёв форм можно задать с помощью метода [**SlideCollection.reorder**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#reorder-int-aspose.slides.ISlide...-). Для этого необходимо вызвать этот метод из списка слайдов презентации, передав ссылку на форму и её номер в порядке. Таким образом, можно переместить форму на передний план или отправить её на задний план слайда. Эта функция особенно полезна, если необходимо разместить водяной знак спереди презентации:
```javascript
let shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```


### **Установить поворот водяного знака**

Ниже приведён пример кода, показывающий, как настроить вращение водяного знака, чтобы разместить его по диагонали слайда:
```javascript
const diagonalAngle = Math.atan(slideSize.getHeight() / slideSize.getWidth()) * 180 / Math.PI;

watermarkShape.setRotation(diagonalAngle);
```


### **Задать имя для водяного знака**

Aspose.Slides позволяет задать имя форме. Используя имя формы, вы сможете в дальнейшем получить к ней доступ для изменения или удаления. Чтобы задать имя форме водяного знака, присвойте его методу [**AutoShape.getName**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getName--):
```javascript
watermarkShape.setName("watermark");
```


### **Удалить водяной знак**

Чтобы удалить форму водяного знака, используйте метод [AutoShape.getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getName--) , чтобы найти её среди форм слайда. Затем передайте форму водяного знака в метод [**ShapeCollection.remove**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#remove-aspose.slides.IShape-):
```javascript
for (var i = 0; i < slide.getShapes().size(); i++) {
    var shape = slide.getShapes().get_Item(i);
    if ("watermark" == shape.getName()) {
        slide.getShapes().remove(watermarkShape);
    }
}
```


## **Часто задаваемые вопросы**

**Что такое водяной знак и зачем его использовать?**

Водяной знак — это текстовое или графическое наложение на слайды, которое помогает защищать интеллектуальную собственность, усиливать узнаваемость бренда или предотвращать несанкционированное использование презентаций.

**Могу ли я добавить водяной знак ко всем слайдам презентации?**

Да, Aspose.Slides позволяет добавить водяной знак на каждый слайд презентации. Вы можете перебрать все слайды и применить настройки водяного знака к каждому из них.

**Как отрегулировать прозрачность водяного знака?**

Прозрачность водяного знака можно изменить, изменяя [настройки заливки](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getfillformat/) формы. Это гарантирует, что водяной знак будет ненавязчивым и не будет отвлекать от содержания слайда.

**Какие форматы изображений поддерживаются для водяных знаков?**

Aspose.Slides поддерживает различные форматы изображений, такие как PNG, JPEG, GIF, BMP, SVG и другие.

**Могу ли я настроить шрифт и стиль текстового водяного знака?**

Да, вы можете выбрать любой шрифт, размер и стиль, чтобы они соответствовали дизайну вашей презентации и поддерживали согласованность бренда.

**Как изменить позицию или ориентацию водяного знака?**

Позицию и ориентацию водяного знака можно изменить, изменяя координаты формы, её размер и свойства вращения.