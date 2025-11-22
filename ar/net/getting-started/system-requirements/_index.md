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
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- العرض
- Aspose.Slides
description: "اكتشف متطلبات نظام Aspose.Slides لـ .NET. تأكد من دعم سلس لPowerPoint وOpenDocument على Windows وLinux وmacOS."
---

## **نظرة عامة**
لا يتطلب Aspose.Slides for .NET تثبيت Microsoft PowerPoint لأن Aspose.Slides هو محرك مستقل لإنشاء مستندات Microsoft PowerPoint والتحويل وتخطيط الصفحات وعرضها.

## **أنظمة التشغيل المدعومة**
يدعم Aspose.Slides for .NET أي نظام تشغيل 32‑bit أو 64‑bit حيث يتم تثبيت إطار عمل .NET أو Mono بما في ذلك (ولكن ليس حصراً):

### **ويندوز**
- Microsoft Windows 2000 Server (x64, x86)
- Microsoft Windows 2003 Server (x64, x86)
- Microsoft Windows 2022 Server
- Microsoft Windows Vista (x64, x86)
- Microsoft Windows XP (x64, x86)
- Microsoft Windows 7 (x64, x86)
- Microsoft Windows 8, 8.1 (x64, x86)
- Microsoft Windows 10 (x64, x86)
- Microsoft Windows 11 (x64, x86)
- Microsoft Azure

### **لينكس**
- Linux (Ubuntu, OpenSUSE, CentOS, Alpine, and others)

{{%  alert  title="Notes"  color="primary"  %}} 
نظرًا لأن CentOS 7 يأتي مع GLIBC 2.14 بينما تتطلب Aspose.Slides for .NET 6 و .NET 7 (بما في ذلك بنية المنصة المتقاطعة) Linux x86_64 مع GLIBC 2.23 أو أحدث، يمكنك استخدام Aspose.Slides for .NET Standard على مثل هذا النظام. 
{{% /alert %}} 

### **ماك**
- Mac OS X

## **الإطارات المدعومة**
Aspose.Slides for .NET يدعم إطارات .NET و Mono:

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

## **بنيات Aspose.Slides الرئيسية**
حاليًا، هناك بنيتان رئيسيتان لـ Aspose.Slides — Aspose.Slides.NET و Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**
هذا هو الإصدار الرئيسي للمنتج. يستخدم محرك الرسومات القياسي لـ .NET.
- على المنصات غير الويندوز، قد تحتاج إلى تثبيت مكتبة `libgdiplus` واعتمادياتها.
- قبل الإصدار Aspose.Slides 25.3، بالنسبة للمنصات غير الويندوز، كان من الضروري استخدام ملف DLL .NET Standard 2.0 من حزمة Aspose.Slides ZIP.
- بدءًا من الإصدار Aspose.Slides 25.3، يمكن استخدام حزمة NuGet مباشرةً حتى على الأنظمة غير الويندوز.
- عند التشغيل على أنظمة غير الويندوز، يجب أن يتضمن تطبيقك السطر التالي عند بدء التشغيل:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```

- **بدءًا من الإصدار 25.3، يمكنك استخدام هذه الحزمة على المنصات التي تدعم .NET، مثل Linux aarch64 (ARM64).**

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**
هذا هو إصدار Aspose.Slides الذي يستخدم محرك رسومات مخصص متعدد المنصات تم تطويره بواسطة فريق Aspose.Slides.  
على المنصات غير الويندوز، قد تكون مكتبة `fontconfig` مطلوبة.

**المنصات المدعومة**
- *Windows*: x86, x86_64  
- *Linux*: x86_64  
- *macOS*: x86_64, ARM64

**مخطط للدعم المستقبلي**  
- *Linux*: aarch64 (ARM64) — *ETA: end of 2025*  

**غير مخطط**
- *Windows 11 ARM* (ARM64) — *Not currently under consideration*

## **الأسئلة الشائعة**

**هل أحتاج إلى تثبيت Microsoft PowerPoint للتحويلات والعرض؟**

لا، لا يتطلب PowerPoint؛ Aspose.Slides هو محرك مستقل لـ [إنشاء](/slides/ar/net/create-presentation/) وتعديل و[تحويل](/slides/ar/net/convert-presentation/) و[عرض](/slides/ar/net/convert-powerpoint-to-png/) العروض التقديمية.

**ما الخطوط اللازمة للعرض الصحيح؟**

عمليًا، يجب أن تكون الخطوط المستخدمة في العرض أو [البدائل المناسبة](/slides/ar/net/font-substitution/) متوفرة. لضمان عرض متسق على Linux/macOS، يُنصح بتثبيت حزم الخطوط الشائعة.