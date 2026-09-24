---
title: مدیریت پاراگراف‌های متن پاورپوینت در جاوااسکریپت
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
- پاورپوینت
- ارائه
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "یاد بگیرید چگونه با Aspose.Slides برای Node.js از طریق Java، پاراگراف‌ها، بخش‌ها، بولت‌ها، فهرست‌های شماره‌دار، تورفتگی‌ها، محتوای HTML و تصاویر پاراگراف را ایجاد و فرمت‌بندی کنید."
---
## **نمایش کلی**

Aspose.Slides for Node.js via Java متن را به صورت یک سلسله‌مراتب از فریم‌های متن، پاراگراف‌ها و بخش‌ها (Portion) نمایش می‌دهد:

* [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) نشان‌دهندهٔ محفظهٔ متن در یک شکل است و دسترسی به مجموعهٔ پاراگراف‌های آن را فراهم می‌کند.
* [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/) نمایانگر یک پاراگراف در یک فریم متن است و دسترسی به بخش‌ها و فرمت‌گذاری در سطح پاراگراف را می‌دهد.
* [Portion](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/) نمایانگر یک بخش متنی در داخل یک پاراگراف است. هر بخش می‌تواند متن و فرمت‌گذاری کاراکتری خود را داشته باشد.

به این ترتیب یک پاراگراف می‌تواند متن با فونت‌ها، رنگ‌ها، اندازه‌ها و فرمت‌های مختلف را با استفاده از چندین بخش داشته باشد.

## **ایجاد و فرمت‌بندی پاراگراف‌ها**

### **ایجاد پاراگراف‌ها با چندین بخش**

مراحل زیر یک فریم متن با سه پاراگراف، هر کدام شامل سه بخش، ایجاد می‌کند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید مربوطه را از طریق ایندکس آن دریافت کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید.
5. از پاراگراف پیش‌فرض استفاده کنید و دو شیء دیگر [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/) را به فریم متن اضافه کنید.
6. به اندازه کافی شیء [Portion](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/) برای هر پاراگراف اضافه کنید تا هر کدام شامل سه بخش شوند. پاراگراف پیش‌فرض در حال حاضر یک بخش خالی دارد.
7. متن هر بخش را تنظیم کنید.
8. فرمت‌گذاری کاراکتری را از طریق [Portion.getPortionFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/getportionformat/) اعمال کنید.
9. ارائه تغییر یافته را ذخیره کنید.

این مثال JavaScript مراحل را پیاده‌سازی می‌کند:

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

### **ایجاد فهرست بولت‌دار یا شماره‌دار**

بولت‌ها و شماره‌گذاری موارد مرتبط را برای مرور سریع‌تر قابل شناسایی می‌کنند. در Aspose.Slides تنظیمات فهرست از طریق [BulletFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bulletformat/) تعریف می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید مربوطه را از طریق ایندکس آن دریافت کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) به اسلاید انتخابی اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض را از فریم متن حذف کنید.
6. یک [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/) برای یک بولت نماد ایجاد کنید.
7. [BulletFormat.setType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bulletformat/settype/) را به [BulletType.Symbol](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bullettype/) تنظیم کنید و کاراکتر بولت را مشخص کنید.
8. متن پاراگراف، تورفتگی، رنگ بولت و ارتفاع بولت را تنظیم کنید.
9. پاراگراف را به فریم متن اضافه کنید.
10. یک پاراگراف دوم ایجاد کنید و [BulletFormat.setType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bulletformat/settype/) را به [BulletType.Numbered](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bullettype/) تنظیم کنید.
11. سبک بولت شماره‌دار را پیکربندی کنید و پاراگراف را به فریم متن اضافه کنید.
12. ارائه را ذخیره کنید.

این مثال JavaScript یک بولت نماد و یک بولت شماره‌دار ایجاد می‌کند:

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

بولت‌های تصویری به شما امکان می‌دهند به جای نماد یا عدد، یک تصویر دلخواه استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید مربوطه را از طریق ایندکس آن دریافت کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) اضافه کنید و به [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) آن دسترسی پیدا کنید.
4. پاراگراف پیش‌فرض را از فریم متن حذف کنید.
5. تصویر بولت را بارگذاری کرده و به مجموعه تصویر ارائه به عنوان یک [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) اضافه کنید.
6. یک [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/) ایجاد کنید و متن آن را تنظیم کنید.
7. [BulletFormat.setType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bulletformat/settype/) را به [BulletType.Picture](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bullettype/) تنظیم کنید.
8. تصویر را از طریق [BulletFormat.getPicture](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bulletformat/getpicture/) اختصاص دهید و ارتفاع بولت را تنظیم کنید.
9. پاراگراف را به فریم متن اضافه کنید.
10. ارائه تغییر یافته را ذخیره کنید.

