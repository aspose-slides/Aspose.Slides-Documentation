---
title: مدیریت پاراگراف‌های متن PowerPoint در اندروید
linktitle: مدیریت پاراگراف
type: docs
weight: 40
url: /fa/androidjava/manage-paragraph/
aliases:
  - /androidjava/paragraph/
  - /androidjava/portion/
keywords:
- اضافه‌کردن متن
- اضافه‌کردن پاراگراف
- مدیریت متن
- مدیریت پاراگراف
- مدیریت گلوله
- تورفتگی پاراگراف
- تورفتگی معلق
- گلوله پاراگراف
- فهرست شماره‌دار
- فهرست بولت‌دار
- ویژگی‌های پاراگراف
- وارد کردن HTML
- متن به HTML
- پاراگراف به HTML
- پاراگراف به تصویر
- متن به تصویر
- صادرات پاراگراف
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "نحوهٔ ایجاد و قالب‌بندی پاراگراف‌ها، بخش‌ها، گلوله‌ها، فهرست‌های شماره‌دار، تورفتگی‌ها، محتوای HTML و تصاویر پاراگرافی را با Aspose.Slides برای Android از طریق Java بیاموزید."
---
## **بررسی کلی**

Aspose.Slides برای Android از طریق Java متن را به صورت سلسله‌مراتبی از فریم‌های متنی، پاراگراف‌ها و بخش‌ها نشان می‌دهد:

* [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) نمایانگر مخزن متن در یک شکل است و دسترسی به مجموعه پاراگراف‌های آن را فراهم می‌کند.
* [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) یک پاراگراف در فریم متنی را نشان می‌دهد و دسترسی به بخش‌ها و قالب‌بندی سطح پاراگراف را ارائه می‌دهد.
* [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) یک بخش متنی درون پاراگراف را نمایان می‌کند. هر بخش می‌تواند متن و قالب‌بندی سطح کاراکتر خود را داشته باشد.

در نتیجه یک پاراگراف می‌تواند متنی با فونت‌ها، رنگ‌ها، اندازه‌ها و قالب‌بندی‌های مختلف را با استفاده از چندین بخش در خود داشته باشد.

## **ایجاد و قالب‌بندی پاراگراف‌ها**

پاراگراف‌ها را در فریم متنی یک شکل ایجاد کنید و از بخش‌ها برای قالب‌بندی اجراهای متن منفرد استفاده کنید. این بخش نشان می‌دهد چگونه می‌توان چندین بخش را در هر پاراگراف ترکیب کرد و رنگ‌ها، اندازه‌های قلم و سبک‌های مختلف را اعمال کرد.

### **ایجاد پاراگراف‌ها با چند بخش**

