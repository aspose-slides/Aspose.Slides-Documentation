---
title: Dia szekciók kezelése bemutatókban Androidon
linktitle: Dia szekció
type: docs
weight: 90
url: /hu/androidjava/slide-section/
keywords:
- szekció létrehozása
- szekció hozzáadása
- szekció szerkesztése
- szekció módosítása
- szekció neve
- szekció diák lekérése
- szekció diák feldolgozása
- PowerPoint
- bemutató
- Android
- Java
- Aspose.Slides
description: "Dia szekciók kezelése Aspose.Slides for Android via Java segítségével: szekciók létrehozása, átnevezése, átrendezése, lekérése és a szekció diák feldolgozása PPTX bemutatókban."
---
## **Bevezetés**

A szekciók a folyamatos diák sorozatát elnevezett csoportokba szervezik, anélkül, hogy a dia tartalmát módosítanák. Az Aspose.Slides for Android via Java segítségével szekciókat hozhat létre, átrendezhet, átnevezhet, ellenőrizhet és eltávolíthat a [Presentation.getSections](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getSections--) metódussal.

A szekciók különösen hasznosak, ha:
- egy nagy bemutatót logikai témákra vagy fejezetekre kell felosztani;
- a diákk csoportok különböző együttműködőkhöz vannak rendelve;
- a diákot csoportokként kell feldolgozni, áthelyezni vagy egyesíteni.

Válasszon tömör szekció neveket, amelyek leírják a csoportosított diák célját. Mivel a szekciók a bemutató struktúrájának részei, használja a szekció API-kat a tagság meghatározásához, ahelyett, hogy a diák pozíciójából következtetne.

## **Szekciók létrehozása és kezelése**

