---
title: علامة مائية
type: docs
weight: 40
url: /ar/java/watermark/
keywords:
- علامة مائية
- إضافة علامة مائية
- علامة مائية نصية
- علامة مائية صورة
- PowerPoint
- تقديم
- Java
- Aspose.Slides لـ Java
description: "إضافة علامات مائية نصية وصورية إلى عروض PowerPoint في Java"
---

## **حول العلامات المائية**

**العلامة المائية** في العرض التقديمي هي ختم نصي أو صوري يستخدم على شريحة واحدة أو على جميع شرائح العرض التقديمي. عادةً ما تُستخدم العلامة المائية للإشارة إلى أن العرض التقديمي مسودة (على سبيل المثال، علامة مائية "مسودة")، أو أنه يحتوي على معلومات سرية (على سبيل المثال، علامة مائية "سرية")، لتحديد الشركة التي ينتمي إليها (على سبيل المثال، علامة مائية "اسم الشركة")، أو لتحديد مؤلف العرض التقديمي، إلخ. تساعد العلامات المائية في منع انتهاكات حقوق الطبع والنشر من خلال الإشارة إلى أنه يجب عدم نسخ العرض التقديمي. تُستخدم العلامات المائية في كلاً من تنسيقات عروض PowerPoint وOpenOffice. في Aspose.Slides، يمكنك إضافة علامة مائية إلى تنسيقات ملفات PowerPoint PPT وPPTX وOpenOffice ODP.

في [**Aspose.Slides**](https://products.aspose.com/slides/java/)، هناك طرق متنوعة يمكنك من خلالها إنشاء علامات مائية في مستندات PowerPoint أو OpenOffice وتعديل تصميمها وسلوكها. الجانب المشترك هو أنه لإضافة علامات مائية نصية، يجب أن تستخدم واجهة [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/)، ولإضافة علامات مائية صور، استخدم فئة [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) أو ملء شكل علامة مائية بصورة. `PictureFrame` تنفذ واجهة [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/)، مما يسمح لك باستخدام جميع إعدادات الكائن المرن. نظرًا لأن `ITextFrame` ليست شكلاً وإعداداته محدودة، فإنه يتم wrapping في كائن [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/).

هناك طريقتان يمكن أن تُطبق بهما العلامة المائية: على شريحة واحدة أو على جميع شرائح العرض التقديمي. تُستخدم الشريحة الأساسية لتطبيق علامة مائية على جميع شرائح العرض التقديمي - تُضاف العلامة المائية إلى الشريحة الأساسية، ويتم تصميمها بالكامل هناك، وتُطبق على جميع الشرائح دون التأثير على الإذن لتعديل العلامة المائية على الشرائح الفردية.

عادةً ما يُعتبر أن العلامة المائية غير متاحة للتحرير من قبل مستخدمين آخرين. لمنع تعديل العلامة المائية (أو بالأحرى الشكل الأب للعلامة المائية)، توفر Aspose.Slides وظيفة قفل الشكل. يمكن قفل شكل معين على شريحة عادية أو على شريحة أساسية. عندما يتم قفل شكل العلامة المائية على الشريحة الأساسية، فإنه سيبقى مقفلاً على جميع شرائح العرض التقديمي.

يمكنك تعيين اسم للعلامة المائية بحيث إذا كنت ترغب في حذفها في المستقبل، يمكنك العثور عليها في أشكال الشريحة بالاسم.

يمكنك تصميم العلامة المائية بأي طريقة؛ ومع ذلك، هناك عادةً ميزات شائعة في العلامات المائية، مثل محاذاة المركز، والدوران، والموقع الأمامي، إلخ. سننظر في كيفية استخدام هذه الميزات في الأمثلة أدناه.

## **علامة مائية نصية**

### **إضافة علامة مائية نصية إلى شريحة**

لإضافة علامة مائية نصية في PPT أو PPTX أو ODP، يمكنك أولاً إضافة شكل إلى الشريحة، ثم إضافة إطار نصي إلى هذا الشكل. يُمثل إطار النص بواسطة واجهة [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/). هذا النوع لا يرث من [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/)، والذي يحتوي على مجموعة واسعة من الخصائص لوضع العلامة المائية بطريقة مرنة. لذلك، يتم wrapping كائن [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) في كائن [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/). لإضافة نص العلامة المائية إلى الشكل، استخدم الطريقة [addTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) كما هو موضح أدناه.

```java
String watermarkText = "سرية";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="اطلع أيضًا" %}} 
- [كيفية استخدام فئة TextFrame](/slides/ar/java/text-formatting/)
{{% /alert %}}

### **إضافة علامة مائية نصية إلى عرض تقديمي**

إذا كنت ترغب في إضافة علامة مائية نصية إلى العرض التقديمي بالكامل (أي، جميع الشرائح دفعة واحدة)، أضفها إلى [MasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/masterslide/). باقي المنطق هو نفسه كما عند إضافة علامة مائية إلى شريحة واحدة - أنشئ كائن [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) ثم أضف العلامة المائية باستخدام الطريقة [addTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

```java
String watermarkText = "سرية";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="اطلع أيضًا" %}} 
- [كيفية استخدام الشريحة الرئيسية](/slides/ar/java/slide-master/)
{{% /alert %}}

