---
title: إضافة علامات مائية إلى العروض التقديمية في Java
linktitle: علامة مائية
type: docs
weight: 40
url: /ar/java/watermark/
keywords:
- علامة مائية
- علامة مائية نصية
- علامة مائية صورية
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
- presentation
- Java
- Aspose.Slides
description: "إدارة العلامات المائية النصية والصورية في عروض PowerPoint وOpenDocument التقديمية باستخدام Java للإشارة إلى مسودة أو معلومات سرية أو حقوق نشر وغيرها."
---

## **حول العلامات المائية**

**العلامة المائية** في عرض تقديمي هي ختم نصي أو صوري يُستخدم على شريحة أو عبر جميع شرائح العرض. عادةً تُستخدم العلامة المائية للإشارة إلى أن العرض مسودة (مثل علامة "مسودة")، أو أنه يحتوي على معلومات سرية (مثل علامة "سري")، لتحديد الشركة المالكة (مثل علامة "اسم الشركة")، لتحديد مؤلف العرض، إلخ. تساعد العلامة المائية في منع انتهاك حقوق النشر بالإشارة إلى أن العرض لا يجب نسخه. تُستخدم العلامات المائية في صيغتي PowerPoint وOpenOffice. في Aspose.Slides، يمكنك إضافة علامة مائية إلى صيغ ملفات PowerPoint PPT وPPTX وOpenOffice ODP.

في [**Aspose.Slides**](https://products.aspose.com/slides/java/)، توجد طرق مختلفة لإنشاء العلامات المائية في مستندات PowerPoint أو OpenOffice وتعديل تصميمها وسلوكها. الجانب المشترك هو أنه لإضافة علامات مائية نصية، يجب استخدام واجهة [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/)، ولإضافة علامات مائية صورية، استخدم فئة [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) أو ملء شكل العلامة المائية بصورة. `PictureFrame` تنفيذ واجهة [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/)، مما يتيح لك استخدام جميع إعدادات الشكل المرنة. بما أن `ITextFrame` ليس شكلاً وإعداداته محدودة، فانه يُغلف في كائن [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/).

هناك طريقتان لتطبيق العلامة المائية: على شريحة واحدة أو على جميع شرائح العرض. يُستخدم Slide Master لتطبيق العلامة المائية على جميع شرائح العرض — تُضاف العلامة المائية إلى Slide Master، تُصمم هناك بالكامل، وتُطبق على جميع الشرائح دون أن تؤثر على إمكانية تعديل العلامة المائية على الشرائح الفردية.

عادةً ما تُعتبر العلامة المائية غير قابلة للتحرير من قبل المستخدمين الآخرين. لمنع تحرير العلامة المائية (أو الشكل الأب للعلامة المائية)، توفر Aspose.Slides وظيفة قفل الأشكال. يمكن قفل شكل معين على شريحة عادية أو على Slide Master. عندما يُقفل شكل العلامة المائية على Slide Master، سيُقفل على جميع شرائح العرض.

يمكنك تعيين اسم للعلامة المائية بحيث يمكنك في المستقبل العثور عليها بحذفها عبر اسمها في أشكال الشريحة.

يمكنك تصميم العلامة المائية بأي طريقة؛ ومع ذلك غالبًا ما تكون هناك سمات شائعة في العلامات المائية، مثل المحاذاة المركزية، والدوران، والموقع الأمامي، إلخ. سنستعرض كيفية استخدام هذه السمات في الأمثلة أدناه.

## **علامة مائية نصية**

### **إضافة علامة مائية نصية إلى شريحة**

لإضافة علامة مائية نصية في PPT أو PPTX أو ODP، يمكنك أولاً إضافة شكل إلى الشريحة، ثم إضافة إطار نص إلى هذا الشكل. يُمثَّل إطار النص بواجهة [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/). هذا النوع لا يرث من [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/)، والذي يحتوي على مجموعة واسعة من الخصائص لتحديد موضع العلامة المائية بطريقة مرنة. لذلك يُغلف كائن [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) داخل كائن [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/). لإضافة نص العلامة المائية إلى الشكل، استخدم الطريقة [addTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) كما هو موضح أدناه.
```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="انظر أيضًا" %}} 
- [كيفية استخدام فئة TextFrame](/slides/ar/java/text-formatting/)
{{% /alert %}}

### **إضافة علامة مائية نصية إلى عرض تقديمي**

إذا كنت ترغب في إضافة علامة مائية نصية إلى العرض بأكمله (أي جميع الشرائح مرة واحدة)، أضفها إلى [MasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/masterslide/). بقية المنطق هو نفسه عند إضافة علامة مائية إلى شريحة واحدة — أنشئ كائن [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) ثم أضف العلامة المائية إليه باستخدام الطريقة [addTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).
```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="انظر أيضًا" %}} 
- [كيفية استخدام Slide Master](/slides/ar/java/slide-master/)
{{% /alert %}}

