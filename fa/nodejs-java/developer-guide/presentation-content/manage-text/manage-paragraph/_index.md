---
title: مدیریت پاراگراف‌های متن PowerPoint در JavaScript
linktitle: مدیریت پاراگراف
type: docs
weight: 40
url: /fa/nodejs-java/manage-paragraph/
aliases:
  - /nodejs-java/paragraph/
  - /nodejs-java/portion/
keywords:
- افزودن متن
- افزودن پاراگراف
- مدیریت متن
- مدیریت پاراگراف
- مدیریت بولت
- تورفتگی پاراگراف
- تورفتگی معلق
- بولت پاراگراف
- فهرست شماره‌دار
- فهرست بولت‌دار
- ویژگی‌های پاراگراف
- وارد کردن HTML
- متن به HTML
- پاراگراف به HTML
- پاراگراف به تصویر
- متن به تصویر
- صادر کردن پاراگراف
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "یاد بگیرید چگونه پاراگراف‌ها، بخش‌ها، بولت‌ها، فهرست‌های شماره‌دار، تورفتگی‌ها، محتوای HTML و تصاویر پاراگراف را با Aspose.Slides برای Node.js از طریق Java ایجاد و قالب‌بندی کنید."
---
## **مرور کلی**

Aspose.Slides for Node.js via Java متن را به‌صورت سلسله‌مراتبی از فریم‌های متنی، پاراگراف‌ها و بخش‌ها (Portion) نمایش می‌دهد:

* [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) فریم متنی داخل یک شکل را نشان می‌دهد و دسترسی به مجموعه پاراگراف‌های آن را فراهم می‌کند.
* [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) یک پاراگراف داخل فریم متنی را نمایش می‌دهد و دسترسی به بخش‌ها و قالب‌بندی سطح پاراگراف را فراهم می‌کند.
* [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) نمایانگر یک بخش متن داخل پاراگراف است. هر بخش می‌تواند متن و قالب‌بندی سطح کاراکتر خود را داشته باشد.

بنابراین یک پاراگراف می‌تواند متن با فونت‌ها، رنگ‌ها، اندازه‌ها و قالب‌بندی‌های مختلف را با استفاده از چندین بخش داشته باشد.

## **ایجاد و قالب‌بندی پاراگراف‌ها**

پاراگراف‌ها را در فریم متنی یک شکل ایجاد کنید و از بخش‌ها برای قالب‌بندی بخش‌های متنی جداگانه استفاده کنید. این بخش نشان می‌دهد چگونه چندین بخش را در هر پاراگراف ترکیب کنید و رنگ‌ها، اندازه فونت و سبک‌های مختلف را اعمال کنید.

### **ایجاد پاراگراف‌ها با بخش‌های متعدد**

مثال زیر به‌زبان JavaScript سه پاراگراف ایجاد می‌کند که هر کدام شامل سه بخش متنی در مجموعه‌ای هستند که توسط [Paragraph.getPortions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/getportions/) برگردانده می‌شود. ابتدا پاراگراف پیش‌فرض و بخش خالی آن را مجدداً استفاده می‌کند، سپس پاراگراف‌ها و بخش‌های باقی‌مانده را اضافه می‌نماید. قالب‌بندی از طریق [Portion.getPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/getportionformat/) اعمال می‌شود: اولین بخش در هر پاراگراف قرمز، بولد و 15 پوینت است؛ دومین بخش آبی، ایتالیک و 18 پوینت؛ بخش سوم قالب‌بندی پیش‌فرض خود را حفظ می‌کند:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    const textFrame = shape.getTextFrame();

    const firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new aspose.slides.Portion());
    firstParagraph.getPortions().add(new aspose.slides.Portion());

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    const paragraphCount = textFrame.getParagraphs().getCount();
    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        const portionCount = paragraph.getPortions().getCount();
        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex === 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex === 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ایجاد فهرست‌های بولت‌دار و شماره‌دار**

متن پاراگراف‌ها را به فهرست‌های دارای نماد، عدد یا تصویر سفارشی تبدیل کنید. مثال‌های این بخش شامل قالب‌بندی بولت، فهرست‌های چندسطحی و شماره‌گذاری سفارشی است.

### **ایجاد فهرست بولت‌دار یا شماره‌دار**

