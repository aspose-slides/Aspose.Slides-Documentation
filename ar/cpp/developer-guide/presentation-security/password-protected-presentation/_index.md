---
title: حماية العروض التقديمية بكلمة مرور في C++
linktitle: حماية كلمة المرور
type: docs
weight: 20
url: /ar/cpp/password-protected-presentation/
keywords:
- عرض تقديمي محمي بكلمة مرور
- كلمة مرور افتتاحية
- تشفير PowerPoint
- فك تشفير PowerPoint
- التحقق من صحة كلمة مرور العرض التقديمي
- فحص كلمة مرور العرض التقديمي
- فتح عرض تقديمي مشفر
- إزالة التشفير
- PowerPoint
- PPT
- PPTX
- عرض تقديمي
- C++
- Aspose.Slides
description: "تشفير، اكتشاف، التحقق من صحة، فتح، وفك تشفير العروض التقديمية المحمية بكلمة مرور لبرنامج PowerPoint بصيغ PPT و PPTX في C++ باستخدام Aspose.Slides."
---
## **نظرة عامة**

كلمة المرور الافتتاحية تشفر العرض التقديمي. كلمة المرور الصحيحة مطلوبة لتحميل وعرض محتوى العرض التقديمي، وبالتالي توفر هذه الحماية السرية.

كلمة المرور الافتتاحية تختلف عن كلمة مرور الحماية من الكتابة. الحماية من الكتابة تقيد التعديل لكنها لا تشفر المحتوى ولا تمنع تحميل العرض التقديمي. لإدارة كلمات المرور لتعديل العروض التقديمية، راجع [Write-Protect Presentations](/slides/ar/cpp/write-protected-presentation/).

تطبق سير العمل أدناه على كل من عروض PPT و PPTX. تستخدم الأمثلة كلا الصيغتين عندما يكون سلوكهما القائم على الملف أو الدفق مهمًا.

## **تشفير عرض تقديمي بكلمة مرور افتتاحية**

استخدم [IProtectionManager::Encrypt](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iprotectionmanager/encrypt/) لتعيين كلمة مرور افتتاحية. ثم استخدم [IPresentation::Save](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/save/) لحفظ العرض المشفر.

المثال التالي يقوم بتشفير عرض PPTX:

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"open_password");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **تحميل عرض مشفر**

