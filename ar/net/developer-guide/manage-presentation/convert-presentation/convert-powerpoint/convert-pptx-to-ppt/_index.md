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
description: "حوّل PPTX إلى PPT بسهولة باستخدام Aspose.Slides لـ .NET—ضمن توافقًا سلسًا مع صيغ PowerPoint مع الحفاظ على تخطيط وجودة عرضك التقديمي."
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض PowerPoint بتنسيق PPTX إلى تنسيق PPT باستخدام C#. تم تغطية الموضوع التالي.

- تحويل PPTX إلى PPT باستخدام C#

## **تحويل PPTX إلى PPT في .NET**

للحصول على عينة كود C# لتحويل PPTX إلى PPT، يرجى مراجعة القسم أدناه أي [تحويل PPTX إلى PPT](#convert-pptx-to-ppt). يقوم فقط بتحميل ملف PPTX وحفظه بتنسيق PPT. عبر تحديد تنسيقات حفظ مختلفة، يمكنك أيضًا حفظ ملف PPTX إلى صيغ متعددة أخرى مثل PDF و XPS و ODP و HTML وغيرها كما هو موضح في هذه المقالات.

- [C# تحويل PPTX إلى PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# تحويل PPTX إلى XPS](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# تحويل PPTX إلى HTML](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# تحويل PPTX إلى ODP](https://docs.aspose.com/slides/net/save-presentation/)
- [C# تحويل PPTX إلى Image](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **تحويل PPTX إلى PPT**
لتحويل PPTX إلى PPT، ما عليك سوى تمرير اسم الملف وتنسيق الحفظ إلى طريقة [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) لفئة [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation/) . يوضح العينة البرمجية C# أدناه كيفية تحويل عرض تقديمي من PPTX إلى PPT باستخدام الخيارات الافتراضية.
```c#
 // إنشاء كائن Presentation يمثل ملف PPTX
 Presentation pres = new Presentation("presentation.pptx");

 // حفظ عرض PPTX إلى تنسيق PPT
 pres.Save("presentation.ppt", SaveFormat.Ppt);
```


## **الأسئلة المتكررة**

**هل تبقى جميع التأثيرات والميزات في PPTX عند حفظها بتنسيق PPT القديم (97–2003)؟**

ليس دائماً. يفتقر تنسيق PPT إلى بعض القدرات الأحدث (مثل بعض التأثيرات، الكائنات، والسلوكيات)، لذلك قد يتم تبسيط الميزات أو تحويلها إلى رسومات نقطية أثناء التحويل.

**هل يمكنني تحويل شرائح محددة فقط إلى PPT بدلاً من العرض التقديمي بالكامل؟**

الحفظ المباشر يستهدف العرض التقديمي بأكمله. لتحويل شرائح معينة، قم بإنشاء عرض تقديمي جديد يحتوي فقط على تلك الشرائح واحفظه كملف PPT؛ أو استخدم خدمة/واجهة برمجة تطبيقات تدعم معايير التحويل لكل شريحة.

**هل يتم دعم العروض التقديمية المحمية بكلمة مرور؟**

نعم. يمكنك اكتشاف ما إذا كان الملف محمياً، فتحه باستخدام كلمة مرور، وكذلك [تكوين إعدادات الحماية/التشفير](/slides/ar/net/password-protected-presentation/) للـ PPT المحفوظ.