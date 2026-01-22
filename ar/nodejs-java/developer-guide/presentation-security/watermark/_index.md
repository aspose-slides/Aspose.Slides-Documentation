---
title: إضافة علامات مائية إلى العروض التقديمية في JavaScript
linktitle: العلامة المائية
type: docs
weight: 40
url: /ar/nodejs-java/watermark/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "إدارة العلامات المائية النصية والصورية في عروض PowerPoint وOpenDocument التقديمية باستخدام Node.js لتحديد مسودة أو معلومات سرية أو حقوق طبع والنشر والمزيد."
---

## **حول العلامة المائية**

**العلامة المائية** في العرض التقديمي هي ختم نصي أو صورة يُستخدم على شريحة واحدة أو عبر جميع شرائح العرض. عادةً ما تُستعمل العلامة المائية للإشارة إلى أن العرض مسودة (مثل علامة "مسودة")، أو أنه يحتوي على معلومات سرية (مثل علامة "سري")، لتحديد الشركة المالكة (مثل علامة "اسم الشركة")، لتحديد مؤلف العرض، وما إلى ذلك. تساعد العلامة المائية على منع انتهاك حقوق النشر من خلال الإشارة إلى أن العرض لا يجب نسخه. تُستخدم العلامات المائية في صيغتي PowerPoint وOpenOffice. في Aspose.Slides، يمكنك إضافة علامة مائية إلى صيغ ملفات PowerPoint PPT وPPTX وOpenOffice ODP.

في [**Aspose.Slides**](https://products.aspose.com/slides/nodejs-java/)، توجد طرق مختلفة لإنشاء علامات مائية في مستندات PowerPoint أو OpenOffice وتعديل تصميمها وسلوكها. الجانب المشترك هو أنه لإضافة علامات مائية نصية، يجب استخدام نوع [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/)، ولإضافة علامات مائية صورة، استخدم فئة [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) أو ملء شكل العلامة المائية بصورة. `PictureFrame` يطبق نوع [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/)، مما يتيح لك استخدام جميع الإعدادات المرنة لكائن الشكل. بما أن `TextFrame` ليس شكلاً وإعداداته محدودة، فهو يُلف داخل كائن [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/).

هناك طريقتان لتطبيق العلامة المائية: على شريحة واحدة أو على جميع شرائح العرض. يُستخدم **Slide Master** لتطبيق العلامة المائية على جميع الشرائح — تُضاف العلامة إلى الـ Slide Master، يتم تصميمها بالكامل هناك، وتُطبّق على جميع الشرائح دون أن تؤثر على إذن تعديل العلامة على الشرائح الفردية.

عادةً ما تُعتبر العلامة المائية غير قابلة للتحرير من قبل المستخدمين الآخرين. لمنع تحرير العلامة المائية (أو الشكل الأب للعلامة المائية)، توفر Aspose.Slides وظيفة قفل الشكل. يمكن قفل شكل معين على شريحة عادية أو على Slide Master. عندما يُقفل شكل العلامة المائية على الـ Slide Master، يُقفل على جميع شرائح العرض.

يمكنك تعيين اسم للعلامة المائية بحيث يمكنك في المستقبل، إذا رغبت بحذفها، العثور عليها بين أشكال الشريحة بالاسم.

يمكنك تصميم العلامة المائية بأي طريقة؛ مع ذلك، هناك ميزات شائعة في العلامات المائية مثل المحاذاة المركزية، الدوران، الموضع الأمامي، إلخ. سنستعرض كيفية استخدامها في الأمثلة أدناه.

## **علامة مائية نصية**

### **إضافة علامة مائية نصية إلى الشريحة**
لإضافة علامة مائية نصية في PPT أو PPTX أو ODP، يمكنك أولاً إضافة شكل إلى الشريحة، ثم إضافة إطار نص إلى هذا الشكل. يُمثَّل إطار النص بنوع [**TextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame). هذا النوع غير وراث من [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape)، الذي يحتوي على مجموعة واسعة من الخصائص لتحديد موضع العلامة المائية بطريقة مرنة. لذلك، يُلف كائن [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) داخل كائن [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape). لإضافة نص العلامة المائية إلى الشكل، استخدم طريقة [**addTextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) مع تمرير نص العلامة المائية إليها:
```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let slide = presentation.getSlides().get_Item(0);

let watermarkShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="انظر أيضًا" %}} 
- كيفية استخدام [TextFrame](/slides/ar/nodejs-java/text-formatting/).
{{% /alert %}}

### **إضافة علامة مائية نصية إلى العرض**
إذا رغبت في إضافة علامة مائية نصية إلى العرض بالكامل (أي جميع الشرائح مرة واحدة)، أضفها إلى [**MasterSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide). باقي المنطق هو نفسه كما عند إضافة علامة مائية إلى شريحة واحدة — أنشئ كائن [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) ثم أضف العلامة المائية إليه باستخدام طريقة [**addTextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-):
```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let masterSlide = presentation.getMasters().get_Item(0);

let watermarkShape = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="انظر أيضًا" %}} 
- [كيفية الاستخدام ](/slides/ar/nodejs-java/slide-master/)[Slide Master](/slides/ar/nodejs-java/slide-master/)
{{% /alert %}}

### **تعيين شفافية شكل العلامة المائية**
افتراضيًا، يكون شكل المستطيل مُصممًا بألوان التعبئة والحد. الأسطر التالية من الشيفرة تجعل الشكل شفافًا.
```javascript
watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
watermarkShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
```


### **تعيين الخط للعلامة المائية النصية**
يمكنك تغيير خط العلامة المائية النصية كما هو موضح أدناه.
```javascript
let textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new aspose.slides.FontData("Arial"));
textFormat.setFontHeight(50);
```


