---
title: قالب‌بندی متن ارائه در جاوا
linktitle: قالب‌بندی متن
type: docs
weight: 50
url: /fa/java/text-formatting/
keywords:
- تراز پاراگراف
- سبک متن
- پس‌زمینه متن
- شفافیت متن
- فاصلهٔ کاراکتر
- ویژگی‌های قلم
- خانوادهٔ قلم
- چرخش متن
- زاویهٔ چرخش
- قاب متن
- فاصلهٔ خطوط
- ویژگی خودکار تنظیم اندازه
- لنگر قاب متن
- تب‌گذاری متن
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Java قالب‌بندی و استایل‌دهی کنید. قلم‌ها، رنگ‌ها، تراز و موارد دیگر را سفارشی کنید."
---
## **مروری**

این مقاله نشان می‌دهد چگونه می‌توان متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Java قالب‌بندی کرد. مواردی شامل رنگ‌های پس‌زمینه، شفافیت، فاصلهٔ کاراکترها، ویژگی‌های قلم، چرخش، فاصلهٔ پاراگراف، رفتار خودکار تنظیم اندازه، لنگر متن، موقعیت‌های تب و تنظیمات زبان پوشش داده می‌شوند.

مگر اینکه به‌ صراحت ذکر شده باشد، مثال‌ها از [sample.pptx](sample.pptx) استفاده می‌کنند. اولین شکل در اولین اسلاید یک جعبهٔ متن است و اولین پاراگراف آن متنی که در زیر نشان داده شده است را شامل می‌شود. هر دو شاخص اسلاید و شکل از صفر شروع می‌شوند. مثال‌هایی که بخش‌های بولد را انتخاب می‌کنند از قالب‌بندی مؤثر استفاده می‌نمایند، از جمله قالب‌بندی بولد ارث‌بری شده:

![متن نمونه](sample_text.png)

برای یافتن و برجسته کردن متن دقیق یا مطابقت‌های عبارت منظم، به بخش [Search and Replace Text](/slides/fa/java/search-and-replace-text/) مراجعه کنید.

## **تنظیم رنگ پس‌زمینهٔ متن**

از [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) برای تنظیم رنگ پیش‌زمینهٔ پیش‌فرض یک پاراگراف استفاده کنید یا از [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) برای قسمت‌های متن جداگانه.

مثال زیر رنگ پس‌زمینهٔ خاکستری روشن را به‌عنوان پیش‌فرض اولین پاراگراف تنظیم می‌کند. رنگ‌های برجستهٔ صریح در قسمت‌های جداگانه بر این پیش‌فرض تقدم دارند:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // رنگ برجسته را برای کل پاراگراف تنظیم کنید.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![پاراگراف خاکستری](gray_paragraph.png)

مثال کد زیر نشان می‌دهد چگونه رنگ پس‌زمینه را برای **قسمت‌های متنی با قلم بولد** تنظیم کنید:

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
            // رنگ برجسته را برای قسمت متن تنظیم کنید.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![قسمت‌های متن خاکستری](gray_text_portions.png)

## **تنظیم تراز پاراگراف‌های متن**

از [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) برای تنظیم تراز پاراگراف در یک قاب متن استفاده کنید. مقدار می‌تواند مرکز، چپ، راست، هم‌تراز و غیره باشد.

مثال کد زیر نشان می‌دهد چگونه پاراگراف را به **مرکز** تراز کنید:

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

از [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) برای تراز عمودی قسمت‌های متنی با اندازهٔ قلم‌های متفاوت در یک خط استفاده کنید. این تنظیم برای کل پاراگراف اعمال می‌شود و تراز هر خط را کنترل می‌کند.

مثال زیر چهار جعبهٔ متن دارای برچسب در یک اسلاید ایجاد می‌کند. هر پاراگراف متن یکسانی را با اندازه‌های ۱۸، ۳۶ و ۵۴ پوینت دارد و تراز قلم متفاوتی دارد. از Arial استفاده می‌شود، خودکار تنظیم اندازه و پیچش غیرفعال‌اند و قاب‌های متن به اندازهٔ کافی بزرگ برای یک خط باقی می‌مانند.

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

