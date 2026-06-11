---
title: Anpassa standardtypsnitt i presentationer med Python
linktitle: Standardtypsnitt
type: docs
weight: 30
url: /sv/python-net/default-font/
keywords:
- standardtypsnitt
- vanligt typsnitt
- normalt typsnitt
- asiatiskt typsnitt
- PDF-export
- XPS-export
- bildexport
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Ställ in standardtypsnitt i Aspose.Slides för Python för att säkerställa korrekt konvertering av PowerPoint (PPT, PPTX) och OpenDocument (ODP) till PDF, XPS och bilder."
---
## **Översikt**

Aspose.Slides låter dig ange standardtypsnitt som används när en presentation renderas. Detta är användbart vid generering av bildminiatyrer eller export av en presentation till format som PDF och XPS. Standardtypsnitt konfigureras via `LoadOptions` innan presentationen laddas.

Egendomen `default_regular_font` definierar standardtypsnittet för vanlig text, medan `default_asian_font` definierar standardtypsnittet för asiatisk text. När dessa alternativ har ställts in kan presentationen laddas och renderas med de angivna typsnitten.

## **Använda standardtypsnitt för rendering av presentation**
Aspose.Slides låter dig ange standardtypsnitt för rendering av presentationen till PDF, XPS eller miniatyrbilder. Denna artikel visar hur du definierar DefaultRegularFont och DefaultAsianFont för att använda dem som standardtypsnitt. Följ stegen nedan för att ladda typsnitt från externa kataloger med Aspose.Slides för Python via .NET‑API:

1. Skapa en instans av LoadOptions.  
1. Ställ in DefaultRegularFont till det typsnitt du vill använda. I följande exempel har jag använt Wingdings.  
1. Ställ in DefaultAsianFont till det typsnitt du vill använda. Jag har använt Wingdings i följande exempel.  
1. Ladda presentationen med Presentation och ange laddningsalternativen.  
1. Generera nu bildminiatyr, PDF och XPS för att verifiera resultatet.  

Implementeringen av ovanstående visas nedan.

```py
import aspose.slides as slides

# Använd laddningsalternativ för att definiera standardtypsnitten för vanlig och asiatisk text# Använd laddningsalternativ för att definiera standardtypsnitten för vanlig och asiatisk text
loadOptions = slides.LoadOptions(slides.LoadFormat.AUTO)
loadOptions.default_regular_font = "Wingdings"
loadOptions.default_asian_font = "Wingdings"

# Ladda presentationen
with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as pptx:
    # Skapa bildminiatyr
    with pptx.slides[0].get_image(1, 1) as img:
        img.save("output_out.png", slides.ImageFormat.PNG)

    # Skapa PDF
    pptx.save("output_out.pdf", slides.export.SaveFormat.PDF)

    # Skapa XPS
    pptx.save("output_out.xps", slides.export.SaveFormat.XPS)
```

## **Vanliga frågor**

**Vad påverkar egentligen `default_regular_font` och `default_asian_font` – bara export eller även miniatyrbilder, PDF, XPS, HTML och SVG?**

De deltar i renderings‑pipeline för alla stödjade utdata. Detta inkluderar bildminiatyrer, [PDF](/slides/sv/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/sv/python-net/convert-powerpoint-to-xps/), [rasterbilder](/slides/sv/python-net/convert-powerpoint-to-png/), [HTML](/slides/sv/python-net/convert-powerpoint-to-html/), och [SVG](/slides/sv/python-net/render-a-slide-as-an-svg-image/), eftersom Aspose.Slides använder samma layout‑ och glyf‑upplösningslogik för dessa mål.

**Tillämpas standardtypsnitt när man bara läser och sparar en PPTX utan någon rendering?**

Nej. Standardtypsnitt spelar roll när text måste mätas och ritas. En ren öppna‑och‑spara‑operation ändrar inte lagrade teckensnittsruns eller filens struktur. Standardtypsnitt kommer in i bilden vid operationer som renderar eller omflödar text.

**Om jag lägger till egna typsnittsmappar eller tillhandahåller typsnitt från minnet, beaktas de då vid val av standardtypsnitt?**

Ja. [Anpassade typsnittskällor](/slides/sv/python-net/custom-font/) utökar katalogen av tillgängliga familjer och glyfer som motorn kan använda. Standardtypsnitt och eventuella [fallback‑regler](/slides/sv/python-net/fallback-font/) söker först i dessa källor, vilket ger bättre täckning på servrar och i containrar.

**Kommer standardtypsnitt att påverka textmått (kerning, avstånd) och därmed radbrytningar och textomslag?**

Ja. Att byta typsnitt ändrar glyf‑mått och kan förändra radbrytningar, textomslag och paginering under rendering. För layoutstabilitet, [bädda in de ursprungliga typsnitten](/slides/sv/python-net/embedded-font/) eller välj metrisk kompatibla standard‑ och fallback‑familjer.

**Finns det någon nytta med att ange standardtypsnitt om alla typsnitt i presentationen är inbäddade?**

Ofta är det onödigt, eftersom [inbäddade typsnitt](/slides/sv/python-net/embedded-font/) redan säkerställer ett enhetligt utseende. Standardtypsnitt fungerar ändå som en säkerhetskudde för tecken som inte täcks av den inbäddade delmängden eller när en fil blandar inbäddad och icke‑inbäddad text.