### **تعيين لون نص العلامة المائية**
لتعيين لون نص العلامة المائية، استخدم الشيفرة التالية:
```java
let alpha = 150;
let red = 200;
let green = 200;
let blue = 200;

let fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
fillFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", red, green, blue, alpha));
```


### **محاذاة العلامة المائية نصيًا إلى الوسط**
يمكنك مركزية العلامة المائية على الشريحة كما يلي:
```javascript
const watermarkWidth = 400;
const watermarkHeight = 40;
const watermarkX = (slideSize.getWidth() - watermarkWidth) / 2;
const watermarkY = (slideSize.getHeight() - watermarkHeight) / 2;

let watermarkShape = masterSlide.getShapes().addAutoShape(
        aspose.slides.ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);
        
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```


الصورة أدناه تُظهر النتيجة النهائية.

![The text watermark](text_watermark.png)

## **علامة مائية صورة**

### **إضافة علامة مائية صورة إلى العرض**
لإضافة علامة مائية صورة إلى جميع شرائح العرض، يمكنك القيام بما يلي:
```javascript
let watermarkImage = aspose.slides.Images.fromFile("watermark.png");
let image = presentation.getImages().addImage(watermarkImage);

// ...

watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
```


### **قفل العلامة المائية من التحرير**
إذا كان من الضروري منع تحرير العلامة المائية، استخدم طريقة [**AutoShape.getShapeLock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#getShapeLock--) على الشكل. بهذه الخاصية، يمكنك حماية الشكل من الاختيار، وإعادة الحجم، وإعادة التموضع، وتجميعه مع عناصر أخرى، وقفل النص من التحرير، وأكثر من ذلك:
```javascript
// قفل شكل العلامة المائية من التعديل
watermarkShape.getShapeLock().setSelectLocked(true);
watermarkShape.getShapeLock().setSizeLocked(true);
watermarkShape.getShapeLock().setTextLocked(true);
watermarkShape.getShapeLock().setPositionLocked(true);
watermarkShape.getShapeLock().setGroupingLocked(true);
```


### **إحضار العلامة المائية إلى الأمام**
في Aspose.Slides، يمكن ضبط ترتيب الأشكال (Z-order) عبر طريقة [**SlideCollection.reorder**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#reorder-int-aspose.slides.ISlide...-). للقيام بذلك، استدعِ هذه الطريقة من قائمة شرائح العرض ومرّر مرجع الشكل ورقم ترتيبه إلى الطريقة. بهذه الطريقة، يمكن إحضار شكل إلى الأمام أو إرساله إلى الخلف. هذه الميزة مفيدة خاصة إذا كنت تحتاج وضع العلامة المائية أمام محتوى العرض:
```javascript
let shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```


### **تعيين دوران العلامة المائية**
إليك مثال شيفرة لضبط دوران العلامة المائية بحيث تكون مائلة عبر الشريحة:
```javascript
const diagonalAngle = Math.atan(slideSize.getHeight() / slideSize.getWidth()) * 180 / Math.PI;

watermarkShape.setRotation(diagonalAngle);
```


### **تعيين اسم للعلامة المائية**
تتيح Aspose.Slides لك تعيين اسم للشكل. باستخدام اسم الشكل، يمكنك الوصول إليه في المستقبل لتعديله أو حذفه. لتعيين اسم شكل العلامة المائية، استخدم طريقة [**AutoShape.getName**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getName--):
```javascript
watermarkShape.setName("watermark");
```


### **إزالة العلامة المائية**
لإزالة شكل العلامة المائية، استخدم طريقة [AutoShape.getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getName--) للعثور عليه في أشكال الشريحة. ثم مرّر الشكل إلى طريقة [**ShapeCollection.remove**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#remove-aspose.slides.IShape-):
```javascript
for (var i = 0; i < slide.getShapes().size(); i++) {
    var shape = slide.getShapes().get_Item(i);
    if ("watermark" == shape.getName()) {
        slide.getShapes().remove(watermarkShape);
    }
}
```


## **الأسئلة الشائعة**

**ما هي العلامة المائية ولماذا يجب علي استخدامها؟**

العلامة المائية هي تراكب نصي أو صوري يُطبق على الشرائح يساعد في حماية الملكية الفكرية، تعزيز التعرف على العلامة التجارية، أو منع الاستخدام غير المصرح به للعروض التقديمية.

**هل يمكنني إضافة علامة مائية إلى جميع الشرائح في العرض؟**

نعم، تتيح Aspose.Slides إضافة علامة مائية إلى كل شريحة في العرض. يمكنك تكرار العملية عبر جميع الشرائح وتطبيق إعدادات العلامة المائية لكل شريحة على حدة.

**كيف يمكنني ضبط شفافية العلامة المائية؟**

يمكنك ضبط شفافية العلامة المائية عن طريق تعديل [إعدادات التعبئة](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getfillformat/) للشكل. يضمن ذلك أن تكون العلامة خفيفة ولا تشوش على محتوى الشريحة.

**ما صيغ الصور المدعومة للعلامات المائية؟**

تدعم Aspose.Slides صيغ صور متعددة مثل PNG وJPEG وGIF وBMP وSVG وغير ذلك.

**هل يمكنني تخصيص الخط والأسلوب للعلامة المائية النصية؟**

نعم، يمكنك اختيار أي خط، حجم، وأسلوب ليتناسب مع تصميم العرض ويحافظ على اتساق العلامة التجارية.

**كيف أغيّر موضع أو اتجاه العلامة المائية؟**

يمكنك تعديل موضع واتجاه العلامة المائية عن طريق تغيير إحداثيات الشكل، حجمه، وخصائص الدوران.