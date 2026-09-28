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
- مدیریت گلوله
- تو رفتگی پاراگراف
- تو رفتگی آویزان
- گلوله پاراگراف
- فهرست شماره‌دار
- فهرست گلوله‌ای
- ویژگی‌های پاراگراف
- واردات HTML
- تبدیل متن به HTML
- تبدیل پاراگراف به HTML
- تبدیل پاراگراف به تصویر
- تبدیل متن به تصویر
- صدور پاراگراف
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "یاد بگیرید چگونه با Aspose.Slides برای Node.js از طریق Java، پاراگراف‌ها، بخش‌ها، گلوله‌ها، فهرست‌های شماره‌دار، تو رفتگی‌ها، محتوای HTML و تصاویر پاراگراف را ایجاد و قالب‌بندی کنید."
---
## **نمای کلی**

Aspose.Slides for Node.js via Java متن را به‌صورت یک سلسله‌مراتب از TextFrameها، Paragraphها و Portionها نشان می‌دهد:

* [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) ظرف متن در یک شکل را نمایندگی می‌کند و دسترسی به مجموعهٔ Paragraphهای آن را فراهم می‌سازد.
* [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/) یک پاراگراف را در یک TextFrame نشان می‌دهد و دسترسی به Portionها و قالب‌بندی در سطح پاراگراف را فراهم می‌کند.
* [Portion](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/) یک بخش متنی درون یک Paragraph را نمایندگی می‌کند. هر Portion می‌تواند متن و قالب‌بندی کاراکتر خاص خود را داشته باشد.

بنابراین یک Paragraph می‌تواند متنی با فونت‌ها، رنگ‌ها، اندازه‌ها و قالب‌بندی‌های مختلف با استفاده از چند Portion داشته باشد.

## **ایجاد و قالب‌بندی Paragraphها**

### **ایجاد Paragraphها با چند Portion**

مراحل زیر یک TextFrame با سه Paragraph ایجاد می‌کند که هر کدام شامل سه Portion هستند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) بسازید.
2. اسلاید مربوطه را از طریق ایندکس آن دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید.
5. از Paragraph پیش‌فرض استفاده کنید و دو شیء دیگر [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/) را به TextFrame اضافه کنید.
6. به تعداد کافی شیء [Portion](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/) اضافه کنید تا هر Paragraph شامل سه Portion شود. Paragraph پیش‌فرض دارای یک Portion خالی است.
7. متن هر Portion را تنظیم کنید.
8. قالب‌بندی کاراکتر را از طریق [Portion.getPortionFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/getportionformat/) اعمال کنید.
9. ارائه (Presentation) اصلاح‌شده را ذخیره کنید.

این مثال JavaScript مراحل را اجرا می‌کند:

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

## **ایجاد فهرست‌های گلوله‌ای و شماره‌دار**

### **ایجاد یک فهرست گلوله‌ای یا شماره‌دار**

گلوله‌ها و شماره‌گذاری موارد مرتبط را قابل اسکن‌تر می‌کند. در Aspose.Slides تنظیمات فهرست از طریق [BulletFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bulletformat/) تعریف می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) بسازید.
2. اسلاید مربوطه را از طریق ایندکس آن دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) به اسلاید انتخابی اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید.
5. Paragraph پیش‌فرض را از TextFrame حذف کنید.
6. یک [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/) برای یک گلولهٔ نماد ایجاد کنید.
7. [BulletFormat.setType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bulletformat/settype/) را به [BulletType.Symbol](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bullettype/) تنظیم کنید و کاراکتر گلوله را مشخص کنید.
8. متن پاراگراف، تورفتگی، رنگ گلوله و ارتفاع گلوله را تنظیم کنید.
9. Paragraph را به TextFrame اضافه کنید.
10. یک پاراگراف دوم ایجاد کنید و [BulletFormat.setType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bulletformat/settype/) را به [BulletType.Numbered](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bullettype/) تنظیم کنید.
11. سبک گلولهٔ شماره‌دار را پیکربندی کنید و Paragraph را به TextFrame اضافه کنید.
12. ارائه را ذخیره کنید.

