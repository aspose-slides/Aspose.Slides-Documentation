---
title: مدیریت پاراگراف‌های متن پاورپوینت در جاوا
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
- تورفتگی پاراگراف
- تورفتگی معلق
- گلوله پاراگراف
- فهرست شماره‌دار
- فهرست گلوله‌دار
- ویژگی‌های پاراگراف
- وارد کردن HTML
- متن به HTML
- پاراگراف به HTML
- پاراگراف به تصویر
- متن به تصویر
- صادر کردن پاراگراف
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه پاراگراف‌ها، بخش‌ها، گلوله‌ها، فهرست‌های شماره‌دار، تورفتگی‌ها، محتوای HTML و تصاویر پاراگراف را با Aspose.Slides برای جاوا ایجاد و فرمت‌بندی کنید."
---
## **بررسی کلی**

Aspose.Slides for Java متن را به‌صورت یک سلسله‌مراتب از قاب‌های متن، پاراگراف‌ها و بخش‌ها (Portion) نمایش می‌دهد:

* [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) نمایانگر محفظه متن در یک شکل است و دسترسی به مجموعهٔ پاراگراف‌های آن را فراهم می‌کند.
* [IParagraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraph/) نمایانگر یک پاراگراف در یک قاب متن است و دسترسی به بخش‌ها و فرمت‌بندی‌های سطح پاراگراف را فراهم می‌کند.
* [IPortion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iportion/) نمایانگر یک توالی متنی درون یک پاراگراف است. هر بخش می‌تواند متن و فرمت‌بندی کاراکتری جداگانه‌ای داشته باشد.

بنابراین یک پاراگراف می‌تواند متنی با فونت‌ها، رنگ‌ها، اندازه‌ها و سایر فرمت‌بندی‌های متفاوت را با استفاده از چندین بخش (Portion) داشته باشد.

## **ایجاد و فرمت‌بندی پاراگراف‌ها**

### **ایجاد پاراگراف‌ها با چندین بخش**

مراحل زیر یک قاب متن با سه پاراگراف ایجاد می‌کند که هر کدام شامل سه بخش هستند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
2. اسلاید مربوطه را از طریق اندیس آن دسترسی پیدا کنید.
3. یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) شکل دسترسی پیدا کنید.
5. از پاراگراف پیش‌فرض استفاده کنید و دو شیء دیگر از نوع [IParagraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraph/) به قاب متن اضافه کنید.
6. برای هر پاراگراف به‌انداز کافی از شیءهای [IPortion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iportion/) اضافه کنید تا شامل سه بخش شوند. پاراگراف پیش‌فرض هم‌اکنون یک بخش خالی دارد.
7. متن هر بخش را تنظیم کنید.
8. فرمت‌بندی کاراکتری را از طریق [IPortion.getPortionFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iportion/#getPortionFormat--) اعمال کنید.
9. ارائه (presentation) اصلاح‌شده را ذخیره کنید.

این مثال جاوا این مراحل را پیاده‌سازی می‌کند:

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

## **ایجاد فهرست‌های گلوله‌ای و شماره‌دار**

### **ایجاد فهرست گلوله‌ای یا شماره‌دار**

گلوله‌ها و شماره‌گذاری، موارد مرتبط را برای اسکن سریع‌تر می‌کنند. در Aspose.Slides، تنظیمات فهرست از طریق [IBulletFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibulletformat/) تعریف می‌شوند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
2. اسلاید مربوطه را از طریق اندیس آن دسترسی پیدا کنید.
3. یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) به اسلاید انتخاب‌شده اضافه کنید.
4. به [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) شکل دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض را از قاب متن حذف کنید.
6. برای یک گلوله نمادین، یک [Paragraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/paragraph/) ایجاد کنید.
7. **IBulletFormat.setType** را به **BulletType.Symbol** تنظیم کنید و کاراکتر گلوله را مشخص کنید.
8. متن پاراگراف، تورفتگی، رنگ گلوله و ارتفاع گلوله را تنظیم کنید.
9. پاراگراف را به قاب متن اضافه کنید.
10. پاراگراف دوم را ایجاد کنید و **IBulletFormat.setType** را به **BulletType.Numbered** تنظیم کنید.
11. سبک گلوله شماره‌دار را پیکربندی کنید و پاراگراف را به قاب متن اضافه کنید.
12. ارائه را ذخیره کنید.