![مقایسهٔ تراز Baseline، Top، Center و Bottom با اندازه‌های قلم مخلوط](font_alignment.png)

تراز قلم از مترات قلم استفاده می‌کند، بنابراین لبه‌های قابل‌مشاهدهٔ حروف لزوماً دقیقاً هم‌خط نیستند. این مثال شامل یک حرف بزرگ و یک پایین‌نشین است تا تفاوت بین تراز پایه و پایین را نشان دهد. موجودی قلم و جایگزینی، کاراکترهای استفاده‌شده و تفاوت در اندازهٔ قلم بر نتایج مؤثر است. ابعاد قاب، حاشیه‌ها، فاصلهٔ خطوط، پیچش و خودکار تنظیم اندازه نیز بر چیدمان تأثیر می‌گذارند؛ برای مقایسهٔ حالت‌ها از همان قلم و تنظیمات چیدمان استفاده کنید.

این تنظیم متفاوت از [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) است که تراز افقی پاراگراف را کنترل می‌کند و از [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) که بلوک متن را عمودی داخل شکل موقعیت می‌دهد، متمایز است. قالب‌بندی سوپرسکریپت و ساب‌اسکریپت از طریق [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setEscapement-float-) بخش‌های جداگانه را نسبت به خط پایه جابه‌جا می‌کند نه اینکه تراز قلم خطوط پاراگراف را تنظیم کند.

## **تنظیم شفافیت برای متن**

شفافیت متن از طریق مؤلفهٔ آلفای رنگ اختصاص‌یافته به [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) کنترل می‌شود. در مثال‌های زیر، `alpha = 50` مقدار کانال آلفای ARGB در بازهٔ ۰ تا ۲۵۵ است، نه درصد شفافیت.

مثال کد زیر نشان می‌دهد چگونه شفافیت را بر **تمام پاراگراف** اعمال کنید:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // رنگ پر کردن متن را به رنگ شفاف تنظیم کنید.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![پاراگراف شفاف](transparent_paragraph.png)

مثال کد زیر نشان می‌دهد چگونه شفافیت را بر **قسمت‌های متنی با قلم بولد** اعمال کنید:

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
            // تنظیم شفافیت قسمت متن.
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

![قسمت‌های متن شفاف](transparent_text_portions.png)

## **تنظیم فاصلهٔ کاراکترها برای متن**

از [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) برای گسترش یا فشردن فاصلهٔ بین کاراکترها در یک جعبهٔ متن استفاده کنید. مثال‌ها ۳ پوینت فاصله اضافه می‌کند؛ مقادیر منفی متن را فشرده می‌نمایند.

کد Java زیر نشان می‌دهد چگونه فاصلهٔ کاراکترها را در **تمام پاراگراف** افزایش دهید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // توجه: برای فشردن فاصلهٔ کاراکتر از مقادیر منفی استفاده کنید.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // فاصلهٔ کاراکتر را گسترش دهید.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![فاصلهٔ کاراکترها در پاراگراف](character_spacing_in_paragraph.png)

مثال کد زیر نشان می‌دهد چگونه فاصلهٔ کاراکترها را در **قسمت‌های متنی با قلم بولد** افزایش دهید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // توجه: برای فشردن فاصلهٔ کاراکتر از مقادیر منفی استفاده کنید.
            portion.getPortionFormat().setSpacing(3); // فاصلهٔ کاراکتر را گسترش دهید.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![فاصلهٔ کاراکترها در قسمت‌های متن](character_spacing_in_text_portions.png)

### **غیرفعال‌سازی کرنینگ برای قلم‌های خاص**

