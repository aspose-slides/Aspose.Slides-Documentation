---
title: تحويل PPTX إلى PPT على Android
linktitle: PPTX إلى PPT
type: docs
weight: 21
url: /ar/androidjava/convert-pptx-to-ppt/
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
- Android
- Java
- Aspose.Slides
description: "تحويل PPTX إلى PPT بسهولة باستخدام Aspose.Slides لنظام Android عبر Java—ضمان توافق سلس مع تنسيقات PowerPoint مع الحفاظ على تخطيط وعرض الشرائح وجودتها."
---

## **نظرة عامة**

توضح هذه المقالة كيفية تحويل عرض PowerPoint بتنسيق PPTX إلى تنسيق PPT باستخدام Java. المواضيع التالية مغطاة.

- تحويل PPTX إلى PPT باستخدام Java

## **تحويل PPTX إلى PPT على Android**

للحصول على مثال شفرة Java لتحويل PPTX إلى PPT، يرجى الاطلاع على القسم أدناه وهو [Convert PPTX to PPT](#convert-pptx-to-ppt). يقوم بتحميل ملف PPTX وحفظه بصيغة PPT. من خلال تحديد صيغ حفظ مختلفة، يمكنك أيضًا حفظ ملف PPTX إلى صيغ أخرى كثيرة مثل PDF، XPS، ODP، HTML وغيرها كما نوقش في هذه المقالات. 

- [تحويل PPTX إلى PDF باستخدام Java](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-pdf/)
- [تحويل PPTX إلى XPS باستخدام Java](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-xps/)
- [تحويل PPTX إلى HTML باستخدام Java](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-html/)
- [تحويل PPTX إلى ODP باستخدام Java](https://docs.aspose.com/slides/androidjava/save-presentation/)
- [تحويل PPTX إلى صورة باستخدام Java](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-png/)

## **تحويل PPTX إلى PPT**
لتحويل ملف PPTX إلى PPT، ما عليك سوى تمرير اسم الملف وصيغة الحفظ إلى طريقة **Save** في فئة [**Presentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) . المثال البرمجي التالي في Java يحول عرضًا من PPTX إلى PPT باستخدام الخيارات الافتراضية.
```java
// إنشاء كائن Presentation يمثل ملف PPTX
Presentation presentation = new Presentation("template.pptx");

// حفظ العرض بصيغة PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```


## **الأسئلة المتكررة**

**هل تحتفظ جميع تأثيرات وميزات PPTX عند الحفظ إلى تنسيق PPT (97–2003) القديم؟**

ليس دائمًا. تنسيق PPT يفتقر إلى بعض الإمكانات الأحدث (مثل بعض التأثيرات، الكائنات، والسلوكيات)، لذا قد يتم تبسيط الميزات أو تحويلها إلى صور نقطية أثناء التحويل.

**هل يمكنني تحويل شرائح محددة فقط إلى PPT بدلًا من العرض الكامل؟**

الحفظ المباشر يستهدف العرض كاملًا. لتحويل شرائح معينة، يمكنك إنشاء عرض جديد يحتوي فقط على تلك الشرائح وحفظه بصيغة PPT؛ أو بدلاً من ذلك، استخدام خدمة/API تدعم معلمات التحويل حسب الشريحة.

**هل يتم دعم العروض المحمية بكلمة مرور؟**

نعم. يمكنك الكشف عما إذا كان الملف محميًا، فتحه باستخدام كلمة مرور، وأيضًا [تكوين إعدادات الحماية/التشفير](/slides/ar/androidjava/password-protected-presentation/) للـ PPT المحفوظ.