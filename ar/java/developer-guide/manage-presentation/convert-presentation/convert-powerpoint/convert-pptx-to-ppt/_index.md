---
title: تحويل PPTX إلى PPT في Java
linktitle: PPTX إلى PPT
type: docs
weight: 21
url: /ar/java/convert-pptx-to-ppt/
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
- Java
- Aspose.Slides
description: "تحويل PPTX إلى PPT بسهولة باستخدام Aspose.Slides for Java — احصل على توافق سلس مع صيغ PowerPoint مع الحفاظ على تخطيط وجودة العرض التقديمي الخاص بك."
---

## **نظرة عامة**

توضح هذه المقالة كيفية تحويل عرض PowerPoint بتنسيق PPTX إلى تنسيق PPT باستخدام Java. الموضوع التالي مشمول.

- تحويل PPTX إلى PPT في Java

## **تحويل PPTX إلى PPT في Java**

للحصول على عينة كود Java لتحويل PPTX إلى PPT، يرجى مراجعة القسم أدناه أي [Convert PPTX to PPT](#convert-pptx-to-ppt). يقوم فقط بتحميل ملف PPTX وحفظه بتنسيق PPT. عن طريق تحديد تنسيقات حفظ مختلفة، يمكنك أيضًا حفظ ملف PPTX إلى العديد من التنسيقات الأخرى مثل PDF وXPS وODP وHTML وغيرها كما هو موضح في هذه المقالات.

- [تحويل PPTX إلى PDF في Java](/slides/ar/java/convert-powerpoint-to-pdf/)
- [تحويل PPTX إلى XPS في Java](/slides/ar/java/convert-powerpoint-to-xps/)
- [تحويل PPTX إلى HTML في Java](/slides/ar/java/convert-powerpoint-to-html/)
- [تحويل PPTX إلى ODP في Java](/slides/ar/java/save-presentation/)
- [تحويل PPTX إلى PNG في Java](/slides/ar/java/convert-powerpoint-to-png/)

## **تحويل PPTX إلى PPT**
لتحويل PPTX إلى PPT ببساطة مرّر اسم الملف وتنسيق الحفظ إلى طريقة **Save** في فئة [**Presentation**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). عينة الكود Java أدناه تحول عرض تقديمي من PPTX إلى PPT باستخدام الخيارات الافتراضية.
```java
// إنشاء كائن Presentation يمثل ملف PPTX
Presentation presentation = new Presentation("template.pptx");

// حفظ العرض التقديمي كـ PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```


## **الأسئلة المتكررة**

**هل تبقى جميع تأثيرات وميزات PPTX محفوظة عند الحفظ بتنسيق PPT (97–2003) القديم؟**

ليس دائمًا. يفتقر تنسيق PPT إلى بعض القدرات الأحدث (مثل بعض التأثيرات والكائنات والسلوكيات)، لذا قد يتم تبسيط أو تحويل الميزات إلى صور نقطية أثناء التحويل.

**هل يمكنني تحويل الشرائح المحددة فقط إلى PPT بدلاً من العرض الكامل؟**

الحفظ المباشر يستهدف العرض الكامل. لتحويل شرائح معينة، أنشئ عرضًا تقديميًا جديدًا يحتوي فقط على هذه الشرائح واحفظه كـ PPT؛ أو استخدم خدمة/واجهة برمجة تطبيقات تدعم معايير تحويل حسب الشريحة.

**هل يتم دعم العروض المحمية بكلمة مرور؟**

نعم. يمكنك اكتشاف ما إذا كان الملف محمياً، فتحه باستخدام كلمة مرور، وكذلك [configure protection/encryption settings](/slides/ar/java/password-protected-presentation/) للـ PPT المحفوظ.