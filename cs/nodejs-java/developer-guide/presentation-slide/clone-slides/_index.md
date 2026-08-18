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
description: "Rychle duplikujte PowerPoint snímky pomocí Aspose.Slides pro Node.js. Sledujte naše příklady kódu pro automatizaci tvorby PPT během několika sekund a eliminujte ruční práci."
---
## **Úvod**

Klónování je proces vytvoření přesné kopie nebo repliky něčeho. Aspose.Slides pro Node.js prostřednictvím Java také umožňuje vytvořit kopii nebo klon libovolného snímku a poté vložit tento klonovaný snímek do aktuální nebo jiné otevřené prezentace. Proces klonování snímků vytvoří nový snímek, který mohou vývojáři upravovat, aniž by změnili původní snímek. Existuje několik možných způsobů, jak klonovat snímek:

- Klon na konci v rámci prezentace.
- Klon na jiném místě v rámci prezentace.
- Klon na konci v jiné prezentaci.
- Klon na jiném místě v jiné prezentaci.
- Klon na konkrétní pozici v jiné prezentaci.

V Aspose.Slides pro Node.js prostřednictvím Java (kolekce objektů [Slide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Slide)) exponovaná objektem [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) poskytuje metody [addClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) a [insertClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) k provedení výše uvedených typů klonování snímků

