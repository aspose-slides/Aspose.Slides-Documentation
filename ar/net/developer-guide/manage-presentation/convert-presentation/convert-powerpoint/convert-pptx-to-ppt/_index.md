---
title: "تحويل PPTX إلى PPT في .NET"
linktitle: "PPTX إلى PPT"
type: docs
weight: 21
url: /ar/net/convert-pptx-to-ppt/
keywords:
- "تحويل PowerPoint"
- "تحويل العرض التقديمي"
- "تحويل الشريحة"
- "تحويل PPTX"
- "PPTX إلى PPT"
- "حفظ PPTX كـ PPT"
- "تصدير PPTX إلى PPT"
- "PowerPoint"
- "عرض تقديمي"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "قم بتحويل PPTX إلى PPT بسهولة باستخدام Aspose.Slides for .NET — احرص على توافق سلس مع صيغ PowerPoint مع الحفاظ على تخطيط وجودة العرض التقديمي الخاص بك."
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض PowerPoint بصيغة PPTX إلى صيغة PPT باستخدام C#. الموضوع التالي مغطى.

- تحويل PPTX إلى PPT في C#

## **تحويل PPTX إلى PPT في .NET**

للحصول على عينة كود C# لتحويل PPTX إلى PPT، يرجى الاطلاع على القسم أدناه أي [تحويل PPTX إلى PPT](#convert-pptx-to-ppt). يقوم بتحميل ملف PPTX وحفظه بصيغة PPT. من خلال تحديد صيغ حفظ مختلفة، يمكنك أيضًا حفظ ملف PPTX إلى صيغ أخرى كثيرة مثل PDF و XPS و ODP و HTML وغيرها كما هو موضح في هذه المقالات.

- [تحويل PPTX إلى PDF في .NET](/slides/ar/net/convert-powerpoint-to-pdf/)
- [تحويل PPTX إلى XPS في .NET](/slides/ar/net/convert-powerpoint-to-xps/)
- [تحويل PPTX إلى HTML في .NET](/slides/ar/net/convert-powerpoint-to-html/)
- [تحويل PPTX إلى ODP في .NET](/slides/ar/net/save-presentation/)
- [تحويل PPTX إلى PNG في .NET](/slides/ar/net/convert-powerpoint-to-png/)

## **تحويل PPTX إلى PPT**
لتحويل PPTX إلى PPT ببساطة مرر اسم الملف وصيغة الحفظ إلى طريقة [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) في فئة [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation/). عينة الكود C# أدناه تحول عرضًا من PPTX إلى PPT باستخدام الخيارات الافتراضية.
```c#
// إنشاء كائن Presentation يمثل ملف PPTX
Presentation pres = new Presentation("presentation.pptx");

// حفظ عرض PPTX بصيغة PPT
pres.Save("presentation.ppt", SaveFormat.Ppt);
```


## **الأسئلة الشائعة**

**هل تبقى جميع تأثيرات وميزات PPTX عند الحفظ بصيغة PPT القديمة (97–2003)؟**

ليس دائمًا. صيغة PPT تفتقد بعض القدرات الحديثة (مثل بعض التأثيرات، الكائنات، والسلوكيات)، لذا قد تُبسط أو تُرسم كصور نقطية أثناء التحويل.

**هل يمكنني تحويل شرائح محددة فقط إلى PPT بدلاً من العرض بالكامل؟**

الحفظ المباشر يستهدف العرض كاملًا. لتحويل شرائح معينة، أنشئ عرضًا جديدًا يحتوي على تلك الشرائح فقط واحفظه بصيغة PPT؛ أو استخدم خدمة/واجهة برمجة تطبيقات تدعم معلمات تحويل لكل شريحة.

**هل تُدعم العروض المحمية بكلمة مرور؟**

نعم. يمكنك اكتشاف ما إذا كان الملف محميًا، فتحه باستخدام كلمة مرور، وكذلك [تكوين إعدادات الحماية/التشفير](/slides/ar/net/password-protected-presentation/) للـ PPT المُحفظ.