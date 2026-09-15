---
title: مدیریت هشدارهای ارائه در پایتون از طریق جاوا
type: docs
weight: 90
url: /fa/python-java/presentation-warnings/
aliases:
- /python-java/دریافت-فراخوانی-هشدار-برای-جایگزینی-قلم‌ها-در-aspose-slides/
keywords:
- فراخوانی هشدار
- سیاست هشدار
- از دست رفتن داده
- خراب‌سازی منبع
- مسئله سازگاری
- جایگزینی قلم
- امضای دیجیتال
- بارگذاری ارائه
- رندر ارائه
- تبدیل ارائه
- ذخیره ارائه
- پاورپوینت
- سند باز
- پایتون
- جاوا
- Aspose.Slides
description: "بیاموزید چگونه هشدارها را جمع‌آوری، دسته‌بندی و بر اساس آنها در هنگام بارگذاری، رندر، تبدیل و ذخیره ارائه‌ها با Aspose.Slides برای پایتون از طریق جاوا مدیریت کنید."
---
## **بررسی کلی**

Aspose.Slides می‌تواند مشکلات قابل بازیابی را هنگام بارگذاری، رندر، تبدیل یا ذخیره یک ارائه گزارش دهد. مثال‌ها شامل رکوردهای منبع آسیب‌دیده، محتوایی که نمی‌توان آن را حفظ کرد، جایگزینی قلم و محدودیت‌های فرمت هدف هستند. یک فراخوانی هشدار به برنامه اجازه می‌دهد این شرایط را ثبت کند و تصمیم بگیرد آیا عملیات جاری می‌تواند ادامه یابد یا نه.

