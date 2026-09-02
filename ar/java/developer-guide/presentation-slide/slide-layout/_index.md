---
title: تطبيق أو تعديل تخطيطات الشرائح في جافا
linktitle: تخطيط الشريحة
type: docs
weight: 60
url: /ar/java/slide-layout/
keywords:
- تخطيط الشريحة
- تخطيط المحتوى
- عنصر نائب
- تصميم العرض التقديمي
- تصميم الشريحة
- تخطيط غير مستخدم
- إظهار التذييل
- شريحة عنوان
- العنوان والمحتوى
- عنوان القسم
- محتوى مزدوج
- مقارنة
- عنوان فقط
- تخطيط فارغ
- محتوى مع توضيح
- صورة مع توضيح
- العنوان والنص العمودي
- عنوان عمودي ونص
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "تطبيق وإنشاء وتعديل تخطيطات الشرائح في Aspose.Slides للغة Java، إضافة عناصر نائبة، إزالة التخطيطات غير المستخدمة، والتحكم في إظهار التذييل."
---
## **نظرة عامة**

يحدد تخطيط الشريحة مواقع وتنسيق العناصر النائبة مثل العناوين والنصوص والصور والمخططات والجداول. يضيف تطبيق التخطيط بنيةً ثابتةً للشرائح مع السماح لكل شريحة باحتواء محتواها الخاص.

تشمل أكثر التخطيطات شيوعًا:

- **شريحة عنوان**: تحتوي على عناصر نائبة للعنوان والعنوان الفرعي.
- **العنوان والمحتوى**: تحتوي على عنصر نائب للعنوان وعنصر نائب عام للمحتوى.
- **فارغ**: لا يحتوي على عناصر نائبة للمحتوى ويكون مفيدًا عندما سيتم وضع كل شكل يدويًا.

## **فهم وراثة التخطيط**

للعرض التقديمي ثلاث مستويات مرتبطة:

1. [شريحة رئيسية](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterslide/) تحدد السمة، التنسيق المشترك، الخلفيات، والكائنات العامة.
2. [شريحة تخطيط](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutslide/) تنتمي إلى رئيسية وتحدد ترتيبًا معينًا للعناصر النائبة.
3. [شريحة عادية](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islide/) تستخدم تخطيطًا واحدًا وتخزن المحتوى المدخل لتلك الشريحة.

تورّث الشريحة العادية السمة والتنسيق من التخطيط الخاص بها، ويورّث التخطيط من الشريحة الرئيسية. أي قيمة تُعيّن مباشرةً على الشريحة العادية تتجاوز القيمة الموروثة في ذلك المستوى. عندما يتم إنشاء شريحة عادية، يتم إنشاء أشكال العناصر النائبة من التخطيط المحدد، بينما المحتوى المدخل لتلك العناصر النائبة يخص الشريحة العادية.

أضف العناصر النائبة المطلوبة إلى التخطيط قبل إنشاء شرائح منه. إضافة عنصر نائب آخر إلى التخطيط لاحقًا لا يضيف تلقائيًا شكل عنصر نائب مطابق إلى الشرائح العادية الموجودة.

هذه العلاقة لها نتيجتان مهمتان:

- تغيير التنسيق الموروث أو الهندسة الحالية لعناصر النائب في التخطيط يمكن أن يحدث تحديثًا لكل الشريحة التي تعتمد عليه. قبل تحرير تخطيط يُستخدم بالفعل، راجع الشرائح التابعة له وتحقق من العرض التقديمي الناتج.
- لا يمكن إزالة تخطيط لا يزال مستخدمًا من قبل شريحة. أعد تعيين الشرائح التابعة له إلى تخطيط آخر أولاً، أو قم بإزالة التخطيطات غير المستخدمة فقط.

لمزيد من المعلومات حول المستوى العلوي من هذه الهرمية، راجع [الشريحة الرئيسية](/slides/ar/java/slide-master/).

## **اختيار وتطبيق تخطيط الشريحة**

استخدم نوع التخطيط عندما يتبع العرض التقديمي تعريفات التخطيط القياسية في PowerPoint. يمكن تحرير أسماء التخطيطات من قبل المستخدم ويمكن ترجمتها، لذا فإن الاختيار بناءً على الاسم أقل موثوقية ما لم تتحكم في القالب المصدر.

المثال التالي يبحث عن **العنوان والمحتوى** في الرئيسي الأول. إذا لم يتوفر هذا التخطيط، فإنه يعود عمدًا إلى **فارغ**. الفحص الثاني للـ null ضروري لأن العرض التقديمي قد يحتوي فقط على تخطيطات مخصصة. ثم يتم تطبيق التخطيط المختار على الشريحة العادية الأولى عبر طريقة [ISlide.setLayoutSlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-).

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

تغيير تخطيط الشريحة لا يزيل الأشكال العادية المضافة مباشرةً إلى الشريحة. ومع ذلك، قد تتغير مواضع العناصر النائبة، والتنسيق الموروث، والعلاقة بين العناصر النائبة الحالية والتخطيط الجديد، لذلك تحقق من الناتج عند التبديل بين تخطيطات مختلفة بشكل كبير.

## **إضافة شريحة تخطيط**

الاختيار والإنشاء عمليتان منفصلتان. المثال السابق يختار تخطيطًا موجودًا؛ لا ينشئ واحدًا. لإنشاء تخطيط، استدعِ طريقة [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) على مجموعة تخطيطات الرئيسي المستهدف.

