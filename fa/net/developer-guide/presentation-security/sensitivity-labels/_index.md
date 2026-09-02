---
title: مدیریت برچسب‌های حساسیّت در ارائه‌های پاورپوینت در .NET
linktitle: برچسب‌های حساسیّت
type: docs
weight: 50
url: /fa/net/sensitivity-labels/
keywords:
- برچسب حساسیّت
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
description: "خواندن، افزودن، به‌روزرسانی، حذف و انتقال برچسب‌های حساسیّت Microsoft Purview در ارائه‌های PPTX پاورپوینت با Aspose.Slides برای .NET."
---
## **نمای کلی**

Microsoft Purview sensitivity labels به سازمان‌ها کمک می‌کند تا اسناد را طبقه‌بندی و مدیریت کنند. در هنگام پردازش خودکار ارائه‌، ممکن است برنامه نیاز داشته باشد برچسب موجود را حفظ کند، برچسب انتخاب‌شده توسط سیاست را اعمال کند، وضعیت آن را به‌روزرسانی کند یا فراداده برچسب نوشته‌شده توسط یک گردش کار قدیمی Microsoft Information Protection (MIP) را منتقل کند.

Aspose.Slides متاداده‌های مدرن برچسب حساسیت را از طریق [Presentation.SensitivityLabels](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/sensitivitylabels/) در دسترس قرار می‌دهد. این ویژگی یک [ISensitivityLabelCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabelcollection/) را برمی‌گرداند که می‌توان قبل از ذخیره ارائه به صورت PPTX آن را بررسی و تغییر داد.

{{% alert color="primary" title="Note" %}}
شناسه‌های برچسب حساسیت و اطلاعات سیاست توسط پیکربندی Microsoft Purview شما تعریف می‌شوند. پیش از افزودن یا انتقال متادیتا، قابلیت دسترسی به برچسب‌ها و الزامات سیاست را در محیط خود بررسی کنید. مقادیر [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabel/contentmarktypes/) نوع علامت‌گذاری‌های محتوا را که به یک برچسب مرتبط هستند توصیف می‌کنند؛ این مقادیر به تنهایی متن یا شکل‌های قابل مشاهده‌ای را بر روی اسلایدها اضافه نمی‌کنند.
{{% /alert %}}

## **درک ویژگی‌های برچسب حساسیت**

هر [ISensitivityLabel](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabel/) شامل متاداده‌های زیر است:

| Property | Purpose |
| --- | --- |
| [ISensitivityLabel.Id](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabel/id/) | شناسه برچسب حساسیت در سیاست Purview را تعیین می‌کند. |
| [ISensitivityLabel.SiteId](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabel/siteid/) | سایت مرتبط با سیاست برچسب را شناسایی می‌کند. |
| [ISensitivityLabel.IsEnabled](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabel/isenabled/) | نشان می‌دهد آیا برچسب فعال است یا خیر. |
| [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabel/isremoved/) | نشان می‌دهد برچسب حذف شده است. هنگام نیاز به نگهداری وضعیت حذف در متادیتا، این ویژگی را به `true` تنظیم کنید. |
| [ISensitivityLabel.AssignmentMethodType](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabel/assignmentmethodtype/) | مشخص می‌کند برچسب به صورت خودکار یا از طریق تصمیم کاربر اعمال شده است. |
| [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabel/contentmarktypes/) | انواع علامت‌گذاری محتوا را که به برچسب مرتبط هستند فهرست می‌کند. |

شناسهٔ [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/fa/net/aspose.slides/sensitivitylabelassignmenttype/) توصیف می‌کند برچسب چگونه اختصاص داده شده است:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/fa/net/aspose.slides/sensitivitylabelassignmenttype/) نمایانگر یک برچسب پیش‌فرض یا خودکار است.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/fa/net/aspose.slides/sensitivitylabelassignmenttype/) نمایانگر برچسبی است که از طریق تصمیم کاربر اعمال شده، شامل برچسب‌های دستی، پیشنهادی و اجباری می‌شود.

