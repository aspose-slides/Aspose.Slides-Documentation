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
- تثبت المقسم العمودي
- عرض واحد
- حالة الشريط
- حجم البُعد
- ضبط تلقائي
- تكبير افتراضي
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "استخدم Aspose.Slides for Android عبر Java لتكوين تخطيط العرض العادي، وتكبير الشريحة والملاحظات، وتباعد الشبكة، ورؤية التعليقات في عروض PowerPoint التقديمية."
---
## **مقدمة**

في طريقة العرض العادية لبرنامج PowerPoint، تظهر الشريحة بين لوحة جانبية للصور المصغرة أو المخطط ولوحة الملاحظات أسفلها. Aspose.Slides for Android عبر Java يُظهر تفضيلات التحرير المحفوظة للعرض التقديمي من خلال [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--). تشمل هذه التفضيلات تخطيط اللوحات، مستويات التكبير، تباعد الشبكة، ورؤية التعليقات.

## **حول INormalViewProperties**

استخدم [getNormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNormalViewProperties--) للوصول إلى الواجهة [INormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/). تتحكم [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) فيما إذا كانت الأيقونات تظهر بجانب عناوين الشرائح في المخطط. تقوم [setSnapVerticalSplitter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setSnapVerticalSplitter-boolean-) بجعل اللوحة الجانبية تنكمش إلى حالتها المصغرة عندما يضيق المستخدم حجمها. تشير [setPreferSingleView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setPreferSingleView-boolean-) إلى تفضيل عرض لوحة واحدة في النافذة الكاملة.

تتحكم [setVerticalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setVerticalBarState-int-) في الفاصل بين اللوحة الجانبية والشريحة. تتحكم [setHorizontalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setHorizontalBarState-int-) في الفاصل أعلى لوحة الملاحظات. كلاهما يقبل قيمة من نوع [SplitterBarStateType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/splitterbarstatetype/) وهي `Minimized` أو `Maximized` أو `Restored`.

## **حول استعادة INormalViewProperties**

عند استعادة الفاصل، تُعيد [getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredLeft--) الحجم المحفوظ للوحة الجانبية وتُعيد [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) الحجم المحفوظ للمنطقة العلوية للشريحة. كلاهما يُظهر [INormalViewRestoredProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/). طريقة [setDimensionSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setDimensionSize-float-) تقبل نسبة مئوية من 0 إلى 100، وتتحكم [setAutoAdjust](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setAutoAdjust-boolean-) فيما إذا كان المُحرر يضبط الحجم عند تغيير حجم النافذة.

هذا المثال يُحدّث عرض تقديمي موجود. يستعيد الفاصل الأفقي، يضبط الحجم الذي تُعيده [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) إلى 80٪ مع تمكين الضبط التلقائي، ويكَبِّر الفاصل العمودي. كما يستدعي [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) لعرض الأيقونات في طريقة عرض المخطط.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    INormalViewProperties normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(SplitterBarStateType.Restored);
    normalView.setVerticalBarState(SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ضبط قيمة التكبير الافتراضية**

تخزن [getSlideViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getSlideViewProperties--) و [getNotesViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNotesViewProperties--) إعدادات تكبير مستقلة للمُحرر. لا تؤثر هذه الإعدادات على أبعاد الشريحة، أو تشغيل عرض الشرائح، أو دقة تصدير الصور.

يفتح هذا المثال عرض تقديمي موجود ويستدعي [setVariableScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setVariableScale-boolean-) لتلائم الشريحة مع نافذة التحرير. بالنسبة لصفحة الملاحظات، يُعطِّل الضبط التلقائي ويستدعي [setScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setScale-int-) لتعيين تكبير ثابت بنسبة 80٪.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ضبط تباعد الشبكة**

[setGridSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) يحدد المسافة بين خطوط الشبكة في جميع أنحاء العرض التقديمي. يقبل قيمة موجبة بالنقاط، مع 72 نقطة لكل بوصة. يطبع هذا المثال التباعد الحالي في عرض تقديمي موجود ويحفظ شبكة بربعة بوصات عن طريق ضبط الفاصل إلى 18 نقطة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18f);

    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تتكرر الشبكة على فاصل ثابت. [Drawing guides](/slides/ar/androidjava/drawing-guides/) تُعَلِّم المواضع الأفقية أو العمودية الفردية. كلاهما أدوات مساعدة في التحرير وتظهر فقط في المحررات التي تعرضها. لا تُظهر عروض الشرائح ولا تصدّر إلى PDF أو صور أو SVG.

## **إظهار أو إخفاء التعليقات عند فتح عرض تقديمي**

[setShowComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-) يخزن تفضيلاً يستخدمه المحررات المتوافقة عند فتح العرض التقديمي. لهذا المثال، إذا كان العرض التقديمي يحتوي على تعليقات، يطبع الإعداد الحالي ويحفظ نسخة مع إخفاء التعليقات. كما يستدعي [setLastView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-) مع [ViewType.SlideView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewtype/#SlideView) لتفتح النسخة في عرض الشريحة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("comments.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current comment visibility: " + viewProperties.getShowComments());

    viewProperties.setShowComments(NullableBool.False);
    viewProperties.setLastView(ViewType.SlideView);

    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

إخفاء التعليقات يحافظ على نصها، مؤلفيها، مواضعها، ردودها، وحالاتها. لتغيير التعليقات نفسها، راجع [Presentation Comments](/slides/ar/androidjava/presentation-comments/). تتحكم إعدادات التصدير فيما إذا كانت التعليقات تظهر في PDF أو HTML أو صور أو ملاحظات أو كتيبات.

## **الأسئلة المتكررة**

**لماذا تكون الشبكة مخفية عندما أقوم بإعادة فتح العرض التقديمي؟**

يخزن العرض التقديمي الفاصل الزمني للشبكة. لرؤية الشبكة، فعّل رؤية الشبكة في المحرر.

**هل تغيير دليل الرسم يؤثر على تباعد الشبكة؟**

لا. إضافة دليل أو تحريكه أو مسحه لا تغيّر الفاصل الزمني للشبكة.

**هل يمكن لأقسام مختلفة من العرض التقديمي أن تحتوي على إعدادات عرض مختلفة؟**

لا. [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--) يُطبق على كامل العرض التقديمي.

**هل يمكنني حفظ إعدادات عرض مختلفة لمستخدمين مختلفين؟**

الملف يخزن مجموعة واحدة من خصائص العرض للجميع. قد يطبّق المحرر تفضيلات محلية للمستخدم أيضًا.

**هل يمكنني حفظ إعدادات العرض في قالب؟**

نعم. العروض التقديمية المُنشأة من القالب تُورّث إعدادات العرض المحفوظة فيه.