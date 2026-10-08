---
title: "Konfigurera teckensnittssubstitution i presentationer på Android"
linktitle: "Teckensnittssubstitution"
type: docs
weight: 70
url: /sv/androidjava/font-substitution/
keywords:
- teckensnitt
- ersätta teckensnitt
- teckensnittssubstitution
- byta teckensnitt
- teckensnittsersättning
- substitutionsregel
- ersättningsregel
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Konfigurera teckensnittssubstitutionsregler och granska substituerade teckensnitt i Aspose.Slides för Android via Java när du renderar eller konverterar presentationer."
---
## **Översikt**

Teckensnittssubstitution gör att Aspose.Slides kan använda ett tillgängligt teckensnitt i stället för ett teckensnitt som inte kan nås när en presentation renderas eller konverteras. Substitutionen påverkar det renderade resultatet; den ändrar inte det teckensnitt som är tilldelat presentationens innehåll.

Du kan definiera vilket teckensnitt som ska användas när ett visst teckensnitt är otillgängligt, och du kan granska de substitutioner som Aspose.Slides kommer att göra under rendering. Detta hjälper till att hålla utdata konsekvent över Android-enheter och miljöer med olika tillgängliga teckensnitt.

Om ett teckensnitt är tillgängligt men saknar en dedikerad fet stil, se [Hantera teckensnitt utan en dedikerad fet stil](/slides/sv/androidjava/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Det avsnittet förklarar hur man rasteriserar den påverkade texten under PDF-export och vilka konsekvenser det har för textmarkering, sökning och skalning.

## **Hämta teckensnittssubstitutioner**

Använd metoden [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) för att avgöra vilka teckensnitt som kommer att substitueras när presentationen renderas. Metoden returnerar [FontSubstitutionInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstitutioninfo/)‑objekt som identifierar de ursprungliga och ersatta teckensnittsnamnen.

Följande Java‑exempel listar alla teckensnittssubstitutioner för en presentation:

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

## **Hämta teckensnittssubstitutioner för valda bilder**

Använd överlagringen [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) med ett `int[] slides`‑argument för att undersöka endast de substitutioner som krävs för att rendera specifika bilder. Detta är användbart när du renderar eller exporterar en del av en presentation, kontrollerar en stor presentation inkrementellt, lokaliserar bilder som är beroende av otillgängliga teckensnitt, förbereder ett minimalt teckensnittspaket för en Android-app eller diagnostiserar renderingsskillnader utan att bearbeta orelaterade bilder.

`slides`‑arrayen innehåller ett‑baserade bildindex: `1` identifierar den första bilden. Till skillnad från detta använder [Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) samlingsåtkomst nollbaserad indexering, så samma bild nås som `presentation.getSlides().get_Item(0)`. Ha denna skillnad i åtanke när du bygger arrayen för att undvika av‑lusningsfel.

Anropa överlagringen via metoden [Presentation.getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getFontsManager--). Den returnerar endast de substitutioner som bestämdes under rendering av de valda bilderna. Varje resultat är ett [FontSubstitutionInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstitutioninfo/)‑objekt som innehåller de ursprungliga och ersatta teckensnittsnamnen. Resultatet speglar den aktuella teckensnittsmiljön, konfigurerade reservregler, substitutionsregler lagrade i en [IFontSubstRuleCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsubstrulecollection/) och [externt laddade teckensnitt](/slides/sv/androidjava/custom-font/).

Samma substitution kan krävas av mer än en vald bild. Döpa av dubbletter i resultaten när du skapar ett teckensnittsinventarium eller en förhandsgranskningsrapport. Följande exempel rapporterar varje returnerad substitution och skapar sedan en sorterad lista över unika teckensnittsmappningar:

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

Gränssnittet [IFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/) erbjuder båda överlagringarna. Välj en enligt omfattningen av renderingsoperationen:

| Överlagring | Använd när |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) med inga argument | Du behöver substitutioner för hela presentationen. |
| [getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) med `int[] slides` | Du behöver substitutioner för ett valt intervall, inkrementell kontroll eller partiell export. |