المثال التالي يضيف دائمًا تخطيطًا جديدًا **العنوان والمحتوى** يسمى `Report Title and Content`، ثم يضيف شريحة عادية بناءً عليه. يجب أن تكون أسماء التخطيطات فريدة داخل المجموعة.

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

أضف تخطيطًا فقط عندما يكون القالب بحاجة فعلًا إلى بنية قابلة لإعادة الاستخدام. إذا كان هناك تخطيط مناسب موجود بالفعل، فاختره وأعد استخدامه بدلًا من إنشاء نسخة مكررة.

## **إضافة عناصر نائبة إلى شريحة التخطيط**

طريقة [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) توفر [ILayoutPlaceholderManager](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutplaceholdermanager/) لإضافة أشكال العناصر النائبة إلى التخطيط.

| عنصر نائب في PowerPoint | طريقة ILayoutPlaceholderManager |
| ------------------------ | -------------------------------- |
| ![المحتوى](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![المحتوى (عمودي)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![نص](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![نص (عمودي)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![صورة](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![مخطط](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![جدول](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![وسائط](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![صورة عبر الإنترنت](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

المثال التالي يتحقق من وجود تخطيط **فارغ**، يضيف أربعة عناصر نائبة إليه، ثم ينشئ شريحة عادية تستخدم التخطيط المعدل. الترتيب مقصود: يتم إضافة العناصر النائبة قبل إنشاء الشريحة العادية، حتى تتمكن Aspose.Slides من إنشاء أشكال العناصر النائبة المقابلة على تلك الشريحة.

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

{{% alert color="warning" title="تحذير" %}}
قد يؤثر تغيير التنسيق الموروث أو هندسة العناصر النائبة الحالية في التخطيط على الشرائح التابعة. العنصر النائب المضاف حديثًا إلى التخطيط لا يتم ملؤه تلقائيًا في الشرائح العادية القائمة. اختبر تغييرات التخطيط على نسخة من العرض التقديمي وتفقد كل شريحة تابعة.
{{% /alert %}}

## **إزالة شرائح التخطيط غير المستخدمة**

استخدم طريقة [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) لإزالة التخطيطات التي لا تشير إليها أي شريحة عادية. تترك الطريقة التخطيطات التي لا تزال قيد الاستخدام دون تغيير.

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

لإزالة تخطيط محدد واحد، استخدم أولاً طريقتي [hasDependingSlides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutslide/#hasDependingSlides--) أو [getDependingSlides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) الخاصة به. أعد تعيين أي شرائح تابعة قبل استدعاء [ILayoutSlide.remove](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutslide/#remove--). محاولة إزالة تخطيط مستخدم يرفع استثناءً من نوع [PptxEditException](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pptxeditexception/).

## **التحكم في إظهار التذييل على شريحة التخطيط**

يحتوي التخطيط على تذييل خاص به وعناصر نائبة لرقم الشريحة وتاريخ الوقت. استخدم طريقة [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) للتحكم في تلك العناصر النائبة لتخطيط واحد. يكون هذا مفيدًا عندما، على سبيل المثال، يجب أن تُظهر تخطيطات المحتوى التذييلات لكن تخطيطات العنوان لا يجب أن تظهرها.

المثال التالي يختار تخطيطًا بأمان ويجعل عناصر التذييل الخاصة به مرئية:

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

## **التحكم في إظهار التذييل على الرئيس وتخطيطاته الفرعية**

لتطبيق إعدادات تذييل موحدة عبر شجرة رئيسية، استخدم طريقة [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterslide/#getHeaderFooterManager--). تعمل طرق الانتشار في [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imasterslideheaderfootermanager/) على الرئيس وتخطيطاته الفرعية الشرائحية والشرائح العادية التابعة؛ ولا تستهدف شريحة عادية واحدة فقط.

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

## **الأسئلة الشائعة**

**ما الفرق بين الشريحة الرئيسية وشريحة التخطيط؟**

تحدد الشريحة الرئيسية سمة العرض التقديمي وتنسيقاته المشتركة. تنتمي شريحة التخطيط إلى رئيسية وتحدد ترتيبًا واحدًا قابلًا لإعادة الاستخدام للعناصر النائبة. تستخدم الشرائح العادية تلك التخطيطات وتخزن محتوى خاصًا بكل شريحة.

**هل يمكنني نسخ شريحة تخطيط من عرض تقديمي إلى آخر؟**

نعم. أضف نسخة إلى مجموعة الوجهة باستخدام طريقة [addClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-). عند النسخ بين العروض التقديمية، تحقق أيضًا من الخطوط والسمات والصور والموارد الأخرى المستخدمة في التخطيط المصدر.

**ماذا يحدث عندما أقوم بتعديل تخطيط مُستخدم بالفعل؟**

تورّث الشرائح التابعة تغييرات التخطيط ما لم تقم بتجاوز التنسيق أو الكائنات المتأثرة محليًا. وبالتالي قد تتغيّر هندسة العناصر النائبة والتنسيق الموروث على العديد من الشرائح مرةً واحدة. استخدم [getDependingSlides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) لتحديد الشرائح المتأثرة قبل تحرير التخطيط.

**ماذا يحدث إذا أزلت تخطيطًا لا يزال قيد الاستخدام؟**

ترمى Aspose.Slides استثناءً من نوع [PptxEditException](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pptxeditexception/). أعد تعيين الشرائح التابعة أولاً، أو استخدم طريقة [removeUnusedLayoutSlides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) لإزالة التخطيطات غير المشار إليها فقط.