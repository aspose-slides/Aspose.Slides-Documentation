---
title: Bädda in teckensnitt i presentationer i Java
linktitle: Inbäddade teckensnitt
type: docs
weight: 40
url: /sv/java/embedded-font/
keywords:
- lägg till teckensnitt
- bädda in teckensnitt
- inbäddning av teckensnitt
- hämta inbäddat teckensnitt
- lägga till inbäddat teckensnitt
- ta bort inbäddat teckensnitt
- komprimera inbäddat teckensnitt
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Hantera inbäddade teckensnitt i PowerPoint med Aspose.Slides för Java. Lägg till, hämta, ta bort och komprimera teckensnitt för att bevara textens utseende och minska filstorleken."
---
## **Introduktion**

Att bädda in teckensnitt lagrar teckensnittsdata i en PowerPoint‑presentation. När en visare stödjer inbäddade teckensnitt kan den visa text med dessa teckensnitt även om de inte är installerade på målsystemet. Detta hjälper till att bevara radbrytningar, textavstånd och bildlayout.

Aspose.Slides för Java låter dig hämta, lägga till och ta bort inbäddade teckensnitt via gränssnittet [IFontsManager](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifontsmanager/) som returneras av [Presentation.getFontsManager](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getFontsManager--). Du kan också minska storleken på inbäddade teckensnittsdata genom att ta bort tecken som presentationen inte använder.

Exemplen nedan fungerar med PPTX‑filer. Innan du bäddar in ett teckensnitt, se till att dess teckensnittsdata är tillgänglig för Aspose.Slides och att licensen tillåter inbäddning.

## **Hämta och ta bort inbäddade teckensnitt**

Använd [getEmbeddedFonts](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) för att lista de teckensnitt som lagras i en presentation. För att ta bort ett, skicka ett teckensnitt från den listan till [removeEmbeddedFont](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-), och spara sedan presentationen.

Följande exempel listar de inbäddade teckensnitten i `EmbeddedFonts.pptx` och tar bort Calibri om det finns:

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

Att ta bort ett inbäddat teckensnitt tar bort dess lagrade teckensnittsdata; det ändrar inte det teckensnitt som är tilldelat texten. Om teckensnittet är installerat på målsystemet kan texten fortfarande använda det. Annars kan rendering kräva [font substitution](/slides/sv/java/font-substitution/), vilket kan påverka layouten.

## **Inspektera teckensnittsdata och inbäddningsbehörigheter**

