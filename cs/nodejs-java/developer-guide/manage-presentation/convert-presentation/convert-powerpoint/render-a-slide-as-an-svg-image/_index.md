---
title: Vykreslení snímků prezentace jako SVG obrázky v JavaScriptu
linktitle: Snímek na SVG
type: docs
weight: 50
url: /cs/nodejs-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint na SVG
- prezentace na SVG
- snímek na SVG
- PPT na SVG
- PPTX na SVG
- uložit PPT jako SVG
- uložit PPTX jako SVG
- exportovat PPT do SVG
- exportovat PPTX do SVG
- vykreslit snímek
- převést snímek
- exportovat snímek
- vektorový obrázek
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: Zjistěte, jak vykreslovat snímky PowerPoint jako SVG obrázky pomocí Aspose.Slides pro Node.js přes Java. Vysoce kvalitní vizuály s jednoduchými příklady kódu v JavaScriptu.
---
## **Přehled**

Tento článek vysvětluje, jak renderovat snímky prezentace jako SVG obrázky pomocí Aspose.Slides. Popisuje formát SVG a jeho výhody, včetně škálovatelnosti, přístupnosti a vhodnosti pro vývoj webu.

Naučíte se, jak načíst soubor prezentace, procházet její snímky a uložit každý snímek jako samostatný SVG soubor. Článek pokrývá formáty prezentací PowerPoint a OpenDocument, včetně PPT, PPTX, ODP a PPS, a ukazuje, jak provést konverzi programově pomocí třídy `Presentation` a metody `writeAsSvg`.

## **Formát SVG**

SVG—zkratka pro Scalable Vector Graphics—je standardní typ grafiky nebo formát používaný k vykreslování dvourozměrných obrázků. SVG ukládá obrázky jako vektory v XML s podrobnostmi, které definují jejich chování nebo vzhled.  

SVG je jedním z mála formátů obrázků, které splňují velmi vysoké standardy v těchto oblastech: škálovatelnost, interaktivita, výkon, přístupnost, programovatelnost a další. Z těchto důvodů se běžně používá ve vývoji webu.  

Můžete chtít použít SVG soubory, když potřebujete

- **vytisknout svou prezentaci ve *velmi velkém formátu*.** SVG obrázky lze škálovat na libovolné rozlišení nebo úroveň. Můžete měnit velikost SVG obrázků tolikrát, kolik je potřeba, aniž byste ztratili kvalitu.
- **použít grafy a diagramy ze svých snímků v *různých médiích nebo platformách*.** Většina čteček dokáže interpretovat SVG soubory. 
- **použít *nejmenší možné velikosti obrázků*.** SVG soubory jsou obvykle menší než jejich vysoce rozlišené ekvivalenty v jiných formátech, zejména v formátech založených na bitmapě (JPEG nebo PNG).

## **Vykreslení snímků jako SVG obrázky**

Aspose.Slides pro Node.js přes Java umožňuje exportovat snímky ve vašich prezentacích jako SVG obrázky. Proveďte následující kroky k vytvoření SVG obrázků:

1. Vytvořte instanci třídy Presentation.
2. Projděte všechny snímky v prezentaci.
3. Zapište každý snímek do vlastního SVG souboru pomocí FileOutputStream.

{{% alert color="primary" %}} 

Můžete si vyzkoušet naši [bezplatnou webovou aplikaci](https://products.aspose.app/slides/cs/conversion/ppt-to-svg), ve které jsme implementovali funkci konverze PPT na SVG z Aspose.Slides pro Node.js přes Java.

{{% /alert %}} 

Ukázkový kód v JavaScriptu vám ukazuje, jak převést PPT na SVG pomocí Aspose.Slides:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var fileStream = java.newInstanceSync("java.io.FileOutputStream", ("slide-" + index) + ".svg");
        try {
            slide.writeAsSvg(fileStream);
        } finally {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené otázky**

**Proč se může výsledné SVG lišit v různých prohlížečích?**

Podpora konkrétních SVG funkcí je v různých prohlížečových enginech implementována odlišně. Parametry [SVGOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgoptions/) pomáhají vyhladit nekompatibility.

**Je možné exportovat nejen snímky, ale také jednotlivé tvary do SVG?**

Ano. Každý [tvar lze uložit jako samostatné SVG](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/writeassvg/), což je výhodné pro ikony, piktogramy a opětovné použití grafiky.

**Lze spojit více snímků do jednoho SVG (pruh/dokument)?**

Standardní scénář je jeden snímek → jedno SVG. Kombinace několika snímků do jednoho SVG plátna je krok post‑processingu prováděný na úrovni aplikace.