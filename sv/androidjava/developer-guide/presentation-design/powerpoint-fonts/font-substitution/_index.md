---
title: Konfigurera teckensnittsersättning i presentationer på Android
linktitle: Teckensnittsersättning
type: docs
weight: 70
url: /sv/androidjava/font-substitution/
keywords:
- teckensnitt
- ersätt teckensnitt
- teckensnittsersättning
- byta teckensnitt
- teckensnittbyte
- ersättningsregel
- bytregel
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Konfigurera teckensnittsersättningsregler och granska ersatta teckensnitt i Aspose.Slides för Android via Java när du renderar eller konverterar presentationer."
---
## **Översikt**

Font substitution gör att Aspose.Slides kan använda ett tillgängligt teckensnitt i stället för ett teckensnitt som inte går att komma åt när en presentation renderas eller konverteras. Ersättningen påverkar den renderade outputen; den ändrar inte teckensnittet som är tilldelat presentationens innehåll.

Du kan definiera vilket teckensnitt som ska användas när ett specifikt teckensnitt är otillgängligt, och du kan inspektera de ersättningar som Aspose.Slides kommer att göra under rendering. Detta hjälper till att hålla utdata konsekvent över Android‑enheter och miljöer med olika tillgängliga teckensnitt.

## **Hämta teckensnittsersättningar**

Använd metoden [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) för att avgöra vilka teckensnitt som kommer att ersättas när presentationen renderas. Metoden returnerar [FontSubstitutionInfo](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontsubstitutioninfo/)-objekt som identifierar de ursprungliga och ersatta teckensnittsnamnen.

Följande Java‑exempel listar alla teckensnittsersättningar för en presentation:

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

## **Hämta teckensnittsersättningar för markerade bilder**

Använd overload‑versionen av [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) med argumentet `int[] slides` för att bara inspektera ersättningar som krävs för att rendera specifika bilder. Detta är användbart när du renderar eller exporterar en del av en presentation, kontrollerar en stor presentation inkrementellt, letar efter bilder som beror på otillgängliga teckensnitt, förbereder ett minimalt teckensnittspaket för en Android‑app eller diagnostiserar renderingsskillnader utan att bearbeta orelaterade bilder.

`slides`‑arrayen innehåller 1‑baserade bildindex: `1` identifierar den första bilden. Till skillnad från samlingsåtkomsten [Presentation.getSlides](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getSlides--) som använder 0‑baserad indexering, nås samma bild som `presentation.getSlides().get_Item(0)`. Ha detta i åtanke när du bygger arrayen för att undvika fel med en förskjutning.

Anropa overload‑versionen via metoden [Presentation.getFontsManager](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getFontsManager--). Den returnerar endast de ersättningar som fastställts under rendering av de valda bilderna. Varje resultat är ett [FontSubstitutionInfo](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontsubstitutioninfo/)-objekt som innehåller de ursprungliga och ersatta teckensnittsnamnen. Resultatet speglar den aktuella teckensnittsmiljön, konfigurerade reservregler, ersättningsregler lagrade i en [IFontSubstRuleCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifontsubstrulecollection/), samt [externally loaded fonts](/slides/sv/androidjava/custom-font/).

Samma ersättning kan krävas av fler än en vald bild. Deduplikera resultaten när du skapar ett teckensnittsinventarium eller en förhandsgranskningsrapport. Följande exempel rapporterar varje returnerad ersättning och skapar sedan en sorterad lista med unika teckensnittskartor:

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

[IFontsManager](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifontsmanager/)-gränssnittet erbjuder båda overload‑versionerna. Välj den som passar omfattningen av renderingsoperationen:

| Överlagring | Använd när |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) utan argument | Du behöver ersättningar för hela presentationen. |
| [getSubstitutions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) med `int[] slides` | Du behöver ersättningar för ett valt intervall, inkrementell kontroll eller partiell export. |

## **Ange teckensnittsersättningsregler**

För att specificera vilket teckensnitt Aspose.Slides ska använda när ett källteckensnitt är otillgängligt:

