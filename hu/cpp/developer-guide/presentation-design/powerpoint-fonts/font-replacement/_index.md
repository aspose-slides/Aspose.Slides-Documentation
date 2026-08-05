---
title: A betűtípus cseréjének egyszerűsítése prezentációkban C++ használatával
linktitle: Betűtípus csere
type: docs
weight: 60
url: /hu/cpp/font-replacement/
keywords:
- betűtípus
- betűtípus cseréje
- betűtípus csere
- betűtípus módosítása
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Zökkenőmentesen cserélje a betűtípusokat az Aspose.Slides C++-ban, hogy konzisztens tipográfiát biztosítson a PowerPoint és OpenDocument prezentációkban."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy egy betűtípust egy másikra cseréljen ki az egész előadás során. Amikor egy betűtípust cserélnek, az eredeti betűtípus összes előfordulása az új betűtípusra módosul.

A betűtípus cseréjének végrehajtásához töltse be az előadást, határozza meg a forrás‑betűtípust és a helyettesítő betűtípust, hívja meg a betűtípus csere metódust, majd mentse a módosított előadást PPTX fájlként. Ez a megközelítés akkor hasznos, ha szándékosan szeretne egy betűtípus‑családot egy másikra cserélni az egész előadásban.

## **Betűtípusok cseréje**

Ha meggondolja magát egy betűtípussal kapcsolatban, kicserélheti azt egy másik betűtípusra. A régi betűtípus minden előfordulása helyettesítésre kerül az új betűtípussal.

Az Aspose.Slides a következő módon teszi lehetővé a betűtípus cseréjét:

1. Töltse be a megfelelő előadást.  
2. Töltse be a cserélendő betűtípust.  
3. Töltse be az új betűtípust.  
4. Cserélje ki a betűtípust.  
5. Írja ki a módosított előadást PPTX fájlként.

Ez a C++ kód bemutatja a betűtípus cseréjét:

``` cpp
// Betölt egy prezentációt
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// Betölti a cserélendő forrás betűtípust
auto sourceFont = System::MakeObject<FontData>(u"Arial");

// Betölti az új betűtípust
auto destFont = System::MakeObject<FontData>(u"Times New Roman");

// Lecseréli a betűtípusokat
presentation->get_FontsManager()->ReplaceFont(sourceFont, destFont);

// Mentés a prezentációt
presentation->Save(u"UpdatedFont_out.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
A szabályok beállításához, amelyek meghatározzák, mi történjen bizonyos körülményekben (például ha egy betűtípus nem érhető el), tekintse meg a [**Betűtípus helyettesítés**](/slides/hu/cpp/font-substitution/) oldalt. 
{{% /alert %}}

## **GYIK**

**Mi a különbség a „betűtípus csere”, a „betűtípus helyettesítés” és a „tartalékbetűtípusok” között?**

A csere egy szándékos váltás egy családról a másikra az egész dokumentumban. A [helyettesítés](/slides/hu/cpp/font-substitution/) egy szabály, például „ha a betűtípus nem elérhető, használja ezt”. A [tartalékbetűtípus](/slides/hu/cpp/fallback-font/) egyedi hiányzó glifek esetén alkalmazandó, amikor az alapkészlet telepítve van, de nem tartalmazza a szükséges karaktereket.

**Érvényes-e a csere a mesterdiákra, elrendezésekre, jegyzetekre és megjegyzésekre?**

Igen. A csere minden olyan előadáselemre hat, amely az eredeti betűtípust használja, beleértve a mesterdiákat és a jegyzeteket; a megjegyzések is a dokumentum részét képezik, és a betűtípus‑motor figyelembe veszi őket.

**Változik-e a betűtípus a beágyazott OLE objektumokban (például Excelben)?**

Nem. Az [OLE tartalom](/slides/hu/cpp/manage-ole/) saját alkalmazása által van szabályozva. A prezentációban végzett csere nem formázza újra a belső OLE adatot; az megjelenhet képként vagy külsőleg szerkeszthető tartalomként.

**Lefordíthatom-e a betűtípust csak a prezentáció egy részére (diák vagy régiók szerint)?**

Célzott csere lehetséges, ha a betűtípust a szükséges objektumok/tartományok szintjén módosítja, ahelyett, hogy globálisan cserélné az egész dokumentumot. A renderelés közbeni általános betűtípus‑kiválasztási logika változatlan marad.

**Hogyan deríthetem előre, hogy milyen betűtípusok vannak használatban az előadásban?**

Használja az előadás [betűtípus‑kezelőjét](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsmanager/): ez felsorolja a [használt családokat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsmanager/getfonts/) és információkat ad a [helyettesítésekről/„ismeretlen” betűtípusokról](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsmanager/getsubstitutions/), ami segít a cserék tervezésében.

**Működik-e a betűtípus csere PDF‑/képkonvertáláskor?**

Igen. Exportálás során az Aspose.Slides ugyanazt a [betűtípus‑kiválasztási/helyettesítési sorrendet](/slides/hu/cpp/font-selection-sequence/) alkalmazza, így az előre végzett csere tiszteletben van tartva a konverzió során.

**Szükséges-e a cél‑betűtípust a rendszerre telepíteni, vagy csatolhatok egy betűtípus‑mappát?**

Telepítés nem kötelező: a könyvtár lehetővé teszi a [külső betűtípusok betöltését](/slides/hu/cpp/custom-font/) a felhasználó mappáiból a [renderelés és export](/slides/hu/cpp/convert-powerpoint/) során való használathoz.

**Megoldja‑e a csere a „tofu” (négyzetek) megjelenését a karakterek helyett?**

Csak akkor, ha a cél‑betűtípus valóban tartalmazza a szükséges glifeket. Ha nem, konfigurálja a [tartalékbetűtípust](/slides/hu/cpp/fallback-font/) a hiányzó karakterek lefedéséhez.