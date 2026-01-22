---
title: تحويل PPTX إلى PPT في JavaScript
linktitle: PPTX إلى PPT
type: docs
weight: 21
url: /ar/nodejs-java/convert-pptx-to-ppt/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPTX
- PPTX إلى PPT
- حفظ PPTX كـ PPT
- تصدير PPTX إلى PPT
- PowerPoint
- العرض التقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تحويل PPTX إلى PPT بسهولة باستخدام Aspose.Slides—ضمان توافق سلس مع صيغ PowerPoint مع الحفاظ على تخطيط وجودة العرض التقديمي الخاص بك."
---

## **نظرة عامة**

توضح هذه المقالة كيفية تحويل عرض PowerPoint بتنسيق PPTX إلى تنسيق PPT باستخدام JavaScript. الموضوع التالي مغطى.

- تحويل PPTX إلى PPT في JavaScript

## **Java تحويل PPTX إلى PPT**

للحصول على عينة شفرة JavaScript لتحويل PPTX إلى PPT، يرجى الاطلاع على القسم أدناه أي [Convert PPTX to PPT](#convert-pptx-to-ppt). تقوم بتحميل ملف PPTX وحفظه بتنسيق PPT. من خلال تحديد تنسيقات حفظ مختلفة، يمكنك أيضًا حفظ ملف PPTX إلى العديد من التنسيقات الأخرى مثل PDF و XPS و ODP و HTML وغيرها كما نوقش في هذه المقالات. 

- [تحويل PPTX إلى PDF في JavaScript](/slides/ar/nodejs-java/convert-powerpoint-to-pdf/)
- [تحويل PPTX إلى XPS في JavaScript](/slides/ar/nodejs-java/convert-powerpoint-to-xps/)
- [تحويل PPTX إلى HTML في JavaScript](/slides/ar/nodejs-java/convert-powerpoint-to-html/)
- [تحويل PPTX إلى ODP في JavaScript](/slides/ar/nodejs-java/save-presentation/)
- [تحويل PPTX إلى PNG في JavaScript](/slides/ar/nodejs-java/convert-powerpoint-to-png/)

## **تحويل PPTX إلى PPT**

لتحويل PPTX إلى PPT ببساطة مرّر اسم الملف وتنسيق الحفظ إلى طريقة **Save** من الفئة [**Presentation**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). عينة الشفرة JavaScript أدناه تحول عرضًا من PPTX إلى PPT باستخدام الإعدادات الافتراضية.
```javascript
// إنشاء كائن Presentation يمثل ملف PPTX
var presentation = new aspose.slides.Presentation("template.pptx");
// save the presentation as PPT
presentation.save("output.ppt", aspose.slides.SaveFormat.Ppt);
```


## **الأسئلة الشائعة**

**هل تبقى جميع تأثيرات وميزات PPTX عند حفظها بتنسيق PPT القديم (97–2003)؟**

ليس دائمًا. يفتقر تنسيق PPT إلى بعض القدرات الأحدث (مثل بعض التأثيرات والكائنات والسلوكيات)، لذا قد يتم تبسيط أو تحويل الميزات إلى صورة raster أثناء التحويل.

**هل يمكنني تحويل شرائح محددة فقط إلى PPT بدلاً من العرض الكامل؟**

الحفظ المباشر يستهدف العرض كاملًا. لتحويل شرائح محددة، أنشئ عرضًا جديدًا يحتوي على تلك الشرائح فقط واحفظه كـ PPT؛ أو استخدم خدمة/واجهة برمجة تطبيقات تدعم معلمات تحويل لكل شريحة.

**هل تدعم العروض المحمية بكلمة مرور؟**

نعم. يمكنك اكتشاف ما إذا كان الملف محميًا، فتحه باستخدام كلمة مرور، وكذلك [تكوين إعدادات الحماية/التشفير](/slides/ar/nodejs-java/password-protected-presentation/) للـ PPT المحفوظ.