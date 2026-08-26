---
title: كتابة-حماية العروض التقديمية في C++
linktitle: الحماية من الكتابة
type: docs
weight: 25
url: /ar/cpp/write-protected-presentation/
keywords:
- حماية من الكتابة
- حماية PowerPoint من الكتابة
- كلمة مرور للتعديل
- تقييد تعديل العرض التقديمي
- إزالة الحماية من الكتابة
- التحقق من كلمة مرور التعديل
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعيين، اكتشاف، التحقق وإزالة كلمات مرور الحماية من الكتابة في عروض PowerPoint PPT و PPTX باستخدام Aspose.Slides للغة C++."
---
## **مقدمة**

كلمة مرور الحماية من التحرير تقيد تعديل العرض التقديمي لكنها لا تشفر محتواه. يمكن للمستخدمين تحميل وعرض عرض محمي من التحرير دون كلمة المرور. اعتمادًا على التطبيق، قد يكون بإمكانهم أيضًا تعديل المحتوى وحفظه تحت اسم مختلف، لذا لا ينبغي اعتبار الحماية من التحرير كآلية للسرية.

كلمة مرور الفتح تخدم غرضًا مختلفًا: فهي تشفر العرض التقديمي وتُطلب لتحميل محتواه. لتشفير عرض تقديمي أو التحقق من كلمة مرور الفتح، راجع [حماية العروض التقديمية بكلمة مرور](/slides/ar/cpp/password-protected-presentation/).

سير العمل في هذه المقالة ينطبق على عروض PPT وPPTX. تستخدم الأمثلة ملفات PPTX؛ عند الحفظ إلى PPT، استخدم الامتداد `.ppt` وتنسيق الحفظ المقابل لـ PPT.

## **تعيين الحماية من التحرير على عرض تقديمي**

استخدم [IProtectionManager::SetWriteProtection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iprotectionmanager/setwriteprotection/) لتعيين كلمة مرور لتعديل العرض التقديمي. سيؤدي حفظ العرض إلى الحفاظ على إعداد الحماية.

المثال التالي يحدد الحماية من التحرير على عرض PPTX:

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"modify_password");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **تحميل عرض تقديمي محمي من التحرير**

نظرًا لأن الحماية من التحرير لا تشفر محتوى العرض، لا يُطلب كلمة مرور لتحميل العرض. تكون كلمة المرور ذات صلة فقط عند التحقق من صلاحية تعديل العرض المحمي.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"write-protected-pres.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());
```

لا تقم بتمرير كلمة مرور الحماية من التحرير إلى [LoadOptions::set_Password](https://reference.aspose.com/slides/ar/cpp/aspose.slides/loadoptions/set_password/). هذه الخاصية تقبل كلمة مرور الفتح للمحتوى المشفر. إذا كان العرض يحتوي على النوعين من الحماية، قدم كلمة مرور الفتح لتحميله وتعامل مع كلمة مرور الحماية من التحرير بشكل منفصل.

## **إزالة الحماية من التحرير من عرض تقديمي**

استخدم [IProtectionManager::RemoveWriteProtection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iprotectionmanager/removewriteprotection/) لإزالة قيد التعديل، ثم احفظ العرض.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"write-protected-pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **التحقق مما إذا كان العرض محميًا من التحرير**

للتفحص دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) كامل، استدعِ [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) وتفحص [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/). الخاصية تستخدم [NullableBool](https://reference.aspose.com/slides/ar/cpp/aspose.slides/nullablebool/) وتعيد `NullableBool::True` عند اكتشاف الحماية من التحرير.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/NullableBool.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"write-protected-pres.pptx");

if (presentationInfo->get_IsWriteProtected() == NullableBool::True)
{
    Console::WriteLine(u"The presentation is write protected.");
}
else
{
    Console::WriteLine(u"Write protection was not detected.");
}
```

الإصدار المتوفر للتيار من [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) يقدم نفس المعلومات لعرض يُمرَّ كتيار.

## **التحقق من صحة كلمة مرور الحماية من التحرير**

استخدم [IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) للتحقق من كلمة مرور التعديل دون تحميل العرض بالكامل. تحقق أولاً من [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/) حتى يطلب التطبيق أو يتحقق من كلمة مرور فقط عندما تكون الحماية من التحرير موجودة.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/NullableBool.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"write-protected-pres.pptx");

if (presentationInfo->get_IsWriteProtected() != NullableBool::True)
{
    Console::WriteLine(u"The presentation is not write protected.");
}
else if (presentationInfo->CheckWriteProtection(u"modify_password"))
{
    Console::WriteLine(u"The write-protection password is correct.");
}
else
{
    Console::WriteLine(u"The write-protection password is incorrect.");
}
```

[IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) يتحقق فقط من كلمة مرور الحماية من التحرير. لا يتحقق من كلمة مرور الفتح ولا يحدد ما إذا كان يمكن تحميل المحتوى المشفر. بالمقابل، [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationinfo/checkpassword/) يتحقق فقط من كلمة مرور الفتح. إذا كان عرض كامل قد تم تحميله مسبقًا، فإن [IProtectionManager::CheckWriteProtection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iprotectionmanager/checkwriteprotection/) يقدم فحص الحماية من التحرير المكافئ عبر مدير الحماية.

في التطبيقات الإنتاجية، لا تُسجِّل كلمات المرور أو تُدرجها في رسائل التشخيص. تجنّب محاولات التحقق المتكررة غير الضرورية، واحتفظ بكلمات المرور في الذاكرة فقط طالما كانت مطلوبة.

{{% alert color="info" title="انظر أيضًا" %}}
- [حماية العروض التقديمية بكلمة مرور](/slides/ar/cpp/password-protected-presentation/)
- [عروض تقديمية للقراءة فقط](/slides/ar/cpp/read-only-presentation/)
- [التوقيع الرقمي في PowerPoint](/slides/ar/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **الأسئلة المتكررة**

**هل الحماية من التحرير تشفر العرض التقديمي؟**

لا. إنها تقيد التعديل لكنها تترك محتوى العرض متاحًا للتحميل والعرض.

**هل كلمة مرور الحماية من التحرير مطلوبة لفتح العرض؟**

لا. كلمة مرور الفتح فقط مطلوبة لتحميل محتوى العرض المشفر.

**هل يمكن أن يحتوي العرض على كل من كلمة مرور الفتح وكلمة مرور الحماية من التحرير؟**

نعم. قدم كلمة مرور الفتح عبر خيارات التحميل لفتح العرض المشفر، وتحقق من كلمة مرور الحماية من التحرير بشكل منفصل عندما يلزم الحصول على صلاحية التعديل.