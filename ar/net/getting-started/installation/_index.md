---
title: التثبيت
type: docs
weight: 70
url: /net/installation/
keywords: "تحميل Aspose.Slides، تثبيت Aspose.Slides، تثبيت Aspose.Slides، Windows، macOS، .NET"
description: "تثبيت Aspose.Slides لـ .NET على Windows أو macOS"
---

## **Windows**
يوفر NuGet أسهل طريقة لتنزيل وتثبيت واجهات برمجة التطبيقات Aspose لـ .NET على أجهزة الكمبيوتر.

### **الطريقة 1: تثبيت أو تحديث Aspose.Slides من مدير حزم NuGet**

1. افتح Microsoft Visual Studio.
2. أنشئ تطبيق وحدة تحكم بسيط أو افتح مشروعًا موجودًا.
3. انتقل إلى **أدوات** > **مدير حزم NuGet**.
4. تحت **تصفح**، ابحث عن *Aspose Slides* في حقل النص.
{{% image img="installation_1.png" alt="تثبيت Aspose.Slides من مدير حزم NuGet - 1" %}}
5. انقر على **Aspose.Slides.NET** ثم انقر على **تثبيت**.
   * إذا كنت تريد تحديث Aspose.Slides - على افتراض أنك قمت بتثبيته مسبقًا - انقر على **تحديث** بدلاً من ذلك.

سيتم تنزيل واجهة برمجة التطبيقات المحددة وإضافتها إلى مشروعك.

### **الطريقة 2: تثبيت أو تحديث Aspose.Slides عبر وحدة التحكم في مدير الحزم**

إليك كيفية الإشارة إلى [واجهة برمجة التطبيقات Aspose.Slides](https://www.nuget.org/packages/Aspose.Slides.NET/) من خلال وحدة التحكم في مدير الحزم:

1. افتح Microsoft Visual Studio.
2. أنشئ تطبيق وحدة تحكم بسيط أو افتح مشروعًا موجودًا.
3. انتقل إلى **أدوات** > **مدير حزم المكتبة** > **وحدة التحكم في مدير الحزم**.
![todo:image_alt_text](installation_2.png)
4. نفذ هذا الأمر: `Install-Package Aspose.Slides.NET`
![todo:image_alt_text](installation_3.png)
سيتم تثبيت النسخة الكاملة الأخيرة في تطبيقك.

* بدلاً من ذلك، يمكنك إضافة لاحقة `-prerelease` إلى الأمر لتحديد أن النسخة الأخيرة (بما في ذلك الإصلاحات العاجلة) يجب أن تُثبت أيضًا.

تظهر نصيحة **تثبيت Aspose.Slides.NET** حول أسفل النافذة.
![todo:image_alt_text](installation_4.png)

بمجرد اكتمال التنزيل، يجب أن ترى بعض رسائل التأكيد.

إذا لم تكن على دراية ب [اتفاقية ترخيص Aspose](https://about.aspose.com/legal/eula)، فقد ترغب في قراءة الترخيص المشار إليه في الرابط.
![todo:image_alt_text](installation_5.png)

يجب أن ترى في تطبيقك أنه تم إضافة Aspose.Slides بنجاح والإشارة إليه.
![todo:image_alt_text](installation_6.png)

في وحدة التحكم في مدير الحزم، يمكنك تنفيذ الأمر `Update-Package Aspose.Slides.NET` للتحقق من التحديثات لحزمة Aspose.Slides. يتم تثبيت التحديثات (إذا وجدت) تلقائيًا. يمكنك أيضًا استخدام لاحقة `-prerelease` لتحديث النسخة الأخيرة.
#### **الاعتبارات عند التشغيل في بيئة خادم مشترك**
نوصي بشدة بتشغيل جميع مكونات Aspose .NET مع مجموعة أذونات **الثقة الكاملة** لأن مكونات Aspose تحتاج أحيانًا إلى الوصول إلى إعدادات السجل والملفات الموجودة في أماكن غير الدليل الافتراضي - على سبيل المثال، عندما تحتاج مكونات Aspose إلى قراءة الخطوط.

علاوة على ذلك، تعتمد مكونات Aspose.NET على فئات نظام .NET الأساسية - وبعض تلك الفئات تتطلب أيضًا إذن الثقة الكاملة للعمليات في حالات معينة.

توفر مزودات خدمات الإنترنت، التي تستضيف تطبيقات متعددة من شركات مختلفة، غالباً مستوى أمان الثقة المتوسطة. في حالة .NET 2.0، قد يؤدي مثل هذا المستوى من الأمان إلى قيود تؤثر على عمليات Aspose.Slides:

- **RegistryPermission** غير متوفر. هذا يعني أنك لا تستطيع الوصول إلى السجل، وهو مطلوب لإدراج الخطوط المثبتة عند تصيير المستندات.
- **FileIOPermission** مقيد. هذا يعني أنك يمكنك فقط الوصول إلى الملفات في هيكل الدليل الافتراضي لتطبيقك. هذا أيضًا يعني بشكل محتمل عدم قراءة الخطوط أثناء عمليات التصدير.

لأسباب أعلاه، نوصي بشدة بتشغيل Aspose.Slides بأذونات **الثقة الكاملة**. إذا كنت تستخدم **الثقة المتوسطة**، فقد تواجه تناقضات - قد لا تعمل بعض ميزات المكتبة (مثل التصيير) عند تنفيذ مهام معينة.

## **macOS**

يوفر NuGet أسهل طريقة لتنزيل وتثبيت Aspose.Slides لـ .NET على أجهزة mac.

**تثبيت المتطلبات المسبقة**

يعمل فضاء الأسماء `System.Drawing` بشكل مختلف في macOS، لذلك يجب عليك تثبيت mono-libgdiplus.

> في .NET 5 والإصدارات السابقة، يعمل حزمة NuGet [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) على Windows وLinux وmacOS. ومع ذلك، هناك بعض الفروقات بين المنصات. على Linux وmacOS، يتم تنفيذ وظيفة GDI+ بواسطة مكتبة [libgdiplus](https://www.mono-project.com/docs/gui/libgdiplus/). هذه المكتبة غير مثبتة بشكل افتراضي في معظم توزيعات Linux ولا تدعم كل وظيفة GDI+ على Windows وmacOS. هناك أيضًا منصات لا تتوفر فيها libgdiplus على الإطلاق. لاستخدام الأنواع من حزمة System.Drawing.Common على Linux وmacOS، يجب عليك تثبيت libgdiplus بشكل منفصل. لمزيد من المعلومات، انظر [تثبيت .NET على Linux](https://docs.microsoft.com/en-us/dotnet/core/install/linux) أو [تثبيت .NET على macOS](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus).

لتثبيت mono-libgdiplus بشكل منفصل على جهاز mac الخاص بك، راجع [هذا المقال](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus) من وثائق .NET.

### **تثبيت Aspose.Slides**

1. افتح Visual Studio.
2. أنشئ تطبيق وحدة تحكم بسيط أو افتح مشروعًا موجودًا.
3. انتقل إلى **مشروع** > **إدارة حزم NuGet...**
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. اكتب *Aspose.Slides* في حقل النص.
5. انقر على **Aspose.Slides لـ .NET** ثم انقر على **إضافة حزمة**.
6. أضف مقتطف كود بسيط.
   * يمكنك نسخ الكود من [هذه الصفحة](/slides/net/create-presentation/).
7. نفذ التطبيق.
8. افتح *folder/bin/Debug/presentation_file_name* لمشروعك.