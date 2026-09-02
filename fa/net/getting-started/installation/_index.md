---
title: نصب
type: docs
weight: 70
url: /fa/net/installation/
keywords:
- نصب Aspose.Slides
- دریافت Aspose.Slides
- استفاده از Aspose.Slides
- نصب Aspose.Slides
- ویندوز
- لینوکس
- macOS
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "بیاموزید چگونه Aspose.Slides برای .NET را به سرعت نصب کنید. راهنمای قدم به قدم، نیازمندی‌های سیستم و نمونه‌های کد - امروز با ارائه‌های PowerPoint کار را آغاز کنید!"
---
## **نمای کلی**

این مقاله نحوهٔ نصب Aspose.Slides برای .NET را در ویندوز، لینوکس و macOS توضیح می‌دهد. تمرکز آن بر نصب مبتنی بر NuGet است و نشان می‌دهد چگونه کتابخانه را از طریق NuGet Package Manager یا Package Manager Console در ویندوز، به یک پروژه .NET در لینوکس، و به یک پروژه Visual Studio در macOS اضافه کنید. همچنین نحوه به‌روزرسانی بسته و نصب نسخه‌های پیش‌انتشار در صورت نیاز را شرح می‌دهد.

قبل از نصب، سیستم‌عامل‌های پشتیبانی‌شده، پیاده‌سازی‌های .NET و وابستگی‌های اضافه را در [نیازمندی‌های سیستم](/slides/fa/net/system-requirements/) مرور کنید.

## **ویندوز**
NuGet ساده‌ترین مسیر برای بارگیری و نصب Aspose APIها برای .NET بر روی رایانه‌های شخصی را فراهم می‌کند. 

### **روش 1: نصب یا به‌روزرسانی Aspose.Slides از NuGet Package Manager**

1. Microsoft Visual Studio را باز کنید. 
2. یک برنامه کنسول ساده ایجاد کنید یا پروژهٔ موجود را باز کنید. 
3. از **Tools** > **NuGet package manager** عبور کنید.
4. در بخش **Browse**، *Aspose Slides* را در فیلد متنی جستجو کنید. 
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. روی **Aspose.Slides.NET** کلیک کنید و سپس **Install** را فشار دهید. 
   * اگر می‌خواهید Aspose.Slides را به‌روزرسانی کنید—به شرط اینکه قبلاً نصب کرده باشید—به‌جای آن **Update** را کلیک کنید. 

API انتخاب‌شده دانلود شده و در پروژهٔ شما ارجاع می‌شود.

### **روش 2: نصب یا به‌روزرسانی Aspose.Slides از طریق Package Manager Console**

این چگونگی ارجاع به [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) از طریق کنسول مدیریت بسته است:

1. Microsoft Visual Studio را باز کنید. 
2. یک برنامه کنسول ساده ایجاد کنید یا پروژهٔ موجود را باز کنید. 
3. از **Tools** > **Library Package Manager** > **Package Manager Console** عبور کنید. 
![todo:image_alt_text](installation_2.png)
4. این فرمان را اجرا کنید: `Install-Package Aspose.Slides.NET` 
![todo:image_alt_text](installation_3.png)
آخرین نسخهٔ کامل در برنامهٔ شما نصب می‌شود. 

* به‌علاوه، می‌توانید پسوند `-prerelease` را به فرمان اضافه کنید تا آخرین نسخه (شامل اصلاحات فوری) نیز نصب شود.

نکتهٔ **Installing Aspose.Slides.NET** در پایین پنجره ظاهر می‌شود. 
![todo:image_alt_text](installation_4.png)

پس از تکمیل دانلود، باید پیام‌های تأیید را ببینید. 

