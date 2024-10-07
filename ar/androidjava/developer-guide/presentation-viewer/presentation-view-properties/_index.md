---
title: خصائص عرض العرض
type: docs
url: /androidjava/presentation-view-properties/
---

{{% alert color="primary" %}} 

يتكون العرض العادي من ثلاثة مناطق محتوى: الشريحة نفسها، ومنطقة محتوى جانبية، ومنطقة محتوى سفلية. الخصائص المتعلقة بتحديد مواقع المناطق المختلفة للمحتوى. هذه المعلومات تسمح للتطبيق بحفظ حالة العرض الخاصة به في الملف، بحيث عند إعادة الفتح، يكون العرض في نفس الحالة التي تم حفظ العرض بها آخر مرة.

تمت إضافة الطريقة [**IViewProperties.*getNormalViewProperties***](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) لتوفير الوصول إلى خصائص العرض العادي للعرض. 

تمت إضافة واجهات [**INormalViewProperties**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties)، [**INormalViewRestoredProperties**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties) وسلاسلها، والتعداد [**SplitterBarStateType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType).

{{% /alert %}} 


## **حول INormalViewProperties** #
يمثل خصائص العرض العادي.

تحدد الطرق [**getShowOutlineIcons**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) و [**setShowOutlineIcons**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) ما إذا كان ينبغي على التطبيق عرض الأيقونات عند عرض محتوى التخطيط في أي من مناطق محتوى وضع العرض العادي.

تحدد الطرق [**getSnapVerticalSplitter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) و [**setSnapVerticalSplitter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) ما إذا كان ينبغي أن ينغلق الفاصل العمودي في حالة مصغرة عندما تكون المنطقة الجانبية صغيرة بما يكفي.

تحدد الخاصية [**getPreferSingleView**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) و [**setPreferSingleView**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) ما إذا كان المستخدم يفضل رؤية منطقة محتوى واحدة بكامل نافذة العرض بدلاً من العرض العادي القياسي مع ثلاث مناطق محتوى. إذا تم تفعيله، قد يختار التطبيق عرض أحد مناطق المحتوى في كامل النافذة.

تحدد الطرق [**getVerticalBarState**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) و [**getHorizontalBarState**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) الحالة التي يجب أن يُظهر فيها شريط الفاصل الأفقي أو العمودي. يفصل شريط الفاصل الأفقي الشريحة عن منطقة المحتوى الموجودة أسفل الشريحة، بينما يفصل شريط الفاصل العمودي الشريحة عن منطقة المحتوى الجانبية. القيم الممكنة هي: [**SplitterBarStateType.Minimized**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Minimized)، [**SplitterBarStateType.Maximized**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) و [**SplitterBarStateType.Restored**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

تحدد الطرق [**getRestoredLeft**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) و [**getRestoredTop**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) حجم المنطقة العلوية أو الجانبية للشريحة في العرض العادي، عندما يتم تطبيق القيمة [**SplitterBarStateType.Restored**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Restored) على [**getVerticalBarState**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) و [**getHorizontalBarState**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) وفقًا لذلك.


## **حول استعادة INormalViewProperties** 
تحدد حجم منطقة الشريحة (العرض عندما تكون طفلاً من [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--)، الارتفاع عندما تكون طفلاً من [getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) في العرض العادي، عندما تكون المنطقة بحجم مستعاد متغير (لا مصغر ولا مكبر). 

تحدد الطريقة [**getDimensionSize**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) حجم منطقة الشريحة (العرض عندما تكون طفلاً من restoredTop، الارتفاع عندما تكون طفلاً من restoredLeft).

تحدد الطريقة [**getAutoAdjust**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) ما إذا كان ينبغي أن يعوض حجم منطقة المحتوى الجانبية عن الحجم الجديد عند تغيير حجم النافذة التي تحتوي على العرض داخل التطبيق.

يوضح المثال أدناه كيف يمكن الوصول إلى خصائص [**ViewProperties.getNormalViewProperties**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) لعرض.

```java
// إنشاء كائن Presentation يمثل ملف عرض
Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // استعادة خصائص عرض العرض
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

يدعم Aspose.Slides لـ Android عبر Java الآن تعيين قيمة التكبير الافتراضية للعرض بحيث عند فتح العرض، يتم تعيين التكبير مسبقًا. يمكن القيام بذلك عن طريق تعيين [ViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties) لعرض. يمكن أيضًا تعيين [getSlideViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) بالإضافة إلى [getNotesViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) برمجيًا. في هذا الموضوع، سنرى مع مثال كيفية تعيين [View Properties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties) لـ [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) في [Aspose.Slides](/slides/).

{{% /alert %}} 

لإعداد خصائص العرض. يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. تعيين [View Properties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties) لـ [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. كتابة العرض كملف [PPTX ](https://docs.fileformat.com/presentation/pptx/).
   في المثال المعطى أدناه، قمنا بتعيين قيمة التكبير لعرض الشريحة وعرض الملاحظات.

```java
// إنشاء كائن Presentation يمثل ملف عرض
Presentation presentation = new Presentation();
try {
    // تعيين خصائص العرض لعرض
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // قيمة التكبير بالنسب المئوية لعرض الشريحة
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // قيمة التكبير بالنسب المئوية لعرض الملاحظات 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```