بولت‌ها و شماره‌گذاری، شناسایی آیتم‌های مرتبط را آسان‌تر می‌کند. در Aspose.Slides تنظیمات فهرست از طریق [BulletFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/) تعریف می‌شوند.

این مثال JavaScript یک بولت نمادین و یک آیتم شماره‌دار را به یک فریم متنی اضافه می‌کند. [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) نوع بولت را انتخاب می‌کند، در حالی که [BulletFormat.setChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setchar/) نماد را فراهم می‌کند و [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstyle/) سبک شماره‌گذاری را انتخاب می‌کند. هر دو آیتم از بولت‌های سیاه با ارتفاع 100 درصد و تورفتگی پاراگراف 25 پوینت استفاده می‌کنند:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const symbolParagraph = new aspose.slides.Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    symbolParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    const numberedParagraph = new aspose.slides.Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain));
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **استفاده از بولت‌های تصویری**

بولت‌های تصویری به شما امکان می‌دهند به‌جای نماد یا عدد از تصویر سفارشی استفاده کنید.

این مثال JavaScript فایل `image.png` را از پوشه کاری برنامه می‌خواند، تصویر را به مجموعه تصاویر ارائه به عنوان یک [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) اضافه می‌کند و به عنوان بولت پاراگراف استفاده می‌نماید. برای استفاده از بولت تصویری [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) فراخوانی می‌شود و تصویر از طریق [BulletFormat.getPicture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/getpicture/) اختصاص می‌یابد. [BulletFormat.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setheight/) برای اندازه‌گذاری بولت نسب به متن پاراگراف روی 100 درصد تنظیم می‌شود:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const bulletImage = aspose.slides.Images.fromFile("image.png");
    let presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Picture));
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", aspose.slides.SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **ایجاد فهرست چندسطحی**

[ParagraphFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setdepth/) را تنظیم کنید تا پاراگراف‌ها در سطوح مختلف فهرست قرار گیرند. سطح بالایی عمق `0` دارد.

این مثال JavaScript مقادیر [ParagraphFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setdepth/) را از 0 تا 3 به چهار پاراگراف اختصاص می‌دهد و سلسله‌مراتبی در یک فریم متنی ایجاد می‌کند. هر پاراگراف از بولت نمادین استفاده می‌کند؛ [BulletFormat.setChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setchar/) به‌صورت متناوب بین یک بولت گرد و یک خط تیره برای تمایز سطوح مجاور تغییر می‌کند:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    firstParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setDepth(java.newShort(0));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    secondParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setDepth(java.newShort(1));

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    thirdParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setDepth(java.newShort(2));

    const fourthParagraph = new aspose.slides.Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    fourthParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    fourthParagraph.getParagraphFormat().setDepth(java.newShort(3));

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **شروع شماره‌گذاری فهرست با مقادیر سفارشی**

از [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) برای تعیین عدد اولیه نمایش‌داده‌شده برای یک پاراگراف شماره‌دار استفاده کنید.

این مثال JavaScript [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) را برای استفاده از شماره‌گذاری در سه پاراگراف تنظیم می‌کند و مقدارهای [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) را به‌صورت 2، 3 و 7 اختصاص می‌دهد. مقدار شروع به‌صورت جداگانه برای هر پاراگراف پیکربندی می‌شود تا اعداد نمایش داده‌شده مقادیر میانی را رد کنند:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(2));
    textFrame.getParagraphs().add(firstParagraph);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(3));
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(7));
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **کنترل چیدمان پاراگراف و ویژگی‌های انتهایی**

حاشیه‌ها و تورفتگی‌های پاراگراف را تنظیم کنید تا موقعیت خط اول و خطوط بسته‌بندی‌شده را کنترل کنید. همچنین می‌توانید علامت انتهای پاراگراف را جدا از بخش‌های متنی قابل مشاهده قالب‌بندی کنید.

### **تنظیم تورفتگی خط اول**

از متد [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) برای کنترل تورفتگی خط اول یک پاراگراف استفاده کنید. این تنظیم فقط خط اول را نسبت به حاشیه چپ پاراگراف جابجا می‌کند. مقدار مثبت، خط اول را به راست می‌برد، در حالی که خطوط باقی‌مانده مطابق بدنهٔ پاراگراف می‌مانند.

وقتی نیاز به جابجایی کل پاراگراف دارید، از [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) استفاده کنید. وقتی فقط خط اول را می‌خواهید جابجا کنید، از [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) استفاده کنید.

