---
title: استرجاع وتحديث خصائص عرض العرض التقديمي في Java
linktitle: خصائص العرض
type: docs
weight: 80
url: /ar/java/presentation-view-properties/
keywords:
- خصائص العرض
- العرض العادي
- محتوى المخطط
- أيقونات المخطط
- تثبيت المقسم العمودي
- العرض الواحد
- حالة الشريط
- حجم البُعد
- تعديل تلقائي
- التكبير الافتراضي
- PowerPoint
- OpenDocument
- العرض التقديمي
- Java
- Aspose.Slides
description: "اكتشف خصائص عرض Aspose.Slides for Java لتخصيص صيغ شرائح PPT و PPTX و ODP — اضبط التخطيطات ومستويات التكبير وإعدادات العرض."
---
## **مقدمة**

العرض العادي يتكون من ثلاثة مناطق محتوى: الشريحة نفسها، ومنطقة محتوى جانبية، ومنطقة محتوى سفلية. الخصائص المتعلقة بتموضع مناطق المحتوى المختلفة. تسمح هذه المعلومات للتطبيق بحفظ حالة العرض في الملف، بحيث عند إعادة الفتح تكون الحالة كما كانت عندما تم حفظ العرض التقديمي آخر مرة.

تمت إضافة الطريقة [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) لتوفير إمكانية الوصول إلى خصائص العرض العادي للعرض التقديمي.  

تمت إضافة الواجهات [INormalViewProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties)، [INormalViewRestoredProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewRestoredProperties) ونسلها، وكذلك تعداد [SplitterBarStateType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/SplitterBarStateType) .

## **حول INormalViewProperties**

تمثل خصائص العرض العادي.

الطرق [getShowOutlineIcons](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) و [setShowOutlineIcons](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) تحدد ما إذا كان يجب على التطبيق إظهار الأيقونات عند عرض محتوى المخطط في أي من مناطق المحتوى في وضع العرض العادي.

الطرق [getSnapVerticalSplitter](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) و [setSnapVerticalSplitter](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) تحدد ما إذا كان يجب أن ينتقل المقسم العمودي إلى حالة مصغرة عندما تكون المنطقة الجانبية صغيرة بما فيه الكفاية.

الخاصية [getPreferSingleView](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) و [setPreferSingleView](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) تحدد ما إذا كان المستخدم يفضل رؤية منطقة محتوى واحدة تُملأ النافذة بالكامل بدلاً من العرض العادي القياسي الذي يضم ثلاث مناطق محتوى. إذا تم تمكينها، قد يختار التطبيق عرض إحدى مناطق المحتوى في النافذة بأكملها.

الطرق [getVerticalBarState](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) و [getHorizontalBarState](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) تحدد الحالة التي يجب أن يظهر فيها شريط المقسّم الأفقي أو العمودي. شريط المقسّم الأفقي يفصل الشريحة عن منطقة المحتوى أسفل الشريحة، وشريط المقسّم العمودي يفصل الشريحة عن منطقة المحتوى الجانبية. القيم الممكنة هي: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ar/java/com.aspose.slides/SplitterBarStateType#Minimized)، [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ar/java/com.aspose.slides/SplitterBarStateType#Maximized) و[SplitterBarStateType.Restored](https://reference.aspose.com/slides/ar/java/com.aspose.slides/SplitterBarStateType#Restored).

الطرق [getRestoredLeft](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) و [getRestoredTop](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) تحدد حجم منطقة الشريحة العلوية أو الجانبية في العرض العادي، عندما يتم تطبيق قيمة [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ar/java/com.aspose.slides/SplitterBarStateType#Restored) على [getVerticalBarState](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) و[getHorizontalBarState](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) على التوالي.

## **حول استعادة INormalViewProperties**

تحدد حجم منطقة الشريحة (العرض عندما تكون طفلاً لـ [getRestoredTop](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#getRestoredTop--)، الارتفاع عندما تكون طفلاً لـ [getRestoredLeft](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) في العرض العادي، عندما تكون المنطقة بحجم مستعاد متغيّر (ليس مصغرة ولا مكبرة).

الطريقة [getDimensionSize](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) تحدد حجم منطقة الشريحة (العرض عندما تكون طفلاً لـ restoredTop، الارتفاع عندما تكون طفلاً لـ restoredLeft).

الطريقة [getAutoAdjust](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) تحدد ما إذا كان يجب أن تعوّض منطقة المحتوى الجانبية عن الحجم الجديد عند تغيير حجم النافذة التي تحتوي العرض داخل التطبيق.

مثال أدناه يوضح كيفية الوصول إلى خصائص [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) لعرض تقديمي.

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

أصبح Aspose.Slides for Java يدعم الآن تعيين قيمة التكبير الافتراضية للعرض التقديمي بحيث يتم ضبط التكبير مسبقاً عند فتح العرض. يمكن تحقيق ذلك عن طريق تعيين [ViewProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ViewProperties) للعرض التقديمي. يمكن ضبط كلٍ من [getSlideViewProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) و[getNotesViewProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) برمجيًا. في هذا القسم، سنرى من خلال مثال كيفية تعيين [View Properties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ViewProperties) للـ [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation) في [Aspose.Slides](/slides/ar/).

{{% /alert %}} 

لضبط خصائص العرض، يرجى اتباع الخطوات التالية:

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation).
2. تعيين [View Properties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ViewProperties) للـ [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation).
3. كتابة العرض التقديمي كملف [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   في المثال أدناه، قمنا بتعيين قيمة التكبير لعرض الشريحة وكذلك عرض الملاحظات.

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

## **الأسئلة المتكررة**

### هل يمكنني تعيين إعدادات عرض مختلفة لأقسام مختلفة من العرض التقديمي؟

يتم تعريف [إعدادات العرض](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getViewProperties--) على مستوى العرض التقديمي ([العرض العادي](https://reference.aspose.com/slides/ar/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[عرض الشريحة](https://reference.aspose.com/slides/ar/java/com.aspose.slides/viewproperties/#getSlideViewProperties--))، وليس لكل قسم على حدة، لذا يتم تطبيق مجموعة واحدة من المعلمات على المستند بالكامل عند الفتح.

### هل يمكنني تحديد حالات عرض مسبقة لمستخدمين مختلفين؟

لا. تُحفظ الإعدادات في الملف وتُشارك بين جميع المستخدمين. قد تلتزم تطبيقات العرض بتفضيلات المستخدم، لكن الملف نفسه يحتوي على مجموعة واحدة من خصائص العرض.

### هل يمكنني إعداد قالب يحتوي على خصائص عرض محددة مسبقًا حتى تفتح العروض التقديمية الجديدة بنفس الطريقة؟

نعم. لأن [خصائص العرض](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getViewProperties--) تُخزن على مستوى العرض التقديمي، يمكنك تضمينها في قالب وإنشاء مستندات جديدة منه بنفس تكوين العرض الأولي.