در برخی موارد، متن نمایش داده‌شده توسط Aspose.Slides ممکن است کمی فشرده‌تر از متن مشابه در PowerPoint به‌نظر برسد. این می‌تواند به این دلیل باشد که PowerPoint داده‌های کرنینگ را برای برخی قلم‌ها نادیده می‌گیرد، حتی اگر قلم اطلاعات کرنینگ معتبر داشته باشد و کرنینگ در تنظیمات PowerPoint فعال باشد.

برای نزدیک‌تر شدن خروجی رندر به PowerPoint، می‌توانید کرنینگ را برای قسمت‌های متنی که از قلم موردنظر استفاده می‌کنند غیرفعال کنید. مقدار [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) را بزرگ‌تر از اندازهٔ واقعی قلم تنظیم کنید. این مثال به «presentation.pptx» با یک جعبهٔ متن به‌عنوان اولین شکل در اولین اسلاید نیاز دارد. نام‌های قلم مؤثر، از جمله قلم‌های ارث‌بری‌شده را بررسی می‌کند و برای قسمت‌هایی که از Roboto استفاده می‌کنند آستانهٔ ۱۰۰ پوینت تنظیم می‌کند؛ این برای قسمت‌های با اندازهٔ قلم زیر ۱۰۰ پوینت کرنینگ را غیرفعال می‌سازد:

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

برای متنی که زیر آستانه است، این تنظیم کرنینگ را جلوگیری می‌کند و می‌تواند به هم‌راستای کردن رندر Aspose.Slides با خروجی بصری PowerPoint برای قلم‌های تحت تأثیر این رفتار خاص PowerPoint کمک کند.

## **مدیریت ویژگی‌های قلم متن**

ویژگی‌های قلم می‌توانند در سطح پاراگراف از طریق [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) یا بر روی قسمت‌های جداگانه از طریق [IPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/) تنظیم شوند.

مثال زیر قلم پیش‌فرض اولین پاراگراف را به ۱۲ پوینت Times New Roman با قالب بولد، ایتالیک و زیرخط نقطه‌دار تنظیم می‌کند. قالب‌بندی صریح بر روی قسمت‌های جداگانه بر این پیش‌فرض‌ها تقدم دارد:

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

مثال زیر ۱۳ پوینت Times New Roman، قالب ایتالیک و زیرخط نقطه‌دار را بر قسمت‌هایی که قالب مؤثرشان بولد است اعمال می‌کند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // تنظیم ویژگی‌های قلم برای قسمت متن.
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

![ویژگی‌های قلم برای قسمت‌های متن](font_properties_for_text_portions.png)

## **کنترل عادی‌سازی ارتفاع متن**

از [IBasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setNormaliseHeight-byte-) هنگام بازآفرینی تایپوگرافی قالب یا بررسی تفاوت‌های ارتفاع کاراکتر استفاده کنید. در PowerPoint، فعال‌سازی عادی‌سازی کاراکترهای جداگانه را به‌صورت عمودی کشیده یا فشرده می‌کند تا ارتفاع قابل‌دید یکسانی در داخل قسمت متن داشته باشند. این تضمین نمی‌کند که ارتفاع متون بین قلم‌های مختلف مساوی باشد.

مقدار ویژگی را به [NullableBool.True یا False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) تنظیم کنید تا صراحتاً عادی‌سازی را فعال یا غیرفعال کنید. `NullableBool.NotDefined` تنظیم محلی را نامشخص می‌گذارد تا مقدار از پاراگراف (مثلاً از [getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--)) به ارث برسد؛ این به معنای `False` نیست. از [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) و [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) برای دریافت مقدار Boolean حل‌شده استفاده کنید.

مثال خودمستقلی که در ادامه می‌آید به **Arial** نصب‌شده نیاز دارد. دو بلوک متن شامل حروف بزرگ، حروف کوچک، حروف پایین‌نشین و کاراکترهای لهجه‌دار در ۵۴ پوینت ایجاد می‌کند. هر دو پاراگراف به طور پیش‌فرض عادی‌سازی را فعال می‌کند. قسمت بالا صراحتاً آن را غیرفعال می‌کند؛ قسمت پایین آن را به ارث می‌برد. ابعاد قاب، حاشیه‌ها و فاصلهٔ پاراگراف یکسان‌اند و پیچش و خودکار تنظیم اندازه غیرفعال‌اند تا مقایسه ثابت بماند. مثال `False: false` و `NotDefined: true` را چاپ می‌کند و «text_height_normalization.pptx» را ذخیره می‌نماید:

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

