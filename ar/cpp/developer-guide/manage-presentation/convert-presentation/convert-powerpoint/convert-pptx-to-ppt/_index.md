---
title: تحويل PPTX إلى PPT باستخدام C++
linktitle: PPTX إلى PPT
type: docs
weight: 21
url: /ar/cpp/convert-pptx-to-ppt/
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
- C++
- Aspose.Slides
description: "قم بتحويل PPTX إلى PPT بسهولة باستخدام Aspose.Slides لـ C++ — احرص على توافق سلس مع صيغ PowerPoint مع الحفاظ على تخطيط وعرضك وجودته."
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض PowerPoint بتنسيق PPTX إلى تنسيق PPT باستخدام C++. يتم تغطية الموضوع التالي.

- تحويل PPTX إلى PPT باستخدام C++

## **تحويل PPTX إلى PPT باستخدام C++**

للحصول على عينة كود C++ لتحويل PPTX إلى PPT، يرجى الاطلاع على القسم أدناه وهو [Convert PPTX to PPT](#convert-pptx-to-ppt). يقوم بتحميل ملف PPTX ويحفظه بتنسيق PPT. عن طريق تحديد صيغ حفظ مختلفة، يمكنك أيضًا حفظ ملف PPTX في العديد من الصيغ الأخرى مثل PDF و XPS و ODP و HTML وغيرها كما هو موضح في هذه المقالات.

- [C++ تحويل PPTX إلى PDF](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-pdf/)
- [C++ تحويل PPTX إلى XPS](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/)
- [C++ تحويل PPTX إلى HTML](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-html/)
- [C++ تحويل PPTX إلى ODP](https://docs.aspose.com/slides/cpp/save-presentation/)
- [C++ تحويل PPTX إلى Image](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-png/)

## **تحويل PPTX إلى PPT**
لتحويل PPTX إلى PPT، ما عليك سوى تمرير اسم الملف وصيغة الحفظ إلى طريقة **Save** في فئة [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/). عينة الكود C++ أدناه تحول **Presentation** من PPTX إلى PPT باستخدام الخيارات الافتراضية.
```cpp
// تحميل PPTX.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// حفظ بتنسيق PPT.
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```


## **الأسئلة الشائعة**

**هل تبقى جميع تأثيرات وميزات PPTX عند الحفظ بصيغة PPT القديمة (97–2003)؟**

ليس دائماً. صيغ PPT تفتقر إلى بعض القدرات الحديثة (مثل بعض التأثيرات، الكائنات، والسلوكيات)، لذا قد يتم تبسيط أو تحويل الميزات إلى صور نقطية أثناء التحويل.

**هل يمكنني تحويل شرائح مختارة فقط إلى PPT بدلاً من العرض الكامل؟**

الحفظ المباشر يستهدف العرض بالكامل. لتحويل شرائح معينة، أنشئ عرضًا جديدًا يضم تلك الشرائح فقط واحفظه كـ PPT؛ أو استخدم خدمة/API تدعم معلمات التحويل لكل شريحة.

**هل يتم دعم العروض المحمية بكلمة مرور؟**

نعم. يمكنك اكتشاف ما إذا كان الملف محميًا، فتحه باستخدام كلمة مرور، وكذلك [تكوين إعدادات الحماية/التشفير](/slides/ar/cpp/password-protected-presentation/) للـ PPT المحفوظ.