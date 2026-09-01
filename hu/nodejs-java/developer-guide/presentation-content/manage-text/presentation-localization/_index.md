---
title: Prezentációi lokalizáció automatizálása JavaScriptben
linktitle: Prezentációs lokalizáció
type: docs
weight: 100
url: /hu/nodejs-java/presentation-localization/
keywords:
- nyelv módosítása
- helyesírás-ellenőrzés
- helyesírás-ellenőrzés letiltása
- helyesírási nyelv
- nyelvi azonosító
- többnyelvű szöveg
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Állítsa be a helyesírási nyelveket a PowerPoint és OpenDocument prezentáció szövegeihez JavaScriptben az Aspose.Slides használatával, beleértve az alapértelmezéseket és a többnyelvű bekezdéseket."
---
## **Áttekintés**

Az Aspose.Slides for Node.js via Java lehetővé teszi, hogy egyes szövegrészekhez helyesírási metaadatokat konfiguráljon. Használja a [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) metódust a helyesírási nyelv azonosításához, a [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) metódust a helyesírás-ellenőrzés engedélyezéséhez vagy letiltásához, valamint a [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) metódust a szélesebb körű „ne ellenőrizze” állapot vezérléséhez. Mivel ezek a beállítások a részlet szintjén kerülnek alkalmazásra, egy bekezdés több nyelvet és különböző helyesírási szabályokat tartalmazhat.

Ez a cikk bemutatja, hogyan rendeljen nyelvet egy adott szöveghez, hogyan állítsa be az új szöveg alapértelmezett nyelvét a [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) metódussal, hogyan hozzon létre többnyelvű bekezdéseket, hogyan válasszon a `SpellCheck` és a `ProofDisabled` között, valamint hogyan őrizze meg a kívánt beállításokat a [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--) használata közben. Ezek a tulajdonságok a prezentációs alkalmazások számára tárolnak metaadatokat; nem fordítanak szöveget, nem hajtanak végre szótári alapú helyesírás-ellenőrzést, és nem adnak vissza helytelenül írt szavakat.

## **A helyesírási nyelv beállítása a szöveghez**

