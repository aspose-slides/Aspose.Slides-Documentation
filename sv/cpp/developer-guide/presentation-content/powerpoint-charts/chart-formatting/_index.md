---
title: Formatera diagram i presentationer i C++
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
description: "Lär dig diagramformatering i Aspose.Slides för C++ och förbättra din PowerPoint-presentation med professionell, iögonfallande stil."
---
## **Översikt**

Den här artikeln förklarar hur du formaterar diagram i PowerPoint‑presentationer med hjälp av Aspose.Slides. Den visar hur du anpassar viktiga diagramdelar såsom axlar, rutnät, titlar, förklaringar, diagramområdet och väggfyllningar för att förbättra diagrammets utseende och läsbarhet.

Den demonstrerar också hur du anger teckensnittsegenskaper för diagramtext, tillämpar förinställda och anpassade numeriska format på diagramdata samt aktiverar rundade hörn för diagramområdet. Tillsammans visar dessa exempel hur du kontrollerar både den visuella stilen och datarepresentationen för diagram i en presentation.

## **Formatera diagram‑entiteter**
Aspose.Slides för C++ låter utvecklare lägga till egna diagram på sina bilder från grunden. Den här artikeln förklarar hur du formaterar olika diagram‑entiteter inklusive diagram‑kategorisk axel och värdeaxel.

Aspose.Slides för C++ tillhandahåller ett enkelt API för att hantera olika diagram‑entiteter och formatera dem med egna värden:

1. Skapa en instans av **Presentation**‑klassen.
1. Hämta en bilds referens via dess index.
1. Lägg till ett diagram med standarddata tillsammans med någon av de önskade typerna (i detta exempel använder vi ChartType.LineWithMarkers).
1. Åtkomst till diagrammets Value Axis och ange följande egenskaper:
   1. Ange **Line format** för Value Axis Major Grid lines
   1. Ange **Line format** för Value Axis Minor Grid lines
   1. Ange **Number Format** för Value Axis
   1. Ange **Min, Max, Major and Minor units** för Value Axis
   1. Ange **Text Properties** för Value Axis‑data
   1. Ange **Title** för Value Axis
   1. Ange **Line Format** för Value Axis
1. Åtkomst till diagrammets Category Axis och ange följande egenskaper:
   1. Ange **Line format** för Category Axis Major Grid lines
   1. Ange **Line format** för Category Axis Minor Grid lines
   1. Ange **Text Properties** för Category Axis‑data
   1. Ange **Title** för Category Axis
   1. Ange **Label Positioning** för Category Axis
   1. Ange **Rotation Angle** för Category Axis‑etiketter
1. Åtkomst till diagrammets Legend och ange **Text Properties** för dem
1. Ställ in visning av diagram‑legender utan att de överlappar diagrammet
1. Åtkomst till diagrammets **Secondary Value Axis** och ange följande egenskaper:
   1. Aktivera den sekundära **Value Axis**
   1. Ange **Line Format** för Secondary Value Axis
   1. Ange **Number Format** för Secondary Value Axis
   1. Ange **Min, Max, Major and Minor units** för Secondary Value Axis
1. Plotta nu den första diagramserien på Secondary Value Axis
1. Ange bakväggens fyllningsfärg för diagrammet
1. Ange diagrammets plot‑områdes fyllningsfärg
1. Skriv den modifierade presentationen till en PPTX‑fil

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartEntities-ChartEntities.cpp" >}}

## **Ange teckensnittsegenskaper för ett diagram**
Aspose.Slides för C++ stödjer att ange teckensnittsrelaterade egenskaper för diagrammet. Följ stegen nedan för att ange teckensnittsegenskaper för diagrammet.

- Skapa ett **Presentation**‑objekt.
- Lägg till diagram på bilden.
- Ange teckenhöjd.
- Spara den modifierade presentationen.

Nedan följer ett exempel.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontPropertiesForChart-FontPropertiesForChart.cpp" >}}

## **Ange teckensnittsegenskaper för ett diagram‑datatabell**
Aspose.Slides för C++ stödjer att ändra färg på kategorier i en seriefärg.

1. Skapa ett **Presentation**‑objekt.
1. Lägg till diagram på bilden.
1. Ange diagramtabell.
1. Ange teckenhöjd.
1. Spara den modifierade presentationen.

Nedan följer ett exempel.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontPropertiesForChartDataTable-SettingFontPropertiesForChartDataTable.cpp" >}}

## **Ange rundade kanter för diagramområdet**
Aspose.Slides för C++ stödjer att ange diagramområde. **IChart.HasRoundedCorners** och **Chart.HasRoundedCorners**‑egenskaper har lagts till i Aspose.Slides.

1. Skapa ett **Presentation**‑objekt.
1. Lägg till diagram på bilden.
1. Ange fyllningstyp och fyllningsfärg för diagrammet
1. Sätt egenskapen för rundade hörn till True.
1. Spara den modifierade presentationen.

Nedan följer ett exempel.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingChartAreaRoundedBorders-SettingChartAreaRoundedBorders.cpp" >}}

## **Ange numeriskt format**
Aspose.Slides för C++ erbjuder ett enkelt API för att hantera diagramdatas format:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)‑klassen.
1. Hämta en bilds referens via dess index.
1. Lägg till ett diagram med standarddata tillsammans med någon av de önskade typerna (detta exempel använder **ChartType.ClusteredColumn**).
1. Ställ in förinställt talformat från de möjliga förinställda värdena.
1. Gå igenom diagramdatacellerna i varje diagramserie och ange diagramdatas talformat.
1. Spara presentationen.
1. Ställ in anpassat talformat.
1. Gå igenom diagramdatacellerna i varje diagramserie och ange ett annat talformat.
1. Spara presentationen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NumberFormat-NumberFormat.cpp" >}}

| |**De möjliga förinställda talformatvärdena tillsammans med deras index som kan användas visas nedan:**|
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

**Kan jag ange halvtransparent fyllning för kolumner/områden samtidigt som kanten förblir opak?**

Ja. Fyllnadens transparens och konturen konfigureras separat. Detta är användbart för att förbättra läsbarheten i rutnätet och data i täta visualiseringar.

**Hur kan jag hantera dataetiketter när de överlappar?**

Minska teckenstorleken, inaktivera icke‑nödvändiga etikettkomponenter (t.ex. kategorier), justera etikettens förskjutning/position, visa etiketter endast för utvalda punkter om det behövs, eller byt format till ”värde + förklaring”.

**Kan jag applicera gradient‑ eller mönsterfyllningar på serier?**

Ja. Både solida och gradient‑/mönsterfyllningar är vanligtvis tillgängliga. I praktiken bör du använda gradienter sparsamt och undvika kombinationer som minskar kontrasten mot rutnätet och texten.