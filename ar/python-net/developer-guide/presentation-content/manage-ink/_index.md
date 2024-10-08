---
title: إدارة الحبر
type: docs
weight: 95
url: /ar/python-net/manage-ink/
keywords: "الحبر في PowerPoint، أدوات الحبر، حبر Python، الرسم في PowerPoint، عرض PowerPoint، Python، Aspose.Slides لـ Python عبر .NET"
description: "استخدم أدوات الحبر لرسم كائنات في PowerPoint Python"
---

يقدم PowerPoint وظيفة الحبر للسماح لك برسم أشكال غير قياسية، والتي يمكن استخدامها لتسليط الضوء على كائنات أخرى، وإظهار الاتصالات والعمليات، وجذب الانتباه إلى عناصر معينة في الشريحة. 

توفر Aspose.Slides واجهة [Aspose.Slides.Ink](https://reference.aspose.com/slides/python-net/aspose.slides.ink/) التي تحتوي على الأنواع التي تحتاجها لإنشاء وإدارة كائنات الحبر. 

## **اختلافات بين الكائنات العادية وكائنات الحبر**

عادةً ما يمثل الكائنات في شريحة PowerPoint بواسطة كائنات الشكل. كائن الشكل، في أبسط أشكاله، هو حاوية تعرف مساحة الكائن نفسه (إطارها) جنبًا إلى جنب مع خصائصه. وتشمل هذه الخصائص حجم منطقة الحاوية، وشكل الحاوية، وخلفية الحاوية، وما إلى ذلك. لمزيد من المعلومات، راجع [تنسيق تخطيط الشكل](https://docs.aspose.com/slides/python-net/shape-manipulations/#access-layout-formats-for-shape).

ومع ذلك، عندما يتعامل PowerPoint مع كائن حبر، فإنه يتجاهل جميع خصائص إطار الكائن (الحاوية) باستثناء حجمه. يتم تحديد حجم منطقة الحاوية بواسطة قيم `width` و `height` القياسية:

![ink_powerpoint1](ink_powerpoint1.png)

## **مسارات شكل الحبر**

المسار هو عنصر أساسي أو معيار يستخدم لتسجيل مسار قلم المستخدم أثناء كتابة الحبر الرقمي. المسارات هي تسجيلات تصف تسلسلات من النقاط المتصلة. 

تحدد أبسط أشكال الترميز إحداثيات X و Y لكل نقطة عينة. عندما يتم عرض جميع النقاط المتصلة، فإنها تنتج صورة مثل هذه:

![ink_powerpoint2](ink_powerpoint2.png)

## خصائص الفرشاة للرسم 

يمكنك استخدام فرشاة لرسم خطوط تربط نقاط عناصر المسار. تحتوي الفرشاة على لون وحجم خاصين بها، يتوافقان مع خصائص `Brush.Color` و `Brush.Size`. 

### **تعيين لون فرشاة الحبر**

تظهر لك هذه الشفرة البرمجية في Python كيفية تعيين لون فرشاة:

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

تظهر لك هذه الشفرة البرمجية في Python كيفية تعيين حجم فرشاة:

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

بشكل عام، لا تتطابق عرض وارتفاع الفرشاة، لذا لا يعرض PowerPoint حجم الفرشاة (يكون قسم البيانات رماديًا). لكن عندما يتطابق عرض وارتفاع الفرشاة، يعرض PowerPoint حجمه بهذه الطريقة:

![ink_powerpoint3](ink_powerpoint3.png)

للتوضيح، دعونا نزيد من ارتفاع كائن الحبر ونراجع الأبعاد الهامة: 

![ink_powerpoint4](ink_powerpoint4.png)

لا تأخذ الحاوية (الإطار) في الاعتبار حجم الفرشات--فهي تفترض دائمًا أن سمك الخط هو صفر (انظر الصورة الأخيرة). 

لذلك، لتحديد المنطقة المرئية لكامل كائن الحبر، يجب علينا مراعاة حجم فرشاة كائنات المسار. هنا، تم تحويل الكائن المستهدف (كائن مسار النص المكتوب باليد) إلى حجم الحاوية (الإطار). عندما يتغير حجم الحاوية (الإطار)، يظل حجم الفرشاة ثابتًا والعكس صحيح. 

![ink_powerpoint5](ink_powerpoint5.png)

يظهر PowerPoint نفس السلوك عند التعامل مع النصوص:

![ink_powerpoint6](ink_powerpoint6.png)

**قراءة متقدمة**

* لقراءة المزيد حول الأشكال بشكل عام، راجع قسم [أشكال PowerPoint](https://docs.aspose.com/slides/python-net/powerpoint-shapes/). 
* لمزيد من المعلومات حول القيم الفعالة، راجع [خصائص الشكل الفعالة](https://docs.aspose.com/slides/python-net/shape-effective-properties/#get-effective-font-height-value). 