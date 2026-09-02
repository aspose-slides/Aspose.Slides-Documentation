---
title: Hantera skript‑specifika temateckensnitt på Android
linktitle: Skript‑specifika temateckensnitt
type: docs
weight: 15
url: /sv/androidjava/script-specific-font-mappings/
keywords:
- skript‑specifikt teckensnitt
- temateckensnittsmappning
- flerspråkig presentation
- skriftsystem
- kyrilliskt teckensnitt
- arabiskt teckensnitt
- japanskt teckensnitt
- georgiskt teckensnitt
- thaana‑teckensnitt
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Inspektera, lägg till, ersätt och ta bort skript‑specifika teckensnittsmappningar i PowerPoint‑teman med Aspose.Slides för Android via Java."
---
## **Översikt**

Ett presentationstema kan välja olika teckensnittsfamiljer för olika skriftsystem. Detta gör att flerspråkig text som fortfarande använder temats teckensnitt kan följa ett samordnat teckensnittsschema samtidigt som lämpliga teckensnitt används för kyrilliska, arabiska, japanska, georgiska, thaana och andra skript.

Temats [IFontScheme](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifontscheme/) innehåller en huvudteckensnittssamling, som vanligtvis används för rubriker, och en bi‑teckensnittssamling, som vanligtvis används för brödtext. Förutom deras latinska och östasiska teckensnittsinställningar exponeras mappningar från skriftsystem‑taggar till teckensnittsfamiljenamn via gränssnittet [IFonts](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifonts/).

Den här artikeln visar hur du inspekterar och ändrar de mappningarna i presentationens huvudtema och verifierar att ändringarna överlever en spara‑och‑ladda‑cykel.

## **Förstå skripttaggar**

Skriptteckensnittsmetoderna använder fyrbokstaviga BCP 47‑skript‑subtaggar för att identifiera skriftsystem. Vanliga värden inkluderar:

| Skripttagg | Skriftsystem |
|---|---|
| `Cyrl` | Kyrilliskt |
| `Arab` | Arabiskt |
| `Hans` | Förenklad kinesiska |
| `Jpan` | Japanska |
| `Geor` | Georgiskt |
| `Thaa` | Thaana |

Dessa mappningar tillhör temats teckensnittsschema, inte enskilda textavsnitt. En presentation kan definiera olika mappningar för huvud‑ och bi‑samlingarna, och den kan utelämna mappningar för vissa skript.

## **Åtkomst och inspektion av skriptteckensnittsmappningar**

