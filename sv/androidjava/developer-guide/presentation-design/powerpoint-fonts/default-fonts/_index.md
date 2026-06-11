---
title: Ange standardtypsnitt för presentationer på Android
linktitle: Standardtypsnitt
type: docs
weight: 30
url: /sv/androidjava/default-font/
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
- Android
- Java
- Aspose.Slides
description: "Ställ in standardtypsnitt i Aspose.Slides för Android via Java för att säkerställa korrekt konvertering av PowerPoint (PPT, PPTX) och OpenDocument (ODP) till PDF, XPS och bilder."
---
## **Översikt**

Aspose.Slides låter dig ange standardtypsnitt som används när en presentation renderas. Detta är användbart när du genererar bildförhandsvisningar av bilder eller exporterar en presentation till format som PDF och XPS. Standardtypsnitt konfigureras via `LoadOptions` innan presentationen laddas.

`setDefaultRegularFont`‑metoden definierar standardtypsnittet för vanlig text, medan `setDefaultAsianFont` definierar standardtypsnittet för asiatisk text. Efter att dessa alternativ har ställts in kan presentationen laddas och renderas med de angivna typsnitten.

## **Använd standardtypsnitt för att rendera en presentation**
Aspose.Slides låter dig ange standardtypsnitt för rendering av presentationen till PDF, XPS eller bildförhandsvisningar. Denna artikel visar hur du definierar DefaultRegularFont och DefaultAsianFont för att använda som standardtypsnitt. Följ stegen nedan för att ladda typsnitt från externa kataloger med Aspose.Slides för Android via Java‑API:

1. Skapa en instans av [LoadOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/LoadOptions).
2. [Ställ in DefaultRegularFont](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) till ditt önskade typsnitt. I följande exempel har jag använt Wingdings.
3. [Ställ in DefaultAsianFont](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) till ditt önskade typsnitt. Jag har använt Wingdings i följande exempel.
4. Ladda presentationen med Presentation och ange laddningsalternativen.
5. Generera nu bildförhandsvisning, PDF och XPS för att verifiera resultaten.

```java
// Använd laddningsalternativ för att definiera standardvanligt och asiatiskt typsnitt
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// Ladda presentationen
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Generera bildförhandsvisning av bild
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

**Vad exakt påverkar DefaultRegularFont och DefaultAsianFont — endast export, eller även bildförhandsvisningar, PDF, XPS, HTML och SVG?**

De deltar i renderingspipelines för alla stödda utdata. Detta inkluderar bildförhandsvisningar, [PDF](/slides/sv/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/sv/androidjava/convert-powerpoint-to-xps/), [rasterbilder](/slides/sv/androidjava/convert-powerpoint-to-png/), [HTML](/slides/sv/androidjava/convert-powerpoint-to-html/), och [SVG](/slides/sv/androidjava/render-a-slide-as-an-svg-image/), eftersom Aspose.Slides använder samma layout‑ och glyfupplösningslogik för dessa mål.

**Tillämpar man standardtypsnitt när man bara läser och sparar en PPTX utan någon rendering?**

Nej. Standardtypsnitt är relevanta när text måste mätas och ritas. En enkel öppna‑och‑spara av en presentation förändrar inte lagrade teckensnittsruns eller filens struktur. Standardtypsnitt används vid operationer som renderar eller omflödar text.

**Om jag lägger till egna teckensnittsmappar eller levererar teckensnitt från minnet, kommer de att beaktas vid val av standardtypsnitt?**

Ja. [Anpassade teckensnittskällor](/slides/sv/androidjava/custom-font/) utökar katalogen av tillgängliga familjer och glyfer som motorn kan använda. Standardtypsnitt och eventuella [fallback‑regler](/slides/sv/androidjava/fallback-font/) kommer att lösa mot dessa källor först, vilket ger mer pålitlig täckning på servrar och i containrar.

**Kommer standardtypsnitt att påverka textmått (kerning, avstånd) och därmed radbrytningar och radomslag?**

Ja. Att byta teckensnitt ändrar glyfmetrik och kan förändra radbrytningar, radomslag och sidindelning under rendering. För layoutstabilitet, [bädda in de ursprungliga teckensnitten](/slides/sv/androidjava/embedded-font/) eller välj metrisk kompatibla standard‑ och fallback‑familjer.

**Finns det någon nytta med att ange standardtypsnitt om alla teckensnitt som används i presentationen är inbäddade?**

Ofta är det onödigt, eftersom [inbäddade teckensnitt](/slides/sv/androidjava/embedded-font/) redan säkerställer enhetligt utseende. Standardtypsnitt är ändå en säkerhetsåtgärd för tecken som inte täcks av den inbäddade delmängden eller när en fil blandar inbäddad och icke‑inbäddad text.