---
title: "استرجاع وتحديث خصائص عرض العرض التقديمي على Android"
linktitle: "خصائص العرض"
type: docs
weight: 80
url: /ar/androidjava/presentation-view-properties/
keywords:
- "خصائص العرض"
- "العرض العادي"
- "محتوى المخطط"
- "أيقونات المخطط"
- "إقفال الفاصل العمودي"
- "العرض المفرد"
- "حالة الشريط"
- "حجم البُعد"
- "تعديل تلقائي"
- "تكبير افتراضي"
- PowerPoint
- OpenDocument
- "العرض التقديمي"
- Android
- Java
- Aspose.Slides
description: "اكتشف خصائص العرض في Aspose.Slides للـ Android عبر Java لتخصيص صيغ شرائح PPT و PPTX و ODP — ضبط التخطيطات ومستويات التكبير وإعدادات العرض."
---
## **المقدمة**

العرض العادي يتكون من ثلاث مناطق محتوى: الشريحة نفسها، منطقة محتوى جانبية، ومنطقة محتوى سفلية. الخصائص المتعلقة بموضع المناطق المختلفة للمحتوى. تسمح هذه المعلومات للتطبيق بحفظ حالة العرض في الملف، بحيث عند إعادة الفتح تكون الحالة نفسها كما كانت عندما تم حفظ العرض الأخير.

تم إضافة طريقة [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) لتوفير الوصول إلى خصائص العرض العادي للعرض التقديمي.

تم إضافة الواجهات [INormalViewProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewRestoredProperties) ونسلها، وتعداد [SplitterBarStateType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/SplitterBarStateType) enum have been added.

## **حول INormalViewProperties**

يمثل خصائص العرض العادي.

تحدد الطريقتان [getShowOutlineIcons](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) و[setShowOutlineIcons](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) ما إذا كان يجب على التطبيق عرض الأيقونات عند عرض محتوى المخطط في أي من مناطق المحتوى في وضع العرض العادي.

تحدد الطريقتان [getSnapVerticalSplitter](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) و[setSnapVerticalSplitter](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) ما إذا كان يجب أن يلتقط الفاصل العمودي إلى الحالة المصغرة عندما تكون المنطقة الجانبية صغيرة بما فيه الكفاية.

تحدد الخاصيتان [getPreferSingleView](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) و[setPreferSingleView](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) ما إذا كان المستخدم يفضل رؤية منطقة محتوى واحدة في نافذة كاملة بدلاً من العرض العادي القياسي الذي يحتوي على ثلاث مناطق محتوى. إذا تم تمكينها، قد يختار التطبيق عرض إحدى مناطق المحتوى في النافذة بأكملها.

