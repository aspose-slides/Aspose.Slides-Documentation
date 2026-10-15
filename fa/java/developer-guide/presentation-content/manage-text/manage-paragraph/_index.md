---
title: مدیریت متن پاراگراف‌های پاورپوینت در جاوا
linktitle: مدیریت پاراگراف
type: docs
weight: 40
url: /fa/java/manage-paragraph/
aliases:
  - /java/paragraph/
  - /java/portion/
keywords:
- اضافه کردن متن
- اضافه کردن پاراگراف
- مدیریت متن
- مدیریت پاراگراف
- مدیریت گلوله
- تو رفتگی پاراگراف
- تو رفتگی آویزان
- گلوله پاراگراف
- فهرست شماره‌دار
- فهرست نقطه‌ای
- خصوصیات پاراگراف
- وارد کردن HTML
- متن به HTML
- پاراگراف به HTML
- پاراگراف به تصویر
- متن به تصویر
- خروجی پاراگراف
- پاورپوینت
- ارائه
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه پاراگراف‌ها، بخش‌ها، گلوله‌ها، فهرست‌های شماره‌دار، تو رفتگی‌ها، محتوای HTML و تصاویر پاراگراف را با Aspose.Slides for Java ایجاد و قالب‌بندی کنید."
---
## **مرور کلی**

Aspose.Slides for Java متن را به صورت سلسله‌مراتب فریم‌های متن، پاراگراف‌ها و بخش‌ها (Portions) نمایان می‌کند:

* [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) نمایانگر محفظه متن در یک شکل است و دسترسی به مجموعهٔ پاراگراف‌های آن را فراهم می‌کند.
* [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) نمایانگر یک پاراگراف در یک فریم متن است و دسترسی به بخش‌ها و قالب‌بندی سطح پاراگراف را ارائه می‌دهد.
* [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) نمایانگر یک بخش متن داخل یک پاراگراف است. هر بخش می‌تواند متن و قالب‌بندی سطح کاراکتر خود را داشته باشد.

در نتیجه یک پاراگراف می‌تواند متنی با فونت‌ها، رنگ‌ها، اندازه‌ها و قالب‌بندی‌های مختلف داشته باشد که با استفاده از بخش‌های متعدد ایجاد می‌شود.

## **ایجاد و قالب‌بندی پاراگراف‌ها**

پاراگراف‌ها را در فریم متن یک شکل ایجاد کنید و برای قالب‌بندی اجرای‌های متنی جداگانه از بخش‌ها استفاده کنید. این بخش نشان می‌دهد چگونه چندین بخش را در هر پاراگراف ترکیب کرده و رنگ‌ها، اندازهٔ فونت و سبک‌های مختلف را اعمال کنید.

### **ایجاد پاراگراف‌ها با بخش‌های متعدد**

مثال جاوای زیر سه پاراگراف ایجاد می‌کند که هر کدام شامل سه اجرای متنی در مجموعهٔ بازگشتی از [IParagraph.getPortions](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getPortions--) هستند. پاراگراف پیش‌فرض و بخش خالی آن مجدداً استفاده می‌شود، سپس پاراگراف‌ها و بخش‌های باقی‌مانده اضافه می‌شوند. قالب‌بندی از طریق [IPortion.getPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getPortionFormat--) انجام می‌شود: اولین بخش در هر پاراگراف قرمز، بولد و ۱۵ پوینت است؛ دومین بخش آبی، ایتالیک و ۱۸ پوینت؛ بخش سوم قالب‌بندی پیش‌فرض خود را حفظ می‌کند:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
    ITextFrame textFrame = shape.getTextFrame();

    IParagraph firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new Portion());
    firstParagraph.getPortions().add(new Portion());

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(secondParagraph);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    int paragraphCount = textFrame.getParagraphs().getCount();
    for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        IParagraph paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        int portionCount = paragraph.getPortions().getCount();
        for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            IPortion portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ایجاد فهرست‌های نقطه‌ای و عددی**

متن پاراگراف را به فهرست‌هایی با نمادها، اعداد یا تصاویر سفارشی سازماندهی کنید. مثال‌های این بخش شامل قالب‌بندی گلوله‌ها، فهرست‌های چندسطحی و اعداد شروع سفارشی می‌شود.

### **ایجاد فهرست نقطه‌ای یا عددی**

