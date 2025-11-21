---
title: تحويل PPTX إلى PPT في .NET
linktitle: PPTX إلى PPT
type: docs
weight: 21
url: /ar/net/convert-pptx-to-ppt/
keywords:
  - تحويل PowerPoint
  - تحويل عرض تقديمي
  - تحويل شريحة
  - تحويل PPTX
  - PPTX إلى PPT
  - حفظ PPTX كـ PPT
  - تصدير PPTX إلى PPT
  - PowerPoint
  - عرض تقديمي
  - .NET
  - C#
  - Aspose.Slides
description: "قم بتحويل PPTX إلى PPT بسهولة باستخدام Aspose.Slides لـ .NET—تأكد من التوافق السلس مع صيغ PowerPoint مع الحفاظ على تخطيط وعرض التقديم وجودته."
---

## **نظرة عامة**

توضح هذه المقالة كيفية تحويل عرض PowerPoint بتنسيق PPTX إلى تنسيق PPT باستخدام C#. يتم تغطية الموضوع التالي.

- تحويل PPTX إلى PPT باستخدام C#

## **C# تحويل PPTX إلى PPT**

للحصول على عينة كود C# لتحويل PPTX إلى PPT، يرجى مراجعة القسم أدناه أي [تحويل PPTX إلى PPT](#convert-pptx-to-ppt). يقوم الكود بتحميل ملف PPTX وحفظه بتنسيق PPT. بتحديد تنسيقات حفظ مختلفة، يمكنك أيضًا حفظ ملف PPTX إلى العديد من التنسيقات الأخرى مثل PDF، XPS، ODP، HTML وغيرها كما هو موضح في هذه المقالات.

- [C# تحويل PPTX إلى PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# تحويل PPTX إلى XPS](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# تحويل PPTX إلى HTML](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# تحويل PPTX إلى ODP](https://docs.aspose.com/slides/net/save-presentation/)
- [C# تحويل PPTX إلى Image](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **تحويل PPTX إلى PPT**
لتحويل PPTX إلى PPT ببساطة مرّر اسم الملف وتنسيق الحفظ إلى طريقة **Save** في فئة **Presentation**. عينة الكود C# أدناه تحول عرضًا من PPTX إلى PPT باستخدام الخيارات الافتراضية.
```c#
// إنشاء كائن Presentation يمثل ملف PPTX
Presentation pres = new Presentation("presentation.pptx");

// حفظ عرض PPTX بتنسيق PPT
pres.Save("presentation.ppt", SaveFormat.Ppt);
```


## **الأسئلة الشائعة**

**هل تبقى جميع تأثيرات وميزات PPTX عند الحفظ بصيغة PPT (97–2003) القديمة؟**

ليس دائمًا. صيغة PPT تفتقر إلى بعض القدرات الأحدث (مثل بعض التأثيرات، الكائنات، والسلوكيات)، لذا قد يتم تبسيط أو تحويل الميزات إلى نقطية أثناء التحويل.

**هل يمكنني تحويل الشرائح المحددة فقط إلى PPT بدلاً من العرض الكامل؟**

الحفظ المباشر يستهدف العرض كاملًا. لتحويل شرائح معينة، أنشئ عرضًا جديدًا يحتوي فقط على تلك الشرائح ثم احفظه كـ PPT؛ أو استخدم خدمة/واجهة برمجة تطبيقات تدعم معلمات التحويل لكل شريحة.

**هل يتم دعم العروض المحمية بكلمة مرور؟**

نعم. يمكنك اكتشاف ما إذا كان الملف محميًا، فتحه باستخدام كلمة المرور، وكذلك [configure protection/encryption settings](/slides/ar/net/password-protected-presentation/) للعرض المحفوظ بصيغة PPT.