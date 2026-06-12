---
title: Grafieken in presentaties opmaken in C++
linktitle: Grafiekopmaak
type: docs
weight: 60
url: /nl/cpp/chart-formatting/
keywords:
- grafiek opmaken
- grafiekopmaak
- grafiekobject
- grafiekeigenschappen
- grafiekinstellingen
- grafiekopties
- lettertype-eigenschappen
- afgeronde rand
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: Leer grafiekopmaak in Aspose.Slides voor C++ en til uw PowerPoint-presentatie naar een professioneel, opvallend uiterlijk.
---
## **Overzicht**

Dit artikel legt uit hoe je grafieken in PowerPoint‑presentaties kunt opmaken met Aspose.Slides. Het toont hoe je belangrijke grafiekelementen kunt aanpassen, zoals assen, rasterlijnen, titels, legenda’s, het plotgebied en wandvullingen, om het uiterlijk en de leesbaarheid van grafiekgegevens te verbeteren.

Het laat ook zien hoe je lettertype‑eigenschappen voor grafiekttekst instelt, standaard‑ en aangepaste numerieke opmaken op grafiekgegevens toepast, en afgeronde hoeken voor het grafiekgebied inschakelt. Samen laten deze voorbeelden zien hoe je zowel de visuele stijl als de gegevensweergave van grafieken in een presentatie kunt beheersen.

## **Grafiek‑objecten opmaken**
Aspose.Slides voor C++ stelt ontwikkelaars in staat om vanaf nul aangepaste grafieken aan hun dia’s toe te voegen. Dit artikel legt uit hoe je verschillende grafiek‑objecten kunt opmaken, inclusief de categorie‑ en waardeas van de grafiek.

Aspose.Slides voor C++ biedt een eenvoudige API voor het beheren van diverse grafiek‑objecten en het opmaken ervan met aangepaste waarden:

1. Maak een instantie van de **Presentation** klasse.
1. Verkrijg een referentie naar een dia via de index.
1. Voeg een grafiek met standaardgegevens toe, samen met een van de gewenste types (in dit voorbeeld gebruiken we ChartType.LineWithMarkers).
1. Open de **Value Axis** van de grafiek en stel de volgende eigenschappen in:
   1. Instellen van **Line format** voor de grote rasterlijnen van de Value Axis
   1. Instellen van **Line format** voor de kleine rasterlijnen van de Value Axis
   1. Instellen van **Number Format** voor de Value Axis
   1. Instellen van **Min, Max, Major and Minor units** voor de Value Axis
   1. Instellen van **Text Properties** voor de gegevens van de Value Axis
   1. Instellen van **Title** voor de Value Axis
   1. Instellen van **Line Format** voor de Value Axis
1. Open de **Category Axis** van de grafiek en stel de volgende eigenschappen in:
   1. Instellen van **Line format** voor de grote rasterlijnen van de Category Axis
   1. Instellen van **Line format** voor de kleine rasterlijnen van de Category Axis
   1. Instellen van **Text Properties** voor de gegevens van de Category Axis
   1. Instellen van **Title** voor de Category Axis
   1. Instellen van **Label Positioning** voor de Category Axis
   1. Instellen van **Rotation Angle** voor de labels van de Category Axis
1. Open de **Legend** van de grafiek en stel de **Text Properties** ervoor in
1. Laat de legenda’s van de grafiek zien zonder de grafiek te laten overlappen
1. Open de **Secondary Value Axis** van de grafiek en stel de volgende eigenschappen in:
   1. Schakel de secundaire **Value Axis** in
   1. Instellen van **Line Format** voor de Secondary Value Axis
   1. Instellen van **Number Format** voor de Secondary Value Axis
   1. Instellen van **Min, Max, Major and Minor units** voor de Secondary Value Axis
1. Plot nu de eerste grafiekserie op de Secondary Value Axis
1. Stel de achterwand van de grafiek in op een vulkleur
1. Stel de vulkleur van het plotgebied van de grafiek in
1. Schrijf de gewijzigde presentatie weg naar een PPTX‑bestand

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartEntities-ChartEntities.cpp" >}}

