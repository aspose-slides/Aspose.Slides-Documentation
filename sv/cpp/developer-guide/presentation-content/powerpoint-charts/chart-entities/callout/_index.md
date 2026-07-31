---
title: Hantera callouts i presentationsdiagram med C++
linktitle: Callout
type: docs
url: /sv/cpp/callout/
keywords:
- diagramcallout
- använd callout
- datamärkning
- märkningformat
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Skapa och formatera callouts i Aspose.Slides för C++ med koncisa kodexempel, kompatibla med PPT och PPTX för att automatisera presentationsarbetsflöden."
---
## **Översikt**

Denna artikel förklarar hur man arbetar med callouts för diagramdatamärkningar i Aspose.Slides. Den visar hur man använder metoden `set_ShowLabelAsDataCallout` för att visa märkningar som callouts, hur man konfigurerar callout‑relaterade märkningsinställningar för ett munkdiagram, och noterar att callouts och deras utseende bevaras när presentationer exporteras till PDF, HTML5, SVG och rasterbildformat.

## **Användning av callouts**
Ny egenskap **ShowLabelAsDataCallout** har lagts till i klassen **DataLabelFormat** och gränssnittet **IDataLabelFormat**, vilket bestämmer om diagrammets datamärkning ska visas som data‑callout eller som datamärkning. I exemplet nedan har vi ställt in callouts.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **Ställ in en callout för ett munkdiagram**
Aspose.Slides för C++ erbjuder stöd för att ställa in serie‑datamärknings‑callout‑formen för ett munkdiagram. Nedan ges ett exempel.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **Vanliga frågor**

**Behålls callouts när en presentation konverteras till PDF, HTML5, SVG eller bilder?**

Ja. Callouts är en del av diagramrenderingen, så när du exporterar till [PDF](/slides/sv/cpp/convert-powerpoint-to-pdf/), [HTML5](/slides/sv/cpp/export-to-html5/), [SVG](/slides/sv/cpp/render-a-slide-as-an-svg-image/), eller [rasterbilder](/slides/sv/cpp/convert-powerpoint-to-png/), bevaras de tillsammans med bildens formatering.

**Fungerar anpassade teckensnitt i callouts, och kan deras utseende bevaras vid export?**

Ja. Aspose.Slides stöder [inbäddning av teckensnitt](/slides/sv/cpp/embedded-font/) i presentationen och styr teckensnittsinbäddning under export som [PDF](/slides/sv/cpp/convert-powerpoint-to-pdf/), vilket säkerställer att callouts ser likadana ut på olika system.