شناسهٔ [SensitivityLabelContentType](https://reference.aspose.com/slides/fa/net/aspose.slides/sensitivitylabelcontenttype/) نوع علامت‌گذاری مرتبط با یک برچسب را مشخص می‌کند:

| Value | Meaning |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/fa/net/aspose.slides/sensitivitylabelcontenttype/) | برچسب به‌صورت پیش‌فرض یا خودکار اعمال شده است. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/fa/net/aspose.slides/sensitivitylabelcontenttype/) | علامت‌گذاری محتوا در هدر با برچسب مرتبط است. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/fa/net/aspose.slides/sensitivitylabelcontenttype/) | علامت‌گذاری محتوا در فوتر با برچسب مرتبط است. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/fa/net/aspose.slides/sensitivitylabelcontenttype/) | علامت‌گذاری محتوا به صورت واترمارک با برچسب مرتبط است. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/fa/net/aspose.slides/sensitivitylabelcontenttype/) | محافظت با رمزنگاری به برچسب مربوط می‌شود. |

چندین نوع علامت‌گذاری می‌تواند به یک برچسب وابسته باشد.

## **فهرست برچسب‌های حساسیت موجود**

مجموعه برچسب‌های مدرن را از [Presentation.SensitivityLabels](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/sensitivitylabels/) بخوانید و آن را مرور کنید. مثال زیر هر ویژگی و علامت‌گذاری محتوایی که برای هر برچسب ذخیره شده است را لیست می‌کند:

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

از [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabelcollection/add/) همراه با شناسه برچسب، شناسه سایت، حالت فعال و روش تخصیص استفاده کنید. پس از اینکه متد برچسب جدید را برگرداند، مقادیر علامت‌گذاری مورد نیاز را از طریق [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabel/contentmarktypes/) اضافه کنید.

مثال زیر برچسبی به‌صورت دستی انتخاب‌شده که با علامت‌گذاری‌های فوتر و واترمارک مرتبط است اضافه می‌کند و سپس نتیجه را به صورت PPTX ذخیره می‌نماید:

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

## **به‌روزرسانی برچسب حساسیت**

ویژگی‌های [ISensitivityLabel](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabel/) قابل خواندن و نوشتن هستند، به‌جز اینکه مجموعه بازگردانده‌شده توسط [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabel/contentmarktypes/) از طریق عملیات لیست خود اصلاح می‌شود. پس از یافتن برچسب موردنظر، می‌توانید شناسه، شناسه سایت, حالت فعال, روش تخصیص, وضعیت حذف و انواع علامت‌گذاری محتوا را به‌روزرسانی کنید. برای حفظ تغییرات ارائه را ذخیره کنید.

مثال زیر حالت فعال و روش تخصیص اولین برچسب را به‌روزرسانی می‌کند:

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

## **علامت‌گذاری یک برچسب حساسیت به‌عنوان حذف‌شده**

برای نگه‌داری اطلاعات اینکه یک برچسب حذف شده است، برچسب را پیدا کنید و [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabel/isremoved/) را به `true` تنظیم کنید. این کار ورودی برچسب را حفظ می‌کند و وضعیت حذف آن را ثبت می‌نماید. اگر به‌جای آن می‌خواهید ورودی را از مجموعهٔ مدرن حذف کنید، از [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabelcollection/removeat/) استفاده کنید؛ برای حذف تمام ورودی‌ها از [ISensitivityLabelCollection.Clear](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabelcollection/clear/) بهره بگیرید.

مثال زیر برچسب خاصی را به‌عنوان حذف‌شده علامت‌گذاری می‌کند و ارائه به‌روز شده را ذخیره می‌نماید:

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

گردش‌کارهای قدیمی مبتنی بر MIP می‌توانند متاداده‌های برچسب حساسیت را در ویژگی‌های سفارشی سند به جای مجموعه مدرن برچسب ذخیره کنند. این متاداده‌ها را با [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/fa/net/aspose.slides/idocumentproperties/getsensitivitylabels/) بخوانید. این متد ویژگی‌های سفارشی قدیمی را تجزیه می‌کند و آرایه‌ای از اشیاء [ISensitivityLabel](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabel/) را برمی‌گرداند.

