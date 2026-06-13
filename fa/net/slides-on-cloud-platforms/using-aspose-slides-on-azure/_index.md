---
title: استفاده از Aspose.Slides در Azure
linktitle: آژور
type: docs
weight: 10
url: /fa/net/using-aspose-slides-on-azure/
keywords:
- پلتفرم‌های ابری
- یکپارچه‌سازی ابری
- مایکروسافت آژور
- توابع Azure
- PPT به PDF
- ذخیره‌سازی Blob
- بدون سرور
- پردازش سند
- پاورپوینت
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "از Aspose.Slides در سرویس برنامه Azure، توابع و کانتینرها برای تولید، ویرایش و تبدیل PPT، PPTX و ODP در برنامه‌های مقیاس‌پذیر ابری .NET استفاده کنید."
---
## **مقدمه**
Aspose.Slides یک کتابخانه قدرتمند برای مدیریت ارائه‌های PowerPoint به‌صورت برنامه‌نویسی است. هنگامی که بر روی Microsoft Azure مستقر می‌شود، مقیاس‌پذیری، قابلیت اطمینان و یکپارچه‌سازی بی‌نظیر با سرویس‌های مختلف ابری را فراهم می‌کند. این مقاله به مزایای استفاده از Aspose.Slides در Azure می‌پردازد، امکان‌های یکپارچه‌سازی را بررسی می‌کند و راهنمای تنظیم محیط را ارائه می‌دهد.

## **مزایا**
استفاده از Aspose.Slides در Azure مزایای متعددی دارد، از جمله:
- **قابلیت مقیاس‌پذیری**: زیرساخت Azure به شما اجازه می‌دهد برنامه‌هایتان را به‌صورت پویا مقیاس‌گذاری کنید.  
  - *یادداشت واقعی:* برای مثال می‌توانید به‌صورت خودکار چندین نمونه Azure Function را هنگام تبدیل دسته‌جویی بزرگ فایل‌های PowerPoint به PDF مقیاس‌گذاری کنید. با بهره‌گیری از مقیاس‌پذیری پویا Azure می‌توانید نوسانات بارگذاری فایل را بدون دخالت دستی مدیریت کنید.
- **قابلیت اطمینان**: Microsoft دسترسی بالا و تحمل خطا را در سراسر دیتاسنترهای خود تضمین می‌کند.  
  - *یادداشت واقعی:* در شرایط عملی، اگر یک منطقه دچار زمان‌وقفه یا تاخیر زیاد شود، قابلیت‌های Failover Azure اطمینان می‌دهند که تبدیل‌های PPT شما در منطقه دیگری ادامه یابد و سرویس بدون وقفه باقی بماند.
- **امنیت**: Azure ویژگی‌های امنیتی داخلی برای حفاظت از برنامه‌ها و داده‌های شما فراهم می‌کند.  
  - *یادداشت واقعی:* یک رویکرد معمول این است که ارائه‌های حساس را در یک Blob container ایمن ذخیره کنید و سپس کنترل دسترسی مبتنی بر نقش (RBAC) را یکپارچه کنید تا فقط Azure Functions مجاز بتوانند برای پردازش به آنها دسترسی داشته باشند.
- **یکپارچه‌سازی یکپارچه**: سرویس‌های Azure مانند Azure Functions، Blob Storage و App Services قابلیت‌های Aspose.Slides را ارتقا می‌دهند.  
  - *یادداشت واقعی و مثال کد:* می‌توانید یک Logic App تنظیم کنید که هر زمان یک فایل PowerPoint در Blob Storage قرار گرفت، یک Azure Function را اجرا کند. در زیر نمونه‌ای از قطعه کد برای مدیریت همزمانی با پردازش هر فایل بارگذاری‌شده به‌صورت موازی آورده شده است:

    ```cs
    [FunctionName("BulkConvertPptToPdf")]
    public static async Task RunAsync(
        [BlobTrigger("incoming-presentations/{name}", Connection = "AzureWebJobsStorage")] Stream inputFile,
        string name,
        [Blob("output-pdfs/{name}.pdf", FileAccess.Write, Connection = "AzureWebJobsStorage")] Stream outputFile,
        ILogger log)
    {
        log.LogInformation($"Converting {name} to PDF in parallel...");
        
        // مثال مدیریت همزمانی: 
        // این می‌تواند بخشی از یک هماهنگ‌کننده دسته‌ای بزرگتر باشد که فایل‌ها را تقسیم می‌کند یا به صورت همزمان پردازش می‌کند.
        using (var presentation = new Presentation(inputFile))
        {
            presentation.Save(outputFile, SaveFormat.Pdf);
        }

        log.LogInformation("Conversion completed successfully.");
    }
    ```
  - در یک خط لوله واقعی، می‌توانید چندین Trigger و اجراهای موازی پیکربندی کنید تا هر فایل ارائه سریعاً پردازش شود—حتی وقتی صدها بارگذاری همزمان رخ می‌دهد.

