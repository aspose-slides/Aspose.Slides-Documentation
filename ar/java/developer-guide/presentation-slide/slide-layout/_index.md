---
title: تطبيق أو تغيير تخطيطات الشرائح في Java
linktitle: تخطيط الشريحة
type: docs
weight: 60
url: /ar/java/slide-layout/
keywords:
- تخطيط الشريحة
- تخطيط المحتوى
- عنصر نائب
- تصميم العرض
- تصميم الشريحة
- تخطيط غير مستخدم
- إظهار التذييل
- شريحة عنوان
- عنوان ومحتوى
- عنوان القسم
- محتوى مزدوج
- مقارنة
- عنوان فقط
- تخطيط فارغ
- محتوى مع تسمية
- صورة مع تسمية
- عنوان ونص عمودي
- عنوان عمودي ونص
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "تطبيق وإنشاء وتعديل تخطيطات الشرائح في Aspose.Slides للـ Java، وإضافة العناصر النائبة، وإزالة التخطيطات غير المستخدمة، والتحكم في إظهار التذييل."
---
## **نظرة عامة**

يحدد تخطيط الشريحة مواضع وتنسيق العناصر النائبة مثل العناوين والنصوص والصور والمخططات والجداول. يوفّر تطبيق التخطيط هيكلًا ثابتًا للشرائح مع السماح لكل شريحة باحتواء محتواها الخاص.

أكثر التخطيطات شيوعًا هي:

- **Title Slide**: يحتوي على عناصر نائب للعنوان والعنوان الفرعي.
- **Title and Content**: يحتوي على عنصر نائب للعنوان وعنصر نائب عام للمحتوى.
- **Blank**: لا يحتوي على عناصر نائب للمحتوى وهو مفيد عندما يتم وضع كل شكل يدويًا.

## **فهم وراثة التخطيط**

للعرض التقديمي ثلاث مستويات ذات صلة:

1. A [master slide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterslide/) تحدد السمة، التنسيقات المشتركة، الخلفيات، والكائنات العامة.
2. A [layout slide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutslide/) تنتمي إلى master وتحدد ترتيبًا معينًا للعناصر النائبة.
3. A [normal slide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islide/) تستخدم تخطيطًا واحدًا وتخزن المحتوى المدخل لتلك الشريحة.

تورث الشريحة العادية السمة والتنسيق من التخطيط الخاص بها، ويورث التخطيط من الـ master. أي قيمة تُحدَّد مباشرةً على الشريحة العادية تتجاوز القيمة الموروثة في ذلك المستوى. عند إنشاء شريحة عادية، تُنشَأ أشكال العناصر النائبة من التخطيط المختار، بينما المحتوى المدخل في تلك العناصر النائبة يخص الشريحة العادية.

أضف العناصر النائبة المطلوبة إلى التخطيط قبل إنشاء الشرائح منه. إضافة عنصر نائب آخر إلى تخطيط لاحقًا لا يُضيف تلقائيًا شكل عنصر نائب مطابق إلى الشرائح العادية الموجودة.

لهذا الارتباط نتيجتان مهمتان:

- تعديل التنسيق الموروث أو هندسة العناصر النائبة الموجودة في تخطيط ما يمكن أن يُحدِّث كل شريحة تعتمد عليه. قبل تحرير تخطيط مُستَخدَم بالفعل، تفقد الشرائح التابعة له وراجع العرض الناتج.
- لا يمكن حذف تخطيط لا يزال مستخدمًا في شريحة. أعد تعيين الشرائح التابعة إليه إلى تخطيط آخر أولًا، أو احذف فقط التخطيطات غير المستخدمة.

لمزيد من المعلومات حول المستوى الأعلى من هذه الشجرة، راجع [Slide Master](/slides/ar/java/slide-master/).

لإخفاء الشعارات أو الأشكال الزخرفية الموروثة من الـ master على شريحة واحدة أو عبر تخطيط مشترك، انظر [Control the Visibility of Master Graphics](/slides/ar/java/slide-master/). يوضح المثال مقارنة بين شريحتين تستخدمان نفس الـ master.

## **اختيار وتطبيق تخطيط الشريحة**

استخدم نوع التخطيط عندما يتبع العرض تعريفات تخطيط PowerPoint القياسية. أسماء التخطيطات قابلة للتحرير من قبل المستخدم ويمكن تعريبها، لذا فإن الاختيار القائم على الاسم أقل موثوقية ما لم تتحكم في قالب المصدر.

