---
title: Prezentáció lokalizációjának automatizálása .NET-ben
linktitle: Prezentáció lokalizáció
type: docs
weight: 100
url: /hu/net/presentation-localization/
keywords:
- nyelv módosítása
- helyesírás-ellenőrzés
- helyesírás-ellenőrzés letiltása
- javítási nyelv
- nyelvi azonosító
- többnyelvű szöveg
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Állítsa be a javítási nyelveket a PowerPoint és OpenDocument prezentáció szövegéhez .NET-ben az Aspose.Slides segítségével, beleértve az alapértelmezéseket és a többnyelvű bekezdéseket."
---
## **Áttekintés**

Aspose.Slides for .NET lehetővé teszi, hogy a bizonyos szövegrészekhez igazítási metaadatokat állítson be. Használja az [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseportionformat/languageid/) a javítási nyelv azonosításához, a [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/hu/net/aspose.slides/baseportionformat/spellcheck/) a helyesírás-ellenőrzés engedélyezéséhez vagy letiltásához, valamint a [BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/hu/net/aspose.slides/baseportionformat/proofdisabled/) a szélesebb körű „nem javít” állapot szabályozásához. Mivel ezek a beállítások a rész szintjén kerülnek alkalmazásra, egy bekezdés több nyelvet és különböző ellenőrzési szabályokat tartalmazhat.

Ez a cikk bemutatja, hogyan rendeljünk nyelvet a konkrét szöveghez, hogyan állítsuk be az új szöveg alapértelmezett nyelvét a [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/defaulttextlanguage/) segítségével, hogyan hozzunk létre többnyelvű bekezdéseket, hogyan válasszunk a `SpellCheck` és a `ProofDisabled` között, és hogyan őrizzük meg a kívánt beállításokat a [Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/joinportionswithsameformatting/) használatakor. Ezek a tulajdonságok metaadatot tárolnak a prezentációs alkalmazások számára; nem fordítják le a szöveget, nem végeznek szótár alapú helyesírás-ellenőrzést, és nem adnak vissza hibás szavakat.

## **Állítsa be a javítási nyelvet a szöveghez**

Hozzon létre vagy töltsön be egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) objektumot, érje el a kívánt szövegrészt az [IPortion.PortionFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/iportion/portionformat/) segítségével, és rendelje hozzá a nyelvazonosítót. Az alábbi példa egy alakzatot hoz létre, brit angolt állít be javítási nyelvként, majd a [Presentation.Save](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/save/) segítségével elmenti az eredményt:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Set the proofing language for this text.";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.LanguageId = "en-GB";

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **Állítsa be az új szöveg alapértelmezett nyelvét**

Használja a [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/defaulttextlanguage/) beállítást, hogy megadja az ellenőrzési nyelvet, amelyet az Aspose.Slides automatikusan hozzárendel az újonnan létrehozott szöveghez. Ez a beállítás akkor hasznos, ha a prezentációban a legtöbb vagy az összes új szöveg ugyanazt a nyelvet használja. Nem változtatja meg a már kifejezett nyelvű szöveg metaadatait.

Az alábbi példa egy olyan prezentációt hoz létre, amelyben az új szöveg német helyesírási szabályokat használ:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DefaultTextLanguage = "de-DE"
};

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Willkommen zur Präsentation";

presentation.Save("default_text_language.pptx", SaveFormat.Pptx);
```

## **Több nyelv használata egy bekezdésben**

Egy [IParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/) kollekciót tartalmaz a szövegrészekből. Hozzon létre külön [Portion](https://reference.aspose.com/slides/hu/net/aspose.slides/portion/) objektumot minden nyelvhez, és állítsa be önállóan a `LanguageId`-t.

Ez a példa egy bekezdést hoz létre, amely angol és francia részeket tartalmaz:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var englishPortion = new Portion("Welcome");
englishPortion.PortionFormat.LanguageId = "en-US";
paragraph.Portions.Add(englishPortion);

var frenchPortion = new Portion(" — Bienvenue");
frenchPortion.PortionFormat.LanguageId = "fr-FR";
paragraph.Portions.Add(frenchPortion);

presentation.Save("multilingual_text.pptx", SaveFormat.Pptx);
```

## **Egyes részek helyesírás-ellenőrzésének engedélyezése vagy letiltása**

Az [IPortionFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/iportionformat/) örökli a [IBasePortionFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseportionformat/) által meghatározott közös szövegtulajdonságokat. Egy rész formátumát az [IPortion.PortionFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/iportion/portionformat/) segítségével érheti el, és beállíthatja a [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/hu/net/aspose.slides/baseportionformat/spellcheck/) értékét, hogy meghatározza, a prezentációs alkalmazás ellenőrizheti-e a helyesírást az adott részben. Az alapértelmezett érték `false`: a `true` engedélyezi a helyesírás-ellenőrzést, míg a `false` letiltja azt.