این مثال جاوا یک گلوله نمادین و یک گلوله شماره‌دار ایجاد می‌کند:

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

گلوله‌های تصویری به شما اجازه می‌دهند به‌جای نماد یا عدد، از یک تصویر سفارشی استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
2. اسلاید مربوطه را از طریق اندیس آن دسترسی پیدا کنید.
3. یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) اضافه کنید و به [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) آن دسترسی پیدا کنید.
4. پاراگراف پیش‌فرض را از قاب متن حذف کنید.
5. تصویر گلوله را بارگذاری کنید و به‌عنوان یک [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ippimage/) به مجموعهٔ تصاویر ارائه اضافه کنید.
6. یک [Paragraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/paragraph/) ایجاد کنید و متن آن را تنظیم کنید.
7. **IBulletFormat.setType** را به **BulletType.Picture** تنظیم کنید.
8. تصویر را از طریق **IBulletFormat.getPicture** اختصاص داده و ارتفاع گلوله را تنظیم کنید.
9. پاراگراف را به قاب متن اضافه کنید.
10. ارائه اصلاح‌شده را ذخیره کنید.

این مثال جاوا یک گلوله تصویری ایجاد می‌کند:

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

**IParagraphFormat.setDepth** را تنظیم کنید تا پاراگراف‌ها در سطوح مختلف فهرست قرار گیرند. سطح بالایی عمق `0` دارد.

1. یک [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید و اسلایدی را دسترسی پیدا کنید.
2. یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) اضافه کنید و پاراگراف پیش‌فرض را از قاب متن آن پاک کنید.
3. چهار پاراگراف ایجاد کنید و نمادهای گلوله‌شان را پیکربندی کنید.
4. مقدار **IParagraphFormat.setDepth** آن‌ها را به ترتیب `0`، `1`، `2` و `3` تنظیم کنید.
5. پاراگراف‌ها را به قاب متن اضافه کنید و ارائه را ذخیره کنید.

این مثال جاوا یک فهرست چهارسطحی گلوله‌دار ایجاد می‌کند:

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

### **شروع موارد فهرست شماره‌دار با مقادیر سفارشی**

از **IBulletFormat.setNumberedBulletStartWith** برای تنظیم عدد اولیه که برای پاراگراف شماره‌دار نمایش داده می‌شود، استفاده کنید.

