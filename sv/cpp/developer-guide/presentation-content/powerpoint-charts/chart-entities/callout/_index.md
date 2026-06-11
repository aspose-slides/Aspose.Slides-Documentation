---
title: Hantera callouts i presentationsdiagram med С++
linktitle: Etikett
type: docs
url: /sv/cpp/callout/
keywords:
- diagramcallout
- använd callout
- datamärkning
- etikettformat
- PowerPoint
- presentation
- С++
- Aspose.Slides
description: "Skapa och formatera callouts i Aspose.Slides för С++ med kortfattade kodexempel, kompatibla med PPT och PPTX för att automatisera presentationsarbetsflöden."
---
## **Översikt**

Den här artikeln förklarar hur du arbetar med callouts för diagramdatamärkningar i Aspose.Slides. Den visar hur du använder metoden `set_ShowLabelAsDataCallout` för att visa märken som callouts, hur du konfigurerar callout‑relaterade märkinställningar för ett ringdiagram, och noterar att callouts och deras utseende bevaras när presentationer exporteras till PDF, HTML5, SVG och rasterbildformat.

## **Använda callouts**
Den nya egenskapen **ShowLabelAsDataCallout** har lagts till i **DataLabelFormat**‑klassen och **IDataLabelFormat**‑gränssnittet, vilket bestämmer om det angivna diagrammets datamärke ska visas som ett data‑callout eller som ett datamärke. I exemplet nedan har vi ställt in callouts.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **Ställ in ett callout för ett ringdiagram**
Aspose.Slides för C++ erbjuder stöd för att ange serie‑datamärkes‑callout‑formen för ett ringdiagram. Nedan ges ett exempel.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **FAQ**

**Bevaras callouts när en presentation konverteras till PDF, HTML5, SVG eller bilder?**

Ja. Callouts är en del av diagramrenderingen, så när du exporterar till [PDF](/slides/sv/cpp/convert-powerpoint-to-pdf/), [HTML5](/slides/sv/cpp/export-to-html5/), [SVG](/slides/sv/cpp/render-a-slide-as-an-svg-image/), eller [rasterbilder](/slides/sv/cpp/convert-powerpoint-to-png/), bevaras de tillsammans med bildens formatering.

**Fungerar egna teckensnitt i callouts, och kan deras utseende bevaras vid export?**

Ja. Aspose.Slides stödjer [inbäddning av teckensnitt](/slides/sv/cpp/embedded-font/) i presentationen och styr teckensnittsinbäddning vid export, t.ex. till [PDF](/slides/sv/cpp/convert-powerpoint-to-pdf/), vilket säkerställer att callouts ser likadana ut på olika system.