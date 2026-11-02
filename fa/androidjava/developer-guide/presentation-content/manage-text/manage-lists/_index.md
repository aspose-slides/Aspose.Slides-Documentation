---
title: "مدیریت فهرست‌های نقطه‌دار و شماره‌دار در ارائه‌ها بر روی اندروید"
linktitle: "مدیریت فهرست‌ها"
type: docs
weight: 60
url: /fa/androidjava/manage-lists/
keywords:
- "نقطه"
- "فهرست نقطه‌دار"
- "فهرست شماره‌دار"
- "نقطه نمادین"
- "نقطه تصویری"
- "نقطه سفارشی"
- "فهرست چندسطحی"
- "ایجاد نقطه"
- "افزودن نقطه"
- "افزودن فهرست"
- "PowerPoint"
- "OpenDocument"
- "ارائه"
- "Android"
- "Java"
- "Aspose.Slides"
description: "یاد بگیرید چگونه فهرست‌های نقطه‌دار، تصویری، چندسطحی و شماره‌دار را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای اندروید از طریق جاوا ایجاد و قالب‌بندی کنید."
---
## **بررسی کلی**

Aspose.Slides for Android via Java به شما امکان می‌دهد فهرست‌های نقطه‌دار و شماره‌دار را در ارائه‌های PowerPoint و OpenDocument ایجاد و قالب‌بندی کنید. یک مورد فهرست یک پاراگراف است که تنظیمات نقطه‌گذاری آن از طریق قالب‌بندی پاراگراف کنترل می‌شود.

از متد [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) برای دسترسی به تنظیمات فهرست در سطح پاراگراف استفاده کنید. نقطه ورود اصلی [IParagraphFormat.getBullet](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) است که یک شیء [IBulletFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/) برمی‌گرداند. با استفاده از این شیء می‌توانید نوع نقطه، نماد، تصویر، رنگ، اندازه، سبک شماره‌گذاری و عدد شروع را تنظیم کنید.

این مقاله نشان می‌دهد چگونه:

- فهرست نقطه‌دار با نماد سفارشی ایجاد کنید
- تصویر نقطه‌ای ایجاد کنید
- فهرست چندسطحی را با تنظیم عمق پاراگراف بسازید
- فهرست شماره‌دار ایجاد کنید
- قالب‌بندی فهرست موجود در یک ارائه را بررسی و تغییر دهید
- مقادیر واقعی نقطه‌ها و اعداد را همراه با متن پاراگراف بخوانید

## **ایجاد فهرست نقطه‌دار**