پیاده‌سازی رابط `IWarningCallback` از طریق `jpype.JProxy` و بررسی مقادیر `getWarningType` و `getDescription` که از طریق `IWarningInfo` ارائه می‌شوند. برای پذیرفتن هشدار، [ReturnAction.Continue](https://reference.aspose.com/slides/fa/python-java/aspose.slides/returnaction/#Continue) را برگردانید یا برای متوقف کردن عملیات، [ReturnAction.Abort](https://reference.aspose.com/slides/fa/python-java/aspose.slides/returnaction/#Abort) را برگردانید.

از [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#setWarningCallback) برای هشدارهایی که هنگام باز کردن یک ارائه ایجاد می‌شوند، استفاده کنید. کلاس‌های گزینه‌های رندر و استخراج از [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveoptions/#setWarningCallback) ارث می‌برند که هشدارها را از رندر اسلاید، تبدیل و ذخیره دریافت می‌کند. چون هشدار خود به تنهایی عملیات برنامه را شناسایی نمی‌کند، هنگام ساخت گزارش ترکیبی، هر نمونه فراخوانی را با مرحلهٔ عملیات مرتبط کنید.

## **هشدارها و استثناها**

هشدار وضعیتی را توصیف می‌کند که Aspose.Slides می‌تواند از آن بازیابی کند اگر فراخوانی `ReturnAction.Continue` را برگرداند. یک استثنا به این معنی است که عملیات درخواست‌شده نمی‌تواند به‌صورت عادی تمام شود؛ استثناها به هشدار تبدیل نمی‌شوند و نمی‌توانند توسط سیاست هشدار مدیریت شوند.

برگرداندن `ReturnAction.Abort` از dispatch کننده هشدار می‌خواهد تا عملیات جاری را با پرتاب یک استثنا خاتمه دهد. نوع استثنای عمومی بستگی به عملیات و فرمت ارائه دارد. به‌عنوان مثال، بارگذاری می‌تواند [PptxReadException](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pptxreadexception/) یا [PptReadException](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pptreadexception/) را ایجاد کند، در حالی که ذخیره یا استخراج می‌تواند [PptxException](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pptxexception/) را ایجاد کند. استثنا را در مرز عملیات مدیریت کنید و از گزارش هشدار برای تعیین این‌که آیا سیاست برنامه باعث خاتمه شده است استفاده کنید؛ به‌جای تکیه بر یک زیردسته یا پیام استثنا. فراخوانی پیش از برگرداندن `ReturnAction.Abort` هشدار را ثبت می‌کند تا دلیل آن برای برنامه در دسترس بماند.

## **دسته‌های هشدار**

کلاس [WarningType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/warningtype/) ثابت‌های عددی برای دسته‌های زیر را فراهم می‌کند:

| نوع هشدار | معنی | سیاست معمول |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/fa/python-java/aspose.slides/warningtype/#SourceFileCorruption) | ارائه منبع شامل خرابی است که می‌تواند باعث شود سند ذخیره‌شده در فرمت اصلی قابل استفاده نباشد. | توقف. |
| [DataLoss](https://reference.aspose.com/slides/fa/python-java/aspose.slides/warningtype/#DataLoss) | متن، نمودارها، تصاویر یا داده‌های دیگر ممکن است پس از بارگذاری یا ذخیره غائب شوند. | توقف. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/fa/python-java/aspose.slides/warningtype/#MajorFormattingLoss) | ارائه ممکن است قالب‌بندی مهمی را از دست بدهد. | در حالت اعتبارسنجی سخت‌گیرانه توقف؛ در غیر این صورت ثبت و ادامه. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/fa/python-java/aspose.slides/warningtype/#MinorFormattingLoss) | اختلاف محدود قالب‌بندی ممکن است رخ دهد. | ثبت برای عیب‌یابی و ادامه. |
| [CompatibilityIssue](https://reference.aspose.com/slides/fa/python-java/aspose.slides/warningtype/#CompatibilityIssue) | نتیجه ممکن است در برخی برنامه‌ها یا نسخه‌های قدیمی به‌درستی باز یا رفتار نکند. | ثبت لاگ و ادامه مگر اینکه سازگاری الزامی باشد. |
| [UnexpectedContent](https://reference.aspose.com/slides/fa/python-java/aspose.slides/warningtype/#UnexpectedContent) | منبع شامل محتوای پشتیبانی‌نشده یا ناشناخته‌ای است که اثر آن هنوز مشخص نیست. | ثبت و ادامه، یا در سیاست سخت‌گیرانه به‌عنوان خطا در نظر گرفتن. |

دسته‌بندی باید تصمیم‌گیری سیاستی را هدایت کند. مقدار بازگردانده‌شده توسط `getDescription` را برای عیب‌یابی ذخیره کنید، اما برای منطق برنامه به متن آن وابسته نشوید زیرا متن پیام می‌تواند بین سناریوهای هشدار و نسخه‌های محصول متفاوت باشد.

## **جمع‌آوری و دسته‌بندی هشدارها**

مثال زیر یک گزارش سطح برنامه برای کل خط پردازش استفاده می‌کند. یک نمونه فراخوانی جداگانه هشدارهای مربوط به بارگذاری، رندر، تبدیل PDF و ذخیره PPTX را برچسب‌گذاری می‌کند. سیاست در صورت وجود خرابی منبع یا از دست رفتن داده‌ها متوقف می‌شود، به‌صورت اختیاری در صورت از دست رفتن قالب‌بندی عمده متوقف می‌شود و برای سایر هشدارها ادامه می‌یابد.

```python
import sys
from dataclasses import dataclass
from enum import Enum

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, LoadOptions, PdfOptions, PptxOptions, Presentation, RenderingOptions, ReturnAction, SaveFormat, WarningType


class OperationStage(Enum):
    Loading = "Loading"
    Rendering = "Rendering"
    Conversion = "Conversion"
    Saving = "Saving"


@dataclass(frozen=True)
class WarningEntry:
    stage: OperationStage
    type: int
    description: str


class WarningReport:
    def __init__(self):
        self._entries = []

    def get_entries(self):
        return tuple(self._entries)

    def add(self, stage, warning):
        entry = WarningEntry(stage, warning.getWarningType(), str(warning.getDescription()))
        self._entries.append(entry)


class WarningPolicy:
    def __init__(self, abort_on_major_formatting_loss):
        self.abort_on_major_formatting_loss = abort_on_major_formatting_loss

    def get_action(self, warning_type):
        if warning_type in (WarningType.SourceFileCorruption, WarningType.DataLoss):
            return ReturnAction.Abort
        if warning_type == WarningType.MajorFormattingLoss and self.abort_on_major_formatting_loss:
            return ReturnAction.Abort
        return ReturnAction.Continue


class ReportingWarningCallback:
    def __init__(self, stage, report, policy):
        self.stage = stage
        self.report = report
        self.policy = policy

    def warning(self, warning):
        self.report.add(self.stage, warning)
        return self.policy.get_action(warning.getWarningType())


def process_presentation(input_path, report, policy):
    try:
        load_options = LoadOptions()
        handler = ReportingWarningCallback(OperationStage.Loading, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        load_options.setWarningCallback(callback)
        presentation = Presentation(input_path, load_options)
        try:
            if not render_first_slide(presentation, report, policy):
                return False
            if not convert_to_pdf(presentation, report, policy):
                return False
            return save_validated_copy(presentation, report, policy)
        finally:
            presentation.dispose()
    except Exception as exception:
        print(f"Loading stopped: {exception}", file=sys.stderr)
        return False


def render_first_slide(presentation, report, policy):
    if presentation.getSlides().size() == 0:
        print("Rendering stopped: the presentation has no slides.", file=sys.stderr)
        return False
    try:
        options = RenderingOptions()
        handler = ReportingWarningCallback(OperationStage.Rendering, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        image = presentation.getSlides().get_Item(0).getImage(options)
        try:
            image.save("slide-1.png", ImageFormat.Png)
            return True
        finally:
            image.dispose()
    except Exception as exception:
        print(f"Rendering stopped: {exception}", file=sys.stderr)
        return False


def convert_to_pdf(presentation, report, policy):
    try:
        options = PdfOptions()
        handler = ReportingWarningCallback(OperationStage.Conversion, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("converted.pdf", SaveFormat.Pdf, options)
        return True
    except Exception as exception:
        print(f"Conversion stopped: {exception}", file=sys.stderr)
        return False


def save_validated_copy(presentation, report, policy):
    try:
        options = PptxOptions()
        handler = ReportingWarningCallback(OperationStage.Saving, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("validated-output.pptx", SaveFormat.Pptx, options)
        return True
    except Exception as exception:
        print(f"Saving stopped: {exception}", file=sys.stderr)
        return False


def warning_type_name(warning_type):
    names = {
        WarningType.SourceFileCorruption: "SourceFileCorruption",
        WarningType.DataLoss: "DataLoss",
        WarningType.MajorFormattingLoss: "MajorFormattingLoss",
        WarningType.MinorFormattingLoss: "MinorFormattingLoss",
        WarningType.CompatibilityIssue: "CompatibilityIssue",
        WarningType.UnexpectedContent: "UnexpectedContent",
    }
    return names.get(warning_type, f"Unknown ({warning_type})")


report = WarningReport()
policy = WarningPolicy(True)
completed = process_presentation("input.pptx", report, policy)

print("Processing completed." if completed else "Processing stopped.")
for entry in report.get_entries():
    type_name = warning_type_name(entry.type)
    print(f"[{entry.stage.value}] {type_name}: {entry.description}")
```

هنگام ساخت `WarningPolicy` مقدار `False` را برای `abort_on_major_formatting_loss` پاس کنید اگر تفاوت‌های عمده قالب‌بندی قابل قبول هستند. مشکلات سازگاری، از دست رفتن قالب‌بندی جزئی و محتوای غیرمنتظره همچنان در گزارش نگه داشته می‌شوند حتی زمانی که عملیات ادامه می‌یابد. اگر برنامه باید هر یک از این دسته‌ها را رد کند، `WarningPolicy.get_action` را گسترش دهید.

## **سناریوهای رایج هشدار**

هشدارها می‌توانند در مراحل مختلف یک گردش کار ظاهر شوند:

- **امضاهای دیجیتال:** یک ارائه امضاشده می‌تواند هنگام بارگذاری هشدار دهد که امضا در طول پردازش از دست خواهد رفت. Aspose.Slides این وضعیت `DataLoss` را از طریق `IPresentationSignedWarningInfo` گزارش می‌دهد. یک فراخوانی در مرحله بارگذاری به برنامه اجازه می‌دهد فایل را رد کند یا به‌صورت صریح پذیرش از دست رفتن گزارش‌شده را اعلام کند.
- **جایگزینی قلم:** یک قلم غیرقابل دسترس می‌تواند هنگام رندر یا استخراج اسلاید جایگزین شود. هشدارهای جایگزینی قلم به عنوان `DataLoss` گزارش می‌شوند، بنابراین سیاست سخت‌گیرانه بالا حتی اگر برنامه جایگزینی خاصی را از نظر بصری قابل قبول بداند، متوقف می‌شود. برای مشاهده این رفتار، از یک ارائه ورودی حاوی متنی با قلمی که در زمان اجرا وجود ندارد استفاده کنید. توضیحات هشدار جایگزینی را شناسایی می‌کند؛ قلم‌های مورد نیاز را پیکربندی کنید یا [قوانین جایگزینی قلم](/slides/fa/python-java/font-substitution/) را قبل از تلاش مجدد تنظیم کنید.
- **محتوای غیرقابلسپاری یا غیرمنتظره:** یک بارگذار می‌تواند رکوردهای ارائه یا ویژگی‌هایی را که تشخیص نمی‌دهد، مواجه شود. چنین هشدارهایی ممکن است از `UnexpectedContent` استفاده کنند، یا در صورت تأثیر داده یا قالب‌بندی، دسته‌ای جدی‌تر داشته باشند.
- **سازگاری فرمت:** ذخیره به فرمت ارائه دیگری می‌تواند ویژگی‌ها را حذف کند یا نتیجه‌ای تولید کند که در برخی برنامه‌ها رفتار متفاوتی داشته باشد. به‌عنوان مثال، ذخیره یک ارائه با بیش از هشت راهنمای افقی یا عمودی به PPT قدیمی، یک `CompatibilityIssue` گزارش می‌دهد. فراخوانی در مرحله ذخیره می‌تواند از دست رفتن را ثبت کرده و ادامه دهد، یا اگر حفظ تمام راهنماها الزامی باشد، آن را رد کند.
- **رفتار بارگذاری:** گزینه‌های بارگذاری و رفتارهای قدیمی نیز می‌توانند هشدار تولید کنند. به‌عنوان مثال، `IObsoletePresLockingBehaviorWarningInfo` استفاده از رفتار قفل‌گذاری ارائه منسوخ را به‌عنوان `CompatibilityIssue` شناسایی می‌کند.

هشدارها به سند منبع، فرمت هدف، عملیات و نسخه Aspose.Slides وابسته‌اند. فرض نکنید هر فایل یک هشدار تولید می‌کند یا یک سناریو همیشه به یک دسته تنها نگاشت می‌شود.

## **به‌صورت ایمن مدیریت عملیات‌های متوقف‌شده**

زمانی که یک فراخوانی `ReturnAction.Abort` را برگرداند، از شی‌ای که بارگذاری نشده استفاده نکنید و فرض نکنید خروجی رندر یا ذخیره کامل است. عملیات ممکن است پس از ایجاد فایل خروجی اما قبل از اتمام آن متوقف شود.

نتایج معتبر را در مسیری جداگانه مانند `validated-output.pptx` ذخیره کنید. فقط پس از اتمام موفقیت‌آمیز عملیات، رضایت گزارش هشدار از سیاست برنامه و توانایی باز و بررسی خروجی، ارائه موجود را جایگزین کنید. این کار از نوشتن روی فایل منبع معتبر با نتیجهٔ جزئی یا رد‌شده جلوگیری می‌کند.

یک گزارش هشدار خالی تضمینی نیست که تمام ویژگی‌های منبع حفظ شده باشند. هر چک محتوا و بصری اضافی که برنامه نیاز دارد اعمال کنید. همچنین به [Open Presentations](/slides/fa/python-java/open-presentation/) و [Save Presentations](/slides/fa/python-java/save-presentation/) مراجعه کنید.

## **سؤال‌های متداول**

**آیا یک فراخوانی هشدار می‌تواند هر خطای Aspose.Slides را مدیریت کند؟**

خیر. این فقط شرایط قابل بازیابی را که به‌صورت هشدار گزارش می‌شوند، مدیریت می‌کند. استثناهایی که به‌صورت مستقل از فراخوانی رخ می‌دهند باید توسط برنامه در اطراف فراخوانی‌های بارگذاری، رندر، تبدیل یا ذخیره مدیریت شوند.

**آیا برگرداندن `ReturnAction.Continue` خروجی یکسانی را تضمین می‌کند؟**

خیر. این فقط اجازه ادامه پردازش را می‌دهد. وضعیت گزارش‌شده همچنان می‌تواند باعث تفاوت‌های داده، قالب‌بندی یا سازگاری شود، بنابراین نوع و توضیحات هشدارهای جمع‌آوری‌شده را بررسی کنید.

**برنامه چگونه می‌تواند عملیاتی که هشدار را تولید کرده شناسایی کند؟**

برای هر عملیات یک نمونه فراخوانی ایجاد کنید و مرحلهٔ تعریف‌شده توسط برنامه را همراه با مقادیر بازگردانده‌شده توسط `getWarningType` و `getDescription` ذخیره کنید، همان‌طور که در مثال نشان داده شده است.