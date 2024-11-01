---
title: الترخيص
type: docs
weight: 120
url: /ar/cpp/licensing/
---

## **تقييم Aspose.Slides**

{{% alert color="primary" %}} 

يمكنك تنزيل نسخة تجريبية من **Aspose.Slides for C++** من [صفحة تحميل NuGet الخاصة بها](https://www.nuget.org/packages/Aspose.Slides.CPP/). توفر النسخة التجريبية نفس الوظائف مثل النسخة المرخصة من المنتج. حزمة التقييم هي نفسها الحزمة المشتراة. تصبح النسخة التجريبية مرخصة ببساطة بعد إضافة بعض السطور البرمجية إليها (لتطبيق الترخيص).

بمجرد أن تكون راضيًا عن تقييمك لـ **Aspose.Slides**، يمكنك [شراء ترخيص](https://purchase.aspose.com/buy). نوصي بالاطلاع على أنواع الاشتراكات المختلفة. إذا كانت لديك أسئلة، اتصل بفريق مبيعات Aspose.

تأتي كل ترخيص Aspose مع اشتراك لمدة عام المجاني لتحديثات جديدة أو إصلاحات تصدر خلال فترة الاشتراك. يحصل المستخدمون مع منتجات مرخصة أو حتى النسخ التجريبية على دعم تقني مجاني وغير محدود.

{{% /alert %}} 

**قيود النسخة التجريبية**

* على الرغم من أن النسخة التجريبية من Aspose.Slides (بدون ترخيص محدد) توفر وظائف كاملة للمنتج، إلا أنها تضيف علامة مائية تجريبية في أعلى المستند عند الفتح وعملية الحفظ. 
* أنت محدود بشريحة واحدة عند استخراج النصوص من شرائح العرض.

{{% alert color="primary" %}} 

لاختبار Aspose.Slides بدون قيود، يمكنك طلب **ترخيص مؤقت لمدة 30 يومًا**. انظر [كيف تحصل على ترخيص مؤقت](https://purchase.aspose.com/temporary-license) للحصول على مزيد من المعلومات.

{{% /alert %}}

## **الترخيص في Aspose.Slides**

* تصبح النسخة التجريبية مرخصة بعد شراء ترخيص وإضافة بعض السطور البرمجية إليها (لتطبيق الترخيص).
* الترخيص هو ملف XML نصي يحتوي على تفاصيل مثل اسم المنتج، عدد المطورين المرخص لهم، تاريخ انتهاء الاشتراك، وما إلى ذلك. 
* يتم توقيع ملف الترخيص رقميًا، لذا يجب عدم تعديل الملف. حتى الإضافة غير المقصودة لسطر إضافي إلى محتويات الملف ستجعله غير صالح.
* عادةً ما تحاول Aspose.Slides for C++ العثور على الترخيص في هذه المواقع:
  * مسار صريح
  * المجلد الذي يحتوي على DLL المكون (المضمن في Aspose.Slides)
  * المجلد الذي يحتوي على التجميع الذي يستدعي DLL المكون (المضمن في Aspose.Slides)
* لتجنب القيود المرتبطة بالنسخة التجريبية، تحتاج إلى تعيين الترخيص قبل استخدام Aspose.Slides. تحتاج فقط إلى تعيين الترخيص مرة واحدة لكل تطبيق أو عملية.

## **تطبيق ترخيص**

يمكن تحميل ترخيص من **ملف**، **تدفق**، أو **موارد مضمنة**.

{{% alert color="primary" %}}

توفر Aspose.Slides فئة [License](https://reference.aspose.com/slides/cpp/class/aspose.slides.license/) لعمليات الترخيص.

{{% /alert %}} 

### **ملف**

أسهل طريقة لتعيين ترخيص تتطلب منك وضع ملف الترخيص في نفس المجلد الذي يحتوي على DLL المكون (المضمن في Aspose.Slides) وتحديد اسم الملف بدون مساره.

يوضح هذا الكود C++ كيفية تعيين ملف الترخيص:

```c++
SharedPtr<Aspose::Slides::License> lic = MakeObject<Aspose::Slides::License>();

lic->SetLicense(L"Aspose.Slides.lic");
```

{{% alert color="warning" %}} 

إذا وضعت ملف الترخيص في دليل مختلف، فعند استدعاء طريقة [License::SetLicense()](https://reference.aspose.com/slides/cpp/class/aspose.slides.license#a44102d1d52a5e45643345448b1814a67)، يجب أن يكون اسم ملف الترخيص في نهاية المسار المحدد هو نفسه اسم ملف الترخيص الخاص بك.

على سبيل المثال، يمكنك تغيير اسم ملف الترخيص إلى *Aspose.Slides.lic.xml*. ثم، في الكود الخاص بك، يجب عليك تمرير المسار إلى الملف (الذي ينتهي بـ *Aspose.Slides.lic.xml*) إلى طريقة [License::SetLicense()](https://reference.aspose.com/slides/cpp/class/aspose.slides.license#a44102d1d52a5e45643345448b1814a67).

{{% /alert %}}

### **تدفق**

يمكنك تحميل ترخيص من تدفق. يوضح هذا الكود C++ كيفية تطبيق ترخيص من تدفق:

```c++
SharedPtr<Aspose::Slides::License> lic = MakeObject<Aspose::Slides::License>();

System::SharedPtr<System::IO::FileStream> stream= System::IO::File::OpenRead(L"Aspose.Slides.lic");

lic->SetLicense(stream); 
```

## **التحقق من صلاحية الترخيص**

لتحقق مما إذا تم تعيين ترخيص بشكل صحيح، يمكنك التحقق من صحته. يوضح هذا الكود C++ كيفية التحقق من صلاحية ترخيص:

```c++
System::SharedPtr<Aspose::Slides::License> license = System::MakeObject<Aspose::Slides::License>();
license->SetLicense(u"Aspose.Slides.lic");
if (license->IsLicensed())
{
    System::Console::WriteLine(u"الترخيص صالح!");
    System::Console::Read();
}
```

## **أمان الخيوط**

{{% alert title="ملاحظة" color="warning" %}} 

طريقة [License::SetLicense()](https://reference.aspose.com/slides/cpp/class/aspose.slides.license#a44102d1d52a5e45643345448b1814a67) ليست آمنة للخيوط. إذا كان يجب استدعاء هذه الطريقة بشكل متزامن من العديد من الخيوط، فقد ترغب في استخدام بدائل المزامنة (مثل قفل) لتجنب المشاكل. 

{{% /alert %}}