Hozzon létre vagy töltön be egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) objektumot, érje el a kívánt szövegrészt a [Portion.getPortionFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/#getPortionFormat--) metódussal, és állítsa be a nyelvi azonosítót. Az alábbi példa egy alakzatot hoz létre, brit angolt állít be helyesírási nyelvként, majd az eredményt a [Presentation.save](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) segítségével menti:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Az alapértelmezett nyelv beállítása az új szöveghez**

Használja a [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) metódust annak meghatározásához, hogy az Aspose.Slides milyen helyesírási nyelvet adjon az újból létrehozott szöveghez. Ez a beállítás akkor hasznos, ha a prezentációban a legtöbb vagy az összes új szöveg ugyanazt a nyelvet használja. Nem módosítja azoknak a szövegeknek a nyelvi metaadatait, amelyek már rendelkeznek kifejezett nyelvvel.

Az alábbi példa egy prezentációt hoz létre, amelyben az új szöveg német helyesírási szabályokat használ:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Több nyelv használata egy bekezdésen belül**

Egy [Paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/) a szövegrészek gyűjteménye. Hozzon létre minden nyelvhez külön [Portion](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/) elemet, és állítsa be annak `LanguageId` tulajdonságát önállóan.

Ez a példa egy bekezdést hoz létre, amelyben angol és francia részek szerepelnek:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const englishPortion = new aspose.slides.Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    const frenchPortion = new aspose.slides.Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Egyes részek helyesírás-ellenőrzésének engedélyezése vagy letiltása**

A [PortionFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portionformat/) örökli a [BasePortionFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/) által meghatározott közös szövegtulajdonságokat. Egy részlet formátumához a [Portion.getPortionFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/#getPortionFormat--) segítségével férhet hozzá, majd a [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) metódussal szabályozhatja, hogy a prezentációs alkalmazás ellenőrizze-e a helyesírást az adott részleten. Az alapértelmezett érték `false`: a `true` engedélyezi a helyesírás-ellenőrzést, míg a `false` letiltja azt.

A beállítás egyedi szövegrészekre vonatkozik. Így ugyanabban a bekezdésben különböző részek eltérő értéket kaphatnak. A [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) és a `setSpellCheck` kiegészítő célokra szolgálnak: a `setLanguageId` határozza meg a helyesírási nyelvet, míg a `setSpellCheck` azt, hogy a részlet helyesírása ellenőrizhető‑e.

A [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) szintén a helyesírást szabályozza, de egy szélesebb körű „ne ellenőrizze” állapotot reprezentál egy [NullableBool](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/nullablebool/) értékkel. Használja a `setSpellCheck`‑et, ha egy közvetlen Boolean kapcsolóra van szüksége kifejezetten a helyesírás-ellenőrzéshez. Használja a `setProofDisabled`‑et, ha a prezentáció „nem ellenőrzött” metaadatait szeretné megőrizni vagy kifejezetten szabályozni, beleértve a `NotDefined` állapotot is. Ha mindkét tulajdonságot beállítja, tartsa értékeiket egységesen; ne kombinálja a `setSpellCheck(true)`‑t a `setProofDisabled(NullableBool.True)`‑val.

Ezek a tulajdonságok a PowerPoint és más prezentációs alkalmazások által használt helyesírási metaadatokat konfigurálják. Az Aspose.Slides nem használja őket szótári alapú helyesírás-ellenőrzésre, sem nem ad vissza hibás szavak listáját.

Az alábbi teljes példa bemutat egy bemeneti prezentáció létrehozását, annak betöltését, különböző helyesírás-ellenőrzési beállítások és helyesírási nyelvek hozzárendelését két részlethez ugyanabban a bekezdésben, az eredmény mentését, újranyitását, valamint a tárolt értékek ellenőrzését:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const inputFile = "spell_check_input.pptx";
const outputFile = "spell_check_settings.pptx";

const sourcePresentation = new aspose.slides.Presentation();
try {
    const sourceSlide = sourcePresentation.getSlides().get_Item(0);
    const sourceShape = sourceSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    const sourceEnglishPortion = new aspose.slides.Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    const sourceFrenchPortion = new aspose.slides.Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

const presentation = new aspose.slides.Presentation(inputFile);
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    const suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation(outputFile);
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const firstPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(0).getPortionFormat().getLanguageId() === "en-US" && 
        storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    const secondPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(1).getPortionFormat().getLanguageId() === "fr-FR" && 
        !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        console.log("The proofing settings were stored correctly.");
    } else {
        console.log("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

A [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--) összevonja a szomszédos részeket, ha azok formázása megegyezik. A `SpellCheck` értékének eltérése önmagában nem tartja szét ezeket a részeket; az összevonás után az eredményrészlet megtartja az első részlet `SpellCheck` értékét. Ha a részeknek különböző helyesírás-ellenőrzési beállításokra van szükségük, hívja meg a `joinPortionsWithSameFormatting`‑t a beállítások hozzárendelése előtt, vagy vizsgálja meg az eredményrészlet határait, és alkalmazza a beállításokat később. A különböző `LanguageId` értékű részek a formázásukban lévő helyesírási nyelv különbsége miatt továbbra is külön maradnak.

## **GYIK**

**A nyelvi azonosító lefordítja a szöveget?**

Nem. A [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) a helyesírási és nyelvtani metaadatokat tárolja; nem módosítja a szövegtartalmat. A szöveget külön le kell fordítania, majd minden lefordított részlethez a megfelelő nyelvi azonosítót kell beállítania.

**A helyesírási nyelv szabályozza a betűtípusokat, elválasztást vagy sortörést?**

Nem. A nyelvi azonosító a helyesírásra vonatkozik. A szöveg megjelenítése és elrendezése elsősorban a rendelkezésre álló [fonts](/slides/hu/nodejs-java/powerpoint-fonts/), a írásrendszer és a szövegkeret beállításaitól függ. A megbízható megjelenítéshez biztosítsa a szükséges betűtípusokat, konfigurálja a [font substitution](/slides/hu/nodejs-java/font-substitution/) beállítását, vagy ágyazza be a [fonts](/slides/hu/nodejs-java/embedded-font/) a prezentációba.

**Egy bekezdés használhat több helyesírási nyelvet?**

Igen. Minden nyelvet rendelje egy külön részlethez, ahogyan a többnyelvű bekezdés példában látható.

**Használjam a `setDefaultTextLanguage`‑t vagy a `setLanguageId`‑t?**

Használja a [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-)‑t, ha az újonnan létrehozott szövegekhez alapértelmezett nyelvet szeretne meghatározni. Használja a [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)‑t, ha egy konkrét részletnek explicit helyesírási nyelvre van szüksége, vagy ha egy bekezdésben több nyelvet használ.