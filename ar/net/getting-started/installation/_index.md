---
title: التثبيت
type: docs
weight: 70
url: /ar/net/installation/
keywords: "تنزيل Aspose.Slides, تثبيت Aspose.Slides, تثبيت Aspose.Slides, Windows, macOS, .NET"
description: "تثبيت Aspose.Slides لـ .NET في Windows أو macOS"
---

## **Windows**
يوفر NuGet أسهل طريقة لتنزيل وتثبيت واجهات برمجة تطبيقات Aspose لـ .NET على أجهزة الكمبيوتر. 

### **الطريقة 1: تثبيت أو تحديث Aspose.Slides من مدير الحزم NuGet**

1. افتح Microsoft Visual Studio. 
2. أنشئ تطبيق وحدة تحكم بسيط أو افتح مشروعًا موجودًا. 
3. انتقل عبر **Tools** > **NuGet package manager**.
4. ضمن **Browse**، ابحث عن *Aspose Slides* في حقل النص. 
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. انقر **Aspose.Slides.NET** ثم انقر **Install**. 
   * إذا كنت تريد تحديث Aspose.Slides — بافتراض أنك قمت بتثبيته بالفعل — انقر **Update** بدلاً من ذلك. 

يتم تنزيل واجهة برمجة التطبيقات المحددة وإضافتها كمراجع في مشروعك.

### **الطريقة 2: تثبيت أو تحديث Aspose.Slides عبر وحدة تحكم مدير الحزم**

هذه هي الطريقة التي تُشير بها إلى [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) عبر وحدة تحكم مدير الحزم:

1. افتح Microsoft Visual Studio. 
2. أنشئ تطبيق وحدة تحكم بسيط أو افتح مشروعًا موجودًا. 
3. انتقل عبر **Tools** > **Library Package Manager** > **Package Manager Console**. 
![todo:image_alt_text](installation_2.png)
4. شغِّل هذا الأمر: `Install-Package Aspose.Slides.NET` 
![todo:image_alt_text](installation_3.png)
يتم تثبيت أحدث إصدار كامل في تطبيقك. 

* بدلاً من ذلك، يمكنك إضافة اللاحقة `-prerelease` إلى الأمر لتحديد أنه يجب تثبيت أحدث إصدار (بما في ذلك التصحيحات) أيضًا.

تظهر تلميحة **Installing Aspose.Slides.NET** في أسفل النافذة. 
![todo:image_alt_text](installation_4.png)

بمجرد اكتمال التنزيل، يجب أن ترى بعض رسائل التأكيد. 

إذا لم تكن على دراية بـ [Aspose EULA](https://about.aspose.com/legal/eula)، فقد ترغب في قراءة الترخيص المشار إليه في الرابط. 
![todo:image_alt_text](installation_5.png)

في تطبيقك، يجب أن ترى أن Aspose.Slides قد تمت إضافته وإحالاته بنجاح. 
![todo:image_alt_text](installation_6.png)

في وحدة تحكم مدير الحزم، يمكنك تشغيل الأمر `Update-Package Aspose.Slides.NET` للتحقق من وجود تحديثات لحزمة Aspose.Slides. يتم تثبيت التحديثات (إن وجدت) تلقائيًا. يمكنك أيضًا استخدام اللاحقة `-prerelease` لتحديث أحدث إصدار.
#### **اعتبارات عند التشغيل في بيئة خادم مشترك**
نوصي بشدة بتشغيل جميع مكونات Aspose .NET مع مجموعة أذونات **Full Trust** لأن مكونات Aspose أحيانًا تحتاج إلى الوصول إلى إعدادات السجل والملفات الموجودة في أماكن غير دليل الويب الافتراضي — على سبيل المثال، عندما تحتاج المكونات إلى قراءة الخطوط. 

علاوةً على ذلك، تعتمد مكونات Aspose.NET على فئات نظام .NET الأساسية — وبعض هذه الفئات يتطلب أذن **Full Trust** للعمليات في حالات معينة.

مزودو خدمة الإنترنت الذين يستضيفون تطبيقات متعددة من شركات مختلفة يفرضون غالبًا مستوى أمان **Medium Trust**. في حالة .NET 2.0، قد يؤدي هذا المستوى إلى قيود تؤثر على عمليات Aspose.Slides:

- **RegistryPermission** غير متاح. وهذا يعني أنك لا تستطيع الوصول إلى السجل، وهو مطلوب لتعداد الخطوط المثبتة عند عرض المستندات.
- **FileIOPermission** مقيد. وهذا يعني أنك تستطيع فقط الوصول إلى الملفات في تسلسل دليل تطبيقك الافتراضي. وهذا قد يمنع قراءة الخطوط خلال عمليات التصدير. 

لذلك نوصي بشدة بتشغيل Aspose.Slides على أذونات **Full Trust**. إذا استخدمت **Medium trust**، قد تواجه عدم تجانس — بعض ميزات المكتبة (مثل العرض) قد لا تعمل عند أداء مهام معينة. 

## **macOS**

يوفر NuGet أسهل طريقة لتنزيل وتثبيت Aspose.Slides لـ .NET على أجهزة ماك. 

**المتطلبات المسبقة**

نطاق الاسم `System.Drawing` يعمل بشكل مختلف في macOS، لذلك عليك تثبيت mono-libgdiplus. 

> In .NET 5 and previous versions, the [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) NuGet package works on Windows, Linux, and macOS. However, there are some platform differences. On Linux and macOS, the GDI+ functionality is implemented by the [libgdiplus)](https://www.mono-project.com/docs/gui/libgdiplus/) library. This library is not installed by default in most Linux distributions and doesn't support all the functionality of GDI+ on Windows and macOS. There are also platforms where libgdiplus is not available at all. To use types from the System.Drawing.Common package on Linux and macOS, you must install libgdiplus separately. For more information, see [Install .NET on Linux](https://docs.microsoft.com/en-us/dotnet/core/install/linux) or [Install .NET on macOS](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus).s

لتثبيت mono-libgdiplus بشكل منفصل على جهاز ماك الخاص بك، راجع [this article](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus) من توثيق .NET. 

### **تثبيت Aspose.Slides**

1. افتح Visual Studio. 
2. أنشئ تطبيق وحدة تحكم بسيط أو افتح مشروعًا موجودًا.
3. انتقل عبر **Project** > **Manage NuGet Packages...**
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. اكتب *Aspose.Slides* في حقل النص. 
5. انقر **Aspose.Slides for .NET** ثم انقر **Add Package.** 
6. أضف مقتطف كود بسيط.
   * يمكنك نسخ الكود من [this page](/slides/ar/net/create-presentation/).
7. شغِّل التطبيق.
8. افتح *folder/bin/Debug/presentation_file_name* في مشروعك.

## **FAQ**

**هل هناك نسخة مجانية أو قيود على الفترة التجريبية؟**

نعم، بشكل افتراضي يعمل Aspose.Slides في وضع التقييم، مما يضيف علامات مائية وقد يكون له قيود أخرى. لإزالة القيود، عليك تطبيق [license](/slides/ar/net/licensing/).