## **یکپارچه‌سازی با سرویس‌ها**
Aspose.Slides می‌تواند با سرویس‌های مختلف Azure یکپارچه شود تا خودکارسازی گردش کار و پردازش اسناد بهینه شود. برخی از یکپارچه‌سازی‌های رایج عبارتند از:
- **Azure Blob Storage**: ذخیره و بازیابی فایل‌های ارائه به‌صورت بهینه.  
  *یادداشت واقعی:* برای تبدیل دسته‌جویی شبانه، می‌توانید ده‌ها یا حتی صدها فایل PPT را در یک Blob container بارگذاری کنید. سپس هر فایل به‌صورت خودکار در یک خط لوله بدون سرور پردازش می‌شود.
- **Azure Functions**: خودکارسازی ایجاد و پردازش ارائه‌ها با استفاده از محاسبات بدون سرور.  
  *یادداشت واقعی:* به‌عنوان مثال، یک Azure Function می‌تواند هر زمان یک فایل PowerPoint جدید در Blob Storage شناسایی شد، بلافاصله آن را به PDF یا تصاویر تبدیل کند بدون نیاز به ماشین مجازی اختصاصی.
- **Azure App Services**: استقرار برنامه‌های وب که ارائه‌ها را به‌صورت لحظه‌ای ایجاد و دستکاری می‌کنند.  
  *یادداشت واقعی:* یک برنامه وب .NET میزبانی کنید که به کاربران امکان بارگذاری فایل‌های PPT، ویرایش محتوی اسلایدها و سپس دانلود PDF تبدیل شده را می‌دهد—و به‌صورت خودکار با افزایش ترافیک مقیاس می‌گیرد.
- **Azure Logic Apps**: ایجاد گردش کارهای خودکار که فایل‌های PowerPoint را مدیریت می‌کنند.  
  *یادداشت واقعی:* می‌توانید پس از یک تبدیل موفق، اقداماتی مانند ارسال اعلان ایمیل یا به‌روزرسانی پایگاه داده را زنجیره‌ای کنید و به‌راحتی فرآیندهای انتها به انتها را با کد سفارشی کم بسازید.

## **راه‌اندازی محیط**
برای شروع استفاده از Aspose.Slides در Azure، باید سرویس‌های ابری مناسب را تنظیم کنید. هنگام انتخاب بین خدمات Azure، موارد زیر را در نظر بگیرید:
- **Azure Functions** برای پردازش بدون سرور ارائه‌ها.
- **Azure Virtual Machines** برای میزبانی برنامه‌های نیازمند سفارشی‌سازی بالا.
- **Azure Kubernetes Service (AKS)** برای استقرار برنامه‌های مبتنی بر Aspose.Slides در کانتینر.
- **Azure App Services** برای اجرای برنامه‌های وب با ویژگی‌های مقیاس‌پذیری داخلی.

## **موارد استفاده رایج**
Aspose.Slides در Azure امکان برنامه‌های واقعی متنوعی را فراهم می‌کند، از جمله:
- **تولید گزارش خودکار**: ایجاد گزارش‌های PowerPoint پویا از پایگاه‌های داده.
- **ویرایش آنلاین ارائه**: ارائه ابزار وب تعاملی برای تغییر اسلایدها به کاربران.
- **پردازش دسته‌جویی**: تبدیل تعداد زیادی ارائه به فرمت‌های مختلف با استفاده از Azure Functions.
- **امنیت ارائه**: اعمال حفاظت با رمز عبور و امضاهای دیجیتال بر فایل‌های PowerPoint.

## **مثال: خودکارسازی تبدیل PPT به PDF با استفاده از Azure Functions**
در زیر نمونه‌ای از یک Azure Function آورده شده است که فایل PowerPoint ذخیره‌شده در Azure Blob Storage را پردازش کرده و به PDF تبدیل می‌کند با استفاده از Aspose.Slides:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

public static class ConvertPptToPdf
{
    [FunctionName("ConvertPptToPdf")]
    public static void Run(
        [BlobTrigger("presentations/{name}", Connection = "AzureWebJobsStorage")] Stream inputBlob, string name,
        [Blob("pdfs/{name}.pdf", FileAccess.Write, Connection = "AzureWebJobsStorage")] Stream outputBlob, ILogger log)
    {
        try
        {
            log.LogInformation($"Processing file: {name}");
            using (var presentation = new Presentation(inputBlob))
            {
                presentation.Save(outputBlob, SaveFormat.Pdf);
            }
            log.LogInformation("Conversion successful.");
        }
        catch (Exception ex)
        {
            log.LogError($"Error processing file: {ex.Message}");
        }
    }
}
```

این تابع زمانی که یک فایل PowerPoint به Azure Blob Storage بارگذاری می‌شود فعال می‌شود و به‌صورت خودکار آن را به PDF تبدیل کرده و خروجی را در یک Blob container دیگر ذخیره می‌کند.

با بهره‌گیری از Aspose.Slides در Azure، توسعه‌دهندگان می‌توانند راه‌حل‌های قوی، مقیاس‌پذیر و خودکار برای پردازش اسناد PowerPoint بسازند.