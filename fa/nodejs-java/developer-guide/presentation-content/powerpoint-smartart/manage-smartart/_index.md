---
title: مدیریت SmartArt در ارائه‌های PowerPoint با استفاده از JavaScript
linktitle: مدیریت SmartArt
type: docs
weight: 10
url: /fa/nodejs-java/manage-smartart/
keywords:
- SmartArt
- متن SmartArt
- نوع چیدمان
- خصوصیت مخفی
- نمودار سازمانی
- نمودار سازمانی تصویری
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "یاد بگیرید چگونه SmartArt در PowerPoint را با Aspose.Slides برای Node.js بسازید و ویرایش کنید با استفاده از نمونه‌های واضح کد JavaScript که سرعت طراحی اسلاید و خودکارسازی را افزایش می‌دهند."
---
## **نمای کلی**

SmartArt یک نمودار PowerPoint است که از گره‌ها، اشکال گره و یک طرح بندی ساخته می‌شود. با Aspose.Slides برای Node.js از طریق Java می‌توانید SmartArt ایجاد کنید، متن را از گره‌های آن بخوانید، طرح بندی آن را تغییر دهید، گره‌های پنهان را بررسی کنید، طرح بندی‌های نمودار سازمانی را پیکربندی کنید و نمودارهای سازمانی تصویری ایجاد کنید.

## **دریافت متن از یک شیء SmartArt**

یک گره SmartArt می‌تواند شامل یک یا چند شکل باشد. برای خواندن متن از اشکال گره، از طریق [SmartArt.getAllNodes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/getallnodes/) پیمایش کنید، سپس [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) بازگردانده‌شده توسط [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartshape/gettextframe/) را بخوانید.

