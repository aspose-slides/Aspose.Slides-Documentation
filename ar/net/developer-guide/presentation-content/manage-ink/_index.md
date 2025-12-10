---
title: إدارة كائنات الحبر في العرض التقديمي باستخدام .NET
linktitle: إدارة الحبر
type: docs
weight: 95
url: /ar/net/manage-ink/
keywords:
- حبر
- كائن حبر
- آثار الحبر
- إدارة الحبر
- رسم الحبر
- رسم
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إدارة كائنات الحبر في PowerPoint — إنشاء، تعديل وتنسيق الحبر الرقمي باستخدام Aspose.Slides لـ .NET. احصل على أمثلة شفرة لتتبع الآثار، لون الفرشاة وحجمها."
---

يقدم PowerPoint وظيفة الحبر لتسمح لك برسم أشكال غير قياسية، والتي يمكن استخدامها لتسليط الضوء على كائنات أخرى، وإظهار الاتصالات والعمليات، وجذب الانتباه إلى عناصر محددة في الشريحة.

توفر Aspose.Slides الواجهة [Aspose.Slides.Ink](https://reference.aspose.com/slides/net/aspose.slides.ink/) التي تحتوي على الأنواع التي تحتاجها لإنشاء وإدارة كائنات الحبر.

## **الاختلافات بين الكائنات العادية وكائنات الحبر**

عادةً ما يتم تمثيل الكائنات على شريحة PowerPoint بواسطة كائنات الشكل. كائن الشكل، بأبسط صوره، هو حاوية تحدد مساحة الكائن نفسه (إطاره) إلى جانب خصائصه. تشمل الأخيرة حجم مساحة الحاوية، وشكل الحاوية، وخلفية الحاوية، وما إلى ذلك. للمزيد من المعلومات، راجع [تنسيق تخطيط الشكل](https://docs.aspose.com/slides/net/shape-manipulations/#access-layout-formats-for-shape).

ومع ذلك، عندما يتعامل PowerPoint مع كائن حبر، يتجاهل جميع خصائص إطار الكائن (الحاوية) باستثناء حجمه. يتم تحديد حجم مساحة الحاوية بواسطة قيم `width` و `height` القياسية:

![ink_powerpoint1](ink_powerpoint1.png)

## **آثار شكل الحبر**

الأثر هو عنصر أساسي أو معيار يُستخدم لتسجيل مسار القلم عندما يكتب المستخدم حبرًا رقميًا. الآثار هي تسجيلات تصف تسلسلات من النقاط المتصلة.

أبسط صيغة للترميز تحدد إحداثيات X و Y لكل نقطة عينة. عندما يتم عرض جميع النقاط المتصلة، ينتج عنها صورة كهذه:

![ink_powerpoint2](ink_powerpoint2.png)

## **خصائص الفرشاة للرسم**

يمكنك استخدام فرشاة لرسم خطوط تربط نقاط عناصر الأثر. للفرشاة لونها وحجمها الخاص، ويتطابقان مع خصائص `Brush.Color` و `Brush.Size`.

### **تعيين لون فرشاة الحبر**

هذا الكود C# يوضح لك كيفية تعيين اللون للفرشاة:
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

هذا الكود C# يوضح لك كيفية تعيين الحجم للفرشاة:
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


بشكل عام، لا يتطابق عرض وارتفاع الفرشاة، لذا لا يعرض PowerPoint حجم الفرشاة (القسم الخاص بالبيانات مظلل). ولكن عندما يتطابق عرض وارتفاع الفرشاة، يعرض PowerPoint حجمه بهذه الطريقة:

![ink_powerpoint3](ink_powerpoint3.png)

للتوضيح، لنقم بزيادة ارتفاع كائن الحبر ومراجعة الأبعاد المهمة:

![ink_powerpoint4](ink_powerpoint4.png)

لا تأخذ الحاوية (الإطار) حجم الفرشاة في الاعتبار—دائمًا ما تفترض أن سمك الخط صفر (انظر الصورة الأخيرة).

لذلك، لتحديد المنطقة الظاهرة لكائن الحبر بالكامل، يجب مراعاة حجم فرشاة كائنات الأثر. هنا، تم تحجيم كائن الهدف (كائن أثر النص المكتوب يدويًا) إلى حجم الحاوية (الإطار). عندما يتغير حجم الحاوية (الإطار)، يبقى حجم الفرشاة ثابتًا والعكس صحيح.

![ink_powerpoint5](ink_powerpoint5.png)

يظهر PowerPoint نفس السلوك عند التعامل مع النصوص:

![ink_powerpoint6](ink_powerpoint6.png)

**قراءة إضافية**

* لقراءة المزيد عن الأشكال بشكل عام، راجع قسم [PowerPoint Shapes](https://docs.aspose.com/slides/net/powerpoint-shapes/).
* لمزيد من المعلومات حول القيم الفعّالة، راجع [خصائص الشكل الفعّالة](https://docs.aspose.com/slides/net/shape-effective-properties/#get-effective-font-height-value).