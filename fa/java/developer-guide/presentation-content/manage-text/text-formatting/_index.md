---
title: قالب‌بندی متن ارائه در جاوا
linktitle: قالب‌بندی متن
type: docs
weight: 50
url: /fa/java/text-formatting/
keywords:
- متن برجسته
- عبارت منظم
- تراز پاراگراف
- استایل متن
- پس‌زمینه متن
- شفافیت متن
- فاصله‌گذاری کاراکتر
- ویژگی‌های قلم
- خانواده قلم
- چرخش متن
- زاویه چرخش
- قاب متن
- فاصله خطوط
- ویژگی خودتنظیم
- لنگر قاب متن
- تب‌بندی متن
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "قالب‌بندی و استایل‌دهی به متن در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Java. قلم‌ها، رنگ‌ها، ترازها و موارد دیگر را سفارشی کنید."
---
## **نمای کلی**

این مقاله نشان می‌دهد چگونه متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides for Java قالب‌بندی کنید. این مقاله شامل برجسته‌سازی، رنگ‌های پس‌زمینه، شفافیت، فاصله‌گذاری کاراکترها، ویژگی‌های قلم، چرخش، فاصله‌گذاری پاراگراف، رفتار خودتنظیم، لنگر قرارگیری متن، توقف‌های تب و تنظیمات زبان می‌باشد.

در مثال‌های زیر، از فایلی به نام «sample.pptx» استفاده خواهیم کرد که شامل یک جعبه متن در اسلاید اول با متن زیر است:

![متن نمونه](sample_text.png)

## **برجسته‌سازی متن**

برای برجسته‌سازی متنی که با الگوی خاصی در یک قاب متن مطابقت دارد، از متد [ITextFrame.highlightText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-) استفاده کنید. این متد رنگ برجسته را بر روی قطعات متن منطبق اعمال می‌کند و می‌تواند همراه با [TextSearchOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textsearchoptions/) برای کنترل نحوه جستجو، مثلاً برای مطابقت فقط با کلمات کامل، به‌کار رود.

مثال کد زیر تمام موارد حروف **"try"** را برجسته می‌کند و سپس فقط کلمه کامل **"to"** را برجسته می‌سازد.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // دریافت اولین شکل از اولین اسلاید.
    IAutoShape shape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // برجسته‌سازی کلمه "try" در شکل.
    shape.getTextFrame().highlightText("try", Color.LIGHT_GRAY);

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // برجسته‌سازی کلمه "to" در شکل.
    shape.getTextFrame().highlightText("to", Color.MAGENTA, searchOptions, null);

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![متن برجسته‌شده](highlighted_text.png)

## **برجسته‌سازی متن با استفاده از عبارات منظم**

متد [ITextFrame.highlightRegex](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) متن‌های مطابقت‌یافته توسط یک عبارت منظم را برجسته می‌کند. در Java، این API بر روی [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) موجود است.

مثال کد زیر تمام کلماتی را که شامل **هفت یا بیشتر کاراکتر** هستند، برجسته می‌کند:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape shape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    java.util.regex.Pattern regex = java.util.regex.Pattern.compile("\\b[^\\s]{7,}\\b");

    // برجسته‌سازی تمام کلماتی که دارای هفت یا بیشتر کاراکتر هستند.
    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, null);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![متن برجسته‌شده با استفاده از عبارت منظم](highlighted_text_using_regex.png)

## **تنظیم رنگ پس‌زمینه متن**

از [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) برای تنظیم رنگ برجسته پیش‌فرض برای یک پاراگراف استفاده کنید، یا برای بخش‌های متنی منفرد از [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) بهره ببرید.

کد زیر نشان می‌دهد چگونه رنگ پس‌زمینه را برای **تمام پاراگراف** تنظیم کنید:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // تنظیم رنگ برجسته برای کل پاراگراف.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![پاراگراف خاکستری](gray_paragraph.png)

کد زیر نشان می‌دهد چگونه رنگ پس‌زمینه را برای **قسمت‌های متنی با قلم بولد** تنظیم کنید:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // تنظیم رنگ برجسته برای بخش متنی.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![قسمت‌های متنی خاکستری](gray_text_portions.png)

## **تراز کردن پاراگراف‌های متن**

از [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) برای تنظیم تراز پاراگراف داخل یک قاب متن استفاده کنید. مقدار می‌تواند مرکزچین، چپ‌چین، راست‌چین، به‌صورت توجیه‌شده و ... باشد.

کد زیر نشان می‌دهد چگونه پاراگراف را به **مرکز** تراز کنید:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // تنظیم تراز پاراگراف به مرکز.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![پاراگراف تراز شده](aligned_paragraph.png)

