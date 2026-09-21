---
title: Změna velikosti snímku prezentace v Javě
linktitle: Velikost snímku
type: docs
weight: 70
url: /cs/java/slide-size/
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
- unikátní velikost snímku
- plnoformátový snímek
- typ obrazovky
- neškálovat
- zajistit přizpůsobení
- maximalizovat
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Naučte se rychle měnit velikost snímků v souborech PPT, PPTX a ODP pomocí Javy a Aspose.Slides, optimalizovat prezentace pro libovolnou obrazovku bez ztráty kvality."
---
## **Úvod**

Aspose.Slides poskytuje komplexní nástroje pro úpravu velikosti snímku a poměru stran v prezentacích PowerPoint, což je klíčové jak pro tisk, tak pro zobrazení na obrazovce. 

Oblíbené velikosti snímků a poměry:

- **Standard (4:3 Poměr stran)**: Ideální pro starší obrazovky a zařízení.
- **Widescreen (16:9 Poměr stran)**: Doporučeno pro moderní projektory a displeje.

Zajistěte konzistenci v celé prezentaci, protože jedna velikost snímku a poměr stran se vztahuje na všechny snímky. Pro optimální výsledek nastavte rozměry snímku na začátku tvorby prezentace, aby nedošlo ke komplikacím.

{{% alert color="info" title="Note" %}}
Ve výchozím nastavení používají prezentace vytvořené pomocí Aspose.Slides standardní poměr stran 4:3.
{{% /alert %}}

Poznámky a stránky s podklady mají odlišné rozměry od běžných snímků. Viz [Notes Page Size](/slides/cs/java/notes-size/) pro změnu jejich velikosti a orientace.

## **Změna velikosti snímku v prezentacích**

Tento ukázkový kód vám ukáže, jak změnit velikost snímku v prezentaci v Javě pomocí Aspose.Slides:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-16x9-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Určení vlastních velikostí snímků v prezentacích**

Pokud zjistíte, že běžné velikosti snímků (4:3 a 16:9) nejsou pro vaši práci vhodné, můžete se rozhodnout použít specifickou nebo jedinečnou velikost snímku. Například pokud plánujete tisknout snímky v plné velikosti z vaší prezentace na vlastní rozvržení stránky nebo pokud chcete prezentaci zobrazovat na určitých typech obrazovek, pravděpodobně získáte výhodu z nastavení vlastní velikosti pro vaši prezentaci. 

Tento ukázkový kód vám ukáže, jak pomocí Aspose.Slides pro Javu specifikovat vlastní velikost snímku pro prezentaci v Javě:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // Velikost papíru A4
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zpracování obsahu snímku po změně velikosti**

Po změně velikosti snímku v prezentaci může být obsah snímků (například obrázky nebo objekty) deformován. Ve výchozím nastavení jsou objekty automaticky přizpůsobeny tak, aby odpovídaly nové velikosti snímku. Při změně velikosti snímku v prezentaci však můžete určit nastavení, které určuje, jak Aspose.Slides zachází s obsahem na snímcích.

V závislosti na tom, co zamýšlíte udělat nebo dosáhnout, můžete použít některé z těchto nastavení:

- `DoNotScale`

  Pokud NECHCETE, aby byly objekty na snímcích měněny, použijte toto nastavení.

- `EnsureFit`

  Pokud chcete zmenšit velikost snímku a potřebujete, aby Aspose.Slides zmenšil objekty na snímcích tak, aby se všechny vešly (tím zabráníte ztrátě obsahu), použijte toto nastavení. 

- `Maximize`

  Pokud chcete zvětšit velikost snímku a potřebujete, aby Aspose.Slides zvětšil objekty na snímcích tak, aby byly poměrně novému rozměru snímku, použijte toto nastavení. 

Tento ukázkový kód vám ukáže, jak použít nastavení `Maximize` při změně velikosti snímku prezentace:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**Mohu nastavit vlastní velikost snímku pomocí jednotek jiných než palce (například body nebo milimetry)?**

Ano. Aspose.Slides interně používá body, kde 1 bod = 1/72 palce. Můžete převést libovolnou jednotku (např. milimetry nebo centimetry) na body a použít takové hodnoty k definování šířky a výšky snímku.

**Ovlivní velmi velká vlastní velikost snímku výkon a využití paměti během renderování?**

Ano. Větší rozměry snímku (v bodech) spolu s vyšším měřítkem renderování zvyšují spotřebu paměti a prodlužují dobu zpracování. Snažte se o praktickou velikost snímku a nastavujte měřítko renderování jen podle potřeby, aby byl dosažen požadovaný kvalita výstupu.

**Mohu definovat jednu nestandardní velikost snímku a poté sloučit snímky z prezentací, které mají různé velikosti?**

Nemůžete [merge presentations](/slides/cs/java/merge-presentation/) pokud mají různé velikosti snímků — nejprve změňte velikost jedné prezentace tak, aby odpovídala druhé. Při změně velikosti snímku můžete zvolit, jak bude existující obsah zpracován pomocí možnosti [SlideSizeScaleType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slidesizescaletype/). Po sladění velikostí můžete sloučit snímky a zachovat formátování.

**Mohu generovat miniatury pro jednotlivé tvary nebo konkrétní oblasti snímku a budou respektovat novou velikost snímku?**

Ano. Aspose.Slides může vykreslit miniatury pro [entire slides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) i pro [selected shapes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shape/#getImage-int-float-float-). Výsledné obrázky odrážejí aktuální velikost snímku a poměr stran, což zajišťuje konzistentní ohraničení a geometrii.