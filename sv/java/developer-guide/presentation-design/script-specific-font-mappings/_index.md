---
title: Hantera skript‑specifika temateckensnitt i Java
linktitle: Skript‑specifika temateckensnitt
type: docs
weight: 15
url: /sv/java/script-specific-font-mappings/
keywords:
- skript‑specifikt teckensnitt
- tema‑teckensnittsmappning
- flerspråkig presentation
- skriftsystem
- kyrilliskt teckensnitt
- arabiskt teckensnitt
- japanskt teckensnitt
- georgiskt teckensnitt
- thaana‑teckensnitt
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Inspektera, lägg till, ersätt och ta bort skript‑specifika teckensnittsmappningar i PowerPoint‑teman med Aspose.Slides för Java."
---
## **Översikt**

Ett presentationstema kan välja olika teckensnittsfamiljer för olika skriftsystem. Detta möjliggör flerspråkig text som fortfarande använder temats teckensnitt att följa ett samordnat teckensnittsschema samtidigt som lämpliga teckensnitt används för kyrilliska, arabiska, japanska, georgiska, thaana och andra skript.

Temats [IFontScheme](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifontscheme/) innehåller en huvudteckensnittssamling som vanligtvis används för rubriker och en bi‑teckensnittssamling som vanligtvis används för brödtext. Förutom deras latin‑ och östasiskainställningar exponeras båda samlingarna mappningar från skriftsystem‑taggar till teckensnittsfamiljenamn via [IFonts](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifonts/)-gränssnittet.

Denna artikel visar hur man inspekterar och modifierar dessa mappningar i presentationens master‑tema och verifierar att förändringarna överlever en spara‑och‑läs‑om‑cykel.

## **Förstå skripttaggar**

Skriftfonthärmetoderna använder fyrabokstavs BCP‑47‑skript‑subtaggar för att identifiera skriftsystem. Vanliga värden inkluderar:

| Skripttag | Skriftsystem |
|---|---|
| `Cyrl` | Kyrilliska |
| `Arab` | Arabiska |
| `Hans` | Förenklad kinesiska |
| `Jpan` | Japanska |
| `Geor` | Georgiska |
| `Thaa` | Thaana |

Dessa mappningar tillhör temats teckensnittsschema, inte enskilda textdelar. En presentation kan definiera olika mappningar för huvud‑ och bi‑samlingarna, och den kan utelämna mappningar för vissa skript.

## **Få åtkomst till och inspektera skript‑teckensnittsmappningar**

