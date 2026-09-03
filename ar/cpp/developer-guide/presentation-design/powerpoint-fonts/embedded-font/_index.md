---
title: تضمين الخطوط في العروض التقديمية باستخدام C++
linktitle: خطوط مضمَّنة
type: docs
weight: 40
url: /ar/cpp/embedded-font/
keywords:
- إضافة خط
- تضمين خط
- تضمين الخط
- الحصول على الخط المضمّن
- إضافة خط مضمّن
- إزالة الخط المضمّن
- ضغط الخط المضمّن
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "إدارة الخطوط المضمَّنة في PowerPoint باستخدام Aspose.Slides للغة C++. إضافة، استرجاع، إزالة، وضغط الخطوط للحفاظ على مظهر النص وتقليل حجم الملف."
---
## **مقدمة**

يتم تخزين خطوط مضمَّنة داخل عرض PowerPoint. عندما يدعم المشاهد الخطوط المضمَّنة، يمكنه عرض النص باستخدام تلك الخطوط حتى وإن لم يتم تثبيتها على النظام المستهدف. يساعد ذلك على الحفاظ على فواصل الأسطر وتباعد النص وتخطيط الشريحة.

تتيح لك Aspose.Slides للـ C++ استرجاع وإضافة وإزالة الخطوط المضمَّنة عبر طريقة [Presentation::get_FontsManager](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_fontsmanager/) لكائن [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/). يمكنك أيضاً تقليل حجم بيانات الخط المضمّن بإزالة الأحرف التي لا يستخدمها العرض.

الأمثلة أدناه تعمل مع ملفات PPTX. قبل تضمين خط، تأكد من توفر بيانات الخط لـ Aspose.Slides وأن ترخيصه يسمح بالتضمين.

## **الحصول على وإزالة الخطوط المضمَّنة**

استخدم [IFontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifontsmanager/getembeddedfonts/) لسرد الخطوط المخزنة في عرض تقديمي. لإزالة أحدها، مرّر الخط من تلك القائمة إلى [IFontsManager::RemoveEmbeddedFont](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifontsmanager/removeembeddedfont/)، ثم احفظ العرض التقديمي.

المثال التالي يسرد الخطوط المضمَّنة في `EmbeddedFonts.pptx` ويزيل Calibri إذا كان موجوداً:
```cpp
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"EmbeddedFonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto embeddedFonts = fontsManager->GetEmbeddedFonts();
SharedPtr<IFontData> fontToRemove;

for (auto&& font : embeddedFonts)
{
    Console::WriteLine(font->get_FontName());

    if (String::Equals(font->get_FontName(), u"Calibri", StringComparison::OrdinalIgnoreCase))
    {
        fontToRemove = font;
    }
}

if (fontToRemove != nullptr)
{
    fontsManager->RemoveEmbeddedFont(fontToRemove);
    presentation->Save(u"WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Calibri is not embedded. No output file was created.");
}

presentation->Dispose();
```

إزالة خط مضمّن يزيل بيانات الخط المخزنة؛ لا يغيّر الخط المعين للنص. إذا كان الخط مثبتاً على النظام المستهدف، يمكن للنص الاستمرار في استخدامه. وإلا قد يتطلب العرض [font substitution](/slides/ar/cpp/font-substitution/)، مما قد يؤثر على التخطيط.

## **فحص بيانات الخط وأذونات التضمين**

استخدم الواجهة [IFontsManager](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifontsmanager/) لفحص الخطوط قبل تضمينها. استدعِ [IFontsManager::GetFonts](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifontsmanager/getfonts/) لاسترجاع الخطوط المستخدمة في العرض. لكل خط، مرّر كائنًا من نوع [IFontData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifontdata/) والقيمة المطلوبة من [FontStyleType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontstyletype/) إلى [IFontsManager::GetFontBytes](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifontsmanager/getfontbytes/). تُعيد الطريقة البيانات الثنائية لذلك نمط الخط، أو `nullptr` عندما يكون الخط أو النمط المطلوب غير متوفر. لا تمرّر نتيجة `nullptr` إلى [IFontsManager::GetFontEmbeddingLevel](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifontsmanager/getfontembeddinglevel/) لأن هذه الطريقة تتطلّب مصفوفة بايت.

