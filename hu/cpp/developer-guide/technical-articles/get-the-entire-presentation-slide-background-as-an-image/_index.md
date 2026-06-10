---
title: A teljes dia háttér képként történő lekérése a prezentációból
linktitle: Teljes dia háttér
type: docs
weight: 95
url: /hu/cpp/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- dia háttér
- végső háttér
- háttér kinyerése
- teljes háttér
- háttér képpé
- PPT háttér
- PPTX háttér
- ODP háttér
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "A PowerPoint és OpenDocument prezentációkból a teljes dia hátteret képek formájában nyeri ki az Aspose.Slides for C++ használatával, egyszerűsítve a vizuális munkafolyamatokat."
---
## **Áttekintés**

A PowerPoint‑prezentációkban a dia háttér több elemből állhat, többek között a dia háttérképéből, a prezentáció téma‑sablonjából, a színpalettából és a mester‑ vagy elrendezés‑diára helyezett objektumokból.

Ez a cikk bemutatja, hogyan lehet az egész dia hátterét képként kinyerni az Aspose.Slides használatával. Mivel erre nincs egyetlen módszer, a megközelítés a kijelölt dia klónozását egy ideiglenes prezentációba, a dia alakzatainak eltávolítását, majd a kapott dia háttér képformátumba konvertálását jelenti.

## **Az egész dia háttér lekérése**

Az Aspose.Slides for C++ nem biztosít egyszerű módszert a teljes prezentációs dia háttér képként történő kinyerésére, de az alábbi lépéseket követve elvégezhető:
1. Töltsd be a prezentációt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztály használatával.
1. Szerezd meg a dia méretét a prezentációból.
1. Válassz ki egy diát.
1. Hozz létre egy ideiglenes prezentációt.
1. Állítsd be ugyanazt a dia méretet az ideiglenes prezentációban.
1. Klónozd a kiválasztott diát az ideiglenes prezentációba.
1. Töröld az alakzatokat a klónozott diáról.
1. Konvertáld a klónozott diát képpé.

Az alábbi kódrészlet kinyeri a teljes prezentációs dia hátterét képként.
```cpp
auto slideIndex = 0;
auto imageScale = 1;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slides()->idx_get(slideIndex);

auto tempPresentation = System::MakeObject<Presentation>();

auto slideWidth = slideSize.get_Width();
auto slideHeight = slideSize.get_Height();
tempPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::DoNotScale);

auto clonedSlide = tempPresentation->get_Slides()->AddClone(slide);
clonedSlide->get_Shapes()->Clear();

auto background = clonedSlide->GetImage(imageScale, imageScale);
background->Save(u"output.png", ImageFormat::Png);

tempPresentation->Dispose();
presentation->Dispose();
```

## **GYIK**

**A mester diáról származó összetett színátmenetek, textúrák vagy képpel kitöltések megmaradnak-e a kapott háttérképen?**

Igen. Az Aspose.Slides megjeleníti a dia, elrendezés vagy mester által meghatározott színátmenet, kép és textúra kitöltéseket. Ha el akarod választani a megjelenést az örökölt mesterektől, akkor [állíts be saját hátteret](/slides/hu/cpp/presentation-background/) az aktuális dián exportálás előtt.

**Hozzáadhatok vízjelet a kapott háttérképhez mentés előtt?**

Igen. [Vízjel](/slides/hu/cpp/watermark/) alakzatot vagy képet adhatod hozzá egy munkaközben lévő [dia másolatához](/slides/hu/cpp/clone-slides/) (a többi tartalom mögé helyezve), majd exportálhatod. Így egy vízjellel ellátott háttérkép jön létre.

**Lekérhetem egy adott elrendezés vagy mester hátterét anélkül, hogy létező diához kapcsolnám?**

Igen. Hozzáférhetsz a kívánt mesterhez vagy elrendezéshez, alkalmazd egy [ideiglenes diára](/slides/hu/cpp/clone-slides/) a szükséges mérettel, majd exportáld azt a diát, hogy megkapd az adott elrendezésből vagy mesterből származó hátteret.

**Vannak licencelési korlátozások, amelyek befolyásolják a képexportot?**

A renderelési funkciók teljes mértékben elérhetők egy [érvényes licence](/slides/hu/cpp/licensing/) esetén. Értékelő módban a kimenet korlátozásokkal, például vízjellel jelenhet meg. Aktiváld a licencet egyszer a folyamatban, mielőtt kötegelt exportokat futtatsz.