Använd [Presentation.getMasterTheme](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getMasterTheme--) för att komma åt temat på presentationsnivå. Metoderna [IFontScheme.getMajor](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifontscheme/#getMajor--) och [IFontScheme.getMinor](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifontscheme/#getMinor--) returnerar de två [IFonts](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifonts/)‑samlingarna.

Anropa [IFonts.getScriptFontMap](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fonts/#getScriptFontMap--) för att hämta alla mappningar från en samling. För att slå upp ett skriftsystem, anropa [IFonts.getScriptFont](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) med dess skripttagg. `getScriptFont` returnerar `null` när den samlingen inte definierar den begärda mappningen.

## **Ändra mappningar och verifiera beständighet**

Använd [IFonts.setScriptFont](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) för att skapa en mappning eller ersätta dess nuvarande teckensnittsfamilj. Använd [IFonts.removeScriptFont](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-) för att ta bort en mappning.

Följande end‑to‑end‑exempel läser alla befintliga huvud‑ och bi‑mappningar, slår upp det japanska huvudteckensnittet, ändrar det kyrilliska huvudteckensnittet, tar bort Thaana‑bi‑mappningen, sparar presentationen och öppnar den igen för att verifiera båda ändringarna. För att göra borttagningssteget oberoende av det ursprungliga temat skapar exemplet först en Thaana‑mappning endast när en sådan ännu inte är definierad.

```java
import com.aspose.slides.*;
import com.aspose.slides.Collections.Generic.Dictionary;
import com.aspose.slides.Collections.Generic.KeyValuePair;

Presentation presentation = new Presentation();
try {
    IFontScheme fontScheme = presentation.getMasterTheme().getFontScheme();
    IFonts majorFonts = fontScheme.getMajor();
    IFonts minorFonts = fontScheme.getMinor();

    System.out.println("Existing major mappings:");
    Dictionary.Enumerator<String, String> majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = majorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    System.out.println("Existing minor mappings:");
    Dictionary.Enumerator<String, String> minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = minorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    String japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        System.out.println("No major Japanese font is defined.");
    } else {
        System.out.println("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    IFonts savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    IFonts savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    String savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    String savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if ("Arial".equals(savedCyrillicFont)) {
        System.out.println("The Cyrillic mapping was preserved.");
    } else {
        System.out.println("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        System.out.println("The Thaana mapping removal was preserved.");
    } else {
        System.out.println("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

Verifikationen använder samma `null`‑beteende som en vanlig uppslagning: efter att borttagningen sparats returnerar `getScriptFont("Thaa")` `null` för bi‑samlingen.

## **Skilja temamappningar från andra teckensnittsinställningar**

Skript‑specifika temamappningar deltar i teckensnittsurval, men de löser ett annat problem än direkt textformatering, substitution och reservteckensnitt:

| Mekanism | Syfte | Effekt av att ändra ett temamappning |
|---|---|---|
| Skript‑specifik temateckensnittsmappning | Väljer ett huvud‑ eller bi‑temateckensnitt för ett skriftsystem. | Text som fortfarande använder motsvarande temateckensnitt kan lösa till den nya mappade familjen. |
| Teckensnitt som tilldelas explicit till ett textavsnitt | Fixerar den begärda teckensnittsfamiljen för det avsnittet i stället för att förlita sig på temat. | Avsnittet kan förbli oförändrat eftersom dess direkta formatering åsidosätter tema‑valet. |
| Teckensnittssubstitution | Ersätter ett begärt teckensnitt när det är otillgängligt eller när en substitutionsregel gäller. | Den sker efter att ett teckensnitt har begärts; den omdefinierar inte temats skript‑mappning. |
| Reservteckensnitt | Tillhandahåller tecken som det valda teckensnittet saknar, ofta för specifika Unicode‑intervall. | Det fyller i saknade tecken; det ändrar inte den sparade temamappningen. |

För mer information om de två sista mekanismerna, se [Font Substitution](/slides/sv/androidjava/font-substitution/) och [Fallback Fonts](/slides/sv/androidjava/fallback-font/).

Att ändra en mappning i [Presentation.getMasterTheme](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getMasterTheme--) påverkar endast innehåll vars effektiva formatering fortfarande beror på det temat. Text kan istället ärva ett temaisnitt från ett master‑, layout‑ eller bild‑tema, eller använda ett explicit tilldelat teckensnitt. Inspektera dessa nivåer när det synliga resultatet inte följer presentationens temamappning.

## **Gör mappade teckensnitt tillgängliga och validera resultatet**

En skript‑mappning lagrar ett teckensnittsfamiljenamn; den installerar eller laddar inte den motsvarande teckensnittsfilen. För konsekvent rendering och export måste varje mappat teckensnitt vara installerat i miljön eller tillhandahållas till Aspose.Slides via en anpassad källa såsom [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) eller [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--). Se [Custom Fonts](/slides/sv/androidjava/custom-font/) för de tillgängliga laddningsalternativen.

Att verifiera den sparade mappningen bekräftar endast att temadefinitionen bevarades. Det bevisar inte att teckensnittet är tillgängligt, innehåller alla nödvändiga tecken eller ger den avsedda layouten. Rendera representativ text för varje krävt skriftsystem till en bild eller PDF och inspektera resultatet. Detta fångar saknade teckensnitt, ofullständig teckentäckning, reserv‑beteende och layoutförändringar innan presentationen distribueras. Se [Convert PowerPoint Presentations](/slides/sv/androidjava/convert-powerpoint/) för renderings‑ och exportexempel.

## **FAQ**

**Vad returnerar `getScriptFont` när ett skript inte är mappat?**

[IFonts.getScriptFont](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) returnerar `null` när den begärda skript‑mappningen inte är definierad i den huvud‑ eller bi‑teckensnittssamlingen.

**Lägger `setScriptFont` till en andra mappning när skriptet redan finns?**

Nej. [IFonts.setScriptFont](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) skapar mappningen när den saknas och ersätter den mappade teckensnittsfamiljen när samma skripttagg redan finns.

**Varför ändrade en temamappning inte viss text?**

Texten kan ha ett explicit tilldelat teckensnitt, ärva ett annat tema via en åsidosättning, eller påverkas av substitution eller reservteckensnitt under rendering. En skript‑mappning på presentationsnivå styr endast text vars effektiva formatering fortfarande hänvisar till den temateckensnittssamlingen.

**Räcker det att spara och öppna igen för att validera flerspråkig utskrift?**

Nej. Att öppna igen verifierar beständighet av temadata. Dessutom bör du rendera representativ text från varje krävt skriftsystem för att bekräfta att de mappade teckensnitten är tillgängliga och innehåller nödvändiga tecken.