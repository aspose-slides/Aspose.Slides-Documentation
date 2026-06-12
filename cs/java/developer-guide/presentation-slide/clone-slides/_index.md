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
description: "Rychle duplikujte snímky PowerPoint pomocí Aspose.Slides pro Java. Postupujte podle našich přehledných příkladů kódu a automatizujte tvorbu PPT během několika sekund a odstraňte ruční práci."
---
## **Úvod**

Klónování je proces vytvoření přesné kopie nebo repliky něčeho. Aspose.Slides for Java také umožňuje vytvořit kopii nebo klon libovolného snímku a poté vložit tento klonovaný snímek do aktuální nebo jiné otevřené prezentace. Proces klonování snímku vytvoří nový snímek, který lze upravovat vývojáři, aniž by se změnil původní snímek. Existuje několik možných způsobů, jak klonovat snímek:

- Klonovat na konci v rámci prezentace.
- Klonovat na jiném místě v rámci prezentace.
- Klonovat na konci v jiné prezentaci.
- Klonovat na jiném místě v jiné prezentaci.
- Klonovat na konkrétním místě v jiné prezentaci.

V Aspose.Slides for Java poskytuje (sbírka objektů [ISlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlide) ) vystavená objektem [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) metody [addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) a [insertClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) , které umožňují provádět výše uvedené typy klonování snímků

