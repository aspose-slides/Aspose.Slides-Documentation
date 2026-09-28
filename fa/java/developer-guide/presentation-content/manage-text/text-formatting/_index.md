---
title: قالب‌بندی متن ارائه در جاوا
linktitle: قالب‌بندی متن
type: docs
weight: 50
url: /fa/java/text-formatting/
keywords:
- هم‌ترازی پاراگراف
- سبک متن
- پس‌زمینه متن
- شفافیت متن
- فاصله بین کاراکترها
- ویژگی‌های قلم
- خانواده قلم
- چرخش متن
- زاویه چرخش
- قاب متن
- فاصله خطوط
- ویژگی خودسازگاری
- لنگر قاب متن
- تب‌بندی متن
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای جاوا قالب‌بندی و استایل می‌کنید. قلم‌ها، رنگ‌ها، تراز و موارد دیگر را سفارشی کنید."
---
## **بررسی کلی**

این مقاله نشان می‌دهد چگونه متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Java قالب‌بندی کنید. این مقاله رنگ‌های پس‌زمینه، شفافیت، فاصله بین کاراکترها، ویژگی‌های قلم، چرخش، فاصله پاراگراف، رفتار autofit، تنظیم موقعیت متن، توقف‌های تب و تنظیمات زبان را پوشش می‌دهد.

مگر اینکه خلاف آن ذکر شود، مثال‌ها از [sample.pptx](sample.pptx) استفاده می‌کنند. اولین شکل در اولین اسلاید یک جعبه متن است و اولین پاراگراف آن شامل متنی است که در زیر نشان داده شده است. هر دو شاخص اسلاید و شکل بر پایه صفر هستند. مثال‌هایی که بخش‌های بولد را انتخاب می‌کنند از قالب‌بندی مؤثر، از جمله قالب‌بندی بولد ارث‌برده استفاده می‌کنند:

![متن نمونه](sample_text.png)

برای یافتن و برجسته‌کردن متن لغوی یا مطابقت‌های عبارات منظم، به [Search and Replace Text](/slides/fa/java/search-and-replace-text/) مراجعه کنید.

## **تنظیم رنگ پس‌زمینه متن**

از [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) برای تنظیم رنگ برجسته پیش‌فرض یک پاراگراف استفاده کنید، یا برای بخش‌های متنی جداگانه از [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) استفاده کنید.

مثال زیر برجسته‌ای خاکستری روشن را به‌عنوان پیش‌فرض برای اولین پاراگراف تنظیم می‌کند. رنگ‌های برجسته صریح در بخش‌های جداگانه بر این پیش‌فرض اولویت دارند:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // رنگ برجسته را برای تمام پاراگراف تنظیم کنید.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![پاراگراف خاکستری](gray_paragraph.png)

مثال کد زیر نشان می‌دهد چگونه رنگ پس‌زمینه را برای **بخش‌های متنی با قلم بولد** تنظیم کنیم:

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
            // رنگ برجسته را برای بخش متن تنظیم کنید.
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

از [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) برای تنظیم تراز پاراگراف درون یک فریم متنی استفاده کنید. مقدار می‌تواند وسط‌چین، چپ‌چین، راست‌چین، توجیه‌شده و غیره باشد.

مثال کد زیر نشان می‌دهد چگونه پاراگراف را به **مرکز** تراز کنیم:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // ترازبندی پاراگراف را به مرکز تنظیم کنید.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![پاراگراف تراز شده](aligned_paragraph.png)

## **تنظیم شفافیت برای متن**

شفافیت متن از طریق مؤلفه آلفای رنگی که به [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) اختصاص داده شده، کنترل می‌شود. در مثال‌های زیر، `alpha = 50` مقدار کانال آلفای ARGB در مقیاس 0–255 است، نه درصد شفافیت.

مثال کد زیر نشان می‌دهد چگونه شفافیت را به **تمام پاراگراف** اعمال کنیم:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // رنگ پرکننده متن را به رنگ شفاف تنظیم کنید.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![پاراگراف شفاف](transparent_paragraph.png)

مثال کد زیر نشان می‌دهد چگونه شفافیت را به **بخش‌های متنی با قلم بولد** اعمال کنیم:

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
            // شفافیت بخش متن را تنظیم کنید.
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

## **تنظیم فاصله کاراکتر برای متن**

از [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) برای افزایش یا کاهش فاصله بین کاراکترها در یک جعبه متن استفاده کنید. مثال‌ها 3 پوینت فاصله اضافه می‌کند؛ مقادیر منفی متن را فشرده می‌کند.

