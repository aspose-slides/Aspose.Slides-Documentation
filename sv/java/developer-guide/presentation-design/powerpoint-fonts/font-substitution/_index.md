---
title: Konfigurera teckensnittsbyte i presentationer med Java
linktitle: Teckensnittsbyte
type: docs
weight: 70
url: /sv/java/font-substitution/
keywords:
- teckensnitt
- ersätt teckensnitt
- teckensnittsbyte
- byt teckensnitt
- teckensnittsersättning
- bytesregel
- ersättningsregel
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Konfigurera regler för teckensnittsbyte och inspektera ersatta teckensnitt i Aspose.Slides för Java vid rendering eller konvertering av PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Font substitution gör att Aspose.Slides kan använda ett tillgängligt teckensnitt i stället för ett teckensnitt som inte kan nås när en presentation renderas eller konverteras. Bytet påverkar det renderade resultatet; det ändrar inte det teckensnitt som är tilldelat presentationens innehåll.

Du kan definiera vilket teckensnitt som ska användas när ett visst teckensnitt inte är tillgängligt, och du kan inspektera de byten som Aspose.Slides kommer att göra under rendering. Detta hjälper till att hålla utdata konsekvent över miljöer med olika installerade teckensnitt.

## **Hämta teckensnittsbyten**

Använd metoden [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) för att avgöra vilka teckensnitt som kommer att bytas ut när presentationen renderas. Metoden returnerar [FontSubstitutionInfo](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontsubstitutioninfo/)-objekt som identifierar de ursprungliga och ersatta teckensnittsnamnen.

Följande Java‑exempel listar alla teckensnittsbyten för en presentation:

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **Hämta teckensnittsbyten för valda bilder**

Använd överlagringen [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) med ett `int[] slides`-argument för att endast inspektera de byten som krävs för att rendera specifika bilder. Detta är användbart när du renderar eller exporterar en del av en presentation, kontrollerar en stor presentation stegvis, lokaliserar bilder som beror på otillgängliga teckensnitt, förbereder ett minimalt teckensnittspaket för en server eller container, eller diagnostiserar renderingsskillnader utan att bearbeta orelaterade bilder.

`slides`‑arrayen innehåller en‑baserade bildindex: `1` identifierar den första bilden. Till skillnad från detta använder åtkomstmetoden för samlingen [Presentation.getSlides](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getSlides--) nollbaserad indexering, så samma bild nås som `presentation.getSlides().get_Item(0)`. Kom ihåg denna skillnad när du bygger arrayen för att undvika avvikelser på +/- ett.

Anropa överlagringen via metoden [Presentation.getFontsManager](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getFontsManager--). Den returnerar endast de byten som fastställts under rendering av de valda bilderna. Varje resultat är ett [FontSubstitutionInfo](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontsubstitutioninfo/)-objekt som innehåller de ursprungliga och ersatta teckensnittsnamnen. Resultatet speglar den aktuella teckensnitts‑miljön, konfigurerade reservregler, substitutionsregler lagrade i en [IFontSubstRuleCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifontsubstrulecollection/), och [externt inlästa teckensnitt](/slides/sv/java/custom-font/).