این مثال JavaScript یک گلولهٔ نماد و یک گلولهٔ شماره‌دار ایجاد می‌کند:

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

### **استفاده از گلوله‌های تصویری**

گلوله‌های تصویری به شما اجازه می‌دهند به‌جای نماد یا عدد از یک تصویر سفارشی استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) بسازید.
2. اسلاید مربوطه را از طریق ایندکس آن دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) اضافه کنید و به [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) آن دسترسی پیدا کنید.
4. Paragraph پیش‌فرض را از TextFrame حذف کنید.
5. تصویر گلوله را بارگذاری کنید و به‌عنوان یک [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) به مجموعهٔ تصاویر ارائه اضافه کنید.
6. یک [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/) ایجاد کرده و متن آن را تنظیم کنید.
7. [BulletFormat.setType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bulletformat/settype/) را به [BulletType.Picture](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bullettype/) تنظیم کنید.
8. تصویر را از طریق [BulletFormat.getPicture](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bulletformat/getpicture/) اختصاص دهید و ارتفاع گلوله را تنظیم کنید.
9. Paragraph را به TextFrame اضافه کنید.
10. ارائه اصلاح‌شده را ذخیره کنید.

این مثال JavaScript یک گلولهٔ تصویری ایجاد می‌کند:

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

[ParagraphFormat.setDepth](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setdepth/) را تنظیم کنید تا Paragraphها در سطوح مختلف فهرست قرار گیرند. سطح بالایی دارای عمق `0` است.

1. یک [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید و به یک اسلاید دسترسی پیدا کنید.
2. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) اضافه کنید و Paragraph پیش‌فرض را از TextFrame آن پاک کنید.
3. چهار Paragraph ایجاد کنید و نمادهای گلولهٔ آن‌ها را پیکربندی کنید.
4. مقدارهای [ParagraphFormat.setDepth](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setdepth/) آن‌ها را به ترتیب `0`، `1`، `2` و `3` تنظیم کنید.
5. Paragraphها را به TextFrame اضافه کنید و ارائه را ذخیره کنید.

این مثال JavaScript یک فهرست چهارسطحی گلوله‌ای ایجاد می‌کند:

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

### **شروع موارد فهرست شماره‌دار با مقادیر سفارشی**

از [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) برای تنظیم عدد اولیهٔ نمایش داده‌شده برای یک Paragraph شماره‌دار استفاده کنید.

1. یک [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید و یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
2. Paragraph پیش‌فرض را از TextFrame شکل پاک کنید.
3. سه Paragraph شماره‌دار ایجاد کنید.
4. برای هر یک از آن‌ها، [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) را به ترتیب به `2`، `3` و `7` تنظیم کنید.
5. Paragraphها را به TextFrame اضافه کنید و ارائه را ذخیره کنید.

این مثال JavaScript عدد شروع سفارشی را برای هر Paragraph تنظیم می‌کند:

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

## **کنترل چیدمان Paragraph و ویژگی‌های انتها**

### **تنظیم تو رفتگی خط اول**

از [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setindent/) برای کنترل تو رفتگی خط اول یک Paragraph استفاده کنید. این متد فقط خط اول را نسبت به حاشیه چپ Paragraph جابه‌جا می‌کند. مقدار مثبت خط اول را به سمت راست می‌برد، در حالی که خطوط باقی‌مانده همانند بدنهٔ Paragraph باقی می‌مانند.

از [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) زمانی استفاده کنید که بخواهید کل Paragraph را جابه‌جا کنید. از [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setindent/) زمانی استفاده کنید که فقط خط اول را جابه‌جا کنید.

مثال زیر چند Paragraph ایجاد کرده و مقادیر مختلف [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setindent/) را اعمال می‌کند تا نشان دهد تو رفتگی خط اول چطور بر چیدمان Paragraph اثر می‌گذارد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) بسازید.
2. اسلاید هدف را دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید و Paragraph پیش‌فرض را حذف کنید.
5. چند Paragraph ایجاد کنید و مقادیر مختلف [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setindent/) را برای آن‌ها تنظیم کنید.
6. Paragraphها را به TextFrame اضافه کنید.
7. ارائه اصلاح‌شده را ذخیره کنید.

