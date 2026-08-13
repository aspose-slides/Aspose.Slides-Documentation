---
title: مدیریت فهرست‌های بولت‌دار و عددی در ارائه‌ها در جاوا
linktitle: مدیریت فهرست‌ها
type: docs
weight: 60
url: /fa/java/manage-lists/
keywords:
- بولت
- فهرست بولت‌دار
- فهرست عددی
- بولت نماد
- بولت تصویری
- بولت سفارشی
- فهرست چندسطحی
- ایجاد بولت
- افزودن بولت
- افزودن فهرست
- PowerPoint
- OpenDocument
- ارائه
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه فهرست‌های بولت‌دار، تصویری، چندسطحی و عددی را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای جاوا ایجاد و قالب‌بندی کنید."
---
## **بررسی اجمالی**

Aspose.Slides for Java به شما امکان می‌دهد فهرست‌های بولت‌دار و عددی را در ارائه‌های PowerPoint و OpenDocument ایجاد و قالب‌بندی کنید. یک مورد فهرست یک پاراگراف است که تنظیمات بولت آن از طریق قالب‌بندی پاراگراف کنترل می‌شود.

از روش [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraph/#getParagraphFormat--) برای دسترسی به تنظیمات فهرست در سطح پاراگراف استفاده کنید. نقطه ورود اصلی [IParagraphFormat.getBullet](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#getBullet--) است که یک شیء [IBulletFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibulletformat/) را برمی‌گرداند. با این شیء می‌توانید نوع بولت، نماد، تصویر، رنگ، اندازه، سبک شماره‌گذاری و شماره شروع را تنظیم کنید.

این مقاله نشان می‌دهد چگونه:

- فهرست بولت‌دار با نماد سفارشی ایجاد شود
- بولت تصویری ایجاد شود
- فهرست چندسطحی با تنظیم عمق پاراگراف ایجاد شود
- فهرست عددی ایجاد شود
- قالب‌بندی فهرست در یک ارائه موجود را بررسی و تغییر دهید

## **ایجاد فهرست بولت‌دار**

برای ایجاد فهرست بولت‌دار، اشیای [IParagraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraph/) را به یک [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) اضافه کنید و [IBulletFormat.setType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibulletformat/#setType-byte-) را به [BulletType.Symbol](https://reference.aspose.com/slides/fa/java/com.aspose.slides/bullettype/#Symbol) تنظیم کنید. سپس می‌توانید [IBulletFormat.setChar](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibulletformat/#setChar-char-)، [IBulletFormat.getColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibulletformat/#getColor--) و [IBulletFormat.setHeight](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibulletformat/#setHeight-float-) را برای کنترل ظاهر بولت تنظیم کنید.

کد جاوا زیر نشان می‌دهد چگونه فهرست بولت‌دار در یک اسلاید ایجاد شود:

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

![The symbol bullets](symbol_bullets.png)

## **ایجاد فهرست عددی**

وقتی ترتیب موارد مهم است از فهرست‌های عددی استفاده کنید. [IBulletFormat.setType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibulletformat/#setType-byte-) را به [BulletType.Numbered](https://reference.aspose.com/slides/fa/java/com.aspose.slides/bullettype/#Numbered) تنظیم کنید. همچنین می‌توانید قالب شماره‌گذاری را با [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) انتخاب کنید یا با [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) زمانی که فهرست باید از مقداری غیر از 1 شروع شود، مقدار شروع را تنظیم کنید.

کد جاوا زیر نشان می‌دهد چگونه فهرست عددی در یک اسلاید ایجاد شود:

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

![The numbered bullets](numbered_bullets.png)

## **ایجاد بولت تصویری**

Aspose.Slides به شما اجازه می‌دهد نماد بولت معمولی را با یک تصویر جایگزین کنید. بولت‌های تصویری بهترین عملکرد را با تصاویر ساده‌ای که در اندازه کوچک نیز قابل خواندن هستند، مانند آیکون‌ها یا فایل‌های PNG شفاف کوچک، دارند.

{{% alert color="info" %}}
در صورت برنامه‌ریزی برای جایگزینی نماد بولت معمولی با یک تصویر، بهتر است گرافیک ساده‌ای با پس‌زمینه شفاف انتخاب کنید. چنین تصاویری به‌عنوان نمادهای بولت سفارشی به خوبی عمل می‌کنند.
به‌خاطر داشته باشید که تصویر به اندازه بسیار کوچکی مقیاس‌دهی می‌شود. برای این دلیل، به‌ شدت توصیه می‌کنیم تصویری انتخاب کنید که هنگام استفاده به‌عنوان بولت در یک فهرست واضح و مؤثر باقی بماند.
{{% /alert %}}

برای ایجاد بولت تصویری، یک تصویر را به [Presentation.getImages](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getImages--) اضافه کنید و شیء تصویر بازگردانده‌شده را به [IBulletFormat.getPicture](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibulletformat/#getPicture--) اختصاص دهید. قبل از اختصاص تصویر، [IBulletFormat.setType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibulletformat/#setType-byte-) را به [BulletType.Picture](https://reference.aspose.com/slides/fa/java/com.aspose.slides/bullettype/#Picture) تنظیم کنید.

فرض کنید تصویر "image.png" داریم:

![A picture for the bullets](picture_for_bullets.png)

کد جاوا زیر نشان می‌دهد چگونه بولت‌های تصویری در یک اسلاید ایجاد شود:

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

![The picture bullets](picture_bullets.png)

## **ایجاد فهرست چندسطحی**

از [IParagraphFormat.setDepth](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#setDepth-short-) برای قرار دادن موارد فهرست در سطوح مختلف استفاده کنید. سطح 0 بالاترین سطح است، سطح 1 زیر آن تو در تو می‌شود و به همین ترتیب.

کد جاوا زیر نشان می‌دهد چگونه فهرست بولت‌دار چندسطحی ایجاد شود:

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

![The multilevel list](multilevel_list.png)

## **تغییر فهرست موجود**

برای تغییر قالب‌بندی فهرست در یک ارائه موجود، پاراگراف هدف را دسترسی پیدا کنید و تنظیمات [IParagraphFormat.getBullet](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#getBullet--) آن را به‌روزرسانی کنید. همان خصوصیات مورد استفاده برای ایجاد فهرست‌ها می‌توانند برای بررسی یا اصلاح فهرست‌های بارگذاری‌شده از فایل PPT، PPTX یا ODP استفاده شوند.

کد جاوا زیر اولین پاراگراف در یک فریم متن را به سبک فهرست عددی تغییر می‌دهد:

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

### آیا فهرست‌های بولت‌دار و عددی می‌توانند به PDF یا تصویر صادر شوند؟

بله. Aspose.Slides قالب‌بندی فهرست را زمانی که فرمت هدف از چیدمان متن و ویژگی‌های بولت مربوطه پشتیبانی می‌کند، حفظ می‌کند.

### آیا می‌توانم فهرست‌ها را در ارائه‌های موجود ویرایش کنم؟

بله. ارائه را بارگذاری کنید، به پاراگراف هدف دسترسی پیدا کنید، تنظیمات [IParagraphFormat.getBullet](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#getBullet--) آن را بررسی یا به‌روزرسانی کنید و ارائه را ذخیره کنید.

### آیا فهرست‌ها می‌توانند متن غیرلاتین داشته باشند؟

بله. متن موارد فهرست می‌تواند شامل کاراکترهای یونیکد باشد، بنابراین می‌توانید فهرست‌ها را در ارائه‌های چندزبانه ایجاد کنید. اطمینان حاصل کنید که فونت‌های استفاده‌شده در ارائه، کاراکترهای مورد نیاز شما را پشتیبانی می‌کنند.