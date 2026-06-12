---
title: Klonování snímků prezentace v .NET
linktitle: Klonovat snímky
type: docs
weight: 40
url: /cs/net/clone-slides/
keywords:
- klonovat snímek
- kopírovat snímek
- uložit snímek
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Rychle duplikujte snímky PowerPointu pomocí Aspose.Slides pro .NET. Postupujte podle našich přehledných ukázek kódu a automatizujte tvorbu PPT během sekund a eliminujte ruční práci."
---
## **Úvod**

Klónování je proces vytváření přesné kopie nebo repliky něčeho. Aspose.Slides také umožňuje zkopírovat (klonovat) libovolný snímek a poté vložit klonovaný snímek do aktuální prezentace nebo jakékoli jiné otevřené prezentace. Klonování snímků vytváří nový snímek, který mohou vývojáři upravovat, aniž by ovlivnili původní snímek. Existuje několik způsobů, jak klonovat snímek:

- Klónovat na konci prezentace.
- Klónovat na jiné pozici v rámci prezentace.
- Klónovat na konci jiné prezentace.
- Klónovat na jiné pozici v jiné prezentaci.
- Klónovat na konkrétní pozici v jiné prezentaci.

V Aspose.Slides pro .NET poskytuje kolekce snímků (kolekce objektů [ISlide](https://reference.aspose.com/slides/cs/net/aspose.slides/islide/)) vystavená objektem [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) metody [AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/addclone/) a [InsertClone](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/insertclone/) pro provedení výše popsaných operací klonování snímků.

## **Klonovat snímek na konci prezentace**

Pokud chcete klonovat snímek a poté jej použít ve stejném souboru prezentace na konci existujících snímků, použijte metodu [AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/methods/addclone/index) podle kroků uvedených níže:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2. Instancujte třídu [ISlideCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection) odkazováním na kolekci Slides vystavenou objektem [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
3. Zavolejte metodu [AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/methods/addclone/index) vystavenou objektem [ISlideCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection), a předávejte snímek, který má být klonován, jako parametr metodě [AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/methods/addclone/index).
4. Uložte upravený soubor prezentace.

V níže uvedeném příkladu jsme klonovali snímek (nacházející se na první pozici – index nula – v prezentaci) na konec prezentace.

```c#
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // Klonovat požadovaný snímek na konec kolekce snímků ve stejné prezentaci
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // Uložit upravenou prezentaci na disk
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```

## **Klonovat snímek na jinou pozici v rámci prezentace**

Pokud chcete klonovat snímek a poté jej použít ve stejném souboru prezentace, ale na jiné pozici, použijte metodu [InsertClone](https://reference.aspose.com/slides/cs/net/aspose.slides.ishapecollection/insertclone/methods/1):

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2. Instancujte třídu odkazováním na kolekci **Slides** vystavenou objektem [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
3. Zavolejte metodu [InsertClone](https://reference.aspose.com/slides/cs/net/aspose.slides.ishapecollection/insertclone/methods/1) vystavenou objektem [ISlideCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection) a předávejte snímek, který má být klonován, spolu s indexem nové pozice jako parametr metodě [InsertClone](https://reference.aspose.com/slides/cs/net/aspose.slides.ishapecollection/insertclone/methods/1).
4. Uložte upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme klonovali snímek (nacházející se na indexu nula – pozice 1 – v prezentaci) na index 1 – pozice 2 – v prezentaci.

```c#
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // Klonovat požadovaný snímek na konec kolekce snímků ve stejné prezentaci
    ISlideCollection slds = pres.Slides;

    // Klonovat požadovaný snímek na zadaný index ve stejné prezentaci
    slds.InsertClone(2, pres.Slides[1]);

    // Uložit upravenou prezentaci na disk
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```

## **Klonovat snímek na konci jiné prezentace**

Pokud potřebujete klonovat snímek z jedné prezentace a použít jej v jiné souboru prezentace, na konci existujících snímků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation), která obsahuje prezentaci, ze které bude snímek klonován.
2. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation), která obsahuje cílovou prezentaci, do které bude snímek přidán.
3. Instancujte třídu [ISlideCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection) odkazováním na kolekci **Slides** vystavenou objektem Presentation cílové prezentace.
4. Zavolejte metodu [AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/methods/addclone/index) vystavenou objektem [ISlideCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection) a předávejte snímek ze zdrojové prezentace jako parametr metodě [AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/methods/addclone/index).
5. Uložte upravený soubor cílové prezentace.

V níže uvedeném příkladu jsme klonovali snímek (z první pozice zdrojové prezentace) na konec cílové prezentace.

```c#
// Vytvořte instanci třídy Presentation pro načtení zdrojového souboru prezentace
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Vytvořte instanci třídy Presentation pro cílový PPTX (kam bude snímek klonován)
    using (Presentation destPres = new Presentation())
    {
        // Klonovat požadovaný snímek ze zdrojové prezentace na konec kolekce snímků v cílové prezentaci
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // Uložit cílovou prezentaci na disk
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Klonovat snímek na jinou pozici v jiné prezentaci**

Pokud potřebujete klonovat snímek z jedné prezentace a použít jej v jiné souboru prezentace, na konkrétní pozici:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation), která obsahuje zdrojovou prezentaci, ze které bude snímek klonován.
2. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation), která obsahuje prezentaci, do které bude snímek přidán.
3. Instancujte třídu [ISlideCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection) odkazováním na kolekci Slides vystavenou objektem Presentation cílové prezentace.
4. Zavolejte metodu [InsertClone](https://reference.aspose.com/slides/cs/net/aspose.slides.ishapecollection/insertclone/methods/1) vystavenou objektem [ISlideCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection) a předávejte snímek ze zdrojové prezentace spolu s požadovanou pozicí jako parametr metodě [InsertClone](https://reference.aspose.com/slides/cs/net/aspose.slides.ishapecollection/insertclone/methods/1).
5. Uložte upravený soubor cílové prezentace.

V níže uvedeném příkladu jsme klonovali snímek (z indexu nula zdrojové prezentace) na index 1 (pozice 2) cílové prezentace.

```c#
// Vytvořte instanci třídy Presentation pro načtení zdrojového souboru prezentace
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Vytvořte instanci třídy Presentation pro cílový PPTX (kam bude snímek klonován)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // Uložit cílovou prezentaci na disk
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Klonovat snímek na konkrétní pozici v jiné prezentaci**

Pokud potřebujete klonovat snímek s hlavním snímkem (master slide) z jedné prezentace a použít jej v jiné prezentaci, nejprve musíte klonovat požadovaný hlavní snímek ze zdrojové prezentace do cílové prezentace. Poté musíte tento hlavní snímek použít pro klonování snímku s hlavním snímkem. Metoda **AddClone(ISlide, IMasterSlide)** očekává hlavní snímek z cílové prezentace, nikoli ze zdrojové. Pro klonování snímku s hlavním snímkem postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) obsahující zdrojovou prezentaci, ze které bude snímek klonován.
2. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) obsahující cílovou prezentaci, do které bude snímek klonován.
3. Přistupte k snímku, který má být klonován, spolu s hlavním snímkem.
4. Instancujte třídu [IMasterSlideCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterslidecollection) odkazováním na kolekci Masters vystavenou objektem [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) cílové prezentace.
5. Zavolejte metodu [AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/methods/addclone/index) vystavenou objektem [IMasterSlideCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterslidecollection) a předávejte hlavní snímek ze zdrojového PPTX jako parametr metodě [AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/methods/addclone/index).
6. Instancujte třídu [ISlideCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection) nastavením reference na kolekci Slides vystavenou objektem [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) cílové prezentace.
7. Zavolejte metodu [AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/methods/addclone/index) vystavenou objektem [ISlideCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection) a předávejte snímek ze zdrojové prezentace k klonování a hlavní snímek jako parametr metodě [AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/methods/addclone/index).
8. Uložte upravený soubor cílové prezentace.

V níže uvedeném příkladu jsme klonovali snímek s hlavním snímkem (nacházející se na indexu nula zdrojové prezentace) na konec cílové prezentace pomocí hlavního snímku ze zdrojového snímku.

```c#
// Vytvořte instanci třídy Presentation pro načtení zdrojového souboru prezentace

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // Vytvořte instanci třídy Presentation pro cílovou prezentaci (kam bude snímek klonován)
    using (Presentation destPres = new Presentation())
    {

        // Vytvořte ISlide ze sady snímků ve zdrojové prezentaci spolu s
        // hlavním snímkem
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Klonovat požadovaný hlavní snímek ze zdrojové prezentace do kolekce hlavních snímků v
        // cílové prezentaci
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Klonovat požadovaný hlavní snímek ze zdrojové prezentace do kolekce hlavních snímků v
        // cílové prezentaci
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // Klonovat požadovaný snímek ze zdrojové prezentace s požadovaným hlavním snímkem na konec
        // kolekce snímků v cílové prezentaci
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // Klonovat požadovaný hlavní snímek ze zdrojové prezentace do kolekce hlavních snímků v // cílové prezentaci
        // Uložit cílovou prezentaci na disk
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```

## **Klonovat snímek na konci určené sekce**

S Aspose.Slides pro .NET můžete klonovat snímek z jedné sekce prezentace a vložit tento snímek do jiné sekce ve stejné prezentaci. V tomto případě musíte použít metodu [AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/methods/addclone/index) z rozhraní [ISlideCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection).

Tento kód v C# ukazuje, jak klonovat snímek a vložit klonovaný snímek do určené sekce:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 150, 100, 100); // pro klonování
    
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISection section = pres.Sections.AddSection("Section2", slide2);

    pres.Slides.AddClone(slide, section);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Často kladené otázky**

**Klonují se poznámky přednášejícího a komentáře recenzentů?**

Ano. Stránka s poznámkami a recenzní komentáře jsou zahrnuty do klonu. Pokud je nechcete, [odstraňte je](/slides/cs/net/presentation-notes/) po vložení.

**Jak jsou zacházeno s grafy a jejich datovými zdroji?**

Objekt grafu, formátování a vložená data jsou zkopírována. Pokud byl graf propojen s externím zdrojem (např. se sešitem vloženým jako OLE), toto propojení je zachováno jako [OLE objekt](/slides/cs/net/manage-ole/). Po přesunu mezi soubory ověřte dostupnost dat a chování obnovy.

**Mohu ovládat pozici vložení a sekce pro klon?**

Ano. Klon můžete vložit na konkrétní index snímku a umístit jej do vybrané [sekce](/slides/cs/net/slide-section/). Pokud cílová sekce neexistuje, nejprve ji vytvořte a poté do ní snímek přesuňte.