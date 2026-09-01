---
title: Prezentáció lokalizációjának automatizálása Androidon
linktitle: Prezentáció lokalizálása
type: docs
weight: 100
url: /hu/androidjava/presentation-localization/
keywords:
- nyelv módosítása
- helyesírás-ellenőrzés
- helyesírás-ellenőrzés letiltása
- ellenőrző nyelv
- nyelv azonosító
- többnyelvű szöveg
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Állítsa be a proofing nyelveket PowerPoint és OpenDocument prezentáció szövegeihez Androidon az Aspose.Slides for Android via Java segítségével, beleértve az alapértelmezéseket és a többnyelvű bekezdéseket."
---
## **Áttekintés**

Aspose.Slides for Android via Java lehetővé teszi, hogy egyes szövegrészekhez proofing metaadatokat konfiguráljon. Használja a [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) a proofing nyelv azonosításához, a [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) a helyesírás-ellenőrzés engedélyezéséhez vagy tiltásához, valamint a [IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) a szélesebb körű „nem proof” állapot szabályozásához. Mivel ezek a beállítások a rész szintjén kerülnek alkalmazásra, egy bekezdés több nyelvet és különböző proofing szabályokat tartalmazhat.

Ez a cikk bemutatja, hogyan rendeljen nyelvet a konkrét szöveghez, hogyan állítsa be az alapértelmezett nyelvet az új szöveghez a [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) segítségével, hogyan építsen többnyelvű bekezdéseket, hogyan válasszon a `SpellCheck` és a `ProofDisabled` között, és hogyan őrizze meg a kívánt beállításokat a [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) használata során. Ezek a tulajdonságok metaadatokat tárolnak a prezentációs alkalmazások számára; nem fordítják a szöveget, nem végzik a szótáralapú helyesírás-ellenőrzést, és nem adnak vissza hibás szavakat.

## **Állítsa be a proofing nyelvet a szöveghez**

