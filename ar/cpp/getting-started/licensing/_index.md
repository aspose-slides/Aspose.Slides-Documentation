---
title: الترخيص
type: docs
weight: 120
url: /ar/cpp/licensing/
keywords:
- ترخيص
- ترخيص مؤقت
- تعيين ترخيص
- استخدام ترخيص
- التحقق من الترخيص
- ملف الترخيص
- نسخة تقييم
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تطبيق وإدارة واستكشاف أخطاء الترخيص في Aspose.Slides لـ C++. ضمان الوصول غير المتقطع إلى جميع الميزات من خلال دليل الترخيص خطوة بخطوة."
---
## **نظرة عامة**

يمكن استخدام Aspose.Slides في وضع التقييم أو باستخدام ترخيص صالح. يوفر إصدار التقييم نفس وظائف الإصدار المرخص، لكنه يضيف علامة مائية تقييم إلى كل شريحة من كل عرض تقديمي يتم حفظه ويقصر النص الذي يقرأه كودك من العروض التقديمية.

توضح هذه المقالة كيفية عمل الترخيص في Aspose.Slides وكيفية تطبيق ترخيص قبل استخدام المكتبة. يمكن تحميل الترخيص من ملف أو من تدفق باستخدام الفئة `License`. كما تُظهر المقالة كيفية التحقق مما إذا تم تطبيق الترخيص بشكل صحيح.

## **تقييم Aspose.Slides**

