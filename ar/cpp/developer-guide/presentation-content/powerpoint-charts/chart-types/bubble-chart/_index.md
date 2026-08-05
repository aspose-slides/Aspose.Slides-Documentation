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
- عرض تقديمي
- C++
- Aspose.Slides
description: "إنشاء وتخصيص مخططات فقاعات قوية في PowerPoint باستخدام Aspose.Slides للغة C++ لتعزيز تصور البيانات بسهولة."
---
## **نظرة عامة**

توضح هذه المقالة كيفية العمل مع مخططات الفقاعات في Aspose.Slides. تغطي خيارين مخصصين محددين: تعديل حجم الفقاعات عبر طريقة `set_BubbleSizeScale` والتحكم في طريقة تمثيل قيم حجم الفقاعات عبر طريقة `set_BubbleSizeRepresentation`.

توضح الأمثلة كيفية إنشاء مخطط فقاعات، وضبط تحجيم حجمه، وتغيير تمثيل حجم الفقاعة لاستخدام العرض. تتضمن المقالة أيضًا قسم أسئلة شائعة قصير يوضح دعم نوع المخطط “Bubble with 3-D”، ويشير إلى أن حدود المخطط العملية تعتمد على الأداء وإصدار PowerPoint المستهدف، ويشرح أن التصدير يحافظ على مظهر المخطط عبر محرك عرض Aspose.Slides.

## **تحجيم حجم مخطط الفقاعات**
يوفر Aspose.Slides for C++ دعمًا لتحجيم حجم مخطط الفقاعات. في Aspose.Slides for **C++** تم إضافة خاصيتي **IChartSeries.BubbleSizeScale** و**IChartSeriesGroup.BubbleSizeScale**. المثال التالي موضح أدناه.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}

## **تمثيل البيانات كأحجام مخطط الفقاعات**
تم إضافة طريقة **get_BubbleSizeRepresentation()** إلى الفئتين **IChartSeries** و**ChartSeries**. تحدد **BubbleSizeRepresentation** كيفية تمثيل قيم حجم الفقاعة في مخطط الفقاعات. القيم الممكنة هي: **BubbleSizeRepresentationType.Area** و**BubbleSizeRepresentationType.Width**. بناءً على ذلك، تمت إضافة تعداد **BubbleSizeRepresentationType** لتحديد الطرق الممكنة لتمثيل البيانات كأحجام مخطط الفقاعات. الكود التالي يوضح ذلك.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **الأسئلة الشائعة**

**هل يدعم “مخطط الفقاعات مع تأثير ثلاثي الأبعاد” وكيف يختلف عن المخطط العادي؟**

نعم. هناك نوع مخطط منفصل يُدعى “Bubble with 3-D”. يضيف نمطًا ثلاثيًا للأبعاد إلى الفقاعات دون إضافة محور إضافي؛ تظل البيانات X‑Y‑S (الحجم). النوع متاح في تعداد [نوع المخطط](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/charttype/) .

**هل هناك حد لعدد السلاسل والنقاط في مخطط الفقاعات؟**

لا يوجد حد ثابت على مستوى API؛ يتم تحديد القيود بناءً على الأداء وإصدار PowerPoint المستهدف. يُنصح بالحفاظ على عدد النقاط معقولًا لتحسين قابلية القراءة وسرعة العرض.

**كيف سيؤثر التصدير على مظهر مخطط الفقاعات (PDF، صور)؟**

يحافظ التصدير إلى الصيغ المدعومة على مظهر المخطط؛ يتم الرسم بواسطة محرك Aspose.Slides. بالنسبة إلى الصيغ النقطية/الشرحية، تُطبق قواعد الرسم العامة للمخططات (الدقة، مكافحة التعرج)، لذا يُفضَّل اختيار DPI كافٍ للطباعة.