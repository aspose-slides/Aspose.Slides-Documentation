---
title: التثبيت
type: docs
weight: 70
url: /ar/net/installation/
keywords:
- تثبيت Aspose.Slides
- تنزيل Aspose.Slides
- استخدام Aspose.Slides
- تثبيت Aspose.Slides
- ويندوز
- لينكس
- ماك أو إس
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيف تثبت Aspose.Slides لـ .NET بسرعة. دليل خطوة بخطوة، ومتطلبات النظام، وعينات الكود — ابدأ العمل على عروض PowerPoint التقديمية اليوم!"
---

## **ويندوز**
يوفر NuGet أسهل طريقة لتنزيل وتثبيت واجهات برمجة تطبيقات Aspose لتقنية .NET على أجهزة الكمبيوتر. 

### **الطريقة 1: تثبيت أو تحديث Aspose.Slides من مدير الحزم NuGet**

1. افتح Microsoft Visual Studio. 
2. أنشئ تطبيقًا سطريًا بسيطًا أو افتح مشروعًا موجودًا. 
3. انتقل عبر **Tools** > **NuGet package manager**.
4. ضمن **Browse**، ابحث عن *Aspose Slides* في حقل النص. 
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. انقر على **Aspose.Slides.NET** ثم انقر على **Install**. 
   * إذا كنت تريد تحديث Aspose.Slides — بافتراض أنك قمت بتثبيته بالفعل — انقر **Update** بدلًا من ذلك. 

يتم تنزيل الواجهة المختارة وإضافتها كمُراجَع في مشروعك.

### **الطريقة 2: تثبيت أو تحديث Aspose.Slides عبر وحدة التحكم لمدير الحزم**

هذا هو الطريقة التي تشير فيها إلى [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) عبر وحدة التحكم لمدير الحزم:

1. افتح Microsoft Visual Studio. 
2. أنشئ تطبيقًا سطريًا بسيطًا أو افتح مشروعًا موجودًا. 
3. انتقل عبر **Tools** > **Library Package Manager** > **Package Manager Console**. 
![todo:image_alt_text](installation_2.png)
4. شغّل هذا الأمر: `Install-Package Aspose.Slides.NET` 
![todo:image_alt_text](installation_3.png)
يتم تثبيت أحدث إصدار كامل في التطبيق الخاص بك. 

* بدلاً من ذلك، يمكنك إضافة لاحقة `-prerelease` إلى الأمر لتحديد أنه يجب تثبيت أحدث إصدار (بما في ذلك التصحيحات) أيضًا.

 تظهر تلميحة **Installing Aspose.Slides.NET** تقريبًا في أسفل النافذة. 
![todo:image_alt_text](installation_4.png)

عند اكتمال التنزيل، يجب أن ترى بعض رسائل التأكيد. 