{{% alert color="info" title="Note" %}}
يمكنك تنزيل نسخة تقييمية من **Aspose.Slides for C++** من [صفحة تنزيل NuGet الخاصة به](https://www.nuget.org/packages/Aspose.Slides.Cpp/) أو، كحزمة ZIP، من [صفحة التنزيل](https://releases.aspose.com/slides/ar/cpp/). تقدم نسخة التقييم نفس الوظائف التي يقدمها المنتج المرخص. في الواقع، حزمة التقييم مطابقة تمامًا للنسخة المشتراة—فقط تصبح مرخصة بمجرد إضافة بعض الأسطر البرمجية لتطبيق الترخيص.

بمجرد أن تكون راضيًا عن تقييمك لـ **Aspose.Slides**، يمكنك [شراء ترخيص](https://purchase.aspose.com/pricing/slides/ar/cpp/). نوصي بمراجعة أنواع الاشتراك المتاحة. إذا كان لديك أي أسئلة، لا تتردد في الاتصال بفريق مبيعات Aspose.

كل ترخيص من Aspose يتضمن اشتراكًا لمدة عام واحد للحصول على ترقيات مجانية، بما في ذلك الإصدارات الجديدة وإصلاحات الأخطاء التي تُصدر خلال تلك الفترة. سواء كنت تستخدم نسخة مرخصة أو نسخة تقييمية، ستحصل على دعم فني مجاني غير محدود.
{{% /alert %}} 

**قيود نسخة التقييم**

* توفر نسخة التقييم (دون تحديد ترخيص) جميع وظائف المنتج، لكنها تضيف مربع نص علامة مائية تقييم إلى كل شريحة من كل عرض تقديمي يتم حفظه.
* يتم قص النص الذي يقرؤه كودك من العرض التقديمي إلى few أولى حروفه، يتبعها إشعار حول قيد التقييم. النص الذي يكتبه كودك يُحفظ بالكامل.

{{% alert color="info" title="Note" %}}
لاختبار Aspose.Slides بدون قيود، يمكنك طلب **ترخيص مؤقت لمدة 30 يومًا**. لمزيد من المعلومات، راجع صفحة [كيفية الحصول على ترخيص مؤقت](https://purchase.aspose.com/temporary-license).
{{% /alert %}}

## **الترخيص في Aspose.Slides**

* تصبح نسخة التقييم مرخصة بعد شراء ترخيص وتطبيقه بإضافة بضع أسطر برمجية.
* الترخيص هو ملف XML نصي بسيط يحتوي على تفاصيل مثل اسم المنتج، وعدد المطورين المسموح لهم بالاستخدام، وتاريخ انتهاء الاشتراك، وغيرها.
* يتم توقيع ملف الترخيص رقميًا، لذلك لا يجب تعديله. حتى التغيير غير المقصود—مثل إضافة فاصل أسطر—سيبطّلغ صلاحية الملف.
* عندما تمرر اسم ملف بدون مسار، يبحث Aspose.Slides for C++ عن ملف الترخيص في دليل العمل الحالي فقط. لا يبحث في دليل البرنامج القابل للتنفيذ أو مكتبة Aspose.Slides، لذا يجب تمرير المسار الكامل عندما يكون ملف الترخيص مخزنًا في مكان آخر.
* لتجنب قيود نسخة التقييم، يجب تعيين الترخيص قبل استخدام Aspose.Slides. يكفي تعيين الترخيص مرة واحدة لكل تطبيق أو عملية.

## **تطبيق ترخيص**

يمكن تحميل الترخيص من **ملف** أو **تدفق**.

{{% alert color="info" title="Note" %}}
توفر Aspose.Slides الفئة [License](https://reference.aspose.com/slides/ar/cpp/aspose.slides/license/) لعمليات الترخيص.
{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}
يمكن لتراخيص جديدة تفعيل Aspose.Slides فقط مع الإصدار 21.4 أو أحدث. الإصدارات الأقدم تستخدم نظام ترخيص مختلف ولن تتعرف على هذه التراخيص.
{{% /alert %}}

### **ملف**

أسهل طريقة لتعيين ترخيص هي وضع ملف الترخيص في دليل عمل برنامجك وتحديد اسم الملف فقط، بدون المسار. وإلا، حدد المسار الكامل للملف.

الكود C++ التالي يطبق ملف الترخيص *Aspose.Slides.lic* من دليل عمل البرنامج:

```c++
#include <Util/License.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    return 0;
}
```

إذا كان الترخيص صالحًا، فإن [License::SetLicense](https://reference.aspose.com/slides/ar/cpp/aspose.slides/license/setlicense/) يرجع ويُنهي البرنامج دون أي إخراج؛ من الآن فصاعدًا، يعمل Aspose.Slides بدون قيود التقييم. إذا لم يكن الملف في دليل العمل، تُلقي الطريقة استثناءً من نوع [FileNotFoundException](https://reference.aspose.com/slides/ar/cpp/system.io/filenotfoundexception/) بالرسالة *License "Aspose.Slides.lic" doesn't exist or access is restricted*. المثال لا يتعامل مع الاستثناء، لذا يتوقف البرنامج.

{{% alert color="warning" title="Warning" %}}
إذا وضعت ملف الترخيص في دليل مختلف، فعند استدعاء طريقة [License::SetLicense](https://reference.aspose.com/slides/ar/cpp/aspose.slides/license/setlicense/) يجب أن يتطابق اسم الملف في نهاية المسار المحدد تمامًا مع اسم ملف الترخيص لديك.

على سبيل المثال، إذا أعدت تسمية ملف الترخيص إلى *Aspose.Slides.lic.xml*، يجب تمرير المسار الكامل المنتهي بـ *Aspose.Slides.lic.xml* إلى طريقة [License::SetLicense](https://reference.aspose.com/slides/ar/cpp/aspose.slides/license/setlicense/) في الكود.
{{% /alert %}}

### **تدفق**

حمل ترخيص من تدفق عندما لا يحتفظ برنامجك بالترخيص كملف يمكن تسميته، على سبيل المثال عندما يقرأ الترخيص من قاعدة بيانات. تقبل [License::SetLicense](https://reference.aspose.com/slides/ar/cpp/aspose.slides/license/setlicense/) أي [Stream](https://reference.aspose.com/slides/ar/cpp/system.io/stream/) يحتوي على الترخيص. لتقليل طول المثال، يفتح الكود C++ التالي *Aspose.Slides.lic* في دليل العمل باستخدام [File::OpenRead](https://reference.aspose.com/slides/ar/cpp/system.io/file/openread/) ويطبق الترخيص من ذلك التدفق:

```c++
#include <Util/License.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

int main()
{
    auto license = MakeObject<License>();
    auto stream = File::OpenRead(u"Aspose.Slides.lic");
    license->SetLicense(stream);

    return 0;
}
```

ترخيص صالح يعطي النتيجة نفسها كما في مثال الملف. إذا كان الملف غير موجود، تُلقي [File::OpenRead](https://reference.aspose.com/slides/ar/cpp/system.io/file/openread/) استثناءً من نوع [FileNotFoundException](https://reference.aspose.com/slides/ar/cpp/system.io/filenotfoundexception/) قبل تطبيق الترخيص، ويتوقف البرنامج.

## **التحقق من الترخيص**

للتحقق مما إذا تم تعيين ترخيص بشكل صحيح، استدعِ [License::IsLicensed](https://reference.aspose.com/slides/ar/cpp/aspose.slides/license/islicensed/). تُعيد `true` فقط بعد تطبيق ترخيص صالح، وتُعيد `false` قبل ذلك. الكود C++ التالي يطبق ملف الترخيص من دليل العمل ثم يتحقق منه:

```c++
#include <Util/License.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    if (license->IsLicensed())
    {
        Console::WriteLine(u"License is good!");
    }

    return 0;
}
```

مع ترخيص صالح، يطبع البرنامج *License is good!* . إذا كان الملف مفقودًا أو ليس ملف ترخيص، تُلقي [License::SetLicense](https://reference.aspose.com/slides/ar/cpp/aspose.slides/license/setlicense/) استثناءً قبل الفحص، ويتوقف البرنامج دون طباعة أي شيء. إذا كان الملف ترخيصًا توقيعه لا يتطابق، على سبيل المثال لأنه تم تحريره، تُعيد SetLicense دون خطأ لكن `IsLicensed` تُعيد `false`، لذا لا يُطبع شيء ويظل Aspose.Slides في وضع التقييم.

## **سلامة الخيوط**

{{% alert color="warning" title="Warning" %}}
طريقة [License::SetLicense](https://reference.aspose.com/slides/ar/cpp/aspose.slides/license/setlicense/) **ليست آمنة في بيئات متعددة الخيوط**. إذا احتجت إلى استدعاء هذه الطريقة من خيوط متعددة في آنٍ واحد، يُنصح باستخدام آليات التزامن (مثل القفل) لتجنب المشكلات المحتملة.
{{% /alert %}}

## **الأسئلة الشائعة**

### هل يمكنني تطبيق الترخيص في بيئة غير متصلة بالكامل (بدون اتصال بالإنترنت)؟

نعم. يتم التحقق من صحة الترخيص محليًا باستخدام ملف الترخيص؛ لا يلزم اتصال بالإنترنت.

### ماذا يحدث بعد انتهاء الاشتراك السنوي؟ هل سيتوقف عمل المكتبة؟

لا. الترخيص دائم: يمكنك الاستمرار في استخدام الإصدارات التي صدرت قبل تاريخ انتهاء الاشتراك؛ لن تتمكن فقط من استخدام الإصدارات الأحدث دون تجديد الاشتراك.