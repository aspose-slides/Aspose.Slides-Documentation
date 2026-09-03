---
title: Vkládání písem do prezentací v JavaScriptu
linktitle: Vložená písma
type: docs
weight: 40
url: /cs/nodejs-java/embedded-font/
keywords:
- přidat písmo
- vložit písmo
- vkládání písem
- získat vložené písmo
- přidat vložené písmo
- odstranit vložené písmo
- komprimovat vložené písmo
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Spravujte vložená písma v PowerPointu pomocí Aspose.Slides pro Node.js přes Java. Přidávejte, získávejte, odstraňujte a komprimujte písma pro zachování vzhledu textu a snížení velikosti souboru."
---
## **Úvod**

Vkládání písem ukládá data písem uvnitř prezentace PowerPoint. Když prohlížeč podporuje vložená písma, může zobrazovat text pomocí těchto písem i v případě, že nejsou nainstalována v cílovém systému. To pomáhá zachovat zalomení řádků, rozestupy textu a rozvržení snímků.

Aspose.Slides pro Node.js přes Java vám umožňuje získávat, přidávat a odstraňovat vložená písma pomocí třídy [FontsManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsmanager/) vrácené metodou [Presentation.getFontsManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/getfontsmanager/). Můžete také zmenšit velikost dat vložených písem odstraněním znaků, které prezentace nepoužívá.

Ukázky níže fungují se soubory PPTX. Před vložením písma se ujistěte, že jeho data písma jsou k dispozici pro Aspose.Slides a že jeho licence umožňuje vkládání.

## **Získání a odstranění vložených písem**

Použijte [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) k vypsání písem uložených v prezentaci. Pro odstranění jednoho předáte písmo z tohoto seznamu metodě [FontsManager.removeEmbeddedFont](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsmanager/removeembeddedfont/), a poté prezentaci uložíte.