1. یک [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید و یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
2. پاراگراف پیش‌فرض را از قاب متن شکل پاک کنید.
3. سه پاراگراف شماره‌دار ایجاد کنید.
4. برای هر پاراگراف **IBulletFormat.setNumberedBulletStartWith** را به ترتیب به `2`، `3` و `7` تنظیم کنید.
5. پاراگراف‌ها را به قاب متن اضافه کنید و ارائه را ذخیره کنید.

این مثال جاوا عدد شروع سفارشی را برای هر پاراگراف تعیین می‌کند:

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

## **کنترل چیدمان پاراگراف و ویژگی‌های انتهایی**

### **تنظیم تورفتگی خط اول**

از **IParagraphFormat.setIndent** برای کنترل تورفتگی خط اول یک پاراگراف استفاده کنید. این متد فقط خط اول را نسبت به حاشیهٔ چپ پاراگراف جابه‌جا می‌کند. مقدار مثبت خط اول را به‌راست می‌چسباند، در حالی که خطوط باقی‌مانده مطابق بدنهٔ پاراگراف می‌مانند.

زمانی که نیاز به جابه‌جایی تمام پاراگراف دارید، از **IParagraphFormat.setMarginLeft** استفاده کنید. برای جابه‌جایی تنها خط اول از **IParagraphFormat.setIndent** بهره ببرید.

مثال زیر چندین پاراگراف ایجاد می‌کند و مقادیر مختلف **IParagraphFormat.setIndent** را برای نشان دادن تأثیر تورفتگی خط اول بر چیدمان پاراگراف به‌کار می‌گیرد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
2. اسلاید هدف را دسترسی پیدا کنید.
3. یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض را حذف کنید.
5. چندین پاراگراف ایجاد کنید و مقادیر متفاوت **IParagraphFormat.setIndent** را برای آن‌ها تنظیم کنید.
6. پاراگراف‌ها را به قاب متن اضافه کنید.
7. ارائه اصلاح‌شده را ذخیره کنید.

این کد نحوه تنظیم تورفتگی پاراگراف را نشان می‌دهد:

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

![The first-line indent of the paragraphs](first_line_indent.png)

### **تنظیم تورفتگی معلق**

تورفتگی معلق یک چیدمان پاراگراف است که در آن خط اول نسبت به خطوط بعدی به سمت چپ می‌آید. در Aspose.Slides این اثر با **IParagraphFormat.setIndent** ایجاد می‌شود؛ کافی است مقدار منفی به آن بدهید تا خط اول نسبت به بدنهٔ پاراگراف به چپ جابه‌جا شود.

در عمل، **IParagraphFormat.setMarginLeft** موقعیت چپ بدنهٔ پاراگراف را تعریف می‌کند و **IParagraphFormat.setIndent** موقعیت خط اول نسبت به همان حاشیه را تنظیم می‌کند. برای ایجاد تورفتگی معلق، مقدار مثبت به **setMarginLeft** و مقدار منفی به **setIndent** بدهید.

این فرمت‌بندی برای کتابشناسی‌ها، مراجع، واژه‌نامه‌ها و سایر پاراگراف‌هایی که خطوط بسته‌شده باید زیر بدنهٔ پاراگراف نه زیر اولین کاراکتر خط اول هم‌راستا شوند، مفید است.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
2. اسلاید هدف را دسترسی پیدا کنید.
3. یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض را حذف کنید.
5. برای هر پاراگراف مقدار مثبت به **IParagraphFormat.setMarginLeft** بدهید.
6. مقدار منفی به **IParagraphFormat.setIndent** بدهید تا اثر تورفتگی معلق ایجاد شود.
7. پاراگراف‌ها را به قاب متن اضافه کنید.
8. ارائه اصلاح‌شده را ذخیره کنید.

این کد نحوه تنظیم تورفتگی معلق برای یک پاراگراف را نشان می‌دهد:

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

![The hanging indent of the paragraphs](hanging_indent.png)

### **تنظیم ویژگی‌های انتهای پاراگراف**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) فرمت علامت انتهای پاراگراف را کنترل می‌کند. مثال زیر اندازهٔ قلم و فونت لاتین را به علامت انتهای پاراگراف دوم اختصاص می‌دهد:

1. یک [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) بارگذاری کنید و اسلایدی را دسترسی پیدا کنید.
2. یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) اضافه کنید و پاراگراف پیش‌فرض آن را پاک کنید.
3. دو پاراگراف ایجاد کنید و به آن‌ها بخش‌های متنی اضافه کنید.
4. برای علامت انتهای پاراگراف دوم، یک [PortionFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/portionformat/) ایجاد کنید.
5. **IBasePortionFormat.setFontHeight** و **IBasePortionFormat.setLatinFont** را تنظیم کنید.
6. فرمت را با **IParagraph.setEndParagraphPortionFormat** اختصاص داده و ارائه را ذخیره کنید.

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

