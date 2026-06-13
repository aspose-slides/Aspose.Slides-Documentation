---
title: مدیریت فهرست‌های گلوله‌ای و شماره‌دار در ارائه‌ها در Java
linktitle: مدیریت فهرست‌ها
type: docs
weight: 60
url: /fa/java/manage-lists/
keywords:
- گلوله
- فهرست گلوله‌ای
- فهرست شماره‌دار
- گلوله نمادین
- گلوله تصویری
- گلوله سفارشی
- فهرست چندسطحی
- ایجاد گلوله
- افزودن گلوله
- افزودن فهرست
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه فهرست‌های گلوله‌ای، تصویری، چندسطحی و شماره‌دار را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Java ایجاد و قالب‌بندی کنید."
---
## **بررسی کلی**

Aspose.Slides for Java به شما امکان می‌دهد فهرست‌های گلوله‌ای و شماره‌دار را در ارائه‌های PowerPoint و OpenDocument ایجاد و قالب‌بندی کنید. یک مورد فهرست، پاراگرافی است که تنظیمات گلوله آن از طریق قالب‌بندی پاراگراف کنترل می‌شود.

از متد[IParagraph.getParagraphFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraph/#getParagraphFormat--) برای دسترسی به تنظیمات فهرست در سطح پاراگراف استفاده کنید. نقطه ورود اصلی [IParagraphFormat.getBullet](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#getBullet--) است که یک شیء[IBulletFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibulletformat/) را برمی‌گرداند. با این شیء می‌توانید نوع گلوله، نماد، تصویر، رنگ، اندازه، سبک شماره‌گذاری و شماره آغاز را تنظیم کنید.

این مقاله نشان می‌دهد چگونه:

- یک فهرست گلوله‌ای با نماد سفارشی ایجاد کنید
- یک گلوله تصویری ایجاد کنید
- یک فهرست چندسطحی با تنظیم عمق پاراگراف ایجاد کنید
- یک فهرست شماره‌دار ایجاد کنید
- قالب‌بندی فهرست را در یک ارائه موجود بررسی و تغییر دهید

## **ایجاد فهرست گلوله‌ای**

برای ایجاد فهرست گلوله‌ای، اشیاء[IParagraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraph/) را به یک[ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) اضافه کنید و[IBulletFormat.setType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibulletformat/#setType-byte-) را روی[BulletType.Symbol](https://reference.aspose.com/slides/fa/java/com.aspose.slides/bullettype/#Symbol) تنظیم کنید. سپس می‌توانید[IBulletFormat.setChar](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibulletformat/#setChar-char-)،[IBulletFormat.getColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibulletformat/#getColor--) و[IBulletFormat.setHeight](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibulletformat/#setHeight-float-) را برای کنترل ظاهر گلوله تنظیم کنید.

کد Java زیر نحوه ایجاد فهرست گلوله‌ای را در یک اسلاید نشان می‌دهد:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Color bulletColor = new Color(205, 92, 92);

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph1.getParagraphFormat().getBullet().setChar('*');
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph1.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph2.getParagraphFormat().getBullet().setChar('*');
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph2.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![گلوله‌های نمادین](symbol_bullets.png)

## **ایجاد فهرست شماره‌دار**

زمانی که ترتیب موارد مهم است از فهرست‌های شماره‌دار استفاده کنید. [IBulletFormat.setType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibulletformat/#setType-byte-) را روی[BulletType.Numbered](https://reference.aspose.com/slides/fa/java/com.aspose.slides/bullettype/#Numbered) تنظیم کنید. همچنین می‌توانید یک قالب شماره‌گذاری را با[IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) انتخاب کنید یا هنگام نیاز به شروع از مقدار دیگری غیر از 1،[IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) را تنظیم کنید.

کد Java زیر نحوه ایجاد فهرست شماره‌دار را در یک اسلاید نشان می‌دهد:

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

![گلوله‌های شماره‌دار](numbered_bullets.png)

## **ایجاد گلوله تصویری**

Aspose.Slides به شما امکان می‌دهد نماد گلوله عادی را با یک تصویر جایگزین کنید. گلوله‌های تصویری بهترین عملکرد را با تصاویر ساده‌ای که در اندازه کوچک نیز قابل خواندن باشند، مانند آیکون‌ها یا فایل‌های PNG شفاف کوچک، دارند.

{{% alert color="primary" %}}
در صورتی که قصد دارید نماد گلوله عادی را با تصویر جایگزین کنید، بهتر است گرافیک ساده‌ای با پس‌زمینه شفاف انتخاب کنید. این گونه تصاویر به عنوان نمادهای سفارشی گلوله به خوبی عمل می‌کنند.

به یاد داشته باشید که تصویر به اندازه بسیار کوچک‌تری مقیاس می‌شود. به همین دلیل، به شدت توصیه می‌شود تصویری انتخاب کنید که حتی در این مقیاس نیز واضح و بصری مؤثر باقی بماند.
{{% /alert %}}

برای ایجاد گلوله تصویری، یک تصویر به[Presentation.getImages](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getImages--) اضافه کنید و شیء تصویر بازگردانده‌شده را به[IBulletFormat.getPicture](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibulletformat/#getPicture--) اختصاص دهید. قبل از اختصاص تصویر،[IBulletFormat.setType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibulletformat/#setType-byte-) را روی[BulletType.Picture](https://reference.aspose.com/slides/fa/java/com.aspose.slides/bullettype/#Picture) تنظیم کنید.

فرض کنید فایل "image.png" داریم:

![تصویر برای گلوله‌ها](picture_for_bullets.png)

کد Java زیر نحوه ایجاد گلوله‌های تصویری را در یک اسلاید نشان می‌دهد:

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

![گلوله‌های تصویری](picture_bullets.png)

## **ایجاد فهرست چندسطحی**

از[IParagraphFormat.setDepth](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#setDepth-short-) برای قرار دادن موارد فهرست در سطوح مختلف استفاده کنید. سطح 0 بالاترین سطح است، سطح 1 زیرمجموعه آن و به همین ترتیب.

کد Java زیر نحوه ایجاد فهرست گلوله‌ای چندسطحی را نشان می‌دهد:

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

برای تغییر قالب‌بندی فهرست در یک ارائه موجود، پاراگراف هدف را دسترسی یافته و تنظیمات[IParagraphFormat.getBullet](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#getBullet--) آن را به‌روزرسانی کنید. همان خصوصیات استفاده‌شده برای ایجاد فهرست‌ها می‌توانند برای بررسی یا اصلاح فهرست‌های بارگذاری‌شده از فایل‌های PPT، PPTX یا ODP به کار روند.

کد Java زیر اولین پاراگراف در یک چارچوب متن را به سبک فهرست شماره‌دار تغییر می‌دهد:

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

**آیا می‌توان فهرست‌های گلوله‌ای و شماره‌دار را به PDF یا تصویر صادر کرد؟**

بله. Aspose.Slides قالب‌بندی فهرست را زمانی که فرمت هدف از چیدمان متن و ویژگی‌های گلوله مربوطه پشتیبانی کند، حفظ می‌کند.

**آیا می‌توان فهرست‌ها را در ارائه‌های موجود ویرایش کرد؟**

بله. ارائه را بارگذاری کنید، به پاراگراف هدف دسترسی پیدا کنید، تنظیمات[IParagraphFormat.getBullet](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#getBullet--) آن را بررسی یا به‌روزرسانی کنید و سپس ارائه را ذخیره کنید.

**آیا فهرست‌ها می‌توانند متن غیرلاتین داشته باشند؟**

بله. متن مورد فهرست می‌تواند شامل کاراکترهای یونیکد باشد، بنابراین می‌توانید فهرست‌ها را در ارائه‌های چندزبانه ایجاد کنید. اطمینان حاصل کنید که فونت‌های استفاده‌شده در ارائه از کاراکترهای مورد نیاز پشتیبانی می‌کنند.