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
description: "إدارة العلامات المائية النصية والصورية في عروض PowerPoint وOpenDocument على Android باستخدام Java لتوضيح مسودة أو معلومات سرية والمزيد."
---
## **مقدمة**

**علامة مائية** في العرض التقديمي هي طباعة نصية أو صورة تُستخدم على شريحة أو على جميع شرائح العرض. عادةً تُستَخدم العلامة المائية للإشارة إلى أن العرض مسودة (مثلاً، علامة مائية "مسودة")، أو أنه يحتوي على معلومات سرية (مثلاً، علامة مائية "سري")، أو لتحديد الشركة المالكة (مثلاً، علامة مائية "اسم الشركة")، أو لتحديد مؤلف العرض، إلخ. تساعد العلامة المائية على منع انتهاكات حقوق النشر من خلال الإشارة إلى أنه لا ينبغي نسخ العرض. تُستَخدم العلامات المائية في صيغتي PowerPoint وOpenOffice. في Aspose.Slides يمكنك إضافة علامة مائية إلى صيغ ملفات PowerPoint PPT وPPTX وOpenOffice ODP.

في [**Aspose.Slides**](https://products.aspose.com/slides/ar/android-java/)، هناك طرق متعددة لإنشاء علامات مائية في مستندات PowerPoint أو OpenOffice وتعديل تصميمها وسلوكها. الجانب المشترك هو أنه لإضافة علامات مائية نصية، يجب استخدام واجهة [ITextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/)، ولإضافة علامات مائية صورة، استخدم الفئة [PictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pictureframe/) أو املأ شكل العلامة المائية بصورة. `PictureFrame` يطبق واجهة [IShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/) مما يتيح لك استخدام جميع إعدادات الشكل المرنة. نظرًا لأن `ITextFrame` ليس شكلاً وإعداداته محدودة، يتم تغليفه داخل كائن [IShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/).

هناك طريقتان لتطبيق العلامة المائية: على شريحة واحدة أو على جميع شرائح العرض. يُستخدَم Master Slide لتطبيق العلامة المائية على جميع الشرائح — تُضاف العلامة المائية إلى Master Slide، تُصمم هناك بالكامل، وتُطبق على جميع الشرائح دون التأثير على إمكانية تعديل العلامة المائية على الشرائح الفردية.

عادةً ما تُعتبر العلامة المائية غير قابلة للتعديل من قبل المستخدمين الآخرين. لمنع تعديل العلامة المائية (أو الشكل الأب لها) توفر Aspose.Slides وظيفة قفل الشكل. يمكن قفل شكل معين على شريحة عادية أو على Master Slide. عندما يُقفل شكل العلامة المائية على Master Slide، يُقفل على جميع شرائح العرض.

يمكنك تعيين اسم للعلامة المائية حتى تتمكن في المستقبل من حذفها بالبحث عنها في أشكال الشريحة حسب الاسم.

يمكنك تصميم العلامة المائية بأي طريقة؛ إلا أن هناك سمات شائعة عادةً في العلامات المائية، مثل المركزية، الدوران، الوضعية الأمامية، إلخ. سنستعرض كيف نستخدم هذه السمات في الأمثلة أدناه.

## **علامة مائية نصية**

### **إضافة علامة مائية نصية إلى شريحة**

لإضافة علامة مائية نصية في PPT أو PPTX أو ODP، يمكنك أولاً إضافة شكل إلى الشريحة، ثم إضافة إطار نص إلى هذا الشكل. يُمثَّل إطار النص بواجهة [ITextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/). هذا النوع لا يُورث من [IShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/)، الذي يحتوي على مجموعة واسعة من الخصائص لتحديد موقع العلامة المائية بطريقة مرنة. لذلك يُغلق كائن [ITextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/) داخل كائن [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/). لإضافة نص العلامة المائية إلى الشكل، استخدم الطريقة [addTextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) كما هو موضح أدناه.

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="See also" %}} 
- [How to Use the TextFrame Class](/slides/ar/androidjava/text-formatting/)
{{% /alert %}}

### **إضافة علامة مائية نصية إلى عرض تقديمي**

إذا كنت تريد إضافة علامة مائية نصية إلى كامل العرض (أي جميع الشرائح مرة واحدة)، أضفها إلى [MasterSlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/masterslide/). باقي المنطق هو نفسه كما عند إضافة علامة مائية إلى شريحة واحدة — أنشئ كائن [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) ثم أضف العلامة المائية إليه باستخدام الطريقة [addTextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="See also" %}} 
- [How to Use the Slide Master](/slides/ar/androidjava/slide-master/)
{{% /alert %}}

### **ضبط شفافية شكل العلامة المائية**

بشكل افتراضي، يُصمم الشكل المستطيل بألوان ملء وخط. السطور التالية من الشيفرة تجعل الشكل شفافًا.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.getFillFormat().setFillType(FillType.NoFill);
    watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
} finally {
    presentation.dispose();
}
```

### **تعيين الخط للعلامة المائية النصية**

يمكنك تغيير خط النص كما هو موضح أدناه.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    textFormat.setLatinFont(new FontData("Arial"));
    textFormat.setFontHeight(50);
} finally {
    presentation.dispose();
}
```

### **ضبط لون نص العلامة المائية**

