---
title: إضافة علامات مائية إلى العروض التقديمية في PHP
linktitle: علامة مائية
type: docs
weight: 40
url: /ar/php-java/watermark/
keywords:
- علامة مائية
- علامة مائية نصية
- علامة مائية صورة
- إضافة علامة مائية
- تغيير علامة مائية
- إزالة علامة مائية
- حذف علامة مائية
- إضافة علامة مائية إلى PPT
- إضافة علامة مائية إلى PPTX
- إضافة علامة مائية إلى ODP
- إزالة علامة مائية من PPT
- إزالة علامة مائية من PPTX
- إزالة علامة مائية من ODP
- حذف علامة مائية من PPT
- حذف علامة مائية من PPTX
- حذف علامة مائية من ODP
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إدارة العلامات المائية النصية والصورية في عروض PowerPoint وOpenDocument باستخدام PHP لتحديد مسودة أو معلومات سرية أو حقوق طبع ونشر والمزيد."
---

## **حول العلامات المائية**

**العلامة المائية** في العرض التقديمي هي طابع نصي أو صورة يُستخدم على شريحة واحدة أو على جميع شرائح العرض. عادةً تُستَخدم العلامة المائية للإشارة إلى أن العرض هو مسودة (مثل العلامة “مسودة”)، أو أنه يحتوي على معلومات سرية (مثل العلامة “سري”)، لتحديد الشركة المالكة (مثل العلامة “اسم الشركة”)، لتحديد مؤلف العرض، وما إلى ذلك. تساعد العلامة المائية على منع انتهاك حقوق النشر من خلال الإشارة إلى أن العرض لا ينبغي نسخه. تُستخدم العلامات المائية في صيغتي PowerPoint وOpenOffice. في Aspose.Slides يمكنك إضافة علامة مائية إلى صيغ ملفات PowerPoint PPT وPPTX وOpenOffice ODP.

