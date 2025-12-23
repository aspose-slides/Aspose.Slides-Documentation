---
title: إنشاء عروض تقديمية في PHP
linktitle: إنشاء عرض تقديمي
type: docs
weight: 10
url: /ar/php-java/create-presentation/
keywords:
- إنشاء عرض تقديمي
- عرض تقديمي جديد
- إنشاء PPT
- PPT جديد
- إنشاء PPTX
- PPTX جديد
- إنشاء ODP
- ODP جديد
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إنشاء عروض تقديمية باستخدام Aspose.Slides لـ PHP عبر Java - إنتاج ملفات PPT و PPTX و ODP وحفظها برمجيًا للحصول على نتائج موثوقة."
---

## **إنشاء عرض تقديمي**

لإضافة خط بسيط إلى شريحة محددة في العرض، يرجى اتباع الخطوات التالية:

1. إنشاء نسخة من الفئة Presentation.
1. الحصول على مرجع الشريحة باستخدام الفهرس Index الخاص بها.
1. إضافة AutoShape من النوع Line باستخدام طريقة addAutoShape المتاحة عبر كائن Shapes.
1. كتابة العرض المعدل كملف PPTX.

في المثال أدناه، قمنا بإضافة خط إلى الشريحة الأولى من العرض.
```php
  # إنشاء كائن Presentation يمثل ملف عرض تقديمي
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape من النوع خط
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة المتكررة**

**ما الصيغ التي يمكنني حفظ عرض تقديمي جديد بها؟**

يمكنك الحفظ بصيغ [PPTX، PPT، و ODP](/slides/ar/php-java/save-presentation/)، وتصدير إلى [PDF](/slides/ar/php-java/convert-powerpoint-to-pdf/)، [XPS](/slides/ar/php-java/convert-powerpoint-to-xps/)، [HTML](/slides/ar/php-java/convert-powerpoint-to-html/)، [SVG](/slides/ar/php-java/convert-powerpoint-to-png/)، و[الصور](/slides/ar/php-java/convert-powerpoint-to-png/)، من بين صيغ أخرى.

**هل يمكنني البدء من قالب (POTX/POTM) وحفظه كـ PPTX عادي؟**

نعم. قم بتحميل القالب واحفظه بالصيغ المطلوبة؛ صيغ POTX/POTM/PPTM والصيغ المشابهة [مدعومة](/slides/ar/php-java/supported-file-formats/).

**كيف يمكنني التحكم في حجم الشريحة/نسبة العرض إلى الارتفاع عند إنشاء عرض تقديمي؟**

حدد [حجم الشريحة](/slides/ar/php-java/slide-size/) (بما في ذلك القوالب مثل 4:3 و16:9 أو الأبعاد المخصصة) واختر طريقة تعديل المحتوى.

**بأي وحدة تُقاس الأحجام والإحداثيات؟**

بالنقاط: البوصة الواحدة تساوي 72 وحدة.

**كيف أتعامل مع عروض تقديمية ضخمة (مع العديد من ملفات الوسائط) لتقليل استهلاك الذاكرة؟**

استخدم [استراتيجيات إدارة BLOB](/slides/ar/php-java/manage-blob/)، قلل التخزين في الذاكرة عبر الاستفادة من الملفات المؤقتة، وفضّل سير العمل القائم على الملفات على التدفقات التي تُحفظ في الذاكرة فقط.

**هل يمكنني إنشاء/حفظ عروض تقديمية بشكل متوازي؟**

لا يمكنك تشغيل نفس نسخة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) من [عدة خيوط](/slides/ar/php-java/multithreading/). شغّل نسخًا منفصلة ومعزولة لكل خيط أو عملية.

**كيف أزيل علامة التجربة المائية والقيود؟**

[تطبيق الترخيص](/slides/ar/php-java/licensing/) مرة واحدة لكل عملية. يجب أن يظل ملف XML للترخيص غير معدل، ويجب مزامنة إعداد الترخيص إذا شاركت عدة خيوط.

**هل يمكنني توقيع PPTX رقمياً بعد إنشائه؟**

نعم. [التوقيعات الرقمية](/slides/ar/php-java/digital-signature-in-powerpoint/) (الإضافة والتحقق) مدعومة للعروض التقديمية.

**هل تدعم العروض التقديمية الماكرو (VBA)؟**

نعم. يمكنك [إنشاء/تحرير مشاريع VBA](/slides/ar/php-java/presentation-via-vba/) وحفظ الملفات التي تدعم الماكرو مثل PPTM/PPSM.