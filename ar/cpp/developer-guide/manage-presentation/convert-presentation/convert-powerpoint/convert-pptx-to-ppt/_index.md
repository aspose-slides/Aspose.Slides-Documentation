---
title: تحويل PPTX إلى PPT باستخدام C++
linktitle: PPTX إلى PPT
type: docs
weight: 21
url: /ar/cpp/convert-pptx-to-ppt/
keywords:
- تحويل PowerPoint
- تحويل العرض
- تحويل الشريحة
- تحويل PPTX
- PPTX إلى PPT
- حفظ PPTX كـ PPT
- تصدير PPTX إلى PPT
- PowerPoint
- العرض
- C++
- Aspose.Slides
description: "قم بتحويل PPTX إلى PPT بسهولة باستخدام Aspose.Slides للـ C++ — احرص على توافق سلس مع تنسيقات PowerPoint مع الحفاظ على تخطيط وعرض تقديمك وجودته."
---

## **نظرة عامة**

توضح هذه المقالة كيفية تحويل عرض PowerPoint بتنسيق PPTX إلى تنسيق PPT باستخدام C++. تم تغطية الموضوع التالي.

- تحويل PPTX إلى PPT باستخدام C++

## **تحويل PPTX إلى PPT باستخدام C++**

للحصول على عينة كود C++ لتحويل PPTX إلى PPT، يرجى الاطلاع على القسم أدناه أي [تحويل PPTX إلى PPT](#convert-pptx-to-ppt). تقوم العينة بتحميل ملف PPTX وحفظه بتنسيق PPT. عن طريق تحديد صيغ حفظ مختلفة، يمكنك أيضًا حفظ ملف PPTX إلى العديد من الصيغ الأخرى مثل PDF وXPS وODP وHTML إلخ كما هو مذكور في هذه المقالات.

- [C++ تحويل PPTX إلى PDF](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-pdf/)
- [C++ تحويل PPTX إلى XPS](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/)
- [C++ تحويل PPTX إلى HTML](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-html/)
- [C++ تحويل PPTX إلى ODP](https://docs.aspose.com/slides/cpp/save-presentation/)
- [C++ تحويل PPTX إلى Image](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-png/)

## **تحويل PPTX إلى PPT**
لتحويل PPTX إلى PPT ببساطة قم بتمرير اسم الملف وصيغة الحفظ إلى طريقة **Save** في فئة [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/). عينة الكود C++ أدناه تقوم بتحويل Presentation من PPTX إلى PPT باستخدام الإعدادات الافتراضية.
```cpp
// تحميل الـ PPTX.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// Save in PPT format.
prs->Save(u"convertedFile.ppt", Aspres::Slides::Export::SaveFormat::Ppt);
```


## **الأسئلة الشائعة**

**هل تبقى جميع تأثيرات وميزات PPTX عند الحفظ بتنسيق PPT القديم (97–2003)؟**

ليس دائمًا. يفتقر تنسيق PPT إلى بعض القدرات الأحدث (مثل بعض التأثيرات والكائنات والسلوكيات)، لذا قد يتم تبسيط أو تحويل الميزات إلى صورة نقطية أثناء التحويل.

**هل يمكنني تحويل الشرائح المحددة فقط إلى PPT بدلاً من العرض الكامل؟**

الحفظ المباشر يستهدف العرض الكامل. لتحويل شرائح معينة، أنشئ عرضًا جديدًا يحتوي فقط على تلك الشرائح واحفظه كـ PPT؛ أو استخدم خدمة/واجهة برمجة تطبيقات تدعم معلمات التحويل لكل شريحة.

**هل يتم دعم العروض المحمية بكلمة مرور؟**

نعم. يمكنك اكتشاف ما إذا كان الملف محميًا، فتحه باستخدام كلمة مرور، وكذلك [configure protection/encryption settings](/slides/ar/cpp/password-protected-presentation/) للـ PPT المحفوظ.