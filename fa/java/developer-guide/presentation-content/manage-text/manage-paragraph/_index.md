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
- افزودن متن
- افزودن پاراگراف
- مدیریت متن
- مدیریت پاراگراف
- مدیریت نقطه
- تورفتگی پاراگراف
- تورفتگی معلق
- نقطه‌گذاری پاراگراف
- فهرست عددی
- فهرست نقطه‌دار
- ویژگی‌های پاراگراف
- وارد کردن HTML
- متن به HTML
- پاراگراف به HTML
- پاراگراف به تصویر
- متن به تصویر
- استخراج پاراگراف
- پاورپوینت
- ارائه
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه پاراگراف‌ها، قسمت‌ها، نقطه‌ها، فهرست‌های عددی، تورفتگی‌ها، محتوای HTML و تصاویر پاراگراف را با Aspose.Slides برای جاوا ایجاد و قالب‌بندی کنید."
---
## **نمای کلی**

Aspose.Slides برای Java متن را به‌عنوان یک سلسله‌مراتب از قاب‌های متنی، پاراگراف‌ها و قسمت‌ها نشان می‌دهد:

* [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) قاب متنی را در یک شکل دربرمی‌گیرد و دسترسی به مجموعه پاراگراف‌های آن را فراهم می‌کند.
* [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) یک پاراگراف را در یک قاب متن نشان می‌دهد و دسترسی به قسمت‌ها و قالب‌بندی در سطح پاراگراف را فراهم می‌کند.
* [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) یک بخش متن را درون یک پاراگراف نشان می‌دهد. هر بخش می‌تواند متن و قالب‌بندی در سطح کاراکتر خود را داشته باشد.

بدین ترتیب یک پاراگراف می‌تواند با استفاده از چندین قسمت، متنی با فونت‌ها، رنگ‌ها، اندازه‌ها و سایر قالب‌بندی‌های مختلف داشته باشد.

## **ایجاد و قالب‌بندی پاراگراف‌ها**

### **ایجاد پاراگراف‌ها با قسمت‌های متعدد**

مراحل زیر یک قاب متن با سه پاراگراف ایجاد می‌کند که هرکدام شامل سه قسمت هستند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ایجاد کنید.
2. اسلاید مربوطه را از طریق ایندکس آن دسترسی پیدا کنید.
3. یک [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) شکل دسترسی پیدا کنید.
5. از پاراگراف پیش‌فرض استفاده کنید و دو شیء دیگر از نوع [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) را به قاب متن اضافه کنید.
6. به اندازه کافی شیء [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) برای هر پاراگراف اضافه کنید تا سه قسمت داشته باشند. پاراگراف پیش‌فرض از پیش یک قسمت خالی دارد.
7. متن هر قسمت را تنظیم کنید.
8. قالب‌بندی در سطح کاراکتر را از طریق [IPortion.getPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getPortionFormat--) اعمال کنید.
9. ارائه اصلاح‌شده را ذخیره کنید.

This Java example implements the steps:

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

## **ایجاد فهرست‌های نقطه‌دار و شماره‌دار**

### **ایجاد فهرست نقطه‌دار یا شماره‌دار**

نقطه‌ها و شماره‌گذاری، موارد مرتبط را برای اسکن آسان‌تر می‌سازند. در Aspose.Slides، تنظیمات فهرست از طریق [IBulletFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/) تعریف می‌شوند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ایجاد کنید.
2. اسلاید مربوطه را از طریق ایندکس آن دسترسی پیدا کنید.
3. یک [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) به اسلاید انتخابی اضافه کنید.
4. به [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) شکل دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض را از قاب متن حذف کنید.
6. یک [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) برای نقطه نماد ایجاد کنید.
7. متد [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-int-) را روی [BulletType.Symbol](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/) تنظیم کنید و کاراکتر نقطه را مشخص کنید.
8. متن پاراگراف، تورفتگی، رنگ نقطه و ارتفاع نقطه را تنظیم کنید.
9. پاراگراف را به قاب متن اضافه کنید.
10. یک پاراگراف دوم ایجاد کنید و متد [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-int-) را روی [BulletType.Numbered](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/) تنظیم کنید.
11. سبک نقطه شماره‌دار را پیکربندی کنید و پاراگراف را به قاب متن اضافه کنید.
12. ارائه را ذخیره کنید.

