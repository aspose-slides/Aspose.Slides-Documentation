---
title: "علامة مائية"
type: docs
weight: 40
url: /ar/nodejs-java/watermark/
keywords: "علامة مائية في العرض التقديمي"
description: "استخدم العلامة المائية في PowerPoint مع Aspose.Slides. أضف علامة مائية إلى عرض ppt أو احذف العلامة المائية. أدخل علامة مائية صورة أو علامة مائية نصية."
---

## **حول العلامة المائية**

**علامة مائية** في عرض تقديمي هي ختم نصي أو صورة يُستخدم على شريحة أو عبر جميع شرائح العرض. عادةً تُستخدم العلامة المائية للدلالة على أن العرض مسودة (مثل علامة "مسودة")، أو أنه يحتوي على معلومات سرية (مثل علامة "سري")، لتحديد الشركة المالكة (مثل علامة "اسم الشركة")، لتحديد مؤلف العرض، إلخ. تساعد العلامة المائية في منع انتهاكات حقوق النشر من خلال الإشارة إلى أنه لا ينبغي نسخ العرض. تُستخدم العلامات المائية في صيغ عروض PowerPoint وOpenOffice. في Aspose.Slides، يمكنك إضافة علامة مائية إلى صيغ ملفات PowerPoint PPT وPPTX وOpenOffice ODP.

في [**Aspose.Slides**](https://products.aspose.com/slides/nodejs-java/)، هناك طرق مختلفة يمكنك من خلالها إنشاء علامات مائية في مستندات PowerPoint أو OpenOffice وتعديل تصميمها وسلوكها. الجانب المشترك هو أن إضافة علامات مائية نصية يتطلب استخدام النوع [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/)، ولإضافة علامات مائية صور استخدم الفئة [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) أو ملء شكل العلامة المائية بصورة. `PictureFrame` يطبق النوع [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/)، مما يتيح لك استخدام جميع إعدادات الشكل المرنة. بما أن `TextFrame` ليس شكلًا وإعداداته محدودة، فإنه يُغلف داخل كائن [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/).

هناك طريقتان لتطبيق العلامة المائية: على شريحة واحدة أو على جميع شرائح العرض. يُستخدم الـ Slide Master لتطبيق العلامة المائية على جميع الشرائح — تُضاف العلامة المائية إلى الـ Slide Master، يتم تصميمها بالكامل هناك، وتُطبق على جميع الشرائح دون التأثير على إذن تعديل العلامة المائية على الشرائح الفردية.

عادةً ما تُعتبر العلامة المائية غير متاحة للتحرير من قبل المستخدمين الآخرين. لمنع تعديل العلامة المائية (أو الشكل الأب للعلامة المائية) يُوفر Aspose.Slides وظيفة قفل الشكل. يمكن قفل شكل محدد على شريحة عادية أو على Slide Master. عندما يُقفل شكل العلامة المائية على الـ Slide Master، سيُقفل على جميع شرائح العرض.

يمكنك تعيين اسم للعلامة المائية حتى تتمكن في المستقبل، إذا رغبت في حذفها، من العثور عليها في أشكال الشريحة عبر الاسم.

يمكنك تصميم العلامة المائية بأي طريقة؛ ومع ذلك، توجد عادةً ميزات شائعة في العلامات المائية مثل المحاذاة إلى المركز، الدوران، الموضع الأمامي، إلخ. سنستعرض كيفية استخدام هذه الخصائص في الأمثلة أدناه.

## **علامة مائية نصية**

### **إضافة علامة مائية نصية إلى شريحة**
لإضافة علامة مائية نصية في PPT أو PPTX أو ODP، يمكنك أولاً إضافة شكل إلى الشريحة، ثم إضافة إطار نص إلى هذا الشكل. يُمثَّل إطار النص بالنوع [**TextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame). هذا النوع لا يرث من [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape)، الذي يملك مجموعة واسعة من الخصائص لتحديد موضع العلامة المائية بشكل مرن. لذلك، يتم تغليف كائن [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) داخل كائن [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape). لإضافة نص العلامة المائية إلى الشكل، استخدم طريقة [**addTextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) مع تمرير نص العلامة المائية إليها:
```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let slide = presentation.getSlides().get_Item(0);

let watermarkShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="انظر أيضًا" %}} 
- [كيفية الاستخدام ](/slides/ar/nodejs-java/slide-master/)[TextFrame](/slides/ar/nodejs-java/adding-and-formatting-text/)
{{% /alert %}}

### **إضافة علامة مائية نصية إلى العرض**
إذا رغبت في إضافة علامة مائية نصية إلى العرض بأكمله (أي جميع الشرائح مرة واحدة)، أضفها إلى [**MasterSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide). بقية المنطق هي نفسها كما عند إضافة علامة مائية إلى شريحة واحدة — أنشئ كائن [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) ثم أضف العلامة المائية إليه باستخدام طريقة [**addTextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-).
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

### **ضبط شفافية شكل العلامة المائية**
افتراضيًا، يكون شكل المستطيل مُصممًا بألوان التعبئة والحد. تجعل السطور البرمجية التالية الشكل شفافًا.
```javascript
watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
watermarkShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
```


### **تعيين الخط لعلامة مائية نصية**
تستطيع تغيير خط العلامة المائية النصية كما هو موضح أدناه.
```javascript
let textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new aspose.slides.FontData("Arial"));
textFormat.setFontHeight(50);
```


### **تعيين لون نص العلامة المائية**
لتعيين لون نص العلامة المائية، استخدم هذا الكود:
```java
let alpha = 150;
let red = 200;
let green = 200;
let blue = 200;

let fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
fillFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", red, green, blue, alpha));
```


### **توسيط العلامة المائية النصية**
يمكن توسيط العلامة المائية على الشريحة ويمكنك القيام بما يلي:
```javascript
const watermarkWidth = 400;
const watermarkHeight = 40;
const watermarkX = (slideSize.getWidth() - watermarkWidth) / 2;
const watermarkY = (slideSize.getHeight() - watermarkHeight) / 2;

let watermarkShape = masterSlide.getShapes().addAutoShape(
        aspose.slides.ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);
        
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```


![العلامة المائية النصية](text_watermark.png)

## **علامة مائية صورة**

### **إضافة علامة مائية صورة إلى عرض**
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
إذا كان من الضروري منع تعديل العلامة المائية، استخدم طريقة [**AutoShape.getShapeLock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#getShapeLock--) على الشكل. باستخدام هذه الخاصية، يمكنك حماية الشكل من الاختيار، إعادة الحجم، إعادة الموضع، تجميعه مع عناصر أخرى، قفل نصه من التحرير، وغير ذلك الكثير:
```javascript
// قفل شكل العلامة المائية من التعديل
watermarkShape.getShapeLock().setSelectLocked(true);
watermarkShape.getShapeLock().setSizeLocked(true);
watermarkShape.getShapeLock().setTextLocked(true);
watermarkShape.getShapeLock().setPositionLocked(true);
watermarkShape.getShapeLock().setGroupingLocked(true);
```


{{% alert color="primary" title="انظر أيضًا" %}} 
- [كيفية قفل الأشكال من التحرير](/slides/ar/nodejs-java/presentation-locking/)
{{% /alert %}}

### **إحضار العلامة المائية إلى الأمام**
في Aspose.Slides، يمكن تعيين ترتيب Z للأشكال عبر طريقة [**SlideCollection.reorder**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#reorder-int-aspose.slides.ISlide...-) . للقيام بذلك، عليك استدعاء هذه الطريقة من قائمة شرائح العرض وتمرير مرجع الشكل ورقمه الترتيبي إلى الطريقة. بهذه الطريقة، يمكن إحضار شكل إلى الأمام أو إرساله إلى الخلف. هذه الميزة مفيدة خاصة إذا كنت تحتاج إلى وضع علامة مائية أمام العرض:
```javascript
let shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```


### **ضبط دوران العلامة المائية**
هذا مثال على الشيفرة لتعديل دوران العلامة المائية بحيث تكون مائلة عبر الشريحة:
```javascript
const diagonalAngle = Math.atan(slideSize.getHeight() / slideSize.getWidth()) * 180 / Math.PI;

watermarkShape.setRotation(diagonalAngle);
```


### **تعيين اسم للعلامة المائية**
يتيح Aspose.Slides لك تعيين اسم للشكل. باستخدام اسم الشكل، يمكنك الوصول إليه مستقبلًا لتعديله أو حذفه. لتعيين اسم شكل العلامة المائية، استخدم طريقة [**AutoShape.getName**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getName--) .
```javascript
watermarkShape.setName("watermark");
```


### **إزالة العلامة المائية**
لإزالة شكل العلامة المائية، استخدم طريقة [AutoShape.getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getName--) للعثور عليه في أشكال الشريحة. ثم مرّر شكل العلامة المائية إلى طريقة [**ShapeCollection.remove**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#remove-aspose.slides.IShape-) .
```javascript
for (var i = 0; i < slide.getShapes().size(); i++) {
    var shape = slide.getShapes().get_Item(i);
    if ("watermark" == shape.getName()) {
        slide.getShapes().remove(watermarkShape);
    }
}
```


## **الأسئلة المتكررة**

**ما هي العلامة المائية ولماذا يجب أن أستخدمها؟**  
العلامة المائية هي طبقة نصية أو صورة تُطبق على الشرائح تساعد على حماية الملكية الفكرية، تعزيز التعرف على العلامة التجارية، أو منع الاستخدام غير المصرح به للعرض.

**هل يمكنني إضافة علامة مائية إلى جميع الشرائح في عرض تقديمي؟**  
نعم، يتيح Aspose.Slides إضافة علامة مائية إلى كل شريحة في العرض. يمكنك المرور على جميع الشرائح وتطبيق إعدادات العلامة المائية على كل واحدة على حدة.

**كيف يمكنني تعديل شفافية العلامة المائية؟**  
يمكنك تعديل شفافية العلامة المائية عن طريق تعديل [إعدادات التعبئة](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getfillformat/) للشكل. وهذا يضمن أن تكون العلامة المائية خفيفة ولا تشوش محتوى الشريحة.

**ما هي صيغ الصور المدعومة للعلامات المائية؟**  
يدعم Aspose.Slides صيغ صور متعددة مثل PNG وJPEG وGIF وBMP وSVG وغيرها.

**هل يمكنني تخصيص الخط والنمط للعلامة المائية النصية؟**  
نعم، يمكنك اختيار أي خط وحجم ونمط لتتناسب مع تصميم عرضك والحفاظ على تناسق العلامة التجارية.

**كيف أغير موضع أو اتجاه العلامة المائية؟**  
يمكنك تعديل موضع واتجاه العلامة المائية عن طريق تعديل إحداثيات الشكل، حجمه، وخصائص الدوران.