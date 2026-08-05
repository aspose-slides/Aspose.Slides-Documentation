---
title: Změna velikosti snímku v prezentaci v Java
linktitle: Velikost snímku
type: docs
weight: 70
url: /cs/java/slide-size/
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
- plná velikost snímku
- typ obrazovky
- neškálovat
- zajistit přizpůsobení
- maximalizovat
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Naučte se rychle měnit velikost snímků v souborech PPT, PPTX a ODP pomocí Javy a Aspose.Slides, optimalizovat prezentace pro jakoukoli obrazovku bez ztráty kvality."
---
## **Úvod**

Aspose.Slides poskytuje komplexní nástroje pro úpravu velikosti snímku a poměru stran v prezentacích PowerPoint, což je klíčové jak pro tisk, tak pro zobrazení na obrazovce.

Oblíbené velikosti a poměry snímků:

- **Standard (poměr stran 4:3)**: Ideální pro starší monitory a zařízení.
- **Širokoúhlý (poměr stran 16:9)**: Doporučený pro moderní projektory a displeje.

Zajistěte konzistenci v celé prezentaci, protože jedna velikost snímku a jeden poměr stran se vztahují na všechny snímky. Pro optimální výsledek nastavte rozměry snímku na začátku tvorby prezentace, abyste se vyhnuli komplikacím.

{{% alert color="primary" %}} 
Ve výchozím nastavení používají prezentace vytvořené pomocí Aspose.Slides standardní poměr stran 4:3.
{{% /alert %}}

## **Změna velikosti snímku v prezentacích**

 Tento ukázkový kód vám ukazuje, jak změnit velikost snímku v prezentaci v jazyce Java pomocí Aspose.Slides:

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

Pokud vám běžné velikosti snímků (4:3 a 16:9) nevyhovují, můžete se rozhodnout použít konkrétní nebo jedinečnou velikost snímku. Například pokud plánujete tisknout snímky v plné velikosti z vaší prezentace na vlastní rozvržení stránky nebo pokud chcete prezentaci zobrazovat na určitých typech obrazovek, pravděpodobně získáte výhody z nastavení vlastní velikosti pro vaši prezentaci.

Tento ukázkový kód vám ukazuje, jak pomocí Aspose.Slides pro Java nastavit vlastní velikost snímku pro prezentaci v jazyce Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // Velikost papíru A4
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zpracování obsahu snímku po změně velikosti**

Po změně velikosti snímku v prezentaci se může obsah snímků (obrázky nebo objekty) deformovat. Ve výchozím nastavení jsou objekty automaticky přizpůsobeny tak, aby vyhovovaly nové velikosti snímku. Při změně velikosti snímku však můžete zadat nastavení, které určuje, jak se Aspose.Slides vypořádá s obsahem na snímcích.

V závislosti na tom, co chcete dosáhnout, můžete použít kterékoliv z těchto nastavení:

- `DoNotScale`

  Pokud **NECHCETE**, aby byly objekty na snímcích změněny velikostí, použijte toto nastavení.

- `EnsureFit`

  Pokud chcete přizpůsobit menší velikost snímku a potřebujete, aby Aspose.Slides zmenšil objekty tak, aby se všechny vešly na snímky (tím se vyhnete ztrátě obsahu), použijte toto nastavení.

- `Maximize`

  Pokud chcete přizpůsobit větší velikost snímku a potřebujete, aby Aspose.Slides zvětšil objekty tak, aby byly proporční k nové velikosti snímku, použijte toto nastavení.

Tento ukázkový kód vám ukazuje, jak použít nastavení `Maximize` při změně velikosti snímku v prezentaci:

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

Ano. Aspose.Slides používá vnitřně body, kde 1 bod odpovídá 1/72 palce. Můžete převést libovolnou jednotku (například milimetry nebo centimetry) na body a použít převedené hodnoty k definování šířky a výšky snímku.

**Ovlivní velmi velká vlastní velikost snímku výkon a spotřebu paměti během vykreslování?**

Ano. Větší rozměry snímku (v bodech) v kombinaci s vyšším měřítkem vykreslování vedou ke zvýšené spotřebě paměti a delším dobám zpracování. Zaměřte se na praktickou velikost snímku a měřítko vykreslování upravujte jen podle potřeby, abyste dosáhli požadované kvality výstupu.

**Mohu definovat jednu nestandardní velikost snímku a poté sloučit snímky z prezentací, které mají různé velikosti?**

Nemůžete [sloučit prezentace](/slides/cs/java/merge-presentation/), pokud mají různé velikosti snímků — nejprve upravte velikost jedné prezentace, aby odpovídala druhé. Při změně velikosti snímku můžete zvolit, jak bude zacházeno s existujícím obsahem, pomocí možnosti [SlideSizeScaleType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slidesizescaletype/). Po sladění velikostí můžete snímky sloučit a zachovat formátování.

**Mohu generovat miniatury pro jednotlivé tvary nebo konkrétní oblasti snímku a budou respektovat novou velikost snímku?**

Ano. Aspose.Slides může vytvářet miniatury pro [celé snímky](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) i pro [vybrané tvary](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shape/#getImage-int-float-float-). Výsledné obrázky odrážejí aktuální velikost a poměr stran snímku, čímž zajišťují konzistentní zarámování a geometrie.