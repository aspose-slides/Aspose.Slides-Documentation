---
title: دریافت ویژگی‌های مؤثر شکل از ارائه‌ها در جاوا
linktitle: ویژگی‌های مؤثر
type: docs
weight: 50
url: /fa/java/shape-effective-properties/
keywords:
- ویژگی‌های شکل
- ویژگی‌های دوربین
- نورپردازی
- برش شکل
- فریم متن
- سبک متن
- ارتفاع قلم
- قالب پر کردن
- پاورپوینت
- ارائه
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه از Aspose.Slides برای جاوا استفاده کنید تا قالب‌بندی محلی، وارث‌شده و مؤثر اشکال را در ارائه‌های PowerPoint تشخیص دهید."
---
## **درک مقادیر محلی، وارث‌شده و مؤثر**

قالب‌بندی PowerPoint می‌تواند از چندین منبع حاصل شود. مقداری که مستقیماً بر روی یک شی ذخیره می‌شود، **مقدار محلی** آن است. اگر آن مقدار تنظیم نشده باشد، PowerPoint به منابع قالب‌بندی والد نگاه می‌کند، از جمله پیش‌فرض پاراگراف، سبک متن، طرح‌بندی یا اسلاید اصلی، تم یا پیش‌فرض‌های سطح ارائه. این مقادیر **مقادیر وارث‌شده** هستند. مقداری که پس از حل کامل سلسله‌مراتب باقی می‌ماند، **مقدار مؤثر** است — مقداری که برای رسم شی استفاده می‌شود.