اگر با [Aspose EULA](https://about.aspose.com/legal/eula) آشنایی ندارید، ممکن است بخواهید مجوز موجود در URL را بخوانید. 
![todo:image_alt_text](installation_5.png)

در برنامهٔ شما، باید ببینید که Aspose.Slides با موفقیت اضافه و ارجاع شده است. 
![todo:image_alt_text](installation_6.png)

در Package Manager Console، می‌توانید فرمان `Update-Package Aspose.Slides.NET` را اجرا کنید تا به‌روزرسانی‌های بستهٔ Aspose.Slides را بررسی کنید. به‌روزرسانی‌ها (در صورت موجود بودن) به‌صورت خودکار نصب می‌شوند. همچنین می‌توانید از پسوند `-prerelease` برای به‌روزرسانی آخرین نسخه استفاده کنید.

#### **ملاحظات هنگام اجرا در محیط سرور مشترک**
ما قویاً توصیه می‌کنیم تمام اجزای Aspose .NET را با مجموعهٔ دسترسی **Full Trust** اجرا کنید زیرا گاهی اجزای Aspose نیاز به دسترسی به تنظیمات رجیستری و فایل‌های واقع در مکان‌های دیگری جز دایرکتوری مجازی دارند—به‌عنوان مثال، زمانی که اجزای Aspose باید قلم‌ها را بخوانند. 

علاوه بر این، اجزای Aspose.NET بر پایهٔ کلاس‌های اصلی سیستم .NET ساخته شده‌اند—and برخی از این کلاس‌ها نیز برای برخی عملیات به دسترسی Full Trust نیاز دارند.

ارائه‌دهندگان سرویس اینترنت (ISP) که برنامه‌های متعددی از شرکت‌های مختلف را میزبانی می‌کنند، غالباً سطح امنیتی Medium Trust را اعمال می‌کنند. در مورد .NET 2.0، چنین سطح امنیتی ممکن است محدودیت‌هایی ایجاد کند که بر عملکرد Aspose.Slides تأثیر می‌گذارد:

- **RegistryPermission** در دسترس نیست. این به این معناست که نمی‌توانید به رجیستری دسترسی داشته باشید، که برای فهرست‌برداری از قلم‌های نصب‌شده هنگام رندر اسناد لازم است.
- **FileIOPermission** محدود شده است. این به این معنی است که فقط می‌توانید به فایل‌ها در سلسله‌مراتب دایرکتوری مجازی برنامهٔ خود دسترسی داشته باشید. این همچنین ممکن است به این معنا باشد که قلم‌ها در عملیات صادرات قابل خواندن نیستند.

به‌دلیل موارد فوق، قویاً توصیه می‌کنیم Aspose.Slides را با دسترسی‌های **Full Trust** اجرا کنید. اگر از **Medium trust** استفاده کنید، ممکن است با ناهماهنگی‌ها مواجه شوید—برخی ویژگی‌های کتابخانه (مانند رندر) ممکن است در انجام برخی کارها کار نکند.

## **لینوکس**

NuGet ساده‌ترین مسیر برای بارگیری و نصب Aspose.Slides برای .NET در لینوکس را فراهم می‌کند. بستهٔ [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) را به پروژهٔ .NET خود اضافه کنید.

## **macOS**

NuGet ساده‌ترین مسیر برای بارگیری و نصب Aspose.Slides برای .NET بر روی مک‌ها را فراهم می‌کند.

### **نصب Aspose.Slides**

1. Visual Studio را باز کنید. 
2. یک برنامه کنسول ساده ایجاد کنید یا پروژهٔ موجود را باز کنید.
3. از **Project** > **Manage NuGet Packages...** عبور کنید.
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. متن *Aspose.Slides* را در فیلد متنی وارد کنید. 
5. روی **Aspose.Slides for .NET** کلیک کنید و سپس **Add Package** را فشار دهید. 
6. یک قطعه کد ساده اضافه کنید.
   * می‌توانید کد را از [این صفحه](/slides/fa/net/create-presentation/) کپی کنید.
7. برنامه را اجرا کنید.
8. پوشهٔ *folder/bin/Debug/presentation_file_name* پروژه‌تان را باز کنید.

## **سؤالات متداول**

**آیا نسخهٔ رایگان یا محدودیت آزمایشی وجود دارد؟**

بله، به طور پیش‌فرض Aspose.Slides در حالت ارزیابی اجرا می‌شود که واترمارک اضافه می‌کند و ممکن است محدودیت‌های دیگری داشته باشد. برای حذف محدودیت‌ها، باید یک [license](/slides/fa/net/licensing/) معتبر اعمال کنید.