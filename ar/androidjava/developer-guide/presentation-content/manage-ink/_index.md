---
title: إدارة كائنات الحبر في العروض التقديمية على Android
linktitle: إدارة الحبر
type: docs
weight: 95
url: /ar/androidjava/manage-ink/
keywords:
- حبر
- كائن الحبر
- أثر الحبر
- إدارة الحبر
- رسم الحبر
- رسم
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إدارة كائنات الحبر في PowerPoint—إنشاء، تعديل وتنسيق الحبر الرقمي باستخدام Aspose.Slides لـ Android. احصل على عينات كود Java للتتبع، ولون الفرشاة وحجمها."
---

يقدّم PowerPoint وظيفة الحبر لتتيح لك رسم أشكال غير قياسية، يمكن استخدامها لتسليط الضوء على كائنات أخرى، وإظهار الاتصالات والعمليات، وجذب الانتباه إلى عناصر محددة في الشريحة.

توفر Aspose.Slides جميع أنواع الحبر (مثل الفئة [Ink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ink/)) التي تحتاجها لإنشاء وإدارة كائنات الحبر.

## **الاختلافات بين الكائنات العادية وكائنات الحبر**

عادةً ما يتم تمثيل الكائنات في شريحة PowerPoint بواسطة كائنات الشكل. كائن الشكل، بأبسط صوره، هو حاوية تحدد مساحة الكائن نفسه (الإطار) جنبًا إلى جنب مع خصائصه. تشمل الخصائص حجم مساحة الحاوية، وشكل الحاوية، وخلفية الحاوية، إلخ. للمزيد من المعلومات، راجع [تنسيق تخطيط الشكل](https://docs.aspose.com/slides/androidjava/shape-manipulations/#access-layout-formats-for-shape).

ومع ذلك، عندما يتعامل PowerPoint مع كائن حبر، يتجاهل جميع خصائص إطار الكائن (الحاوية) باستثناء حجمه. يتم تحديد حجم مساحة الحاوية بواسطة قيمي `width` و`height` القياسيتين:

![ink_powerpoint1](ink_powerpoint1.png)

## **آثار شكل الحبر**

الأثر هو عنصر أساسي أو معيار يُستخدم لتسجيل مسار القلم عندما يكتب المستخدم حبرًا رقميًا. الأثار هي تسجيلات تصف تسلسلات من النقاط المتصلة.

أبسط أشكال الترميز تحدد إحداثيات X وY لكل نقطة عينة. عندما تُرسم جميع النقاط المتصلة، ينتج عنها صورة مثل هذه:

![ink_powerpoint2](ink_powerpoint2.png)

## **خصائص الفرشاة للرسم**

يمكنك استخدام فرشاة لرسم خطوط تُربط نقاط عناصر الأثر. للفرشاة لونها وحجمها الخاص، ويتوافق ذلك مع خاصيتي `Brush.Color` و`Brush.Size`.

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


عمومًا، لا تتطابق عرض وارتفاع الفرشاة، لذلك لا يعرض PowerPoint حجم الفرشاة (يكون قسم البيانات رماديًا). ولكن عندما يتطابق عرض وارتفاع الفرشاة، يعرض PowerPoint حجمه بهذه الطريقة:

![ink_powerpoint3](ink_powerpoint3.png)

من أجل الوضوح، لنزيد ارتفاع كائن الحبر ونستعرض الأبعاد الهامة:

![ink_powerpoint4](ink_powerpoint4.png)

لا تأخذ الحاوية (الإطار) حجم الفرشاة في الاعتبار—فهي تفترض دائمًا أن سمك الخط صفر (انظر الصورة الأخيرة).

لذلك، لتحديد المنطقة الظاهرة لكامل كائن الحبر، يجب مراعاة حجم فرشاة عناصر الأثر. هنا، تم تحجيم الكائن الهدف (كائن أثر النص المكتوب بخط اليد) إلى حجم الحاوية (الإطار). عندما يتغير حجم الحاوية (الإطار)، يبقى حجم الفرشاة ثابتًا والعكس صحيح.

![ink_powerpoint5](ink_powerpoint5.png)

يظهر PowerPoint نفس السلوك عند التعامل مع النصوص:

![ink_powerpoint6](ink_powerpoint6.png)

**قراءة إضافية**

* لقراءة المزيد عن الأشكال بشكل عام، راجع قسم [PowerPoint Shapes](https://docs.aspose.com/slides/androidjava/powerpoint-shapes/).
* لمزيد من المعلومات حول القيم الفعالة، راجع [خصائص الشكل الفعالة](https://docs.aspose.com/slides/androidjava/shape-effective-properties/#getting-effective-font-height-value).