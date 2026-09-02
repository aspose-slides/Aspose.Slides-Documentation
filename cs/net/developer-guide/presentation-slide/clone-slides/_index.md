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
description: "Rychle duplikujte snímky PowerPointu pomocí Aspose.Slides pro .NET. Postupujte podle našich přehledných ukázek kódu a automatizujte vytvoření PPT během několika sekund, čímž eliminujete ruční práci."
---
## **Úvod**

Klonování je proces vytvoření přesné kopie nebo repliky něčeho. Aspose.Slides také umožňuje zkopírovat (klonovat) libovolný snímek a poté vložit klonovaný snímek do aktuální prezentace nebo jakékoli jiné otevřené prezentace. Klonování snímku vytvoří nový snímek, který mohou vývojáři upravovat, aniž by ovlivnili původní snímek. Existuje několik způsobů, jak klonovat snímek:

- Klonování na konci prezentace.
- Klonování na jinou pozici v rámci prezentace.
- Klonování na konci jiné prezentace.
- Klonování na jinou pozici v jiné prezentaci.
- Klonování spolu s hlavním snímkem do jiné prezentace.

V Aspose.Slides pro .NET poskytuje kolekce snímků (kolekce objektů [ISlide](https://reference.aspose.com/slides/cs/net/aspose.slides/islide/)) vystavená objektem [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) metody [AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/addclone/) a [InsertClone](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/insertclone/) pro provedení výše popsaných operací klonování snímků.

## **Klonování snímku na konci prezentace**

Pokud chcete klonovat snímek a poté jej použít ve stejném souboru prezentace na konci existujících snímků, použijte metodu [AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/methods/addclone/index) podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) .
1. Získejte třídu [ISlideCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection) odkazem na kolekci Slides vystavenou objektem [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) .
1. Zavolejte metodu [AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/methods/addclone/index) vystavenou objektem [ISlideCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection) a jako parametr předáte snímek, který má být klonován.
1. Zapište upravený soubor prezentace.

V níže uvedeném příkladu jsme klonovali snímek (nacházející se na první pozici – index nula – v prezentaci) na konec prezentace.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // Zklonujte požadovaný snímek na konec kolekce snímků ve stejné prezentaci
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // Uložte upravenou prezentaci na disk
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```

## **Klonování snímku na jinou pozici v prezentaci**
Pokud chcete klonovat snímek a poté jej použít ve stejném souboru prezentace, ale na jiné pozici, použijte metodu [InsertClone](https://reference.aspose.com/slides/cs/net/aspose.slides.ishapecollection/insertclone/methods/1):

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) .
1. Získejte třídu odkazující na kolekci **Slides** vystavenou objektem [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) .
1. Zavolejte metodu [InsertClone](https://reference.aspose.com/slides/cs/net/aspose.slides.ishapecollection/insertclone/methods/1) vystavenou objektem [ISlideCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection) a jako parametry předáte snímek, který má být klonován, a index pro novou pozici.
1. Zapište upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme klonovali snímek (nacházející se na indexu 1 – pozice 2 – v prezentaci) na index 2 – pozice 3 – v prezentaci.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // Zklonujte požadovaný snímek na konec kolekce snímků ve stejné prezentaci
    ISlideCollection slds = pres.Slides;

    // Zklonujte požadovaný snímek na zadaný index ve stejné prezentaci
    slds.InsertClone(2, pres.Slides[1]);

    // Uložte upravenou prezentaci na disk
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```

## **Klonování snímku na konci jiné prezentace**
Pokud potřebujete klonovat snímek z jedné prezentace a použít jej v jiné prezentaci, na konci existujících snímků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) obsahující prezentaci, ze které bude snímek klonován.
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) obsahující cílovou prezentaci, do které bude snímek přidán.
1. Získejte třídu [ISlideCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection) odkazem na kolekci **Slides** vystavenou objektem Presentation cílové prezentace.
1. Zavolejte metodu [AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/methods/addclone/index) vystavenou objektem [ISlideCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection) a jako parametr předáte snímek ze zdrojové prezentace.
1. Zapište upravený soubor cílové prezentace.

