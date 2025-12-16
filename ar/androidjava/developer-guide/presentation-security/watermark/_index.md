---
title: إضافة علامات مائية إلى العروض التقديمية على Android
linktitle: علامة مائية
type: docs
weight: 40
url: /ar/androidjava/watermark/
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
- Android
- Java
- Aspose.Slides
description: "إدارة العلامات المائية النصية والصورية في العروض التقديمية PowerPoint و OpenDocument على Android باستخدام Java لتحديد مسودة أو معلومات سرية وغيرها."
---

## **حول العلامات المائية**

**علامة مائية** في العرض التقديمي هي طباعة نصية أو صورة تُستخدم على شريحة أو عبر جميع شرائح العرض. عادةً ما تُستخدم العلامة المائية للإشارة إلى أن العرض مسودة (مثلاً، علامة مائية "مسودة")، أو أنه يحتوي على معلومات سرية (مثلاً، علامة مائية "سري")، لتحديد الشركة التي ينتمي إليها (مثلاً، علامة مائية "اسم الشركة")، لتحديد مؤلف العرض، إلخ. تساعد العلامة المائية في منع انتهاك حقوق النشر عن طريق الإشارة إلى أنه لا ينبغي نسخ العرض. تُستخدم العلامات المائية في صيغ PowerPoint و OpenOffice للعرض. في Aspose.Slides، يمكنك إضافة علامة مائية إلى صيغ ملفات PowerPoint PPT و PPTX و OpenOffice ODP.

في [**Aspose.Slides**](https://products.aspose.com/slides/android-java/)، هناك طرق متعددة يمكنك من خلالها إنشاء علامات مائية في مستندات PowerPoint أو OpenOffice وتعديل تصميمها وسلوكها. الجانب المشترك هو أنه لإضافة علامات مائية نصية، يجب عليك استخدام واجهة [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)، ولإضافة علامات مائية صورة، استخدم فئة [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) أو املأ شكل العلامة المائية بصورة. `PictureFrame` يطبق واجهة [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) مما يتيح لك استخدام جميع إعدادات الشكل المرنة. نظرًا لأن `ITextFrame` ليس شكلًا وإعداداته محدودة، يتم تغليفه داخل كائن [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/).

هناك طريقتان لتطبيق العلامة المائية: على شريحة واحدة أو على جميع شرائح العرض. يُستخدم “Slide Master” لتطبيق علامة مائية على جميع الشرائح — تُضاف العلامة المائية إلى “Slide Master”، يتم تصميمها بالكامل هناك، ثم تُطبق على جميع الشرائح دون التأثير على إمكانية تعديل العلامة المائية على الشرائح الفردية.

عادةً ما تُعتبر العلامة المائية غير قابلة للتحرير من قبل المستخدمين الآخرين. لمنع تعديل العلامة المائية (أو شكلها الأصل)، توفر Aspose.Slides وظيفة قفل الشكل. يمكن قفل شكل معين على شريحة عادية أو على “Slide Master”. عندما يُقفل شكل العلامة المائية على “Slide Master”، سيُقفل على جميع شرائح العرض.

يمكنك تعيين اسم للعلامة المائية بحيث يمكنك في المستقبل، إذا أردت حذفها، العثور عليها في أشكال الشريحة بالاسم.

يمكنك تصميم العلامة المائية بأي طريقة؛ ومع ذلك، هناك ميزات شائعة عادةً في العلامات المائية مثل محاذاة المركز، الدوران، الموضع الأمامي، إلخ. سنستعرض كيفية استخدام هذه الميزات في الأمثلة أدناه.

## **علامة مائية نصية**

### **إضافة علامة مائية نصية إلى شريحة**

لإضافة علامة مائية نصية في PPT أو PPTX أو ODP، يمكنك أولاً إضافة شكل إلى الشريحة، ثم إضافة إطار نص إلى هذا الشكل. يُمثل إطار النص واجهة [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/). هذا النوع لا يرث من [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/)، الذي يحتوي على مجموعة واسعة من الخصائص لتحديد موقع العلامة المائية بطريقة مرنة. لذا يتم تغليف كائن [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) داخل كائن [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/). لإضافة نص العلامة المائية إلى الشكل، استخدم الطريقة [addTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) كما هو موضح أدناه.
```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="انظر أيضًا" %}} 
- [كيفية استخدام فئة TextFrame](/slides/ar/androidjava/text-formatting/)
{{% /alert %}}

### **إضافة علامة مائية نصية إلى عرض تقديمي**

إذا رغبت في إضافة علامة مائية نصية إلى العرض بأكمله (أي جميع الشرائح دفعة واحدة)، أضفها إلى [MasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterslide/). باقي المنطق هو نفسه كما عند إضافة علامة مائية إلى شريحة واحدة — أنشئ كائن [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) ثم أضف العلامة المائية إليه باستخدام الطريقة [addTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).
```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="انظر أيضًا" %}} 
- [كيفية استخدام Slide Master](/slides/ar/androidjava/slide-master/)
{{% /alert %}}

