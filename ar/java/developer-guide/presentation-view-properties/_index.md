---
title: "استخراج وتحديث خصائص عرض العرض التقديمي في جافا"
linktitle: "خصائص العرض"
type: docs
weight: 80
url: /ar/java/presentation-view-properties/
keywords:
- "خصائص العرض"
- "عرض عادي"
- "محتوى المخطط"
- "أيقونات المخطط"
- "تثبيت الفاصل الرأسي"
- "عرض واحد"
- "حالة الشريط"
- "حجم البعد"
- "تعديل تلقائي"
- "تكبير افتراضي"
- PowerPoint
- OpenDocument
- "عرض تقديمي"
- Java
- Aspose.Slides
description: "اكتشف خصائص العرض في Aspose.Slides للغة Java لتخصيص صيغ شرائح PPT و PPTX و ODP - تعديل التخطيطات ومستويات التكبير وإعدادات العرض."
---
## **مقدمة**

يتكون العرض العادي من ثلاث مناطق محتوى: الشريحة نفسها، ومنطقة محتوى جانبية، ومنطقة محتوى سفلية. الخصائص المتعلقة بموضع المناطق المختلفة للمحتوى. تسمح هذه المعلومات للتطبيق بحفظ حالة العرض إلى الملف، بحيث عند إعادة الفتح تكون الحالة نفسها كما كانت عند حفظ العرض التقديمي آخر مرة.

تمت إضافة الطريقة [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) لتوفير الوصول إلى خصائص العرض العادي للعرض التقديمي.  

تمت إضافة الواجهات [INormalViewProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewRestoredProperties) وما يرتبط بها من واجهات، بالإضافة إلى تعداد [SplitterBarStateType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/SplitterBarStateType).

## **حول INormalViewProperties**

تمثل خصائص العرض العادي.

تحدد الطرق [getShowOutlineIcons](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) و[setShowOutlineIcons](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) ما إذا كان يجب على التطبيق إظهار الرموز عند عرض محتوى المخطط في أي من مناطق المحتوى في وضع العرض العادي.

تحدد الطرق [getSnapVerticalSplitter](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) و[setSnapVerticalSplitter](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) ما إذا كان الفاصل الرأسي يجب أن ينتقل إلى حالة مصغرة عندما تكون المنطقة الجانبية صغيرة بما فيه الكفاية.

تحدد الخاصية [getPreferSingleView](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) و[setPreferSingleView](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) ما إذا كان المستخدم يفضل رؤية منطقة محتوى واحدة بكامل النافذة بدلاً من العرض العادي القياسي بثلاث مناطق محتوى. إذا تم تمكين ذلك، قد يختار التطبيق عرض واحدة من مناطق المحتوى في كامل النافذة.

تحدد الطرق [getVerticalBarState](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) و[getHorizontalBarState](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) الحالة التي يجب أن يظهر فيها شريط الفاصل الأفقي أو الرأسي. يفصل شريط الفاصل الأفقي الشريحة عن منطقة المحتوى أسفل الشريحة، بينما يفصل شريط الفاصل الرأسي الشريحة عن منطقة المحتوى الجانبية. القيم الممكنة هي: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ar/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ar/java/com.aspose.slides/SplitterBarStateType#Maximized) و[SplitterBarStateType.Restored](https://reference.aspose.com/slides/ar/java/com.aspose.slides/SplitterBarStateType#Restored).