[EmbeddingLevel](https://reference.aspose.com/slides/ar/cpp/aspose.slides/embeddinglevel/) هو تعداد علميات يُبلغ عن قيود التضمين المخزنة في الخط:
- `Installable` يسمح بالتضمين والتثبيت الدائم على نظام آخر، حسب ترخيص الخط.
- `Restricted` يمنع التضمين إلا إذا تم الحصول على إذن من مالك الخط القانوني عندما يكون هذا العلم هو علم الإذن الوحيد.
- `PreviewPrint` يسمح بالاستخدام المؤقت للعرض والطباعة؛ يجب أن يكون المستند الذي يحتوي الخط للقراءة فقط.
- `Editable` يسمح بالاستخدام المؤقت ويسمح بتحرير المستند وحفظه.
- `NoSubsetting` هو قيد إضافي يمنع تضمين جزء فقط من الرموز. يجب تضمين جميع الأحرف عندما يكون هذا العلم موجوداً.
- `BitmapOnly` هو قيد إضافي يسمح بتضمين ضربات البت ماب فقط، وليس بيانات الخط الخارطي. إذا لا يحتوي الخط على ضربات بت ماب، لا يمكن تضمينه.

القيم الأربعة الأولى تصف إذن الاستخدام، بينما يمكن دمج `NoSubsetting` و`BitmapOnly` معه. تحقق من المعدّلات باستخدام عمليات bitwise. لأن قيمة `Installable` تساوي صفر، قم بقناع بتات إذن الاستخدام وقارن النتيجة مع `Installable`. يجب أن تضبط الخطوط الحالية بتة إذن استخدام واحدة كحد أقصى. للتوافق مع الخطوط القديمة التي تضبط أكثر من واحدة، يختار المساعد أدناه أقل إذن تقييداً: `Editable`، ثم `PreviewPrint`، ثم `Restricted`.

المثال التالي يراجع بيانات الخط العادي، السميك، المائل، والسميك-المائل المتوفرة لكل خط يُرجعها `GetFonts`. يتخطى الأنماط غير المتوفرة، الخطوط المقيدة، الخطوط ذات البت ماب فقط، الخطوط المحدودة للعرض والطباعة لأن الناتج يبقى قابلًا للتحرير، والخطوط المضمَّنة بالفعل. إذا كان لأي نمط متوفر خاصية `NoSubsetting`، يتم تضمين جميع الأحرف لذلك العائلة الخطية.
```cpp
#include <DOM/EmbeddingLevel.h>
#include <DOM/FontStyleType.h>
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/EmbedFontCharacters.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/collections/list.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;

auto getUsagePermission = [](EmbeddingLevel level)
{
    const auto permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    auto permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel::Editable) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::Editable;
    }

    if ((permissions & EmbeddingLevel::PreviewPrint) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::PreviewPrint;
    }

    if ((permissions & EmbeddingLevel::Restricted) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
};

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto fontStyles = MakeArray<FontStyleType>({
    FontStyleType::Regular,
    FontStyleType::Bold,
    FontStyleType::Italic,
    FontStyleType::Bold | FontStyleType::Italic
});
auto fontStyleNames = MakeArray<String>({u"regular", u"bold", u"italic", u"bold-italic"});

auto embeddedFontNames = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());
for (auto&& embeddedFont : fontsManager->GetEmbeddedFonts())
{
    embeddedFontNames->Add(embeddedFont->get_FontName());
}

auto fontsToEmbedAll = MakeObject<List<SharedPtr<IFontData>>>();
auto fontsToEmbedUsedOnly = MakeObject<List<SharedPtr<IFontData>>>();
for (auto&& font : fontsManager->GetFonts())
{
    if (embeddedFontNames->Contains(font->get_FontName()))
    {
        Console::WriteLine(u"{0}: already embedded.", font->get_FontName());
        continue;
    }

    auto hasAvailableData = false;
    auto allAvailableStylesCanBeEmbedded = true;
    auto previewPrintOnly = false;
    auto requiresFullFont = false;

    for (auto styleIndex = 0; styleIndex < fontStyles->get_Length(); styleIndex++)
    {
        auto fontStyle = fontStyles[styleIndex];
        auto fontBytes = fontsManager->GetFontBytes(font, fontStyle);
        if (fontBytes == nullptr)
        {
            Console::WriteLine(u"{0} ({1}): font data is unavailable.", font->get_FontName(), fontStyleNames[styleIndex]);
            continue;
        }

        hasAvailableData = true;
        auto embeddingLevel = fontsManager->GetFontEmbeddingLevel(fontBytes, font->get_FontName());
        auto usagePermission = getUsagePermission(embeddingLevel);
        auto noSubsetting = (embeddingLevel & EmbeddingLevel::NoSubsetting) != EmbeddingLevel::Installable;
        auto bitmapOnly = (embeddingLevel & EmbeddingLevel::BitmapOnly) != EmbeddingLevel::Installable;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel::PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel::Restricted && !bitmapOnly;

        Console::WriteLine(u"{0} ({1}): embedding level {2}.", font->get_FontName(), fontStyleNames[styleIndex], static_cast<uint16_t>(embeddingLevel));
    }

    if (!hasAvailableData)
    {
        Console::WriteLine(u"{0}: skipped because no requested style is available.", font->get_FontName());
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console::WriteLine(u"{0}: skipped because at least one available style does not permit outline embedding.", font->get_FontName());
    }
    else if (previewPrintOnly)
    {
        Console::WriteLine(u"{0}: skipped because this example produces an editable presentation.", font->get_FontName());
    }
    else if (requiresFullFont)
    {
        fontsToEmbedAll->Add(font);
    }
    else
    {
        fontsToEmbedUsedOnly->Add(font);
    }
}

for (auto&& font : fontsToEmbedAll)
{
    fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::All);
}

for (auto&& font : fontsToEmbedUsedOnly)
{
    fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::OnlyUsed);
}

presentation->Save(u"WithAuditedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

هذا الفحص يُبلغ عن القيود المشفرة في كل ملف خط. لا يمنح ترخيصاً، ولا يثبت أنك حصلت على الخط بصورة قانونية، ولا يحل محل فحص اتفاقية ترخيص الخط قبل توزيع نسخة مضمَّنة.

## **إضافة خطوط مضمَّنة**

استخدم [IFontsManager::AddEmbeddedFont](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifontsmanager/addembeddedfont/) لتضمين خط. تدعم الإصدارات المتعددة إما كائنًا من نوع [IFontData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifontdata/) أو مصفوفة بايت تحتوي على بيانات الخط. يحدد تعداد [EmbedFontCharacters](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/embedfontcharacters/) الأحرف التي يتم تضمينها:
- [All](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/embedfontcharacters/) يضمّن جميع الأحرف في الخط. استخدم هذا الخيار عندما يحتاج المتلقون إلى تحرير العرض وإدخال نص جديد.
- [OnlyUsed](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/embedfontcharacters/) يضمّن فقط الأحرف المستخدمة في العرض لتقليل حجم الملف. اختر هذا الخيار لعروض نهائية مخصصة أساسًا للعرض.

المثال التالي يستخدم [IFontsManager::GetFonts](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifontsmanager/getfonts/) لاسترجاع الخطوط المستخدمة في `Fonts.pptx` ويضمّن تلك التي لم تُضمّن بعد. يجب أن تكون الخطوط المراد إضافتها متوفرة على الجهاز المشغل للشفرة. الخطوط المضمَّنة الموجودة تحتفظ بمجموعة الأحرف الحالية.
```cpp
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/EmbedFontCharacters.h>
#include <Export/SaveFormat.h>
#include <system/collections/sorted_set.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto allFonts = fontsManager->GetFonts();
auto embeddedFonts = fontsManager->GetEmbeddedFonts();
auto embeddedFontNames = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

for (auto&& embeddedFont : embeddedFonts)
{
    embeddedFontNames->Add(embeddedFont->get_FontName());
}

for (auto&& font : allFonts)
{
    if (!embeddedFontNames->Contains(font->get_FontName()))
    {
        fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::All);
        embeddedFontNames->Add(font->get_FontName());
    }
}

