---
title: مدیریت برچسب‌های حساسیت در ارائه‌های PowerPoint در .NET
linktitle: برچسب‌های حساسیت
type: docs
weight: 50
url: /fa/net/sensitivity-labels/
keywords:
- برچسب حساسیت
- Microsoft Purview
- Microsoft Information Protection
- متادیتای MIP
- علامت‌گذاری محتوا
- حفاظت از اطلاعات
- حاکمیت سند
- PowerPoint
- PPTX
- امنیت ارائه
- .NET
- C#
- Aspose.Slides
description: "خواندن، افزودن، به‌روزرسانی، حذف و انتقال برچسب‌های حساسیت Microsoft Purview در ارائه‌های PPTX پاورپوینت با Aspose.Slides برای .NET."
---
## **بررسی کلی**

برچسب‌های حساسیت Microsoft Purview به سازمان‌ها کمک می‌کنند تا اسناد را طبقه‌بندی و حاکمیت کنند. در هنگام پردازش خودکار ارائه، ممکن است برنامه نیاز داشته باشد برچسب موجود را حفظ کند، برچسبی که توسط سیاست انتخاب شده اعمال کند، وضعیت آن را به‌روزرسانی کند یا فراداده برچسب را که توسط یک جریان کاری قدیمی Microsoft Information Protection (MIP) نوشته شده است، منتقل کند.

Aspose.Slides متادیتای برچسب‌های حساسیت مدرن را از طریق [Presentation.SensitivityLabels](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/sensitivitylabels/) در دسترس می‌گذارد. این ویژگی یک [ISensitivityLabelCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabelcollection/) را برمی‌گرداند که می‌توان قبل از ذخیره ارائه به‌صورت PPTX، آن را بررسی و تغییر داد.

{{% alert color="info" title="Note" %}}
شناسه‌های برچسب‌های حساسیت و اطلاعات سیاست توسط پیکربندی Microsoft Purview شما تعریف می‌شوند. پیش از افزودن یا انتقال متادیتا، دسترسی به برچسب و الزامات سیاست را در محیط خود اعتبارسنجی کنید. مقادیر [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabel/contentmarktypes/) نوع علامت‌گذاری محتوا مرتبط با یک برچسب را توصیف می‌کنند؛ آنها به تنهایی متن یا شکل‌های قابل رؤیت را به اسلایدها اضافه نمی‌کنند.
{{% /alert %}}

## **درک ویژگی‌های برچسب حساسیت**

هر [ISensitivityLabel](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabel/) شامل متادیتای زیر است:

| ویژگی | هدف |
| --- | --- |
| [ISensitivityLabel.Id](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabel/id/) | شناسه برچسب حساسیت در سیاست Purview را تعیین می‌کند. |
| [ISensitivityLabel.SiteId](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabel/siteid/) | سایت مرتبط با سیاست برچسب را شناسایی می‌کند. |
| [ISensitivityLabel.IsEnabled](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabel/isenabled/) | نشان می‌دهد آیا برچسب فعال است یا نه. |
| [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabel/isremoved/) | نشان می‌دهد برچسب حذف شده است. وقتی حالت حذف باید در متادیتا حفظ شود، این ویژگی را به `true` تنظیم کنید. |
| [ISensitivityLabel.AssignmentMethodType](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabel/assignmentmethodtype/) | مشخص می‌کند برچسب به‌صورت خودکار یا بر اساس تصمیم کاربر اعمال شده است. |
| [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabel/contentmarktypes/) | فهرست انواع علامت‌گذاری محتوا مرتبط با برچسب را ارائه می‌دهد. |

enum [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/fa/net/aspose.slides/sensitivitylabelassignmenttype/) توصیف می‌کند برچسب چگونه اختصاص یافته است:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/fa/net/aspose.slides/sensitivitylabelassignmenttype/) برچسب پیش‌فرض یا به‌صورت خودکار اعمال‌شده را نشان می‌دهد.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/fa/net/aspose.slides/sensitivitylabelassignmenttype/) برچسبی را توصیف می‌کند که از طریق تصمیم کاربر، شامل برچسب‌های دستی، پیشنهادی و اجباری، اعمال شده است.

enum [SensitivityLabelContentType](https://reference.aspose.com/slides/fa/net/aspose.slides/sensitivitylabelcontenttype/) نوع علامت‌گذاری مرتبط با برچسب را شناسایی می‌کند:

| مقدار | معنی |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/fa/net/aspose.slides/sensitivitylabelcontenttype/) | برچسب به‌صورت پیش‌فرض یا خودکار اعمال شده است. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/fa/net/aspose.slides/sensitivitylabelcontenttype/) | علامت‌گذاری محتوای سرصفحه به برچسب مرتبط است. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/fa/net/aspose.slides/sensitivitylabelcontenttype/) | علامت‌گذاری محتوای پاورقی به برچسب مرتبط است. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/fa/net/aspose.slides/sensitivitylabelcontenttype/) | علامت‌گذاری محتوای واترمارک به برچسب مرتبط است. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/fa/net/aspose.slides/sensitivitylabelcontenttype/) | حفاظت رمزنگاری‌شده به برچسب مرتبط است. |