المثال التالي يبحث عن **Title and Content** في الـ master الأول. إذا كان ذلك التخطيط غير متوفر، يرجع بشكل صريح إلى **Blank**. الفحص الثاني للـ null ضروري لأن العرض قد يحتوي على تخطيطات مخصصة فقط. بعد ذلك يتم تطبيق التخطيط المختار على الشريحة العادية الأولى عبر طريقة [ISlide.setLayoutSlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) .

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide targetLayout = layoutSlides.getByType(SlideLayoutType.TitleAndObject);

    if (targetLayout == null) {
        targetLayout = layoutSlides.getByType(SlideLayoutType.Blank);
    }

    if (targetLayout == null) {
        throw new IllegalStateException("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تغيير تخطيط الشريحة لا يحذف الأشكال العادية المضافة مباشرةً إلى الشريحة. مع ذلك، قد تتغير مواضع العناصر النائبة، التنسيق الموروث، والارتباط بين العناصر النائبة الموجودة والتخطيط الجديد، لذا تفقد النتيجة عند التحويل بين تخطيطات مختلفة اختلافًا كبيرًا.

## **إضافة تخطيط شريحة**

الاختيار والإنشاء عمليتان منفصلتان. المثال السابق يختار تخطيطًا موجودًا؛ لا يُنشئ واحدًا. لإنشاء تخطيط، استدعِ طريقة [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) على مجموعة تخطيطات الـ master المستهدف.

المثال التالي يضيف دائمًا تخطيطًا جديدًا **Title and Content** باسم `Report Title and Content`، ثم يضيف شريحة عادية تستند إليه. يجب أن تكون أسماء التخطيطات فريدة داخل المجموعة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide reportLayout = masterSlide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

أضف تخطيطًا فقط عندما يحتاج القالب فعليًا إلى بنية قابلة لإعادة الاستخدام. إذا كان هناك تخطيط مناسب موجود بالفعل، اختره واستخدمه بدلاً من إنشاء نسخة مكررة.

## **إضافة عناصر نائب إلى تخطيط الشريحة**

توفر طريقة [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) كائنًا من نوع [ILayoutPlaceholderManager](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutplaceholdermanager/) لإضافة أشكال عناصر نائب إلى التخطيط.

| عنصر نائب PowerPoint | `ILayoutPlaceholderManager` Method |
| -------------------- | ---------------------------------- |
| ![Content](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Content (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Text](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Text (Vertical)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Picture](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Chart](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Table](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Media](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Online Image](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

المثال التالي يتحقق من وجود التخطيط **Blank**، يضيف أربعة عناصر نائب إليه، ثم ينشئ شريحة عادية تستخدم التخطيط المعدل. الترتيب مقصود: تُضاف العناصر النائبة قبل إنشاء الشريحة العادية، حتى يتمكن Aspose.Slides من توليد أشكال العناصر النائبة المقابلة على تلك الشريحة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayout == null) {
        throw new IllegalStateException("The presentation does not contain a Blank layout slide.");
    }

    ILayoutPlaceholderManager placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
تغيير التنسيق الموروث أو هندسة العناصر النائبة الموجودة في التخطيط قد يؤثر على الشرائح التابعة. العنصر النائب المضاف حديثًا لا يُضاف تلقائيًا إلى الشرائح العادية القائمة. جرّب تغييرات التخطيط على نسخة من العرض وفحص كل شريحة تابعة.
{{% /alert %}}

## **إزالة تخطيطات الشرائح غير المستخدمة**

استخدم طريقة [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) لإزالة التخطيطات التي لا تُشير إليها أي شريحة عادية. تُبقي الطريقة التخطيطات التي لا تزال قيد الاستخدام كما هي.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

لإزالة تخطيط محدد، استخدم أولًا طريقة [hasDependingSlides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutslide/#hasDependingSlides--) أو [getDependingSlides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) الخاصة به. أعد تعيين أي شرائح تابعة قبل استدعاء [ILayoutSlide.remove](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutslide/#remove--). محاولة حذف تخطيط مستخدم تُثير استثناءً من نوع [PptxEditException](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pptxeditexception/).

## **التحكم في ظهور تذييل الصفحة على تخطيط الشريحة**

يحتوي التخطيط على تذييل خاص به، وعناصر نائب لرقم الشريحة وتاريخ/وقت. استخدم طريقة [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) للتحكم في تلك العناصر النائبة لتخطيط واحد. هذا مفيد عندما، على سبيل المثال، يجب أن تُظهر تخطيطات المحتوى التذييل بينما لا تُظهر تخطيطات العناوين ذلك.

المثال التالي يختار تخطيطًا بأمان ويجعل عناصر تذييل الصفحة مرئية:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject);

    if (layoutSlide == null) {
        layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    }

    if (layoutSlide == null) {
        throw new IllegalStateException("The presentation does not contain a suitable layout slide.");
    }

    ILayoutSlideHeaderFooterManager headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **التحكم في ظهور تذييل الصفحة على الـ master وتخطيطاته الفرعية**

لتطبيق إعدادات تذييل موحدة عبر شجرة الـ master، استخدم طريقة [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterslide/#getHeaderFooterManager--) . طرق النشر في [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterslideheaderfootermanager/) تُطبّق على الـ master وتخطيطات الشرائح التابعة له وكذلك الشرائح العادية؛ لا تستهدف شريحة عادية واحدة فقط.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة المتكررة**

**ما الفرق بين الـ master slide وتخطيط الشريحة؟**

يقوم الـ master slide بتعريف سمة العرض والتنسيق المشترك. ينتمي تخطيط الشريحة إلى الـ master ويحدد ترتيبًا قابلاً لإعادة الاستخدام للعناصر النائبة. تستخدم الشرائح العادية تلك التخطيطات وتخزن محتوىً خاصًا بكل شريحة.

**هل يمكن نسخ تخطيط شريحة من عرض تقديمي إلى آخر؟**

نعم. أضف نسخة إلى مجموعة الوجهة باستخدام طريقة [addClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-). عند النسخ بين العروض، تحقق أيضًا من الخطوط، السمات، الصور، والموارد الأخرى المستخدمة في التخطيط الأصلي.

**ماذا يحدث إذا عدَّلت تخطيطًا قيد الاستخدام بالفعل؟**

تورّث الشرائح التابعة تغييرات التخطيط ما لم تقم بتجاوز التنسيق أو الكائنات المتأثرة محليًا. يمكن أن تتغيّر هندسة العناصر النائبة والتنسيق الموروث على العديد من الشرائح مرة واحدة. استخدم [getDependingSlides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) لتحديد الشرائح المتأثرة قبل تعديل التخطيط.

**ماذا يحدث إذا حذفت تخطيطًا لا يزال قيد الاستخدام؟**

ترمي Aspose.Slides استثناءً من نوع [PptxEditException](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pptxeditexception/). أعد تعيين الشرائح التابعة أولًا، أو استخدم [removeUnusedLayoutSlides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) لإزالة التخطيطات غير المشار إليها فقط.