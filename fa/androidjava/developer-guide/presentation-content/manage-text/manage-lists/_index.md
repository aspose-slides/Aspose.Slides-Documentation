---
title: مدیریت فهرست‌های نقطه‌دار و شماره‌دار در ارائه‌ها بر روی اندروید
linktitle: مدیریت فهرست‌ها
type: docs
weight: 60
url: /fa/androidjava/manage-lists/
keywords:
- نقطه
- فهرست نقطه‌دار
- فهرست شماره‌دار
- نقطه نماد
- نقطه تصویری
- نقطه سفارشی
- فهرست چندسطحی
- ایجاد نقطه
- افزودن نقطه
- افزودن فهرست
- PowerPoint
- OpenDocument
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه فهرست‌های نقطه‌دار، تصویری، چندسطحی و شماره‌دار را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای اندروید از طریق جاوا ایجاد و قالب‌بندی کنید."
---
## **بررسی کلی**

Aspose.Slides for Android via Java به شما امکان ایجاد و قالب‌بندی فهرست‌های نقطه‌دار و شماره‌دار در ارائه‌های PowerPoint و OpenDocument را می‌دهد. یک مورد فهرست، پاراگرافی است که تنظیمات نقطه آن از طریق قالب پاراگراف آن کنترل می‌شود.

از متد [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) برای دسترسی به تنظیمات فهرست در سطح پاراگراف استفاده کنید. نقطه ورود اصلی متد [IParagraphFormat.getBullet](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) است که یک شیء [IBulletFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibulletformat/) بر می‌گرداند. با این شیء می‌توانید نوع نقطه، نماد، تصویر، رنگ، اندازه، سبک شماره‌گذاری و شماره شروع را تنظیم کنید.

این مقاله نشان می‌دهد چگونه:

- فهرست نقطه‌دار با نماد سفارشی ایجاد کنید
- نقطه تصویر ایجاد کنید
- فهرست چندسطحی با تنظیم عمق پاراگراف ایجاد کنید
- فهرست شماره‌دار ایجاد کنید
- قالب‌بندی فهرست موجود در یک ارائه را بررسی و تغییر دهید

## **ایجاد فهرست نقطه‌دار**