این مثال به یک ارائه با حداقل یک اسلاید و یک شیء SmartArt به عنوان اولین شکل در آن اسلاید نیاز دارد. هر چارچوب متن موجود را در کنسول چاپ می‌کند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
        let smartArt = shape;
        let nodes = smartArt.getAllNodes();

        for (let nodeIndex = 0; nodeIndex < nodes.size(); nodeIndex++) {
            let node = nodes.get_Item(nodeIndex);
            let nodeShapes = node.getShapes();

            for (let shapeIndex = 0; shapeIndex < nodeShapes.size(); shapeIndex++) {
                let nodeShape = nodeShapes.get_Item(shapeIndex);

                if (nodeShape.getTextFrame() != null) {
                    console.log(nodeShape.getTextFrame().getText());
                }
            }
        }
    } else {
        console.log("The first shape is not a SmartArt object.");
    }
} finally {
    presentation.dispose();
}
```

## **تغییر نوع طرح بندی یک شیء SmartArt**

طرح بندی SmartArt تعیین می‌کند که گره‌ها چگونه مرتب و به هم متصل می‌شوند. مثال زیر یک شیء SmartArt با مقدار `BasicBlockList` از [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) ایجاد می‌کند، آن را به مقدار `BasicProcess` تغییر می‌دهد و ارائه را ذخیره می‌کند. موقعیت و اندازه‌ای که به [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addsmartart/) ارسال می‌شود برحسب پوینت اندازه‌گیری می‌شود. برای تغییر طرح بندی از [SmartArt.setLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setlayout/) استفاده کنید.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);
    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **بررسی اینکه آیا یک گره SmartArt پنهان است**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/ishidden/) نشان می‌دهد که آیا گره در مدل داده‌ای SmartArt پنهان است یا نه. گره‌های پنهان می‌توانند در ساختار وجود داشته باشند حتی زمانی که طرح بندی انتخاب شده آن‌ها را به عنوان عناصر نمودار قابل مشاهده نشان نمی‌دهد.

مثال زیر یک گره به شیء SmartArt که از مقدار `RadialCycle` در [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) استفاده می‌کند اضافه می‌کند و وضعیت پنهان بودن گره اضافه‌شده را بررسی می‌نماید. اگر گره پنهان باشد، پیغامی چاپ می‌کند و نمودار را ذخیره می‌کند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);
    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **دریافت یا تنظیم طرح بندی نمودار سازمانی**

برای نمودارهای SmartArt که از طرح بندی نمودار سازمانی استفاده می‌کنند، [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/getorganizationchartlayout/) و [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/setorganizationchartlayout/) تعیین می‌کنند که گره‌های فرزند تحت یک گره والد چگونه چیدمان شوند. برای مثال، می‌توانید گره‌های فرزند را طوری تنظیم کنید که از سمت چپ، راست یا هر دو سمت آویزان شوند، بسته به [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/) انتخاب‌شده.

مثال زیر یک نمودار سازمانی ایجاد می‌کند و طرح بندی گره اول را به مقدار `LeftHanging` در [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/) تنظیم می‌نماید. ایندکس صفر-پایه `0` اولین گره سطح بالایی را انتخاب می‌کند؛ گره‌های فرزند آن از چیدمان انتخاب‌شده استفاده می‌کنند. سپس ارائه ویرایش‌شده ذخیره می‌شود.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);
    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ایجاد یک نمودار سازمانی تصویری**

نمودار سازمانی تصویری یک طرح بندی SmartArt است که برای نمودارهای سلسله‌مراتبی شامل محل‌نگهدار تصویر طراحی شده است. هنگام افزودن شیء SmartArt به یک اسلاید، مقدار `PictureOrganizationChart` در [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) را استفاده کنید. این مثال یک نمودار با محل‌نگهدارهای تصویر ذخیره می‌کند؛ اما این محل‌نگهدارها را با تصاویر پر نمی‌کند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تبدیل نمودارهای قدیمی به گروهی از اشکال**

هنگامی که یک ارائه موجود را به‌روزرسانی می‌کنید، ممکن است نیاز داشته باشید یک نمودار سازمانی که اصلاً در PowerPoint 97–2003 ایجاد شده است را به‌روز کنید. Aspose.Slides این نمودارهای قدیمی را به عنوان اشیاء [LegacyDiagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/) نمایش می‌دهد. برای تبدیل یک نمودار به گروهی از اشکال به‌طوری که بتوانید عناصر بصری جداگانه را ویرایش کنید، از [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/converttogroupshape/) استفاده کنید. برای جزئیات، به [LegacyDiagram API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/) مراجعه کنید.

تبدیل، یک گروه جدید به مجموعه اشکال اضافه می‌کند بدون اینکه نمودار اصلی حذف شود. پس از تبدیل موفق، برای جلوگیری از محتوای duplicated، اصل را با [ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/remove/) حذف کنید. قبل از تبدیل، نمودارهای قدیمی را در یک لیست جمع‌آوری کنید تا افزودن و حذف اشکال باعث خراب شدن تکرار نشود.

مثال زیر یک ارائه را باز می‌کند، در هر اسلاید جستجو می‌کند، نمودارها را به گروهی از اشکال تبدیل می‌نماید و ارائه به‌روزشده را به صورت PPTX ذخیره می‌کند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("legacy-diagrams.ppt");
try {
    let slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        let slide = slides.get_Item(slideIndex);
        let shapes = slide.getShapes();
        let legacyDiagrams = [];
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            let shape = shapes.get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.ILegacyDiagram")) {
                legacyDiagrams.push(shape);
            }
        }

        for (let legacyDiagram of legacyDiagrams) {
            let groupShape = legacyDiagram.convertToGroupShape();

            if (groupShape != null) {
                shapes.remove(legacyDiagram);
            }
        }
    }

    presentation.save("modernized.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ارائه ذخیره‌شده شامل گروه‌های قابل ویرایش از اشکال به‌جای نمودارهای قدیمی تبدیل‌شده است و دیگر هیچ نمودار اصلی در کنار آن‌ها وجود ندارد. PPTX را در PowerPoint باز کنید تا عناصر جداگانه هر گروه را ویرایش کنید، مانند متن، پرکردن یا موقعیت آن‌ها.

## **پرسش‌های متداول**

**آیا SmartArt از آینه‌سازی یا معکوس‌سازی برای زبان‌های راست به چپ پشتیبانی می‌کند؟**

بله. متد [SmartArt.setReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setreversed/) جهت نمودار را از چپ به راست به راست به چپ یا بالعکس تغییر می‌دهد، به‌شرطی که طرح بندی انتخاب‌شده SmartArt از معکوس‌سازی پشتیبانی کند.

**چگونه می‌توانم SmartArt را به همان اسلاید یا به ارائه دیگری کپی کنم و قالب‌بندی را حفظ کنم؟**

می‌توانید [ShapeCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addclone/) را با [کلون کردن شکل SmartArt](/slides/fa/nodejs-java/shape-manipulations/) استفاده کنید یا [کلون کردن کل اسلاید](/slides/fa/nodejs-java/clone-slides/) که شامل SmartArt است. هر دو روش اندازه، موقعیت و قالب‌بندی را حفظ می‌کنند.

**چگونه می‌توانم SmartArt را به تصویر رستری برای پیش‌نمایش یا صادرات وب رندر کنم؟**

[رندر اسلاید](/slides/fa/nodejs-java/convert-powerpoint-to-png/) یا کل ارائه را به PNG یا JPEG تبدیل کنید. SmartArt به‌عنوان بخشی از اسلاید رندر می‌شود.

**چگونه می‌توانم یک شیء SmartArt خاص را در یک اسلاید پیدا کنم اگر چندین مورد وجود داشته باشد؟**

از [Shape.setAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setalternativetext/) یا [Shape.setName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setname/) برای اختصاص یک متن جایگزین متمایز یا نام به شکل SmartArt استفاده کنید، آن مقدار را در [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes) جستجو کنید و سپس بررسی کنید که شکل منطبق یک [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/) باشد.