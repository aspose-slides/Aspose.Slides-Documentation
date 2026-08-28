---
title: مدیریت پاراگراف‌های متنی پاورپوینت در جاوااسکریپت
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
  - مدیریت نقطه
  - تورفتگی پاراگراف
  - تورفتگی معلق
  - نقطه پاراگراف
  - فهرست شماره‌دار
  - فهرست نقطه‌ای
  - خواص پاراگراف
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
description: "یاد بگیرید چگونه پاراگراف‌ها، بخش‌ها، نقطه‌ها، فهرست‌های شماره‌دار، تورفتگی‌ها، محتوای HTML و تصاویر پاراگراف را با Aspose.Slides برای Node.js از طریق Java ایجاد و قالب‌بندی کنید."
---
## **بررسی کلی**

Aspose.Slides for Node.js via Java متن را به صورت یک سلسله‌مراتب از چارچوب‌های متنی (TextFrame)، پاراگراف‌ها و بخش‌ها (Portion) نمایش می‌دهد:

* [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) متن داخل یک شکل را در خود نگه می‌دارد و دسترسی به مجموعه پاراگراف‌های آن را فراهم می‌کند.
* [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/) نمایان‌گر یک پاراگراف در یک چارچوب متنی است و دسترسی به بخش‌ها و قالب‌بندی سطح پاراگراف را می‌دهد.
* [Portion](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/) نمایان‌گر یک قسمت متنی داخل یک پاراگراف است. هر بخش می‌تواند متن و قالب‌بندی کاراکتر خود را داشته باشد.

بدین ترتیب یک پاراگراف می‌تواند متنی با فونت‌ها، رنگ‌ها، اندازه‌ها و قالب‌بندی‌های مختلف داشته باشد که با استفاده از چندین بخش (Portion) تعریف می‌شوند.

## **ایجاد و قالب‌بندی پاراگراف‌ها**

### **ایجاد پاراگراف‌ها با چندین بخش**

مراحل زیر یک چارچوب متنی با سه پاراگراف، هر کدام شامل سه بخش، می‌سازد:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید مورد نظر را با استفاده از اندیس آن پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید.
5. از پاراگراف پیش‌فرض استفاده کنید و دو شیء دیگر [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/) را به چارچوب متنی اضافه کنید.
6. به اندازه کافی شیء [Portion](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/) برای هر پاراگراف اضافه کنید تا هر کدام سه بخش داشته باشند. پاراگراف پیش‌فرض در حال حاضر شامل یک بخش خالی است.
7. متن هر بخش را تنظیم کنید.
8. قالب‌بندی کاراکتری را از طریق [Portion.getPortionFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/getportionformat/) اعمال کنید.
9. ارائه (Presentation) اصلاح‌شده را ذخیره کنید.

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

## **ایجاد فهرست‌های نقطه‌ای و عددی**

### **ایجاد فهرست نقطه‌ای یا عددی**

نقطه‌ها و شماره‌ها به خوانایی موارد مرتبط کمک می‌کند. در Aspose.Slides تنظیمات فهرست از طریق [BulletFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bulletformat/) تعریف می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید مورد نظر را با استفاده از اندیس آن پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) به اسلاید انتخاب‌شده اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض را از چارچوب متنی حذف کنید.
6. یک [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/) برای یک نقطه نمادیک (symbol bullet) بسازید.
7. با استفاده از [BulletFormat.setType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bulletformat/settype/) مقدار [BulletType.Symbol](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bullettype/) را تنظیم کرده و کاراکتر نقطه را مشخص کنید.
8. متن پاراگراف، تورفتگی، رنگ نقطه و ارتفاع نقطه را تنظیم کنید.
9. پاراگراف را به چارچوب متنی اضافه کنید.
10. پاراگراف دوم را بسازید و با استفاده از [BulletFormat.setType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bulletformat/settype/) مقدار [BulletType.Numbered](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bullettype/) را تنظیم کنید.
11. سبک نقطه عددی را پیکربندی کنید و پاراگراف را به چارچوب متنی اضافه کنید.
12. ارائه را ذخیره کنید.

