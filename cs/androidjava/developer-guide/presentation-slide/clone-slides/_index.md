---
title: Klonování snímků prezentace na Androidu
linktitle: Klonovat snímky
type: docs
weight: 35
url: /cs/androidjava/clone-slides/
keywords:
- klonovat snímek
- kopírovat snímek
- uložit snímek
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Duplicitujte snímky PowerPoint pomocí Aspose.Slides pro Android. Postupujte podle našich přehledných příkladů kódu v Javě a automatizujte tvorbu PPT během několika sekund a odstraňte ruční práci."
---
## **Úvod**

Klónování je proces vytvoření přesné kopie nebo repliky něčeho. Aspose.Slides pro Android prostřednictvím Java také umožňuje vytvořit kopii nebo klon libovolného snímku a poté tento klonovaný snímek vložit do aktuální nebo jiné otevřené prezentace. Proces klonování snímku vytvoří nový snímek, který mohou vývojáři upravovat, aniž by změnili původní snímek. Existuje několik možných způsobů, jak klonovat snímek:

- Klonovat na konci v rámci prezentace.
- Klonovat na jiném místě v rámci prezentace.
- Klonovat na konci v jiné prezentaci.
- Klonovat na jiném místě v jiné prezentaci.
- Klonovat na konkrétním místě v jiné prezentaci.

V Aspose.Slides pro Android prostřednictvím Java (kolekce objektů [ISlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlide)) vystavená objektem [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) poskytuje metody [addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) a [insertClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) k provedení výše uvedených typů klonování snímků.

