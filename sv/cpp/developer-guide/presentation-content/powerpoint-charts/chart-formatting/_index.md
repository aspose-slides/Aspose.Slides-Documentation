---
title: Formatera presentationsdiagram i C++
linktitle: Diagramformatering
type: docs
weight: 60
url: /sv/cpp/chart-formatting/
keywords:
- formatera diagram
- diagramformatering
- diagramobjekt
- diagramegenskaper
- diagraminställningar
- diagramalternativ
- teckensnittsegenskaper
- rundade kanter
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Lär dig diagramformatering i Aspose.Slides för C++ och höj din PowerPoint-presentation med professionell, iögonfallande stil."
---
## **Översikt**

Den här artikeln förklarar hur man formaterar diagram i PowerPoint‑presentationer med Aspose.Slides. Den visar hur man anpassar viktiga diagramdelar såsom axlar, rutnätslinjer, titlar, förklaringar, plotområdet och väggfyllningar för att förbättra utseendet och läsbarheten av diagramdata. Den demonstrerar också hur man anger teckenegenskaper för diagramtext, använder förinställda och anpassade numeriska format för diagramdata samt aktiverar rundade hörn för diagramområdet. Tillsammans visar dessa exempel hur man styr både den visuella stilen och datapresentationen för diagram i en presentation.

## **Formatera diagramobjekt**
Aspose.Slides för C++ låter utvecklare lägga till anpassade diagram i sina bilder från grunden. Den här artikeln förklarar hur man formaterar olika diagramobjekt inklusive diagramkategori‑ och värdeaxel.

Aspose.Slides för C++ erbjuder ett enkelt API för att hantera olika diagramobjekt och formatera dem med anpassade värden:

1. Skapa en instans av **Presentation**‑klassen.
1. Hämta en bilds referens via dess index.
1. Lägg till ett diagram med standarddata av någon av de önskade typerna (i detta exempel använder vi ChartType.LineWithMarkers).
1. Åtkomst till diagrammets värdeaxel och ställ in följande egenskaper:
   1. Ställ in **Line format** för värdeaxelns stora rutnätslinjer
   1. Ställ in **Line format** för värdeaxelns små rutnätslinjer
   1. Ställ in **Number Format** för värdeaxeln
   1. Ställ in **Min, Max, Major and Minor units** för värdeaxeln
   1. Ställ in **Text Properties** för värdeaxelns data
   1. Ställ in **Title** för värdeaxeln
   1. Ställ in **Line Format** för värdeaxeln
1. Åtkomst till diagrammets kategoriaxel och ställ in följande egenskaper:
   1. Ställ in **Line format** för kategoriaxelns stora rutnätslinjer
   1. Ställ in **Line format** för kategoriaxelns små rutnätslinjer
   1. Ställ in **Text Properties** för kategoriaxelns data
   1. Ställ in **Title** för kategoriaxeln
   1. Ställ in **Label Positioning** för kategoriaxeln
   1. Ställ in **Rotation Angle** för kategoriaxelns etiketter
1. Åtkomst till diagrammets förklaring och ställ in **Text Properties** för dem
1. Ställ in att visa diagramförklaringar utan att de överlappar diagrammet
1. Åtkomst till diagrammets **Secondary Value Axis** och ställ in följande egenskaper:
   1. Aktivera den sekundära **Value Axis**
   1. Ställ in **Line Format** för den sekundära värdeaxeln
   1. Ställ in **Number Format** för den sekundära värdeaxeln
   1. Ställ in **Min, Max, Major and Minor units** för den sekundära värdeaxeln
1. Plotta nu den första diagramserien på den sekundära värdeaxeln
1. Ställ in diagrammets bakre vägg till fyllnadsfärg
1. Ställ in diagrammets plotområde fyllningsfärg
1. Skriv den modifierade presentationen till en PPTX‑fil

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartEntities-ChartEntities.cpp" >}}

## **Ställ in teckensnittsegenskaper för ett diagram**
Aspose.Slides för C++ erbjuder stöd för att ange teckenrelaterade egenskaper för diagrammet. Följ stegen nedan för att ställa in teckensnittsegenskaper för diagrammet.

- Instansiera **Presentation**‑klassobjektet.
- Lägg till diagram på bilden.
- Ange teckenhöjd.
- Spara den modifierade presentationen.

Nedan följer ett exempel.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontPropertiesForChart-FontPropertiesForChart.cpp" >}}

## **Ställ in teckensnittsegenskaper för en diagramdatatabell**
Aspose.Slides för C++ erbjuder stöd för att ändra färg på kategorier i en seriefärg.

1. Instansiera **Presentation**‑klassobjektet.
1. Lägg till diagram på bilden.
1. Ställ in diagramtabell.
1. Ange teckenhöjd.
1. Spara den modifierade presentationen.

Nedan följer ett exempel.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontPropertiesForChartDataTable-SettingFontPropertiesForChartDataTable.cpp" >}}

## **Ställ in rundade kanter för diagramområdet**
Aspose.Slides för C++ erbjuder stöd för att ställa in diagramområdet. Egenskaperna **IChart.HasRoundedCorners** och **Chart.HasRoundedCorners** har lagts till i Aspose.Slides.

1. Instansiera **Presentation**‑klassobjektet.
1. Lägg till diagram på bilden.
1. Ange fyllningstyp och fyllningsfärg för diagrammet
1. Ställ in egenskapen för rundade hörn till True.
1. Spara den modifierade presentationen.

Nedan följer ett exempel.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingChartAreaRoundedBorders-SettingChartAreaRoundedBorders.cpp" >}}

## **Ställ in numeriskt format**
Aspose.Slides för C++ erbjuder ett enkelt API för att hantera diagramdatans format:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) .
1. Hämta en bilds referens via dess index.
1. Lägg till ett diagram med standarddata av någon av de önskade typerna (i detta exempel används **ChartType.ClusteredColumn**).
1. Ställ in det förinställda nummerformatet från de möjliga förinställningarna.
1. Gå igenom diagramdatacellerna i varje diagramserie och ange diagramdatans nummerformat.
1. Spara presentationen.
1. Ange ett anpassat nummerformat.
1. Gå igenom diagramdatacellerna i varje diagramserie och ange ett annat nummerformat för diagramdata.
1. Spara presentationen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NumberFormat-NumberFormat.cpp" >}}

| |**De möjliga förinställda nummerformatvärdena och deras index som kan användas ges nedan:**|
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

## **Vanliga frågor**

**Kan jag ange halvtransparent fyllning för kolumner/områden samtidigt som kanten förblir ogenomskinlig?**

Ja. Fyllnadens transparens och konturen konfigureras separat. Detta är användbart för att förbättra läsbarheten i rutnätet och data i täta visualiseringar.

**Hur kan jag hantera datamärkningar när de överlappar?**

Minska teckenstorleken, inaktivera icke‑nödvändiga märkningselement (t.ex. kategorier), justera märkningens offset/position, visa märkningar endast för utvalda punkter om nödvändigt, eller byt formatet till "värde + förklaring".

**Kan jag applicera gradient‑ eller mönsterfyllningar på serier?**

Ja. Både solida och gradient‑/mönsterfyllningar är vanligtvis tillgängliga. I praktiken bör gradienter användas sparsamt och man bör undvika kombinationer som minskar kontrasten mot rutnätet och texten.