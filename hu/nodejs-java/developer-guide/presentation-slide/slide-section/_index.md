---
title: "Dia szekciók kezelése bemutatókban JavaScript‑tel"
linktitle: "Dia szekció"
type: docs
weight: 90
url: /hu/nodejs-java/slide-section/
keywords:
- "szekció létrehozása"
- "szekció hozzáadása"
- "szekció szerkesztése"
- "szekció módosítása"
- "szekció neve"
- "szekció diák lekérése"
- "szekció diák feldolgozása"
- "PowerPoint"
- "bemutató"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Dia szekciók kezelése az Aspose.Slides for Node.js via Java segítségével: szekciók létrehozása, átnevezése, átrendezése, lekérése és feldolgozása PPTX bemutatókban."
---
## **Bevezetés**

A szekciók a soron következő diákot névvel ellátott csoportokba szervezik anélkül, hogy megváltoztatnák a diákat. Az Aspose.Slides for Node.js via Java segítségével létrehozhat, átrendezhet, átnevezhet, ellenőrizhet és eltávolíthat szekciókat a [Presentation.getSections](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#getSections) metódussal.

A szekciók különösen hasznosak, ha:

- egy nagy bemutatót logikai témákra vagy fejezetekre kell felosztani;
- a diák különböző csoportjait különböző közreműködőknek kell hozzárendelni;
- a diákat csoportként kell feldolgozni, áthelyezni vagy egyesíteni.

Válasszon tömör szekcióneveket, amelyek leírják a csoportosított diák célját. Mivel a szekciók a bemutató struktúrájának részei, használja a szekció API-kat a tagság meghatározásához a diák pozíciója helyett.

## **Szekciók létrehozása és kezelése**

Használja a [SectionCollection.addSection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sectioncollection/#addSection) metódust egy szekció létrehozásához, amelynek megadja a nevét és a kezdő diát. Az Aspose.Slides a bemutató aktuális szekciós struktúrája alapján határozza meg, hogy mely diák tartoznak a szekcióhoz.

A ugyanazon [SectionCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sectioncollection/) lehetővé teszi továbbá, hogy:

- egy szekciót a diáiával együtt áthelyezni a [SectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sectioncollection/#reorderSectionWithSlides) használatával;
- csak a szekciódefiníciót eltávolítani a [SectionCollection.removeSection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sectioncollection/#removeSection) segítségével, ami megtartja a diákat;
- egy szekciót és diáiát eltávolítani a [SectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sectioncollection/#removeSectionWithSlides) használatával;
- egy üres szekciót a végén hozzáadni a [SectionCollection.appendEmptySection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sectioncollection/#appendEmptySection) segítségével.

A következő példa két szekciót hoz létre, az egyiket áthelyezi, eltávolítja a diáiával együtt, és egy üres szekciót fűz hozzá:

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const titleSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    const resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

Ezek után a bemutató tartalmazza a `Introduction` szekciót a diáival, valamint egy üres `Appendix` szekciót. A `Results` szekció és a diái el lettek távolítva.

## **Szekciók átnevezése**

Egy szekció átnevezéséhez hívja meg a [Section.setName](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/section/#setName) metódust. A szekció diái és pozíciója változatlan marad.

A következő példa egy szekciót hoz létre és megváltoztatja a nevét:

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **Diák lekérdezése szekciókból**

A [Presentation.getSections](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#getSections) metódus egy [SectionCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sectioncollection/) objektumot ad vissza, amelyet index alapján érhet el. Minden [Section](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/section/) esetén hívja meg a [Section.getSlidesListOfSection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/section/#getSlidesListOfSection) metódust, hogy megkapja a jelenleg hozzá tartozó diák listáját. A metódus egy [SectionSlideCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sectionslidecollection/) objektumot ad vissza, amely számlálót és indexelt hozzáférést biztosít.

A következő példa két feltöltött szekciót és egy üres szekciót hoz létre, majd kiírja minden szekció [nevét](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/section/#getName), [azonosítóját](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/section/#getSectionId), [kezdő diáját](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/section/#getStartedFromSlide), a diák számát és a dia sorszámokat. A [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sectionslidecollection/#get_Item) metódust használja az első dia és a kollekció minden egyes diájának olvasásához. Az üres szekció esetén a visszaadott kollekció mérete nulla, az indexelt hozzáférés kihagyásra kerül, és a ciklus nem hajt végre műveletet.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    const sections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < sections.size(); sectionIndex++) {
        const section = sections.get_Item(sectionIndex);
        const sectionSlides = section.getSlidesListOfSection();
        const startingSlideObject = section.getStartedFromSlide();
        const startingSlide = startingSlideObject === null ? "none" : startingSlideObject.getSlideNumber().toString();

        console.log("Section: " + section.getName());
        console.log("ID: " + section.getSectionId().toString());
        console.log("Starting slide: " + startingSlide);
        console.log("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            console.log("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        let slideNumbers = "Slide numbers:";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            slideNumbers += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(slideNumbers);
    }
} finally {
    presentation.dispose();
}
```

A szekció tagságát a bemutató szekciós struktúrája határozza meg. Ne számolja ki kézzel egy szekció tartományát a [Section.getStartedFromSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/section/#getStartedFromSlide), dia indexek és a következő szekció kezdő diája alapján.

A struktúrapróbálások megváltoztathatják egy szekcióhoz tartozó diák listáját és azok sorszámait is. Ez magában foglalja a diák átrendezését, egy dia klónozását egy szekcióba, egy szekció és diái áthelyezését, diák eltávolítását és szekciók törlését. A következő példa minden ilyen változtatás után meghívja a [Section.getSlidesListOfSection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/section/#getSlidesListOfSection) metódust, ahelyett, hogy a szekció korábbi határait feltételezné.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const firstSection = presentation.getSections().addSection("First", firstSlide);
    const secondSection = presentation.getSections().addSection("Second", thirdSlide);

    const printSectionSlides = (label, section) => {
        const sectionSlides = section.getSlidesListOfSection();
        let output = label + " (" + sectionSlides.size() + " slides):";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            output += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(output);
    };

    printSectionSlides("Initially", firstSection);

    const slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides("After cloning into the section", firstSection);

    const slidesBeforeReorder = firstSection.getSlidesListOfSection();
    const firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    const lastSlideInSection = slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1);
    presentation.getSlides().reorder(firstSectionPosition, lastSlideInSection);
    printSectionSlides("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides("After moving the section", firstSection);

    const slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    const remainingSections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < remainingSections.size(); sectionIndex++) {
        printSectionSlides("Remaining section", remainingSections.get_Item(sectionIndex));
    }
} finally {
    presentation.dispose();
}
```

Hívja meg újra a [Section.getSlidesListOfSection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/section/#getSlidesListOfSection) metódust, amikor diákat vagy szekciókat átrendeznek, klónoznak, áthelyeznek vagy eltávolítanak. Ez biztosítja, hogy a további feldolgozás a jelenlegi bemutató struktúrához igazodjon.

A PPT (PowerPoint 97–2003) formátum nem őrzi meg a szekció metaadatokat. Használja ezt a munkafolyamatot olyan formátummal, amely támogatja a szekciókat, például PPTX; a PPT formátumba konvertálás eltávolítja a későbbi iterációhoz szükséges szekciós struktúrát.

## **GYIK**

**Megmaradnak a szekciók, ha PPT (PowerPoint 97–2003) formátumba mentjük?**

Nem. A PPT formátum nem támogatja a szekció metaadatokat, ezért a szekciócsoportosítás elveszik, ha .ppt formátumba ment.

**Lehet egy egész szekciót „elrejteni”?**

Nem. A szekciónak nincs láthatósági állapota. A tartalmának elrejtéséhez hívja meg a [Slide.setHidden](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/#setHidden) metódust a szekció minden egyes diájára.

**Hogyan találhatom meg azt a szekciót, amelyik egy adott diát tartalmaz?**

A [Presentation.getSections](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#getSections) által visszaadott kollekció minden szekciójához férjen hozzá, hívja meg a [Section.getSlidesListOfSection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/section/#getSlidesListOfSection) metódust az egyes szekciókon, és hasonlítsa össze a visszaadott diák listáját a keresett diával. Nem üres szekció esetén a [Section.getStartedFromSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/section/#getStartedFromSlide) visszaadja az első diát; üres szekció esetén `null`-t ad vissza.