عيّن [LoadOptions::set_Password](https://reference.aspose.com/slides/ar/cpp/aspose.slides/loadoptions/set_password/) إلى كلمة المرور الافتتاحية ومرّر الخيارات إلى [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) عند تحميل الملف. يفشل التحميل عندما تكون كلمة المرور الافتتاحية مطلوبة ولكن كلمة المرور المقدمة مفقودة أو غير صحيحة.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// العمل مع العرض التقديمي المفكّ تشفيره.
```

## **إزالة التشفير من عرض تقديمي**

حمّل العرض باستخدام كلمة المرور الافتتاحية، واستدعِ [IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iprotectionmanager/removeencryption/)، ثم احفظ النتيجة. يمكن بعد ذلك تحميل العرض المحفوظ دون كلمة مرور.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **التحقق من كلمة مرور افتتاحية قبل التحميل**

استخدم [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) للحصول على [IPresentationInfo](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationinfo/) دون إنشاء نسخة كاملة من العرض. تحقق من [IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/) قبل طلب أو التحقق من كلمة مرور. عندما تكون الحماية موجودة، تحقق من القيمة المقدمة باستخدام [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationinfo/checkpassword/).

### **سير عمل مسار الملف**

المثال التالي يتحقق من صحة كلمة مرور افتتاحية لملف PPTX، يمرّر القيمة التي تم التحقق منها إلى [LoadOptions::set_Password](https://reference.aspose.com/slides/ar/cpp/aspose.slides/loadoptions/set_password/)، ثم يحمل العرض الكامل:

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

String filePath = u"protected-presentation.pptx";
String password = u"open_password";
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);

if (!presentationInfo->get_IsPasswordProtected())
{
    Console::WriteLine(u"The presentation does not have an opening password.");
}
else if (!presentationInfo->CheckPassword(password))
{
    Console::WriteLine(u"The opening password is incorrect.");
}
else
{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(password);
    auto presentation = MakeObject<Presentation>(filePath, loadOptions);

    Console::WriteLine(u"The presentation was validated and loaded successfully.");
}
```

### **سير عمل الدفق**

إصدار الدفق من [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) يوفر نفس سير العمل. أعد ضبط موضع الدفق القابل للبحث قبل تحميل العرض الكامل من ذلك الدفق.

المثال التالي يستخدم ملف PPT:

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

String password = u"open_password";
auto presentationStream = File::OpenRead(u"protected-presentation.ppt");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(presentationStream);

if (!presentationInfo->get_IsPasswordProtected())
{
    Console::WriteLine(u"The presentation does not have an opening password.");
}
else if (!presentationInfo->CheckPassword(password))
{
    Console::WriteLine(u"The opening password is incorrect.");
}
else
{
    presentationStream->set_Position(0);

    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(password);
    auto presentation = MakeObject<Presentation>(presentationStream, loadOptions);

    Console::WriteLine(u"The presentation was validated and loaded successfully.");
}
```

### **قيم إرجاع CheckPassword**

[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationinfo/checkpassword/) يرجع `true` فقط عندما يحتوي العرض على كلمة مرور افتتاحية وتكون كلمة المرور المقدمة صحيحة. ويرجع `false` في كل من الحالات التالية:

- كلمة المرور غير صحيحة.
- العرض لا يحتوي على كلمة مرور افتتاحية.
- كلمة المرور المقدمة فارغة أو خالية.

السلوك نفسه لعروض PPT و PPTX.

## **التحقق مما إذا كان العرض المحمَّل مشفرًا**

بعد تحميل عرض بكلمة مرور صحيحة، افحص [IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iprotectionmanager/get_isencrypted/) لتأكيد أن العرض الأصلي كان مشفرًا. لاكتشاف الحماية بكلمة مرور افتتاحية قبل التحميل، استخدم `IPresentationInfo::get_IsPasswordProtected` كما هو موضح أعلاه.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");
auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
Console::WriteLine(isEncrypted ? u"The presentation is encrypted." : u"The presentation is not encrypted.");
```

## **توصيات الأمن**

{{% alert color="warning" title="الأمان" %}}
لا تقم بتسجيل كلمات المرور الافتتاحية أو تضمينها في رسائل التشخيص. تجنّب محاولات التحقق المتكررة غير الضرورية، احتفظ بكلمات المرور في الذاكرة طالما هي مطلوبة فقط، وأعد استخدام نتيجة تحقق ناجحة عند تحميل العرض مباشرةً.
{{% /alert %}}

## **حماية عرض بكلمة مرور عبر الإنترنت**

1. افتح تطبيق [Aspose.Slides Lock](https://products.aspose.app/slides/ar/lock).
2. اختر أو حمّل العرض التقديمي.
3. أدخل كلمة مرور لحماية العرض.
4. اختياريًا، أدخل كلمة مرور منفصلة لحماية التعديل.
5. طبق الحماية وحمّل الملف الناتج.

{{% alert color="info" title="انظر أيضًا" %}}
- [حماية العروض من الكتابة](/slides/ar/cpp/write-protected-presentation/)
- [التوقيع الرقمي في PowerPoint](/slides/ar/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **الأسئلة المتداولة**

**ما الفرق بين كلمة المرور الافتتاحية وكلمة مرور الحماية من الكتابة؟**

كلمة المرور الافتتاحية تشفر العرض التقديمي وتكون مطلوبة لتحميل محتواه. كلمة مرور الحماية من الكتابة تقيد التعديل دون تشفير المحتوى.

**هل يمكنني التحقق من صحة كلمة المرور الافتتاحية دون تحميل جميع الشرائح؟**

نعم. احصل على معلومات العرض، وتحقق مما إذا كانت هناك حماية بكلمة مرور افتتاحية، وقم بالتحقق من كلمة المرور قبل إنشاء نسخة كاملة من العرض.

**هل تدعم سير عمل التحقق من كلمة المرور كلًا من PPT و PPTX؟**

نعم. اكتشاف كلمة المرور والتحقق منها عبر مسار الملف أو الدفق يعمل بنفس الطريقة على عروض PPT و PPTX.