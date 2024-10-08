---
title: علامة مائية
type: docs
weight: 40
url: /ar/androidjava/watermark/
keywords:
- علامة مائية
- إضافة علامة مائية
- علامة مائية نصية
- علامة مائية صورة
- PowerPoint
- عرض تقديمي
- أندرويد
- جافا
- Aspose.Slides لأندرويد عبر جافا
description: "قم بإضافة علامات مائية نصية وصورية إلى عروض PowerPoint في جافا"
---

## **حول العلامات المائية**

**العلامة المائية** في عرض تقديمي هي ختم نصي أو صوري يستخدم على شريحة أو عبر جميع الشرائح في العرض التقديمي. عادة ما تستخدم العلامة المائية للإشارة إلى أن العرض التقديمي مسودة (مثل، علامة مائية "مسودة")، أو أنها تحتوي على معلومات سرية (مثل، علامة مائية "سري")، لتحديد الشركة التي تعود إليها (مثل، علامة مائية "اسم الشركة")، لتحديد مؤلف العرض التقديمي، إلخ. تساعد العلامة المائية في منع انتهاك حقوق الطبع والنشر من خلال الإشارة إلى أن العرض التقديمي لا ينبغي نسخه. تُستخدم العلامات المائية في كل من تنسيقات عروض PowerPoint وOpenOffice. في Aspose.Slides، يمكنك إضافة علامة مائية إلى تنسيقات ملفات PowerPoint PPT وPPTX وOpenOffice ODP.

في [**Aspose.Slides**](https://products.aspose.com/slides/android-java/)، هناك طرق متنوعة يمكنك من خلالها إنشاء علامات مائية في مستندات PowerPoint أو OpenOffice وتعديل تصميمها وسلوكها. الجانب المشترك هو أنه لإضافة علامات مائية نصية، يجب عليك استخدام واجهة [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)، ولإضافة علامات مائية صور، استخدم فئة [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) أو املأ شكل علامة مائية بصورة. implements `PictureFrame` واجهة [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) ، مما يسمح لك باستخدام جميع إعدادات كائن الشكل المرنة. نظرًا لأن `ITextFrame` ليس شكلًا وإعداداته محدودة، فإنه يلتف في كائن [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/).

هناك طريقتان يمكن تطبيق العلامة المائية: على شريحة واحدة أو على جميع الشرائح في العرض التقديمي. تُستخدم شريحة Master لتطبيق علامة مائية على جميع الشرائح في العرض التقديمي - تتم إضافة العلامة المائية إلى شريحة Master، وتصميمها بالكامل هناك، وتطبيقها على جميع الشرائح دون التأثير على الإذن لتعديل العلامة المائية على الشرائح الفردية.

تعتبر العلامة المائية عادة غير متاحة للتعديل من قبل مستخدمين آخرين. لمنع تعديل العلامة المائية (أو بالأحرى، شكل العلامة المائية), توفر Aspose.Slides وظيفة قفل الشكل. يمكن قفل شكل معين على شريحة عادية أو على شريحة Master. عند قفل شكل العلامة المائية على شريحة Master، سيتم قفله على جميع الشرائح في العرض التقديمي.

يمكنك تعيين اسم للعلامة المائية حتى تتمكن في المستقبل، إذا أردت حذفها، من العثور عليها في أشكال الشريحة حسب الاسم.

يمكنك تصميم العلامة المائية بأي شكل؛ ومع ذلك، عادة ما توجد ميزات شائعة في العلامات المائية، مثل المحاذاة المركزية، والدوران، والموقع الأمامي، إلخ. سننظر في كيفية استخدام هذه الميزات في الأمثلة أدناه.

## **علامة مائية نصية**

### **إضافة علامة مائية نصية إلى شريحة**

لإضافة علامة مائية نصية في PPT أو PPTX أو ODP، يمكنك أولاً إضافة شكل إلى الشريحة، ثم إضافة إطار نص إلى هذا الشكل. يتم تمثيل إطار النص من خلال واجهة [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/). هذا النوع ليس وراثيًا من [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) ، الذي يحتوي على مجموعة واسعة من الخصائص لوضع العلامة المائية بمرونة. لذلك، يتم لف كائن [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) في كائن [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/). لإضافة نص العلامة المائية إلى الشكل، استخدم طريقة [addTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) كما هو موضح أدناه.

```java
String watermarkText = "سري";

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

إذا كنت ترغب في إضافة علامة مائية نصية إلى العرض التقديمي بأكمله (أي، جميع الشرائح مرة واحدة)، أضفها إلى [MasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterslide/). تظل منطق الإضافة كما هو عند إضافة علامة مائية إلى شريحة واحدة - قم بإنشاء كائن [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) ثم أضف العلامة المائية إليه باستخدام طريقة [addTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

```java
String watermarkText = "سري";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="انظر أيضًا" %}} 
- [كيفية استخدام شريحة Master](/slides/ar/androidjava/slide-master/)
{{% /alert %}}

