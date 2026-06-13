---
title: مدیریت فهرست‌های بولت‌دار و شماره‌دار در ارائه‌ها با استفاده از جاوااسکریپت
linktitle: مدیریت فهرست‌ها
type: docs
weight: 60
url: /fa/nodejs-java/manage-lists/
keywords:
- بولت
- فهرست بولت‌دار
- فهرست شماره‌دار
- بولت نمادین
- بولت تصویری
- بولت سفارشی
- فهرست چندسطحی
- ایجاد بولت
- افزودن بولت
- افزودن فهرست
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "یاد بگیرید چگونه فهرست‌های بولت‌دار، تصویری، چندسطحی و شماره‌دار را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Node.js از طریق Java ایجاد و قالب‌بندی کنید."
---
## **نمای کلی**

Aspose.Slides for Node.js via Java به شما امکان ایجاد و قالب‌بندی لیست‌های بولت‌دار و شماره‌دار در ارائه‌های PowerPoint و OpenDocument را می‌دهد. یک آیتم لیست یک پاراگراف است که تنظیمات بولت آن از طریق فرمت پاراگراف کنترل می‌شود.

از کلاس [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/) برای دسترسی به تنظیمات لیست در سطح پاراگراف استفاده کنید. نقطه ورود اصلی `Paragraph.getParagraphFormat().getBullet()` است که یک شیء [BulletFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bulletformat/) را برمی‌گرداند. با این شیء می‌توانید نوع بولت، نماد، تصویر، رنگ، اندازه، سبک شماره‌گذاری و شماره شروع را تنظیم کنید.

این مقاله نشان می‌دهد چگونه:

- ایجاد یک لیست بولت‌دار با نماد سفارشی
- ایجاد بولت تصویری
- ایجاد لیست چندسطحی با تنظیم عمق پاراگراف
- ایجاد لیست شماره‌دار
- بررسی و تغییر قالب‌بندی لیست در یک ارائه موجود

## **ایجاد لیست بولت‌دار**

برای ایجاد یک لیست بولت‌دار، اشیاء [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/) را به یک [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) اضافه کنید و `BulletFormat.setType` را به [BulletType.Symbol](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bullettype/) تنظیم کنید. سپس می‌توانید `BulletFormat.setChar`، `BulletFormat.getColor` و `BulletFormat.setHeight` را برای کنترل ظاهر بولت تنظیم کنید.

کد JavaScript زیر نحوه ایجاد یک لیست بولت‌دار در یک اسلاید را نشان می‌دهد:

```javascript
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

![گلوله‌های نماد](symbol_bullets.png)

## **ایجاد لیست شماره‌دار**

از لیست‌های شماره‌دار زمانی استفاده کنید که ترتیب آیتم‌ها مهم باشد. `BulletFormat.setType` را به [BulletType.Numbered](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bullettype/) تنظیم کنید. همچنین می‌توانید یک قالب شماره‌گذاری را با `BulletFormat.setNumberedBulletStyle` انتخاب کنید یا وقتی لیست باید از مقداری غیر از 1 شروع شود، `BulletFormat.setNumberedBulletStartWith` را تنظیم کنید.

کد JavaScript زیر نشان می‌دهد چگونه یک لیست شماره‌دار در یک اسلاید ایجاد کنید:

```javascript
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

![گلوله‌های شماره‌دار](numbered_bullets.png)

## **ایجاد بولت تصویری**

Aspose.Slides به شما اجازه می‌دهد نماد بولت معمولی را با یک تصویر جایگزین کنید. بولت‌های تصویری بهترین عملکرد را با تصاویر ساده‌ای دارند که در اندازه کوچک قابل خواندن باقی بمانند، مانند آیکون‌ها یا فایل‌های PNG شفاف کوچک.

{{% alert color="primary" %}}
در حالت ایده‌آل، اگر قصد دارید نماد بولت معمولی را با یک تصویر جایگزین کنید، بهتر است یک گرافیک ساده با پس‌زمینه شفاف انتخاب کنید. چنین تصاویری به عنوان نمادهای بولت سفارشی بسیار مناسب هستند.

به یاد داشته باشید که تصویر به اندازهٔ بسیار کوچک‌تری مقیاس‌بندی می‌شود. به همین دلیل، ما قویاً توصیه می‌کنیم تصویری را انتخاب کنید که هنگام استفاده به عنوان بولت در یک لیست واضح و بصری مؤثر باقی بماند.
{{% /alert %}}

برای ایجاد بولت تصویری، یک تصویر را به [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) با استفاده از `Presentation.getImages().addImage` اضافه کنید و شیء [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) بازگشتی را به `BulletFormat.getPicture().setImage` اختصاص دهید. قبل از اختصاص تصویر، `BulletFormat.setType` را به [BulletType.Picture](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bullettype/) تنظیم کنید.

فرض کنید فایلی به نام "image.png" داریم:

![تصویری برای بولت‌ها](picture_for_bullets.png)

کد JavaScript زیر نشان می‌دهد چگونه بولت‌های تصویری را در یک اسلاید ایجاد کنید:

```javascript
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

![بولت‌های تصویری](picture_bullets.png)

## **ایجاد لیست چندسطحی**

از `ParagraphFormat.setDepth` برای قرار دادن آیتم‌های لیست در سطوح مختلف استفاده کنید. سطح 0 بالاترین سطح است، سطح 1 زیر آن تو در تو می‌شود و به همین ترتیب.

کد JavaScript زیر نشان می‌دهد چگونه یک لیست بولت‌دار چندسطحی ایجاد کنید:

```javascript
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

![لیست چندسطحی](multilevel_list.png)

## **تغییر لیست موجود**

برای تغییر قالب‌بندی لیست در یک ارائه موجود، به پاراگراف هدف دسترسی پیدا کنید و تنظیمات `ParagraphFormat.getBullet` آن را به‌روزرسانی کنید. همان ویژگی‌هایی که برای ایجاد لیست‌ها استفاده می‌شوند می‌توانند برای بررسی یا اصلاح لیست‌های بارگذاری‌شده از فایل‌های PPT، PPTX یا ODP استفاده شوند.

کد JavaScript زیر پاراگراف اول در یک فریم متن را به استفاده از سبک لیست شماره‌دار تغییر می‌دهد:

```javascript
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

## **پرسش‌های متداول**

**آیا لیست‌های بولت‌دار و شماره‌دار می‌توانند به PDF یا تصاویر صادر شوند؟**

بله. Aspose.Slides قالب‌بندی لیست را حفظ می‌کند زمانی که فرمت هدف از چیدمان متن و ویژگی‌های بولت مربوطه پشتیبانی کند.

**آیا می‌توانم لیست‌ها را در ارائه‌های موجود ویرایش کنم؟**

بله. ارائه را بارگذاری کنید، به پاراگراف هدف دسترسی پیدا کنید، تنظیمات `ParagraphFormat.getBullet` آن را بررسی یا به‌روزرسانی کنید و سپس ارائه را ذخیره کنید.

**آیا لیست‌ها می‌توانند متن غیر لاتین داشته باشند؟**

بله. متن آیتم‌های لیست می‌تواند شامل کاراکترهای Unicode باشد، بنابراین می‌توانید لیست‌ها را در ارائه‌های چندزبانه ایجاد کنید. اطمینان حاصل کنید که فونت‌های استفاده شده در ارائه از کاراکترهای مورد نیاز شما پشتیبانی می‌کنند.