این کد نشان می‌دهد چگونه یک تو رفتگی Paragraph تنظیم شود:

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

![تو رفتگی خط اول پاراگراف‌ها](first_line_indent.png)

### **تنظیم تو رفتگی آویزان**

تو رفتگی آویزان یک چیدمان Paragraph است که در آن خط اول به سمت چپ خطوط باقی‌مانده می‌آید. در Aspose.Slides این اثر را با [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setindent/) ایجاد می‌کنید. برای جابه‌جایی خط اول به سمت چپ مقدار منفی به این متد بدهید.

در عمل، [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) موقعیت چپ بدنهٔ Paragraph را تعیین می‌کند و [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setindent/) موقعیت خط اول را نسبت به آن حاشیه تنظیم می‌کند. برای ایجاد تو رفتگی آویزان، مقدار مثبت به `setMarginLeft` و مقدار منفی به `setIndent` بدهید.

این قالب‌بندی برای کتابشناسی‌ها، مراجع، ورودی‌های واژه‌نامه و سایر پاراگراف‌هایی که خطوط بسته‌شده باید زیر بدنهٔ Paragraph نه زیر اولین کاراکتر خط اول هم‌راستا شوند، مفید است.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) بسازید.
2. اسلاید هدف را دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید و Paragraph پیش‌فرض را حذف کنید.
5. برای هر Paragraph مقدار مثبت به [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) بدهید.
6. مقدار منفی به [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setindent/) بدهید تا اثر تو رفتگی آویزان ایجاد شود.
7. Paragraphها را به TextFrame اضافه کنید.
8. ارائه اصلاح‌شده را ذخیره کنید.

این کد نشان می‌دهد چگونه تو رفتگی آویزان برای یک Paragraph تنظیم شود:

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

![تو رفتگی آویزان پاراگراف‌ها](hanging_indent.png)

### **تنظیم ویژگی‌های انتهایی Paragraph**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) قالب‌بندی علامت پایان Paragraph را کنترل می‌کند. مثال زیر اندازهٔ قلم و قلم لاتین را برای علامت پایان دومین Paragraph تعیین می‌کند:

1. یک [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد یا بارگذاری کنید و به یک اسلاید دسترسی پیدا کنید.
2. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) اضافه کنید و Paragraph پیش‌فرض آن را پاک کنید.
3. دو Paragraph ایجاد کنید و به آن‌ها Portionهای متنی اضافه کنید.
4. یک [PortionFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portionformat/) برای علامت پایان دومین Paragraph ایجاد کنید.
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

## **شمارش خطوط رندر شده**

