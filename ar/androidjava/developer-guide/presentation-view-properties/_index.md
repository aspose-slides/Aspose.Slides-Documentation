---
title: استرجاع وتحديث خصائص عرض العرض التقديمي على Android
linktitle: خصائص العرض
type: docs
weight: 80
url: /ar/androidjava/presentation-view-properties/
keywords:
- خصائص العرض
- العرض العادي
- محتوى المخطط
- أيقونات المخطط
- تثبيت الفاصل العمودي
- العرض الفردي
- حالة الشريط
- حجم البُعد
- تعديل تلقائي
- التكبير الافتراضي
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "اكتشف خصائص العرض في Aspose.Slides لنظام Android عبر Java لتخصيص صيغ شرائح PPT و PPTX و ODP — ضبط التخطيطات ومستويات التكبير وإعدادات العرض."
---
## **المقدمة**

يتكون العرض العادي من ثلاث مناطق محتوى: الشريحة نفسها، منطقة محتوى جانبية، ومنطقة محتوى سفلية. الخصائص المتعلقة بموضع مناطق المحتوى المختلفة. تسمح هذه المعلومات للتطبيق بحفظ حالة العرض إلى الملف، بحيث عندما يُعاد فتحه تكون الحالة نفسها كما كانت عند حفظ العرض التقديمي آخر مرة.

تم إضافة الطريقة [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) لتوفير الوصول إلى خصائص العرض العادي للعرض التقديمي.  

تم إضافة الواجهات [INormalViewProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties)، [INormalViewRestoredProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewRestoredProperties) وسلالتها، وكذلك تعداد [SplitterBarStateType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/SplitterBarStateType).

## **حول INormalViewProperties**

تمثل خصائص العرض العادي.

تحدد الطريقتان [getShowOutlineIcons](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) و[getSetShowOutlineIcons](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) ما إذا كان يجب على التطبيق إظهار أيقونات عند عرض محتوى المخطط في أي من مناطق المحتوى في وضع العرض العادي.

تحدد الطريقتان [getSnapVerticalSplitter](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) و[setSnapVerticalSplitter](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) ما إذا كان الفاصل العمودي يجب أن ينتقل إلى حالة مصغرة عندما تكون المنطقة الجانبية صغيرة بما يكفي.

تحدد الخاصية [getPreferSingleView](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) و[setPreferSingleView](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) ما إذا كان المستخدم يفضل رؤية منطقة محتوى واحدة بملء النافذة بدلاً من العرض العادي القياسي الذي يحتوي على ثلاث مناطق محتوى. إذا تم تمكينها، قد يختار التطبيق عرض إحدى مناطق المحتوى على كامل النافذة.

تحدد الطريقتان [getVerticalBarState](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) و[getHorizontalBarState](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) الحالة التي يجب أن يُظهر فيها شريط الفاصل الأفقي أو العمودي. يفصل شريط الفاصل الأفقي الشريحة عن منطقة المحتوى أسفل الشريحة، وي separates vertical accordingly. القيم الممكنة هي: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/SplitterBarStateType#Minimized)، [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) و[SplitterBarStateType.Restored](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

تحدد الطريقتان [getRestoredLeft](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) و[getRestoredTop](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) حجم منطقة الشريحة العلوية أو الجانبية في العرض العادي، عندما تُطبق قيمة [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/SplitterBarStateType#Restored) على [getVerticalBarState](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) و[getHorizontalBarState](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) على التوالي.

## **حول استعادة INormalViewProperties**

يحدد حجم منطقة الشريحة (العرض عندما تكون فرعًا لـ [getRestoredTop](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--)، الارتفاع عندما تكون فرعًا لـ [getRestoredLeft](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) في العرض العادي، عندما تكون المنطقة ذات حجم مستعاد متغيّر (ليس مصغرًا ولا مكبرًا).  

تحدد الطريقة [getDimensionSize](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) حجم منطقة الشريحة (العرض عندما تكون فرعًا لـ restoredTop، الارتفاع عندما تكون فرعًا لـ restoredLeft).  

تحدد الطريقة [getAutoAdjust](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) ما إذا كان يجب أن تُعوّض منطقة المحتوى الجانبية عن الحجم الجديد عند تغيير حجم النافذة التي تحتوي على العرض داخل التطبيق.  

يُظهر المثال أدناه كيفية الوصول إلى خصائص [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) لعروض تقديمية.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // استعادة خصائص العرض للعرض التقديمي
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```
## **تعيين قيمة التكبير الافتراضية**

{{% alert color="info" %}} 

يدعم Aspose.Slides لـ Android عبر Java الآن تعيين قيمة التكبير الافتراضية للعروض التقديمية بحيث يتم تعيين التكبير بالفعل عند فتح العرض. يمكن تحقيق ذلك عن طريق ضبط [ViewProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ViewProperties) للعرض. يمكن ضبط كل من [getSlideViewProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) و[getNotesViewProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) برمجياً. في هذا الموضوع، سنرى من خلال مثال كيفية ضبط [View Properties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ViewProperties) للـ [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation) في [Aspose.Slides](/slides/ar/).

{{% /alert %}} 

من أجل ضبط خصائص العرض، يرجى اتباع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation).
1. ضبط [View Properties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ViewProperties) للـ [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation).
1. احفظ العرض كملف [PPTX](https://docs.fileformat.com/presentation/pptx/). في المثال أدناه، تم تعيين قيمة التكبير لعرض الشريحة وكذلك عرض الملاحظات.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // تعيين خصائص العرض للعرض التقديمي
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // قيمة التكبير بالنسب المئوية لعرض الشريحة
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // قيمة التكبير بالنسب المئوية لعرض الملاحظات 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **الأسئلة الشائعة**

### هل يمكنني تعيين إعدادات عرض مختلفة لأقسام مختلفة من العرض التقديمي؟

يتم تعريف [View settings](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getViewProperties--) على مستوى العرض التقديمي ([Normal View](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--))، وليس لكل قسم، لذلك تُطبق مجموعة واحدة من المعلمات على المستند بالكامل عند فتحه.

### هل يمكنني تحديد حالات عرض مختلفة مسبقًا لمستخدمين مختلفين؟

لا. يتم تخزين الإعدادات في الملف وتُشارك. قد تلتزم تطبيقات المشاهدة بتفضيلات المستخدم، لكن الملف نفسه يحتوي على مجموعة واحدة من خصائص العرض.

### هل يمكنني إعداد قالب يحتوي على خصائص عرض مسبقة الدمج بحيث تفتح العروض التقديمية الجديدة بنفس الطريقة؟

نعم. نظرًا لأن [view properties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getViewProperties--) تُخزن على مستوى العرض التقديمي، يمكنك تضمينها في قالب وإنشاء مستندات جديدة منه مع نفس تكوين العرض الأولي.