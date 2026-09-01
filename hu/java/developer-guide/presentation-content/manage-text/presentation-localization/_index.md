---
title: Prezentációk lokalizációjának automatizálása Java-ban
linktitle: Prezentáció lokalizáció
type: docs
weight: 100
url: /hu/java/presentation-localization/
keywords:
- nyelv módosítása
- helyesírás-ellenőrzés
- helyesírás-ellenőrzés letiltása
- lektorálási nyelv
- nyelvi azonosító
- többnyelvű szöveg
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Állítsa be a lektorálási nyelveket a PowerPoint és OpenDocument prezentációs szöveghez Java-ban az Aspose.Slides segítségével, beleértve az alapértelmezéseket és a többnyelvű bekezdéseket."
---
## **Áttekintés**

Az Aspose.Slides for Java lehetővé teszi, hogy egyedi szövegrészekhez konfigurálja a lektorálási metaadatokat. Használja a [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) metódust a lektorálási nyelv azonosításához, a [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) metódust a helyesírás-ellenőrzés engedélyezéséhez vagy letiltásához, valamint a [IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) metódust a szélesebb körű „ne ellenőrizze” állapot vezérléséhez. Mivel ezek a beállítások a rész szintjén kerülnek alkalmazásra, egy bekezdés több nyelvet és különböző lektorálási szabályokat is tartalmazhat.

Ez a cikk bemutatja, hogyan lehet egy nyelvet hozzárendelni egy adott szöveghez, hogyan állítsa be az újonnan létrehozott szöveg alapértelmezett nyelvét a [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) metódussal, hogyan építsen fel többnyelvű bekezdéseket, hogyan válasszon a `SpellCheck` és a `ProofDisabled` között, valamint hogyan őrizze meg a kívánt beállításokat a [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) használata során. Ezek a tulajdonságok metaadatokat tárolnak a bemutatóalkalmazások számára; nem fordítják le a szöveget, nem hajtanak végre szótári alapú helyesírás-ellenőrzést, és nem adnak vissza helytelenül írt szavakat.

## **A lektorálási nyelv beállítása szöveghez**