مثال زیر در Android از طریق Java سه پاراگراف ایجاد می‌کند که هر کدام شامل سه اجرا متن در مجموعه‌ای هستند که توسط [IParagraph.getPortions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getPortions--) برگردانده می‌شود. این مثال پاراگراف پیش‌فرض و بخش خالی آن را بازاستفاده می‌کند، سپس پاراگراف‌ها و بخش‌های باقی‌مانده را اضافه می‌نماید. قالب‌بندی از طریق [IPortion.getPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/#getPortionFormat--) اعمال می‌شود: اولین بخش در هر پاراگراف قرمز، بولد و 15 پوینت است؛ دومین بخش آبی، ایتالیک و 18 پوینت؛ سومین بخش قالب‌بندی پیش‌فرض خود را حفظ می‌کند:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **ایجاد فهرست‌های بولتی و عددی**

متن پاراگراف را به فهرست‌هایی با نمادها، اعداد یا تصاویر سفارشی سازماندهی کنید. مثال‌های این بخش شامل قالب‌بندی بولت، فهرست‌های چندسطحی و مقدارهای شروع سفارشی هستند.

### **ایجاد فهرست بولتی یا عددی**

بولت‌ها و شماره‌گذاری موارد مرتبط را برای اسکن راحت‌تر می‌کنند. در Aspose.Slides تنظیمات فهرست از طریق [IBulletFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/) تعریف می‌شود.

این مثال در Android از طریق Java یک بولت نمادین و یک مورد عددی را به همان فریم متنی اضافه می‌کند. [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) نوع بولت را انتخاب می‌کند، در حالی که [IBulletFormat.setChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setChar-char-) نماد را فراهم می‌کند و [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) سبک شماره‌گذاری را انتخاب می‌کند. هر دو مورد از بولت‌های سیاه با ارتفاع 100 درصد و تو رفتگی پاراگراف 25 پوینت استفاده می‌کنند:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **استفاده از بولت‌های تصویری**

بولت‌های تصویری به شما امکان می‌دهند به جای نماد یا عدد از تصویر سفارشی استفاده کنید.

این مثال در Android از طریق Java یک تصویر را به مجموعه تصاویر ارائه اضافه می‌کند به عنوان یک [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) و از آن به عنوان بولت پاراگراف استفاده می‌کند. این مثال برای استفاده از بولت تصویری [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) را فراخوانی می‌کند و تصویر را از طریق [IBulletFormat.getPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#getPicture--) اختصاص می‌دهد. [IBulletFormat.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setHeight-float-) به 100 درصد تنظیم می‌شود تا اندازه بولت نسبت به متن پاراگراف تنظیم شود:

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

[ IParagraphFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) را تنظیم کنید تا پاراگراف‌ها در سطوح مختلف یک فهرست قرار گیرند. سطح بالایی دارای عمق `0` است.

این مثال در Android از طریق Java مقادیر [IParagraphFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) را از 0 تا 3 به چهار پاراگراف اختصاص می‌دهد و سلسله‌مراتبی در یک فریم متنی ایجاد می‌کند. هر پاراگراف از بولت نماد استفاده می‌کند، به طوری که [IBulletFormat.setChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setChar-char-) بین یک بولت گرد و یک خط تیره برای تمایز سطوح مجاور جابجا می‌شود:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **شروع موارد فهرست عددی با مقادیر دلخواه**

از [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) برای تنظیم عدد اولیه نمایش داده‌شده برای یک پاراگراف عددی استفاده کنید.

این مثال در Android از طریق Java [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) را برای استفاده از شماره‌گذاری برای سه پاراگراف تنظیم می‌کند و مقادیر [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) را به ترتیب 2، 3 و 7 اختصاص می‌دهد. مقدار شروع به طور جداگانه برای هر پاراگراف پیکربندی می‌شود تا امکان پرش مقادیر عددی فراهم شود:

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

## **کنترل چیدمان پاراگراف و خصوصیات انتهایی**

مارجین‌ها و تو رفتگی‌های پاراگراف را تنظیم کنید تا موقعیت خط اول و خطوط بسته‌شده را کنترل کنید. همچنین می‌توانید علامت پایان پاراگراف را جدا از بخش‌های متنی قابل مشاهده قالب‌بندی کنید.

### **تنظیم تورفتگی خط اول**

از متد [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) برای کنترل تورفتگی خط اول یک پاراگراف استفاده کنید. این تنظیم فقط خط اول را نسبت به حاشیه چپ پاراگراف جابه‌جا می‌کند. مقدار مثبت، خط اول را به سمت راست شفت می‌دهد، در حالی که خطوط باقی‌مانده به بدنه پاراگراف هم‌تراز می‌مانند.

از [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) زمانی که نیاز دارید کل پاراگراف را جابه‌جا کنید، استفاده کنید. از [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) زمانی که فقط خط اول را می‌خواهید جابه‌جا کنید، استفاده کنید.

مثال زیر سه پاراگراف را با [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) برابر 20 پوینت و مقادیر [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) برابر 0، 20 و 40 پوینت تنظیم می‌کند. خطوط اول به شکل تدریجی از افست بزرگتری شروع می‌شوند، در حالی که خطوط بسته‌شده همان حاشیه چپ را حفظ می‌کنند:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![تورفتگی خط اول پاراگراف‌ها](first_line_indent.png)

### **تنظیم تورفتگی معلق**

تورفتگی معلق یک چیدمان پاراگراف است که در آن خط اول به سمت چپ خطوط باقی‌مانده شروع می‌شود. در Aspose.Slides این اثر را با خصوصیت [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) ایجاد می‌کنید. مقدار `Indent` را منفی تنظیم کنید تا خط اول نسبت به بدنه پاراگراف به چپ شفت شود.

در عمل، [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) موقعیت چپ بدنه پاراگراف را تعریف می‌کند و [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) موقعیت خط اول را نسبت به آن حاشیه تعیین می‌کند. برای ایجاد تورفتگی معلق، مقدار مثبت `MarginLeft` و مقدار منفی `Indent` را تنظیم کنید.

این قالب‌بندی برای کتابشناسی‌ها، مراجع، واژه‌نامه‌ها و سایر پاراگراف‌هایی که خطوط بسته‌شده باید زیر بدنه پاراگراف هم‌تراز شوند، مفید است.

مثال Android از طریق Java زیر مقادیر [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) برابر 40 و 60 پوینت را با مقادیر [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) برابر -20 و -30 پوینت ترکیب می‌کند. در هر پاراگراف، خط اول به سمت چپ خطوط بسته‌شده شروع می‌شود؛ پاراگراف دوم تورفتگی معلق عمیق‌تری دارد:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![تورفتگی معلق پاراگراف‌ها](hanging_indent.png)

### **تنظیم خصوصیات انتهایی اجرای پاراگراف**

متد [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) قالب‌بندی علامت پایان پاراگراف را کنترل می‌کند. مثال زیر یک [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/) با [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) برابر 48 پوینت و [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) برابر Times New Roman ایجاد می‌کند. این قالب‌بندی به علامت پایان پاراگراف دوم اعمال می‌شود و بخش‌های متنی قابل مشاهده دست نخورده می‌مانند:

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

برای قوانین پاراگراف که بر بسته شدن خودکار و نقطه‌گذاری در انتهای خطوط تأثیر می‌گذارند، به [کنترل شکست خط](/slides/fa/androidjava/text-formatting/#control-line-breaking) و [کنترل علائم نقطه‌گذاری معلق](/slides/fa/androidjava/text-formatting/#control-hanging-punctuation) مراجعه کنید.

از [IParagraph.getLinesCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getLinesCount--) برای شمارش خطوط اشغال‌شده توسط یک پاراگراف پس از چیدمان متن استفاده کنید، از جمله بسته شدن خودکار. این کار هنگام بررسی طول متن و چیدمان در قالب‌های ارائه مفید است.

پاراگراف یک مورد در [ITextFrame.getParagraphs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParagraphs--) است و می‌تواند چندین خط رندر شده اشغال کند. یک شکست خط صریح درون پاراگراف یک خط جدید ایجاد می‌کند بدون اینکه پاراگراف دیگری ساخته شود. بسته شدن خودکار خطوط را بر اساس عرض موجود ایجاد می‌کند بدون اینکه کاراکترهای شکست صریح به متن افزوده شود. بنابراین شمارش پاراگراف‌ها یا کاراکترهای شکست خط، تعداد خطوط رندر شده را نمی‌دهد.

مثال زیر یک شکل متنی ایجاد می‌کند، خطوط آن را می‌شمارد، شکل را باریک می‌کند و سپس متن را با رشته کوتاه‌تری جایگزین می‌نماید. این مثال با [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) بسته شدن متن را فعال می‌کند و با [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) حالت خودکار متناسب کردن را غیرفعال می‌سازد تا عرض شکل کنترل بسته شدن را بدون کوچک‌کردن خودکار متن یا تغییر اندازه شکل انجام دهد. هر اندازه‌گیری از [IParagraph.getLinesCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getLinesCount--) استفاده می‌کند. ابعاد شکل به پوینت است. در نهایت مثال یک پاراگراف دیگر اضافه می‌کند و تعداد خطوط را در فریم متنی جمع می‌کند.

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

با این متن و این ابعاد، باریک کردن شکل تعداد خطوط را افزایش می‌دهد، در حالی که جایگزینی متن با رشته کوتاه تعداد آن را کاهش می‌دهد. شمارش دقیق می‌تواند بسته به در دسترس بودن قلم، جایگزینی، اندازه قلم، حاشیه‌ها، تو رفتگی، بسته شدن و تنظیمات خودکار متناسب متفاوت باشد. از قلم‌ها و تنظیمات چیدمانی که برای محیط هدف در نظر گرفته‌اید، هنگام بررسی یک قالب استفاده کنید.

تعداد خطوط به تنهایی تعیین‌کننده این نیست که آیا متن از محدوده خود فراتر می‌رود یا نه. ارتفاع موجود، ارتفاع خطوط، فاصله بین پاراگراف و خطوط، و رفتار خودکار متناسب نیز مهم هستند؛ حتی یک خط می‌تواند عرض موجود را وقتی بسته شدن غیرفعال باشد، تجاوز کند.

## **واردات و صادرات محتوای پاراگراف**

از HTML برای آوردن متن به یک ارائه یا صادرات پاراگراف‌های موجود برای استفاده خارج از آن استفاده کنید. این بخش همچنین نشان می‌دهد چگونه می‌توان پاراگراف‌های منفرد را به عنوان تصویر رندر کرد، شامل پاراگراف‌های موجود در سلول‌های جدول.

### **وارد کردن متن HTML به پاراگراف‌ها**

از [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) برای تبدیل نشانه‌گذاری HTML به پاراگراف‌ها و بخش‌ها در یک فریم متنی استفاده کنید.

این مثال Android از طریق Java HTML را از یک فایل می‌خواند و نشانه‌گذاری را به [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) پاس می‌دهد. پاراگراف پیش‌فرض فریم متنی را پاک می‌کند تا فریم تنها شامل محتوای وارد شده باشد. شکل مستطیلی حاشیه 10 پوینت در هر سمت اسلاید باقی می‌گذارد:

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

از [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) برای صادرات یک بازه انتخاب‌شده از پاراگراف‌ها به HTML استفاده کنید. وقتی متن ارائه را در یک وب‌سایت دوباره استفاده می‌کنید، ممکن است بخواهید تأکید محلی را بدون انتقال فونت، اندازه یا سبک‌های جعبه متن ارائه حفظ کنید. برای کنترل عمق ارث‌بری قالب‌بندی، [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit-int-) را تنظیم کنید.

[نمونه ارائه](text-inheritance.pptx) را دانلود کنید و در پوشه کاری برنامه قرار دهید. اسلاید اول آن شامل یک شکل متنی با متن «متن وارث؛ قرمز صریح 18pt» است. ورودی عمداً از چندین سطح قالب‌بندی استفاده می‌کند:

- سبک متن پیش‌فرض ارائه Calibri با اندازه 28 پوینت را فراهم می‌کند.
- سبک متن سطح اول فریم متنی متن آبی و ایتالیک را فراهم می‌کند.
- پاراگراف به صورت صریح متن بولد تنظیم می‌کند.
- بخش دوم، «قرمز صریح 18pt»، به صورت صریح متن قرمز و اندازه 18 پوینت تنظیم می‌شود.

مثال کامل زیر همان پاراگراف‌ها را سه بار صادر می‌کند. [TextToHtmlConversionOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/texttohtmlconversionoptions/) را به متد صادرات می‌دهد و هر نتیجه را به‌صورت یک فایل HTML UTF‑8 جداگانه می‌نویسد:

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

HTML تولید شده CSS زیر را برای اولین بخش، «متن وارث؛ » شامل می‌شود. جدول اعلان‌های مربوطه را لیست می‌کند؛ سایر خاصیت‌های تولید شده برای وضوح حذف شده‌اند.

| خروجی | CSS مرتبط برای اولین بخش | ظاهر |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | متن آبی، بولد، ایتالیک با اندازهٔ 28 پوینت در فونت Calibri، در صورتی که این قلم موجود باشد. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | متن آبی، بولد، ایتالیک؛ فونت و اندازهٔ صفحه یا مرورگر فراهم می‌شود. |
| `ParagraphOnly.html` | `font-weight:bold` | متن بولد؛ فونت، اندازه، رنگ و سبک ایتالیک توسط صفحه یا مرورگر تأمین می‌شود. |

بخش دوم قالب‌بندی `color:#ff0000`، `font-size:18pt` و `font-weight:bold` را در هر سه خروجی حفظ می‌کند. همچنین ایتالیک در `All` و `TextBox` حفظ می‌شود، اما در `ParagraphOnly` نیست. محدود کردن ارث‌بری بنابراین قالب‌بندی‌ای که به‌صورت صریح به پاراگراف یا بخش اختصاص داده شده را حذف نمی‌کند.

فایل‌ها را در یک مرورگر باز کنید تا آنها را مقایسه کنید. در دو حالت محدود شده، ویژگی‌های CSS حذف‌شده توسط سبک‌های صفحه مقصد یا پیش‌فرض‌های مرورگر تکمیل می‌شوند، بنابراین ظاهر نهایی به موقعیتی که HTML استفاده می‌شود وابسته است.

### **رندر یک پاراگراف به عنوان تصویر**

[IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) یک پاراگراف منفرد را مستقیماً رندر می‌کند و یک [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/) برمی‌گرداند. نتیجه را با [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) به فایل یا جریان ذخیره کنید. نیازی به رندر شکل شامل‌کننده یا برش دستی بیت‌مپ ندارید.

[IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) می‌تواند `null` برگرداند اگر پاراگراف در مجموعهٔ والد یافت نشود، مرزهای رندر معتبر نداشته باشد یا قابل رندر نباشد. قبل از ذخیره‌کردن نتیجه را بررسی کنید و پس از استفاده تصویر برگردانده‌شده را آزاد کنید.

#### **رندر یک پاراگراف با مقیاس پیش‌فرض**

این مثال یک ارائه با یک اسلاید دارد که شکل اول آن جعبه متنی حاوی سه پاراگراف است.

![جعبه متن با سه پاراگراف](paragraph_to_image_input.png)

مثال زیر پاراگراف دوم را در ایندکس 1 انتخاب می‌کند و بدون پارامترهای مقیاس به [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) فراخوانی می‌کند. بررسی می‌کند که شکل شامل پاراگراف مورد نیاز باشد و رندر تصویر بازگردانده شود قبل از اینکه [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) برای ذخیرهٔ آن در فرمت PNG فراخوانی شود. بلوک `finally` تصویر را پس از استفاده آزاد می‌کند.

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

#### **رندر یک پاراگراف در سلول جدول با مقیاس‌بندی**

از بارگذاری [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-) که پارامترهای `float scaleX` و `float scaleY` را می‌پذیرد برای تنظیم عوامل مقیاس افقی و عمودی استفاده کنید. مثال زیر یک جدول ایجاد می‌کند، پاراگراف را در اولین سلول آن با عرض و ارتفاع دو برابر پیش‌فرض رندر می‌کند و نتیجه را به صورت تصویر PNG ذخیره می‌کند.

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

عامل مقیاس `1` آن محور را در اندازهٔ پیش‌فرض پیکسل نگه می‌دارد. برای مثال `2` برای هر دو عامل تصویر با عرض و ارتفاع تقریباً دو برابر ابعاد پیش‌فرض تولید می‌کند که چهار برابر پیکسل دارد. عوامل بزرگتر معمولاً برای زوم یا خروجی با وضوح بالا متن واضح‌تری تولید می‌کنند، اما حافظه و حجم فایل را نیز افزایش می‌دهند. عوامل زیر `1` تصاویر کوچکتر با جزئیات کمتر تولید می‌کنند. برای حفظ نسبت طول‌عرض پاراگراف از عوامل برابر استفاده کنید؛ عوامل متفاوت افقی و عمودی تصویر را به‌طور مستقل کش می‌دهند.

رندر یک شکل کامل با [IShape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getImage--) زمانی مفید است که خروجی نیاز به شامل پرکردن، حاشیه یا دیگر زمینه‌های بصری شکل داشته باشد. برای تصویر فقط پاراگراف، از [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) استفاده کنید.

## **سوالات متداول**

**آیا می‌توانم بسته شدن خط را به‌صورت کامل درون یک فریم متنی غیرفعال کنم؟**

بله. با تنظیم [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) بسته شدن غیرفعال می‌شود تا خطوط در لبه‌های فریم متنی قطع نشوند.

**چگونه می‌توانم حدود دقیق روی اسلاید یک پاراگراف خاص را دریافت کنم؟**

از [IParagraph.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getRect--) برای دریافت مستطیل مرزی پاراگراف استفاده کنید. [IPortion.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/#getRect--) مرزهای یک بخش منفرد را فراهم می‌کند.

**کنترل ترازبندی پاراگراف (چپ، راست، مرکز یا تراز) در کجا قرار دارد؟**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) یک تنظیم سطح پاراگراف است و بر تمام پاراگراف اعمال می‌شود بدون در نظر گرفتن قالب‌بندی بخش‌های منفرد.

برای تراز کردن فونت‌های با اندازه‌های مختلف در هر خط، به [تراز کردن فونت‌ها در یک خط](/slides/fa/androidjava/text-formatting/#align-fonts-within-a-line) مراجعه کنید.

**آیا می‌توانم زبان تصحیح املایی را برای بخشی از یک پاراگراف تنظیم کنم؟**

بله. برای بخش‌های منفرد [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) را تنظیم کنید تا یک پاراگراف بتواند متنی در چند زبان داشته باشد.