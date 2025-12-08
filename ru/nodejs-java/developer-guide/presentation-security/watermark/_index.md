---
title: Водяной знак
type: docs
weight: 40
url: /ru/nodejs-java/watermark/
keywords: "водяной знак в презентации"
description: "Используйте водяной знак в PowerPoint с Aspose.Slides. Добавьте водяной знак в презентацию ppt или удалите водяной знак. Вставьте графический водяной знак или текстовый водяной знак."
---

## **О водяном знаке**

**Водяной знак** в презентации — это текстовая или графическая печать, используемая на одном слайде или во всех слайдах презентации. Обычно водяной знак применяют, чтобы указать, что презентация является черновиком (например, водяной знак «Черновик»), что она содержит конфиденциальную информацию (например, «Конфиденциально»), указать, к какой компании относится документ (например, «Название компании»), идентифицировать автора презентации и т.п. Водяной знак помогает предотвратить нарушения авторских прав, показывая, что презентацию нельзя копировать. Водяные знаки поддерживаются в форматах PowerPoint и OpenOffice. В Aspose.Slides вы можете добавить водяной знак в файлы PowerPoint PPT, PPTX и OpenOffice ODP.

В [**Aspose.Slides**](https://products.aspose.com/slides/nodejs-java/) доступны разные способы создания водяных знаков в документах PowerPoint или OpenOffice и изменения их дизайна и поведения. Общее требование — для добавления текстовых водяных знаков необходимо использовать тип [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/), а для графических — класс [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) или заполнить форму водяного знака изображением. `PictureFrame` реализует тип [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/), позволяя использовать все гибкие настройки объекта формы. Поскольку `TextFrame` не является формой и его настройки ограничены, он оборачивается в объект [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/).

Водяной знак можно применять двумя способами: к отдельному слайду или ко всем слайдам презентации. Для применения водяного знака ко всем слайдам используется Slide Master — водяной знак добавляется в Slide Master, полностью оформляется там и применяется ко всем слайдам, не ограничивая возможность изменения водяного знака на отдельных слайдах.

Обычно водяной знак считается недоступным для редактирования другими пользователями. Чтобы запретить редактирование водяного знака (точнее, его родительской формы), Aspose.Slides предоставляет возможность блокировки формы. Конкретную форму можно заблокировать на обычном слайде или на Slide Master. Когда форма водяного знака заблокирована на Slide Master, она будет заблокирована на всех слайдах презентации.

Можно задать имя водяному знаку, чтобы в дальнейшем при необходимости удалить его, найти форму по имени в списке форм слайда.

Водяной знак может быть оформлен произвольно; однако обычно у него есть общие характеристики, такие как центрирование, вращение, расположение спереди и т.д. Рассмотрим, как использовать эти возможности в примерах ниже.

## **Текстовый водяной знак**

### **Добавить текстовый водяной знак на слайд**
Чтобы добавить текстовый водяной знак в PPT, PPTX или ODP, сначала добавьте форму на слайд, затем добавьте в эту форму текстовый кадр. Текстовый кадр представляет тип [**TextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame). Этот тип не наследуется от [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape), который предоставляет широкий набор свойств для гибкого позиционирования водяного знака. Поэтому объект [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) оборачивается в объект [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape). Чтобы добавить текст водяного знака в форму, используйте метод [**addTextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) с переданным текстом водяного знака:
```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let slide = presentation.getSlides().get_Item(0);

let watermarkShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="Смотрите также" %}} 
- [Как использовать](/slides/ru/nodejs-java/slide-master/)[TextFrame](/slides/ru/nodejs-java/adding-and-formatting-text/)
{{% /alert %}}

### **Добавить текстовый водяной знак в презентацию**

Если необходимо добавить текстовый водяной знак во всю презентацию (то есть сразу на все слайды), добавьте его в [**MasterSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide). Остальная логика такая же, как при добавлении водяного знака на отдельный слайд — создайте объект [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) и затем добавьте в него водяной знак с помощью метода [**addTextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-):
```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let masterSlide = presentation.getMasters().get_Item(0);

let watermarkShape = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="Смотрите также" %}} 
- [Как использовать](/slides/ru/nodejs-java/slide-master/)[Slide Master](/slides/ru/nodejs-java/slide-master/)
{{% /alert %}}

### **Установить прозрачность формы водяного знака**

По умолчанию прямоугольная форма имеет заполнение и цвет линии. Следующий код делает форму прозрачной.
```javascript
watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
watermarkShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
```


### **Установить шрифт для текстового водяного знака**

Вы можете изменить шрифт текстового водяного знака, как показано ниже.
```javascript
let textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new aspose.slides.FontData("Arial"));
textFormat.setFontHeight(50);
```


### **Задать цвет текста водяного знака**