چندین نوع علامت‌گذاری می‌توانند به یک برچسب مرتبط شوند.

## **فهرست برچسب‌های حساسیت موجود**

مجموعه برچسب‌های مدرن را از [Presentation.SensitivityLabels](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/sensitivitylabels/) بخوانید و آن را مرور کنید. مثال زیر هر ویژگی و علامت‌گذاری محتوا ذخیره‌شده برای هر برچسب را فهرست می‌کند:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

foreach (var sensitivityLabel in sensitivityLabels)
{
    Console.WriteLine("Label ID: " + sensitivityLabel.Id);
    Console.WriteLine("Site ID: " + sensitivityLabel.SiteId);
    Console.WriteLine("Enabled: " + sensitivityLabel.IsEnabled);
    Console.WriteLine("Removed: " + sensitivityLabel.IsRemoved);
    Console.WriteLine("Assignment method: " + sensitivityLabel.AssignmentMethodType);

    foreach (var contentMarkType in sensitivityLabel.ContentMarkTypes)
    {
        Console.WriteLine("Content marking: " + contentMarkType);
    }
}
```

## **افزودن برچسب حساسیت با علامت‌گذاری محتوا**

از [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabelcollection/add/) همراه با شناسه برچسب، شناسه سایت، وضعیت فعال بودن و روش اختصاص استفاده کنید. پس از بازگرداندن [ISensitivityLabel](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabel/) جدید، مقادیر علامت‌گذاری مورد نیاز را از طریق [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabel/contentmarktypes/) اضافه نمایید.

مثال زیر برچسبی که به‌صورت دستی انتخاب شده و با علامت‌گذاری‌های پاورقی و واترمارک مرتبط است را اضافه می‌کند و سپس نتیجه را به‌صورت PPTX ذخیره می‌کند:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

var labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
var siteIdentifier = Guid.Parse("{aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee}");
var isEnabled = true;
var assignmentMethod = SensitivityLabelAssignmentType.Privileged;

var sensitivityLabel = sensitivityLabels.Add(
    labelIdentifier,
    siteIdentifier,
    isEnabled,
    assignmentMethod);

sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Footer);
sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Watermark);

presentation.Save("presentation_with_label.pptx", SaveFormat.Pptx);
```

## **به‌روزرسانی یک برچسب حساسیت**

ویژگی‌های [ISensitivityLabel](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabel/) قابلیت خواندن/نوشتن دارند، به‌جز این که مجموعه‌ای که توسط [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabel/contentmarktypes/) برگردانده می‌شود، از طریق عملیات لیست آن اصلاح می‌شود. پس از یافتن برچسب مورد نیاز، می‌توانید شناسه، شناسه سایت، وضعیت فعال بودن، روش اختصاص، وضعیت حذف و انواع علامت‌گذاری محتوا را به‌روز کنید. برای حفظ تغییرات ارائه را ذخیره کنید.

مثال زیر وضعیت فعال بودن و روش اختصاص اولین برچسب را به‌روزرسانی می‌کند:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

if (sensitivityLabels.Count > 0)
{
    var sensitivityLabel = sensitivityLabels[0];
    sensitivityLabel.IsEnabled = true;
    sensitivityLabel.AssignmentMethodType = SensitivityLabelAssignmentType.Privileged;
}

presentation.Save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
```

## **علامت‌گذاری برچسب حساسیت به عنوان حذف‌شده**

برای حفظ این واقعیت که یک برچسب حذف شده است، برچسب را پیدا کنید و [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabel/isremoved/) را به `true` تنظیم کنید. این کار ورود برچسب را نگه می‌دارد و وضعیت حذف آن را ثبت می‌کند. اگر به‌جای آن می‌خواهید ورودی را از مجموعه مدرن حذف کنید، از [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabelcollection/removeat/) استفاده کنید؛ برای حذف همه ورودی‌ها از [ISensitivityLabelCollection.Clear](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabelcollection/clear/) استفاده کنید.

مثال زیر یک برچسب خاص را به‌عنوان حذف‌شده علامت‌گذاری کرده و ارائه به‌روز شده را ذخیره می‌کند:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;
var targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

foreach (var sensitivityLabel in sensitivityLabels)
{
    var isTargetLabel = string.Equals(
        sensitivityLabel.Id,
        targetLabelIdentifier,
        StringComparison.OrdinalIgnoreCase);

    if (isTargetLabel)
    {
        sensitivityLabel.IsRemoved = true;
        break;
    }
}

presentation.Save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
```

## **خواندن و انتقال برچسب‌های حساسیت قدیمی MIP**