مقایسهٔ زیر از ارائهٔ ذخیره‌شده استخراج شده است. ردیف بالایی عادی‌سازی غیرفعال (`False`) دارد؛ ردیف پایینی از تنظیم فعال شده ارث می‌برد (`NotDefined` → `True`). برای بازتولید این ظاهر، Arial نصب باشد.

![متن ۵۴ پوینت Arial با عادی‌سازی غیرفعال در بالا و عادی‌سازی ارث‌بری شده در پایین](text_height_normalization.png)

عادی‌سازی ارتفاع کاراکترها را بدون تغییر مقدار [getFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFontHeight--) که اندازهٔ قلم را بر حسب پوینت مشخص می‌کند، تغییر می‌دهد. [setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) در پاراگراف فاصلهٔ خطوط را کنترل می‌کند، در حالی که [setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) در قاب متن نحوهٔ تنظیم متن یا محفظهٔ آن را برای پر شدن تعیین می‌کند. این تنظیمات اهداف متفاوتی دارند و می‌توانند به‌صورت مستقل بر چیدمان کلی تأثیر بگذارند. برای اطلاعات بیشتر درباره قالب‌بندی پاراگراف و ارث‌بری، به بخش [Manage Paragraph](/slides/fa/java/manage-paragraph/) مراجعه کنید.

## **اعمال و حذف خط‌گذاری (Strikethrough)**

از [IBasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setStrikethroughType-byte-) بر روی یک قسمت متن برای نشان دادن اصلاحات، عبارات لغو شده یا قیمت‌های قبلی بدون حذف متن اصلی استفاده کنید. آن را به [TextStrikethroughType.Single یا Double](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/) تنظیم کنید تا یک یا دو خط بر متن کشیده شود.

