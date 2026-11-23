---
title: "قالب‌بندی متن ارائه در اندروید"
linktitle: "قالب‌بندی متن"
type: docs
weight: 50
url: /fa/androidjava/text-formatting/
keywords:
- "هم‌ترازی پاراگراف"
- "سبک متن"
- "پس‌زمینه متن"
- "شفافیت متن"
- "فاصله کاراکترها"
- "ویژگی‌های قلم"
- "خانواده قلم"
- "چرخش متن"
- "زاویه چرخش"
- "قاب متن"
- "فاصله خط"
- "ویژگی Autofit"
- "لنگر قاب متن"
- "تب‌بندی متن"
- "زبان پیش‌فرض"
- "PowerPoint"
- "OpenDocument"
- "ارائه"
- "Android"
- "Java"
- "Aspose.Slides"
description: "متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای اندروید از طریق Java قالب‌بندی و استایل دهید. قلم‌ها، رنگ‌ها، تراز و دیگر ویژگی‌ها را سفارشی کنید."
---
## **مرور کلی**

این مقاله نشان می‌دهد که چگونه می‌توان متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Android از طریق Java قالب‌بندی کرد. این مقاله به رنگ‌های پس‌زمینه، شفافیت، فاصله کاراکترها، ویژگی‌های قلم، چرخش، فاصله‌های پاراگراف، رفتار autofit، تکیه‌کردن متن، تب‌استاپ‌ها و تنظیمات زبان می‌پردازد.

مگر اینکه خلاف آن ذکر شود، نمونه‌ها از [sample.pptx](sample.pptx) استفاده می‌کنند. اولین شکل در اولین اسلاید یک جعبه متن است و اولین پاراگراف آن شامل متنی است که در زیر نشان داده شده است. هر دو ایندِکس اسلاید و شکل به‌صورت صفر‑مبنا هستند. نمونه‌هایی که بخش‌های بولد را انتخاب می‌کنند از قالب‌بندی مؤثر استفاده می‌نمایند، از جمله قالب‌بندی بولد به ارث‌برده:

![متن نمونه](sample_text.png)

برای یافتن و برجسته‌سازی متن به‌صورت دقیق یا مطابقت‌های عبارات منظم، به [جستجو و جایگزینی متن](/slides/fa/androidjava/search-and-replace-text/) مراجعه کنید.

## **تنظیم رنگ پس‌زمینه متن**

از [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) برای تنظیم رنگ برجسته پیش‌فرض یک پاراگراف استفاده کنید، یا از [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) برای بخش‌های متنی جداگانه بهره بگیرید.

مثال زیر برجسته خاکستری روشن را به‌عنوان پیش‌فرض برای اولین پاراگراف تنظیم می‌کند. رنگ‌های برجسته صریح بر روی بخش‌های جداگانه نسبت به این پیش‌فرض ارجحیت دارند:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // رنگ برجسته را برای کل پاراگراف تنظیم کنید.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![پاراگراف خاکستری](gray_paragraph.png)

کد نمونه زیر نشان می‌دهد چگونه رنگ پس‌زمینه را برای **بخش‌های متنی با قلم ضخیم** تنظیم کنیم:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // رنگ برجسته را برای بخش متن تنظیم کنید.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LTGRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![بخش‌های متنی خاکستری](gray_text_portions.png)

## **تراز پاراگراف‌های متن**

از [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) برای تنظیم تراز پاراگراف درون یک فریم متن استفاده کنید. مقدار می‌تواند centered، left‑aligned، right‑aligned، justified و غیره باشد.

مثال زیر نشان می‌دهد چگونه پاراگراف را به **مرکز** تراز کنیم:

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

## **تراز قلم‌ها درون یک خط**

از [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) برای تراز عمودی بخش‌های متنی با اندازه‌های قلم مختلف درون یک خط استفاده کنید. این تنظیم بر کل پاراگراف اعمال می‌شود و تراز را در هر کدام از خطوط آن کنترل می‌کند.

