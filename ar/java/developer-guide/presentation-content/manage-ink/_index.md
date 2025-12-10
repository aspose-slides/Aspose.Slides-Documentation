---
title: إدارة كائنات الحبر في العروض التقديمية باستخدام Java
linktitle: إدارة الحبر
type: docs
weight: 95
url: /ar/java/manage-ink/
keywords:
- حبر
- كائن حبر
- تتبع الحبر
- إدارة الحبر
- رسم الحبر
- رسم
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "إدارة كائنات الحبر في PowerPoint—إنشاء وتحرير وتنسيق الحبر الرقمي باستخدام Aspose.Slides للغة Java. احصل على عينات كود للتتبع، ولون الفرشاة والحجم."
---

يقدم PowerPoint وظيفة الحبر لتسمح لك برسم أشكال غير قياسية، والتي يمكن استخدامها لتسليط الضوء على كائنات أخرى، وإظهار الاتصالات والعمليات، وجذب الانتباه إلى عناصر محددة على الشريحة. 

يوفر Aspose.Slides جميع أنواع الحبر (مثل الفئة [Ink](https://reference.aspose.com/slides/java/com.aspose.slides/ink/)) التي تحتاجها لإنشاء وإدارة كائنات الحبر. 

## **الاختلافات بين الكائنات العادية وكائنات الحبر**

عادةً ما يتم تمثيل الكائنات على شريحة PowerPoint بواسطة كائنات الشكل. كائن الشكل، في أبسط صوره، هو حاوية تحدد مساحة الكائن نفسه (إطاره) إلى جانب خصائصه. تشمل الأخيرة حجم مساحة الحاوية، شكل الحاوية، خلفية الحاوية، إلخ. للمزيد من المعلومات، راجع [Shape Layout Format](https://docs.aspose.com/slides/java/shape-manipulations/#access-layout-formats-for-shape).

ومع ذلك، عندما يتعامل PowerPoint مع كائن حبر، يتجاهل جميع خصائص إطار الكائن (الحاوية) باستثناء حجمه. يتم تحديد حجم مساحة الحاوية بواسطة القيم القياسية `width` و `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **آثار شكل الحبر**

التتبع هو عنصر أساسي أو معيار يستخدم لتسجيل مسار القلم عندما يكتب المستخدم الحبر الرقمي. التتبعات هي سجلات تصف سلاسل من النقاط المتصلة. 

أبسط شكل للترميز يحدد إحداثيات X و Y لكل نقطة عينة. عندما يتم رسم جميع النقاط المتصلة، ينتج عنها صورة مثل هذه:

![ink_powerpoint2](ink_powerpoint2.png)

## **خصائص الفرشاة للرسم**

يمكنك استخدام فرشاة لرسم خطوط تربط نقاط عناصر التتبع. للفرشاة لونها وحجمها الخاص، وفقًا لخصائص `Brush.Color` و `Brush.Size`. 

### **تعيين لون فرشاة الحبر**

This Java code shows you how to set the color for a brush:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Color brushColor = brush.getColor();
    brush.setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```


### **تعيين حجم فرشاة الحبر** 

This Java code shows you how to set the size for a brush:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Dimension2D brushSize = brush.getSize();
    brush.setSize(new Dimension(5, 10));
} finally {
    if (pres != null) pres.dispose();
}
```


عمومًا، لا يتطابق عرض الفرشاة وارتفاعها، لذلك لا يعرض PowerPoint حجم الفرشاة (يكون قسم البيانات مموهًا). ولكن عندما يتطابق عرض الفرشاة وارتفاعها، يعرض PowerPoint حجمه بهذه الطريقة:

![ink_powerpoint3](ink_powerpoint3.png)

للتوضيح، دعنا نزيد ارتفاع كائن الحبر ونستعرض الأبعاد المهمة: 

![ink_powerpoint4](ink_powerpoint4.png)

الحاوية (الإطار) لا تأخذ في الاعتبار حجم الفرشاة--دائمًا ما تفترض أن سمك الخط صفر (انظر الصورة الأخيرة). 

لذلك، لتحديد المنطقة المرئية لكامل كائن الحبر، يجب أن نأخذ في الاعتبار حجم فرشاة كائنات التتبع. هنا، تم تحجيم الكائن الهدف (كائن تتبع النص المكتوب يدويًا) إلى حجم الحاوية (الإطار). عندما يتغير حجم الحاوية (الإطار)، يبقى حجم الفرشاة ثابتًا والعكس صحيح. 

![ink_powerpoint5](ink_powerpoint5.png)

يظهر PowerPoint نفس السلوك عند التعامل مع النصوص:

![ink_powerpoint6](ink_powerpoint6.png)

**قراءة إضافية**

* لقراءة حول الأشكال بشكل عام، راجع قسم [PowerPoint Shapes](https://docs.aspose.com/slides/java/powerpoint-shapes/). 
* لمزيد من المعلومات حول القيم الفعّالة، راجع [Shape Effective Properties](https://docs.aspose.com/slides/java/shape-effective-properties/#getting-effective-font-height-value).