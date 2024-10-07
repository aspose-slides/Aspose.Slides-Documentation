---
title: التثبيت
type: docs
weight: 70
url: /cpp/installation/
keywords: "تنزيل Aspose.Slides، تثبيت Aspose.Slides، تثبيت Aspose.Slides، ويندوز، C++"
description: "تثبيت Aspose.Slides لـ C++ على نظام ويندوز"
---

## **ويندوز**
يقدم NuGet أسهل طريقة لتنزيل وتثبيت واجهات برمجة التطبيقات (APIs) الخاصة بـ Aspose لـ C++ على أجهزة الكمبيوتر.

### **الخيار الأول: تثبيت أو تحديث Aspose.Slides لـ C++ من مدير الحزم NuGet**

1. افتح Microsoft Visual Studio.
2. أنشئ تطبيق وحدة تحكم بسيط. أو يمكنك فتح مشروعك المفضل.
3. اذهب إلى **الأدوات** > **مدير حزم NuGet**.
4. تحت **التصفح**، اكتب *Aspose.Slides.Cpp* في حقل النص.

![todo:image_alt_text](installation_1.png)

3. انقر على الإصدار الذي تحتاجه **Aspose.Slides.Cpp** ثم انقر على **تثبيت**.
   * إذا كنت ترغب في تحديث Aspose.Slides - مما يعني أنك قد قمت بتثبيته بالفعل - انقر على **تحديث** بدلاً من ذلك.

يتم تنزيل واجهة برمجة التطبيقات المحددة وإدراجها في مشروعك.

### **الخيار 2: تثبيت أو تحديث Aspose.Slides من خلال وحدة تحكم مدير الحزم**

لإدراج [واجهة برمجة التطبيقات Aspose.Slides](https://www.nuget.org/packages/Aspose.Slides.Cpp/) باستخدام وحدة تحكم مدير الحزم، قم بما يلي:

1. افتح الحل/المشروع الخاص بك في Visual Studio.

1. انتقل إلى **الأدوات** > **مدير حزم NuGet** > **وحدة تحكم مدير الحزم**.

   تفتح وحدة تحكم مدير الحزم.

![todo:image_alt_text](installation_2.png)

4. اكتب هذا الأمر: `Install-Package Aspose.Slides.Cpp`
> إذا كنت ترغب في تثبيت إصدار x86، استخدم حزمة Aspose.Slides.Cpp.x86: `Install-Package Aspose.Slides.Cpp.x86`

5. اضغط على مفتاح Enter.

   يتم تثبيت أحدث إصدار كامل في تطبيقك.

   * بدلاً من ذلك، يمكنك إضافة اللاحقة `-prerelease` إلى الأمر لتحديد أنه يجب تثبيت أحدث إصدار (بما في ذلك التصحيحات).

![todo:image_alt_text](installation_3.png)

​	بمجرد اكتمال التنزيل، يجب أن ترى بعض رسائل التأكيد.

![todo:image_alt_text](installation_4.png)

إذا لم تكن على دراية بـ [EULA Aspose](https://about.aspose.com/legal/eula)، فقد ترغب في قراءة الترخيص المشار إليه في الرابط.

في وحدة تحكم مدير الحزم، يمكنك تشغيل الأمر `Update-Package Aspose.Slides.Cpp` للتحقق من التحديثات الخاصة بحزمة Aspose.Slides. يتم تثبيت التحديثات (إن وجدت) تلقائيًا. يمكنك أيضًا استخدام اللاحقة `-prerelease` لتحديث أحدث إصدار.

### استخدام مجلدات Include و lib
1. [قم بتنزيل](https://downloads.aspose.com/slides/cpp) أحدث إصدار من Aspose.Slides لـ C++.
1. قم بفك ضغط المجلد إلى بيئة الإنتاج.
1. لاستخدام Aspose.Slides لـ C++، قم بإدراج مجلدات Include و lib في مشروعك.