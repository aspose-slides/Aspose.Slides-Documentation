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
description: "قم بتحويل PPTX إلى PPT بسهولة باستخدام Aspose.Slides لنظام Android عبر Java — تأكد من توافق سلس مع صيغ PowerPoint مع الحفاظ على تخطيط وعرض العرض وجودته."
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض PowerPoint بتنسيق PPTX إلى تنسيق PPT باستخدام Java. يتم تغطية الموضوع التالي.

- تحويل PPTX إلى PPT باستخدام Java

## **تحويل PPTX إلى PPT على Android**

للحصول على مثال شفرة Java لتحويل PPTX إلى PPT، يرجى مراجعة القسم أدناه وهو [تحويل PPTX إلى PPT](#convert-pptx-to-ppt). يقوم بتحميل ملف PPTX وحفظه بتنسيق PPT. عن طريق تحديد تنسيقات حفظ مختلفة، يمكنك أيضاً حفظ ملف PPTX إلى صيغ أخرى كثيرة مثل PDF و XPS و ODP و HTML وغيرها كما نوقش في هذه المقالات.

- [تحويل PPTX إلى PDF على Android](/slides/ar/androidjava/convert-powerpoint-to-pdf/)
- [تحويل PPTX إلى XPS على Android](/slides/ar/androidjava/convert-powerpoint-to-xps/)
- [تحويل PPTX إلى HTML على Android](/slides/ar/androidjava/convert-powerpoint-to-html/)
- [تحويل PPTX إلى ODP على Android](/slides/ar/androidjava/save-presentation/)
- [تحويل PPTX إلى PNG على Android](/slides/ar/androidjava/convert-powerpoint-to-png/)

## **تحويل PPTX إلى PPT**
لتحويل ملف PPTX إلى PPT، ما عليك سوى تمرير اسم الملف وتنسيق الحفظ إلى الطريقة **Save** في فئة [**Presentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation). الكود Sample Java أدناه يحول عرضاً من PPTX إلى PPT باستخدام الخيارات الافتراضية.
```java
// إنشاء كائن Presentation يمثل ملف PPTX
Presentation presentation = new Presentation("template.pptx");

// حفظ العرض التقديمي كـ PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```


## **الأسئلة الشائعة**

**هل تبقى جميع تأثيرات وميزات PPTX عند الحفظ إلى تنسيق PPT القديم (97–2003)؟**

ليس دائماً. يفتقر تنسيق PPT إلى بعض القدرات الحديثة (مثل بعض التأثيرات، الكائنات، والسلوكيات)، لذا قد يتم تبسيط أو تحويل الميزات إلى صورة ثابتة أثناء التحويل.

**هل يمكنني تحويل الشرائح المحددة فقط إلى PPT بدلاً من العرض الكامل؟**

الحفظ المباشر يستهدف العرض بأكمله. لتحويل شرائح معينة، أنشئ عرضاً جديداً يحتوي فقط على تلك الشرائح واحفظه كـ PPT؛ بدلاً من ذلك، استخدم خدمة/API تدعم معلمات التحويل للشرائح الفردية.

**هل يتم دعم العروض المحمية بكلمة مرور؟**

نعم. يمكنك اكتشاف ما إذا كان الملف محمياً، فتحه باستخدام كلمة مرور، وأيضاً [configure protection/encryption settings](/slides/ar/androidjava/password-protected-presentation/) للعرض المحفوظ بتنسيق PPT.