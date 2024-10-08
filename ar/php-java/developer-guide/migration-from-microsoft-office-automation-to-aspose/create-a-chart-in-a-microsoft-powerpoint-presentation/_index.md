---
title: إنشاء رسم بياني في عرض Microsoft PowerPoint
type: docs
weight: 70
url: /ar/php-java/create-a-chart-in-a-microsoft-powerpoint-presentation/
---

{{% alert color="primary" %}} 

 الرسوم البيانية هي تمثيلات بصرية للبيانات تُستخدم على نطاق واسع في العروض التقديمية. يوضح هذا المقال الشيفرة لإنشاء رسم بياني في Microsoft PowerPoint برمجيًا باستخدام [VSTO](/slides/ar/php-java/create-a-chart-in-a-microsoft-powerpoint-presentation/) و[Aspose.Slides لـ PHP عبر Java](/slides/ar/php-java/create-a-chart-in-a-microsoft-powerpoint-presentation/).

{{% /alert %}} 
## **إنشاء رسم بياني**
تصف أمثلة الشيفرة أدناه عملية إضافة رسم بياني عمودي مجمع ثلاثي الأبعاد بسيط باستخدام VSTO. تقوم بإنشاء نسخة من العرض التقديمي وإضافة رسم بياني افتراضي إليه. ثم تستخدم مصنف Microsoft Excel للوصول إلى بيانات الرسم البياني وتعديلها بالإضافة إلى ضبط خصائص الرسم البياني. أخيرًا، تقوم بحفظ العرض التقديمي.
### **مثال VSTO**
باستخدام VSTO، تُنفذ الخطوات التالية:

1. إنشاء نسخة من عرض Microsoft PowerPoint.
1. إضافة شريحة فارغة إلى العرض التقديمي.
1. إضافة رسم بياني **عمودي مجمع ثلاثي الأبعاد** والوصول إليه.
1. إنشاء نسخة جديدة من مصنف Microsoft Excel وتحميل بيانات الرسم البياني.
1. الوصول إلى ورقة بيانات الرسم البياني باستخدام نسخة مصنف Microsoft Excel.
1. ضبط نطاق الرسم البياني في ورقة العمل وإزالة السلسلتين 2 و3 من الرسم البياني.
1. تعديل بيانات فئة الرسم البياني في ورقة بيانات الرسم البياني.
1. تعديل بيانات السلسلة 1 في ورقة بيانات الرسم البياني.
1. الآن، الوصول إلى عنوان الرسم البياني وضبط خصائص الخط المتعلقة.
1. الوصول إلى محور القيمة للرسم البياني وضبط الوحدة الكبرى والوحدات الفرعية والحد الأقصى والحد الأدنى للقيم.
1. الوصول إلى عمق الرسم البياني أو محور السلسلة وإزالته كما في هذا المثال، حيث تُستخدم سلسلة واحدة فقط.
1. الآن، ضبط زوايا دوران الرسم البياني في اتجاه X وY.
1. حفظ العرض التقديمي.
1. إغلاق نسخ Microsoft Excel وPowerPoint.

**العرض التقديمي الناتج، الذي تم إنشاؤه بـ VSTO** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **مثال Aspose.Slides لـ PHP عبر Java**
باستخدام Aspose.Slides لـ PHP عبر Java، تُنفذ الخطوات التالية:

1. إنشاء نسخة من عرض Microsoft PowerPoint.
1. إضافة شريحة فارغة إلى العرض التقديمي.
1. إضافة رسم بياني **عمودي مجمع ثلاثي الأبعاد** والوصول إليه.
1. الوصول إلى ورقة بيانات الرسم البياني باستخدام نسخة مصنف Microsoft Excel.
1. إزالة السلسلتين 2 و3 غير المستخدمتين.
1. الوصول إلى فئات الرسم البياني وتعديل التسميات.
1. الوصول إلى السلسلة 1 وتعديل قيم السلسلة.
1. الآن، الوصول إلى عنوان الرسم البياني وضبط خصائص الخط.
1. الوصول إلى محور القيمة للرسم البياني وضبط الوحدة الكبرى والوحدات الفرعية والحد الأقصى والحد الأدنى للقيم.
1. الآن، ضبط زوايا دوران الرسم البياني في اتجاه X وY.
1. حفظ العرض التقديمي بصيغة PPTX.

**العرض التقديمي الناتج، الذي تم إنشاؤه بـ Aspose.Slides** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}