مثال زیر سه پاراگراف را همان‌گونه [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) برابر با 20 پوینت و مقادیر [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) برابر با 0، 20 و 40 پوینت تنظیم می‌کند. خطوط اول به‌تدریج با افست بزرگ‌تر شروع می‌شوند، در حالی که خطوط بسته‌بندی‌شده همان حاشیهٔ چپ را حفظ می‌کنند:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![تورفتگی خط اول پاراگراف‌ها](first_line_indent.png)

### **تنظیم تورفتگی معلق (Hanging Indent)**

تورفتگی معلق یک چیدمان پاراگراف است که در آن خط اول نسبت به خطوط دیگر به سمت چپ شروع می‌شود. در Aspose.Slides این اثر را با متد [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) ایجاد می‌کنید. برای جابه‌جایی خط اول به چپ، مقدار تورفتگی را منفی کنید.

در عمل، [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) موقعیت چپ بدنهٔ پاراگراف را تعریف می‌کند و [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) موقعیت خط اول را نسبت به آن حاشیه تنظیم می‌کند. برای ایجاد تورفتگی معلق، حاشیهٔ چپ مثبت و تورفتگی منفی تنظیم کنید.

این قالب‌بندی برای فهرست‌ها، مراجع، واژه‌نامه‌ها و سایر پاراگراف‌هایی که خطوط بسته‌بندی‌شده باید زیر بدنهٔ پاراگراف نه زیر کاراکتر اول خط اول قرار گیرند، مفید است.

در مثال زیر مقادیر [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) برابر با 40 و 60 پوینت با مقادیر [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) برابر با -20 و -30 پوینت ترکیب می‌شوند. در هر پاراگراف خط اول به سمت چپ خطوط بسته‌بندی‌شده شروع می‌شود؛ پاراگراف دوم تورفتگی معلق عمیق‌تری دارد:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![تورفتگی معلق پاراگراف‌ها](hanging_indent.png)

### **تنظیم ویژگی‌های انتهای پاراگراف**

متد [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) قالب‌بندی علامت انتهای پاراگراف را کنترل می‌کند. مثال زیر یک [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) ایجاد می‌کند که در آن [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) روی 48 پوینت و [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLatinFont) روی Times New Roman تنظیم شده است. این قالب به علامت انتهای پاراگراف دوم اختصاص می‌یابد و بخش‌های متنی قابل مشاهده بدون تغییر می‌مانند:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getPortions().add(new aspose.slides.Portion("Sample text"));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion("Sample text 2"));

    const endParagraphFormat = new aspose.slides.PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تعداد خطوط رندر شده**