Ez a beállítás az egyes szövegrészekre vonatkozik. Így egy bekezdésen belül különböző részek különböző értékeket használhatnak. A [BasePortionFormat.LanguageId](https://reference.aspose.com/slides/hu/net/aspose.slides/baseportionformat/languageid/) és a `SpellCheck` kiegészítő célokat szolgálnak: a `LanguageId` az ellenőrzési nyelvet azonosítja, míg a `SpellCheck` meghatározza, hogy a rész helyesírás-ellenőrzése engedélyezett-e.

A [BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/hu/net/aspose.slides/baseportionformat/proofdisabled/) szintén szabályozza a javítást, de a szélesebb körű „ne javítson” állapotot egy [NullableBool](https://reference.aspose.com/slides/hu/net/aspose.slides/nullablebool/) formájában jeleníti meg. Használja a `SpellCheck`-et, ha közvetlen Boolean kapcsolót szeretne kifejezetten a helyesírás-ellenőrzéshez. Használja a `ProofDisabled`-et, ha a prezentáció „nem javított” metaadatait szeretné megőrizni vagy kifejezetten szabályozni, beleértve a `NotDefined` állapotot is. Ha mindkét tulajdonságot beállítja, tartsa értékeiket konzisztensen; ne kombinálja a `SpellCheck = true`-t a `ProofDisabled = NullableBool.True`-val.

Ezek a tulajdonságok a PowerPoint és más prezentációs alkalmazások által használt javítási metaadatokat konfigurálják. Az Aspose.Slides nem használja őket szótár alapú helyesírás-ellenőrzéshez, és nem ad vissza hibás szavak listáját.

Az alábbi teljes példában bemutatjuk, hogyan hozunk létre bemeneti prezentációt, töltsük be, rendeljünk különböző helyesírás-ellenőrzési beállításokat és javítási nyelveket két résznek ugyanabban a bekezdésben, mentsük el az eredményt, nyissuk meg újra, és ellenőrizzük a tárolt értékeket:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputFile = "spell_check_input.pptx";
const string outputFile = "spell_check_settings.pptx";

using (var sourcePresentation = new Presentation())
{
    var sourceSlide = sourcePresentation.Slides[0];
    var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    var sourceParagraph = sourceShape.TextFrame.Paragraphs[0];
    sourceParagraph.Portions.Clear();

    var sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.PortionFormat.LanguageId = "en-US";
    sourceParagraph.Portions.Add(sourceEnglishPortion);

    var sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.PortionFormat.LanguageId = "fr-FR";
    sourceParagraph.Portions.Add(sourceFrenchPortion);

    sourcePresentation.Save(inputFile, SaveFormat.Pptx);
}

using (var presentation = new Presentation(inputFile))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var portions = shape.TextFrame.Paragraphs[0].Portions;

    var checkedPortion = portions[0];
    checkedPortion.PortionFormat.LanguageId = "en-US";
    checkedPortion.PortionFormat.SpellCheck = true;

    var suppressedPortion = portions[1];
    suppressedPortion.PortionFormat.LanguageId = "fr-FR";
    suppressedPortion.PortionFormat.SpellCheck = false;

    presentation.Save(outputFile, SaveFormat.Pptx);
}

using var reopenedPresentation = new Presentation(outputFile);
var reopenedShape = (IAutoShape)reopenedPresentation.Slides[0].Shapes[0];
var storedPortions = reopenedShape.TextFrame.Paragraphs[0].Portions;

var firstPortionStored = storedPortions.Count == 2 &&
    storedPortions[0].PortionFormat.LanguageId == "en-US" &&
    storedPortions[0].PortionFormat.SpellCheck;

var secondPortionStored = storedPortions.Count == 2 &&
    storedPortions[1].PortionFormat.LanguageId == "fr-FR" &&
    !storedPortions[1].PortionFormat.SpellCheck;

if (firstPortionStored && secondPortionStored)
{
    Console.WriteLine("The proofing settings were stored correctly.");
}
else
{
    Console.WriteLine("The proofing settings could not be verified.");
}
```

A [Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/joinportionswithsameformatting/) összevonja az egymás melletti, azonos formázású részeket. Az `SpellCheck` különbözősége önmagában nem tartja szét ezeket a részeket; az egyesítés után a keletkező rész megtartja az első rész `SpellCheck` értékét. Ha a részeknek különböző helyesírás-ellenőrzési beállításokra van szükségük, hívja meg a `JoinPortionsWithSameFormatting`-et a beállítások hozzárendelése előtt, vagy ellenőrizze a keletkező rész határait, és utólag állítsa be újra a beállításokat. A különböző `LanguageId` értékű részek külön maradnak, mivel a javítási nyelv formázása eltér.

## **GYIK**

**A nyelvazonosító lefordítja a szöveget?**

Nem. Az [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseportionformat/languageid/) metaadatot tárol a helyesírási és nyelvtani ellenőrzéshez; nem módosítja a szövegtartalmat. A szöveget külön kell lefordítani, majd állítsa be a megfelelő nyelvazonosítót minden lefordított részhez.

**A javítási nyelv befolyásolja a betűtípusokat, elválasztást vagy sortörést?**

Nem. A nyelvazonosító csak a javításhoz szolgál. A szöveg megjelenítése és elrendezése elsősorban a rendelkezésre álló [fonts](/slides/hu/net/powerpoint-fonts/), az írásrendszer, és a szövegkeret beállítások függvénye. A megbízható megjelenítéshez biztosítsa a szükséges betűtípusokat, konfigurálja a [font substitution](/slides/hu/net/font-substitution/), vagy [embed fonts](/slides/hu/net/embedded-font/) a prezentációba.

**Használhat egy bekezdés több javítási nyelvet?**

Igen. Rendelje minden nyelvet egy külön részhez, ahogyan a többnyelvű bekezdés példában is látható.

**Használjam a `DefaultTextLanguage`-t vagy a `LanguageId`-t?**

Használja a [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/defaulttextlanguage/) beállítást, ha alapértelmezett nyelvet szeretne az újonnan létrehozott szöveghez. Használja az [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseportionformat/languageid/) beállítást, ha egy adott résznek kifejezett javítási nyelvre van szüksége, vagy ha egy bekezdés több nyelvet tartalmaz.