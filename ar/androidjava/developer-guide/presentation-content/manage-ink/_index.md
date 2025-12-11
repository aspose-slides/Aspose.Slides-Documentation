---
title: إدارة كائنات الحبر في العروض التقديمية على Android
linktitle: إدارة الحبر
type: docs
weight: 95
url: /ar/androidjava/manage-ink/
keywords:
- حبر
- كائن حبر
- أثر الحبر
- إدارة الحبر
- رسم الحبر
- رسم
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إدارة كائنات الحبر في PowerPoint — إنشاء وتحرير وتنسيق الحبر الرقمي باستخدام Aspose.Slides لـ Android. احصل على نماذج شفرة Java لأثر الحبر، ولون الفرشاة وحجمها."
---

يوفر PowerPoint وظيفة الحبر لتمكينك من رسم أشكال غير قياسية، والتي يمكن استخدامها لتسليط الضوء على كائنات أخرى، وإظهار الاتصالات والعمليات، وجذب الانتباه إلى عناصر محددة في الشريحة.

Aspose.Slides يوفر جميع أنواع الحبر (مثل فئة [Ink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ink/) ) التي تحتاجها لإنشاء وإدارة كائنات الحبر.

## **الاختلافات بين الكائنات العادية وكائنات الحبر**

عادةً ما يتم تمثيل الكائنات على شريحة PowerPoint بواسطة كائنات الشكل. كائن الشكل، بأبسط صوره، هو حاوية تُحدد مساحة الكائن نفسه (إطاره) إلى جانب خصائصه. تشمل هذه الخصائص حجم مساحة الحاوية، وشكل الحاوية، وخلفية الحاوية، وما إلى ذلك. للمزيد من المعلومات، راجع [Shape Layout Format](https://docs.aspose.com/slides/androidjava/shape-manipulations/#access-layout-formats-for-shape).

ومع ذلك، عندما يتعامل PowerPoint مع كائن حبر، يتجاهل جميع خصائص إطار الكائن (الحاوية) باستثناء حجمه. يتم تحديد حجم مساحة الحاوية بواسطة قيم `width` و `height` القياسية:

![ink_powerpoint1](ink_powerpoint1.png)

## **آثار شكل الحبر**

الآثر هو عنصر أساسي أو معيار يستخدم لتسجيل مسار القلم عندما يكتب المستخدم بالحبر الرقمي. الآثار هي تسجيلات تصف تسلسلات من النقاط المتصلة.

أبسط شكل من الترميز يُحدّد إحداثيات X و Y لكل نقطة عينة. عندما يتم عرض جميع النقاط المتصلة، ينتج عنها صورة كهذه:

![ink_powerpoint2](ink_powerpoint2.png)

## **خصائص الفرشاة للرسم**

يمكنك استخدام فرشاة لرسم خطوط تصل بين نقاط عناصر الأثر. للفرشاة لونها وحجمها الخاص، ويتوافقان مع خاصيتي `Brush.Color` و `Brush.Size`.

### **تعيين لون فرشاة الحبر**

يظهر لك هذا الكود Java كيفية تعيين اللون للفرشاة:
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

يظهر لك هذا الكود Java كيفية تعيين الحجم للفرشاة:
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


عمومًا، لا يتطابق عرض الفرشاة وارتفاعها، لذا لا يعرض PowerPoint حجم الفرشاة (يكون قسم البيانات مظللًا). ولكن عندما يتطابق عرض الفرشاة وارتفاعها، يعرض PowerPoint حجمه بهذه الطريقة:

![ink_powerpoint3](ink_powerpoint3.png)

للتوضيح، لنقم بزيادة ارتفاع كائن الحبر ومراجعة الأبعاد المهمة:

![ink_powerpoint4](ink_powerpoint4.png)

لا تعتبر الحاوية (الإطار) حجم الفرشاة—فهي دائمًا تفترض أن سماكة الخط صفر (انظر الصورة الأخيرة).

لذلك، لتحديد المنطقة المرئية لكامل كائن الحبر، يجب أن نأخذ في الاعتبار حجم فرشاة كائنات الآثر. هنا، تم تحجيم كائن الهدف (كائن آثر النص المكتوب يدويًا) إلى حجم الحاوية (الإطار). عندما يتغير حجم الحاوية (الإطار)، يظل حجم الفرشاة ثابتًا والعكس صحيح.

![ink_powerpoint5](ink_powerpoint5.png)

يعرض PowerPoint السلوك نفسه عند التعامل مع النصوص:

![ink_powerpoint6](ink_powerpoint6.png)

**قراءة إضافية**

* لقراءة حول الأشكال بشكل عام، راجع قسم [PowerPoint Shapes](https://docs.aspose.com/slides/androidjava/powerpoint-shapes/).
* لمزيد من المعلومات حول القيم الفعّالة، راجع [Shape Effective Properties](https://docs.aspose.com/slides/androidjava/shape-effective-properties/#getting-effective-font-height-value).