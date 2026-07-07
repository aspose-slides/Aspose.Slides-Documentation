---
title: متطلبات النظام
type: docs
weight: 60
url: /ar/net/system-requirements/
keywords:
- متطلبات النظام
- نظام تشغيل
- التثبيت
- التبعيات
- ويندوز
- لينكس
- ماك أو إس
- باوربوينت
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "اكتشف متطلبات نظام Aspose.Slides for .NET. تأكد من دعم سلس لـ PowerPoint وOpenDocument على أنظمة Windows وLinux وmacOS."
---
## **مقدمة**

Aspose.Slides for .NET لا يتطلب وجود Microsoft PowerPoint مثبتًا لأن Aspose.Slides عبارة عن محرك مستقل لإنشاء مستندات Microsoft PowerPoint، والتحويل، وتخطيط الصفحات، وعرضها.

## **أنظمة التشغيل المدعومة**

Aspose.Slides for .NET يدعم أي نظام تشغيل 32‑bit أو 64‑bit حيث يتم تثبيت إطار .NET أو Mono بما في ذلك (ولكن ليس حصرًا على):

### **ويندوز**

- Microsoft Windows 2000 Server ( x64, x86)
- Microsoft Windows 2003 Server ( x64, x86)
- Microsoft Windows 2022 Server
- Microsoft Windows Vista ( x64, x86)
- Microsoft Windows XP ( x64, x86)
- Microsoft Windows 7 ( x64, x86)
- Microsoft Windows 8, 8.1 ( x64, x86)
- Microsoft Windows 10 ( x64, x86)
- Microsoft Windows 11 ( x64, x86)
- Microsoft Azure

### **لينكس**

- Linux (Ubuntu, OpenSUSE, CentOS, Alpine, and others)

### **ماك**

- Mac OS X

## **الأطر المدعومة**

Aspose.Slides for .NET يدعم إطاري .NET و Mono:

### **إطارات .NET**

- .NET Framework 2.0
- .NET Framework 3.5
- .NET Framework 4.0
- .NET Framework 4.0_ClientProfile
- .NET Framework 4.5.0
- .NET Framework 4.5.1
- .NET Framework 4.5.2
- .NET Framework 4.6.0
- .NET Framework 4.6.2
- .NET Framework 4.5.0
- .NET Framework 4.5.1
- .NET Framework 4.6.0
- .NET Framework 4.6.2
- .NET Framework 4.7
- .NET Framework 4.7.2
- .NET 5
- .NET 6
- .NET 7
- .NET 8
- .NET 9
- .NET Core
- COM Interop support (COM, C++, VBScript)

### **إطار Mono**

- MONO Support in MAC and Linux platforms

## **بيئات التطوير**

يمكن استخدام Aspose.Slides for .NET لتطوير التطبيقات في أي بيئة تطوير تستهدف منصة .NET، ولكن هذه البيئات مدعومة صراحةً:

- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
- Microsoft Visual Studio 2022

## **الإصدارات الرئيسية لـ Aspose.Slides**

حاليًا، هناك إصداران رئيسيان من Aspose.Slides — Aspose.Slides.NET و Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

هذا هو الإصدار الرئيسي للمنتج. يستخدم محرك الرسومات القياسي لــ .NET.  
- على الأنظمة غير الويندوز، قد تحتاج إلى تثبيت مكتبة `libgdiplus` وتبعياتها.  
- قبل الإصدار Aspose.Slides 25.3، على الأنظمة غير الويندوز، كان من الضروري استخدام ملف DLL الخاص بـ .NET Standard 2.0 من حزمة Aspose.Slides المضغوطة.  
- بدءًا من الإصدار Aspose.Slides 25.3، يمكن استخدام حزمة NuGet مباشرةً حتى على الأنظمة غير الويندوز.  
- عند تشغيل التطبيق على أنظمة غير الويندوز، يجب تضمين السطر التالي عند بدء التشغيل:  
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```  
- **بدءًا من الإصدار 25.3، يمكنك استخدام هذه الحزمة على المنصات التي تدعم .NET، مثل Linux aarch64 (ARM64).**

#### **حزم إضافية لـ Linux Alpine**

عند تشغيل Aspose.Slides for .NET داخل حاوية Alpine Linux، قد لا يكون تثبيت `libgdiplus` وحده كافيًا. عادةً لا تتضمن الحاويات Alpine الخطوط بشكل افتراضي. إذا لم تتوفر أي خطوط، قد تفشل عمليات العرض أو التحويل مع خطأ مشابه لـ:

```text
System.ArgumentException: Font '?' cannot be found
```  
لاستخدام Aspose.Slides على Alpine، قم بتثبيت `libgdiplus` مع حزمة خطوط واحدة على الأقل.

**الخيار 1: خطوط DejaVu**

الخيار الموصى به هو تثبيت حزمة `ttf-dejavu`:

```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