لتعيين لون نص العلامة المائية، استخدم الشيفرة التالية:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 150, red = 200, green = 200, blue = 200;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
    fillFormat.setFillType(FillType.Solid);
    fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
} finally {
    presentation.dispose();
}
```

### **توسيط علامة مائية نصية**

يمكنك توسيط العلامة المائية على الشريحة، وللقيام بذلك نفّذ ما يلي:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    float watermarkWidth = 400;
    float watermarkHeight = 40;
    float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
    float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

    IAutoShape watermarkShape = slide.getShapes().addAutoShape(
            ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

    ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
} finally {
    presentation.dispose();
}
```

الصورة أدناه تُظهر النتيجة النهائية.

![علامة مائية نصية](text_watermark.png)

## **علامة مائية صورة**

### **إضافة علامة مائية صورة إلى عرض تقديمي**

لإضافة علامة مائية صورة إلى شريحة عرض تقديمي، يمكنك تنفيذ ما يلي:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    InputStream imageStream = new FileInputStream("watermark.png");
    IPPImage image = presentation.getImages().addImage(imageStream);

    watermarkShape.getFillFormat().setFillType(FillType.Picture);
    watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
} finally {
    presentation.dispose();
}
```

### **قفل علامة مائية من التعديل**

إذا كان من الضروري منع تعديل العلامة المائية، استخدم الطريقة [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) على الشكل. باستخدام هذه الخاصية، يمكنك حماية الشكل من الاختيار، وإعادة التحجيم، وإعادة الموقع، وتجميعه مع عناصر أخرى، وقفل نصه من التعديل، وغير ذلك الكثير:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    // قفل شكل العلامة المائية من التعديل
    watermarkShape.getAutoShapeLock().setSelectLocked(true);
    watermarkShape.getAutoShapeLock().setSizeLocked(true);
    watermarkShape.getAutoShapeLock().setTextLocked(true);
    watermarkShape.getAutoShapeLock().setPositionLocked(true);
    watermarkShape.getAutoShapeLock().setGroupingLocked(true);
} finally {
    presentation.dispose();
}
```

### **جلب علامة مائية إلى الأمام**

في Aspose.Slides، يمكن ضبط ترتيب الأشكال (Z-order) عبر الطريقة [IShapeCollection.reorder](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). للقيام بذلك، تحتاج لاستدعاء هذه الطريقة من قائمة شرائح العرض وتمرير مرجع الشكل ورقم ترتيبه إلى الطريقة. بهذه الطريقة يمكن جلب شكل إلى الأمام أو إرساله إلى الخلف في الشريحة. هذه الميزة مفيدة خصوصًا إذا رغبت في وضع العلامة المائية أمام محتوى العرض:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    int shapeCount = slide.getShapes().size();
    slide.getShapes().reorder(shapeCount - 1, watermarkShape);
} finally {
    presentation.dispose();
}
```

### **ضبط دوران العلامة المائية**

فيما يلي مثال على الشيفرة لضبط دوران العلامة المائية بحيث تُوضع بزاوية مائلة عبر الشريحة:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

    watermarkShape.setRotation((float)diagonalAngle);
} finally {
    presentation.dispose();
}
```

### **تعيين اسم للعلامة المائية**

تتيح Aspose.Slides لك تعيين اسم للشكل. باستخدام اسم الشكل، يمكنك الوصول إليه لاحقًا لتعديله أو حذفه. لتعيين اسم شكل العلامة المائية، استخدم الطريقة [IAutoShape.setName](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.setName("watermark");
} finally {
    presentation.dispose();
}
```

### **إزالة علامة مائية**

لإزالة شكل العلامة المائية، استخدم الطريقة [IAutoShape.getName](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/#getName--) للعثور عليه في أشكال الشريحة. ثم، مرّر شكل العلامة المائية إلى الطريقة [IShapeCollection.remove](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("watermarked.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape[] slideShapes = slide.getShapes().toArray();
    for (IShape shape : slideShapes) {
        if ("watermark".equals(shape.getName()))
        {
            slide.getShapes().remove(shape);
        }
    }
} finally {
    presentation.dispose();
}
```

## **الأسئلة المتكررة**

### ما هي العلامة المائية ولماذا يجب استخدامها؟

العلامة المائية هي طبقة نصية أو صورة تُطبق على الشرائح وتساعد في حماية الملكية الفكرية، وتعزيز التعرف على العلامة التجارية، أو منع الاستخدام غير المصرّح به للعروض.

### هل يمكنني إضافة علامة مائية إلى جميع الشرائح في عرض تقديمي؟

نعم، تتيح Aspose.Slides إضافة علامة مائية برمجيًا إلى كل شريحة في العرض. يمكنك التنقل عبر جميع الشرائح وتطبيق إعدادات العلامة المائية على كل واحدة على حدة.

### كيف يمكنني ضبط شفافية العلامة المائية؟

يمكنك ضبط شفافية العلامة المائية عن طريق تعديل إعدادات الملء ([getFillFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/shape/#getFillFormat--)) للشكل. يضمن ذلك أن تكون العلامة المائية خفيفة ولا تشتت انتباه المشاهد عن محتوى الشريحة.

### ما صيغ الصور المدعومة للعلامات المائية؟

تدعم Aspose.Slides صيغ صور متعددة مثل PNG وJPEG وGIF وBMP وSVG وغيرها.

### هل يمكنني تخصيص الخط والنمط للعلامة المائية النصية؟

نعم، يمكنك اختيار أي خط وحجم ونمط لتتناسب مع تصميم العرض وتحافظ على اتساق العلامة التجارية.

### كيف أغيّر موضع أو اتجاه العلامة المائية؟

يمكنك تعديل موضع العلامة المائية واتجاهها برمجيًا عن طريق تعديل إحداثيات الشكل، وحجمه، وخصائص الدوران.