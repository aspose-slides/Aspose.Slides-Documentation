---
title: Aspose.Slides لـ .NET 6 متعدد المنصات (حزمة ZIP)
type: docs
weight: 237
url: /ar/net/slides-for-net-6-cross-platform-zip-package/
keywords:
- متعدد المنصات
- .NET 6
- GLIBC
- csproj
- مسار الهدف
- مكتبة تعتمد
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
description: "استخدم Aspose.Slides لـ .NET 6 لبناء تطبيقات C# متعددة المنصات على Windows و Linux و macOS لإنشاء وتحرير وتحويل ملفات PowerPoint PPT و PPTX و ODP."
---

{{% alert title="Note" color="primary" %}}

Aspose.Slides for .NET 6 Cross-Platform متاح أيضاً من [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform).

{{% /alert %}}

## **استخدام Aspose.Slides عبر المنصة من حزمة ZIP**

1. قم بتنزيل حزمة ZIP لأحدث نسخة من Aspose.Slides من [Release Page](https://releases.aspose.com/slides/net/).

2. افك ضغط الملفات من *Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* وضعها في المجلد الذي سيتم استخدامه كاعتمادات في مشروعك.

3. أضف مرجعاً إلى Aspose.Slides.dll.

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   في مثالنا (فيما يلي)، المكتبات موجودة في مجلد المشروع على هذا المسار: *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![browse-console-app](browse-console-app.jpg)

4. ضع الملفات المتبقية (التي تعتمد عليها Aspose.Slides) في دليل الإخراج عن طريق إضافة التعليمات إلى ملف مشروع csproj بهذه الطريقة:
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


5. انتبه إلى `TargetPath`.

   بشكل افتراضي، ينسخ `<CopyToOutputDirectory>` الملفات مع الحفاظ على مسارها النسبي، لكننا نحتاج إلى أن تذهب المكتبات التابعة إلى نفس المجلد الذي يتم فيه إنشاء الإخراج (موقع Aspose.Slides.dll).

## **ملاحظات**

### **نظام الرسومات المملوك**

| Aspose.Slides.dll                                          | المجمع الرئيسي لـ .NET المسؤول عن جميع منطق Aspose.Slides |
| ---------------------------------------------------------- | ------------------------------------------------------------ |
| aspose.slides.drawing.capi_vc14x64.dll                     | اعتماد: تنفيذ نظام الرسومات لمنصة Win x64                    |
| aspose.slides.drawing.capi_vc14x86.dll                     | اعتماد: تنفيذ نظام الرسومات لمنصة Win x64                    |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | اعتماد: تنفيذ نظام الرسومات لنظام Linux (x86/x64)          |
| libaspose.slides.drawing.capi_appleclang_x86_64.dylib      | اعتماد: تنفيذ نظام الرسومات لنظام macOS AMD64 (x86-64/x64) |
| libaspose.slides.drawing.capi_appleclang_arm64.dylib       | اعتماد: تنفيذ نظام الرسومات لنظام macOS ARM64 (AArch64)    |

Aspose.Slides.dll يستخدم المكتبة التي يتطلبها النظام الذي يعمل عليه. عادةً ما تكون المكتبات موجودة في نفس موقع Aspose.Slides.dll في أي نظام ملفات.

### **هيكل حزمة ZIP**

تحتوي حزمة ZIP على بنية المجلدات التالية:

  Aspose.Slides

  ├─── net6.0

  │  ├─── crossplatform

  │  └─── default

  ├─── net20

  ├─── net462

  └─── netstandard2.0

* يحتوي كل مجلد على مجمعات للإصدار .NET المقابل. هناك نسختان لـ net6.0: default و crossplatform. الأخيرة تحتوي على Aspose.Slides.dll متعدد المنصات وجميع تبعياته. يمكن استخدام محتويات هذا المجلد غير المضغوطة كإضافة اعتماد في مشروع للتطوير متعدد المنصات وحالات استعمال أخرى لـ Aspose.Slides.

## **أنظر أيضاً**

- [متطلبات النظام](/slides/ar/net/system-requirements/)