کد جاوا زیر نشان می‌دهد چگونه فاصله کاراکتر را در **تمام پاراگراف** گسترش دهیم:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // توجه: برای فشرده‌کردن فاصله بین کاراکترها از مقادیر منفی استفاده کنید.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // فاصله کاراکترها را افزایش دهید.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![فاصله کاراکتر در پاراگراف](character_spacing_in_paragraph.png)

مثال کد زیر نشان می‌دهد چگونه فاصله کاراکتر را در **بخش‌های متنی با قلم بولد** گسترش دهیم:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // نکته: برای فشرده‌کردن فاصله بین کاراکترها از مقادیر منفی استفاده کنید.
            portion.getPortionFormat().setSpacing(3); // فاصله کاراکترها را افزایش دهید.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![فاصله کاراکتر در بخش‌های متن](character_spacing_in_text_portions.png)

### **غیرفعال کردن کرنینگ برای فونت‌های خاص**

در برخی موارد، متنی که توسط Aspose.Slides رندر می‌شود ممکن است کمی فشرده‌تر از همان متنی که در PowerPoint نمایش داده می‌شود، به نظر برسد. این می‌تواند به این دلیل باشد که PowerPoint داده‌های کرنینگ برای برخی فونت‌ها را نادیده می‌گیرد، حتی اگر فونت حاوی اطلاعات کرنینگ معتبر باشد و کرنینگ در تنظیمات PowerPoint فعال باشد.

برای نزدیک‌تر کردن خروجی رندر به PowerPoint در چنین مواردی، می‌توانید کرنینگ را برای بخش‌های متنی که از فونت مورد نظر استفاده می‌کنند غیرفعال کنید. مقدار [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) را به مقداری بزرگتر از اندازه واقعی فونت تنظیم کنید. این مثال به «presentation.pptx» با یک جعبه متن به‌عنوان اولین شکل در اولین اسلاید نیاز دارد. نام‌های قلم مؤثر شامل قلم‌های ارث‌برده بررسی می‌شوند و آستانه 100 پوینت برای بخش‌هایی که از Roboto استفاده می‌کنند تنظیم می‌شود؛ این کار کرنینگ را برای بخش‌های مطابق با اندازه قلم زیر 100 پوینت غیرفعال می‌کند:

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

برای متنی که زیر آستانه باشد، این تنظیم از کرنینگ جلوگیری می‌کند و می‌تواند به تطابق رندر Aspose.Slides با خروجی بصری PowerPoint برای فونت‌های تحت تأثیر این رفتار ویژه PowerPoint کمک کند.

## **مدیریت ویژگی‌های قلم متن**

ویژگی‌های قلم می‌توانند در سطح پاراگراف از طریق [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) یا بر روی بخش‌های جداگانه از طریق [IPortionFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iportionformat/) تنظیم شوند.

مثال زیر قلم پیش‌فرض اولین پاراگراف را به 12 پوینت Times New Roman با قالب‌بندی بولد، ایتالیک و زیرخط نقطه‌دار تنظیم می‌کند. قالب‌بندی صریح بر بخش‌های جداگانه بر این پیش‌فرض‌ها اولویت دارد:

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

مثال زیر 13 پوینت Times New Roman، قالب‌ایتالیک و زیرخط نقطه‌دار را به بخش‌هایی که قالب‌بندی مؤثر آن‌ها بولد است، اعمال می‌کند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // ویژگی‌های قلم را برای بخش متنی تنظیم کنید.
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

از [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) برای تنظیم جهت‌گیری از پیش تعریف‌شده متن درون یک شکل استفاده کنید.

مثال کد زیر جهت‌گیری متن را در شکل به [TextVerticalType.Vertical270](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textverticaltype/) تنظیم می‌کند که متن را **90 درجه خلاف ساعت‌گرد** می‌چرخاند:

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

## **تنظیم چرخش سفارشی برای فریم‌های متن**

از [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) برای تنظیم زاویه چرخش سفارشی برای یک [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) استفاده کنید.

مثال کد زیر فریم متن را داخل شکل به میزان 3 درجه ساعت‌گرد می‌چرخاند:

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

Aspose.Slides [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-)، [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) و [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) را برای کنترل فاصله پاراگراف فراهم می‌کند. این ویژگی‌ها به‌صورت زیر استفاده می‌شوند:

* مقدار مثبت برای تعیین فاصله خط به‌عنوان درصدی از ارتفاع خط استفاده شود.
* مقدار منفی برای تعیین فاصله خط به‌واحد پوینت استفاده شود.