Använd [Presentation.getMasterTheme](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getMasterTheme--) för att få åtkomst till presentationens tema. Metoderna [IFontScheme.getMajor](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifontscheme/#getMajor--) och [IFontScheme.getMinor](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifontscheme/#getMinor--) returnerar de två [IFonts](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifonts/)-samlingarna.

Anropa [IFonts.getScriptFontMap](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fonts/#getScriptFontMap--) för att hämta alla mappningar från en samling. För att slå upp ett skriftsystem, anropa [IFonts.getScriptFont](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) med dess skripttag. `getScriptFont` returnerar `null` när den samlingen inte definierar den begärda mappningen.

## **Modifiera mappningar och verifiera beständighet**

Använd [IFonts.setScriptFont](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) för att skapa en mappning eller ersätta dess nuvarande teckensnittsfamilj. Använd [IFonts.removeScriptFont](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-) för att ta bort en mappning.

Följande end‑to‑end‑exempel läser alla befintliga huvud‑ och bi‑mappningar, slår upp det japanska huvudteckensnittet, ändrar det kyrilliska huvudteckensnittet, tar bort Thaana‑bi‑mappningen, sparar presentationen och öppnar den igen för att verifiera båda förändringarna. För att göra borttagningssteget oberoende av det ursprungliga temat skapar exemplaret först en Thaana‑mappning endast om en sådan ännu inte är definierad.

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

Verifieringen använder samma `null`‑beteende som en vanlig uppslagning: efter att borttagningen har sparats returnerar `getScriptFont("Thaa")` `null` för bi‑samlingen.

## **Skilj tema‑mappningar från andra teckensnittsinställningar**

Skript‑specifika tema‑mappningar deltar i teckensnittsval, men de löser ett annat problem än direkt textformatering, ersättning och reservteckensnitt:

| Mekanism | Syfte | Effekt av att ändra en tema‑mappning |
|---|---|---|
| Skript‑specifik tema‑teckensnittsmappning | Väljer ett huvud‑ eller bi‑tema‑teckensnitt för ett skriftsystem. | Text som fortfarande använder motsvarande tema‑teckensnitt kan lösa upp till den nya mappade familjen. |
| Teckensnitt tilldelat explicit till en textdel | Fixerar den begärda teckensnittsfamiljen på den delen istället för att förlita sig på temat. | Delen kan förbli oförändrad eftersom dess direkta formatering åsidosätter temavalet. |
| Teckensnittsersättning | Ersätter ett begärt teckensnitt när det teckensnittet inte är tillgängligt eller när en ersättningsregel gäller. | Det sker efter att ett teckensnitt har begärts; det omdefinierar inte temats skript‑mappning. |
| Teckensnittsfallback | Tillhandahåller tecken som det valda teckensnittet saknar, ofta för specifika Unicode‑intervall. | Det fyller i saknad teckenstäckning; det ändrar inte den lagrade temamappningen. |

För mer information om de två sista mekanismerna, se [Teckensnittsersättning](/slides/sv/java/font-substitution/) och [Reservteckensnitt](/slides/sv/java/fallback-font/).

Att ändra en mappning i [Presentation.getMasterTheme](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getMasterTheme--) påverkar endast innehåll vars effektiva formatering fortfarande beror på det temat. Text kan istället ärva en tema‑överskrivning från en master, layout eller bild, eller använda ett explicit tilldelat teckensnitt. Inspektera dessa nivåer när det synliga resultatet inte följer presentationens temamappning.

## **Gör mappade teckensnitt tillgängliga och validera resultatet**

En skript‑mappning lagrar ett teckensnittsfamiljenamn; den installerar eller laddar inte den motsvarande teckensnittsfilen. För konsekvent rendering och export måste varje mappat teckensnitt vara installerat i miljön eller tillhandahållas till Aspose.Slides via en anpassad källa som [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) eller [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/sv/java/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--). Se [Custom Fonts](/slides/sv/java/custom-font/) för de tillgängliga laddningsalternativen.

Att verifiera den sparade mappningen bekräftar endast att temadefinitionen bevarades. Det bevisar inte att teckensnittet är tillgängligt, innehåller alla erforderliga tecken eller ger den avsedda layouten. Rendera representativ text för varje required skriftsystem till en bild eller PDF och inspektera resultatet. Detta fångar saknade teckensnitt, ofullständig teckenstäckning, fallback‑beteende och layoutförändringar innan presentationen distribueras. Se [Konvertera PowerPoint-presentationer](/slides/sv/java/convert-powerpoint/) för renderings‑ och exportexempel.

## **Vanliga frågor**

**Vad returnerar `getScriptFont` när ett skript inte är mappat?**

`[IFonts.getScriptFont](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-)` returnerar `null` när den begärda skript‑mappningen inte är definierad i den huvud‑ eller bi‑teckensnittssamlingen.

**Lägger `setScriptFont` till en andra mappning när skriptet redan finns?**

Nej. `[IFonts.setScriptFont](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-)` skapar mappningen när den saknas och ersätter den mappade teckensnittsfamiljen när samma skripttag redan finns.

**Varför ändrade en förändring av en tema‑mappning inte viss text?**

Texten kan ha ett explicit tilldelat teckensnitt, ärva ett annat tema via en överskrivning, eller påverkas av ersättning eller fallback under rendering. En skript‑mappning på presentationsnivå styr endast text vars effektiva formatering fortfarande refererar till den temateckensnittssamlingen.

**Räcker det att spara och öppna igen för att validera flerspråkig output?**

Nej. Att öppna igen verifierar beständigheten av temadata. Rendera också representativ text från varje erforderligt skriftsystem för att bekräfta att de mappade teckensnitten är tillgängliga och innehåller de nödvändiga tecknen.