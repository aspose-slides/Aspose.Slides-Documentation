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
- macOS
- باوربوينت
- OpenDocument
- العرض التقديمي
- .NET
- C#
- Aspose.Slides
description: "اكتشف متطلبات نظام Aspose.Slides for .NET. تأكد من دعم سلس لـ PowerPoint و OpenDocument على ويندوز، لينكس، وماكOS."
---

## **نظرة عامة**
لا يتطلب Aspose.Slides for .NET تثبيت Microsoft PowerPoint لأن Aspose.Slides هو محرك مستقل لإنشاء مستندات Microsoft PowerPoint، والتحويل، وتنسيق الصفحات، وعرضها.

## **أنظمة التشغيل المدعومة**
يدعم Aspose.Slides for .NET أي نظام تشغيل 32‑بت أو 64‑بت حيث تم تثبيت إطار .NET أو Mono بما في ذلك (ولكن ليس على حصر):

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
- لينكس (Ubuntu، OpenSUSE، CentOS، Alpine، وغيرها)

{{%  alert  title="Notes"  color="primary"  %}} 
لأن CentOS 7 يأتي مع GLIBC 2.14 بينما يتطلب Aspose.Slides for .NET 6 و .NET 7 (بما في ذلك نسخة المنصات المتعددة) نظام Linux x86_64 مع GLIBC 2.23 أو أحدث، يمكنك استخدام Aspose.Slides for .NET Standard على هذا النظام.
{{% /alert %}} 

### **ماك**
- Mac OS X

## **الأطر المدعومة**
يدعم Aspose.Slides for .NET أطر .NET و Mono:

### **أطر .NET**
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

## **البناءات الرئيسية لـ Aspose.Slides**
حاليًا، هناك بناؤان رئيسيان لـ Aspose.Slides — Aspose.Slides.NET و Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**
هذه هي النسخة الرئيسية للمنتج. يستخدم محرك الرسومات القياسي لـ .NET.
- على المنصات غير Windows قد تحتاج إلى تثبيت مكتبة `libgdiplus` وتبعياتها.
- قبل الإصدار Aspose.Slides 25.3، للمنصات غير Windows كان من الضروري استخدام ملف DLL .NET Standard 2.0 من حزمة Aspose.Slides ZIP.
- بدءًا من الإصدار Aspose.Slides 25.3، يمكن استخدام حزمة NuGet مباشرة حتى على الأنظمة غير Windows.
- عند التشغيل على أنظمة غير Windows، يجب على تطبيقك تضمين السطر التالي عند بدء التشغيل:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```

- **بدءًا من الإصدار 25.3، يمكنك استخدام هذه الحزمة على المنصات التي تدعم .NET، مثل Linux aarch64 (ARM64).**

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**
هذه هي نسخة Aspose.Slides التي تستخدم محرك رسومات مخصص متعدد المنصات تم تطويره بواسطة فريق Aspose.Slides.  
على المنصات غير Windows قد تكون مكتبة `fontconfig` مطلوبة.

**المنصات المدعومة**
- *Windows*: x86، x86_64  
- *Linux*: x86_64  
- *macOS*: x86_64، ARM64

**مخطط للدعم المستقبلي**  
- *Linux*: aarch64 (ARM64) — *متوقع الإنتهاء: نهاية 2025*  

**غير مخطط له**
- *Windows 11 ARM* (ARM64) — *ليس قيد النظر حاليًا*

## **الأسئلة الشائعة**

**هل أحتاج إلى تثبيت Microsoft PowerPoint للتحويلات والعرض؟**

لا، لا يلزم PowerPoint؛ Aspose.Slides هو محرك مستقل لـ [إنشاء](/slides/ar/net/create-presentation/)، وتعديل، و[تحويل](/slides/ar/net/convert-presentation/)، و[عرض](/slides/ar/net/convert-powerpoint-to-png/) العروض التقديمية.

**ما الخطوط المطلوبة للعرض الصحيح؟**

عمليًا، يجب أن تكون الخطوط المستخدمة في العرض أو [البدائل](/slides/ar/net/font-substitution/) المناسبة متاحة. لضمان عرض متسق على Linux/macOS، يُنصح بتثبيت حزم الخطوط الشائعة.