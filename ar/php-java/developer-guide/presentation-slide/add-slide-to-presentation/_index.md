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
description: "أضف الشرائح بسهولة إلى عروض PowerPoint و OpenDocument الخاصة بك باستخدام Aspose.Slides for PHP عبر Java — إدراج شرائح سلس وفعال في ثوانٍ."
---

## **إضافة شريحة إلى عرض تقديمي**
{{% alert color="primary" %}} 

قبل التحدث عن إضافة الشرائح إلى ملفات العرض التقديمي، دعنا نناقش بعض الحقائق حول الشرائح. يحتوي كل ملف عرض تقديمي PowerPoint على شريحة **Master / Layout** وشريحة **Normal** أخرى. يعني ذلك أن ملف العرض يحتوي على شريحة واحدة على الأقل أو أكثر. من المهم معرفة أن ملفات العرض التي لا تحتوي على شرائح غير مدعومة من قبل Aspose.Slides for PHP via Java. كل شريحة لها معرف فريد وتُرتب جميع الشرائح العادية بترتيب يحدده الفهرس الصفري القائم على الصفر.

{{% /alert %}} 

Aspose.Slides for PHP via Java يسمح للمطورين بإضافة شرائح فارغة إلى عرضهم. لإضافة شريحة فارغة في العرض، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- إنشاء فئة [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection) بتعيين مرجع إلى الخاصية [Slides](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) (مجموعة كائنات Slide المحتوى) التي exposeها كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- إضافة شريحة فارغة إلى العرض في نهاية مجموعة شرائح المحتوى عن طريق استدعاء طريقة [**addEmptySlide**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) التي exposeها كائن [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection).
- القيام ببعض الأعمال مع الشريحة الفارغة التي تم إضافتها حديثاً.
- أخيراً، كتابة ملف العرض باستخدام كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
```php
  # إنشاء كائن من فئة Presentation التي تمثل ملف العرض
  $pres = new Presentation();
  try {
    # إنشاء كائن من فئة SlideCollection
    $slds = $pres->getSlides();
    for($i = 0; $i < java_values($pres->getLayoutSlides()->size()) ; $i++) {
      # إضافة شريحة فارغة إلى مجموعة الشرائح
      $slds->addEmptySlide($pres->getLayoutSlides()->get_Item($i));
    }
    # إجراء بعض الأعمال على الشريحة المضافة حديثاً
    # حفظ ملف PPTX إلى القرص
    $pres->save("EmptySlide.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **الأسئلة الشائعة**

**هل يمكنني إدراج شريحة جديدة في موضع محدد، وليس فقط في النهاية؟**

نعم. تدعم المكتبة مجموعات الشرائح وعمليات [insert](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/insertclone/) ، لذا يمكنك إضافة شريحة في الفهرس المطلوب بدلاً من النهاية فقط.

**هل يتم الحفاظ على السمات/الأنماط عند إضافة شريحة بناءً على تخطيط؟**

نعم. يرث التخطيط التنسيق من الـ master، وتورّث الشريحة الجديدة من التخطيط المحدد والـ master المرتبط به.

**أي شريحة تكون موجودة في عرض تقديمي "فارغ" جديد قبل إضافة الشرائح؟**

العرض التقديمي الذي تم إنشاؤه حديثاً يحتوي بالفعل على شريحة فارغة واحدة ذات فهرس صفر. من المهم مراعاة ذلك عند حساب مؤشرات الإدراج.

**كيف أختار التخطيط "الصحيح" لشريحة جديدة إذا كان الـ master يحتوي على العديد من الخيارات؟**

بشكل عام اختر [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) الذي يتطابق مع الهيكل المطلوب ([Title and Content, Two Content, إلخ](https://reference.aspose.com/slides/php-java/aspose.slides/slidelayouttype/)). إذا كان هذا التخطيط غير موجود، يمكنك [add it to the master](/slides/ar/php-java/slide-layout/) ثم استخدامه.