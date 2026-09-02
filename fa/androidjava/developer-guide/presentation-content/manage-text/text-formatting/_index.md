---
title: قالب‌بندی متن ارائه در اندروید
linktitle: قالب‌بندی متن
type: docs
weight: 50
url: /fa/androidjava/text-formatting/
keywords:
- تراز پاراگراف
- استایل متن
- پس‌زمینه متن
- شفافیت متن
- فاصله کاراکتر
- ویژگی‌های فونت
- خانواده فونت
- چرخش متن
- زاویه چرخش
- قاب متن
- فاصله خط
- ویژگی Autofit
- لنگر قاب متن
- تب‌بندی متن
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "قالب‌بندی و استایل‌دهی متن در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای اندروید از طریق Java. سفارشی‌سازی فونت‌ها، رنگ‌ها، تراز و موارد دیگر."
---
## **نمای کلی**

این مقاله نحوه قالب‌بندی متن در ارائه‌های PowerPoint و OpenDocument را با استفاده از Aspose.Slides for Android از طریق Java نشان می‌دهد. مواردی از رنگ پس‌زمینه، شفافیت، فاصله‌گذاری کاراکترها، ویژگی‌های فونت، چرخش، فاصله‌گذاری پاراگراف، رفتار Autofit، لنگر متن، ایستای تب و تنظیمات زبان پوشش داده می‌شود.

در مثال‌های زیر، از فایلی به نام **"sample.pptx"** استفاده می‌کنیم که یک جعبه متن در اسلاید اول دارد و متن زیر را شامل می‌شود:

![نمونه متن](sample_text.png)

برای یافتن و برجسته‌سازی متن به صورت دقیق یا تطابق با عبارات منظم، رجوع کنید به [جستجو و جایگزینی متن](/slides/fa/androidjava/search-and-replace-text/).

## **تنظیم رنگ پس‌زمینه متن**

از [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) برای تعیین رنگ برجسته‌سازی پیش‌فرض یک پاراگراف استفاده کنید یا از [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) برای قسمت‌های متنی جداگانه.

کد زیر نشان می‌دهد چگونه رنگ پس‌زمینه **تمام پاراگراف** را تنظیم کنید:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

کد زیر نحوه تنظیم رنگ پس‌زمینه برای **بخش‌های متنی با فونت بولد** را نشان می‌دهد:

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
            // تنظیم رنگ برجسته برای بخش متنی.
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

## **تراز کردن پاراگراف‌های متنی**

از [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) برای تنظیم تراز پاراگراف داخل چارچوب متن استفاده کنید. مقدار می‌تواند centered، left-aligned، right-aligned، justified و ... باشد.

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

## **تنظیم شفافیت برای متن**

شفافیت متن از طریق مؤلفه آلفای رنگی که به [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) اختصاص داده می‌شود، کنترل می‌گردد. در مثال‌های زیر، `alpha = 50` مقدار آلفای ARGB در مقیاس 0–255 است، نه درصد شفافیت.

کد زیر نشان می‌دهد چگونه شفافیت را برای **تمام پاراگراف** اعمال کنید:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // تنظیم رنگ پر کردن متن به رنگ شفاف.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![پاراگراف شفاف](transparent_paragraph.png)

کد زیر نشان می‌دهد چگونه شفافیت را برای **بخش‌های متنی با فونت بولد** اعمال کنید:

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
            // تنظیم شفافیت بخش متنی.
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

## **تنظیم فاصله کاراکتر برای متن**

از [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) برای افزایش یا کاهش فاصله بین کاراکترها در یک جعبه متن استفاده کنید.

کد جاوا زیر نشان می‌دهد چگونه فاصله کاراکترها را در **تمام پاراگراف** گسترش دهید:

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

![فاصله کاراکتر در پاراگراف](character_spacing_in_paragraph.png)

کد زیر نشان می‌دهد چگونه فاصله کاراکترها را در **بخش‌های متنی با فونت بولد** گسترش دهید:

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

![فاصله کاراکتر در بخش‌های متنی](character_spacing_in_text_portions.png)

### **غیرفعال کردن کرنینگ برای فونت‌های خاص**

در برخی موارد، متن رندر شده توسط Aspose.Slides ممکن است نسبت به همان متن در PowerPoint کمی فشرده به‌نظر برسد. این می‌تواند به این دلیل باشد که PowerPoint داده‌های کرنینگ را برای برخی فونت‌ها نادیده می‌گیرد، حتی اگر فونت دارای اطلاعات کرنینگ معتبر باشد و در تنظیمات PowerPoint کرنینگ فعال باشد.

برای نزدیک‌تر شدن خروجی رندر شده به نمایش PowerPoint، می‌توانید کرنینگ را برای بخش‌های متنی که از فونت مورد نظر استفاده می‌کنند، غیرفعال کنید. مقدار [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) را به مقداری به‌مراتب بزرگتر از اندازه واقعی فونت تنظیم کنید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

این تنظیم مانع اعمال کرنینگ بر روی بخش‌های متنی مطابق می‌شود و می‌تواند به هم‌راستایی رندر Aspose.Slides با خروجی تصویری PowerPoint برای فونت‌های تحت تاثیر این رفتار مخصوص PowerPoint کمک کند.

## **مدیریت ویژگی‌های فونت متن**

ویژگی‌های فونت می‌توانند در سطح پاراگراف از طریق [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) یا در سطح بخش‌های جداگانه از طریق [IPortionFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iportionformat/) تنظیم شوند.

