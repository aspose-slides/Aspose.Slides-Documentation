---
title: Dia szekciók kezelése prezentációkban C++-val
linktitle: Dia szekció
type: docs
weight: 100
url: /hu/cpp/slide-section/
keywords:
- szekció létrehozása
- szekció hozzáadása
- szekció szerkesztése
- szekció módosítása
- szekció neve
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Egyszerűsítse a dia szekciókat PowerPointban és OpenDocumentban az Aspose.Slides for C++ segítségével – bontsa szét, nevezze át, és rendezze át a PPTX és ODP munkafolyamatok optimalizálásáért."
---
## **Bevezetés**

Az Aspose.Slides for C++ segítségével PowerPoint‑prezentációt szekciókba rendezhet. Létrehozhat olyan szekciókat, amelyek meghatározott diákot tartalmaznak.  

Lehet, hogy szekciókat szeretne létrehozni és azokat felhasználni a diák logikai részekre osztásához a következő helyzetekben:

- Amikor nagy prezentáción dolgozik másokkal vagy egy csapattal – és egyes diákat egy kollégnak vagy csapattagoknak kell kiosztania.  
- Amikor egy sok diát tartalmazó prezentációval dolgozik – és nehézségei vannak a tartalom egyszerre történő kezelésével vagy szerkesztésével.  

Ideális esetben olyan szekciót kell létrehozni, amely hasonló diákot tartalmaz – a diák közös jellemzőkkel bírnak, vagy egy szabály alapján csoportosíthatók – és a szekciót olyan névvel kell ellátni, amely leírja a benne lévő diák tartalmát.  

## **Szekciók létrehozása prezentációkban**

A prezentációban diákot tartalmazó szekció hozzáadásához az Aspose.Slides for C++ biztosítja az AddSection metódust, amely lehetővé teszi a létrehozni kívánt szekció nevének és a szekció kezdődiájának megadását.  

Ez a példakód bemutatja, hogyan hozhat létre szekciót egy prezentációban C++‑ban:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto defaultSlide = pres->get_Slides()->idx_get(0);
auto newSlide1 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide2 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide3 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide4 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));

auto section1 = pres->get_Sections()->AddSection(u"Section 1", newSlide1);
auto section2 = pres->get_Sections()->AddSection(u"Section 2", newSlide3);
// a section1 a newSlide2-nél fejeződik be, és ezután a section2 kezdődik   

pres->Save(u"pres-sections.pptx", SaveFormat::Pptx);

pres->get_Sections()->ReorderSectionWithSlides(section2, 0);
pres->Save(u"pres-sections-moved.pptx", SaveFormat::Pptx);

pres->get_Sections()->RemoveSectionWithSlides(section2);

pres->get_Sections()->AppendEmptySection(u"Last empty section");

pres->Save(u"pres-section-with-empty.pptx", SaveFormat::Pptx);
```

## **Szekciók nevének módosítása**

Miután létrehozott egy szekciót egy PowerPoint‑prezentációban, előfordulhat, hogy meg akarja változtatni a nevét.  

Ez a példakód bemutatja, hogyan változtathatja meg egy szekció nevét egy prezentációban C++‑ban az Aspose.Slides használatával:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto section = pres->get_Sections()->idx_get(0);
section->set_Name(u"My section");
```

## **GYIK**

**Megmaradnak a szekciók a PPT (PowerPoint 97–2003) formátumba mentéskor?**

Nem. A PPT formátum nem támogatja a szekció metaadatait, ezért a szekciócsoportosítás elveszik a .ppt‑be mentéskor.  

**Lehet egy egész szekciót „elrejteni”?**

Nem. Csak egyedi diákat lehet elrejteni. Egy szekciónak mint entitásnak nincs „rejtett” állapota.  

**Gyorsan meg tudom találni a szekciót egy diára hivatkozva, illetve a szekció első diáját?**

Igen. Egy szekció egyértelműen a kezdődiájával definiált; egy adott diából megállapítható, melyik szekcióhoz tartozik, és egy szekció esetén elérhető az első diája.