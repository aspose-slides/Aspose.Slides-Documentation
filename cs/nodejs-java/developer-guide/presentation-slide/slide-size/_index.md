---
title: Změna velikosti snímku prezentace v JavaScriptu
linktitle: Velikost snímku
type: docs
weight: 70
url: /cs/nodejs-java/slide-size/
keywords:
- velikost snímku
- poměr stran
- standardní
- širokoúhlý
- 4:3
- 16:9
- nastavit velikost snímku
- změnit velikost snímku
- vlastní velikost snímku
- speciální velikost snímku
- unikátní velikost snímku
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
descriptions: "Naučte se rychle měnit velikost snímků v souborech PPT, PPTX a ODP pomocí Node.js a Aspose.Slides, optimalizujte prezentace pro jakoukoli obrazovku bez ztráty kvality."
---
## **Úvod**

Aspose.Slides poskytuje komplexní nástroje pro úpravu velikosti snímku a poměru stran v PowerPoint prezentacích, což je zásadní jak pro tisk, tak pro zobrazování na obrazovce. 

Oblíbené velikosti snímků a poměry:

- **Standard (poměr stran 4:3)**: Ideální pro starší obrazovky a zařízení.
- **Širokoúhlý (poměr stran 16:9)**: Doporučeno pro moderní projektory a displeje.

Zajistěte konzistenci v celé prezentaci, protože jedna velikost snímku a poměr stran se vztahují na všechny snímky. Pro optimální výsledek nastavte rozměry snímku na začátku procesu tvorby prezentace, aby nedošlo ke komplikacím.

{{% alert color="primary" %}} 
Ve výchozím nastavení používají prezentace vytvořené pomocí Aspose.Slides standardní poměr stran 4:3.
{{% /alert %}}

## **Změna velikosti snímku v prezentacích**

Tento ukázkový kód vám ukáže, jak změnit velikost snímku v prezentaci v JavaScriptu pomocí Aspose.Slides:

```javascript
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

Pokud vám běžné velikosti snímků (4:3 a 16:9) nevyhovují, můžete se rozhodnout použít specifickou nebo unikátní velikost snímku. Například, pokud plánujete tisknout snímky v plné velikosti z prezentace na vlastní rozložení stránky nebo pokud chcete prezentaci zobrazovat na určitých typech obrazovek, pravděpodobně získáte výhodu používáním vlastního nastavení velikosti pro vaši prezentaci. 

Tento ukázkový kód vám ukáže, jak pomocí Aspose.Slides pro Node.js přes Java specifikovat vlastní velikost snímku pro prezentaci v JavaScriptu:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, aspose.slides.SlideSizeScaleType.DoNotScale);// velikost papíru A4
    pres.save("pres-a4-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Řešení problémů při změně velikosti snímků v prezentacích**

Po změně velikosti snímku v prezentaci se může obsah snímků (například obrázky nebo objekty) deformovat. Ve výchozím nastavení jsou objekty automaticky změněny velikostně tak, aby odpovídaly nové velikosti snímku. Nicméně při změně velikosti snímku můžete určit nastavení, které určuje, jak Aspose.Slides zachází s obsahem na snímcích.

V závislosti na tom, co chcete udělat nebo dosáhnout, můžete použít kterékoliv z těchto nastavení:

- `DoNotScale`

  Pokud NECHCETE, aby objekty na snímcích byly změněny velikostně, použijte toto nastavení.

- `EnsureFit`

  Pokud chcete škálovat na menší velikost snímku a potřebujete, aby Aspose.Slides zmenšilo objekty na snímcích tak, aby se všechny vešly na snímky (tím zabráníte ztrátě obsahu), použijte toto nastavení.

- `Maximize`

  Pokud chcete škálovat na větší velikost snímku a potřebujete, aby Aspose.Slides zvětšilo objekty na snímcích tak, aby byly úměrné nové velikosti snímku, použijte toto nastavení.

Tento ukázkový kód vám ukáže, jak použít nastavení `Maximize` při změně velikosti snímku v prezentaci:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.Ledger, aspose.slides.SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené dotazy**

**Mohu nastavit vlastní velikost snímku pomocí jednotek jiných než palce (například body nebo milimetry)?**

Ano. Aspose.Slides interně používá body, kde 1 bod je roven 1/72 palce. Jakoukoliv jednotku (například milimetry nebo centimetry) můžete převést na body a použít převedené hodnoty k definování šířky a výšky snímku.

**Ovplyvní velmi velká vlastní velikost snímku výkon a využití paměti během vykreslování?**

Ano. Větší rozměry snímku (v bodech) v kombinaci s vyšším měřítkem vykreslování vedou k vyšší spotřebě paměti a delším dobám zpracování. Snažte se o praktickou velikost snímku a měřítko vykreslování upravujte jen podle potřeby, aby byl dosažen požadovaný výstupní kvalita.

**Mohu definovat jednu nestandardní velikost snímku a poté sloučit snímky z prezentací, které mají různé velikosti?**

Nemůžete [sloučit prezentace](/slides/cs/nodejs-java/merge-presentation/) pokud mají různé velikosti snímků — nejprve změňte velikost jedné prezentace, aby odpovídala druhé. Při změně velikosti snímku můžete zvolit, jak bude zacházeno s existujícím obsahem, pomocí možnosti [SlideSizeScaleType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidesizescaletype/). Po zarovnání velikostí můžete sloučit snímky se zachováním formátování.

**Mohu generovat náhledy pro jednotlivé tvary nebo konkrétní oblasti snímku, a budou respektovat novou velikost snímku?**

Ano. Aspose.Slides může vykreslovat náhledy pro [celé snímky](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/#getImage) i pro [vybrané tvary](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/#getImage). Výsledné obrázky odrážejí aktuální velikost a poměr stran snímku, což zajišťuje konzistentní rámování a geometrii.