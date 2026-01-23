---
title: إضافة شرائح إلى العروض التقديمية في PHP
linktitle: إضافة شريحة
type: docs
weight: 10
url: /ar/php-java/add-slide-to-presentation/
keywords:
- إضافة شريحة
- إنشاء شريحة
- شريحة فارغة
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "أضف الشرائح بسهولة إلى عروض PowerPoint و OpenDocument باستخدام Aspose.Slides for PHP via Java — إدراج شرائح سلس وفعال في ثوانٍ."
---

## **إضافة شريحة إلى عرض تقديمي**
{{% alert color="primary" %}} 

قبل الحديث عن إضافة الشرائح إلى ملفات العرض التقديمي، دعونا نناقش بعض الحقائق حول الشرائح. كل ملف عرض PowerPoint يحتوي على شريحة **Master / Layout** وشريحة **Normal** أخرى. هذا يعني أن ملف العرض يحتوي على شريحة واحدة على الأقل أو أكثر. من المهم معرفة أن ملفات العرض بدون شرائح غير مدعومة من قبل Aspose.Slides for PHP via Java. كل شريحة لها معرّف فريد وجميع الشرائح العادية مرتبة بترتيب محدد بواسطة الفهرس الذي يبدأ من الصفر.

{{% /alert %}} 

يسمح Aspose.Slides for PHP via Java للمطورين بإضافة شرائح فارغة إلى عرضهم التقديمي. لإضافة شريحة فارغة في العرض، يرجى اتباع الخطوات التالية:

- إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) .
- احصل على كائن [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) باستخدام الطريقة [getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) (مجموعة كائنات Slide المحتوى) التي يوفرها كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) .
- أضف شريحة فارغة إلى العرض في نهاية مجموعة شرائح المحتوى عن طريق استدعاء الطريقة [**addEmptySlide**](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addEmptySlide) التي يوفرها كائن [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) .
- قم ببعض العمل مع الشريحة الفارغة التي أضيفت حديثًا.
- أخيرًا، احفظ ملف العرض باستخدام كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) .
```php
  # إنشاء كائن من فئة Presentation التي تمثل ملف العرض التقديمي
  $pres = new Presentation();
  try {
    # إنشاء كائن من فئة SlideCollection
    $slds = $pres->getSlides();
    for($i = 0; $i < java_values($pres->getLayoutSlides()->size()) ; $i++) {
      # إضافة شريحة فارغة إلى مجموعة الشرائح
      $slds->addEmptySlide($pres->getLayoutSlides()->get_Item($i));
    }
    # القيام ببعض الأعمال على الشريحة التي تم إضافتها حديثًا
    # حفظ ملف PPTX إلى القرص
    $pres->save("EmptySlide.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **الأسئلة المتكررة**

**هل يمكنني إدراج شريحة جديدة في موضع محدد، وليس فقط في النهاية؟**

نعم. تدعم المكتبة مجموعات الشرائح وعمليات [insert](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/insertclone/)، لذا يمكنك إضافة شريحة في الفهرس المطلوب بدلاً من النهاية فقط.

**هل يتم الحفاظ على السمات/الأنماط عند إضافة شريحة بناءً على تخطيط؟**

نعم. يرث التخطيط التنسيق من الماستر الخاص به، وت inherits الشريحة الجديدة من التخطيط المختار والماستر المرتبط به.

**أي شريحة موجودة في عرض تقديمي "فارغ" جديد قبل إضافة الشرائح؟**

يحتوي العرض التقديمي المنشأ حديثًا بالفعل على شريحة فارغة واحدة ذات فهرس صفر. من المهم مراعاة ذلك عند حساب مؤشرات الإدراج.

**كيف أختار التخطيط "المناسب" لشريحة جديدة إذا كان الماستر يحتوي على خيارات متعددة؟**

عامةً اختر الـ[LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) الذي يطابق البنية المطلوبة ([Title and Content, Two Content, إلخ](https://reference.aspose.com/slides/php-java/aspose.slides/slidelayouttype/)). إذا كان هذا التخطيط غير موجود، يمكنك [أضفه إلى الماستر](/slides/ar/php-java/slide-layout/) ثم استخدامه.