1. Läs in presentationen.  
2. Skapa teckensnittsdefinitioner för käll‑ och ersättningsteckensnitt.  
3. Skapa ett [FontSubstRule](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontsubstrule/) med villkoret [WhenInaccessible](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontsubstcondition/).  
4. Lägg till regeln i en [FontSubstRuleCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontsubstrulecollection/).  
5. Tilldela samlingen med metoden [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).  
6. Rendera eller konvertera presentationen.

Följande Java‑exempel ersätter `Arial` med `SomeRareFont` när `SomeRareFont` är otillgängligt, och renderar sedan den första bilden för att verifiera resultatet. Ersättningsteckensnittet måste vara tillgängligt för Aspose.Slides.

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

{{% alert color="info" title="Obs" %}}
För en villkorslös förändring av de teckensnitt som används i hela presentationen, se [Font Replacement](/slides/sv/androidjava/font-replacement/).
{{% /alert %}}

## **Begränsningar för matematiska ekvationsteckensnitt**

Teckensnittsersättningsregler är en del av den standardiserade teckensnittsväljningsprocessen som används under rendering och konvertering. De fungerar för vanlig text när Aspose.Slides kan ersätta ett otillgängligt teckensnitt med det tillgängliga teckensnitt som anges i en regel.

Office‑Math‑ekvationer har ett extra krav. Om en ekvation använder **Cambria Math** kan Aspose.Slides behöva exakt detta teckensnitt för att beräkna och rendera ekvationslayouten. En regel som ersätter med ett annat matematiskt teckensnitt, t.ex. **STIX Two Math**, kan inte ersätta **Cambria Math** för detta ändamål, och renderingen kan fortfarande rapportera att **Cambria Math** krävs.

För att rendera eller konvertera en sådan presentation, gör **Cambria Math** tillgängligt för Aspose.Slides. Ladda det som ett [external font](/slides/sv/androidjava/custom-font/) så att applikationen kan använda det under rendering och konvertering.

Denna begränsning gäller endast ekvationslayouten. Ersättningsreglerna ovan gäller fortfarande för vanlig presentationstext.

## **Vanliga frågor**

**Vad är skillnaden mellan font replacement och font substitution?**

[Font replacement](/slides/sv/androidjava/font-replacement/) ändrar avsiktligt ett teckensnitt till ett annat i hela presentationen. Font substitution väljer ett teckensnitt för den renderade outputen när det konfigurerade villkoret är uppfyllt, exempelvis när det ursprungliga teckensnittet är otillgängligt.

**När tillämpas ersättningsregler?**

Reglerna deltar i [font selection sequence](/slides/sv/androidjava/font-selection-sequence/) under rendering och konvertering. Med `WhenInaccessible` används en regel endast när Aspose.Slides inte kan komma åt källteckensnittet.

**Vad händer om ett teckensnitt saknas och ingen ersättningsregel är konfigurerad?**

Aspose.Slides väljer det närmaste tillgängliga teckensnittet enligt sin teckensnittsväljningsprocess. Resultatet beror på vilka teckensnitt som finns i runtime‑miljön.

**Kan jag ladda externa teckensnitt för att undvika ersättning?**

Ja. Du kan [load external fonts](/slides/sv/androidjava/custom-font/) så att Aspose.Slides kan använda dem under rendering och konvertering.

**Distribuerar Aspose teckensnitt med biblioteket?**

Nej. Du ansvarar för att tillhandahålla teckensnitt och följa deras licensvillkor.

**Kan ersättningsresultat skilja sig mellan Android‑enheter?**

Ja. Tillgängliga systemteckensnitt kan variera mellan Android‑versioner, enheter och leverantörer, så ett teckensnitt som finns i en miljö kan behöva ersättas i en annan.

**Hur kan jag göra teckensnittsväljning konsekvent över Android‑enheter?**

Paketera samma erforderliga teckensnittsfiler med applikationen, [load them as external fonts](/slides/sv/androidjava/custom-font/), och [embed fonts](/slides/sv/androidjava/embedded-font/) när licenser tillåter det. Du kan också anropa [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) före export för att identifiera oväntade ersättningar.