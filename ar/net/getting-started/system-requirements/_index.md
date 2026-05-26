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
- ماك أو إس
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "اكتشف متطلبات نظام Aspose.Slides لـ .NET. تأكد من دعم سلس لـ PowerPoint وOpenDocument على ويندوز، لينكس، وماك أو إس."
---
## **مقدمة**

Aspose.Slides for .NET لا يتطلب تثبيت Microsoft PowerPoint لأن Aspose.Slides هو محرك مستقل لإنشاء مستندات Microsoft PowerPoint والتحويل وتنسيق الصفحات وعرضها.

## **أنظمة التشغيل المدعومة**

Aspose.Slides for .NET يدعم أي نظام تشغيل 32‑bit أو 64‑bit where .NET أو Mono framework مثبت بما في ذلك (لكن ليس حصرًا على):

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

Aspose.Slides for .NET يدعم أطر .NET وMono:

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

Aspose.Slides for .NET يمكن استخدامه لتطوير التطبيقات في أي بيئة تطوير تستهدف منصة .NET، لكن هذه البيئات مدعومة صراحةً:

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

### **[Aspose.Slides لـ .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

هذا هو الإصدار الرئيسي للمنتج. يستخدم محرك الرسوميات القياسي في .NET.  
- على المنصات غير Windows قد تحتاج إلى تثبيت مكتبة `libgdiplus` واعتمادياتها.  
- قبل الإصدار Aspose.Slides 25.3، على المنصات غير Windows كان من الضروري استخدام DLL .NET Standard 2.0 من حزمة ZIP الخاصة بـ Aspose.Slides.  
- بدءًا من الإصدار Aspose.Slides 25.3، يمكن استخدام حزمة NuGet مباشرة حتى على الأنظمة غير Windows.  
- عند التشغيل على أنظمة غير Windows، يجب أن يتضمن تطبيقك السطر التالي عند بدء التشغيل:  
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```  
- **بدءًا من الإصدار 25.3، يمكنك استخدام هذه الحزمة على المنصات التي تدعم .NET، مثل Linux aarch64 (ARM64).**

#### **حزم إضافية لـ Linux Alpine**

عند تشغيل Aspose.Slides for .NET داخل حاوية Alpine Linux، قد لا يكون تثبيت `libgdiplus` وحده كافيًا. عادةً لا تتضمن حاويات Alpine خطوطًا بشكل افتراضي. إذا لم تتوفر خطوط، قد تفشل عمليات العرض أو التحويل بخطأ يشبه:

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

حزمة `ttf-dejavu` تثبت تلقائيًا الاعتماديات المتعلقة بالخطوط المطلوبة، مثل `fontconfig` و `encodings` و `mkfontscale` و `mkfontdir`. لا تحتاج إلى حزم خطوط إضافية لمعظم حالات الاستخدام.

**الخيار 2: خطوط Microsoft Core**

إذا كانت عروضك التقديمية تستخدم خطوطًا خاصة بـ Microsoft مثل Arial أو Times New Roman أو Courier New أو Verdana، قم بتثبيت Microsoft Core Fonts بدلاً من ذلك:

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```  

استخدم هذا الخيار فقط عندما تتطلب العروض التي يتم معالجتها خطوط Microsoft. بالنسبة لمعظم السيناريوهات، يكون تثبيت `ttf-dejavu` أبسط وأكثر موثوقية.

### **[Aspose.Slides لـ .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

هذا هو الإصدار من Aspose.Slides الذي يستخدم محرك رسومات مخصص متعدد المنصات طوره فريق Aspose.Slides.  
على المنصات غير Windows قد تكون مكتبة `fontconfig` مطلوبة.

**المنصات المدعومة**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)  
- *macOS*: x86_64, ARM64 (aarch64)

**المنصات غير المدعومة**
- *Windows 11 ARM* (ARM64) — *غير مدروس حاليًا*

{{%  alert  title="Notes"  color="primary"  %}}  
لـ Linux x64، يلزم GLIBC 2.23+؛ ولـ Linux ARM64، يلزم GLIBC 2.39+. الأنظمة مثل CentOS 7 (GLIBC 2.14) غير مدعومة. إذا احتجت تشغيل Aspose.Slides على CentOS 7 أو أنظمة غير متوافقة أخرى (مثال: Alpine)، يرجى استخدام الحزمة القياسية: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **التعليمات المتكررة**

**هل أحتاج إلى تثبيت Microsoft PowerPoint لإجراء التحويلات وعرض الشرائح؟**

لا، لا يلزم PowerPoint؛ Aspose.Slides هو محرك مستقل لـ [إنشاء](/slides/ar/net/create-presentation/) وتعديل و[تحويل](/slides/ar/net/convert-presentation/) و[عرض](/slides/ar/net/convert-powerpoint-to-png/) العروض التقديمية.

**ما الخطوط المطلوبة للعرض الصحيح؟**

يجب أن تكون الخطوط المستخدمة في العرض، أو بدائل مناسبة، متوفرة في نظام التشغيل. على Linux وmacOS، قم بتثبيت حزم خطوط شائعة لضمان عرض متسق.

للحاويات Alpine Linux، قم بتثبيت حزمة خطوط واحدة على الأقل بالإضافة إلى `libgdiplus`. الإعداد الأدنى الموصى به هو `libgdiplus` مع `ttf-dejavu`. إذا كانت خطوط Microsoft مثل Arial أو Times New Roman أو Courier New أو Verdana مطلوبة، استخدم `msttcorefonts-installer` مع `fontconfig`.

**لماذا يتم عرض خط مخصص كبديل أو نص مفقود على Linux؟**

إذا كان ملف الخط يحتوي على سجلات جدول أسماء غير متسقة أو تالفة، قد يختار مكدس مطابقة الخطوط في Linux (FreeType/fontconfig) سجلًا غير صالح، مما يؤدي إلى عدم حل الخط. استخدام نسخة من الخط ذات سجلات جدول أسماء مصححة أو تثبيت بديل متسق يحل المشكلة.