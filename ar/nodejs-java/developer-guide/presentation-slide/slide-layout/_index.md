---
title: تطبيق أو تغيير تخطيطات الشرائح في JavaScript
linktitle: تخطيط الشريحة
type: docs
weight: 60
url: /ar/nodejs-java/slide-layout/
keywords:
- تخطيط الشرائح
- تخطيط المحتوى
- عنصر نائب
- تصميم العرض
- تصميم الشريحة
- تخطيط غير مستخدم
- رؤية التذييل
- شريحة العنوان
- العنوان والمحتوى
- عنوان القسم
- محتوى مزدوج
- مقارنة
- عنوان فقط
- تخطيط فارغ
- محتوى مع توضيح
- صورة مع توضيح
- عنوان ونص عمودي
- عنوان عمودي ونص
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تطبيق وإنشاء وتعديل تخطيطات الشرائح في Aspose.Slides لـ Node.js عبر Java، إضافة عناصر نائب، إزالة التخطيطات غير المستخدمة، والتحكم في رؤية التذييل."
---
## **نظرة عامة**

يحدد تخطيط الشريحة مواضع وتنسيق العناصر النائبة مثل العناوين، النص، الصور، المخططات، والجداول. تطبيق تخطيط يمنح الشرائح بنية ثابتة مع السماح لكل شريحة باحتواء محتواها الخاص.

تشمل التخطيطات الأكثر شيوعًا:

- **شريحة العنوان**: تحتوي على عناصر نائب للعنوان والعنوان الفرعي.
- **العنوان والمحتوى**: يحتوي على عنصر نائب للعنوان وعنصر نائب عام للمحتوى.
- **فارغ**: لا يحتوي على عناصر نائب للمحتوى وهو مفيد عندما يتم وضع كل شكل يدويًا.

## **فهم وراثة التخطيط**

للعرض التقديمي ثلاثة مستويات مرتبطة:

1. A [master slide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterslide/) defines the theme, shared formatting, backgrounds, and common objects. => يحدد [شريحة رئيسية](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterslide/) السمة، التنسيق المشترك، الخلفيات، والكائنات العامة.
1. A [layout slide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutslide/) belongs to a master and defines a particular arrangement of placeholders. => تنتمي [شريحة التخطيط](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutslide/) إلى شريحة رئيسية وتحدد ترتيبًا معينًا لعناصر نائب.
1. A [normal slide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slide/) uses one layout and stores the content entered for that slide. => تستخدم [شريحة عادية](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slide/) تخطيطًا واحدًا وتخزن المحتوى المدخل لتلك الشريحة.

تُورث الشريحة العادية السمة والتنسيق من تخطيطها، ويورث التخطيط من شريحة رئيسية. القيمة التي تُعيّن مباشرةً على شريحة عادية تتجاوز القيمة الموروثة في ذلك المستوى. عند إنشاء شريحة عادية، تُنشأ أشكال العناصر النائبة من التخطيط المختار، بينما المحتوى المدخل في تلك العناصر النائبة يُنتمي إلى الشريحة العادية.

أضف العناصر النائبة المطلوبة إلى تخطيط قبل إنشاء شرائح منه. إضافة عنصر نائب آخر إلى التخطيط لاحقًا لا يضيف بشكل تلقائي شكل عنصر نائب مماثل إلى الشرائح العادية الموجودة.

لِهذه العلاقة نتيجتان مهمتان:

- قد يؤدي تغيير التنسيق الموروث أو هندسة عنصر نائب موجود في التخطيط إلى تحديث كل الشريحة التي تعتمد عليه. قبل تعديل تخطيط يتم استخدامه بالفعل، افحص الشرائح التابعة له وراجع العرض الناتج.
- لا يمكن إزالة تخطيط لا يزال مستخدمًا من قبل شريحة. أعد تعيين الشرائح التابعة له إلى تخطيط آخر أولاً، أو احذف فقط التخطيطات غير المستخدمة.

لمزيد من المعلومات حول المستوى العلوي من هذه الهيكلية، راجع [Slide Master](/slides/ar/nodejs-java/slide-master/).

