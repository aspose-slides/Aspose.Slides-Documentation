---
title: مدیریت فهرست‌های نقطه‌دار و شماره‌دار در ارائه‌ها با Java
linktitle: مدیریت فهرست‌ها
type: docs
weight: 60
url: /fa/java/manage-lists/
keywords:
- گلوله
- فهرست نقطه‌دار
- فهرست شماره‌دار
- گلوله نماد
- گلوله تصویری
- گلوله سفارشی
- فهرست چندسطحی
- ایجاد گلوله
- افزونن گلوله
- افزودن فهرست
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه فهرست‌های نقطه‌دار، تصویری، چندسطحی و شماره‌دار را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Java ایجاد و قالب‌بندی کنید."
---
## **نمای کلی**

Aspose.Slides for Java به شما اجازه می‌دهد که فهرست‌های نقطه‌دار و شماره‌دار را در ارائه‌های PowerPoint و OpenDocument ایجاد و قالب‌بندی کنید. یک مورد فهرست یک پاراگراف است که تنظیمات گلوله آن از طریق قالب‌بندی پاراگراف کنترل می‌شود.

از متد [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getParagraphFormat--) برای دسترسی به تنظیمات فهرست در سطح پاراگراف استفاده کنید. نقطه ورودی اصلی [IParagraphFormat.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getBullet--) است که یک شیء [IBulletFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/) را برمی‌گرداند. با استفاده از این شیء می‌توانید نوع گلوله، نماد، تصویر، رنگ، اندازه، سبک شماره‌گذاری و شماره شروع را تنظیم کنید.

این مقاله نشان می‌دهد که چگونه:
- ایجاد فهرست نقطه‌دار با نماد سفارشی
- ایجاد گلوله تصویری
- ایجاد فهرست چندسطحی با تنظیم عمق پاراگراف
- ایجاد فهرست شماره‌دار
- بازرسی و تغییر قالب‌بندی فهرست در یک ارائه موجود
- خواندن مارکرها و شماره‌های واقعی فهرست همراه با متن پاراگراف

## **ایجاد فهرست نقطه‌دار**

