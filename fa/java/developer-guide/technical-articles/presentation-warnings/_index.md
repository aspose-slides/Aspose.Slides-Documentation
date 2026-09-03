---
title: مدیریت هشدارهای ارائه در جاوا
type: docs
weight: 90
url: /fa/java/presentation-warnings/
aliases:
- /java/دریافت-فراخوانی-هشدار-برای-جایگزینی-قلم-در-aspose-slides/
keywords:
- فراخوانی هشدار
- سیاست هشدار
- از دست رفتن داده
- خرابی منبع
- مشکل سازگاری
- جایگزینی قلم
- امضای دیجیتال
- بارگذاری ارائه
- رندر ارائه
- تبدیل ارائه
- ذخیره ارائه
- پاورپوینت
- سند باز
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه هشدارها را پیش از بارگذاری، رندر، تبدیل و ذخیره ارائه‌ها با Aspose.Slides برای جاوا جمع‌آوری، طبقه‌بندی و مدیریت کنید."
---
## **بررسی کلی**

Aspose.Slides می‌تواند مشکلات قابل بازیابی را هنگام بارگذاری، رندر، تبدیل یا ذخیره یک ارائه گزارش کند. نمونه‌ها شامل سوابق منبع خراب، محتوایی که نمی‌توان آن را حفظ کرد، جایگزینی قلم و محدودیت‌های فرمت هدف هستند. یک فراخوانی هشدار به برنامه اجازه می‌دهد این شرایط را ضبط کند و تصمیم بگیرد آیا عملیات جاری می‌تواند ادامه یابد یا خیر.

