---
title: Lägg till trendlinjer i presentationsdiagram i C++
linktitle: Trendlinje
type: docs
url: /sv/cpp/trend-line/
keywords:
- diagram
- trendlinje
- exponentiell trendlinje
- linjär trendlinje
- logaritmisk trendlinje
- glidande medelvärdestrendlinje
- polynomtrendlinje
- potenstrendlinje
- anpassad trendlinje
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Lägg snabbt till och anpassa trendlinjer i PowerPoint-diagram med Aspose.Slides för C++ — en praktisk guide för att engagera din publik."
---
## **Översikt**

Den här artikeln förklarar hur du lägger till trendlinjer i presentationsdiagram med Aspose.Slides. Den visar hur du skapar ett diagram, lägger till trendlinjer i diagramserier och arbetar med flera typer av trendlinjer, inklusive exponentiell, linjär, logaritmisk, glidande medelvärde, polynom och potens.

Den beskriver också hur du lägger till en anpassad linje i ett diagram genom att infoga en linjefigur, och innehåller en kort FAQ om värden för framåt‑ och bakåtriktad trendlinjeprojektion samt om trendlinjer bevaras vid export till PDF eller SVG och när diagram renderas som bilder.

## **Lägg till en trendlinje**
Aspose.Slides for C++ erbjuder ett enkelt API för att hantera olika diagramtrendlinjer:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)‑klassen.
1. Hämta en slides referens via dess index.
1. Lägg till ett diagram med standarddata samt önskad typ (detta exempel använder ChartType.ClusteredColumn).
1. Lägg till en exponentiell trendlinje för diagramserie 1.
1. Lägg till en linjär trendlinje för diagramserie 1.
1. Lägg till en logaritmisk trendlinje för diagramserie 2.
1. Lägg till en glidande medelvärdestrendlinje för diagramserie 2.
1. Lägg till en polynomtrendlinje för diagramserie 3.
1. Lägg till en potenstrendlinje för diagramserie 3.
1. Skriv den modifierade presentationen till en PPTX‑fil.

Följande kod används för att skapa ett diagram med trendlinjer.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartTrendLines-ChartTrendLines.cpp" >}}

## **Lägg till en anpassad linje**
Aspose.Slides for C++ erbjuder ett enkelt API för att lägga till anpassade linjer i ett diagram. För att lägga till en enkel rak linje på en vald slide i presentationen, följ stegen nedan:

- Skapa en instans av Presentation‑klassen
- Hämta referensen till en slide genom att använda dess Index
- Skapa ett nytt diagram med metoden AddChart som exponeras av Shapes‑objektet
- Lägg till en AutoShape av typen Line med metoden AddAutoShape som exponeras av Shapes‑objektet
- Ställ in färgen på figurens linjer.
- Skriv den modifierade presentationen som en PPTX‑fil

Följande kod används för att skapa ett diagram med anpassade linjer.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}

## **FAQ**

**Vad betyder “framåt” och “bakåt” för en trendlinje?**

Det är längden på trendlinjen som projiceras framåt/bakåt: för spridningsdiagram (XY) – i enheterna på axlarna; för icke‑spridningsdiagram – i antal kategorier. Endast icke‑negativa värden är tillåtna.

**Kommer trendlinjen att bevaras när presentationen exporteras till PDF eller SVG, eller när en slide renderas som en bild?**

Ja. Aspose.Slides konverterar presentationer till [PDF](/slides/sv/cpp/convert-powerpoint-to-pdf/)/[SVG](/slides/sv/cpp/render-a-slide-as-an-svg-image/) och renderar diagram till bilder; trendlinjer, som en del av diagrammet, bevaras under dessa operationer. En metod finns också för att [exportera en bild av diagrammet](/slides/sv/cpp/create-shape-thumbnails/).