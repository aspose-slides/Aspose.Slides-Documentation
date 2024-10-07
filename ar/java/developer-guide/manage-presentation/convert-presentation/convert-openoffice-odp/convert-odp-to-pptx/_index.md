---
title: تحويل ODP إلى PPTX
type: docs
weight: 10
url: /java/convert-odp-to-pptx/
---

## **تحويل ODP إلى عرض PPTX/PPT**
توفر Aspose.Slides لـ Java فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) التي تمثل ملف عرض تقديمي. يمكن الآن لفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) أيضًا الوصول إلى ODP من خلال مُنشئ [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#Presentation-java.lang.String-) عند إنشاء الكائن. يظهر المثال التالي كيفية تحويل عرض تقديمي ODP إلى عرض تقديمي PPTX.

```java
// فتح ملف ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// حفظ العرض التقديمي ODP بصيغة PPTX
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **مثال حي**
يمكنك زيارة [**تحويل Aspose.Slides**](https://products.aspose.app/slides/conversion/) تطبيق الويب، الذي تم بناؤه باستخدام **API Aspose.Slides.** توضح التطبيق كيفية تنفيذ تحويل ODP إلى PPTX باستخدام API Aspose.Slides.