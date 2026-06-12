---
title: Převod snímků PowerPoint na PNG v JavaScriptu
linktitle: PowerPoint na PNG
type: docs
weight: 30
url: /cs/nodejs-java/convert-powerpoint-to-png/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint na PNG
- prezentace na PNG
- snímek na PNG
- PPT na PNG
- PPTX na PNG
- uložit PPT jako PNG
- uložit PPTX jako PNG
- exportovat PPT do PNG
- exportovat PPTX do PNG
- Node.js
- JavaScript
- Aspose.Slides
description: "Rychlý převod prezentací PowerPoint na vysoce kvalitní PNG obrázky v JavaScriptu pomocí Aspose.Slides pro Node.js, zajišťující přesné a automatizované výsledky."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentace PowerPoint na obrázky PNG pomocí Aspose.Slides. Ukazuje, jak načíst soubory prezentací ve formátech jako PPT, PPTX a ODP, vykreslit snímky jako obrázky a uložit výsledek ve formátu PNG.

Článek také demonstruje, jak přizpůsobit vytvořené PNG obrázky nastavením měřítka nebo zadáním požadované šířky a výšky.

## **Převod PowerPointu na PNG**

Postupujte podle těchto kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
2. Získejte objekt snímku ze sbírky vrácené metodou [Presentation.getSlides()](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation#getSlides--) ve třídě [Slide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Slide).
3. Použijte metodu [Slide.getImage()](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Slide) pro získání miniatury každého snímku.
4. Použijte metodu [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/iimage/#save) k uložení miniatury snímku ve formátu PNG.

Tento JavaScriptový kód ukazuje, jak převést prezentaci PowerPoint na PNG:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage();
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
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

## **Převod PowerPointu na PNG s vlastním rozměrem**

Pokud chcete získat PNG soubory s určitou mírou, můžete nastavit hodnoty `desiredX` a `desiredY`, které určují rozměry výsledné miniatury.

Tento kód v JavaScriptu demonstruje popsanou operaci:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var scaleX = 2.0;
    var scaleY = 2.0;
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(scaleX, scaleY);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
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

## **Převod PowerPointu na PNG s vlastní velikostí**

Pokud chcete získat PNG soubory s konkrétní velikostí, můžete předat preferované argumenty `width` a `height` pro `ImageSize`.

Tento kód ukazuje, jak převést PowerPoint na PNG při specifikaci velikosti obrázků:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 960, 720);
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(size);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
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

## **FAQ**

**Jak mohu exportovat pouze konkrétní tvar (např. graf nebo obrázek) místo celého snímku?**

Aspose.Slides podporuje [generování miniatur pro jednotlivé tvary](/slides/cs/nodejs-java/create-shape-thumbnails/); můžete vykreslit tvar do PNG obrázku.

**Je paralelní převod podporován na serveru?**

Ano, ale nesdílejte jednu instanci prezentace mezi vlákny. Použijte samostatnou instanci pro každé vlákno nebo proces.

**Jaká jsou omezení trial verze při exportu do PNG?**

Režim hodnocení přidává vodoznak k výstupním obrázkům a uplatňuje další omezení, dokud není použita licence.