---
title: تحويل ODP إلى PPTX على Android
linktitle: ODP إلى PPTX
type: docs
weight: 10
url: /ar/androidjava/convert-odp-to-pptx/
keywords:
- تحويل OpenDocument
- تحويل عرض تقديمي
- تحويل شريحة
- تحويل ODP
- OpenDocument إلى PPTX
- ODP إلى PPTX
- حفظ ODP كـ PPTX
- تصدير ODP إلى PPTX
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تحويل ODP إلى PPTX باستخدام Aspose.Slides لأندرويد. أمثلة كود جافا نظيفة، نصائح الدفعات، ونتائج عالية الجودة—بدون الحاجة إلى PowerPoint."
---

## **تحويل ODP إلى عرض PPTX/PPT**
Aspose.Slides for Android via Java يوفّر فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) التي تمثّل ملف عرض تقديمي. يمكن الآن لفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) أيضًا الوصول إلى ODP من خلال مُنشئ [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#Presentation-java.lang.String-) عندما يتم إنشاء الكائن. يوضح المثال التالي كيفية تحويل عرض ODP إلى عرض PPTX.

```java
// فتح ملف ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// حفظ عرض ODP بصيغة PPTX
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **مثال حي**
يمكنك زيارة تطبيق الويب [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) الذي بُني باستخدام **Aspose.Slides API**. يوضح التطبيق كيفية تنفيذ تحويل ODP إلى PPTX باستخدام Aspose.Slides API.

## **الأسئلة الشائعة**

**هل أحتاج إلى تثبيت Microsoft PowerPoint أو LibreOffice لتحويل ODP إلى PPTX؟**

لا. يعمل Aspose.Slides بشكل مستقل ولا يتطلب تطبيقات طرف ثالث لقراءة أو كتابة ODP/PPTX.

**هل يتم الحفاظ على الشرائح الرئيسية والتخطيطات والسمات أثناء التحويل؟**

نعم. تستخدم المكتبة نموذج كائن عرض تقديمي كامل وتحتفظ بالهيكل، بما في ذلك الشرائح الرئيسية والتخطيطات، بحيث يبقى التصميم صحيحًا بعد التحويل.

**هل يمكنني تحويل ملفات ODP المحمية بكلمة مرور؟**

نعم. يدعم Aspose.Slides اكتشاف الحماية، وفتح العمل مع [protected presentations](/slides/ar/androidjava/password-protected-presentation/) (بما في ذلك ODP) عندما تزود كلمة المرور، وكذلك تكوين التشفير والوصول إلى خصائص المستند.

**هل Aspose.Slides مناسب لخدمات التحويل السحابية أو المستندة إلى REST؟**

نعم. يمكنك استخدام المكتبة المحلية في الخلفية الخاصة بك أو [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST API)؛ كلا الخيارين يدعمان تحويل ODP → PPTX.