برای قوانین پاراگراف که بر بسته‌بندی خودکار و نقطه‌گذاری در انتهای خطوط تأثیر می‌گذارند، به بخش‌های [Control Line Breaking](/slides/fa/nodejs-java/text-formatting/#control-line-breaking) و [Control Hanging Punctuation](/slides/fa/nodejs-java/text-formatting/#control-hanging-punctuation) مراجعه کنید.

از [Paragraph.getLinesCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getLinesCount) برای شمارش خطوط اشغال‌شده توسط یک پاراگراف پس از چیدمان متن، شامل بسته‌بندی خودکار، استفاده کنید. این قابلیت هنگام بررسی طول متن و چیدمان در قالب‌های ارائه مفید است.

پاراگراف یک آیتم در [TextFrame.getParagraphs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/getparagraphs/) است و می‌تواند چندین خط رندر شده را اشغال کند. یک شکست خط صریح درون پاراگراف یک خط جدید ایجاد می‌کند بدون اینکه پاراگراف جدیدی بسازد. بسته‌بندی خودکار بر اساس عرض موجود خطوطی را ایجاد می‌کند بدون اینکه شکست‌های خط صریح به متن افزوده شوند. بنابراین شمارش پاراگراف‌ها یا کاراکترهای شکست خط، شمارش واقعی خطوط رندر شده را نمی‌دهد.

مثال زیر یک شکل متنی ایجاد می‌کند، خطوط آن را می‌شمارد، شکل را باریک‌تر می‌کند و سپس متن را با رشته‌ای کوتاه‌تر جایگزین می‌نماید. این مثال با استفاده از [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/) بسته‌بندی را فعال می‌کند و با [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setautofittype/) قابلیت خودانطباق را غیرفعال می‌کند تا عرض شکل کنترل بسته‌بندی را بدون کوچک‌سازی خودکار متن یا تغییر اندازه شکل انجام دهد. هر اندازه‌گیری از [Paragraph.getLinesCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getLinesCount) استفاده می‌کند. ابعاد شکل بر حسب پوینت هستند. در نهایت، مثال یک پاراگراف دیگر اضافه می‌کند و مجموع تعداد خطوط را در سراسر فریم متنی جمع می‌زند:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    console.log("Original width: " + paragraph.getLinesCount());

    shape.setWidth(150);
    console.log("Narrower shape: " + paragraph.getLinesCount());

    paragraph.setText("Short text.");
    console.log("Shorter text: " + paragraph.getLinesCount());

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Another paragraph.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    textFrame.getParagraphs().add(secondParagraph);

    let totalLineCount = 0;
    for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
        const currentParagraph = textFrame.getParagraphs().get_Item(i);
        totalLineCount += currentParagraph.getLinesCount();
    }
    console.log("Total lines in the text frame: " + totalLineCount);
} finally {
    presentation.dispose();
}
```

با این متن و این ابعاد، باریک‌تر کردن شکل تعداد خطوط را افزایش می‌دهد، در حالی که جایگزینی متن با رشته کوتاه‌تر آن را کاهش می‌دهد. شمارش دقیق می‌تواند بسته به در دسترس بودن و جایگزینی فونت، اندازه فونت، حاشیه‌ها، تورفتگی، بسته‌بندی و تنظیمات خودانطباق متفاوت باشد. هنگام بررسی یک قالب، از فونت‌ها و تنظیمات چیدمانی که برای محیط هدف مدنظر دارید استفاده کنید.

تعداد خطوط به‌تنهایی تعیین‌کنندهٔ سرریز بودن متن درون محفظه نیست. ارتفاع موجود، ارتفاع خطوط، فاصله پاراگراف و خط، و رفتار خودانطباق نیز مؤثرند؛ حتی یک خط واحد می‌تواند عرض موجود را در صورت غیرفعال بودن بسته‌بندی تجاوز کند.

## **وارد کردن و خروجی گرفتن محتوای پاراگراف**

از HTML برای وارد کردن متن به ارائه یا خروجی گرفتن پاراگراف‌های موجود برای استفاده بیرون از آن استفاده کنید. این بخش همچنین نشان می‌دهد چگونه پاراگراف‌های منفرد را به‌صورت تصویر رندر کنید، از جمله پاراگراف‌های موجود در سلول‌های جدول.

### **وارد کردن متن HTML به پاراگراف‌ها**

از [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) برای تبدیل نشانه‌گذاری HTML به پاراگراف‌ها و بخش‌ها در یک فریم متنی استفاده کنید.

این مثال JavaScript فایل `file.html` را از پوشه کاری برنامه می‌خواند و نشانه‌گذاری را به [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) می‌فرستد. پاراگراف پیش‌فرض فریم متنی را پاک می‌کند تا فریم تنها شامل محتوای وارد شده باشد. شکل مستطیلی حاشیهٔ 10‑پوینتی در هر سمت اسلاید ایجاد می‌کند:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeWidth = presentation.getSlideSize().getSize().getWidth() - 20;
    const shapeHeight = presentation.getSlideSize().getSize().getHeight() - 20;
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const html = fs.readFileSync("file.html", "utf8");
    shape.getTextFrame().getParagraphs().addFromHtml(html);
    presentation.save("html_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **خروجی گرفتن متن پاراگراف به HTML**

از [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) برای خروجی گرفتن یک بازهٔ انتخابی از پاراگراف‌ها به صورت HTML استفاده کنید. هنگام استفاده مجدد از متن ارائه در یک وب‌سایت، ممکن است بخواهید تأکید محلی را حفظ کنید بدون اینکه فونت، اندازه یا سبک‌های جعبهٔ متنی ارائه را منتقل کنید. با تنظیم [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/texttohtmlconversionoptions/settextinheritancelimit/) می‌توانید میزان ارث‌بری قالب‌بندی توسط خروجی‌گذار را کنترل کنید.

[نمونه ارائه را دانلود کنید](text-inheritance.pptx) و در پوشه کاری برنامه قرار دهید. اسلاید اول آن شامل یک شکل متنی است که متن «Inherited text; explicit red 18pt» را دارد. ورودی به‌صراحت از سطوح مختلف قالب‌بندی استفاده می‌کند:

- سبک متن پیش‌فرض ارائه، Calibri با سایز 28 pt را فراهم می‌کند.
- سبک متن سطح اول فریم متنی، متن آبی و ایتالیک را فراهم می‌کند.
- پاراگراف به‌صراحت متن بولد را تنظیم می‌کند.
- بخش دوم، «explicit red 18pt», به‌صراحت متن قرمز و سایز 18 pt را تنظیم می‌کند.

مثال کامل زیر همان پاراگراف‌ها را سه بار خروجی می‌دهد. [TextToHtmlConversionOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/texttohtmlconversionoptions/) به متد خروجی افزوده می‌شود و هر نتیجه به‌صورت یک فایل HTML جداگانهٔ UTF‑8 ذخیره می‌شود:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("text-inheritance.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null) {
            const paragraphs = textFrame.getParagraphs();

            const modes = [aspose.slides.TextInheritanceLimit.All, aspose.slides.TextInheritanceLimit.TextBox, aspose.slides.TextInheritanceLimit.ParagraphOnly];
            const fileNames = ["All.html", "TextBox.html", "ParagraphOnly.html"];

            for (let i = 0; i < modes.length; i++) {
                const options = new aspose.slides.TextToHtmlConversionOptions();
                options.setTextInheritanceLimit(modes[i]);

                const html = paragraphs.exportToHtml(0, paragraphs.getCount(), options);
                fs.writeFileSync(fileNames[i], html, "utf8");
            }
        } else {
            console.log("The first shape does not contain a text frame.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

HTML تولید شده CSS زیر را برای اولین بخش «Inherited text; » دارد. جدول موارد مربوطه را نشان می‌دهد؛ سایر خصوصیات تولید شده برای وضوح حذف شده‌اند.

| خروجی | CSS مربوط به اولین بخش | ظاهر |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | متن آبی، بولد، ایتالیک با سایز 28 pt در Calibri، در صورتی که این فونت موجود باشد. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | متن آبی، بولد، ایتالیک؛ صفحه یا مرورگر فونت و سایز را فراهم می‌کند. |
| `ParagraphOnly.html` | `font-weight:bold` | متن بولد؛ صفحه یا مرورگر فونت، سایز، رنگ و سبک ایتالیک را تأمین می‌کند. |

بخش دوم `color:#ff0000`، `font-size:18pt` و `font-weight:bold` را در هر سه خروجی حفظ می‌کند. همچنین ایتالیک در `All` و `TextBox` حفظ می‌شود ولی در `ParagraphOnly` نیست. محدود کردن ارث‌بری به این معنی است که قالب‌بندی اختصاصی به پاراگراف یا بخش حذف نمی‌شود.

