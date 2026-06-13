---
title: یکپارچه‌سازی Aspose.Slides با Google Slides
linktitle: اسلایدهای Google
type: docs
weight: 50
url: /fa/net/integrating-aspose-slides-with-google-slides/
keywords:
- پلتفرم‌های ابری
- یکپارچه‌سازی ابری
- اسلایدهای Google
- Google Drive
- Google API
- حساب سرویس Google
- یکپارچه‌سازی SaaS
- OAuth 2.0
- PPT به PDF
- اتوماسیون PowerPoint
- پردازش ارائه
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides را با Google Slides متصل کنید تا ارائه‌ها را وارد، هماهنگ و تبدیل کنید، گردش‌کارها را خودکار کنید و PowerPoint و OpenDocument را در یک خط لوله نگه دارید."
---
## **مقدمه**

Aspose.Slides اکنون یکپارچه‌سازی با Google Slides و Google Drive را از طریق [SaaS Integration API](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) فراهم می‌کند. این یکپارچه‌سازی به برنامه‌های .NET امکان تبدیل، ویرایش، دانلود و بارگذاری ارائه‌های Google Slides را می‌دهد.

## **Google Slides چیست؟**
[Google Slides](https://workspace.google.com/products/slides/fa/) یک نرم‌افزار ارائه‌ای رایگان و مبتنی بر وب است که توسط Google توسعه یافته است. این سرویس به کاربران امکان ایجاد، ویرایش و به‌اشتراک‌گذاری ارائه‌های اسلایدی به‌صورت آنلاین را می‌دهد، مشابه Microsoft PowerPoint. از همکاری لحظه‌ای، ذخیره‌سازی ابری پشتیبانی می‌کند و بر روی هر دستگاهی که دسترسی به اینترنت دارد کار می‌کند.

## **Google API**
قبل از شروع به کار با ارائه Google Slides خود از طریق Aspose.Slides، باید یک پروژه Google API ایجاد کنید و یک [Google Cloud project](https://developers.google.com/workspace/guides/create-project) بسازید، سپس APIهای مورد نیاز را فعال کنید.

سپس باید روشی را که می‌خواهید به Google API دسترسی داشته باشید انتخاب کنید - [Aspose.Slides Google Integration](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) دو روش برای دسترسی به Google API را پشتیبانی می‌کند:
- `Google Service Account`
- `OAuth 2.0` با تعامل کاربر از طریق مرورگر.

### **حساب سرویس Google**
حساب سرویس یک حساب مخصوص Google است که توسط برنامه‌ها یا سرورها برای دسترسی برنامه‌نویسی به Google APIها بدون تعامل کاربر استفاده می‌شود. معمولاً برای سیستم‌های بک‌اند یا وظایف خودکار به‌کار می‌رود. حساب‌های سرویس با یک فایل کلید JSON احراز هویت می‌شوند و آدرس ایمیل خود را دارند. می‌توانند از طریق [Google Cloud IAM](https://cloud.google.com/iam/docs/overview) مجوزهای خاصی دریافت کنند و اغلب با APIهایی مانند Google Drive، Sheets یا BigQuery برای دسترسی امن و خودکار به منابع استفاده می‌شوند.

### **OAuth 2.0**
روش رایج دیگر برای دسترسی به Google APIها از طریق OAuth 2.0 با تعامل کاربر از طریق مرورگر است. در این جریان، کاربر به صفحه ورود Google منتقل می‌شود تا به برنامه اجازه دسترسی بدهد. پس از تأیید، برنامه یک کد مجوز دریافت می‌کند که آن را برای دریافت توکن دسترسی و توکن تازه‌سازی (refresh token) مبادله می‌کند.

توکن دسترسی، دسترسی موقت به Google APIها را فراهم می‌کند، در حالی که توکن تازه‌سازی می‌تواند ذخیره و برای دریافت توکن‌های دسترسی جدید بدون نیاز به ورود مجدد کاربر استفاده شود. یعنی تعامل مرورگر فقط یک بار ضرورت دارد و دسترسی‌های بعدی به‌صورت کامل خودکار می‌شود. این روش معمولاً برای برنامه‌هایی که نیاز به دسترسی به داده‌های کاربر (مانند Gmail، Calendar یا Drive) با رضایت کاربر دارند، به‌کار می‌رود.

## **بیایید کد بنویسیم**
اولین قدم افزودن بسته NuGet [Aspose.Slides SaaS Integration](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) به پروژه شماست:

```
dotnet add package Aspose.Slides.SaaSIntegrations
```

### **مثال ۱**
در مثال زیر، یک ارائه Google Slides را از Google Drive دانلود کرده و به‌عنوان فایل PDF در دیسک محلی ذخیره می‌کنیم. برای احراز هویت از یک حساب سرویس Google استفاده می‌کنیم، به‌طوری که فایل JSON حساب سرویس قبلاً دانلود شده باشد.

```csharp
// ایجاد HttpClient مدیریت‌شده به‌صورت خارجی
HttpClient httpClient = new HttpClient();

// ایجاد یک ارائه‌دهندهٔ احراز هویت با استفاده از فایل JSON حساب سرویس
IGoogleAuthorizationProvider account = new GoogleServiceAccountAuthProvider(@"service_account_json_file.json", httpClient);

// راه‌اندازی سرویس یکپارچه‌سازی Google Slides با ارائه‌دهندهٔ احراز هویت
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// بارگذاری یک ارائه از Google Drive با استفاده از شناسهٔ فایل آن به یک نمونهٔ IPresentation از Aspose.Slides
using IPresentation pres = await googleSlidesIntegration.LoadPresentationAsync("1A2B3C4D5E6F7G8H9I0J");

// در صورت نیاز، ارائه را اصلاح کنید (مثلاً حذف اسلاید دوم)
pres.Slides.RemoveAt(1);

// ذخیرهٔ ارائه به‌صورت فایل PDF به‌صورت محلی
pres.Save(@"GoogleDriveDownload.pdf", SaveFormat.Pdf);
```

برای راحتی، Aspose.Slides SaaS Integration متدی برای فهرست کردن همه فایل‌های قابل دسترس کاربران ارائه می‌دهد. داده‌های برگشتی شامل نام فایل، نوع MIME و شناسهٔ فایل (file ID) است.

```csharp
// دریافت فهرست فایل‌های قابل دسترس برای حساب سرویس ارائه‌شده
var availableFiles = await googleSlidesIntegration.GetDriveFileInfosAsync();

foreach (GoogleDriveFileInfo googleDriveFileInfo in availableFiles)
{
    Console.WriteLine($"File name: {googleDriveFileInfo.Name}, File ID: {googleDriveFileInfo.Id}, MIME type: {googleDriveFileInfo.MimeType}");
}
```

راه دیگر برای یافتن شناسهٔ فایل، باز کردن ارائه در برنامه وب Google Slides و پیدا کردن آن در URL است.

برای مثال، در URL زیر:

```
https://docs.google.com/presentation/d/1A2B3C4D5E6F7G8H9I0J/edit
```

شناسهٔ فایل به صورت زیر است:

```
1A2B3C4D5E6F7G8H9I0J
```

## **مثال ۲**
در مثال بعدی، یک ارائه PowerPoint را از صفر ایجاد می‌کنیم و آن را به‌صورت فرمت Google Slides به Google Drive بارگذاری می‌کنیم. برای احراز هویت از OAuth 2.0 استفاده می‌کنیم.

```csharp
// ایجاد HttpClient مدیریت‌شده به‌صورت خارجی
HttpClient httpClient = new HttpClient();

// ایجاد یک ارائه‌دهندهٔ احراز هویت با استفاده از OAuth همراه با شناسهٔ کلاینت و کلید مخفی
IGoogleAuthorizationProvider account = new GoogleOAuthProvider("clientId", "clientSecret", httpClient);

// راه‌اندازی سرویس یکپارچه‌سازی Google Slides با ارائه‌دهندهٔ احراز هویت
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// Create a sample presentation
using (var presentation = new Presentation())
{
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";
    
    // ذخیرهٔ ارائه در پوشهٔ ریشهٔ Google Drive به فرمت Google Slides
    // همچنین می‌توانید هر فرمت خروجی دیگری که توسط Aspose.Slides پشتیبانی می‌شود را انتخاب کنید
    var newFileId = await googleSlidesIntegration.SavePresentationAsync(presentation, "New presentation", GoogleSaveFormatType.GoogleSlides);
    Console.WriteLine($"Uploaded file ID: {newFileId}");
}
```

اگر از این نوع احراز هویت در برنامهٔ خود استفاده کنید، `interaction with the browser is required`. باید حساب خود را انتخاب کرده و تأیید کنید که برنامه می‌تواند به API Google Drive شما دسترسی داشته باشد. همین کافی است—این عملیات فقط در اولین اجرا ضروری است.

### **مثال ۳**
در مثال زیر از توکن دسترسی پیش‌دستهبند استفاده می‌کنیم. `GoogleAccessTokenAuthProvider` یک پیاده‌سازی از رابط `IGoogleAuthorizationProvider` است که از یک توکن دسترسی OAuth 2.0 موجود برای احراز درخواست‌ها به Google APIها استفاده می‌کند. بر خلاف ارائه‌دهندگانی که جریان OAuth را آغاز یا مدیریت می‌کنند، این کلاس به فراخواننده نیاز دارد تا یک توکن دسترسی معتبر فراهم کند.

این ارائه‌دهنده در سیستم‌هایی مفید است که توکن دسترسی به‌صورت خارجی (معمولاً توسط یک برنامهٔ فرانت‌اند یا سرویس دیگر) به‌دست آمده و به بک‌اند پاس داده می‌شود. به‌ویژه برای محیط‌های توزیع‌شده که مدیریت توکن‌های تازه‌سازی در سمت سرور می‌تواند پیچیدگی یا خطر عدم اعتبار توکن را به‌خاطر داشته باشد، مناسب است.

این مثال نشان می‌دهد چگونه می‌توان یک فایل را جایگزین و نام آن را در Google Drive به‌روزرسانی کرد، در حالی که شناسهٔ فایل حفظ می‌شود.

```csharp
// ایجاد یک مشتری HTTP برای ارسال درخواست‌ها
using HttpClient httpClient = new HttpClient();

// تنظیم احراز هویت Google Drive با استفاده از توکن دسترسی
GoogleAccessTokenAuthProvider accessTokenAuthProvider = new GoogleAccessTokenAuthProvider("access_token");

// راه‌اندازی یکپارچه‌سازی با Google Slides/Drive با استفاده از احراز هویت و مشتری HTTP
GoogleSlidesIntegration googleSlidesIntegration =
    new GoogleSlidesIntegration(accessTokenAuthProvider, httpClient);

// ایجاد یک ارائه نمونه با استفاده از Aspose.Slides
using (var presentation = new Presentation())
{
    // افزودن شکل مستطیل به اولین اسلاید و تنظیم متن آن
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";

    // تعریف گزینه‌های ذخیره‌سازی PDF با کیفیت و تنظیمات سازگاری خاص
    ISaveOptions saveOptions = new PdfOptions()
    {
        JpegQuality = 50,
        Compliance = PdfCompliance.PdfA1b
    };

    // ذخیره (جایگزینی) فایل موجود در Google Drive با شناسهٔ فایل، به‌روزرسانی نام آن و خروجی به صورت PDF
    await googleSlidesIntegration.SavePresentationToExistingFileAsync(
        presentation,
        "1A2B3C4D5E6F7G8H9I0J",            // شناسهٔ فایل موجود در Google Drive
        GoogleSaveFormatType.Pdf,         // فرمت دلخواه برای ذخیره‌سازی
        saveOptions,           
        "NewFileName.pdf"                 // نام جدید برای اختصاص به فایل
    );
}
```

## **خلاصه**
Aspose.Slides اکنون از یک فرمت فایل اضافی برای مدیریت پشتیبانی می‌کند و خودکارسازی گردش کاری مبتنی بر ابر برای ایجاد، به‌اشتراک‌گذاری و ویرایش ارائه‌ها را ساده می‌سازد.

این مقاله به ویژگی‌های اساسی پرداخته است. می‌توانید فایل‌ها را در زیرپوشه‌ها ذخیره کنید، فایل‌های موجود را جایگزین کنید و به فرمت‌های مختلف—نه فقط ارائه‌های Google Slides—به Google Drive صادر کنید.

Aspose.Slides SaaS Integration به‌طور مستمر پشتیبانی از پلتفرم‌های ارائه SaaS را گسترش خواهد داد، بنابراین برای به‌روزرسانی‌های آینده مراجعه کنید.

## **پرسش‌های متداول**

**آیا برای استفاده از این یکپارچه‌سازی به حساب Google Workspace نیاز دارم؟**  
خیر. می‌توانید از یک حساب Google رایگان یا یک حساب Google Workspace استفاده کنید. دسترسی مورد نیاز بستگی به مجوزهای شما در Google Drive و Slides دارد.

**کدام روش احراز هویت را باید انتخاب کنم—Service Account یا OAuth 2.0؟**  
از **Service Account** برای گردش‌های کاری بک‌اند یا خودکار بدون تعامل کاربر استفاده کنید.  
از **OAuth 2.0** استفاده کنید اگر نیاز به دسترسی به فایل‌های Google Slides یا Drive کاربر خاصی با رضایت او دارید.

**آیا می‌توانم با فرمت‌های دیگری جز Google Slides کار کنم؟**  
بله. Aspose.Slides امکان ذخیره ارائه‌ها در فرمت‌های مختلف (مانند PDF، PPTX، HTML) را پیش از بارگذاری به Google Drive فراهم می‌کند.

**چگونه می‌توانم شناسهٔ فایل یک ارائه Google Slides را به‌دست آورم؟**  
می‌توانید با استفاده از متد `GetDriveFileInfosAsync()` آن را بازیابی کنید یا از URL ارائه در Google Slides کپی کنید.

**آیا یکپارچه‌سازی قابلیت جایگزینی یک فایل موجود در Google Drive را دارد؟**  
بله. از متد `SavePresentationToExistingFileAsync` برای به‌روزرسانی یک فایل با حفظ شناسهٔ آن استفاده کنید.

**آیا برای استفاده از OAuth 2.0 هر بار نیاز به تعامل مرورگر است؟**  
خیر. تعامل مرورگر فقط در اولین بار احراز هویت لازم است. پس از آن توکن‌های تازه‌سازی ذخیره‌شده دسترسی خودکار را امکان‌پذیر می‌کنند.