مثال زیر یک اسلاید حاوی چهار جعبه متن برچسب‌دار ایجاد می‌کند. هر پاراگراف متنی یکسان با اندازه‌های 18، 36 و 54 پوینت دارد و تراز قلم متفاوتی دارد. از Arial استفاده می‌کند، Autofit و Wrap را غیرفعال می‌سازد و فریم‌های متنی را به‌اندازه‌ای بزرگ می‌کند که تنها یک خط را جا بدهند.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![مقایسه تراز Baseline، Top، Center و Bottom با اندازه‌های قلم ترکیبی](font_alignment.png)

تراز قلم بر پایه معیارهای فونت است، بنابراین لبه‌های قابل مشاهدهٔ حروف لزوماً دقیقاً هم‌سطح نخواهند بود. این مثال شامل یک حرف بزرگ و یک حرف descender است تا تفاوت بین تراز baseline و bottom را نشان دهد. در دسترس بودن قلم، جانشینی، کاراکترهای استفاده‌شده و تفاوت در اندازه‌های قلم بر نتیجه تأثیر می‌گذارند. ابعاد فریم، حاشیه‌ها، فاصلهٔ خط، Wrap و Autofit نیز بر چیدمان تأثیر دارند؛ برای مقایسهٔ حالت‌ها از همان قلم‌ها و تنظیمات لایه‌بندی استفاده کنید.

این تنظیم متفاوت از [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) است که تراز افقی پاراگراف را کنترل می‌کند، و از [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) که موقعیت بلوک متن را عمودی درون شکل تنظیم می‌کند. قالب‌بندی Superscript و Subscript از طریق [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setEscapement-float-) به جای تنظیم تراز قلم برای خطوط پاراگراف، موقعیت بخش‌ها را نسبت به baseline جابه‌جا می‌کند.

## **تنظیم شفافیت متن**

شفافیت متن از طریق مؤلفهٔ آلفای رنگی که به [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) اختصاص داده می‌شود، کنترل می‌شود. در مثال‌های زیر، `alpha = 50` مقدار کانال آلفا در مقیاس 0–255 است، نه درصد شفافیت.

کد نمونه زیر نشان می‌دهد چگونه شفافیت را برای **کل پاراگراف** اعمال کنیم:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // رنگ پرکننده متن را به رنگ شفاف تنظیم کنید.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![پاراگراف شفاف](transparent_paragraph.png)

کد نمونه زیر نشان می‌دهد چگونه شفافیت را برای **بخش‌های متنی با قلم ضخیم** اعمال کنیم:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // شفافیت بخش متن را تنظیم کنید.
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

![بخش‌های متنی شفاف](transparent_text_portions.png)

## **تنظیم فاصله کاراکترها برای متن**

از [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) برای افزايش یا فشرده‌سازی فاصله بین کاراکترها در یک جعبه متن استفاده کنید. مثال‌ها 3 پوینت فاصله اضافه می‌کند؛ مقادیر منفی متن را فشرده می‌سازند.

کد جاوا زیر نشان می‌دهد چگونه فاصله کاراکترها را در **کل پاراگراف** گسترش دهیم:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // توجه: برای فشرده‌سازی فاصلهٔ کاراکترها از مقادیر منفی استفاده کنید.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // فاصلهٔ کاراکترها را گسترش دهید.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![فاصله کاراکترها در پاراگراف](character_spacing_in_paragraph.png)

کد نمونه زیر نشان می‌دهد چگونه فاصله کاراکترها را در **بخش‌های متنی با قلم ضخیم** گسترش دهیم:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // توجه: برای فشرده‌سازی فاصلهٔ کاراکترها از مقادیر منفی استفاده کنید.
            portion.getPortionFormat().setSpacing(3); // فاصلهٔ کاراکترها را گسترش دهید.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![فاصله کاراکترها در بخش‌های متنی](character_spacing_in_text_portions.png)

### **غیرفعال‌سازی Kerning برای قلم‌های خاص**

