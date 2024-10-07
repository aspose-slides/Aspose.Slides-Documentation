---
title: إدارة الحبر
type: docs
weight: 95
url: /androidjava/manage-ink/
keywords: "الحبر في PowerPoint، أدوات الحبر، Java Ink، الرسم في PowerPoint، عرض PowerPoint، Java، Aspose.Slides لـ Android عبر Java"
description: "استخدم أدوات الحبر لرسم كائنات في PowerPoint Java"
---

يوفر PowerPoint وظيفة الحبر للسماح لك برسم أشكال غير قياسية، والتي يمكن استخدامها لتسليط الضوء على كائنات أخرى، وإظهار الاتصالات والعمليات، وجذب الانتباه إلى عناصر معينة في الشريحة.

توفر Aspose.Slides جميع أنواع الحبر (مثل [Ink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ink/) class) التي تحتاجها لإنشاء وإدارة كائنات الحبر.

## **الاختلافات بين الكائنات العادية وكائنات الحبر**

عادةً ما يتم تمثيل الكائنات الموجودة في شريحة PowerPoint بواسطة كائنات الشكل. في أبسط أشكالها، كائن الشكل هو حاوية تحدد مساحة الكائن نفسه (إطارها) جنبًا إلى جنب مع خصائصها. تشمل الأخيرة حجم منطقة الحاوية، وشكل الحاوية، وخلفية الحاوية، إلخ. لمزيد من المعلومات، انظر [تنسيق تخطيط الشكل](https://docs.aspose.com/slides/androidjava/shape-manipulations/#access-layout-formats-for-shape).

ومع ذلك، عندما يتعامل PowerPoint مع كائن حبر، فإنه يتجاهل جميع خصائص إطار الكائن (الحاوية) باستثناء حجمه. يتم تحديد حجم منطقة الحاوية بواسطة القيم القياسية `width` و `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **أثر أشكال الحبر**

الأثر هو عنصر أساسي أو معيار يُستخدم لتسجيل مسار القلم أثناء كتابة المستخدم للحبر الرقمي. الآثار هي تسجيلات تصف تسلسلات من النقاط المتصلة.

يحدد الشكل الأبسط للتشفير إحداثيات X و Y لكل نقطة عينة. عند رسم جميع النقاط المتصلة، فإنها تنتج صورة مثل هذه:

![ink_powerpoint2](ink_powerpoint2.png)

## خصائص الفرشاة للرسم

يمكنك استخدام فرشاة لرسم خطوط تربط نقاط عناصر الأثر. تحتوي الفرشاة على لونها وحجمها الخاص، ويتوافق مع خصائص `Brush.Color` و `Brush.Size`.

### **تعيين لون فرشاة الحبر**

هذا الرمز بلغة Java يوضح لك كيفية تعيين اللون لفرشاة:

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

هذا الرمز بلغة Java يوضح لك كيفية تعيين الحجم لفرشاة:

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

بشكل عام، قد لا تتطابق العرض والارتفاع للفرشاة، لذا لا يعرض PowerPoint حجم الفرشاة (قسم البيانات يكون رمادي اللون). ولكن عندما يتطابق عرض الفرشاة وارتفاعها، يعرض PowerPoint حجمها بهذه الطريقة:

![ink_powerpoint3](ink_powerpoint3.png)

للتوضيح، دعونا نزيد ارتفاع كائن الحبر ونراجع الأبعاد المهمة:

![ink_powerpoint4](ink_powerpoint4.png)

لا تأخذ الحاوية (الإطار) في اعتبارها حجم الفرشاة - فهي تفترض دائمًا أن سمك الخط هو صفر (انظر الصورة الأخيرة).

لذلك، لتحديد المنطقة المرئية لكائن الحبر بالكامل، يجب علينا النظر في حجم فرشاة كائنات الأثر. هنا، تم تعديل مقياس الكائن الهدف (كائن أثر النص المكتوب بخط اليد) ليتناسب مع حجم الحاوية (الإطار). عندما يتغير حجم الحاوية (الإطار)، يظل حجم الفرشاة ثابتًا والعكس صحيح.

![ink_powerpoint5](ink_powerpoint5.png)

يظهر PowerPoint نفس السلوك عند التعامل مع النصوص:

![ink_powerpoint6](ink_powerpoint6.png)

**قراءة إضافية**

* لقراءة حول الأشكال بشكل عام، انظر قسم [أشكال PowerPoint](https://docs.aspose.com/slides/androidjava/powerpoint-shapes/).
* لمزيد من المعلومات حول القيم الفعالة، انظر [خصائص الشكل الفعالة](https://docs.aspose.com/slides/androidjava/shape-effective-properties/#getting-effective-font-height-value).