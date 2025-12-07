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
description: "حول PPTX إلى PPT بسهولة باستخدام Aspose.Slides لـ C++ — احرص على توافق سلس مع صيغ PowerPoint مع الحفاظ على تخطيط وعرض تقديمك وجودته."
---

## **نظرة عامة**

توضح هذه المقالة كيفية تحويل عرض تقديمي PowerPoint بتنسيق PPTX إلى تنسيق PPT باستخدام C++. يتم تغطية الموضوع التالي.

- تحويل PPTX إلى PPT باستخدام C++

## **تحويل PPTX إلى PPT باستخدام C++**

للحصول على مثال شفرة C++ لتحويل PPTX إلى PPT، يرجى الاطلاع على القسم أدناه وهو [Convert PPTX to PPT](#convert-pptx-to-ppt). يقوم ببساطة بتحميل ملف PPTX وحفظه بتنسيق PPT. عن طريق تحديد تنسيقات حفظ مختلفة، يمكنك أيضًا حفظ ملف PPTX إلى تنسيقات أخرى كثيرة مثل PDF و XPS و ODP و HTML وغيرها كما هو موضح في هذه المقالات.

- [تحويل PPTX إلى PDF باستخدام C++](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-pdf/)
- [تحويل PPTX إلى XPS باستخدام C++](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/)
- [تحويل PPTX إلى HTML باستخدام C++](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-html/)
- [تحويل PPTX إلى ODP باستخدام C++](https://docs.aspose.com/slides/cpp/save-presentation/)
- [تحويل PPTX إلى صورة باستخدام C++](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-png/)

## **تحويل PPTX إلى PPT**
لتحويل ملف PPTX إلى PPT ما عليك سوى تمرير اسم الملف وتنسيق الحفظ إلى طريقة **Save** في فئة [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/). يوضح مثال شفرة C++ أدناه كيفية تحويل عرض تقديمي من PPTX إلى PPT باستخدام الخيارات الافتراضية.
```cpp
// تحميل ملف PPTX.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// حفظ بصيغة PPT.
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```


## **الأسئلة المتكررة**

**هل يتم الحفاظ على جميع تأثيرات وميزات PPTX عند الحفظ إلى تنسيق PPT (97–2003) القديم؟**

ليس دائمًا. يفتقر تنسيق PPT إلى بعض القدرات الأحدث (مثل بعض التأثيرات والكائنات والسلوكيات)، لذا قد يتم تبسيط أو تحويل الميزات إلى رسومات نقطية أثناء التحويل.

**هل يمكنني تحويل شرائح محددة فقط إلى PPT بدلاً من العرض التقديمي بالكامل؟**

الحفظ المباشر يستهدف العرض التقديمي كاملًا. لتحويل شرائح معينة، أنشئ عرضًا تقديميًا جديدًا يحتوي فقط على تلك الشرائح واحفظه كـ PPT؛ أو استخدم خدمة/واجهة برمجة تطبيقات تدعم تحويل الشرائح بشكل فردي.

**هل يتم دعم العروض التقديمية المحمية بكلمة مرور؟**

نعم. يمكنك اكتشاف ما إذا كان الملف محميًا، فتحه باستخدام كلمة مرور، وكذلك [configure protection/encryption settings](/slides/ar/cpp/password-protected-presentation/) للـ PPT المحفوظ.