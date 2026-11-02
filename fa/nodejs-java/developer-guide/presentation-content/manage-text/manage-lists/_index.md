---
title: مدیریت فهرست‌های نقطه‌دار و شماره‌دار در ارائه‌ها با استفاده از جاوااسکریپت
linktitle: مدیریت فهرست‌ها
type: docs
weight: 60
url: /fa/nodejs-java/manage-lists/
keywords:
- نقطه
- فهرست نقطه‌دار
- فهرست شماره‌دار
- نقطه نمادین
- نقطه تصویری
- نقطه سفارشی
- فهرست چندسطحی
- ایجاد نقطه
- افزودن نقطه
- افزودن فهرست
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "یاد بگیرید چگونه فهرست‌های نقطه‌دار، تصویری، چندسطحی و شماره‌دار را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Node.js via Java ایجاد و قالب‌بندی کنید."
---
## **بررسی کلی**

Aspose.Slides for Node.js via Java به شما امکان می‌دهد فهرست‌های نقطه‌دار و شماره‌دار را در ارائه‌های PowerPoint و OpenDocument ایجاد و قالب‌بندی کنید. یک مورد فهرست یک پاراگراف است که تنظیمات نقطه آن از طریق قالب پاراگراف کنترل می‌شود.

از کلاس [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) برای دسترسی به تنظیمات فهرست در سطح پاراگراف استفاده کنید. نقطه ورودی اصلی `Paragraph.getParagraphFormat().getBullet()` است که یک شیء [BulletFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/) برمی‌گرداند. با این شیء می‌توانید نوع نقطه، نماد، تصویر، رنگ، اندازه، سبک شماره‌گذاری و عدد شروع را تنظیم کنید.

این مقاله نشان می‌دهد چگونه:

- ایجاد یک فهرست نقطه‌دار با نماد سفارشی
- ایجاد یک نقطه تصویر
- ایجاد یک فهرست چندسطحی با تنظیم عمق پاراگراف
- ایجاد یک فهرست شماره‌دار
- بررسی و تغییر قالب‌بندی فهرست در یک ارائه موجود
- خواندن نشانگرها و شماره‌های واقعی فهرست در کنار متن پاراگراف

## **ایجاد یک فهرست نقطه‌دار**

برای ایجاد فهرست نقطه‌دار، شیءهای [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) را به یک [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) اضافه کنید و `BulletFormat.setType` را به [BulletType.Symbol](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/) تنظیم کنید. سپس می‌توانید `BulletFormat.setChar`، `BulletFormat.getColor` و `BulletFormat.setHeight` را برای کنترل ظاهر نقطه تنظیم کنید.

کد JavaScript زیر نحوه ایجاد فهرست نقطه‌دار در یک اسلاید را نشان می‌دهد:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function createParagraph(text, bulletColor) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Symbol));
    bulletFormat.setChar(java.newChar("*"));
    paragraphFormat.setIndent(15);
    bulletFormat.setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    bulletFormat.getColor().setColor(bulletColor);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const bulletColor = java.newInstanceSync("java.awt.Color", 205, 92, 92);

    const paragraph1 = createParagraph("The first paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![نقطه‌های نمادیک](symbol_bullets.png)

## **ایجاد یک فهرست شماره‌دار**

از فهرست‌های شماره‌دار زمانی استفاده کنید که ترتیب موارد مهم باشد. `BulletFormat.setType` را به [BulletType.Numbered](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/) تنظیم کنید. همچنین می‌توانید با `BulletFormat.setNumberedBulletStyle` قالب شماره‌گذاری را انتخاب کنید یا با `BulletFormat.setNumberedBulletStartWith` وقتی فهرست باید از مقدار دیگری غیر از 1 شروع شود عدد شروع را تعیین کنید.

کد JavaScript زیر نشان می‌دهد چگونه فهرست شماره‌دار را در یک اسلاید ایجاد کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 90, 80);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![نقطه‌های شماره‌دار](numbered_bullets.png)

## **ایجاد نقطه تصویر**

Aspose.Slides به شما اجازه می‌دهد نماد نقطه معمولی را با یک تصویر جایگزین کنید. نقطه‌های تصویری بهترین عملکرد را با تصاویری ساده دارند که در اندازه کوچک خوانا باقی می‌مانند، مانند آیکون‌ها یا فایل‌های PNG شفاف کوچک.

{{% alert color="info" title="Note" %}}
در صورت برنامه‌ریزی برای جایگزینی نماد نقطه معمولی با تصویر، بهتر است گرافیک ساده‌ای با پس‌زمینه شفاف انتخاب کنید. چنین تصاویری به عنوان نمادهای سفارشی نقطه به خوبی عمل می‌کنند.

به یاد داشته باشید تصویر به اندازه بسیار کوچکی مقیاس خواهد شد. به همین دلیل توصیه می‌کنیم تصویری انتخاب کنید که در مقیاس نقطه در فهرست واضح و مؤثر باقی بماند.
{{% /alert %}}

