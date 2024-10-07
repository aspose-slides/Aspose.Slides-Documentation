---
title: علامة مائية
type: docs
weight: 40
url: /php-java/watermark/
keywords:
- علامة مائية
- إضافة علامة مائية
- علامة مائية نصية
- علامة مائية صورة
- PowerPoint
- عرض تقديمي
- PHP
- Java
- Aspose.Slides لـ PHP عبر Java
description: "إضافة علامات مائية نصية وصور إلى عروض PowerPoint في PHP"
---

## **عن العلامات المائية**

**العلامة المائية** في العرض التقديمي هي ختم نصي أو صورة يُستخدم على شريحة أو في جميع شرائح العرض التقديمي. عادةً ما تُستخدم العلامة المائية للإشارة إلى أن العرض التقديمي مسودة (على سبيل المثال، علامة مائية "مسودة")، أنه يحتوي على معلومات سرية (على سبيل المثال، علامة مائية "سري")، لتحديد الشركة التابعة لها (على سبيل المثال، علامة مائية "اسم الشركة")، للتعرف على مؤلف العرض التقديمي، إلخ. تساعد العلامات المائية في منع انتهاكات حقوق الطبع والنشر من خلال الإشارة إلى أن العرض التقديمي لا ينبغي نسخه. تُستخدم العلامات المائية في كل من تنسيقات عرض PowerPoint وOpenOffice. في Aspose.Slides، يمكنك إضافة علامة مائية إلى تنسيقات ملفات PowerPoint PPT وPPTX وOpenOffice ODP.

في [**Aspose.Slides**](https://products.aspose.com/slides/php-java/)، هناك طرق مختلفة يمكنك من خلالها إنشاء علامات مائية في مستندات PowerPoint أو OpenOffice وتعديل تصميمها وسلوكها. السمة المشتركة هي أنه لإضافة علامات مائية نصية، يجب عليك استخدام فئة [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)، ولإضافة علامات مائية صور، استخدم فئة [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) أو املأ شكل العلامة المائية بصورة. تقوم `PictureFrame` بتنفيذ فئة [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/)، مما يتيح لك استخدام جميع إعدادات كائن الشكل المرنة. حيث أن `ITextFrame` ليست شكلاً وإعداداتها محدودة، فإنها تلتف داخل كائن [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/).

هناك طريقتان يمكن تطبيق العلامة المائية من خلالهما: على شريحة واحدة أو على جميع شرائح العرض التقديمي. يتم استخدام شريحة الماستر لتطبيق علامة مائية على جميع شرائح العرض التقديمي - تُضاف العلامة المائية إلى شريحة الماستر، وتصمم بالكامل هناك، وتطبق على جميع الشرائح دون التأثير على الإذن بتعديل العلامة المائية على الشرائح الفردية.

تُعتبر العلامة المائية عادة غير متاحة للتعديل من قبل مستخدمين آخرين. لمنع تعديل العلامة المائية (أو بالأحرى شكل العلامة المائية) من التح编辑، توفر Aspose.Slides وظيفة قفل الشكل. يمكن قفل شكل معين على شريحة عادية أو على شريحة الماستر. عندما يكون شكل العلامة المائية مقفلاً على شريحة الماستر، سيكون مقفلاً على جميع شرائح العرض التقديمي.

يمكنك تعيين اسم للعلامة المائية حتى تتمكن في المستقبل، إذا كنت تريد حذفها، من العثور عليها في أشكال الشريحة بالاسم.

يمكنك تصميم العلامة المائية بأي طريقة؛ ومع ذلك، هناك عادة ميزات شائعة في العلامات المائية، مثل المحاذاة في الوسط، الدوران، الموضع الأمامي، إلخ. سننظر في كيفية استخدام هذه الميزات في الأمثلة أدناه.

## **علامة مائية نصية**

### **إضافة علامة مائية نصية إلى شريحة**

لإضافة علامة مائية نصية في PPT أو PPTX أو ODP، يمكنك أولاً إضافة شكل إلى الشريحة، ثم إضافة إطار نص إلى هذا الشكل. يتم تمثيل إطار النص بواسطة فئة [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/). هذا النوع ليس موروثًا من [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/)، والذي يحتوي على مجموعة واسعة من الخصائص لوضع العلامة المائية بطريقة مرنة. لذلك، يتم لف كائن [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) داخل كائن [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/). لإضافة نص العلامة المائية إلى الشكل، استخدم طريقة [addTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#addTextFrame) كما هو موضح أدناه.

```php
$watermarkText = "سري";

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$watermarkShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="راجع أيضاً" %}} 
- [كيفية استخدام فئة TextFrame](/slides/php-java/text-formatting/)
{{% /alert %}}

### **إضافة علامة مائية نصية إلى عرض تقديمي**

إذا كنت ترغب في إضافة علامة مائية نصية إلى العرض التقديمي بالكامل (أي، جميع الشرائح دفعة واحدة)، أضفها إلى [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/). باقي المنطق هو نفسه كما عند إضافة علامة مائية إلى شريحة واحدة - إنشاء كائن [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) ثم إضافة العلامة المائية إليه باستخدام طريقة [addTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#addTextFrame).

```php
$watermarkText = "سري";

$presentation = new Presentation();
$masterSlide = $presentation->getMasters()->get_Item(0);

$watermarkShape = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="راجع أيضاً" %}} 
- [كيفية استخدام شريحة الماستر](/slides/php-java/slide-master/)
{{% /alert %}}

