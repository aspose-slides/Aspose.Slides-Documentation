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
- مقسم عمودي قابل للانقضاط
- عرض واحد
- حالة الشريط
- حجم البُعد
- ضبط تلقائي
- التكبير الافتراضي
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "استخدم Aspose.Slides للغة Java لتكوين تخطيط العرض العادي، وتكبير الشرائح والملاحظات، وتباعد الشبكة، ورؤية التعليقات في عروض PowerPoint التقديمية."
---
## **المقدمة**

في طريقة العرض العادية في PowerPoint، تظهر الشريحة بين لوحة جانبية للصور المصغرة أو المخطط ولوحة الملاحظات أسفلها. تُظهر مكتبة Aspose.Slides للغة Java تفضيلات التحرير المحفوظة للعرض من خلال [Presentation.getViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getViewProperties--). تشمل هذه التفضيلات تخطيط اللوحات، مستويات التكبير، تباعد الشبكة، ورؤية التعليقات.

## **حول INormalViewProperties**

استخدم [getNormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getNormalViewProperties--) للوصول إلى واجهة [INormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) يتحكم في ما إذا كانت الأيقونات تظهر بجوار عناوين الشرائح في المخطط. [setSnapVerticalSplitter](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setSnapVerticalSplitter-boolean-) يسمح للوحة الجانبية بالانقضاط إلى وضعها المصغر عندما يضيق المستخدم حجمها. [setPreferSingleView](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setPreferSingleView-boolean-) يشير إلى تفضيل عرض لوحة واحدة في النافذة الكاملة.

[setVerticalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setVerticalBarState-int-) يتحكم في الفاصل بين اللوحة الجانبية والشريحة. [setHorizontalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setHorizontalBarState-int-) يتحكم في الفاصل أعلى لوحة الملاحظات. كلاهما يقبل قيمة من نوع [SplitterBarStateType](https://reference.aspose.com/slides/java/com.aspose.slides/splitterbarstatetype/) وهي `Minimized` أو `Maximized` أو `Restored`.

## **حول استعادة INormalViewProperties**

عند استعادة الفاصل، يوفر [getRestoredLeft](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredLeft--) الحجم المحفوظ للوحة الجانبية و[getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredTop--) الحجم المحفوظ للمنطقة العليا من الشريحة. كلاهما يكشف عن [INormalViewRestoredProperties](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/). طريقة [setDimensionSize](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/#setDimensionSize-float-) تقبل نسبة مئوية من 0 إلى 100، و[setAutoAdjust](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/#setAutoAdjust-boolean-) يتحكم فيما إذا كان المحرر يضبط الحجم عند تعديل حجم النافذة.

هذا المثال يُحدّث عرضًا تقديميًا موجودًا. يستعيد الفاصل الأفقي، يعيّن الحجم الذي تُرجعه [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredTop--) إلى 80% مع تمكين الضبط التلقائي، ويكبر الفاصل العمودي. كما يستدعي [setShowOutlineIcons](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) لعرض الأيقونات في وضع المخطط.

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

## **تعيين قيمة التكبير الافتراضية**

يخزن [getSlideViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getSlideViewProperties--) و[getNotesViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getNotesViewProperties--) إعدادات تكبير مستقلة للمحرر. هذه الإعدادات لا تؤثر على أبعاد الشرائح أو تشغيل عرض الشرائح أو دقة تصدير الصور.

هذا المثال يفتح عرضًا تقديميًا موجودًا ويستدعي [setVariableScale](https://reference.aspose.com/slides/java/com.aspose.slides/icommonslideviewproperties/#setVariableScale-boolean-) لتناسب الشريحة مع نافذة التحرير. بالنسبة لصفحة الملاحظات، يعطل التحجيم التلقائي ويستدعي [setScale](https://reference.aspose.com/slides/java/com.aspose.slides/icommonslideviewproperties/#setScale-int-) لتعيين تكبير ثابت بنسبة 80%.

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

## **تعيين تباعد الشبكة**

[setGridSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) يحدد المسافة بين خطوط الشبكة التحريرية في جميع أنحاء العرض. يأخذ قيمة موجبة بالنقاط، حيث 72 نقطة في البوصة. هذا المثال يطبع التباعد الحالي في عرض تقديمي موجود ويحفظ شبكة بربع بوصة بتعيين الفاصل إلى 18 نقطة.

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

تتكرر الشبكة على فاصل ثابت. [إرشادات الرسم](/slides/ar/java/drawing-guides/) تُحدّد مواضع أفقية أو رأسية فردية. كلاهما أدوات مساعدة في التحرير وتظهر فقط في المحرّرات التي تعرضها. عروض الشرائح والتصدير إلى PDF أو صور أو SVG تتجاهلها.

## **إظهار أو إخفاء التعليقات عند فتح عرض تقديمي**

[setShowComments](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setShowComments-byte-) يخزن تفضيلًا يستخدمه المحرّرات المتوافقة عند فتح العرض. بالنسبة لعرض تقديمي موجود يحتوي على تعليقات، يطبع هذا المثال الإعداد الحالي ويحفظ نسخة مع إخفاء التعليقات. كما يستدعي [setLastView](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setLastView-int-) مع [ViewType.SlideView](https://reference.aspose.com/slides/java/com.aspose.slides/viewtype/#SlideView) حتى تُفتح النسخة في وضع الشريحة.

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

إخفاء التعليقات يحفظ نصها ومؤلفيها ومواقعها وردودها وحالاتها. لتغيير التعليقات نفسها، راجع [تعليقات العرض](/slides/ar/java/presentation-comments/). تتحكم إعدادات التصدير فيما إذا كانت التعليقات تظهر في PDF أو HTML أو صور أو ملاحظات أو ملخصات.

## **أسئلة شائعة**

**لماذا تُخفى الشبكة عند إعادة فتح العرض؟**

يقوم العرض بتخزين الفاصل الزمني للشبكة. لرؤية الشبكة، فعّل رؤية الشبكة في المحرر.

**هل يؤدي مسح إرشادات الرسم إلى تغيير تباعد الشبكة؟**

لا. إضافة أو نقل أو مسح دليل لا يغيّر الفاصل الزمني للشبكة.

**هل يمكن لأقسام مختلفة من العرض أن تكون لها إعدادات عرض مختلفة؟**

لا. [Presentation.getViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getViewProperties--) ينطبق على العرض بأكمله.

**هل يمكنني حفظ إعدادات عرض مختلفة لمستخدمين مختلفين؟**

يحفظ الملف مجموعة واحدة من خصائص العرض للجميع. قد يطبق المحرر أيضًا تفضيلات محلية للمستخدم.

**هل يمكنني حفظ إعدادات العرض في قالب؟**

نعم. العروض التي تُنشأ من القالب ترتثّ من إعدادات العرض المحفوظة فيه.