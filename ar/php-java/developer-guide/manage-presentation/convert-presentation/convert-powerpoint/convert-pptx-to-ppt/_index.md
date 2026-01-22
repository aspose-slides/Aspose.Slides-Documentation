---
title: تحويل PPTX إلى PPT باستخدام PHP
linktitle: PPTX إلى PPT
type: docs
weight: 21
url: /ar/php-java/convert-pptx-to-ppt/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPTX
- PPTX إلى PPT
- حفظ PPTX كـ PPT
- تصدير PPTX إلى PPT
- PowerPoint
- العرض التقديمي
- PHP
- Aspose.Slides
description: "قم بتحويل PPTX إلى PPT بسهولة باستخدام Aspose.Slides — احرص على توافق سلس مع صيغ PowerPoint مع الحفاظ على تخطيط وعرض العرض التقديمي وجودته."
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض PowerPoint بصيغة PPTX إلى صيغة PPT باستخدام PHP. يتم تغطية الموضوع التالي.

- تحويل PPTX إلى PPT

## **تحويل PPTX إلى PPT في PHP**

للحصول على مثال كود Java لتحويل PPTX إلى PPT، يرجى مراجعة القسم أدناه أي [تحويل PPTX إلى PPT](#convert-pptx-to-ppt). يقوم بتحميل ملف PPTX وحفظه بصيغة PPT. من خلال تحديد صيغ حفظ مختلفة، يمكنك أيضًا حفظ ملف PPTX إلى صيغ أخرى كثيرة مثل PDF وXPS وODP وHTML وغيرها كما هو موضح في هذه المقالات. 

- [تحويل PPTX إلى PDF في PHP](/slides/ar/php-java/convert-powerpoint-to-pdf/)
- [تحويل PPTX إلى XPS في PHP](/slides/ar/php-java/convert-powerpoint-to-xps/)
- [تحويل PPTX إلى HTML في PHP](/slides/ar/php-java/convert-powerpoint-to-html/)
- [تحويل PPTX إلى ODP في PHP](/slides/ar/php-java/save-presentation/)
- [تحويل PPTX إلى PNG في PHP](/slides/ar/php-java/convert-powerpoint-to-png/)

## **تحويل PPTX إلى PPT**
لتحويل PPTX إلى PPT ببساطة مرّر اسم الملف وصيغة الحفظ إلى طريقة **Save** في فئة [**Presentation**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) . عينة كود PHP أدناه تحول عرض تقديمي من PPTX إلى PPT باستخدام الخيارات الافتراضية.
```php
  # إنشاء كائن Presentation يمثل ملف PPTX
  $presentation = new Presentation("template.pptx");
  # حفظ العرض التقديمي كـ PPT
  $presentation->save("output.ppt", SaveFormat::Ppt);
```


## **الأسئلة الشائعة**

**هل تبقى جميع تأثيرات وميزات PPTX عند الحفظ إلى صيغة PPT (97–2003) القديمة؟**

ليس دائمًا. صيغة PPT تفتقر إلى بعض القدرات الأحدث (مثل بعض التأثيرات، الكائنات، والسلوكيات)، لذا قد يتم تبسيط أو تحويل الميزات إلى raster أثناء التحويل.

**هل يمكنني تحويل شرائح محددة فقط إلى PPT بدلًا من العرض بالكامل؟**

الحفظ المباشر يستهدف العرض بالكامل. لتحويل شرائح معينة، أنشئ عرضًا جديدًا يحتوي فقط على تلك الشرائح واحفظه بصيغة PPT؛ أو استخدم خدمة/API تدعم معلمات تحويل حسب الشريحة.

**هل يتم دعم العروض المحمية بكلمة مرور؟**

نعم. يمكنك اكتشاف ما إذا كان الملف محميًا، فتحه باستخدام كلمة المرور، وأيضًا [تكوين إعدادات الحماية/التشفير](/slides/ar/php-java/password-protected-presentation/) للملف PPT المحفوظ.