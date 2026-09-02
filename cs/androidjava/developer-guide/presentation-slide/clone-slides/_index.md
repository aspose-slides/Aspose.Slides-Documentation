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
description: "Duplicitní snímky PowerPointu s Aspose.Slides pro Android. Postupujte podle našich srozumitelných příkladů kódu v Javě a automatizujte vytvoření PPT během vteřin a eliminujte ruční práci."
---
## **Úvod**

Klonování je proces vytvoření přesné kopie nebo repliky něčeho. Aspose.Slides pro Android prostřednictvím Java také umožňuje vytvořit kopii nebo klon libovolného snímku a následně vložit tento klonovaný snímek do aktuální nebo jiné otevřené prezentace. Proces klonování snímku vytvoří nový snímek, který lze upravovat vývojáři, aniž by se měnil původní snímek. Existuje několik možných způsobů, jak klonovat snímek:

- Klonovat na konci v rámci prezentace.
- Klonovat na jiné pozici v rámci prezentace.
- Klonovat na konci v jiné prezentaci.
- Klonovat na jiné pozici v jiné prezentaci.
- Klonovat na konkrétní pozici v jiné prezentaci.

V Aspose.Slides pro Android prostřednictvím Java (kolekce objektů [ISlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlide)) vystavená objektem [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) poskytuje metody [addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) a [insertClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) pro provedení výše uvedených typů klonování snímků

