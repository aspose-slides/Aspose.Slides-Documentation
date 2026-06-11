---
title: Ange standardtypsnitt för presentation i Java
linktitle: Standardtypsnitt
type: docs
weight: 30
url: /sv/java/default-font/
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
- Java
- Aspose.Slides
description: "Ange standardtypsnitt i Aspose.Slides för Java för att säkerställa korrekt konvertering av PowerPoint (PPT, PPTX) och OpenDocument (ODP) till PDF, XPS och bilder."
---
## **Översikt**

Aspose.Slides låter dig ange standardtypsnitt som används när en presentation renderas. Detta är användbart när du genererar miniatyrbilder av bilder eller exporterar en presentation till format som PDF och XPS. Standardtypsnitt konfigureras via `LoadOptions` innan presentationen laddas.

`setDefaultRegularFont`‑metoden definierar standardtypsnittet för vanlig text, medan `setDefaultAsianFont` definierar standardtypsnittet för asiatisk text. Efter att dessa alternativ har ställts in kan presentationen laddas och renderas med de angivna typsnitten.

## **Använd standardtypsnitt för att rendera en presentation**
Aspose.Slides låter dig ange standardtypsnittet för att rendera presentationen till PDF, XPS eller miniatyrbilder. Den här artikeln visar hur du definierar DefaultRegularFont och DefaultAsianFont för användning som standardtypsnitt. Följ stegen nedan för att läsa in typsnitt från externa kataloger med hjälp av Aspose.Slides för Java‑API:

1. Skapa en instans av [LoadOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/LoadOptions).
1. [Ställ in DefaultRegularFont](https://reference.aspose.com/slides/sv/java/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) till ditt önskade typsnitt. I följande exempel har jag använt Wingdings.
1. [Ställ in DefaultAsianFont](https://reference.aspose.com/slides/sv/java/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) till ditt önskade typsnitt. Jag har använt Wingdings i följande exempel.
1. Läs in presentationen med Presentation och ange laddningsalternativen.
1. Generera nu bildminiatyr, PDF och XPS för att verifiera resultaten.

Implementeringen av ovanstående visas nedan.

```java
// Använd lastalternativ för att definiera standardvanligt och asiatisk typsnitt
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// Läs in presentationen
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Generera bildminiatyr
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
         // spara bilden på disken.
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }

    // Generera PDF
    pres.save("output_out.pdf", SaveFormat.Pdf);

    // Generera XPS
    pres.save("output_out.xps", SaveFormat.Xps);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vanliga frågor**

**Vad påverkar egentligen DefaultRegularFont och DefaultAsianFont—endast export, eller även miniatyrbilder, PDF, XPS, HTML och SVG?**

De deltar i renderingspipelines för alla stödda utdata. Detta inkluderar bildminiatyrer, [PDF](/slides/sv/java/convert-powerpoint-to-pdf/), [XPS](/slides/sv/java/convert-powerpoint-to-xps/), [rasterbilder](/slides/sv/java/convert-powerpoint-to-png/), [HTML](/slides/sv/java/convert-powerpoint-to-html/), och [SVG](/slides/sv/java/render-a-slide-as-an-svg-image/), eftersom Aspose.Slides använder samma layout‑ och glyfupplösningslogik för dessa mål.

**Tillämpas standardtypsnitt när man bara läser och sparar en PPTX utan någon rendering?**

Nej. Standardtypsnitt är relevanta när text måste mätas och ritas. En enkel öppna‑spara av en presentation ändrar inte lagrade typrun eller filens struktur. Standardtypsnitt kommer i spel under operationer som renderar eller flödar om text.

**Om jag lägger till egna typsnittsmappor eller tillhandahåller typsnitt från minnet, kommer de att beaktas vid val av standardtypsnitt?**

Ja. [Anpassade typsnittskällor](/slides/sv/java/custom-font/) utökar katalogen med tillgängliga familjer och glyfer som motorn kan använda. Standardtypsnitt och eventuella [fallback‑regler](/slides/sv/java/fallback-font/) kommer att lösas mot dessa källor först, vilket ger mer pålitlig täckning på servrar och i containrar.

**Kommer standardtypsnitt att påverka textmått (kerning, avstånd) och därmed radbrytningar och radomslag?**

Ja. Att byta typsnitt ändrar glyfmått och kan förändra radbrytningar, radomslag och sidindelning under rendering. För layoutstabilitet, [bädda in de ursprungliga typsnitten](/slides/sv/java/embedded-font/) eller välj metrisk kompatibla standard- och fallback‑familjer.

**Finns det någon nytta med att ställa in standardtypsnitt om alla typsnitt som används i presentationen är inbäddade?**

Ofta är det inte nödvändigt, eftersom [inbäddade typsnitt](/slides/sv/java/embedded-font/) redan säkrar ett enhetligt utseende. Standardtypsnitt hjälper fortfarande som en säkerhetsåtgärd för tecken som inte täcks av den inbäddade delmängden eller när en fil blandar inbäddad och ej inbäddad text.