گلوله‌ها و شماره‌گذاری موارد مرتبط را برای اسکن آسان‌تر می‌کند. در Aspose.Slides، تنظیمات فهرست از طریق [IBulletFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/) تعریف می‌شود.

این مثال جاوا یک گلوله نمادین و یک مورد عددی را به همان فریم متن اضافه می‌کند. [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) نوع گلوله را انتخاب می‌کند، در حالی که [IBulletFormat.setChar](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setChar-char-) نماد را فراهم می‌کند و [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) سبک شماره‌گذاری را انتخاب می‌کند. هر دو مورد از گلوله‌های سیاه با ارتفاع ۱۰۰ درصد و تو رفتگی پاراگراف ۲۵ پوینت استفاده می‌کنند:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph symbolParagraph = new Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    symbolParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    Paragraph numberedParagraph = new Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **استفاده از گلوله‌های تصویری**

گلوله‌های تصویری به شما اجازه می‌دهند به جای نماد یا عدد، از تصویر سفارشی استفاده کنید.

این مثال جاوا یک تصویر را به مجموعهٔ تصاویر ارائه اضافه می‌کند به عنوان یک [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) و از آن به عنوان گلولهٔ پاراگراف استفاده می‌کند. برای استفاده از گلولهٔ تصویری [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) فراخوانی می‌شود و تصویر از طریق [IBulletFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#getPicture--) اختصاص می‌یابد. [IBulletFormat.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setHeight-float-) بر روی ۱۰۰ درصد تنظیم می‌شود تا گلوله نسبت به متن پاراگراف اندازه بگیرد:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage bulletImage = Images.fromFile("bullets.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **ایجاد فهرست چندسطحی**

[IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) را تنظیم کنید تا پاراگراف‌ها در سطوح مختلف فهرست قرار گیرند. سطح بالایی عمق `0` دارد.

این مثال جاوا مقادیر [IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) را از ۰ تا ۳ به چهار پاراگراف اختصاص می‌دهد و یک سلسله‌مراتب در یک فریم متن ایجاد می‌کند. هر پاراگراف از یک گلولهٔ نماد استفاده می‌کند و [IBulletFormat.setChar](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setChar-char-) بین یک گلولهٔ گرد و یک خط تیره به‌صورت متناوب می‌چرخد تا سطوح مجاور را متمایز کند:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    IParagraph firstParagraph = new Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    firstParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setDepth((short) 0);

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    secondParagraph.getParagraphFormat().getBullet().setChar('-');
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setDepth((short) 1);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    thirdParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setDepth((short) 2);

    IParagraph fourthParagraph = new Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    fourthParagraph.getParagraphFormat().getBullet().setChar('-');
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    fourthParagraph.getParagraphFormat().setDepth((short) 3);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **شروع اقلام فهرست عددی با مقادیر سفارشی**

از [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) برای تنظیم عدد اولیه نمایش داده‌شده برای پاراگراف عددی استفاده کنید.

این مثال جاوا [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) را برای استفاده از شماره‌گذاری برای سه پاراگراف تنظیم می‌کند و مقادیر [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) را به ترتیب ۲، ۳ و ۷ اختصاص می‌دهد. مقدار شروع برای هر پاراگراف جداگانه پیکربندی می‌شود تا اعداد نمایش داده‌شده مقادیر میانی را رد کنند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 2);
    textFrame.getParagraphs().add(firstParagraph);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 3);
    textFrame.getParagraphs().add(secondParagraph);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 7);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **کنترل چیدمان پاراگراف و ویژگی‌های پایان**

حاشیه‌ها و تو رفتگی‌های پاراگراف را تنظیم کنید تا موقعیت خط اول و خطوط بسته‌شده را کنترل کنید. می‌توانید علامت پایان پاراگراف را جدا از بخش‌های متنی قابل مشاهده قالب‌بندی کنید.

### **تنظیم تو رفتگی خط اول**

از روش [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) برای کنترل تو رفتگی خط اول یک پاراگراف استفاده کنید. این تنظیم فقط خط اول را نسبت به حاشیهٔ چپ پاراگراف جابه‌جا می‌کند. مقدار مثبت خط اول را به سمت راست می‌برد، در حالی که خطوط باقی‌مانده به بدنهٔ پاراگراف تراز می‌شوند.

از [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) زمانی استفاده کنید که می‌خواهید کل پاراگراف را جابه‌جا کنید. از [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) زمانی استفاده کنید که می‌خواهید فقط خط اول را جابه‌جا کنید.

