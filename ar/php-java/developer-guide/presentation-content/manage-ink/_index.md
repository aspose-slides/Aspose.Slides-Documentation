---
title: إدارة الحبر
type: docs
weight: 95
url: /php-java/manage-ink/
keywords: "الحبر في PowerPoint، أدوات الحبر، حبر Java، رسم في PowerPoint، عرض PowerPoint، Java، Aspose.Slides لـ PHP عبر Java"
description: "استخدام أدوات الحبر لرسم الأشكال في PowerPoint Java"
---

يقدم PowerPoint وظيفة الحبر للسماح لك برسم أشكال غير قياسية، والتي يمكن استخدامها لتسليط الضوء على كائنات أخرى، وإظهار الاتصالات والعمليات، وجذب الانتباه إلى عناصر محددة على الشريحة.

تقدم Aspose.Slides جميع أنواع الحبر (مثل [Ink](https://reference.aspose.com/slides/php-java/aspose.slides/ink/) class) التي تحتاجها لإنشاء وإدارة كائنات الحبر.

## **الاختلافات بين الكائن العادي وكائنات الحبر**

تمثل الكائنات الموجودة على شريحة PowerPoint عادةً بأشكال كائنات. كائن الشكل، في أبسط صوره، هو حاوية تحدد مساحة الكائن نفسه (إطاره) إلى جانب خصائصه. تتضمن هذه الأخيرة حجم منطقة الحاوية، وشكل الحاوية، وخلفية الحاوية، وما إلى ذلك. لمزيد من المعلومات، راجع [شكل تنسيق التخطيط](https://docs.aspose.com/slides/php-java/shape-manipulations/#access-layout-formats-for-shape).

ومع ذلك، عندما يتعامل PowerPoint مع كائن حبر، فإنه يتجاهل جميع خصائص إطار الكائن (الحاوية) باستثناء حجمه. يتم تحديد حجم منطقة الحاوية بواسطة قيم `width` و`height` القياسية:

![ink_powerpoint1](ink_powerpoint1.png)

## **أثر أشكال الحبر**

الأثر هو عنصر أساسي أو قياسي يستخدم لتسجيل مسار القلم أثناء كتابة المستخدم للحبر الرقمي. الآثار هي تسجيلات تصف تسلسلات من النقاط المتصلة.

أبسط شكل للتشفير يحدد إحداثيات X وY لكل نقطة عينة. عند عرض جميع النقاط المتصلة، فإنها تنتج صورة مثل هذه:

![ink_powerpoint2](ink_powerpoint2.png)

## خصائص الفرشاة للرسم 

يمكنك استخدام فرشاة لرسم خطوط تربط نقاط عناصر الأثر. تحتوي الفرشاة على لون وحجم خاصين بها، يتوافقان مع خصائص `Brush.Color` و`Brush.Size`.

### **تعيين لون فرشاة الحبر**

يوضح هذا الكود بلغة PHP كيف يتم تعيين اللون لفرشاة:

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

يوضح هذا الكود بلغة PHP كيف يتم تعيين الحجم لفرشاة:

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

بشكل عام، لا تتطابق عرض وارتفاع الفرشاة، لذلك لا يعرض PowerPoint حجم الفرشاة (يكون قسم البيانات رمادي اللون). ولكن عندما تتطابق عرض وارتفاع الفرشاة، يعرض PowerPoint حجمها بهذه الطريقة:

![ink_powerpoint3](ink_powerpoint3.png)

للتوضيح، دعونا نزيد من ارتفاع كائن الحبر ونراجع الأبعاد المهمة:

![ink_powerpoint4](ink_powerpoint4.png)

لا تأخذ الحاوية (الإطار) في الاعتبار حجم الفرشاة--بل تفترض دائمًا أن سمك الخط هو صفر (انظر الصورة الأخيرة).

لذا، لتحديد المنطقة المرئية لكائن الحبر بالكامل، يجب علينا أخذ حجم فرشاة كائنات الأثر في الاعتبار. هنا، تم تغيير حجم الكائن المستهدف (كائن أثر النص المكتوب بخط اليد) ليتناسب مع حجم الحاوية (الإطار). عندما يتغير حجم الحاوية (الإطار)، يبقى حجم الفرشاة ثابتًا والعكس صحيح.

![ink_powerpoint5](ink_powerpoint5.png)

يظهر PowerPoint نفس السلوك عند التعامل مع النصوص:

![ink_powerpoint6](ink_powerpoint6.png)

**قراءة إضافية**

* لقراءة المزيد حول الأشكال بشكل عام، انظر قسم [أشكال PowerPoint](https://docs.aspose.com/slides/php-java/powerpoint-shapes/).
* لمزيد من المعلومات حول القيم الفعالة، راجع [خصائص الشكل الفعالة](https://docs.aspose.com/slides/php-java/shape-effective-properties/#getting-effective-font-height-value).