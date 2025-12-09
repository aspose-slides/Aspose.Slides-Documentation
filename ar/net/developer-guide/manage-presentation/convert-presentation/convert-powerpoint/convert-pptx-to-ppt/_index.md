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
description: "تحويل PPTX إلى PPT بسهولة باستخدام Aspose.Slides لـ .NET — يضمن توافقًا سلسًا مع صيغ PowerPoint مع الحفاظ على تخطيط وعرض الشرائح وجودتها."
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض PowerPoint بتنسيق PPTX إلى تنسيق PPT باستخدام C#. يتم تغطية الموضوع التالي.

- تحويل PPTX إلى PPT في C#

## **C# Convert PPTX to PPT**

للحصول على مثال كود C# لتحويل PPTX إلى PPT، يرجى الاطلاع على القسم أدناه أي [تحويل PPTX إلى PPT](#convert-pptx-to-ppt). يقوم فقط بتحميل ملف PPTX وحفظه بتنسيق PPT. عن طريق تحديد تنسيقات حفظ مختلفة، يمكنك أيضًا حفظ ملف PPTX بصيغ أخرى مثل PDF و XPS و ODP و HTML وغيرها كما هو موضح في هذه المقالات.

- [C# تحويل PPTX إلى PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# تحويل PPTX إلى XPS](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# تحويل PPTX إلى HTML](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# تحويل PPTX إلى ODP](https://docs.aspose.com/slides/net/save-presentation/)
- [C# تحويل PPTX إلى Image](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **تحويل PPTX إلى PPT**
لتحويل PPTX إلى PPT ببساطة مرّر اسم الملف وتنسيق الحفظ إلى طريقة [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) في فئة [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation/). يوضح مثال الكود C# أدناه كيفية تحويل عرض تقديمي من PPTX إلى PPT باستخدام الإعدادات الافتراضية.
```c#
// إنشاء كائن Presentation يمثل ملف PPTX
Presentation pres = new Presentation("presentation.pptx");

// حفظ عرض PPTX بصيغة PPT
pres.Save("presentation.ppt", SaveFormat.Ppt);
```


## **الأسئلة الشائعة**

**هل جميع تأثيرات وميزات PPTX تُحافظ عليها عند الحفظ بتنسيق PPT القديم (97–2003)؟**

ليس دائمًا. تنسيق PPT يفتقر إلى بعض القدرات newer (مثل بعض التأثيرات والكائنات والسلوكيات)، لذا قد يتم تبسيط أو تحويل الميزات إلى Raster أثناء التحويل.

**هل يمكنني تحويل الشرائح المحددة فقط إلى PPT بدلاً من العرض الكامل؟**

الحفظ المباشر يستهدف العرض بالكامل. لتحويل شرائح معينة، أنشئ عرض تقديمي جديد يحتوي على تلك الشرائح فقط واحفظه كـ PPT؛ أو استخدم خدمة/API تدعم معلمات التحويل لكل شريحة.

**هل يتم دعم العروض المحمية بكلمة مرور؟**

نعم. يمكنك اكتشاف ما إذا كان الملف محميًا، فتحه باستخدام كلمة مرور، وكذلك [تكوين إعدادات الحماية/التشفير](/slides/ar/net/password-protected-presentation/) للـ PPT المحفوظ.