presentation->Save(u"WithEmbeddedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ضغط الخطوط المضمَّنة**

[Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) يقلل من بيانات الخط المضمّن بإزالة الأحرف غير المستخدمة. يعمل على الخطوط التي تم تضمينها مسبقاً، لذا يعتمد تقليل الحجم على مقدار بيانات الخط غير المستخدمة في العرض.

المثال التالي يضغط الخطوط في `EmbeddedFonts.pptx` ويحفظ النتيجة كملف منفصل:
```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"EmbeddedFonts.pptx");
Compress::CompressEmbeddedFonts(presentation);
presentation->Save(u"CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

احتفظ بالملف الأصلي إذا كان قد يحتاج المتلقون إلى إضافة نص لاحقًا. الأحرف التي أزيلت أثناء الضغط لم تعد متاحة من الخط المضمّن، حتى وإن كنت قد ضمنت جميع الأحرف في البداية.

## **الأسئلة الشائعة**

**كيف يمكنني التحقق مما إذا كان الخط المضمّن سيُستبدل أثناء العرض؟**

استدعِ [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifontsmanager/getsubstitutions/) في البيئة التي تعرض فيها العرض لمعرفة الخطوط التي سيستبدلها Aspose.Slides. تحقق أيضاً من إعدادات [font substitution](/slides/ar/cpp/font-substitution/) وقواعد [font fallback](/slides/ar/cpp/fallback-font/). يتعامل fallback مع الأحرف المفقودة، لذا فإن تضمين الخط لا يحل مشكلة الأحرف التي لا يحتويها الخط نفسه.

**هل يجب عليّ تضمين الخطوط الشائعة مثل Arial و Calibri؟**

اتخذ القرار بناءً على البيئة المستهدفة. إذا كانت الخطوط المطلوبة متوفرة على كل جهاز يفتح أو يعرض العرض، قد يؤدي تضمينها إلى زيادة حجم الملف دون ضرورة. إذا كان قد يفتقر المتلقون أو الخوادم إلى تلك الخطوط، قد يساعد تضمينها في الحفاظ على المظهر المقصود، بشرط أن تسمح تراخيصها بذلك.