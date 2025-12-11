---
title: التثبيت
type: docs
weight: 70
url: /ar/cpp/installation/
keywords:
- تثبيت Aspose.Slides
- تحميل Aspose.Slides
- استخدام Aspose.Slides
- تثبيت Aspose.Slides
- ويندوز
- لينكس
- ماك أو إس
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعرف على كيفية تثبيت Aspose.Slides لـ C++ بسرعة. دليل خطوة بخطوة، متطلبات النظام، وعينات الشيفرة — ابدأ العمل على عروض PowerPoint التقديمية اليوم!"
---

## **ويندوز**
يُوفر NuGet أسهل طريقة لتنزيل وتثبيت واجهات برمجة التطبيقات Aspose للغة C++ على أجهزة الكمبيوتر. 

### **الخيار الأول: تثبيت أو تحديث Aspose.Slides للغة C++ من مدير الحزم NuGet**

1. افتح Microsoft Visual Studio. 
2. أنشئ تطبيق كونسول بسيط. أو يمكنك فتح مشروعك المفضل. 
3. انتقل إلى **Tools** > **NuGet package manager**.
4. ضمن **Browse**، اكتب *Aspose.Slides.Cpp* في حقل النص. 

![todo:image_alt_text](installation_1.png)

3. انقر على الإصدار الذي تحتاجه **Aspose.Slides.Cpp** ثم انقر **Install**. 
   * إذا كنت ترغب في تحديث Aspose.Slides—مما يعني أنك قد قمت بتثبيته بالفعل—انقر **Update** بدلاً من ذلك. 

يتم تنزيل واجهة برمجة التطبيقات المحددة وتضمينها في مشروعك.

### **الخيار 2: تثبيت أو تحديث Aspose.Slides عبر وحدة التحكم لمدير الحزم**

لإحالة [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.Cpp/) باستخدام وحدة التحكم لمدير الحزم، افعل ذلك:

1. افتح solution/المشروع الخاص بك في Visual Studio.

1. انتقل إلى **Tools** > **NuGet Package Manager** > **Package Manager Console**. 

   تفتح وحدة التحكم لمدير الحزم. 

![todo:image_alt_text](installation_2.png)

4. اكتب هذا الأمر: `Install-Package Aspose.Slides.Cpp` 
> إذا كنت ترغب في تثبيت نسخة x86، استخدم الحزمة Aspose.Slides.Cpp.x86: `Install-Package Aspose.Slides.Cpp.x86`

5. اضغط مفتاح Enter.

   يتم تثبيت أحدث إصدار كامل في تطبيقك. 

   * بدلاً من ذلك، يمكنك إضافة اللاحقة `-prerelease` إلى الأمر لتحديد أن أحدث إصدار (بما في ذلك التصحيحات) يجب تثبيته أيضًا.

![todo:image_alt_text](installation_3.png)

​	بمجرد اكتمال التنزيل، يجب أن ترى بعض رسائل التأكيد.  

![todo:image_alt_text](installation_4.png)

إذا لم تكن مألوفًا مع [Aspose EULA](https://about.aspose.com/legal/eula)، فقد ترغب في قراءة الترخيص المذكور في الرابط.  

في وحدة التحكم لمدير الحزم، يمكنك تشغيل الأمر `Update-Package Aspose.Slides.Cpp` للتحقق من وجود تحديثات لحزمة Aspose.Slides. يتم تثبيت التحديثات (إن وجدت) تلقائيًا. يمكنك أيضًا استخدام اللاحقة `-prerelease` لتحديث أحدث إصدار.

### **استخدام مجلدات Include و lib**
1. [Download](https://downloads.aspose.com/slides/cpp) أحدث نسخة من Aspose.Slides للغة C++.
1. قم بفك ضغط المجلد إلى بيئة الإنتاج.
1. لاستخدام Aspose.Slides للغة C++، أشر إلى مجلدات Include و lib في مشروعك

## **FAQ**

**هل هناك نسخة مجانية أو قيود على التجربة؟**

نعم، افتراضيًا، يعمل Aspose.Slides في وضع التقييم، مما يضيف علامات مائية وقد يكون له قيود أخرى. لإزالة القيود، عليك تطبيق [license](/slides/ar/cpp/licensing/) صالح.