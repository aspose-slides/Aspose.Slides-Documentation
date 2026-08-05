---
title: Diagrammen in Presentaties Formatteren in C++
linktitle: Diagramopmaak
type: docs
weight: 60
url: /nl/cpp/chart-formatting/
keywords:
- diagram opmaken
- diagramopmaak
- diagramonderdeel
- diagrameigenschappen
- diagraminstellingen
- diagramopties
- lettertype-eigenschappen
- afgeronde rand
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer diagramopmaak in Aspose.Slides voor C++ en til uw PowerPoint-presentatie naar een professioneel, opvallend uiterlijk."
---
## **Overzicht**

Dit artikel legt uit hoe je diagrammen in PowerPoint‑presentaties kunt opmaken met Aspose.Slides. Het laat zien hoe je belangrijke diagramonderdelen zoals assen, rasterlijnen, titels, legenda’s, het plot‑gebied en wand‑vullingen kunt aanpassen om het uiterlijk en de leesbaarheid van diagramgegevens te verbeteren.

Het toont ook hoe je lettertype‑eigenschappen voor diagramtekst kunt instellen, vooraf ingestelde en aangepaste numerieke opmaken op diagramgegevens kunt toepassen, en afgeronde hoeken voor het diagramgebied kunt inschakelen. Samen laten deze voorbeelden zien hoe je zowel de visuele stijl als de weergave van gegevens in diagrammen van een presentatie kunt beheersen.

## **Diagramonderdelen Opmaak**
Aspose.Slides for C++ stelt ontwikkelaars in staat aangepaste diagrammen vanaf nul aan hun dia’s toe te voegen. Dit artikel legt uit hoe je verschillende diagramonderdelen kunt opmaken, inclusief categorie‑ en waardenas.

Aspose.Slides for C++ biedt een eenvoudige API voor het beheren van verschillende diagramonderdelen en het opmaken ervan met aangepaste waarden:

1. Maak een instantie van de **Presentation**‑klasse.
1. Verkrijg een verwijzing naar de dia op basis van zijn index.
1. Voeg een diagram toe met standaardgegevens en een van de gewenste typen (in dit voorbeeld gebruiken we ChartType.LineWithMarkers).
1. Toegang tot de Value Axis van het diagram en stel de volgende eigenschappen in:
   1. Instellen van **Line format** voor Value Axis Major Grid‑lines
   1. Instellen van **Line format** voor Value Axis Minor Grid‑lines
   1. Instellen van **Number Format** voor Value Axis
   1. Instellen van **Min, Max, Major and Minor units** voor Value Axis
   1. Instellen van **Text Properties** voor Value Axis‑gegevens
   1. Instellen van **Title** voor Value Axis
   1. Instellen van **Line Format** voor Value Axis
1. Toegang tot de Category Axis van het diagram en stel de volgende eigenschappen in:
   1. Instellen van **Line format** voor Category Axis Major Grid‑lines
   1. Instellen van **Line format** voor Category Axis Minor Grid‑lines
   1. Instellen van **Text Properties** voor Category Axis‑gegevens
   1. Instellen van **Title** voor Category Axis
   1. Instellen van **Label Positioning** voor Category Axis
   1. Instellen van **Rotation Angle** voor Category Axis‑labels
1. Toegang tot de Legend van het diagram en stel de **Text Properties** daarvoor in
1. Stel in dat diagram‑legenda’s getoond worden zonder het diagram te overlappen
1. Toegang tot de **Secondary Value Axis** van het diagram en stel de volgende eigenschappen in:
   1. Schakel de Secondary **Value Axis** in
   1. Instellen van **Line Format** voor Secondary Value Axis
   1. Instellen van **Number Format** voor Secondary Value Axis
   1. Instellen van **Min, Max, Major and Minor units** voor Secondary Value Axis
1. Plot nu de eerste diagramreeks op de Secondary Value Axis
1. Stel de achterwand van het diagram in op een vulkleur
1. Stel de vulkleur van het plot‑gebied van het diagram in
1. Schrijf de gewijzigde presentatie weg naar een PPTX‑bestand

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartEntities-ChartEntities.cpp" >}}

