---
title: Водяной знак
type: docs
weight: 40
url: /php-java/watermark/
keywords: "водяной знак в презентации"
description: "Используйте водяной знак в PowerPoint с помощью Aspose.Slides. Добавьте водяной знак в ppt-презентацию или удалите водяной знак. Вставьте изображение водяного знака или текстовый водяной знак."
---


## **О водяном знаке**
**Водяной знак** в презентации — это текстовый или изображенческий штамп, использующийся на слайде или на всех слайдах презентации. Обычно водяной знак используется для указания на то, что презентация является черновиком (например, водяной знак "Черновик"); что она содержит конфиденциальную информацию (например, водяной знак "Конфиденциально"); для указания, к какой компании она принадлежит (например, водяной знак с "Название компании"); для идентификации автора презентации и т. д. Водяной знак помогает предотвратить нарушение авторских прав на презентацию, указывая на то, что презентацию нельзя копировать. Водяные знаки используются как в форматах презентаций PowerPoint, так и OpenOffice. В Aspose.Slides вы можете добавить водяной знак в форматах файлов PowerPoint PPT, PPTX и OpenOffice ODP.

В [**Aspose.Slides**](https://products.aspose.com/slides/php-java/) есть различные способы создания водяного знака в PowerPoint или OpenOffice, чтобы обернуть его в разные формы, изменить дизайн и поведение и т. д. Общее в том, что для добавления текстовых водяных знаков вы должны использовать класс [**TextFrame**](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame), а для добавления изображения водяного знака - [**PictureFrame**](https://reference.aspose.com/slides/php-java/aspose.slides/PictureFrame/). [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/PictureFrame/) реализует интерфейс [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) и может использовать всю мощь гибких настроек объекта формы. [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) не является формой, и его настройки ограничены. Поэтому рекомендуется оборачивать объект [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) в объект [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape).

Существует два способа применения водяного знака: к одному слайду и ко всем слайдам презентации. Слайд-мастер используется для применения водяного знака ко всем слайдам презентации — водяной знак добавляется в слайд-мастер, полностью разрабатывается там и применяется ко всем слайдам без изменения разрешения на редактирование водяного знака на слайдах.

Водяной знак обычно считается недоступным для редактирования другими пользователями. Чтобы предотвратить редактирование водяного знака (или, скорее, родительской формы водяного знака), Aspose.Slides предоставляет функциональность блокировки формы. Определенная форма может быть зафиксирована на обычном слайде или на слайде-мастере. При блокировке формы водяного знака на слайде-мастере она будет заблокирована на всех слайдах презентации.

Вы можете установить имя водяного знака, чтобы в будущем, если вы захотите удалить водяной знак, вы могли найти его в формах слайда по имени.

Вы можете разрабатывать водяной знак любым образом, однако обычно в водяных знаках присутствуют общие характеристики, такие как: центрированное выравнивание, вращение, передняя позиция и т. д. Мы рассмотрим, как использовать их в примерах ниже.
## **Текстовый водяной знак**
### **Добавить текстовый водяной знак на слайд**
Чтобы добавить текстовый водяной знак в PPT, PPTX или ODP, вы можете сначала добавить форму на слайд, а затем добавить текстовый фрейм в эту форму. Текстовый фрейм представлен типом [**TextFrame**](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame). Этот тип не наследуется от [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape), который имеет широкий набор свойств для настройки водяного знака гибким образом. Поэтому рекомендуется оборачивать объект [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) в объект [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape). Чтобы добавить водяной знак в форму, используйте метод [**addTextFrame**](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape#addTextFrame-java.lang.String-) с текстом водяного знака, переданным в него:

```php
  # Откройте презентацию
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $watermarkShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 0, 0, 0, 0);
    $watermarkTextFrame = $watermarkShape->addTextFrame("Водяной знак");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```



{{% alert color="primary" title="Смотрите также" %}} 
- [Как использовать ](/slides/php-java/slide-master/)[TextFrame](/slides/php-java/adding-and-formatting-text/)
{{% /alert %}}

### **Добавить текстовый водяной знак в презентацию**
Если вы хотите добавить водяной знак в презентацию (каждый слайд сразу), добавьте его в [**MasterSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide).
Вся остальная логика такая же, как при добавлении водяного знака на один слайд — создать объект [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) и затем добавить водяной знак в него с помощью метода [**addTextFrame**](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape#addTextFrame-java.lang.String-):

```php
  # Откройте презентацию
  $pres = new Presentation();
  try {
    $master = $pres->getMasters()->get_Item(0);
    $watermarkShape = $master->getShapes()->addAutoShape(ShapeType::Triangle, 0, 0, 0, 0);
    $watermarkTextFrame = $watermarkShape->addTextFrame("Водяной знак");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" title="Смотрите также" %}} 
- [Как использовать ](/slides/php-java/slide-master/)[Слайд-мастер](/slides/php-java/slide-master/)
{{% /alert %}}

### **Установить шрифт текстового водяного знака**
Вы можете изменить шрифт текстового водяного знака:

```php
  $watermarkPortion = $watermarkTextFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
  $watermarkPortion->getPortionFormat()->setFontBold(NullableBool::True);
  $watermarkPortion->getPortionFormat()->setFontHeight(52);

```


### **Установить прозрачность текстового водяного знака**
Чтобы установить прозрачность текстового водяного знака, используйте этот код:

```php
  $alpha = 150;
  $red = 200;
  $green = 200;
  $blue = 200;
  $watermarkPortion = $watermarkTextFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
  $watermarkPortion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
  $watermarkPortion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", $red, $green, $blue, $alpha));

```


### **Центрировать текстовый водяной знак**
Центрировать водяной знак на слайде можно следующим образом:

```php
  $center = new Point2DFloat($pres->getSlideSize()->getSize()->getWidth() / 2, $pres->getSlideSize()->getSize()->getHeight() / 2);
  $width = 300;
  $height = 300;
  $x = $center->getX() - $width / 2;
  $y = $center->getY() - $height / 2;
  # ...
  $watermarkShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, $x, $y, $width, $height);

```


## **Изображенческий водяной знак**
### **Добавить изображенческий водяной знак в презентацию**
Чтобы добавить изображенческий водяной знак на все слайды презентации, можно сделать следующее:

```php
  $picture;
  $image = Images->fromFile("watermark.png");
  try {
    $picture = $pres->getImages()->addImage($image);
  } finally {
    if (!java_is_null($image)) {
      $image->dispose();
    }
  }
  # ...
  $watermarkShape->getFillFormat()->setFillType(FillType::Picture);
  $watermarkShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
  $watermarkShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);

```




## **Заблокировать водяной знак от редактирования**
Если необходимо предотвратить редактирование водяного знака, используйте метод [**AutoShape.getShapeLock**](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape#getShapeLock--) на форме, которая его оборачивает. С помощью этого метода вы можете защитить форму от выбора, изменения размера, изменения положения, группировки с другими элементами, заблокировать текст для редактирования и многое другое:

```php
  # Заблокировать формы от изменения
  $watermarkShape->getShapeLock()->setSelectLocked(true);
  $watermarkShape->getShapeLock()->setSizeLocked(true);
  $watermarkShape->getShapeLock()->setTextLocked(true);
  $watermarkShape->getShapeLock()->setPositionLocked(true);
  $watermarkShape->getShapeLock()->setGroupingLocked(true);

```

{{% alert color="primary" title="Смотрите также" %}} 
- [Как заблокировать формы от редактирования](/slides/php-java/presentation-locking/)
{{% /alert %}}

## **Переместить водяной знак на передний план**
В Aspose.Slides порядок наложения форм можно установить с помощью метода [**SlideCollection.reorder**](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection#reorder-int-com.aspose.slides.ISlide...-). Для этого вам нужно вызвать этот метод из списка слайдов презентации и передать ссылку на форму и её номер порядка в метод. Таким образом, можно поместить форму на передний или задний план слайда. Эта функция особенно полезна, если нужно разместить водяной знак на переднем плане презентации:

```php
  $slide->getShapes()->reorder($slide->getShapes()->size() - 1, $watermarkShape);

```


## **Установить вращение водяного знака**
Вот пример, как установить вращение водяного знака (и его родительской формы):

```php
  $h = $pres->getSlideSize()->getSize()->getHeight();
  $w = $pres->getSlideSize()->getSize()->getWidth();
  $watermarkShape->setX($w - $watermarkShape->getWidth() / 2);
  $watermarkShape->setY($h - $watermarkShape->getHeight() / 2);
  $watermarkShape->setRotation(calculateRotation($h, $w));

```

```php

```


## **Установить имя для водяного знака**
Aspose.Slides позволяет установить имя формы. По имени формы вы можете обратиться к ней в будущем, чтобы изменить или удалить. Чтобы установить имя родительской формы водяного знака — установите его в методе [**AutoShape.getName**](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getName--):



```php
  $watermarkShape->setName("водяной знак");

```


## **Удалить водяной знак**
Чтобы удалить форму водяного знака и его дочерние элементы с слайда, используйте метод [AutoShape.getName](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getName--) для поиска в формах слайда. Затем передайте форму водяного знака в метод [**ShapeCollection.remove**](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeCollection#remove-com.aspose.slides.IShape-) :

```php
  for($i = 0; $i < java_values($slide->getShapes()->size()) ; $i++) {
    $shape = $slide->getShapes()->get_Item($i);
    if ("водяной знак"->equals($shape->getName())) {
      $slide->getShapes()->remove($watermarkShape);
    }
  }
```


## **Пример в реальном времени**
Вам может быть интересно ознакомиться с **Aspose.Slides** **бесплатными** [**Добавить водяной знак** ](https://products.aspose.app/slides/watermark) и [**Удалить водяной знак**](https://products.aspose.app/slides/watermark/remove-watermark) онлайн инструментами. 

![todo:image_alt_text](slides-watermark.png)