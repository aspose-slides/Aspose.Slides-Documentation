---
title: Aspose.Slides برای .NET 6 کراس‑پلتفرم (بسته ZIP)
type: docs
weight: 237
url: /fa/net/slides-for-net-6-cross-platform-zip-package/
keywords:
- کراس‑پلتفرم
- .NET 6
- GLIBC
- csproj
- مسیر هدف
- کتابخانه وابسته
- Aspose.Slides.dll
- System.Drawing.Common
- تضاد نام
- نام مستعار خارجی
- CS0433
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "از Aspose.Slides برای .NET 6 برای ساخت برنامه‌های C# چندپلتفرمی در ویندوز، لینوکس و macOS استفاده کنید که قادر به ایجاد، ویرایش و تبدیل فایل‌های PowerPoint PPT، PPTX و ODP هستند."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه از Aspose.Slides برای .NET 6 Cross-Platform از یک بسته ZIP استفاده کنید. این مقاله توصیف می‌کند چگونه بسته را دانلود کنید، فایل‌ها را از پوشه `net6.0/crossplatform` استخراج کنید، مرجع `Aspose.Slides.dll` را اضافه کنید و فایل پروژه را طوری پیکربندی کنید که کتابخانه‌های وابسته مورد نیاز به پوشه خروجی برنامه کپی شوند.

مقاله همچنین محتویات بسته کراس‑پلتفرم را شرح می‌دهد، شامل اسمبلی اصلی Aspose.Slides .NET و کتابخانه‌های زیرسیستم گرافیکی مخصوص هر پلتفرم برای ویندوز، لینوکس و macOS.

{{% alert title="Note" color="primary" %}}

Aspose.Slides برای .NET 6 Cross-Platform همچنین از طریق [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) در دسترس است.

{{% /alert %}}

## **استفاده از Aspose.Slides کراس‑پلتفرم از یک بسته ZIP**

1. بسته ZIP جدیدترین نسخه Aspose.Slides را از [صفحه انتشار](https://releases.aspose.com/slides/fa/net/) دانلود کنید.  

2. فایل‌ها را از *Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* استخراج کنید و در پوشه‌ای که برای وابستگی‌ها در پروژهٔ خود استفاده می‌شود، قرار دهید.  

3. مرجع به `Aspose.Slides.dll` را اضافه کنید.  

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   در مثال ما (در زیر) کتابخانه‌ها در پوشهٔ پروژه در این مسیر قرار دارند: *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*  

   ![browse-console-app](browse-console-app.jpg)

4. فایل‌های باقی‌مانده (که Aspose.Slides به آن‌ها نیاز دارد) را با افزودن دستورات به فایل پروژهٔ csproj به پوشه خروجی کپی کنید:

```xml
<ItemGroup>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\aspose.slides.drawing.capi_vc14x64.dll">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>aspose.slides.drawing.capi_vc14x64.dll</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\aspose.slides.drawing.capi_vc14x86.dll">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>aspose.slides.drawing.capi_vc14x86.dll</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\Aspose.Slides.xml">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>Aspose.Slides.xml</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang_x86_64.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_appleclang_x86_64.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang_arm64.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_appleclang_arm64.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so</TargetPath>
   </None>

</ItemGroup>
```

5. به `TargetPath` توجه کنید.  

   به طور پیش‌فرض، `<CopyToOutputDirectory>` فایل‌ها را همراه با مسیر نسبیشان کپی می‌کند، اما ما نیاز داریم کتابخانه‌های وابسته به همان پوشه‌ای که خروجی تولید می‌شود (محل `Aspose.Slides.dll`) رفته‌اند.

## **نکات**

### **زیرسیستم گرافیکی اختصاصی**

Aspose.Slides کراس‑پلتفرم مجموعه‌ای از کتابخانه‌هاست:

| Aspose.Slides.dll                                          | اسمبلی اصلی .NET که مسئول تمام منطق Aspose.Slides است |
| ---------------------------------------------------------- | ------------------------------------------------------ |
| aspose.slides.drawing.capi_vc14x64.dll                     | وابستگی: پیاده‌سازی زیرسیستم گرافیکی برای Win x64      |
| aspose.slides.drawing.capi_vc14x86.dll                     | وابستگی: پیاده‌سازی زیرسیستم گرافیکی برای Win x64      |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | وابستگی: پیاده‌سازی زیرسیستم گرافیکی برای Linux (x86/x64) |
| libaspose.slides.drawing.capi_appleclang_x86_64.dylib      | وابستگی: پیاده‌سازی زیرسیستم گرافیکی برای macOS AMD64 (x86-64/x64) |
| libaspose.slides.drawing.capi_appleclang_arm64.dylib       | وابستگی: پیاده‌سازی زیرسیستم گرافیکی برای macOS ARM64 (AArch64) |

Aspose.Slides.dll از کتابخانه‌ای استفاده می‌کند که سیستم اجرا کننده آن نیاز دارد. کتابخانه‌ها معمولاً در همان مکانی که `Aspose.Slides.dll` قرار دارد، در هر فایل سامانه‌ای یافت می‌شوند.

### **ساختار بسته ZIP**

بسته ZIP ساختار پوشه‌های زیر را دارد:

Aspose.Slides
├─── net6.0
│   ├─── crossplatform
│   └─── default
├─── net20
├─── net462
└─── netstandard2.0

* هر پوشه شامل اسمبلی‌های مربوط به نسخهٔ .NET متناظر است. برای net6.0 دو نسخه وجود دارد: default و crossplatform. نسخهٔ دوم شامل `Aspose.Slides.dll` کراس‑پلتفرم و تمام وابستگی‌های آن است. محتویات استخراج شدهٔ این پوشه می‌تواند به‌عنوان افزودنی وابستگی در یک پروژه برای توسعهٔ کراس‑پلتفرم و سایر موارد استفادهٔ Aspose.Slides استفاده شود.

## **همچنین ببینید**

- [نیازمندی‌های سیستم](/slides/fa/net/system-requirements/)