Samma substitution kan krävas av mer än en vald bild. Deduplikera resultaten när du skapar ett teckensnittsregister eller en förhandsgranskningsrapport. Följande exempel rapporterar varje returnerad substitution och skapar sedan en sorterad lista med unika teckensnittskopplingar:

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;
import java.util.ArrayList;
import java.util.List;
import java.util.Set;
import java.util.TreeSet;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int[] selectedSlides = { 1, 3, 5 };
    List<FontSubstitutionInfo> substitutions = new ArrayList<>();
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions(selectedSlides)) {
        substitutions.add(substitution);
    }

    System.out.println("Substitutions for the selected slides:");
    for (FontSubstitutionInfo substitution : substitutions) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }

    Set<String> sortedPreflightEntries = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
    for (FontSubstitutionInfo substitution : substitutions) {
        String entry = substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
        sortedPreflightEntries.add(entry);
    }

    System.out.println("Deduplicated font preflight report:");
    for (String entry : sortedPreflightEntries) {
        System.out.println(entry);
    }
} finally {
    presentation.dispose();
}
```

[IFontsManager](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifontsmanager/)-gränssnittet tillhandahåller båda överlagringarna. Välj en enligt omfattningen av renderingsoperationen:

| Överlagring | Använd när |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) med inga argument | Du behöver substitutioner för hela presentationen. |
| [getSubstitutions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) med `int[] slides` | Du behöver substitutioner för ett valt intervall, inkrementell kontroll eller partiell export. |

## **Ange teckensnittsbytesregler**

För att ange vilket teckensnitt Aspose.Slides ska använda när ett källteckensnitt inte är tillgängligt:

1. Läs in presentationen.
2. Skapa teckensnittsdefinitioner för käll- och ersättningsteckensnitt.
3. Skapa en [FontSubstRule](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontsubstrule/) med villkoret [WhenInaccessible](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontsubstcondition/).
4. Lägg till regeln i en [FontSubstRuleCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontsubstrulecollection/).
5. Tilldela samlingen genom att använda metoden [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).
6. Rendera eller konvertera presentationen.

Följande Java‑exempel ersätter `Arial` för `SomeRareFont` när `SomeRareFont` inte är tillgängligt, och renderar sedan den första bilden för att verifiera resultatet. Det ersättande teckensnittet måste vara tillgängligt för Aspose.Slides.

```java
import com.aspose.slides.FontData;
import com.aspose.slides.FontSubstCondition;
import com.aspose.slides.FontSubstRule;
import com.aspose.slides.FontSubstRuleCollection;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontSubstRule;
import com.aspose.slides.IFontSubstRuleCollection;
import com.aspose.slides.IImage;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData substituteFont = new FontData("Arial");
    IFontSubstRule substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection substitutionRules = new FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    IImage image = presentation.getSlides().get_Item(0).getImage(1f, 1f);
    try {
        image.save("slide.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
För en ovillkorlig ändring av de teckensnitt som används i hela en presentation, se [Teckensnittsersättning](/slides/sv/java/font-replacement/).
{{% /alert %}}

## **Begränsningar för teckensnitt i matematiska ekvationer**

Teckensnittsbytesregler är en del av den standardiserade teckensnittsvalprocessen som används under rendering och konvertering. De fungerar för vanlig text när Aspose.Slides kan ersätta ett otillgängligt teckensnitt med det tillgängliga teckensnitt som specificeras av en regel.

Office Math‑ekvationer har ett extra krav. Om en ekvation använder **Cambria Math** kan Aspose.Slides behöva exakt det teckensnittet för att beräkna och rendera ekvationslayouten. En regel som ersätter med ett annat matematiskt teckensnitt, såsom **STIX Two Math**, kan inte ersätta **Cambria Math** för detta ändamål, och rendering kan fortfarande rapportera att **Cambria Math** krävs.

För att rendera eller konvertera en sådan presentation, gör **Cambria Math** tillgängligt för Aspose.Slides. Installera det i operativsystemet eller ladda det som ett [externt teckensnitt](/slides/sv/java/custom-font/).

Denna begränsning gäller för ekvationslayout. Substitutionsreglerna som beskrivits ovan gäller fortfarande för vanlig presentationstext.

## **Vanliga frågor**

**Vad är skillnaden mellan teckensnittsersättning och teckensnittsbyte?**

[Font replacement](/slides/sv/java/font-replacement/) ändrar medvetet ett teckensnitt till ett annat i hela presentationen. Teckensnittsbyte väljer ett teckensnitt för det renderade resultatet när den konfigurerade villkoret uppfylls, exempelvis när det ursprungliga teckensnittet inte är tillgängligt.

**När tillämpas substitutionsregler?**

Reglerna deltar i [font selection sequence](/slides/sv/java/font-selection-sequence/) under rendering och konvertering. Med `WhenInaccessible` används en regel endast när Aspose.Slides inte kan komma åt källteckensnittet.

**Vad händer när ett teckensnitt saknas och ingen substitutionsregel är konfigurerad?**

Aspose.Slides väljer det närmaste tillgängliga teckensnittet enligt sin teckensnittsvalprocess. Resultatet beror på vilka teckensnitt som finns i körmiljön.

**Kan jag ladda externa teckensnitt för att undvika substitution?**

Ja. Du kan [ladda externa teckensnitt](/slides/sv/java/custom-font/) så att Aspose.Slides kan använda dem under rendering och konvertering.

**Distribuerar Aspose teckensnitt med biblioteket?**

Nej. Du ansvarar för att tillhandahålla teckensnitt och följa deras licenser.

**Kan substitutionsresultat skilja sig mellan Windows, Linux och macOS?**

Ja. Installerade teckensnitt och sökvägar för teckensnitt varierar mellan operativsystem, så ett teckensnitt som är tillgängligt på en maskin kan behöva bytas på en annan.

**Hur kan jag göra teckensnittsvalet konsekvent i batchkonverteringar?**

Använd samma teckensnittsfiler och versioner på varje maskin eller container, [ladda erforderliga externa teckensnitt](/slides/sv/java/custom-font/), och [bädda in teckensnitt](/slides/sv/java/embedded-font/) när licensen tillåter. Du kan även anropa [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) före export för att identifiera oväntade byten.