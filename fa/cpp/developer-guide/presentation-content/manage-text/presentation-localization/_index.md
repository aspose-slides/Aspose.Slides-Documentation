---
title: اتوماسیون بومی‌سازی ارائه در C++
linktitle: بومی‌سازی ارائه
type: docs
weight: 100
url: /fa/cpp/presentation-localization/
keywords:
- تغییر زبان
- بررسی املا
- سرکوب بررسی املا
- زبان اثبات
- شناسه زبان
- متن چندزبانه
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "زبان‌های اثبات را برای متن ارائه‌های PowerPoint و OpenDocument در C++ با Aspose.Slides تنظیم کنید، شامل مقادیر پیش‌فرض و پاراگراف‌های چندزبانه."
---
## **نمای کلی**

Aspose.Slides for C++ به شما امکان می‌دهد متادیتای اثبات را برای بخش‌های متنی فردی پیکربندی کنید. برای شناسایی زبان اثبات، از [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseportionformat/set_languageid/) استفاده کنید، برای اجازه یا سرکوب بررسی املا، از [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/fa/cpp/aspose.slides/baseportionformat/set_spellcheck/) استفاده کنید و برای کنترل وضعیت کلی «بدون اثبات»، از [BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/fa/cpp/aspose.slides/baseportionformat/set_proofdisabled/) استفاده کنید. چون این تنظیمات در سطح بخش اعمال می‌شوند، یک پاراگراف می‌تواند شامل چندین زبان و قوانین اثبات متفاوت باشد.

این مقاله توضیح می‌دهد که چگونه یک زبان را به متن خاصی اختصاص دهید، زبان پیش‌فرض برای متن جدید را با [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) تنظیم کنید، پاراگراف‌های چندزبانه بسازید، بین `SpellCheck` و `ProofDisabled` انتخاب کنید و هنگام استفاده از [Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/joinportionswithsameformatting/) تنظیمات مورد نظر را حفظ کنید. این ویژگی‌ها متادیتای مربوط به برنامه‌های ارائه را ذخیره می‌کنند؛ آن‌ها متن را ترجمه نمی‌کنند، بررسی املا بر پایهٔ واژه‌نامه را انجام نمی‌دهند و کلمات غلط املایی را بر نمی‌گردانند.

## **تنظیم زبان اثبات برای متن**

یک [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد یا بارگذاری کنید، بخش متنی مورد نیاز را از طریق [IPortion::get_PortionFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iportion/get_portionformat/) به دست آورید و شناسهٔ زبان آن را اختصاص دهید. مثال زیر یک شکل ایجاد می‌کند، انگلیسی بریتانیایی را به عنوان زبان اثبات تنظیم می‌کند و نتیجه را با [Presentation::Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/save/) ذخیره می‌نماید:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Set the proofing language for this text.");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->set_LanguageId(u"en-GB");

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **تنظیم زبان پیش‌فرض برای متن جدید**

از [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) برای تعیین زبان اثباتی که Aspose.Slides به متنی که به تازگی ایجاد می‌شود اختصاص می‌دهد، استفاده کنید. این تنظیم وقتی مفید است که بیشتر یا تمام متون جدید در یک ارائه از یک زبان استفاده کنند. این تنظیم متادیتای زبان متن‌هایی که قبلاً شناسهٔ صریحی داشته‌اند را تغییر نمی‌دهد.

مثال زیر یک ارائه ایجاد می‌کند که متن جدید آن از قواعد اثبات آلمانی استفاده می‌کند:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"de-DE");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Willkommen zur Präsentation");

