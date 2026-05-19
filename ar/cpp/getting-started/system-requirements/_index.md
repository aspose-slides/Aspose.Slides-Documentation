---
title: متطلبات النظام
type: docs
weight: 80
url: /ar/cpp/system-requirements/
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
- العرض التقديمي
- C++
- Aspose.Slides
description: "اكتشف متطلبات نظام Aspose.Slides for C++. تأكد من دعم PowerPoint و OpenDocument بسلاسة على Windows و Linux و macOS."
---
## **المقدمة**

Aspose.Slides لا يتطلب تثبيت Microsoft PowerPoint لأنه محرك مستقل لإنشاء مستندات Microsoft PowerPoint والتحويل وتخطيط الصفحات وعرضها.

## **أنظمة التشغيل المدعومة**
Aspose.Slides for C++ هي مكتبة C++ أصلية. تدعم Aspose.Slides for C++ أنظمة التشغيل والمنصات 64-بت و 32-بت التالية:

### **ويندوز**
- Microsoft Windows Server 2008 (x64, x86)
- Microsoft Windows Server 2012 (x64, x86)
- Microsoft Windows Server 2012 R2 (x64, x86)
- Microsoft Windows Server 2016 (x64, x86)
- Microsoft Windows Server 2019 (x64, x86)
- Microsoft Windows XP (x64, x86)
- Microsoft Windows 7 (x64, x86)
- Microsoft Windows 8, 8.1 (x64, x86)
- Microsoft Windows 10 (x64, x86)

### **لينكس**
- نظام Ubuntu 16.04 أو أحدث.
- CentOS 8 أو أحدث.
- Fedora 24 أو أحدث.
- وغيرها من أنظمة Linux بمعمارية x86_64 مع glibc 2.23 أو أحدث.

### **macOS**
- macOS Monterey 12.1 أو أحدث.

## **بيئات التطوير**
يمكنك استخدام Aspose.Slides for C++ عند تطوير التطبيقات لنظام Windows أو Linux أو macOS.

### **ويندوز**
- Microsoft Visual Studio 2017 أو أحدث.
- CMake 3.18 أو أحدث.

### **لينكس**
- Clang 3.9 أو أحدث.
- GCC 6.1 أو أحدث.
- CMake 3.18 أو أحدث.

### **macOS**
- Xcode 13.4 أو أحدث.

## **الأسئلة المتكررة**

**هل أحتاج إلى تثبيت Microsoft PowerPoint للتحويلات والعرض؟**

لا، لا يلزم وجود PowerPoint؛ Aspose.Slides هو محرك مستقل لإنشاء [إنشاء](/slides/ar/cpp/create-presentation/)، تعديل، [تحويل](/slides/ar/cpp/convert-presentation/)، و[عرض](/slides/ar/cpp/convert-powerpoint-to-png/) العروض التقديمية.

**ما الخطوط المطلوبة للعرض الصحيح؟**

في الواقع، يجب أن تكون الخطوط المستخدمة في العرض التقديمي أو [البدائل](/slides/ar/cpp/font-substitution/) المناسبة متاحة. لضمان عرض ثابت على Linux/macOS، يُنصح بتثبيت حزم الخطوط الشائعة.

**لماذا يتم عرض الخط المخصص كخط احتياطي أو نص مفقود على Linux؟**

إذا كان ملف الخط يحتوي على سجلات جدول أسماء غير متناسقة أو تالفة، قد يختار نظام مطابقة الخطوط في Linux (FreeType/fontconfig) سجلًا غير صالح، مما يؤدي إلى عدم حل الخط. باستخدام نسخة من الخط تحتوي على سجلات جدول أسماء مصححة أو تثبيت بديل متناسق يحل المشكلة.