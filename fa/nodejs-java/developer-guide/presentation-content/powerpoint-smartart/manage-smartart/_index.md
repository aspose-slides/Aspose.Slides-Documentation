---
title: مدیریت SmartArt در ارائه‌های PowerPoint با استفاده از JavaScript
linktitle: مدیریت SmartArt
type: docs
weight: 10
url: /fa/nodejs-java/manage-smartart/
keywords:
- SmartArt
- متن SmartArt
- نوع طرح
- ویژگی مخفی
- نمودار سازمانی
- نمودار سازمانی تصویری
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "یاد بگیرید که با استفاده از Aspose.Slides برای Node.js، SmartArt در PowerPoint را با نمونه‌های واضح کد JavaScript بسازید و ویرایش کنید تا طراحی اسلایدها و خودکارسازی را سرعت بخشید."
---
## **نمای کلی**

SmartArt یک نمودار PowerPoint است که از گره‌ها، اشکال گره‌ها و یک طرح ساخته شده است. با Aspose.Slides برای Node.js از طریق Java، می‌توانید SmartArt ایجاد کنید، متن را از گره‌های آن بخوانید، طرح آن را تغییر دهید، گره‌های مخفی را بازرسی کنید، طرح‌های نمودار سازمانی را پیکربندی کنید و نمودارهای سازمانی تصویری ایجاد کنید.

```javascript
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
    }
} finally {
    presentation.dispose();
}
```

## **دریافت متن از شیء SmartArt**

یک گره در SmartArt می‌تواند یک یا چند شکل داشته باشد. برای خواندن متن قابل مشاهده، از طریق [SmartArt.getAllNodes](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/smartart/#getAllNodes--) مرور کنید، سپس [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) را که توسط [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/smartartshape/#getTextFrame--) برگردانده می‌شود، بخوانید.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تغییر نوع طرح شیء SmartArt**

طرح SmartArt کنترل می‌کند که گره‌ها چگونه چیده و متصل می‌شوند. مثال زیر یک شیء SmartArt را با مقدار `BasicBlockList` از [SmartArtLayoutType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/smartartlayouttype/) ایجاد می‌کند، آن را به مقدار `BasicProcess` تغییر می‌دهد و ارائه را ذخیره می‌کند.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);

    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **بررسی اینکه آیا یک گره SmartArt مخفی است**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/smartartnode/ishidden/) نشان می‌دهد که آیا گره در مدل داده‌ای SmartArt مخفی است یا نه. گره‌های مخفی می‌توانند در ساختار وجود داشته باشند حتی زمانی که طرح انتخاب‌شده آن‌ها را به عنوان عناصر نمودار قابل مشاهده نشان نمی‌دهد.

مثال زیر یک گره به شیء SmartArt اضافه می‌کند که از مقدار `RadialCycle` در [SmartArtLayoutType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/smartartlayouttype/) استفاده می‌کند و وضعیت مخفی بودن گره را بررسی می‌کند.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);

    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **دریافت یا تنظیم طرح نمودار سازمانی**

برای نمودارهای SmartArt که از طرح نمودار سازمانی استفاده می‌کنند، [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/smartartnode/#getOrganizationChartLayout--) و [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/smartartnode/#setOrganizationChartLayout-int-) تعریف می‌کنند که گره‌های فرزند تحت یک گره والد چگونه چیده شوند. به عنوان مثال، می‌توانید گره‌های فرزند را طوری تنظیم کنید که از سمت چپ، راست یا هر دو طرف آویزان شوند، بسته به [OrganizationChartLayoutType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/organizationchartlayouttype/) انتخاب‌شده.

مثال زیر یک نمودار سازمانی ایجاد می‌کند و طرح گرهٔ اول را به مقدار `LeftHanging` در [OrganizationChartLayoutType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/organizationchartlayouttype/) تنظیم می‌نماید.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ایجاد نمودار سازمانی تصویری**

نمودار سازمانی تصویری یک طرح SmartArt است که برای نمودارهای سلسله‌مراتبی شامل جای‌گاه‌های تصویر طراحی شده است. هنگام افزودن شیء SmartArt به اسلاید، از مقدار `PictureOrganizationChart` در [SmartArtLayoutType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/smartartlayouttype/) استفاده کنید.

## **سوالات متداول**

**آیا SmartArt از آینه‌کردن یا معکوس‌کردن برای زبان‌های راست به چپ پشتیبانی می‌کند؟**

بله. متد [SmartArt.setReversed](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/smartart/setreversed/) مسیر نمودار را از چپ‑به‑راست به راست‑به‑چپ یا برعکس تغییر می‌دهد هنگامی که طرح انتخاب‌شدهٔ SmartArt از معکوس‌سازی پشتیبانی می‌کند.

**چگونه می‌توانم SmartArt را به همان اسلاید یا به ارائهٔ دیگری کپی کنم در حالی که قالب‌بندی حفظ شود؟**

می‌توانید با استفاده از [clone the SmartArt shape](/slides/fa/nodejs-java/shape-manipulations/) همراه با [ShapeCollection.addClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapecollection/addclone/) یا با [clone the whole slide](/slides/fa/nodejs-java/clone-slides/) که شامل SmartArt است، SmartArt را کپی کنید. هر دو روش اندازه، موقعیت و قالب‌بندی را حفظ می‌کنند.

**چگونه می‌توانم SmartArt را به یک تصویر رستر برای پیش‌نمایش یا صادرات وب رندر کنم؟**

[Render the slide](/slides/fa/nodejs-java/convert-powerpoint-to-png/) یا کل ارائه را به PNG یا JPEG رندر کنید. SmartArt به‌عنوان بخشی از اسلاید رندر می‌شود.

**چگونه می‌توانم یک شیء SmartArt خاص را در یک اسلاید پیدا کنم اگر چندین مورد وجود داشته باشد؟**

یک مقدار متمایز برای [Shape.setAlternativeText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/setalternativetext/) یا [Shape.setName](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/setname/) بر روی شکل SmartArt تنظیم کنید، آن مقدار را در [BaseSlide.getShapes](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseslide/#getShapes) جستجو کنید، و سپس بررسی کنید که شکل یافت‌شده یک [SmartArt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/smartart/) است.