جریان‌های کاری مبتنی بر MIP قدیمی می‌توانند متادیتای برچسب حساسیت را در خصوصیات سفارشی سند به جای مجموعه مدرن برچسب ذخیره کنند. این متادیتا را با [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/fa/net/aspose.slides/idocumentproperties/getsensitivitylabels/) بخوانید. این متد خصوصیات سفارشی قدیمی را تجزیه کرده و آرایه‌ای از اشیای [ISensitivityLabel](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabel/) را برمی‌گرداند.

برای انتقال متادیتا، هر برچسب بازگردانده‌شده را از طریق [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabelcollection/add/) به [ISensitivityLabelCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabelcollection/) مدرن اضافه کنید. چون افزودن شناسه برچسب تکراری منجر به استثنا می‌شود، مثال قبل از کپی هر برچسب، مجموعه مقصد را بررسی می‌کند. می‌توانید اعتبارسنجی بیشتری اضافه کنید تا اطمینان حاصل شود هر برچسب قدیمی هنوز در سیاست جاری Purview وجود دارد.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation_with_legacy_labels.pptx");
var legacySensitivityLabels = presentation.DocumentProperties.GetSensitivityLabels();
var modernSensitivityLabels = presentation.SensitivityLabels;

foreach (var legacySensitivityLabel in legacySensitivityLabels)
{
    var labelAlreadyExists = false;

    foreach (var modernSensitivityLabel in modernSensitivityLabels)
    {
        labelAlreadyExists = string.Equals(
            modernSensitivityLabel.Id,
            legacySensitivityLabel.Id,
            StringComparison.OrdinalIgnoreCase);

        if (labelAlreadyExists)
        {
            break;
        }
    }

    if (!labelAlreadyExists)
    {
        modernSensitivityLabels.Add(legacySensitivityLabel);
    }
}

presentation.Save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
```

انتقال، اشیای برچسب تجزیه‌شده را به مجموعه مدرن کپی می‌کند. این کار نیازی به پاک‌سازی تمام خصوصیات سفارشی سند ندارد، بنابراین متادیتای نامرتبط سند دست‌نخورده باقی می‌ماند. با استفاده از [IPresentation.Save](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentation/save/) همراه با [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/net/aspose.slides.export/saveformat/) متادیتای برچسب مدرن را در فایل PPTX بنویسید.

## **پرسش‌های متداول**

**آیا افزودن نوع علامت‌گذاری محتوا یک سرصفحه، پاورقی یا واترمارک قابل رؤیت بر روی اسلایدها ایجاد می‌کند؟**

خیر. مقادیری که از طریق [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabel/contentmarktypes/) اضافه می‌شوند، توصیف‌کننده علامت‌گذاری‌های مرتبط با برچسب حساسیت هستند. آنها متن یا شکل‌های قابل رؤیت در ارائه ایجاد نمی‌کنند. اگر گردش کار شما نیاز به رندر این علامت‌گذاری‌ها دارد، محتویات مربوط به اسلاید را به‑صورت جداگانه اضافه کنید.

**تفاوت علامت‌گذاری یک برچسب به عنوان حذف‌شده و حذف آن از مجموعه چیست؟**

تنظیم [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabel/isremoved/) به `true` ورودی برچسب را حفظ می‌کند و وضعیت حذف آن را ثبت می‌نماید. فراخوانی [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabelcollection/removeat/) ورودی را از مجموعه مدرن حذف می‌کند. عملیاتی را انتخاب کنید که با نیازهای نگهداری متادیتای سازمان شما سازگار باشد.

**آیا یک ارائه می‌تواند هم متادیتای MIP قدیمی و هم برچسب‌های حساسیت مدرن را داشته باشد؟**

بله. برچسب‌های قدیمی می‌توانند در خصوصیات سفارشی سند باقی بمانند، در حالی که برچسب‌های مدرن از طریق [Presentation.SensitivityLabels](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/sensitivitylabels/) در دسترس هستند. برای خواندن متادیتای قدیمی از [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/fa/net/aspose.slides/idocumentproperties/getsensitivitylabels/) استفاده کنید و فقط برچسب‌های معتبر که پیش‌تر در مجموعه مدرن وجود ندارند را منتقل کنید.

**زمانی که برچسبی با همان شناسه بیش از یک بار اضافه شود چه می‌شود؟**

[ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabelcollection/add/) هنگامیکه مجموعه قبلاً شامل برچسبی با همان شناسه باشد، یک `ArgumentException` پرتاب می‌کند. پیش از افزودن یا انتقال برچسب‌ها، مقادیر موجود [ISensitivityLabel.Id](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabel/id/) را بررسی کنید.

**برای حفظ برچسب‌های حساسیت به‌روزرسانی‌شده کدام فرمت خروجی باید استفاده شود؟**

ارائه را به‌صورت PPTX ذخیره کنید با فراخوانی [IPresentation.Save](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentation/save/) همراه با [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/net/aspose.slides.export/saveformat/)، همان‌طور که در مثال‌های بالا نشان داده شده است.