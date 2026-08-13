---
title: دریافت ویژگی‌های مؤثر شکل از ارائه‌ها در اندروید
linktitle: ویژگی‌های مؤثر
type: docs
weight: 50
url: /fa/androidjava/shape-effective-properties/
keywords:
- ویژگی‌های شکل
- ویژگی‌های دوربین
- نورپردازی
- برجستگی شکل
- چارچوب متن
- سبک متن
- ارتفاع قلم
- قالب پر کردن
- پاورپوینت
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه از Aspose.Slides برای اندروید با استفاده از جاوا برای تشخیص قالب‌بندی محلی، ارث‌برده و مؤثر اشکال در ارائه‌های PowerPoint استفاده کنید."
---
## **درک ویژگی‌های محلی، ارث‌برده و مؤثر**

قالب‌بندی PowerPoint می‌تواند از چندین منبع باشد. مقداری که مستقیماً بر روی یک شی ذخیره می‌شود، **مقدار محلی** آن است. اگر آن مقدار تنظیم نشده باشد، PowerPoint به منابع قالب‌بندی والد نگاه می‌کند، مانند پیش‌گزیدهٔ پاراگراف، سبک متن، یک طرح یا اسلاید اصلی، تم یا پیش‌گزیده‌های سطح ارائه. آن مقادیر **مقادیر ارث‌برده** هستند. مقداری که پس از حل کامل سلسله‌مراتب باقی می‌ماند **مقدار مؤثر** است — مقداری که برای رندر کردن شی استفاده می‌شود.

