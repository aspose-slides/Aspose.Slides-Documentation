---
title: تحويل ODP إلى PPTX
type: docs
weight: 10
url: /ar/cpp/convert-odp-to-pptx/
---

يقدم Aspose.Slides لـ .NET فئة Presentation التي تمثل ملف عرض تقديمي. يمكن الآن لفئة [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) الوصول إلى ODP من خلال مُنشئ Presentation عند إنشاء الكائن. يوضح المثال التالي كيفية تحويل عرض تقديمي ODP إلى عرض تقديمي PPTX.

``` cpp
// المسار إلى دليل المستندات.
String dataDir = GetDataPath();

// فتح ملف ODP
auto pres = System::MakeObject<Presentation>(dataDir + u"AccessOpenDoc.odp");

// حفظ عرض ODP التقديمي بتنسيق PPTX
pres->Save(dataDir + u"AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```



## **مثال مباشر**
يمكنك زيارة [**تحويل Aspose.Slides**](https://products.aspose.app/slides/conversion/) تطبيق الويب، الذي تم بناؤه باستخدام **واجهة برمجة تطبيقات Aspose.Slides.** يُظهر التطبيق كيفية تنفيذ تحويل ODP إلى PPTX باستخدام واجهة برمجة تطبيقات Aspose.Slides.