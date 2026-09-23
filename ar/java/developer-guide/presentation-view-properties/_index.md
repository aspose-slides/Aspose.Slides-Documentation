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
- تثبيت القاطع العمودي
- العرض الفردي
- حالة الشريط
- حجم البُعد
- ضبط تلقائي
- التكبير الافتراضي
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "اكتشف خصائص العرض في Aspose.Slides for Java لتخصيص صيغ شرائح PPT و PPTX و ODP — تعديل التخطيطات ومستويات التكبير وإعدادات العرض."
---
## **المقدمة**

يتكون العرض العادي من ثلاث مناطق محتوى: الشريحة نفسها، ومنطقة محتوى جانبية، ومنطقة محتوى سفلية. الخصائص المتعلقة بموضع مناطق المحتوى المختلفة. تسمح هذه المعلومات للتطبيق بحفظ حالة العرض في الملف، حتى عندما يُعاد فتحه يكون العرض في نفس الحالة التي كان عليها عند حفظ العرض آخر مرة.

تم إضافة الطريقة [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) لتوفير الوصول إلى خصائص العرض العادي للعرض التقديمي.

تم إضافة الواجهات [INormalViewProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties)، [INormalViewRestoredProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewRestoredProperties) وسلفاتها، وكذلك تعداد [SplitterBarStateType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/SplitterBarStateType).

## **حول INormalViewProperties**

يمثل خصائص العرض العادي.

الطريقة [getShowOutlineIcons](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) والطريقة [setShowOutlineIcons](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) تحددان ما إذا كان يجب على التطبيق إظهار أيقونات عندما يتم عرض محتوى المخطط في أي من مناطق المحتوى في وضع العرض العادي.

الطريقة [getSnapVerticalSplitter](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) والطريقة [setSnapVerticalSplitter](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) تحددان ما إذا كان يجب أن يلتقط القاطع العمودي إلى حالة مصغرة عندما تكون المنطقة الجانبية صغيرة بما فيه الكفاية.

الخاصية [getPreferSingleView](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) والطريقة [setPreferSingleView](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) تحددان ما إذا كان المستخدم يفضل رؤية منطقة محتوى واحدة كاملة النافذة بدلاً من العرض العادي القياسي الذي يتضمن ثلاث مناطق محتوى. إذا تم تمكينها، قد يختار التطبيق عرض إحدى مناطق المحتوى في النافذة بأكملها.

الطريقة [getVerticalBarState](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) والطريقة [getHorizontalBarState](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) تحددان الحالة التي يجب أن يظهر فيها شريط القاطع الأفقي أو العمودي. يفصل شريط القاطع الأفقي الشريحة عن منطقة المحتوى أسفل الشريحة، ويفصل شريط القاطع العمودي الشريحة عن منطقة المحتوى الجانبية. القيم المحتملة هي: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ar/java/com.aspose.slides/SplitterBarStateType#Minimized)، [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ar/java/com.aspose.slides/SplitterBarStateType#Maximized) و[SplitterBarStateType.Restored](https://reference.aspose.com/slides/ar/java/com.aspose.slides/SplitterBarStateType#Restored).

