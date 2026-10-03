---
title: Konfigurera teckensnittssubstitution i presentationer med Java
linktitle: Teckensnittssubstitution
type: docs
weight: 70
url: /sv/java/font-substitution/
keywords:
- teckensnitt
- ersätt teckensnitt
- teckensnittssubstitution
- ersätta teckensnitt
- teckensnittsersättning
- substitutionsregel
- ersättningsregel
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Konfigurera teckensnittssubstitutionsregler och inspektera substituerade teckensnitt i Aspose.Slides för Java när du renderar eller konverterar PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Fontsubstitution tillåter Aspose.Slides att använda ett tillgängligt teckensnitt i stället för ett teckensnitt som inte kan nås när en presentation renderas eller konverteras. Substitutionen påverkar det renderade resultatet; den ändrar inte teckensnittet som är tilldelat presentationens innehåll.

Du kan definiera vilket teckensnitt som ska användas när ett specifikt teckensnitt är otillgängligt, och du kan granska de substitutioner som Aspose.Slides kommer att göra under rendering. Detta hjälper till att hålla utdata konsekvent över miljöer med olika installerade teckensnitt.

## **Hämta fontsubstitutioner**

Använd metoden [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) för att avgöra vilka teckensnitt som kommer att substitueras när presentationen renderas. Metoden returnerar objekt av typen [FontSubstitutionInfo](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontsubstitutioninfo/) som identifierar de ursprungliga och substituerade teckensnittsnamnen.

Följande Java‑exempel listar alla fontsubstitutioner för en presentation:

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

## **Hämta fontsubstitutioner för valda bilder**

Använd överlagringen av [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) med argumentet `int[] slides` för att endast granska de substitutioner som krävs för att rendera specifika bilder. Detta är användbart när du renderar eller exporterar en del av en presentation, kontrollerar en stor presentation stegvis, lokaliserar bilder som är beroende av otillgängliga teckensnitt, förbereder ett minimalt teckensnittspaket för en server eller container, eller diagnostiserar renderingsskillnader utan att bearbeta orelaterade bilder.

`slides`‑arrayen innehåller ett‑baserade bildindex: `1` identifierar den första bilden. Till skillnad från detta använder [Presentation.getSlides](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getSlides--) samlingsåtkomstmetoden noll‑baserad indexering, så samma bild nås som `presentation.getSlides().get_Item(0)`. Ha denna skillnad i åtanke när du bygger arrayen för att undvika fel med ett steg.

Anropa överlagringen via metoden [Presentation.getFontsManager](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getFontsManager--) . Den returnerar endast de substitutioner som fastställts under rendering av de valda bilderna. Varje resultat är ett [FontSubstitutionInfo](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontsubstitutioninfo/)‑objekt som innehåller de ursprungliga och substituerade teckensnittsnamnen. Resultatet speglar den aktuella teckensnittsmiljön, konfigurerade reservregler och [externally loaded fonts](/slides/sv/java/custom-font/). Substitutionsregler lagrade i en [IFontSubstRuleCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifontsubstrulecollection/) tillämpas när presentationen renderas, men resultatet listar dem inte; kontrollera teckensnitten i utdatafilen istället.

Samma substitution kan krävas av mer än en vald bild. Deduplicera resultaten när du skapar en teckensnitts‑inventering eller för‑flygsrapport. Följande exempel rapporterar varje returnerad substitution och skapar sedan en sorterad lista över unika teckensnittsmappningar:

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

[IFontsManager](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifontsmanager/)‑gränssnittet tillhandahåller båda överlagringarna. Välj en enligt omfattningen av renderingsoperationen:

| Överlagring | Använd den när |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) med inga argument | Du behöver substitutioner för hela presentationen. |
| [getSubstitutions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) med `int[] slides` | Du behöver substitutioner för ett valt intervall, stegvis kontroll eller partiell export. |

## **Ange fontsubstitutionsregler**

För att ange vilket teckensnitt Aspose.Slides ska använda när ett källteckensnitt är otillgängligt:

