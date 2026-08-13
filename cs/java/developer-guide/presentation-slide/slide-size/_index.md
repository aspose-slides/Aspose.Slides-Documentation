---
title: Změna velikosti snímku prezentace v Javě
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
- jedinečná velikost snímku
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
description: "Naučte se rychle měnit velikost snímků v souborech PPT, PPTX a ODP pomocí Javy a Aspose.Slides, optimalizujte prezentace pro jakoukoli obrazovku bez ztráty kvality."
---
## **Introduction**

Aspose.Slides poskytuje komplexní nástroje pro úpravu velikosti snímku a poměru stran v prezentacích PowerPoint, což je kritické jak pro tisk, tak pro zobrazování na obrazovce.

Popular Slide Sizes and Ratios:

- **Standard (4:3 Aspect Ratio)**: Ideální pro starší monitory a zařízení.
- **Widescreen (16:9 Aspect Ratio)**: Doporučeno pro moderní projektory a displeje.

Zajistěte konzistenci v celé prezentaci, protože jedna velikost snímku a poměr stran se vztahují na všechny snímky. Pro optimální výsledek nastavte rozměry snímku na začátku tvorby prezentace, abyste se vyhnuli komplikacím.

{{% alert color="info" %}} 
Ve výchozím nastavení používají prezentace vytvořené pomocí Aspose.Slides standardní poměr stran 4:3.
{{% /alert %}}

## **Change the Slide Size in Presentations**

Tento ukázkový kód vám ukazuje, jak změnit velikost snímku v prezentaci v jazyce Java pomocí Aspose.Slides:

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

## **Specify Custom Slide Sizes in Presentations**

Pokud vám běžné velikosti snímků (4:3 a 16:9) nevyhovují, můžete se rozhodnout použít konkrétní nebo jedinečnou velikost snímku. Například pokud plánujete tisknout snímky v plné velikosti z vaší prezentace na vlastní rozvržení stránky nebo pokud chcete zobrazovat prezentaci na určitých typech obrazovek, pravděpodobně získáte výhodu z nastavení vlastní velikosti pro vaši prezentaci.

Tento ukázkový kód vám ukazuje, jak pomocí Aspose.Slides pro Java zadat vlastní velikost snímku pro prezentaci v jazyce Java:

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

## **Handle Slide Content After Resizing**

Po změně velikosti snímku v prezentaci se může obsah snímků (obrázky nebo objekty) zkreslit. Ve výchozím nastavení jsou objekty automaticky změněny tak, aby odpovídaly nové velikosti snímku. Při změně velikosti snímku však můžete zadat nastavení, které určuje, jak Aspose.Slides zachází s obsahem na snímcích.

Podle toho, co chcete dosáhnout, můžete použít kterékoliv z těchto nastavení:

- `DoNotScale`

  Pokud **ne**chcete, aby objekty na snímcích byly měněny, použijte toto nastavení.

- `EnsureFit`

  Pokud chcete zmenšit na menší velikost snímku a potřebujete, aby Aspose.Slides zmenšil objekty na snímcích tak, aby se všechny vešly (tím se vyhnete ztrátě obsahu), použijte toto nastavení.

- `Maximize`

  Pokud chcete zvětšit na větší velikost snímku a potřebujete, aby Aspose.Slides zvětšil objekty na snímcích, aby byly úměrné nové velikosti, použijte toto nastavení.

Tento ukázkový kód vám ukazuje, jak použít nastavení `Maximize` při změně velikosti snímku v prezentaci:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Can I set a custom slide size using units other than inches (for example, points or millimeters)?

Ano. Aspose.Slides interně používá body, kde 1 bod = 1/72 palce. Jakoukoli jednotku (například milimetry nebo centimetry) můžete převést na body a použít převodní hodnoty k definování šířky a výšky snímku.

### Will a very large custom slide size affect performance and memory usage during rendering?

Ano. Větší rozměry snímků (v bodech) v kombinaci s vyšším měřítkem vykreslování vedou k vyšší spotřebě paměti a delším dobám zpracování. Snažte se o praktickou velikost snímku a upravujte měřítko vykreslování jen podle potřeby, abyste dosáhli požadované kvality výstupu.

### Can I define one non-standard slide size and then merge slides from presentations that have different sizes?

Nemůžete [sloučit prezentace](/slides/cs/java/merge-presentation/) pokud mají různé velikosti snímků — nejprve změňte velikost jedné prezentace, aby odpovídala druhé. Při změně velikosti snímku můžete zvolit, jak se bude zacházet s existujícím obsahem pomocí možnosti [SlideSizeScaleType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slidesizescaletype/). Po sladění velikostí můžete sloučit snímky při zachování formátování.

### Can I generate thumbnails for individual shapes or specific regions of a slide, and will they respect the new slide size?

Ano. Aspose.Slides může generovat miniatury pro [entire slides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) i pro [selected shapes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shape/#getImage-int-float-float-). Výsledné obrázky odrážejí aktuální velikost snímku a poměr stran, což zajišťuje konzistentní rámování a geometrii.