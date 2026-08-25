---
title: Diákszakciók kezelése prezentációkban Java-val
linktitle: Diákszakció
type: docs
weight: 90
url: /hu/java/slide-section/
keywords:
- szekció létrehozása
- szekció hozzáadása
- szekció szerkesztése
- szekció módosítása
- szekció neve
- szekció diák lekérése
- szekció diák feldolgozása
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Diákszakciók kezelése az Aspose.Slides for Java-val: szekciók létrehozása, átnevezése, átrendezése, lekérése és szekciódiák feldolgozása PPTX prezentációkban."
---
## **Bevezetés**

A szekciók a egymást követő diákot elnevezett csoportokba szervezik anélkül, hogy megváltoztatnák a diák tartalmát. Az Aspose.Slides for Java-val szekciókat hozhat létre, átrendezhet, átnevezhet, ellenőrizhet és eltávolíthat a [Presentation.getSections](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getSections--) metódus segítségével.

A szekciók különösen hasznosak, ha:

- egy nagy prezentációt logikai témákra vagy fejezetekre kell felosztani;
- a különböző diákköröket különböző együttműködőkre kell kiosztani;
- a diákat csoportként kell feldolgozni, áthelyezni vagy egyesíteni.

Válasszon tömör szekciónévket, amelyek leírják a csoportosított diák célját. Mivel a szekciók a bemutató szerkezetének részei, használja a szekció API‑kat a tagság meghatározásához, ahelyett, hogy a diákkövetésből következtetne.

## **Szekciók létrehozása és kezelése**

Használja a [ISectionCollection.addSection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isectioncollection/#addSection-java.lang.String-com.aspose.slides.ISlide-) metódust szekció létrehozásához a neve és a kezdő dia megadásával. Az Aspose.Slides a prezentáció jelenlegi szekciószerkezetéből határozza meg, mely diák tartoznak a szekcióhoz.

Az ugyanaz a [ISectionCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isectioncollection/) is lehetővé teszi, hogy:

- a szekciót a diáival együtt áthelyezze a [ISectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isectioncollection/#reorderSectionWithSlides-com.aspose.slides.ISection-int-) használatával;
- csak a szekciódefiníciót távolítsa el a [ISectionCollection.removeSection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isectioncollection/#removeSection-com.aspose.slides.ISection-) segítségével, ami megtartja a diákot;
- a szekciót és annak diákját távolítsa el a [ISectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isectioncollection/#removeSectionWithSlides-com.aspose.slides.ISection-) segítségével;
- üres szekciót adjon hozzá a végén a [ISectionCollection.appendEmptySection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isectioncollection/#appendEmptySection-java.lang.String-) segítségével.

A következő példa két szekciót hoz létre, az egyiket áthelyezi, azt a diáiival együtt eltávolítja, majd egy üres szekciót fűz hozzá:

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

Ezek után a bemutató tartalmazza a `Introduction` szekciót a diáinak együtt és egy üres `Appendix` szekciót. A `Results` szekció és annak diái eltávolításra kerültek.

## **Szekciók átnevezése**

Egy szekció átnevezéséhez hívja meg annak [ISection.setName](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isection/#setName-java.lang.String-) metódusát. A szekció diái és pozíciója változatlan marad.

A következő példa egy szekciót hoz létre és megváltoztatja a nevét:

```java
import com.aspose.slides.ISection;
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

A [Presentation.getSections](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getSections--) metódus egy [ISectionCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isectioncollection/) objektumot ad vissza, amelyet végigiterálhat. Minden [ISection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isection/) esetén hívja meg a [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isection/#getSlidesListOfSection--) metódust a jelenleg hozzá tartozó diák lekéréséhez. A metódus egy [ISectionSlideCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isectionslidecollection/) objektumot ad vissza, amely számlálót, indexelt hozzáférést és iterálást biztosít.

A következő példa két feltöltött szekciót és egy üres szekciót hoz létre, majd kiírja minden szekció [name](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isection/#getName--), [identifier](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isection/#getSectionId--), [starting slide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isection/#getStartedFromSlide--), diák számát és diaszámokat. A [ISectionSlideCollection.get_Item](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isectionslidecollection/#get_Item-int-) használatával olvassa az első diát, és egy kibővített `for` utasítással dolgozza fel az összes diát. Az üres szekció esetén a visszaadott gyűjtemény mérete nulla, a metódust nem hívják, és az iteráció nem hajt végre műveletet.

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

A szekció tagsága a prezentáció szekciószerkezetéből származik. Ne számítsa ki kézzel egy szekció tartományát a [ISection.getStartedFromSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isection/#getStartedFromSlide--), diaindexek és a következő szekció kezdődiai alapján.

A szerkezeti módosítások megváltoztathatják a szekcióhoz tartozó visszaadott diák számát és azok diaszámát is. Ide tartozik a diák átrendezése, egy dia klónozása egy szekcióba, egy szekció áthelyezése a diáival együtt, diák eltávolítása és szekciók törlése. A következő példa minden ilyen változás után meghívja a [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isection/#getSlidesListOfSection--) metódust, ahelyett, hogy a szekció korábbi határairól feltételezéseket tárolna.

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

Hívja meg a [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isection/#getSlidesListOfSection--) metódust újra, amikor csak diák vagy szekciók átrendezésre, klónozásra, áthelyezésre vagy eltávolításra kerülnek. Ez a későbbi feldolgozást a jelenlegi prezentációs szerkezettel összehangolja.

A PPT (PowerPoint 97–2003) formátum nem őrzi meg a szekció metaadatait. Használja ezt a munkafolyamatot olyan formátummal, amely támogatja a szekciókat, például PPTX‑szel; PPT‑re konvertáláskor a szekciószerkezet, amely a későbbi iterációhoz szükséges, eltűnik.

## **GYIK**

**Are sections preserved when saving to the PPT (PowerPoint 97–2003) format?**

Nem. A PPT formátum nem támogatja a szekció metaadatait, ezért a szekciócsoportosítás elveszik .ppt‑ként mentéskor.

**Can an entire section be "hidden"?**

Nem. A szekciónak nincs láthatósági állapota. A tartalma elrejtéséhez hívja meg a [ISlide.setHidden](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islide/#setHidden-boolean-) metódust minden diához a szekcióban.

**How can I find the section that contains a slide?**

Iteráljon a [Presentation.getSections](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getSections--) által visszaadott gyűjteményen, hívja meg minden szekciónál a [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isection/#getSlidesListOfSection--) metódust, és hasonlítsa össze a visszakapott diákot a keresett diával. Egy nem üres szekciónál a [ISection.getStartedFromSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isection/#getStartedFromSlide--) visszaadja az első diát; egy üres szekciónál `null`‑t ad vissza.