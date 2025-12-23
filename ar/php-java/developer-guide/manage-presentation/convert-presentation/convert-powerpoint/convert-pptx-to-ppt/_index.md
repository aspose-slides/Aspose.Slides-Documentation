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

تشرح هذه المقالة كيفية تحويل عرض PowerPoint بتنسيق PPTX إلى تنسيق PPT باستخدام PHP. الموضوع التالي مغطى.

- تحويل PPTX إلى PPT

## **تحويل PPTX إلى PPT في PHP**

للحصول على مثال شفرة Java لتحويل PPTX إلى PPT، يرجى الاطلاع على القسم أدناه أي [تحويل PPTX إلى PPT](#convert-pptx-to-ppt). يقوم بتحميل ملف PPTX وحفظه بتنسيق PPT. عن طريق تحديد صيغ حفظ مختلفة، يمكنك أيضًا حفظ ملف PPTX إلى العديد من الصيغ الأخرى مثل PDF و XPS و ODP و HTML وغيرها كما نوقش في هذه المقالات.

- [تحويل PPTX إلى PDF باستخدام Java](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-pdf/)
- [تحويل PPTX إلى XPS باستخدام Java](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-xps/)
- [تحويل PPTX إلى HTML باستخدام Java](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-html/)
- [تحويل PPTX إلى ODP باستخدام Java](https://docs.aspose.com/slides/php-java/save-presentation/)
- [تحويل PPTX إلى صورة باستخدام Java](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-png/)

## **تحويل PPTX إلى PPT**
لتحويل PPTX إلى PPT ببساطة مرّر اسم الملف وصيغة الحفظ إلى طريقة **Save** في فئة [**Presentation**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation). عينة الشفرة PHP أدناه تحول عرض تقديمي من PPTX إلى PPT باستخدام الخيارات الافتراضية.
```php
  # إنشاء كائن Presentation يمثل ملف PPTX
  $presentation = new Presentation("template.pptx");
  # حفظ العرض التقديمي كـ PPT
  $presentation->save("output.ppt", SaveFormat::Ppt);
```


## **FAQ**

**هل تبقى جميع التأثيرات والميزات في PPTX عند الحفظ إلى تنسيق PPT التقليدي (97–2003)؟**

ليس دائمًا. يفتقر تنسيق PPT إلى بعض القدرات الحديثة (مثل بعض التأثيرات، الكائنات، والسلوكيات)، لذا قد يتم تبسيط أو تحويل الميزات إلى رسومات نقطية أثناء التحويل.

**هل يمكنني تحويل الشرائح المحددة فقط إلى PPT بدلاً من العرض الكامل؟**

الحفظ المباشر يستهدف العرض كاملًا. لتحويل شرائح معينة، أنشئ عرض تقديمي جديد يحتوي فقط على تلك الشرائح واحفظه كـ PPT؛ بدلاً من ذلك، استخدم خدمة/API تدعم معاملات تحويل per‑slide.

**هل يتم دعم العروض المحمية بكلمة مرور؟**

نعم. يمكنك اكتشاف ما إذا كان الملف محميًا، فتحه باستخدام كلمة مرور، وأيضًا [تكوين إعدادات الحماية/التشفير](/slides/ar/php-java/password-protected-presentation/) للـ PPT المحفوظ.