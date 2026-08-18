---
title: Klonování snímků prezentace v Javě
linktitle: Klonovat snímky
type: docs
weight: 35
url: /cs/java/clone-slides/
keywords:
- klonovat snímek
- kopírovat snímek
- uložit snímek
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Rychle duplikujte snímky PowerPoint pomocí Aspose.Slides for Java. Postupujte podle našich přehledných příkladů kódu a automatizujte tvorbu PPT během několika sekund a odstraňte ruční práci."
---
## **Úvod**

Klonování je proces vytvoření přesné kopie nebo repliky něčeho. Aspose.Slides for Java také umožňuje vytvořit kopii nebo klon libovolného snímku a poté vložit tento klonovaný snímek do aktuální nebo jiné otevřené prezentace. Proces klonování snímku vytvoří nový snímek, který může vývojář upravit, aniž by změnil původní snímek. Existuje několik možných způsobů, jak snímek klonovat:

- Klonovat na konci v rámci jedné prezentace.
- Klonovat na jiné pozici v rámci jedné prezentace.
- Klonovat na konci v jiné prezentaci.
- Klonovat na jiné pozici v jiné prezentaci.
- Klonovat společně s hlavním snímkem do jiné prezentace.

V Aspose.Slides for Java, (kolekce objektů [ISlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlide) ) exposeovaná objektem [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) poskytuje metody [addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) a [insertClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) pro provedení výše uvedených typů klonování snímků

