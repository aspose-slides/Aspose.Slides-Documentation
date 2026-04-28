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
- باوربوينت
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "اكتشف متطلبات نظام Aspose.Slides for .NET. احرص على دعم سلس لـ PowerPoint و OpenDocument على نظامي ويندوز، لينكس، وماك أو إس."
---
## **نظرة عامة**
Aspose.Slides for .NET لا يتطلب تثبيت Microsoft PowerPoint لأن Aspose.Slides هو محرك مستقل لإنشاء مستندات Microsoft PowerPoint وتحويلها وتنسيق الصفحات وعرضها.

## **أنظمة التشغيل المدعومة**
Aspose.Slides for .NET يدعم أي نظام تشغيل 32‑bit أو 64‑bit حيث يكون .NET أو Mono مثبتًا بما في ذلك (وليس حصراً على):

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

{{%  alert  title="ملاحظات"  color="primary"  %}} 
نظرًا لأن CentOS 7 يأتي مع GLIBC 2.14 بينما يتطلب Aspose.Slides for .NET 6 و .NET 7 (بما في ذلك بناء المنصات المتعددة) نظام Linux x86_64 مع GLIBC 2.23 أو أحدث، يمكنك استخدام Aspose.Slides for .NET Standard على مثل هذا النظام.
{{% /alert %}} 

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
- دعم COM Interop (COM, C++, VBScript)

### **Mono Framework**
- دعم MONO في منصات MAC و Linux

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
هذا هو الإصدار الرئيسي للمنتج. يستخدم محرك الرسوميات القياسي لـ .NET.
- على المنصات غير Windows، قد تحتاج إلى تثبيت مكتبة `libgdiplus` وتبعياتها.
- قبل الإصدار Aspose.Slides 25.3، بالنسبة للمنصات غير Windows، كان من الضروري استخدام ملف DLL الخاص بـ .NET Standard 2.0 من حزمة Aspose.Slides ZIP.
- بدءًا من الإصدار Aspose.Slides 25.3، يمكن استخدام حزمة NuGet مباشرةً حتى على الأنظمة غير Windows.
- عند التشغيل على أنظمة غير Windows، يجب أن يتضمن تطبيقك السطر التالي عند بدء التشغيل:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **بدءًا من الإصدار 25.3، يمكنك استخدام هذه الحزمة على المنصات التي تدعم .NET، مثل Linux aarch64 (ARM64).**

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**
هذا هو الإصدار من Aspose.Slides الذي يستخدم محرك رسوميات مخصص متعدد المنصات طوره فريق Aspose.Slides.  
على المنصات غير Windows، قد تكون مكتبة `fontconfig` مطلوبة.

**المنصات المدعومة**
- *Windows*: x86, x86_64  
- *Linux*: x86_64  
- *macOS*: x86_64, ARM64

**مخطط الدعم المستقبلي**  
- *Linux*: aarch64 (ARM64) — *الموعد المتوقع: نهاية 2025*  

**غير مخطط له**
- *Windows 11 ARM* (ARM64) — *غير مدروس حاليًا*

## **الأسئلة المتكررة**

**هل أحتاج إلى تثبيت Microsoft PowerPoint لإجراء التحويلات والعرض؟**

لا، لا يلزم PowerPoint؛ Aspose.Slides هو محرك مستقل لـ [إنشاء](/slides/ar/net/create-presentation/)، تعديل، [تحويل](/slides/ar/net/convert-presentation/) و[عرض](/slides/ar/net/convert-powerpoint-to-png/) العروض التقديمية.

**ما الخطوط المطلوبة للعرض الصحيح؟**

عمليًا، يجب أن تكون الخطوط المستخدمة في العرض أو [البدائل](/slides/ar/net/font-substitution/) المتناسبة متوفرة. لضمان عرض متسق على Linux/macOS، يُنصح بتثبيت حزم الخطوط الشائعة.

**لماذا يظهر خط مخصص كبديل أو نص مفقود على Linux؟**

إذا كان ملف الخط يحتوي على سجلات جدول أسماء غير متسقة أو corrupted، قد يختار مكدس مطابقة الخطوط في Linux (FreeType/fontconfig) سجلًا غير صالح، مما يؤدي إلى عدم حل الخط. استخدام نسخة خط مع سجلات جدول أسماء مصححة أو تثبيت بديل متسق يحل المشكلة.