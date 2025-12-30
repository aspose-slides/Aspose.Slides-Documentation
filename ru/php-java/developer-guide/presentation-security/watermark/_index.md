---
title: Добавить водяные знаки в презентации на PHP
linktitle: Водяной знак
type: docs
weight: 40
url: /ru/php-java/watermark/
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
- PHP
- Aspose.Slides
description: "Управляйте текстовыми и графическими водяными знаками в презентациях PowerPoint и OpenDocument на PHP, чтобы обозначить черновик, конфиденциальную информацию, авторские права и многое другое."
---

## **О водяных знаках**

**Водяной знак** в презентации — это текстовая или графическая метка, используемая на отдельном слайде или на всех слайдах презентации. Обычно водяной знак применяется для указания того, что презентация является черновиком (например, водяной знак «Черновик»), содержит конфиденциальную информацию (например, «Конфиденциально»), принадлежит определённой компании (например, «Название компании»), идентифицирует автора презентации и т.д. Водяной знак помогает предотвратить нарушение авторских прав, указывая, что копировать презентацию нельзя. Водяные знаки поддерживаются как в форматах PowerPoint, так и в OpenOffice. В Aspose.Slides вы можете добавить водяной знак в файлы PPT, PPTX и ODP.

В [**Aspose.Slides**](https://products.aspose.com/slides/php-java/) существует несколько способов создания водяных знаков в документах PowerPoint или OpenOffice и изменения их дизайна и поведения. Общий принцип таков: для добавления текстовых водяных знаков следует использовать класс [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/), а для графических — класс [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) или заполнить форму водяного знака изображением. `PictureFrame` реализует класс [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/), что позволяет использовать все гибкие настройки объекта формы. Поскольку `ITextFrame` не является формой и его параметры ограничены, он оборачивается в объект [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/).

Водяной знак может быть применён двумя способами: к отдельному слайду или ко всем слайдам презентации. Для применения к каждому слайду используется мастер‑слайд — водяной знак добавляется в мастер‑слайд, полностью оформляется там и применяется ко всем слайдам, не ограничивая возможность изменения знака на отдельных слайдах.

Обычно считается, что водяной знак недоступен для редактирования другими пользователями. Чтобы предотвратить редактирование водяного знака (а точнее его родительской формы), Aspose.Slides предоставляет функции блокировки форм. Конкретную форму можно заблокировать как на обычном слайде, так и на мастере‑слайде. Когда форма водяного знака заблокирована на мастере‑слайде, она будет заблокирована на всех слайдах презентации.

Вы можете задать имя водяному знаку, чтобы в дальнейшем, при необходимости удалить его, найти его среди форм слайда по имени.

Водяной знак можно оформить любым способом; однако обычно у него есть общие свойства, такие как центрирование, вращение, расположение спереди и т.д. Ниже мы рассмотрим, как использовать эти свойства в примерах.

## **Текстовый водяной знак**

### **Добавление текстового водяного знака на слайд**

Чтобы добавить текстовый водяной знак в PPT, PPTX или ODP, сначала добавьте форму на слайд, затем добавьте к этой форме текстовый фрейм. Текстовый фрейм представляет класс [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/). Этот тип не наследуется от [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/), который предоставляет широкий набор свойств для гибкого позиционирования водяного знака. Поэтому объект [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) оборачивается в объект [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/). Чтобы добавить текст водяного знака в форму, используйте метод [addTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#addTextFrame) как показано ниже.
```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$watermarkShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```


{{% alert color="primary" title="See also" %}} 
- [How to Use the TextFrame Class](/slides/ru/php-java/text-formatting/)
{{% /alert %}}

### **Добавление текстового водяного знака в презентацию**

Если нужно добавить текстовый водяной знак во всю презентацию (т.е. на все слайды сразу), добавьте его в [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/). Дальнейшая логика такая же, как при добавлении знака на один слайд — создайте объект [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) и затем добавьте к нему водяной знак с помощью метода [addTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#addTextFrame).
```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$masterSlide = $presentation->getMasters()->get_Item(0);

$watermarkShape = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```


{{% alert color="primary" title="See also" %}} 
- [How to Use the Slide Master](/slides/ru/php-java/slide-master/)
{{% /alert %}}

### **Установка прозрачности формы водяного знака**

По умолчанию прямоугольная форма имеет цвета заливки и контура. Следующий код делает форму прозрачной.
```php
$watermarkShape->getFillFormat()->setFillType(FillType::NoFill);
$watermarkShape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
```


### **Установка шрифта для текстового водяного знака**

Вы можете изменить шрифт текстового водяного знака, как показано ниже.
```php
$textFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
$textFormat->setLatinFont(new FontData("Arial"));
$textFormat->setFontHeight(50);
```


### **Установка цвета текста водяного знака**

Чтобы задать цвет текста водяного знака, используйте следующий код:
```php
$alpha = 150;
$red = 200;
$green = 200;
$blue = 200;
$textColor = new Java("java.awt.Color", $red, $green, $blue, $alpha);

$fillFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();
$fillFormat->setFillType(FillType::Solid);
$fillFormat->getSolidFillColor()->setColor($textColor);
```


### **Центрирование текстового водяного знака**

Водяной знак можно центрировать на слайде, для чего выполните следующее:
```php
$slideSize = $presentation->getSlideSize()->getSize();
$slideWidth = java_values($slideSize->getWidth());
$slideHeight = java_values($slideSize->getHeight());

$watermarkWidth = 400;
$watermarkHeight = 40;
$watermarkX = ($slideWidth - $watermarkWidth) / 2;
$watermarkY = ($slideHeight - $watermarkHeight) / 2;

$watermarkShape = $slide->getShapes()->addAutoShape(
        ShapeType::Rectangle, $watermarkX, $watermarkY, $watermarkWidth, $watermarkHeight);

$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);
```


Ниже показан окончательный результат.

![The text watermark](text_watermark.png)

## **Графический водяной знак**

### **Добавление графического водяного знака в презентацию**

Чтобы добавить графический водяной знак на слайд презентации, выполните следующее:
```php
$image = Images::fromFile("watermark.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$watermarkShape->getFillFormat()->setFillType(FillType::Picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
```


### **Блокировка редактирования водяного знака**

Если требуется запретить редактирование водяного знака, используйте метод [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#getAutoShapeLock) у формы. С помощью этого свойства можно защитить форму от выбора, изменения размеров, перемещения, группировки с другими элементами, блокировать её текст от редактирования и многое другое:
```php
// Заблокировать форму водяного знака от изменения
$watermarkShape->getAutoShapeLock()->setSelectLocked(true);
$watermarkShape->getAutoShapeLock()->setSizeLocked(true);
$watermarkShape->getAutoShapeLock()->setTextLocked(true);
$watermarkShape->getAutoShapeLock()->setPositionLocked(true);
$watermarkShape->getAutoShapeLock()->setGroupingLocked(true);
```


### **Перемещение водяного знака на передний план**

В Aspose.Slides порядок слоёв форм можно задать методом [ShapeCollection.reorder](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#reorder). Для этого вызовите метод из списка слайдов презентации, передав ссылку на форму и номер её порядка. Таким образом можно переместить форму на передний план или отодвинуть её назад. Эта функция особенно полезна, когда нужно разместить водяной знак перед содержимым презентации:
```php
$shapeCount = java_values($slide->getShapes()->size());
$slide->getShapes()->reorder($shapeCount - 1, $watermarkShape);
```


### **Установка вращения водяного знака**

Ниже пример кода, показывающий, как задать вращение водяного знака, чтобы он располагался по диагонали слайда:
```php
$diagonalAngle = atan($slideWidth / $slideHeight) * 180 / M_PI;

$watermarkShape->setRotation($diagonalAngle);
```


### **Задание имени водяному знаку**

Aspose.Slides позволяет задать имя формы. Используя имя формы, в дальнейшем можно обратиться к ней для изменения или удаления. Чтобы задать имя формы водяного знака, присвойте его методу [AutoShape.setName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setName):
```php
$watermarkShape->setName("watermark");
```


### **Удаление водяного знака**

Чтобы удалить форму водяного знака, используйте метод [AutoShape.getName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getName) для поиска её среди форм слайда. Затем передайте найденную форму в метод [ShapeCollection.remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#remove):
```php
$slideShapes = $slide->getShapes()->toArray();
foreach ($slideShapes as $shape) {
    if ($shape->getName() === "watermark") {
        $slide->getShapes()->remove($shape);
    }
}
```


## **FAQ**

**Что такое водяной знак и зачем он нужен?**

Водяной знак — это наложенный на слайды текст или изображение, который помогает защищать интеллектуальную собственность, усиливать узнаваемость бренда или предотвращать несанкционированное использование презентаций.

**Можно ли добавить водяной знак на все слайды презентации?**

Да, Aspose.Slides позволяет программно добавить водяной знак на каждый слайд презентации. Можно пройтись по всем слайдам и применить настройки знака индивидуально.

**Как изменить прозрачность водяного знака?**

Прозрачность водяного знака можно изменить, задав параметры заливки ([getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getfillformat/)) формы. Это делает знак ненавязчивым и не отвлекает внимание от содержания слайда.

**Какие форматы изображений поддерживаются для водяных знаков?**

Aspose.Slides поддерживает различные форматы изображений, такие как PNG, JPEG, GIF, BMP, SVG и другие.

**Можно ли настроить шрифт и стиль текстового водяного знака?**

Да, вы можете выбрать любой шрифт, размер и стиль, чтобы они соответствовали дизайну вашей презентации и поддерживали согласованность бренда.

**Как изменить позицию или ориентацию водяного знака?**

Позицию и ориентацию водяного знака можно программно изменить, задав координаты, размер и угол вращения формы.