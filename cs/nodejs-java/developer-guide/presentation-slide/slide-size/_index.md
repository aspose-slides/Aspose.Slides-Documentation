---
title: Změna velikosti snímku prezentace v JavaScriptu
linktitle: Velikost snímku
type: docs
weight: 70
url: /cs/nodejs-java/slide-size/
keywords:
- velikost snímku
- poměr stran
- standard
- širokoúhlý
- 4:3
- 16:9
- nastavit velikost snímku
- změnit velikost snímku
- vlastní velikost snímku
- speciální velikost snímku
- jedinečná velikost snímku
- snímek v plné velikosti
- typ obrazovky
- neškálovat
- zajistit přizpůsobení
- maximalizovat
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se rychle měnit velikost snímků v souborech PPT, PPTX a ODP pomocí Node.js a Aspose.Slides, optimalizujte prezentace pro jakoukoli obrazovku bez ztráty kvality."
---
## **Úvod**

Aspose.Slides poskytuje komplexní nástroje pro úpravu velikosti snímku a poměru stran v prezentacích PowerPoint, což je klíčové jak pro tisk, tak pro zobrazení na obrazovce.

Oblíbené velikosti snímků a poměry:

- **Standard (poměr stran 4:3)**: Ideální pro starší monitory a zařízení.
- **Širokoúhlý (poměr stran 16:9)**: Doporučeno pro moderní projektory a displeje.

Zajistěte konzistenci v celé prezentaci, protože jediná velikost snímku a poměr stran se vztahují ke všem snímkům. Pro optimální výsledek nastavte rozměry snímku na začátku tvorby prezentace, abyste se vyhnuli komplikacím.

{{% alert color="info" title="Note" %}}
Ve výchozím nastavení používají prezentace vytvořené pomocí Aspose.Slides standardní poměr stran 4:3.
{{% /alert %}}

Poznámky a stránky s výstřižky mají jiné rozměry než běžné snímky. Viz [Velikost stránky poznámek](/slides/cs/nodejs-java/notes-size/) pro změnu jejich velikosti a orientace.

## **Změna velikosti snímku v prezentacích**

 Tento ukázkový kód ukazuje, jak změnit velikost snímku v prezentaci v JavaScriptu pomocí Aspose.Slides:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.OnScreen16x9, aspose.slides.SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Určení vlastních velikostí snímků v prezentacích**

Pokud vám běžné velikosti snímků (4:3 a 16:9) nevyhovují, můžete zvolit konkrétní nebo jedinečnou velikost snímku. Například pokud plánujete tisknout snímky v plné velikosti na vlastní rozložení stránky nebo chcete prezentaci zobrazovat na určitých typech obrazovek, pravděpodobně získáte výhody z nastavení vlastní velikosti pro vaši prezentaci.

Tento ukázkový kód ukazuje, jak pomocí Aspose.Slides pro Node.js přes Java specifikovat vlastní velikost snímku pro prezentaci v JavaScriptu:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, aspose.slides.SlideSizeScaleType.DoNotScale);// formát papíru A4
    pres.save("pres-a4-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Řešení problémů při změně velikosti snímků v prezentacích**

Po změně velikosti snímku v prezentaci se může obsah snímků (obrázky nebo objekty) deformovat. Ve výchozím nastavení se objekty automaticky přizpůsobí nové velikosti snímku. Při změně velikosti snímku však můžete určit nastavení, které určuje, jak Aspose.Slides zachází s obsahem na snímcích.

Podle toho, co chcete dosáhnout, můžete použít některé z těchto nastavení:

- `DoNotScale`

  Pokud **NE** chcete, aby se objekty na snímcích měnily, použijte toto nastavení.

- `EnsureFit`

  Pokud chcete přizpůsobit menší velikost snímku a potřebujete, aby Aspose.Slides zmenšil objekty tak, aby se všechny vešly na snímek (tím se vyhnete ztrátě obsahu), použijte toto nastavení.

- `Maximize`

  Pokud chcete přizpůsobit větší velikost snímku a potřebujete, aby Aspose.Slides zvětšil objekty tak, aby byly úměrné nové velikosti snímku, použijte toto nastavení.

Tento ukázkový kód ukazuje, jak použít nastavení `Maximize` při změně velikosti snímku v prezentaci:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.Ledger, aspose.slides.SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené otázky**

**Mohu nastavit vlastní velikost snímku pomocí jednotek jiných než palce (například body nebo milimetry)?**

Ano. Aspose.Slides interně používá body, kde 1 bod odpovídá 1/72 palce. Jakoukoli jednotku (například milimetry nebo centimetry) můžete převést na body a použít převedené hodnoty k definování šířky a výšky snímku.

**Ovlivní velmi velká vlastní velikost snímku výkon a spotřebu paměti během vykreslování?**

Ano. Větší rozměry snímku (v bodech) v kombinaci s vyšším měřítkem vykreslování zvyšují spotřebu paměti a prodlužují dobu zpracování. Zvolte praktickou velikost snímku a upravujte měřítko vykreslování jen podle potřeby, aby byl dosažen požadovaný výstupní kvalita.

**Mohu definovat jednu nestandardní velikost snímku a pak sloučit snímky z prezentací, které mají různé velikosti?**

Nemůžete [sloučit prezentace](/slides/cs/nodejs-java/merge-presentation/) pokud mají různé velikosti snímků — nejprve změňte velikost jedné prezentace tak, aby odpovídala druhé. Při změně velikosti snímku můžete zvolit, jak bude zacházeno s existujícím obsahem pomocí možnosti [SlideSizeScaleType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidesizescaletype/). Po vyrovnání velikostí můžete sloučit snímky při zachování formátování.

**Mohu generovat miniatury pro jednotlivé tvary nebo konkrétní oblasti snímku a budou respektovat novou velikost snímku?**

Ano. Aspose.Slides dokáže vytvářet miniatury pro [celé snímky](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/#getImage) i pro [vybrané tvary](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/#getImage). Výsledné obrázky odrážejí aktuální velikost a poměr stran snímku, což zajišťuje konzistentní rámování a geometrii.