## **تنظیم شفافیت برای متن**

شفافیت متن از طریق مؤلفه آلفای رنگی که به [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) اختصاص داده می‌شود، کنترل می‌شود. در مثال‌های زیر، `alpha = 50` مقدار کانال آلفای ARGB در مقیاس 0-255 است و نه درصد شفافیت.

کد زیر نشان می‌دهد چگونه شفافیت را برای **تمام پاراگراف** اعمال کنید:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // تنظیم رنگ پر کردن متن به رنگ شفاف.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![پاراگراف شفاف](transparent_paragraph.png)

کد زیر نشان می‌دهد چگونه شفافیت را برای **قسمت‌های متنی با قلم بولد** اعمال کنید:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // تنظیم شفافیت بخش متنی.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![قسمت‌های متنی شفاف](transparent_text_portions.png)

## **تنظیم فاصله کاراکترها برای متن**

از [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) برای گسترش یا فشرده‌سازی فاصله بین کاراکترها در یک جعبه متن استفاده کنید.

کد Java زیر نشان می‌دهد چگونه فاصله کاراکترها را در **تمام پاراگراف** گسترش دهید:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // توجه: برای فشردن فاصله کاراکتر از مقادیر منفی استفاده کنید.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // گسترش فاصله کاراکتر.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![فاصله کاراکترها در پاراگراف](character_spacing_in_paragraph.png)

مثال کد زیر نشان می‌دهد چگونه فاصله کاراکترها را در **قسمت‌های متنی با قلم بولد** گسترش دهید:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // توجه: برای فشردن فاصله کاراکتر از مقادیر منفی استفاده کنید.
            portion.getPortionFormat().setSpacing(3); // گسترش فاصله کاراکتر.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![فاصله کاراکترها در قسمت‌های متنی](character_spacing_in_text_portions.png)

### **غیرفعال‌سازی کرنینگ برای قلم‌های خاص**

در برخی موارد، متنی که توسط Aspose.Slides رندر می‌شود، ممکن است کمی فشرده‌تر از همان متن در PowerPoint به‌نظر برسد. این می‌تواند به این دلیل باشد که PowerPoint داده‌های کرنینگ را برای برخی قلم‌ها نادیده می‌گیرد، حتی اگر قلم حاوی اطلاعات کرنینگ معتبر باشد و کرنینگ در تنظیمات PowerPoint فعال باشد.

برای نزدیک‌تر شدن خروجی رندر شده به PowerPoint در این موارد، می‌توانید کرنینگ را برای قسمت‌های متنی که از قلم مورد تأثیر استفاده می‌کنند، غیرفعال کنید. مقدار [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) را به مقداری به‌مرات بزرگ‌تر از اندازه واقعی قلم تنظیم کنید:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormat portionFormat = portion.getPortionFormat();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portionFormat.setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

این تنظیم مانع اعمال کرنینگ بر روی قسمت‌های متنی منطبق می‌شود و می‌تواند به هم‌راستای‌سازی رندر Aspose.Slides با خروجی بصری PowerPoint برای قلم‌های تحت تأثیر این رفتار خاص PowerPoint کمک کند.

## **مدیریت ویژگی‌های قلم متن**

ویژگی‌های قلم می‌تواند در سطح پاراگراف از طریق [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) یا در قسمت‌های منفرد از طریق [IPortionFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iportionformat/) تنظیم شود.

کد زیر قلم و سبک متن را برای تمام پاراگراف تنظیم می‌کند: اندازه قلم، بولد، ایتالیک، زیرخط نقطه‌دار و قلم Times New Roman را برای تمام قسمت‌های پاراگراف اعمال می‌کند:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

![ویژگی‌های قلم برای پاراگراف](font_properties_for_paragraph.png)

مثال کد زیر ویژگی‌های مشابه را برای **قسمت‌های متنی با قلم بولد** اعمال می‌کند:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // تنظیم ویژگی‌های قلم برای بخش متنی.
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

![ویژگی‌های قلم برای قسمت‌های متنی](font_properties_for_text_portions.png)

## **تنظیم چرخش متن**

از [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) برای تنظیم جهت از پیش تعریف‌شده متن داخل یک شکل استفاده کنید.

کد زیر جهت متن را در شکل به `Vertical270` تنظیم می‌کند که متن را **۹۰ درجه پادساعت‌گرد** می‌چرخاند:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![چرخش متن](text_rotation.png)

## **تنظیم چرخش سفارشی برای قاب‌های متنی**

از [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) برای تنظیم زاویه چرخش سفارشی برای یک [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) استفاده کنید.

کد زیر قاب متن را داخل شکل به میزان ۳ درجه ساعتگرد می‌چرخاند:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![چرخش سفارشی متن](custom_text_rotation.png)