این مثال JavaScript یک نقطه نمادیک و یک نقطه عددی ایجاد می‌کند:

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

### **استفاده از نقطه‌های تصویری**

نقطه‌های تصویری به شما اجازه می‌دهد به جای نماد یا عدد، از تصویر دلخواه استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید مورد نظر را با استفاده از اندیس آن پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) اضافه کنید و به [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) آن دسترسی پیدا کنید.
4. پاراگراف پیش‌فرض را از چارچوب متنی حذف کنید.
5. تصویر نقطه را بارگذاری کنید و به مجموعه تصویرهای ارائه به عنوان یک [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) اضافه کنید.
6. یک [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/) بسازید و متن آن را تنظیم کنید.
7. با استفاده از [BulletFormat.setType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bulletformat/settype/) مقدار [BulletType.Picture](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bullettype/) را تنظیم کنید.
8. تصویر را از طریق [BulletFormat.getPicture](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bulletformat/getpicture/) اختصاص داده و ارتفاع نقطه را تنظیم کنید.
9. پاراگراف را به چارچوب متنی اضافه کنید.
10. ارائه اصلاح‌شده را ذخیره کنید.

این مثال JavaScript یک نقطه تصویری ایجاد می‌کند:

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

با تنظیم [ParagraphFormat.setDepth](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setdepth/) می‌توانید پاراگراف‌ها را در سطوح مختلف فهرست قرار دهید. سطح بالایی عمق `0` دارد.

1. یک [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید و به یک اسلاید دسترسی پیدا کنید.
2. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) اضافه کنید و پاراگراف پیش‌فرض را از چارچوب متنی آن پاک کنید.
3. چهار پاراگراف بسازید و نمادهای نقطه آن‌ها را پیکربندی کنید.
4. مقدار [ParagraphFormat.setDepth](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setdepth/) آن‌ها را به ترتیب `0`، `1`، `2` و `3` تنظیم کنید.
5. پاراگراف‌ها را به چارچوب متنی اضافه کنید و ارائه را ذخیره کنید.

این مثال JavaScript یک فهرست نقطه‌ای چهار سطحی ایجاد می‌کند:

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

### **شروع شمارش موارد فهرست عددی از مقدار دلخواه**

از [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) برای تعیین عدد اولیه هر پاراگراف عددی استفاده کنید.

1. یک [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید و یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
2. پاراگراف پیش‌فرض را از چارچوب متنی شکل پاک کنید.
3. سه پاراگراف عددی بسازید.
4. برای هر پاراگراف مقدار [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) را به ترتیب `2`، `3` و `7` تنظیم کنید.
5. پاراگراف‌ها را به چارچوب متنی اضافه کنید و ارائه را ذخیره کنید.

این مثال JavaScript عدد شروع سفارشی را برای هر پاراگراف تعیین می‌کند:

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

### **تنظیم تورفتگی خط اول**

با استفاده از [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setindent/) می‌توانید تورفتگی خط اول پاراگراف را کنترل کنید. این متد فقط خط اول را نسبت به حاشیه چپ پاراگراف جابه‌جا می‌کند. مقدار مثبت خط اول را به سمت راست می‌برد، در حالی که خطوط باقی‌مانده همان‌جا می‌مانند.

زمانی که نیاز به جابه‌جایی کل پاراگراف دارید از [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) استفاده کنید. برای جابه‌جایی فقط خط اول از [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setindent/) استفاده کنید.

مثال زیر چند پاراگراف ایجاد می‌کند و مقادیر مختلف [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setindent/) را برای نشان دادن تأثیر تورفتگی خط اول اعمال می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) بسازید.
2. اسلاید هدف را باز کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض را حذف کنید.
5. چند پاراگراف بسازید و مقادیر مختلف [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setindent/) را برای آن‌ها تنظیم کنید.
6. پاراگراف‌ها را به چارچوب متنی اضافه کنید.
7. ارائه اصلاح‌شده را ذخیره کنید.

