---
title: A betűtípus-csere egyszerűsítése a .NET prezentációkban
linktitle: Betűtípus csere
type: docs
weight: 60
url: /hu/net/font-replacement/
keywords:
- betűtípus
- betűtípus cseréje
- betűtípus csere
- betűtípus módosítása
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Cserélje könnyedén a betűtípusokat az Aspose.Slides for .NET-ben, hogy egységes tipográfiát biztosítson a PowerPoint és OpenDocument prezentációkban."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy egy betűtípust egy másikra cseréljen a teljes bemutató során. Amikor egy betűtípust cserélnek, az eredeti betűtípus minden előfordulása az új betűtípusra módosul.

A betűtípus csere végrehajtásához töltse be a bemutatót, határozza meg a forrásbetűtípust és a helyettesítő betűtípust, hívja meg a betűtípus csere metódust, majd mentse el a módosított bemutatót PPTX fájlként. Ez a megközelítés akkor hasznos, ha szándékosan szeretne egy betűtípuscsaládot másikra cserélni a bemutató során.

## **Betűtípusok cseréje**

Ha meggondolja magát egy betűtípussal kapcsolatban, lecserélheti azt egy másik betűtípusra. A régi betűtípus minden előfordulása az új betűtípusra lesz cserélve.

1. Töltse be a megfelelő bemutatót.  
2. Töltse be a lecserélendő betűtípust.  
3. Töltse be az új betűtípust.  
4. Cserélje le a betűtípust.  
5. Írja ki a módosított bemutatót PPTX fájlként.  

Ez a C# kód bemutatja a betűtípus cseréjét:

```c#
// Betölt egy bemutatót
Presentation presentation = new Presentation("Fonts.pptx");

// Betölti a forrásbetűtípust, amelyet cserélni fognak
IFontData sourceFont = new FontData("Arial");

// Betölti az új betűtípust
IFontData destFont = new FontData("Times New Roman");

// Lecseréli a betűtípusokat
presentation.FontsManager.ReplaceFont(sourceFont, destFont);

// Elmenti a bemutatót
presentation.Save("UpdatedFont_out.pptx", SaveFormat.Pptx);
```

{{% alert title="Megjegyzés" color="warning" %}} 
Az egyes feltételek (például ha egy betűtípust nem lehet elérni) esetén történő viselkedés szabályozásához lásd a [**Betűtípus helyettesítés**](/slides/hu/net/font-substitution/)-t. 
{{% /alert %}}

## **GYIK**

**Mi a különbség a "betűtípus csere", "betűtípus helyettesítés" és a "fallback betűtípusok" között?**

A csere egy szándékos átváltás egy családról egy másikra az egész dokumentumban. [Helyettesítés](/slides/hu/net/font-substitution/) egy olyan szabály, mint „ha a betűtípus nem érhető el, használja X‑et.” [Fallback](/slides/hu/net/fallback-font/) egyedi hiányzó karakterekre kerül alkalmazásra, amikor az alapbetűtípus telepítve van, de nem tartalmazza a szükséges karaktereket.

**Érvényes‑e a csere a mesterdia, elrendezések, jegyzetek és a kommentek esetén?**

Igen. A csere minden olyan bemutatóobjektust érint, amely az eredeti betűtípust használja, beleértve a mesterdia és a jegyzetek is; a kommentek is a dokumentum részei, és a betűtípus‑motor figyelembe veszi őket.

**Módosul‑e a betűtípus a beágyazott OLE objektumokban (például Excel‑ben)?**

Nem. Az [OLE tartalom](/slides/hu/net/manage-ole/) saját alkalmazása által van vezérelve. A bemutatóban végzett csere nem formázza újra a belső OLE adatokat; előfordulhat, hogy képként vagy külsőleg szerkeszthető tartalomként jelenik meg.

**Lecserélhetek egy betűtípust csak a bemutató egy részén (diák vagy régiók szerint)?**

Céltudatos csere lehetséges, ha a betűtípust a szükséges objektumok/körök szintjén módosítja, ahelyett, hogy globális cserét alkalmazna az egész dokumentumra. A megjelenítés során alkalmazott általános betűtípus‑kiválasztási logika változatlan marad.

**Hogyan tudom előre meghatározni, hogy a bemutató mely betűtípusokat használ?**

Használja a bemutató [betűtípuskezelőjét](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsmanager/): ez listát biztosít a [használt családokról](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsmanager/getfonts/) és információt a [helyettesítésekről/„ismeretlen” betűtípusokról](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsmanager/getsubstitutions/), ami segít megtervezni a cserét.

**Működik‑e a betűtípus csere PDF‑/képek konvertálásakor?**

Igen. Exportáláskor az Aspose.Slides ugyanazt a [betűtípus kiválasztási/helyettesítési sorrendet](/slides/hu/net/font-selection-sequence/) alkalmazza, így az előzetesen végrehajtott csere a konvertálás során figyelembe lesz véve.

**Szükséges‑e a célbetűtípust telepíteni a rendszerbe, vagy elég egy betűtípus mappát csatolni?**

Telepítés nem szükséges: a könyvtár lehetővé teszi a [külső betűtípusok betöltését](/slides/hu/net/custom-font/) felhasználói mappákból a [megjelenítés és export](/slides/hu/net/convert-powerpoint/) során.

**Javíthatja‑e a csere a „tofu” (négyzetek) problémát, amikor karakterek hiányoznak?**

Csak akkor, ha a célbetűtípus valójában tartalmazza a szükséges glifeket. Ha nem, [állítsa be a fallbacket](/slides/hu/net/fallback-font/), hogy lefedje a hiányzó karaktereket.