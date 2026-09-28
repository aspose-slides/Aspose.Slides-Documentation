---
title: تطبيق أو تغيير تخطيطات الشرائح في جافا سكريبت
linktitle: تخطيط الشريحة
type: docs
weight: 60
url: /ar/nodejs-java/slide-layout/
keywords:
- تخطيط الشريحة
- تخطيط المحتوى
- عنصر نائب
- تصميم العرض التقديمي
- تصميم الشريحة
- تخطيط غير مستخدم
- إظهار التذييل
- شريحة العنوان
- العنوان والمحتوى
- رأس القسم
- محتواان
- مقارنة
- العنوان فقط
- تخطيط فارغ
- محتوى مع توضيح
- صورة مع توضيح
- العنوان والنص العمودي
- العنوان العمودي والنص
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تطبيق وإنشاء وتعديل تخطيطات الشرائح في Aspose.Slides لـ Node.js عبر Java، إضافة عناصر نائبة، إزالة التخطيطات غير المستخدمة، والتحكم في إظهار التذييل."
---
## **نظرة عامة**

يحدد تخطيط الشريحة مواضع وتنسيق العناصر النائبة مثل العناوين والنصوص والصور والرسوم البيانية والجداول. يتيح تطبيق التخطيط للشرا̈يح هيكلًا متسقًا مع السماح لكل شريحة بمحتواها الخاص.

- **Title Slide**: يحتوي على عناصر نائبة للعنوان والعنوان الفرعي.
- **Title and Content**: يحتوي على عنصر نائب للعنوان وعنصر نائب محتوى عام الغرض.
- **Blank**: لا يحتوي على عناصر نائبة للمحتوى وهو مفيد عندما يتم وضع كل شكل يدويًا.

## **فهم وراثة التخطيط**

العرض التقديمي له ثلاثة مستويات ذات صلة:

1. A [الشريحة الرئيسية](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterslide/) defines the theme, shared formatting, backgrounds, and common objects.
1. A [شريحة التخطيط](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutslide/) belongs to a master and defines a particular arrangement of placeholders.
1. A [شريحة عادية](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slide/) uses one layout and stores the content entered for that slide.

A normal slide inherits theme and formatting from its layout, and the layout inherits from its master. A value set directly on a normal slide overrides the inherited value at that level. When a normal slide is created, its placeholder shapes are generated from the selected layout, while the content entered into those placeholders belongs to the normal slide.

Add required placeholders to a layout before creating slides from it. Adding another placeholder to a layout later does not automatically add a corresponding placeholder shape to existing normal slides.

هذه العلاقة لها نتيجتين مهمتين:

- Changing inherited formatting or existing placeholder geometry on a layout can update every slide that depends on it. Before editing a layout that is already in use, inspect its dependent slides and review the resulting presentation.
- A layout that is still used by a slide cannot be removed. Reassign its dependent slides to another layout first, or remove only unused layouts.

For more information about the top level of this hierarchy, see [الشريحة الرئيسية](/slides/ar/nodejs-java/slide-master/).

To hide inherited logos or decorative master shapes on one slide or through a shared layout, see [Control the Visibility of Master Graphics](/slides/ar/nodejs-java/slide-master/). The example compares two slides using the same master.

## **اختيار وتطبيق تخطيط شريحة**

Use a [SlideLayoutType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidelayouttype/) value when the presentation follows standard PowerPoint layout definitions. Layout names are user-editable and can be localized, so name-based selection is less reliable unless you control the source template.