مثال زیر سه پاراگراف را با همان [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) به میزان ۲۰ پوینت و مقادیر [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) برابر با ۰، ۲۰ و ۴۰ پوینت تنظیم می‌کند. خطوط اول به‌صورت افزایشی در فاصله شروع می‌شوند، در حالی که خطوط بسته‌شده همان حاشیهٔ چپ را حفظ می‌کنند:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![تو رفتگی خط اول پاراگراف‌ها](first_line_indent.png)

### **تنظیم تو رفتگی آویزان**

تو رفتگی آویزان یک چیدمان پاراگراف است که در آن خط اول در سمت چپ خطوط باقی‌مانده شروع می‌شود. در Aspose.Slides این اثر را با ویژگی [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) ایجاد می‌کنید. `Indent` را به مقدار منفی تنظیم کنید تا خط اول نسبت به بدنهٔ پاراگراف به سمت چپ جابه‌جا شود.

در عمل، [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) موقعیت چپ بدنهٔ پاراگراف را تعریف می‌کند و [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) موقعیت خط اول را نسبت به آن حاشیه مشخص می‌سازد. برای ایجاد تو رفتگی آویزان، مقدار مثبت `MarginLeft` و مقدار منفی `Indent` را تنظیم کنید.

این قالب‌بندی برای کتاب‌نامه‌ها، مراجع، ورودی‌های واژه‌نامه و سایر پاراگراف‌هایی که خطوط بسته‌شده باید زیر بدنهٔ پاراگراف نه زیر اولین کاراکتر خط اول تراز شوند، مفید است.

مثال جاوا زیر مقادیر [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) برابر با ۴۰ و ۶۰ پوینت را با مقادیر [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) برابر با -۲۰ و -۳۰ پوینت ترکیب می‌کند. در هر پاراگراف، خط اول به سمت چپ خطوط بسته‌شده شروع می‌شود؛ پاراگراف دوم تو رفتگی آویزان عمیق‌تری دارد:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![تو رفتگی آویزان پاراگراف‌ها](hanging_indent.png)

### **تنظیم ویژگی‌های پایان پاراگراف**

متد [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) قالب‌بندی علامت پایان پاراگراف را کنترل می‌کند. مثال زیر یک [PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/) با [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) برابر با ۴۸ پوینت و [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) تنظیم‌شده بر روی Times New Roman ایجاد می‌کند. این قالب به علامت پایان پاراگراف دوم اختصاص می‌یابد و بخش‌های متنی قابل مشاهده را دست‌نخورده می‌گذارد:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getPortions().add(new Portion("Sample text"));

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion("Sample text 2"));

    PortionFormat endParagraphFormat = new PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **شمارش خطوط رندر شده**