برای ایجاد فهرست نقطه‌دار، پاراگراف‌ها را به یک [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) اضافه کنید و [IBulletFormat.setType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) را به [BulletType.Symbol](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/bullettype/) تنظیم کنید. سپس می‌توانید [IBulletFormat.setChar](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibulletformat/#setChar-char-)، [IBulletFormat.getColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibulletformat/#getColor--) و [IBulletFormat.setHeight](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibulletformat/#setHeight-float-) را برای کنترل ظاهر نقطه تنظیم کنید.

کد جاوا زیر نشان می‌دهد چگونه فهرست نقطه‌دار در یک اسلاید ایجاد شود:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph1.getParagraphFormat().getBullet().setChar('*');
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph1.getParagraphFormat().getBullet().getColor().setColor(Color.RED);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph2.getParagraphFormat().getBullet().setChar('*');
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph2.getParagraphFormat().getBullet().getColor().setColor(Color.RED);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![نمادهای نقطه‌دار](symbol_bullets.png)

## **ایجاد فهرست شماره‌دار**

از فهرست‌های شماره‌دار زمانی استفاده کنید که ترتیب موارد مهم باشد. [IBulletFormat.setType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) را به [BulletType.Numbered](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/bullettype/) تنظیم کنید. همچنین می‌توانید قالب شماره‌گذاری را با [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) انتخاب کنید یا زمانی که فهرست باید از مقدار دیگری غیر از 1 شروع شود، با [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) مقدار شروع را تنظیم کنید.

کد جاوا زیر نشان می‌دهد چگونه فهرست شماره‌دار در یک اسلاید ایجاد شود:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![نمادهای شماره‌دار](numbered_bullets.png)

## **ایجاد نقطه تصویر**

Aspose.Slides به شما اجازه می‌دهد نماد نقطه معمولی را با یک تصویر جایگزین کنید. نقطه‌های تصویر بهترین کارایی را با تصاویر ساده‌ای که در اندازه کوچک نیز قابل خواندن باشند، مثل آیکون‌ها یا فایل‌های PNG شفاف کوچک، دارند.

{{% alert color="primary" %}}
در صورت تمایل به جایگزینی نماد نقطه معمولی با یک تصویر، بهتر است گرافیک ساده‌ای با پس‌زمینه شفاف انتخاب کنید. چنین تصاویری به‌عنوان نمادهای نقطه سفارشی به‌خوبی عمل می‌کنند.
به یاد داشته باشید که تصویر به اندازه بسیار کوچک مقیاس‌بندی می‌شود. به همین دلیل، توصیه می‌کنیم تصویری انتخاب کنید که حتی در این اندازه نیز واضح و مؤثر باشد.
{{% /alert %}}

برای ایجاد نقطه تصویر، یک تصویر را به [Presentation.getImages](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getImages--) اضافه کنید و شیء [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) برگردانده شده را به [IBulletFormat.getPicture](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibulletformat/#getPicture--) اختصاص دهید. قبل از اختصاص تصویر، [IBulletFormat.setType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) را به [BulletType.Picture](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/bullettype/) تنظیم کنید.

فرض کنید فایلی به نام "image.png" داریم:

![تصویری برای نقطه‌ها](picture_for_bullets.png)

کد جاوا زیر نشان می‌دهد چگونه نقطه‌های تصویری در یک اسلاید ایجاد شود:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    IPPImage bulletImage = presentation.getImages().addImage(Images.fromFile("image.png"));

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph1.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph2.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![نقطه‌های تصویری](picture_bullets.png)

## **ایجاد فهرست چندسطحی**

از متد [IParagraphFormat.setDepth](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) برای قرار دادن موارد فهرست در سطوح مختلف استفاده کنید. سطح 0 بالاترین سطح است، سطح 1 زیر آن تو در تو می‌شود و به همین ترتیب.

کد جاوا زیر نشان می‌دهد چگونه فهرست نقطه‌دار چندسطحی ایجاد شود:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().setDepth((short) 0);
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().setDepth((short) 1);
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().setDepth((short) 2);
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    Paragraph paragraph4 = new Paragraph();
    paragraph4.getParagraphFormat().setDepth((short) 3);
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![فهرست چندسطحی](multilevel_list.png)

## **تغییر فهرست موجود**

برای تغییر قالب‌بندی فهرست در یک ارائه موجود، به پاراگراف هدف دسترسی پیدا کنید و تنظیمات [IParagraphFormat.getBullet](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) آن را به‌روزرسانی کنید. همان متدهایی که برای ایجاد فهرست‌ها استفاده می‌شوند می‌توانند برای بررسی یا اصلاح فهرست‌های بارگذاری‌شده از فایل PPT، PPTX یا ODP به کار روند.

کد جاوا زیر اولین پاراگراف در یک فریم متن را به سبک فهرست شماره‌دار تغییر می‌دهد:

```java
Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 1);
    paragraph.getParagraphFormat().setMarginLeft(30);
    paragraph.getParagraphFormat().setIndent(-20);

    presentation.save("updated_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سوالات متداول**

**آیا فهرست‌های نقطه‌دار و شماره‌دار می‌توانند به PDF یا تصاویر صادر شوند؟**

بله. Aspose.Slides قالب‌بندی فهرست‌ها را هنگامی نگه می‌دارد که فرمت هدف ویژگی‌های متن و نقطه مربوطه را پشتیبانی کند.

**آیا می‌توانم فهرست‌ها را در ارائه‌های موجود ویرایش کنم؟**

بله. ارائه را بارگذاری کنید، به پاراگراف هدف دسترسی پیدا کنید، تنظیمات [IParagraphFormat.getBullet](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) آن را بررسی یا به‌روزرسانی کنید و سپس ارائه را ذخیره کنید.

**آیا فهرست‌ها می‌توانند متن غیرلاتین داشته باشند؟**

بله. متن موارد فهرست می‌تواند شامل کاراکترهای یونیکد باشد، بنابراین می‌توانید فهرست‌ها را در ارائه‌های چندزبانه ایجاد کنید. اطمینان حاصل کنید که فونت‌های مورد استفاده در ارائه از کاراکترهای مورد نیاز شما پشتیبانی می‌کنند.