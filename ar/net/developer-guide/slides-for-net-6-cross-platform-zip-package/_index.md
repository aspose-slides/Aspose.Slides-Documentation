---
title: "Aspose.Slides لـ .NET 6 متعدد المنصات (حزمة ZIP)"
type: docs
weight: 237
url: /ar/net/slides-for-net-6-cross-platform-zip-package/
aliases:
  - /net/slides-for-net-6-cross-platform/
keywords:
  - متعدد المنصات
  - .NET 6
  - GLIBC
  - csproj
  - مسار الهدف
  - مكتبة تابعة
  - Aspose.Slides.dll
  - System.Drawing.Common
  - تعارض الأسماء
  - اسم مستعار خارجي
  - CS0433
  - PowerPoint
  - OpenDocument
  - عرض تقديمي
  - .NET
  - C#
  - Aspose.Slides
description: "استخدم Aspose.Slides لـ .NET 6 لبناء تطبيقات C# متعددة المنصات على أنظمة Windows وLinux وmacOS تقوم بإنشاء وتعديل وتحويل ملفات PowerPoint بصيغ PPT وPPTX وODP."
---
## **نظرة عامة**

تشرح هذه المقالة طريقة استخدام Aspose.Slides for .NET 6 Cross-Platform من حزمة ZIP. وتصف كيفية تنزيل الحزمة، فك ملفات المجلد `net6.0/crossplatform`، إضافة مرجع إلى `Aspose.Slides.dll`، وتكوين ملف المشروع بحيث تُنسخ المكتبات التابعة المطلوبة إلى دليل إخراج التطبيق.

كما تصف المقالة محتويات حزمة cross‑platform، بما في ذلك التجميع الأساسي Aspose.Slides .NET ومكتبات نظام الرسوميات الخاصة بالمنصات لنظام Windows وLinux وmacOS.

{{% alert title="Note" color="primary" %}}
Aspose.Slides for .NET 6 Cross-Platform متوفر أيضًا عبر [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform).
{{% /alert %}}

## **استخدام Aspose.Slides Cross‑Platform من حزمة ZIP**

1. تنزيل حزمة ZIP لأحدث نسخة من Aspose.Slides من [صفحة الإصدار](https://releases.aspose.com/slides/ar/net/).  
2. فك الملفات من *Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* ووضعها في المجلد الذي سيُستخدم للاعتمادات في مشروعك.  
3. إضافة مرجع إلى Aspose.Slides.dll.

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   في مثالنا (أدناه) توجد المكتبات في مجلد المشروع على هذا المسار: *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![browse-console-app](browse-console-app.jpg)

4. وضع الملفات المتبقية (التي تعتمد عليها Aspose.Slides) في دليل الإخراج بإضافة تعليمات إلى ملف المشروع csproj بهذه الطريقة:

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

5. الانتباه إلى `TargetPath`.

   بشكل افتراضي، `<CopyToOutputDirectory>` ينسخ الملفات مع الحفاظ على مسارها النسبي، لكننا نحتاج إلى أن تُنسَخ المكتبات التابعة إلى نفس المجلد الذي يُولد فيه الإخراج (موقع Aspose.Slides.dll).

## **ملاحظات**

### **نظام الرسوميات المملوك**

Aspose.Slides cross‑platform هو مجموعة من المكتبات:

| Aspose.Slides.dll                                          | التجميع الأساسي .NET المسؤول عن جميع منطق Aspose.Slides |
| ---------------------------------------------------------- | -------------------------------------------------------- |
| aspose.slides.drawing.capi_vc14x64.dll                     | اعتماد: تنفيذ نظام الرسوميات لنظام Win x64               |
| aspose.slides.drawing.capi_vc14x86.dll                     | اعتماد: تنفيذ نظام الرسوميات لنظام Win x64               |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | اعتماد: تنفيذ نظام الرسوميات لنظام Linux (x86/x64)      |
| libaspose.slides.drawing.capi_appleclang_x86_64.dylib      | اعتماد: تنفيذ نظام الرسوميات لنظام macOS AMD64 (x86-64/x64) |
| libaspose.slides.drawing.capi_appleclang_arm64.dylib       | اعتماد: تنفيذ نظام الرسوميات لنظام macOS ARM64 (AArch64) |

يستخدم Aspose.Slides.dll المكتبة المطلوبة من النظام الذي يعمل عليه. عادةً ما تكون المكتبات موجودة في نفس موقع Aspose.Slides.dll في أي نظام ملفات.

### **هيكل حزمة ZIP**

تحتوي حزمة ZIP على بنية المجلدات التالية:

Aspose.Slides
├─── net6.0
│  ├─── crossplatform
│  └─── default
├─── net20
├─── net462
└─── netstandard2.0

* كل مجلد يحتوي على تجميعات للإصدار .NET المقابل. هناك نسختان لـ net6.0: default وcrossplatform. الأخيرة تحتوي على Aspose.Slides.dll متعدد المنصات وجميع تبعياته. يمكن استخدام المحتويات المفكوكة لهذا المجلد كإضافة اعتماد في مشروع لتطوير متعدد المنصات وحالات استخدام أخرى لـ Aspose.Slides.

## **انظر أيضاً**

- [متطلبات النظام](/slides/ar/net/system-requirements/)