برای ایجاد فهرست نقطه‌دار، پاراگراف‌ها را به یک [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) اضافه کنید و [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) را روی [BulletType.Symbol](https://reference.aspose.com/slides/androidjava/com.aspose.slides/bullettype/) تنظیم کنید. سپس می‌توانید [IBulletFormat.setChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setChar-char-)، [IBulletFormat.getColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#getColor--) و [IBulletFormat.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setHeight-float-) را برای کنترل ظاهر نقطه تنظیم کنید.

کد Java زیر نحوه ایجاد فهرست نقطه‌دار را در یک اسلاید نشان می‌دهد:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    int bulletColor = Color.rgb(205, 92, 92);

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

![نمادهای نقطه‌ای](symbol_bullets.png)

## **ایجاد فهرست شماره‌دار**

از فهرست‌های شماره‌دار زمانی استفاده کنید که ترتیب موارد اهمیت دارد. [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) را روی [BulletType.Numbered](https://reference.aspose.com/slides/androidjava/com.aspose.slides/bullettype/) تنظیم کنید. همچنین می‌توانید قالب شماره‌گذاری را با [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) انتخاب کنید یا هنگام نیاز به شروع فهرست از مقدار دیگری نسبت به ۱، با [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) مقدار شروع را تنظیم کنید.

کد Java زیر نحوه ایجاد فهرست شماره‌دار را در یک اسلید نشان می‌دهد:

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

![نمادهای شماره‌دار](numbered_bullets.png)

## **ایجاد تصویر نقطه‌ای**

Aspose.Slides به شما اجازه می‌دهد نماد نقطه‌ی معمولی را با تصویری جایگزین کنید. تصویرهای نقطه‌ای بهترین عملکرد را با تصاویر ساده‌ای که در اندازه کوچک قابل خواندن هستند، مانند آیکون‌ها یا فایل‌های PNG شفاف کوچک، دارند.

{{% alert color="info" title="Note" %}}
در صورتی که قصد دارید نماد نقطه‌ی معمولی را با تصویر جایگزین کنید، بهتر است گرافیک ساده‌ای با پس‌زمینه شفاف انتخاب کنید. چنین تصاویری به‌عنوان نمادهای سفارشی نقطه عملکرد خوبی دارند.
همچنین به یاد داشته باشید که تصویر به اندازه بسیار کوچکی مقیاس‌بندی می‌شود. به همین دلیل توصیه می‌کنیم تصویری انتخاب کنید که حتی در این اندازه نیز واضح و مؤثر باشد.
{{% /alert %}}

برای ایجاد تصویر نقطه‌ای، یک تصویر به [Presentation.getImages](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getImages--) اضافه کنید و شیء بازگردانده شده [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) را به [IBulletFormat.getPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#getPicture--) اختصاص دهید. قبل از اختصاص تصویر، [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) را روی [BulletType.Picture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/bullettype/) تنظیم کنید.

فرض کنید فایلی به نام "image.png" داریم:

![تصویری برای نقطه‌ها](picture_for_bullets.png)

کد Java زیر نشان می‌دهد چگونه تصویر نقطه‌ای در یک اسلاید ایجاد شود:

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

![نقطه‌های تصویری](picture_bullets.png)

## **ایجاد فهرست چندسطحی**

از [IParagraphFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) برای قرار دادن موارد فهرست در سطوح مختلف استفاده کنید. سطح ۰ بالاترین سطح است، سطح ۱ زیرمجموعه آن و به همین ترتیب.

کد Java زیر نحوه ایجاد فهرست چندسطحی را نشان می‌دهد:

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

برای تغییر قالب‌بندی فهرست در یک ارائه موجود، پاراگراف هدف را دسترسی پیدا کنید و تنظیمات [IParagraphFormat.getBullet](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) آن را به‌روزرسانی کنید. همان متدهایی که برای ایجاد فهرست‌ها استفاده می‌شوند، می‌توانند برای بررسی یا اصلاح فهرست‌های بارگذاری‌شده از فایل PPT، PPTX یا ODP به کار روند.

کد Java زیر پاراگراف اول یک فریم متن را به سبک فهرست شماره‌دار تغییر می‌دهد:

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

## **خواندن مقادیر واقعی نقطه‌ها**

هنگام استخراج محتویات ارائه، علامت‌های فهرست را همراه با متن پاراگراف نگه دارید. با فراخوانی [IParagraphFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getEffective--) و دسترسی به [IParagraphFormatEffectiveData.getBullet](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformateffectivedata/#getBullet--) قالب‌بندی نقطه مؤثر را دریافت کنید. قبل از خواندن [getActualBulletValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--)، نوع آن را با [getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformateffectivedata/#getType--) بررسی کنید.

برای فهرست‌های شماره‌دار، این سه مقدار را متمایز کنید:

- [getNumberedBulletStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStyle--) فرمت را تعیین می‌کند، مانند اعداد عربی به‌همراه نقطه یا حروف کوچک به‌همراه نقطه.
- [getNumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStartWith--) عدد شروع را برای گروهی از پاراگراف‌های شماره‌دار مشخص می‌کند.
- [getActualBulletValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) علامت قالب‌بندی‌شده برای پاراگراف خاص را برمی‌گرداند. برای مثال، مورد دوم در فهرستی که از ۵ شروع می‌شود، `6.` را برمی‌گرداند.

با هر پاراگراف مقدار [getDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDepth--) را حفظ کنید تا سطح تو در توی آن نگه داشته شود. علامت واقعی سلسله مراتب کامل را رمزگذاری نمی‌کند: یک مورد تو در تو می‌تواند `c.` را برگرداند به‌جای برچسب ترکیبی مانند `6.c.`.

مثال خودکفایی زیر فهرست‌ها را ایجاد می‌کند، آن‌ها را در یک ارائه ذخیره می‌کند و سپس ارائه را بارگذاری می‌کند تا متن، عمق، نوع نقطه و مقدار واقعی هر پاراگراف را گزارش دهد. علامت تصویری آبی کوچک از SVG درون‌خطی ساخته می‌شود.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 440, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20, 660, 400);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // یک نشانگر تصویری بدون فایل تصویر خارجی ایجاد کنید.
    SvgImage svg = new SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    IPPImage bulletImage = presentation.getImages().addImage(svg);

    class ListBuilder {
        void addParagraph(String text, short depth, byte type, short start, byte style) {
            Paragraph paragraph = new Paragraph();
            paragraph.setText(text);

            IParagraphFormat format = paragraph.getParagraphFormat();
            format.setDepth(depth);
            format.setMarginLeft(30 + depth * 40);
            format.setIndent(-28);
            format.setSpaceAfter(8);
            format.getDefaultPortionFormat().setFontHeight(22);
            format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
            format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
            format.getBullet().setType(type);
            format.getBullet().setBulletHardColor(NullableBool.True);
            format.getBullet().getColor().setColor(Color.BLACK);
            if (type == BulletType.Numbered) {
                format.getBullet().setNumberedBulletStyle(style);
                format.getBullet().setNumberedBulletStartWith(start);
            } else if (type == BulletType.Symbol) {
                format.getBullet().setChar('\u2022');
            } else if (type == BulletType.Picture) {
                format.getBullet().getPicture().setImage(bulletImage);
            }

            textFrame.getParagraphs().add(paragraph);
        }
    }

    ListBuilder list = new ListBuilder();
    list.addParagraph("First item", (short) 0, BulletType.Numbered, (short) 5, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Second item", (short) 0, BulletType.Numbered, (short) 5, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Nested item", (short) 1, BulletType.Numbered, (short) 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    list.addParagraph("Next nested item", (short) 1, BulletType.Numbered, (short) 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    list.addParagraph("Deep item", (short) 2, BulletType.Numbered, (short) 4, NumberedBulletStyle.BulletRomanLCPeriod);
    list.addParagraph("Back to top level", (short) 0, BulletType.Numbered, (short) 5, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Symbol marker", (short) 0, BulletType.Symbol, (short) 1, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("No bullet", (short) 0, BulletType.None, (short) 1, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Picture marker", (short) 0, BulletType.Picture, (short) 1, NumberedBulletStyle.BulletArabicPeriod);
    presentation.save("actual_bullet_values.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation loadedPresentation = new Presentation("actual_bullet_values.pptx");
try {
    IAutoShape loadedShape = (IAutoShape) loadedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Text | Depth | Type | Actual value");
    for (IParagraph paragraph : loadedShape.getTextFrame().getParagraphs()) {
        IBulletFormatEffectiveData bullet = paragraph.getParagraphFormat().getEffective().getBullet();
        String marker;
        switch (bullet.getType()) {
            case BulletType.Numbered:
            case BulletType.Symbol:
                marker = bullet.getActualBulletValue();
                break;
            case BulletType.None:
                marker = bullet.getActualBulletValue() + " (no bullet)";
                break;
            case BulletType.Picture:
                marker = bullet.getActualBulletValue() + " (image required)";
                break;
            default:
                marker = "unsupported bullet type";
                break;
        }
        String typeName = BulletType.getName(BulletType.class, bullet.getType());
        System.out.println(paragraph.getText() + " | " + paragraph.getParagraphFormat().getDepth() + " | " + typeName + " | " + marker);
    }
} finally {
    loadedPresentation.dispose();
}
```

فهرست‌های منبع در زیر نشان داده شده‌اند.

![فهرست‌هایی که از 5 شروع می‌شوند، موارد حروفی تو در تو و شماره‌گذاری رومی، مارکر نماد، پاراگراف بدون نقطه و مارکر تصویر آبی](actual_bullet_values.png)

گزارش با علامت‌های نمایش داده‌شده در PowerPoint مطابقت دارد:

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

برای [BulletType.None and BulletType.Picture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/bullettype/)، [getActualBulletValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) مقدار `null` را برمی‌گرداند، نه یک رشته خالی. این انواع را به‌صورت جداگانه مدیریت کنید: قبلی هیچ علامتی ندارد، در حالی که دومی نیاز دارد تصویر نقطه به‌صورت جداگانه استخراج شود. یک تصویر نقطه‌ای نمی‌تواند فقط با استخراج یک علامت متنی بازتولید شود.

## **سؤالات متداول**

**آیا می‌توان فهرست‌های نقطه‌دار و شماره‌دار را به PDF یا تصویر صادر کرد؟**

بله. Aspose.Slides قالب‌بندی فهرست را زمانی که فرمت هدف ویژگی‌های متن و نقطه مربوطه را پشتیبانی کند، حفظ می‌کند.

**آیا می‌توان فهرست‌ها را در ارائه‌های موجود ویرایش کرد؟**

بله. ارائه را بارگذاری کنید، پاراگراف هدف را دسترسی پیدا کنید، تنظیمات [IParagraphFormat.getBullet](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) آن را بررسی یا به‌روزرسانی کنید و سپس ارائه را ذخیره کنید.

**آیا فهرست‌ها می‌توانند متن غیرلاتین داشته باشند؟**

بله. متن موارد فهرست می‌تواند شامل کاراکترهای یونیکد باشد، بنابراین می‌توانید فهرست‌ها را در ارائه‌های چندزبانه ایجاد کنید. اطمینان حاصل کنید که قلم‌های مورد استفاده در ارائه از کاراکترهای مورد نیاز پشتیبانی می‌کنند.