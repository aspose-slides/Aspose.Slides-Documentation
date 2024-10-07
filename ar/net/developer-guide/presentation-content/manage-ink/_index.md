---
title: إدارة الحبر
type: docs
weight: 95
url: /net/manage-ink/
keywords: "الحبر في PowerPoint، أدوات الحبر، C# الحبر، الرسم في PowerPoint، عرض PowerPoint، C#، Csharp، Aspose.Slides لـ .NET "
description: "استخدم أدوات الحبر لرسم أشياء في PowerPoint C#"
---

يقدم PowerPoint وظيفة الحبر للسماح لك برسم أشكال غير قياسية، والتي يمكن استخدامها لتسليط الضوء على أشياء أخرى، عرض الروابط والعمليات، وجذب الانتباه إلى عناصر محددة على الشريحة.

توفر Aspose.Slides واجهة [Aspose.Slides.Ink](https://reference.aspose.com/slides/net/aspose.slides.ink/) ، والتي تحتوي على الأنواع التي تحتاجها لإنشاء وإدارة كائنات الحبر.

## **الاختلافات بين كائن عادي وكائن الحبر**

عادةً ما يتم تمثيل الكائنات على شريحة PowerPoint بواسطة كائنات الشكل. كائن الشكل، في أبسط صوره، هو حاوية تحدد مساحة الكائن نفسه (إطاره) جنبًا إلى جنب مع خصائصه. تشمل الأخيرة حجم مساحة الحاوية، وشكل الحاوية، وخلفية الحاوية، إلخ. لمزيد من المعلومات، راجع [تنسيق تخطيط الشكل](https://docs.aspose.com/slides/net/shape-manipulations/#access-layout-formats-for-shape).

ومع ذلك، عندما يتعامل PowerPoint مع كائن حبر، يتجاهل جميع خصائص إطار الكائن (الحاوية) باستثناء حجمه. يتم تحديد حجم مساحة الحاوية بواسطة قيم `width` و `height` القياسية:

![ink_powerpoint1](ink_powerpoint1.png)

## **آثار أشكال الحبر**

الأثر هو عنصر أساسي أو معيار يستخدم لتسجيل مسار القلم أثناء كتابة المستخدم للحبر الرقمي. الآثار هي تسجيلات تصف تسلسلات من النقاط المتصلة.

أبسط شكل من أشكال التشفير يحدد إحداثيات X و Y لكل نقطة عينة. عند عرض جميع النقاط المتصلة، تنتج صورة مثل هذه:

![ink_powerpoint2](ink_powerpoint2.png)

## خصائص الفرشاة للرسم

يمكنك استخدام فرشاة لرسم خطوط تربط نقاط عناصر الأثر. تحتوي الفرشاة على لون وحجم خاص بها، يتوافقان مع خصائص `Brush.Color` و `Brush.Size`.

### **تعيين لون فرشاة الحبر**

يوضح لك هذا الكود C# كيفية تعيين اللون لفرشاة:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    IInk ink = (IInk)pres.Slides[0].Shapes[0];
    IInkTrace[] traces = ink.Traces;
    IInkBrush brush = traces[0].Brush;
    Color brushColor = brush.Color;
    brush.Color = Color.Red;
}
```

### **تعيين حجم فرشاة الحبر**

يوضح لك هذا الكود C# كيفية تعيين الحجم لفرشاة:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    IInk ink = (IInk)pres.Slides[0].Shapes[0];
    IInkTrace[] traces = ink.Traces;
    IInkBrush brush = traces[0].Brush;
    SizeF brushSize = brush.Size;
    brush.Size = new SizeF(5f, 10f);
}
```

بشكل عام، لا يتطابق عرض وارتفاع الفرشاة، لذا فإن PowerPoint لا يعرض حجم الفرشاة (يكون قسم البيانات رمادي اللون). لكن عندما يتطابق عرض وارتفاع الفرشاة، يعرض PowerPoint حجمه بهذه الطريقة:

![ink_powerpoint3](ink_powerpoint3.png)

للتوضيح، دعونا نزيد ارتفاع كائن الحبر ونراجع الأبعاد الهامة:

![ink_powerpoint4](ink_powerpoint4.png)

لا يأخذ الإطار (الحاوية) في الاعتبار حجم الفرشاة--بل يفترض دائمًا أن سمك الخط هو صفر (انظر الصورة الأخيرة).

لذلك، لتحديد المنطقة المرئية لكامل كائن الحبر، يجب أن نأخذ في الاعتبار حجم فرشاة كائنات الأثر. هنا، تم تغيير حجم الكائن المستهدف (كائن الأثر المكتوب بخط اليد) بما يتناسب مع حجم الإطار (الحاوية). عندما يتغير حجم الإطار (الحاوية)، يظل حجم الفرشاة ثابتًا والعكس صحيح.

![ink_powerpoint5](ink_powerpoint5.png)

يظهر PowerPoint نفس السلوك عند التعامل مع النصوص:

![ink_powerpoint6](ink_powerpoint6.png)

**قراءة إضافية**

* لقراءة حول الأشكال بشكل عام، انظر قسم [أشكال PowerPoint](https://docs.aspose.com/slides/net/powerpoint-shapes/).
* لمزيد من المعلومات حول القيم الفعالة، راجع [خصائص الشكل الفعالة](https://docs.aspose.com/slides/net/shape-effective-properties/#get-effective-font-height-value).