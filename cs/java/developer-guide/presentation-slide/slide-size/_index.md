---
title: Změna velikosti snímku prezentace v jazyce Java
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
descriptions: "Zjistěte, jak rychle změnit velikost snímků v souborech PPT, PPTX a ODP pomocí Javy a Aspose.Slides, optimalizovat prezentace pro jakoukoli obrazovku bez ztráty kvality."
---
## **Úvod**

Aspose.Slides poskytuje komplexní nástroje pro úpravu velikosti snímků a poměru stran v prezentacích PowerPoint, což je klíčové jak pro tisk, tak pro zobrazení na obrazovce. 

Oblíbené velikosti snímků a poměry:

- **Standard (poměr stran 4:3)**: Ideální pro starší obrazovky a zařízení.
- **Širokoúhlý (poměr stran 16:9)**: Doporučeno pro moderní projektory a displeje.

Zajistěte konzistenci po celé prezentaci, protože jediná velikost snímku a poměr stran se vztahuje na všechny snímky. Pro optimální výsledky nastavte rozměry snímku na začátku tvorby prezentace, abyste předešli komplikacím.

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

Pokud považujete běžné velikosti snímků (4:3 a 16:9) za nevhodné pro svou práci, můžete se rozhodnout použít konkrétní nebo jedinečnou velikost snímku. Například pokud plánujete vytisknout snímky v plné velikosti z prezentace na vlastní rozvržení stránky nebo pokud chcete prezentaci zobrazit na určitých typech obrazovek, pravděpodobně vám prospěje nastavení vlastní velikosti pro vaši prezentaci.

Tento ukázkový kód ukazuje, jak pomocí Aspose.Slides pro Java určit vlastní velikost snímku pro prezentaci v jazyce Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // velikost papíru A4
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zpracování obsahu snímku po změně velikosti**

Po změně velikosti snímku v prezentaci může dojít k deformaci obsahu snímků (například obrázků nebo objektů). Ve výchozím nastavení jsou objekty automaticky přizpůsobeny tak, aby vyplnily novou velikost snímku. Při změně velikosti snímku však můžete určit nastavení, které určuje, jak Aspose.Slides zachází s obsahem na snímcích.

V závislosti na tom, co chcete dosáhnout, můžete použít kterékoliv z těchto nastavení:

- `DoNotScale`

  Pokud nechcete, aby byly objekty na snímcích přizpůsobeny, použijte toto nastavení.

- `EnsureFit`

  Pokud chcete zmenšit velikost snímku a potřebujete, aby Aspose.Slides zmenšil objekty na snímcích tak, aby se všechny vešly na snímek (tím se vyhnete ztrátě obsahu), použijte toto nastavení. 

- `Maximize`

  Pokud chcete zvětšit velikost snímku a potřebujete, aby Aspose.Slides zvětšil objekty na snímcích tak, aby byly úměrné nové velikosti snímku, použijte toto nastavení. 

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

Ano. Aspose.Slides interně používá body, kde 1 bod odpovídá 1/72 palce. Můžete převést libovolnou jednotku (například milimetry nebo centimetry) na body a použít převedené hodnoty k určení šířky a výšky snímku.

**Ovlivní velmi velká vlastní velikost snímku výkon a spotřebu paměti během vykreslování?**

Ano. Větší rozměry snímků (v bodech) v kombinaci s vyšším měřítkem vykreslování vedou ke zvýšené spotřebě paměti a delším časům zpracování. Usilujte o praktickou velikost snímku a měřítko vykreslování upravujte pouze podle potřeby, abyste dosáhli požadované kvality výstupu.

**Mohu definovat jednu nestandardní velikost snímku a poté sloučit snímky z prezentací, které mají různé velikosti?**

Nemůžete [sloučit prezentace](/slides/cs/java/merge-presentation/), pokud mají různé velikosti snímků – nejprve změňte velikost jedné prezentace tak, aby odpovídala druhé. Při změně velikosti snímku si můžete vybrat, jak se bude zacházet s existujícím obsahem, pomocí možnosti [SlideSizeScaleType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slidesizescaletype/). Po sladění velikostí můžete sloučit snímky a zachovat formátování.

**Mohu generovat miniatury pro jednotlivé tvary nebo konkrétní oblasti snímku a budou respektovat novou velikost snímku?**

Ano. Aspose.Slides může vytvořit miniatury pro [celé snímky](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) i pro [vybrané tvary](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shape/#getImage-int-float-float-). Výsledné obrázky odrážejí aktuální velikost a poměr stran snímku, což zajišťuje jednotné oříznutí a geometrii.