إذا لم تكن على دراية بـ [Aspose EULA](https://about.aspose.com/legal/eula)، قد ترغب في قراءة الترخيص المشار إليه في الرابط. 
![todo:image_alt_text](installation_5.png)

في تطبيقك، يجب أن ترى أن Aspose.Slides تم إضافته وإحالاته بنجاح. 
![todo:image_alt_text](installation_6.png)

في وحدة تحكم مدير الحزم، يمكنك تشغيل الأمر `Update-Package Aspose.Slides.NET` للتحقق من التحديثات لحزمة Aspose.Slides. تُثبت التحديثات (إن وجد) تلقائيًا. يمكنك أيضًا استخدام لاحقة `-prerelease` لتحديث أحدث إصدار.
#### **الاعتبارات عند التشغيل في بيئة خادم مشتركة**
نوصي بشدة بتشغيل جميع مكونات Aspose .NET مع مجموعة الأذونات **Full Trust** لأن مكونات Aspose قد تحتاج أحيانًا للوصول إلى إعدادات السجل والملفات الموجودة في أماكن غير دليل الويب الافتراضي — على سبيل المثال، عندما تحتاج مكونات Aspose لقراءة الخطوط. 

علاوة على ذلك، تعتمد مكونات Aspose.NET على الفئات الأساسية لنظام .NET — وبعض تلك الفئات تتطلب أيضًا إذن Full Trust لبعض العمليات في حالات معينة.

مزودو خدمة الإنترنت الذين يستضيفون تطبيقات متعددة من شركات مختلفة عادةً ما يفرضون مستوى أمان Medium Trust. في حالة .NET 2.0، قد يؤدي مثل هذا المستوى الأمني إلى قيود تؤثر على عمليات Aspose.Slides:

- **RegistryPermission** غير متاح. يعني هذا أنك لا تستطيع الوصول إلى السجل، وهو مطلوب لتعداد الخطوط المثبتة عند تصيير المستندات.
- **FileIOPermission** مقيد. يعني هذا أنك لا تستطيع الوصول إلا إلى الملفات ضمن تسلسل دليل الويب الافتراضي لتطبيقك. وقد يعني ذلك أيضًا أن الخطوط لا يمكن قراءتها أثناء عمليات التصدير.

لهذه الأسباب، نوصي بشدة بتشغيل Aspose.Slides على أذونات **Full Trust**. إذا استخدمت **Medium trust**، قد تواجه تناقضات — قد لا تعمل بعض ميزات المكتبة (مثل التصيير) عند إجراء مهام معينة. 

## **macOS**

يوفر NuGet أسهل طريقة لتنزيل وتثبيت Aspose.Slides لتقنية .NET على أجهزة mac. 

**تثبيت المتطلبات المسبقة**

تعمل مساحة الاسم `System.Drawing` بشكل مختلف في macOS، لذا عليك تثبيت mono-libgdiplus. 

> في .NET 5 والإصدارات السابقة، حزمة NuGet [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) تعمل على Windows و Linux و macOS. ومع ذلك، هناك بعض الاختلافات بين الأنظمة. في Linux و macOS، يتم تنفيذ وظائف GDI+ عبر مكتبة [libgdiplus](https://www.mono-project.com/docs/gui/libgdiplus/). هذه المكتبة لا تُثبت بشكل افتراضي في معظم توزيعات Linux ولا تدعم جميع وظائف GDI+ على Windows و macOS. هناك أيضًا أنظمة لا تتوفر فيها libgdiplus مطلقًا. لاستخدام الأنواع من حزمة System.Drawing.Common على Linux و macOS، يجب تثبيت libgdiplus بشكل منفصل. للمزيد من المعلومات، راجع [Install .NET on Linux](https://docs.microsoft.com/en-us/dotnet/core/install/linux) أو [Install .NET on macOS](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus).

لتثبيت mono-libgdiplus بشكل منفصل على جهاز mac الخاص بك، راجع [this article](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus) من وثائق .NET. 

### **تثبيت Aspose.Slides**

1. افتح Visual Studio. 
2. أنشئ تطبيقًا سطريًا بسيطًا أو افتح مشروعًا موجودًا.
3. انتقل عبر **Project** > **Manage NuGet Packages...**
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. اكتب *Aspose.Slides* في حقل النص. 
5. انقر على **Aspose.Slides for .NET** ثم انقر على **Add Package.** 
6. أضف مقتطف كود بسيط.
   * يمكنك نسخ الكود من [this page](/slides/ar/net/create-presentation/).
7. شغّل التطبيق.
8. افتح *folder/bin/Debug/presentation_file_name* الخاص بمشروعك.

## **الأسئلة الشائعة**

**هل هناك نسخة مجانية أو قيود على التجربة؟**

نعم، بشكل افتراضي، يعمل Aspose.Slides في وضع التقييم، مما يضيف علامات مائية وقد يكون له قيود أخرى. لإزالة القيود، يجب تطبيق [license](/slides/ar/net/licensing/) صالح.