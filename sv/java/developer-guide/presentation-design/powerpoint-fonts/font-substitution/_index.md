---
title: Konfigurera teckensnittssubstitution i presentationer med Java
linktitle: Teckensnittssubstitution
type: docs
weight: 70
url: /sv/java/font-substitution/
keywords:
- teckensnitt
- ersätta teckensnitt
- teckensnittssubstitution
- ersätt teckensnitt
- teckensnittsutbyte
- substitutionsregel
- ersättningsregel
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Konfigurera regler för teckensnittssubstitution och granska ersatta teckensnitt i Aspose.Slides för Java när du renderar eller konverterar PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Fontsubstitution gör det möjligt för Aspose.Slides att använda ett tillgängligt teckensnitt i stället för ett teckensnitt som inte kan nås när en presentation renderas eller konverteras. Substitutionen påverkar det renderade resultatet; den ändrar inte det teckensnitt som är tilldelat presentationsinnehållet.

Du kan definiera vilket teckensnitt som ska användas när ett specifikt teckensnitt är otillgängligt, och du kan granska de substitutioner som Aspose.Slides kommer att göra under rendering. Detta hjälper till att hålla resultatet enhetligt över miljöer med olika installerade teckensnitt.

Om ett teckensnitt är tillgängligt men inte har en dedikerad fet stil, se [Hantera teckensnitt utan en dedikerad fet stil](/slides/sv/java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Det avsnittet förklarar hur man rasteriserar den berörda texten under PDF‑export och vilka konsekvenser det har för textmarkering, sökning och skalning.

## **Hämta teckensnitts‑substitutioner**

Använd metoden [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) för att bestämma vilka teckensnitt som kommer att ersättas när presentationen renderas. Metoden returnerar objekt av typen [FontSubstitutionInfo](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstitutioninfo/) som identifierar de ursprungliga och ersatta teckensnittsnamnen.

Följande Java‑exempel listar alla teckensnitts‑substitutioner för en presentation:

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

## **Hämta teckensnitts‑substitutioner för valda bilder**

Använd överlagringen [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) med ett argument av typen `int[] slides` för att granska endast de substitutioner som krävs för att rendera specifika bilder. Detta är användbart när du renderar eller exporterar en del av en presentation, kontrollerar en stor presentation stegvis, lokalisera bilder som är beroende av otillgängliga teckensnitt, förbereder ett minimalt teckensnittspaket för en server eller container, eller diagnostiserar renderingsskillnader utan att bearbeta orelaterade bilder.

`slides`‑arrayen innehåller ett‑baserade bildindex: `1` identifierar den första bilden. I kontrast använder åtkomsten [Presentation.getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) noll‑baserad indexering, så samma bild nås som `presentation.getSlides().get_Item(0)`. Ha denna skillnad i åtanke när du bygger arrayen för att undvika en‑off‑fel.

Anropa överlagringen via metoden [Presentation.getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getFontsManager--). Den returnerar endast de substitutioner som fastställts under rendering av de valda bilderna. Varje resultat är ett [FontSubstitutionInfo](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstitutioninfo/)‑objekt som innehåller de ursprungliga och ersatta teckensnittsnamnen. Resultatet speglar den aktuella teckensnittsmiljön, konfigurerade reservregler och [externt laddade teckensnitt](/slides/sv/java/custom-font/). Substitutionsregler som lagras i en [IFontSubstRuleCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsubstrulecollection/) tillämpas när presentationen renderas, men resultatet listar dem inte; kontrollera teckensnitten i utdatafilen istället.

Samma substitution kan krävas av mer än en vald bild. Deduplikera resultaten när du skapar ett teckensnitts‑inventarium eller en förhandsgranskningsrapport. Följande exempel rapporterar varje returnerad substitution och skapar sedan en sorterad lista med unika teckensnittsmappningar:

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

Gränssnittet [IFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/) tillhandahåller båda överlagringarna. Välj en enligt omfånget för renderingsoperationen:

| Overload | Use it when |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) with no arguments | Du behöver substitutioner för hela presentationen. |
| [getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) with `int[] slides` | Du behöver substitutioner för ett valt intervall, inkrementell kontroll eller partiell export. |

## **Ange regler för teckensnitts‑substitution**

