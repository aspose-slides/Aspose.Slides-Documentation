---
title: تحويل ODP إلى PPTX
type: docs
weight: 10
url: /ar/androidjava/convert-odp-to-pptx/
---

## **تحويل ODP إلى PPTX/PPT عرض تقديمي**
يقدم Aspose.Slides لنظام Android عبر Java فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) التي تمثل ملف عرض تقديمي. يمكن الآن لفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) أيضًا الوصول إلى ODP من خلال منشئ [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#Presentation-java.lang.String-) عند إنشاء الكائن. يوضح المثال التالي كيفية تحويل عرض تقديمي من ODP إلى عرض تقديمي من PPTX.

```java
// فتح ملف ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// حفظ عرض ODP التقديمي بتنسيق PPTX
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **مثال مباشر**
يمكنك زيارة [**تحويل Aspose.Slides**](https://products.aspose.app/slides/conversion/) التطبيق الويب، الذي تم بناؤه باستخدام **واجهة برمجة تطبيقات Aspose.Slides.** يوضح التطبيق كيفية تنفيذ تحويل ODP إلى PPTX باستخدام واجهة برمجة تطبيقات Aspose.Slides.