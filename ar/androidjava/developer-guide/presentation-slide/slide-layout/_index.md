---
title: تطبيق أو تغيير تخطيطات الشرائح على Android
linktitle: تخطيط الشريحة
type: docs
weight: 60
url: /ar/androidjava/slide-layout/
keywords:
- تخطيط الشريحة
- تخطيط المحتوى
- عنصر نائب
- تصميم العرض التقديمي
- تصميم الشريحة
- تخطيط غير مستخدم
- رؤية التذييل
- شريحة عنوان
- العنوان والمحتوى
- عنوان القسم
- محتويان
- مقارنة
- عنوان فقط
- تخطيط فارغ
- محتوى مع شرح
- صورة مع شرح
- عنوان ونص عمودي
- عنوان عمودي ونص
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: تطبيق وإنشاء وتعديل تخطيطات الشرائح في Aspose.Slides لنظام Android عبر Java، إضافة عناصر نائبة، إزالة التخطيطات غير المستخدمة، والتحكم في رؤية التذييل.
---
## **نظرة عامة**

تحدد تخطيط الشريحة مواضع وتنسيق العناصر النائبة مثل العناوين والنصوص والصور والمخططات والجداول. يؤدي تطبيق تخطيط إلى إعطاء الشرائح بنية متسقة مع السماح لكل شريحة بأن تحتوي على محتواها الخاص.

أكثر التخطيطات شيوعًا هي:

- **شريحة عنوان**: تحتوي على عناصر نائبة للعنوان والعنوان الفرعي.
- **العنوان والمحتوى**: تحتوي على عنصر نائب للعنوان وعنصر نائب عام للمحتوى.
- **فارغ**: لا يحتوي على عناصر نائبة، وهو مفيد عندما يتم وضع كل شكل يدويًا.

## **فهم وراثة التخطيط**

للعرض التقديمي ثلاثة مستويات مترابطة:

1. شريحة [رئيسية](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasterslide/) تُعرّف السمة، التنسيق المشترك، الخلفيات، والكائنات العامة.
1. شريحة [تخطيط](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilayoutslide/) تنتمي إلى رئيسية وتحدد ترتيبًا معينًا للعناصر النائبة.
1. شريحة [عادية](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islide/) تستخدم تخطيطًا واحدًا وتخزن المحتوى المُدخل لتلك الشريحة.

ترث الشريحة العادية السمة والتنسيق من تخطيطها، ويُرث التخطيط من الرئيسي. القيمة المحددة مباشرة على الشريحة العادية تتجاوز القيمة الموروثة على ذلك المستوى. عند إنشاء شريحة عادية، تُنشأ أشكال العناصر النائبة من التخطيط المحدد، بينما المحتوى المدخل في تلك العناصر النائبة يخص الشريحة العادية.

أضف العناصر النائبة المطلوبة إلى التخطيط قبل إنشاء الشرائح منه. إضافة عنصر نائب آخر إلى التخطيط لاحقًا لا يُضيف تلقائيًا شكل عنصر نائب مماثل إلى الشرائح العادية القائمة.

هذه العلاقة لها نتيجتين مهمتين:

- تغيير التنسيق الموروث أو الشكل الهندسي للعناصر النائبة الحالية على تخطيط قد يُحدّث كل شريحة تعتمد عليه. قبل تعديل تخطيط مُستخدم بالفعل، افحص الشرائح التابعة له وراجع العرض الناتج.
- لا يمكن حذف تخطيط ما زال مستخدمًا من قبل شريحة. يجب إعادة تعيين الشرائح التابعة إلى تخطيط آخر أولًا، أو حذف التخطيطات غير المستخدمة فقط.

لمزيد من المعلومات حول المستوى الأعلى من هذه الهرمية، راجع [شريحة رئيسية](/slides/ar/androidjava/slide-master/).

## **اختيار وتطبيق تخطيط شريحة**

استخدم نوع تخطيط عندما يتبع العرض التقديمي تعريفات تخطيط PowerPoint القياسية. أسماء التخطيطات قابلة للتحرير من قبل المستخدم ويمكن تعريبها، لذا فإن الاختيار بناءً على الاسم أقل موثوقية ما لم تتحكم في القالب المصدر.

المثال التالي يبحث عن **العنوان والمحتوى** في الأولى من الشريحة الرئيسية. إذا كان ذلك التخطيط غير متاح، فإنه ينتقل عمدًا إلى **فارغ**. الفحص الثاني للـ null ضروري لأن العرض التقديمي قد يحتوي فقط على تخطيطات مخصصة. ثم يُطبق التخطيط المحدد على الشريحة العادية الأولى عبر طريقة [ISlide.setLayoutSlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) .

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

تغيّر تخطيط شريحة لا يزيل الأشكال العادية المضافة مباشرة إلى الشريحة. ومع ذلك، قد تتغيّر مواضع العناصر النائبة، التنسيق الموروث، والارتباط بين العناصر النائبة الحالية والتخطيط الجديد، لذا افحص الناتج عند التحويل بين تخطيطات مختلفة جذريًا.

## **إضافة شريحة تخطيط**

الاختيار وإنشاء التخطيط عمليتان منفصلتان. المثال السابق يختار تخطيطًا موجودًا؛ لا ينشئ واحدًا. لإنشاء تخطيط، استدعِ طريقة [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) على مجموعة تخطيطات الرئيسي المستهدف.

