---
title: تنسيق مخططات العرض التقديمي في C++
linktitle: تنسيق المخطط
type: docs
weight: 60
url: /ar/cpp/chart-formatting/
keywords:
- تنسيق المخطط
- تنسيق المخططات
- كائن المخطط
- خصائص المخطط
- إعدادات المخطط
- خيارات المخطط
- خصائص الخط
- حدود مستديرة
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعلم تنسيق المخططات في Aspose.Slides لـ C++ وحسّن عرض PowerPoint التقديمي الخاص بك بأسلوب احترافي وجذاب."
---

## **تنسيق كائنات المخطط**
Aspose.Slides for C++ يتيح للمطورين إضافة مخططات مخصصة إلى شرائحهم من الصفر. توضح هذه المقالة كيفية تنسيق كائنات المخطط المختلفة بما في ذلك محور الفئة ومحور القيم.

Aspose.Slides for C++ provides a simple API for managing different chart entities and formatting them using custom values:

1. إنشاء مثال من فئة **Presentation**.
1. الحصول على إشارة إلى شريحة عبر فهرستها.
1. إضافة مخطط ببيانات افتراضية مع أي نوع مطلوب (في هذا المثال سنستخدم ChartType.LineWithMarkers).
1. الوصول إلى محور القيم للمخطط وتعيين الخصائص التالية:
   1. تعيين **Line format** لخطوط الشبكة الرئيسية لمحور القيم
   1. تعيين **Line format** لخطوط الشبكة الفرعية لمحور القيم
   1. تعيين **Number Format** لمحور القيم
   1. تعيين **Min, Max, Major and Minor units** لمحور القيم
   1. تعيين **Text Properties** لبيانات محور القيم
   1. تعيين **Title** لمحور القيم
   1. تعيين **Line Format** لمحور القيم
1. الوصول إلى محور الفئة للمخطط وتعيين الخصائص التالية:
   1. تعيين **Line format** لخطوط الشبكة الرئيسية لمحور الفئة
   1. تعيين **Line format** لخطوط الشبكة الفرعية لمحور الفئة
   1. تعيين **Text Properties** لبيانات محور الفئة
   1. تعيين **Title** لمحور الفئة
   1. تعيين **Label Positioning** لمحور الفئة
   1. تعيين **Rotation Angle** لتسميات محور الفئة
1. الوصول إلى مفتاح المخطط وتعيين **Text Properties** له
1. إظهار مفاتيح المخطط دون تداخلها مع المخطط
1. الوصول إلى **Secondary Value Axis** للمخطط وتعيين الخصائص التالية:
   1. تمكين **Value Axis** الثانوي
   1. تعيين **Line Format** لمحور القيم الثانوي
   1. تعيين **Number Format** لمحور القيم الثانوي
   1. تعيين **Min, Max, Major and Minor units** لمحور القيم الثانوي
1. الآن ارسم السلسلة الأولى للمخطط على محور القيم الثانوي
1. ضبط خلفية المخطط لتعبئة اللون
1. ضبط لون تعبئة مساحة الرسم للمخطط
1. كتابة العرض المعدل إلى ملف PPTX

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartEntities-ChartEntities.cpp" >}}

## **تعيين خصائص الخط لمخطط**
Aspose.Slides for C++ provides support for setting the font related properties for the chart. Please follow the steps below for setting the font properties for chart.

- إنشاء كائن من فئة Presentation.
- إضافة مخطط إلى الشريحة.
- تعيين ارتفاع الخط.
- حفظ العرض المعدل.

مثال العينة أدناه.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontPropertiesForChart-FontPropertiesForChart.cpp" >}}

## **تعيين خصائص الخط لجدول بيانات المخطط**
Aspose.Slides for C++ provides support for changing color of categories in a series color.

1. إنشاء كائن من فئة Presentation.
1. إضافة مخطط إلى الشريحة.
1. تعيين جدول المخطط.
1. تعيين ارتفاع الخط.
1. حفظ العرض المعدل.

مثال العينة أدناه.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontPropertiesForChartDataTable-SettingFontPropertiesForChartDataTable.cpp" >}}

## **تعيين حدود مستديرة لمنطقة المخطط**
Aspose.Slides for C++ provides support for setting chart area. **IChart.HasRoundedCorners** and **Chart.HasRoundedCorners** properties have been added in Aspose.Slides.

1. إنشاء كائن من فئة Presentation.
1. إضافة مخطط إلى الشريحة.
1. تعيين نوع التعبئة ولون التعبئة للمخطط
1. تعيين خاصية الزاوية المستديرة إلى True.
1. حفظ العرض المعدل.

مثال العينة أدناه.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingChartAreaRoundedBorders-SettingChartAreaRoundedBorders.cpp" >}}

## **تعيين التنسيق الرقمي**
Aspose.Slides for C++ provides a simple API for managing chart data format:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
1. الحصول على إشارة إلى شريحة عبر فهرستها.
1. إضافة مخطط ببيانات افتراضية مع أي نوع مطلوب (هذا المثال يستخدم **ChartType.ClusteredColumn**).
1. تعيين تنسيق الرقم المسبق من القيم المسبقة الممكنة.
1. الانتقال عبر خلية بيانات المخططات في كل سلسلة وتعيين تنسيق رقم بيانات المخطط.
1. حفظ العرض.
1. تعيين تنسيق الرقم المخصص.
1. الانتقال عبر خلايا بيانات المخطط داخل كل سلسلة وتعيين تنسيق رقم مختلف.
1. حفظ العرض.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NumberFormat-NumberFormat.cpp" >}}

| |**القيم الممكنة لتنسيق الأرقام المسبقة مع الفهرس المسبق والتي يمكن استخدامها موضح أدناه:**|
| :- | :- |
|**0**|General|
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?>
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0/)|
|**48**|##0.0E+00|
|**49**|@|
|||
| :- | :- |

## **الأسئلة المتكررة**

**هل يمكنني تعيين تعبئات شبه شفافة للأعمدة/المناطق مع الحفاظ على حدود غير شفافة؟**

نعم. يتم تكوين شفافية التعبئة والحدود بشكل منفصل. هذا مفيد لتحسين قابلية قراءة الشبكة والبيانات في التصورات الكثيفة.

**كيف يمكنني التعامل مع تسميات البيانات عندما تتداخل؟**

قلل حجم الخط، أو عطل مكونات التسمية غير الضرورية (مثل الفئات)، أو اضبط إزاحة/موضع التسمية، أو اعرض التسميات فقط للنقاط المختارة إذا لزم الأمر، أو غيّر التنسيق إلى "القيمة + المفتاح".

**هل يمكنني تطبيق تعبئات تدرجية أو نمطية على السلاسل؟**

نعم. عادةً ما تكون كل من التعبئات الصلبة والتدرجات/النقوش متاحة. في الممارسة العملية، استخدم التدرجات بشكل مقتصد وتجنب التركيبات التي تقلل من التباين مع الشبكة والنص.