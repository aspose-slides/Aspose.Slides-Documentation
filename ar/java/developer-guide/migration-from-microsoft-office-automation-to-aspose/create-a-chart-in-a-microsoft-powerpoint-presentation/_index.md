---
title: إنشاء مخططات باستخدام VSTO و Aspose.Slides للـ Java
linktitle: إنشاء مخطط
type: docs
weight: 70
url: /ar/java/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- إنشاء مخطط
- ترحيل
- VSTO
- أتمتة Office
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعرف على كيفية أتمتة إنشاء مخطط PowerPoint باستخدام Java. يوضح هذا الدليل خطوة بخطوة لماذا Aspose.Slides للـ Java هو بديل أسرع وأكثر قوة لـ Microsoft.Office.Interop."
---
{{% alert color="info" %}} 

المخططات هي تمثيلات بصرية للبيانات تُستخدم على نطاق واسع في العروض التقديمية. تُظهر هذه المقالة الشيفرة لإنشاء مخطط في Microsoft PowerPoint برمجياً باستخدام [VSTO](/slides/ar/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) و[Aspose.Slides for Java](/slides/ar/java/create-a-chart-in-a-microsoft-powerpoint-presentation/).

{{% /alert %}} 
## **إنشاء مخطط**
تصف أمثلة الشيفرة أدناه عملية إضافة مخطط عمودي مجمع ثلاثي الأبعاد بسيط باستخدام VSTO. تقوم بإنشاء مثيل لعرض تقديمي Microsoft PowerPoint، وتضيف مخططًا افتراضيًا إليه. ثم تستخدم مصنف Microsoft Excel للوصول إلى بيانات المخطط وتعديلها مع ضبط خصائص المخطط. أخيرًا، تحفظ العرض التقديمي.
### **مثال VSTO**
باستخدام VSTO، يتم تنفيذ الخطوات التالية:

1. إنشاء مثيل لعرض تقديمي Microsoft PowerPoint.
1. إضافة شريحة فارغة إلى العرض التقديمي.
1. إضافة مخطط **عمودي مجمع ثلاثي الأبعاد** والوصول إليه.
1. إنشاء مثيل جديد لمصنف Microsoft Excel وتحميل بيانات المخطط.
1. الوصول إلى ورقة عمل بيانات المخطط باستخدام مثيل Microsoft Excel Workbook instancefromworkbook.
1. تحديد نطاق المخطط في ورقة العمل وإزالة السلسلة 2 و3 من المخطط.
1. تعديل بيانات فئات المخطط في ورقة عمل بيانات المخطط.
1. تعديل بيانات السلسلة 1 للمخطط في ورقة عمل بيانات المخطط.
1. الآن، الوصول إلى عنوان المخطط وضبط خصائص الخط المتعلقة به.
1. الوصول إلى محور قيم المخطط وضبط الوحدة الرئيسية، الوحدات الفرعية، القيمة القصوى والقيمة الدنيا.
1. الوصول إلى عمق المخطط أو محور السلسلة وإزالته كما هو موضح في هذا المثال، حيث تُستَخدم سلسلة واحدة فقط.
1. الآن، ضبط زوايا دوران المخطط في اتجاه X وY.
1. حفظ العرض التقديمي.
1. إغلاق مثيلات Microsoft Excel وPowerPoint.

**عرض التقديم الناتج، تم إنشاؤه باستخدام VSTO** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **مثال Aspose.Slides for Java**
باستخدام Aspose.Slides for Java، يتم تنفيذ الخطوات التالية:

1. إنشاء مثيل لعرض تقديمي Microsoft PowerPoint.
1. إضافة شريحة فارغة إلى العرض التقديمي.
1. إضافة مخطط **عمودي مجمع ثلاثي الأبعاد** والوصول إليه.
1. الوصول إلى ورقة عمل بيانات المخطط باستخدام مثيل Microsoft Excel Workbook instancefromworkbook.
1. إزالة السلسلة 2 و3 غير المستخدمة.
1. الوصول إلى فئات المخطط وتعديل التسميات.
1. الوصول إلى السلسلة 1 وتعديل قيم السلسلة.
1. الآن، الوصول إلى عنوان المخطط وضبط خصائص الخط.
1. الوصول إلى محور قيم المخطط وضبط الوحدة الرئيسية، الوحدات الفرعية، القيمة القصوى والقيمة الدنيا.
1. الآن، ضبط زوايا دوران المخطط في اتجاه X وY.
1. حفظ العرض التقديمي بصيغة PPTX.

**عرض التقديم الناتج، تم إنشاؤه باستخدام Aspose.Slides** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}

## **الأسئلة المتكررة**

### هل يمكنني إنشاء أنواع أخرى من المخططات مثل مخططات الفطيرة أو الخطية أو الأعمدة باستخدام Aspose.Slides؟

نعم. يدعم Aspose.Slides مجموعة واسعة من [أنواع المخططات](/slides/ar/java/create-chart/)، بما في ذلك مخططات الفطيرة، المخططات الخطية، مخططات الأعمدة، المخططات النقطية، مخططات الفقاعات، وغيرها. يمكنك تحديد نوع المخطط المطلوب باستخدام الفئة [ChartType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/charttype/) عند إضافة مخطط.

### هل يمكنني تطبيق أنماط أو سمات مخصصة على المخطط؟

نعم. يمكنك تخصيص مظهر المخطط بالكامل، بما في ذلك الألوان، الخطوط، التعبئة، الحدود، خطوط الشبكة، وتخطيطه. ومع ذلك، تطبيق سمات Office تمامًا كما تظهر في PowerPoint يتطلب ضبط الأنماط الفردية يدويًا.

### هل يمكنني تصدير المخطط كصورة منفصلة عن الشريحة؟

نعم، يتيح Aspose.Slides تصدير أي شكل—بما في ذلك المخططات—كصورة منفصلة (مثل PNG أو JPEG) باستخدام طريقة `getImage` على [شكل](https://reference.aspose.com/slides/ar/java/com.aspose.slides/shape/).