به عنوان مثال، ممکن است یک بخش متن ارتفاع قلم را تعریف نکند. مقدار محلی آن بخش با استفاده از متد [getFontHeight](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseportionformat/#getFontHeight--) سپس `Float.NaN` می‌شود که به معنی «در اینجا تنظیم نشده» است. این بخش می‌تواند ارتفاعی را از پاراگراف خود، سبک متن پیش‌فرض ارائه یا منبع دیگری به ارث ببرد. فراخوانی متد [getEffective](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iportionformat/#getEffective--) بر روی قالب‌بندی بخش، ارتفاع نهایی حل‌شده را برمی‌گرداند.

از دو نوع داده قالب‌بندی برای مقاصد مختلف استفاده کنید:

- برای خواندن یا تغییر یک شی قالب‌بندی محلی، مانند [IPortionFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iportionformat/)، زمانی که نیاز دارید مقدار از کجا تعریف شده است را کنترل کنید.
- برای خواندن یک شی داده مؤثر، مانند [IPortionFormatEffectiveData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iportionformateffectivedata/)، هنگامی که به نتیجه نهایی رندر شده نیاز دارید. داده‌های مؤثر فقط برای خواندن هستند.

## **مقایسه مقادیر محلی، وارث‌شده و مؤثر**

مثال کامل زیر یک شکل ایجاد می‌کند و ارتفاع قلم را در سطوح ارائه، پاراگراف و بخش تنظیم می‌نماید. در هر مرحله مقادیر تعریف‌شده در آن سطوح و مقدار مؤثر حاصل برای همان بخش متن چاپ می‌شود. همچنین نشان می‌دهد چرا داده مؤثر پس از تغییرات قالب‌بندی باید دوباره خوانده شود.

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

            // مقادیر وارث‌شده را در دو سطح متفاوت تعریف کنید.
            presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

            printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

            // یک مقدار محلی در بخش، هر دو مقدار وارث‌شده را نادیده می‌گیرد.
            portion.getPortionFormat().setFontHeight(36);
            printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

            // تغییر یک مقدار وارث‌شده، مقدار محلی موجود را بازنویسی نمی‌کند.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
            printFontHeights("The local value still has priority", presentation, paragraph, portion);

            // مقدار محلی را پاک کنید. اکنون بخش دوباره از پاراگراف وراثت می‌گیرد.
            portion.getPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The local value is cleared", presentation, paragraph, portion);

            // مقدار پاراگراف را پاک کنید. پیش‌فرض ارائه اکنون نتیجه را فراهم می‌کند.
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

        // پس از تغییرات قبل، داده مؤثر را بخوانید.
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

اولویت در این مثال قالب‌بندی محلی بخش است، سپس قالب‌بندی پاراگراف، و در نهایت پیش‌فرض ارائه. اشیاء دیگر می‌توانند زنجیره وراثت متفاوتی داشته باشند، اما اصل یکسان است: مقدار صریح خاص‌تر برنده است و متد [getEffective](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iportionformat/#getEffective--) نتیجه نهایی را برمی‌گرداند.

## **دریافت ویژگی‌های متن مؤثر**

قالب‌بندی متن در چند شی تقسیم می‌شود:

- [ITextFrameFormat.getEffective()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframeformat/#getEffective--) ویژگی‌های فریم‑متن مانند حاشیه‌ها، تکیه‌گاه، خود‑تطبیق و جهت متن عمودی را حل می‌کند.
- [ITextStyle.getEffective()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextstyle/#getEffective--) قالب‌بندی پاراگراف را برای هر سطح سبک متن حل می‌کند.
- [IParagraphFormat.getEffective()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#getEffective--) ویژگی‌های پاراگراف مانند تراز، تورفتگی و نقطه‌ها را حل می‌کند.
- [IPortionFormat.getEffective()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iportionformat/#getEffective--) ویژگی‌های کاراکتر مانند ارتفاع قلم، نوع قلم، رنگ، توپر و ایتالیک را حل می‌کند.

برای مثال بعدی، فایل `text-formatting.pptx` باید حداقل یک اسلاید و یک [AutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/autoshape/) با فریم متنی غیرخالی داشته باشد. AutoShape می‌تواند در هر موقعیتی از مجموعه اشکال ظاهر شود؛ کد یک شی مناسب را جستجو کرده و قبل از استفاده اعتبارسنجی می‌کند.

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

## **دریافت ویژگی‌های سه‌بعدی مؤثر**

متد [IThreeDFormat.getEffective()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformat/#getEffective--) یک شی [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformateffectivedata/) را برمی‌گرداند که تمام تنظیمات سه‌بعدی حل‌شده را گروه‌بندی می‌کند. متدهای [getCamera](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformateffectivedata/#getCamera--)، [getLightRig](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformateffectivedata/#getLightRig--)، [getBevelTop](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformateffectivedata/#getBevelTop--)، و [getBevelBottom](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ithreedformateffectivedata/#getBevelBottom--) داده‌های مؤثر مربوطه را نمایان می‌سازند. خواندن این تنظیمات مرتبط به‌صورت یکجا، درک ظاهر نهایی سه‌بعدی یک شکل را آسان‌تر می‌کند.

برای این مثال، فایل `shape-3d.pptx` باید حداقل یک شکل در اولین اسلاید داشته باشد. اگر می‌خواهید خروجی شامل مقادیری غیر از پیش‌فرض‌ها باشد، تنظیمات دوربین سه‌بعدی، نور یا برش را روی آن شکل اعمال کنید.

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

## **دریافت قالب‌بندی جدول مؤثر**

قالب‌بندی جدول می‌تواند از سبک جدول و از قالب‌های اعمال‌شده به کل جدول، یک ستون، یک ردیف یا یک سلول فردی حاصل شود. برای تداخل بین پر کردن‌های صریح تعریف‌شده، اولویت به ترتیب سلول، ردیف، ستون و سپس کل جدول است. قالب مؤثر یک سلول، قالب نهایی استفاده‌شده برای رسم آن سلول است.

برای این مثال، فایل `table-formatting.pptx` باید حداقل یک جدول در اولین اسلاید داشته باشد. جدول باید حداقل یک ردیف و یک ستون داشته باشد. کد به‌جای فرض اینکه `getShapes().get_Item(0)` یک جدول است، یک شی [ITable](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itable/) را جستجو می‌کند.

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

اگر به رنگ به‌جای تنها نوع پر کردن نیاز دارید، ابتدا نوع پر کردن مؤثر را با متد [getFillType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifillformateffectivedata/#getFillType--) بررسی کنید و سپس متد مربوط به آن نوع را بخوانید—for example, [getSolidFillColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifillformateffectivedata/#getSolidFillColor--) برای پر کردن یکدست.

## **خواندن مجدد داده‌های مؤثر پس از تغییرات**

داده‌های مؤثر توالی قالب‌بندی را در زمان حل شدن توصیف می‌کنند. پس از تغییر هر موردی که می‌تواند در این توالی شرکت داشته باشد، `getEffective` را دوباره فراخوانی کنید، از جمله:

- قالب‌بندی محلی شی؛
- پیش‌فرض‌های پاراگراف یا فریم‑متن؛
- قالب سبک جدول، جدول، ستون، ردیف یا سلول؛
- قالب‌بندی طرح‌بندی یا اسلاید اصلی؛
- داده‌های تم یا پیش‌فرض‌های سطح ارائه؛
- طرح‌بندی یا اسلاید اصلی اختصاص یافته به یک اسلاید.

داده مؤثر را به‌عنوان یک snapshot دائم نگه ندارید. Aspose.Slides ممکن است برخی داده‌های مؤثر را به‌صورت داخلی cache کند و فراخوانی بعدی `getEffective` می‌تواند آن داده‌ها را تازه‌سازی کند. اگر نیاز به مقایسه مقادیر قبل و بعد از تغییر دارید، مقادیر اسکالار مورد نیاز—مانند ارتفاع قلم، رنگ، تراز یا عرض برش—را قبل از اعمال تغییر به متغیرهای خود کپی کنید.

برای تغییر یک مقدار، شی قالب‌بندی محلی مربوطه را به‌روز کنید و سپس `getEffective` را فراخوانی کنید تا نتیجه را تأیید کنید. اشیاء داده مؤثر خود فقط برای خواندن هستند.

## **سؤالات متداول**

**چگونه می‌توانم تشخیص دهم کدام سطح مقدار مؤثر را فراهم کرده است؟**

داده مؤثر تنها مقدار نهایی را دارد، نه منبع آن. اشیاء محلی قابل‌فیلتر از سطح خاص‌ترین به بیرون بررسی کنید. برای متن، این می‌تواند شامل بخش، پاراگراف، فریم متن، طرح‌بندی، اسلاید اصلی، تم و پیش‌فرض‌های ارائه باشد. مقادیر تعریف‌نشده مانند `Float.NaN` یا `null` نشان می‌دهند که جستجو به سطح دیگری ادامه دارد.

**اگر هیچ سطحی ویژگی‌ای را تعریف نکند چه می‌شود؟**

Aspose.Slides مقدار پیش‌فرض مناسب PowerPoint یا کتابخانه را حل می‌کند. آن مقدار حل‌شده در داده مؤثر ظاهر می‌شود حتی اگر هیچ شی محلی به‌صورت صریح آن را تعریف نکرده باشد.

**چرا گاهی مقدار مؤثر برابر مقدار محلی است؟**

مقدار محلی محاسبه وراثت را برنده شده است. این زمانی پیش می‌آید که ویژگی به‌صورت صریح روی شی تنظیم شده و هیچ قانون خاص‌تری آن را بازنویسی نمی‌کند.

**وقتی باید به‌جای داده مؤثر از داده محلی استفاده کنم؟**

از داده محلی برای بازرسی یا ویرایش یک سطح خاص قالب‌بندی استفاده کنید. از داده مؤثر زمانی استفاده کنید که به ظاهر نهایی پس از وراثت، قوانین تم و سبک‌های قابل‑اعمال نیاز دارید. مثال [complete comparison example](#compare-local-inherited-and-effective-values) هر دو را در یک جریان کاری نشان می‌دهد.