این کد نشان می‌دهد چگونه تورفتگی پاراگراف تنظیم می‌شود:

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

تورفتگی معلق به این معنی است که خط اول نسبت به بقیه خطوط به سمت چپ می‌آید. در Aspose.Slides این اثر را با [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setindent/) ایجاد می‌کنید؛ مقدار منفی به خط اول جابه‌جایی به سمت چپ می‌دهد.

در عمل، [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) موقعیت سمت چپ بدنه پاراگراف را تعیین می‌کند و [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setindent/) موقعیت خط اول نسبت به آن حاشیه را. برای ایجاد تورفتگی معلق، مقدار مثبت به `setMarginLeft` و مقدار منفی به `setIndent` بدهید.

این قالب‌بندی برای کتابشناسی‌ها، مراجع، ورودی‌های واژه‌نامه و سایر پاراگراف‌هایی که خطوط پیچیده باید زیر بدنه پاراگراف قرار بگیرند، مفید است.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) بسازید.
2. اسلاید هدف را باز کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض را حذف کنید.
5. برای هر پاراگراف مقدار مثبت به [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) بدهید.
6. مقدار منفی به [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setindent/) بدهید تا اثر تورفتگی معلق ایجاد شود.
7. پاراگراف‌ها را به چارچوب متنی اضافه کنید.
8. ارائه اصلاح‌شده را ذخیره کنید.

این کد نشان می‌دهد چگونه تورفتگی معلق برای یک پاراگراف تنظیم می‌شود:

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

### **تنظیم ویژگی‌های انتهای پاراگراف**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) قالب‌بندی علامت پایان پاراگراف را کنترل می‌کند. مثال زیر اندازه قلم و قلم لاتین را برای علامت پایان پاراگراف دوم تنظیم می‌کند:

