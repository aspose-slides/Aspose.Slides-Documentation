---
title: حماية العروض التقديمية بكلمة مرور في C++
linktitle: حماية كلمة المرور
type: docs
weight: 20
url: /ar/cpp/password-protected-presentation/
keywords:
- عرض تقديمي محمي بكلمة مرور
- كلمة مرور الفتح
- تشفير PowerPoint
- فك تشفير PowerPoint
- التحقق من كلمة مرور العرض التقديمي
- فحص كلمة مرور العرض التقديمي
- فتح عرض تقديمي مشفر
- إزالة التشفير
- PowerPoint
- PPT
- PPTX
- عرض تقديمي
- C++
- Aspose.Slides
description: "تشفير، اكتشاف، التحقق، فتح، وفك تشفير العرض التقديمي المحمي بكلمة مرور PowerPoint بصيغ PPT و PPTX في C++ باستخدام Aspose.Slides."
---
## **نظرة عامة**

كلمة مرور الفتح تشفر العرض التقديمي. كلمة المرور الصحيحة مطلوبة لتحميل وعرض محتوى العرض التقديمي، لذا فإن هذه الحماية توفر السرية.

كلمة مرور الفتح تختلف عن كلمة مرور الحماية من الكتابة. الحماية من الكتابة تقيد التعديل لكنها لا تشفر المحتوى ولا تمنع تحميل العرض التقديمي. لإدارة كلمات المرور لتعديل العروض التقديمية، راجع [Write-Protect Presentations](/slides/ar/cpp/write-protected-presentation/).

تطبق سير العمل أدناه على كل من عروض PPT و PPTX. تستخدم الأمثلة كلا التنسيقين حيث يكون سلوكهما القائم على الملفات وتدفقات البيانات مهمًا.

## **تشفير عرض تقديمي بكلمة مرور فتح**

استخدم [IProtectionManager::Encrypt](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iprotectionmanager/encrypt/) لتعيين كلمة مرور الفتح. ثم استخدم [IPresentation::Save](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/save/) لحفظ العرض التقديمي المشفر.

المثال التالي يشفر عرض تقديمي بصيغة PPTX:

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

## **إبقاء خصائص المستند عامة**

بشكل افتراضي، يتضمن Aspose.Slides خصائص المستند في تشفير العرض التقديمي. يتحكم [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) في هذا السلوك بشكل مستقل عن تشفير محتوى الشرائح. مرر `false` إلى هذه الطريقة قبل استدعاء [IProtectionManager::Encrypt](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iprotectionmanager/encrypt/) عندما يجب على نظام الفهرسة أو التصنيف أو البحث أو إدارة المستندات قراءة البيانات الوصفية دون كلمة مرور الفتح.

المثال التالي ينشئ عرض تقديمي PPTX مشفرًا مع إبقاء خصائص المستند المدمجة عامة:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IProtectionManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto properties = presentation->get_DocumentProperties();
properties->set_Author(u"Contoso Knowledge Management");
properties->set_Title(u"Quarterly Product Roadmap");
properties->set_Keywords(u"roadmap, planning, internal");

