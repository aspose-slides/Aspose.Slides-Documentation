---
title: Automatizace lokalizace prezentace v C++
linktitle: Lokalizace prezentace
type: docs
weight: 100
url: /cs/cpp/presentation-localization/
keywords:
- změnit jazyk
- kontrola pravopisu
- potlačit kontrolu pravopisu
- jazyk korektury
- identifikátor jazyka
- vícejazyčný text
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Nastavte jazyky korektury pro text prezentací v PowerPointu a OpenDocument v C++ pomocí Aspose.Slides, včetně výchozích hodnot a vícejazyčných odstavců."
---
## **Přehled**

Aspose.Slides pro C++ vám umožňuje konfigurovat metadata korektury pro jednotlivé textové části. Použijte [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibaseportionformat/set_languageid/) k určení jazyka korektury, [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/cs/cpp/aspose.slides/baseportionformat/set_spellcheck/) k povolení nebo potlačení kontrol pravopisu a [BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/cs/cpp/aspose.slides/baseportionformat/set_proofdisabled/) k řízení širšího stavu „neprovádět korekturu“. Protože se tato nastavení aplikují na úrovni části, může jeden odstavec obsahovat více jazyků a různé pravidla korektury.

Tento článek vysvětluje, jak přiřadit jazyk konkrétnímu textu, nastavit výchozí jazyk pro nový text pomocí [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/), vytvořit vícejazyčné odstavce, zvolit mezi `SpellCheck` a `ProofDisabled` a zachovat požadovaná nastavení při použití [Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/joinportionswithsameformatting/). Tyto vlastnosti ukládají metadata pro prezentační aplikace; nepřekládají text, neprovádějí kontrolu pravopisu na základě slovníku ani nevracejí nesprávně napsaná slova.

## **Nastavte jazyk korektury pro text**

Vytvořte nebo načtěte [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/), přistupte k požadované textové části přes [IPortion::get_PortionFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportion/get_portionformat/) a přiřaďte její identifikátor jazyka. Následující příklad vytvoří tvar, nastaví britskou angličtinu jako jazyk korektury a výsledek uloží pomocí [Presentation::Save](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/save/):

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

## **Nastavte výchozí jazyk pro nový text**

Použijte [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) k určení jazyka korektury, který Aspose.Slides přiřadí nově vytvořenému textu. Toto nastavení je užitečné, když většina nebo celý nový text v prezentaci používá stejný jazyk. Nemění metadata jazyka textu, který již má explicitně nastavený jazyk.

Následující příklad vytvoří prezentaci, jejíž nový text používá německá pravidla korektury:

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

## **Použijte více jazyků v jednom odstavci**

[IParagraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraph/) obsahuje kolekci textových částí. Pro každý jazyk vytvořte samostatnou [Portion](https://reference.aspose.com/slides/cs/cpp/aspose.slides/portion/) a nastavte její `LanguageId` nezávisle.

Tento příklad vytvoří jeden odstavec s částmi v angličtině a francouzštině:

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

## **Povolit nebo potlačit kontrolu pravopisu pro jednotlivé části**

[IPortionFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportionformat/) dědí společné textové vlastnosti definované v [IBasePortionFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibaseportionformat/). Přistupte k formátu části přes [IPortion::get_PortionFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportion/get_portionformat/) a zavolejte [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/cs/cpp/aspose.slides/baseportionformat/set_spellcheck/) k řízení, zda prezentační aplikace může kontrolovat pravopis této části. Výchozí hodnota je `false`: `true` povoluje kontrolu pravopisu, zatímco `false` ji potlačuje.

Nastavení se vztahuje na jednotlivé textové části. Různé části ve stejném odstavci tak mohou mít různé hodnoty. [BasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cs/cpp/aspose.slides/baseportionformat/set_languageid/) a `SpellCheck` slouží k doplňujícím účelům: `LanguageId` určuje jazyk korektury, zatímco `SpellCheck` určuje, zda je kontrola pravopisu povolena pro danou část.

[BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/cs/cpp/aspose.slides/baseportionformat/set_proofdisabled/) také řídí korekturu, ale představuje širší stav „neprovádět korekturu“ jako [NullableBool](https://reference.aspose.com/slides/cs/cpp/aspose.slides/nullablebool/). Použijte `SpellCheck`, když potřebujete přímý Boolean přepínač jen pro kontrolu pravopisu. Použijte `ProofDisabled`, když potřebujete zachovat nebo explicitně řídit metadata o nepoužití korektury, včetně stavu `NullableBool::NotDefined`. Pokud nastavíte obě vlastnosti, udržujte jejich hodnoty konzistentní; nekombinujte `SpellCheck = true` s `ProofDisabled = NullableBool::True`.

Tyto vlastnosti konfigurovat metadata korektury používaná PowerPointem a dalšími prezentačními aplikacemi. Aspose.Slides je nepoužívá k provádění slovníkových kontrol pravopisu ani k vracení seznamu chybně napsaných slov.

Následující kompletní příklad vytvoří vstupní prezentaci, načte ji, přiřadí různé nastavení kontroly pravopisu a jazyky korektury dvěma částem ve stejném odstavci, výsledek uloží, otevře jej znovu a ověří uložené hodnoty:

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

[Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/joinportionswithsameformatting/) spojuje sousední části, které mají stejné formátování. Rozdíl pouze v `SpellCheck` neudrží takové části oddělené; po jejich sloučení část zachová hodnotu `SpellCheck` první části. Pokud části potřebují odlišná nastavení kontroly pravopisu, zavolejte `JoinPortionsWithSameFormatting` před přiřazením těchto nastavení, nebo po sloučení zkontrolujte hranice vzniklých částí a nastavení znovu aplikujte. Části s odlišnými hodnotami `LanguageId` zůstanou oddělené, protože se liší formátováním jazyka korektury.

## **FAQ**

**Překládá jazykové ID text?**

Ne. [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibaseportionformat/set_languageid/) ukládá metadata korektury pro pravopis a gramatiku; nemění obsah textu. Přeložte text samostatně a poté nastavte příslušný identifikátor jazyka pro každou přeloženou část.

**Řídí jazyk korektury fonty, dělení slov nebo zalomení řádků?**

Ne. Identifikátor jazyka slouží jen k korektuře. Vykreslování a rozvržení textu závisí především na dostupných [fontech](/slides/cs/cpp/powerpoint-fonts/), písmu a nastaveních textového rámce. Pro spolehlivé vykreslení zajistěte požadované fonty, nakonfigurujte [náhradu fontů](/slides/cs/cpp/font-substitution/) nebo [vložte fonty](/slides/cs/cpp/embedded-font/) do prezentace.

**Může jeden odstavec používat několik jazyků korektury?**

Ano. Přiřaďte každý jazyk samostatné části, jak je ukázáno v příkladu vícejazyčného odstavce.

**Mám použít `DefaultTextLanguage` nebo `LanguageId`?**

Použijte [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/), když chcete výchozí jazyk pro nově vytvořený text. Použijte [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibaseportionformat/set_languageid/), když konkrétní část potřebuje explicitní jazyk korektury nebo když odstavec obsahuje více jazyků.