## **اختيار وتطبيق تخطيط الشريحة**

استخدم قيمة [SlideLayoutType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidelayouttype/) عندما يتبع العرض تعريفات تخطيط PowerPoint القياسية. أسماء التخطيطات قابلة للتحرير من قبل المستخدم ويمكن ترجمتها، لذا فإن الاختيار القائم على الاسم أقل موثوقية ما لم تتحكم في قالب المصدر.

المثال التالي يبحث عن **العنوان والمحتوى** على أول شريحة رئيسية. إذا لم يتوفر هذا التخطيط، يتم الرجوع عمدًا إلى **فارغ**. الفحص الثاني للـnull ضروري لأن العرض قد يحتوي فقط على تخطيطات مخصصة. ثم يُطبق التخطيط المختار على أول شريحة عادية عبر طريقة [Slide.setLayoutSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slide/#setLayoutSlide).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let targetLayout = layoutSlides.getByType(titleAndObjectLayoutType);

    if (targetLayout === null) {
        targetLayout = layoutSlides.getByType(blankLayoutType);
    }

    if (targetLayout === null) {
        throw new Error("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تغيير تخطيط الشريحة لا يزيل الأشكال العادية التي أضيفت مباشرةً إلى الشريحة. ومع ذلك، قد تتغير مواضع العناصر النائبة، التنسيق الموروث، والارتباط بين العناصر النائبة الحالية والتخطيط الجديد، لذا يجب فحص المخرجات عند التحول بين تخطيطات مختلفة اختلافًا كبيرًا.

## **إضافة شريحة تخطيط**

الاختيار والإنشاء عمليتان منفصلتان. المثال السابق يختار تخطيطًا موجودًا؛ لا ينشئ واحدًا. لإنشاء تخطيط، استدع طريقة [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterlayoutslidecollection/#add) على مجموعة تخطيطات الشريحة الرئيسة المستهدفة.

المثال التالي يضيف دائمًا تخطيطًا جديدًا **العنوان والمحتوى** باسم `Report Title and Content`، ثم يضيف شريحة عادية تعتمد عليه. يجب أن تكون أسماء التخطيطات فريدة داخل المجموعة.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let reportLayout = masterSlide.getLayoutSlides().add(titleAndObjectLayoutType, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

أضف تخطيطًا فقط عندما يحتاج القالب إلى بنية قابلة لإعادة الاستخدام أخرى. إذا كان هناك تخطيط مناسب بالفعل، فاختره واستخدمه بدلاً من إنشاء نسخة مكررة.

## **إضافة عناصر نائب إلى شريحة التخطيط**

توفر طريقة [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) كائنًا من نوع [LayoutPlaceholderManager](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutplaceholdermanager/) لإضافة أشكال عناصر نائب إلى التخطيط.

| عنصر نائب في PowerPoint | طريقة `LayoutPlaceholderManager` |
| ----------------------- | -------------------------------- |
| ![المحتوى](content.png) | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![المحتوى (عمودي)](contentV.png) | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![نص](text.png) | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![نص (عمودي)](textV.png) | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![صورة](picture.png) | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![مخطط](chart.png) | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![جدول](table.png) | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![وسائط](media.png) | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![صورة عبر الإنترنت](onlineImage.png) | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

البرنامج التالي يتحقق من وجود تخطيط **فارغ**، يضيف أربعة عناصر نائب إليه، ثم ينشئ شريحة عادية تستخدم التخطيط المعدل. الترتيب مقصود: تُضاف العناصر النائبة قبل إنشاء الشريحة العادية، بحيث يمكن Aspose.Slides توليد أشكال العناصر النائبة المقابلة على تلك الشريحة.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayout = presentation.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayout === null) {
        throw new Error("The presentation does not contain a Blank layout slide.");
    }

    let placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![عناصر نائب على شريحة التخطيط](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
تغيير التنسيق الموروث أو هندسة عناصر نائب التخطيط الموجودة يمكن أن يؤثر على الشرائح التابعة. عنصر نائب تخطيط مضاف حديثًا لا يُملأ تلقائيًا في الشرائح العادية الموجودة. اختبر تغييرات التخطيط على نسخة من العرض وراجع كل شريحة تابعة.
{{% /alert %}}

## **إزالة شرائح التخطيط غير المستخدمة**

استخدم طريقة [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) لإزالة التخطيطات التي لا تشير إليها أي شريحة عادية. تُبقي الطريقة التخطيطات التي لا تزال قيد الاستخدام كما هي.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

لإزالة تخطيط محدد، استخدم أولاً طريقة [hasDependingSlides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides) أو [getDependingSlides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutslide/#getDependingSlides). أعد تعيين أي شرائح تابعة قبل استدعاء [LayoutSlide.remove](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutslide/#remove). محاولة إزالة تخطيط مستخدم تُسبب استثناءً من نوع [PptxEditException](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pptxeditexception/).

## **التحكم في ظهور تذييل الصفحة على شريحة التخطيط**

للتخطيط تذييل خاص به، رقم شريحة، وعناصر نائب للوقت والتاريخ. استخدم طريقة [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager) للتحكم في تلك العناصر النائبة لتخطيط واحد. هذا مفيد عندما يجب أن تُظهر تخطيطات المحتوى تذييلات بينما لا تُظهر تخطيطات العناوين ذلك.

المثال التالي يختار تخطيطًا بأمان ويجعل عناصر التذييل الخاصة به مرئية:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = presentation.getLayoutSlides().getByType(titleAndObjectLayoutType);

    if (layoutSlide === null) {
        layoutSlide = presentation.getLayoutSlides().getByType(blankLayoutType);
    }

    if (layoutSlide === null) {
        throw new Error("The presentation does not contain a suitable layout slide.");
    }

    let headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **التحكم في ظهور تذييل الصفحة على الشريحة الرئيسية وتخطيطاتها الفرعية**

لتطبيق إعدادات تذييل موحدة عبر هيكلية الشريحة الرئيسية، استخدم طريقة [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager). طرق النشر في [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterslideheaderfootermanager/) تعمل على الشريحة الرئيسية وتخطيطاتها الفرعية والشرائح العادية؛ ولا تستهدف شريحة عادية واحدة فقط.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة المتكررة**

**ما الفرق بين الشريحة الرئيسية وشريحة التخطيط؟**

تُعرّف الشريحة الرئيسية سمة العرض وتنسيقها المشترك. شريحة التخطيط تنتمي إلى شريحة رئيسية وتحدد ترتيبًا قابلاً لإعادة الاستخدام لعناصر نائب. تستخدم الشرائح العادية تلك التخطيطات وتخزن محتوى كل شريحة على حدة.

**هل يمكنني نسخ شريحة تخطيط من عرض تقديمي إلى آخر؟**

نعم. أضف نسخة إلى مجموعة الهدف باستخدام طريقة [addClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone). عند النسخ بين عروض تقديمية، تحقق أيضًا من الخطوط، السمات، الصور، وغيرها من الموارد المستخدمة في التخطيط المصدر.

**ماذا يحدث عندما أقوم بتعديل تخطيط قيد الاستخدام؟**

تُورّث الشرائح التابعة تغييرات التخطيط ما لم تقم بتجاوز التنسيق أو الكائنات المتأثرة محليًا. قد تتغير هندسة العناصر النائبة والتنسيق الموروث على العديد من الشرائح دفعة واحدة. استخدم طريقة [getDependingSlides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) لتحديد الشرائح المتأثرة قبل تعديل التخطيط.

**ماذا يحدث إذا قمت بإزالة تخطيط لا يزال قيد الاستخدام؟**

يرمي Aspose.Slides استثناءً من نوع [PptxEditException](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pptxeditexception/). أعد تعيين الشرائح التابعة أولاً، أو استخدم طريقة [removeUnusedLayoutSlides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) لإزالة التخطيطات غير المشار إليها فقط.