تحدد الطرق [getRestoredLeft](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) و[getRestoredTop](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) حجم منطقة الشريحة العلوية أو الجانبية في العرض العادي، عندما يتم تطبيق قيمة [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ar/java/com.aspose.slides/SplitterBarStateType#Restored) على كل من [getVerticalBarState](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) و[getHorizontalBarState](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) على التوالي.

## **حول استعادة INormalViewProperties**

يحدد حجم منطقة الشريحة (العرض عندما تكون فرعًا لـ [getRestoredTop](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#getRestoredTop--)، والارتفاع عندما تكون فرعًا لـ [getRestoredLeft](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) في العرض العادي، عندما تكون المنطقة بحجم مستعاد متغير (ليس مصغّرًا ولا مكبرًا).

تحدد الطريقة [getDimensionSize](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) حجم منطقة الشريحة (العرض عندما تكون فرعًا لـ restoredTop، والارتفاع عندما تكون فرعًا لـ restoredLeft).

تحدد الطريقة [getAutoAdjust](https://reference.aspose.com/slides/ar/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) ما إذا كان يجب أن يعوض حجم منطقة المحتوى الجانبية عن الحجم الجديد عند تغيير حجم النافذة التي تحتوي على العرض داخل التطبيق.

يوضح المثال أدناه كيفية الوصول إلى خصائص [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) لعرض تقديمي.

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

يدعم Aspose.Slides للغة Java الآن تعيين قيمة التكبير الافتراضية للعرض التقديمي بحيث يتم تعيين التكبير عند فتح العرض التقديمي. يمكن القيام بذلك عن طريق تعيين [ViewProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ViewProperties) للعرض التقديمي. يمكن تعيين [getSlideViewProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) وكذلك [getNotesViewProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) برمجياً. في هذا الموضوع، سنرى من خلال مثال كيفية تعيين [View Properties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ViewProperties) لـ [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation) في Aspose.Slides.

{{% /alert %}} 

لتعيين خصائص العرض، يرجى اتباع الخطوات التالية:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation).
2. تعيين [View Properties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ViewProperties) للـ [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation).
3. حفظ العرض التقديمي كملف [PPTX](https://docs.fileformat.com/presentation/pptx/).
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

استخدم [Presentation.getViewProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getViewProperties--) للوصول إلى إعدادات العرض على مستوى العرض التقديمي. تقرأ أو تغير طرق [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iviewproperties/#getGridSpacing--) و[IViewProperties.setGridSpacing](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) الفاصل الزمني للشبكة التحريرية الأساسية. ينطبق هذا الإعداد على كامل العرض التقديمي، وليس على شريحة فردية. يُحدد تباعد الشبكة بالنقاط، حيث 72 نقطة تساوي بوصة واحدة. استخدم قيمة موجبة، كما هو مطلوب في وثائق API.

يفتح المثال التالي ملف `demo.pptx` الموجود، ويطبع تباعد الشبكة الحالي، ويضبط فاصل ربع بوصة، ثم يحفظ النتيجة.

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

الشبكة تختلف عن [drawing guides](/slides/ar/java/drawing-guides/). يتحكم تباعد الشبكة في فاصل منتظم، بينما تُعد الأدلة الرسومية خطوط محاذاة أفقية أو عمودية يتم وضعها بشكل منفرد. إضافة أو نقل أو مسح الأدلة الرسومية لا يغيّر تباعد الشبكة.

كل من الشبكة والأدلة الرسومية هي مساعدات تحرير. لا يتم تقديمها كمحتوى شريحة في PDF أو الصور أو SVG أو عرض الشرائح. تخزين تباعد الشبكة لا يضمن أن يعرضه المحرر: تعتمد رؤيته أيضًا على تفضيلات المشاهد أو المحرر.

## **الأسئلة المتكررة**

**لماذا لا تكون الشبكة مرئية بعد إعادة فتح العرض التقديمي؟**  
يخزن الملف تباعد الشبكة، لكن المحرر يتحكم فيما إذا كانت الشبكة تُعرض. تحقق من إعدادات رؤية الشبكة في المحرر.

**هل يغيّر مسح الأدلة الرسومية تباعد الشبكة؟**  
لا. الأدلة الرسومية وتباعد الشبكة إعدادات مستقلة. مسح الأدلة يترك الفاصل المخزن للشبكة دون تغيير.

**هل يمكنني تعيين إعدادات عرض مختلفة لأقسام مختلفة من العرض التقديمي؟**  
يتم تعريف [إعدادات العرض](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getViewProperties--) على مستوى العرض التقديمي ([Normal View](https://reference.aspose.com/slides/ar/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/ar/java/com.aspose.slides/viewproperties/#getSlideViewProperties--))، وليس لكل قسم، لذا يتم تطبيق مجموعة واحدة من المعلمات على المستند بأكمله عند فتحه.

**هل يمكنني تعريف حالات عرض مختلفة لمستخدمين مختلفين مسبقًا؟**  
لا. تُخزن الإعدادات في الملف وتُشارك. قد تحترم تطبيقات العرض تفضيلات المستخدم، لكن الملف نفسه يحتوي على مجموعة واحدة من خصائص العرض.

**هل يمكنني إعداد قالب بخصائص عرض مُعرفة مسبقًا بحيث تفتح العروض التقديمية الجديدة بنفس الطريقة؟**  
نعم. لأن [خصائص العرض](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getViewProperties--) تُخزن على مستوى العرض التقديمي، يمكنك تضمينها في قالب وإنشاء مستندات جديدة منه بنفس تكوين العرض الأولي.