---
title: متطلبات النظام
type: docs
weight: 60
url: /ar/net/system-requirements/
keywords:
- متطلبات النظام
- نظام التشغيل
- التثبيت
- التبعيات
- ويندوز
- لينكس
- ماك
- باوربوينت
- مستند مفتوح
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "اكتشف متطلبات نظام Aspose.Slides for .NET. احرص على دعم سلس لبرنامج PowerPoint و OpenDocument على أنظمة Windows و Linux و macOS."
---
## **مقدمة**

Aspose.Slides for .NET لا يتطلب تثبيت Microsoft PowerPoint لأن Aspose.Slides هو محرك مستقل لإنشاء مستندات Microsoft PowerPoint وتحويلها وتنسيق الصفحات وعرضها.

## **أنظمة التشغيل المدعومة**

يدعم Aspose.Slides for .NET أي نظام تشغيل 32‑bit أو 64‑bit يتم فيه تثبيت .NET أو إطار Mono بما في ذلك (ولكن ليس حصرًا على):

### **Windows**

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

### **Linux**

- Linux (Ubuntu, OpenSUSE, CentOS, Alpine، وغيرها)

### **Mac**

- Mac OS X

## **الأطر المدعومة**

Aspose.Slides for .NET يدعم أطر .NET و Mono:

### **.NET Frameworks**

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

### **Mono Framework**

- MONO Support in MAC and Linux platforms

## **بيئات التطوير**

Aspose.Slides for .NET يمكن استخدامها لتطوير التطبيقات في أي بيئة تطوير تستهدف منصة .NET، لكن هذه البيئات مدعومة صراحةً:

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

هذه هي النسخة الأساسية من المنتج. يستخدم محرك الرسومات القياسي لـ .NET.
- على الأنظمة غير Windows، قد تحتاج إلى تثبيت مكتبة `libgdiplus` وتبعياتها.
- قبل الإصدار Aspose.Slides 25.3، بالنسبة للأنظمة غير Windows، كان من الضروري استخدام ملف DLL لـ .NET Standard 2.0 من حزمة ZIP الخاصة بـ Aspose.Slides.
- بدءًا من الإصدار Aspose.Slides 25.3، يمكن استخدام حزمة NuGet مباشرةً حتى على الأنظمة غير Windows.
- عند التشغيل على أنظمة غير Windows، يجب أن يتضمن تطبيقك السطر التالي عند بدء التشغيل:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **بدءًا من الإصدار 25.3، يمكنك استخدام هذه الحزمة على المنصات التي تدعم .NET، مثل Linux aarch64 (ARM64).**

#### **الحزم الإضافية لـ Linux Alpine**

عند تشغيل Aspose.Slides for .NET في حاوية Alpine Linux، قد لا يكون تثبيت `libgdiplus` وحده كافيًا. عادةً لا تتضمن حاويات Alpine خطوطًا بشكل افتراضي. إذا لم تتوفر خطوط، قد تفشل عمليات العرض أو التحويل بخطأ مشابه للآتي:
```text
System.ArgumentException: Font '?' cannot be found
```
لاستخدام Aspose.Slides على Alpine، قم بتثبيت `libgdiplus` مع حزمة خطوط واحدة على الأقل.

**الخيار 1: خطوط DejaVu**

الخيار الموصى به هو تثبيت حزمة ttf-dejavu:

```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

حزمة `ttf-dejavu` تثبت تلقائيًا التبعيات المتعلقة بالخطوط المطلوبة، مثل `fontconfig` و `encodings` و `mkfontscale` و `mkfontdir`. لا حاجة إلى حزم خطوط إضافية لمعظم الحالات.

**الخيار 2: خطوط Microsoft Core**

إذا كانت عروضك التقديمية تستخدم خطوطًا خاصة بـ Microsoft مثل Arial أو Times New Roman أو Courier New أو Verdana، فقم بتثبيت Microsoft Core Fonts بدلاً من ذلك:

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

استخدم هذا الخيار فقط عندما تتطلب العروض التقديمية خطوط Microsoft. بالنسبة لمعظم السيناريوهات، يكون تثبيت `ttf-dejavu` أبسط وأكثر موثوقية.

**متطلبات إضافية للعولمة**

لتمكين دعم العولمة بشكل صحيح على Alpine، قم بتثبيت حزمة `icu-libs` وتعطيل وضع الثبات:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

هذه هي نسخة Aspose.Slides التي تستخدم محرك رسومات مخصص متعدد المنصات طوره فريق Aspose.Slides.  
على الأنظمة غير Windows، قد تكون مكتبة `fontconfig` مطلوبة.

**المنصات المدعومة**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**المنصات غير المدعومة**
- *Windows 11 ARM* (ARM64) — *ليس قيد النظر حاليًا*

{{%  alert  title="Notes"  color="info"  %}}  
بالنسبة إلى Linux x64، يلزم وجود GLIBC 2.23+؛ بالنسبة إلى Linux ARM64، يلزم وجود GLIBC 2.39+. الأنظمة مثل CentOS 7 (GLIBC 2.14) غير مدعومة. إذا كنت بحاجة إلى تشغيل Aspose.Slides على CentOS 7 أو أنظمة غير متوافقة أخرى (مثل Alpine)، يرجى استخدام الحزمة القياسية: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **الأسئلة المتكررة**

### هل أحتاج إلى تثبيت Microsoft PowerPoint للتحويلات والعرض؟

لا، لا يلزم PowerPoint؛ Aspose.Slides هو محرك مستقل لـ [إنشاء](/slides/ar/net/create-presentation/) وتعديل و[تحويل](/slides/ar/net/convert-presentation/) و[عرض](/slides/ar/net/convert-powerpoint-to-png/) العروض التقديمية.

### ما الخطوط المطلوبة للعرض الصحيح؟

يجب أن تكون الخطوط المستخدمة في العرض أو البدائل المناسبة متوفرة في نظام التشغيل. على Linux و macOS، قم بتثبيت حزم خطوط شائعة لضمان عرض ثابت.

في حاويات Alpine Linux، قم بتثبيت حزمة خطوط واحدة على الأقل بالإضافة إلى `libgdiplus`. الإعداد الأدنى الموصى به هو `libgdiplus` مع `ttf-dejavu`. إذا كانت الخطوط المطلوبة هي خطوط Microsoft مثل Arial أو Times New Roman أو Courier New أو Verdana، استخدم `msttcorefonts-installer` مع `fontconfig`.

### لماذا يتم عرض خط مخصص كبديل أو نص مفقود على Linux؟

إذا كان ملف الخط يحتوي على سجلات جدول أسماء غير متناسقة أو تالفة، قد يختار نظام مطابقة الخطوط في Linux (FreeType/fontconfig) سجلًا غير صالح، مما يؤدي إلى عدم التعرف على الخط. استخدام نسخة من الخط ذات سجلات جدول أسماء صحيحة أو تثبيت بديل متناسق يحل المشكلة.