### **تعيين شفافية شكل العلامة المائية**

بشكل افتراضي، يتم تصميم شكل المستطيل بألوان الملء والخط. تجعل الأسطر التالية من الكود الشكل شفافًا.

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **تعيين الخط لعلامة مائية نصية**

يمكنك تغيير خط النص للعلامة المائية كما هو موضح أدناه.

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **تعيين لون نص العلامة المائية**

لتعيين لون نص العلامة المائية، استخدم هذا الكود:

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
```

### **توسيع علامة مائية نصية**

من الممكن توسيع العلامة المائية على الشريحة، وللقيام بذلك، يمكنك اتباع الخطوات التالية:

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

## **قفل العلامة المائية من التحرير**

إذا كان من الضروري منع تعديل العلامة المائية، استخدم الطريقة [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) على الشكل. باستخدام هذه الخاصية، يمكنك حماية الشكل من التحديد، والتعديل في الحجم، وإعادة الموقع، وتجميعه مع عناصر أخرى، وقفل نصه من التحرير، والعديد من الأمور الأخرى:

```java
// قفل شكل العلامة المائية من التعديل
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

## **إحضار علامة مائية إلى الأمام**

في Aspose.Slides، يمكن تعيين ترتيب Z للأشكال عبر الطريقة [IShapeCollection.reorder](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). للقيام بذلك، تحتاج إلى استدعاء هذه الطريقة من قائمة الشرائح الخاصة بالعروض وتمرير مرجع الشكل ورقم ترتيبه إلى الطريقة. بهذه الطريقة، من الممكن إحضار شكل إلى الأمام أو إرساله إلى الخلف من الشريحة. هذه الميزة مفيدة بشكل خاص إذا كنت بحاجة لوضع علامة مائية أمام العرض التقديمي:

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

## **تعيين دوران العلامة المائية**

إليك مثالًا على الكود حول كيفية ضبط دوران العلامة المائية بحيث يتم وضعها بشكل مائل عبر الشريحة:

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

## **تعيين اسم لعلامة مائية**

تسمح لك Aspose.Slides بتعيين اسم للشكل. باستخدام اسم الشكل، يمكنك الوصول إليه في المستقبل لتعديله أو حذفه. لتعيين اسم شكل العلامة المائية، عينه إلى الطريقة [IAutoShape.setName](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setName-java.lang.String-):

```java
watermarkShape.setName("علامة مائية");
```

## **إزالة علامة مائية**

لإزالة شكل العلامة المائية، استخدم الطريقة [IAutoShape.getName](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getName--) للعثور عليها في أشكال الشريحة. ثم، مرر شكل العلامة المائية إلى الطريقة [IShapeCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) كما يلي:

```java
IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("علامة مائية".equals(shape.getName()))
    {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **مثال حي**

قد ترغب في إلقاء نظرة على **Aspose.Slides المجانية** [إضافة علامة مائية](https://products.aspose.app/slides/watermark) و[إزالة علامة مائية](https://products.aspose.app/slides/watermark/remove-watermark) الأدوات عبر الإنترنت.

![الأدوات عبر الإنترنت لإضافة وإزالة العلامات المائية](online_tools.png)