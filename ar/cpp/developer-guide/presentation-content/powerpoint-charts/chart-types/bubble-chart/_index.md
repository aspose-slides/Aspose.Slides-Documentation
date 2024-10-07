---
title: رسم بياني فقاعي
type: docs
url: /cpp/bubble-chart/
---

## **تغيير حجم الرسم البياني الفقاعي**
تقدم Aspose.Slides لـ C++ دعمًا لتغيير حجم الرسم البياني الفقاعي. في Aspose.Slides لـ **C++ تم إضافة خصائص **IChartSeries.BubbleSizeScale** و **IChartSeriesGroup.BubbleSizeScale**. تم إعطاء مثال بسيط أدناه.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}


## **تمثيل البيانات كأحجام للرسم البياني الفقاعي**
تم إضافة طريقة جديدة **get_BubbleSizeRepresentation()** إلى فئات **IChartSeries** و **ChartSeries**. تحدد **BubbleSizeRepresentation** كيفية تمثيل قيم حجم الفقاعات في الرسم البياني الفقاعي. القيم الممكنة هي: **BubbleSizeRepresentationType.Area** و **BubbleSizeRepresentationType.Width**. وبناءً عليه، تم إضافة تعداد **BubbleSizeRepresentationType** لتحديد الطرق الممكنة لتمثيل البيانات كأحجام للرسم البياني الفقاعي. الكود التجريبي موضح أدناه.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}