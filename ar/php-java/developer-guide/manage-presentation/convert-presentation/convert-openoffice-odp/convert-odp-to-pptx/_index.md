---
title: تحويل ODP إلى PPTX في PHP
linktitle: ODP إلى PPTX
type: docs
weight: 10
url: /ar/php-java/convert-odp-to-pptx/
keywords:
- تحويل OpenDocument
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل ODP
- OpenDocument إلى PPTX
- ODP إلى PPTX
- حفظ ODP كـ PPTX
- تصدير ODP إلى PPTX
- PowerPoint
- OpenDocument
- العرض التقديمي
- PHP
- Aspose.Slides
description: "تحويل ODP إلى PPTX باستخدام Aspose.Slides لـ PHP عبر Java. أمثلة شفرة نظيفة، نصائح للدفعات، ونتائج عالية الجودة - بدون الحاجة إلى PowerPoint."
---

## **تحويل ODP إلى عرض PPTX/PPT**
تقدم Aspose.Slides for PHP via Java الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) التي تمثل ملف عرض تقديمي. يمكن الآن لفئة Presentation أيضًا الوصول إلى ODP عبر منشئ [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#Presentation-java.lang.String-) عند إنشاء الكائن. يوضح المثال التالي كيفية تحويل عرض ODP إلى عرض PPTX.
```php
// فتح ملف ODP
  $pres = new Presentation("AccessOpenDoc.odp");
  try {
  } finally {
  }
  # حفظ عرض ODP بصيغة PPTX
  $pres->save("AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```


## **مثال حي**
يمكنك زيارة [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) تطبيق الويب، الذي تم بناؤه باستخدام **Aspose.Slides API**. يوضح التطبيق كيفية تنفيذ تحويل ODP إلى PPTX باستخدام Aspose.Slides API.

## **الأسئلة الشائعة**

**هل أحتاج إلى تثبيت Microsoft PowerPoint أو LibreOffice لتحويل ODP إلى PPTX؟**

لا. يعمل Aspose.Slides بشكل مستقل ولا يتطلب تطبيقات طرف ثالث لقراءة أو كتابة ODP/PPTX.

**هل يتم الحفاظ على الشرائح الرئيسية، والتخطيطات، والسمات أثناء التحويل؟**

نعم. تستخدم المكتبة نموذج كائن عرض تقديمي كامل وتحتفظ بالبنية، بما في ذلك الشرائح الرئيسية والتخطيطات، بحيث يبقى التصميم صحيحًا بعد التحويل.

**هل يمكنني تحويل ملفات ODP محمية بكلمة مرور؟**

نعم. يدعم Aspose.Slides اكتشاف الحماية، وفتح والعمل مع [العروض التقديمية المحمية](/slides/ar/php-java/password-protected-presentation/) (بما في ذلك ODP) عند توفير كلمة المرور، بالإضافة إلى تكوين التشفير والوصول إلى خصائص المستند.

**هل Aspose.Slides مناسب لخدمات التحويل السحابية أو القائمة على REST؟**

نعم. يمكنك استخدام المكتبة المحلية في الخادم الخاص بك أو [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST API)؛ كلا الخيارين يدعمان تحويل ODP → PPTX.