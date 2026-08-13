---
title: إضافة علامات مائية إلى العروض التقديمية في Java
linktitle: علامة مائية
type: docs
weight: 40
url: /ar/java/watermark/
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
- Java
- Aspose.Slides
description: "إدارة العلامات المائية النصية والصورية في عروض PowerPoint وOpenDocument التقديمية باستخدام Java للإشارة إلى مسودة، معلومات سرية، حقوق طبع ونشر، والمزيد."
---
## **المقدمة**

**العلامة المائية** في عرض تقديمي هي ختم نصي أو صورة يُستخدم على شريحة واحدة أو على جميع شرائح العرض. عادةً ما تُستخدم العلامة المائية للدلالة على أن العرض مسودة (مثل العلامة المائية “Draft”) أو أنه يحتوي على معلومات سرية (مثل العلامة المائية “Confidential”) أو لتحديد الشركة المالكة (مثل العلامة المائية “Company Name”) أو لتحديد مؤلف العرض، إلخ. تساعد العلامة المائية على منع انتهاكات حقوق النشر بإشارة إلى أنه لا ينبغي نسخ العرض. تُستخدم العلامات المائية في صيغ عروض PowerPoint وOpenOffice. في Aspose.Slides يمكنك إضافة علامة مائية إلى صيغ ملفات PowerPoint PPT، PPTX، وOpenOffice ODP.

في [**Aspose.Slides**](https://products.aspose.com/slides/ar/java/)، توجد طرق مختلفة لإنشاء علامات مائية في مستندات PowerPoint أو OpenOffice وتعديل تصميمها وسلوكها. الجانب المشترك هو أنه لإضافة علامات مائية نصية، يجب استخدام واجهة [ITextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/)، ولإضافة علامات مائية صورة، استخدم الفئة [PictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pictureframe/) أو املأ شكل العلامة المائية بصورة. `PictureFrame` تنفِّذ واجهة [IShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/)؛ مما يتيح لك استخدام جميع الإعدادات المرنة لكائن الشكل. بما أن `ITextFrame` ليس شكلًا وإعداداته محدودة، فإنه يُلف داخل كائن [IShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/).

هناك طريقتان لتطبيق العلامة المائية: على شريحة واحدة أو على جميع شرائح العرض. يُستخدم Slide Master لتطبيق علامة مائية على جميع شرائح العرض — تُضاف العلامة المائية إلى Slide Master، تُصمم بالكامل هناك، وتُطبَّق على جميع الشرائح دون التأثير على إذن تعديل العلامة المائية على الشرائح الفردية.

عادةً ما تعتبر العلامة المائية غير قابلة للتحرير من قبل المستخدمين الآخرين. لمنع تعديل العلامة المائية (أو الشكل الأب لها)، توفر Aspose.Slides خاصية قفل الشكل. يمكن قفل شكل محدد على شريحة عادية أو على Slide Master. عندما يُقفل شكل العلامة المائية على Slide Master، سيُقفل على جميع شرائح العرض.

يمكنك تعيين اسم للعلامة المائية بحيث يمكنك مستقبلاً، إذا رغبت بحذفها، العثور عليها بين أشكال الشريحة عبر الاسم.

يمكنك تصميم العلامة المائية بأي طريقة؛ ومع ذلك، توجد عادةً ميزات شائعة في العلامات المائية مثل المحاذاة المركزية، الدوران، الوضعية الأمامية، إلخ. سنستعرض كيفية استخدام هذه الخصائص في الأمثلة أدناه.

## **علامة مائية نصية**

### **إضافة علامة مائية نصية إلى شريحة**

لإضافة علامة مائية نصية في PPT أو PPTX أو ODP، يمكنك أولاً إضافة شكل إلى الشريحة، ثم إضافة إطار نصي إلى هذا الشكل. يُمثَّل الإطار النصي بواجهة [ITextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/). هذا النوع لا يُورث من [IShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/)، الذي يوفِّر مجموعة واسعة من الخصائص لتحديد موضع العلامة المائية بطريقة مرنة. لذلك، يُلف كائن [ITextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/) داخل كائن [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/). لإضافة نص العلامة المائية إلى الشكل، استخدم الطريقة [addTextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) كما هو موضح أدناه.

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="انظر أيضًا" %}} 
- [How to Use the TextFrame Class](/slides/ar/java/text-formatting/)
{{% /alert %}}

### **إضافة علامة مائية نصية إلى عرض تقديمي**

إذا أردت إضافة علامة مائية نصية إلى العرض بالكامل (أي جميع الشرائح مرة واحدة)، أضفها إلى [MasterSlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/masterslide/). يبقى باقي المنطق كما هو عند إضافة علامة مائية إلى شريحة واحدة — أنشئ كائن [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) ثم أضف العلامة المائية إليه باستخدام الطريقة [addTextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="انظر أيضًا" %}} 
- [How to Use the Slide Master](/slides/ar/java/slide-master/)
{{% /alert %}}

