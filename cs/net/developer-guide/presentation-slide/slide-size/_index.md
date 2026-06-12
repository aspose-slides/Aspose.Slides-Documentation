---
title: Změna velikosti snímku prezentace v .NET
linktitle: Velikost snímku
type: docs
weight: 70
url: /cs/net/slide-size/
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
- .NET
- C#
- Aspose.Slides
descriptions: "Zjistěte, jak rychle změnit velikost snímků v souborech PPT, PPTX a ODP pomocí .NET a Aspose.Slides, optimalizujte prezentace pro jakoukoli obrazovku bez ztráty kvality."
---
## **Úvod**

Aspose.Slides for .NET poskytuje komplexní nástroje pro úpravu velikosti snímku a poměru stran v prezentacích PowerPoint, což je důležité jak pro tisk, tak pro zobrazení na obrazovce. 

Oblíbené velikosti snímků a poměry:

- **Standard (poměr stran 4:3)**: Ideální pro starší obrazovky a zařízení.
- **Širokoúhlý (poměr stran 16:9)**: Doporučeno pro moderní projektory a displeje.

Zajistěte konzistenci v celé prezentaci, protože jediná velikost snímku a poměr stran se aplikuje na všechny snímky. Pro optimální výsledky nastavte rozměry snímku na začátku procesu tvorby prezentace, abyste se vyhnuli komplikacím.

{{% alert color="primary" %}} 
Ve výchozím nastavení používají prezentace vytvořené pomocí Aspose.Slides standardní poměr stran 4:3.
{{% /alert %}}

## **Jak změnit velikost snímku v prezentaci**

Tento příklad ukazuje, jak změnit velikost snímku v prezentaci pomocí Aspose.Slides v jazyce C#:

```csharp
using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **Určení vlastních velikostí snímků**

Přizpůsobení velikosti snímku vašim konkrétním potřebám, například pro jedinečné rozvržení papíru nebo specifikace obrazovky, může být užitečné. Zde je návod, jak nastavit vlastní velikost snímku pomocí Aspose.Slides pro .NET:

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // formát papíru A4
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **Řízení obsahu snímku po změně velikosti**

Po změně velikosti se může obsah snímku deformovat. Můžete řídit, jak Aspose.Slides tuto změnu spravuje:

- **`DoNotScale`**: Udržet objekty v původní velikosti, aby se nepřevzorkovály.
- **`EnsureFit`**: Zmenšit objekty, aby se vešly na menší snímky, čímž se zabrání ztrátě obsahu.
- **`Maximize`**: Zvětšit objekty tak, aby vyhovovaly větším snímkům pro estetickou konzistenci.

Příklad použití nastavení `Maximize` pro úpravu velikosti snímku:

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **Často kladené otázky**

**Mohu nastavit vlastní velikost snímku pomocí jednotek jiných než palce (například body nebo milimetry)?**

Ano. Aspose.Slides interně používá body, kde 1 bod odpovídá 1/72 palce. Můžete převést libovolnou jednotku (například milimetry nebo centimetry) na body a použít převodní hodnoty k definování šířky a výšky snímku.

**Ovlivní velmi velká vlastní velikost snímku výkon a spotřebu paměti během renderování?**

Ano. Větší rozměry snímku (v bodech) v kombinaci s vyšším měřítkem renderování vedou k vyšší spotřebě paměti a delším dobám zpracování. Zvolte praktickou velikost snímku a upravujte měřítko renderování jen podle potřeby, abyste dosáhli požadované kvality výstupu.

**Mohu definovat jednu nestandardní velikost snímku a poté sloučit snímky z prezentací, které mají odlišné velikosti?**

Nelze [sloučit prezentace](/slides/cs/net/merge-presentation/) pokud mají různé velikosti snímků — nejprve změňte velikost jedné prezentace, aby odpovídala druhé. Při změně velikosti snímku můžete zvolit, jak se zachází s existujícím obsahem pomocí možnosti [SlideSizeScaleType](https://reference.aspose.com/slides/cs/net/aspose.slides/slidesizescaletype/). Po zarovnání velikostí můžete sloučit snímky při zachování formátování.

**Mohu generovat miniatury pro jednotlivé tvary nebo konkrétní oblasti snímku a budou respektovat novou velikost snímku?**

Ano. Aspose.Slides dokáže generovat miniatury pro [celé snímky](https://reference.aspose.com/slides/cs/net/aspose.slides/slide/getimage/) i pro [vybrané tvary](https://reference.aspose.com/slides/cs/net/aspose.slides/shape/getimage/). Výsledné obrázky odrážejí aktuální velikost a poměr stran snímku, což zajišťuje konzistentní rámování a geometrii.