تحدد الطريقتان [getVerticalBarState](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) و[getHorizontalBarState](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) الحالة التي يجب أن يُعرض بها شريط الفاصل الأفقي أو العمودي. يفصل شريط الفاصل الأفقي بين الشريحة ومنطقة المحتوى أسفل الشريحة، بينما يفصل شريط الفاصل العمودي بين الشريحة ومنطقة المحتوى الجانبية. القيم الممكنة هي: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) و[SplitterBarStateType.Restored](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

تحدد الطريقتان [getRestoredLeft](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) و[getRestoredTop](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) حجم المنطقة العليا أو الجانبية للشريحة في العرض العادي، عندما تكون القيمة [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/SplitterBarStateType#Restored) مُطبقة على [getVerticalBarState](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) و[getHorizontalBarState](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) وفقًا لذلك.

## **حول استعادة INormalViewProperties**

يحدد حجم منطقة الشريحة (العرض عندما تكون فرعًا لـ [getRestoredTop](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--)، الارتفاع عندما تكون فرعًا لـ [getRestoredLeft](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) في العرض العادي، عندما تكون المنطقة ذات حجم مستعاد متغير (ليس مصغرة ولا مكبرة).

تحدد الطريقة [getDimensionSize](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) حجم منطقة الشريحة (العرض عندما تكون فرعًا لـ restoredTop، الارتفاع عندما تكون فرعًا لـ restoredLeft).

تحدد الطريقة [getAutoAdjust](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) ما إذا كان يجب على حجم منطقة المحتوى الجانبية التعويض عن الحجم الجديد عند تغيير حجم النافذة التي تحتوي على العرض داخل التطبيق.

يُظهر المثال أدناه كيفية الوصول إلى خصائص [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) لعرض تقديمي.

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

أصبحت مكتبة Aspose.Slides for Android عبر Java الآن تدعم تعيين قيمة التكبير الافتراضية للعرض التقديمي بحيث يكون التكبير مضبوطًا بالفعل عند فتح العرض التقديمي. يمكن القيام بذلك عن طريق تعيين [ViewProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ViewProperties) لعرض تقديمي. يمكن تعيين كل من [getSlideViewProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) و[getNotesViewProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) برمجيًا. في هذا الموضوع، سنرى من خلال مثال كيفية تعيين [View Properties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ViewProperties) لـ [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation) في Aspose.Slides.

{{% /alert %}} 

لإعداد خصائص العرض، يرجى اتباع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation).
1. تعيين [View Properties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ViewProperties) لـ [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation).
1. كتابة العرض التقديمي كملف [PPTX](https://docs.fileformat.com/presentation/pptx/) . في المثال أدناه، قمنا بتعيين قيمة التكبير لعرض الشريحة وكذلك عرض الملاحظات.

```java
import com.aspose.slides.*;

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

## **تعيين تباعد الشبكة**

استخدم [Presentation.getViewProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getViewProperties--) للوصول إلى إعدادات العرض على مستوى العرض التقديمي. تقرأ وتغيير الفاصل الزمني للشبكة التحريرية الأساسية طرق [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--) و[IViewProperties.setGridSpacing](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) . ينطبق هذا الإعداد على كامل العرض التقديمي، وليس على شريحة فردية. يتم تحديد تباعد الشبكة بالنقاط، حيث أن 72 نقطة تساوي بوصة واحدة. استخدم قيمة موجبة، كما هو مطلوب في وثائق API.

المثال التالي يفتح ملف `demo.pptx` موجود، يطبع تباعد الشبكة الحالي، يضبط فاصلًا ربع بوصة، ويحفظ النتيجة.

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

الشبكة مختلفة عن [drawing guides](/slides/ar/androidjava/drawing-guides/). يتحكم تباعد الشبكة في فاصل منتظم، بينما الأدلة الرسومية هي خطوط محاذاة أفقية أو عمودية موضوعة بشكل فردي. إضافة أو نقل أو مسح الأدلة الرسومية لا يغيّر تباعد الشبكة.

كل من الشبكة والأدلة الرسومية هي مساعدات تحرير. لا يتم عرضها كمحتوى شريحة في PDF أو صور أو SVG أو عرض شرائح. تخزين تباعد الشبكة لا يضمن أن المحرر سيعرض الشبكة: اعتماد رؤيتها أيضًا على تفضيلات المشاهد أو المحرر.

## **الأسئلة المتكررة**

**لماذا لا تظهر الشبكة بعد إعادة فتح العرض التقديمي؟**

الملف يخزن تباعد الشبكة، لكن المحرر يتحكم فيما إذا كانت الشبكة معروضة. تحقق من إعدادات رؤية الشبكة في المحرر.

**هل يؤدي مسح الأدلة الرسومية إلى تغيير تباعد الشبكة؟**

لا. الأدلة الرسومية وتباعد الشبكة إعدادات مستقلة. مسح الأدلة يترك الفاصل المخزن للشبكة دون تغيير.

**هل يمكنني ضبط إعدادات عرض مختلفة لأقسام مختلفة من العرض التقديمي؟**

يتم تعريف [إعدادات العرض](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getViewProperties--) على مستوى العرض التقديمي ([Normal View](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--))، وليس لكل قسم، لذلك يتم تطبيق مجموعة واحدة من المعلمات على المستند بأكمله عند فتحه.

**هل يمكنني تعريف حالات عرض مختلفة مسبقًا لمستخدمين مختلفين؟**

لا. يتم تخزين الإعدادات في الملف وتُشارك. قد تلتزم تطبيقات المشاهدة بتفضيلات المستخدم، لكن الملف نفسه يحتوي على مجموعة واحدة فقط من خصائص العرض.

**هل يمكنني إعداد قالب بخصائص عرض مسبقة التعريف بحيث تفتح العروض الجديدة بنفس الطريقة؟**

نعم. لأن [خصائص العرض](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getViewProperties--) تُخزن على مستوى العرض التقديمي، يمكنك تضمينها في قالب وإنشاء مستندات جديدة منه بنفس تكوين العرض الأولي.