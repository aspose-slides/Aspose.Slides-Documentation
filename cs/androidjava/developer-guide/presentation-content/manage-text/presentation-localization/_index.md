---
title: Automatizujte lokalizaci prezentací na Androidu
linktitle: Lokalizace prezentací
type: docs
weight: 100
url: /cs/androidjava/presentation-localization/
keywords:
- změna jazyka
- kontrola pravopisu
- potlačení kontroly pravopisu
- jazyk proofingu
- identifikátor jazyka
- vícejazykový text
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Nastavte jazyky proofingu pro text prezentací PowerPoint a OpenDocument na Androidu pomocí Aspose.Slides pro Android přes Java, včetně výchozích hodnot a vícejazykových odstavců."
---
## **Přehled**

Aspose.Slides pro Android přes Java vám umožňuje konfigurovat metadata proofingu pro jednotlivé textové části. Použijte [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) k určení jazyka proofingu, [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) k povolení nebo potlačení kontrol pravopisu a [IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) ke kontrole širšího stavu „neprovádět proof“. Protože jsou tato nastavení aplikována na úrovni části, jeden odstavec může obsahovat více jazyků a různé pravidla proofingu.

Tento článek vysvětluje, jak přiřadit jazyk konkrétnímu textu, nastavit výchozí jazyk pro nový text pomocí [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), vytvořit vícejazykové odstavce, zvolit mezi `SpellCheck` a `ProofDisabled` a zachovat zamýšlená nastavení při použití [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--). Tyto vlastnosti ukládají metadata pro prezentační aplikace; nepřekládají text, neprovádějí pravopisnou kontrolu založenou na slovníku ani nevracejí nesprávně napsaná slova.

## **Nastavení jazyka proofingu pro text**

Vytvořte nebo načtěte [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/), přistupte k požadované textové části pomocí [IPortion.getPortionFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iportion/#getPortionFormat--), a přiřaďte její identifikátor jazyka. Následující příklad vytvoří tvar, nastaví britskou angličtinu jako jazyk proofingu a uloží výsledek pomocí [Presentation.save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-):

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

## **Nastavení výchozího jazyka pro nový text**

Použijte [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), abyste určili jazyk proofingu, který Aspose.Slides přiřadí nově vytvořenému textu. Toto nastavení je užitečné, když většina nebo veškerý nový text v prezentaci používá stejný jazyk. Nemění metadata jazyka u textu, který již má explicitně nastavený jazyk.

Následující příklad vytvoří prezentaci, jejíž nový text používá německá pravidla proofingu:

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

## **Použití více jazyků v jednom odstavci**

[IParagraph](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iparagraph/) obsahuje kolekci textových částí. Vytvořte samostatnou [Portion](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/portion/) pro každý jazyk a nastavte jeho `LanguageId` nezávisle.

Následující příklad vytvoří jeden odstavec s anglickými a francouzskými částmi:

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

## **Povolení nebo potlačení kontroly pravopisu pro jednotlivé části**

[IPortionFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iportionformat/) dědí společné textové vlastnosti definované v [IBasePortionFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibaseportionformat/). Přistupujte k formátu části přes [IPortion.getPortionFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iportion/#getPortionFormat--) a použijte [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-), abyste řídili, zda prezentační aplikace může provádět kontrolu pravopisu pro danou část. Výchozí hodnota je `false`: `true` povolí kontrolu pravopisu, zatímco `false` ji potlačí.

Nastavení se vztahuje na jednotlivé textové části. Různé části ve stejném odstavci tak mohou používat odlišné hodnoty. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) a `setSpellCheck` slouží doplňujícím způsobem: `setLanguageId` určuje jazyk proofingu, zatímco `setSpellCheck` stanoví, zda jsou pro část povoleny kontroly pravopisu.

[IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) také řídí proofing, ale představuje širší stav „neprovádět proof“ jako [NullableBool](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/nullablebool/). Použijte `setSpellCheck`, pokud potřebujete přímý přepínač typu Boolean speciálně pro kontroly pravopisu. Použijte `setProofDisabled`, pokud potřebujete zachovat nebo explicitně řídit metadata o neprovádění proof v prezentaci, včetně jejího stavu `NotDefined`. Pokud nastavíte obě vlastnosti, udržujte jejich hodnoty konzistentní; neprovádějte kombinaci `setSpellCheck(true)` s `setProofDisabled(NullableBool.True)`.

Tyto vlastnosti konfigurovají metadata proofingu používaná v PowerPointu a dalších prezentačních aplikacích. Aspose.Slides je nepoužívá k provádění pravopisné kontroly založené na slovníku ani nevrací seznam nesprávně napsaných slov.

Následující kompletní příklad vytvoří vstupní prezentaci, načte ji, přiřadí různé nastavení kontroly pravopisu a jazyky proofingu dvěma částem ve stejném odstavci, uloží výsledek, znovu jej otevře a ověří uložené hodnoty:

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

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) spojuje sousední části, které mají stejné formátování. Pouhý rozdíl v `SpellCheck` neudrží takové části oddělené; po jejich sloučení si výsledná část zachová hodnotu `SpellCheck` první části. Pokud části potřebují odlišná nastavení kontroly pravopisu, zavolejte `joinPortionsWithSameFormatting` před přiřazením těchto nastavení, nebo prozkoumejte hranice výsledných částí a po sloučení nastavení znovu aplikujte. Části s odlišnými hodnotami `LanguageId` zůstávají oddělené, protože se liší formátováním jazyka proofingu.

## **Často kladené otázky**

**Překládá ID jazyka text?**

Ne. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) ukládá metadata proofingu pro pravopis a gramatiku; nemění obsah textu. Přeložte text samostatně a poté nastavte vhodný identifikátor jazyka pro každou přeloženou část.

**Řídí jazyk proofingu fonty, dělení slov nebo zalamování řádků?**

Ne. Identifikátor jazyka slouží pro proofing. Vykreslování a rozvržení textu závisí především na dostupných [fontech](/slides/cs/androidjava/powerpoint-fonts/), písmu, a nastaveních textového rámce. Pro spolehlivé vykreslování poskytněte požadované fonty, nakonfigurujte [náhradu fontů](/slides/cs/androidjava/font-substitution/), nebo [vložené fonty](/slides/cs/androidjava/embedded-font/) v prezentaci.

**Může jeden odstavec používat několik jazyků proofingu?**

Ano. Přiřaďte každý jazyk k samostatné části, jak je ukázáno v příkladu vícejazykového odstavce.

**Mám použít `setDefaultTextLanguage` nebo `setLanguageId`?**

Použijte [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), pokud chcete výchozí jazyk pro nově vytvořený text. Použijte [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), pokud konkrétní část potřebuje explicitní jazyk proofingu nebo když odstavec obsahuje více jazyků.