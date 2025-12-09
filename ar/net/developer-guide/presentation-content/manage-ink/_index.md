---
title: إدارة كائنات الحبر في العروض التقديمية باستخدام .NET
linktitle: إدارة الحبر
type: docs
weight: 95
url: /ar/net/manage-ink/
keywords:
- حبر
- كائن حبر
- تتبع الحبر
- إدارة الحبر
- رسم الحبر
- الرسم
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إدارة كائنات الحبر في PowerPoint—إنشاء، تعديل وتنسيق الحبر الرقمي باستخدام Aspose.Slides لـ .NET. احصل على عينات كود للتتبع، لون الفرشاة وحجمها."
---

يوفر PowerPoint وظيفة الحبر لتسمح لك برسم أشكال غير قياسية، يمكن استخدامها لتسليط الضوء على كائنات أخرى، وإظهار الاتصالات والعمليات، وجذب الانتباه إلى عناصر محددة في الشريحة. 

توفر Aspose.Slides الواجهة [Aspose.Slides.Ink](https://reference.aspose.com/slides/net/aspose.slides.ink/)، التي تحتوي على الأنواع التي تحتاجها لإنشاء وإدارة كائنات الحبر. 

## **الفرق بين الكائنات العادية وكائنات الحبر**

الكائنات على شريحة PowerPoint عادةً ما تمثل بواسطة كائنات الشكل. كائن الشكل، بأبسط صوره، هو حاوية تحدد مساحة الكائن نفسه (إطاره) إلى جانب خصائصه. تشمل الأخيرة حجم مساحة الحاوية، وشكل الحاوية، وخلفية الحاوية، إلخ. للحصول على معلومات، راجع [Shape Layout Format](https://docs.aspose.com/slides/net/shape-manipulations/#access-layout-formats-for-shape).

ومع ذلك، عندما يتعامل PowerPoint مع كائن حبر، يتجاهل جميع خصائص إطار الكائن (الحاوية) باستثناء حجمه. يتم تحديد حجم مساحة الحاوية بواسطة قيم `width` و `height` القياسية:

![ink_powerpoint1](ink_powerpoint1.png)

## **آثار شكل الحبر**

التتبع هو عنصر أساسي أو معيار يُستخدم لتسجيل مسار القلم عندما يكتب المستخدم الحبر الرقمي. التتبعات هي تسجيلات تصف سلاسل من النقاط المتصلة. 

أبسط شكل للتشفير يحدد إحداثيات X و Y لكل نقطة عينة. عندما يتم عرض جميع النقاط المتصلة، ينتج صورة كهذه:

![ink_powerpoint2](ink_powerpoint2.png)

## خصائص الفرشاة للرسم 

يمكنك استخدام فرشاة لرسم خطوط توصل بين نقاط عناصر التتبع. للفرشاة لونها وحجمها الخاص، ويتوافقان مع خصائص `Brush.Color` و `Brush.Size`. 

### **تعيين لون فرشاة الحبر**

يعرض هذا الكود C# كيفية تعيين اللون للفرشاة:
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

يعرض هذا الكود C# كيفية تعيين الحجم للفرشاة:
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


عمومًا، لا يتطابق عرض وارتفاع الفرشاة، لذا لا يعرض PowerPoint حجم الفرشاة (القسم الخاص بالبيانات مظلل بالرمادي). ولكن عندما يتطابق عرض وارتفاع الفرشاة، يعرض PowerPoint حجمه بهذه الطريقة:

![ink_powerpoint3](ink_powerpoint3.png)

للتوضيح، لنزيد ارتفاع كائن الحبر ونستعرض الأبعاد المهمة:

![ink_powerpoint4](ink_powerpoint4.png)

الحاوية (الإطار) لا تأخذ في الاعتبار حجم الفرشاة--دائمًا ما تفترض أن سمك الخط صفر (انظر الصورة الأخيرة). 

وبالتالي، لتحديد المنطقة المرئية لكائن الحبر بالكامل، يجب مراعاة حجم فرشاة كائنات التتبع. هنا، تم تحجيم الكائن الهدف (كائن تتبع النص المكتوب يدويًا) إلى حجم الحاوية (الإطار). عندما يتغير حجم الحاوية (الإطار)، يبقى حجم الفرشاة ثابتًا والعكس صحيح. 

![ink_powerpoint5](ink_powerpoint5.png)

يظهر PowerPoint نفس السلوك عند التعامل مع النصوص:

![ink_powerpoint6](ink_powerpoint6.png)

**قراءة إضافية**

* لقراءة حول الأشكال بشكل عام، راجع قسم [PowerPoint Shapes](https://docs.aspose.com/slides/net/powerpoint-shapes/). 
* لمزيد من المعلومات حول القيم الفعّالة، راجع [Shape Effective Properties](https://docs.aspose.com/slides/net/shape-effective-properties/#get-effective-font-height-value).