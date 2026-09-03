---
title: "مدیریت هشدارهای ارائه در اندروید"
type: docs
weight: 90
url: /fa/androidjava/presentation-warnings/
aliases:
- /androidjava/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- "callback هشدار"
- "سیاست هشدار"
- "از دست رفتن داده"
- "فساد منبع"
- "مشکل سازگاری"
- "جایگزینی قلم"
- "امضای دیجیتال"
- "بارگذاری ارائه"
- "رندر ارائه"
- "تبدیل ارائه"
- "ذخیره ارائه"
- "PowerPoint"
- "OpenDocument"
- "Android"
- "Java"
- "Aspose.Slides"
description: "یاد بگیرید چگونه هشدارها را در حین بارگذاری، رندر، تبدیل و ذخیره ارائه‌ها با Aspose.Slides برای Android با استفاده از Java جمع‌آوری، طبقه‌بندی و مدیریت کنید."
---
## **نمای کلی**

Aspose.Slides می‌تواند مشکلات بازیابی‌پذیر را هنگام بارگذاری، رندر، تبدیل یا ذخیره یک ارائه گزارش دهد. مثال‌ها شامل سوابق منبع خراب، محتوایی که نمی‌توان آن را حفظ کرد، جایگزینی قلم و محدودیت‌های قالب هدف است. یک callback هشدار به برنامه اجازه می‌دهد این شرایط را ثبت کرده و تصمیم بگیرد آیا عملیات جاری می‌تواند ادامه یابد یا نه.

