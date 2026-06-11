---
title: Ange standardtypsnitt för presentationer i JavaScript
linktitle: Standardtypsnitt
type: docs
weight: 30
url: /sv/nodejs-java/default-font/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Ställ in standardtypsnitt i Aspose.Slides för Node.js via Java för att säkerställa korrekt konvertering av PowerPoint (PPT, PPTX) och OpenDocument (ODP) till PDF, XPS och bilder."
---
## **Översikt**

Aspose.Slides låter dig ange standardtypsnitt som används när en presentation renderas. Detta är användbart när du genererar bildminiatyrer eller exporterar en presentation till format som PDF och XPS. Standardtypsnitt konfigureras via `LoadOptions` innan presentationen laddas.

`setDefaultRegularFont`-metoden definierar standardtypsnittet för vanlig text, medan `setDefaultAsianFont` definierar standardtypsnittet för asiatisk text. Efter att dessa alternativ har satts kan presentationen laddas och renderas med de angivna typsnitten.

## **Använda standardtypsnitt för att rendera en presentation**
Aspose.Slides låter dig ange standardtypsnittet för att rendera presentationen till PDF, XPS eller miniatyrer. Denna artikel visar hur du definierar DefaultRegularFont och DefaultAsianFont för att använda dem som standardtypsnitt. Följ stegen nedan för att ladda typsnitt från externa kataloger med Aspose.Slides för Node.js via Java API:

1. Skapa en instans av [LoadOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/LoadOptions).
2. [Set the DefaultRegularFont](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) till ditt önskade typsnitt. I följande exempel har jag använt Wingdings.
3. [Set the DefaultAsianFont](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) till ditt önskade typsnitt. Jag har använt Wingdings i följande exempel.
4. Ladda presentationen med Presentation och ange laddningsalternativen.
5. Generera nu bildminiatyren, PDF och XPS för att verifiera resultaten.

Implementeringen av ovanstående ges nedan.

```javascript
// Använd laddningsalternativ för att definiera standardtypsnitten för vanlig och asiatisk text
var loadOptions = new aspose.slides.LoadOptions(aspose.slides.LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");
// Ladda presentationen
var pres = new aspose.slides.Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Generera bildminiatyr
    var slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
        // spara bilden på disken.
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // Generera PDF
    pres.save("output_out.pdf", aspose.slides.SaveFormat.Pdf);
    // Generera XPS
    pres.save("output_out.xps", aspose.slides.SaveFormat.Xps);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Vanliga frågor**

**Vad exakt påverkar DefaultRegularFont och DefaultAsianFont—endast export, eller även miniatyrer, PDF, XPS, HTML och SVG?**

De deltar i renderingspipeline för alla stödda utdata. Detta inkluderar bildminiatyrer, [PDF](/slides/sv/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/sv/nodejs-java/convert-powerpoint-to-xps/), [rasterbilder](/slides/sv/nodejs-java/convert-powerpoint-to-png/), [HTML](/slides/sv/nodejs-java/convert-powerpoint-to-html/), och [SVG](/slides/sv/nodejs-java/render-a-slide-as-an-svg-image/), eftersom Aspose.Slides använder samma layout- och teckenglypblösningslogik för dessa mål.

**Tillämpas standardtypsnitt när man bara läser och sparar en PPTX utan någon rendering?**

Nej. Standardtypsnitt spelar roll när text måste mätas och ritas. En enkel öppna‑spara av en presentation ändrar inte lagrade teckensnittssekvenser eller filens struktur. Standardtypsnitt används vid operationer som renderar eller återflödar text.

**Om jag lägger till egna teckensnittsmappar eller tillhandahåller teckensnitt från minnet, kommer de att beaktas vid val av standardtypsnitt?**

Ja. [Custom font sources](/slides/sv/nodejs-java/custom-font/) utökar katalogen över tillgängliga familjer och glyfer som motorn kan använda. Standardtypsnitt och eventuella [fallback rules](/slides/sv/nodejs-java/fallback-font/) kommer att lösas mot dessa källor först, vilket ger mer pålitlig täckning på servrar och i containrar.

**Kommer standardtypsnitt att påverka textmetriker (kerning, avstånd) och därmed radbrytningar och omslag?**

Ja. Att byta typsnitt ändrar glyfmått och kan förändra radbrytningar, omslag och paginering under rendering. För layoutstabilitet, [embed the original fonts](/slides/sv/nodejs-java/embedded-font/) eller välj metrisk kompatibla standard- och fallback‑familjer.

**Finns det någon poäng med att ange standardtypsnitt om alla typsnitt som används i presentationen är inbäddade?**

Ofta är det inte nödvändigt, eftersom [embedded fonts](/slides/sv/nodejs-java/embedded-font/) redan säkerställer ett konsekvent utseende. Standardtypsnitt hjälper fortfarande som en säkerhetsnät för tecken som inte täcks av den inbäddade delmängden eller när en fil blandar inbäddad och icke‑inbäddad text.