في [**Aspose.Slides**](https://products.aspose.com/slides/php-java/)، هناك طرق متعددة لإنشاء علامات مائية في مستندات PowerPoint أو OpenOffice وتعديل تصميمها وسلوكها. الجانب المشترك هو أنه لإضافة علامات مائية نصية يجب استخدام الفئة [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)، ولإضافة علامات مائية صورة، استخدم الفئة [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) أو ملء شكل العلامة المائية بصورة. `PictureFrame` تنفذ الفئة [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) مما يتيح لك الاستفادة من جميع إعدادات الشكل المرنة. بما أن `ITextFrame` ليس شكلاً ولا إعداداته محدودة، فإنه يتم تغليفه في كائن [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/).

هناك طريقتان لتطبيق العلامة المائية: على شريحة واحدة أو على جميع شرائح العرض. يُستخدم Slide Master لتطبيق العلامة المائية على جميع الشرائح — يتم إضافة العلامة إلى Slide Master وتصميمها هناك بالكامل، ثم تُطبّق على جميع الشرائح دون أن تؤثر على إمكانية تعديل العلامة على الشرائح الفردية.

عادةً ما تُعتبر العلامة المائية غير قابلة للتحرير من قبل المستخدمين الآخرين. لمنع تعديل العلامة المائية (أو الشكل الأب للعلامة) توفر Aspose.Slides وظيفة قفل الشكل. يمكن قفل شكل معين في شريحة عادية أو في Slide Master. عندما يُقفل شكل العلامة على Slide Master، يُقفل على جميع شرائح العرض.

يمكنك تعيين اسم للعلامة المائية حتى تتمكن في المستقبل من حذفها بسهولة عبر البحث عن الشكل بالاسم في الشرائح.

يمكنك تصميم العلامة المائية بأي طريقة؛ ومع ذلك توجد خصائص شائعة للعلامات المائية مثل المحاذاة المركزية، الدوران، الموضع الأمامي، وما إلى ذلك. سنستعرض كيفية استخدام هذه الخصائص في الأمثلة أدناه.

## **علامة مائية نصية**

### **إضافة علامة مائية نصية إلى شريحة**

لإضافة علامة مائية نصية في PPT أو PPTX أو ODP، يمكنك أولاً إضافة شكل إلى الشريحة، ثم إضافة إطار نص إلى هذا الشكل. يُمثَّل إطار النص بالفئة [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/). هذا النوع ليس مُشتقًا من [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/)، الذي يحتوي على مجموعة واسعة من الخصائص لتحديد موضع العلامة المائية بشكل مرن. لذلك يتم تغليف كائن [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) داخل كائن [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/). لإضافة نص العلامة إلى الشكل، استخدم الطريقة [addTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#addTextFrame) كما هو موضح أدناه.
```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$watermarkShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```


{{% alert color="primary" title="انظر أيضًا" %}} 
- [How to Use the TextFrame Class](/slides/ar/php-java/text-formatting/)
{{% /alert %}}

### **إضافة علامة مائية نصية إلى عرض تقديمي كامل**

إذا أردت إضافة علامة مائية نصية إلى كامل العرض (أي جميع الشرائح مرة واحدة)، أضفها إلى [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/). يبقى منطق العملية كما هو عند إضافة علامة مائية إلى شريحة واحدة — أنشئ كائن [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) ثم أضف العلامة إليه باستخدام الطريقة [addTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#addTextFrame).
```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$masterSlide = $presentation->getMasters()->get_Item(0);

$watermarkShape = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```


{{% alert color="primary" title="انظر أيضًا" %}} 
- [How to Use the Slide Master](/slides/ar/php-java/slide-master/)
{{% /alert %}}

### **تعيين شفافية شكل العلامة المائية**

بشكل افتراضي، يتم تنسيق شكل المستطيل بألوان ملء وخط. السطور التالية من الشيفرة تجعل الشكل شفافًا.
```php
$watermarkShape->getFillFormat()->setFillType(FillType::NoFill);
$watermarkShape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
```


### **تعيين خط للعلامة المائية النصية**

يمكنك تغيير خط النص للعلامة المائية كما هو موضح أدناه.
```php
$textFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
$textFormat->setLatinFont(new FontData("Arial"));
$textFormat->setFontHeight(50);
```


### **تعيين لون نص العلامة المائية**

لتعيين لون نص العلامة، استخدم الشيفرة التالية:
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


### **محاذاة العلامة المائية في المركز**

يمكنك محاذاة العلامة في وسط الشريحة، وذلك عبر تنفيذ الشيفرة التالية:
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


الصورة أدناه تُظهر النتيجة النهائية.

![The text watermark](text_watermark.png)

## **علامة مائية صورة**

### **إضافة علامة مائية صورة إلى عرض تقديمي**

لإضافة علامة مائية صورة إلى شريحة عرض تقديمي، يمكنك اتباع الخطوات التالية:
```php
$image = Images::fromFile("watermark.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$watermarkShape->getFillFormat()->setFillType(FillType::Picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
```


### **قفل العلامة المائية لمنع تعديلها**

إذا كان من الضروري منع تعديل العلامة المائية، استخدم الطريقة [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#getAutoShapeLock) على الشكل. من خلال هذه الخاصية يمكنك حماية الشكل من الاختيار، وتغيير حجمه، وإعادة تموضعه، وتجميعه مع عناصر أخرى، وقفل النص من التحرير، وأكثر من ذلك:
```php
// قفل شكل العلامة المائية من التعديل
$watermarkShape->getAutoShapeLock()->setSelectLocked(true);
$watermarkShape->getAutoShapeLock()->setSizeLocked(true);
$watermarkShape->getAutoShapeLock()->setTextLocked(true);
$watermarkShape->getAutoShapeLock()->setPositionLocked(true);
$watermarkShape->getAutoShapeLock()->setGroupingLocked(true);
```


### **إحضار العلامة المائية إلى المقدمة**

في Aspose.Slides، يمكن تعيين ترتيب Z للأشكال عبر الطريقة [ShapeCollection.reorder](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#reorder). للقيام بذلك، استدعِ هذه الطريقة من قائمة شرائح العرض ومرّر مرجع الشكل ورقم ترتيبه. بهذه الطريقة يمكن إحضار الشكل إلى المقدمة أو إرساله إلى الخلف. هذه الميزة مفيدة خاصةً إذا أردت وضع العلامة المائية أمام محتوى العرض:
```php
$shapeCount = java_values($slide->getShapes()->size());
$slide->getShapes()->reorder($shapeCount - 1, $watermarkShape);
```


### **تعيين دوران العلامة المائية**

فيما يلي مثال على شفرة لتعديل دوران العلامة بحيث تكون مائلة عبر الشريحة:
```php
$diagonalAngle = atan($slideWidth / $slideHeight) * 180 / M_PI;

$watermarkShape->setRotation($diagonalAngle);
```


### **تعيين اسم للعلامة المائية**

يسمح Aspose.Slides لك بتعيين اسم للشكل. باستخدام اسم الشكل يمكنك الوصول إليه لاحقًا لتعديله أو حذفه. لتعيين اسم لشكل العلامة المائية، استخدم الطريقة [AutoShape.setName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setName):
```php
$watermarkShape->setName("watermark");
```


### **إزالة العلامة المائية**

لإزالة شكل العلامة المائية، استخدم الطريقة [AutoShape.getName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getName) للعثور عليه في أشكال الشريحة. ثم مرّر الشكل إلى الطريقة [ShapeCollection.remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#remove):
```php
$slideShapes = $slide->getShapes()->toArray();
foreach ($slideShapes as $shape) {
    if ($shape->getName() === "watermark") {
        $slide->getShapes()->remove($shape);
    }
}
```


## **الأسئلة الشائعة**

**ما هي العلامة المائية ولماذا يجب استخدامها؟**

العلامة المائية هي طبقة نصية أو صورية تُطبق على الشرائح لحماية الملكية الفكرية، تعزيز التعرف على العلامة التجارية، أو منع الاستخدام غير المصرح به للعرض.

**هل يمكنني إضافة علامة مائية إلى جميع الشرائح في العرض؟**

نعم، تتيح لك Aspose.Slides إضافة علامة مائية برمجيًا إلى كل شريحة في العرض. يمكنك التنقل عبر جميع الشرائح وتطبيق إعدادات العلامة مائية على كل واحدة على حدة.

**كيف يمكنني ضبط شفافية العلامة المائية؟**

يمكنك تعديل شفافية العلامة عبر تعديل إعدادات الملء ([getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getfillformat/)) للشكل. يضمن ذلك أن تكون العلامة خفيفة ولا تشتت الانتباه عن محتوى الشريحة.

**ما صيغ الصور المدعومة للعلامات المائية؟**

تدعم Aspose.Slides صيغ صور متعددة مثل PNG وJPEG وGIF وBMP وSVG وغيرها.

**هل يمكنني تخصيص خط ونمط العلامة المائية النصية؟**

نعم، يمكنك اختيار أي خط وحجم ونمط لتتناسب مع تصميم العرض وتحقق اتساق العلامة التجارية.

**كيف أغير موضع أو اتجاه العلامة المائية؟**

يمكنك تعديل موضع واتجاه العلامة مبرمجيًا عبر تعديل إحداثيات الشكل وحجمه وخصائص الدوران.