برای قوانین پاراگراف که بر بسته‌بندی خودکار و نقطه‌گذاری در انتهای خطوط تأثیر دارند، به [Control Line Breaking](/slides/fa/java/text-formatting/#control-line-breaking) و [Control Hanging Punctuation](/slides/fa/java/text-formatting/#control-hanging-punctuation) مراجعه کنید.

از [IParagraph.getLinesCount](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getLinesCount--) برای شمارش خطوطی که پاراگراف پس از چیدمان متن اشغال می‌کند استفاده کنید، از جمله بسته‌بندی خودکار. این مورد زمانی مفید است که طول متن و چیدمان در قالب‌های ارائه را بررسی می‌کنید.

یک پاراگراف یک مورد در [ITextFrame.getParagraphs](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParagraphs--) است و می‌تواند چندین خط رندر شده را اشغال کند. یک شکست خط صریح داخل پاراگراف خط جدیدی ایجاد می‌کند بدون اینکه پاراگراف دیگری ساخته شود. بسته‌بندی خودکار خطوط را بر اساس عرض موجود ایجاد می‌کند بدون وارد کردن شکست‌های صریح به متن. بنابراین شمارش پاراگراف‌ها یا کاراکترهای شکست خط، شمارش خطوط رندر شده را نمی‌دهد.

مثال زیر یک شکل متنی ایجاد می‌کند، خطوط آن را می‌شمارد، شکل را باریک می‌کند و سپس متن را با رشتهٔ کوتاه‌تری جایگزین می‌کند. مثال با استفاده از [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) بسته‌بندی را فعال می‌کند و با [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) خودکار‌ساز را غیرفعال می‌سازد تا عرض شکل کنترل بسته‌بندی را بدون کوچک‌سازی خودکار متن یا تغییر اندازه شکل داشته باشد. هر اندازه‌گیری از [IParagraph.getLinesCount](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getLinesCount--) استفاده می‌کند. ابعاد شکل بر حسب پوینت هستند. در نهایت، مثال پاراگراف دیگری اضافه می‌کند و مجموع شمارش خطوط را در سراسر فریم متن محاسبه می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    System.out.println("Original width: " + paragraph.getLinesCount());

    shape.setWidth(150);
    System.out.println("Narrower shape: " + paragraph.getLinesCount());

    paragraph.setText("Short text.");
    System.out.println("Shorter text: " + paragraph.getLinesCount());

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Another paragraph.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    textFrame.getParagraphs().add(secondParagraph);

    int totalLineCount = 0;
    for (IParagraph currentParagraph : textFrame.getParagraphs()) {
        totalLineCount += currentParagraph.getLinesCount();
    }
    System.out.println("Total lines in the text frame: " + totalLineCount);
} finally {
    presentation.dispose();
}
```

با این متن و این ابعاد، باریک کردن شکل تعداد خطوط را افزایش می‌دهد، در حالی که جایگزینی متن با رشتهٔ کوتاه‌تر آن را کاهش می‌دهد. شمارش دقیق می‌تواند بسته به در دسترس بودن و جایگزینی قلم، اندازهٔ قلم، حاشیه‌ها، تو رفتگی، بسته‌بندی و تنظیمات خودکار‌ساز متفاوت باشد. هنگام بررسی قالب، از قلم‌ها و تنظیمات چیدمان موردنظر برای محیط هدف استفاده کنید.

تعداد خطوط به تنهایی تعیین‌کنندهٔ سرریز متن از محفظه نیست. ارتفاع در دسترس، ارتفاع خطوط، فاصلهٔ بین پاراگراف و خط، و رفتار خودکار‌ساز نیز مهم‌اند؛ حتی یک خط می‌تواند عرض موجود را هنگام غیرفعال بودن بسته‌بندی تجاوز کند.

## **واردات و صادرات محتوای پاراگراف**

از HTML برای وارد کردن متن به یک ارائه یا صادرات پاراگراف‌های موجود برای استفاده خارج از آن استفاده کنید. این بخش همچنین نشان می‌دهد چگونه پاراگراف‌های منفرد را به‌صورت تصویر رندرسازی کنید، از جمله پاراگراف‌های موجود در سلول‌های جدول.

### **وارد کردن متن HTML به پاراگراف‌ها**

از [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) برای تبدیل نشانه‌گذاری HTML به پاراگراف‌ها و بخش‌ها در یک فریم متن استفاده کنید.

این مثال جاوا HTML را از یک فایل می‌خواند و نشانه‌گذاری را به [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) پاس می‌دهد. پاراگراف پیش‌فرض فریم متن را پاک می‌کند تا فریم فقط محتوای وارد شده را داشته باشد. شکل مستطیلی حاشیهٔ ۱۰ پوینت در هر سمت اسلاید باقی می‌گذارد:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    float shapeWidth = (float) presentation.getSlideSize().getSize().getWidth() - 20;
    float shapeHeight = (float) presentation.getSlideSize().getSize().getHeight() - 20;
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().getParagraphs().clear();

    try {
        byte[] htmlBytes = Files.readAllBytes(Paths.get("file.html"));
        String html = new String(htmlBytes, StandardCharsets.UTF_8);
        shape.getTextFrame().getParagraphs().addFromHtml(html);
        presentation.save("html_text.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("The HTML file could not be read: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **صادرات متن پاراگراف به HTML**

از [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) برای صادرات یک بازهٔ انتخابی از پاراگراف‌ها به HTML استفاده کنید. هنگام استفاده مجدد از متن ارائه در یک وب‌سایت، ممکن است بخواهید تأکید محلی را بدون انتقال فونت، اندازه یا سبک‌های جعبهٔ متن ارائه حفظ کنید. با تنظیم [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/java/com.aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit-int-) می‌توانید کنترل کنید که تبدیل‌کننده تا چه حد از وراثت قالب‌بندی دنبال می‌کند.

[نمونهٔ ارائه را دانلود کنید](text-inheritance.pptx) و در پوشهٔ کاری برنامه قرار دهید. اسلاید اول آن شامل یک شکل متنی است که متن «Inherited text; explicit red 18pt» را دارد. ورودی به‌صراحت از چندین سطح قالب‌بندی استفاده می‌کند:

- سبک متن پیش‌فرض ارائه Calibri با اندازهٔ ۲۸ پوینت فراهم می‌کند.
- سبک متن سطح اول فریم متن متن آبی و ایتالیک را فراهم می‌کند.
- پاراگراف به‌صراحت متن بولد تنظیم می‌کند.
- بخش دوم، «explicit red 18pt»، به‌صراحت متن قرمز و اندازهٔ ۱۸ پوینت تنظیم می‌کند.

مثال کامل زیر همان پاراگراف‌ها را سه بار صادر می‌کند. [TextToHtmlConversionOptions](https://reference.aspose.com/slides/java/com.aspose.slides/texttohtmlconversionoptions/) را به متد صادرات پاس می‌دهد و هر نتیجه را به‌صورت یک فایل HTML جداگانهٔ UTF‑8 می‌نویسد:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("text-inheritance.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            
            int[] modes = { TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly };
            String[] fileNames = { "All.html", "TextBox.html", "ParagraphOnly.html" };

            for (int i = 0; i < modes.length; i++) {
                TextToHtmlConversionOptions options = new TextToHtmlConversionOptions();
                options.setTextInheritanceLimit(modes[i]);

                String html = paragraphs.exportToHtml(0, paragraphs.getCount(), options);
                byte[] htmlBytes = html.getBytes(StandardCharsets.UTF_8);
                try {
                    Files.write(Paths.get(fileNames[i]), htmlBytes);
                } catch (IOException exception) {
                    System.out.println("The HTML file could not be written: " + exception.getMessage());
                }
            }
        } else {
            System.out.println("The first shape does not contain a text frame.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

HTML تولید شده CSS زیر را برای بخش اول «Inherited text; » شامل می‌شود. جدول، اعلان‌های مرتبط را فهرست می‌کند؛ سایر ویژگی‌های تولید شده برای وضوح حذف شده‌اند.

| خروجی | CSS مرتبط برای بخش اول | ظاهر |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | متن آبی، بولد، ایتالیک با ۲۸ پوینت در Calibri، در صورتی که این قلم موجود باشد. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | متن آبی، بولد، ایتالیک؛ صفحه یا مرورگر پیرامونی خانوادهٔ قلم و اندازه را فراهم می‌کند. |
| `ParagraphOnly.html` | `font-weight:bold` | متن بولد؛ صفحه یا مرورگر پیرامونی خانوادهٔ قلم، اندازه، رنگ و سبک ایتالیک را فراهم می‌کند. |

بخش دوم `color:#ff0000`, `font-size:18pt` و `font-weight:bold` را در هر سه خروجی حفظ می‌کند. همچنین ایتالیک را در `All` و `TextBox` حفظ می‌کند، اما در `ParagraphOnly` نه. محدود کردن وراثت بنابراین قالب‌بندی صریحاً به پاراگراف یا بخش اختصاص یافته را حذف نمی‌کند.

