---
title: Bädda in typsnitt i presentationer på Android
linktitle: Inbäddade typsnitt
type: docs
weight: 40
url: /sv/androidjava/embedded-font/
keywords:
- lägga till typsnitt
- inbädda typsnitt
- inbäddning av typsnitt
- hämta inbäddat typsnitt
- lägga till inbäddat typsnitt
- ta bort inbäddat typsnitt
- komprimera inbäddat typsnitt
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Hantera inbäddade typsnitt i PowerPoint med Aspose.Slides för Android via Java. Lägg till, hämta, ta bort och komprimera typsnitt för att bevara textens utseende och minska filstorleken."
---
## **Introduktion**

Inbäddning av typsnitt lagrar typsnittsdata i en PowerPoint-presentation. När en visare stödjer inbäddade typsnitt kan den visa text med dessa typsnitt även om de inte är installerade på målsystemet. Detta hjälper till att bevara radbrytningar, textavstånd och bildlayout.

Aspose.Slides för Android via Java låter dig hämta, lägga till och ta bort inbäddade typsnitt via gränssnittet [IFontsManager](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifontsmanager/) som returneras av [Presentation.getFontsManager](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getFontsManager--). Du kan också minska storleken på inbäddade typsnittsdata genom att ta bort tecken som presentationen inte använder.

Exemplen nedan fungerar med PPTX-filer. Innan du bäddar in ett typsnitt, se till att dess typsnittsdata är tillgänglig för Aspose.Slides och att licensen tillåter inbäddning.

## **Hämta och ta bort inbäddade typsnitt**

Använd [getEmbeddedFonts](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) för att lista typsnitten som lagras i en presentation. För att ta bort ett, skicka ett typsnitt från den listan till [removeEmbeddedFont](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-), och spara sedan presentationen.

Följande exempel listar de inbäddade typsnitten i `EmbeddedFonts.pptx` och tar bort Calibri om det finns:

```java
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    for (IFontData font : embeddedFonts) {
        System.out.println(font.getFontName());
    }

    IFontData fontToRemove = null;
    for (IFontData font : embeddedFonts) {
        if ("Calibri".equalsIgnoreCase(font.getFontName())) {
            fontToRemove = font;
            break;
        }
    }

    if (fontToRemove != null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

Att ta bort ett inbäddat typsnitt tar bort dess lagrade typsnittsdata; det ändrar inte det teckensnitt som tilldelats texten. Om typsnittet är installerat på målsystemet kan texten fortfarande använda det. Annars kan rendering kräva [font substitution](/slides/sv/androidjava/font-substitution/), vilket kan påverka layouten.

## **Inspektera typsnittsdata och inbäddningsbehörigheter**

Använd gränssnittet [IFontsManager](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifontsmanager/) för att inspektera typsnitt innan de inbäddas. Anropa [IFontsManager.getFonts](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) för att hämta de typsnitt som används i presentationen. För varje typsnitt, skicka ett [IFontData](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifontdata/)‑objekt och det erforderliga [FontStyleType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontstyletype/)‑värdet till [IFontsManager.getFontBytes](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifontsmanager/#getFontBytes-com.aspose.slides.IFontData-int-). Metoden returnerar de binära data för den typsnittsstilen, eller `null` när det begärda typsnittet eller stilen inte är tillgänglig. Skicka inte ett `null`‑resultat till [IFontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifontsmanager/#getFontEmbeddingLevel-byte---java.lang.String-), eftersom den metoden kräver en byte‑array.

[EmbeddingLevel](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/embeddinglevel/) är en flagg‑enumeration som rapporterar inbäddningsrestriktionerna lagrade i typsnittet:

- `Installable` tillåter inbäddning och permanent installation på ett annat system, med förbehåll för typsnittets licens.
- `Restricted` förbjuder inbäddning om inte tillstånd erhålls från typsnittets rättsliga ägare när det är den enda användnings‑behörighetsflaggan.
- `PreviewPrint` tillåter tillfällig användning för visning och utskrift; ett dokument som innehåller typsnittet måste vara skrivskyddat.
- `Editable` tillåter tillfällig användning och tillåter att dokumentet redigeras och sparas.
- `NoSubsetting` är en extra restriktion som förbjuder att bara en delmängd av glyferna inbäddas. Bädda in alla tecken när denna flagga är närvarande.
- `BitmapOnly` är en extra restriktion som endast tillåter inbäddning av bitmap‑slag, inte konturdata. Om typsnittet saknar bitmap‑slag kan det inte inbäddas.

De första fyra värdena beskriver användningsbehörighet, medan `NoSubsetting` och `BitmapOnly` kan kombineras med dem. Kontrollera modifierarna med bitvisa operationer. Eftersom `Installable` är noll, maskera användnings‑behörighetsbitarna och jämför resultatet med `Installable` istället för att kontrollera det som en flagga. Nuvarande typsnitt bör sätta högst en användnings‑behörighetsbit. För kompatibilitet med äldre typsnitt som sätter mer än en, väljer hjälpfunktionen nedan den minst restriktiva behörigheten: `Editable`, sedan `PreviewPrint`, sedan `Restricted`.

Följande exempel granskar de vanliga, feta, kursiva och fet‑kursiva data som är tillgängliga för varje typsnitt som returneras av `getFonts`. Det hoppar över otillgängliga stilar, begränsade typsnitt, endast‑bitmap‑typsnitt, typsnitt begränsade till förhandsgranskning och utskrift eftersom utdata förblir redigerbar, samt typsnitt som redan är inbäddade. Om någon tillgänglig stil har `NoSubsetting` bäddar det in alla tecken för den typsnittsfamiljen.

```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.EmbeddingLevel;
import com.aspose.slides.FontStyleType;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Locale;
import java.util.Set;

