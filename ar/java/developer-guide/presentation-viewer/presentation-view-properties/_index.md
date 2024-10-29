---
title: خصائص عرض التقديم
type: docs
url: /ar/java/presentation-view-properties/
---

{{% alert color="primary" %}} 

يتكون العرض العادي من ثلاث مناطق محتوى: الشريحة نفسها، منطقة محتوى جانبية، ومنطقة محتوى سفلية. تتعلق الخصائص بتحديد موضع مناطق المحتوى المختلفة. هذه المعلومات تسمح للتطبيق بحفظ حالة العرض في الملف، حتى عندما يتم إعادة فتحه تكون الحالة كما كانت عند آخر حفظ للتقديم.

تم إضافة طريقة [**IViewProperties.*getNormalViewProperties***](https://reference.aspose.com/slides/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) لتوفير الوصول إلى خصائص العرض العادي للتقديم. 

تمت إضافة الواجهات [**INormalViewProperties**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties)، [**INormalViewRestoredProperties**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewRestoredProperties) وسلالتها، بالإضافة إلى التعداد [**SplitterBarStateType**](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType).

{{% /alert %}} 


## **حول INormalViewProperties** #
تمثل خصائص العرض العادي.

تحدد طرق [**getShowOutlineIcons**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) و [**setShowOutlineIcons**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) ما إذا كان يجب على التطبيق عرض الرموز عند عرض محتوى المخطط في أي من مناطق المحتوى في وضع العرض العادي.

تحدد طرق [**getSnapVerticalSplitter**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) و [**setSnapVerticalSplitter**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) ما إذا كان يجب أن يتماشى الفاصل العمودي مع حالة مصغرة عندما تكون المنطقة الجانبية صغيرة بما فيه الكفاية.

تحدد خاصية [**getPreferSingleView**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) و [**setPreferSingleView**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) ما إذا كان المستخدم يفضل رؤية منطقة محتوى واحدة في نافذة كاملة بدلاً من العرض العادي القياسي مع ثلاث مناطق محتوى. إذا تم التمكين، قد يختار التطبيق عرض واحدة من مناطق المحتوى في النافذة بالكامل.

تحدد طرق [**getVerticalBarState**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) و [**getHorizontalBarState**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) الحالة التي يجب أن يظهر فيها شريط الفاصل الأفقي أو العمودي. يفصل شريط الفاصل الأفقي الشريحة عن منطقة المحتوى أسفل الشريحة، بينما يفصل شريط الفاصل العمودي الشريحة عن المنطقة المحتوى الجانبية. القيم الممكنة هي: [**SplitterBarStateType.Minimized**](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Minimized)، [**SplitterBarStateType.Maximized**](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Maximized) و [**SplitterBarStateType.Restored**](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Restored).

تحدد طرق [**getRestoredLeft**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) و [**getRestoredTop**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) حجم منطقة الشريحة العليا أو الجانبية من العرض العادي، عندما يتم تطبيق القيمة [**SplitterBarStateType.Restored**](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Restored) بالنسبة إلى [**getVerticalBarState**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) و [**getHorizontalBarState**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) على التوالي.


## **حول استعادة INormalViewProperties** 
تحدد حجم منطقة الشريحة (العرض عندما تكون طفلًا لـ [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredTop--)، والارتفاع عندما تكون طفلًا لـ [getRestoredLeft](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) من العرض العادي، عندما تكون المنطقة بحجم مستعاد متغير (لا مصغرة ولا م最大化). 

تحدد طريقة [**getDimensionSize**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) حجم منطقة الشريحة (العرض عندما تكون طفلًا من restoredTop، والارتفاع عندما تكون طفلًا من restoredLeft).

تحدد طريقة [**getAutoAdjust**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) ما إذا كان يجب أن تعوض حجم منطقة المحتوى الجانبية عن الحجم الجديد عند تغيير حجم النافذة التي تحتوي على العرض داخل التطبيق.

مثال موضح أدناه يبين كيفية الوصول إلى خصائص [**ViewProperties.getNormalViewProperties**](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) لتقديم.

```java
// إنشاء كائن تقديم يمثل ملف تقديم
Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // استعادة خصائص العرض للتقديم
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

يدعم Aspose.Slides لـ Java الآن تعيين قيمة التكبير الافتراضية للتقديم بحيث عند فتح التقديم، يتم تعيين التكبير مسبقًا. يمكن القيام بذلك عن طريق تعيين [ViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties) للتقديم. يمكن تعيين [getSlideViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) وكذلك [getNotesViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) برمجيًا. في هذا الموضوع، سنرى مع مثال كيفية تعيين [View Properties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties) لـ [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) في [Aspose.Slides](/slides/ar/).

{{% /alert %}} 

لتعيين خصائص العرض. يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
2. تعيين [View Properties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties) للتقديم.
3. كتابة التقديم كملف [PPTX ](https://docs.fileformat.com/presentation/pptx/)كالذي تم تقديمه أدناه، حيث قمنا بتعيين قيمة التكبير لعرض الشريحة وكذلك لعرض الملاحظات.

```java
// إنشاء كائن تقديم يمثل ملف تقديم
Presentation presentation = new Presentation();
try {
    // تعيين خصائص العرض للتقديم
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // قيمة التكبير بالنسبة المئوية لعرض الشريحة
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // قيمة التكبير بالنسبة المئوية لعرض الملاحظات 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```