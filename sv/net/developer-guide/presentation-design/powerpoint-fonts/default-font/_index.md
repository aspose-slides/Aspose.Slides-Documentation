---
title: Ange standardteckensnitt för presentation i .NET
linktitle: Standardteckensnitt
type: docs
weight: 30
url: /sv/net/default-font/
keywords:
- standardteckensnitt
- vanligt teckensnitt
- normalt teckensnitt
- asiatiskt teckensnitt
- PDF-export
- XPS-export
- bildexport
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Ställ in standardteckensnitt i Aspose.Slides för .NET för att säkerställa korrekt konvertering av PowerPoint (PPT, PPTX) och OpenDocument (ODP) till PDF, XPS och bilder."
---
## **Översikt**

Aspose.Slides låter dig ange standardteckensnitt som används när en presentation renderas. Detta är användbart när du genererar miniatyrbilder av bilder eller exporterar en presentation till format som PDF och XPS. Standardteckensnitt konfigureras via `LoadOptions` innan presentationen laddas.

`DefaultRegularFont`‑egenskapen definierar standardteckensnittet för vanlig text, medan `DefaultAsianFont` definierar standardteckensnittet för asiatisk text. När dessa alternativ har ställts in kan presentationen laddas och renderas med de specificerade teckensnitten.

## **Använd standardteckensnitt för att rendera en presentation**
Aspose.Slides låter dig sätta standardteckensnitt för att rendera presentationen till PDF, XPS eller miniatyrbilder. Denna artikel visar hur du definierar DefaultRegularFont och DefaultAsianFont för användning som standardteckensnitt. Följ stegen nedan för att ladda teckensnitt från externa kataloger med Aspose.Slides för .NET API:

1. Skapa en instans av LoadOptions.
1. Ställ in DefaultRegularFont till ditt önskade teckensnitt. I följande exempel har jag använt Wingdings.
1. Ställ in DefaultAsianFont till ditt önskade teckensnitt. Jag har använt Wingdings i följande exempel.
1. Ladda presentationen med Presentation och ange lastalternativen.
1. Generera nu bildminiaturen, PDF och XPS för att verifiera resultaten.

Implementationen av ovanstående visas nedan.

```c#
// Använd lastalternativen för att ange standardteckensnitt för vanlig och asiatisk text
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.DefaultRegularFont = "Wingdings";
loadOptions.DefaultAsianFont = "Wingdings";

using (Presentation pptx = new Presentation("DefaultFonts.pptx", loadOptions))
{
    using (IImage image = pptx.Slides[0].GetImage(1, 1))
    {
        image.Save("DefaultFonts_out.png", ImageFormat.Png);
    }

    pptx.Save("DefaultFonts_out.pdf", SaveFormat.Pdf);
    pptx.Save("DefaultFonts_out.xps", SaveFormat.Xps);
}
```

## **Vanliga frågor**

**Vad exakt påverkar DefaultRegularFont och DefaultAsianFont—endast export, eller även miniatyrbilder, PDF, XPS, HTML och SVG?**

De deltar i renderings‑pipelines för alla stödjade utdata. Detta inkluderar bildminiaturer, [PDF](/slides/sv/net/convert-powerpoint-to-pdf/), [XPS](/slides/sv/net/convert-powerpoint-to-xps/), [rasterbilder](/slides/sv/net/convert-powerpoint-to-png/), [HTML](/slides/sv/net/convert-powerpoint-to-html/), och [SVG](/slides/sv/net/render-a-slide-as-an-svg-image/), eftersom Aspose.Slides använder samma layout‑ och glyf‑upplösningslogik för dessa mål.

**Tillämpar standardteckensnitt när du bara läser och sparar en PPTX utan någon renderning?**

Nej. Standardteckensnitt är viktiga när text måste mätas och ritas. En ren öppna‑spara‑operation av en presentation ändrar inte lagrade teckensnittsruns eller filens struktur. Standardteckensnitt används vid operationer som renderar eller omflödar text.

**Om jag lägger till egna teckensnittsmappar eller levererar teckensnitt från minnet, kommer de att beaktas vid val av standardteckensnitt?**

Ja. [Anpassade teckensnittskällor](/slides/sv/net/custom-font/) utökar katalogen med tillgängliga familjer och glyfer som motorn kan använda. Standardteckensnitt och eventuella [fallback‑regler](/slides/sv/net/fallback-font/) kommer att lösas mot dessa källor först, vilket ger mer pålitlig täckning på servrar och i containrar.

**Kommer standardteckensnitt att påverka textmått (kerning, avstånd) och därmed radbrytningar och textbrytning?**

Ja. Att byta teckensnitt ändrar glyf‑mått och kan förändra radbrytningar, omslagning och paginering vid rendering. För layoutstabilitet, [bädda in de ursprungliga teckensnitten](/slides/sv/net/embedded-font/) eller välj metrisk kompatibla standard‑ och fallback‑familjer.

**Finns det någon mening med att ange standardteckensnitt om alla teckensnitt som används i presentationen är inbäddade?**

Ofta är det inte nödvändigt, eftersom [inbäddade teckensnitt](/slides/sv/net/embedded-font/) redan garanterar en konsekvent visning. Standardteckensnitt är ändå användbara som en säkerhetsåtgärd för tecken som inte täcks av det inbäddade delmängden eller när en fil blandar inbäddad och icke‑inbäddad text.