---
title: Konfigurace náhrady fontů v prezentacích pomocí JavaScriptu
linktitle: Náhrada fontů
type: docs
weight: 70
url: /cs/nodejs-java/font-substitution/
keywords:
- písmo
- náhradní font
- náhrada fontu
- nahrazení fontu
- nahrazení fontu
- pravidlo náhrady
- pravidlo nahrazení
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Konfigurujte pravidla náhrady fontů a zkontrolujte nahrazené fonty v Aspose.Slides pro Node.js pomocí Javy při vykreslování nebo konverzi prezentací PowerPoint a OpenDocument."
---
## **Přehled**

Náhrada fontů umožňuje Aspose.Slides použít dostupný font místo fontu, který není při vykreslování nebo konverzi prezentace přístupný. Náhrada ovlivňuje výstup vykreslení; nemění font přiřazený k obsahu prezentace.

Můžete definovat, který font se má použít, když je konkrétní font nedostupný, a můžete zkontrolovat náhrady, které Aspose.Slides během vykreslování provede. To pomáhá udržet výstup konzistentní napříč prostředími s různými nainstalovanými fonty.

## **Získání náhrad fontů**

Použijte metodu [FontsManager.getSubstitutions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) k určení, které fonty budou během vykreslení prezentace nahrazeny. Metoda vrací objekty [FontSubstitutionInfo](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsubstitutioninfo/), které uvádějí původní a nahrazené názvy fontů.

Následující příklad v JavaScriptu vypíše všechny náhrady fontů pro prezentaci:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var substitutions = presentation.getFontsManager().getSubstitutions().iterator();
    while (substitutions.hasNext()) {
        var substitution = substitutions.next();
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **Získání náhrad fontů pro vybrané snímky**

Použijte přetížení [FontsManager.getSubstitutions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) s polem indexů snímků, abyste zkontrolovali jen náhrady potřebné k vykreslení konkrétních snímků. To je užitečné, když vykreslujete nebo exportujete část prezentace, provádíte inkrementální kontrolu velké prezentace, vyhledáváte snímky závislé na nedostupných fontech, připravujete minimální balíček fontů pro server nebo kontejner, nebo diagnostikujete rozdíly ve vykreslování bez zpracování nesouvisejících snímků.

Přetížení očekává primitivní Java `int[]`. Vytvořte jej pomocí `java.newArray("int", [...])`; obyčejné pole JavaScriptu se převede na `Integer[]` a neodpovídá tomuto přetížení.

Pole obsahuje jednorozměrné indexy snímků počínaje jedničkou: `1` označuje první snímek. Naopak kolekční přístup [Presentation.getSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/getslides/) používá nulové indexování, takže stejný snímek je přístupný jako `presentation.getSlides().get_Item(0)`. Při tvorbě pole mějte tento rozdíl na paměti, aby nedošlo k chybám o jeden.

Volání přetížení provádějte přes [Presentation.getFontsManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/getfontsmanager/). Vrací pouze náhrady určené při vykreslování vybraných snímků. Každý výsledek je objekt [FontSubstitutionInfo](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsubstitutioninfo/) obsahující původní a nahrazené názvy fontů. Výsledek odráží aktuální prostředí fontů, nastavená pravidla záložních fontů, pravidla náhrad uložená v [FontSubstRuleCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsubstrulecollection/) a [externě načtené fonty](/slides/cs/nodejs-java/custom-font/).

Stejnou náhradu může vyžadovat více než jeden vybraný snímek. Při tvorbě inventáře fontů nebo předletového reportu duplikáty odstraňte. Následující příklad vypíše každou vrácenou náhradu a poté vytvoří seřazený seznam unikátních mapování fontů:

```javascript
var aspose = aspose || {};
const java = require("java");
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var selectedSlides = java.newArray("int", [1, 3, 5]);
    var substitutions = [];
    var substitutionIterator = presentation.getFontsManager().getSubstitutions(selectedSlides).iterator();
    while (substitutionIterator.hasNext()) {
        substitutions.push(substitutionIterator.next());
    }

    console.log("Substitutions for the selected slides:");
    substitutions.forEach(function (substitution) {
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    });

    var preflightEntries = substitutions.map(function (substitution) {
        return substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
    });
    var sortedPreflightEntries = Array.from(new Set(preflightEntries)).sort(function (first, second) {
        return first.localeCompare(second, undefined, { sensitivity: "base" });
    });

    console.log("Deduplicated font preflight report:");
    sortedPreflightEntries.forEach(function (entry) {
        console.log(entry);
    });
} finally {
    presentation.dispose();
}
```

Třída [FontsManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsmanager/) poskytuje obě přetížení. Vyberte si podle rozsahu vykreslovací operace:

| Přetížení | Použijte, když |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) bez argumentů | Potřebujete náhrady pro celou prezentaci. |
| [getSubstitutions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) s Java `int[]` indexů snímků | Potřebujete náhrady pro vybraný rozsah, inkrementální kontrolu nebo částečný export. |