### **ضبط شفافية شكل العلامة المائية**

بشكل افتراضي، يُنسق شكل المستطيل بألوان تعبئة وخط. تجعل السطور التالية من الكود الشكل شفافًا.
```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```


### **تعيين الخط للعلامة المائية النصية**

يمكنك تغيير خط العلامة المائية النصية كما هو موضح أدناه.
```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```


### **ضبط لون نص العلامة المائية**

لتعيين لون نص العلامة المائية، استخدم هذا الكود:
```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(Color.argb(alpha, red, green, blue));
```


### **محاذاة العلامة المائية النصية إلى الوسط**

يمكنك محاذاة العلامة المائية إلى وسط الشريحة، وللقيام بذلك يمكنك تنفيذ ما يلي:
```java
SizeF slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```


الصورة أدناه توضح النتيجة النهائية.

![العلامة المائية النصية](text_watermark.png)

## **علامة مائية صورة**

### **إضافة علامة مائية صورة إلى عرض تقديمي**

لإضافة علامة مائية صورة إلى شريحة عرض تقديمي، يمكنك القيام بما يلي:
```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```


### **قفل علامة مائية من التحرير**

إذا كان من الضروري منع تعديل العلامة المائية، استخدم الطريقة [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) على الشكل. باستخدام هذه الخاصية، يمكنك حماية الشكل من الاختيار، وإعادة الحجم، وإعادة التموقع، وتجميعه مع عناصر أخرى، وقفل نصه من التحرير، وأكثر من ذلك:
```java
// قفل شكل العلامة المائية من التعديل
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```


### **إحضار علامة مائية إلى الأمام**

في Aspose.Slides، يمكن تعيين ترتيب Z للأشكال عبر الطريقة [IShapeCollection.reorder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) . للقيام بذلك، تحتاج إلى استدعاء هذه الطريقة من قائمة شرائح العرض وتمرير مرجع الشكل ورقم ترتيبه إلى الطريقة. بهذه الطريقة، يمكن إحضار شكل إلى الأمام أو إرساله إلى الخلف من الشريحة. تكون هذه الخاصية مفيدة خاصة إذا كنت بحاجة إلى وضع علامة مائية أمام محتوى العرض:
```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```


### **ضبط دوران العلامة المائية**

إليك مثال شفرة يوضح كيفية تعديل دوران العلامة المائية بحيث تكون موجهة قطريًا عبر الشريحة:
```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```


### **تعيين اسم للعلامة المائية**

يسمح لك Aspose.Slides بتعيين اسم للشكل. باستخدام اسم الشكل، يمكنك الوصول إليه في المستقبل لتعديله أو حذفه. لتعيين اسم لشكل العلامة المائية، عينه إلى الطريقة [IAutoShape.setName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-):
```java
watermarkShape.setName("watermark");
```


### **إزالة علامة مائية**

لإزالة شكل العلامة المائية، استخدم الطريقة [IAutoShape.getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getName--) للعثور عليه في أشكال الشريحة. ثم مرّر شكل العلامة المائية إلى الطريقة [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) :
```java
IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(watermarkShape);
    }
}
```


## **الأسئلة الشائعة**

**ما هي العلامة المائية ولماذا يجب استخدامها؟**

العلامة المائية هي طبقة نصية أو صورة تُطبق على الشرائح وتساعد في حماية الملكية الفكرية، وتعزيز التعرف على العلامة التجارية، أو منع الاستخدام غير المصرح به للعرض.

**هل يمكنني إضافة علامة مائية إلى جميع الشرائح في عرض تقديمي؟**

نعم، يسمح لك Aspose.Slides بإضافة علامة مائية برمجيًا إلى كل شريحة في العرض. يمكنك iterating عبر جميع الشرائح وتطبيق إعدادات العلامة المائية على كل منها بشكل منفصل.

**كيف يمكنني ضبط شفافية العلامة المائية؟**

يمكنك ضبط شفافية العلامة المائية عن طريق تعديل إعدادات التعبئة ([getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getFillFormat--)) للشكل. يضمن ذلك أن تكون العلامة المائية خفيفة ولا تشتت انتباه المشاهد عن محتوى الشريحة.

**ما صيغ الصور المدعومة للعلامات المائية؟**

يدعم Aspose.Slides صيغ صور متعددة مثل PNG و JPEG و GIF و BMP و SVG وغيرها.

**هل يمكنني تخصيص الخط والأسلوب للعلامة المائية النصية؟**

نعم، يمكنك اختيار أي خط، وحجم، وأسلوب لتتناسب مع تصميم العرض والحفاظ على تناسق العلامة التجارية.

**كيف أقوم بتغيير موضع أو اتجاه العلامة المائية؟**

يمكنك تعديل موضع العلامة المائية واتجاهها برمجيًا عن طريق تعديل إحداثيات الشكل، وحجمه، وخصائص الدوران.