این مثال JavaScript یک بولت تصویری ایجاد می‌کند:

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

[ParagraphFormat.setDepth](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setdepth/) را تنظیم کنید تا پاراگراف‌ها در سطوح مختلف فهرست قرار گیرند. سطح بالایی دارای عمق `0` است.

1. یک [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید و به یک اسلاید دسترسی پیدا کنید.
2. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) اضافه کنید و پاراگراف پیش‌فرض را از فریم متن آن پاک کنید.
3. چهار پاراگراف ایجاد کنید و نمادهای بولت آن‌ها را پیکربندی کنید.
4. مقدارهای [ParagraphFormat.setDepth](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setdepth/) آنها را به ترتیب `0`، `1`، `2` و `3` تنظیم کنید.
5. پاراگراف‌ها را به فریم متن اضافه کنید و ارائه را ذخیره کنید.

این مثال JavaScript یک فهرست بولت‌دار چهار سطحی ایجاد می‌کند:

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

### **شروع شماره‌گذاری آیتم‌های فهرست با مقادیر سفارشی**

از [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) برای تعیین شماره اولیه نمایش داده شده برای یک پاراگراف شماره‌دار استفاده کنید.

1. یک [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید و یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
2. پاراگراف پیش‌فرض را از فریم متن شکل پاک کنید.
3. سه پاراگراف شماره‌دار ایجاد کنید.
4. برای پاراگراف‌های مربوطه، [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) را به ترتیب `2`، `3` و `7` تنظیم کنید.
5. پاراگراف‌ها را به فریم متن اضافه کنید و ارائه را ذخیره کنید.

این مثال JavaScript به هر پاراگراف یک شماره شروع سفارشی اختصاص می‌دهد:

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

### **تنظیم تورفتگی اولین خط**

از [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setindent/) برای کنترل تورفتگی اولین خط یک پاراگراف استفاده کنید. این متد فقط اولین خط را نسبت به حاشیهٔ چپ پاراگراف حرکت می‌دهد. مقدار مثبت اولین خط را به سمت راست می‌برد، در حالی که خطوط باقی‌مانده به بدن پاراگراف تراز می‌مانند.

زمانی که نیاز به جابه‌جایی کل پاراگراف دارید، از [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) استفاده کنید. برای جابه‌جایی فقط اولین خط، از [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setindent/) استفاده کنید.

مثال زیر چند پاراگراف ایجاد می‌کند و مقادیر مختلف [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setindent/) را برای نشان دادن تأثیر تورفتگی اولین خط بر چیدمان پاراگراف اعمال می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید هدف را دریافت کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض را حذف کنید.
5. چند پاراگراف ایجاد کنید و مقادیر مختلف [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setindent/) را برای آنها تنظیم کنید.
6. پاراگراف‌ها را به فریم متن اضافه کنید.
7. ارائه تغییر یافته را ذخیره کنید.

این کد نحوه تنظیم تورفتگی پاراگراف را نشان می‌دهد:

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

![The first-line indent of the paragraphs](first_line_indent.png)

### **تنظیم تورفتگی معلق**

تورفتگی معلق یک چیدمان پاراگراف است که در آن اولین خط در سمت چپ خطوط باقی‌مانده شروع می‌شود. در Aspose.Slides این اثر را با [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setindent/) ایجاد می‌کنید. برای جابه‌جایی اولین خط به سمت چپ، مقدار منفی به این متد بدهید.

در عمل، [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) موقعیت چپ بدنهٔ پاراگراف را تعریف می‌کند و [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setindent/) موقعیت اولین خط را نسبت به آن حاشیه تعیین می‌کند. برای ایجاد تورفتگی معلق، مقدار مثبت به `setMarginLeft` و مقدار منفی به `setIndent` بدهید.

این فرمت‌بندی برای کتابشناسی‌ها، مراجعات، ورودی‌های واژه‌نامه و سایر پاراگراف‌هایی که خطوط بسته‌بندی شده باید زیر بدنهٔ پاراگراف تراز شوند، مفید است.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید هدف را دریافت کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض را حذف کنید.
5. پاراگراف‌ها ایجاد کنید و برای هر کدام مقدار مثبت به [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) بدهید.
6. مقدار منفی به [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setindent/) بدهید تا اثر تورفتگی معلق ایجاد شود.
7. پاراگراف‌ها را به فریم متن اضافه کنید.
8. ارائه تغییر یافته را ذخیره کنید.

این کد نحوه تنظیم تورفتگی معلق برای یک پاراگراف را نشان می‌دهد:

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

![The hanging indent of the paragraphs](hanging_indent.png)

### **تنظیم ویژگی‌های انتهایی پاراگراف**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) فرمت علامت پایان پاراگراف را کنترل می‌کند. مثال زیر اندازهٔ قلم و فونت لاتین را به علامت پایان پاراگراف دوم اختصاص می‌دهد:

1. یک [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد یا بارگذاری کنید و به یک اسلاید دسترسی پیدا کنید.
2. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) اضافه کنید و پاراگراف پیش‌فرض آن را پاک کنید.
3. دو پاراگراف ایجاد کنید و به آنها بخش‌های متنی اضافه کنید.
4. یک [PortionFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portionformat/) برای علامت پایان پاراگراف دوم ایجاد کنید.
5. [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) و [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#setLatinFont) را تنظیم کنید.
6. فرمت را با [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) اختصاص دهید و ارائه را ذخیره کنید.

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

## **شمارش خطوط رندر شده**

از [Paragraph.getLinesCount](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/#getLinesCount) برای شمارش خطوطی که پس از چیدمان متن یک پاراگراف اشغال می‌کند (شامل پیچش خودکار) استفاده کنید. این روش برای بررسی طول متن و چیدمان در الگوهای ارائه مفید است.

یک پاراگراف در [TextFrame.getParagraphs](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#getParagraphs) یک مورد است و می‌تواند چندین خط رندر شده اشغال کند. یک شکستن خط صریح داخل پاراگراف یک خط جدید ایجاد می‌کند بدون اینکه پاراگراف دیگری ساخته شود. پیچش خودکار خطوط را بر پایهٔ عرض موجود ایجاد می‌کند بدون اینکه کاراکترهای شکستن خط صریح را به متن اضافه کند. بنابراین شمارش پاراگراف‌ها یا کاراکترهای شکستن خط، تعداد خطوط رندر شده را نمی‌دهد.

مثال زیر یک شکل متنی می‌سازد، خطوط آن را می‌شمارد، شکل را باریک می‌کند و سپس متن را با یک رشته کوتاهتر جایگزین می‌کند. پیچش فعال است و خودکار تنظیم‌اندازه (autofit) غیرفعال است تا عرض شکل کنترل‌کنندهٔ پیچش باشد بدون اینکه متن یا شکل به‌طور خودکار کوچک شود. ابعاد شکل بر حسب نقطه (points) است. در نهایت، مثال یک پاراگراف دیگر اضافه می‌کند و تعداد خطوط را در سراسر فریم متن جمع می‌زند.

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

با این متن و این ابعاد، باریک‌سازی شکل تعداد خطوط را افزایش می‌دهد، در حالی که جایگزینی متن با رشتهٔ کوتاهتر آن را کاهش می‌دهد. شمارش دقیق می‌تواند بسته به در دسترس بودن فونت، جایگزینی، اندازهٔ قلم، حاشیه‌ها، تورفتگی، پیچش و تنظیمات autofit متفاوت باشد. برای بررسی یک الگو، از فونت‌ها و تنظیمات چیدمان هدف‌محور استفاده کنید.

تعداد خطوط به تنهایی تعیین‌کنندهٔ overflow متن نیست. ارتفاع موجود، ارتفاع خطوط، فاصلهٔ بین پاراگراف‌ها و خطوط، و رفتار autofit نیز مهم هستند؛ حتی یک خط می‌تواند عرض موجود را هنگام غیرفعال بودن پیچش تجاوز کند.

## **واردات و صادرات محتوای پاراگراف**

### **وارد کردن متن HTML به پاراگراف‌ها**

از [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) برای تبدیل علامت‌گذاری HTML به پاراگراف‌ها و بخش‌ها در یک فریم متن استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. یک اسلاید دریافت کنید و یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) اضافه کنید.
3. به [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض را پاک کنید.
4. رشتهٔ HTML منبع را تعریف یا خوانده کنید.
5. رشتهٔ HTML را به [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) پاس دهید.
6. ارائه تغییر یافته را ذخیره کنید.

این مثال JavaScript HTML را به یک فریم متن وارد می‌کند:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapeWidth = presentation.getSlideSize().getSize().getWidth() - 20;
    const shapeHeight = presentation.getSlideSize().getSize().getHeight() - 20;
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const html = "<p><b>Aspose.Slides</b> imports HTML text into presentation paragraphs.</p>";
    shape.getTextFrame().getParagraphs().addFromHtml(html);
    presentation.save("html_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **صادرات متن پاراگراف به HTML**

از [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) برای خروجی‌گیری از یک بازهٔ انتخابی پاراگراف‌ها به صورت HTML استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد یا بارگذاری کنید.
2. اسلاید را دسترسی پیدا کنید و [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) شامل متن را بیابید.
3. به [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید.
4. با ارائهٔ شاخص پاراگراف شروع و تعداد پاراگراف‌های مورد نظر، [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) را فراخوانی کنید.
5. رشتهٔ HTML بازگشتی را در فایلی بنویسید.

این مثال JavaScript خودکفا یک شکل متنی می‌سازد و تمام پاراگراف‌های آن را صادر می‌کند:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

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
        if (textFrame !== null) {
            const paragraphs = textFrame.getParagraphs();
            const html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            fs.writeFileSync("paragraphs.html", html, "utf8");
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

### **رندر یک پاراگراف به عنوان تصویر**

[Paragraph.getImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/#getImage) یک پاراگراف منفرد را مستقیماً رندر می‌کند و یک [IImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/iimage/) بر می‌گرداند. نتیجه را با [IImage.save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/iimage/#save) به فایل ذخیره کنید. نیازی به رندر شکل حاوی آن یا برش دستی bitmap ندارید.

[Paragraph.getImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/#getImage) می‌تواند `null` برگرداند اگر پاراگراف در مجموعه والد پیدا نشود، مرزهای رندر معتبری نداشته باشد یا قابل رندر نباشد. قبل از ذخیره بررسی کنید و پس از استفاده تصویر برگشتی را آزاد کنید.

#### **رندر پاراگراف با مقیاس پیش‌فرض**

جعبه متن زیر شامل سه پاراگراف است:

![The text box with three paragraphs](paragraph_to_image_input.png)

مثال زیر پاراگراف دوم را در یک شکل متنی عادی با مقیاس پیش‌فرض رندر می‌کند و تصویر خروجی را به فرمت PNG ذخیره می‌سازد. بلوک `finally` اطمینان می‌دهد که تصویر به درستی آزاد می‌شود.

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

![The paragraph image](paragraph_to_image_output.png)

#### **رندر پاراگراف در سلول جدول با مقیاس‌دهی**

از بارگذاری [Paragraph.getImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/#getImage) که پارامترهای `scaleX` و `scaleY` را می‌پذیرد استفاده کنید تا عوامل مقیاس افقی و عمودی را تنظیم کنید. مثال زیر یک جدول می‌سازد، پاراگراف را در اولین سلول آن با دو برابر عرض و ارتفاع پیش‌فرض رندر می‌کند و نتیجه را به‌صورت تصویر PNG ذخیره می‌کند.

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

یک عامل مقیاس `1` آن محور را در اندازهٔ پیش‌فرض پیکسل نگه می‌دارد. به عنوان مثال، مقدار `2` برای هر دو عامل تصویری با عرض و ارتفاع تقریباً دو برابر ابعاد پیش‌فرض تولید می‌کند که چهار برابر پیکسل دارد. عوامل بزرگتر معمولاً برای زوم یا خروجی با وضوح بالا متن واضح‌تری تولید می‌کنند، اما مصرف حافظه و حجم فایل را نیز افزایش می‌دهند. عوامل زیر `1` تصویرهای کوچکتر با جزئیات کمتر می‌سازند. برای حفظ نسبت عرض به ارتفاع پاراگراف، از عوامل برابر استفاده کنید؛ عوامل متفاوت افقی و عمودی تصویر را به‌صورت مستقل کشیده می‌کنند.

رندر کل یک شکل با [Shape.getImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/#getImage) زمانی مفید است که خروجی نیاز به شامل پرکن، حاشیه یا زمینهٔ بصری شکل داشته باشد. برای تصویر فقط پاراگراف، از [Paragraph.getImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/#getImage) استفاده کنید.

## **سوالات متداول**

**آیا می‌توانم به‌طور کامل پیچش خطوط داخل یک فریم متن را غیرفعال کنم؟**

بله. برای غیرفعال کردن پیچش، [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframeformat/setwraptext/) را تنظیم کنید تا خطوط در لبه‌های فریم متن شکسته نشوند.

**چگونه می‌توانم محدودهٔ دقیق بر روی اسلاید یک پاراگراف خاص را دریافت کنم؟**

از [Paragraph.getRect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/getrect/) برای دریافت مستطیل مرزی پاراگراف استفاده کنید. [Portion.getRect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/#getRect) مرزهای یک بخش منفرد را فراهم می‌کند.

**محل کنترل تراز پاراگراف (چپ، راست، مرکز یا توزیع) کجاست؟**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setalignment/) یک تنظیم سطح پاراگراف است و بر کل پاراگراف اعمال می‌شود، صرف‌نظر از فرمت‌بندی بخش‌های منفرد.

**آیا می‌توانم زبان اصلاح‌گری را برای بخشی از یک پاراگراف تنظیم کنم؟**

بله. برای بخش‌های منفرد [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) را تنظیم کنید؛ به این ترتیب یک پاراگراف می‌تواند متنی در چند زبان مختلف داشته باشد.