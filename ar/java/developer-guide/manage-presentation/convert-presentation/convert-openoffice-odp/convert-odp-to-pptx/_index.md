---
title: تحويل ODP إلى PPTX في Java
linktitle: ODP إلى PPTX
type: docs
weight: 10
url: /ar/java/convert-odp-to-pptx/
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
- Java
- Aspose.Slides
description: "تحويل ODP إلى PPTX باستخدام Aspose.Slides for Java. أمثلة نظيفة على كود Java، نصائح للدفعات، ونتائج عالية الجودة—بدون الحاجة إلى PowerPoint."
---

## **تحويل ODP إلى عرض PPTX/PPT**
Aspose.Slides for Java يوفر الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) التي تمثل ملف عرض تقديمي. يمكن الآن للفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) أيضًا الوصول إلى ODP عبر مُنشئ [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#Presentation-java.lang.String-) عندما يتم إنشاء الكائن. يُظهر المثال التالي كيفية تحويل عرض ODP إلى عرض PPTX.
```java
// فتح ملف ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// حفظ عرض ODP إلى صيغة PPTX
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **مثال حي**
يمكنك زيارة تطبيق الويب [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) الذي تم بناؤه باستخدام **Aspose.Slides API**. يوضح التطبيق كيفية تنفيذ تحويل ODP إلى PPTX باستخدام Aspose.Slides API.