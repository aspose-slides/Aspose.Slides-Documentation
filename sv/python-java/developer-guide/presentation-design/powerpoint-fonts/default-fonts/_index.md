---
title: Ange standardteckensnitt för presentation i Python via Java
linktitle: Standardteckensnitt
type: docs
weight: 30
url: /sv/python-java/default-font/
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
- Python
- Java
- Aspose.Slides
description: "Ange standardteckensnitt i Aspose.Slides för Python via Java för att säkerställa korrekt konvertering av PowerPoint (PPT, PPTX) och OpenDocument (ODP) till PDF, XPS och bilder."
---
## **Översikt**

Aspose.Slides låter dig ange standardteckensnitt som används när en presentation renderas. Detta är användbart när du genererar bildminiatyrer eller exporterar en presentation till format såsom PDF och XPS. Standardteckensnitt konfigureras via [LoadOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/loadoptions/) innan presentationen läses in.

Metoden [setDefaultRegularFont](https://reference.aspose.com/slides/sv/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) definierar standardteckensnittet för vanlig text, medan [setDefaultAsianFont](https://reference.aspose.com/slides/sv/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) definierar standardteckensnittet för asiatisk text. Efter att dessa alternativ har ställts in kan presentationen läsas in och renderas med de angivna teckensnitten.

## **Använd standardteckensnitt för att rendera en presentation**

Aspose.Slides låter dig ange standardteckensnitt för att rendera en presentation till PDF, XPS eller miniatyrbilder. Detta avsnitt visar hur du definierar standardteckensnitt för vanlig och asiatisk text med Aspose.Slides för Python via Java:

1. Skapa en instans av [LoadOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/loadoptions/).
2. Använd [setDefaultRegularFont](https://reference.aspose.com/slides/sv/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) för att ange önskat teckensnitt. Följande exempel använder Wingdings.
3. Använd [setDefaultAsianFont](https://reference.aspose.com/slides/sv/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) för att ange önskat teckensnitt. Följande exempel använder också Wingdings.
4. Läs in presentationen med [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) med laddningsalternativen.
5. Generera bildminiatyren, PDF och XPS för att verifiera resultaten.

Följande exempel implementerar dessa steg:

```python
from asposeslides.api import ImageFormat, LoadFormat, LoadOptions, Presentation, SaveFormat

# Använd laddningsalternativ för att ange standardteckensnitt för vanlig och asiatisk text.
load_options = LoadOptions(LoadFormat.Auto)
load_options.setDefaultRegularFont("Wingdings")
load_options.setDefaultAsianFont("Wingdings")

# Läs in presentationen.
presentation = Presentation("DefaultFonts.pptx", load_options)
try:
    # Generera en bildminiatyr för bilden.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # Spara bilden till disk.
        slide_image.save("output.png", ImageFormat.Png)
    finally:
        slide_image.dispose()

    # Generera en PDF.
    presentation.save("output_out.pdf", SaveFormat.Pdf)

    # Generera ett XPS-dokument.
    presentation.save("output_out.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

## **FAQ**

**Vad exakt påverkar de standardvanliga och asiatiska teckensnitten—endast export, eller även miniatyrer, PDF, XPS, HTML och SVG?**

De deltar i renderingspipelines för alla stödda utdata. Detta inkluderar bildminiatyrer, [PDF](/slides/sv/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/sv/python-java/convert-powerpoint-to-xps/), [rasterbilder](/slides/sv/python-java/convert-powerpoint-to-png/), [HTML](/slides/sv/python-java/convert-powerpoint-to-html/), och [SVG](/slides/sv/python-java/render-a-slide-as-an-svg-image/), eftersom Aspose.Slides använder samma layout‑ och glyfupplösningslogik för dessa mål.

**Tillämpars standardteckensnitt när man bara läser och sparar en PPTX utan någon rendering?**

Nej. Standardteckensnitt är relevanta när text måste mätas och ritas. En enkel öppna‑spara av en presentation ändrar inte lagrade teckensnittsruns eller filens struktur. Standardteckensnitt blir aktuella vid operationer som renderar eller flödar om text.

**Om jag lägger till egna teckensnittsmappar eller tillhandahåller teckensnitt från minnet, kommer de att beaktas vid valet av standardteckensnitt?**

Ja. [Anpassade teckensnittskällor](/slides/sv/python-java/custom-font/) utökar katalogen med tillgängliga familjer och glyfer som motorn kan använda. Standardteckensnitt och eventuella [fallback‑regler](/slides/sv/python-java/fallback-font/) kommer att lösas mot dessa källor först, vilket ger mer pålitlig täckning på servrar och i containrar.

**Kommer standardteckensnitt att påverka textmått (kerning, avstånd) och därmed radbrytningar och omslag?**

Ja. Att ändra teckensnittet ändrar glyfmått och kan förändra radbrytningar, omslag och paginering under rendering. För stabil layout, [bädda in de ursprungliga teckensnitten](/slides/sv/python-java/embedded-font/) eller välj metrisk kompatibla standard‑ och fallback‑familjer.

**Finns det någon anledning att ange standardteckensnitt om alla teckensnitt som används i presentationen är inbäddade?**

Ofta är det inte nödvändigt, eftersom [inbäddade teckensnitt](/slides/sv/python-java/embedded-font/) redan säkerställer ett konsekvent utseende. Standardteckensnitt hjälper fortfarande som en säkerhetsåtgärd för tecken som inte täcks av den inbäddade delmängden eller när en fil blandar inbäddad och icke‑inbäddad text.