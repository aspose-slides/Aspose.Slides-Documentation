---
title: الترخيص
type: docs
weight: 80
url: /ar/net/licensing/
---

## **تقييم Aspose.Slides**

{{% alert color="primary" %}} 

يمكنك تنزيل نسخة تقييم من **Aspose.Slides لـ .NET** من [صفحة تحميل NuGet الخاصة به](https://www.nuget.org/packages/Aspose.Slides.NET/). توفر نسخة التقييم نفس وظائف النسخة المرخصة من المنتج. حزمة التقييم هي نفسها الحزمة المشتراة. ببساطة تصبح نسخة التقييم مرخصة بعد إضافة بضع سطور من التعليمات البرمجية إليها (لتطبيق الترخيص).

بمجرد أن تكون راضيًا عن تقييمك لـ **Aspose.Slides**، يمكنك [شراء ترخيص](https://purchase.aspose.com/buy). نوصي بالاطلاع على أنواع الاشتراكات المختلفة. إذا كان لديك أسئلة، تواصل مع فريق مبيعات Aspose.

تأتي كل ترخيص Aspose مع اشتراك لمدة عام لترقيات مجانية إلى إصدارات جديدة أو إصلاحات تصدر خلال فترة الاشتراك. يحصل المستخدمون الذين لديهم منتجات مرخصة أو حتى نسخ تقييم على الدعم الفني المجاني وغير المحدود.

{{% /alert %}} 

**قيود نسخة التقييم**

* بينما توفر نسخة تقييم Aspose.Slides (بدون ترخيص محدد) جميع وظائف المنتج، إلا أنها تضيف علامة مائية للتقييم في أعلى المستند عند فتحه وحفظه. 
* أنت مقيد بشريحة واحدة فقط عند استخراج النصوص من شرائح العرض التقديمي.

{{% alert color="primary" %}} 

لاختبار Aspose.Slides بدون قيود، يمكنك طلب **ترخيص مؤقت لمدة 30 يومًا**. انظر [كيفية الحصول على ترخيص مؤقت](https://purchase.aspose.com/temporary-license) للحصول على مزيد من المعلومات.

{{% /alert %}}

## **الترخيص في Aspose.Slides**
* تصبح نسخة التقييم مرخصة بعد شراء ترخيص وإضافة بضع سطور من التعليمات البرمجية إليها (لتطبيق الترخيص).
* الترخيص هو ملف XML نصي يحتوي على تفاصيل مثل اسم المنتج، عدد المطورين المرخص لهم، تاريخ انتهاء الاشتراك، وما إلى ذلك. 
* يتم توقيع ملف الترخيص رقميًا، لذا يجب عليك عدم تعديل الملف. حتى إضافة غير مقصودة لفاصل سطر إضافي إلى محتويات الملف ستلغي صلاحيته.
* عادةً ما تحاول Aspose.Slides العثور على الترخيص في هذه المواقع:
  * مسار محدد
  * المجلد الذي يحتوي على DLL المكون (المتضمن في Aspose.Slides)
  * المجلد الذي يحتوي على التجميع الذي استدعى DLL المكون (المتضمن في Aspose.Slides)
  * المجلد الذي يحتوي على التجميع الرئيسي (ملف .exe الخاص بك)
  * مورد مضمن في التجميع الذي استدعى DLL المكون (المتضمن في Aspose.Slides).
* لتجنب القيود المرتبطة بنسخة التقييم، تحتاج إلى تعيين ترخيص قبل استخدام Aspose.Slides. يتعين عليك تعيين ترخيص مرة واحدة فقط لكل تطبيق أو عملية.

{{% alert color="primary" %}} 

ربما ترغب في الاطلاع على [الترخيص بمقياس](https://docs.aspose.com/slides/net/metered-licensing/).

{{% /alert %}} 


## **تطبيق ترخيص**
يمكن تحميل الترخيص من **ملف**، **تدفق**، أو **موارد مضمنة**. 

{{% alert color="primary" %}}

توفر Aspose.Slides فئة [License](https://reference.aspose.com/slides/net/aspose.slides/license) لعمليات الترخيص.

{{% /alert %}} 

### **ملف**
أسهل طريقة لتعيين ترخيص تتطلب منك وضع ملف الترخيص في نفس المجلد الذي يحتوي على DLL المكون (المتضمن في Aspose.Slides) وتحديد اسم الملف فقط بدون مساره.

هذا الكود C# يوضح لك كيفية تعيين ملف الترخيص:

``` csharp
// إنشاء كائن من فئة License 
Aspose.Slides.License license = new Aspose.Slides.License();

// تعيين مسار ملف الترخيص
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" %}} 

إذا وضعت ملف الترخيص في دليل مختلف، عند استدعاء أسلوب [SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/#setlicense_1)، يجب أن يكون اسم ملف الترخيص في نهاية المعطى الصريح هو نفسه اسم ملف الترخيص الخاص بك.

على سبيل المثال، يمكنك تغيير اسم ملف الترخيص إلى *Aspose.Slides.lic.xml*. ثم، في كودك، عليك تمرير المسار إلى الملف (ينتهي بـ *Aspose.Slides.lic.xml*) إلى أسلوب [SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/#setlicense_1).

{{% /alert %}}

### **تدفق**
يمكنك تحميل الترخيص من تدفق. يوضح لك هذا الكود C# كيفية تطبيق ترخيص من تدفق:

``` csharp
// إنشاء كائن من فئة License 
Aspose.Slides.License license = new Aspose.Slides.License();

// تعيين الترخيص من خلال تدفق
license.SetLicense(myStream);
```

### **موارد مضمنة**
يمكنك حزم الترخيص مع تطبيقك (لتجنب فقدانه) عن طريق إضافة الترخيص كموارد مضمنة في أحد التجميعات التي تستدعي DLL المكون (المتضمن في Aspose.Slides). 

إليك كيفية إضافة ملف الترخيص كموارد مضمنة:

1. في Visual Studio، أضف ملف الترخيص (.lic) إلى المشروع بهذه الطريقة: مر من خلال **ملف** > **إضافة عنصر موجود** > **إضافة**. 
2. حدد الملف في **مستعرض الحل**.
3. في نافذة **الخصائص**، قم بتعيين **نوع البناء** إلى **موارد مضمنة**.
4. للوصول إلى الترخيص المضمن في التجميع، أضف ملف الترخيص كموارد مضمنة إلى المشروع، ثم مرر اسم ملف الترخيص إلى الأسلوب `SetLicense`. 


تقوم فئة `License` تلقائيًا بالعثور على ملف الترخيص في الموارد المضمنة. لا تحتاج إلى استدعاء الأساليب `GetExecutingAssembly` و `GetManifestResourceStream` من فئة `System.Reflection.Assembly` في إطار عمل Microsoft .NET.

هذا الكود C# يوضح لك كيفية تعيين ترخيص كموارد مضمنة:

``` csharp
// إنشاء كائن من فئة License
Aspose.Slides.License license = new Aspose.Slides.License();

// تمرير اسم ملف الترخيص المضمن في التجميع
license.SetLicense("Aspose.Slides.lic");
```

## **التحقق من صلاحية الترخيص**

للتحقق مما إذا كان قد تم تعيين ترخيص بشكل صحيح، يمكنك التحقق من صلاحيته. يوضح لك هذا الكود C# كيفية التحقق من صلاحية ترخيص:

```c#
Aspose.Slides.License license = new Aspose.Slides.License();

license.SetLicense("Aspose.Slides.lic");

if (license.IsLicensed())
{
    Console.WriteLine("الترخيص سليم!");
    Console.Read();
}
```

## **أمان الخيوط**

{{% alert title="ملاحظة" color="warning" %}} 

أسلوب [license.SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/) ليس آمنًا للخيوط. إذا كان يجب استدعاء هذا الأسلوب بشكل متزامن من العديد من الخيوط، قد ترغب في استخدام بدائل التزامن (مثل قفل) لتجنب المشاكل. 

{{% /alert %}}