فایل‌ها را در همان مرورگر باز کنید تا مقایسه کنید. در دو حالت محدود، ویژگی‌های CSS حذف‌شده توسط سبک‌های صفحهٔ مقصد یا پیش‌فرض‌های مرورگر حل می‌شوند، بنابراین ظاهر نهایی به محلی که HTML استفاده می‌شود بستگی دارد.

### **رندر یک پاراگراف به عنوان تصویر**

[IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) یک پاراگراف منفرد را مستقیماً رندر می‌کند و یک [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/) بازمی‌گرداند. نتیجه را با [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) به فایل یا جریان ذخیره کنید. نیازی به رندر شکل حاوی یا برش دستی بیت‌مپ نیست.

[IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) ممکن است `null` برگرداند اگر پاراگراف در مجموعهٔ والد پیدا نشود، مرز رندر معتبری نداشته باشد یا نتواند رندر شود. قبل از ذخیره‌سازی نتیجه را بررسی کنید و پس از استفاده تصویر بازگشتی را آزاد کنید.

#### **رندر یک پاراگراف با مقیاس پیش‌فرض**

مثال از یک ارائه با یک اسلاید استفاده می‌کند که اولین شکل آن یک جعبهٔ متنی با سه پاراگراف است.

![جعبهٔ متن با سه پاراگراف](paragraph_to_image_input.png)

