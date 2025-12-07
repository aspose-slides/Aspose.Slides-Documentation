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
description: "قم بتحويل PPTX إلى PPT بسهولة باستخدام Aspose.Slides لـ C++ — تأكد من التوافق السلس مع تنسيقات PowerPoint مع الحفاظ على تخطيط العرض التقديمي وجودته."
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض PowerPoint بتنسيق PPTX إلى تنسيق PPT باستخدام C++. يتم تغطية الموضوع التالي.

- تحويل PPTX إلى PPT في C++

## **تحويل PPTX إلى PPT في C++**

للحصول على مثال كود C++ لتحويل PPTX إلى PPT، يرجى الاطلاع على القسم أدناه وهو [Convert PPTX to PPT](#convert-pptx-to-ppt). يقوم بتحميل ملف PPTX وحفظه بتنسيق PPT. عن طريق تحديد تنسيقات حفظ مختلفة، يمكنك أيضًا حفظ ملف PPTX إلى العديد من التنسيقات الأخرى مثل PDF وXPS وODP وHTML وغيرها كما نوقش في هذه المقالات. 

- [C++ تحويل PPTX إلى PDF](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-pdf/)
- [C++ تحويل PPTX إلى XPS](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/)
- [C++ تحويل PPTX إلى HTML](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-html/)
- [C++ تحويل PPTX إلى ODP](https://docs.aspose.com/slides/cpp/save-presentation/)
- [C++ تحويل PPTX إلى Image](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-png/)

## **تحويل PPTX إلى PPT**
لتحويل PPTX إلى PPT، ما عليك سوى تمرير اسم الملف وتنسيق الحفظ إلى طريقة **Save** في الفئة [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/). يثبت المثال البرمجي C++ أدناه تحويل عرض تقديمي من PPTX إلى PPT باستخدام الخيارات الافتراضية.
```cpp
// تحميل ملف PPTX.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// حفظ بتنسيق PPT.
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```


## **الأسئلة المتكررة**

**هل تحتفظ جميع تأثيرات وميزات PPTX عند الحفظ بتنسيق PPT القديم (97–2003)؟**

ليس دائماً. يفتقر تنسيق PPT إلى بعض الإمكانيات الأحدث (مثل بعض التأثيرات، الكائنات، والسلوكيات)، لذلك قد يتم تبسيط أو تحويل الميزات إلى صورة rasterized أثناء التحويل.

**هل يمكنني تحويل شرائح محددة فقط إلى PPT بدلاً من العرض الكامل؟**

الحفظ المباشر يستهدف العرض الكامل. لتحويل شرائح محددة، أنشئ عرضًا تقديميًا جديدًا يحتوي فقط على تلك الشرائح واحفظه كملف PPT؛ أو استخدم خدمة/API تدعم معلمات التحويل لكل شريحة.

**هل يتم دعم العروض المحمية بكلمة مرور؟**

نعم. يمكنك اكتشاف ما إذا كان الملف محميًا، فتحه باستخدام كلمة مرور، وأيضًا [تكوين إعدادات الحماية/التشفير](/slides/ar/cpp/password-protected-presentation/) للـ PPT المحفوظ.