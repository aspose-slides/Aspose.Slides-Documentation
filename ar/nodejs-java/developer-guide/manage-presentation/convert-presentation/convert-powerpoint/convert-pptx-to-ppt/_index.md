---
title: تحويل PPTX إلى PPT باستخدام JavaScript
linktitle: تحويل PPTX إلى PPT
type: docs
weight: 21
url: /ar/nodejs-java/convert-pptx-to-ppt/
keywords: "تحويل PPTX إلى PPT باستخدام Java, تحويل عرض PowerPoint, PPTX إلى PPT, Java, Aspose.Slides"
description: "تحويل PowerPoint PPTX إلى PPT باستخدام JavaScript"
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض PowerPoint بصيغة PPTX إلى صيغة PPT باستخدام JavaScript. الموضوع التالي مغطى.

- تحويل PPTX إلى PPT باستخدام JavaScript

## **Java تحويل PPTX إلى PPT**

للحصول على عينة شفرة JavaScript لتحويل PPTX إلى PPT، يرجى الاطلاع على القسم أدناه أي [Convert PPTX to PPT](#convert-pptx-to-ppt). يقوم بتحميل ملف PPTX وحفظه بصيغة PPT. عن طريق تحديد صيغ حفظ مختلفة، يمكنك أيضًا حفظ ملف PPTX بصيغ أخرى مثل PDF و XPS و ODP و HTML وغيرها كما نوقش في هذه المقالات.

- [Java تحويل PPTX إلى PDF](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-pdf/)
- [Java تحويل PPTX إلى XPS](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-xps/)
- [Java تحويل PPTX إلى HTML](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-html/)
- [Java تحويل PPTX إلى ODP](https://docs.aspose.com/slides/nodejs-java/save-presentation/)
- [Java تحويل PPTX إلى صورة](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-png/)

## **تحويل PPTX إلى PPT**

لتحويل PPTX إلى PPT، ما عليك سوى تمرير اسم الملف وصيغة الحفظ إلى طريقة **Save** في فئة [**Presentation**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). عينة الشفرة JavaScript أدناه تحول Presentation من PPTX إلى PPT باستخدام الخيارات الافتراضية.
```javascript
// إنشاء كائن Presentation يمثل ملف PPTX
var presentation = new aspose.slides.Presentation("template.pptx");
// حفظ العرض كملف PPT
presentation.save("output.ppt", aspose.slides.SaveFormat.Ppt);
```


## **الأسئلة الشائعة**

**هل جميع تأثيرات وميزات PPTX تبقى عند الحفظ بصيغة PPT القديمة (97–2003)؟**

ليس دائماً. صيغة PPT تفتقر إلى بعض القدرات الأحدث (مثل بعض التأثيرات، الكائنات، والسلوكيات)، لذا قد يتم تبسيط الميزات أو تحويلها إلى صورة raster أثناء التحويل.

**هل يمكنني تحويل شرائح محددة فقط إلى PPT بدلاً من العرض الكامل؟**

الحفظ المباشر يستهدف العرض كاملًا. لتحويل شرائح محددة، أنشئ عرضًا جديدًا يحتوي فقط على تلك الشرائح وقم بحفظه كـ PPT؛ أو استخدم خدمة/API تدعم معلمات التحويل لكل شريحة.

**هل يتم دعم العروض المحمية بكلمة مرور؟**

نعم. يمكنك اكتشاف ما إذا كان الملف محميًا، فتحه باستخدام كلمة مرور، وأيضًا [تكوين إعدادات الحماية/التشفير](/slides/ar/nodejs-java/password-protected-presentation/) للـ PPT المحفوظ.