## **Klonovat snímek na konci prezentace**
Pokud chcete klonovat snímek a poté jej použít ve stejném souboru prezentace na konci existujících snímků, použijte metodu [addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
2. Načtěte kolekci [ISlideCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#getSlides--) odkazem na kolekci Slides, kterou vystavuje objekt [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
3. Zavolejte metodu [addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) vystavenou objektem [ISlideCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#getSlides--) a jako parametr předáte snímek, který má být klonován.
4. Zapište upravený soubor prezentace.

V ukázce níže jsme naklonovali snímek (nacházející se na první pozici – index nula – v prezentaci) na konec prezentace.

```java
import com.aspose.slides.*;

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

## **Klonovat snímek na jinou pozici v rámci prezentace**
Pokud chcete klonovat snímek a poté jej použít ve stejném souboru prezentace, ale na jiné pozici, použijte metodu [insertClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
2. Načtěte třídu odkazem na kolekci [**Slides**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#getSlides--) vystavenou objektem [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
3. Zavolejte metodu [insertClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) vystavenou objektem [ISlideCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#getSlides--) a jako parametry předáte snímek, který má být klonován, a index nové pozice.
4. Zapište upravenou prezentaci ve formátu PPTX.

V ukázce níže jsme naklonovali snímek (nacházející se na indexu 1 – pozice 2 – v prezentaci) na index 2 – pozici 3 – v prezentaci.

```java
import com.aspose.slides.*;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Získejte kolekci snímků ve stejné prezentaci
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
Pokud potřebujete klonovat snímek z jedné prezentace a použít jej v jiné prezentaci na konci existujících snímků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) obsahující prezentaci, ze které bude snímek klonován.
2. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) obsahující cílovou prezentaci, do které bude snímek přidán.
3. Načtěte kolekci [ISlideCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection) odkazem na kolekci [**Slides**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#getSlides--) vystavenou objektem Presentation cílové prezentace.
4. Zavolejte metodu [addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) vystavenou objektem [ISlideCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#getSlides--) a jako parametr předáte snímek ze zdrojové prezentace.
5. Zapište upravený soubor cílové prezentace.

V ukázce níže jsme naklonovali snímek (z první pozice zdrojové prezentace) na konec cílové prezentace.

```java
import com.aspose.slides.*;

// Vytvořte instanci třídy Presentation pro načtení souboru zdrojové prezentace
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Vytvořte instanci třídy Presentation pro cílový PPTX (kam bude snímek klonován)
    Presentation destPres = new Presentation();
    try {
        // Klonujte požadovaný snímek ze zdrojové prezentace na konec kolekce snímků v cílové prezentaci
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Zapište cílovou prezentaci na disk
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klonovat snímek na jinou pozici v jiné prezentaci**
Pokud potřebujete klonovat snímek z jedné prezentace a použít jej v jiné prezentaci na konkrétní pozici:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) obsahující zdrojovou prezentaci, ze které bude snímek klonován.
2. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) obsahující prezentaci, do které bude snímek přidán.
3. Načtěte kolekci [ISlideCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#getSlides--) odkazem na kolekci Slides vystavenou objektem Presentation cílové prezentace.
4. Zavolejte metodu [insertClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISSlide-) vystavenou objektem [ISlideCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#getSlides--) a jako parametry předáte snímek ze zdrojové prezentace a požadovanou pozici.
5. Zapište upravený soubor cílové prezentace.

V ukázce níže jsme naklonovali snímek (z indexu nula zdrojové prezentace) na index 1 (pozice 2) cílové prezentace.

```java
import com.aspose.slides.*;

// Vytvořte instanci třídy Presentation pro načtení souboru zdrojové prezentace
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Vytvořte instanci třídy Presentation pro cílový PPTX (kam bude snímek klonován)
    Presentation destPres = new Presentation();
    try {
        // Klonujte požadovaný snímek ze zdrojové prezentace na zadaný index v cílové prezentaci
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(1, srcPres.getSlides().get_Item(0));

        // Zapište cílovou prezentaci na disk
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klonovat snímek na konkrétní pozici v jiné prezentaci**
Pokud potřebujete klonovat snímek s nadřízeným snímkem (master slide) z jedné prezentace a použít jej v jiné prezentaci, nejprve musíte naklonovat požadovaný master slide ze zdrojové prezentace do cílové. Poté použijete tento master slide pro klonování snímku s master slide. Metoda [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-com.aspose.slides.IMasterSlide-boolean-) očekává master slide z cílové prezentace, nikoli ze zdrojové. Pro klonování snímku s master slide postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) obsahující zdrojovou prezentaci, ze které bude snímek klonován.
2. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) obsahující cílovou prezentaci, do které bude snímek klonován.
3. Získejte snímek, který má být klonován, spolu s jeho master slide.
4. Načtěte kolekci [IMasterSlideCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IMasterSlideCollection) odkazem na kolekci Masters vystavenou objektem [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) cílové prezentace.
5. Zavolejte metodu [addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) vystavenou objektem [IMasterSlideCollection] a jako parametr předáte master slide ze zdrojové PPTX, který má být klonován.
6. Načtěte kolekci [ISlideCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#getSlides--) nastavením odkazu na kolekci Slides vystavenou objektem [Presentation] cílové prezentace.
7. Zavolejte metodu [addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) vystavenou objektem [ISlideCollection] a jako parametry předáte snímek ze zdrojové prezentace, který má být klonován, a master slide.
8. Zapište upravený soubor cílové prezentace.

V ukázce níže jsme naklonovali snímek s master slide (nacházející se na indexu nula zdrojové prezentace) na konec cílové prezentace pomocí master slide ze zdrojového snímku.

```java
import com.aspose.slides.*;

// Vytvořte instanci třídy Presentation pro načtení souboru zdrojové prezentace
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Vytvořte instanci třídy Presentation pro cílovou prezentaci (kam bude snímek klonován)
    Presentation destPres = new Presentation();
    try {
        // Vytvořte objekt ISlide ze sbírky snímků ve zdrojové prezentaci spolu s
        // hlavním snímkem
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Klonujte požadovaný hlavní snímek ze zdrojové prezentace do kolekce hlavních snímků v
        // cílové prezentaci
        IMasterSlideCollection masters = destPres.getMasters();
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
Pokud chcete klonovat snímek a poté jej použít ve stejné prezentaci, ale v jiné sekci, použijte metodu [**addClone**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-com.aspose.slides.ISection-) vystavenou rozhraním [**ISlideCollection**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection). Aspose.Slides pro Android prostřednictvím Java umožňuje klonovat snímek z první sekce a vložit tento klonovaný snímek do druhé sekce stejné prezentace.

Následující úryvek kódu vám ukáže, jak klonovat snímek a vložit jej do určené sekce.

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

## **Zajistit odpovídající velikost snímku**

Při klonování snímků do jiné prezentace se ujistěte, že cílová prezentace má stejnou velikost snímku jako zdrojová. Pokud se velikosti liší, Aspose.Slides automaticky nepřepočítává měřítko klonovaných objektů – jejich původní souřadnice a rozměry zůstávají zachovány, což může způsobit nesprávné zarovnání nebo překročení okrajů snímku.

Před klonováním master slide a snímku můžete nastavit velikost snímku cílové prezentace tak, aby odpovídala zdrojové:

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

Proveďte to před klonováním master slide a snímku.

## **Často kladené otázky**

**Klone se poznámky k představovateli a recenzní komentáře?**

Ano. Stránka s poznámkami a recenzní komentáře jsou součástí klonu. Pokud je nechcete, [odstraňte je](/slides/cs/androidjava/presentation-notes/) po vložení.

**Jak jsou zpracovány grafy a jejich datové zdroje?**

Objekt grafu, jeho formátování a vložená data jsou zkopírována. Pokud byl graf propojen s externím zdrojem (např. se souborem OLE), toto propojení zůstane zachováno jako [OLE objekt](/slides/cs/androidjava/manage-ole/). Po přesunu mezi soubory ověřte dostupnost dat a chování aktualizace.

**Mohu řídit pozici vložení a sekce klonu?**

Ano. Klon můžete vložit na konkrétní index snímku a umístit jej do zvolené [sekce](/slides/cs/androidjava/slide-section/). Pokud cílová sekce neexistuje, nejprve ji vytvořte a potom do ní snímek přesuňte.