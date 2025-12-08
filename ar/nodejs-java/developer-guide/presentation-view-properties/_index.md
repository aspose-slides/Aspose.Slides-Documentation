---
title: خصائص عرض العرض التقديمي
type: docs
weight: 80
url: /ar/nodejs-java/presentation-view-properties/
keywords:
- خصائص العرض
- العرض العادي
- محتوى المخطط
- أيقونات المخطط
- التقاط المقسم العمودي
- العرض الفردي
- حالة الشريط
- حجم البُعد
- تعديل تلقائي
- التكبير الافتراضي
- PowerPoint
- عرض تقديمي
- Node.js
- Java
- Aspose.Slides لـ Node.js عبر Java
description: "إدارة خصائص عرض العروض التقديمية PowerPoint في JavaScript"
---

{{% alert color="primary" %}} 

العرض العادي يتكون من ثلاث مناطق محتوى: الشريحة نفسها، منطقة محتوى جانبية، ومنطقة محتوى سفلية. الخصائص المرتبطة بموضع مناطق المحتوى المختلفة تسمح للتطبيق بحفظ حالة العرض في الملف، بحيث عند إعادة الفتح تكون الحالة هي نفسها عندما تم حفظ العرض آخر مرة.

تم إضافة الطريقة [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) لتوفير الوصول إلى خصائص العرض العادي للعرض التقديمي.  

تم إضافة الفئات [NormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties)، [NormalViewRestoredProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewRestoredProperties) والورثة لها، بالإضافة إلى تعداد [SplitterBarStateType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SplitterBarStateType).  

{{% /alert %}} 

## **حول NormalViewProperties**

يمثل خصائص العرض العادي.

الطريقة [getShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) والطريقة [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) تحددان ما إذا كان ينبغي للتطبيق إظهار أيقونات المخطط عندما يتم عرض محتوى المخطط في أي من مناطق المحتوى في وضع العرض العادي.

الطريقة [getSnapVerticalSplitter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) والطريقة [setSnapVerticalSplitter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) تحددان ما إذا كان شريط القسام الرأسي يجب أن يلتقط إلى حالة مصغرة عندما تكون المنطقة الجانبية صغيرة بما يكفي.

الخاصية [getPreferSingleView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) والطريقة [setPreferSingleView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) تحددان ما إذا كان المستخدم يفضّل رؤية منطقة محتوى واحدة ممتدة على كامل النافذة بدلاً من العرض العادي القياسي الذي يحتوي على ثلاث مناطق محتوى. إذا تم تفعيلها، قد يختار التطبيق عرض إحدى مناطق المحتوى في النافذة بأكملها.

الطريقة [getVerticalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) والطريقة [getHorizontalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) تحددان الحالة التي يجب أن يُظهر فيها شريط القسام الأفقي أو الرأسي. الشريط القسامي الأفقي يفصل الشريحة عن منطقة المحتوى أسفل الشريحة، والشريط القسامي الرأسي يفصل الشريحة عن المنطقة الجانبية. القيم المحتملة هي: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SplitterBarStateType#Minimized)، [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) و[SplitterBarStateType.Restored](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

الطريقة [getRestoredLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) والطريقة [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) تحددان حجم المنطقة العلوية أو الجانبية من الشريحة في العرض العادي عندما يتم تطبيق قيمة [SplitterBarStateType.Restored](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SplitterBarStateType#Restored) على [getVerticalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) و[getHorizontalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) على التوالي.

## **حول Restoring NormalViewProperties** 

تحدد حجم منطقة الشريحة (العرض عندما تكون ابنًا لـ [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--)، الارتفاع عندما تكون ابنًا لـ [getRestoredLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) في العرض العادي عندما تكون المنطقة ذات حجم متغير مستعاد (ليس مصغرة ولا مكبرة).  

الطريقة [getDimensionSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) تحدد حجم منطقة الشريحة (العرض عندما تكون ابنًا لـ restoredTop، الارتفاع عندما تكون ابنًا لـ restoredLeft).  

الطريقة [getAutoAdjust](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) تحدد ما إذا كان حجم منطقة المحتوى الجانبية يجب أن يتعادل مع الحجم الجديد عند تغيير حجم النافذة التي تحتوي العرض داخل التطبيق.  

يظهر المثال أدناه كيف يمكنك الوصول إلى خصائص [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) لعرض تقديمي.
```javascript

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // استعادة خصائص العرض للعرض التقديمي
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **تعيين قيمة التكبير الافتراضية**

{{% alert color="primary" %}} 

أصبح Aspose.Slides for Node.js via Java يدعم الآن تعيين قيمة التكبير الافتراضية للعرض التقديمي بحيث يتم تعيين التكبير مسبقًا عند فتح العرض. يمكن فعل ذلك عن طريق تعيين [ViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties) للعرض التقديمي. يمكن تعيين كل من [getSlideViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) و[getNotesViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) برمجيًا. في هذا الموضوع، سنستعرض مثالًا يوضح كيفية تعيين [View Properties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties) للـ [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) في [Aspose.Slides](/slides/ar/).  

{{% /alert %}} 

لتعيين خصائص العرض، يرجى اتباع الخطوات التالية:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).  
1. تعيين [View Properties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties) للـ [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).  
1. حفظ العرض التقديمي كملف [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   في المثال الوارد أدناه، تم تعيين قيمة التكبير لكل من عرض الشريحة وعرض الملاحظات.  
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // تعيين خصائص العرض للعرض التقديمي
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // قيمة التكبير بالنسبة المئوية لعرض الشريحة
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // قيمة التكبير بالنسبة المئوية لعرض الملاحظات
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **FAQ**

**هل يمكنني تعيين إعدادات عرض مختلفة لأقسام مختلفة من العرض التقديمي؟**

تُعرّف إعدادات العرض على مستوى العرض التقديمي ([Normal View](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/))، وليس لكل قسم، لذا يتم تطبيق مجموعة واحدة من المعلمات على المستند بأكمله عند الفتح.

**هل يمكنني تحديد حالات عرض مختلفة لمستخدمين مختلفين؟**

لا. تُحفظ الإعدادات في الملف وتُشارك بين جميع المستخدمين. قد تلتزم تطبيقات العرض بتفضيلات المستخدم، لكن الملف نفسه يحتوي على مجموعة واحدة من خصائص العرض.

**هل يمكنني إعداد قالب يحتوي على خصائص عرض مسبقة التعريف بحيث تفتح العروض الجديدة بنفس الطريقة؟**

نعم. نظرًا لأن [view properties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getviewproperties/) تُخزن على مستوى العرض التقديمي، يمكنك تضمينها في قالب وإنشاء مستندات جديدة منه بنفس تكوين العرض الأولي.