### **تحديد شفافية شكل العلامة المائية**

بشكل افتراضي، يتم تنسيق شكل المستطيل بألوان التعبئة والحد. تجعل الأسطر التالية من الكود الشكل شفافًا.
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


### **تعيين لون نص العلامة المائية**

لتعيين لون نص العلامة المائية، استخدم الكود التالي:
```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
```


### **محاذاة العلامة المائية النصية إلى المركز**

يمكنك مركز العلامة المائية على الشريحة، ولتحقيق ذلك يمكنك تنفيذ ما يلي:
```java
Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```


الصورة أدناه تُظهر النتيجة النهائية.

![The text watermark](text_watermark.png)

## **علامة مائية صورية**

### **إضافة علامة مائية صورية إلى عرض تقديمي**

لإضافة علامة مائية صورية إلى شريحة من العرض، يمكنك تنفيذ ما يلي:
```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```


### **قفل العلامة المائية من التحرير**

إذا كان من الضروري منع تحرير العلامة المائية، استخدم الطريقة [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) على الشكل. باستخدام هذه الخاصية يمكنك حماية الشكل من الاختيار، وإعادة التحجيم، وإعادة التموضع، وتجميعه مع عناصر أخرى، وقفل نصه من التحرير، والعديد غيرها:
```java
// قفل شكل العلامة المائية من التعديل
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```


### **إحضار العلامة المائية إلى الأمام**

في Aspose.Slides، يمكن تحديد ترتيب الأشكال (Z-order) عبر الطريقة [IShapeCollection.reorder](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). للقيام بذلك، تحتاج إلى استدعاء هذه الطريقة من قائمة شرائح العرض وتمرير مرجع الشكل ورقم ترتيبه إلى الطريقة. بهذه الطريقة يمكن إحضار الشكل إلى المقدمة أو إرساله إلى الخلف في الشريحة. هذه الميزة مفيدة خصوصًا إذا أردت وضع العلامة المائية أمام محتوى العرض:
```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```


### **تعيين دوران العلامة المائية**

فيما يلي مثال على كود لتعديل دوران العلامة المائية بحيث تكون موجهة بشكل قطري عبر الشريحة:
```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```


### **تعيين اسم للعلامة المائية**

تتيح لك Aspose.Slides تعيين اسم للشكل. باستخدام اسم الشكل يمكنك الوصول إليه في المستقبل لتعديله أو حذفه. لتعيين اسم شكل العلامة المائية، اسند الاسم إلى الطريقة [IAutoShape.setName](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setName-java.lang.String-):
```java
watermarkShape.setName("watermark");
```


### **إزالة العلامة المائية**

لإزالة شكل العلامة المائية، استخدم الطريقة [IAutoShape.getName](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getName--) للعثور عليه بين أشكال الشريحة. ثم مرّر شكل العلامة المائية إلى الطريقة [IShapeCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) :
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

**ما هي العلامة المائية ولماذا ينبغي علي استخدامها؟**

العلامة المائية هي طبقة نصية أو صورية تُطبق على الشرائح وتساعد على حماية الملكية الفكرية، وتعزيز التعرف على العلامة التجارية، أو منع الاستخدام غير المصرّح به للعرض.

**هل يمكنني إضافة علامة مائية إلى جميع الشرائح في عرض تقديمي؟**

نعم، تتيح لك Aspose.Slides إضافة علامة مائية برمجيًا إلى كل شريحة في العرض. يمكنك التكرار عبر جميع الشرائح وتطبيق إعدادات العلامة المائية على كل منها بشكل فردي.

**كيف يمكنني تعديل شفافية العلامة المائية؟**

يمكنك تعديل شفافية العلامة المائية عن طريق تعديل إعدادات التعبئة ([getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getFillFormat--)) للشكل. يضمن ذلك أن تكون العلامة المائية خفيفة ولا تشوش محتوى الشريحة.

**ما صيغ الصور المدعومة للعلامات المائية؟**

تدعم Aspose.Slides صيغ صور متعددة مثل PNG وJPEG وGIF وBMP وSVG وغيرها.

**هل يمكنني تخصيص الخط ونمط العلامة المائية النصية؟**

نعم، يمكنك اختيار أي خط وحجم ونمط لتتناسب مع تصميم عرضك وتحافظ على اتساق العلامة التجارية.

**كيف يمكنني تغيير موقع أو اتجاه العلامة المائية؟**

يمكنك تعديل موقع واتجاه العلامة المائية برمجيًا عن طريق تعديل إحداثيات الشكل، حجمه، وخصائص الدوران.