## **Lettertype‑eigenschappen Instellen voor een Diagram**
Aspose.Slides for C++ biedt ondersteuning voor het instellen van lettertype‑gerelateerde eigenschappen voor het diagram. Volg de onderstaande stappen om de lettertype‑eigenschappen voor een diagram in te stellen.

- Maak een **Presentation**‑object aan.
- Voeg een diagram toe op de dia.
- Stel de lettergrootte in.
- Sla de gewijzigde presentatie op.

Onderstaand voorbeeld geeft een voorbeeldcode.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontPropertiesForChart-FontPropertiesForChart.cpp" >}}

## **Lettertype‑eigenschappen Instellen voor een Diagram‑tabel**
Aspose.Slides for C++ biedt ondersteuning voor het wijzigen van de kleur van categorieën in een reeks.

1. Maak een **Presentation**‑object aan.
1. Voeg een diagram toe op de dia.
1. Stel de diagram‑tabel in.
1. Stel de lettergrootte in.
1. Sla de gewijzigde presentatie op.

Onderstaand voorbeeld geeft een voorbeeldcode.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontPropertiesForChartDataTable-SettingFontPropertiesForChartDataTable.cpp" >}}

## **Afgeronde Randen voor Diagramgebied Instellen**
Aspose.Slides for C++ biedt ondersteuning voor het instellen van het diagramgebied. De eigenschappen **IChart.HasRoundedCorners** en **Chart.HasRoundedCorners** zijn toegevoegd in Aspose.Slides.

1. Maak een **Presentation**‑object aan.
1. Voeg een diagram toe op de dia.
1. Stel het vultype en de vulkleur van het diagram in.
1. Schakel de eigenschap voor ronde hoeken in (True).
1. Sla de gewijzigde presentatie op.

Onderstaand voorbeeld geeft een voorbeeldcode.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingChartAreaRoundedBorders-SettingChartAreaRoundedBorders.cpp" >}}

## **Numeriek Formaat Instellen**
Aspose.Slides for C++ biedt een eenvoudige API voor het beheren van het diagram‑gegevensformaat:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.
1. Verkrijg een verwijzing naar de dia op basis van zijn index.
1. Voeg een diagram toe met standaardgegevens en een van de gewenste typen (dit voorbeeld gebruikt **ChartType.ClusteredColumn**).
1. Stel het vooraf ingestelde nummerformaat in op basis van de mogelijke preset‑waarden.
1. Doorloop elke diagramreeks en stel het nummerformaat van de diagramgegevenscellen in.
1. Sla de presentatie op.
1. Stel een aangepast nummerformaat in.
1. Doorloop de diagramgegevenscellen in elke reeks en stel een ander nummerformaat in.
1. Sla de presentatie op.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NumberFormat-NumberFormat.cpp" >}}

| |**De mogelijke preset‑nummerformaatwaarden met hun preset‑index die kunnen worden gebruikt, staan hieronder:**|
| :- | :- |
|**0**|Algemeen|
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

|||
| :- | :- |

## **FAQ**

**Kan ik halfdoorzichtige vullingen voor kolommen/gebieden instellen terwijl de rand ondoorzichtig blijft?**

Ja. Vullingstransparantie en de omtrek worden afzonderlijk geconfigureerd. Dit is handig om de leesbaarheid van het raster en de gegevens in dichte visualisaties te verbeteren.

**Hoe ga ik om met gegevenslabels wanneer ze overlappen?**

Verminder de lettergrootte, schakel niet‑essentiële labelonderdelen uit (bijvoorbeeld categorieën), stel de offset/positie van het label in, toon alleen labels voor geselecteerde punten indien nodig, of wijzig het formaat naar “waarde + legenda”.

**Kan ik verloop‑ of patroonvullingen op reeksen toepassen?**

Ja. Zowel effen als verloop‑/patroonvullingen zijn doorgaans beschikbaar. Gebruik in de praktijk verlopen spaarzaam en vermijd combinaties die het contrast met het raster en de tekst verminderen.