## **تنظیم فاصله خطوط پاراگراف‌ها**

Aspose.Slides متدهای [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-), و [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) را برای کنترل فاصله پاراگراف‌ها فراهم می‌کند. این ویژگی‌ها به‌صورت زیر استفاده می‌شوند:

* از مقدار مثبت برای تعیین فاصله خط به‌عنوان درصدی از ارتفاع خط استفاده کنید.
* از مقدار منفی برای تعیین فاصله خط بر حسب نقاط (points) استفاده کنید.

کد زیر نشان می‌دهد چگونه فاصله خطوط را داخل پاراگراف مشخص کنید:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![فاصله خطوط داخل پاراگراف](line_spacing.png)

## **تنظیم نوع خودتنظیم برای قاب‌های متنی**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) تعیین می‌کند که متن هنگام تجاوز از مرزهای کانتینر خود چگونه رفتار کند. از آن برای کنترل اینکه متن کوچکتر شود، سرریز کند یا به‌صورت خودکار شکل را تغییر اندازه دهد، استفاده کنید.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم لنگر قاب‌های متنی**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) نحوه موقعیت‌یابی متن به‌صورت عمودی داخل یک شکل را تعریف می‌کند، به‌عنوان مثال در بالا، وسط یا پایین.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم تب‌بندی متن**

از [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) و [IParagraphFormat.getTabs](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#getTabs--) برای پیکربندی توقف‌های تب در یک پاراگراف استفاده کنید.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left);

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![تب‌های پاراگراف](paragraph_tabs.png)

## **تنظیم زبان بررسی‌کننده**

Aspose.Slides متد [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) را فراهم می‌کند که به شما امکان تنظیم زبان بررسی برای یک بخش متنی را می‌دهد. زبان بررسی، زبان مورد استفاده برای بررسی املاء و گرامر در PowerPoint را تعیین می‌کند.

کد زیر نشان می‌دهد چگونه زبان بررسی را برای یک بخش متنی تنظیم کنید:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // تنظیم شناسه زبان بررسی.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1.");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم زبان پیش‌فرض**

از [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) برای تعریف زبان پیش‌فرض متن‌های ایجاد شده هنگام بارگذاری یا ساخت یک ارائه استفاده کنید.

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

## **تنظیم سبک متن پیش‌فرض**

برای اعمال قالب‌بندی متن پیش‌فرض در سطح ارائه، از [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--) استفاده کنید.

کد زیر نشان می‌دهد چگونه یک قلم پیش‌فرض بولد با اندازه ۱۴ پوینت برای تمام متن‌ها در تمام اسلایدهای یک ارائه جدید تنظیم شود.

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

## **استخراج متن با اثر تمامی حروف بزرگ**

در PowerPoint، اعمال اثر فونت **All Caps** باعث می‌شود متن روی اسلاید به حروف بزرگ نمایش داده شود حتی اگر به‌صورت حروف کوچک تایپ شده باشد. وقتی چنین بخشی از متن را با Aspose.Slides بازیابی می‌کنید، کتابخانه متن را دقیقاً همان‌گونه که وارد شده است برمی‌گرداند. برای هم‌خوانی با متن نمایش داده‌شده، [TextCapType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textcaptype/) را بررسی کنید و وقتی مقدار `All` است، رشته برگشتی را به حروف بزرگ تبدیل کنید.

فرض کنید در اسلاید اول فایل sample2.pptx یک جعبه متن زیر داریم.

![اثر All Caps](all_caps_effect.png)

کد زیر نشان می‌دهد چگونه متنی را که اثر **All Caps** روی آن اعمال شده است استخراج کنیم:

```java
Presentation presentation = new Presentation("sample2.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **پرسش‌های متداول**

**چگونه متن در یک جدول در اسلاید را ویرایش کنیم؟**

برای ویرایش متن در یک جدول در اسلاید، از [ITable](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itable/) استفاده کنید. سلول‌ها را پیمایش کنید و هر سلول را از طریق [ICell.getTextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icell/#getTextFrame--) و قالب‌بندی پاراگراف‌ها از طریق [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraph/#getParagraphFormat--) به‌روز کنید.

**چگونه رنگ گرادیان به متن در یک اسلاید PowerPoint اعمال کنیم؟**

برای اعمال رنگ گرادیان به متن، از [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) استفاده کنید. [IFillFormat.setFillType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifillformat/#setFillType-byte-) را به [FillType.Gradient](https://reference.aspose.com/slides/fa/java/com.aspose.slides/filltype/) تنظیم کنید و نقاط گرادیان، جهت و شفافیت را پیکربندی کنید.