Hozzon létre vagy töltsön be egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/)-t, érje el a kívánt szövegrészt az [IPortion.getPortionFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iportion/#getPortionFormat--) segítségével, és adja meg a nyelvazonosítóját. Az alábbi példa egy alakzatot hoz létre, a brit angolt állítja be proofing nyelvként, majd az eredményt a [Presentation.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) metódussal menti:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IPortion;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Állítsa be az alapértelmezett nyelvet az új szöveghez**

Használja a [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) metódust annak a proofing nyelvnek a meghatározásához, amelyet az Aspose.Slides az újonnan létrehozott szövegre alkalmaz. Ez a beállítás akkor hasznos, ha a prezentáció nagy része vagy teljes egészében ugyanazt a nyelvet használja. Nem módosítja a már explicit nyelvet felcímkézett szöveg nyelvmetaadatait.

Az alábbi példa egy olyan prezentációt hoz létre, amelyben az új szöveg német proofing szabályokat használ:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ISlide;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Több nyelv használata egy bekezdésben**

Egy [IParagraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraph/) a szövegrészek gyűjteményét tartalmazza. Hozzon létre minden nyelvhez külön [Portion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/portion/) elemet, és állítsa be annak `LanguageId` értékét önállóan.

Ez a példa egy bekezdést hoz létre angol és francia részekkel:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion englishPortion = new Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    Portion frenchPortion = new Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Helyesírás-ellenőrzés engedélyezése vagy tiltása egyedi részeknél**

Az [IPortionFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iportionformat/) örökli az [IBasePortionFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseportionformat/) által definiált közös szövegtulajdonságokat. Egy rész formátumához az [IPortion.getPortionFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iportion/#getPortionFormat--) segítségével férhet hozzá, majd a [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) metódussal szabályozhatja, hogy a prezentációs alkalmazás ellenőrizze-e a helyesírást az adott részben. Az alapértelmezett érték `false`: a `true` engedélyezi a helyesírás-ellenőrzést, míg a `false` tiltja azt.

A beállítás egyedi szövegrészekre vonatkozik. Így egy bekezdés különböző részei eltérő értékeket használhatnak. Az [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) és a `setSpellCheck` egymást kiegészítő célokat szolgálnak: az `setLanguageId` a proofing nyelvet azonosítja, míg a `setSpellCheck` azt határozza meg, hogy a rész számára engedélyezett-e a helyesírás-ellenőrzés.

Az [IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) szintén a proofing-et szabályozza, de a [NullableBool](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/nullablebool/) formájában képviseli a szélesebb „ne bizonyosodjon meg” állapotot. Használja a `setSpellCheck`-et, ha közvetlen Boolean kapcsolót szeretne a helyesírás-ellenőrzéshez. Használja a `setProofDisabled`-et, ha a prezentáció „no‑proof” metaadatait szeretné megőrizni vagy kifejezetten vezérelni, beleértve a `NotDefined` állapotot is. Ha mindkét tulajdonságot beállítja, tartsa konzisztens értékeiket; ne kombinálja a `setSpellCheck(true)`-t a `setProofDisabled(NullableBool.True)`-val.

Ezek a tulajdonságok a PowerPoint és más prezentációs alkalmazások által használt proofing metaadatokat konfigurálják. Az Aspose.Slides nem használja őket szótáralapú helyesírás-ellenőrzéshez, és nem ad vissza hibás szavak listáját.

Az alábbi teljes példa bemutat egy bemeneti prezentáció betöltését, a két részhez eltérő helyesírás-ellenőrzési beállítások és proofing nyelvek hozzárendelését, a mentést, a újbóli megnyitást, valamint a tárolt értékek ellenőrzését:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.IPortion;
import com.aspose.slides.IPortionCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

String inputFile = "spell_check_input.pptx";
String outputFile = "spell_check_settings.pptx";

Presentation sourcePresentation = new Presentation();
try {
    ISlide sourceSlide = sourcePresentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    Portion sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    Portion sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

Presentation presentation = new Presentation(inputFile);
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    IPortion checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    IPortion suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation(outputFile);
try {
    IAutoShape reopenedShape = (IAutoShape) reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    boolean firstPortionStored = storedPortions.getCount() == 2 &&
            "en-US".equals(storedPortions.get_Item(0).getPortionFormat().getLanguageId()) &&
            storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    boolean secondPortionStored = storedPortions.getCount() == 2 &&
            "fr-FR".equals(storedPortions.get_Item(1).getPortionFormat().getLanguageId()) &&
            !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        System.out.println("The proofing settings were stored correctly.");
    } else {
        System.out.println("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

A [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) metódus egyesíti a szomszédos részeket, ha azok formázása megegyezik. Az `SpellCheck` különböző értéke önmagában nem tartja szét ezeket a részeket; az egyesítés után a keletkező rész az első rész `SpellCheck` értékét örökli. Ha a részeknek különböző helyesírás-ellenőrzési beállításokra van szükségük, hívja meg a `joinPortionsWithSameFormatting`-et a beállítások hozzárendelése előtt, vagy vizsgálja meg a keletkező rész határait, és alkalmazza újra a beállításokat. A különböző `LanguageId` értékű részek továbbra is különállóak maradnak, mivel proofing‑nyelvi formázásuk eltér.

## **GYIK**

**Egy nyelvazonosító lefordítja a szöveget?**

Nem. Az [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) a helyesírási és nyelvtani proofing metaadatokat tárolja; nem változtatja meg a szöveg tartalmát. A szöveget külön kell lefordítani, majd minden lefordított részhez állítsa be a megfelelő nyelvazonosítót.

**A proofing nyelv szabályozza a betűtípusokat, elválasztást vagy sortörést?**

Nem. A nyelvazonosító csak proofing célokra szolgál. A szöveg renderelése és elrendezése elsősorban a rendelkezésre álló [fonts](/slides/hu/androidjava/powerpoint-fonts/), az írásrendszer és a szövegkeret beállításai függvénye. A megbízható megjelenítéshez biztosítsa a szükséges betűtípusokat, konfigurálja a [font substitution](/slides/hu/androidjava/font-substitution/) vagy [embed fonts](/slides/hu/androidjava/embedded-font/) opciót a prezentációban.

**Egy bekezdés használhat több proofing nyelvet?**

Igen. Rendeljen minden nyelvet egy külön részhez, ahogy a többnyelvű bekezdés példájában látható.

**Használjam a `setDefaultTextLanguage`-t vagy a `setLanguageId`-t?**

Használja a [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) metódust, ha az újonnan létrehozott szöveghez szeretne alapértelmezett nyelvet beállítani. Használja az [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) metódust, ha egy konkrét résznek explicit proofing nyelvre van szüksége, vagy ha egy bekezdés több nyelvet tartalmaz.