مثال زیر فاصله داخل اولین پاراگراف را به 200٪ از ارتفاع خط (فاصله دوتایی) تنظیم می‌کند:

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

![فاصله خط در پاراگراف](line_spacing.png)

## **کنترل شکستن خط**

قواعد شکستن خط پاراگراف در بلوک‌های متنی باریک و ارائه‌هایی که متن لاتین و شرق آسیا را ترکیب می‌کنند مفید است. روش‌های زیر متعلق به [IParagraphFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/) هستند، بنابراین بر کل پاراگراف اعمال می‌شوند:

- [setLatinLineBreak](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) قواعد شکستن خط لاتین را کنترل می‌کند. در متن ترکیبی، تغییر آن می‌تواند مکان بسته شدن متن شرق آسیا و علائم نگارشی مجاور را نیز تغییر دهد.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) قواعد شکستن خط شرق آسیا را کنترل می‌کند، از جمله محدودیت‌های کاراکتر در ابتدا و انتهای خط.

این قواعد جایگزین [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) نمی‌شوند؛ این متد بسته شدن خودکار درون یک فریم متنی را فعال می‌کند. این قواعد بر زمانی که بسته شدن رخ می‌دهد، تأثیر می‌گذارند؛ آن‌ها کاراکترهای شکستن خط را وارد نمی‌کنند. یک شکست خط صریح یک خط جدید درون پاراگراف ایجاد می‌کند که مستقل از عرض در دسترس است.

مثال خودکفا زیر یک بلوک متنی باریک شامل چینی و لاتین ایجاد می‌کند. هر دو گزینه شکستن خط به‌صورت صریح تنظیم می‌شوند و «line_breaking.pptx» ذخیره می‌شود. برای آزمایش هر یک از قواعد، مقدار مربوطه را تغییر دهید در حالی که تنظیمات دیگر ثابت بمانند. مثال از 24 پوینت Arial و SimSun با عرض فریم 160 پوینت و حاشیه افقی صفر استفاده می‌کند. [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) با [TextAutofitType.None](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textautofittype/) فراخوانی می‌شود تا اندازه متن و ابعاد فریم ثابت بمانند.

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

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) به علائم نگارشی واجد شرایط اجازه می‌دهد تا فراتر از لبه راست خط متن امتداد یابند به‌جای اینکه در خط بعدی قرار گیرند. این ویژگی به کل پاراگراف اعمال می‌شود و متفاوت از تورفتگی معلق است.

