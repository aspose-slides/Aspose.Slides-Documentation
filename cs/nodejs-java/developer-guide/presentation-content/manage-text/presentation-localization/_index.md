---
title: Automatizujte lokalizaci prezentace v JavaScriptu
linktitle: Lokalizace prezentace
type: docs
weight: 100
url: /cs/nodejs-java/presentation-localization/
keywords:
- změna jazyka
- kontrola pravopisu
- potlačení kontroly pravopisu
- jazyk korektury
- identifikátor jazyka
- vícejazyčný text
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Nastavte jazyky korektury pro text v prezentacích PowerPoint a OpenDocument v JavaScriptu pomocí Aspose.Slides, včetně výchozích a vícejazyčných odstavců."
---
## **Přehled**

Aspose.Slides pro Node.js pomocí Javy vám umožňuje konfigurovat metadata korektury pro jednotlivé textové úseky. Použijte [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) k určení jazyka korektury, [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) k povolení nebo potlačení kontrol pravopisu a [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) k řízení širšího stavu „neprovádět korekturu“. Protože jsou tato nastavení aplikována na úrovni úseku, jeden odstavec může obsahovat více jazyků a různé pravidla korektury.

Tento článek vysvětluje, jak přiřadit jazyk konkrétnímu textu, nastavit výchozí jazyk pro nový text pomocí [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), vytvořit vícejazyčné odstavce, zvolit mezi `SpellCheck` a `ProofDisabled` a zachovat zamýšlená nastavení při použití [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--). Tyto vlastnosti ukládají metadata pro prezentační aplikace; nepřekládají text, neprovádějí kontrolu pravopisu založenou na slovníku ani nevracejí nesprávně napsaná slova.

## **Nastavení jazyka korektury pro text**

Vytvořte nebo načtěte [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/), přístup k požadovanému textovému úseku prostřednictvím [Portion.getPortionFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portion/#getPortionFormat--) a přiřaďte jeho identifikátor jazyka. Následující příklad vytvoří tvar, nastaví britskou angličtinu jako jazyk korektury a uloží výsledek pomocí [Presentation.save](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-):

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

## **Nastavení výchozího jazyka pro nový text**

Použijte [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) k určení jazyka korektury, který Aspose.Slides přiřadí nově vytvořenému textu. Toto nastavení je užitečné, když většina nebo veškerý nový text v prezentaci používá stejný jazyk. Nemění metadata jazyka textu, který již má explicitně nastavený jazyk.

Následující příklad vytvoří prezentaci, kde nový text používá pravidla korektury pro němčinu:

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

## **Použití více jazyků v jednom odstavci**

[Paragraph](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraph/) obsahuje kolekci textových úseků. Vytvořte samostatný [Portion](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portion/) pro každý jazyk a nastavte jeho `LanguageId` nezávisle.

Tento příklad vytvoří jeden odstavec s anglickými a francouzskými úseky:

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

## **Povolení nebo potlačení kontroly pravopisu pro jednotlivé úseky**

[PortionFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portionformat/) dědí společné textové vlastnosti definované v [BasePortionFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseportionformat/). Přístup k formátu úseku získáte pomocí [Portion.getPortionFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portion/#getPortionFormat--) a použijte [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) k řízení, zda prezentační aplikace může provádět kontrolu pravopisu pro tento úsek. Výchozí hodnota je `false`: `true` povolí kontrolu pravopisu, zatímco `false` ji potlačuje.

Nastavení se vztahuje na jednotlivé textové úseky. Různé úseky ve stejném odstavci tak mohou používat odlišné hodnoty. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) a `setSpellCheck` slouží doplňujícím účelům: `setLanguageId` určuje jazyk korektury, zatímco `setSpellCheck` rozhoduje, zda jsou pro úsek povoleny kontroly pravopisu.

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) také řídí korekturu, ale představuje širší stav „neprovádět korekturu“ jako [NullableBool](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/nullablebool/). Použijte `setSpellCheck`, když potřebujete přímý přepínač Boolean specificky pro kontrolu pravopisu. Použijte `setProofDisabled`, když potřebujete zachovat nebo explicitně řídit metadata prezentace o neprovedení korektury, včetně jejího stavu `NotDefined`. Pokud nastavíte obě vlastnosti, zachovejte jejich hodnoty konzistentní; nekomponujte `setSpellCheck(true)` s `setProofDisabled(NullableBool.True)`.

Tyto vlastnosti konfigují metadata korektury používaná v PowerPointu a dalších prezentačních aplikacích. Aspose.Slides je nepoužívá k provádění kontroly pravopisu založené na slovníku ani nevrací seznam nesprávně napsaných slov.

Následující kompletní příklad vytvoří vstupní prezentaci, načte ji, přiřadí různá nastavení kontroly pravopisu a jazyky korektury dvěma úsekům ve stejném odstavci, uloží výsledek, znovu jej otevře a ověří uložené hodnoty:

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

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--) spojuje sousední úseky, které mají stejné formátování. Rozdíl pouze v `SpellCheck` nezaručuje, že úseky zůstanou oddělené; po jejich sloučení výsledný úsek si zachová hodnotu `SpellCheck` prvního úseku. Pokud úseky vyžadují různá nastavení kontroly pravopisu, zavolejte `joinPortionsWithSameFormatting` před přiřazením těchto nastavení, nebo prozkoumejte hranice výsledného úseku a nastavení následně znovu aplikujte. Úseky s odlišnými hodnotami `LanguageId` zůstávají oddělené, protože se liší formátováním jazyka korektury.

## **Často kladené otázky**

**Překládá ID jazyka text?**

Ne. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) ukládá metadata korektury pro pravopis a gramatiku; nemění obsah textu. Přeložte text zvlášť a poté nastavte odpovídající identifikátor jazyka pro každý přeložený úsek.

**Řídí jazyk korektury písma, dělení slov nebo zalamování řádků?**

Ne. Identifikátor jazyka slouží ke korektuře. Vykreslování textu a rozvržení hlavně závisí na dostupných [fonts](/slides/cs/nodejs-java/powerpoint-fonts/), na písmu, na systému psaní a na nastaveních textového rámce. Pro spolehlivé vykreslení zajistěte požadovaná písma, nakonfigurujte [font substitution](/slides/cs/nodejs-java/font-substitution/), nebo [embed fonts](/slides/cs/nodejs-java/embedded-font/) v prezentaci.

**Může jeden odstavec používat několik jazyků korektury?**

Ano. Přiřaďte každý jazyk k samostatnému úseku, jak je ukázáno v příkladu vícejazyčného odstavce.

**Mám použít `setDefaultTextLanguage` nebo `setLanguageId`?**

Použijte [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), když chcete výchozí nastavení pro nově vytvořený text. Použijte [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-), když konkrétní úsek potřebuje explicitní jazyk korektury nebo když odstavec obsahuje více jazyků.