### **تعيين شفافية شكل العلامة المائية**

بشكل افتراضي، يتم تصميم الشكل المستطيل بألوان التعبئة والخط. تجعل الأسطر التالية من التعليمات البرمجية الشكل شفافًا.

```php
$watermarkShape->getFillFormat()->setFillType(FillType::NoFill);
$watermarkShape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
```

### **تعيين الخط لعلامة مائية نصية**

يمكنك تغيير خط نص العلامة المائية كما هو موضح أدناه.

```php
$textFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
$textFormat->setLatinFont(new FontData("Arial"));
$textFormat->setFontHeight(50);
```

### **تعيين لون نص العلامة المائية**

لتعيين لون نص العلامة المائية، استخدم هذا الرمز:

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

### **تمركز علامة مائية نصية**

من الممكن تمركز العلامة المائية على شريحة، ومن أجل ذلك يمكنك القيام بما يلي:

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

يظهر الشكل أدناه النتيجة النهائية.

![علامة مائية نصية](text_watermark.png)

## **علامة مائية صورة**

### **إضافة علامة مائية صورة إلى عرض تقديمي**

لإضافة علامة مائية صورة إلى شريحة عرض تقديمي، يمكنك القيام بما يلي:

```php
$image = Images::fromFile("watermark.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$watermarkShape->getFillFormat()->setFillType(FillType::Picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
```

## **قفل علامة مائية لمنع التعديل**

إذا كان من الضروري منع تعديل العلامة المائية، استخدم طريقة [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#getAutoShapeLock) على الشكل. باستخدام هذه الخاصية، يمكنك حماية الشكل من التحديد، إعادة الحجم، إعادة الموضع، التجميع مع عناصر أخرى، قفل نصه من التعديل، والعديد من الأمور الأخرى:

```php
// قفل شكل العلامة المائية من التعديل
$watermarkShape->getAutoShapeLock()->setSelectLocked(true);
$watermarkShape->getAutoShapeLock()->setSizeLocked(true);
$watermarkShape->getAutoShapeLock()->setTextLocked(true);
$watermarkShape->getAutoShapeLock()->setPositionLocked(true);
$watermarkShape->getAutoShapeLock()->setGroupingLocked(true);
```

## **إحضار علامة مائية إلى الأمام**

في Aspose.Slides، يمكن تعيين ترتيب الأشكال عبر طريقة [ShapeCollection.reorder](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#reorder). للقيام بذلك، تحتاج إلى استدعاء هذه الطريقة من قائمة شرائح العرض التقديمي وتمرير المرجع إلى الشكل ورقم ترتيبه إلى الطريقة. بهذه الطريقة، يمكنك إحضار شكل إلى الأمام أو إرساله إلى الجزء الخلفي من الشريحة. هذه الميزة مفيدة بشكل خاص إذا كنت بحاجة لوضع علامة مائية أمام العرض التقديمي:

```php
$shapeCount = java_values($slide->getShapes()->size());
$slide->getShapes()->reorder($shapeCount - 1, $watermarkShape);
```

## **تعيين دوران العلامة المائية**

إليك نموذج شفرة لكيفية ضبط دوران العلامة المائية بحيث تكون موضوعة بشكل قطري عبر الشريحة:

```php
$diagonalAngle = atan($slideWidth / $slideHeight) * 180 / M_PI;

$watermarkShape->setRotation($diagonalAngle);
```

## **تعيين اسم للعلامة المائية**

تسمح لك Aspose.Slides بتعيين اسم لشكل. باستخدام اسم الشكل، يمكنك الوصول إليه في المستقبل لتعديله أو حذفه. لتعيين اسم شكل العلامة المائية، قم بتعيينه إلى طريقة [AutoShape.setName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setName):

```php
$watermarkShape->setName("علامة مائية");
```

## **إزالة علامة مائية**

لإزالة شكل العلامة المائية، استخدم طريقة [AutoShape.getName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getName) للعثور عليها في أشكال الشريحة. ثم، قم بتمرير شكل العلامة المائية إلى طريقة [ShapeCollection.remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#remove):

```php
$slideShapes = $slide->getShapes()->toArray();
foreach ($slideShapes as $shape) {
    if ($shape->getName() === "علامة مائية") {
        $slide->getShapes()->remove($shape);
    }
}
```

## **مثال حي**

قد ترغب في الاطلاع على **Aspose.Slides المجاني** [إضافة علامة مائية](https://products.aspose.app/slides/watermark) و [إزالة علامة مائية](https://products.aspose.app/slides/watermark/remove-watermark) أدوات عبر الإنترنت.

![أدوات عبر الإنترنت لإضافة وإزالة العلامات المائية](online_tools.png)