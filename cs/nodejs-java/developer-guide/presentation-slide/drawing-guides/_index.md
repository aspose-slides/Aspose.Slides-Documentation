---
title: Správa kreslicích vodítek v prezentacích v JavaScriptu
linktitle: Kreslicí vodítka
type: docs
weight: 85
url: /cs/nodejs-java/drawing-guides/
keywords:
- kreslicí vodítko
- horizontální vodítko
- vertikální vodítko
- zarovnávací vodítko
- zobrazení snímku
- hlavní snímek
- rozložení snímku
- poznámkový mistr
- výtiskový mistr
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Přidávejte, přistupujte a odstraňujte horizontální a vertikální kreslicí vodítka v prezentacích PowerPoint pomocí Aspose.Slides pro Node.js přes Java."
---
## **Přehled**

Kreslicí vodítka jsou nastavitelná horizontální a vertikální čáry, které uživatelům pomáhají konzistentně zarovnávat tvary při úpravě prezentace v PowerPointu. Jsou zvláště užitečná, když aplikace generuje prezentaci, která bude později ručně upravována: aplikace může uložit stejné pomůcky pro zarovnání, které by měli autoři dodržovat při přidávání či přesouvání obsahu.

Kreslicí vodítka jsou pomůcky pro úpravy, nikoli obsah snímku. Neobjeví se v režimu prezentace ani v renderovaném výstupu. Aspose.Slides for Node.js via Java je zpřístupňuje pomocí třídy [DrawingGuidesCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/drawingguidescollection/). Vodítko je reprezentováno třídou [DrawingGuide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/drawingguide/) a má orientaci, pozici a barvu.

Pozice se měří v bodech od levého horního rohu příslušného snímku nebo mistra. Vertikální vodítko používá horizontální souřadnici, typicky mezi nulou a šířkou snímku. Horizontální vodítko používá vertikální souřadnici, typicky mezi nulou a výškou snímku.

## **Přidání vodítek do zobrazení snímku**

Použijte [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) ke správě vodítek zobrazených při úpravě běžných snímků. Zavolejte [DrawingGuidesCollection.add](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/drawingguidescollection/#add) s hodnotou [Orientation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/orientation/) a pozicí v bodech.

Následující příklad přidá jedno vertikální vodítko vpravo od středu snímku a jedno horizontální vodítko pod něj:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 + 12.5);
    guides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5);

    presentation.save("drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Přístup k vodítkům**

Metody [DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/drawingguidescollection/#getCount) a [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/drawingguidescollection/#get_Item) poskytují přístup k existujícím vodítkům. Metody [DrawingGuide.getOrientation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide.getPosition](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/drawingguide/#getPosition) a [DrawingGuide.getColor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/drawingguide/#getColor) vrací hodnoty, které lze také změnit odpovídajícími metodami pro nastavení.

Následující příklad čte vodítka zobrazení snímku z prezentace vytvořené výše:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("drawing-guides.pptx");
try {
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (let index = 0; index < guides.getCount(); index++) {
        const guide = guides.get_Item(index);
        console.log("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **Přidání vodítek do hlavního a rozložení snímků**

Hlavní snímek a každý jeho rozložení snímků může mít své vlastní kolekce kreslicích vodítek. Použijte [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterslide/#getDrawingGuides) pro hlavní snímek a [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutslide/#getDrawingGuides) pro rozložení snímku.

Následující příklad přidá vertikální vodítko na první hlavní snímek a horizontální vodítko na první rozložení snímku:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    const layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Přidání vodítek do poznámkových a výtiskových hlavních snímků**

Poznámkové mistry a výtiskové mistry také podporují kreslicí vodítka. Použijte [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masternotesslide/#getDrawingGuides) a [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterhandoutslide/#getDrawingGuides) k přístupu k jejich kolekcím. Pokud prezentace neobsahuje některý z těchto mistrů, `MasterNotesSlideManager.setDefaultMasterNotesSlide` nebo `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` vytvoří výchozí mistr a vrátí jej.

Následující příklad přidá horizontální vodítko do poznámkového mistra a vertikální vodítko do výtiskového mistra:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const notesSize = presentation.getNotesSize().getSize();
    const notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    const handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(slides.Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(slides.Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Vymazání vodítek**

Zavolejte [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/drawingguidescollection/#clear) k odebrání každého vodítka z konkrétní kolekce. Vymazání jedné kolekce neovlivní vodítka uložená v jiném rozsahu.

Následující příklad vymaže vodítka zobrazení snímku a všech vodítek na hlavních snímcích, rozložení snímcích, poznámkovém mistru i výtiskovém mistru, aniž by vytvářel chybějící mistry:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (let index = 0; index < presentation.getMasters().size(); index++) {
        presentation.getMasters().get_Item(index).getDrawingGuides().clear();
    }

    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        presentation.getLayoutSlides().get_Item(index).getDrawingGuides().clear();
    }

    const notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster !== null) {
        notesMaster.getDrawingGuides().clear();
    }

    const handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster !== null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Často kladené dotazy**

**Objevují se kreslicí vodítka ve slideshow nebo exportovaných obrázcích?**

Ne. Kreslicí vodítka jsou pomůcky pro zarovnání při úpravách a nejsou vykreslována jako obsah prezentace.

**Lze kreslicí vodítko přidat přímo k jednotlivému normálnímu snímku?**

Vodítka pro úpravu normálních snímků jsou uložena ve vlastnostech zobrazení snímku prezentace. Samostatné kolekce vodítek jsou k dispozici pro hlavní snímky, rozložení snímků, poznámkové mistry i výtiskové mistry.

**Jaké jednotky se používají pro pozice vodítek?**

Pozice jsou udávány v bodech, kde 72 bodů odpovídá jedné palci. Vertikální pozice se měří od levého okraje a horizontální pozice od horního okraje.

**Odstraňování kreslicích vodítek odstraňuje tvary nebo mění obsah snímku?**

Ne. Metoda [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/drawingguidescollection/#clear) odstraňuje pouze vodítka ve vybrané kolekci. Tvary a další obsah snímku zůstávají beze změny.