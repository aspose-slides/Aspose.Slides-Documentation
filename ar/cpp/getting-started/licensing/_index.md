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
- نسخة التقييم
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تطبيق وإدارة واستكشاف مشكلات الترخيص في Aspose.Slides للغة C++. ضمان الوصول غير المتقطع إلى جميع الميزات من خلال دليل الترخيص خطوة بخطوة."
---
## **نظرة عامة**

يمكن استخدام Aspose.Slides في وضع التقييم أو باستخدام ترخيص صالح. يوفر إصدار التقييم نفس وظائف الإصدار المرخص، لكنه يضيف علامة مائية للتقييم عند فتح العروض التقديمية أو حفظها ويقيد استخراج النص بشريحة واحدة.

توضح هذه المقالة كيفية عمل الترخيص في Aspose.Slides وكيفية تطبيق ترخيص قبل استخدام المكتبة. يمكن تحميل الترخيص من ملف أو تدفق أو مورد مدمج باستخدام الصنف `License`. كما تُظهر المقالة طريقة التحقق مما إذا تم تطبيق الترخيص بشكل صحيح.

## **تقييم Aspose.Slides**

{{% alert color="info" %}} 

يمكنك تنزيل نسخة تقييم **Aspose.Slides for C++** من [صفحة تنزيل NuGet الخاصة به](https://www.nuget.org/packages/Aspose.Slides.CPP/). توفر نسخة التقييم نفس وظائف المنتج المرخص. في الواقع، حزمة التقييم مطابقة تمامًا للنسخة المشتراة—ففقط بمجرد إضافة بضع أسطر من الشيفرة لتطبيق الترخيص تصبح مرخصة.

بمجرد أن تكون راضيًا عن تقييمك لـ **Aspose.Slides**، يمكنك [شراء ترخيص](https://purchase.aspose.com/buy). نوصي بمراجعة أنواع الاشتراكات المتاحة. إذا كان لديك أي أسئلة، لا تتردد في التواصل مع فريق مبيعات Aspose.

كل ترخيص Aspose يتضمن اشتراكًا سنويًا لمدة عام للحصول على ترقيات مجانية، بما في ذلك الإصدارات الجديدة وإصلاحات الأخطاء التي تُصدر خلال تلك الفترة. سواء كنت تستخدم نسخة مرخصة أو نسخة تقييم، ستحصل على دعم فني مجاني وغير محدود.

{{% /alert %}} 

**قيود نسخة التقييم**

* على الرغم من أن نسخة تقييم Aspose.Slides (عند عدم تطبيق ترخيص) توفر كامل وظائف المنتج، إلا أنها تُدرج علامة مائية للتقييم في أعلى المستند أثناء عمليات الفتح والحفظ.  
* يقتصر استخراج النص على شريحة واحدة عند استخدام نسخة التقييم.

{{% alert color="info" %}} 

لاختبار Aspose.Slides بدون قيود، يمكنك طلب **ترخيص مؤقت لمدة 30 يومًا**. لمزيد من المعلومات، راجع صفحة [كيفية الحصول على ترخيص مؤقت](https://purchase.aspose.com/temporary-license).

{{% /alert %}}

## **الترخيص في Aspose.Slides**

* تصبح نسخة التقييم مرخصة بعد شراء ترخيص وتطبيقه بإضافة بضع سطور من الشيفرة.  
* الترخيص هو ملف XML نصّي عادي يحتوي على تفاصيل مثل اسم المنتج، عدد المطورين الذين يُرخص لهم، تاريخ انتهاء الاشتراك، وغيرها.  
* ملف الترخيص موقع رقمياً، لذلك لا يجوز تعديله. حتى التغيير غير المقصود—مثل إضافة فاصل سطر—سيُعيد إبطال الملف.  
* عادةً ما يبحث Aspose.Slides for C++ عن ملف الترخيص في المواقع التالية:  
  * مسار يتم تحديده صراحةً في الشيفرة  
  * المجلد الذي يحتوي على DLL الخاص بالمكوّن (المضمّن في Aspose.Slides)  
  * المجلد الذي يحتوي على التجميع (assembly) الذي يستدعي DLL المكوّن  
* لتجنب قيود نسخة التقييم، يجب تعيين الترخيص قبل استخدام Aspose.Slides. يكفي تعيين الترخيص مرة واحدة فقط لكل تطبيق أو عملية.

## **تطبيق ترخيص**

يمكن تحميل الترخيص من **ملف**، **تدفق**، أو **مورد مدمج**.

{{% alert color="info" %}}

توفر Aspose.Slides الصنف [License](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.license/) لعمليات الترخيص.

{{% /alert %}} 

{{% alert color="warning" %}}

يمكن للتراخيص الجديدة تفعيل Aspose.Slides فقط مع الإصدار 21.4 أو ما بعده. الإصدارات الأقدم تستخدم نظام ترخيص مختلف ولن تتعرف على هذه التراخيص.

{{% /alert %}}

### **ملف**

أسهل طريقة لتعيين ترخيص هي وضع ملف الترخيص في نفس مجلد DLL الخاص بالمكوّن (المضمّن في Aspose.Slides) وتحديد اسم الملف فقط، دون المسار.

يظهر الرمز التالي بلغة C++ طريقة تعيين ملف الترخيص:

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

{{% alert color="warning" %}} 

إذا وضعت ملف الترخيص في دليل مختلف، عند استدعاء طريقة [License::SetLicense](https://reference.aspose.com/slides/ar/cpp/aspose.slides/license/setlicense/)، يجب أن يتطابق اسم الملف في نهاية المسار المحدد تمامًا مع اسم ملف الترخيص الخاص بك.

على سبيل المثال، إذا قمت بإعادة تسمية ملف الترخيص إلى *Aspose.Slides.lic.xml*، يجب تمرير المسار الكامل المنتهي بـ *Aspose.Slides.lic.xml* إلى طريقة [License::SetLicense](https://reference.aspose.com/slides/ar/cpp/aspose.slides/license/setlicense/) في الشيفرة الخاصة بك.

{{% /alert %}}

### **تدفق**

يمكنك تحميل الترخيص من تدفق. يوضح الرمز التالي بلغة C++ طريقة تطبيق الترخيص من تدفق:

```c++
#include <Util/License.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto license = MakeObject<License>();

auto stream = File::OpenRead(u"Aspose.Slides.lic");

license->SetLicense(stream);
```

## **التحقق من ترخيص**

للتحقق مما إذا تم تعيين الترخيص بشكل صحيح، يمكنك التحقق منه. يوضح الرمز التالي بلغة C++ طريقة التحقق من الترخيص:

```c++
#include <Util/License.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto license = MakeObject<License>();

license->SetLicense(u"Aspose.Slides.lic");

if (license->IsLicensed())
{
    Console::WriteLine(u"License is good!");
    Console::ReadKey();
}
```

## **سلامة الخيوط**

{{% alert title="Note" color="warning" %}} 

طريقة [License::SetLicense](https://reference.aspose.com/slides/ar/cpp/aspose.slides/license/setlicense/) ليست **آمنة للخيط**. إذا كنت بحاجة إلى استدعاء هذه الطريقة من عدة خيوط في آنٍ واحد، يُنصح باستخدام آليات المزامنة (مثل القفل) لتجنّب المشكلات المحتملة.

{{% /alert %}}

## **الأسئلة المتكررة**

### هل يمكنني تطبيق الترخيص في بيئة غير متصلة تمامًا (بدون اتصال بالإنترنت)؟

نعم. يتم التحقق من الترخيص محليًا باستخدام ملف الترخيص؛ لا يلزم اتصال بالإنترنت.

### ماذا يحدث بعد انتهاء الاشتراك السنوي? هل سيتوقف المكتبة عن العمل؟

لا. الترخيص دائم: يمكنك الاستمرار في استخدام الإصدارات التي صدرت قبل تاريخ انتهاء اشتراكك؛ ولكن لن تكون مؤهلاً لاستخدام الإصدارات الأحدث دون التجديد.