class EmbeddingPermission {
    int getUsagePermission(int level) {
        int permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
        int permissions = level & permissionMask;

        if ((permissions & EmbeddingLevel.Editable) != 0) {
            return EmbeddingLevel.Editable;
        }

        if ((permissions & EmbeddingLevel.PreviewPrint) != 0) {
            return EmbeddingLevel.PreviewPrint;
        }

        if ((permissions & EmbeddingLevel.Restricted) != 0) {
            return EmbeddingLevel.Restricted;
        }

        return EmbeddingLevel.Installable;
    }
}

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    int[] fontStyles = {
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic
    };

    Set<String> embeddedFontNames = new HashSet<String>();
    for (IFontData embeddedFont : fontsManager.getEmbeddedFonts()) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    EmbeddingPermission permissionHelper = new EmbeddingPermission();
    List<IFontData> fontsToEmbed = new ArrayList<IFontData>();
    List<Integer> embeddingRules = new ArrayList<Integer>();
    for (IFontData font : fontsManager.getFonts()) {
        if (embeddedFontNames.contains(font.getFontName().toLowerCase(Locale.ROOT))) {
            System.out.println(font.getFontName() + ": already embedded.");
            continue;
        }

        boolean hasAvailableData = false;
        boolean allAvailableStylesCanBeEmbedded = true;
        boolean previewPrintOnly = false;
        boolean requiresFullFont = false;

        for (int fontStyle : fontStyles) {
            byte[] fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes == null) {
                System.out.println(font.getFontName() + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            int embeddingLevel = fontsManager.getFontEmbeddingLevel(fontBytes, font.getFontName());
            int usagePermission = permissionHelper.getUsagePermission(embeddingLevel);
            boolean noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
            boolean bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

            requiresFullFont |= noSubsetting;
            previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

            System.out.println(font.getFontName() + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            System.out.println(font.getFontName() + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            System.out.println(font.getFontName() + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            System.out.println(font.getFontName() + ": skipped because this example produces an editable presentation.");
        } else {
            int rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.add(font);
            embeddingRules.add(rule);
        }
    }

    for (int i = 0; i < fontsToEmbed.size(); i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed.get(i), embeddingRules.get(i));
    }

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Denna inspektion rapporterar de restriktioner som är kodade i varje typsnittfil. Den beviljar inte någon licens, bevisar inte att du har skaffat typsnittet lagligt, eller ersätter kontrollen av typsnittets licensavtal innan du distribuerar en inbäddad kopia.

## **Lägg till inbäddade typsnitt**

Använd [addEmbeddedFont](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) för att bädda in ett typsnitt. Dess överlagringar accepterar antingen ett [IFontData](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifontdata/)‑objekt eller en byte‑array som innehåller typsnittsdata. Enumerationen [EmbedFontCharacters](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/embedfontcharacters/) styr vilka tecken som inkluderas:

- `All` bäddar in alla tecken i typsnittet. Använd detta alternativ när mottagare behöver redigera presentationen och ange ny text.
- `OnlyUsed` bäddar in endast de tecken som används i presentationen för att minska filstorleken. Välj detta alternativ för en färdig presentation som främst är avsedd för visning.

Följande exempel använder [getFonts](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) för att hämta de typsnitt som används i `Fonts.pptx` och bäddar in de som inte redan är inbäddade. Typsnitten som ska läggas till måste vara tillgängliga på Android‑enheten eller registrerade hos Aspose.Slides. Befintliga inbäddade typsnitt behåller sina nuvarande teckenset.

```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.HashSet;
import java.util.Locale;
import java.util.Set;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] allFonts = fontsManager.getFonts();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();
    Set<String> embeddedFontNames = new HashSet<String>();

    for (IFontData embeddedFont : embeddedFonts) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    for (IFontData font : allFonts) {
        String fontName = font.getFontName().toLowerCase(Locale.ROOT);
        if (!embeddedFontNames.contains(fontName)) {
            fontsManager.addEmbeddedFont(font, EmbedFontCharacters.All);
            embeddedFontNames.add(fontName);
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Komprimera inbäddade typsnitt**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) minskar inbäddad typsnittsdata genom att ta bort oanvända tecken. Den fungerar på typsnitt som redan är inbäddade, så storleksreduktionen beror på hur mycket oanvänd typsnittsdata presentationen innehåller.

Följande exempel komprimerar typsnitten i `EmbeddedFonts.pptx` och sparar resultatet som en separat fil:

```java
import com.aspose.slides.Compress;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Behåll originalfilen om mottagarna kan behöva lägga till text senare. Tecken som tas bort under komprimeringen är inte längre tillgängliga från det inbäddade typsnittet, även om du ursprungligen bäddade in alla tecken.

## **FAQ**

**Hur kan jag kontrollera om ett inbäddat typsnitt fortfarande kommer att ersättas under rendering?**

Anropa [getSubstitutions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) i den miljö där du renderar presentationen för att se vilka typsnitt Aspose.Slides kommer att ersätta. Kontrollera också inställningarna för [font substitution](/slides/sv/androidjava/font-substitution/) och reglerna för [font fallback](/slides/sv/androidjava/fallback-font/). Fallback hanterar saknade tecken, så inbäddning av ett typsnitt löser inte tecken som själva typsnittet inte innehåller.

**Bör jag bädda in vanliga typsnitt som Arial och Calibri?**

Basera beslutet på målmiljön. Om de nödvändiga typsnitten finns tillgängliga på varje enhet som öppnar eller renderar presentationen kan inbäddning av dem lägga till onödig filstorlek. Om mottagare eller servrar kan sakna dessa typsnitt kan inbäddning av dem hjälpa till att bevara det avsedda utseendet, förutsatt att deras licenser tillåter det.