برای انتقال متاداده‌ها، هر برچسب بازگردانده‌شده را از طریق [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabelcollection/add/) به مجموعهٔ مدرن [ISensitivityLabelCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabelcollection/) اضافه کنید. چون افزودن شناسهٔ برچسب تکراری یک استثنا ایجاد می‌کند، مثال قبل از کپی کردن هر برچسب مجموعه مقصد را بررسی می‌کند. می‌توانید اعتبارسنجی‌های بیشتری برای اطمینان از وجود برچسب‌های قدیمی در سیاست جاری Purview اضافه کنید.

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

انتقال، اشیاء برچسب تجزیه‌شده را به مجموعهٔ مدرن کپی می‌کند. این کار نیازی به پاک‌سازی تمام ویژگی‌های سفارشی سند ندارد، بنابراین متاداده‌های غیرمرتبط سند دست‌نخورده می‌مانند. برای نوشتن متاداده‌های مدرن برچسب به یک فایل PPTX از [IPresentation.Save](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentation/save/) همراه با [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/net/aspose.slides.export/saveformat/) استفاده کنید.

## **سوالات متداول**

**آیا افزودن یک نوع علامت‌گذاری محتوا هدر، فوتر یا واترمارک قابل مشاهده‌ای روی اسلایدها ایجاد می‌کند؟**

نه. مقادیری که از طریق [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabel/contentmarktypes/) اضافه می‌شوند، نوع علامت‌گذاری‌های مرتبط با برچسب حساسیت را توصیف می‌کنند و متن یا شکل‌های قابل مشاهده‌ای در ارائه ایجاد نمی‌کنند. اگر جریان کار شما نیاز به رندرسازی این علامت‌گذاری‌ها داشته باشد، محتویات اسلاید مربوطه را جداگانه اضافه کنید.

**تفاوت علامت‌گذاری یک برچسب به‌عنوان حذف‌شده و حذف آن از مجموعه چیست؟**

تنظیم [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabel/isremoved/) به `true` ورودی برچسب را حفظ می‌کند و وضعیت حذف آن را ثبت می‌نماید. فراخوانی [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabelcollection/removeat/) ورودی را از مجموعهٔ مدرن حذف می‌کند. عملیاتی را انتخاب کنید که با الزامات نگهداری متادیتای سازمان شما همخوانی داشته باشد.

**آیا یک ارائه می‌تواند هم متادیتای MIP قدیمی و هم برچسب‌های حساسیت مدرن را شامل شود؟**

بله. برچسب‌های قدیمی می‌توانند در ویژگی‌های سفارشی سند باقی بمانند، در حالی که برچسب‌های مدرن از طریق [Presentation.SensitivityLabels](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/sensitivitylabels/) در دسترس هستند. برای خواندن متادیتای قدیمی از [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/fa/net/aspose.slides/idocumentproperties/getsensitivitylabels/) استفاده کنید و فقط برچسب‌های معتبر که هنوز در مجموعهٔ مدرن وجود ندارند را منتقل کنید.

**چه اتفاقی می‌افتد وقتی یک برچسب با همان شناسه بیش از یک‌بار افزوده شود؟**

[ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabelcollection/add/) هنگامیکه مجموعه قبلاً حاوی برچسبی با همان شناسه باشد، یک `ArgumentException` پرتاب می‌کند. قبل از افزودن یا انتقال برچسب‌ها، مقادیر [ISensitivityLabel.Id](https://reference.aspose.com/slides/fa/net/aspose.slides/isensitivitylabel/id/) موجود را بررسی کنید.

**کدام قالب خروجی برای حفظ برچسب‌های حساسیت به‌روز شده باید استفاده شود؟**

برای حفظ برچسب‌های حساسیت به‌روز شده، ارائه را به صورت PPTX با فراخوانی [IPresentation.Save](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentation/save/) همراه با [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/net/aspose.slides.export/saveformat/) ذخیره کنید، همانطور که در مثال‌های بالا نشان داده شده است.