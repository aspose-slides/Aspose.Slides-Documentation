---
title: A prezentáció lokalizálásának automatizálása C++-ban
linktitle: Prezentáció lokalizálása
type: docs
weight: 100
url: /hu/cpp/presentation-localization/
keywords:
- nyelv módosítása
- helyesírás-ellenőrzés
- helyesírás-ellenőrzés letiltása
- ellenőrzési nyelv
- nyelvazonosító
- többnyelvű szöveg
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Állítsa be a proofing nyelveket PowerPoint és OpenDocument prezentáció szövegeihez C++-ban az Aspose.Slides segítségével, beleértve az alapértelmezéseket és a többnyelvű bekezdéseket."
---
## **Áttekintés**

Az Aspose.Slides for C++ lehetővé teszi, hogy egyedi szövegrésszek proofing metaadatait konfigurálja. Használja a [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseportionformat/set_languageid/) függvényt a proofing nyelv azonosításához, a [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/hu/cpp/aspose.slides/baseportionformat/set_spellcheck/) függvényt a helyesírás-ellenőrzés engedélyezéséhez vagy letiltásához, valamint a [BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/hu/cpp/aspose.slides/baseportionformat/set_proofdisabled/) függvényt a szélesebb körű proof tiltás vezérléséhez. Mivel ezek a beállítások a rész szintjén kerülnek alkalmazásra, egy bekezdés több nyelvet és különböző proofing szabályokat is tartalmazhat.

Ez a cikk elmagyarázza, hogyan lehet egy nyelvet hozzárendelni egy adott szöveghez, hogyan állítható be az új szöveg alapértelmezett nyelve a [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) segítségével, hogyan építhetők fel többnyelvű bekezdések, hogyan választható a `SpellCheck` vagy a `ProofDisabled`, és hogyan őrizhetők meg a kívánt beállítások a [Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/joinportionswithsameformatting/) használata során. Ezek a tulajdonságok metaadatot tárolnak a prezentációs alkalmazások számára; nem fordítanak szöveget, nem hajtanak végre szótár-alapú helyesírás-ellenőrzést, és nem adnak vissza hibás szavakat.

## **A proofing nyelv beállítása a szöveghez**

Hozzon létre vagy töltsön be egy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/)-t, érje el a kívánt szövegrésszt a [IPortion::get_PortionFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportion/get_portionformat/) segítségével, és rendelje hozzá a nyelvazonosítót. Az alábbi példa egy alakzatot hoz létre, brit angolt állít be proofing nyelvként, majd a [Presentation::Save](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/save/)‑el menti az eredményt:

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

## **Alapértelmezett nyelv beállítása az új szöveghez**

Használja a [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) függvényt annak a proofing nyelvnek a meghatározására, amelyet az Aspose.Slides az újonnan létrehozott szöveghez rendel. Ez a beállítás akkor hasznos, ha a prezentációban a legújabb vagy minden új szöveg ugyanazt a nyelvet használja. Nem módosítja a már explicit nyelvvel rendelkező szöveg nyelvi metaadatait.

Az alábbi példa egy olyan prezentációt hoz létre, amelyben az új szöveg német proofing szabályokat alkalmaz:

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

## **Több nyelv használata egy bekezdésben**

