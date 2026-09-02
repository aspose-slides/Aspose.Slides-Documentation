---
title: Automatisera presentation lokalisering i C++
linktitle: Presentation lokalisering
type: docs
weight: 100
url: /sv/cpp/presentation-localization/
keywords:
- ändra språk
- stavningskontroll
- undertryck stavningskontroll
- korrekturspråk
- språk-id
- flerspråkig text
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Ställ in korrekturspråk för PowerPoint- och OpenDocument-presentationstext i C++ med Aspose.Slides, inklusive standardvärden och flerspråkiga stycken."
---
## **Översikt**

Aspose.Slides för C++ låter dig konfigurera korrekturmetadata för enskilda textdelar. Använd [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibaseportionformat/set_languageid/) för att ange korrekturspråket, [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/sv/cpp/aspose.slides/baseportionformat/set_spellcheck/) för att tillåta eller undertrycka stavningskontroller och [BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/sv/cpp/aspose.slides/baseportionformat/set_proofdisabled/) för att styra det bredare ”ingen korrektur”-tillståndet. Eftersom dessa inställningar tillämpas på portionsnivå kan ett stycke innehålla flera språk och olika korrekturregler.

Denna artikel förklarar hur du tilldelar ett språk till specifik text, ställer in standardspråket för ny text med [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/), bygger flerspråkiga stycken, väljer mellan `SpellCheck` och `ProofDisabled` samt bevarar de avsedda inställningarna när du använder [Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/joinportionswithsameformatting/). Dessa egenskaper lagrar metadata för presentationsprogram; de översätter inte text, utför inte ordboksbaserad stavningskontroll och returnerar inte felstavade ord.

## **Ställ in korrekturspråket för text**

Skapa eller läs in en [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/), få åtkomst till den erforderliga textdelen via [IPortion::get_PortionFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iportion/get_portionformat/) och tilldela dess språkidentifierare. Följande exempel skapar en form, anger brittisk engelska som korrekturspråk och sparar resultatet med [Presentation::Save](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/save/):

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

## **Ställ in standardspråk för ny text**

Använd [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) för att ange det korrekturspråk som Aspose.Slides tilldelar ny skapad text. Denna inställning är användbar när det mesta eller hela nya textinnehållet i en presentation använder samma språk. Den ändrar inte språkmetadata för text som redan har ett explicit språk.

Följande exempel skapar en presentation där ny text använder tyska korrekturregler:

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

## **Använd flera språk i ett stycke**

Ett [IParagraph](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraph/) innehåller en samling textdelar. Skapa en separat [Portion](https://reference.aspose.com/slides/sv/cpp/aspose.slides/portion/) för varje språk och ange dess `LanguageId` oberoende.

Detta exempel skapar ett stycke med engelska och franska delar:

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

## **Aktivera eller undertryck stavningskontroll för enskilda delar**

[IPortionFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iportionformat/) ärver de gemensamma textegenskaper som definieras av [IBasePortionFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibaseportionformat/). Få åtkomst till en parts format via [IPortion::get_PortionFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iportion/get_portionformat/) och anropa [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/sv/cpp/aspose.slides/baseportionformat/set_spellcheck/) för att styra om ett presentationsprogram får kontrollera stavning för den delen. Standardvärdet är `false`: `true` tillåter stavningskontroll, medan `false` undertrycker den.

Inställningen gäller enskilda textdelar. Olika delar i samma stycke kan därför ha olika värden. [BasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/sv/cpp/aspose.slides/baseportionformat/set_languageid/) och `SpellCheck` har kompletterande syften: `LanguageId` identifierar korrekturspråket, medan `SpellCheck` bestämmer om stavningskontroller är tillåtna för delen.

[BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/sv/cpp/aspose.slides/baseportionformat/set_proofdisabled/) styr också korrektur, men den representerar det bredare ”gör ingen korrektur”-tillståndet som en [NullableBool](https://reference.aspose.com/slides/sv/cpp/aspose.slides/nullablebool/). Använd `SpellCheck` när du behöver en direkt Boolesk växel specifikt för stavningskontroller. Använd `ProofDisabled` när du vill bevara eller explicit styra presentationens inga‑korrektur‑metadata, inklusive dess `NullableBool::NotDefined`‑tillstånd. Om du sätter båda egenskaperna, håll deras värden konsekventa; kombinera inte `SpellCheck = true` med `ProofDisabled = NullableBool::True`.

Dessa egenskaper konfigurerar korrekturmetadata som används av PowerPoint och andra presentationsprogram. Aspose.Slides använder dem inte för att köra ordboksbaserad stavningskontroll eller returnera en lista över felstavade ord.

Följande kompletta exempel skapar en inmatningspresentation, läser in den, tilldelar olika stavningskontrollinställningar och korrekturspråk till två delar i samma stycke, sparar resultatet, öppnar det igen och verifierar de lagrade värdena:

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

[Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/joinportionswithsameformatting/) förenar intilliggande delar som har samma formatering. En skillnad i `SpellCheck` ensam håller inte sådana delar separata; efter att de har förenats behåller den resulterande delen `SpellCheck`‑värdet från den första delen. Om delar behöver olika stavningskontrollinställningar, anropa `JoinPortionsWithSameFormatting` innan du tilldelar dessa inställningar, eller inspektera de resulterande delgränserna och återapplicera inställningarna efteråt. Delar med olika `LanguageId`‑värden förblir separata eftersom deras korrektur‑språksformatering skiljer sig.

## **FAQ**

**Översätter ett språk‑ID texten?**

Nej. [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibaseportionformat/set_languageid/) lagrar korrekturmetadata för stavning och grammatik; den förändrar inte textinnehållet. Översätt texten separat och sätt sedan rätt språkidentifierare för varje översatt del.

**Styr korrekturspråket typsnitt, bindestreck eller radbrytning?**

Nej. Språkidentifieraren är avsedd för korrektur. Textrendering och layout beror främst på tillgängliga [fonts](/slides/sv/cpp/powerpoint-fonts/), skriftsystemet och inställningarna för text‑ramen. För pålitlig rendering, tillhandahåll de erforderliga typsnitten, konfigurera [font substitution](/slides/sv/cpp/font-substitution/) eller [embed fonts](/slides/sv/cpp/embedded-font/) i presentationen.

**Kan ett stycke använda flera korrekturspråk?**

Ja. Tilldela varje språk till en separat del, som visas i exemplet med flerspråkigt stycke.

**Ska jag använda `DefaultTextLanguage` eller `LanguageId`?**

Använd [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) när du vill ha ett standardvärde för ny skapad text. Använd [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibaseportionformat/set_languageid/) när en specifik del behöver ett explicit korrekturspråk eller när ett stycke innehåller flera språk.