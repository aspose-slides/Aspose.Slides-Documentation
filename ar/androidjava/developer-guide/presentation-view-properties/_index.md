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
- تثبيت القاطع العمودي
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
description: "اكتشف خصائص العرض في Aspose.Slides لمنصة Android عبر Java لتخصيص صيغ شرائح PPT، PPTX، و ODP—ضبط التخطيطات، مستويات التكبير، وإعدادات العرض."
---
## **مقدمة**

العرض العادي يتكون من ثلاث مناطق محتوى: الشريحة نفسها، ومنطقة محتوى جانبية، ومنطقة محتوى سفلية. الخصائص المتعلقة بتموضع المناطق المختلفة للمحتوى. تسمح هذه المعلومات للتطبيق بحفظ حالة العرض إلى الملف، بحيث عند إعادة الفتح تكون الحالة نفسها كما كان عليها العرض عندما تم حفظ العرض آخر مرة.

تم إضافة الطريقة [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) لتوفير الوصول إلى خصائص العرض العادي للعرض التقديمي. 

تم إضافة الواجهات [INormalViewProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewRestoredProperties) ونسخها الفرعية، بالإضافة إلى تعداد [SplitterBarStateType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/SplitterBarStateType) .

## **حول INormalViewProperties**

يمثل خصائص العرض العادي.

تحدد الطريقة [getShowOutlineIcons](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) والطريقة [setShowOutlineIcons](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) ما إذا كان يجب على التطبيق إظهار الأيقونات عند عرض محتوى المخطط في أي من مناطق المحتوى في وضع العرض العادي.

تحدد الطريقة [getSnapVerticalSplitter](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) والطريقة [setSnapVerticalSplitter](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) ما إذا كان المُقسِّم العمودي يجب أن يلتقط إلى حالة مصغرة عندما تكون المنطقة الجانبية صغيرة بما فيه الكفاية.

الخاصية [getPreferSingleView](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) و[setPreferSingleView](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean--) تحددان ما إذا كان المستخدم يفضِّل رؤية منطقة محتوى واحدة في نافذة كاملة بدلاً من العرض العادي القياسي بثلاث مناطق محتوى. إذا تم تمكينها، قد يختار التطبيق عرض إحدى مناطق المحتوى في كامل النافذة.

