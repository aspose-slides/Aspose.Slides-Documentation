---
title: مدیریت پاراگراف‌های متن پاورپوینت در اندروید
linktitle: مدیریت پاراگراف
type: docs
weight: 40
url: /fa/androidjava/manage-paragraph/
aliases:
  - /androidjava/paragraph/
  - /androidjava/portion/
keywords:
  - افزودن متن
  - افزودن پاراگراف
  - مدیریت متن
  - مدیریت پاراگراف
  - مدیریت گلوله
  - تورفتگی پاراگراف
  - تورفتگی معلق
  - گلوله پاراگراف
  - فهرست عددی
  - فهرست نقطه‌دار
  - خصوصیات پاراگراف
  - واردات HTML
  - متن به HTML
  - پاراگراف به HTML
  - پاراگراف به تصویر
  - متن به تصویر
  - صادرات پاراگراف
  - پاورپوینت
  - ارائه
  - اندروید
  - جاوا
  - Aspose.Slides
description: "یاد بگیرید چگونه پاراگراف‌ها، بخش‌ها، گلوله‌ها، فهرست‌های عددی، تورفتگی‌ها، محتوای HTML و تصاویر پاراگراف را با Aspose.Slides برای اندروید از طریق جاوا ایجاد و قالب‌بندی کنید."
---
## **نمای کلی**

Aspose.Slides for Android via Java متن را به صورت یک سلسله مراتب از قاب‌های متن، پاراگراف‌ها و بخش‌ها (Portions) نمایش می‌دهد:

* [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) نمایانگر محفظه متن در یک شکل است و دسترسی به مجموعه پاراگراف‌های آن را فراهم می‌کند.
* [IParagraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraph/) نمایانگر یک پاراگراف در یک قاب متن است و دسترسی به بخش‌ها و قالب‌بندی سطح پاراگراف را فراهم می‌کند.
* [IPortion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iportion/) نمایانگر یک بخش متن (run) درون یک پاراگراف است. هر بخش می‌تواند متن و قالب‌بندی سطح کاراکتر خود را داشته باشد.

به این ترتیب یک پاراگراف می‌تواند متن با قلم‌ها، رنگ‌ها، اندازه‌ها و سایر قالب‌بندی‌های متفاوت را با استفاده از چندین بخش داشته باشد.

## **ایجاد و قالب‌بندی پاراگراف‌ها**

### **ایجاد پاراگراف‌ها با چندین بخش**