در برخی موارد، متنی که توسط Aspose.Slides رندر می‌شود ممکن است کمی فشرده‌تر از همان متن در PowerPoint به نظر برسد. این می‌تواند به این دلیل باشد که PowerPoint داده‌های kerning را برای برخی قلم‌ها نادیده می‌گیرد، حتی اگر قلم شامل اطلاعات معتبر kerning باشد و kerning در تنظیمات PowerPoint فعال باشد.

برای نزدیک‌تر کردن خروجی رندر به PowerPoint می‌توانید kerning را برای بخش‌های متنی که از قلم تحت تأثیر استفاده می‌کنند، غیرفعال کنید. مقدار [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) را بزرگ‌تر از اندازهٔ واقعی قلم تنظیم کنید. این مثال به «presentation.pptx» که حاوی یک جعبه متن به‌عنوان اولین شکل در اولین اسلاید است، نیاز دارد. نام‌های قلم مؤثر، شامل قلم‌های به ارث‌برده، بررسی می‌شود و آستانهٔ 100 پوینت برای بخش‌هایی که از Roboto استفاده می‌کنند، تنظیم می‌شود. این کار kerning را برای بخش‌های متن با اندازهٔ قلم زیر 100 پوینت غیرفعال می‌کند:

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

برای متن‌های منطبق با آستانه، این تنظیم از kerning جلوگیری می‌کند و می‌تواند به هم‌راستای شدن رندر Aspose.Slides با خروجی بصری PowerPoint برای قلم‌های تحت تأثیر این رفتار خاص PowerPoint کمک کند.

## **مدیریت ویژگی‌های قلم متن**

ویژگی‌های قلم می‌توانند در سطح پاراگراف از طریق [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) یا بر روی بخش‌های جداگانه از طریق [IPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/) تنظیم شوند.

مثال زیر قلم پیش‌فرض اولین پاراگراف را به Times New Roman 12 پوینت با قالب بولد، ایتالیک و زیرخط نقطه‌ای تنظیم می‌کند. قالب‌بندی صریح بر روی بخش‌های جداگانه بر این پیش‌فرض‌ها ارجحیت دارد:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // ویژگی‌های قلم را برای پاراگراف تنظیم کنید.
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

مثال زیر Times New Roman 13 پوینت، قالب ایتالیک و زیرخط نقطه‌ای را برای بخش‌هایی که قالب مؤثر آن‌ها بولد است، اعمال می‌کند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // ویژگی‌های قلم را برای بخش متن تنظیم کنید.
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

![ویژگی‌های قلم برای بخش‌های متنی](font_properties_for_text_portions.png)

## **کنترل نرمال‌سازی ارتفاع متن**

از [IBasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setNormaliseHeight-byte-) برای بازآفرینی تایپوگرافی قالب یا بررسی تفاوت‌های ارتفاع کاراکترها استفاده کنید. در PowerPoint، فعال‌سازی نرمال‌سازی کاراکترهای فردی را به صورت عمودی کشیده یا فشرده می‌کند تا ارتفاع قابل مشاهدهٔ یکنواختی داشته باشند؛ اما تضمین نمی‌کند که ارتفاع متون در قلم‌های مختلف برابر باشد.

مقدار ویژگی را به [NullableBool.True یا False](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) تنظیم کنید تا صراحتاً نرمال‌سازی را فعال یا غیرفعال کنید. `NullableBool.NotDefined` تنظیم محلی را نا‌تنظیم می‌گذارد تا بخش مقدار را از پاراگراف (مثلاً از [getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--)) به ارث ببرد. این به معنی `False` نیست. از [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--) و [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) برای دریافت مقدار بولی حل‌شده استفاده کنید.

مثال مستقل زیر به **Arial** نصب‌شده نیاز دارد. دو بلوک متن حاوی حروف بزرگ، حروف کوچک، descender و کاراکترهای لهجه‌دار را در اندازهٔ 54 پوینت ایجاد می‌کند. هر دو پاراگراف به‌طور پیش‌فرض نرمال‌سازی را فعال می‌کند؛ بخش بالا صراحتاً آن را غیرفعال می‌کند؛ بخش پایین آن را به ارث می‌برد. اندازه فریم‌ها، حاشیه‌ها و فاصله پاراگراف یکسان هستند و Wrap و Autofit غیرفعال‌اند تا مقایسه سازگار بماند. برنامه `False: false` و `NotDefined: true` را چاپ می‌کند و «text_height_normalization.pptx» را ذخیره می‌نماید.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