المثال التالي يضيف دائمًا تخطيط **العنوان والمحتوى** جديدًا باسم `Report Title and Content`، ثم يضيف شريحة عادية تعتمد عليه. يجب أن تكون أسماء التخطيطات فريدة داخل المجموعة.

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

أضف تخطيطًا فقط عندما يحتاج القالب فعليًا إلى بنية قابلة لإعادة الاستخدام أخرى. إذا كان هناك تخطيط مناسب موجود بالفعل، فاختره وأعد استخدامه بدلًا من إنشاء نسخة مكررة.

## **إضافة عناصر نائبة إلى شريحة تخطيط**

توفر طريقة [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) كائنًا من نوع [ILayoutPlaceholderManager](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) لإضافة أشكال العناصر النائبة إلى تخطيط.

| عنصر نائب في PowerPoint | طريقة `ILayoutPlaceholderManager` |
| ----------------------- | --------------------------------- |
| ![Content](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Content (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Text](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Text (Vertical)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Picture](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Chart](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Table](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Media](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Online Image](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

المثال التالي يتحقق من وجود تخطيط **فارغ**، يضيف إليه أربعة عناصر نائبة، ثم ينشئ شريحة عادية تستخدم التخطيط المعدل. الترتيب متعمد: تُضاف العناصر النائبة قبل إنشاء الشريحة العادية، بحيث يتمكن Aspose.Slides من توليد أشكال العناصر النائبة المقابلة على تلك الشريحة.

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
تغيير التنسيق الموروث أو الشكل الهندسي للعناصر النائبة في التخطيط قد يؤثر على الشرائح التابعة. العنصر النائب المضاف حديثًا لا يُملأ تلقائيًا في الشرائح العادية القائمة. اختبر تغييرات التخطيط على نسخة من العرض التقديمي وافحص كل شريحة تابعة.
{{% /alert %}}

## **إزالة شرائح التخطيط غير المستخدمة**

استخدم طريقة [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) لإزالة التخطيطات التي لا تشير إليها أي شريحة عادية. تُبقي الطريقة التخطيطات التي لا يزال يُستعمل فيها سليمة.

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

لإزالة تخطيط معين، استخدم أولًا طريقة [hasDependingSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilayoutslide/#hasDependingSlides--) أو [getDependingSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) الخاصة به. أعد تعيين أي شرائح تابعة قبل استدعاء طريقة [ILayoutSlide.remove](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilayoutslide/#remove--). محاولة إزالة تخطيط مُستَعمَل تُثير استثناءً من نوع [PptxEditException](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pptxeditexception/).

## **التحكم في إظهار التذييل على شريحة تخطيط**

لل تخطيط تذييله الخاص، ورقم شريحة، وعناصر التاريخ/الوقت. استخدم طريقة [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) للتحكم في تلك العناصر النائبة لتخطيط واحد. هذا مفيد عندما، على سبيل المثال، يجب أن تُظهر تخطيطات المحتوى التذييل بينما تُخفى تخطيطات العنوان.

المثال التالي يحدد تخطيطًا بأمان ويجعل عناصر التذييل مرئية:

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

## **التحكم في إظهار التذييل على شريحة رئيسية وتخطيطاتها الفرعية**

لتطبيق إعدادات تذييل متسقة عبر شجرة رئيسية، استخدم طريقة [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasterslide/#getHeaderFooterManager--) . تعمل طرائق النشر في [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) على الرئيسي وتخطيطات الشرائح التابعة له والشريحة العادية؛ لا تستهدف شريحة عادية واحدة فقط.

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

**ما الفرق بين الشريحة الرئيسية وشريحة التخطيط؟**

الشريحة الرئيسية تُعرّف سمة العرض التقديمي والتنسيق المشترك. شريحة التخطيط تنتمي إلى رئيسية وتُعرّف ترتيبًا قابلاً لإعادة الاستخدام للعناصر النائبة. تستخدم الشرائح العادية تلك التخطيطات وتخزن محتوى الشريحة الخاص.

**هل يمكنني نسخ شريحة تخطيط من عرض تقديمي إلى آخر؟**

نعم. أضف نسخة إلى مجموعة الوجهة باستخدام طريقة [addClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) . عند النسخ بين عروض تقديمية، تحقق أيضًا من الخطوط، السمات، الصور، والموارد الأخرى المستخدمة في التخطيط الأصلي.

**ماذا يحدث عندما أعدّل تخطيطًا مُستخدمًا بالفعل؟**

ترث الشرائح التابعة تغييرات التخطيط ما لم تقم بتجاوز التنسيق أو الكائنات المتأثرة محليًا. قد يتغيّر الشكل الهندسي للعناصر النائبة والتنسيق الموروث على عدة شرائح دفعة واحدة. استخدم طريقة [getDependingSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) لتحديد الشرائح المتأثرة قبل تعديل التخطيط.

**ماذا يحدث إذا أزلت تخطيطًا ما زال قيد الاستخدام؟**

ترمي Aspose.Slides استثناءً من نوع [PptxEditException](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pptxeditexception/). أعد تعيين الشرائح التابعة أولًا، أو استخدم طريقة [removeUnusedLayoutSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) لإزالة التخطيطات غير المرجعية فقط.