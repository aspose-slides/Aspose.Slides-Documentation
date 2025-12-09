---
title: تحويل PPTX إلى PPT في .NET
linktitle: PPTX إلى PPT
type: docs
weight: 21
url: /ar/net/convert-pptx-to-ppt/
keywords:
- تحويل PowerPoint
- تحويل العرض
- تحويل الشريحة
- تحويل PPTX
- PPTX إلى PPT
- حفظ PPTX كـ PPT
- تصدير PPTX إلى PPT
- PowerPoint
- عرض
- .NET
- C#
- Aspose.Slides
description: "حوّل PPTX إلى PPT بسهولة باستخدام Aspose.Slides لـ .NET — احرص على توافق سلس مع صيغ PowerPoint مع الحفاظ على تخطيط وعرض تقديمك وجودته."
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض PowerPoint بتنسيق PPTX إلى تنسيق PPT باستخدام C#. الموضوع التالي مغطى.

- تحويل PPTX إلى PPT باستخدام C#

## **C# تحويل PPTX إلى PPT**

للحصول على كود عينة C# لتحويل PPTX إلى PPT، يرجى الاطلاع على القسم أدناه أي[Convert PPTX to PPT](#convert-pptx-to-ppt). يقوم بتحميل ملف PPTX وحفظه بتنسيق PPT. عبر تحديد تنسيقات حفظ مختلفة، يمكنك أيضًا حفظ ملف PPTX إلى تنسيقات أخرى كثيرة مثل PDF و XPS و ODP و HTML وغيرها كما نوقش في هذه المقالات. 

- [C# تحويل PPTX إلى PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# تحويل PPTX إلى XPS](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# تحويل PPTX إلى HTML](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# تحويل PPTX إلى ODP](https://docs.aspose.com/slides/net/save-presentation/)
- [C# تحويل PPTX إلى Image](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **تحويل PPTX إلى PPT**
لتحويل PPTX إلى PPT، قم بتمرير اسم الملف وتنسيق الحفظ إلى طريقة[**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) في فئة[**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation/). عينة كود C# أدناه تحول عرضًا من PPTX إلى PPT باستخدام الخيارات الافتراضية.
```c#
// إنشاء كائن Presentation يمثل ملف PPTX
Presentation pres = new Presentation("presentation.pptx");

// حفظ عرض PPTX إلى تنسيق PPT
pres.Save("presentation.ppt", SaveFormat.Ppt);
```


## **FAQ**

**هل تبقى جميع تأثيرات وميزات PPTX عند الحفظ بتنسيق PPT القديم (97–2003)؟**

ليس دائمًا. يفتقر تنسيق PPT إلى بعض الإمكانات الحديثة (مثل بعض التأثيرات والكائنات والسلوكيات)، لذا قد يتم تبسيط أو تحويل الميزات إلى صور نقطية أثناء التحويل.

**هل يمكنني تحويل الشرائح المحددة فقط إلى PPT بدلاً من العرض الكامل؟**

الحفظ المباشر يستهدف العرض كاملًا. لتحويل شرائح معينة، أنشئ عرضًا جديدًا يحتوي على تلك الشرائح فقط واحفظه كـ PPT؛ أو استخدم خدمة/API تدعم معلمات التحويل لكل شريحة.

**هل يتم دعم العروض المحمية بكلمة مرور؟**

نعم. يمكنك اكتشاف ما إذا كان الملف محميًا، فتحه باستخدام كلمة مرور، وأيضًا[تكوين إعدادات الحماية/التشفير](/slides/ar/net/password-protected-presentation/) للـ PPT المحفوظ.