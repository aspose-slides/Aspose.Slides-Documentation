---
title: قالب‌بندی متن ارائه در اندروید
linktitle: قالب‌بندی متن
type: docs
weight: 50
url: /fa/androidjava/text-formatting/
keywords:
- متن برجسته
- عبارت منظم
- تراز پاراگراف
- سبک متن
- پس‌زمینه متن
- شفافیت متن
- فاصله‌گذاری کاراکتر
- ویژگی‌های قلم
- خانواده قلم
- چرخش متن
- زاویهٔ چرخش
- قاب متن
- فاصله‌گذاری خطوط
- ویژگی Autofit
- لنگر قاب متن
- تب متن
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "قالب‌بندی و استایل‌دهی به متن در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Android از طریق Java. فونت‌ها، رنگ‌ها، تراز و موارد دیگر را سفارشی کنید."
---
## **بررسی کلی**

این مقاله نشان می‌دهد چگونه می‌توان متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Android از طریق Java قالب‌بندی کرد. این مقاله به برجسته‌سازی، رنگ‌های پس‌زمینه، شفافیت، فاصله‌گذاری کاراکترها، ویژگی‌های قلم، چرخش، فاصله‌گذاری پاراگراف، رفتار Autofit، لنگرگذاری متن، توقف‌های تب و تنظیمات زبان می‌پردازد.

در مثال‌های زیر، از فایلی به نام «sample.pptx» استفاده می‌کنیم که یک کادر متن در اسلاید اول دارد و متن زیر را شامل می‌شود:

![متن نمونه](sample_text.png)

## **برجسته‌سازی متن**

از متد [ITextFrame.highlightText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.lang.Integer-) زمانی استفاده کنید که نیاز به برجسته‌سازی متنی دارید که با یک الگوی خاص در یک فریم متنی مطابقت دارد. این متد رنگ برجسته را بر روی بخش‌های متن مطابق اعمال می‌کند و می‌تواند همراه با [ITextSearchOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITextSearchOptions) برای کنترل نحوه جستجو، برای مثال برای مطابقت فقط با کل کلمات، استفاده شود.

کد نمونه زیر همهٔ موارد حرف **«try»** را برجسته می‌کند و سپس فقط کلمهٔ کامل **«to»** را برجسته می‌سازد.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // دریافت اولین شکل از اولین اسلاید.
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // برجسته‌سازی کلمه "try" در شکل.
    shape.getTextFrame().highlightText("try", Color.rgb(173, 216, 230));

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // برجسته‌سازی کلمه "to" در شکل.
    int violetColor = Color.rgb(238, 130, 238);
    shape.getTextFrame().highlightText("to", violetColor, searchOptions, null);

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![متن برجسته شده](highlighted_text.png)

## **برجسته‌سازی متن با استفاده از عبارات منظم**

متد [ITextFrame.highlightRegex](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITextFrame#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) متن‌های پیدا شده توسط یک عبارت منظم را برجسته می‌کند.

کد نمونه زیر همهٔ کلماتی را که **هفت یا بیش از هفت کاراکتر** دارند، برجسته می‌سازد:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    java.util.regex.Pattern regex = java.util.regex.Pattern.compile("\\b[^\\s]{7,}\\b");

    // برجسته‌سازی تمام کلماتی که دارای هفت یا بیشتر کاراکتر هستند.
    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, null);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![متن برجسته شده با استفاده از عبارت منظم](highlighted_text_using_regex.png)

## **تنظیم رنگ پس‌زمینه متن**