برای ایجاد فهرست نقطه‌دار، اشیاء [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) را به یک [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) اضافه کنید و [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) را روی [BulletType.Symbol](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/#Symbol) تنظیم کنید. سپس می‌توانید [IBulletFormat.setChar](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setChar-char-)، [IBulletFormat.getColor](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#getColor--) و [IBulletFormat.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setHeight-float-) را برای کنترل ظاهر گلوله تنظیم کنید.

کد جاوای زیر نحوه ایجاد فهرست نقطه‌دار در یک اسلاید را نشان می‌دهد:
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
![گلوله‌های نماد](symbol_bullets.png)

## **ایجاد فهرست شماره‌دار**

از فهرست‌های شماره‌دار زمانی که ترتیب موارد اهمیت دارد استفاده کنید. [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) را روی [BulletType.Numbered](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/#Numbered) تنظیم کنید. همچنین می‌توانید قالب شماره‌گذاری را با [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) انتخاب کنید یا با [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) زمانی که فهرست باید از مقدار دیگری غیر از 1 شروع شود تنظیم نمایید.

کد جاوای زیر نشان می‌دهد چگونه فهرست شماره‌دار در یک اسلاید ایجاد شود:
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
![گلوله‌های شماره‌دار](numbered_bullets.png)

## **ایجاد گلوله تصویری**

Aspose.Slides به شما امکان می‌دهد نماد گلوله معمولی را با یک تصویر جایگزین کنید. گلوله‌های تصویری بهترین عملکرد را با تصاویر ساده‌ای که در اندازه کوچک قابل خواندن باقی می‌مانند، مانند آیکون‌ها یا فایل‌های PNG شفاف کوچک، دارند.

{{% alert color="info" title="Note" %}}
در حالت ایده‌آل، اگر قصد جایگزینی نماد گلوله معمولی با یک تصویر را دارید، بهتر است یک گرافیک ساده با پس‌زمینه شفاف انتخاب کنید. چنین تصاویری به‌عنوان نمادهای سفارشی گلوله به خوبی کار می‌کنند.
{{% /alert %}}

برای ایجاد گلوله تصویری، یک تصویر به [Presentation.getImages](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getImages--) اضافه کنید و شیء تصویر بازگردانده‌شده را به [IBulletFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#getPicture--) اختصاص دهید. قبل از اختصاص تصویر، [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) را روی [BulletType.Picture](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/#Picture) تنظیم کنید.

فرض کنید فایل "image.png" را داریم:
![تصویری برای گلوله‌ها](picture_for_bullets.png)

کد جاوای زیر نشان می‌دهد چگونه گلوله‌های تصویری در یک اسلاید ایجاد شوند:
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
![گلوله‌های تصویری](picture_bullets.png)

## **ایجاد فهرست چندسطحی**

از [IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) برای قرار دادن موارد فهرست در سطوح مختلف استفاده کنید. سطح ۰ بالاترین سطح است، سطح ۱ زیر آن تو در تو است و به همین ترتیب.

کد جاوای زیر نشان می‌دهد چگونه فهرست نقطه‌دار چندسطحی ایجاد شود:
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

برای تغییر قالب‌بندی فهرست در یک ارائه موجود، به پاراگراف هدف دسترسی پیدا کنید و تنظیمات [IParagraphFormat.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getBullet--) آن را به‌روز کنید. همان خصوصیات استفاده‌شده برای ایجاد فهرست‌ها می‌توانند برای بررسی یا اصلاح فهرست‌های بارگذاری‌شده از فایل‌های PPT، PPTX یا ODP استفاده شوند.
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

## **خواندن مقادیر واقعی گلوله**

هنگام استخراج محتوای ارائه، مارکرهای فهرست را همراه با متن پاراگراف نگه دارید. با فراخوانی [IParagraphFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getEffective--) و دسترسی به [IParagraphFormatEffectiveData.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformateffectivedata/#getBullet--) قالب‌بندی مؤثر گلوله را دریافت کنید. قبل از خواندن [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--)، [getType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getType--) آن را بررسی کنید.

برای فهرست‌های شماره‌دار، این سه مقدار را متمایز کنید:
- [getNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStyle--) قالب را تعیین می‌کند، مانند اعداد عربی همراه با نقطه یا حروف کوچک همراه با نقطه.
- [getNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStartWith--) عدد شروع برای یک گروه از پاراگراف‌های شماره‌دار را مشخص می‌کند.
- [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) نشانگر قالب‌بندی شده برای یک پاراگراف خاص را برمی‌گرداند. برای مثال، دومین مورد در فهرستی که از 5 شروع می‌شود، `6.` را برمی‌گرداند.

[getDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDepth--) را برای هر پاراگراف حفظ کنید تا سطح تو در توی آن حفظ شود. نشانگر واقعی کل سلسله‌مراتب را رمزگذاری نمی‌کند: یک مورد تو در تو می‌تواند `c.` را برگرداند نه برچسب ترکیبی مثل `6.c.`.

مثال خودکفای زیر فهرست‌ها را ایجاد می‌کند، آن‌ها را در یک ارائه ذخیره می‌نماید و سپس ارائه را دوباره بارگذاری می‌کند تا متن، عمق، نوع گلوله و مقدار واقعی هر پاراگراف را گزارش دهد. نشانگر تصویر کوچک آبی از SVG درون‌خط تولید شده است.
```java
import com.aspose.slides.*;
import java.awt.Color;

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
![فهرست‌های شروع‌شده از 5، موارد حروفی تو در تو و عددی رومی، نشانه نماد، پاراگراف بدون گلوله و نشانگر تصویر آبی](actual_bullet_values.png)

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

برای [BulletType.None and BulletType.Picture](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/)، [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) مقدار `null` را برمی‌گرداند، نه یک رشته خالی. این انواع را به‌صورت جداگانه مدیریت کنید: اولین مورد هیچ نشانگری ندارد، در حالی که مورد دوم نیاز به استخراج تصویر گلوله به‌صورت جداگانه دارد. یک گلوله تصویری نمی‌تواند تنها با استخراج یک نشانگر متنی بازتولید شود.

## **سوالات متداول**

**آیا می‌توان فهرست‌های نقطه‌دار و شماره‌دار را به PDF یا تصاویر صادر کرد؟**
بله. Aspose.Slides قالب‌بندی فهرست‌ها را حفظ می‌کند زمانی که فرمت هدف از چیدمان متن و ویژگی‌های گلوله مربوطه پشتیبانی می‌کند.

**آیا می‌توانم فهرست‌ها را در ارائه‌های موجود ویرایش کنم؟**
بله. ارائه را بارگذاری کنید، به پاراگراف هدف دسترسی پیدا کنید، تنظیمات [IParagraphFormat.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getBullet--) را بررسی یا به‌روز کنید و ارائه را ذخیره نمایید.

**آیا فهرست‌ها می‌توانند حاوی متن غیرلاتین باشند؟**
بله. متن موارد فهرست می‌تواند شامل کاراکترهای یونیکد باشد، بنابراین می‌توانید فهرست‌ها را در ارائه‌های چند زبانه ایجاد کنید. مطمئن شوید که فونت‌های استفاده‌شده در ارائه از کاراکترهای مورد نیاز شما پشتیبانی می‌کنند.