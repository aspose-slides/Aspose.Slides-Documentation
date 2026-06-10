---
title: Betűtípus-helyettesítés áramvonalasítása prezentációkban Python használatával
linktitle: Betűtípus helyettesítés
type: docs
weight: 60
url: /hu/python-net/font-replacement/
keywords:
- betűtípus
- betűtípus cseréje
- betűtípus helyettesítés
- betűtípus módosítása
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Zökkenőmentesen cserélje a betűtípusokat az Aspose.Slides Python segítségével a .NET-en keresztül, hogy konzisztens tipográfiát biztosítson a PowerPoint és OpenDocument prezentációkban."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy egy betűtípust egy másikkal helyettesítsen az egész prezentáció során. Amikor egy betűtípust helyettesítenek, az eredeti betűtípus minden előfordulása az új betűtípusra változik.

A betűtípus-helyettesítés végrehajtásához töltse be a prezentációt, adja meg a forrásbetűtípust és a helyettesítő betűtípust, hívja meg a betűtípus-helyettesítési metódust, és mentse a módosított prezentációt PPTX fájlként. Ez a megközelítés akkor hasznos, ha szándékosan szeretne egy betűcsaládot egy másikra cserélni a prezentációban.

## **Betűtípusok helyettesítése**

Ha mégsem szeretné használni az aktuális betűtípust, helyettesítheti azt egy másik betűtípussal. A régi betűtípus minden előfordulása az új betűtípusra lesz cserélve.

Az Aspose.Slides a következő módon teszi lehetővé a betűtípus helyettesítését:

1. Töltse be a megfelelő prezentációt. 
2. Töltse be a helyettesítendő betűtípust. 
3. Töltse be az új betűtípust. 
4. Helyettesítse a betűtípust. 
5. Írja ki a módosított prezentációt PPTX fájlként.

Ez a Python‑kód bemutatja a betűtípus helyettesítését:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Betölt egy prezentációt
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Betölti a helyettesítendő forrásbetűtípust
    sourceFont = slides.FontData("Arial")

    # Betölti az új betűtípust
    destFont = slides.FontData("Times New Roman")

    # Kicseréli a betűtípusokat
    presentation.fonts_manager.replace_font(sourceFont, destFont)

    # Mentse a prezentációt
    presentation.save("UpdatedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Note" color="warning" %}} 

A szabályok beállításához, amelyek meghatározzák, mi történjen bizonyos feltételek esetén (például ha egy betűtípus nem érhető el), lásd a [**Font Substitution**](/slides/hu/python-net/font-substitution/). 

{{% /alert %}}

## **GYIK**

**Mi a különbség a „betűtípus helyettesítés”, a „betűtípus szubsztitúció” és a „fallback betűtípusok” között?**

A helyettesítés egy szándékos váltás egy családról egy másikra a teljes dokumentumban. A [Substitution](/slides/hu/python-net/font-substitution/) egy szabály, például „ha a betűtípus nem érhető el, használja ezt”. A [Fallback](/slides/hu/python-net/fallback-font/) egyedi hiányzó glifekre alkalmazott megoldás, amikor az alapbetűtípus telepítve van, de nem tartalmazza a szükséges karaktereket.

**A helyettesítés vonatkozik a mesterdia‑slide‑okra, elrendezésekre, jegyzetekre és megjegyzésekre is?**

Igen. A helyettesítés minden prezentációs objektumra kihat, amely az eredeti betűtípust használja, beleértve a mesterdia‑slide‑okat és a jegyzeteket; a megjegyzések is a dokumentum részei, és a betűtípus‑motor figyelembe veszi őket.

**Megváltozik-e a betűtípus a beágyazott OLE‑objektumokban (például Excelben)?**

Nem. Az [OLE content](/slides/hu/python-net/manage-ole/) saját alkalmazása által van szabályozva. A prezentációban történő helyettesítés nem formázza újra a belső OLE‑adatokat; azok képként vagy külsőleg szerkeszthető tartalomként jelenhetnek meg.

**Lefordíthatom-e a betűtípust csak a prezentáció egy részén (dia vagy terület szerint)?**

Célzott helyettesítés lehetséges, ha a betűtípust a szükséges objektumok/tartományok szintjén változtatja meg, ahelyett, hogy globális helyettesítést alkalmazna a teljes dokumentumra. Az általános betűtípus‑kiválasztási logika a renderelés során változatlan marad.

**Hogyan tudom előre meghatározni, hogy mely betűtípusok vannak használatban a prezentációban?**

Használja a prezentáció [font manager]‑ét (https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsmanager/): ez listát ad a [használt családokról] (https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsmanager/get_fonts/) és információt a [szubsztitúciókról/„ismeretlen” betűtípusokról] (https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsmanager/get_substitutions/), ami segít a helyettesítés megtervezésében.

**Működik a betűtípus‑helyettesítés PDF‑/kép‑konverzió során?**

Igen. Az exportálás során az Aspose.Slides ugyanazt a [font selection/substitution sequence](/slides/hu/python-net/font-selection-sequence/) alkalmazza, így előre végzett helyettesítés tiszteletben van tartva a konverzió során.

**Szükséges-e a célbetűtípust telepíteni a rendszerbe, vagy feltölthetek egy betűtípus‑mappát?**

A telepítés nem kötelező: a könyvtár lehetővé teszi a [loading external fonts](/slides/hu/python-net/custom-font/) használatát felhasználói mappákból a [rendering and export](/slides/hu/python-net/convert-powerpoint/) során.

**A helyettesítés megoldja-e a „tofu” (négyzet) megjelenést a karakterek helyett?**

Csak akkor, ha a célbetűtípus valóban tartalmazza a szükséges glifeket. Ha nem, [configure fallback](/slides/hu/python-net/fallback-font/) a hiányzó karakterek lefedésére.