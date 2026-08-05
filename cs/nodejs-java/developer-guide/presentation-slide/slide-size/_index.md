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
description: "Zjistěte, jak rychle změnit velikost snímků v souborech PPT, PPTX a ODP pomocí Node.js a Aspose.Slides, optimalizovat prezentace pro libovolnou obrazovku bez ztráty kvality."
---
## **Úvod**

Aspose.Slides poskytuje komplexní nástroje pro nastavení velikosti snímku a poměru stran v prezentacích PowerPoint, což je klíčové jak pro tisk, tak pro zobrazení na obrazovce.

Oblíbené velikosti snímků a poměry:

- **Standardní (poměr stran 4:3)**: Ideální pro starší monitory a zařízení.
- **Širokoúhlý (poměr stran 16:9)**: Doporučeno pro moderní projektory a displeje.

Zajistěte konzistenci v celé prezentaci, protože jedna velikost snímku a poměr stran se vztahují na všechny snímky. Pro optimální výsledky nastavte rozměry snímků na začátku tvorby prezentace, abyste se vyhli komplikacím.

{{% alert color="primary" %}} 
Ve výchozím nastavení používají prezentace vytvořené pomocí Aspose.Slides standardní poměr stran 4:3.
{{% /alert %}}

## **Změna velikosti snímku v prezentacích**

Tento ukázkový kód vám ukazuje, jak změnit velikost snímku v prezentaci v JavaScriptu pomocí Aspose.Slides:

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

Pokud vám běžné velikosti snímků (4:3 a 16:9) nevyhovují, můžete se rozhodnout použít specifickou nebo jedinečnou velikost snímku. Například pokud plánujete tisknout snímky v plné velikosti z vaší prezentace na vlastní rozvržení stránky nebo pokud chcete prezentaci zobrazovat na určitých typech obrazovek, pravděpodobně vám prospěje nastavení vlastní velikosti pro vaši prezentaci.

Tento ukázkový kód vám ukazuje, jak pomocí Aspose.Slides for Node.js prostřednictvím Javy specifikovat vlastní velikost snímku pro prezentaci v JavaScriptu:

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

Po změně velikosti snímku v prezentaci se může obsah snímků (například obrázky nebo objekty) zdeformovat. Ve výchozím nastavení jsou objekty automaticky přizpůsobeny tak, aby odpovídaly nové velikosti snýmku. Při změně velikosti snímku však můžete určit nastavení, které určuje, jak Aspose.Slides zachází s obsahem na snímcích.

V závislosti na tom, co chcete dosáhnout, můžete použít kterékoliv z následujících nastavení:

- `DoNotScale`

  Pokud NECHCETE, aby byly objekty na snímcích přizpůsobeny, použijte toto nastavení.

- `EnsureFit`

  Pokud chcete zmenšit velikost snímku a potřebujete, aby Aspose.Slides zmenšil objekty na snímcích tak, aby se všechny vešly (tím se vyhnete ztrátě obsahu), použijte toto nastavení. 

- `Maximize`

  Pokud chcete zvětšit velikost snímku a potřebujete, aby Aspose.Slides zvětšil objekty na snímcích tak, aby byly úměrné nové velikosti snímku, použijte toto nastavení. 

Tento ukázkový kód vám ukazuje, jak použít nastavení `Maximize` při změně velikosti snímku prezentace:

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

## **Často kladené otázky**

**Mohu nastavit vlastní velikost snímku pomocí jednotek jiných než palce (například body nebo milimetry)?**

Ano. Aspose.Slides interně používá body, kde 1 bod je 1/72 palce. Můžete převést libovolnou jednotku (např. milimetry nebo centimetry) na body a použít převedené hodnoty k definování šířky a výšky snímku.

**Ovlivní velmi velká vlastní velikost snímku výkon a spotřebu paměti během renderování?**

Ano. Větší rozměry snímků (v bodech) v kombinaci s vyšším škálováním při renderování vedou ke zvýšené spotřebě paměti a delším časům zpracování. Zaměřte se na praktickou velikost snímku a upravujte škálování renderování jen podle potřeby, abyste dosáhli požadované kvality výstupu.

**Nemohu definovat jednu nestandardní velikost snímku a pak sloučit snímky z prezentací, které mají různé velikosti?**

Nemůžete [sloučit prezentace](/slides/cs/nodejs-java/merge-presentation/) pokud mají různé velikosti snímků — nejprve změňte velikost jedné prezentace tak, aby odpovídala druhé. Při změně velikosti snímku můžete zvolit, jak bude zacházeno s existujícím obsahem pomocí možnosti [SlideSizeScaleType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidesizescaletype/). Po vyrovnání velikostí můžete sloučit snímky a zachovat formátování.

**Mohu generovat náhledy pro jednotlivé tvary nebo konkrétní oblasti snímku a budou respektovat novou velikost snímku?**

Ano. Aspose.Slides může vykreslovat náhledy pro [celé snímky](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/#getImage) i pro [vybrané tvary](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/#getImage). Výsledné obrázky odrážejí aktuální velikost a poměr stran snímku, což zajišťuje konzistentní ořez a geometrii.