رابط [IWarningCallback](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iwarningcallback/) را پیاده‌سازی کنید و مقادیر [getWarningType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iwarninginfo/#getWarningType--) و [getDescription](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iwarninginfo/#getDescription--) ارائه‌شده توسط [IWarningInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iwarninginfo/) را بررسی کنید. برای پذیرش هشدار [ReturnAction.Continue](https://reference.aspose.com/slides/fa/java/com.aspose.slides/returnaction/#Continue) را بازگردانید یا برای متوقف کردن عملیات [ReturnAction.Abort](https://reference.aspose.com/slides/fa/java/com.aspose.slides/returnaction/#Abort) را بازگردانید.

از [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) برای هشدارهایی که هنگام باز کردن یک ارائه ایجاد می‌شوند استفاده کنید. کلاس‌های گزینه رندر و خروجی از [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/fa/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) ارث‌بری می‌کنند که هشدارها را از رندر اسلاید، تبدیل و ذخیره دریافت می‌کند. چون خود هشدار عملیاتی که برنامه انجام می‌دهد را شناسایی نمی‌کند، هر نمونه فراخوانی را با مرحله عملیات مرتبط کنید تا گزارش ترکیبی بسازید.

## **هشدارها و استثناها**

هشدار شرایطی را توصیف می‌کند که Aspose.Slides می‌تواند در صورت بازگرداندن `ReturnAction.Continue` از آن بازگردد. استثنا به این معنی است که عملیات درخواست‌شده نمی‌تواند به‌طور معمول به پایان برسد؛ استثناها به هشدار تبدیل نمی‌شوند و توسط سیاست هشدار قابل مدیریت نیستند.

بازگرداندن `ReturnAction.Abort` درخواست می‌کند که توزیع‌کننده هشدار عملیات جاری را با پرتاب یک استثنا پایان دهد. نوع استثنای عمومی به عملیات و فرمت ارائه بستگی دارد. به‌عنوان مثال، بارگذاری می‌تواند یک [PptxReadException](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pptxreadexception/) یا [PptReadException](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pptreadexception/) ایجاد کند، در حالی که ذخیره یا خروجی می‌تواند یک [PptxException](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pptxexception/) ایجاد کند. استثنا را در مرز عملیات مدیریت کنید و از گزارش هشدار برای تعیین این‌که آیا سیاست برنامه سبب قطع عملیات شده است استفاده کنید، نه فقط تکیه بر یک زیردسته یا پیام استثنا. فراخوانی هشدار را پیش از بازگرداندن `ReturnAction.Abort` ثبت می‌کند تا دلیل همچنان برای برنامه در دسترس باشد.

## **دسته‌های هشدار**

کلاس [WarningType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/warningtype/) ثابت‌های عددی زیر را برای دسته‌های زیر فراهم می‌کند:

| نوع هشدار | معنا | سیاست معمول |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/fa/java/com.aspose.slides/warningtype/#SourceFileCorruption) | ارائه منبع شامل خرابی است که می‌تواند سند ذخیره‌شده در فرمت اصلی را غیرقابل استفاده کند. | لغو. |
| [DataLoss](https://reference.aspose.com/slides/fa/java/com.aspose.slides/warningtype/#DataLoss) | پس از بارگذاری یا ذخیره، متن، نمودارها، تصاویر یا داده‌های دیگر ممکن است غائب شوند. | لغو. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/fa/java/com.aspose.slides/warningtype/#MajorFormattingLoss) | ممکن است قالب‌بندی مهم ارائه از دست برود. | در حالت اعتبارسنجی سخت‌گیرانه لغو؛ در غیر این صورت ضبط و ادامه. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/fa/java/com.aspose.slides/warningtype/#MinorFormattingLoss) | تفاوت محدود قالب‌بندی ممکن است رخ دهد. | ضبط برای عیب‌یابی و ادامه. |
| [CompatibilityIssue](https://reference.aspose.com/slides/fa/java/com.aspose.slides/warningtype/#CompatibilityIssue) | ممکن است نتیجه در برخی برنامه‌ها یا نسخه‌های قدیمی باز نشود یا به‌درستی عمل نکند. | ثبت و ادامه مگر اینکه سازگاری اجباری باشد. |
| [UnexpectedContent](https://reference.aspose.com/slides/fa/java/com.aspose.slides/warningtype/#UnexpectedContent) | محتوا یا رکوردهای پشتیبانی‌نشده‌ای در منبع وجود دارد که اثر آن هنوز شناخته نشده است. | ضبط و ادامه، یا در سیاست سخت‌گیرانه به‌عنوان خطا در نظر گرفتن. |

دسته‌بندی باید تصمیم‌گیری سیاست را هدایت کند. مقدار بازگردانده‌شده توسط [getDescription](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iwarninginfo/#getDescription--) را برای عیب‌یابی ذخیره کنید، اما برای منطق برنامه بر روی متن آن وابسته نشوید زیرا متن پیام می‌تواند بین سناریوهای هشدار و نسخه‌های محصول متفاوت باشد.

## **جمع‌آوری و طبقه‌بندی هشدارها**

مثال زیر از یک گزارش سطح برنامه برای کل مسیر پردازش استفاده می‌کند. یک نمونه فراخوانی جداگانه هشدارهای بارگذاری، رندر، تبدیل به PDF و ذخیره PPTX را برچسب‌گذاری می‌کند. سیاست در صورت خرابی منبع یا از دست رفتن داده‌ها لغو می‌شود، به‌صورت اختیاری در صورت از دست رفتن قالب‌بندی عمده لغو می‌کند و برای سایر هشدارها ادامه می‌دهد.

```java
import com.aspose.slides.IImage;
import com.aspose.slides.IWarningCallback;
import com.aspose.slides.IWarningInfo;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;
import com.aspose.slides.ReturnAction;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.WarningType;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

class PresentationWarningExample {
    public static void main(String[] args) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        boolean completed = processPresentation("input.pptx", report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, report, policy);
            }
            finally {
                presentation.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Loading stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean renderFirstSlide(Presentation presentation, WarningReport report, WarningPolicy policy) {
        if (presentation.getSlides().size() == 0) {
            System.err.println("Rendering stopped: the presentation has no slides.");
            return false;
        }

        try {
            RenderingOptions options = new RenderingOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Rendering, report, policy);
            options.setWarningCallback(callback);

            IImage image = presentation.getSlides().get_Item(0).getImage(options);
            try {
                image.save("slide-1.png", ImageFormat.Png);
                return true;
            }
            finally {
                image.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Rendering stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean convertToPdf(Presentation presentation, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            presentation.save("converted.pdf", SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            presentation.save("validated-output.pptx", SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Saving stopped: " + exception.getMessage());
            return false;
        }
    }

    private static String warningTypeName(int warningType) {
        switch (warningType) {
            case WarningType.SourceFileCorruption:
                return "SourceFileCorruption";
            case WarningType.DataLoss:
                return "DataLoss";
            case WarningType.MajorFormattingLoss:
                return "MajorFormattingLoss";
            case WarningType.MinorFormattingLoss:
                return "MinorFormattingLoss";
            case WarningType.CompatibilityIssue:
                return "CompatibilityIssue";
            case WarningType.UnexpectedContent:
                return "UnexpectedContent";
            default:
                return "Unknown (" + warningType + ")";
        }
    }

    private enum OperationStage {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private static final class WarningEntry {
        final OperationStage stage;
        final int type;
        final String description;

        WarningEntry(OperationStage stage, int type, String description) {
            this.stage = stage;
            this.type = type;
            this.description = description;
        }
    }

    private static final class WarningReport {
        private final List<WarningEntry> entries = new ArrayList<WarningEntry>();

        List<WarningEntry> getEntries() {
            return Collections.unmodifiableList(entries);
        }

        void add(OperationStage stage, IWarningInfo warning) {
            WarningEntry entry = new WarningEntry(stage, warning.getWarningType(), warning.getDescription());
            entries.add(entry);
        }
    }

    private static final class WarningPolicy {
        private final boolean abortOnMajorFormattingLoss;

        WarningPolicy(boolean abortOnMajorFormattingLoss) {
            this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        int getAction(int warningType) {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss) {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && abortOnMajorFormattingLoss) {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private static final class ReportingWarningCallback implements IWarningCallback {
        private final OperationStage stage;
        private final WarningReport report;
        private final WarningPolicy policy;

        ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy) {
            this.stage = stage;
            this.report = report;
            this.policy = policy;
        }

        @Override
        public int warning(IWarningInfo warning) {
            report.add(stage, warning);
            return policy.getAction(warning.getWarningType());
        }
    }
}
```

در صورتی که تفاوت‌های قالب‌بندی عمده قابل قبول باشد، هنگام ساخت `WarningPolicy` مقدار `false` را برای `abortOnMajorFormattingLoss` پاس دهید. مسائل سازگاری، از دست رفتن قالب‌بندی جزئی و محتواهای غیرمنتظره همچنان در گزارش حفظ می‌شوند حتی زمانی که عملیات ادامه می‌یابد. اگر برنامه باید هر یک از این دسته‌ها را رد کند، `WarningPolicy.getAction` را گسترش دهید.

## **سناریوهای رایج هشدار**

هشدارها می‌توانند در مراحل مختلف یک گردش کار ظاهر شوند:

- **امضاهای دیجیتال:** یک ارائه امضا شده می‌تواند هنگام بارگذاری هشدار دهد که امضای آن در طول پردازش از دست خواهد رفت. Aspose.Slides این وضعیت `DataLoss` را از طریق [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationsignedwarninginfo/) گزارش می‌کند. یک فراخوانی در مرحله بارگذاری به برنامه اجازه می‌دهد فایل را رد کند یا صراحتاً ریسک از دست رفتن را بپذیرد.
- **جایگزینی قلم:** یک قلم در دسترس نباشد و در حین رندر یا خروجی اسلاید جایگزین شود. هشدارهای جایگزینی قلم به عنوان `DataLoss` گزارش می‌شوند، بنابراین سیاست سخت‌گیرانه بالا حتی اگر برنامه جایگزینی را بصری قابل قبول بداند، لغو می‌کند. برای مشاهده این رفتار، از ارائه‌ای استفاده کنید که متنی با قلم غیرقابل دسترس در زمان اجرا داشته باشد. توضیح هشدار جایگزینی را شناسایی می‌کند؛ قبل از تلاش مجدد فونت‌های مورد نیاز یا [قوانین جایگزینی قلم](/slides/fa/java/font-substitution/) را پیکربندی کنید.
- **محتوای پشتیبانی‌نشده یا غیرمنتظره:** بارگر ممکن است رکوردها یا ویژگی‌هایی را که تشخیص نمی‌دهد پیدا کند. چنین هشدارهایی ممکن است `UnexpectedContent` یا دسته‌بندی شدیدی‌تر داشته باشند اگر داده یا قالب‌بندی تحت تأثیر باشد.
- **سازگاری فرمت:** ذخیره به فرمت ارائه دیگری می‌تواند ویژگی‌ها را حذف کند یا نتیجه‌ای تولید کند که در برخی برنامه‌ها رفتار متفاوتی داشته باشد. برای مثال، ذخیره ارائه‌ای با بیش از هشت راهنمای افقی یا عمودی به فرمت PPT قدیمی `CompatibilityIssue` گزارش می‌دهد. فراخوانی در مرحله ذخیره می‌تواند این از دست رفتن را ثبت کرده و ادامه دهد یا اگر حفظ تمام راهنماها ضروری باشد، آن را رد کند.
- **رفتار بارگذاری:** گزینه‌های بارگذاری و رفتارهای قدیمی نیز می‌توانند هشدار تولید کنند. به‌عنوان مثال، [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) استفاده از رفتار قفل‌گذاری ارائه منقضی‌شده را به‌عنوان `CompatibilityIssue` شناسایی می‌کند.

هشدارها به سند منبع، فرمت هدف، عملیات و نسخه Aspose.Slides بستگی دارند. فرض نکنید که هر فایل هشدار ایجاد می‌کند یا اینکه یک سناریو همیشه به یک دسته خاص می‌ماند.

## **به‌صورت ایمن مدیریت عملیات‌های لغو‌شده**

زمانی که یک فراخوانی `ReturnAction.Abort` باز می‌گرداند، از شیئی که بارگذاری‌اش شکست خورده استفاده نکنید و فرض نکنید خروجی رندر یا ذخیره کامل است. عملیات می‌تواند پس از ایجاد فایل خروجی اما پیش از تکمیل آن پایان یابد.

نتایج اعتبارسنجی‌شده را در مسیری جداگانه مانند `validated-output.pptx` ذخیره کنید. فقط پس از اتمام موفقیت‌آمیز عملیات، تأیید سیاست هشدار و قابلیت باز کردن و بررسی خروجی، ارائه موجود را بازنویسی کنید. این کار از بازنویسی یک فایل منبع معتبر با نتیجه جزئی یا رد شده جلوگیری می‌کند.

یک گزارش هشدار خالی تضمین نمی‌کند که هر ویژگی منبع حفظ شده باشد. هر بررسی محتوایی و بصری اضافی که برنامه نیاز دارد اعمال کنید. همچنین به [Open Presentations](/slides/fa/java/open-presentation/) و [Save Presentations](/slides/fa/java/save-presentation/) مراجعه کنید.

## **سوالات متداول**

**آیا یک فراخوانی هشدار می‌تواند هر خطای Aspose.Slides را مدیریت کند؟**

خیر. این فراخوانی فقط شرایط قابل بازیابی را به‌صورت هشدار گزارش می‌کند. استثناهایی که به‌طور مستقل از فراخوانی رخ می‌دهند باید توسط برنامه در اطراف فراخوانی بارگذاری، رندر، تبدیل یا ذخیره مدیریت شوند.

**آیا بازگرداندن `ReturnAction.Continue` خروجی یکسانی را تضمین می‌کند؟**

خیر. این تنها اجازه می‌دهد پردازش ادامه یابد. شرایط گزارش‌شده ممکن است همچنان منجر به اختلافات داده، قالب‌بندی یا سازگاری شود، بنابراین نوع‌ها و توصیف‌های جمع‌آوری‌شده هشدارها را بررسی کنید.

**چگونه یک برنامه می‌تواند عملیات تولیدکننده هشدار را شناسایی کند؟**

برای هر عملیات یک نمونه فراخوانی ایجاد کنید و مرحله‌ای تعریف‌شده توسط برنامه را همراه با مقادیر بازگردانده‌شده توسط [getWarningType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iwarninginfo/#getWarningType--) و [getDescription](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iwarninginfo/#getDescription--) ذخیره کنید، همان‌طور که در مثال نشان داده شده است.