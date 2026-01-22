---
title: تحويل PPTX إلى PPT في C++
linktitle: PPTX إلى PPT
type: docs
weight: 21
url: /ar/cpp/convert-pptx-to-ppt/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPTX
- PPTX إلى PPT
- حفظ PPTX كـ PPT
- تصدير PPTX إلى PPT
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "قم بتحويل PPTX إلى PPT بسهولة باستخدام Aspose.Slides للـ C++—تأكد من توافق سلس مع صيغ PowerPoint مع الحفاظ على تخطيط وعرض تقديمك وجودته."
---

## **نظرة عامة**

هذه المقالة توضح كيفية تحويل عرض تقديمي PowerPoint بصيغة PPTX إلى صيغة PPT باستخدام C++. الموضوع التالي مغطى.

- تحويل PPTX إلى PPT في C++

## **تحويل PPTX إلى PPT في C++**

للحصول على مثال شفرة C++ لتحويل PPTX إلى PPT، يرجى مراجعة القسم أدناه أي [تحويل PPTX إلى PPT](#convert-pptx-to-ppt). يقوم بتحميل ملف PPTX وحفظه بصيغة PPT. عن طريق تحديد صيغ حفظ مختلفة، يمكنك أيضاً حفظ ملف PPTX إلى صيغ أخرى مثل PDF و XPS و ODP و HTML كما نوقش في هذه المقالات.

- [تحويل PPTX إلى PDF باستخدام C++](/slides/ar/cpp/convert-powerpoint-to-pdf/)
- [تحويل PPTX إلى XPS باستخدام C++](/slides/ar/cpp/convert-powerpoint-to-xps/)
- [تحويل PPTX إلى HTML باستخدام C++](/slides/ar/cpp/convert-powerpoint-to-html/)
- [تحويل PPTX إلى ODP باستخدام C++](/slides/ar/cpp/save-presentation/)
- [تحويل PPTX إلى PNG باستخدام C++](/slides/ar/cpp/convert-powerpoint-to-png/)

## **تحويل PPTX إلى PPT**
لتحويل PPTX إلى PPT ما عليك سوى تمرير اسم الملف وصيغة الحفظ إلى طريقة **Save** لفئة [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/). مثال شفرة C++ أدناه يحول Presentation من PPTX إلى PPT باستخدام الخيارات الافتراضية.
```cpp
// تحميل PPTX.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// حفظ بصيغة PPT.
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```


## **الأسئلة الشائعة**

**هل يتم الحفاظ على جميع تأثيرات وميزات PPTX عند الحفظ بتنسيق PPT (97–2003) القديم؟**

ليس دائماً. تنسيق PPT يفتقر إلى بعض القدرات الأحدث (مثل بعض التأثيرات، الكائنات، والسلوكيات)، لذا قد يتم تبسيط أو تحويل الميزات إلى رسومات نقطية أثناء التحويل.

**هل يمكنني تحويل الشرائح المحددة فقط إلى PPT بدلاً من كامل العرض؟**

الحفظ المباشر يستهدف كامل العرض. لتحويل شرائح معينة، أنشئ عرضاً تقديمياً جديداً يحتوي فقط على تلك الشرائح واحفظه كـ PPT؛ أو استخدم خدمة/واجهة برمجة تطبيقات تدعم معلمات التحويل لكل شريحة.

**هل يدعم العروض المحمية بكلمة مرور؟**

نعم. يمكنك الكشف عما إذا كان الملف محمياً، فتحه باستخدام كلمة المرور، وكذلك [configure protection/encryption settings](/slides/ar/cpp/password-protected-presentation/) للـ PPT المحفوظ.