presentation->Save(u"default_text_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **استفاده از چندین زبان در یک پاراگراف**

یک [IParagraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraph/) شامل مجموعه‌ای از بخش‌های متنی است. برای هر زبان یک [Portion](https://reference.aspose.com/slides/fa/cpp/aspose.slides/portion/) جداگانه ایجاد کنید و `LanguageId` آن را به طور مستقل تنظیم کنید.

این مثال یک پاراگراف با بخش‌های انگلیسی و فرانسوی ایجاد می‌کند:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 420.0f, 80.0f);
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto englishPortion = System::MakeObject<Portion>(u"Welcome");
englishPortion->get_PortionFormat()->set_LanguageId(u"en-US");
paragraph->get_Portions()->Add(englishPortion);

auto frenchPortion = System::MakeObject<Portion>(u" — Bienvenue");
frenchPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
paragraph->get_Portions()->Add(frenchPortion);

presentation->Save(u"multilingual_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **فعال یا غیرفعال کردن بررسی املا برای بخش‌های منفرد**

[IPortionFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iportionformat/) ویژگی‌های متنی عمومی تعریف‌شده توسط [IBasePortionFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseportionformat/) را به ارث می‌برد. با استفاده از [IPortion::get_PortionFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iportion/get_portionformat/) به قالب یک بخش دسترسی پیدا کنید و [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/fa/cpp/aspose.slides/baseportionformat/set_spellcheck/) را فراخوانی کنید تا کنترل کنید آیا برنامهٔ ارائه می‌تواند املا را برای آن بخش بررسی کند یا خیر. مقدار پیش‌فرض `false` است: `true` اجازهٔ بررسی املا را می‌دهد، در حالی که `false` آن را سرکوب می‌کند.

این تنظیم برای بخش‌های متنی منفرد اعمال می‌شود. بنابراین بخش‌های مختلف در همان پاراگراف می‌توانند مقادیر متفاوتی داشته باشند. [BasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/fa/cpp/aspose.slides/baseportionformat/set_languageid/) و `SpellCheck` اهداف تکمیلی دارند: `LanguageId` زبان اثبات را شناسایی می‌کند، در حالی که `SpellCheck` تعیین می‌کند آیا بررسی املا برای بخش مجاز است یا نه.

[BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/fa/cpp/aspose.slides/baseportionformat/set_proofdisabled/) نیز اثبات را کنترل می‌کند، اما وضعیت گستردهٔ «عدم اثبات» را به عنوان یک [NullableBool](https://reference.aspose.com/slides/fa/cpp/aspose.slides/nullablebool/) نشان می‌دهد. وقتی به یک سوئیچ بولی مستقیم برای بررسی املا نیاز دارید، از `SpellCheck` استفاده کنید. وقتی نیاز دارید متادیتای «بدون اثبات» ارائه را حفظ یا به‌صراحت کنترل کنید، شامل وضعیت `NullableBool::NotDefined` آن، از `ProofDisabled` استفاده کنید. اگر هر دو ویژگی را تنظیم کنید، مقادیر آن‌ها را سازگار نگه دارید؛ `SpellCheck = true` را با `ProofDisabled = NullableBool::True` ترکیب نکنید.

این ویژگی‌ها متادیتای اثبات را که توسط PowerPoint و سایر برنامه‌های ارائه مورد استفاده قرار می‌گیرد، پیکربندی می‌کند. Aspose.Slides از آن‌ها برای اجرای بررسی املا بر پایهٔ واژه‌نامه یا بازگرداندن فهرست کلمات غلط املایی استفاده نمی‌کند.

مثال کامل زیر یک ارائهٔ ورودی ایجاد می‌کند، آن را بارگذاری می‌کند، تنظیمات مختلف بررسی املا و زبان‌های اثبات را به دو بخش در همان پاراگراف اختصاص می‌دهد، نتیجه را ذخیره می‌کند، مجدداً باز می‌کند و مقادیر ذخیره‌شده را تأیید می‌کند:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const System::String inputFile = u"spell_check_input.pptx";
const System::String outputFile = u"spell_check_settings.pptx";

{
    auto sourcePresentation = System::MakeObject<Presentation>();
    auto sourceSlide = sourcePresentation->get_Slide(0);
    auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 420.0f, 80.0f);
    auto sourceParagraph = sourceShape->get_TextFrame()->get_Paragraph(0);
    sourceParagraph->get_Portions()->Clear();

    auto sourceEnglishPortion = System::MakeObject<Portion>(u"Check this text. ");
    sourceEnglishPortion->get_PortionFormat()->set_LanguageId(u"en-US");
    sourceParagraph->get_Portions()->Add(sourceEnglishPortion);

    auto sourceFrenchPortion = System::MakeObject<Portion>(u"Ignorer ce code : ZX-81.");
    sourceFrenchPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
    sourceParagraph->get_Portions()->Add(sourceFrenchPortion);

    sourcePresentation->Save(inputFile, SaveFormat::Pptx);
    sourcePresentation->Dispose();
}

{
    auto presentation = System::MakeObject<Presentation>(inputFile);
    auto firstShape = presentation->get_Slide(0)->get_Shape(0);
    auto shape = System::ExplicitCast<IAutoShape>(firstShape);
    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);

    auto checkedPortion = paragraph->get_Portion(0);
    checkedPortion->get_PortionFormat()->set_LanguageId(u"en-US");
    checkedPortion->get_PortionFormat()->set_SpellCheck(true);

    auto suppressedPortion = paragraph->get_Portion(1);
    suppressedPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
    suppressedPortion->get_PortionFormat()->set_SpellCheck(false);

    presentation->Save(outputFile, SaveFormat::Pptx);
    presentation->Dispose();
}

auto reopenedPresentation = System::MakeObject<Presentation>(outputFile);
auto reopenedFirstShape = reopenedPresentation->get_Slide(0)->get_Shape(0);
auto reopenedShape = System::ExplicitCast<IAutoShape>(reopenedFirstShape);
auto storedParagraph = reopenedShape->get_TextFrame()->get_Paragraph(0);

bool portionsStored = storedParagraph->get_Portions()->get_Count() == 2;
if (portionsStored)
{
    auto firstStoredPortion = storedParagraph->get_Portion(0);
    auto secondStoredPortion = storedParagraph->get_Portion(1);

    bool firstPortionStored = firstStoredPortion->get_PortionFormat()->get_LanguageId() == u"en-US" && 
        firstStoredPortion->get_PortionFormat()->get_SpellCheck();

    bool secondPortionStored = secondStoredPortion->get_PortionFormat()->get_LanguageId() == u"fr-FR" && 
        !secondStoredPortion->get_PortionFormat()->get_SpellCheck();

    if (firstPortionStored && secondPortionStored)
    {
        System::Console::WriteLine(u"The proofing settings were stored correctly.");
    }
    else
    {
        System::Console::WriteLine(u"The proofing settings could not be verified.");
    }
}
else
{
    System::Console::WriteLine(u"The proofing settings could not be verified.");
}

reopenedPresentation->Dispose();
```

[Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/joinportionswithsameformatting/) بخش‌های مجاور که قالب یکسان دارند را ترکیب می‌کند. تنها تفاوت در `SpellCheck` باعث عدم جداسازی این بخش‌ها نمی‌شود؛ پس از ترکیب، بخش حاصل مقدار `SpellCheck` بخش اول را حفظ می‌کند. اگر بخش‌ها نیاز به تنظیمات متفاوت بررسی املا داشته باشند، قبل از اختصاص این تنظیمات `JoinPortionsWithSameFormatting` را صدا بزنید یا مرزهای بخش حاصل را بررسی کرده و پس از آن تنظیمات را مجدداً اعمال کنید. بخش‌هایی که مقدار `LanguageId` متفاوت دارند، به دلیل تفاوت قالب زبان اثبات، به‌صورت جداگانه باقی می‌مانند.

## **سوالات متداول**

**آیا شناسهٔ زبان متن را ترجمه می‌کند؟**

نه. [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseportionformat/set_languageid/) متادیتای اثبات را برای املا و دستور زبان ذخیره می‌کند؛ محتوی متن را تغییر نمی‌دهد. متن را جداگانه ترجمه کنید و سپس شناسهٔ زبان مناسب را برای هر بخش ترجمه‌شده تنظیم کنید.

**آیا زبان اثبات کنترل فونت‌ها، شکست هجای کلمات یا بسته‌بندی خط را انجام می‌دهد؟**

نه. شناسهٔ زبان برای اثبات است. رندرینگ متن و چیدمان عمدتاً به [فونت‌های](/slides/fa/cpp/powerpoint-fonts/) موجود، سیستم نوشتاری و تنظیمات چارچوب متن وابسته است. برای رندرینگ قابل اعتماد، فونت‌های مورد نیاز را فراهم کنید، [جایگزینی فونت](/slides/fa/cpp/font-substitution/) را پیکربندی کنید یا فونت‌ها را در ارائه [جایگذاری](/slides/fa/cpp/embedded-font/) کنید.

**آیا یک پاراگراف می‌تواند چندین زبان اثبات داشته باشد؟**

بله. هر زبان را به یک بخش جداگانه اختصاص دهید، همان‌طور که در مثال پاراگراف چندزبانه نشان داده شده است.

**کدامیک را باید استفاده کنم، `DefaultTextLanguage` یا `LanguageId`؟**

وقتی می‌خواهید یک مقدار پیش‌فرض برای متنی که به تازگی ایجاد می‌شود داشته باشید، از [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) استفاده کنید. وقتی یک بخش خاص نیاز به زبان اثبات صریح دارد یا یک پاراگراف شامل چندین زبان است، از [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseportionformat/set_languageid/) استفاده کنید.