از متد [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IParagraphFormat#getDefaultPortionFormat--) برای تعیین رنگ برجسته پیش‌فرض برای یک پاراگراف، یا از [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IBasePortionFormat#getHighlightColor--) برای بخش‌های متن جداگانه استفاده کنید.

کد نمونه زیر نحوهٔ تنظیم رنگ پس‌زمینه برای **تمام پاراگراف** را نشان می‌دهد:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // تنظیم رنگ برجسته برای تمام پاراگراف.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![پاراگراف خاکستری](gray_paragraph.png)

کد نمونه زیر نشان می‌دهد چگونه رنگ پس‌زمینه را برای **بخش‌های متنی با فونت بولد** تنظیم کنید:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // تنظیم رنگ برجسته برای بخش متن.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LTGRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![بخش‌های متن خاکستری](gray_text_portions.png)

## **تراز کردن پاراگراف‌های متنی**

از متد [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IParagraphFormat#setAlignment-byte-) برای تنظیم تراز پاراگراف درون یک فریم متنی استفاده کنید. مقدار می‌تواند مرکزی، چپ‌تراز، راست‌تراز، توجیه‌شده و غیره باشد.

کد نمونه زیر نحوهٔ تراز کردن پاراگراف به **مرکز** را نشان می‌دهد:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // تنظیم تراز پاراگراف به مرکز.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![پاراگراف تراز شده](aligned_paragraph.png)

## **تنظیم شفافیت برای متن**

شفافیت متن از طریق مؤلفهٔ آلفای رنگی که به [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--) اختصاص داده می‌شود، کنترل می‌شود. در مثال‌های زیر، `alpha = 50` مقدار کانال آلفای ARGB در مقیاس ۰-۲۵۵ است، نه درصد شفافیت.

کد نمونه زیر نشان می‌دهد چگونه شفافیت را برای **تمام پاراگراف** اعمال کنید:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // تنظیم رنگ پر متن به رنگ شفاف.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![پاراگراف شفاف](transparent_paragraph.png)

کد نمونه زیر نشان می‌دهد چگونه شفافیت را برای **بخش‌های متنی با فونت بولد** اعمال کنید:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // تنظیم شفافیت بخش متن.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![بخش‌های متن شفاف](transparent_text_portions.png)

## **تنظیم فاصله‌گذاری کاراکترها برای متن**

از متد [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IBasePortionFormat#setSpacing-float-) برای گسترش یا فشرده‌سازی فاصله بین کاراکترها در یک کادر متن استفاده کنید.

کد جاوا زیر نشان می‌دهد چگونه فاصله‌گذاری کاراکترها را در **تمام پاراگراف** گسترش دهید:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // توجه: برای فشرده‌سازی فاصله کاراکتر از مقادیر منفی استفاده کنید.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // گسترش فاصله کاراکتر.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![فاصله‌گذاری کاراکترها در پاراگراف](character_spacing_in_paragraph.png)

کد نمونه زیر نشان می‌دهد چگونه فاصله‌گذاری کاراکترها را در **بخش‌های متنی با فونت بولد** گسترش دهید:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // توجه: برای فشرده‌سازی فاصله کاراکتر از مقادیر منفی استفاده کنید.
            portion.getPortionFormat().setSpacing(3); // گسترش فاصله کاراکتر.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![فاصله‌گذاری کاراکترها در بخش‌های متن](character_spacing_in_text_portions.png)

### **غیرفعال‌سازی کرنینگ برای فونت‌های خاص**

در برخی موارد، متنی که توسط Aspose.Slides رندر می‌شود ممکن است کمی فشرده‌تر از همان متن در PowerPoint به نظر برسد. این می‌تواند به این دلیل باشد که PowerPoint داده‌های کرنینگ برای برخی فونت‌ها را نادیده می‌گیرد، حتی اگر فونت حاوی اطلاعات کرنینگ معتبر باشد و کرنینگ در تنظیمات PowerPoint فعال باشد.

برای نزدیک‌تر شدن خروجی رندر به PowerPoint در این شرایط، می‌توانید کرنینگ را برای بخش‌های متنی که از فونت موردنظر استفاده می‌کنند، غیرفعال کنید. مقدار [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IBasePortionFormat#setKerningMinimalSize-float-) را به مقداری به‌مرات بزرگ‌تر از اندازهٔ واقعی فونت تنظیم کنید:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (int paragraphIndex = 0; paragraphIndex < autoShape.getTextFrame().getParagraphs().getCount(); paragraphIndex++) {
        IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

        for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
            IPortion portion = paragraph.getPortions().get_Item(portionIndex);
            IFontData latinFont = portion.getPortionFormat().getLatinFont();
            IFontData eastAsianFont = portion.getPortionFormat().getEastAsianFont();
            IFontData complexScriptFont = portion.getPortionFormat().getComplexScriptFont();

            boolean usesTargetFont =
                    latinFont != null && targetFont.equals(latinFont.getFontName()) ||
                    eastAsianFont != null && targetFont.equals(eastAsianFont.getFontName()) ||
                    complexScriptFont != null && targetFont.equals(complexScriptFont.getFontName());

            if (usesTargetFont) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

این تنظیم از اعمال کرنینگ بر بخش‌های متنی مطابق جلوگیری می‌کند و می‌تواند به هم‌راستای شدن رندر Aspose.Slides با خروجی بصری PowerPoint برای فونت‌هایی که تحت این رفتار خاص PowerPoint هستند، کمک کند.

## **مدیریت ویژگی‌های قلم متن**

ویژگی‌های قلم می‌توانند در سطح پاراگراف از طریق [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IParagraphFormat#getDefaultPortionFormat--) یا در بخش‌های جداگانه از طریق [IPortionFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPortionFormat) تنظیم شوند.

کد زیر قلم و سبک متن را برای **تمام پاراگراف** تنظیم می‌کند: اندازه قلم، بولد، ایتالیک، خط تیره زیر خط و قلم Times New Roman را برای همهٔ بخش‌های پاراگراف اعمال می‌کند.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // تنظیم ویژگی‌های قلم برای پاراگراف.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![ویژگی‌های قلم برای پاراگراف](font_properties_for_paragraph.png)

کد نمونه زیر ویژگی‌های مشابه را برای **بخش‌های متنی با فونت بولد** اعمال می‌کند:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // تنظیم ویژگی‌های قلم برای بخش متن.
            portion.getPortionFormat().setFontHeight(13);
            portion.getPortionFormat().setFontItalic(NullableBool.True);
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
            portion.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![ویژگی‌های قلم برای بخش‌های متن](font_properties_for_text_portions.png)

## **تنظیم چرخش متن**

از متد [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-) برای تنظیم جهت پیش‌فرض متن درون یک شکل استفاده کنید.

کد نمونه زیر جهت متن درون شکل را به `Vertical270` تنظیم می‌کند که متن را **۹۰ درجه به خلاف جهت عقربه‌های ساعت** چرخش می‌دهد:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![چرخش متن](text_rotation.png)

## **تنظیم چرخش سفارشی برای فریم‌های متنی**

از متد [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) برای تنظیم زاویهٔ چرخش سفارشی برای یک [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITextFrame) استفاده کنید.

کد نمونه زیر فریم متنی را داخل شکل ۳ درجه به جهت ساعت محوری می‌چرخاند:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![چرخش سفارشی متن](custom_text_rotation.png)

## **تنظیم فاصله‌گذاری خطوط پاراگراف‌ها**

Aspose.Slides متدهای [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IParagraphFormat#setSpaceAfter-float-)، [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IParagraphFormat#setSpaceBefore-float-) و [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IParagraphFormat#setSpaceWithin-float-) را برای کنترل فاصله‌گذاری پاراگراف‌ها فراهم می‌کند. این ویژگی‌ها به شکل زیر استفاده می‌شوند:

* برای تعیین فاصله‌گذاری به‌عنوان درصدی از ارتفاع خط، مقدار مثبت استفاده کنید.
* برای تعیین فاصله‌گذاری به‌واحد پوینت، مقدار منفی استفاده کنید.

کد نمونه زیر نشان می‌دهد چگونه فاصله‌گذاری خط را درون پاراگراف تعیین کنید:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![فاصله‌گذاری خطوط درون پاراگراف](line_spacing.png)

## **تنظیم نوع Autofit برای فریم‌های متنی**

متد [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-) تعیین می‌کند متن هنگام تجاوز از مرزهای محفظهٔ خود چگونه رفتار کند. از آن برای کنترل اینکه متن کوچک شود، سرریز شود یا به‌صورت خودکار اندازهٔ شکل را تغییر دهد، استفاده کنید.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم نقطهٔ لنگر فریم‌های متنی**

متد [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-) نحوهٔ موقعیت‌دهی عمودی متن داخل یک شکل را تعریف می‌کند، برای مثال در بالا، وسط یا پایین.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم تب‌های متن**

از متدهای [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IParagraphFormat#setDefaultTabSize-float-) و [IParagraphFormat.getTabs](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IParagraphFormat#getTabs--) برای پیکربندی توقف‌های تب در یک پاراگراف استفاده کنید.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left);

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![تب‌های پاراگراف](paragraph_tabs.png)

## **تنظیم زبان تصحیح املائی**

Aspose.Slides متد [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) را فراهم می‌کند که به شما اجازه می‌دهد زبان تصحیح املائی برای یک بخش متن را تنظیم کنید. این زبان تعیین می‌کند که در PowerPoint از چه زبانی برای بررسی املا و دستور زبان استفاده شود.

کد نمونه زیر نشان می‌دهد چگونه زبان تصحیح املائی برای یک بخش متن تنظیم شود:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // تنظیم شناسهٔ زبان تصحیح املائی.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم زبان پیش‌فرض**

از متد [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/LoadOptions#setDefaultTextLanguage-java.lang.String-) برای تعریف زبان پیش‌فرض متنی که هنگام بارگذاری یا ایجاد یک ارائه ساخته می‌شود، استفاده کنید.

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // یک شکل مستطیل جدید با متن اضافه کنید.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // زبان اولین بخش متن را بررسی کنید.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **تنظیم سبک پیش‌فرض متن**

برای اعمال قالب‌بندی پیش‌فرض متن در سطح ارائه، از [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPresentation#getDefaultTextStyle--) استفاده کنید.

کد نمونه زیر نشان می‌دهد چگونه یک قلم بولد پیش‌فرض با اندازهٔ ۱۴ پوینت برای تمام متن‌ها در اسلایدهای یک ارائهٔ جدید تنظیم شود.

```java
Presentation presentation = new Presentation();
try {
    // دریافت قالب پاراگراف سطح بالا.
    IParagraphFormat paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat != null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(NullableBool.True);
    }

    presentation.save("default_text_style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **استخراج متن با اثر تمام حروف بزرگ**

در PowerPoint، اعمال اثر **All Caps** روی قلم باعث می‌شود متن روی اسلاید به صورت حروف بزرگ نمایش داده شود حتی اگر در ابتدا با حروف کوچک تایپ شده باشد. وقتی چنین بخشی از متن را با Aspose.Slides دریافت می‌کنید، کتابخانه متن را دقیقاً همان‌طور که وارد شده است برمی‌گرداند. برای تطبیق با متنی که نمایش داده می‌شود، [TextCapType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/TextCapType) را بررسی کنید و وقتی مقدار `All` باشد، رشتهٔ برگردانده شده را به حروف بزرگ تبدیل کنید.

بیایید فرض کنیم یک کادر متن زیر در اسلاید اول فایل sample2.pptx وجود دارد.

![اثر All Caps](all_caps_effect.png)

کد نمونه زیر نشان می‌دهد چگونه متن را با اثر **All Caps** استخراج کنیم:

```java
Presentation presentation = new Presentation("sample2.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortion textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    System.out.println("Original text: " + textPortion.getText());

    IPortionFormatEffectiveData textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() == TextCapType.All) {
        String text = textPortion.getText().toUpperCase();
        System.out.println("All-Caps effect: " + text);
    }
} finally {
    presentation.dispose();
}
```

خروجی:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **سوالات متداول**

**چگونه می‌توان متن در جدول یک اسلاید را ویرایش کرد؟**

برای ویرایش متن در جدول یک اسلاید، از [ITable](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITable) استفاده کنید. سلول‌ها را پیمایش کنید و هر سلول را از طریق [ICell.getTextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ICell#getTextFrame--) و قالب‌بندی پاراگراف‌ها را از طریق [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IParagraph#getParagraphFormat--) به‌روز کنید.

**چگونه می‌توان رنگ گرادیان را به متن در یک اسلاید PowerPoint اعمال کرد؟**

برای اعمال رنگ گرادیان به متن، از [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--) استفاده کنید. [IFillFormat.setFillType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IFillFormat#setFillType-int-) را به [FillType.Gradient](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FillType) تنظیم کنید و نقاط گرادیان، جهت و شفافیت را پیکربندی کنید.