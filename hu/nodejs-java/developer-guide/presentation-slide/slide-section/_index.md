---
title: Dia szekciók kezelése prezentációkban JavaScript használatával
linktitle: Dia szekció
type: docs
weight: 90
url: /hu/nodejs-java/slide-section/
keywords:
- szekció létrehozása
- szekció hozzáadása
- szekció szerkesztése
- szekció módosítása
- szekció neve
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Egyszerűsítse a dia szekciók kezelését PowerPoint és OpenDocument formátumokban az Aspose.Slides for Node.js segítségével – bontsa szét, nevezze át és rendezze újra a PPTX és ODP munkafolyamatok optimalizálásához."
---
## **Bevezetés**

Az Aspose.Slides for Node.js via Java segítségével PowerPoint prezentációkat szervezhet szekciókba. Létrehozhat szekciókat, amelyek meghatározott diákat tartalmaznak.

Bizonyos helyzetekben szekciókat hozhat létre, és használhatja őket a dia szervezésére vagy felosztására a prezentációban logikai részekre:

- Amikor nagy prezentáción dolgozik más emberekkel vagy egy csapattal – és bizonyos diák hozzárendelésére van szükség egy kollégához vagy csapattagokhoz. 
- Amikor egy sok diát tartalmazó prezentációval dolgozik – és nehézségekbe ütközik annak tartalmának egyidejű kezelése vagy szerkesztése során.

Ideális esetben olyan szekciót kell létrehozni, amely hasonló diákat tartalmaz – a diáknak közös vonása van, vagy egy szabály alapján csoportba sorolhatók – és a szekciónak olyan nevet kell adni, amely leírja benne lévő diákat. 

## **Szekciók létrehozása a prezentációkban**

A prezentációban diákot tartalmazó szekció hozzáadásához az Aspose.Slides for Node.js via Java a [addSection()](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SectionCollection#addSection-java.lang.String-aspose.slides.ISlide-) metódust biztosítja, amely lehetővé teszi a létrehozni kívánt szekció nevének és a kezdő dia megadását.

Ez a példa kód bemutatja, hogyan hozhat létre szekciót egy prezentációban JavaScript-ben:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var defaultSlide = pres.getSlides().get_Item(0);
    var newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var section1 = pres.getSections().addSection("Section 1", newSlide1);
    var section2 = pres.getSections().addSection("Section 2", newSlide3);// a section1 a newSlide2-nél befejeződik, és utána a section2 kezdődik
    pres.save("pres-sections.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().removeSectionWithSlides(section2);
    pres.getSections().appendEmptySection("Last empty section");
    pres.save("pres-section-with-empty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Szekciók nevének módosítása**

Miután létrehozott egy szekciót egy PowerPoint prezentációban, dönthet úgy, hogy megváltoztatja a nevét. 

Ez a példa kód megmutatja, hogyan változtathatja meg egy szekció nevét egy prezentációban JavaScript használatával az Aspose.Slides segítségével:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Megmaradnak a szekciók a PPT (PowerPoint 97–2003) formátumba mentéskor?**

Nem. A PPT formátum nem támogatja a szekció metaadatait, így a szekciócsoportosítás elveszik, amikor .ppt formátumba ment.

**Lehet egy teljes szekciót "elrejtett"?**

Nem. Csak egyedi diák rejthetők el. A szekciónak, mint entitásnak, nincs "hidden" állapota.

**Gyorsan megtalálhatok egy szekciót egy dia alapján, és fordítva, a szekció első diát?**

Igen. Egy szekció egyértelműen a kezdő diája alapján definiálható; egy dia alapján meghatározható, hogy melyik szekcióhoz tartozik, és egy szekció esetén elérhető az első diája.