فایل‌ها را در همان مرورگر باز کنید تا مقایسه کنید. در دو حالت محدود، خصوصیات CSS حذف شده توسط سبک‌های صفحه مقصد یا پیش‌فرض‌های مرورگر حل می‌شوند، بنابراین ظاهر نهایی به محل استفادهٔ HTML بستگی دارد.

### **رندر یک پاراگراف به عنوان تصویر**

[Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) یک پاراگراف منفرد را مستقیم رندر می‌کند و یک [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/) برمی‌گرداند. نتیجه را با [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) به فایل یا جریان ذخیره کنید. نیازی به رندر شکل شامل‌کننده یا برش دستی bitmap نیست.

[Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) می‌تواند `null` بازگرداند اگر پاراگراف در مجموعه والد یافت نشود، مرزهای رندر معتبری نداشته باشد یا قابل رندر نباشد. پیش از ذخیره‌سازی نتیجه را بررسی کنید و پس از استفاده تصویر بازگردانده‌شده را آزاد کنید.

#### **رندر پاراگراف با مقیاس پیش‌فرض**

مثال یک ارائه با یک اسلاید ایجاد می‌کند که اولین شکل آن یک جعبهٔ متنی حاوی سه پاراگراف است.

![جعبهٔ متنی با سه پاراگراف](paragraph_to_image_input.png)

