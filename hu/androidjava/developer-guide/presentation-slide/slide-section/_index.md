---
title: Dia szekciók kezelése a prezentációkban Androidon
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
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Egyszerűsítse a diák szekcióinak kezelését PowerPoint és OpenDocument formátumokban az Aspose.Slides for Android via Java segítségével—osztás, átnevezés és újrarendezés a PPTX és ODP munkafolyamatok optimalizálásához."
---
## **Bevezetés**

Az Aspose.Slides for Android via Java segítségével egy PowerPoint-prezentációt szekciókba rendezhet. Létrehozhat szekciókat, amelyek meghatározott diákot tartalmaznak.

Ilyen helyzetekben előfordulhat, hogy szekciókat hoz létre, és azokat a prezentáció diáinak logikai részekre rendezésére vagy felosztására használja:

- Amikor egy nagy prezentáción dolgozik másokkal vagy egy csapattal – és bizonyos diákat egy kollégának vagy néhány csapattagnak kell kiosztania. 
- Amikor egy sok diát tartalmazó prezentációval dolgozik – és nehezen tudja egyszerre kezelni vagy szerkeszteni annak tartalmát.

Ideálisan olyan szekciót kell létrehozni, amely hasonló diákot tartalmaz – a diáknak közös vonása van, vagy szabály alapján csoportba sorolhatók – és a szekciónak olyan nevet kell adni, amely leírja a benne lévő diákat. 

## **Szekciók létrehozása a prezentációkban**

A prezentációban diákot tartalmazó szekció hozzáadásához az Aspose.Slides for Android via Java a [addSection()](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) metódust biztosítja, amely lehetővé teszi a létrehozni kívánt szekció nevének megadását, valamint annak a diáknak a meghatározását, amelytől a szekció kezdődik.

Ez a mintakód bemutatja, hogyan hozhat létre egy szekciót a prezentációban Java használatával:

```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("Section 1", newSlide1);
    ISection section2 = pres.getSections().addSection("Section 2", newSlide3); // a section1 befejeződik a newSlide2-nél, és utána a section2 kezdődik   

    pres.save("pres-sections.pptx", SaveFormat.Pptx);

    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", SaveFormat.Pptx);

    pres.getSections().removeSectionWithSlides(section2);

    pres.getSections().appendEmptySection("Last empty section");

    pres.save("pres-section-with-empty.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Szekciók nevének módosítása**

Miután létrehozott egy szekciót egy PowerPoint-prezentációban, előfordulhat, hogy megváltoztatja annak nevét. 

Ez a mintakód bemutatja, hogyan változtathatja meg egy szekció nevét a prezentációban Java és az Aspose.Slides használatával:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ISection section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Megmaradnak a szekciók a PPT (PowerPoint 97–2003) formátumba mentéskor?**

Nem. A PPT formátum nem támogatja a szekció metaadatokat, ezért a szekciók csoportosítása elveszik, amikor .ppt formátumba ment.

**Lehet egy egész szekciót „elrejteni”?**

Nem. Csak egyes diák rejthetők el. A szekció, mint entitás, nem rendelkezik „rejtett” állapottal.

**Gyorsan meg tudom találni egy szekciót egy dia alapján, illetve a szekció első diáját?**

Igen. Egy szekció egyértelműen a kezdő diájával van meghatározva; egy adott dia alapján megállapítható, melyik szekcióhoz tartozik, és egy szekció esetén elérhető annak első diája.