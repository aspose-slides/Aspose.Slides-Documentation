---
title: تحديد خطوط العرض التقديمي الافتراضية في PHP
linktitle: الخط الافتراضي
type: docs
weight: 30
url: /ar/php-java/default-font/
keywords:
- الخط الافتراضي
- خط عادي
- خط طبيعي
- خط آسيوي
- تصدير PDF
- تصدير XPS
- تصدير الصور
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعيين الخطوط الافتراضية في Aspose.Slides لـ PHP عبر Java لضمان تحويل صحيح لعروض PowerPoint (PPT، PPTX) وOpenDocument (ODP) إلى PDF وXPS والصور."
---

## **استخدام الخطوط الافتراضية لتصيير عرض تقديمي**
Aspose.Slides يتيح لك تعيين الخط الافتراضي لتصيير العرض التقديمي إلى PDF أو XPS أو صور مصغرة. يوضح هذا المقال كيفية تعريف DefaultRegularFont وDefaultAsianFont لاستخدامهما كخطوط افتراضية. يرجى اتباع الخطوات أدناه لتحميل الخطوط من دلائل خارجية باستخدام Aspose.Slides for PHP عبر Java API:

1. إنشاء نسخة من [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions).
2. [تعيين DefaultRegularFont](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) إلى الخط الذي تريده. في المثال التالي، استخدمت Wingdings.
3. [تعيين DefaultAsianFont](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) إلى الخط الذي تريده. استخدمت Wingdings في العينة التالية.
4. تحميل العرض التقديمي باستخدام Presentation وتعيين خيارات التحميل.
5. الآن، قم بإنشاء صورة مصغرة للشريحة، PDF و XPS للتحقق من النتائج.

```php
  # استخدم خيارات التحميل لتعريف الخطوط الافتراضية العادية والآسيوية
  $loadOptions = new LoadOptions(LoadFormat::Auto);
  $loadOptions->setDefaultRegularFont("Wingdings");
  $loadOptions->setDefaultAsianFont("Wingdings");
  # تحميل العرض التقديمي
  $pres = new Presentation("DefaultFonts.pptx", $loadOptions);
  try {
    # إنشاء صورة مصغرة للشريحة
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1, 1);
    try {
      # حفظ الصورة على القرص.
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # إنشاء PDF
    $pres->save("output_out.pdf", SaveFormat::Pdf);
    # إنشاء XPS
    $pres->save("output_out.xps", SaveFormat::Xps);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة الشائعة**

**ما الذي يؤثر عليه DefaultRegularFont وDefaultAsianFont بالضبط—هل فقط على التصدير، أم أيضًا على الصور المصغرة، PDF، XPS، HTML، وSVG؟**

إنهما يشاركان في خط أنابيب التصدير لجميع المخرجات المدعومة. وهذا يشمل الصور المصغرة للشرائح، [PDF](/slides/ar/php-java/convert-powerpoint-to-pdf/)، [XPS](/slides/ar/php-java/convert-powerpoint-to-xps/)، [صور نقطية](/slides/ar/php-java/convert-powerpoint-to-png/)، [HTML](/slides/ar/php-java/convert-powerpoint-to-html/)، و[SVG](/slides/ar/php-java/render-a-slide-as-an-svg-image/)، لأن Aspose.Slides يستخدم نفس منطق تخطيط وحل الحروف عبر هذه الأهداف.

**هل يتم تطبيق الخطوط الافتراضية عند قراءة وحفظ ملف PPTX فقط دون أي تصيير؟**

لا. الخطوط الافتراضية تكون ذات أهمية عندما يجب قياس النص ورسمه. عملية فتح‑حفظ مباشرة للعرض التقديمي لا تغير من تشغيلات الخط المخزنة أو بنية الملف. تظهر الخطوط الافتراضية فقط أثناء العمليات التي تقوم بتصيير النص أو إعادة تنسيقه.

**إذا قمت بإضافة مجلدات خطوط خاصة أو زودت الخطوط من الذاكرة، هل سيتم أخذها في الاعتبار عند اختيار الخطوط الافتراضية؟**

نعم. [مصادر الخطوط المخصصة](/slides/ar/php-java/custom-font/) توسّع كتالوج العائلات والحروف المتاحة التي يمكن للمحرك استخدامها. الخطوط الافتراضية وأي [قواعد احتياطية](/slides/ar/php-java/fallback-font/) ستُحلّ أولاً ضد هذه المصادر، مما يوفر تغطية أكثر موثوقية على الخوادم وفي الحاويات.

**هل تؤثر الخطوط الافتراضية على مقاييس النص (Kerning، التقدّم) وبالتالي على فواصل السطر والالتفاف؟**

نعم. تغيير الخط يغيّر مقاييس الحروف ويمكن أن يغيّر فواصل السطر، الالتفاف، وتجزئة الصفحات أثناء التصيير. لضمان استقرار التخطيط، يُنصح بـ[تضمين الخطوط الأصلية](/slides/ar/php-java/embedded-font/) أو اختيار عائلات افتراضية واحتياطية متناسقة من حيث المقاييس.

**هل هناك فائدة من تعيين خطوط افتراضية إذا كانت جميع الخطوط المستخدمة في العرض التقديمي مضمَّنة؟**

غالبًا لا يكون ذلك ضروريًا، لأن [الخطوط المضمَّنة](/slides/ar/php-java/embedded-font/) تضمن مظهرًا ثابتًا بالفعل. إلا أن الخطوط الافتراضية لا تزال مفيدة كشبكة أمان للأحرف غير المغطاة بالمجموعة المضمَّنة أو عندما يمزج الملف بين نص مضمَّن وغير مضمَّن.