V níže uvedeném příkladu jsme klonovali snímek (z první pozice zdrojové prezentace) na konec cílové prezentace.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation pro načtení zdrojového souboru prezentace
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Vytvořte instanci třídy Presentation pro cílový PPTX (kam bude snímek klonován)
    using (Presentation destPres = new Presentation())
    {
        // Zklonujte požadovaný snímek ze zdrojové prezentace na konec kolekce snímků v cílové prezentaci
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // Uložte cílovou prezentaci na disk
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Klonování snímku na jinou pozici v jiné prezentaci**
Pokud potřebujete klonovat snímek z jedné prezentace a použít jej v jiné prezentaci, na konkrétní pozici:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) obsahující zdrojovou prezentaci, ze které bude snímek klonován.
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) obsahující prezentaci, do níž bude snímek přidán.
1. Získejte třídu [ISlideCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection) odkazem na kolekci Slides vystavenou objektem Presentation cílové prezentace.
1. Zavolejte metodu [InsertClone](https://reference.aspose.com/slides/cs/net/aspose.slides.ishapecollection/insertclone/methods/1) vystavenou objektem [ISlideCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection) a jako parametry předáte snímek ze zdrojové prezentace a požadovanou pozici.
1. Zapište upravený soubor cílové prezentace.

V níže uvedeném příkladu jsme klonovali snímek (z nultého indexu zdrojové prezentace) na index 1 (pozice 2) cílové prezentace.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation pro načtení zdrojového souboru prezentace
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Vytvořte instanci třídy Presentation pro cílový PPTX (kam bude snímek klonován)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // Uložte cílovou prezentaci na disk
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Klonování snímku s jeho hlavním snímkem do jiné prezentace**
Pokud potřebujete klonovat snímek spolu s hlavním snímkem z jedné prezentace a použít jej v jiné prezentaci, musíte nejprve klonovat požadovaný hlavní snímek ze zdrojové prezentace do cílové prezentace. Poté použijete tento hlavní snímek pro klonování snímku s hlavním snímkem. Metoda **AddClone(ISlide, IMasterSlide)** očekává hlavní snímek z cílové prezentace, nikoli ze zdrojové. Postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) obsahující zdrojovou prezentaci, ze které bude snímek klonován.
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) obsahující cílovou prezentaci, do které bude snímek klonován.
1. Získejte snímek, který má být klonován, spolu s jeho hlavním snímkem.
1. Získejte třídu [IMasterSlideCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterslidecollection) odkazem na kolekci Masters vystavenou objektem [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) cílové prezentace.
1. Zavolejte metodu [AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/methods/addclone/index) vystavenou objektem [IMasterSlideCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterslidecollection) a jako parametr předáte hlavní snímek ze zdrojového PPTX k klonování.
1. Získejte třídu [ISlideCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection) nastavením odkazu na kolekci Slides vystavenou objektem [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) cílové prezentace.
1. Zavolejte metodu [AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/methods/addclone/index) vystavenou objektem [ISlideCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection) a jako parametry předáte snímek ze zdrojové prezentace a hlavní snímek.
1. Zapište upravený soubor cílové prezentace.

V níže uvedeném příkladu jsme klonovali snímek s hlavním snímkem (nacházející se v nultém indexu zdrojové prezentace) na konec cílové prezentace pomocí hlavního snímku ze zdrojového snímku.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation pro načtení zdrojového souboru prezentace

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // Vytvořte instanci třídy Presentation pro cílovou prezentaci (kam bude snímek klonován)
    using (Presentation destPres = new Presentation())
    {

        // Vytvořte ISlide ze sbírky snímků ve zdrojové prezentaci spolu s
        // hlavním snímkem
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Zklonujte požadovaný hlavní snímek ze zdrojové prezentace do sbírky hlavních snímků v
        // cílové prezentaci
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Zklonujte požadovaný hlavní snímek ze zdrojové prezentace do sbírky hlavních snímků v
        // cílové prezentaci
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // Zklonujte požadovaný snímek ze zdrojové prezentace s požadovaným hlavním snímkem na konec
        // sbírky snímků v cílové prezentaci
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // Zklonujte požadovaný hlavní snímek ze zdrojové prezentace do sbírky hlavních snímků v // cílové prezentaci
        // Uložte cílovou prezentaci na disk
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```

## **Klonování snímku na konci určené sekce**

S Aspose.Slides pro .NET můžete klonovat snímek z jedné sekce prezentace a vložit jej do jiné sekce ve stejné prezentaci. V tomto případě musíte použít metodu [AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/methods/addclone/index) z rozhraní [ISlideCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection).

Tento C# kód ukazuje, jak klonovat snímek a vložit klonovaný snímek do určené sekce:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 150, 100, 100); // ke klonování
    
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISection section = pres.Sections.AddSection("Section2", slide2);

    pres.Slides.AddClone(slide, section);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Zajistěte shodnou velikost snímků**

Při klonování snímků do jiné prezentace se ujistěte, že cílová prezentace má stejnou velikost snímku jako zdrojová. Pokud se velikosti liší, Aspose.Slides automaticky nepřepočítává velikost klonovaných tvarů – jejich původní souřadnice a rozměry zůstávají zachovány, což může způsobit nesprávné zarovnání obsahu nebo jeho přesahování mimo okraje snímku.

Můžete nastavit velikost snímku cílové prezentace tak, aby odpovídala zdrojové, před klonováním hlavního snímku a snímku:

```cs
SizeF sourceSize = sourcePresentation.SlideSize.Size;

targetPresentation.SlideSize.SetSize(
    sourceSize.Width, sourceSize.Height, SlideSizeScaleType.DoNotScale);
```

Udělejte to před klonováním hlavního snímku a snímku.

## **Často kladené otázky**

**Kopírují se také poznámky přednášejícího a komentáře recenzenta?**

Ano. Stránka s poznámkami a komentáře recenzenta jsou součástí klonu. Pokud je nechcete, [odstraňte je](/slides/cs/net/presentation-notes/) po vložení.

**Jak jsou zacházeno s grafy a jejich zdrojovými daty?**

Objekt grafu, formátování i vložená data jsou zkopírována. Pokud byl graf propojen s externím zdrojem (např. se sešitem vloženým jako OLE), tato vazba je zachována jako [objekt OLE](/slides/cs/net/manage-ole/). Po přesunu mezi soubory ověřte dostupnost dat a chování obnovy.

**Mohu ovlivnit pozici vložení a sekce pro klon?**

Ano. Klon můžete vložit na konkrétní index snímku a umístit jej do vybrané [sekce](/slides/cs/net/slide-section/). Pokud cílová sekce neexistuje, nejprve ji vytvořte a potom do ní snímek přesuňte.