حزمة `ttf-dejavu` تقوم تلقائيًا بتثبيت تبعيات الخط المطلوبة مثل `fontconfig` و `encodings` و `mkfontscale` و `mkfontdir`. لا تحتاج إلى حزم خطوط إضافية في معظم الحالات.

**الخيار 2: خطوط Microsoft Core**

إذا كانت عروضك التقديمية تستخدم خطوط Microsoft مثل Arial أو Times New Roman أو Courier New أو Verdana، فقم بتثبيت Microsoft Core Fonts بدلاً من ذلك:

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

استخدم هذا الخيار فقط عندما تتطلب العروض التقديمية معالجة خطوط Microsoft. في معظم السيناريوهات، يكون تثبيت `ttf-dejavu` أبسط وأكثر موثوقية.

**متطلبات إضافية للعالمية**

لتمكين دعم عالمي صحيح على Alpine، قم بتثبيت حزمة `icu-libs` وتعطيل وضع invariant:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

هذا هو الإصدار من Aspose.Slides الذي يستخدم محرك رسوميات متعدد المنصات مخصص تم تطويره بواسطة فريق Aspose.Slides.  
على الأنظمة غير الويندوز، قد تكون مكتبة `fontconfig` مطلوبة.

**المنصات المدعومة**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)  
- *macOS*: x86_64, ARM64 (aarch64)

**المنصات غير المدعومة**
- *Windows 11 ARM* (ARM64) — *ليس قيد النظر حاليًا*

{{%  alert  title="Notes"  color="primary"  %}}  
بالنسبة إلى Linux x64، يلزم GLIBC 2.23+؛ بالنسبة إلى Linux ARM64، يلزم GLIBC 2.39+. الأنظمة مثل CentOS 7 (GLIBC 2.14) غير مدعومة. إذا كنت بحاجة لتشغيل Aspose.Slides على CentOS 7 أو أنظمة غير متوافقة أخرى (مثل Alpine)، يرجى استخدام الحزمة القياسية: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **الأسئلة المتكررة**

**هل أحتاج إلى تثبيت Microsoft PowerPoint للتحويلات والعرض؟**

لا، لا يلزم PowerPoint؛ Aspose.Slides هو محرك مستقل لـ [إنشاء](/slides/ar/net/create-presentation/) وتعديل و[تحويل](/slides/ar/net/convert-presentation/) و[عرض](/slides/ar/net/convert-powerpoint-to-png/) العروض التقديمية.

**ما الخطوط المطلوبة للعرض الصحيح؟**

يجب توفر الخطوط المستخدمة في العرض أو بدائل مناسبة في نظام التشغيل. على Linux و macOS، قم بتثبيت حزم الخطوط الشائعة لضمان عرض ثابت.

بالنسبة لحاويات Alpine Linux، ثبت حزمة خطوط واحدة على الأقل إلى جانب `libgdiplus`. الإعداد الأدنى الموصى به هو `libgdiplus` مع `ttf-dejavu`. إذا كانت الخطوط المطلوبة هي خطوط Microsoft مثل Arial أو Times New Roman أو Courier New أو Verdana، استخدم `msttcorefonts-installer` مع `fontconfig`.

**لماذا يتم عرض خط مخصص كبديل أو نص مفقود على Linux؟**

إذا كان ملف الخط يحتوي على سجلات جدول أسماء غير متسقة أو تالفة، قد تختار طبقة مطابقة الخطوط في Linux (FreeType/fontconfig) سجلاً غير صالح، مما يؤدي إلى عدم التعرف على الخط. استخدام نسخة خط ذات سجلات اسم مصححة أو تثبيت بديل متسق يحل المشكلة.