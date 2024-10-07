---
title: Aspose.Slides لـ .NET 6 عبر المنصات
type: docs
weight: 237
url: /net/slides-for-net-6-cross-platform
keywords: Aspose.Slides, .NET, عبر المنصات
description: Aspose.Slides لـ .NET 6 عبر المنصات
---

1. يمكن استخدام Aspose.Slides عبر المنصات لـ .NET6 مع .NET 7 والإصدارات المستقبلية من .NET.

2. **المتطلبات الأساسية**: لاستخدام نسخة Aspose.Slides عبر المنصات لـ .NET 6، تحتاج إلى تحميل حزمة Aspose.Slides من [صفحة الإصدارات](https://releases.aspose.com/slides/net/). حزمة Aspose.Slides من NuGet لا تناسب لأن لها دعم عبر المنصات فقط لـ .NET Standard.

3. **المتطلبات**: [متطلبات النظام](https://docs.aspose.com/slides/net/system-requirements/). يرجى ملاحظة أن Aspose.Slides لـ .NET 6 و .NET 7 يتطلبان Linux x86_x64 مع GLIBC 2.23 وما فوق. **CentOS** 7 (الذي يحتوي على إصدار GLIBC 2.14) غير مدعوم. لاستخدام Slides في CentOS 7 أو أنظمة أخرى (مثل Alpine) التي لا تفي بالمتطلبات، يرجى الحصول على Aspose.Slides لـ .NETStandard.

## **الحصول على واستخدام Aspose.Slides عبر المنصات**

1. قم بتنزيل حزمة ZIP من أحدث إصدار من Aspose.Slides من [صفحة الإصدارات](https://releases.aspose.com/slides/net/). 

2. فك ضغط الملفات من *\Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* وضعها في المجلد الذي سيتم استخدامه للاعتماديات في مشروعك.

3. أضف إشارة إلى Aspose.Slides.dll

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   في مثالنا (أدناه)، تتواجد المكتبات في مجلد المشروع على هذا المسار: *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![browse-console-app](browse-console-app.jpg)

4. ضع الملفات المتبقية (التي تعتمد عليها Aspose.Slides) في دليل الإخراج عن طريق إضافة تعليمات إلى ملف csproj بهذا الشكل:
```
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

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
                  <TargetPath>libaspose.slides.drawing.capi_appleclang.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
                  <TargetPath>libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so</TargetPath>
   </None>

</ItemGroup>
```

5. انتبه إلى TargetPath. 

   بشكل افتراضي، `<CopyToOutputDirectory>` copies files while preserving their relative path, لكننا بحاجة إلى أن تذهب المكتبات التابعة إلى نفس المجلد الذي يتم فيه إنشاء الإخراج (مكان Aspose.Slides.dll).

## ملاحظات

### **دعم System.Drawing.Common فقط لـ Windows**

بدءًا من .NET 6، فإن دعم System.Drawing.Common (الذي يوفر دعم GDI+) متاح [فقط في Windows](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only). تعتمد Aspose.Slides لـ .NET على GDI+. بالإضافة إلى ذلك، تحتوي واجهة برمجة التطبيقات العامة لـ Aspose.Slides على أنواع (Bitmap، Metafile، Graphics، إلخ) من حزمة System.Drawing.Common.

### **نظام الرسوميات المملوك**

لحل مشكلة التغيير الجذري (الذي يلغي دعم عبر المنصات لـ System.Drawing.Common)، تستخدم Aspose.Slides - بدءًا من الإصدار 23.6 - تنفيذها الخاص لنظام الرسوميات.

هذه هي الأنظمة المدعومة: **Windows**، **Linux**، و **macOS**.

Aspose.Slides عبر المنصات هو مجموعة من المكتبات:

| Aspose.Slides.dll                                          | التجميع الرئيسي لـ .NET المسؤول عن كافة منطق Aspose.Slides    |
| ---------------------------------------------------------- | ------------------------------------------------------------ |
| aspose.slides.drawing.capi_vc14x64.dll                     | الاعتماد: تنفيذ نظام الرسوميات لـ Win x64    |
| aspose.slides.drawing.capi_vc14x86.dll                     | الاعتماد: تنفيذ نظام الرسوميات لـ Win x86    |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | الاعتماد: تنفيذ نظام الرسوميات لـ Linux (x86/x64) |
| libaspose.slides.drawing.capi_appleclang.dylib             | الاعتماد: تنفيذ نظام الرسوميات لـ macOS      |

تستخدم Aspose.Slides.dll المكتبة التي يتطلبها النظام الذي تعمل عليه. عادة ما تكون المكتبات موجودة في نفس المكان الذي يوجد فيه Aspose.Slides.dll في أي نظام ملفات.

### **واجهة برمجة التطبيقات العامة لـ Aspose.Slides والأنواع من System.Drawing.Common. حل لمشكلة أسماء التعارض**

تستخدم واجهة برمجة التطبيقات العامة لـ Aspose.Slides الأنواع من System.Drawing.Common (Bitmap، Metafile، Graphics، والعديد من الآخرين). لتسهيل الانتقال السلس إلى منتج Aspose.Slides عبر المنصات الجديد ولتجنب إدخال العديد من التغييرات الجذرية في واجهة برمجة التطبيقات العامة لـ Slides، يقوم التنفيذ المملوك لنظام الرسوميات **بتكرار** الأنواع والمساحات الاسمية من System.Drawing.Common.

لذلك، إذا كنت تطور أو تعمل في بيئة Linux، فإنك تحتاج فقط إلى استخدام Aspose.Slides كاعتماد - وستبقى واجهة برمجة التطبيقات بالكامل كما هي.

**مشكلة محتملة**: الإعداد الموصوف له عيوبه. على سبيل المثال، إذا كنت تطور في Windows ولديك مشاريع تستخدم System.Drawing.Common الأصلية، قد تواجه تعارضات مع أنواع Aspose.Slides.

**حل**: يمكنك استخدام extern alias لحل المشكلة. انظر [**استخدام حزمة System.Drawing.Common وطبقات Slides لـ .NET6 (CS0433: النوع موجود في كل من Slides و System.Drawing.Common خطأ)**](https://docs.aspose.com/slides/net/net6/#using-the-systemdrawingcommon-package-and-slides-for-net6-classes-cs0433-the-type-exists-in-both-slides-and-systemdrawingcommon-error).

يعمل فريق Slides على مهام ستؤدي إلى تبسيط وتوحيد واجهة برمجة التطبيقات العامة.

### **حزم NuGet و ZIP**

* حزمة NuGet لـ Aspose.Slides لـ .NET تفتقر حاليًا إلى دعم Aspose.Slides عبر المنصات لـ .NET 6.

* تدعم حزمة NuGet لـ Aspose.Slides لـ .NET الدعم عبر المنصات لـ .NET Standard ولكن ليس لـ .NET 6.

* النسخة عبر المنصات من Aspose.Slides متاحة كحزم ZIP المقدمة على [صفحة الإصدارات](https://releases.aspose.com/slides/net/).

* تحتوي حزمة ZIP على هيكل المجلدات التالي:

  ├───net2.0

  ├───net3.5

  ├───net3.5_ClientProfile

  ├───net4.0

  ├───net4.0_ClientProfile

  ├───net6.0

  │  ├───crossplatform

  │  └───win

  ├───netstandard2.0

  └───netstandard2.1

* كل مجلد يحتوي على تجميعات لإصدار .NET المقابل له. هناك إصداران لـ net6.0: win وcrossplatform. يحتوي الأخير على Aspose.Slides.dll عبر المنصات وجميع اعتماداتها. يمكن استخدام محتويات هذا المجلد بعد فك ضغطه كإضافة اعتماد في مشروع للتطوير عبر المنصات واستخدامات أخرى لـ Aspose.Slides.