مثال زیر پاراگراف دوم را در اندیس ۱ انتخاب می‌کند و بدون پارامترهای مقیاس به [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) فراخوانی می‌کند. بررسی می‌کند که شکل شامل پاراگراف موردنظر است و رندر تصویر را قبل از فراخوانی [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) برای ذخیرهٔ آن در قالب PNG تأیید می‌کند. بلوک `finally` تصویر را پس از استفاده آزاد می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null && textFrame.getParagraphs().getCount() > 1) {
            IParagraph paragraph = textFrame.getParagraphs().get_Item(1);
            IImage paragraphImage = paragraph.getImage();

            if (paragraphImage != null) {
                try {
                    paragraphImage.save("paragraph.png", ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                System.out.println("The paragraph could not be rendered.");
            }
        } else {
            System.out.println("The expected paragraph was not found.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

نتیجه:

![تصویر پاراگراف](paragraph_to_image_output.png)

#### **رندر یک پاراگراف در سلول جدول با مقیاس**

از بارگذاری [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage-float-float-) که پارامترهای `float scaleX` و `float scaleY` را می‌پذیرد استفاده کنید تا عوامل مقیاس افقی و عمودی تنظیم شوند. مثال زیر یک جدول ایجاد می‌کند، پاراگراف را در اولین سلول آن با دو برابر عرض و ارتفاع پیش‌فرض رندر می‌کند و نتیجه را به‌صورت تصویر PNG ذخیره می‌کند.

```java
import com.aspose.slides.*;

float scaleX = 2f;
float scaleY = 2f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = slide.getShapes().addTable(50, 50, new double[] { 300 }, new double[] { 80 });
    IParagraph paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    IImage paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage != null) {
        try {
            paragraphImage.save("table_paragraph.png", ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        System.out.println("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

یک عامل مقیاس `1` آن محور را در اندازهٔ پیش‌فرض پیکسل نگه می‌دارد. برای مثال، `2` برای هر دو عامل تصویری با عرض و ارتفاع تقریباً دو برابر ابعاد پیش‌فرض ایجاد می‌کند که چهار برابر پیکسل دارد. عوامل بزرگتر معمولاً متن واضح‌تری برای بزرگ‌نمایی یا خروجی با وضوح بالا فراهم می‌کنند، اما حافظه و اندازهٔ فایل را نیز افزایش می‌دهند. عوامل زیر `1` تصاویر کوچکتر با جزئیات کمتر تولید می‌کنند. برای حفظ نسبت عرض‑به‑ارتفاع پاراگراف از عوامل برابر استفاده کنید؛ عوامل افقی و عمودی متفاوت خروجی را به‌صورت مستقل کشیده می‌کنند.

رندر یک شکل کامل با [IShape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getImage--) زمانی مفید است که خروجی باید پرکننده، مرز یا سایر زمینه‌های بصری شکل را شامل شود. برای تصویر فقط پاراگراف، از [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) استفاده کنید.

## **پرسش‌های متداول**

**آیا می‌توانم بسته‌بندی خطوط داخل فریم متن را به‌طور کامل غیرفعال کنم؟**

بله. با تنظیم [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) بسته‌بندی را غیرفعال کنید تا خطوط در لبه‌های فریم متن شکسته نشوند.

**چگونه می‌توانم مرزهای دقیق بر روی اسلاید برای یک پاراگراف خاص را دریافت کنم؟**

از [IParagraph.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getRect--) برای دریافت مستطیل محاطی پاراگراف استفاده کنید. [IPortion.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getRect--) مرزهای یک بخش منفرد را فراهم می‌کند.

**کنترل تراز پاراگراف (چپ، راست، مرکز یا توجیه) کجا قرار دارد؟**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) یک تنظیم سطح پاراگراف است و بر کل پاراگراف اعمال می‌شود، بدون درنظر گرفتن قالب‌بندی بخش‌های منفرد.

برای تراز عمودی بخش‌های مختلف با اندازهٔ قلم متفاوت در هر خط، به [Align Fonts Within a Line](/slides/fa/java/text-formatting/#align-fonts-within-a-line) مراجعه کنید.

**آیا می‌توانم زبان تصحیح‌کنندهٔ املایی را برای بخشی از یک پاراگراف تنظیم کنم؟**

بله. برای بخش‌های منفرد [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) تنظیم کنید تا یک پاراگراف بتواند متنی با چندین زبان داشته باشد.