برای قواعد Paragraph که بر بسته شدن خودکار و نقطه‌گذاری در انتهای خطوط اثر می‌گذارند، به بخش‌های [Control Line Breaking](/slides/fa/nodejs-java/text-formatting/#control-line-breaking) و [Control Hanging Punctuation](/slides/fa/nodejs-java/text-formatting/#control-hanging-punctuation) مراجعه کنید.

از [Paragraph.getLinesCount](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/#getLinesCount) برای شمارش خطوطی که یک Paragraph پس از چیدمان متن اشغال می‌کند، استفاده کنید؛ این شامل بسته شدن خودکار نیز می‌شود. این روش برای بررسی طول متن و چیدمان در الگوهای ارائه مفید است.

یک Paragraph یک آیتم در [TextFrame.getParagraphs](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#getParagraphs) است و می‌تواند چندین خط رندر شده را اشغال کند. یک شکست خط صریح داخل Paragraph یک خط جدید ایجاد می‌کند بدون اینکه Paragraph جدیدی ساخته شود. بسته شدن خودکار خطوط را بر اساس عرض موجود ایجاد می‌کند بدون وارد کردن شکست‌های خط صریح به متن. بنابراین شمارش Paragraphها یا کاراکترهای شکست خط، تعداد خطوط رندر شده را نمی‌دهد.

مثال زیر یک شکل متنی ایجاد می‌کند، خطوط آن را می‌شمارد، شکل را باریک می‌کند و سپس متن را با رشتهٔ کوتاه‌تری جایگزین می‌کند. بسته شدن خط فعال است و Autofit غیرفعال؛ بنابراین عرض شکل بسته شدن خط را کنترل می‌کند بدون اینکه به‌صورت خودکار متن یا اندازهٔ شکل را تغییر دهد. ابعاد شکل بر حسب پوینت است. در پایان مثال یک Paragraph دیگر اضافه می‌کند و مجموع تعداد خطوط را در کل TextFrame محاسبه می‌کند.

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

با این متن و این ابعاد، باریک کردن شکل تعداد خطوط را افزایش می‌دهد، در حالی که جایگزینی متن با رشتهٔ کوتاه تعداد خطوط را کاهش می‌دهد. شمارش دقیق ممکن است بسته به در دسترس بودن قلم، جایگزینی، اندازهٔ قلم، حاشیه‌ها، تو رفتگی، بسته شدن و تنظیمات Autofit متفاوت باشد. هنگام بررسی یک الگو، از قلم‌ها و تنظیمات چیدمان موردنظر برای محیط هدف استفاده کنید.

تنها شمارش خطوط نشان‌دهندهٔ overflow متن در کانتینر نیست. ارتفاع موجود، ارتفاع خطوط، فاصلهٔ بین Paragraphها و خطوط، و رفتار Autofit نیز مؤثرند؛ حتی یک خط می‌تواند عرض موجود را تجاوز کند هنگامی که بسته شدن غیر فعال باشد.

## **واردات و صادرات محتوای Paragraph**

### **وارد کردن متن HTML به داخل Paragraphها**

از [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) برای تبدیل قالب‌بندی HTML به Paragraphها و Portionها در یک TextFrame استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) بسازید.
2. به یک اسلاید دسترسی پیدا کنید و یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) اضافه کنید.
3. به [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید و Paragraph پیش‌فرض را پاک کنید.
4. رشتهٔ HTML منبع را تعریف یا بخوانید.
5. رشتهٔ HTML را به [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) پاس بدهید.
6. ارائه اصلاح‌شده را ذخیره کنید.

این مثال JavaScript HTML را به یک TextFrame وارد می‌کند:

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

### **صادر کردن متن Paragraph به HTML**

از [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) برای صادر کردن محدوده‌ای از Paragraphها به صورت HTML استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد یا بارگذاری کنید.
2. اسلاید را دسترسی پیدا کنید و [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) شامل متن را پیدا کنید.
3. به [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید.
4. با مشخص کردن ایندکس Paragraph شروع و تعداد Paragraphهای مورد نظر، [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) را فراخوانی کنید.
5. رشتهٔ HTML بازگشتی را در فایلی بنویسید.

این مثال JavaScript خودکفا یک شکل متنی ایجاد می‌کند و تمام Paragraphهای آن را صادر می‌نماید:

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

### **رندر یک Paragraph به‌صورت تصویر**

[Paragraph.getImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/#getImage) یک Paragraph تک را به‌صورت مستقیم رندر می‌کند و یک [IImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/iimage/) برمی‌گرداند. نتیجه را با [IImage.save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/iimage/#save) در فایلی ذخیره کنید؛ نیازی به رندر شکل حاوی آن یا برش بیت‌مپ به‌صورت دستی نیست.

[Paragraph.getImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/#getImage) می‌تواند `null` برگرداند اگر Paragraph در مجموعهٔ والد یافت نشود، محدودهٔ رندر معتبری نداشته باشد یا قابل رندر نباشد. قبل از ذخیره کردن نتیجه را بررسی کنید و پس از استفاده تصویر بازگردانده‌شده را آزاد کنید.

#### **رندر یک Paragraph با مقیاس پیش‌فرض**

جعبه متن زیر شامل سه Paragraph است:

![جعبه متن با سه Paragraph](paragraph_to_image_input.png)

مثال زیر Paragraph دوم را در یک شکل متنی عادی با مقیاس پیش‌فرض رندر می‌کند و تصویر بازگشتی را به فرمت PNG ذخیره می‌نماید. بلوک `finally` اطمینان می‌دهد که تصویر به‌درستی آزاد شود.

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

![تصویر Paragraph](paragraph_to_image_output.png)

#### **رندر یک Paragraph در سلول جدول با مقیاس‌بندی**

از overload متد [Paragraph.getImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/#getImage) که پارامترهای `scaleX` و `scaleY` را می‌پذیرد استفاده کنید تا عوامل مقیاس افقی و عمودی را تنظیم کنید. مثال زیر یک جدول ایجاد می‌کند، Paragraph را در اولین سلول آن با دو برابر عرض و ارتفاع پیش‌فرض رندر می‌نماید و نتیجه را به‌صورت تصویر PNG ذخیره می‌کند.

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

عامل مقیاس `1` آن محور را در اندازهٔ پیش‌فرض پیکسل نگه می‌دارد. برای مثال، `2` برای هر دو عامل تصویری تولید می‌کند که عرض و ارتفاع آن تقریباً دو برابر ابعاد پیش‌فرض است و چهار برابر پیکسل بیشتری دارد. عوامل بزرگ‌تر معمولاً متن واضح‌تری برای زوم یا خروجی با وضوح بالا تولید می‌کنند، اما مصرف حافظه و اندازهٔ فایل را نیز افزایش می‌دهند. عوامل زیر `1` تصاویر کوچکتری با جزئیات کمتر تولید می‌کنند. برای حفظ نسبت عرض/ارتفاع Paragraph، از عوامل برابر استفاده کنید؛ عوامل افقی و عمودی متفاوت خروجی را به‌صورت مستقل کش می‌دهند.

رندر کل شکل با [Shape.getImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/#getImage) زمانی مفید است که خروجی باید شامل پرکردن، حاشیه یا سایر زمینه‌های بصری شکل باشد. برای تصویر فقط پاراگراف، از [Paragraph.getImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/#getImage) استفاده کنید.

## **سؤالات متداول**

**آیا می‌توانم بسته شدن خط داخل یک TextFrame را به‌طور کامل غیرفعال کنم؟**

بله. با تنظیم [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframeformat/setwraptext/) می‌توانید بسته شدن را غیرفعال کنید تا خطوط در لبه‌های TextFrame شکسته نشوند.

**چگونه می‌توانم مرزهای دقیق روی اسلاید یک Paragraph خاص را به‌دست آورم؟**

از [Paragraph.getRect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/getrect/) برای دریافت مستطیل محدودهٔ Paragraph استفاده کنید. [Portion.getRect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/#getRect) محدودهٔ یک Portion منفرد را فراهم می‌کند.

**کنترل تراز Paragraph (چپ، راست، مرکز یا توزیع) در کجا انجام می‌شود؟**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setalignment/) تنظیم سطح Paragraph است و بر کل Paragraph اعمال می‌شود صرف‌نظر از قالب‌بندی جداگانهٔ Portionها.

**آیا می‌توانم زبان اصلاح‌کنندهٔ نوشتاری را برای بخشی از یک Paragraph تنظیم کنم؟**

بله. با تنظیم [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) برای Portionهای جداگانه، می‌توانید یک Paragraph شامل متنی با چندین زبان داشته باشید.