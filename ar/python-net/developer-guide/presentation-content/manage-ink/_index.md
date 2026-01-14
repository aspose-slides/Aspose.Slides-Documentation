---
title: إدارة كائنات الحبر في العروض التقديمية باستخدام بايثون
linktitle: إدارة الحبر
type: docs
weight: 95
url: /ar/python-net/manage-ink/
keywords:
- حبر
- كائن حبر
- أثر حبر
- إدارة الحبر
- رسم الحبر
- رسم
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "إدارة كائنات الحبر في PowerPoint — إنشاء, تعديل وتنسيق الحبر الرقمي باستخدام Aspose.Slides للبايثون عبر .NET. احصل على أمثلة شفرة للأثار، لون الفرشاة وحجمها."
---

يُوفر PowerPoint وظيفة الحبر (ink) لتتيح لك رسم أشكال غير قياسية، والتي يمكن استخدامها لتسليط الضوء على كائنات أخرى، وإظهار الاتصالات والعمليات، وجذب الانتباه إلى عناصر معينة على الشريحة. 

توفر Aspose.Slides مساحة الاسم [aspose.slides.ink](https://reference.aspose.com/slides/python-net/aspose.slides.ink/) التي تحتوي على الأنواع التي تحتاجها لإنشاء وإدارة كائنات الحبر. 

## **الاختلافات بين الكائنات العادية وكائنات الحبر**

عادةً ما يتم تمثيل الكائنات على شريحة PowerPoint بواسطة كائنات الشكل. كائن الشكل، في أبسط صوره، هو حاوية تُحدِّد مساحة الكائن نفسه (الإطار) إلى جانب خصائصه. تشمل الأخيرة حجم مساحة الحاوية، شكل الحاوية، خلفية الحاوية، وما إلى ذلك. للمزيد من المعلومات، راجع [Shape Layout Format](https://docs.aspose.com/slides/python-net/shape-manipulations/#access-layout-formats-for-shape).

ومع ذلك، عندما يتعامل PowerPoint مع كائن حبر، يتجاهل جميع خصائص إطار الكائن (الحاوية) باستثناء حجمه. يتم تحديد حجم مساحة الحاوية بالقيم القياسية `width` و `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **آثار شكل الحبر (Inkshape Traces)**

الأثر هو عنصر أساسي أو معيار يُستخدم لتسجيل مسار القلم أثناء كتابة الحبر الرقمي. الأثار هي تسجيلات تصف تسلسلات من النقاط المتصلة. 

أبسط شكل للتشفير يحدد إحداثيات X و Y لكل نقطة عينة. عندما تُرسم جميع النقاط المتصلة، ينتج عنها صورة مثل هذه:

![ink_powerpoint2](ink_powerpoint2.png)

## خصائص الفرشاة للرسم 

يمكنك استخدام فرشاة لرسم خطوط تربط نقاط عناصر الأثر. للفرشاة لونها وحجمها الخاص، ويتطابق ذلك مع الخصائص `Brush.color` و `Brush.size`. 

### **تعيين لون فرشاة الحبر**

يعرض هذا الكود Python كيفية تعيين اللون للفرشاة:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_color = brush.color
    brush.color = draw.Color.red
```


### **تعيين حجم فرشاة الحبر** 

يعرض هذا الكود Python كيفية تعيين الحجم للفرشاة:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_size = brush.size
    brush.size = draw.SizeF(5.0, 10.0)
```


عمومًا، لا يتطابق عرض وارتفاع الفرشاة، لذا لا يعرض PowerPoint حجم الفرشاة (يكون قسم البيانات مظللًا). لكن عندما يتطابق عرض وارتفاع الفرشاة، يعرض PowerPoint حجمه بهذه الطريقة:

![ink_powerpoint3](ink_powerpoint3.png)

للتوضيح، لنزيد ارتفاع كائن الحبر ونستعرض الأبعاد المهمة:

![ink_powerpoint4](ink_powerpoint4.png)

لا تعتبر الحاوية (الإطار) حجم الفرشاة—فهي تفترض دائمًا أن سماكة الخط صفر (انظر الصورة الأخيرة). 

لذلك، لتحديد المنطقة المرئية لكامل كائن الحبر، يجب أن نأخذ في الاعتبار حجم فرشاة كائنات الأثر. هنا، تم تحجيم الكائن الهدف (كائن أثر النص المكتوب يدويًا) ليتناسب مع حجم الحاوية (الإطار). عندما يتغير حجم الحاوية (الإطار)، يظل حجم الفرشاة ثابتًا والعكس صحيح.

![ink_powerpoint5](ink_powerpoint5.png)

يظهر PowerPoint نفس السلوك عند التعامل مع النصوص:

![ink_powerpoint6](ink_powerpoint6.png)

**مزيد من القراءة**

* لقراءة حول الأشكال بشكل عام، راجع قسم [PowerPoint Shapes](https://docs.aspose.com/slides/python-net/powerpoint-shapes/). 
* لمزيد من المعلومات حول القيم الفعالة، اطلع على [Shape Effective Properties](https://docs.aspose.com/slides/python-net/shape-effective-properties/#get-effective-font-height-value).