## **Ange teckensnittssubstitutionsregler**

För att ange vilket teckensnitt som Aspose.Slides ska använda när ett källteckensnitt är otillgängligt:

1. Läs in presentationen.
2. Skapa teckensnittdefinitioner för käll- och ersättningsteckensnitten.
3. Skapa en [FontSubstRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrule/) med villkoret [WhenInaccessible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstcondition/).
4. Lägg till regeln i en [FontSubstRuleCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrulecollection/).
5. Tilldela samlingen genom att använda metoden [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).
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
För en ovillkorlig förändring av de teckensnitt som används i hela presentationen, se [Teckensnittsersättning](/slides/sv/androidjava/font-replacement/).
{{% /alert %}}

## **Begränsningar för matematiska ekvationsteckensnitt**

Teckensnittssubstitutionsregler är en del av den standardprocess för teckensnittsväljning som används under rendering och konvertering. De fungerar för vanlig text när Aspose.Slides kan ersätta ett otillgängligt teckensnitt med det tillgängliga teckensnitt som anges i en regel.

Office Math‑ekvationer har ett extra krav. Om en ekvation använder **Cambria Math** kan Aspose.Slides behöva exakt det teckensnittet för att beräkna och rendera ekvationens layout. En regel som substituerar ett annat matte‑teckensnitt, såsom **STIX Two Math**, kan inte ersätta **Cambria Math** för detta ändamål, och rendering kan fortfarande rapportera att **Cambria Math** krävs.

För att rendera eller konvertera en sådan presentation, gör **Cambria Math** tillgängligt för Aspose.Slides. Ladda det som ett [externt teckensnitt](/slides/sv/androidjava/custom-font/) så att applikationen kan använda det under rendering och konvertering.

Denna begränsning gäller ekvationslayouten. Substitutionsreglerna som beskrivits ovan gäller fortfarande för vanlig presentationstext.

## **Vanliga frågor**

**Vad är skillnaden mellan teckensnittsersättning och teckensnittssubstitution?**

[Teckensnittsersättning](/slides/sv/androidjava/font-replacement/) ändrar medvetet ett teckensnitt till ett annat i hela presentationen. Teckensnittssubstitution väljer ett teckensnitt för den renderade utdata när det konfigurerade villkoret är uppfyllt, till exempel när det ursprungliga teckensnittet är otillgängligt.

**När tillämpas substitueringsregler?**

Reglerna deltar i [teckensnittsväljningssekvensen](/slides/sv/androidjava/font-selection-sequence/) under rendering och konvertering. Med `WhenInaccessible` används en regel endast när Aspose.Slides inte kan nå källteckensnittet.

**Vad händer när ett teckensnitt saknas och ingen substitueringsregel är konfigurerad?**

Aspose.Slides väljer det närmaste tillgängliga teckensnittet enligt sin teckensnittsväljningsprocess. Resultatet beror på vilka teckensnitt som finns tillgängliga i körningsmiljön.

**Kan jag ladda externa teckensnitt för att undvika substitution?**

Ja. Du kan [ladda externa teckensnitt](/slides/sv/androidjava/custom-font/) så att Aspose.Slides kan använda dem under rendering och konvertering.

**Distribuerar Aspose teckensnitt med biblioteket?**

Nej. Du ansvarar för att tillhandahålla teckensnitt och följa deras licenser.

**Kan substitueringsresultat skilja sig mellan Android-enheter?**

Ja. Tillgängliga systemteckensnitt kan skilja sig mellan Android-versioner, enheter och leverantörer, så ett teckensnitt som finns i en miljö kan kräva substitution i en annan.

**Hur kan jag göra teckensnittsväljning konsekvent över Android-enheter?**

Paketera samma nödvändiga teckensnitts‑filer med applikationen, [ladda dem som externa teckensnitt](/slides/sv/androidjava/custom-font/) och [bädda in teckensnitt](/slides/sv/androidjava/embedded-font/) när licensen tillåter det. Du kan även anropa [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) före export för att identifiera oväntade substitutioner.