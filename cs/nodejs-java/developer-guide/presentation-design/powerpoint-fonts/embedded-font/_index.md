---
title: Vkládání fontů do prezentací pomocí JavaScriptu
linktitle: Vkládání fontu
type: docs
weight: 40
url: /cs/nodejs-java/embedded-font/
keywords:
- přidat font
- vložit font
- vkládání fontu
- získat vložený font
- přidat vložený font
- odebrat vložený font
- komprimovat vložený font
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Vkládejte TrueType fonty do prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro Node.js prostřednictvím Javy, čímž zajistíte přesné vykreslování na všech platformách."
---
## **Úvod**

**Embedded fonts in PowerPoint** jsou užitečné, když chcete, aby se vaše prezentace zobrazovala správně na jakémkoli systému nebo zařízení. Pokud jste použili font od třetí strany nebo nestandardní font, protože jste byli kreativní, máte ještě více důvodů font vložit. Jinak (bez vložených fontů) se texty nebo čísla na vašich snímcích, rozvržení, stylování atd. mohou změnit nebo se proměnit v matoucí obdélníky. 

Třída [FontsManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/FontsManager), třída [FontData](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontdata/) a třída [Compress](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compress/) obsahují většinu vlastností a metod, které potřebujete k práci s vloženými fonty v prezentacích PowerPoint.

## **Získání nebo odebrání vložených fontů z prezentace**

Aspose.Slides poskytuje metodu [getEmbeddedFonts](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) (vystupující z třídy [FontsManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/FontsManager)), která vám umožní získat (nebo zjistit) fonty vložené v prezentaci. K odebrání fontů se používá metoda [removeEmbeddedFont](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsmanager/#removeEmbeddedFont-aspose.slides.IFontData-) (vystupující ze stejné třídy).

Tento JavaScriptový kód vám ukazuje, jak získat a odebrat vložené fonty z prezentace:

```javascript
// Vytvoří objekt Presentation, který představuje soubor prezentace
var pres = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    // Vykreslí snímek obsahující textový rámec, který používá vložený "FunSized"
    var slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // Uloží obrázek na disk ve formátu JPEG
    try {
        slideImage.save("picture1_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    var fontsManager = pres.getFontsManager();
    // Získá všechny vložené fonty
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    // Najde font "Calibri"
    var calibriEmbeddedFont = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log("" + embeddedFonts[i].getFontName());
        if ("Calibri" == embeddedFonts[i].getFontName()) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }
    // Odstraní font "Calibri"
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);
    // Vykreslí prezentaci; font "Calibri" je nahrazen existujícím
    slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // Uloží obrázek na disk ve formátu JPEG
    try {
        slideImage.save("picture2_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // Uloží prezentaci bez vloženého fontu "Calibri" na disk
    pres.save("WithoutManageEmbeddedFonts_out.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Přidání vložených fontů do prezentace**

Pomocí výčtu [EmbedFontCharacters](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/embedfontcharacters/) a dvou přetížení metody [addEmbeddedFont](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsmanager/#addEmbeddedFont-aspose.slides.IFontData-int-) můžete vybrat preferované (vkládací) pravidlo pro vložení fontů do prezentace. Tento JavaScriptový kód vám ukazuje, jak vložit a přidat fonty do prezentace:

```javascript
// Načte prezentaci
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
    // Uloží prezentaci na disk
    pres.save("AddEmbeddedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Komprimace vložených fontů**

Aby vám umožnil komprimovat fonty vložené v prezentaci a snížit její velikost souboru, Aspose.Slides poskytuje metodu [compressEmbeddedFonts](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts-aspose.slides.Presentation-) (vystupující z třídy [Compress](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compress/)).

Tento JavaScriptový kód vám ukazuje, jak komprimovat vložené fonty PowerPoint:

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

**Jak mohu zjistit, že konkrétní font v prezentaci bude i přesto při vykreslování nahrazen, i když je vložen?**

Zkontrolujte [substitution information](/slides/cs/nodejs-java/font-substitution/) ve správci fontů a [fallback/substitution rules](/slides/cs/nodejs-java/fallback-font/): pokud není font k dispozici nebo je omezen, bude použita náhradní možnost.

**Stojí za to vkládat „systémové“ fonty jako Arial/Calibri?**

Obvykle ne — jsou téměř vždy k dispozici. Ale pro úplnou přenositelnost v „tenkých“ prostředích (Docker, Linuxový server bez předinstalovaných fontů) může vložení systémových fontů eliminovat riziko neočekávaných náhrad.