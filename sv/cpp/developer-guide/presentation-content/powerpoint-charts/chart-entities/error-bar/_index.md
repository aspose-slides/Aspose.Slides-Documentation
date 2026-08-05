---
title: Anpassa felstaplar i presentationsdiagram med C++
linktitle: Felstapel
type: docs
url: /sv/cpp/error-bar/
keywords:
- felstapel
- anpassat värde
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du lägger till och anpassar felstaplar i diagram med Aspose.Slides för C++ — optimera datavisualiseringar i PowerPoint-presentationer."
---
## **Översikt**

Denna artikel förklarar hur du arbetar med felstaplar i presentationsdiagram med Aspose.Slides. Den visar hur du lägger till felstaplar i en diagramserie, konfigurerar X‑ och Y‑inställningar för felstaplar samt använder olika värdetyper som fasta, procentuella och anpassade värden.

Den demonstrerar också hur du tilldelar anpassade felstaplar för enskilda datapunkter i en serie genom att använda den motsvarande datapunktssamlingen. Dessutom innehåller artikeln korta noteringar om hur felstaplar beter sig vid export, deras kompatibilitet med markörer och dataetiketter samt var du hittar de relaterade API‑referensklasserna och uppräkningarna.

## **Lägg till felstaplar**
Aspose.Slides för C++ erbjuder ett enkelt API för att hantera felstaplarsvärden. Exempelkoden gäller när du använder en anpassad värdetyper. För att ange ett värde, använd **ErrorBarCustomValues**‑egenskapen för en specifik datapunkt i **DataPoints**‑samlingen för serien:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
1. Lägg till ett bubbeldiagram på den önskade bilden.
1. Kom åt den första diagramserien och ange felstaplarens X‑format.
1. Kom åt den första diagramserien och ange felstaplarens Y‑format.
1. Ställ in staplarnas värden och format.
1. Skriv den modifierade presentationen till en PPTX‑fil.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddErrorBars-AddErrorBars.cpp" >}}

## **Lägg till anpassade felstaplar**
Aspose.Slides för C++ erbjuder ett enkelt API för att hantera anpassade felstaplarsvärden. Exempelkoden gäller när **IErrorBarsFormat.ValueType**‑egenskapen är lika med **Custom**. För att ange ett värde, använd **ErrorBarCustomValues**‑egenskapen för en specifik datapunkt i **DataPoints**‑samlingen för serien:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
1. Lägg till ett bubbeldiagram på den önskade bilden.
1. Kom åt den första diagramserien och ange felstaplarens X‑format.
1. Kom åt den första diagramserien och ange felstaplarens Y‑format.
1. Kom åt diagramseriens enskilda datapunkter och ange felstaplarnas värden för en individuell datapunkt i serien.
1. Ställ in staplarnas värden och format.
1. Skriv den modifierade presentationen till en PPTX‑fil.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddCustomError-AddCustomError.cpp" >}}

## **Vanliga frågor**

**Vad händer med felstaplarna när en presentation exporteras till PDF eller bilder?**

De renderas som en del av diagrammet och bevaras under konverteringen tillsammans med resten av diagramformatet, förutsatt att en kompatibel version eller renderare används.

**Kan felstaplar kombineras med markörer och dataetiketter?**

Ja. Felstaplar är ett separat element och är kompatibla med markörer och dataetiketter; om element överlappar kan du behöva justera formateringen.

**Var kan jag hitta listan över egenskaper och uppräkningar för att arbeta med felstaplar i API:t?**

I API‑referensen: klassen [ErrorBarsFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/errorbarsformat/) och de relaterade uppräkningarna [ErrorBarType](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/errorbartype/) och [ErrorBarValueType](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/errorbarvaluetype/).