تحدد الطريقة [getVerticalBarState](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) والطريقة [getHorizontalBarState](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) الحالة التي يجب أن يُعرض فيها شريط التقسيم الأفقي أو العمودي. شريط التقسيم الأفقي يفصل الشريحة عن منطقة المحتوى أسفل الشريحة، وشريط التقسيم العمودي يفصل الشريحة عن منطقة المحتوى الجانبية. القيم المحتملة هي: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) و[SplitterBarStateType.Restored](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

تحدد الطريقة [getRestoredLeft](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) والطريقة [getRestoredTop](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) حجم منطقة الشريحة العلوية أو الجانبية في العرض العادي، عندما يتم تطبيق القيمة [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/SplitterBarStateType#Restored) على [getVerticalBarState](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) و[getHorizontalBarState](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) على التوالي.

## **حول استعادة INormalViewProperties**

يحدد حجم منطقة الشريحة (العرض عندما تكون تابعًا لـ [getRestoredTop](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), الارتفاع عندما تكون تابعًا لـ [getRestoredLeft](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) في العرض العادي، عندما تكون المنطقة بحجم مستعاد متغير (ليس مصغرًا ولا مكبرًا). 

الطريقة [getDimensionSize](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) تحدد حجم منطقة الشريحة (العرض عندما تكون تابعًا لـ restoredTop، الارتفاع عندما تكون تابعًا لـ restoredLeft).

الطريقة [getAutoAdjust](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) تحدد ما إذا كان يجب أن يعوض حجم منطقة المحتوى الجانبية عن الحجم الجديد عند تغيير حجم النافذة التي تحتوي على العرض داخل التطبيق.

في المثال أدناه يوضح كيفية الوصول إلى خصائص [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) لعرض تقديمي.

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

أصبحت Aspose.Slides لمنصة Android عبر Java تدعم الآن تعيين قيمة التكبير الافتراضية للعرض التقديمي بحيث يتم تعيين التكبير بالفعل عند فتح العرض. يمكن القيام بذلك عن طريق تعيين [ViewProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ViewProperties) للعرض التقديمي. يمكن تعيين كل من [getSlideViewProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) و[getNotesViewProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) برمجيًا. في هذا الموضوع، سنرى مع مثال كيفية تعيين [View Properties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ViewProperties) لـ [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation) في Aspose.Slides.

{{% /alert %}} 

لتعيين خصائص العرض، يرجى اتباع الخطوات التالية:

1. إنشاء مثْل من فئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation).
1. ضبط [View Properties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ViewProperties) لـ [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation).
1. حفظ العرض التقديمي كملف [PPTX](https://docs.fileformat.com/presentation/pptx/).
   في المثال أدناه، قمنا بتعيين قيمة التكبير لكل من عرض الشريحة وعرض الملاحظات.

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

استخدم [Presentation.getViewProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getViewProperties--) للوصول إلى إعدادات العرض على مستوى العرض التقديمي. تقرأ وتغير الطريقتان [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--) و[IViewProperties.setGridSpacing](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) الفاصل الزمني للشبكة التحريرية الأساسية. ينطبق هذا الإعداد على كامل العرض التقديمي، وليس على شريحة فردية. يتم تحديد تباعد الشبكة بالنقاط، حيث تساوي 72 نقطة بوصة واحدة. استخدم قيمة موجبة كما يتطلب توثيق API.

المثال التالي يفتح ملف `demo.pptx` موجود، يطبع تباعد الشبكة الحالي، يعيّن فاصلًا ربع بوصة، ويحفظ النتيجة.

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

الشبكة تختلف عن [drawing guides](/slides/ar/androidjava/drawing-guides/). يتحكم تباعد الشبكة في فاصل منتظم، بينما الأدلة الرسومية هي خطوط محاذاة أفقية أو رأسية يتم وضعها بشكل فردي. إضافة أو نقل أو حذف الأدلة الرسومية لا يغيّر تباعد الشبكة.

كلا من الشبكة والأدلة الرسومية هما أدوات مساعدة للتحرير. لا يتم عرضهما كمحتوى شريحة في PDF أو صور أو SVG أو عرض شرائح. تخزين تباعد الشبكة لا يضمن أن المتحرر سيعرض الشبكة؛ فالرؤية تعتمد also on the viewer or editor's preferences.

## **إظهار أو إخفاء التعليقات عند فتح العرض التقديمي**

استخدم [Presentation.getViewProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getViewProperties--) للوصول إلى إعدادات العرض على مستوى العرض التقديمي. استخدم [IViewProperties.getShowComments](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iviewproperties/#getShowComments--) و[IViewProperties.setShowComments](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-) لقراءة أو تغيير التفضيل المخزن ما إذا كان يجب إظهار التعليقات عند فتح العرض التقديمي في PowerPoint أو محرر متوافق آخر.

هذا الإعداد يتحكم فقط في تفضيل العرض المخزن. لا يضيف أو يزيل أو يحرر أو يحل التعليقات. إخفاء التعليقات يحافظ على محتواها ومؤلفيها ومواقعها وردودها وحالاتها. راجع [Presentation Comments](/slides/ar/androidjava/presentation-comments/) للعمليات التي تغير التعليقات نفسها.

المثال التالي يتطلب وجود ملف `comments.pptx` يحتوي على تعليقات. يطبع إعداد الرؤية الحالي، يطلب إخفاء التعليقات، ويحفظ ملف PPTX جديد دون إزالة أي تعليقات. كما يستخدم [IViewProperties.setLastView](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-) مع [ViewType.SlideView](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/viewtype/#SlideView) لتكوين العرض التحريري الأولي جنبًا إلى جنب مع رؤية التعليقات.

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

هذا الإعداد لا يحدد ما إذا كانت التعليقات تُدرج في تصديرات PDF أو HTML أو صورة أو ملاحظات أو كتيب. قم بتهيئة خيارات التصدير المحددة ذات الصلة بشكل منفصل.

## **الأسئلة الشائعة**

**لماذا لا تكون الشبكة مرئية بعد إعادة فتح العرض التقديمي؟**

الملف يخزن تباعد الشبكة، لكن المحرر يحدد ما إذا كانت الشبكة تُعرض. تحقق من إعدادات رؤية الشبكة في المحرر.

**هل يؤثر حذف الأدلة الرسومية على تباعد الشبكة؟**

لا. الأدلة الرسومية وتباعد الشبكة إعدادات مستقلة. حذف الأدلة لا يغيّر الفاصل المخزن للشبكة.

**هل يمكنني تعيين إعدادات عرض مختلفة لأقسام مختلفة من العرض التقديمي؟**

إعدادات العرض تُعرّف على مستوى العرض التقديمي ([Normal View](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), وليس لكل قسم، لذا يتم تطبيق مجموعة واحدة من المعاملات على المستند كاملًا عند فتحه.

**هل يمكنني تعريف حالات عرض مختلفة لمستخدمين مختلفين مسبقًا؟**

لا. الإعدادات مخزنة في الملف وتُشارك. قد تلتزم تطبيقات العرض بتفضيلات المستخدم، لكن الملف نفسه يحتوي على مجموعة واحدة من خصائص العرض.

**هل يمكنني إعداد قالب بخصائص عرض معرفة مسبقًا بحيث تفتح العروض التقديمية الجديدة بنفس الطريقة؟**

نعم. بما أن خصائص العرض تُخزن على مستوى العرض التقديمي، يمكنك تضمينها في قالب وإنشاء مستندات جديدة منه بنفس تكوين العرض الأولي.