## **Klonovat snímek na konci prezentace**
Pokud chcete klonovat snímek a poté jej použít ve stejném souboru prezentace na konci existujících snímků, použijte metodu [addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
2. Instancujte třídu [ISlideCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#getSlides--) odkazováním na kolekci Slides vystavenou objektem [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
3. Zavolejte metodu [addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) vystavenou objektem [ISlideCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#getSlides--) a jako parametr předávejte snímek, který má být klonován, metodě [addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
4. Zapište upravený soubor prezentace.

V níže uvedeném příkladu jsme klonovali snímek (nacházející se na první pozici – nulový index – prezentace) na konec prezentace.

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Zkopírujte požadovaný snímek na konec kolekce snímků ve stejné prezentaci
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Uložte upravenou prezentaci na disk
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klonovat snímek na jiné místo v rámci prezentace**
Pokud chcete klonovat snímek a poté jej použít ve stejném souboru prezentace, ale na jiném místě, použijte metodu [insertClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
2. Instancujte třídu odkazováním na kolekci **Slides** vystavenou objektem [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
3. Zavolejte metodu [insertClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) vystavenou objektem [ISlideCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#getSlides--) a jako parametr předávejte snímek, který má být klonován, spolu s indexem pro novou pozici metodě [insertClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
4. Zapište upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme klonovali snímek (nacházející se na nulovém indexu – pozice 1 – prezentace) na index 1 – pozice 2 – prezentace.

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Zkopírujte požadovaný snímek na konec kolekce snímků ve stejné prezentaci
    ISlideCollection slds = pres.getSlides();

    // Zkopírujte požadovaný snímek na zadaný index ve stejné prezentaci
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Uložte upravenou prezentaci na disk
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klonovat snímek na konci jiné prezentace**
Pokud potřebujete klonovat snímek z jedné prezentace a použít jej v jiné souboru prezentace, na konci existujících snímků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation), která obsahuje prezentaci, ze které bude snímek klonován.
2. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation), která obsahuje cílovou prezentaci, do které bude snímek přidán.
3. Instancujte třídu [ISlideCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlideCollection) odkazováním na kolekci **Slides** vystavenou objektem Presentation cílové prezentace.
4. Zavolejte metodu [addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) vystavenou objektem [ISlideCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#getSlides--) a jako parametr předávejte snímek ze zdrojové prezentace metodě [addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
5. Zapište upravený soubor cílové prezentace.

V níže uvedeném příkladu jsme klonovali snímek (z prvního indexu zdrojové prezentace) na konec cílové prezentace.

```java
// Vytvořte instanci třídy Presentation pro načtení zdrojového souboru prezentace
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Vytvořte instanci třídy Presentation pro cílový PPTX (kam bude snímek klonován)
    Presentation destPres = new Presentation();
    try {
        // Zkopírujte požadovaný snímek ze zdrojové prezentace na konec kolekce snímků v cílové prezentaci
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

## **Klonovat snímek na jiné místo v jiné prezentaci**
Pokud potřebujete klonovat snímek z jedné prezentace a použít jej v jiné souboru prezentace, na konkrétním místě:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation), která obsahuje zdrojovou prezentaci, ze které bude snímek klonován.
2. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation), která obsahuje prezentaci, do které bude snímek přidán.
3. Instancujte třídu [ISlideCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#getSlides--) odkazováním na kolekci Slides vystavenou objektem Presentation cílové prezentace.
4. Zavolejte metodu [insertClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) vystavenou objektem [ISlideCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#getSlides--) a jako parametr předávejte snímek ze zdrojové prezentace spolu s požadovanou pozicí metodě [insertClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
5. Zapište upravený soubor cílové prezentace.

V níže uvedeném příkladu jsme klonovali snímek (z nulového indexu zdrojové prezentace) na index 1 (pozice 2) cílové prezentace.

```java
// Vytvořte instanci třídy Presentation pro načtení zdrojového souboru prezentace
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Vytvořte instanci třídy Presentation pro cílový PPTX (kam bude snímek klonován)
    Presentation destPres = new Presentation();
    try {
        // Zkopírujte požadovaný snímek ze zdrojové prezentace na konec kolekce snímků v cílové prezentaci
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // Uložte cílovou prezentaci na disk
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klonovat snímek na konkrétním místě v jiné prezentaci**
Pokud potřebujete klonovat snímek spolu s hlavním snímkem (master slide) z jedné prezentace a použít jej v jiné prezentaci, musíte nejprve klonovat požadovaný hlavní snímek ze zdrojové prezentace do cílové prezentace. Pak tento hlavní snímek použijete pro klonování snímku s hlavním snímkem. Metoda [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) očekává hlavní snímek z cílové prezentace, nikoli ze zdrojové. Pro klonování snímku s hlavním snímkem postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation), která obsahuje zdrojovou prezentaci, ze které bude snímek klonován.
2. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation), která obsahuje cílovou prezentaci, do které bude snímek klonován.
3. Získejte přístup k snímku, který má být klonován, spolu s hlavním snímkem.
4. Instancujte třídu [IMasterSlideCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IMasterSlideCollection) odkazováním na kolekci Masters vystavenou objektem [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) cílové prezentace.
5. Zavolejte metodu [addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) vystavenou objektem [IMasterSlideCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IMasterSlideCollection) a jako parametr předávejte hlavní snímek ze zdrojového PPTX, který má být klonován, metodě [addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
6. Instancujte třídu [ISlideCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#getSlides--) nastavením odkazu na kolekci Slides vystavenou objektem [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) cílové prezentace.
7. Zavolejte metodu [addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) vystavenou objektem [ISlideCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#getSlides--) a jako parametr předávejte snímek ze zdrojové prezentace, který má být klonován, a hlavní snímek metodě [addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
8. Zapište upravený soubor cílové prezentace.

V níže uvedeném příkladu jsme klonovali snímek s hlavním snímkem (nacházející se na nulovém indexu zdrojové prezentace) na konec cílové prezentace pomocí hlavního snímku ze zdrojového snímku.

```java
// Vytvořte instanci třídy Presentation pro načtení zdrojového souboru prezentace
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Vytvořte instanci třídy Presentation pro cílovou prezentaci (kam bude snímek klonován)
    Presentation destPres = new Presentation();
    try {
        // Vytvořte ISlide ze sbírky snímků ve zdrojové prezentaci spolu s
        // hlavním snímkem
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Zkopírujte požadovaný hlavní snímek ze zdrojové prezentace do sbírky hlavních snímků v
        // cílové prezentaci
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Zkopírujte požadovaný hlavní snímek ze zdrojové prezentace do sbírky hlavních snímků v
        // cílové prezentaci
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Zkopírujte požadovaný snímek ze zdrojové prezentace s požadovaným hlavním snímkem na konec
        // sbírky snímků v cílové prezentaci
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
Pokud chcete klonovat snímek a poté jej použít ve stejném souboru prezentace, ale v jiné sekci, použijte metodu [addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) vystavenou rozhraním [ISlideCollection]. Aspose.Slides pro Java umožňuje klonovat snímek z první sekce a poté vložit tento klonovaný snímek do druhé sekce stejné prezentace.

Následující úryvek kódu ukazuje, jak klonovat snímek a vložit klonovaný snímek do určité sekce.

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

**Klonují se poznámky k řečníkovi a komentáře recenzentů?**

Ano. Stránka s poznámkami a recenzní komentáře jsou zahrnuty do klonu. Pokud je nechcete, [odstraňte je](/slides/cs/java/presentation-notes/) po vložení.

**Jak jsou zpracovány grafy a jejich datové zdroje?**

Objekt grafu, jeho formátování a vložená data jsou zkopírována. Pokud byl graf propojen s externím zdrojem (např. se sešitem vloženým jako OLE), toto propojení je zachováno jako [OLE objekt](/slides/cs/java/manage-ole/). Po přesunu mezi soubory ověřte dostupnost dat a chování aktualizace.

**Mohu řídit pozici vložení a sekce pro klon?**

Ano. Klon můžete vložit na konkrétní index snímku a umístit jej do vybrané [sekce](/slides/cs/java/slide-section/). Pokud cílová sekce neexistuje, nejprve ji vytvořte a poté do ní snímek přesuňte.