Для установки цвета текста водяного знака используйте следующий код:
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
Можно центрировать водяной знак на слайде, сделав следующее:
```javascript
const watermarkWidth = 400;
const watermarkHeight = 40;
const watermarkX = (slideSize.getWidth() - watermarkWidth) / 2;
const watermarkY = (slideSize.getHeight() - watermarkHeight) / 2;

let watermarkShape = masterSlide.getShapes().addAutoShape(
        aspose.slides.ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);
        
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```


Изображение ниже показывает конечный результат.

![The text watermark](text_watermark.png)

## **Графический водяной знак**

### **Добавить графический водяной знак в презентацию**

Чтобы добавить графический водяной знак во все слайды презентации, выполните следующее:
```javascript
let watermarkImage = aspose.slides.Images.fromFile("watermark.png");
let image = presentation.getImages().addImage(watermarkImage);

// ...

watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
```


### **Блокировать водяной знак от редактирования**

Если необходимо запретить редактирование водяного знака, используйте метод [**AutoShape.getShapeLock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#getShapeLock--) у формы. С помощью этого свойства можно защитить форму от выбора, изменения размеров, перемещения, группирования с другими элементами, блокировать её текст от редактирования и многое другое:
```javascript
// Заблокировать форму водяного знака от изменения
watermarkShape.getShapeLock().setSelectLocked(true);
watermarkShape.getShapeLock().setSizeLocked(true);
watermarkShape.getShapeLock().setTextLocked(true);
watermarkShape.getShapeLock().setPositionLocked(true);
watermarkShape.getShapeLock().setGroupingLocked(true);
```


{{% alert color="primary" title="Смотрите также" %}} 
- [Как заблокировать формы от редактирования](/slides/ru/nodejs-java/presentation-locking/)
{{% /alert %}}

### **Переместить водяной знак на передний план**

В Aspose.Slides порядок Z-слоёв форм можно задать через метод [**SlideCollection.reorder**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#reorder-int-aspose.slides.ISlide...-). Для этого вызовите метод из списка слайдов презентации, передав ссылку на форму и её порядковый номер. Таким образом можно переместить форму на передний план или отправить её назад. Эта возможность особенно полезна, если нужно разместить водяной знак спереди презентации:
```javascript
let shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```


### **Установить вращение водяного знака**

Ниже пример кода, показывающий, как задать вращение водяного знака, чтобы он располагался по диагонали слайда:
```javascript
const diagonalAngle = Math.atan(slideSize.getHeight() / slideSize.getWidth()) * 180 / Math.PI;

watermarkShape.setRotation(diagonalAngle);
```


### **Задать имя водяному знаку**

Aspose.Slides позволяет задать имя формы. Используя имя формы, можно в дальнейшем обращаться к ней для изменения или удаления. Чтобы задать имя формы водяного знака, присвойте его методу [**AutoShape.getName**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getName--):
```javascript
watermarkShape.setName("watermark");
```


### **Удалить водяной знак**

Чтобы удалить форму водяного знака, используйте метод [AutoShape.getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getName--) для поиска её в списке форм слайда. Затем передайте найденную форму в метод [**ShapeCollection.remove**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#remove-aspose.slides.IShape-):
```javascript
for (var i = 0; i < slide.getShapes().size(); i++) {
    var shape = slide.getShapes().get_Item(i);
    if ("watermark" == shape.getName()) {
        slide.getShapes().remove(watermarkShape);
    }
}
```


## **FAQ**

**Что такое водяной знак и зачем он нужен?**

Водяной знак — это текстовая или графическая надпись, наложенная на слайды, помогающая защитить интеллектуальную собственность, усилить узнаваемость бренда или предотвратить несанкционированное использование презентаций.

**Можно ли добавить водяной знак на все слайды презентации?**

Да, Aspose.Slides позволяет добавить водяной знак на каждый слайд презентации. Можно пройтись по всем слайдам и применить настройки водяного знака к каждому из них.

**Как отрегулировать прозрачность водяного знака?**

Прозрачность водяного знака можно изменить, изменив [настройки заполнения](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getfillformat/) формы. Это делает водяной знак едва заметным и не отвлекает от содержания слайда.

**Какие форматы изображений поддерживаются для водяных знаков?**

Aspose.Slides поддерживает различные форматы изображений, такие как PNG, JPEG, GIF, BMP, SVG и другие.

**Можно ли настроить шрифт и стиль текстового водяного знака?**

Да, вы можете выбрать любой шрифт, размер и стиль, чтобы они соответствовали дизайну вашей презентации и сохраняли фирменный стиль.

**Как изменить позицию или ориентацию водяного знака?**

Позицию и ориентацию водяного знака можно изменить, задав координаты, размеры и свойства вращения формы.