## **Klon na konci v rámci prezentace**
Pokud chcete klonovat snímek a poté jej použít ve stejném souboru prezentace na konci existujících snímků, použijte metodu [addClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
1. Získejte objekt [SlideCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation#getSlides--) odkazováním na kolekci Slides, kterou exponuje objekt [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
1. Zavolejte metodu [addClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) exponovanou objektem [SlideCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation#getSlides--) a jako parametr předávejte snímek, který má být klonován.
1. Zapište upravený soubor prezentace.

V níže uvedeném příkladu jsme klonovali snímek (nacházející se na první pozici – index nula – prezentace) na konec prezentace.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instancujte třídu Presentation, která představuje soubor prezentace
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Zklonujte požadovaný snímek na konec kolekce snímků ve stejné prezentaci
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // Zapište upravenou prezentaci na disk
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klon na jiném místě v rámci prezentace**
Pokud chcete klonovat snímek a poté jej použít ve stejném souboru prezentace, ale na jiné pozici, použijte metodu [insertClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-):

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
1. Získejte objekt odkazováním na kolekci [**Slides**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation#getSlides--) exponovanou objektem [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
1. Zavolejte metodu [insertClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) exponovanou objektem [SlideCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation#getSlides--) a jako parametry předávejte snímek, který má být klonován, a index nové pozice.
1. Zapište upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme klonovali snímek (nacházející se v indexu 1 – pozice 2 – prezentace) na index 2 – pozice 3 – prezentace.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instancujte třídu Presentation, která představuje soubor prezentace
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // Zklonujte požadovaný snímek na konec kolekce snímků ve stejné prezentaci
    var slds = pres.getSlides();
    // Zklonujte požadovaný snímek na zadaný index ve stejné prezentaci
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // Zapište upravenou prezentaci na disk
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klon na konci v jiné prezentaci**
Pokud potřebujete klonovat snímek z jedné prezentace a použít jej v jiné prezentaci na konci existujících snímků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) obsahující prezentaci, ze které bude snímek klonován.
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) obsahující cílovou prezentaci, do které bude snímek přidán.
1. Získejte objekt [SlideCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideCollection) odkazováním na kolekci [**Slides**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation#getSlides--) exponovanou objektem Presentation cílové prezentace.
1. Zavolejte metodu [addClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) exponovanou objektem [SlideCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation#getSlides--) a jako parametr předávejte snímek ze zdrojové prezentace.
1. Zapište upravený soubor cílové prezentace.

V níže uvedeném příkladu jsme klonovali snímek (z prvního indexu zdrojové prezentace) na konec cílové prezentace.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instancujte třídu Presentation pro načtení zdrojového souboru prezentace
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instancujte třídu Presentation pro cílový PPTX (kam bude snímek klonován)
    var destPres = new aspose.slides.Presentation();
    try {
        // Zklonujte požadovaný snímek ze zdrojové prezentace na konec kolekce snímků v cílové prezentaci
        var slds = destPres.getSlides();
        slds.addClone(srcPres.getSlides().get_Item(0));
        // Zapište cílovou prezentaci na disk
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klon na jiném místě v jiné prezentaci**
Pokud potřebujete klonovat snímek z jedné prezentace a použít jej v jiné prezentaci na konkrétní pozici:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) obsahující zdrojovou prezentaci, ze které bude snímek klonován.
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) obsahující prezentaci, do které bude snímek přidán.
1. Získejte objekt [SlideCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation#getSlides--) odkazováním na kolekci Slides exponovanou objektem Presentation cílové prezentace.
1. Zavolejte metodu [insertClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) exponovanou objektem [SlideCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation#getSlides--) a jako parametry předávejte snímek ze zdrojové prezentace spolu s požadovanou pozicí.
1. Zapište upravený soubor cílové prezentace.

V níže uvedeném příkladu jsme klonovali snímek (z indexu nula zdrojové prezentace) na index 1 (pozice 2) cílové prezentace.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instancujte třídu Presentation pro načtení souboru zdrojové prezentace
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instancujte třídu Presentation pro cílový PPTX (kam bude snímek klonován)
    var destPres = new aspose.slides.Presentation();
    try {
        // Zklonujte požadovaný snímek ze zdrojové prezentace na konec kolekce snímků v cílové prezentaci
        var slds = destPres.getSlides();
        slds.insertClone(1, srcPres.getSlides().get_Item(0));
        // Zapište cílovou prezentaci na disk
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klon na konkrétní pozici v jiné prezentaci**
Pokud potřebujete klonovat snímek s hlavním snímkem (master slide) z jedné prezentace a použít jej v jiné prezentaci, musíte nejprve klonovat požadovaný hlavní snímek ze zdrojové prezentace do cílové. Poté použijte tento hlavní snímek pro klonování snímku s hlavním snímkem. Metoda [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) očekává hlavní snímek z cílové prezentace, nikoli ze zdrojové. Pro klonování snímku s hlavním snímkem postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) obsahující zdrojovou prezentaci, ze které bude snímek klonován.
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) obsahující cílovou prezentaci, do které bude snímek klonován.
1. Získejte přístup k snímku, který má být klonován, spolu s hlavním snímkem.
1. Získejte objekt [MasterSlideCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/MasterSlideCollection) odkazováním na kolekci Masters exponovanou objektem [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) cílové prezentace.
1. Zavolejte metodu [addClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) exponovanou objektem [MasterSlideCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/MasterSlideCollection) a jako parametr předávejte hlavní snímek ze zdrojového PPTX, který má být klonován.
1. Získejte objekt [SlideCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation#getSlides--) nastavením reference na kolekci Slides exponovanou objektem [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) cílové prezentace.
1. Zavolejte metodu [addClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) exponovanou objektem [SlideCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation#getSlides--) a jako parametry předávejte snímek ze zdrojové prezentace a hlavní snímek.
1. Zapište upravený soubor cílové prezentace.

V níže uvedeném příkladu jsme klonovali snímek s hlavním snímkem (nacházející se na indexu nula zdrojové prezentace) na konec cílové prezentace pomocí hlavního snímku ze zdrojového snímku.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instancujte třídu Presentation pro načtení souboru zdrojové prezentace
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Instancujte třídu Presentation pro cílovou prezentaci (kam bude snímek klonován)
    var destPres = new aspose.slides.Presentation();
    try {
        // Instancujte ISlide z kolekce snímků v zdrojové prezentaci spolu s
        // hlavním snímkem
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Zklonujte požadovaný hlavní snímek ze zdrojové prezentace do kolekce hlavních snímků v
        // cílové prezentaci
        var masters = destPres.getMasters();
        var DestMaster = masters.addClone(SourceMaster);
        // Zklonujte požadovaný snímek ze zdrojové prezentace s požadovaným hlavním snímkem na konec
        // kolekce snímků v cílové prezentaci
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);
        // Uložte cílovou prezentaci na disk
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klon na konci ve specifikované sekci**
Pokud chcete klonovat snímek a poté jej použít ve stejném souboru prezentace, ale v jiné sekci, použijte metodu [**addClone**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) exponovanou třídou [**SlideCollection**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideCollection). Aspose.Slides pro Node.js prostřednictvím Java umožňuje klonovat snímek z první sekce a poté vložit tento klonovaný snímek do druhé sekce stejné prezentace.

Následující úryvek kódu ukazuje, jak klonovat snímek a vložit jej do určené sekce.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // Uložte cílovou prezentaci na disk
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Zajistit shodu velikosti snímku**

Při klonování snímků do jiné prezentace se ujistěte, že cílová prezentace má stejnou velikost snímku jako zdrojová. Pokud se velikosti snímků liší, Aspose.Slides automaticky nepřepočítá měřítko klonovaných tvarů – jejich původní souřadnice a rozměry zůstávají zachovány, což může způsobit, že obsah bude nesprávně zarovnán nebo přesáhne okraje snímku.

Velikost snímku cílové prezentace můžete nastavit tak, aby odpovídala zdrojové, předtím než klonujete hlavní snímek a snímek:

```javascript
const sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), aspose.slides.SlideSizeScaleType.DoNotScale);
```

Udělejte to před klonováním hlavního snímku a snímku.

## **Často kladené otázky**

**Klony se kopírují poznámky k řečníkovi a komentáře recenzenta?**

Ano. Stránka s poznámkami a recenzní komentáře jsou zahrnuty do klonu. Pokud je nechcete, [odeberte je](/slides/cs/nodejs-java/presentation-notes/) po vložení.

**Jak se zacházejí s grafy a jejich zdroji dat?**

Objekt grafu, formátování a vložená data se kopírují. Pokud byl graf propojen s externím zdrojem (např. vložený OLE sešit), toto propojení zůstává jako [OLE objekt](/slides/cs/nodejs-java/manage-ole/). Po přesunu mezi soubory ověřte dostupnost dat a chování při aktualizaci.

**Mohu ovládat pozici vložení a sekce pro klon?**

Ano. Můžete vložit klon na konkrétní index snímku a umístit jej do vybrané [sekce](/slides/cs/nodejs-java/slide-section/). Pokud cílová sekce neexistuje, nejprve ji vytvořte a pak snímek do ní přesuňte.