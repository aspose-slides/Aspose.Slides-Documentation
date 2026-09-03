---
title: Inbädda teckensnitt i presentationer i JavaScript
linktitle: Inbäddade teckensnitt
type: docs
weight: 40
url: /sv/nodejs-java/embedded-font/
keywords:
- lägga till teckensnitt
- inbädda teckensnitt
- inbäddning av teckensnitt
- hämta inbäddat teckensnitt
- lägga till inbäddat teckensnitt
- ta bort inbäddat teckensnitt
- komprimera inbäddat teckensnitt
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Hantera inbäddade teckensnitt i PowerPoint med Aspose.Slides för Node.js via Java. Lägg till, hämta, ta bort och komprimera teckensnitt för att bevara textens utseende och minska filstorleken."
---
## **Introduktion**

Inbäddning av teckensnitt lagrar teckensnittsdata i en PowerPoint-presentation. När en visare stöder inbäddade teckensnitt kan den visa text med dessa teckensnitt även om de inte är installerade på målsystemet. Detta hjälper till att bevara radbrytningar, textavstånd och bildlayout.

Aspose.Slides för Node.js via Java låter dig hämta, lägga till och ta bort inbäddade teckensnitt via klassen [FontsManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsmanager/) som returneras av [Presentation.getFontsManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/getfontsmanager/). Du kan också minska storleken på inbäddade teckensnittsdata genom att ta bort tecken som presentationen inte använder.

Exemplen nedan fungerar med PPTX-filer. Innan du bäddar in ett teckensnitt, se till att dess teckensnittsdata är tillgänglig för Aspose.Slides och att licensen tillåter inbäddning.

## **Hämta och ta bort inbäddade teckensnitt**

Använd [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) för att lista teckensnitt som lagras i en presentation. För att ta bort ett, skicka ett teckensnitt från den listan till [FontsManager.removeEmbeddedFont](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsmanager/removeembeddedfont/), och spara sedan presentationen.

Följande exempel listar de inbäddade teckensnitten i `EmbeddedFonts.pptx` och tar bort Calibri om det finns:

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

Att ta bort ett inbäddat teckensnitt tar bort dess lagrade teckensnittsdata; det ändrar inte det teckensnitt som är tilldelat texten. Om teckensnittet är installerat på målsystemet kan texten fortfarande använda det. Annars kan rendering kräva [font substitution](/slides/sv/nodejs-java/font-substitution/), vilket kan påverka layouten.

## **Granska teckensnittsdata och inbäddningsbehörigheter**

