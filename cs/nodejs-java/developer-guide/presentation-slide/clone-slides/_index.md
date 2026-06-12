---
title: Klonování snímků prezentace v JavaScriptu
linktitle: Klonovat snímky
type: docs
weight: 35
url: /cs/nodejs-java/clone-slides/
keywords:
- klonovat snímek
- kopírovat snímek
- uložit snímek
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Rychle duplikujte snímky PowerPointu pomocí Aspose.Slides pro Node.js. Postupujte podle našich ukázkových kódů a automatizujte tvorbu PPT během několika sekund a odstraňte ruční práci."
---
## **Úvod**

Klónování je proces vytváření přesné kopie nebo replika něčeho. Aspose.Slides for Node.js via Java také umožňuje vytvořit kopii nebo klon libovolného snímku a následně vložit tento klonovaný snímek do aktuální nebo jakékoli jiné otevřené prezentace. Proces klonování snímků vytváří nový snímek, který mohou vývojáři upravovat, aniž by změnili původní snímek. Existuje několik možných způsobů, jak klonovat snímek:

- Klonovat na konci v rámci prezentace.
- Klonovat na jiném místě v rámci prezentace.
- Klonovat na konci v jiné prezentaci.
- Klonovat na jiném místě v jiné prezentaci.
- Klonovat na konkrétním místě v jiné prezentaci.

V Aspose.Slides for Node.js via Java (kolekce objektů [Slide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Slide) ) vystavená objektem [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) poskytuje metody [addClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) a [insertClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-), které umožňují provést výše uvedené typy klonování snímků

