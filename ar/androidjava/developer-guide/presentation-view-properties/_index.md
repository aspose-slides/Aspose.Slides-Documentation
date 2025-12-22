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
- تثبيت الفاصل الرأسي
- عرض منفرد
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
description: "اكتشف Aspose.Slides لنظام Android عبر Java لخصائص العرض لتخصيص صيغ PPT و PPTX و ODP—ضبط التخطيطات ومستويات التكبير وإعدادات العرض."
---

{{% alert color="primary" %}} 

العرض العادي يتكون من ثلاث مناطق محتوى: الشريحة نفسها، منطقة محتوى جانبية، ومنطقة محتوى سفلية. الخصائص المتعلقة بموضع مناطق المحتوى المختلفة. تسمح هذه المعلومات للتطبيق بحفظ حالة العرض في الملف، بحيث عندما يتم فتحه مرة أخرى تكون الحالة كما كانت عندما تم حفظ العرض آخر مرة.

تمت إضافة الطريقة [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) لتوفير الوصول إلى خصائص العرض العادي للعرض التقديمي.  

تمت إضافة الواجهات [INormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties) وسلالتها، وكذلك التعداد [SplitterBarStateType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType) تم إضافته.  

{{% /alert %}} 

## **حول INormalViewProperties**

تمثل خصائص العرض العادي.

تحدد الطرق [getShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) و [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) ما إذا كان ينبغي للتطبيق إظهار الأيقونات عند عرض محتوى المخطط في أي من مناطق المحتوى في وضع العرض العادي.

تحدد الطرق [getSnapVerticalSplitter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) و [setSnapVerticalSplitter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) ما إذا كان الفاصل الرأسي يجب أن ينتقل إلى حالة مصغرة عندما تكون المنطقة الجانبية صغيرة بما يكفي.

تحدد الخاصية [getPreferSingleView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) و [setPreferSingleView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean--) ما إذا كان المستخدم يفضّل مشاهدة منطقة محتوى واحدة بملء النافذة بدلًا من العرض العادي القياسي الذي يحتوي على ثلاث مناطق محتوى. إذا تم تمكينها، قد يختار التطبيق عرض إحدى مناطق المحتوى في كامل النافذة.

تحدد الطرق [getVerticalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) و [getHorizontalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) الحالة التي يجب أن يُظهر فيها شريط الفاصل الأفقي أو الرأسي. شريط الفاصل الأفقي يفصل الشريحة عن منطقة المحتوى أسفل الشريحة، وشريط الفاصل الرأسي يفصل الشريحة عن المنطقة الجانبية. القيم الممكنة هي: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) و [SplitterBarStateType.Restored](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

تحدد الطرق [getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) و [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) حجم المنطقة العلوية أو الجانبية في العرض العادي، عندما تُطبق قيمة [SplitterBarStateType.Restored](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Restored) على [getVerticalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) و [getHorizontalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) وفقًا لذلك.

## **حول استعادة INormalViewProperties**

تحدد حجم منطقة الشريحة (العرض عندما تكون فرعًا لـ [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--)، الارتفاع عندما تكون فرعًا لـ [getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) في العرض العادي، عندما تكون المنطقة ذات حجم مستعاد متغير (ليس مصغّرًا ولا مكبّرًا).  

تحدد الطريقة [getDimensionSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) حجم منطقة الشريحة (العرض عندما تكون فرعًا لـ restoredTop، الارتفاع عندما تكون فرعًا لـ restoredLeft).  

تحدد الطريقة [getAutoAdjust](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) ما إذا كان يجب أن يتعوض حجم منطقة المحتوى الجانبية عن الحجم الجديد عند تعديل حجم النافذة التي تحتوي على العرض داخل التطبيق.  

يُعطى المثال أدناه يوضح كيفية الوصول إلى خصائص [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) لعرض تقديمي.  
```java
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

{{% alert color="primary" %}} 

يدعم Aspose.Slides لنظام Android عبر Java الآن تعيين قيمة التكبير الافتراضية للعرض التقديمي بحيث يتم تعيين التكبير بالفعل عند فتح العرض. يمكن تحقيق ذلك عن طريق تعيين [ViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties) للعرض التقديمي. يمكن ضبط كل من [getSlideViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) و [getNotesViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) برمجيًا. في هذا الموضوع، سنرى مثالًا يوضح كيفية تعيين [View Properties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties) لـ [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) في [Aspose.Slides](/slides/ar/).  

{{% /alert %}} 

لتعيين خصائص العرض، يرجى اتباع الخطوات التالية:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. تعيين [View Properties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties) لـ [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. كتابة العرض التقديمي كملف [PPTX](https://docs.fileformat.com/presentation/pptx/).  
في المثال المعطى أدناه، قمنا بتعيين قيمة التكبير لعرض الشريحة وكذلك لعرض الملاحظات.  
```java
Presentation presentation = new Presentation();
try {
    // تعيين خصائص العرض للعرض التقديمي
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // قيمة التكبير بالنسبة المئوية لعرض الشريحة
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // قيمة التكبير بالنسبة المئوية لعرض الملاحظات 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **الأسئلة الشائعة**

**هل يمكنني تعيين إعدادات عرض مختلفة لأقسام مختلفة من العرض التقديمي؟**

يتم تعريف [إعدادات العرض](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--) على مستوى العرض التقديمي ([Normal View](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--))، وليس لكل قسم، لذا مجموعة واحدة من المعلمات تنطبق على المستند بأكمله عند فتحه.

**هل يمكنني تعريف حالات عرض مختلفة لمستخدمين مختلفين مسبقًا؟**

لا. يتم تخزين الإعدادات في الملف وتُشارك. قد تحترم تطبيقات العرض تفضيلات المستخدم، لكن الملف نفسه يحتوي على مجموعة واحدة من خصائص العرض.

**هل يمكنني إعداد قالب يحتوي على خصائص عرض معرفة مسبقًا بحيث تُفتح العروض التقديمية الجديدة بنفس الطريقة؟**

نعم. نظرًا لأن [خصائص العرض](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--) تُخزن على مستوى العرض التقديمي، يمكنك تضمينها في قالب وإنشاء مستندات جديدة منه بنفس تكوين العرض الأولي.