---
title: قالب‌بندی متن ارائه در جاوا
linktitle: قالب‌بندی متن
type: docs
weight: 50
url: /fa/java/text-formatting/
keywords:
- تراز پاراگراف
- استایل متن
- پس‌زمینه متن
- شفافیت متن
- فاصله کاراکترها
- ویژگی‌های قلم
- خانواده قلم
- چرخش متن
- زاویه چرخش
- قاب متن
- فاصله خطوط
- ویژگی autofit
- لنگر قاب متن
- تب‌بندی متن
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Java قالب‌بندی و استایل دهید. قلم‌ها، رنگ‌ها، تراز و موارد دیگر را سفارشی کنید."
---
## **بررسی کلی**

این مقاله نشان می‌دهد چگونه متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides for Java قالب‌بندی کنید. این مقاله به رنگ‌های پس‌زمینه، شفافیت، فاصله بین کاراکترها، ویژگی‌های قلم، چرخش، فاصله‌های پاراگراف، رفتار autofit، لنگر متن، توقف‌های تب و تنظیمات زبان می‌پردازد.

مگر اینکه خلاف آن ذکر شود، مثال‌ها از [sample.pptx](sample.pptx) استفاده می‌کنند. اولین شکل در اولین اسلاید یک کادر متن است و اولین پاراگراف آن حاوی متنی است که در زیر نشان داده شده است. هر دو شاخص اسلاید و شکل به صورت صفر‑مبنا هستند. مثال‌هایی که بخش‌های بولد را انتخاب می‌کنند، از قالب‌بندی مؤثر شامل قالب‌بندی بولد وراثت‌گیرفته استفاده می‌کنند:

![متن نمونه](sample_text.png)

برای یافتن و برجسته‌سازی متن دقیق یا تطبیق‌های عبارت منظم، به [جستجو و جایگزینی متن](/slides/fa/java/search-and-replace-text/) مراجعه کنید.

## **تنظیم رنگ پس‌زمینه متن**

از [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) برای تنظیم رنگ پیش‌زمینه پیش‌فرض برای یک پاراگراف استفاده کنید، یا از [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) برای بخش‌های متن جداگانه استفاده کنید.

مثال زیر یک برجسته‌سازی خاکستری روشن را به‌عنوان پیش‌فرض برای اولین پاراگراف تنظیم می‌کند. رنگ‌های برجسته صریح در بخش‌های جداگانه بر این پیش‌فرض اولویت دارند:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // تنظیم رنگ برجسته برای کل پاراگراف.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![پاراگراف خاکستری](gray_paragraph.png)

کد زیر نحوه تنظیم رنگ پس‌زمینه برای **بخش‌های متن با قلم بولد** را نشان می‌دهد:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // تنظیم رنگ برجسته برای بخش متن.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![بخش‌های متن خاکستری](gray_text_portions.png)

## **تراز پاراگراف‌های متن**

از [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) برای تنظیم تراز پاراگراف در داخل یک قاب متن استفاده کنید. مقدار می‌تواند مرکزی، چپ‌تراز، راست‌تراز، هم‌تراز و … باشد.

کد زیر نشان می‌دهد چگونه پاراگراف را به **مرکز** تراز کنید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

## **تراز قلم‌ها در یک خط**

از [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) برای تراز عمودی بخش‌های متن با اندازه‌های قلم متفاوت در یک خط استفاده کنید. این تنظیم برای تمام پاراگراف اعمال می‌شود و تراز داخل هر خط را کنترل می‌کند.