1. یک [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد یا بارگذاری کنید و به یک اسلاید دسترسی پیدا کنید.
2. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) اضافه کنید و پاراگراف پیش‌فرض آن را پاک کنید.
3. دو پاراگراف بسازید و به آن‌ها بخش‌های متنی اضافه کنید.
4. یک [PortionFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portionformat/) برای علامت پایان پاراگراف دوم ایجاد کنید.
5. [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) و [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#setLatinFont) را تنظیم کنید.
6. قالب را با [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) اختصاص داده و ارائه را ذخیره کنید.

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

## **واردات و صادرات محتوای پاراگراف**

### **وارد کردن متن HTML به پاراگراف‌ها**

از [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) برای تبدیل نشانه‌گذاری HTML به پاراگراف‌ها و بخش‌ها در یک چارچوب متنی استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. یک اسلاید باز کنید و یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) اضافه کنید.
3. به [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض را حذف کنید.
4. رشته HTML منبع را تعریف یا بخوانید.
5. رشته HTML را به [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) پاس دهید.
6. ارائه اصلاح‌شده را ذخیره کنید.

این مثال JavaScript HTML را به یک چارچوب متنی وارد می‌کند:

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

### **صادر کردن متن پاراگراف به HTML**

از [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) برای صادرات محدوده‌ای از پاراگراف‌ها به HTML استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد یا بارگذاری کنید.
2. اسلاید را باز کنید و [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) حاوی متن را پیدا کنید.
3. به [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید.
4. با فراخوانی [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) اندیس پاراگراف شروع و تعداد پاراگراف‌های موردنظر را مشخص کنید.
5. رشته HTML بازگشتی را در یک فایل بنویسید.

این مثال JavaScript مستقل یک شکل متنی می‌سازد و تمام پاراگراف‌های آن را صادر می‌کند:

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

### **رندرسازی پاراگراف به عنوان تصویر**

[Paragraph.getImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/#getImage) یک پاراگراف منفرد را رندر می‌کند و یک [IImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/iimage/) برمی‌گرداند. نتیجه را با [IImage.save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/iimage/#save) در فایلی ذخیره کنید. نیازی به رندر کردن شکل شامل یا برش دستی بیت‌مپ نیست.

[Paragraph.getImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/#getImage) می‌تواند `null` برگرداند اگر پاراگراف در مجموعه والد یافت نشود، محدوده رندر معتبری نداشته باشد یا قابل رندر نباشد. قبل از ذخیره‌سازی نتیجه را بررسی کنید و پس از استفاده تصویر برگردانده‌شده را آزاد کنید.

#### **رندرسازی پاراگراف با مقیاس پیش‌فرض**

جعبه متن زیر شامل سه پاراگراف است:

![The text box with three paragraphs](paragraph_to_image_input.png)

مثال زیر پاراگراف دوم را در یک شکل متنی عادی با مقیاس پیش‌فرض رندر می‌کند و تصویر بازگشتی را به فرمت PNG ذخیره می‌نماید. بلوک `finally` اطمینان می‌دهد که تصویر به طور صحیح آزاد می‌شود.

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

#### **رندرسازی پاراگراف در یک سلول جدول با مقیاس‌دهی**

از نسخه overload `Paragraph.getImage` که پارامترهای `scaleX` و `scaleY` را می‌پذیرد برای تنظیم مقیاس افقی و عمودی استفاده کنید. مثال زیر یک جدول می‌سازد، پاراگراف را در اولین سلول آن با دو برابر عرض و ارتفاع پیش‌فرض رندر می‌کند و نتیجه را به صورت تصویر PNG ذخیره می‌نماید.

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

عامل مقیاس `1` اندازه پیش‌فرض محور را حفظ می‌کند. به عنوان مثال `2` برای هر دو عامل تصویری می‌سازد که عرض و ارتفاع تقریباً دو برابر ابعاد پیش‌فرض باشد و در نتیجه چهار برابر پیکسل داشته باشد. عوامل بزرگتر معمولاً متن تیزتر برای بزرگ‌نمایی یا خروجی با وضوح بالا تولید می‌کنند، اما مصرف حافظه و حجم فایل را نیز افزایش می‌دهند. عوامل زیر `1` تصاویر کوچکتر و با جزئیات کمتر تولید می‌کنند. برای حفظ نسبت طول/عرض پاراگراف از عوامل برابر استفاده کنید؛ عوامل متفاوت افقی و عمودی تصویر را به طور مستقل کش می‌دهند.

رندر کل شکل با [Shape.getImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/#getImage) زمانی مفید است که خروجی باید پرکن، حاشیه یا سایر زمینه‌های بصری شکل را شامل شود. برای تصویر فقط پاراگراف، از [Paragraph.getImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/#getImage) استفاده کنید.

## **سؤالات متداول**

**آیا می‌توانم به‌طور کامل بسته شدن خطوط داخل یک چارچوب متنی را غیرفعال کنم؟**

بله. با تنظیم [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframeformat/setwraptext/) می‌توانید بسته شدن خطوط را غیرفعال کنید تا خطوط در لبه‌های چارچوب متنی قطع نشوند.

**چگونه می‌توانم مرزهای دقیق روی‑اسلاید یک پاراگراف خاص را دریافت کنم؟**

از [Paragraph.getRect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/getrect/) برای بازیابی مستطیل محصور کننده پاراگراف استفاده کنید. [Portion.getRect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/#getRect) مرزهای یک بخش منفرد را برمی‌گرداند.

**کنترل ترازبندی پاراگراف (چپ، راست، مرکز یا کشیده) در کجا قرار دارد؟**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setalignment/) تنظیمی در سطح پاراگراف است و برای تمام پاراگراف اعمال می‌شود، صرف‌نظر از قالب‌بندی هر بخش به‌صورت‌جدا.

**آیا می‌توانم زبان اصلاحی (proofing) را برای بخشی از یک پاراگراف تنظیم کنم؟**

بله. با تنظیم [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) برای بخش‌های منفرد، می‌توان یک پاراگراف را حاوی متن در چندین زبان کرد.