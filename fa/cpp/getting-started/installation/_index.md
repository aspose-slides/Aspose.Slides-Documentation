---
title: نصب
type: docs
weight: 70
url: /fa/cpp/installation/
keywords:
- نصب Aspose.Slides
- دانلود Aspose.Slides
- استفاده از Aspose.Slides
- نصب Aspose.Slides
- ویندوز
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه Aspose.Slides برای C++ را به سرعت نصب کنید. راهنمای گام به گام، نیازمندی‌های سیستم و نمونه‌های کد — امروز کار با ارائه‌های PowerPoint را آغاز کنید!"
---
## **بررسی کلی**

این مقاله نحوه نصب Aspose.Slides را در ویندوز توضیح می‌دهد. تمرکز آن بر نصب مبتنی بر NuGet است و نشان می‌دهد چگونه کتابخانه را به یک پروژه در Visual Studio اضافه کنید، چه از طریق NuGet Package Manager و چه از طریق Package Manager Console در ویندوز. همچنین نحوه به‌روزرسانی بسته و نصب نسخه‌های پیش‌انتشار را در صورت نیاز تشریح می‌کند.

## **ویندوز**
NuGet ساده‌ترین مسیر برای دانلود و نصب APIهای Aspose برای C++ روی کامپیوترها را فراهم می‌کند. 

### **گزینه یک: نصب یا به‌روزرسانی Aspose.Slides برای C++ از NuGet Package Manager**

1. Microsoft Visual Studio را باز کنید.  
2. یک برنامه‌ی کنسول ساده ایجاد کنید یا می‌توانید پروژه‌ی مورد نظر خود را باز کنید.  
3. از **Tools** > **NuGet package manager** عبور کنید.  
4. در بخش **Browse**، عبارت *Aspose.Slides.Cpp* را در فیلد متنی تایپ کنید.  

![todo:image_alt_text](installation_1.png)

3. نسخه مورد نیاز **Aspose.Slides.Cpp** را انتخاب کنید و سپس روی **Install** کلیک کنید.  
   * اگر می‌خواهید Aspose.Slides را به‌روزرسانی کنید (به این معنی که قبلاً نصب شده است) به جای آن روی **Update** کلیک کنید.  

API انتخابی دانلود شده و در پروژه شما ارجاع داده می‌شود.

### **گزینه ۲: نصب یا به‌روزرسانی Aspose.Slides از طریق Package Manager Console**

برای ارجاع به [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.Cpp/) با استفاده از Package Manager Console، مراحل زیر را انجام دهید:

1. راه‌حل/پروژه خود را در Visual Studio باز کنید.  

1. از **Tools** > **NuGet Package Manager** > **Package Manager Console** عبور کنید.  

   کنسول Package Manager باز می‌شود.  

![todo:image_alt_text](installation_2.png)

4. این فرمان را تایپ کنید: `Install-Package Aspose.Slides.Cpp` 
> اگر می‌خواهید نسخه x86 را نصب کنید، بسته Aspose.Slides.Cpp.x86 را استفاده کنید: `Install-Package Aspose.Slides.Cpp.x86`

5. کلید Enter را فشار دهید.

   جدیدترین نسخه کامل در برنامه شما نصب می‌شود.  

   * به‌جای آن می‌توانید پسوند `-prerelease` را به فرمان اضافه کنید تا آخرین نسخه (شامل هات‌فیکس‌ها) نیز نصب شود.

![todo:image_alt_text](installation_3.png)

​	زمانی که دانلود به پایان رسید، پیام‌های تأیید مشاهده خواهید کرد.  

![todo:image_alt_text](installation_4.png)

اگر با [EULA Aspose](https://about.aspose.com/legal/eula) آشنایی ندارید، ممکن است بخواهید مجوز اشاره‌شده در URL را بخوانید.  

در Package Manager Console می‌توانید فرمان `Update-Package Aspose.Slides.Cpp` را اجرا کنید تا به‌روزرسانی‌های بسته Aspose.Slides را بررسی کنید. به‌روزرسانی‌ها (در صورت وجود) به‌صورت خودکار نصب می‌شوند. همچنین می‌توانید از پسوند `-prerelease` برای به‌روزرسانی آخرین نسخه استفاده کنید.


### **استفاده از پوشه‌های Include و lib**
1. [Download](https://downloads.aspose.com/slides/fa/cpp) آخرین نسخه Aspose.Slides برای C++ را دریافت کنید.  
1. پوشه را در محیط تولید باز کنید.  
1. برای استفاده از Aspose.Slides برای C++، پوشه‌های Include و lib را در پروژه خود ارجاع دهید.

## **سوالات متداول**

**آیا نسخه رایگان یا محدودیت‌های آزمایشی وجود دارد؟**

بله، به‌طور پیش‌فرض Aspose.Slides در حالت ارزیابی اجرا می‌شود که واترمارک‌ها را اضافه می‌کند و ممکن است محدودیت‌های دیگری داشته باشد. برای حذف این محدودیت‌ها باید یک [license](/slides/fa/cpp/licensing/) معتبر اعمال کنید.