مقایسهٔ زیر از ارائهٔ ذخیره‌شده استخراج شده است. ردیف بالایی نرمال‌سازی غیرفعال (`False`) دارد؛ ردیف پایینی مقدار ارث‌برده فعال (`NotDefined` → `True`) را نشان می‌دهد. برای بازآفرینی این ظاهر، Arial باید نصب باشد.

![متن 54‑پوینتی Arial با نرمال‌سازی غیرفعال در بالا و نرمال‌سازی ارث‌برده فعال در پایین](text_height_normalization.png)

نرمال‌سازی ارتفاع کاراکترها را بدون تغییر مقدار [getFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFontHeight--) که اندازهٔ قلم را به پوینت مشخص می‌کند، تغییر می‌دهد. [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) فاصلهٔ خطوط را کنترل می‌کند، در حالی که [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) نحوهٔ تنظیم اندازهٔ متن یا ظرف آن را مشخص می‌کند. این تنظیمات هدفهای متفاوتی دارند و می‌توانند به‌صورت مستقل نحوهٔ کلی چیدمان را تغییر دهند. برای اطلاعات بیشتر درباره قالب‌بندی پاراگراف و ارث‌بری، به [مدیریت پاراگراف](/slides/fa/androidjava/manage-paragraph/) مراجعه کنید.

## **اعمال و حذف Strikethrough**

از [IBasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setStrikethroughType-byte-) روی یک بخش متن برای نمایش اصلاحات، اصطلاحات لغو‌شده یا قیمت‌های قبلی بدون حذف متن اصلی استفاده کنید. برای یک یا دو خط عبور از متن، مقدار را به ترتیب به [TextStrikethroughType.Single یا Double](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/) تنظیم کنید.