## **Klonovat snímek na konci prezentace**
Pokud chcete klonovat snímek a poté jej použít ve stejném souboru prezentace na konci existujících snímků, použijte metodu [addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
1. Vytvořte instanci [ISlideCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#getSlides--) odkazem na kolekci Slides vystavenou objektem [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
1. Zavolejte metodu [addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) vystavenou objektem [ISlideCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#getSlides--) a předávejte snímek, který má být klonován, jako parametr metodě [addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Zapište upravený soubor prezentace.

V ukázce níže jsme klonovali snímek (nacházející se na první pozici – index nula – v prezentaci) na konec prezentace.

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Klonujte požadovaný snímek na konec kolekce snímků ve stejné prezentaci
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Zapište upravenou prezentaci na disk
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klonovat snímek na jiné místo v rámci prezentace**
Pokud chcete klonovat snímek a poté jej použít ve stejném souboru prezentace, ale na jiném místě, použijte metodu [insertClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
1. Vytvořte instanci odkazem na kolekci [**Slides**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#getSlides--) vystavenou objektem [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
1. Zavolejte metodu [insertClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) vystavenou objektem [ISlideCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#getSlides--) a předávejte snímek, který má být klonován, spolu s indexem nové pozice jako parametr metodě [insertClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Zapište upravenou prezentaci jako soubor PPTX.

V ukázce níže jsme klonovali snímek (nacházející se na indexu nula – pozice 1 – v prezentaci) na index 1 – pozice 2 – v prezentaci.

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Klonujte požadovaný snímek na konec kolekce snímků ve stejné prezentaci
    ISlideCollection slds = pres.getSlides();

    // Klonujte požadovaný snímek na zadaný index ve stejné prezentaci
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Zapište upravenou prezentaci na disk
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klonovat snímek na konci jiné prezentace**
Pokud potřebujete klonovat snímek z jedné prezentace a použít jej v jiné prezentaci, na konci existujících snímků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) obsahující prezentaci, ze které bude snímek klonován.
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) obsahující cílovou prezentaci, do které bude snímek přidán.
1. Vytvořte instanci [ISlideCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection) odkazem na kolekci [**Slides**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#getSlides--) vystavenou objektem Presentation cílové prezentace.
1. Zavolejte metodu [addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) vystavenou objektem [ISlideCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#getSlides--) a předávejte snímek ze zdrojové prezentace jako parametr metodě [addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Zapište upravený cílový soubor prezentace.

V ukázce níže jsme klonovali snímek (z první pozice zdrojové prezentace) na konec cílové prezentace.

```java
// Vytvořte instanci třídy Presentation pro načtení zdrojového souboru prezentace
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Vytvořte instanci třídy Presentation pro cílový PPTX (kam bude snímek klonován)
    Presentation destPres = new Presentation();
    try {
        // Klonujte požadovaný snímek ze zdrojové prezentace na konec kolekce snímků v cílové prezentaci
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Napište cílovou prezentaci na disk
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klonovat snímek na jiné místo v jiné prezentaci**
Pokud potřebujete klonovat snímek z jedné prezentace a použít jej v jiné prezentaci, na konkrétním místě:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) obsahující zdrojovou prezentaci, ze které bude snímek klonován.
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) obsahující prezentaci, do které bude snímek přidán.
1. Vytvořte instanci [ISlideCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#getSlides--) odkazem na kolekci Slides vystavenou objektem Presentation cílové prezentace.
1. Zavolejte metodu [insertClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) vystavenou objektem [ISlideCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#getSlides--) a předávejte snímek ze zdrojové prezentace spolu s požadovanou pozicí jako parametr metodě [insertClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Zapište upravený cílový soubor prezentace.

V ukázce níže jsme klonovali snímek (z indexu nula zdrojové prezentace) na index 1 (pozice 2) cílové prezentace.

```java
// Vytvořte instanci třídy Presentation pro načtení zdrojového souboru prezentace
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Vytvořte instanci třídy Presentation pro cílový PPTX (kam bude snímek klonován)
    Presentation destPres = new Presentation();
    try {
        // Klonujte požadovaný snímek ze zdrojové prezentace na konec kolekce snímků v cílové prezentaci
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // Zapište cílovou prezentaci na disk
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klonovat snímek na konkrétním místě v jiné prezentaci**
Pokud potřebujete klonovat snímek s hlavním snímkem (master slide) z jedné prezentace a použít jej v jiné prezentaci, nejprve musíte klonovat požadovaný hlavní snímek ze zdrojové prezentace do cílové prezentace. Pak tento hlavní snímek použijete pro klonování snímku s hlavním snímkem. Metoda [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) očekává hlavní snímek z cílové prezentace, nikoli ze zdrojové. Pro klonování snímku s hlavním snímkem postupujte podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) obsahující zdrojovou prezentaci, ze které bude snímek klonován.
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) obsahující cílovou prezentaci, do které bude snímek klonován.
1. Získejte přístup ke snímku, který má být klonován, spolu s jeho hlavním snímkem.
1. Vytvořte instanci [IMasterSlideCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IMasterSlideCollection) odkazem na kolekci Masters vystavenou objektem [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) cílové prezentace.
1. Zavolejte metodu [addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) vystavenou objektem [IMasterSlideCollection] a předávejte hlavní snímek ze zdrojového PPTX jako parametr metodě [addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Vytvořte instanci [ISlideCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#getSlides--) nastavením reference na kolekci Slides vystavenou objektem [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) cílové prezentace.
1. Zavolejte metodu [addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) vystavenou objektem [ISlideCollection] a předávejte snímek ze zdrojové prezentace a hlavní snímek jako parametry metodě [addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Zapište upravený cílový soubor prezentace.

V ukázce níže jsme klonovali snímek s hlavním snímkem (nacházející se na indexu nula zdrojové prezentace) na konec cílové prezentace pomocí hlavního snímku ze zdrojového snímku.

```java
// Vytvořte instanci třídy Presentation pro načtení zdrojového souboru prezentace
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Vytvořte instanci třídy Presentation pro cílovou prezentaci (kam bude snímek klonován)
    Presentation destPres = new Presentation();
    try {
        // Vytvořte ISlide z kolekce snímků ve zdrojové prezentaci spolu s
        // hlavním snímkem
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Klonujte požadovaný hlavní snímek ze zdrojové prezentace do kolekce hlavních snímků v
        // cílové prezentaci
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Klonujte požadovaný hlavní snímek ze zdrojové prezentace do kolekce hlavních snímků v
        // cílové prezentaci
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Klonujte požadovaný snímek ze zdrojové prezentace s požadovaným hlavním snímkem na konec
        // kolekce snímků v cílové prezentaci
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // Uložte cílovou prezentaci na disk
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klonovat snímek na konci určené sekce**
Pokud chcete klonovat snímek a poté jej použít ve stejné prezentaci, ale v jiné sekci, použijte metodu [**addClone**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) vystavenou rozhraním [**ISlideCollection**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection). Aspose.Slides pro Android prostřednictvím Java umožňuje klonovat snímek z první sekce a poté vložit tento klonovaný snímek do druhé sekce téže prezentace.

Následující úryvek kódu ukazuje, jak klonovat snímek a vložit klonovaný snímek do určené sekce.

```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
    // Uložte cílovou prezentaci na disk
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Často kladené otázky**

**Klonují se poznámky k přednášejícímu a komentáře recenzentů?**

Ano. Stránka s poznámkami a recenzní komentáře jsou součástí klonu. Pokud je nechcete, [odstraňte je](/slides/cs/androidjava/presentation-notes/) po vložení.

**Jak jsou zpracovány grafy a jejich datové zdroje?**

Objekt grafu, formátování a vložená data jsou zkopírována. Pokud byl graf propojen s externím zdrojem (např. sešitem vloženým jako OLE), toto propojení zůstane zachováno jako [OLE objekt](/slides/cs/androidjava/manage-ole/). Po přesunu mezi soubory ověřte dostupnost dat a chování aktualizace.

**Mohu řídit pozici vložení a sekce pro klon?**

Ano. Klon můžete vložit na konkrétní index snímku a umístit jej do vybrané [sekce](/slides/cs/androidjava/slide-section/). Pokud cílová sekce neexistuje, nejprve ji vytvořte a pak do ní snímek přesuňte.