اینترفیس [IWarningCallback](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iwarningcallback/) را پیاده‌سازی کنید و مقادیر [getWarningType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) و [getDescription](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) را که از طریق [IWarningInfo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iwarninginfo/) فراهم می‌شوند بررسی کنید. برای پذیرش هشدار [ReturnAction.Continue](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/returnaction/#Continue) را برگردانید یا برای متوقف کردن عملیات [ReturnAction.Abort](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/returnaction/#Abort) را برگردانید.

از [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) برای هشدارهایی که هنگام باز کردن یک ارائه ایجاد می‌شوند استفاده کنید. کلاس‌های گزینه رندر و خروجی از [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) ارث می‌برند که هشدارها را از رندر اسلاید، تبدیل و ذخیره دریافت می‌کند. از آنجا که خود هشدار عملیات برنامه را شناسایی نمی‌کند، هر نمونه callback را با مرحله عملیاتی مرتبط کنید هنگامی که گزارش ترکیبی می‌سازید.

## **هشدارها و استثناها**

هشدار شرایطی را توصیف می‌کند که Aspose.Slides می‌تواند از آن بازیابی کند اگر callback مقدار `ReturnAction.Continue` را برگرداند. یک استثنا به این معنی است که عملیات درخواست‌شده نمی‌تواند به طور عادی تکمیل شود؛ استثناها به هشدار تبدیل نمی‌شوند و نمی‌توانند توسط سیاست هشدار مدیریت شوند.

برگرداندن `ReturnAction.Abort` از dispatcher هشدار می‌طلبد تا عملیات جاری را با پرتاب یک استثنا متوقف کند. استثنای عمومی بسته به عملیات و قالب ارائه متفاوت است. برای مثال، بارگذاری می‌تواند [PptxReadException](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pptxreadexception/) یا [PptReadException](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pptreadexception/) را ایجاد کند، در حالی که ذخیره یا خروجی می‌تواند [PptxException](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pptxexception/) را به‌وجود آورد. استثنا را در مرز عملیات مدیریت کنید و از گزارش هشدار برای تعیین اینکه آیا سیاست برنامه باعث خاتمه شده است استفاده کنید نه اینکه فقط به یک زیرنوع استثنا یا پیام وابسته باشید. callback هشدار را قبل از برگرداندن `ReturnAction.Abort` ثبت می‌کند تا دلیل آن در دسترس برنامه باقی بماند.

## **دسته‌بندی‌های هشدار**

کلاس [WarningType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/warningtype/) ثابت‌های عددی برای دسته‌های زیر را فراهم می‌کند:

| نوع هشدار | معنی | سیاست معمول |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/warningtype/#SourceFileCorruption) | ارائه منبع شامل فساد است که می‌تواند سند ذخیره‌شده در قالب اصلی‌اش را غیرقابل استفاده کند. | Abort. |
| [DataLoss](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/warningtype/#DataLoss) | متن، نمودارها، تصاویر یا داده‌های دیگر ممکن است پس از بارگذاری یا ذخیره غایب باشند. | Abort. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/warningtype/#MajorFormattingLoss) | ارائه ممکن است قالب‌بندی مهمی را از دست بدهد. | Abort در حالت اعتبارسنجی سخت‌گیرانه؛ در غیر اینصورت ثبت و ادامه. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/warningtype/#MinorFormattingLoss) | یک اختلاف محدود در قالب‌بندی ممکن است رخ دهد. | ثبت برای عیب‌یابی و ادامه. |
| [CompatibilityIssue](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/warningtype/#CompatibilityIssue) | نتیجه ممکن است در برخی برنامه‌ها یا نسخه‌های قدیمی به درستی باز یا رفتار نکند. | ثبت و ادامه مگر این که سازگاری اجباری باشد. |
| [UnexpectedContent](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/warningtype/#UnexpectedContent) | منبع حاوی محتوای پشتیبانی‌نشده یا ناشناخته است که اثر آن هنوز مشخص نیست. | ثبت و ادامه، یا در یک سیاست سخت‌گیرانه به عنوان خطا در نظر گرفتن. |

دسته‌بندی باید تصمیم‌گیری سیاستی را هدایت کند. مقدار برگردانده‌شده توسط [getDescription](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) را برای عیب‌یابی ذخیره کنید، اما برای منطق برنامه به متن آن وابسته نشوید چون متن پیام می‌تواند بین سناریوهای هشدار و نسخه‌های محصول متفاوت باشد.

## **جمع‌آوری و طبقه‌بندی هشدارها**

مثال زیر یک گزارش سطح برنامه برای کل خط لوله پردازشی استفاده می‌کند. یک نمونه callback جداگانه هشدارهای بارگذاری، رندر، تبدیل PDF و ذخیره PPTX را برچسب‌گذاری می‌کند. سیاست در مواجهه با فساد منبع یا از دست رفتن داده‌ها متوقف می‌شود، به‌صورت اختیاری در صورت از دست رفتن قالب‌بندی مهم متوقف می‌گردد و برای سایر هشدارها ادامه می‌دهد.

فایل `input.pptx` را در یک پوشه قابل نوشتن برنامه قرار دهید و آن پوشه را به `PresentationWarningExample.run` پاس کنید. مثال خروجی‌های خود را در همان پوشه ذخیره می‌کند. پردازش ارائه را روی یک رشته پس‌زمینه اجرا کنید تا رابط کاربری Android پاسخگو بماند.

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
import java.io.File;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class PresentationWarningExample {
    public static void run(File dataDirectory) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        File inputFile = new File(dataDirectory, "input.pptx");
        boolean completed = processPresentation(inputFile.getAbsolutePath(), dataDirectory, report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, dataDirectory, report, policy);
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

    private static boolean renderFirstSlide(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
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
                File outputFile = new File(dataDirectory, "slide-1.png");
                image.save(outputFile.getAbsolutePath(), ImageFormat.Png);
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

    private static boolean convertToPdf(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "converted.pdf");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "validated-output.pptx");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx, options);
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

در هنگام ساختن `WarningPolicy` مقدار `false` را برای `abortOnMajorFormattingLoss` بگیرید اگر اختلافات قالب‌بندی بزرگ قابل قبول باشند. مشکلات سازگاری، از دست رفتن قالب‌بندی جزئی و محتوای ناخواسته همچنان در گزارش باقی می‌مانند حتی وقتی عملیات ادامه می‌یابد. اگر برنامه باید هر یک از این دسته‌ها را رد کند، `WarningPolicy.getAction` را گسترش دهید.

## **سناریوهای رایج هشدار**

- **Digital signatures:** یک ارائه امضاشده می‌تواند هنگام بارگذاری هشدار دهد که امضای آن در طول پردازش از دست خواهد رفت. Aspose.Slides این وضعیت `DataLoss` را از طریق [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationsignedwarninginfo/) گزارش می‌کند. یک callback در مرحله بارگذاری به برنامه اجازه می‌دهد فایل را رد کند یا صراحتاً از از دست رفتن گزارش‌شده پذیرش کند.
- **Font substitution:** یک قلم در دسترس نیست و در هنگام رندر یا خروجی اسلاید جایگزین می‌شود. هشدارهای جایگزینی قلم به عنوان `DataLoss` گزارش می‌شوند، بنابراین سیاست سخت‌گیرانه بالا حتی در صورتی که برنامه جایگزینی خاصی را از نظر بصری قابل قبول بداند، متوقف می‌شود. برای مشاهده این رفتار، ارائه‌ای ورودی داشته باشید که متنی با قلمی غیرقابل دسترس برای زمان اجرا داشته باشد. توضیح هشدار جایگزینی را شناسایی می‌کند؛ قلم‌های مورد نیاز یا [قوانین جایگزینی قلم](/slides/fa/androidjava/font-substitution/) را قبل از تلاش مجدد پیکربندی کنید.
- **Unsupported or unexpected content:** یک بارگذار ممکن است رکوردها یا ویژگی‌هایی را که نمی‌شناسد با آنها مواجه شود. چنین هشدارهایی ممکن است `UnexpectedContent` استفاده کنند، یا دسته‌ای شدیدتر اگر داده یا قالب‌بندی تحت تاثیر باشد.
- **Format compatibility:** ذخیره به قالب ارائه دیگر ممکن است ویژگی‌ها را حذف کند یا نتیجه‌ای تولید کند که در برخی برنامه‌ها متفاوت رفتار کند. به‌عنوان مثال، ذخیره ارائه‌ای با بیش از هشت راهنمای افقی یا عمودی به PPT قدیمی `CompatibilityIssue` گزارش می‌دهد. callback در مرحله ذخیره می‌تواند این از دست رفتن را ثبت کند و ادامه دهد، یا اگر حفظ تمام راهنماها ضروری باشد آن را رد کند.
- **Loading behavior:** گزینه‌های بارگذاری و رفتارهای قدیمی نیز می‌توانند هشدار ایجاد کنند. به‌عنوان مثال، [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) استفاده از رفتار قفل‌گذاری ارائه منسوخ را به عنوان `CompatibilityIssue` شناسایی می‌کند.

هشدارها به سند منبع، قالب هدف، عملیات و نسخه Aspose.Slides وابسته‌اند. فرض نکنید هر فایل حتماً هشدار تولید می‌کند یا هر سناریو همیشه به یک دسته واحد نگاشت می‌شود.

## **به‌صورت ایمن مدیریت عملیات‌های متوقف‌شده**

زمانی که یک callback مقدار `ReturnAction.Abort` را برمی‌گرداند، از شیئی که بارگذاری‌اش شکست خورده استفاده نکنید و فرض نکنید خروجی رندر یا ذخیره کامل است. عملیات می‌تواند پس از ایجاد فایل خروجی اما پیش از تکمیل آن خاتمه یابد.

نتایج معتبر را در مسیر جداگانه‌ای مانند `validated-output.pptx` ذخیره کنید. یک ارائه موجود را فقط پس از این که عملیات به‌صورت موفقیت‌آمیز تمام شد، گزارش هشدار سیاست برنامه را برآورده کرد و خروجی قابل باز و بررسی بود، جایگزین کنید. این کار از نوشتن روی فایل منبع معتبر با نتیجهٔ جزئی یا ردشده جلوگیری می‌کند.

یک گزارش هشدار خالی تضمین‌کنندهٔ حفظ تمام ویژگی‌های منبع نیست. هر بررسی محتوایی و بصری اضافی که برنامه نیاز دارد اعمال کنید. همچنین به [Open Presentations](/slides/fa/androidjava/open-presentation/) و [Save Presentations](/slides/fa/androidjava/save-presentation/) مراجعه کنید.

## **سؤال‌های متداول**

**آیا یک callback هشدار می‌تواند هر خطای Aspose.Slides را مدیریت کند؟**

نه. این فقط شرایط قابل بازیابی را که به صورت هشدار گزارش می‌شوند، مدیریت می‌کند. استثناهایی که مستقل از callback رخ می‌دهند باید توسط برنامه در اطراف فراخوانی بارگذاری، رندر، تبدیل یا ذخیره‌سازی مدیریت شوند.

**آیا برگرداندن `ReturnAction.Continue` تضمین می‌کند خروجی دقیقاً یکسان باشد؟**

نه. این فقط اجازه می‌دهد پردازش ادامه یابد. وضعیت گزارش‌شده هنوز ممکن است باعث تفاوت‌های داده، قالب‌بندی یا سازگاری شود، بنابراین نوع و توضیحات هشدارهای جمع‌آوری‌شده را بررسی کنید.

**یک برنامه چگونه می‌تواند عملیات تولیدکننده هشدار را شناسایی کند؟**

برای هر عملیات یک نمونه callback ایجاد کنید و مرحله‌ای که برنامه تعریف می‌کند را همراه با مقادیر برگردانده‌شده توسط [getWarningType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) و [getDescription](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) ذخیره کنید، همان‌طور که در مثال نشان داده شده است.