För att ange vilket teckensnitt Aspose.Slides ska använda när ett källteckensnitt är otillgängligt:

1. Läs in presentationen.
2. Skapa teckensnittdefinitioner för käll- och ersättningsteckensnitten.
3. Skapa en [FontSubstRule](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrule/) med villkoret [WhenInaccessible](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstcondition/).
4. Lägg till regeln i en [FontSubstRuleCollection](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrulecollection/).
5. Tilldela samlingen genom att använda metoden [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).
6. Rendera eller konvertera presentationen.

Följande Java‑exempel ersätter `Arial` för `SomeRareFont` när `SomeRareFont` är otillgängligt, och renderar sedan den första bilden för att verifiera resultatet. Ersättningsteckensnittet måste vara tillgängligt för Aspose.Slides.

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
För en ovillkorlig ändring av teckensnitten som används i hela en presentation, se [Teckensnittsutbyte](/slides/sv/java/font-replacement/).
{{% /alert %}}

## **Begränsningar för teckensnitt i matematiska ekvationer**

Regler för teckensnittssubstitution är en del av den standardprocess för teckensnittsväljning som används under rendering och konvertering. De fungerar för vanlig text när Aspose.Slides kan ersätta ett otillgängligt teckensnitt med det tillgängliga teckensnitt som anges i en regel.

Office Math‑ekvationer har ett extra krav. Om en ekvation använder **Cambria Math** kan Aspose.Slides behöva exakt det teckensnittet för att beräkna och rendera ekvationslayouten. En regel som ersätter det med ett annat matematiskt teckensnitt, som **STIX Two Math**, kan inte ersätta **Cambria Math** för detta ändamål, och renderingen kan fortfarande ange att **Cambria Math** krävs.

För att rendera eller konvertera en sådan presentation, gör **Cambria Math** tillgängligt för Aspose.Slides. Installera det i operativsystemet eller ladda det som ett [externt teckensnitt](/slides/sv/java/custom-font/).

Denna begränsning gäller för ekvationslayout. Substitutionsreglerna som beskrivits ovan gäller fortfarande för vanlig presentationstext.

## **Vanliga frågor**

**Vad är skillnaden mellan teckensnittsutbyte och teckensnittssubstitution?**

[Teckensnittsutbyte](/slides/sv/java/font-replacement/) ändrar avsiktligt ett teckensnitt till ett annat i hela presentationen. Teckensnittssubstitution väljer ett teckensnitt för renderat resultat när det konfigurerade villkoret är uppfyllt, till exempel när det ursprungliga teckensnittet är otillgängligt.

**När tillämpas substitutionsregler?**

Reglerna deltar i [font selection sequence](/slides/sv/java/font-selection-sequence/) under rendering och konvertering. Med `WhenInaccessible` används en regel endast när Aspose.Slides inte kan komma åt källteckensnittet.

**Vad händer när ett teckensnitt saknas och ingen substitutionsregel är konfigurerad?**

Aspose.Slides väljer det närmaste tillgängliga teckensnittet enligt sin teckensnittsväljprocess. Resultatet beror på vilka teckensnitt som finns i körningsmiljön.

**Kan jag ladda externa teckensnitt för att undvika substitution?**

Ja. Du kan [ladda externa teckensnitt](/slides/sv/java/custom-font/) så att Aspose.Slides kan använda dem under rendering och konvertering.

**Distribuerar Aspose teckensnitt med biblioteket?**

Nej. Du är ansvarig för att tillhandahålla teckensnitt och följa deras licenser.

**Kan substitutionsresultat skilja sig mellan Windows, Linux och macOS?**

Ja. Installerade teckensnitt och sökvägar för teckensnitt skiljer sig åt mellan operativsystem, så ett teckensnitt som är tillgängligt på en maskin kan kräva substitution på en annan.

**Hur kan jag göra teckensnittsväljning konsekvent i batchkonverteringar?**

Använd samma teckensnittsfiler och versioner på alla maskiner eller containrar, [ladda erforderliga externa teckensnitt](/slides/sv/java/custom-font/) och [bädda in teckensnitt](/slides/sv/java/embedded-font/) när licensen tillåter. Du kan också anropa [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) före export för att identifiera oväntade substitutioner.