## **Klonovat na konci v rámci prezentace**
Pokud chcete klonovat snímek a poté jej použít ve stejném souboru prezentace na konci existujících snímků, použijte metodu [addClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
1. Instanciujte třídu [SlideCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation#getSlides--) odkazem na kolekci Slides, kterou vystavuje objekt [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
1. Zavolejte metodu [addClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) vystavenou objektem [SlideCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation#getSlides--) a jako parametr předložte snímek, který má být klonován.
1. Zapište upravený soubor prezentace.

V níže uvedeném příkladu jsme klonovali snímek (nacházející se na první pozici – nultý index – v prezentaci) na konec prezentace.

```javascript
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Zkopírujte požadovaný snímek na konec kolekce snímků ve stejné prezentaci
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // Zapíše upravenou prezentaci na disk
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klonovat na jiném místě v rámci prezentace**
Pokud chcete klonovat snímek a poté jej použít ve stejném souboru prezentace, ale na jiné pozici, použijte metodu [insertClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-):

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
1. Instanciujte třídu odkazem na kolekci **Slides** vystavenou objektem [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
1. Zavolejte metodu [insertClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) vystavenou objektem [SlideCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation#getSlides--) a jako parametry předložte snímek, který má být klonován, spolu s indexem nové pozice.
1. Zapište upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme klonovali snímek (nacházející se na nultém indexu – pozice 1 – v prezentaci) na index 1 – pozice 2 – v prezentaci.

```javascript
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // Zkopírujte požadovaný snímek na konec kolekce snímků ve stejné prezentaci
    var slds = pres.getSlides();
    // Zkopírujte požadovaný snímek na určený index ve stejné prezentaci
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // Zapíše upravenou prezentaci na disk
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klonovat na konci v jiné prezentaci**
Pokud potřebujete klonovat snímek z jedné prezentace a použít jej v jiné souboru prezentace, na konci existujících snímků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) obsahující prezentaci, ze které bude snímek klonován.
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) obsahující cílovou prezentaci, do které bude snímek přidán.
1. Instanciujte třídu [SlideCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideCollection) odkazem na kolekci **Slides**, kterou vystavuje objekt Presentation cílové prezentace.
1. Zavolejte metodu [addClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) vystavenou objektem [SlideCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation#getSlides--) a jako parametr předložte snímek ze zdrojové prezentace.
1. Zapište upravený soubor cílové prezentace.

V níže uvedeném příkladu jsme klonovali snímek (z prvního indexu zdrojové prezentace) na konec cílové prezentace.

```javascript
// Vytvořte instanci třídy Presentation pro načtení zdrojového souboru prezentace
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Vytvořte instanci třídy Presentation pro cílový PPTX (kam bude snímek klonován)
    var destPres = new aspose.slides.Presentation();
    try {
        // Zkopírujte požadovaný snímek ze zdrojové prezentace na konec kolekce snímků v cílové prezentaci
        var slds = destPres.getSlides();
        slds.addClone(srcPres.getSlides().get_Item(0));
        // Zapíše cílovou prezentaci na disk
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klonovat na jiném místě v jiné prezentaci**
Pokud potřebujete klonovat snímek z jedné prezentace a použít jej v jiné souboru prezentace na konkrétní pozici:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) obsahující zdrojovou prezentaci, ze které bude snímek klonován.
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) obsahující prezentaci, do které bude snímek přidán.
1. Instanciujte třídu [SlideCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation#getSlides--) odkazem na kolekci Slides, kterou vystavuje objekt Presentation cílové prezentace.
1. Zavolejte metodu [insertClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) vystavenou objektem [SlideCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation#getSlides--) a jako parametry předložte snímek ze zdrojové prezentace spolu s požadovanou pozicí.
1. Zapište upravený soubor cílové prezentace.

V níže uvedeném příkladu jsme klonovali snímek (z nultého indexu zdrojové prezentace) na index 1 (pozice 2) v cílové prezentaci.

```javascript
// Vytvořte instanci třídy Presentation pro načtení souboru zdrojové prezentace
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Vytvořte instanci třídy Presentation pro cílový PPTX (kam bude snímek klonován)
    var destPres = new aspose.slides.Presentation();
    try {
        // Zkopírujte požadovaný snímek ze zdrojové prezentace na konec kolekce snímků v cílové prezentaci
        var slds = destPres.getSlides();
        slds.insertClone(2, srcPres.getSlides().get_Item(0));
        // Zapíše cílovou prezentaci na disk
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klonovat na konkrétní pozici v jiné prezentaci**
Pokud potřebujete klonovat snímek s hlavním snímkem (master slide) z jedné prezentace a použít jej v jiné prezentaci, je nejprve nutné klonovat požadovaný hlavní snímek ze zdrojové prezentace do cílové prezentace. Poté musíte použít tento hlavní snímek při klonování snímku s hlavním snímkem. Metoda [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) očekává hlavní snímek z cílové prezentace, nikoli ze zdrojové. Pro klonování snímku s hlavním snímkem postupujte podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) obsahující zdrojovou prezentaci, ze které bude snímek klonován.
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) obsahující cílovou prezentaci, do které bude snímek klonován.
1. Získejte přístup k snímku, který má být klonován, spolu s hlavním snímkem.
1. Instanciujte třídu [MasterSlideCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/MasterSlideCollection) odkazem na kolekci Masters, kterou vystavuje objekt [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) cílové prezentace.
1. Zavolejte metodu [addClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) vystavenou objektem [MasterSlideCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/MasterSlideCollection) a jako parametr předložte hlavní snímek ze zdrojového PPTX, který má být klonován.
1. Instanciujte třídu [SlideCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation#getSlides--) nastavením odkazu na kolekci Slides, kterou vystavuje objekt [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) cílové prezentace.
1. Zavolejte metodu [addClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides ISlide-) vystavenou objektem [SlideCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation#getSlides--) a jako parametry předložte snímek ze zdrojové prezentace, který má být klonován, a hlavní snímek.
1. Zapište upravený soubor cílové prezentace.

V níže uvedeném příkladu jsme klonovali snímek s hlavním snímkem (nacházející se na nultém indexu zdrojové prezentace) na konec cílové prezentace pomocí hlavního snímku ze zdrojového snímku.

```javascript
// Vytvořte instanci třídy Presentation pro načtení souboru zdrojové prezentace
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Vytvořte instanci třídy Presentation pro cílovou prezentaci (kam bude snímek klonován)
    var destPres = new aspose.slides.Presentation();
    try {
        // Vytvořte ISlide ze sbírky snímků ve zdrojové prezentaci spolu s
        // hlavním snímkem
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Zkopírujte požadovaný hlavní snímek ze zdrojové prezentace do kolekce hlavních snímků v
        // cílové prezentaci
        var masters = destPres.getMasters();
        var DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Zkopírujte požadovaný hlavní snímek ze zdrojové prezentace do kolekce hlavních snímků v
        // cílové prezentaci
        var iSlide = masters.addClone(SourceMaster);
        // Zkopírujte požadovaný snímek ze zdrojové prezentace s požadovaným hlavním snímkem na konec
        // kolekce snímků v cílové prezentaci
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);
        // Uložte cílovou prezentaci na disk
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klonovat na konci ve specifikované sekci**
Pokud chcete klonovat snímek a poté jej použít ve stejném souboru prezentace, ale v jiné sekci, použijte metodu [**addClone**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) vystavenou třídou [**SlideCollection**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideCollection). Aspose.Slides for Node.js via Java umožňuje klonovat snímek z první sekce a následně vložit tento klonovaný snímek do druhé sekce stejné prezentace.

Níže uvedený úryvek kódu ukazuje, jak klonovat snímek a vložit klonovaný snímek do specifikované sekce.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // Uložit cílovou prezentaci na disk
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Často kladené otázky**

**Klonují se poznámky řečníka a komentáře recenzentů?**

Ano. Stránka s poznámkami a recenzní komentáře jsou zahrnuty do klonu. Pokud je nechcete, [odstraňte je](/slides/cs/nodejs-java/presentation-notes/) po vložení.

**Jak jsou zacházeno s grafy a jejich zdroji dat?**

Objekt grafu, jeho formátování a vložená data jsou zkopírována. Pokud byl graf propojen s externím zdrojem (např. se sešitem vloženým jako OLE), tato vazba je zachována jako [OLE objekt](/slides/cs/nodejs-java/manage-ole/). Po přesunu mezi soubory ověřte dostupnost dat a chování aktualizace.

**Mohu řídit pozici vložení a sekce pro klon?**

Ano. Klon můžete vložit na konkrétní index snímku a umístit jej do zvolené [sekce](/slides/cs/nodejs-java/slide-section/). Pokud cílová sekce neexistuje, nejprve ji vytvořte a poté do ní snímek přesunte.