برای ایجاد نقطه تصویر، یک تصویر را به [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) با `Presentation.getImages().addImage` اضافه کنید و شیء بازگشتی [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) را به `BulletFormat.getPicture().setImage` اختصاص دهید. قبل از اختصاص تصویر، `BulletFormat.setType` را به [BulletType.Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/) تنظیم کنید.

فرض کنید فایلی به نام "image.png" داریم:

![یک تصویر برای نقطه‌ها](picture_for_bullets.png)

کد JavaScript زیر نشان می‌دهد چگونه نقطه‌های تصویری را در یک اسلاید ایجاد کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function createParagraph(text, image) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Picture));
    bulletFormat.getPicture().setImage(image);
    paragraphFormat.setIndent(15);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
let image = null;
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    image = aspose.slides.Images.fromFile("image.png");
    const bulletImage = presentation.getImages().addImage(image);

    const paragraph1 = createParagraph("The first paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (image !== null) {
        image.dispose();
    }
    presentation.dispose();
}
```

نتیجه:

![نقطه‌های تصویری](picture_bullets.png)

## **ایجاد فهرست چندسطحی**

از `ParagraphFormat.setDepth` برای قرار دادن موارد فهرست در سطوح مختلف استفاده کنید. سطح 0 بالاترین سطح است، سطح 1 زیرمجموعه آن و به همین ترتیب.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 260, 110);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().setDepth(java.newShort(0));
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().setDepth(java.newShort(1));
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().setDepth(java.newShort(2));
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    const paragraph4 = new aspose.slides.Paragraph();
    paragraph4.getParagraphFormat().setDepth(java.newShort(3));
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![فهرست چندسطحی](multilevel_list.png)

## **تغییر فهرست موجود**

برای تغییر قالب‌بندی فهرست در یک ارائه موجود، پاراگراف هدف را دسترسی یافته و تنظیمات `ParagraphFormat.getBullet` آن را به‌روزرسانی کنید. همان ویژگی‌هایی که برای ایجاد فهرست‌ها استفاده می‌شوند می‌توانند برای بررسی یا تغییر فهرست‌های بارگذاری‌شده از فایل PPT، PPTX یا ODP به کار روند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Numbered));
    bulletFormat.setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletRomanUCPeriod));
    bulletFormat.setNumberedBulletStartWith(java.newShort(1));
    paragraphFormat.setMarginLeft(30);
    paragraphFormat.setIndent(-20);

    presentation.save("updated_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **خواندن مقادیر واقعی نقطه‌ها**

هنگام استخراج محتوای ارائه، نشانگرهای فهرست را همراه با متن پاراگراف نگه داشته باشید. فراخوانی کنید [ParagraphFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getEffective) و به [IParagraphFormatEffectiveData.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformateffectivedata/#getBullet--) دسترسی پیدا کنید تا قالب نقطه مؤثر را به دست آورید. پیش از خواندن [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--)، متد [getType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getType--) آن را بررسی کنید.

برای فهرست‌های شماره‌دار، این سه مقدار را متمایز کنید:

- [getNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStyle--) فرمت را تعیین می‌کند، مانند اعداد عربی به همراه نقطه یا حروف کوچک به همراه نقطه.
- [getNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStartWith--) عدد شروع برای یک گروه از پاراگراف‌های شماره‌دار را مشخص می‌کند.
- [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) نشانگر قالب‌بندی‌شده برای یک پاراگراف خاص را برمی‌گرداند. برای مثال، دومین مورد در فهرست که از 5 شروع شده است، `6.` را برمی‌گرداند.

با حفظ [getDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDepth) برای هر پاراگراف، سطح تو در توی آن حفظ می‌شود. نشانگر واقعی تمام ساختار سلسله‌مراتبی را رمزگذاری نمی‌کند: یک مورد تو در تو می‌تواند `c.` را برگرداند نه برچسب ترکیبی مثل `6.c.`.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const black = java.newInstanceSync("java.awt.Color", 0, 0, 0);

const presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 440, aspose.slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 20, 660, 400);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // یک نشانگر تصویری بدون فایل تصویر خارجی ایجاد کنید.
    const svg = new aspose.slides.SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    const bulletImage = presentation.getImages().addImage(svg);

    function addParagraph(text, depth, type, start, style) {
        const paragraph = new aspose.slides.Paragraph();
        paragraph.setText(text);

        const format = paragraph.getParagraphFormat();
        format.setDepth(java.newShort(depth));
        format.setMarginLeft(30 + depth * 40);
        format.setIndent(-28);
        format.setSpaceAfter(8);
        format.getDefaultPortionFormat().setFontHeight(22);
        format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(black);
        format.getBullet().setType(java.newByte(type));
        format.getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
        format.getBullet().getColor().setColor(black);
        if (type === aspose.slides.BulletType.Numbered) {
            format.getBullet().setNumberedBulletStyle(java.newByte(style));
            format.getBullet().setNumberedBulletStartWith(java.newShort(start));
        } else if (type === aspose.slides.BulletType.Symbol) {
            format.getBullet().setChar(java.newChar(0x2022));
        } else if (type === aspose.slides.BulletType.Picture) {
            format.getBullet().getPicture().setImage(bulletImage);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    addParagraph("First item", 0, aspose.slides.BulletType.Numbered, 5, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    addParagraph("Second item", 0, aspose.slides.BulletType.Numbered, 5, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    addParagraph("Nested item", 1, aspose.slides.BulletType.Numbered, 3, aspose.slides.NumberedBulletStyle.BulletAlphaLCPeriod);
    addParagraph("Next nested item", 1, aspose.slides.BulletType.Numbered, 3, aspose.slides.NumberedBulletStyle.BulletAlphaLCPeriod);
    addParagraph("Deep item", 2, aspose.slides.BulletType.Numbered, 4, aspose.slides.NumberedBulletStyle.BulletRomanLCPeriod);
    addParagraph("Back to top level", 0, aspose.slides.BulletType.Numbered, 5, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    addParagraph("Symbol marker", 0, aspose.slides.BulletType.Symbol, 1, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    addParagraph("No bullet", 0, aspose.slides.BulletType.None, 1, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    addParagraph("Picture marker", 0, aspose.slides.BulletType.Picture, 1, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    presentation.save("actual_bullet_values.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const loadedPresentation = new aspose.slides.Presentation("actual_bullet_values.pptx");
try {
    const loadedShape = loadedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Text | Depth | Type | Actual value");
    const paragraphs = loadedShape.getTextFrame().getParagraphs();
    for (let i = 0; i < paragraphs.getCount(); i++) {
        const paragraph = paragraphs.get_Item(i);
        const bullet = paragraph.getParagraphFormat().getEffective().getBullet();
        let marker;
        switch (bullet.getType()) {
            case aspose.slides.BulletType.Numbered:
            case aspose.slides.BulletType.Symbol:
                marker = bullet.getActualBulletValue();
                break;
            case aspose.slides.BulletType.None:
                marker = bullet.getActualBulletValue() + " (no bullet)";
                break;
            case aspose.slides.BulletType.Picture:
                marker = bullet.getActualBulletValue() + " (image required)";
                break;
            default:
                marker = "unsupported bullet type";
                break;
        }
        const typeName = Object.keys(aspose.slides.BulletType).find(name => aspose.slides.BulletType[name] === bullet.getType());
        console.log(paragraph.getText() + " | " + paragraph.getParagraphFormat().getDepth() + " | " + typeName + " | " + marker);
    }
} finally {
    loadedPresentation.dispose();
}
```