## **Nastavení pravidel náhrady fontů**

Pro určení fontu, který má Aspose.Slides použít, když je zdrojový font nedostupný:

1. Načtěte prezentaci.  
2. Vytvořte definice fontů pro zdrojový a náhradní font.  
3. Vytvořte [FontSubstRule](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsubstrule/) s podmínkou [WhenInaccessible](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsubstcondition/).  
4. Přidejte pravidlo do [FontSubstRuleCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsubstrulecollection/).  
5. Přiřaďte kolekci pomocí metody [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/).  
6. Vykreslete nebo konvertujte prezentaci.

Následující příklad v JavaScriptu nahrazuje `Arial` za `SomeRareFont`, když je `SomeRareFont` nedostupný, a poté vykresluje první snímek pro ověření výsledku. Náhradní font musí být pro Aspose.Slides dostupný.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    var substituteFont = new aspose.slides.FontData("Arial");
    var substitutionRule = new aspose.slides.FontSubstRule(sourceFont, substituteFont, aspose.slides.FontSubstCondition.WhenInaccessible);

    var substitutionRules = new aspose.slides.FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    var image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0);
    try {
        image.save("slide.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Poznámka" %}}
Pro ne podmíněnou změnu fontů používaných v celé prezentaci viz [Font Replacement](/slides/cs/nodejs-java/font-replacement/).
{{% /alert %}}

## **Omezení pro fonty matematických rovnic**

Pravidla náhrady fontů jsou součástí standardního procesu výběru fontu používaného během vykreslování a konverze. Fungují pro běžný text, když Aspose.Slides může nahradit nedostupný font dostupným fontem definovaným pravidlem.

Matematické rovnice v Office Math mají další požadavek. Pokud rovnice používá **Cambria Math**, Aspose.Slides může potřebovat právě tento font k výpočtu a vykreslení rozvržení rovnice. Pravidlo, které nahrazuje jiný matematický font, například **STIX Two Math**, nemůže nahradit **Cambria Math** pro tento účel a vykreslování může stále uvádět, že **Cambria Math** je vyžadován.

Pro vykreslení nebo konverzi takové prezentace zajistěte, aby byl **Cambria Math** dostupný pro Aspose.Slides. Nainstalujte jej v operačním systému nebo jej načtěte jako [externí font](/slides/cs/nodejs-java/custom-font/).

Toto omezení se vztahuje na rozvržení rovnic. Popisovaná pravidla náhrady stále platí pro běžný text prezentace.

## **Často kladené otázky**

**Jaký je rozdíl mezi nahrazením fontu a náhradou fontu?**

[Font replacement](/slides/cs/nodejs-java/font-replacement/) úmyslně mění jeden font na jiný v celé prezentaci. Náhrada fontu vybírá font pro vykreslený výstup, když je splněna nakonfigurovaná podmínka, například když je původní font nedostupný.

**Kdy se pravidla náhrady uplatňují?**

Pravidla se podílejí na [font selection sequence](/slides/cs/nodejs-java/font-selection-sequence/) během vykreslování a konverze. S `WhenInaccessible` se pravidlo použije jen tehdy, když Aspose.Slides nemůže získat přístup ke zdrojovému fontu.

**Co se stane, když chybí font a není nakonfigurováno žádné pravidlo náhrady?**

Aspose.Slides vybere nejbližší dostupný font podle svého procesu výběru fontu. Výsledek závisí na fontech dostupných v běhovém prostředí.

**Mohu načíst externí fonty, aby se zabránilo náhradě?**

Ano. Můžete [load external fonts](/slides/cs/nodejs-java/custom-font/), aby je Aspose.Slides mohl použít během vykreslování a konverze.

**Distribuuje Aspose fonty s knihovnou?**

Ne. Za poskytování fontů a dodržování jejich licencí jste zodpovědní vy.

**Mohou se výsledky náhrady lišit mezi Windows, Linux a macOS?**

Ano. Instalované fonty a umístění vyhledávání fontů se liší podle operačního systému, takže font dostupný na jednom stroji může vyžadovat náhradu na jiném.

**Jak zajistit konzistentní výběr fontů při hromadných konverzích?**

Používejte stejné soubory fontů a jejich verze na každém stroji nebo kontejneru, [načtěte požadované externí fonty](/slides/cs/nodejs-java/custom-font/) a [embed fonts](/slides/cs/nodejs-java/embedded-font/), pokud licence dovolí. Můžete také před exportem zavolat [FontsManager.getSubstitutions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) k identifikaci neočekávaných náhrad.