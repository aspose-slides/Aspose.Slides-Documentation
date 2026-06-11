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

Denna artikel förklarar hur man arbetar med felstaplar i presentationsdiagram med hjälp av Aspose.Slides. Den visar hur man lägger till felstaplar i en diagramserie, konfigurerar X- och Y-felstapelsinställningar och tillämpar olika värdetyper såsom fast, procentuell och anpassade värden.

Den visar också hur man tilldelar anpassade felstaplarvärden för enskilda datapunkter i en serie genom att använda den motsvarande datapunktssamlingen. Dessutom innehåller artikeln korta noteringar om hur felstaplar beter sig vid export, deras kompatibilitet med markörer och datalabels, samt var man hittar de relaterade API-referensklasserna och enumsen.

## **Lägg till felstaplar**
Aspose.Slides för C++ tillhandahåller ett enkelt API för att hantera felstaplarvärden. Exempelkoden gäller när man använder en anpassad värdetyp. För att ange ett värde, använd egenskapen **ErrorBarCustomValues** för en specifik datapunkt i **DataPoints**-samlingen för serien:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
1. Lägg till ett bubbeldiagram på önskad bild.
1. Hämta den första diagramserien och ange felstapeln X-format.
1. Hämta den första diagramserien och ange felstapeln Y-format.
1. Ställ in staplarnas värden och format.
1. Skriv den modifierade presentationen till en PPTX-fil.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddErrorBars-AddErrorBars.cpp" >}}

## **Lägg till anpassade felstaplar**
Aspose.Slides för C++ tillhandahåller ett enkelt API för att hantera anpassade felstaplarvärden. Exempelkoden gäller när egenskapen **IErrorBarsFormat.ValueType** är lika med **Custom**. För att ange ett värde, använd egenskapen **ErrorBarCustomValues** för en specifik datapunkt i **DataPoints**-samlingen för serien:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
1. Lägg till ett bubbeldiagram på önskad bild.
1. Hämta den första diagramserien och ange felstapeln X-format.
1. Hämta den första diagramserien och ange felstapeln Y-format.
1. Åtkomst till diagramseriens enskilda datapunkter och ställ in felstaplarvärden för en individuell datapunkt i serien.
1. Ställ in staplarnas värden och format.
1. Skriv den modifierade presentationen till en PPTX-fil.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddCustomError-AddCustomError.cpp" >}}

## **Vanliga frågor**

**Vad händer med felstaplarna när en presentation exporteras till PDF eller bilder?**

De renderas som en del av diagrammet och bevaras under konverteringen tillsammans med resten av diagramformatet, förutsatt att en kompatibel version eller renderare används.

**Kan felstaplar kombineras med markörer och datalabels?**

Ja. Felstaplar är ett separat element och är kompatibla med markörer och datalabels; om elementen överlappar kan du behöva justera formateringen.

**Var kan jag hitta listan över egenskaper och enum för att arbeta med felstaplar i API:et?**

I API-referensen: klassen [ErrorBarsFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/errorbarsformat/) samt de relaterade enumen [ErrorBarType](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/errorbartype/) och [ErrorBarValueType](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/errorbarvaluetype/).