The following example looks for **Title and Content** on the first master. If that layout is unavailable, it deliberately falls back to **Blank**. The second null check is necessary because a presentation can contain only custom layouts. The selected layout is then applied to the first normal slide through the [Slide.setLayoutSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slide/#setLayoutSlide) method.

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

Changing a slide's layout does not remove ordinary shapes added directly to the slide. However, placeholder positions, inherited formatting, and the correspondence between existing placeholders and the new layout can change, so inspect the output when switching between substantially different layouts.

## **إضافة شريحة تخطيط**

Selection and creation are separate operations. The previous example selects an existing layout; it does not create one. To create a layout, call the [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterlayoutslidecollection/#add) method on the target master's layout collection.

The following example always adds a new **Title and Content** layout named `Report Title and Content`, then adds a normal slide based on it. Layout names must be unique within the collection.

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

Add a layout only when the template genuinely needs another reusable structure. If a suitable layout already exists, select and reuse it instead of creating a duplicate.

## **إضافة عناصر نائبة إلى شريحة تخطيط**

The [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) method provides a [LayoutPlaceholderManager](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutplaceholdermanager/) for adding placeholder shapes to a layout.

| عنصر نائي في PowerPoint              | `LayoutPlaceholderManager` Method |
| ----------------------------------- | --------------------------------- |
| ![المحتوى](content.png)             | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![المحتوى (عمودي)](contentV.png) | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![نص](text.png)                     | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![نص (عمودي)](textV.png)           | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![صورة](picture.png)               | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![مخطط](chart.png)                 | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![جدول](table.png)                 | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)           | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![وسائط](media.png)                 | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![صورة على الإنترنت](onlineImage.png)    | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

The following example verifies that the **Blank** layout exists, adds four placeholders to it, and then creates a normal slide that uses the modified layout. The order is intentional: the placeholders are added before the normal slide is created, so Aspose.Slides can generate the corresponding placeholder shapes on that slide.

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

The result:

![العناصر النائبة على شريحة التخطيط](add_placeholders.png)

{{% alert color="warning" title="تحذير" %}}
Changing inherited formatting or the geometry of existing layout placeholders can affect dependent slides. A newly added layout placeholder is not backfilled into existing normal slides. Test layout changes on a copy of the presentation and inspect every dependent slide.
{{% /alert %}}

## **إزالة شرائح التخطيط غير المستخدمة**

Use the [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) method to remove layouts that no normal slide references. The method leaves layouts that are still in use intact.

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

To remove one specific layout, first use its [hasDependingSlides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides) or [getDependingSlides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) method. Reassign any dependent slides before calling [LayoutSlide.remove](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutslide/#remove). Attempting to remove a used layout raises a [PptxEditException](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pptxeditexception/).

## **التحكم في إظهار التذييل على شريحة التخطيط**

A layout has its own footer, slide-number, and date-time placeholders. Use the [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager) method to control those placeholders for one layout. This is useful when, for example, content layouts should show footers but title layouts should not.

The following example selects a layout safely and makes its footer elements visible:

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

## **التحكم في إظهار التذييل على الشريحة الرئيسية وتخطيطاتها الفرعية**

To apply consistent footer settings across a master hierarchy, use the [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager) method. The propagation methods of [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterslideheaderfootermanager/) operate on the master and its dependent layout slides and normal slides; they do not target just one normal slide.

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

A master slide defines the presentation's theme and shared formatting. A layout slide belongs to a master and defines one reusable arrangement of placeholders. Normal slides use those layouts and store slide-specific content.

**هل يمكنني نسخ شريحة تخطيط من عرض تقديمي إلى آخر؟**

Yes. Add a copy to the destination collection with the [addClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone) method. When copying between presentations, also verify fonts, themes, images, and other resources used by the source layout.

**ماذا يحدث عندما أقوم بتعديل تخطيط مُستخدم بالفعل؟**

Dependent slides inherit the layout changes unless they override the affected formatting or objects locally. Placeholder geometry and inherited styling can therefore change on many slides at once. Use [getDependingSlides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) to identify the affected slides before editing the layout.

**ماذا يحدث إذا قمت بإزالة تخطيط ما زال قيد الاستخدام؟**

Aspose.Slides throws a [PptxEditException](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pptxeditexception/). Reassign the dependent slides first, or use [removeUnusedLayoutSlides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) to remove only unreferenced layouts.