---
title: إدارة كائنات الحبر في العروض التقديمية باستخدام JavaScript
linktitle: إدارة الحبر
type: docs
weight: 95
url: /ar/nodejs-java/manage-ink/
keywords:
- حبر
- كائن حبر
- تتبع الحبر
- إدارة الحبر
- رسم الحبر
- رسم
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إدارة كائنات الحبر في PowerPoint — إنشاء وتحرير وتنسيق الحبر الرقمي باستخدام Aspose.Slides لـ Node.js. احصل على أمثلة كود JavaScript للتتبع، ولون الفرشاة وحجمها."
---

PowerPoint يوفر وظيفة الحبر لتتيح لك رسم أشكال غير معيارية، والتي يمكن استخدامها لتسليط الضوء على عناصر أخرى، وإظهار الاتصالات والعمليات، وجذب الانتباه إلى عناصر محددة على الشريحة.

Aspose.Slides توفر جميع أنواع الحبر (مثل الفئة [Ink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ink/)) التي تحتاجها لإنشاء وإدارة كائنات الحبر.

## **الفرق بين الكائن العادي وكائنات الحبر**

الكائنات على شريحة PowerPoint عادةً ما يتم تمثيلها بواسطة كائنات الشكل. كائن الشكل، في أبسط صوره، هو حاوية تحدد مساحة الكائن نفسها (إطارها) إلى جانب خصائصه. تشمل الأخيرة حجم مساحة الحاوية، وشكل الحاوية، وخلفية الحاوية، إلخ. للمزيد من المعلومات، راجع [Shape Layout Format](https://docs.aspose.com/slides/nodejs-java/shape-manipulations/#access-layout-formats-for-shape).

ومع ذلك، عندما يتعامل PowerPoint مع كائن حبر، يتجاهل جميع خصائص إطار الكائن (الحاوية) باستثناء حجمه. يتم تحديد حجم مساحة الحاوية بواسطة القيم القياسية `width` و `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **آثار شكل الحبر**

التتبع هو عنصر أساسي أو معيار يُستخدم لتسجيل مسار القلم عندما يكتب المستخدم بحبر رقمي. التتبعات هي تسجيلات تصف تسلسلات من النقاط المتصلة.

أبسط أشكال الترميز تحدد إحداثيات X و Y لكل نقطة عينة. عندما يتم عرض جميع النقاط المتصلة، تُنتج صورة مشابهة لهذه:

![ink_powerpoint2](ink_powerpoint2.png)

## خصائص الفرشاة للرسم 

يمكنك استخدام فرشاة لرسم خطوط تربط نقاط عناصر التتبع. للفرشاة لونها وحجمها الخاص، ويتوافقان مع طرق `Brush.setColor` و `Brush.setSize`.

### **تعيين لون فرشاة الحبر**

This JavaScript code shows you how to set the color for a brush:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushColor = brush.getColor();
    brush.setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **تعيين حجم فرشاة الحبر** 

This JavaScript code shows you how to set the size for a brush:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushSize = brush.getSize();
    brush.setSize(java.newInstanceSync("java.awt.Dimension", 5, 10));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


عمومًا، لا يتطابق عرض الفرشاة وارتفاعها، لذا لا يعرض PowerPoint حجم الفرشاة (يظهر قسم البيانات باللون الرمادي). ولكن عندما يتطابق عرض الفرشاة وارتفاعها، يعرض PowerPoint حجمه بهذه الطريقة:

![ink_powerpoint3](ink_powerpoint3.png)

للتوضيح، دعنا نزيد ارتفاع كائن الحبر ونستعرض الأبعاد المهمة: 

![ink_powerpoint4](ink_powerpoint4.png)

الحاوية (الإطار) لا تأخذ حجم الفرش في الاعتبار--دائمًا ما تفترض أن سمك الخط صفر (انظر الصورة الأخيرة). 

لذلك، لتحديد المنطقة المرئية لكامل كائن الحبر، يجب أن نأخذ في الاعتبار حجم فرشاة كائنات التتبع. هنا، تم تحجيم الكائن المستهدف (كائن تتبع النص المكتوب بخط اليد) إلى حجم الحاوية (الإطار). عندما يتغير حجم الحاوية (الإطار)، يبقى حجم الفرشاة ثابتًا والعكس صحيح. 

![ink_powerpoint5](ink_powerpoint5.png)

يعرض PowerPoint نفس السلوك عند التعامل مع النصوص:

![ink_powerpoint6](ink_powerpoint6.png)

**قراءة إضافية**

* لقراءة المزيد عن الأشكال بشكل عام، راجع قسم [PowerPoint Shapes](https://docs.aspose.com/slides/nodejs-java/powerpoint-shapes/).
* لمزيد من المعلومات حول القيم الفعالة، راجع [Shape Effective Properties](https://docs.aspose.com/slides/nodejs-java/shape-effective-properties/#getting-effective-font-height-value).