1. Läs in presentationen.
2. Skapa teckensnittsdefinitioner för käll- och ersättningsteckensnitt.
3. Skapa en [FontSubstRule](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontsubstrule/) med villkoret [WhenInaccessible](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontsubstcondition/).
4. Lägg till regeln i en [FontSubstRuleCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontsubstrulecollection/).
5. Tilldela samlingen genom att använda metoden [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).
6. Rendera eller konvertera presentationen.

Följande Java‑exempel substituerar `Arial` för `SomeRareFont` när `SomeRareFont` är otillgängligt, och renderar sedan den första bilden för att verifiera resultatet. Det ersättande teckensnittet måste vara tillgängligt för Aspose.Slides.

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
För en ovillkorlig förändring av de teckensnitt som används i hela presentationen, se [Font Replacement](/slides/sv/java/font-replacement/).
{{% /alert %}}

## **Begränsningar för teckensnitt i matematiska ekvationer**

Fontsubstitutionsregler är en del av den standardiserade teckensnittsväljningsprocessen som används under rendering och konvertering. De fungerar för vanlig text när Aspose.Slides kan ersätta ett otillgängligt teckensnitt med det tillgängliga teckensnitt som specificerats av en regel.

Office Math‑ekvationer har ett extra krav. Om en ekvation använder **Cambria Math**, kan Aspose.Slides behöva exakt det teckensnittet för att beräkna och rendera ekvationens layout. En regel som substituerar ett annat matematiskt teckensnitt, såsom **STIX Two Math**, kan inte ersätta **Cambria Math** för detta ändamål, och rendering kan fortfarande rapportera att **Cambria Math** krävs.

För att rendera eller konvertera en sådan presentation, gör **Cambria Math** tillgängligt för Aspose.Slides. Installera det i operativsystemet eller ladda det som ett [external font](/slides/sv/java/custom-font/).

Denna begränsning gäller layouten av ekvationer. De ovan beskrivna substitionsreglerna gäller fortfarande för vanlig presentationstext.

## **FAQ**

**Vad är skillnaden mellan font replacement och font substitution?**

[Font replacement](/slides/sv/java/font-replacement/) ändrar avsiktligt ett teckensnitt till ett annat i hela presentationen. Font substitution väljer ett teckensnitt för renderat resultat när det konfigurerade villkoret är uppfyllt, exempelvis när det ursprungliga teckensnittet är otillgängligt.

**När tillämpas substitionsregler?**

Reglerna deltar i [font selection sequence](/slides/sv/java/font-selection-sequence/) under rendering och konvertering. Med `WhenInaccessible` används en regel endast när Aspose.Slides inte kan komma åt källteckensnittet.

**Vad händer om ett teckensnitt saknas och ingen substitionsregel är konfigurerad?**

Aspose.Slides väljer det närmaste tillgängliga teckensnittet enligt sin teckensnittsväljningsprocess. Resultatet beror på vilka teckensnitt som finns i körningsmiljön.

**Kan jag ladda externa teckensnitt för att undvika substitution?**

Ja. Du kan [load external fonts](/slides/sv/java/custom-font/) så att Aspose.Slides kan använda dem under rendering och konvertering.

**Distribuerar Aspose teckensnitt med biblioteket?**

Nej. Du ansvarar för att tillhandahålla teckensnitt och följa deras licensvillkor.

**Kan substitionsresultat skilja sig mellan Windows, Linux och macOS?**

Ja. Installerade teckensnitt och sökvägar för teckensnitt varierar mellan operativsystem, så ett teckensnitt som är tillgängligt på en maskin kan kräva substitution på en annan.

**Hur kan jag göra teckensnittsväljningen konsekvent i batch‑konverteringar?**

Använd samma teckensnittsfiler och versioner på varje maskin eller container, [load required external fonts](/slides/sv/java/custom-font/), och [embed fonts](/slides/sv/java/embedded-font/) när licensen tillåter det. Du kan också anropa [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) före export för att identifiera oväntade substitutioner.