Egy [IParagraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/) szövegrésszek gyűjteményét tartalmazza. Hozzon létre minden nyelvhez egy külön [Portion](https://reference.aspose.com/slides/hu/cpp/aspose.slides/portion/) elemet, és állítsa be a `LanguageId`‑t önállóan.

Ez a példa egy bekezdést hoz létre angol és francia részekkel:

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

## **Helyesírás-ellenőrzés engedélyezése vagy letiltása egyedi részekhez**

Az [IPortionFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportionformat/) örökli az [IBasePortionFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseportionformat/) által meghatározott közös szövegtulajdonságokat. Érje el egy rész formátumát a [IPortion::get_PortionFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportion/get_portionformat/)‑on keresztül, és hívja a [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/hu/cpp/aspose.slides/baseportionformat/set_spellcheck/) függvényt annak vezérlésére, hogy a prezentációs alkalmazás ellenőrizze-e a helyesírást az adott részhez. Az alapértelmezett érték `false`: a `true` engedélyezi a helyesírás-ellenőrzést, míg a `false` letiltja azt.

A beállítás egyedi szövegrésszekre vonatkozik. Így ugyanabban a bekezdésben lévő különböző részek eltérő értékeket használhatnak. A [BasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/hu/cpp/aspose.slides/baseportionformat/set_languageid/) és a `SpellCheck` kiegészítő célokat szolgálnak: a `LanguageId` azonosítja a proofing nyelvet, míg a `SpellCheck` határozza meg, hogy a részhez engedélyezett‑e a helyesírás‑ellenőrzés.

A [BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/hu/cpp/aspose.slides/baseportionformat/set_proofdisabled/) szintén a proofingot vezérli, de a szélesebb körű „ne proofoljon” állapotot egy [NullableBool](https://reference.aspose.com/slides/hu/cpp/aspose.slides/nullablebool/) formájában reprezentálja. Használja a `SpellCheck`‑et, ha egy közvetlen logikai kapcsolóra van szüksége kifejezetten a helyesírás-ellenőrzéshez. Használja a `ProofDisabled`‑et, ha a prezentáció „ne proofoljon” metaadatait szeretné megőrizni vagy kifejezetten szabályozni, beleértve a `NullableBool::NotDefined` állapotot is. Ha mindkét tulajdonságot beállítja, tartsa értékeiket konzisztensen; ne kombinálja a `SpellCheck = true`‑t a `ProofDisabled = NullableBool::True`‑val.

Ezek a tulajdonságok a PowerPoint és más prezentációs alkalmazások által használt proofing metaadatot konfigurálják. Az Aspose.Slides nem használja ezeket szótár‑alapú helyesírás‑ellenőrzésre, és nem ad vissza hibás szavak listáját.

Az alábbi teljes példa egy bemeneti prezentációt hoz létre, betölti, különböző helyesírás‑ellenőrzési beállításokat és proofing nyelveket ad két résznek ugyanabban a bekezdésben, elmenti az eredményt, újra megnyitja, és ellenőrzi a tárolt értékeket:

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

A [Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/joinportionswithsameformatting/) összevonja az egymás melletti, azonos formázású részeket. Egyetlen `SpellCheck` eltérés önmagában nem tartja szét ezeket a részeket; az összevonás után az eredményrész megtartja az első rész `SpellCheck` értékét. Ha a részeknek különböző helyesírás‑ellenőrzési beállításokra van szükségük, hívja a `JoinPortionsWithSameFormatting`‑et a beállítások hozzárendelése előtt, vagy ellenőrizze a kapott részhatárokat, és alkalmazza a beállításokat később. A különböző `LanguageId` értékekkel rendelkező részek külön maradnak, mivel proofing‑nyelvi formázásuk eltér.

## **GYIK**

**A nyelvazonosító lefordítja a szöveget?**

Nem. A [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseportionformat/set_languageid/) proofing metaadatot tárol a helyesírás és nyelvtan ellenőrzéséhez; nem módosítja a szövegtartalmat. A szöveget külön kell lefordítani, majd minden lefordított részhez állítsa be a megfelelő nyelvazonosítót.

**A proofing nyelv befolyásolja a betűtípusokat, elválasztást vagy a sortöréseket?**

Nem. A nyelvazonosító csak proofing célokra szolgál. A szöveg megjelenítése és elrendezése elsősorban az elérhető [fonts](/slides/hu/cpp/powerpoint-fonts/), az írásrendszer és a szövegdoboz beállításaitól függ. A megbízható megjelenítéshez biztosítsa a szükséges betűtípusokat, konfigurálja a [font substitution](/slides/hu/cpp/font-substitution/)‑t, vagy ágyazza be a [betűtípusokat](/slides/hu/cpp/embedded-font/) a prezentációba.

**Használhat egy bekezdés több proofing nyelvet?**

Igen. Minden nyelvet rendelje egy külön részhez, ahogy a többnyelvű bekezdés példában látható.

**Használjam a `DefaultTextLanguage`‑t vagy a `LanguageId`‑t?**

Használja a [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/)‑t, ha alapértelmezett nyelvet szeretne az újonnan létrehozott szöveghez. Használja a [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseportionformat/set_languageid/)‑t, ha egy konkrét résznek explicit proofing nyelvre van szüksége, vagy ha egy bekezdés több nyelvet tartalmaz.