Använd klassen [FontsManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsmanager/) för att granska teckensnitt innan de inbäddas. Anropa [FontsManager.getFonts](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsmanager/getfonts/) för att hämta teckensnitten som används i presentationen. För varje teckensnitt, skicka ett [FontData](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontdata/)-objekt och det erforderliga [FontStyleType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontstyletype/)-värdet till [FontsManager.getFontBytes](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsmanager/#getFontBytes). Metoden returnerar de binära data för den teckensnittsstilen, eller `null` när det begärda teckensnittet eller stilen inte är tillgänglig. Skicka inte ett `null`‑resultat till [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), eftersom den metoden kräver en byte‑array. I Node.js, konvertera den returnerade JavaScript‑arrayen till en Java‑byte‑array med `java.newArray` innan du skickar den till `getFontEmbeddingLevel`.

[EmbeddingLevel](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/embeddinglevel/) rapporterar inbäddningsrestriktionerna som lagras i teckensnittet som en uppsättning flaggor:

- `Installable` tillåter inbäddning och permanent installation på ett annat system, under förutsättning att teckensnittets licens tillåter det.
- `Restricted` förbjuder inbäddning såvida inte tillstånd erhållits från teckensnittets juridiska ägare när det är den enda användningsbehörighetsflaggan.
- `PreviewPrint` tillåter tillfällig användning för visning och utskrift; ett dokument som innehåller teckensnittet måste vara skrivskyddat.
- `Editable` tillåter tillfällig användning och möjliggör att dokumentet redigeras och sparas.
- `NoSubsetting` är en ytterligare restriktion som förbjuder att bara en delmängd av tecknen inbädds. Bädda in alla tecken när denna flagga är närvarande.
- `BitmapOnly` är en ytterligare restriktion som endast tillåter att bitmap‑slag inbäddas, inte konturdata. Om teckensnittet saknar bitmap‑slag kan det inte inbäddas.

De första fyra värdena beskriver användningsbehörighet, medan `NoSubsetting` och `BitmapOnly` kan kombineras med dem. Kontrollera modifierarna med bitvisa operationer. Eftersom `Installable` är noll, maskera användningsbehörighetsbitarna och jämför resultatet med `Installable` istället för att kontrollera det som en flagga. Aktuella teckensnitt bör sätta högst en användningsbehörighetsbit. För kompatibilitet med äldre teckensnitt som sätter mer än en, väljer hjälpfunktionen nedan den minst restriktiva behörigheten: `Editable`, sedan `PreviewPrint`, sedan `Restricted`.

Följande exempel granskar de vanliga, fetstilta, kursiva och fetkursiva data som är tillgängliga för varje teckensnitt som returneras av `getFonts`. Det hoppar över otillgängliga stilar, restrikterade teckensnitt, endast‑bitmap‑teckensnitt, teckensnitt begränsade till förhandsvisning och utskrift eftersom utdata förblir redigerbar, samt teckensnitt som redan är inbäddade. Om någon tillgänglig stil har `NoSubsetting` bäddar den in alla tecken för den teckensnittsfamiljen.

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

Denna granskning rapporterar restriktionerna som är kodade i varje teckensnittfil. Den beviljar inte någon licens, bevisar inte att du skaffat teckensnittet lagligt, eller ersätter kontrollen av teckensnittets licensavtal innan du distribuerar en inbäddad kopia.

## **Lägg till inbäddade teckensnitt**

Använd [FontsManager.addEmbeddedFont](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsmanager/addembeddedfont/) för att inbädda ett teckensnitt. Dess överlagringar accepterar antingen ett [FontData](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontdata/)-objekt eller en byte‑array som innehåller teckensnittsdata. [EmbedFontCharacters](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/embedfontcharacters/) styr vilka tecken som inkluderas:

- `All` inbäddar alla tecken i teckensnittet. Använd detta alternativ när mottagarna behöver redigera presentationen och skriva in ny text.
- `OnlyUsed` inbäddar endast de tecken som används i presentationen för att minska filstorleken. Välj detta alternativ för en färdig presentation som främst är avsedd för visning.

Följande exempel använder [FontsManager.getFonts](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsmanager/getfonts/) för att hämta teckensnitten som används i `Fonts.pptx` och inbäddar de som ännu inte är inbäddade. Teckensnitten som ska läggas till måste vara tillgängliga på maskinen där koden körs. Befintliga inbäddade teckensnitt behåller sina nuvarande teckenuppsättningar.

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

## **Komprimera inbäddade teckensnitt**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compress/compressembeddedfonts/) minskar inbäddade teckensnittsdata genom att ta bort oanvända tecken. Den fungerar på teckensnitt som redan är inbäddade, så storleksreduktionen beror på hur mycket oanvänd teckensnittsdata presentationen innehåller.

Följande exempel komprimerar teckensnitten i `EmbeddedFonts.pptx` och sparar resultatet som en separat fil:

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

Behåll originalfilen om mottagarna kan behöva lägga till text senare. Tecken som tas bort under komprimeringen är inte längre tillgängliga från det inbäddade teckensnittet, även om du ursprungligen inbäddade alla tecken.

## **Vanliga frågor**

**Hur kan jag kontrollera om ett inbäddat teckensnitt fortfarande kommer att ersättas vid rendering?**

Anropa [FontsManager.getSubstitutions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) i den miljö där du renderar presentationen för att se vilka teckensnitt Aspose.Slides kommer att ersätta. Kontrollera även inställningarna för [font substitution](/slides/sv/nodejs-java/font-substitution/) och [font fallback](/slides/sv/nodejs-java/fallback-font/) regler. Fallback hanterar saknade tecken, så inbäddning av ett teckensnitt löser inte tecken som teckensnittet självt inte innehåller.

**Bör jag inbädda vanliga teckensnitt som Arial och Calibri?**

Basera beslutet på målmiljön. Om de erforderliga teckensnitten är tillgängliga på varje maskin som öppnar eller renderar presentationen kan inbäddning av dem öka onödig filstorlek. Om mottagare eller servrar kan sakna dessa teckensnitt kan inbäddning hjälpa till att bevara det avsedda utseendet, förutsatt att licenserna tillåter det.