برای حذف Strikethrough، مقدار [TextStrikethroughType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/#None) را بدهید. این صراحتاً اثر را غیرفعال می‌کند، حتی اگر قالب‌بندی زمینه‌ای Strikethrough داشته باشد. برعکس، مقدار [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/#NotDefined) تنظیم محلی را تعریف‌نشده می‌گذارد تا بخش قالب‌بندی را از پاراگراف به ارث ببرد؛ این تضمین نمی‌کند که Strikethrough حذف شود. برای خواندن قالب‌بندی نتیجه، شامل مقادیر ارث‌برده، از [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--) استفاده کنید.

مثال زیر سه مقایسهٔ قیمتی ایجاد می‌کند. هر پاراگراف بخش‌های جداگانه‌ای برای برچسب، قیمت قبلی و قیمت جاری دارد؛ تنها قیمت قبلی تحت تأثیر قرار می‌گیرد. ردیف اول Strikethrough را اعمال و سپس حذف می‌کند؛ سایر ردیف‌ها Strikethrough تک‌خطی و دوخطی را حفظ می‌کنند. تغییر این تنظیم متن و دیگر قالب‌بندی‌های آن، از جمله بولد بودن قیمت قبلی، را حفظ می‌نماید.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

    // Strikethrough را اعمال کنید، سپس به‌صورت صریح آن را از اولین قیمت قبلی حذف کنید.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None);

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double);

    presentation.save("strikethrough.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه (از بالا به پایین): بدون Strikethrough، Strikethrough تک‌خطی و Strikethrough دوخطی.

![قیمت‌های قبلی بدون Strikethrough، با Strikethrough تک‌خطی و با Strikethrough دوخطی](strikethrough.png)

## **تنظیم چرخش متن**

از [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) برای تنظیم جهت پیش‌فرض متن درون یک شکل استفاده کنید.

مثال زیر جهت متن در شکل را به [TextVerticalType.Vertical270](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textverticaltype/) تنظیم می‌کند؛ این مقدار متن را **90 درجه ضد ساعتگرد** می‌چرخاند:

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

برای نگه داشتن یک عدد دو رقمی در یک برچسب ژاپنی عمودی، هر دو رقم را در یک بخش متن قرار دهید و روی آن بخش متد [IBasePortionFormat.setKumimoji](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setKumimoji-byte-) را فراخوانی کنید. مثال از [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textverticaltype/#EastAsianVertical) و قلم MS Gothic 40 پوینت برای هر دو برچسب استفاده می‌کند. فقط مقدار [NullableBool](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) که به بخش عددی پاس داده می‌شود متفاوت است.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

در PowerPoint، برچسب چپ (`True`) ارقام را به‌صورت عمودی و کنار هم بین 和 و 年 نشان می‌دهد. در برچسب راست (`False`) جفت ارقام 90 درجه ساعتگرد چرخیده‌اند. کاراکترهای ژاپنی اطراف در هر دو برچسب عمودی می‌مانند.

![مقایسهٔ برچسب‌های تاریخ عمودی در PowerPoint با ارقام عمودی در سمت چپ و ارقام چرخیده در سمت راست](vertical_date.png)

## **تنظیم چرخش سفارشی برای فریم‌های متن**

از [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) برای تنظیم زاویهٔ چرخش دلخواه برای یک [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) استفاده کنید.

کد نمونه زیر فریم متن را 3 درجه ساعتگرد درون شکل می‌چرخاند:

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

## **تنظیم فاصلهٔ خطی پاراگراف‌ها**

Aspose.Slides توابع [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-)، [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) و [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) را برای کنترل فاصلهٔ پاراگراف‌ها فراهم می‌کند. این ویژگی‌ها به‌صورت زیر به‌کار می‌روند:

* استفاده از مقدار مثبت برای تعیین فاصلهٔ خط به‌عنوان درصدی از ارتفاع خط.
* استفاده از مقدار منفی برای تعیین فاصلهٔ خط به‌صورت پوینت.

مثال زیر فاصلهٔ داخل اولین پاراگراف را به 200 % از ارتفاع خط (فاصلهٔ دو‌برابری) تنظیم می‌کند:

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

![فاصلهٔ خط درون پاراگراف](line_spacing.png)

## **کنترل شکستن خط**

قواعد شکستن خط پاراگراف در بلوک‌های متنی باریک و ارائه‌های ترکیبی لاتین و شرق آسیا مفید هستند. متدهای زیر متعلق به [IParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/) هستند و بنابراین بر کل پاراگراف اعمال می‌شوند:

- [setLatinLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) قواعد شکستن خط لاتین را کنترل می‌کند. در متن ترکیبی، تغییر آن می‌تواند محل شکست متن شرق آسیا و علامت‌های نگارشی را نیز تغییر دهد.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) قواعد شکستن خط شرق آسیا را کنترل می‌کند، شامل محدودیت‌های کاراکتر در ابتدا و انتهای خط.

این قواعد جایگزین [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) نمی‌شوند؛ این متد Wrap خودکار را درون فریم متن فعال می‌سازد. این قواعد بر چیدمان زمانی که Wrap رخ می‌دهد تأثیر می‌گذارند؛ آن‌ها کاراکترهای شکستن خط را درج نمی‌کنند. یک شکست خط صریح یک خط جدید درون پاراگراف ایجاد می‌کند که مستقل از عرض موجود است.

مثال زیر یک بلوک متن باریک حاوی چینی و لاتین می‌سازد. هر دو گزینه شکستن خط به‌صورت صریح تنظیم می‌شوند و «line_breaking.pptx» ذخیره می‌شود. برای آزمایش هر یک از قواعد، مقدار مربوطه را تغییر دهید و دیگری را ثابت بگذارید. مثال از Arial 24 پوینت و SimSun با عرض فریم 160 پوینت و حاشیهٔ افقی صفر استفاده می‌کند. [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) با مقدار [TextAutofitType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textautofittype/) فراخوانی می‌شود تا اندازهٔ متن و ابعاد فریم ثابت بمانند.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **کنترل علامت تعلیق‌دار (Hanging Punctuation)**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) به علامت‌های مجاز اجازه می‌دهد تا از حاشیهٔ راست خط متن فراتر روند به‌جای اینکه در خط بعدی قرار گیرند. این ویژگی برای کل پاراگراف اعمال می‌شود و با تورفتگی معلق متفاوت است.