Následující příklad vypíše vložená písma v souboru `EmbeddedFonts.pptx` a odstraní Calibri, pokud je přítomen:
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var embeddedFonts = fontsManager.getEmbeddedFonts();

    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log(embeddedFonts[i].getFontName());
    }

    var fontToRemove = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        if (String(embeddedFonts[i].getFontName()).toLowerCase() === "calibri") {
            fontToRemove = embeddedFonts[i];
            break;
        }
    }

    if (fontToRemove !== null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

Odstranění vloženého písma odstraní jeho uložená data; nezmění písmo přiřazené textu. Pokud je písmo nainstalováno v cílovém systému, text jej může stále používat. V opačném případě může vykreslování vyžadovat [náhrada písma](/slides/cs/nodejs-java/font-substitution/), což může ovlivnit rozvržení.

## **Prozkoumání dat písma a oprávnění k vložení**

Použijte třídu [FontsManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsmanager/) k prozkoumání písem před jejich vložením. Zavolejte [FontsManager.getFonts](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsmanager/getfonts/) k získání písem použitých v prezentaci. Pro každé písmo předáte objekt [FontData](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontdata/) a požadovanou hodnotu [FontStyleType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontstyletype/) metodě [FontsManager.getFontBytes](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsmanager/#getFontBytes). Metoda vrátí binární data pro daný styl písma nebo `null`, pokud požadované písmo nebo styl není k dispozici. Nepředávejte výsledek `null` metodě [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), protože tato metoda vyžaduje pole bytů. V Node.js převěďte vrácené pole JavaScriptu na Java pole bytů pomocí `java.newArray` před jeho předáním do `getFontEmbeddingLevel`.

[EmbeddingLevel](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/embeddinglevel/) hlásí omezení vložení uložená v písmu jako sadu příznaků:

- `Installable` umožňuje vložení a trvalou instalaci na jiném systému, pokud to licence písma povoluje.
- `Restricted` zakazuje vložení, pokud není získáno povolení od právního vlastníka písma, když je to jediný příznak povolení použití.
- `PreviewPrint` umožňuje dočasné použití pro prohlížení a tisk; dokument obsahující písmo musí být jen ke čtení.
- `Editable` umožňuje dočasné použití a dovoluje upravovat a ukládat dokument.
- `NoSubsetting` je další omezení, které zakazuje vložení jen podmnožiny glifů. Při přítomnosti tohoto příznaku vložte všechny znaky.
- `BitmapOnly` je další omezení, které umožňuje vložit jen bitmapové verze, nikoli data obrysů. Pokud písmo nemá bitmapové verze, nemůže být vloženo.

Prvních čtyři hodnoty popisují povolení k použití, zatímco `NoSubsetting` a `BitmapOnly` lze s nimi kombinovat. Kontrolujte modifikátory pomocí bitových operací. Protože `Installable` je nula, maskujte bity povolení k použití a porovnávejte výsledek s `Installable` místo kontrolování jako příznaku. Současná písma by měla nastavit nejvýše jeden bit povolení k použití. Pro kompatibilitu se staršími písmy, která nastaví více než jeden, níže uvedený pomocník vybírá nejméně restriktivní povolení: `Editable`, pak `PreviewPrint`, pak `Restricted`.

Následující příklad prověřuje běžná, tučná, kurzívní a tučně kurzívní data dostupná pro každé písmo vrácené metodou `getFonts`. Přeskakuje nedostupné styly, omezená písma, písma pouze bitmapová, písma omezená na prohlížení a tisk, protože výstup zůstává editovatelný, a písma, která jsou již vložena. Pokud má nějaký dostupný styl `NoSubsetting`, vloží všechny znaky pro tuto rodinu písem.
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

function getUsagePermission(level) {
    var permissionMask = aspose.slides.EmbeddingLevel.Restricted | aspose.slides.EmbeddingLevel.PreviewPrint | aspose.slides.EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & aspose.slides.EmbeddingLevel.Editable) !== 0) {
        return aspose.slides.EmbeddingLevel.Editable;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.PreviewPrint) !== 0) {
        return aspose.slides.EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.Restricted) !== 0) {
        return aspose.slides.EmbeddingLevel.Restricted;
    }

    return aspose.slides.EmbeddingLevel.Installable;
}

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    var embeddedFontNames = new Set();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    var fontsToEmbed = [];
    var embeddingRules = [];
    var fonts = fontsManager.getFonts();
    for (var i = 0; i < fonts.length; i++) {
        var font = fonts[i];
        var fontName = String(font.getFontName());
        if (embeddedFontNames.has(fontName.toLowerCase())) {
            console.log(fontName + ": already embedded.");
            continue;
        }

        var hasAvailableData = false;
        var allAvailableStylesCanBeEmbedded = true;
        var previewPrintOnly = false;
        var requiresFullFont = false;

        for (var j = 0; j < fontStyles.length; j++) {
            var fontStyle = fontStyles[j];
            var fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes === null) {
                console.log(fontName + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            var fontByteValues = Array.from(fontBytes);
            var javaFontBytes = java.newArray("byte", fontByteValues);
            var embeddingLevel = fontsManager.getFontEmbeddingLevel(javaFontBytes, fontName);
            var usagePermission = getUsagePermission(embeddingLevel);
            var noSubsetting = (embeddingLevel & aspose.slides.EmbeddingLevel.NoSubsetting) !== 0;
            var bitmapOnly = (embeddingLevel & aspose.slides.EmbeddingLevel.BitmapOnly) !== 0;

            requiresFullFont = requiresFullFont || noSubsetting;
            previewPrintOnly = previewPrintOnly || usagePermission === aspose.slides.EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded = allAvailableStylesCanBeEmbedded && usagePermission !== aspose.slides.EmbeddingLevel.Restricted && !bitmapOnly;

            console.log(fontName + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            console.log(fontName + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            console.log(fontName + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            console.log(fontName + ": skipped because this example produces an editable presentation.");
        } else {
            var rule = requiresFullFont ? aspose.slides.EmbedFontCharacters.All : aspose.slides.EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.push(font);
            embeddingRules.push(rule);
        }
    }

    for (var i = 0; i < fontsToEmbed.length; i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed[i], embeddingRules[i]);
    }

    presentation.save("WithAuditedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Toto prozkoumání hlásí omezení zakódovaná v každém souboru písma. Neuděluje licenci, neprokazuje, že jste písmo získali legálně, ani nenahrazuje kontrolu licenční smlouvy písma před distribucí vložené kopie.

## **Přidání vložených písem**

Použijte [FontsManager.addEmbeddedFont](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsmanager/addembeddedfont/) k vložení písma. Jeho přetížení přijímají buď objekt [FontData](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontdata/), nebo pole bytů obsahující data písma. [EmbedFontCharacters](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/embedfontcharacters/) určuje, které znaky jsou zahrnuty:

- `All` vloží všechny znaky písma. Použijte tuto možnost, když příjemci potřebují upravovat prezentaci a zadávat nový text.
- `OnlyUsed` vloží jen znaky použité v prezentaci, aby se zmenšila velikost souboru. Zvolte tuto možnost pro dokončenou prezentaci určenou hlavně k prohlížení.

Následující příklad používá [FontsManager.getFonts](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsmanager/getfonts/) k získání písem použitých v souboru `Fonts.pptx` a vloží ta, která ještě nejsou vložena. Písma k přidání musí být k dispozici na stroji, na kterém se kód spouští. Existující vložená písma zachovávají své aktuální sady znaků.
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var allFonts = fontsManager.getFonts();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    var embeddedFontNames = new Set();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    for (var i = 0; i < allFonts.length; i++) {
        var font = allFonts[i];
        var fontName = String(font.getFontName()).toLowerCase();
        if (!embeddedFontNames.has(fontName)) {
            var hasAvailableData = false;
            for (var j = 0; j < fontStyles.length; j++) {
                if (fontsManager.getFontBytes(font, fontStyles[j]) !== null) {
                    hasAvailableData = true;
                    break;
                }
            }

            if (hasAvailableData) {
                fontsManager.addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
                embeddedFontNames.add(fontName);
            } else {
                console.log(font.getFontName() + ": skipped because its font data is unavailable.");
            }
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Komprese vložených písem**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compress/compressembeddedfonts/) snižuje data vložených písem odstraněním nepoužitých znaků. Funguje na písmích, která jsou již vložena, takže snížení velikosti závisí na tom, kolik nepoužitých dat písma prezentace obsahuje.

Následující příklad komprimuje písma v souboru `EmbeddedFonts.pptx` a výsledek uloží jako samostatný soubor:
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Uchovejte původní soubor, pokud příjemci budou později potřebovat přidávat text. Znaky odstraněné během komprese už nebudou k dispozici ve vloženém písmu, i když jste původně vložili všechny znaky.

## **FAQ**

**Jak mohu zkontrolovat, zda bude vložené písmo během vykreslování stále nahrazeno?**

V prostředí, ve kterém prezentaci vykreslujete, zavolejte [FontsManager.getSubstitutions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/), abyste zjistili, která písma Aspose.Slides nahradí. Také zkontrolujte nastavení [náhrada písma](/slides/cs/nodejs-java/font-substitution/) a pravidla [fallback písma](/slides/cs/nodejs-java/fallback-font/). Náhradní písmo řeší chybějící znaky, takže vložení písma nevyřeší znaky, které samotné písmo neobsahuje.

**Mám vkládat běžná písma jako Arial a Calibri?**

Rozhodnutí by mělo vycházet z cílového prostředí. Pokud jsou požadovaná písma k dispozici na každém počítači, který prezentaci otevírá nebo vykresluje, jejich vložení může přidat zbytečnou velikost souboru. Pokud příjemci nebo servery mohou tato písma postrádat, jejich vložení může pomoci zachovat zamýšlený vzhled, pokud to jejich licence umožňuje.