### **تعيين شفافية شكل العلامة المائية**

بشكل افتراضي، يُصمم الشكل المستطيل بألوان تعبئة وخط. الأسطر التالية من الشيفرة تجعل الشكل شفافًا.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

presentation.dispose();
```

### **تعيين الخط للعلامة المائية النصية**

يمكنك تغيير خط النص العلامة المائية كما هو موضح أدناه.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);

presentation.dispose();
```

### **تعيين لون نص العلامة المائية**

لتعيين لون نص العلامة المائية، استخدم الشيفرة التالية:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));

presentation.dispose();
```

### **محاذاة العلامة المائية النصية إلى الوسط**

يمكنك محاذاة العلامة المائية إلى وسط الشريحة، وذلك عبر ما يلي:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

الصورة أدناه تُظهر النتيجة النهائية.

![العلامة المائية النصية](text_watermark.png)

## **علامة مائية صورة**

### **إضافة علامة مائية صورة إلى عرض تقديمي**

لإضافة علامة مائية صورة إلى شريحة عرض تقديمي، يمكنك القيام بما يلي:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

presentation.dispose();
```

### **قفل العلامة المائية من التحرير**

إذا كان من الضروري منع تعديل العلامة المائية، استخدم الطريقة [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) على الشكل. عبر هذه الخاصية يمكنك حماية الشكل من الاختيار، إعادة التحجيم، إعادة الموضع، التجميع مع عناصر أخرى، قفل نصه من التحرير، والمزيد:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// قفل شكل العلامة المائية من التعديل
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);

presentation.dispose();
```

### **إظهار العلامة المائية في المقدمة**

في Aspose.Slides، يمكن ضبط ترتيب Z للأشكال عبر الطريقة [IShapeCollection.reorder](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). للقيام بذلك، استدعِ هذه الطريقة من قائمة شرائح العرض ومرّر مرجع الشكل ورقمه التسلسلي إلى الطريقة. بذلك يمكنك إظهار الشكل في المقدمة أو إرساله إلى الخلفية. هذه الميزة مفيدة خصوصًا إذا أردت وضع العلامة المائية أمام محتوى العرض:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);

presentation.dispose();
```

### **تعيين دوران العلامة المائية**

فيما يلي مثال شيفرة لتعديل دوران العلامة المائية بحيث تُوضع مائلة عبر الشريحة:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

Dimension2D slideSize = presentation.getSlideSize().getSize();

double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);

presentation.dispose();
```

### **تعيين اسم للعلامة المائية**

تتيح لك Aspose.Slides تعيين اسم للشكل. باستخدام اسم الشكل، يمكنك الوصول إليه لاحقًا لتعديله أو حذفه. لتعيين اسم شكل العلامة المائية، استخدم الطريقة [IAutoShape.setName](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#setName-java.lang.String-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.setName("watermark");

presentation.dispose();
```

### **إزالة العلامة المائية**

لإزالة شكل العلامة المائية، استخدم الطريقة [IAutoShape.getName](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/#getName--) للعثور عليه ضمن أشكال الشريحة. ثم مرّر الشكل إلى الطريقة [IShapeCollection.remove](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(shape);
    }
}

presentation.dispose();
```

## **الأسئلة المتكررة**

### ما هي العلامة المائية ولماذا ينبغي عليّ استخدامها؟

العلامة المائية هي طبقة نصية أو صورية تُطبق على الشرائح وتساعد على حماية الملكية الفكرية، تعزيز التعرف على العلامة التجارية، أو منع الاستخدام غير المصرح به للعرض.

### هل يمكنني إضافة علامة مائية إلى جميع الشرائح في عرض تقديمي؟

نعم، يُمكن لـ Aspose.Slides إضافة علامة مائية برمجيًا إلى كل شريحة في العرض. يمكنك التكرار عبر جميع الشرائح وتطبيق إعدادات العلامة المائية على كل واحدة على حدة.

### كيف يمكنني تعديل شفافية العلامة المائية؟

يمكنك تعديل شفافية العلامة المائية عن طريق تعديل إعدادات التعبئة ([getFillFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/shape/#getFillFormat--)) للشكل. يضمن ذلك أن تكون العلامة المائية خفيفة ولا تشوش محتوى الشريحة.

### ما صيغ الصور المدعومة للعلامات المائية؟

يدعم Aspose.Slides صيغ صور متعددة مثل PNG، JPEG، GIF، BMP، SVG، وغيرها.

### هل يمكنني تخصيص خط ونمط العلامة المائية النصية؟

نعم، يمكنك اختيار أي خط، حجم، ونمط لتتناسب مع تصميم عرضك وتُحافظ على اتساق العلامة التجارية.

### كيف أغيّر موضع أو اتجاه العلامة المائية؟

يمكنك تعديل موضع واتجاه العلامة المائية برمجيًا عبر تعديل إحداثيات الشكل، حجمه، وخصائص الدوران.