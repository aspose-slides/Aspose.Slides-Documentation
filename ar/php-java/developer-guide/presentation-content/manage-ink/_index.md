---
title: إدارة كائنات الحبر في العروض التقديمية باستخدام PHP
linktitle: إدارة الحبر
type: docs
weight: 95
url: /ar/php-java/manage-ink/
keywords:
- حبر
- كائن الحبر
- آثار الحبر
- إدارة الحبر
- رسم الحبر
- الرسم
- PowerPoint
- العرض التقديمي
- PHP
- Aspose.Slides
description: "إدارة كائنات الحبر في PowerPoint — إنشاء، تعديل وتنسيق الحبر الرقمي باستخدام Aspose.Slides للـ PHP عبر Java. احصل على أمثلة شفرة للآثار ولون وحجم الفرشاة."
---

يقدّم PowerPoint وظيفة الحبر التي تسمح لك برسم أشكال غير قياسية، والتي يمكن استخدامها لتسليط الضوء على كائنات أخرى، وإظهار الاتصالات والعمليات، وجذب الانتباه إلى عناصر محددة في الشريحة.

توفر Aspose.Slides جميع أنواع الحبر (مثل الفئة [Ink](https://reference.aspose.com/slides/php-java/aspose.slides/ink/)) التي تحتاجها لإنشاء وإدارة كائنات الحبر.

## **الفرق بين الكائنات العادية وكائنات الحبر**

عادةً ما يتم تمثيل الكائنات على شريحة PowerPoint بواسطة كائنات الشكل. كائن الشكل، في أبسط صوره، هو حاوية تُحدّد مساحة الكائن نفسه (إطاره) إلى جانب خصائصه. تشمل الخصائص حجم مساحة الحاوية، شكل الحاوية، خلفية الحاوية، إلخ. للمزيد من المعلومات، راجع [تنسيق تخطيط الشكل](https://docs.aspose.com/slides/php-java/shape-manipulations/#access-layout-formats-for-shape).

ومع ذلك، عندما يتعامل PowerPoint مع كائن حبر، فإنّه يتجاهل جميع خصائص إطار الكائن (الحاوية) باستثناء حجمه. يُحدّد حجم مساحة الحاوية بالقيم القياسية `width` و `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **آثار شكل الحبر**

الأثر هو عنصر أساسي أو معيار يُستخدم لتسجيل مسار القلم بينما يكتب المستخدم بالحبر الرقمي. الأثار هي تسجيلات تصف تسلسلات من النقاط المتصلة.

أبسط أشكال الترميز تحدد إحداثيات X و Y لكل نقطة عينة. عند عرض جميع النقاط المتصلة، يتم إنتاج صورة كهذه:

![ink_powerpoint2](ink_powerpoint2.png)

## **خصائص الفرشاة للرسم**

يمكنك استخدام فرشاة لرسم خطوط تربط نقاط عناصر الأثر. للفرشاة لونها وحجمها الخاصين، ويتوافق ذلك مع خصائص `Brush.Color` و `Brush.Size`.

### **تعيين لون فرشاة الحبر**

هذا الكود PHP يوضح لك كيفية تعيين لون للفرشاة:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushColor = $brush->getColor();
    $brush->setColor(java("java.awt.Color")->RED);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **تعيين حجم فرشاة الحبر**

هذا الكود PHP يوضح لك كيفية تعيين حجم للفرشاة:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushSize = $brush->getSize();
    $brush->setSize(new Java("java.awt.Dimension", 5, 10));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


عمومًا، لا يتطابق عرض وارتفاع الفرشاة، لذلك لا يعرض PowerPoint حجم الفرشاة (يكون قسم البيانات مظللًا). لكن عندما يتطابق عرض الفرشاة مع ارتفاعها، يعرض PowerPoint حجمه بهذه الطريقة:

![ink_powerpoint3](ink_powerpoint3.png)

للتوضيح، دعنا نزيد ارتفاع كائن الحبر ونستعرض الأبعاد المهمة:

![ink_powerpoint4](ink_powerpoint4.png)

لا تأخذ الحاوية (الإطار) حجم الفرشات في الاعتبار— فهي تفترض دائمًا أن سمك الخط صفر (انظر الصورة الأخيرة).

لذا، لتحديد المنطقة المرئية لكامل كائن الحبر، يجب علينا أخذ حجم فرشاة عناصر الأثر في الاعتبار. هنا، تم تحجيم الكائن الهدف (كائن أثر النص المكتوب يدويًا) ليتناسب مع حجم الحاوية (الإطار). عندما يتغير حجم الحاوية (الإطار)، يبقى حجم الفرشاة ثابتًا والعكس صحيح.

![ink_powerpoint5](ink_powerpoint5.png)

يظهر PowerPoint نفس السلوك عند التعامل مع النصوص:

![ink_powerpoint6](ink_powerpoint6.png)

**قراءة إضافية**

* لقراءة المزيد حول الأشكال بشكل عام، راجع قسم [أشكال PowerPoint](https://docs.aspose.com/slides/php-java/powerpoint-shapes/).
* لمزيد من المعلومات حول القيم الفعّالة، راجع [خصائص الشكل الفعّالة](https://docs.aspose.com/slides/php-java/shape-effective-properties/#getting-effective-font-height-value).