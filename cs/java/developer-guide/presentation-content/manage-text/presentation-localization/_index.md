---
title: Automatizace lokalizace prezentace v Javě
linktitle: Lokalizace prezentace
type: docs
weight: 100
url: /cs/java/presentation-localization/
keywords:
- změna jazyka
- kontrola pravopisu
- potlačení kontroly pravopisu
- jazyk revize
- identifikátor jazyka
- vícejazyčný text
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Nastavte jazyky revize pro text prezentací PowerPoint a OpenDocument v Javě pomocí Aspose.Slides, včetně výchozích hodnot a vícejazyčných odstavců."
---
## **Přehled**

Aspose.Slides for Java umožňuje konfigurovat metadata revize pro jednotlivé úseky textu. Použijte [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) k určení jazyka revize, [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) k povolení nebo potlačení kontroly pravopisu a [IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) k řízení obecnějšího stavu „neprovádět revizi“. Protože jsou tato nastavení aplikována na úrovni úseku, může jeden odstavec obsahovat více jazyků a různá pravidla revize.

Tento článek vysvětluje, jak přiřadit jazyk konkrétnímu textu, nastavit výchozí jazyk pro nový text pomocí [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), vytvořit vícejazyčné odstavce, zvolit mezi `SpellCheck` a `ProofDisabled` a zachovat zamýšlená nastavení při použití [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--). Tyto vlastnosti ukládají metadata pro prezentační aplikace; neprovádějí překlad textu, kontrolu pravopisu na základě slovníku ani nevracejí nesprávně napsaná slova.

## **Nastavení jazyka revize pro text**

Vytvořte nebo načtěte [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/), získejte požadovaný úsek textu pomocí [IPortion.getPortionFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iportion/#getPortionFormat-- ) a přiřaďte jeho identifikátor jazyka. Následující příklad vytvoří tvar, nastaví britskou angličtinu jako jazyk revize a uloží výsledek pomocí [Presentation.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#save-java.lang.String-int-):

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

Použijte [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) k určení jazyka revize, který Aspose.Slides přiřadí nově vytvořenému textu. Toto nastavení je užitečné, když většina nebo veškerý nový text v prezentaci používá stejný jazyk. Nemění metadata jazyka textu, který již má explicitně nastavený jazyk.

Následující příklad vytvoří prezentaci, jejíž nový text používá německá pravidla revize:

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

[IParagraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraph/) obsahuje kolekci úseků textu. Vytvořte samostatný [Portion](https://reference.aspose.com/slides/cs/java/com.aspose.slides/portion/) pro každý jazyk a nastavte jeho `LanguageId` nezávisle.

Tento příklad vytvoří jeden odstavec s úseky v angličtině a francouzštině:

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

## **Povolení nebo potlačení kontroly pravopisu pro jednotlivé úseky**

[IPortionFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iportionformat/) dědí společné textové vlastnosti definované v [IBasePortionFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseportionformat/). Získejte formát úseku pomocí [IPortion.getPortionFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iportion/#getPortionFormat--) a použijte [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) k řízení, zda prezentační aplikace může provádět kontrolu pravopisu pro daný úsek. Výchozí hodnota je `false`: `true` povolí kontrolu pravopisu, zatímco `false` ji potlačí.

Nastavení se vztahuje na jednotlivé úseky textu. Různé úseky ve stejném odstavci tak mohou mít různé hodnoty. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) a `setSpellCheck` mají doplňující účely: `setLanguageId` určuje jazyk revize, zatímco `setSpellCheck` určuje, zda jsou pro úsek povoleny kontroly pravopisu.

[IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) také řídí revizi, ale představuje širší stav „neprovádět revizi“ jako [NullableBool](https://reference.aspose.com/slides/cs/java/com.aspose.slides/nullablebool/). Použijte `setSpellCheck`, kdy potřebujete přímý Boolean přepínač specificky pro kontroly pravopisu. Použijte `setProofDisabled`, když potřebujete zachovat nebo explicitně řídit metadata prezentace pro „neprovádět revizi“, včetně jejího stavu `NotDefined`. Pokud nastavíte obě vlastnosti, zachovejte jejich hodnoty konzistentní; nekombinujte `setSpellCheck(true)` s `setProofDisabled(NullableBool.True)`.

Tyto vlastnosti konfigurovat metadata revize používaná v PowerPointu a dalších prezentačních aplikacích. Aspose.Slides je nepoužívá k provádění slovníkových kontrol pravopisu ani k vracení seznamu chybně napsaných slov.

Následující kompletní příklad vytvoří vstupní prezentaci, načte ji, přiřadí různé nastavení kontroly pravopisu a jazyky revize dvěma úsekům ve stejném odstavci, uloží výsledek, znovu jej otevře a ověří uložené hodnoty:

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

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) spojuje sousední úseky, které mají stejné formátování. Rozdíl pouze v `SpellCheck` nezabrání sloučení takových úseků; po sloučení si výsledný úsek ponechá hodnotu `SpellCheck` prvního úseku. Pokud úseky potřebují odlišná nastavení kontroly pravopisu, zavolejte `joinPortionsWithSameFormatting` před přiřazením těchto nastavení, nebo po sloučení zkontrolujte hranice výsledných úseků a nastavení znovu aplikujte. Úseky s odlišnými hodnotami `LanguageId` zůstávají oddělené, protože se liší jejich formátování jazyka revize.

## **Často kladené otázky**

**Překládá ID jazyka text?**

Ne. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) ukládá metadata revize pro pravopis a gramatiku; nemění obsah textu. Text přeložte samostatně a poté nastavte vhodný identifikátor jazyka pro každý přeložený úsek.

**Řídí jazyk revize písma, dělení slov nebo zalamování řádků?**

Ne. Identifikátor jazyka slouží jen k revizi. Vykreslování textu a rozvržení jsou primárně závislé na dostupných [fonts](/slides/cs/java/powerpoint-fonts/), systému psaní a nastaveních textového rámce. Pro spolehlivé vykreslování zajistěte potřebná písma, nakonfigurujte [font substitution](/slides/cs/java/font-substitution/) nebo [embed fonts](/slides/cs/java/embedded-font/) v prezentaci.

**Může jeden odstavec používat několik jazyků revize?**

Ano. Přiřaďte každý jazyk k samostatnému úseku, jak ukazuje příklad vícejazyčného odstavce.

**Mám použít `setDefaultTextLanguage` nebo `setLanguageId`?**

Použijte [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), když chcete nastavit výchozí jazyk pro nově vytvořený text. Použijte [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), když konkrétní úsek potřebuje explicitní jazyk revize nebo když odstavec obsahuje více jazyků.