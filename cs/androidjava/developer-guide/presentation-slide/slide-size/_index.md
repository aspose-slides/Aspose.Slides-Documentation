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
- unikátní velikost snímku
- plnoformátový snímek
- typ obrazovky
- neškálovat
- zajistit přizpůsobení
- maximalizovat
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Rychle změňte velikost snímků v souborech PPT, PPTX a ODP pomocí Javy a Aspose.Slides pro Android, optimalizujte prezentace pro jakoukoli obrazovku bez ztráty kvality."
---
## **Úvod**

Aspose.Slides poskytuje komplexní nástroje pro úpravu velikosti snímku a poměru stran v prezentacích PowerPoint, což je klíčové jak pro tisk, tak pro zobrazení na obrazovce.

Oblíbené velikosti snímků a poměry:

- **Standard (4:3 poměr stran)**: Ideální pro starší obrazovky a zařízení.
- **Širokoúhlý (16:9 poměr stran)**: Doporučeno pro moderní projektory a displeje.

Zajistěte konzistenci v celé prezentaci, protože jediná velikost snímku a poměr stran se vztahují na všechny snímky. Pro optimální výsledek nastavte rozměry snímku na začátku procesu tvorby prezentace, abyste se vyhnuli komplikacím.

{{% alert color="info" title="Note" %}}
Ve výchozím nastavení používají prezentace vytvořené pomocí Aspose.Slides standardní poměr stran 4:3.
{{% /alert %}}

Stránky poznámek a podkladů mají odlišné rozměry od běžných snímků. Viz [Velikost poznámkové stránky](/slides/cs/androidjava/notes-size/) pro změnu jejich velikosti a orientace.

## **Změna velikosti snímku v prezentacích**

Tento ukázkový kód vám ukáže, jak v Javě pomocí Aspose.Slides změnit velikost snímku v prezentaci:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zadání vlastních velikostí snímků v prezentacích**

Pokud vám běžné velikosti snímků (4:3 a 16:9) nevyhovují, můžete použít specifickou nebo unikátní velikost snímku. Například pokud plánujete tisknout snímky v plné velikosti na vlastní rozvržení stránky nebo chcete prezentaci zobrazovat na určitých typech obrazovek, pravděpodobně získáte výhodu z nastavení vlastní velikosti pro vaši prezentaci.

Tento ukázkový kód vám ukáže, jak pomocí Aspose.Slides pro Android přes Javu nastavit vlastní velikost snímku pro prezentaci v Javě:

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

Po změně velikosti snímku v prezentaci může být obsah snímků (obrázky nebo objekty) zkreslený. Ve výchozím nastavení jsou objekty automaticky upraveny tak, aby odpovídaly nové velikosti snímku. Při změně velikosti snímku však můžete specifikovat nastavení, které určuje, jak se Aspose.Slides vypořádá s obsahem na snímcích.

V závislosti na tom, co chcete dosáhnout, můžete použít kterékoliv z těchto nastavení:

- `DoNotScale`

  Pokud **NE** chcete, aby byly objekty na snímcích změněny, použijte toto nastavení.

- `EnsureFit`

  Pokud chcete zmenšit snímek a potřebujete, aby Aspose.Slides zmenšil objekty tak, aby se všechny vešly na snímek (tím zabráníte ztrátě obsahu), použijte toto nastavení.

- `Maximize`

  Pokud chcete zvětšit snímek a potřebujete, aby Aspose.Slides zvětšil objekty tak, aby byly úměrné nové velikosti snímku, použijte toto nastavení.

Tento ukázkový kód vám ukáže, jak použít nastavení `Maximize` při změně velikosti snímku v prezentaci:

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

Ano. Aspose.Slides používá interně body, kde 1 bod odpovídá 1/72 palce. Jakoukoliv jednotku (například milimetry nebo centimetry) můžete převést na body a použít převedené hodnoty pro definování šířky a výšky snímku.

**Ovlivní velmi velká vlastní velikost snímku výkon a spotřebu paměti během vykreslování?**

Ano. Větší rozměry snímku (v bodech) spojené s vyšším měřítkem vykreslování vedou ke zvýšené spotřebě paměti a delším časům zpracování. Usilujte o praktickou velikost snímku a upravujte měřítko vykreslování pouze podle potřeby k dosažení požadované kvality výstupu.

**Mohu definovat jednu nestandardní velikost snímku a poté sloučit snímky z prezentací, které mají různé velikosti?**

Nemůžete [sloučit prezentace](/slides/cs/androidjava/merge-presentation/), pokud mají různé velikosti snímků — nejprve změňte velikost jedné prezentace, aby odpovídala druhé. Při změně velikosti snímku můžete zvolit, jak bude zacházeno s existujícím obsahem, pomocí možnosti [SlideSizeScaleType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slidesizescaletype/). Po nastavení shodných rozměrů můžete sloučit snímky při zachování formátování.

**Mohu generovat náhledy pro jednotlivé tvary nebo konkrétní oblasti snímku a budou respektovat novou velikost snímku?**

Ano. Aspose.Slides může vykreslit náhledy pro [celé snímky](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) i pro [vybrané tvary](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shape/#getImage-int-float-float-). Výsledné obrázky odrážejí aktuální velikost snímku a poměr stran, což zajišťuje konzistentní ohraničení a geometrickou přesnost.