مثال خودکفا زیر نقطه‌گذاری معلق را در یک فریم متن با عرض 100 پوینت فعال می‌کند و «hanging_punctuation.pptx» ذخیره می‌کند. با 24 پوینت Arial و حاشیه افقی صفر، نقطه نهایی بعد از «sentence» می‌ماند و بیش از لبه راست متن امتداد می‌یابد. برای مقایسه مقدار را به [NullableBool.False](https://reference.aspose.com/slides/fa/java/com.aspose.slides/nullablebool/) تنظیم کنید: با این تنظیمات، نقطه یک خط جداگانه اشغال می‌کند. بسته شدن فعال و autofit غیرفعال است تا عرض در دسترس ثابت بماند.

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

همهٔ علائم نگارشی نمی‌توانند معلق شوند. نتیجهٔ قابل مشاهده به در دسترس بودن قلم و طرح‌بندی بستگی دارد: تغییر قلم، عرض در دسترس، حاشیه‌ها یا تنظیمات autofit می‌تواند اختلاف قابل مشاهده را حذف کند.

## **تنظیم نوع Autofit برای فریم‌های متن**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) تعیین می‌کند متن هنگام عبور از مرزهای محفظهٔ خود چگونه رفتار کند. از آن برای کنترل اینکه متن کوچک شود، بیرون بزند یا به‌صورت خودکار شکل را تغییر اندازه دهد استفاده کنید. مثال زیر شکل را برای متناسب شدن با متن تغییر اندازه می‌دهد و نتیجه را در «autofit_type.pptx» ذخیره می‌کند.

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

برای شمارش خطوط پس از بسته شدن خودکار و مشاهدهٔ نحوهٔ تغییر عرض متن یا شکل، به [Count Rendered Lines](/slides/fa/java/manage-paragraph/) مراجعه کنید. شمارش خطوط به تنهایی نشان نمی‌دهد که متن از محفظهٔ خود عبور کرده است یا نه.

## **تنظیم لنگر فریم‌های متن**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) تعیین می‌کند متن به‌صورت عمودی در داخل یک شکل چگونه موقعیت‌گیری کند، به‌عنوان مثال در بالا، وسط یا پایین. مثال زیر متن را به پایین اولین شکل لنگر می‌کند و نتیجه را در «text_anchor.pptx» ذخیره می‌کند.

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

## **تنظیم تب‌بندی متن**

از [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) و [IParagraphFormat.getTabs](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#getTabs--) برای پیکربندی توقف‌های تب در یک پاراگراف استفاده کنید. مثال زیر فاصله پیش‌فرض تب را به 100 پوینت تنظیم می‌کند و یک توقف تب چپ‌چین را در 30 پوینت اضافه می‌کند. این تنظیمات بر متنی که شامل کاراکترهای تب باشد تأثیر می‌گذارد.

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

Aspose.Slides متد [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) را فراهم می‌کند که به شما اجازه می‌دهد زبان proofing را برای یک بخش متنی تنظیم کنید. زبان proofing زبان مورد استفاده برای بررسی املا و گرامر در PowerPoint را تعیین می‌کند.

مثال زیر به «presentation.pptx» با یک جعبه متن به‌عنوان اولین شکل در اولین اسلاید و حداقل یک پاراگراف نیاز دارد. محتوای اولین پاراگراف را به «1。» تغییر می‌دهد، فونت آن را به SimSun تنظیم می‌کند و زبان proofing چینی ساده (`zh-CN`) را اختصاص می‌دهد. نتیجه در «proofing_language.pptx» ذخیره می‌شود:

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

## **تنظیم زبان پیش‌فرض**

از [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) برای تعریف زبان پیش‌فرض متنی که در حین بارگذاری یا ایجاد یک ارائه ایجاد می‌شود، استفاده کنید. مثال زیر یک ارائه با زبان متنی انگلیسی آمریکا به‌عنوان پیش‌فرض ایجاد می‌کند، یک جعبه متن اضافه می‌کند و برای اولین بخش متنی آن `en-US` چاپ می‌کند.

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

    // زبان اولین بخش را بررسی کنید.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **تنظیم سبک متن پیش‌فرض**

برای اعمال قالب‌بندی پیش‌فرض متن در سطح ارائه، از [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--) استفاده کنید.

مثال زیر قلم بولد 14 پوینت را به‌عنوان پیش‌فرض برای پاراگراف‌های سطح بالای یک ارائهٔ جدید تنظیم می‌کند و در «default_text_style.pptx» ذخیره می‌شود. متن می‌تواند این پیش‌فرض‌ها را به ارث ببرد مگر این که قالب‌بندی خاص‌تری آنها را بازنویسی کند.

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

## **استخراج متن با اثر تمام‌حروف بزرگ**

در PowerPoint، اعمال اثر **All Caps** به قلم باعث می‌شود متن حتی اگر به حروف کوچک وارد شده باشد، روی اسلاید به صورت حروف بزرگ نمایش داده شود. هنگامی که چنین بخشی از متن را با Aspose.Slides استخراج می‌کنید، کتابخانه متن را دقیقاً به همان شکلی که وارد شده برمی‌گرداند. برای هم‌خوانی با متن نمایشی، [TextCapType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textcaptype/) را بررسی کنید و زمانی که مقدار `All` باشد، رشتهٔ بازگشتی را به حروف بزرگ تبدیل کنید.

مثال زیر به «sample2.pptx» با یک جعبه متن به‌عنوان اولین شکل در اولین اسلاید نیاز دارد. اولین پاراگراف آن اولین بخش متن «Hello, Aspose!» را دارد که اثر All Caps روی آن اعمال شده است، همان‌طور که در زیر نشان داده شده است.

![اثر تمام‌حروف بزرگ](all_caps_effect.png)

کد مثال زیر نشان می‌دهد چگونه متن را با اثر **All Caps** استخراج کنیم:

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

**How do I modify text in a table on a slide?**

برای اصلاح متن در یک جدول روی اسلاید، از [ITable](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itable/) استفاده کنید. سلول‌ها را پیمایش کرده و هر سلول را از طریق [ICell.getTextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icell/#getTextFrame--) و قالب‌بندی پاراگراف‌ها از طریق [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraph/#getParagraphFormat--) به‌روزرسانی کنید.

**How do I apply a gradient color to text on a PowerPoint slide?**

برای اعمال رنگ گرادیانت به متن، از [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) استفاده کنید. مقدار [IFillFormat.setFillType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifillformat/#setFillType-byte-) را روی [FillType.Gradient](https://reference.aspose.com/slides/fa/java/com.aspose.slides/filltype/) تنظیم کنید و نقاط گرادیانت، جهت و شفافیت را پیکربندی کنید.