Hozzon létre vagy töltsön be egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) objektumot, érje el a kívánt szövegrészt a [IPortion.getPortionFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iportion/#getPortionFormat--) metódussal, és adja meg a nyelvi azonosítót. Az alábbi példa egy alakzatot hoz létre, brit angolt állít be lektorálási nyelvként, és elmenti az eredményt a [Presentation.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#save-java.lang.String-int-) metódussal:

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

## **Alapértelmezett nyelv beállítása új szöveghez**

Használja a [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) metódust annak a lektorálási nyelvnek a megadásához, amelyet az Aspose.Slides az újonnan létrehozott szöveghez rendel. Ez a beállítás akkor hasznos, ha a bemutatóban a legtöbb vagy az összes új szöveg ugyanazt a nyelvet használja. Nem változtatja meg azon szövegek nyelvi metaadatait, amelyek már rendelkeznek explicit nyelvi beállítással.

Az alábbi példa egy olyan prezentációt hoz létre, amelynek új szövege német lektorálási szabályokat követ:

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

Egy [IParagraph](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraph/) a szövegrészek gyűjteményét tartalmazza. Hozzon létre minden nyelvhez egy külön [Portion](https://reference.aspose.com/slides/hu/java/com.aspose.slides/portion/) elemet, és állítsa be önállóan a `LanguageId` tulajdonságot.

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

## **Helyesírás-ellenőrzés engedélyezése vagy letiltása egyedi részeknél**

Az [IPortionFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iportionformat/) örökli a [IBasePortionFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseportionformat/) által definiált közös szövegtulajdonságokat. Egy rész formátumához a [IPortion.getPortionFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iportion/#getPortionFormat--) metódussal férhet hozzá, és a [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) metódussal vezérelheti, hogy a bemutatóalkalmazás ellenőrizze-e a helyesírást az adott rész számára. Az alapértelmezett érték `false`: `true` engedélyezi a helyesírás-ellenőrzést, míg `false` letiltja azt.

A beállítás egyedi szövegrészekre vonatkozik. Így ugyanabban a bekezdésben lévő különböző részek eltérő értékeket használhatnak. Az [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) és a `setSpellCheck` egymást kiegészítő célt szolgálnak: a `setLanguageId` azonosítja a lektorálási nyelvet, a `setSpellCheck` pedig meghatározza, hogy a részhez engedélyezett-e a helyesírás-ellenőrzés.

Az [IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) szintén a lektorálást szabályozza, de a szélesebb körű „ne ellenőrizze” állapotot egy [NullableBool](https://reference.aspose.com/slides/hu/java/com.aspose.slides/nullablebool/) értékkel reprezentálja. Használja a `setSpellCheck`-et, ha közvetlen Boolean kapcsolóra van szüksége kifejezetten a helyesírás-ellenőrzéshez. Használja a `setProofDisabled`-et, ha meg szeretné őrizni vagy kifejezetten szabályozni szeretné a prezentáció „nincs lektorálás” metaadatait, beleértve a `NotDefined` állapotot is. Ha mindkét tulajdonságot beállítja, tartsa konzisztens értékeiket; ne kombinálja a `setSpellCheck(true)`-t a `setProofDisabled(NullableBool.True)`-val.

Ezek a tulajdonságok a PowerPoint és más bemutatóalkalmazások által használt lektorálási metaadatokat konfigurálják. Az Aspose.Slides nem használja őket szótári alapú helyesírás-ellenőrzés futtatására vagy a hibás szavak listájának visszaadására.

Az alábbi teljes példa egy bemeneti prezentációt hoz létre, betölti, különböző helyesírás-ellenőrzési beállításokat és lektorálási nyelveket rendel két részhez ugyanabban a bekezdésben, elmenti az eredményt, újra megnyitja, és ellenőrzi a tárolt értékeket:

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

A [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) összevonja a szomszédos részeket, ha azok formázása megegyezik. A `SpellCheck` értékének különbözősége önmagában nem akadályozza meg az ilyen részek egyesülését; az egyesülés után az eredményül kapott rész megtartja az első rész `SpellCheck` értékét. Ha a részeknek eltérő helyesírás-ellenőrzési beállításokra van szükségük, hívja meg a `joinPortionsWithSameFormatting` metódust a beállítások hozzárendelése előtt, vagy ellenőrizze az eredményül kapott rész határait, és alkalmazza újra a beállításokat. A különböző `LanguageId` értékekkel rendelkező részek továbbra is különállóak maradnak, mivel a lektorálási nyelv formázása eltérő.

## **GYIK**

**Egy nyelvi azonosító lefordítja a szöveget?**

Nem. Az [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) helyesírás- és nyelvtani metaadatokat tárol, de nem módosítja a szöveg tartalmát. A szöveget külön kell lefordítani, majd a megfelelő nyelvi azonosítót beállítani az egyes lefordított részekhez.

**A lektorálási nyelv befolyásolja a betűtípusokat, elválasztást vagy sortörést?**

Nem. A nyelvi azonosító csak lektorálásra szolgál. A szöveg megjelenítését és elrendezését elsősorban a rendelkezésre álló [fonts](/slides/hu/java/powerpoint-fonts/), az írásrendszer és a szövegkeret beállításai határozzák meg. A megbízható megjelenéshez biztosítsa a szükséges betűtípusokat, konfigurálja a [font substitution](/slides/hu/java/font-substitution/) beállítást, vagy ágyazza be a betűtípusokat a [embed fonts](/slides/hu/java/embedded-font/) útmutató szerint.

**Használhat egy bekezdés több lektorálási nyelvet?**

Igen. Rendeljen minden nyelvet egy külön részhez, ahogy a többnyelvű bekezdés példájában látható.

**A `setDefaultTextLanguage` vagy a `setLanguageId` a megfelelő?**

Használja a [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) metódust, ha az újonnan létrehozott szövegre alapértelmezett nyelvet szeretne beállítani. Használja az [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) metódust, ha egy adott résznek explicit lektorálási nyelvre van szüksége, vagy ha egy bekezdés több nyelvet tartalmaz.