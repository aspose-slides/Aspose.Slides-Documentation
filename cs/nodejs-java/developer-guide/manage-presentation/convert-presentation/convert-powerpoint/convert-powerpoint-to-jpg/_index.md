---
title: Převod PPT a PPTX na JPG v JavaScriptu
linktitle: PowerPoint na JPG
type: docs
weight: 60
url: /cs/nodejs-java/convert-powerpoint-to-jpg/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint na JPG
- prezentace na JPG
- snímek na JPG
- PPT na JPG
- PPTX na JPG
- uložit PowerPoint jako JPG
- uložit prezentaci jako JPG
- uložit snímek jako JPG
- uložit PPT jako JPG
- uložit PPTX jako JPG
- exportovat PPT do JPG
- exportovat PPTX do JPG
- Node.js
- JavaScript
- Aspose.Slides
description: "Převod snímků PowerPoint (PPT, PPTX) na vysoce kvalitní JPG obrázky v JavaScriptu pomocí Aspose.Slides pro Node.js přes Java s využitím rychlých a spolehlivých příkladů kódu."
---
## **Úvod**

Převod prezentací PowerPoint a OpenDocument do JPG obrázků usnadňuje sdílení snímků, optimalizaci výkonu a vkládání obsahu na webové stránky nebo do aplikací. Aspose.Slides umožňuje transformovat soubory PPTX, PPT i ODP na vysoce kvalitní JPEG obrázky. Tento průvodce popisuje různé metody konverze.

Díky těmto funkcím můžete snadno implementovat vlastní prohlížeč prezentací a vytvořit miniaturu pro každý snímek. To může být užitečné, pokud chcete chránit snímky před kopírováním nebo ukázat prezentaci v režimu jen pro čtení. Aspose.Slides umožňuje konvertovat celou prezentaci nebo konkrétní snímek do obrazových formátů.

## **Převod PowerPoint PPT/PPTX na JPG**
Zde jsou kroky pro převod PPT/PPTX na JPG:

1. Vytvořte instanci typu [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
2. Získejte objekt snímku typu [Slide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Slide) z kolekce [Presentation.getSlides()](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation#getSlides--) .
3. Vytvořte miniaturu každého snímku a poté ji převeďte na JPG. Metoda [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Slide#getImage-float-float-) se používá k získání miniatury snímku, vrací objekt [Imagess](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Images). Metoda [getImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Slide#getImage-aspose.slides.IRenderingOptions-float-float-) musí být volána z požadovaného snímku typu [Slide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Slide), přičemž měřítka výsledné miniatury jsou předána metodě.
4. Po získání miniatury snímku zavolejte metodu [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/iimage/#save) z objektu miniatury. Předáte název souboru a formát obrázku.

{{% alert color="primary" %}}

**Poznámka**: Konverze PPT/PPTX na JPG se liší od konverze na jiné typy v Aspose.Slides API. Pro jiné typy obvykle používáte [**Presentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-), ale zde potřebujete metodu [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/iimage/#save).

{{% /alert %}} 

```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // Vytvoří obrázek v plném měřítku
        var slideImage = sld.getImage(1.0, 1.0);
        // Uloží obrázek na disk ve formátu JPEG
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Převod PowerPoint PPT/PPTX na JPG s vlastním rozměrem**
Chcete‑li změnit rozměr výsledné miniatury a JPG obrázku, můžete nastavit hodnoty *ScaleX* a *ScaleY* jejich předáním do metod [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Slide#getImage-float-float-):

```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    // Definuje rozměry
    var desiredX = 1200;
    var desiredY = 800;
    // Získá škálované hodnoty X a Y
    var ScaleX = 1.0 / pres.getSlideSize().getSize().getWidth() * desiredX;
    var ScaleY = 1.0 / pres.getSlideSize().getSize().getHeight() * desiredY;
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // Vytvoří obrázek v plném měřítku
        var slideImage = sld.getImage(ScaleX, ScaleY);
        // Uloží obrázek na disk ve formátu JPEG
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Vykreslení komentářů při ukládání prezentace do obrázku**
Aspose.Slides pro Node.js přes Java poskytuje funkci, která umožňuje vykreslit komentáře na snímcích prezentace při převodu těchto snímků do obrázků. Tento JavaScriptový kód demonstruje operaci:

```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    var notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
    var opts = new aspose.slides.RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        var slideImage = sld.getImage(opts, java.newInstanceSync("java.awt.Dimension", 740, 960));
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.png", sld.getSlideNumber()));
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Tip" color="primary" %}}

Aspose poskytuje [BEZPLATNOU aplikaci Collage](https://products.aspose.app/slides/cs/collage). Pomocí této online služby můžete sloučit [JPG na JPG](https://products.aspose.app/slides/cs/collage/jpg) nebo PNG na PNG obrázky, vytvořit [foto mřížky](https://products.aspose.app/slides/cs/collage/photo-grid) a tak dále. 

{{% /alert %}}

## **Viz také**

Podívejte se na další možnosti převodu PPT/PPTX na obrázek, například:

- [PPT/PPTX na SVG konverze](/slides/cs/nodejs-java/render-a-slide-as-an-svg-image/).

## **Často kladené otázky**

**Podporuje tato metoda hromadnou konverzi?**

Ano, Aspose.Slides umožňuje hromadnou konverzi více snímků do JPG v jedné operaci.

**Podporuje konverze SmartArt, grafy a další složité objekty?**

Ano, Aspose.Slides vykresluje veškerý obsah, včetně SmartArt, grafů, tabulek, tvarů a dalších. Přesnost vykreslení se však může mírně lišit od PowerPointu, zejména při použití vlastních nebo chybějících písem.

**Existují nějaká omezení počtu snímků, které lze zpracovat?**

Aspose.Slides samotný neklade žádná striktní omezení na počet snímků, které můžete zpracovat. Nicméně při práci s velkými prezentacemi nebo obrázky vysokého rozlišení můžete narazit na chybu nedostatku paměti.