برای حذف خط‌گذاری، [TextStrikethroughType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/#None) را پاس کنید. این به‌صراحت اثر را غیرفعال می‌کند، حتی اگر قالب‌بندی اطراف خط‌گذاری داشته باشد. برعکس، [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/#NotDefined) تنظیم محلی را نامشخص می‌گذارد تا قسمت قالب‌بندی را از پاراگراف به ارث ببرد؛ این تضمین نمی‌کند که خط‌گذاری حذف شود. برای خواندن قالب‌بندی نهایی، شامل مقادیر ارث‌بری‌شده، از [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) استفاده کنید.

مثال خودمستقلی زیر سه مقایسهٔ قیمت ایجاد می‌کند. هر پاراگراف دارای قسمت‌های جداگانه برای برچسب، قیمت قبلی و قیمت فعلی است، بنابراین فقط قیمت قبلی تحت تأثیر قرار می‌گیرد. ردیف اول خط‌گذاری را اعمال و سپس حذف می‌کند؛ ردیف‌های دیگر به ترتیب خط‌گذاری تک و دو خطی را حفظ می‌کنند. تغییر این تنظیم متن و دیگر قالب‌بندی‌های آن، از جمله بولد بودن قیمت قبلی، را حفظ می‌کند.

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

    // خط‌گذاری را اعمال کنید، سپس به‌طور صریح آن را از اولین قیمت قبلی حذف کنید.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None);

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double);

    presentation.save("strikethrough.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه، از بالا به پایین: بدون خط‌گذاری، خط‌گذاری تک‌خطی و خط‌گذاری دوخطی.

![قیمت‌های قبلی بدون خط‌گذاری، با خط‌گذاری تک‌خطی و با خط‌گذاری دوخطی](strikethrough.png)

## **تنظیم چرخش متن**

از [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) برای تنظیم یک جهت‌گیری پیش‌تعریف‌شدهٔ متن درون یک شکل استفاده کنید.

مثال کد زیر جهت‌گیری متن در شکل را به [TextVerticalType.Vertical270](https://reference.aspose.com/slides/java/com.aspose.slides/textverticaltype/) تنظیم می‌کند که متن را **۹۰ درجه ساعت‌گرد** می‌چرخاند:

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

## **تنظیم چرخش سفارشی برای قاب‌های متن**

از [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) برای تنظیم زاویهٔ چرخش سفارشی یک [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) استفاده کنید.

مثال کد زیر قاب متن را ۳ درجه ساعت‌گرد درون شکل می‌چرخاند:

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

## **تنظیم فاصلهٔ خطوط پاراگراف‌ها**

Aspose.Slides متدهای [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-)، [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) و [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) را برای کنترل فاصلهٔ پاراگراف ارائه می‌دهد. این ویژگی‌ها به‌صورت زیر استفاده می‌شوند:

* مقدار مثبت برای تعیین فاصلهٔ خطوط به‌صورت درصدی از ارتفاع خط.
* مقدار منفی برای تعیین فاصلهٔ خطوط به پوینت.

مثال زیر فاصلهٔ درون پاراگراف اول را به ۲۰۰٪ از ارتفاع خط (دو برابر) تنظیم می‌کند:

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

![فاصلهٔ خطوط درون پاراگراف](line_spacing.png)

## **کنترل شکست خطوط**

قوانین شکست خط پاراگراف در بلوک‌های متن باریک و ارائه‌هایی که متن لاتین و شرق آسیا را ترکیب می‌کنند، مفید هستند. متدهای زیر متعلق به [IParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/) هستند، بنابراین به کل پاراگراف اعمال می‌شوند:

- [setLatinLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) قوانین شکست خط لاتین را کنترل می‌کند. در متن ترکیبی، تغییر آن می‌تواند موقعیت پیچش متن و نقطه‌گذاری شرق آسیا را نیز تغییر دهد.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) قوانین شکست خط شرق آسیا را کنترل می‌کند، از جمله محدودیت‌های کاراکترهای ابتدای و انتهای خط.

این قوانین جایگزین [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) که پیچش خودکار را داخل یک قاب متن فعال می‌سازد، نمی‌شوند. آن‌ها بر چیدمان هنگام پیچش تأثیر می‌گذارند؛ کاراکترهای شکست خط را وارد نمی‌کنند. یک شکست خط صریح یک خط جدید درون پاراگراف ایجاد می‌کند بدون توجه به عرض موجود.

مثال خودمستقلی زیر یک بلوک متن باریک شامل متن چینی و لاتین ایجاد می‌کند. هر دو گزینهٔ شکست خط را به صراحت تنظیم کرده و «line_breaking.pptx» را ذخیره می‌کند. برای آزمایش هر یک از این قوانین، مقدار مربوطه را تغییر دهید در حالی که تنظیمات دیگر ثابت می‌مانند. مثال از Arial ۲۴ پوینت و SimSun با عرض قاب ۱۶۰ پوینت و حاشیهٔ افقی صفر استفاده می‌کند. [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) با [TextAutofitType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textautofittype/) فراخوانی می‌شود تا اندازهٔ متن و ابعاد قاب ثابت بمانند.

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

## **کنترل نقطه‌گذاری معلق**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) اجازه می‌دهد نقطه‌گذاری‌های واجد شرایط فراسوی لبهٔ راست خط متن ادامه یابد به جای اینکه در خط بعدی قرار گیرند. این تنظیم برای کل پاراگراف اعمال می‌شود و متفاوت از تورفتگی معلق است.

مثال خودمستقلی زیر نقطه‌گذاری معلق را در یک قاب متن ۱۰۰ پوینتی فعال می‌کند و «hanging_punctuation.pptx» را ذخیره می‌کند. با Arial ۲۴ پوینت و حاشیهٔ افقی صفر، نقطهٔ نهایی پس از «sentence» می‌ماند و فراتر از لبهٔ راست متن امتداد می‌یابد. برای مقایسه، ویژگی به [NullableBool.False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) تنظیم کنید: در این تنظیمات نقطه در خطی جداگانه قرار می‌گیرد. پیچش فعال و خودکار تنظیم اندازه غیرفعال‌اند تا عرض موجود ثابت بماند.

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

نه همهٔ علامت‌های نقطه‌گذاری می‌توانند معلق شوند. شرایط قلم و چیدمان توصیف‌شده در بخش [Control Line Breaking](#control-line-breaking) نیز برای این مقایسه اعمال می‌شود: تغییر قلم، عرض موجود، حاشیه‌ها یا تنظیمات خودکار تنظیم اندازه می‌تواند تفاوت قابل‌مشاهده را حذف کند.

## **تنظیم نوع خودکار تنظیم اندازه برای قاب‌های متن**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) تعیین می‌کند که متن هنگام تجاوز از مرزهای محفظهٔ خود چگونه رفتار کند. از آن برای کنترل این‌که آیا متن کوچک می‌شود، overflow می‌کند یا شکل به‌صورت خودکار اندازه‌اش را تغییر می‌دهد، استفاده کنید. مثال زیر شکل را طوری تنظیم می‌کند که برای متنش تغییر اندازه دهد و نتیجه را در «autofit_type.pptx» ذخیره می‌کند:

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

برای شمردن خطوط پس از پیچش خودکار و مشاهدهٔ چگونگی تغییر عرض متن یا شکل، به بخش [Count Rendered Lines](/slides/fa/java/manage-paragraph/) مراجعه کنید. شمارش خطوط به‌تنهایی نشان نمی‌دهد که متن از محفظه‌اش overflow می‌کند یا نه.

## **تنظیم لنگر قاب‌های متن**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) نحوهٔ موقعیت‌یابی عمودی متن داخل شکل را تعریف می‌کند، مثلاً در بالا، میانه یا پایین. مثال زیر متن را به پایین‌ترین شکل اولین شکل لنگر می‌کند و نتیجه را در «text_anchor.pptx» ذخیره می‌کند:

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

از [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) و [IParagraphFormat.getTabs](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getTabs--) برای پیکربندی موقعیت‌های تب در یک پاراگراف استفاده کنید. مثال زیر فاصلهٔ پیش‌فرض تب را به ۱۰۰ پوینت تنظیم کرده و یک تب چپ‌تراز در ۳۰ پوینت اضافه می‌کند. این تنظیمات بر متنی که شامل کاراکترهای تب است تأثیر می‌گذارد.

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

## **تنظیم زبان تصحیح‌نویس**

Aspose.Slides [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) را فراهم می‌کند که به شما امکان می‌دهد زبان تصحیح‌نویس برای یک قسمت متن را تنظیم کنید. زبان تصحیح‌نویس تعیین می‌کند که کدام زبان برای بررسی املایی و دستوری در PowerPoint استفاده شود.

مثال زیر به «presentation.pptx» با یک جعبهٔ متن به‌عنوان اولین شکل در اولین اسلاید و حداقل یک پاراگراف نیاز دارد. محتوای اولین پاراگراف را با «1。」» جایگزین می‌کند، SimSun را به عنوان قلم آن تنظیم می‌نماید و زبان تصحیح‌نویس چینی ساده (`zh-CN`) را اختصاص می‌دهد. نتیجه در «proofing_language.pptx» ذخیره می‌شود:

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

    // تنظیم شناسهٔ زبان تصحیح‌نویس.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **کپی متادیتای زبان**

هنگام کپی متن چندزبانه از یک قالب، هر دو [IBasePortionFormat.getLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getLanguageId--) و [IBasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getAlternativeLanguageId--) را حفظ کنید. مثال خودمستقلی زیر یک قسمت منبع با زبان انگلیسی ایالات‌متحده به‌عنوان زبان اصلی و فرانسوی به‌عنوان زبان جایگزین ایجاد می‌کند و متن و شناسه‌ها را به یک قسمت در ارائهٔ جدید کپی می‌نماید.

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

برای امتحان منبع بدون زبان جایگزین، تخصیص `"fr-FR"` را حذف کنید. در این صورت شناسهٔ جایگزین `null` می‌شود و همان دستور کپی عدم حضور آن را بدون ایجاد مقدار پیش‌فرض حفظ می‌کند، حتی اگر مقصد قبلاً زبان جایگزین داشته باشد.

این شناسه‌ها متادیتای زبان را ذخیره می‌کنند. حفظ آن‌ها تعیین نمی‌کند که PowerPoint کدام واژه‌نامه را برای بررسی املا یا دستور زبان انتخاب می‌کند.

## **تنظیم زبان پیش‌فرض**

از [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) برای تعریف زبان پیش‌فرض متنی که هنگام بارگذاری یا ایجاد یک ارائه ساخته می‌شود، استفاده کنید. مثال زیر ارائه‌ای با زبان پیش‌فرض متن انگلیسی ایالات‌متحده ایجاد کرده، یک جعبهٔ متن اضافه می‌کند و `en-US` را برای اولین قسمت متنش چاپ می‌کند.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // یک شکل مستطیل جدید با متن اضافه کنید.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // زبان اولین قسمت را بررسی کنید.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **تنظیم سبک متن پیش‌فرض**

برای اعمال قالب‌بندی پیش‌فرض متن در سطح ارائه، از [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--) استفاده کنید.

مثال زیر قلم ۱۴ پوینت بولد را به‌عنوان پیش‌فرض برای پاراگراف‌های سطح بالای یک ارائهٔ جدید تنظیم می‌کند و در «default_text_style.pptx» ذخیره می‌نماید. متن می‌تواند این پیش‌فرض‌ها را به ارث ببرد مگر اینکه قالب‌بندی خاص‌تری آنها را بازنویسی کند.

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

## **استخراج متن با اثر تمام حروف بزرگ (All‑Caps)**

در PowerPoint، اعمال اثر **All Caps** باعث می‌شود متن حتی اگر به‌صورت حروف کوچک وارد شده باشد، بر روی اسلاید به‌صورت حروف بزرگ نمایش داده شود. هنگام بازیابی چنین بخشی از متن با Aspose.Slides، کتابخانه متن را دقیقاً همان‌طور که وارد شده است برمی‌گرداند. برای مطابقت با متن نمایش داده‌شده، [TextCapType](https://reference.aspose.com/slides/java/com.aspose.slides/textcaptype/) را بررسی کنید و زمانی که مقدار `All` باشد، رشتهٔ بازگردانده‌شده را به حروف بزرگ تبدیل کنید.

این مثال به «sample2.pptx» با یک جعبهٔ متن به‌عنوان اولین شکل در اولین اسلاید نیاز دارد. اولین پاراگراف آن اولین قسمتش شامل «Hello, Aspose!» با اثر All Caps اعمال‌شده است، همان‌گونه که در زیر نشان داده شده است.

![اثر All Caps](all_caps_effect.png)

مثال کد زیر نشان می‌دهد چگونه متن را با اثر **All Caps** استخراج کنید:

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

**چگونه متن در یک جدول روی اسلاید را ویرایش کنم؟**

برای ویرایش متن در یک جدول روی اسلاید، از [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) استفاده کنید. سلول‌ها را پیمایش کنید و هر سلول را از طریق [ICell.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) و قالب‌بندی پاراگراف از طریق [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getParagraphFormat--) به‌روزرسانی نمایید.

**چگونه می‌توان رنگ گرادیان را به متن روی یک اسلاید پاورپوینت اعمال کرد؟**

برای اعمال رنگ گرادیان به متن، از [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) استفاده کنید. [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) را به [FillType.Gradient](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) تنظیم کنید و ایست‌های گرادیان، جهت و شفافیت را پیکربندی کنید.

قابلیت مرتبط: [Format text within slides](/slides/fa/features/text-formatting/).