presentation->get_Slide(0)->set_Name(u"Encrypted presentation content");
presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"open_password");
presentation->Save(u"public-properties-encrypted.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

تمرير `false` إلى `set_EncryptDocumentProperties` لا يجعل الشرائح أو القوالب أو التخطيطات أو الأشكال أو الوسائط أو أي محتوى آخر في العرض التقديمي عامًا. يؤثر فقط على خصائص المستند. لقراءة تلك الخصائص دون تحميل المحتوى المشفر، راجع [Manage Presentation Properties](/slides/ar/cpp/presentation-properties/).

## **تحميل عرض تقديمي مشفر**

حدد [LoadOptions::set_Password](https://reference.aspose.com/slides/ar/cpp/aspose.slides/loadoptions/set_password/) إلى كلمة مرور الفتح ومرّر الخيارات إلى [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) عند تحميل الملف. سيفشل التحميل عندما تكون كلمة مرور الفتح مطلوبة لكن كلمة المرور المقدمة مفقودة أو غير صحيحة.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// العمل مع العرض التقديمي المفك التشفير.
```

## **إزالة التشفير من عرض تقديمي**

حمِّل العرض التقديمي باستخدام كلمة مرور الفتح الخاصة به، استدعِ [IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iprotectionmanager/removeencryption/)، واحفظ النتيجة. يمكن بعد ذلك تحميل العرض التقديمي المحفوظ دون كلمة مرور.

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

## **التحقق من صحة كلمة مرور الفتح قبل التحميل**

استخدم [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) للحصول على [IPresentationInfo](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationinfo/) دون إنشاء نسخة كاملة من العرض التقديمي. تحقق من [IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/) قبل طلب أو التحقق من كلمة مرور. عندما تكون الحماية موجودة، تحقق من صحة القيمة المقدمة باستخدام [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationinfo/checkpassword/).

### **سير عمل مسار الملف**

المثال التالي يتحقق من صحة كلمة مرور الفتح لملف PPTX، يمرّر القيمة التي تم التحقق منها إلى [LoadOptions::set_Password](https://reference.aspose.com/slides/ar/cpp/aspose.slides/loadoptions/set_password/)، ثم يحمل العرض التقديمي الكامل:

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

### **سير عمل التدفق**

الإصدار المتعلق بالتدفق من [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) يوفّر نفس سير العمل. أعد ضبط موضع تدفق قابل للبحث قبل تحميل العرض التقديمي الكامل من ذلك التدفق.

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

[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationinfo/checkpassword/) يعيد `true` فقط عندما يكون للعرض التقديمي كلمة مرور فتح وتكون كلمة المرور المقدمة صحيحة. يعيد `false` في كل من الحالات التالية:

- كلمة المرور غير صحيحة.
- العرض التقديمي لا يحتوي على كلمة مرور فتح.
- كلمة المرور المقدمة فارغة أو null.

السلوك نفسه ينطبق على عروض PPT و PPTX.

## **التحقق مما إذا كان العرض التقديمي المحمل مشفرًا**

بعد تحميل عرض تقديمي باستخدام كلمة المرور الصحيحة، افحص [IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iprotectionmanager/get_isencrypted/) لتأكيد أن العرض الأصلي كان مشفرًا. لاكتشاف حماية كلمة مرور الفتح قبل التحميل، استخدم `IPresentationInfo::get_IsPasswordProtected` كما هو موضح أعلاه.

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

## **توصيات الأمان**

{{% alert color="warning" title="الأمان" %}}
لا تقم بتسجيل كلمات مرور الفتح أو تضمينها في رسائل التشخيص. تجنب محاولات التحقق المتكررة غير الضرورية، احتفظ بكلمات المرور في الذاكرة فقط طالما كانت مطلوبة، وأعد استخدام نتيجة تحقق ناجحة عند تحميل العرض التقديمي مباشرة.

قد تكشف خصائص المستند العامة عن أسماء المؤلفين، العناوين، المواضيع، الكلمات المفتاحية، معلومات الشركة، التعليقات، والقيم المخصصة رغم أن محتوى العرض مشفر. شفر البيانات الوصفية الحساسة مع العرض التقديمي. يجب أن يكون ترك الخصائص عامة قرارًا صريحًا يُتخذ فقط عندما يتعين على الأنظمة فهرسة أو تصنيف أو البحث أو إدارة الملف دون كلمة مرور الفتح.
{{% /alert %}}

## **حماية عرض تقديمي بكلمة مرور عبر الإنترنت**

1. افتح تطبيق [Aspose.Slides Lock](https://products.aspose.app/slides/ar/lock).
1. اختر أو حمّل العرض التقديمي.
1. أدخل كلمة مرور لحماية العرض.
1. اختياريًا أدخل كلمة مرور منفصلة لحماية التحرير.
1. طبق الحماية وحمّل الملف الناتج.

{{% alert color="info" title="انظر أيضًا" %}}
- [حماية العروض من الكتابة](/slides/ar/cpp/write-protected-presentation/)
- [التوقيع الرقمي في PowerPoint](/slides/ar/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **الأسئلة المتكررة**

**ما الفرق بين كلمة مرور الفتح وكلمة مرور الحماية من الكتابة؟**

كلمة مرور الفتح تشفر العرض التقديمي وتكون مطلوبة لتحميل محتواه. كلمة مرور الحماية من الكتابة تقيد التعديل دون تشفير المحتوى.

**هل يمكنني التحقق من صحة كلمة مرور الفتح دون تحميل جميع الشرائح؟**

نعم. احصل على معلومات العرض التقديمي، وتأكد ما إذا كانت حماية كلمة مرور الفتح موجودة، وتحقق من صحة كلمة المرور قبل إنشاء نسخة كاملة من العرض التقديمي.

**هل يمكن للتطبيق قراءة البيانات الوصفية دون كلمة مرور الفتح؟**

نعم، ولكن فقط عندما يكون العرض التقديمي مشفرًا باستخدام `set_EncryptDocumentProperties(false)`. يجب على التطبيق حينها استخدام وضع التحميل الخاص بخصائص المستند فقط كما هو موضح في [Manage Presentation Properties](/slides/ar/cpp/presentation-properties/).

**هل تدعم سير عمل التحقق من كلمة المرور كلاً من PPT و PPTX؟**

نعم. كشف كلمة المرور والتحقق منها بناءً على مسار الملف أو التدفق يتصرفان بنفس الطريقة بالنسبة لعروض PPT و PPTX.