مراحل زیر یک قاب متن با سه پاراگراف ایجاد می‌کند که هر کدام شامل سه بخش هستند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
2. اسلاید مورد نظر را از طریق ایندکس آن دریافت کنید.
3. یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) شکل دسترسی پیدا کنید.
5. از پاراگراف پیش‌فرض استفاده کنید و دو شیء دیگر [IParagraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraph/) را به قاب متن اضافه کنید.
6. برای هر پاراگراف به اندازه کافی شیء [IPortion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iportion/) اضافه کنید تا سه بخش داشته باشد. پاراگراف پیش‌فرض قبلاً یک بخش خالی دارد.
7. متن هر بخش را تنظیم کنید.
8. قالب‌بندی سطح کاراکتر را از طریق [IPortion.getPortionFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iportion/#getPortionFormat--) اعمال کنید.
9. ارائه (presentation) تغییر یافته را ذخیره کنید.

این مثال Android via Java مراحل فوق را پیاده‌سازی می‌کند:

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


## **ایجاد فهرست‌های نقطه‌دار و عددی**

### **ایجاد فهرست نقطه‌دار یا عددی**

نقطه‌گذاری و شماره‌گذاری موارد مرتبط را برای اسکن راحت‌تر می‌کند. در Aspose.Slides تنظیمات فهرست از طریق [IBulletFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibulletformat/) تعریف می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
2. اسلاید مورد نظر را از طریق ایندکس آن دریافت کنید.
3. یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید انتخاب شده اضافه کنید.
4. به [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) شکل دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض را از قاب متن حذف کنید.
6. یک [Paragraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/paragraph/) برای یک نقطه نمادین ایجاد کنید.
7. [IBulletFormat.setType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibulletformat/#setType-int-) را به [BulletType.Symbol](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/bullettype/) تنظیم کنید و کاراکتر نقطه را مشخص کنید.
8. متن پاراگراف، تورفتگی، رنگ نقطه و ارتفاع نقطه را تنظیم کنید.
9. پاراگراف را به قاب متن اضافه کنید.
10. یک پاراگراف دوم ایجاد کنید و [IBulletFormat.setType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibulletformat/#setType-int-) را به [BulletType.Numbered](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/bullettype/) تنظیم کنید.
11. سبک نقطه عددی را پیکربندی کنید و پاراگراف را به قاب متن اضافه کنید.
12. ارائه را ذخیره کنید.

این مثال Android via Java یک نقطه نمادین و یک نقطه عددی ایجاد می‌کند:

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


### **استفاده از نقطه‌های تصویری**

نقطه‌های تصویری به شما اجازه می‌دهد به جای نماد یا عدد از یک تصویر سفارشی استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
2. اسلاید مورد نظر را از طریق ایندکس آن دریافت کنید.
3. یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) اضافه کنید و به [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) آن دسترسی پیدا کنید.
4. پاراگراف پیش‌فرض را از قاب متن حذف کنید.
5. تصویر نقطه را بارگذاری کنید و به مجموعه تصاویر ارائه به عنوان یک [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) اضافه کنید.
6. یک [Paragraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/paragraph/) ایجاد کرده و متن آن را تنظیم کنید.
7. [IBulletFormat.setType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibulletformat/#setType-int-) را به [BulletType.Picture](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/bullettype/) تنظیم کنید.
8. تصویر را از طریق [IBulletFormat.getPicture](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibulletformat/#getPicture--) اختصاص دهید و ارتفاع نقطه را تنظیم کنید.
9. پاراگراف را به قاب متن اضافه کنید.
10. ارائه تغییر یافته را ذخیره کنید.

این مثال Android via Java یک نقطه تصویری ایجاد می‌کند:

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

[اینتی‌ن یا] [IParagraphFormat.setDepth](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) را تنظیم کنید تا پاراگراف‌ها در سطوح مختلف فهرست قرار گیرند. سطح بالایی دارای عمق `0` است.

1. یک [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید و به یک اسلاید دسترسی پیدا کنید.
2. یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) اضافه کنید و پاراگراف پیش‌فرض را از قاب متن آن پاک کنید.
3. چهار پاراگراف ایجاد کنید و نمادهای نقطه آن‌ها را پیکربندی کنید.
4. مقدارهای [IParagraphFormat.setDepth](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) آن‌ها را به ترتیب `0`، `1`، `2` و `3` تنظیم کنید.
5. پاراگراف‌ها را به قاب متن اضافه کنید و ارائه را ذخیره کنید.

این مثال Android via Java یک فهرست نقطه‌دار چهارسطحی ایجاد می‌کند:

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


### **شروع شماره‌گذاری آیتم‌های فهرست با مقادیر دلخواه**

از [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) برای تنظیم عدد اولیه نمایش داده شده برای یک پاراگراف عددی استفاده کنید.

1. یک [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید و یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
2. پاراگراف پیش‌فرض را از قاب متن شکل حذف کنید.
3. سه پاراگراف عددی ایجاد کنید.
4. برای پاراگراف‌های مربوطه، [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) را به ترتیب به `2`، `3` و `7` تنظیم کنید.
5. پاراگراف‌ها را به قاب متن اضافه کنید و ارائه را ذخیره کنید.

این مثال Android via Java عدد شروع سفارشی را به هر پاراگراف اختصاص می‌دهد:

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

## **کنترل چینش پاراگراف و ویژگی‌های پایانی**

### **تنظیم تورفتگی خط اول**

از [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) برای کنترل تورفتگی خط اول یک پاراگراف استفاده کنید. این متد فقط خط اول را نسبت به حاشیه چپ پاراگراف جابه‌جا می‌کند. مقدار مثبت خط اول را به سمت راست منتقل می‌کند، در حالی که خطوط دیگر به بدنه پاراگراف متصل می‌مانند.

زمانی که نیاز به جابه‌جایی کل پاراگراف دارید از [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) استفاده کنید. برای جابه‌جایی فقط خط اول از [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) استفاده کنید.

مثال زیر چندین پاراگراف ایجاد کرده و مقادیر مختلف [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) را برای نشان دادن تأثیر تورفتگی خط اول بر چینش پاراگراف اعمال می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
2. اسلاید هدف را دریافت کنید.
3. یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض را حذف کنید.
5. چندین پاراگراف ایجاد کنید و برای هر یک مقادیر مختلف [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) تنظیم کنید.
6. پاراگراف‌ها را به قاب متن اضافه کنید.
7. ارائه تغییر یافته را ذخیره کنید.

این کد نشان می‌دهد چگونه تورفتگی پاراگراف تنظیم شود:

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

تورفتگی معلق یک چینش پاراگراف است که در آن خط اولین به سمت چپ خطوط باقی‌مانده شروع می‌شود. در Aspose.Slides این اثر را با [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) ایجاد می‌کنید. مقدار منفی برای جابه‌جایی خط اول به چپ نسبت به بدنه پاراگراف استفاده می‌شود.

در عمل، [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) موقعیت چپ بدنه پاراگراف را تعیین می‌کند و [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) موقعیت خط اول را نسبت به آن حاشیه مشخص می‌کند. برای ایجاد تورفتگی معلق، مقدار مثبت به `setMarginLeft` و مقدار منفی به `setIndent` بدهید.

این قالب‌بندی برای کتاب‌شناسی‌ها، مراجع، واژه‌نامه‌ها و دیگر پاراگراف‌هایی که خطوط بسته‌بندی شده باید زیر بدنه پاراگراف align شوند مفید است.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
2. اسلاید هدف را دریافت کنید.
3. یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض را حذف کنید.
5. برای هر پاراگراف مقدار مثبت به [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) بدهید.
6. مقدار منفی به [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) بدهید تا اثر تورفتگی معلق ایجاد شود.
7. پاراگراف‌ها را به قاب متن اضافه کنید.
8. ارائه تغییر یافته را ذخیره کنید.

این کد نشان می‌دهد چگونه تورفتگی معلق برای یک پاراگراف تنظیم شود:

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

### **تنظیم ویژگی‌های انتهای پاراگراف**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) قالب‌بندی علامت پایان پاراگراف را کنترل می‌کند. مثال زیر اندازه قلم و قلم لاتین را برای علامت پایان پاراگراف دوم تنظیم می‌کند:

1. یک [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) بارگذاری کنید و به یک اسلاید دسترسی پیدا کنید.
2. یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) اضافه کنید و پاراگراف پیش‌فرض آن را پاک کنید.
3. دو پاراگراف ایجاد کنید و به آن‌ها بخش‌های متنی اضافه کنید.
4. برای علامت پایان پاراگراف دوم یک [PortionFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/portionformat/) ایجاد کنید.
5. [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) و [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) را تنظیم کنید.
6. قالب را با [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) اختصاص داده و ارائه را ذخیره کنید.

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

برای قوانین پاراگرافی که بر بسته‌بندی خودکار و نقطه‌گذاری در انتهای خطوط تأثیر می‌گذارند، به بخش‌های [Control Line Breaking](/slides/fa/androidjava/text-formatting/#control-line-breaking) و [Control Hanging Punctuation](/slides/fa/androidjava/text-formatting/#control-hanging-punctuation) مراجعه کنید.

از [IParagraph.getLinesCount](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraph/#getLinesCount--) برای شمارش خطوطی که پس از چینش متن یک پاراگراف اشغال می‌کند (شامل بسته‌بندی خودکار) استفاده کنید. این روش برای بررسی طول متن و چینش در الگوهای ارائه مفید است.

یک پاراگراف یک مورد در [ITextFrame.getParagraphs](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#getParagraphs--) است و می‌تواند چندین خط رندر شده را اشغال کند. شکست خط صریح درون پاراگراف یک خط جدید ایجاد می‌کند بدون اینکه پاراگراف جدیدی ساخته شود. بسته‌بندی خودکار بر پایه عرض موجود خطوط را ایجاد می‌کند بدون این‌که نشانه‌های شکست خط صریح را در متن وارد کند. بنابراین شمارش پاراگراف‌ها یا کاراکترهای شکست خط، شمارش خطوط رندر شده را نمی‌دهد.

مثال زیر یک شکل متنی ایجاد می‌کند، خطوط آن را می‌شمارد، شکل را باریک می‌کند و سپس متن را با یک رشته کوتاه‌تر جایگزین می‌کند. بسته‌بندی فعال است و AutoFit غیرفعال است تا عرض شکل کنترل بسته‌بندی را بدون کوچک شدن خودکار متن یا تغییر اندازه شکل انجام دهد. ابعاد شکل بر حسب پونت هستند. در نهایت، مثال یک پاراگراف دیگر اضافه می‌کند و مجموع شمارش خطوط را در سراسر قاب متن محاسبه می‌کند.

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

با این متن و این ابعاد، باریک شدن شکل تعداد خطوط را افزایش می‌دهد، در حالی که جایگزینی متن با رشته کوتاه شمارش را کاهش می‌دهد. شمارش‌های دقیق می‌توانند بسته به در دسترس بودن قلم، جایگزینی، اندازه قلم، حاشیه‌ها، تورفتگی، بسته‌بندی و تنظیمات AutoFit متفاوت باشند. هنگام بررسی یک الگو، از قلم‌ها و تنظیمات چینش موردنظر برای محیط هدف استفاده کنید.

تنها شمارش خطوط تعیین‌کنندهٔ overflow متن در محفظه نیست. ارتفاع موجود، ارتفاع خطوط، فاصله‌های پاراگراف و خط، و رفتار AutoFit نیز مهم‌اند؛ حتی یک خط می‌تواند عرض موجود را وقتی بسته‌بندی غیرفعال باشد تجاوز کند.

## **واردات و صادرات محتوای پاراگراف**

### **وارد کردن متن HTML به پاراگراف‌ها**

از [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) برای تبدیل نشانه‌گذاری HTML به پاراگراف‌ها و بخش‌ها در یک قاب متن استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
2. به یک اسلاید دسترسی پیدا کنید و یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) اضافه کنید.
3. به [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض را پاک کنید.
4. فایل HTML منبع را بخوانید.
5. رشته HTML را به [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) پاس دهید.
6. ارائه تغییر یافته را ذخیره کنید.

این مثال Android via Java HTML را به یک قاب متن وارد می‌کند:

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


### **صادر کردن متن پاراگراف به HTML**

از [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) برای استخراج یک بازهٔ منتخب از پاراگراف‌ها به صورت HTML استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید و ارائه موردنظر را بارگذاری کنید.
2. به اسلاید دسترسی پیدا کنید و [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) حاوی متن را پیدا کنید.
3. به [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) شکل دسترسی پیدا کنید.
4. با مشخص کردن ایندکس پاراگراف شروع و تعداد پاراگراف‌های موردنظر، [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) را فراخوانی کنید.
5. رشته HTML برگردانده شده را در یک فایل بنویسید.

این مثال Android via Java تمام پاراگراف‌های اولین شکل متنی را صادر می‌کند:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("ExportingHTMLText.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            String html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            try {
                Files.write(Paths.get("paragraphs.html"), html.getBytes(StandardCharsets.UTF_8));
            } catch (IOException exception) {
                System.out.println("The HTML file could not be written: " + exception.getMessage());
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

### **رندر یک پاراگراف به عنوان تصویر**

[IParagraph.getImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraph/#getImage--) یک پاراگراف منفرد را مستقیماً رندر کرده و یک [IImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/) بر می‌گرداند. نتیجه را با [IImage.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) در فایل یا جریان ذخیره کنید. نیازی به رندر شکل حاوی آن یا برش دستی bitmap نیست.

[IParagraph.getImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraph/#getImage--) می‌تواند `null` برگرداند اگر پاراگراف در مجموعه والد یافت نشود، مرزهای رندر معتبر نداشته باشد یا قابل رندر نباشد. قبل از ذخیره‌سازی نتیجه را بررسی کنید و پس از استفاده تصویر بازگشتی را آزاد کنید.

#### **رندر یک پاراگراف با مقیاس پیش‌فرض**

فرض کنید فایلی به نام sample.pptx با یک اسلاید داریم که اولین شکل آن یک کادر متن شامل سه پاراگراف است.

![کادر متن با سه پاراگراف](paragraph_to_image_input.png)

مثال زیر پاراگراف دوم را در یک شکل متنی عادی با مقیاس پیش‌فرض رندر می‌کند و تصویر برگشتی را در قالب PNG ذخیره می‌نماید. بلوک `finally` اطمینان می‌دهد که تصویر به‌درستی آزاد می‌شود.

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

#### **رندر یک پاراگراف در یک سلول جدول با مقیاس دهی**

از overload [IParagraph.getImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-) که پارامترهای `float scaleX` و `float scaleY` را می‌پذیرد برای تنظیم مقادیر مقیاس افقی و عمودی استفاده کنید. مثال زیر یک جدول می‌سازد، پاراگراف را در اولین سلول آن با دو برابر عرض و ارتفاع پیش‌فرض رندر می‌کند و نتیجه را به صورت تصویر PNG ذخیره می‌نماید.

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

مقدار مقیاس `1` محور مربوطه را در اندازه پیش‌فرض پیکسل نگه می‌دارد. برای مثال، `2` برای هر دو عامل تصویری تولید می‌کند که عرض و ارتفاع تقریباً دو برابر ابعاد پیش‌فرض هستند، که چهار برابر پیکسل تولید می‌کند. عوامل بزرگ‌تر معمولاً متن واضح‌تری برای زوم یا خروجی با وضوح بالا می‌آورند، اما مصرف حافظه و اندازه فایل را نیز افزایش می‌دهند. عوامل زیر `1` تصاویر کوچکتری با جزئیات کمتر می‌سازند. برای حفظ نسبت عرض به ارتفاع پاراگراف از عوامل برابر استفاده کنید؛ عوامل متفاوت افقی و عمودی خروجی را به‌طور مستقل می‌کشند.

رندر کل یک شکل با [IShape.getImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getImage--) زمانی مفید است که خروجی نیاز به شامل پرکن، حاشیه یا سایر زمینه‌های بصری شکل داشته باشد. برای تصویر فقط پاراگراف، از [IParagraph.getImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraph/#getImage--) استفاده کنید.

## **سوالات متداول**

**آیا می‌توانم بسته‌بندی خطوط داخل یک قاب متن را به‌طور کامل غیرفعال کنم؟**

بله. برای غیرفعال‌سازی بسته‌بندی و جلوگیری از شکست خطوط در لبه‌های قاب متن، [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) را تنظیم کنید.

**چگونه می‌توانم محدوده دقیق روی اسلاید یک پاراگراف خاص را به‌دست آورم؟**

از [IParagraph.getRect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraph/#getRect--) برای دریافت مستطیل محدوده پاراگراف استفاده کنید. [IPortion.getRect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iportion/#getRect--) محدوده یک بخش منفرد را فراهم می‌کند.

**کنترل تراز پاراگراف (چپ، راست، مرکز یا توجیه) در کجا انجام می‌شود؟**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) یک تنظیم در سطح پاراگراف است و بر کل پاراگراف اعمال می‌شود، بدون توجه به قالب‌بندی بخش‌های منفرد.

**آیا می‌توانم زبان تصحیح برای بخشی از یک پاراگراف تنظیم کنم؟**

بله. برای بخش‌های منفرد [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) را تنظیم کنید، به‌طوری‌که یک پاراگراف بتواند متن‌های چند زبانه داشته باشد.