الطريقة [getRestoredLeft](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) والطريقة [getRestoredTop](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) تحددان حجم المنطقة العلوية أو الجانبية في العرض العادي عندما يتم تطبيق القيمة [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ar/java/com.aspose.slides/SplitterBarStateType#Restored) على [getVerticalBarState](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) و[getHorizontalBarState](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--).

## **حول استعادة INormalViewProperties**

تحدد حجم منطقة الشريحة (العرض عندما تكون طفلاً لـ [getRestoredTop](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#getRestoredTop--)، الارتفاع عندما تكون طفلاً لـ [getRestoredLeft](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) في العرض العادي، عندما تكون المنطقة ذات حجم مستعاد متغير (ليس مصغرة ولا مكبرة).

الطريقة [getDimensionSize](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) تحدد حجم منطقة الشريحة (العرض عندما تكون طفلاً لـ restoredTop، الارتفاع عندما تكون طفلاً لـ restoredLeft).

الطريقة [getAutoAdjust](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) تحدد ما إذا كان يجب على منطقة المحتوى الجانبية التعويض عن الحجم الجديد عند تعديل حجم النافذة التي تحتوي على العرض داخل التطبيق.

يوضح المثال أدناه كيف يمكن الوصول إلى خصائص [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) لعرض تقديمي.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // استعادة خصائص عرض العرض التقديمي
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

يدعم Aspose.Slides for Java الآن تعيين قيمة التكبير الافتراضية للعرض التقديمي بحيث يتم تعيين التكبير بالفعل عند فتح العرض. يمكن القيام بذلك عن طريق تعيين [ViewProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ViewProperties) للعرض التقديمي. يمكن ضبط كل من [getSlideViewProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) و[getNotesViewProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) برمجياً. في هذا القسم، سنرى مثالاً يوضح كيفية تعيين [View Properties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ViewProperties) لـ [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation) في Aspose.Slides.

{{% /alert %}} 

لضبط خصائص العرض، يرجى اتباع الخطوات أدناه:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation).
1. تعيين [View Properties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ViewProperties) للـ [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation).
1. كتابة العرض التقديمي كملف [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   في المثال المرفق أدناه، قمنا بتعيين قيمة التكبير لكل من عرض الشريحة وعرض الملاحظات.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // تحديد خصائص عرض العرض التقديمي
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // قيمة التكبير بالنسب المئوية لعرض الشريحة
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // قيمة التكبير بالنسب المئوية لعرض الملاحظات 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تعيين تباعد الشبكة**

استخدم [Presentation.getViewProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getViewProperties--) للوصول إلى إعدادات العرض على مستوى العرض التقديمي. تُقرأ أو تُغيّر الطرق [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iviewproperties/#getGridSpacing--) و[IViewProperties.setGridSpacing](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) الفاصل الزمني للشبكة التحريرية الأساسية. يُطبق هذا الإعداد على كامل العرض التقديمي، وليس على شريحة فردية. يُحدد تباعد الشبكة بالنقاط، حيث أن 72 نقطة تساوي بوصة واحدة. استخدم قيمة موجبة، كما هو مطلوب في وثائق API.

المثال التالي يفتح ملف `demo.pptx` الموجود مسبقاً، يطبع تباعد الشبكة الحالي، يحدد فاصل ربع بوصة، ثم يحفظ النتيجة.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("demo.pptx");
try {
    float gridSpacing = presentation.getViewProperties().getGridSpacing();
    System.out.println("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18f);
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

الشبكة تختلف عن [drawing guides](/slides/ar/java/drawing-guides/). يتحكم تباعد الشبكة في فاصل منتظم، بينما تكون خطوط الإرشاد رسومية موضوعة بشكل فردي أفقياً أو رأسياً. إضافة أو نقل أو مسح خطوط الإرشاد لا يغيّر تباعد الشبكة.

كل من الشبكة وخطوط الإرشاد تُعدّ أدوات تحرير. لا يتم عرضها كمحتوى شريحة في ملفات PDF أو الصور أو SVG أو أثناء عرض الشرائح. تخزين تباعد الشبكة لا يضمن أن يعرض المحرر الشبكة: يعتمد ظهورها أيضاً على تفضيلات المشاهد أو المحرر.

## **إظهار أو إخفاء التعليقات عند فتح عرض تقديمي**

استخدم [Presentation.getViewProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getViewProperties--) للوصول إلى إعدادات العرض على مستوى العرض التقديمي. استخدم [IViewProperties.getShowComments](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iviewproperties/#getShowComments--) و[IViewProperties.setShowComments](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iviewproperties/#setShowComments-byte-) لقراءة أو تعديل التفضيل المخزن بشأن ما إذا كان يجب إظهار التعليقات عند فتح العرض في PowerPoint أو محرر متوافق آخر.

هذا الإعداد يتحكم فقط في تفضيل العرض المخزن. لا يضيف أو يزيل أو يحرر أو يحل التعليقات. إخفاء التعليقات يحافظ على محتواها ومؤلفيها ومواقعها والردود والحالات. راجع [Presentation Comments](/slides/ar/java/presentation-comments/) للعمليات التي تغير التعليقات نفسها.

المثال التالي يتطلب ملف `comments.pptx` موجود مسبقاً يحتوي على تعليقات. يطبع إعداد الرؤية الحالي، يطلب إخفاء التعليقات، ثم يحفظ ملف PPTX جديد دون إزالة أي تعليقات. كما يستخدم [IViewProperties.setLastView](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iviewproperties/#setLastView-int-) مع [ViewType.SlideView](https://reference.aspose.com/slides/ar/java/com.aspose.slides/viewtype/#SlideView) لتكوين عرض التحرير الأولي إلى جانب رؤية التعليقات.

```java
import com.aspose.slides.NullableBool;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation("comments.pptx");
try {
    byte showComments = presentation.getViewProperties().getShowComments();
    System.out.println("Current comment visibility: " + showComments);

    presentation.getViewProperties().setShowComments(NullableBool.False);
    presentation.getViewProperties().setLastView(ViewType.SlideView);
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

هذا الإعداد لا يحدّد ما إذا كانت التعليقات تُدرج في تصديرات PDF أو HTML أو صورة أو ملاحظات أو كتيّب. اضبط خيارات التصدير الخاصة بكل تنسيق على حدة.

## **الأسئلة المتكررة**

**لماذا لا تكون الشبكة مرئية بعد إعادة فتح العرض التقديمي؟**

الملف يخزن تباعد الشبكة، لكن المحرر هو من يتحكم في ما إذا كانت الشبكة تُعرض. تحقق من إعدادات ظهور الشبكة في المحرر.

**هل يؤثر مسح خطوط الإرشاد على تباعد الشبكة؟**

لا. خطوط الإرشاد وتباعد الشبكة إعدادات مستقلة. مسح الخطوط لا يغيّر الفاصل المخزن للشبكة.

**هل يمكنني ضبط إعدادات عرض مختلفة لأقسام مختلفة من العرض التقديمي؟**

إعدادات العرض ([View settings](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getViewProperties--)) تُعرّف على مستوى العرض التقديمي ([Normal View](https://reference.aspose.com/slides/ar/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/ar/java/com.aspose.slides/viewproperties/#getSlideViewProperties--))، وليس لكل قسم، لذا مجموعة واحدة من المعايير تُطبق على المستند بأكمله عند الفتح.

**هل يمكنني تعريف حالات عرض مختلفة لمستخدمين مختلفين مسبقاً؟**

لا. تُخزن الإعدادات في الملف وتُشارك بين جميع المستخدمين. قد تحترم التطبيقات التي تعرض الملف تفضيلات المستخدم، لكن الملف نفسه يحتوي على مجموعة واحدة من خصائص العرض.

**هل يمكنني إعداد قالب يحتوي على خصائص عرض مسبقة بحيث تفتح العروض الجديدة بنفس الطريقة؟**

نعم. بما أن [view properties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getViewProperties--) تُخزن على مستوى العرض التقديمي، يمكنك تضمينها في قالب وإنشاء مستندات جديدة منه مع تكوين عرض أولي متماثل.