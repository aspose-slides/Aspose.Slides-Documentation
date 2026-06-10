---
title: A betűtípus helyettesítés egyszerűsítése előadásokban C++ használatával
linktitle: Betűtípus helyettesítés
type: docs
weight: 60
url: /hu/cpp/font-replacement/
keywords:
- betűtípus
- betűtípus helyettesítés
- betűtípus helyettesítés
- betűtípus módosítása
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Zökkenőmentesen helyettesítheti a betűtípusokat az Aspose.Slides C++-ban, hogy konzisztens tipográfiát biztosítson a PowerPoint és OpenDocument előadásokban."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy egy betűtípust egy másikkal helyettesítsen a teljes előadás során. Amikor egy betűtípust helyettesítenek, az eredeti betűtípus minden előfordulása az új betűtípusra változik.

A betűtípus helyettesítéséhez töltse be az előadást, határozza meg a forrás‑betűtípust és a helyettesítő betűtípust, hívja meg a betűtípus‑helyettesítési metódust, majd mentse a módosított előadást PPTX fájlként. Ez a megközelítés akkor hasznos, ha szándékosan szeretne egy betűcsaládot egy másikra cserélni az egész előadásban.

## **Betűtípusok helyettesítése**

Ha meggondolja magát a betűtípus használatával kapcsolatban, helyettesítheti azt egy másik betűtípussal. A régi betűtípus minden előfordulása az új betűtípussal lesz helyettesítve.

Az Aspose.Slides lehetővé teszi a betűtípus ilyen módú helyettesítését:

1. Töltse be a megfelelő előadást.  
2. Töltse be a helyettesítendő betűtípust.  
3. Töltse be az új betűtípust.  
4. Helyettesítse a betűtípust.  
5. Írja ki a módosított előadást PPTX fájlként.

Ez a C++ kód bemutatja a betűtípus helyettesítését:

``` cpp
// Betölt egy előadást
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// Betölti a helyettesítendő forrásbetűtípust
auto sourceFont = System::MakeObject<FontData>(u"Arial");

// Betölti az új betűtípust
auto destFont = System::MakeObject<FontData>(u"Times New Roman");

// Helyettesíti a betűtípusokat
presentation->get_FontsManager()->ReplaceFont(sourceFont, destFont);

// Elmenti az előadást
presentation->Save(u"UpdatedFont_out.pptx", SaveFormat::Pptx);
```

{{% alert title="Megjegyzés" color="warning" %}}  
A bizonyos feltételek (például ha egy betűtípus nem érhető el) esetén alkalmazandó szabályok beállításához tekintse meg a [**Betűtípus helyettesítés**](/slides/hu/cpp/font-substitution/)-t.  
{{% /alert %}}

## **GYIK**

**Mi a különbség a „betűtípus helyettesítés”, a „betűtípus szubsztitúció” és a „tartalékbetűtípus” között?**

A helyettesítés egy szándékos váltás egy családról a másikra az egész dokumentumban. A [Szubsztitúció](/slides/hu/cpp/font-substitution/) egy olyan szabály, mint például „ha a betűtípus nem elérhető, használja ezt X‑et”. A [Tartalékbetűtípus](/slides/hu/cpp/fallback-font/) egyedi hiányzó glifokra vonatkozik, amikor az alap‑betűtípus telepítve van, de nem tartalmazza a szükséges karaktereket.

**A helyettesítés vonatkozik‑e a mester‑diákokra, elrendezésekre, jegyzetekre és megjegyzésekre?**

Igen. A helyettesítés az összes olyan előadás‑objektusra hat, amely az eredeti betűtípust használja, beleértve a mester‑diákat és a jegyzeteket; a megjegyzések is a dokumentum részei, és a betűtípus‑motor figyelembe veszi őket.

**A betűtípus megváltozik‑e beágyazott OLE objektumok (például Excel) belsejében?**

Nem. Az [OLE‑tartalom](/slides/hu/cpp/manage-ole/) saját alkalmazásához tartozik. A prezentációban végzett helyettesítés nem formázza újra a belső OLE adatokat; azok képként vagy külsőleg szerkeszthető tartalomként jelenhetnek meg.

**Lerövidhetem‑e a betűtípus helyettesítést csak az előadás egy részére (diák vagy régiók szerint)?**

Célzott helyettesítés lehetséges, ha a betűtípust a szükséges objektumok/kötetek szintjén módosítja, ahelyett, hogy globálisan alkalmazná az egész dokumentumra. A renderelés során a betűtípus‑kiválasztási logika továbbra is ugyanaz marad.

**Hogyan tudom előre meghatározni, hogy a prezentáció mely betűtípusokat használ?**

Használja a prezentáció [betűtípus‑kezelőjét](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsmanager/): ez listát ad a [használatban lévő családokról](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsmanager/getfonts/) és információkat a [szubsztitúciókról/„ismeretlen” betűtípusokról](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsmanager/getsubstitutions/), ami segít a helyettesítés megtervezésében.

**A betűtípus helyettesítés működik‑e PDF‑/képkonvertálás során?**

Igen. Exportáláskor az Aspose.Slides ugyanazt a [betűtípus‑kiválasztási/szubsztitúciós sorrendet](/slides/hu/cpp/font-selection-sequence/) alkalmazza, így a előre végzett helyettesítést a konvertálás tiszteletben tartja.

**Telepíteni kell a cél‑betűtípust a rendszerbe, vagy csatolhatok egy betűtípus‑mappát?**

Telepítés nem szükséges: a könyvtár lehetővé teszi a [külső betűtípusok betöltését](/slides/hu/cpp/custom-font/) felhasználói mappákból a [renderelés és export](/slides/hu/cpp/convert-powerpoint/) során.

**A helyettesítés megoldja‑e a „tofu” (négyzetek) megjelenését a karakterek helyett?**

Csak akkor, ha a cél‑betűtípus ténylegesen tartalmazza a szükséges glifeket. Ha nem, [konfigurálja a tartalékbetűtípust](/slides/hu/cpp/fallback-font/) a hiányzó karakterek lefedéséhez.