Használja az [ISectionCollection.addSection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isectioncollection/#addSection-java.lang.String-com.aspose.slides.ISlide-) metódust egy szekció létrehozásához, amelynél megadja a nevét és a kezdő diát. Az Aspose.Slides meghatározza, hogy mely diák tartoznak a szekcióhoz a bemutató aktuális szekciószerkezete alapján.

Az ugyanaz az [ISectionCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isectioncollection/) azt is lehetővé teszi, hogy:
- egy szekciót a diáiával együtt áthelyezze a [ISectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isectioncollection/#reorderSectionWithSlides-com.aspose.slides.ISection-int-) metódus használatával;
- csak a szekciódefiníciót távolítsa el a [ISectionCollection.removeSection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isectioncollection/#removeSection-com.aspose.slides.ISection-) metódussal, amely megőrzi a diát;
- a szekciót és annak diáját távolítsa el a [ISectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isectioncollection/#removeSectionWithSlides-com.aspose.slides.ISection-) metódussal;
- adjunk egy üres szekciót a végén a [ISectionCollection.appendEmptySection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isectioncollection/#appendEmptySection-java.lang.String-) metódussal.

A következő példában két szekciót hoz létre, az egyiket áthelyezi, eltávolítja a diáiával együtt, és egy üres szekciót fűz hozzá:
```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide titleSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    ISection resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

Ezek után a bemutató tartalmazza az `Introduction` szekciót a diáival együtt és egy üres `Appendix` szekciót. A `Results` szekció és annak diái eltávolításra kerültek.

## **Szekciók átnevezése**

Egy szekció átnevezéséhez hívja meg a [ISection.setName](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isection/#setName-java.lang.String-) metódust. A szekció diái és pozíciója változatlan marad.

A következő példában egy szekciót hoz létre és megváltoztatja a nevét:
```java
import com.aspose.slides.ISection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISection section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **Diák lekérése szekciókból**

A [Presentation.getSections](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getSections--) metódus egy [ISectionCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isectioncollection/) objektumot ad vissza, amelyen iterálhat. Minden [ISection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isection/) esetén hívja meg a [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) metódust, hogy megkapja a jelenleg hozzá tartozó diák listáját. A metódus egy [ISectionSlideCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isectionslidecollection/) objektumot ad vissza, amely számlálót, indexelt hozzáférést és iterációt biztosít.

A következő példában két feltöltött szekciót és egy üres szekciót hoz létre, majd kiírja minden szekció [nevét](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isection/#getName--), [azonosítóját](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isection/#getSectionId--), [kezdő diáját](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isection/#getStartedFromSlide--), a diák számát és a dia számokat. A [ISectionSlideCollection.get_Item](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isectionslidecollection/#get_Item-int-) metódust használja az első dia beolvasásához és egy kiterjesztett `for` utasítást minden dia feldolgozásához. Az üres szekció esetén a visszaadott gyűjtemény mérete nulla, a metódus nem hívódik meg, és az iteráció nem hajt végre műveleteket.
```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    for (ISection section : presentation.getSections()) {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        String startingSlide = section.getStartedFromSlide() == null ? "none" : Integer.toString(section.getStartedFromSlide().getSlideNumber());

        System.out.println("Section: " + section.getName());
        System.out.println("ID: " + section.getSectionId());
        System.out.println("Starting slide: " + startingSlide);
        System.out.println("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            System.out.println("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        System.out.print("Slide numbers:");
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

A szekciótagságot a bemutató szekciószerkezete határozza meg. Ne számolja ki kézzel egy szekció tartományát az [ISection.getStartedFromSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isection/#getStartedFromSlide--) alapján, valamint a dia indexeket és a következő szekció kezdő diaját.

A struktúraváltoztatások módosíthatják a szekcióhoz tartozó diák listáját és azok diaszámát is. Ez magában foglalja a diák átrendezését, egy dia klónozását egy szekcióba, egy szekció és diái áthelyezését, diák eltávolítását és szekciók törlését. A következő példában minden ilyen változtatás után meghívja a [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) metódust, ahelyett, hogy a szekció korábbi határait feltételezné.
```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

import java.util.function.BiConsumer;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISection firstSection = presentation.getSections().addSection("First", firstSlide);
    ISection secondSection = presentation.getSections().addSection("Second", thirdSlide);

    BiConsumer<String, ISection> printSectionSlides = (label, section) -> {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        System.out.printf("%s (%d slides):", label, sectionSlides.size());
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    };

    printSectionSlides.accept("Initially", firstSection);

    ISectionSlideCollection slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides.accept("After cloning into the section", firstSection);

    ISectionSlideCollection slidesBeforeReorder = firstSection.getSlidesListOfSection();
    int firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    presentation.getSlides().reorder(firstSectionPosition, slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1));
    printSectionSlides.accept("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides.accept("After moving the section", firstSection);

    ISectionSlideCollection slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides.accept("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    for (ISection section : presentation.getSections()) {
        printSectionSlides.accept("Remaining section", section);
    }
} finally {
    presentation.dispose();
}
```

Hívja meg újra a [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) metódust, amikor diák vagy szekciók átrendezésre, klónozásra, áthelyezésre vagy eltávolításra kerülnek. Ez a további feldolgozást a jelenlegi bemutatószerkezethez igazítja.

A PPT (PowerPoint 97–2003) formátum nem őrzi meg a szekció metaadatait. Használja ezt a munkafolyamatot olyan formátummal, amely támogatja a szekciókat, például PPTX‑el; PPT‑re konvertálás esetén a szekciószerkezet, amely a későbbi iterációhoz szükséges, elveszik.

## **GYIK**

**Megmaradnak a szekciók a PPT (PowerPoint 97–2003) formátumba mentéskor?**

Nem. A PPT formátum nem támogatja a szekció metaadatait, ezért a szekciócsoportosítás elveszik, ha .ppt‑ként menti.

**Lehet egy teljes szekciót "elrejteni"?**

Nem. A szekciónak nincs láthatósági állapota. A tartalma elrejtéséhez hívja meg a [ISlide.setHidden](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islide/#setHidden-boolean-) metódust minden egyes dián a szekcióban.

**Hogyan találhatom meg azt a szekciót, amelyik egy diát tartalmaz?**

Iteráljon a [Presentation.getSections](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getSections--) által visszaadott gyűjteményen, minden szekciónál hívja meg az [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) metódust, és hasonlítsa össze a visszakapott diákat a keresett diával. Egy nem üres szekciónál az [ISection.getStartedFromSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isection/#getStartedFromSlide--) visszaadja az első diát; egy üres szekciónál `null`-t ad vissza.