مثال زیر علامت تعلیق‌دار را در فریم متنی با عرض 100 پوینت فعال می‌کند و «hanging_punctuation.pptx» را ذخیره می‌کند. با Arial 24 پوینت و حاشیهٔ افقی صفر، نقطهٔ نهایی پس از «sentence» می‌ماند و از حاشیهٔ راست متن فراتر می‌رود. برای مقایسه مقدار را به [NullableBool.False](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) تنظیم کنید: با این تنظیمات، نقطه در خط جداگانه‌ای قرار می‌گیرد. Wrap فعال و Autofit غیرفعال است تا عرض قابل استفاده ثابت بماند.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

هر علامت نگارشی نمی‌تواند تعلیق‌دار باشد. شرایط قلم و چیدمان توضیح داده‌شده در بخش [کنترل شکستن خط](#control-line-breaking) نیز برای این مقایسه اعمال می‌شود: تغییر قلم، عرض موجود، حاشیه‌ها یا تنظیمات Autofit می‌تواند تفاوت قابل مشاهده را از بین ببرد.

## **تنظیم نوع Autofit برای فریم‌های متن**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) تعیین می‌کند که متن وقتی از مرزهای ظرف خود فراتر می‌رود، چگونه رفتار کند. از آن برای کنترل اینکه آیا متن کوچک می‌شود، سرریز می‌کند یا به‌صورت خودکار شکل را تغییر اندازه می‌دهد، استفاده کنید. مثال زیر شکل را طوری تنظیم می‌کند که برای متناسب شدن با متن، اندازهٔ خود را تغییر دهد و نتیجه در «autofit_type.pptx» ذخیره می‌شود.

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

برای شمارش خطوط پس از Wrap خودکار و مشاهدهٔ چگونگی تغییر عرض متن یا شکل، به [شمارش خطوط رندر شده](/slides/fa/androidjava/manage-paragraph/) مراجعه کنید. صرفاً شمارش خطوط نشان‌دهندهٔ سرریز متن نیست.

## **تنظیم Anchor فریم‌های متن**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) تعریف می‌کند که متن عمودی داخل یک شکل در کجا قرار بگیرد؛ مثلاً در بالا، وسط یا پایین. مثال زیر متن را به پایین‌ترین قسمت اولین شکل می‌چسباند و نتیجه را در «text_anchor.pptx» ذخیره می‌کند.

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

از [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) و [IParagraphFormat.getTabs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) برای پیکربندی توقف‌های تب در یک پاراگراف استفاده کنید. مثال زیر فاصلهٔ پیش‌فرض تب را به 100 پوینت تنظیم می‌کند و یک توقف تب چپ‌راست در 30 پوینت اضافه می‌کند. این تنظیمات بر متنی که شامل کاراکترهای تب است اثر می‌گذارند.

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

## **تنظیم زبان Proofing**

Aspose.Slides متد [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) را فراهم می‌کند که به شما امکان می‌دهد زبان proofing یک بخش متن را تنظیم کنید. زبان proofing زبان مورد استفاده برای بررسی غلط‌املایی و گرامر در PowerPoint را تعیین می‌کند.

مثال زیر به «presentation.pptx» که یک جعبه متن به‌عنوان اولین شکل در اولین اسلاید دارد و حداقل یک پاراگراف دارد، نیاز دارد. محتویات اولین پاراگراف را با «1。」» جایگزین می‌کند، قلم آن را به SimSun تنظیم می‌نماید و زبان proofing چینی ساده (`zh-CN`) را اختصاص می‌دهد. نتیجه در «proofing_language.pptx» ذخیره می‌شود:

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

    // شناسه زبان proofing را تنظیم کنید.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **کپی کردن Metadata زبان**

هنگام کپی متن چندزبانه از یک قالب، هم [IBasePortionFormat.getLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getLanguageId--) و هم [IBasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getAlternativeLanguageId--) را حفظ کنید. مثال زیر یک بخش منبع با زبان US English و زبان جایگزین French ایجاد می‌کند و متن و شناسه‌ها را به بخشی در ارائهٔ جدید کپی می‌نماید.

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
    // اگر منبع زبان جایگزین نداشته باشد، مقدار null مقدار مقصد را پاک می‌کند.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای آزمایش منبع بدون زبان جایگزین، مقدار `"fr-FR"` را اختصاص ندهید. در این صورت شناسه جایگزین `null` می‌شود و دستور کپی همان‌طور که هست آن را حفظ می‌کند؛ حتی اگر مقصد قبلاً زبان جایگزین داشته باشد.

این شناسه‌ها متادیتای زبان را نگهداری می‌کنند. حفظ آن‌ها تعیین‌کنندهٔ دیکشنری‌ای که PowerPoint برای بررسی املا یا گرامر انتخاب می‌کند، نیست.

## **تنظیم زبان پیش‌فرض**

از [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) برای تعریف زبان پیش‌فرض متنی که هنگام بارگذاری یا ایجاد ارائه ایجاد می‌شود، استفاده کنید. مثال زیر یک ارائه با زبان پیش‌فرض US English ایجاد می‌کند، یک جعبه متن اضافه می‌کند و برای اولین بخش متنی «en-US» را چاپ می‌کند.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // اضافه کردن یک شکل مستطیلی جدید با متن.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // بررسی زبان اولین بخش متن.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **تنظیم سبک پیش‌فرض متن**

برای اعمال قالب‌بندی متن پیش‌فرض در سطح ارائه، از [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--) استفاده کنید.

مثال زیر قلم 14‑پوینتی بولد را به‌عنوان پیش‌فرض برای پاراگراف‌های سطح بالا در یک ارائهٔ جدید تنظیم می‌کند و در «default_text_style.pptx» ذخیره می‌نماید. متن می‌تواند این پیش‌فرض‌ها را به ارث ببرد مگر اینکه قالب‌بندی خاص‌تری آن‌ها را بازنویسی کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // دریافت قالب پاراگراف سطح بالایی.
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

در PowerPoint، اعمال افکت فونت **All Caps** متن را روی اسلاید به صورت حروف بزرگ نشان می‌دهد حتی اگر در اصل با حروف کوچک وارد شده باشد. هنگام بازیابی چنین بخشی از متن با Aspose.Slides، کتابخانه متن را دقیقاً همان‌طور که وارد شده است برمی‌گرداند. برای هم‌خوانی با متن نمایش داده‌شده، مقدار [TextCapType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textcaptype/) را بررسی کنید و وقتی مقدار `All` باشد، رشتهٔ بازگردانده‌شده را به حروف بزرگ تبدیل کنید.

این مثال به «sample2.pptx» که یک جعبه متن به‌عنوان اولین شکل در اولین اسلاید دارد، نیاز دارد. اولین پاراگراف آن شامل «Hello, Aspose!» با افکت All Caps است، همان‌طور که در پایین نشان داده شده است.

![اثر All Caps](all_caps_effect.png)

کد نمونه زیر نشان می‌دهد چگونه متن را با اعمال افکت **All Caps** استخراج کنیم:

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

## **سؤالات متداول**

**چگونه می‌توان متن در یک جدول روی اسلاید را ویرایش کرد؟**

برای ویرایش متن در جدول روی اسلاید، از [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) استفاده کنید. سلول‌ها را پیمایش کنید و هر سلول را از طریق [ICell.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) به‌روزرسانی کنید و قالب‌بندی پاراگراف را از طریق [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) تنظیم نمایید.

**چگونه می‌توان رنگ گرادیان را به متن در یک اسلاید PowerPoint اعمال کرد؟**

برای اعمال رنگ گرادیان به متن، از [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) استفاده کنید. مقدار [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) را به [FillType.Gradient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) تنظیم کنید و نقاط توقف، جهت و شفافیت گرادیان را پیکربندی نمایید.