برای مثال، یک بخش متن ممکن است ارتفاع قلم خود را تعریف نکند. مقدار محلی آن [getFontHeight](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibaseportionformat/#getFontHeight--) سپس `Float.NaN` است که به معنای «در اینجا تنظیم نشده» می‌باشد. این بخش می‌تواند ارتفاعی را از پاراگراف خود، سبک متن پیش‌گزیده ارائه، یا منبع قابل اعمال دیگر به ارث ببرد. فراخوانی [getEffective](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iportionformat/#getEffective--) بر روی فرمت بخش، ارتفاع نهایی حل‌شده را برمی‌گرداند.

از دو نوع دادهٔ قالب‌بندی برای مقاصد مختلف استفاده کنید:

- یک شی قالب‌بندی محلی را بخوانید یا تغییر دهید، مانند [IPortionFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iportionformat/)، زمانی که نیاز به کنترل محل تعریف مقدار دارید.
- یک شی دادهٔ مؤثر را بخوانید، مانند [IPortionFormatEffectiveData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iportionformateffectivedata/)، زمانی که به نتیجهٔ نهایی، رندره‌شده نیاز دارید. داده‌های مؤثر فقط‑خواندنی هستند.

## **مقایسه مقادیر محلی، ارث‌برده و مؤثر**

مثال کامل زیر یک شکل ایجاد می‌کند و ارتفاع‌های قلم را در سطوح ارائه، پاراگراف و بخش اعمال می‌نماید. هر مرحله مقادیر تعریف‌شده در آن سطوح و مقدار مؤثر به‌دست آمده برای همان بخش متن را چاپ می‌کند. همچنین نشان می‌دهد چرا پس از تغییرات قالب‌بندی باید دادهٔ مؤثر دوباره خوانده شود.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
            ITextFrame textFrame = shape.addTextFrame("Effective formatting");
            IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
            IPortion portion = paragraph.getPortions().get_Item(0);

            // مقادیر ارث‌برده را در دو سطح مختلف تعریف کنید.
            presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

            printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

            // یک مقدار محلی در بخش، هر دو مقدار ارث‌برده را بازنویسی می‌کند.
            portion.getPortionFormat().setFontHeight(36);
            printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

            // تغییر یک مقدار ارث‌برده، مقدار محلی موجود را بازنویسی نمی‌کند.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
            printFontHeights("The local value still has priority", presentation, paragraph, portion);

            // مقدار محلی را پاک کنید. بخش اکنون دوباره از پاراگراف ارث می‌برد.
            portion.getPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The local value is cleared", presentation, paragraph, portion);

            // مقدار پاراگراف را پاک کنید. پیش‌گزیدهٔ ارائه اکنون نتیجه را فراهم می‌کند.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

            presentation.save("effective-properties.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }

    private static void printFontHeights(String caption, Presentation presentation, IParagraph paragraph, IPortion portion) {
        float presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
        float paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
        float localValue = portion.getPortionFormat().getFontHeight();

        // داده‌های مؤثر را پس از تغییرات پیشین بخوانید.
        float effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

        System.out.println(caption);
        System.out.println("  Presentation default: " + formatLocalValue(presentationValue));
        System.out.println("  Paragraph default:    " + formatLocalValue(paragraphValue));
        System.out.println("  Portion local:        " + formatLocalValue(localValue));
        System.out.println("  Portion effective:    " + effectiveValue);
    }

    private static String formatLocalValue(float value) {
        return Float.isNaN(value) ? "<not set>" : Float.toString(value);
    }
}
```


اولویت در این مثال، قالب‌بندی محلی بخش است، سپس قالب‌بندی پاراگراف و در نهایت پیش‌گزیدهٔ ارائه. اشیای دیگر می‌توانند زنجیرهٔ ارث‌برداری متفاوتی داشته باشند، اما اصل یکسان است: مقدار صریح و خاص‌تر برتری دارد و [getEffective](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iportionformat/#getEffective--) نتیجهٔ نهایی را بر می‌گرداند.

## **دریافت ویژگی‌های مؤثر متن**

قالب‌بندی متن در چندین شی تقسیم شده است:

- [ITextFrameFormat.getEffective()](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframeformat/#getEffective--) ویژگی‌های چارچوب متن مانند حاشیه‌ها، لنگرگذاری، خودمتناسبی و جهت متن عمودی را حل می‌کند.
- [ITextStyle.getEffective()](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextstyle/#getEffective--) قالب‌بندی پاراگراف را برای هر سطح سبک متن حل می‌کند.
- [IParagraphFormat.getEffective()](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#getEffective--) ویژگی‌های پاراگراف مانند تراز، تورفتگی و گلوله‌ها را حل می‌کند.
- [IPortionFormat.getEffective()](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iportionformat/#getEffective--) ویژگی‌های نویسه‌ای مانند ارتفاع قلم، نوع قلم، رنگ، ضخیم و ایتالیک را حل می‌کند.

برای مثال بعدی، فایل `text-formatting.pptx` باید حداقل یک اسلاید و یک [AutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/autoshape/) با چارچوب متن غیر خالی داشته باشد. AutoShape می‌تواند در هر موقعیتی از مجموعهٔ اشکال ظاهر شود؛ کد یک شی مناسب را جستجو کرده و قبل از استفاده اعتبارسنجی می‌کند.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("text-formatting.pptx");
        try {
            if (presentation.getSlides().size() == 0) {
                throw new IllegalStateException("The presentation contains no slides.");
            }

            IAutoShape shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
            if (shape == null) {
                throw new IllegalStateException("The first slide must contain an AutoShape with non-empty text.");
            }

            ITextFrame textFrame = shape.getTextFrame();
            IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
            IPortion portion = paragraph.getPortions().get_Item(0);

            ITextFrameFormatEffectiveData textFrameEffective = textFrame.getTextFrameFormat().getEffective();
            IParagraphFormatEffectiveData paragraphEffective = paragraph.getParagraphFormat().getEffective();
            IPortionFormatEffectiveData portionEffective = portion.getPortionFormat().getEffective();

            System.out.println("Text frame margins:");
            System.out.println("  Left: " + textFrameEffective.getMarginLeft());
            System.out.println("  Top: " + textFrameEffective.getMarginTop());
            System.out.println("  Right: " + textFrameEffective.getMarginRight());
            System.out.println("  Bottom: " + textFrameEffective.getMarginBottom());
            System.out.println("Paragraph alignment: " + paragraphEffective.getAlignment());
            System.out.println("Font height: " + portionEffective.getFontHeight());
            System.out.println("Bold: " + portionEffective.getFontBold());

            ITextStyleEffectiveData effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
            for (int level = 0; level < 9; level++) {
                IParagraphFormatEffectiveData levelEffective = effectiveTextStyle.getLevel(level);
                System.out.println("Level " + level + " indent: " + levelEffective.getIndent());
            }
        } finally {
            presentation.dispose();
        }
    }

    private static IAutoShape findAutoShapeWithText(ISlide slide) {
        for (IShape candidate : slide.getShapes()) {
            if (candidate instanceof IAutoShape && hasNonEmptyText((IAutoShape)candidate)) {
                return (IAutoShape)candidate;
            }
        }
        return null;
    }

    private static boolean hasNonEmptyText(IAutoShape shape) {
        if (shape.getTextFrame() == null) {
            return false;
        }
        if (shape.getTextFrame().getParagraphs().getCount() == 0) {
            return false;
        }
        return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
    }
}
```

## **دریافت ویژگی‌های مؤثر سه‌بعدی**

[IThreeDFormat.getEffective()](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/#getEffective--) یک شی [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformateffectivedata/) بازمی‌گرداند که تمام تنظیمات سه‌بعدی حل‌شده را گروه‌بندی می‌کند. متدهای [getCamera](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformateffectivedata/#getCamera--)، [getLightRig](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformateffectivedata/#getLightRig--)، [getBevelTop](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformateffectivedata/#getBevelTop--) و [getBevelBottom](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformateffectivedata/#getBevelBottom--) داده‌های مؤثر مربوطه را در اختیار می‌گذارند. خواندن این تنظیمات مرتبط به‌طور همزمان، درک ظاهر نهایی سه‌بعدی یک شکل را آسان‌تر می‌کند.

برای این مثال، فایل `shape-3d.pptx` باید حداقل یک شکل در اولین اسلاید خود داشته باشد. اگر می‌خواهید خروجی مقادیری غیر از پیش‌گزیده‌ها داشته باشد، تنظیمات دوربین سه‌بعدی، نورپردازی یا برجستگی را روی آن شکل اعمال کنید.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("shape-3d.pptx");
        try {
            if (presentation.getSlides().size() == 0 || presentation.getSlides().get_Item(0).getShapes().size() == 0) {
                throw new IllegalStateException("The first slide must contain a shape.");
            }

            IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
            IThreeDFormatEffectiveData threeDEffective = shape.getThreeDFormat().getEffective();

            System.out.println("Camera:");
            System.out.println("  Type: " + threeDEffective.getCamera().getCameraType());
            System.out.println("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
            System.out.println("  Zoom: " + threeDEffective.getCamera().getZoom());

            System.out.println("Light rig:");
            System.out.println("  Type: " + threeDEffective.getLightRig().getLightType());
            System.out.println("  Direction: " + threeDEffective.getLightRig().getDirection());

            System.out.println("Top bevel:");
            System.out.println("  Type: " + threeDEffective.getBevelTop().getBevelType());
            System.out.println("  Width: " + threeDEffective.getBevelTop().getWidth());
            System.out.println("  Height: " + threeDEffective.getBevelTop().getHeight());
        } finally {
            presentation.dispose();
        }
    }
}
```

## **دریافت قالب‌بندی مؤثر جدول**

قالب‌بندی جدول می‌تواند از سبک جدول و از قالب‌های اعمال‌شده بر کل جدول، یک ستون، یک ردیف یا یک سلول جداگانه ناشی شود. در برخوردهای مربوط به پرکننده‌های صریح، الویت به ترتیب سلول، ردیف، ستون و سپس کل جدول است. قالب مؤثر یک سلول، قالب نهایی استفاده‌شده برای رسم آن سلول است.

برای این مثال، فایل `table-formatting.pptx` باید حداقل یک جدول در اولین اسلاید خود داشته باشد. جدول باید حداقل یک ردیف و یک ستون داشته باشد. کد به جای فرض اینکه `getShapes().get_Item(0)` یک جدول است، به دنبال یک شی [ITable](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itable/) می‌گردد.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("table-formatting.pptx");
        try {
            if (presentation.getSlides().size() == 0) {
                throw new IllegalStateException("The presentation contains no slides.");
            }

            ITable table = findTable(presentation.getSlides().get_Item(0));
            if (table == null) {
                throw new IllegalStateException("The first slide must contain a table.");
            }
            if (table.getRows().size() == 0 || table.getColumns().size() == 0) {
                throw new IllegalStateException("The table must contain at least one cell.");
            }

            ITableFormatEffectiveData tableEffective = table.getTableFormat().getEffective();
            IRowFormatEffectiveData rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
            IColumnFormatEffectiveData columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
            ICellFormatEffectiveData cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

            System.out.println("Table fill: " + tableEffective.getFillFormat().getFillType());
            System.out.println("Row fill: " + rowEffective.getFillFormat().getFillType());
            System.out.println("Column fill: " + columnEffective.getFillFormat().getFillType());
            System.out.println("Final cell fill: " + cellEffective.getFillFormat().getFillType());
        } finally {
            presentation.dispose();
        }
    }

    private static ITable findTable(ISlide slide) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ITable) {
                return (ITable)shape;
            }
        }
        return null;
    }
}
```

اگر به رنگ نیاز دارید نه فقط نوع پرکننده، ابتدا نوع پرکنندهٔ مؤثر [getFillType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifillformateffectivedata/#getFillType--) را بررسی کنید، سپس متدی که به آن نوع مربوط است را بخوانید — برای مثال، [getSolidFillColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifillformateffectivedata/#getSolidFillColor--) برای پرکنندهٔ ثابت.

## **دوباره‌خوانی داده‌های مؤثر پس از تغییرات**

داده‌های مؤثر توصیف‌گر سلسله‌مراتب قالب‌بندی در زمان حل شدن هستند. پس از تغییر هر چیزی که می‌تواند در آن سلسله‌مراتب شرکت کند، `getEffective` را دوباره فراخوانی کنید، از جمله:

- قالب‌بندی محلی شی；
- پیش‌گزیده‌های پاراگراف یا چارچوب متن；
- یک سبک جدول، جدول، ستون، ردیف یا قالب سلول；
- قالب‌بندی طرح یا اسلاید اصلی；
- داده‌های تم یا پیش‌گزیده‌های سطح ارائه；
- طرح یا اسلاید اصلی اختصاص یافته به یک اسلاید。

دادهٔ مؤثر را به‌عنوان یک تصویر ثابت دائمی نگه ندارید. Aspose.Slides ممکن است برخی داده‌های مؤثر را به‌صورت داخلی کش کند و فراخوانی بعدی `getEffective` می‌تواند آن داده‌ها را به‌روز کند. اگر نیاز به مقایسه مقادیر قبل و بعد از تغییر دارید، مقادیر اسکالر مورد نیاز خود — مانند ارتفاع قلم، رنگ، تراز یا عرض برجستگی — را پیش از اعمال تغییرات در متغیرهای خود کپی کنید.

برای تغییر یک مقدار، شی قالب‌بندی محلی مناسب را به‌روزرسانی کنید و سپس `getEffective` را فراخوانی کنید تا نتیجه را تأیید کنید. اشیای دادهٔ مؤثر خود فقط‑خواندنی هستند.

## **پرسش‌های متداول**

**چگونه می‌توانم متوجه شوم کدام سطح مقدار مؤثر را ارائه داده است؟**

دادهٔ مؤثر تنها مقدار نهایی را شامل می‌شود، نه منبع آن. اشیای محلی قابل اعمال را از سطح خاص‌ترین به سمت بیرون بررسی کنید. برای متن، این می‌تواند شامل بخش، پاراگراف، چارچوب متن، طرح، اسلاید اصلی، تم و پیش‌گزیده‌های ارائه باشد. مقادیر تعریف‌نشده مانند `Float.NaN` یا `null` نشان می‌دهند که جستجو به سطح دیگری ادامه می‌یابد.

**چه اتفاقی می‌افتد وقتی هیچ سطحی خاصیتی را تعریف نکند؟**

Aspose.Slides مقدار پیش‌گزیدهٔ مناسب PowerPoint یا کتابخانه را حل می‌کند. آن مقدار حل‌شده در دادهٔ مؤثر ظاهر می‌شود حتی اگر هیچ شی محلی به‌صورت صریح آن را تعریف نکرده باشد.

**چرا گاهی مقدار مؤثر برابر با مقدار محلی است؟**

مقدار محلی بر محاسبهٔ ارث‌برداری پیروز شده است. این زمانی پیش می‌آید که ویژگی صریحاً بر روی شی تنظیم شده باشد و هیچ قاعدهٔ خاص‌تری آن را بازنویسی نکند.

**چه زمانی باید از دادهٔ محلی به‌جای دادهٔ مؤثر استفاده کنم؟**

دادهٔ محلی را برای بررسی یا ویرایش یک سطح قالب‌بندی خاص استفاده کنید. دادهٔ مؤثر را زمانی به کار ببرید که به ظاهر نهایی پس از ارث‌برداری، قوانین تم و سبک‌های قابل اعمال نیاز دارید. مثال [مقایسه کامل](#compare-local-inherited-and-effective-values) هر دو را در همان جریان کاری نشان می‌دهد.