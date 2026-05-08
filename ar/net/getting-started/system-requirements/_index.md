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
- مستند مفتوح
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "اكتشف متطلبات نظام Aspose.Slides for .NET. تأكد من دعم سلس لباوربوينت و OpenDocument على ويندوز، لينكس، وماك أو إس."
---
## **نظرة عامة**
Aspose.Slides for .NET لا تحتاج إلى تثبيت Microsoft PowerPoint لأن Aspose.Slides هو محرك مستقل لإنشاء وثائق Microsoft PowerPoint، التحويل، تخطيط الصفحات، والعرض.

## **أنظمة التشغيل المدعومة**
Aspose.Slides for .NET يدعم أي نظام تشغيل 32‑bit أو 64‑bit حيث يتم تثبيت إطار .NET أو Mono بما في ذلك (ولكن ليس حصراً):

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
- Linux (Ubuntu, OpenSUSE, CentOS, Alpine, وغيرها)

### **ماك**
- Mac OS X

## **الأطر المدعومة**
Aspose.Slides for .NET يدعم أطر .NET و Mono:

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
- دعم COM Interop (COM, C++, VBScript)

### **إطار Mono**
- دعم MONO على منصات MAC و Linux

## **بيئات التطوير**
يمكن استخدام Aspose.Slides for .NET لتطوير التطبيقات في أي بيئة تطوير تستهدف منصة .NET، لكن البيئات التالية مدعومة صراحةً:

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
هذا هو الإصدار الرئيسي للمنتج. يستخدم محرك الرسومات القياسي لـ .NET.
- على الأنظمة غير الويندوز، قد تحتاج إلى تثبيت مكتبة `libgdiplus` واعتمادياتها.
- قبل الإصدار Aspose.Slides 25.3، على الأنظمة غير الويندوز كان من الضروري استخدام ملف DLL الخاص بـ .NET Standard 2.0 من حزمة Aspose.Slides ZIP.
- بدءًا من الإصدار Aspose.Slides 25.3، يمكن استخدام حزمة NuGet مباشرةً حتى على الأنظمة غير الويندوز.
- عند التشغيل على أنظمة غير الويندوز، يجب على تطبيقك تضمين السطر التالي عند بدء التشغيل:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **بدءًا من الإصدار 25.3، يمكنك استخدام هذه الحزمة على المنصات التي تدعم .NET، مثل Linux aarch64 (ARM64).**

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**
هذا هو الإصدار من Aspose.Slides الذي يستخدم محرك رسومات مخصص متعدد المنصات تم تطويره بواسطة فريق Aspose.Slides.  
على الأنظمة غير الويندوز، قد تكون مكتبة `fontconfig` مطلوبة.

**المنصات المدعومة**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**المنصات غير المدعومة**
- *Windows 11 ARM* (ARM64) — *غير مدروس حاليًا*

{{%  alert  title="Notes"  color="primary"  %}}  
لـ Linux x64، يلزم GLIBC 2.23+؛ ولـ Linux ARM64، يلزم GLIBC 2.39+. الأنظمة مثل CentOS 7 (GLIBC 2.14) غير مدعومة. إذا كنت بحاجة لتشغيل Aspose.Slides على CentOS 7 أو أنظمة غير متوافقة أخرى (مثل Alpine)، يرجى استخدام الحزمة القياسية: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **الأسئلة المتكررة**

**هل أحتاج إلى تثبيت Microsoft PowerPoint لإجراء التحويلات والعرض؟**

لا، لا يلزم PowerPoint؛ Aspose.Slides هو محرك مستقل لـ [إنشاء](/slides/ar/net/create-presentation/)، تعديل، [تحويل](/slides/ar/net/convert-presentation/)، و[عرض](/slides/ar/net/convert-powerpoint-to-png/) العروض التقديمية.

**ما الخطوط المطلوبة للعرض الصحيح؟**

في الواقع، يجب أن تكون الخطوط المستخدمة في العرض أو [بدائلها](/slides/ar/net/font-substitution/) متوفرة. لضمان عرض ثابت على Linux/macOS، يُنصح بتثبيت حزم خطوط شائعة.

**لماذا يتم عرض الخط المخصص كبديل أو نص مفقود على Linux؟**

إذا كان ملف الخط يحتوي على سجلات جدول أسماء غير متناسقة أو تالفة، قد يختار مكدس مطابقة الخطوط في Linux (FreeType/fontconfig) سجلًا غير صالح، مما يؤدي إلى عدم التعرف على الخط. استخدام نسخة خط مع سجلات جدول أسماء مصححة أو تثبيت بديل متناسق يحل المشكلة.