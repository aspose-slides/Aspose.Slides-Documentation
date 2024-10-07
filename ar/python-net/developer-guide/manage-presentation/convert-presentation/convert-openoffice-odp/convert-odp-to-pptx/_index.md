---
title: تحويل ODP إلى PPTX
type: docs
weight: 10
url: /python-net/convert-odp-to-pptx/
keywords: "تحويل عرض OpenOffice، ODP، ODP إلى PPTX، بايثون"
description: "تحويل ODP من OpenOffice إلى عرض PowerPoint PPTX في بايثون"
---

تقدم Aspose.Slides لـ Python عبر .NET فئة Presentation التي تمثل ملف عرض. يمكن الآن أيضًا لفئة [**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) الوصول إلى ODP من خلال باني Presentation عند إنشاء الكائن. يوضح المثال التالي كيفية تحويل عرض ODP إلى عرض PPTX.

```py
# استيراد وحدة Aspose.Slides لـ Python عبر .NET
import aspose.slides as slides

# فتح ملف ODP
pres = slides.Presentation("AccessOpenDoc.odp")

# حفظ عرض ODP بتنسيق PPTX
pres.save("AccessOpenDoc_out.pptx", slides.export.SaveFormat.PPTX)
```



## **مثال حي**
يمكنك زيارة [**تحويل Aspose.Slides**](https://products.aspose.app/slides/conversion/) تطبيق الويب، الذي تم بناؤه باستخدام **Aspose.Slides API.** يظهر التطبيق كيف يمكن تنفيذ تحويل ODP إلى PPTX باستخدام Aspose.Slides API.