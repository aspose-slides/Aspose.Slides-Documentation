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
- حفظ PPTX بصيغة PPT
- تصدير PPTX إلى PPT
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "قم بتحويل PPTX إلى PPT بسهولة باستخدام Aspose.Slides لأجهزة Android عبر Java—وتأكد من توافق سلس مع صيغ PowerPoint مع الحفاظ على تخطيط عرضك التقديمي وجودته."
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض PowerPoint بتنسيق PPTX إلى تنسيق PPT باستخدام Java. الموضوع التالي مغطى.

- تحويل PPTX إلى PPT باستخدام Java

## **تحويل PPTX إلى PPT على Android**

للحصول على مثال شفرة Java لتحويل PPTX إلى PPT، يرجى مراجعة القسم أدناه أي [Convert PPTX to PPT](#convert-pptx-to-ppt). يتم فقط تحميل ملف PPTX وحفظه بتنسيق PPT. بتحديد تنسيقات حفظ مختلفة، يمكنك أيضاً حفظ ملف PPTX إلى العديد من التنسيقات الأخرى مثل PDF و XPS و ODP و HTML وغيرها كما نوقش في هذه المقالات.

- [Java تحويل PPTX إلى PDF](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-pdf/)
- [Java تحويل PPTX إلى XPS](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-xps/)
- [Java تحويل PPTX إلى HTML](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-html/)
- [Java تحويل PPTX إلى ODP](https://docs.aspose.com/slides/androidjava/save-presentation/)
- [Java تحويل PPTX إلى صورة](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-png/)

## **تحويل PPTX إلى PPT**
لتحويل PPTX إلى PPT، ما عليك سوى تمرير اسم الملف وتنسيق الحفظ إلى طريقة **Save** في الفئة [**Presentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation). المثال البرمجي Java أدناه يحول Presentation من PPTX إلى PPT باستخدام الخيارات الافتراضية.
```java
// إنشاء كائن Presentation يمثل ملف PPTX
Presentation presentation = new Presentation("template.pptx");

// حفظ العرض التقديمي كـ PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```


## **الأسئلة المتكررة**

**هل تبقى جميع تأثيرات وميزات PPTX عند الحفظ بتنسيق PPT القديم (97–2003)؟**

ليس دائماً. يفتقر تنسيق PPT إلى بعض القدرات الأحدث (مثل بعض التأثيرات، الكائنات، والسلوكيات)، لذا قد يتم تبسيط أو تحويل الميزات إلى رسومات نقطية أثناء التحويل.

**هل يمكنني تحويل الشرائح المحددة فقط إلى PPT بدلاً من العرض الكامل؟**

الحفظ المباشر يستهدف العرض الكامل. لت تحويل شرائح محددة، أنشئ عرضًا جديدًا يحتوي فقط على تلك الشرائح واحفظه كـ PPT؛ أو استخدم خدمة/واجهة برمجة تطبيقات تدعم معلمات التحويل لكل شريحة.

**هل يتم دعم العروض المحمية بكلمة مرور؟**

نعم. يمكنك اكتشاف ما إذا كان الملف محميًا، فتحه باستخدام كلمة مرور، بالإضافة إلى [تكوين إعدادات الحماية/التشفير](/slides/ar/androidjava/password-protected-presentation/) للـ PPT المحفوظ.