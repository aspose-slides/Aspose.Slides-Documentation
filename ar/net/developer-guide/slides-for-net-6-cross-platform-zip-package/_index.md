---
title: Aspose.Slides for .NET 6 عبر المنصات (حزمة ZIP)
type: docs
weight: 237
url: /ar/net/slides-for-net-6-cross-platform-zip-package/
aliases:
  - /net/slides-for-net-6-cross-platform/
keywords:
- عبر-المنصات
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
description: "استخدم Aspose.Slides for .NET 6 لبناء تطبيقات C# عبر المنصات على Windows وLinux وmacOS التي تنشئ وتحرر وتحول ملفات PowerPoint PPT وPPTX وODP."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية استخدام Aspose.Slides for .NET 6 Cross-Platform من حزمة ZIP. وتوضح طريقة تنزيل الحزمة، استخراج الملفات من المجلد `net6.0/crossplatform`، إضافة مرجع إلى `Aspose.Slides.dll`، وتكوين ملف المشروع بحيث تُنسخ المكتبات التابعة المطلوبة إلى دليل إخراج التطبيق.

تصف المقالة أيضًا محتويات الحزمة عبر‑المنصات، بما في ذلك تجميع Aspose.Slides .NET الرئيسي ومكتبات نظام الرسوميات المتخصص للمنصات Windows وLinux وmacOS.

{{% alert title="Note" color="info" %}}
Aspose.Slides for .NET 6 Cross-Platform متاح أيضًا على [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform).
{{% /alert %}}

## **استخدام Aspose.Slides عبر‑المنصات من حزمة ZIP**

1. تنزيل حزمة ZIP لأحدث نسخة من Aspose.Slides من [صفحة الإصدار](https://releases.aspose.com/slides/ar/net/).

2. استخراج الملفات من *Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* ووضعها في المجلد الذي سيُستخدم كاعتماديات في مشروعك.

3. إضافة مرجع إلى Aspose.Slides.dll.

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   في مثالنا (أدناه)، المكتبات موجودة في مجلد المشروع على هذا المسار: *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![browse-console-app](browse-console-app.jpg)

4. وضع الملفات المتبقية (التي تعتمد عليها Aspose.Slides) في دليل الإخراج بإضافة التعليمات إلى ملف مشروع csproj بهذه الطريقة:

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

   بشكل افتراضي، `<CopyToOutputDirectory>` ينسخ الملفات مع الحفاظ على مسارها النسبي، لكننا نحتاج إلى أن تذهب المكتبات التابعة إلى نفس المجلد الذي يُنشأ فيه الإخراج (موقع Aspose.Slides.dll).

## **ملاحظات**

### **نظام الرسوميات المملوك**

Aspose.Slides عبر‑المنصات هو مجموعة من المكتبات:

| Aspose.Slides.dll                                          | التجميع الرئيسي لـ .NET المسؤول عن كل منطق Aspose.Slides                 |
| ---------------------------------------------------------- | -------------------------------------------------------------------------- |
| aspose.slides.drawing.capi_vc14x64.dll                     | تبعية: تنفيذ نظام الرسوميات لنظام Windows x64                  |
| aspose.slides.drawing.capi_vc14x86.dll                     | تبعية: تنفيذ نظام الرسوميات لنظام Windows x64                  |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | تبعية: تنفيذ نظام الرسوميات لنظام Linux (x86/x64)          |
| libaspose.slides.drawing.capi_appleclang_x86_64.dylib      | تبعية: تنفيذ نظام الرسوميات لنظام macOS AMD64 (x86-64/x64) |
| libaspose.slides.drawing.capi_appleclang_arm64.dylib       | تبعية: تنفيذ نظام الرسوميات لنظام macOS ARM64 (AArch64)    |

يستخدم Aspose.Slides.dll المكتبة التي يتطلبها النظام الذي يعمل عليه. عادةً ما تكون المكتبات موجودة في نفس موقع Aspose.Slides.dll في أي نظام ملفات.

### **بنية حزمة ZIP**

تحتوي حزمة ZIP على بنية المجلدات التالية:

  Aspose.Slides

  ├─── net6.0

  │  ├─── crossplatform

  │  └─── default

  ├─── net20

  ├─── net462

  └─── netstandard2.0

* كل مجلد يحتوي على التجميعات الخاصة بإصداره .NET المقابل. هناك نسختان لـ net6.0: default وcrossplatform. الأخيرة تحتوي على Aspose.Slides.dll عبر‑المنصات وكل تبعياته. يمكن استخدام المحتويات المفكوكة لهذا المجلد كإضافة اعتماد في مشروع لتطوير عبر‑المنصات وحالات استخدام Aspose.Slides الأخرى.

## **انظر أيضًا**

- [System Requirements](/slides/ar/net/system-requirements/)