منابع فهرست در زیر نشان داده شده‌اند.

![فهرست‌ها شروع از 5، موارد حروف تو در تو و اعداد رومی، یک نشانگر نمادیک، یک پاراگراف بدون نقطه و یک نشانگر تصویر آبی](actual_bullet_values.png)

گزارش با نشانگرهای نمایش داده‌شده در PowerPoint مطابقت دارد:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

برای [BulletType.None and BulletType.Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/)، [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) مقدار `null` را برمی‌گرداند، نه رشته خالی. این انواع را به‌صورت جداگانه مدیریت کنید: نوع اول هیچ نشانگری ندارد، در حالی که نوع دوم نیاز به استخراج تصویر نقطه به‌صورت جداگانه دارد. یک نقطه تصویر نمی‌تواند صرفاً با استخراج یک نشانگر متن بازآفرینی شود.

## **پرسش‌های متداول**

**آیا فهرست‌های نقطه‌دار و شماره‌دار می‌توانند به PDF یا تصاویر صادر شوند؟**

بله. Aspose.Slides قالب‌بندی فهرست را هنگامیکه فرمت هدف از چیدمان متن و ویژگی‌های نقطه پشتیبانی کند، حفظ می‌کند.

**آیا می‌توان فهرست‌ها را در ارائه‌های موجود ویرایش کرد؟**

بله. ارائه را بارگذاری کنید، به پاراگراف هدف دسترسی پیدا کنید، تنظیمات `ParagraphFormat.getBullet` آن را بررسی یا به‌روزرسانی کنید و ارائه را ذخیره کنید.

**آیا فهرست‌ها می‌توانند متن غیر لاتین داشته باشند؟**

بله. متن موارد فهرست می‌تواند شامل کاراکترهای یونیکد باشد، بنابراین می‌توانید فهرست‌ها را در ارائه‌های چندزبانه ایجاد کنید. اطمینان حاصل کنید فونت‌های استفاده‌شده در ارائه کاراکترهای مورد نیاز شما را پشتیبانی می‌کنند.