This Java example creates a symbol bullet and a numbered bullet:

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

### **استفاده از نقطه‌های تصویری**

نقطه‌های تصویری به شما اجازه می‌دهند به جای نماد یا عدد، از تصویر دلخواه استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ایجاد کنید.
2. اسلاید مربوطه را از طریق ایندکس آن دسترسی پیدا کنید.
3. یک [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) اضافه کنید و به [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) آن دسترسی پیدا کنید.
4. پاراگراف پیش‌فرض را از قاب متن حذف کنید.
5. تصویر نقطه را بارگذاری کنید و به عنوان یک [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) به مجموعه تصویرهای ارائه اضافه کنید.
6. یک [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) ایجاد کنید و متن آن را تنظیم کنید.
7. متد [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-int-) را روی [BulletType.Picture](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/) تنظیم کنید.
8. تصویر را از طریق [IBulletFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#getPicture--) اختصاص دهید و ارتفاع نقطه را تنظیم کنید.
9. پاراگراف را به قاب متن اضافه کنید.
10. ارائه اصلاح‌شده را ذخیره کنید.

This Java example creates a picture bullet:

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

متد [IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) را تنظیم کنید تا پاراگراف‌ها در سطوح مختلف فهرست قرار بگیرند. سطح بالایی عمق `0` دارد.

1. یک [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ایجاد کنید و به یک اسلاید دسترسی پیدا کنید.
2. یک [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) اضافه کنید و پاراگراف پیش‌فرض را از قاب متن آن پاک کنید.
3. چهار پاراگراف ایجاد کنید و نمادهای نقطه آنها را پیکربندی کنید.
4. مقدار [IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) آنها را به ترتیب `0`، `1`، `2` و `3` تنظیم کنید.
5. پاراگراف‌ها را به قاب متن اضافه کنید و ارائه را ذخیره کنید.

This Java example creates a four-level bulleted list:

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

### **شروع موارد فهرست شماره‌دار با مقادیر دلخواه**

از متد [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) برای تنظیم عدد اولیه نمایش‌داده‌شده برای یک پاراگراف شماره‌دار استفاده کنید.

1. یک [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ایجاد کنید و یک [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
2. پاراگراف پیش‌فرض را از قاب متن شکل پاک کنید.
3. سه پاراگراف شماره‌دار ایجاد کنید.
4. متد [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) را به ترتیب برای پاراگراف‌ها به `2`، `3` و `7` تنظیم کنید.
5. پاراگراف‌ها را به قاب متن اضافه کنید و ارائه را ذخیره کنید.

This Java example assigns a custom starting number to each paragraph:

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

### **تنظیم تورفتگی خط اول**

از متد [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) برای کنترل تورفتگی خط اول یک پاراگراف استفاده کنید. این متد تنها خط اول را نسبت به حاشیه چپ پاراگراف جابه‌جا می‌کند. مقدار مثبت خط اول را به سمت راست می‌برد، در حالی که خطوط باقی‌مانده هم‌راستا با بدنه پاراگراف می‌مانند.

هنگامی که نیاز به جابه‌جایی کل پاراگراف دارید، از [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) استفاده کنید. وقتی فقط خط اول را می‌خواهید جابه‌جا کنید، از [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) استفاده کنید.

مثال زیر چند پاراگراف ایجاد می‌کند و مقادیر متفاوتی از [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) را برای نشان دادن تأثیر تورفتگی خط اول بر چیدمان پاراگراف اعمال می‌نماید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ایجاد کنید.
2. به اسلاید هدف دسترسی پیدا کنید.
3. یک [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض را حذف کنید.
5. چند پاراگراف ایجاد کنید و مقادیر متفاوتی از [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) برای هر کدام تنظیم کنید.
6. پاراگراف‌ها را به قاب متن اضافه کنید.
7. ارائه اصلاح‌شده را ذخیره کنید.

This code shows you how to set a paragraph indent:

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
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().setFillType(FillType.Solid);
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

تورفتگی معلق یک چیدمان پاراگراف است که در آن خط اول نسبت به خطوط دیگر به سمت چپ می‌آید. در Aspose.Slides این اثر را با استفاده از [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) ایجاد می‌کنید. برای جابه‌جایی خط اول به سمت چپ مقدار منفی به این متد بدهید.

در عمل، [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) موقعیت چپ بدنه پاراگراف را مشخص می‌کند و [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) موقعیت خط اول نسبت به آن حاشیه را تعیین می‌کند. برای ایجاد تورفتگی معلق، مقدار مثبت به `setMarginLeft` و مقدار منفی به `setIndent` بدهید.

این قالب‌بندی برای کتاب‌شناسی‌ها، مراجع، واژه‌نامه‌ها و سایر پاراگراف‌هایی که خطوط بسته‌بندی شده باید زیر بدنه پاراگراف هم‌تراز شوند، مفید است.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ایجاد کنید.
2. به اسلاید هدف دسترسی پیدا کنید.
3. یک [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض را حذف کنید.
5. برای هر پاراگراف مقدار مثبت به [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) بدهید.
6. برای ایجاد اثر تورفتگی معلق مقدار منفی به [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) بدهید.
7. پاراگراف‌ها را به قاب متن اضافه کنید.
8. ارائه اصلاح‌شده را ذخیره کنید.

This code shows you how to set a hanging indent for a paragraph:

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

![تورفتگی معلق پاراگراف‌ها](hanging_indent.png)

### **تنظیم خصوصیات انتهای اجرا پاراگراف**

متد [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) قالب‌بندی علامت انتهای پاراگراف را کنترل می‌کند. مثال زیر اندازه قلم و قلم لاتین را برای علامت انتهای پاراگراف دوم تنظیم می‌کند:

1. یک [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) بارگذاری کنید و به یک اسلاید دسترسی پیدا کنید.
2. یک [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) اضافه کنید و پاراگراف پیش‌فرض آن را پاک کنید.
3. دو پاراگراف ایجاد کنید و به هر کدام قسمت‌های متنی اضافه کنید.
4. یک [PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/) برای علامت انتهای پاراگراف دوم ایجاد کنید.
5. [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) و [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) را تنظیم کنید.
6. قالب را با [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) اعمال کنید و ارائه را ذخیره کنید.

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

برای قوانین پاراگرافی که بر بسته‌بندی خودکار و نقطه‌گذاری در انتهای خطوط تأثیر می‌گذارند، به [Control Line Breaking](/slides/fa/java/text-formatting/#control-line-breaking) و [Control Hanging Punctuation](/slides/fa/java/text-formatting/#control-hanging-punctuation) مراجعه کنید.

از متد [IParagraph.getLinesCount](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getLinesCount--) برای شمارش خطوط اشغالی یک پاراگراف پس از چیدمان متن استفاده کنید؛ این شمارش شامل بسته‌بندی خودکار می‌شود. این مورد هنگام بررسی طول متن و چیدمان در قالب‌های ارائه مفید است.

یک پاراگراف یک مورد در [ITextFrame.getParagraphs](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParagraphs--) است و می‌تواند چندین خط رندر شده را اشغال کند. شکست خط صریح داخل پاراگراف یک خط جدید ایجاد می‌کند بدون اینکه پاراگراف جدیدی ساخته شود. بسته‌بندی خودکار خطوط را بر اساس عرض موجود ایجاد می‌کند بدون اینکه شکست‌های صریح به متن اضافه شود. بنابراین شمارش پاراگراف‌ها یا کاراکترهای شکست خط، تعداد خطوط رندر شده را نمی‌دهد.

مثال زیر یک شکل متنی ایجاد می‌کند، خطوط آن را می‌شمارد، شکل را باریک می‌کند و سپس متن را با رشته کوتاه‌تری جایگزین می‌کند. بسته‌بندی فعال است و AutoFit غیرفعال شده تا عرض شکل کنترل‌کنندهٔ بسته‌بندی باشد بدون اینکه متن خودبه‌خود کوچک یا شکل تغییر اندازه یابد. ابعاد شکل به واحد نقطه است. در پایان مثال یک پاراگراف دیگر اضافه می‌کند و تعداد خطوط را در سراسر قاب متن جمع می‌کند.

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

با این متن و این ابعاد، باریک‌کردن شکل تعداد خطوط را افزایش می‌دهد، در حالی که جایگزینی متن با رشته کوتاه تعداد خطوط را کاهش می‌دهد. شمارش دقیق می‌تواند بسته به در دسترس بودن قلم، جایگزینی، اندازه قلم، حاشیه‌ها، تورفتگی، بسته‌بندی و تنظیمات AutoFit متفاوت باشد. هنگام بررسی یک قالب، از قلم‌ها و تنظیمات چیدمانی که برای محیط هدف در نظر گرفته‌اید استفاده کنید.

تعداد خطوط به تنهایی تعیین نمی‌کند که آیا متن از مخزن خود تجاوز می‌کند یا نه. ارتفاع قابل دسترس، ارتفاع خطوط، فاصله‌های پاراگراف و خط، و رفتار AutoFit نیز مهم هستند؛ حتی یک خط واحد می‌تواند عرض قابل دسترس را در صورتی که بسته‌بندی غیرفعال باشد، تجاوز کند.

## **واردات و صادرات محتویات پاراگراف**

### **وارد کردن متن HTML به پاراگراف‌ها**

از متد [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) برای تبدیل نشانه‌گذاری HTML به پاراگراف‌ها و قسمت‌ها در یک قاب متنی استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ایجاد کنید.
2. به یک اسلاید دسترسی پیدا کنید و یک [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) اضافه کنید.
3. به [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض آن را پاک کنید.
4. فایل HTML منبع را بخوانید.
5. رشته HTML را به متد [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) پاس دهید.
6. ارائه اصلاح‌شده را ذخیره کنید.

This Java example imports HTML into a text frame:

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

از متد [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) برای صادرات یک بازهٔ انتخابی از پاراگراف‌ها به HTML استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ایجاد کنید و ارائه مورد نظر را بارگذاری کنید.
2. به اسلاید دسترسی پیدا کنید و [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) حاوی متن را پیدا کنید.
3. به [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) شکل دسترسی پیدا کنید.
4. متد [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) را با اندیس پاراگراف شروع و تعداد پاراگراف‌های مورد نظر برای صادرات فراخوانی کنید.
5. رشته HTML بازگشتی را در فایلی بنویسید.

This Java example exports all paragraphs from the first text shape:

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

### **رندر کردن پاراگراف به عنوان تصویر**

متد [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) یک پاراگراف فردی را مستقیماً رندر می‌کند و یک [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/) برمی‌گرداند. نتیجه را با متد [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) در فایل یا جریان ذخیره کنید. نیازی به رندر کردن شکل شامل‌کننده یا برش دستی بیت‌مپ نیست.

[IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) می‌تواند `null` برگرداند اگر پاراگراف در مجموعه والد یافت نشود، محدودهٔ رندر معتبری نداشته باشد یا قابل رندر نباشد. قبل از ذخیره‌سازی نتیجه را بررسی کنید و پس از استفاده تصویر بازگشتی را از بین ببرید.

#### **رندر کردن پاراگراف با مقیاس پیش‌فرض**

فرض کنید فایلی به نام sample.pptx داریم که شامل یک اسلاید است و اولین شکل آن یک جعبه متن با سه پاراگراف است.

![جعبه متن با سه پاراگراف](paragraph_to_image_input.png)

مثال زیر پاراگراف دوم را در یک شکل متن عادی با مقیاس پیش‌فرض رندر می‌کند و تصویر حاصل را در قالب PNG ذخیره می‌نماید. بلوک `finally` تضمین می‌کند که تصویر به‌درستی از بین برود.

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

#### **رندر کردن پاراگراف در یک سلول جدول با مقیاس‌بندی**

از overload متد [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage-float-float-) که پارامترهای `float scaleX` و `float scaleY` را می‌پذیرد، برای تنظیم مقیاس افقی و عمودی استفاده کنید. مثال زیر یک جدول ایجاد می‌کند، پاراگراف را در اولین سلول آن با دو برابر عرض و ارتفاع پیش‌فرض رندر می‌کند و نتیجه را به‌صورت تصویر PNG ذخیره می‌نماید.

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

یک ضریب مقیاس `1` محور مربوطه را با اندازهٔ پیکسل پیش‌فرض نگه می‌دارد. برای مثال، `2` برای هر دو ضریب، تصویری تولید می‌کند که عرض و ارتفاع آن تقریباً دو برابر ابعاد پیش‌فرض است و چهار برابر پیکسل دارد. ضرایب بزرگ‌تر معمولاً متن واضح‌تری برای زوم یا خروجی با وضوح بالا تولید می‌کنند، اما مصرف حافظه و حجم فایل را نیز افزایش می‌دهند. ضرایب زیر `1` تصاویری کوچکتر با جزئیات کمتر تولید می‌کنند. برای حفظ نسبت تصویر پاراگراف، از ضرایب برابر استفاده کنید؛ ضرایب متفاوت افقی و عمودی تصویر را به‌طور مستقل کش می‌دهند.

رندر یک شکل کامل با استفاده از [IShape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getImage--) زمانی مفید است که خروجی نیاز به شامل پر، حاشیه یا سایر زمینه‌های بصری شکل داشته باشد. برای تصویر فقط پاراگراف، از [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) استفاده کنید.

## **پرسش‌های متداول**

**آیا می‌توانم بسته‌بندی خطوط را به‌طور کامل داخل یک قاب متنی غیرفعال کنم؟**

بله. متد [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) را تنظیم کنید تا بسته‌بندی غیرفعال شود و خطوط در لبه‌های قاب متنی شکست نبخشند.

**چگونه می‌توانم مرزهای دقیق روی اسلاید یک پاراگراف خاص را بدست آورم؟**

از متد [IParagraph.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getRect--) برای بازیابی مستطیل مرز پاراگراف استفاده کنید. متد [IPortion.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getRect--) مرزهای یک بخش فردی را فراهم می‌کند.

**محل کنترل تراز پاراگراف (چپ، راست، مرکز یا توجیه) کجاست؟**

متد [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) یک تنظیم سطح پاراگرافی است و بر کل پاراگراف اعمال می‌شود، صرف‌نظر از قالب‌بندی هر بخش جداگانه.

برای تراز عمودی بخش‌های مختلف با اندازه‌های قلم متفاوت در هر خط، به [Align Fonts Within a Line](/slides/fa/java/text-formatting/#align-fonts-within-a-line) مراجعه کنید.

**آیا می‌توانم زبان اثبات برای بخشی از یک پاراگراف تنظیم کنم؟**

بله. برای بخش‌های فردی متد [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) را تنظیم کنید تا یک پاراگراف بتواند متنی با چند زبان مختلف داشته باشد.