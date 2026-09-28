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
- عنوان ومحتوى
- عنوان القسم
- محتوى مزدوج
- مقارنة
- عنوان فقط
- تخطيط فارغ
- محتوى مع تسمية توضيحية
- صورة مع تسمية توضيحية
- عنوان ونص عمودي
- عنوان عمودي ونص
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تطبيق، إنشاء وتعديل تخطيطات الشرائح في Aspose.Slides للأندرويد عبر جافا، إضافة عناصر نائبة، إزالة التخطيطات غير المستخدمة، والتحكم في رؤية التذييل."
---
## **نظرة عامة**

يحدد تخطيط الشريحة مواضع وتنسيق العناصر النائبة مثل العناوين والنصوص والصور والرسوم البيانية والجداول. يوفّر تطبيق التخطيط بنية متسقة للشرائح مع السماح لكل شريحة باحتواء محتواها الخاص.

تشمل أكثر التخطيطات شيوعًا:

- **شريحة عنوان**: تحتوي على عناصر نائبة للعنوان والعنوان الفرعي.
- **عنوان ومحتوى**: تحتوي على عنصر نائب للعنوان وعنصر نائب عام للمحتوى.
- **فارغ**: لا يحتوي على أي عناصر نائبة ويُستخدم عندما يتم وضع كل شكل يدويًا.

## **فهم وراثة التخطيط**

العرض التقديمي له ثلاث مستويات مرتبطة:

1. [شريحة رئيسية](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasterslide/) تُعرّف السمة، التنسيق المشترك، الخلفيات، والكائنات العامة.
1. [شريحة تخطيط](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilayoutslide/) تنتمي إلى رئيسية وتحدد ترتيبًا معينًا للعناصر النائبة.
1. [شريحة عادية](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islide/) تستخدم تخطيطًا واحدًا وتخزن المحتوى المدخل لتلك الشريحة.

ترث الشريحة العادية السمة والتنسيق من تخطيطها، ويرث التخطيط من رئيسيته. أي قيمة تُحدَّد مباشرةً على الشريحة العادية تتجاوز القيمة الموروثة في ذلك المستوى. عند إنشاء شريحة عادية، تُولَّد أشكال العناصر النائبة من التخطيط المحدد، بينما يُعَدُّ المحتوى المدخل إلى تلك العناصر جزءًا من الشريحة العادية.

أضف العناصر النائبة المطلوبة إلى التخطيط قبل إنشاء شرائح منه. إضافة عنصر نائب آخر إلى التخطيط لاحقًا لا يضيف تلقائيًا شكل عنصر نائب مماثل إلى الشرائح العادية الموجودة.

لهذا العلاقة نتيجتان مهمتان:

- تعديل التنسيق الموروث أو الشكل الهندسي لعناصر نائبة موجودة في التخطيط يمكن أن يُحدِّث كل الشريحة التي تعتمد عليه. قبل تعديل تخطيط مُستخدم، افحص الشرائح التابعة له وراجع النتيجة النهائية.
- لا يمكن إزالة تخطيط لا يزال مُستَخدَمًا من قبل شريحة. أعد تعيين الشرائح التابعة إلى تخطيط آخر أولاً، أو احذف التخطيطات غير المستخدمة فقط.

لمزيد من المعلومات حول المستوى الأعلى من هذه الهرمية، راجع [شريحة رئيسية](/slides/ar/androidjava/slide-master/).

لإخفاء الشعارات أو الأشكال الزخرفية الموروثة من الرئيسي على شريحة واحدة أو عبر تخطيط مشترك، راجع [التحكم في رؤية الرسومات الرئيسية](/slides/ar/androidjava/slide-master/). يُقارن المثال شريحتين تستخدمان نفس الرئيسي.

## **اختيار وتطبيق تخطيط شريحة**

استخدم نوع التخطيط عندما يتبع العرض التقديمي تعريفات تخطيط PowerPoint القياسية. أسماء التخطيطات قابلة للتحرير من قِبل المستخدم ويمكن توطينها، لذا يكون الاختيار القائم على الاسم أقل موثوقية ما لم تكن تتحكم في القالب المصدر.

المثال التالي يبحث عن **عنوان ومحتوى** في الأولية الأولى. إذا كان هذا التخطيط غير متوفر، يتراجع عمدًا إلى **فارغ**. الفحص الثاني للـ null ضروري لأن العرض التقديمي قد يحتوي فقط على تخطيطات مخصصة. يتم بعد ذلك تطبيق التخطيط المختار على الشريحة العادية الأولى عبر طريقة [ISlide.setLayoutSlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) .

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

تغيير تخطيط الشريحة لا يزيل الأشكال العادية المضافة مباشرةً إلى الشريحة. ومع ذلك، يمكن أن تتغيّر مواضع العناصر النائبة، التنسيق الموروث، والارتباط بين العناصر النائبة الحالية والتخطيط الجديد، لذا افحص الناتج عند التبديل بين تخطيطات مختلفة اختلافًا كبيرًا.

## **إضافة شريحة تخطيط**

الاختيار والإنشاء عمليتان منفصلتان. المثال السابق يختار تخطيطًا موجودًا؛ لا ينشئ واحدًا. لإنشاء تخطيط، استدع طريقة [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) على مجموعة تخطيطات الرئيسي المستهدف.

