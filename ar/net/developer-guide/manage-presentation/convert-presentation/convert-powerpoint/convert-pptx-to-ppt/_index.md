---
title: تحويل PPTX إلى PPT في C#
linktitle: تحويل PPTX إلى PPT
type: docs
weight: 21
url: /ar/net/convert-pptx-to-ppt/
keywords: "C# تحويل PPTX إلى PPT, تحويل عرض PowerPoint, PPTX إلى PPT, C#, Aspose.Slides"
description: "تحويل PowerPoint PPTX إلى PPT في C#"
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض PowerPoint بتنسيق PPTX إلى تنسيق PPT باستخدام C#. يتم تغطية الموضوع التالي.

- تحويل PPTX إلى PPT في C#

## **C# تحويل PPTX إلى PPT**

للحصول على عينة كود C# لتحويل PPTX إلى PPT، يرجى الاطلاع على القسم أدناه أي [تحويل PPTX إلى PPT](#convert-pptx-to-ppt). يقوم هذا الكود بتحميل ملف PPTX وحفظه بتنسيق PPT. من خلال تحديد تنسيقات حفظ مختلفة، يمكنك أيضًا حفظ ملف PPTX إلى العديد من التنسيقات الأخرى مثل PDF وXPS وODP وHTML وغيرها كما هو موضح في هذه المقالات.

- [C# تحويل PPTX إلى PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# تحويل PPTX إلى XPS](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# تحويل PPTX إلى HTML](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# تحويل PPTX إلى ODP](https://docs.aspose.com/slides/net/save-presentation/)
- [C# تحويل PPTX إلى صورة](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **تحويل PPTX إلى PPT**
لتحويل ملف PPTX إلى PPT، ما عليك سوى تمرير اسم الملف وتنسيق الحفظ إلى طريقة [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) الخاصة بفئة [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation/). مثال الكود C# أدناه يحول عرض تقديمي من PPTX إلى PPT باستخدام الإعدادات الافتراضية.
```c#
// إنشاء كائن Presentation يمثل ملف PPTX
Presentation pres = new Presentation("presentation.pptx");

// حفظ عرض PPTX إلى تنسيق PPT
pres.Save("presentation.ppt", SaveFormat.Ppt);
```


## **الأسئلة المتكررة**

**هل تبقى جميع التأثيرات والميزات في PPTX عند الحفظ بتنسيق PPT (97–2003) القديم؟**

ليس دائمًا. يفتقر تنسيق PPT إلى بعض القدرات الأحدث (مثل بعض التأثيرات، الكائنات، والسلوكيات)، لذا قد يتم تبسيط أو تحويل بعض الميزات إلى صورة أثناء التحويل.

**هل يمكنني تحويل شرائح محددة فقط إلى PPT بدلاً من العرض بالكامل؟**

الحفظ المباشر يستهدف العرض الكامل. لتحويل شرائح معينة، يمكنك إنشاء عرض تقديمي جديد يحتوي فقط على تلك الشرائح وحفظه كملف PPT؛ أو بدلاً من ذلك، استخدام خدمة/API تدعم تحويل كل شريحة على حدة.

**هل تدعم العروض المحمية بكلمة مرور؟**

نعم. يمكنك اكتشاف ما إذا كان الملف محميًا، وفتحه باستخدام كلمة مرور، وكذلك [configure protection/encryption settings](/slides/ar/net/password-protected-presentation/) للـ PPT المحفوظ.