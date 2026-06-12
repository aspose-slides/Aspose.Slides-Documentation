---
title: Změna velikosti snímků prezentace na Androidu
linktitle: Velikost snímku
type: docs
weight: 70
url: /cs/androidjava/slide-size/
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
- plnoformátový snímek
- typ obrazovky
- neškálovat
- zajistit vložení
- maximalizovat
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
descriptions: "Rychle změňte velikost snímků v souborech PPT, PPTX a ODP pomocí Javy a Aspose.Slides pro Android, optimalizujte prezentace pro jakýkoli displej bez ztráty kvality."
---
## **Úvod**

Aspose.Slides poskytuje komplexní nástroje pro úpravu velikosti snímku a poměru stran v prezentacích PowerPoint, což je zásadní jak pro tisk, tak pro zobrazení na obrazovce. 

Populární velikosti snímků a poměry:

- **Standard (poměr stran 4:3)**: Ideální pro starší obrazovky a zařízení.
- **Širokoúhlý (poměr stran 16:9)**: Doporučeno pro moderní projektory a displeje.

Zajistěte konzistenci v celé prezentaci, protože jediná velikost snímku a poměr stran se použijí na všechny snímky. Pro optimální výsledek nastavte rozměry snímku na začátku procesu tvorby prezentace, abyste se vyhnuli komplikacím.

{{% alert color="primary" %}} 
Ve výchozím nastavení používají prezentace vytvořené pomocí Aspose.Slides standardní poměr stran 4:3.
{{% /alert %}}

## **Změna velikosti snímku v prezentacích**

Tento ukázkový kód ukazuje, jak změnit velikost snímku v prezentaci v jazyce Java pomocí Aspose.Slides:

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Určení vlastních velikostí snímků v prezentacích**

Pokud považujete běžné velikosti snímků (4:3 a 16:9) za nevhodné pro svou práci, můžete se rozhodnout použít konkrétní nebo jedinečnou velikost snímku. Například pokud plánujete tisknout snímky v plné velikosti z vaší prezentace na vlastní rozvržení stránky nebo pokud chcete prezentaci zobrazovat na určitých typech obrazovek, pravděpodobně vám prospěje nastavení vlastní velikosti pro vaši prezentaci. 

Tento ukázkový kód ukazuje, jak pomocí Aspose.Slides pro Android v Javě specifikovat vlastní velikost snímku pro prezentaci v jazyce Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // Formát papíru A4
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zpracování obsahu snímku po změně velikosti**

Po změně velikosti snímku v prezentaci se může obsah snímků (například obrázky nebo objekty) zdeformovat. Ve výchozím nastavení jsou objekty automaticky změněny tak, aby odpovídaly nové velikosti snímku. Při změně velikosti snímku prezentace však můžete určit nastavení, které určuje, jak Aspose.Slides zachází s obsahem na snímcích.

V závislosti na tom, co chcete dosáhnout, můžete použít některé z následujících nastavení:

- `DoNotScale`

  Pokud NECHCETE, aby objekty na snímcích byly měněny, použijte toto nastavení.

- `EnsureFit`

  Pokud chcete zmenšit na menší velikost snímku a potřebujete, aby Aspose.Slides zmenšilo objekty na snímcích tak, aby se všechny vešly (tím zabráníte ztrátě obsahu), použijte toto nastavení. 

- `Maximize`

  Pokud chcete zvětšit na větší velikost snímku a potřebujete, aby Aspose.Slides zvětšilo objekty na snímcích tak, aby byly úměrné nové velikosti snímku, použijte toto nastavení. 

Tento ukázkový kód ukazuje, jak použít nastavení `Maximize` při změně velikosti snímku v prezentaci:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**Mohu nastavit vlastní velikost snímku pomocí jednotek jiných než palce (například body nebo milimetry)?**

Ano. Aspose.Slides interně používá body, kde 1 bod je roven 1/72 palce. Můžete převést jakoukoli jednotku (například milimetry nebo centimetry) na body a použít převedené hodnoty k definování šířky a výšky snímku.

**Může velmi velká vlastní velikost snýmku ovlivnit výkon a využití paměti během vykreslování?**

Ano. Větší rozměry snímku (v bodech) v kombinaci s vyšším měřítkem vykreslování vedou k vyšší spotřebě paměti a delším dobám zpracování. Snažte se o praktickou velikost snímku a měřítko vykreslování upravujte jen podle potřeby, abyste dosáhli požadované kvality výstupu.

**Mohu definovat jednu nestandardní velikost snímku a poté sloučit snímky z prezentací, které mají různé velikosti?**

Nemůžete [sloučit prezentace](/slides/cs/androidjava/merge-presentation/) pokud mají různé velikosti snímků — nejprve změňte velikost jedné prezentace tak, aby odpovídala druhé. Při změně velikosti snímku můžete zvolit, jak se zachází s existujícím obsahem pomocí možnosti [SlideSizeScaleType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slidesizescaletype/). Po zarovnání velikostí můžete snímky sloučit a zachovat formátování.

**Mohu generovat miniatury pro jednotlivé tvary nebo konkrétní oblasti snímku a budou respektovat novou velikost snímku?**

Ano. Aspose.Slides může vykreslovat miniatury pro [celé snímky](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) i pro [vybrané tvary](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shape/#getImage-int-float-float-). Výsledné obrázky odrážejí aktuální velikost a poměr stran snímku, což zajišťuje konzistentní ohraničení a geometrii.