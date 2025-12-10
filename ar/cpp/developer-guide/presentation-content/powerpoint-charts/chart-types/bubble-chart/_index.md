---
title: تخصيص مخططات الفقاعات في العروض التقديمية باستخدام C++
linktitle: مخطط الفقاعات
type: docs
url: /ar/cpp/bubble-chart/
keywords:
- مخطط الفقاعات
- حجم الفقاعات
- تحجيم الحجم
- تمثيل الحجم
- PowerPoint
- العرض التقديمي
- C++
- Aspose.Slides
description: "أنشئ وقم بتخصيص مخططات الفقاعات القوية في PowerPoint باستخدام Aspose.Slides لـ C++ لتحسين تصور البيانات بسهولة."
---

## **تحجيم حجم مخطط الفقاعات**
توفر Aspose.Slides لـ C++ دعمًا لتحجيم حجم مخطط الفقاعات. في Aspose.Slides لـ **C++** تمت إضافة الخصائص **IChartSeries.BubbleSizeScale** و **IChartSeriesGroup.BubbleSizeScale**. مثال توضيحي أدناه.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}

## **تمثيل البيانات كأحجام مخطط الفقاعات**
تم إضافة الطريقة الجديدة **get_BubbleSizeRepresentation()** إلى الفئات **IChartSeries** و **ChartSeries**. تحدد **BubbleSizeRepresentation** كيفية تمثيل قيم حجم الفقاعات في مخطط الفقاعات. القيم الممكنة هي: **BubbleSizeRepresentationType.Area** و **BubbleSizeRepresentationType.Width**. بناءً على ذلك، تمت إضافة تعداد **BubbleSizeRepresentationType** لتحديد الطرق الممكنة لتمثيل البيانات كأحجام مخطط الفقاعات. مثال الشيفرة موجود أدناه.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **الأسئلة الشائعة**

**هل يتم دعم "مخطط الفقاعات بتأثير ثلاثي الأبعاد"، وكيف يختلف عن المخطط العادي؟**
نعم. هناك نوع مخطط منفصل يدعى "Bubble with 3-D". يطبق تنسيقًا ثلاثي الأبعاد على الفقاعات لكنه لا يضيف محورًا إضافيًا؛ تظل البيانات X-Y-S (الحجم). يتوفر هذا النوع في تعداد [chart type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/).

**هل هناك حد لعدد السلاسل والنقاط في مخطط الفقاعات؟**
لا يوجد حد ثابت على مستوى API؛ يتم تحديد القيود بناءً على الأداء وإصدار PowerPoint المستهدف. يُنصح بالحفاظ على عدد النقاط معقولًا لضمان قابلية القراءة وسرعة العرض.

**كيف سيؤثر التصدير على مظهر مخطط الفقاعات (PDF، الصور)؟**
يحافظ التصدير إلى الصيغ المدعومة على مظهر المخطط؛ يتم إجراء العرض بواسطة محرك Aspose.Slides. بالنسبة للصيغ النقطية/المتجهة، تُطبق قواعد العرض العامة للرسومات البيانية (الدقة، إلغاء التنعيم)، لذا يُنصح باختيار DPI كافٍ للطباعة.