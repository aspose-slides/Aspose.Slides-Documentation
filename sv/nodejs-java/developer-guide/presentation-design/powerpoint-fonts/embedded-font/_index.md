---
title: Bädda in teckensnitt i presentationer med JavaScript
linktitle: Bädda in teckensnitt
type: docs
weight: 40
url: /sv/nodejs-java/embedded-font/
keywords:
- lägg till teckensnitt
- bädda in teckensnitt
- teckensnittsinbäddning
- hämta inbäddat teckensnitt
- lägg till inbäddat teckensnitt
- ta bort inbäddat teckensnitt
- komprimera inbäddat teckensnitt
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Bädda in TrueType‑teckensnitt i PowerPoint‑ och OpenDocument‑presentationer med Aspose.Slides för Node.js via Java, vilket säkerställer korrekt återgivning på alla plattformar."
---
## **Introduction**

**Inbäddade teckensnitt i PowerPoint** är användbara när du vill att din presentation ska visas korrekt på alla system eller enheter. Om du använde ett tredjeparts‑ eller icke‑standardteckensnitt för att vara kreativ i ditt arbete, har du ännu fler skäl att bädda in teckensnittet. Annars (utan inbäddade teckensnitt) kan texter eller siffror på dina bilder, layout, formatering osv. förändras eller förvandlas till förvirrande rektanglar. 

Klassen [FontsManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/FontsManager), klassen [FontData](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontdata/), klassen [Compress](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compress/) och deras klasser innehåller de flesta egenskaperna och metoderna du behöver för att arbeta med inbäddade teckensnitt i PowerPoint‑presentationer.

## **Get or Remove Embedded Fonts from Presentation**

Aspose.Slides tillhandahåller metoden [getEmbeddedFonts](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) (tillgänglig via klassen [FontsManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/FontsManager)) så att du kan hämta (eller ta reda på) de teckensnitt som är inbäddade i en presentation. För att ta bort teckensnitt används metoden [removeEmbeddedFont](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsmanager/#removeEmbeddedFont-aspose.slides.IFontData-) (tillgänglig via samma klass).

Denna JavaScript‑kod visar hur du hämtar och tar bort inbäddade teckensnitt från en presentation:

```javascript
// Skapar ett Presentation‑objekt som representerar en presentationsfil
var pres = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    // Renderar en bild som innehåller en textram som använder inbäddade "FunSized"
    var slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // Sparar bilden till disk i JPEG‑format
    try {
        slideImage.save("picture1_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    var fontsManager = pres.getFontsManager();
    // Hämtar alla inbäddade teckensnitt
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    // Letar upp teckensnittet "Calibri"
    var calibriEmbeddedFont = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log("" + embeddedFonts[i].getFontName());
        if ("Calibri" == embeddedFonts[i].getFontName()) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }
    // Tar bort teckensnittet "Calibri"
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);
    // Renderar presentationen; teckensnittet "Calibri" ersätts med ett befintligt
    slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // Sparar bilden till disk i JPEG‑format
    try {
        slideImage.save("picture2_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // Sparar presentationen utan inbäddat teckensnitt "Calibri" till disk
    pres.save("WithoutManageEmbeddedFonts_out.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Add Embedded Fonts to Presentation**

Genom att använda enumet [EmbedFontCharacters](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/embedfontcharacters/) och två överlagringar av metoden [addEmbeddedFont](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsmanager/#addEmbeddedFont-aspose.slides.IFontData-int-) kan du välja din föredragna (inbäddnings)regel för att bädda in teckensnitten i en presentation. Denna JavaScript‑kod visar hur du bäddar in och lägger till teckensnitt i en presentation:

```javascript
// Laddar presentationen
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    var allFonts = pres.getFontsManager().getFonts();
    var embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
    allFonts.forEach(font => {
        var embeddedFontsContainsFont = false;
        for (var i = 0; i < embeddedFonts.length; i++) {
            if (embeddedFonts[i].equals(font)) {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont) {
            pres.getFontsManager().addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    });
    // Sparar presentationen till disk
    pres.save("AddEmbeddedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Compress Embedded Fonts**

För att du ska kunna komprimera de teckensnitt som är inbäddade i en presentation och minska filstorleken tillhandahåller Aspose.Slides metoden [compressEmbeddedFonts](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts-aspose.slides.Presentation-) (tillgänglig via klassen [Compress](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compress/)).

Denna JavaScript‑kod visar hur du komprimerar inbäddade PowerPoint‑teckensnitt:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**How can I tell that a specific font in the presentation will still be substituted during rendering despite embedding?**  
Kontrollera [substitutionsinformation](/slides/sv/nodejs-java/font-substitution/) i teckenhanteraren och [fallback/substitutionsregler](/slides/sv/nodejs-java/fallback-font/): om teckensnittet är otillgängligt eller begränsat används en reserv.

**Is it worth embedding "system" fonts like Arial/Calibri?**  
Vanligtvis nej – de är nästan alltid tillgängliga. Men för full portabilitet i "tunna" miljöer (Docker, en Linux‑server utan förinstallerade teckensnitt) kan inbäddning av systemteckensnitt eliminera risken för oväntade ersättningar.