المثال التالي يضيف دائمًا تخطيطًا جديدًا **عنوان ومحتوى** يُسمّى `Report Title and Content`، ثم يضيف شريحة عادية تستند إليه. يجب أن تكون أسماء التخطيطات فريدة داخل المجموعة.

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

أضف تخطيطًا فقط عندما يحتاج القالب حقًا إلى بنية قابلة لإعادة الاستخدام. إذا كان تخطيط ملائم موجودًا مسبقًا، اختره واستخدمه بدلاً من إنشاء نسخة مكررة.

## **إضافة عناصر نائبة إلى شريحة تخطيط**

توفر طريقة [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) كائنًا من النوع [ILayoutPlaceholderManager](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) لإضافة أشكال عناصر نائبة إلى تخطيط.

| العنصر النائب في PowerPoint | طريقة `ILayoutPlaceholderManager` |
| --------------------------- | --------------------------------- |
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

المثال التالي يتحقق من وجود التخطيط **فارغ**، يضيف أربعة عناصر نائبة إليه، ثم ينشئ شريحة عادية تستخدم التخطيط المعدل. الترتيب متعمد: تُضاف العناصر النائبة قبل إنشاء الشريحة العادية، حتى يستطيع Aspose.Slides توليد أشكال العناصر النائبة المقابلة على تلك الشريحة.

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

![العناصر النائبة على شريحة التخطيط](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
تغيير التنسيق الموروث أو الشكل الهندسي لعناصر نائبة موجودة في التخطيط يمكن أن يؤثر على الشرائح التابعة. العنصر النائب المضاف حديثًا لا يُملأ تلقائيًا في الشرائح العادية الموجودة. اختبر تغييرات التخطيط على نسخة من العرض التقديمي وافحص كل شريحة تابعة.
{{% /alert %}}

## **إزالة شرائح تخطيط غير مستخدمة**

استخدم طريقة [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) لإزالة التخطيطات التي لا تشير إليها أي شريحة عادية. تترك الطريقة التخطيطات التي لا تزال قيد الاستخدام كما هي.

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

لإزالة تخطيط معين، استخدم أولاً طريقة [hasDependingSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilayoutslide/#hasDependingSlides--) أو [getDependingSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) الخاصة به. أعد تعيين أي شرائح تابعة قبل استدعاء [ILayoutSlide.remove](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilayoutslide/#remove--). محاولة إزالة تخطيط مستخدم تُسبب استثناءً من النوع [PptxEditException](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pptxeditexception/).

## **التحكم في رؤية تذييل الصفحة على شريحة تخطيط**

يحتوي التخطيط على تذييل صفحة، رقم شريحة، وعناصر نائبة للوقت/التاريخ خاصة به. استخدم طريقة [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) للتحكم في تلك العناصر النائبة لتخطيط واحد. هذا مفيد عندما، على سبيل المثال، يجب أن تُظهر تخطيطات المحتوى التذييل ولكن لا يجب أن تُظهر تخطيطات العنوان ذلك.

المثال التالي يختار تخطيطًا بأمان ويجعل عناصر تذييل الصفحة الخاصة به مرئية:

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

## **التحكم في رؤية تذييل الصفحة على رئيسية وتخطيطاتها الفرعية**

لتطبيق إعدادات تذييل موحدة عبر تسلسل هرمي للرئيسية، استخدم طريقة [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasterslide/#getHeaderFooterManager--) . تُطبق طرق الانتشار الخاصة بـ [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) على الرئيسي وتخطيطاته التابعة والشرائح العادية؛ لا تستهدف شريحة عادية واحدة فقط.

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

تُعرّف الشريحة الرئيسية سمة العرض التقديمي والتنسيق المشترك. شريحة التخطيط تنتمي إلى رئيسية وتحدد ترتيبًا قابلًا لإعادة الاستخدام للعناصر النائبة. تستخدم الشرائح العادية تلك التخطيطات وتخزن محتوىً خاصًا بكل شريحة.

**هل يمكنني نسخ شريحة تخطيط من عرض تقديمي إلى آخر؟**

نعم. أضف نسخة إلى مجموعة الوجهة باستخدام طريقة [addClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-). عند النسخ بين العروض، تحقق أيضًا من الخطوط، السمات، الصور، والموارد الأخرى المستخدمة في التخطيط الأصلي.

**ماذا يحدث إذا عدّلت تخطيطًا قيد الاستخدام بالفعل؟**

ترث الشرائح التابعة تغييرات التخطيط ما لم تقم بتجاوز التنسيق أو الكائنات المتأثرة محليًا. يمكن أن يتغيّر الشكل الهندسي للعناصر النائبة والأسلوب الموروث على العديد من الشرائح في آن واحد. استخدم [getDependingSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) لتحديد الشرائح المتأثرة قبل تعديل التخطيط.

**ماذا يحدث إذا أزلت تخطيطًا لا يزال قيد الاستخدام؟**

ترمي Aspose.Slides استثناءً من النوع [PptxEditException](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pptxeditexception/). أعد تعيين الشرائح التابعة أولاً، أو استخدم [removeUnusedLayoutSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) لإزالة التخطيطات غير المرجعية فقط.