### **تعيين شفافية شكل العلامة المائية**

افتراضيًا، يكون شكل المستطيل مزينًا بألوان التعبئة والخط. تجعل الأسطر التالية من التعليمات البرمجية الشكل شفافًا.

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **تعيين الخط لعلامة مائية نصية**

يمكنك تغيير خط النص في العلامة المائية كما هو موضح أدناه.

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **تعيين لون نص العلامة المائية**

لتعيين لون نص العلامة المائية، استخدم هذا الرمز:

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(Color.argb(alpha, red, green, blue));
```

### **توسيع علامة مائية نصية إلى المركز**

يمكنك توسيع العلامة المائية على الشريحة، وللقيام بذلك، يمكنك القيام بما يلي:

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

توضح الصورة أدناه النتيجة النهائية.

![العلامة المائية النصية](text_watermark.png)

## **علامة مائية صورية**

### **إضافة علامة مائية صورية إلى عرض تقديمي**

لإضافة علامة مائية صورية إلى شريحة عرض تقديمي، يمكنك القيام بما يلي:

```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

## **قفل علامة مائية من التحرير**

إذا كان من الضروري منع تحرير علامة مائية، استخدم طريقة [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) على الشكل. باستخدام هذه الخاصية، يمكنك حماية الشكل من أن يتم تحديده، أو إعادة تحجيمه، أو إعادة موضعه، أو تجميعه مع عناصر أخرى، وقفل نصه من التحرير، والمزيد:

```java
// قفل شكل العلامة المائية من التعديل
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

## **إحضار علامة مائية إلى الأمام**

في Aspose.Slides، يمكن تعيين ترتيب Z للشكل عبر طريقة [IShapeCollection.reorder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). للقيام بذلك، تحتاج إلى استدعاء هذه الطريقة من قائمة شرائح العرض التقديمي وتمرير مرجع الشكل ورقم ترتيبه إلى الطريقة. بهذه الطريقة، من الممكن إحضار شكل إلى الأمام أو إرساله إلى الجزء الخلفي من الشريحة. هذه الميزة مفيدة بشكل خاص إذا كنت بحاجة إلى وضع علامة مائية أمام العرض التقديمي:

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

## **تعيين دوران العلامة المائية**

إليك مثال على التعليمات البرمجية حول كيفية ضبط دوران العلامة المائية بحيث تكون موضوعة بزاوية مائلة عبر الشريحة:

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

## **تعيين اسم للعلامة المائية**

تسمح Aspose.Slides لك بتعيين اسم للشكل. باستخدام اسم الشكل، يمكنك الوصول إليه في المستقبل لتعديله أو حذفه. لتعيين اسم شكل العلامة المائية، قم بتعيينه لطريقة [IAutoShape.setName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-):

```java
watermarkShape.setName("watermark");
```

## **إزالة علامة مائية**

لإزالة شكل العلامة المائية، استخدم طريقة [IAutoShape.getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getName--) للعثور عليها في أشكال الشريحة. ثم، قم بتمرير شكل العلامة المائية إلى طريقة [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) كما يلي:

```java
IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **مثال حي**

قد ترغب في التحقق من أدوات **Aspose.Slides المجانية** [إضافة علامة مائية](https://products.aspose.app/slides/watermark) و[إزالة علامة مائية](https://products.aspose.app/slides/watermark/remove-watermark) عبر الإنترنت.

![أدوات عبر الإنترنت لإضافة وإزالة العلامات المائية](online_tools.png)