## **Klonování snímku na konci prezentace**
Pokud chcete klonovat snímek a poté jej použít ve stejném souboru prezentace na konci existujících snímků, použijte metodu [addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
1. Vytvořte instanci [ISlideCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#getSlides--) odkazováním na kolekci Slides, kterou exposeuje objekt [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
1. Zavolejte metodu [addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) exposeovanou objektem [ISlideCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#getSlides--) a jako parametr předáte snímek, který má být klonován.
1. Uložte upravený soubor prezentace.

V níže uvedeném příkladu jsme klonovali snímek (nacházející se na první pozici – index 0 – v prezentaci) na konec prezentace.

```java
import com.aspose.slides.*;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Klonujte požadovaný snímek na konec kolekce snímků ve stejné prezentaci
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Uložte upravenou prezentaci na disk
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klonování snímku na jiné pozici v prezentaci**
Pokud chcete klonovat snímek a poté jej použít ve stejném souboru prezentace, ale na jiné pozici, použijte metodu [insertClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
1. Vytvořte instanci odkazováním na kolekci [**Slides**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#getSlides--) exposeovanou objektem [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
1. Zavolejte metodu [insertClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) exposeovanou objektem [ISlideCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#getSlides--) a jako parametry předáte snímek, který má být klonován, a index pro novou pozici.
1. Uložte upravený soubor prezentace jako PPTX.

V níže uvedeném příkladu jsme klonovali snímek (nacházející se na indexu 1 – pozice 2 – v prezentaci) na index 2 – pozice 3 – v prezentaci.

```java
import com.aspose.slides.*;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Získejte kolekci snímků v prezentaci
    ISlideCollection slds = pres.getSlides();

    // Klonujte požadovaný snímek na zadaný index ve stejné prezentaci
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Uložte upravenou prezentaci na disk
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klonování snímku na konci jiné prezentace**
Pokud potřebujete klonovat snímek z jedné prezentace a použít jej v jiné souboru prezentace, na konci existujících snímků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) obsahující prezentaci, ze které bude snímek klonován.
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) obsahující cílovou prezentaci, do které bude snímek přidán.
1. Vytvořte instanci [ISlideCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlideCollection) odkazováním na kolekci [**Slides**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#getSlides--) exposeovanou objektem Presentation cílové prezentace.
1. Zavolejte metodu [addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) exposeovanou objektem [ISlideCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#getSlides--) a jako parametr předáte snímek ze zdrojové prezentace.
1. Uložte upravený soubor cílové prezentace.

V níže uvedeném příkladu jsme klonovali snímek (z první pozice zdrojové prezentace) na konec cílové prezentace.

```java
import com.aspose.slides.*;

// Vytvořte instanci třídy Presentation pro načtení souboru zdrojové prezentace
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Vytvořte instanci třídy Presentation pro cílový PPTX (kde bude snímek klonován)
    Presentation destPres = new Presentation();
    try {
        // Klonujte požadovaný snímek ze zdrojové prezentace na konec kolekce snímků v cílové prezentaci
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Uložte cílovou prezentaci na disk
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klonování snímku na jinou pozici v jiné prezentaci**
Pokud potřebujete klonovat snímek z jedné prezentace a použít jej v jiné souboru prezentace, na konkrétní pozici:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) obsahující zdrojovou prezentaci, ze které bude snímek klonován.
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) obsahující prezentaci, do které bude snímek přidán.
1. Vytvořte instanci [ISlideCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#getSlides--) odkazováním na kolekci Slides exposeovanou objektem Presentation cílové prezentace.
1. Zavolejte metodu [insertClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) exposeovanou objektem [ISlideCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#getSlides--) a jako parametry předáte snímek ze zdrojové prezentace a požadovanou pozici.
1. Uložte upravený soubor cílové prezentace.

V níže uvedeném příkladu jsme klonovali snímek (z nulového indexu zdrojové prezentace) na index 1 (pozice 2) cílové prezentace.

```java
import com.aspose.slides.*;

// Vytvořte instanci třídy Presentation pro načtení souboru zdrojové prezentace
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Vytvořte instanci třídy Presentation pro cílový PPTX (kde bude snímek klonován)
    Presentation destPres = new Presentation();
    try {
        // Klonujte požadovaný snímek ze zdrojové prezentace na zadaný index v cílové prezentaci
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(1, srcPres.getSlides().get_Item(0));

        // Uložte cílovou prezentaci na disk
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klonování snímku s jeho hlavním snímkem do jiné prezentace**
Pokud potřebujete klonovat snímek spolu s hlavním snímkem z jedné prezentace a použít jej v jiné prezentaci, nejprve musíte klonovat požadovaný hlavní snímek ze zdrojové prezentace do cílové prezentace. Poté použijete tento hlavní snímek pro klonování snímku s hlavním snímkem. Metoda [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) očekává hlavní snímek z cílové prezentace, nikoli ze zdrojové. Pro klonování snímku s hlavním snímkem postupujte následovně:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) obsahující zdrojovou prezentaci, ze které bude snímek klonován.
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) obsahující cílovou prezentaci, do které bude snímek klonován.
1. Získejte snímek, který má být klonován, spolu s jeho hlavním snímkem.
1. Vytvořte instanci [IMasterSlideCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IMasterSlideCollection) odkazováním na kolekci Masters exposeovanou objektem [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) cílové prezentace.
1. Zavolejte metodu [addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) exposeovanou objektem [IMasterSlideCollection] a jako parametr předáte hlavní snímek ze zdrojové PPTX, který má být klonován.
1. Vytvořte instanci [ISlideCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#getSlides--) nastavením odkazu na kolekci Slides exposeovanou objektem [Presentation] cílové prezentace.
1. Zavolejte metodu [addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) exposeovanou objektem [ISlideCollection] a jako parametry předáte snímek ze zdrojové prezentace, který má být klonován, a hlavní snímek.
1. Uložte upravený soubor cílové prezentace.

V níže uvedeném příkladu jsme klonovali snímek s hlavním snímkem (nacházející se na nulovém indexu zdrojové prezentace) na konec cílové prezentace pomocí hlavního snímku ze zdrojového snímku.

```java
import com.aspose.slides.*;

// Vytvořte instanci třídy Presentation pro načtení souboru zdrojové prezentace
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Vytvořte instanci třídy Presentation pro cílovou prezentaci (kde bude snímek klonován)
    Presentation destPres = new Presentation();
    try {
        // Vytvořte instanci ISlide ze sbírky snímků ve zdrojové prezentaci spolu s
        // Hlavním snímkem
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Klonujte požadovaný hlavní snímek ze zdrojové prezentace do sbírky hlavních snímků v
        // cílové prezentaci
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = masters.addClone(SourceMaster);

        // Klonujte požadovaný snímek ze zdrojové prezentace s požadovaným hlavním snímkem na konec
        // sbírky snímků v cílové prezentaci
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);

        // Uložte cílovou prezentaci na disk
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klonování snímku na konci určené sekce**
Pokud chcete klonovat snímek a poté jej použít ve stejném souboru prezentace, ale v jiné sekci, použijte metodu [**addClone**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) exposeovanou rozhraním [**ISlideCollection**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlideCollection). Aspose.Slides for Java umožňuje klonovat snímek z první sekce a poté vložit tento klonovaný snímek do druhé sekce téže prezentace.

Následující úryvek kódu ukazuje, jak klonovat snímek a vložit klonovaný snímek do určené sekce.

```java
import com.aspose.slides.*;

IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);

    // Uložte cílovou prezentaci na disk
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Zajistěte shodnou velikost snímku**

Při klonování snímků do jiné prezentace se ujistěte, že cílová prezentace má stejnou velikost snímku jako zdrojová. Pokud se velikosti liší, Aspose.Slides automaticky nepřevzorkuje klonované tvary – jejich původní souřadnice a rozměry zůstávají zachovány, což může způsobit, že obsah bude nesprávně zarovnán nebo přesahovat okraje snímku.

Před klonováním hlavního snímku a snímku můžete nastavit velikost snímku cílové prezentace tak, aby odpovídala zdrojové:

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

Udělejte to před klonováním hlavního snímku a snímku.

## **Často kladené otázky**

**Kopírují se poznámky přednášejícího a komentáře recenzentů?**

Ano. Stránka s poznámkami a recenzní komentáře jsou zahrnuty do klonu. Pokud je nechcete, [odstraňte je](/slides/cs/java/presentation-notes/) po vložení.

**Jak jsou zpracovány grafy a jejich datové zdroje?**

Objekt grafu, jeho formátování a vložená data jsou zkopírována. Pokud byl graf propojen s externím zdrojem (např. se sešitem vloženým jako OLE), toto propojení je zachováno jako [OLE object](/slides/cs/java/manage-ole/). Po přesunu mezi soubory ověřte dostupnost dat a chování aktualizace.

**Mohu řídit pozici vložení a sekce pro klon?**

Ano. Klon můžete vložit na konkrétní index snímku a umístit jej do vybrané [section](/slides/cs/java/slide-section/). Pokud cílová sekce neexistuje, nejprve ji vytvořte a poté do ní snímek přesuňte.