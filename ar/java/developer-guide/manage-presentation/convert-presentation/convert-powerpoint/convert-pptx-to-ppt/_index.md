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
description: "قم بسهولة بتحويل PPTX إلى PPT باستخدام Aspose.Slides للـ Java — احرص على توافق سلس مع صيغ PowerPoint مع الحفاظ على تخطيط وعرض تقديميتك وجودتها."
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض PowerPoint بصيغة PPTX إلى صيغة PPT باستخدام Java. الموضوع التالي مغطى.

- تحويل PPTX إلى PPT باستخدام Java

## **تحويل PPTX إلى PPT باستخدام Java**

للحصول على عينة كود Java لتحويل PPTX إلى PPT، يرجى مراجعة القسم أدناه أي [تحويل PPTX إلى PPT](#convert-pptx-to-ppt). يتم فقط تحميل ملف PPTX وحفظه بصيغة PPT. عن طريق تحديد صيغ حفظ مختلفة، يمكنك أيضًا حفظ ملف PPTX إلى صيغ أخرى عديدة مثل PDF و XPS و ODP و HTML وغيرها كما نوقش في هذه المقالات. 

- [تحويل PPTX إلى PDF باستخدام Java](https://docs.aspose.com/slides/java/convert-powerpoint-to-pdf/)
- [تحويل PPTX إلى XPS باستخدام Java](https://docs.aspose.com/slides/java/convert-powerpoint-to-xps/)
- [تحويل PPTX إلى HTML باستخدام Java](https://docs.aspose.com/slides/java/convert-powerpoint-to-html/)
- [تحويل PPTX إلى ODP باستخدام Java](https://docs.aspose.com/slides/java/save-presentation/)
- [تحويل PPTX إلى صورة باستخدام Java](https://docs.aspose.com/slides/java/convert-powerpoint-to-png/)

## **تحويل PPTX إلى PPT**
لتحويل ملف PPTX إلى PPT، ما عليك سوى تمرير اسم الملف وصيغة الحفظ إلى طريقة **Save** في الصنف [**Presentation**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). عينة كود Java أدناه تحول عرضًا من PPTX إلى PPT باستخدام الإعدادات الافتراضية.
```java
// إنشاء كائن Presentation يمثل ملف PPTX
Presentation presentation = new Presentation("template.pptx");

// حفظ العرض التقديمي كـ PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```


## **الأسئلة الشائعة**

**هل تبقى جميع تأثيرات وميزات PPTX محفوظة عند الحفظ بصيغة PPT القديمة (97–2003)؟**

ليس دائمًا. تنقص صيغة PPT بعض القدرات الحديثة (مثل بعض التأثيرات، الكائنات، والسلوكيات)، لذا قد يتم تبسيط أو تحويل الميزات إلى نقطية أثناء التحويل.

**هل يمكنني تحويل الشرائح المحددة فقط إلى PPT بدلاً من العرض الكامل؟**

الحفظ المباشر يستهدف العرض الكامل. لتحويل شرائح محددة، أنشئ عرضًا جديدًا يحتوي فقط على تلك الشرائح واحفظه كـ PPT؛ أو استخدم خدمة/واجهة برمجة تطبيقات تدعم معلمات التحويل لكل شريحة.

**هل يتم دعم العروض المحمية بكلمة مرور؟**

نعم. يمكنك اكتشاف ما إذا كان الملف محميًا، فتحه باستخدام كلمة مرور، وكذلك [تكوين إعدادات الحماية/التشفير](/slides/ar/java/password-protected-presentation/) للـ PPT المحفوظ.