Använd gränssnittet [IFontsManager](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifontsmanager/) för att inspektera teckensnitt innan de bädds in. Anropa [IFontsManager.getFonts](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifontsmanager/#getFonts--) för att hämta de teckensnitt som används i presentationen. För varje teckensnitt, skicka ett [IFontData](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifontdata/)-objekt och det erforderliga [FontStyleType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontstyletype/)-värdet till [IFontsManager.getFontBytes](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifontsmanager/#getFontBytes-com.aspose.slides.IFontData-int-). Metoden returnerar de binära data för den teckensnittsstilen, eller `null` när det begärda teckensnittet eller stilen inte är tillgänglig. Skicka inte ett `null`‑resultat till [IFontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifontsmanager/#getFontEmbeddingLevel-byte---java.lang.String-), eftersom den metoden kräver en byte‑array.

[EmbeddingLevel](https://reference.aspose.com/slides/sv/java/com.aspose.slides/embeddinglevel/) är en flagg‑enumeration som rapporterar de inbäddningsrestriktioner som lagras i teckensnittet:

- `Installable` tillåter inbäddning och permanent installation på ett annat system, under förutsättning att teckensnittslicensen tillåter det.
- `Restricted` förbjuder inbäddning om inte tillåtelse erhålls från teckensnittets juridiska ägare när det är det enda användnings‑behörighetsflaggan.
- `PreviewPrint` tillåter tillfällig användning för visning och utskrift; ett dokument som innehåller teckensnittet måste vara skrivskyddat.
- `Editable` tillåter tillfällig användning och gör det möjligt att redigera och spara dokumentet.
- `NoSubsetting` är en ytterligare restriktion som förbjuder att bara en delmängd av glyferna bäddas in. Bädda in alla tecken när denna flagga är närvarande.
- `BitmapOnly` är en ytterligare restriktion som endast tillåter inbäddning av bitmap‑slag, inte konturdata. Om teckensnittet saknar bitmap‑slag kan det inte bäddas in.

De första fyra värdena beskriver användarbehörighet, medan `NoSubsetting` och `BitmapOnly` kan kombineras med dem. Kontrollera modifierarna med bitvisa operationer. Eftersom `Installable` är noll, maskera användarbehörighets‑bitarna och jämför resultatet med `Installable` i stället för att kontrollera det som en flagga. Aktuella teckensnitt bör sätta högst en användarbehörighetsbit. För kompatibilitet med äldre teckensnitt som sätter fler än en, väljer hjälpfunktionen nedan den minst restriktiva behörigheten: `Editable`, sedan `PreviewPrint`, sedan `Restricted`.

Följande exempel granskar de vanliga, fetstil, kursiv och fet‑kursiv data som finns för varje teckensnitt som returneras av `getFonts`. Det hoppar över otillgängliga stilar, begränsade teckensnitt, enbart bitmap‑teckensnitt, teckensnitt som är begränsade till förhandsgranskning och utskrift eftersom utdata förblir redigerbar, samt teckensnitt som redan är inbäddade. Om någon tillgänglig stil har `NoSubsetting` bäddas alla tecken in för den teckensnittsfamiljen.

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

Denna inspektion rapporterar de restriktioner som kodas i varje teckensnittfil. Den beviljar ingen licens, bevisar inte att du skaffat teckensnittet lagligt, och ersätter inte kontrollen av teckensnittets licensavtal innan du distribuerar en inbäddad kopia.

## **Lägg till inbäddade teckensnitt**

Använd [addEmbeddedFont](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) för att bädda in ett teckensnitt. Dess överlagringar accepterar antingen ett [IFontData](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifontdata/)-objekt eller en byte‑array som innehåller teckensnittsdata. Enumerationen [EmbedFontCharacters](https://reference.aspose.com/slides/sv/java/com.aspose.slides/embedfontcharacters/) styr vilka tecken som inkluderas:

- [All](https://reference.aspose.com/slides/sv/java/com.aspose.slides/embedfontcharacters/) bäddar in alla tecken i teckensnittet. Använd detta alternativ när mottagarna behöver redigera presentationen och skriva in ny text.
- [OnlyUsed](https://reference.aspose.com/slides/sv/java/com.aspose.slides/embedfontcharacters/) bäddar in endast de tecken som används i presentationen för att minska filstorleken. Välj detta alternativ för en färdig presentation som huvudsakligen är avsedd för visning.

Följande exempel använder [getFonts](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifontsmanager/#getFonts--) för att hämta de teckensnitt som används i `Fonts.pptx` och bäddar in de som ännu inte är inbäddade. Teckensnitten som ska läggas till måste finnas på maskinen som kör koden. Existerande inbäddade teckensnitt behåller sina nuvarande teckenuppsättningar.

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

## **Komprimera inbäddade teckensnitt**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/sv/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) minskar inbäddade teckensnittsdata genom att ta bort oanvända tecken. Den arbetar på teckensnitt som redan är inbäddade, så storleksreduktionen beror på hur mycket oanvänd teckensnittsdata presentationen innehåller.

Följande exempel komprimerar teckensnitten i `EmbeddedFonts.pptx` och sparar resultatet som en separat fil:

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

Behåll originalfilen om mottagarna senare kan behöva lägga till text. Tecken som tas bort under komprimeringen är inte längre tillgängliga från det inbäddade teckensnittet, även om du ursprungligen bäddade in alla tecken.

## **FAQ**

**Hur kan jag kontrollera om ett inbäddat teckensnitt fortfarande kommer att ersättas vid rendering?**

Anropa [getSubstitutions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) i den miljö där du renderar presentationen för att se vilka teckensnitt Aspose.Slides kommer att ersätta. Kontrollera också inställningarna för [font substitution](/slides/sv/java/font-substitution/) och reglerna för [font fallback](/slides/sv/java/fallback-font/). Fallback hanterar saknade tecken, så inbäddning av ett teckensnitt löser inte tecken som teckensnittet självt saknar.

**Bör jag bädda in vanliga teckensnitt som Arial och Calibri?**

Basera beslutet på målmiljön. Om de erforderliga teckensnitten finns på varje maskin som öppnar eller renderar presentationen, kan inbäddning av dem öka filstorleken onödigt. Om mottagare eller servrar kan sakna dessa teckensnitt kan inbäddning hjälpa till att bevara det avsedda utseendet, förutsatt att deras licenser tillåter det.