---
title: إدارة الحبر
type: docs
weight: 95
url: /java/manage-ink/
keywords: "الحبر في PowerPoint، أدوات الحبر، Java Ink، الرسم في PowerPoint، عرض PowerPoint، Java، Aspose.Slides for Java"
description: "استخدم أدوات الحبر لرسم الأشكال في PowerPoint Java"
---

يوفر PowerPoint وظيفة الحبر للسماح لك برسم أشكال غير قياسية، والتي يمكن استخدامها لتسليط الضوء على أشياء أخرى، وإظهار الروابط والعمليات، وجذب الانتباه إلى عناصر معينة على الشريحة.

تقدم Aspose.Slides جميع أنواع الحبر (مثل [Ink](https://reference.aspose.com/slides/java/com.aspose.slides/ink/) class) التي تحتاجها لإنشاء وإدارة كائنات الحبر.

## **الاختلافات بين الكائن العادي وكائنات الحبر**

عادةً ما تمثل الكائنات على شريحة PowerPoint من خلال كائنات الشكل. كائن الشكل، في أبسط صوره، هو حاوية تحدد منطقة الكائن نفسه (إطاره) جنبًا إلى جنب مع خصائصه. تشمل الأخيرة حجم منطقة الحاوية، وشكل الحاوية، وخلفية الحاوية، إلخ. لمزيد من المعلومات، الرجاء الاطلاع على [تنسيق تخطيط الشكل](https://docs.aspose.com/slides/java/shape-manipulations/#access-layout-formats-for-shape).

ومع ذلك، عندما تتعامل PowerPoint مع كائن حبر، فإنها تتجاهل جميع خصائص إطار الكائن (الحاوية) باستثناء حجمه. يتم تحديد حجم منطقة الحاوية باستخدام القيم القياسية `width` و `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **آثار شكل الحبر**

الأثر هو عنصر أساسي أو معيار يُستخدم لتسجيل مسار القلم عندما يكتب المستخدم الحبر الرقمي. الآثار هي تسجيلات تصف سلاسل من النقاط المتصلة.

أبسط أشكال الترميز تحدد إحداثيات X و Y لكل نقطة عينة. عندما يتم عرض جميع النقاط المتصلة، فإنها تنتج صورة مثل هذه:

![ink_powerpoint2](ink_powerpoint2.png)

## خصائص الفرشاة للرسم

يمكنك استخدام فرشاة لرسم خطوط تربط نقاط عناصر الأثر. تحتوي الفرشاة على لونها وحجمها الخاصين، وفقًا لخصائص `Brush.Color` و `Brush.Size`.

### **تعيين لون فرشاة الحبر**

يعرض هذا الكود بلغة Java كيفية تعيين اللون لفرشاة:

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

يعرض هذا الكود بلغة Java كيفية تعيين الحجم لفرشاة:

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

بشكل عام، لا تتوافق عرض وارتفاع الفرشاة، لذلك لا تعرض PowerPoint حجم الفرشاة (القسم الخاص بالبيانات مموه). ولكن عندما يتطابق عرض وارتفاع الفرشاة، تعرض PowerPoint حجمها بهذه الطريقة:

![ink_powerpoint3](ink_powerpoint3.png)

للتوضيح، دعنا نقم بزيادة ارتفاع كائن الحبر ومراجعة الأبعاد المهمة:

![ink_powerpoint4](ink_powerpoint4.png)

لا تأخذ الحاوية (الإطار) في الاعتبار حجم الفرشاة--إنها تفترض دائمًا أن سمك الخط هو صفر (انظر الصورة الأخيرة).

لذلك، لتحديد المنطقة المرئية لكائن الحبر بالكامل، يجب أن نأخذ في الاعتبار حجم فرشاة كائنات الأثر. هنا، تم تغيير حجم الكائن المستهدف (كائن أثر النص المكتوب بخط اليد) ليتناسب مع حجم الحاوية (الإطار). عندما يتغير حجم الحاوية (الإطار)، يظل حجم الفرشاة ثابتًا والعكس صحيح.

![ink_powerpoint5](ink_powerpoint5.png)

تظهر PowerPoint نفس السلوك عند التعامل مع النصوص:

![ink_powerpoint6](ink_powerpoint6.png)

**قراءة إضافية**

* لقراءة حول الأشكال بشكل عام، راجع قسم [أشكال PowerPoint](https://docs.aspose.com/slides/java/powerpoint-shapes/).
* لمزيد من المعلومات حول القيم الفعالة، راجع [خصائص الشكل الفعالة](https://docs.aspose.com/slides/java/shape-effective-properties/#getting-effective-font-height-value).