برای قوانین پاراگراف که بر بسته شدن خودکار و نقطه‌گذاری در انتهای خطوط تأثیر می‌گذارند، به ‎[Control Line Breaking](/slides/fa/java/text-formatting/#control-line-breaking)‎ و ‎[Control Hanging Punctuation](/slides/fa/java/text-formatting/#control-hanging-punctuation)‎ مراجعه کنید.

از **IParagraph.getLinesCount** برای شمارش خطوطی که پس از چینش متن یک پاراگراف اشغال می‌کند (از جمله بسته شدن خودکار) استفاده کنید. این متد هنگام بررسی طول متن و چینش در قالب‌های ارائه مفید است.

یک پاراگراف یک مورد در ‎[ITextFrame.getParagraphs]‎ است و می‌تواند چندین خط رندر شده را شامل شود. یک شکست‌خط صریح داخل پاراگراف یک خط جدید ایجاد می‌کند بدون اینکه پاراگراف جدیدی بسازد. بسته شدن خودکار خطوط را بر اساس عرض موجود ایجاد می‌کند بدون اینکه شکست‌خط صریحی به متن اضافه شود. بنابراین شمارش پاراگراف‌ها یا کاراکترهای شکست‌خط، شمارش خطوط رندر شده را نمی‌دهد.

مثال زیر یک شکل متنی ایجاد می‌کند، خطوط آن را می‌شمارد، شکل را باریک می‌کند و سپس متن را با رشتهٔ کوتاه‌تری جایگزین می‌کند. بسته شدن خط فعال است و AutoFit غیرفعال شده تا عرض شکل کنترل بسته شدن را بدون کوچک‌سازی خودکار متن یا تغییر اندازه شکل انجام دهد. ابعاد شکل به نقطه (point) است. در نهایت، مثال یک پاراگراف دیگر اضافه می‌کند و شمارش خطوط را در سراسر قاب متن جمع می‌کند.

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

با این متن و این ابعاد، باریک‌کردن شکل تعداد خطوط را افزایش می‌دهد، در حالی که جایگزینی متن با رشتهٔ کوتاه تعداد خطوط را کاهش می‌دهد. شمارش دقیق می‌تواند بسته به در دسترس بودن و جایگزینی قلم، اندازه قلم، حاشیه‌ها، تورفتگی، بسته شدن و تنظیمات AutoFit متفاوت باشد. برای بررسی یک قالب، از قلم‌ها و تنظیمات چیدمان موردنظر برای محیط هدف استفاده کنید.

تنها شمارش خطوط نمی‌تواند تعیین کند آیا متن از محفظهٔ خود عبور می‌کند یا نه. ارتفاع موجود، ارتفاع خطوط، فواصل پاراگراف و خط و رفتار AutoFit نیز مهم هستند؛ حتی یک خط واحد می‌تواند عرض موجود را هنگام غیرفعال بودن بسته شدن خط تجاوز کند.

## **واردات و صادرات محتوای پاراگراف**

### **وارد کردن متن HTML به پاراگراف‌ها**

از **ParagraphCollection.addFromHtml** برای تبدیل نشانه‌گذاری HTML به پاراگراف‌ها و بخش‌ها در یک قاب متن استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
2. اسلایدی را دسترسی پیدا کنید و یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) اضافه کنید.
3. به [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض آن را پاک کنید.
4. فایل HTML منبع را بخوانید.
5. رشتهٔ HTML را به **ParagraphCollection.addFromHtml** پاس بدهید.
6. ارائه اصلاح‌شده را ذخیره کنید.

این مثال جاوا HTML را به یک قاب متن وارد می‌کند:

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

از **ParagraphCollection.exportToHtml** برای صادرات محدودهٔ انتخاب‌شده‌ای از پاراگراف‌ها به صورت HTML استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید و ارائه موردنظر را بارگذاری کنید.
2. اسلاید را دسترسی پیدا کنید و [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) حاوی متن را پیدا کنید.
3. به [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) شکل دسترسی پیدا کنید.
4. **ParagraphCollection.exportToHtml** را با اندیس پاراگراف شروع و تعداد پاراگراف‌های موردنظر برای صادرات صدا بزنید.
5. رشتهٔ HTML برگردانده‌شده را در فایلی بنویسید.

این مثال جاوا تمام پاراگراف‌ها را از اولین شکل متنی صادر می‌کند:

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

[IParagraph.getImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraph/#getImage--) یک پاراگراف تک را مستقیماً رندر می‌کند و یک [IImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimage/) برمی‌گرداند. نتیجه را با **IImage.save** به‌صورت فایل یا جریان ذخیره کنید. نیازی به رندر کردن شکل حاوی آن یا برش دستی بیت‌مپ نیست.

[IParagraph.getImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraph/#getImage--) ممکن است `null` برگرداند اگر پاراگراف در مجموعهٔ والد پیدا نشود، مرزهای رندر معتبری نداشته باشد یا رندر نشود. قبل از ذخیره‌سازی نتیجه را بررسی کرده و پس از استفاده تصویر را آزاد کنید.

#### **رندر پاراگراف با مقیاس پیش‌فرض**

فرض کنید فایلی به نام sample.pptx با یک اسلاید داریم که اولین شکل آن یک جعبه متن شامل سه پاراگراف است.

![The text box with three paragraphs](paragraph_to_image_input.png)

مثال زیر پاراگراف دوم را در یک شکل متن معمولی با مقیاس پیش‌فرض رندر می‌کند و تصویر برگردانده‌شده را در قالب PNG ذخیره می‌نماید. بلوک ‎finally‎ تضمین می‌کند تصویر به‌درستی آزاد شود.

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

![The paragraph image](paragraph_to_image_output.png)

#### **رندر پاراگراف در سلول جدول با مقیاس‌بندی**

از overload ‎[IParagraph.getImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraph/#getImage-float-float-)‎ که پارامترهای ‎float scaleX‎ و ‎float scaleY‎ را می‌پذیرد، برای تنظیم عوامل مقیاس افقی و عمودی استفاده کنید. مثال زیر یک جدول ایجاد می‌کند، پاراگراف را در اولین سلول با دوبرابر عرض و ارتفاع پیش‌فرض رندر می‌کند و نتیجه را به‌صورت تصویر PNG ذخیره می‌نماید.

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

عامل مقیاس ‎1‎ اندازهٔ پیش‌فرض پیکسل را حفظ می‌کند. برای مثال، ‎2‎ برای هر دو عامل تصویری تولید می‌کند که عرض و ارتفاع آن تقریباً دو برابر ابعاد پیش‌فرض است و در نتیجه چهار برابر پیکسل دارد. عوامل بزرگ‌تر معمولاً متن شفاف‌تری برای زوم یا خروجی با وضوح بالا فراهم می‌کنند، اما حافظه و حجم فایل را نیز افزایش می‌دهند. عوامل زیر ‎1‎ تصاویری کوچک‌تر با جزئیات کمتر تولید می‌کنند. برای حفظ نسبت عرض به ارتفاع پاراگراف از عوامل مساوی استفاده کنید؛ عوامل افقی و عمودی متفاوت تصویر را به‌طور مستقل کش می‌دهند.

رندر کل شکل با ‎[IShape.getImage]‎ زمانی مفید است که خروجی نیاز به شامل پر شدن، حاشیه یا سایر زمینه‌های بصری شکل داشته باشد. برای تصویر فقط پاراگراف، از ‎[IParagraph.getImage]‎ استفاده کنید.

## **پرسش‌های متداول**

**آیا می‌توانم بسته شدن خودکار خطوط را داخل یک قاب متن به‌طور کامل غیرفعال کنم؟**

بله. **ITextFrameFormat.setWrapText** را به ‎0‎ تنظیم کنید تا بسته شدن غیرفعال شود و خطوط در لبه‌های قاب متن شکسته نشوند.

**چگونه می‌توانم مرزهای دقیق روی اسلاید یک پاراگراف خاص را دریافت کنم؟**

از **IParagraph.getRect** برای دریافت مستطیل محاطی پاراگراف استفاده کنید. **IPortion.getRect** مرزهای یک بخش جداگانه را فراهم می‌کند.

**کنترل تراز پاراگراف (چپ، راست، مرکز یا توجیه) از کجا انجام می‌شود؟**

**IParagraphFormat.setAlignment** یک تنظیم سطح پاراگراف است و بر تمام پاراگراف اعمال می‌شود، صرف‌نظر از فرمت‌بندی هر بخش.

**آیا می‌توانم زبان بررسی کنندهٔ املا را برای بخشی از یک پاراگراف تنظیم کنم؟**

بله. برای بخش‌های جداگانه **IBasePortionFormat.setLanguageId** را تنظیم کنید تا یک پاراگراف بتواند متنی در چندین زبان داشته باشد.