کد زیر فونت و سبک متن را برای **تمام پاراگراف** تنظیم می‌کند: اندازه فونت، بولد، ایتالیک، زیرخط نقطه‌دار و فونت Times New Roman را برای تمام بخش‌های پاراگراف اعمال می‌سازد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // تنظیم ویژگی‌های فونت برای پاراگراف.
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

![ویژگی‌های فونت برای پاراگراف](font_properties_for_paragraph.png)

کد زیر ویژگی‌های مشابهی را برای **بخش‌های متنی با فونت بولد** اعمال می‌کند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // تنظیم ویژگی‌های فونت برای بخش متنی.
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

![ویژگی‌های فونت برای بخش‌های متنی](font_properties_for_text_portions.png)

## **تنظیم چرخش متن**

از [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) برای تعیین جهت پیش‌فرض متن درون یک شکل استفاده کنید.

کد زیر جهت متن در شکل را به [TextVerticalType.Vertical270](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textverticaltype/) تنظیم می‌کند که متن را **۹۰ درجه به سمت پادساعتگرد** می‌چرخاند:

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

## **تنظیم چرخش سفارشی برای فریم‌های متنی**

از [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) برای تنظیم زاویه چرخش دلخواه یک [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) استفاده کنید.

کد زیر فریم متن را به میزان ۳ درجه به سمت ساعت درون شکل می‌چرخاند:

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

## **تنظیم فاصله خط پاراگراف‌ها**

Aspose.Slides امکانات زیر را برای کنترل فاصله پاراگراف فراهم می‌کند: [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-)، [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) و [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-). این ویژگی‌ها به صورت زیر استفاده می‌شوند:

* برای مشخص کردن فاصله خط به صورت درصدی از ارتفاع خط، از مقدار مثبت استفاده کنید.
* برای تعیین فاصله خط به نقطه، از مقدار منفی استفاده کنید.

کد زیر نشان می‌دهد چگونه فاصله خط را درون پاراگراف تعیین کنید:

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

![فاصله خط درون پاراگراف](line_spacing.png)

## **تنظیم نوع Autofit برای فریم‌های متنی**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) تعیین می‌کند که متن چه رفتارهایی داشته باشد وقتی از مرزهای ظرف خود فراتر می‌رود. از آن برای کنترل اینکه متن کوچک شود، overflow کند یا شکل را به‌صورت خودکار تغییر اندازه دهد، استفاده کنید.

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

## **تنظیم لنگر فریم‌های متنی**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) مشخص می‌کند متن به صورت عمودی درون شکل چگونه موقعیت یابد؛ به‌عنوان مثال در بالا، وسط یا پایین.

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

از [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) و [IParagraphFormat.getTabs](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) برای پیکربندی ایستای تب در یک پاراگراف استفاده کنید.

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

## **تنظیم زبان اصلاح املایی**

Aspose.Slides متد [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) را فراهم می‌کند که امکان تنظیم زبان اصلاح املایی برای یک بخش متنی را می‌دهد. این زبان تعیین می‌کند که بررسی‌های املا و گرامر در PowerPoint به چه زبانی انجام شود.

کد زیر نحوه تنظیم زبان اصلاح املایی برای یک بخش متنی را نشان می‌دهد:

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

    // تنظیم شناسه زبان اصلاحی.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم زبان پیش‌فرض**

از [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) برای تعریف زبان پیش‌فرض متنی که هنگام بارگذاری یا ایجاد یک ارائه ایجاد می‌شود، استفاده کنید.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // افزودن یک شکل مستطیل جدید با متن.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // بررسی زبان اولین بخش متن.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **تنظیم سبک متن پیش‌فرض**

برای اعمال قالب‌بندی متن پیش‌فرض در سطح ارائه، از [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--) استفاده کنید.

کد زیر نشان می‌دهد چگونه یک فونت بولد پیش‌فرض با اندازه ۱۴ پوینت برای تمام متن‌های اسلایدها در یک ارائه جدید تنظیم شود.

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

در PowerPoint، اعمال اثر **All Caps** باعث می‌شود متن روی اسلاید به صورت حروف بزرگ نمایش داده شود حتی اگر در اصل با حروف کوچک وارد شده باشد. زمانی که چنین بخشی از متن را با Aspose.Slides بازیابی می‌کنید، کتابخانه متن را دقیقاً همان‌گونه که وارد شده است برمی‌گرداند. برای هم‌خوانی با متنی که نمایش داده می‌شود، رشته بازگشتی را به حروف بزرگ تبدیل کنید وقتی مقدار آن [TextCapType.All](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textcaptype/) باشد.

فرض کنیم جعبه متن زیر در اسلاید اول فایل **sample2.pptx** وجود دارد:

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

**چگونه متن در جدول یک اسلاید را ویرایش کنیم؟**

برای ویرایش متن در جدول یک اسلاید، از [ITable](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itable/) استفاده کنید. سلول‌ها را مرور کنید و هر سلول را از طریق [ICell.getTextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icell/#getTextFrame--) و قالب‌بندی پاراگراف از طریق [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) به‌روزرسانی کنید.

**چگونه رنگ گرادیان را بر متن در اسلاید PowerPoint اعمال کنیم؟**

برای اعمال رنگ گرادیان به متن، از [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) استفاده کنید. [IFillFormat.setFillType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) را به [FillType.Gradient](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/filltype/) تنظیم کنید و ایستای گرادیان، جهت و شفافیت را پیکربندی کنید.