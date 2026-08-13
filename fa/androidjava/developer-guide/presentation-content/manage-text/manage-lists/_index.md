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
- Android
- Java
- Aspose.Slides
description: "چگونگی ایجاد و قالب‌بندی فهرست‌های نقطه‌دار، تصویری، چندسطحی و شماره‌دار در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای اندروید از طریق جاوا را بیاموزید."
---
## **نمای کلی**

Aspose.Slides for Android via Java به شما امکان می‌دهد فهرست‌های نقطه‌دار و شماره‌دار را در ارائه‌های PowerPoint و OpenDocument ایجاد و قالب‌بندی کنید. یک مورد فهرست یک پاراگراف است که تنظیمات نقطه‌گذاری آن از طریق قالب پاراگراف کنترل می‌شود.

از متد [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) برای دسترسی به تنظیمات فهرست در سطح پاراگراف استفاده کنید. نقطه ورودی اصلی [IParagraphFormat.getBullet](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) است که یک شیء [IBulletFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibulletformat/) برمی‌گرداند. با این شیء می‌توانید نوع نقطه، نماد، تصویر، رنگ، اندازه، سبک شماره‌گذاری و شماره شروع را تنظیم کنید.

این مقاله نحوهٔ:

- ایجاد فهرست نقطه‌دار با نماد سفارشی
- ایجاد نقطهٔ تصویری
- ایجاد فهرست چندسطحی با تنظیم عمق پاراگراف
- ایجاد فهرست شماره‌دار
- بررسی و تغییر قالب‌بندی فهرست در یک ارائهٔ موجود

را نشان می‌دهد.

## **ایجاد فهرست نقطه‌دار**

برای ایجاد فهرست نقطه‌دار، پاراگراف‌ها را به یک [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) اضافه کنید و متد [IBulletFormat.setType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) را به [BulletType.Symbol](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/bullettype/) تنظیم کنید. سپس می‌توانید با متدهای [IBulletFormat.setChar](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibulletformat/#setChar-char-)، [IBulletFormat.getColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibulletformat/#getColor--) و [IBulletFormat.setHeight](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibulletformat/#setHeight-float-) ظاهر نقطه را کنترل کنید.

کد جاوای زیر نحوهٔ ایجاد فهرست نقطه‌دار را در یک اسلاید نشان می‌دهد:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![نشان‌های نمادین](symbol_bullets.png)

## **ایجاد فهرست شماره‌دار**

زمانی که ترتیب موارد اهمیت دارد از فهرست‌های شماره‌دار استفاده کنید. متد [IBulletFormat.setType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) را به [BulletType.Numbered](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/bullettype/) تنظیم کنید. همچنین می‌توانید یک قالب شماره‌گذاری را با [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) انتخاب کنید یا با [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) مقدار شروع را زمانی که فهرست باید از عددی غیر از 1 شروع شود، تعیین کنید.

کد جاوای زیر نحوهٔ ایجاد فهرست شماره‌دار را در یک اسلاید نشان می‌دهد:

```java
import com.aspose.slides.*;

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

![نشان‌های شماره‌دار](numbered_bullets.png)

## **ایجاد نقطهٔ تصویری**

Aspose.Slides به شما اجازه می‌دهد نماد نقطهٔ معمولی را با یک تصویر جایگزین کنید. نقاط تصویری بهترین عملکرد را با تصاویر ساده‌ای که در اندازهٔ کوچک قابل خواندن باشند، مانند آیکون‌ها یا فایل‌های PNG شفاف کوچک، دارند.

{{% alert color="info" %}}
در صورتی که قصد جایگزینی نماد نقطهٔ معمولی با تصویر را دارید، بهتر است یک گرافیک ساده با پس‌زمینهٔ شفاف انتخاب کنید. چنین تصاویری به‌عنوان نمادهای نقطهٔ سفارشی مناسب هستند.
همچنین به این نکته توجه داشته باشید که تصویر تا اندازهٔ بسیار کوچکی مقیاس خواهد شد؛ به همین دلیل توصیه می‌کنیم تصویری انتخاب کنید که در این شرایط همچنان واضح و بصری مؤثر باشد.
{{% /alert %}}

برای ایجاد نقطهٔ تصویری، یک تصویر را با استفاده از [Presentation.getImages](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getImages--) اضافه کنید و شیء بازگشتی [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) را به متد [IBulletFormat.getPicture](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibulletformat/#getPicture--) اختصاص دهید. پیش از اختصاص تصویر، متد [IBulletFormat.setType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) را به [BulletType.Picture](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/bullettype/) تنظیم کنید.

فرض کنید فایلی به نام "image.png" داریم:

![یک تصویر برای نقاط](picture_for_bullets.png)

کد جاوای زیر نشان می‌دهد چگونه نقطه‌های تصویری را در یک اسلاید ایجاد کنید:

```java
import com.aspose.slides.*;

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

![نقاط تصویری](picture_bullets.png)

## **ایجاد فهرست چندسطحی**

از متد [IParagraphFormat.setDepth](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) برای قرار دادن موارد فهرست در سطوح مختلف استفاده کنید. سطح 0 بالاترین سطح است، سطح 1 زیرمجموعهٔ آن و به همین ترتیب.

کد جاوای زیر نحوهٔ ایجاد فهرست چندسطحی را نشان می‌دهد:

```java
import com.aspose.slides.*;

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

برای تغییر قالب‌بندی فهرست در یک ارائهٔ موجود، پاراگراف هدف را دسترسی یافته و تنظیمات [IParagraphFormat.getBullet](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) آن را به‌روزرسانی کنید. همان متدهایی که برای ایجاد فهرست‌ها استفاده می‌شوند، می‌توانند برای بررسی یا اصلاح فهرست‌های بارگذاری‌شده از فایل‌های PPT، PPTX یا ODP به کار روند.

کد جاوای زیر اولین پاراگراف در یک چارچوب متن را به سبک فهرست شماره‌دار تغییر می‌دهد:

```java
import com.aspose.slides.*;

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

### آیا می‌توان فهرست‌های نقطه‌دار و شماره‌دار را به PDF یا تصاویر صادر کرد؟

بله. Aspose.Slides قالب‌بندی فهرست‌ها را حفظ می‌کند هنگامی که فرمت هدف ویژگی‌های مربوط به چیدمان متن و نقطه را پشتیبانی می‌کند.

### آیا می‌توان فهرست‌ها را در ارائه‌های موجود ویرایش کرد؟

بله. ارائه را بارگیری کنید، به پاراگراف هدف دسترسی پیدا کنید، تنظیمات [IParagraphFormat.getBullet](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) آن را بررسی یا به‌روزرسانی کنید و سپس ارائه را ذخیره کنید.

### آیا فهرست‌ها می‌توانند متن غیر لاتین داشته باشند؟

بله. متن موارد فهرست می‌تواند شامل کاراکترهای یونیکد باشد، بنابراین می‌توانید فهرست‌هایی در ارائه‌های چندزبانه ایجاد کنید. مطمئن شوید قلم‌های مورد استفاده در ارائه کاراکترهای مورد نیاز شما را پشتیبانی می‌کند.