مثال زیر پاراگراف دوم (اندیس 1) را انتخاب می‌کند و بدون پارامترهای مقیاس به [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) فراخوانی می‌کند. ابتدا بررسی می‌کند که شکل پاراگراف موردنظر را دارد و رندر تصویر موفق بوده است، سپس با [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) آن را به فرمت PNG ذخیره می‌کند. بلوک `finally` پس از استفاده تصویر را آزاد می‌کند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 100);
    const sourceTextFrame = sourceShape.getTextFrame();
    sourceTextFrame.getParagraphs().clear();
    for (const text of ["First paragraph", "Second paragraph", "Third paragraph"]) {
        const sourceParagraph = new aspose.slides.Paragraph();
        sourceParagraph.setText(text);
        sourceTextFrame.getParagraphs().add(sourceParagraph);
    }
    const shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null && textFrame.getParagraphs().getCount() > 1) {
            const paragraph = textFrame.getParagraphs().get_Item(1);
            const paragraphImage = paragraph.getImage();

            if (paragraphImage !== null) {
                try {
                    paragraphImage.save("paragraph.png", aspose.slides.ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                console.log("The paragraph could not be rendered.");
            }
        } else {
            console.log("The expected paragraph was not found.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

نتیجه:

![تصویر پاراگراف](paragraph_to_image_output.png)

#### **رندر پاراگراف در یک سلول جدول با مقیاس**

از نسخهٔ overload شدهٔ [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) که پارامترهای `scaleX` و `scaleY` را می‌پذیرد استفاده کنید تا مقیاس افقی و عمودی را تنظیم کنید. مثال زیر یک جدول می‌سازد، پاراگراف را در اولین سلول آن با دو برابر عرض و ارتفاع پیش‌فرض رندر می‌کند و نتیجه را به‌صورت تصویر PNG ذخیره می‌نماید.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const columnWidths = java.newArray("double", [300]);
    const rowHeights = java.newArray("double", [80]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    const paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    const paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage !== null) {
        try {
            paragraphImage.save("table_paragraph.png", aspose.slides.ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        console.log("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

مقدار مقیاس `1` محور مربوطه را در اندازه پیش‌فرض پیکسل نگه می‌دارد. برای مثال، مقدار `2` برای هر دو عامل، عرض و ارتفاع تصویر را تقریباً دو برابر می‌کند که منجر به چهار برابر پیکسل می‌شود. عوامل بزرگتر معمولاً متن تیزتر برای بزرگ‌نمایی یا خروجی با وضوح بالا تولید می‌کند، اما حافظه و حجم فایل را نیز افزایش می‌دهد. عوامل زیر `1` تصویرهای کوچکتر با جزئیات کمتر تولید می‌کنند. برای حفظ نسبت تصویر پاراگراف از عوامل برابر استفاده کنید؛ عوامل افقی و عمودی متفاوت خروجی را به‌صورت مستقل کش می‌دهند.

رندر کل شکل با [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) زمانی مفید است که خروجی نیاز به نمایش پر، حاشیه یا سایر زمینه‌های بصری شکل داشته باشد. برای تصویر تنها پاراگراف، از [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) استفاده کنید.

## **سؤالات متداول**

**آیا می‌توانم بسته‌بندی خطوط داخل فریم متنی را به‌طور کامل غیرفعال کنم؟**

بله. با تنظیم [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/) بسته‌بندی را غیرفعال کنید تا خطوط در لبه‌های فریم متنی شکسته نشوند.

**چگونه می‌توانم مرزهای دقیق روی‌اسلاید یک پاراگراف خاص را به‌دست آورم؟**

از [Paragraph.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/getrect/) برای دریافت مستطیل محدود‌کننده پاراگراف استفاده کنید. [Portion.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/getrect/) مرزهای یک بخش منفرد را فراهم می‌کند.

**کنترل تراز پاراگراف (چپ، راست، مرکز یا راست‌چین) در کجا انجام می‌شود؟**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setalignment/) تنظیمی در سطح پاراگراف است و بر تمام پاراگراف اعمال می‌شود، صرف‌نظر از قالب‌بندی بخش‌های منفرد.

برای تراز عمودی بخش‌های مختلف با اندازه‌های فونت متفاوت در هر خط، به بخش [Align Fonts Within a Line](/slides/fa/nodejs-java/text-formatting/#align-fonts-within-a-line) مراجعه کنید.

**آیا می‌توانم زبان تصحیح نوشتاری را برای بخشی از یک پاراگراف تنظیم کنم؟**

بله. برای بخش‌های منفرد [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) تنظیم کنید تا یک پاراگراف بتواند متن در چندین زبان مختلف داشته باشد.