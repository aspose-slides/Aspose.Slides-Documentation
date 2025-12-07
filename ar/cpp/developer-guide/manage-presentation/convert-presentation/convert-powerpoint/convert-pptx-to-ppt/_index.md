---
title: تحويل PPTX إلى PPT في C++
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
description: "قم بتحويل PPTX إلى PPT بسهولة باستخدام Aspose.Slides للغة C++ - احرص على توافق سلس مع صيغ PowerPoint مع الحفاظ على تخطيط وعرض تقديمك وجودته."
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض PowerPoint بصيغة PPTX إلى صيغة PPT باستخدام C++. الموضوع التالي مغطى.

- تحويل PPTX إلى PPT في C++

## **تحويل PPTX إلى PPT في C++**

للحصول على مثال كود C++ لتحويل PPTX إلى PPT، يرجى الاطلاع على القسم أدناه أي [Convert PPTX to PPT](#convert-pptx-to-ppt). يقوم بتحميل ملف PPTX فقط ثم حفظه بصيغة PPT. عن طريق تحديد صيغ حفظ مختلفة، يمكنك أيضًا حفظ ملف PPTX إلى صيغ أخرى عديدة مثل PDF، XPS، ODP، HTML وغيرها كما نوقش في هذه المقالات. 

- [C++ تحويل PPTX إلى PDF](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-pdf/)
- [C++ تحويل PPTX إلى XPS](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/)
- [C++ تحويل PPTX إلى HTML](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-html/)
- [C++ تحويل PPTX إلى ODP](https://docs.aspose.com/slides/cpp/save-presentation/)
- [C++ تحويل PPTX إلى Image](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-png/)

## **تحويل PPTX إلى PPT**
لتحويل PPTX إلى PPT، ما عليك سوى تمرير اسم الملف وصيغة الحفظ إلى طريقة **Save** في الفئة [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/). المثال البرمجي C++ أدناه يحول عرضًا من PPTX إلى PPT باستخدام الخيارات الافتراضية.
```cpp
// تحميل ملف PPTX.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// حفظ بصيغة PPT.
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```


## **الأسئلة المتكررة**

**هل تبقى جميع التأثيرات والميزات في PPTX عند الحفظ بصيغة PPT القديمة (97–2003)؟**

ليس دائمًا. صيغة PPT تفتقر إلى بعض القدرات الأحدث (مثل بعض التأثيرات، والكائنات، والسلوكيات)، لذلك قد يتم تبسيط أو تحويل الميزات إلى نقاط raster خلال التحويل.

**هل يمكنني تحويل شرائح محددة فقط إلى PPT بدلًا من العرض الكامل؟**

الحفظ المباشر يستهدف كامل العرض. لتحويل شرائح محددة فقط، أنشئ عرضًا جديدًا يحتوي على تلك الشرائح فقط واحفظه كملف PPT؛ أو بدلاً من ذلك، استخدم خدمة/API تدعم معلمات التحويل لكل شريحة.

**هل يتم دعم العروض المحمية بكلمة مرور؟**

نعم. يمكنك اكتشاف ما إذا كان الملف محمًا بكلمة مرور، فتحه باستخدام كلمة المرور، وكذلك [تكوين إعدادات الحماية/التشفير](/slides/ar/cpp/password-protected-presentation/) للـ PPT المحفوظ.