مثال زیر یک اسلاید با چهار کادر متنی برچسب‌دار ایجاد می‌کند. هر پاراگراف متنی یکسان با اندازه‌های 18، 36 و 54 نقطه دارد که تراز قلم متفاوتی دارند. از Arial استفاده می‌کند، autofit و wrap را غیرفعال می‌کند و اندازه قاب‌ها را به‌گونه‌ای تنظیم می‌کند که یک خط کافی باشد.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] alignments = { FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom };
    String[] alignmentNames = { "Baseline", "Top", "Center", "Bottom" };
    float[] fontSizes = { 18f, 36f, 54f };

    for (int i = 0; i < alignments.length; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame textFrame = shape.getTextFrame();
        textFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
        textFrame.getTextFrameFormat().setWrapText(NullableBool.False);

        IParagraph label = textFrame.getParagraphs().get_Item(0);
        label.setText(alignmentNames[i]);
        label.getParagraphFormat().setAlignment(TextAlignment.Left);
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Arial"));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

        Paragraph paragraph = new Paragraph();
        paragraph.getParagraphFormat().setFontAlignment(alignments[i]);
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Arial"));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        for (float fontSize : fontSizes) {
            Portion portion = new Portion("Ag ");
            portion.getPortionFormat().setFontHeight(fontSize);
            paragraph.getPortions().add(portion);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    presentation.save("font_alignment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![مقایسه تراز Baseline، Top، Center و Bottom با اندازه‌های قلم مخلوط](font_alignment.png)

تراز قلم از متریک‌های قلم استفاده می‌کند، بنابراین لبه‌های قابل مشاهده حروف لزوماً دقیقاً هم‌سطح نیستند. این مثال شامل یک حرف بزرگ و یک حروف پایین‌رونده است تا تفاوت بین تراز baseline و bottom واضح‌تر شود. در دسترس بودن قلم و جایگزینی آن، کاراکترهای استفاده‌شده و تفاوت در اندازه‌های قلم بر نتیجه تأثیر می‌گذارد. ابعاد قاب، حاشیه‌ها، فاصله خطوط، wrap و autofit نیز بر چیدمان تأثیر دارند؛ برای مقایسه حالت‌ها از همان قلم‌ها و تنظیمات چیدمان استفاده کنید.

این تنظیم متفاوت از [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) است که تراز افقی پاراگراف را کنترل می‌کند و همچنین از [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) که موقعیت بلوک متن را به‌صورت عمودی درون شکل تعیین می‌کند، متفاوت است. فرمت‌گذاری superscript و subscript از طریق [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setEscapement-float-) جایگاه بخش‌ها را نسبت به baseline جابه‌جا می‌کند، نه اینکه تراز قلم خطوط پاراگراف را تغییر دهد.

## **تنظیم شفافیت برای متن**

شفافیت متن از طریق مؤلفه آلفای رنگ اختصاص یافته به [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) کنترل می‌شود. در مثال‌های زیر، `alpha = 50` یک مقدار کانال آلفای ARGB در مقیاس 0‑255 است، نه درصد شفافیت.

کد زیر نشان می‌دهد چگونه شفافیت را بر **تمام پاراگراف** اعمال کنید:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // تنظیم رنگ پر کردن متن به رنگ شفاف.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![پاراگراف شفاف](transparent_paragraph.png)

کد زیر نشان می‌دهد چگونه شفافیت را بر **بخش‌های متن با قلم بولد** اعمال کنید:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // تنظیم شفافیت بخش متن.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![بخش‌های متن شفاف](transparent_text_portions.png)

## **تنظیم فاصله کاراکترها برای متن**

از [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) برای گسترش یا فشرده‌سازی فاصله بین کاراکترهای یک کادر متن استفاده کنید. مثال‌ها 3 نقطه فاصله اضافه می‌کنند؛ مقادیر منفی متن را فشرده می‌کنند.

کد زیر نشان می‌دهد چگونه فاصله کاراکترها را در **تمام پاراگراف** گسترش دهید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // توجه: برای فشرده‌سازی فاصله کاراکتر از مقادیر منفی استفاده کنید.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // گسترش فاصله کاراکتر.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![فاصله کاراکترها در پاراگراف](character_spacing_in_paragraph.png)

کد زیر نشان می‌دهد چگونه فاصله کاراکترها را در **بخش‌های متن با قلم بولد** گسترش دهید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
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

![فاصله کاراکترها در بخش‌های متن](character_spacing_in_text_portions.png)

### **غیرفعال‌کردن کرنینگ برای قلم‌های خاص**

در برخی موارد، متن رندر شده توسط Aspose.Slides ممکن است کمی فشرده‌تر از متن مشابه در PowerPoint به‌نظر برسد. این ممکن است به این دلیل باشد که PowerPoint داده‌های کرنینگ برای برخی قلم‌ها را نادیده می‌گیرد، حتی اگر قلم دارای اطلاعات کرنینگ معتبر باشد و کرنینگ در تنظیمات PowerPoint فعال باشد.

برای نزدیک‌تر شدن خروجی رندر شده به PowerPoint، می‌توانید کرنینگ را برای بخش‌های متنی که از قلم موردنظر استفاده می‌کنند، غیرفعال کنید. مقدار [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) را بزرگ‌تر از اندازه واقعی قلم تنظیم کنید. این مثال نیاز به «presentation.pptx» دارد که اولین شکل آن روی اولین اسلاید یک کادر متن باشد. نام‌های قلم مؤثر، شامل قلم‌های وراثت‌گیرفته، بررسی می‌شود و برای بخش‌هایی که از Roboto استفاده می‌کنند، آستانه 100 نقطه تنظیم می‌شود: این مقدار کرنینگ را برای بخش‌های متن با اندازه قلم زیر 100 نقطه غیرفعال می‌کند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormatEffectiveData portionFormat = portion.getPortionFormat().getEffective();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای متن‌های زیر آستانه، این تنظیم کرنینگ را مانع می‌شود و می‌تواند به هم‌راستایی رندر Aspose.Slides با خروجی بصری PowerPoint برای قلم‌های تحت تأثیر این رفتار خاص PowerPoint کمک کند.

## **مدیریت ویژگی‌های قلم متن**

ویژگی‌های قلم می‌توانند در سطح پاراگراف از طریق [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) یا در بخش‌های جداگانه از طریق [IPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/) تنظیم شوند.

مثال زیر قلم پیش‌فرض پاراگراف اول را به 12‑پونت Times New Roman با قالب بولد، ایتالیک و خط زیر نقطه‌ای تنظیم می‌کند. قالب‌بندی صریح برای بخش‌های جداگانه بر این پیش‌فرض‌ها تقدم دارد:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

مثال زیر 13‑پونت Times New Roman، قالب ایتالیک و خط زیر نقطه‌ای را بر بخش‌هایی که قالب مؤثرشان بولد است، اعمال می‌کند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
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

## **کنترل نرمالیزه کردن ارتفاع متن**

از [IBasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setNormaliseHeight-byte-) هنگام بازآفرینی تایپوگرافی قالب یا بررسی تفاوت‌های ارتفاع کاراکتر استفاده کنید. در PowerPoint، فعال‌سازی نرمالیزه کردن باعث کشش یا فشرده‌سازی عمودی هر کاراکتر می‌شود تا ارتفاع قابل مشاهده آن‌ها در داخل بخش متن یکنواخت شود. این تضمین نمی‌کند که ارتفاع متن‌ها در قلم‌های مختلف برابر باشد.

مقدار ویژگی را به [NullableBool.True یا False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) تنظیم کنید تا نرمالیزه کردن را صریحاً فعال یا غیرفعال کنید. `NullableBool.NotDefined` تنظیم محلی را برنمی‌گذارد تا مقدار از پاراگراف (مثلاً از [getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--)) ارث‌بَر شود؛ این به معنای `False` نیست. برای به‌دست آوردن مقدار بولی حل‌شده از [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) و [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) استفاده کنید.

مثال زیر که نیاز به نصب **Arial** دارد، دو بلوک متن حاوی حروف بزرگ، حروف کوچک، حروف پایین‌رونده و حروف با لهجه در 54‑پونت ایجاد می‌کند. هر دو پاراگراف به‌صورت پیش‌فرض نرمالیزه کردن را فعال می‌کنند. بخش بالایی آن را صریحاً غیرفعال می‌کند؛ بخش پایینی آن را ارث می‌برد. ابعاد قاب، حاشیه‌ها و فاصله پاراگراف یکسان هستند و wrap و autofit غیرفعال‌اند تا مقایسه سازگار بماند. مثال `False: false` و `NotDefined: true` چاپ می‌کند و «text_height_normalization.pptx» را ذخیره می‌کند:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] settings = { NullableBool.False, NullableBool.NotDefined };
    String[] settingNames = { "False", "NotDefined" };

    for (int i = 0; i < settings.length; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame textFrame = shape.getTextFrame();
        textFrame.setText("Hxgjpq ÅÉ 0123");
        textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
        textFrame.getTextFrameFormat().setWrapText(NullableBool.False);
        textFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        textFrame.getTextFrameFormat().setMarginTop(0);
        textFrame.getTextFrameFormat().setMarginLeft(0);

        IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        paragraph.getParagraphFormat().setSpaceWithin(100);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(NullableBool.True);

        IPortion portion = paragraph.getPortions().get_Item(0);
        FontData font = new FontData("Arial");
        portion.getPortionFormat().setLatinFont(font);
        portion.getPortionFormat().setFontHeight(54);
        portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        portion.getPortionFormat().setNormaliseHeight(settings[i]);

        System.out.println(settingNames[i] + ": " + portion.getPortionFormat().getEffective().getNormaliseHeight());
    }

    presentation.save("text_height_normalization.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

مقایسه زیر از ارائه ذخیره‌شده استخراج شده است. ردیف بالایی نرمالیزه کردن غیرفعال (`False`) دارد؛ ردیف پایینی مقدار ارث‌بری (`NotDefined` → `True`) را نشان می‌دهد. برای بازآفرینی این ظاهر، Arial باید نصب شده باشد.

![متن 54‑پونتی Arial با نرمالیزه کردن غیرفعال در بالا و نرمالیزه کردن ارث‌بری در زیر](text_height_normalization.png)

نرمالیزه کردن ارتفاع کاراکترها را بدون تغییر مقدار [getFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFontHeight--) (که اندازه قلم را به‌پونت مشخص می‌کند) تغییر می‌دهد. [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) فاصله خطوط را کنترل می‌کند، در حالی که [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) نحوه تنظیم اندازه متن یا محفظه آن را کنترل می‌کند. این تنظیمات مقاصد متفاوتی دارند و می‌توانند به‌صورت مستقل بر چیدمان کلی تأثیر بگذارند. برای اطلاعات بیشتر درباره قالب‌بندی پاراگراف و ارث‌بری، به [Manage Paragraph](/slides/fa/java/manage-paragraph/) مراجعه کنید.

## **اعمال و حذف خط‌وسط**

از [IBasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setStrikethroughType-byte-) برای یک بخش متن استفاده کنید تا اصلاحات، عبارات لغو شده یا قیمت‌های قبلی را بدون حذف متن اصلی نشان دهید. مقدار را به [TextStrikethroughType.Single یا Double](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/) تنظیم کنید تا یک یا دو خط از طریق متن کشیده شود.

برای حذف خط‌وسط، از [TextStrikethroughType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/#None) استفاده کنید. این به‌صراحت اثر را غیرفعال می‌کند، حتی اگر قالب‌بندی اطراف خط‌وسط داشته باشد. برعکس، [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/#NotDefined) تنظیم محلی را تعریف نمی‌کند و به بخش اجازه می‌دهد تا قالب‌بندی را از مثالاً پاراگراف به ارث ببرد؛ این تضمین نمی‌کند که خط‌وسط حذف شود. برای خواندن قالب‌بندی نهایی، شامل مقادیر ارث‌بری، از [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) استفاده کنید.

مثال زیر سه مقایسه قیمت ایجاد می‌کند. هر پاراگراف بخش‌های جداگانه‌ای برای برچسب، قیمت قبلی و قیمت فعلی دارد، لذا تنها قیمت قبلی تحت تأثیر قرار می‌گیرد. ردیف اول خط‌وسط را اعمال و سپس حذف می‌کند؛ ردیف‌های دیگر به ترتیب خط‌وسط تک و دوخطی را حفظ می‌کنند. تغییر این تنظیم متن و قالب‌بندی‌های دیگر (مانند بولد) را حفظ می‌کند.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 620, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().getParagraphs().clear();

    String[] labels = { "None: ", "Single: ", "Double: " };

    for (String label : labels) {
        Paragraph paragraph = new Paragraph();
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceAfter(20);

        IPortionFormat format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setFontHeight(28);
        FontData font = new FontData("Arial");
        format.setLatinFont(font);
        format.getFillFormat().setFillType(FillType.Solid);
        format.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        Portion labelPortion = new Portion(label);
        paragraph.getPortions().add(labelPortion);

        Portion previousPrice = new Portion("$100");
        previousPrice.getPortionFormat().setFontBold(NullableBool.True);
        paragraph.getPortions().add(previousPrice);
        Portion currentPrice = new Portion(" → $80");
        paragraph.getPortions().add(currentPrice);

        shape.getTextFrame().getParagraphs().add(paragraph);
    }

    IParagraphCollection paragraphs = shape.getTextFrame().getParagraphs();

    // اعمال خط‌وسط، سپس به‌صورت صریح حذف آن از اولین قیمت قبلی.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None);

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double);

    presentation.save("strikethrough.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه، از بالا به پایین: بدون خط‌وسط، خط‌وسط تک، و خط‌وسط دوخطی.

![قیمت‌های قبلی بدون خط‌وسط، با خط‌وسط تک و با خط‌وسط دوخطی](strikethrough.png)

## **تنظیم چرخش متن**

از [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) برای تنظیم جهت پیش‌تعریف‌شده متن در داخل یک شکل استفاده کنید.

کد زیر جهت متن در شکل را به [TextVerticalType.Vertical270](https://reference.aspose.com/slides/java/com.aspose.slides/textverticaltype/) تنظیم می‌کند که متن را **90 درجه در جهت ساعت‌عکس** می‌چرخاند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![چرخش متن](text_rotation.png)

## **نمایش ارقام به‌صورت کنار هم در متن عمودی**

برای نگه‌داشتن یک عدد دورقمی در یک برچسب عمودی ژاپنی، هر دو رقم را در یک بخش متن قرار دهید و روی آن بخش [IBasePortionFormat.setKumimoji](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setKumimoji-byte-) را فراخوانی کنید. مثال از [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/java/com.aspose.slides/textverticaltype/#EastAsianVertical) و 40‑پونت MS Gothic برای هر دو برچسب استفاده می‌کند. تنها مقدار [NullableBool](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) که به بخش عددی داده می‌شود متفاوت است.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] settings = { NullableBool.True, NullableBool.False };
    float x = 120;

    for (byte kumimoji : settings) {
        IAutoShape label = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, 48, 120, 420);
        label.getFillFormat().setFillType(FillType.NoFill);
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame frame = label.addTextFrame("");
        frame.getTextFrameFormat().setTextVerticalType(TextVerticalType.EastAsianVertical);

        IParagraph paragraph = frame.getParagraphs().get_Item(0);
        IPortionFormat format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        FontData font = new FontData("MS Gothic");
        format.setLatinFont(font);
        format.setEastAsianFont(font);
        format.setFontHeight(40);
        format.getFillFormat().setFillType(FillType.Solid);
        format.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        Portion digits = new Portion("12");
        digits.getPortionFormat().setKumimoji(kumimoji);
        
        paragraph.getPortions().clear();
        paragraph.getPortions().add(new Portion("令和"));
        paragraph.getPortions().add(digits);
        paragraph.getPortions().add(new Portion("年"));

        x += 240;
    }
    presentation.save("vertical_date.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

در PowerPoint، برچسب چپ (`True`) ارقام را عمود و کنار هم بین 和 و 年 نشان می‌دهد. در برچسب راست (`False`) جفت ارقام 90 درجه در جهت ساعت‌گرد چرخیده‌اند. حروف ژاپنی اطراف در هر دو برچسب عمود می‌مانند.

![مقایسه برچسب‌های تاریخ عمودی در PowerPoint با ارقام عمود در سمت چپ و ارقام چرخیده در سمت راست](vertical_date.png)

## **تنظیم چرخش سفارشی برای قاب‌های متن**

از [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) برای تنظیم زاویه چرخش سفارشی یک [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) استفاده کنید.

کد زیر قاب متن را درون شکل 3 درجه در جهت ساعت‌گرد می‌چرخاند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![چرخش سفارشی متن](custom_text_rotation.png)

## **تنظیم فاصله خطوط پاراگراف‌ها**

Aspose.Slides متدهای [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-)، [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) و [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) را برای کنترل فاصله پاراگراف فراهم می‌کند. این ویژگی‌ها به‌صورت زیر استفاده می‌شوند:

* از مقدار مثبت برای نگه‌داری فاصله خط به‌عنوان درصدی از ارتفاع خط استفاده کنید.
* از مقدار منفی برای تعیین فاصله خط به‌پونت استفاده کنید.

مثال زیر فاصله داخل اولین پاراگراف را به 200٪ از ارتفاع خط (دوبل اسپیس) تنظیم می‌کند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![فاصله خطوط داخل پاراگراف](line_spacing.png)

## **کنترل شکست خط**

قوانین شکست خط پاراگراف در بلوک‌های متنی باریک و ارائه‌هایی که متن لاتین و شرق آسیا را مخلوط می‌کنند مفید هستند. متدهای زیر متعلق به [IParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/) هستند، بنابراین بر کل پاراگراف اعمال می‌شوند:

- [setLatinLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) قوانین شکست خط لاتین را کنترل می‌کند. در متن مخلوط، تغییر آن می‌تواند محل بسته شدن متن شرق آسیا و علائم نگارشی را نیز تغییر دهد.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) قوانین شکست خط شرق آسیا را کنترل می‌کند، از جمله محدودیت‌های کاراکتر در ابتدای یا انتهای خط.

این قوانین جایگزین [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) که بسته‌بندی خودکار را درون یک قاب متن فعال می‌کند، نمی‌شوند. آن‌ها بر چیدمان هنگام بسته شدن تأثیر می‌گذارند؛ کاراکترهای شکست خط را وارد نمی‌کنند. یک شکست خط صریح یک خط جدید را درون پاراگراف независимо از عرض موجود ایجاد می‌کند.

مثال زیر یک بلوک متن باریک شامل متن چینی و لاتین ایجاد می‌کند. هر دو گزینه شکست خط به‌صورت صریح تنظیم می‌شوند و «line_breaking.pptx» ذخیره می‌شود. برای آزمایش هر یک از قوانین، مقدار مربوطه را تغییر دهید و تنظیمات دیگر را ثابت نگه دارید. این مثال 24‑پونت Arial و SimSun، عرض قاب 160‑پونت و حاشیه افقی صفر دارد. [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) با [TextAutofitType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textautofittype/) فراخوانی می‌شود تا اندازه متن و ابعاد قاب ثابت بمانند.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("中文排版测试，PowerPoint 中文演示。");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    FontData eastAsianFont = new FontData("SimSun");
    format.getDefaultPortionFormat().setEastAsianFont(eastAsianFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setLatinLineBreak(NullableBool.False);
    format.setEastAsianLineBreak(NullableBool.True);

    presentation.save("line_breaking.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **کنترل علائم نگارشی آویزان**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) به علامت‌های نگارشی واجد شرایط اجازه می‌دهد تا از لبه راست خط متن فراتر بروند به جای اینکه در خط بعدی جای بگیرند. این تنظیم برای تمام پاراگراف اعمال می‌شود و متفاوت از تورفتگی آویزان است.

مثال زیر علامت نگارشی آویزان را در یک قاب متن 100‑پونتی فعال می‌کند و «hanging_punctuation.pptx» را ذخیره می‌کند. با 24‑پونت Arial و حاشیه افقی صفر، نقطه نهایی پس از «sentence» می‌ماند و از لبه راست متن فراتر می‌رود. مقدار ویژگی را به [NullableBool.False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) تنظیم کنید تا مقایسه کنید: با این تنظیمات، نقطه در خط جداگانه‌ای قرار می‌گیرد. wrap فعال و autofit غیرفعال شده‌اند تا عرض در دسترس ثابت بماند.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("Simple text, next sentence.");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setHangingPunctuation(NullableBool.True);

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

همهٔ علائم نگارشی نمی‌توانند آویزان شوند. شرایط قلم و چیدمان شرح داده شده در بخش [کنترل شکست خط](#control-line-breaking) نیز به این مقایسه اعمال می‌شود: تغییر قلم، عرض در دسترس، حاشیه‌ها یا تنظیمات autofit می‌تواند تفاوت قابل مشاهده را حذف کند.

## **تنظیم نوع Autofit برای قاب‌های متن**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) تعیین می‌کند که متن وقتی از مرزهای محفظه‌اش فراتر می‌رود، چگونه رفتار کند. از آن برای کنترل اینکه متن کوچک شود، overflow کند یا شکل به‌صورت خودکار اندازه خود را تغییر دهد استفاده کنید. مثال زیر شکل را برای تناسب خود با متن تنظیم می‌کند و نتیجه را در «autofit_type.pptx» ذخیره می‌کند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای شمارش خطوط پس از بسته‌بندی خودکار و مشاهدهٔ چگونگی تغییر عرض متن یا شکل، به [Count Rendered Lines](/slides/fa/java/manage-paragraph/) مراجعه کنید. تنها شمارش خطوط نشان‌دهندهٔ overflow متن نیست.

## **تنظیم لنگر قاب‌های متن**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) تعریف می‌کند که متن به‌صورت عمودی داخل یک شکل چگونه موقعیت یابد؛ به‌عنوان مثال در بالا، میانه یا پایین. مثال زیر متن را به پایین اولین شکل لنگر می‌کند و نتیجه را در «text_anchor.pptx» ذخیره می‌کند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم تب‌های متن**

از [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) و [IParagraphFormat.getTabs](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getTabs--) برای پیکربندی نقاط توقف تب در یک پاراگراف استفاده کنید. مثال زیر اندازه پیش‌فرض تب را به 100 پونت تنظیم می‌کند و یک نقطه توقف تب چپ‌تراز را در 30 پونت اضافه می‌کند. این تنظیمات بر متنی که شامل کاراکترهای تب باشد تأثیر می‌گذارد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    
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

## **تنظیم زبان اصلاح نویسندگی**

Aspose.Slides متد [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) را ارائه می‌دهد که به شما اجازه می‌دهد زبان اصلاح نویسندگی برای یک بخش متن را تنظیم کنید. این زبان تعیین می‌کند که بررسی املایی و دستوری در PowerPoint به کدام زبان انجام شود.

مثال زیر نیاز به «presentation.pptx» دارد که اولین شکل آن یک کادر متن در اولین اسلاید باشد و حداقل یک پاراگراف داشته باشد. محتویات اولین پاراگراف را به «1。» تغییر می‌دهد، SimSun را به‌عنوان قلم تنظیم می‌کند و زبان اصلاح نویسندگی چینی ساده (`zh-CN`) را اختصاص می‌دهد. نتیجه در «proofing_language.pptx» ذخیره می‌شود:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // تنظیم شناسه زبان اصلاح نویسندگی.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **کپی متادیتای زبان**

هنگام کپی متن چندزبانه از یک قالب، هر دو [IBasePortionFormat.getLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getLanguageId--) و [IBasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getAlternativeLanguageId--) را حفظ کنید. مثال زیر یک بخش منبع با زبان انگلیسی (آمریکای ایالات متحده) و زبان جایگزین فرانسه ایجاد می‌کند و متن و شناسه‌ها را به یک بخش در ارائه جدید کپی می‌کند.

```java
import com.aspose.slides.*;

Portion source = new Portion("Hello! Bonjour!");
source.getPortionFormat().setLanguageId("en-US");
source.getPortionFormat().setAlternativeLanguageId("fr-FR");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 80);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion destination = new Portion();
    destination.setText(source.getText());
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId());
    // اگر منبع زبان جایگزینی نداشته باشد، null مقدار مقصد را پاک می‌کند.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

اگر می‌خواهید منبع بدون زبان جایگزین داشته باشید، تخصیص `"fr-FR"` را حذف کنید. در این صورت شناسه جایگزین `null` می‌شود و همان دستور کپی عدم وجود آن را بدون افزودن مقدار پیش‌فرض حفظ می‌کند، حتی اگر مقصد قبلاً زبان جایگزین داشته باشد.

این شناسه‌ها متادیتای زبان را ذخیره می‌کنند. حفظ آن‌ها تعیین نمی‌کند که کدام فرهنگ‌نامه توسط PowerPoint برای بررسی املایی یا دستوری انتخاب شود.

## **تنظیم زبان پیش‌فرض**

از [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) برای تعریف زبان پیش‌فرض متنی که در هنگام بارگذاری یا ایجاد یک ارائه ساخته می‌شود، استفاده کنید. مثال زیر ارائه‌ای با زبان پیش‌فرض متن انگلیسی (آمریکای ایالات متحده) ایجاد می‌کند، یک کادر متن اضافه می‌کند و برای اولین بخش متن `en-US` را چاپ می‌کند.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // یک شکل مستطیلی جدید با متن اضافه کنید.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // زبان اولین بخش متن را بررسی کنید.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **تنظیم سبک متن پیش‌فرض**

برای اعمال قالب‌بندی متن پیش‌فرض در سطح ارائه، از [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--) استفاده کنید.

مثال زیر قلم 14‑پونتی بولد را به‌عنوان پیش‌فرض برای پاراگراف‌های سطح بالا در یک ارائه جدید تنظیم می‌کند و آن را در «default_text_style.pptx» ذخیره می‌کند. متن می‌تواند این پیش‌فرض‌ها را ارث‌بَر کند مگر اینکه قالب‌بندی مخصوص‌تر آن‌ها را بازنویسی کند.

```java
import com.aspose.slides.*;

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

## **استخراج متن با اثر All‑Caps**

در PowerPoint، اعمال اثر **All Caps** به قلم باعث می‌شود متن در اسلاید به‌صورت حروف بزرگ نمایش داده شود حتی اگر در ابتدا به حروف کوچک وارد شده باشد. وقتی چنین بخشی را با Aspose.Slides بازیابی می‌کنید، کتابخانه متن دقیقاً همان‌گونه که وارد شده است بر می‌گرداند. برای تطبیق با متن نمایش داده‌شده، [TextCapType](https://reference.aspose.com/slides/java/com.aspose.slides/textcaptype/) را بررسی کنید و هنگامی که مقدار `All` باشد، رشتهٔ برگردانده‌شده را به حروف بزرگ تبدیل کنید.

این مثال نیاز به «sample2.pptx» دارد که اولین شکل آن یک کادر متن در اولین اسلاید باشد. اولین پاراگراف آن اولین بخشش شامل «Hello, Aspose!» است که اثر All Caps روی آن اعمال شده است، همان‌طور که در زیر نشان داده شده:

![اثر All Caps](all_caps_effect.png)

کد زیر نشان می‌دهد چگونه متن را با اثر **All Caps** استخراج کنید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

## **پرسش‌های متداول**

**چگونه متن را در جدول روی اسلاید ویرایش کنم؟**

برای ویرایش متن در جدول روی اسلاید، از [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) استفاده کنید. سلول‌ها را پیمایش کنید و هر سلول را از طریق [ICell.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) و قالب‌بندی پاراگراف از طریق [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getParagraphFormat--) به‌روزرسانی کنید.

**چگونه رنگ گرادیان را به متن روی اسلاید PowerPoint اعمال کنم؟**

برای اعمال رنگ گرادیان به متن، از [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) استفاده کنید. مقدار [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) را به [FillType.Gradient](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) تنظیم کنید و نقاط توقف، جهت و شفافیت گرادیان را پیکربندی کنید.

قابلیت مرتبط: [Format text within slides](/slides/fa/features/text-formatting/).