## **Lettertype‑eigenschappen voor een grafiek instellen**
Aspose.Slides voor C++ biedt ondersteuning voor het instellen van lettertype‑gerelateerde eigenschappen van een grafiek. Volg de onderstaande stappen om de lettertype‑eigenschappen voor een grafiek in te stellen.

- Instantieer een Presentation‑klasseobject.
- Voeg een grafiek toe aan de dia.
- Stel de letterhoogte in.
- Sla de gewijzigde presentatie op.

Hieronder staat een voorbeeldcode.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontPropertiesForChart-FontPropertiesForChart.cpp" >}}

## **Lettertype‑eigenschappen voor een grafiek‑datatabel instellen**
Aspose.Slides voor C++ ondersteunt het wijzigen van de kleur van categorieën in een seriekleur.

1. Instantieer een Presentation‑klasseobject.
1. Voeg een grafiek toe aan de dia.
1. Stel de grafiektabel in.
1. Stel de letterhoogte in.
1. Sla de gewijzigde presentatie op.

Hieronder staat een voorbeeldcode.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontPropertiesForChartDataTable-SettingFontPropertiesForChartDataTable.cpp" >}}

## **Afgeronde randen voor het grafiekgebied instellen**
Aspose.Slides voor C++ ondersteunt het instellen van het grafiekgebied. De eigenschappen **IChart.HasRoundedCorners** en **Chart.HasRoundedCorners** zijn toegevoegd in Aspose.Slides.

1. Instantieer een Presentation‑klasseobject.
1. Voeg een grafiek toe aan de dia.
1. Stel het vultype en de vulkleur van de grafiek in.
1. Schakel de eigenschap **RoundedCorners** in op True.
1. Sla de gewijzigde presentatie op.

Hieronder staat een voorbeeldcode.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingChartAreaRoundedBorders-SettingChartAreaRoundedBorders.cpp" >}}

## **Numeriek formaat instellen**
Aspose.Slides voor C++ biedt een eenvoudige API voor het beheren van het opmaakformaat van grafiekgegevens:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
1. Verkrijg een referentie naar een dia via de index.
1. Voeg een grafiek met standaardgegevens toe, samen met een van de gewenste types (dit voorbeeld gebruikt **ChartType.ClusteredColumn**).
1. Stel het voorgedefinieerde nummerformaat in via een van de mogelijke preset‑waarden.
1. Doorloop elke cel in elke grafiekserie en stel het getalformaat van de grafiekgegevens in.
1. Sla de presentatie op.
1. Stel een aangepast nummerformaat in.
1. Doorloop de gegevenscellen in elke serie en stel een verschillend nummerformaat in.
1. Sla de presentatie op.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NumberFormat-NumberFormat.cpp" >}}

| |**Mogelijke preset‑nummerformaatwaarden met hun bijbehorende index**|
| :- | :- |
|**0**|General|
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

**Kan ik halfdoorzichtige vullingen voor kolommen/gebieden gebruiken terwijl de rand ondoorzichtig blijft?**

Ja. Vultransparantie en de omlijning worden afzonderlijk geconfigureerd. Dit is nuttig om de leesbaarheid van het raster en de gegevens in dichte visualisaties te verbeteren.

**Hoe ga ik om met gegevenslabels die elkaar overlappen?**

Verklein de lettergrootte, schakel niet‑essentiële labelonderdelen uit (bijvoorbeeld categorieën), stel de offset/positie van het label in, toon alleen labels voor geselecteerde punten indien nodig, of wijzig het format naar “waarde + legenda”.

**Kan ik een verloop‑ of patroonvulling op een serie toepassen?**

Ja. Zowel effen als verloop/patroonvullingen zijn doorgaans beschikbaar. Gebruik in de praktijk verloopspaarzaam en vermijd combinaties die het contrast met het raster en de tekst verminderen.